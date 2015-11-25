using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BMSP.DBAccesser.DBScript
{
    /// <summary>
    ///功能说明:   字符串处理类 
    ///创建人:     Bano
    ///最后更新:   2009/09/17 
    ///创建时间:   2009/09/17     
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// 生成随机密码
        /// </summary>
        /// <param name="pwdchars">使用字符</param>
        /// <param name="pwdlen">生成长度</param>
        /// <returns></returns>
        public static string MakePassword(string pwdchars, int pwdlen)
        {
            string tmpstr = "";
            int iRandNum;
            Random rnd = new Random();
            for (int i = 0; i < pwdlen; i++)
            {
                iRandNum = rnd.Next(pwdchars.Length);
                tmpstr += pwdchars[iRandNum];
            }
            return tmpstr;
        }

        /// <summary>
        /// 判断是否为数字
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsUInt(string key)
        {
            if (Regex.IsMatch(key, @"^([\d])+$"))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 取数组列值
        /// </summary>
        /// <param name="src">字符串源</param>
        /// <param name="flag">截取标识</param>
        /// <param name="num">列</param>
        /// <returns></returns>
        public static string GetArrayValue(string src,char flag, int num)
        {
            string values = string.Empty;
            if (src.IndexOf(flag) > -1)
            {
                string[] ArrayList = src.Split(flag);
                if (ArrayList.Length > num)
                    values = ArrayList[num].ToString();
            }
            return values;
        }       
    }

}
