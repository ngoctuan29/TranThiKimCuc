-----18/08/2017
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
		b.PatientBirthyear,b.PatientBirthday,b.PatientAddress, (case when b.PatientGender=0 then N'N?' else 'Nam' end ) PatientGenderName,a5.ServiceModuleName GroupName,a5.ServiceModuleCode,a1.DisparityPrice
		from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode inner join BanksAccountDetail a1 on a.BanksAccountCode=a1.BanksAccountCode
		inner join Service a2 on a1.ServiceCode=a2.ServiceCode inner join ServiceCategory a3 on a2.ServiceCategoryCode=a3.ServiceCategoryCode
		inner join ServiceGroup a4 on a3.ServiceGroupCode=a4.ServiceGroupCode inner join ServiceModule a5 on a4.ServiceModuleCode=a5.ServiceModuleCode inner join PatientReceive a6 on a.ReferenceCode=a6.PatientReceiveID
		where a.Cancel=0 and convert(date,a.PostingDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103)  
		and a2.ServiceCode in (select ServiceCode from @TableLimitServices)
		and a2.ServiceCategoryCode in(select * from @TableCategory) and a3.ServiceGroupCode in(select * from @TableGroup)
		group by a.PatientCode,a.ReferenceCode,a.PostingDate,b.PatientName,b.PatientBirthyear,b.PatientBirthday,b.PatientAddress,b.PatientGender,a5.ServiceModuleName,a5.ServiceModuleCode,a1.DisparityPrice
	union all
	select a.PatientCode,a.ReferenceCode,CONVERT(date,a.PostingDate,103) PostingDate,convert(date,a.PostingDate,108)  PostingTime,SUM(a1.Quantity * a1.ServicePrice) Amount,b.PatientName,
		b.PatientBirthyear,b.PatientBirthday,b.PatientAddress, (case when b.PatientGender=0 then N'N?' else 'Nam' end ) PatientGenderName,a5.ServiceModuleName GroupName,a5.ServiceModuleCode,a1.DisparityPrice
		from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode inner join BanksAccountDetail a1 on a.BanksAccountCode=a1.BanksAccountCode
		inner join Items a2 on a1.ServiceCode=a2.ItemCode inner join ItemCategory a3 on a2.ItemCategoryCode=a3.ItemCategoryCode
		inner join ItemGroup a4 on a3.GroupCode=a4.GroupCode inner join ServiceModule a5 on a4.ServiceModuleCode=a5.ServiceModuleCode inner join PatientReceive a6 on a.ReferenceCode=a6.PatientReceiveID
		where a.Cancel=0 and convert(date,a.PostingDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103)  
		--and a2.ServiceCode in (select ServiceCode from @TableLimitServices)
		--and a2.ServiceCategoryCode in(select * from @TableCategory) and a3.ServiceGroupCode in(select * from @TableGroup)
		group by a.PatientCode,a.ReferenceCode,a.PostingDate,b.PatientName,b.PatientBirthyear,b.PatientBirthday,b.PatientAddress,b.PatientGender,a5.ServiceModuleName,a5.ServiceModuleCode,a1.DisparityPrice
	union all
	select a.RetailCode, a.PatientReceiveID ReferenceCode,CONVERT(date,a.ExportDate,103) PostingDate,convert(date,a.ExportDate,108)  PostingTime ,SUM(a1.Quantity * a1.UnitPrice) Amount,a.FullName,
		a.Birthyear,a.PatientBirthday,a.Address, (case when a.PatientGender=0 then N'N?' else 'Nam' end ) PatientGenderName,a5.ServiceModuleName GroupName,a5.ServiceModuleCode,0 as DisparityPrice
		from MedicinesRetail a  inner join MedicinesRetailDetail a1 on a.RetailCode=a1.RetailCode
		inner join Items a2 on a1.ItemCode=a2.ItemCode inner join ItemCategory a3 on a2.ItemCategoryCode=a3.ItemCategoryCode
		inner join ItemGroup a4 on a3.GroupCode=a4.GroupCode inner join ServiceModule a5 on a4.ServiceModuleCode=a5.ServiceModuleCode 
		where a.Paid=1 and convert(date,a.ExportDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103)
		group by a.PatientCode,a.RetailCode,a.ExportDate,a.FullName,a.Birthyear,a.PatientBirthday,a.PatientGender,a5.ServiceModuleName,a5.ServiceModuleCode,a.PatientReceiveID,a.Address,DisparityPrice
end