using Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class GameBLL : IGameBLL
    {
        private readonly IGameDAL _dal;

        public GameBLL(IGameDAL dal)
        {
            _dal = dal;
        }
        public Game GetByUserID(int UserID)
        {
            return _dal.GetByUserID(UserID);
        }

        public void PutGame(Game game)
        {
            _dal.PutGame(game);
        }
    }
}
