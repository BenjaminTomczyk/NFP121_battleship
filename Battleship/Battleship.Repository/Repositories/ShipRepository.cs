using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.Model.Entities;
using Battleship.Repository.DBContext;
using Battleship.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Battleship.Repository.Repositories
{
	public class ShipRepository : IShipRepository
	{
		private BattleshipDbContext _ctx;

		public ShipRepository(BattleshipDbContext ctx)
		{
			_ctx = ctx;
		}

		public Ship AddShip(Ship ship)
        {
			_ctx.Ship.Add(ship);
			_ctx.SaveChanges();

			return _ctx.Ship.First(s => s.Id == ship.Id);
		}

		public IQueryable<Ship> GetShips(Game game)
        {
			return _ctx.Ship.Include(s => s.Game).Where(s => s.Game.Id == game.Id);
		}
	}
}

