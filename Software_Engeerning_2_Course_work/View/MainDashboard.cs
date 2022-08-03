using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Software_Engeerning_2_Course_work.Controller;
using Software_Engeerning_2_Course_work.View.comments;

namespace Software_Engeerning_2_Course_work.View
{
    public partial class MainDashboard : Form
    {
        LayoutFormatter layoutFormatter;
        public static MainDashboard mainDashboardInstance;
        public Panel MainDashboardPanel, panelDashboardTittleGet;
        public Label mainTittle;
        ProjectController projectController = new ProjectController();
        UserController userController = new UserController();
        TaskController taskController = new TaskController();
        SubTaskController subTaskController = new SubTaskController();
        CommentsController commentsController = new CommentsController();

        string userRole = Environment.GetEnvironmentVariable("userRole");
        public MainDashboard()
        {
            InitializeComponent();
            mainDashboardInstance = this;
            MainDashboardPanel = panelMainDashboard;
            mainTittle = labelDashboardTitle;
            panelDashboardTittleGet = panelDashboardTittle;
            panelLogo.Height = this.Height; //Side bar height 
            layoutFormatter = new LayoutFormatter(panelUserSubMenu, panelProjectSubMenu, panelTaskSubMenu, panelSubTaskSubMenu);
            layoutFormatter.customizeDesign();
            timer1.Start();
            labelUserName.Text = Environment.GetEnvironmentVariable("firstname");
            labelUserRole.Text = userRole;
            if (userRole == "Developers")
            {
                //Hide the user
                btnAddUser.Visible = false;
                // add project 
                btnAddProject.Visible = false;
                btnViewPoject.Dock = DockStyle.Top;

                // add task hide
                btnAddTask.Visible = false;
                //Hide sub task
                btnAddSubTask.Visible = false;
            }
            commentsController.viewComments();
            
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            layoutFormatter.showSubMenu(panelUserSubMenu);
        }

        private void btnProject_Click(object sender, EventArgs e)
        {
            layoutFormatter.showSubMenu(panelProjectSubMenu);
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            layoutFormatter.showSubMenu(panelTaskSubMenu);
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            projectController.create();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            userController.create();
        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            userController.view();
        }

        private void btnViewPoject_Click(object sender, EventArgs e)
        {
            projectController.view();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            taskController.create();
        }

        private void btnViewTask_Click(object sender, EventArgs e)
        {
            taskController.view();
        }

        private void btnAddSubTask_Click(object sender, EventArgs e)
        {
            subTaskController.create();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            subTaskController.view();
        }
        private void OnTimerEvent(object sender, EventArgs e)
        {
            
            lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
            lbldate.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }

        private void btnOverView_Click(object sender, EventArgs e)
        {
            layoutFormatter.formAlign(new View.TreeView(), "Over View");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void btnSubTask_Click(object sender, EventArgs e)
        {
            layoutFormatter.showSubMenu(panelSubTaskSubMenu);
            
        }
       
    }
}
