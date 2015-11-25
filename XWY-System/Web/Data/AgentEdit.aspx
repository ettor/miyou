<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgentEdit.aspx.cs" Inherits="Data_AgentEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>代理新增/修改</title>
    <link href="../Css/Sys.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/lib/themes/gray/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/lib/themes/icon.css" />
    <script type="text/javascript" src="/lib/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/lib/jquery.easyui.min.js"></script>

    <script type="text/javascript" src ="/DatePicker/WdatePicker.js?random='" + Math.random() + "'"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="1" width="100%" class="tableSave">
        <tr>
            <td class="tdleft" style="width:90px">
                &nbsp;代理名称:&nbsp;
            </td>
            <td>
                &nbsp;<asp:TextBox ID="txtAgentName" runat="server"  CssClass="inputcss"></asp:TextBox>&nbsp;
            </td>
            <td class="tdleft">
                &nbsp;代理电话:
            </td>
            <td>
                &nbsp;<asp:TextBox ID="txtAgentTel" runat="server"  CssClass="inputcss"></asp:TextBox>&nbsp;
            </td>
        </tr>
        
        <tr>
            <td class="tdleft">
                &nbsp;备注:&nbsp;
            </td>
            <td colspan="3">
                &nbsp;<asp:TextBox ID="txtMemo" runat="server"  CssClass="inputcss" Width="410px" TextMode="MultiLine" Rows="6"></asp:TextBox>&nbsp;
            </td>
        </tr>

        <tr>
            <td colspan="4" height="30" align="center">
                <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-ok'" onclick="$('#btSave').click()">
                    确认</a>&nbsp;&nbsp; <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-no'"
                        onclick="parent.window.Close();">关闭</a>
            </td>
        </tr>
    </table>
    <div id="buttonhide">
        <asp:Button ID="btSave" runat="server" CssClass="sysbtbg" OnClick="btSave_Click"
            Text="保 存" />
    </div>
    </form>
</body>
</html>

