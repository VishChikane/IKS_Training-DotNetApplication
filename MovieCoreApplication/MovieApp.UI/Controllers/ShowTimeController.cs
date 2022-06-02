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
    public class ShowTimeController : Controller
    {
        IConfiguration _configuration;
        public ShowTimeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> ShowIndex()
        {
            using(HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTime/ShowMovieShowTime";
                using(var response = await client.GetAsync(endPoint))
                {
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieShowTimes = JsonConvert.DeserializeObject<List<MovieShowTime>>(result);
                        return View(movieShowTimes);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "No Data Found!";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> InsertMovieShowTime()
        {
            List<MovieModel> movieList = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/SelectMovies";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        movieList = JsonConvert.DeserializeObject<List<MovieModel>>(result);
                    }
                }
            }
            List<SelectListItem> movieListItems = new List<SelectListItem>();
            SelectListItem newMovieItem = new SelectListItem();
            newMovieItem.Text = "Select";
            newMovieItem.Value = "0";
            movieListItems.Add(newMovieItem);
            foreach (var item in movieList)
            {
                newMovieItem = new SelectListItem();
                newMovieItem.Text = item.MovieName;
                newMovieItem.Value = item.MovieId.ToString();
                movieListItems.Add(newMovieItem);
            }
            ViewBag.movieShowList = movieListItems;


            List<TheatreModel> theatreList = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Theatre/SelectTheatre";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        theatreList = JsonConvert.DeserializeObject<List<TheatreModel>>(result);
                    }
                }
            }
            List<SelectListItem> theatreListItems = new List<SelectListItem>();
            SelectListItem newTheatreItem = new SelectListItem();
            newTheatreItem.Text = "Select";
            newTheatreItem.Value = "0";
            theatreListItems.Add(newTheatreItem);
            foreach (var item in theatreList)
            {
                newTheatreItem = new SelectListItem();
                newTheatreItem.Text = item.ThreatreName;
                newTheatreItem.Value = item.ThreatreId.ToString();
                theatreListItems.Add(newTheatreItem);
            }
            ViewBag.theatreShowList = theatreListItems;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertMovieShowTime(MovieShowTime movieShowTime)
        {
            using(HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieShowTime), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTime/AddMovieShowTime";
                using(var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        ViewBag.status = "OK";
                        ViewBag.message = "Show Time Inserted!";
                        return RedirectToAction("ShowIndex", "ShowTime");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Insert ShowTime Failed!";
                    }
                }
            }
            return View();
        }

    }
}



