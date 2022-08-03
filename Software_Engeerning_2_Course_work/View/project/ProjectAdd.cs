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
using Software_Engeerning_2_Course_work.Models;

namespace Software_Engeerning_2_Course_work.View.project
{
    public partial class ProjectAdd : Form
    {
        ProjectController projectController = new ProjectController();
        int projectId;
        public ProjectAdd()
        {
            InitializeComponent();
            projectController.autoID(labelProjectId);
            projectController.getUsers(checkedListBoxUsers);
            comboBoxStatus.SelectedIndex = comboBoxStatus.FindStringExact("Not Started");
        }
        public ProjectAdd(Project project, List<string> usersId)
        {
            InitializeComponent();
            if(project != null)
            {
                labelProjectId.Text = project.Id.ToString();
                txtProjectTittle.Text = project.Tittle;
                txtDescription.Text = project.Description;
                dateTimePickerStartDate.Value = project.StartDate;
                dateTimePickerEndDate.Value = project.EndDate;
                txtDuration.Text = project.Duration;
                txtPercentage.Text = project.Percentage.ToString();
                comboBoxStatus.Text = project.Status;
                comboBoxStatus.SelectedIndex = comboBoxStatus.FindStringExact(project.Status);
                projectController.getUsers(checkedListBoxUsers);

                for (int count = 0; count < checkedListBoxUsers.Items.Count; count++)
                {
                    if (usersId.Contains(checkedListBoxUsers.Items[count].ToString()))
                    {
                        checkedListBoxUsers.SetItemChecked(count, true);
                    }
                }
                listBoxUsersSelected.Items.Clear();
                foreach (Object items in checkedListBoxUsers.CheckedItems)
                {
                    listBoxUsersSelected.Items.Add(items.ToString());
                }
                btnsubmit.Text = "Update";
                this.projectId = project.Id;
            }
            
        }
        private void checkedListBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxUsersSelected.Items.Clear();
            foreach (Object items in checkedListBoxUsers.CheckedItems)
            {
                listBoxUsersSelected.Items.Add(items.ToString());
            }
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            string[] usersId = new string[listBoxUsersSelected.Items.Count];
           
            Project project = new Project();
            project.Description = txtDescription.Text;
            project.Tittle = txtProjectTittle.Text;
            project.Duration = txtDuration.Text;
            project.Status = comboBoxStatus.Text;
            project.StartDate = dateTimePickerStartDate.Value.Date;
            project.EndDate = dateTimePickerStartDate.Value.Date;
            project.Percentage = int.Parse(txtPercentage.Text);
            for (int i = 0; i < listBoxUsersSelected.Items.Count; i++)
            {
                string ts = listBoxUsersSelected.Items[i].ToString();
                string[] id = ts.Split('-');
                usersId[i] = id[0];
                    
            }
            if(btnsubmit.Text == "Update")
            {
                project.Id = projectId;
                projectController.update(project, usersId, groupBox1);
                listBoxUsersSelected.Items.Clear();
            }
            else
            {
                projectController.store(project, usersId, groupBox1);
                listBoxUsersSelected.Items.Clear();
            }
            
        }
        private void txtDuration_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtDuration.Text !="")
            {
                DateTime startDate = dateTimePickerStartDate.Value;
                dateTimePickerEndDate.Value = startDate.AddDays(int.Parse(txtDuration.Text));
            }
            
        }
    }
}
