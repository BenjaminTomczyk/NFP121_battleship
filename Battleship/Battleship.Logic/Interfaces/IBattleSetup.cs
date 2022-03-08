using System.Collections.Generic;
using Battleship.Model.Entities;

namespace Battleship.Logic.Interfaces
{
    public interface IBattleSetup
    {
        List<Ship> PlaceBoats(Player p1, int gridSize, List<int> requiredShips);
    }
}