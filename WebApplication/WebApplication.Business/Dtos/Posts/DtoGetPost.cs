using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.ApiClient.ServiceInterface;
using WebApplication.Business.Dtos.Users;
using WebApplication.Models.Models;

namespace WebApplication.Business.Dtos.Posts
{
    public class DtoGetPost
    {
        public int PostID { get; set; }
        public DateTime CreateTime { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DtoGetUser User { get; set; }
    }
}
