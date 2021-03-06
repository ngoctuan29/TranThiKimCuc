if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BM05_YTTN_Template' and b.name='DepartmentCode')
	alter table BM05_YTTN_Template add DepartmentCode varchar(200) not null default ''
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BM05_YTTN' and b.name='Cancel')
	alter table BM05_YTTN add Cancel int not null default 0
go
IF NOT EXISTS (SELECT name FROM sys.objects WHERE object_id = OBJECT_ID(N'BM05_YTTN_Template') AND type in (N'U'))
CREATE TABLE BM05_YTTN_Template
(
	RowIDTemplate int identity(2016,1),
	OrderNumber int not null,
	LaMa varchar(5),
	LaMa_Detail varchar(10),
	TargetName nvarchar(300),
	Result nvarchar(100),
	ServiceCode varchar(100) not null default ''
	CONSTRAINT pk_BM05_YTTN_Template PRIMARY KEY(RowIDTemplate)
)
go
IF NOT EXISTS (SELECT name FROM sys.objects WHERE object_id = OBJECT_ID(N'BM05_YTTN') AND type in (N'U'))
CREATE TABLE BM05_YTTN
(
	RowID Decimal(20,0) identity(20016,1),
	EmployeeCode varchar(15),
	IDate datetime default getdate(),
	WorkDate datetime,
	FromDate date,
	ToDate date,
	CONSTRAINT pk_BM05_YTTN PRIMARY KEY(RowID)
)
go
IF NOT EXISTS (SELECT name FROM sys.objects WHERE object_id = OBJECT_ID(N'BM05_YTTN_Detail') AND type in (N'U'))
CREATE TABLE BM05_YTTN_Detail
(
	RowID_BM05 Decimal(20,0),
	RowIDTemplate int not null,
	TargetName nvarchar(300),
	Result nvarchar(50),
	CONSTRAINT pk_BM05_YTTN_Detail PRIMARY KEY(RowID_BM05,RowIDTemplate)
)
go
if exists(select name from sysobjects where name ='proIns_BM05_YTTN_Template')
	drop procedure proIns_BM05_YTTN_Template
go
create procedure proIns_BM05_YTTN_Template
(
	@RowIDTemplate int,
	@OrderNumber int,
	@LaMa varchar(5),
	@LaMa_Detail varchar(10),
	@TargetName nvarchar(300),
	@Result nvarchar(100),
	@ServiceCode varchar(100)= '',
	@DepartmentCode varchar(200)= ''
)
as
begin tran
	if exists(select RowIDTemplate from BM05_YTTN_Template where RowIDTemplate=@RowIDTemplate)
		update BM05_YTTN_Template set OrderNumber=@OrderNumber,LaMa=@LaMa,LaMa_Detail=@LaMa_Detail,TargetName=@TargetName,Result=@Result,ServiceCode=@ServiceCode,DepartmentCode=@DepartmentCode where RowIDTemplate=@RowIDTemplate
	else
	begin
		insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result,ServiceCode,DepartmentCode) values(@OrderNumber,@LaMa,@LaMa_Detail,@TargetName,@Result,@ServiceCode,@DepartmentCode)
	end
commit tran
go
if exists(select name from sysobjects where name ='proIns_BM05_YTTN')
	drop procedure proIns_BM05_YTTN
go
create procedure proIns_BM05_YTTN
(
	@Result decimal output,
	@RowID decimal,
	@EmployeeCode varchar(15),
	@WorkDate datetime,
	@FromDate date,
	@ToDate date
)
as
begin tran
	if exists(select RowID from BM05_YTTN where CONVERT(date,ToDate,103)>=CONVERT(date,@FromDate,103))
		set @Result =-1
	else if exists(select RowID from BM05_YTTN where RowID=@RowID)
	begin
		update BM05_YTTN set EmployeeCode=@EmployeeCode,WorkDate=@WorkDate,FromDate=@FromDate,ToDate=@ToDate where RowID=@RowID
		set @Result = @RowID
	end
	else
	begin
		insert into BM05_YTTN(EmployeeCode,WorkDate,FromDate,ToDate) values(@EmployeeCode,@WorkDate,@FromDate,@ToDate)
		set @Result = (select RowID from BM05_YTTN where CONVERT(date,FromDate,103)=CONVERT(date,@FromDate,103) and CONVERT(date,ToDate,103)=CONVERT(date,@ToDate,103))
	end
	
