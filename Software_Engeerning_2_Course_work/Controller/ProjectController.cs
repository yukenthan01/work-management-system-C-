using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Software_Engeerning_2_Course_work.View.project;
using Software_Engeerning_2_Course_work.View;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using Software_Engeerning_2_Course_work.Models;
using Software_Engeerning_2_Course_work.validators;
using FluentValidation.Results;
using System.Globalization;

namespace Software_Engeerning_2_Course_work
{
    class ProjectController
    {
        LayoutFormatter layoutFormatter = new LayoutFormatter();
        ConnectionString cs = new ConnectionString();
        SqlConnection con;
        public ProjectController()
        {
            con = new SqlConnection(cs.dbCon);
        }

        public void create()
        {
            layoutFormatter.formAlign(new ProjectAdd(), "Register New Project");
            
        }
        public void view()
        {
            layoutFormatter.formAlign(new ProjectView(), "View Projects");

        }
        public void edit(int id)
        {
            Project project = new Project();
            SqlCommand cmd = new SqlCommand("SELECT * FROM projects WHERE Id ='" + id.ToString() + "'", con);
            
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            
            while (sdr.Read())
            {
                project.Id = int.Parse(sdr[0].ToString());
                project.Tittle = sdr[1].ToString();
                project.Description = sdr[2].ToString();
                project.StartDate = DateTime.Parse(sdr[3].ToString());
                project.EndDate = DateTime.Parse(sdr[4].ToString());
                project.Duration = sdr[5].ToString();
                project.Percentage = int.Parse(sdr[6].ToString());
                project.Status = sdr[7].ToString();

            }
            
            con.Close();
            con.Open();
            //get the id form user project 
            string projectUsers = "SELECT users_id FROM projectsUsers WHERE projects_id ='" + id.ToString() + "'";
            SqlDataAdapter daprojectUsers = new SqlDataAdapter();
            DataTable dtprojectUsers = new DataTable();
            daprojectUsers = new SqlDataAdapter(projectUsers, con);
            daprojectUsers.Fill(dtprojectUsers);
            string[] arrray = dtprojectUsers.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray();
            int[] ids = Array.ConvertAll(arrray, int.Parse);

            List<string> usersId = new List<string>();
            
            string query = "SELECT * FROM users WHERE Id IN  (" + String.Join(",", ids) + ")";
            con = new SqlConnection(cs.dbCon);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                usersId.Add(dt.Rows[i][0] + " - " + dt.Rows[i][2] + " " + dt.Rows[i][3]);
            }
            con.Close();
            layoutFormatter.formAlign(new ProjectAdd(project,usersId), "Edit Project");
        }
        public void update(Project project, string[] usersId, GroupBox groupBox)
        {
            if (checktheValidation(project, groupBox, usersId,"update"))
            {
                using (con = new SqlConnection(cs.dbCon))
                {
                    string query = "UPDATE projects SET tittle = @tittle ,description = @description, startDate = @startDate, endDate = @endDate, duration = @duration, percentage = @percentage, status = @status Where Id = @id";
                    
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@tittle", project.Tittle);
                    command.Parameters.AddWithValue("@description", project.Description);
                    command.Parameters.AddWithValue("@startDate", project.StartDate);
                    command.Parameters.AddWithValue("@endDate", project.EndDate);
                    command.Parameters.AddWithValue("@duration", project.Duration);
                    command.Parameters.AddWithValue("@percentage", project.Percentage);
                    command.Parameters.AddWithValue("@status", project.Status);
                    command.Parameters.AddWithValue("@id", project.Id);

                    string delete = "DELETE FROM projectsUsers WHERE projects_id ='" + project.Id + "'";
                    SqlCommand commandDelete = new SqlCommand(delete, con);
                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        commandDelete.ExecuteNonQuery();
                        for (int id = 0; id < usersId.Count(); id++)
                        {
                            
                            string projectUsers = "INSERT INTO projectsUsers (projects_id,users_id)OUTPUT INSERTED.ID VALUES (@proid" + id + ",@users_id)";
                            SqlCommand projectUsersCommand = new SqlCommand(projectUsers, con);
                            projectUsersCommand.Parameters.AddWithValue("@proid" + id, project.Id);
                            projectUsersCommand.Parameters.AddWithValue("@users_id", usersId[id]);
                            projectUsersCommand.ExecuteNonQuery();
                        }
                        MessageBox.Show("Project Details Updated Successfully", "Project Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        layoutFormatter.formClear(groupBox);

                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
        public void getUsers(CheckedListBox checkedListBox)
        {
            
            string query = "SELECT * FROM users WHERE status = 'Working'";
            con = new SqlConnection(cs.dbCon);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                da = new SqlDataAdapter(query, con);
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    checkedListBox.Items.Add(dt.Rows[i][0] + " - " + dt.Rows[i][2] + " " + dt.Rows[i][3]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Project Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void loadView(DataGridView dataGridView, string field = null, string searchValue = null)
        {
            string query = "";

            if (field == null && searchValue == null )
            {
                query = "SELECT * FROM projects";
            }
            else if (field == "All")
            {
                query = "SELECT * FROM projects";
            }
            else if (field != "" && searchValue != "")
            {
                
                if (field == "ID")
                {
                    query = "select * from projects where Id = '" + searchValue + "'  ";
                }
                else if (field == "Start Date")
                {
                    query = "select * from projects where startDate = '" + searchValue+ "'  ";
                }
                else
                {
                    query = "select * from projects where " + field.ToLower() + " = '" + searchValue + "'  ";
                }

            }
            con = new SqlConnection(cs.dbCon);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable("projects");

            try
            {
                da = new SqlDataAdapter(query, con);
                da.Fill(dt);
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Project View", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void store(Project project, string[] usersId,GroupBox groupBox)
        {
            if (checktheValidation(project, groupBox,usersId))
            {
                    using (con = new SqlConnection(cs.dbCon))
                    {
                        string query = "INSERT INTO projects (tittle,description,startDate,endDate,duration,percentage,status)OUTPUT INSERTED.ID VALUES (@tittle,@description,@startDate,@endDate,@duration,@percentage,@status)";
                        SqlCommand command = new SqlCommand(query, con);
                        command.Parameters.AddWithValue("@tittle", project.Tittle);
                        command.Parameters.AddWithValue("@description", project.Description);
                        command.Parameters.AddWithValue("@startDate", project.StartDate);
                        command.Parameters.AddWithValue("@endDate", project.EndDate);
                        command.Parameters.AddWithValue("@duration", project.Duration);
                        command.Parameters.AddWithValue("@percentage", project.Percentage);
                        command.Parameters.AddWithValue("@status", project.Status);
                        try
                        {
                            con.Open();
                           // command.ExecuteNonQuery();
                            int lastId = (int)command.ExecuteScalar();
                            
                            for (int id = 0; id < usersId.Count(); id++)
                            {
                                string projectUsers = "INSERT INTO projectsUsers (projects_id,users_id)OUTPUT INSERTED.ID VALUES (@proid"+id+",@users_id)";
                                SqlCommand projectUsersCommand = new SqlCommand(projectUsers, con);
                                projectUsersCommand.Parameters.AddWithValue("@proid"+id, lastId);
                                projectUsersCommand.Parameters.AddWithValue("@users_id", usersId[id]);
                                projectUsersCommand.ExecuteNonQuery();
                            }
                        
                            MessageBox.Show("New Projected Created", "Project", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            layoutFormatter.formClear(groupBox);

                        }
                        catch (SqlException e)
                        {
                            MessageBox.Show(e.ToString());
                        }
                        finally
                        {
                            con.Close();
                        }
                }
                
            }
            
        }
        
        public void autoID(Label label)
        {
            con = new SqlConnection(cs.dbCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(Id),999)+1 FROM projects", con);
            int tranID = int.Parse(cmd.ExecuteScalar().ToString());
            string rs = "R-" + tranID;
            con.Close();
            label.Text = tranID.ToString();
        }
        public bool checktheValidation(Project project, GroupBox groupBox,string[] user,string update = null)
        {
            bool valid = false;
            ProjectValidator projectValidator = null;
            if (update == null)
            {
                projectValidator = new ProjectValidator();
            }
            else
            {
                projectValidator = new ProjectValidator("update");
            }
            ValidationResult results = projectValidator.Validate(project);
            
            if (!results.IsValid && user.Count() >= 0)
            {
                
                foreach (var failure in results.Errors)
                {
                    foreach (Control c in groupBox.Controls)
                    {
                        if (c is Label)
                        {
                            if (c.AccessibleName == "labelErrorTittle" && failure.PropertyName == "Tittle")
                            {
                                c.Text = failure.ErrorMessage;
                                c.Visible = true;
                            }
                            if (c.AccessibleName == "labelErrorDescription" && failure.PropertyName == "Description")
                            {
                                c.Text = failure.ErrorMessage;
                                c.Visible = true;
                            }
                            if (c.AccessibleName == "labelErrorStartDate" && failure.PropertyName == "StartDate")
                            {
                                c.Text = failure.ErrorMessage;
                                c.Visible = true;
                            }
                            if (c.AccessibleName == "labelErrorDuration" && failure.PropertyName == "Duration")
                            {
                                c.Text = failure.ErrorMessage;
                                c.Visible = true;
                            }
                            if (c.AccessibleName == "labelErrorEndDate" && failure.PropertyName == "EndDate")
                            {
                                c.Text = failure.ErrorMessage;
                                c.Visible = true;
                            }
                            if (c.AccessibleName == "labelErrorStatus" && failure.PropertyName == "Status")
                            {
                                c.Text = failure.ErrorMessage;
                                c.Visible = true;
                            }
                            if (c.AccessibleName == "labelErrorPercentage" && failure.PropertyName == "Percentage")
                            {
                                c.Text = failure.ErrorMessage;
                                c.Visible = true;
                            }
                            if (c.AccessibleName == "labelErrorUsers")
                            {
                                if(user.Count() >= 0)
                                {
                                    c.Text = "Select the users";
                                    c.Visible = true;
                                }
                                else
                                {
                                    c.Visible = false;
                                }
                            }

                        }
                    }

                }
            }
            else
            {
                foreach (Control c in groupBox.Controls)
                {
                    if (c is Label)
                    {
                        if (c.AccessibleName == "labelErrorTittle")
                        {
                            c.Visible = false;
                        }
                        if (c.AccessibleName == "labelErrorDescription")
                        {
                            c.Visible = false;
                        }
                        if (c.AccessibleName == "labelErrorStartDate")
                        {
                            c.Visible = false;
                        }
                        if (c.AccessibleName == "labelErrorDuration")
                        {
                            c.Visible = false;
                        }
                        if (c.AccessibleName == "labelErrorEndDate")
                        {
                            c.Visible = false;
                        }
                        if (c.AccessibleName == "labelErrorStatus")
                        {
                            c.Visible = false;
                        }
                        if (c.AccessibleName == "labelErrorPercentage")
                        {
                            c.Visible = false;
                        }
                        if (user.Count() >= 0)
                        {
                            if (c.AccessibleName == "labelErrorUsers")
                            {
                                c.Visible = false;
                            }
                        }
                            

                    }
                }
                valid = true;
            }
            return valid;
        }

    }
}
