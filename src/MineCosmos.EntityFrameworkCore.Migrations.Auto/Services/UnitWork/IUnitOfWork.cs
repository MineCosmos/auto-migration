using MineCosmos.EntityFrameworkCore.Migrations.Auto.DbContexts;

namespace MineCosmos.EntityFrameworkCore.Migrations.Auto.Services.UnitWork;

internal interface IUnitOfWork
{
    Task<bool> CommitAsync();
}

internal class UnitOfWork: IUnitOfWork
{
    private readonly MigrationDbContext _db;

    public UnitOfWork(MigrationDbContext db)
    {
        _db = db;
    }
    public async Task<bool> CommitAsync()
    {
        return await _db.SaveChangesAsync() > 0;
    }
}