using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;

namespace BusinessLogic.BasePage
{
    public class PageBase : System.Web.UI.Page
    {
       //public  SysConfigInfo sci = new SysConfigInfo();
       public string currentUrl = "";
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //初始化系统配置
           
           
            string url = System.Web.HttpContext.Current.Request.CurrentExecutionFilePath.ToString();
            currentUrl = url;
      
            if (url.ToUpper().IndexOf("LOGIN") >= 0)//判断如果地址栏中包含LOGIN字样，就不验证用户是否存在，反之则要验证用户是否登录状态
            { }
            else {
                string sname = "UserName";
                if (Session[sname] == null || Session[sname].ToString() == "")
                {
                    Response.Redirect("http://" + Request.Url.Authority + Request.ApplicationPath+"/Login.aspx?ec=100001");//跳转到Login页面
                }
            }
            
        }

        protected override void OnInitComplete(EventArgs e)
        {
            base.OnInitComplete(e);
            if (!currentUrl.Contains("AgentList.aspx") && !currentUrl.Contains("ProductList.aspx")
                && !currentUrl.Contains("BillList.aspx") && !currentUrl.Contains("BillEdit.aspx")
                && !currentUrl.Contains("AgentEdit.aspx") && !currentUrl.Contains("ProductEdit.aspx")
                && !currentUrl.Contains("Memo.aspx") && !currentUrl.Contains("SysLog.aspx"))
            {
                Bindpagecssjs();
            }
            //this.Page.Title += " - 系统名称";
            this.Page.Title += "";
            ////验证授权
            //string url = System.Web.HttpContext.Current.Request.CurrentExecutionFilePath.ToString();
            //if (url.ToUpper().IndexOf("LOGIN") < 0)
            //{
            //    if (!DAL.Safe.EncryLVE.Lazycat_VLic())
            //    {
            //        //显示授权过期
            //        Response.Redirect("/Login.aspx?ec=100006");//跳转到Login页面
            //    }
            //}
        }

        /// <summary>
        /// 绑定样式和js框架
        /// </summary>
        private void Bindpagecssjs()
        {
            string url = "http://"+Request.Url.Authority+ Request.ApplicationPath;

            HtmlGenericControl favicon = new HtmlGenericControl("link");
            favicon.Attributes["rel"] = "shortcut icon";
            favicon.Attributes["href"] = url + "/favicon.ico";
            Page.Header.Controls.Add(favicon);

            //为网站套用css样式表
            HtmlGenericControl commcss = new HtmlGenericControl("link");
            commcss.Attributes["rel"] = "stylesheet";
            commcss.Attributes["type"] = "text/css";
            commcss.Attributes["href"] = url + "/css/default.css";
            this.Page.Header.Controls.Add(commcss);

            //js/themes/default/easyui.css
            HtmlGenericControl easycss = new HtmlGenericControl("link");
            easycss.Attributes["rel"] = "stylesheet";
            easycss.Attributes["type"] = "text/css";
            easycss.Attributes["href"] = url + "/js/themes/default/easyui.css";
            this.Page.Header.Controls.Add(easycss);

            HtmlGenericControl iconcss = new HtmlGenericControl("link");
            iconcss.Attributes["rel"] = "stylesheet";
            iconcss.Attributes["type"] = "text/css";
            iconcss.Attributes["href"] = url + "/js/themes/icon.css";
            this.Page.Header.Controls.Add(iconcss);

            HtmlGenericControl tipcss = new HtmlGenericControl("link");
            tipcss.Attributes["rel"] = "stylesheet";
            tipcss.Attributes["type"] = "text/css";
            tipcss.Attributes["href"] = url + "/css/tipyellowsimple/tip-yellowsimple.css";
            this.Page.Header.Controls.Add(tipcss);

            //js/themes/icon.css

            HtmlGenericControl jqueryjs = new HtmlGenericControl("script");
            jqueryjs.Attributes["src"] = url + "/js/jquery-1.4.4.min.js";
            this.Page.Header.Controls.Add(jqueryjs);

            HtmlGenericControl esayui_1 = new HtmlGenericControl("script");
            esayui_1.Attributes["src"] = url + "/js/jquery.easyui.min.js";
            this.Page.Header.Controls.Add(esayui_1);

            HtmlGenericControl datePicker = new HtmlGenericControl("script");
            datePicker.Attributes["src"] = url + "/js/jquery.datePicker.js";
            this.Page.Header.Controls.Add(datePicker);

            HtmlGenericControl lazycatmain = new HtmlGenericControl("script");
            lazycatmain.Attributes["src"] = url + "/js/lazycat.main.js";
            this.Page.Header.Controls.Add(lazycatmain);

            HtmlGenericControl lazycattip = new HtmlGenericControl("script");
            lazycattip.Attributes["src"] = url + "/js/lazycat.tip.js";
            this.Page.Header.Controls.Add(lazycattip);

            
        }

    }
}
