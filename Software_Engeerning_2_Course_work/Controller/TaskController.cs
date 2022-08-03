using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentValidation.Results;
using Software_Engeerning_2_Course_work.Models;
using Software_Engeerning_2_Course_work.validators;
using Software_Engeerning_2_Course_work.View.task;
namespace Software_Engeerning_2_Course_work.Controller
{
    class TaskController
    {
        LayoutFormatter layoutFormatter = new LayoutFormatter();
        ConnectionString cs = new ConnectionString();
        SqlConnection con;

        public TaskController()
        {
            con = new SqlConnection(cs.dbCon);
        }
        public void create()
        {
            layoutFormatter.formAlign(new TaskAdd(), "Register New Task");
        }

        public void view()
        {
            layoutFormatter.formAlign(new TaskView(), "View Tasks");
        }
        public void edit(int id)
        {
            Tasks task = new Tasks();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tasks WHERE Id ='" + id.ToString() + "'", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                task.Id = int.Parse(sdr[0].ToString());
                task.Tittle = sdr[1].ToString();
                task.Description = sdr[2].ToString();
                task.StartDate = DateTime.Parse(sdr[3].ToString());
                task.EndDate = DateTime.Parse(sdr[4].ToString());
                task.Duration = sdr[5].ToString();
                task.Percentage = int.Parse(sdr[6].ToString());
                task.Status = sdr[7].ToString();
                task.ProjectId = int.Parse(sdr[8].ToString());
            }

