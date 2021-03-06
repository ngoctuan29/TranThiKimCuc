
IF NOT EXISTS (SELECT name FROM sys.objects WHERE object_id = OBJECT_ID(N'Inventory_Estimate') AND type in (N'U'))
CREATE TABLE Inventory_Estimate
(
	RowID varchar(20),
	ExpRepositoryCode varchar(15),
	ImpRepositoryCode varchar(15),
	EmployeeCode varchar(15),
	Note nvarchar(300),
	IDate datetime not null default getdate(),
	WorkDate datetime not null,
	Estimate_Code varchar(50)
	CONSTRAINT pk_Inventory_Estimate PRIMARY KEY(RowID)
)
go
IF NOT EXISTS (SELECT name FROM sys.objects WHERE object_id = OBJECT_ID(N'Inventory_Estimate_Detail') AND type in (N'U'))
CREATE TABLE Inventory_Estimate_Detail
(
	ItemCode varchar(50),
	RowID_Estimate varchar(20),
	QuantityExist numeric(18,4) not null,
	QuantityRequets numeric(18,4) not null,
	QuantityReal numeric(18,4) not null,
	CONSTRAINT pk_Inventory_Estimate_Detail PRIMARY KEY(ItemCode,RowID_Estimate),
	CONSTRAINT fk_Inventory_Estimate_Detail foreign key(RowID_Estimate) references Inventory_Estimate(RowID)
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
