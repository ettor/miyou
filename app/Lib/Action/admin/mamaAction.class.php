<?php
class mamaAction extends BackendAction {
	public function _initialize() {
		parent::_initialize();
		$this->_mod = D('items');
		$this->_cate_mod = D('items_cate');
	} 
	public function _before_index() {
		$res = $this->_cate_mod->field('id,name')->select();
		$cate_list = array();
		foreach ($res as $val) {
			$cate_list[$val['id']] = $val['name'];
		} 
		$this->assign('cate_list', $cate_list);
		$this->sort = 'ordid ASC,';
		$this->order = 'add_time DESC';
	} 
	protected function _search() {
		$res = $this->_cate_mod->field('id,name')->select();
		$cate_list = array();
		foreach ($res as $val) {
			$cate_list[$val['id']] = $val['name'];
		} 
		$this->assign('cate_list', $cate_list);
		$start_credit_arr = $this->cridet();
		$end_credit_arr = $this->cridet();
		$start_credit = $this->_request('start_credit', 'trim');
		$end_credit = $this->_request('end_credit', 'trim');
		$this->assign('start_credit_arr', $start_credit_arr);
		$this->assign('end_credit_arr', $end_credit_arr);
		$this->assign('start_credit', $start_credit);
		$this->assign('end_credit', $end_credit);
		$sort = $this->_request('sort', 'trim');
		$sort_arr = $this->sort_arr();
		$this->assign('sort', $sort);
		$this->assign('sort_arr', $sort_arr);
		$time_start = $this->_request('time_start', 'trim');
		$time_start = isset($time_start)?$time_start:date("Y-m-d H:m", time());
		$time_end = $this->_request('time_end', 'trim');
		$time_end = isset($time_end)?$time_end:date("Y-m-d H:m", time() + (24 * 60 * 60-1) * 3);
		$page_no = $this->_request('page_no', 'trim');
		$page_no = isset($page_no)?$page_no:1;
		$tmall = $this->_request('tmall', 'trim');
		$tmall = isset($tmall)?$tmall:false;
		$this->assign("tmall", $tmall);
		$price_min = $this->_request('price_min', 'trim');
		$price_max = $this->_request('price_max', 'trim');
		$rates_min = $this->_request('rates_min', 'trim');
		$rates_max = $this->_request('rates_max', 'trim');
		$area = $this->_request('area', 'trim');
		$cate_id = $this->_request('cate_id', 'intval');
		if ($cate_id) {
			$id_arr = $this->_cate_mod->get_child_ids($cate_id, true);
			$map['cate_id'] = array('IN', $id_arr);
			$spid = $this->_cate_mod->where(array('id' => $cate_id))->getField('spid');
			if ($spid == 0) {
				$spid = $cate_id;
			} else {
				$spid .= $cate_id;
			} 
		} 
		$cid = $this->_request('cid', 'trim');
		$this->assign('add_time', time());
		$this->assign('time_start', $time_start);
		$this->assign('time_end', $time_end);
		$keyword = $this->_request('keyword', 'trim');
		if ($keyword) {
			$mama_pars = array('keyword' => $keyword, 'area' => $area, 'start_price' => $price_min, 'end_price' => $price_max, 'start_commission_rate' => $rates_min, 'end_commission_rate' => $rates_max, 'start_credit' => $start_credit, 'end_credit' => $end_credit, 'tmall_item' => $tmall, 'sort' => $sort, 'cid' => $cid, 'host' => $_SERVER['SERVER_NAME'], 'code' => C('ftx_code'), 'page_no' => $page_no,);
			$mama_str = base64_decode("aHR0cDovL3phb3NoaS51ei50YW9iYW8uY29tL2FwaS9nZXRfaXRlbXNfc2VhcmNoLnBocD97cGFyc30=");
			$mama_url = str_replace('{pars}', http_build_query($mama_pars), $mama_str);
			$url_md5 = md5($mama_url);
			if (F("MamaItem_" . $url_md5)) {
				$result = F("MamaItem_" . $url_md5);
			} else {
				$result = g2u($this->http($mama_url));
				$result = json_decode($result, true);
				F("MamaItem_" . $url_md5, $result);
			} 
			foreach($result as $key => $value) {
				$result[$key]['coupon_rate'] = round(($value['final_price'] / $value['price']) * 10000, 0);
				if (M("items")->where(array('num_iid' => $value['item_id']))->find()) {
					$result[$key]['title'] = "<span style='color:red;'>已经采集</span>--" . $result[$key]['title'];
				} 
			} 
			$this->assign("mama_list", $result);
			$this->assign('search', array('time_start' => $time_start, 'time_end' => $time_end, 'price_min' => $price_min, 'price_max' => $price_max, 'rates_min' => $rates_min, 'rates_max' => $rates_max, 'area' => $area, 'selected_ids' => $spid, 'cate_id' => $cate_id, 'keyword' => $keyword, 'cid' => $cid, 'host' => $_SERVER['SERVER_NAME'], 'code' => C('ftx_code'), 'page_no' => $page_no,));
		} 
	} 
	public function add() {
		if (IS_POST) {
			if (false === $data = $this->_mod->create()) {
				$this->error($this->_mod->getError());
			} 
			if (!$data['cate_id'] || !trim($data['cate_id'])) {
				$this->error('请选择商品分类');
			} 
			$item_id = $this->_mod->publish($data);
			!$item_id && $this->error(L('operation_failure'));
			$this->success(L('operation_success'));
		} else {
			$orig_list = M('items_orig')->where(array('pass' => 1))->select();
			$this->assign('orig_list', $orig_list);
			$this->display();
		} 
	} 
	public function ajaxadd() {
		if (IS_POST) {
			$data = array();
			$num_iid = $data['num_iid'] = I("num_iid", "", "trim");
			$title = $data['title'] = I("title", "", "trim,strip_tags");
			$data['intro'] = $title;
			$data['coupon_price'] = I("coupon_price", "", "trim");
			$data['coupon_rate'] = I("coupon_rate", "", "trim");
			$data['price'] = I("price", "", "trim");
			$data['cate_id'] = I("cate_id", "", "trim");
			$data['coupon_start_time'] = I("time_start", "", "trim");
			$data['coupon_end_time'] = I("time_end", "", "trim");
			$data['status'] = "underway";
			$item_info = $this->getItem($num_iid);
			$data['add_time'] = time();
			$data['pic_url'] = $item_info['pic_url'];
			$data['nick'] = $item_info['nick'];
			$data['click_url'] = $item_info['click_url'];
			$data['inventory'] = $item_info['num'];
			if ($item_info['freight_payer'] == "buyer") {
				$data['ems'] = 0;
			} else {
				$data['ems'] = 1;
			} 
			$data['shop_type'] = $item_info['tmall'];
			$data['volume'] = $item_info['volume'];
			$data['content'] = $item_info['content'];
			$data['hits'] = rand(100, 1000);
			$data['likes'] = rand(100, 1000);
			$tag_list = $this->_mod->get_tags_by_title($title);
			$data['tags'] = implode(' ', $tag_list);
			if (M("items")->where(array('num_iid' => $num_iid))->find()) {
				$this->ajaxReturn(0, '', "宝贝已经存在.");
				exit();
			} 
			if ($this->_mod->publish($data)) {
				$this->ajaxReturn(1, '', "宝贝添加成功");
			} 
		} 
	} 
	public function ajaxgetid() {
		$url = $this->_get('url', 'trim');
		$url == '' && $this->ajaxReturn(0, L('please_input') . L('correct_itemurl'));
		!$this->get_id($url) && $this->ajaxReturn(0, L('please_input') . L('correct_itemurl'));
		$iid = $this->get_id($url);
		$items = M('items')->where(array('num_iid' => $iid))->find();
		$items && $this->ajaxReturn(0, L('item_exist'));
		$content = $this->getItem($iid);
		$this->ajaxReturn(1, '', $content);
	} 
	public function get_id($url) {
		$id = 0;
		$parse = parse_url($url);
		if (isset($parse['query'])) {
			parse_str($parse['query'], $params);
			if (isset($params['id'])) {
				$id = $params['id'];
			} elseif (isset($params['item_id'])) {
				$id = $params['item_id'];
			} elseif (isset($params['default_item_id'])) {
				$id = $params['default_item_id'];
			} elseif (isset($params['amp;id'])) {
				$id = $params['amp;id'];
			} elseif (isset($params['amp;item_id'])) {
				$id = $params['amp;item_id'];
			} elseif (isset($params['amp;default_item_id'])) {
				$id = $params['amp;default_item_id'];
			} 
		} 
		return $id;
	} 
	public function ajax_gettags() {
		$title = $this->_get('title', 'trim');
		$tag_list = D('items')->get_tags_by_title($title);
		$tags = implode(' ', $tag_list);
		$this->ajaxReturn(1, L('operation_success'), $tags);
	} 
	public function http($url) {
		set_time_limit(0);
		$result = file_get_contents($url);
		if ($result === false) {
			$curl = curl_init();
			curl_setopt($curl, CURLOPT_URL, $url);
			curl_setopt($curl, CURLOPT_HEADER, false);
			curl_setopt($curl, CURLOPT_RETURNTRANSFER, 1);
			$result = curl_exec($curl);
			curl_close($curl);
		} 
		if (empty($result)) {
			$result = false;
		} 
		return $result;
	} 
	public function cridet() {
		$cridetArr = array('1' => '一心', '2' => '两心', '3' => '三心', '4' => '四心', '5' => '五心', '6' => '一钻', '7' => '两钻', '8' => '三钻', '9' => '四钻', '10' => '五钻', '11' => '一冠', '12' => '两冠', '13' => '三冠', '14' => '四冠', '15' => '五冠', '16' => '一黄冠', '17' => '二黄冠', '18' => '三黄冠', '19' => '四黄冠', '20' => '五黄冠');
		$arr = array();
		foreach($cridetArr as $key => $value) {
			$arr[] = array("id" => $key, "name" => $value);
		} 
		return $arr;
	} 
	public function sort_arr() {
		$arr = array(array("id" => "price_asc", "name" => "价格从低到高"), array("id" => "sales_desc", "name" => "销量从高到低"), array("id" => "credit_desc", "name" => "信用从高到低"),);
		return $arr;
	} 
	public function ajax_mama_cate() {
		$cid = $this->_get('cid', 'trim', 0);
		if (F("Mamacid_" . $cid)) {
			$result = F("Mamacid_" . $cid);
		} else {
			$url = "http://zaoshi.uz.taobao.com/api/get_cats.php?cid=" . $cid;
			$result = g2u($this->http($url));
			$result = json_decode($result, true);
			$result = $result['item_cats']['item_cat'];
			F("Mamacid_" . $cid, $result);
		} 
		if (empty($result)) {
			$this->ajaxReturn(0, "暂无分类");
		} else {
			$this->ajaxReturn(1, "成功获取", $result);
		} 
	} 
} 
?>