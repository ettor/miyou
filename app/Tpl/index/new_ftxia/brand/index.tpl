<!doctype html>
<html>
<head>
<include file="public:head" />
<link rel="stylesheet" type="text/css" href="http://static.ftxia.com/static/css/brand.css" />
</head>
<body>
<include file="public:header" />

<div class="bmain {:C('ftx_site_width')} m0a clear tag-list"">

	<div class="brands">
		<ul>
		<volist name="brands" id="val" mod="9">
		<li <eq name="mod" value="8">style="margin-left:0px;" </eq>  >
			<a href="{:U('brand/dlist',array('uid'=>$val['uid']))}" target="_blank">
				<div class="pic">
					<img src="{$val.shop_icon}" width="80px" height="40px">
				</div>
				<div class="txt-all">
					<p class="shop-name">{$val.shop-name}</p>
					<p class="discount">{$val.discount}</p>
				</div>
			</a>
		</li>
		</volist>
		</ul>
	</div>


<div class="contain pr">
<volist name="lists" id="val">

            <div class="brand-con">
    <div class="brand-top">
    <div class="shop-icon fl">
    <div class="pic"><img src="{$val['shop']['logo']}" height="40" width="80"></div>
    </div>
    <div class="shop-detail fr">
        <p class="title"><em class="icon tao-t"></em><span>{$val['shop']['nick']}&nbsp;&nbsp;&nbsp;&nbsp;[{$val['shop']['discount']}]</span></p>
        <p class="source">{$val['shop']['txt']}</p>
        <a href="{:U('brand/dlist',array('uid'=>$val['shop']['uid']))}" class="go-kan01" target="_blank">更多{$val['shop']['items_total']}款宝贝&gt;&gt;</a>
        <div class="bottom-bg"></div>
    </div>
    </div>
    <div class="brand-list">
        <ul class="goods-list">
		<volist name="val['items']" id="vals" offset="0" length='3'>
              <li>
                        <div class="list-good start">                       
                        <a href="{:U('jump/index',array('iid'=>$vals['num_iid']))}" target="_blank">
                                    <img alt="{$vals['title']}" width="290px" height="190px" src="{$vals['pic_url']}" class="lazy good-pic" d-src="http://s1.juancdn.com/bao/140423/a/c/53578d4f8803e_580x380.jpg_290x190.jpg" style="display: block;">
                                    </a>
                            <h5 class="good-title"><a href="{:U('jump/index',array('iid'=>$vals['num_iid']))}" target="_blank">{$vals['title']}</a>
                                <div class="icon-all" style="display:none;"></div>
                            </h5>
                            <div class="title-tips">折扣价格{$vals['coupon_price']}元</div>
                            <div class="good-price">
                                <span class="price-current"><em>￥</em>{$vals['coupon_price']}</span>
                                <span class="des-other">
                                <span class="price-old"><em>￥</em>{$vals['price']}</span>
                                <span class="discount"><b>{$vals['zk']}</b>折包邮</span>
                                </span>
                                <div class="ggbtn {$vals['state']}">
                                    <a href="{:U('jump/index',array('iid'=>$vals['num_iid']))}" target="_blank">
					  <if condition="$vals['state'] eq 'start'">
                                            <b>{$vals['t']}</b><span>点开始</span>
					    <else/>
						<span>去看看</span>
					    </if>
                                        </a>
				</div>
                            </div>
                            <div class="pic-des">
                                <div class="des-state">
                                    <span class="state-time fl">开始：{$vals.coupon_start_time|date="m月d日 H时i分",###}</span>
                                </div>
                            </div>
                        </div>
                        </li>
			</volist> 
		</ul>
            <div class="clear"></div>
        </div>
        </div>
                      
</volist>      
</div>



</div>






	<div style="position: relative;width: 980px;height: 30px;margin: 10px auto 8px;">
		<div style="position: relative;padding-top: 10px;float: right;display: inline;">内容资源来自：<a href="http://open.ftxia.com/" target="_blank">飞天侠开放平台</a></div>
	</div>
	 
 
<include file="public:footer" />
</body>
</html>