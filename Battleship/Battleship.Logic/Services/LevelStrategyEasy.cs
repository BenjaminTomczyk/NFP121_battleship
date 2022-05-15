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
        public Position LogicIA(List<Explosion> shootings)
        {
            Position positionSelected = new Position();
            Random rdPos = new Random();
            bool PositionInvalid = true;

            while (PositionInvalid)
            {
                positionSelected.SetNewValue(rdPos.Next(0, GameService.GetInstanceGame().GridSize), rdPos.Next(0, GameService.GetInstanceGame().GridSize)); //TODO veriffier si on recperer la bonne valeur de l'instance
                foreach(Explosion previousShoot in shootings)
                {
                    if (positionSelected.Equals(previousShoot.ExplosionLocation))
                    {
                        PositionInvalid = true;
                        break;
                    }
                    PositionInvalid = false;
                }       
            }
            return positionSelected;    
        }

        public string GetName()
        {
            return this.nameStrategy;
        }

    }
}