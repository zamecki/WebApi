using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.ApiClient.ServiceInterface;
using WebApplication.Business.Base;
using WebApplication.Business.Dtos.Posts;
using WebApplication.Business.LogicInterface;
using WebApplication.Business.Uow;
using WebApplication.Models.Models;

namespace WebApplication.Business.Logic
{
    public class PostBusiness : BusinessBase, IPostBusiness
    {
        private ICatService CatService;

        public PostBusiness(IUnityOfWork uow, ICatService catService) : base(uow)
        {
            CatService = catService;
        }

        public async Task<int> CreateAsync(DtoCreatePost dtoCreatePost)
        {
            User user = Uow.User.GetById(dtoCreatePost.UserID);
            Post post = await dtoCreatePost.ToPostAsync(user, CatService);
            await Uow.Post.AddAsync(post);
            return post.UserID;
        }

        public Task<DtoGetPost> FindAsync(int postID)
        {
            Post post = Uow.Post.GetById(postID);
            if (post == null)
                throw new BusinessException("Post not found");
            return post.ToDtoGetPostAsync(CatService);
        }

        public async Task<List<DtoGetPost>> GetAllAsync(int userID)
        {
            List<Post> posts = Uow.Post.GetAll().Where(x => x.UserID == userID).ToList();
            var dtoTasks = posts.Select(async post => await post.ToDtoGetPostAsync(CatService)).ToList();
            var dtos = await Task.WhenAll(dtoTasks);
            return dtos.ToList();
        }
    }
}
