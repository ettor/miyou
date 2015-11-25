using BMSP.DBAccesser.DBScript;
using BusinessLogic.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Bill;
using System.Data;

namespace BusinessLogic.Bill
{
    public class BillAction : BaseService<Model.Bill.Bill>
    {
        public string GetBillList(string pKeywords, string pStatus, string pSource, string pSDate, string pEDate, string pIncludeFinished, string pOrderedStatus, int page, int rows)
        {
            string vSql = @"SELECT TOP 100 PERCENT a.billid
                                                  ,a.customername
                                                  ,a.customertel
                                                  ,a.customeraddress
                                                  ,a.productid
                                                  ,cast(convert(decimal, a.buyprice) as numeric(9,2)) buyprice
                                                  ,a.quantity
                                                  ,cast(convert(decimal, a.totalprice) as numeric(9,2)) totalprice
                                                  ,cast(convert(decimal, a.totalprice) - convert(decimal, a.buyprice) as numeric(9,2)) profit
                                                  ,a.agentid
                                                  ,a.status
                                                  ,a.expressno
                                                  ,a.billdate
                                                  ,a.memo
                                                  ,a.insertp
                                                  ,a.insertt
                                                  ,a.updatep
                                                  ,a.updatet
                                                  ,a.source
                                                  ,b.productname
                                                  ,c.agentname
                                                  ,a.orderedstatus
                                              from bill a
                                              left join Data_Product b 
                                              on a.productid=b.productid
                                              left join data_agent c
                                              on a.agentid=c.agentid
                            where 1=1 {0}";

            string where = "";
            if (!string.IsNullOrEmpty(pKeywords))
            {
                where += string.Format(@" and (a.customername like '%{0}%' or a.customertel like '%{0}%' 
                                    or a.customeraddress like '%{0}%' or b.productname like '%{0}%' or c.agentname like '%{0}%' ) ",pKeywords);
            }

            if (!string.IsNullOrEmpty(pStatus) && pStatus.Trim() != "==请选择==")
            {
                where += string.Format(" AND a.status='{0}' ", pStatus.Trim());
            }

            if (!string.IsNullOrEmpty(pOrderedStatus) && pOrderedStatus.Trim() != "==请选择==")
            {
                where += string.Format(" AND a.orderedstatus='{0}' ", pOrderedStatus.Trim());
            }

            if (!string.IsNullOrEmpty(pSource) && pSource.Trim() != "==请选择==")
            {
                where += string.Format(" AND a.source='{0}' ", pSource.Trim());
            }

            if (!string.IsNullOrEmpty(pSDate))
            {
                where += string.Format(@" and a.billdate >= '{0}' ",pSDate);
            }

            if (!string.IsNullOrEmpty(pEDate))
            {
                where += string.Format(@" and a.billdate <= '{0}' ", pEDate);
            }

            if (!string.IsNullOrEmpty(pIncludeFinished) && pIncludeFinished.Trim() == "false")
            {
                where += string.Format(@" and a.status <> '{0}' ", "已结束");
            }

            vSql = vSql.Replace("{0}", where);

            string vResult = JsonUtils.FormatPageData(vSql, page, rows, "billdate desc,insertt");
            return vResult;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        //public string BillDelete(string pId)
        //{
        //    JsonResult vJsonResult = new JsonResult();
        //    vJsonResult.Status = "success";
        //    vJsonResult.Msg = "操作成功";

        //    string vSql = string.Format(" delete from Bill where BillId={0} ", pId);
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
        public string SetBillStatus(string pId, string pStatus)
        {
            JsonResult vJsonResult = new JsonResult();
            vJsonResult.Status = "success";
            vJsonResult.Msg = "操作成功";

            string vSql = string.Format(" update Bill set status='{0}' where BillId={1} ", pStatus, pId);
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
        /// 修改下单状态
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pStatus"></param>
        /// <returns></returns>
        public string SetBillOrderedStatus(string pId, string pStatus)
        {
            JsonResult vJsonResult = new JsonResult();
            vJsonResult.Status = "success";
            vJsonResult.Msg = "操作成功";

            string vSql = string.Format(" update Bill set orderedstatus='{0}' where BillId={1} ", pStatus, pId);
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
        /// 查询账款流水总金额
        /// </summary>
        /// <param name="pKeywords"></param>
        /// <param name="pStatus"></param>
        /// <param name="pSDate"></param>
        /// <param name="pEDate"></param>
        /// <returns></returns>
        public string QueryProfit(string pKeywords, string pStatus, string pSource, string pSDate, string pEDate, string pIncludeFinished, string pOrderedStatus)
        {
            string vSql = @"SELECT isnull(cast(sum(convert(decimal, a.buyprice)) as numeric(9,2)),0) buyprice
                                  ,isnull(cast(sum(convert(decimal, a.totalprice)) as numeric(9,2)),0) totalprice
                                  ,isnull(cast(sum(convert(decimal, a.totalprice) - convert(decimal, a.buyprice)) as numeric(9,2)),0) profit
                              from bill a
                              left join Data_Product b 
                              on a.productid=b.productid
                              left join data_agent c
                              on a.agentid=c.agentid
                            where 1=1 {0}";

            string where = "";
            if (!string.IsNullOrEmpty(pKeywords))
            {
                where += string.Format(@" and (a.customername like '%{0}%' or a.customertel like '%{0}%' 
                                    or a.customeraddress like '%{0}%' or b.productname like '%{0}%' or c.agentname like '%{0}%' ) ", pKeywords);
            }

            if (!string.IsNullOrEmpty(pStatus) && pStatus.Trim() != "==请选择==")
            {
                where += string.Format(" AND a.status='{0}' ", pStatus.Trim());
            }

            if (!string.IsNullOrEmpty(pOrderedStatus) && pOrderedStatus.Trim() != "==请选择==")
            {
                where += string.Format(" AND a.OrderedStatus='{0}' ", pOrderedStatus.Trim());
            }

            if (!string.IsNullOrEmpty(pSource) && pSource.Trim() != "==请选择==")
            {
                where += string.Format(" AND a.source='{0}' ", pSource.Trim());
            }

            if (!string.IsNullOrEmpty(pSDate))
            {
                where += string.Format(@" and a.billdate >= '{0}' ", pSDate);
            }

            if (!string.IsNullOrEmpty(pEDate))
            {
                where += string.Format(@" and a.billdate <= '{0}' ", pEDate);
            }

            if (!string.IsNullOrEmpty(pIncludeFinished) && pIncludeFinished.Trim() == "false")
            {
                where += string.Format(@" and a.status <> '{0}' ", "已结束");
            }

            vSql = vSql.Replace("{0}", where);

            DBManager vDb = new DBManager();
            vDb.ConnectionOpen();
            string vResult = JsonUtils.DtToJson3(vDb.Query(vSql).Tables[0]);
            vDb.ConnectionClose();

            return vResult;
        }

        /// <summary>
        /// 订单导出
        /// </summary>
        /// <param name="pKeywords"></param>
        /// <param name="pStatus"></param>
        /// <param name="pSource"></param>
        /// <param name="pSDate"></param>
        /// <param name="pEDate"></param>
        /// <returns></returns>
        public DataTable GetBillForExport(string pKeywords, string pStatus, string pSource, string pSDate, string pEDate, string pIncludeFinished, string pOrderedStatus)
        {
            string vSql = @"SELECT TOP 100 PERCENT a.customername '客户名称'
                                                  ,a.customertel '客户电话'
                                                  ,a.customeraddress '客户地址'
                                                  ,b.productname '产品名称'
                                                  ,cast(convert(decimal, a.buyprice) as numeric(9,2)) '进货金额'
                                                  ,a.quantity '数量'
                                                  ,cast(convert(decimal, a.totalprice) as numeric(9,2)) '订单金额'
                                                  ,cast(convert(decimal, a.totalprice) - convert(decimal, a.buyprice) as numeric(9,2)) '净利润'
                                                  ,c.agentname '代理'
                                                  ,a.status '状态'
                                                  ,a.OrderedStatus '下单状态'
                                                  ,a.expressno '快递单号'
                                                  ,a.billdate '订单日期'
                                                  ,a.memo '备注'
                                                  ,a.insertt '录入日期'
                                                  ,a.source  '来源'
                                              from bill a
                                              left join Data_Product b 
                                              on a.productid=b.productid
                                              left join data_agent c
                                              on a.agentid=c.agentid
                            where 1=1 {0}";

            string where = "";
            if (!string.IsNullOrEmpty(pKeywords))
            {
                where += string.Format(@" and (a.customername like '%{0}%' or a.customertel like '%{0}%' 
                                    or a.customeraddress like '%{0}%' or b.productname like '%{0}%' or c.agentname like '%{0}%' ) ", pKeywords);
            }

            if (!string.IsNullOrEmpty(pStatus) && pStatus.Trim() != "==请选择==")
            {
                where += string.Format(" AND a.status='{0}' ", pStatus.Trim());
            }

            if (!string.IsNullOrEmpty(pOrderedStatus) && pOrderedStatus.Trim() != "==请选择==")
            {
                where += string.Format(" AND a.OrderedStatus='{0}' ", pOrderedStatus.Trim());
            }

            if (!string.IsNullOrEmpty(pSource) && pSource.Trim() != "==请选择==")
            {
                where += string.Format(" AND a.source='{0}' ", pSource.Trim());
            }

            if (!string.IsNullOrEmpty(pSDate))
            {
                where += string.Format(@" and a.billdate >= '{0}' ", pSDate);
            }

            if (!string.IsNullOrEmpty(pEDate))
            {
                where += string.Format(@" and a.billdate <= '{0}' ", pEDate);
            }

            if (!string.IsNullOrEmpty(pIncludeFinished) && pIncludeFinished.Trim() == "false")
            {
                where += string.Format(@" and a.status <> '{0}' ", "已结束");
            }

            vSql = vSql.Replace("{0}", where);

            vSql = vSql + " order by a.billdate desc,a.insertt desc ";

            DBManager vDb = new DBManager();
            vDb.ConnectionOpen();

            DataTable vDt = vDb.Query(vSql).Tables[0];

            vDb.ConnectionClose();

            return vDt;
        }
    }
}