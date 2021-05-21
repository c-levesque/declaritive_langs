using System;
using System.Collections.Generic;
using System.Text;

namespace CL_GradesTracker_ProjectOne
{
    class Evaluation
    {
        public string description { get; set; }
        public int out_of { get; set; }
        public double earned_marks { get; set; }
        public double percent { get; set; }
        public double course_marks { get; set; }
        public double weight_out_of_100 { get; set; }

        public Evaluation()
        {

        }
        public Evaluation(string desc, int out_of, double earned_marks, double weight_out_of_100)
        {
            this.description = desc;
            this.out_of = out_of;
            this.earned_marks = earned_marks;
            this.weight_out_of_100 = weight_out_of_100;
            this.percent = 100 * this.earned_marks / this.out_of;
            this.course_marks = this.percent * this.weight_out_of_100 / 100;

        }
    }

    
}
