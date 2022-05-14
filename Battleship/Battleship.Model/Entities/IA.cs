﻿using System.Collections.Generic;

namespace Battleship.Model.Entities
{
	public class IA
	{
		public int Id { get; set; }

		public string LevelStrategy { get; set; }       //TODO faire reference a ILEVELSTRATEGY pour le type de LevelStrategy
		public List<Explosion> Shootings;
		public Game Game { get; set; }

		public IA(int id, string level)
        {
			Id = id;
			Level = level;
        }
	}
}

