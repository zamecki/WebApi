using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models.Models;

namespace WebApplication.Business.Dtos.Users
{
    public class DtoUpdateUser
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; } = true;

        public static explicit operator DtoUpdateUser(User user)
        {
            return new DtoUpdateUser()
            {
                UserID = user.UserID,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Active = user.Active
            };
        }
    }
}
