<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NongXianGou.aspx.cs" Inherits="Modules_NongXianGou" %>

<%@ Register Src="../Control/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Control/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <link rel="shortcut icon" href="../favicon.ico" />
    <script src="../js/Default/jquery.js">
    </script>
    <title>农鲜购-哈哈特卖网 </title>
    <style type="text/css">
        body
        {
            font-family: "proxima-nova-1" , "proxima-nova-2" , "Helvetica" , "Arial" ,sans-serif;
        }
    </style>
    <link rel="stylesheet" href="../js/Default/style.css">
    <link rel="stylesheet" href="../js/Default/style_locale.css">
    <link rel="stylesheet" href="../js/Default/style2.css">
</head>
<body class="with-rail " style="background-color: #F2F2ED">
    <iframe id="sina_anywhere_iframe" style="display: none;"></iframe>
    <!-- Page header -->
    <uc1:Header ID="Head1" runat="server" />
    <!-- Page wrapper -->
    <div id="page" class="container">
        <div style="position: relative; margin-top: 2px;">
            <div style="margin-top: 10px;">
                <span style="font: 16px/1.5 tahoma,arial,Hiragino Sans GB,WenQuanYi Micro Hei,\5FAE\8F6F\96C5\9ED1,\5B8B\4F53,sans-serif;
                    font-weight: bold;">亲情放送，自己亲戚家核桃，福山张格庄，亲情价购买，16元一斤，市场都是20以上，现帮亲戚开拓自己家种植养护牲畜市场，
                    后期还会有自己在院子里菜地里喂养的鸡，鸡蛋，羊肉都可以让你尝到和市场不一样的味道。
                    买到就是赚到，小伙伴们，工作累了，来点核桃补补脑吧。
                    <br />
                    <span>抢购电话：18605457545，个人微信：福山张格庄魏国华(微信号：xiaomili27)</span>
                    </span>
            </div>
            <img src="/images/nongxiangou/1.jpg" />
        </div>
    </div>
    <!-- Page footer -->
    <uc2:Footer ID="Foot1" runat="server" />
</body>
</html>
