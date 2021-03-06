﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Game.aspx.cs" Inherits="Modules_Games_Game" %>

<%@ Register Src="../../Control/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../../Control/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>

<!DOCTYPE html>

<html>
<head>
    <meta content="IE=11.0000"
          http-equiv="X-UA-Compatible">
    <title>哈哈特卖-一夜N次郎</title>
    <meta charset="utf-8">
    <meta name="viewport" content="initial-scale=1, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0, width=device-width,target-densitydpi=device-dpi">

    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <script src="game/createjs.js" type="text/javascript"></script>
    <script src="/js/Default/jquery.js"></script>
    <link href="icon.png" rel="apple-touch-icon-precomposed">
    <link href="game/pic.css"
          rel="stylesheet" type="text/css">

    <script type="text/javascript">

        var isDesktop = navigator['userAgent'].match(/(ipad|iphone|ipod|android|windows phone)/i) ? false : true;
        var fontunit = isDesktop ? 20 : ((window.innerWidth > window.innerHeight ? window.innerHeight : window.innerWidth) / 320) * 10;
        document.write('<style type="text/css">' +
			'html,body {font-size:' + (fontunit < 30 ? fontunit : '30') + 'px;}' +
			(isDesktop ? '#welcome,#GameTimeLayer,#GameLayerBG,#GameScoreLayer.SHADE{position: absolute;}' :
				'#welcome,#GameTimeLayer,#GameLayerBG,#GameScoreLayer.SHADE{position:fixed;}@media screen and (orientation:landscape) {#landscape {display: box; display: -webkit-box; display: -moz-box; display: -ms-flexbox;}}') +
			'</style>');
    </script>

    <style type="text/css">
        body {
            font-family: "Helvetica Neue", Helvetica, STHeiTi, sans-serif;
            margin: 0;
            padding: 0;
        }

        .loading {
            background-image: url("data:image/gif;base64,R0lGODlhJQAlAJECAL3L2AYrTv///wAAACH/C05FVFNDQVBFMi4wAwEAAAAh+QQFCgACACwAAAAAJQAlAAACi5SPqcvtDyGYIFpF690i8xUw3qJBwUlSadmcLqYmGQu6KDIeM13beGzYWWy3DlB4IYaMk+Dso2RWkFCfLPcRvFbZxFLUDTt21BW56TyjRep1e20+i+eYMR145W2eefj+6VFmgTQi+ECVY8iGxcg35phGo/iDFwlTyXWphwlm1imGRdcnuqhHeop6UAAAIfkEBQoAAgAsEAACAAQACwAAAgWMj6nLXAAh+QQFCgACACwVAAUACgALAAACFZQvgRi92dyJcVJlLobUdi8x4bIhBQAh+QQFCgACACwXABEADAADAAACBYyPqcsFACH5BAUKAAIALBUAFQAKAAsAAAITlGKZwWoMHYxqtmplxlNT7ixGAQAh+QQFCgACACwQABgABAALAAACBYyPqctcACH5BAUKAAIALAUAFQAKAAsAAAIVlC+BGL3Z3IlxUmUuhtR2LzHhsiEFACH5BAUKAAIALAEAEQAMAAMAAAIFjI+pywUAIfkEBQoAAgAsBQAFAAoACwAAAhOUYJnAagwdjGq2amXGU1PuLEYBACH5BAUKAAIALBAAAgAEAAsAAAIFhI+py1wAIfkEBQoAAgAsFQAFAAoACwAAAhWUL4AIvdnciXFSZS6G1HYvMeGyIQUAIfkEBQoAAgAsFwARAAwAAwAAAgWEj6nLBQAh+QQFCgACACwVABUACgALAAACE5RgmcBqDB2MarZqZcZTU+4sRgEAIfkEBQoAAgAsEAAYAAQACwAAAgWEj6nLXAAh+QQFCgACACwFABUACgALAAACFZQvgAi92dyJcVJlLobUdi8x4bIhBQAh+QQFCgACACwBABEADAADAAACBYSPqcsFADs=");
            background-repeat: no-repeat;
            background-position: center center;
            background-size: auto 60%;
        }

        .logo {
            background: url(img/logo.png) center center no-repeat;
            background-size: auto 100%;
        }

        .SHADE {
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            bottom: 0;
            z-index: 11;
        }

        .BOX-V {
            box-orient: vertical;
            -webkit-box-orient: vertical;
            -moz-box-orient: vertical;
            -ms-flex-direction: column;
        }

        .BOX-D {
            box-align: end;
            box-pack: center -webkit-box-align: end;
            -webkit-box-pack: center;
            -ms-flex-align: end;
            -ms-flex-pack: center;
        }

        .BOX-M {
            box-align: center;
            box-pack: center;
            -webkit-box-align: center;
            -webkit-box-pack: center;
            -ms-flex-align: center;
            -ms-flex-pack: center;
        }

        .BOX-S {
            display: block;
            box-flex: 1;
            -webkit-box-flex: 1;
            -moz-box-flex: 1;
            -ms-flex: 1;
        }

        .BOX, .BOX-V, .BOX-D, .BOX-M, .FOOTER {
            display: box;
            display: -webkit-box;
            display: -moz-box;
            display: -ms-flexbox;
        }

        .BBOX, .BOX, .APP-STAGE, .INSET-STAGE, .STAGE, .PAGE-STAGE, .PAGE, .PAGE-BOX, .INSET-PAGE, .FOOTER {
            box-sizing: border-box;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
        }

        #welcome {
            background-color: rgba(0,0,0,.8);
            text-align: center;
            font-weight: bold;
            overflow: hidden;
        }

        .welcome-bg {
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background: url(img/bg.jpg) center center no-repeat;
            background-size: 100% 100%;
            opacity: .4;
            overflow: hidden;
        }

        #GameTimeLayer {
            top: 1em;
            left: 0;
            width: 100%;
            text-align: center;
            color: #f00;
            font-size: 4em;
            text-shadow: 0 0 3px #fff,0 0 3px #fff,0 0 3px #fff;
            overflow: hidden;
        }

        #GameLayerBG {
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            overflow: hidden;
            background: #fff;
        }

        .GameLayer {
            position: absolute;
            bottom: 0;
            left: 0;
        }

        .block {
            position: absolute;
            border-top: 1px solid #1D70B6;
            background-repeat: no-repeat;
            background-position: center;
        }

        .t1, .t2, .t3, .t4, .t5 {
            background-size: auto 100%;
        }

        .tt1, .tt2, .tt3, .tt4, .tt5 {
            background-size: auto 86%;
        }

        .bl {
            border-left: 1px solid #1D70B6;
        }

        @-ms-keyframes flash {
            0% {
                opacity: 1;
            }

            50% {
                opacity: 0;
            }

            100% {
                opacity: 1;
            }
        }

        @-webkit-keyframes flash {
            0% {
                opacity: 1;
            }

            50% {
                opacity: 0;
            }

            100% {
                opacity: 1;
            }
        }

        .flash {
            -webkit-animation: flash .2s 3;
            animation: flash .2s 3;
        }

        .bad {
            background-color: #f00;
            -webkit-animation: flash .2s 3;
            animation: flash .2s 3;
        }

        * {
            -webkit-tap-highlight-color: rgba(0,0,0,0);
            -ms-tap-highlight-color: rgba(0,0,0,0);
            tap-highlight-color: rgba(0,0,0,0);
            -ms-user-select: none;
        }

        #GameScoreLayer {
            background-position: center .5em;
            background-size: auto 4em;
            padding-top: 5em;
            font-size: 2em;
            font-weight: bold;
            color: #fff;
            text-align: center;
            overflow: hidden;
        }

        .bgc1 {
            background-color: #23378B;
        }

        .bgc2 {
            background-color: #009FE3;
        }

        .bgc3 {
            background-color: #E42313;
        }

        .bgc4 {
            background-color: #FCBD1B;
        }

        .bgc5 {
            background-color: #34002A;
        }

        #GameScoreLayer-share {
            height: 1.3em;
            line-height: 1.3em;
            overflow: hidden;
        }

        .share-icon {
            width: 1.7em;
            background-repeat: no-repeat;
            background-size: auto 100%;
        }

        #GameScoreLayer-btn .btn {
            text-align: center;
            font-size: 1.1em;
            background-color: rgba(0,0,0,.3);
            height: 2em;
            line-height: 2em;
        }

        .btn:active {
            opacity: 0.2;
        }

        #landscape {
            display: none;
        }


        #gameBody {
            position: relative;
            width: 640px;
            margin: 0 auto;
            height: 100%;
        }
    </style>

    <meta name="GENERATOR" content="MSHTML 11.00.9600.17344">

    <style type="text/css">
        body
        {
            font-family: "proxima-nova-1" , "proxima-nova-2" , "Helvetica" , "Arial" ,sans-serif;
        }
    </style>

    <link rel="stylesheet" href="../../js/Default/style.css">
    <link rel="stylesheet" href="../../js/Default/style_locale.css">
    <link rel="stylesheet" href="../../js/Default/style2.css">

