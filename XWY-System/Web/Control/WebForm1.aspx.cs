using BMSP.DBAccesser;
using BMSP.DBAccesser.DBScript;
using BusinessLogic.Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Control_WebForm1 : System.Web.UI.Page
{
    private string mTableName = string.Empty;
    private string mDbname = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rpDB.DataSource = GetDBTree();
            rpDB.DataBind();
            //TextBox1.Text = BMSP.Common.Encrypts.EncryptQueryString("/images/user/sfweiw.jpg");
            //TextBox1.Text = BMSP.Common.Encrypts.DecryptQueryString("5C9CE7E6B9354463F539DF4C890BD805C51777CA2CF5728AB5");
        }
    }

    public string DBName
    {
        get { return mDbname; }
        set { mDbname = value; }
    }

    protected void btCreator_Click(object sender, EventArgs e)
    {
        string vNameStr = Request.Form["MSG"];
        if (!string.IsNullOrEmpty(vNameStr))
        {
            string[] vArrayMSG = vNameStr.Split(',');
            for (int vLoop = 0; vLoop < vArrayMSG.Length; vLoop++)
            {
                mTableName = vArrayMSG[vLoop].ToString();
                //string vPath = Server.MapPath("/");
                //vPath = vPath.Replace("WFP.WorkFlow", "WFP.Model");
                //using (TextWriter vTw = new StreamWriter(vPath + mTableName + ".cs", false, System.Text.Encoding.GetEncoding("UTF-8")))
                //{
                    EntityCreator vEc = new EntityCreator(mTableName, DataBaseType.SqlServer);
                    TextBox2.Text = vEc.Code;
                    //vTw.Write(vEc.Code);
                    //vTw.Close();
                //}
            }
        }
    }


    public static DataTable GetDBTree()
    {
        //DbHelperSQL.ConnectionStr = "RDAS";
        DBManager _dbManage = new DBManager();
        DataTable dt = new DataTable();
        _dbManage.ConnectionOpen();
        dt = _dbManage.GetDBTable();
        _dbManage.ConnectionClose();
        return dt;
    }
}