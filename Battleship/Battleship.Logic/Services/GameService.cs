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

			_Game.IA = new IA();
			
			_Game.ShipsPose = new List<Ship>();

			_Game.PlayerShoots = new List<Explosion>();

			_Game.PositionsInvalid = new List<Position>();

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
				PlayerStatisticsModel p = new PlayerStatisticsModel();
				p.Player = g.Player.UserName;
				p.Result = g.Result;
				p.PlayerShootsNumber = g.PlayerShootsNumber;
				p.IAShootsNumber = g.IAShootsNumber;
				p.IA = "Facile";//g.IA.Level;
				p.Duration = g.Duration;

				stats.Add(p);
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
				PlayerStatisticsModel p = new PlayerStatisticsModel();
				p.Player = g.Player.UserName;
				p.Result = g.Result;
				p.PlayerShootsNumber = g.PlayerShootsNumber;
				p.IAShootsNumber = g.IAShootsNumber;
				p.IA = "Facile";//g.IA.Level;
				p.Duration = g.Duration;

				stats.Add(p);
			}
			return stats;
		}

		public Game UpdateGame(Game game)
        {
			return _Game = _gameRepository.UpdateGame(game);
        }

		public Game SetGameIA(string level)
		{

			if (level == "facile") {
				LevelStrategyEasy easy = new LevelStrategyEasy();

				_Game.IA.LevelStrategy = easy;
				_Game.IA.Level = "facile";

				_IIAService.SetLevelStrategy(easy);

				//_IIAService.UpdateIA(_Game.IA);
				UpdateGame(_Game);
				
			}
			else if (level == "moyen") {
				LevelStrategyMedium medium = new LevelStrategyMedium();
				_Game.IA.LevelStrategy = medium;
				_Game.IA.Level = "medium";

				_IIAService.SetLevelStrategy(medium);

				//_IIAService.UpdateIA(_Game.IA);
				UpdateGame(_Game);
			}

			return _Game;
        }

		public bool ShootIsValid(Position position)
        {
			foreach (Explosion oldExplo in _Game.PlayerShoots)
			{
				if (oldExplo.ExplosionLocation.Equals(position))
				{
					return false;
				}
			}
			
			return true;
		}

		public Explosion UserShoot(Position position)
        {
			bool shootResult = false;
			if (ShootIsValid(position))
			{
				foreach (Ship IAShip in _Game.ShipsPose)
				{
					if (IAShip.Player == "IA")
					{
						foreach (Position posIAShip in IAShip.Positions)
						{
							if (position.Equals(posIAShip))
							{
								shootResult = true;
								break;
							}
						}
					}
				}

				Explosion newUserExplosion= new Explosion(position, shootResult);
				AddPosToShootList("User", newUserExplosion);
				return newUserExplosion;
			}
            else
            {
				Explosion newUserExplosion = new Explosion(null, shootResult);
				return newUserExplosion;
			}
		}

		public Game SetIAGrid()
        {
			_Game.ShipsPose.Add(new Ship(new Position(0, 0), new Position(1, 0),new List<Position>(), _Game, "IA", true,2));
			_Game.ShipsPose.Add(new Ship(new Position(0, 2), new Position(2, 2),new List<Position>(), _Game, "IA", true,3));
			_Game.ShipsPose.Add(new Ship(new Position(0, 4), new Position(2, 4), new List<Position>(), _Game, "IA", true,3));
			_Game.ShipsPose.Add(new Ship(new Position(0, 6), new Position(3, 6), new List<Position>(), _Game, "IA", true,4));
			_Game.ShipsPose.Add(new Ship(new Position(4, 4), new Position(7, 7), new List<Position>(), _Game, "IA", true, 4));
			_Game.ShipsPose.Add(new Ship(new Position(3, 0), new Position(7, 4), new List<Position>(), _Game, "IA", true,5));

			return _gameRepository.UpdateGame(_Game);
		}

		public Explosion IAShoot()
        {
			Explosion newIAExplosion = _IIAService.gameStage(_Game);
			AddPosToShootList("IA", newIAExplosion);
			return newIAExplosion;

		}

		public Game VerifEndGame()
        {
			int comptPlayer = 0;
			int comptIA = 0;

			foreach(Explosion exp in _Game.PlayerShoots)
            {
				if (exp.Hit) comptPlayer++;
            }

			foreach (Explosion exp in _Game.IAShoots)
			{
				if (exp.Hit) comptIA++;
			}

			if (comptPlayer == 21)
            {
				_Game.Finished = true;
				_Game.Result = "Gagné";
			}
			else if (comptIA == 21)
            {
				_Game.Finished = true;
				_Game.Result = "Perdu";
			}

			return _gameRepository.UpdateGame(_Game);
		}

		public Game AddPosToShootList(string name, Explosion exp)
        {
			if(name == "User")
            {
				_Game.PlayerShoots.Add(exp);
				_Game.PlayerShootsNumber++;
				return _gameRepository.UpdateGame(_Game);
            }
            else
            {
				_Game.IAShoots.Add(exp);
				_Game.IAShootsNumber++;			
				return _gameRepository.UpdateGame(_Game);
            }

        }

		public Game AddShip(Ship ship)
        {
			_Game.ShipsPose.Add(ship);
			return _gameRepository.UpdateGame(_Game);
        }
	}
}

