using System;
using System.Collections.Generic;
using System.Text;
using BMSP.DBAccesser.interfaces;
using System.Data;
using System.Data.OleDb;

namespace BMSP.DBAccesser.core
{
    public class OleDbHelper : IDBHelper
    {
        #region 属性定义
        private OleDbCommand command;
        private OleDbConnection connection;
        private OleDbTransaction tran;

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

        public OleDbHelper(string connectionString)
        {
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }

        #region IDBHelper 成员       

        /// <summary>
        /// DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable ExecuteDataTable()
        {
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
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
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
            {
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
        }

        /// <summary>
        /// 获取数据库中表的相关信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDBTable()
        {
            return connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, 
                new Object[] { null, null, null, "Table" });  
        }

        /// <summary>
        /// 获取表中列的相关信息 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDBTableColumns(string TableName)
        {
            return connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, 
                new Object[] { null, null,TableName, null });
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        public void IExecuteNonQuery()
        {
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// 事务实例
        /// </summary>
        public void BeginTransaction()
        {
            ConnectionOpen();
            tran = connection.BeginTransaction();
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
        /// ExecuteDataRow
        /// </summary>
        /// <returns></returns>
        public DataRow ExecuteDataRow()
        {
            using (OleDbDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
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
        ///  GetReader
        /// </summary>
        public  IDataReader GetReader()
        {
            using (OleDbDataReader reader = command.ExecuteReader())
            {
                return reader;
            }
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <returns></returns>
        public int ExecuteNonQuery()
        {
            int result = command.ExecuteNonQuery();
            return result;
        }

        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <returns></returns>
        public object ExecuteScalar()
        {
            object obj = command.ExecuteScalar();
            return obj;
        }

        /// <summary>
        /// Parameters
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddParameter(string key, object value)
        {
            command.Parameters.Add(new OleDbParameter(key, value));
        }

        /// <summary>
        /// 添加输出参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddOutParameter(string key, object value)
        {
            command.Parameters.Add(new OleDbParameter(key, value)).Direction = ParameterDirection.Output;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">过程名</param>
        /// <param name="parameters">参数</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public DataSet ExecuteProcName(string storedProcName, string tableName)
        {
            using (OleDbDataAdapter adapter = new OleDbDataAdapter())
            {
                DataSet ds = new DataSet();
                adapter.SelectCommand = BuildQueryCommand(storedProcName);
                adapter.Fill(ds, tableName);
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
            using (OleDbDataAdapter adapter = new OleDbDataAdapter())
            {
                DataSet ds = new DataSet();
                adapter.SelectCommand = BuildQueryCommand(storedProcName);
                adapter.Fill(ds, tableName);
                Dictionary<string, string> parameterDic = new Dictionary<string, string>();
                foreach (OleDbParameter parameter in command.Parameters)
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
        private OleDbCommand BuildQueryCommand(string storedProcName)
        {
            command.CommandText = storedProcName;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }
        #endregion
    }
}
