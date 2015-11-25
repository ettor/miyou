using System;
using System.Collections.Generic;
using System.Text;

namespace BMSP.DBAccesser.DBScript
{
    /// <summary>
    /// 排除与数据字段的关联
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class ExcludeAttribute : Attribute
    {
        public ExcludeAttribute()
        {
        }
    }
}
