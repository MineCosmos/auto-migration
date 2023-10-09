namespace MineCosmos.EntityFrameworkCore.Migrations.Auto.Common;

public interface IEntity
{
    string Id { get; set; }
    
    DateTime CreateTime { get; set; }
}