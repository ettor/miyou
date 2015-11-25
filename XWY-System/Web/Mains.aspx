<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mains.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单跟踪系统</title>
</head>
<body class="easyui-layout" style="overflow-y: hidden" scroll="no"><script src="/js/Lazycat.loading.js"></script>
    <script>
        function killErrors() {
            return true;
        }
        window.onerror = killErrors;
        var sysname = '<%=sysname %>';
    </script>
    
    <script type="text/javascript">

        $(function () {
            $('#loginOut').click(function () {
                $.messager.confirm(sysname, '您确定要退出本次登录吗?', function (r) {
                    if (r) {
                        window.location.href = 'Login.aspx';
                    }
                });
            })
        })
    </script>
    <script src="js/lazycat.menu.js"></script>
    <script>
        <%=leftmenu %>
</script>
    <noscript>
        <div style="position: absolute; z-index: 100000; height: 2046px; top: 0px; left: 0px;
            width: 100%; background: white; text-align: center;">
            <img src="images/noscript.gif" alt='抱歉，请开启脚本支持！' />
        </div>
    </noscript>
    <div region="north" id="Top_Nav" runat="server"  split="false" border="false" style="overflow: hidden; height: 30px;
        line-height: 30px; font-family: Verdana, 微软雅黑,黑体; background:url(images/bg/header1.jpg) left top no-repeat;">
        <%--<img src="images/logo1.jpg" style=" margin-top:5px; margin-left:10px;" />--%>
        <span class="head">
       </span>
    </div>
    <div region="south" split="false" style="height: 30px; background: #D2E0F2;">
        <div class="copyright"><b>订单跟踪系统</b>   欢迎 <asp:Label ID="Loginname" runat="server"></asp:Label>
            ！  <a href="javascript:void(0)" id="loginOut">安全退出</a></div>
        <div class="footer">
            Power By  553202835</a>&copy; 2015</div>
    </div>
    <div region="west" hide="true" split="true" title="导航菜单" style="width: 180px;" id="west" runat="server">
        <div id="nav" class="easyui-accordion" fit="true" border="false">
            <!--  导航内容 -->
        </div>
    </div>
    <div id="mainPanle" region="center" style="background: #eee; overflow-y: hidden">
        <div id="tabs" class="easyui-tabs" fit="true" border="false">
            <div title="欢迎使用" style="padding: 20px; overflow: hidden; color: red;">
                <iframe src="Default.aspx" width="100%" height="100%" frameborder="0" style="text-align:center"></iframe>
            </div>
        </div>
    </div>
    <div id="mm" class="easyui-menu" style="width: 150px;">
        <div id="mm-tabupdate">
            刷新</div>
        <div class="menu-sep">
        </div>
        <div id="mm-tabclose">
            关闭</div>
        <div id="mm-tabcloseall">
            全部关闭</div>
        <div id="mm-tabcloseother">
            除此之外全部关闭</div>
        <div class="menu-sep">
        </div>
        <div id="mm-tabcloseright">
            当前页右侧全部关闭</div>
        <div id="mm-tabcloseleft">
            当前页左侧全部关闭</div>
        <div class="menu-sep">
        </div>
        <div id="mm-exit">
            退出</div>
    </div>
    
</body>
</html>
