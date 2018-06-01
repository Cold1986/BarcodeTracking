/*
  project    : Kunshan Barcode Tracking System
  description: Init scripts of wave II - phase I 
  version    : 1.0
  author     : RRD IT
*/
--版本号表
CREATE TABLE ref_version (
	id INT NOT NULL identity(1,1) primary key (id),
	factoryCode VARCHAR(50) NOT NULL DEFAULT '0', --工厂代码
	version VARCHAR(20) NOT NULL, --版本号
)
;

--参照表
CREATE TABLE reference (
	id INT NOT NULL identity(1,1) primary key (id),
	name VARCHAR(100) NOT NULL, --产品名称
	project VARCHAR(100) NOT NULL, ---项目
	color VARCHAR(10) NOT NULL, --颜色
	boxType VARCHAR(10) NOT NULL, --合型
	productVersion VARCHAR(50) NOT NULL, --版本
	apn VARCHAR(50) NOT NULL, --AP/N
	label VARCHAR(100) NOT NULL, --小标签
	jdeNo VARCHAR(100) NOT NULL, --JDE料号
	outJDENo VARCHAR(100) NULL, --出wistronJDE料号
	oemCustNo VARCHAR(100) NOT NULL, --OEM 客户料号
	outCustNo VARCHAR(100) NULL, --出wistron客户料号
	packingQty VARCHAR(50) NULL DEFAULT '0', --装箱数量
	description VARCHAR(100) NULL, --产品描述
	version INT NOT NULL, --关联版本号表主键
	factoryCode VARCHAR(50) NOT NULL, --制造工厂代码
	operatedBy VARCHAR(50) NOT NULL, --操作人员
	operatedTime DATETIME NOT NULL, --操作时间
	FOREIGN KEY ( version ) REFERENCES ref_version(id)
)
;

--权限表
CREATE TABLE jurisdiction(
	id [int] IDENTITY(1,1) NOT NULL,
	name [nvarchar](50) NULL,
	adAccount [nvarchar](50) NULL,
	createdTime [datetime] NULL,
	createdBy [nvarchar](50) NULL,
	status [varchar](20) NULL
) ON [PRIMARY]

-- 库位管理表
create table RepositoryInfo
(
	id [int] IDENTITY(1,1) NOT NULL,
	repositoryNo  [nvarchar](50) Not NULL UNIQUE, -- 库位编号
	description [nvarchar](500) NULL , --描述
	factoryCode VARCHAR(50) NOT NULL DEFAULT '0', --工厂代码
	lastUpdatedTime [datetime] NULL,
	lastUpdatedBy [nvarchar](50) NULL,
	status [varchar](20) NULL  -- 0 不可用 1可用
)

CREATE TABLE sys_ddlData(
	id INT NOT NULL identity(1,1) primary key (id),
	showKey varchar(100) not null,
	showValue varchar(100) not null,
	type varchar(10) not null,
	sort int null
)


--昆山小料参照表
CREATE TABLE KS_Condiments_Reference (
	id INT NOT NULL identity(1,1) primary key (id),
	project VARCHAR(100) NOT NULL, ---项目
	color VARCHAR(10) NOT NULL, --颜色
	boxType VARCHAR(10) NOT NULL, --合型
	jdeNo VARCHAR(100) NOT NULL, --JDE料号
	packingQty VARCHAR(50) NULL DEFAULT '0', --装箱数量
	description VARCHAR(100) NULL, --产品描述
	factoryCode VARCHAR(50) NOT NULL, --制造工厂代码
	operatedBy VARCHAR(50) NOT NULL, --操作人员
	operatedTime DATETIME NOT NULL, --操作时间
)