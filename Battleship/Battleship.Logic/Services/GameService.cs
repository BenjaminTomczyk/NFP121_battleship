using System;
using Battleship.Logic.Interfaces;
using Battleship.Model.Entities;
using Battleship.Repository.Interfaces;

namespace Battleship.Logic.Services
{
	public class GameService : IGameService
	{
		private readonly IGameRepository _gameRepository;

		public GameService(IGameRepository gameRepository)
		{
			_gameRepository = gameRepository;
		}

		public string SetIA()
        {
			return _gameRepository.SetIALevels();
        }

		public Game StartGame(Game game)
        {
			return _gameRepository.setNewGame(game);
        }
	}
}

