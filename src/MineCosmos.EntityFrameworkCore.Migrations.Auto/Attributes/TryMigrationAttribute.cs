using System.Diagnostics.CodeAnalysis;

namespace MineCosmos.EntityFrameworkCore.Migrations.Auto.Attributes;

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
    public LinkMigrationAttribute(int order)
    {
        Order = order;
    }

    [NotNull]
    public int Order { get; } = 0;
}