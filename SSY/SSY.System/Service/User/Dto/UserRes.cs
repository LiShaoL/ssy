namespace SSY.System;

/// <summary>
/// 登录返回参数
/// </summary>
public class PcLoginRes
{         
    /// <summary>
    /// 登录令牌
    /// </summary>
    public string AccessToken { get; set; }
    /// <summary>
    /// 刷新令牌
    /// </summary>
    public string RefreshToken { get; set; }
}
public class GetUserInfoRes
{
    /// <summary>
    /// 用户Id 
    ///</summary>
    public long Id { get; set; }
    /// <summary>
    /// 姓名 
    ///</summary>
    public string Name { get; set; }
    /// <summary>
    /// 账号
    /// </summary>
    public string Account { get; set; }
    /// <summary>
    /// 权限Id 
    ///</summary>
    public long RoleId { get; set; }
    public List<Authorities> Authorities { get; set; }
    public List<Roles> Roles { get; set; }
}
public class Roles
{
    public string roleName { get; set; }
    public string roleCode { get; set; }
    public long roleId { get; set; }

}

public class Authorities
{
    public long menuId { get; set; }
    public long parentId { get; set; }
    public string authority { get; set; }
    public string title { get; set; }
    public string icon { get; set; }
    public string path { get; set; }
    public int deleted { get; set; }
    public int hide { get; set; }
    public long sortNumber { get; set; }
    public string component { get; set; }
    public int menuType { get; set; }
}
public class PicValidCodeRes
{
    /// <summary>
    /// 验证码图片，Base64
    /// </summary>
    public string ValidCodeBase64 { get; set; }

    /// <summary>
    /// 验证码请求号
    /// </summary>
    public string ValidCodeReqNo { get; set; }
}
