/*
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace Nile.Stores.Sql
{
    /// <summary>Provides an implementation of <see cref="IProductDatabase"/> using SQL Server.</summary>
    public class SqlProductDatabase : ProductDatabase
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="SqlProductDatabase"/> class.</summary>
        public SqlProductDatabase ( string connectionString )
        {
            Verify.ArgumentIsNotNullOrEmpty(nameof(connectionString), connectionString);

            _connectionString = connectionString;
        }
        #endregion

        protected override Product AddCore ( Product product )
        {
            using (var conn = CreateConnection())
            {
                var cmd = CreateCommand(conn, "AddProduct");
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

                conn.Open();
                var id = Convert.ToInt32(cmd.ExecuteScalar());

                return GetCore(id);
            };
        }

        protected override IEnumerable<Product> GetAllCore ()
        {
            using (var conn = CreateConnection())
            {
                var cmd = CreateCommand(conn, "GetAllProducts");

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    var items = new List<Product>();
                    while (reader.Read())
                    {
                        items.Add(LoadProduct(reader));
                    };

                    return items;
                };
            };
        }

        protected override Product GetCore ( int id )
        {
            using (var conn = CreateConnection())
            {
                var cmd = CreateCommand(conn, "GetProduct");
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return LoadProduct(reader);
                };
            };

            return null;
        }

        protected override void RemoveCore ( int id )
        {
            using (var conn = CreateConnection())
            {
                var cmd = CreateCommand(conn, "RemoveProduct");
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            };
        }

        protected override Product UpdateCore ( Product existing, Product newItem )
        {
            using (var conn = CreateConnection())
            {
                var cmd = CreateCommand(conn, "UpdateProduct");
                cmd.Parameters.AddWithValue("@id", existing.Id);
                cmd.Parameters.AddWithValue("@name", newItem.Name);
                cmd.Parameters.AddWithValue("@description", newItem.Description);
                cmd.Parameters.AddWithValue("@price", newItem.Price);
                cmd.Parameters.AddWithValue("@isDiscontinued", newItem.IsDiscontinued);

                conn.Open();
                var id = Convert.ToInt32(cmd.ExecuteScalar());

                return GetCore(id);
            };
        }

        #region Private Members

        private SqlCommand CreateCommand ( SqlConnection connection, string commandText )
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            return cmd;
        }

        private SqlConnection CreateConnection () => new SqlConnection(_connectionString);        

        private Product LoadProduct ( DbDataReader reader )
        {
            return new Product()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Price = reader.GetDecimal(2),
                Description = reader.GetString(3),                
                IsDiscontinued = reader.GetBoolean(4)
            };
        }

        private readonly string _connectionString;
        #endregion
    }
}