commit
go
if exists(select name from sysobjects where name ='proIns_BM05_YTTNDetail')
	drop procedure proIns_BM05_YTTNDetail
go
create procedure proIns_BM05_YTTNDetail
(
	@RowID_BM05 Decimal(20,0),
	@RowIDTemplate int ,
	@TargetName nvarchar(300),
	@Result nvarchar(50)
)
as
begin tran
	if exists(select RowID_BM05 from BM05_YTTN_Detail where RowID_BM05=@RowID_BM05 and RowIDTemplate=@RowIDTemplate)
		update BM05_YTTN_Detail set TargetName=@TargetName,Result=@Result where RowID_BM05=@RowID_BM05 and RowIDTemplate=@RowIDTemplate
	else 
		insert into BM05_YTTN_Detail(RowID_BM05,RowIDTemplate,TargetName,Result) values(@RowID_BM05,@RowIDTemplate,@TargetName,@Result)
commit
go
if exists(select name from sysobjects where name ='proDel_BM05YTTN_Template')
	drop procedure proDel_BM05YTTN_Template
go
create procedure proDel_BM05YTTN_Template
(
	@RowIDTemplate int,
	@iresult int output
)
as
begin tran
	if exists(select RowIDTemplate from BM05_YTTN_Detail where RowIDTemplate=@RowIDTemplate)
		set @iresult =-1
	else
	begin
		delete from BM05_YTTN_Template where RowIDTemplate=@RowIDTemplate
		set @iresult =1
	end
commit
go
----------
if exists(select name from sysobjects where name ='proView_MBM05_SKSS' and type='P')
	drop procedure proView_MBM05_SKSS
go
create procedure proView_MBM05_SKSS
(
	@RowID_BM05 Decimal(20,0)
)
as
begin
	select a.FromDate,a.ToDate,b.TargetName,b.Result,c.OrderNumber,c.LaMa from BM05_YTTN a inner join BM05_YTTN_Detail b on a.RowID=b.RowID_BM05 inner join BM05_YTTN_Template c on b.RowIDTemplate=c.RowIDTemplate where a.RowID=@RowID_BM05
end
go
if exists(select name from sysobjects where name ='proView_TotalSuggested' and type='P')
	drop procedure proView_TotalSuggested
