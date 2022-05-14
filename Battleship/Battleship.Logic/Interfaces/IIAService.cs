using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleship.Model.Entities;

namespace Battleship.Logic.Interfaces
{
	public interface IIAService
	{
		void SetLevelStrategy(ILevelStrategy strategy);
		Position ExecuteLevelStrategy();
		void gameStage();
		bool Shoot(Position position);
	}
}

