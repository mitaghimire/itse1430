using System;
using System.Collections.Generic;
using System.Linq;


namespace MovieLibrary
{
    //Interfaces appear on the same line as base types but ARE NOT base type
    //MovieDatabase implements ImovieDatabase
    // A type can implement any # of interfaces
    // All members on an interface must be public and implemented

    //Abstract class required if any member is abstract
    // 1. Cannot be instantiated
    // 2. Must derive from it 
    // 3. Must implement all abstract members

    /// <summary>Provides the base implementation of a database of movies.</summary>
    public abstract class MovieDatabase : IMovieDatabase  // IEditableDatabase, IReadableDatabase
    {
       
        //Not on interface
       // public void Foo () { }
        public Movie Add ( Movie movie, out string error )
        {
            //TOOO: Movie is not null

            //Movie is valid
            var results = new ObjectValidator().TryValidateFullObject(movie);
            if (results.Count() > 0)
            {
                foreach (var result in results)
                {
                    error = result.ErrorMessage;
                    return null;
                };
            };

            // Movie name is unique
            var existing = GetByName(movie.Name);
            if (existing != null)
            {
                error = "Movie must be unique";
                return null;
            };

            error = null;
            return AddCore(movie);
        }

       
        public void Delete ( int id )
        {
            //TOOO : Validate Id >= 0

            DeleteCore(id);

        }

        //Use IEnumerable<T> for readonly lists of items
        //public Movie[] GetAll ()
        public IEnumerable<Movie> GetAll ()
        {
            return GetAllCore();
        }

        public Movie Get ( int id )
        {
            //TOOO: id >= 0

            return GetByIdCore(id);
        }
        public string Update ( int id, Movie movie )
        {
            //TOOO: id >= 0
            //TOOO: Movie is not null

            //Movie is valid
            var results = new ObjectValidator().TryValidateFullObject(movie);
            if (results.Count() > 0)
            {
                foreach (var result in results)
                {
                    return result.ErrorMessage;
                   
                };
            };

            // Movie name is unique
            var existing = GetByName(movie.Name);
            if (existing != null && existing.Id != id)
                 return  "Movie must be unique";

             UpdateCore(id, movie);
           
              return "";
        }
        protected abstract Movie AddCore ( Movie movie );

        protected abstract void DeleteCore ( int id );

        protected virtual Movie GetByName ( string name )
        {
            foreach (var movie in GetAll())
            {
                if (String.Compare(movie.Name, name, true) == 0)
                    return movie;
            };

            return null;
        }

        protected abstract IEnumerable<Movie> GetAllCore ();

        protected abstract Movie GetByIdCore ( int id );

        protected abstract void UpdateCore ( int id, Movie movie );
    }
}
