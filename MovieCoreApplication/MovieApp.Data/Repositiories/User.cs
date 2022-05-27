using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System.Linq;

namespace MovieApp.Data.Repositiories
{
    public class User : IUser
    {
        MovieDbContext _movieDbContext;

        public User(MovieDbContext movieDbContext) 
        {
            _movieDbContext = movieDbContext;
        }
        
        // Register user
        public string Register(UserModel userModel)
        {
            string msg = "";
            _movieDbContext.userModel.Add(userModel);
            _movieDbContext.SaveChanges();//Execute sql statement
            msg = "Inserted User";
            return msg;
        }

        // Login user
        public object Login(UserModel user)
        {
            UserModel userModel = null;
            var result = _movieDbContext.userModel.Where(obj => obj.Email == user.Email && obj.Password == user.Password).ToList();
            if (result.Count > 0)
            {
                userModel = result[0];
            }
            return userModel;
        }

        // Get All User
        public object SelectUsers()
        {
            List<UserModel> userList = _movieDbContext.userModel.ToList();
            return userList;
        }

        // Update User
        public string Update(UserModel userModel)
        {
            string msg = "";
            _movieDbContext.Entry(userModel).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
            msg = "Updated User";
            return msg;
        }

        // Delete User
        public string Delete(int userId)
        {
            string msg = "";
            var user = _movieDbContext.userModel.Find(userId);
            if (user == null)
                return "User Not Found";
            _movieDbContext.Entry(user).State = EntityState.Deleted;
            _movieDbContext.SaveChanges();
            msg = "Delected User";
            return msg;
        }

        // Get User By Id
        //public UserModel GetUserById(int userId)
        //{
        //    return _movieDbContext.userModel.Find(userId);
        //}

    }
}
