using Microsoft.EntityFrameworkCore;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.Common;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.DbContexts;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.Extensions;

namespace MineCosmos.EntityFrameworkCore.Migrations.Auto.Services.Base;

public class MigrationParameter
{
    public int? Page { get; set; }
    public int? PageSize { get; set; }
    public DateTime? MinDate { get; set; }
    public DateTime? MaxDate { get; set; }
}

internal interface IMigrationService<T> where T:class, IEntity
{
    Task<PagedList<T>> GetListAsync(MigrationParameter? parameter = null);

    Task<T?> GetAsync(string id);

    IQueryable<T> Query();
}

internal class MigrationService<T>:IMigrationService<T> where T:class, IEntity
{
    private readonly MigrationDbContext _db;

    public MigrationService(MigrationDbContext db)
    {
        _db = db;
    }

    public async Task<PagedList<T>> GetListAsync(MigrationParameter? parameter = null)
    {
       var res = await Query().WhereIfNotNull(parameter?.MinDate, x => x.CreateTime.Date > parameter!.MinDate)
         .WhereIfNotNull(parameter?.MaxDate, x => x.CreateTime.Date <= parameter!.MaxDate)
         .OrderByDescending(x=>x.CreateTime).ToPagedListAsync(parameter);
       return res;
    }

    public async Task<T?> GetAsync(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return default;
        
        return await Query().FirstOrDefaultAsync(x => x.Id == id);
    }

    public IQueryable<T> Query()
    {
        return _db.Set<T>().AsQueryable();
    }
}

