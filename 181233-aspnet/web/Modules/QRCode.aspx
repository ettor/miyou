<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QRCode.aspx.cs" Inherits="Modules_QRCode" %>

<%@ Register Src="../Control/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Control/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <link rel="shortcut icon" href="../favicon.ico" />
    <script src="../js/Default/jquery.js">
    </script>
    <title>老杨健康农产品-哈哈特卖网 </title>
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
                    font-weight: bold;">汇聚全国各地当季最新鲜农产品、生鲜，现摘现发，给消费者最新鲜的产品，现招第一批100个代理，大家共同做好这个市场，顺便一起挣点儿钱，招完即止，欢迎大家咨询私聊。
                    <br />说明：
                    <br />1、不用交任何费用、不压货，所有销售过程中的风险由我老杨来承担，让大家真正零风险。
                    <br />2、我将会一对一培训，随时解疑答惑。
                    <br /><br />微信/电话：15753517601
                    <br />
                    <span></span>
                    </span>
            </div>
            <img style="width:430px;height:430px" src="/images/553202835.png" />
            &nbsp;&nbsp;&nbsp;&nbsp;<img style="width:430px;height:430px" src="/images/jiugongge.jpg" />
        </div>
    </div>
    <!-- Page footer -->
    <uc2:Footer ID="Foot1" runat="server" />
</body>
</html>
