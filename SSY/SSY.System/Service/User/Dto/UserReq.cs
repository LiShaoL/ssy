namespace SSY.System;

/// <summary>
/// 登录参数
/// </summary>
public class PcLoginReq
{
    /// <summary>
    /// 账号
    /// </summary>
    [Required(ErrorMessage = "账号不为空")]
    public string Account { get; set; }
    /// <summary>
    /// 密码
    /// </summary>
    [Required(ErrorMessage = "密码不为空")]
    public string Password { get; set; }
}
public class AddUserReq
{
    /// <summary>
    /// 账号 
    ///</summary>
    public string Account { get; set; }
    /// <summary>
    /// 密码 
    ///</summary>
    public string Password { get; set; }
    /// <summary>
    /// 姓名 
    ///</summary>
    public string Name { get; set; }
    /// <summary>
    /// 权限Id 
    ///</summary>
    public long RoleId { get; set; }
}
public class UpdateUserReq : AddUserReq
{
    public long Id { get; set; }
}

public class UserIdReq
{
    public long Id { get; set; }
}
public class GetUserListReq : BasePageInput
{
    /// <summary>
    /// 账号 
    ///</summary>
    public string Account { get; set; }
    /// <summary>
    /// 姓名 
    ///</summary>
    public string Name { get; set; }
}
