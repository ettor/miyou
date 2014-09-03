DROP TABLE IF EXISTS `ftxia_link`;
CREATE TABLE `ftxia_link` (
  `id` smallint(4) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `img` varchar(255) NOT NULL,
  `url` varchar(255) NOT NULL,
  `ordid` tinyint(3) unsigned NOT NULL DEFAULT '255',
  `status` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

INSERT INTO `ftxia_link` VALUES (1,'秒杀网','','http://www.8mob.com',2,1),(2,'拓谷服饰','','http://www.tuogu2012.com',4,1),(3,'沐沐街','','http://www.mumujie.com/',3,1),(4,'飞天侠淘宝客官网','','http://bbs.8mob.com/',1,1);