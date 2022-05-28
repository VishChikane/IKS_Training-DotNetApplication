using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositiories
{
    public interface ITheatre
    {
        object SelectTheatre();
        string AddTheatre(TheatreModel theatreModel);
        string UpdateTheatre(TheatreModel theatreModel);
        string DeleteTheatre(int theatreId);
        object SelectTheatreById(int theatreId);
    }
}
