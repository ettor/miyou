using BusinessLogic.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BMSP.DBAccesser.DBScript;
using BMSP.Common;
using System.Data;
using BusinessLogic.Control;

namespace BusinessLogic.Sys
{
    public class SysUserAction
    {
        public static string Users_Login(string pUser,string pPwd)
        {
            string vRes = "登录失败";

            pPwd = Md5Encode.MD5Encode(pPwd);

            string vSql = string.Format("select UserId,UserName from Sys_User where UserName = '{0}' and UserPassword = '{1}'",pUser,pPwd);

            DBManager vDb = new DBManager();
            vDb.ConnectionOpen();
            DataTable vDt = vDb.Query(vSql).Tables[0];
            vDb.ConnectionClose();

            if (vDt != null && vDt.Rows.Count > 0)
            {
                System.Web.HttpContext.Current.Session.Add("UserId", vDt.Rows[0]["UserId"].ToString());
                System.Web.HttpContext.Current.Session.Add("UserName", vDt.Rows[0]["UserName"].ToString());

                vRes = "success";
            }

            return vRes;
        }

        /// <summary>
        /// 操作日志
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public string GetSysLogList(int page, int rows)
        {
            string vSql = @"SELECT TOP 100 PERCENT a.id
                                                  ,a.OperateType
                                                  ,a.IP
                                                  ,a.memo
                                                  ,a.InsertP
                                                  ,a.InsertT
                                              from Sys_Log a
                            where 1=1 ";

            string vResult = JsonUtils.FormatPageData(vSql, page, rows, "InsertT");
            return vResult;
        }
    }
}