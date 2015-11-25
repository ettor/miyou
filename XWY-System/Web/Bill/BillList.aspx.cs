using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Bill_BillList : BusinessLogic.BasePage.PageBase
{
    public string lastdate = "";
    public string nextdate = "";
    public string thisdate = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            thisdate = DateTime.Now.ToString("yyyy-MM-dd");
            //txtSDate.Value = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
            if (Request.QueryString["pDate"] == null || Request.QueryString["pDate"].ToString().Trim() == "")
            {
                txtSDate.Value = DateTime.Now.ToString("yyyy-MM") + "-01";
                txtEDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                lastdate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                nextdate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            }
            else
            {
                if (Request.QueryString["pDate"].ToString().Trim() == "9999")
                {
                    txtSDate.Value = "";
                    txtEDate.Value = "";
                    lastdate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                    nextdate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                }
                else
                {
                    txtSDate.Value = Request.QueryString["pDate"].ToString().Trim();
                    txtEDate.Value = Request.QueryString["pDate"].ToString().Trim();
                    lastdate = DateTime.Parse(Request.QueryString["pDate"].ToString().Trim()).AddDays(-1).ToString("yyyy-MM-dd");
                    nextdate = DateTime.Parse(Request.QueryString["pDate"].ToString().Trim()).AddDays(1).ToString("yyyy-MM-dd");
                }
            }
            CheckBox1.Checked = true;
        }
    }

    //public string GetLastDay()
    //{
    //    string vRes = "";

    //    if (txtEDate.Value.Trim() != "")
    //    {
    //        vRes = DateTime.Parse(txtEDate.Value).AddDays(-1).ToString("yyyy-MM-dd");

    //        txtSDate.Value = vRes;
    //        txtEDate.Value = vRes;
    //    }

    //    return vRes;
    //}

    public string GetNextDay()
    {
        string vRes = "";

        if (txtEDate.Value.Trim() != "")
        {
            vRes = DateTime.Parse(txtEDate.Value).AddDays(1).ToString("yyyy-MM-dd");

            txtSDate.Value = vRes;
            txtEDate.Value = vRes;
        }

        return vRes;
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        string pKeywords = txtKeywords.Text.Trim();
        string pStatus = ddlStatus.SelectedValue.Trim();
        string pSource = ddlSource.SelectedValue.Trim();
        string pSDate = txtSDate.Value.Trim();
        string pEDate = txtEDate.Value.Trim();
        string pIncludeFinished = CheckBox1.Checked ? "true" : "false";
        string pOrderedStatus = ddlOrderedStatus.SelectedValue.Trim();

        BusinessLogic.Bill.BillAction vAction = new BusinessLogic.Bill.BillAction();
        DataTable dt = vAction.GetBillForExport(pKeywords, pStatus, pSource, pSDate, pEDate, pIncludeFinished, pOrderedStatus);
        MemoryStream ms = BusinessLogic.Control.ExcelHelper.RenderToExcel(dt);

        BusinessLogic.Control.ExcelHelper.RenderToBrowser(ms, this.Context, "OrderExports.xls");
    }
}