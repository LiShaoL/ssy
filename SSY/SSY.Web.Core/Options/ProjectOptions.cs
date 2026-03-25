namespace SSY.Web.Core;

public static class ProjectOptions
{
    /// <summary>
    /// 注册项目配置选项
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddProjectOptions(this IServiceCollection services)
    {
        services.AddConfigurableOptions<WebSettingsOptions>();
        services.AddConfigurableOptions<CacheOptions>();
        services.AddConfigurableOptions<AliyunOssOptions>(); 
        services.AddConfigurableOptions<AliyunSmsOptions>();
        return services;
    }
}
