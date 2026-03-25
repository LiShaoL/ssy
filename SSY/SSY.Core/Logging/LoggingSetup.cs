using Microsoft.Extensions.Options;

namespace SSY.Core;

public static class LoggingSetup
{
    public static void AddLoggingSetup(this IServiceCollection services)
    {
        //控制台日志
        var Console = App.GetConfig<bool>("Logging:Monitor:Console", true);
        services.AddConsoleFormatter(options =>
        {
            options.DateFormat = "yyyy-MM-dd HH:mm:ss(zzz) dddd";
            options.WriteFilter = (logMsg) =>
            {
                if (logMsg.LogName == "System.Logging.LoggingMonitor" && !Console)
                {
                    return Console;
                }
                else
                {
                    return true;
                }
            };
        });

        //Monitor日志配置
        services.AddMonitorLogging(options =>
        {
            options.IgnorePropertyNames = new[] { "Byte" };
            options.IgnorePropertyTypes = new[] { typeof(byte[]) };
        });

        // 日志写入文件
        var File = App.GetConfig<bool>("Logging:Monitor:File", true);
        Array.ForEach(new[] { LogLevel.Information, LogLevel.Warning, LogLevel.Error }, logLevel =>
        {
            services.AddFileLogging(options =>
            {
                options.WithTraceId = true; // 显示线程Id
                options.WithStackFrame = true; // 显示程序集
                options.FileNameRule = fileName => string.Format(fileName, DateTime.Now, logLevel.ToString()); // 每天创建一个文件
                options.WriteFilter = (logMsg) =>
                {
                    if (logMsg.LogName == "System.Logging.LoggingMonitor" && !File)
                    {
                        return File;
                    }
                    else
                    {
                        return logMsg.LogLevel == logLevel;
                    }
                };
                options.HandleWriteError = (writeError) => // 写入失败时启用备用文件
                {
                    writeError.UseRollbackFileName(Path.GetFileNameWithoutExtension(writeError.CurrentFileName) + "-oops" + Path.GetExtension(writeError.CurrentFileName));
                };
                options.MessageFormat = LoggerFormatter.Json;
                options.MessageFormat = (logMsg) =>
                {
                    var stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine("【日志级别】：" + logMsg.LogLevel);
                    stringBuilder.AppendLine("【日志类名】：" + logMsg.LogName);
                    stringBuilder.AppendLine("【日志时间】：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    stringBuilder.AppendLine("【日志内容】：" + logMsg.Message);
                    if (logMsg.Exception != null)
                    {
                        stringBuilder.AppendLine("【异常信息】：" + logMsg.Exception);
                    }
                    return stringBuilder.ToString();
                };

            });
        });


        //日志写入数据库配置
        services.AddDatabaseLogging<DatabaseLoggingWriter>(options =>
        {
            options.WriteFilter = (logMsg) =>
            {
                return logMsg.LogName == "System.Logging.LoggingMonitor";//只写入LoggingMonitor日志
            };
        });
    }
}

