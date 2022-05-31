using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositiories
{
    public interface IShowTime
    {
        string InsertMovieShowTime(MovieShowTime movieShowTime);
        List<MovieShowTime> ShowMovieShowTime();
    }
}
