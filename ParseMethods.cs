using System;
using System.Collections.Generic;
using System.Text;

namespace CL_GradesTracker_ProjectOne
{
    public static class ParseMethods
    {
        public static void ParseMainInput(string input, ref List<Course> courses, int dashes, string top_message)
        {
            switch (input)
            {
                case "A":
                    Course newCourse = CrudMethods.AddCourse();
                    if (newCourse != null)
                    {
                        courses.Add(newCourse);
                        Console.Clear();
                        MainMenu.Display(ref courses, dashes, top_message);
                    }
                    else
                    {
                        ParseMainInput(input, ref courses, dashes, top_message);
                    }
                    break;

                case "X":
                    System.Environment.Exit(1);
                    break;

                default:
                    Error.PrintMessage("incorrect selection made, please select an option above: ");
                    HelperMethods.PromptUser("Enter a command: ");
                    string new_input = Console.ReadLine();
                    char c = new_input[0];
                    MainMenu.ParseUserInput(c, -1, new_input, ref courses, top_message, dashes); break;
            }
        }

        public static void ParseCourseInput(string input, ref List<Course> courses, int dashes, string topMessage, int selection)
        {
            

            if(int.TryParse(input, out var parsedSelection))
            {
                if(parsedSelection <= 0 || parsedSelection > courses[selection].Evaluations.Count)
                {
                    Error.PrintMessage("Incorrect input, try again..");
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

                    case "X":
                        Console.Clear();
                        topMessage = "Grades Summary";
                        MainMenu.Display(ref courses, dashes, topMessage);
                        break;

                    default:
                        Error.PrintMessage("Incorrect input, try again..");
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
                    DeleteEvaluation(ref courses, courseSelection, evaluationSelection);
                    Console.Clear();
                    CourseMenu.Display(ref courses, dashes, courses[courseSelection].Code, courseSelection);
                    break;

                case "E":
                    Console.Clear();
                    MainMenu.Display(ref courses, dashes, "Grades Summary");
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

        static void DeleteEvaluation(ref List<Course> courses, int courseSelection, int evaluationSelection)
        {
            string input;
            HelperMethods.PromptUser($"Delete { courses[courseSelection].Evaluations[evaluationSelection].Description }? (Y/N): ");
            input = HelperMethods.GetUserSelection();
            if(VerifyYesOrNo(input))
            {
                if(input == "Y")
                {
                    courses[courseSelection].Evaluations[evaluationSelection] = null;
                }
                else
                {
                    return;
                }
            }
            else
            {
                Error.PrintMessage("Incorrect input, try again...");
                DeleteEvaluation(ref courses, courseSelection, evaluationSelection);
            }
        }

        static bool VerifyYesOrNo(string input)
        {
            switch(input)
            {
                case "Y":
                    return true;
                case "N":
                    return true;
                default:
                    return false;
            }
        }

    }

}
