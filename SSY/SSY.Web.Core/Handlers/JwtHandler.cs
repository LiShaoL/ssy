using Furion.Authorization;
using Furion.DataEncryption;
namespace SSY.Web.Core;

public class JwtHandler : AppAuthorizeHandler
{
    /// <summary>
    /// 重写 Handler 添加自动刷新
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task HandleAsync(AuthorizationHandlerContext context, DefaultHttpContext httpContext)
    {
        var expire = App.GetConfig<int>("JWTSettings:ExpiredTime"); 
        var currentHttpContext = context.GetCurrentHttpContext();
        //自动刷新Token
        if (JWTEncryption.AutoRefreshToken(context, currentHttpContext, expire, expire))
        {
            await AuthorizeHandleAsync(context);
        }
        else
        {
            context.Fail(); // 授权失败
            if (currentHttpContext == null)
                return;
            currentHttpContext.SignoutToSwagger();
        }
    }

    /// <summary>
    /// 授权判断逻辑，授权通过返回 true，否则返回 false
    /// </summary>
    /// <param name="context"></param>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    public override async Task<bool> PipelineAsync(AuthorizationHandlerContext context, DefaultHttpContext httpContext)
    {
        // 这里写您的授权判断逻辑，授权通过返回 true，否则返回 false

        // 此处已经自动验证 Jwt Token的有效性了，无需手动验证
        return await CheckAuthorizationAsync(httpContext);
    }

    /// <summary>
    /// 检查权限
    /// </summary>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    private static async Task<bool> CheckAuthorizationAsync(DefaultHttpContext httpContext)
    {

        // 登录模式判断PC、APP
        if (App.User.FindFirst(ClaimConst.LoginMode)?.Value == ((int)AuthDeviceTypeEumu.APP).ToString())
            return true;

        // 排除超管
        if (App.User.FindFirst(ClaimConst.AccountType)?.Value == ((int)AccountTypeEnum.SuperAdmin).ToString())
            return true;

        //写自己的权限判断逻辑

        return true;
    }
}