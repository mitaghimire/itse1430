/*
 * ITSE 1430
 * movie Library Console Application
 */
    using System;

namespace MovieLibraray
{
    class Program
    {
        static void Main ( string[] args )
        {
            //FunWithTYpes();
            //FunWithVariable();


            // while => while (E) S ;
            // 0+ iterations, pre test condition
            while (true)
            {
                char choice = DisplayMenu();
                if (choice == 'Q')
                    return;
            };

            string title = "";
            string description = "";
            string rating = "";
            int duration;
        }
        // 
         static char DisplayMenu ()
         {
            // 1+ iteration, post test
            // do S while (E);
            // block statement => { S* }
            do
            {

                Console.WriteLine("MovieLibrary");
                Console.WriteLine("............");

                Console.WriteLine("Q)uit");

                 // Get input from user
                string input = Console.ReadLine();

                 // C++: if (X = 10 ) ;
                //If (E) S;
                if (input == "Q") // 2 equal signs => equality
                  return 'Q';

              Console.WriteLine("Invalid option");
            } while (true);


         }
    }

}
