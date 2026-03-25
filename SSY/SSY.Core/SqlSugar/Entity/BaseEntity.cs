using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSY.Core
{
    public class BaseEntity
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [SugarColumn(ColumnDescription = "Id", IsPrimaryKey = true)]
        public virtual long Id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnDescription = "创建时间", IsOnlyIgnoreUpdate = true, IsNullable = true)]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [SugarColumn(ColumnDescription = "更新时间", IsOnlyIgnoreInsert = true, IsNullable = true)]
        public virtual DateTime? UpdateTime { get; set; }
    }
}
