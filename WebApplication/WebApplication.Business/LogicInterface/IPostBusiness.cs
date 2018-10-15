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
        Task<int> CreateAsync(DtoCreatePost dtoCreatePost);

        Task<DtoGetPost> FindAsync(int postID);

        Task<List<DtoGetPost>> GetAllAsync(int userID);
    }
}
