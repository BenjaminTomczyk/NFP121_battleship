using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.Model.Entities;
using Battleship.Repository.DBContext;
using Battleship.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Battleship.Repository.Repositories
{
	public class GameRepository : IGameRepository
	{
		private BattleshipDbContext _ctx;

		public GameRepository(BattleshipDbContext ctx)
		{
			_ctx = ctx;
		}

        public Game setNewGame(Game game)
        {
			_ctx.Game.Add(game);
			_ctx.SaveChanges();

			return getGame(game.Id);
		}

		public Game getGame(int id)
        {
			return _ctx.Game.Include(p => p.Player).Include(i => i.ShipsPose)//.Include(i => i.PlayerShoots)//.Include(i => i.PositionsInvalid)
				.First(g => g.Id == id);
		}

		public IQueryable<Game> getHistory()
        {
			return _ctx.Game.Include(p => p.Player);
		}

        public Game UpdateGame(Game game)
        {
            Game g = _ctx.Game.First(s => s.Id == game.Id);
            g = game;
            _ctx.SaveChanges();
            return g;
        }
	}
}

