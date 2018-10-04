using System;
using System.Collections.Generic;
using System.Linq;
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
        public DtoResult<List<DtoGetPost>> GetAll(int userID)
        {

            return Resolve(() =>
            {
                return new DtoResult<List<DtoGetPost>>() { Result = PostBusiness.GetAll(userID) };
            });
        }

        [HttpGet]
        [AllowAnonymous]
        public DtoResult<DtoGetPost> FindPost(int postID)
        {

            return Resolve(() =>
            {
                return new DtoResult<DtoGetPost>() { Result = PostBusiness.Find(postID) };
            });
        }

        [HttpPost]
        [AllowAnonymous]
        public DtoResult<int> CreatePost(DtoCreatePost post)
        {
            return Resolve(() =>
            {
                int postID = PostBusiness.Create(post);
                PostBusiness.Commit();
                return new DtoResult<int>() { Result = postID };
            });
        }
    }
}