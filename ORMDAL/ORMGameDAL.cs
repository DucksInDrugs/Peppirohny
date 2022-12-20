using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Interfaces;
using Entities;

namespace ORMDAL
{
    public class ORMGameDAL : IGameDAL
    {
        public Entities.Game GetByUserID(int UserID)
        {
            var context = new DefaultDBContext();
            try
            {
                var game = context.Game.FirstOrDefault(item => item.userID == UserID);
                if (game == null)
                {
                    return null;
                }
                return new Entities.Game()
                {
                    id = game.id,
                    score = game.score,
                    playDate = game.playDate,
                    userID = game.userID
                };
            }
            finally
            {
                context.Dispose();
            }
        }

        public void PutGame(Entities.Game game)
        {
            var context = new DefaultDBContext();
            try
            {
                context.Game.Add(new Game()
                {
                    score = game.score,
                    playDate = game.playDate,
                    userID = game.userID
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
