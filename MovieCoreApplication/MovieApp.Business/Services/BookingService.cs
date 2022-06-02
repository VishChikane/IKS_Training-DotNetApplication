using MovieApp.Data.Repositiories;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Business.Services
{
    public class BookingService
    {
        IBooking _booking;
        public BookingService(IBooking booking)
        {
            _booking = booking;
        }

        // Get All Booking Details
        public List<BookingModel> getAllBookingList()
        {
            return _booking.getAllBookingList();
        }

        // Add booking Details
        public string addBooking(BookingModel bookingModel)
        {
            return _booking.addBooking(bookingModel);
        }

        // delete Booking 
        public string deleteBooking(int bookingId)
        {
            return _booking.deleteBooking(bookingId);
        }

        // Select booking by Id 

        public BookingModel selectBookingById(int bookingId)
        {
            return _booking.selectBookingById(bookingId);
        }
    }
}
