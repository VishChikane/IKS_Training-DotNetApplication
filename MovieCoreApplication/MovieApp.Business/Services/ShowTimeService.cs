using MovieApp.Data.Repositiories;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Business.Services
{
    public class ShowTimeService
    {
        IShowTime _showTime;
        public ShowTimeService(IShowTime showTime)
        {
            _showTime = showTime;
        }

        public string InsertMovieShowTime(MovieShowTime showTime)
        {
            return _showTime.InsertMovieShowTime(showTime);
        }

        public List<MovieShowTime> ShowMovieShowTime()
        {
            return _showTime.ShowMovieShowTime();
        }
    }
}
