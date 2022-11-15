using System.Windows.Forms;

namespace MovieLibrary.WinHost
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var child = new MovieForm();

            do
            {

                //showing form modally
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;
                //child.Show();
                try
                {
                    _movies.Add(child.SelectedMovie);
                    UpdateUI();
                    return;

                } catch (InvalidOperationException ex)
                {
                    DisplayError("Movies must be unique.", "Add Failed");
                } catch (ArgumentException ex)
                {
                    DisplayError("You messed up developer.", "Add Failed");
                } catch (Exception ex)

                {
                    DisplayError(ex.Message, "Add Failed");

                    //rethrow
                    //throw ex;
                };
            } while (true);
        }
            
        //private Movie _movie;
        private IMovieDatabase _movies = new Memory.MemoryMovieDatabase();

        private void OnMovieDelete (object sender, EventArgs e)
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            if (!Confirm($"Are you sure you want to delete '{movie.Title}'?", "Delete"))
                return;

            //TODO: Implement
            //DisplayError("Not implemented yet", "Delete");
            _movies.Remove(movie.Id);
            UpdateUI();
        }

        protected override void OnFormClosing ( FormClosingEventArgs e )
        {
            base.OnFormClosing(e);

            if (Confirm("Are you sure you want to leave?", "Close"))
                return;

            e.Cancel = true;
        }

        protected override void OnFormClosed ( FormClosedEventArgs e )
        {
            base.OnFormClosed(e);

        }
        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            UpdateUI();
        }


        private void UpdateUI ()
        {

            var movies = _movies.GetAll();

            _lstMovies.Items.Clear();

            //Func<Movie, string> someFunc = OrderBytitle;
            //var someResult = someFunc = OrderByTitle;

            //var items = movies.OrderBy(OrderByTitle);
           // movies = movies.OrderBy(OrderByTitle);
            //movies = movies.ThenBy(OrderByReleaseYear);

            var items = movies.OrderBy(x => x.Title)
                              .ThenBy(x => x.ReleaseYear)
                              .ToArray();
            //_lstMovies.Items.AddRange(movies);
            //foreach (var movie in movies)
            //_lstMovies.Items.Add(movie);
            _lstMovies.Items.AddRange(items);
        }

        private string OderByTitle ( Movie movie) //Func<Movie, string>
        {
            return movie.Title;
        }
        private int OrderByReleaseYear (Movie movie ) 
        {
            return movie.ReleaseYear;
        }

        private Movie GetSelectedMovie()
        {
            return _lstMovies.SelectedItem as Movie;
        }

        private bool Confirm ( string message, string title)
        {
            DialogResult result = MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }
        private void DisplayError ( string message, string title)
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _miMovieDelete_Click ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            if (!Confirm("Are you sure you want to delete the movie?", "Delete"))
                return;

            _movies.Remove(movie.Id);
            UpdateUI();

            ////TODO :IMPLEMENT
            //DisplayError("Not implemented yet", "Delete");
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var child = new MovieForm();
            child.SelectedMovie = movie;

            do
            {
                //showing form modally
                if (child.ShowDialog() != DialogResult.OK)
                    return;
                //child.Show();
                //if (_movies.Update(movie.Id, child.SelectedMovie, out var error))
                try
                {
                    Cursor = Cursors.WaitCursor;
                    _movies.Update(movie.Id, child.SelectedMovie);
                    //System.Threading.Thread
                    //Cursor = Cursors.Default;

                    UpdateUI();
                    return;
                } catch (Exception ex)
                {
                    //Cursor = cursors.Default;
                    DisplayError(ex.Message, "Update Failed");
                }finally
                { 
                    //guaranteed to run
                    Cursor=Cursors.Default;
                };

                ////todo: Save this off
                //_movie = child.SelectedMovie;
                //UpdateUI();
            } while (true);
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutForm();

            about .ShowDialog();
        }
    }
}