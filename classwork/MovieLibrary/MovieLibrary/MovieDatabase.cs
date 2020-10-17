﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
    public class MovieDatabase
    {
        public Movie Add ( Movie movie, out string error )
        {
            //TOO : Movie is valid
            // Movie name is unique
            error = "";
            // Find first empty sport in array
            // for (EI; EC; EU ) S;
            //     EI :: = initializer expression (runs once before loop executes)
            //     EC :: = conditional expression => boolen (executes before loop statement is run, aborts if condition is false
            //     EU :: = update expression (runs at end of current iterate)
            // Length -> int(# of rows in the array)
            for (var index = 0; index < _movies.Length; ++index)
            {
                // Array element acess :: = V[int]
                if (_movies[index] == null)
                {
                    //Clone so argument can be modified without impacting out array
                    var item = CloneMovie(movie);

                    //Set a unique ID
                    item.Id = _id++;

                    //Add movie to array
                    _movies[index] = item;

                    //Set ID on orginal object and return
                    movie.Id = item.Id;
                    return movie;
                };
            };
            
            error = "No more room";
            return null;
        }

        public void Delete ( int id )
        {
            //TOOO : Validate Id
            for (var index = 0; index < _movies.Length; ++index)
            {
                //Array element acess :: = V[int]
                //if (_movies[index] != null && _movies{index].Id == id)
                if (_movies[index]?.Id == id) //null conditional ?. if instance != null acess the member
                {
                    _movies[index] = null;
                    return;
                };
            };
        }

        public Movie[]GetAll ()
        {
            //DONOT DO THIS
            //1. Expose underlying movie  items
            //2. Callers add/remove movies
            //return _movies;


            //TOOO: Determine how many movies we're storing
            //For each one create a clone copy
            return _movies;
        }

        public Movie Get (int id)

        {
            //foreach(var id in array) S
           // for (var index = 0; index < _movies.Length; ++index)
           foreach(var movie in _movies)
            {
                //movie == _movies[index]
                // Restrictions:
                // 1. movie is readonly  // movie = new Movie();
                // 2. _movies cannot change, immutable
                if (movie?.Id == id) //null conditional ?. if instance != null acess the member
                    return CloneMovie(movie);
            };
            return null;
        }
            

        public string Update ( int id, Movie movie )
        {
            //TOO: Validate Id
            // Movie exists
            var existing = Get(id);
            if (existing == null)
                return "Movie not found";

            // updated movie is valid
            // updated movie name is unique

            for (var index = 0; index < _movies.Length; ++index)
            {
                if (_movies[index]?.Id == id) //null conditional ?. if instance != null acess the member
                {
                    //Clone it so we separate our value from argument
                    var item = CloneMovie(movie);

                    item.Id = id;
                    _movies[index] = item;
                    return "";
                };
            };
            
            return "";
        }
        private Movie CloneMovie (Movie movie)
        {
            var item = new Movie();
            item.Id = movie.Id;
            item.Rating = movie.Rating;
            item.ReleaseYear = movie.ReleaseYear;
            item.RunLength = movie.RunLength;
            item.IsClassic = movie.IsClassic;
            item.Description = movie.Description;

            return item;
        }

        //Only store clone copies of movies here!!
         private Movie[] _movies = new Movie[100]; //0.99
         private int _id = 1;

    }
}
