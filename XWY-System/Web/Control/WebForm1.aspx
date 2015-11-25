<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebForm1.aspx.cs" Inherits="Control_WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%"><tr><td width="20%"><asp:Repeater ID="rpDB" runat="server">
            <HeaderTemplate>
                <table>
                <tr><td colspan="2"><%=DBName%> <input title="全选" onclick="CA()" tabindex="105" type="checkbox" name="allbox"></td></tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <input onclick="CCA(this)" type="checkbox" name="MSG" value="<%#Eval ("name") %>"></td>
                    <td>
                        <%#Eval("name")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
             <asp:Button ID="btnCreator" runat="server" Text="生成实体" OnClick="btCreator_Click" />
                   </td><td  width="80%"> <asp:TextBox ID="TextBox2" runat="server" Height="524px" TextMode="MultiLine" 
            Width="1004px"></asp:TextBox></td></tr></table>
     
       
        <br />
        <br />
        加密字串：<br />
        <asp:TextBox ID="TextBox1" runat="server" Height="80px" TextMode="MultiLine" 
            Width="438px"></asp:TextBox>
        <br />
        <asp:Label ID="lbResult" runat="server"></asp:Label>
        <br />
    </form>
</body>
</html>
