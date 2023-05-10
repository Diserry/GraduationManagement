# GraduationManagement
On this project you can manage the graduates for thier obtain employment information and there also has a campus recruitment for this project.There needs five  roles in this project--Student,Teacher,Class supervisor ,Employment Department,Administrators,all of them have different functions.
本项目为校赛项目，Winfrom，下面是所有数据库源码以及数据，数据库为Mysql
-- MySQL dump 10.13  Distrib 5.7.30, for Win64 (x86_64)
--
-- Host: localhost    Database: graduatemanagement
-- ------------------------------------------------------
-- Server version	5.7.30-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `graduatemanagement`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `graduatemanagement` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `graduatemanagement`;

--
-- Table structure for table `academy`
--

DROP TABLE IF EXISTS `academy`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `academy` (
  `ac_no` bigint(20) NOT NULL COMMENT '学院号',
  `ac_name` varchar(50) DEFAULT NULL COMMENT '学院名',
  PRIMARY KEY (`ac_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `academy`
--

LOCK TABLES `academy` WRITE;
/*!40000 ALTER TABLE `academy` DISABLE KEYS */;
INSERT INTO `academy` VALUES (30000,'软件与软工智能学院'),(30001,'管理学院');
/*!40000 ALTER TABLE `academy` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `account`
--

DROP TABLE IF EXISTS `account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `account` (
  `a_no` bigint(20) NOT NULL COMMENT '登录账号',
  `a_password` varchar(10) DEFAULT '123456' COMMENT '登录密码',
  `a_name` varchar(15) DEFAULT NULL COMMENT '用户姓名',
  `a_identy` int(11) DEFAULT NULL COMMENT '用户身份',
  PRIMARY KEY (`a_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account`
--

LOCK TABLES `account` WRITE;
/*!40000 ALTER TABLE `account` DISABLE KEYS */;
INSERT INTO `account` VALUES (1001,'123456','管理员',5),(1002,'123456','辅导员',1),(1003,'123456','班导师',2),(1004,'123456','就业科',3),(1005,'123456','企业',4),(1006,'123456','班导师1',2),(3001,'123456','企业1',4),(3002,'123456','企业2',4),(3003,'123456','腾讯',4),(3004,'123456','企业4',4),(3005,'123456','企业5',4),(3006,'123456','企业6',4),(3007,'123456','企业7',4),(3008,'123456','滴滴',4),(3009,'123456','胡豆传媒',4),(3010,'123456','和Seth',4),(3366,'123456','佳佳',0),(20000,'123456','学生1',0),(20001,'123456','学生2',0),(20002,'123456','学生3',0),(20003,'222222','学生4',0),(20005,'123456','学生5',0),(21996,'123456','学生6',0),(21997,'123456','学生7',0),(219971006,'123456','贺贵俊',0),(219971101,'123456','曹志伟',0),(219971102,'123456','学生',0),(219971106,'123456','刘小龙',0);
/*!40000 ALTER TABLE `account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `class`
--

DROP TABLE IF EXISTS `class`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `class` (
  `t_no` bigint(20) NOT NULL COMMENT '辅导员号',
  `b_no` bigint(20) NOT NULL COMMENT '班导师号',
  `class_no` bigint(20) NOT NULL COMMENT '班级号',
  `class_name` varchar(50) DEFAULT NULL COMMENT '班级名',
  `s_academy` varchar(20) NOT NULL COMMENT '学院',
  `pro_no` bigint(20) NOT NULL COMMENT '专业号',
  PRIMARY KEY (`t_no`,`b_no`,`class_no`,`s_academy`,`pro_no`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `class`
--

LOCK TABLES `class` WRITE;
/*!40000 ALTER TABLE `class` DISABLE KEYS */;
INSERT INTO `class` VALUES (1002,1003,40000,'21软工一班','30000',50000),(1002,1006,41000,'21工商一班','30001',51000);
/*!40000 ALTER TABLE `class` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `company`
--

DROP TABLE IF EXISTS `company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `company` (
  `comp_no` bigint(20) NOT NULL COMMENT '企业号',
  `comp_name` varchar(50) NOT NULL COMMENT '企业名',
  `profile` varchar(1000) DEFAULT NULL COMMENT '企业简介',
  `service` varchar(50) DEFAULT NULL COMMENT '服务',
  `comp_position` varchar(50) DEFAULT NULL COMMENT '地址',
  `treatment` varchar(10) DEFAULT NULL COMMENT '待遇',
  `imagecount` bigint(20) DEFAULT NULL COMMENT '企业环境的图片个数',
  PRIMARY KEY (`comp_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `company`
--

LOCK TABLES `company` WRITE;
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
INSERT INTO `company` VALUES (3001,'华为','华为创立于1987年，是全球领先的ICT（信息与通信）基础设施和智能终端提供商，我们致力于把数字世界带入每个人、每个家庭、每个组织，构建万物互联的智能世界：让无处不在的联接，成为人人平等的权利；为世界提供最强算力，让云无处不在，让智能无所不及；所有的行业和组织，因强大的数字平台而变得敏捷、高效、生机勃勃；通过AI重新定义体验，让消费者在家居、办公、出行等全场景获得极致的个性化体验。目前华为约有19.4万员工，业务遍及170多个国家和地区，服务30多亿人口。','智能硬件,IT技术服务｜咨询,制造业','深圳','110101',4),(3002,'阿里巴巴','阿里巴巴集团的使命是让天下没有难做的生意。\r\n我们旨在赋能企业改变营销、销售和经营的方式。我们为商家、品牌及其他企业提供基本的互联网基础设施以及营销平台，让其可借助互联网的力量与用户和客户互动。我们的业务包括核心电商、云计算、数字媒体和娱乐以及创新项目和其他业务。我们并通过子公司菜鸟网络及所投资的关联公司口碑，参与物流和本地服务行业，同时与蚂蚁金融服务集团有战略合作，该金融服务集团主要通过中国领先的第三方网上支付平台支付宝运营。','电子商务,互联网','杭州','101101',4),(3003,'腾讯','腾讯以技术丰富互联网用户的生活。\r\n通过通信及社交平台微信和 QQ 促进用户联系，并助其连接数字内容和生活服务，尽在弹指间。\r\n通过高效广告平台，协助品牌和市场营销者触达数以亿计的中国消费者。\r\n通过金融科技及企业服务，促进合作伙伴业务发展，助力实现数字化升级。等。','游戏,社交媒体,音频｜视频媒体','深圳','111011',4),(3004,'百度','“百度”二字，来自于八百年前南宋词人辛弃疾的一句词：众里寻他千百度。这句话描述了词人对理想的执着追求。\r\n百度拥有数万名研发工程师，这是中国乃至全球最为优秀的技术团队。这支队伍掌握着世界上最为先进的搜索引擎技术，使百度成为中国掌握世界尖端科学核心技术的中国高科技企业，也使中国成为美国、俄罗斯、和韩国之外，全球仅有的4个拥有搜索引擎核心技术的国家之一。','人工智能服务,信息检索,科技金融','北京','100111',4),(3005,'快手','快手是领先的内容社区和社交平台，是短视频行业开创者与引领者。快手致力于创造一个温暖和信任的社区，让更多普通人拥有表达和被看见的机会，并由此培育了繁荣与高互动的社区生态，每天有上千万优质内容上传。','短视频','北京','101010',4),(3006,'360','三六零安全科技股份有限公司（以下简称 “360公司”）是中国最大的互联网和安全服务提供商。公司创立于2005年，是互联网免费安全的首倡者，先后推出360安全卫士、360手机卫士、360安全浏览器等国民级安全产品，PC安全产品月活用户达5亿，移动安全产品月活超4.6亿。同时，360公司还为中央机关、国家部委、地方政府和企事业单位提供安全咨询、安全运维、安全培训等多种安全服务。','工具类产品,信息检索,信息安全','北京','110111',4),(3007,'bilibili','哔哩哔哩是中国年轻世代高度聚集的综合性视频社区，被用户亲切地称为“B站”。截至2021年第一季度，B站月均活跃用户达2.23亿，其中35岁及以下用户占比超86%。 围绕用户、创作者和内容，B站构建了一个源源不断产生优质内容的生态系统。中国优秀的专业创作者都聚集在B站创作内容，涵盖生活、游戏、时尚、知识、音乐等数千个品类和圈层，带领着流行文化的风潮，成为中文互联网极其独特的存在。目前，B站91%的视频播放量都来自于专业用户创作的视频（Professional User Generated Video，PUGV）。 在此基础之上，B站提供了移动游戏、直播、付费内容、广告、漫画、电商等商业化产品服务，并对电竞、虚拟偶像等前沿领域展开战略布局。 B站多个季度蝉联QuestMobile“Z世代偏爱APP”和“Z世代偏爱泛娱乐APP”两项榜单第一位。公司于2018年3月登陆美国纳斯达克，并于2021年3月在港交所二次上市。','音频｜视频媒体','上海','101101',4),(3008,'滴滴出行','滴滴出行是卓越的一站式移动出行平台；为5.5亿用户提供出租车、快车、专车、豪华车、公交、代驾、企业级、共享单车、共享电单车、共享汽车、外卖等多元化的出行和运输服务。在滴滴平台，超过3100万车主及司机获得灵活的工作和收入机会。\r\n滴滴出行与监管部门、出租车行业及社群积极协作，致力于以智慧交通创新解决全球交通、环保和就业挑战。滴滴也和汽车产业链企业建立广泛的合作，携手打造面向未来的汽车运营服务平台。\r\n在全球范围内，滴滴与Grab、Lyft、Ola、99、Taxify、Careem构建的移动出行网络触达全球超过80%的人口、覆盖1000多座城市。目前，滴滴通过旗下99平台服务巴西，在墨西哥和澳洲提供滴滴品牌的出行业务；并在日本通过合资公司提供网约出租车服务。滴滴始终致力于提升用户体验，创造社会价值，建设安全、开放、可持续的移动出行新生态。','旅游｜出行','北京','100110',4),(3009,'胡豆传媒','拍电影','娱乐','重庆工程学院','111111',1),(3010,'和Seth','5挺合适','过热和','身体很好','101000',2);
/*!40000 ALTER TABLE `company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `graduationdeclaration`
--

DROP TABLE IF EXISTS `graduationdeclaration`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `graduationdeclaration` (
  `s_no` bigint(20) NOT NULL COMMENT '学生学号',
  `s_counsellor` varchar(10) DEFAULT NULL COMMENT '辅导员',
  `s_ClassTutor` varchar(10) DEFAULT NULL COMMENT '班导师',
  `degree` varchar(10) DEFAULT NULL COMMENT '学历',
  `EmploymentStatus` varchar(10) DEFAULT NULL COMMENT '就业状态',
  `Referrer` varchar(10) DEFAULT NULL COMMENT '推荐老师',
  `Jobs` varchar(20) DEFAULT NULL COMMENT '就业岗位',
  `Salary` bigint(20) DEFAULT NULL COMMENT '就业薪资',
  `ArrivalTime` date DEFAULT NULL COMMENT '到岗时间',
  `f_phone` varchar(13) DEFAULT NULL COMMENT '家长电话',
  `EmploymentCompanies` varchar(50) DEFAULT NULL COMMENT '就业单位',
  `s_Comment` tinytext COMMENT '备注信息',
  `s_state` varchar(10) DEFAULT NULL COMMENT '状态，集中or分散',
  `s_phone` varchar(13) DEFAULT NULL COMMENT '学生电话',
  `s_name` varchar(50) DEFAULT NULL COMMENT '学生姓名',
  `class_name` varchar(50) DEFAULT NULL COMMENT '班级名',
  `pro_name` varchar(50) DEFAULT NULL COMMENT '专业名',
  `ac_name` varchar(50) DEFAULT NULL COMMENT '学院名',
  `go_way` varchar(20) DEFAULT NULL COMMENT '毕业去向',
  PRIMARY KEY (`s_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `graduationdeclaration`
--

LOCK TABLES `graduationdeclaration` WRITE;
/*!40000 ALTER TABLE `graduationdeclaration` DISABLE KEYS */;
INSERT INTO `graduationdeclaration` VALUES (3366,'辅导员','班导师','本科','已签约','无','教师',5600,'2023-03-08','13111111','育才中学','','分散','13111','佳佳','21软工一班','软件工程','软件与软工智能学院','广东'),(20000,'辅导员','班导师','本科','未实习','vhj','火锅',0,'2023-01-11','181','2322','不懂','集中','181','学生1','21软工一班','软件工程','软件与软工智能学院','天津'),(20001,'辅导员','班导师','本科','实习','发个','故不能和',8000,'2022-10-18','161','规划和','个体u衣柜','分散','161','学生2','21软工一班','软件工程','软件与软工智能学院','北京'),(20002,'辅导员','班导师1','本科','已签约','鸡鸡','辉煌',8900,'2023-01-28','177','的风格','我也是骗你们的','集中','177','学生3','21工商一班','工商管理','管理学院','北京'),(20003,'辅导员','班导师1','本科','实习','就来','加一',5600,'2023-01-19','131','不过不会','骗你们的','集中','131','学生4','21工商一班','工商管理','管理学院','北京'),(21997,'辅导员','班导师1','本科','已签约','张老师','程序员',6000,'2023-01-12','1','腾讯','无','集中','1','学生5','21工商一班','工商管理','管理学院','重庆'),(219971006,'辅导员','班导师','本科','已签约','绘画','软件工程师',9100,'2023-01-31','22113','育才中学','','分散','1236515','贺贵俊','21软工一班','软件工程','软件与软工智能学院','青海'),(219971101,'教师1','教师2','本科','已签约','无','挖掘机师傅',9000,'2021-07-08','13156894451','山东蓝翔','','分散','1310000101','曹志伟','21软工一班','软件工程','软件与软工智能学院','山东'),(219971106,'辅导员','班导师','本科','实习','无','挖掘机师傅',11000,'2023-03-15','1523365','山东蓝翔','','集中','13165456','刘小龙','21软工一班','软件工程','软件与软工智能学院','河南');
/*!40000 ALTER TABLE `graduationdeclaration` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `interview`
--

DROP TABLE IF EXISTS `interview`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `interview` (
  `comp_no` bigint(20) NOT NULL COMMENT '单位号',
  `p_no` bigint(20) NOT NULL COMMENT '岗位号',
  `s_no` bigint(20) NOT NULL COMMENT '学号',
  `i_time` datetime DEFAULT NULL COMMENT '面试时间',
  `i_position` varchar(100) DEFAULT NULL COMMENT '面试地点',
  `i_state` varchar(10) DEFAULT NULL COMMENT '面试状态',
  `i_content` varchar(200) DEFAULT NULL COMMENT '备注，内容',
  PRIMARY KEY (`comp_no`,`p_no`,`s_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `interview`
--

LOCK TABLES `interview` WRITE;
/*!40000 ALTER TABLE `interview` DISABLE KEYS */;
INSERT INTO `interview` VALUES (3001,4001,20001,'2023-02-27 10:00:00','','已通过',''),(3001,4001,21997,'2023-02-27 10:00:00','','已通过',''),(3001,4002,20000,'2023-03-01 10:00:00','一道风景','已通过','4345346'),(3001,4009,21997,'2023-02-27 10:00:00','','已通过',''),(3008,4001,219971006,'2023-03-22 10:00:00','他','已通过','图'),(3008,4001,219971101,'2023-03-10 10:00:00','西安方式如果时光','已通过','早点来'),(3008,4001,219971106,'2023-03-10 10:00:00','的风景','已通过','早点来'),(3008,4002,3366,'2023-03-22 10:00:00','等待','未通过','早点来');
/*!40000 ALTER TABLE `interview` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jobwanted`
--

DROP TABLE IF EXISTS `jobwanted`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `jobwanted` (
  `s_no` bigint(20) NOT NULL COMMENT '用户',
  `comp_no` bigint(20) NOT NULL COMMENT '单位',
  `p_no` bigint(20) NOT NULL COMMENT '岗位',
  `j_birth` date DEFAULT NULL COMMENT '出生日期',
  `j_degree` varchar(50) DEFAULT NULL COMMENT '学历',
  `j_phone` varchar(20) DEFAULT NULL COMMENT '联系电话',
  `j_head` varchar(255) DEFAULT NULL COMMENT '个人头像',
  `j_resume` varchar(255) DEFAULT NULL COMMENT '简历图片',
  `j_state` varchar(20) DEFAULT NULL COMMENT '处理进程',
  `j_time` datetime DEFAULT NULL COMMENT '提交时间',
  PRIMARY KEY (`s_no`,`comp_no`,`p_no`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jobwanted`
--

LOCK TABLES `jobwanted` WRITE;
/*!40000 ALTER TABLE `jobwanted` DISABLE KEYS */;
INSERT INTO `jobwanted` VALUES (3366,3008,4002,'2023-03-22','本科','13111111','20230322132837.jpg','202303221328371.jpg','面试失败','2023-03-22 13:28:37'),(20000,3001,4002,'2023-03-01','本科','14654165','20230301201756.jpg','202303012017561.jpg','已就职','2023-03-01 20:17:56'),(20000,3003,4003,'2002-05-03','研究生','12345678910','20230203210835.jpg','202302032108351.jpg','待审核','2023-02-03 21:08:35'),(20000,3004,4002,'2002-05-22','研究生','12345678910','20230203202454.jpg','202302032024541.jpg','已通过','2023-02-03 20:24:54'),(20001,3001,4001,'2002-07-28','本科','12345678910','20230202180011.jpg','202302021800111.jpg','待面试','2023-02-02 18:00:11'),(20001,3006,4002,'2003-07-28','本科','12345678910','20230203212559.jpg','202302032125591.jpg','待审核','2023-02-03 21:25:59'),(20002,3001,4001,'1999-01-26','研究生','32452345345','20230226155540.jpg','202302261555401.jpg','未通过','2023-02-26 15:55:40'),(20002,3002,4003,'2021-02-08','研究生','14725836900','20230202183948.jpg','202302021839481.jpg','待审核','2023-02-02 18:39:48'),(20003,3006,4002,'2020-02-02','博士','98765432100','20230202223246.jpg','202302022232461.jpg','待审核','2023-02-02 22:32:46'),(20005,3003,4003,'2001-06-06','本科','25802','20230202224843.jpg','202302022248431.jpg','待审核','2023-03-01 19:28:35'),(21996,3008,4001,'2003-04-02','研究生','14714714714','20230202184253.jpg','202302021842531.jpg','待审核','2023-02-02 18:42:53'),(21997,3001,4001,'2023-02-18','博士','5675765787','20230218204701.jpg','202302182047011.jpg','已辞退','2023-02-18 20:47:01'),(21997,3001,4009,'2001-02-20','研究生','12345678','20230227102739.jpg','202302271027391.jpg','已辞退','2023-02-27 10:27:39'),(21997,3002,4003,'2001-06-21','本科','12345679810','20230204231941.jpg','202302042320151.jpg','待审核','2023-02-04 23:20:15'),(21997,3006,4002,'2023-02-18','研究生','214165465465','20230218141330.jpg','202302181413301.jpg','待审核','2023-02-18 14:13:30'),(21997,3008,4001,'2002-06-27','研究生','13028396681','20230203192207.jpg','202302031922071.jpg','未通过','2023-02-03 19:23:29'),(219971006,3008,4001,'2023-03-22','本科','113552','20230322144431.jpg','202303221444311.jpg','已就职','2023-03-22 14:44:31'),(219971101,3008,4001,'2023-03-09','本科','13111111','20230309222520.jpg','202303092225201.jpg','已就职','2023-03-09 22:25:20'),(219971106,3008,4001,'2023-03-10','本科','156566','20230310142555.jpg','202303101425551.jpg','已就职','2023-03-10 14:25:55');
/*!40000 ALTER TABLE `jobwanted` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `post`
--

DROP TABLE IF EXISTS `post`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `post` (
  `p_no` bigint(20) NOT NULL COMMENT '岗位便编号',
  `p_name` varchar(50) NOT NULL COMMENT '岗位名称',
  PRIMARY KEY (`p_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `post`
--

LOCK TABLES `post` WRITE;
/*!40000 ALTER TABLE `post` DISABLE KEYS */;
INSERT INTO `post` VALUES (4001,'软件工程师'),(4002,'算法工程师'),(4003,'前端开发工程师'),(4004,'单片机开发'),(4005,'软件测试员'),(4006,'软件维护员'),(4007,'unity开发'),(4008,'上位机开发'),(4009,'游戏开发');
/*!40000 ALTER TABLE `post` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `postcompany`
--

DROP TABLE IF EXISTS `postcompany`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `postcompany` (
  `p_no` bigint(20) NOT NULL COMMENT '岗位编号',
  `comp_no` bigint(20) NOT NULL COMMENT '发布企业',
  `pc_salary` varchar(20) DEFAULT NULL COMMENT '岗位工资',
  `pc_position` varchar(50) DEFAULT NULL COMMENT '岗位地址',
  `pc_experience` varchar(50) DEFAULT NULL COMMENT '需要工作经验（n-m年）',
  `pc_degree` varchar(10) DEFAULT NULL COMMENT '学历要求',
  `pc_technology` varchar(50) DEFAULT NULL COMMENT '涉及技术',
  `pc_phone` varchar(20) DEFAULT NULL COMMENT '联系电话',
  `pc_count` bigint(20) DEFAULT NULL COMMENT '招聘人数',
  `pc_responsibility` varchar(500) DEFAULT NULL COMMENT '岗位职责',
  `pc_requrie` varchar(500) DEFAULT NULL COMMENT '技能要求',
  PRIMARY KEY (`p_no`,`comp_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `postcompany`
--

LOCK TABLES `postcompany` WRITE;
/*!40000 ALTER TABLE `postcompany` DISABLE KEYS */;
INSERT INTO `postcompany` VALUES (4001,3001,'10~20K薪','深圳','经验不限','本科','java/C++/C语言','12345678910',15,'1. 有相关工作经验\r\n2. 熟练使用通用编程语言进行开发工作\r\n3. 完成相应模块软件的设计，开发，编码和测试任务\r\n4. 英语可作为工作语言\r\n5. 沟通能力强，团队合作性好','【岗位要求】\r\n1、大专或以上学历，电子信息、计算机、通信或相关专业；\r\n2、具有音频产品行业（耳机或音箱）软件开发2年以上工作经验；\r\n3、具有TWS蓝牙耳机BES（恒⽞）芯片或Airoha（络达）芯片软件开发2年以上开发经验者优先；\r\n4、精通C及C编译环境，并具有Linux/RTOS平台开发经验，有独⽴的系统分析与设计能⼒。\r\n5、具备一定的硬件知识，能看懂原理图并熟悉基本硬件⼯作原理。\r\n6、熟悉蓝⽛产品基本UI软件开发，熟练掌握蓝⽛A2DP,AVRCP,HFP,SPP主流profile，以及BLE规范和在 TWS产品中的应⽤ 。\r\n7、能独⽴分析蓝⽛空包⽇志以及⼿机HCI⽇志，结合固件⽇志快速定位和解决问题。\r\n8、踏实严谨，有强烈的责任⼼和团队精神以及良好的沟通协调能⼒，善于学习总结。\r\n9、熟练英语读写能力，良好的英语沟通能力。\r\n10、有过git和jira⼯作经验者优先'),(4001,3002,'9k~20k薪','杭州','3~5年','本科','C#/java/Msql',NULL,20,'无','无'),(4001,3008,'35k~30k薪','杭州','3~5年','本科及以上','C/C++/嵌入式','12345678910',20,'1，协同硬件工程师完成方案评估和核心芯片选型；\r\n2. 负责嵌入式软件方案设计、文档编写，代码编写以及调试，包括最后上线运营与维护；\r\n3. 通过数据分析已知问题或发现潜在问题；\r\n4. 协调和推动已知问题的解决和方案的落地；','1. 本科及以上学历，计算机、电子、自控类相关专业；\r\n2. 5年以上嵌入式软件研发经验，丰富的设计和调试经验，较强的发现并解决问题的能力；\r\n3. 熟练使用C/C++语言，有扎实的编程基础和丰富的编程经验；\r\n4. 精通ARM体系结构和嵌入式系统，熟悉FreeRTOS等实时操作系统，能够熟练移植；\r\n5. 熟练掌握CAN，SPI，I2C，UART硬件接口协议，有丰富的STM或TI DSP等MCU开发经验；\r\n6. 熟练掌握电机控制原理，PID控制，FOC矢量控制，有丰富的交流电机调试经验；'),(4002,3001,'9k~15k薪','深圳','2~4年','本科','C#/java/Mysql',NULL,30,'1234','4576'),(4002,3004,'25~50k薪','北京','1~3年','本科及以上','C/C++/Python/linux','11223344556',15,'-负责百度地图路况和ETA技术的研究与开发\r\n-解决百度地图产品中路况和ETA的实际问题\r\n-研究道路交通流量建模技术与应用\r\n-模型优化、特征优化','-计算机及相关专业本科及以上学历\r\n-熟悉Linux平台，熟练掌握C/C++编程，Python、Shell或其他脚本语言\r\n-对数据结构和算法设计有较为深刻的理解\r\n-熟悉机器学习和深度学习，有相关算法应用经验\r\n-优秀的分析问题和解决问题的能力，勇于解决难题\r\n-有路况、ETA、导航相关实践经验的优先\r\n-在学术会议上发表过相关领域文章者优先'),(4002,3006,'30~45k薪','上海','3~5年','本科及以上','搜索算法/深度学习','14725836910',36,'负责CTR/CVR模型优化相关工作、在特征工程、模型结构、机制策略等方面进行持续探索优化、提升广告的点击率和转化率，进而提升系统变现能力以及客户投放效果。在工作中能够主动发现各种策略的问题并提出优化方案，推进优化方案落实；','1. 具备计算广告、机器学习 、推荐系统、搜索等相关领域的实践或研究经验；\r\n2. 具有扎实的工程实现能力，精通C/C++/Java/python语言之一；\r\n3. 计算机、数学统计学等专业本科以上学历，3年以上机器学习相关工作经验；\r\n4. 良好的沟通能力，有较强的责任心并具有一定的抗压能力。'),(4002,3008,'9000','北京','5-10年','本科','Mysql',NULL,3,'阿尔法狗的修复\r\n','会C#'),(4003,3002,'14k~28k薪','杭州','3~5年','本科及以上','CSS/htlm5/vue','11111111111',30,'1. 参与淘系行业&商家技术产品的的前端开发工作，工作内容包括但不限于架构设计、交互设计与实现、 组件优化、技术创新等；\r\n\r\n2. 参与产品需求的分析，与设计师、后端工程师一起完成产品功能的开发，优化用户体验；\r\n\r\n3. 通过对业务深刻的理解，改进技术方案，提高整体的研发效率和质量；负责或协助相关开发文档的撰写，并分享经验和新技术，帮助团队一起成长。\r\n\r\n工作地址','CSS/htlm5/vue'),(4003,3003,'8k~15k薪','上海','1~2年','本科及以上','CSS/javaScript/html','00000000000',20,'前端开发实习\r\n岗位职责\r\n负责网站前端应用开发','1.熟悉HTML、CSS、JavaScript等Web前端技术；\r\n2.熟悉VUE、Nodejs者优先；'),(4009,3001,'200K~500K薪','深圳','1万年','幼儿园','玄学，天文，地理',NULL,300,'每天作息规律\r\n凌晨0点上班\r\n晚上11：59下班','能过独立了开发操作系统');
/*!40000 ALTER TABLE `postcompany` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `profession`
--

DROP TABLE IF EXISTS `profession`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `profession` (
  `pro_name` varchar(50) NOT NULL COMMENT '专业名',
  `pro_no` bigint(20) NOT NULL COMMENT '专业号',
  `ac_no` bigint(20) NOT NULL COMMENT '学院号',
  PRIMARY KEY (`pro_no`,`ac_no`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `profession`
--

LOCK TABLES `profession` WRITE;
/*!40000 ALTER TABLE `profession` DISABLE KEYS */;
INSERT INTO `profession` VALUES ('软件工程',50000,30000),('工商管理',51000,30001);
/*!40000 ALTER TABLE `profession` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student`
--

DROP TABLE IF EXISTS `student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `student` (
  `s_no` bigint(20) NOT NULL COMMENT '学生学号',
  `s_name` varchar(50) NOT NULL COMMENT '学生姓名',
  `s_class` bigint(20) DEFAULT NULL COMMENT '班级号',
  `s_pro` bigint(20) NOT NULL COMMENT '专业号',
  `check_state` varchar(20) NOT NULL COMMENT '审批状态：1辅导员审批，',
  `s_sex` varchar(2) DEFAULT NULL COMMENT '性别',
  PRIMARY KEY (`s_no`,`s_pro`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student`
--

LOCK TABLES `student` WRITE;
/*!40000 ALTER TABLE `student` DISABLE KEYS */;
INSERT INTO `student` VALUES (3366,'佳佳',40000,50000,'就业科审核',''),(11312,'二分',40000,50000,'未提交',''),(20000,'学生1',40000,50000,'已通过审核','男'),(20001,'学生2',40000,50000,'已通过审核','女'),(20002,'学生3',41000,51000,'已通过审核','男'),(20003,'学生4',41000,51000,'已通过审核','男'),(20005,'学生5',40000,50000,'未提交','男'),(21996,'学生6',41000,51000,'未提交','女'),(21997,'学生7',41000,51000,'已通过审核','男'),(33333,'工业化',40000,50000,'未提交',''),(219971006,'贺贵俊',40000,50000,'已通过审核',''),(219971101,'曹志伟',40000,50000,'已通过审核',''),(219971102,'罗刚',41000,51000,'未提交',''),(219971106,'刘小龙',40000,50000,'就业科审核',''),(219971107,'韩刚龙',40000,50000,'未提交','男'),(219971108,'孙丽萍',40000,50000,'未提交','女'),(219971109,'陈桂平',41000,51000,'未提交','男'),(219971110,'李熙平',41000,51000,'未提交','男'),(219971111,'董三女',40000,50000,'未提交','男'),(219971112,'李开英',41000,51000,'未提交','女'),(219971113,'刘再海',41000,51000,'未提交','男'),(219971114,'康永清',40000,50000,'未提交','男'),(219971115,'康根',40000,50000,'未提交','男'),(219971116,'刘来有',40000,50000,'未提交','男'),(219971117,'石双厚',41000,51000,'未提交','男'),(219971118,'石天才',41000,51000,'未提交','男'),(219971119,'石利军',41000,51000,'未提交','男');
/*!40000 ALTER TABLE `student` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teacher`
--

DROP TABLE IF EXISTS `teacher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `teacher` (
  `t_no` bigint(20) NOT NULL COMMENT '教师号',
  `t_name` varchar(50) DEFAULT NULL COMMENT '教师名',
  `t_phone` varchar(13) DEFAULT NULL COMMENT '教师电话',
  `t_academyno` bigint(20) DEFAULT NULL COMMENT '所属学院号',
  PRIMARY KEY (`t_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teacher`
--

LOCK TABLES `teacher` WRITE;
/*!40000 ALTER TABLE `teacher` DISABLE KEYS */;
INSERT INTO `teacher` VALUES (1002,'辅导员','177464888',30000),(1003,'班导师','155378937',30000),(1006,'就业科','156676979',30001),(1008,'尖椒鸡','1311111',30001);
/*!40000 ALTER TABLE `teacher` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-10 16:51:09
