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
        //public List<Explosion> _Shootings;

        private readonly IIARepository _iaRepository;

        public Game _Game;

        public IAService(ILevelStrategy levelStrategy, IIARepository iARepository) 
        {
            //_Id = id;
            _LevelStrategy = levelStrategy;
            _iaRepository = iARepository;
            //_Game = GameService.GetInstanceGame();
            //_Shootings = new List<Explosion>();
        }

        public void SetLevelStrategy(ILevelStrategy strategy)
        {
            _LevelStrategy = strategy;
        }

        public Position ExecuteLevelStrategy(Game game)
        {
            return _LevelStrategy.LogicIA(game);
        }

        public string GetNameLevel()
        {
            return _LevelStrategy.GetName();
        }
        

        public Explosion gameStage(Game game)
        {
            Position positionSelected = ExecuteLevelStrategy(game);
            bool shootResult = Shoot(positionSelected, game);
            Explosion newIAExplosion = new Explosion(positionSelected, shootResult);
            //_Shootings.Add(newIAExplosion);

            return newIAExplosion;

        }


        public bool Shoot(Position position, Game game)
        {
            bool shootresult = false;

            foreach (Ship userShip in game.ShipsPose)
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

        public IA UpdateIA(IA ia)
        {
            return _iaRepository.UpdateIA(ia);
        }
    }
}