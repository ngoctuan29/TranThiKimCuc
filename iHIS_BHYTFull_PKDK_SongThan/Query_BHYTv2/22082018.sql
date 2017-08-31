---22/08/2017
ALTER procedure [dbo].[proList_Items]
(
	@ItemCode varchar(50)
)
as
begin
	if exists(select ItemCode from Items where ItemCode=@ItemCode and Is_Acttach_Service=1)
	select a.AttachServiceCode,s.ServiceName,a.ItemCode,a.Quantity from Attach_Service a inner join Service  s  on a.AttachServiceCode=s.ServiceCode where ItemCode=@ItemCode and a.Is_Service_Auto=0
end

GO
ALTER procedure [dbo].[proList_Items_Auto]
(
	@ItemCode varchar(50)
)
as
begin
	if exists(select ItemCode from Items where ItemCode=@ItemCode and Is_Acttach_Service=1)
	select a.AttachServiceCode,s.ServiceName,a.ItemCode,a.Quantity from Attach_Service a inner join Service  s  on a.AttachServiceCode=s.ServiceCode where ItemCode=@ItemCode and a.Is_Service_Auto=1
end

go

ALTER procedure [dbo].[pro_Report_View_DailyInvoiceDetail]
(
	
	@StartDate datetime,
	@EndDate datetime,
	@Cancel int=0
	)
as
begin
declare @MucBHChiTra decimal(18,2)=(select BHYTUnderPrice from BHYTParameters)
select lst.*  ,
 (case when lst.BHYTPay>0 then lst.PatientPay else 0 end) DifferentPay, (lst.Quantity * lst.DisparityPrice) DisparityAmount,
 (case when lst.BHYTPay>0 then 0 else lst.PatientPay end) ServiceAmount ,
 (case when lst.BHYTPay>0 then lst.Quantity* lst.DisparityPrice +lst.PatientPay  else lst.Quantity* lst.DisparityPrice +lst.PatientPay  end) TotalAmount
 --(case when lst.BHYTPay>0 and lst.BHYTPay>@MucBHChiTra then lst.Quantity* lst.DisparityPrice +lst.PatientPay  else (case when lst.BHYTPay>0 and lst.BHYTPay<=@MucBHChiTra then lst.Quantity* lst.DisparityPrice else lst.Quantity* lst.DisparityPrice +lst.PatientPay  end) end) TotalAmount 
