using System;
using System.Collections.Generic;
using Battleship.Model.Entities;

namespace Battleship.Logic.Interfaces
{
    public class BattleSetup : IBattleSetup
    {
        public List<Ship> PlaceBoats(Player p1, int gridSize, List<int> requiredShips)
        {
            var res = new List<Ship>();
            for (int i = 0; i < requiredShips.Count; i++)
            {
                res.Add(new Ship()
                {
                    Start = new Position(),
                    End = new Position()
                });
            }
            return res;
        }
    }
}