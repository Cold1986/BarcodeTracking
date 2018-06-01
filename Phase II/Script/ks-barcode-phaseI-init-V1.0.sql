/*
  project    : Kunshan Barcode Tracking System
  description: Init scripts of wave II - phase I 
  version    : 1.0
  author     : RRD IT
*/
--�汾�ű�
CREATE TABLE ref_version (
	id INT NOT NULL identity(1,1) primary key (id),
	factoryCode VARCHAR(50) NOT NULL DEFAULT '0', --��������
	version VARCHAR(20) NOT NULL, --�汾��
)
;

--���ձ�
CREATE TABLE reference (
	id INT NOT NULL identity(1,1) primary key (id),
	name VARCHAR(100) NOT NULL, --��Ʒ����
	project VARCHAR(100) NOT NULL, ---��Ŀ
	color VARCHAR(10) NOT NULL, --��ɫ
	boxType VARCHAR(10) NOT NULL, --����
	productVersion VARCHAR(50) NOT NULL, --�汾
	apn VARCHAR(50) NOT NULL, --AP/N
	label VARCHAR(100) NOT NULL, --С��ǩ
	jdeNo VARCHAR(100) NOT NULL, --JDE�Ϻ�
	outJDENo VARCHAR(100) NULL, --��wistronJDE�Ϻ�
	oemCustNo VARCHAR(100) NOT NULL, --OEM �ͻ��Ϻ�
	outCustNo VARCHAR(100) NULL, --��wistron�ͻ��Ϻ�
	packingQty VARCHAR(50) NULL DEFAULT '0', --װ������
	description VARCHAR(100) NULL, --��Ʒ����
	version INT NOT NULL, --�����汾�ű�����
	factoryCode VARCHAR(50) NOT NULL, --���칤������
	operatedBy VARCHAR(50) NOT NULL, --������Ա
	operatedTime DATETIME NOT NULL, --����ʱ��
	FOREIGN KEY ( version ) REFERENCES ref_version(id)
)
;

--Ȩ�ޱ�
CREATE TABLE jurisdiction(
	id [int] IDENTITY(1,1) NOT NULL,
	name [nvarchar](50) NULL,
	adAccount [nvarchar](50) NULL,
	createdTime [datetime] NULL,
	createdBy [nvarchar](50) NULL,
	status [varchar](20) NULL
) ON [PRIMARY]

-- ��λ�����
create table RepositoryInfo
(
	id [int] IDENTITY(1,1) NOT NULL,
	repositoryNo  [nvarchar](50) Not NULL UNIQUE, -- ��λ���
	description [nvarchar](500) NULL , --����
	factoryCode VARCHAR(50) NOT NULL DEFAULT '0', --��������
	lastUpdatedTime [datetime] NULL,
	lastUpdatedBy [nvarchar](50) NULL,
	status [varchar](20) NULL  -- 0 ������ 1����
)

CREATE TABLE sys_ddlData(
	id INT NOT NULL identity(1,1) primary key (id),
	showKey varchar(100) not null,
	showValue varchar(100) not null,
	type varchar(10) not null,
	sort int null
)


--��ɽС�ϲ��ձ�
CREATE TABLE KS_Condiments_Reference (
	id INT NOT NULL identity(1,1) primary key (id),
	project VARCHAR(100) NOT NULL, ---��Ŀ
	color VARCHAR(10) NOT NULL, --��ɫ
	boxType VARCHAR(10) NOT NULL, --����
	jdeNo VARCHAR(100) NOT NULL, --JDE�Ϻ�
	packingQty VARCHAR(50) NULL DEFAULT '0', --װ������
	description VARCHAR(100) NULL, --��Ʒ����
	factoryCode VARCHAR(50) NOT NULL, --���칤������
	operatedBy VARCHAR(50) NOT NULL, --������Ա
	operatedTime DATETIME NOT NULL, --����ʱ��
)