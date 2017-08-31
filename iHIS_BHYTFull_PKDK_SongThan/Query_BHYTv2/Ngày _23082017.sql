--Ngày 23/08/2017
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MedicinesForPatients_Receive')
begin
CREATE TABLE MedicinesForPatients_Receive
(
	RowID decimal(22,0) identity(1,1),
	PatientCode varchar(15),
	PatientReceiveID decimal(22,0),
	ReferenceCode varchar(25),
	IDate datetime not null default getdate(),
	EmployeeCode varchar(15) not null,
	ItemCode varchar(15),
	RepositoryCode varchar(15),
	Quantity decimal(8,4) not null default 0,
	Quantity_Receive decimal(8,4) not null default 0,
	WorkDate_Receive datetime,
	Note nvarchar(250),
	RowIDMedicine decimal(22,0) not null default 0,
	CONSTRAINT pk_MedicinesForPatients_Receive PRIMARY KEY (RowID)
)
end

go

ALTER procedure [dbo].[prDel_PhieuThuTien]
(
	@iresult int output,
	@RowID numeric(18, 0),
	@ReceiveID numeric(18, 0),
	@PatientCode varchar(50),
	@ServiceCode varchar(50)
)
as
begin
	if exists(select ReceiptID from SuggestedServiceReceipt where ReceiptID=@RowID and PatientCode=@PatientCode and ServiceCode=@ServiceCode and RefID=@ReceiveID)
	begin
		if exists(select ReceiptID from SuggestedServiceReceipt where ReceiptID=@RowID and PatientCode=@PatientCode and ServiceCode=@ServiceCode and RefID=@ReceiveID and  Status=0 AND Paid=0)
			begin 
				delete from SuggestedServiceReceipt where ReceiptID=@RowID and PatientCode=@PatientCode and ServiceCode=@ServiceCode and RefID=@ReceiveID and  Status=0 AND Paid=0
				set @iresult =1
			end
		else
		begin
			set @iresult =-1
		end
	end
	else
		set @iresult =-2
end


GO
alter procedure [dbo].[prDel_Thuoc]
(
	@iresult int output,
	@RowID numeric(18, 0),
	@MedicalRecordCode varchar(50),
	@ItemCode varchar(50)
)
as
begin
	if exists(select RowID from MedicinesForPatientsDetail where MedicalRecordCode=@MedicalRecordCode and ItemCode=@ItemCode)
	begin
		if exists(select MD.RowID from MedicinesForPatientsDetail MD, MedicinesForPatients MP where MD.MedicalRecordCode=@MedicalRecordCode and MD.MedicalRecordCode=MP.MedicalRecordCode and MD.ItemCode=@ItemCode and MD.Paid=0 and MP.Done=0)
			begin 
				delete from MedicinesForPatientsDetail where MedicalRecordCode=@MedicalRecordCode and ItemCode=@ItemCode and Paid=0
				set @iresult = 1
					update MedicalPrescriptionDetail set Status=0 where MedicalRecordCode=@MedicalRecordCode and ItemCode=@ItemCode
				if not exists (select ItemCode from MedicalPrescriptionDetail where MedicalRecordCode=@MedicalRecordCode and Status=1)
					update MedicalRecord set Status=0 where MedicalRecordCode=@MedicalRecordCode
				if not exists(select MD.RowID from MedicinesForPatientsDetail MD, MedicinesForPatients MP where MD.MedicalRecordCode=@MedicalRecordCode and MD.MedicalRecordCode=MP.MedicalRecordCode)
					delete from MedicinesForPatients where MedicalRecordCode=@MedicalRecordCode
			end
		else
		begin
			set @iresult =-1
		end
	end
	else
	begin
		set @iresult =-2
	end
end


go


go
ALTER TABLE Items ADD Is_Acttach_Service int;
go
ALTER TABLE Items ADD Is_Service_Auto int;

go 
update Items set Is_Acttach_Service = 0

