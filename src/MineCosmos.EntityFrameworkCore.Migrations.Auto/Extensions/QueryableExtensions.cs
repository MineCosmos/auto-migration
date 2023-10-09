using System.Linq.Expressions;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.Common;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.Services.Base;

namespace MineCosmos.EntityFrameworkCore.Migrations.Auto.Extensions;

internal static class QueryableExtensions
{
    public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> query, MigrationParameter? parameter)
        where T : IEntity
    {
        return await PagedList<T>.CreateAsync(query, parameter?.Page ?? 1, parameter?.PageSize ?? 20);
    }

    public static IQueryable<T> WhereIf<T>(this IQueryable<T> queryable, bool @if, Expression<Func<T, bool>> exp)
    {
        return @if ? queryable.Where(exp) : queryable;
    }
    
    public static IQueryable<T> WhereIfNotNull<T>(this IQueryable<T> queryable, object? param, Expression<Func<T, bool>> exp)
    {
        return param is not null ? queryable.Where(exp) : queryable;
    }
}