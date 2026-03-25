namespace SSY.Core;

/// <summary>
/// 短信服务接口
/// </summary>
public interface ISmsService : ISingleton
{
    Task<bool> SendCodeAsync(string phoneNumber, string templateCode, object templateParam);
}
