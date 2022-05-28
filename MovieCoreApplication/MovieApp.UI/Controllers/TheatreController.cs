using Microsoft.AspNetCore.Mvc;
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
    public class TheatreController : Controller
    {
        IConfiguration _configuration;

        public TheatreController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET : TheatreController
        public async Task<IActionResult> ShowTheatreDetails()
        {
            using (HttpClient client = new HttpClient())
            {
                var endPoint = _configuration["WebApiBaseUrl"] + "Theatre/SelectTheatre";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var theatreModel = JsonConvert.DeserializeObject<List<TheatreModel>>(result);
                        return View(theatreModel);
                    }
                }
            }
            return View();
        }

        // GET : TheatreController/AddTheatre
        [HttpGet]
        public IActionResult AddTheatre()
        {
            return View();
        }

        // POST : TheatreController/AddTheatre
        [HttpPost]
        public async Task<IActionResult> AddTheatre(TheatreModel theatre)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(theatre), Encoding.UTF8, "application/json");
                var endPoint = _configuration["WebApiBaseUrl"] + "Theatre/AddTheatre";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        ViewBag.status = "OK";
                        ViewBag.message = "Theatre Added Succesfully ...!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Sorry, Theatre Adding Failed ...!";
                    }
                }
            }
            return View();
        }

        // GET : TheatreController/Edit
        public async Task<IActionResult> Edit(int theatreId)
        {
            using (HttpClient client = new HttpClient())
            {
                var endPoint = _configuration["WebApiBaseUrl"] + "Theatre/SelectTheatreById?theatreId=" + theatreId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var theatreModel = JsonConvert.DeserializeObject<TheatreModel>(result);
                        return View(theatreModel);
                    }
                }
            }
            return View();
        }

        // POST : TheatreController/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(TheatreModel updateTheatre)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(updateTheatre), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Theatre/UpdateTheatre";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        ViewBag.status = "OK";
                        ViewBag.message = "Theatre Updated Succesfully ...!";
                        return RedirectToAction("ShowTheatreDetails", "Theatre");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Sorry, Theatre Updated Failed ...!";
                    }
                }
            }
            return View();
        }

        // GET : TheatreController/Delete
        public async Task<IActionResult> Delete(int theatreId)
        {
            using (HttpClient client = new HttpClient())
            {
                var endPoint = _configuration["WebApiBaseUrl"] + "Theatre/SelectTheatreById?theatreId=" + theatreId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var theatreModel = JsonConvert.DeserializeObject<TheatreModel>(result);
                        return View(theatreModel);
                    }
                }
            }
            return View();
        }

        // POST : TheatreController/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(TheatreModel deleteTheatre)
        {
            using (HttpClient client = new HttpClient())
            {
                var endPoint = _configuration["WebApiBaseUrl"] + "Theatre/DeleteTheatre?theatreId=" + deleteTheatre.ThreatreId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return RedirectToAction("ShowTheatreDetails", "Theatre");
                    }
                    else
                    {
                        ViewBag.status("Error");
                        ViewBag.message("Theatre Delete Failed ...!");
                    }
                }
            }
            return View();
        }
    }
}
