using Furion.DataEncryption;
using IP2Region.Net.Abstractions;
using NewLife.Serialization;
using Newtonsoft.Json;
using SSY.Core.Logging;
using System.Globalization;
using UAParser;

namespace SSY.Core;

public class DatabaseLoggingWriter : IDatabaseLoggingWriter
{
    private readonly DbRepository<SysLogVisit> _sysLogVisit;
    private readonly DbRepository<SysLogOperate> _sysLogOperate;
    private readonly ISearcher _searcher;
    public DatabaseLoggingWriter(DbRepository<SysLogVisit> sysLogVisit, DbRepository<SysLogOperate> sysLogOperate, ISearcher searcher)
    {
        _sysLogVisit = sysLogVisit;
        _sysLogOperate = sysLogOperate;
        _searcher = searcher;
    }

    public async Task WriteAsync(LogMessage logMsg, bool flush)
    {
        //获取请求json字符串
        var jsonString = logMsg.Context?.Get("loggingMonitor").ToString();
        dynamic jloggingMonitor = JsonConvert.DeserializeObject(jsonString);//后边研究下    
        //转成实体
        var loggingMonitor = jsonString.ToJsonEntity<LoggingMonitorJson>();
        //日志时间赋值
        loggingMonitor.LogDateTime = logMsg.LogDateTime;

        var browser = "";
        var os = "";
        if (loggingMonitor.UserAgent != null)
        {
            var client = Parser.GetDefault().Parse(loggingMonitor.UserAgent.ToString());
            browser = $"{client.UA.Family} {client.UA.Major}.{client.UA.Minor} / {client.Device.Family}";
            os = $"{client.OS.Family} {client.OS.Major} {client.OS.Minor}";
        }
        //验证失败和没有DisplayTitle之类的不记录日志
        if (loggingMonitor.Validation == null && loggingMonitor.DisplayTitle != null)
        {
            //访问日志
            if (loggingMonitor.DisplayTitle == "登录" || loggingMonitor.DisplayTitle == "登出")
            {
                //如果没有异常信息
                if (loggingMonitor.Exception == null)
                {
                    await CreateVisitLog(loggingMonitor, browser, os);//添加到访问日志
                }
                else
                {
                    //添加到异常日志
                    await CreateOperationLog(loggingMonitor, browser, os);
                }
            }
            else
            {
                //只有定义了Title的POST方法才记录日志
                if (!loggingMonitor.DisplayTitle.Contains("/") && loggingMonitor.HttpMethod == "POST")
                {
                    //添加到操作日志
                    await CreateOperationLog(loggingMonitor, browser, os);
                }
            }
        }
    }

    /// <summary>
    /// 创建访问日志
    /// </summary>
    /// <param name="operation">访问类型</param>
    /// <param name="loggingMonitor">loggingMonitor</param>
    /// <param name="clientInfo">客户端信息</param>
    private async Task CreateVisitLog(LoggingMonitorJson loggingMonitor, string browser, string os)
    {
        var name = "";//用户姓名
        var opAccount = "";//用户账号
        if (loggingMonitor.DisplayTitle == "登录")
        {
            //如果是登录，用户信息就从返回值里拿
            var result = loggingMonitor.ReturnInformation.Value.ToJson();//返回值转json
            var userInfo = result.ToJsonEntity<SSYResult<JWTModel>>();//格式化成user表
            var tokenData = JWTEncryption.ReadJwtToken(userInfo.Data.AccessToken);
            name = tokenData.GetPayloadValue<string>("Name");//解密JWT获取用户名
            opAccount = tokenData.GetPayloadValue<string>("Account");//解密JWT获取账号
        }
        else
        {
            //如果是登出，用户信息就从AuthorizationClaims里拿
            name = loggingMonitor.AuthorizationClaims.Where(it => it.Type == ClaimConst.Name).Select(it => it.Value).FirstOrDefault();
            opAccount = loggingMonitor.AuthorizationClaims.Where(it => it.Type == ClaimConst.Account).Select(it => it.Value).FirstOrDefault();
        }
        //日志表实体
        var devLogVisit = new SysLogVisit
        {
            Name = loggingMonitor.DisplayTitle,
            Category = loggingMonitor.DisplayTitle == "登录" ? SSYConst.Log_Login : SSYConst.Log_LOGOUT,
            ExeStatus = "成功",
            OpAddress = GetLoginAddress(loggingMonitor.RemoteIPv4),
            OpIp = loggingMonitor.RemoteIPv4,
            OpBrowser = browser,
            OpOs = os,
            OpTime = loggingMonitor.LogDateTime,
            OpUser = name,
            OpAccount = opAccount
        };
        await _sysLogVisit.AsInsertable(devLogVisit).IgnoreColumns(true).ExecuteCommandAsync();//入库
    }

