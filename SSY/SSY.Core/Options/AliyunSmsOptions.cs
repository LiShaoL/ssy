using Furion.ConfigurableOptions;

namespace SSY.Core;

public class AliyunSmsOptions : IConfigurableOptions
{
    public string SignName { get; set; }
    public string AccessKeyId { get; set; }
    public string AccessKeySecret { get; set; }
    public string Endpoint { get; set; }
    public Templates templates { get; set; }
}

public class Templates
{
    public string LoginCode { get; set; }
}
