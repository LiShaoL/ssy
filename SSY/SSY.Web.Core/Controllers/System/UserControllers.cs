using System.ComponentModel;

namespace SSY.Web.Core.Controllers.System
{
    [ApiDescriptionSettings("System", Tag = "用户管理")]
    [Route("User")]
    public class UserControllers : IDynamicApiController
    {
        private readonly IUserService _userService;
        public UserControllers(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpGet("GetCaptcha")]
        [AllowAnonymous]
        public dynamic GetCaptcha()
        {
            return _userService.GetCaptcha();
        }

        /// <summary>
        /// PC登录
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("PcLogin")]
        [AllowAnonymous]
        [DisplayName("登录")]
        public async Task<dynamic> PcLogin([FromBody] PcLoginReq req)
        {
            return await _userService.PcLogin(req);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUserInfo")]
        public async Task<dynamic> GetUserInfo()
        {
            return await _userService.GetUserInfo();
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUserList")]
        public async Task<dynamic> GetUserList([FromQuery] GetUserListReq req)
        {
            return await _userService.GetUserList(req);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddUser")]
        [DisplayName("添加用户")]
        public async Task<dynamic> AddUser([FromBody] AddUserReq req)
        {
            return await _userService.AddUser(req);
        }

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetRoles")]
        public async Task<dynamic> GetRoles()
        {
            return await _userService.GetRoles();
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpdateUser")]
        [DisplayName("修改用户")]
        public async Task<dynamic> UpdateUser([FromBody] UpdateUserReq req)
        {
            return await _userService.UpdateUser(req);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        [HttpPost("DelUser")]
        [DisplayName("删除用户")]
        public async Task<dynamic> DelUser([FromBody] UserIdReq req)
        {
            return await _userService.DelUser(req);
        }
    }
}
