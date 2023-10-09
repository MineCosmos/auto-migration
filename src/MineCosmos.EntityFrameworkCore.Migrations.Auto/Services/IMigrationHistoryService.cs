using Microsoft.EntityFrameworkCore;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.DbContexts;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.Domain;

namespace MineCosmos.EntityFrameworkCore.Migrations.Auto.Services;

internal interface IMigrationHistoryService<T>
{
    
}

internal class MigrationHistoryService<T> : IMigrationHistoryService<T>
    where T : AutoMigration<T>
{
    private readonly T _db;

    public MigrationHistoryService(T db)
    {
        _db = db;
    }

    public async Task<IEnumerable<string>> GetAppliedMigrationsAsync()
    {
        return await _db.Database.GetAppliedMigrationsAsync();
    }
    
    public async Task<IEnumerable<string>> GetPendingMigrationsAsync()
    {
        return await _db.Database.GetPendingMigrationsAsync();
    }
}