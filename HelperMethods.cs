using System;
using System.Collections.Generic;
using System.Text;

namespace CL_GradesTracker_ProjectOne
{
    static class HelperMethods
    {


        public static void options_display(int dashes)
        {
            int i;
            for (i = 0; i < dashes; ++i)
            {
                Console.Write("-");
            }

            Console.WriteLine("\nPress # from the above list to view/edit/delete a specific course.");
            Console.WriteLine("Press A to add a new course.");
            Console.WriteLine("Press X to quit");


            for (i = 0; i < dashes; ++i)
            {
                Console.Write("-");
            }
        }

        public static void print_box(string display, int d)
        {
            int display_string_length = display.Length;

            print_multiple("-", d);

            int spaces = (d - display_string_length) / 2;

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

            print_multiple("-", d);


        }

        public static void print_multiple(string s, int amount)
        {
            int x;
            Console.Write("+");
            for (x = 0; x < amount; x++)
            {
                Console.Write(s);
            }
            Console.Write("+");

        }


        public static void main_menu(List<Course> courses, int dashes)
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("\n\nThere are currently no saved courses.\n");
            }
            else
            {
                int courseCount = 1;
                Console.WriteLine("\n\n{0,3} {1,-10} {2,16} {3,10} {4,10}", "#.", "Course", "Marks Earned", "Out Of", "Percent");
                Console.WriteLine("");
                foreach (Course c in courses)
                {
                    Console.WriteLine("{0,3} {1,-10} {2,16} {3,10} {4,10}",
                        courseCount++ + ".",
                        c.code,
                        String.Format("{0:0.0}", c.marks_earned),
                        String.Format("{0:0.0}", c.out_of),
                        String.Format("{0:0.0}", c.percent));
                }
            }
            // options display
            options_display(dashes);

            // receive user input
            get_user_input();
        }

        public static void get_user_input()
        {
            Console.WriteLine("");
            Console.Write("Enter a command: ");
            string input = Console.ReadLine();
            input.Trim();
            string selection = input.Substring(0);

            Console.WriteLine("you typed -> " + selection);
        }
    }
}
