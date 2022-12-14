using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    /// <summary>Provides a base implementation of <see cref="IMovieDatabase"/>.</summary>
    public abstract class MovieDatabase : IMovieDatabase
    {
        /// <inheritdoc />
        public Movie Add ( Movie movie )
        {
            //Validate movie
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            //Use IValidatableObject Luke...
            ObjectValidator.Validate(movie);

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
                throw new InvalidOperationException("Movie title must be unique.");

            movie.OldMethod();

            //Add
            movie = AddCore(movie);
            return movie;
        }

        /// <inheritdoc />        
        public Movie Get ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            return GetCore(id);
        }

        /// <inheritdoc />                
        public IEnumerable<Movie> GetAll ()
        {
            return GetAllCore();
        }

        /// <inheritdoc />        
        public void Remove ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            RemoveCore(id);
        }

        /// <inheritdoc />        
        public void Update ( int id, Movie movie )
        {
            //Validate movie
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            if (movie == null)
                throw new ArgumentNullException(nameof(movie));
            ObjectValidator.Validate(movie);

            //Movie must already exist
            var oldMovie = GetCore(id);
            if (oldMovie == null)
                throw new ArgumentException("Movie does not exist", nameof(movie));

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null && existing.Id != id)
                throw new InvalidOperationException("Movie title must be unique.");

            try
            {
                UpdateCore(id, movie);
            } catch (Exception e)
            {
                throw new Exception("Update failed", e);
            };
        }

        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The new movie.</returns>
        protected abstract Movie AddCore ( Movie movie );

        /// <summary>Gets a movie by ID.</summary>
        /// <param name="id">The ID of the movie.</param>
        /// <returns>The movie, if any.</returns>
        protected abstract Movie GetCore ( int id );

        /// <summary>Gets all movies.</summary>
        /// <returns>The list of movies.</returns>
        protected abstract IEnumerable<Movie> GetAllCore ();

        /// <summary>Removes a movie given its ID.</summary>
        /// <param name="id">The movie ID.</param>
        protected abstract void RemoveCore ( int id );

        /// <summary>Updates an existing movie.</summary>
        /// <param name="id">The movie ID.</param>
        /// <param name="movie">The movie details.</param>
        protected abstract void UpdateCore ( int id, Movie movie );

        /// <summary>Finds a movie by its title.</summary>
        /// <param name="title">The movie title.</param>
        /// <returns>The movie, if any.</returns>
        protected abstract Movie FindByTitle ( string title );
    }
}
//{
//    /// <summary>Provides a database of movies.</summary>
//    public abstract class MovieDatabase : IMovieDatabase
//    {
//        /// <summary>Adds a movie to the database.</summary>
//        /// <param name="movie">The movie to add.</param>
//        /// <param name="errorMessage">The error message, if any.</param>
//        /// <returns>The new movie.</returns>
//        /// <remarks>
//        /// Fails if:
//        ///   - Movie is null
//        ///   - Movie is not valid
//        ///   - Movie title already exists
//        /// </remarks>
//        public Movie Add ( Movie movie)
//        {
//            //Validate movie
//            if (movie == null)
//                throw new ArgumentNullException(nameof(movie));

//            ObjectValidator.Validate(movie);
//            //{
//            //    errorMessage = "Movie cannot be null";
//            //    return null;
//            //};

//            //Use IValidatableObject Luke...
//            //if (!movie.Validate(out errorMessage))
//            //if (!ObjectValidator.IsValid(movie, out errorMessage))
//            //    return null;

//            //Must be unique
//            var existing = FindByTitle(movie.Title);
//            if (existing != null)
//                throw new InvalidOperationException("Movie title must be unique.");
//            //{
//            //    errorMessage = "Movie must be unique";
//            //    return null;
//            //};

//            //Add
//            movie = AddCore(movie);
//            //movie.Id = _id++;
//            //_movies.Add(movie.Clone());


//            return movie;
//        }

//        protected abstract Movie AddCore ( Movie movie );

