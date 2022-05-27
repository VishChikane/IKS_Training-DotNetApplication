using MovieApp.Data.Repositiories;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Business.Services
{
    public class MovieService
    {
        IMovie _imovie;

        public MovieService(IMovie imovie)
        {
            _imovie = imovie;   
        }

        // Get All Movies
        public object SelectMovies()
        {
            return _imovie.SelectMovies();
        }

        // Add A Movie 
        public string AddMovie(MovieModel movieModel)
        { 
            return _imovie.AddMovie(movieModel); ;
        }

        // Update MMovie
        public string UpdateMovie(MovieModel movie)
        {
            return _imovie.UpdateMovie(movie);
        }

        // Delete Movie
        public string DeleteMovie(int movieId)
        {
            return _imovie.DeleteMovie(movieId);
        }

        // Get Movie By Id
        //public void GetMovieById(int movieId)
        //{
        //    _imovie.GetMovieById(movieId);
        //}
    }
}
