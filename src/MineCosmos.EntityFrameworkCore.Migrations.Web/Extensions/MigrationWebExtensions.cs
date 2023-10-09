using Microsoft.AspNetCore.Builder;

namespace MineCosmos.EntityFrameworkCore.Migrations.Web.Extensions;

public static class MigrationWebExtensions
{
    public static IApplicationBuilder UseMigrationWeb(this IApplicationBuilder app)
    {
        //app.UseBlazorFrameworkFiles();
        
        return app;
    }
}