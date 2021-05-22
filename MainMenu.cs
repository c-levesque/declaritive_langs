using System;
using System.Collections.Generic;
using System.Text;

namespace CL_GradesTracker_ProjectOne
{
    public static class MainMenu
    {
        public static void Display(ref List<Course> courses, int dashes, string topMessage)
        {
            string input;

            DisplayTop(topMessage, dashes);

            DisplayCourses(courses);

            OptionMenu.DisplayMainOptions(dashes);

            HelperMethods.PromptUser("Enter a command: ");
            input = HelperMethods.GetUserSelection();

            ParseMethods.ParseMainInput(input, ref courses, dashes, topMessage);
        }

        public static void ParseUserInput(char c, int selection, string input, ref List<Course> courses, string topMessage, int dashes)
        {
            GetCourseSelection(ref c, ref selection, input);

            if (Char.IsDigit(c) && selection >= 0)
            {
                if(selection < 0 || selection >= courses.Count)
                {
                    Error.PrintMessage("Incorrect input, try again..");
                    HelperMethods.PromptUser("Enter a command: ");
                    input = HelperMethods.GetUserSelection();
                    ParseUserInput(c, selection, input, ref courses, topMessage, dashes);
                }
                Console.Clear();
                topMessage = courses[selection].Code;
                CourseMenu.Display(ref courses, dashes, topMessage, selection);
            }
            else
            {
                ParseMethods.ParseMainInput(input, ref courses, dashes, topMessage);
            }
        }

        static void GetCourseSelection(ref char c, ref int selection, string input)
        {
            c = input[0];

            // modifies course selection (if one was made)
            if (Char.IsDigit(c))
            {
                selection = int.Parse(input) - 1;
            }
        }

        static void DisplayTop(string topMessage, int dashes)
        {
            PrintMethods.CreateMainBox(topMessage, dashes);
        }

        static void DisplayCourses(List<Course> courses)
        {
            int courseCount = 1;

            if (courses.Count == 0)
            {
                Console.WriteLine("\n\nThere are currently no saved courses.");
            }
            else
            {
                Console.WriteLine("\n\n{0,3} {1,-10} {2,16} {3,10} {4,10}", "#.", "Course", "Marks Earned", "Out Of", "Percent");
                Console.WriteLine("");
                foreach (Course c in courses)
                {
                    Console.WriteLine("{0,3} {1,-10} {2,16} {3,10} {4,10}",
                        courseCount + ".",
                        c.Code,
                        String.Format("{0:0.0}", c.MarksEarned),
                        String.Format("{0:0.0}", c.OutOf),
                        String.Format("{0:0.0}", c.Percent));
                    courseCount++;
                }
            }
        }
    }
}