go 
update Items set Is_Service_Auto = 0
Go
Go
drop table Attach_Service
go
create table Attach_Service(
	RowID int Identity(1,1) Primary key,
	AttachServiceCode varchar(50) ,
	--ServiceGroupCode varchar(50),
	--ServiceCategoryCode varchar(50),
	ItemCode nvarchar(50),
	ObjectCode int,
	IDate datetime,
	Quantity int,
	EmployeeCode varchar(50),
	STT int,
	Note nvarchar(300)
	CONSTRAINT FR1 FOREIGN KEY (ItemCode) REFERENCES Items(ItemCode)
)
go

ALTER TABLE Attach_Service ADD Is_Service_Auto int;

go 
update Attach_Service set Is_Service_Auto = 0

go
drop proc proIU_Attach_Service
go
Create procedure [dbo].[proIU_Attach_Service]
(
	@RowID int,
	@AttachServiceCode varchar(50),
	@ItemCode nvarchar(50),
	@ObjectCode int,
	@IDate datetime,
	@Quantity int,
	@EmployeeCode varchar(50),
	@STT int,
	@Note nvarchar(300),
	@Is_Service_Auto int
)
as
begin 
	
	if not exists(select ItemCode from Attach_Service where AttachServiceCode=@AttachServiceCode and ItemCode=@ItemCode)
		insert into Attach_Service(AttachServiceCode,ItemCode,ObjectCode,IDate,Quantity,EmployeeCode,STT,Note,Is_Service_Auto) values(@AttachServiceCode,@ItemCode,@ObjectCode,@IDate,@Quantity,@EmployeeCode,@STT,@Note,@Is_Service_Auto)
	else
		update Attach_Service set AttachServiceCode=@AttachServiceCode,ObjectCode=@ObjectCode,Quantity=@Quantity,EmployeeCode=@EmployeeCode,STT=@STT,Note=@Note,IDate=@IDate,Is_Service_Auto=@Is_Service_Auto where AttachServiceCode=@AttachServiceCode and ItemCode=@ItemCode
end
go
drop proc proList_Items
GO
Create procedure [dbo].[proList_Items]
(
	@ItemCode varchar(50)
)
as
begin
	select a.AttachServiceCode,s.ServiceName,a.ItemCode,a.ObjectCode,isnull(a.Quantity,1) Quantity  from Attach_Service a inner join Service  s  on a.AttachServiceCode=s.ServiceCode inner join Items i on a.ItemCode = i.ItemCode
	where a.ItemCode=@ItemCode and a.Is_Service_Auto=0 and i.Is_Acttach_Service=1
end
go
drop proc proList_Items_Auto
go
Create procedure [dbo].[proList_Items_Auto]
(
	@ItemCode varchar(50)
)
as
begin
	select a.AttachServiceCode,s.ServiceName,a.ItemCode,a.ObjectCode,isnull(a.Quantity,1) Quantity from Attach_Service a inner join Service  s  on a.AttachServiceCode=s.ServiceCode inner join Items i on a.ItemCode = i.ItemCode
	where a.ItemCode=@ItemCode and a.Is_Service_Auto=1 and i.Is_Acttach_Service=1
end
go
drop proc pro_LayGia
go
Create procedure [dbo].[pro_LayGia]
(
	@ServiceCode varchar(50)
)
as
begin
	select RowID,UnitPrice from ServicePrice where ServiceCode=@ServiceCode
end

go

