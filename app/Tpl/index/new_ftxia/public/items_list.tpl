
	<ul class="goods-list {:C('ftx_site_wc')}">
		<volist name="items_list" id="item" key="i" mod="4">

		<li  class="<eq name="mod" value="3"> last</eq>">
			<div class="sid_{$item.sellerId}  list-good   {$item.class} " id="nid_{$item.num_iid}">
				<div class="good-pic">
					<a href="{:U('jump/index',array('iid'=>$item['num_iid']))}" target="_blank"><img src='/static/jky/images/blank.gif' data-original='{:attach(get_thumb($item['pic_url'], '_b'),'item')}' alt="{$item.title}" class="lazy"   /></a>
					<div class="yhq"> </div>
					<div class="zhekou">{$item.zk}折</div>
				</div>
				<h5 class="good-title">
					<if condition="$item.shop_type eq 'C' ">
					<b class="icon tao-n" title="淘宝网"></b></if>
					<if condition="$item.shop_type eq 'B' ">
					<b class="icon tao-t" title="天猫商城"></b></if>

					<a target="_blank" href="{:U('item/index',array('id'=>$item['num_iid']))}" class="title">{$item.title}</a>
				</h5>
				<div class="good-price">
					<span class="price-current"><em>￥</em>{$item.coupon_price}</span>
					<span class="des-other">
						<span class="price-old"><em>¥{$item.price}</em> </span>
						<span class="discount show">
							<if condition="$item.ems eq 1"><b class="i2" title="包邮"></b></if>
							<notempty name="visitor">
							<if condition="$visitor['username'] eq C('ftx_index_admin')">
							 <a title="不显示" href="javascript:void(0);" data-id="{$item.num_iid}">取消</a> 
							</if>
							</notempty>
						</span>
					</span>
					<div class="btn-new   {$item.class}">
						<a href="{:U('jump/index',array('iid'=>$item['num_iid']))}" target="_blank" rel="nofollow"><span><if condition="$item.class eq 'wait'">
							即将开始
						<elseif condition="$item.class eq 'sellout'"/>
							已卖光
						<elseif condition="$item.class eq 'end'"/>
							已结束
						<elseif condition="$item.class eq 'buy'"/>
							去抢购
						</if></span></a>
					</div>
				</div>
				<div class="pic-des">
					<div class="des-state">
						<span class="state-time fl">开始：{$item.coupon_start_time|date="m月d日 H时i分",###}</span>
						<a class="des-report report fr" znid="{$item.num_iid}" title="{$item.title}" href="javascript:;">举报</a>
					</div>
				</div>
				{$item.coupon_start_time|newicon}
			</div>
		</li>
		</volist>
	</ul>
