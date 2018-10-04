using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Business.Base;
using WebApplication.Business.Dtos.Users;
using WebApplication.Business.LogicInterface;
using WebApplication.Business.Uow;
using WebApplication.Models.Models;

namespace WebApplication.Business.Logic
{
    public class UserBusiness : BusinessBase, IUserBusiness
    {
        public UserBusiness(IUnityOfWork uow) : base(uow)
        {
        }

        public int Create(DtoCreateUser dtoCreateUser)
        {
            User user = dtoCreateUser.ToUser();
            Uow.User.Add(user);
            return user.UserID;
        }

        public void Deactivate(int userID)
        {
            User user = Uow.User.GetById(userID);
            if (user == null)
                throw new BusinessException("User not found");
            user.Active = false;
            Uow.Commit();
        }

        public void Activate(int userID)
        {
            User user = Uow.User.GetById(userID);
            if (user == null)
                throw new BusinessException("User not found");
            user.Active = true;
            Uow.Commit();
        }

        public DtoGetUser FindUser(string name)
        {
            User user = Uow.User.GetAll().Where(x => x.Name.Contains(name) && x.Active).FirstOrDefault();
            if (user == null)
                throw new BusinessException("User not found");
            return (DtoGetUser)user;
        }

        public void Update(DtoUpdateUser updateUser)
        {
            User userBase = Uow.User.GetById(updateUser.UserID);
            if (userBase == null)
                throw new BusinessException("User not found");

            updateUser.ToUser(ref userBase);
            Uow.User.Update(userBase);
        }

        public User FindUserByEmail(string email)
        {
            User user = Uow.User.GetAll().Where(x => x.Email == email && x.Active).FirstOrDefault();
            if (user == null)
                throw new BusinessException("User not found");
            return user;
        }
    }
}