ALTER procedure [dbo].[pro_ReportDailyInvoice]
(
	@StartDate datetime,
	@EndDate datetime,
	@Cancel int=0
)
as
begin
	select ROW_NUMBER() OVER(ORDER BY a.BanksAccountCode DESC) AS RowNumber, 
	b.PatientCode
	,b.PatientName
	,(case when b.PatientGender=1 then N'Nam' else N'N?' end)PatientGenderName
	,b.PatientBirthyear
	,a3.ObjectName
	,CONVERT(date,a.PostingDate,103) PostingDate
	,a.NoInvoice
	,(case when a.ShiftWork='AM' then N'Ca 1' when a.ShiftWork='PM' then N'Ca 2' when a.ShiftWork='EV' then N'Ca 3' else '' end) ShiftWork
	,a1.EmployeeName
	,a2.EmployeeName CashierName
	,a.TotalReal
	,[dbo].func_PatientOfAddressFull(c.Address,c1.WardName,c2.DistrictName,c3.ProvincialName) PatientAddress
	,a4.EmployeeName EmployeeNameCancel
	,a.CancelDate
	,a.BanksAccountCode
	,a.ReferenceCode
	,a.ObjectCode
	,a.ReasonCancel
	,a.TotalAmount
	,a.Exemptions
	,a.TotalBHYTPay
	,a.BHYTPay
	,a.TotalSurcharge
	,a.PatientPay
	,convert(char(5),a.PostingDate,108) PostingTime
	,a.TotalBHYTPay-a.BHYTPay as DifferentPay
	, a.TotalBHYTPay
	from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode left join Employee a1 on a.EmployeeCode=a1.EmployeeCode left join Employee a2 on a.CashierCode=a2.EmployeeCode
	inner join Object a3 on a.ObjectCode=a3.ObjectCode inner join PatientReceive c on a.ReferenceCode=c.PatientReceiveID left join Employee a4 on a.EmployeeCodeCancel=a4.EmployeeCode
	left join Catalog_Ward c1 on c.WardCode=c1.WardCode left join Catalog_District c2 on c.DistrictCode=c2.DistrictCode left join Catalog_Provincial c3 on c.ProvincialCode=c3.ProvincialCode
	where CONVERT(date,a.PostingDate ,103)between CONVERT(date,@StartDate,103) and CONVERT(date,@EndDate,103) and a.Cancel=0
	--order by a.PostingDate,a.NoInvoice
	union all
	
	select '0' RowNumber
	,b.PatientCode
	,b.PatientName,
	(case when b.PatientGender=1 then N'Nam' else N'N?' end)PatientGenderName
	,b.PatientBirthyear
	,a3.ObjectName,
	CONVERT(date,a.WorkingDateOrder,103) PostingDate
	,''as NoInvoice
	,'' as ShiftWork
	,a1.EmployeeName
	,a2.EmployeeName CashierName
	,a.AmountReal as TotalReal 
	,[dbo].func_PatientOfAddressFull(c.Address,c1.WardName,c2.DistrictName,c3.ProvincialName) PatientAddress
	,null as EmployeeNameCancel
	,null as CancelDate
	,a.BanksAccountCode
	,a.PatientReceiveID as ReferenceCode
	,a.ObjectCode
	,null as ReasonCancel
	,a.AmountOrder as TotalAmount
	,0 as Exemptions
	,null as TotalBHYTPay
	,'0' as BHYTPay
	,'0' as TotalSurcharge
	,'0' as PatientPay
	,convert(char(5),a.WorkingDateOrder,108) PostingTime
	,null as DifferentPay
	,null as TotalBHYTPay  
	from Fee_Advance_Payment a  inner join  Patients b  on a.PatientCode = b.PatientCode inner join Object a3 on a.ObjectCode= a3.ObjectCode left join Employee a1 on a.EmployeeCode=a1.EmployeeCode left join Employee a2 on a.EmployeeCodeOrder=a2.EmployeeCode
	 inner join PatientReceive c on a.PatientReceiveID=c.PatientReceiveID left join Catalog_Ward c1 on c.WardCode=c1.WardCode left join Catalog_District c2 on c.DistrictCode=c2.DistrictCode left join Catalog_Provincial c3 on c.ProvincialCode=c3.ProvincialCode
	 where CONVERT(date,a.WorkingDateOrder,103) between CONVERT(date,@StartDate,103) and CONVERT(date,@EndDate,103) and a.Paid=0
end

