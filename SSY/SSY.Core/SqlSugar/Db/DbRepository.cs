namespace SSY.Core;

/// <summary>
/// 仓储模式对象
/// </summary>
public class DbRepository<T> : SimpleClient<T> where T : class, new()
{
    public DbRepository()
    {
        var iTenant = SqlSugarSetup.ITenant;
        Context = iTenant.GetConnectionScopeWithAttr<T>();//ioc注入的对象
    }
}
