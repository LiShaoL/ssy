namespace SSY.Core;

/// <summary>
/// 操作日志表
///</summary>
[SugarTable("sys_log_operate")]
[Tenant(SqlsugarConst.DB_Default)]
public class SysLogOperate
{
    /// <summary>
    /// Id 
    ///</summary>
    [SugarColumn(ColumnName = "Id", IsPrimaryKey = true)]
    public long Id { get; set; }
    /// <summary>
    /// 具体消息 
    ///</summary>
    [SugarColumn(ColumnName = "ExeMessage")]
    public string ExeMessage { get; set; }
    /// <summary>
    /// 类名称 
    ///</summary>
    [SugarColumn(ColumnName = "ClassName")]
    public string ClassName { get; set; }
    /// <summary>
    /// 方法名称 
    ///</summary>
    [SugarColumn(ColumnName = "MethodName")]
    public string MethodName { get; set; }
    /// <summary>
    /// 请求方式 
    ///</summary>
    [SugarColumn(ColumnName = "ReqMethod")]
    public string ReqMethod { get; set; }
    /// <summary>
    /// 请求地址 
    ///</summary>
    [SugarColumn(ColumnName = "ReqUrl")]
    public string ReqUrl { get; set; }
    /// <summary>
    /// 请求参数 
    ///</summary>
    [SugarColumn(ColumnName = "ParamJson")]
    public string ParamJson { get; set; }
    /// <summary>
    /// 返回结果 
    ///</summary>
    [SugarColumn(ColumnName = "ResultJson")]
    public string ResultJson { get; set; }
    /// <summary>
    /// 日志分类 
    ///</summary>
    [SugarColumn(ColumnName = "Category")]
    public string Category { get; set; }
    /// <summary>
    /// 日志名称 
    ///</summary>
    [SugarColumn(ColumnName = "Name")]
    public string Name { get; set; }
    /// <summary>
    /// 执行状态 
    ///</summary>
    [SugarColumn(ColumnName = "ExeStatus")]
    public string ExeStatus { get; set; }
    /// <summary>
    /// 操作ip 
    ///</summary>
    [SugarColumn(ColumnName = "OpIp")]
    public string OpIp { get; set; }
    /// <summary>
    /// 操作地址 
    ///</summary>
    [SugarColumn(ColumnName = "OpAddress")]
    public string OpAddress { get; set; }
    /// <summary>
    /// 操作浏览器 
    ///</summary>
    [SugarColumn(ColumnName = "OpBrowser")]
    public string OpBrowser { get; set; }
    /// <summary>
    /// 操作系统 
    ///</summary>
    [SugarColumn(ColumnName = "OpOs")]
    public string OpOs { get; set; }
    /// <summary>
    /// 操作时间 
    ///</summary>
    [SugarColumn(ColumnName = "OpTime")]
    public DateTime OpTime { get; set; }
    /// <summary>
    /// 操作人姓名 
    ///</summary>
    [SugarColumn(ColumnName = "OpUser")]
    public string OpUser { get; set; }
    /// <summary>
    /// 操作人账号 
    ///</summary>
    [SugarColumn(ColumnName = "OpAccount")]
    public string OpAccount { get; set; }
    /// <summary>
    /// 创建时间 
    ///</summary>
    [SugarColumn(ColumnName = "CreateTime")]
    public DateTime? CreateTime { get; set; }
    /// <summary>
    /// 更新时间 
    ///</summary>
    [SugarColumn(ColumnName = "UpdateTime")]
    public DateTime? UpdateTime { get; set; }
    /// <summary>
    /// 创建者Id 
    ///</summary>
    [SugarColumn(ColumnName = "CreateUserId")]
    public long? CreateUserId { get; set; }
    /// <summary>
    /// 修改者Id 
    ///</summary>
    [SugarColumn(ColumnName = "UpdateUserId")]
    public long? UpdateUserId { get; set; }
    /// <summary>
    /// 创建人 
    ///</summary>
    [SugarColumn(ColumnName = "CreateUser")]
    public string CreateUser { get; set; }
    /// <summary>
    /// 更新人 
    ///</summary>
    [SugarColumn(ColumnName = "UpdateUser")]
    public string UpdateUser { get; set; }
    /// <summary>
    /// 软删除 
    ///</summary>
    [SugarColumn(ColumnName = "IsDelete")]
    public byte? IsDelete { get; set; }
    /// <summary>
    /// 扩展信息 
    ///</summary>
    [SugarColumn(ColumnName = "ExtJson")]
    public string ExtJson { get; set; }
}
