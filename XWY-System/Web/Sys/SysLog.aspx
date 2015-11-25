<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SysLog.aspx.cs" Inherits="Sys_SysLog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>操作日志</title>
    <link href="../Css/Sys.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/lib/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/lib/themes/icon.css" />
    <script type="text/javascript" src="/lib/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/lib/jquery.easyui.min.js"></script>

    <script type="text/javascript" src ="/DatePicker/WdatePicker.js?random='" + Math.random() + "'"></script>
    <script type="text/javascript">
        $(function () {
            Query();
        });

        function Query() {
            $('#tt').datagrid({
                title: '操作日志列表',
                iconCls: 'icon-list',
                height: 420,
                singleSelect: false,
                autoRowHeight: false,
                url: '/Handler/ajax.ashx?class=BusinessLogic.Sys.SysUserAction&method=GetSysLogList',
                queryParams: {
                    //'pKeywords': $("#txtKeywords").val(),
                    //'pStatus': $("#ddlStatus").val(),
                    //'pSource': $("#ddlSource").val(),
                    //'pSDate': $("#txtSDate").val(),
                    //'pEDate': $("#txtEDate").val()
                },
                idField: 'id',
                columns: [[
			        { title: '操作类型', field: 'operatetype', width: 110 },
                    { title: 'ip', field: 'ip', width: 130 },
                    { title: '操作说明', field: 'memo', width: 200 },
                    { title: '操作人', field: 'insertp', width: 80 },
                    { title: '操作时间', field: 'insertt', width: 150 }
                ]],
                pagination: true,
                pageNumber: 1,
                rownumbers: true,
                pageSize: 10
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nborderbottom">
        <%--<div class="query">
            关键字:
            <asp:TextBox ID="txtKeywords" CssClass="inputcss" runat="server" Width="300px"></asp:TextBox>
            &nbsp;起止日期：
            <input id="txtSDate" class = "Wdate"  onclick="WdatePicker()" runat="server" type="text" style="width:100px"/>
             ~
            <input id="txtEDate" class = "Wdate"  onclick="WdatePicker()" runat="server" type="text" style="width:100px"/>
            &nbsp;&nbsp;数据来源:
            <asp:DropDownList ID="ddlSource" runat="server">
                    <asp:ListItem>==请选择==</asp:ListItem>
                    <asp:ListItem Value="网站">网站</asp:ListItem>
                    <asp:ListItem Value="微信">微信</asp:ListItem>
                </asp:DropDownList>
            &nbsp;&nbsp;状态:
            <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem>==请选择==</asp:ListItem>
                    <asp:ListItem Value="未付款">未付款</asp:ListItem>
                    <asp:ListItem Value="已付款">已付款</asp:ListItem>
                </asp:DropDownList>
        </div>
            --%>
        <div class="toolbar">
            <%--<a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-add'"
                    onclick="Add()">新增</a>&nbsp;--%>
            <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-search'"
                onclick="Query()">查询</a>

            <%--&nbsp;&nbsp;
            <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-save'" onclick="javascript:$('#btnExport').click()">导 出</a>
            <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Style="display:none;" />--%>
        </div>
        <table id="tt">
        </table>
    </div>
    </form>
</body>
</html>

