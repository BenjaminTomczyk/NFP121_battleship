using System;
using System.ComponentModel.DataAnnotations;

namespace Battleship.Model.Entities
{
	public class PlayerStatisticsModel
	{
        [Required]
        public string Result { get; set; }
        [Required]
        public int PlayerShootsNumber { get; set; }
        [Required]
        public int IAShootsNumber { get; set; }
        [Required]
        public IA IA { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        [Required]
        public ApplicationUser Player { get; set; }

        public PlayerStatisticsModel() { }

        public PlayerStatisticsModel(string result, int playerShootsNumber,
            int iaShootNumber, IA ia, TimeSpan duration, ApplicationUser player)
        {
            Result = result;
            PlayerShootsNumber = playerShootsNumber;
            IAShootsNumber = iaShootNumber;
            IA = ia;
            Duration = duration;
            Player = player;
        }
    }
}

