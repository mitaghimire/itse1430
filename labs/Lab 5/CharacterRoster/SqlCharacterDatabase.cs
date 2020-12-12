using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRoster
{
    class SqlCharacterDatabase
    {

        //ADO.NET
        //  Provider specific types:  (Provider)- 
        //     System.Data.(Provider)Client

        // Connection ::= Logical connection to a database 
        // Command ::= Represents action to take (DML - data manipulation lang) (vs DDL - data definition lang)
        // -DataReader ::= Reads data as a stream
        // DataAdapter ::= Reads data as a buffer
        // Transaction ::= Multiple commands
        public SqlCharacterDatabase ( string connectionString )
        {
            //Shoould probably validate this .......
            _connectionString = connectionString;
        }
        //Make readonly as it is only set in constructor
        private readonly string _connectionString;


        protected override CharacterRoster AddCore ( CharacterRoster character )
        {
            //throw new NotImplementedException();
            using (var connection = OpenConnection())
            {
                //Provider-agnostic way to create command
                var command = connection.CreateCommand();
                command.CommandText = "AddProduct";

                //Add parameters
                //   1. Create parameter and add manually
                var parmName = new SqlParameter("@name", character.Name);
                command.Parameters.Add(parmName);
                command.CommandType = CommandType.StoredProcedure;

                //   2. Create parameter using command
                var parmDescription = command.CreateParameter();
                parmDescription.ParameterName = "@description";
                parmDescription.Value = character.Description;
                parmDescription.SqlDbType = SqlDbType.NVarChar;
                command.Parameters.Add(parmDescription);

                //   3. (SQL Server) AddWithValue (PREFERRED when SQL)
                command.Parameters.AddWithValue("@price", character.Price);
                command.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);
                // Execute command
                //  ExecuteNonQuery ::= Returns (or don't care about) nothing - DELETE, UPDATE
                //  ExecuteScalar   ::= Returns the first value of the first row, if any - INSERT
                //  ExecuteReader   ::= Returns results (streaming)
                object result = command.ExecuteScalar();
                var id = Convert.ToInt32(result);

                //Finish out method
                product.Id = id;
                return product;
            };

        }

        //public void Delete(int id)
        protected override void RemoveCore ( int id )
        {
            using (var connection = OpenConnection())
            {
                //Provider-agnostic way to create command
                var command = connection.CreateCommand();
                command.CommandText = "[RemoveProduct]";
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
        protected override IEnumerable<Product> GetAllCore ()
        {
            var ds = new DataSet();

            //IDisposable so always wrap in a using
            using (var connection = OpenConnection())
            {
                //Provider-specific way
                //Note: IDisposable but no existing implementation needs it
                var command = new SqlCommand("GetAllProducts", connection);
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
                    yield return new Product() {
                        Id = Convert.ToInt32(row[0]),
                        Name = row["name"].ToString(),

                        Description = row.Field<string>("description"),
                        Price = row.Field<decimal>("price"),
                        IsDiscontinued = row.Field<bool>("isdiscontinued"),
                    };
                };
            };
        }





        //public  Get ( int id )
        protected override Product GetCore ( int id )
        {
            using (var connection = OpenConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetProduct";
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

                            return new Product() {
                                Id = movieId,
                                Name = reader.GetString(1),
                                Description = reader.GetString(3),
                                Price = reader.GetFieldValue<decimal>(2),
                                IsDiscontinued = reader.GetFieldValue<bool>(4)
                            };
                        };
                    };
                };
            };

            return null;
        }

        protected Product FindbyId ( int id )
        {
            var products = GetAllCore();
            foreach (var product in products)
            {
                if (product.Id == id)
                    return product;
            };

            return null;
        }

        //public string Update ( int id, Movie movie )
        protected override Product UpdateCore ( Product existing, Product newItem )
        {

            using (var connection = OpenConnection())
            {
                //Provider-agnostic way to create command
                var command = connection.CreateCommand();
                command.CommandText = "UpdateProduct";
                command.CommandType = CommandType.StoredProcedure;

                //Add parameters
                //   1. Create parameter and add manually
                var parmName = new SqlParameter("@name", newItem.Name);
                command.Parameters.Add(parmName);

                //   2. Create parameter using command
                var parmDescription = command.CreateParameter();
                parmDescription.ParameterName = "@description";
                parmDescription.Value = newItem.Description;
                parmDescription.SqlDbType = SqlDbType.NVarChar;
                command.Parameters.Add(parmDescription);

                //   3. (SQL Server) AddWithValue (PREFERRED when SQL)
                command.Parameters.AddWithValue("@price", newItem.Price);
                command.Parameters.AddWithValue("@isDiscontinued", newItem.IsDiscontinued);
                command.Parameters.AddWithValue("@id", existing.Id);

                // Execute command
                //  ExecuteNonQuery ::= Returns (or don't care about) nothing - DELETE, UPDATE
                //  ExecuteScalar   ::= Returns the first value of the first row, if any - INSERT
                //  ExecuteReader   ::= Returns results (streaming)
                command.ExecuteNonQuery();
            };

            return newItem;
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
