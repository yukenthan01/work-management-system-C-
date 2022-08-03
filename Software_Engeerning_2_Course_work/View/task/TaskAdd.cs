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

namespace Software_Engeerning_2_Course_work.View.task
{
    public partial class TaskAdd : Form
    {
        TaskController taskController = new TaskController();
        LayoutFormatter layoutFormatter = new LayoutFormatter();
        int projectId;
        int taskId;
        public TaskAdd()
        {
            InitializeComponent();
            taskController.autoID(labelTaskId);
            taskController.getProjectId(comboBoxProjectId);
            comboBoxStatus.SelectedIndex = comboBoxStatus.FindStringExact("Not Started");
        }
        public TaskAdd(Tasks tasks, List<string> usersId)
        {
            InitializeComponent();
            taskController.getProjectId(comboBoxProjectId);
            if (tasks != null)
            {
                
                labelTaskId.Text = tasks.Id.ToString();
                txtTaskTittle.Text = tasks.Tittle;
                txtDescription.Text = tasks.Description;
                dateTimePickerStartDate.Value = tasks.StartDate;
                dateTimePickerEndDate.Value = tasks.EndDate;
                txtDuration.Text = tasks.Duration;
                txtPercentage.Text = tasks.Percentage.ToString();
                comboBoxStatus.SelectedIndex = comboBoxStatus.FindStringExact(tasks.Status);
                comboBoxProjectId.Text = tasks.ProjectId.ToString();
                taskController.getProjectUsers(checkedListBoxProjectUsers,tasks.ProjectId.ToString());
                

                for (int count = 0; count < checkedListBoxProjectUsers.Items.Count; count++)
                {
                    if (usersId.Contains(checkedListBoxProjectUsers.Items[count].ToString()))
                    {
                        checkedListBoxProjectUsers.SetItemChecked(count, true);
                    }
                }
                listBoxUsersSelected.Items.Clear();
                foreach (Object items in checkedListBoxProjectUsers.CheckedItems)
                {
                    listBoxUsersSelected.Items.Add(items.ToString());
                }
                btnsubmit.Text = "Update";
                this.taskId = tasks.Id;
                this.projectId = tasks.ProjectId;   
            }

        }

        private void comboBoxProjectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string proId;
            if (comboBoxProjectId != null)
            {
                string[] id = comboBoxProjectId.Text.Split('-');
                proId = id[0];
                projectId = int.Parse(proId);
                checkedListBoxProjectUsers.Items.Clear();
                listBoxUsersSelected.Items.Clear(); 
                taskController.getProjectUsers(checkedListBoxProjectUsers, proId);
            }
            
        }

        private void checkedListBoxProjectUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

            layoutFormatter.addListFromCheckList(checkedListBoxProjectUsers, listBoxUsersSelected);
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            Tasks task = new Tasks();
            task.Description = txtDescription.Text;
            task.Tittle = txtTaskTittle.Text;
            task.Duration = txtDuration.Text;
            task.Status = comboBoxStatus.Text;
            task.StartDate = dateTimePickerStartDate.Value.Date;
            task.EndDate = dateTimePickerStartDate.Value.Date;
            task.Percentage = int.Parse(txtPercentage.Text);
            task.ProjectId = projectId;
            string[] usersId = new string[listBoxUsersSelected.Items.Count];
            for (int i = 0; i < listBoxUsersSelected.Items.Count; i++)
            {
                string ts = listBoxUsersSelected.Items[i].ToString();
                string[] id = ts.Split('-');
                usersId[i] = id[0];
            }
            if (btnsubmit.Text == "Update")
            {
                task.Id = taskId;
                taskController.update(task, usersId, groupBox1);
                listBoxUsersSelected.Items.Clear();
            }
            else
            {
                taskController.store(task, usersId, groupBox1);
                listBoxUsersSelected.Items.Clear();
            }

        }

        private void txtDuration_TextChanged(object sender, EventArgs e)
        {
            if (txtDuration.Text != "")
            {
                DateTime startDate = dateTimePickerStartDate.Value;
                dateTimePickerEndDate.Value = startDate.AddDays(int.Parse(txtDuration.Text));
            }
        }
    }
}