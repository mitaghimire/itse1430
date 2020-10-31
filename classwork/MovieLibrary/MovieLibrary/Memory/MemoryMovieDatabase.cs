using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary.Memory
{
    public class MemoryMovieDatabase : MovieDatabase  
    {
        
        //public Movie Add ( Movie movie, out string error )
        protected override Movie AddCore (Movie movie)
        {
          //Clone so argument can be modified without impacting our array
            var item = CloneMovie(movie);

            //Set a unique ID
            item.Id = _id++;

            //Add movie to array
            //_movies[index] = item;
            _movies.Add(item);

          //Set ID on original object and return
            movie.Id = item.Id;
            return movie;

        
        }

        protected override void DeleteCore ( int id )
        {
           

            var movie = FindById(id);
            if (movie != null)
            {
               
                _movies.Remove(movie);
            };

           
        }

        // public IEnumerable<Movie> GetAll ()
        protected override IEnumerable<Movie> GetAllCore ()
        {
            foreach (var movie in _movies)
                yield return CloneMovie(movie);
        }

        //public Movie Get ( int id )
        protected override Movie GetByIdCore ( int id )
        {
            var movie = FindById(id);


            return (movie != null) ? CloneMovie(movie) : null;
        }

        protected override Movie GetByName ( string name )
        {
            foreach (var movie in _movies)
            {
                if (String.Compare(movie.Name, name, true) == 0)
                    return CloneMovie(movie);
            };

            return null;
        }

        //public string Update ( int id, Movie movie )
        protected override void UpdateCore ( int id, Movie movie )
        {
            var existing = FindById(id);

            CopyMovie(existing, movie); 
        }
 
        private Movie CloneMovie ( Movie movie )
        {
            var item = new Movie();
            item.Id = movie.Id;

            CopyMovie(item, movie);

            return item;
        }

        private void CopyMovie ( Movie target, Movie source )
        {
            target.Name = source.Name;
            target.Rating = source.Rating;
            target.ReleaseYear = source.ReleaseYear;
            target.RunLength = source.RunLength;
            target.IsClassic = source.IsClassic;
            target.Description = source.Description;
        }

        private Movie FindById ( int id )
        {
            foreach (var movie in _movies)
            {

                if (movie?.Id == id)
                    return movie;
            };
            return null;
        }

        private List<Movie> _movies = new List<Movie>(); //Generic list of Movies, use for field
                    
        private int _id = 1;

        //Non-generic
        //  arrayList - list of objects
        // Generic Types
        // List<T> where T is any type
    }
}
