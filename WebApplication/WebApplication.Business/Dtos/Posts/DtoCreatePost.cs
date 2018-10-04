using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Business.Dtos.Posts
{
    public class DtoCreatePost
    {
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
