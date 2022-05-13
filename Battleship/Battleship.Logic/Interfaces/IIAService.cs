using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleship.Model.Entities;

namespace Battleship.Logic.Interfaces
{
	public interface IIAService
	{
		void setCurrentGame(Game game);
		bool Shoot(Position position);
	}
}

