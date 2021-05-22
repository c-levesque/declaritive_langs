using System;
using System.Collections.Generic;
using System.Text;

namespace CL_GradesTracker_ProjectOne
{
    public static class EvaluationMenu
    {
        public static void Display(ref List<Course> courses, int dashes, string topMessage, int courseSelection, int evaulationSelection)
        {
            string input;

            DisplayTop(topMessage, dashes);

            DisplayEvaluation(courses, courseSelection, evaulationSelection);

            OptionMenu.DisplayEvaluationOptions(dashes);

            HelperMethods.PromptUser("Enter a command: ");
            input = HelperMethods.GetUserSelection();

            ParseMethods.ParseEvaluationInput(input, ref courses, dashes, topMessage, courseSelection, evaulationSelection);
        }

  

        static void GetEvaluationSelection(ref char c, ref int selection, string input)
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

        static void DisplayEvaluation(List<Course> courses, int courseSelection, int evaluationSelection)
        {

            Evaluation temp = courses[courseSelection].Evaluations[evaluationSelection];
        
            Console.WriteLine("\n\n{0,-10} {1,16} {2,7} {3,10} {4,13} {5,12}",
                "Evaluation", 
                "Marks Earned", 
                "Out Of", 
                "Percent", 
                "Course Marks", 
                "Weight/100");
            Console.WriteLine(""); Console.WriteLine("{0,-10} {1,16} {2,7} {3,10} {4,13} {5,12}",
                temp.Description,
                String.Format("{0:0.0}", temp.MarksEarned),
                String.Format("{0:0.0}", temp.OutOf),
                String.Format("{0:0.0}", temp.Percent),
                String.Format("{0:0.0}", temp.CourseMarks),
                String.Format("{0:0.0}", temp.Weight));
            
           
        }
    }
}
