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


	<div class="list-introduce">
<div class="pic fl"><img src="{$lists['shop']['big_img']}" height="130" width="740"></div>
<div class="detail fr">
<div class="img"><img src="{$lists['shop']['logo']}" height="40" width="80"></div>
<p class="shop-name">{$lists['shop']['nick']}</p>
<p class="discount discount01" style="display:block;">{$lists['shop']['discount']}</p>
<p class="txt" style="display:none;">{$lists['shop']['txt']}</p>
</div></div>




<ul class="goods-list">
	<volist name="lists['items']" id="vals" >
                     <li>
        <div class="list-good {$vals['state']}">
                  <a href="{:U('jump/index',array('iid'=>$vals['num_iid']))}" target="_blank">
                    <img alt="{$vals['title']}" width="290px" height="190px" src="{$vals['pic_url']}" class="lazy good-pic"  style="display: block;">
                   </a>
            <h5 class="good-title"><a href="{:U('jump/index',array('iid'=>$vals['num_iid']))}" target="_blank">{$vals['title']}</a>
                <div class="icon-all" style="display:none;"></div>
            </h5>
	    <div class="title-tips">折扣价格{$vals['coupon_price']}元</div>

            <div class="good-price">
                <span class="price-current"><em>￥</em>{$vals['coupon_price']}</span>

                    <span class="des-other">
                    <span class="price-old"><em>￥</em>{$vals['price']}</span>
                    <span class="discount"><b>{$vals['zk']}</b>折 包邮</span>
                    </span>

                <div class="ggbtn {$vals['state']}">
		<a href="{:U('jump/index',array('iid'=>$vals['num_iid']))}" target="_blank">
                        <em class="icon tao-t"></em><span>去抢购</span>
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
</div>




	<div style="position: relative;width: 980px;height: 30px;margin: 10px auto 8px;">
		<div style="position: relative;padding-top: 10px;float: right;display: inline;">内容资源来自：<a href="http://open.ftxia.com/" target="_blank">飞天侠开放平台</a></div>
	</div>
	 
 
<include file="public:footer" />
</body>
</html>