using BMSP.Common;
using BMSP.DBAccesser.DBScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BusinessLogic.Data;
using System.Data;
public partial class Data_Memo : BusinessLogic.BasePage.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string vSql = string.Format(@"select id,
	                                memo,
	                                InsertP,
	                                InsertT from Sys_Memo ");
            DBManager vDb = new DBManager();
            vDb.ConnectionOpen();
            DataTable vDt = vDb.Query(vSql).Tables[0];
            vDb.ConnectionClose();

            if (vDt != null && vDt.Rows.Count > 0)
            {
                try
                {
                    txtMemo.Text = vDt.Rows[0]["Memo"].ToString();
                }
                catch
                { }
            }
        }
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        #region 防呆
        if (string.IsNullOrEmpty(txtMemo.Text.Trim()))
        {
            Function.Alert("请输入备忘内容", this);
            return;
        }

        #endregion

        DBManager vDb = new DBManager();
        vDb.BeginTransaction();

        try
        {
            string vSql = "delete from Sys_Memo";
            vDb.ExecuteSql(vSql);

            vSql = string.Format(@"insert into Sys_Memo(Memo,InsertP,InsertT) values('{0}','{1}',getdate())", txtMemo.Text.Trim(), Session["UserId"].ToString());
            vDb.ExecuteSql(vSql);
            vDb.CommitTransaction();

            Function.Alert("操作成功", this);
        }
        catch
        {
            vDb.RollBackTransaction();
            Function.Alert("操作失败", this);
        }
            
    }
}