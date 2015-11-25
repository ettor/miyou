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

public partial class Bill_BillEdit : BusinessLogic.BasePage.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Id = Function.GetStringSafeFromQueryString(this, "Id", "Str");

        if (!IsPostBack)
        {
            TextBox10.Value = DateTime.Now.ToString("yyyy-MM-dd");
			this.TextBox8.SelectedValue = "未付款";
            ddlOrderedStatus.SelectedValue = "未下单";
            BindProduct();
            BindAgent();
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

                string vSql = string.Format(@"select a.billid
                                                  ,a.customername
                                                  ,a.customertel
                                                  ,a.customeraddress
                                                  ,a.productid
                                                  ,a.buyprice
                                                  ,a.quantity
                                                  ,a.totalprice
                                                  ,a.agentid
                                                  ,a.status
                                                  ,a.expressno
                                                  ,a.billdate
                                                  ,a.memo
                                                  ,a.insertp
                                                  ,a.insertt
                                                  ,a.updatep
                                                  ,a.updatet
                                                  ,b.productname
                                                  ,c.agentname
                                                  ,a.orderedstatus
                                              from bill a
                                              left join Data_Product b 
                                              on a.productid=b.productid
                                              left join data_agent c
                                              on a.agentid=c.agentid
                                            where a.billid={0} ", Id);
                DBManager vDb = new DBManager();
                vDb.ConnectionOpen();
                DataTable vDt = vDb.Query(vSql).Tables[0];
                vDb.ConnectionClose();

                if (vDt != null && vDt.Rows.Count > 0)
                {
                    try
                    {
                        this.TextBox1.Text = vDt.Rows[0]["customername"].ToString();
                        this.TextBox2.Text = vDt.Rows[0]["customertel"].ToString();
                        this.TextBox3.Text = vDt.Rows[0]["customeraddress"].ToString();
                        this.TextBox4.SelectedValue = vDt.Rows[0]["productid"].ToString();
                        this.TextBox5.Text = vDt.Rows[0]["buyprice"].ToString();
                        this.TextBox6.Text = vDt.Rows[0]["quantity"].ToString();
                        this.TextBox7.Text = vDt.Rows[0]["totalprice"].ToString();
                        this.TextBox8.SelectedValue = vDt.Rows[0]["status"].ToString();
                        ddlOrderedStatus.SelectedValue = vDt.Rows[0]["orderedstatus"].ToString();
                        if (vDt.Rows[0]["agentid"].ToString().Trim() != "")
                        {
                            this.TextBox9.SelectedValue = vDt.Rows[0]["agentid"].ToString();
                        }
                        this.TextBox10.Value = vDt.Rows[0]["billdate"].ToString();
                        this.TextBox11.Text = vDt.Rows[0]["expressno"].ToString();
                        txtMemo.Text = vDt.Rows[0]["Memo"].ToString();
                    }
                    catch
                    { }
                }
            }
        }
    }

    private void BindProduct()
    {
        string vSql = @"select a.ProductId,
	                                a.ProductName,a.IsHot
                                from	Data_Product a where a.status='有效' order by a.IsHot desc,a.sortno, a.ProductId desc ";
        DBManager vDBManager = new DBManager();
        vDBManager.ConnectionOpen();
        DataTable vDt = vDBManager.Query(vSql).Tables[0];
        vDBManager.ConnectionClose();

        this.TextBox4.DataSource = vDt;
        this.TextBox4.DataTextField = "ProductName";
        this.TextBox4.DataValueField = "ProductId";
        this.TextBox4.DataBind();

        this.TextBox4.Items.Insert(0, "==请选择==");
    }

    private void BindAgent()
    {
        string vSql = @"select distinct a.AgentId,
	                                a.AgentName
                                from	Data_Agent a where a.status='有效' order by a.AgentId desc ";
        DBManager vDBManager = new DBManager();
        vDBManager.ConnectionOpen();
        DataTable vDt = vDBManager.Query(vSql).Tables[0];
        vDBManager.ConnectionClose();

        this.TextBox9.DataSource = vDt;
        this.TextBox9.DataTextField = "AgentName";
        this.TextBox9.DataValueField = "AgentId";
        this.TextBox9.DataBind();

        this.TextBox9.Items.Insert(0, "==请选择==");
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        string Id = Function.GetStringSafeFromQueryString(this, "Id", "Str");

        #region 防呆
        if (string.IsNullOrEmpty(TextBox1.Text.Trim()))
        {
            Function.Alert("请输入客户名称", this);
            return;
        }

        if (string.IsNullOrEmpty(TextBox2.Text.Trim()))
        {
            Function.Alert("请输入客户电话", this);
            return;
        }

        if (string.IsNullOrEmpty(TextBox3.Text.Trim()))
        {
            Function.Alert("请输入客户地址", this);
            return;
        }

        if (string.IsNullOrEmpty(TextBox6.Text.Trim()))
        {
            Function.Alert("请输入数量", this);
            return;
        }

        if (string.IsNullOrEmpty(TextBox5.Text.Trim()))
        {
            Function.Alert("请输入进货金额", this);
            return;
        }

        if (string.IsNullOrEmpty(TextBox7.Text.Trim()))
        {
            Function.Alert("请输入订单金额", this);
            return;
        }

        if (TextBox4.SelectedIndex == 0)
        {
            Function.Alert("请选择产品", this);
            return;
        }

        if (TextBox8.SelectedIndex == 0)
        {
            Function.Alert("请选择状态", this);
            return;
        }

        if (TextBox10.Value.Trim() == "")
        {
            Function.Alert("请输入订单日期", this);
            return;
        }

        //if (string.IsNullOrEmpty(txtAgentTel.Text.Trim()))
        //{
        //    Function.Alert("请输入联系人职位", this);
        //    return;
        //}

        #endregion

        Model.Bill.Bill vBill = new Model.Bill.Bill();

        vBill.CustomerName = this.TextBox1.Text.Trim();
        vBill.CustomerTel = this.TextBox2.Text.Trim();
        vBill.CustomerAddress = this.TextBox3.Text.Trim();
        vBill.ProductId = this.TextBox4.SelectedValue.Trim();
        vBill.BuyPrice = this.TextBox5.Text.Trim();
        vBill.Quantity = this.TextBox6.Text.Trim();
        vBill.TotalPrice = this.TextBox7.Text.Trim();
        vBill.Status = this.TextBox8.SelectedValue.Trim();
        vBill.OrderedStatus = ddlOrderedStatus.SelectedValue.Trim();
        if (this.TextBox9.SelectedIndex != 0)
        {
            vBill.AgentId = this.TextBox9.SelectedValue.Trim();
        }
        vBill.BillDate = this.TextBox10.Value.Trim();
        vBill.ExpressNo = this.TextBox11.Text.Trim();
        vBill.Memo = txtMemo.Text.Trim();

        bool vResult = false;
        if (!string.IsNullOrEmpty(Id.Trim()))
        {
            vBill.BillId = int.Parse(Id);

            vBill.UpdateT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            vBill.UpdateP = Session["UserId"].ToString();

            vResult = BillAction.Edit(vBill);
        }
        else
        {
            vBill.InsertT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            vBill.InsertP = Session["UserId"].ToString();

            vBill.Source = "网站";

            vResult = BillAction.Add(vBill);
        }
        if (vResult)
            this.Page.RegisterStartupScript("Close", "<script>parent.window.Close();</script>");
        else
            Function.Alert("维护失败", this);
    }
    protected void TextBox4_SelectedIndexChanged(object sender, EventArgs e)
    {
        string vProductId = TextBox4.SelectedValue.ToString();
        string vSql = string.Format(@"select a.BuyPrice
                                from	Data_Product a where ProductId = {0} ", vProductId);
        DBManager vDBManager = new DBManager();
        vDBManager.ConnectionOpen();
        DataTable vDt = vDBManager.Query(vSql).Tables[0];
        vDBManager.ConnectionClose();

        TextBox5.Text = "";
        if (vDt != null && vDt.Rows.Count > 0)
        {
            TextBox5.Text = vDt.Rows[0]["BuyPrice"].ToString();
        }
    }
}