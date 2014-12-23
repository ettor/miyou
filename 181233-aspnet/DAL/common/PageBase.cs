using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;

namespace DAL.Common
{
    public class PageBase : System.Web.UI.Page
    {
        public string currentUrl = "";
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            string url = System.Web.HttpContext.Current.Request.CurrentExecutionFilePath.ToString();
            currentUrl = url;
            string directorypath = System.IO.Path.GetDirectoryName(Request.PhysicalPath);

            if (url.ToUpper().IndexOf("LOGIN") >= 0)//判断如果地址栏中包含LOGIN字样，就不验证用户是否存在，反之则要验证用户是否登录状态
            { }
            else if (Session["user_id"] == null || Session["user_id"].ToString().Trim() == "")
            {
                //Response.Redirect("http://" + Request.Url.Authority + Request.ApplicationPath+"login.aspx");
                Response.Write("<script type='text/javascript'>window.parent.location.href='" + "http://" + Request.Url.Authority + Request.ApplicationPath + "/" + "admin/login.aspx" + "';</script>");
            }
        }

        protected override void OnInitComplete(EventArgs e)
        {
            base.OnInitComplete(e);
            this.Page.Title += "";
        }
    }
}
