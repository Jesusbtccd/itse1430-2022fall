﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Memory
{
    public class MemoryMovieDatabase : MovieDatabase
    {
        //TODO: Seed database
        public MemoryMovieDatabase ()
        {
            //Array/collection initializer syntax
            //var movies = new Movie[3];

            //Object initializer syntax
            //new Movie("Jaws", "PG");
            //var movie = new Movie();
            //movie.Title = "Jaws";
            //movie.Rating = "PG";
            //movie.RunLength = 210;
            //movie.ReleaseYear = 1977;
            //movie.Description = "Shark eats people";
            //movie.IsClassic = true;
            //movies[0] = new Movie() {
            //    Title = "Jaws",
            //    Rating = "PG",
            //    RunLength = 210,
            //    ReleaseYear = 1977,
            //    Description = "Shark eats people",
            //    IsClassic = true,
            //};            
            //movies[1] = new Movie() {
            //    Title = "Jaws 2",
            //    Rating = "PG-13",
            //    RunLength = 220,
            //    ReleaseYear = 1979,
            //    Description = "Shark eats people...again"                
            //};
            //movies[2] = new Movie() {
            //            Title = "Dune",
            //            Rating = "PG-13",
            //            RunLength = 320,
            //            ReleaseYear = 1985,
            //            Description = "Based on book",
            //        };
            var movies = new Movie[] {
                new Movie() {
                    Title = "Jaws",
                    Rating = "PG",
                    RunLength = 210,
                    ReleaseYear = 1977,
                    Description = "Shark eats people",
                    IsClassic = true,
                },
                new Movie() {
                    Title = "Jaws 2",
                    Rating = "PG-13",
                    RunLength = 220,
                    ReleaseYear = 1979,
                    Description = "Shark eats people...again"
                },
                new Movie() {
                    Title = "Dune",
                    Rating = "PG-13",
                    RunLength = 320,
                    ReleaseYear = 1985,
                    Description = "Based on book",
                }
            };
            foreach (var movie in movies)
                Add(movie, out var error);
        }

        protected override Movie AddCore ( Movie movie )
        {
            //Array
            // Find first null element
            // If found then set to new movie
            // Else
            //   Resize the array 
            //   Copy all existing elements over
            //   Set 'oldarray.Length' to new movie

            //Add
            movie.Id = _id++;
            _movies.Add(movie.Clone());

            return movie;
        }

        protected override Movie GetCore ( int id )
        {
            //Enumerate array looking for match            
            //for (var index = 0; index < _movies.Length; ++index)
            //if (_movies[index]?.Id == id)
            //return _movies[index].Clone();  //Clone because of ref type
            foreach (var movie in _movies)
                if (movie?.Id == id)
                    return movie.Clone();  //Clone because of ref type

            return null;
        }

        //When method returns IEnumerable<T> you MAY use an iterator instead
        protected override IEnumerable<Movie> GetAllCore ()
        {
            //var items = new List<Movie>();

            //When returning an array, clone it...
            //var items = new Movie[_movies.Count];
            //for (var index = 0; index < _movies.Length; ++index)
            //    items[index] = _movies[index]?.Clone();
            //var index = 0;
            foreach (var movie in _movies)
            {
                //items[index++] = movie.Clone();
                //items.Add(movie.Clone());
                yield return movie.Clone();
            };

            //return items;
        }

        protected override void RemoveCore ( int id )
        {
            //Enumerate array looking for match
            for (var index = 0; index < _movies.Count; ++index)
                if (_movies[index]?.Id == id)
                {
                    //_movies[index] = null;
                    _movies.RemoveAt(index);
                    return;
                };
        }

        protected override void UpdateCore ( int id, Movie movie )
        {
            ////Validate movie
            //if (movie == null)
            //{
            //    errorMessage = "Movie cannot be null";
            //    return false;
            //};
            ////if (!movie.Validate(out errorMessage))
            //if (!new ObjectValidator().IsValid(movie, out errorMessage))
            //    return false;

            ////Movie must already exist
            //var oldMovie = FindById(id);
            //if (oldMovie == null)
            //{
            //    errorMessage = "Movie does not exist";
            //    return false;
            //};

            ////Must be unique
            //var existing = FindByTitle(movie.Title);
            //if (existing != null && existing.Id != id)
            //{
            //    errorMessage = "Movie must be unique";
            //    return false;
            //};

            //Copy 
            var oldMovie = FindById(id);
            movie.CopyTo(oldMovie);
            oldMovie.Id = id;

            //errorMessage = null;
            //return true;
        }

        #region Private Members

        private Movie FindById ( int id )
        {
            foreach (var movie in _movies)
                if (movie.Id == id)
                    return movie;

            return null;
        }

        protected override Movie FindByTitle ( string title )
        {
            foreach (var movie in _movies)
                if (String.Equals(movie.Title, title, StringComparison.OrdinalIgnoreCase))
                    return movie;

            return null;
        }

        private int _id = 1;

        //System.Collections.Generic
        //private Movie[] _movies = new Movie[100];
        private List<Movie> _movies = new List<Movie>();
        //private Collection<Movie> _movies = new Collection<Movie>();
        //List<string>;
        //  List<int>;
        #endregion
    }
}
