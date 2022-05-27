using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositiories;
using MovieApp.Entity;

namespace MovieApp.Business.Services
{
    public class UserService
    {
        IUser _iuser;
        public UserService(IUser user)
        {
            _iuser = user;
        }

        // Register New User
        public string Register(UserModel userModel)
        {
            return _iuser.Register(userModel);
        }

        // Login User
        public object Login(UserModel userModel)
        {
            return _iuser.Login(userModel);
        }

        // Select All User
        public object SelectUsers()
        {
            return _iuser.SelectUsers();
        }

        // Update user
        public string Update(UserModel userModel)
        {
            return _iuser.Update(userModel);
        }

        // Delete user
        public string Delete(int userId)
        {
            return _iuser.Delete(userId);
        }
    }
}
