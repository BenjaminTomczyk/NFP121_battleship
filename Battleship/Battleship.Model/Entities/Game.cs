using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Model.Entities
{
    public class Game
    {
        public int GridSize { get; set; }

        public List<Position>? PositionsInvalid{ get;set; }

        private static Game _instance;

        public static Game GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Game();
            }
            return _instance;
        }
    }
}
