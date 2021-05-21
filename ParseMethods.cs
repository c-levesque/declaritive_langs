using System;
using System.Collections.Generic;
using System.Text;

namespace CL_GradesTracker_ProjectOne
{
    public static class ParseMethods
    {
        public static void ParseMainInput(string input, List<Course> courses, int dashes, string top_message)
        {
            switch (input)
            {
                case "A":
                    Course newCourse = CrudMethods.AddCourse();
                    if (newCourse != null)
                    {
                        courses.Add(newCourse);
                        Console.Clear();
                        MainMenu.Display(courses, dashes, top_message);
                    }
                    else
                    {
                        ParseMainInput(input, courses, dashes, top_message);
                    }
                    break;

                case "X":
                    System.Environment.Exit(1);
                    break;

                default:
                    Error.PrintMessage("incorrect selection made, please select an option above: ");
                    string new_input = Console.ReadLine();
                    ParseMainInput(new_input.ToUpper(), courses, dashes, top_message); break;
            }
        }

        public static void ParseCourseInput(string input, List<Course> courses, int dashes, string top_message, int selection)
        {
            char ch = input[0];

            if (Char.IsDigit(ch))
            {
                // evaluation selection goes here
            }
            else
            {
                switch (input)
                {
                    case "A":
                        courses[selection].Evaluations.Add(CrudMethods.AddEvaluation());
                        Console.Clear();
                        CourseMenu.Display(courses, dashes, top_message, selection);
                        break;

                    case "X":
                        Console.Clear();
                        top_message = "Grades Summary";
                        MainMenu.Display(courses, dashes, top_message);
                        break;

                    default:
                        Console.Write("incorrect selection made, please select an option above: ");
                        string new_input = Console.ReadLine();
                        ParseCourseInput(new_input.ToUpper(), courses, dashes, top_message, selection); break;
                }
            }

        }
    }

}
