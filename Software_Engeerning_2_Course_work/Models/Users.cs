using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engeerning_2_Course_work.Models
{
    public class Users
    {
        private int id;
        private string tittle = "";
        private string firstname = "";
        private string lastname = "";
        private string email = "";
        private string phoneno = "";
        private string status = "";
        private string password = "";
        private string userRole = "";

        public Users()
        {

        }
        public int Id { get => id; set => id = value; }
        public string Tittle { get => tittle; set => tittle = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Email { get => email; set => email = value; }
        public string Phoneno { get => phoneno; set => phoneno = value; }
        public string Status { get => status; set => status = value; }
        public string Password { get => password; set => password = value; }
        public string UserRole { get => userRole; set => userRole = value; }
        
    }
}
