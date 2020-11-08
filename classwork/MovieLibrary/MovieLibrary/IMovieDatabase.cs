using System;
using System.Collections.Generic;

namespace MovieLibrary
{
    //Interface
    //  interface- declaration :: = [acess] interface identifier { interface - member* ]
    // interface-member :: = property | method | event
    // 1. No acess modifiers (always public)
    // 2. No implementation of anythings
    // Cannot instantiate an interface

    //common interfaces
    //IEnumerable<T>, IEnumerator<T>
    // IList<T>, IReadOnlyList<T>
    //IComparer<T> = relational comparison, StringComparsion
    //ICloneable<T> - clone object , but doesn't actually work
    //IValidatableObject - validates objects 
    public interface IMovieDatabase
    {
        /// <summary>Add a movie to  the database.</summary>
        /// <param name="movie"> The movie to add. </param>
        /// <returns>The new movie.</returns>
        /// <exception cref="ArgumentNullException"></paramref name = "movie"/> is null.</exception>
        /// <exception cref="InvalidOperationException">A movie with the same name already exists.</exception
        /// exception cref ="InvalidOperationException"> A movie with the same name already exists.</exception
        /// error: Movie is invalid
        /// error: Movie already exists
        Movie Add ( Movie movie );

        /// <summary>Delets a movie from the database.</summary>
        /// <param name="id"> The movie to delet.</param>
        /// error: Id is less than Zero.
        void Delete ( int id );

        /// <summary>Gets a movie from the database.</summary>
        /// <param name="id">The movie to retrieve.</param>
        /// error: Id is less than zero.
        Movie Get ( int id );

        /// <summary>Updates an existing movie in the database.</summary>
        /// <param name="id">The movie to update.</param>
        /// <param name="movie">The movie details.</param>
        /// error : Id is less than zero.
        /// error : Movie does not exist.
        /// error : Movie is not valid.
        /// error : Movie name already exists.
        IEnumerable<Movie>GetAll ();
        void Update ( int id, Movie movie );
    }
}