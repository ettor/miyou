using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Data;
using BMSP.DBAccesser.DBScript;

namespace BusinessLogic.Control
{
    public class JsonUtils
    {
        /// <summary>
        /// 将dt转化成Json数据 格式如 table[{id:1,title:'体育'},id:2,title:'娱乐'}]
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DtToSON(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"total\":" + dt.Rows.Count + ",\"rows\": [");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i > 0)
                    jsonBuilder.Append(",");
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j > 0)
                        jsonBuilder.Append(",");
                    jsonBuilder.Append("\"" + dt.Columns[j].ColumnName.ToLower() + "\":\"" + dt.Rows[i][j].ToString().Replace("\t", " ").Replace("\r", " ").Replace("\n", " ").Replace("\\", " ") + "\"");
                }
                jsonBuilder.Append("}");
            }
            jsonBuilder.Append("]}");
            return jsonBuilder.ToString();

        }

        /// <summary>
        /// 将dt转化成Json数据 格式如 table[{id:1,title:'体育'},id:2,title:'娱乐'}]
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DtToJson2(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i > 0)
                    jsonBuilder.Append(",");
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j > 0)
                        jsonBuilder.Append(",");
                    jsonBuilder.Append("\"" + dt.Columns[j].ColumnName.ToLower() + "\":\"" + dt.Rows[i][j].ToString().Replace("\t", " ").Replace("\r", " ").Replace("\n", " ").Replace("\\", " ") + "\"");
                }
                jsonBuilder.Append("}");
            }
            jsonBuilder.Append("]}");
            return jsonBuilder.ToString();

        }

        /// <summary>
        /// 将dt转化成Json数据 格式如 table[{id:1,title:'体育'},id:2,title:'娱乐'}]
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DtToJson3(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i > 0)
                    jsonBuilder.Append(",");
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j > 0)
                        jsonBuilder.Append(",");
                    jsonBuilder.Append("\"" + dt.Columns[j].ColumnName.ToLower() + "\":\"" + dt.Rows[i][j].ToString().Replace("\t", " ").Replace("\r", " ").Replace("\n", " ").Replace("\\", " ") + "\"");
                }
                jsonBuilder.Append("}");
            }
            jsonBuilder.Append("]");
            return jsonBuilder.ToString();

        }

        /// <summary>
        /// 将dt转化成Json数据 格式如 table[{id:1,title:'体育'},id:2,title:'娱乐'}]，\r\n换行符特殊处理
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DtToJson4(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i > 0)
                    jsonBuilder.Append(",");
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j > 0)
                        jsonBuilder.Append(",");

                    string vRes = "\"" + dt.Columns[j].ColumnName.ToLower() + "\":\"" + GetStrHaveBr(dt.Rows[i][j].ToString()) + "\"";
                    jsonBuilder.Append(vRes);
                }
                jsonBuilder.Append("}");
            }
            jsonBuilder.Append("]");
            return jsonBuilder.ToString();

        }

        /// <summary>
        /// 带有换行符的值处理
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        private static string GetStrHaveBr(string pStr)
        {
            string vRes = "";

            vRes = pStr.Replace("\t", " ").Replace("\r", "<br/>").Replace("\n", "<br/>").Replace("\\", " ");

            while (vRes.Contains("<br/><br/>"))
            {
                vRes = vRes.Replace("<br/><br/>", "<br/>");
            }

            return vRes;
        }

        /// <summary>
        /// 将dt转化成Json数据 格式如 table[{id:1,title:'体育'},id:2,title:'娱乐'}]
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DtToJsonPage(DataTable dt, int pTotal)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"total\":" + pTotal + ",\"rows\": [");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i > 0)
                    jsonBuilder.Append(",");
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j > 0)
                        jsonBuilder.Append(",");
                    jsonBuilder.Append("\"" + dt.Columns[j].ColumnName.ToLower() + "\":\"" + dt.Rows[i][j].ToString().Replace("\t", " ").Replace("\r", " ").Replace("\n", " ").Replace("\\", " ").Replace("\"", "“") + "\"");
                }
                jsonBuilder.Append("}");
            }
            jsonBuilder.Append("]}");
            return jsonBuilder.ToString();

        }

        /// <summary>
        /// 输出Json结果
        /// </summary>
        /// <param name="pModel"></param>
        /// <returns></returns>
        public static string ReturnResule(object pModel)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(pModel);
        }

        /// <summary>
        /// 格式化分页数据
        /// </summary>
        /// <param name="pSql">侍处理SQL</param>
        /// <param name="pIndex">页码</param>
        /// <param name="pRows">页行数</param>
        /// <returns></returns>
        public static DataTable FormatPageDataTable(string pSql, int pBegin, int pEnd,string pKey)
        {
            string vSql = @"SELECT *
                              FROM (SELECT wA.*, row_number() over(order by {3} desc) as RN
                                      FROM ({0}) wA
                                     WHERE RN <= {2})
                             WHERE RN >= {1}";
            DBManager vDbManager = new DBManager();
            vDbManager.ConnectionOpen();
            //pTotal = vDbManager.Query(pSql).Tables[0].Rows.Count;
            DataTable vDt = vDbManager.Query(string.Format(vSql, pSql, pBegin, pEnd,pKey)).Tables[0];
            vDbManager.ConnectionClose();

            return vDt;
        }

        /// <summary>
        /// 格式化分页数据
        /// </summary>
        /// <param name="pSql">侍处理SQL</param>
        /// <param name="pIndex">页码</param>
        /// <param name="pRows">页行数</param>
        /// <returns></returns>
        public static string FormatPageData(string pSql, int pIndex, int pRows,string pKey)
        {
            int vBegin = 0;
            int vEnd = pIndex * pRows;
            if (pIndex == 1)
                vBegin = 0;
            else
            {
                vBegin = pIndex - 1;
                vBegin = vBegin * pRows;
            }
            string vSql = @"SELECT *
                              FROM (SELECT wA.*, ROW_NUMBER() OVER 
                    (ORDER BY {3} desc) AS RowNumber
                                      FROM ({0}) wA
                                     WHERE 1=1) se
                             WHERE RowNumber > {1} and RowNumber <= {2}";
            DBManager vDbManager = new DBManager();
            vDbManager.ConnectionOpen();
            string vCountSql="SELECT COUNT(*) FROM ("+pSql+") wes";
            int vCount = int.Parse(vDbManager.Query(vCountSql).Tables[0].Rows[0][0].ToString());
            DataTable vDt = vDbManager.Query(string.Format(vSql, pSql, vBegin, vEnd,pKey)).Tables[0];
            vDbManager.ConnectionClose();

            return DtToJsonPage(vDt, vCount);
        }

        /// <summary>
        /// 格式化分页数据
        /// </summary>
        /// <param name="pSql"></param>
        /// <param name="pIndex"></param>
        /// <param name="pRows"></param>
        /// <param name="pKey"></param>
        /// <param name="pSortType">sql中order by类型(asc或desc)</param>
        /// <returns></returns>
        public static string FormatPageData2(string pSql, int pIndex, int pRows, string pKey,string pSortType)
        {
            int vBegin = 0;
            int vEnd = pIndex * pRows;
            if (pIndex == 1)
                vBegin = 0;
            else
            {
                vBegin = pIndex - 1;
                vBegin = vBegin * pRows;
            }
            string vSql = @"SELECT *
                              FROM (SELECT wA.*, ROW_NUMBER() OVER 
                    (ORDER BY {3} {4}) AS RowNumber
                                      FROM ({0}) wA
                                     WHERE 1=1) se
                             WHERE RowNumber > {1} and RowNumber <= {2}";
            DBManager vDbManager = new DBManager();
            vDbManager.ConnectionOpen();
            string vCountSql = "SELECT COUNT(*) FROM (" + pSql + ") wes";
            int vCount = int.Parse(vDbManager.Query(vCountSql).Tables[0].Rows[0][0].ToString());
            DataTable vDt = vDbManager.Query(string.Format(vSql, pSql, vBegin, vEnd, pKey, pSortType)).Tables[0];
            vDbManager.ConnectionClose();

            return DtToJsonPage(vDt, vCount);
        }

        /// <summary>
        /// 格式化分页数据
        /// </summary>
        /// <param name="pSql">侍处理SQL</param>
        /// <param name="pIndex">页码</param>
        /// <param name="pRows">页行数</param>
        /// <returns></returns>
        public static DataTable FormatPageDataTable2(string pSql, int pBegin, int pEnd,out int pTotal)
        {
            string vSql = @"SELECT *
                              FROM (SELECT wA.*, ROWNUM RN
                                      FROM ({0}) wA
                                     WHERE ROWNUM <= {2})
                             WHERE RN >= {1}";
            DBManager vDbManager = new DBManager();
            vDbManager.ConnectionOpen();
            pTotal = vDbManager.Query(pSql).Tables[0].Rows.Count;
            DataTable vDt = vDbManager.Query(string.Format(vSql, pSql, pBegin, pEnd)).Tables[0];
            vDbManager.ConnectionClose();

            return vDt;
        }

    }
}
