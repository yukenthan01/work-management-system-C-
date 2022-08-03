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

namespace Software_Engeerning_2_Course_work.View.user
{
    public partial class UserView : Form
    {
        UserController userController = new UserController();
        public UserView()
        {
            InitializeComponent();
            userController.loadView(dataGridViewUsers);
        }

        private void UserView_Load(object sender, EventArgs e)
        {
            //userController.view(dataGridViewUsers);
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if(dropSearchSelected.Text !="" && txtUserSearch.Text != "")
            {
                userController.loadView(dataGridViewUsers, dropSearchSelected.Text, txtUserSearch.Text);
            }
            else
            {
                MessageBox.Show("Select the option and enter the value", "User View", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int index = dataGridViewUsers.SelectedRows[0].Index;
                int id = int.Parse(dataGridViewUsers.SelectedRows[0].Cells[0].Value.ToString());
                DialogResult dialogResult = MessageBox.Show("Do you want Edit this "+ id +"?", "User View", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    userController.edit(id);
                }
            }
        }
    }
}
