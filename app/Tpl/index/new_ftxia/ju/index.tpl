<!doctype html>
<html>
<head>
<include file="public:head" />
<link rel="stylesheet" href="http://g.tbcdn.cn/ju/common/1.0.57/global-min.css" />
<link rel="stylesheet" href="http://g.tbcdn.cn/ju/??home/1.0.31/common/home-min.css,juseek/1.0.3/v1/seek-min.css,judt/1.0.1/gold/v1/home-min.css" />
<load href="__STATIC__/jky/css/good.css" />
<style>
#content {width: 980px;margin: 20px auto;}
#content {padding-left: 0px;padding-right: 2px;}
.ju-itemlist ul {width: 1020px;}
.ju-itemlist li {margin: 0px 38px 38px 0;-webkit-animation-fill-mode: forwards;animation-fill-mode: forwards;}
li.brand {display:none;}
.pages {float: center;}
</style>
</head>
<body>
<include file="public:header" />
<div class="jiu-nav-main">
	<div class="jiu-nav {:C('ftx_site_width')}">
		<div class="nav-item ">
			<div class="item-list">
				<ul>
				<li ><a href="/ju" <if condition="$cid eq 0"> class="active"</if> >全部</a></li>
				<volist name="cats" id="vol"> 
				<li><a href="{:U('ju/index',array('cid'=>$vol['cid']))}"  <if condition="$cid eq $vol['cid']"> class="active"</if> >{$vol.name}</a></li>
				</volist>
				</ul>
			</div>
		</div>
	</div>
</div>

	<div id="content" class="container ju-container ju-pc">
		<div class="ju-itemlist J_JuHomeList">
		{$html}
		</div>
	</div>

	<div class="page"><em></em><div>{$page}</div></div>

	<div style="position: relative;width: 980px;height: 30px;margin: 10px auto 8px;">
		<div style="position: relative;padding-top: 10px;float: right;display: inline;">内容资源来自：<a href="http://open.ftxia.com/" target="_blank">飞天侠开放平台</a></div>
	</div>
	 
 
<include file="public:footer" />
</body>
</html>