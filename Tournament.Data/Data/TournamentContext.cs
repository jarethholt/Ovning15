using Microsoft.EntityFrameworkCore;
using Tournament.Core.Entities;

namespace Tournament.Data.Data;

public class TournamentContext : DbContext
{
    public DbSet<Game> Game { get; set; }
    public DbSet<Core.Entities.Tournament> Tournament { get; set; }

    public TournamentContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=tournament.db");
    }
}
