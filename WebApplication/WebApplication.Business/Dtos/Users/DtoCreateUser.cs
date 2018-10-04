using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.Models;

namespace WebApplication.Business.Dtos.Users
{
    public class DtoCreateUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}