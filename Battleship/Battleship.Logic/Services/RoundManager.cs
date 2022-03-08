using System;
using Battleship.Logic.Interfaces;
using Battleship.Model.Entities;

namespace Battleship.Logic.Services
{
    public class RoundManager : IRoundManager
    {
        public bool HasBoats(Player player)
        {
            return false;
        }

        public void DoTurn(Player p)
        {
        }
    }
}