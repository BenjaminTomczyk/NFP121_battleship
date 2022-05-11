using System;
using System.Collections.Generic;
using Battleship.Model.Entities;

namespace Battleship.Repository.Interfaces
{
    public interface IGameRepository
    {
        string SetIALevels();
        Game setNewGame(Game game);
    }

}

