using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Software_Engeerning_2_Course_work.Controller;

namespace Software_Engeerning_2_Course_work.View.project
{
    public partial class ProjectView : Form
    {
        ProjectController projectController = new ProjectController();
        string userRole = Environment.GetEnvironmentVariable("userRole");
        public ProjectView()
        {
            InitializeComponent();
            projectController.loadView(dataGridViewProjects);
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (comboBoxSelectedOption.Text != "")
            {

                if (txtPojectSearch.Text != "")
                {
                    projectController.loadView(dataGridViewProjects, comboBoxSelectedOption.Text, txtPojectSearch.Text);
                }
                else if (comboBoxStatus.Text != "")
                {
                    projectController.loadView(dataGridViewProjects, comboBoxSelectedOption.Text, comboBoxStatus.Text);
                }
            else if (dateTimePickerSelectDate.Value.Date != null)
            {
                //MessageBox.Show(dateTimePickerSelectDate.Value.Date.ToLongDateString(), "Project View", MessageBoxButtons.OK, MessageBoxIcon.Error);
                projectController.loadView(dataGridViewProjects, comboBoxSelectedOption.Text, dateTimePickerSelectDate.Value.Date.ToLongDateString());
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

        private void comboBoxSelectedOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSelectedOption.Text == "Start Date")
            {
                txtPojectSearch.Visible = false;
                comboBoxStatus.Visible = false;
                dateTimePickerSelectDate.Visible = true;
            }
            else if(comboBoxSelectedOption.Text == "Status")
            {
                txtPojectSearch.Visible = false;
                dateTimePickerSelectDate.Visible = false;
                comboBoxStatus.Visible = true;
            }
            else
            {
                comboBoxStatus.Visible = false;
                dateTimePickerSelectDate.Visible = false;
                txtPojectSearch.Visible = true;
            }
        }

        private void dataGridViewProjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (userRole != "Developers") {
                if (e.RowIndex >= 0)
                {
                    int index = dataGridViewProjects.SelectedRows[0].Index;
                    int id = int.Parse(dataGridViewProjects.SelectedRows[0].Cells[0].Value.ToString());
                    DialogResult dialogResult = MessageBox.Show("Do you want Edit this " + id + "?", "User View", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        projectController.edit(id);
                    }
                }
            }
            else 
            {
                MessageBox.Show("No permissoin to Edit","Project",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
        }
    }
}
