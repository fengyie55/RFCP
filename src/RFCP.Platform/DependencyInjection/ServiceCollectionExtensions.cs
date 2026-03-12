using Microsoft.Extensions.DependencyInjection;
using RFCP.Platform.Alarm;
using RFCP.Platform.Configuration;
using RFCP.Platform.Logging;
using RFCP.Platform.Permissions;
using RFCP.Platform.Records;

namespace RFCP.Platform.DependencyInjection;

/// <summary>
/// Registers RFCP platform cross-cutting services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds platform services to DI container.
    /// </summary>
    public static IServiceCollection AddRfcpPlatformServices(this IServiceCollection services)
    {
        services.AddSingleton<ILogService, LogService>();
        services.AddSingleton<IAlarmManager, AlarmManager>();
        services.AddSingleton<IPermissionManager, PermissionManager>();
        services.AddSingleton<IConfigurationManager, ConfigurationManager>();
        services.AddSingleton<IOperationRecordService, OperationRecordService>();
        services.AddSingleton<IProcessingRecordService, ProcessingRecordService>();
        return services;
    }
}
