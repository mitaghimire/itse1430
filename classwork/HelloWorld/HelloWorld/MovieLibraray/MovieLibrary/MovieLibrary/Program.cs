/*
 * ITSE 1430
 * Movie Library Console Application
 */
using System;

namespace MovieLibrary
{
    class Program
    {
        static void Main ( string[] args )
        {
            //FunWithTypes();
            //FunWithVariables();

            // while=> while (E) S ;
            // 0+ iterations, pre test condition
            while (true)
            {
                // Scope  -lifetime of a variable : starts at declaration and continues untile end of current scope
                char choice = DisplayMenu();
                if (choice == 'Q')
                    return;
                else if (choice == 'A')
                    AddMovie();
            };

            string title = "";
            string description = "";
            string rating = "";
            int duratiion;
            
        }

        static void AddMovie ()
        {
            // Get title
            Console.WriteLine("Movie title: ");
            //string title = Console.ReadLine();
            string title = ReadString(true);

            // Get description
            Console.WriteLine("Description (optional): ");
            //string description = Console.ReadLine();
            string description = ReadString(false);

            // Get rating
            Console.WriteLine("Rating: ");
            //string rating = Console.ReadLine();
            string rating = ReadString(false);


            // Get duration
            Console.WriteLine("Duration (in minuate): ");
            //string duration = Console.ReadLine();
            int duration = ReadInt32(0);

            // Get is classic
            Console.WriteLine("Is Classic (Y/N)? ");
            string isClassic = Console.ReadLine();
        }

        static char DisplayMenu ()
        {
            // 1+ iteration, post test
            // do S while (E) ;
            // block statement => { S* }
            do
            {
                Console.WriteLine("Movie Library");
                Console.WriteLine(".............");

                Console.WriteLine("A)dd Movie");
                Console.WriteLine("Q)uit");

                // Get input from user
                string value = Console.ReadLine();

                // C++ : (x =10) ; // Not valid in C#
                // if(E) S;
                // if (E) S else S ;
                if (value =="Q") // 2 equal signs => equality
                    return 'Q';
                else if (value == "A")
                    return 'A';

                DisplayError("Invalid option");
            } while (true);
            
        }

        private static void DisplayError ( string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
                
            Console.WriteLine(message);

            Console.ResetColor();
        }
        static int ReadInt32()
        {
            return ReadInt32(Int32.MinValue);
        }
        static int ReadInt32( int minimumValue )
        {
            do
            {
                string value = Console.ReadLine();

                //Parse to int int32.Parse (string) -not safe
                // int result = Int32.Parse(value);

                //Parameter kinds
                //  Input parameter ("pass by value") - a copy of the argument is places into parameter inside function defination
                //  Input/output parameter ("pass by reference") - a reference to the argument is passed to the function and both orginal argument and parameter reference same value (C++: int& )
                // Output parameter -function caller does not provide input, function always provides output ( C++ : return type)
                //bool Int32.TryParse (string, out int result )
                // Double.Parse/TryParse
                //Single.Parse/TryParse
                //Boolean.Parse/TryParse
                //Int16.Parse/TryParse
                int result;
              if (Int32.TryParse(value, out result) && result >= minimumValue)
                return result;

                if (minimumValue != Int32.MinValue)   //Int32.MaxValue
                    DisplayError("Value must be at least" + minimumValue); //string concatenation
                else
                DisplayError("Must be integral value");
            } while (true);
        }
        //Logical operators (booleans)
        // Not = > !E
        // AND => E && E : boolean
        // OR => E || E : boolean

        //Relational operators ( primitives + afew extra )
        // equality => E == E
        // inequality => E != E
        // greater than  => E > E
        // greater than or equal to => E >= E
        // less than => E < E
        // less than or equal to => E <= E

        static string ReadString ( bool required )
        {
            do
            {
                string value = Console.ReadLine();

                //if not reuired or not empty return
                if (!required || value != "")
                        return value;
                //{
                    // Is it empty
                    //if (value == "")
                        DisplayError("value is required");
                //}
               // return value;
            } while (true);
    }

    }
}
