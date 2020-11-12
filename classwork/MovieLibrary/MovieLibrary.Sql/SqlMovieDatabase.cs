using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MovieLibrary.Sql
{
    /// <summary>Provides an implementation of <see cref="IMovieDatabase"/> using a SQL Server database.</summary>
    /// 
    
    public class SqlMovieDatabase : MovieDatabase
    {
        //ADO.NET
        //  Provider specific types:  (Provider)- 
        //     System.Data.(Provider)Client
      
        // Connection ::= Logical connection to a database 
        // Command ::= Represents action to take (DML - data manipulation lang) (vs DDL - data definition lang)
        // -DataReader ::= Reads data as a stream
        // DataAdapter ::= Reads data as a buffer
        // Transaction ::= Multiple commands
        public SqlMovieDatabase ( string connectionString )
        {
            //Shoould probably validate this .......
            _connectionString = connectionString;
        }
        //Make readonly as it is only set in constructor
        private readonly string _connectionString;


        protected override Movie AddCore ( Movie movie )
        {
            //throw new NotImplementedException();
            using (var connection = OpenConnection())
            {
                //Provider-agnostic way to create command
                var command = connection.CreateCommand();
                command.CommandText = "AddMovie";

                //Add parameters
                //   1. Create parameter and add manually
                var parmName = new SqlParameter("@name", movie.Name);
                command.Parameters.Add(parmName);
                command.CommandType = CommandType.StoredProcedure;

                //   2. Create parameter using command
                var parmDescription = command.CreateParameter();
                parmDescription.ParameterName = "@description";
                parmDescription.Value = movie.Description;
                parmDescription.SqlDbType = SqlDbType.NVarChar;
                command.Parameters.Add(parmDescription);

                //   3. (SQL Server) AddWithValue (PREFERRED when SQL)
                command.Parameters.AddWithValue("@rating", movie.Rating);
                command.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                command.Parameters.AddWithValue("@runLength", movie.RunLength);
                command.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                // Execute command
                //  ExecuteNonQuery ::= Returns (or don't care about) nothing - DELETE, UPDATE
                //  ExecuteScalar   ::= Returns the first value of the first row, if any - INSERT
                //  ExecuteReader   ::= Returns results (streaming)
                object result = command.ExecuteScalar();
                var id = Convert.ToInt32(result);

                //Finish out method
                movie.Id = id;
                return movie;
            };

        }

        //public void Delete(int id)
        protected override void DeleteCore ( int id )
        {
            using (var connection = OpenConnection())
            {
                //Provider-agnostic way to create command
                var command = connection.CreateCommand();
                command.CommandText = "DeleteMovie";
                command.CommandType = CommandType.StoredProcedure;

                //Add parameters
                command.Parameters.AddWithValue("@id", id);

                // Execute command
                //  ExecuteNonQuery ::= Returns (or don't care about) nothing - DELETE, UPDATE
                //  ExecuteScalar   ::= Returns the first value of the first row, if any - INSERT
                //  ExecuteReader   ::= Returns results (streaming)
                command.ExecuteNonQuery();
            };
        }

        // public IEnumerable<Movie> GetAll ()
        protected override IEnumerable<Movie> GetAllCore ()
        {
            var ds = new DataSet();

            //IDisposable so always wrap in a using
            using (var connection = OpenConnection())
            {
                //Provider-specific way
                //Note: IDisposable but no existing implementation needs it
                var command = new SqlCommand("GetMovies", connection);
                command.CommandType = CommandType.StoredProcedure;

                //Execute the command - using the buffered approach                
                var da = new SqlDataAdapter() {
                    SelectCommand = command
                };

                //Retrieve data (buffered)
                da.Fill(ds);
            };

            //Get table, if any
            var table = ds.Tables.Count > 0 ? ds.Tables[0] : null;
            if (table != null)
            {
                //Enumerate the rows
                // Convert IEnumerable to IEnuemable<DataRow> using OfType<>
                //     foreach (var item in table.Rows) { if (item is DataRow row) yield return row }
                foreach (var row in table.Rows.OfType<DataRow>())
                {
                    //Access fields
                    // Get specific column
                    //   # - by ordinal (0 based index)
                    //   name - by column name
                    // Get typed value
                    //   Convert.ToInt32(row[#]) ::= Object to Int32
                    //   row[].ToString() ::= To a string [PREFERRED]
                    yield return new Movie() {
                        Id = Convert.ToInt32(row[0]),
                        Name = row["name"].ToString(),

                        Description = row.Field<string>("description"),
                        Rating = row.Field<string>("Rating"),

                        ReleaseYear = row.Field<int>("ReleaseYear"),
                        RunLength = row.Field<int>("RunLength"),
                        IsClassic = row.Field<bool>("IsClassic"),
                    };
                };
            };
        }





        //public Movie Get ( int id )
        protected override Movie GetByIdCore ( int id )
        {
            using (var connection = OpenConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetMovie";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", id);

                //Stream data using reader
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var movieId = reader.GetInt32(0);
                        if (movieId == id)
                        {
                            //Read using either 
                            //  Get(Primitive)
                            //  GetFieldValue<T>
                            // WARNING:
                            //   Use ordinal - string column names require extra code
                            //   **Boolean doesn't work
                            //   **Null doesn't work
                            //var ordinal = reader.GetOrdinal("Name");
                            //reader.GetString(ordinal);

                            return new Movie() {
                                Id = movieId,
                                Name = reader.GetString(1),
                                Description = reader.GetString(2),
                                Rating = reader.GetFieldValue<string>(3),
                                ReleaseYear = reader.GetFieldValue<int>(4),
                                RunLength = reader.GetFieldValue<int>(5),
                                IsClassic = reader.GetFieldValue<bool>(6)
                            };
                        };
                    };
                };
            };

            return null;
        }

        protected override Movie GetByName ( string name )
        {
            var movies = GetAllCore();
            foreach (var movie in movies)
            {
                if (String.Compare(movie.Name, name, true) == 0)
                    return movie;
            };

            return null;
        }

        //public string Update ( int id, Movie movie )
        protected override void UpdateCore ( int id, Movie movie )
        {

            using (var connection = OpenConnection())
            {
                //Provider-agnostic way to create command
                var command = connection.CreateCommand();
                command.CommandText = "UpdateMovie";
                command.CommandType = CommandType.StoredProcedure;

                //Add parameters
                //   1. Create parameter and add manually
                var parmName = new SqlParameter("@name", movie.Name);
                command.Parameters.Add(parmName);

                //   2. Create parameter using command
                var parmDescription = command.CreateParameter();
                parmDescription.ParameterName = "@description";
                parmDescription.Value = movie.Description;
                parmDescription.SqlDbType = SqlDbType.NVarChar;
                command.Parameters.Add(parmDescription);

                //   3. (SQL Server) AddWithValue (PREFERRED when SQL)
                command.Parameters.AddWithValue("@rating", movie.Rating);
                command.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                command.Parameters.AddWithValue("@runLength", movie.RunLength);
                command.Parameters.AddWithValue("@isClassic", movie.IsClassic);
                command.Parameters.AddWithValue("@id", id);

                // Execute command
                //  ExecuteNonQuery ::= Returns (or don't care about) nothing - DELETE, UPDATE
                //  ExecuteScalar   ::= Returns the first value of the first row, if any - INSERT
                //  ExecuteReader   ::= Returns results (streaming)
                command.ExecuteNonQuery();
            };
        }



        private SqlConnection OpenConnection ()
        {
            //Connect to database using connection string
            var conn = new SqlConnection(_connectionString);


            //SqlException if something goes wrong
            conn.Open();
            return conn;
        }

       
       
    }
}