go
create procedure proView_TotalSuggested
(
	@FromDate date,
	@ToDate date,
	@ServiceCode varchar(2000)
)
as
begin
	declare @TableLimitServices table(ServiceCode varchar(15))
	insert into @TableLimitServices(ServiceCode)(select ServiceCode from Service where ServiceCode in(select * from dbo.fnSplitString(@ServiceCode,',')))
	select sum(a.Quantity) TotalQuantity
	from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b1.ServiceGroupCode=b2.ServiceGroupCode
	where CONVERT(date,a.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
	--and a.Status=1 
	and a.Paid =1
	and a.ServiceCode in(select * from @TableLimitServices)
end
go
--------------------------------------I
/*
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(1,'I','',N'Hoạt động chăm sóc bà mẹ','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(2,'I','1',N'Số phụ nữ có thai được theo dõi tại cơ sở','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(3,'I','1.1',N'     Trđ: Vị thành niên','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(4,'I','2',N'Số PN có thai được XN HIV','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(5,'I','2.1',N'     Trđ: Số có kết quả khẳng định nhiễm HIV',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(6,'I','3',N'Tổng số lần khám thai','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(7,'I','3.1',N'     Trđ: Số lần XN nước tiểu','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(8,'I','4',N'Số PN đẻ tại cơ sở',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(9,'I','4.1',N'     Trđ: Số đẻ tuổi vị thành niên',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(10,'I','4.2',N'     Số được quản lý thai','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(11,'I','4.3',N'     Số được tiêm UV đủ mũi vắc xin UV','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(12,'I','4.4',N'     Số được KT ≥ 3 lần trong 3 kỳ thai sản','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(13,'I','4.5',N'     Số được KT ≥ 4 lần trong 4 kỳ thai sản','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(14,'I','4.6',N'     Số được XN HIV trước và trong lần mang thai này','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(15,'I','4.7',N'     Số được XN HIV khi chuyển dạ',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(16,'I','4.8',N'     Số được điều trị ARV khi mang thai',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(17,'I','4.9',N'     Trđ: Số được khẳng định có HIV (+) trong kỳ mang thai này',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(18,'I','4.10',N'     Số được điều trị ARV khi đẻ',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(19,'I','4.11',N'     Số đẻ can thiệp FX/GH',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(20,'I','4.12',N'     Số đẻ được cán bộ có kỹ năng đỡ',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(21,'I','4.13',N'     Số đẻ con thứ 3 trở lên',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(22,'I','4.14',N'     Số đẻ được xét nghiệm viêm gan B',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(23,'I','4.15',N'     Số được xét nghiệm giang mai',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(24,'I','5',N'Các tai biến sản khoa, trong đó:','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(25,'I','5.1.1',N'     Trđ: Băng huyết - Mắc',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(26,'I','5.1.2',N'     Trđ: Băng huyết - Chết',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(27,'I','5.2.1',N'     Vỡ tử cung - Mắc','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(28,'I','5.2.2',N'     Vỡ tử cung - Chết',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(29,'I','5.3.1',N'     Sản giật - Mắc',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(30,'I','5.3.2',N'     Sản giật - Chết',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(31,'I','5.4.1',N'     Uốn ván sơ sinh - Mắc',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(32,'I','5.4.2',N'     Uốn ván sơ sinh - Chết',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(33,'I','5.5.1',N'     Nhiễm khuẩn - Mắc',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(34,'I','5.5.2',N'     Nhiễm khuẩn - Chết',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(35,'I','5.6.1',N'     Tai biến phá thai - Mắc',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(36,'I','5.6.2',N'     Tai biến phá thai - Chết',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(37,'I','5.7.1',N'     Tai biến khác - Mắc',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(38,'I','5.7.2',N'     Tai biến khác - Chết',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(39,'I','6',N'Số tử vong mẹ',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(40,'I','7',N'Số lần khám phụ khoa','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(41,'I','8',N'Số lần chữa phụ khoa','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(42,'I','9',N'Số nhiễm khuẩn đường sinh sản',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(43,'I','9.1',N'     Trđ: Số điều trị Giang mai',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(44,'I','9.2',N'     Số điều trị Lậu',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(45,'I','10',N'Phá thai',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(46,'I','10.1',N'     Trđ: Phá thai ≤ 7 tuần',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(47,'I','10.2',N'     Trên 7 tuần đến <12 tuần',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(48,'I','10.3',N'     Phá thai ≥ 12 tuần',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(49,'I','10.4',N'     Số phá thai vị thành niên',N'không có')
--------------------------------------II
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(50,'II','',N'Tình hình sức khỏe trẻ em','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(51,'II','1',N'Số trẻ đẻ ra sống',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(52,'II','1.1',N'     Trđ: Nữ',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(53,'II','2',N'Số trẻ đẻ non',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(54,'II','3',N'Số bị dị tật bẩm sinh',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(55,'II','4',N'Số bị ngạt',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(56,'II','5',N'Số trẻ sinh ra từ mẹ HIV',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(57,'II','6',N'Số trẻ sơ sinh được cân',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(58,'II','6.1',N'     Trđ: Số < 2500gram',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(59,'II','8',N'Số trẻ được bú sữa mẹ giờ đầu',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(60,'II','9',N'Số được tiêm vitamin K1',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(61,'II','7',N'Số trẻ được tiêm viêm gan B',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(62,'II','7.1',N'Số trẻ được tiêm viêm gan B',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(63,'II','12',N'Tử vong thai nhi và trẻ em',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(64,'II','12.1',N'     Trđ: Số thai nhi TV (từ 22 tuần đến khi sinh)',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(65,'II','12.2',N'     Số TV < 7 ngày',N'không có')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(66,'II','12.3',N'     Số TV < 28 ngày',N'không có')
-------------------------------------III
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(67,'III','',N'Kế hoạch hóa gia đình','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(68,'III','1',N'Tổng số mới thực hiện BPTT','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(69,'III','1.1',N'     Số mới đặt DCTC','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(70,'III','1.2',N'     Số mới dùng thuốc tránh thai','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(71,'III','1.3',N'     Trđ: Thuốc tiêm','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(72,'III','1.4',N'     Thuốc cấy','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(73,'III','1.5',N'     Số mới triệt sản','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(74,'III','1.6',N'     Trđ: Nữ','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(75,'III','1.7',N'     Biện pháp hiện đại khác','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(76,'III','2',N'Tai biến KHHGĐ','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(77,'III','2.1',N'     Trđ: Đặt vòng - Mắc','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(78,'III','2.2',N'     Trđ: Đặt vòng - Chết','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(79,'III','2.3',N'     Thuốc - Mắc','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(80,'III','2.4',N'     Thuốc - Chết','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(81,'III','2.5',N'     Triệt sản - Mắc','')
insert into BM05_YTTN_Template(OrderNumber,LaMa,LaMa_Detail,TargetName,Result) values(82,'III','2.6',N'     Triệt sản - Chết','')
*/
if exists(select name from sysobjects where name ='proDel_MedicalRecord')
	drop procedure proDel_MedicalRecord
go
create procedure proDel_MedicalRecord
(
	@PatientCode varchar(50),
	@MedicalRecordCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@Result int output
)
as
begin
	if exists (select PatientCode from MedicalRecord where MedicalRecordCode=@MedicalRecordCode and PatientReceiveID=@PatientReceiveID)
	begin
		declare @ReceiptID numeric(18,0)=0
		set @ReceiptID=(select ReceiptID from MedicalRecord where MedicalRecordCode=@MedicalRecordCode and PatientReceiveID=@PatientReceiveID)
		if exists(select PatientCode from MedicalRecord where MedicalRecordCode=@MedicalRecordCode and PatientReceiveID=@PatientReceiveID and Status=1)
			set @Result=-1 -- Ho so da duyet don thuoc, khong cho phep xoa!
		else if exists(select PatientCode from MedicinesForPatients where MedicalRecordCode=@MedicalRecordCode and PatientReceiveID=@PatientReceiveID)
			set @Result=-1 -- Ho so da duyet don thuoc, khong cho phep xoa!
		else if exists(select PatientCode from MedicalRecord where MedicalRecordCode=@MedicalRecordCode and PatientReceiveID=@PatientReceiveID and Paid=1 and (BanksAccountCode is not null and BanksAccountCode<>''))
			set @Result=-2 -- Benh an da thanh toan vien phi
		else if exists(select PatientCode from SuggestedServiceReceipt where PatientCode=@PatientCode and RefID=@PatientReceiveID and Paid=1 and (BanksAccountCode is not null and BanksAccountCode<>'') and ReferenceCode=@MedicalRecordCode)
			set @Result=-4 -- Dịch vụ đã thanh toán tiền, không cho phép xóa
		else if exists(select PatientCode from SuggestedServiceReceipt where PatientCode=@PatientCode and RefID=@PatientReceiveID and ReferenceCode=@MedicalRecordCode and Status=1)
			set @Result=-5 -- Có Dịch vụ đã thực hiện, không cho phép xóa
		else
		begin
			delete from PatientAppointment where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID
			delete from SurviveSign where RefID=@PatientReceiveID and PatientCode=@PatientCode and ReferenceCode=@MedicalRecordCode
			delete from MedicalPrescriptionDetail where MedicalRecordCode=@MedicalRecordCode
			delete from MedicalRecord where MedicalRecordCode=@MedicalRecordCode and PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode
			--- Trong: huy so kham thai va hs ngoai tru 19/09/2016
			delete from MedicalRecord_ANC where MedicalRecordCode=@MedicalRecordCode
			delete from MedicalRecord_Childbirth where MedicalRecordCode=@MedicalRecordCode
			delete from MedicalRecord_Abortions where MedicalRecordCode=@MedicalRecordCode
			update MedicalRecordOutput set Cancel=1 where PatientReceiveID=@PatientReceiveID
			--- select * from MedicalRecordOutput
			update SuggestedServiceReceipt set [Status]=0 where ReceiptID=@ReceiptID
			delete from SuggestedServiceReceipt where RefID=@PatientReceiveID and PatientCode=@PatientCode and ReferenceCode=@MedicalRecordCode and [Status]=0 and (BanksAccountCode is null or BanksAccountCode='')
			set @Result =1 --- success
		end
    end
    else
		set @Result =-3 --- Mã hs benh an chua phat sinh
end
go
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'MedicalRecord_Childbirth') AND type in (N'U'))
CREATE TABLE MedicalRecord_Childbirth
(
	MedicalRecordCode varchar(50),
	EmployeeCode varchar(15),
	IDate datetime default getdate(),
	QLThai nvarchar(150),
	TiemUV nvarchar(150),
	KT3Lan bit,
	KT4Lan bit,
	XNHIVMangThai nvarchar(200),
	XNHIVChuyenDa nvarchar(200),
	SLDeDuThang int,
	SLDeNon int,
	SLPhaThai int,
	SLConHienTai int,
	CachThucDe nvarchar(200),
	TaiBienMac int,
	TaiBienTV int,
	CanNang nvarchar(15),
	GioiTinh int,
	TinhTrangCon nvarchar(200),
	TVThaiNhi nvarchar(200),
	NguoiDoDe nvarchar(200),
	BuGioDau varchar(10),
	TiemViataminK1 bit,
	TiemVXViemGanB bit,
	KhamTuanDau nvarchar(200),
	KhamSauDe nvarchar(200),
	GhiChu nvarchar(200),
	WorkDate datetime
	CONSTRAINT pk_MedicalRecord_Childbirth PRIMARY KEY(MedicalRecordCode)
)
go
if exists(select name from sysobjects where name ='proIns_MedicalRecord_Childbirth')
	drop procedure proIns_MedicalRecord_Childbirth
