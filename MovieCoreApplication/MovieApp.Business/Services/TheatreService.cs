using MovieApp.Data.Repositiories;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Business.Services
{
    public class TheatreService
    {
        ITheatre _itheatre;

        public TheatreService(ITheatre itheatre)
        {
            _itheatre = itheatre;   
        }

        // Get All Theatre
        public object SelectTheatre()
        {
            return _itheatre.SelectTheatre();
        }

        // Add New Theatre
        public string AddTheatre(TheatreModel theatreModel)
        {
            return _itheatre.AddTheatre(theatreModel);
        }

        // Update Theatre
        public string UpdateTheatre(TheatreModel theatre)
        {
            return _itheatre.UpdateTheatre(theatre);
        }

        // Delete Theatre
        public string DeleteTheatre(int theatreId)
        {
            return _itheatre.DeleteTheatre(theatreId);
        }

    }
}
