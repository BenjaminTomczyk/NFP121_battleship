using System.ComponentModel.DataAnnotations;

namespace Battleship.Model.Entities
{
	public class PlaceShipModel
	{
		[Required]
		public int[] Start { get; set; }
		[Required]
		public int[] End { get; set; }
	}
}