go
create procedure proIns_MedicalRecord_Childbirth
(
	@MedicalRecordCode varchar(50),
	@EmployeeCode varchar(15),
	@QLThai nvarchar(150),
	@TiemUV nvarchar(150),
	@KT3Lan bit,
	@KT4Lan bit,
	@XNHIVMangThai nvarchar(200),
	@XNHIVChuyenDa nvarchar(200),
	@SLDeDuThang int,
	@SLDeNon int,
	@SLPhaThai int,
	@SLConHienTai int,
	@CachThucDe nvarchar(200),
	@TaiBienMac int,
	@TaiBienTV int,
	@CanNang nvarchar(15),
	@GioiTinh int,
	@TinhTrangCon nvarchar(200),
	@TVThaiNhi nvarchar(200),
	@NguoiDoDe nvarchar(200),
	@BuGioDau varchar(10),
	@TiemViataminK1 bit,
	@TiemVXViemGanB bit,
	@KhamTuanDau nvarchar(200),
	@KhamSauDe nvarchar(200),
	@GhiChu nvarchar(200),
	@WorkDate datetime
)
as
begin
	if exists(select MedicalRecordCode from MedicalRecord_Childbirth where MedicalRecordCode=@MedicalRecordCode)
		update MedicalRecord_Childbirth set EmployeeCode=@EmployeeCode,QLThai=@QLThai,TiemUV=@TiemUV,KT3Lan=@KT3Lan,KT4Lan=@KT4Lan,XNHIVMangThai=@XNHIVMangThai,XNHIVChuyenDa=@XNHIVChuyenDa,SLDeDuThang=@SLDeDuThang,
		SLDeNon=@SLDeNon,SLPhaThai=@SLPhaThai,SLConHienTai=@SLConHienTai,CachThucDe=@CachThucDe,TaiBienMac=@TaiBienMac,TaiBienTV=@TaiBienTV,CanNang=@CanNang,GioiTinh=@GioiTinh,TinhTrangCon=@TinhTrangCon,TVThaiNhi=@TVThaiNhi,
		NguoiDoDe=@NguoiDoDe,BuGioDau=@BuGioDau,TiemViataminK1=@TiemViataminK1,TiemVXViemGanB=@TiemVXViemGanB,KhamTuanDau=@KhamTuanDau,KhamSauDe=@KhamSauDe,GhiChu=@GhiChu,WorkDate=@WorkDate
		where MedicalRecordCode=@MedicalRecordCode
	else
	begin
		insert into MedicalRecord_Childbirth(MedicalRecordCode,EmployeeCode,QLThai,TiemUV,KT3Lan,KT4Lan,XNHIVMangThai,XNHIVChuyenDa,SLDeDuThang,SLDeNon,SLPhaThai,SLConHienTai,CachThucDe,TaiBienMac,TaiBienTV,CanNang,GioiTinh,TinhTrangCon,TVThaiNhi,NguoiDoDe,BuGioDau,TiemViataminK1,TiemVXViemGanB,KhamTuanDau,KhamSauDe,GhiChu,WorkDate) 
		values(@MedicalRecordCode,@EmployeeCode,@QLThai,@TiemUV,@KT3Lan,@KT4Lan,@XNHIVMangThai,@XNHIVChuyenDa,@SLDeDuThang,@SLDeNon,@SLPhaThai,@SLConHienTai,@CachThucDe,@TaiBienMac,@TaiBienTV,@CanNang,@GioiTinh,@TinhTrangCon,@TVThaiNhi,@NguoiDoDe,@BuGioDau,@TiemViataminK1,@TiemVXViemGanB,@KhamTuanDau,@KhamSauDe,@GhiChu,@WorkDate)
	end
