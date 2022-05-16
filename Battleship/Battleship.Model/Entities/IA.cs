using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Battleship.Model.Entities
{
	public class IA
	{
		public int Id { get; set; }
		[NotMapped]
		public ILevelStrategy LevelStrategy { get; set; }
		//public List<Explosion> Shootings;
		//public Game Game { get; set; }
		public string Level { get; set; } //En attendant la mise en place de la strategy

		public IA() {
			Level = "";
		}

		public IA(ILevelStrategy levelStrategy)
        {
			LevelStrategy = levelStrategy;
			Level = levelStrategy.GetName();
        }
	}
}

