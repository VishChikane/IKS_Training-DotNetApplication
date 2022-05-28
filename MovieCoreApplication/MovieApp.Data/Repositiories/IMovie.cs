using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositiories
{
    public interface IMovie
    {
        object SelectMovies();
        string AddMovie(MovieModel movieModel);
        string UpdateMovie(MovieModel movieModel);
        string DeleteMovie(int movieId);
        object SelectMovieById(int movieId);
    }
}
