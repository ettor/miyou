using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BMSP.DBAccesser.interfaces
{
    public interface IDBHelper
    {
        /// <summary>
        /// SQL语句
        /// </summary>
        string CommandText { get; set; }
        /// <summary>
        /// 返回多条数据记录
        /// </summary>
        /// <returns></returns>
        DataTable ExecuteDataTable();

        /// <summary>
        /// 返回多条数据记录
        /// </summary>
        /// <returns></returns>
        DataSet ExecuteDataSet();
        /// <summary>
        /// 返回单条数据记录
        /// </summary>
        /// <returns></returns>
        DataRow ExecuteDataRow();

        IDataReader GetReader();

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">过程名</param>
        /// <param name="parameters">参数</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        DataSet ExecuteProcName(string storedProcName, string tableName);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">过程名</param>
        /// <param name="parameters">参数</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        DataSet ExecuteProcName(string storedProcName, string tableName, out Dictionary<string, string> outPut);

        int ExecuteNonQuery();
        object ExecuteScalar();
        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();
        void IExecuteNonQuery();
        void ConnectionOpen();
        void ConnectionClose();

        DataTable GetDBTable();
        DataTable GetDBTableColumns(string TableName);
       
        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        void AddParameter(string key, object value);

        void AddOutParameter(string key, object value);
        
    }
}
