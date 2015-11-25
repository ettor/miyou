using System;
using System.Collections.Generic;
using System.Text;

namespace BMSP.DBAccesser.DBScript
{
    /// <summary>
    /// 数据查询基类
    /// </summary>
    public class QueryBase
    {
        protected string _Table = "";
        protected string _PrimaryKey = "";
        protected string _paramStyle = "@";
        protected string _Where = "";
        protected string _Columns = "*";
        protected string _OrderBy = "";
        protected string _Sql = "";
        protected string _UpdateFields = "";
        //private QueryType _QType = QueryType.Read;
        protected string _GroupBy = "";
        protected string _Having = "";
        protected int _LimitFirst = 1;
        protected int _LimitLengh = 20000;
        /// <summary>
        /// 存储过程名称
        /// </summary>
        private string _ProcName = ""; //add by Snail
        /// <summary>
        /// 是否执行自定义SQL
        /// </summary>
        private bool _isExecuteCustomSql = false;//add by Snail

        #region 属性
        /// <summary>
        /// 表名
        /// </summary>
        public virtual string Table
        {
            set { _Table = value; }
            get { return _Table; }
        }

        /// <summary>
        /// 主键
        /// </summary>
        public string PrimaryKey
        {
            set { _PrimaryKey = value; }
            get { return _PrimaryKey; }
        }
        /// <summary>
        /// 参数占位符
        /// </summary>
        public string ParamStyle
        {
            set { _paramStyle = value; }
            get { return _paramStyle; }
        }
        /// <summary>
        /// 查询条件
        /// </summary>
        public string Where
        {
            set { _Where = value; }
            get { return _Where; }
        }

        /// <summary>
        /// 查询字段
        /// </summary>
        public string Columns
        {
            set { _Columns = value; }
            get { return _Columns; }
        }

        /// <summary>
        /// 排序
        /// </summary>
        public string OrderBy
        {
            set { _OrderBy = value; }
            get
            {
                if (string.IsNullOrEmpty(_OrderBy))
                {
                    return string.Format("{0} desc", _PrimaryKey);
                }
                return _OrderBy;
            }
        }

        /// <summary>
        /// 直接设置Sql
        /// </summary>
        public string Sql
        {
            set { _Sql = value; }
            get { return _Sql; }
        }

        /// <summary>
        /// 更新字段
        /// </summary>
        public string UpdateFields
        {
            set { _UpdateFields = value; }
            get { return _UpdateFields; }
        }
        /// <summary>
        /// 分组字段
        /// </summary>
        public string GroupBy
        {
            set { _GroupBy = value; }
            get { return _GroupBy; }
        }
        /// <summary>
        /// 分组后查询条件
        /// </summary>
        public string Having
        {
            set { _Having = value; }
            get { return _Having; }
        }
        /// <summary>
        /// 开始查询位置
        /// </summary>
        public int LimitFirst
        {
            set { _LimitFirst = value; }
            get { return _LimitFirst; }
        }

        /// <summary>
        /// 查询条数
        /// </summary>
        public int LimitLengh
        {
            set { _LimitLengh = value; }
            get { return _LimitLengh; }
        }
        /// <summary>
        /// 存储过程名称
        /// </summary>
        public string ProcName //add by Snail
        {
            get { return _ProcName; }
            set { _ProcName = value; }
        }
        /// <summary>
        /// 是否执行自定义 SQL
        /// </summary>
        public bool IsExecuteCustomSql
        {
            get { return _isExecuteCustomSql; }
            set { _isExecuteCustomSql = value; }
        }
        /// <summary>
        /// SQL类型
        /// </summary>
        //public QueryType QType
        //{
        //    set { _QType = value; }
        //    get { return _QType; }
        //}
        #endregion 属性

        #region 输出SQL
        /// <summary>
        /// 输出SQL
        /// </summary>
        /// <returns></returns>
        public virtual string ExportSql()
        {
            return "";
        }

        public virtual string ExportModel()
        {
            return "";
        }

        public virtual string ExportList()
        {
            return "";
        }

        public virtual string ExportExists()
        {
            return "";
        }

        public virtual string ExportUpdateFields()
        {
            return "";
        }

        public virtual string ExportDelete()
        {
            return "";
        }
        #endregion 输出SQL

        #region SQL输出处理
        public virtual string ExportDeal(string sql)
        {
            return sql.Replace("@", ParamStyle);
        }
        #endregion
    }
}
