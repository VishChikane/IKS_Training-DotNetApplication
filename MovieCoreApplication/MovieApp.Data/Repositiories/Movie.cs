using Microsoft.EntityFrameworkCore;
using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Repositiories
{
    public class Movie : IMovie
    {
        MovieDbContext _movieDbContext;

        public Movie(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        // Get All Movie
        public object SelectMovies()
        {
            List<MovieModel> movieList = _movieDbContext.movieModel.ToList();
            return movieList;
        }

        // Add A Movie
        public string AddMovie(MovieModel movieModel)
        {
            string msg = "";
            _movieDbContext.movieModel.Add(movieModel);
            _movieDbContext.SaveChanges();
            msg = "Added Movie";
            return msg;
        }

        // Update Movie
        public string UpdateMovie(MovieModel movieModel)
        {
            string msg = "";
            _movieDbContext.Entry(movieModel).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
            msg = "Updated Movie";
            return msg;
        }

        // Delete Movie
        public string DeleteMovie(int movieId)
        {
            string msg = "";
            var movie = _movieDbContext.movieModel.Find(movieId);
            if (movie == null)
                return "Movie Not Found";
            _movieDbContext.movieModel.Remove(movie);   
            _movieDbContext.SaveChanges();
            msg = "Deleted Movie";
            return msg;
        }

        // Select Movie By Id
        public object SelectMovieById(int movieId)
        {
            return _movieDbContext.movieModel.Find(movieId);
        }


    }
}
