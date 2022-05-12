using System;
using System.Threading.Tasks;
using Battleship.Model.Entities;

namespace Battleship.Logic.Interfaces
{
	public interface IGameService
	{
		string SetIA();

		Task<Game> StartGame(string id);

		Game GetGame();
	}
}

