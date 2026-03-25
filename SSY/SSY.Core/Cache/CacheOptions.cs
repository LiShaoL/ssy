using Furion.ConfigurableOptions;
using NewLife.Caching;

namespace SSY.Core;

public class CacheOptions: IConfigurableOptions
{
    /// <summary>
    /// 缓存前缀
    /// </summary>
    public string Prefix { get; set; }

    /// <summary>
    /// 缓存类型
    /// </summary>
    public string CacheType { get; set; }

    /// <summary>
    /// Redis缓存
    /// </summary>
    public RedisOption Redis { get; set; }
}
/// <summary>
/// Redis缓存
/// </summary>
public sealed class RedisOption : RedisOptions
{
    /// <summary>
    /// 最大消息大小
    /// </summary>
    public int MaxMessageSize { get; set; }
    /// <summary>
    /// 自动检测集群节点
    /// </summary>
    public bool AutoDetect { get; set; }
}
