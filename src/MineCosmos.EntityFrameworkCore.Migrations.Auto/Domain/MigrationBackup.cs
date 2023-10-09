using System.ComponentModel.DataAnnotations.Schema;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.Common;

namespace MineCosmos.EntityFrameworkCore.Migrations.Auto.Domain;

[Table("__MigrationBackup")]
public class MigrationBackup:IEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime CreateTime { get; set; } = DateTime.Now;
    public string MigrationDetailId { get; set; } = string.Empty;
    public MigrationDetail? MigrationDetail { get; set; }
    public string BackupName { get; set; } = string.Empty;
}