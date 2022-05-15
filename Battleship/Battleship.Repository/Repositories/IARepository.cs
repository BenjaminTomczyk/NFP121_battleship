using System;
using Battleship.Repository.DBContext;
using Battleship.Repository.Interfaces;

namespace Battleship.Repository.Repositories
{
	public class IARepository : IIARepository
	{
		private BattleshipDbContext _ctx;

		public IARepository(BattleshipDbContext ctx)
		{
			_ctx = ctx;
		}
	}
}

