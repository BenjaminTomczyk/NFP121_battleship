using System;
using System.Linq;
using Battleship.Model.Entities;
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

		public IA UpdateIA(IA ia)
		{
			IA i = _ctx.IA.First(s => s.Id == ia.Id);
			i = ia;
			_ctx.SaveChanges();
			return i;
		}
	}
}

