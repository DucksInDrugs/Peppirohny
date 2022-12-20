using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class UserBLL: IUserBLL
    {
        private IUserDAL _dal;

        public UserBLL(IUserDAL dal)
        {
            _dal = dal;
        }

        public User GetByLogin(string login)
        {
            return _dal.GetByLogin(login);
        }

        public User GetByID(int id)
        {
            return _dal.GetByID(id);
        }

        public void PutUser(User user)
        {
            _dal.PutUser(user);
        }
    }
}
