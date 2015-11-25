using BMSP.Common.Utils;
using BMSP.DBAccesser;
using BMSP.DBAccesser.DBScript;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace BusinessLogic.Control
{
    public class EntityCreator
    {
        private string tablename;
        private DataBaseType mDataBaseType;

        public EntityCreator(string tableName, DataBaseType pType)
        {
            this.tablename = tableName;
            mDataBaseType = pType;
        }

        private string _Code()
        {
            DataTable dt = new DataTable();
            dt = GetDBTableColumns(tablename);
            Column Col = new Column();
            StringBuilder sb = new StringBuilder();
            sb.Append("using System;\r\nusing System.Collections.Generic;\r\n");
            string ClassName = tablename;
            sb.Append("namespace WFP.Model");
            sb.Append("\r\n").Append("{");
            sb.Append("\r\n\tpublic class ").Append(ClassName).Append("\r\n");
            sb.Append("\t{\r\n");
            sb.Append("\t\t#region 属性\r\n");
            Col.Primary = GetDBTablePK(tablename, mDataBaseType);
            string[] vPKArry = Col.Primary.Split(',');
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                Col.Code = StrHelper.ParseCodeType(dt.Rows[j]["data_type"].ToString().ToLower());
                Col.Name = dt.Rows[j]["column_name"].ToString();
                Col.EntityMapping = "";
                //Col.Length = int.Parse(dt.Rows[j]["max_length"].ToString());
                sb.Append("\t\t").Append("private ").Append(Col.Code).Append(" ").Append("_").Append(Col.Name).Append(";").Append("\r\n");
                bool vIsPk = false;
                foreach (string vItem in vPKArry)
                {
                    if (Col.Name == vItem)
                        vIsPk = true;
                }
                //if (Col.Code == "int" || Col.Code == "double" || vIsPk || Col.Code == "DateTime")
                //{
                //    sb.Append("\t\t[EntityMapping(");
                //    if (Col.Code == "int" || Col.Code == "double")
                //        Col.EntityMapping += "RealNumber = true,";
                //    if (vIsPk)
                //        Col.EntityMapping += "PrimaryKey = true,";
                //    if (Col.Code == "DateTime")
                //        Col.EntityMapping += "DateTime = true,";
                //    Col.EntityMapping = Col.EntityMapping.Substring(0, Col.EntityMapping.Length - 1);
                //    sb.Append(Col.EntityMapping);
                //    sb.Append(" )]\r\n");
                //}
                sb.Append("\t\t").Append("public ").Append(Col.Code).Append(" ").Append(Col.Name).Append("\r\n");
                sb.Append("\t\t{\r\n");
                sb.Append("\t\t\t").Append("get{ return _").Append(Col.Name).Append("; }\r\n");
                sb.Append("\t\t\t").Append("set\r\n");
                sb.Append("\t\t\t{\r\n");

                sb.Append("\t\t\t\tif (this.hash.ContainsKey(\"").Append(Col.Name).Append("\"))\r\n");
                sb.Append("\t\t\t\t{\r\n");
                sb.Append("\t\t\t\t\tthis.hash[\"" + Col.Name + "\"] = value.ToString();\r\n");
                sb.Append("\t\t\t\t}\r\n");
                sb.Append("\t\t\t\telse\r\n");
                sb.Append("\t\t\t\t{\r\n");
                sb.Append("\t\t\t\t\tthis.hash.Add(\"").Append(Col.Name).Append("\",value.ToString());\r\n");
                sb.Append("\t\t\t\t}\r\n");
                sb.Append("\t\t\t\t_").Append(Col.Name).Append(" = value;\r\n");
                sb.Append("\t\t\t}\r\n");
                sb.Append("\t\t}\r\n");
            }
            sb.Append("\t\tprivate Dictionary<string, string> _hash = new Dictionary<string, string>();\r\n");
            sb.Append("\t\tpublic Dictionary<string, string> hash\r\n");
            sb.Append("\t\t{\r\n");
            sb.Append("\t\t\tget\r\n");
            sb.Append("\t\t\t{\r\n");
            sb.Append("\t\t\t\treturn _hash;\r\n");
            sb.Append("\t\t\t}\r\n");
            sb.Append("\t\t\tset\r\n");
            sb.Append("\t\t\t{\r\n");
            sb.Append("\t\t\t\t _hash = value;\r\n");
            sb.Append("\t\t\t}\r\n");
            sb.Append("\t\t}\r\n");
            sb.Append("\t\t#endregion\r\n");
            sb.Append("\t}\r\n");
            sb.Append("}\r\n");
            sb.Append("\r\n");
            //return "";
            return sb.ToString();
        }

        /// <summary>
        /// 獲取表主鍵
        /// </summary>
        /// <param name="pTableName">表名</param>
        /// <param name="pType">數據庫類型</param>
        /// <returns></returns>
        public static string GetDBTablePK(string pTableName, DataBaseType pType)
        {
            string vSql = string.Empty;
            string vTemp = string.Empty;
            DataTable vDt = new DataTable();
            DBManager vDbmanager = new DBManager();
            vDbmanager.ConnectionOpen();
            #region SQL
            switch (pType.ToString())
            {
                case "OleDb":
                    vSql = "select * from {0}";
                    vDt = vDbmanager.Query(string.Format(vSql, pTableName)).Tables[0];
                    vTemp = vDt.PrimaryKey[0].ColumnName;
                    break;
                case "SqlServer":
                    vSql = "exec sp_helpconstraint '{0}'";
                    vDt = vDbmanager.Query(string.Format(vSql, pTableName)).Tables[0];
                    try 
                    { 
                        vTemp = vDt.Rows[0]["constraint_keys"].ToString(); 
                    }
                    catch { }
                   
                    break;
                case "Oracle":
                    vSql = @"SELECT column_name
                                        FROM user_constraints c, user_cons_columns col
                                        WHERE c.constraint_name = col.constraint_name
                                        AND c.constraint_type = 'P'
                                        AND c.table_name = '{0}'";
                    vDt = vDbmanager.Query(string.Format(vSql, pTableName)).Tables[0];
                    if (vDt.Rows.Count > 0)
                    {
                        foreach (DataRowView vRow in vDt.DefaultView)
                        {
                            vTemp += vRow[0].ToString() + ",";
                        }
                        vTemp = vTemp.Substring(0, vTemp.Length - 1);
                    }
                    break;
            }
            vDbmanager.ConnectionClose();
            #endregion
            return vTemp;
        }


        public static DataTable GetDBTableColumns(string pTableName)
        {
            DBManager _dbManage = new DBManager();
            DataTable dt = new DataTable();
            _dbManage.ConnectionOpen();
            dt = _dbManage.GetDBTableColumns(pTableName);
            _dbManage.ConnectionClose();
            return dt;
        }


        public string Code
        {
            get
            {
                return this._Code();
            }
        }
    }
}