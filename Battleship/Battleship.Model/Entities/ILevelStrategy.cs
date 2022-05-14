﻿
using System.Collections.Generic;

namespace Battleship.Model.Entities
{
	public interface ILevelStrategy
	{
		Position LogicIA(List<Explosion> shootings);
		string GetName();
	}
}

