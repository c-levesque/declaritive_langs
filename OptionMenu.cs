using System;
using System.Collections.Generic;
using System.Text;

namespace CL_GradesTracker_ProjectOne
{
    public static class OptionMenu
    {
        public static void DisplayMainOptions(int dashes)
        {
            int i;

            Console.WriteLine("");

            for (i = 0; i < dashes; ++i)
            {
                Console.Write("-");
            }

            Console.WriteLine("\nPress # from the above list to view/edit/delete a specific course.");
            Console.WriteLine("Press A to add a new course.");
            Console.WriteLine("Press X to quit");

            for (i = 0; i < dashes; ++i)
            {
                Console.Write("-");
            }
        }

        public static void DisplayCourseOptions(int dashes)
        {
            int i;

            Console.WriteLine("");

            for (i = 0; i < dashes; ++i)
            {
                Console.Write("-");
            }
            Console.WriteLine("\nPress D to delete this course.");
            Console.WriteLine("Press A to add an evaluation.");
            Console.WriteLine("Press # from the above list to edit/delete a specific evaluation");
            Console.WriteLine("Press X to return to main menu");

            for (i = 0; i < dashes; ++i)
            {
                Console.Write("-");
            }
        }

        public static void DisplayEvaluationOptions(int dashes)
        {
            int i;

            Console.WriteLine("");

            for (i = 0; i < dashes; ++i)
            {
                Console.Write("-");
            }
            Console.WriteLine("\nPress D to delete this course.");
            Console.WriteLine("Press E to edit this evaluation.");
            Console.WriteLine("Press X to return to the previous menu");

            for (i = 0; i < dashes; ++i)
            {
                Console.Write("-");
            }
        }
    }
}
