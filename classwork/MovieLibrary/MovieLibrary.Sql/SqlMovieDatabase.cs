using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MovieLibrary.Sql
{
    /// <summary>Provides an implementation of <see cref="IMovieDatabase"/> using a SQL Server database.</summary>
    /// 
    ///
    public class SqlMovieDatabase : MovieDatabase  
    {
        public SqlMovieDatabase ( string connectionString )
        {
            //Shoould probably validate this .......
            _connectionString = connectionString;
        }
        //Make readonly as it is only set in constructor
        private readonly string _connectionString;


        protected override Movie AddCore (Movie movie)
        {
            throw new NotImplementedException();
        }
        
        //public void Delete(int id)
        protected override void DeleteCore ( int id )
        { 
            throw new NotImplementedException();
        }

        // public IEnumerable<Movie> GetAll ()
        protected override IEnumerable<Movie> GetAllCore ()
        {
            using (var connection = new SqlConnection ( _connectionString))
            {
                connection.Open();
            };
            return Enumerable.Empty<Movie>();
        }

        //public Movie Get ( int id )
        protected override Movie GetByIdCore ( int id )
        {
            throw new NotImplementedException();
        }

        protected override Movie GetByName ( string name )
        {
            throw new NotImplementedException();
        }

        //public string Update ( int id, Movie movie )
        protected override void UpdateCore ( int id, Movie movie )
        {
            throw new NotImplementedException();
        }
 

        private Movie FindById ( int id )
        {
            throw new NotImplementedException();
        }

       
    }
}
