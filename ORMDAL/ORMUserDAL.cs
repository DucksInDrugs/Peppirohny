using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using System.Linq;

namespace ORMDAL
{
    public class ORMUserDAL : IUserDAL
    {
        public Entities.User GetByLogin(string login)
        {
            var context = new DefaultDBContext();
            try
            {
                var user = context.User.FirstOrDefault(item => item.login == login);

                if (user == null)
                {
                    return null;
                }
                var entity = new Entities.User()
                {
                    id = user.id,
                    name = user.name,
                    password = user.password,
                    login = user.login,
                    creationDate = user.creationDate
                };
                return entity;
            }
            finally
            {
                context.Dispose();
            }
        }

        public Entities.User GetByID(int id)
        {
            var context = new DefaultDBContext();
            try
            {
                var user = context.User.FirstOrDefault(item => item.id == id);

                if (user == null)
                {
                    return null;
                }
                var entity = new Entities.User()
                {
                    id = user.id,
                    name = user.name,
                    password = user.password,
                    login = user.login,
                    creationDate = user.creationDate
                };
                return entity;
            }
            finally
            {
                context.Dispose();
            }

        }

        public void PutUser(Entities.User user)
        {
            var context = new DefaultDBContext();
            try
            {
                context.User.Add(new User()
                {
                    name = user.name,
                    password = user.password,
                    login = user.login,
                    creationDate = user.creationDate
                });
                context.SaveChanges();
            }
            finally
            {
                context.Dispose();
            }
        }
    }
}
