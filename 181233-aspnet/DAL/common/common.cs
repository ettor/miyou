using System;
using System.Collections.Generic;

using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace DAL.Common
{
    public class common
    {
        public static void ShowMessage(Page currentPage, string msgStyle, string msg)
        {
            currentPage.ClientScript.RegisterStartupScript(currentPage.GetType(), "tip", "$(function(){ $.messager.alert('米团科技','" + msg + "','" + msgStyle + "');});", true);
        }
    }
}
