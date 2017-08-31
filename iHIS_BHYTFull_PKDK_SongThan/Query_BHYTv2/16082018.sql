USE [iHIS_SongThan]
GO
/****** Object:  StoredProcedure [dbo].[pro_ReportDailyInvoice]    Script Date: 12/08/02017 9:35:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	where CONVERT(date,a.PostingDate ,103)between CONVERT(date,'12/08/2017',103) and CONVERT(date,'12/08/2017',103) and a.Cancel=0
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
	 where CONVERT(date,a.WorkingDateOrder,103) between CONVERT(date,'12/08/2017',103) and CONVERT(date,'12/08/2017',103) and a.Paid=0
end


go
ALTER TABLE Items ADD Is_Acttach_Service int;
go
ALTER TABLE Items ADD Is_Service_Auto int;


Go
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
Go
ALTER procedure [dbo].[proIU_Attach_Service]
(
	@RowID int,
	@AttachServiceCode varchar(50),
	@ItemCode nvarchar(50),
	@ObjectCode int,
	@IDate datetime,
	@Quantity int,
	@EmployeeCode varchar(50),
	@STT int,
	@Note nvarchar(300)
)
as
begin 
	
	if exists(select ItemCode from Attach_Service where RowID=@RowID and ItemCode=@ItemCode)
		update Attach_Service set AttachServiceCode=@AttachServiceCode,ObjectCode=@ObjectCode,Quantity=@Quantity,EmployeeCode=@EmployeeCode,STT=@STT,Note=@Note,IDate=@IDate where RowID=@RowID and ItemCode=@ItemCode
	else
		insert into Attach_Service(AttachServiceCode,ItemCode,ObjectCode,IDate,Quantity,EmployeeCode,STT,Note) values(@AttachServiceCode,@ItemCode,@ObjectCode,@IDate,@Quantity,@EmployeeCode,@STT,@Note)
	
end

go
--15082017

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
ALTER procedure [dbo].[proList_Items]
(
	@ItemCode varchar(50)
)
as
begin
	if exists(select ItemCode from Items where ItemCode=@ItemCode and Is_Acttach_Service=1)
	select a.AttachServiceCode,s.ServiceName,a.ItemCode from Attach_Service a inner join Service  s  on a.AttachServiceCode=s.ServiceCode where ItemCode=@ItemCode
end

go

Alter procedure [dbo].[pro_LayGia]
(
	@ServiceCode varchar(50)
)
as
begin
	select RowID,UnitPrice from ServicePrice where ServiceCode=@ServiceCode
end 
