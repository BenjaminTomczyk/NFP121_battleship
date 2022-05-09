using System;
using System.Collections.Generic;
using Battleship.Logic.Services;
using Battleship.Model.Entities;

namespace Battleship.Logic.Interfaces
{
    public class BattleSetup : IBattleSetup
    {
        public List<ShipService> PlaceBoats(Player p1, int gridSize, List<int> requiredShips)
        {
            var res = new List<ShipService>();
            for (int i = 0; i < requiredShips.Count; i++)
            {
                res.Add(new ShipService(new Position(),new Position()));
            }
            return res;
        }
    }
}