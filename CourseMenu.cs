using System;
using System.Collections.Generic;
using System.Text;

namespace CL_GradesTracker_ProjectOne
{
    public static class CourseMenu
    {
        public static void Display(ref List<Course> courses, int dashes, string topMessage, int selection)
        {
            string input;

            DisplayTop(topMessage, dashes);

            DisplayEvaluations(courses, selection);

            OptionMenu.DisplayCourseOptions(dashes);

            HelperMethods.PromptUser("Enter a command: ");
            input = HelperMethods.GetUserSelection();

            ParseMethods.ParseCourseInput(input, ref courses, dashes, topMessage, selection);
        }

        static void DisplayTop(string topMessage, int dashes)
        {
            PrintMethods.CreateMainBox(topMessage, dashes);
        }

        static void DisplayEvaluations(List<Course> courses, int selection)
        {
            int evaluation_count;

            if (courses[selection].Evaluations.Count == 0)
            {
                Console.WriteLine($"\n\nThere are currently no evaluations for { courses[selection].Code }.");
            }
            else
            {
                evaluation_count = 1;
                Console.WriteLine("\n\n{0,3} {1,-16} {2,16} {3,7} {4,10} {5,13} {6,12}", "#.", "Evaluation", "Marks Earned", "Out Of", "Percent", "Course Marks", "Weight/100");
                Console.WriteLine("");
                foreach (Evaluation e in courses[selection].Evaluations)
                {
                    if(e != null)
                    {
                        Console.WriteLine("{0,3} {1,-16} {2,16} {3,7} {4,10} {5,13} {6,12}",
                       evaluation_count + ".",
                       e.Description,
                       String.Format("{0:0.0}", e.MarksEarned),
                       String.Format("{0:0.0}", e.OutOf),
                       String.Format("{0:0.0}", e.Percent),
                       String.Format("{0:0.0}", e.CourseMarks),
                       String.Format("{0:0.0}", e.Weight));
                        evaluation_count++;
                    }
                   
                }
            }
        }
    }
}
