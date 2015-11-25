using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic.Sys;

public partial class _Default : BusinessLogic.BasePage.PageBase
{
    public string leftmenu = "";
    public string sysname = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        sysname = "订单跟踪系统";
        this.west.Attributes.Add("title", sysname);
        Loginname.Text = Session["UserName"].ToString();
        //string ruleid = Session[DAL.SysCommonConfig.IS_Users_Rule_Id].ToString();
        //if (Convert.ToInt32(ruleid) <= 0)
        //{
        //    Response.Redirect("login.aspx?ec=100002");
        //}
        leftmenu = BusinessLogic.Sys.Menu.Menu_GetList();
        //string show=Request.QueryString["show"];
        //if (show != null && show == "0")
        //{
        //    Top_Nav.Visible = false;
        //}

        //Response.Redirect("Modules/Default.aspx");
    }
}