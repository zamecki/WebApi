using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Business.Base;
using WebApplication.Business.Dtos.Posts;

namespace WebApplication.Business.LogicInterface
{
    public interface IPostBusiness : ICommitable
    {
        int Create(DtoCreatePost dtoCreatePost);

        DtoGetPost Find(int postID);

        List<DtoGetPost> GetAll(int userID);
    }
}
