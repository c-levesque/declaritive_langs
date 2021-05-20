using System;

namespace CL_GradesTracker_ProjectOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n" +
                "\t\t\t~ GRADES TRACKING SYSTEM ~\n");

            print_box("got it working ");
        }

        static void print_box(string display)
        {
            int dashes = 74, display_string_length = display.Length;

            print_multiple("-", dashes);

            int spaces = (dashes - display_string_length) / 2;

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

            print_multiple("-", dashes);


        }

        static void print_multiple(string s, int amount)
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