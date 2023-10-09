using Microsoft.EntityFrameworkCore;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.Domain;

namespace MineCosmos.EntityFrameworkCore.Migrations.Auto.DbContexts;

public class AutoMigration<T>: DbContext where T : DbContext
{
    public AutoMigration(DbContextOptions<T> options):base(options)
    {
        
    }
    
    internal DbSet<EfMigrationsHistory> EfMigrationsHistories { get; set; } = null!;
}