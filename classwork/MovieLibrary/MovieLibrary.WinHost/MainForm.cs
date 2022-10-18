using System.Windows.Forms;

namespace MovieLibrary.WinHost
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void OnMovieAdd (object sender, EventArgs e)
        {
            var child = new MovieForm();

            //showing form modally
            if (child.ShowDialog(this) != DialogResult.OK)  
                return;
            //child.Show();

            //todo: Save this off
            _movie = child.SelectedMovie;
            UpdateUI();
            
        }

        private Movie _movie;

        private void OnMovieDelete (object sender, EventArgs e)
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            if (!Confirm($"Are you sure you want to delete '{movie.Title}'?", "Delete"))
                return;

            //TODO: Implement
            //DisplayError("Not implemented yet", "Delete");
            _movie = null;
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

        private void UpdateUI ()
        {
            _lstMovies.Items.Clear();
            if (_movie != null)
            {
                _lstMovies.Items.Add(_movie);
            };
        }

        private Movie GetSelectedMovie()
        {
            return _movie;
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
            if (!Confirm("Are you sure you want to delete the movie?", "Delete"))
                return;

            //TODO :IMPLEMENT
            DisplayError("Not implemented yet", "Delete");
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;
            var child = new MovieForm();
            child.SelectedMovie = movie;

            //showing form modally
            if (child.ShowDialog() != DialogResult.OK)
                return;
            //child.Show();

            //todo: Save this off
            _movie = child.SelectedMovie;
            UpdateUI();
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