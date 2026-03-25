using Furion.ConfigurableOptions;

namespace SSY.Core;
public class AliyunOssOptions: IConfigurableOptions
{
    public string AccessKeyId { get; set; }
    public string AccessKeySecret { get; set; }
    public string Endpoint { get; set; }
    public string BucketName { get; set; }
}

