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
        public string _Level { get; set; }

        public Game _Game;

        public IAService(int id, string level) 
        {
            _Id = id;
            _Level = level;
        }
        public void setCurrentGame(Game game)
        {
            _Game = game;
        }



        public bool Shoot(Position position)
        {
            bool shootresult = false;
            
            foreach(Ship userShip in _Game.ShipsPose)//TODO parcourir la liste des bateaux de l'utilisateur // Rajouter un string sur le ship pour savoir si c'est un bateau de l'IA ou de l'utilisateur
            {
                if (userShip.NamePlayer == "User")
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