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

        public Position LogicIA(Game game)
        {
            Position positionSelected = new Position();
            bool positionInvalid = true;
            List<Explosion> shootsIA = game.IAShoots;
            Random rdPos = new Random();
            while (positionInvalid)
            { 
                if (shootsIA.Count == 0 || shootsIA[shootsIA.Count - 1].Hit == false)
                {
                    positionSelected.SetNewValue(rdPos.Next(0, game.GridSize), rdPos.Next(0, game.GridSize));
                }
                else
                {
                    Position lastShootPosition = shootsIA[shootsIA.Count - 1].ExplosionLocation;
                    List<Position> potentialShootingPosition = GenerationPotentialShootingPosition(lastShootPosition);
                    potentialShootingPosition = EliminateImpossiblePositions(potentialShootingPosition,game);

                    if (potentialShootingPosition.Count == 0)  
                    {
                        positionSelected.SetNewValue(rdPos.Next(0, game.GridSize), rdPos.Next(0, game.GridSize));
                    }
                    else
                    {
                        Position posSelect = potentialShootingPosition[rdPos.Next(0, potentialShootingPosition.Count)];
                        positionSelected.SetNewValue(posSelect.Column, posSelect.Row);
                    }
                    
                }
                foreach (Explosion previousShoot in shootsIA)
                {
                    if (positionSelected.Equals(previousShoot.ExplosionLocation))
                    {
                        positionInvalid = true;
                        break;
                    }
                    positionInvalid = false;
                }
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

        public List<Position> EliminateImpossiblePositions(List<Position> potentialShootingPosition,Game game)
        {
            List<Position> resultEliminatePositions = new List<Position>(potentialShootingPosition);
            foreach (Position shootPosition in potentialShootingPosition)
            {
                if(shootPosition.Column < 0 || shootPosition.Column > 7 || shootPosition.Row < 0 || shootPosition.Row > 7)
                {
                    resultEliminatePositions.Remove(shootPosition);
                }                   
                else
                {
                    /*foreach(Position invalidPosition in game.PositionsInvalid)
                    {
                        if (invalidPosition.Equals(shootPosition)) resultEliminatePositions.Remove(invalidPosition);
                    }*/

                    foreach (Explosion oldExplositionIA in game.IAShoots)
                    {
                        if (oldExplositionIA.ExplosionLocation.Equals(shootPosition)) resultEliminatePositions.Remove(oldExplositionIA.ExplosionLocation);
                    }
                }
            }

            return resultEliminatePositions;
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