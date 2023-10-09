using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MineCosmos.EntityFrameworkCore.Migrations.Auto.Domain;

[Table("__EFMigrationsHistory")]
internal class EfMigrationsHistory
{
    [Key]
    [MaxLength(150)]
    public string MigrationId { get; set; } = string.Empty;

    [MaxLength(32)]
    public string ProductVersion { get; set; } = string.Empty;

    [NotMapped]
    public string Sort => MigrationId.Split("_")[0];
}