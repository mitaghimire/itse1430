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

            //while = while (E) S;
            //0+ iterations, pre test conditon
            while (true)
            {
                //scope - lifetime of a variable : starts at declaration and continues untile end of current scope
                char choice = DisplayMenu();
                if (choice == 'Q')
                    return;
            };

            DisplayMenu();

            string title = "";
            string description = "";
            string rating = "";
            int duration;

            static void DisplayMenu ()
            {
                do
                {



                    Console.WriteLine("Movie Library");
                    Console.Write("...........");

                    Console.WriteLine("Q)uit");

                    //Get input from user
                    string input = Console.ReadLine();

                    //c++ : if (x =10);
                    // if (E) S;
                    if (input =="Q") // 2 equal sign = equality
                        return 'Q';



                    Console.WriteLine("Invalid option");
                } while (true);




            }
        }
    }
}
