using System;
using System.Collections.Generic;


namespace CL_GradesTracker_ProjectOne
{
    class Program
    {

        static List<Course> courses = new List<Course>();
        const int DASHES = 74;

        static void Main(string[] args)
        {

            // comment out to fast track
            AddTestData();

            // create main menu
            RunProgram();

        }

        private static void AddTestData()
        {
            Course c = new Course("ABCD-1234");
            courses.Add(c);

            Evaluation e1 = new Evaluation("proj 1", 50, 46.5, 15);
            Evaluation e2 = new Evaluation("quiz 1", 5, 4, 2);
            Evaluation e3 = new Evaluation("midterm t", 45, 29.0, 25);

            courses[0].Evaluations.Add(e1);
            courses[0].Evaluations.Add(e2);
            courses[0].Evaluations.Add(e3);
        }

        private static void RunProgram()
        {
            MainMenu.Display(courses, DASHES, "Grades Summary");
        }
    }


}