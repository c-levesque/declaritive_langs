using System;
using System.Collections.Generic;
using System.Text;

namespace CL_GradesTracker_ProjectOne
{
    public static class CrudMethods
    {
        public static Course AddCourse()
        {
            string input, inputToUpper;
            HelperMethods.PromptUser("Enter a course code: ");
            input = Console.ReadLine();
            input.Trim();
            inputToUpper = input.ToUpper();

            if (HelperMethods.VerifyCourseCode(inputToUpper))
            {
                return new Course(inputToUpper);
            }
            else
            {
                Error.PrintMessage("Course code must contain 4 letters - 4 numbers ... EG 'ABCD-1234'");
                Console.WriteLine();
                return null;
            }
        }

        public static Evaluation AddEvaluation()
        {
            string description;
            int outOfParsed = 0;
            double weightParsed = 0.0, marksEarnedParsed = 0.0;

            HelperMethods.PromptUser("Enter a description: ");
            description = Console.ReadLine();
            description.Trim();

            HelperMethods.VerifyEvaluationOutOf(ref outOfParsed);

            HelperMethods.VerifyEvaluationWeight(ref weightParsed);

            HelperMethods.VerifyEvaluationMarksEarned(ref marksEarnedParsed);

            return new Evaluation(description, outOfParsed, marksEarnedParsed, weightParsed);
        }


        public static void DeleteEvaluation(ref List<Course> courses, int courseSelection, int evaluationSelection)
        {
            string input;
            HelperMethods.PromptUser($"Delete { courses[courseSelection].Evaluations[evaluationSelection].Description }? (Y/N): ");
            input = HelperMethods.GetUserSelection();
            if (VerifyYesOrNo(input))
            {
                if (input == "Y")
                {
                    Evaluation toBeRemoved = courses[courseSelection].Evaluations[evaluationSelection];
                    courses[courseSelection].Evaluations.Remove(toBeRemoved);
                    toBeRemoved = null;
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

        public static void DeleteCourse(ref List<Course> courses, int courseSelection)
        {
            string input;
            HelperMethods.PromptUser($"Delete { courses[courseSelection].Code }? (Y/N): ");
            input = HelperMethods.GetUserSelection();
            if (VerifyYesOrNo(input))
            {
                if (input == "Y")
                {
                    Course toBeRemoved = courses[courseSelection];
                    courses.Remove(toBeRemoved);
                    toBeRemoved = null;
                }
                else
                {
                    return;
                }
            }
            else
            {
                Error.PrintMessage("Incorrect input, try again...");
                Console.WriteLine();
                DeleteCourse(ref courses, courseSelection);
            }
        }

        static bool VerifyYesOrNo(string input)
        {
            switch (input)
            {
                case "Y":
                    return true;
                case "N":
                    return true;
                default:
                    return false;
            }
        }

        internal static void EditEvaluation(ref List<Course> courses, int courseSelection, int evaluationSelection)
        {
            Evaluation editedEvaluation = AddEvaluation();
            courses[courseSelection].Evaluations[evaluationSelection] = editedEvaluation;
        }
    }


    
}
