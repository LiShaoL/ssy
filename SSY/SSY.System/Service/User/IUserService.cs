namespace SSY.System;

/// <summary>
/// 用户管理
/// </summary>
public interface IUserService : ITransient
{
    Task<dynamic> AddUser(AddUserReq req);
    Task<dynamic> DelUser(UserIdReq req);
    dynamic GetCaptcha();
    Task<dynamic> GetRoles();
    Task<dynamic> GetUserInfo();
    Task<dynamic> GetUserList(GetUserListReq req);
    Task<dynamic> PcLogin(PcLoginReq req);
    Task<dynamic> UpdateUser(UpdateUserReq req);
}
