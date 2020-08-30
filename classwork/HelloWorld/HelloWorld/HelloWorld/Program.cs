/*
 * Mita Ghimire
 * ITSE 1430
 * Lab 1
 */
using System;

namespace HelloWorld
{
    // pascal casing - capitalize on word boundaries including first word
    // camel casing - capitalize on word boundaries except first ( e.g. firstName, payRate)
    class Program
    { 
        // Fuction declaration - declaration to compiler that a function exists with a given signature
        // Fuction signature - fuction name and the parameter types (sometime it will include return type)
        // Function defination - declaration + implementation
        static void Main ( string[] args ) //parameter
        {
            // A single line comment
            // Another line of comments

            // display given string to output
            //Arguments - data passed to function
            Console.WriteLine("Hello World!"); //printf, cout

            // variale declaration: 
            // T id; 
            //int hours;
            //hours = 10; //Assignment operator id =E

            // Identifier Rules
            //1. unique within scope
            //2. must satrt with underscore or letter
            //3. consist of letters, digits and underscores
            //always camel case local variable(noun) and parameter
            //Preferred: T id = E;
            int hours = 10;

            //int pay = 0;
            //pay = hours * 9;
            int totalpay = hours * 9;

            //Function overloading - multiple functions with same name but different paremeters
            //atof, atoi
            Console.WriteLine(totalpay);
      
        }

    }
}     