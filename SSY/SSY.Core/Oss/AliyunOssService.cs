using Aliyun.OSS;
using Microsoft.Extensions.Options;

namespace SSY.Core;

public class AliyunOssService : IOssService
{
    private readonly OssClient _client;
    private readonly AliyunOssOptions _aliyunOssOptions;
    public AliyunOssService(IOptions<AliyunOssOptions> aliyunOssOptions)
    {
        _aliyunOssOptions = aliyunOssOptions.Value;

        _client = new OssClient(
        _aliyunOssOptions.Endpoint,
        _aliyunOssOptions.AccessKeyId,
        _aliyunOssOptions.AccessKeySecret);
    }

    /// <summary>
    /// 删除阿里云OSS上的文件
    /// </summary>
    /// <param name="objectName"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task DeleteAsync(string objectName)
    {
        await Task.Run(() =>
        {
            _client.DeleteObject(_aliyunOssOptions.BucketName, objectName);
        });
    }

    /// <summary>
    /// 下载阿里云OSS上的文件
    /// </summary>
    /// <param name="objectName"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Stream> DownloadAsync(string objectName)
    {
        return await Task.Run(() =>
        {
            var result = _client.GetObject(_aliyunOssOptions.BucketName, objectName);
            return result.Content;
        });
    }

    /// <summary>
    /// 上传文件到阿里云OSS
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="objectName"></param>
    /// <param name="contentType"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<string> UploadAsync(Stream stream, string objectName)
    {
        await Task.Run(() =>
        {
            _client.PutObject(_aliyunOssOptions.BucketName, objectName, stream);
        });

        return $"https://{_aliyunOssOptions.BucketName}.{_aliyunOssOptions.Endpoint}/{objectName}";
    }
}
