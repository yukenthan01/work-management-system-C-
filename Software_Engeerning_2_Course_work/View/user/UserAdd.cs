using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Software_Engeerning_2_Course_work.Models;
using Software_Engeerning_2_Course_work.Controller;

namespace Software_Engeerning_2_Course_work.View.user
{
    public partial class UserAdd : Form
    {
        UserController userController = new UserController() ;
        LayoutFormatter layoutFormatter = new LayoutFormatter();
        int userId;
        public UserAdd(Users users)
        {
            InitializeComponent();
            if (users != null)
            {
                lblUserId.Text = users.Id.ToString();
                droTittle.Text = users.Tittle.ToString();
                txtFirstname.Text = users.Firstname.ToString();
                txtLastname.Text = users.Lastname.ToString();
                txtemail.Text = users.Email.ToString();
                txtPhoneNo.Text = users.Phoneno.ToString();
                droStatus.Text = users.Status.ToString();
                dropUserRole.Text = users.UserRole.ToString();
                txtPassword.Text = users.Password.ToString();
                btnsubmit.Text = "Update";
                this.userId = users.Id;
            }
            
        }
        public UserAdd()
        {
            InitializeComponent();
            userController.autoID(lblUserId);
            txtFirstname.Text = Environment.GetEnvironmentVariable("firstname");

        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            Users users = new Users();

            users.Tittle = droTittle.Text;
            users.Firstname = txtFirstname.Text;
            users.Lastname = txtLastname.Text;
            users.Email = txtemail.Text;
            users.Phoneno = txtPhoneNo.Text;
            users.Status = droStatus.Text;
            users.Password = txtPassword.Text;
            users.UserRole = dropUserRole.Text;
            

            if (btnsubmit.Text == "Update")
            {
                users.Id = userId;
                userController.update(users, groupBox1);
            }
            else
            {
                userController.store(users, groupBox1);
                userController.autoID(lblUserId);
            }
            

        }
        
    }
}
