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

public partial class Data_AgentEdit : BusinessLogic.BasePage.PageBase
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

                string vSql = string.Format(@"select AgentId,
	                                AgentName,
	                                AgentTel,
	                                Memo,
	                                Status,
	                                InsertP,
	                                InsertT from Data_Agent where AgentId={0} ", Id);
                DBManager vDb = new DBManager();
                vDb.ConnectionOpen();
                DataTable vDt = vDb.Query(vSql).Tables[0];
                vDb.ConnectionClose();

                if (vDt != null && vDt.Rows.Count > 0)
                {
                    try
                    {
                        txtAgentName.Text = vDt.Rows[0]["AgentName"].ToString();
                        txtAgentTel.Text = vDt.Rows[0]["AgentTel"].ToString();
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
        if (string.IsNullOrEmpty(txtAgentName.Text.Trim()))
        {
            Function.Alert("请输入代理名称", this);
            return;
        }
        //if (string.IsNullOrEmpty(txtAgentTel.Text.Trim()))
        //{
        //    Function.Alert("请输入联系人职位", this);
        //    return;
        //}

        #endregion

        Model.Data.Data_Agent vData_Agent = new Model.Data.Data_Agent();
        vData_Agent.AgentName = txtAgentName.Text.Trim();
        vData_Agent.AgentTel = txtAgentTel.Text.Trim();
        vData_Agent.Memo = txtMemo.Text.Trim();

        bool vResult = false;
        if (!string.IsNullOrEmpty(Id.Trim()))
        {
            vData_Agent.AgentId = int.Parse(Id);

            vData_Agent.UpdateT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ;
            vData_Agent.UpdateP = Session["UserId"].ToString();

            vResult = AgentAction.Edit(vData_Agent);
        }
        else
        {
            vData_Agent.Status = "有效";
            vData_Agent.InsertT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            vData_Agent.InsertP = Session["UserId"].ToString();

            vResult = AgentAction.Add(vData_Agent);
        }
        if (vResult)
            this.Page.RegisterStartupScript("Close", "<script>parent.window.Close();</script>");
        else
            Function.Alert("维护失败", this);
    }
}