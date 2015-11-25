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

public partial class Data_ProductEdit : BusinessLogic.BasePage.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Id = Function.GetStringSafeFromQueryString(this, "Id", "Str");

        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                //                BaseService<Model.Data.Data_Agent> vAction = new BaseService<Model.Data.Data_Agent>();
                //                SqlParameters vSqlPar = new SqlParameters();
                //                vSqlPar.select = @"AgentId,
                //	                                AgentName,
                //	                                AgentTel,
                //	                                Memo,
                //	                                Status,
                //	                                InsertP,
                //	                                InsertT";
                //                vSqlPar.conditions = "AgentId=@Id";
                //                vAction.AddParameter("Id", Id);

                //                List<Model.Data.Data_Agent> vList = vAction.GetList(vSqlPar);

                string vSql = string.Format(@"select ProductId
                                  ,ProductName
                                  ,SupplierName,SupplierTel,Spec,BuyPrice,AgentPrice,SalePrice,ProductMemo
                                  ,Memo
                                  ,Status
                                  ,InsertP
                                  ,InsertT
                                  ,UpdateP
                                  ,UpdateT,sortno
                                FROM Data_Product where ProductId={0} ", Id);
                DBManager vDb = new DBManager();
                vDb.ConnectionOpen();
                DataTable vDt = vDb.Query(vSql).Tables[0];
                vDb.ConnectionClose();

                if (vDt != null && vDt.Rows.Count > 0)
                {
                    try
                    {
                        this.txtProductName.Text = vDt.Rows[0]["ProductName"].ToString();
                        this.TextBox1.Text = vDt.Rows[0]["SupplierName"].ToString();
                        this.TextBox2.Text = vDt.Rows[0]["SupplierTel"].ToString();
                        this.TextBox3.Text = vDt.Rows[0]["AgentPrice"].ToString();
                        this.TextBox4.Text = vDt.Rows[0]["SalePrice"].ToString();
                        this.TextBox5.Text = vDt.Rows[0]["BuyPrice"].ToString();
                        this.TextBox6.Text = vDt.Rows[0]["ProductMemo"].ToString();
                        this.TextBox7.Text = vDt.Rows[0]["sortno"].ToString();
                        txtMemo.Text = vDt.Rows[0]["Memo"].ToString();
                    }
                    catch
                    { }
                }
            }
        }
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        string Id = Function.GetStringSafeFromQueryString(this, "Id", "Str");

        #region 防呆
        if (string.IsNullOrEmpty(txtProductName.Text.Trim()))
        {
            Function.Alert("请输入代理名称", this);
            return;
        }

        if (string.IsNullOrEmpty(TextBox3.Text.Trim()))
        {
            Function.Alert("请输入代理价格", this);
            return;
        }

        if (string.IsNullOrEmpty(TextBox4.Text.Trim()))
        {
            Function.Alert("请输入零售价格", this);
            return;
        }

        if (string.IsNullOrEmpty(TextBox5.Text.Trim()))
        {
            Function.Alert("请输入进货价格", this);
            return;
        }
        //if (string.IsNullOrEmpty(txtAgentTel.Text.Trim()))
        //{
        //    Function.Alert("请输入联系人职位", this);
        //    return;
        //}

        #endregion

        Model.Data.Data_Product vData_Product = new Model.Data.Data_Product();
        vData_Product.ProductName = this.txtProductName.Text.Trim();

        vData_Product.SupplierName = this.TextBox1.Text.Trim();
        vData_Product.SupplierTel = this.TextBox2.Text.Trim();
        vData_Product.AgentPrice = this.TextBox3.Text.Trim();
        vData_Product.SalePrice = this.TextBox4.Text.Trim();
        vData_Product.BuyPrice = this.TextBox5.Text.Trim();
        vData_Product.ProductMemo = this.TextBox6.Text.Trim();
        vData_Product.Memo = txtMemo.Text.Trim();
        vData_Product.SortNo = this.TextBox7.Text.Trim() == "" ? "999" : this.TextBox7.Text.Trim();

        bool vResult = false;
        if (!string.IsNullOrEmpty(Id.Trim()))
        {
            vData_Product.ProductId = int.Parse(Id);

            vData_Product.UpdateT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            vData_Product.UpdateP = Session["UserId"].ToString();

            vResult = ProductAction.Edit(vData_Product);
        }
        else
        {
            vData_Product.Status = "有效";
            vData_Product.InsertT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            vData_Product.InsertP = Session["UserId"].ToString();

            vResult = ProductAction.Add(vData_Product);
        }
        if (vResult)
            this.Page.RegisterStartupScript("Close", "<script>parent.window.Close();</script>");
        else
            Function.Alert("维护失败", this);
    }
}