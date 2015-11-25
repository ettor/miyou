using BMSP.DBAccesser.DBScript;
using BusinessLogic.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Data;
using System.Data;

namespace BusinessLogic.Data
{
    public class ProductAction : BaseService<Data_Product>
    {
        public string GetProductList(string pKeywords, string pStatus, int page, int rows)
        {
            string vSql = @"SELECT TOP 100 PERCENT ProductId
                                  ,ProductName
                                  ,SupplierName,SupplierTel,Spec,BuyPrice,AgentPrice,SalePrice,ProductMemo
                                  ,Memo
                                  ,Status
                                  ,InsertP
                                  ,InsertT
                                  ,UpdateP
                                  ,UpdateT
                                  ,IsHot
                                  ,sortno
                                  ,isagent
                              FROM Data_Product a
                            where 1=1 {0}";

            string where = "";
            if (!string.IsNullOrEmpty(pKeywords))
            {
                where += string.Format("and ProductName like '%{0}%' ",pKeywords);
            }

            if (!string.IsNullOrEmpty(pStatus) && pStatus.Trim() != "==请选择==")
            {
                where += string.Format(" AND a.status='{0}' ", pStatus.Trim());
            }

            vSql = vSql.Replace("{0}", where);

            string vResult = JsonUtils.FormatPageData(vSql, page, rows, "ishot desc,sortno,insertt");
            return vResult;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        //public string ProductDelete(string pId)
        //{
        //    JsonResult vJsonResult = new JsonResult();
        //    vJsonResult.Status = "success";
        //    vJsonResult.Msg = "操作成功";

        //    string vSql = string.Format(" delete from Data_Product where ProductId={0} ", pId);
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
        /// 修改状态
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pStatus"></param>
        /// <returns></returns>
        public string SetProductStatus(string pId, string pStatus)
        {
            JsonResult vJsonResult = new JsonResult();
            vJsonResult.Status = "success";
            vJsonResult.Msg = "操作成功";

            string vTempSql = "";
            if (pStatus == "无效")
            {
                vTempSql = ",ishot='N' ";
            }
            string vSql = string.Format(" update Data_Product set status='{0}' {2} where ProductId={1} ", pStatus, pId,vTempSql);
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

        /// <summary>
        /// 设置热门状态
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pIsHot"></param>
        /// <returns></returns>
        public string SetProductHotStatus(string pId, string pIsHot)
        {
            JsonResult vJsonResult = new JsonResult();
            vJsonResult.Status = "success";
            vJsonResult.Msg = "操作成功";

            string vSql = string.Format(" update Data_Product set ishot='{0}' where ProductId={1} ", pIsHot, pId);
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

        /// <summary>
        /// 设置代理标示
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pIsHot"></param>
        /// <returns></returns>
        public string SetProductAgentStatus(string pId, string pIsAgent)
        {
            JsonResult vJsonResult = new JsonResult();
            vJsonResult.Status = "success";
            vJsonResult.Msg = "操作成功";

            string vSql = string.Format(" update Data_Product set isagent='{0}' where ProductId={1} ", pIsAgent, pId);
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

        public DataTable GetProductForExport(string pKeywords, string pStatus)
        {
            string vSql = @"SELECT TOP 100 PERCENT ProductName '产品名称'
                                  ,BuyPrice '进货价',AgentPrice  '代理价',SalePrice  '零售价',ProductMemo  '产品备注'
                                  ,Memo '备注'
                                  ,Status '状态'
                                  ,IsHot '是否热门'
                                  ,sortno '排序号'
                                  ,isagent '是否代理'
                              FROM Data_Product a
                            where 1=1 {0} order by ishot desc,sortno,insertt";

            string where = "";
            if (!string.IsNullOrEmpty(pKeywords))
            {
                where += string.Format("and ProductName like '%{0}%' ", pKeywords);
            }

            if (!string.IsNullOrEmpty(pStatus) && pStatus.Trim() != "==请选择==")
            {
                where += string.Format(" AND a.status='{0}' ", pStatus.Trim());
            }

            vSql = vSql.Replace("{0}", where);

            DBManager vDb = new DBManager();
            vDb.ConnectionOpen();

            DataTable vDt = vDb.Query(vSql).Tables[0];

            vDb.ConnectionClose();

            return vDt;
        }
    }
}