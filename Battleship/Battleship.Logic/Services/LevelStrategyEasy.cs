using Battleship.Logic.Interfaces;
using Battleship.Model.Entities;
using Battleship.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleship.Logic.Services
{
    public class LevelStrategyEasy : ILevelStrategy
    {
        string nameStrategy = "Easy";
        public Position LogicIA(Game game)
        {
            Position positionSelected = new Position();
            List<Explosion> shootsIA = game.IAShoots;
            Random rdPos = new Random();
            bool positionInvalid = true;

            while (positionInvalid)
            {
                positionSelected.SetNewValue(rdPos.Next(0, game.GridSize), rdPos.Next(0, game.GridSize));
                positionInvalid = PositionIsInvalid(shootsIA, positionSelected);
            }
            return positionSelected;    
        }

        public bool PositionIsInvalid(List<Explosion> shootings, Position positionSelected)
        {
            foreach (Explosion previousShoot in shootings)
            {
                if (positionSelected.Equals(previousShoot.ExplosionLocation)) return true;
            }
            return false;
        }

        public string GetName()
        {
            return this.nameStrategy;
        }

    }
}