﻿namespace MovieLibrary
{

  
    /// <summary>represents a movie.</summary>
   
    public class Movie
    {
        private string _title = "";

        public string GetTitle ()
        {
            return _title;
        }
        public void SetTitle ( string title )
        {
            //this._title = title;
            _title = title;
        }

        //TODO:hide this
        public string _description = "";
        public int _runLength = 0; //in minutes
        public int _releaseYear = 1900;
        public string _rating = "";
        public bool _isClassic = false;

        public bool IsBlackAndWhite ()
        {
            return _releaseYear < 1939;
        }

        /// <summary>Clones the existing movie.</summary>
        /// <returns>A copy of the movie.</returns>

        public Movie Clone ()
        {
            var movie = new Movie();
            CopyTo(movie);

            return movie;

            //CopyTo(movie);
            //movie.title = title;
            //movie.description = description;
            //movie.runLength = runLength;
            //movie.releaseYear = releaseYear;
            //movie.rating = rating;
            //movie.isClassic = isClassic;
            //return movie;
        }

        /// <summary>Copy the movie to another instance.</summary>
        /// <param name="movie">Movie to copy into.</param>

        public void CopyTo ( Movie movie)
        {
           // var areEqual = title == this.title;


            movie._title = _title;
            movie._description = _description;
            movie._runLength = _runLength;
            movie._releaseYear = _releaseYear;
            movie._rating = _rating;
            movie._isClassic = _isClassic;
           
        }

    }
}