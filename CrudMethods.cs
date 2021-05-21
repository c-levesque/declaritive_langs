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

            return new Evaluation(description, outOfParsed, marksEarnedParsed, weight_out_of_100);

        }


    }


    
}