    /// <summary>
    /// 创建操作日志
    /// </summary>
    /// <param name="operation">操作名称</param>
    /// <param name="path">请求地址</param>
    /// <param name="loggingMonitor">loggingMonitor</param>
    /// <param name="clientInfo">客户端信息</param>
    /// <returns></returns>
    private async Task CreateOperationLog(LoggingMonitorJson loggingMonitor, string browser, string os)
    {
        //用户名称
        var name = loggingMonitor.AuthorizationClaims?.Where(it => it.Type == ClaimConst.Name).Select(it => it.Value).FirstOrDefault();
        //账号
        var opAccount = loggingMonitor.AuthorizationClaims?.Where(it => it.Type == ClaimConst.Account).Select(it => it.Value).FirstOrDefault();

        //获取参数json字符串，
        var paramJson = loggingMonitor.Parameters == null || loggingMonitor.Parameters.Count == 0 ? null : loggingMonitor.Parameters[0].Value.ToJson();

        //获取结果json字符串
        var resultJson = string.Empty;
        if (loggingMonitor.ReturnInformation != null)//如果有返回值
        {
            if (loggingMonitor.ReturnInformation.Value != null)//如果返回值不为空
            {
                var time = loggingMonitor.ReturnInformation.Value.Time != null ? DateTime.Parse(loggingMonitor.ReturnInformation.Value.Time) : DateTime.Now;//转成时间
                loggingMonitor.ReturnInformation.Value.Time = time.ToString(CultureInfo.CurrentCulture);//转成字符串
                resultJson = loggingMonitor.ReturnInformation.Value.ToJson();
            }
        }

        //操作日志表实体
        var devLogOperate = new SysLogOperate
        {
            Name = loggingMonitor.DisplayTitle,
            Category = SSYConst.Log_OPERATE,
            ExeStatus = "成功",
            OpAddress = GetLoginAddress(loggingMonitor.RemoteIPv4),
            OpIp = loggingMonitor.RemoteIPv4,
            OpBrowser = browser,
            OpOs = os,
            OpTime = loggingMonitor.LogDateTime,
            OpUser = name,
            OpAccount = opAccount,
            ReqMethod = loggingMonitor.HttpMethod,
            ReqUrl = loggingMonitor.RequestUrl,
            ResultJson = resultJson,
            ClassName = loggingMonitor.DisplayName,
            MethodName = loggingMonitor.ActionName,
            ParamJson = paramJson
        };
        //如果异常不为空
        if (loggingMonitor.Exception != null)
        {
            devLogOperate.Category = SSYConst.Log_EXCEPTION;//操作类型为异常
            devLogOperate.ExeStatus = "失败";//操作状态为失败
            devLogOperate.ExeMessage = loggingMonitor.Exception.Type + ":" + loggingMonitor.Exception.Message + "\n" + loggingMonitor.Exception.StackTrace;
        }
        await _sysLogOperate.AsInsertable(devLogOperate).IgnoreColumns(true).ExecuteCommandAsync();//入库
    }

    /// <summary>
    /// 解析IP地址
    /// </summary>
    /// <param name="ip"></param>
    /// <returns></returns>
    private string GetLoginAddress(string ip)
    {
        var loginAddress = "未知";
        var ipInfo = _searcher.Search(ip);//解析ip
        loginAddress = ipInfo?.Replace("0|", "");//去掉前面的0|
        return loginAddress;
    }
}
