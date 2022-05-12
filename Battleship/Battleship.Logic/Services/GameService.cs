using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Battleship.Logic.Interfaces;
using Battleship.Model.Entities;
using Battleship.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Battleship.Logic.Services
{
	public class GameService : IGameService
	{
		private readonly IGameRepository _gameRepository;
		private readonly IUserService _userService;

		public Game _Game;

		public GameService(IGameRepository gameRepository, IUserService userService)
		{
			_gameRepository = gameRepository;
			_userService = userService;
		}

		public string SetIA()
        {
			return _gameRepository.SetIALevels();
        }

		public async Task<Game> StartGame(string id)
        {
			_Game = new Game();

			_Game.Player = await _userService.GetUserAsync(id);

			_Game.GridSize = 8;

			Game game = _gameRepository.setNewGame(_Game);

			return _Game;
		}

		public Game GetGame()
        {
			return _gameRepository.getGame(_Game.Id);
        }
	}
}

