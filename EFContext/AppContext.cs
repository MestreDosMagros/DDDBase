using Dominio;
using Microsoft.EntityFrameworkCore;

namespace EFContext;

public class AppContext : DbContext
{
    public DbSet<Pessoa> Pessoas { get; set; }

    public AppContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
