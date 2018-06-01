use ks_hty;

create table outstock_info(
id INT NOT NULL AUTO_INCREMENT,
SONo varchar(200) not null comment '销售订单号',
CartonNo VARCHAR(1000) NOT NULL comment '箱唛标签',
PalletNo varchar(200) null comment '卡板编号',
JDENo varchar(50) null comment 'JDE 号',
ProductionNo varchar(100) null comment '生产序列号',
Num varchar(50) null comment '装箱数量',
upload_user varchar(100) null comment '上传用户',
upload_date datetime null default CURRENT_TIMESTAMP ,
file_name varchar(200) not null,
PRIMARY KEY ( id )
)
CREATE INDEX SONo ON outstock_info(SONo(10));
CREATE INDEX CartonNo ON outstock_info(CartonNo(10));
CREATE INDEX PalletNo ON outstock_info(PalletNo(10));
CREATE INDEX JDENo ON outstock_info(JDENo(10));
CREATE INDEX ProductionNo ON outstock_info(ProductionNo(10));


use ks_hty;
create table instock_info(
id INT NOT NULL AUTO_INCREMENT,
JobNo varchar(200) not null comment '工单号',
CartonNo VARCHAR(1000) NOT NULL comment '箱唛标签',
PalletNo varchar(200) null comment '卡板编号',
JDENo varchar(50) null comment 'JDE 号',
ProductionNo varchar(100) null comment '生产序列号' ,
Num varchar(50) null comment '装箱数量',
upload_user varchar(100) null comment '上传用户',
upload_date datetime null default CURRENT_TIMESTAMP ,

file_name varchar(200) not null,
PRIMARY KEY ( id )

)
CREATE INDEX JobNo ON instock_info(JobNo(10));
CREATE INDEX CartonNo ON instock_info(CartonNo(10));
CREATE INDEX PalletNo ON instock_info(PalletNo(10));
CREATE INDEX JDENo ON instock_info(JDENo(10));
CREATE INDEX ProductionNo ON instock_info(ProductionNo(10));


use ks_hty;
create table reference(
id INT NOT NULL AUTO_INCREMENT,
Project  varchar(100) not null comment '项目',
Color varchar(10) not null comment '颜色',
BoxType nvarchar(10) not null comment '合型',
Version nvarchar(50) not null comment '版本',
APN varchar(50) not null comment 'AP/N',
Label varchar(100) not null comment '小标签',
HotPermJDE varchar(100) not null comment '热烫JDE料号',
ColdPermJDE varchar(100) not null comment '冷烫JDE料号',
OEM varchar(100) not null comment 'OEM 客户料号',

PRIMARY KEY ( id )
)




create view view_reference as 
select concat_ws(' ', tb.project ,tb.project_version,color,'款') as productName,tb.APN,tb.OEM,tb.HotPermJDE,tb.ColdPermJDE,tb.num,tb.project,tb.BoxType,tb.color,tb.version
from (
select project,
	Version,
	case Version 
	when '美国版(US)' then 'B1B' 
    when '美国版ROW(US)' then 'B1S'
    when '中国版(CH)' then 'B167'
    when '澳洲版(AUS)' then 'B168'
    when '欧洲版(EU)' then 'B24'
    when '印度版(IND)' then 'B138'
	when '英国版(UK)' then 'B6'
      end as project_version,
	color,
    BoxType,
    case project when 'HTY1' then case BoxType when '小款' then '70'
												when '中款' then '60'end
				when 'HTY2' then case BoxType when '小款' then '80'
												when '中款' then '64'end
                when 'HTY3' then case BoxType when '小款' then '80'
												when '中款' then '64'end
				end as num,
	APN,
    HotPermJDE,
    ColdPermJDE,
    OEM
from reference
) as tb