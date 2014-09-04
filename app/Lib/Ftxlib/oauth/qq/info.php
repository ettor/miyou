<?php

return array(
    'code'      => 'qq',
    'name'      => 'QQ登录',
    'desc'      => 'http://qzone.qq.com',
    'author'    => 'Ftxia',
    'version'   => '1.0',
    'config'    => array(
        'app_key'   => array(
            'text'  => 'App Key',
            'desc'  => '申请：http://connect.opensns.qq.com/',
            'type'  => 'text',
        ),
        'app_secret'=> array(
            'text'  => 'App Secret',
            'desc'  => '申请：http://connect.opensns.qq.com/',
            'type'  => 'text',
        )
    )
);