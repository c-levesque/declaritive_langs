using System;
using System.Collections.Generic;
using System.Text;

namespace CL_GradesTracker_ProjectOne
{
    public class Evaluation
    {
        public string Description { get; set; }
        public int OutOf { get; set; }
        public double MarksEarned { get; set; }
        public double Percent { get; set; }
        public double CourseMarks { get; set; }
        public double Weight { get; set; }

        public Evaluation()
        {

        }
        public Evaluation(string description, int outOf, double marksEarned, double weight)
        {
            this.Description = description;
            this.OutOf = outOf;
            this.MarksEarned = marksEarned;
            this.Weight = weight;

            this.Percent = 100 * this.MarksEarned / this.OutOf;
            this.CourseMarks = this.Percent * this.Weight / 100;
        }
    }

    
}
