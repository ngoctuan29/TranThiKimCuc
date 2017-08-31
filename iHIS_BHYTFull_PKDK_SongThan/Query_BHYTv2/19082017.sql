--19/08/2017



go
ALTER TABLE Items ADD Is_Acttach_Service int;
go
ALTER TABLE Items ADD Is_Service_Auto int;

go update Items set Is_Acttach_Service = 0

go update Items set Is_Service_Auto = 0
Go
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
go

ALTER TABLE Attach_Service ADD Is_Service_Auto int;

go update Attach_Service set Is_Service_Auto = 0

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






/****** Object:  StoredProcedure [dbo].[proList_Items]    Script Date: 19/08/02017 3:41:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[proList_Items]
(
	@ItemCode varchar(50)
)
as
begin
	if exists(select ItemCode from Items where ItemCode=@ItemCode and Is_Acttach_Service=1)
	select a.AttachServiceCode,s.ServiceName,a.ItemCode from Attach_Service a inner join Service  s  on a.AttachServiceCode=s.ServiceCode where ItemCode=@ItemCode and a.Is_Service_Auto=0
end


Create procedure [dbo].[proList_Items_Auto]
(
	@ItemCode varchar(50)
)
as
begin
	if exists(select ItemCode from Items where ItemCode=@ItemCode and Is_Acttach_Service=1)
	select a.AttachServiceCode,s.ServiceName,a.ItemCode from Attach_Service a inner join Service  s  on a.AttachServiceCode=s.ServiceCode where ItemCode=@ItemCode and a.Is_Service_Auto=1
end




Create procedure [dbo].[pro_LayGia]
(
	@ServiceCode varchar(50)
)
as
begin
	select RowID,UnitPrice from ServicePrice where ServiceCode=@ServiceCode
end



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