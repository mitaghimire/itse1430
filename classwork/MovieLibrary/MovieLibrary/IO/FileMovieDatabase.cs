﻿/*
 * ITSE 1430
 * Class work
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MovieLibrary.IO
{
    /// <summary>Provides an implementation of <see cref="IMovieDatabase"/> using a file.</summary>
    public class FileMovieDatabase : MovieDatabase  
    {
        public FileMovieDatabase (string filename)
        {
            _filename = filename;
        }

        private readonly string _filename;
        //public Movie Add ( Movie movie, out string error )
        /// <inheritdoc/>
        protected override Movie AddCore (Movie movie)
        {
            //Find highest ID
            var movies = GetAllCore();

            //movies.Count() - count of items
            // .Any() => true if there are any items in set or false otherwise
            // .Max() -> returns largest item but crashes if set is empty
            var lastId = movies.Any() ? movies.Max(x => x.Id) : 0;

            ////HACK: To list 
            //var items = new List<Movie>(movies);

            //var lastId = 0;
            //foreach(var item in movies)
            //{
            //    if (item.Id > lastId)
            //        lastId = item.Id;
            //};

            //Set a unique ID
            movie.Id = ++lastId;

            //Add a new item to the existing IEnumerable
            movies = movies.Union(new[] { movie });
           // items.Add(movie);

            SaveMovies(movies);
            return movie;
            
        }

        protected override void DeleteCore ( int id )
        {
            //Streaming approach
            //Stream stream = File.OpenRead(_filename); //Opens a files for reading
            //StreamWriter writer = null;
            var tempFilename = _filename + ".bak";

            //Open original file for reading
            //Open temp files for writing
            //Stream original file to temp file, excluding deleted movie

            //Using statement file for reading
            // Using (E) S
            // IDisposable is the interface that identifies a types as needing explicit cleanup
            // void Dispose()

            //Open orginal file for reading
            using (Stream stream = File.OpenRead(_filename))
            using (var reader = new StreamReader(stream))
            {
                //stream.Dispose();

                //Open temp files for writing - overwrite any existing file
                using (var writer = new StreamWriter(tempFilename, false)) 
                {
                    //Keep reading until end of stream 
                    while (!reader.EndOfStream)
                    {
                        //Read movie
                        var line = reader.ReadLine();
                        var movie = LoadMovie(line);

                        //If not the movie we're looking for, write out line to temp file
                        if (movie?.Id == id)
                            writer .WriteLine(line);
                    };
                }; //writer.Close()
            }; // stream.Close(), reader.Close()

            //try
            //} finally
            //{
            //    writer?.Close();

            //    //Guaranteed to be called whether code completes or not 
            //    stream.Close();
            //};

            //Swap temp file with original file
            File.Copy(tempFilename, _filename, true);
            File.Delete(tempFilename);

            //Buffered approach
            //var movies = new List<Movie>(GetAllCore());
            //foreach (var movie in movies)
            //{
            //    if (movie.Id == id)
            //    {
            //        movies.Remove(movie);
            //        break;
            //    };
            //};

            //SaveMovies(movies);  
        }

        // public IEnumerable<Movie> GetAll ()
        protected override IEnumerable<Movie> GetAllCore ()
        {
            if (File.Exists(_filename))
            {
                //Read file buffered as an array
                //string[] lines = File.ReadAllLines(_filename);
                ////string rawText = File.ReadAllText(_filename);

                //foreach (var line in lines)
                //{
                //    var movie = LoadMovie(line);
                //    if (movie != null)
                //        yield return movie;
                //};
                // LINQ extension methods
                //var movies = File.ReadAllLines(_filename)
                //                  .Select(x => LoadMovie(x));

                

                // LINQ syntax
                var movies = from line in File.ReadAllLines(_filename)
                             where !String.IsNullOrEmpty(line)
                             //orderby member, member
                             select LoadMovie(line);

                foreach (var movie in movies)
                  yield return movie;
            };
        }

        //public Movie Get ( int id )
        protected override Movie GetByIdCore ( int id )
        {
            return FindById(id);
        }

        protected override Movie GetByName ( string name )
        {
            var movies = GetAllCore();
            foreach (var movie in movies)
            { 
                //Static method
                if (String.Compare(movie.Name, name, true) == 0)
                    return movie;
            };

            return null;
        }

        //public string Update ( int id, Movie movie )
        protected override void UpdateCore ( int id, Movie movie )
        {
            //Remove old movie
            //var items = new List<Movie>(GetAllCore());
            //foreach (var item in items)
            //{
            //    //Use item not movie
            //    if (item.Id == id)
            //    {
            //        //must use item here, not movie 
            //        items.Remove(item);
            //        break;
            //    };
            //};

            //movie.Id = id;
            //items.Add(movie);
            var items = GetAllCore();
            var existing = items.FirstOrDefault(x => x.Id == id);
            if (existing != null)
            {
                //Exclude the existing movie
                movie.Id = id;
                items =  items.Except(new[] { existing })
                              .Union(new[] { movie });
              SaveMovies(items);
            };
        }
 
        private Movie FindById ( int id )
        {
            //Streaming approach
            Stream stream = File.OpenRead(_filename);
            try
            {

                // Opens a file for reading
                //OpenWriting(filename) //Opens a file for writing 
                //OpenText(filename) //Opens a text file for reading

                //Stream = series of data (binary = byte, text = character)
                // May be read, write or seek(CanRead, CanWrite, CanSeek)
                // stream.Read() Low level

                //Use reader/writer for working with stream, provides a cleaner API
                StreamReader reader = new StreamReader(stream); //Reads text streams
                                                                //BinaryReader reader; //For binary files

                //Keep reading until end of stream or find movie
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    var movie = LoadMovie(line);
                    if (movie?.Id == id)
                        return movie;
                };

                return null;

                //Not exception safe
                //stream.Close();
                //Catch blocks here

            }
            finally
            {
                //Exception safe
                //Guaranteed to be called whether code completes or not 
                stream.Close();
            };

            //Buffered approach
            //var movies = GetAllCore();
            //foreach (var movie in movies)
            //{

            //    if (movie?.Id == id)
            //        return movie;
            //};
        }

        private Movie LoadMovie (string line)
        {
            //Note : No commas in string values

            //Id, "Name", "Description" , "Rating", RunLength, ReleaseYear, IsClassic

            string[] tokens = line.Split(',');
            if (tokens.Length != 7)
                return null;

            var movie = new Movie() {
                Id = Int32.Parse(tokens[0]),
                Name = tokens[1],
                Description = tokens[2],
                Rating = RemoveQuotes(tokens[3]),
                RunLength = Int32.Parse(tokens[4]),
                ReleaseYear = Int32.Parse(tokens[5]),
                IsClassic = Int32.Parse(tokens[6]) != 0
            };

            return movie;
        }

        private string EncloseQuotes ( string value)
        {
            return "\"" + value + "\"";
        }


        private string RemoveQuotes ( string value)
        {
            return value.Trim('"');
        }

        private void SaveMovies ( IEnumerable<Movie> movies)
        {
            //Buffered writing
            var lines = new List<string>();
            foreach (var movie in movies)
                lines.Add(SaveMovies(movie));

            File.WriteAllLines(_filename, lines);
        }

        private string SaveMovies ( Movie movie )
        {
            //Note : No commas in string values

            //Id, "Name", "Description" , "Rating", RunLength, ReleaseYear, IsClassic
            var builder = new System.Text.StringBuilder();

            builder.AppendFormat($"{movie.Id},");
            builder.AppendFormat($"{EncloseQuotes(movie.Name)},");
            builder.AppendFormat($"{EncloseQuotes(movie.Description)},");
            builder.AppendFormat($"{EncloseQuotes(movie.Rating)},");
            builder.AppendFormat($"{movie.RunLength},");
            builder.AppendFormat($"{movie.ReleaseYear},");
            builder.AppendFormat($"{(movie.IsClassic ? 1 : 0)}");

            return builder.ToString();
        }
        

       //File class -  used to manage files
       // Copy
       // Move
       // Exists
       // Open for reading and writing
    }
}
