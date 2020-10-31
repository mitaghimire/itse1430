using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
   public class SeedMovieDatabase
    {
        public void Seed (IMovieDatabase database)
        {
            //Not Needed here
            //_movies.Clear(); clear all item from list

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

            // TOOO: Fix error handling
            foreach (var item in items)
               database.Add(item, out var error);


        }
    }
}
