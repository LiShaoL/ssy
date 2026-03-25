using AlibabaCloud.OpenApiClient.Models;
using AlibabaCloud.SDK.Dysmsapi20170525;
using AlibabaCloud.SDK.Dysmsapi20170525.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace SSY.Core;

public class AliyunSmsService : ISmsService
{
    private readonly AliyunSmsOptions _options;
    private readonly Lazy<Client> _client;
    public AliyunSmsService(IOptions<AliyunSmsOptions> options)
    {
        _options = options.Value;

        _client = new Lazy<Client>(CreateClient);
    }

    private Client CreateClient()
    {
        var config = new Config
        {
            AccessKeyId = _options.AccessKeyId,
            AccessKeySecret = _options.AccessKeySecret,
            Endpoint = _options.Endpoint
        };
        return new Client(config);
    }

    /// <summary>
    /// 异步发送短信
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <param name="templateCode"></param>
    /// <param name="templateParam"></param>
    /// <returns></returns>
    public async Task<bool> SendCodeAsync(string phoneNumber, string templateCode, object templateParam)
    {
        var request = new SendSmsRequest
        {
            PhoneNumbers = phoneNumber,
            SignName = _options.SignName,
            TemplateCode = templateCode,
            TemplateParam = JsonSerializer.Serialize(templateParam)
        };

        try
        {
            var response = await _client.Value.SendSmsAsync(request);

            if (response?.Body?.Code == "OK")
                return true;

            // 记录日志
            Log.Information($"短信发送失败，电话：{phoneNumber},理由：{response?.Body?.Message}");
            return false;
        }
        catch (Exception ex)
        {
            Log.Information($"短信发送异常：{ex.Message}");
            return false;
        }
    }
}
