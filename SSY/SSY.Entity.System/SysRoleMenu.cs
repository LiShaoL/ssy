namespace SSY.Entity.System
{
    /// <summary>
    /// 系统角色菜单表
    ///</summary>
    [SugarTable("sys_role_menu")]
    [Tenant(SqlsugarConst.DB_Default)]
    public class SysRoleMenu
    {
        /// <summary>
        /// 主键Id 
        ///</summary>
         [SugarColumn(ColumnName="id" ,IsPrimaryKey = true   )]
         public long Id { get; set; }
        /// <summary>
        /// 角色Id 
        ///</summary>
         [SugarColumn(ColumnName="role_id"    )]
         public long RoleId { get; set; }
        /// <summary>
        /// 菜单Id 
        ///</summary>
         [SugarColumn(ColumnName="menu_id"    )]
         public long MenuId { get; set; }
    }
}
