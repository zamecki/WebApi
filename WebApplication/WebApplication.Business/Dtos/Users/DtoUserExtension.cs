using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.Models;

namespace WebApplication.Business.Dtos.Users
{
    public static class DtoUserExtension
    {
        public static User ToUser(this DtoCreateUser dtoCreateUser)
        {
            return new User()
            {
                Name = dtoCreateUser.Name,
                LastName = dtoCreateUser.LastName,
                Email = dtoCreateUser.Email,
                Password = dtoCreateUser.Password,
                Active = true
            };
        }
        public static void ToUser(this DtoUpdateUser dtoUpdateUser, ref User user)
        {
            user.Name = dtoUpdateUser.Name;
            user.LastName = dtoUpdateUser.LastName;
            user.Email = dtoUpdateUser.Email;
            user.Active = dtoUpdateUser.Active;

        }
    }
}