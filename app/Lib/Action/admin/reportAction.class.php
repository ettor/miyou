<?php
class reportAction extends BackendAction {
    public function _initialize() {
        parent::_initialize();
        $this->_mod = D('report');
        $this->item_mod = D('items');
    }

    public function _before_index() {
    	$reason['1'] = "商品已下架";
    	$reason['2'] = "商品已卖光";
    	$reason['4'] = "商品链接不正确";
    	$reason['5'] = "商品分类不正确";
    	$reason['6'] = "价格与网站不一致(VIP折扣登录淘宝后才能看到)";
		$reason['7'] = "卖家拒绝发货";
    	$reason['8'] = "商品描述有误";
    	$reason['99'] = "其他原因";
    	$this->assign('reason', $reason);   	
    }

}