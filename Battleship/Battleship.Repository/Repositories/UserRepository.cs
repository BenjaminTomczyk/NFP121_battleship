using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.Model.Entities;
using Battleship.Repository.DBContext;
using Battleship.Repository.Interfaces;

namespace Battleship.Repository.Repositories
{
	public class UserRepository : IUserRepository
	{
		private BattleshipDbContext _ctx;

		public UserRepository(BattleshipDbContext ctx)
		{
			_ctx = ctx;
		}

		public List<Game> GetUserHistory(string id)
        {
			return _ctx.Game.Where(c => c.Player.Id == id).ToList();
		}
	}
}

