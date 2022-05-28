using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieApp.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class MovieController : Controller
    {
        IConfiguration _configuration;

        public MovieController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> ShowMovieDetails()
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/SelectMovies";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieModel = JsonConvert.DeserializeObject<List<MovieModel>>(result);
                        return View(movieModel);
                    }
                }
            }
            return View();
        }

        // Get : MovieController/AddMovie
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        // Post : MovieController/AddMovie
        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieModel movie)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                ViewBag.status = "";
                StringContent content = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/AddMovie";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "OK";
                        ViewBag.message = "Movie Added Succesfully ...!";
                        // return RedirectToAction("Index", "Movies");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Sorry, Movie Adding Failed ...!";
                    }
                }
            }
            return View();
        }

        // GET : MovieController/Edit/5
        public async Task<IActionResult> Edit(int movieId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/SelectMovieById?movieId="+movieId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieModel = JsonConvert.DeserializeObject<MovieModel>(result);
                        return View(movieModel);
                    }
                }
            }
            return View();
        }

        // POST: MovieController/Edit
        [HttpPost]
        public async Task<ActionResult> Edit(MovieModel updatedmovie)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(updatedmovie), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/UpdateMovie";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return RedirectToAction("ShowMovieDetails", "Movie");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Sorry, Movie Updated Failed ...!";
                    }
                }
            }
            return View();
        }


        // GET : MovieController/Delete/5
        public async Task<IActionResult> Delete(int movieId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/SelectMovieById?movieId=" + movieId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieModel = JsonConvert.DeserializeObject<MovieModel>(result);
                        return View(movieModel);
                    }
                }
            }
            return View();
        }

        // POST : MovieController/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(MovieModel deleteMovie)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/DeleteMovie?movieId="+deleteMovie.MovieId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return RedirectToAction("ShowMovieDetails", "Movie");
                    }
                    else
                    {
                        ViewBag.status("Error");
                        ViewBag.message("Movie Delete Failed ...!");
                    }
                }
            }
            return View();
        }


    }
}
