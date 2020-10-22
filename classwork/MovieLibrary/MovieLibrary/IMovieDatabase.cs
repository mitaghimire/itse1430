using System;
namespace MovieLibrary
{
    //Interface
    //  interface- declaration :: = [acess] interface identifier { interface - member* ]
    // interface-member :: = property | method | event
    // 1. No acess modifiers (always public)
    // 2. No implementation of anythings
    // Cannot instantiate an interface
    public interface IMovieDatabase
    {
        Movie Add ( Movie movie, out string error );
        void Delete ( int id );
        Movie Get ( int id );
        Movie[] GetAll ();
        string Update ( int id, Movie movie );
    }
}