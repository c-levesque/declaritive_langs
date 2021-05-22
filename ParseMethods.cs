using System;
using System.Collections.Generic;
using System.Text;

namespace CL_GradesTracker_ProjectOne
{
    public static class ParseMethods
    {
        public static void ParseMainInput(string input, ref List<Course> courses, int dashes, string topMessage)
        {
            if (int.TryParse(input, out var parsedSelection))
            {
                if (parsedSelection <= 0 || parsedSelection > courses.Count)
                {
                    Error.PrintMessage("Incorrect input, try again..");
                    Console.WriteLine();
                    HelperMethods.PromptUser("Enter a command: ");
                    input = HelperMethods.GetUserSelection();
                    ParseMainInput(input, ref courses, dashes, "Grades Summary");
                }
                else
                {
                    Console.Clear();
                    CourseMenu.Display(ref courses, dashes, courses[--parsedSelection].Code, parsedSelection);
                }
            }
            else
            {
                switch (input)
                {
                    case "A":
                        Course newCourse = CrudMethods.AddCourse();
                        if (newCourse != null)
                        {
                            courses.Add(newCourse);
                            Console.Clear();
                            MainMenu.Display(ref courses, dashes, topMessage);
                        }
                        else
                        {
                            ParseMainInput(input, ref courses, dashes, topMessage);
                        }
                        break;

                    case "X":
                        System.Environment.Exit(1);
                        break;

                    default:
                        Error.PrintMessage("Incorrect input, try again..");
                        Console.WriteLine();
                        HelperMethods.PromptUser("Enter a command: ");
                        string new_input = HelperMethods.GetUserSelection();
                        ParseMainInput(new_input, ref courses, dashes, topMessage); break;
                }
            }
           
        }

        public static void ParseCourseInput(string input, ref List<Course> courses, int dashes, string topMessage, int selection)
        {
            

            if(int.TryParse(input, out var parsedSelection))
            {
                if(parsedSelection <= 0 || parsedSelection > courses[selection].Evaluations.Count)
                {
                    Error.PrintMessage("Incorrect input, try again..");
                    Console.WriteLine();
                    HelperMethods.PromptUser("Enter a command: ");
                    input = HelperMethods.GetUserSelection();
                    ParseCourseInput(input, ref courses, dashes, topMessage, selection);
                }
                else
                {
                    DisplayEvaluation(input, ref courses, dashes, topMessage, selection);
                }
            }
            else
            {
                switch (input)
                {
                    case "A":
                        courses[selection].Evaluations.Add(CrudMethods.AddEvaluation());
                        Console.Clear();
                        CourseMenu.Display(ref courses, dashes, topMessage, selection);
                        break;

                    case "D":
                        CrudMethods.DeleteCourse(ref courses, selection);
                        Console.Clear();
                        MainMenu.Display(ref courses, dashes, "Grades Summary");
                        break;

                    case "X":
                        Console.Clear();
                        topMessage = "Grades Summary";
                        MainMenu.Display(ref courses, dashes, topMessage);
                        break;

                    default:
                        Error.PrintMessage("Incorrect input, try again..");
                        Console.WriteLine();
                        HelperMethods.PromptUser("Enter a command: ");
                        string new_input = Console.ReadLine();
                        ParseCourseInput(new_input.ToUpper(), ref courses, dashes, topMessage, selection); break;
                }
            }

        }

        public static void DisplayEvaluation(string input, ref List<Course> courses, int dashes, string topMessage, int courseSelection)
        {
            int evaluationSelection = int.Parse(input) - 1;
            Console.Clear();
            topMessage += $" {courses[courseSelection].Evaluations[evaluationSelection].Description }";
            EvaluationMenu.Display(ref courses, dashes, topMessage, courseSelection, evaluationSelection);
        }

        public static void ParseEvaluationInput(string input, ref List<Course> courses, int dashes, string topMessage, int courseSelection, int evaluationSelection)
        {       
            switch (input)
            {
                case "D":
                    CrudMethods.DeleteEvaluation(ref courses, courseSelection, evaluationSelection);
                    Console.Clear();
                    CourseMenu.Display(ref courses, dashes, courses[courseSelection].Code, courseSelection);
                    break;

                case "E":
                    CrudMethods.EditEvaluation(ref courses, courseSelection, evaluationSelection);
                    Console.Clear();
                    CourseMenu.Display(ref courses, dashes, courses[courseSelection].Code, courseSelection);
                    break;

                case "X":
                    Console.Clear();
                    CourseMenu.Display(ref courses, dashes, courses[courseSelection].Code, courseSelection);
                    break;

                default:
                    Console.Write("incorrect selection made, please select an option above: ");
                    string new_input = Console.ReadLine();
                    ParseCourseInput(new_input.ToUpper(), ref courses, dashes, topMessage, courseSelection); break;
            }
        }

       

    

    }

}
