<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillCheckSet.aspx.cs" Inherits="Data_BillCheckSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>产品新增/修改</title>
    <link href="../Css/Sys.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/lib/themes/gray/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/lib/themes/icon.css" />
    <script type="text/javascript" src="/lib/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/lib/jquery.easyui.min.js"></script>

    <script type="text/javascript" src ="/DatePicker/WdatePicker.js?random='" + Math.random() + "'"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nborderbottom">
        <div class="query">
            当前对账日期:
            &nbsp;&nbsp;<input id="txtBillCheckDate" class = "Wdate"  onclick="WdatePicker()" runat="server" type="text" style="width:100px"/>
            &nbsp;&nbsp;<a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-ok'" onclick="$('#btSave').click()">
                    确认</a>
        </div>
    </div>
   
    <div id="buttonhide">
        <asp:Button ID="btSave" runat="server" CssClass="sysbtbg" OnClick="btSave_Click"
            Text="保 存" />
    </div>
    </form>
</body>
</html>

