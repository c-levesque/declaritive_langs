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

        public static void course_options_display(int dashes)
        {
            int i;
            for (i = 0; i < dashes; ++i)
            {
                Console.Write("-");
            }
            Console.WriteLine("\nPress D to delete this course.");
            Console.WriteLine("Press A to add an evaluation.");
            Console.WriteLine("Press # from the above list to edit/delete a specific evaluation");
            Console.WriteLine("Press X to return to main menu");
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


        public static void main_menu(List<Course> courses, int dashes, string top_message)
        {

            // main display
            Console.WriteLine("\n" +
                "\t\t\t~ GRADES TRACKING SYSTEM ~\n");
            print_box(top_message, dashes);

            if (courses.Count == 0)
            {
                Console.WriteLine("\n\nThere are currently no saved courses.");
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
            Console.WriteLine("");
            options_display(dashes);

            // receive user input
            Console.WriteLine("");
            Console.Write("Enter a command: ");
            string input = get_user_input();

            char ch = input[0];
            int selection = -1;
            if(Char.IsDigit(ch))
            {
                selection = int.Parse(input);
                selection--;
            }
            // if selection was a number and courses is not empty, parse user input for course evaluations 
            if (Char.IsDigit(ch) && selection >= 0)
            {
                Console.Clear();
                top_message = courses[selection].code;
                main_course_menu(courses, dashes, top_message, selection);
            }
            else
            {
                parse_user_input(input, courses, dashes, top_message);
            }

        }

        public static void main_course_menu(List<Course> courses, int dashes, string top_message, int selection)
        {

            // main display
            Console.WriteLine("\n" +
                "\t\t\t~ GRADES TRACKING SYSTEM ~\n");
            print_box(top_message, dashes);

            Course selectedCourse = courses[selection];

            if (selectedCourse.evaluations == null)
            {
                Console.WriteLine("\n\nThere are currently no evaluations for " + selectedCourse.code + ".");
            }
            else
            {
                int evaluation_count = 1;
                Console.WriteLine("\n\n{0,3} {1,-10} {2,16} {3,10} {4,10} {5,12} {5,12}", "#.", "Evaluation", "Marks Earned", "Out Of", "Percent" , "Course Marks", "Weight/100");
                Console.WriteLine("");
                foreach (Evaluation e in selectedCourse.evaluations)
                {
                    Console.WriteLine("{0,3} {1,-10} {2,16} {3,10} {4,10} {5,12} {5,12}",
                        evaluation_count++ + ".",
                        e.description,
                        String.Format("{0:0.0}", e.earned_marks),
                        String.Format("{0:0.0}", e.out_of),
                        String.Format("{0:0.0}", e.percent),
                        String.Format("{0:0.0}", e.course_marks),
                        String.Format("{0:0.0}", e.weight_out_of_100));
                }
            }
            // options display
            Console.WriteLine("");
            course_options_display(dashes);

            // receive user input
            Console.WriteLine("");
            Console.Write("Enter a command: ");
            string input = get_user_input();

            char ch = input[0];

            // if selection was a number and courses is not empty, parse user input for course evaluations 
            if (Char.IsDigit(ch) && courses.Count != 0)
            {
                parse_course_selection(input, courses, dashes, top_message, selection);
            }
            else
            {
                parse_user_input(input, courses, dashes, top_message);
            }

        }
        public static string get_user_input()
        {
            string input = Console.ReadLine();
            input.Trim();
            string upper = input.ToUpper();
            return upper.Substring(0);
        }
        public static void parse_user_input(string input, List<Course> courses, int dashes, string top_message)
        {
            switch(input)
            {
                case "A":
                    Course newCourse = add_course();
                    if (newCourse != null)
                    {
                        courses.Add(newCourse);
                        Console.Clear();
                        main_menu(courses, dashes, top_message);
                    }
                    else
                    {
                        parse_user_input(input, courses, dashes, top_message);
                    }
                    break;

                default:
                    Console.Write("incorrect selection made, please select an option above: ");
                    string new_input = Console.ReadLine();
                    parse_user_input(new_input.ToUpper(), courses, dashes, top_message); break;
            }
        }

        public static void parse_course_selection(string input, List<Course> courses, int dashes, string top_message, int selection)
        {

            char ch = input[0];

            if(Char.IsDigit(ch))
            {

            }
            else
            {
                switch (input)
                {
                    case "A":
                        Evaluation new_evaluation = add_evaluation();
                        if (new_evaluation != null)
                        {
                            courses[selection].evaluations.Add(new_evaluation);
                            Console.Clear();
                            main_course_menu(courses, dashes, top_message, selection);
                        }
                        else
                        {
                            parse_course_selection(input, courses, dashes, top_message,selection);
                        }
                        break;

                    default:
                        Console.Write("incorrect selection made, please select an option above: ");
                        string new_input = Console.ReadLine();
                        parse_course_selection(new_input.ToUpper(), courses, dashes, top_message, selection); break;
                }
            }
      
        }

        public static Course add_course()
        {
            Console.Write("Enter a course code: ");
            string input = Console.ReadLine();
            input.Trim();
            string upper = input.ToUpper();

            if (verify_course_code(upper))
            {
                Course newCourse = new Course();
                newCourse.code = upper;
                return newCourse;
            }
            else
            {
                Console.WriteLine("Course code must contain 4 letters - 4 numbers ... EG 'ABCD-1234'");
                return null;
            }
        }

        public static Evaluation add_evaluation()
        {

            Evaluation new_evaluation = new Evaluation();

            Console.Write("Enter a description: ");
            string input = Console.ReadLine();
            input.Trim();
            new_evaluation.description = input;


            Console.Write("\nEnter the 'out of' mark: ");
            input = Console.ReadLine();
            input.Trim();
            int out_of = int.Parse(input);
            new_evaluation.out_of = out_of;

            Console.Write("\nEnter the % weight: ");
            input = Console.ReadLine();
            input.Trim();
            double weight = double.Parse(input);
            new_evaluation.weight_out_of_100 = weight;

            Console.Write("\nEnter marks earned or Press ENTER to skip: ");
            input = Console.ReadLine();
            double marks_earned = double.Parse(input);
            new_evaluation.earned_marks = marks_earned;

            new_evaluation.percent = 100 * new_evaluation.earned_marks / new_evaluation.out_of;
            new_evaluation.course_marks = new_evaluation.percent * new_evaluation.weight_out_of_100 / 100;

            return new_evaluation;

        }


        public static bool verify_course_code(string code)
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
    }

   
}
