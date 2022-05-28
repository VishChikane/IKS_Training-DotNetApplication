using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositiories
{
    public interface IUser
    {
        string Register(UserModel userModel);
        object Login(UserModel userModel);
        string Update(UserModel userModel);
        string Delete(int userId);
        object SelectUsers();
        object SelectUserById(int userId);
    }
}
