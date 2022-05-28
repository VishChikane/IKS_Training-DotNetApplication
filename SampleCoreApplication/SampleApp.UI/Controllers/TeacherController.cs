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
                        return RedirectToAction("ShowAllTeacherDetails", "Teacher");
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
    
        // GET : TeacherController/Edit/5
        public async Task<IActionResult> EditAsync(int id)
        {
            using(HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Teacher/SelectTeacherById?id=" + id;
                using(var response = await client.GetAsync(endPoint))
                {
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var teacherModel = JsonConvert.DeserializeObject<Teacher>(result);
                        return View(teacherModel);
                    }
                }
            }
            return View();
        }

        // POST : TeacherController/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Teacher teacher)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(teacher), Encoding.UTF8, "application/json");
                var endPoint = _configuration["WebApiBaseUrl"] + "Teacher/UpdateTeacher";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        ViewBag.status = "OK";
                        ViewBag.message = "Updated Teacher Successfully ...!";
                        return RedirectToAction("ShowAllTeacherDetails", "Teacher");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Update Teacher Failed ...!";
                    }
                }
            }
            return View();
        }

        // GET : TeacherController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Teacher/SelectTeacherById?id=" + id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var teacherModel = JsonConvert.DeserializeObject<Teacher>(result);
                        return View(teacherModel);
                    }
                }
            }
            return View();
        }

        // POST : TeacherController/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(Teacher deleteTeacher)
        {
            using (HttpClient client = new HttpClient())
            {
                var endPoint = _configuration["WebApiBaseUrl"] + "Teacher/DeleteTeacher?id="+deleteTeacher.Id;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        ViewBag.status = "OK";
                        ViewBag.message = "Updated Teacher Successfully ...!";
                        return RedirectToAction("ShowAllTeacherDetails", "Teacher");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Update Teacher Failed ...!";
                    }
                }
            }
            return View();
        }
    }
}
