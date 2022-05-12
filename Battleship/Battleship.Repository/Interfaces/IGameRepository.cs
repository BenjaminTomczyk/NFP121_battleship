using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.Model.Entities;

namespace Battleship.Repository.Interfaces
{
    public interface IGameRepository
    {
        string SetIALevels();

        Game setNewGame(Game game);

        Game getGame(int id);

        IQueryable<Game> getHistory();
    }

}

