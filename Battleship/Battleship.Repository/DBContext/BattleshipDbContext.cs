using System;
using Microsoft.EntityFrameworkCore;
using Battleship.Model.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Battleship.Repository.DBContext
{
    public class BattleshipDbContext : IdentityDbContext<ApplicationUser>
    {
        public BattleshipDbContext(DbContextOptions<BattleshipDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Game { get; set; }
        public DbSet<Ship> Ship { get; set; }
        public DbSet<IA> IA { get; set; }
    }
}