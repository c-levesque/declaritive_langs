using System;
using System.Collections.Generic;
using System.Text;

namespace CL_GradesTracker_ProjectOne
{
    public class Course
    {
        public string Code { get; set; }
        public int MarksEarned { get; set; }
        public int OutOf { get; set; }
        public int Percent { get; set; }
        public List<Evaluation> Evaluations = new List<Evaluation>();

        public Course(string code)
        {
            this.Code = code;
        }
    
    }
}
