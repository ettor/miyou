using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.IO;

using BMSP.DBAccesser;
using BMSP.DBAccesser.interfaces;
using BMSP.Common;
using System.Collections.Generic;

namespace BMSP.DBAccesser
{
    /// <summary>
    /// 数据访问抽象基础类
    /// Copyright (C) 2009 BFW
    /// All rights reserved	
    /// </summary>
    public class DbHelperSQL
    {
        //public static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public static string ConnectionStr = string.Empty;
        protected IDBHelper dbHelper = null;
        public DbHelperSQL()
        {
            if (string.IsNullOrEmpty(ConnectionStr))
                ConnectionStr = "ConnectionString";
            dbHelper = DBHelperFactory.CreateDBHelper(ConnectionStr);
            ConnectionStr = "";
        }

        #region 公用方法
        /// <summary> 
        /// 返回单条记录中的某一项
        /// </summary> 
        /// <param name="type">要取得的字段名称</param> 
        /// <param name="TableWhere">条件</param> 
        /// <returns>text1 返回值 </returns> 
        public string GetDs(string Type, string TableName, string StrWhere)
        {
            string values = string.Empty;
            string SQLString = "select " + Type + " from " + TableName + " where " + StrWhere;
            dbHelper.CommandText = SQLString;
            try
            {
                values = Convert.ToString(dbHelper.ExecuteScalar());
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }

            return values;
        }

        /// <summary>
        /// 取出符合條件的記錄數
        /// </summary>
        /// <param name="str_SqlAndWhere"></param>
        /// <returns></returns>
        public int GetRsCount(string str_SqlAndWhere)
        {
            int num1;
            string SQLString = "select count(*) from " + str_SqlAndWhere;
            dbHelper.CommandText = SQLString;
            try
            {
                num1 = int.Parse(dbHelper.ExecuteScalar().ToString());
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }

            return num1;
        }

