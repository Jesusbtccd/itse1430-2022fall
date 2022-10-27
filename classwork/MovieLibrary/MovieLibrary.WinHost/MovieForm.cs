using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLibrary.WinHost
{
    public partial class MovieForm : Form
    {
        public MovieForm ()
        {
            InitializeComponent();
        }

        public Movie SelectedMovie { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);


            //Do any init just before UI is renderd
            if (SelectedMovie != null)
            {
                //Load Ui
                _txtTitle.Text = SelectedMovie.Title;
                _txtDescription.Text = SelectedMovie.Description;
                _cbRating.Text = SelectedMovie.Rating;

                _chkIsClassic.Checked = SelectedMovie.IsClassic;
                _txtRunLength.Text = SelectedMovie.RunLength.ToString();
                _txtReleaseYear.Text = SelectedMovie.ReleaseYear.ToString();
            };

            //force validation
            ValidateChildren();
        }

        private void OnSave ( object sender, EventArgs e )
        {
            //FormClosedEventArgs validation of children
            if (!ValidateChildren())
                return;

            var btn = sender as Button;

            //todo : add validation
            var movie = new Movie();
            movie.Title = _txtTitle.Text;
            movie.Description = _txtDescription.Text;
            movie.Rating = _cbRating.Text;

            movie.IsClassic = _chkIsClassic.Checked;
            movie.RunLength = GetInt32(_txtRunLength);
            movie.ReleaseYear = GetInt32(_txtReleaseYear);

            if (!new ObjectValidator().IsValid(movie, (out var error))
            {
                DisplayError(error, "Save");
                return;
            };
            //// if (movie.Rating.Length == 0)
            // {
            //     DisplayError("Rating is required", "Save");
            //     return;
            // };
            // //if (movie.RunLength < 0)
            // {
            //     DisplayError("Run Length must be >= 0", "Save");
            //     return;
            // };
            // //if (movie.ReleaseYear < 1900)
            // {
            //     DisplayError("Release Year must be >= 1900", "Save");
            //     return;
            // };
            //get rid of from
            //setting forms dialogresult to a reasonable value
            // call Close()
            SelectedMovie = movie;
            DialogResult = DialogResult.OK;
            Close();

        }

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int GetInt32 ( TextBox control )
        {
            if (Int32.TryParse(control.Text, out var result))
                return result;

            return -1;
        }

        private void label5_Click ( object sender, EventArgs e )
        {

        }

        private void OnValidateTitle ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                //not valid
                _errors.SetError(control, "Title is required");
                e.Cancel = true;
            } else
            {
                //valid
                _errors.SetError(control, "");
            };
        }



        private void OnValidateRating ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var control = sender as ComboBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                //not valid
                _errors.SetError(control, "Title is required");
                e.Cancel = true;
            } else
            {
                //valid
                _errors.SetError(control, "");
            };
        }

        private void OnValidateRunLength ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var control = sender as TextBox;

            var value = GetInt32(control);
            if (value < 0)
            {
                //not valid
                _errors.SetError(control, "Run length must be >= 0");
                e.Cancel = true;
            } else
            {
                //valid
                _errors.SetError(control, "");
            };
        }

        private void OnValidateReleaseYear ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var control = sender as TextBox;

            var value = GetInt32(control);
            if (value < 1900)
            {
                //not valid
                _errors.SetError(control, "Release Year must be at least 1900");
                e.Cancel = true;
            } else
            {
                //valid
                _errors.SetError(control, "");
            };
        }
    }

}


