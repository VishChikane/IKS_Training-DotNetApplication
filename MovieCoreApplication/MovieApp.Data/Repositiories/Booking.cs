using Microsoft.EntityFrameworkCore;
using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Repositiories
{
    public class Booking : IBooking
    {
        MovieDbContext _movieDbContext;
        public Booking(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        // Get All Booking Details
        public List<BookingModel> getAllBookingList()
        {
            return _movieDbContext.bookingModel.ToList();
        }

        // Add Booking
        public string addBooking(BookingModel booking)
        {
            _movieDbContext.bookingModel.Add(booking);
            _movieDbContext.SaveChanges();
            return "Booking Details Added";
        }

        public string deleteBooking(int bookingId)
        {
            var booking = _movieDbContext.bookingModel.Find(bookingId);
            _movieDbContext.Entry(booking).State = EntityState.Deleted;
            _movieDbContext.SaveChanges();
            return "Booking Deleted Succesfully";
        }

        public BookingModel selectBookingById(int bookingId)
        {
            return _movieDbContext.bookingModel.Find(bookingId);
        }
    }
}
