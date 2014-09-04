<!doctype html>
<html>
<head>
<include file="public:head" />
<link rel=stylesheet type=text/css href="__STATIC__/jky/css/view.css" />
<script type="text/javascript">
	var thsId={$item.num_iid};
</script>
</head>
<body>
<include file="public:header" />
<!--商品详细-->
<div class="main {:C('ftx_site_width')}">

	<div class="place-explain">
		您的位置：<a target="_blank" href="{:C('ftx_site_url')}">{:C('ftx_site_name')}</a>
		<notempty name="item.cate_id">&nbsp;&gt;&nbsp;
			<if condition="$cate_data[$item['cate_id']]['pid'] gt 0">
				<if condition="$cate_data[$cate_data[$item['cate_id']]['pid']]['pid'] gt 0">
					<a target="_blank" href="{:U('index/cate',array('cid'=>$cate_data[$cate_data[$item['cate_id']]['pid']]['pid']))}">{$cate_data[$cate_data[$cate_data[$item['cate_id']]['pid']]['pid']]['name']}</a>&nbsp;&gt;&nbsp;
				</if>
				<a target="_blank" href="{:U('index/cate',array('cid'=>$cate_data[$item['cate_id']]['pid']))}">{$cate_data[$cate_data[$item['cate_id']]['pid']]['name']}</a>&nbsp;&gt;&nbsp;
			</if>
			<a target="_blank" href="{:U('index/cate',array('cid'=>$item['cate_id']))}">{$cate_data[$item['cate_id']]['name']}</a>
		</notempty>
		
		&nbsp;&gt;&nbsp; 
		<a class="bady-xx-seo" href="{:U('item/index',array('id'=>$item['num_iid']))}">{$item.title}</a>
	</div>


	<div class="container fl">



		<div class="product clear">
			<div class="product-pic fl">
				<a href="{:U('jump/index',array('iid'=>$item['num_iid']))}" target="_blank" rel="nofollow"><img src='{:attach(get_thumb($item['pic_url'], '_b'),'item')}' alt="{$item.title}"    /></a>
				<span></span>
			</div>
			<div class="product-info fl">
				<h3><a href="{:U('jump/index',array('iid'=>$item['num_iid']))}" target="_blank" rel="nofollow">{$item.title}</a></h3>
				<div class="share"><a class="report" znid="{$item.num_iid}" title="{$item.title}" href="javascript:;"><i class="report-icon"></i>举报</a></div>
				<dl class="jp-size">
					<dt>宝贝属性：</dt>
					<dd>
						<ul>
						<volist name="tags" id="tag">
							<li><a class="active" href="{:U('tag/'.$tag)}" target="_blank"><span>{$tag}</span></a></li>  
						</volist>
						</ul>
					</dd>
					<dd class="size-tips" style="display:none;"><i></i>请选择宝贝属性</dd>
				</dl>
				<p class="tips clear">
					<span class="item-pr fl">原价：<em class="old-price ffv">{$item.price}元</em></span>
					<span class="fl">折扣：<em class="org_2 ffv">{$item.zk}折</em></span>
				</p>
				<p class="price">
					<span class="title-tips01">
                                            折扣价格<em class="tip-b"></em>
                                     </span>
					<em class="org">￥</em>
					<span class="jd-current">{$item.coupon_price}</span> 
					<if condition="$item.ems eq 1">/包邮</if></span>
				</p>
				<div class="pg"></div>

				<div class="item-btn clear">
					<span class="btn-tip fl">
						
						<if condition="$item.class eq 'wait'">
							<a class="btn fl {$item.class}" href="{:U('jump/index',array('iid'=>$item['num_iid']))}" target="_blank" rel="nofollow">
							<span>即将开始</span></a>
						<elseif condition="$item.class eq 'sellout'"/>
							<a class="btn fl {$item.class}" href="{:U('jump/index',array('iid'=>$item['num_iid']))}" target="_blank" rel="nofollow">
							<span>已卖光</span></a>
						<elseif condition="$item.class eq 'end'"/>
							<a class="btn fl {$item.class}" href="{:U('jump/index',array('iid'=>$item['num_iid']))}" target="_blank" rel="nofollow">
							<span>已结束</span></a>
						<elseif condition="$item.class eq 'buy'"/>
							<if condition="$item.shop_type eq 'C' ">
							<a class="btn fl {$item.class}" href="{:U('jump/index',array('iid'=>$item['num_iid']))}" target="_blank" rel="nofollow">
								<span>去淘宝抢购</span>
							</a></if>
							<if condition="$item.shop_type eq 'B' ">
							<a class="btn fl {$item.class}" href="{:U('jump/index',array('iid'=>$item['num_iid']))}" target="_blank" rel="nofollow">
								<span>去天猫抢购</span>
							</a></if>
						</if> 
					</span>
					<div id="tq_html" class="tq_html"></div>
				</div>
				<p class="price bady-time">
					<span class="fl">开抢时间：</span>
					<span class="time fl">{$item.coupon_start_time|date="m月d日 H时i分",###}</span>
					<span class="common nomind shoot_time">
						<script type="text/javascript">
							var __qqClockShare = {
							   content: "{$item.title}",
							   time: "{$item.coupon_start_time|date="Y-m-d H:i",###}",
							   advance: 5,
							   url: "{:C('ftx_site_url')}{:U('item/index',array('id'=>$item['num_iid']))}",
							   icon: "2_1"
							};
							document.write('<a href="http://qzs.qq.com/snsapp/app/bee/widget/open.htm#content=' + encodeURIComponent(__qqClockShare.content) +'&time=' + encodeURIComponent(__qqClockShare.time) +'&advance=' + __qqClockShare.advance +'&url=' + encodeURIComponent(__qqClockShare.url) + '" target="_blank"><img src="http://i.gtimg.cn/snsapp/app/bee/widget/img/' + __qqClockShare.icon + '.png" style="border:0px;"/></a>');
						</script>
					</span>
				</p>
				<p class="fenxiang">
					<span class="fl">分享商品：</span>
					<div id="bdshare" class="fl bdshare_t bds_tools get-codes-bdshare fl">
						<a class="bds_sqq" rel="nofollow"></a>
						<a class="bds_qzone" rel="nofollow"></a>
						<a class="bds_tsina" rel="nofollow"></a>
						<a class="bds_tqq" rel="nofollow"></a>
						<a class="bds_renren" rel="nofollow"></a>
						<a class="bds_taobao tjh" rel="nofollow"></a>
						<span class="bds_more"></span>
						<script type="text/javascript" id="bdshare_js" data="type=button" ></script>
						<script type="text/javascript" id="bdshell_js"></script>
						<script type="text/javascript">
							var bds_config = {
								'bdDesc' : '发现个灰常给力的商品！{$item.title}，赶紧来抢吧！',
								'bdText' : '发现个灰常给力的商品！{$item.title}，赶紧来抢吧！' ,
								'bdPic' : '{:attach(get_thumb($item['pic_url'], '_b'),'item')}',
								'review' : 'off'
							};
							document.getElementById("bdshell_js").src = "http://bdimg.share.baidu.com/static/js/shell_v2.js?cdnversion=" + new Date().getHours();
						</script>
					</div>
				</p>
			</div>
		</div>
		<if condition=" ($item.shop_type eq 'B') OR ($item.shop_type eq 'C') ">
		<script type="text/javascript" src="/index.php?m=item&a=getinfo&id={$item.num_iid}"></script>
		</if>



		<div class="product-comment">
			<div class="bady-tab" id="bady-tab">
				<ul>
					<li class="tab1">
						<a class="badyactive" href="#desc">宝贝详情</a>
						<div class="bady-line-top"></div>
					</li>
					<li class="tab2">
						<a class="" href="#comm">买过的人说
						<em>{$comment_list|count} </em>
						</a>
						<div class=""></div>
					</li>
					<li class="tab3">
						<a href="#user_comment" class="">用户评论<em></em></a>
						<div class=""></div>
					</li>
					<li class="tab4">
						<a href="#xihuan" class="">猜你喜欢<em></em></a>
						<div class=""></div>
					</li>
				</ul>
				<div class="gobuy fr" style="display: none; ">
					<span class="title-tips01">折扣价格<em class="tip-b"></em></span>
					<p class="price fl">
						<em class="org">￥</em> 
						<span class="jd-current">{$item.coupon_price}</span> <if condition="$item.ems eq 1">/包邮</if>
					</p>
					<a target="_blank" id="dealGone" class="btn fl {$item.class}" href="{:U('jump/index',array('iid'=>$item['num_iid']))}" rel="nofollow"><span>
						<if condition="$item.shop_type eq 'C' ">去淘宝抢购</if>
						<if condition="$item.shop_type eq 'B' ">去天猫抢购</if>
						<if condition="$item.shop_type eq 'D' ">去抢购</if>
					</span></a>
				</div>
			</div>






			<div class="information" style="display: block;" >
				<h3><a name="desc" >商品描述</a></h3>
				<p><p>{$item.desc}</p></p>
				<p><p>{$desc}</p></p>
			</div>

			<div class="bady-tab bady-tab01" >
				<ul>
					<li style="border-right: none">
						<a  name="comm" class="" href="#tab3">买过的人说<em>{$comment_list|count} </em></a>
						<div class=""></div>
					</li>
				</ul>
			</div>



		<div  style="display: block;"  class="information comment" >

		<div class="info-parameter comment-dis">
			<div class="item-comment">
				<div class="comment-box">
					<div class="comment-title fl">
						<div class="com-box">
							<div class="pl-box">
								<p>以下是来自<if condition="$item.shop_type eq 'C' ">淘宝</if><if condition="$item.shop_type eq 'B' ">天猫</if>买家的评论</p>
							</div>
							<div class="cf_b com-big">
								<div class="com-list user-info-r">
								
			<ul>
			<volist name="comment_list" id="val">
			<li>
				<div class="rate-user-info">
					<span class="rate-user">
						{$val.uname}
						<span class="rate-user-grade">
                                                        <em class="tm-icon t{$val.tmalllevel}"> </em>
                                                        <em class="tm-icon vip-icon {$val.tblevel}"></em>
						</span>
					</span>
					<span class="rate-right fr">
						<em class="rate-time">{$val.add_time|frienddate}</em>
						<em>评论来自 <if condition="$item.shop_type eq 'C' ">淘宝</if><if condition="$item.shop_type eq 'B' ">天猫</if></em>
					</span>
					<div class="rate-leirong">{$val.info}</div>
				</div>
			</li>
			</volist>
			</ul>
								</div>
							</div>
						</div>
					</div>
					<div class="com-box"></div>
				</div>
			</div>
		</div>
		</div>
		 


		<div class="bady-tab bady-tab02"  >
		  <ul>
		      <li style="border-right: none;">
			  <a name="user_comment" class="" href="#tab3">用户评论<em></em></a>
			  <div class=""></div>
		      </li>
		  </ul>
		</div>
		<div style="display: block;" class="information comment" >
 
			<div class="comment-container">
				<div id="comment-list">
				<volist name="user_comment_list" id="val">
					<dl  uid="{$val.id}" >
						<dt><img src="{:avatar($val['uid'], '32')}" width="40" height="40"></dt>
						<dd class="u-name"><em>{$val.add_time|frienddate}</em>{$val.uname}</dd>
						<dd class="com-nr" title="{$val.infoo}">{$val.info}</dd>
					</dl>
					 
				</volist>
				</div>
			</div>
			<div class="page-com"></div>

			<div class="com-box">
				<textarea name="comment" id="comment" class="pub-txt" onfocus="if(value=='你也可以顺便说点什么 O(∩_∩)O') {value=''}" onblur="if(value=='') {value='你也可以顺便说点什么 O(∩_∩)O'}">你也可以顺便说点什么 O(∩_∩)O</textarea>
				<div class="pub-area">
					<span class="count">还可以输入<em id="num" class="orange">140</em>个字</span>
					<input onclick="saveComment()" type="submit" name="Submit2" value="发表" class="pub_btn" />
				</div>
			</div>
			
		</div><a name="xihuan" ></a>
	</div>
 
	</div> 
	<div class="clear"></div>
</div>
		
<include file="public:list" />

<script>
num=140;
$('#comment').bind('focus keyup input paste',function(){  //采用几个事件来触发（已增加鼠标粘贴事件）   
	$('#num').text(num-$(this).attr("value").length)  //获取评论框字符长度并添加到ID="num"元素上  
});
function saveComment(){
	var commentNum=$('#comment').val().length;
	var commentTip = '你也可以顺便说点什么 O(∩_∩)O';
	if(commentNum==''){
		alert('评论内容不能为空');
	}
	else if(commentNum>num){
		alert('评论字数不能大于140个字');
	}
	else if(commentNum<10){
		alert('评论字数不能小于10个字');
	}
	else{
		var comment=$('#comment').val();
		
		if(comment==commentTip || comment==''){
		    alert(errorArr[27]);
		}
		else{
			$.ajax({
				url: '{:U('ajax/comment')}',
				data:{'iid':thsId,'comment':comment},
				dataType:'json',
				success: function(data){
					//alert(data);
					if(data.s==0){
			    		alert(errorArr[data.id]);
						if(data.id==33){
				    		helpWindows('两次评论间隔要大于24小时','小助手');
						}
					}
					else if(data.s==1){
						alert('评论成功');
			    		location.replace(location.href);
					}
				}
			});
		}
	}
}
</script>
 
<script type="text/javascript" src="__STATIC__/jky/js/deal.js"></script>

<script type="text/javascript">
    $(".bady-tab:eq(0) li:eq(0)").find("a").addClass("badyactive");
    $(".bady-tab:eq(0) li:eq(0)").find("div").addClass("bady-line-top");
    //评论处js切换效果
    $(".bady-tab:eq(0) li").click(function(){
        $(document).scrollTop($('.bady-part').offset().top-50);
        $(".bady-tab").not( $(".bady-tab:eq(0)")).hide();
        $(this).parents("ul").find("a").removeClass("badyactive");
        $(this).parents("ul").find("div").removeClass("bady-line-top");
        $(this).find("a").addClass("badyactive");
        $(this).find("div").addClass("bady-line-top");
        if($(this).index() == 0){
            $(".bady-tab,.information").show();
            if($(".bady-tab").size() - $(".information").size() == 1){
                $(".bady-tab01").hide();
            }else if($(".bady-tab").size() - $(".information").size() == 2){
                $(".bady-tab01").hide();
                $(".bady-tab02").hide();
            }
        }else{
            $(".information").hide();
            $(".information:eq("+$(this).index()+")").show();
        }
    });

    $(".bady-tab:eq(0) li").each(function(index){
        if(typeof($(this).attr("name"))!="undefined"){
            $("#"+$(this).attr("name")).click();
            $("#"+$(this).attr("name")).parents("ul").find("a").removeClass("badyactive");
            $("#"+$(this).attr("name")).parents("ul").find("div").removeClass("bady-line-top");
            $("#"+$(this).attr("name")).find("a").addClass("badyactive");
            $("#"+$(this).attr("name")).find("div").addClass("bady-line-top");
        }
    });

    var F_jkyCeleMenuAni = function(){
        var jiuMenuObj = $('#bady-tab');
        var Tab01Obj= $('.tab1').find("a")
        var Tab02Obj= $('.tab1').find("div")
        var Tab03Obj= $('.tab2').find("a")
        var Tab04Obj= $('.tab2').find("div")
        var Tab05Obj= $('.tab3').find("a")
        var Tab06Obj= $('.tab3').find("div")
	var Tab07Obj= $('.tab4').find("a")
        var Tab08Obj= $('.tab4').find("div")
        var menuScrolFunc = function(){
            scrolY = $(window).scrollTop();
            if(scrolY < 580){
                jiuMenuObj.removeClass('fixed');
                $('div.gobuy').hide();
            }else{
                jiuMenuObj.addClass('fixed');
                $('div.gobuy').show();
            }
            if(scrolY >=$('.goods-list').offset().top && !($(".information:eq(0)").is(":hidden"))){
		Tab05Obj.removeClass("badyactive");
                Tab06Obj.removeClass("bady-line-top");
                Tab03Obj.removeClass("badyactive");
                Tab04Obj.removeClass("bady-line-top");
                Tab01Obj.removeClass("badyactive");
                Tab02Obj.removeClass("bady-line-top");
                Tab07Obj.addClass("badyactive");
                Tab08Obj.addClass("bady-line-top")
            }else if(scrolY >=$('.bady-tab02').offset().top && !($(".information:eq(0)").is(":hidden"))){
	        Tab07Obj.removeClass("badyactive");
                Tab08Obj.removeClass("bady-line-top");
                Tab03Obj.removeClass("badyactive");
                Tab04Obj.removeClass("bady-line-top");
                Tab01Obj.removeClass("badyactive");
                Tab02Obj.removeClass("bady-line-top");
                Tab05Obj.addClass("badyactive");
                Tab06Obj.addClass("bady-line-top")
            }else if(scrolY >= $('.bady-tab01').offset().top && !($(".information:eq(0)").is(":hidden"))){
	        Tab07Obj.removeClass("badyactive");
                Tab08Obj.removeClass("bady-line-top");
                Tab01Obj.removeClass("badyactive");
                Tab02Obj.removeClass("bady-line-top");
                Tab05Obj.removeClass("badyactive");
                Tab06Obj.removeClass("bady-line-top");
                Tab03Obj.addClass("badyactive");
                Tab04Obj.addClass("bady-line-top")
            }else if(!($(".information:eq(0)").is(":hidden"))){
	        Tab07Obj.removeClass("badyactive");
                Tab08Obj.removeClass("bady-line-top");
                Tab03Obj.removeClass("badyactive");
                Tab04Obj.removeClass("bady-line-top");
                Tab05Obj.removeClass("badyactive");
                Tab06Obj.removeClass("bady-line-top");
                Tab01Obj.addClass("badyactive");
                Tab02Obj.addClass("bady-line-top")
            }

        }
        var F_nmenu_scroll = function () {
            if (!window.XMLHttpRequest) {
                return;
            }else{
                //默认执行一次
                menuScrolFunc();
                $(window).bind("scroll", menuScrolFunc);
            }
        }
        F_nmenu_scroll();
    }
    F_jkyCeleMenuAni();
</script>
<load href="__STATIC__/ftxia/js/report.js" />
<include file="public:footer" />
</body>
</html>
