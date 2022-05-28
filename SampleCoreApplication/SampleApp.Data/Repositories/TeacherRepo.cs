using Microsoft.EntityFrameworkCore;
using SampleApp.Data.DataConnection;
using SampleApp.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleApp.Data.Repositories  // Repositiories
{
    public class TeacherRepo : ITeacherRepo
    {
        SampleDbContext _sampleDbContext;

        public TeacherRepo(SampleDbContext sampleDbContext)
        {
            _sampleDbContext = sampleDbContext;
        }

        // Select All Teachers
        public object SelectAllTeacher()
        {
            return _sampleDbContext.teacherModel.ToList();
        }

        // Added New Teacher
        public string AddTeacher(Teacher teacher)
        {
            _sampleDbContext.teacherModel.Add(teacher);
            _sampleDbContext.SaveChanges();
            return "Added Teacher Successfully ..!";
        }

        // Updated Teacher
        public string UpdateTeacher(Teacher teacher)
        {
            _sampleDbContext.Entry(teacher).State = EntityState.Modified;
            _sampleDbContext.SaveChanges();
            return "Updated Teacher Successfully ..!";
        }

        // Delete Teacher
        public string DeleteTeacher(int teacherId)
        {
            var teacher = _sampleDbContext.teacherModel.Find(teacherId);
            if (teacher == null)
                return "Teacher Not Found";
            _sampleDbContext.Entry(teacher).State = EntityState.Deleted;
            _sampleDbContext.SaveChanges();
            return "Deleted Teacher Successfully ..!";
        }

        public object SelectTeacherById(int teacherId)
        {
            return _sampleDbContext.teacherModel.Find(teacherId);
        }
    }
}
