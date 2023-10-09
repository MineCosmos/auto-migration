using MineCosmos.EntityFrameworkCore.Migrations.Auto.Common;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.Domain;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.Services.Base;

namespace MineCosmos.EntityFrameworkCore.Migrations.Auto.Services;

public interface IMigrationService
{
    Task<MigrationDetail?> GetMigrationDetailAsync(string id);
    Task<MigrationBackup?> GetMigrationBackupAsync(string id);
    Task<MigrationLink?> GetMigrationLinkAsync(string id);
    
    Task<PagedList<MigrationDetail>> GetMigrationDetailsAsync(MigrationParameter? parameter = null);
    Task<PagedList<MigrationBackup>> GetMigrationBackupsAsync(MigrationParameter? parameter = null);
    Task<PagedList<MigrationLink>> GetMigrationLinksAsync(MigrationParameter? parameter = null);
}

public sealed class MigrationService : IMigrationService
{
    private readonly IAutoMigrationService<MigrationDetail> _migrationDetailService;
    private readonly IAutoMigrationService<MigrationBackup> _migrationBackupService;
    private readonly IAutoMigrationService<MigrationLink> _migrationLinkService;

    public MigrationService(
        IAutoMigrationService<MigrationDetail> migrationDetailService
        ,IAutoMigrationService<MigrationBackup> migrationBackupService
        ,IAutoMigrationService<MigrationLink> migrationLinkService)
    {
        _migrationDetailService = migrationDetailService;
        _migrationBackupService = migrationBackupService;
        _migrationLinkService = migrationLinkService;
    }

    public async Task<MigrationDetail?> GetMigrationDetailAsync(string id)
    {
        return  await _migrationDetailService.GetAsync(id);
    }

    public async Task<MigrationBackup?> GetMigrationBackupAsync(string id)
    {
        return await _migrationBackupService.GetAsync(id);
    }

    public async Task<MigrationLink?> GetMigrationLinkAsync(string id)
    {
        return await _migrationLinkService.GetAsync(id);
    }

    public async Task<PagedList<MigrationDetail>> GetMigrationDetailsAsync(MigrationParameter? parameter = null)
    {
        return await _migrationDetailService.GetListAsync(parameter);
    }

    public async Task<PagedList<MigrationBackup>> GetMigrationBackupsAsync(MigrationParameter? parameter = null)
    {
        return await _migrationBackupService.GetListAsync(parameter);
    }

    public async Task<PagedList<MigrationLink>> GetMigrationLinksAsync(MigrationParameter? parameter = null)
    {
        return await _migrationLinkService.GetListAsync(parameter);
    }
}