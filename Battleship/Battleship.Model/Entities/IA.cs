﻿using System.Collections.Generic;

namespace Battleship.Model.Entities
{
	public class IA
	{
		public int Id { get; set; }

		public ILevelStrategy LevelStrategy { get; set; }
		public List<Explosion> Shootings;
		//public Game Game { get; set; }
		public string Level { get; set; } //En attendant la mise en place de la strategy

		public IA(int id, ILevelStrategy levelStrategy)
        {
			Id = id;
			LevelStrategy = levelStrategy;
        }
	}
}

