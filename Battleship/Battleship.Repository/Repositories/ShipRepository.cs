using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.Model.Entities;
using Battleship.Repository.DBContext;
using Battleship.Repository.Interfaces;
using BattleshipAPI.Database;

namespace Battleship.Repository.Repositories
{
	public class ShipRepository : IShipRepository
	{
		private BattleshipDbContext _ctx;

		public ShipRepository(BattleshipDbContext ctx)
		{
			_ctx = ctx;
		}
	}
}

