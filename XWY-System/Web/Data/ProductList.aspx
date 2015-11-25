<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="Data_ProductList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>产品管理</title>
    <link href="../Css/Sys.css?random='" + Math.random() + "'"  rel="stylesheet" type="text/css" />
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
                title: '产品列表',
                iconCls: 'icon-list',
                height: 420,
                singleSelect: false,
                autoRowHeight: false,
                url: '/Handler/ajax.ashx?class=BusinessLogic.Data.ProductAction&method=GetProductList',
                queryParams: {
                    'pKeywords': $("#txtKeywords").val(),
                    'pStatus': $("#ddlStatus").val()
                },
                idField: 'productid',
                columns: [[
			        { title: '产品名称', field: 'productname', width: 140 },
                    { title: '供应商名称', field: 'suppliername', width: 70 },
                    { title: '供应商电话', field: 'suppliertel', width: 60 },
                    { title: '进货价', field: 'buyprice', width: 50, align: 'right' },
                    { title: '代理价', field: 'agentprice', width: 50, align: 'right' },
                    { title: '零售价', field: 'saleprice', width: 60, align: 'right' },
                    { title: '产品备注', field: 'productmemo', width: 80 },
                    { title: '备注', field: 'memo', width: 50 },
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
                    {
                        title: '代理标示', field: 'isagent', width: 70, formatter: function (value, rec) {
                            if (rec.isagent == "Y") {
                                return "<span style=\" color:red;font-weight:bolder\">是</span>";
                            }
                            else {
                                return "<span style=\" color:green;font-weight:bolder\">否</span>";
                            }
                        }
                    },
                    { title: '排序', field: 'sortno', width: 50 },
                    { title: '录入日期', field: 'insertt', width: 10 },
                    { title: '录入人', field: 'insertp', width: 40 },
                    {
                        title: '操作', field: 'operate', width: 250, formatter: function (value, rec) {
                            var vLinkStr = "";
                            vLinkStr += "<a href=\"#\"  onclick=\"Edit(" + rec.productid + ")\" style=\" color:blue;\">修改</a>";

                            if (rec.status == '无效') {
                                vLinkStr += " | <a href=\"#\"  onclick=\"SetStatus(" + rec.productid + ",'有效')\" style=\" color:blue;\">改为有效</a>";
                            }
                            else {
                                vLinkStr += " | <a href=\"#\"  onclick=\"SetStatus(" + rec.productid + ",'无效')\" style=\" color:blue;\">改为无效</a>";
                            }

                            if (rec.ishot == 'Y') {
                                vLinkStr += " | <a href=\"#\"  onclick=\"SetHotStatus(" + rec.productid + ",'N','" + rec.status + "')\" style=\" color:blue;\">取消热门</a>";
                            }
                            else {
                                vLinkStr += " | <a href=\"#\"  onclick=\"SetHotStatus(" + rec.productid + ",'Y','" + rec.status + "')\" style=\" color:blue;\">设为热门</a>";
                            }

                            if (rec.isagent == 'Y') {
                                vLinkStr += " | <a href=\"#\"  onclick=\"SetAgentStatus(" + rec.productid + ",'N','" + rec.status + "')\" style=\" color:blue;\">取消代理</a>";
                            }
                            else {
                                vLinkStr += " | <a href=\"#\"  onclick=\"SetAgentStatus(" + rec.productid + ",'Y','" + rec.status + "')\" style=\" color:blue;\">设为代理</a>";
                            }
                            return vLinkStr;
                        }
                    }
                ]],
                pagination: true,
                pageNumber: 1,
                rownumbers: true,
                pageSize: 10,
                rowStyler: function (index, row) {
                    if (row.ishot == 'Y') {
                        // return 'color:red;'; // return inline style
                        //return 'background-color:#FF7F2A;color:#FF0000;'; // return inline style
                        return 'color:#FF0000;'; // return inline style
                        // the function can return predefined css class and inline style
                        // return {class:'r1', style:{'color:#fff'}};	
                    }
                }
            });
        }

        //新增
        function Add() {
            $("#ShowPageUrl").attr("src", "ProductEdit.aspx");
            $("#w").window('open');
        }

        //修改
        function Edit(pId) {
            $("#ShowPageUrl").attr("src", "ProductEdit.aspx?Id=" + pId);
            $("#w").window('open');
        }

        //更改状态
        function SetStatus(pId, pStatus) {
            if (!confirm('是否确认更改状态？')) {
                return;
            }
            var data = {
                'pId': pId,
                'pStatus': pStatus
            };
            $.ajax({
                type: "POST",
                url: "/Handler/ajax.ashx?class=BusinessLogic.Data.ProductAction&method=SetProductStatus",
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

        //热门状态设置
        function SetHotStatus(pId, pIsHot, pStatus) {
            if (pIsHot == "Y" && pStatus == "无效")
            {
                $.messager.alert('管理系统', '状态为无效的产品不能设为热门', 'error');
                return;
            }

            if (!confirm('是否确认更改热门状态？')) {
                return;
            }
            var data = {
                'pId': pId,
                'pIsHot': pIsHot
            };
            $.ajax({
                type: "POST",
                url: "/Handler/ajax.ashx?class=BusinessLogic.Data.ProductAction&method=SetProductHotStatus",
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

        //是否是代理产品设置
        function SetAgentStatus(pId, pIsAgent, pStatus) {
            if (pIsAgent == "Y" && pStatus == "无效") {
                $.messager.alert('管理系统', '状态为无效的产品不能设为代理产品', 'error');
                return;
            }

            if (!confirm('是否确认更改代理标示？')) {
                return;
            }
            var data = {
                'pId': pId,
                'pIsAgent': pIsAgent
            };
            $.ajax({
                type: "POST",
                url: "/Handler/ajax.ashx?class=BusinessLogic.Data.ProductAction&method=SetProductAgentStatus",
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
            产品名称:
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

            &nbsp;&nbsp;
            <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-save'" onclick="javascript:$('#btnExport').click()">导 出</a>
            <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Style="display:none;" />
        </div>
        <table id="tt">
        </table>
    </div>
    <div id="w" class="easyui-window" data-options="title:'产品新增/修改',iconCls:'icon-save',closed:true,modal:true,collapsible:false,minimizable:false"
        style="width: 600px; height: 340px; padding: 5px;">
        <iframe marginwidth="0" id="ShowPageUrl" marginheight="0" src="" frameborder="0"
            width="100%" height="100%" scrolling="auto"></iframe>
    </div>
    </form>
</body>
</html>

