﻿namespace MovieLibrary
{
    /// <summary>represents a movie.</summary>

    public class Movie
    {
        public int Id { get; private set; }
        public string Title
        {
            //string get_Title()
            get 
            { 
                return String.IsNullOrEmpty(_title ) ? "" : _title;
            }

            //void set_Title (string value)
            set { _title = String.IsNullOrEmpty(value) ? "" : value.Trim(); }
        }
        private string _title;

        //public string GetTitle ()
        //{
        //    return _title;
        //}
        //public void SetTitle ( string title )
        //{
        //    //this._title = title;
        //    _title = title;
        //}

        public string Description
        {
            get { return String.IsNullOrEmpty(_description) ? "" : _description; }
            set { _description = String.IsNullOrEmpty(value) ? "" : value.Trim(); }
        }
        private string _description;

        //public int RunLength
        //{
        //    get { return _runLength; }
        //    set { _runLength = value; }
        //}
        //private int _runLength = 0; //in minutes
        //Auto property
        public int RunLength { get; set; }


        //public int ReleaseYear
        //{
        //    get { return _releaseYear; }
        //    set { _releaseYear = value; }
        //}
        //private int _releaseYear = 1900;

        public int ReleaseYear { get; set; } = 1900;

        public string Rating
        {
            get { return String.IsNullOrEmpty(_rating) ? "" : _rating; }
            set { _rating = String.IsNullOrEmpty(value) ? "" : value.Trim(); }
        }
        private string _rating = "";


        public bool IsClassic {  get; set; }
        //public bool IsClassic
        //{
        //    get { return _isClassic; }
        //    set { _isClassic = value; }
        //}
        //private bool _isClassic = false;

        //public bool IsBlackAndWhite (){return _releaseYear < 1939;}

        public bool IsBlackAndWhite
        {
            get { return ReleaseYear < 1939; }
            //set {}
        }

        /// <summary>Clones the existing movie.</summary>
        /// <returns>A copy of the movie.</returns>
        public Movie Clone ()
        {
            var movie = new Movie();
            CopyTo(movie);

            return movie;
        }

        /// <summary>Copy the movie to another instance.</summary>
        /// <param name="movie">Movie to copy into.</param>
        public void CopyTo ( /* Movie this */ Movie movie )
        {
            //var areEqual = title == this.title;

            movie.Title = Title;
            movie.Description = Description; //this.description
            movie.RunLength = RunLength;
            movie.ReleaseYear = ReleaseYear;
            movie.Rating = Rating;
            movie.IsClassic = IsClassic;
        }
    }
}

////TODO:hide this


////public string _description = "";

//public int RunLength
//        { get { return _runLength; }
//            set { _runLength = value; }
//        }
//        private int Runlentgh = 0;


//        public int _runLength = 0; //in minutes
        
//        public int _releaseYear = 1900;
//        public string _rating = "";
//        public bool _isClassic = false;

//        public bool IsBlackAndWhite ()
//        {
//            return _releaseYear < 1939;
//        }

//        /// <summary>Clones the existing movie.</summary>
//        /// <returns>A copy of the movie.</returns>

//        public Movie Clone ()
//        {
//            var movie = new Movie();
//            CopyTo(movie);

//            return movie;

//            //CopyTo(movie);
//            //movie.title = title;
//            //movie.description = description;
//            //movie.runLength = runLength;
//            //movie.releaseYear = releaseYear;
//            //movie.rating = rating;
//            //movie.isClassic = isClassic;
//            //return movie;
//        }

//        /// <summary>Copy the movie to another instance.</summary>
//        /// <param name="movie">Movie to copy into.</param>

//        public void CopyTo ( Movie movie)
//        {
//           // var areEqual = title == this.title;


//            movie._title = _title;
//            movie._description = _description;
//            movie._runLength = _runLength;
//            movie._releaseYear = _releaseYear;
//            movie._rating = _rating;
//            movie._isClassic = _isClassic;
           
//        }

//    }
//}