<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
-->
</style>
<link rel="Stylesheet" type="text/css" href="Css/tipyellowsimple/tip-yellowsimple.css" />

<%--    <link href="/Css/Sys.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/lib/themes/gray/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/lib/themes/icon.css" />
    <script type="text/javascript" src="/lib/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/lib/jquery.easyui.min.js"></script>--%>
</head>
<body >
    <form id="form1" runat="server">
    <script src="Js/lazycat.password.js"></script>
    
    <div id="Mainframe">
     <div class="logotop"></div>
   
      <table width="450" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td bgcolor="#ADB9CB" style="padding:4px;">
          	<div class="loginbox">
   	    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td align="left" valign="middle" class="box_title">系统登录</td>
                  </tr>
                  <tr>
                    <td align="left" valign="middle" class="boxinfo" style="padding-top:10px;"><span class="left10">您的登录账号：</span></td>
                  </tr>
                  <tr>
                    <td align="left" valign="middle"><span class="left10">
                      <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="UserName" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                  </tr>
                  <tr>
                    <td align="left" valign="middle" class="boxinfo" ><span class="left10">您的密码：</span></td>
                  </tr>
                  <tr>
                    <td align="left" valign="middle" ><span class="left10">
                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="Password" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></span>
                    </td>
                  </tr>
                  <tr>
                    <td align="left" valign="middle" class="boxinfo" >
                        <span class="left10">
                        <asp:Button ID="Button1" runat="server" Height="27px" onclick="Button1_Click" 
                            Text="用户登录" Width="92px" />                        
                      </span></td>
              </tr>
                  <tr>
                    <td align="left" valign="middle" class="boxinfo" ></td>
            </tr>
                  <tr id="ShowErrorsInfo" runat="server" visible="false">
                    <td align="left" valign="middle" class="boxinfo">
                    <asp:Label  id="ErrorInfo" runat="server" CssClass="error"></asp:Label>
                    </td>
                  </tr>
                </table>
                <div class="clear"></div>
          </td>
        </tr>
      </table>
    </div>
    <input type="hidden" id="ecnum" runat="server" />
   

    <script type="text/javascript">
        $(function () {
            if (top != self) {
                var url = "/login.aspx";
                var ecnum = $("#ecnum").val();
                if (ecnum != null) {
                    url += "?ec=" + ecnum;
                }
                top.window.location.href = url;
            }

            $("#Password").iPass();

        });
    </script>
    
    </div>
     </form>
</body>
</html>

