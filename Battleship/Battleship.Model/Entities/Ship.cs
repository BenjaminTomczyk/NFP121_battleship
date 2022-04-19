using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Model.Entities
{
    public class Ship
    {
        public Position? Start { get; set; }
        public Position? End { get; set; }
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

        public bool IsDiagonale()
        {
            return (Start.Column != End.Column && Start.Row != End.Row);
        }

        public bool IsCollision(Ship ship1) 
        {
            if (ship1 is null) return false;
            List<Position> thisPos = this.GenerationListPositions();
            List<Position> ship1Pos = ship1.GenerationListPositions();
           
            return thisPos.Any(ipositionThis => ship1Pos.Any(ipostionShip1 => ipositionThis.Equals(ipostionShip1)));
        }

        public void SetNewAttributPosition(int startCol, int startRow,int endCol, int endRow)
        {
            Start.SetNewValue(startCol, startRow);
            End.SetNewValue(endCol, endRow);
        }

        public List<Position> GenerationListPositions() //CORRIGER SYSTEME de MIN et MAX car mtn on fait aussi des diagonales
        {
            List<Position> listPosition = new List<Position>();
            if (!IsSet) return listPosition;

            this.OrderPosition();

            if (!IsDiagonale())
            {
                ListPositionStandard(listPosition);
            }
            else ListPositionDiagonale(listPosition);
            
            return listPosition;
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