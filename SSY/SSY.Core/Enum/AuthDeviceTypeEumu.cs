namespace SSY.Core;

/// <summary>
/// Login设备类型枚举
/// </summary>
public enum AuthDeviceTypeEumu
{
    /// <summary>
    /// PC端
    /// </summary>
    [Description("PC端")]
    PC = 1,

    /// <summary>
    /// 移动端
    /// </summary>
    [Description("移动端")]
    APP = 2,

    /// <summary>
    /// 小程序
    /// </summary>
    [Description("小程序")]
    MINI = 3
}