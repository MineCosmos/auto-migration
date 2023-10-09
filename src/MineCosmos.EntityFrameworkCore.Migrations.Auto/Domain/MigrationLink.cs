using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.Common;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.Enums;

namespace MineCosmos.EntityFrameworkCore.Migrations.Auto.Domain;

[Table("__MigrationLink")]
public class MigrationLink:IEntity
{
    public string Id { get; set; } = String.Empty;
    public DateTime CreateTime { get; set; }

    public string MigrationDetailId { get; set; } = string.Empty;
    public MigrationDetail? MigrationDetail { get; set; }
    public DateTime MigrationTime { get; set; } = DateTime.Now;
    public string? Description { get; set; }
    public MigrationType Type { get; set; } = MigrationType.Normal;
    public MigrationResult Result { get; set; } = MigrationResult.Success;
}