/*
 * ITSE 1430
 * Mita Ghimire
 * Classwork
 */
using System;

//StringBuliding, Regular expressions, Encoding
//using System.Text;

namespace MovieLibrary
{
    //Type 
    // pascal case
    // Noun
    // Singular unless they represent a collection of things
    // [access] class identifier {}

    // doctags


    /// <summary>Represents a movie.</summary><summary>
    /// <remaks>
    /// A paragraph of information.
    /// Another set of information.
    /// </remaks>
    public class Movie
    {
        // date - date to store

        //Fields - where the data is stored
        //string name;
        //Fields work identical to variables
        // Named as nouns, no abbreviations and no generic names
        public string Name = "";
            

       
        public string Description = "";
        public string Rating; 
        public int RunLength; // =0
        public bool IsClassic; // = false;
        

        //Functionality - functions you want to expose
    }

    // Accessibility - the visibility of an identifier to other code, compile time only, determines who can see what at compilation
    // pubic - everybody
    // private - only the owning type (default for members)
}
