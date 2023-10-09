using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.DbContexts;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.Enums;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.Services;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.Services.Base;

namespace MineCosmos.EntityFrameworkCore.Migrations.Auto;

public static class AutoMigrationExtensions
{
    public static IServiceCollection AddAutoMigration<T>(this IServiceCollection services)
        where T : AutoMigration<T>
    {
        services.AddDbContext<MigrationDbContext>();
        services.AddScoped(typeof(IAutoMigrationService<>), typeof(AutoMigrationService<>));
        services.AddScoped<IMigrationService, MigrationService>();
        services.AddScoped<IMigrationHistoryService<T>, MigrationHistoryService<T>>();
        
        return services;
    }
    
    public static IApplicationBuilder UseAutoMigration<T>(this IApplicationBuilder app
        , MigrationMode migrationMode = MigrationMode.Produce) where T : AutoMigration<T>
    {
        app.InitMigrationDatabase();
        
        using var scoped = app.ApplicationServices.CreateScope();

        var migrationDb = scoped.ServiceProvider.GetRequiredService<MigrationDbContext>();
        try
        {
            migrationDb.Database.EnsureCreated();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        if (migrationMode == MigrationMode.Design)
        {
            var db = scoped.ServiceProvider.GetRequiredService<T>();
            try
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
#if DEBUG
                Trace.WriteLine($"{ex.Message}");
#endif
            }

        }

        if (migrationMode == MigrationMode.Produce)
        {

        }

        if (migrationMode == MigrationMode.Release)
        {

        }

        return app;
    }

    private static void InitMigrationDatabase(this IApplicationBuilder app)
    {
        using var scoped = app.ApplicationServices.CreateScope();
        var db = scoped.ServiceProvider.GetRequiredService<MigrationDbContext>();
        db.Database.EnsureCreated();
    }
}