//        /// <summary>Gets a movie.</summary>
//        /// <param name="id">ID of the movie.</param>
//        /// <returns>The movie, if any.</returns>
//        /// <remarks>
//        /// Fails if:
//        ///    - Id is less than 1
//        /// </remarks>
//        public Movie Get ( int id )
//        {
//            //TODO: Error
//            if (id <= 0)
//                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");
//                //return null;

//            //foreach (var movie in _movies)
//            //    if (movie?.Id == id)
//            //        return movie.Clone();  //Clone because of ref type
//            return GetCore(id);
//        }

//        protected abstract Movie GetCore ( int id );

//        /// <summary>Gets all the movies.</summary>
//        /// <returns>The movies.</returns>
//        //public Movie[] GetAll ()
//        //When method returns IEnumerable<T> you MAY use an iterator instead
//        public IEnumerable<Movie> GetAll ()
//        {
//            return GetAllCore();
//            //var items = new List<Movie>();

//            //When returning an array, clone it...
//            //var items = new Movie[_movies.Count];
//            //for (var index = 0; index < _movies.Length; ++index)
//            //    items[index] = _movies[index]?.Clone();
//            //var index = 0;
//            //foreach (var movie in _movies)
//            //{
//            //    //items[index++] = movie.Clone();
//            //    //items.Add(movie.Clone());
//            //    yield return movie.Clone();
//            //};

//            //return items;
//        }

//        protected abstract IEnumerable<Movie> GetAllCore ();

//        /// <summary>Remove a movie.</summary>
//        /// <param name="id">ID of the movie to remove.</param>
//        /// <remarks>
//        /// Fails if:
//        /// - Id <= 0
//        /// </remarks>
//        public void Remove ( int id )
//        {
//            if (id <= 0)
//                if (id <= 0)
//                    throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

//            RemoveCore(id);
//            //Enumerate array looking for match
//            //for (var index = 0; index < _movies.Count; ++index)
//            //    if (_movies[index]?.Id == id)
//            //    {
//            //        //_movies[index] = null;
//            //        _movies.RemoveAt(index);
//            //        return;
//            //    };
//        }
//        protected abstract void RemoveCore ( int id );

//        /// <summary>Updates a movie in the database.</summary>
//        /// <param name="movie">The new movie information.</param>
//        /// <param name="errorMessage">The error message, if any.</param>
//        /// <returns>true if successful or false otherwise.</returns>
//        /// <remarks>
//        /// Fails if:
//        ///   - Id is <= 0
//        ///   - Movie does not already exist
//        ///   - Movie is null
//        ///   - Movie is not valid
//        ///   - Movie title already exists
//        /// </remarks>
//        public void Update ( int id, Movie movie )
//        {
//            //Validate movie
//            if (id <= 0)
//                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");
//            //{
//            //    errorMessage = "Movie cannot be null";
//            //    return false;
//            //};

//            if (movie == null)
//                throw new ArgumentNullException(nameof(movie));
//            ObjectValidator.Validate(movie);


//            //Movie must already exist
//            var oldMovie = GetCore(id);
//            if (oldMovie == null)
//                throw new ArgumentException("Movie does not exist", nameof(movie));
//            //{
//            //    errorMessage = "Movie does not exist";
//            //    return false;
//            //};

//            //Must be unique
//            var existing = FindByTitle(movie.Title);
//            if (existing != null && existing.Id != id)
//                    throw new InvalidOperationException("Movie must be unique.");

//            try
//            {
//                UpdateCore(id, movie);
//            } catch (Exception e)
//            {
//                throw new Exception("Update failed", e);
//            };
//            //{
//            //    errorMessage = "Movie must be unique";
//            //    return false;
//            //};

//            //UpdateCore(id, movie);
//            //////Copy 
//            ////movie.CopyTo(oldMovie);
//            ////oldMovie.Id = id;

//            //errorMessage = null;
//            //return true;
//        }

//        protected abstract void UpdateCore ( int id, Movie movie );

//        protected abstract Movie FindByTitle ( string title );
//    }
//}
