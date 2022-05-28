using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApp.Business.Services;
using SampleApp.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        TeacherService _teacherService;

        public TeacherController(TeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        // Select All Teacher
        [HttpGet("SelectAllTeacher")]
        public IActionResult SelectAllTeacher()
        {
            return Ok(_teacherService.SelectAllTeacher());
        }

        // Add New Teacher
        [HttpPost("AddTeacher")]
        public IActionResult AddTeacher(Teacher teacher)
        {
            return Ok(_teacherService.AddTeacher(teacher));
        }

        // Update Teacher
        [HttpPut("UpdateTeacher")]
        public IActionResult UpdateTeacher(Teacher teacher)
        {
            return Ok(_teacherService.UpdateTeacher(teacher));
        }

        // Delete Teacher
        [HttpDelete("DeleteTeacher")]
        public IActionResult DeleteTeacher(int id)
        {
            return Ok(_teacherService.DeleteTeacher(id));
        }

        // Select Tecaher By Id
        [HttpGet("SelectTeacherById")]
        public IActionResult SelectTeacherById(int id)
        {
            return Ok(_teacherService.SelectTeacherById(id));
        }
    }
}
