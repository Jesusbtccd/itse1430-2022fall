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
            if (child.ShowDialog() != DialogResult.OK)  //showing form modally
                return;
            //child.Show();

            //todo: Save this off
            var movie = child.SelectedMovie;
            
        }

        private bool Confirm ( string message, string title)
        {
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }
        private void DisplayError ( string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _miMovieDelete_Click ( object sender, EventArgs e )
        {
            if (!Confirm("Are you sure you want to delete the movie?", "Delete"))
                return;

            //TODO :IMPLEMENT
            DisplayError("Not implemented yet", "Delete");
        }
    }
}