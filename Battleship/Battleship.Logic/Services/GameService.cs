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
		private readonly IIAService _IIAService;

		public static Game _Game;

		public List<Ship> ShipsPose = new List<Ship>();


		public GameService(IGameRepository gameRepository, IUserService userService, IIAService iIAService)
		{
			_gameRepository = gameRepository;
			_userService = userService;
			_IIAService = iIAService;
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

			_Game.Ship2Number = 1;
			_Game.Ship3Number = 2;
			_Game.Ship4Number = 2;
			_Game.Ship5Number = 1;

			_Game.Date = DateTime.Now;

			_Game.PlacedShips = 0;

			return _gameRepository.setNewGame(_Game);
		}

        public Game GetGame(int id) => _gameRepository.getGame(id);

        public static Game GetInstanceGame() => _Game;

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
				stats.Add(new PlayerStatisticsModel(g.Player.UserName, g.Result, g.PlayerShootsNumber, g.IAShootsNumber, g.IA.LevelStrategy.GetName(), g.Duration));
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
				stats.Add(new PlayerStatisticsModel(g.Player.UserName, g.Result, g.PlayerShootsNumber, g.IAShootsNumber, g.IA.LevelStrategy.GetName(), g.Duration));
			}

			return stats;
		}

		public Game UpdateGame(Game game)
        {
			return _Game = _gameRepository.UpdateGame(game);
        }

		public Game SetGameIA(string level) //todo faire que la game courante l'ia soit set en fonction de la difficulté
		{
			IA ia = new IA();
			_Game.IA = ia;

			if (level == "facile") {
				_IIAService.SetLevelStrategy(new LevelStrategyEasy());
			}
			else if (level == "moyen") {
				_IIAService.SetLevelStrategy(new LevelStrategyMedium());
			}

			return _Game;
        }

		public bool TryShoot(Position position)
        {
			return _IIAService.Shoot(position); //TODO c'est gameStage() qu'il faut appeler pour tirer IA
        }

		public Game AddPosToShootList(int playerOrIA, Position pos)
        {
			if(playerOrIA == 1)
            {
				_Game.PlayerShoots.Add(pos);
				_Game.PlayerShootsNumber++;
				return _gameRepository.UpdateGame(_Game);
            }
            else
            {
				_Game.IAShoots.Add(pos);
				_Game.IAShootsNumber++;
				return _gameRepository.UpdateGame(_Game);
            }

        }
	}
}

