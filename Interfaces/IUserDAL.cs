using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IUserDAL
    {
        User GetByID(int id);
        User GetByLogin(string login);
        void PutUser(User user);
    }
}
