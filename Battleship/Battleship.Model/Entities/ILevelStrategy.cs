
using System.Collections.Generic;

namespace Battleship.Model.Entities
{
	public interface ILevelStrategy
	{
		Position LogicIA(Game game);

		bool PositionIsInvalid(List<Explosion> shootings, Position positionSelected);
		string GetName();
	}
}

