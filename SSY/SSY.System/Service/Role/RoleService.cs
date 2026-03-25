namespace SSY.System;

public class RoleService : IRoleService
{
    private readonly DbRepository<SysRoleMenu> _sysRoleMenu;
    private readonly DbRepository<SysRole> _sysRole;
    private readonly DbRepository<SysMenu> _sysMenu;
    public RoleService(DbRepository<SysRoleMenu> sysRoleMenu, DbRepository<SysRole> sysRole, DbRepository<SysMenu> sysMenu)
    {
        _sysRoleMenu = sysRoleMenu;
        _sysRole = sysRole;
        _sysMenu = sysMenu;
    }
    /// <summary>
    /// 添加角色
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> AddRole(AddRoleReq req)
    {
        var role = req.Adapt<SysRole>();
        role.Id = CommonUtils.GetSingleId();
        role.CreateTime = DateTime.Now;
        return await _sysRole.InsertAsync(role);
    }

    /// <summary>
    /// 分配权限
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> AssignPermissions(AssignPermissionsReq req)
    {
        //删除原有权限
        await _sysRoleMenu.DeleteAsync(o => o.RoleId == req.Id);
        //添加新权限
        List<SysRoleMenu> sysRoleMenus = new List<SysRoleMenu>();
        foreach (var item in req.MenuIds)
        {
            SysRoleMenu sysRoleMenu = new SysRoleMenu();
            sysRoleMenu.Id = CommonUtils.GetSingleId();
            sysRoleMenu.RoleId = req.Id;
            sysRoleMenu.MenuId = item;
            sysRoleMenus.Add(sysRoleMenu);
        }
        return await _sysRoleMenu.InsertRangeAsync(sysRoleMenus);
    }

    /// <summary>
    /// 删除角色
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> DelRole(RoleId req)
    {
        var del = await _sysRole.DeleteAsync(o => o.Id == req.Id);
        if (del)
        {
            //删除绑定的菜单
            return await _sysRoleMenu.DeleteAsync(o => o.RoleId == req.Id);
        }
        else
        {
            throw Oops.Bah("删除角色失败");
        }
    }

    /// <summary>
    /// 获取角色列表
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> GetRoleList(GetRoleListReq req)
    {
        var query = await _sysRole.AsQueryable()
            .WhereIF(!string.IsNullOrEmpty(req.Name), o => o.Name.Contains(req.Name))
            .ToPagedListAsync(req.Current, req.Size);
        return query;
    }

    /// <summary>
    /// 获取角色菜单列表
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> GetRoleMenuList(RoleId req)
    {
        var menuList = await _sysMenu.GetListAsync(o => o.IsDelete == 0);
        var roleMenuList = await _sysRoleMenu.GetListAsync(o => o.RoleId == req.Id);
        List<GetRoleMenuListRes> reslsit = new List<GetRoleMenuListRes>();
        foreach (var item in menuList)
        {
            var res = item.Adapt<GetRoleMenuListRes>();
            if (roleMenuList.Where(o => o.MenuId == item.Id).FirstOrDefault() != null)
            {
                res.Checked = true;
            }
            else
            {
                res.Checked = false;
            }
            reslsit.Add(res);
        }
        return reslsit;
    }

    /// <summary>
    /// 修改角色
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> UpdateRole(UpdateRoleReq req)
    {
        var role = req.Adapt<SysRole>();
        role.UpdateTime = DateTime.Now;
        return await _sysRole.AsUpdateable(role).IgnoreColumns(o => new { o.CreateTime }).ExecuteCommandAsync() > 0;
    }
}
