<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillList.aspx.cs" Inherits="Bill_BillList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>订单管理</title>
    <link href="../Css/Sys.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/lib/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/lib/themes/icon.css" />
    <script type="text/javascript" src="/lib/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/lib/jquery.easyui.min.js"></script>

    <script type="text/javascript" src ="/DatePicker/WdatePicker.js?random='" + Math.random() + "'"></script>
    <script type="text/javascript">
        $(function () {
            $("#w").window('close');

            $("#spanBuyPrice").html("0");
            $("#spanSalePrice").html("0");
            $("#spanProfit").html("0");

            Query();
        });

        function Query() {
            $('#tt').datagrid({
                title: '订单列表',
                iconCls: 'icon-list',
                height: 420,
                singleSelect: false,
                autoRowHeight: false,
                url: '/Handler/ajax.ashx?class=BusinessLogic.Bill.BillAction&method=GetBillList',
                queryParams: {
                    'pKeywords': $("#txtKeywords").val(),
                    'pStatus': $("#ddlStatus").val(),
                    'pSource': $("#ddlSource").val(),
                    'pSDate': $("#txtSDate").val(),
                    'pEDate': $("#txtEDate").val(),
                    'pIncludeFinished': $("#CheckBox1").is(':checked'),
                    'pOrderedStatus': $("#ddlOrderedStatus").val()
                },
                idField: 'billid',
                columns: [[
			        { title: '客户名称', field: 'customername', width: 60 },
                    { title: '客户电话', field: 'customertel', width: 90 },
                    { title: '客户地址', field: 'customeraddress', width: 60 },
                    { title: '产品名称', field: 'productname', width: 70 },
                    { title: '数量', field: 'quantity', width: 40, align: 'right' },
                    { title: '进货金额', field: 'buyprice', width: 60, align: 'right' },
                    { title: '订单金额', field: 'totalprice', width: 60, align: 'right' },
                    {
                        title: '净利润', field: 'profit', width: 60, align: 'right', formatter: function (value, rec) {
                            if (rec.profit < "0") {
                                return "<span style=\" color:red;font-weight:bolder\">" + rec.profit + "</span>";
                            }
                            else {
                                return "<span style=\" color:green;font-weight:bolder\">" + rec.profit + "</span>";
                            }
                        }
                    },
                    { title: '代理', field: 'agentname', width: 30 },
                    { title: '快递单号', field: 'expressno', width: 30 },
                    { title: '订单日期', field: 'billdate', width: 70 },
                    { title: '备注', field: 'memo', width: 40 },
                    {
                        title: '状态', field: 'status', width: 50, formatter: function (value, rec) {
                            if (rec.status == "未付款") {
                                return "<span style=\" color:red;font-weight:bolder\">未付款</span>";
                            }
                            else if (rec.status == "已付款") {
                                return "<span style=\" color:green;font-weight:bolder\">已付款</span>";
                            }
                            else if (rec.status == "已结束") {
                                return "<span style=\" color:green;font-weight:bolder\">已结束</span>";
                            }
                        }
                    },
                    {
                        title: '下单状态', field: 'orderedstatus', width: 50, formatter: function (value, rec) {
                            if (rec.orderedstatus == "未下单") {
                                return "<span style=\" color:red;font-weight:bolder\">未下单</span>";
                            }
                            else if (rec.orderedstatus == "已下单") {
                                return "<span style=\" color:green;font-weight:bolder\">已下单</span>";
                            }
                        }
                    },
                    { title: '录入时间', field: 'insertt', width: 70 },
                    { title: '录入人', field: 'insertp', width: 70, hidden: true },
                    { title: '数据来源', field: 'source', width: 40 },
                    {
                        title: '操作', field: 'operate', width: 100, formatter: function (value, rec) {
                            var vLinkStr = "";
                            vLinkStr += "<a href=\"#\"  onclick=\"Edit(" + rec.billid + ")\" style=\" color:blue;\">修改</a>";

                            if (rec.status == '未付款') {
                                vLinkStr += " | <a href=\"#\"  onclick=\"SetStatus(" + rec.billid + ",'已付款')\" style=\" color:blue;\">改为已付款</a>";
                            }

                            return vLinkStr;
                        }
                    },
                    {
                        title: '操作2', field: 'operate2', width: 60, formatter: function (value, rec) {
                            var vLinkStr = "";

                            if (rec.status == '已付款') {
                                vLinkStr += "<a href=\"#\"  onclick=\"SetStatus(" + rec.billid + ",'已结束')\" style=\" color:blue;\">改为已结束</a>";
                            }

                            return vLinkStr;
                        }
                    },
                    {
                        title: '操作3', field: 'operate3', width: 70, formatter: function (value, rec) {
                            var vLinkStr = "";

                            if (rec.orderedstatus == '未下单') {
                                vLinkStr += "<a href=\"#\"  onclick=\"SetOrderedStatus(" + rec.billid + ",'已下单')\" style=\" color:blue;\">改为已下单</a>";
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
                    if (row.status == '已结束') {
                        // return 'color:red;'; // return inline style
                        return 'background-color:#D4FFD4;'; // return inline style
                        //return 'color:#FF0000;'; // return inline style
                        // the function can return predefined css class and inline style
                        // return {class:'r1', style:{'color:#fff'}};	
                    }
                }
            });

            QueryProfit();
        }

        //新增
        function Add() {
            $("#ShowPageUrl").attr("src", "BillEdit.aspx");
            $("#w").window('open');
        }

        //修改
        function Edit(pId) {
            $("#ShowPageUrl").attr("src", "BillEdit.aspx?Id=" + pId);
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
                url: "/Handler/ajax.ashx?class=BusinessLogic.Bill.BillAction&method=SetBillStatus",
                dataType: "json",
                data: data,
                success: function (json) {
                    if (json.Status == "error") {
                        $.messager.alert('管理系统', json.Msg, 'error');
                    }
                    else {
                        //$.messager.alert('管理系统', json.Msg, 'info', function () {
                        //    $('#tt').datagrid('reload');
                        //    QueryProfit();
                        //});
                        $('#tt').datagrid('reload');
                        QueryProfit();
                    }
                }
            });
        }

        function SetOrderedStatus(pId, pStatus) {
            if (!confirm('是否确认更改状态？')) {
                return;
            }
            var data = {
                'pId': pId,
                'pStatus': pStatus
            };
            $.ajax({
                type: "POST",
                url: "/Handler/ajax.ashx?class=BusinessLogic.Bill.BillAction&method=SetBillOrderedStatus",
                dataType: "json",
                data: data,
                success: function (json) {
                    if (json.Status == "error") {
                        $.messager.alert('管理系统', json.Msg, 'error');
                    }
                    else {
                        //$.messager.alert('管理系统', json.Msg, 'info', function () {
                        //    $('#tt').datagrid('reload');
                        //    QueryProfit();
                        //});
                        $('#tt').datagrid('reload');
                        QueryProfit();
                    }
                }
            });
        }

        //查询账款流水总金额
        function QueryProfit() {
            var data = {
                'pKeywords': $("#txtKeywords").val(),
                'pStatus': $("#ddlStatus").val(),
                'pSource': $("#ddlSource").val(),
                'pSDate': $("#txtSDate").val(),
                'pEDate': $("#txtEDate").val(),
                'pIncludeFinished': $("#CheckBox1").is(':checked'),
                'pOrderedStatus': $("#ddlOrderedStatus").val()
            };
            $.ajax({
                type: "POST",
                url: "/Handler/ajax.ashx?class=BusinessLogic.Bill.BillAction&method=QueryProfit",
                dataType: "json",
                data: data,
                success: function (json) {
                    if (json != null) {
                        $("#spanBuyPrice").html(json[0].buyprice);
                        $("#spanSalePrice").html(json[0].totalprice);
                        $("#spanProfit").html(json[0].profit);
                    }
                    else {
                        $.messager.alert('管理系统', "查询账款流水总金额出错", 'error');
                    }
                }
            });
        }

        //删除
        //function Delete(pId) {
        //    if (!confirm('是否确认删除？')) {
        //        return;
        //    }
        //    var data = {
        //        'pId': pId
        //    };
        //    $.ajax({
        //        type: "POST",
        //        url: "/Handler/ajax.ashx?class=BusinessLogic.Bill.AgentAction&method=AgentDelete",
        //        dataType: "json",
        //        data: data,
        //        success: function (json) {
        //            if (json.Status == "error") {
        //                $.messager.alert('管理系统', json.Msg, 'error');
        //            }
        //            else {
        //                $.messager.alert('管理系统', json.Msg, 'info', function () {
        //                    $('#tt').datagrid('reload');
        //                });
        //            }
        //        }
        //    });
        //}

        //关闭
        function Close() {
            $("#w").window('close');
            $('#tt').datagrid('reload');
            QueryProfit();
        }

        function clearday() {
            location.href = "BillList.aspx?pDate=9999";
        }

        function thisday() {
            var thisdate = '<%=thisdate %>';
            location.href = "BillList.aspx?pDate=" + thisdate;
        }

        function lastday() {
            var lastdate = '<%=lastdate %>';
            location.href = "BillList.aspx?pDate=" + lastdate;
        }

        function nextday() {
            var nextdate = '<%=nextdate %>';
            location.href = "BillList.aspx?pDate=" + nextdate;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nborderbottom">
        <div class="query">
                <table>
                    <tr>
                        <td>
                            关键字:
                        </td>
                        <td>
                            <asp:TextBox ID="txtKeywords" CssClass="inputcss" runat="server" Width="220px"></asp:TextBox>
                        </td>
                        <td>
                            数据来源:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSource" runat="server">
                                <asp:ListItem>==请选择==</asp:ListItem>
                                <asp:ListItem Value="网站">网站</asp:ListItem>
                                <asp:ListItem Value="微信">微信</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            状态:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatus" runat="server">
                                <asp:ListItem>==请选择==</asp:ListItem>
                                <asp:ListItem Value="未付款">未付款</asp:ListItem>
                                <asp:ListItem Value="已付款">已付款</asp:ListItem>
                                <asp:ListItem Value="已结束">已结束</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            下单状态:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlOrderedStatus" runat="server">
                                <asp:ListItem>==请选择==</asp:ListItem>
                                <asp:ListItem Value="未下单">未下单</asp:ListItem>
                                <asp:ListItem Value="已下单">已下单</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox1" runat="server" />包含已结束订单
                        </td>
                        
                    </tr>
                    <tr>
                        <td>
                            起止日期：
                        </td>
                        <td>
                            <input id="txtSDate" class = "Wdate"  onclick="WdatePicker()" runat="server" type="text" style="width:100px"/>
                             ~
                            <input id="txtEDate" class = "Wdate"  onclick="WdatePicker()" runat="server" type="text" style="width:100px"/>
                        </td>
                        <td colspan="7">
                            <a href="#" id="clearday" style="color:blue" onclick="clearday()">清空</a>
                            &nbsp;<a href="#" id="thisday" style="color:blue" onclick="thisday()">今天</a>
                            &nbsp;<a href="#" id="lastday" style="color:blue" onclick="lastday()">前一天</a>
                            &nbsp; <a href="#" id="nextday" style="color:blue" onclick="nextday()">后一天</a>
                        </td>
                    </tr>
                </table>
        </div>
        <div class="toolbar">
            <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-add'"
                    onclick="Add()">新增</a>&nbsp;
            <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-search'"
                onclick="Query()">查询</a>

            &nbsp;&nbsp;
            <a href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-save'" onclick="javascript:$('#btnExport').click()">导 出</a>
            <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Style="display:none;" />

            <span style="margin-left:300px; font-weight:bold; font-size:14px">
                进货金额：<span id="spanBuyPrice" style="color:red; font-style:italic; font-size:15px"></span>
                &nbsp;&nbsp;&nbsp;销售金额：<span id="spanSalePrice" style="color:red; font-style:italic; font-size:15px"></span>
                &nbsp;&nbsp;&nbsp;总利润：<span id="spanProfit" style="color:red; font-style:italic; font-size:15px"></span></span>
        </div>
        <table id="tt">
        </table>
    </div>
    <div id="w" class="easyui-window" data-options="title:'订单新增/修改',iconCls:'icon-save',closed:true,modal:true,collapsible:false,minimizable:false"
        style="width: 700px; height: 450px; padding: 5px;">
        <iframe marginwidth="0" id="ShowPageUrl" marginheight="0" src="" frameborder="0"
            width="100%" height="100%" scrolling="auto"></iframe>
    </div>
    </form>
</body>
</html>

