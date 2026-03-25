namespace SSY.Entity.System
{
    /// <summary>
    /// 系统角色表
    ///</summary>
    [SugarTable("sys_role")]
    [Tenant(SqlsugarConst.DB_Default)]
    public class SysRole
    {
        /// <summary>
        /// 主键Id 
        ///</summary>
         [SugarColumn(ColumnName="id" ,IsPrimaryKey = true   )]
         public long Id { get; set; }
        /// <summary>
        /// 名称 
        ///</summary>
         [SugarColumn(ColumnName="name"    )]
         public string Name { get; set; }
        /// <summary>
        /// 备注 
        ///</summary>
         [SugarColumn(ColumnName="remark"    )]
         public string Remark { get; set; }
        /// <summary>
        /// 状态 
        ///</summary>
         [SugarColumn(ColumnName="status"    )]
         public int Status { get; set; }
        /// <summary>
        /// 创建时间 
        ///</summary>
         [SugarColumn(ColumnName="create_time"    )]
         public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 更新时间 
        ///</summary>
         [SugarColumn(ColumnName="update_time"    )]
         public DateTime? UpdateTime { get; set; }
    }
}
