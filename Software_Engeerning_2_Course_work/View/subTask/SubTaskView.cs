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

namespace Software_Engeerning_2_Course_work.View.subTask
{
    public partial class SubTaskView : Form
    {
        SubTaskController subTaskController = new SubTaskController();
        public SubTaskView()
        {
            InitializeComponent();
            subTaskController.loadView(dataGridViewSubTasks);
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (comboBoxSelectedOption.Text != "")
            {

                if (txtSearch.Text != "")
                {
                    subTaskController.loadView(dataGridViewSubTasks, comboBoxSelectedOption.Text, txtSearch.Text);
                }
                else if (comboBoxStatus.Text != "")
                {
                    subTaskController.loadView(dataGridViewSubTasks, comboBoxSelectedOption.Text, comboBoxStatus.Text);
                }
                else if (dateTimePickerSelectDate.Value.Date != null)
                {

                    subTaskController.loadView(dataGridViewSubTasks, comboBoxSelectedOption.Text, dateTimePickerSelectDate.Value.Date.ToLongDateString());
                }
                else
                {
                    MessageBox.Show("Enter the value or Select the correct date", "Sub Task View", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Select the option", "Sub Task View", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewSubTasks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int index = dataGridViewSubTasks.SelectedRows[0].Index;
                int id = int.Parse(dataGridViewSubTasks.SelectedRows[0].Cells[0].Value.ToString());
                DialogResult dialogResult = MessageBox.Show("Do you want Edit this " + id + "?", "Sub Task View", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    subTaskController.edit(id);
                }
            }
        }
    }
}
