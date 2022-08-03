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

namespace Software_Engeerning_2_Course_work.View
{
    public partial class TreeView : Form
    {
        ConnectionString cs = new ConnectionString();
        SqlConnection con;
        public TreeView()
        {
            InitializeComponent();
        }

        private void TreeView_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM projects ORDER BY tittle";
            con = new SqlConnection(cs.dbCon);
            con.Open();
            SqlCommand cmd = new SqlCommand(query,con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TreeNode treeNode = new TreeNode(dr["Id"].ToString()+" "+'-'+ " " + dr["tittle"].ToString());
                    treeNode.ForeColor = Color.DarkBlue;
                    treeNode.Nodes.Add(dr["tittle"].ToString());
                    SqlDataReader tasks = getTask(dr["Id"].ToString());
                    while (tasks.Read())
                    {
                        TreeNode taskNode = new TreeNode(tasks["Id"].ToString() + " " + '-' + " " + tasks["tittle"].ToString());
                        //taskNode.ForeColor = Color.FromArgb(104, 135, 168); ;
                        SqlDataReader subTask = getSubTask(tasks["Id"].ToString());
                        while (subTask.Read())
                        {
                            //TreeNode subTaskNode = new TreeNode(subTask["Id"].ToString() + " " + '-' + " " + subTask["tittle"].ToString());
                            taskNode.Nodes.Add(subTask["tittle"].ToString());
                        }
                        treeNode.Nodes.Add(taskNode);

                    }
                    treeView1.Nodes.Add(treeNode);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Project Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                
            }
        }
        public SqlDataReader getTask(string project_id)
        {
            string query = "SELECT * FROM tasks WHERE project_id = "+ project_id + " ORDER BY tittle";
            con = new SqlConnection(cs.dbCon);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public SqlDataReader getSubTask(string task_id)
        {
            string query = "SELECT * FROM subTask WHERE task_id = " + task_id + " ORDER BY tittle";
            con = new SqlConnection(cs.dbCon);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
