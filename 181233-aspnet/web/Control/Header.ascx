<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Control_Header" %>

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <link rel="shortcut icon" href="../favicon.ico"/>
    <script src="../js/Default/jquery.js">
    </script>
    <style type="text/css">
        body{font-family:"proxima-nova-1","proxima-nova-2","Helvetica","Arial",sans-serif;}
    </style>

    <link rel="stylesheet" href="../js/Default/style.css">
    <link rel="stylesheet" href="../js/Default/style_locale.css">
    <link rel="stylesheet" href="../js/Default/style2.css">

    <script>
        var _hmt = _hmt || [];
        (function () {
            var hm = document.createElement("script");
            hm.src = "//hm.baidu.com/hm.js?5174e99afc4a5ec33e737997786f9be5";
            var s = document.getElementsByTagName("script")[0];
            s.parentNode.insertBefore(hm, s);
        })();
    </script>

    <div id="header">
        <header role="banner">
            <div id="nav">
                <div id="nav-flow">
                    <div class="nav-container-container"  style="background-color:#2188D3">
                        <nav class="nav container" id="nav-main"  style="background-color:#2188D3">
                            <%--<span id="logo">
                                <a href=""
                                class="s-engadget-logo-web-over" style="background:url(images/logo.png); height:40px; width:124px;">
                                    哈哈特卖
                                </a>
                                <span class="edition">
                                    引领优质生活
                                </span>
                            </span>--%>
                            <span id="logo" style="font-size:20px; margin-top:20px ; font-weight:bold; color:white">
                                <a href="/Default.aspx">哈哈特卖</a>
                            </span>
                            <ul>
                                <li class="news">
                                    <a class="item" href="/Default.aspx">
                                        首页
                                    </a>
                                </li>
                                <li class="news">
                                    <a class="item" href="/Modules/NongXianGou.aspx">
                                        农鲜购
                                    </a>
                                </li>
                                <li class="news">
                                    <a class="item" href="/Modules/ChongZhi.aspx">
                                        话费充值
                                    </a>
                                </li>
                               <%-- <li class="reviews">
                                    <a class="item " href="/Default.aspx" id="reviews-link">
                                        分类浏览
                                        <i class="s-icn-arw-gry-down">
                                        </i>
                                    </a>
                                </li>--%>
                                
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </header>
        
        <%--<div class="aside container breaking" id="redbar" style="margin-bottom:2px; display:none">
            <p>
                <a href="/Default.aspx">
                    <i class="s-thunder-redbar">
                    </i>
                    <strong>
                        哈哈特卖:
                    </strong>
                    哈哈特卖。。。
                </a>
            </p>
        </div>--%>
    </div>