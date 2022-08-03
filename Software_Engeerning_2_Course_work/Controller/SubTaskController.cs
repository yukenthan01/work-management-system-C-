using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Software_Engeerning_2_Course_work.View.subTask;
using Software_Engeerning_2_Course_work.Models;
using FluentValidation.Results;
using Software_Engeerning_2_Course_work.validators;

namespace Software_Engeerning_2_Course_work.Controller
{
    class SubTaskController
    {
        LayoutFormatter layoutFormatter = new LayoutFormatter();
        ConnectionString cs = new ConnectionString();
        SqlConnection con;
        public SubTaskController()
        {
            con = new SqlConnection(cs.dbCon);
        }

        public void create()
        {
            layoutFormatter.formAlign(new SubTaskAdd(), "Register New Sub Task");
        }
        public void view()
        {
            layoutFormatter.formAlign(new SubTaskView(), "View Sub Tasks");
        }
        public void update(SubTask subTasks, GroupBox groupBox)
        {
            if (checktheValidation(subTasks, groupBox))
            {
                using (con = new SqlConnection(cs.dbCon))
                {
                    string query = "UPDATE subTask SET tittle = @tittle ,description = @description, startDate = @startDate, endDate = @endDate, duration = @duration, percentage = @percentage, status = @status,task_id = @task_id,user_id = @user_id Where Id = @id";
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@tittle", subTasks.Tittle);
                    command.Parameters.AddWithValue("@description", subTasks.Description);
                    command.Parameters.AddWithValue("@startDate", subTasks.StartDate);
                    command.Parameters.AddWithValue("@endDate", subTasks.EndDate);
                    command.Parameters.AddWithValue("@duration", subTasks.Duration);
                    command.Parameters.AddWithValue("@percentage", subTasks.Percentage);
                    command.Parameters.AddWithValue("@status", subTasks.Status);
                    command.Parameters.AddWithValue("@task_id", subTasks.TaskId);
                    command.Parameters.AddWithValue("@user_id", subTasks.UserId);
                    command.Parameters.AddWithValue("@id", subTasks.Id);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        view();
                        MessageBox.Show("Sub Task Details Updated Successfully", "Sub Task", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (subTasks.Status != "Not Started")
                {
                    SendMail sendMail = new SendMail(subTasks.Id.ToString(), subTasks.Tittle, subTasks.Description, subTasks.StartDate.ToShortDateString(), subTasks.Status);
                    sendMail.mailGenerate(getEmail(subTasks.UserId),"Sub Task Status Update.");
                }
                

            }
        }
        public string getEmail(int userId)
        {
            string userEmail = "";
            try
            {
                con = new SqlConnection(cs.dbCon);
                SqlCommand cmd = new SqlCommand("SELECT email FROM users WHERE Id = '"+userId+"'", con);

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        userEmail = sdr[0].ToString();
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
            return userEmail;
        }
        public void edit(int id)
        {
            List<string> project = new List<string>();
            List<string> user = new List<string>();
            List<string> task = new List<string>();
            SubTask SubTask = new SubTask();
            SqlCommand cmd = new SqlCommand("SELECT * FROM SubTask WHERE Id ='" + id.ToString() + "'", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                SubTask.Id = int.Parse(sdr[0].ToString());
                SubTask.Tittle = sdr[1].ToString();
                SubTask.Description = sdr[2].ToString();
                SubTask.StartDate = DateTime.Parse(sdr[3].ToString());
                SubTask.EndDate = DateTime.Parse(sdr[4].ToString());
                SubTask.Duration = sdr[5].ToString();
                SubTask.Percentage = int.Parse(sdr[6].ToString());
                SubTask.Status = sdr[7].ToString();
                SubTask.TaskId = int.Parse(sdr[8].ToString());
                SubTask.UserId = int.Parse(sdr[9].ToString());
            }
            con.Close();
            SqlCommand cmd2 = new SqlCommand("SELECT tasks.project_id AS project_id,projects.tittle AS project_tittle,tasks.tittle  FROM tasks INNER JOIN  projects on tasks.project_id = projects.Id  where tasks.Id = '"+ SubTask.TaskId.ToString() + "' ", con);
            con.Open();
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            while (sdr2.Read())
            {
               project.Add(sdr2[0].ToString() + '-' + sdr2[1].ToString());
                task.Add(SubTask.TaskId.ToString() + '-' + sdr2[2].ToString());
            }
            con.Close();
            SqlCommand cmd3 = new SqlCommand("SELECT firstname from users where Id = '" + SubTask.UserId.ToString() + "' ", con);
            con.Open();
            SqlDataReader sdr3 = cmd3.ExecuteReader();
            while (sdr3.Read())
            {
                user.Add(SubTask.UserId.ToString() + '-' + sdr3[0].ToString());
            }
            con.Close();
            layoutFormatter.formAlign(new SubTaskAdd(SubTask,project,user, task), "Edit Sub Task");
        }
        public void loadView(DataGridView dataGridView, string field = null, string searchValue = null)
        {
            string query = "";
            string current_userId = Environment.GetEnvironmentVariable("id");
            string userRole = Environment.GetEnvironmentVariable("userRole");
            if (field == null && searchValue == null)
            {
                if (userRole != "Developers")
                {
                    query = "SELECT subTask.Id as Id, subTask.tittle as tittle, subTask.description as description, subTask.startDate as startDate, subTask.endDate as endDate, subTask.duration as duration, subTask.percentage as percentage, subTask.task_id as task_id,subTask.user_id AS user_id, tasks.tittle AS task_tittle, users.firstname AS firstname FROM subTask INNER JOIN tasks on tasks.Id = subTask.task_id INNER JOIN users on users.id = subTask.user_id ";
                }
                else
                {
                    query = "SELECT subTask.Id as Id, subTask.tittle as tittle, subTask.description as description, subTask.startDate as startDate, subTask.endDate as endDate, subTask.duration as duration, subTask.percentage as percentage, subTask.task_id as task_id,subTask.user_id AS user_id, tasks.tittle AS task_tittle, users.firstname AS firstname FROM subTask INNER JOIN tasks on tasks.Id = subTask.task_id INNER JOIN users on users.id = subTask.user_id where subTask.user_id ='" + current_userId + "'";
                }
            }
            else if (field == "All")
            {
                if (userRole != "Developers")
                {
                    query = "SELECT subTask.Id as Id, subTask.tittle as tittle, subTask.description as description, subTask.startDate as startDate, subTask.endDate as endDate, subTask.duration as duration, subTask.percentage as percentage, subTask.task_id as task_id,subTask.user_id AS user_id, tasks.tittle AS task_tittle, users.firstname AS firstname FROM subTask INNER JOIN tasks on tasks.Id = subTask.task_id INNER JOIN users on users.id = subTask.user_id";
                }
                else
                {
                    query = "SELECT subTask.Id as Id, subTask.tittle as tittle, subTask.description as description, subTask.startDate as startDate, subTask.endDate as endDate, subTask.duration as duration, subTask.percentage as percentage, subTask.task_id as task_id,subTask.user_id AS user_id, tasks.tittle AS task_tittle, users.firstname AS firstname FROM subTask INNER JOIN tasks on tasks.Id = subTask.task_id INNER JOIN users on users.id = subTask.user_id where subTask ='" + current_userId + "'";
                }
            }
            else if (field != "" && searchValue != "")
            {
                if (field == "ID")
                {
                    if (userRole != "Developers")
                    {
                        query = "SELECT subTask.Id as Id, subTask.tittle as tittle, subTask.description as description, subTask.startDate as startDate, subTask.endDate as endDate, subTask.duration as duration, subTask.percentage as percentage, subTask.task_id as task_id,subTask.user_id AS user_id, tasks.tittle AS task_tittle, users.firstname AS firstname FROM subTask INNER JOIN tasks on tasks.Id = subTask.task_id INNER JOIN users on users.id = subTask.user_id where subTask.Id = '" + searchValue + "'  ";
                    }
                    else 
                    {
                        query = "SELECT subTask.Id as Id, subTask.tittle as tittle, subTask.description as description, subTask.startDate as startDate, subTask.endDate as endDate, subTask.duration as duration, subTask.percentage as percentage, subTask.task_id as task_id,subTask.user_id AS user_id, tasks.tittle AS task_tittle, users.firstname AS firstname FROM subTask INNER JOIN tasks on tasks.Id = subTask.task_id INNER JOIN users on users.id = subTask.user_id where subTask.Id = '" + searchValue + "' where subTask.user_id = '"+ current_userId +"' ";
                    }
                }
                else if (field == "Start Date")
                {
                    if (userRole != "Developers")
                    {
                        query = "SELECT subTask.Id as Id, subTask.tittle as tittle, subTask.description as description, subTask.startDate as startDate, subTask.endDate as endDate, subTask.duration as duration, subTask.percentage as percentage, subTask.task_id as task_id,subTask.user_id AS user_id, tasks.tittle AS task_tittle, users.firstname AS firstname FROM subTask INNER JOIN tasks on tasks.Id = subTask.task_id INNER JOIN users on users.id = subTask.user_id where subTask.startDate = '" + searchValue + "'  ";
                    }
                    else
                    {
                        query = "SELECT subTask.Id as Id, subTask.tittle as tittle, subTask.description as description, subTask.startDate as startDate, subTask.endDate as endDate, subTask.duration as duration, subTask.percentage as percentage, subTask.task_id as task_id,subTask.user_id AS user_id, tasks.tittle AS task_tittle, users.firstname AS firstname FROM subTask INNER JOIN tasks on tasks.Id = subTask.task_id INNER JOIN users on users.id = subTask.user_id where subTask.startDate = '" + searchValue + "' where subTask.user_id = '" + current_userId + "' ";
                    }
                }
                else
                {
                    if (userRole != "Developers")
                    {
                        query = "SELECT subTask.Id as Id, subTask.tittle as tittle, subTask.description as description, subTask.startDate as startDate, subTask.endDate as endDate, subTask.duration as duration, subTask.percentage as percentage, subTask.task_id as task_id,subTask.user_id AS user_id, tasks.tittle AS task_tittle, users.firstname AS firstname FROM subTask INNER JOIN tasks on tasks.Id = subTask.task_id INNER JOIN users on users.id = subTask.user_id where  subTask." + field.ToLower() + " = '" + searchValue + "'  ";
                    }
                    else
                    {
                        query = "SELECT subTask.Id as Id, subTask.tittle as tittle, subTask.description as description, subTask.startDate as startDate, subTask.endDate as endDate, subTask.duration as duration, subTask.percentage as percentage, subTask.task_id as task_id,subTask.user_id AS user_id, tasks.tittle AS task_tittle, users.firstname AS firstname FROM subTask INNER JOIN tasks on tasks.Id = subTask.task_id INNER JOIN users on users.id = subTask.user_id where  subTask." + field.ToLower() + " = '" + searchValue + "' where subTask.user_id = '" + current_userId + "' ";
                    }
                }

            }
            con = new SqlConnection(cs.dbCon);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                da = new SqlDataAdapter(query, con);
                da.Fill(dt);
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Sub Task View", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void store(SubTask subTasks, GroupBox groupBox)
        {
            if (checktheValidation(subTasks, groupBox))
            {
                using (con = new SqlConnection(cs.dbCon))
                {
                    string query = "INSERT INTO subTask (tittle,description,startDate,endDate,duration,percentage,status,task_id,user_id)OUTPUT INSERTED.ID VALUES (@tittle,@description,@startDate,@endDate,@duration,@percentage,@status,@task_id,@user_id)";
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@tittle", subTasks.Tittle);
                    command.Parameters.AddWithValue("@description", subTasks.Description);
                    command.Parameters.AddWithValue("@startDate", subTasks.StartDate);
                    command.Parameters.AddWithValue("@endDate", subTasks.EndDate);
                    command.Parameters.AddWithValue("@duration", subTasks.Duration);
                    command.Parameters.AddWithValue("@percentage", subTasks.Percentage);
                    command.Parameters.AddWithValue("@status", subTasks.Status);
                    command.Parameters.AddWithValue("@task_id", subTasks.TaskId);
                    command.Parameters.AddWithValue("@user_id", subTasks.UserId);
                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("New Sub Task Created", "Task", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public bool checktheValidation(SubTask subTask, GroupBox groupBox,string update = null)
        {
            bool valid = false;
            SubTaskValidator subTaskValidator = null;
            if (update == null)
            {
                subTaskValidator = new SubTaskValidator();
            }
            else
            {
               // subTaskController = new SubTaskController("update");
            }
            ValidationResult results = subTaskValidator.Validate(subTask);

            if (!results.IsValid)
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
                            if (c.AccessibleName == "labelErrorUsers" && failure.PropertyName == "userId")
                            {
                                c.Text = failure.ErrorMessage;
                                c.Visible = true;
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
                        if (c.AccessibleName == "labelErrorUsers")
                        {
                            c.Visible = false;
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
        public void getTaskUsers(ComboBox combo, string projectId)
        {

            string query = "SELECT user_id FROM tasksUsers WHERE task_id = '" + projectId + "'";
            con = new SqlConnection(cs.dbCon);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                da = new SqlDataAdapter(query, con);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
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
                            combo.Items.Add(sdr[0].ToString() + '-' + sdr[2].ToString());
                        }
                        combo.Enabled = true;
                    }
                }
                else
                {
                    combo.Items.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Project Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        public void getProjectTasks(ComboBox comboBox, string projectId)
        {

            string query = "SELECT Id,tittle FROM tasks WHERE project_id = '" + projectId + "'";
            con = new SqlConnection(cs.dbCon);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                da = new SqlDataAdapter(query, con);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count;i++ )
                    {
                        comboBox.Items.Add(dt.Rows[i][0].ToString() + '-' + dt.Rows[i][1].ToString());
                        comboBox.Enabled = true;
                    }
                }
                else
                {
                    comboBox.Items.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Sub Task Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
