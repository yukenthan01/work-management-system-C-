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

namespace Software_Engeerning_2_Course_work.View.task
{
    public partial class TaskView : Form
    {
        TaskController taskController = new TaskController();
        public TaskView()
        {
            InitializeComponent();
            taskController.loadView(dataGridViewTasks);
        }

        private void comboBoxSelectedOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSelectedOption.Text == "Start Date")
            {
                txtSearch.Visible = false;
                comboBoxStatus.Visible = false;
                dateTimePickerSelectDate.Visible = true;
            }
            else if (comboBoxSelectedOption.Text == "Status")
            {
                txtSearch.Visible = false;
                dateTimePickerSelectDate.Visible = false;
                comboBoxStatus.Visible = true;
            }
            else
            {
                comboBoxStatus.Visible = false;
                dateTimePickerSelectDate.Visible = false;
                txtSearch.Visible = true;
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (comboBoxSelectedOption.Text != "")
            {

                if (txtSearch.Text != "")
                {
                    taskController.loadView(dataGridViewTasks, comboBoxSelectedOption.Text, txtSearch.Text);
                }
                else if (comboBoxStatus.Text != "")
                {
                    taskController.loadView(dataGridViewTasks, comboBoxSelectedOption.Text, comboBoxStatus.Text);
                }
                else if (dateTimePickerSelectDate.Value.Date != null)
                {
                    
                    taskController.loadView(dataGridViewTasks, comboBoxSelectedOption.Text, dateTimePickerSelectDate.Value.Date.ToLongDateString());
                }
                else
                {
                    MessageBox.Show("Enter the value or Select the correct date", "Project View", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Select the option", "Project View", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewProjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (Environment.GetEnvironmentVariable("userRole") != "Developers")
            {
                if (e.RowIndex >= 0)
                {
                    int index = dataGridViewTasks.SelectedRows[0].Index;
                    int id = int.Parse(dataGridViewTasks.SelectedRows[0].Cells[0].Value.ToString());
                    DialogResult dialogResult = MessageBox.Show("Do you want Edit this " + id + "?", "Task View", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        taskController.edit(id);
                    }
                }
            }
            else
            {
                MessageBox.Show("No permissoin to Edit", "Task", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
