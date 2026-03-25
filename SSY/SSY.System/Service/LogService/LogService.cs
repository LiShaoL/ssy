namespace SSY.System;

/// <summary>
/// 日志管理
/// </summary>
public class LogService : ILogService
{
    private readonly DbRepository<SysLogOperate> _sysLogOperate;
    private readonly DbRepository<SysLogVisit> _sysLogVisit;
    public LogService(DbRepository<SysLogOperate> sysLogOperate, DbRepository<SysLogVisit> sysLogVisit)
    {
        _sysLogOperate = sysLogOperate;
        _sysLogVisit = sysLogVisit;
    }
    /// <summary>
    /// 清空操作日志列表
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> DelLogOperateList()
    {
        return await _sysLogOperate.AsDeleteable().ExecuteCommandAsync() > 0;
    }

    /// <summary>
    /// 清空登录日志列表
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> DelLogVisitList()
    {
        return await _sysLogVisit.AsDeleteable().ExecuteCommandAsync() > 0;
    }

    /// <summary>
    /// 获取操作日志列表
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> GetLogOperateList(GetLogVisitListReq req)
    {
        var list = await _sysLogOperate.AsQueryable()
            .WhereIF(!string.IsNullOrEmpty(req.OpUser), o => o.OpUser.Contains(req.OpUser))
            .WhereIF(!string.IsNullOrEmpty(req.OpAccount), o => o.OpAccount.Contains(req.OpAccount))
            .WhereIF(!string.IsNullOrEmpty(req.StartTime) && !string.IsNullOrEmpty(req.EndTime), o => o.CreateTime > DateTime.Parse(req.StartTime) && o.CreateTime < DateTime.Parse(req.EndTime))
            .OrderByDescending(o => o.CreateTime)
            .ToPagedListAsync(req.Current, req.Size);
        return list;
    }

    /// <summary>
    /// 获取登录日志列表
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<dynamic> GetLogVisitList(GetLogVisitListReq req)
    {
        var list = await _sysLogVisit.AsQueryable()
            .WhereIF(!string.IsNullOrEmpty(req.OpUser), o => o.OpUser.Contains(req.OpUser))
            .WhereIF(!string.IsNullOrEmpty(req.OpAccount), o => o.OpAccount.Contains(req.OpAccount))
            .WhereIF(!string.IsNullOrEmpty(req.StartTime) && !string.IsNullOrEmpty(req.EndTime), o => o.CreateTime > DateTime.Parse(req.StartTime) && o.CreateTime < DateTime.Parse(req.EndTime))
            .OrderByDescending(o => o.CreateTime)
            .ToPagedListAsync(req.Current, req.Size);
        return list;
    }
}
