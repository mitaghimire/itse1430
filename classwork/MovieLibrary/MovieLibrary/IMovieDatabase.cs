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
        Movie Add ( Movie movie, out string error );
        void Delete ( int id );
        Movie Get ( int id );
       IEnumerable<Movie>GetAll ();
        string Update ( int id, Movie movie );
    }
}