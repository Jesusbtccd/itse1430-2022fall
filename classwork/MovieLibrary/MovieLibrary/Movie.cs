﻿/*
 * Name
 * Lab
 * Fall 2022
 */
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary
{
    /// <summary>Represents a movie.</summary>
    public class Movie : IValidatableObject
    {
        /// <summary>Represents a movie.</summary>
        public Movie () : this("", "")
        {
            //Initialize("", "");
        }

        //Constructor chaining
        // Allows for calling another constructor on same type
        // Eliminates the need for private initialize functions (dangerous)
        // Can chain indefinitely
        public Movie ( string title ) : this(title, "")
        {
            //Init that field initializers cannot do
            //Title = title;
            //Initialize(title, "");
        }

        public Movie ( string title, string description ) : base() //Object.ctor()
        {
            //Initialize(title, description);

            Title = title;
            Description = description;
        }

        //Don't do this
        //private void Initialize ( string title, string description )
        //{
        //    Title = title;
        //    Description = description;
        //}

        /// <summary>Gets the unique ID.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the title.</summary>
        public string Title
        {
            // string get_Title () 
            get 
            {
                //return String.IsNullOrEmpty(_title) ? "" : _title;
                return _title ?? "";
            }

            // void set_Title ( string value )
            //set { _title = String.IsNullOrEmpty(value) ? "" : value.Trim(); }
            set { _title = value?.Trim() ?? ""; }
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

        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            //get { return String.IsNullOrEmpty(_description) ? "" : _description; }
            get { return _description ?? ""; }
            //set { _description = String.IsNullOrEmpty(value) ? "" : value.Trim(); }
            set { _description = value?.Trim() ?? ""; }
        }
        private string _description;

        /// <summary>Gets or sets the run length in minutes.</summary>
        //public int RunLength
        //{
        //    get { return _runLength; }
        //    set { _runLength = value; }
        //}
        //private int _runLength = 0; //in minutes
        //Auto property
        public int RunLength { get; set; }

        /// <summary>Gets or sets the release year.</summary>
        /// <value>Default is 1900.</value>
        //public int ReleaseYear
        //{
        //    get { return _releaseYear; }
        //    set { _releaseYear = value; }
        //}
        //private int _releaseYear = 1900;
        public int ReleaseYear { get; set; } = 1900;

        /// <summary>Gets or sets the MPAA rating.</summary>
        public string Rating
        {
            //get { return String.IsNullOrEmpty(_rating) ? "" : _rating; }
            get { return _rating ?? ""; }
            //set { _rating = String.IsNullOrEmpty(value) ? "" : value.Trim(); }
            set { _rating = value?.Trim() ?? ""; }
        }
        private string _rating;

        /// <summary>Determines if the movie is a classic.</summary>
        public bool IsClassic { get; set; }

        /// <summary>Determines if the movie is black and white.</summary>
        //public bool IsBlackAndWhite () { return _releaseYear < 1939; }
        public bool IsBlackAndWhite
        {
            get { return ReleaseYear < YearColorWasIntroduced; }
            //set { }
        }

        //Public fields are allowed when they are constants
        public const int YearColorWasIntroduced = 1939;
        //public readonly Movie Empty = new Movie();

        //private Movie EmptyMovie { get; } = new Movie();
        //private readonly Movie _emptyMovie= new Movie();

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
            movie.Id = Id;
            movie.Title = Title;
            movie.Description = Description; //this.description
            movie.RunLength = RunLength;
            movie.ReleaseYear = ReleaseYear;
            movie.Rating = Rating;
            movie.IsClassic = IsClassic;

        }

        public bool Validate ( out string errorMessage )
        {
            if (Title.Length == 0)
            {
                errorMessage = "Title is required";
                return false;
            };
            if (Rating.Length == 0)
            {
                errorMessage = "Rating is required";
                return false;
            };
            if (RunLength < 0)
            {
                errorMessage = "Run Length must be >= 0";
                return false;
            };
            if (ReleaseYear < 1900)
            {
                errorMessage = "Release Year must be >= 1900";
                return false;
            };

            errorMessage = null;
            return true;
        }

        //Equals & GetHashCode
        //GetType
        public override string ToString ()
        {
            //ToString == this.toString();
            //var str = base.ToString();  //Calls base type impl
            return Title;
        }

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            var errors = new List<ValidationResult>();

            if (Title.Length == 0)
                errors.Add(new ValidationResult("Title is required", new[] { nameof(Title) } ));
            {
                errorMessage = "Title is required";
                return false;
            };
            if (Rating.Length == 0)
                errors.Add(new ValidationResult("Title is required", new[] { nameof(Rating) }));
            {
                errorMessage = "Rating is required";
                return false;
            };
            if (RunLength < 0)
                errors.Add(new ValidationResult("Title is required", new[] { nameof(RunLength) }));
            {
                errorMessage = "Run Length must be >= 0";
                return false;
            };
            if (ReleaseYear < 1900)
                errors.Add(new ValidationResult("Release ", new[] { nameof(ReleaseYear) }));
            {
                errorMessage = "Release Year must be >= 1900";
                return false;
            };

            errorMessage = null;
            return true;
        }
    }
       
    }
}


