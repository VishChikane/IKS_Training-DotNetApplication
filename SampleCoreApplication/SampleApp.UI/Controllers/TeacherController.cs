using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SampleApp.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.UI.Controllers
{
    public class TeacherController : Controller
    {
        IConfiguration _configuration;

        public TeacherController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET :  TeacherController/ShowAllTeacherDetails
        public async Task<IActionResult> ShowAllTeacherDetails()
        {
            using(HttpClient client = new HttpClient())
            {
                var endPoint = _configuration["WebApiBaseUrl"] + "Teacher/SelectAllTeacher";
                using (var response = await client.GetAsync(endPoint))
                {
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var teacherModel = JsonConvert.DeserializeObject<List<Teacher>>(result);
                        return View(teacherModel);
                    }
                }
            }
            return View();
        }


        // GET : TeacherController/AddTeacher
        public IActionResult AddTeacher()
        {
            return View();
        }

        // POST : TeacherController/AddTeacher
        [HttpPost]
        public async Task<IActionResult> AddTeacher(Teacher teacher)
        {
            using(HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(teacher), Encoding.UTF8,"application/json");
                var endPoint = _configuration["WebApiBaseUrl"] + "Teacher/AddTeacher";
                using(var response = await client.PostAsync(endPoint, content))
                {
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        ViewBag.status = "OK";
                        ViewBag.message = "Added Teacher Successfully ...!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Adding Teacher Failed ...!";
                    }
                }
            }
            return View();
        }
    }
}