        public int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        public string GetMaxValue(string FieldName, string TableName, string pWhere)
        {
            string strsql = "select max(" + FieldName + ") from " + TableName + " where " + pWhere;
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        public bool Exists(string strSql)
        {
            object obj = GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void AddParameter(string key, object value)
        {
            dbHelper.AddParameter(key, value);
        }

        public void AddOutParameter(string key, object value)
        {
            dbHelper.AddOutParameter(key, value);
        }
        #endregion

        #region  执行简单SQL语句
        /// <summary>
        /// 返回泛型實體
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="sql"></param>
        /// <param name="dynObj"></param>
        /// <returns></returns>
        public T Entity<T>(string sql, object dynObj)
        {
            dbHelper.CommandText = sql;
            DataRow dr = null;
            DataTable vDt = dbHelper.ExecuteDataTable();
            if (vDt.Rows.Count > 0)
                dr = vDt.Rows[0];
            if (dr != null)
            {
                dynObj = DataReaderToEntity.PopulateFromIDataReader<T>(dr);
            }
            else
            {
                dynObj = null;
            }

            return (T)dynObj;
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString)
        {
            dbHelper.CommandText = SQLString;
            try
            {
                int rows = dbHelper.ExecuteNonQuery();
                return rows;
            }
            catch (Exception E)
            {
                FileObj.WriteLogFile(E.ToString() + "\n" + SQLString);
                throw new Exception(E.Message);
            }
        }

        public bool ExecuteSqlBool(string SQLString)
        {
            bool flag = false;
            dbHelper.CommandText = SQLString;
            try
            {
                int rows = dbHelper.ExecuteNonQuery();
                if (rows > 0)
                {
                    flag = true;
                }
            }
            catch (Exception E)
            {
                FileObj.WriteLogFile(E.ToString() + "\n" + SQLString);
                throw new Exception(E.Message);
            }

            return flag;
        }

        public IDataReader GetDataRead(string SQLString)
        {
            dbHelper.CommandText = SQLString;
            return dbHelper.GetReader();
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>
        public void ExecuteSqlTran(ArrayList SQLStringList)
        {
            for (int n = 0; n < SQLStringList.Count; n++)
            {
                string strsql = SQLStringList[n].ToString();
                if (strsql.Trim().Length > 1)
                {
                    dbHelper.CommandText = strsql;
                    dbHelper.IExecuteNonQuery();
                }
            }
        }

        //        /// <summary>
        //        /// 执行带一个存储过程参数的的SQL语句。
        //        /// </summary>
        //        /// <param name="SQLString">SQL语句</param>
        //        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        //        /// <returns>影响的记录数</returns>
        //        public static int ExecuteSql(string SQLString,string content)
        //        {				
        //            using (SqlConnection connection = new SqlConnection(connectionString))
        //            {
        //                SqlCommand cmd = new SqlCommand(SQLString,connection);		
        //                System.Data.SqlClient.SqlParameter  myParameter = new System.Data.SqlClient.SqlParameter ( "@content", SqlDbType.NText);
        //                myParameter.Value = content ;
        //                cmd.Parameters.Add(myParameter);
        //                try
        //                {
        //                    connection.Open();
        //                    int rows=cmd.ExecuteNonQuery();
        //                    return rows;
        //                }
        //                catch(System.Data.SqlClient.SqlException E)
        //                {				
        //                    throw new Exception(E.Message);
        //                }
        //                finally
        //                {
        //                    cmd.Dispose();
        //                    connection.Close();
        //                }	
        //            }
        //        }
        //        /// <summary>
        //        /// 执行带一个存储过程参数的的SQL语句。
        //        /// </summary>
        //        /// <param name="SQLString">SQL语句</param>
        //        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        //        /// <returns>影响的记录数</returns>
        //        public static object ExecuteSqlGet(string SQLString,string content)
        //        {				
        //            using (SqlConnection connection = new SqlConnection(connectionString))
        //            {
        //                SqlCommand cmd = new SqlCommand(SQLString,connection);		
        //                System.Data.SqlClient.SqlParameter  myParameter = new System.Data.SqlClient.SqlParameter ( "@content", SqlDbType.NText);
        //                myParameter.Value = content ;
        //                cmd.Parameters.Add(myParameter);
        //                try
        //                {
        //                    connection.Open();
        //                    object obj = cmd.ExecuteScalar();
        //                    if((Object.Equals(obj,null))||(Object.Equals(obj,System.DBNull.Value)))
        //                    {					
        //                        return null;
        //                    }
        //                    else
        //                    {
        //                        return obj;
        //                    }		
        //                }
        //                catch(System.Data.SqlClient.SqlException E)
        //                {				
        //                    throw new Exception(E.Message);
        //                }
        //                finally
        //                {
        //                    cmd.Dispose();
        //                    connection.Close();
        //                }	
        //            }
        //        }
        //        /// <summary>
        //        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        //        /// </summary>
        //        /// <param name="strSQL">SQL语句</param>
        //        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        //        /// <returns>影响的记录数</returns>
        //        public static int ExecuteSqlInsertImg(string strSQL,byte[] fs)
        //        {		
        //            using (SqlConnection connection = new SqlConnection(connectionString))
        //            {
        //                SqlCommand cmd = new SqlCommand(strSQL,connection);	
        //                System.Data.SqlClient.SqlParameter  myParameter = new System.Data.SqlClient.SqlParameter ( "@fs", SqlDbType.Image);
        //                myParameter.Value = fs ;
        //                cmd.Parameters.Add(myParameter);
        //                try
        //                {
        //                    connection.Open();
        //                    int rows=cmd.ExecuteNonQuery();
        //                    return rows;
        //                }
        //                catch(System.Data.SqlClient.SqlException E)
        //                {				
        //                    throw new Exception(E.Message);
        //                }
        //                finally
        //                {
        //                    cmd.Dispose();
        //                    connection.Close();
        //                }				
        //            }
        //        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string SQLString)
        {
            dbHelper.CommandText = SQLString;
            try
            {
                object obj = dbHelper.ExecuteScalar();
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            catch (Exception e)
            {
                FileObj.WriteLogFile(e.ToString() + "\n" + SQLString);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet Query(string SQLString)
        {
            DataSet ds = new DataSet();
            try
            {
                dbHelper.CommandText = SQLString;
                ds = dbHelper.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                FileObj.WriteLogFile(ex.ToString() + "\n" + SQLString);
                throw new Exception(ex.Message);
            }
            return ds;
        }

        //        public static DataSet Query(string SQLString,int Times)
        //        {
        //            using (SqlConnection connection = new SqlConnection(connectionString))
        //            {
        //                DataSet ds = new DataSet();
        //                try
        //                {
        //                    connection.Open();					
        //                    SqlDataAdapter command = new SqlDataAdapter(SQLString,connection);		
        //                    command.SelectCommand.CommandTimeout=Times;
        //                    command.Fill(ds,"ds");
        //                }
        //                catch(System.Data.SqlClient.SqlException ex)
        //                {				
        //                    throw new Exception(ex.Message);
        //                }			
        //                return ds;
        //            }			
        //        }



        //        #endregion

        //        #region 执行带参数的SQL语句

        //        /// <summary>
        //        /// 执行SQL语句，返回影响的记录数
        //        /// </summary>
        //        /// <param name="SQLString">SQL语句</param>
        //        /// <returns>影响的记录数</returns>
        //        public static int ExecuteSql(string SQLString,params SqlParameter[] cmdParms)
        //        {
        //            using (SqlConnection connection = new SqlConnection(connectionString))
        //            {				
        //                using (SqlCommand cmd = new SqlCommand())
        //                {
        //                    try
        //                    {		
        //                        PrepareCommand(cmd, connection, null,SQLString, cmdParms);
        //                        int rows=cmd.ExecuteNonQuery();
        //                        cmd.Parameters.Clear();
        //                        return rows;
        //                    }
        //                    catch(System.Data.SqlClient.SqlException E)
        //                    {				
        //                        throw new Exception(E.Message);
        //                    }
        //                }				
        //            }
        //        }


        //        /// <summary>
        //        /// 执行多条SQL语句，实现数据库事务。
        //        /// </summary>
        //        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        //        public static void ExecuteSqlTran(Hashtable SQLStringList)
        //        {			
        //            using (SqlConnection conn = new SqlConnection(connectionString))
        //            {
        //                conn.Open();
        //                using (SqlTransaction trans = conn.BeginTransaction()) 
        //                {
        //                    SqlCommand cmd = new SqlCommand();
        //                    try 
        //                    {
        //                        //悜遠
        //                        foreach (DictionaryEntry myDE in SQLStringList)
        //                        {	
        //                            string 	cmdText=myDE.Key.ToString();
        //                            SqlParameter[] cmdParms=(SqlParameter[])myDE.Value;
        //                            PrepareCommand(cmd,conn,trans,cmdText, cmdParms);
        //                            int val = cmd.ExecuteNonQuery();
        //                            cmd.Parameters.Clear();

        //                            trans.Commit();
        //                        }					
        //                    }
        //                    catch 
        //                    {
        //                        trans.Rollback();
        //                        throw;
        //                    }
        //                }				
        //            }
        //        }


        //        /// <summary>
        //        /// 执行一条计算查询结果语句，返回查询结果（object）。
        //        /// </summary>
        //        /// <param name="SQLString">计算查询结果语句</param>
        //        /// <returns>查询结果（object）</returns>
        //        public static object GetSingle(string SQLString,params SqlParameter[] cmdParms)
        //        {
        //            using (SqlConnection connection = new SqlConnection(connectionString))
        //            {
        //                using (SqlCommand cmd = new SqlCommand())
        //                {
        //                    try
        //                    {
        //                        PrepareCommand(cmd, connection, null,SQLString, cmdParms);
        //                        object obj = cmd.ExecuteScalar();
        //                        cmd.Parameters.Clear();
        //                        if((Object.Equals(obj,null))||(Object.Equals(obj,System.DBNull.Value)))
        //                        {					
        //                            return null;
        //                        }
        //                        else
        //                        {
        //                            return obj;
        //                        }				
        //                    }
        //                    catch(System.Data.SqlClient.SqlException e)
        //                    {				
        //                        throw new Exception(e.Message);
        //                    }					
        //                }
        //            }
        //        }

        ///// <summary>
        ///// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        ///// </summary>
        ///// <param name="strSQL">查询语句</param>
        ///// <returns>SqlDataReader</returns>
        //public static SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    SqlCommand cmd = new SqlCommand();
        //    try
        //    {
        //        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
        //        SqlDataReader myReader = cmd.ExecuteReader();
        //        cmd.Parameters.Clear();
        //        return myReader;
        //    }
        //    catch (System.Data.SqlClient.SqlException e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    //			finally
        //    //			{
        //    //				cmd.Dispose();
        //    //				connection.Close();
        //    //			}	

        //}

        //        /// <summary>
        //        /// 执行查询语句，返回DataSet
        //        /// </summary>
        //        /// <param name="SQLString">查询语句</param>
        //        /// <returns>DataSet</returns>
        //        public static DataSet Query(string SQLString,params SqlParameter[] cmdParms)
        //        {
        //            using (SqlConnection connection = new SqlConnection(connectionString))
        //            {
        //                SqlCommand cmd = new SqlCommand();
        //                PrepareCommand(cmd, connection, null,SQLString, cmdParms);
        //                using( SqlDataAdapter da = new SqlDataAdapter(cmd) )
        //                {
        //                    DataSet ds = new DataSet();	
        //                    try
        //                    {												
        //                        da.Fill(ds,"ds");
        //                        cmd.Parameters.Clear();
        //                    }
        //                    catch(System.Data.SqlClient.SqlException ex)
        //                    {				
        //                        throw new Exception(ex.Message);
        //                    }			
        //                    return ds;
        //                }				
        //            }			
        //        }


        //        private static void PrepareCommand(SqlCommand cmd,SqlConnection conn,SqlTransaction trans, string cmdText, SqlParameter[] cmdParms) 
        //        {
        //            if (conn.State != ConnectionState.Open)
        //                conn.Open();
        //            cmd.Connection = conn;
        //            cmd.CommandText = cmdText;
        //            if (trans != null)
        //                cmd.Transaction = trans;
        //            cmd.CommandType = CommandType.Text;//cmdType;
        //            if (cmdParms != null) 
        //            {


        //                foreach (SqlParameter parameter in cmdParms)
        //                {
        //                    if ( ( parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input ) && 
        //                        (parameter.Value == null))
        //                    {
        //                        parameter.Value = DBNull.Value;
        //                    }
        //                    cmd.Parameters.Add(parameter);
        //                }
        //            }
        //        }

        //        #endregion

        //        #region 存储过程操作

        //        /// <summary>
        //        /// 执行存储过程，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        //        /// </summary>
        //        /// <param name="storedProcName">存储过程名</param>
        //        /// <param name="parameters">存储过程参数</param>
        //        /// <returns>SqlDataReader</returns>
        //        public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters )
        //        {
        //            using (SqlConnection connection = new SqlConnection(connectionString))
        //            {
        //                SqlDataReader returnReader;
        //                connection.Open();
        //                SqlCommand command = BuildQueryCommand( connection,storedProcName, parameters );
        //                command.CommandType = CommandType.StoredProcedure;
        //                returnReader = command.ExecuteReader();				
        //                return returnReader;
        //            }
        //        }


        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public DataTable RunProcedure(string storedProcName, string tableName)
        {
            return dbHelper.ExecuteProcName(storedProcName, tableName).Tables[0];
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public DataTable RunProcedure(string storedProcName, string tableName, out Dictionary<string, string> outPut)
        {
            return dbHelper.ExecuteProcName(storedProcName, tableName, out outPut).Tables[0];
        }
        //        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        //        {
        //            using (SqlConnection connection = new SqlConnection(connectionString))
        //            {
        //                DataSet dataSet = new DataSet();
        //                connection.Open();
        //                SqlDataAdapter sqlDA = new SqlDataAdapter();
        //                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
        //                sqlDA.SelectCommand.CommandTimeout = Times;
        //                sqlDA.Fill(dataSet, tableName);
        //                connection.Close();
        //                return dataSet;
        //            }
        //        }


        //        /// <summary>
        //        /// 执行存储过程，返回影响的行数		
        //        /// </summary>
        //        /// <param name="storedProcName">存储过程名</param>
        //        /// <param name="parameters">存储过程参数</param>
        //        /// <param name="rowsAffected">影响的行数</param>
        //        /// <returns></returns>
        //        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        //        {
        //            using (SqlConnection connection = new SqlConnection(connectionString))
        //            {
        //                int result;
        //                connection.Open();
        //                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
        //                rowsAffected = command.ExecuteNonQuery();
        //                result = (int)command.Parameters["ReturnValue"].Value;
        //                //Connection.Close();
        //                return result;
        //            }
        //        }

        //        /// <summary>
        //        /// 创建 SqlCommand 对象实例(用来返回一个整数值)	
        //        /// </summary>
        //        /// <param name="storedProcName">存储过程名</param>
        //        /// <param name="parameters">存储过程参数</param>
        //        /// <returns>SqlCommand 对象实例</returns>
        //        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        //        {
        //            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
        //            command.Parameters.Add(new SqlParameter("ReturnValue",
        //                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
        //                false, 0, 0, string.Empty, DataRowVersion.Default, null));
        //            return command;
        //        }

        /// <summary>
        /// 获取数据库中表的相关信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDBTable()
        {
            return dbHelper.GetDBTable();
        }

        /// <summary>
        /// 获取表中列的相关信息 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDBTableColumns(string TableName)
        {
            return dbHelper.GetDBTableColumns(TableName);
        }

        #endregion

    }

}
