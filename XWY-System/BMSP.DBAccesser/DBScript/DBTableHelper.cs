using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using BMSP.DBAccesser.DBScript;
using BFW.DBAccesser;

namespace BMSP.DBAccesser.DBScript
{
    /// <summary>
    ///功能说明:   数据库表格处理类 
    ///创建人:     Bano
    ///最后更新:   2009/09/17 
    ///创建时间:   2009/09/17     
    /// </summary>
    public class DBTableHelper
    {
       /// <summary>
       /// 获取数据表结构信息
       /// </summary>
       /// <param name="tableName">表名称</param>
       /// <returns>1:字段名2:字段类型3:长度4:是否可为空5:是否主键6:备注信息</returns>
       public static DataTable GetTableBySqlServer(string tableName)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select sys.columns.name, sys.types.name as typename, sys.columns.max_length, sys.columns.is_nullable,");

           strSql.Append(" (select count(*) from sys.identity_columns where");
           strSql.Append(" sys.identity_columns.object_id = sys.columns.object_id ");
           strSql.Append(" and sys.columns.column_id = sys.identity_columns.column_id) as is_identity ,");

           strSql.Append(" (select value from sys.extended_properties where ");
           strSql.Append("  sys.extended_properties.major_id = sys.columns.object_id ");
           strSql.Append("  and sys.extended_properties.minor_id = sys.columns.column_id) as description");

           strSql.Append(" from sys.columns, sys.tables, sys.types where sys.columns.object_id = sys.tables.object_id");
           strSql.Append(" and sys.columns.system_type_id=sys.types.system_type_id and sys.tables.name='" + tableName + "'");
           strSql.Append(" and sys.types.name <>'sysname'");
           strSql.Append(" order by sys.columns.column_id");
           return DbHelperSQL.Query(strSql.ToString()).Tables[0];
       }

       /// <summary>
       /// 获取数据表结构信息
       /// </summary>
       /// <param name="tableName">表名称</param>
       /// <returns>1:字段名2:字段类型3:长度4:是否可为空5:是否主键6:备注信息</returns>
        public  string GetTablePkByAccess(string tableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + tableName + "");
            DataTable dt = new DataTable();
            dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return dt.PrimaryKey[0].ColumnName+":Int";
        }

       /// <summary>
       /// 获取表主键字段及字段类型
       /// </summary>
       /// <param name="tableName">表名称</param>
       /// <returns></returns>
       public  string GetTablePKBySqlServer(string tableName)
       {
           DataTable dt = new DataTable();
           dt = GetTableBySqlServer(tableName);
           string isPK = string.Empty;
           for (int tLoop = 0; tLoop < dt.Rows.Count; tLoop++)
           {
               if (dt.Rows[tLoop]["is_identity"].ToString() == "1")
                   isPK = dt.Rows[tLoop]["name"].ToString() + ":" + dt.Rows[tLoop]["typename"].ToString();
           }
           return isPK;
       }

       /// <summary>
       /// 获取库中所有表名
       /// </summary>
       /// <returns></returns>
       public  DataTable GetTableNameBySqlServer()
       {
           DataTable dt = new DataTable();
           StringBuilder strSql = new StringBuilder();
           strSql.Append(" Select name From Sysobjects where type='u'");
           dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
           return dt;
       }

       /// <summary>
       /// 获取数据库名称
       /// </summary>
       /// <returns></returns>
       public  string GetDBName()
       {
           string connectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
           string dbName = StringHelper.GetArrayValue(connectionstring, ';', 1);
           dbName = dbName.ToLower().Replace("database=", "");
           return dbName;
       }
   }
}
