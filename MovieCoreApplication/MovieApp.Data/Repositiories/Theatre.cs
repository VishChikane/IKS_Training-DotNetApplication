using Microsoft.EntityFrameworkCore;
using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Repositiories
{
    
    public class Theatre : ITheatre
    {
        MovieDbContext _movieDbContext;

        public Theatre(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        // Get Theatres 
        public object SelectTheatre()
        {
            List<TheatreModel> theatreList = _movieDbContext.theatreModel.ToList();
            return theatreList;
        }

        // Add New Theatre
        public string AddTheatre(TheatreModel theatreModel)
        {
            _movieDbContext.theatreModel.Add(theatreModel);
            _movieDbContext.SaveChanges();
            return "Inserted New Theatre";
        }

        // Update Thetre
        public string UpdateTheatre(TheatreModel theatreModel)
        {
            _movieDbContext.Entry(theatreModel).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
            return "Updated Theatre";
        }

        // Delete Theatre
        public string DeleteTheatre(int theatreId)
        {
            var theatre = _movieDbContext.theatreModel.Find(theatreId);
            _movieDbContext.Entry(theatre).State = EntityState.Deleted;
            _movieDbContext.SaveChanges();
            return "Delected Theatre";
        }

        // Select Theatre By Id
        public object SelectTheatreById(int theatreId)
        {
            return _movieDbContext.theatreModel.Find(theatreId);
        }
    }
}
