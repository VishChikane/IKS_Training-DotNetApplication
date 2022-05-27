using SampleApp.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.Data.Repositories
{
    public interface ITeacherRepo
    {
        object SelectAllTeacher();
        String AddTeacher(Teacher teacher);
        string UpdateTeacher(Teacher teacher);
        string DeleteTeacher(int teacherId);
    }
}
