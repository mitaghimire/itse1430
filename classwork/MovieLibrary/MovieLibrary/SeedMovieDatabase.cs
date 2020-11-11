using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
   public static class SeedMovieDatabase
    {
        //Make static because it does not reference any instance data
        //Nor does it really need to be created
        //Converting to an extension method
        //1. Must be in a static class (public or internal)
        //2. Must accept as a first parameter the type to extend
        //3. First parameter must be preceded by keyword 'this 
        //  4. (Optional) Change first parameter to `source`
        public static void Seed ( this IMovieDatabase source )   //database.Seed()
        {
            //Extension methods - DO NOT check for null

            //Not Needed here - clear all item from list
            //_movies.Clear(); 

            //Collection initializer syntax
            var items = new[] { //new Movie[] {
                new Movie() {
                   Name = "Jaws",
                   ReleaseYear = 1977,
                   RunLength = 190,
                   Description = "Shark movie",
                   IsClassic = true,
                   Rating = "PG",   // Can have a comma at end
                },
               new Movie() {
                Name = "Jaws 2",
                ReleaseYear = 1979,
                RunLength = 195,
                Description = "Shark movie",
                IsClassic = true,
                Rating = "PG 13",
               },
               new Movie() {
                 Name = "Dune",
                 ReleaseYear = 1985,
                 RunLength = 220,
                 Description = "Based on book",
                 IsClassic = true,
                 Rating = "PG",
               },

            };

            //TODO: Fix error handling
            foreach (var item in items)
                source.Add(item);

        }
    }
}
