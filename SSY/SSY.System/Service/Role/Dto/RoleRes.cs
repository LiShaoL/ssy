namespace SSY.System;
public class GetRoleMenuListRes
{
    /// <summary>
    /// 主键Id 
    ///</summary>
    public long Id { get; set; }
    /// <summary>
    /// 父Id 
    ///</summary>
    public long ParentId { get; set; }
    /// <summary>
    /// 菜单类型 
    ///</summary>

    public int MenuType { get; set; }
    /// <summary>
    /// 路由名称 
    ///</summary>
    public string Name { get; set; }
    /// <summary>
    /// 路由地址 
    ///</summary>
    public string Path { get; set; }
    /// <summary>
    /// 组件路径 
    ///</summary>
    public string Component { get; set; }
    /// <summary>
    /// 权限标识 
    ///</summary>
    public string Authority { get; set; }
    /// <summary>
    /// 菜单名称 
    ///</summary>
    public string Title { get; set; }
    /// <summary>
    /// 图标 
    ///</summary>
    public string Icon { get; set; }
    /// <summary>
    /// 排序 
    ///</summary>
    public int OrderNo { get; set; }
    /// <summary>
    /// 是否隐藏 
    ///</summary>
    public int IsHide { get; set; }
    /// <summary>
    /// 是否隐藏 
    ///</summary>
    public bool Checked { get; set; }
}
