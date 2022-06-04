using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTokenDemoApp.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel()
            {
                UserName="Vishal_Admin",Email = "Vishal_Admin@gmail.com",Password="Admin@123",GivenName="Vishal",Surname="Chikane",Role="Administrator"
            },
            new UserModel()
            {
                UserName="Vijay_Seller",Email = "Vijay_Seller@gmail.com",Password="Seller@123",GivenName="Vijay",Surname="Deshmukh",Role="Seller"
            },
            new UserModel()
            {
                UserName="Kishor_Admin",Email = "Kishor_Admin@gmail.com",Password="Admin@123",GivenName="Kishor",Surname="Chikane",Role="Administrator"
            },
            new UserModel()
            {
                UserName="Dhiraj_Seller",Email = "Dhiraj_Seller@gmail.com",Password="Seller@123",GivenName="Dhiraj",Surname="Deshmukh",Role="Seller"
            }
        };
    }
}
