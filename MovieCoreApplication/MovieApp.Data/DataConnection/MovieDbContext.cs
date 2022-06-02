using Microsoft.EntityFrameworkCore;
using MovieApp.Entity;

namespace MovieApp.Data.DataConnection
{
    public class MovieDbContext: DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext>options):base(options)
        {

        }
        public DbSet<UserModel> userModel { get; set; }

        public DbSet<MovieModel> movieModel { get; set; }

        public DbSet<TheatreModel> theatreModel { get; set; }

        public DbSet<MovieShowTime> movieShowTime { get; set; }

        public DbSet<BookingModel> bookingModel { get; set; }

    }

}
