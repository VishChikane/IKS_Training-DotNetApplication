using Microsoft.AspNetCore.Http;
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
    public class UserController : Controller
    {
        private IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: UserController
        public async Task<IActionResult> ShowUserDetails()
        {
            //Fetch API,AxiosApi,HttpClient
            //Http Verbs: GET,POST,DELETE..
            //Http Req/response

            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "User/SelectUsers";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<List<UserModel>>(result);
                        return View(userModel);
                    }
                }
            }
            return View();
        }

        // GET: UserController/RegisterUser
        public IActionResult Register()
        {
            //if (ModelState.IsValid)
           
            return View();
        }

        // POST: UserController/Register
        [HttpPost]
        public async Task<IActionResult> Register(UserModel user)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "User/RegisterUser";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        ViewBag.status = "OK";
                        ViewBag.message = "User Register Succesfully ...!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Sorry, User Register Failed ...!";
                    }
                }
            }
            return View();
        }

        // GET: UserController/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: UserController/Login
        [HttpPost]
        public async Task<IActionResult> Login(UserModel user)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "User/Login";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "OK";
                        ViewBag.message = "User Register Succesfully ...!";
                        // return RedirectToAction("Index", "Movies");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Sorry, User Login Failed ...!";
                    }
                }
            }
            return View();
        }

        // GET: UserController/EditUser/5
        public async Task<IActionResult> Edit(int userId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "User/SelectUserById?userId=" + userId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        return View(userModel);
                    }
                }
            }
            return View();
        }

        // POST: UserController/Edit
        [HttpPost]
        public async Task<ActionResult> Edit(UserModel updatedUser)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(updatedUser), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "User/UpdateUser";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        ViewBag.status = "OK";
                        ViewBag.message = "User Updated Succesfully ...!";
                        //return RedirectToAction("ShowUserDetails", "User");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Sorry, User Updated Failed ...!";
                    }
                }
            }
            return View();
        }

        // GET: UserController/DeleteUser/5
        public async Task<IActionResult> Delete(int userId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "User/SelectUserById?userId=" + userId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        return View(userModel);
                    }
                }
            }
            return View();
        }

        // POST: UserController/DeleteUser
        [HttpPost]
        public async Task<ActionResult> Delete(UserModel deleteUser)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "User/DeleteUser?userId=" + deleteUser.UserId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        ViewBag.status = "OK";
                        ViewBag.message = "User Deleted Succesfully ...!";
                        return RedirectToAction("ShowUserDetails", "User");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Sorry, User Delete Failed ...!";
                    }
                }
            }
            return View();
        }

    }
}
