using Battleship.Repository.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class DesignTimeDbContextFactory :
        IDesignTimeDbContextFactory<BattleshipDbContext>
{
    public BattleshipDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var builder = new DbContextOptionsBuilder<BattleshipDbContext>();
        var connectionString = "Server=localhost;Port=3306;Database=Battleship;Uid=Battleship;Pwd=Battleship;";
        builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly("BattleshipAPI"));

        return new BattleshipDbContext(builder.Options);
    }
}