using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Software_Engeerning_2_Course_work.View.comments;
using Software_Engeerning_2_Course_work.Models;

namespace Software_Engeerning_2_Course_work.Controller
{
    class CommentsController
    {
        LayoutFormatter layoutFormatter = new LayoutFormatter();
        ConnectionString cs = new ConnectionString();
        SqlConnection con;

        public CommentsController()
        {

        }
        public void viewComments()
        {
            layoutFormatter.formAlign(new Comments(), "Project Comments");
        }
        public void store(Models.Comment comments)
        {
            using (con = new SqlConnection(cs.dbCon))
            {
                string query = "INSERT INTO comments (project_id,user_id,comment,dateTime)VALUES (@project_id,@user_id,@comment,@dateTime)";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@project_id", comments.Project_id);
                command.Parameters.AddWithValue("@user_id", comments.User_id);
                command.Parameters.AddWithValue("@comment", comments.Comments);
                command.Parameters.AddWithValue("@dateTime", comments.DateTime);
                
                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                   
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public SqlDataReader getProjects()
        {
            string currentUserId = Environment.GetEnvironmentVariable("id");
            string query = "SELECT projects_id FROM projectsUsers WHERE users_id = " + currentUserId + "";
            con = new SqlConnection(cs.dbCon);
            con.Open();
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(query, con);
            da.Fill(dt);

            if (dt.Rows.Count <= 0)
            {
                query = "SELECT projects_id FROM projectsUsers ";
            }
            SqlDataAdapter da2;
            DataTable dt2 = new DataTable();
            da2 = new SqlDataAdapter(query, con);
            da2.Fill(dt2);

            string[] arrray = dt2.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray();
            int[] ids = Array.ConvertAll(arrray, int.Parse);

            string projectQuery = "SELECT * FROM projects WHERE Id IN(" + String.Join(", ", ids) + ")";

            SqlCommand cmd = new SqlCommand(projectQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
            return null;
        }
        public SqlDataReader getComments(string projectId)
        {
            string query = "SELECT comments.Id,comments.project_id,comments.comment FROM comments WHERE project_id = " + projectId + "";
            con = new SqlConnection(cs.dbCon);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;

        }
    }
}
