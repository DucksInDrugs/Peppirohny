using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL
{
    public class GameDAL: IGameDAL
    {
        private List<Game> games = new List<Game>()
        {
            //new Users() { Id = 1, Name = "Ivan", Age = 20, Phone = "123454" },
            //new Users() { Id = 2, Name = "Ivan", Age = 20, Phone = "123454" },
            //new Users() { Id = 3, Name = "Ivan", Age = 20, Phone = "123454" },
            //new Users() { Id = 4, Name = "Ivan"},
        };

        public Game GetByID(int id)
        {
            return games.FirstOrDefault(item => item.id == id);
        }

        public Game GetByUserID(int UserID)
        {
            return games.FirstOrDefault(item => item.userID == UserID);
        }

        public void PutGame(Game game)
        {
            games.Add(game);
        }
    }
}
