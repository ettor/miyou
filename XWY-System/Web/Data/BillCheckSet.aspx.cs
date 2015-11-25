using BMSP.Common;
using BMSP.DBAccesser.DBScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BusinessLogic.Bill;
using System.Data;

public partial class Data_BillCheckSet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string vSql = @"select a.BillCheckDate
                                            from Data_BillCheckSet a ";
            DBManager vDb = new DBManager();
            vDb.ConnectionOpen();
            DataTable vDt = vDb.Query(vSql).Tables[0];
            vDb.ConnectionClose();

            if (vDt != null && vDt.Rows.Count > 0)
            {
                try
                {
                    this.txtBillCheckDate.Value = vDt.Rows[0]["BillCheckDate"].ToString();
                }
                catch
                { }
            }
        }
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        string Id = Function.GetStringSafeFromQueryString(this, "Id", "Str");

        #region 防呆
        if (string.IsNullOrEmpty(txtBillCheckDate.Value.Trim()))
        {
            Function.Alert("请输入当前对账日期", this);
            return;
        }
        #endregion

        string vSql = string.Format(@" update Data_BillCheckSet set BillCheckDate='{0}' ", txtBillCheckDate.Value.Trim());
        
        DBManager vDb = new DBManager();
        vDb.ConnectionOpen();
        int vRes = vDb.ExecuteSql(vSql);
        vDb.ConnectionClose();

        if (vRes > 0)
        {
            Function.Alert("保存成功", this);
        }
        else
        {
            Function.Alert("保存失败", this);
        }
    }
}