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
    public class UserController : ControllerBase
    {
        UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // Get All User
        [HttpGet("SelectUsers")]
        public IActionResult SelectUsers()
        {
            return Ok(_userService.SelectUsers());
        }

        // Register User
        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser(UserModel userModel)
        {
            return Ok(_userService.Register(userModel));
        }

        // Login User
        [HttpPost("LoginUser")]
        public IActionResult LoginUser(UserModel userModel)
        {
            return Ok(_userService.Login(userModel));
        }

        // Update user
        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(UserModel userModel)
        {
            return Ok(_userService.Update(userModel));
        }

        // Delete User
        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int userId)
        {
            return Ok(_userService.Delete(userId));
        }

        // Get User By ID
        [HttpGet("SelectUserById")]
        public IActionResult SelectUserById(int userId)
        {
            return Ok(_userService.SelectUserById(userId));
        }

    }
}
