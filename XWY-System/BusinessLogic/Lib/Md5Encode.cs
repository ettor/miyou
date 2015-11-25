using System;
using System.Collections.Generic;

using System.Text;

namespace BusinessLogic.Lib
{
    public class Md5Encode
    {
        /// <summary>
        /// MD5加密算法
        /// </summary>
        /// <param name="str"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string MD5Encode(string str, int code)
        {
            try
            {
                if (code == 16) //16位MD5加密（取32位加密的9~25字符） 
                {
                    return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").Substring(8, 16);
                }
                if (code == 32) //32位加密 
                {
                    return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
                }
                return "00000000000000000000000000000000";
            }
            catch (Exception)
            {
                return "00000000000000000000000000000000";
            }
        }

        public static string MD5Encode(string str)
        {
            try
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
            }
            catch (Exception)
            {
                return "00000000000000000000000000000000";
            }
        }
        

     

    }
}