</head>
<body onload="init()" style="line-height:normal;font-size:16px; font-family:'Helvetica Neue', Helvetica, 'Nimbus Sans L', Arial, 'Liberation Sans', 'Hiragino Sans GB', 'Microsoft YaHei', 'Wenquanyi Micro Hei', 'WenQuanYi Zen Hei', 'ST Heiti', SimHei, 'WenQuanYi Zen Hei Sharp', sans-serif">
    <uc1:Header ID="Head1" runat="server" />
    <img style="left: 0px; top: 0px; width: 0px; position: absolute; opacity: 0;"
         src="game/icon.png">
    <!--<link rel="stylesheet" type="text/css" href="banner.css">
    <div class="body">
        <div class="li ">
            <a href="http://8c2qya.c.admaster.com.cn/c/a18601,b200389797,c1316,i0,m101,h"><img src="img2/bg.jpg" width="100%"></a>
            <div class="click-icon"><a href="http://8c2qya.c.admaster.com.cn/c/a18601,b200389797,c1316,i0,m101,h"></a></div>
            <div class="contain">
                <div class="title"></div>
                <div class="box">
                    <div class="text"></div>
                    <div class="sel sel-a"><a href="http://8c2qxa.c.admaster.com.cn/c/a18601,b200389795,c1316,i0,m101,h"></a></div>
                    <div class="flex"></div>
                    <div class="sel sel-b"><a href="http://8c2qxu.c.admaster.com.cn/c/a18601,b200389796,c1316,i0,m101,h"></a></div>
                    <div class="flex2"></div>
                </div>
            </div>
        </div>
        <div class="li hide">
            <a href="http://8c2qzu.c.admaster.com.cn/c/a18601,b200389800,c1316,i0,m101,h"><img src="img2/bg.jpg" width="100%"></a>
            <div class="click-icon"><a href="http://8c2qzu.c.admaster.com.cn/c/a18601,b200389800,c1316,i0,m101,h"></a></div>
            <div class="contain">
                <div class="title2"></div>
                <div class="box">
                    <div class="text"></div>
                    <div class="sel sel-a2"><a href="http://8c2qyu.c.admaster.com.cn/c/a18601,b200389798,c1316,i0,m101,h"></a></div>
                    <div class="flex"></div>
                    <div class="sel sel-b2"><a href="http://8c2qza.c.admaster.com.cn/c/a18601,b200389799,c1316,i0,m101,h"></a></div>
                    <div class="flex2"></div>
                </div>
            </div>
        </div>
        <div class="li hide">
            <a href="http://8c2q1a.c.admaster.com.cn/c/a18601,b200389803,c1316,i0,m101,h"><img src="img2/bg.jpg" width="100%"></a>
            <div class="click-icon"><a href="http://8c2q1a.c.admaster.com.cn/c/a18601,b200389803,c1316,i0,m101,h"></a></div>
            <div class="contain">
                <div class="title"></div>
                <div class="box">
                    <div class="text"></div>
                    <div class="sel sel-a3"><a href="http://8c2q0a.c.admaster.com.cn/c/a18601,b200389801,c1316,i0,m101,h"></a></div>
                    <div class="flex"></div>
                    <div class="sel sel-b3"><a href="http://8c2q0u.c.admaster.com.cn/c/a18601,b200389802,c1316,i0,m101,h"></a></div>
                    <div class="flex2"></div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="banner.js">
        // var liChange = function () {
        // 	var i,j,
        // 		arr = document.querySelectorAll('')
        // }
    </script>-->
    <!-- <div class="banner" style="position: fixed;z-index: 100;bottom: 0;">
        <a href="http://8dqhsu.c.admaster.com.cn/c/a19489,b200430426,c1316,i0,m101,h"><img src="img2/banner.jpg" width="100%" style="display: block;"></a>
    </div> -->

    <script type="text/javascript">
        if (isDesktop)
            document.write('<div id="gameBody">');
    </script>

    <script type="text/javascript">
        var body, blockSize, GameLayer = [], GameLayerBG, touchArea = [], GameTimeLayer;
        var transform, transitionDuration;

        function init(argument) {
            showWelcomeLayer();
            body = document.getElementById('gameBody') || document.body;
            body.style.height = window.innerHeight + 'px';
            transform = typeof (body.style.webkitTransform) != 'undefined' ? 'webkitTransform' : (typeof (body.style.msTransform) != 'undefined' ? 'msTransform' : 'transform');
            transitionDuration = transform.replace(/ransform/g, 'ransitionDuration');

            GameTimeLayer = document.getElementById('GameTimeLayer');
            GameLayer.push(document.getElementById('GameLayer1'));
            GameLayer[0].children = GameLayer[0].querySelectorAll('div');
            GameLayer.push(document.getElementById('GameLayer2'));
            GameLayer[1].children = GameLayer[1].querySelectorAll('div');
            GameLayerBG = document.getElementById('GameLayerBG');
            if (GameLayerBG.ontouchstart === null) {
                GameLayerBG.ontouchstart = gameTapEvent;
            } else {
                GameLayerBG.onmousedown = gameTapEvent;
                document.getElementById('landscape-text').innerHTML = '点我开始玩耍';
                document.getElementById('landscape').onclick = winOpen;
            }
            gameInit();

            window.addEventListener('resize', refreshSize, false);

            setTimeout(function () {
                var btn = document.getElementById('ready-btn');
                btn.className = 'btn';
                btn.innerHTML = ' 预备，上！'
                btn.style.backgroundColor = '#F00';
                btn.onclick = function () {
                    _smq.push(['custom', '一夜N次郎', '游戏按钮', '预备']);
                    _gaq.push(['_trackEvent', '一夜N次郎', '游戏按钮', '预备']);
                    closeWelcomeLayer();
                }

            }, 500);
        }
        function winOpen() {
            window.open(location.href + '?r=' + Math.random(), 'nWin', 'height=500,width=320,toolbar=no,menubar=no,scrollbars=no');
            var opened = window.open('about:blank', '_self'); opened.opener = null; opened.close();
        }
        var refreshSizeTime;
        function refreshSize() {
            clearTimeout(refreshSizeTime);
            refreshSizeTime = setTimeout(_refreshSize, 200);
        }
        function _refreshSize() {
            countBlockSize();
            for (var i = 0; i < GameLayer.length; i++) {
                var box = GameLayer[i];
                for (var j = 0; j < box.children.length; j++) {
                    var r = box.children[j],
    				rstyle = r.style;
                    rstyle.left = (j % 4) * blockSize + 'px';
                    rstyle.bottom = Math.floor(j / 4) * blockSize + 'px';
                    rstyle.width = blockSize + 'px';
                    rstyle.height = blockSize + 'px';
                }
            }
            var f, a;
            if (GameLayer[0].y > GameLayer[1].y) {
                f = GameLayer[0];
                a = GameLayer[1];
            } else {
                f = GameLayer[1];
                a = GameLayer[0];
            }
            var y = ((_gameBBListIndex) % 10) * blockSize;
            f.y = y;
            f.style[transform] = 'translate3D(0,' + f.y + 'px,0)';

            a.y = -blockSize * Math.floor(f.children.length / 4) + y;
            a.style[transform] = 'translate3D(0,' + a.y + 'px,0)';

        }
        function countBlockSize() {
            blockSize = body.offsetWidth / 4;
            body.style.height = window.innerHeight + 'px';
            GameLayerBG.style.height = window.innerHeight + 'px';
            touchArea[0] = window.innerHeight - blockSize * 0;
            touchArea[1] = window.innerHeight - blockSize * 3;
        }
        var _gameBBList = [], _gameBBListIndex = 0, _gameOver = false, _gameStart = false, _gameTime, _gameTimeNum, _gameScore;
        function gameInit() {
            createjs.Sound.registerSound({ src: "img/err.mp3", id: "err" });
            createjs.Sound.registerSound({ src: "img/end.mp3", id: "end" });
            createjs.Sound.registerSound({ src: "img/tap.mp3", id: "tap" });
            gameRestart();
        }
        function gameRestart() {
            console.log('gameRestart');
            _gameBBList = [];
            _gameBBListIndex = 0;
            _gameScore = 0;
            _gameOver = false;
            _gameStart = false;
            _gameTimeNum = 2000;
            GameTimeLayer.innerHTML = creatTimeText(_gameTimeNum);
            countBlockSize();
            refreshGameLayer(GameLayer[0]);
            refreshGameLayer(GameLayer[1], 1);
        }
        function gameStart() {
            _gameStart = true;
            _gameTime = setInterval(gameTime, 10);
        }
        function gameOver() {
            _gameOver = true;
            clearInterval(_gameTime);
            setTimeout(function () {
                GameLayerBG.className = '';
                showGameScoreLayer();
            }, 1500);
        }
        function gameTime() {
            _gameTimeNum--;
            if (_gameTimeNum <= 0) {
                GameTimeLayer.innerHTML = '&nbsp;&nbsp;&nbsp;&nbsp;时间到！';
                gameOver();
                GameLayerBG.className += ' flash';
                createjs.Sound.play("end");
            } else {
                GameTimeLayer.innerHTML = creatTimeText(_gameTimeNum);
            }
        }
        function creatTimeText(n) {
            var text = (100000 + n + '').substr(-4, 4);
            text = '&nbsp;&nbsp;' + text.substr(0, 2) + "'" + text.substr(2) + "''"
            return text;
        }
        var _ttreg = / t{1,2}(\d+)/, _clearttClsReg = / t{1,2}\d+| bad/;
        function refreshGameLayer(box, loop, offset) {
            var i = Math.floor(Math.random() * 1000) % 4 + (loop ? 0 : 4);
            for (var j = 0; j < box.children.length; j++) {
                var r = box.children[j],
    			rstyle = r.style;
                rstyle.left = (j % 4) * blockSize + 'px';
                rstyle.bottom = Math.floor(j / 4) * blockSize + 'px';
                rstyle.width = blockSize + 'px';
                rstyle.height = blockSize + 'px';
                r.className = r.className.replace(_clearttClsReg, '');
                if (i == j) {
                    _gameBBList.push({ cell: i % 4, id: r.id });
                    r.className += ' t' + (Math.floor(Math.random() * 1000) % 5 + 1);
                    r.notEmpty = true;
                    i = (Math.floor(j / 4) + 1) * 4 + Math.floor(Math.random() * 1000) % 4;
                } else {
                    r.notEmpty = false;
                }
            }
            if (loop) {
                box.style.webkitTransitionDuration = '0ms';
                box.style.display = 'none';
                box.y = -blockSize * (Math.floor(box.children.length / 4) + (offset || 0)) * loop;
                setTimeout(function () {
                    box.style[transform] = 'translate3D(0,' + box.y + 'px,0)';
                    setTimeout(function () {
                        box.style.display = 'block';
                    }, 100);
                }, 200);
            } else {
                box.y = 0;
                box.style[transform] = 'translate3D(0,' + box.y + 'px,0)';
            }
            box.style[transitionDuration] = '150ms';
        }
        function gameLayerMoveNextRow() {
            for (var i = 0; i < GameLayer.length; i++) {
                var g = GameLayer[i];
                g.y += blockSize;
                if (g.y > blockSize * (Math.floor(g.children.length / 4))) {
                    refreshGameLayer(g, 1, -1);
                } else {
                    g.style[transform] = 'translate3D(0,' + g.y + 'px,0)';
                }
            }
        }
        function gameTapEvent(e) {
            if (_gameOver) {
                return false;
            }
            var tar = e.target;
            var y = e.clientY || e.targetTouches[0].clientY,
    		x = (e.clientX || e.targetTouches[0].clientX) - body.offsetLeft,
    		p = _gameBBList[_gameBBListIndex];
            if (y > touchArea[0] || y < touchArea[1]) {
                return false;
            }
            if ((p.id == tar.id && tar.notEmpty) || (p.cell == 0 && x < blockSize) || (p.cell == 1 && x > blockSize && x < 2 * blockSize) || (p.cell == 2 && x > 2 * blockSize && x < 3 * blockSize) || (p.cell == 3 && x > 3 * blockSize)) {
                if (!_gameStart) {
                    gameStart();
                }
                createjs.Sound.play("tap");
                tar = document.getElementById(p.id);
                tar.className = tar.className.replace(_ttreg, ' tt$1');
                _gameBBListIndex++;
                _gameScore++;
                gameLayerMoveNextRow();
            } else if (_gameStart && !tar.notEmpty) {
                createjs.Sound.play("err");
                gameOver();
                tar.className += ' bad';
            }
            return false;
        }
        function createGameLayer() {
            var html = '<div id="GameLayerBG">';
            for (var i = 1; i <= 2; i++) {
                var id = 'GameLayer' + i;
                html += '<div id="' + id + '" class="GameLayer">';
                for (var j = 0; j < 10; j++) {
                    for (var k = 0; k < 4; k++) {
                        html += '<div id="' + id + '-' + (k + j * 4) + '" num="' + (k + j * 4) + '" class="block' + (k ? ' bl' : '') + '"></div>';
                    }
                }
                html += '</div>';
            }
            html += '</div>';

            html += '<div id="GameTimeLayer"></div>';

            return html;
        }
        function closeWelcomeLayer() {
            var l = document.getElementById('welcome');
            l.style.display = 'none';
        }
        function showWelcomeLayer() {
            var l = document.getElementById('welcome');
            l.style.display = 'block';
        }
        function showGameScoreLayer() {
            var l = document.getElementById('GameScoreLayer');
            var c = document.getElementById(_gameBBList[_gameBBListIndex - 1].id).className.match(_ttreg)[1];
            l.className = l.className.replace(/bgc\d/, 'bgc' + c);
            document.getElementById('GameScoreLayer-text').innerHTML = shareText(_gameScore);
            document.getElementById('GameScoreLayer-score').innerHTML = '得分&nbsp;&nbsp;' + _gameScore;
            var bast = cookie('bast-score');
            if (!bast || _gameScore > bast) {
                bast = _gameScore;
                cookie('bast-score', bast, 100);
            }
            document.getElementById('GameScoreLayer-bast').innerHTML = '最佳&nbsp;&nbsp;' + bast;
            l.style.display = 'block';

            //保存游戏得分
            //$.post("/webapp/Ashx/ajax.ashx", { med: 'SaveGameLog', score: bast, uid: localStorage["uid"] }, function (data) {

            //})

        }
        function hideGameScoreLayer() {
            var l = document.getElementById('GameScoreLayer');
            l.style.display = 'none';
        }
        function replayBtn() {
            gameRestart();
            hideGameScoreLayer();
        }
        function backBtn() {
            //gameRestart();
            //hideGameScoreLayer();
            //showWelcomeLayer();
            location.href = '/Default.aspx';
        }
        var mebtnopenurl = 'http://181233.com';
        function shareText(score) {
            if (score <= 49)
                return '呵呵！一夜' + score + '次郎！<br/>来盒杜蕾斯激情装昂，<br/>加油呗！';
            if (score <= 99)
                return '酷！一夜' + score + '次郎！<br/>试试魔法装，让你更厉害！';
            if (score <= 149)
                return '帅呆了！一夜' + score + '次郎！<br/>你是不是用Durex V-焕觉多速震动棒了？';
            if (score <= 199)
                return '太牛了！一夜' + score + '次郎！<br/>距离更牛，还差一盒杜蕾斯至臻肤感装！';

            if (score >= 260) {
                mebtnopenurl = 'http://active.coupon.jd.com/ilink/couponSendFront/send_index.action?key=3cc83651b073474e9d839f997c93e8b5&roleId=266683&to=durexshop.jd.com';
                document.getElementById('mebtn').innerHTML = '&nbsp;奖励10元！';
            } else {
                mebtnopenurl = 'http://durexchina.jd.com/m/index.html';
                document.getElementById('mebtn').innerHTML = '&nbsp;郎君点我！';
            }

            return '膜拜ing！一夜' + score + '次郎！<br/>只有杜蕾斯焕觉M-双驱双震按摩器能与你相配！';
        }
        function share(type) {
            //var content = encodeURIComponent(' #一夜N次郎# 我是一夜'+_gameScore+'次郎，哥就是这么厉害！You can you 也up啊！http://m.durex.com.cn/qr/1N'),
            //title  = '',
            //pic   = encodeURIComponent('http://m.durex.com.cn/qr/1N/s.jpg'),
            //url   = '';//encodeURIComponent('http://m.durex.com.cn/qr/1N'),
            //back  = encodeURIComponent('http://m.durex.com.cn/qr/1N');
            //var tourl = '';
            //switch( type ){
            //	case 'weixin':
            //	showWeixinShade('img/qr.png', 'img/ww_03.png', 'img/ww_07.png', 'img/ww_08.png');
            //	return;
            //	case 'sina':
            //	tourl = 'http://service.weibo.com/share/mobile.php?title=$content&url=$url&pic=$pic&backurl=$back';
            //	break;
            //	case 'douban':
            //	tourl = 'http://www.douban.com/recommend/?url=$url&title=$content&image=$pic&backurl=$back';
            //	break;
            //	case 'kaixin':
            //	tourl = 'http://www.kaixin001.com/repaste/share.php?rurl=$url&rtitle=$content&rpic=$pic&rbackurl=$back';
            //	break;
            //	case 'renren':
            //	tourl = 'http://widget.renren.com/dialog/share?resourceUrl=$url&srcUrl=$url&title=$content&pic=$pic';
            //	break;
            //	case 'qqwb':
            //	tourl = 'http://v.t.qq.com/share/share.php?url=$url&title=$content&pic=$pic&backurl=$back';
            //	break;
            //	case 'zone':
            //	tourl = 'http://sns.qzone.qq.com/cgi-bin/qzshare/cgi_qzshare_onekey?title=$title&summary=$content&url=$url&pic=$pic';
            //	break;
            //}
            //tourl = tourl.replace('$title',title).replace('$content',content).replace('$pic',pic).replace('$url',url).replace('$back',back);
            //window.open(tourl,'_blank');
        }
        function toStr(obj) {
            if (typeof obj == 'object') {
                return JSON.stringify(obj);
            } else {
                return obj;
            }
            return '';
        }
        function cookie(name, value, time) {
            if (name) {
                if (value) {
                    if (time) {
                        var date = new Date();
                        date.setTime(date.getTime() + 864e5 * time), time = date.toGMTString();
                    }
                    return document.cookie = name + "=" + escape(toStr(value)) + (time ? "; expires=" + time + (arguments[3] ? "; domain=" + arguments[3] + (arguments[4] ? "; path=" + arguments[4] + (arguments[5] ? "; secure" : "") : "") : "") : ""), !0;
                }
                return value = document.cookie.match("(?:^|;)\\s*" + name.replace(/([-.*+?^${}()|[\]\/\\])/g, "\\$1") + "=([^;]*)"), value = value && "string" == typeof value[1] ? unescape(value[1]) : !1, (/^(\{|\[).+\}|\]$/.test(value) || /^[0-9]+$/g.test(value)) && eval("value=" + value), value;
            }
            var data = {};
            value = document.cookie.replace(/\s/g, "").split(";");
            for (var i = 0; value.length > i; i++) name = value[i].split("="), name[1] && (data[name[0]] = unescape(name[1]));
            return data;
        }
        document.write(createGameLayer());
    </script>
    
    <div class="BBOX SHADE bgc1 logo" id="GameScoreLayer" style="display: none;">
        <div style="padding: 0px 5%;">
            <div id="GameScoreLayer-text"></div><br>
            <div id="GameScoreLayer-score" style="margin-bottom: 1em;">得分</div>
            <div id="GameScoreLayer-bast">最佳</div><br>
            <div class="BOX" id="GameScoreLayer-btn">
                <div class="btn BOX-S" onclick="_smq.push(['custom', '一夜N次郎', '游戏按钮', '返回']); _gaq.push(['_trackEvent', '一夜N次郎', '游戏按钮', '返回']); backBtn()">返回</div>&nbsp;

                <div class="btn BOX-S" onclick="_smq.push(['custom', '一夜N次郎', '游戏按钮', '重来']); _gaq.push(['_trackEvent', '一夜N次郎', '游戏按钮', '重来']); replayBtn()">重来</div>&nbsp;

            </div><br>
        </div>
    </div>
    <div class="SHADE BOX-M" id="welcome">
        <div class="welcome-bg FILL"></div>
        <div class="FILL BOX-M" style="left: 0px; top: 0px; right: 0px; bottom: 0px; position: absolute; z-index: 5;">
            <div style="margin: 0px 8% 0px 9%;">
                <div style="color: rgb(254, 240, 2); font-size: 2.6em;"></div><br>
                <div style="color: rgb(255, 255, 255); line-height: 1.5em; font-size: 2.2em;">从最下面的套套开始，<br>20秒内看你能拆开多少个<br>套套，你就是一夜几次郎！</div><br><br>
                <div class="btn loading" id="ready-btn" style="margin: 0px auto; width: 8em; height: 1.7em; color: rgb(255, 255, 255); line-height: 1.7em; font-size: 2.2em; display: inline-block;"></div>
            </div>
        </div>
    </div>
    <div class="SHADE BOX-M" id="landscape" style="background: rgba(0, 0, 0, 0.9);">
        <div class="welcome-bg FILL"></div>
        <div id="landscape-text"
             style="color: rgb(255, 255, 255); font-size: 3em;">请竖屏玩耍</div>
    </div>
    <div id="z-ad" style="width: 100%; bottom: 0px; display: block; position: absolute;">     </div>
    <script type="text/javascript">
        var wait = 60;
        var test = document.getElementById("z-ad");
        setTimeout(function () {
            test.style.display = "none"
        }, wait * 1000);
    </script>

    <script type="text/javascript">
        if (isDesktop)
            document.write('</div>');
    </script>

    <style type="text/css">
        #weixin-shade {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0,0,0,.8);
            z-index: 1000;
            overflow: auto;
            color: #fff;
            text-align: center;
        }

        #weixin-shade-scroll {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            overflow-y: auto;
            overflow-x: hidden;
        }

        #weixin-shade-qr div {
            font-size: 2.4em;
            text-align: center;
            margin-top: 1em;
        }

        #weixin-shade-qr {
        }

            #weixin-shade-qr img {
                display: block;
                width: 50%;
                margin: 2em auto;
            }

        #weixin-shade .step {
        }

            #weixin-shade .step .num {
                display: inline-block;
                margin: .5em auto;
                font-size: 3em;
                width: 1.5em;
                height: 1.5em;
                line-height: 1.5em;
                border-radius: 1em;
                background-color: #aaa;
                color: #000;
            }

            #weixin-shade .step div {
                font-size: 2em;
            }

            #weixin-shade .step img {
                display: block;
                width: 70%;
                margin: 2em auto;
            }
    </style>

    <script type="text/javascript">
        function showWeixinShade(qr, step1, step2, step3) {
            var s = document.getElementById('weixin-shade');
            if (s) {
                s.style.display = 'block';
                return;
            }
            s = document.createElement('div');
            s.id = 'weixin-shade';
            s.onclick = function () { this.style.display = 'none'; }
            s.style.position = (isDesktop ? 'absolute' : 'fixed');
            var html = '<div id="weixin-shade-scroll">';
            var i = 1;
            if (typeof (WeixinJSBridge) == 'undefined') {
                html += '<div id="weixin-shade-qr"><div>分享到微信</div><img src="' + qr + '"/></div>';
                html += '<div id="weixin-shade-step1" class="step"><span class="num">' + i + '</span><div>用手机摄像头扫描上方二维码</div><img src="' + step1 + '"/></div>';
                i++;
            }
            html += '<div id="weixin-shade-step2" class="step"><span class="num">' + i + '</span><div>手机打开分享页面后，点击右上角分享按钮</div><img src="' + step2 + '"/></div>';
            html += '<div id="weixin-shade-step3" class="step"><span class="num">' + (i + 1) + '</span><div>分享给好友或者分享到朋友圈</div><img src="' + step3 + '"/></div>';
            html += '</div>';
            s.innerHTML += html;
            body.appendChild(s);
        }
    </script>

    <script type="text/javascript">
        var _smq = _smq || [];
        _smq.push(['_setAccount', 'c9930ed8', new Date()]);
        _smq.push(['pageview']);

        (function () {
            var sm = document.createElement('script'); sm.type = 'text/javascript'; sm.async = true;
            sm.src = ('https:' == document.location.protocol ? 'https://' : 'http://') + 'cdnmaster.com/sitemaster/sm.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(sm, s);
        })();
    </script>

    <script type="text/javascript">
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-29156015-1']);
        _gaq.push(['_addOrganic', 'soso', 'w']);
        _gaq.push(['_addOrganic', 'sogou', 'query']);
        _gaq.push(['_addOrganic', 'yodao', 'q']);
        _gaq.push(['_trackPageview']);
        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();
    </script>
</body>
</html>
