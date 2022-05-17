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
		Position ExecuteLevelStrategy(Game game);
		Explosion gameStage(Game game);
		bool Shoot(Position position,Game game);
		string GetNameLevel();
		IA UpdateIA(IA ia);
	}
}

