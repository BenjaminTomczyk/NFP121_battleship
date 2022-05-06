using System;
using Microsoft.EntityFrameworkCore;
using Battleship.Model.Entities;

namespace BattleshipAPI.Database
{
	public class BattleshipDbContext : DbContext
	{
		public DbSet<Ship> Ships { get; set; }

		public BattleshipDbContext(DbContextOptions<BattleshipDbContext> ctx) : base(ctx)
        {
			
        }
	}
}

