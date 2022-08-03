using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Software_Engeerning_2_Course_work.View.user;
using Software_Engeerning_2_Course_work.Models;
using Software_Engeerning_2_Course_work.validators;
using FluentValidation.Results;
using System.Collections;
using System.Data;

namespace Software_Engeerning_2_Course_work.Controller
{
    class UserController
    {
        LayoutFormatter layoutFormatter = new LayoutFormatter();
        ConnectionString cs = new ConnectionString();
        SqlConnection con ;

        public UserController()
        {
            con = new SqlConnection(cs.dbCon);
        }

        //Bi
        public void create()
        {
            layoutFormatter.formAlign(new UserAdd(), "Register New User");

        }
        public void view()
        {
            layoutFormatter.formAlign(new UserView(), "View Users");
            
        }
        public void edit(int id)
        {
            Users users = new Users();
            SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE id ='" + id.ToString() + "'", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                users.Id = int.Parse(sdr[0].ToString());
                users.Tittle = sdr[1].ToString();
                users.Firstname = sdr[2].ToString();
                users.Lastname = sdr[3].ToString();
                users.Email = sdr[4].ToString();
                users.Phoneno = sdr[5].ToString();
                users.Status = sdr[6].ToString();
                users.UserRole = sdr[7].ToString();
                users.Password = sdr[8].ToString();
            }
            con.Close();
            layoutFormatter.formAlign(new UserAdd(users), "Edit Users");

        }
        //update the date form users
        public void update(Users users, GroupBox groupBox1)
        {
            if (checktheValidation(users, groupBox1))
            {
                using (con = new SqlConnection(cs.dbCon))
                {
                    string query = "UPDATE users SET tittle = @tittle ,firstname = @firstname, lastname = @lastname, email = @email, phoneno = @phoneno, status = @status, userRole = @userRole, password = @password Where Id = @id";
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@tittle", users.Tittle);
                    command.Parameters.AddWithValue("@firstname", users.Firstname);
                    command.Parameters.AddWithValue("@lastname", users.Lastname);
                    command.Parameters.AddWithValue("@email", users.Email);
                    command.Parameters.AddWithValue("@phoneno", users.Phoneno);
                    command.Parameters.AddWithValue("@status", users.Status);
                    command.Parameters.AddWithValue("@userRole", users.UserRole);
                    command.Parameters.AddWithValue("@password", users.Password);
                    command.Parameters.AddWithValue("@id", users.Id);
                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("User Details Updated Successfully", "User Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        layoutFormatter.formClear(groupBox1);
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
        // view user gride view nd serach with field method return view
        public void loadView(DataGridView dataGridView, string field = null,string searchValue =null)
        {
            string query = "";
            if (field == null && searchValue == null)
            {
                query = "SELECT * FROM users ";
            }
            else if (field != "" && searchValue != "")
            {
                if (field == "ID")
                {
                    query = "select * from users where Id = '" + searchValue + "'  ";
                }
                else
                {
                    query = "select * from users where "+field.ToLower()+" = '" + searchValue + "'  ";
                }
            }
            con = new SqlConnection(cs.dbCon);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable("users");
            try
            {
                da = new SqlDataAdapter(query, con);
                da.Fill(dt);
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "User View", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void store(Users users, GroupBox groupBox1)
        {
            if (checktheValidation(users,groupBox1)) //Input validation check is tru
            {
                using (con = new SqlConnection(cs.dbCon)) //check connection
                {
                    string query = "INSERT INTO users (tittle,firstname,lastname,email,phoneno,status,userRole,password) VALUES (@tittle,@firstname,@lastname,@email,@phoneno,@status,@userRole,@password)";
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@tittle", users.Tittle);
                    command.Parameters.AddWithValue("@firstname", users.Firstname);
                    command.Parameters.AddWithValue("@lastname", users.Lastname);
                    command.Parameters.AddWithValue("@email", users.Email);
                    command.Parameters.AddWithValue("@phoneno", users.Phoneno);
                    command.Parameters.AddWithValue("@status", users.Status);
                    command.Parameters.AddWithValue("@userRole", users.UserRole);
                    command.Parameters.AddWithValue("@password", users.Password);
                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("User Registered Successfully", "User Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        layoutFormatter.formClear(groupBox1);
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
            SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(Id),999)+1 FROM users", con);
            int tranID = int.Parse(cmd.ExecuteScalar().ToString());
            string rs = "R-" + tranID;
            con.Close();
            label.Text = tranID.ToString();
        }
        public bool checktheValidation(Users users,GroupBox groupBox)
        {
            bool valid = false;
            UserValidator userValidator = new UserValidator();
            ValidationResult results = userValidator.Validate(users);
            if (!results.IsValid)
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
                            if (c.AccessibleName == "labelErrorFirstname" && failure.PropertyName == "Firstname")
                            {
                                c.Text = failure.ErrorMessage;
                                c.Visible = true;
                            }
                            if (c.AccessibleName == "labelErrorLastname" && failure.PropertyName == "Lastname")
                            {
                                c.Text = failure.ErrorMessage;
                                c.Visible = true;
                            }
                            if (c.AccessibleName == "labelErrorStatus" && failure.PropertyName == "Status")
                            {
                                c.Text = failure.ErrorMessage;
                                c.Visible = true;
                            }
                            if (c.AccessibleName == "labelErrorEmail" && failure.PropertyName == "Email")
                            {
                                c.Text = failure.ErrorMessage;
                                c.Visible = true;
                            }
                            if (c.AccessibleName == "labelErrorPhoneNo" && failure.PropertyName == "Phoneno")
                            {
                                c.Text = failure.ErrorMessage;
                                c.Visible = true;
                            }
                            if (c.AccessibleName == "labelErrorPassword" && failure.PropertyName == "Password")
                            {
                                c.Text = failure.ErrorMessage;
                                c.Visible = true;
                            }
                            if (c.AccessibleName == "labelErrorUserRole" && failure.PropertyName == "UserRole")
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
                        if (c.AccessibleName == "labelErrorTittle"  )
                        {
                            c.Visible = false;
                        }
                        if (c.AccessibleName == "labelErrorFirstname" )
                        {
                            c.Visible = false;
                        }
                        if (c.AccessibleName == "labelErrorLastname")
                        {
                            c.Visible = false;
                        }
                        if (c.AccessibleName == "labelErrorStatus" )
                        {
                            c.Visible = false;
                        }
                        if (c.AccessibleName == "labelErrorEmail")
                        {
                            c.Visible = false;
                        }
                        if (c.AccessibleName == "labelErrorPhoneNo")
                        {
                            c.Visible = false;
                        }
                        if (c.AccessibleName == "labelErrorPassword" )
                        {
                            c.Visible = false;
                        }
                        if (c.AccessibleName == "labelErrorUserRole" )
                        {
                            c.Visible = false;
                        }
                    }
                }
                valid = true;
            }
            return valid;
        }
    }
}
