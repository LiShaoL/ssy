namespace SSY.System;

public interface IMenuService : ITransient
{
    Task<dynamic> AddMenu(AddMenuReq req);
    Task<dynamic> DelMenu(MenuIdReq req);
    Task<dynamic> GetMenuList(GetMenuListReq req);
    Task<dynamic> UpdateMenu(UpdateMenuReq req);
}
