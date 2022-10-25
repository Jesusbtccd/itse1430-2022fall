using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class MovieDatabase
    {
       
        public virtual Movie Add ( Movie movie, out string errorMessage)
        {
            //Array
            //Find first null element
            //If found then set to new movie
            //Else
            //Resize the array
            //Copy all existing elements over
            //
            if (movie == null)
            {
                errorMessage = "Movie cannot be null";
                return null;
            };
            if (!movie.Validate(out errorMessage))
                return null;

            var existing = FindByTitle(movie.Title);
            if (existing !=null)
            {
                errorMessage = "Movie must be unique";
                return null;
            };


            //Add
            movie.Id = _id++;
            _movies.Add(movie.Clone());

            errorMessage = null;
            return movie;


           
            return movie;
        }

        public Movie Get ( int id )
        {
            //if (_movie != null && _movie.Id == id)
            //    return _movie;
            //for (var index = 0; index < _movies.Length; ++index)
            foreach (var movie in _movies )
                if (movie?.Id == id)
                    return movie.Clone();   //Clone because of ref type
            return null;
        }

        /// <summary>Gets all the movies.</summary>
        /// <returns>The movies.</returns>
        public Movie[] GetAll ()
        {
            //TODO: Filter out null
            var items = new Movie[_movies.Count];
            //for (var index = 0; index < _movies.Length; ++index)
            //    items[index] = _movies[index]?.Clone();

            var index = 0;
            foreach (var movie in _movies)
                items[index++] = movie?.Clone();

            //Empty array
            //new Movie[0];

            return items;
        }

       
        public void Remove (int id)
        {
            //TODO; switch to foreach
            //enumerate array looking for each
            for (var index = 0; index < _movies.Count; ++index)
                if (_movies[index].Id == id)
                {
                    //_movies[index] = null;
                    _movies.RemoveAt(index);
                    return;
                };
        }

        public bool Update ( int id, Movie movie, out string errorMessage )
        {
            if (movie == null)
            {
                errorMessage = "Movie cannot be null";
                return false;
            };
            if (!movie.Validate(out errorMessage))
                return false;

            //Movie must already exist
            var oldMovie = FindById(id);
            if (oldMovie == null)
            {
                errorMessage = "Movie does not exist";
                return false;
            };

            //must be unique
            var existing = FindByTitle(movie.Title);
            if (existing !=null && existing.Id != id)
            {
                errorMessage = "Movie must be unique";
                return false;
            };

            //Copy 
            movie.CopyTo(oldMovie);
            oldMovie.Id = id;
            //Add
            //movie.Id = _id++;
            //_movies.Add(movie.Clone());

            errorMessage = null;
            return true;        
        }

        //TODO: Update

        #region Private Members

        private Movie FindById ( int id )
        {
            foreach (var movie in _movies)
                if (movie.Id == id)
                    return movie;
            return null;
        }

        private Movie FindByTitle (string title)
        {
            foreach (var movie in _movies)
                if (String.Equals(movie.Title, title, StringComparison.OrdinalIgnoreCase))
                    return movie;
            return null;
        }

        private int _id = 1;
        //System.Collections.generic
        //private Movie[] _movies = new Movie[100];
        private List<Movie> _movies = new List<Movie>();
        #endregion
    }
}
