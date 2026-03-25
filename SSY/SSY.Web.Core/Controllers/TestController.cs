using Furion.FriendlyException;
using Microsoft.Extensions.Options;
using System.ComponentModel;

namespace SSY.Web.Core.Controllers
{
    [Route("Test")]
    public class TestController : IDynamicApiController
    {
        private readonly IOssService _aliyunOssService;
        private readonly ISmsService _smsService;
        private readonly AliyunSmsOptions _aliyunSmsOptions;
        public TestController(IOssService aliyunOssService, ISmsService smsService, IOptions<AliyunSmsOptions> aliyunSmsOptions)
        {
            _aliyunOssService = aliyunOssService;
            _smsService = smsService;
            _aliyunSmsOptions = aliyunSmsOptions.Value;
        }

        /// <summary>
        /// 测试文件上传file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("UploadFile")]
        [DisplayName("文件上传")]
        public async Task<string> UploadFileBy(IFormFile file)
        {
            if (file == null) throw Oops.Bah("文件不存在");
            var datePath = DateTime.Now.ToString("yyyy/MM");
            var fileName = $"{Guid.NewGuid().ToString("N")}{Path.GetExtension(file.FileName)}";
            var objectName = $"{datePath}/{fileName}";
            var path = await _aliyunOssService.UploadAsync(file.OpenReadStream(), objectName);
            return path;
        }

        /// <summary>
        /// 测试发短信
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpPost("SendSms")]
        [DisplayName("测试发短信")]
        public async Task<bool> SendSms(string phone)
        {
            var result = await _smsService.SendCodeAsync(phone, _aliyunSmsOptions.templates.LoginCode, new { code = "111111" });
            if (!result) throw Oops.Bah("发送失败");
            return result;
        }
    }
}
