using Battleship.Logic.Interfaces;
using Battleship.Model.Entities;
using Battleship.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleship.Logic.Services
{
    public class LevelStrategyMedium : ILevelStrategy
    {

        string nameStrategy = "Medium";

        public Position LogicIA(List<Explosion> shootings)
        {
            Position positionSelected = new Position();
            bool PositionInvalid = true;

            if (shootings.Count == 0 || shootings[shootings.Count-1].Hit == false)
            {
                Random rdPos = new Random();
                positionSelected.SetNewValue(rdPos.Next(0, GameService.GetInstanceGame().GridSize), rdPos.Next(0, GameService.GetInstanceGame().GridSize)); //TODO veriffier si on recperer la bonne valeur de l'instance
            }
            else
            {
                /*generer liste des point autour du tire qui a toucher

                  eliminer les point impossible : (cf shipservice deja fait un truc qui élimine des element d'une liste)
	                    -hors de la grille
                       - point qui sont juxtaposer des autres bateaux*/
                Position lastShootPosition = shootings[shootings.Count - 1].ExplosionLocation;
                List<Position> potentialShootingPosition = GenerationPotentialShootingPosition(lastShootPosition);


            }

            return new Position();
        }

        public List<Position> GenerationPotentialShootingPosition(Position shootHit)
        {
            List<Position> potentialShootingPosition = new List<Position>();
      
            potentialShootingPosition.Add(new Position(shootHit.Row, shootHit.Column + 1));
            potentialShootingPosition.Add(new Position(shootHit.Row + 1, shootHit.Column + 1));
            potentialShootingPosition.Add(new Position(shootHit.Row + 1, shootHit.Column));
            potentialShootingPosition.Add(new Position(shootHit.Row + 1, shootHit.Column - 1));
            potentialShootingPosition.Add(new Position(shootHit.Row, shootHit.Column - 1));
            potentialShootingPosition.Add(new Position(shootHit.Row - 1, shootHit.Column - 1));
            potentialShootingPosition.Add(new Position(shootHit.Row - 1, shootHit.Column));
            potentialShootingPosition.Add(new Position(shootHit.Row - 1, shootHit.Column + 1));

            return potentialShootingPosition;
        }

        public string GetName()
        {
            return this.nameStrategy;
        }

    }
}