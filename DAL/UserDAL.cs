using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL
{
    public class UserDAL: IUserDAL
    {
        private static List<User> users = new List<User>();

        public User GetByID(int id)
        {
            return users.FirstOrDefault(item => item.id == id);
        }
        public User GetByLogin(string login)
        {
            return users.FirstOrDefault(item => item.login == login);
        }

        public void PutUser(User user)
        {
            users.Add(user);
        }
    }
}
