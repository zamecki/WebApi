using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApplication.Base;
using WebApplication.Business.Dtos;
using WebApplication.Business.Dtos.Posts;
using WebApplication.Business.LogicInterface;
using WebApplication.Models.Models;

namespace WebApplication.Controllers
{
    public class PostController : ApiControllerBase
    {
        private IPostBusiness PostBusiness;

        public PostController(IPostBusiness postBusiness)
        {
            PostBusiness = postBusiness;
        }

        [HttpGet]
        [Route("{userID:int}")]
        [AllowAnonymous]
        public async Task<DtoResult<List<DtoGetPost>>> GetAllAsync(int userID)
        {

            return await ResolveAsync(async () =>
            {
                return new DtoResult<List<DtoGetPost>>() { Result = await PostBusiness.GetAllAsync(userID) };
            });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<DtoResult<DtoGetPost>> FindPostAsync(int postID)
        {

            return await ResolveAsync(async () =>
            {
                return new DtoResult<DtoGetPost>() { Result = await PostBusiness.FindAsync(postID) };
            });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<DtoResult<int>> CreatePostAsync(DtoCreatePost post)
        {
            return await ResolveAsync(async () =>
            {
                int postID = await PostBusiness.CreateAsync(post);
                PostBusiness.Commit();
                return new DtoResult<int>() { Result = postID };
            });
        }
    }
}