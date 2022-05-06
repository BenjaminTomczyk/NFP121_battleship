using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Model.Entities
{
    public class Ship
    {
        public int Id { get; set; }
        public Position? Start { get; set; }
        public Position? End { get; set; }

        public List<Position>? Positions { get; set; }
        public bool IsSet => Start != null && End != null;

        public bool IsPosition()
        {
            if (Math.Abs(Start.Row - End.Row) == Math.Abs(Start.Column - End.Column)) return true;
            return false;
        }

        public bool IsInGrid(int gridSize)
        {
            if (!IsSet) return false;
            List<int> positions = new List<int>() { Start.Column, Start.Row, End.Column, End.Row };
            return positions.TrueForAll(p => (0 <= p && p < gridSize ));     
        }

        public bool IsInjuxtapose(Game game) 
        {
            foreach(Position posI in Positions)
            {
                foreach (Position posY in game.PositionsInvalid)
                    if (posI.Equals(posY)) return false;
            }
            return false;
        }

        public void AddPositionInvalid(Game game)
        {
            if (this.Positions != null && game!=null)
            {
                foreach (Position posI in Positions)
                {
                    game.PositionsInvalid.Add(new Position(posI.Row, posI.Column + 1));
                    game.PositionsInvalid.Add(new Position(posI.Row + 1, posI.Column + 1));
                    game.PositionsInvalid.Add(new Position(posI.Row + 1, posI.Column));
                    game.PositionsInvalid.Add(new Position(posI.Row + 1, posI.Column - 1));
                    game.PositionsInvalid.Add(new Position(posI.Row, posI.Column - 1));
                    game.PositionsInvalid.Add(new Position(posI.Row - 1, posI.Column - 1));
                    game.PositionsInvalid.Add(new Position(posI.Row - 1, posI.Column));
                    game.PositionsInvalid.Add(new Position(posI.Row - 1, posI.Column + 1));
                }
            }

            game.PositionsInvalid = game.PositionsInvalid.Distinct().ToList();

            foreach (Position posI in Positions)
            {
                game.PositionsInvalid.Remove(posI);
            }
        }

        public bool IsDiagonale()
        {
            return (Start.Column != End.Column && Start.Row != End.Row);
        }

        public bool IsCollision(Ship ship1) 
        {
            if (ship1 is null) return false;
            this.GenerationListPositions();
            //TODO : mettre la fonction lors de la pose du bateau apres les verifications de si il est valide
            ship1.GenerationListPositions();
           
            return this.Positions.Any(ipositionThis => ship1.Positions.Any(ipostionShip1 => ipositionThis.Equals(ipostionShip1)));
        }

        public void SetNewAttributPosition(int startCol, int startRow,int endCol, int endRow)
        {
            Start.SetNewValue(startCol, startRow);
            End.SetNewValue(endCol, endRow);
        }

        public void GenerationListPositions()
        {
            List<Position> listPosition = new List<Position>();
            if (IsSet)
            {
                this.OrderPosition();

                if (!IsDiagonale())
                {
                    ListPositionStandard(listPosition);
                }
                else ListPositionDiagonale(listPosition);
            }

            this.Positions = listPosition;
        }
        public void ListPositionStandard(List<Position> listPosition)
        {
            var listCol = Enumerable.Range(Start.Column, End.Column - Start.Column + 1);
            var listRow = Enumerable.Range(Start.Row, End.Row - Start.Row + 1);

            foreach (var iListCol in listCol)
            {
                foreach (var ilistRow in listRow) listPosition.Add(new Position(ilistRow, iListCol));
            }
        }
        public void ListPositionDiagonale(List<Position> listPosition)
        {
            if (Start.Row < End.Row && Start.Column < End.Column)
            {
                AddPosition(listPosition,+1);
            }
            else if (Start.Row > End.Row && Start.Column < End.Column)
            {
                AddPosition(listPosition,-1);
            }
        }

        public void AddPosition (List<Position> listPosition,int direction)
        {
            for (int i = 0; i <= End.Column - Start.Column; i++)
            {
                listPosition.Add(new Position(Start.Row + i* direction, Start.Column + i));
            }
        }

        public void OrderPosition()
        {
            var startCol= Start.Column;
            var endCol = End.Column;
            var startRow =Start.Row;
            var endRow = End.Row;

            if (!IsDiagonale())
            {
                startCol = Math.Min(Start.Column, End.Column);
                endCol = Math.Max(Start.Column, End.Column);
                startRow = Math.Min(Start.Row, End.Row);
                endRow = Math.Max(Start.Row, End.Row);
            }
            
            else if (IsDiagonale() && Start.Column > End.Column)
            {
                startCol = End.Column;
                startRow = End.Row ;
                endCol = Start.Column;
                endRow = Start.Row;
            }

            SetNewAttributPosition(startCol, startRow, endCol, endRow);
            
        }
    }
}