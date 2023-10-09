using System.ComponentModel;

namespace MineCosmos.EntityFrameworkCore.Migrations.Auto.Enums;

public enum MigrationType
{
    [Description("正常")]
    Normal = 0,
    [Description("尝试")]
    Try,
    [Description("跳过")]
    Skip,
    [Description("链接")]
    Link
}

public enum MigrationResult
{
    [Description("成功")]
    Success = 0,
    [Description("失败")]
    Fail
}