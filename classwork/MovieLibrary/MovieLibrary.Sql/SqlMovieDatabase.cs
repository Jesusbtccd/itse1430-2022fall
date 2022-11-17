using System.Data;
using System.Data.SqlClient;

namespace MovieLibrary.Sql
{
    public class SqlMovieDatabase : MovieDatabase
    {
        private string _connectionString;

        public SqlMovieDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }
        protected override Movie AddCore ( Movie movie )
        {

            //using statement
            //IDisposable
            using (var conn = OpenConnection())
            {
                throw new NotImplementedException();
            };
            //    SqlConnection conn = null;

            //try
            //{
            //    conn = OpenConnection();

            //    throw new NotImplementedException();
            //} finally
            //{
            //    //clean up connection
            //    conn?.Close();
            //};
        }
        protected override Movie FindByTitle ( string title )
        {
            using (var conn = OpenConnection())
            {
                throw new NotImplementedException();
            };
            //var conn = OpenConnection();

            ////clean up connection
            //conn.Close();

            ////find movie by Id
            //return null;
        }
        protected override IEnumerable<Movie> GetAllCore ()
        {
            var ds = new DataSet();

            using (var conn = OpenConnection())
            {
                //created command 1
                var cmd = new SqlCommand("GetMovies", conn);

                //need data adapter for dataset
                var da = new SqlDataAdapter (cmd);

                
                da.Fill(ds);
            };

            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
            {
                foreach (DataRow row in table.Rows.OfType<DataRow>())
                {
                    yield return new Movie() {
                        Id = (int)row[0],       //ordinal index with cast
                        Title = row["Name"] as string,      //Name with cast
                        Description = row.IsNull(2) ? "" : row.Field<string>(2),  //ordinal index
                        Rating = row.Field<string>("Rating"),       //column with generic
                        RunLength = row.Field<int>("RunLenght"),    //
                        ReleaseYear = row.Field<int>("ReleaseYear"),
                        IsClassic = row.Field<bool>("IsClassic"),

                    };
                }
            }

            
        }
        protected override Movie GetCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                throw (new NotImplementedException());
            }
            //conn.Close ();

            ////Find movie by ID
            //return null;
        }
        protected override void RemoveCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                throw new NotImplementedException();
            };
        }



protected override void UpdateCore ( int id, Movie movie ) => throw new NotImplementedException();

        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open ();

            return conn;
        }
    }
}