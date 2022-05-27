using System;
using System.Collections.Generic;
using System.Text;
using SampleApp.Data.Repositories;
using SampleApp.Entity.Models;

namespace SampleApp.Business.Services
{
    public class TeacherService
    {
        ITeacherRepo _teacherRepo;

        public TeacherService(ITeacherRepo teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }

        // Select All Teacher
        public object SelectAllTeacher()
        {
            return _teacherRepo.SelectAllTeacher();
        }

        // Add New Teacher 
        public string AddTeacher(Teacher teacher)
        {
            return _teacherRepo.AddTeacher(teacher);
        }

        // Update Teacher
        public string UpdateTeacher(Teacher teacher)
        {
            return _teacherRepo.UpdateTeacher(teacher);
        }

        // Delete Teacher
        public string DeleteTeacher(int teacherId)
        {
            return _teacherRepo.DeleteTeacher(teacherId);
        }
    }
}
