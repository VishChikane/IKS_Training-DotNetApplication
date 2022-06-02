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
    public class ShowTimeController : ControllerBase
    {
        ShowTimeService  _showTimeService;

        public ShowTimeController(ShowTimeService showTimeService)
        {
            _showTimeService = showTimeService;
        }

        [HttpGet("ShowMovieShowTime")]
        public IActionResult ShowMovieShowTime()
        {
            return Ok(_showTimeService.ShowMovieShowTime());
        }

        [HttpPost("AddMovieShowTime")]
        public IActionResult AddMovieShowTime(MovieShowTime movieShow)
        {
            return Ok(_showTimeService.InsertMovieShowTime(movieShow));
        }
    }
}
