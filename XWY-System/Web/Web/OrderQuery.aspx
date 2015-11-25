<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderQuery.aspx.cs" Inherits="Web_OrderNoQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=0.5, maximum-scale=2.0, user-scalable=yes" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="line-height:28px; font-family:Verdana, '宋体', sans-serif; font-size:14px;color:#323232;margin-left:10px;margin:0 auto; margin-top:50px">
        收件人电话：<asp:TextBox ID="TextBox1" runat="server" Height="25px"></asp:TextBox>&nbsp;<asp:button runat="server" text="查 询" OnClick="Unnamed1_Click" />
        <br />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <br />
        注：每次查询只显示最近5条订单信息
        <br />
        ----------------------------------
        <br />
        <span style="color:green">如有问题，请加微信 <span style="font-weight:bold;color:blue">15753517601</span> 联系，感谢您的支持！</span>
    </div>
    </form>
</body>

</html>