from (
	select p.PatientCode ,p.PatientName,(case when p.PatientGender=1 then N'Nam' else N'Nữ' end)PatientGenderName,p.PatientBirthyear,b3.ObjectName,
	(case when ab.ShiftWork='AM' then N'Ca 1' when ab.ShiftWork='PM' then N'Ca 2' when ab.ShiftWork='EV' then N'Ca 3' else '' end) ShiftWork,
 a4.EmployeeName as DepartmentNameOrder
,a2.ServiceCategoryName
,a3.ServiceGroupName
,a1.ServiceName,
ab1.ServiceCode
,sum(ab1.Quantity)Quantity, ab1.ServicePrice, sum(ab1.DisparityPrice)DisparityPrice, sum(ab1.BHYTPay)BHYTPay,ab1.PatientPay ,N'Lần' UnitOfMeasureName,
CONVERT(date,ab1.PostingDate,104) PostingDate,a5.EmployeeName as CashierName,CONVERT(varchar(5),ab1.PostingDate,108) PostingTime,b3.ObjectCode
from BanksAccount ab 
inner join BanksAccountDetail ab1 on ab.BanksAccountCode = ab1.BanksAccountCode 
inner join SuggestedServiceReceipt a on ab1.BanksAccountCode = a.BanksAccountCode and ab1.ReceiptID = a.ReceiptID
  inner  join Service a1 on ab1.ServiceCode = a1.ServiceCode inner join ServiceCategory a2 on a1.ServiceCategoryCode = a2.ServiceCategoryCode
                         inner join ServiceGroup a3 on a2.ServiceGroupCode = a3.ServiceGroupCode
                         left join Department b1 on a.DepartmentCodeOrder = b1.DepartmentCode inner
                         join Object b3 on a.ObjectCode = b3.ObjectCode
                         inner join PatientReceive c1 on a.RefID = c1.PatientReceiveID
                        inner join Employee a4 on a.EmployeeCodeDoctor = a4.EmployeeCode
						inner join Employee a5 on ab.CashierCode = a5.EmployeeCode
						inner join Patients p on ab.PatientCode = p.PatientCode 
 ---where 1=1  and  ab1.PostingDate between @StartDate and @EndDate and a.Paid in(1) and a.BanksAccountCode is not null
where 1=1  and CONVERT(date,ab1.PostingDate,103) between CONVERT(date,@StartDate,103) and CONVERT(date,@EndDate,103)  and a.Paid in(1) and a.BanksAccountCode is not null
 group by  p.PatientCode,p.PatientName,p.PatientGender,p.PatientBirthyear,b3.ObjectName,ab.ShiftWork, a4.EmployeeName 
,a2.ServiceCategoryName
,a3.ServiceGroupName
,a1.ServiceName,
ab1.ServiceCode,ab1.BHYTPay,ab1.STT
,ab1.Quantity,ab1.ServicePrice,ab1.PatientPay,CONVERT(date,ab1.PostingDate,104),a5.EmployeeName,CONVERT(varchar(5),ab1.PostingDate,108),b3.ObjectCode
union all
select p.PatientCode ,p.PatientName,(case when p.PatientGender=1 then N'Nam' else N'Nữ' end)PatientGenderName,p.PatientBirthyear,b3.ObjectName,(case when ab.ShiftWork='AM' then N'Ca 1' when ab.ShiftWork='PM' then N'Ca 2' when ab.ShiftWork='EV' then N'Ca 3' else '' end) ShiftWork,
 
a4.EmployeeName as DepartmentNameOrder
,it1.ItemCategoryName ServiceCategoryName
,it2.GroupName ServiceGroupName
,it.ItemName ServiceName,
ab1.ServiceCode
,sum(ab1.Quantity)Quantity, ab1.ServicePrice, sum(ab1.DisparityPrice)DisparityPrice ,sum(ab1.BHYTPay)BHYTPay,ab1.PatientPay,un.UnitOfMeasureName,
CONVERT(date,ab1.PostingDate,104) PostingDate,a5.EmployeeName as CashierName,CONVERT(varchar(5),ab1.PostingDate,108) PostingTime,b3.ObjectCode
from BanksAccount ab inner join BanksAccountDetail ab1 on ab.BanksAccountCode = ab1.BanksAccountCode inner join Patients p on ab.PatientCode = p.PatientCode 
  inner join MedicinesForPatientsDetail me on ab1.BanksAccountCode = me.BanksAccountCode and me.ItemCode = ab1.ServiceCode
  inner join MedicalRecord a on me.MedicalRecordCode = a.MedicalRecordCode  
 left join Items it on ab1.ServiceCode = it.ItemCode
                         join ItemCategory it1 on it1.ItemCategoryCode = it.ItemCategoryCode
                         inner
                         join ItemGroup it2 on it1.GroupCode = it2.GroupCode
                         inner join  UnitOfMeasure un on it.UnitOfMeasureCode = un.UnitOfMeasureCode 
                        inner join Object b3 on a.ObjectCode = b3.ObjectCode
                        inner join Employee a4 on a.EmployeeCodeDoctor = a4.EmployeeCode
						inner join Employee a5 on ab.CashierCode = a5.EmployeeCode
---where 1=1  and  ab1.PostingDate between @StartDate and @EndDate and a.Paid in(1) and a.BanksAccountCode is not null					
 where 1=1  and CONVERT(date,a.PostingDate,103) between CONVERT(date,@StartDate,103) and CONVERT(date,@EndDate,103)  and a.Paid in(1) and a.BanksAccountCode is not null
 group by p.PatientCode,p.PatientName,p.PatientGender,p.PatientBirthyear,b3.ObjectName,ab.ShiftWork, a4.EmployeeName ,CONVERT(varchar(5),ab1.PostingDate,108)
,it1.ItemCategoryName 
,it2.GroupName 
,it.ItemName ,
ab1.ServiceCode,ab1.BHYTPay,ab1.STT
,ab1.Quantity,ab1.ServicePrice,ab1.PatientPay,un.UnitOfMeasureName, CONVERT(date,ab1.PostingDate,104),a5.EmployeeName,b3.ObjectCode
) lst
end
