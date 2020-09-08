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
                    AddMenu();
            };

            string title = "";
            string description = "";
            string rating = "";
            int duratiion;
            
        }

        static void AddMenu ()
        {
            // Get title
            Console.WriteLine("Movie title: ");
            string title = Console.ReadLine();

            // Get description
            Console.WriteLine("Description: ");
            string description = Console.ReadLine();

            // Get rating
            Console.WriteLine("Rating: ");
            string rating = Console.ReadLine();


            // Get duration
            Console.WriteLine("Duration (in minuate): ");
            string duration = Console.ReadLine();

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

                DisplayError();
            } while (true);
            
        }

        private static void DisplayError ()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
                
            Console.WriteLine("Invalid option");

            Console.ResetColor();
        }
    }
}
