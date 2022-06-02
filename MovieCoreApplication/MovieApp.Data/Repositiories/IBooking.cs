using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositiories
{
    public interface IBooking
    {
        string addBooking(BookingModel booking);

        List<BookingModel> getAllBookingList();
        string deleteBooking(int bookingId);
        BookingModel selectBookingById(int bookingId);
    }
}
