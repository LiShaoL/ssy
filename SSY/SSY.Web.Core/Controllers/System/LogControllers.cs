using System.ComponentModel;

namespace SSY.Web.Core.Controllers.System
{
    [ApiDescriptionSettings("System", Tag = "日志管理")]
    [Route("Log")]
    public class LogControllers : IDynamicApiController
    {
        private readonly ILogService _logService;
        public LogControllers(ILogService logService)
        {
            _logService = logService;
        }

        /// <summary>
        /// 获取登录日志列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetLogVisitList")]
        public async Task<dynamic> GetLogVisitList([FromQuery] GetLogVisitListReq req)
        {
            return await _logService.GetLogVisitList(req);
        }

        /// <summary>
        /// 清空登录日志列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("DelLogVisitList")]
        [DisplayName("清空登录日志")]
        public async Task<dynamic> DelLogVisitList()
        {
            return await _logService.DelLogVisitList();
        }

        /// <summary>
        /// 获取操作日志列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetLogOperateList")]
        public async Task<dynamic> GetLogOperateList([FromQuery] GetLogVisitListReq req)
        {
            return await _logService.GetLogOperateList(req);
        }

        /// <summary>
        /// 清空操作日志列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("DelLogOperateList")]
        [DisplayName("清空操作日志")]
        public async Task<dynamic> DelLogOperateList()
        {
            return await _logService.DelLogOperateList();
        }
    }
}
