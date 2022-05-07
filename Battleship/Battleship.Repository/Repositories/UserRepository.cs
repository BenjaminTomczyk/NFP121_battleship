using System;
using Battleship.Model.Entities;
using Battleship.Repository.Interfaces;
using BattleshipAPI.Database;

namespace Battleship.Repository.Repositories
{
	public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
	{
		public UserRepository(BattleshipDbContext ctx): base(ctx)
		{
		}
	}
}

