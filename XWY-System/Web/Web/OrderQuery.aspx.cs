using BMSP.Common;
using BMSP.DBAccesser.DBScript;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_OrderNoQuery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        Label1.ForeColor = System.Drawing.Color.Black;

        if (string.IsNullOrEmpty(TextBox1.Text.Trim()))
        {
            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Text = "请输入收件人电话！";
            return;
        }

        BusinessLogic.Control.Common.WriteSysLog("OrderQuery", "快递单号查询-" + TextBox1.Text.Trim(), "");

        Label1.Text = "";

        string vSql = string.Format(@" select	top 5 a.BillDate,
	                                                    b.productname,
	                                                    a.ExpressNo
                                                    from	Bill a
                                                    left	join Data_Product b
                                                    on	a.productid = b.productid
                                                    where	a.CustomerTel = '{0}'
                                                    order	by a.billDate desc ", TextBox1.Text.Trim());
        DBManager vDb = new DBManager();
        vDb.ConnectionOpen();
        DataTable vDt = vDb.Query(vSql).Tables[0];
        vDb.ConnectionClose();

        if (vDt != null && vDt.Rows.Count > 0)
        {
            try
            {
                for (int i = 0; i < vDt.Rows.Count; i++)
                {
                    string vExpressNo = vDt.Rows[i]["ExpressNo"].ToString().Trim();
                    if (string.IsNullOrEmpty(vExpressNo))
                    {
                        vExpressNo = "暂无快递信息，请稍等...";
                    }

                    Label1.Text += (i+1).ToString() + "、下单日期【" + vDt.Rows[i]["BillDate"].ToString() + "，" + vDt.Rows[i]["productname"].ToString()
                        + "】，<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;快递信息【" + vExpressNo + "】<br/>";
                }
            }
            catch
            { }
        }

        if (Label1.Text.Trim() == "")
        {
            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Text = "暂无收件人信息，请稍等...<br/>";
        }
    }
}