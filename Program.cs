using System;
using System.Collections.Generic;


namespace CL_GradesTracker_ProjectOne
{
    class Program
    {
        static void Main(string[] args)
        {
            const int DASHES = 74;
            bool is_running = true;
            List<Course> courses = new List<Course>();
         
            
         
            
            // main display
            Console.WriteLine("\n" +
                "\t\t\t~ GRADES TRACKING SYSTEM ~\n");
            HelperMethods.print_box("Grades Summary", DASHES);

            // create main menu
            HelperMethods.main_menu(courses, DASHES);

            Console.Clear();
            // create add new course
            // create delete course
            // main menu with course
            // view course details (evaluations)
            // update course details

        }


    }


}