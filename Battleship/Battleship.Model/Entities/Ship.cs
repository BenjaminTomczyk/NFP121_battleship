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

        public bool IsCollision(Ship ship1) 
        {
            return false;
        }

        public List<Position> GenerationListPositions() //CORRIGER SYSTEME de MIN et MAX car mtn on fait aussi des diagonales
        {
            List<Position> listPosition = new List<Position>();
            if (!IsSet) return listPosition;
            var startCol = Math.Min(Start.Column, End.Column);
            var endCol = Math.Max(Start.Column, End.Column);
            var startRow = Math.Min(Start.Row, End.Row);
            var endRow = Math.Max(Start.Row, End.Row);

            if (startCol == endCol || startRow == endRow)
            {
                var listCol = Enumerable.Range(startCol, endCol - startCol + 1);
                var listRow = Enumerable.Range(startRow, endRow - startRow + 1);

                foreach (var iListCol in listCol)
                {
                    foreach (var ilistRow in listRow) listPosition.Add(new Position(ilistRow, iListCol));
                }
            }
            else //Diagonale a gerer
            {
                listPosition.Add(new Position(startCol + i, startRow + i));
            }
            
            return listPosition;
        }
    }
}