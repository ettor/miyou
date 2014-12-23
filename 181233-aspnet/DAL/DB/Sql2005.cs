using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace DAL.DB
{
    public class Sql2005
    {
        /// <summary>
        /// 获取针对oracle数据库链接的字符串
        /// </summary>
        /// <returns></returns>
        public static SqlConnection SQL_GetConnection()
        {
            //string connectionString = connstr;
            string connectionString = ConfigurationManager.ConnectionStrings["mituan_sqlserver"].ToString();
            SqlConnection oraclecon = new SqlConnection(connectionString);
            return oraclecon;
        }


        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        public static string SQL_Exqsql(string strsql)
        {
            string res = "";
            SqlConnection sql = SQL_GetConnection();
            try
            {
                sql.Open();
                SqlCommand sqlcom = new SqlCommand(strsql, sql);
                sqlcom.ExecuteNonQuery();
                res = "success";
                return res;
            }
            catch (SqlException exe)
            {
                return exe.Message.ToString();
            }
            finally
            {
                sql.Close();
            }
        }


        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        public static DataSet SQL_GetDataSet(string strsql)
        {
            SqlConnection sql = SQL_GetConnection();
            DataSet ds = new DataSet();
            try
            {
                sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter(strsql, sql);
                sda.Fill(ds, "ds");
                sda.Dispose();

                return ds;
            }
            catch (SqlException)
            {
                return null;
            }
            finally
            {
                sql.Close();
            }
        }


        /// <summary>
        /// 根据查询语句返回一个特定的字段值
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        public static string O_ExcuseScalarSql(string strsql)
        {
            SqlConnection sql = SQL_GetConnection();
            try
            {
                sql.Open();
                SqlCommand sqlcom = new SqlCommand(strsql, sql);
                string res = Convert.ToString(sqlcom.ExecuteScalar());
                return "success," + res;
            }
            catch (SqlException exe)
            {
                return "数据链接 根据查询条件执行ExcuseScalar引发异常，查询语句：" + strsql + " 错误编号：" + exe.ErrorCode.ToString() + "。错误描述：" + exe.Message.ToString();
                //return Lazycat.Common.Safe.Errors.Errors_Show("10202");
            }
            finally
            {
                sql.Close();
            }
        }

        public static ArrayList O_ExecProc(string proc, SqlParameter[] para, string[] p_out)
        {
            ArrayList res = new ArrayList();

            SqlConnection conn = SQL_GetConnection();
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = proc;
                foreach (SqlParameter sqlpara in para)
                {
                    comm.Parameters.Add(sqlpara);
                }

                comm.ExecuteNonQuery();

                foreach (string out_para in p_out)
                {
                    res.Add((String)comm.Parameters[out_para].Value);
                }
            }
            catch (SqlException exe)
            {
                res.Add("sql执行存储过程出错 错误编号：" + exe.ErrorCode.ToString() + "。错误描述：" + exe.Message.ToString());
            }
            finally
            {
                conn.Close();
            }

            return res;
        }

    }
}
