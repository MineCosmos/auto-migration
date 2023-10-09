namespace MineCosmos.EntityFrameworkCore.Migrations.Auto;

/// <summary>
/// 迁移类型
/// </summary>
public enum MigrationMode
{
    /// <summary>
    /// 设计阶段, 比较暴力, 将会直接对表结构进行迁移
    /// </summary>
    Design,
    /// <summary>
    /// 生产阶段, 与Release大致相同, 但是缺少一些容错
    /// </summary>
    Produce,
    /// <summary>
    /// 线上阶段, 完整的数据备份, 大量容错
    /// </summary>
    Release
}
