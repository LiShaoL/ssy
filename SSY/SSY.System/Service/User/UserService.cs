using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace SSY.System;

/// <summary>
/// 用户管理
/// </summary>
public class UserService : IUserService
{
    private static readonly string passSalt = App.GetConfig<string>("PassSalt", true);
    private readonly DbRepository<SysUser> _hcUser;
    private readonly DbRepository<SysRoleMenu> _sysRoleMenu;
    private readonly DbRepository<SysRole> _sysRole;
    public UserService(DbRepository<SysUser> hcUser, DbRepository<SysRoleMenu> sysRoleMenu, DbRepository<SysRole> sysRole)
    {
        _hcUser = hcUser;
        _sysRoleMenu = sysRoleMenu;
        _sysRole = sysRole;
    }

    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> AddUser(AddUserReq req)
    {
        var user = req.Adapt<SysUser>();
        user.Password = MD5Encryption.Encrypt(passSalt + req.Password);
        user.Id = CommonUtils.GetSingleId();
        user.CreateTime = DateTime.Now;
        return await _hcUser.InsertAsync(user);
    }

    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> DelUser(UserIdReq req)
    {
        if (req.Id == 1300000000101)
        {
            throw Oops.Bah("超级管理员无法删除");
        }
        return await _hcUser.DeleteAsync(o => o.Id == req.Id);
    }

    /// <summary>
    /// 获取验证码
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public dynamic GetCaptcha()
    {
        //生成验证码
        var captchInfo = CaptchaUtil.CreateCaptcha(CaptchaType.CHAR, 4, 100, 38);
        //返回验证码和请求号
        return new PicValidCodeRes
        {
            ValidCodeBase64 = captchInfo.Base64Str,
            ValidCodeReqNo = captchInfo.Code.ToLower()
        };
    }

    /// <summary>
    /// 获取角色
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> GetRoles()
    {
        return await _sysRole.GetListAsync();
    }

    /// <summary>
    /// 获取用户信息
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> GetUserInfo()
    {
        GetUserInfoRes res = new GetUserInfoRes();
        res.Id = long.Parse(App.User?.FindFirstValue(ClaimConst.UserId));
        res.RoleId = long.Parse(App.User?.FindFirstValue(ClaimConst.RoleId));
        res.Name = App.User?.FindFirstValue(ClaimConst.Name);
        res.Account = App.User?.FindFirstValue(ClaimConst.Account);
        //菜单
        var authorities = await _sysRoleMenu.AsQueryable()
            .LeftJoin<SysMenu>((rm, m) => rm.MenuId == m.Id)
            .Where((rm, m) => rm.RoleId == res.RoleId)
            .Where((rm, m) => m.IsDelete == 0)
            .OrderBy((rm, m) => m.OrderNo)
            .Select((rm, m) => new Authorities()
            {
                menuId = m.Id,
                parentId = m.ParentId,
                title = m.Title,
                path = m.Path,
                component = m.Component,
                icon = m.Icon,
                authority = m.Authority,
                deleted = m.IsDelete,
                hide = m.IsHide,
                sortNumber = m.OrderNo,
                menuType = m.MenuType
            }).ToListAsync();
        res.Authorities = authorities;
        //权限
        var roles = await _sysRole.AsQueryable()
            .Where(o => o.Id == res.RoleId)
            .Select(o => new Roles()
            {
                roleId = o.Id,
                roleCode = o.Name,
                roleName = o.Remark
            })
            .ToListAsync();
        res.Roles = roles;
        return res;
    }

    /// <summary>
    /// 获取用户列表
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> GetUserList(GetUserListReq req)
    {
        var query = await _hcUser.AsQueryable()
            .WhereIF(!string.IsNullOrEmpty(req.Account), o => o.Account.Contains(req.Account))
            .WhereIF(!string.IsNullOrEmpty(req.Name), o => o.Name.Contains(req.Name))
            .ToPagedListAsync(req.Current, req.Size);
        return query;
    }

    /// <summary>
    /// PC登录
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> PcLogin(PcLoginReq req)
    {
        var pass = MD5Encryption.Encrypt(passSalt + req.Password);
        var user = await _hcUser.AsQueryable().Where(o => o.Account == req.Account && o.Password == pass).FirstAsync();
        if (user == null)
        {
            throw Oops.Bah("账号或者密码不正确");
        }
        PcLoginRes res = new PcLoginRes();
        res.AccessToken = JWTEncryption.Encrypt(new Dictionary<string, object>
            {
            {ClaimConst.UserId, user.Id},
            {ClaimConst.Account, user.Account},
            {ClaimConst.Name, user.Name},
            {ClaimConst.RoleId, user.RoleId},
            {ClaimConst.AccountType, user.AccountType},
            {ClaimConst.LoginMode, AuthDeviceTypeEumu.APP},
            });
        //设置token过期和添加Redis
        var expire = App.GetConfig<int>("JWTSettings:ExpiredTime");//获取过期时间(分钟)
        var expirtTime = DateTime.Now.AddSeconds(expire);//过期时间
        // 生成刷新Token令牌
        var refreshToken = JWTEncryption.GenerateRefreshToken(res.AccessToken, expire);
        res.RefreshToken = refreshToken;
        // 设置Swagger自动登录
        App.HttpContext.SigninToSwagger(res.AccessToken);
        // 设置响应报文头
        App.HttpContext.SetTokensOfResponseHeaders(res.AccessToken, refreshToken);
        return res;
    }

    /// <summary>
    /// 修改用户
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> UpdateUser(UpdateUserReq req)
    {
        var user = req.Adapt<SysUser>();
        user.Password = MD5Encryption.Encrypt(passSalt + req.Password);
        return await _hcUser.AsUpdateable(user).IgnoreColumns(o => new { o.CreateTime }).ExecuteCommandAsync();
    }
}
