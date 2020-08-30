/*
 * Mita Ghimire
 * ITSE 1430
 * Lab 1
 */
using System;

namespace HelloWorld
{
    // pascal casting - capitalize on word boundaries including first word
    // camel casting - capitalize on word boundaries except first ( e.g. firstName, payRate)
    class Program
    { 
        // Fuction declaration - declaration to compile that a function exists with a given signature
        // Fuction signature - fuction name and the parameter types (sometime it will include return type)
        // Function defination - declaration + implementation
        static void Main ( string[] args )
        {
            // A single line comment
            // Another line of comment

            // display given string to output
            Console.WriteLine("Hello World!");

            int hours = 40;
            double payRate = 12.80;

            double totalPay = hours * payRate;
              
            // variale declaration
            // T id; 

            //always camel case

            //prefered : T id = E;
           
            
            hours = 10; // assigment operator : id = E

           

            //int pay = 0;
            // pay = hours *9;
            int pay = hours *9;
       
        }

    }
}     