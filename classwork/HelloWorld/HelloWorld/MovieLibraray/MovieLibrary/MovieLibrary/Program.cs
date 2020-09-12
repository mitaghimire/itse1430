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
                //char choice = DisplayMenu();
                //if (choice == 'Q')
                //    return;
                //else if (choice == 'A')
                //    AddMovie();
                switch(DisplayMenu())
                {
                    case 'Q': return;

                    case 'A': AddMovie(); break;

                    case 'V': ViewMovie(); break;
                };
            };  
        }

        static string title = "";
        static string description = "";
        static string rating = "";
        static int duration;
        static bool isClassic;

        static void AddMovie ()
        {
            // Get title
            Console.WriteLine("Movie title: ");
            //string title = Console.ReadLine();

            //type inferencing - compile time only
            //Restrictiions:
            //1. only works with local variables
            //2. Variable must be initilized
            //3. (Sort of) Cannot figure out type or it s wrong
            //string title = ReadString(true);
           // string title2 = "";
             title = ReadString(true); //tring title = ReadString(true)


            // Get description
            Console.WriteLine("Description (optional): ");
            //string description = Console.ReadLine();
             description = ReadString(false);

            // Get rating
            Console.WriteLine("Rating: ");
            //string rating = Console.ReadLine();
             rating = ReadString(false);


            // Get duration
            Console.WriteLine("Duration (in minuate): ");
            //string duration = Console.ReadLine();
             duration = ReadInt32(0);

            // Get is classic
            Console.WriteLine("Is Classic (Y/N)? ");
            //string isClassic = Console.ReadLine();
             isClassic = ReadBoolean();
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
                Console.WriteLine("V)iew Movie");
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
                else if (value == "V")
                    return 'V';

                DisplayError("Invalid option");
            } while (true);
            
        }

        //displays an error
        private static void DisplayError ( string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
                
            Console.WriteLine(message);

            Console.ResetColor();
        }

        static bool ReadBoolean()
        {
            do
            {
                //Read as string
                string value = Console.ReadLine();

                // NOt useful because of how it is parsed
                //Boolean.TryParse(value, out bool result)   

                // switch - replacement for if -else-if when
                // Each condition is against same variable
                // AnD equality
                // switch (E) 
                //{
                // case*
                // [default]
                // }
                // case :: = case E : S*
                // defult :: = defult : S*
            
                //if (value == "Y" || value == "y") //NOT THE SAME ::= value =="Y" || "y"
                //    return true;
                //else if (value == "N" || value == "n")
                //    return false;
                //else
                // S;
               // C++ differences
               //1. No fallthrought case E: S; break; case E2 : S;
               // 2. Any expression type is allowed
               // 3. Case lables must be unique and compile time constants
               // 4. Multiple statment are allowed
                switch (value)
                {
                    case "X": Console.WriteLine("Wrong value"); break;

                    case "Y":              //If case statement empty (including semicolon) then fallthrough
                    case "y": return true;

                    case "N": 
                    case "n": return false;

                    case "A":
                    { 
                        //Use block statement for more than 1 statement
                       Console.WriteLine("Wrong value");
                       Console.WriteLine("Wrong value again");
                       break;   

                    };

                  default: break; //if nothing else

                };

                    DisplayError("Invalid option");
            } while (true);
        }

        //Read an integer
        static int ReadInt32()
        {
            return ReadInt32(Int32.MinValue);
        }
        //Reads an integer wiht a minmum value
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
                //Inline variable declaration - out parameter only
               // int result;
                //if (Int32.TryParse(value, out int result) && result >= minimumValue)
                  if (Int32.TryParse(value, out var result) && result >= minimumValue)
                        return result;

                //Terminates the loop
                //break;
                //Terminate the iteration
                //continue;


                if (minimumValue != Int32.MinValue)   //Int32.MaxValue
                    DisplayError("Value must be at least" + minimumValue); //string concatenation
                else
                DisplayError("Must be integral value");
            } while (true);
        }

        static void ViewMovie()
        {
            Console.WriteLine(title);

            // TOOO: Description if available
            Console.WriteLine(" " + description);

            //TOOO: if available
            Console.WriteLine(" "+ rating);

            Console.WriteLine(duration);

            Console.WriteLine(isClassic);
        }

        //Arithmetic (uniary)
        // +E
        // -E

        //Arithmetic (binary) - type coercison
        // addition 10 + 12
        //subtraction 123 - 110.4
        //multiplication 10 * 20
        // division 30 / 3
        // modulus 7 % 4 => 3 (remainder) , only works with integrals

        //int division problem
        // 10 / 3 => int / int => int = 3
        // 10.0 / 3 => double / int => double = 3.33
        // (double)10 /3 => double /int

        // typecast => (T)E
        // not allowed => (string)10, int "Hellow" , (int)10.5

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


        static void FunWithStrings ()
        {
            //5 characters in it, takes up 10 bytes
            //C++ difference : no NULl

            // Escape sequence begins wwith \ and is followed by generally 1 character, only works in literals
            // \n - newline
            // \t - tab
            // \" - "
            // \' - ' (char literal)
            // \\ - \
            // \xHH - hex equivalent \x0A
            var name = "Bob\c"; //Complier warning - Bobc
            var message = "Hello \"Bob\nWorld";

            //File Paths - always escape sequences
            var filePath = "C:\\Temp\\test.pdf"; //C:\Temp\test.pdf
            var filePath2 = @"C:\Temp\test.pdf"; //Verbatim string

            //TOOOO : null and empty string
        }

    }
}
