using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IUserBLL
    {
        User GetByID(int id);
        User GetByLogin(string login);
        void PutUser(User user);
    }
}
