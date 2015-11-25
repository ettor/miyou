using BMSP.DBAccesser.DBScript;
using BusinessLogic.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Data;

namespace BusinessLogic.Data
{
    public class AgentAction : BaseService<Data_Agent>
    {
        public string GetAgentList(string pKeywords, string pStatus, int page, int rows)
        {
            string vSql = @"SELECT TOP 100 PERCENT AgentId
                                  ,AgentName
                                  ,AgentTel
                                  ,Memo
                                  ,Status
                                  ,InsertP
                                  ,InsertT
                                  ,UpdateP
                                  ,UpdateT
                              FROM Data_Agent a
                            where 1=1 {0}";

            string where = "";
            if (!string.IsNullOrEmpty(pKeywords))
            {
                where += string.Format("and (AgentName like '%{0}%' or AgentTel like '%{0}%' or Memo like '%{0}%' ) ",pKeywords);
            }

            if (!string.IsNullOrEmpty(pStatus) && pStatus.Trim() != "==请选择==")
            {
                where += string.Format(" AND a.status='{0}' ", pStatus.Trim());
            }

            vSql = vSql.Replace("{0}", where);

            string vResult = JsonUtils.FormatPageData(vSql, page, rows,"insertt");
            return vResult;
        }

        /// <summary>
        /// 代理删除
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        //public string AgentDelete(string pId)
        //{
        //    JsonResult vJsonResult = new JsonResult();
        //    vJsonResult.Status = "success";
        //    vJsonResult.Msg = "操作成功";

        //    string vSql = string.Format(" delete from Data_Agent where AgentId={0} ", pId);
        //    DBManager vDBManager = new DBManager();
        //    vDBManager.ConnectionOpen();
        //    int vRes = vDBManager.ExecuteSql(vSql);
        //    vDBManager.ConnectionClose();

        //    if (vRes <= 0)
        //    {
        //        vJsonResult.Status = "error";
        //        vJsonResult.Msg = "操作失败";
        //    }

        //    return JsonUtils.ReturnResule(vJsonResult);
        //}

        /// <summary>
        /// 修改代理状态
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pStatus"></param>
        /// <returns></returns>
        public string SetAgentStatus(string pId,string pStatus)
        {
            JsonResult vJsonResult = new JsonResult();
            vJsonResult.Status = "success";
            vJsonResult.Msg = "操作成功";

            string vSql = string.Format(" update Data_Agent set status='{0}' where AgentId={1} ", pStatus, pId);
            DBManager vDBManager = new DBManager();
            vDBManager.ConnectionOpen();
            int vRes = vDBManager.ExecuteSql(vSql);
            vDBManager.ConnectionClose();

            if (vRes <= 0)
            {
                vJsonResult.Status = "error";
                vJsonResult.Msg = "操作失败";
            }

            return JsonUtils.ReturnResule(vJsonResult);
        }
    }
}