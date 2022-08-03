using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Software_Engeerning_2_Course_work.Controller;
using Software_Engeerning_2_Course_work.Models;

namespace Software_Engeerning_2_Course_work.View.comments
{
    public partial class Comments : Form
    {
        CommentsController commentsController = new CommentsController();
        SqlDataReader dataReader;
        private string projectId;
        public Comments()
        {
            InitializeComponent();
            load();
        }
        public void load()
        {
            dataReader = commentsController.getProjects();
            if (dataReader != null)
            {
                if (dataReader.HasRows)
            {
                GroupBox group;
                Label labelProjectTittle = new Label();
                int s = 38;
                while (dataReader.Read())
                {
                    group = new GroupBox();
                    group.Location = new Point(6, s);
                    group.Size = new Size(400, 70);
                    group.Dock = DockStyle.Top;
                    group.Text = dataReader["Id"].ToString();
                    group.Font = new Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular);
                    group.FlatStyle = FlatStyle.Standard;
                    group.Margin = new Padding(4, 4, 4, 4);

                    // label for the project tittle
                    labelProjectTittle = new Label();
                    labelProjectTittle.AutoSize = true;
                    labelProjectTittle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular);
                    labelProjectTittle.Location = new System.Drawing.Point(109, 33);
                    labelProjectTittle.Name = "label1";
                    labelProjectTittle.Size = new System.Drawing.Size(138, 30);
                    labelProjectTittle.TabIndex = 0;
                    labelProjectTittle.Text = dataReader["tittle"].ToString();
                    group.Controls.Add(labelProjectTittle);
                    group.Click += new System.EventHandler(groupBoxClick);
                    //labelProjectTittle.Click += new System.EventHandler(groupBoxClick);
                    groupBoxProjects.Controls.Add(group);
                    s += 81;
                }
            }
            }
        }
        private void groupBoxClick(object sender, EventArgs e)
        {
            string searchKey = "";
            foreach (Control c in groupBoxProjects.Controls)
            {
                if(c is GroupBox)
                {
                    c.BackColor = Color.Transparent;
                }
            }
            if (sender is GroupBox)
            {
                GroupBox g = (GroupBox)sender;
                g.BackColor = Color.FromArgb(191, 205, 219);
                searchKey = g.Text;
                projectId = g.Text;
                groupBox1.Visible = true;
            }
            
           
            SqlDataReader commentsReader;
            commentsReader = commentsController.getComments(searchKey);
            if (commentsReader.HasRows)
            {
                GroupBox commentGroupBox = new GroupBox();
                
                while (commentsReader.Read())
                {
                    commentGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(184)))), ((int)(((byte)(196)))));
                    
                    commentGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular);
                    commentGroupBox.Location = new System.Drawing.Point(3, 3);
                    commentGroupBox.Name = "groupBoxUserName";
                    commentGroupBox.Size = new System.Drawing.Size(475, 75);
                    commentGroupBox.TabIndex = 2;
                    commentGroupBox.TabStop = false;
                    commentGroupBox.Text = commentsReader["project_id"].ToString();

                    Label label = new Label();
                    label.AutoSize = true;
                    label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular);
                    label.Location = new System.Drawing.Point(109, 33);
                    label.Name = "label1";
                    label.Size = new System.Drawing.Size(138, 30);
                    label.TabIndex = 0;
                    label.Text = commentsReader["comment"].ToString();
                    commentGroupBox.Controls.Add(label);
                    panelChatPanel.Controls.Add(commentGroupBox);
                }
            }
            else
            {
                panelChatPanel.Controls.Clear();
            }
        }
       
        private void btnAddComment_Click(object sender, EventArgs e)
        {
            //richTextBoxComment
            if (richTextBoxComment.Text != "")
            {
                DateTime now = DateTime.Now;
                Comment comments = new Comment();
                comments.Comments = richTextBoxComment.Text;
                comments.Project_id = int.Parse(projectId);
                comments.User_id = int.Parse(Environment.GetEnvironmentVariable("id"));
                comments.DateTime = now;

                commentsController.store(comments);
                //groupBoxProjects.Controls.Clear();
                load();
            }
            else
            {
                MessageBox.Show("Enter the Comment", "Comment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
