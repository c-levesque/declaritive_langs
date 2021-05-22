using System;
using System.Collections.Generic;
using System.Text;

namespace CL_GradesTracker_ProjectOne
{
    static class HelperMethods
    {
        public static void PromptUser(string prompt)
        {
            Console.Write(prompt);
        }
        public static string GetUserSelection()
        {
            string input = Console.ReadLine();
            input.Trim();
            string upper = input.ToUpper();
            return upper.Substring(0);
        }


        public static bool VerifyCourseCode(string code)
        {
            string code_to_test = code;
            int code_length = code_to_test.Length;

            if (code_length != 9)
                return false;

            string letters = code_to_test.Substring(0, 4);
            string hyphen = code_to_test.Substring(4, 1);
            string numbers = code_to_test.Substring(5, 4);

            // test letters 
            foreach (char c in letters)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            // test hyphen 
            foreach (char c in hyphen)
            {
                if (c != '-')
                    return false;
            }
            // test numbers 
            foreach (char c in numbers)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            // everything passed at this point so return true
            return true;
        }
        public static void VerifyEvaluationOutOf(ref int outOf)
        {
            string input;

            PromptUser("Enter the 'out of' mark: ");
            input = Console.ReadLine();
            input.Trim();

            if (int.TryParse(input, out var parseAttemptOutOf))
            {
                outOf = parseAttemptOutOf;
            }
            else
            {
                Error.PrintMessage("Input must be of type INT eg '10' ");
                VerifyEvaluationOutOf(ref outOf);
            }
        }

        public static void VerifyEvaluationWeight(ref double weight)
        {
            string input;

            PromptUser("Enter the % weight: ");
            input = Console.ReadLine();
            input.Trim();

            if (double.TryParse(input, out var parseAttemptWeight))
            {
                weight = parseAttemptWeight;
            }
            else
            {
                Error.PrintMessage("Input must be of type DOUBLE eg '10.0' ");
                VerifyEvaluationWeight(ref weight);
            }
        }

        public static void VerifyEvaluationMarksEarned(ref double marksEarned)
        {
            string input;
            PromptUser("Enter marks earned or Press ENTER to skip: ");
            input = Console.ReadLine();
            if (input == "")
            {
                marksEarned = 0.0;
            }
            else
            {
                if (double.TryParse(input, out var parseAttemptMarksEarned))
                {
                    marksEarned = parseAttemptMarksEarned;
                }
                else
                {
                    Error.PrintMessage("Input must be of type DOUBLE eg '10.0' ");
                    VerifyEvaluationWeight(ref marksEarned);
                }
            }
        }

    }

   
}
