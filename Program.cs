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
            add_test_data();

            // create main menu
            HelperMethods.main_menu(courses, DASHES, "Grades Summary");

        

        }

        private static void add_test_data()
        {
            Course c = new Course("ABCD-1234");
            courses.Add(c);

            Evaluation e1 = new Evaluation("proj 1", 50, 15, 46.5);
            Evaluation e2 = new Evaluation("quiz 1", 5, 2, 4);
            Evaluation e3 = new Evaluation("midterm t", 45, 25, 29.0);

            courses[0].evaluations.Add(e1);
            courses[0].evaluations.Add(e2);
            courses[0].evaluations.Add(e3);
        }
    }


}