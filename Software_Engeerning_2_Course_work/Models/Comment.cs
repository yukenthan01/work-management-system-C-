using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engeerning_2_Course_work.Models
{
    class Comment
    {
        private int id;
        private int project_id;
        private int user_id;
        private string comments;
        private DateTime dateTime;

        
        public int Id { get => id; set => id = value; }

        public int Project_id { get => project_id; set => project_id = value; }

        public int User_id { get => user_id; set => user_id = value; }

        public string Comments { get => comments; set => comments = value; }

        public DateTime DateTime { get => dateTime; set => dateTime = value; }

    }
}
