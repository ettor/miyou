<!doctype html>
<html>
<head>
<include file="public:head" />
<css file="__STATIC__/jky/css/baoming.css" />
</head>
<body>
<include file="public:header" />


<include file="bm_top" />

<!--main start -->
<div class="main {:C('ftx_site_width')} mb20 main-newgood">
		<div class="form-result">
			<table width="100%" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<th width="10%">报名时间</th>
					<th width="">商品名称</th>
					<th width="8%">商品原价</th>
					<th width="8%">活动价格</th>
					<th width="10%">包邮范围</th>
					<th width="10%">30天销售</th>
					<th width="10%">审核状态</th>
					<th width="10%" class="last">操作</th>
				</tr>

				<notempty name="goods_list">
					<volist name="goods_list" id="val">

					<tr>
					<td>{$val.add_time|date="Y-m-d H:i:s",###}</td>
					<td style="text-align:left"><a href="http://item.taobao.com/item.htm?id={$val.num_iid}" class="name" target="_blank">{$val.title}</a></td>
					<td>{$val.price}</td>
					<td>{$val.coupon_price}</td>
					<td><if condition="$val.ems eq 1">包邮<else/>不包邮</if></td>
					<td>{$val.volume}</td>
					<td>
						<div class="red">
						<if condition="$val.pass eq 1"><span>通过</span>
						<br><span class="opt"><span>修改</span>&nbsp;</span>
						<elseif condition="$val.pass eq 0" />
							<if condition="$val.status eq 'fail'"><span>未通过</span><br><span class="opt"><span><a href="{:U('baoming/edit',array('id'=>$val['id']))}">修改</a></span>&nbsp;</span><else/><span>审核中</span><br><span class="opt"><span>修改</span>&nbsp;</span></if>
						</if>
						</div>
					</td>
					<td class="last">
						<a href="{:U('baoming/edit',array('id'=>$val['id']))}" class="btn-blue">修改</a>
					</td>
					</tr>
 
					</volist>
			</table>
					<else/>
			</table>
					<div class="tc f14 pt50">没有找到您要查询的信息哦，您可以先去<a href="{:U('baoming/index')}" style="color:#0289CD;">报名&gt;&gt;</a></div>
					</notempty>



				
				
				
							


							<div class="page"><div class="pageNav"> {$page_bar}</div></div> 
		</div>
		    		</div>
	</div>
</div>


<include file="public:footer" />
<script src="__STATIC__/ftxia/js/goods.js"></script>
</body>
</html>