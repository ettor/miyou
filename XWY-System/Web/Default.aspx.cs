using BMSP.DBAccesser.DBScript;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBManager vDb = new DBManager();
            vDb.ConnectionOpen();

            string strsql = "select * from Sys_Memo a ";
            DataTable vDt = vDb.Query(strsql).Tables[0];

            if (vDt != null && vDt.Rows.Count > 0)
            {
                div1.InnerHtml = vDt.Rows[0]["memo"].ToString().Replace("\r\n", "<br/>");
            }

            vDb.ConnectionClose();
        }
    }
}