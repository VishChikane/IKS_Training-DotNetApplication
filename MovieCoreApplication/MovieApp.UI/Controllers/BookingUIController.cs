using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MovieApp.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class BookingUIController : Controller
    {
        IConfiguration _configuration;

        public BookingUIController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> BookingList()
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Booking/GetAllBookingList";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        List<BookingModel> bookingList = JsonConvert.DeserializeObject<List<BookingModel>>(result);
                        return View(bookingList);
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TicketBooking(int movieId)
        {
            //List<theatremodel> list = api call response
            //var tname=list.where(obj=>obj.tid==item.theatreid).ToList()[0];

            List<MovieShowTime> showTimeList = null;
            MovieModel movieModel = null;
            List<TheatreModel> theatreList = null;

            ViewBag.MovieId = movieId;

            // ShowTimeModel Api : Select *
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTime/ShowMovieShowTime";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        showTimeList = JsonConvert.DeserializeObject<List<MovieShowTime>>(result);

                        // TheatreModel Api  : Select *
                        using (HttpClient client1 = new HttpClient())
                        {
                            string endPoint1 = _configuration["WebApiBaseUrl"] + "Theatre/SelectTheatre";
                            using (var response1 = await client1.GetAsync(endPoint1))
                            {
                                if (response1.StatusCode == HttpStatusCode.OK)
                                {
                                    var result1 = await response1.Content.ReadAsStringAsync();
                                    theatreList = JsonConvert.DeserializeObject<List<TheatreModel>>(result1);

                                    // Select ShowTime & Theatre 
                                    List<SelectListItem> showTheatreListItems = new List<SelectListItem>();
                                    foreach (var item in showTimeList)
                                    {
                                        SelectListItem newShowTheatreItem = new SelectListItem();
                                        TheatreModel theatre = theatreList.Where(obj => obj.ThreatreId == item.TheatreId).ToList()[0];
                                        newShowTheatreItem.Text = theatre.ThreatreName;
                                        newShowTheatreItem.Value = theatre.ThreatreId.ToString();
                                        showTheatreListItems.Add(newShowTheatreItem);
                                    }
                                    ViewBag.showShowTheatreList = showTheatreListItems;
                                }
                            }
                        }

                    }
                }
            }

            // MovieModel Api  : Select *
            using (HttpClient client2 = new HttpClient())
            {
                string endPoint2 = _configuration["WebApiBaseUrl"] + "Movie/SelectMovieById?movieId=" + movieId;
                using (var response2 = await client2.GetAsync(endPoint2))
                {
                    if (response2.StatusCode == HttpStatusCode.OK)
                    {
                        var result2 = await response2.Content.ReadAsStringAsync();
                        movieModel = JsonConvert.DeserializeObject<MovieModel>(result2);

                        // Select ShowTime & Movie for movie name 
                        List<SelectListItem> selectListItems = new List<SelectListItem>();
                        SelectListItem movie = new SelectListItem();
                        movie.Text = movieModel.MovieName;
                        movie.Value = movieId.ToString();
                        selectListItems.Add(movie);
                        ViewBag.showSelectedMovie = selectListItems;
                    }
                }
            }

            // ShowTime Drop Down
            List<SelectListItem> showTimeListItems = new List<SelectListItem>();
            SelectListItem newshowTimeItem = new SelectListItem();
            foreach (var item in showTimeList)
            {
                newshowTimeItem = new SelectListItem();
                newshowTimeItem.Text = item.ShowTime;
                newshowTimeItem.Value = item.ShowId.ToString();
                showTimeListItems.Add(newshowTimeItem);
            }
            ViewBag.showTimeShowList = showTimeListItems;

            // Date Drop Down
            List<SelectListItem> dateListItems = new List<SelectListItem>();
            SelectListItem newDateItem = new SelectListItem();
            foreach (var item in showTimeList)
            {
                newDateItem = new SelectListItem();
                newDateItem.Text = item.Date;
                newDateItem.Value = item.ShowId.ToString();
                dateListItems.Add(newDateItem);
            }
            ViewBag.dateShowList = dateListItems;

            // UserModel Api : Select *
            IEnumerable<UserModel> userList = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "User/SelectUsers";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        userList = JsonConvert.DeserializeObject<IEnumerable<UserModel>>(result);
                    }
                }
            }

            // UserId Dropdown
            List<SelectListItem> userListItems = new List<SelectListItem>();
            foreach (var item in userList)
            {
                SelectListItem newUserItem = new SelectListItem();
                newUserItem.Text = item.FirstName + " " + item.LastName;
                newUserItem.Value = item.UserId.ToString();
                userListItems.Add(newUserItem);
            }
            ViewBag.userShowList = userListItems;

            // Ticket Count Drop Down
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<SelectListItem> ticketListItems = new List<SelectListItem>();
            foreach (var item in arr)
            {
                SelectListItem ticketListItem = new SelectListItem();
                ticketListItem.Text = item.ToString();
                ticketListItem.Value = item.ToString();
                ticketListItems.Add(ticketListItem);
            }
            ViewBag.ticketCountShowList = ticketListItems;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TicketBooking(BookingModel bookingModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(bookingModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Booking/AddBooking";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        ViewBag.status = "OK";
                        ViewBag.message = "Booking Added Succesfully...!";
                        return RedirectToAction("BookingList", "BookingUI");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Booking Failed!";
                    }
                }
            }
            return View();
        }

        // GET : BookingUIController/Delete
        public async Task<IActionResult> Delete(int bookingId)
        {
            using (HttpClient client = new HttpClient())
            {
                var endPoint = _configuration["WebApiBaseUrl"] + "Booking/SelectBookingById?bookingId=" + bookingId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var bookingModel = JsonConvert.DeserializeObject<BookingModel>(result);
                        return View(bookingModel);
                    }
                }
            }
            return View();
        }

        // POST : BookingUIController/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(BookingModel deleteBooking)
        {
            using (HttpClient client = new HttpClient())
            {
                var endPoint = _configuration["WebApiBaseUrl"] + "Booking/DeleteBooking?bookingId=" + deleteBooking.BookingId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return RedirectToAction("BookingList", "BookingUI");
                    }
                    else
                    {
                        ViewBag.status("Error");
                        ViewBag.message("Booking Delete Failed ...!");
                    }
                }
            }
            return View();
        }
    }
}
