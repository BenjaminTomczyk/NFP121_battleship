using System;
using Battleship.Model.Entities;

namespace Battleship.Logic.Interfaces
{
	public interface IGameService
	{
		string SetIA();

		Game StartGame(Game game);
	}
}

