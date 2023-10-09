using Microsoft.EntityFrameworkCore;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.DbContexts;

namespace AutoSample.Data;

public class SampleDbContext : AutoMigration<SampleDbContext>
{
    public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