go
ALTER procedure [dbo].[proWaitingForPayMent]
(
	@DateFrom char(10),
	@DateTo char(10)
)
as
begin
	select b.PatientReceiveID,b.PatientCode,a.PatientName,(case when a.PatientGender=0 then N'N?' else 'Nam' end) GenderName,a.PatientBirthyear,c.ObjectName,b.CreateDate
	from Patients a inner join (
	select a.PatientReceiveID,a.PatientCode,a.ObjectCode,convert(char(10),a.CreateDate,103) CreateDate
	from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID 
	where b.Paid=0 and (b.BanksAccountCode is null or b.BanksAccountCode='') and b.ServicePrice>0 and b.ObjectCode <>5 and 
	CONVERT(date,b.WorkDate,103) between CONVERT(date,@DateFrom,103) and  CONVERT(date,@DateTo,103)
	group by a.PatientReceiveID,a.PatientCode,a.ObjectCode,convert(char(10),a.CreateDate,103)
	) b on a.PatientCode=b.PatientCode inner join Object c on b.ObjectCode=c.ObjectCode
	union
	select b.PatientReceiveID,b.PatientCode,a.PatientName,(case when a.PatientGender=0 then N'N?' else 'Nam' end) GenderName,a.PatientBirthyear,c.ObjectName,b.CreateDate
	from Patients a inner join (
	select a.PatientReceiveID,a.PatientCode,a.ObjectCode,convert(char(10),a.CreateDate,103) CreateDate
	from PatientReceive a inner join MedicinesForPatients b on a.PatientReceiveID=b.PatientReceiveID inner join MedicinesForPatientsDetail b1 on b.RowID=b1.RowIDMedicines
	where b1.Paid=0 and (b1.BanksAccountCode is null or b1.BanksAccountCode='') and b1.ObjectCode <>5 
	and CONVERT(date,b.DateApproved,103) between CONVERT(date,@DateFrom,103) and  CONVERT(date,@DateTo,103)
	group by a.PatientReceiveID,a.PatientCode,a.ObjectCode,convert(char(10),a.CreateDate,103)) b on a.PatientCode=b.PatientCode inner join Object c on b.ObjectCode=c.ObjectCode
	
end


go


