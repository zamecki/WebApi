using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Business.Base;
using WebApplication.Business.Dtos.Users;
using WebApplication.Models.Models;

namespace WebApplication.Business.LogicInterface
{
    public interface IUserBusiness : ICommitable
    {
        int Create(DtoCreateUser dtoCreateUser);
        void Deactivate(int userID);
        void Activate(int userID);
        void Update(DtoUpdateUser user);
        DtoGetUser FindUser(string name);
        User FindUserByEmail(string email);
    }
}
