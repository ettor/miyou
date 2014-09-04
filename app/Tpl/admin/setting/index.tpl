<include file="public:header" />
<div class="pad_lr_10">
	<form id="info_form" action="{:u('setting/edit')}" method="post" enctype="multipart/form-data">
	<table width="100%" class="table_form">
		<tr>
            <th width="150">{:L('site_url')} :</th>
            <td><input type="text" name="setting[site_url]" class="input-text" size="30" value="{:C('ftx_site_url')}">
	    <span class="gray ml10">网站地址必须以http:// 开头 / 斜杠结尾</span> 如http://bbs.138gzs.com/</td>
        </tr>
        <tr>
            <th width="150">{:L('site_name')} :</th>
            <td><input type="text" name="setting[site_name]" class="input-text" size="30" value="{:C('ftx_site_name')}"></td>
        </tr>
    
        <tr>
            <th>{:L('site_icp')} :</th>
            <td><input type="text" name="setting[site_icp]" class="input-text" size="30" value="{:C('ftx_site_icp')}">
            如：闽ICP备08010074号-1 </td>
        </tr>
		<tr>
            <th>QQ :</th>
            <td><input type="text" name="setting[qq]" class="input-text" size="30" value="{:C('ftx_qq')}"></td>
        </tr>
        <tr>
            <th>{:L('statistics_code')} :</th>
            <td><p>
                <textarea rows="6" cols="80" name="setting[statistics_code]">{:C('ftx_statistics_code')}</textarea> 
            </p>
            <p>统计代码申请教程<a href="统计代码申请教程http://bbs.138gzs.com/forum-49-1.html" target="_blank">http://bbs.138gzs.com/forum-49-1.html</a></p></td>
           
      </tr>
		 <tr>
            <th width="150">{:L('ipban_switch')} :</th>
            <td>
                <label><input type="radio" <if condition="C('ftx_ipban_switch') eq '1'">checked="checked"</if> value="1" name="setting[ipban_switch]"> {:L('open')}</label> &nbsp;&nbsp;
                <label><input type="radio" <if condition="C('ftx_ipban_switch') eq '0'">checked="checked"</if> value="0" name="setting[ipban_switch]"> {:L('close')}</label>
                <span class="gray ml10">如果本站没有添加禁止IP地址库，建议关闭改功能提升性能</span>
            </td>
        </tr>
    	<tr>
            <th width="150">采集器秘钥 :</th>
            <td>
                <input type="text" name="setting[robots_key]" class="input-text" size="50" value="{:C('ftx_robots_key')}" /><br>
	            <span class="gray ml10">采集器密匙只要是华美网络论坛vip免费联系QQ<a href="tencent://message/?uin=422677261&amp;Site=http://bbs.138gzs.com&amp;Menu=yes" target="_blank">422677261</a>索要</span></td>
        </tr>
    	<tr>
            <th width="150">妈妈采集密钥 :</th>
            <td>
                <input type="text" name="setting[code]" class="input-text" size="50" value="{:C('ftx_code')}" /><br>
	            <span class="gray ml10">该功能由于淘宝开放平台api搜索需要付费，所以我们也是进行收费的，阿里妈妈采集一天1块钱联系QQ<a href="tencent://message/?uin=422677261&amp;Site=http://bbs.138gzs.com&amp;Menu=yes" target="_blank">422677261</a></span></td>
        </tr>
		 <tr>
            <th width="150">{:L('kefu_html')} :</th>
            <td>
                <input type="text" name="setting[kefu_html]" class="input-text" size="80" value="{:C('ftx_kefu_html')}">
                <span class="gray ml10"><br>前台客服链接：请填写如：http://amos.im.alisoft.com/msg.aw?v=2&uid=你的客服旺旺&site=cntaobao&s=2&charset=utf-8</span>
            </td>
        </tr>

		<tr>
            <th width="150">Header添加代码 :</th>
            <td>
                <textarea rows="6" cols="80" name="setting[header_html]">{:C('ftx_header_html')}</textarea>
                <span class="gray ml10"><br>
                需要在header添加内容的可以加在这里</span>
            ，<a href="http://bbs.138gzs.com/forum-49-1.html" target="_blank">相关使用教程</a></td>
        </tr>


		<tr>
            <th width="150">淘点金代码 :</th>
            <td>
                <textarea rows="6" cols="80" name="setting[taojindian_html]">{:C('ftx_taojindian_html')}</textarea>
                <span class="gray ml10"><br>
                淘点金申请教程<a href="http://bbs.138gzs.com/thread-298-1-1.html">http://bbs.138gzs.com/thread-298-1-1.html</a></span>
            </td>
        </tr>

    	<tr>
        	<th>{:L('site_status')} :</th>
        	<td>
            	<label><input type="radio" class="J_change_status" <if condition="C('ftx_site_status') eq '1'">checked="checked"</if> value="1" name="setting[site_status]"> {:L('open')}</label> &nbsp;&nbsp;
                <label><input type="radio" class="J_change_status" <if condition="C('ftx_site_status') eq '0'">checked="checked"</if> value="0" name="setting[site_status]"> {:L('close')}</label>
            </td>
    	</tr>
        <tr id="J_closed_reason" <if condition="C('ftx_site_status') eq 1">class="hidden"</if>>
        	<th>{:L('closed_reason')} :</th>
        	<td><textarea rows="4" cols="50" name="setting[closed_reason]" id="closed_reason">{:C('ftx_closed_reason')}</textarea></td>
    	</tr>
        <tr>
        	<th></th>
        	<td><input type="hidden" name="menuid"  value="{$menuid}"/><input type="submit" class="smt mr10" value="{:L('submit')}"/></td>
    	</tr>
	</table>
	</form>
</div>
<include file="public:footer" />
<script>
$(function(){
    $('.J_change_status').live('click', function(){
        if($(this).val() == '0'){
            $('#J_closed_reason').fadeIn();
        }else{
            $('#J_closed_reason').fadeOut();
        }
    });
});
</script>
</body>
</html>