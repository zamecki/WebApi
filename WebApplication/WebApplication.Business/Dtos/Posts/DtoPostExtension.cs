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
    public static class DtoPostExtension
    {
        public static async Task<Post> ToPostAsync(this DtoCreatePost dtoCreatePost, User user, ICatService catService)
        {
            return new Post()
            {
                Title = dtoCreatePost.Title,
                Message = dtoCreatePost.Message,
                ImageApiID = (await catService.GetRandomCatAsync()).id,
                CreateTime = DateTime.Now,
                UserID = user.UserID
            };
        }

        public static async Task<DtoGetPost> ToDtoGetPostAsync(this Post post, ICatService catService)
        {
            return new DtoGetPost()
            {
                PostID = post.PostID,
                CreateTime = post.CreateTime,
                ImageUrl = (await catService.GetCatAsync(post.ImageApiID)).url,
                Title = post.Title,
                Message = post.Message,
                User = (DtoGetUser)post.User
            };
        }
    }
}