end
go
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'MedicalRecord_Abortions') AND type in (N'U'))
CREATE TABLE MedicalRecord_Abortions
(
	MedicalRecordCode varchar(50),
	EmployeeCode varchar(15),
	IDate datetime default getdate(),
	TTHonNhan bit,
	SoConHienCo int,
	NgayKinhCuoiCung char(10),
	ChuanDoanThai nvarchar(200),
	PPPhaThai nvarchar(200),
	KetQuaSoiMo nvarchar(200),
	TaiBienMac bit,
	TaiBienChet bit,
	KhamLai nvarchar(100),
	GhiChu nvarchar(200),
	WorkDate datetime
	CONSTRAINT pk_MedicalRecord_Abortions PRIMARY KEY(MedicalRecordCode)
)
go
if exists(select name from sysobjects where name ='proIns_MedicalRecord_Abortions')
	drop procedure proIns_MedicalRecord_Abortions
go
create procedure proIns_MedicalRecord_Abortions
(
	@MedicalRecordCode varchar(50),
	@EmployeeCode varchar(15),
	@TTHonNhan bit,
	@SoConHienCo int,
	@NgayKinhCuoiCung char(10),
	@ChuanDoanThai nvarchar(200),
	@PPPhaThai nvarchar(200),
	@KetQuaSoiMo nvarchar(200),
	@TaiBienMac bit,
	@TaiBienChet bit,
	@KhamLai nvarchar(100),
	@GhiChu nvarchar(200),
	@WorkDate datetime
)
as
begin
	if exists(select MedicalRecordCode from MedicalRecord_Abortions where MedicalRecordCode=@MedicalRecordCode)
		update MedicalRecord_Abortions set EmployeeCode=@EmployeeCode,TTHonNhan=@TTHonNhan,SoConHienCo=@SoConHienCo,NgayKinhCuoiCung=@NgayKinhCuoiCung,ChuanDoanThai=@ChuanDoanThai,PPPhaThai=@PPPhaThai,KetQuaSoiMo=@KetQuaSoiMo,TaiBienMac=@TaiBienMac,TaiBienChet=@TaiBienChet,WorkDate=@WorkDate,KhamLai=@KhamLai,GhiChu=@GhiChu where MedicalRecordCode=@MedicalRecordCode
	else
	begin
		insert into MedicalRecord_Abortions(EmployeeCode,TTHonNhan,SoConHienCo,NgayKinhCuoiCung,ChuanDoanThai,PPPhaThai,KetQuaSoiMo,TaiBienMac,TaiBienChet,WorkDate,KhamLai,GhiChu,MedicalRecordCode) values(@EmployeeCode,@TTHonNhan,@SoConHienCo,@NgayKinhCuoiCung,@ChuanDoanThai,@PPPhaThai,@KetQuaSoiMo,@TaiBienMac,@TaiBienChet,@WorkDate,@KhamLai,@GhiChu,@MedicalRecordCode)
	end