ALTER procedure [dbo].[pro_Ins_Items]
(
	@ItemCode varchar(50),
	@ItemName nvarchar(max),
	@Active nvarchar(max),
	@UsageCode varchar(50),
	@UnitOfMeasureCode varchar(50),
	@ItemCategoryCode varchar(50),
	@UnitPrice numeric(18, 3),
	@Status int,
	@SalesPrice numeric(18, 3),
	@SafelyQuantity int,
	@RepositoryCode nvarchar(250),
	@udate datetime,
	@EmployeeCode varchar(50),
	@BHYTPrice numeric(18, 3),
	@ListBHYT int,
	@RateBHYT int,
	@CountryCode varchar(6),
	@ProducerCode varchar(50),
	@Note nvarchar(100),
	@DisparityPrice numeric(18,4),
	@ListService int=0,
	@VendorCode varchar(200),
	@Packed nvarchar(50),
	@QtyOfMeasure int,
	@ItemContent nvarchar(50),
	@STTBCBHYT varchar(50),
	@SODKGP varchar(50),
	@STTQDPK varchar(50),
	@QUYCACH nvarchar(max),
	@Generic_BD char(1),
	@VENCode char(1),
	@Active_TT40 varchar(20)='',
	@SalesPrice_Retail decimal(18,4)=0,
	@UnitOfMeasureCode_Medi varchar(15)='',
	@Converted_Medi bit=1,
	@Is_Acttach_Service int,
	@Is_Service_Auto int
)
as
begin
	if exists(select ItemCode from Items where ItemCode=@ItemCode)
		begin		
			update Items set ItemName=@ItemName,Active=@Active,UsageCode=@UsageCode,UnitOfMeasureCode=@UnitOfMeasureCode,ItemCategoryCode=@ItemCategoryCode,UnitPrice=@UnitPrice,[Status]=@Status,SalesPrice=@SalesPrice,SafelyQuantity=@SafelyQuantity,RepositoryCode=@RepositoryCode,idate=GETDATE(),
			BHYTPrice=@BHYTPrice,ListBHYT=@ListBHYT,RateBHYT=@RateBHYT,CountryCode=@CountryCode,ProducerCode=@ProducerCode,Note=@Note,DisparityPrice=@DisparityPrice,ListService=@ListService,VendorCode=@VendorCode,Packed=@Packed,QtyOfMeasure=@QtyOfMeasure,ItemContent=@ItemContent,STTBCBHYT=@STTBCBHYT,
			SODKGP=@SODKGP,STTQDPK=@STTQDPK,QUYCACH=@QUYCACH,Generic_BD=@Generic_BD,VENCode=@VENCode,Active_TT40=@Active_TT40,SalesPrice_Retail=@SalesPrice_Retail,UnitOfMeasureCode_Medi=@UnitOfMeasureCode_Medi,Converted_Medi=@Converted_Medi ,
			Is_Acttach_Service=@Is_Acttach_Service , Is_Service_Auto=@Is_Service_Auto
			where ItemCode=@ItemCode
		end
	else
	begin
		declare @_ItemCode varchar(50)
		declare @_stt decimal(8,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(ItemCode,6)) maxcode from Items order by CONVERT(decimal(18,0),RIGHT(ItemCode,6)) desc)+1
		if(@_stt<=9)
			begin
				set @_ItemCode = 'TH00000'+convert(varchar(5),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_ItemCode = 'TH0000'+convert(varchar(6),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_ItemCode = 'TH000'+convert(varchar(6),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_ItemCode = 'TH00'+convert(varchar(6),@_stt)
			end
		else if(@_stt>9999 and @_stt<=99999)
			begin
				set @_ItemCode = 'TH0'+convert(varchar(6),@_stt)
			end
		else if(@_stt>99999 and @_stt<=999999)
			begin
				set @_ItemCode = 'TH'+convert(varchar(6),@_stt)
			end
		else
			begin
				set @_ItemCode = 'TH000001'
			end
		insert into Items(ItemCode,ItemName,Active,UsageCode,UnitOfMeasureCode,ItemCategoryCode,UnitPrice,Status,SalesPrice,SafelyQuantity,RepositoryCode,idate,udate,EmployeeCode,BHYTPrice,ListBHYT,RateBHYT,CountryCode,ProducerCode,Note,DisparityPrice,ListService,VendorCode,Packed,QtyOfMeasure,ItemContent,STTBCBHYT,SODKGP,STTQDPK,QUYCACH,Generic_BD,VENCode,Active_TT40,SalesPrice_Retail,UnitOfMeasureCode_Medi,Converted_Medi,Is_Acttach_Service , Is_Service_Auto) 
		values(@_ItemCode,@ItemName,@Active,@UsageCode,@UnitOfMeasureCode,@ItemCategoryCode,@UnitPrice,@Status,@SalesPrice,@SafelyQuantity,@RepositoryCode,GETDATE(),@udate,@EmployeeCode,@BHYTPrice,@ListBHYT,@RateBHYT,@CountryCode,@ProducerCode,@Note,@DisparityPrice,@ListService,@VendorCode,@Packed,@QtyOfMeasure,@ItemContent,@STTBCBHYT,@SODKGP,@STTQDPK,@QUYCACH,@Generic_BD,@VENCode,@Active_TT40,@SalesPrice_Retail,@UnitOfMeasureCode_Medi,@Converted_Medi,@Is_Acttach_Service , @Is_Service_Auto)
	end
end

go

ALTER procedure [dbo].[proView_StatisticBankTotal]
(
	@FromDate date,
	@ToDate date,
	@ServiceCategoryCode varchar(300),
	@ServiceGroupCode varchar(15),
	@ServiceCode varchar(1000)=''
)
as
begin
	
	declare @TableGroup table(ServiceGroupCode varchar(15))
	declare @TableCategory table(ServiceCategoryCode varchar(15))
	declare @TableLimitServices table(ServiceCode varchar(15))
	declare @CountLimit int =0
	if LEN(@ServiceGroupCode)>0
		insert into @TableGroup(ServiceGroupCode)(select ServiceGroupCode from ServiceGroup where ServiceGroupCode in(select * from dbo.fnSplitString(@ServiceGroupCode,',')))
	else
		insert into @TableGroup(ServiceGroupCode)(select ServiceGroupCode from ServiceGroup)
	if LEN(@ServiceCategoryCode)>0
		insert into @TableCategory(ServiceCategoryCode)(select ServiceCategoryCode from ServiceCategory where ServiceCategoryCode in(select * from dbo.fnSplitString(@ServiceCategoryCode,',')))
	else
		insert into @TableCategory(ServiceCategoryCode)(select ServiceCategoryCode from ServiceCategory where ServiceGroupCode in(select ServiceGroupCode from @TableGroup))
	if LEN(@ServiceCode)>0
		insert into @TableLimitServices(ServiceCode)(select ServiceCode from [Service] where ServiceCode in(select * from dbo.fnSplitString(@ServiceCode,',')))
	else
		insert into @TableLimitServices(ServiceCode)(select ServiceCode from [Service] where ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory))

	 select a.PatientCode,a.ReferenceCode,CONVERT(date,a.PostingDate,103) PostingDate,convert(date,a.PostingDate,108)  PostingTime,SUM(a1.Quantity * a1.ServicePrice) Amount,b.PatientName,
		b.PatientBirthyear,b.PatientBirthday,b.PatientAddress, (case when b.PatientGender=0 then N'N?' else 'Nam' end ) PatientGenderName,a5.ServiceModuleName GroupName,a5.ServiceModuleCode,SUM(a1.Quantity * a1.DisparityPrice) DisparityPrice
		from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode inner join BanksAccountDetail a1 on a.BanksAccountCode=a1.BanksAccountCode
		inner join Service a2 on a1.ServiceCode=a2.ServiceCode inner join ServiceCategory a3 on a2.ServiceCategoryCode=a3.ServiceCategoryCode
		inner join ServiceGroup a4 on a3.ServiceGroupCode=a4.ServiceGroupCode inner join ServiceModule a5 on a4.ServiceModuleCode=a5.ServiceModuleCode inner join PatientReceive a6 on a.ReferenceCode=a6.PatientReceiveID
		where a.Cancel=0 and convert(date,a.PostingDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103)  
		and a2.ServiceCode in (select ServiceCode from @TableLimitServices)
		and a2.ServiceCategoryCode in(select * from @TableCategory) and a3.ServiceGroupCode in(select * from @TableGroup)
		group by a.PatientCode,a.ReferenceCode,a.PostingDate,b.PatientName,b.PatientBirthyear,b.PatientBirthday,b.PatientAddress,b.PatientGender,a5.ServiceModuleName,a5.ServiceModuleCode
	union all
	select a.PatientCode,a.ReferenceCode,CONVERT(date,a.PostingDate,103) PostingDate,convert(date,a.PostingDate,108)  PostingTime,SUM(a1.Quantity * a1.ServicePrice) Amount,b.PatientName,
		b.PatientBirthyear,b.PatientBirthday,b.PatientAddress, (case when b.PatientGender=0 then N'N?' else 'Nam' end ) PatientGenderName,a5.ServiceModuleName GroupName,a5.ServiceModuleCode,SUM(a1.Quantity * a1.DisparityPrice) DisparityPrice
		from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode inner join BanksAccountDetail a1 on a.BanksAccountCode=a1.BanksAccountCode
		inner join Items a2 on a1.ServiceCode=a2.ItemCode inner join ItemCategory a3 on a2.ItemCategoryCode=a3.ItemCategoryCode
		inner join ItemGroup a4 on a3.GroupCode=a4.GroupCode inner join ServiceModule a5 on a4.ServiceModuleCode=a5.ServiceModuleCode inner join PatientReceive a6 on a.ReferenceCode=a6.PatientReceiveID
		where a.Cancel=0 and convert(date,a.PostingDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103)  
		--and a2.ServiceCode in (select ServiceCode from @TableLimitServices)
		--and a2.ServiceCategoryCode in(select * from @TableCategory) and a3.ServiceGroupCode in(select * from @TableGroup)
		group by a.PatientCode,a.ReferenceCode,a.PostingDate,b.PatientName,b.PatientBirthyear,b.PatientBirthday,b.PatientAddress,b.PatientGender,a5.ServiceModuleName,a5.ServiceModuleCode
	union all
	select a.RetailCode, a.PatientReceiveID ReferenceCode,CONVERT(date,a.ExportDate,103) PostingDate,convert(date,a.ExportDate,108)  PostingTime ,SUM(a1.Quantity * a1.UnitPrice) Amount,a.FullName,
		a.Birthyear,a.PatientBirthday,a.Address, (case when a.PatientGender=0 then N'N?' else 'Nam' end ) PatientGenderName,a5.ServiceModuleName GroupName,a5.ServiceModuleCode,0 as DisparityPrice
		from MedicinesRetail a  inner join MedicinesRetailDetail a1 on a.RetailCode=a1.RetailCode
		inner join Items a2 on a1.ItemCode=a2.ItemCode inner join ItemCategory a3 on a2.ItemCategoryCode=a3.ItemCategoryCode
		inner join ItemGroup a4 on a3.GroupCode=a4.GroupCode inner join ServiceModule a5 on a4.ServiceModuleCode=a5.ServiceModuleCode 
		where a.Paid=1 and convert(date,a.ExportDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103)
		group by a.PatientCode,a.RetailCode,a.ExportDate,a.FullName,a.Birthyear,a.PatientBirthday,a.PatientGender,a5.ServiceModuleName,a5.ServiceModuleCode,a.PatientReceiveID,a.Address
end

go

ALTER procedure [dbo].[pro_ReportDailyInvoice]
(
	@StartDate datetime,
	@EndDate datetime,
	@Cancel int=0
)
as
begin
	select ROW_NUMBER() OVER(ORDER BY a.BanksAccountCode DESC) AS RowNumber, 
	b.PatientCode
	,b.PatientName
	,(case when b.PatientGender=1 then N'Nam' else N'N?' end)PatientGenderName
	,b.PatientBirthyear
	,a3.ObjectName
	,CONVERT(date,a.PostingDate,103) PostingDate
	,a.NoInvoice
	,(case when a.ShiftWork='AM' then N'Ca 1' when a.ShiftWork='PM' then N'Ca 2' when a.ShiftWork='EV' then N'Ca 3' else '' end) ShiftWork
	,a1.EmployeeName
	,a2.EmployeeName CashierName
	,a.TotalReal
	,[dbo].func_PatientOfAddressFull(c.Address,c1.WardName,c2.DistrictName,c3.ProvincialName) PatientAddress
	,a4.EmployeeName EmployeeNameCancel
	,a.CancelDate
	,a.BanksAccountCode
	,a.ReferenceCode
	,a.ObjectCode
	,a.ReasonCancel
	,a.TotalAmount
	,a.Exemptions
	,a.TotalBHYTPay
	,a.BHYTPay
	,a.TotalSurcharge
	,a.PatientPay
	,convert(char(5),a.PostingDate,108) PostingTime
	,a.TotalBHYTPay-a.BHYTPay as DifferentPay
	, a.TotalBHYTPay
	from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode left join Employee a1 on a.EmployeeCode=a1.EmployeeCode left join Employee a2 on a.CashierCode=a2.EmployeeCode
	inner join Object a3 on a.ObjectCode=a3.ObjectCode inner join PatientReceive c on a.ReferenceCode=c.PatientReceiveID left join Employee a4 on a.EmployeeCodeCancel=a4.EmployeeCode
	left join Catalog_Ward c1 on c.WardCode=c1.WardCode left join Catalog_District c2 on c.DistrictCode=c2.DistrictCode left join Catalog_Provincial c3 on c.ProvincialCode=c3.ProvincialCode
	where CONVERT(date,a.PostingDate ,103)between CONVERT(date,@StartDate,103) and CONVERT(date,@EndDate,103) and a.Cancel=0
	--order by a.PostingDate,a.NoInvoice
	union all
	
	select '0' RowNumber
	,b.PatientCode
	,b.PatientName,
	(case when b.PatientGender=1 then N'Nam' else N'N?' end)PatientGenderName
	,b.PatientBirthyear
	,a3.ObjectName,
	CONVERT(date,a.WorkingDateOrder,103) PostingDate
	,''as NoInvoice
	,'' as ShiftWork
	,a1.EmployeeName
	,a2.EmployeeName CashierName
	,a.AmountReal as TotalReal 
	,[dbo].func_PatientOfAddressFull(c.Address,c1.WardName,c2.DistrictName,c3.ProvincialName) PatientAddress
	,null as EmployeeNameCancel
	,null as CancelDate
	,a.BanksAccountCode
	,a.PatientReceiveID as ReferenceCode
	,a.ObjectCode
	,null as ReasonCancel
	,a.AmountOrder as TotalAmount
	,0 as Exemptions
	,null as TotalBHYTPay
	,'0' as BHYTPay
	,'0' as TotalSurcharge
	,'0' as PatientPay
	,convert(char(5),a.WorkingDateOrder,108) PostingTime
	,null as DifferentPay
	,null as TotalBHYTPay  
	from Fee_Advance_Payment a  inner join  Patients b  on a.PatientCode = b.PatientCode inner join Object a3 on a.ObjectCode= a3.ObjectCode left join Employee a1 on a.EmployeeCode=a1.EmployeeCode left join Employee a2 on a.EmployeeCodeOrder=a2.EmployeeCode
	 inner join PatientReceive c on a.PatientReceiveID=c.PatientReceiveID left join Catalog_Ward c1 on c.WardCode=c1.WardCode left join Catalog_District c2 on c.DistrictCode=c2.DistrictCode left join Catalog_Provincial c3 on c.ProvincialCode=c3.ProvincialCode
	 where CONVERT(date,a.WorkingDateOrder,103) between CONVERT(date,@StartDate,103) and CONVERT(date,@EndDate,103) and a.Paid=0
end

go
drop proc pro_Ins_MedicinesForPatients_Receive
go
create procedure [dbo].[pro_Ins_MedicinesForPatients_Receive]
(
	@PatientCode varchar(15),
	@PatientReceiveID decimal(22, 0),
	@ReferenceCode varchar(25),
	@IDate datetime,
	@EmployeeCode varchar(15),
	@ItemCode varchar(15),
	@RepositoryCode varchar(15),
	@Quantity decimal(8, 4),
	@Quantity_Receive decimal(8, 4),
	@WorkDate_Receive datetime,
	@Note nvarchar(250),
	@RowIDMedicine decimal(22, 0)
)
as
begin
	if exists(select ItemCode from MedicinesForPatients_Receive where ItemCode=@ItemCode and PatientReceiveID=@PatientReceiveID and RowIDMedicine=@RowIDMedicine)
	begin
		update MedicinesForPatients_Receive set PatientCode=@PatientCode, PatientReceiveID=@PatientReceiveID, ReferenceCode=@ReferenceCode, IDate=GETDATE(), EmployeeCode=@EmployeeCode, ItemCode=@ItemCode, RepositoryCode=@RepositoryCode, Quantity=@Quantity, Quantity_Receive=@Quantity_Receive,WorkDate_Receive=GETDATE(),Note=@Note,RowIDMedicine=@RowIDMedicine where ItemCode=@ItemCode and PatientReceiveID=@PatientReceiveID and RowIDMedicine=@RowIDMedicine
	end
	else
	begin		
		insert into MedicinesForPatients_Receive(PatientCode,PatientReceiveID,ReferenceCode,IDate,EmployeeCode,ItemCode,RepositoryCode,Quantity,Quantity_Receive,WorkDate_Receive,Note,RowIDMedicine) values(@PatientCode,@PatientReceiveID,@ReferenceCode,GETDATE(),@EmployeeCode,@ItemCode,@RepositoryCode,@Quantity,@Quantity_Receive,GETDATE(),@Note,@RowIDMedicine)
	end
end







