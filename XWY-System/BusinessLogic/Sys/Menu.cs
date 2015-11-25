using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using BMSP.DBAccesser.DBScript;
using BMSP.DBAccesser;
using BMSP.Common;

namespace BusinessLogic.Sys
{
    public class Menu
    {
        ///// <summary>
        ///// 根据用户编号返回左侧的连接列表
        ///// </summary>
        ///// <returns></returns>
        public static string Menu_GetList()
        {
            DBManager vDb = new DBManager();
            vDb.ConnectionOpen();

            StringBuilder s = new StringBuilder();
            string strsql = "select * from Modules_Table a where a.M_PID = 0 order by a.M_px asc,a.m_id";
            DataSet ds = vDb.Query(strsql);

            vDb.ConnectionClose();

            s.Append("var _menus = { \"menus\": [ \r\n");
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                //int childcount = Menu_getchildcount(Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString()), Convert.ToInt32(ruid));
                int childcount = 1;
                if (childcount > 0)
                {
                    s.Append("      { \r\n");
                    s.Append("          \"menuid\": \"" + i.ToString() + "\", \"icon\": \"" + ds.Tables[0].Rows[i]["M_icon"].ToString()
                        + "\", \"menuname\": \"" + ds.Tables[0].Rows[i]["M_name"].ToString() + "\"");

                    s.Append(",\r\n");
                    s.Append("   \"menus\": [ \r\n");
                    //strsql = "select * from LZH_Menus where M_parid=" + ds.Tables[0].Rows[i][0].ToString() + " order by M_px desc";
                    strsql = "select * from Modules_Table a where a.M_PID=" + ds.Tables[0].Rows[i][0].ToString() + " order by a.M_px asc,a.m_id";
                    
                    vDb = new DBManager();
                    vDb.ConnectionOpen();

                    DataSet ChildDs = vDb.Query(strsql);

                    vDb.ConnectionClose();

                    for (int j = 0; j <= ChildDs.Tables[0].Rows.Count - 1; j++)
                    {
                        s.Append("{ \"menuid\": \"" + i.ToString() + j.ToString() + "\", \"menuname\": \"" + ChildDs.Tables[0].Rows[j]["M_name"].ToString()
                            + "\", \"icon\": \"" + ChildDs.Tables[0].Rows[j]["M_ICON"].ToString()
                            + "\", \"url\": \"" + ChildDs.Tables[0].Rows[j]["M_link"].ToString()
                            + "\" },\r\n");
                    }

                    s.Remove(s.Length - 3, 1);
                    s.Append("]\r\n");

                    s.Append("},\r\n");
                }

            }
            s.Remove(s.Length - 3, 1);

            s.Append("]");
            s.Append("};");
            return s.ToString();
        }
    }
}
