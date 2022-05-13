using System;
using System.Collections.Generic;
using System.Linq;
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

			_Game.Result = "";

			_Game.GridSize = 8;

			Game game = _gameRepository.setNewGame(_Game);

			return _Game;
		}

		public Game GetGame(int id)
        {
			return _gameRepository.getGame(id);
        }

		public List<PlayerStatisticsModel> GetUserHistory(string id)
        {
			IQueryable<Game> res = _gameRepository.getHistory();

			res = res
				.Where(g =>
					g.Finished == false &&
					g.Player.Id == id)
				.Take(10);

			List<PlayerStatisticsModel> stats = new List<PlayerStatisticsModel>();
			foreach(Game g in res)
            {
				stats.Add(new PlayerStatisticsModel(g.Result, g.PlayerShootsNumber, g.IAShootsNumber, g.IA, g.Duration, g.Player));
            }

			return stats;
        }

		public List<PlayerStatisticsModel> GetFullHistory()
		{
			IQueryable<Game> res = _gameRepository.getHistory();

			res = res
				.Where(g =>
					g.Finished == false)
				.Take(10);

			List<PlayerStatisticsModel> stats = new List<PlayerStatisticsModel>();
			foreach (Game g in res)
			{
				stats.Add(new PlayerStatisticsModel(g.Result, g.PlayerShootsNumber, g.IAShootsNumber, g.IA, g.Duration, g.Player));
			}

			return stats;
		}
	}
}

