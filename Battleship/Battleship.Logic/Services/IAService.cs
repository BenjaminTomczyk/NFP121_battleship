using Battleship.Logic.Interfaces;
using Battleship.Model.Entities;
using Battleship.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleship.Logic.Services
{
    public class IAService : IIAService
    {
        public int _Id { get; set; }
        public ILevelStrategy _LevelStrategy { get; set; }
        public List<Explosion> _Shootings;

        public Game _Game;

        public IAService(ILevelStrategy levelStrategy) 
        {
            //_Id = id;
            _LevelStrategy = levelStrategy;
            _Game = GameService.GetInstanceGame();
            _Shootings = new List<Explosion>();
        }

        public void setCurrentGame(Game game)
        {
            _Game = game;
        }

        public void SetLevelStrategy(ILevelStrategy strategy) => _LevelStrategy = strategy;

        public Position ExecuteLevelStrategy()
        {
            return _LevelStrategy.logicIA();
        }
        

        public void gameStage()
        { 

        }


        public bool Shoot(Position position)
        {
            bool shootresult = false;

            foreach(Ship userShip in _Game.Ships)

            {
                if (userShip.Player == "User")
                {
                    foreach (Position posUserShip in userShip.Positions)
                    {
                        if (position.Equals(posUserShip)) return true;
                    }
                }
            }
            return shootresult;
        }
        
            

    }
}