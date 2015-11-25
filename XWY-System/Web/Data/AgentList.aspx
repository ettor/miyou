<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgentList.aspx.cs" Inherits="Data_AgentList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>代理管理</title>
    <link href="../Css/Sys.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/lib/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/lib/themes/icon.css" />
    <script type="text/javascript" src="/lib/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/lib/jquery.easyui.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#w").window('close');
            Query();
        });

        function Query() {
            $('#tt').datagrid({
                title: '代理列表',
                iconCls: 'icon-list',
                height: 420,
                singleSelect: false,
                autoRowHeight: false,
                url: '/Handler/ajax.ashx?class=BusinessLogic.Data.AgentAction&method=GetAgentList',
                queryParams: {
                    'pKeywords': $("#txtKeywords").val(),
                    'pStatus': $("#ddlStatus").val()
                },
                idField: 'agentid',
                columns: [[
			        { title: '代理名称', field: 'agentname', width: 140 },
                    { title: 'Tel', field: 'agenttel', width: 90 },
                    { title: '备注', field: 'memo', width: 140 },
                    {
                        title: '状态', field: 'status', width: 50, formatter: function (value, rec) {
                            if (rec.status == "无效") {
                                return "<span style=\" color:red;font-weight:bolder\">无效</span>";
                            }
                            else {
                                return "<span style=\" color:green;font-weight:bolder\">有效</span>";
                            }
                        }
                    },
                    { title: '录入日期', field: 'insertt', width: 130 },
                    { title: '录入人', field: 'insertp', width: 70 },
                    {
                        title: '操作', field: 'operate', width: 110, formatter: function (value, rec) {
                            var vLinkStr = "";
                            vLinkStr += "<a href=\"#\"  onclick=\"Edit(" + rec.agentid + ")\" style=\" color:blue;\">修改</a>";

                            if (rec.status == '无效') {
                                vLinkStr += " | <a href=\"#\"  onclick=\"SetStatus(" + rec.agentid + ",'有效')\" style=\" color:blue;\">改为有效</a>";
                            }
                            else {
                                vLinkStr += " | <a href=\"#\"  onclick=\"SetStatus(" + rec.agentid + ",'无效')\" style=\" color:blue;\">改为无效</a>";
                            }

                            return vLinkStr;
                        }
                    }
                ]],
                pagination: true,
                pageNumber: 1,
                rownumbers: true,
                pageSize: 10
            });
        }

        //新增
        function Add() {
            $("#ShowPageUrl").attr("src", "AgentEdit.aspx");
            $("#w").window('open');
        }

        //修改
        function Edit(pId) {
            $("#ShowPageUrl").attr("src", "AgentEdit.aspx?Id=" + pId);
            $("#w").window('open');
        }

        //更改状态
        function SetStatus(pId,pStatus) {
            if (!confirm('是否确认更改状态？')) {
                return;
            }
            var data = {
                'pId': pId,
                'pStatus': pStatus
            };
            $.ajax({
                type: "POST",
                url: "/Handler/ajax.ashx?class=BusinessLogic.Data.AgentAction&method=SetAgentStatus",
                dataType: "json",
                data: data,
                success: function (json) {
                    if (json.Status == "error") {
                        $.messager.alert('管理系统', json.Msg, 'error');
                    }
                    else {
                        //$.messager.alert('管理系统', json.Msg, 'info', function () {
                        //    $('#tt').datagrid('reload');
                        //});
                        $('#tt').datagrid('reload');
                    }
                }
            });
        }

        //删除
        function Delete(pId) {
            if (!confirm('是否确认删除？')) {
                return;
            }
            var data = {
                'pId': pId
            };
            $.ajax({
                type: "POST",
                url: "/Handler/ajax.ashx?class=BusinessLogic.Data.AgentAction&method=AgentDelete",
                dataType: "json",
                data: data,
                success: function (json) {
                    if (json.Status == "error") {
                        $.messager.alert('管理系统', json.Msg, 'error');
                    }
                    else {
                        $.messager.alert('管理系统', json.Msg, 'info', function () {
                            $('#tt').datagrid('reload');
                        });
                    }
                }
            });
        }

        //关闭
        function Close() {
            $("#w").window('close');
            $('#tt').datagrid('reload');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nborderbottom">
        <div class="query">
            关键字:
            <asp:TextBox ID="txtKeywords" CssClass="inputcss" runat="server" Width="300px"></asp:TextBox>
            &nbsp;状态:
            <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem>==请选择==</asp:ListItem>
                    <asp:ListItem Value="有效">有效</asp:ListItem>
                    <asp:ListItem Value="无效">无效</asp:ListItem>
                </asp:DropDownList>
        </div>
        <div class="toolbar">
            <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-add'"
                    onclick="Add()">新增</a>&nbsp;
            <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-search'"
                onclick="Query()">查询</a>
        </div>
        <table id="tt">
        </table>
    </div>
    <div id="w" class="easyui-window" data-options="title:'代理新增/修改',iconCls:'icon-save',closed:true,modal:true,collapsible:false,minimizable:false"
        style="width: 600px; height: 220px; padding: 5px;">
        <iframe marginwidth="0" id="ShowPageUrl" marginheight="0" src="" frameborder="0"
            width="100%" height="100%" scrolling="auto"></iframe>
    </div>
    </form>
</body>
</html>

