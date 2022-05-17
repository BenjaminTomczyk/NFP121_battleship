using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleship.Model.Entities;

namespace Battleship.Logic.Interfaces
{
	public interface IGameService
	{
		Task<Game> StartGame(string id);

		Game GetGame(int id);

		List<PlayerStatisticsModel> GetUserHistory(string id);

		List<PlayerStatisticsModel> GetFullHistory();

		Game UpdateGame(Game game);

		Game SetGameIA(string level);

		Explosion UserShoot(Position position);

		Explosion IAShoot();

		Game AddPosToShootList(string name, Explosion exp);

		Game AddShip(Ship ship);

		Game VerifEndGame();
	}
}

