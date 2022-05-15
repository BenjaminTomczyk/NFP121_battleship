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

		public string SetIALevels()
        {
            //var ia = _ctx.IA.ToList();
            //if (!ia.Any())
            //{
            //    //_ctx.IA.Add(new IA(1, "Facile"));
            //    //_ctx.IA.Add(new IA(2, "Moyen"));
            //    //_ctx.SaveChanges();

            //    return "Created";
            //}
            //else
            //{
            //    var ia1 = _ctx.IA.First(c => c.Id == 1);
            //    var ia2 = _ctx.IA.First(c => c.Id == 2);
            //    ia1.Id = 1;
            //    ia1.Level = "Facile";
            //    ia2.Id = 2;
            //    ia2.Level = "Moyen";
            //    _ctx.SaveChanges();


                return "Updated";
            //}
        }

        public Game setNewGame(Game game)
        {
			_ctx.Game.Add(game);
			_ctx.SaveChanges();

			return _ctx.Game.First(c => c.Id == game.Id);
		}

		public Game getGame(int id)
        {
			return _ctx.Game.Include(p => p.Player).First(g => g.Id == id);
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

