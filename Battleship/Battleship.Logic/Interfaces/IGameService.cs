using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleship.Model.Entities;

namespace Battleship.Logic.Interfaces
{
	public interface IGameService
	{
		string SetIA();

		Task<Game> StartGame(string id);

		Game GetGame(int id);

		List<PlayerStatisticsModel> GetUserHistory(string id);

		List<PlayerStatisticsModel> GetFullHistory();
	}
}

