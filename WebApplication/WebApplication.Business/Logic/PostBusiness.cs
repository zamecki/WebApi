using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Business.Base;
using WebApplication.Business.Dtos.Posts;
using WebApplication.Business.LogicInterface;
using WebApplication.Business.Uow;
using WebApplication.Models.Models;

namespace WebApplication.Business.Logic
{
    public class PostBusiness : BusinessBase, IPostBusiness
    {
        public PostBusiness(IUnityOfWork uow) : base(uow)
        {
        }

        public int Create(DtoCreatePost dtoCreatePost)
        {
            User user = Uow.User.GetById(dtoCreatePost.UserID);
            Post post = dtoCreatePost.ToPost(user);
            Uow.Post.Add(post);
            return post.UserID;
        }

        public DtoGetPost Find(int postID)
        {
            Post post = Uow.Post.GetById(postID);
            if (post == null)
                throw new BusinessException("Post not found");
            return (DtoGetPost)post;
        }

        public List<DtoGetPost> GetAll(int userID)
        {
            List<Post> posts = Uow.Post.GetAll().Where(x => x.UserID == userID).ToList();
            return posts.Select(x => (DtoGetPost)x).ToList();
        }
    }
}
