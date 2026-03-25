using System.ComponentModel;

namespace SSY.Web.Core.Controllers.System
{
    [ApiDescriptionSettings("System", Tag = "角色管理")]
    [Route("Role")]
    public class RoleControllers : IDynamicApiController
    {
        private readonly IRoleService _roleService;
        public RoleControllers(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetRoleList")]
        public async Task<dynamic> GetRoleList([FromQuery] GetRoleListReq req)
        {
            return await _roleService.GetRoleList(req);
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddRole")]
        [DisplayName("添加角色")]
        public async Task<dynamic> AddRole([FromBody] AddRoleReq req)
        {
            return await _roleService.AddRole(req);
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpdateRole")]
        [DisplayName("修改角色")]
        public async Task<dynamic> UpdateRole([FromBody] UpdateRoleReq req)
        {
            return await _roleService.UpdateRole(req);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <returns></returns>
        [HttpPost("DelRole")]
        [DisplayName("删除角色")]
        public async Task<dynamic> DelRole([FromBody] RoleId req)
        {
            return await _roleService.DelRole(req);
        }

        /// <summary>
        /// 分配权限
        /// </summary>
        /// <returns></returns>
        [HttpPost("AssignPermissions")]
        [DisplayName("分配权限")]
        public async Task<dynamic> AssignPermissions([FromBody] AssignPermissionsReq req)
        {
            return await _roleService.AssignPermissions(req);
        }

        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetRoleMenuList")]
        public async Task<dynamic> GetRoleMenuList([FromQuery] RoleId req)
        {
            return await _roleService.GetRoleMenuList(req);
        }
    }
}
