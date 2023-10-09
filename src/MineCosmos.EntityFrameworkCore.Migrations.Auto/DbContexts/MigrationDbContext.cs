using Microsoft.EntityFrameworkCore;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.Domain;

namespace MineCosmos.EntityFrameworkCore.Migrations.Auto.DbContexts;

internal class MigrationDbContext:DbContext
{
    public DbSet<MigrationDetail> MigrationDetails { get; set; } = null!;
    public DbSet<MigrationLink> MigrationLinks { get; set; } = null!;
    public DbSet<MigrationBackup> MigrationBackups { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=migration.db");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}