/*
 * ITSE 1430
 * Movie Library Console Application
 */

using System;

using System.Text;
namespace MovieLibrary
{
    class Program
    {
        static void Main ( string[] args )
        {
            //FunWithTypes();
            //FunWithVariables();
            // while => while (E) S;
            // 0+ iterations, pre test condition
            while (true)
            {
                //Scope - lifetime of a variable : starts at declaration and continues until end of current scope
                //char choice = DisplayMenu();
                //if (choice == 'Q')
                //    return;
                //else if (choice == 'A')
                //    AddMovie();
                switch (DisplayMenu())
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
            //Get title
            Console.WriteLine("Movie title: ");
            //string title = Console.ReadLine();
            //Type inferencing - compile time only
            //Restrictions:
            // 1. ONLY works with local variables
            // 2. Variable must be initialized 
            // 3. (Sort of) Cannot figure out type or it is wrong
            //string title = ReadString(true);
            //int title2 = "";
            title = ReadString(true);  //string title = ReadString(true);
            //title = 10;
            //Get description
            Console.WriteLine("Description (optional): ");
            //string description = Console.ReadLine();
            description = ReadString(false);
            //Get rating
            Console.WriteLine("Rating: ");
            //string rating = Console.ReadLine();
            rating = ReadString(false);
            //Get duration
            Console.WriteLine("Duration (in minutes): ");
            //string duration = Console.ReadLine();
            duration = ReadInt32(0);
            //Get is classic
            Console.WriteLine("Is Classic (Y/N)? ");
            //string isClassic = Console.ReadLine();
            isClassic = ReadBoolean();
        }

        static char DisplayMenu ()
        {
            // 1+ iteration, post test
            // do S while (E);
            // block statement => { S* }
            do
            {
                Console.WriteLine("Movie Library");
                Console.WriteLine("-----------------");

                Console.WriteLine("A)dd Movie");

                Console.WriteLine("V)iew Movie");

                Console.WriteLine("Q)uit");

                //Get input from user
                string value = Console.ReadLine();
                //C++: if (x = 10) ; //Not valid in C#
                // if (E) S;
                // if (E) S else S;
                if (value == "Q")   // 2 equal signs => equality 
                    //if (value == "Q")   // 2 equal signs => equality 
                    if (String.Compare(value, "Q", true) == 0)

                        return 'Q';
                    else if (value == "A") ;

                    else if (String.Compare(value, "A", StringComparison.CurrentCultureIgnoreCase) == 0)

                        return 'A';

                    else if (value == "V") ;

                    else if (String.Compare(value, "V", true) == 0)
                        return 'V';

                DisplayError("Invalid option");
            } while (true);


        }

        //Displays an error
        private static void DisplayError ( string message )
        {

            Console.BackgroundColor = ConsoleColor.Red;

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(message);

            Console.ResetColor();
        }
        static bool ReadBoolean ()
        {
            do
            {
                //Read as string
                string value = Console.ReadLine();
                //Not useful because of how it is parsed
                //Boolean.TryParse(value, out bool result)
                // switch - replacement for if-else-if WHEN
                //  Each condition is against same variable
                //  AND equality
                // switch (E)
                // {
                //    case*
                //    [default]
                // }
                // case    ::= case E : S*
                // default ::= default : S*
                //if (value == "Y" || value == "y")  //NOT THE SAME ::=   value == "Y" || "y"
                //    return true;
                //else if (value == "N" || value == "n")
                //    return false;
                //else
                //    S;
                // C++ DIFFERENCES
                //   1. No fallthrough  case E: S; break; case E2 : S;
                //   2. Any expression type is allowed
                //   3. Case labels must be unique and compile time constants
                //   4. Multiple statements are allowed
                switch (value)
                {

                }
                switch (value.ToLower())
                {
                    case "X": Console.WriteLine("Wrong value"); break;

                    case "Y":                   //If case statement empty (including semicolon) then fallthrough
                    //case "Y":                   //If case statement empty (including semicolon) then fallthrough

                    case "y": return true;

                    case "N":
                    //case "N": 
                    case "n": return false;

                    case "A":
                    //case "A":
                    case "a":
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

        //Reads an integer
        static int ReadInt32 ()
        {
            return ReadInt32(Int32.MinValue);

        }

        //Reads an integer with a minimum value
        static int ReadInt32 ( int minimumValue )
        {
            do
            {
                string value = Console.ReadLine();
                //Parse to int int Int32.Parse ( string ) - not safe
                //int result = Int32.Parse(value);
                // Parameter kinds
                //   Input parameter ("pass by value") - a copy of the argument is placed into parameter inside function definition
                //   Input/output parameter ("pass by reference") - a reference to the argument is passed to the function and both original argument and parameter reference same value ( C++: int& )
                //   Output paramter - function caller does not provide input, function always provides output (C++: return type)
                //bool Int32.TryParse ( string, out int result )
                // Double.Parse/TryParse
                // Single.Parse/TryParse
                // Boolean.Parse/TryParse 
                // Int16.Parse/TryParse
                //Inline variable declaration - out parameters only
                //int result;
                //if (Int32.TryParse(value, out int result) && result >= minimumValue)

                if (Int32.TryParse(value, out var result) && result >= minimumValue)

                    return result;

                //Terminates the loop
                //break;

                //Terminate the iteration 
                //continue;

                if (minimumValue != Int32.MinValue)   //Int32.MaxValue

                    DisplayError("Value must be at least " + minimumValue);  //String concatenation

                else

                    DisplayError("Must be integral value");

            } while (true);
        }

        static void ViewMovie ()
        {
            Console.WriteLine(title);
            Console.WriteLine("Title\t\tRating\tDuration\tIsClassic");

            //Console.WriteLine("-----------------");

            Console.WriteLine("".PadLeft(60, '-'));

            //1. Format arguments
            // Format string - consists of string characters with arguments specified in curly braces as zero-based ordinals
            // 1. Readable but not great
            // 2. No compile time checking, runtime error
            //Console.WriteLine("{0}\t{1}\t{2}\t{3}", title, rating, duration, isClassic);
            //2. String.Format
            //var message = String.Format("{0}\t{1}\t{2}\t{3}", title, rating, duration, isClassic);
            //Console.WriteLine(message);
            //3. String concatenation
            //   A: Programmatically build it
            //   A: Somewhat readable
            //   D: Harder to read as it gets longer
            //   D: Bad performance

            //var message = title + "\t" + rating + "\t" + duration + "\t" + isClassic;
            //var message = title + "\t" + rating + "\t" + duration.ToString() + "\t" + isClassic.ToString();
            //Console.WriteLine(message);

            //4. String builder
            //   A: Efficient on memory
            //   A: Conditional formatting
            //   D: Longer
            //   D: Harder to read
            //var builder = new StringBuilder();
            //builder.Append(title);
            //builder.Append("\t");
            //builder.Append(rating);
            //builder.Append("\t");
            //builder.Append(duration);
            //builder.Append("\t");
            //builder.Append("isClassic");
            //builder.Append("\t");
            //message = builder.ToString();
            //5. String Joining
            //message = String.Join("\t", title, rating, duration, isClassic);

            //Conditional operator     C ? T : F

            // if (C) return T else return F

            //6. String interpolation - $
            //   A. Use expressions instead of ordinals
            //   A. More readable
            //   A. Compile time checked
            //   D. Compile time only and against literals

            var classicIndicator = isClassic ? "Yes" : "No";

            /*if (isClassic)

                classicIndicator = "Yes";

            else
                classicIndicator = "No";
            */

            var message = $"{title}\t\t{rating}\t{duration}\t\t{classicIndicator}";

            Console.WriteLine(message);

            //Write description if available

            if (!String.IsNullOrEmpty(description))

                Console.WriteLine(description);

            Console.WriteLine("");

            //TODO: Description if available

            Console.WriteLine(" " + description);

            //Console.WriteLine(" " + description);

            //TODO: If available

            Console.WriteLine(" " + rating);
            //Console.WriteLine(" " + rating);

            Console.WriteLine(duration);
            //Console.WriteLine(duration);

            Console.WriteLine(isClassic);
            //Console.WriteLine(isClassic);
        }

        //Arithmetic (unary) 
        //  +E
        //  -E 
        //Arithmetic (binary) - type coercion
        // addition 10 + 12   
        // subtraction 123 - 110.4
        // multiplication 10 * 20
        // division 30 / 3 
        // modulus 7 % 4 => 3 (remainder), only works with integrals
        //int division problem
        //  10 / 3 => int / int => int  = 3
        //  10.0 / 3 => double / int => double = 3.33
        //  (double)10 / 3 => double /int 
        // typecast => (T)E
        // not allowed => (string)10 , (int)"Hello",  (int)10.5
        //Logical operators (booleans)
        // NOT => !E : boolean
        // AND => E && E : boolean
        // OR => E || E : boolean
        //Relational operators (primitives + a few extra)
        // equality => E == E
        // inequality => E != E
        // greater than => E > E
        // greater than or equal to => E >= E
        // less than => E < E
        // less than or equal to => E <= E
        //Reads a string, optionally required
        static string ReadString ( bool required )
        {
            do
            {
                string value = Console.ReadLine();
                //If not required or not empty return
                if (!required || value != "")
                    return value;
                DisplayError("Value is required");
            } while (true);
        }

    }

}

