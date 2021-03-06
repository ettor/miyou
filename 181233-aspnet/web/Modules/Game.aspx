﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Game.aspx.cs" Inherits="Modules_Game" %>

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
        <div style="position:relative; margin-top:2px; height:700px">
            <div style="margin-top:10px;">
                
            </div>
        </div>
    </div>

    <!-- Page footer -->
    <uc2:Footer ID="Foot1" runat="server" />
    
</body>

</html>
