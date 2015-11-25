using System;
using System.Collections.Generic;
using System.Text;

namespace BMSP.DBAccesser.DBScript
{
    /// <summary>
    /// 映射数据库字段
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class DbColumnAttribute : Attribute
    {
        private string _Name;
        private bool _IsDbGenerate = false;

        #region 构造函数
        public DbColumnAttribute()
        {
        }
        public DbColumnAttribute(string name)
        {
            _Name = name;
        }
        public DbColumnAttribute(string name, bool isAuto)
        {
            _Name = name;
            _IsDbGenerate = isAuto;
        }
        #endregion

        /// <summary>
        /// 字段名
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        /// <summary>
        /// 是否自增
        /// </summary>
        public bool IsDbGenerate
        {
            get { return _IsDbGenerate; }
            set { _IsDbGenerate = value; }
        }



    }
}
