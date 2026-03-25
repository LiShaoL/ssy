namespace SSY.System;

public interface IRoleService : ITransient
{
    Task<dynamic> AddRole(AddRoleReq req);
    Task<dynamic> AssignPermissions(AssignPermissionsReq req);
    Task<dynamic> DelRole(RoleId req);
    Task<dynamic> GetRoleList(GetRoleListReq req);
    Task<dynamic> GetRoleMenuList(RoleId req);
    Task<dynamic> UpdateRole(UpdateRoleReq req);
}
