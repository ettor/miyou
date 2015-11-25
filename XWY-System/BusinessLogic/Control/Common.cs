using BMSP.DBAccesser.DBScript;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessLogic.Control
{
    public static class Common
    {
        /// <summary>
        /// 判断岗位是否存在
        /// </summary>
        /// <param name="pPostName"></param>
        /// <returns></returns>
        public static bool IsHaveRecordOfPost(string pPostName)
        {
            DBManager vDbManager = new DBManager();
            vDbManager.ConnectionOpen();
            string vSql = string.Format(@"select 1 from POST_INFO where post_name='{0}'",pPostName);
            DataTable vDt = vDbManager.Query(vSql).Tables[0];
            vDbManager.ConnectionClose();

            bool vRes = false;

            if (vDt != null && vDt.Rows.Count > 0)
            {
                vRes = true;
            }

            return vRes;
        }

        /// <summary>
        /// 判断城市是否存在
        /// </summary>
        /// <param name="pCity"></param>
        /// <returns></returns>
        public static bool IsHaveRecordOfCity(string pCity)
        {
            DBManager vDbManager = new DBManager();
            vDbManager.ConnectionOpen();
            string vSql = string.Format(@"SELECT 1
                                          FROM (SELECT PORVINCE || '-' || CITY AS city
                                                  FROM etl_account_d
                                                 WHERE city IS NOT NULL
                                                   AND PORVINCE IS NOT NULL
                                                   and ACCNT_TYPE_CD = 'KA'
                                                   AND acct_status = '活动'
                                                 GROUP BY PORVINCE || '-' || CITY)
                                        where city='{0}'", pCity);
            DataTable vDt = vDbManager.Query(vSql).Tables[0];
            vDbManager.ConnectionClose();

            bool vRes = false;

            if (vDt != null && vDt.Rows.Count > 0)
            {
                vRes = true;
            }

            return vRes;
        }

        /// <summary>
        /// 判断卖场是否存在
        /// </summary>
        /// <param name="pMarket"></param>
        /// <returns></returns>
        public static bool IsHaveRecordOfMarket(string pMarket)
        {
            DBManager vDbManager = new DBManager();
            vDbManager.ConnectionOpen();
            string vSql = string.Format(@"select 1 from W_ACCOUNT_D_V WHERE SIEBELNUM='{0}'", pMarket);
            DataTable vDt = vDbManager.Query(vSql).Tables[0];
            vDbManager.ConnectionClose();

            bool vRes = false;

            if (vDt != null && vDt.Rows.Count > 0)
            {
                vRes = true;
            }

            return vRes;
        }

        /// <summary>
        /// 取得格式化日期
        /// </summary>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public static string GetDateTimeFormat(string pValue)
        {
            string vRes = "";
            try
            {
                vRes = DateTime.Parse(pValue).ToString("yyyy-MM-dd");
            }
            catch
            { }
            return vRes;
        }

        /// <summary>
        /// 两个日期之间相差的月份
        /// </summary>
        /// <param name="pOldMonth"></param>
        /// <param name="pNewMonth"></param>
        /// <returns></returns>
        public static string GetMonthDiff(string pOldMonth,string pNewMonth)
        {
            string vRes = "0"; ;

            try
            {
                vRes = (DateTime.Parse(pNewMonth).Month - DateTime.Parse(pOldMonth).Month).ToString();
            }
            catch
            { }
            return vRes;
        }

        /// <summary>
        /// 记录登录日志
        /// </summary>
        /// <param name="pLoginUser"></param>
        public static void WriteLoginLog(string pLoginUser)
        {
            string vSql = string.Format("insert into SYS_LOG_lOGIN(empid,insertt) values('{0}',sysdate)",pLoginUser);

            DBManager vDb = new DBManager();
            vDb.ConnectionOpen();
            vDb.ExecuteSql(vSql);
            vDb.ConnectionClose();
        }

        /// <summary>
        /// 转换性别（中文到英文）
        /// </summary>
        /// <param name="pSex"></param>
        /// <returns></returns>
        public static string TransFormSex(string pSex)
        {
            string vRes = pSex;

            if (pSex == "男")
            {
                vRes = "M";
            }
            if (pSex == "女")
            {
                vRes = "F";
            }

            return vRes;
        }

        public static int GetInt(object pValue)
        {
            int vRes = 0;
            try
            {
                vRes = int.Parse(pValue.ToString());
            }
            catch
            { }
            return vRes;
        }

        /// <summary>
        /// 写入系统日志
        /// </summary>
        /// <param name="pOperateType"></param>
        /// <param name="pIp"></param>
        /// <param name="pMemo"></param>
        /// <param name="pInsertP"></param>
        public static void WriteSysLog(string pOperateType,string pMemo, string pInsertP)
        {
            string strIP = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();

            string vSql = string.Format(@"insert into Sys_Log(OperateType,IP,Memo,InsertP,InsertT) 
                                            values ('{0}','{1}','{2}','{3}',getdate())", pOperateType, strIP, pMemo, pInsertP);

            try
            {
                DBManager vDb = new DBManager();
                vDb.ConnectionOpen();
                vDb.ExecuteSql(vSql);
                vDb.ConnectionClose();
            }
            catch
            { }
        }
    }
}
