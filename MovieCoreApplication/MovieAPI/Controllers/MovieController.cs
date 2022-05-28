using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Services;
using MovieApp.Data.Repositiories;
using MovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        // Get All Movies
        [HttpGet("SelectMovies")]
        public IActionResult SelectMovies()
        {
            return Ok(_movieService.SelectMovies());
        }

        // Add New Movie
        [HttpPost("AddMovie")]
        public IActionResult AddMovie(MovieModel movieModel)
        {
            return Ok(_movieService.AddMovie(movieModel));

        }

        // Update Movie
        [HttpPut("UpdateMovie")]
        public IActionResult UpdateMovie(MovieModel movieModel)
        {
            return Ok(_movieService.UpdateMovie(movieModel));
        }

        // Delete Movie
        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteMovie(int movieId) 
        {
            return Ok(_movieService.DeleteMovie(movieId));
        }

        // Get Movie By Id
        [HttpGet("SelectMovieById")]
        public IActionResult SelectMovieById(int movieId)
        {
            return Ok(_movieService.SelectMovieById(movieId));
        }


    }
}
