﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engeerning_2_Course_work.Models
{
    public class Tasks
    {
        private int id;
        private string tittle = "";
        private string description = "";
        private DateTime startDate;
        private DateTime endDate;
        private string duration = "";
        private int percentage;
        private string status = "";
        private int projectId;

        public int Id { get => id; set => id = value; }
        public int ProjectId { get => projectId; set => projectId = value; }
        public string Tittle { get => tittle; set => tittle = value; }
        public string Description { get => description; set => description = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public string Duration { get => duration; set => duration = value; }
        public int Percentage { get => percentage; set => percentage = value; }
        public string Status { get => status; set => status = value; }
    }
}
