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
        public Position LogicIA()
        {



            return new Position();    
        }

        public string GetName()
        {
            return this.nameStrategy;
        }

    }
}