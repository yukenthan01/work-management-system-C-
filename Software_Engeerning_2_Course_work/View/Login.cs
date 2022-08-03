using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Engeerning_2_Course_work.View
{
    public partial class Login : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlConnection con;
        public Login()
        {
            InitializeComponent();
            con = new SqlConnection(cs.dbCon);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text !="")
            {
                string query = "SELECT Id,firstname,email,userRole FROM users WHERE email = '" + txtUsername.Text + "' AND password = '"+ txtPassword.Text +"'";
                try
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Environment.SetEnvironmentVariable("id", sdr[0].ToString());
                            Environment.SetEnvironmentVariable("firstname", sdr[1].ToString());
                            Environment.SetEnvironmentVariable("email", sdr[2].ToString());
                            Environment.SetEnvironmentVariable("userRole", sdr[3].ToString());
                            
                        }
                        MainDashboard mainDashboard = new MainDashboard();
                        mainDashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Please Check the Username or Password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Fill the details","Login",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
