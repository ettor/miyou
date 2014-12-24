<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChongZhi.aspx.cs" Inherits="Modules_ChongZhi" %>

<%@ Register Src="../Control/Header.ascx" TagName="Header"
    TagPrefix="uc1" %>

<%@ Register Src="../Control/Footer.ascx" TagName="Footer"
TagPrefix="uc2" %>

<!DOCTYPE html>
<html >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <link rel="shortcut icon" href="../favicon.ico"/>
    <script src="../js/Default/jquery.js">
    </script>
    <title>
        哈哈特卖网，引领优质生活（181233.COM）
    </title>
    <style type="text/css">
        body{font-family:"proxima-nova-1","proxima-nova-2","Helvetica","Arial",sans-serif;}
    </style>
    <link rel="stylesheet" href="../js/Default/style.css">
    <link rel="stylesheet" href="../js/Default/style_locale.css">
    <link rel="stylesheet" href="../js/Default/style2.css">
</head>
<body class="with-rail " style=" background-color:#F2F2ED">
    <iframe id="sina_anywhere_iframe" style="display: none;">
    </iframe>
    <!-- Page header -->
    <uc1:Header ID="Head1" runat="server" />

    <!-- Page wrapper -->
    <div id="page" class="container">
        <div style="position:relative; margin-top:2px; height:480px">
            <div style="margin-top:10px;">
                <a data-type="5" data-tmpl="300x200" data-tmplid="137" data-style="2" data-border="1" href="#">淘宝充值</a>
            </div>
        </div>
    </div>

    <!-- Page footer -->
    <uc2:Footer ID="Foot1" runat="server" />
    
    <script type="text/javascript">        (function (win, doc) { var s = doc.createElement("script"), h = doc.getElementsByTagName("head")[0]; if (!win.alimamatk_show) { s.charset = "gbk"; s.async = true; s.src = "http://a.alimama.cn/tkapi.js"; h.insertBefore(s, h.firstChild); }; var o = { pid: "mm_96416444_7384055_24668486", /*推广单元ID，用于区分不同的推广渠道*/appkey: "", /*通过TOP平台申请的appkey，设置后引导成交会关联appkey*/unid: ""/*自定义统计字段*/ }; win.alimamatk_onload = win.alimamatk_onload || []; win.alimamatk_onload.push(o); })(window, document);</script>
</body>

</html>
