using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.ApiClient.Models
{
    public class Cat
    {
        public string id { get; set; }
        public string url { get; set; }
        public List<object> breeds { get; set; }
        public List<object> categories { get; set; }
    }
}
