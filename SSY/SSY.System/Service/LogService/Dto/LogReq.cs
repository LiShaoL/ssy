namespace SSY.System;

public class GetLogVisitListReq : BasePageInput
{
    /// <summary>
    /// 登录人名称
    /// </summary>
    public string OpUser { get; set; }
    /// <summary>
    /// 操作人账号 
    ///</summary>
    public string OpAccount { get; set; }
    /// <summary>
    /// 开始时间 
    ///</summary>
    public string StartTime { get; set; }
    /// <summary>
    /// 结束时间 
    ///</summary>
    public string EndTime { get; set; }
}