end
go
if exists(select name from sysobjects where name='proView_ListMedicalRecord_Childbirth')
	drop procedure proView_ListMedicalRecord_Childbirth
go
create procedure proView_ListMedicalRecord_Childbirth
(
	@FromDate char(10),
	@ToDate char(10)
)
as
	begin
		select ROW_NUMBER() OVER(ORDER BY CONVERT(date,a.iDate,103) DESC) as STT, CONVERT(date,a.iDate,103)iDate, d.PatientName,d.PatientAge,'' BHYT,
		[dbo].func_PatientOfAddressFull(d.PatientAddress,b1.WardName,c1.DistrictName,d1.ProvincialName) PatientAddress, f.CareerName ,e.EThnicName,
		a.QLThai,a.TiemUV, (case when a.KT3Lan = 1 then N'Có' else N'Không'end) KT3Lan,(case when a.KT4Lan = 1 then N'Có' else N'Không'end) KT4Lan,
		a.XNHIVMangThai,a.XNHIVChuyenDa,a.SLDeDuThang,a.SLDeNon,a.SLPhaThai,a.SLConHienTai,a.CachThucDe,(case when a.TaiBienMac = 1 then N'Có' else N'Không'end)TaiBienMac, 
		(case when a.TaiBienTV = 1 then N'Có' else N'Không'end) TaiBienTV, (case when a.GioiTinh = 0 then a.CanNang else '' end) GioiTinhNu,
		(case when a.GioiTinh = 1 then a.CanNang else '' end) GioiTinhNam,a.TinhTrangCon,a.TVThaiNhi,a.NguoiDoDe,a.BuGioDau,
		(case when a.TiemViataminK1 = 1 then N'Có' else N'Không'end) TiemViataminK1,(case when a.TiemVXViemGanB = 1 then N'Có' else N'Không'end) TiemVXViemGanB,
		a.KhamTuanDau,a.KhamSauDe,a.GhiChu
		from MedicalRecord_Childbirth a inner join MedicalRecord b on a.MedicalRecordCode=b.MedicalRecordCode inner join PatientReceive c on b.PatientReceiveID=c.PatientReceiveID
		inner join Patients d on c.PatientCode=d.PatientCode left join Catalog_Ward b1 on d.WardCode=b1.WardCode left join Catalog_District c1 on d.DistrictCode=c1.DistrictCode left join Catalog_Provincial d1 on d.ProvincialCode=d1.ProvincialCode 
		inner join Catalog_EThnic e on e.EThnicID=c.EThnicID inner join Career f on d.CareerCode=f.CareerCode inner join Employee a1 on a1.EmployeeCode=a.EmployeeCode
		where CONVERT(date,a.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
	end
go
if exists(select name from sysobjects where name='proView_ListMedicalRecord_Abortions')
	drop procedure proView_ListMedicalRecord_Abortions
go
create procedure proView_ListMedicalRecord_Abortions
(
	@FromDate char(10),
	@ToDate char(10)
)
as
	begin
	select ROW_NUMBER() OVER(ORDER BY CONVERT(date,a.iDate,103) DESC) as STT, CONVERT(date,a.iDate,103)iDate, d.PatientName,d.PatientAge,
	[dbo].func_PatientOfAddressFull(d.PatientAddress,b1.WardName,c1.DistrictName,d1.ProvincialName) PatientAddress, f.CareerName ,e.EThnicName,
	(case when a.TTHonNhan = 1 then N'Độc thân' else N'Có gia đình'end) TTHonNhan,a.SoConHienCo,a.NgayKinhCuoiCung,a.ChuanDoanThai,a.PPPhaThai,a.KetQuaSoiMo,  
	(case when a.TaiBienMac = 1 then N'Có' else N'Không'end) TaiBienMac,(case when a.TaiBienChet = 1 then N'Có' else N'Không'end) TaiBienChet ,a1.EmployeeName,a.KhamLai,a.GhiChu
	from MedicalRecord_Abortions a inner join MedicalRecord b on a.MedicalRecordCode=b.MedicalRecordCode inner join PatientReceive c on b.PatientReceiveID=c.PatientReceiveID
	inner join Patients d on c.PatientCode=d.PatientCode left join Catalog_Ward b1 on d.WardCode=b1.WardCode left join Catalog_District c1 on d.DistrictCode=c1.DistrictCode left join Catalog_Provincial d1 on d.ProvincialCode=d1.ProvincialCode 
	inner join Catalog_EThnic e on e.EThnicID=c.EThnicID left join Career f on d.CareerCode=f.CareerCode inner join Employee a1 on a1.EmployeeCode=a.EmployeeCode
	where CONVERT(date,a.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
	end
go
if exists(select name from sysobjects where name ='proView_TotalSuggested' and type='P')
	drop procedure proView_TotalSuggested
go
create procedure proView_TotalSuggested
(
	@FromDate date,
	@ToDate date,
	@ServiceCode varchar(2000),
	@DepartmentCode varchar(200)
)
as
begin tran
	declare @TableLimitServices table(ServiceCode varchar(15))
	declare @TableLimitDepartment table(DepartmentCode varchar(15))
	insert into @TableLimitServices(ServiceCode)(select ServiceCode from Service where ServiceCode in(select * from dbo.fnSplitString(@ServiceCode,',')))
	if len(@DepartmentCode)>0
		insert into @TableLimitDepartment(DepartmentCode)(select DepartmentCode from Department where DepartmentCode in(select * from dbo.fnSplitString(@DepartmentCode,',')));
	else
		insert into @TableLimitDepartment(DepartmentCode)(select DepartmentCode from Department where Hide=0);
	select sum(a.Quantity) TotalQuantity
		from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b1.ServiceGroupCode=b2.ServiceGroupCode
		where CONVERT(date,a.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) 
		--and a.Status=1 
		and a.Paid =1
		and a.ServiceCode in(select * from @TableLimitServices)
		and a.DepartmentCodeOrder in(select * from @TableLimitDepartment)
commit tran
go
