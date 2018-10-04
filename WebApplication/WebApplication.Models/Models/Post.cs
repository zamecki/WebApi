using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public DateTime CreateTime { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
