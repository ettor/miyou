<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <meta name="viewport" content="width=device-width; initial-scale=1.0; minimum-scale=1.0; maximum-scale=2.0">
        <meta name="MobileOptimized" content="320">
        <link rel="shortcut icon" type="image/x-icon" href="/static/images/favicon.ico" media="screen" />
	<load href="__STATIC__/wap/css/base.css" />
	<load href="__STATIC__/wap/css/index.css" />
	<load href="__STATIC__/js/jquery/jquery.js" />
	<load href="__STATIC__/js/jquery.lazyload.min.js" />
	<script type="text/javascript">
		$(function(){
			$("img.lazy").lazyload();
		})
	</script>
        <title>触屏版</title>
    </head>
<body id="index">
<div class="header">
        <a class="logo" href="/"><span>全场九块九包邮<br>华美网络提供</span></a>
        <div class="nav">
            <a href="{:U('classfiy/index')}" class="filter">筛 选</a>
        </div>
    </div>
    <div class="current-category">
        您所在的分类：全部
                </div>
<present name="items_list">
    <div class="deatail">
	<volist name="items_list" id="item" key="i">
        <section>
                <a href="{:U('jump/index',array('id'=>$item['num_iid']))}" target="_blank">
                    <em class="go-buy"> 去抢购</em>                 <img alt="{$item.title}" src="__STATIC__/images/grey.gif" data-original="{$item.pic_url}_100x100.jpg" class="lazy" />
                                            <ul class="deals">
                        <li class="title">{$item.title}</li>
                        <li class="current-price">￥{$item.coupon_price}</li>
                        <li class="old-price">￥{$item.price}</li>
                    </ul>
                </a>
            </section>
		</volist>	
	</div>
</present>
    <div class="deatail-page">
	 {$page}
	</div>

<div class="foot">
 
    <div class="nav">
        <ul>
            <li><a href="/">首页</a></li>
            <li class="no-border"><a href="{:C('ftx_site_name')}"> PC版</a></li>
        </ul></div>
    <div class="copyright"><span class="copyright">&copy;2014 {:C('ftx_site_name')}</span><p></p></div>
</div>
  
</body>
</html>