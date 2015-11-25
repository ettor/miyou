<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillEdit.aspx.cs" Inherits="Bill_BillEdit" %>

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
    <table border="0" cellpadding="0" cellspacing="1" width="100%" class="tableSave">
        <tr>
            <td class="tdleft" style="width:90px">
                &nbsp;客户名称:&nbsp;
            </td>
            <td>
                &nbsp;<asp:TextBox ID="TextBox1" runat="server"  CssClass="inputcss"></asp:TextBox>&nbsp;
            </td>
            <td class="tdleft">
                &nbsp;客户电话:
            </td>
            <td>
                &nbsp;<asp:TextBox ID="TextBox2" runat="server"  CssClass="inputcss"></asp:TextBox>&nbsp;
            </td>
        </tr>

        <tr>
            <td class="tdleft">
                &nbsp;收货地址:&nbsp;
            </td>
            <td colspan="3">
                &nbsp;<asp:TextBox ID="TextBox3" runat="server"  CssClass="inputcss" Width="460px" TextMode="MultiLine" Rows="2"></asp:TextBox>&nbsp;
            </td>
        </tr>

        <tr>
            <td class="tdleft" style="width:90px">
                &nbsp;产品名称:&nbsp;
            </td>
            <td>
                &nbsp;<asp:DropDownList ID="TextBox4" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="TextBox4_SelectedIndexChanged">
            </asp:DropDownList>&nbsp;
            </td>
            <td class="tdleft">
                &nbsp;数量:&nbsp;
            </td>
            <td>
                &nbsp;<asp:TextBox ID="TextBox6" runat="server"  CssClass="inputcss"></asp:TextBox>&nbsp;
            </td>
        </tr>

        <tr>
            <td class="tdleft" style="width:90px">
                &nbsp;进货金额:
            </td>
            <td>
                &nbsp;<asp:TextBox ID="TextBox5" runat="server"  CssClass="inputcss"></asp:TextBox>&nbsp;
            </td>
            <td class="tdleft">
                &nbsp;订单金额:
            </td>
            <td>
                &nbsp;<asp:TextBox ID="TextBox7" runat="server"  CssClass="inputcss"></asp:TextBox>&nbsp;
            </td>
        </tr>

        <tr>
            <td class="tdleft" style="width:90px">
                &nbsp;状态:&nbsp;
            </td>
            <td>
                &nbsp;<asp:DropDownList ID="TextBox8" runat="server">
                    <asp:ListItem>==请选择==</asp:ListItem>
                    <asp:ListItem Value="未付款">未付款</asp:ListItem>
                    <asp:ListItem Value="已付款">已付款</asp:ListItem>
                    <asp:ListItem Value="已结束">已结束</asp:ListItem>
                </asp:DropDownList>&nbsp;
            </td>
            <td class="tdleft">
                &nbsp;代理人:
            </td>
            <td>
                &nbsp;<asp:DropDownList ID="TextBox9" runat="server" Width="150px">
            </asp:DropDownList>&nbsp;
            </td>
        </tr>
        
        <tr>
            <td class="tdleft" style="width:90px">
                &nbsp;订单日期:&nbsp;
            </td>
            <td>
                &nbsp;<input id="TextBox10" class = "Wdate"  onclick="WdatePicker()" runat="server" type="text" style="width:100px"/>&nbsp;
            </td>
            <td class="tdleft">
                &nbsp;快递单号:
            </td>
            <td>
                &nbsp;<asp:TextBox ID="TextBox11" runat="server"  CssClass="inputcss"></asp:TextBox>&nbsp;
            </td>
        </tr>

        <tr>
            <td class="tdleft" style="width:90px">
                &nbsp;下单状态:&nbsp;
            </td>
            <td>
                &nbsp;<asp:DropDownList ID="ddlOrderedStatus" runat="server">
                    <asp:ListItem>==请选择==</asp:ListItem>
                    <asp:ListItem Value="未下单">未下单</asp:ListItem>
                    <asp:ListItem Value="已下单">已下单</asp:ListItem>
                </asp:DropDownList>&nbsp;
            </td>
        </tr>

        <tr>
            <td class="tdleft">
                &nbsp;备注:&nbsp;
            </td>
            <td colspan="3">
                &nbsp;<asp:TextBox ID="txtMemo" runat="server"  CssClass="inputcss" Width="460px" TextMode="MultiLine" Rows="3"></asp:TextBox>&nbsp;
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

