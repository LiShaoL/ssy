namespace SSY.System;
/// <summary>
/// 菜单管理
/// </summary>
public class MenuService : IMenuService
{
    private readonly DbRepository<SysMenu> _sysMenu;
    public MenuService(DbRepository<SysMenu> sysMenu)
    {
        _sysMenu = sysMenu;
    }
    /// <summary>
    /// 添加菜单
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> AddMenu(AddMenuReq req)
    {
        var menu = req.Adapt<SysMenu>();
        menu.Id = CommonUtils.GetSingleId();
        menu.IsDelete = 0;
        menu.CreateTime = DateTime.Now;
        return await _sysMenu.InsertAsync(menu);
    }

    /// <summary>
    /// 删除菜单
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> DelMenu(MenuIdReq req)
    {
        return await _sysMenu.AsUpdateable()
            .SetColumns(o => o.IsDelete == 1)
            .Where(o => o.Id == req.Id)
            .ExecuteCommandAsync() > 0;
    }

    /// <summary>
    /// 获取菜单列表
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> GetMenuList(GetMenuListReq req)
    {
        var openlist = await _sysMenu.AsQueryable()
            .WhereIF(!string.IsNullOrEmpty(req.Title), o => o.Title.Contains(req.Title))
            .WhereIF(!string.IsNullOrEmpty(req.Path), o => o.Path.Contains(req.Path))
            .Where(o => o.IsDelete == 0).ToListAsync();
        return openlist;
    }

    /// <summary>
    /// 修改菜单
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> UpdateMenu(UpdateMenuReq req)
    {
        var menu = req.Adapt<SysMenu>();
        menu.UpdateTime = DateTime.Now;
        return await _sysMenu.AsUpdateable(menu).IgnoreColumns(o => new { o.CreateTime, o.IsDelete, o.Name }).ExecuteCommandAsync() > 0;
    }
}
