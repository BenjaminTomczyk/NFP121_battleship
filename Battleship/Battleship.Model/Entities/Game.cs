using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Battleship.Model.Entities
{
    public class Game
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public IA IA { get; set; }
        [Required]
        public ApplicationUser Player { get; set; }
        [Required]
        public string Result { get; set; }
        [Required]
        public int PlayerShootsNumber { get; set; }
        [Required]
        public int IAShootsNumber { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        [Required]
        public bool Finished { get; set; }

        public int GridSize { get; set; }

        public List<Position>? PositionsInvalid = new List<Position>() { };

        public Game()
        {
        }

        public Game(IA ia, ApplicationUser player, string result, int playerShootNumber,
            int iaShootNumber, TimeSpan duration, List<Position> positionsInvalid, bool finished) {

            IA = ia;
            Player = player;
            Result = result;
            PlayerShootsNumber = playerShootNumber;
            IAShootsNumber = iaShootNumber;
            Duration = duration;
            PositionsInvalid = positionsInvalid;
            Finished = finished;
        }
    }
}
