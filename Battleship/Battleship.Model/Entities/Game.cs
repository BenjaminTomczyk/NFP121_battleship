using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Model.Entities
{
    public class Game
    {
        public int GridSize { get; set; }

        public List<Position> PositionsInvalid = new List<Position>();

    }
}
