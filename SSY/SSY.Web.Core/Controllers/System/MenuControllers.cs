using System.ComponentModel;

namespace SSY.Web.Core.Controllers.System
{
    [ApiDescriptionSettings("System", Tag = "菜单管理")]
    [Route("Menu")]
    public class MenuControllers : IDynamicApiController
    {
        private readonly IMenuService  _menuService;
        public MenuControllers(IMenuService menuService)
        {
            _menuService = menuService;
        }

        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetMenuList")]
        public async Task<dynamic> GetMenuList([FromQuery]GetMenuListReq req)
        {
            return await _menuService.GetMenuList(req);
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddMenu")]
        [DisplayName("添加菜单")]
        public async Task<dynamic> AddMenu([FromBody]AddMenuReq req)
        {
            return await _menuService.AddMenu(req);
        }

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpdateMenu")]
        [DisplayName("修改菜单")]
        public async Task<dynamic> UpdateMenu([FromBody] UpdateMenuReq req)
        {
            return await _menuService.UpdateMenu(req);
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost("DelMenu")]
        [DisplayName("删除菜单")]
        public async Task<dynamic> DelMenu([FromBody] MenuIdReq req)
        {
            return await _menuService.DelMenu(req);
        }
    }
}
