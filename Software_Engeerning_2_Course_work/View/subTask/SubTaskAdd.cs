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

namespace Software_Engeerning_2_Course_work.View.subTask
{
    public partial class SubTaskAdd : Form
    {
        SubTaskController subTaskController = new SubTaskController();
        int subTaskId;
        public SubTaskAdd()
        {
            InitializeComponent();
            subTaskController.getProjectId(comboBoxProjectId);
            subTaskController.autoID(labelSubTaskId);
            comboBoxStatus.SelectedIndex = comboBoxStatus.FindStringExact("Not Started");
        }
        public SubTaskAdd(SubTask subTask,List<string> project, List<string> user, List<string> task)
        {
            InitializeComponent();
            subTaskController.getProjectId(comboBoxProjectId);
            if (subTask != null)
            {
                labelSubTaskId.Text = subTask.Id.ToString();
                txtSubTaskTittle.Text = subTask.Tittle;
                txtDescription.Text = subTask.Description;
                dateTimePickerStartDate.Value = subTask.StartDate;
                dateTimePickerEndDate.Value = subTask.EndDate;
                txtDuration.Text = subTask.Duration;
                txtPercentage.Text = subTask.Percentage.ToString();
                
                comboBoxStatus.SelectedIndex = comboBoxStatus.FindStringExact(subTask.Status);

                comboBoxProjectId.SelectedIndex = comboBoxProjectId.FindStringExact(project[0]);

                comboBoxTask.SelectedIndex = comboBoxTask.FindStringExact(task[0]);
                comboBoxSubTaskUser.SelectedIndex = comboBoxSubTaskUser.FindStringExact(user[0]);
                btnsubmit.Text = "Update";
                this.subTaskId = subTask.Id;
            }
        }
        private void comboBoxProjectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string proId;
            if (comboBoxProjectId != null)
            {
                string[] id = comboBoxProjectId.Text.Split('-');
                proId = id[0];
                subTaskController.getProjectTasks(comboBoxTask, proId);
            }
        }

        private void comboBoxTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            string taId;
            if (comboBoxTask != null)
            {
                string[] id = comboBoxTask.Text.Split('-');
                taId = id[0];
                subTaskController.getTaskUsers(comboBoxSubTaskUser, taId);
            }
            
        }
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            SubTask subTask = new SubTask();
            if (comboBoxSubTaskUser.SelectedIndex >= 0 && comboBoxTask.SelectedIndex >= 0)
            {

                string[] task_id = comboBoxTask.Text.Split('-');
                string [] userId = comboBoxSubTaskUser.Text.Split('-');
                subTask.Description = txtDescription.Text;
                subTask.Tittle = txtSubTaskTittle.Text;
                subTask.Duration = txtDuration.Text;
                subTask.Status = comboBoxStatus.Text;
                subTask.StartDate = dateTimePickerStartDate.Value.Date;
                subTask.EndDate = dateTimePickerStartDate.Value.Date;
                subTask.Percentage = int.Parse(txtPercentage.Text);
                subTask.TaskId = int.Parse(task_id[0]);
                subTask.UserId = int.Parse(userId[0]);
                if (btnsubmit.Text == "Update")
                {
                    subTask.Id = subTaskId;
                    subTaskController.update(subTask,groupBox1);
                }
                else
                {
                    subTaskController.store(subTask, groupBox1);
                }
            }
            else
            {
                if (comboBoxSubTaskUser.SelectedIndex <= -1 )
                {
                    labelErrorUsers.Text = "Select the User ";
                    labelErrorUsers.Visible = true;
                }
                else
                {
                    labelErrorUsers.Visible = false;
                }
                if(comboBoxTask.SelectedIndex <= -1)
                {
                    labelErrorTaskId.Text = "Select the Task";
                    labelErrorTaskId.Visible = true;
                }
                else
                {
                    labelErrorTaskId.Visible = false;
                }
                
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
