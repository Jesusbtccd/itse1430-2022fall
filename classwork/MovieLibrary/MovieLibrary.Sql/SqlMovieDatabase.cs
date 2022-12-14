using System.Data;
using System.Data.SqlClient;

namespace MovieLibrary.Sql
{
    public class SqlMovieDatabase : MovieDatabase
    {
        //private string _connectionString;

        public SqlMovieDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }
        protected override Movie AddCore ( Movie movie )
        {
            //Using statement
            // IDisposable
            using (var conn = OpenConnection())
            {
                //Create command option 2 - long way
                var cmd = new SqlCommand();
                cmd.CommandText = "AddMovie";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure; //CommandType.Text;

                //Add parameters option 1 - best way
                cmd.Parameters.AddWithValue("@name", movie.Title);

                //Add parameters option 2 - long way (or with type)
                var paramRating = new SqlParameter("@rating", movie.Rating);
                cmd.Parameters.Add(paramRating);

                //Add parameters option 3 - generic
                var paramDescription = cmd.CreateParameter();
                paramDescription.ParameterName = "@description";
                paramDescription.Value = movie.Description;
                paramDescription.DbType = DbType.String;
                cmd.Parameters.Add(paramDescription);

                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                //Execute command and get result
                object result = cmd.ExecuteScalar();
                //movie.Id = (int)result;
                movie.Id = Convert.ToInt32(result);

                return movie;
            };

            #region try-finally equivalent
            //SqlConnection conn = null;

            //try
            //{
            //    conn = OpenConnection();

            //    throw new NotImplementedException();
            //} finally
            //{
            //    //Clean up connection
            //    conn?.Close();
            //    conn?.Dispose();
            //};
            #endregion
        }

        protected override Movie FindByTitle ( string title )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("FindByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", title);

                //Read with streamed IO
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Movie() {
                            Id = (int)reader[0],              //Ordinal with cast
                            Title = reader["Name"] as string, //Column name with cast
                            Description = reader.IsDBNull(2) ? "" : reader.GetString(2),//Typed name with ordinal
                            Rating = reader.GetString("Rating"),
                            RunLength = reader.GetInt32("RunLength"), //Typed name with column
                            ReleaseYear = reader.GetFieldValue<int>("ReleaseYear"),
                            IsClassic = reader.GetFieldValue<bool>("IsClassic")
                        };
                    };
                };
            };

            return null;
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            var ds = new DataSet();

            using (var conn = OpenConnection())
            {
                //Create command 1 - using new
                var cmd = new SqlCommand("GetMovies", conn);

                //Need data adapter for Dataset
                var da = new SqlDataAdapter(cmd);

                //Buffered IO                
                da.Fill(ds);
            };

            //Data loaded, can work with it now
            // Find table and then enumerate rows to get data
            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
            {
                foreach (DataRow row in table.Rows.OfType<DataRow>())
                {
                    yield return new Movie() {
                        Id = (int)row[0],                   //Ordinal index with cast
                        Title = row["Name"] as string,      //Name with cast
                        Description = row.IsNull(2) ? "" : row.Field<string>(2), //Ordinal index with generic
                        Rating = row.Field<string>("Rating"), //Column with generic
                        RunLength = row.Field<int>("RunLength"),
                        ReleaseYear = row.Field<int>("ReleaseYear"),
                        IsClassic = row.Field<bool>("IsClassic"),
                    };
                };
            };
        }

        protected override Movie GetCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetMovie", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                //Read with streamed IO
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Movie() {
                            Id = (int)reader[0],              //Ordinal with cast
                            Title = reader["Name"] as string, //Column name with cast
                            Description = reader.IsDBNull(2) ? "" : reader.GetString(2),//Typed name with ordinal
                            Rating = reader.GetString("Rating"),
                            RunLength = reader.GetInt32("RunLength"), //Typped name with column
                            ReleaseYear = reader.GetFieldValue<int>("ReleaseYear"),
                            IsClassic = reader.GetFieldValue<bool>("IsClassic")
                        };
                    };
                };
            };

            return null;
        }

        protected override void RemoveCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                //Create command option 3 - generic
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DeleteMovie";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                //Set parameters
                cmd.Parameters.AddWithValue("@id", id);

                //Execute command 2 - no results/don't care
                cmd.ExecuteNonQuery();
            };
        }
        protected override void UpdateCore ( int id, Movie movie )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "UpdateMovie";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure; //CommandType.Text;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", movie.Title);
                cmd.Parameters.AddWithValue("@rating", movie.Rating);
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                //Execute command and get result
                cmd.ExecuteNonQuery();

                #region SQL Injection

                //movie.Title = "SELECT * FROM Movies WHERE Name = '';DELETE FROM Movies;SELECT * FROM MOvies WHERE Name = ''";
                //var cmd2 = new SqlCommand($"SELECT * FROM Movies WHERE Name = @title");
                //cmd2.Parameters.AddWithValue("@title", movie.Title); 

                #endregion
            };
        }

        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }

        private readonly string _connectionString;
    }
}

////using statement
////IDisposable
//using (var conn = OpenConnection())
//            {
//                throw new NotImplementedException();
//            };
//            //    SqlConnection conn = null;

//            //try
//            //{
//            //    conn = OpenConnection();

//            //    throw new NotImplementedException();
//            //} finally
//            //{
//            //    //clean up connection
//            //    conn?.Close();
//            //};
//        }
//        protected override Movie FindByTitle ( string title )
//        {
//            using (var conn = OpenConnection())
//            {
//                throw new NotImplementedException();
//            };
//            //var conn = OpenConnection();

//            ////clean up connection
//            //conn.Close();

//            ////find movie by Id
//            //return null;
//        }
//        protected override IEnumerable<Movie> GetAllCore ()
//        {
//            var ds = new DataSet();

//            using (var conn = OpenConnection())
//            {
//                //created command 1
//                var cmd = new SqlCommand("GetMovies", conn);

//                //need data adapter for dataset
//                var da = new SqlDataAdapter (cmd);

                
//                da.Fill(ds);
//            };

//            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
//            if (table != null)
//            {
//                foreach (DataRow row in table.Rows.OfType<DataRow>())
//                {
//                    yield return new Movie() {
//                        Id = (int)row[0],       //ordinal index with cast
//                        Title = row["Name"] as string,      //Name with cast
//                        Description = row.IsNull(2) ? "" : row.Field<string>(2),  //ordinal index
//                        Rating = row.Field<string>("Rating"),       //column with generic
//                        RunLength = row.Field<int>("RunLenght"),    //
//                        ReleaseYear = row.Field<int>("ReleaseYear"),
//                        IsClassic = row.Field<bool>("IsClassic"),

//                    };
//                }
//            }

            
//        }
//        protected override Movie GetCore ( int id )
//        {
//            using (var conn = OpenConnection())
//            {
//                throw (new NotImplementedException());
//            }
//            //conn.Close ();

//            ////Find movie by ID
//            //return null;
//        }
//        protected override void RemoveCore ( int id )
//        {
//            using (var conn = OpenConnection())
//            {
//                throw new NotImplementedException();
//            };
//        }



//protected override void UpdateCore ( int id, Movie movie ) => throw new NotImplementedException();

//        private SqlConnection OpenConnection ()
//        {
//            var conn = new SqlConnection(_connectionString);
//            conn.Open ();

//            return conn;
//        }
//    }
//}