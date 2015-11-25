using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Data_ProductList : BusinessLogic.BasePage.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlStatus.SelectedValue = "有效";
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        string pKeywords = txtKeywords.Text.Trim();
        string pStatus = ddlStatus.SelectedValue.Trim();

        BusinessLogic.Data.ProductAction vAction = new BusinessLogic.Data.ProductAction();
        DataTable dt = vAction.GetProductForExport(pKeywords, pStatus);
        MemoryStream ms = BusinessLogic.Control.ExcelHelper.RenderToExcel(dt);

        BusinessLogic.Control.ExcelHelper.RenderToBrowser(ms, this.Context, "ProductExports.xls");
    }
}