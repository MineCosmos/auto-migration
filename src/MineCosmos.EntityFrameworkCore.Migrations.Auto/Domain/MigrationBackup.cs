using System.ComponentModel.DataAnnotations.Schema;

namespace MineCosmos.EntityFrameworkCore.Migrations.Auto.Domain;

[Table("__MigrationBackup")]
public class MigrationBackup
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string MigrationDetailId { get; set; } = string.Empty;
    public MigrationDetail? MigrationDetail { get; set; }
    public string BackupName { get; set; } = string.Empty;
}