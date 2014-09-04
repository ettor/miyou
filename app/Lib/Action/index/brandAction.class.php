<?php
class brandAction extends FirstendAction {
	public function _initialize() {
        parent::_initialize();
        $api_config = M('items_site')->where(array('code' => 'ftxia'))->getField('config');
        $this->_tbconfig = unserialize($api_config);
    }
	 
	public function index(){ 
		$top = $this->_get_top();
        $req = $top->load_api('FtxiaBrandListsGetRequest');
        $req->setFields('title,name');
		$req->setTime(date("y-m-d-h",time()));
		$resp = $top->execute($req);
        $brandlist = object_to_array($resp->brandlist);
		$this->assign('brands',$brandlist['brand']);
		$this->assign('lists',$brandlist['list']);
        $this->assign('nav_curr', 'brand');
        $this->_config_seo(array(
			'title' => ' 【品牌折扣】 —' ,
		));
		$this->display('index');
	}

	public function dlist(){ 
		$uid = I('uid');

		$top = $this->_get_top();
        $req = $top->load_api('FtxiaBrandListsGetRequest');
        $req->setFields('title,name');
		$req->setUid($uid);
		$req->setTime(date("y-m-d-h",time()));
		$resp = $top->execute($req);
        $brandlist = object_to_array($resp->brandlist);
		$this->assign('brands',$brandlist['brand']);
		$this->assign('lists',$brandlist['list']);
        $this->assign('nav_curr', 'brand');
        $this->_config_seo(array(
			'title' => ' 【品牌折扣】 —  ' ,
		));
		$this->display('dlist');
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