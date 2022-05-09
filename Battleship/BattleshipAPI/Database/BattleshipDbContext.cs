using System;
using Microsoft.EntityFrameworkCore;
using Battleship.Model.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BattleshipAPI.Database
{
    public class BattleshipDbContext : IdentityDbContext<ApplicationUser>
    {
        public BattleshipDbContext(DbContextOptions<BattleshipDbContext> options) : base(options)
        {
        }
    }
}

