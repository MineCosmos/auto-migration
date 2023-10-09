using System.Diagnostics.CodeAnalysis;

namespace MineCosmos.EntityFrameworkCore.Migrations.Auto;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class TryMigrationAttribute : Attribute
{

}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class SkipMigrationAttribute : Attribute
{

}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class LinkMigrationAttribute : Attribute
{
    private int _order = 0;
    public LinkMigrationAttribute(int order)
    {
        _order = order;
    }

    [NotNull]
    public int Order => _order;
}