namespace SSY.Core;

/// <summary>
/// 全局分页查询输入参数
/// </summary>
public class BasePageInput
{
    /// <summary>
    /// 当前页码
    /// </summary>
    [DataValidation(ValidationTypes.Numeric)]
    public virtual int Current { get; set; } = 1;

    /// <summary>
    /// 每页条数
    /// </summary>
    [Range(1, 100, ErrorMessage = "页码容量超过最大限制")]
    [DataValidation(ValidationTypes.Numeric)]
    public virtual int Size { get; set; } = 10;
}