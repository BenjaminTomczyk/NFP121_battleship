using System;
using Battleship.Logic.Interfaces;
using Battleship.Model.Entities;

namespace Battleship.Logic.Services
{
	public class GameService : IGameService
	{
		public GameService()
		{
		}

		public Game StartGame()
        {
			return new Game();
        }
	}
}

