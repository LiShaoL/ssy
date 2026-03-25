namespace SSY.Entity.System
{
    /// <summary>
    /// 系统菜单表
    ///</summary>
    [SugarTable("sys_menu")]
    [Tenant(SqlsugarConst.DB_Default)]
    public class SysMenu
    {
        /// <summary>
        /// 主键Id 
        ///</summary>
         [SugarColumn(ColumnName="id" ,IsPrimaryKey = true   )]
         public long Id { get; set; }
        /// <summary>
        /// 父Id 
        ///</summary>
         [SugarColumn(ColumnName="parent_id"    )]
         public long ParentId { get; set; }
        /// <summary>
        /// 菜单类型 
        ///</summary>
         [SugarColumn(ColumnName="menu_type"    )]
         public int MenuType { get; set; }
        /// <summary>
        /// 路由名称 
        ///</summary>
         [SugarColumn(ColumnName="name"    )]
         public string Name { get; set; }
        /// <summary>
        /// 路由地址 
        ///</summary>
         [SugarColumn(ColumnName="path"    )]
         public string Path { get; set; }
        /// <summary>
        /// 组件路径 
        ///</summary>
         [SugarColumn(ColumnName="component"    )]
         public string Component { get; set; }
        /// <summary>
        /// 权限标识 
        ///</summary>
         [SugarColumn(ColumnName="authority"    )]
         public string Authority { get; set; }
        /// <summary>
        /// 菜单名称 
        ///</summary>
         [SugarColumn(ColumnName="title"    )]
         public string Title { get; set; }
        /// <summary>
        /// 图标 
        ///</summary>
         [SugarColumn(ColumnName="icon"    )]
         public string Icon { get; set; }
        /// <summary>
        /// 排序 
        ///</summary>
         [SugarColumn(ColumnName="order_no"    )]
         public int OrderNo { get; set; }
        /// <summary>
        /// 是否隐藏 
        ///</summary>
         [SugarColumn(ColumnName="is_hide"    )]
         public int IsHide { get; set; }
        /// <summary>
        /// 软删除 
        ///</summary>
         [SugarColumn(ColumnName="is_delete"    )]
         public int IsDelete { get; set; }
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
