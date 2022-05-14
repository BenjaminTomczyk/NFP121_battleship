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

        public IAService(int id, ILevelStrategy levelStrategy) 
        {
            _Id = id;
            _LevelStrategy = levelStrategy;
            _Game = GameService.GetInstanceGame();
            _Shootings = new List<Explosion>();
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
            
<<<<<<< Updated upstream
            /*foreach(Ship userShip in _Game.ShipsPose)//TODO parcourir la liste des bateaux de l'utilisateur // Rajouter un string sur le ship pour savoir si c'est un bateau de l'IA ou de l'utilisateur
=======
            foreach(Ship userShip in _Game.ShipsPose)
>>>>>>> Stashed changes
            {
                if (userShip.NamePlayer == "User")//TODO parcourir la liste des bateaux de l'utilisateur // Rajouter un string sur le ship pour savoir si c'est un bateau de l'IA ou de l'utilisateur
                {
                    foreach (Position posUserShip in userShip.Positions)
                    {
                        if (position.Equals(posUserShip)) return true;
                    }
                }
            }*/
            return shootresult;
        }
        
            

    }
}