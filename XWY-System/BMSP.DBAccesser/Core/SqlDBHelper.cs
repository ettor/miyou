using System;
using System.Collections.Generic;
using System.Text;
using BMSP.DBAccesser.interfaces;
using System.Data;
using System.Data.SqlClient;

namespace BMSP.DBAccesser.core
{
    public class SqlDBHelper : IDBHelper
    {
        #region 属性定义
        private SqlCommand command;
        private SqlConnection connection;
        private SqlTransaction tran;

        public string CommandText
        {
            get { return command.CommandText; }
            set { command.CommandText = value; }
        }
        public void ConnectionOpen()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }
        public void ConnectionClose()
        {
            connection.Close();
        }
        #endregion

        public SqlDBHelper(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection=connection;
        }

        #region IDBHelper 成员

        /// <summary>
        /// DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable ExecuteDataTable()
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        /// <summary>
        /// DataSet
        /// </summary>
        /// <returns></returns>
        public DataSet ExecuteDataSet()
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                command.Parameters.Clear();
                return ds;
            }
        }

        /// <summary>
        /// 事务实例
        /// </summary>
        public void BeginTransaction()
        {
            ConnectionOpen();
            tran= connection.BeginTransaction();
            command.Transaction = tran;
        }

        /// <summary>
        /// 事务提交
        /// </summary>
        public void CommitTransaction()
        {
            tran.Commit();
            ConnectionClose();
        }

        /// <summary>
        /// 事务回滚
        /// </summary>
        public void RollBackTransaction()
        {
            tran.Rollback();
            ConnectionClose();
        }

        /// <summary>
        /// 返回单条数据记录
        /// </summary>
        /// <returns></returns>
        public DataRow ExecuteDataRow()
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                DataRow row = null;
                if (reader.HasRows)
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    row = table.Rows[0];
                }
                return row;
            }
        }    
    
        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        public void IExecuteNonQuery()
        {
           command.ExecuteNonQuery();
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <returns></returns>
        public int ExecuteNonQuery()
        {
            int result = command.ExecuteNonQuery();
            command.Parameters.Clear();
            return result;
        }

        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <returns></returns>
        public object ExecuteScalar()
        {
            object obj = command.ExecuteScalar();
            command.Parameters.Clear();
            return obj;
        }

        /// <summary>
        ///  GetReader
        /// </summary>
        public  IDataReader GetReader()
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                return reader;
            }
        }

        /// <summary>
        /// 添加输入参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddParameter(string key, object value)
        {
            command.Parameters.Add(new SqlParameter(key, value));
        }
        /// <summary>
        /// 添加输出参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddOutParameter(string key, object value)
        {
            command.Parameters.Add(new SqlParameter(key, value)).Direction = ParameterDirection.Output; 
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">过程名</param>
        /// <param name="parameters">参数</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public DataSet ExecuteProcName(string storedProcName,string tableName)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                DataSet ds = new DataSet();
                adapter.SelectCommand = BuildQueryCommand(storedProcName);                
                adapter.Fill(ds,tableName);
                command.Parameters.Clear();
                return ds;
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">过程名</param>
        /// <param name="parameters">参数</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public DataSet ExecuteProcName(string storedProcName, string tableName, out Dictionary<string, string> outPut)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                DataSet ds = new DataSet();
                adapter.SelectCommand = BuildQueryCommand(storedProcName);
                adapter.Fill(ds, tableName);
                Dictionary<string, string> parameterDic = new Dictionary<string, string>();
                foreach (SqlParameter parameter in command.Parameters)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Output))
                    {
                        parameterDic.Add(parameter.ParameterName, parameter.Value.ToString());
                    }
                }
                command.Parameters.Clear();
                outPut = parameterDic;
                return ds;
            }
        }

        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private SqlCommand BuildQueryCommand(string storedProcName)
        {
            command.CommandText = storedProcName;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }


        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            int result;
            SqlCommand command = BuildIntCommand(storedProcName);
            rowsAffected = command.ExecuteNonQuery();
            result = (int)command.Parameters["ReturnValue"].Value;
            //Connection.Close();
            return result;
        }

        /// <summary>
        /// 创建 SqlCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand 对象实例</returns>
        private SqlCommand BuildIntCommand(string storedProcName)
        {
            SqlCommand command = BuildQueryCommand(storedProcName);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        /// <summary>
        /// 获取数据库中表的相关信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDBTable()
        {
            CommandText = " Select name From Sysobjects where type='u' order by name";
            return ExecuteDataTable();
        }

        /// <summary>
        /// 获取表中列的相关信息 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDBTableColumns(string TableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sys.columns.name as column_name, sys.types.name as data_type, sys.columns.max_length, sys.columns.is_nullable,");

            strSql.Append(" (select count(*) from sys.identity_columns where");
            strSql.Append(" sys.identity_columns.object_id = sys.columns.object_id ");
            strSql.Append(" and sys.columns.column_id = sys.identity_columns.column_id) as is_identity ,");

            strSql.Append(" (select value from sys.extended_properties where ");
            strSql.Append("  sys.extended_properties.major_id = sys.columns.object_id ");
            strSql.Append("  and sys.extended_properties.minor_id = sys.columns.column_id) as description");

            strSql.Append(" from sys.columns, sys.tables, sys.types where sys.columns.object_id = sys.tables.object_id");
            strSql.Append(" and sys.columns.system_type_id=sys.types.system_type_id and sys.tables.name='" + TableName + "'");
            strSql.Append(" and sys.types.name <>'sysname'");
            strSql.Append(" order by sys.columns.column_id");
            CommandText = strSql.ToString();
            return ExecuteDataTable();
        }

        #endregion
    }
}
