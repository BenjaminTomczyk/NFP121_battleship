using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Model.Entities
{
    public class Ship
    {
        public Position Start { get; set; }
        public Position End { get; set; }
        public bool IsSet => Start != null && End != null;

        public bool IsInGrid(int gridSize)
        {
            if (!IsSet) return false;
            return Start.Row < gridSize && Start.Column < gridSize && End.Row < gridSize && End.Column < gridSize; 
        }

        public bool IsCollision(Ship ship1) 
        {
            return false;
        }

        public List<Position> GenerationListPositions()
        {
            List<Position> listPosition = new List<Position>();
            if (!IsSet) return listPosition;
            var startCol = Math.Min(Start.Column, End.Column);
            var EndCol = Math.Max(Start.Column, End.Column);
            var startRow = Math.Min(Start.Row, End.Row);
            var EndRow = Math.Max(Start.Row, End.Row);

            var listCol = Enumerable.Range(startCol, EndCol - startCol + 1);
            var listRow = Enumerable.Range(startRow, EndRow - startRow + 1);

            foreach (var iListCol in listCol)
            {
                foreach(var ilistRow in listRow)
                {
                    listPosition.Add(new Position()
                    {
                        Column = iListCol,
                        Row = ilistRow
                    }) ;
                }
            }

            return listPosition;
        }


    }
}