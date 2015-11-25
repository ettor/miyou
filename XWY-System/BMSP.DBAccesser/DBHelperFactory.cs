using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using BMSP.DBAccesser.interfaces;
using BMSP.DBAccesser.core;

namespace BMSP.DBAccesser
{
    public class DBHelperFactory
    {
        private static DataBaseType dbtype = new DataBaseType();
        private static string connectionstring = string.Empty;
        public static string ConnectionString
        {
            get { return connectionstring; }
            set { connectionstring = value; }
        }
        public static DataBaseType dbType { get { return dbtype; } set { dbtype = value; } }

        static DBHelperFactory()
        {
            //if (dbType == null)
            dbtype = DataBaseType.SqlServer;
        }

        /// <summary>
        /// 根据数据库连接字符串名生成数据库访问类
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public static IDBHelper CreateDBHelper(string connectionName)
        {
            ///从配置文件中获取数据库连接字符串
            connectionstring = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;

            switch (dbType)
            {
                case DataBaseType.SqlServer:
                    return new SqlDBHelper(connectionstring);
                case DataBaseType.Oracle:
                    return new OracleDBHelper(connectionstring);
                case DataBaseType.OleDb:
                    return new OleDbHelper(connectionstring);
                default:
                    return null;
            }
        }
    }
}
