namespace SSY.Core;

public class JWTModel
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
