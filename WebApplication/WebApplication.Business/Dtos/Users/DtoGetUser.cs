using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.Models;

namespace WebApplication.Business.Dtos.Users
{
    public class DtoGetUser
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; } = true;

        public static explicit operator DtoGetUser(User user)
        {
            return new DtoGetUser()
            {
                UserID = user.UserID,
                Name = user.Name,
                LastName = user.LastName,
                Active = user.Active 
            };
        }
    }
}