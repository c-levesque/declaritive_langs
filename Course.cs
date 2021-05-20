using System;
using System.Collections.Generic;
using System.Text;

namespace CL_GradesTracker_ProjectOne
{
    class Course
    {
        public string code { get; set; }
        public int marks_earned { get; set; }
        public int out_of { get; set; }
        public int percent { get; set; }
        public List<Evaluation> evaluations { get; set; }


     

    }
}
