using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IGameBLL
    {
        Game GetByUserID(int UserID);
        void PutGame(Game game);
    }
}
