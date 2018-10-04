using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication.Base;
using WebApplication.Business.Dtos;
using WebApplication.Business.Dtos.Users;
using WebApplication.Business.LogicInterface;
using WebApplication.Models.Models;

namespace WebApplication.Controllers
{
    public class UserController : ApiControllerBase
    {
        private IUserBusiness UserBusiness;
        

        public UserController(IUserBusiness userBusiness)
        {
            UserBusiness = userBusiness;
        }


        [HttpPost]
        [AllowAnonymous]
        public DtoResult<int> CreateUser(DtoCreateUser user)
        {
            return Resolve(() =>
            {
                int userID = UserBusiness.Create(user);
                UserBusiness.Commit();
                return new DtoResult<int>() { Result = userID };
            });
        }

        [HttpDelete]
        [AllowAnonymous]
        public DtoResultBase DeleteUser(int userID)
        {

            return Resolve(() =>
            {
                UserBusiness.Deactivate(userID);
                UserBusiness.Commit();
                return new DtoResultBase();
            });
        }

        [HttpPut]
        [AllowAnonymous]
        public DtoResultBase ActivateUser(int userID)
        {

            return Resolve(() =>
            {
                UserBusiness.Activate(userID);
                UserBusiness.Commit();
                return new DtoResultBase();
            });
        }
        [HttpGet]
        [Authorize(Roles="USER")]
        public DtoResult<DtoGetUser> FindUser(string name)
        {

            return Resolve(() =>
            {                
                return new DtoResult<DtoGetUser>() { Result = UserBusiness.FindUser(name) };
            });
        }

        [HttpPatch]
        [AllowAnonymous]
        public DtoResultBase UpdateUser(DtoUpdateUser user)
        {

            return Resolve(() =>
            {
                UserBusiness.Update(user);
                UserBusiness.Commit();
                return new DtoResultBase();
            });
        }
    }
}