using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models.Models;

namespace WebApplication.Business.Dtos.Posts
{
    public static class DtoPostExtension
    {
        public static Post ToPost(this DtoCreatePost dtoCreatePost, User user)
        {
            return new Post()
            {
                Title = dtoCreatePost.Title,
                Message = dtoCreatePost.Message,
                CreateTime = DateTime.Now,
                UserID = user.UserID
            };
        }
    }
}
