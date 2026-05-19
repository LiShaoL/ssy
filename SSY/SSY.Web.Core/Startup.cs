using Furion.VirtualFileServer;
using IP2Region.Net.Abstractions;
using IP2Region.Net.XDB;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SSY.Web.Core;

/// <summary>
/// Web启动项配置
/// </summary>
[AppStartup(99)]
public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        //加载选项
        services.AddProjectOptions();

        //SqlSugar
        services.AddSqlSugar();

        //缓存注册
        services.AddCache();

        // JWT配置
        services.AddJwt<JwtHandler>(enableGlobalAuthorize: true, jwtBearerConfigure: options =>
        {
            // 实现 JWT 身份验证过程控制
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var httpContext = context.HttpContext;
                    // 若请求 Url 包含 token 参数，则设置 Token 值
                    if (httpContext.Request.Query.ContainsKey("token"))
                        context.Token = httpContext.Request.Query["token"];
                    return Task.CompletedTask;
                }
            };
        });
        // 允许跨域
        services.AddCorsAccessor();

        //禁止在主机启动时通过 App.GetOptions<TOptions> 获取选项，如需获取配置选项理应通过 App.GetConfig<TOptions>("配置节点", true)。
        var appSettings = App.GetConfig<WebSettingsOptions>("WebSettings", true);
        //如果是演示环境,加上操作筛选器,禁止操作数据库
        if (appSettings.EnvPoc) { services.AddMvcFilter<MyActionFilter>(); }

        //Gzip响应压缩(压缩已被Nginx接管)
        services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.Providers.Add<BrotliCompressionProvider>();
            options.Providers.Add<GzipCompressionProvider>();
            options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
            [
                "text/html; charset=utf-8",
                "application/xhtml+xml",
                "application/atom+xml",
                "image/svg+xml"
            ]);
        });
        //远程请求
        services.AddHttpRemote();

        // 配置ip2region
        services.AddSingleton<ISearcher>(new Searcher(CachePolicy.Content, Path.Combine(App.HostEnvironment.ContentRootPath, "ip2region.xdb")));

        //添加控制器相关
        services.AddControllers()
            .AddNewtonsoftJson(options => //配置json
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();// 首字母小写（驼峰样式）
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";// 返回时间格式化
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;// 忽略循环引用
            }).AddInjectWithUnifyResult<SSYResultProvider>();//配置统一返回模型;

        //注册日志
        services.AddLoggingSetup();

        //Nginx代理的话获取真实IP
        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.All;
            //新增如下两行
            options.KnownNetworks.Clear();
            options.KnownProxies.Clear();
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        //启用Gzip响应压缩(压缩已被Nginx接管)
        app.UseResponseCompression();

        //Nginx代理的话获取真实IP
        app.UseForwardedHeaders();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");//已启用全局统一错误处理，暂时没有这个异常接口
            app.UseHsts();
        }


        // 启用HTTPS
        app.UseHttpsRedirection();

        // 添加状态码拦截中间件
        app.UseUnifyResultStatusCodes();

        // 特定文件类型（文件后缀）处理
        var contentTypeProvider = FS.GetFileExtensionContentTypeProvider();
        // contentTypeProvider.Mappings[".文件后缀"] = "MIME 类型";
        app.UseStaticFiles(new StaticFileOptions
        {
            ContentTypeProvider = contentTypeProvider
        });



        app.UseRouting();

        app.UseCorsAccessor();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseInject(string.Empty);


        app.UseEndpoints(endpoints =>
        {
            // 获取插件选项
            //var pluginsOptions = App.GetOptions<PluginSettingsOptions>();
            //如果通知类型是Signalr
            //if (pluginsOptions.UseSignalR)
            //{
            //    // 注册集线器
            //    endpoints.MapHubs();
            //}

            endpoints.MapControllers();
        });
    }
}