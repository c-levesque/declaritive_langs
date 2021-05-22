using System;
using System.Collections.Generic;
using System.Text;

namespace CL_GradesTracker_ProjectOne
{
    public static class PrintMethods
    {
        public static void CreateMainBox(string display, int d)
        {
            string intro = "~ GRADES TRACKING SYTEM ~ ";

            int display_string_length = display.Length;
            int spaces = (d - display_string_length) / 2;


            // main display
            Console.WriteLine();
            for (int x = 0; x < (spaces - (intro.Length / 4)); x++) // dynamically adjusts intro line
            {
                Console.Write(" ");
            }
            Console.Write(intro);
            Console.WriteLine("\n");


            PrintChar("-", d);

          

            bool is_odd = false;

            _ = display_string_length % 2 == 0 ? is_odd = false : is_odd = true;

            Console.WriteLine();
            Console.Write("|");

            for (int x = 0; x < spaces; x++)
            {
                Console.Write(" ");
            }
            Console.Write(display);
            for (int x = 0; x < spaces; x++)
            {
                Console.Write(" ");
            }
            if (is_odd)
                Console.Write(" ");
            Console.Write("|\n");

            PrintChar("-", d);
        }

        public static void PrintChar(string s, int amount)
        {
            int x;
            Console.Write("+");
            for (x = 0; x < amount; x++)
            {
                Console.Write(s);
            }
            Console.Write("+");

        }
    }
}
