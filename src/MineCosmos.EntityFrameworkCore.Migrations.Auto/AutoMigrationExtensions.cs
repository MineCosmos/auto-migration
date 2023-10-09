using Microsoft.EntityFrameworkCore;

namespace MineCosmos.EntityFrameworkCore.Migrations.Auto;

public static class AutoMigrationExtensions
{
    public static DbContextOptionsBuilder UseAutoMigration(this DbContextOptionsBuilder optionsBuilder
        , MigrationMode migrationMode = MigrationMode.Produce)
    {

        if (migrationMode == MigrationMode.Design)
        {

        }

        if (migrationMode == MigrationMode.Produce)
        {

        }

        if (migrationMode == MigrationMode.Release)
        {

        }

        return optionsBuilder;
    }
}
