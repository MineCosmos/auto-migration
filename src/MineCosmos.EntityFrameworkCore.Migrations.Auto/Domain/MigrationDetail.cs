using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.Common;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.Enums;

namespace MineCosmos.EntityFrameworkCore.Migrations.Auto.Domain;

[Table("__MigrationDetail")]
public class MigrationDetail:IEntity
{
    [Comment("MigrationId")]
    public string Id { get; set; } = string.Empty;

    public DateTime CreateTime { get; set; }

    [MaxLength(100)]
    public string Version { get; set; } = string.Empty;
    public DateTime MigrationTime { get; set; } = DateTime.Now;
    public string? Description { get; set; }
    public MigrationType Type { get; set; } = MigrationType.Normal;
    public MigrationResult Result { get; set; } = MigrationResult.Success;

    public ICollection<MigrationLink> MigrationLinks { get; set; } = new List<MigrationLink>();
    public ICollection<MigrationBackup> MigrationBackups { get; set; } = new List<MigrationBackup>();
}