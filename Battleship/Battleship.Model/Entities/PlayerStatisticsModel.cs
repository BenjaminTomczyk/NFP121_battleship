using System;
using System.ComponentModel.DataAnnotations;

namespace Battleship.Model.Entities
{
	public class PlayerStatisticsModel
	{
        [Required]
        public string Player { get; set; }
        [Required]
        public string Result { get; set; }
        [Required]
        public int PlayerShootsNumber { get; set; }
        [Required]
        public int IAShootsNumber { get; set; }
        [Required]
        public string IA { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }


        public PlayerStatisticsModel() { }

        public PlayerStatisticsModel(string player, string result, int playerShootsNumber,
            int iaShootNumber, string ia, TimeSpan duration)
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

