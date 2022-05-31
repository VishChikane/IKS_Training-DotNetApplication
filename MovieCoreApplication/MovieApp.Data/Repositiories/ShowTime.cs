using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Repositiories
{
    public class ShowTime : IShowTime
    {
        MovieDbContext _movieDbContext;
        public ShowTime(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public string InsertMovieShowTime(MovieShowTime movieShow)
        {
            _movieDbContext.movieShowTime.Add(movieShow);
            _movieDbContext.SaveChanges();
            return "Show Inserted Successfully...!";
        }

        public List<MovieShowTime> ShowMovieShowTime()
        {
           return _movieDbContext.movieShowTime.ToList();
        }
    }
}
