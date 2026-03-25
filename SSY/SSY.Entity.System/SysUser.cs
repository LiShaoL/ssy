namespace SSY.Entity.System
{
    /// <summary>
    /// 用户信息表
    ///</summary>
    [SugarTable("sys_user")]
    [Tenant(SqlsugarConst.DB_Default)]
    public class SysUser
    {
        /// <summary>
        /// Id 
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true)]
        public long Id { get; set; }
        /// <summary>
        /// 账号 
        ///</summary>
        [SugarColumn(ColumnName = "account")]
        public string Account { get; set; }
        /// <summary>
        /// 密码 
        ///</summary>
        [SugarColumn(ColumnName = "password")]
        public string Password { get; set; }
        /// <summary>
        /// 姓名 
        ///</summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// 权限Id 
        ///</summary>
        [SugarColumn(ColumnName = "role_id")]
        public long RoleId { get; set; }
        /// <summary>
        /// 账号类型 
        ///</summary>
        [SugarColumn(ColumnName = "account_type")]
        public int AccountType { get; set; }
        /// <summary>
        /// 创建时间 
        ///</summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }
    }
}
