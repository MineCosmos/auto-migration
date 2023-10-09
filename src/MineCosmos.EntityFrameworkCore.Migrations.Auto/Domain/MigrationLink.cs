using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MineCosmos.EntityFrameworkCore.Migrations.Auto.Domain;

[Table("__MigrationLink")]
public class MigrationLink
{
    [Key]
    public string Id { get; set; } = String.Empty;

    public string MigrationDetailId { get; set; } = string.Empty;
    public MigrationDetail? MigrationDetail { get; set; }
}