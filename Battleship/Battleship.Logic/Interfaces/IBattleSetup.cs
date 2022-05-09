using System.Collections.Generic;
using Battleship.Logic.Services;
using Battleship.Model.Entities;

namespace Battleship.Logic.Interfaces
{
    public interface IBattleSetup
    {
        List<ShipService> PlaceBoats(Player p1, int gridSize, List<int> requiredShips);
    }
}