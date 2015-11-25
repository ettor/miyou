using System;
using System.Collections.Generic;
using System.Text;

namespace BMSP.DBAccesser.DBScript
{
    /// <summary>
    ///功能说明:   SQl字串处理类 
    ///创建人:     Bano
    ///最后更新:   2009/09/17 
    ///创建时间:   2009/09/17    
    /// </summary>
    public class SqlHelper
    {

        public static string FormatField(EntityMappingAttribute pEntity,string pField)
        {
            string vTemp = string.Empty;
            if (pEntity!=null)
            {
                if (pEntity.RealNumber)
                    vTemp = pField;
                else
                    vTemp = "'" + pField + "'";
            }
            else
                vTemp = "N'" + pField + "'";
            return vTemp;
        }

        public static string GetStringValue(string temp)
        {
            if (temp.IndexOf("'") != -1)
            {
                StringBuilder sb = new StringBuilder(temp);
                sb.Replace("'", "''");
                return sb.ToString();
            }
            else
            {
                return temp;
            }
        }

        public static string GetDateTimeValueQuote(string temp)
        {
            return DateTime.Parse(temp).ToString("yyyy/MM/dd HH:mm:ss");
        }

        /// <summary>
        /// 主键条件
        /// </summary>
        /// <param name="Pk"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetWherePkBySqlServer(string Pk,string id)
        {
            string values = string.Empty;
            if (!string.IsNullOrEmpty(Pk))
            {
                if (Pk.IndexOf(':') > -1)
                {
                    string[] tVal = Pk.Split(':');
                    if (tVal[1].ToLower() == "int")
                        values = " where " + tVal[0].ToLower() + "=" + int.Parse(id);
                    else
                        values = " where " + tVal[0].ToLower() + "='" + id + "'";
                }
            }
            return values;
        }
        public static string GetStringValueQuote(string temp)
        {
            temp = GetStringValue(temp);
            return "'" + temp + "'";
        }
        public static string GetNumberValue(byte temp)
        {
            return temp.ToString();
        }
        public static string GetNumberValue(short temp)
        {
            return temp.ToString();
        }
        public static string GetNumberValue(int temp)
        {
            return temp.ToString();
        }
        public static string GetNumberValue(long temp)
        {
            return temp.ToString();
        }
        public static string GetNumberValue(bool temp)
        {
            return temp ? "1" : "0";
        }
        public static string GetNumberValue(float temp)
        {
            return temp.ToString();
        }
        public static string GetNumberValue(double temp)
        {
            return temp.ToString();
        }
        public static string GetNumberValue(string temp)
        {
            return int.Parse(temp).ToString();
        }
        public static string GetNumberValue(object temp)
        {
            return int.Parse(temp.ToString()).ToString();
        }
    }
}
