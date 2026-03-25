namespace SSY.System;

/// <summary>
/// 添加菜单参数
/// </summary>
public class AddMenuReq
{
    /// <summary>
    /// 上级菜单Id
    /// </summary>
    [Required(ErrorMessage = "上级菜单不为空")]
    public long ParentId { get; set; }
    /// <summary>
    /// 菜单类型 1目录 2菜单 3按钮
    ///</summary>
    [Required(ErrorMessage = "菜单类型不为空")]
    public int MenuType { get; set; }
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
    [Required(ErrorMessage = "菜单名称不为空")]
    public string Title { get; set; }
    /// <summary>
    /// 图标 
    ///</summary>
    public string Icon { get; set; }
    /// <summary>
    /// 排序 
    ///</summary>
    [Required(ErrorMessage = "排序不为空")]
    public int OrderNo { get; set; }
    /// <summary>
    /// 是否隐藏 
    ///</summary>
    public int IsHide { get; set; }
}
/// <summary>
/// 修改菜单参数
/// </summary>
public class UpdateMenuReq: AddMenuReq
{
    public long Id { get; set; }     
}
/// <summary>
/// ID
/// </summary>
public class MenuIdReq
{
    /// <summary>
    /// ID
    /// </summary>
    [Required(ErrorMessage = "Id不为空")]
    public long Id { get; set; }
}
public class GetMenuListReq
{
    /// <summary>
    /// 路由地址 
    ///</summary>
    public string Path { get; set; }
    /// <summary>
    /// 菜单名称 
    ///</summary>
    public string Title { get; set; }
}
