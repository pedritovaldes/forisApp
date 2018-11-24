using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForisApp
{
    class Presence
    {
        public string StudentName {get; set;}
        public double TotalMinutes { get; set; }
        public int TotalDays { get; set; }

        public Presence(string student, double totalMinutes, int totalDays)
        {
            StudentName = student;
            TotalMinutes = totalMinutes;
            TotalDays = totalDays;
        }
    }
}
