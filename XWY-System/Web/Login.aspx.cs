using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessLogic.Sys;

public partial class Login : BusinessLogic.BasePage.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //只要访问当前页面就情况系统的session变量
        Session.Remove("UserId");
        Session.Remove("UserName");

        this.Page.Title = "订单跟踪 - 系统登录";

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string uname = this.UserName.Text.Trim();
        string pwd = this.Password.Text.Trim();

        string res = SysUserAction.Users_Login(uname, pwd);
        if (res == "success")
        {
            BusinessLogic.Control.Common.WriteSysLog("Login", "后台登录", uname);
            Response.Redirect("Mains.aspx");
        }
        else
        {
            this.ShowErrorsInfo.Visible = true;
            this.ErrorInfo.Text = res;
        }
    }
}