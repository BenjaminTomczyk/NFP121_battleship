﻿using System;
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

			_Game.Date = DateTime.Now;

			return _gameRepository.setNewGame(_Game);
		}

		public Game GetGame(int id)
        {
			return _gameRepository.getGame(id);
		}

		public List<PlayerStatisticsModel> GetUserHistory(string id)
        {
			IQueryable<Game> res = _gameRepository.getHistory();

			res = res
				.OrderByDescending(g => g.Date)
				.Where(g =>
					g.Finished == true &&
					g.Player.Id == id)
				.Take(10);

			List<PlayerStatisticsModel> stats = new List<PlayerStatisticsModel>();
			foreach(Game g in res)
            {
				stats.Add(new PlayerStatisticsModel(g.Player.UserName, g.Result, g.PlayerShootsNumber, g.IAShootsNumber, g.IA.Level, g.Duration));
			}
			return stats;
        }

		public List<PlayerStatisticsModel> GetFullHistory()
		{
			IQueryable<Game> res = _gameRepository.getHistory();

			res = res
				.OrderByDescending(g => g.Date)
				.Where(g =>
					g.Finished == true)
				.Take(10);

			List<PlayerStatisticsModel> stats = new List<PlayerStatisticsModel>();
			foreach (Game g in res)
			{
				stats.Add(new PlayerStatisticsModel(g.Player.UserName, g.Result, g.PlayerShootsNumber, g.IAShootsNumber, g.IA.Level, g.Duration));
			}

			return stats;
		}
	}
}
