using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Services;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        BookingService _bookingService;
        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // Get All Booking Details
        [HttpGet("GetAllBookingList")]
        public IActionResult getAllBookingList()
        {
            return Ok(_bookingService.getAllBookingList());
        } 

        // Add Booking
        [HttpPost("AddBooking")]
        public IActionResult AddBooking(BookingModel booking)
        {
            return Ok(_bookingService.addBooking(booking));
        }

        // Delete Booking 
        [HttpDelete("DeleteBooking")]
        public IActionResult DeleteBooking(int bookingId)
        {
            return Ok(_bookingService.deleteBooking(bookingId));
        }

        // Select Booking By Id 
        [HttpGet("SelectBookingById")]
        public IActionResult SelectBookingById(int bookingId)
        {
            return Ok(_bookingService.selectBookingById(bookingId));
        }
    }
}