            con.Close();
            con.Open();
            //get the id form user project 
            string projectUsers = "SELECT user_id FROM tasksUsers WHERE task_id ='" + id.ToString() + "'";
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
                //usersId.Add(dt.Rows[i][0] + " - " + dt.Rows[i][2] );
                usersId.Add(dt.Rows[i][0].ToString() + '-' + dt.Rows[i][2].ToString());
            }
            con.Close();
            layoutFormatter.formAlign(new TaskAdd(task, usersId), "Edit Task");
        }
        public void update(Tasks task, string[] usersId, GroupBox groupBox)
        {
            if (checktheValidation(task, groupBox, usersId, "update"))
            {
                using (con = new SqlConnection(cs.dbCon))
                {
                    string query = "UPDATE tasks SET tittle = @tittle ,description = @description, startDate = @startDate, endDate = @endDate, duration = @duration, percentage = @percentage, status = @status,project_id = @project_id Where Id = @id";

                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@tittle", task.Tittle);
                    command.Parameters.AddWithValue("@description", task.Description);
                    command.Parameters.AddWithValue("@startDate", task.StartDate);
                    command.Parameters.AddWithValue("@endDate", task.EndDate);
                    command.Parameters.AddWithValue("@duration", task.Duration);
                    command.Parameters.AddWithValue("@percentage", task.Percentage);
                    command.Parameters.AddWithValue("@status", task.Status);
                    command.Parameters.AddWithValue("@project_id", task.ProjectId);
                    command.Parameters.AddWithValue("@id", task.Id);
                    string delete = "DELETE FROM tasksUsers WHERE task_id ='" + task.Id + "'";
                    SqlCommand commandDelete = new SqlCommand(delete, con);
                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        commandDelete.ExecuteNonQuery();
                        for (int id = 0; id < usersId.Count(); id++)
                        {

                            string projectUsers = "INSERT INTO tasksUsers (task_id,user_id)OUTPUT INSERTED.ID VALUES (@task_id" + id + ",@user_id)";
                            SqlCommand projectUsersCommand = new SqlCommand(projectUsers, con);
                            projectUsersCommand.Parameters.AddWithValue("@task_id" + id, task.Id);
                            projectUsersCommand.Parameters.AddWithValue("@user_id", usersId[id]);
                            projectUsersCommand.ExecuteNonQuery();
                        }
                        view();
                        MessageBox.Show("Task Details Updated Successfully", "Task Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void loadView(DataGridView dataGridView, string field = null, string searchValue = null)
        {
            string query = "";

            if (field == null && searchValue == null)
            {
                query = "SELECT * FROM tasks";
            }
            else if (field == "All")
            {
                query = "SELECT * FROM tasks";
            }
            else if (field != "" && searchValue != "")
            {

                if (field == "ID")
                {
                    query = "select * from tasks where Id = '" + searchValue + "'  ";
                }
                else if (field == "Start Date")
                {
                    query = "select * from tasks where startDate = '" + searchValue + "'  ";
                }
                else
                {
                    query = "select * from tasks where " + field.ToLower() + " = '" + searchValue + "'  ";
                }

            }
            con = new SqlConnection(cs.dbCon);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable("tasks");

            try
            {
                da = new SqlDataAdapter(query, con);
                da.Fill(dt);
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Task View", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void store(Tasks tasks, string[] usersId, GroupBox groupBox)
        {
            if (checktheValidation(tasks, groupBox, usersId))
            {
                using (con = new SqlConnection(cs.dbCon))
                {
                    string query = "INSERT INTO tasks (tittle,description,startDate,endDate,duration,percentage,status,project_id)OUTPUT INSERTED.ID VALUES (@tittle,@description,@startDate,@endDate,@duration,@percentage,@status,@project_id)";
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@tittle", tasks.Tittle);
                    command.Parameters.AddWithValue("@description", tasks.Description);
                    command.Parameters.AddWithValue("@startDate", tasks.StartDate);
                    command.Parameters.AddWithValue("@endDate", tasks.EndDate);
                    command.Parameters.AddWithValue("@duration", tasks.Duration);
                    command.Parameters.AddWithValue("@percentage", tasks.Percentage);
                    command.Parameters.AddWithValue("@status", tasks.Status);
                    command.Parameters.AddWithValue("@project_id", tasks.ProjectId);
                    try
                    {
                        con.Open();
                        //command.ExecuteNonQuery();
                        int lastId = (int)command.ExecuteScalar();
                        for (int id = 0; id < usersId.Count(); id++)
                        {
                            string projectUsers = "INSERT INTO tasksUsers (task_id,user_id)OUTPUT INSERTED.ID VALUES (@task_id" + id + ",@users_id)";
                            SqlCommand projectUsersCommand = new SqlCommand(projectUsers, con);
                            projectUsersCommand.Parameters.AddWithValue("@task_id" + id, lastId);
                            projectUsersCommand.Parameters.AddWithValue("@users_id", usersId[id]);
                            projectUsersCommand.ExecuteNonQuery();
                        }
                        MessageBox.Show("New Task Created", "Task", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public bool checktheValidation(Tasks tasks, GroupBox groupBox, string[] user, string update = null)
        {
            bool valid = false;
            TaskValidator taskValidator = null;
            if (update == null)
            {
                taskValidator = new TaskValidator();
            }
            else
            {
                taskValidator = new TaskValidator("update");
            }
            ValidationResult results = taskValidator.Validate(tasks);

            if (!results.IsValid && user.Count() >= 0)
            {

                foreach (var failure in results.Errors)
                {
                    foreach (Control c in groupBox.Controls)
                    {
                        if (c is Label)
                        {
                            if (c.AccessibleName == "labelErrorProjectId" && failure.PropertyName == "ProjectId")
                            {
                                c.Text = failure.ErrorMessage;
                                c.Visible = true;
                            }
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
                                if (user.Count() >= 0)
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
        public void autoID(Label label)
        {
            con = new SqlConnection(cs.dbCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(Id),999)+1 FROM tasks", con);
            int tranID = int.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            label.Text = tranID.ToString();
        }
        public void getProjectId(ComboBox comboBox)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Id,tittle FROM projects", con);
                
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                comboBox.Items.Clear();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        comboBox.Items.Add(sdr[0].ToString() + '-' + sdr[1].ToString());
                    }
                }
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
        public void getProjectUsers(CheckedListBox checkedListBox,string projectId)
        {

            string query = "SELECT users_id FROM projectsUsers WHERE projects_id = '"+ projectId + "'";
            con = new SqlConnection(cs.dbCon);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                da = new SqlDataAdapter(query, con);
                da.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    string[] arrray = dt.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray();
                    int[] ids = Array.ConvertAll(arrray, int.Parse);

                    SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE Id IN  (" + String.Join(",", ids) + ")", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            checkedListBox.Items.Add(sdr[0].ToString() + '-' + sdr[2].ToString());
                        }
                    }
                }
                else
                {
                    checkedListBox.Items.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Project Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
