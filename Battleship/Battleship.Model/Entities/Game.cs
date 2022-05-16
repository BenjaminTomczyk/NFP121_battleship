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
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int PlacedShips { get; set; }
        [Required]
        public List<Ship> ShipsPose { get; set; }
        [Required]
        public List<Explosion> PlayerShoots { get; set; }
        [Required]
        public List<Explosion> IAShoots { get; set; }
        [Required]
        public List<Position> PositionsInvalid { get; set; }


        public int GridSize { get; set; }

        public int Ship2Number { get; set; }
        public int Ship3Number { get; set; }
        public int Ship4Number { get; set; }
        public int Ship5Number { get; set; }

        


        public Game()
        {
            PositionsInvalid = new List<Position>();
            ShipsPose = new List<Ship>();
            PlayerShoots = new List<Explosion>();
            IAShoots = new List<Explosion>();
            PlacedShips = 0;
            Ship2Number = 1;
            Ship3Number = 2;
            Ship4Number = 2;
            Ship5Number = 1;
        }

        public Game(IA ia, ApplicationUser player, string result, int playerShootNumber,
            int iaShootNumber, TimeSpan duration, List<Position> positionsInvalid, bool finished,
            DateTime date, List<Ship> shipsPose, int placedShips, List<Explosion> playerShoots, List<Explosion> iaShoots) {

            IA = ia;
            Player = player;
            Result = result;
            PlayerShootsNumber = playerShootNumber;
            IAShootsNumber = iaShootNumber;
            Duration = duration;
            PositionsInvalid = positionsInvalid;
            Finished = finished;
            Date = date;
            PlacedShips = placedShips;
            ShipsPose = shipsPose;
            PlayerShoots = playerShoots;
            IAShoots = iaShoots;
            Ship2Number = 1;
            Ship3Number = 2;
            Ship4Number = 2;
            Ship5Number = 1;
        }
    }
}
