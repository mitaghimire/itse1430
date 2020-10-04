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
        //Data - data to store
       
        //Fields - where the data is stored
        //string name;
        //Fields work identical to variables
        // Named as nouns, no abbreviations and no generic names
        public string Name = "";
        public string Description = "";
        public string Rating; 
        public int RunLength; // = 0;
        public bool IsClassic; // = false;
        public int ReleaseYear = 1900;
        

        //Functionality - functions you want to expose 

        /// <summary>Validates the movie instance.</summary>
        /// <returns> The error message, if any.</returns>
        public string Validate(/*Movie this */)
        {
            //this is reference to current instance
            //rarely needed
            //var name = this.Name;

            //only 2 cases where 'this' is needed
            //1. scoping issues => fix the issue
            //    fields are _id
            //    locals are id
            //    ex:
            //      var Name =""; //WRONG
            // this.Nmae = Name; //CORRECT
            // 2. passing the entire object to another method (only really valid case)

            //Name ir required
            if (String.IsNullOrEmpty(Name)) //this.Name
                return "Name is require";

            //Run lenght must be >= 0
            if (RunLength < 0)
                return "Run Length must be greater than or equal to 0";

            //Release year must be >= 1900
            if (ReleaseYear < 1900)
                return "Release Year must be at least 1900";

            return null;
        }
    }

    // Accessibility - the visibility of an identifier to other code, compile time only, determines who can see what at compilation
    // pubic - everyone
    // private - only the owning type (default for members)
}
