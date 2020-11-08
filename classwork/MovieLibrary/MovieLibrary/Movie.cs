
/*
 * ITSE 1430
 * Mita Ghimire
 * Classwork
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

    //Static vs instance members 
    // Instance members are tied to the instance they are called on 
    //    Fields - data in the instance (instance._id, instance._name)
    // Method - requires an instance to execute (instance.method())  (instance.ToString)
    // Static members are globel to all instances
    //   Fields - equivlaent to globel variable
    //   Method - equivalent to a globel function, does not have instance access, does not have a parameter (Int32.TryParse)
    /// <summary>Represents a movie.</summary><summary>
    /// <remaks>
    /// A paragraph of information.
    /// Another set of information.
    /// </remaks>
    public class Movie : IValidatableObject
    {
        //Data - data to store

        //Fields - where the data is stored
        // Should always be private
        //Named using camel case and start with underscore
        //string name;
        //Fields work identical to variables
        // Named as nouns, no abbreviations and no generic names

        //Only time public field allowed - read only data
        //Constants
        // [access] const T identifier = E;
        // 1. Must be a primitive type
        // 2. Must have an intializer expression
        // 3. Must recompile all code if value changed
        public const int MaximumNameLength = 50;

        //Read only
        // [acess] readonly T identifier;
        // 1. any type
        // 2. Must be initialized once either in initializer expression or at instance creation
        // 3. Allowed to have different "readonly" values for each instance
        // 4. Is not baked into source code
        public readonly int MaximumDescriptionLength = 200;
        
       
        //Not a field because:
        //1. can not write
        //2. calculated
        //public int Age;

        //Not a method either, because:
        //1. Not funcationality
        //2. complex syntax compared to fields
        //3. Get/Set is in name
        //public int GetAge () { }
        public int Age
        {
            //read only property
            //Calculated property
            get { return DateTime.Now.Year - ReleaseYear; }
            //set { }

        }

        // Mixed accessibility - using a different access on either getter or setter
        // 1. only 1 method can have access modifier
        //2. always more restrictive
        public int Id { get; set; } 

        //Properties - Methods that have fields-like syntax
        // full peoperty [acess]  T identifier { getter setter }
        // getter :: = get { S* }
        // setter :: = set { S* }
        // auto property :: = [acess] T identifier {get; set;}
        // Properties returing arrays or strings should not return null
        public string Name
        {
            //getter T get _Name ()
            get 
            {
                // Coalesce - scanning a series of expressions looking for non-Null
                // E1 ?? E2
                // if E1 is not null then return E1
                // else return E2
                //if (_name ==null)
                //    return "";

                //return _name;
                return _name ?? "";


            }
            //setter void set_Name ( T value ) 
            set 
            {
                _name = value;
            }
        }
        private string _name = "";

        /// <summary>Gets or Sets the movie description./// </summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }

        }
        private string _description = "";

        public string Rating
        {
            get { return _rating ?? ""; }
            set { _rating = value; }

        }
        private string _rating;

        /// <summary>Gets or sets the run length in minutes. /// </summary>
        public int RunLength { get; set; }
        //{
        //    get { return _runLength; }
        //    set { _runLength = value; }
        //}
        //private int _runLength; // = 0;

        /// <summary>Get or sets the release year./// </summary>
        /// <value>Default value is 1900.</value>
        public int ReleaseYear { get; set; } = 1900;
        //{
        //    get { return _releaseYear; }
        //    set { _releaseYear = value; }
        //}
        //private int _releaseYear = 1900;

        public bool IsClassic { get; set; }
        //{
        //    get { return _isClassic;}
        //    set { _isClassic = value; }
        //}
        // private bool _isClassic; // = false;

        //Functionality - functions you want to expose 

        /// <summary>Validates the movie instance.</summary>
        /// <returns> The error message, if any.</returns>
       // public string Validate(/*Movie this */)
       // {
        //    //this is reference to current instance
        //    //rarely needed
        //    //var name = this.Name;

        //    //only 2 cases where 'this' is needed
        //    //1. scoping issues => fix the issue
        //    //    fields are _id
        //    //    locals are id
        //    //    ex:
        //    //      var Name =""; //WRONG
        //    // this.Nmae = Name; //CORRECT
        //    // 2. passing the entire object to another method (only really valid case)

            //Name ir required
            //if (String.IsNullOrEmpty(Name)) //this.Name
               // return "Name is require";

            //Run lenght must be >= 0
            //if (RunLength <= 0)
                //return "Run Length must be greater than or equal to 0";

            //Release year must be >= 1900
            //if (ReleaseYear< 1900)
                //return "Release Year must be at least 1900";

            //return null;
       // }

    public override string ToString (/* this */)   //instane.ToString()
    {
        return Name;
    }

    public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            //when you are using the iterator syntax then all the return statement must be yield return

            if (String.IsNullOrEmpty(Name))
                yield return new ValidationResult("Name is required", new[] { nameof(Name) });
                        //Yield returing new validation result with message and string array (collection in it syntax) containg a single strin with name of Name

            if (RunLength <0)
                yield return new ValidationResult("Run Length must be greater than or equal to 0" ,new[] { nameof(RunLength) });

            if (ReleaseYear < 1900)
                yield return new ValidationResult("Release Year must be at least 1900", new[] { nameof(ReleaseYear) });

            //return null;
        }
    }

    // Accessibility - the visibility of an identifier to other code, compile time only, determines who can see what at compilation
    // pubic - everyone
    // private - only the owning type (default for members)
}
