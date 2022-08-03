using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Software_Engeerning_2_Course_work.View.project;

namespace Software_Engeerning_2_Course_work.View.user
{
    public partial class MainDashboard_OLD : Form
    {
        LayoutFormatter layoutFormatter;
        public MainDashboard_OLD()
        {
            InitializeComponent();
            panelLogo.Height = this.Height; //Side bar height 
            layoutFormatter = new LayoutFormatter(panelUserSubMenu, panelProjectSubMenu,panelTaskSubMenu,panelSubTaskSubMenu);
            layoutFormatter.customizeDesign();
        }
        private void MainDashboard_Load(object sender, EventArgs e)
        {

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
        private void btnSubTask_Click(object sender, EventArgs e)
        {
            layoutFormatter.showSubMenu(panelSubTaskSubMenu);
        }
        private void btnTeams_Click(object sender, EventArgs e)
        {
            layoutFormatter.showSubMenu(panelTeamsSubMenu);
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserAdd userAdd = new UserAdd();
            userAdd.FormBorderStyle = FormBorderStyle.None;
            userAdd.TopLevel = false;
            userAdd.AutoScroll = false;
            panelMainDashboard.Controls.Clear();
            userAdd.Location = new Point(
            panelMainDashboard.ClientSize.Width / 2 - userAdd.Size.Width / 2,
            panelMainDashboard.ClientSize.Height / 2 - userAdd.Size.Height / 2);
            panelMainDashboard.Anchor = AnchorStyles.None;
            userAdd.Height = panelMainDashboard.Height - 40 ;
            panelMainDashboard.Controls.Add(userAdd);
            
            userAdd.Show();

            labelDashboardTitle.Text = "Register New User";
            labelDashboardTitle.Location = new Point(
            panelDashboardTittle.ClientSize.Width / 2 - labelDashboardTitle.Size.Width / 2,
            panelDashboardTittle.ClientSize.Height / 2 - labelDashboardTitle.Size.Height / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserView userView = new UserView();
            userView.FormBorderStyle = FormBorderStyle.None;
            userView.TopLevel = false;
            userView.AutoScroll = false;
            panelMainDashboard.Controls.Clear();
            userView.Location = new Point(
            panelMainDashboard.ClientSize.Width / 2 - userView.Size.Width / 2,
            panelMainDashboard.ClientSize.Height / 2 - userView.Size.Height / 2);
            panelMainDashboard.Anchor = AnchorStyles.None;
            userView.Height = panelMainDashboard.Height - 60 ;
            panelMainDashboard.Controls.Add(userView);
            labelDashboardTitle.Text = "View Users";
            userView.Show();

            labelDashboardTitle.Location = new Point(
            panelDashboardTittle.ClientSize.Width / 2 - labelDashboardTitle.Size.Width / 2,
            panelDashboardTittle.ClientSize.Height / 2 - labelDashboardTitle.Size.Height / 2);
        }

        private void panelMainDashboard_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panelMainDashboard.ClientRectangle,
               Color.White, 1, ButtonBorderStyle.Solid, // left
               Color.White, 1, ButtonBorderStyle.Solid, // top
               Color.White, 1, ButtonBorderStyle.Solid, // right
               Color.White, 1, ButtonBorderStyle.Solid);// bottom
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            
        }
    }
}
