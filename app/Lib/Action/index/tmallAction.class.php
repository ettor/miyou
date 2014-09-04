<?php
class tmallAction extends FirstendAction {
	public function _initialize() {
        parent::_initialize();
		$this->_mod = D('items');
		$api_config = M('items_site')->where(array('code' => 'ftxia'))->getField('config');
        $this->_tbconfig = unserialize($api_config);
    }

    public function index() {
		$p = I('p',1, 'intval');
		$sort = I('sort','new','trim');

		$top = $this->_get_top();
        $req = $top->load_api('TmallItemsGetRequest');
        $req->setFields('num_iid,title,pic_url,price,volume');
        $req->setPageNo($p);
		$req->setSort($sort);
		$req->setTime(date("Y-m-d H-i"));
		$resp = $top->execute($req);
        $count = $resp->totals;
        $items_list = object_to_array($resp->items);

		$items = array();
		$pagecount = 0;
		$seller_arr = array();
		$sellers = '';
		foreach($items_list as $key=>$val){
			$items[$key]			= $val;
			$items[$key]['class']	= $this->_mod->status($val['status'],$val['coupon_start_time'],$val['coupon_end_time']);
			$items[$key]['zk']		= round(($val['coupon_price']/$val['price'])*10, 1); 
			if(!$val['click_url']){
				$items[$key]['click_url']	=U('jump/index',array('id'=>$val['id']));
			}
			if($val['coupon_start_time']>time()){
				$items[$key]['click_url']	=U('item/index',array('id'=>$val['id']));
				$items[$key]['timeleft'] = $val['coupon_start_time']-time();
			}else{
				$items[$key]['timeleft'] = $val['coupon_end_time']-time();
			}
			$items[$key]['cate_name']		=$cate_list['p'][$val['cate_id']]['name'];
			$url = C('ftx_site_url').U('item/index',array('id'=>$val['id']));
			$items[$key]['url'] = urlencode($url);
			$items[$key]['urltitle'] = urlencode($val['title']);
			$items[$key]['price'] = number_format($val['price'],1);
			$items[$key]['coupon_price'] = number_format($val['coupon_price'],1);
			$pagecount++;
			if($val['sellerId']){
				$seller_arr[] = $val['sellerId'];
			}
			
		}
		$seller_arr = array_unique($seller_arr);
		$sellers = implode(",",$seller_arr);
		$this->assign('sellers', $sellers);


		$this->assign('items_list',$items);
        $pager = $this->_pager($count, '60');
        $this->assign('page', $pager->fshow());

		$this->assign('sort', $sort);
        $this->assign('nav_curr', 'tmall');
        $this->_config_seo(array(
			'title' => '商城优选 — 精选最值得买的爆款商品 — ',
		));
        $this->display();
    }


	private function _get_top() {
        vendor('Ftxia.TopClient');
        vendor('Ftxia.RequestCheckUtil');
        vendor('Ftxia.Logger');
        $top = new TopClient;
        $top->appkey = $this->_tbconfig['app_key'];
        $top->secretKey = $this->_tbconfig['app_secret'];
        return $top;
    }
 
}