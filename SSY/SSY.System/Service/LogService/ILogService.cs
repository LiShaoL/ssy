namespace SSY.System;

public interface ILogService : ITransient
{
    Task<dynamic> DelLogOperateList();
    Task<dynamic> DelLogVisitList();
    Task<dynamic> GetLogOperateList(GetLogVisitListReq req);
    Task<dynamic> GetLogVisitList(GetLogVisitListReq req);
}
