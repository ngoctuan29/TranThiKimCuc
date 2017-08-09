if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Service' and b.name ='Attach_Items')
	alter table Service add Attach_Items bit default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SuggestedServiceReceipt' and b.name ='Check_')
	alter table SuggestedServiceReceipt add Check_ int default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SuggestedServiceReceipt' and b.name ='ReceiptID_DisparityPrice')
	alter table SuggestedServiceReceipt add ReceiptID_DisparityPrice numeric(18,0) default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Service' and b.name ='IDGroupPrint')
	alter table Service add IDGroupPrint int default 0 not null
go
-------12/04/2017 Vien phí apdung cho BHYT
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Service' and b.name ='Ten_TT37')
	alter table Service add Ten_TT37 nvarchar(2000) not null default ''
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Service' and b.name ='Ma_TT37')
	alter table Service add Ma_TT37 varchar(25) not null default ''
go
------- 11/04/2017 Toa mau
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SamplePrescriptionLine' and b.name ='UnitOfMeasureCode_Medi')
	alter table SamplePrescriptionLine add UnitOfMeasureCode_Medi varchar(15) default '' not null
go
------- 06/04/2017 Add xet nghiem - CDHA
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServiceRadiologyDetailEntry' and b.name ='Checked')
	alter table ServiceRadiologyDetailEntry add Checked bit not null default 1
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='LaboratoryPackage' and b.name ='TemplateHeaderCode')
	alter table LaboratoryPackage add TemplateHeaderCode nvarchar(50)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='LaboratoryPackage' and b.name ='TypeResult')
	alter table LaboratoryPackage add TypeResult int not null default 0
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='LaboratoryPackage' and b.name ='LaboratoryPackageName')
	alter table LaboratoryPackage add LaboratoryPackageName nvarchar(1000) not null default ''
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='LaboratoryPackage' and b.name ='ServiceCode')
	alter table LaboratoryPackage add ServiceCode varchar(20) not null default ''
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='TemplateDescription' and b.name ='ServiceMenuID')
	alter table TemplateDescription add ServiceMenuID int not null default 0
go
------- 03/04/17 Add Tiem Chung
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ImmunizationTimesDetail' and b.name ='TimesEntryID')
	alter table ImmunizationTimesDetail add TimesEntryID int default -1 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ImmunizationTimesDetail' and b.name ='Warning')
	alter table ImmunizationTimesDetail add Warning bit default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ImmunizationTimesDetail' and b.name ='Note')
	alter table ImmunizationTimesDetail add Note nvarchar(500) default '' not null
go
-------
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServiceLaboratoryEntry' and b.name ='EmployeeCodeDoctor')
	alter table ServiceLaboratoryEntry add EmployeeCodeDoctor varchar(20) default '' not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='TemplateDescription' and b.name ='PrintPaper')
	alter table TemplateDescription add PrintPaper varchar(10) default '' not null
go
------------- upd 21/03/2017
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Items' and b.name ='UnitOfMeasureCode_Medi')
	alter table Items add UnitOfMeasureCode_Medi varchar(15) default '' not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Items' and b.name ='Converted_Medi')
	alter table Items add Converted_Medi bit default 1 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Items' and b.name ='SalesPrice_Retail')
	alter table Items add SalesPrice_Retail decimal(18,4) default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicalPrescriptionDetail' and b.name ='UnitOfMeasureCode_Medi')
	alter table MedicalPrescriptionDetail add UnitOfMeasureCode_Medi varchar(15) default '' not null
go
------------- upd 18/03/2017
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Items' and b.name ='SalesPrice_Retail')
	alter table Items add SalesPrice_Retail decimal(18,4) default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ExportWarehousing' and b.name ='EmployeeNameReceive')
	alter table ExportWarehousing add EmployeeNameReceive nvarchar(250) default '' not null
go
IF  EXISTS (SELECT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'BN_04_YTTN')
	drop table BN_04_YTTN
go
--UPDATE Medicalrecord set ICD10_Custom=b.DiagnosisCode,ICD10Name_Custom=b.DiagnosisName from Medicalrecord a inner join Diagnosis b on a.DiagnosisCode=b.RowID
--- Upd Ngay 15/02/2017
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='PatientReceive' and b.name ='OrderNumberYYYY')
	alter table PatientReceive add OrderNumberYYYY int not null default 0
go
--- Ngay 08/02/2017
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicalRecord' and b.name='ICD10_Custom')
	alter table MedicalRecord add ICD10_Custom varchar(20) not null default ''
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicalRecord' and b.name='ICD10Name_Custom')
	alter table MedicalRecord add ICD10Name_Custom nvarchar(500) not null default ''
go
--- Ngay 16/01/2017 update
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SystemParameter' and b.name='EmployeeCode')
	alter table SystemParameter add EmployeeCode varchar(15) not null default ''
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='TemplateDescription' and b.name='EmployeeDoctorCode')
	alter table TemplateDescription add EmployeeDoctorCode varchar(15) not null default ''
go
-- update pro_Ins_TemplateDescription, pro_WaitingServiceForDate
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Service_BHYT' and b.name='DonGia_010316')
	alter table Service_BHYT add DonGia_010316 decimal(18,2) not null default 0
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Service_BHYT' and b.name='DonGia_010716')
	alter table Service_BHYT add DonGia_010716 decimal(18,2) not null default 0
go
----------ngay 24/12/2016
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Service' and b.name='SOQDPK')
	alter table Service add SOQDPK nvarchar(20) not null default ''
go
---pro_Ins_Service
--- Lab
--pro_Del_LaboratoryPackage
--pro_Ins_LaboratoryPackageDetail
--pro_Del_LaboratoryPackageDetail
--proWaitingLaboratory
--pro_Ins_BanksAccountDetail_01
--pro_Del_BanksAccount

----------ngay 21/12/2016
--pro_RealMedicinesEmergencyDetail_ForRealID
-------------------------- Luu thong tin xuat hoa don, 19/12/2016
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccount' and b.name='Invoice_MauSo')
	alter table BanksAccount add Invoice_MauSo varchar(100) not null default ''
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccount' and b.name='Invoice_KyHieu')
	alter table BanksAccount add Invoice_KyHieu varchar(100) not null default ''
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccount' and b.name='Invoice_HoTenKH')
	alter table BanksAccount add Invoice_HoTenKH nvarchar(300) not null default ''
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccount' and b.name='Invoice_DiaChi')
	alter table BanksAccount add Invoice_DiaChi nvarchar(300) not null default ''
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccount' and b.name='Invoice_MaSoThue')
	alter table BanksAccount add Invoice_MaSoThue varchar(50) not null default ''
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccount' and b.name='Invoice_DienThoai')
	alter table BanksAccount add Invoice_DienThoai nvarchar(50) not null default ''
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccount' and b.name='Invoice_HTThanhToan')
	alter table BanksAccount add Invoice_HTThanhToan nvarchar(100) not null default ''
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccount' and b.name='Invoice_VAT')
	alter table BanksAccount add Invoice_VAT int not null default 0
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccount' and b.name='Invoice_EmployeeCode')
	alter table BanksAccount add Invoice_EmployeeCode varchar(15) not null default ''
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccount' and b.name='Invoice_DonVi')
	alter table BanksAccount add Invoice_DonVi nvarchar(300) not null default ''
go
-------- Proc relation: pro_Ins_BanksAccount
--------------- upd them ma khoa phong thuc hien
if not exists(select name from sys.columns where Name = N'DepartmentCode' and Object_ID = Object_ID(N'ServiceLaboratoryEntry'))
 alter table ServiceLaboratoryEntry add DepartmentCode varchar(10)
go
---update ServiceLaboratoryEntry set DepartmentCode=''
---pro_Ins_ServiceLaboratoryEntry
---proWaitingLaboratory
---------------Update Chiet Khau Bac Sy
----- Update 15/11/2015
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SuggestedServiceReceipt' and b.name ='ConfirmDiscountIntro')
	alter table SuggestedServiceReceipt add ConfirmDiscountIntro int not null default 0
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SuggestedServiceReceipt' and b.name ='IntroName')
	alter table SuggestedServiceReceipt add IntroName nvarchar(250)
go
----- 12/10/2015
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicinesForPatients' and b.name='IDate')
	alter table MedicinesForPatients add IDate datetime default getdate() not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccount' and b.name='IDate')
	alter table BanksAccount add IDate datetime default getdate() not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='PatientReceive' and b.name='IDate')
	alter table PatientReceive add IDate datetime default getdate() not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SuggestedServiceReceipt' and b.name='ConfirmDiscountDoing')
	alter table SuggestedServiceReceipt add ConfirmDiscountDoing int default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SuggestedServiceReceipt' and b.name='DiscountDoing')
	alter table SuggestedServiceReceipt add DiscountDoing decimal default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SuggestedServiceReceipt' and b.name='PerDiscountDoing')
	alter table SuggestedServiceReceipt add PerDiscountDoing int default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SuggestedServiceReceipt' and b.name='ConfirmDiscountDone')
	alter table SuggestedServiceReceipt add ConfirmDiscountDone int default 0 not null
go
----------</12/10/2015
----------
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SuggestedServiceReceipt' and b.name ='DiscountIntro')
	alter table SuggestedServiceReceipt add DiscountIntro numeric(18,2) not null default 0
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SuggestedServiceReceipt' and b.name ='DiscountDoctorDone')
	alter table SuggestedServiceReceipt add DiscountDoctorDone numeric(18,2) not null default 0
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SuggestedServiceReceipt' and b.name ='DiscountDoctor')
	alter table SuggestedServiceReceipt add DiscountDoctor numeric(18,2) not null default 0
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServicePrice' and b.name ='PerDiscountIntro')
	alter table ServicePrice add PerDiscountIntro int not null default 0
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServicePrice' and b.name ='DiscountIntro')
	alter table ServicePrice add DiscountIntro numeric(18,2) not null default 0
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServicePrice' and b.name ='PerDiscountDoctorDone')
	alter table ServicePrice add PerDiscountDoctorDone int not null default 0
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServicePrice' and b.name ='DiscountDoctorDone')
	alter table ServicePrice add DiscountDoctorDone numeric(18,2) not null default 0
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServicePrice' and b.name ='PerDiscountDoctor')
	alter table ServicePrice add PerDiscountDoctor int not null default 0
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServicePrice' and b.name ='DiscountDoctor')
	alter table ServicePrice add DiscountDoctor numeric(18,2) not null default 0
go
----------
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SuggestedServiceReceipt' and b.name='ConfirmDiscountPointed')
	alter table SuggestedServiceReceipt add ConfirmDiscountPointed int default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ImmunizationRecordDetail' and b.name='EmployeeCodeDoing')
	alter table ImmunizationRecordDetail add EmployeeCodeDoing varchar(50)
go
--update ImmunizationRecordDetail set EmployeeCodeDoing=EmployeeCode where EmployeeCodeDoing is null
--update ImmunizationRecordDetail set EmployeeCodeDoctor=EmployeeCode where EmployeeCodeDoctor is null
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Surgeries' and b.name='EmployeeCodeDoing')
	alter table Surgeries add EmployeeCodeDoing varchar(50)
go
--update Surgeries set EmployeeCodeDoing=EmployeeCodeUpd
--go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServiceRadiologyEntry' and b.name='EmployeeCodeDoing')
	alter table ServiceRadiologyEntry add EmployeeCodeDoing varchar(50)
go
--update ServiceRadiologyEntry set EmployeeCodeDoing=EmployeeCode
--go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SuggestedServiceReceipt' and b.name='PerDiscountDoctor')
	alter table SuggestedServiceReceipt add PerDiscountDoctor int default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SuggestedServiceReceipt' and b.name='PerDiscountDoctorDone')
	alter table SuggestedServiceReceipt add PerDiscountDoctorDone int default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicalRecord' and b.name='EmployeeCodeDoing')
	alter table MedicalRecord add EmployeeCodeDoing varchar(50)
go
--update MedicalRecord set EmployeeCodeDoing=EmployeeCode
--go
if exists(select name from sysobjects where name ='proGetPatientReceiveForDoctor' and type='P')
	drop procedure proGetPatientReceiveForDoctor
go
create procedure proGetPatientReceiveForDoctor
(
	@FromDate datetime,
	@ToDate datetime,
	@EmployeeCode varchar(15),
	@ServiceGroupCode varchar(250),
	@Type varchar(5)
)
as
begin
	declare @TableGroup table(ServiceGroupCode varchar(15))
	if LEN(@ServiceGroupCode)>0
		insert into @TableGroup(ServiceGroupCode)(select ServiceGroupCode from ServiceGroup where ServiceGroupCode in(select * from dbo.fnSplitString(@ServiceGroupCode,',')))
	else
		insert into @TableGroup(ServiceGroupCode)(select ServiceGroupCode from ServiceGroup)
	if(@Type!='DONE')
	begin
		select a.EmployeeCodeDoing EmployeeCode,b.EmployeeName 
		from MedicalRecord a inner join Employee b on a.EmployeeCodeDoing = b.EmployeeCode inner join SuggestedServiceReceipt c on a.ReceiptID=c.ReceiptID 
		inner join Service c1 on c.ServiceCode=c1.ServiceCode inner join ServiceCategory c2 on c1.ServiceCategoryCode=c2.ServiceCategoryCode inner join ServiceGroup c3 on c2.ServiceGroupCode=c3.ServiceGroupCode
		where CONVERT(date,a.PostingDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) and c.Paid=1
		and c3.ServiceGroupCode in (select ServiceGroupCode from @TableGroup)
		and a.EmployeeCodeDoing = (case when @EmployeeCode='' then a.EmployeeCodeDoing else @EmployeeCode end)
		group by a.EmployeeCodeDoing,b.EmployeeName
		union
		select a.EmployeeCodeDoing EmployeeCode,b.EmployeeName from Surgeries a inner join Employee b on a.EmployeeCodeDoing = b.EmployeeCode inner join SuggestedServiceReceipt c on a.IDSuggested=c.ReceiptID
		inner join Service c1 on c.ServiceCode=c1.ServiceCode inner join ServiceCategory c2 on c1.ServiceCategoryCode=c2.ServiceCategoryCode inner join ServiceGroup c3 on c2.ServiceGroupCode=c3.ServiceGroupCode
		where CONVERT(date,c.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) and c.Paid=1
		and c3.ServiceGroupCode in (select ServiceGroupCode from @TableGroup)
		and a.EmployeeCodeDoing = (case when @EmployeeCode='' then a.EmployeeCodeDoing else @EmployeeCode end)
		group by a.EmployeeCodeDoing,b.EmployeeName
		union
		select a.EmployeeCodeDoing EmployeeCode,b.EmployeeName from ServiceRadiologyEntry a inner join Employee b on a.EmployeeCodeDoing = b.EmployeeCode inner join SuggestedServiceReceipt c on a.SuggestedID=c.ReceiptID
		inner join Service c1 on c.ServiceCode=c1.ServiceCode inner join ServiceCategory c2 on c1.ServiceCategoryCode=c2.ServiceCategoryCode inner join ServiceGroup c3 on c2.ServiceGroupCode=c3.ServiceGroupCode
		where CONVERT(date,c.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) and c.Paid=1
		and c3.ServiceGroupCode in (select ServiceGroupCode from @TableGroup)
		and a.EmployeeCodeDoing = (case when @EmployeeCode='' then a.EmployeeCodeDoing else @EmployeeCode end)
		group by a.EmployeeCodeDoing,b.EmployeeName
	end
	else
	begin
		select a.EmployeeCodeDoctor EmployeeCode,b.EmployeeName 
		from MedicalRecord a inner join Employee b on a.EmployeeCodeDoctor = b.EmployeeCode inner join SuggestedServiceReceipt c on a.ReceiptID=c.ReceiptID 
		inner join Service c1 on c.ServiceCode=c1.ServiceCode inner join ServiceCategory c2 on c1.ServiceCategoryCode=c2.ServiceCategoryCode inner join ServiceGroup c3 on c2.ServiceGroupCode=c3.ServiceGroupCode
		where CONVERT(date,a.PostingDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) and c.Paid=1
		and c3.ServiceGroupCode in (select ServiceGroupCode from @TableGroup)
		and a.EmployeeCodeDoctor = (case when @EmployeeCode='' then a.EmployeeCodeDoctor else @EmployeeCode end)
		group by a.EmployeeCodeDoctor,b.EmployeeName
		union
		select a.EmployeeCode,b.EmployeeName from Surgeries a inner join Employee b on a.EmployeeCode = b.EmployeeCode inner join SuggestedServiceReceipt c on a.IDSuggested=c.ReceiptID
		inner join Service c1 on c.ServiceCode=c1.ServiceCode inner join ServiceCategory c2 on c1.ServiceCategoryCode=c2.ServiceCategoryCode inner join ServiceGroup c3 on c2.ServiceGroupCode=c3.ServiceGroupCode
		where CONVERT(date,c.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) and c.Paid=1
		and c3.ServiceGroupCode in (select ServiceGroupCode from @TableGroup)
		and a.EmployeeCode = (case when @EmployeeCode='' then a.EmployeeCode else @EmployeeCode end)
		group by a.EmployeeCode,b.EmployeeName
		union
		select a.EmployeeCodeDoctor EmployeeCode,b.EmployeeName from ServiceRadiologyEntry a inner join Employee b on a.EmployeeCodeDoctor = b.EmployeeCode inner join SuggestedServiceReceipt c on a.SuggestedID=c.ReceiptID
		inner join Service c1 on c.ServiceCode=c1.ServiceCode inner join ServiceCategory c2 on c1.ServiceCategoryCode=c2.ServiceCategoryCode inner join ServiceGroup c3 on c2.ServiceGroupCode=c3.ServiceGroupCode
		where CONVERT(date,c.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) and c.Paid=1
		and c3.ServiceGroupCode in (select ServiceGroupCode from @TableGroup)
		and a.EmployeeCodeDoctor = (case when @EmployeeCode='' then a.EmployeeCodeDoctor else @EmployeeCode end)
		group by a.EmployeeCodeDoctor,b.EmployeeName
	end
end
go
if exists(select name from sysobjects where name ='proGetPatientReceiveForDoctorDetail' and type='P')
	drop procedure proGetPatientReceiveForDoctorDetail
go
create procedure proGetPatientReceiveForDoctorDetail
(
	@FromDate char(10),
	@ToDate char(10),
	@EmployeeCode varchar(15),
	@ServiceGroupCode varchar(50),
	@Type varchar(5)
)
as
begin
	declare @TableGroup table(ServiceGroupCode varchar(15))
	if LEN(@ServiceGroupCode)>0
		insert into @TableGroup(ServiceGroupCode)(select ServiceGroupCode from ServiceGroup where ServiceGroupCode in(select * from dbo.fnSplitString(@ServiceGroupCode,',')))
	else
		insert into @TableGroup(ServiceGroupCode)(select ServiceGroupCode from ServiceGroup)
	if(@Type!='DONE')
	begin
		 Select a.ReceiptID,b.PatientReceiveID,b.CreateDate PostingDate,e.PatientCode,e.PatientName,(case e.PatientGender when 0 then N'Nữ' else 'Nam' end) PatientGenderName, e.PatientBirthyear,
		 c.ServiceCode,c.ServiceName,(a.ServicePrice *a.Quantity) ServicePrice,(a.DiscountDoing *a.Quantity) DiscountAmount,ISNULL(a.PerDiscountDoing,c1.PerDiscountDoctorDone) DiscountPer, a.ConfirmDiscountDoing as [Check],a1.EmployeeCodeDoing
		from SuggestedServiceReceipt a inner join PatientReceive b on a.RefID=b.PatientReceiveID inner join MedicalRecord a1 on a.ReceiptID=a1.ReceiptID inner join [Service] c on a.ServiceCode=c.ServiceCode 
		inner join ServiceCategory d on c.ServiceCategoryCode=d.ServiceCategoryCode inner join Patients e on b.PatientCode=e.PatientCode  
		inner join ServicePrice c1 on a.RowIDPrice=c1.RowID
		where CONVERT(date,a.WorkDate,103) >= CONVERT(date,@FromDate,103) and CONVERT(date,a.WorkDate,103)<=CONVERT(date,@ToDate,103) 
		and a.ServiceCode not in('DV000000')  and a.Paid=1
		and d.ServiceGroupCode in (select ServiceGroupCode from @TableGroup)
		and a1.EmployeeCodeDoing = (case when @EmployeeCode='' then a1.EmployeeCodeDoing else @EmployeeCode end)
		union all
		Select a.ReceiptID,b.PatientReceiveID,b.CreateDate PostingDate,e.PatientCode,e.PatientName,(case e.PatientGender when 0 then N'Nữ' else 'Nam' end) PatientGenderName, e.PatientBirthyear,
		 c.ServiceCode,c.ServiceName,(a.ServicePrice *a.Quantity) ServicePrice,(a.DiscountDoing *a.Quantity) DiscountAmount,ISNULL(a.PerDiscountDoing,c1.PerDiscountDoctorDone) DiscountPer, a.ConfirmDiscountDoing as [Check],a1.EmployeeCodeDoing
		from SuggestedServiceReceipt a inner join PatientReceive b on a.RefID=b.PatientReceiveID inner join Surgeries a1 on a.ReceiptID=a1.IDSuggested inner join [Service] c on a.ServiceCode=c.ServiceCode 
		inner join ServiceCategory d on c.ServiceCategoryCode=d.ServiceCategoryCode inner join Patients e on b.PatientCode=e.PatientCode  
		inner join ServicePrice c1 on a.RowIDPrice=c1.RowID 
		where CONVERT(date,a.WorkDate,103) >= CONVERT(date,@FromDate,103) and CONVERT(date,a.WorkDate,103)<=CONVERT(date,@ToDate,103) 
		and a.ServiceCode not in('DV000000') and a.Paid=1
		and d.ServiceGroupCode in (select ServiceGroupCode from @TableGroup)
		and a1.EmployeeCode = (case when @EmployeeCode='' then a1.EmployeeCode else @EmployeeCode end)
		union all
		Select a.ReceiptID,b.PatientReceiveID,b.CreateDate PostingDate,e.PatientCode,e.PatientName,(case e.PatientGender when 0 then N'Nữ' else 'Nam' end) PatientGenderName, e.PatientBirthyear,
		 c.ServiceCode,c.ServiceName,(a.ServicePrice *a.Quantity) ServicePrice,(a.DiscountDoing *a.Quantity) DiscountAmount,ISNULL(a.PerDiscountDoing,c1.PerDiscountDoctorDone) DiscountPer, a.ConfirmDiscountDoing as [Check],a1.EmployeeCodeDoing
		from SuggestedServiceReceipt a inner join PatientReceive b on a.RefID=b.PatientReceiveID inner join ServiceRadiologyEntry a1 on a.ReceiptID=a1.SuggestedID inner join [Service] c on a.ServiceCode=c.ServiceCode 
		inner join ServiceCategory d on c.ServiceCategoryCode=d.ServiceCategoryCode inner join Patients e on b.PatientCode=e.PatientCode  
		inner join ServicePrice c1 on a.RowIDPrice=c1.RowID 
		where CONVERT(date,a.WorkDate,103) >= CONVERT(date,@FromDate,103) and CONVERT(date,a.WorkDate,103)<=CONVERT(date,@ToDate,103) 
		and a.ServiceCode not in('DV000000')  and a.Paid=1 and d.ServiceGroupCode in (select ServiceGroupCode from @TableGroup)
		and a1.EmployeeCodeDoing = (case when @EmployeeCode='' then a1.EmployeeCodeDoing else @EmployeeCode end)		
	end
	else
	begin
		Select a.ReceiptID,b.PatientReceiveID,b.CreateDate PostingDate,e.PatientCode,e.PatientName,(case e.PatientGender when 0 then N'Nữ' else 'Nam' end) PatientGenderName, e.PatientBirthyear,
		 c.ServiceCode,c.ServiceName,(a.ServicePrice *a.Quantity) ServicePrice,(a.DiscountDoctorDone * a.Quantity) DiscountAmount,ISNULL(a.PerDiscountDoctorDone,c1.PerDiscountDoctorDone) DiscountPer, a.ConfirmDiscountDone as [Check],a1.EmployeeCodeDoctor EmployeeCodeDoing
		from SuggestedServiceReceipt a inner join PatientReceive b on a.RefID=b.PatientReceiveID inner join MedicalRecord a1 on a.ReceiptID=a1.ReceiptID inner join [Service] c on a.ServiceCode=c.ServiceCode 
		inner join ServiceCategory d on c.ServiceCategoryCode=d.ServiceCategoryCode inner join Patients e on b.PatientCode=e.PatientCode  
		inner join ServicePrice c1 on a.RowIDPrice=c1.RowID 
		where CONVERT(date,a.WorkDate,103) >= CONVERT(date,@FromDate,103) and CONVERT(date,a.WorkDate,103)<=CONVERT(date,@ToDate,103) 
		and a.ServiceCode not in('DV000000') and a.Paid=1 and d.ServiceGroupCode in (select ServiceGroupCode from @TableGroup)
		and a1.EmployeeCodeDoctor = (case when @EmployeeCode='' then a1.EmployeeCodeDoctor else @EmployeeCode end)
		union all
		Select a.ReceiptID,b.PatientReceiveID,b.CreateDate PostingDate,e.PatientCode,e.PatientName,(case e.PatientGender when 0 then N'Nữ' else 'Nam' end) PatientGenderName, e.PatientBirthyear,
		 c.ServiceCode,c.ServiceName,(a.ServicePrice *a.Quantity) ServicePrice,(a.DiscountDoctorDone * a.Quantity) DiscountAmount,ISNULL(a.PerDiscountDoctorDone,c1.PerDiscountDoctorDone) DiscountPer, a.ConfirmDiscountDone as [Check],a1.EmployeeCode EmployeeCodeDoing
		from SuggestedServiceReceipt a inner join PatientReceive b on a.RefID=b.PatientReceiveID inner join Surgeries a1 on a.ReceiptID=a1.IDSuggested inner join [Service] c on a.ServiceCode=c.ServiceCode 
		inner join ServiceCategory d on c.ServiceCategoryCode=d.ServiceCategoryCode inner join Patients e on b.PatientCode=e.PatientCode  
		inner join ServicePrice c1 on a.RowIDPrice=c1.RowID 
		where CONVERT(date,a.WorkDate,103) >= CONVERT(date,@FromDate,103) and CONVERT(date,a.WorkDate,103)<=CONVERT(date,@ToDate,103) 
		and a.ServiceCode not in('DV000000') and a.Paid=1 and d.ServiceGroupCode in (select ServiceGroupCode from @TableGroup)
		and a1.EmployeeCode = (case when @EmployeeCode='' then a1.EmployeeCode else @EmployeeCode end)		
		union all
		Select a.ReceiptID,b.PatientReceiveID,b.CreateDate PostingDate,e.PatientCode,e.PatientName,(case e.PatientGender when 0 then N'Nữ' else 'Nam' end) PatientGenderName, e.PatientBirthyear,
		 c.ServiceCode,c.ServiceName,(a.ServicePrice *a.Quantity) ServicePrice,(a.DiscountDoctorDone * a.Quantity) DiscountAmount,ISNULL(a.PerDiscountDoctorDone,c1.PerDiscountDoctorDone) DiscountPer, a.ConfirmDiscountDone as [Check],a1.EmployeeCodeDoctor EmployeeCodeDoing
		from SuggestedServiceReceipt a inner join PatientReceive b on a.RefID=b.PatientReceiveID inner join ServiceRadiologyEntry a1 on a.ReceiptID=a1.SuggestedID inner join [Service] c on a.ServiceCode=c.ServiceCode 
		inner join ServiceCategory d on c.ServiceCategoryCode=d.ServiceCategoryCode inner join Patients e on b.PatientCode=e.PatientCode  
		inner join ServicePrice c1 on a.RowIDPrice=c1.RowID 
		where CONVERT(date,a.WorkDate,103) >= CONVERT(date,@FromDate,103) and CONVERT(date,a.WorkDate,103)<=CONVERT(date,@ToDate,103) 
		and a.ServiceCode not in('DV000000') and a.Paid=1 and d.ServiceGroupCode in (select ServiceGroupCode from @TableGroup)
		and a1.EmployeeCodeDoctor = (case when @EmployeeCode='' then a1.EmployeeCodeDoctor else @EmployeeCode end)
	end
end
go
IF NOT EXISTS (SELECT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ReportDiscount')
begin
CREATE TABLE ReportDiscount
(
	ReceiptID numeric(18,0),
	PatientReceiveID numeric(18,0) not null default 0,
	PatientCode varchar(15) not null,
	ServiceCode varchar(15) not null,
	ServicePrice numeric(18,2) not null default 0,
	ServicePriceOverTime numeric(18,2) not null default 0,
	DiscountAmount numeric(18,2) default 0 not null,
	DiscountPer int not null default 0,
	ReceiveDate datetime not null,
	IntroName nvarchar(200),
	WorkDate datetime default getdate(),
	ShiftWork char(2),
	EmployeeCode varchar(15),
	CONSTRAINT pk_ReportDiscount PRIMARY KEY (ReceiptID)
)
end
go
if exists(select name from sysobjects where name ='proIUReportDiscount')
	drop procedure proIUReportDiscount
go
create procedure proIUReportDiscount
(
	@ReceiptID numeric(18,0),
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(15),
	@ServiceCode varchar(15),
	@ServicePrice numeric(18,2),
	@ServicePriceOverTime numeric(18,2),
	@DiscountAmount numeric(18,2),
	@DiscountPer int,
	@ReceiveDate datetime,
	@IntroName nvarchar(200),
	@ShiftWork char(2),
	@Status int,
	@EmployeeCode varchar(15),
	@Result smallint output
)
as
begin
	set @IntroName=upper(@IntroName)
	if( exists(select PatientCode from ReportDiscount where ReceiptID=@ReceiptID) and @Status=0)
		begin
			delete from ReportDiscount where ReceiptID=@ReceiptID
			update SuggestedServiceReceipt set ConfirmDiscountIntro=0 where ReceiptID=@ReceiptID
			set @Result =1
		end
	else if(exists(select PatientCode from ReportDiscount where ReceiptID=@ReceiptID) and @Status=1)
		begin
			update ReportDiscount set PatientReceiveID=@PatientReceiveID,PatientCode=@PatientCode,ServiceCode=@ServiceCode,ServicePrice=@ServicePrice,ServicePriceOverTime=@ServicePriceOverTime,
			DiscountAmount=@DiscountAmount,DiscountPer=@DiscountPer,ReceiveDate=@ReceiveDate,IntroName=@IntroName,WorkDate=GETDATE(),ShiftWork=@ShiftWork,EmployeeCode=@EmployeeCode where ReceiptID=@ReceiptID 
			update SuggestedServiceReceipt set ConfirmDiscountIntro=@Status,DiscountIntro=@DiscountAmount,IntroName=@IntroName where ReceiptID=@ReceiptID
			set @Result =1
		end
	else if(@Status=1)
		begin
			insert into ReportDiscount(ReceiptID,PatientReceiveID,PatientCode,ServiceCode,ServicePrice,ServicePriceOverTime,DiscountAmount,DiscountPer,ReceiveDate,IntroName,WorkDate,ShiftWork,EmployeeCode) 
			values(@ReceiptID,@PatientReceiveID,@PatientCode,@ServiceCode,@ServicePrice,@ServicePriceOverTime,@DiscountAmount,@DiscountPer,@ReceiveDate,@IntroName,GETDATE(),@ShiftWork,@EmployeeCode)
			update SuggestedServiceReceipt set ConfirmDiscountIntro=@Status,DiscountIntro=@DiscountAmount,IntroName=@IntroName where ReceiptID=@ReceiptID
			set @Result =1
		end
	else
		set @Result =1
end
go
if exists(select name from sysobjects where name like'pReport_DiscountForIntro' and type='P')
	drop procedure pReport_DiscountForIntro
go
create procedure pReport_DiscountForIntro
(
	@FromDate char(10),
	@ToDate char(10),
	@ServiceGroupCode varchar(400),
	@ServiceCategoryCode varchar(400),
	@IntroName nvarchar(200),
	@EmployeeCode varchar(50),
	@TypeReport char(2)
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
	if @TypeReport='DE'
	begin
		select SUM(b.Quantity) Quantity, SUM(b.Quantity*b.DiscountIntro) TotalAmount,b.IntroName,c1.ServiceGroupName,c.ServiceName
		from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ReportDiscount b1 on b.ReceiptID=b1.ReceiptID
		where b.ServiceCode not in('DV000000') 
		and b.Paid=1
		and b.IntroName is not null and b.IntroName <>'' and CONVERT(date,a.CreateDate,103) >= CONVERT(date,@FromDate,103) and CONVERT(date,a.CreateDate,103)<=CONVERT(date,@ToDate,103)
		and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) 
		and b.IntroName=(case @IntroName when '' then b.IntroName else @IntroName end) and b.ConfirmDiscountIntro=1
		group by b.IntroName,c1.ServiceGroupName,c.ServiceName
	end
	else if @TypeReport='IN'
	begin
		select SUM(b.Quantity) Quantity, SUM(b.Quantity*b.DiscountIntro) TotalAmount,b.IntroName,c1.ServiceGroupName,c2.ServiceCategoryName,c.ServiceName,CONVERT(char(10),b.WorkDate,103) WorkDate,d.PatientName,d.PatientBirthyear,(case when d.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,d.PatientAddress,d.PatientMobile
		from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		inner join Patients d on a.PatientCode=d.PatientCode inner join ReportDiscount b1 on b.ReceiptID=b1.ReceiptID
		where b.ServiceCode not in('DV000000') 
		and b.Paid=1
		and b.IntroName is not null and b.IntroName <>'' and CONVERT(date,b.WorkDate,103) >= CONVERT(date,@FromDate,103) and CONVERT(date,b.WorkDate,103)<=CONVERT(date,@ToDate,103)
		and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) 
		and b.IntroName=(case @IntroName when '' then b.IntroName else @IntroName end) and b.ConfirmDiscountIntro=1
		group by b.IntroName,c1.ServiceGroupName,c2.ServiceCategoryName,c.ServiceName,CONVERT(char(10),b.WorkDate,103),d.PatientName,d.PatientBirthyear,d.PatientGender,d.PatientAddress,d.PatientMobile
	end
	else if @TypeReport='GE'
	begin
		select SUM(b.Quantity*b.DiscountIntro) TotalAmount,b.IntroName,c1.ServiceGroupName
		from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode inner join ReportDiscount b1 on b.ReceiptID=b1.ReceiptID
		where b.ServiceCode not in('DV000000') 
		and b.Paid=1
		and b.IntroName = case when @IntroName='' then b.IntroName else @IntroName end
		and CONVERT(date,b.WorkDate,103) >= CONVERT(date,@FromDate,103) and CONVERT(date,b.WorkDate,103)<=CONVERT(date,@ToDate,103)
		and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) and b.ConfirmDiscountIntro=1
		group by b.IntroName,c1.ServiceGroupName
	end
end
go
if exists(select name from sysobjects where name ='pReport_DiscountForDoctor' and type='P')
	drop procedure pReport_DiscountForDoctor
go
create procedure pReport_DiscountForDoctor
(
	@FromDate char(10),
	@ToDate char(10),
	@ServiceGroupCode varchar(400),
	@ServiceCategoryCode varchar(400),
	@EmployeeCodeDoctor varchar(200),
	@EmployeeCode varchar(50),
	@TypeReport varchar(3)
)
as
begin
	declare @TableGroup table(ServiceGroupCode varchar(15))
	declare @TableCategory table(ServiceCategoryCode varchar(15))
	declare @TableDoctor table(EmployeeCodeDoctor varchar(15))
	if LEN(@ServiceGroupCode)>0
		insert into @TableGroup(ServiceGroupCode)(select ServiceGroupCode from ServiceGroup where ServiceGroupCode in(select * from dbo.fnSplitString(@ServiceGroupCode,',')))
	else
		insert into @TableGroup(ServiceGroupCode)(select ServiceGroupCode from ServiceGroup)
	if LEN(@ServiceCategoryCode)>0
		insert into @TableCategory(ServiceCategoryCode)(select ServiceCategoryCode from ServiceCategory where ServiceCategoryCode in(select * from dbo.fnSplitString(@ServiceCategoryCode,',')))
	else
		insert into @TableCategory(ServiceCategoryCode)(select ServiceCategoryCode from ServiceCategory where ServiceGroupCode in(select ServiceGroupCode from @TableGroup))
	if LEN(@EmployeeCodeDoctor)>0
		insert into @TableDoctor(EmployeeCodeDoctor)(select EmployeeCode from Employee where EmployeeCode in(select * from dbo.fnSplitString(@EmployeeCodeDoctor,',')))
	else
		insert into @TableDoctor(EmployeeCodeDoctor)(select EmployeeCode from Employee where EmployeeCode in(select EmployeeCode from Employee))

	if @TypeReport='RS'
	begin
		select SUM(b.Quantity) Quantity, SUM(b.Quantity*b.DiscountDoing) TotalAmount,d1.EmployeeName,c1.ServiceGroupName,c.ServiceName,c2.ServiceCategoryName,CONVERT(char(10),d.PostingDate,103) PostingDate,e.PatientName,e.PatientBirthyear,(case when e.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,e.PatientAddress,e.PatientMobile
		from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		inner join MedicalRecord d on b.ReceiptID=d.ReceiptID inner join Employee d1 on d.EmployeeCodeDoing=d1.EmployeeCode inner join Patients e on a.PatientCode=e.PatientCode
		where b.ServiceCode not in('DV000000') and b.Paid=1 and CONVERT(date,b.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
		and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) and d.EmployeeCodeDoing in (select EmployeeCodeDoctor from @TableDoctor)
		and b.ConfirmDiscountDoing =1
		group by d1.EmployeeName,c1.ServiceGroupName,c.ServiceName,c2.ServiceCategoryName,CONVERT(char(10),d.PostingDate,103),e.PatientName,e.PatientBirthyear,e.PatientGender,e.PatientAddress,e.PatientMobile
		union all
		select SUM(b.Quantity) Quantity, SUM(b.Quantity*b.DiscountDoing) TotalAmount,d1.EmployeeName,c1.ServiceGroupName,c.ServiceName,c2.ServiceCategoryName,CONVERT(char(10),d.PostingDate,103) PostingDate,e.PatientName,e.PatientBirthyear,(case when e.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,e.PatientAddress,e.PatientMobile
		from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		inner join ServiceRadiologyEntry d on b.ReceiptID=d.SuggestedID inner join Employee d1 on d.EmployeeCodeDoing=d1.EmployeeCode inner join Patients e on a.PatientCode=e.PatientCode
		where b.ServiceCode not in('DV000000') and b.Paid=1 and CONVERT(date,b.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
		and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) and d.EmployeeCodeDoctor in (select EmployeeCodeDoctor from @TableDoctor)
		and b.ConfirmDiscountDoing=1
		group by d1.EmployeeName,c1.ServiceGroupName,c.ServiceName,c2.ServiceCategoryName,CONVERT(char(10),d.PostingDate,103),e.PatientName,e.PatientBirthyear,e.PatientGender,e.PatientAddress,e.PatientMobile
		--union all
		--select SUM(b.Quantity) Quantity, SUM(b.Quantity*b.DiscountIntro) TotalAmount,d1.EmployeeName,c1.ServiceGroupName,c.ServiceName,c2.ServiceCategoryName,d1.PostingDate,e.PatientName,e.PatientBirthyear,(case when e.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,e.PatientAddress,e.PatientMobile
		--from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		--inner join (select distinct d.SuggestedID,d2.EmployeeName,CONVERT(char(10),d1.PostingDate,103) PostingDate from  ServiceLaboratoryDetail d inner join ServiceLaboratoryEntry d1 on d.RowIDLaboratoryEnTry=d1.RowID inner join Employee d2 on d1.EmployeeCode=d2.EmployeeCode where d1.EmployeeCode in (select EmployeeCodeDoctor from @TableDoctor)) d1 on b.ReceiptID=d1.SuggestedID  inner join Patients e on a.PatientCode=e.PatientCode
		--where b.ServiceCode not in('DV000000') and b.Paid=1 and b.BanksAccountCode is not null and b.BanksAccountCode <>'' and CONVERT(date,b.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
		--and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) and c.ServiceCode in (select ServiceCode from @TableLimitServices)
		--group by d1.EmployeeName,c1.ServiceGroupName,c.ServiceName,c2.ServiceCategoryName,d1.PostingDate,e.PatientName,e.PatientBirthyear,e.PatientGender,e.PatientAddress,e.PatientMobile
		--union
		select SUM(b.Quantity) Quantity, SUM(b.Quantity*b.DiscountDoing) TotalAmount,d1.EmployeeName,c1.ServiceGroupName,c.ServiceName,c2.ServiceCategoryName,CONVERT(char(10),d.IDate,103) PostingDate,e.PatientName,e.PatientBirthyear,(case when e.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,e.PatientAddress,e.PatientMobile
		from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		inner join Surgeries d on b.ReceiptID=d.IDSuggested inner join Employee d1 on d.EmployeeCodeDoing=d1.EmployeeCode inner join Patients e on a.PatientCode=e.PatientCode
		where b.ServiceCode not in('DV000000') and b.Paid=1 and CONVERT(date,b.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
		and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) and d.EmployeeCode in (select EmployeeCodeDoctor from @TableDoctor)
		and b.ConfirmDiscountDoing=1
		group by d1.EmployeeName,c1.ServiceGroupName,c.ServiceName,c2.ServiceCategoryName,CONVERT(char(10),d.IDate,103),e.PatientName,e.PatientBirthyear,e.PatientGender,e.PatientAddress,e.PatientMobile
		--union
		--select SUM(b.Quantity) Quantity, SUM(b.Quantity*b.DiscountIntro) TotalAmount,d2.EmployeeName,c1.ServiceGroupName,c.ServiceName,c2.ServiceCategoryName,convert(char(10),d1.DateGiven,103) PostingDate,e.PatientName,e.PatientBirthyear,(case when e.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,e.PatientAddress,e.PatientMobile
		--from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		--inner join ImmunizationRecord d on b.ReceiptID=d.ReceiptID inner join ImmunizationRecordDetail d1 on d.ImmunizationRecordCode=d1.ImmunizationRecordCode inner join Employee d2 on d1.EmployeeCodeDoctor=d2.EmployeeCode inner join Patients e on a.PatientCode=e.PatientCode
		--where b.ServiceCode not in('DV000000') and b.Paid=1 and b.BanksAccountCode is not null and b.BanksAccountCode <>'' and CONVERT(date,b.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
		--and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) and c.ServiceCode in (select ServiceCode from @TableLimitServices) and d1.EmployeeCode in (select EmployeeCodeDoctor from @TableDoctor)
		--group by d2.EmployeeName,c1.ServiceGroupName,c.ServiceName,c2.ServiceCategoryName,convert(char(10),d1.DateGiven,103),e.PatientName,e.PatientBirthyear,e.PatientGender,e.PatientAddress,e.PatientMobile
	end
	else if @TypeReport='RS1'
	begin
		select SUM(b.Quantity) Quantity, SUM(b.Quantity*b.DiscountIntro) TotalAmount,d1.EmployeeName,c1.ServiceGroupName,c.ServiceName,c2.ServiceCategoryName,CONVERT(char(10),d.PostingDate,103) PostingDate,e.PatientName,e.PatientBirthyear,(case when e.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,e.PatientAddress,e.PatientMobile
		from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		inner join MedicalRecord d on b.ReceiptID=d.ReceiptID inner join Employee d1 on d.EmployeeCodeDoctor=d1.EmployeeCode inner join Patients e on a.PatientCode=e.PatientCode
		where b.ServiceCode not in('DV000000') and b.Paid=1 and CONVERT(date,b.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
		and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) and d.EmployeeCodeDoing in (select EmployeeCodeDoctor from @TableDoctor)
		and b.ConfirmDiscountDone=1
		group by d1.EmployeeName,c1.ServiceGroupName,c.ServiceName,c2.ServiceCategoryName,CONVERT(char(10),d.PostingDate,103),e.PatientName,e.PatientBirthyear,e.PatientGender,e.PatientAddress,e.PatientMobile
		union all
		select SUM(b.Quantity) Quantity, SUM(b.Quantity*b.DiscountIntro) TotalAmount,d1.EmployeeName,c1.ServiceGroupName,c.ServiceName,c2.ServiceCategoryName,CONVERT(char(10),d.PostingDate,103) PostingDate,e.PatientName,e.PatientBirthyear,(case when e.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,e.PatientAddress,e.PatientMobile
		from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		inner join ServiceRadiologyEntry d on b.ReceiptID=d.SuggestedID inner join Employee d1 on d.EmployeeCodeDoctor=d1.EmployeeCode inner join Patients e on a.PatientCode=e.PatientCode
		where b.ServiceCode not in('DV000000') and b.Paid=1 and CONVERT(date,b.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
		and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) and d.EmployeeCodeDoctor in (select EmployeeCodeDoctor from @TableDoctor)
		and b.ConfirmDiscountDone=1
		group by d1.EmployeeName,c1.ServiceGroupName,c.ServiceName,c2.ServiceCategoryName,CONVERT(char(10),d.PostingDate,103),e.PatientName,e.PatientBirthyear,e.PatientGender,e.PatientAddress,e.PatientMobile
		union all
		select SUM(b.Quantity) Quantity, SUM(b.Quantity*b.DiscountIntro) TotalAmount,d1.EmployeeName,c1.ServiceGroupName,c.ServiceName,c2.ServiceCategoryName,CONVERT(char(10),d.IDate,103) PostingDate,e.PatientName,e.PatientBirthyear,(case when e.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,e.PatientAddress,e.PatientMobile
		from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		inner join Surgeries d on b.ReceiptID=d.IDSuggested inner join Employee d1 on d.EmployeeCode=d1.EmployeeCode inner join Patients e on a.PatientCode=e.PatientCode
		where b.ServiceCode not in('DV000000') and b.Paid=1 and CONVERT(date,b.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
		and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) and d.EmployeeCode in (select EmployeeCodeDoctor from @TableDoctor)
		and b.ConfirmDiscountDone=1
		group by d1.EmployeeName,c1.ServiceGroupName,c.ServiceName,c2.ServiceCategoryName,CONVERT(char(10),d.IDate,103),e.PatientName,e.PatientBirthyear,e.PatientGender,e.PatientAddress,e.PatientMobile
	end
	else if @TypeReport='HA'
	begin
		select SUM(b.Quantity) Quantity, SUM(b.Quantity*b.DiscountDoctor) TotalAmount,b1.EmployeeName,c1.ServiceGroupName,c.ServiceName,c2.ServiceCategoryName,CONVERT(char(10),b.WorkDate,103) PostingDate,d.PatientName,d.PatientBirthyear,(case when d.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,d.PatientAddress,d.PatientMobile
		from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		inner join Employee b1 on b.EmployeeCodeDoctor=b1.EmployeeCode inner join Patients d on a.PatientCode=d.PatientCode
		where b.ServiceCode not in('DV000000') and b.Paid=1 and b.ConfirmDiscountPointed =1
		and CONVERT(date,b.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
		and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) 
		--and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) 
		--and c.ServiceCode in (select ServiceCode from @TableLimitServices) 
		and b.EmployeeCodeDoctor in (select EmployeeCodeDoctor from @TableDoctor)
		group by b1.EmployeeName,c1.ServiceGroupName,c.ServiceName,c2.ServiceCategoryName,CONVERT(char(10),b.WorkDate,103),d.PatientName,d.PatientBirthyear,d.PatientGender,d.PatientAddress,d.PatientMobile
	end
	else if @TypeReport='G1'
	begin
		select SUM(b.Quantity*b.DiscountDoctor) TotalAmount,b1.EmployeeName,c1.ServiceGroupName
		from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		inner join Employee b1 on b.EmployeeCodeDoctor=b1.EmployeeCode
		where b.ServiceCode not in('DV000000') 
		and b.Paid=1 and b.ConfirmDiscountPointed =1
		and CONVERT(date,b.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
		and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) and b.EmployeeCodeDoctor in (select EmployeeCodeDoctor from @TableDoctor)
		group by b1.EmployeeName,c1.ServiceGroupName
	end
	else if @TypeReport='G2'
	begin
		select SUM(b.Quantity*b.DiscountDoing) TotalAmount,d1.EmployeeName,c1.ServiceGroupName
		from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		inner join MedicalRecord d on b.ReceiptID=d.ReceiptID inner join Employee d1 on d.EmployeeCodeDoing=d1.EmployeeCode
		where b.ServiceCode not in('DV000000') and b.Paid=1 and b.BanksAccountCode is not null and b.BanksAccountCode <>'' and CONVERT(date,b.WorkDate,103) >= CONVERT(date,@FromDate,103) and CONVERT(date,b.WorkDate,103)<=CONVERT(date,@ToDate,103)
		and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) and d.EmployeeCodeDoing in (select EmployeeCodeDoctor from @TableDoctor)
		and b.ConfirmDiscountDoing=1
		group by d1.EmployeeName,c1.ServiceGroupName
		union all
		select SUM(b.Quantity*b.DiscountDoing) TotalAmount,d1.EmployeeName,c1.ServiceGroupName
		from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		inner join ServiceRadiologyEntry d on b.ReceiptID=d.SuggestedID inner join Employee d1 on d.EmployeeCodeDoing=d1.EmployeeCode
		where b.ServiceCode not in('DV000000') and b.Paid=1 and b.BanksAccountCode is not null and b.BanksAccountCode <>'' and CONVERT(date,b.WorkDate,103) >= CONVERT(date,@FromDate,103) and CONVERT(date,b.WorkDate,103)<=CONVERT(date,@ToDate,103)
		and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) and d.EmployeeCodeDoctor in (select EmployeeCodeDoctor from @TableDoctor)
		and b.ConfirmDiscountDoing=1
		group by d1.EmployeeName,c1.ServiceGroupName
		--union
		--select SUM(b.Quantity*b.DiscountIntro) TotalAmount,d1.EmployeeName,c1.ServiceGroupName
		--from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		--inner join (select distinct d.SuggestedID,d2.EmployeeName from  ServiceLaboratoryDetail d inner join ServiceLaboratoryEntry d1 on d.RowIDLaboratoryEnTry=d1.RowID inner join Employee d2 on d1.EmployeeCode=d2.EmployeeCode where d1.EmployeeCode in (select EmployeeCodeDoctor from @TableDoctor)) d1 on b.ReceiptID=d1.SuggestedID
		--where b.ServiceCode not in('DV000000') and b.Paid=1 and b.BanksAccountCode is not null and b.BanksAccountCode <>'' and CONVERT(date,b.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
		--and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) and c.ServiceCode in (select ServiceCode from @TableLimitServices)
		--group by d1.EmployeeName,c1.ServiceGroupName
		--union
		select SUM(b.Quantity*b.DiscountDoing) TotalAmount,d1.EmployeeName,c1.ServiceGroupName
		from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		inner join Surgeries d on b.ReceiptID=d.IDSuggested inner join Employee d1 on d.EmployeeCodeDoing=d1.EmployeeCode
		where b.ServiceCode not in('DV000000') and b.Paid=1 and b.BanksAccountCode is not null and b.BanksAccountCode <>'' and CONVERT(date,b.WorkDate,103) >= CONVERT(date,@FromDate,103) and CONVERT(date,b.WorkDate,103)<=CONVERT(date,@ToDate,103)
		and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) and d.EmployeeCode in (select EmployeeCodeDoctor from @TableDoctor)
		and b.ConfirmDiscountDoing=1
		group by d1.EmployeeName,c1.ServiceGroupName
		--union
		--select SUM(b.Quantity*b.DiscountIntro) TotalAmount,d2.EmployeeName,c1.ServiceGroupName
		--from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		--inner join ImmunizationRecord d on b.ReceiptID=d.ReceiptID inner join ImmunizationRecordDetail d1 on d.ImmunizationRecordCode=d1.ImmunizationRecordCode inner join Employee d2 on d1.EmployeeCodeDoctor=d2.EmployeeCode
		--where b.ServiceCode not in('DV000000') and b.Paid=1 and b.BanksAccountCode is not null and b.BanksAccountCode <>'' and CONVERT(date,b.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
		--and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) and c.ServiceCode in (select ServiceCode from @TableLimitServices) and d1.EmployeeCode in (select EmployeeCodeDoctor from @TableDoctor)
		--group by d2.EmployeeName,c1.ServiceGroupName
	end
	else if @TypeReport='G3'
	begin
		select SUM(b.Quantity*b.DiscountIntro) TotalAmount,d1.EmployeeName,c1.ServiceGroupName
		from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		inner join MedicalRecord d on b.ReceiptID=d.ReceiptID inner join Employee d1 on d.EmployeeCodeDoctor=d1.EmployeeCode
		where b.ServiceCode not in('DV000000') and b.Paid=1 and b.BanksAccountCode is not null and b.BanksAccountCode <>'' and CONVERT(date,b.WorkDate,103) >= CONVERT(date,@FromDate,103) and CONVERT(date,b.WorkDate,103)<=CONVERT(date,@ToDate,103)
		and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) and d.EmployeeCodeDoing in (select EmployeeCodeDoctor from @TableDoctor)
		and b.ConfirmDiscountDone=1
		group by d1.EmployeeName,c1.ServiceGroupName
		union all
		select SUM(b.Quantity*b.DiscountIntro) TotalAmount,d1.EmployeeName,c1.ServiceGroupName
		from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		inner join ServiceRadiologyEntry d on b.ReceiptID=d.SuggestedID inner join Employee d1 on d.EmployeeCodeDoctor=d1.EmployeeCode
		where b.ServiceCode not in('DV000000') and b.Paid=1 and b.BanksAccountCode is not null and b.BanksAccountCode <>'' and CONVERT(date,b.WorkDate,103) >= CONVERT(date,@FromDate,103) and CONVERT(date,b.WorkDate,103) <= CONVERT(date,@ToDate,103)
		and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) and d.EmployeeCodeDoctor in (select EmployeeCodeDoctor from @TableDoctor)
		and b.ConfirmDiscountDone=1
		group by d1.EmployeeName,c1.ServiceGroupName
		--union
		--select SUM(b.Quantity*b.DiscountIntro) TotalAmount,d1.EmployeeName,c1.ServiceGroupName
		--from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		--inner join (select distinct d.SuggestedID,d2.EmployeeName from  ServiceLaboratoryDetail d inner join ServiceLaboratoryEntry d1 on d.RowIDLaboratoryEnTry=d1.RowID inner join Employee d2 on d1.EmployeeCode=d2.EmployeeCode where d1.EmployeeCode in (select EmployeeCodeDoctor from @TableDoctor)) d1 on b.ReceiptID=d1.SuggestedID
		--where b.ServiceCode not in('DV000000') and b.Paid=1 and b.BanksAccountCode is not null and b.BanksAccountCode <>'' and CONVERT(date,b.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
		--and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) and c.ServiceCode in (select ServiceCode from @TableLimitServices)
		--group by d1.EmployeeName,c1.ServiceGroupName
		--union
		select SUM(b.Quantity*b.DiscountIntro) TotalAmount,d1.EmployeeName,c1.ServiceGroupName
		from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		inner join Surgeries d on b.ReceiptID=d.IDSuggested inner join Employee d1 on d.EmployeeCode=d1.EmployeeCode
		where b.ServiceCode not in('DV000000') and b.Paid=1 and b.BanksAccountCode is not null and b.BanksAccountCode <>'' and CONVERT(date,b.WorkDate,103) >= CONVERT(date,@FromDate,103) and CONVERT(date,b.WorkDate,103)<=CONVERT(date,@ToDate,103)
		and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) and d.EmployeeCode in (select EmployeeCodeDoctor from @TableDoctor)
		and b.ConfirmDiscountDone=1
		group by d1.EmployeeName,c1.ServiceGroupName
		--union
		--select SUM(b.Quantity*b.DiscountIntro) TotalAmount,d2.EmployeeName,c1.ServiceGroupName
		--from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceGroup c1 on c.ServiceGroupCode=c1.ServiceGroupCode inner join ServiceCategory c2 on c.ServiceCategoryCode=c2.ServiceCategoryCode
		--inner join ImmunizationRecord d on b.ReceiptID=d.ReceiptID inner join ImmunizationRecordDetail d1 on d.ImmunizationRecordCode=d1.ImmunizationRecordCode inner join Employee d2 on d1.EmployeeCodeDoctor=d2.EmployeeCode
		--where b.ServiceCode not in('DV000000') and b.Paid=1 and b.BanksAccountCode is not null and b.BanksAccountCode <>'' and CONVERT(date,b.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
		--and c.ServiceGroupCode in(select ServiceGroupCode from @TableGroup) and c.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory) and c.ServiceCode in (select ServiceCode from @TableLimitServices) and d1.EmployeeCode in (select EmployeeCodeDoctor from @TableDoctor)
		--group by d2.EmployeeName,c1.ServiceGroupName
	end
end
go
--------------</ Chiet khau Bac Sy
--- /Tinh trang lay lai ket qua may
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServiceLaboratoryEntry' and b.name='Result_Machine')
	alter table ServiceLaboratoryEntry add Result_Machine int default 0 not null
go
---< Nhom in report trong thuoc
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='CatalogComputer' and b.name='DateWorking')
	alter table CatalogComputer add DateWorking datetime default getdate() not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Items' and b.name='GroupPrinterCode')
	alter table Items add GroupPrinterCode varchar(8)
go
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GroupPrinter]') AND type in (N'U'))
begin
CREATE TABLE GroupPrinter
(
	RowID int identity(1,1),
	GroupPrinterCode varchar(8),
	GroupPrinterName nvarchar(500),
	Type_ char(1),
	OrderNumber int,
	EmployeeCode varchar(50),
	IDate datetime not null default getdate()
	CONSTRAINT pk_GroupPrinter PRIMARY KEY(RowID)
)
end
go
if exists(select name from sysobjects where name ='proIns_GroupPrinter')
	drop procedure proIns_GroupPrinter
go
create procedure proIns_GroupPrinter
(
	@GroupPrinterCode varchar(8),
	@GroupPrinterName nvarchar(500),
	@Type_ char(1),
	@OrderNumber int,
	@EmployeeCode varchar(50)
)
as
begin
	if exists(select GroupPrinterCode from GroupPrinter where GroupPrinterCode=@GroupPrinterCode)
		begin		
			update GroupPrinter set GroupPrinterName=@GroupPrinterName,Type_=@Type_,EmployeeCode=@EmployeeCode,OrderNumber=@OrderNumber,IDate=getdate() where GroupPrinterCode=@GroupPrinterCode
		end
	else
	begin
		declare @_stt decimal(6) =1
		declare @_Code varchar(8)=''
		if exists(select top(1) GroupPrinterCode from GroupPrinter order by RowID desc)
		begin
			set @_stt = (select top(1) CONVERT(decimal(6),isnull( SUBSTRING(GroupPrinterCode, 3, len(GroupPrinterCode)-2),0)) maxcode from GroupPrinter order by RowID desc)+1
			set @_Code=('NI'+(convert(varchar(6),@_stt)))
		end
		else
			set @_Code='NI1'
		print @_Code
		insert into GroupPrinter(GroupPrinterCode,GroupPrinterName,Type_,OrderNumber,EmployeeCode) values(@_Code,@GroupPrinterName,@Type_,@OrderNumber,@EmployeeCode)
	end
end
go
if exists(select name from sysobjects where name ='proDel_GroupPrinter')
	drop procedure proDel_GroupPrinter
go
create procedure proDel_GroupPrinter
(
	@GroupPrinterCode varchar(8),
	@iresult int output
)
as
begin
	if exists(select GroupPrinterCode from Items where GroupPrinterCode=@GroupPrinterCode)
		set @iresult =-1
	else
	begin
		delete from GroupPrinter where GroupPrinterCode=@GroupPrinterCode
		set @iresult =1
	end
end
go
--- /. Nhom in report trong thuoc
------------ 20/10/2016 Tuong Tac Thuoc
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='Items_BHYT') 
begin
CREATE TABLE Items_BHYT
(
	RowID decimal identity(1,1),
	STT decimal(18,0),
	SO_DANG_KY varchar(50) unique,
	TEN_THUOC nvarchar(500),
	MA_HOAT_CHAT_TT40 varchar(25),
	HOAT_CHAT_TT40 varchar(500),
	HOAT_CHAT_SODK varchar(500),
	MA_DUONG_DUNG varchar(10),
	DUONG_DUNG Nvarchar(150),
	HAM_LUONG Nvarchar(150),
	DONG_GOI nvarchar(250),
	HANG_SX nvarchar(250),
	NUOC_SX nvarchar(250),
	CONSTRAINT pk_Items_BHYT PRIMARY KEY (RowID)
)
end
go
if not exists(select name from sys.columns where Name = N'Active_TT40' and Object_ID = Object_ID(N'Items'))
 alter table Items add Active_TT40 varchar(20)
go
if not exists(select name from sys.columns where Name = N'BHYT_MaDuongDung' and Object_ID = Object_ID(N'Usage'))
 alter table Usage add BHYT_MaDuongDung varchar(10)
go
if not exists(select name from sys.columns where Name = N'STT' and Object_ID = Object_ID(N'Usage'))
 alter table Usage add STT int default 0 not null
go
if not exists(select name from sys.columns where Name = N'Pregnant' and Object_ID = Object_ID(N'MedicalRecord'))
 alter table MedicalRecord add Pregnant bit not null default 0
go
if not exists(select name from sys.columns where Name = N'Breastfeeding' and Object_ID = Object_ID(N'MedicalRecord'))
 alter table MedicalRecord add Breastfeeding bit not null default 0
go
if not exists(select name from sys.columns where Name = N'Use_Smoking' and Object_ID = Object_ID(N'MedicalRecord'))
 alter table MedicalRecord add Use_Smoking bit not null default 0
go
if not exists(select name from sys.columns where Name = N'Use_Alcohol' and Object_ID = Object_ID(N'MedicalRecord'))
 alter table MedicalRecord add Use_Alcohol bit not null default 0
go
------./ 20/10/2016 Tuong Tac Thuoc
------------ 23/09/2016 Phan Tich Ven
if not exists(select name from sys.columns where Name = N'IDAppointment247' and Object_ID = Object_ID(N'PatientReceive'))
 alter table PatientReceive add IDAppointment247 nvarchar(50)
go
if not exists(select name from sys.columns where Name = N'IDAppointment247' and Object_ID = Object_ID(N'SuggestedServiceReceipt'))
	alter table SuggestedServiceReceipt add IDAppointment247 nvarchar(50)
if not exists(select name from sys.columns where Name = N'IDDoctorAppointment247' and Object_ID = Object_ID(N'SuggestedServiceReceipt'))
	alter table SuggestedServiceReceipt add IDDoctorAppointment247 nvarchar(50)
if not exists(select name from sys.columns where Name = N'NameDoctorAppointment247' and Object_ID = Object_ID(N'SuggestedServiceReceipt'))
	alter table SuggestedServiceReceipt add NameDoctorAppointment247 nvarchar(100)
go
if not exists(select name from sys.columns where Name = N'PK247Code' and Object_ID = Object_ID(N'ClinicInformation'))
	alter table ClinicInformation add PK247Code varchar(50)
go
if not exists(select name from sys.columns where Name = N'Generic_BD' and Object_ID = Object_ID(N'Items'))
	alter table Items add Generic_BD char(1)
go
if not exists(select name from sys.columns where Name = N'VENCode' and Object_ID = Object_ID(N'Items'))
	alter table Items add VENCode char(1)
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='Catalog_VEN') 
begin
CREATE TABLE Catalog_VEN
(
	VENCode char(1),
	VENName nvarchar(100),
	CONSTRAINT Catalog_VEN_pk PRIMARY KEY (VENCode)
)
end
go
/*
insert into Catalog_VEN(VENCode,VENName) values('V',N'Vital (tối cần)')
insert into Catalog_VEN(VENCode,VENName) values('E',N'Essential (thiết yếu)')
insert into Catalog_VEN(VENCode,VENName) values('N',N'Non-Essential(không thiết yếu)')
*/
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='Catalog_ATC') 
begin
CREATE TABLE Catalog_ATC
(
	RowID int identity(1,1),
	ATCCode nvarchar(10),
	ATCName nvarchar(250),
	CONSTRAINT Catalog_ATC_pk PRIMARY KEY (ATCCode)
)
end
go
/*
insert into Catalog_ATC(ATCCode,ATCName) values(N'A',N'Đường tiêu hóa và chuyển hóa')
insert into Catalog_ATC(ATCCode,ATCName) values(N'B',N'Máu và cơ quan tạo máu')
insert into Catalog_ATC(ATCCode,ATCName) values(N'C',N'Hệ tim mạch')
insert into Catalog_ATC(ATCCode,ATCName) values(N'D',N'Thuốc dùng trên da')
insert into Catalog_ATC(ATCCode,ATCName) values(N'G',N'Hệ tiết niệu sinh dục và hormon sinh dục')
insert into Catalog_ATC(ATCCode,ATCName) values(N'H',N'Các chế phẩm hormon có tác dụng toàn thân ngoại trừ hormon sinh dục')
insert into Catalog_ATC(ATCCode,ATCName) values(N'J',N'Thuốc kháng khuẩn dùng toàn thân')
insert into Catalog_ATC(ATCCode,ATCName) values(N'L',N'Thuốc chống ung thư và tác nhân điều hòa miễn dịch')
insert into Catalog_ATC(ATCCode,ATCName) values(N'M',N'Hệ cơ xương')
insert into Catalog_ATC(ATCCode,ATCName) values(N'N',N'Hệ thần kinh trung ương')
insert into Catalog_ATC(ATCCode,ATCName) values(N'P',N'Thuốc chống ký sinh trùng')
insert into Catalog_ATC(ATCCode,ATCName) values(N'R',N'Hệ hô hấp')
insert into Catalog_ATC(ATCCode,ATCName) values(N'S',N'Giác quan')
insert into Catalog_ATC(ATCCode,ATCName) values(N'V',N'Thuốc khác')
insert into Catalog_ATC(ATCCode,ATCName) values(N'Đ',N'Thành phẩm đông y')
*/
------------17/08/2016
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='PatientsSendSMS') 
begin
CREATE TABLE PatientsSendSMS
(
	IDTarget varchar(25) not null,
	PatientCode varchar(15),
	AppointmentDate char(10),
	Mobile varchar(50) not null,
	Result nvarchar(100),
	Content nvarchar(max),
	EmployeeCode varchar(15),
	WorkDate datetime default getdate() not null,
	IDate datetime default getdate() not null,
	PatientReceiveID decimal(18,0),
	CONSTRAINT PatientsSendSMS_pk PRIMARY KEY (IDTarget)
)
end
go
if exists(select name from sysobjects where name ='proIns_PatientsSendSMS')
	drop procedure proIns_PatientsSendSMS
go
create procedure proIns_PatientsSendSMS
(
	@IDTarget varchar(25),
	@PatientCode varchar(15),
	@AppointmentDate char(10),
	@Mobile varchar(50),
	@Result nvarchar(100),
	@Content nvarchar(max),
	@EmployeeCode varchar(15),
	@WorkDate datetime,
	@PatientReceiveID decimal
)
as
begin
	if not exists(select IDTarget from PatientsSendSMS where IDTarget=@IDTarget)
	begin
		insert into PatientsSendSMS(IDTarget,PatientCode,AppointmentDate,Mobile,Result,Content,EmployeeCode,WorkDate,PatientReceiveID) values(@IDTarget,@PatientCode,@AppointmentDate,@Mobile,@Result,@Content,@EmployeeCode,@WorkDate,@PatientReceiveID)
	end
end
go
if exists(select name from sysobjects where name ='proView_PatientsSendSMS')
	drop procedure proView_PatientsSendSMS
go
create procedure proView_PatientsSendSMS
(
	@FrmDate char(10),
	@ToDate char(10)
)
as
begin
	select a.PatientReceiveID,a.PatientCode,b.PatientName,b.PatientBirthyear, (case b.PatientGender when 1 then 'Nam' else N'Nữ' end) PatientGenderName,a.Content,a.Result,a.WorkDate,c.EmployeeName
	from PatientsSendSMS a inner join Patients b on a.PatientCode=b.PatientCode inner join Employee c on a.EmployeeCode=c.EmployeeCode
	where CONVERT(date,a.WorkDate,103) between CONVERT(date,@FrmDate,103) and CONVERT(date,@ToDate,103)
end
go
if exists(select name from sysobjects where name='func_MedicalPrescriptionDetailForItems')
	drop function func_MedicalPrescriptionDetailForItems
go
create function [dbo].[func_MedicalPrescriptionDetailForItems](@MedicalRecordCode varchar(50))
RETURNS NVARCHAR(1000)
AS
BEGIN
	Declare @strKQ nvarchar(max)
	set @strKQ=''
	Declare @Tempt nvarchar(max)
	Declare @kq nvarchar(max)
	declare cur1 cursor read_only fast_forward
	for select (RTRIM(b.ItemName) +' : ' + CONVERT(varchar(10),a.Quantity) +' ('+d.UnitOfMeasureName+') '+
	(case when a.Morning<>'' then N' Sáng '+a.Morning else '' end)+(case when a.Noon<>'' then N' Trưa '+a.Noon else '' end)+
	(case when a.Afternoon<>'' then N' Chiều '+a.Afternoon else '' end)+(case when a.Evening<>'' then N' Tối '+a.Evening else '' end) 
	+ ' '+ a.Instruction) ItemName from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode inner join 
	UnitOfMeasure d on b.UnitOfMeasureCode=d.UnitOfMeasureCode 
	where a.MedicalRecordCode = @MedicalRecordCode 
	open cur1
	fetch next from cur1 into @kq
	while @@FETCH_STATUS = 0
	begin
		set @Tempt = @kq
		if ( len(@strKQ) > 0)
		begin
			set @strKQ=@strKQ + '; ' + @Tempt
		end
		else
		begin
			set @strKQ=@strKQ + @Tempt
		end
		FETCH NEXT FROM cur1 into @kq
	end
	CLOSE cur1
	DEALLOCATE cur1
	RETURN @strKQ
end
go
if exists(select name from sysobjects where name='func_MedicinesRetailForItems')
	drop function func_MedicinesRetailForItems
go
create function [dbo].[func_MedicinesRetailForItems](@PatientReceiveID numeric(18,0),@PatientCode varchar(50))
RETURNS NVARCHAR(1000)
AS
BEGIN
	Declare @strKQ nvarchar(max)
	set @strKQ=''
	Declare @Tempt nvarchar(max)
	Declare @kq nvarchar(max)
	declare cur1 cursor read_only fast_forward
	for select (c.ItemName +' : ' + CONVERT(varchar(10),b.QuantityExport) +' ('+d.UnitOfMeasureName+') '+(case when b.Morning<>'' then N' Sáng '+b.Morning else '' end)+(case when b.Noon<>'' then N' Trưa '+b.Noon else '' end)+(case when b.Afternoon<>'' then N' Chiều '+b.Afternoon else '' end)+(case when b.Evening<>'' then N' Tối '+b.Evening else '' end) + ' '+ b.Instruction) ItemName from MedicinesRetail a inner join MedicinesRetailDetail b on a.RetailCode=b.RetailCode inner join Items c on b.ItemCode=c.ItemCode inner join UnitOfMeasure d on c.UnitOfMeasureCode=d.UnitOfMeasureCode where a.PatientCode=@PatientCode and a.PatientReceiveID=@PatientReceiveID and a.Paid = 1
	open cur1
	fetch next from cur1 into @kq
	while @@FETCH_STATUS = 0
	begin
		set @Tempt = @kq
		if ( len(@strKQ) > 0)
		begin
			set @strKQ=@strKQ + '; ' + @Tempt
		end
		else
		begin
			set @strKQ=@strKQ + @Tempt
		end
		FETCH NEXT FROM cur1 into @kq
	end
	CLOSE cur1
	DEALLOCATE cur1
	RETURN @strKQ
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'MedicalRecord_ANC') AND type in (N'U'))
CREATE TABLE MedicalRecord_ANC
(
	MedicalRecordCode varchar(50),
	EmployeeCode varchar(15),
	IDate datetime default getdate(),
	TienSuSinhDe nvarchar(100),
	NgayKinhCuoiCung char(10),
	TuanThai varchar(20),
	NgaySinhDuKien char(10),
	LanCoThai int,
	TrongLuongMe varchar(20),
	ChieuCaoMe varchar(20),
	HuyetAp varchar(10),
	HuyetAp1 varchar(10),
	ChieuCaoTC varchar(10),
	VongBung varchar(10),
	KhungChau varchar(10),
	ThieuMau nvarchar(50),
	Protein nvarchar(50),
	XNHIV nvarchar(200),
	XNKhac nvarchar(200),
	TienLuongDe nvarchar(200),
	SoMuiTiem int,
	UongVien bit,
	WorkDate datetime,
	TimThai nvarchar(100),
	NgoiThai nvarchar(100),
	GhiChu nvarchar(200),
	CONSTRAINT pk_MedicalRecord_ANC PRIMARY KEY(MedicalRecordCode)
)
go
if exists(select name from sysobjects where name ='proIns_MedicalRecord_ANC')
	drop procedure proIns_MedicalRecord_ANC
go
create procedure proIns_MedicalRecord_ANC
(
	@MedicalRecordCode varchar(50),
	@EmployeeCode varchar(15),
	@TienSuSinhDe nvarchar(100),
	@NgayKinhCuoiCung char(10),
	@TuanThai varchar(20),
	@NgaySinhDuKien char(10),
	@LanCoThai int,
	@TrongLuongMe varchar(20),
	@ChieuCaoMe varchar(20),
	@HuyetAp varchar(10),
	@HuyetAp1 varchar(10),
	@ChieuCaoTC varchar(10),
	@VongBung varchar(10),
	@KhungChau varchar(10),
	@ThieuMau nvarchar(50),
	@Protein nvarchar(50),
	@XNHIV nvarchar(200),
	@XNKhac nvarchar(200),
	@TienLuongDe nvarchar(200),
	@SoMuiTiem int,
	@UongVien bit,
	@WorkDate datetime,
	@TimThai nvarchar(200),
	@NgoiThai nvarchar(200),
	@GhiChu nvarchar(200)
)
as
begin
	if exists(select MedicalRecordCode from MedicalRecord_ANC where MedicalRecordCode=@MedicalRecordCode)
		update MedicalRecord_ANC set EmployeeCode=@EmployeeCode,TienSuSinhDe=@TienSuSinhDe,NgayKinhCuoiCung=@NgayKinhCuoiCung,TuanThai=@TuanThai,NgaySinhDuKien=@NgaySinhDuKien,LanCoThai=@LanCoThai,TrongLuongMe=@TrongLuongMe,ChieuCaoMe=@ChieuCaoMe,HuyetAp=@HuyetAp,HuyetAp1=@HuyetAp1,ChieuCaoTC=@ChieuCaoTC,VongBung=@VongBung,KhungChau=@KhungChau,ThieuMau=@ThieuMau,Protein=@Protein,XNHIV=@XNHIV,XNKhac=@XNKhac,TienLuongDe=@TienLuongDe,SoMuiTiem=@SoMuiTiem,UongVien=@UongVien,WorkDate=@WorkDate, TimThai=@TimThai,NgoiThai=@NgoiThai,GhiChu=@GhiChu where MedicalRecordCode=@MedicalRecordCode
	else
	begin
		insert into MedicalRecord_ANC(EmployeeCode,TienSuSinhDe,NgayKinhCuoiCung,TuanThai,NgaySinhDuKien,LanCoThai,TrongLuongMe,ChieuCaoMe,HuyetAp,HuyetAp1,ChieuCaoTC,VongBung,KhungChau,ThieuMau,Protein,XNHIV,XNKhac,TienLuongDe,SoMuiTiem,UongVien,WorkDate,MedicalRecordCode,TimThai,NgoiThai,GhiChu) values(@EmployeeCode,@TienSuSinhDe,@NgayKinhCuoiCung,@TuanThai,@NgaySinhDuKien,@LanCoThai,@TrongLuongMe,@ChieuCaoMe,@HuyetAp,@HuyetAp1,@ChieuCaoTC,@VongBung,@KhungChau,@ThieuMau,@Protein,@XNHIV,@XNKhac,@TienLuongDe,@SoMuiTiem,@UongVien,@WorkDate,@MedicalRecordCode,@TimThai,@NgoiThai,@GhiChu)
	end
end
go
if not exists(select name from sys.columns where Name = N'Hide' and Object_ID = Object_ID(N'InventoryGeneral'))
	alter table InventoryGeneral add Hide int default 0 not null
go
if not exists(select * from sys.columns where Name = N'Printer' and Object_ID = Object_ID(N'BanksAccount'))
	alter table BanksAccount add Printer int default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicinesRetail' and b.name='VAT')
	alter table MedicinesRetail add VAT int default 0 not null
go
----------------------------------------- BHYT 18/08/2016
if not exists(select * from sys.columns where Name = N'Capcuu' and Object_ID = Object_ID(N'BHYT'))
	alter table BHYT add Capcuu int default 0 not null
go
----------------------
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'DepartmentBHYT'))
CREATE TABLE DepartmentBHYT
(
	STT int,
	TenKhoa nvarchar(200),
	MaKhoa varchar(5)
)
go
/*
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(1,N'1. Khoa Khám bệnh','K01')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(2,N'2. Khoa Hồi sức cấp cứu','K02')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(3,N'3. Khoa Nội tổng hợp','K03')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(4,N'4. Khoa Nội tim mạch','K04')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(5,N'5. Khoa Nội tiêu hóa','K05')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(6,N'6. Khoa Nội cơ - xương - khớp','K06')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(7,N'7. Khoa Nội thận - tiết niệu','K07')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(8,N'8. Khoa Nội tiết','K08')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(9,N'9. Khoa Dị ứng','K09')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(10,N'10. Khoa Huyết học lâm sàng','K10')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(11,N'11. Khoa Truyền nhiễm','K11')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(12,N'12. Khoa Lao','K12')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(13,N'13. Khoa Da liễu','K13')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(14,N'14. Khoa Thần kinh','K14')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(15,N'15. Khoa Tâm thần','K15')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(16,N'16. Khoa Y học cổ truyền','K16')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(17,N'17. Khoa Lão học','K17')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(18,N'18. Khoa Nhi','K18')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(19,N'19. Khoa Ngoại tổng hợp','K19')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(20,N'20. Khoa Ngoại thần kinh','K20')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(21,N'21. Khoa Ngoại lồng ngực','K21')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(22,N'22. Khoa Ngoại tiêu hóa','K22')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(23,N'23. Khoa Ngoại thận - tiết niệu','K23')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(24,N'24. Khoa Chấn thương chỉnh hình','K24')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(25,N'25. Khoa Bỏng','K25')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(26,N'26. Khoa Phẫu thuật - Gây mê hồi sức','K26')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(27,N'27. Khoa Phụ sản','K27')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(28,N'28. Khoa Tai - Mũi - Họng','K28')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(29,N'29. Khoa Răng - Hàm - Mặt','K29')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(30,N'30. Khoa Mắt','K30')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(31,N'31. Khoa Vật lý trị liệu - Phục hồi chức năng','K31')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(32,N'32. Khoa Y học hạt nhân','K32')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(33,N'33. Khoa Ung bướu (điều trị tia xạ)','K33')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(34,N'34. Khoa Truyền máu','K34')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(35,N'35. Khoa Lọc máu (thận nhân đạo)','K35')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(36,N'36. Khoa Huyết học','K36')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(37,N'37. Khoa Sinh hóa','K37')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(38,N'38. Khoa Vi sinh','K38')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(39,N'39. Khoa Chẩn đoán hình ảnh','K39')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(40,N'40. Khoa Thăm dò chức năng','K40')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(41,N'41. Khoa Nội soi','K41')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(42,N'42. Khoa Giải phẫu bệnh','K42')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(43,N'43. Khoa Chống nhiễm khuẩn','K43')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(44,N'44. Khoa Dược','K44')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(45,N'45. Khoa Dinh dưỡng','K45')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(46,N'46. Khoa Sinh học phân tử','K46')
insert into DepartmentBHYT(STT,TenKhoa,MaKhoa)values(47,N'47. Khoa Xét nghiệm','K47')
go
*/
----------- loai khoa
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LoaiKhoa'))
CREATE TABLE LoaiKhoa
(
	Id int,
	TenLoai nvarchar(50)
)
go
/*
insert into LoaiKhoa(Id,TenLoai)values(0,N'Khác')
insert into LoaiKhoa(Id,TenLoai)values(1,N'Ngoại trú')
insert into LoaiKhoa(Id,TenLoai)values(2,N'Nội trú')
go
*/
----------------------DMTTRV
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'DMTaiNanTT'))
CREATE TABLE DMTaiNanTT
(
	Ma int,
	Ten nvarchar(200)
)
go
/*
insert into DMTaiNanTT(Ma,Ten) values(0,N'Không')
insert into DMTaiNanTT(Ma,Ten) values(1,N'Tai nạn giao thông')
insert into DMTaiNanTT(Ma,Ten) values(2,N'Tai nạn lao động')
insert into DMTaiNanTT(Ma,Ten) values(3,N'Tai nạn dưới nước')
insert into DMTaiNanTT(Ma,Ten) values(4,N'Bỏng')
insert into DMTaiNanTT(Ma,Ten) values(5,N'Bạo lực, xung đột')
insert into DMTaiNanTT(Ma,Ten) values(6,N'Tự tử')
insert into DMTaiNanTT(Ma,Ten) values(7,N'Ngộ độc các loại')
insert into DMTaiNanTT(Ma,Ten) values(8,N'Khác')
*/
------------------------DMTTRV
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'DMTTRV'))
CREATE TABLE DMTTRV
(
	Ma int,
	Ten nvarchar(200)
)
go
/*
insert into DMTTRV(Ma,Ten) values(1,N'Ra viện')
insert into DMTTRV(Ma,Ten) values(2,N'Chuyển viện')
insert into DMTTRV(Ma,Ten) values(3,N'Trốn viện')
insert into DMTTRV(Ma,Ten) values(4,N'Xin ra viện')
*/
------------------KCBBD
if not exists(select * from sys.columns where Name = N'TT' and Object_ID = Object_ID(N'KCBBD'))
	alter table KCBBD add TT int default 0 not null
go
-------------------ReportBHYT
if not exists(select * from sys.columns where Name = N'MATNTT' and Object_ID = Object_ID(N'ReportBHYT'))
	alter table ReportBHYT add MATNTT int default 0 not null
go
if not exists(select * from sys.columns where Name = N'MATTRV' and Object_ID = Object_ID(N'ReportBHYT'))
	alter table ReportBHYT add MATTRV int default 0 not null
go
if not exists(select * from sys.columns where Name = N'IDTreatmentResults' and Object_ID = Object_ID(N'ReportBHYT'))
	alter table ReportBHYT add IDTreatmentResults int default 0 not null
go
if not exists(select * from sys.columns where Name = N'Capcuu' and Object_ID = Object_ID(N'ReportBHYT'))
	alter table ReportBHYT add Capcuu int default 0 not null
go
if not exists(select * from sys.columns where Name = N'TongBH' and Object_ID = Object_ID(N'ReportBHYT'))
	alter table ReportBHYT add TongBH decimal(18, 2) default 0 not null
go
if not exists(select * from sys.columns where Name = N'BNTraBH' and Object_ID = Object_ID(N'ReportBHYT'))
	alter table ReportBHYT add BNTraBH decimal(18, 2) default 0 not null
go
-------------------Department
if not exists(select * from sys.columns where Name = N'IdBv' and Object_ID = Object_ID(N'Department'))
	alter table Department add IdBv int default 0 not null
go
if not exists(select * from sys.columns where Name = N'KBHYT' and Object_ID = Object_ID(N'Department'))
	alter table Department add KBHYT varchar(10)
go
-------------------Items
if not exists(select * from sys.columns where Name = N'STTBCBHYT' and Object_ID = Object_ID(N'Items'))
	alter table Items add STTBCBHYT varchar(50)
go
if not exists(select * from sys.columns where Name = N'SODKGP' and Object_ID = Object_ID(N'Items'))
	alter table Items add SODKGP varchar(50)
go
if not exists(select * from sys.columns where Name = N'STTQDPK' and Object_ID = Object_ID(N'Items'))
	alter table Items add STTQDPK varchar(50)
go
if not exists(select * from sys.columns where Name = N'QUYCACH' and Object_ID = Object_ID(N'Items'))
	alter table Items add QUYCACH nvarchar(max)
go
-------------------Items
if not exists(select * from sys.columns where Name = N'TenCha' and Object_ID = Object_ID(N'Patients'))
	alter table Patients add TenCha nvarchar(250)
go
if not exists(select * from sys.columns where Name = N'NSCha' and Object_ID = Object_ID(N'Patients'))
	alter table Patients add NSCha numeric(18,4)
go
if not exists(select * from sys.columns where Name = N'TenMe' and Object_ID = Object_ID(N'Patients'))
	alter table Patients add TenMe nvarchar(250)
go
if not exists(select * from sys.columns where Name = N'NSMe' and Object_ID = Object_ID(N'Patients'))
	alter table Patients add NSMe numeric(18,4)
go
------------------sugge
if not exists(select * from sys.columns where Name = N'PaidBV' and Object_ID = Object_ID(N'SuggestedServiceReceipt'))
	alter table SuggestedServiceReceipt add PaidBV int default 0 not null
go
-----------------NhomTHUOC
if not exists(select * from sys.columns where Name = N'GroupID_BHYT' and Object_ID = Object_ID(N'ItemGroup'))
	alter table ItemGroup add GroupID_BHYT int default 0 not null
go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LabAppointmentForResults') AND type in (N'U'))
CREATE TABLE LabAppointmentForResults
(
	PatientReceiveID decimal(18,0),
	EmployeeCode varchar(15),
	IDate datetime default getdate(),
	SampleDate date,
	AppointmentDate date,
	AppointmentContent nvarchar(300),
	AppointmentCode varchar(5),
	ServiceCategoryCode varchar(15)
	CONSTRAINT pk_LabAppointmentForResults PRIMARY KEY(PatientReceiveID,ServiceCategoryCode)
)
go
if exists(select name from sysobjects where name ='proIns_LabAppointmentForResults')
	drop procedure proIns_LabAppointmentForResults
go
create procedure proIns_LabAppointmentForResults
(
	@PatientReceiveID decimal(18,0),
	@EmployeeCode varchar(15),
	@SampleDate date,
	@AppointmentDate date,
	@AppointmentContent nvarchar(300),
	@AppointmentCode varchar(5),
	@ServiceCategoryCode varchar(15)
)
as
begin
	if exists(select PatientReceiveID from LabAppointmentForResults where PatientReceiveID=@PatientReceiveID and ServiceCategoryCode=@ServiceCategoryCode)
		update LabAppointmentForResults set SampleDate=@SampleDate,AppointmentDate=@AppointmentDate,AppointmentCode=@AppointmentCode,EmployeeCode=@EmployeeCode,AppointmentContent=@AppointmentContent where PatientReceiveID=@PatientReceiveID and ServiceCategoryCode=@ServiceCategoryCode
	else
	begin
		insert into LabAppointmentForResults(PatientReceiveID,EmployeeCode,SampleDate,AppointmentDate,AppointmentCode,AppointmentContent,ServiceCategoryCode) values(@PatientReceiveID,@EmployeeCode,@SampleDate,@AppointmentDate,@AppointmentCode,@AppointmentContent,@ServiceCategoryCode)
	end
end
go
if exists(select name from sysobjects where name ='proDel_LabAppointmentForResults')
	drop procedure proDel_LabAppointmentForResults
go
create procedure proDel_LabAppointmentForResults
(
	@PatientReceiveID decimal(18,0),
	@ServiceCategoryCode varchar(15)
)
as
begin
	 delete from LabAppointmentForResults where PatientReceiveID=@PatientReceiveID and ServiceCategoryCode=@ServiceCategoryCode
end
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServicePrice' and b.name='DateOfApplicationEnd')
	alter table ServicePrice add DateOfApplicationEnd date not null default getdate()
go
if not exists(select name from sys.columns where Name = N'IDSales' and Object_ID = Object_ID(N'SuggestedServiceReceipt'))
	alter table SuggestedServiceReceipt add IDSales int default 0 not null
go
if not exists(select name from sys.columns where Name = N'StatusAppointment' and Object_ID = Object_ID(N'SuggestedServiceReceipt'))
	alter table SuggestedServiceReceipt add StatusAppointment bit default 0 not null
go
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ServiceSales]') AND type in (N'U'))
CREATE TABLE ServiceSales
(
	RowID int identity(1,1),
	Name nvarchar(250),
	IDate datetime default getdate(),
	DateFrom date,
	DateTo date,
	Hide int default 0,
	EmployeeCode varchar(15),
	CONSTRAINT pk_ServiceSales PRIMARY KEY(RowID)
)
go
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ServiceSalesDetail]') AND type in (N'U'))
CREATE TABLE ServiceSalesDetail
(
	IDSales int,
	ServiceCode varchar(15),
	IDate datetime default getdate(),
	UnitPrice decimal(18,2),
	RateSales int,
	UnitPriceSales decimal(18,2),
	EmployeeCode varchar(15),
	CONSTRAINT pk_ServiceSalesDetail PRIMARY KEY(IDSales,ServiceCode),
	constraint fk_ServiceSalesDetail_ServiceSales foreign key(IDSales) references ServiceSales(RowID)
)
go
if exists(select name from sysobjects where name ='proIns_ServiceSales')
	drop procedure proIns_ServiceSales
go
create procedure proIns_ServiceSales
(
	@RowID int,
	@Name nvarchar(250),
	@DateFrom date,
	@DateTo date,
	@Hide int,
	@EmployeeCode varchar(15),
	@IDOutPut int output
)
as
begin
	if exists(select RowID from ServiceSales where RowID=@RowID)
	begin
		update ServiceSales set Name=@Name,DateFrom=@DateFrom,DateTo=@DateTo,Hide=@Hide,EmployeeCode=@EmployeeCode where RowID=@RowID
		set @IDOutPut=@RowID
	end
	else
	begin
		insert into ServiceSales(Name,DateFrom,DateTo,Hide,EmployeeCode) values(@Name,@DateFrom,@DateTo,@Hide,@EmployeeCode)
		set @IDOutPut = (SELECT ISNULL(IDENT_CURRENT('ServiceSales'),-1) RowID)
		--SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY];
	end
end
go
if exists(select name from sysobjects where name ='proDel_ServiceSales')
	drop procedure proDel_ServiceSales
go
create procedure proDel_ServiceSales
(
	@RowID int,
	@iresult int output
)
as
begin
	if exists(select ServiceCode from SuggestedServiceReceipt where IDSales=@RowID)
		set @iresult =-1
	else
	begin
		delete from ServiceSalesDetail where IDSales=@RowID
		delete from ServiceSales where RowID=@RowID
		set @iresult =1
	end
end
go
if exists(select name from sysobjects where name ='proIns_ServiceSalesDetail')
	drop procedure proIns_ServiceSalesDetail
go
create procedure proIns_ServiceSalesDetail
(
	@IDSales int,
	@ServiceCode varchar(15),
	@UnitPrice decimal(18,2),
	@RateSales int,
	@UnitPriceSales decimal(18,2),
	@EmployeeCode varchar(15)
)
as
begin
	if exists(select ServiceCode from ServiceSalesDetail where IDSales=@IDSales and ServiceCode=@ServiceCode)
		update ServiceSalesDetail set UnitPrice=@UnitPrice,RateSales=@RateSales,UnitPriceSales=@UnitPriceSales,EmployeeCode=@EmployeeCode,IDate=getdate() where IDSales=@IDSales and ServiceCode=@ServiceCode
	else
		insert into ServiceSalesDetail(IDSales,ServiceCode,UnitPrice,RateSales,UnitPriceSales,EmployeeCode) values(@IDSales,@ServiceCode,@UnitPrice,@RateSales,@UnitPriceSales,@EmployeeCode)
end
go
if exists(select name from sysobjects where name ='proDel_ServiceSalesDetail')
	drop procedure proDel_ServiceSalesDetail
go
create procedure proDel_ServiceSalesDetail
(
	@RowID int,
	@ServiceCode varchar(15),
	@iresult int output
)
as
begin
	if exists(select ServiceCode from SuggestedServiceReceipt where IDSales=@RowID and ServiceCode=@ServiceCode)
		set @iresult =-1
	else
	begin
		delete from ServiceSalesDetail where IDSales=@RowID and ServiceCode=@ServiceCode
		set @iresult =1
	end
end
go
-------------- Update 04/07/2016 BHYT
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DMLoaiPT_TT]') AND type in (N'U'))
CREATE TABLE DMLoaiPT_TT
(
	MaPT_TT varchar(3),
	Ten nvarchar(250),
	IDate datetime default getdate(),
	Hide int default 0,
	CONSTRAINT pk_DMLoaiPT_TT PRIMARY KEY(MaPT_TT)
)
go
/*
insert into DMLoaiPT_TT(MaPT_TT,Ten)values('N0',N'')
insert into DMLoaiPT_TT(MaPT_TT,Ten)values('PD',N'Phẫu Thuật Đặc Biệt')
insert into DMLoaiPT_TT(MaPT_TT,Ten)values('P1',N'Phẫu Thuật Loại 1')
insert into DMLoaiPT_TT(MaPT_TT,Ten)values('P2',N'Phẫu Thuật Loại 2')
insert into DMLoaiPT_TT(MaPT_TT,Ten)values('P3',N'Phẫu Thuật Loại 3')
insert into DMLoaiPT_TT(MaPT_TT,Ten)values('TD',N'Thủ Thuật Đặc Biệt')
insert into DMLoaiPT_TT(MaPT_TT,Ten)values('T1',N'Thủ Thuật Loại 1')
insert into DMLoaiPT_TT(MaPT_TT,Ten)values('T2',N'Thủ Thuật Loại 2')
insert into DMLoaiPT_TT(MaPT_TT,Ten)values('T3',N'Thủ Thuật Loại 3')
go*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DMChuyenKhoa_BHYT]') AND type in (N'U'))
CREATE TABLE DMChuyenKhoa_BHYT
(
	MaCK varchar(3),
	STT int not null,
	Ten nvarchar(250),
	IDate datetime default getdate(),
	Hide int default 0,
	CONSTRAINT pk_DMChuyenKhoa_BHYT PRIMARY KEY(MaCK)
)
go
/*
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('01',1,N'I. HỒI SỨC CẤP CỨU, CHÔNG ĐỘC')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('02',2,N'II. NỘI KHOA')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('03',3,N'III. NHI KHOA')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('04',4,N'IV. LAO')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('05',5,N'V. DA LIỄU')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('06',6,N'VI. TÂM THẦN')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('07',7,N'VII. NỘI TIẾT')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('08',8,N'VIII. Y HỌC CỔ TRUYỀN, CHÂM CỨU')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('09',9,N'IX. GÂY MÊ HỒI SỨC')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('10',10,N'X. NGOẠI KHOA')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('11',11,N'XI. BỎNG')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('12',12,N'XII. UNG BƯỚU')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('13',13,N'XIII. PHỤ SẢN')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('14',14,N'XIV. MẮT')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('15',15,N'XV. TAI MŨI HỌNG')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('16',16,N'XVI. RĂNG HÀM MẶT')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('17',17,N'XVII. PHỤC HỒI CHỨC NĂNG')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('18',18,N'XVIII. ĐIỆN QUANG')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('19',19,N'XIX. Y HỌC HẠT NHÂN')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('20',20,N'XX. NỌI SOI CHẨN ĐOÁN, CAN THIỆP')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('21',21,N'XXI. THĂM DÒ CHỨC NĂNG')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('22',22,N'XXII. HUYẾT HỌC, TRUYỀN MÁU')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('23',23,N'XXIII. HÓA SINH')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('24',24,N'XXIV. VI SINH')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('25',25,N'XXV. GIẢI PHẪU BỆNH')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('26',26,N'XXVI. VI PHẪU')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('27',27,N'XXVII. PHẪU THUẬT NỘI SOI')
insert into DMChuyenKhoa_BHYT(MaCK,STT,Ten) values('28',28,N'XXVIII. PHẪU THUẬT TẠO HÌNH, THẨM MỸ')
*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ServiceGroup_BHYT]') AND type in (N'U'))
CREATE TABLE ServiceGroup_BHYT
(
	GroupID int,
	STT int not null,
	GroupName nvarchar(250),
	IDate datetime default getdate(),
	Hide int default 0,
	Abbreviations varchar(15),
	CONSTRAINT pk_ServiceGroup_BHYT PRIMARY KEY(GroupID)
)
go
/*
insert into ServiceGroup_BHYT(GroupID,STT,GroupName,Hide,Abbreviations) values(1,1,N'XÉT NGHIỆM',0,'XN')
insert into ServiceGroup_BHYT(GroupID,STT,GroupName,Hide,Abbreviations) values(2,2,N'CHẨN ĐOÁN HÌNH ẢNH',0,'CDHA')
insert into ServiceGroup_BHYT(GroupID,STT,GroupName,Hide,Abbreviations) values(3,3,N'THĂM DÒ CHỨC NĂNG',0,'TDCN')
insert into ServiceGroup_BHYT(GroupID,STT,GroupName,Hide,Abbreviations) values(4,4,N'THUỐC TRONG DANH MỤC BHYT',0,'THUOCBH')
insert into ServiceGroup_BHYT(GroupID,STT,GroupName,Hide,Abbreviations) values(5,5,N'THUỐC ĐIỀU TRỊ UNG THƯ, CHỐNG THẢI GHÉP NGOÀI DANH MỤC',0,'THUOCUT')
insert into ServiceGroup_BHYT(GroupID,STT,GroupName,Hide,Abbreviations) values(6,6,N'THUỐC THANH TOÁN THEO TỶ LỆ',0,'THUOC')
insert into ServiceGroup_BHYT(GroupID,STT,GroupName,Hide,Abbreviations) values(7,7,N'MÁU VÀ CHẾ PHẨM MÁU',0,'MAU')
insert into ServiceGroup_BHYT(GroupID,STT,GroupName,Hide,Abbreviations) values(8,8,N'THỦ THUẬT, PHẪU THUẬT',0,'TTPT')
insert into ServiceGroup_BHYT(GroupID,STT,GroupName,Hide,Abbreviations) values(9,9,N'DVKT CAO CHI PHÍ LỚN',0,'DVKTC')
insert into ServiceGroup_BHYT(GroupID,STT,GroupName,Hide,Abbreviations) values(10,10,N'VẬT TƯ Y TẾ TRONG DANH MỤC BHYT',0,'VTYTBH')
insert into ServiceGroup_BHYT(GroupID,STT,GroupName,Hide,Abbreviations) values(11,11,N'VẬT TƯ Y TẾ THANH TOÁN THEO TỶ LỆ',0,'VTYTTL')
insert into ServiceGroup_BHYT(GroupID,STT,GroupName,Hide,Abbreviations) values(12,12,N'VẬN CHUYỂN',0,'VC')
insert into ServiceGroup_BHYT(GroupID,STT,GroupName,Hide,Abbreviations) values(13,13,N'KHÁM BỆNH',0,'KB')
insert into ServiceGroup_BHYT(GroupID,STT,GroupName,Hide,Abbreviations) values(14,13,N'GIƯỜNG ĐIỀU TRỊ NGOẠI TRÚ',0,'GIUONGNG')
insert into ServiceGroup_BHYT(GroupID,STT,GroupName,Hide,Abbreviations) values(15,13,N'GIƯỜNG ĐIỀU TRỊ NỘI TRÚ',0,'GIUONGNOI')
go*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Service_BHYT]') AND type in (N'U'))
CREATE TABLE Service_BHYT
(
	MaTuongDuong varchar(15),
	Ma_TT50 varchar(10),
	Ten_TT50 nvarchar(1000),
	PhanTuyen varchar(5),
	MaPT_TT varchar(3),
	IDate datetime default getdate(),
	Hide int default 0,
	Ma_TT37 varchar(15),
	Ten_TT37 nvarchar(1000),
	SoQD nvarchar(250),
	NgayKy char(10),
	MaCKTT50 varchar(3),
	MaTT03_04 nvarchar(100),
	MaQD5084 nvarchar(100),
	STT int not null,
	GhiChu nvarchar(250)
	CONSTRAINT pk_Service_BHYT PRIMARY KEY(MaTuongDuong)
)
go
if not exists(select name from sys.columns where Name = N'GroupID_BHYT' and Object_ID = Object_ID(N'ServiceGroup'))
	alter table ServiceGroup add GroupID_BHYT int default 0 not null
go
if not exists(select name from sys.columns where Name = N'MaTuongDuong_BHYT' and Object_ID = Object_ID(N'Service'))
	alter table [Service] add MaTuongDuong_BHYT varchar(15)
go
if not exists(select name from sys.columns where Name = N'MaCK_BHYT' and Object_ID = Object_ID(N'Service'))
	alter table [Service] add MaCK_BHYT varchar(3)
go
if not exists(select name from sys.columns where Name = N'MaDK_BHYT' and Object_ID = Object_ID(N'Service'))
	alter table [Service] add MaDK_BHYT varchar(15)
go
if not exists(select name from sys.columns where Name = N'Note' and Object_ID = Object_ID(N'Service'))
	alter table [Service] add Note nvarchar(200)
go
--------------------------- END BHYT
if not exists(select name from sys.columns where Name = N'ServicePrice' and Object_ID = Object_ID(N'ServicePackageDetail'))
	alter table ServicePackageDetail add ServicePrice decimal(18,2) default 0 not null
go
if not exists(select name from sys.columns where Name = N'SampleTransferPrice' and Object_ID = Object_ID(N'ServicePrice'))
	alter table ServicePrice add SampleTransferPrice decimal(18,2) default 0 not null
go
if not exists(select name from sys.columns where Name = N'SampleTransfer' and Object_ID = Object_ID(N'Service'))
	alter table [Service] add SampleTransfer int default 0 not null
go
if not exists(select name from sys.columns where Name = N'SampleTransfer' and Object_ID = Object_ID(N'SuggestedServiceReceipt'))
	alter table SuggestedServiceReceipt add SampleTransfer int default 0 not null
go
if not exists(select name from sys.columns where Name = N'SampleTransferPrice' and Object_ID = Object_ID(N'SuggestedServiceReceipt'))
	alter table SuggestedServiceReceipt add SampleTransferPrice decimal(18,2) default 0 not null
go
-------------- Thuoc 11-06-2016
if not exists(select name from sys.columns where Name = N'ServicePriceSalesOff' and Object_ID = Object_ID(N'BanksAccountDetail'))
	alter table BanksAccountDetail add ServicePriceSalesOff numeric(18,2) default 0 not null
go
if not exists(select name from sys.columns where Name = N'Depreciated' and Object_ID = Object_ID(N'Warehousing'))
	alter table Warehousing add Depreciated decimal default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Warehousing' and b.name='FormNo')
	alter table Warehousing add FormNo varchar(100)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Warehousing' and b.name='VAT')
	alter table Warehousing add VAT int default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='WarehousingDetail' and b.name='QuantityInput')
	alter table WarehousingDetail add QuantityInput int default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='WarehousingDetail' and b.name='QtyOfMeasure')
	alter table WarehousingDetail add QtyOfMeasure int default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='WarehousingDetail' and b.name='PerSalesPrice')
	alter table WarehousingDetail add PerSalesPrice int default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='WarehousingDetail' and b.name='UnitPriceNoVAT')
	alter table WarehousingDetail add UnitPriceNoVAT numeric(18,0) default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Items' and b.name='ItemContent')
	alter table Items add ItemContent nvarchar(50)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Items' and b.name='QtyOfMeasure')
	alter table Items add QtyOfMeasure int default 1 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Items' and b.name='Packed')
	alter table Items add Packed nvarchar(50)
go
-------------- Kham benh
if not exists(select name from sys.columns where Name = N'PatientBirthday' and Object_ID = Object_ID(N'MedicinesRetail'))
	alter table MedicinesRetail add PatientBirthday date
go
if not exists(select name from sys.columns where Name = N'PatientMonth' and Object_ID = Object_ID(N'MedicinesRetail'))
	alter table MedicinesRetail add PatientMonth varchar(5)
go
if not exists(select name from sys.columns where Name = N'PatientGender' and Object_ID = Object_ID(N'MedicinesRetail'))
	alter table MedicinesRetail add PatientGender int not null default 0
go
if not exists(select name from sys.columns where Name = N'PatientAge' and Object_ID = Object_ID(N'MedicinesRetail'))
	alter table MedicinesRetail add PatientAge int not null default 0
go
if not exists(select name from sys.columns where Name = N'EmployeeCodeDoctor' and Object_ID = Object_ID(N'MedicinesRetail'))
	alter table MedicinesRetail add EmployeeCodeDoctor varchar(15)
go
if not exists(select name from sys.columns where Name = N'EmployeeNameDoctor' and Object_ID = Object_ID(N'MedicinesRetail'))
	alter table MedicinesRetail add EmployeeNameDoctor nvarchar(250)
go
if not exists(select name from sys.columns where Name = N'PatientMonth' and Object_ID = Object_ID(N'Patients'))
	alter table Patients add PatientMonth varchar(5)
go
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[EmployeeGroup]') AND type in (N'U'))
begin
CREATE TABLE EmployeeGroup
(
	EmployeeGroupID int,
	EmployeeGroupName nvarchar(250)
	CONSTRAINT pk_EmployeeGroup PRIMARY KEY(EmployeeGroupID)
)
end
go
--insert into EmployeeGroup(EmployeeGroupID,EmployeeGroupName) values(9999,N'Quản Trị Hệ Thống (Admin)')
--insert into EmployeeGroup(EmployeeGroupID,EmployeeGroupName) values(0,N'')
--insert into EmployeeGroup(EmployeeGroupID,EmployeeGroupName) values(1,N'Nhân Viên')
--go
if not exists(select * from sys.columns where Name = N'EmployeeGroupID' and Object_ID = Object_ID(N'Employee'))
	alter table Employee add EmployeeGroupID int default 0 not null
go
if not exists(select * from sys.columns where Name = N'ReasonCancel' and Object_ID = Object_ID(N'MedicinesRetail'))
	alter table MedicinesRetail add ReasonCancel nvarchar(500)
go
if exists(select name from sysobjects where name ='proHSBAResultService' and type='P')
	drop procedure proHSBAResultService
go
create procedure proHSBAResultService
(
	@RefID numeric(18,0),
	@PatientCode varchar(50)
)
as
set nocount on
begin
	declare @TableSugges table(PatientReceiveID decimal(20,0), ReceiptID decimal(20,0), ServiceCode varchar(15),ServiceModuleCode varchar(15), Status int)
	declare @TableResult table(ReceiptID decimal(20,0), EmployeeDoctorName nvarchar(250),ServiceCode varchar(15),Status int, ServiceMenuID int, ResultCode varchar(20))

	declare @ResultCode varchar(20)=''

	insert into @TableSugges(PatientReceiveID,ReceiptID,ServiceCode,ServiceModuleCode,Status)
	select a.RefID,a.ReceiptID,a.ServiceCode,b2.ServiceModuleCode,a.Status
	from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode 
	inner join ServiceGroup b2 on b1.ServiceGroupCode=b2.ServiceGroupCode
	where a.RefID=@RefID and a.PatientCode=@PatientCode and b2.ServiceModuleCode<>'KCB'
	declare @Count int = (select count(*) SL from @TableSugges)
	while @Count>0
	begin
		declare @ReceiptID numeric(18,0) = (select top(1) ReceiptID from @TableSugges)
		declare @ServiceModuleCode varchar(15) = (select top(1) ServiceModuleCode from @TableSugges)
		declare @ServiceCode varchar(15) = (select top(1) ServiceCode from @TableSugges)
		declare @Status int = (select top(1) Status from @TableSugges)
		declare @EmployeeDoctorName nvarchar(250)
		declare @ServiceMenuID int =0
		if exists(select ServiceMenuID from ServiceMenuForService where ServiceCode=@ServiceCode)
			set @ServiceMenuID = (select top(1) ServiceMenuID from ServiceMenuForService where ServiceCode=@ServiceCode)
		if @ServiceModuleCode='CDHA' and @Status=1
			begin
				select @EmployeeDoctorName=b.EmployeeName,@ResultCode=convert(varchar(20),a.RowID) from ServiceRadiologyEntry a inner join Employee b on a.EmployeeCodeDoctor=b.EmployeeCode where SuggestedID=@ReceiptID
			end
		else if @ServiceModuleCode='XN'
			begin
				select top(1) @EmployeeDoctorName=c.EmployeeName,@ResultCode=convert(varchar(20),a.RowID) from ServiceLaboratoryEntry a inner join ServiceLaboratoryDetail b on a.RowID=b.RowIDLaboratoryEnTry inner join Employee c on a.EmployeeCode=c.EmployeeCode where b.SuggestedID=@ReceiptID
			end
		else if @ServiceModuleCode='PTTT' and @Status=1
			begin
				select @EmployeeDoctorName=b.EmployeeName,@ResultCode=a.SurgeriesCode from Surgeries a inner join Employee b on a.EmployeeCode=b.EmployeeCode where IDSuggested=@ReceiptID
			end
		else if @ServiceModuleCode='TC'
			begin
				select top(1) @EmployeeDoctorName=c.EmployeeName,@ResultCode=a.ImmunizationRecordCode from ImmunizationRecord a inner join ImmunizationRecordDetail b on a.ImmunizationRecordCode=b.ImmunizationRecordCode inner join Employee c on b.EmployeeCodeDoctor=c.EmployeeCode where a.ReceiptID=@ReceiptID
			end
		else
			set @EmployeeDoctorName=''
		insert into @TableResult(ReceiptID,EmployeeDoctorName,ServiceCode,Status,ServiceMenuID,ResultCode) values(@ReceiptID,@EmployeeDoctorName,@ServiceCode,@Status,@ServiceMenuID,@ResultCode)
		delete from @TableSugges where ReceiptID=@ReceiptID
		set @Count=@Count-1
	end
	select a.ReceiptID,a.EmployeeDoctorName,a.ServiceCode,b.ServiceName,b1.ServiceCategoryCode,b1.ServiceCategoryName,b2.ServiceGroupName,b2.ServiceModuleCode,a.Status,'' as Preview,a.ServiceMenuID,a.ResultCode from @TableResult a inner join service b on a.ServiceCode = b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b1.ServiceGroupCode=b2.ServiceGroupCode
end
go
if not exists(select * from sys.columns where Name = N'Treatments' and Object_ID = Object_ID(N'MedicalEmergency'))
	alter table MedicalEmergency add Treatments nvarchar(200)
go
if not exists(select * from sys.columns where Name = N'AmountTransferPre' and Object_ID = Object_ID(N'report_NXT_CT'))
	alter table report_NXT_CT add AmountTransferPre numeric(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'AmountTransferPre' and Object_ID = Object_ID(N'report_NXT_TH'))
	alter table report_NXT_TH add AmountTransferPre numeric(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'AmountTransfer' and Object_ID = Object_ID(N'report_NXT_CT'))
	alter table report_NXT_CT add AmountTransfer numeric(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'AmountTransfer' and Object_ID = Object_ID(N'report_NXT_TH'))
	alter table report_NXT_TH add AmountTransfer numeric(18,4) default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BHYT' and b.name='KCBBDCodeFull')
	alter table BHYT add KCBBDCodeFull varchar(10)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Items' and b.name='VendorCode')
	alter table Items add VendorCode varchar(200)
go
------------- Update 28/11/2015
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccount' and b.name='ReasonCancel')
	alter table BanksAccount add ReasonCancel nvarchar(250)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ClinicInformation' and b.name='WorkingTimeLineFrom01')
	alter table ClinicInformation add WorkingTimeLineFrom01 char(5)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ClinicInformation' and b.name='WorkingTimeLineTo01')
	alter table ClinicInformation add WorkingTimeLineTo01 char(5)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ClinicInformation' and b.name='WorkingTimeLineFrom02')
	alter table ClinicInformation add WorkingTimeLineFrom02 char(5)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ClinicInformation' and b.name='WorkingTimeLineTo02')
	alter table ClinicInformation add WorkingTimeLineTo02 char(5)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ClinicInformation' and b.name='WorkingTimeLineFrom03')
	alter table ClinicInformation add WorkingTimeLineFrom03 char(5)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ClinicInformation' and b.name='WorkingTimeLineTo03')
	alter table ClinicInformation add WorkingTimeLineTo03 char(5)
go
------------- update 16/11/2015
--IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'PatientsOrder')
--begin
--CREATE TABLE PatientsOrder
--(
--	RowID numeric(18,0) identity(1,1),
--	PatientCode varchar(15)
--	CONSTRAINT pk_PatientsOrder PRIMARY KEY (PatientCode)
--)
--end
--go
--insert into PatientsOrder(PatientCode) select PatientCode from Patients
--go
------------- update 10/11/2015
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccount' and b.name='CancelDate')
	alter table BanksAccount add CancelDate datetime
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccount' and b.name='EmployeeCodeCancel')
	alter table BanksAccount add EmployeeCodeCancel varchar(20)
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ReportBHYT')
begin
CREATE TABLE ReportBHYT
(
	ReportID varchar(20),
	[BHYTPay] [decimal](18, 2) NOT NULL default 0,
	[PatientPay] [decimal](18, 2) NOT NULL default 0,
	[Exemptions] [decimal](18, 2) NOT NULL default 0,
	[TotalAmount] [decimal](18, 2) NOT NULL default 0,
	[PostingDate] [datetime] NOT NULL,
	[EmployeeCode] [varchar](50) NOT NULL,
	[EmployeeCodeCancel] [varchar](50),
	[PatientCode] [varchar](50) NOT NULL,
	[Cancel] [int] NOT NULL default 0,
	[TotalReal] [decimal](18, 2) NOT NULL default 0,
	[RateExemptions] [decimal](18, 2) NOT NULL default 0,
	[RateSurcharge] [decimal](18, 2) NOT NULL default 0,
	[TotalSurcharge] [decimal](18, 2) NOT NULL default 0,
	[ShiftWork] [char](2) NULL,
	CancelDate datetime,
	DateInto datetime,
	DateOut datetime,
	DepartmentCode varchar(50),
	ObjectCode int,
	Symptoms nvarchar(200),	Advices nvarchar(200),Treatments nvarchar(200),TackleCode int not null default 0,ICD10 varchar(20),ICD10More varchar(100),DiagnosisCustom nvarchar(150),AppointmentDate varchar(15),AppointmentContent nvarchar(150),
	Pulse varchar(5) ,Temperature varchar(5),BloodPressure varchar(5),BloodPressure1 varchar(5),[Weight] [varchar](5),Hight varchar(5),Breath varchar(5),
	Serial varchar(20),StartDate date,EndDate date,KCBBDCode varchar(10),TraiTuyen int default 0,Serial01 varchar(5),Serial02 varchar(5),Serial03 varchar(5),Serial04 varchar(5),Serial05 varchar(5),Serial06 varchar(5), ReferralPaper int default 0, RateBHYT int default 0
	CONSTRAINT pk_ReportBHYT PRIMARY KEY (ReportID)
)
end
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ReportBHYTDetail')
begin
CREATE TABLE ReportBHYTDetail
(
	ReportID varchar(20),
	PatientReceiveID numeric(18,0) not null,
	[PatientCode] [varchar](50) NOT NULL,
	[ServiceCode] [varchar](50) NOT NULL,
	[ServicePrice] [numeric](18, 2) NOT NULL default 0,
	[DisparityPrice] [numeric](18, 2) NOT NULL default 0,
	[ObjectCode] [int] NOT NULL,
	[Quantity] [int] NOT NULL default 0,
	[BHYTPay] [numeric](18, 2) NOT NULL default 0,
	[PatientPay] [numeric](18, 2) NOT NULL default 0,
	[Amount] [numeric](18, 2) NOT NULL default 0,
	IUDate datetime default getdate(),
	Ordinal int not null default 0,
	RateBHYT int not null default 0,
	BHYTPrice numeric(18,2) not null default 0,
	SalesPrice numeric(18,2) not null default 0,
	DateOfIssues varchar(5),
	Morning varchar(5),
	Noon varchar(5),
	Afternoon varchar(5),
	Evening varchar(5),
	Instruction nvarchar(200),
	DoseOf varchar(5),
	DoseOfPills varchar(5),
	RowIDPrice decimal(18,0)
	CONSTRAINT pk_ReportBHYTDetail PRIMARY KEY (ReportID,PatientReceiveID,PatientCode,Ordinal),
	CONSTRAINT fk_ReportBHYTDetail_ReportBHYT foreign  KEY (ReportID) references ReportBHYT(ReportID)
)
end
go
if exists(select name from sysobjects where name ='proIUReportBHYT')
	drop procedure proIUReportBHYT
go
create procedure proIUReportBHYT
(
	@ReportID varchar(20),@BHYTPay decimal(18, 2),@PatientPay decimal(18, 2),@Exemptions decimal(18, 2),
	@TotalAmount decimal(18, 2),@EmployeeCode varchar(50),@PatientCode varchar(50),@TotalReal decimal(18, 2),@RateExemptions decimal(18, 2),
	@RateSurcharge decimal(18, 2),@TotalSurcharge decimal(18, 2),@ShiftWork char(2),@DateInto datetime,@DateOut datetime,@DepartmentCode varchar(50),
	@Symptoms nvarchar(200),@Advices nvarchar(200),@Treatments nvarchar(200),@TackleCode int,@ICD10 varchar(20),@ICD10More varchar(100),
	@DiagnosisCustom nvarchar(150),@AppointmentDate varchar(15),@AppointmentContent nvarchar(150),
	@Pulse varchar(5),@Temperature varchar(5),@BloodPressure varchar(5),@BloodPressure1 varchar(5),@Weight varchar (5),@Hight varchar(5),@Breath varchar(5),
	@Serial varchar(20),@StartDate date,@EndDate date,@KCBBDCode varchar(10),@TraiTuyen int,@Serial01 varchar(5),@Serial02 varchar(5),
	@Serial03 varchar(5),@Serial04 varchar(5),@Serial05 varchar(5),@Serial06 varchar(5), @ReferralPaper int, @RateBHYT int, @ObjectCode int,@DateIntoEdit datetime ,
	@MATNTT int , @MATTRV int , @IDTreatmentResults int,@Capcuu int,@TongBH decimal(18, 2),@BNTraBH decimal(18, 2),@ICD10_Custom varchar(20)='',@ICD10Name_Custom nvarchar(500)='',
	@RowIDResult varchar(20) output
)
as
begin
	if exists(select PatientCode from ReportBHYT where ReportID=@ReportID and Cancel=0)
		begin
			update ReportBHYT set BHYTPay=@BHYTPay,PatientPay=@PatientPay,Exemptions=@Exemptions,TotalAmount=@TotalAmount,EmployeeCode=@EmployeeCode,
			TotalReal=@TotalReal,RateExemptions=@RateExemptions,RateSurcharge=@RateSurcharge,TotalSurcharge=@TotalSurcharge,ShiftWork=@ShiftWork,
			DateInto=@DateIntoEdit,DateOut=@DateOut,DepartmentCode=@DepartmentCode,Symptoms=@Symptoms,Advices=@Advices,Treatments=@Treatments,TackleCode=@TackleCode,
			ICD10=@ICD10,ICD10More=@ICD10More,DiagnosisCustom=@DiagnosisCustom,AppointmentDate=@AppointmentDate,AppointmentContent=@AppointmentContent,
			Pulse=@Pulse,Temperature=@Temperature,BloodPressure=@BloodPressure,BloodPressure1=@BloodPressure1,[Weight]=@Weight,Hight=@Hight,Breath=@Breath,
			Serial=@Serial,StartDate=@StartDate,EndDate=@EndDate,KCBBDCode=@KCBBDCode,TraiTuyen=@TraiTuyen,Serial01=@Serial01,Serial02=@Serial02,
			Serial03=@Serial03,Serial04=@Serial04,Serial05=@Serial05,Serial06=@Serial06,ReferralPaper=@ReferralPaper,RateBHYT=@RateBHYT,ObjectCode=@ObjectCode,
			MATNTT=@MATNTT,MATTRV=@MATTRV,IDTreatmentResults=@IDTreatmentResults,Capcuu = @Capcuu,TongBH=@TongBH,BNTraBH=@BNTraBH,ICD10_Custom=@ICD10_Custom,ICD10Name_Custom=@ICD10Name_Custom
			where ReportID=@ReportID and PatientCode=@PatientCode
			set @RowIDResult = @ReportID
		end
	else
	begin
		if exists( select PatientCode from PatientReceive where PatientCode=@PatientCode and CONVERT(date,CreateDate,103)=CONVERT(date,@DateInto,103) and ConfirmBV01=0)
		begin
			declare @RowIDTemp varchar(20)=(SELECT CONVERT(char(8),GETDATE(),112)+ CONVERT(varchar(2),(DATEPART(hour,GETDATE()))) + convert(varchar(2),DATEPART(mi,GETDATE())) + CONVERT(varchar(2),DATEPART(ss,GETDATE())) + CONVERT(varchar(4),DATEPART(millisecond,GETDATE())))
			set @RowIDResult = @RowIDTemp
			insert into ReportBHYT(BHYTPay,PatientPay,Exemptions,TotalAmount,EmployeeCode,TotalReal,RateExemptions,RateSurcharge,TotalSurcharge,ShiftWork,DateInto,DateOut,DepartmentCode,
			Symptoms,Advices,Treatments,TackleCode,ICD10,ICD10More,DiagnosisCustom,AppointmentDate,AppointmentContent,Pulse,Temperature,BloodPressure,BloodPressure1,Weight,Hight,Breath,
			Serial,StartDate,EndDate,KCBBDCode,TraiTuyen,Serial01,Serial02,Serial03,Serial04,Serial05,Serial06,ReferralPaper,PatientCode,ReportID,PostingDate,RateBHYT,ObjectCode,MATNTT,MATTRV,IDTreatmentResults,Capcuu,TongBH,BNTraBH,ICD10_Custom,ICD10Name_Custom)
			values(@BHYTPay,@PatientPay,@Exemptions,@TotalAmount,@EmployeeCode,@TotalReal,@RateExemptions,@RateSurcharge,@TotalSurcharge,@ShiftWork,@DateIntoEdit,@DateOut,@DepartmentCode,
			@Symptoms,@Advices,@Treatments,@TackleCode,@ICD10,@ICD10More,@DiagnosisCustom,@AppointmentDate,@AppointmentContent,@Pulse,@Temperature,@BloodPressure,@BloodPressure1,@Weight,@Hight,@Breath,
			@Serial,@StartDate,@EndDate,@KCBBDCode,@TraiTuyen,@Serial01,@Serial02,@Serial03,@Serial04,@Serial05,@Serial06,@ReferralPaper,@PatientCode,@RowIDTemp,GETDATE(),@RateBHYT,@ObjectCode,@MATNTT,@MATTRV,@IDTreatmentResults,@Capcuu,@TongBH,@BNTraBH,@ICD10_Custom,@ICD10Name_Custom)
		end
	end
end
go
if exists(select name from sysobjects where name ='proIUReportBHYTDetail')
	drop procedure proIUReportBHYTDetail
go
CREATE procedure proIUReportBHYTDetail
(
	@ReportID varchar(20),@PatientReceiveID numeric(18,0),@PatientCode varchar(50),@ServiceCode varchar(50),@ServicePrice numeric(18, 2),@DisparityPrice numeric(18, 2),
	@ObjectCode int,@Quantity numeric(18, 2),@BHYTPay numeric(18, 2),@PatientPay numeric(18, 2),@Amount numeric(18, 2),@Ordinal int,@RateBHYT int,@BHYTPrice numeric(18,2),
	@SalesPrice numeric(18,2),@DateOfIssues varchar(5),@Morning varchar(5),@Noon varchar(5),@Afternoon varchar(5),@Evening varchar(5),@Instruction nvarchar(200),
	@DoseOf varchar(5),	@DoseOfPills varchar(5), @RowIDPrice decimal(18,0),@ServiceCode_PK varchar(20),@SODKGP varchar(20)
)
as
begin
	if exists(select ServiceCode from ReportBHYTDetail where PatientCode=@PatientCode and ReportID=@ReportID and Ordinal=@Ordinal)
		begin
			update ReportBHYTDetail set ServiceCode=@ServiceCode,ServicePrice=@ServicePrice,DisparityPrice=@DisparityPrice,ObjectCode=@ObjectCode,Quantity=@Quantity,BHYTPay=@BHYTPay,PatientPay=@PatientPay,Amount=@Amount,IUDate=GETDATE(),Ordinal=@Ordinal,SalesPrice=@SalesPrice,BHYTPrice=@BHYTPrice,RateBHYT=@RateBHYT,
			DateOfIssues=@DateOfIssues,Morning=@Morning,Noon=@Noon,Afternoon=@Afternoon,Evening=@Evening,Instruction=@Instruction,RowIDPrice=@RowIDPrice,ServiceCode_PK=@ServiceCode_PK,SODKGP=@SODKGP
			where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode and ReportID=@ReportID and Ordinal=@Ordinal
		end
	else
	begin
		set @Ordinal = (select ISNULL(MAX(Ordinal),0)+1 from ReportBHYTDetail where ReportID=@ReportID)
		insert into ReportBHYTDetail(ReportID,PatientReceiveID,PatientCode,ServiceCode,ServicePrice,DisparityPrice,ObjectCode,Quantity,BHYTPay,PatientPay,Amount,IUDate,Ordinal,SalesPrice,BHYTPrice,RateBHYT,DateOfIssues,Morning,Noon,Afternoon,Evening,Instruction,DoseOf,DoseOfPills,RowIDPrice,ServiceCode_PK,SODKGP) 
		values(@ReportID,@PatientReceiveID,@PatientCode,@ServiceCode,@ServicePrice,@DisparityPrice,@ObjectCode,@Quantity,@BHYTPay,@PatientPay,@Amount,GETDATE(),@Ordinal,@SalesPrice,@BHYTPrice,@RateBHYT,@DateOfIssues,@Morning,@Noon,@Afternoon,@Evening,@Instruction,@DoseOf,@DoseOfPills,@RowIDPrice,@ServiceCode_PK,@SODKGP)
	end
	update SuggestedServiceReceipt set PaidBV = 1 where ServiceCode = @ServiceCode and PatientCode = @PatientCode and RefID = @PatientReceiveID
end
go
if exists(select name from sysobjects where name ='proDel_ReportBHYT')
	drop procedure proDel_ReportBHYT
go
create procedure proDel_ReportBHYT
(
	@ReportID varchar(20),
	@iresult int output
)
as
begin
	update PatientReceive set ConfirmBV01=0 where PatientReceiveID in(select distinct PatientReceiveID from ReportBHYTDetail where ReportID=@ReportID)
	delete ReportBHYTDetail where ReportID=@ReportID
	delete ReportBHYT where ReportID=@ReportID
	--update ReportBHYT set Cancel=1,EmployeeCodeCancel=@EmployeeCode,CancelDate=GETDATE() where ReportID=@ReportID
	set @iresult =1
end
go
if exists(select name from sysobjects where name ='proDel_ReportBHYTDetail')
	drop procedure proDel_ReportBHYTDetail
go
create procedure proDel_ReportBHYTDetail
(
	@ReportID varchar(20),
	@iresult int output
)
as
begin
	delete ReportBHYTDetail where ReportID=@ReportID
	set @iresult =1
end
go
if exists(select name from sysobjects where name ='proUpd_ReportBHYT')
	drop procedure proUpd_ReportBHYT
go
create procedure [dbo].[proUpd_ReportBHYT]
(
	@ReportID varchar(20),
	@EmployeeCode varchar(50),
	@iresult int output
)
as
begin
	update PatientReceive set ConfirmBV01=0 where PatientReceiveID in(select distinct PatientReceiveID from ReportBHYTDetail where ReportID=@ReportID)
	update SuggestedServiceReceipt set PaidBV = 0 where  RefID in (select distinct PatientReceiveID from ReportBHYTDetail where ReportID=@ReportID)
	--delete ReportBHYTDetail where ReportID=@ReportID
	--delete ReportBHYT where ReportID=@ReportID
	update ReportBHYT set Cancel=1,EmployeeCodeCancel=@EmployeeCode,CancelDate=GETDATE() where ReportID=@ReportID
	
	set @iresult =1
end
go
if exists(select name from sysobjects where name ='proGet_ReportBHYT')
	drop procedure proGet_ReportBHYT
go
create procedure proGet_ReportBHYT
(
	@ReportID varchar(20)
)
as
begin
	select a.ReportID,a.PatientCode,b.PatientName,(case when b.PatientGender=0 then N'Nữ' else N'Nam' end) PatientGenderName,b.PatientBirthyear,b.PatientAge,[dbo].func_PatientOfAddressFull(b.PatientAddress,b1.WardName,b2.DistrictName,b3.ProvincialName) PatientAddress,a.Serial,a.Serial01,a.Serial02,a.Serial03,a.Serial04,a.Serial05,a.Serial06,a.StartDate,a.EndDate,a.KCBBDCode,c.KCBBDName,a.ReferralPaper,a.RateBHYT,
	 a.TongBH as TotalAmount,a.BHYTPay, a.BNTraBH as PatientPay,a.Exemptions,a.BNTraBH as TotalReal,a.RateExemptions,a.RateSurcharge,a.TotalSurcharge,a.Symptoms,a.Advices,a.Treatments,a.DiagnosisCustom,a.AppointmentDate,a.AppointmentContent,a.Pulse,a.Temperature,a.BloodPressure,a.BloodPressure1,a.Weight,a.Hight,a.Breath,(case when b.PatientGender=1 then 1 else 0 end) PatientGenderMale,(case when b.PatientGender=0 then 1 else 0 end) PatientGenderFeMale,
	(case when a.TraiTuyen = 1 then 1 else 0 end) TraiTuyen,(case when a.TraiTuyen=0 then 1 else 0 end) DungTuyen,DATEPART(HOUR, a.DateInto)HHvv,DATEPART(MINUTE, a.DateInto)MIvv,DATEPART(HOUR, a.DateOut)HHrv,DATEPART(MINUTE, a.DateOut)MIrv,(datediff(DD,a.DateInto,a.DateOut)+1) NgayDieuTri,(case when a.ObjectCode=1 then 1 else 0 end) BHYT,(case when a.ObjectCode<>1 then 1 else 0 end) NoneBHYT,a.DateInto,a.DateOut,d.ObjectName
	--,e.DiagnosisCode,e.DiagnosisName
	, '' as DepartmentName,'' as ICD10,'' as ICD10More,(case when a.capcuu=1 then 1 else 0 end) Capcuu
	,a2.EmployeeName,a.ICD10_Custom DiagnosisCode,a.ICD10Name_Custom DiagnosisName
	from ReportBHYT a inner join Patients b on a.PatientCode=b.PatientCode left join Catalog_Ward b1 on b.WardCode=b1.WardCode left join Catalog_District b2 on b.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on b.ProvincialCode=b3.ProvincialCode
	inner join KCBBD c on REPLACE(a.KCBBDCode,' ','')=REPLACE((c.ProvincialIDBHYT+'-'+c.KCBBDCode),' ','') inner join [Object] d on a.ObjectCode=d.ObjectCode 
	--left join Diagnosis e on a.ICD10=e.RowID
	inner join Employee a2 on a.EmployeeCode = a2.EmployeeCode
	where a.ReportID=@ReportID
end
go
if exists(select name from sysobjects where name ='proGet_ReportBHYTDetail')
	drop procedure proGet_ReportBHYTDetail
go
create procedure proGet_ReportBHYTDetail
(
	@ReportID varchar(20),
	@Type int=0
)
as
begin
	if(@Type=0)
	begin
		select a.ServiceCode,b.ServiceName,b1.ServiceCategoryName,b2.ServiceGroupName,b3.UnitOfMeasureName,a.Quantity,a.SalesPrice,a.DisparityPrice,a.Amount,a.PatientPay,a.BHYTPay
		from ReportBHYTDetail a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b.ServiceGroupCode=b2.ServiceGroupCode
		inner join UnitOfMeasure b3 on b.UnitOfMeasureCode=b3.UnitOfMeasureCode
		where a.ReportID=@ReportID and b2.ServiceModuleCode <>'KCB' and a.ObjectCode = 1
	end
	else if(@Type=1)
	begin
		select a.ServiceCode,[dbo].[func_GetActive](b.Active,'+',b.ItemName,b.ItemContent) ItemName,b4.UsageName,b1.ItemCategoryName ServiceCategoryName,b2.GroupName ServiceGroupName,b3.UnitOfMeasureName,a.Quantity,a.Instruction,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening
		from ReportBHYTDetail a inner join Items b on a.ServiceCode=b.ItemCode inner join ItemCategory b1 on b.ItemCategoryCode=b1.ItemCategoryCode inner join ItemGroup b2 on b1.GroupCode=b2.GroupCode
		inner join UnitOfMeasure b3 on b.UnitOfMeasureCode=b3.UnitOfMeasureCode inner join Usage b4 on b.UsageCode=b4.UsageCode
		where a.ReportID=@ReportID and a.ObjectCode=1
	end
	else if(@Type=3)
	begin
		select a.ServiceCode,b.ServiceName,b1.ServiceCategoryName,b2.ServiceGroupName GroupName,b3.UnitOfMeasureName,a.Quantity,a.SalesPrice,a.BHYTPrice,a.ServicePrice,a.Amount,a.PatientPay,a.BHYTPay,0 as DisparityPrice,b4.STT,c.ObjectName
		from ReportBHYTDetail a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b.ServiceGroupCode=b2.ServiceGroupCode
		inner join UnitOfMeasure b3 on b.UnitOfMeasureCode=b3.UnitOfMeasureCode inner join [Object] c on a.ObjectCode=c.ObjectCode inner join ServiceModule b4 on b2.ServiceModuleCode=b4.ServiceModuleCode
		where a.ReportID=@ReportID and a.ObjectCode = 1
		union all
		select a.ServiceCode,[dbo].[func_GetActive](b.Active,'+',b.ItemName,b.ItemContent) ServiceName,b1.ItemCategoryName ServiceCategoryName,b2.GroupName,b3.UnitOfMeasureName,a.Quantity,a.SalesPrice,a.BHYTPrice,a.ServicePrice,a.Amount,a.PatientPay,a.BHYTPay,0 as DisparityPrice,b5.STT,c.ObjectName
		from ReportBHYTDetail a inner join Items b on a.ServiceCode=b.ItemCode inner join ItemCategory b1 on b.ItemCategoryCode=b1.ItemCategoryCode inner join ItemGroup b2 on b1.GroupCode=b2.GroupCode
		inner join UnitOfMeasure b3 on b.UnitOfMeasureCode=b3.UnitOfMeasureCode inner join Usage b4 on b.UsageCode=b4.UsageCode  inner join [Object] c on a.ObjectCode=c.ObjectCode inner join ServiceModule b5 on b2.ServiceModuleCode=b5.ServiceModuleCode
		where a.ReportID=@ReportID and a.ObjectCode = 1
		order by STT
	end
	else
	begin
		select a.ServiceCode,b.ServiceName,b1.ServiceCategoryName,b2.ServiceGroupName GroupName,b3.UnitOfMeasureName,a.Quantity,a.SalesPrice,a.BHYTPrice,a.ServicePrice,a.Amount,a.PatientPay,a.BHYTPay,a.DisparityPrice,b4.STT,c.ObjectName
		from ReportBHYTDetail a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b.ServiceGroupCode=b2.ServiceGroupCode
		inner join UnitOfMeasure b3 on b.UnitOfMeasureCode=b3.UnitOfMeasureCode inner join [Object] c on a.ObjectCode=c.ObjectCode inner join ServiceModule b4 on b2.ServiceModuleCode=b4.ServiceModuleCode
		where a.ReportID=@ReportID
		union all
		select a.ServiceCode,[dbo].[func_GetActive](b.Active,'+',b.ItemName,b.ItemContent) ServiceName,b1.ItemCategoryName ServiceCategoryName,b2.GroupName,b3.UnitOfMeasureName,a.Quantity,a.SalesPrice,a.BHYTPrice,a.ServicePrice,a.Amount,a.PatientPay,a.BHYTPay,a.DisparityPrice,b5.STT,c.ObjectName
		from ReportBHYTDetail a inner join Items b on a.ServiceCode=b.ItemCode inner join ItemCategory b1 on b.ItemCategoryCode=b1.ItemCategoryCode inner join ItemGroup b2 on b1.GroupCode=b2.GroupCode
		inner join UnitOfMeasure b3 on b.UnitOfMeasureCode=b3.UnitOfMeasureCode inner join Usage b4 on b.UsageCode=b4.UsageCode  inner join [Object] c on a.ObjectCode=c.ObjectCode inner join ServiceModule b5 on b2.ServiceModuleCode=b5.ServiceModuleCode
		where a.ReportID=@ReportID
		order by STT
	end
end
go
if exists(select name from sysobjects where name ='proGet_ReportBHYTThuPhi')
	drop procedure proGet_ReportBHYTThuPhi
go
create procedure proGet_ReportBHYTThuPhi
(
	@ReportID varchar(20)
)
as
begin
	select a.ReportID,a.PatientCode,b.PatientName,(case when b.PatientGender=0 then N'Nữ' else N'Nam' end) PatientGenderName,b.PatientBirthyear,b.PatientAge,[dbo].func_PatientOfAddressFull(b.PatientAddress,b1.WardName,b2.DistrictName,b3.ProvincialName) PatientAddress,a.Serial,a.Serial01,a.Serial02,a.Serial03,a.Serial04,a.Serial05,a.Serial06,a.StartDate,a.EndDate,a.KCBBDCode,c.KCBBDName,a.ReferralPaper,a.RateBHYT,
	 a.TotalAmount,a.BHYTPay, a.PatientPay,a.Exemptions,a.TotalReal,a.RateExemptions,a.RateSurcharge,a.TotalSurcharge,a.Symptoms,a.Advices,a.Treatments,a.DiagnosisCustom,a.AppointmentDate,a.AppointmentContent,a.Pulse,a.Temperature,a.BloodPressure,a.BloodPressure1,a.Weight,a.Hight,a.Breath,(case when b.PatientGender=1 then 1 else 0 end) PatientGenderMale,(case when b.PatientGender=0 then 1 else 0 end) PatientGenderFeMale,
	(case when a.TraiTuyen = 1 then 1 else 0 end) TraiTuyen,(case when a.TraiTuyen=0 then 1 else 0 end) DungTuyen,DATEPART(HOUR, a.DateInto)HHvv,DATEPART(MINUTE, a.DateInto)MIvv,DATEPART(HOUR, a.DateOut)HHrv,DATEPART(MINUTE, a.DateOut)MIrv,(datediff(DD,a.DateInto,a.DateOut)+1) NgayDieuTri,(case when a.ObjectCode=1 then 1 else 0 end) BHYT,(case when a.ObjectCode<>1 then 1 else 0 end) NoneBHYT,a.DateInto,a.DateOut,d.ObjectName,e.DiagnosisCode,e.DiagnosisName, '' as DepartmentName,'' as ICD10,'' as ICD10More,(case when a.capcuu=1 then 1 else 0 end) Capcuu
	from ReportBHYT a inner join Patients b on a.PatientCode=b.PatientCode left join Catalog_Ward b1 on b.WardCode=b1.WardCode left join Catalog_District b2 on b.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on b.ProvincialCode=b3.ProvincialCode
	inner join KCBBD c on REPLACE(a.KCBBDCode,' ','')=REPLACE((c.ProvincialIDBHYT+'-'+c.KCBBDCode),' ','') inner join [Object] d on a.ObjectCode=d.ObjectCode left join Diagnosis e on a.ICD10=e.RowID
	where a.ReportID=@ReportID
end
go

if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccountDetail' and b.name='BHYTPay')
	alter table BanksAccountDetail add BHYTPay numeric(18,2) not null default 0
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccountDetail' and b.name='PatientPay')
	alter table BanksAccountDetail add PatientPay numeric(18,2) not null default 0
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='PatientReceive' and b.name='BarcodeBHYT')
	alter table PatientReceive add BarcodeBHYT nvarchar(max)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='RealMedicinesForPatientsDetail' and b.name='Paid')
	alter table RealMedicinesForPatientsDetail add Paid int not null default 0
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='RealMedicinesForPatientsDetail' and b.name='BanksAccountCode')
	alter table RealMedicinesForPatientsDetail add BanksAccountCode varchar(50)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicinesForPatientsDetail' and b.name='Paid')
	alter table MedicinesForPatientsDetail add Paid int not null default 0
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicinesForPatientsDetail' and b.name='BanksAccountCode')
	alter table MedicinesForPatientsDetail add BanksAccountCode varchar(50)
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'InventoryLimited')
begin
CREATE TABLE InventoryLimited
(
	EmployeeCode varchar(50),
	ItemCode varchar(50),
	RepositoryCode varchar(50),
	Quantity int not null default 0,
	IDate datetime default getdate() not null,
	IEmployeeCode varchar(50)
	CONSTRAINT InventoryLimited_pk PRIMARY KEY (RepositoryCode,ItemCode)
)
end
go
if exists(select name from sysobjects where name ='pro_InsInventoryLimited')
	drop procedure pro_InsInventoryLimited
go
create procedure pro_InsInventoryLimited
(
	@ItemCode varchar(50),
	@RepositoryCode varchar(50),
	@Quantity int,
	@EmployeeCode varchar(50),
	@IEmployeeCode varchar(50)
)
as
begin
	if exists(select ItemCode from InventoryLimited where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode)
		begin
			update InventoryLimited set Quantity=@Quantity, EmployeeCode=@EmployeeCode where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode
		end
	else
	begin
		insert into InventoryLimited(ItemCode,RepositoryCode,Quantity,EmployeeCode,IEmployeeCode) values(@ItemCode,@RepositoryCode,@Quantity,@EmployeeCode,@IEmployeeCode)
	end
end
go
-- Update 02/08/2015
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='PatientReceive' and b.name='ConfirmBV01')
	alter table PatientReceive add ConfirmBV01 int not null default 0
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='WarehousingDetail' and b.name='BHYTPrice')
	alter table WarehousingDetail add BHYTPrice decimal(18,3) not null default 0
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicalEmergency' and b.name='Symptoms')
	alter table MedicalEmergency add Symptoms nvarchar(250)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Items' and b.name='ListService')
	alter table Items add ListService int default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SystemParameter' and b.name='VersionNo')
	alter table SystemParameter add VersionNo varchar(20)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BHYT' and b.name='ReferralPaper')
	alter table BHYT add ReferralPaper int default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServiceRadiologyEntry' and b.name='Note')
	alter table ServiceRadiologyEntry add Note nvarchar(200)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicinesForPatients' and b.name='EmployeeCodeDone')
	alter table MedicinesForPatients add EmployeeCodeDone varchar(20)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicinesForPatients' and b.name ='Done')
	alter table MedicinesForPatients add Done int default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Items' and b.name='DisparityPrice')
	alter table Items add DisparityPrice numeric(18,4) default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='KCBBD' and b.name ='ProvincialIDBHYT')
	alter table KCBBD add ProvincialIDBHYT varchar(3)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Catalog_Provincial' and b.name ='ProvincialIDBHYT')
	alter table Catalog_Provincial add ProvincialIDBHYT varchar(3)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicalPrescriptionDetail' and b.name ='BHYT')
	alter table MedicalPrescriptionDetail add BHYT int default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Items' and b.name ='Note')
	alter table Items add Note nvarchar(100)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BHYT' and b.name ='Serial01')
	alter table BHYT add Serial01 varchar(5)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BHYT' and b.name ='Serial02')
	alter table BHYT add Serial02 varchar(5)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BHYT' and b.name ='Serial03')
	alter table BHYT add Serial03 varchar(5)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BHYT' and b.name ='Serial04')
	alter table BHYT add Serial04 varchar(5)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BHYT' and b.name ='Serial05')
	alter table BHYT add Serial05 varchar(5)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BHYT' and b.name ='Serial06')
	alter table BHYT add Serial06 varchar(5)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ImmunizationRecordDetail' and b.name ='EmployeeCodeDoctor')
	alter table ImmunizationRecordDetail add EmployeeCodeDoctor varchar(50)
go
-- Update 12/07/2015
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ImmunizationRecordDetail' and b.name ='EmployeeCodeDoctor')
	alter table ImmunizationRecordDetail add EmployeeCodeDoctor varchar(50)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccount' and b.name ='NoInvoice')
	alter table BanksAccount add NoInvoice varchar(50)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicalRecord' and b.name ='Treatments')
	alter table MedicalRecord add Treatments nvarchar(200)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Warehousing' and b.name ='ShiftWork')
	alter table Warehousing add ShiftWork char(2) 
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicinesForPatients' and b.name ='ShiftWork')
	alter table MedicinesForPatients add ShiftWork char(2) 
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicinesRetail' and b.name ='ShiftWork')
	alter table MedicinesRetail add ShiftWork char(2) 
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServiceLaboratoryEntry' and b.name ='ShiftWork')
	alter table ServiceLaboratoryEntry add ShiftWork char(2) 
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccount' and b.name ='ShiftWork')
	alter table BanksAccount add ShiftWork char(2) 
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='RealMedicinesForPatients' and b.name ='ShiftWork')
	alter table RealMedicinesForPatients add ShiftWork char(2) 
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Surgeries' and b.name ='ShiftWork')
	alter table Surgeries add ShiftWork char(2) 
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ImmunizationRecordDetail' and b.name ='ShiftWork')
	alter table ImmunizationRecordDetail add ShiftWork char(2) 
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ImmunizationRecord' and b.name ='ShiftWork')
	alter table ImmunizationRecord add ShiftWork char(2) 
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServiceRadiologyEntry' and b.name ='ShiftWork')
	alter table ServiceRadiologyEntry add ShiftWork char(2) 
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicalRecord' and b.name ='ShiftWork')
	alter table MedicalRecord add ShiftWork char(2) 
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SuggestedServiceReceipt' and b.name ='ShiftWork')
	alter table SuggestedServiceReceipt add ShiftWork char(2) 
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='PatientReceive' and b.name ='ShiftWork')
	alter table PatientReceive add ShiftWork char(2) 
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ImmunizationTimesDetail' and b.name ='DayTimesCome')
	alter table ImmunizationTimesDetail add DayTimesCome int default 0 not null
go
--- exec proGetImmunizationHistoryTimes 'TC1','15003641',7252,'DV000028'
if exists(select name from sysobjects where name ='proGetImmunizationHistoryTimes')
	drop procedure proGetImmunizationHistoryTimes
go
create procedure proGetImmunizationHistoryTimes
(
	@ImmunizationRecordCode varchar(15),
	@PatientCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@ServiceCode varchar(50)
)
as
begin
	if exists(select PatientCode from ImmunizationRecord where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID and ImmunizationRecordCode=@ImmunizationRecordCode)
		begin
			select b.ImmunizationRecordCode,a.DoseNoID as RowIDDoseNo,b.LotNo,b.Note,b.Content,CONVERT(char(10),b.AppointmentDate,103) AppointmentDate,b.AppointmentContent,a1.DoseNoName,b.EmployeeCode,b2.MedicalRecordCode,CONVERT(char(10),b.DateGiven,103) DateGiven,b.ImmunizationRecordDetailCode,a.ServiceCode,a.DayTimes,a.DayTimesCome,a.Warning
			from ImmunizationTimesDetail a left join ImmunizationRecordDetail b on a.DoseNoID=b.RowIDDoseNo and b.ImmunizationRecordCode=@ImmunizationRecordCode
			--left join ImmunizationRecord b1 on b.ImmunizationRecordCode=b1.ImmunizationRecordCode and b1.PatientCode=@PatientCode and b1.PatientReceiveID=@PatientReceiveID and b1.ImmunizationRecordCode=@ImmunizationRecordCode
			inner join CatalogDoseNo a1 on a.DoseNoID=a1.RowID 
			left join MedicalRecord b2 on b.ImmunizationRecordDetailCode=b2.ReferenceCode and b2.TypeMedical=3 
			where a.ServiceCode=@ServiceCode order by RowIDDoseNo 
		end
	else
		begin
			select '' as ImmunizationRecordCode,a.DoseNoID as RowIDDoseNo,'' as LotNo,'' as Note,'' as Content,'' as AppointmentDate,'' as AppointmentContent,a1.DoseNoName,'' as EmployeeCode,'' as MedicalRecordCode,'' as DateGiven,'' as ImmunizationRecordDetailCode,a.ServiceCode,a.DayTimes,a.DayTimesCome,a.Warning
			from ImmunizationTimesDetail a  inner join CatalogDoseNo a1 on a.DoseNoID=a1.RowID 
			where a.ServiceCode=@ServiceCode order by RowIDDoseNo 
		end
end
go
if exists(select name from sysobjects where name like'proGetSerialNumberLabEntry')
	drop procedure proGetSerialNumberLabEntry
go
create procedure proGetSerialNumberLabEntry
(
	@ServiceCategoryCode varchar(50),
	@PatientCode varchar(50),
	@PatientReceiveID decimal,
	@LabPathologicalID int,
	@Result int output
)
as
begin
	if not exists(select PatientCode from ServiceLaboratoryEntry where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID and LabPathologicalID=@LabPathologicalID and CONVERT(date,PostingDate,103)=CONVERT(date,GETDATE(),103))
		begin
			set @Result = (select (ISNULL( max(convert(int,STT)),1)+1) STT from ServiceLaboratoryEntry where ServiceCategoryCode=@ServiceCategoryCode and CONVERT(date,PostingDate,103)=CONVERT(date,GETDATE(),103))
		end
	else
		begin
			set @Result = (select STT from ServiceLaboratoryEntry where LabPathologicalID=@LabPathologicalID and PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID and CONVERT(date,PostingDate,103)=CONVERT(date,GETDATE(),103))
		end
end
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServiceLaboratoryEntry' and b.name ='OrderDate')
	alter table ServiceLaboratoryEntry add OrderDate varchar(20)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServiceLaboratoryEntry' and b.name ='EmployeeCodeOrder')
	alter table ServiceLaboratoryEntry add EmployeeCodeOrder varchar(20)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServiceLaboratoryEntry' and b.name ='EmployeeDoctorCodeOrder')
	alter table ServiceLaboratoryEntry add EmployeeDoctorCodeOrder varchar(20)
go
-- Update 01/07/2015
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicalRecord' and b.name ='Hide')
	alter table MedicalRecord add Hide int default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='LaboratoryPackageDetail' and b.name ='ValuesEntry')
	alter table LaboratoryPackageDetail add ValuesEntry nvarchar(50) 
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServicePackageDetail' and b.name ='Serial')
	alter table ServicePackageDetail add Serial int default 1 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicalRecord' and b.name ='TypeMedical')
	alter table MedicalRecord add TypeMedical int default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServiceLaboratoryEntry' and b.name ='DepartmentCodeOrder')
	alter table ServiceLaboratoryEntry add DepartmentCodeOrder varchar(10)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServiceLaboratoryEntry' and b.name ='LabPathologicalID')
	alter table ServiceLaboratoryEntry add LabPathologicalID int default 1 not null
go
--Update 17/06/15
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ServiceLimitForEmployee')
begin
CREATE TABLE ServiceLimitForEmployee
(
	EmployeeCode varchar(50),
	ServiceCode varchar(50),
	IDate datetime default getdate() not null,
	IEmployeeCode varchar(50)
	CONSTRAINT ServiceLimitForEmployee_pk PRIMARY KEY (EmployeeCode,ServiceCode)
)
end
go
if exists(select name from sysobjects where name like'proInsUpd_ServiceLimit')
	drop procedure proInsUpd_ServiceLimit
go
create procedure proInsUpd_ServiceLimit
(
	@ServiceCode varchar(50),
	@EmployeeCode varchar(50),
	@IEmployeeCode varchar(50),
	@Result int output
)
as
begin
	if not exists(select ServiceCode from ServiceLimitForEmployee where ServiceCode=@ServiceCode and EmployeeCode=@EmployeeCode)
		begin
			insert into ServiceLimitForEmployee(EmployeeCode,ServiceCode,IEmployeeCode,IDate) values(@EmployeeCode,@ServiceCode,@IEmployeeCode,GETDATE())
			set @Result =1
		end
	else
		set @Result =0
end
go
--End update 17/06/15
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServiceMenu' and b.name ='Hide')
	alter table ServiceMenu add Hide int default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccount' and b.name ='CashierCode')
	alter table BanksAccount add CashierCode varchar(50)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicinesRetail' and b.name ='PatientReceiveClinic')
	alter table MedicinesRetail add PatientReceiveClinic varchar(30)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='PatientReceive' and b.name ='PatientReceiveClinic')
	alter table PatientReceive add PatientReceiveClinic varchar(30)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='PatientReceive' and b.name ='OrderNumber')
	alter table PatientReceive add OrderNumber int default 1 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServiceRadiologyEntry' and b.name ='ServiceGroupCode')
	alter table ServiceRadiologyEntry add ServiceGroupCode varchar(50) default 'CDHA' not null
go
--IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'LaboratoryTypeResult')
--	drop table LaboratoryTypeResult
--go
--CREATE TABLE LaboratoryTypeResult(
--	ServiceCode varchar(50) NOT NULL,
--	IDate datetime default getdate(),
--	TypeResult int default 0,
--	EmployeeCode varchar(50),
--	CONSTRAINT LaboratoryTypeResult_pk PRIMARY KEY (ServiceCode)
--)
--go
if exists(select name from sysobjects where name like'proInsUpd_LabTypeResult')
	drop procedure proInsUpd_LabTypeResult
go
create procedure proInsUpd_LabTypeResult
(
	@ServiceCode varchar(50),
	@TypeResult int,
	@EmployeeCode varchar(50),
	@Result int output
)
as
begin
	if exists(select ServiceCode from LaboratoryTypeResult where ServiceCode=@ServiceCode)
		update LaboratoryTypeResult set TypeResult=@TypeResult,EmployeeCode=@EmployeeCode where ServiceCode=@ServiceCode
	else
		insert into LaboratoryTypeResult(ServiceCode,IDate,TypeResult,EmployeeCode) values(@ServiceCode,GETDATE(),@TypeResult,@EmployeeCode)
	set @Result =1
end
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServiceLaboratoryEntry' and b.name ='PostingDateResult')
	alter table ServiceLaboratoryEntry add PostingDateResult varchar(25) 
go
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Report_TagRepository')
	drop table Report_TagRepository
go
CREATE TABLE Report_TagRepository(
	ItemCode varchar(50) NOT NULL,
	RepositoryCode varchar(50) NOT NULL,
	AmountBeginPre numeric(18, 4) default 0 NOT NULL,
	AmountExportPre numeric(18, 4) default 0 NOT NULL,
	AmountImportPre numeric(18, 4) default 0 NOT NULL,
	AmountRepaidPre numeric(18, 4) default 0 NOT NULL,
	AmountRepaidVenPre numeric(18, 4) default 0 NOT NULL,
	AmountEndPre numeric(18, 4) default 0 NOT NULL,
	AmountKhaiTonPre decimal(18,4) not null default 0,
	AmountImportRepaidPre decimal(18,4) not null default 0,
	AmountTransferPre decimal(18,4) not null default 0,
	AmountImportTransferPre decimal(18,4) not null default 0,
	RowNumber int default 1 not null
)
go
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Report_TagRepositoryDetail')
	drop table Report_TagRepositoryDetail
go
CREATE TABLE Report_TagRepositoryDetail(
	ItemCode varchar(50) NOT NULL,
	RepositoryCode varchar(50) NOT NULL,
	WorkingDate varchar(10),
	ExportDate varchar(10),
	ImportDate varchar(10),
	Content nvarchar(100),
	Note nvarchar(100),
	AmountImport numeric(18, 2) default 0 NOT NULL,
	AmountExport numeric(18, 2) default 0 NOT NULL,
	AmountExists numeric(18, 2) default 0 NOT NULL,
	RowNumber int default 1 not null
)
go
if exists(select name from sysobjects where name like'pro_Report_TagGeneral')
	drop procedure pro_Report_TagGeneral
go
create procedure pro_Report_TagGeneral
(
	@RepositoryCode varchar(50),
	@FromDate date,
	@ToDate date,
	@ItemCode varchar(50)
)
as
begin
	declare @DateBegin datetime =getdate()
	if exists(select RowID from SystemParameter where RowID=208 and [Values]=1)
		set @DateBegin =(select convert(date,DateReport,103) DateForm from RepositoryCatalog where RepositoryCode=@RepositoryCode)
	else
		set @DateBegin = @FromDate
	declare @AmountBegin numeric(18,4) =0,@AmountImport numeric(18,4)=0,@AmountExport numeric(18,4)=0,@HTKHO numeric(18,4)=0,@AmountExportRetail numeric(18,4)=0, @AmountExportVendor numeric(18,4)=0
	declare @DateEnd date
	declare @Shipment nvarchar(250)
	declare @Count numeric(18,0)=0
	declare @RowIDGumshoe numeric(18,0)
	declare @RowNumber int =1
	declare @WarehousingCode varchar(50)=''
	declare @ExpWarehousingCode varchar(50)=''
	declare @QuantityTemp numeric(18,4)=0
	declare @GroupCode int=0
	set @GroupCode =( select RepositoryGroupCode from RepositoryCatalog where RepositoryCode=@RepositoryCode)
	delete from Report_TagRepository
	delete from Report_TagRepositoryDetail
	--Lay du lieu truoc thoi gian lay bao cao
	insert into Report_TagRepository(ItemCode,RepositoryCode,AmountKhaiTonPre,AmountImportPre,AmountImportRepaidPre,AmountExportPre,AmountRepaidPre,AmountRepaidVenPre,AmountTransferPre,AmountImportTransferPre)
	select a.ItemCode,a.RepositoryCode,SUM(a.Amount_KhaiTonDau) AmountKhaiTonPre, SUM(a.Amount_NhapMoi) AmountImportPre, SUM(a.Amount_NhanHoanTraKho) AmountImportRepaidPre,(SUM(a.Amount_XuatBan) +SUM(a.Amount_XuatBN)) AmountExportPre,SUM(a.Amount_HTKho) AmountRepaidPre,SUM(a.Amount_HTNCC) AmountRepaidVenPre,SUM(a.Amount_XuatCK) AmountTransferPre,SUM(a.Amount_NhanCK) AmountImportTransferPre
	from (
	-------- 1 Nhap moi kho, cac he thong kho khong phai kho chan
	select b.ItemCode,a.RepositoryCode, ISNULL(sum(b.Quantity),0) as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice
	 from Warehousing a inner join WarehousingDetail b on a.WarehousingCode=b.WarehousingCode 
	where a.RepositoryCode=@RepositoryCode and a.Status=1 and a.Reason<>4 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ImportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ImportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.RepositoryCode,b.UnitPrice,b.SalesPrice
	-------- 2 Khai Ton
	union all
	select b.ItemCode,a.RepositoryCode, 0 as Amount_NhapMoi, ISNULL(sum(b.Quantity),0) as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice
	from Warehousing a inner join WarehousingDetail b on a.WarehousingCode=b.WarehousingCode 
	where a.RepositoryCode=@RepositoryCode and a.Status=1 and a.Reason=4 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ImportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ImportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.RepositoryCode,b.UnitPrice,b.SalesPrice
	-------- 3 Nhan hoan tra kho
	union all
	select b.ItemCode,a.ImpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, ISNULL(sum(b.AmountRealExport),0) as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice
	from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
	where a.ImpRepositoryCode=@RepositoryCode and a.Type=2 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ExportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.ImpRepositoryCode,b.UnitPrice,b.SalesPrice
	-------- 4 Xuat ban le 
	union all
	select b.ItemCode,b.RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, ISNULL(sum(b.QuantityExport),0) as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,c.UnitPrice,c.SalesPrice
	from MedicinesRetail a inner join MedicinesRetailDetail b on a.RetailCode=b.RetailCode inner join InventoryGumshoe c on b.RowIDInventoryGumshoe=c.RowID 
	where b.RepositoryCode=@RepositoryCode and a.Paid=1 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ExportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,b.RepositoryCode,c.UnitPrice,c.SalesPrice
	-------- 5 Xuat cho benh nhan kham benh (Duyet toa BHYT)
	union all
	select b.ItemCode,b.RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, ISNULL(sum(b.QuantityExport),0) as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,c.UnitPrice,c.SalesPrice
	from MedicinesForPatients a inner join MedicinesForPatientsDetail b on a.RowID=b.RowIDMedicines inner join InventoryGumshoe c on b.RowIDInventoryGumshoe=c.RowID 
	where b.RepositoryCode=@RepositoryCode and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.DateApproved,103) >= convert(date,@DateBegin,103) and convert(date,a.DateApproved,103)<convert(date,@FromDate,103)
	group by b.ItemCode,b.RepositoryCode,c.UnitPrice,c.SalesPrice
	-------- 6 Xuat chuyen kho
	union all
	select b.ItemCode,a.ExpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, ISNULL(sum(b.AmountRealExport),0) as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice
	from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
	where a.ExpRepositoryCode=@RepositoryCode and a.Type=1 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ExportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.ExpRepositoryCode,b.UnitPrice,b.SalesPrice
	-------- 7 Hoan tra kho
	union all
	select b.ItemCode,a.ExpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,ISNULL(sum(b.AmountRealExport),0) as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice
	from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
	where a.ExpRepositoryCode=@RepositoryCode and a.Type=2 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ExportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.ExpRepositoryCode,b.UnitPrice,b.SalesPrice
	-------- 8 Nhan chuyen kho, nhan hoan tra kho
	union all
	select b.ItemCode,a.ImpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,ISNULL(sum(b.AmountRealExport),0) as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice
	from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
	where a.ImpRepositoryCode=@RepositoryCode and a.Type=1 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ExportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.ImpRepositoryCode,b.UnitPrice,b.SalesPrice
	-------- 9 Hoan tra nha cung cap
	union all
	select b.ItemCode,a.ExpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,ISNULL(sum(b.AmountRealExport),0) as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,c.UnitPrice,c.SalesPrice
	from ExportVendor a inner join ExportVendorDetail b on a.ExportVendorCode=b.ExportVendorCode inner join InventoryGumshoe c on b.RowIDGumshoe=c.RowID
	where Cancel=0 and a.ExpRepositoryCode=@RepositoryCode and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ExportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.ExpRepositoryCode,c.UnitPrice,c.SalesPrice
	-------- 10 Xuat thuoc tu truc cho benh nhan
	union all
	select b.ItemCode,b.RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, ISNULL(sum(b.Quantity),0) as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,c.UnitPrice,c.SalesPrice
	from RealMedicinesForPatients a inner join RealMedicinesForPatientsDetail b on a.RowID=b.RealRowID inner join InventoryGumshoe c on b.RowIDInventoryGumshoe=c.RowID 
	where b.RepositoryCode=@RepositoryCode and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.DateApproved,103) >= convert(date,@DateBegin,103) and convert(date,a.DateApproved,103)<convert(date,@FromDate,103)
	group by b.ItemCode,b.RepositoryCode,c.UnitPrice,c.SalesPrice
	) a group by a.ItemCode,a.RepositoryCode
	update Report_TagRepository set AmountEndPre=(AmountKhaiTonPre+AmountBeginPre+AmountImportPre+AmountImportRepaidPre+AmountImportTransferPre)-(AmountExportPre+AmountRepaidPre+AmountRepaidVenPre+AmountTransferPre)

	------------ Thuoc nhap, xuat trong thoi gian xem bao cao.
    Declare @CountTag int =0
    set @CountTag = (select Count(*) sl from Report_TagRepository where RepositoryCode=@RepositoryCode)
    if(@CountTag>0)
    begin
		declare @AmountEndPre decimal (18,4)=0
		declare @AmountEndTemp decimal (18,4)=0
		declare @Note nvarchar(100)
		declare @DateInven date = @FromDate
		Declare @TableTagRepository table(ItemCode varchar(50),AmountEndPre numeric(18, 4))
		insert into @TableTagRepository(ItemCode,AmountEndPre) (select ItemCode,AmountEndPre from Report_TagRepository where RepositoryCode=@RepositoryCode) order by ItemCode
		
		Declare @TableDateTemp table(WorkDate date)
		while(@FromDate<=@ToDate)
		begin
			insert into @TableDateTemp(WorkDate) values(@FromDate)
			set @FromDate=DATEADD(Day,1,@FromDate)
		end
		while(@CountTag>0)
		begin
			set @RowNumber= (select ISNULL(MAX(RowNumber),0)+1 STT from Report_TagRepositoryDetail)
			select top(1) @ItemCode=ItemCode,@AmountEndPre=AmountEndPre from @TableTagRepository
			if not exists( select ItemCode from Report_TagRepositoryDetail where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode)
			begin
				insert into Report_TagRepositoryDetail(ItemCode,RepositoryCode,WorkingDate,ExportDate,ImportDate,Content,Note,AmountImport,AmountExport,AmountExists,RowNumber) values(@ItemCode,@RepositoryCode,CONVERT(varchar(10),DATEADD(Day,-1,@DateInven),103),'','',N'Tồn đầu kỳ','',0,0,@AmountEndPre,@RowNumber)
				set @AmountEndTemp=@AmountEndPre
			end
			declare @WorkDate date = getdate()
			declare curGeneral cursor read_only fast_forward
			for select WorkDate from @TableDateTemp
				open curGeneral
				fetch next from curGeneral into @WorkDate
				while @@FETCH_STATUS = 0
					begin
						---------Khai bao ton dau
						declare cur1 cursor read_only fast_forward
						for select isnull(SUM(b.Quantity),0) KhaiTon,a.WarehousingCode
							from Warehousing a inner join WarehousingDetail b on a.WarehousingCode=b.WarehousingCode left join InventoryGumshoe c on b.RowID=c.IDWarehousingDetail and c.RepositoryCode=@RepositoryCode and (c.ExpWarehousingCode ='' or c.ExpWarehousingCode is null)
							where a.RepositoryCode=@RepositoryCode and b.ItemCode=@ItemCode and a.Status=1 and a.Reason=4
							and convert(date,a.ImportDate,103) = convert(date,@WorkDate,103) group by a.WarehousingCode
						open cur1
						fetch next from cur1 into @QuantityTemp,@Note
						while @@FETCH_STATUS = 0
						begin
							set @AmountEndTemp=@AmountEndTemp+@QuantityTemp
							set @RowNumber= (select ISNULL(MAX(RowNumber),0)+1 STT from Report_TagRepositoryDetail)
							insert into Report_TagRepositoryDetail(ItemCode,RepositoryCode,WorkingDate,ExportDate,ImportDate,Content,Note,AmountImport,AmountExport,AmountExists,RowNumber) values(@ItemCode,@RepositoryCode,CONVERT(varchar(10),@WorkDate,103),'',CONVERT(varchar(10),@WorkDate,103),N'Phiếu:'+@Note+ N' Khai tồn kho','',@QuantityTemp,0,@AmountEndTemp,@RowNumber)
							FETCH NEXT FROM cur1 into @QuantityTemp,@Note
						end
						CLOSE cur1
						DEALLOCATE cur1
						if(@GroupCode<>1)
							begin
								----------Kho chan xuat sang kho le
								declare cur2 cursor read_only fast_forward
								for select isnull(SUM(b.AmountRealExport),0) TotalImport,a.ExpWarehousingCode
									from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
									where a.ImpRepositoryCode=@RepositoryCode and b.ItemCode=@ItemCode and a.Type=1
									and convert(date,a.ExportDate,103) = convert(date,@WorkDate,103) group by a.ExpWarehousingCode
								open cur2
								fetch next from cur2 into @QuantityTemp,@Note
								while @@FETCH_STATUS = 0
								begin
									set @AmountEndTemp=@AmountEndTemp+@QuantityTemp
									set @RowNumber= (select ISNULL(MAX(RowNumber),0)+1 STT from Report_TagRepositoryDetail)
									insert into Report_TagRepositoryDetail(ItemCode,RepositoryCode,WorkingDate,ExportDate,ImportDate,Content,Note,AmountImport,AmountExport,AmountExists,RowNumber) values(@ItemCode,@RepositoryCode,CONVERT(varchar(10),@WorkDate,103),'',CONVERT(varchar(10),@WorkDate,103),N'Phiếu:'+@Note+ N' Chuyển từ kho chẳn','',@QuantityTemp,0,@AmountEndTemp,@RowNumber)
									FETCH NEXT FROM cur2 into @QuantityTemp,@Note
								end
								CLOSE cur2
								DEALLOCATE cur2
								-----------Hoan tra ve kho
								declare cur3 cursor read_only fast_forward
								for select isnull(SUM(b.AmountRealExport),0) as HTKHO,a.ExpRepositoryCode
									from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
									where a.ExpRepositoryCode=@RepositoryCode and b.ItemCode=@ItemCode and a.Type=2 
									and convert(date,a.ExportDate,103) = convert(date,@WorkDate,103) group by a.ExpRepositoryCode
								open cur3
								fetch next from cur3 into @QuantityTemp,@Note
								while @@FETCH_STATUS = 0
								begin
									set @AmountEndTemp=@AmountEndTemp-@QuantityTemp
									set @RowNumber= (select ISNULL(MAX(RowNumber),0)+1 STT from Report_TagRepositoryDetail)
									insert into Report_TagRepositoryDetail(ItemCode,RepositoryCode,WorkingDate,ExportDate,ImportDate,Content,Note,AmountImport,AmountExport,AmountExists,RowNumber) values(@ItemCode,@RepositoryCode,CONVERT(varchar(10),@WorkDate,103),CONVERT(varchar(10),@WorkDate,103),'',N'Phiếu:'+@Note+ N' Hoàn trả về kho chẳn','',0,@QuantityTemp,@AmountEndTemp,@RowNumber)
									FETCH NEXT FROM cur3 into @QuantityTemp,@Note
								end
								CLOSE cur3
								DEALLOCATE cur3
								-----------Xuat cho benh nhan
								declare cur4 cursor read_only fast_forward
								for select isnull(SUM(a1.QuantityExport),0) TotalExp,b.PatientCode
									from MedicinesForPatientsDetail a1 inner join MedicinesForPatients b on a1.RowIDMedicines=b.RowID
									where a1.RepositoryCode=@RepositoryCode and a1.ItemCode=@ItemCode and convert(date,a1.Idate,103) = convert(date,@WorkDate,103)
									Group by b.PatientCode
								open cur4
								fetch next from cur4 into @QuantityTemp,@Note
								while @@FETCH_STATUS = 0
								begin
									set @AmountEndTemp=@AmountEndTemp-@QuantityTemp
									set @RowNumber= (select ISNULL(MAX(RowNumber),0)+1 STT from Report_TagRepositoryDetail)
									insert into Report_TagRepositoryDetail(ItemCode,RepositoryCode,WorkingDate,ExportDate,ImportDate,Content,Note,AmountImport,AmountExport,AmountExists,RowNumber) values(@ItemCode,@RepositoryCode,CONVERT(varchar(10),@WorkDate,103),CONVERT(varchar(10),@WorkDate,103),'',N'Xuất cho BN:'+@Note,'',0,@QuantityTemp,@AmountEndTemp,@RowNumber)
									FETCH NEXT FROM cur4 into @QuantityTemp,@Note
								end
								CLOSE cur4
								DEALLOCATE cur4
								--------- Xuat ban cho Benh nhan
								declare cur5 cursor read_only fast_forward
								for select isnull(SUM(a1.QuantityExport),0) TotalExp,a.RetailCode+' - '+a.FullName
									from MedicinesRetail a inner join MedicinesRetailDetail a1 on a.RetailCode=a1.RetailCode
									where a1.RepositoryCode=@RepositoryCode and a1.ItemCode=@ItemCode and convert(date,a.ExportDate,103) = convert(date,@WorkDate,103)
									and a.Paid in(1)
									Group by a.RetailCode+' - '+a.FullName
								open cur5
								fetch next from cur5 into @QuantityTemp,@Note
								while @@FETCH_STATUS = 0
								begin
									set @AmountEndTemp=@AmountEndTemp-@QuantityTemp
									set @RowNumber= (select ISNULL(MAX(RowNumber),0)+1 STT from Report_TagRepositoryDetail)
									insert into Report_TagRepositoryDetail(ItemCode,RepositoryCode,WorkingDate,ExportDate,ImportDate,Content,Note,AmountImport,AmountExport,AmountExists,RowNumber) values(@ItemCode,@RepositoryCode,CONVERT(varchar(10),@WorkDate,103),CONVERT(varchar(10),@WorkDate,103),'',N'Xuất bán cho BN:'+@Note,'',0,@QuantityTemp,@AmountEndTemp,@RowNumber)
									FETCH NEXT FROM cur5 into @QuantityTemp,@Note
								end
								CLOSE cur5
								DEALLOCATE cur5
								--------- Xuat Tu Truc Cho BN
								declare cur6 cursor read_only fast_forward
								for select isnull(SUM(a1.Quantity),0) TotalExp,b.PatientCode
									from RealMedicinesForPatientsDetail a1 inner join RealMedicinesForPatients b on a1.RealRowID=b.RowID
									where a1.RepositoryCode=@RepositoryCode and a1.ItemCode=@ItemCode and convert(date,b.DateApproved,103) = convert(date,@WorkDate,103)
									Group by b.PatientCode
								open cur6
								fetch next from cur6 into @QuantityTemp,@Note
								while @@FETCH_STATUS = 0
								begin
									set @AmountEndTemp=@AmountEndTemp-@QuantityTemp
									set @RowNumber= (select ISNULL(MAX(RowNumber),0)+1 STT from Report_TagRepositoryDetail)
									insert into Report_TagRepositoryDetail(ItemCode,RepositoryCode,WorkingDate,ExportDate,ImportDate,Content,Note,AmountImport,AmountExport,AmountExists,RowNumber) values(@ItemCode,@RepositoryCode,CONVERT(varchar(10),@WorkDate,103),CONVERT(varchar(10),@WorkDate,103),'',N'Xuất tủ trực cho BN:'+@Note,'',0,@QuantityTemp,@AmountEndTemp,@RowNumber)
									FETCH NEXT FROM cur6 into @QuantityTemp,@Note
								end
								CLOSE cur6
								DEALLOCATE cur6
						end
						else
							begin
								-----------Hoan tra ve kho
								declare cur7 cursor read_only fast_forward
								for select isnull(SUM(b.AmountRealExport),0) as HTKHO,a.ExpRepositoryCode
									from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
									where a.ImpRepositoryCode=@RepositoryCode and b.ItemCode=@ItemCode and a.Type=2 
									and convert(date,a.ExportDate,103) = convert(date,@WorkDate,103) group by a.ExpRepositoryCode
								open cur7
								fetch next from cur7 into @QuantityTemp,@Note
								while @@FETCH_STATUS = 0
								begin
									set @AmountEndTemp=@AmountEndTemp-@QuantityTemp
									set @RowNumber= (select ISNULL(MAX(RowNumber),0)+1 STT from Report_TagRepositoryDetail)
									insert into Report_TagRepositoryDetail(ItemCode,RepositoryCode,WorkingDate,ExportDate,ImportDate,Content,Note,AmountImport,AmountExport,AmountExists,RowNumber) values(@ItemCode,@RepositoryCode,CONVERT(varchar(10),@WorkDate,103),CONVERT(varchar(10),@WorkDate,103),'',N'Phiếu:'+@Note+ N'Nhận hoàn trả kho','',@QuantityTemp,0,@AmountEndTemp,@RowNumber)
									FETCH NEXT FROM cur7 into @QuantityTemp,@Note
								end
								CLOSE cur7
								DEALLOCATE cur7
								-----------Hoan tra ve NCC
								declare cur8 cursor read_only fast_forward
								for select isnull(SUM(a1.AmountRealExport),0) TotalExp,b.ExportVendorCode
									from ExportVendorDetail a1 inner join ExportVendor b on a1.ExportVendorCode=b.ExportVendorCode
									where b.ExpRepositoryCode=@RepositoryCode and a1.ItemCode=@ItemCode and convert(date,b.ExportDate,103) = convert(date,@WorkDate,103) and b.Cancel=0
									Group by b.ExportVendorCode
								open cur8
								fetch next from cur8 into @QuantityTemp,@Note
								while @@FETCH_STATUS = 0
								begin
									set @AmountEndTemp=@AmountEndTemp-@QuantityTemp
									set @RowNumber= (select ISNULL(MAX(RowNumber),0)+1 STT from Report_TagRepositoryDetail)
									insert into Report_TagRepositoryDetail(ItemCode,RepositoryCode,WorkingDate,ExportDate,ImportDate,Content,Note,AmountImport,AmountExport,AmountExists,RowNumber) values(@ItemCode,@RepositoryCode,CONVERT(varchar(10),@WorkDate,103),CONVERT(varchar(10),@WorkDate,103),'',N'Xuất hoàn trả NCC:'+@Note,'',0,@QuantityTemp,@AmountEndTemp,@RowNumber)
									FETCH NEXT FROM cur8 into @QuantityTemp,@Note
								end
								CLOSE cur8
								DEALLOCATE cur8
							end
						FETCH NEXT FROM curGeneral into @WorkDate
					End
			CLOSE curGeneral
			DEALLOCATE curGeneral
			
			delete from @TableTagRepository where ItemCode=@ItemCode
			set @CountTag=@CountTag-1
		End
		end
	select a.ItemCode,a.WorkingDate,a.ExportDate,a.ImportDate,a.Content,a.Note,a.AmountImport,a.AmountExport,a.AmountExists,a1.ItemName,a2.UnitOfMeasureName,a3.ItemCategoryName,a4.GroupName,b.AmountEndPre,b1.RepositoryName,c.CountryName,d.ProducerName
	from Report_TagRepositoryDetail a inner join Items a1 on a.ItemCode=a1.ItemCode inner join UnitOfMeasure a2 on a1.UnitOfMeasureCode=a2.UnitOfMeasureCode inner join ItemCategory a3 on a1.ItemCategoryCode=a3.ItemCategoryCode inner join ItemGroup a4 on a3.GroupCode = a4.GroupCode
	inner join Report_TagRepository b on a.ItemCode=b.ItemCode inner join RepositoryCatalog b1 on b.RepositoryCode=b1.RepositoryCode inner join Country c on a1.CountryCode=c.CountryCode inner join Producer d on a1.ProducerCode=d.ProducerCode
	order by a.ItemCode,CONVERT(Date,WorkingDate,103) asc
end
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServiceLaboratoryEntry' and b.name ='PostingDateResult')
	alter table ServiceLaboratoryEntry add PostingDateResult varchar(25) 
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ServiceRadiologyEntry' and b.name ='EmployeeCodeDoctor')
	alter table ServiceRadiologyEntry add EmployeeCodeDoctor varchar(50) 
go
--update ServiceRadiologyEntry set EmployeeCodeDoctor=EmployeeCode where EmployeeCodeDoctor is null
--go
----------- Update 13/04/2015
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'CatalogTypeReceive')
begin
CREATE TABLE CatalogTypeReceive
(
	RowID int,
	ReceiveName nvarchar(250) not null
	CONSTRAINT CatalogTypeReceive_pk PRIMARY KEY (RowID)
)
end
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='PatientReceive' and b.name ='IDTypeReceive')
	alter table PatientReceive add IDTypeReceive int default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Patients' and b.name ='IDTypeReceive')
	alter table Patients add IDTypeReceive int default 0 not null
go
----------- Update 11/04/2015
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='RepositoryCatalog' and b.name ='DateReport')
	alter table RepositoryCatalog add DateReport datetime default getdate() not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicalRecord' and b.name ='DiagnosisCustom')
	alter table MedicalRecord add DiagnosisCustom nvarchar(250) 
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Surgeries' and b.name ='DiagnosisCustomOn')
	alter table Surgeries add DiagnosisCustomOn nvarchar(250)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Surgeries' and b.name ='DiagnosisCustomOut')
	alter table Surgeries add DiagnosisCustomOut nvarchar(250)
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'DiagnosisCustom')
begin
CREATE TABLE DiagnosisCustom
(
	RowID int identity(1,1),
	DiagnosisName nvarchar(250) not null,
	EmployeeCode varchar(50),
	IDate datetime default getdate()
	CONSTRAINT DiagnosisCustom_pk PRIMARY KEY (RowID),
	CONSTRAINT fk_DiagnosisCustom_Employee foreign key(EmployeeCode) references Employee(EmployeeCode)
)
end
go
if exists(select name from sysobjects where name like'proIns_DiagnosisCustom')
	drop procedure proIns_DiagnosisCustom
go
create procedure proIns_DiagnosisCustom
(
	@RowID int,
	@DiagnosisName nvarchar(250),
	@EmployeeCode varchar(50)
)
as
begin
	if exists(select RowID from DiagnosisCustom where RowID=@RowID)
	begin
		update DiagnosisCustom set DiagnosisName=@DiagnosisName,EmployeeCode=@EmployeeCode,IDate=GETDATE() where RowID=@RowID
	end
	else
	begin
		insert into DiagnosisCustom(DiagnosisName,EmployeeCode) values(@DiagnosisName,@EmployeeCode)
	end
end
go
if exists(select name from sysobjects where name like'proDel_DiagnosisCustom')
	drop procedure proDel_DiagnosisCustom
go
create procedure proDel_DiagnosisCustom
(
	@RowID int,
	@iresult int output
)
as
begin
	delete DiagnosisCustom where RowID=@RowID
	set @iresult =1
end
go
----------- Update 31/03/2015
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicalHistory' and b.name ='EmployeeCode')
	alter table MedicalHistory add EmployeeCode varchar(50) not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicalHistory' and b.name ='IDate')
	alter table MedicalHistory add IDate datetime default getdate() not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicalHistory' and b.name ='MedicalHistoryContent')
	alter table MedicalHistory add MedicalHistoryContent nvarchar(max) not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Patients' and b.name ='MedicalHistoryChildren')
	alter table Patients add MedicalHistoryChildren nvarchar(max) 
go
if exists(select name from sysobjects where name like'pro_UpdPatientsAbout')
	drop procedure pro_UpdPatientsAbout
go
create procedure pro_UpdPatientsAbout
(
	@PatientCode varchar(50),
	@MedicalHistoryChildren nvarchar(max),
	@Result int output
)
as
begin
	update Patients set MedicalHistoryChildren=@MedicalHistoryChildren where PatientCode=@PatientCode
	set @Result=1
end
go
---------- update 14/03/2015
if exists(select name from sysobjects where name like'pro_ViewShipmentDateEnd')
	drop procedure pro_ViewShipmentDateEnd
go
create procedure pro_ViewShipmentDateEnd
as
begin
	select 0 as [Delete], a.ItemCode,b.ItemName,b.Active,b1.ItemCategoryName,b2.GroupName,b3.UnitOfMeasureName,a.Shipment,a.DateEnd,a.Shipment as ShipmentNew,a.DateEnd as DateEndNew
	from InventoryGumshoe a inner join Items b on a.ItemCode=b.ItemCode inner join ItemCategory b1 on b.ItemCategoryCode=b1.ItemCategoryCode
	inner join ItemGroup b2 on b1.GroupCode=b2.GroupCode inner join UnitOfMeasure b3 on b.UnitOfMeasureCode=b3.UnitOfMeasureCode
	group by a.ItemCode,b.ItemName,b.Active,b1.ItemCategoryName,b2.GroupName,b3.UnitOfMeasureName,a.Shipment,a.DateEnd
end
go
if exists(select name from sysobjects where name like'proUpd_InventoryShipmentDateEnd')
	drop procedure proUpd_InventoryShipmentDateEnd
go
create procedure proUpd_InventoryShipmentDateEnd
(
	@ItemCode varchar(50),
	@Shipment nvarchar(250),
	@DateEnd date,
	@ShipmentNew nvarchar(250),
	@DateEndNew date
)
as
begin
	update InventoryGumshoe set Shipment=@ShipmentNew,DateEnd=convert(date,@DateEndNew,103) where ItemCode=@ItemCode and convert(date,DateEnd,103)=convert(date,@DateEnd,103) and shipment=@Shipment
end
go
----------- update 17/03/15
--insert into [Service](ServiceCategoryCode,ServiceCode,ServiceName,DepartmentCode,Hide,ServiceGroupCode,EmployeeCode,PatientType,Serial) values('LO0001','DV000000',N'Chỉ định trong tiếp đón','',1,'KCB','admin',1,-1)
--go
--insert into Department(DepartmentCode,DepartmentName,ServiceGroupCode,Hide) values('KP0000',N'Tiếp nhận','KCB',1)
--go
if not exists(select * from sys.columns where Name = N'AmountBeginPre' and Object_ID = Object_ID(N'report_NXT_CT'))
	alter table report_NXT_CT add AmountBeginPre numeric(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'AmountImportPre' and Object_ID = Object_ID(N'report_NXT_CT'))
	alter table report_NXT_CT add AmountImportPre numeric(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'AmountExportPre' and Object_ID = Object_ID(N'report_NXT_CT'))
	alter table report_NXT_CT add AmountExportPre numeric(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'AmountEndPre' and Object_ID = Object_ID(N'report_NXT_CT'))
	alter table report_NXT_CT add AmountEndPre numeric(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'AmountRepaidPre' and Object_ID = Object_ID(N'report_NXT_CT'))
	alter table report_NXT_CT add AmountRepaidPre numeric(18,4) default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='report_NXT_CT' and b.name ='AmountRepaidVenPre')
	alter table report_NXT_CT add AmountRepaidVenPre numeric(18,4) default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='UnitOfMeasure' and b.name ='Type')
	alter table UnitOfMeasure add [Type] Char(1) default 'I' not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Service' and b.name ='UnitOfMeasureCode')
	alter table [Service] add [UnitOfMeasureCode] varchar(50) default null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SuggestedServiceReceipt' and b.name ='AmountExemption')
	alter table SuggestedServiceReceipt add AmountExemption numeric(18,2) default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SuggestedServiceReceipt' and b.name ='Quantity')
	alter table SuggestedServiceReceipt add Quantity int default 1 not null
go
----------- Update 24/03/2015
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='PatientReceive' and b.name ='IntroName')
	alter table PatientReceive add IntroName nvarchar(250) default null
--go
--alter table PatientReceive drop column IntroCode
go
if exists(select name from sysobjects where name like'proUpd_WarehousingInven')
	drop procedure proUpd_WarehousingInven
go
create procedure proUpd_WarehousingInven
(
	@WarehousingCode varchar(50),
	@RowID numeric(18,0),
	@RepositoryCode varchar(50),
	@ItemCode varchar(50),
	@UnitOfMeasureCode varchar(50),
	@Quantity numeric(18,0),
	@UnitPrice numeric(18,3),
	@BHYTPrice numeric(18,3),
	@Amount numeric(18,3),
	@Tax int,
	@Scot numeric(18,3),
	@TotalTax numeric(18,3),
	@SalesPrice numeric(18,3),
	@Shipment nvarchar(250),
	@DateEnd date,
	@Result int output
)
as
begin
	declare @RowIDGumshoe numeric(18,0)=0
	if exists(select WarehousingCode from Warehousing where WarehousingCode=@WarehousingCode)
	begin
		if exists(select RowID from InventoryGumshoe where WarehousingCode=@WarehousingCode and ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and IDWarehousingDetail=@RowID)
		begin
			select @RowIDGumshoe=RowID from InventoryGumshoe where WarehousingCode=@WarehousingCode and ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and IDWarehousingDetail=@RowID
			if exists(select ItemCode from RealMedicinesForPatientsDetail where RowIDInventoryGumshoe=@RowIDGumshoe)
				set @Result = -1--N'Thuốc đã xuất cho bệnh nhân trong kho tủ trực.'
			else if exists(select ItemCode from MedicinesForPatientsDetail where RowIDInventoryGumshoe=@RowIDGumshoe)
				set @Result = -2--N'Thuốc đã duyệt cấp toa cho bệnh nhân.'
			else if exists(select ItemCode from MedicinesRetailDetail where RowIDInventoryGumshoe=@RowIDGumshoe)
				set @Result = -3--N'Thuốc xuất bán.'
			else if exists(select ExpWarehousingCode from ExportWarehousingDetail where RowIDGumshoe=@RowIDGumshoe)
			begin
				declare @ExpWarehousingCode varchar(50)
				select @ExpWarehousingCode=ExpWarehousingCode from ExportWarehousingDetail where RowIDGumshoe=@RowIDGumshoe
				set @Result = -4--N'Thuốc đã xuất chuyển kho, Phiếu' +@ExpWarehousingCode+'.'
			end
			else
			begin
				 declare @AmountCurrent numeric(18,3)=0
				 select @AmountCurrent=AmountImport from InventoryGumshoe where IDWarehousingDetail=@RowID and ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and WarehousingCode=@WarehousingCode
				 update InventoryGeneral set AmountImport=AmountImport-@AmountCurrent,AmountEnd=AmountEnd-@AmountCurrent where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Hide = 0
				 update InventoryGumshoe set AmountImport=@Quantity,DateEnd=@DateEnd,SalesPrice=@SalesPrice,UnitPrice=@UnitPrice,Shipment=@Shipment,BHYTPrice=@BHYTPrice where IDWarehousingDetail=@RowID and ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and WarehousingCode=@WarehousingCode
				 update InventoryGeneral set AmountImport=AmountImport+@Quantity,AmountEnd=AmountEnd+@Quantity where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode  and Hide = 0
				 update WarehousingDetail set UnitOfMeasureCode=@UnitOfMeasureCode,Quantity=@Quantity,UnitPrice=@UnitPrice,Amount=@Amount,Tax=@Tax,Scot=@Scot,TotalTax=@TotalTax,SalesPrice=@SalesPrice,Shipment=@Shipment,DateEnd=@DateEnd where RowID=@RowID and WarehousingCode=@WarehousingCode and ItemCode=@ItemCode
				 update Items set UnitPrice=@UnitPrice,BHYTPrice=@BHYTPrice where ItemCode=@ItemCode
				 set @Result = 1--N'Cập nhật thành công!'
			end
		end
		else
			set @Result = -5--N'Mã thuốc không tồn tại trong table InventoryGumshoe' +@ItemCode+'.'
	end
	else
		set @Result = -6--N'Mã phiếu nhập' +@WarehousingCode+' không tồn tại.'
end
go
----------- Update 28/03/2015
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicalPrescriptionDetail' and b.name ='DoseOf')
	alter table MedicalPrescriptionDetail add DoseOf int default 0 not null
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicalPrescriptionDetail' and b.name ='DoseOfPills')
	alter table MedicalPrescriptionDetail add DoseOfPills nvarchar(20) 
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='SuggestedServiceReceipt' and b.name ='EmployeeCodeDoctor')
	alter table SuggestedServiceReceipt add EmployeeCodeDoctor varchar(50) 
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicalRecord' and b.name ='EmployeeCodeDoctor')
	alter table MedicalRecord add EmployeeCodeDoctor varchar(50) 
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='MedicalRecord' and b.name ='ReceiptID')
	alter table MedicalRecord add ReceiptID numeric(18,0) default -1 not null
go
----------- Update 10/03/2015
if not exists(select * from sys.columns where Name = N'AmountBeginPre' and Object_ID = Object_ID(N'report_NXT_TH'))
	alter table report_NXT_TH add AmountBeginPre numeric(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'AmountImportPre' and Object_ID = Object_ID(N'report_NXT_TH'))
	alter table report_NXT_TH add AmountImportPre numeric(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'AmountExportPre' and Object_ID = Object_ID(N'report_NXT_TH'))
	alter table report_NXT_TH add AmountExportPre numeric(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'AmountEndPre' and Object_ID = Object_ID(N'report_NXT_TH'))
	alter table report_NXT_TH add AmountEndPre numeric(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'AmountRepaidPre' and Object_ID = Object_ID(N'report_NXT_TH'))
	alter table report_NXT_TH add AmountRepaidPre numeric(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'AmountRepaidVenPre' and Object_ID = Object_ID(N'report_NXT_TH'))
	alter table report_NXT_TH add AmountRepaidVenPre numeric(18,4) default 0 not null
go
----------- Update 17/02/2015
if exists(select name from sysobjects where name like'pro_RptViewImmunization')
	drop procedure pro_RptViewImmunization
go
create procedure pro_RptViewImmunization
(
	@ImmunizationRecordCode varchar(15),
	@PatientReceiveID numeric(18,0)
)
as
	begin
		select a.ImmunizationRecordCode,a.PatientCode,a2.ObjectName,b.DepartmentCodeOrder,b2.DepartmentName DepartmentNameOrder,a.DepartmentCode,a3.DepartmentName,
		b3.EmployeeName EmployeeNameOrder,a4.EmployeeName,b.CreateDate SuggestedDate,b.CreateDate ImmunizationDate,c.CreateDate ReceiveDate,c.OutDate,b1.ServiceName,a1.PatientName,a1.Allergy,a1.MedicalHistory,a1.PatientAge,a1.PatientBirthyear,
		a1.PatientEmail,a1.PatientMobile,(case a1.PatientGender when 0 then N'Nữ' else 'Nam' end) PatientGenderName,[dbo].func_PatientOfAddress(@PatientReceiveID) PatientAddress,c1.EThnicName,c2.NationalityName,c3.CareerName
		from ImmunizationRecord a inner join Patients a1 on a.PatientCode=a1.PatientCode
		inner join SuggestedServiceReceipt b on a.ReceiptID=b.ReceiptID
		inner join Service b1 on b.ServiceCode=b1.ServiceCode inner join Object a2 on a.ObjectCode=a2.ObjectCode
		inner join Department b2 on b.DepartmentCodeOrder = b2.DepartmentCode left join Department a3 on a.DepartmentCode=a3.DepartmentCode
		inner join Employee b3 on b.EmployeeCode=b3.EmployeeCode inner join Employee a4 on a.EmployeeCode=a4.EmployeeCode
		inner join PatientReceive c on a.PatientReceiveID=c.PatientReceiveID left join Catalog_EThnic c1 on c.EThnicID=c1.EThnicID left join Catalog_Nationality c2 on c.NationalityID=c2.NationalityID
		left join Career c3 on c.CareerCode=c3.CareerCode left join Catalog_Provincial c4 on c.ProvincialCode=c4.ProvincialCode left join Catalog_District c5 on c.DistrictCode=c5.DistrictCode
		left join Catalog_Ward c6 on c.WardCode=c6.WardCode
		where a.ImmunizationRecordCode=@ImmunizationRecordCode
	end
go
if exists(select name from sysobjects where name like'pro_RptViewImmunizationDetail')
	drop procedure pro_RptViewImmunizationDetail
go
create procedure pro_RptViewImmunizationDetail
(
	@ImmunizationRecordCode varchar(15)
)
as
	begin
		select a.ImmunizationRecordDetailCode,a1.DoseNoName,a.LotNo,a.Note,a.Content,a.DateGiven,a.AppointmentDate,a.AppointmentContent,a2.EmployeeName
		from ImmunizationRecordDetail a inner join CatalogDoseNo a1 on a.RowIDDoseNo=a1.RowID inner join Employee a2 on a.EmployeeCode=a2.EmployeeCode
		where a.ImmunizationRecordCode=@ImmunizationRecordCode
	end
go
-----------Update 15/02/2015
if not exists(select * from sys.columns where Name = N'MedicalHistory' and Object_ID = Object_ID(N'PatientsRelation'))
	alter table PatientsRelation add MedicalHistory nvarchar(250) default ''
go
if not exists(select * from sys.columns where Name = N'Age' and Object_ID = Object_ID(N'PatientsRelation'))
	alter table PatientsRelation add Age varchar(3) default ''
go
if not exists(select * from sys.columns where Name = N'CareerName' and Object_ID = Object_ID(N'PatientsRelation'))
	alter table PatientsRelation add CareerName nvarchar(100) default ''
go
-----------Update 07/02/2015
if exists(select name from sysobjects where name = 'proWaitingServiceImmunization')--21/07/2016
	drop procedure proWaitingServiceImmunization
go
create procedure proWaitingServiceImmunization
(
	@FromDate date=getdate,
	@ToDate date=getdate,
	@ImmunizationStatus int=0,
	@DepartmentCode varchar(50),
	@Paid int=0,
	@MenuID int
)
as
	declare @QuanlityDate nvarchar(250)
	declare @EndDate datetime
	--select @QuanlityDate=[Description] from SystemParameter where RowID=300
	if @ImmunizationStatus=0
	begin
		if @Paid=0
		begin
			select a.ReceiptID,a.RefID,a.PatientCode,a.CreateDate,b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
			(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,e.ServiceName,a.ServiceCode,a.ReferenceCode,c.DepartmentName, CONVERT(char(10),a.CreateDate,103) ImmunizationDate, '' ImmunizationRecordCode,a.Paid
			from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode left join Department c on a.DepartmentCodeOrder=c.DepartmentCode
			inner join Object d on a.ObjectCode=d.ObjectCode inner join [Service] e on a.ServiceCode=e.ServiceCode
			where a.Status=@ImmunizationStatus and convert(date,a.CreateDate,103) between convert(date,@FromDate,103) and convert(date,@toDate,103)
			and a.DepartmentCode=@DepartmentCode and a.Note<>'TIEPDON' and a.ServiceCode in(select ServiceCode from ServiceMenuForService where ServiceMenuid=@MenuID)
			order by a.WorkDate desc
		end
		else
		begin
			select a.ReceiptID,a.RefID,a.PatientCode,a.CreateDate,b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
			(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,e.ServiceName,a.ServiceCode,a.ReferenceCode,c.DepartmentName,CONVERT(char(10),a.CreateDate,103) ImmunizationDate, '' ImmunizationRecordCode,a.Paid
			from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode left join Department c on a.DepartmentCodeOrder=c.DepartmentCode
			inner join Object d on a.ObjectCode=d.ObjectCode inner join [Service] e on a.ServiceCode=e.ServiceCode
			where a.Status=@ImmunizationStatus  and convert(date,a.CreateDate,103) between convert(date,@FromDate,103) and convert(date,@toDate,103)
			and a.DepartmentCode=@DepartmentCode and a.Note<>'TIEPDON' and (a.ObjectCode=1 or a.Paid=1) and a.ServiceCode in(select ServiceCode from ServiceMenuForService where ServiceMenuid=@MenuID)
			order by a.WorkDate desc
		end
	end
	else if @ImmunizationStatus =1
	begin
		select a.ReceiptID,a.RefID,a.PatientCode,a.CreateDate,b.PatientName,a1.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
		(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,e.ServiceName,a.ServiceCode,a.ReferenceCode,c.DepartmentName,CONVERT(char(10),a1.WorkDate,103) ImmunizationDate, a1.ImmunizationRecordCode,a.Paid
		from SuggestedServiceReceipt a inner join ImmunizationRecord a1 on a.ReceiptID=a1.ReceiptID
		inner join Patients b on a.PatientCode=b.PatientCode left join Department c on a.DepartmentCodeOrder=c.DepartmentCode
		inner join Object d on a.ObjectCode=d.ObjectCode inner join [Service] e on a.ServiceCode=e.ServiceCode
		where a1.Status=@ImmunizationStatus 
		 and convert(date,a.WorkDate,103) between convert(date,@FromDate,103) and convert(date,@toDate,103)
		and a.DepartmentCode=@DepartmentCode and a.ServiceCode in(select ServiceCode from ServiceMenuForService where ServiceMenuid=@MenuID)
		order by a.WorkDate desc
	end
	else
	begin
		select a.ReceiptID,a.RefID,a.PatientCode,a.CreateDate,b.PatientName,a1.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
		(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,e.ServiceName,a.ServiceCode,a.ReferenceCode,c.DepartmentName,CONVERT(char(10),a1.WorkDate,103) ImmunizationDate, a1.ImmunizationRecordCode,a.Paid
		from SuggestedServiceReceipt a inner join ImmunizationRecord a1 on a.ReceiptID=a1.ReceiptID
		inner join Patients b on a.PatientCode=b.PatientCode left join Department c on a.DepartmentCodeOrder=c.DepartmentCode
		inner join Object d on a.ObjectCode=d.ObjectCode inner join [Service] e on a.ServiceCode=e.ServiceCode
		where a1.Status=2 and convert(date,a1.WorkDate,103) between convert(date,@FromDate,103) and convert(date,@toDate,103)
		and a.DepartmentCode=@DepartmentCode and a.ServiceCode in(select ServiceCode from ServiceMenuForService where ServiceMenuid=@MenuID)
		order by a.WorkDate desc
	end
go
-----------Update ngay 24/01/2015
IF ( NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ImmunizationRecord'))
BEGIN
    create table ImmunizationRecord
    (
		ImmunizationRecordCode varchar(15),
		ObjectCode int not null,
		PatientType int not null,
		ServiceCode varchar(50),
		PatientReceiveID numeric(18,0),
		PatientCode varchar(50),
		ReceiptID numeric(18,0),
		DepartmentCode varchar(50),
		WorkDate datetime default getdate(),
		UDate datetime default getdate(),
		EmployeeCode varchar(50),
		[Status] int default 0,
		CONSTRAINT ImmunizationRecord_pk primary key (ImmunizationRecordCode),
		Constraint fk_ImmunizationRecord_PatientReceive foreign key(PatientReceiveID) references PatientReceive(PatientReceiveID),
		Constraint fk_ImmunizationRecord_Patients foreign key(PatientCode) references Patients(PatientCode),
		Constraint fk_ImmunizationRecord_Employee foreign key(EmployeeCode) references Employee(EmployeeCode),
		Constraint fk_ImmunizationRecord_SuggestedServiceReceipt foreign key(ReceiptID) references SuggestedServiceReceipt(ReceiptID)
    )
END
go
if exists(select name from sysobjects where name like'proInsImmunizationRecord')
	drop procedure proInsImmunizationRecord
go
create procedure proInsImmunizationRecord
(
	@ImmunizationRecordCode varchar(15),
	@ObjectCode int,
	@PatientType int,
	@ServiceCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(50),
	@ReceiptID numeric(18,0),
	@DepartmentCode varchar(50),
	@EmployeeCode varchar(50),
	@Status int=0,
	@ShiftWork char(2),
	@ReturnCode varchar(15) output
)
as
begin
	declare @ContentNew nvarchar(max)=''
	declare @ContentOld nvarchar(max)=''
	-- @ImmunizationRecordCode-@ObjectCode-@PatientType-@ServiceCode-@PatientReceiveID-@PatientCode-@ReceiptID-@DepartmentCode-@EmployeeCode-@Status
	set @ContentNew=@ImmunizationRecordCode+'^'+CONVERT(varchar(2),@ObjectCode)+'^'+CONVERT(varchar(2),@PatientType)+'^'+@ServiceCode+'^'+CONVERT(varchar(20),@PatientReceiveID)+'^'+@PatientCode+'^'+CONVERT(varchar(20),@ReceiptID)+'^'+@DepartmentCode+'^'+@EmployeeCode+'^'+CONVERT(char(1),@Status)
	set @ContentOld=(select ImmunizationRecordCode+'^'+CONVERT(varchar(2),ObjectCode)+'^'+CONVERT(varchar(2),PatientType)+'^'+ServiceCode+'^'+CONVERT(varchar(20),PatientReceiveID)+'^'+PatientCode+'^'+CONVERT(varchar(20),ReceiptID)+'^'+DepartmentCode+'^'+EmployeeCode+'^'+CONVERT(char(1),Status) Content from ImmunizationRecord where ImmunizationRecordCode=@ImmunizationRecordCode)
	if exists(select ImmunizationRecordCode from ImmunizationRecord where ImmunizationRecordCode=@ImmunizationRecordCode)
	begin
		exec ProInsLogEventInsUpdDel 'Upd',@ContentOld,@ContentNew,@EmployeeCode,'ImmunizationRecord'
		update ImmunizationRecord set ObjectCode=@ObjectCode,PatientType=@PatientType,ServiceCode=@ServiceCode,DepartmentCode=@DepartmentCode,EmployeeCode=@EmployeeCode,[Status]=@Status,ShiftWork=@ShiftWork where ImmunizationRecordCode=@ImmunizationRecordCode
		update SuggestedServiceReceipt set Status=1 where ReceiptID=@ReceiptID
		set @ReturnCode=@ImmunizationRecordCode
	end
	else
	begin
		declare @_Code varchar(50)
		declare @_stt numeric(18,0)
		set @_stt = isnull((select top(1) CONVERT(numeric(18,0),isnull(SUBSTRING(ImmunizationRecordCode,3,13),0)) maxcode from ImmunizationRecord order by CONVERT(numeric(18,0),isnull(SUBSTRING(ImmunizationRecordCode,3,13),0)) desc),0)+1
		set @_Code='TC'+CONVERT(varchar(13),@_stt)
		insert into ImmunizationRecord(ImmunizationRecordCode,ObjectCode,PatientType,ServiceCode,PatientReceiveID,PatientCode,ReceiptID,DepartmentCode,EmployeeCode,Status,ShiftWork) values(@_Code,@ObjectCode,@PatientType,@ServiceCode,@PatientReceiveID,@PatientCode,@ReceiptID,@DepartmentCode,@EmployeeCode,@Status,@ShiftWork)
		set @ReturnCode=@_Code
		update SuggestedServiceReceipt set Status=1 where ReceiptID=@ReceiptID
		exec ProInsLogEventInsUpdDel 'Ins',@ContentOld,@ContentNew,@EmployeeCode,'ImmunizationRecord'
	end
end
go
if exists(select name from sysobjects where name like'proUpdImmunizationRecord')
	drop procedure proUpdImmunizationRecord
go
create procedure proUpdImmunizationRecord
(
	@ImmunizationRecordCode varchar(15),
	@PatientReceiveID numeric(18,0),
	@EmployeeCode varchar(50),
	@Result int output
)
as
begin
	if exists (select PatientCode from ImmunizationRecord where ImmunizationRecordCode=@ImmunizationRecordCode and PatientReceiveID=@PatientReceiveID)
	begin
		update ImmunizationRecord set Status=1 where ImmunizationRecordCode=@ImmunizationRecordCode and PatientReceiveID=@PatientReceiveID
		set @Result = 1
	end
	else
		 set @Result = -1
end
go
if exists(select name from sysobjects where name like'proDelImmunizationRecord')
	drop procedure proDelImmunizationRecord
go
create procedure proDelImmunizationRecord
(
	@ImmunizationRecordCode varchar(15),
	@ImmunizationRecordDetailCode varchar(15),
	@PatientReceiveID numeric(18,0),
	@EmployeeCode varchar(50),
	@Result int output
)
as
begin
	declare @ContentNew nvarchar(max)=''
	declare @ContentOld nvarchar(max)=''
	declare @ItemCode varchar(50)
	declare @Quantity decimal(18,2)
	declare @RepositoryCode varchar(50)
	declare @RowIDInventoryGumshoe decimal(18,0)
	declare @RowIDDetail numeric(18,0)
	--set @ContentOld=(select ImmunizationRecordCode+'^'+CONVERT(varchar(2),ObjectCode)+'^'+CONVERT(varchar(2),PatientType)+'^'+ServiceCode+'^'+CONVERT(varchar(20),PatientReceiveID)+'^'+PatientCode+'^'+CONVERT(varchar(20),ReceiptID)+'^'+DepartmentCode+'^'+CONVERT(varchar(20),WorkDate)+'^'+CONVERT(varchar(20),UDate)+'^'+EmployeeCode+'^'+CONVERT(char(1),Status) Content from ImmunizationRecord where ImmunizationRecordCode=@ImmunizationRecordCode)
	if exists(select ImmunizationRecordDetailCode from ImmunizationRecordDetail where ImmunizationRecordDetailCode=@ImmunizationRecordDetailCode)
	begin
		if exists(select RefCode from RealMedicinesForPatients where RefCode=@ImmunizationRecordDetailCode and (BanksAccountCode is null or BanksAccountCode=''))
			begin
				declare cur cursor read_only fast_forward
				for select a1.RowID,a1.ItemCode,a1.Quantity,a1.RepositoryCode,a1.RowIDInventoryGumshoe from RealMedicinesForPatients a inner join RealMedicinesForPatientsDetail a1 on a.RowID=a1.RealRowID where a.RefCode=@ImmunizationRecordDetailCode
				open cur
				fetch next from cur into @RowIDDetail,@ItemCode,@Quantity,@RepositoryCode,@RowIDInventoryGumshoe
				while @@FETCH_STATUS = 0
				begin
					update InventoryGumshoe set AmountExport=AmountExport-@Quantity where RowID=@RowIDInventoryGumshoe and ItemCode=@ItemCode
					update InventoryGeneral set AmountExport=AmountExport-@Quantity, AmountEnd=AmountEnd+@Quantity where RepositoryCode=@RepositoryCode and ItemCode=@ItemCode and Hide = 0
					delete from RealMedicinesForPatientsDetail where RowID=@RowIDDetail and ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and RowIDInventoryGumshoe=@RowIDInventoryGumshoe
					FETCH NEXT FROM cur into @RowIDDetail,@ItemCode,@Quantity,@RepositoryCode,@RowIDInventoryGumshoe
				end
				CLOSE cur
				DEALLOCATE cur
				
				--set @ContentOld=(select ImmunizationRecordDetailCode+'^'+ImmunizationRecordCode+'^'+CONVERT(varchar(2),RowIDDoseNo)+'^'+CONVERT(varchar(2),LotNo)+'^'+Note+'^'+Content+'^'+CONVERT(varchar(20),IDate)+'^'+CONVERT(varchar(20),UDate)+'^'+CONVERT(varchar(20),DateGiven)+'^'+AppointmentDate+'^'+AppointmentContent+'^'+EmployeeCode from ImmunizationRecordDetail where ImmunizationRecordDetailCode=@ImmunizationRecordDetailCode)
				delete from RealMedicinesForPatients where RefCode=@ImmunizationRecordDetailCode and PatientReceiveID=@PatientReceiveID
				delete from ImmunizationRecordDetail where ImmunizationRecordDetailCode=@ImmunizationRecordDetailCode
				if((select COUNT(*) Quantity from ImmunizationRecordDetail where ImmunizationRecordCode=@ImmunizationRecordCode)<=0)
				begin
					update SuggestedServiceReceipt set Status=0 where ReceiptID=(select ReceiptID from ImmunizationRecord where ImmunizationRecordCode=@ImmunizationRecordCode and PatientReceiveID=@PatientReceiveID)
					delete from ImmunizationRecord where ImmunizationRecordCode=@ImmunizationRecordCode
				end
				set @Result=1
			end
		else
			begin
				delete from ImmunizationRecordDetail where ImmunizationRecordDetailCode=@ImmunizationRecordDetailCode
				if((select COUNT(*) Quantity from ImmunizationRecordDetail where ImmunizationRecordCode=@ImmunizationRecordCode)<=0)
				begin
					update SuggestedServiceReceipt set Status=0 where ReceiptID=(select ReceiptID from ImmunizationRecord where ImmunizationRecordCode=@ImmunizationRecordCode and PatientReceiveID=@PatientReceiveID)
					delete from ImmunizationRecord where ImmunizationRecordCode=@ImmunizationRecordCode
				end
				set @Result=1
			end
	end
	else
		set @Result=-1
end
go
if exists(select name from sysobjects where name like'proDelImmunizationRecordWithMedical')
	drop procedure proDelImmunizationRecordWithMedical
go
create procedure proDelImmunizationRecordWithMedical
(
	@ImmunizationRecordCode varchar(15),
	@ImmunizationRecordDetailCode varchar(15),
	@PatientReceiveID numeric(18,0),
	@EmployeeCode varchar(50),
	@MedicalRecordCode varchar(50),
	@Result int output
)
as
begin
	declare @ContentNew nvarchar(max)=''
	declare @ContentOld nvarchar(max)=''
	if exists(select ImmunizationRecordDetailCode from ImmunizationRecordDetail where ImmunizationRecordDetailCode=@ImmunizationRecordDetailCode)
	begin
		delete MedicalPrescriptionDetail where MedicalRecordCode in(select MedicalRecordCode from MedicalRecord where MedicalRecordCode=@MedicalRecordCode and Paid=0 and (BanksAccountCode is null or BanksAccountCode='') and TypeMedical=3) and Status=0
		delete MedicalRecord where MedicalRecordCode=@MedicalRecordCode and Paid=0 and (BanksAccountCode is null or BanksAccountCode='') and TypeMedical=3
		delete from ImmunizationRecordDetail where ImmunizationRecordDetailCode=@ImmunizationRecordDetailCode
		if((select COUNT(*) Quantity from ImmunizationRecordDetail where ImmunizationRecordCode=@ImmunizationRecordCode)<=0)
		begin
			update SuggestedServiceReceipt set Status=0 where ReceiptID=(select ReceiptID from ImmunizationRecord where ImmunizationRecordCode=@ImmunizationRecordCode and PatientReceiveID=@PatientReceiveID)
			delete from ImmunizationRecord where ImmunizationRecordCode=@ImmunizationRecordCode
		end
		set @Result=1
	end
	else
		set @Result=-1
end
go
IF ( NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ImmunizationRecordDetail'))
BEGIN
    create table ImmunizationRecordDetail
    (
		RowID numeric(18,0) identity(1,1),
		ImmunizationRecordCode varchar(15),
		ImmunizationRecordDetailCode varchar(15),
		RowIDDoseNo int,
		LotNo varchar(50),
		Note nvarchar(200),
		Content nvarchar(max),
		IDate datetime default getdate(),
		UDate datetime default getdate(),
		DateGiven datetime,
		AppointmentDate varchar(10),
		AppointmentContent nvarchar(200),
		EmployeeCode varchar(50),
		CONSTRAINT pk_ImmunizationRecordDetail primary key (ImmunizationRecordDetailCode),
		Constraint fk_ImmunizationRecordDetail_Employee foreign key(EmployeeCode) references Employee(EmployeeCode),
		Constraint fk_ImmunizationRecordDetail_ImmunizationRecord foreign key(ImmunizationRecordCode) references ImmunizationRecord(ImmunizationRecordCode),
		Constraint fk_ImmunizationRecordDetail_CatalogDoseNo foreign key(RowIDDoseNo) references CatalogDoseNo(RowID),
		CONSTRAINT uni_ImmunizationRecordDetail UNIQUE(ImmunizationRecordCode, RowIDDoseNo)
    )
END
go
if exists(select name from sysobjects where name like'%proInsImmunizationRecordDetail%')
	drop procedure proInsImmunizationRecordDetail
go
create procedure proInsImmunizationRecordDetail
(
	@ImmunizationRecordDetailCode varchar(15),
	@ImmunizationRecordCode varchar(15),
	@RowIDDoseNo int,
	@LotNo varchar(50),
	@Note nvarchar(200),
	@Content nvarchar(max),
	@DateGiven datetime,
	@AppointmentDate varchar(20),
	@AppointmentContent nvarchar(200),
	@EmployeeCode varchar(50),
	@ShiftWork char(2),
	@EmployeeCodeDoctor varchar(50),
	@ReturnCode varchar(15) output
)
as
begin
	declare @ContentNew nvarchar(max)=''
	declare @ContentOld nvarchar(max)=''
	declare @IDate datetime=getdate()
	declare @UDate datetime=getdate()
	--@ImmunizationRecordDetailCode^@ImmunizationRecordCode^@RowIDDoseNo^@LotNo^@Note^@Content^@IDate^@UDate^@DateGiven^@AppointmentDate^@AppointmentContent^@EmployeeCode
	set @ContentNew=(@ImmunizationRecordDetailCode+'^'+@ImmunizationRecordCode+'^'+CONVERT(varchar(2),@RowIDDoseNo)+'^'+CONVERT(varchar(2),@LotNo)+'^'+@Note+'^'+@Content+'^'+CONVERT(varchar(20),@IDate)+'^'+CONVERT(varchar(20),@UDate)+'^'+CONVERT(varchar(20),@DateGiven)+'^'+@AppointmentDate+'^'+@AppointmentContent+'^'+@EmployeeCode)
	set @ContentOld=(select ImmunizationRecordDetailCode+'^'+ImmunizationRecordCode+'^'+CONVERT(varchar(2),RowIDDoseNo)+'^'+CONVERT(varchar(2),LotNo)+'^'+Note+'^'+Content+'^'+CONVERT(varchar(20),IDate)+'^'+CONVERT(varchar(20),UDate)+'^'+CONVERT(varchar(20),DateGiven)+'^'+AppointmentDate+'^'+AppointmentContent+'^'+EmployeeCode from ImmunizationRecordDetail where ImmunizationRecordDetailCode=@ImmunizationRecordDetailCode)
	if exists(select ImmunizationRecordCode from ImmunizationRecordDetail where ImmunizationRecordDetailCode=@ImmunizationRecordDetailCode)
	begin
		exec ProInsLogEventInsUpdDel 'Upd',@ContentOld,@ContentNew,@EmployeeCode,'ImmunizationRecordDetail'
		update ImmunizationRecordDetail set ImmunizationRecordCode=@ImmunizationRecordCode,RowIDDoseNo=@RowIDDoseNo,LotNo=@LotNo,Note=@Note,Content=@Content,UDate=@UDate,DateGiven=@DateGiven,AppointmentDate=@AppointmentDate,EmployeeCode=@EmployeeCode,ShiftWork=@ShiftWork,EmployeeCodeDoctor=@EmployeeCodeDoctor where ImmunizationRecordDetailCode=@ImmunizationRecordDetailCode
		set @ReturnCode=@ImmunizationRecordDetailCode
	end
	else
	begin
		declare @_Code varchar(50)
		declare @_stt numeric(18,0)
		set @_stt = isnull((select top(1) CONVERT(numeric(18,0),isnull(SUBSTRING(ImmunizationRecordDetailCode,4,12),0)) maxcode from ImmunizationRecordDetail order by CONVERT(numeric(18,0),isnull(SUBSTRING(ImmunizationRecordDetailCode,4,12),0)) desc),0)+1
		set @_Code='TCC'+CONVERT(varchar(12),@_stt)
		insert into ImmunizationRecordDetail(ImmunizationRecordDetailCode,ImmunizationRecordCode,RowIDDoseNo,LotNo,Note,Content,IDate,UDate,DateGiven,AppointmentDate,AppointmentContent,EmployeeCode,ShiftWork,EmployeeCodeDoctor) values(@_Code,@ImmunizationRecordCode,@RowIDDoseNo,@LotNo,@Note,@Content,@IDate,@UDate,@DateGiven,@AppointmentDate,@AppointmentContent,@EmployeeCode,@ShiftWork,@EmployeeCodeDoctor)
		set @ReturnCode=@_Code
		exec ProInsLogEventInsUpdDel 'Ins',@ContentOld,@ContentNew,@EmployeeCode,'ImmunizationRecordDetail'
	end
end
go
if exists(select name from sysobjects where name like'%ProInsLogEventInsUpdDel%')
	drop procedure ProInsLogEventInsUpdDel
go
-----------Update 31/01/2015
if not exists(select * from sys.columns where Name = N'EmployeeCode' and Object_ID = Object_ID(N'DiagnosisAbbreviations'))
	alter table DiagnosisAbbreviations add EmployeeCode varchar(10) not null
go
if not exists(select * from sys.columns where Name = N'RowIDMedicalPattern' and Object_ID = Object_ID(N'MedicalRecord'))
	alter table MedicalRecord add RowIDMedicalPattern int default -1 not null
go
if not exists(select * from sys.columns where Name = N'ContentMedicalPattern' and Object_ID = Object_ID(N'MedicalRecord'))
	alter table MedicalRecord add ContentMedicalPattern nvarchar(max) default ''
go
-----------Update ngay 24/01/2015
IF ( NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LogEventInsUpdDel'))
BEGIN
    create table LogEventInsUpdDel
    (
		RowID numeric(18,0) identity(1,1),
		InsUpdDel char(3),
		ContentOld nvarchar(max),
		ContentNew nvarchar(max),
		IDate datetime default getdate(),
		EmployeeCode varchar(50),
		TableName nvarchar(max),
		CONSTRAINT LogEventInsUpdDel_pk primary key (RowID)
    )
END
if exists(select name from sysobjects where name like'%ProInsLogEventInsUpdDel%')
	drop procedure ProInsLogEventInsUpdDel
go
create procedure ProInsLogEventInsUpdDel
(
	@InsUpdDel char(3),
	@ContentOld nvarchar(max),
	@ContentNew nvarchar(max),
	@EmployeeCode varchar(50),
	@TableName varchar(max)
)
as
begin
	insert into LogEventInsUpdDel(InsUpdDel,ContentOld,ContentNew,EmployeeCode,IDate,TableName) values(@InsUpdDel,@ContentOld,@ContentNew,@EmployeeCode,GETDATE(),@TableName)
end
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MedicalPattern')
begin
CREATE TABLE MedicalPattern
(
	RowID int identity(1,1),
	Title nvarchar(200),
	Content nvarchar(max),
	ServiceCode varchar(50),
	EmployeeCode varchar(50),
	IDate datetime default getdate()
	CONSTRAINT MedicalPattern_pk PRIMARY KEY (RowID),
	CONSTRAINT fk_MedicalPattern_Employee foreign key(EmployeeCode) references Employee(EmployeeCode)
)
end
go
if exists(select name from sysobjects where name like'%proInsMedicalPattern%')
	drop procedure proInsMedicalPattern
go
create procedure proInsMedicalPattern
(
	@RowID int,
	@Title nvarchar(200),
	@Content nvarchar(max),
	@ServiceCode varchar(50),
	@EmployeeCode varchar(50),
	@Result int output
)
as
begin
	declare @ContentNew nvarchar(max)=''
	declare @ContentOld nvarchar(max)=''
	set @ContentNew=CONVERT(varchar(10),@RowID)+'^'+@Title+'^'+@Content+'^'+@ServiceCode+'^'+@EmployeeCode
	set @ContentOld=(select (CONVERT(varchar(10),RowID)+'^'+Title+'^'+Content+'^'+ServiceCode+'^'+EmployeeCode) from MedicalPattern where RowID=@RowID)
	if exists(select RowID from MedicalPattern where RowID=@RowID)
		begin
			exec ProInsLogEventInsUpdDel 'Upd',@ContentOld,@ContentNew,@EmployeeCode,'MedicalPattern'
			update MedicalPattern set Title=@Title,Content=@Content,ServiceCode=@ServiceCode,EmployeeCode=@EmployeeCode where RowID=@RowID
			set @Result=1
		end
	else
		begin
			insert into MedicalPattern(Title,Content,ServiceCode,EmployeeCode) values(@Title,@Content,@ServiceCode,@EmployeeCode)
			set @Result=1
			exec ProInsLogEventInsUpdDel 'Ins',@ContentOld,@ContentNew,@EmployeeCode,'MedicalPattern'
		end
end
go
if exists(select name from sysobjects where name like'%proDelMedicalPattern%')
	drop procedure proDelMedicalPattern
go
create procedure proDelMedicalPattern
(
	@RowID int,
	@EmployeeCode varchar(50),
	@Result int output
)
as
begin
	declare @ContentNew nvarchar(max)=''
	declare @ContentOld nvarchar(max)=''
	set @ContentOld=(select (CONVERT(varchar(10),RowID)+'^'+Title+'^'+Content+'^'+ServiceCode+'^'+EmployeeCode) from MedicalPattern where RowID=@RowID)
	if not exists(select RowIDMedicalPattern from MedicalRecord where RowIDMedicalPattern=@RowID)
		begin
			exec ProInsLogEventInsUpdDel 'Del',@ContentOld,@ContentNew,@EmployeeCode,'MedicalPattern'
			delete from MedicalPattern where RowID=@RowID
			set @Result=1
		end
	else
		set @Result=-1
end
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'PatientsRelationMenu')
begin
CREATE TABLE PatientsRelationMenu
(
	RowID int identity(1,1),
	RelationTitle nvarchar(250),
	EmployeeCode varchar(50),
	IDate datetime default getdate()
	CONSTRAINT PatientsRelationMenu_pk PRIMARY KEY (RowID),
	CONSTRAINT fk_PatientsRelationMenu_Employee foreign key(EmployeeCode) references Employee(EmployeeCode)
)
end
go
if exists(select name from sysobjects where name like'%proDelPatientsRelationMenu%')
	drop procedure proDelPatientsRelationMenu
go
create procedure proDelPatientsRelationMenu
(
	@RowID numeric(18,0),
	@Result int output
)
as
begin
	if not exists(select RowIDMenu from PatientsRelation where RowIDMenu=@RowID)
		begin
			delete from PatientsRelationMenu where RowID=@RowID
			set @Result=1
		end
	else
		set @Result=-1
end
go
if exists(select name from sysobjects where name like'%proInsPatientsRelationMenu%')
	drop procedure proInsPatientsRelationMenu
go
create procedure proInsPatientsRelationMenu
(
	@RowID int,
	@RelationTitle nvarchar(250),
	@EmployeeCode nvarchar(50)
)
as
begin
	if exists(select RowID from PatientsRelationMenu where RowID=@RowID)
	begin
		update PatientsRelationMenu set RelationTitle=@RelationTitle,EmployeeCode=@EmployeeCode where RowID=@RowID
	end
	else
	begin
		insert into PatientsRelationMenu(RelationTitle,EmployeeCode) values(@RelationTitle,@EmployeeCode)
	end
end
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'PatientsRelation')
begin
CREATE TABLE PatientsRelation
(
	RowID numeric(18,0) identity(1,1),
	PatientCode varchar(50),
	PatientReceiveID numeric(18,0),
	RelationContent nvarchar(500),
	EmployeeCode varchar(50),
	IDate datetime default getdate(),
	RowIDMenu int,
	CONSTRAINT PatientsRelation_pk PRIMARY KEY (RowID),
	CONSTRAINT fk_PatientsRelation_Employee foreign key(EmployeeCode) references Employee(EmployeeCode),
	CONSTRAINT fk_PatientsRelation_PatientsRelationMenu foreign key(RowIDMenu) references PatientsRelationMenu(RowID)
)
end
go
if exists(select name from sysobjects where name like'%proDelPatientsRelation%')
	drop procedure proDelPatientsRelation
go
create procedure proDelPatientsRelation
(
	@RowID numeric(18,0)
)
as
begin
	delete from PatientsRelation where RowID=@RowID
end
go
if exists(select name from sysobjects where name like'%proInsPatientsRelation%')
	drop procedure proInsPatientsRelation
go
create procedure proInsPatientsRelation
(
	@RowID numeric(18,0),
	@PatientCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@RelationContent nvarchar(500),
	@EmployeeCode nvarchar(50),
	@MedicalHistory nvarchar(250),
	@Age varchar(3),
	@CareerName nvarchar(100),
	@RowIDMenu int
)
as
begin
	if exists(select RowID from PatientsRelation where RowID=@RowID)
	begin
		update PatientsRelation set RelationContent=@RelationContent,EmployeeCode=@EmployeeCode,MedicalHistory=@MedicalHistory,Age=@Age,CareerName=@CareerName where RowID=@RowID
	end
	else
	begin
		insert into PatientsRelation(PatientCode,RelationContent,EmployeeCode,PatientReceiveID,RowIDMenu,MedicalHistory,Age,CareerName) values(@PatientCode,@RelationContent,@EmployeeCode,@PatientReceiveID,@RowIDMenu,@MedicalHistory,@Age,@CareerName)
	end
end
go
if not exists(select * from sys.columns where Name = N'STT' and Object_ID = Object_ID(N'ServiceLaboratoryEntry'))
	alter table ServiceLaboratoryEntry add STT int default 0 not null
go
if not exists(select * from sys.columns where Name = N'IDWarehousingDetail' and Object_ID = Object_ID(N'InventoryGumshoe'))
	alter table InventoryGumshoe add IDWarehousingDetail int default -1 not null
go
if exists(select name from sysobjects where name like'%pro_upd_nhapxuat%')
	drop procedure pro_upd_nhapxuat
go
create procedure pro_upd_nhapxuat
(
	@RepositoryCode varchar(50)
)
as
begin
	declare @RepositoryGroupCode numeric(2,0)
	declare @ItemCode varchar(50)=''
	declare @ItemCodeTemp varchar(50)=''
	declare @Count numeric(18,0)=0
	declare @RowIDGumshoe numeric(18,0)
	declare @SlXuat numeric(18,3)
	Declare @TableTemp table(RowIDInventoryGumshoe numeric(18,0),ItemCode varchar(50))
	select @RepositoryGroupCode=RepositoryGroupCode from RepositoryCatalog where RepositoryCode=@RepositoryCode
	
	if @RepositoryGroupCode=1
	   begin
			insert @TableTemp(RowIDInventoryGumshoe,ItemCode)(select RowID,ItemCode from InventoryGumshoe where RepositoryCode=@RepositoryCode) order by ItemCode asc
			set @Count = (select COUNT(*) sl from @TableTemp)
			WHILE(@Count) > 0
			BEGIN
					SELECT TOP (1) @ItemCode=ItemCode,@RowIDGumshoe=RowIDInventoryGumshoe FROM @TableTemp
					if @ItemCodeTemp<>@ItemCode
					begin
						update InventoryGeneral set AmountExport=0,AmountEnd=AmountImport where RepositoryCode=@RepositoryCode and ItemCode=@ItemCode  and Hide = 0
						set @ItemCodeTemp=@ItemCode
					end
					set @SlXuat = ((select isnull(sum(a.AmountRealExport),0) SlXuat from ExportWarehousingDetail a inner join ExportWarehousing b on a.ExpWarehousingCode=b.ExpRepositoryCode where a.RowIDGumshoe=@RowIDGumshoe and a.ItemCode=@ItemCode and a.RepositoryExportCode=@RepositoryCode and b.Type=1)
									+ (select isnull(SUM(b.AmountRealExport),0) from ExportVendor a inner join ExportVendorDetail b on a.ExportVendorCode=b.ExportVendorCode where a.ExpRepositoryCode=@RepositoryCode and b.ItemCode=@ItemCode and b.RowIDGumshoe=@RowIDGumshoe and a.Cancel=0)
									)
					update InventoryGumshoe set AmountExport=@SlXuat where ItemCode=@ItemCode and RowID=@RowIDGumshoe
					update InventoryGeneral set AmountExport=AmountExport+@SlXuat where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode  and Hide = 0
					update InventoryGeneral set AmountEnd=AmountBegin+AmountImport-AmountExport where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode  and Hide = 0
					DELETE FROM @TableTemp where ItemCode=@ItemCode and RowIDInventoryGumshoe=@RowIDGumshoe
				set @Count=@Count-1
			END
	   end
	else
		begin
			insert @TableTemp(RowIDInventoryGumshoe,ItemCode)(select RowID,ItemCode from InventoryGumshoe where RepositoryCode=@RepositoryCode) order by ItemCode asc
			set @Count = (select COUNT(*) sl from @TableTemp)
			WHILE(@Count) > 0
			BEGIN
					SELECT TOP (1) @ItemCode=ItemCode,@RowIDGumshoe=RowIDInventoryGumshoe FROM @TableTemp
					if @ItemCodeTemp<>@ItemCode
					begin
						update InventoryGeneral set AmountExport=0,AmountEnd=AmountImport where RepositoryCode=@RepositoryCode and ItemCode=@ItemCode  and Hide = 0
						set @ItemCodeTemp=@ItemCode
					end
					set @SlXuat=(
								(select isnull(sum(Quantity),0) SlXuat from RealMedicinesForPatientsDetail where RowIDInventoryGumshoe=@RowIDGumshoe and ItemCode=@ItemCode)
								+(select isnull(sum(b.QuantityExport),0)
									from MedicinesRetail a inner join MedicinesRetailDetail b on a.RetailCode=b.RetailCode
									where a.Paid=1 and b.RowIDInventoryGumshoe=@RowIDGumshoe and b.ItemCode=@ItemCode and b.RepositoryCode=@RepositoryCode)
								+(select ISNULL(SUM(b.QuantityExport),0) SlXuat from MedicinesForPatients a inner join MedicinesForPatientsDetail b on a.RowID=b.RowIDMedicines
							where b.RowIDInventoryGumshoe=@RowIDGumshoe and b.ItemCode=@ItemCode and b.RepositoryCode=@RepositoryCode)
								+(select ISNULL(SUM(b.AmountRealExport),0) SlXuat from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode where a.ExpRepositoryCode=@RepositoryCode and b.RowIDGumshoe=@RowIDGumshoe and a.Type=2)
								)
					update InventoryGumshoe set AmountExport=@SlXuat where ItemCode=@ItemCode and RowID=@RowIDGumshoe
					update InventoryGeneral set AmountExport=AmountExport+@SlXuat where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Hide = 0
					update InventoryGeneral set AmountEnd=AmountBegin+AmountImport-AmountExport where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Hide = 0
					DELETE FROM @TableTemp where ItemCode=@ItemCode and RowIDInventoryGumshoe=@RowIDGumshoe
				set @Count=@Count-1
			END
		end
end
go
----------- Update ngay 19/01/2015
if not exists(select * from sys.columns where Name = N'Address' and Object_ID = Object_ID(N'PatientReceive'))
	alter table PatientReceive add Address nvarchar(max) default ''
go
if not exists(select * from sys.columns where Name = N'EThnicID' and Object_ID = Object_ID(N'Patients'))
	alter table Patients add EThnicID int default -1 not null
go
if not exists(select * from sys.columns where Name = N'CareerCode' and Object_ID = Object_ID(N'Patients'))
	alter table Patients add CareerCode varchar(10) default null
go
if not exists(select * from sys.columns where Name = N'NationalityID' and Object_ID = Object_ID(N'Patients'))
	alter table Patients add NationalityID int default -1 not null
go
if not exists(select * from sys.columns where Name = N'ProvincialCode' and Object_ID = Object_ID(N'Patients'))
	alter table Patients add ProvincialCode varchar(3) default null
go
if not exists(select * from sys.columns where Name = N'DistrictCode' and Object_ID = Object_ID(N'Patients'))
	alter table Patients add DistrictCode varchar(5) default null
go
if not exists(select * from sys.columns where Name = N'WardCode' and Object_ID = Object_ID(N'Patients'))
	alter table Patients add WardCode varchar(8) default null
go
if not exists(select * from sys.columns where Name = N'CompanyInfo' and Object_ID = Object_ID(N'PatientReceive'))
	alter table PatientReceive add CompanyInfo nvarchar(200) default ''
go
if not exists(select * from sys.columns where Name = N'EThnicID' and Object_ID = Object_ID(N'PatientReceive'))
	alter table PatientReceive add EThnicID int default -1 not null
go
if not exists(select * from sys.columns where Name = N'CareerCode' and Object_ID = Object_ID(N'PatientReceive'))
	alter table PatientReceive add CareerCode varchar(10) default null
go
if not exists(select * from sys.columns where Name = N'NationalityID' and Object_ID = Object_ID(N'PatientReceive'))
	alter table PatientReceive add NationalityID int default -1 not null
go
if not exists(select * from sys.columns where Name = N'ProvincialCode' and Object_ID = Object_ID(N'PatientReceive'))
	alter table PatientReceive add ProvincialCode varchar(3) default null
go
if not exists(select * from sys.columns where Name = N'DistrictCode' and Object_ID = Object_ID(N'PatientReceive'))
	alter table PatientReceive add DistrictCode varchar(5) default null
go
if not exists(select * from sys.columns where Name = N'WardCode' and Object_ID = Object_ID(N'PatientReceive'))
	alter table PatientReceive add WardCode varchar(8) default null
go
----------- Update ngay 14/01/2015
alter table LaboratoryPackageDetail alter column MinValuedFemale decimal(18,5)
alter table LaboratoryPackageDetail alter column MaxValuedFemale decimal(18,5)
alter table LaboratoryPackageDetail alter column MinValuedMale decimal(18,5)
alter table LaboratoryPackageDetail alter column MaxValuedMale decimal(18,5)
go
-----------Update ngay 10/01/2015
if not exists(select * from sys.columns where Name = N'Report' and Object_ID = Object_ID(N'BanksAccount'))
	alter table BanksAccount add Report int default 1 not null
go
-----------Update ngay 27/12/2014
if not exists(select * from sys.columns where Name = N'STT' and Object_ID = Object_ID(N'LaboratoryPackageDetail'))
	alter table LaboratoryPackageDetail add STT int default 1 not null
go
if not exists(select * from sys.columns where Name = N'STT' and Object_ID = Object_ID(N'ServiceLaboratoryDetail'))
	alter table ServiceLaboratoryDetail add STT int default 1 not null
go
if not exists(select * from sys.columns where Name = N'ParameterMachine' and Object_ID = Object_ID(N'ServiceLaboratoryDetail'))
	alter table ServiceLaboratoryDetail add ParameterMachine nvarchar(50) default '' not null
go
if not exists(select * from sys.columns where Name = N'ParameterMachine' and Object_ID = Object_ID(N'LaboratoryPackageDetail'))
	alter table LaboratoryPackageDetail add ParameterMachine nvarchar(50) default '' not null
go
if not exists(select * from sys.columns where Name = N'STT' and Object_ID = Object_ID(N'ServiceLaboratoryEntry'))
	alter table ServiceLaboratoryEntry add STT int default 0 not null
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MachineLists')
begin
CREATE TABLE MachineLists
(
	RowID int identity(1,1),
	MechineCode varchar(5),
	MechineName nvarchar(250) not null,
	ServiceCategoryCode varchar(50),
	Hide int default 0,
	IDate datetime default getdate()
	CONSTRAINT MachineLists_pk PRIMARY KEY (RowID),
	CONSTRAINT fk_MachineLists_ServiceCategory foreign key(ServiceCategoryCode) references ServiceCategory(ServiceCategoryCode)
)
end
go
if exists(select name from sysobjects where name ='proIU_MachineLists')
	drop procedure proIU_MachineLists
go
create procedure proIU_MachineLists
(
	@RowID int,
	@MechineCode varchar(5),
	@MechineName nvarchar(250),
	@ServiceCategoryCode varchar(50),
	@Hide int =0,
	@Result int output
)
as
begin
	if exists(select RowID from MachineLists where RowID=@RowID)
	begin
		update MachineLists set MechineCode=@MechineCode,MechineName=@MechineName,ServiceCategoryCode=@ServiceCategoryCode,Hide=@Hide where RowID=@RowID
		set @Result =2
	end
	else
	begin
		insert into MachineLists(MechineCode,MechineName,ServiceCategoryCode,Hide,IDate) values (@MechineCode,@MechineName,@ServiceCategoryCode,@Hide,GETDATE())
		set @Result =1
	end
end
go
---------------------------------Exec table ServiceGroup
if exists(select name from sysobjects where name like'%pro_Del_ServiceGroup%')
	drop procedure pro_Del_ServiceGroup
go
create procedure pro_Del_ServiceGroup
(
	@ServiceGroupCode varchar(50),
	@iresult int output
)
as
begin
	if exists(select ServiceGroupCode from [ServiceCategory] where ServiceGroupCode=@ServiceGroupCode)
		set @iresult =-1
	else
	begin
		delete ServiceGroup where ServiceGroupCode=@ServiceGroupCode
		set @iresult =1
	end
end
go
--declare @istatus int
--exec pro_Del_ServiceGroup 'XN',@istatus output
--print @istatus
---------------------------------- Exec table ServiceCategory
if exists(select name from sysobjects where name ='pro_Ins_ServiceCategory')
	drop procedure pro_Ins_ServiceCategory
go
create procedure pro_Ins_ServiceCategory
(
	@ServiceGroupCode varchar(50),
	@ServiceCategoryCode varchar(50),
	@ServiceCategoryName nvarchar(max),
	@STT int
)
as
begin
	if exists(select ServiceGroupCode from [ServiceCategory] where ServiceCategoryCode=@ServiceCategoryCode)
	begin
		update [ServiceCategory] set ServiceGroupCode=@ServiceGroupCode,ServiceCategoryName=@ServiceCategoryName,STT=@STT where ServiceCategoryCode=@ServiceCategoryCode
	end
	else
	begin
		declare @_CategoryCode varchar(50)
		declare @_stt decimal(18,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(ServiceCategoryCode,4)) maxcode from [ServiceCategory] order by RowID desc)+1
		if(@_stt<=9)
			begin
				set @_CategoryCode = 'LO000'+convert(varchar(50),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_CategoryCode = 'LO00'+convert(varchar(50),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_CategoryCode = 'LO0'+convert(varchar(50),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_CategoryCode = 'LO'+convert(varchar(50),@_stt)
			end
		else
			begin
				set @_CategoryCode = 'LO0001'
			end
		insert into [ServiceCategory](ServiceGroupCode,ServiceCategoryCode,ServiceCategoryName,STT) values(@ServiceGroupCode,@_CategoryCode,@ServiceCategoryName,@STT)
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_ServiceCategory%')
	drop procedure pro_Del_ServiceCategory
go
create procedure pro_Del_ServiceCategory
(
	@ServiceCategoryCode varchar(50),
	@iresult int output
)
as
begin
	if exists(select ServiceCategoryCode from [Service] where ServiceCategoryCode=@ServiceCategoryCode)
		set @iresult =-1
	else
	begin
		delete ServiceCategory where ServiceCategoryCode=@ServiceCategoryCode
		set @iresult =1
	end
end
go
---------------------------------- Exec table Department
if exists(select name from sysobjects where name = 'pro_Ins_Department')
	drop procedure pro_Ins_Department
go
create procedure pro_Ins_Department
(
	@DepartmentCode varchar(50),
	@DepartmentName nvarchar(max),
	@ServiceGroupCode varchar(50),
	@Hide int,
	@IdBv int,
	@KBHYT varchar(50)
	
)
as
begin
	if exists(select DepartmentCode from [Department] where DepartmentCode=@DepartmentCode)
	begin
		update Department set DepartmentName=@DepartmentName,ServiceGroupCode=@ServiceGroupCode,Hide=@Hide,IdBv=@IdBv,KBHYT=@KBHYT where DepartmentCode=@DepartmentCode
	end
	else
	begin
		declare @_DepartmentCode varchar(50)
		declare @_stt decimal(18,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(DepartmentCode,4)) maxcode from Department order by CONVERT(decimal(18,0),RIGHT(DepartmentCode,4)) desc)+1
		print @_stt
		if(@_stt<=9)
			begin
				set @_DepartmentCode = 'KP000'+convert(varchar(50),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_DepartmentCode = 'KP00'+convert(varchar(50),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_DepartmentCode = 'KP0'+convert(varchar(50),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_DepartmentCode = 'KP'+convert(varchar(50),@_stt)
			end
		else
			begin
				set @_DepartmentCode = 'KP0001'
			end
		insert into Department(DepartmentCode,DepartmentName,ServiceGroupCode,Hide,IdBv,KBHYT) values(@_DepartmentCode,@DepartmentName,@ServiceGroupCode,@Hide,@IdBv,@KBHYT)
	end
end
go
--select * from Department
--exec pro_Ins_Department '','aaa','KCB',1
if exists(select name from sysobjects where name like'%pro_Del_Department%')
	drop procedure pro_Del_Department
go
create procedure pro_Del_Department
(
	@DepartmentCode varchar(50),
	@iresult int output
)
as
begin
	if exists(select DepartmentCode from [Service] where DepartmentCode=@DepartmentCode)
		set @iresult =-1
	else if exists(select DepartmentCode from SuggestedServiceReceipt where DepartmentCode=@DepartmentCode)
		set @iresult =-1
	else
	begin
		delete Department where DepartmentCode=@DepartmentCode
		set @iresult =1
	end
end
go
---exec pro_Del_Department 'KP0001',1
---------------------------------- Exec Hang san xuat [Producer]
if exists(select name from sysobjects where name like'%pro_Ins_Producer%')
	drop procedure pro_Ins_Producer
go
create procedure pro_Ins_Producer
(
	@ProducerCode varchar(50),
	@ProducerName nvarchar(max),
	@Hide int
)
as
begin
	if exists(select ProducerCode from Producer where ProducerCode=@ProducerCode)
	begin
		update Producer set ProducerName=@ProducerName,Hide=@Hide where ProducerCode=@ProducerCode
	end
	else
	begin
		declare @_TempCode varchar(50)
		declare @_stt decimal(18,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(ProducerCode,4)) maxcode from Producer order by RowID desc)+1
		if(@_stt<=9)
			begin
				set @_TempCode = 'HSX000'+convert(varchar(50),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_TempCode = 'HSX00'+convert(varchar(50),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_TempCode = 'HSX0'+convert(varchar(50),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_TempCode = 'HSX'+convert(varchar(50),@_stt)
			end
		else
			begin
				set @_TempCode = 'HSX0001'
			end
		insert into Producer(ProducerCode,ProducerName,Hide) values(@_TempCode,@ProducerName,@Hide)
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_Producer%')
	drop procedure pro_Del_Producer
go
create procedure pro_Del_Producer
(
	@ProducerCode varchar(50),
	@iresult int output
)
as
begin
	if exists(select ProducerCode from Items where ProducerCode=@ProducerCode)
		set @iresult =-1
	else
	begin
		delete Producer where ProducerCode=@ProducerCode
		set @iresult =1
	end
end
go
---------------------------------- Exec Nuoc San xuat [Country]
if exists(select name from sysobjects where name like'%pro_Ins_Country%')
	drop procedure pro_Ins_Country
go
create procedure pro_Ins_Country
(
	@CountryCode varchar(6),
	@CountryName nvarchar(250)
)
as
begin
	if exists(select CountryCode from Country where CountryCode=@CountryCode)
	begin
		update Country set CountryName=@CountryName where CountryCode=@CountryCode
	end
	else
	begin
		declare @_TempCode varchar(50)
		declare @_stt decimal(18,0)
		set @_stt = (select top(1) CONVERT(decimal(3,0),RIGHT(CountryCode,3)) maxcode from Country order by CONVERT(decimal(3,0),RIGHT(CountryCode,3)) desc)+1
		if(@_stt<=9)
			begin
				set @_TempCode = 'NSX00'+convert(varchar(6),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_TempCode = 'NSX0'+convert(varchar(6),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_TempCode = 'NSX'+convert(varchar(6),@_stt)
			end
		else
			begin
				set @_TempCode = 'NSX001'
			end
		insert into Country(CountryCode,CountryName) values(@_TempCode,@CountryName)
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_Country%')
	drop procedure pro_Del_Country
go
create procedure pro_Del_Country
(
	@CountryCode varchar(6),
	@iresult int output
)
as
begin
	if exists(select CountryCode from Items where CountryCode=@CountryCode)
		set @iresult =-1
	else
	begin
		delete Country where CountryCode=@CountryCode
		set @iresult =1
	end
end
go
------------------------Execute table Service
if exists(select name from sysobjects where name ='pro_Ins_Service')
	drop procedure pro_Ins_Service
go
create procedure pro_Ins_Service
(
	@ServiceCategoryCode varchar(50),
	@ServiceCode varchar(50),
	@ServiceName nvarchar(max),
	@DepartmentCode nvarchar(250),
	@Hide int,
	@ServiceGroupCode varchar(50),
	@EmployeeCode varchar(50),
	@PatientType varchar(20),
	@Serial int,
	@UnitOfMeasureCode varchar(50),
	@SampleTransfer int,
	@MaTuongDuong_BHYT varchar(50),
	@MaCK_BHYT varchar(50),
	@MaDK_BHYT varchar(50),
	@Note varchar(max)='',
	@SOQDPK nvarchar(20)='',
	@Ma_TT37 varchar(15)='',
	@Ten_TT37 nvarchar(2000)='',
	@IDGroupPrint int=0
)
as
begin
	if @Serial=0
		set @Serial=(select ISNULL(MAX(serial),1)+1 from [Service])
	if exists(select ServiceCode from [Service] where ServiceCode=@ServiceCode)
	begin
		update [Service] set ServiceCategoryCode=@ServiceCategoryCode,ServiceName=@ServiceName,DepartmentCode=@DepartmentCode,Hide=@Hide,ServiceGroupCode=@ServiceGroupCode,EmployeeCode=@EmployeeCode,PatientType=@PatientType,Serial=@Serial,UnitOfMeasureCode=@UnitOfMeasureCode,SampleTransfer=@SampleTransfer,MaTuongDuong_BHYT=@MaTuongDuong_BHYT,MaCK_BHYT=@MaCK_BHYT,MaDK_BHYT=@MaDK_BHYT,Note=@Note,SOQDPK=@SOQDPK,Ma_TT37=@Ma_TT37,Ten_TT37=@Ten_TT37,IDGroupPrint=@IDGroupPrint where ServiceCode=@ServiceCode
	end
	else
	begin
		declare @_ServiceCode varchar(50)
		declare @_stt decimal(18,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(ServiceCode,6)) maxcode from [Service] order by CONVERT(decimal(18,0),RIGHT(ServiceCode,6)) desc)+1
		if(@_stt<=9)
			begin
				set @_ServiceCode = 'DV00000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_ServiceCode = 'DV0000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_ServiceCode = 'DV000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_ServiceCode = 'DV00'+convert(varchar(10),@_stt)
			end
		else if(@_stt>9999 and @_stt<=99999)
			begin
				set @_ServiceCode = 'DV0'+convert(varchar(10),@_stt)
			end
		else if(@_stt>99999 and @_stt<=999999)
			begin
				set @_ServiceCode = 'DV'+convert(varchar(10),@_stt)
			end
		else
			begin
				set @_ServiceCode = 'DV000001'
			end
		insert into [Service](ServiceCategoryCode,ServiceCode,ServiceName,DepartmentCode,Hide,ServiceGroupCode,EmployeeCode,PatientType,Serial,UnitOfMeasureCode,SampleTransfer,MaTuongDuong_BHYT,MaCK_BHYT,MaDK_BHYT,Note,SOQDPK,Ma_TT37,Ten_TT37,IDGroupPrint) values(@ServiceCategoryCode,@_ServiceCode,@ServiceName,@DepartmentCode,@Hide,@ServiceGroupCode,@EmployeeCode,@PatientType,@Serial,@UnitOfMeasureCode,@SampleTransfer,@MaTuongDuong_BHYT,@MaCK_BHYT,@MaDK_BHYT,@Note,@SOQDPK,@Ma_TT37,@Ten_TT37,@IDGroupPrint)
	end
end
go
if exists(select name from sysobjects where name ='pro_Del_Service')
	drop procedure pro_Del_Service
go
create procedure pro_Del_Service
(
	@ServiceCode varchar(50),
	@iresult int output
)
as
begin
	if exists(select ServiceCode from [ServicePrice] where ServiceCode=@ServiceCode)
		set @iresult =-1
	else if exists(select ServiceCode from SuggestedServiceReceipt where ServiceCode=@ServiceCode)
		set @iresult =-1
	else
	begin
		delete from [Service] where ServiceCode=@ServiceCode
	set @iresult =1
	end
end
go
-------------------------------- Table ServicePrice
if exists(select name from sysobjects where name ='pro_Ins_ServicePrice')
	drop procedure pro_Ins_ServicePrice
go
create procedure pro_Ins_ServicePrice
(
	@RowID decimal(18,0),
	@ServiceCode varchar(50),
	@UnitPrice decimal(18,2),
	@ObjectCode int,
	@DateOfApplication datetime,
	@EmployeeCode varchar(50),
	@DisparityPrice numeric(18,2),
	@Hide int,
	@SampleTransferPrice decimal(18,2),
	@DateOfApplicationEnd date,
	@PerDiscountIntro int=0,
	@DiscountIntro numeric(18,2)=0,
	@PerDiscountDoctorDone int=0,
	@DiscountDoctorDone numeric(18,2)=0,
	@PerDiscountDoctor int=0,
	@DiscountDoctor numeric(18,2)=0
)
as
begin
	if exists(select ServiceCode from [ServicePrice] where RowID=@RowID )
	begin
		update ServicePrice set UnitPrice=@UnitPrice,ObjectCode=@ObjectCode,DateOfApplication=@DateOfApplication,EmployeeCode=@EmployeeCode,DisparityPrice=@DisparityPrice,Hide=@Hide,SampleTransferPrice=@SampleTransferPrice,DateOfApplicationEnd=@DateOfApplicationEnd,PerDiscountIntro=@PerDiscountIntro,DiscountIntro=@DiscountIntro,PerDiscountDoctorDone=@PerDiscountDoctorDone,DiscountDoctorDone=@DiscountDoctorDone,PerDiscountDoctor=@PerDiscountDoctor,DiscountDoctor=@DiscountDoctor where RowID=@RowID
		--update SuggestedServiceReceipt set ServicePrice=@UnitPrice,DisparityPrice=@DisparityPrice where RowIDPrice=@RowID
	end
	else
	begin
		insert into ServicePrice(ServiceCode,UnitPrice,ObjectCode,DateOfApplication,EmployeeCode,DisparityPrice,Hide,SampleTransferPrice,DateOfApplicationEnd,PerDiscountIntro,DiscountIntro,PerDiscountDoctorDone,DiscountDoctorDone,PerDiscountDoctor,DiscountDoctor) values(@ServiceCode,@UnitPrice,@ObjectCode,@DateOfApplication,@EmployeeCode,@DisparityPrice,@Hide,@SampleTransferPrice,@DateOfApplicationEnd,@PerDiscountIntro,@DiscountIntro,@PerDiscountDoctorDone,@DiscountDoctorDone,@PerDiscountDoctor,@DiscountDoctor)
	end
end
go
--exec pro_Ins_Service 'LO0003','',N'Tét tét','KP0001',1,'CDHA'
if exists(select name from sysobjects where name ='pro_Del_ServicePrice')
	drop procedure pro_Del_ServicePrice
go
create procedure pro_Del_ServicePrice
(
	@RowID decimal(18,0),
	@iresult int output
)
as
begin
	if exists(select ServiceCode from SuggestedServiceReceipt where RowIDPrice=@RowID)
		set @iresult =-1
	else
	begin
		delete from ServicePrice where RowID=@RowID
		set @iresult =1
	end
end
go
------------------------- Table ServicePackage
if exists(select name from sysobjects where name ='pro_Ins_ServicePackage')
	drop procedure pro_Ins_ServicePackage
go
create procedure pro_Ins_ServicePackage
(
	@ServicePackageCode varchar(50),
	@ServicePackageName nvarchar(max),
	@EmployeeCode varchar(50)
)
as
begin
	if exists(select ServicePackageCode from ServicePackage where ServicePackageCode=@ServicePackageCode )
	begin
		update ServicePackage set ServicePackageName=@ServicePackageName,EmployeeCode=@EmployeeCode where ServicePackageCode=@ServicePackageCode
	end
	else
	begin
		declare @_ServicePackageCod varchar(50)
		declare @_stt decimal(18,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(ServicePackageCode,4)) maxcode from ServicePackage order by RowID desc)+1
		
		if(@_stt<=9)
			begin
				set @_ServicePackageCod = 'PK000'+convert(varchar(5),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_ServicePackageCod = 'PK00'+convert(varchar(5),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_ServicePackageCod = 'PK0'+convert(varchar(5),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_ServicePackageCod = 'PKO'+convert(varchar(5),@_stt)
			end
		else
			begin
				set @_ServicePackageCod = 'PK0001'
			end
		insert into ServicePackage(ServicePackageCode,ServicePackageName,EmployeeCode) values(@_ServicePackageCod,@ServicePackageName,@EmployeeCode)
	end
end
go
--exec pro_Ins_Service 'LO0003','',N'Tét tét','KP0001',1,'CDHA'
if exists(select name from sysobjects where name ='pro_Del_ServicePackage')
	drop procedure pro_Del_ServicePackage
go
create procedure pro_Del_ServicePackage
(
	@ServicePackageCode varchar(50),
	@iresult int output
)
as
begin
	delete from ServicePackageDetail where ServicePackageCode=@ServicePackageCode
	delete from ServicePackage where ServicePackageCode=@ServicePackageCode
	set @iresult =1
end
go
------------------------- Table ServicePackageDetail
if exists(select name from sysobjects where name ='pro_Ins_ServicePackageDetail')
	drop procedure pro_Ins_ServicePackageDetail
go
create procedure pro_Ins_ServicePackageDetail
(
	@RowID decimal(18,0),
	@ServicePackageCode varchar(50),
	@ServiceCode varchar(50),
	@EmployeeCode varchar(50),
	@Serial int,
	@ServicePrice decimal(18,2)
)
as
begin
	if exists(select ServicePackageCode from ServicePackageDetail where ServicePackageCode=@ServicePackageCode and ServiceCode=@ServiceCode)
		begin
			update ServicePackageDetail set ServicePackageCode=@ServicePackageCode,ServiceCode=@ServiceCode,EmployeeCode=@EmployeeCode,Serial=@Serial,ServicePrice=@ServicePrice where RowID=@RowID
		end
	else
		begin
			insert into ServicePackageDetail(ServicePackageCode,ServiceCode,EmployeeCode,Serial,ServicePrice) values(@ServicePackageCode,@ServiceCode,@EmployeeCode,@Serial,@ServicePrice)
		End
end
go
if exists(select name from sysobjects where name ='pro_Del_ServicePackageDetail')
	drop procedure pro_Del_ServicePackageDetail
go
create procedure pro_Del_ServicePackageDetail
(
	@RowID decimal(18,0),
	@iresult int output
)
as
begin
	delete from ServicePackageDetail where RowID=@RowID
	set @iresult =1
end
go
-------------------------------------Exec table Object
if exists(select name from sysobjects where name ='pro_Ins_Object')
	drop procedure pro_Ins_Object
go
create procedure pro_Ins_Object
(
	@ObjectCode int,
	@ObjectName nvarchar(max),
	@ObjectCard int
)
as
begin
	if exists(select ObjectCode from [Object] where ObjectCode=@ObjectCode)
	begin
		update [Object] set ObjectName=@ObjectName,ObjectCard=@ObjectCard where ObjectCode=@ObjectCode
	end
	else
	begin
		insert into [Object](ObjectName,ObjectCard) values(@ObjectName,@ObjectCard)
	end
end
go
if exists(select name from sysobjects where name ='pro_Del_Object')
	drop procedure pro_Del_Object
go
create procedure pro_Del_Object
(
	@ObjectCode int,
	@iresult int output
)
as
begin
	if exists(select ObjectCode from [ServicePrice] where ObjectCode=@ObjectCode)
		set @iresult =-1
	else
	begin
		delete from [Object] where ObjectCode=@ObjectCode
		set @iresult =1
	end
end
go
-------------------------------------Exec table Employee
if exists(select name from sysobjects where name ='pro_Ins_Employee')
	drop procedure pro_Ins_Employee
go
create procedure pro_Ins_Employee
(
	@EmployeeCode varchar(50),
	@EmployeeName nvarchar(max),
	@Sex int,
	@Mobile nvarchar(50),
	@IDCard nvarchar(50),
	@Address nvarchar(max),
	@Birthday datetime,
	@PositionCode int,
	@Username varchar(50),
	@Password varchar(50),
	@DepartmentCode varchar(50),
	@offwork int,
	@EmployeeGroupID int,
	@iresult int output
)
as
begin
	if exists(select Username from [Employee] where EmployeeCode=@EmployeeCode)
	begin
		update [Employee] set EmployeeName=@EmployeeName,Sex=@Sex,Mobile=@Mobile,IDCard=@IDCard,[Address]=@Address,Birthday=@Birthday,PositionCode=@PositionCode,Username=@Username,[Password]=@Password,DepartmentCode=@DepartmentCode,OffWork=@offwork,EmployeeGroupID=@EmployeeGroupID where EmployeeCode=@EmployeeCode
		set @iresult = 1
	end
	else
	begin
		declare @_EmployeeCode varchar(50)
		declare @_stt decimal(8,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(EmployeeCode,5)) maxcode from Employee order by RowID desc)+1
		if(@_stt<=9)
			begin
				set @_EmployeeCode = 'NV0000'+convert(varchar(6),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_EmployeeCode = 'NV000'+convert(varchar(6),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_EmployeeCode = 'NV00'+convert(varchar(6),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_EmployeeCode = 'NV0'+convert(varchar(6),@_stt)
			end
		else if(@_stt>9999 and @_stt<=99999)
			begin
				set @_EmployeeCode = 'NV'+convert(varchar(6),@_stt)
			end
		else
			begin
				set @_EmployeeCode = 'NV00001'
			end
		insert into Employee(EmployeeCode,EmployeeName,Sex,Mobile,IDCard,[Address],Birthday,PositionCode,Username,[Password],DepartmentCode,OffWork,EmployeeGroupID) values(@_EmployeeCode,@EmployeeName,@Sex,@Mobile,@IDCard,@Address,@Birthday,@PositionCode,@Username,@Password,@DepartmentCode,@offwork,@EmployeeGroupID)
		set @iresult = 1
	end
end
go
if exists(select name from sysobjects where name ='pro_Del_Employee')
	drop procedure pro_Del_Employee
go
create procedure pro_Del_Employee
(
	@EmployeeCode varchar(50),
	@iresult int output
)
as
begin
	if exists(select EmployeeCode from BanksAccount where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from BHYT where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from Catalog_Food where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from Catalog_SurgicalCrew where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from DepartmentForRepository where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from ExportVendor where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from ExportWarehousing where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from FoodDetail where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from FoodEntry where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from Introducer where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from Items where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from LaboratoryPackage where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from MedicalEmergency where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from MedicalEmergencyOut where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from MedicalRecord where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from MedicinesForPatients where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from MedicinesRetail where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmloyeeCode from PatientAppointment where EmloyeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from PatientReceive where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from RealMedicinesForPatients where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from RepositoryCatalog where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from SamplePrescriptionHeader where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from [Service] where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from ServicePackage where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from ServicePackageDetail where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from ServicePrice where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from ServiceRadiologyEntry where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from SuggestedServiceReceipt where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from Surgeries where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from SurgicalCrew where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from SurviveSign where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from TemplateDescription where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from TemplateItemNorms where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCodeUpd from TemplateItemNorms where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else if exists(select EmployeeCode from Warehousing where EmployeeCode=@EmployeeCode)
		set @iresult =-1
	else
	begin
		delete MenuSecurity where EmployeeCode=@EmployeeCode
		delete Employee where EmployeeCode=@EmployeeCode
		set @iresult =1
	end
end
go
if exists(select name from sysobjects where name like'%pro_Upd_EmployeePermiss%')
	drop procedure pro_Upd_EmployeePermiss
go
create procedure pro_Upd_EmployeePermiss
(
	@EmployeeCode varchar(50),
	@PermissionDepart varchar(500),
	@iresult int output
)
as
begin
	if exists(select Username from [Employee] where EmployeeCode=@EmployeeCode)
	begin
		update [Employee] set PermissionDepart=@PermissionDepart where EmployeeCode=@EmployeeCode
		set @iresult = 1
	end
	else
	begin
		set @iresult = -1
	end
end
go
if exists(select name from sysobjects where name like'%pro_Upd_EmployeeRepository%')
	drop procedure pro_Upd_EmployeeRepository
go
create procedure pro_Upd_EmployeeRepository
(
	@EmployeeCode varchar(50),
	@PermissionRepository varchar(500),
	@iresult int output
)
as
begin
	if exists(select Username from [Employee] where EmployeeCode=@EmployeeCode)
	begin
		update [Employee] set PermissionRepository=@PermissionRepository where EmployeeCode=@EmployeeCode
		set @iresult = 1
	end
	else
	begin
		set @iresult = -1
	end
end
go
--------------------------------table EmployeePosition
if exists(select name from sysobjects where name like'%pro_Del_EmployeePosition%')
	drop procedure pro_Del_EmployeePosition
go
create procedure pro_Del_EmployeePosition
(
	@PositionCode varchar(50),
	@iresult int output
)
as
begin
	if exists(select * from EmployeePosition where PositionCode=@PositionCode)
		set @iresult =-1
	else
	begin
		delete EmployeePosition where PositionCode=@PositionCode
		set @iresult =1
	end
end
go
------------------------------ table nha cung cap [Vendor]
if exists(select name from sysobjects where name like'%pro_Ins_Vendor%')
	drop procedure pro_Ins_Vendor
go
create procedure pro_Ins_Vendor
(
	@VendorCode varchar(50),
	@VendorName nvarchar(max),
	@Salesman nvarchar(50),
	@Address nvarchar(max),
	@Phone nvarchar(50),
	@Email nvarchar(50),
	@Status int,
	@VendorTaxNo nvarchar(50),
	@VendorFax nvarchar(50),
	@VendorBankName nvarchar(50)
)
as
begin
	if exists(select VendorCode from Vendor where VendorCode=@VendorCode)
		begin		
			update Vendor set VendorName=@VendorName,Salesman=@Salesman,[Address]=@Address,Phone=@Phone,Email=@Email,Status=@Status,VendorTaxNo=@VendorTaxNo,VendorFax=@VendorFax,VendorBankName=@VendorBankName where VendorCode=@VendorCode
		end
	else
	begin
		declare @_VendorCode varchar(50)
		declare @_stt decimal(8,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(VendorCode,5)) maxcode from Vendor order by RowID desc)+1
		if(@_stt<=9)
			begin
				set @_VendorCode = 'NCC0000'+convert(varchar(6),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_VendorCode = 'NCC000'+convert(varchar(6),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_VendorCode = 'NCC00'+convert(varchar(6),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_VendorCode = 'NCC0'+convert(varchar(6),@_stt)
			end
		else if(@_stt>9999 and @_stt<=99999)
			begin
				set @_VendorCode = 'NCC'+convert(varchar(6),@_stt)
			end
		else
			begin
				set @_VendorCode = 'NCC00001'
			end
		insert into Vendor(VendorCode,VendorName,Salesman,[address],phone,Email,[status],VendorTaxNo,VendorFax,VendorBankName) values(@_VendorCode,@VendorName,@Salesman,@Address,@Phone,@Email,@Status,@VendorTaxNo,@VendorFax,@VendorBankName)
	end
end
go
if exists(select name from sysobjects where name ='pro_Del_Vendor')
	drop procedure pro_Del_Vendor
go
create procedure pro_Del_Vendor
(
	@VendorCode varchar(50),
	@iresult int output
)
as
begin
	--if exists(select DepartmentCode from [Service] where DepartmentCode=@DepartmentCode)
	--	set @iresult =-1
	--else
	begin
		delete Vendor where VendorCode=@VendorCode
		set @iresult =1
	end
end
go
------------------------------ table duong dung [Usage]
if exists(select name from sysobjects where name ='pro_Ins_Usage')
	drop procedure pro_Ins_Usage
go
create procedure pro_Ins_Usage
(
	@UsageCode varchar(50),
	@UsageName nvarchar(max),
	@STT int,
	@BHYT_MaDuongDung varchar(10)
)
as
begin
	if exists(select UsageCode from Usage where UsageCode=@UsageCode)
		begin		
			update Usage set UsageName=@UsageName,STT=@STT,BHYT_MaDuongDung=@BHYT_MaDuongDung where UsageCode=@UsageCode
		end
	else
	begin
		declare @_UsageCode varchar(50)
		declare @_stt decimal(8,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(UsageCode,5)) maxcode from Usage order by RowID desc)+1
		if(@_stt<=9)
			begin
				set @_UsageCode = 'DD0000'+convert(varchar(6),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_UsageCode = 'DD000'+convert(varchar(6),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_UsageCode = 'DD00'+convert(varchar(6),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_UsageCode = 'DD0'+convert(varchar(6),@_stt)
			end
		else if(@_stt>9999 and @_stt<=99999)
			begin
				set @_UsageCode = 'DD'+convert(varchar(6),@_stt)
			end
		else
			begin
				set @_UsageCode = 'DD00001'
			end
		insert into Usage(UsageCode,UsageName,STT,BHYT_MaDuongDung) values(@_UsageCode,@UsageName,@STT,@BHYT_MaDuongDung)
	end
end
go
if exists(select name from sysobjects where name ='pro_Del_Usage')
	drop procedure pro_Del_Usage
go
create procedure pro_Del_Usage
(
	@UsageCode varchar(50),
	@iresult int output
)
as
begin
	if exists(select UsageCode from Items where UsageCode=@UsageCode)
		set @iresult =-1
	else
	begin
		delete Usage where UsageCode=@UsageCode
		set @iresult =1
	end
end
go
------------------------------ table loai thuoc [ItemCategory]
if exists(select name from sysobjects where name like'%pro_Ins_ItemCategory%')
	drop procedure pro_Ins_ItemCategory
go
create procedure pro_Ins_ItemCategory
(
	@ItemCategoryCode varchar(50),
	@ItemCategoryName nvarchar(max),
	@GroupCode varchar(20)
)
as
begin
	if exists(select ItemCategoryCode from ItemCategory where ItemCategoryCode=@ItemCategoryCode)
		begin		
			update ItemCategory set ItemCategoryName=@ItemCategoryName,GroupCode=@GroupCode where ItemCategoryCode=@ItemCategoryCode
		end
	else
	begin
		declare @_ItemCategoryCode varchar(50)
		declare @_stt decimal(8,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(ItemCategoryCode,4)) maxcode from ItemCategory order by RowID desc)+1
		if(@_stt<=9)
			begin
				set @_ItemCategoryCode = 'LT000'+convert(varchar(6),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_ItemCategoryCode = 'LT00'+convert(varchar(6),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_ItemCategoryCode = 'LT0'+convert(varchar(6),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_ItemCategoryCode = 'LT'+convert(varchar(6),@_stt)
			end
		else
			begin
				set @_ItemCategoryCode = 'LT0001'
			end
		insert into ItemCategory(ItemCategoryCode,ItemCategoryName,GroupCode) values(@_ItemCategoryCode,@ItemCategoryName,@GroupCode)
	end
end
go
-- execute pro_Ins_ItemCategory '','Tesst test'
if exists(select name from sysobjects where name like'%pro_Del_ItemCategory%')
	drop procedure pro_Del_ItemCategory
go
create procedure pro_Del_ItemCategory
(
	@ItemCategoryCode varchar(50),
	@iresult int output
)
as
begin
	--if exists(select DepartmentCode from [Service] where DepartmentCode=@DepartmentCode)
	--	set @iresult =-1
	--else
	--begin
		delete ItemCategory where ItemCategoryCode=@ItemCategoryCode
		set @iresult =1
	--end
end
go
------------------------------ table nhom thuoc [ItemGroup]
if exists(select name from sysobjects where name ='pro_Ins_ItemGroup')
	drop procedure pro_Ins_ItemGroup
go
create procedure pro_Ins_ItemGroup
(
	@GroupCode varchar(50),
	@GroupName nvarchar(max),
	@ServiceModuleCode varchar(20),
	@GroupID_BHYT int
)
as
begin
	if exists(select GroupCode from ItemGroup where GroupCode=@GroupCode)
		begin		
			update ItemGroup set GroupName=@GroupName,ServiceModuleCode=@ServiceModuleCode,GroupID_BHYT=@GroupID_BHYT where GroupCode=@GroupCode
		end
	else
	begin
		declare @_Code varchar(50)
		declare @_stt decimal(8,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(GroupCode,4)) maxcode from ItemGroup order by RIGHT(GroupCode,4) desc)+1
		if(@_stt<=9)
			begin
				set @_Code = 'NT000'+convert(varchar(6),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_Code = 'NT00'+convert(varchar(6),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_Code = 'NT0'+convert(varchar(6),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_Code = 'NT'+convert(varchar(6),@_stt)
			end
		else
			begin
				set @_Code = 'NT0001'
			end
		insert into ItemGroup(GroupCode,GroupName,ServiceModuleCode,GroupID_BHYT) values(@_Code,@GroupName,@ServiceModuleCode,@GroupID_BHYT)
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_ItemGroup%')
	drop procedure pro_Del_ItemGroup
go
create procedure pro_Del_ItemGroup
(
	@GroupCode varchar(50),
	@iresult int output
)
as
begin
	if exists(select GroupCode from ItemCategory where GroupCode=@GroupCode)
		set @iresult =-1
	else
	begin
		delete from ItemGroup where GroupCode=@GroupCode
		set @iresult =1
	end
end
go
------------------------------ table cach dung [Instruction]
if exists(select name from sysobjects where name like'%pro_Ins_Instruction%')
	drop procedure pro_Ins_Instruction
go
create procedure pro_Ins_Instruction
(
	@RowID numeric(18,0),
	@InstructionName nvarchar(max)
)
as
begin
	if exists(select * from Instruction where RowID=@RowID)
		begin		
			update Instruction set InstructionName=@InstructionName where RowID=@RowID
		end
	else
	begin
		insert into Instruction(InstructionName) values(@InstructionName)
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_Instruction%')
	drop procedure pro_Del_Instruction
go
create procedure pro_Del_Instruction
(
	@RowID numeric(18,0),
	@iresult int output
)
as
begin
	--if exists(select DepartmentCode from [Service] where DepartmentCode=@DepartmentCode)
	--	set @iresult =-1
	--else
	--begin
		delete Instruction where RowID=@RowID
		set @iresult =1
	--end
end
go
------------------------------ table cach dung [Instruction]
if exists(select name from sysobjects where name like'%pro_Ins_UnitOfMeasure%')
	drop procedure pro_Ins_UnitOfMeasure
go
create procedure pro_Ins_UnitOfMeasure
(
	@UnitOfMeasureCode varchar(50),
	@UnitOfMeasureName nvarchar(max),
	@Type char(1)
)
as 
begin
	if exists(select UnitOfMeasureName from UnitOfMeasure where UnitOfMeasureCode=@UnitOfMeasureCode)
		begin		
			update UnitOfMeasure set UnitOfMeasureName=@UnitOfMeasureName where UnitOfMeasureCode=@UnitOfMeasureCode
		end
	else
	begin
	declare @_UnitOfMeasureCode varchar(50)
		declare @_stt decimal(8,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(UnitOfMeasureCode,4)) maxcode from UnitOfMeasure order by RowID desc)+1
		if(@_stt<=9)
			begin
				set @_UnitOfMeasureCode = 'DVT000'+convert(varchar(6),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_UnitOfMeasureCode = 'DVT00'+convert(varchar(6),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_UnitOfMeasureCode = 'DVT0'+convert(varchar(6),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_UnitOfMeasureCode = 'DVT'+convert(varchar(6),@_stt)
			end
		else
			begin
				set @_UnitOfMeasureCode = 'DVT0001'
			end
		insert into UnitOfMeasure(UnitOfMeasureCode,UnitOfMeasureName,[Type]) values(@_UnitOfMeasureCode,@UnitOfMeasureName,@Type)
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_UnitOfMeasure%')
	drop procedure pro_Del_UnitOfMeasure
go
create procedure pro_Del_UnitOfMeasure
(
	@UnitOfMeasureCode varchar(50),
	@iresult int output
)
as
begin
	if exists(select UnitOfMeasureCode from Items where UnitOfMeasureCode=@UnitOfMeasureCode)
		set @iresult =-1
	else if exists(select UnitOfMeasureCode from [Service] where UnitOfMeasureCode=@UnitOfMeasureCode)
		set @iresult =-1
	else
	begin
		delete UnitOfMeasure where UnitOfMeasureCode=@UnitOfMeasureCode
		set @iresult =1
	end
end
go
------------------------------ table danh muc kho [RepositoryCatalog]
if exists(select name from sysobjects where name like'%pro_Ins_RepositoryCatalog%')
	drop procedure pro_Ins_RepositoryCatalog
go
create procedure pro_Ins_RepositoryCatalog
(
	@RepositoryCode varchar(50),
	@RepositoryName nvarchar(max),
	@Hide int,
	@EmployeeCode varchar(50),
	@RepositoryGroupCode numeric(2,0),
	@DateReport datetime
)
as 
begin
	if exists(select RepositoryCode from RepositoryCatalog where RepositoryCode=@RepositoryCode)
		begin		
			update RepositoryCatalog set RepositoryName=@RepositoryName,Hide=@Hide,EmployeeCode=@EmployeeCode,RepositoryGroupCode=@RepositoryGroupCode,DateReport=@DateReport where RepositoryCode=@RepositoryCode
		end
	else
	begin
	declare @_RepositoryCode varchar(50)
		declare @_stt decimal(8,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(RepositoryCode,3)) maxcode from RepositoryCatalog order by RowID desc)+1
		if(@_stt<=9)
			begin
				set @_RepositoryCode = 'KHO00'+convert(varchar(5),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_RepositoryCode = 'KHO0'+convert(varchar(5),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_RepositoryCode = 'KHO'+convert(varchar(5),@_stt)
			end
		else
			begin
				set @_RepositoryCode = 'KHO001'
			end
		insert into RepositoryCatalog(RepositoryCode,RepositoryName,Hide,EmployeeCode,RepositoryGroupCode,DateReport) values(@_RepositoryCode,@RepositoryName,@Hide,@EmployeeCode,@RepositoryGroupCode,@DateReport)
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_RepositoryCatalog%')
	drop procedure pro_Del_RepositoryCatalog
go
create procedure pro_Del_RepositoryCatalog
(
	@RepositoryCode varchar(50),
	@iresult int output
)
as
begin
	if exists(select RepositoryCode from DepartmentForRepository where RepositoryCode=@RepositoryCode)
		set @iresult =-1
	else if exists(select RepositoryCode from InventoryGeneral where RepositoryCode=@RepositoryCode  and Hide = 0)
		set @iresult =-1
	else if exists(select RepositoryCode from InventoryGumshoe where RepositoryCode=@RepositoryCode)
		set @iresult =-1
	else
	begin
		delete RepositoryCatalog where RepositoryCode=@RepositoryCode
		set @iresult =1
	end
end
go
------------------------------ table danh muc thuoc Items [Items]
if exists(select name from sysobjects where name ='pro_Ins_Items' and type='P')
	drop procedure pro_Ins_Items
go
create procedure pro_Ins_Items
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
	@Converted_Medi bit=1
)
as
begin
	if exists(select ItemCode from Items where ItemCode=@ItemCode)
		begin		
			update Items set ItemName=@ItemName,Active=@Active,UsageCode=@UsageCode,UnitOfMeasureCode=@UnitOfMeasureCode,ItemCategoryCode=@ItemCategoryCode,UnitPrice=@UnitPrice,[Status]=@Status,SalesPrice=@SalesPrice,SafelyQuantity=@SafelyQuantity,RepositoryCode=@RepositoryCode,idate=GETDATE(),BHYTPrice=@BHYTPrice,ListBHYT=@ListBHYT,RateBHYT=@RateBHYT,CountryCode=@CountryCode,ProducerCode=@ProducerCode,Note=@Note,DisparityPrice=@DisparityPrice,ListService=@ListService,VendorCode=@VendorCode,Packed=@Packed,QtyOfMeasure=@QtyOfMeasure,ItemContent=@ItemContent,STTBCBHYT=@STTBCBHYT,SODKGP=@SODKGP,STTQDPK=@STTQDPK,QUYCACH=@QUYCACH,Generic_BD=@Generic_BD,VENCode=@VENCode,Active_TT40=@Active_TT40,SalesPrice_Retail=@SalesPrice_Retail,UnitOfMeasureCode_Medi=@UnitOfMeasureCode_Medi,Converted_Medi=@Converted_Medi where ItemCode=@ItemCode
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
		insert into Items(ItemCode,ItemName,Active,UsageCode,UnitOfMeasureCode,ItemCategoryCode,UnitPrice,Status,SalesPrice,SafelyQuantity,RepositoryCode,idate,udate,EmployeeCode,BHYTPrice,ListBHYT,RateBHYT,CountryCode,ProducerCode,Note,DisparityPrice,ListService,VendorCode,Packed,QtyOfMeasure,ItemContent,STTBCBHYT,SODKGP,STTQDPK,QUYCACH,Generic_BD,VENCode,Active_TT40,SalesPrice_Retail,UnitOfMeasureCode_Medi,Converted_Medi) values(@_ItemCode,@ItemName,@Active,@UsageCode,@UnitOfMeasureCode,@ItemCategoryCode,@UnitPrice,@Status,@SalesPrice,@SafelyQuantity,@RepositoryCode,GETDATE(),@udate,@EmployeeCode,@BHYTPrice,@ListBHYT,@RateBHYT,@CountryCode,@ProducerCode,@Note,@DisparityPrice,@ListService,@VendorCode,@Packed,@QtyOfMeasure,@ItemContent,@STTBCBHYT,@SODKGP,@STTQDPK,@QUYCACH,@Generic_BD,@VENCode,@Active_TT40,@SalesPrice_Retail,@UnitOfMeasureCode_Medi,@Converted_Medi)
	end
end
go
if exists(select name from sysobjects where name ='pro_Del_Items')
	drop procedure pro_Del_Items
go
create procedure pro_Del_Items
(
	@ItemCode varchar(50),
	@iresult int output
)
as
begin
	if exists(select ItemCode from InventoryGeneral where ItemCode=@ItemCode  and Hide = 0)
		set @iresult =-1
	else if exists(select ItemCode from InventoryGumshoe where ItemCode=@ItemCode)
		set @iresult =-1
	else
	begin
		delete Items where ItemCode=@ItemCode
		set @iresult =1
	end
end
go
------------------------------ table Phan quyen user [MenuSecurity]
if exists(select name from sysobjects where name like'%pro_Ins_MenuSecurity%')
	drop procedure pro_Ins_MenuSecurity
go
create procedure pro_Ins_MenuSecurity
(
	@MenuCode varchar(50),
	@MenuName nvarchar(max),
	@EmployeeCode varchar(50)
	
)
as
begin
	Declare @RowID numeric(18,0)
	select @RowID=ISNULL(MAX(RowID)+1,1) from MenuSecurity
	insert into MenuSecurity(RowID,MenuCode,MenuName,EmployeeCode,CreateDate) values(@RowID,@MenuCode,@MenuName,@EmployeeCode,GETDATE())
end
go
if exists(select name from sysobjects where name like'%pro_Del_MenuSecurity%')
	drop procedure pro_Del_MenuSecurity
go
create procedure pro_Del_MenuSecurity
(
	@EmployeeCode varchar(50),
	@iresult int output
)
as
begin
	delete from MenuSecurity where EmployeeCode=@EmployeeCode
	set @iresult =1
end
go
------------------------------ table Danh sach cac menu [MenuList]
if exists(select name from sysobjects where name like'%pro_Ins_MenuList%')
	drop procedure pro_Ins_MenuList
go
create procedure pro_Ins_MenuList
(
	@MenuCode varchar(50),
	@MenuName nvarchar(max)
)
as
begin
	declare @RowID numeric(18,0)
	if exists(select Menucode from MenuList where menucode=@MenuCode)
	begin
		update MenuList set Menuname=@MenuName where menucode=@MenuCode
	end
	else
	begin
		select @RowID=ISNULL(max(RowID)+1,1) from MenuList
		insert into MenuList(RowID,MenuCode,MenuName) values(@RowID,@MenuCode,@MenuName)
	end
end
go
--------------------------------- table trieu chung benh [Symptoms]
if exists(select name from sysobjects where name like'%pro_Ins_Symptoms%')
	drop procedure pro_Ins_Symptoms
go
create procedure pro_Ins_Symptoms
(
	@RowID numeric(18,0),
	@SymptomsName nvarchar(max)
)
as
begin
	if exists(select SymptomsName from Symptoms where RowID=@RowID)
	begin
		update Symptoms set SymptomsName=@SymptomsName where RowID=@RowID
	end
	else
	begin
		insert into Symptoms(SymptomsName) values(@SymptomsName)
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_Symptoms%')
	drop procedure pro_Del_Symptoms
go
create procedure pro_Del_Symptoms
(
	@RowID numeric(18,0),
	@iresult int output
)
as
begin
	delete from Symptoms where RowID=@RowID
	set @iresult =1
end
go
--------------------------------- table ma ICD-10 [Diagnosis]
if exists(select name from sysobjects where name like'%pro_Ins_Diagnosis%')
	drop procedure pro_Ins_Diagnosis
go
create procedure pro_Ins_Diagnosis
(
	@RowID numeric(18,0),
	@DiagnosisName nvarchar(max),
	@DiagnosisCode varchar(50)
)
as
begin
	if exists(select DiagnosisName from Diagnosis where RowID=@RowID)
	begin
		update Diagnosis set DiagnosisName=@DiagnosisName,DiagnosisCode=@DiagnosisCode where RowID=@RowID
	end
	else
	begin
		insert into Diagnosis(DiagnosisName,DiagnosisCode) values(@DiagnosisName,@DiagnosisCode)
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_Diagnosis%')
	drop procedure pro_Del_Diagnosis
go
create procedure pro_Del_Diagnosis
(
	@RowID numeric(18,0),
	@iresult int output
)
as
begin
	delete from Diagnosis where RowID=@RowID
	set @iresult =1
end
go
--------------------------------- table tien su benh [MedicalHistory]
if exists(select name from sysobjects where name like'%pro_Ins_MedicalHistory%')
	drop procedure pro_Ins_MedicalHistory
go
create procedure pro_Ins_MedicalHistory
(
	@RowID numeric(18,0),
	@MedicalHistoryName nvarchar(max),
	@MedicalHistoryContent nvarchar(max),
	@EmployeeCode varchar(50)
)
as
begin
	if exists(select MedicalHistoryName from MedicalHistory where RowID=@RowID)
	begin
		update MedicalHistory set MedicalHistoryName=@MedicalHistoryName,MedicalHistoryContent=@MedicalHistoryContent,EmployeeCode=@EmployeeCode where RowID=@RowID
	end
	else
	begin
		insert into MedicalHistory(MedicalHistoryName,MedicalHistoryContent,EmployeeCode) values(@MedicalHistoryName,@MedicalHistoryContent,@EmployeeCode)
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_MedicalHistory%')
	drop procedure pro_Del_MedicalHistory
go
create procedure pro_Del_MedicalHistory
(
	@RowID numeric(18,0),
	@iresult int output
)
as
begin
	delete from MedicalHistory where RowID=@RowID
	set @iresult =1
end
go
--------------------------------- table Loi dan [Advices]
if exists(select name from sysobjects where name like'%pro_Ins_Advices%')
	drop procedure pro_Ins_Advices
go
create procedure pro_Ins_Advices
(
	@RowID numeric(18,0),
	@AdvicesName nvarchar(max)
)
as
begin
	if exists(select AdvicesName from Advices where RowID=@RowID)
	begin
		update Advices set Advicesname=@AdvicesName where RowID=@RowID
	end
	else
	begin
		insert into Advices(AdvicesName) values(@AdvicesName)
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_Advices%')
	drop procedure pro_Del_Advices
go
create procedure pro_Del_Advices
(
	@RowID numeric(18,0),
	@iresult int output
)
as
begin
	delete from Advices where RowID=@RowID
	set @iresult =1
end
go
--------------------------------- table Noi dang ky KCB BD [KCBBD]
if exists(select name from sysobjects where name = 'pro_Ins_KCBBD')
	drop procedure pro_Ins_KCBBD
go
create procedure pro_Ins_KCBBD 
(
	@RowID numeric(18,0),
	@KCBBDCode varchar(50),
	@KCBBDName nvarchar(max),
	@ProvincialIDBHYT varchar(3),
	@TT int
)
as
begin
	if exists(select KCBBDName from KCBBD where RowID=@RowID)
	begin
		update KCBBD set KCBBDCode=@KCBBDCode,KCBBDName=@KCBBDName,ProvincialIDBHYT=@ProvincialIDBHYT,TT=@TT where RowID=@RowID
	end
	else
	begin
		insert into KCBBD(KCBBDCode,KCBBDName,ProvincialIDBHYT,TT) values(@KCBBDCode,@KCBBDName,@ProvincialIDBHYT,@TT)
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_KCBBD%')
	drop procedure pro_Del_KCBBD
go
create procedure pro_Del_KCBBD
(
	@RowID numeric(18,0),
	@iresult int output
)
as
begin
	delete from KCBBD where RowID=@RowID
	set @iresult =1
end
go
--------------------------------- table Benh nhan [Patients]
if exists(select name from sysobjects where name ='pro_GetPatientCode')
	drop procedure pro_GetPatientCode
go
create procedure pro_GetPatientCode
(
	@vresult varchar(50) output
)
as
begin
	declare @YY char(2)
	SELECT @YY=RIGHT(YEAR(GETDATE()), 2)
	declare @_Code varchar(50)
	declare @_stt decimal(8,0)
	set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(PatientCode,6)) maxcode from PatientsOrder order by RowID desc)+1
	if(@_stt<=9)
		begin
			set @_Code = @YY+'00000'+convert(varchar(6),@_stt)
		end
	else if(@_stt>9 and @_stt<=99)
		begin
			set @_Code = @YY+'0000'+convert(varchar(6),@_stt)
		end
	else if(@_stt>99 and @_stt<=999)
		begin
			set @_Code = @YY+'000'+convert(varchar(6),@_stt)
		end
	else if(@_stt>999 and @_stt<=9999)
		begin
			set @_Code = @YY+'00'+convert(varchar(6),@_stt)
		end
	else if(@_stt>9999 and @_stt<=99999)
		begin
			set @_Code = @YY+'0'+convert(varchar(6),@_stt)
		end
	else if(@_stt>99999 and @_stt<=999999)
		begin
			set @_Code = @YY+convert(varchar(6),@_stt)
		end
	else if(@_stt>999999)
		begin
			set @_Code = CONVERT(char(2),RIGHT(YEAR(GETDATE()), 2)+1)+'000001'
		end
	else
		begin
			set @_Code = @YY+'000001'
		end
	insert into PatientsOrder(PatientCode) values(@_Code)
	set @vresult =@_Code
end
go
if exists(select name from sysobjects where name ='pro_Ins_Patients' and type='P')
	drop procedure pro_Ins_Patients
go
create procedure pro_Ins_Patients 
(
	@PatientCode varchar(50),
	@PatientName nvarchar(250),
	@PatientGender int,
	@PatientBirthday datetime,
	@PatientBirthyear int,
	@PatientAge int,
	@PatientAddress nvarchar(max),
	@PatientMobile varchar(50),
	@PatientEmail varchar(100),
	@CodeArise varchar(50),
	@MedicalHistory nvarchar(max),
	@Allergy nvarchar(max),
	@PatientImage image,
	@EThnicID int=-1,
	@CareerCode varchar(10),
	@NationalityID int=-1,
	@ProvincialCode varchar(3),
	@DistrictCode varchar(5),
	@WardCode varchar(8),
	@IDTypeReceive int,
	@PatientMonth varchar(5),
	@TenCha nvarchar(250),
	@NSCha numeric(18,0) = 0,
	@TenMe nvarchar(250),
	@NSMe numeric(18,0) = 0
)
as
begin
	if exists(select PatientCode from Patients where PatientCode=@PatientCode)
	begin
		if DATALENGTH(@PatientImage)<=0 or @PatientImage is null
			update Patients set PatientName=@PatientName,PatientGender=@PatientGender,PatientBirthday=@PatientBirthday,PatientBirthyear=@PatientBirthyear,PatientAge=@PatientAge,PatientAddress=@PatientAddress,PatientMobile=@PatientMobile,PatientEmail=@PatientEmail,CodeArise=@CodeArise,MedicalHistory=@MedicalHistory,Allergy=@Allergy,EThnicID=@EThnicID,CareerCode=@CareerCode,NationalityID=@NationalityID,ProvincialCode=@ProvincialCode,DistrictCode=@DistrictCode,WardCode=@WardCode,IDTypeReceive=@IDTypeReceive,PatientMonth=@PatientMonth,TenCha=@TenCha,NSCha=@NSCha,TenMe=@TenMe,NSMe=@NSMe where PatientCode=@PatientCode
		else
			update Patients set PatientName=@PatientName,PatientGender=@PatientGender,PatientBirthday=@PatientBirthday,PatientBirthyear=@PatientBirthyear,PatientAge=@PatientAge,PatientAddress=@PatientAddress,PatientMobile=@PatientMobile,PatientEmail=@PatientEmail,CodeArise=@CodeArise,MedicalHistory=@MedicalHistory,Allergy=@Allergy,PatientImage=@PatientImage,EThnicID=@EThnicID,CareerCode=@CareerCode,NationalityID=@NationalityID,ProvincialCode=@ProvincialCode,DistrictCode=@DistrictCode,WardCode=@WardCode,IDTypeReceive=@IDTypeReceive,PatientMonth=@PatientMonth,TenCha=@TenCha,NSCha=@NSCha,TenMe=@TenMe,NSMe=@NSMe where PatientCode=@PatientCode
	end
	else
	begin
		insert into Patients(PatientCode,PatientName,PatientGender,PatientBirthday,PatientBirthyear,PatientAge,PatientAddress,PatientMobile,PatientEmail,CodeArise,MedicalHistory,Allergy,PatientImage,EThnicID,CareerCode,NationalityID,ProvincialCode,DistrictCode,WardCode,IDTypeReceive,PatientMonth,TenCha,NSCha,TenMe,NSMe) values(@PatientCode,@PatientName,@PatientGender,@PatientBirthday,@PatientBirthyear,@PatientAge,@PatientAddress,@PatientMobile,@PatientEmail,@CodeArise,@MedicalHistory,@Allergy,@PatientImage,@EThnicID,@CareerCode,@NationalityID,@ProvincialCode,@DistrictCode,@WardCode,@IDTypeReceive,@PatientMonth,@TenCha,@NSCha,@TenMe,@NSMe)
	end
end
go
if exists(select name from sysobjects where name ='pro_UpdPatients')
	drop procedure pro_UpdPatients
go
create procedure pro_UpdPatients
(
	@PatientCode varchar(50),
	@MedicalHistory nvarchar(max),
	@Allergy nvarchar(max)
)
as
begin
	update Patients set MedicalHistory=@MedicalHistory,Allergy=@Allergy where PatientCode=@PatientCode
end
go
--------------------------------- table BHYT
if exists(select name from sysobjects where name='pro_Ins_BHYT')
	drop procedure pro_Ins_BHYT
go
create procedure pro_Ins_BHYT
(
	@RowID numeric(18,0),
	@Serial varchar(50),
	@Serial01 varchar(5),
	@PatientCode varchar(50),
	@KCBBDCode varchar(50),
	@StartDate datetime,
	@EndDate datetime,
	@Hide int,
	@EmployeeCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@TraiTuyen int,
	@Serial02 varchar(5),
	@Serial03 varchar(5),
	@Serial04 varchar(5),
	@Serial05 varchar(5),
	@Serial06 varchar(5),
	@ReferralPaper int,
	@KCBBDCodeFull varchar(10),
	@Capcuu int
)
as
begin
	if exists(select PatientReceiveID from BHYT where PatientReceiveID=@PatientReceiveID)
		update BHYT set Serial=@Serial,Serial01=@Serial01,Serial02=@Serial02,Serial03=@Serial03,Serial04=@Serial04,Serial05=@Serial05,Serial06=@Serial06,KCBBDCode=@KCBBDCode,StartDate=@StartDate,EndDate=@EndDate,Hide=@Hide,TraiTuyen=@TraiTuyen,ReferralPaper=@ReferralPaper,KCBBDCodeFull=@KCBBDCodeFull,Capcuu=@Capcuu where PatientReceiveID=@PatientReceiveID
	else
	begin
		insert into BHYT(Serial,Serial01,Serial02,Serial03,Serial04,Serial05,Serial06,PatientCode,KCBBDCode,StartDate,EndDate,Hide,EmployeeCode,PatientReceiveID,TraiTuyen,ReferralPaper,KCBBDCodeFull,Capcuu) values(@Serial,@Serial01,@Serial02,@Serial03,@Serial04,@Serial05,@Serial06,@PatientCode,@KCBBDCode,@StartDate,@EndDate,@Hide,@EmployeeCode,@PatientReceiveID,@TraiTuyen,@ReferralPaper,@KCBBDCodeFull,@Capcuu)
	end
end
go
--------------------------------- table Dau sinh ton [SurviveSign]
if exists(select name from sysobjects where name like'%pro_Ins_SurviveSign%')
	drop procedure pro_Ins_SurviveSign
go
create procedure pro_Ins_SurviveSign
(
	@RowID numeric(18,0),
	@PatientCode varchar(50),
	@Pulse varchar(50),
	@Temperature varchar(50),
	@BloodPressure varchar(50),
	@Weight varchar(50),
	@EmployeeCode varchar(50),
	@RefID numeric(18,0),
	@ReferenceCode varchar(50),
	@BloodPressure1 varchar(50),
	@Hight varchar(50),
	@Breath varchar(50),
	@CreateDate datetime
)
as
begin
	if exists(select RowID from SurviveSign where RowID=@RowID)
	begin
		update SurviveSign set PatientCode=@PatientCode,Pulse=@Pulse,Temperature=@Temperature,BloodPressure=@BloodPressure,Weight=@Weight,EmployeeCode=@EmployeeCode,RefID=@RefID,ReferenceCode=@ReferenceCode,BloodPressure1=@BloodPressure1,Hight=@Hight,Breath=@Breath,CreateDate=@CreateDate where RowID=@RowID
	end
	else
	begin
		insert into SurviveSign(PatientCode,Pulse,Temperature,BloodPressure,Weight,EmployeeCode,RefID,ReferenceCode,BloodPressure1,Hight,Breath,CreateDate) values(@PatientCode,@Pulse,@Temperature,@BloodPressure,@Weight,@EmployeeCode,@RefID,@ReferenceCode,@BloodPressure1,@Hight,@Breath,@CreateDate)
	end
end
go
--execute pro_Ins_SurviveSign 0,'BN','01','01','01','01','NV00001'
--------------------------------- table tiep don [PatientReceive]

if exists(select name from sysobjects where name ='pro_Del_PatientReceive')
	drop procedure pro_Del_PatientReceive
go
create procedure pro_Del_PatientReceive
(
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(50),
	@iresult int output
)
as
begin
	if exists(select PatientCode from ServiceLaboratoryEntry where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode)
	begin
		set @iresult = -1 -- benh nhan da lam xet nghiem
	end
	else if exists(select PatientCode from ServiceRadiologyEntry where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode)
	begin
		set @iresult = -2 -- benh nhan da lam cls
	end
	else if exists(select PatientCode from MedicalRecord where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode)
	begin
		set @iresult = -3 -- benh nhan da kham benh
	end
	else if exists(select PatientCode from BanksAccount where RateExemptions=@PatientReceiveID and PatientCode=@PatientCode and Cancel=0)
	begin
		set @iresult = -4 -- benh nhan da phat sinh thu kham benh
	end
	else if exists(select PatientCode from Surgeries where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode)
	begin
		set @iresult = -5 -- benh nhan da lam thu thuat
	end
	else
		begin
			delete from SuggestedServiceReceipt where RefID=@PatientReceiveID and PatientCode=@PatientCode and status=0 and paid=0
			delete from PatientReceive where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode
			set @iresult = 1
		end
end
go
------------------------------- Table chi dinh dinh dich vu [SuggestedServiceReceipt]
if exists(select name from sysobjects where name = 'pro_Ins_SuggestedServiceReceipt')
 drop procedure pro_Ins_SuggestedServiceReceipt
go
create procedure pro_Ins_SuggestedServiceReceipt
(
	@ReceiptID numeric(18,0),
	@DepartmentCode varchar(50),
	@ServiceCode varchar(50),
	@ServicePrice numeric(18,0),
	@DisparityPrice numeric(18,0),
	@PatientCode varchar(50),
	@Status int,
	@Paid int,
	@ServicePackageCode varchar(50),
	@EmployeeCode varchar(50),
	@Note nvarchar(50),
	@RefID numeric(18,0),
	@ObjectCode int,
	@PatientType int,
	@WorkDate DateTime,
	@ReferenceCode varchar(50),
	@DepartmentCodeOrder varchar(50),
	@EmployeeCodeDoctor varchar(50),
	@ShiftWork char(2),
	@StatusDepartment int =0,
	@Quantity int =1,
	@IDAppointment247 nvarchar(50)='',
	@IDDoctorAppointment247 nvarchar(50)='',
	@NameDoctorAppointment247 nvarchar(100)='',
	@Content nvarchar(200)='',
	@Check_ int=0
)
as
begin
	declare @SampleTransfer int =0
	declare @SampleTransferPrice decimal(18,2)=0
	declare @RowIDPrice numeric(18,0)
	declare @STT int =1
	set @SampleTransfer = (select SampleTransfer from [Service] where ServiceCode=@ServiceCode)
	declare @DiscountIntro numeric(18,2)=0
	declare @DiscountDoctorDone numeric(18,2)=0
	declare @DiscountDoctor numeric(18,2)=0
	declare @IntroName nvarchar(200)=''
	select @IntroName=IntroName from PatientReceive where PatientReceiveID=@RefID
	if exists(select ServiceCode,SampleTransfer=@SampleTransfer from [Service] where ServiceCode=@ServiceCode and ServiceGroupCode='KCB')
		set @Note='TIEPDON'
	else
		set @Note=''
	--declare @DepartmentDone varchar(250)
	if exists(select ReceiptID from SuggestedServiceReceipt where ReceiptID=@ReceiptID)
	begin
		declare cur cursor read_only fast_forward
		for select RowID,UnitPrice,DisparityPrice,SampleTransferPrice,DiscountIntro,DiscountDoctorDone,DiscountDoctor from ServicePrice where Hide=0 and ServiceCode=@ServiceCode and ObjectCode=@ObjectCode
		open cur
		fetch next from cur into @RowIDPrice,@ServicePrice, @DisparityPrice,@SampleTransferPrice,@DiscountIntro,@DiscountDoctorDone,@DiscountDoctor
		while @@FETCH_STATUS = 0
		begin
			if exists(select MedicalRecordCode from MedicalRecord where ReceiptID=@ReceiptID and EmployeeCodeDoctor=@EmployeeCodeDoctor)
				begin
					if exists (select ReceiptID_DisparityPrice from SuggestedServiceReceipt where ReceiptID_DisparityPrice=@ReceiptID)
					begin
						update SuggestedServiceReceipt set DepartmentCode=@DepartmentCode,ServiceCode=@ServiceCode,ServicePrice=0,DisparityPrice=@DisparityPrice,PatientCode=@PatientCode,CreateDate=GETDATE(),ServicePackageCode=@ServicePackageCode,EmployeeCode=@EmployeeCode,Note=@Note,RefID=@RefID,ObjectCode=@ObjectCode,RowIDPrice=@RowIDPrice,WorkDate=@WorkDate,ReferenceCode=@ReferenceCode,@DepartmentCodeOrder=@DepartmentCodeOrder,EmployeeCodeDoctor=@EmployeeCodeDoctor,SampleTransfer=@SampleTransfer,SampleTransferPrice=@SampleTransferPrice,Quantity=@Quantity,IDAppointment247 =@IDAppointment247, IDDoctorAppointment247 = @IDDoctorAppointment247, NameDoctorAppointment247 = @NameDoctorAppointment247,DiscountIntro=@DiscountIntro,DiscountDoctorDone=@DiscountDoctorDone,DiscountDoctor=@DiscountDoctor,IntroName=@IntroName,Content=@Content where ReceiptID_DisparityPrice=@ReceiptID and Paid=0
						set @DisparityPrice=0
					end
					update SuggestedServiceReceipt set DepartmentCode=@DepartmentCode,ServiceCode=@ServiceCode,ServicePrice=@ServicePrice,DisparityPrice=@DisparityPrice,PatientCode=@PatientCode,CreateDate=GETDATE(),ServicePackageCode=@ServicePackageCode,EmployeeCode=@EmployeeCode,Note=@Note,RefID=@RefID,ObjectCode=@ObjectCode,RowIDPrice=@RowIDPrice,WorkDate=@WorkDate,ReferenceCode=@ReferenceCode,@DepartmentCodeOrder=@DepartmentCodeOrder,EmployeeCodeDoctor=@EmployeeCodeDoctor,SampleTransfer=@SampleTransfer,SampleTransferPrice=@SampleTransferPrice,Quantity=@Quantity,IDAppointment247 =@IDAppointment247, IDDoctorAppointment247 = @IDDoctorAppointment247, NameDoctorAppointment247 = @NameDoctorAppointment247,DiscountIntro=@DiscountIntro,DiscountDoctorDone=@DiscountDoctorDone,DiscountDoctor=@DiscountDoctor,IntroName=@IntroName,Content=@Content,Check_=@Check_ where ReceiptID=@ReceiptID and Paid=0
				end
			else
				begin
					if exists (select ReceiptID_DisparityPrice from SuggestedServiceReceipt where ReceiptID_DisparityPrice=@ReceiptID)
					begin
						update SuggestedServiceReceipt set DepartmentCode=@DepartmentCode,ServiceCode=@ServiceCode,ServicePrice=0,DisparityPrice=@DisparityPrice,PatientCode=@PatientCode,CreateDate=GETDATE(),ServicePackageCode=@ServicePackageCode,EmployeeCode=@EmployeeCode,Note=@Note,RefID=@RefID,ObjectCode=@ObjectCode,RowIDPrice=@RowIDPrice,WorkDate=@WorkDate,ReferenceCode=@ReferenceCode,@DepartmentCodeOrder=@DepartmentCodeOrder,EmployeeCodeDoctor=@EmployeeCodeDoctor,SampleTransfer=@SampleTransfer,SampleTransferPrice=@SampleTransferPrice,Quantity=@Quantity,IDAppointment247 =@IDAppointment247, IDDoctorAppointment247 = @IDDoctorAppointment247, NameDoctorAppointment247 = @NameDoctorAppointment247,DiscountIntro=@DiscountIntro,DiscountDoctorDone=@DiscountDoctorDone,DiscountDoctor=@DiscountDoctor,IntroName=@IntroName,Content=@Content where ReceiptID_DisparityPrice=@ReceiptID and Status=0
						set @DisparityPrice=0
					end
					update SuggestedServiceReceipt set DepartmentCode=@DepartmentCode,ServiceCode=@ServiceCode,ServicePrice=@ServicePrice,DisparityPrice=@DisparityPrice,PatientCode=@PatientCode,CreateDate=GETDATE(),ServicePackageCode=@ServicePackageCode,EmployeeCode=@EmployeeCode,Note=@Note,RefID=@RefID,ObjectCode=@ObjectCode,RowIDPrice=@RowIDPrice,WorkDate=@WorkDate,ReferenceCode=@ReferenceCode,@DepartmentCodeOrder=@DepartmentCodeOrder,EmployeeCodeDoctor=@EmployeeCodeDoctor,SampleTransfer=@SampleTransfer,SampleTransferPrice=@SampleTransferPrice,Quantity=@Quantity,IDAppointment247 =@IDAppointment247, IDDoctorAppointment247 = @IDDoctorAppointment247, NameDoctorAppointment247 = @NameDoctorAppointment247,DiscountIntro=@DiscountIntro,DiscountDoctorDone=@DiscountDoctorDone,DiscountDoctor=@DiscountDoctor,IntroName=@IntroName,Content=@Content,Check_=@Check_ where ReceiptID=@ReceiptID and Status=0-- and Paid=0
				end
			FETCH NEXT FROM cur into @RowIDPrice,@ServicePrice, @DisparityPrice,@SampleTransferPrice,@DiscountIntro,@DiscountDoctorDone,@DiscountDoctor
		end	 
		CLOSE cur
		DEALLOCATE cur
	end
	else
	begin
		if @StatusDepartment=0
		begin
			declare cur cursor read_only fast_forward
			for select RowID,UnitPrice,DisparityPrice,SampleTransferPrice,DiscountIntro,DiscountDoctorDone,DiscountDoctor from ServicePrice where Hide=0 and ServiceCode=@ServiceCode and ObjectCode=@ObjectCode
			open cur
			fetch next from cur into @RowIDPrice,@ServicePrice, @DisparityPrice,@SampleTransferPrice,@DiscountIntro,@DiscountDoctorDone,@DiscountDoctor
			while @@FETCH_STATUS = 0
			begin
				set @STT = (select isnull(max(STT),0)+1 from SuggestedServiceReceipt where CONVERT(date,CreateDate,103)=CONVERT(date,GETDATE(),103) and DepartmentCode=@DepartmentCode)
				insert into SuggestedServiceReceipt(DepartmentCode,ServiceCode,ServicePrice,DisparityPrice,PatientCode,[Status],Paid,CreateDate,ServicePackageCode,EmployeeCode,Note,RefID,ObjectCode,RowIDPrice,PatientType,WorkDate,ReferenceCode,STT,DepartmentCodeOrder,EmployeeCodeDoctor,ShiftWork,SampleTransfer,SampleTransferPrice,Quantity,PaidBV,IDAppointment247,IDDoctorAppointment247,NameDoctorAppointment247,DiscountIntro,DiscountDoctorDone,DiscountDoctor,IntroName,Content,Check_) values(@DepartmentCode,@ServiceCode,@ServicePrice,@DisparityPrice,@PatientCode,@Status,@Paid,GETDATE(),@ServicePackageCode,@EmployeeCode,@Note,@RefID,@ObjectCode,@RowIDPrice,@PatientType,@WorkDate,@ReferenceCode,@STT,@DepartmentCodeOrder,@EmployeeCodeDoctor,@ShiftWork,@SampleTransfer,@SampleTransferPrice,@Quantity,0,@IDAppointment247,@IDDoctorAppointment247,@NameDoctorAppointment247,@DiscountIntro,@DiscountDoctorDone,@DiscountDoctor,@IntroName,@Content,@Check_)
				set @ReceiptID = (select isnull(ReceiptID,0) ReceiptID from SuggestedServiceReceipt where DepartmentCode=@DepartmentCode and ServiceCode=@ServiceCode and ServicePrice=@ServicePrice and DisparityPrice=@DisparityPrice and PatientCode=@PatientCode and Status=@Status and Paid=@Paid and ServicePackageCode=@ServicePackageCode and EmployeeCode=@EmployeeCode and Note=@Note and RefID=@RefID and ObjectCode=@ObjectCode and RowIDPrice=@RowIDPrice and PatientType=@PatientType and WorkDate=@WorkDate and ReferenceCode=@ReferenceCode and STT=@STT and DepartmentCodeOrder=@DepartmentCodeOrder and EmployeeCodeDoctor=@EmployeeCodeDoctor and ShiftWork=@ShiftWork and SampleTransfer=@SampleTransfer)
				if(@ReceiptID>0 and @DisparityPrice >0)
				begin
					insert into SuggestedServiceReceipt(DepartmentCode,ServiceCode,ServicePrice,DisparityPrice,PatientCode,[Status],Paid,CreateDate,ServicePackageCode,EmployeeCode,Note,RefID,ObjectCode,RowIDPrice,PatientType,WorkDate,ReferenceCode,STT,DepartmentCodeOrder,EmployeeCodeDoctor,ShiftWork,SampleTransfer,SampleTransferPrice,Quantity,PaidBV,IDAppointment247,IDDoctorAppointment247,NameDoctorAppointment247,DiscountIntro,DiscountDoctorDone,DiscountDoctor,IntroName,Content,ReceiptID_DisparityPrice) values(@DepartmentCode,@ServiceCode,0,@DisparityPrice,@PatientCode,@Status,@Paid,GETDATE(),@ServicePackageCode,@EmployeeCode,@Note,@RefID,@ObjectCode,@RowIDPrice,@PatientType,@WorkDate,@ReferenceCode,@STT,@DepartmentCodeOrder,@EmployeeCodeDoctor,@ShiftWork,@SampleTransfer,@SampleTransferPrice,@Quantity,0,@IDAppointment247,@IDDoctorAppointment247,@NameDoctorAppointment247,@DiscountIntro,@DiscountDoctorDone,@DiscountDoctor,@IntroName,@Content,@ReceiptID)	
					update SuggestedServiceReceipt set DisparityPrice=0 where ReceiptID=@ReceiptID
				end
				FETCH NEXT FROM cur into @RowIDPrice,@ServicePrice, @DisparityPrice,@SampleTransferPrice,@DiscountIntro,@DiscountDoctorDone,@DiscountDoctor
			end	 
			CLOSE cur
			DEALLOCATE cur
		end
		else
		begin
			set @RowIDPrice =-1 set @ServicePrice =0 set @DisparityPrice =0
			set @STT = ( select isnull(max(STT),0)+1 from SuggestedServiceReceipt where CONVERT(date,CreateDate,103)=CONVERT(date,GETDATE(),103) and DepartmentCode=@DepartmentCode)
			insert into SuggestedServiceReceipt(DepartmentCode,ServiceCode,ServicePrice,DisparityPrice,PatientCode,[Status],Paid,CreateDate,ServicePackageCode,EmployeeCode,Note,RefID,ObjectCode,RowIDPrice,PatientType,WorkDate,ReferenceCode,STT,DepartmentCodeOrder,EmployeeCodeDoctor,ShiftWork,SampleTransfer,SampleTransferPrice,Quantity,PaidBV,IDAppointment247,IDDoctorAppointment247,NameDoctorAppointment247,DiscountIntro,DiscountDoctorDone,DiscountDoctor,IntroName,Content,Check_) values(@DepartmentCode,@ServiceCode,@ServicePrice,@DisparityPrice,@PatientCode,@Status,@Paid,GETDATE(),@ServicePackageCode,@EmployeeCode,@Note,@RefID,@ObjectCode,@RowIDPrice,@PatientType,@WorkDate,@ReferenceCode,@STT,@DepartmentCodeOrder,@EmployeeCodeDoctor,@ShiftWork,@SampleTransfer,@SampleTransferPrice,@Quantity,0,@IDAppointment247,@IDDoctorAppointment247,@NameDoctorAppointment247,@DiscountIntro,@DiscountDoctorDone,@DiscountDoctor,@IntroName,@Content,@Check_)
		end
	end
end
go
if exists(select name from sysobjects where name = 'proIns_SuggestedReceive')
 drop procedure proIns_SuggestedReceive
go
create procedure proIns_SuggestedReceive
(
	@ReceiptID numeric(18,0),
	@DepartmentCode varchar(50),
	@ServiceCode varchar(50),
	@ServicePrice numeric(18,0),
	@DisparityPrice numeric(18,0),
	@PatientCode varchar(50),
	@Status int,
	@Paid int,
	@ServicePackageCode varchar(50),
	@EmployeeCode varchar(50),
	@Note nvarchar(50),
	@RefID numeric(18,0),
	@ObjectCode int,
	@PatientType int,
	@WorkDate DateTime,
	@ReferenceCode varchar(50),
	@DepartmentCodeOrder varchar(50),
	@ShiftWork char(2),
	@Quantity int =1,
	@IDAppointment247 nvarchar(50),
	@IDDoctorAppointment247 nvarchar(50),
	@NameDoctorAppointment247 nvarchar(100)
)
as
begin tran
	declare @RowIDPrice numeric(18,0)=-1
	declare @STT int =-1
	declare @IntroName nvarchar(200)= (select IntroName from PatientReceive where PatientReceiveID=@RefID)
	if not exists(select ServiceCode from SuggestedServiceReceipt where RefID=@RefID and ServiceCode=@ServiceCode)
		insert into SuggestedServiceReceipt(DepartmentCode,ServiceCode,ServicePrice,DisparityPrice,PatientCode,[Status],Paid,CreateDate,ServicePackageCode,EmployeeCode,Note,RefID,ObjectCode,RowIDPrice,PatientType,WorkDate,ReferenceCode,STT,DepartmentCodeOrder,ShiftWork,Quantity,PaidBV,IDAppointment247,IDDoctorAppointment247,NameDoctorAppointment247,IntroName) values(@DepartmentCode,@ServiceCode,@ServicePrice,@DisparityPrice,@PatientCode,@Status,@Paid,GETDATE(),@ServicePackageCode,@EmployeeCode,@Note,@RefID,@ObjectCode,@RowIDPrice,@PatientType,@WorkDate,@ReferenceCode,@STT,@DepartmentCodeOrder,@ShiftWork,@Quantity,0,@IDAppointment247,@IDDoctorAppointment247,@NameDoctorAppointment247,@IntroName)
commit tran
go
if exists(select name from sysobjects where name ='pro_Del_SuggestedServiceReceipt')
	drop procedure pro_Del_SuggestedServiceReceipt
go
create procedure pro_Del_SuggestedServiceReceipt
(
	@ReceiptID numeric(18,0),
	@iresult int output
)
as
begin
	if @ReceiptID=-1
	begin
		set @iresult=0
	end
	else if exists(select [Status] from SuggestedServiceReceipt where ReceiptID=@ReceiptID and [Status] in(1,2))
	begin
		set @iresult=-1
	end
	else if exists(select Paid from SuggestedServiceReceipt where ReceiptID=@ReceiptID and Paid in(1))
	begin
		set @iresult=-2
	end
	else if exists(select a.Status from MedicalPrescriptionDetail a inner join MedicalRecord b on a.MedicalRecordCode=b.MedicalRecordCode where b.ReceiptID=@ReceiptID and a.Status=1)
	begin
		set @iresult=-3
	end
	else
	begin
		delete from MedicalPrescriptionDetail where MedicalRecordCode =(select b.MedicalRecordCode from MedicalPrescriptionDetail a inner join MedicalRecord b on a.MedicalRecordCode=b.MedicalRecordCode where b.ReceiptID=@ReceiptID and a.Status=1)
		delete from MedicalRecord where ReceiptID=@ReceiptID and Status=0
		delete from SuggestedServiceReceipt where ReceiptID=@ReceiptID
		set @iresult=1
	end
end
go
------------------------------------ table thu tien
if exists(select name from sysobjects where name ='pro_Ins_BanksAccount')
	drop procedure pro_Ins_BanksAccount
go
create procedure pro_Ins_BanksAccount
(
	@BanksAccountCode varchar(50),
	@ReferenceCode Numeric(18,0),
	@BHYTPay numeric(18,2),
	@PatientPay numeric(18,2),
	@Exemptions numeric(18,2),
	@TotalAmount numeric(18,2),
	@Description nvarchar(max),
	@EmployeeCode varchar(50),
	@PatientCode varchar(50),
	@Cancel int,
	@PatientType int,
	@ObjectCode int,
	@TotalReal decimal(18,2),
	@RateExemptions decimal(18,4),
	@RateSurcharge decimal(18,4),
	@TotalSurcharge decimal(18,4),
	@IntroCode varchar(10),
	@Serial int,
	@CashierCode varchar(50),
	@ShiftWork char(2),
	@TotalBHYTPay decimal(18,2),
	@TotalPatientPay decimal(18,2)
)
as
begin tran
	if @Serial=0
		set @Serial=(select isnull(MAX(serial),0)+1 from BanksAccount where CONVERT(date,PostingDate,103)=CONVERT(date,GETDATE(),103))
	if not exists(select BanksAccountCode from BanksAccount where BanksAccountCode=@BanksAccountCode)
	begin
		--declare @_BanksAccountCode varchar(50)=''
		--declare @_stt decimal(18,0)=0
		--set @_stt = (select top(1) isnull( CONVERT(decimal(16,0),RIGHT(BanksAccountCode,10)),0) maxcode from BanksAccount order by RowID desc)+1
		--set @_BanksAccountCode = @BanksAccountCode
		insert into BanksAccount(BanksAccountCode,ReferenceCode,BHYTPay,PatientPay,Exemptions,TotalAmount,[Description],PostingDate,EmployeeCode,PatientCode,Cancel,PatientType,ObjectCode,TotalReal,RateExemptions,RateSurcharge,TotalSurcharge,IntroCode,Serial,CashierCode,ShiftWork,TotalBHYTPay,TotalPatientPay) values (@BanksAccountCode,@ReferenceCode,@BHYTPay,@PatientPay,@Exemptions,@TotalAmount,@Description,Getdate(),@EmployeeCode,@PatientCode,@Cancel,@PatientType,@ObjectCode,@TotalReal,@RateExemptions,@RateSurcharge,@TotalSurcharge,@IntroCode,@Serial,@CashierCode,@ShiftWork,@TotalBHYTPay,@TotalPatientPay)
		declare @Invoice_HoTenKH nvarchar(250)= (select PatientName from Patients where PatientCode=@PatientCode)
		declare @Invoice_DiaChi nvarchar(300)= (select [dbo].func_PatientOfAddress(@ReferenceCode))
		declare @Invoice_DienThoai nvarchar(50)= (select PatientMobile from Patients where PatientCode=@PatientCode)
		update BanksAccount set Invoice_HoTenKH=@Invoice_HoTenKH,Invoice_DiaChi=@Invoice_DiaChi,Invoice_DienThoai=@Invoice_DienThoai,Invoice_HTThanhToan='TM' where BanksAccountCode=@BanksAccountCode
	end
commit
go
if exists(select name from sysobjects where name ='pro_Ins_BanksAccountDetail')
	drop procedure pro_Ins_BanksAccountDetail
go
create procedure pro_Ins_BanksAccountDetail
(
	@BanksAccountCode varchar(50),
	@EmployeeCode varchar(50),
	@ReceiptID numeric(18,0),
	@STT int,
	@Type int,
	@BHYTPay numeric(18,2),
	@PatientPay numeric(18,2),
	@ServicePriceSalesOff decimal(18,2),
	@Quantity int
)
as
begin tran
	declare @ServiceCode varchar(50)
	declare @ServicePrice numeric(18,2)
	declare @DisparityPrice numeric(18,2)
	declare @ObjectCode int
	declare @RowIDPrice numeric(18,0)
	if exists(select BanksAccountCode from BanksAccount where BanksAccountCode=@BanksAccountCode)
		begin
			declare cur1 cursor read_only fast_forward
			for select ReceiptID,ServiceCode,ServicePrice,DisparityPrice,ObjectCode,RowIDPrice from SuggestedServiceReceipt where ReceiptID=@ReceiptID
			open cur1
			fetch next from cur1 into @ReceiptID,@ServiceCode,@ServicePrice,@DisparityPrice,@ObjectCode,@RowIDPrice
			while @@FETCH_STATUS = 0
			begin
				insert into BanksAccountDetail(BanksAccountCode,ServiceCode,ServicePrice,DisparityPrice,STT,ObjectCode,PostingDate,EmployeeCode,RowIDPrice,ReceiptID,Type,Quantity,BHYTPay, PatientPAY,ServicePriceSalesOff) values(@BanksAccountCode,@ServiceCode,@ServicePrice,@DisparityPrice,@STT,@ObjectCode,GETDATE(),@EmployeeCode,@RowIDPrice,@ReceiptID,@Type,@Quantity,@BHYTPay, @PatientPAY,@ServicePriceSalesOff)
				update SuggestedServiceReceipt set Paid=1,BanksAccountCode=@BanksAccountCode where ReceiptID=@ReceiptID
				FETCH NEXT FROM cur1 into @ReceiptID,@ServiceCode,@ServicePrice,@DisparityPrice,@ObjectCode,@RowIDPrice
			end	 
			CLOSE cur1
			DEALLOCATE cur1
		end
commit tran
go
if exists(select name from sysobjects where name ='pro_Ins_BanksAccountDetail_01')
	drop procedure pro_Ins_BanksAccountDetail_01
go
create procedure pro_Ins_BanksAccountDetail_01
(
	@BanksAccountCode varchar(50),
	@ServiceCode varchar(50),
	@ServicePrice numeric(18,2),
	@DisparityPrice numeric(18,2),
	@STT int,
	@ObjectCode int,
	@EmployeeCode varchar(50),
	@RowIDPrice numeric(18,0),
	@ReceiptID numeric(18,0),
	@Type int,
	@Quantity numeric(18,2),
	@RowIDDetail numeric(18,0),
	@MedicinesType int,
	@MedicalRecordCode varchar(50),
	@RowIDMedicines numeric(18,0),
	@BHYTPay numeric(18,2),
	@PatientPay numeric(18,2),
	@ServicePriceSalesOff numeric(18,2)
)
as
begin tran
	if exists(select BanksAccountCode from BanksAccount where BanksAccountCode=@BanksAccountCode)
		begin
			insert into BanksAccountDetail(BanksAccountCode,ServiceCode,ServicePrice,DisparityPrice,STT,ObjectCode,PostingDate,EmployeeCode,RowIDPrice,ReceiptID,Type,Quantity,BHYTPay,PatientPay,ServicePriceSalesOff) values(@BanksAccountCode,@ServiceCode,@ServicePrice,@DisparityPrice,@STT,@ObjectCode,GETDATE(),@EmployeeCode,@RowIDPrice,@ReceiptID,@Type,@Quantity,@BHYTPay,@PatientPay,@ServicePriceSalesOff)
			if(@MedicinesType=1)
				update MedicinesForPatientsDetail set Paid=1,BanksAccountCode=@BanksAccountCode where MedicalRecordCode=@MedicalRecordCode and RowIDMedicines=@RowIDMedicines and RowID=@RowIDDetail and ItemCode=@ServiceCode
			else if(@MedicinesType=2)
			begin
				update RealMedicinesForPatientsDetail set Paid=1,BanksAccountCode=@BanksAccountCode where RealRowID=@RowIDMedicines and RowID=@RowIDDetail and ItemCode=@ServiceCode
				declare @CountRows int = (select count(*) from RealMedicinesForPatientsDetail where RealRowID=@RowIDMedicines and Paid=0 and (BanksAccountCode is null or BanksAccountCode=''))
				if @CountRows<=0
				 update RealMedicinesForPatients set BanksAccountCode=@BanksAccountCode where RowID=@RowIDMedicines 
			end
		end
commit tran
go
if exists(select name from sysobjects where name ='pro_Del_BanksAccount')
	drop procedure pro_Del_BanksAccount
go
create procedure pro_Del_BanksAccount
(
	@BanksAccountCode varchar(50),
	@PatientCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@ShiftWork char(2),
	@EmployeeCodeCancel varchar(20),
	@ReasonCancel nvarchar(250)
)
as
begin
	if exists(select BanksAccountCode from BanksAccount where BanksAccountCode=@BanksAccountCode and Cancel=0)
		begin
			update SuggestedServiceReceipt set Paid=0,BanksAccountCode='' where BanksAccountCode=@BanksAccountCode and PatientCode=@PatientCode and RefID=@PatientReceiveID
			update MedicalRecord set Paid=0,BanksAccountCode='' where BanksAccountCode=@BanksAccountCode and PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID
			update BanksAccount set Cancel=1,ShiftWork=@ShiftWork,EmployeeCodeCancel=@EmployeeCodeCancel,CancelDate=GETDATE(),ReasonCancel=@ReasonCancel where BanksAccountCode=@BanksAccountCode and ReferenceCode=@PatientReceiveID and PatientCode=@PatientCode
			update RealMedicinesForPatients set BanksAccountCode=null where BanksAccountCode=@BanksAccountCode and PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID
			--update MedicinesRetail set BanksAccountCode=null,Paid=1 where BanksAccountCode=@BanksAccountCode and PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID
			update RealMedicinesForPatientsDetail set BanksAccountCode=null,Paid=0 where BanksAccountCode=@BanksAccountCode
			update MedicinesForPatientsDetail set BanksAccountCode=null,Paid=0 where BanksAccountCode=@BanksAccountCode
			if exists(select status from PatientReceive where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode and Status=2)
				update PatientReceive set Status=1 where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode
		end
end
go
--if exists(select name from sysobjects where name like'%proDel_ReportBHYT%')
--	drop procedure proDel_ReportBHYT
--go
--create procedure proDel_ReportBHYT
--(
--	@PatientCode varchar(50),
--	@PatientReceiveID numeric(18,0),
--	@EmployeeCodeCancel varchar(20)
--)
--as
--begin
--	if exists(select PatientReceiveID from ReportBHYT where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode and Cancel=0)
--		begin
--			update ReportBHYT set Cancel=1,EmployeeCodeCancel=@EmployeeCodeCancel,CancelDate=GETDATE() where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode
--			update PatientReceive set ConfirmBV01=0 where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode
--		end
--end
--go
--------------------------------- table RateBHYT
if exists(select name from sysobjects where name like'%pro_Ins_RateBHYT%')
	drop procedure pro_Ins_RateBHYT
go
create procedure pro_Ins_RateBHYT
(
	@RateCard varchar(50),
	@RateTrue int,
	@RateFalse int
)
as
begin
	if exists(select * from RateBHYT where RateCard=@RateCard)
	begin
		update RateBHYT set RateTrue=@RateTrue,RateFalse=@RateFalse  where RateCard=@RateCard
	end
	else
	begin
		insert into RateBHYT(RateCard,RateTrue,RateFalse) values(@RateCard,@RateTrue,@RateFalse)
	end
end
go
--------------------------------- table BHYTParameters
if exists(select name from sysobjects where name like'%pro_Ins_BHYTParameters%')
	drop procedure pro_Ins_BHYTParameters
go
create procedure pro_Ins_BHYTParameters
(
	@RowID int,
	@BHYTUnderPrice numeric(18,2),
	@BHYTOnPrice numeric(18,2)
)
as
begin
	if exists(select RowID from BHYTParameters where RowID=@RowID)
	begin
		update BHYTParameters set BHYTUnderPrice=@BHYTUnderPrice,BHYTOnPrice=@BHYTOnPrice  where RowID=@RowID
	end
end
go
------------------ Table SamplePrescriptionHeader
if exists(select name from sysobjects where name like'%pro_Ins_SampleHeader%')
	drop procedure pro_Ins_SampleHeader
go
create procedure pro_Ins_SampleHeader
(
	@SamplePrescriptionCode varchar(50),
	@SamplePrescriptionName nvarchar(max),
	@SamplePrescriptionDescription nvarchar(max),
	@EmployeeCode varchar(50)
)
as
begin
	if exists(select SamplePrescriptionCode from SamplePrescriptionHeader where SamplePrescriptionCode=@SamplePrescriptionCode)
		begin		
			update SamplePrescriptionHeader set SamplePrescriptionName=@SamplePrescriptionName,SamplePrescriptionDescription=@SamplePrescriptionDescription,EmployeeCode=@EmployeeCode where SamplePrescriptionCode=@SamplePrescriptionCode
		end
	else
	begin
		declare @_SampleCode varchar(50)
		declare @_stt decimal(8,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(SamplePrescriptionCode,5)) maxcode from SamplePrescriptionHeader order by RowID desc)+1
		if(@_stt<=9)
			begin
				set @_SampleCode = 'TOA0000'+convert(varchar(5),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_SampleCode = 'TOA000'+convert(varchar(5),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_SampleCode = 'TOA00'+convert(varchar(5),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_SampleCode = 'TOA0'+convert(varchar(5),@_stt)
			end
		else if(@_stt>9999 and @_stt<=99999)
			begin
				set @_SampleCode = 'TOA'+convert(varchar(5),@_stt)
			end
		else
			begin
				set @_SampleCode = 'TOA00001'
			end
		insert into SamplePrescriptionHeader(SamplePrescriptionCode,SamplePrescriptionName,SamplePrescriptionDescription,EmployeeCode) values(@_SampleCode,@SamplePrescriptionName,@SamplePrescriptionDescription,@EmployeeCode)
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_SampleHeader%')
	drop procedure pro_Del_SampleHeader
go
create procedure pro_Del_SampleHeader
(
	@SamplePrescriptionCode varchar(50),
	@iresult int output
)
as
begin
	delete from SamplePrescriptionLine where SamplePrescriptionCode=@SamplePrescriptionCode
	delete from SamplePrescriptionHeader where SamplePrescriptionCode=@SamplePrescriptionCode
	set @iresult =1
end
go
--- exec pro_Del_SampleHeader 'TOA00003'
------------------ Table SamplePrescriptionLine
if exists(select name from sysobjects where name ='pro_Ins_SampleLine')
	drop procedure pro_Ins_SampleLine
go
create procedure pro_Ins_SampleLine
(
	@SamplePrescriptionCode varchar(50),
	@ItemCode varchar(50),
	@UnitOfMeasure varchar(50),
	@DateOfIssues int,
	@Morning float,
	@Noon float,
	@Afternoon float,
	@Evening float,
	@Quantity float,
	@Instruction nvarchar(max),
	@RowID numeric(18,0),
	@UnitOfMeasureCode_Medi varchar(15)
)
as
begin
	if exists(select RowID from SamplePrescriptionLine where RowID=@RowID)
		begin		
			update SamplePrescriptionLine set ItemCode=@ItemCode,UnitOfMeasure=@UnitOfMeasure,DateOfIssues=@DateOfIssues,Morning=@Morning,Noon=@Noon,Afternoon=@Afternoon,Evening=@Evening,Quantity=@Quantity,Instruction=@Instruction,UnitOfMeasureCode_Medi=@UnitOfMeasureCode_Medi where RowID=@RowID
		end
	else
	begin
		insert into SamplePrescriptionLine(SamplePrescriptionCode,ItemCode,UnitOfMeasure,DateOfIssues,Morning,Noon,Afternoon,Evening,Quantity,Instruction,UnitOfMeasureCode_Medi) values(@SamplePrescriptionCode,@ItemCode,@UnitOfMeasure,@DateOfIssues,@Morning,@Noon,@Afternoon,@Evening,@Quantity,@Instruction,@UnitOfMeasureCode_Medi)
	End
end
go
if exists(select name from sysobjects where name ='pro_Del_SampleLine')
	drop procedure pro_Del_SampleLine
go
create procedure pro_Del_SampleLine
(
	@RowID decimal(18,0),
	@iresult int output
)
as
begin
	delete from SamplePrescriptionLine where RowID=@RowID
	set @iresult =1
end
go
------------------ Table SamplePrescriptionHeader
if exists(select name from sysobjects where name ='pro_Ins_MedicalRecord')
	drop procedure pro_Ins_MedicalRecord
go
create procedure pro_Ins_MedicalRecord
(
	@MedicalRecordCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(50),
	@DepartmentCode varchar(50),
	@EmployeeCode varchar(50),
	@DiagnosisCode numeric(18,0),
	@DescriptionNode nvarchar(1000),
	@PostingDate datetime,
	@AppointmentDate datetime,
	@ReferenceCode varchar(50),
	@Symptoms nvarchar(250),
	@Status int,
	@ObjectCode int,
	@Advices nvarchar(250),
	@DiagnosisEnclosed numeric(18,0),
	@TackleCode int,
	@ServiceCode varchar(50),
	@RowIDMedicalPattern int =-1,
	@ContentMedicalPattern nvarchar(max),
	@EmployeeCodeDoctor varchar(50),
	@DiagnosisCustom nvarchar(250),
	@TypeMedical int =1,
	@ReceiptID numeric(18,0)=0,
	@ShiftWork char(2),
	@Treatments nvarchar(200)='',
	@Pregnant bit=0,
	@Breastfeeding bit=0,
	@Use_Smoking bit=0,
	@Use_Alcohol bit=0,
	@EmployeeCodeDoing varchar(50)='',
	@ICD10_Custom varchar(20)='',
	@ICD10Name_Custom nvarchar(500)='',
	@ResultMedicalCode varchar(50) output
)
as
begin
	if(@ReceiptID=0)
		set @ReceiptID = (select top(1) ReceiptID from SuggestedServiceReceipt where PatientCode=@PatientCode and RefID=@PatientReceiveID and DepartmentCode=@DepartmentCode and Note='TIEPDON' and ServiceCode=@ServiceCode)
	if exists(select MedicalRecordCode from MedicalRecord where MedicalRecordCode=@MedicalRecordCode)
		begin		
			update MedicalRecord set PatientReceiveID=@PatientReceiveID,PatientCode=@PatientCode,DepartmentCode=@DepartmentCode,EmployeeCode=@EmployeeCode,DiagnosisCode=@DiagnosisCode,
			DescriptionNode=@DescriptionNode,PostingDate=@PostingDate,AppointmentDate=@AppointmentDate,ReferenceCode=@ReferenceCode,Symptoms=@Symptoms,ObjectCode=@ObjectCode,
			Advices=@Advices,DiagnosisEnclosed=@DiagnosisEnclosed,TackleCode=@TackleCode,RowIDMedicalPattern=@RowIDMedicalPattern,ContentMedicalPattern=@ContentMedicalPattern,EmployeeCodeDoctor=@EmployeeCodeDoctor,ReceiptID=@ReceiptID,DiagnosisCustom=@DiagnosisCustom,Treatments=@Treatments,
			Pregnant=@Pregnant,Breastfeeding=@Breastfeeding,Use_Smoking=@Use_Smoking,Use_Alcohol=@Use_Alcohol,EmployeeCodeDoing=@EmployeeCodeDoing,ICD10_Custom=@ICD10_Custom,ICD10Name_Custom=@ICD10Name_Custom
			where MedicalRecordCode=@MedicalRecordCode
			set @ResultMedicalCode=@MedicalRecordCode
		end
	else
	begin
		set @MedicalRecordCode =(SELECT 'BA' + CONVERT(char(8),GETDATE(),112) + REPLACE(CONVERT(VARCHAR(15),GETDATE(),114),':','') Code)
		insert into MedicalRecord(MedicalRecordCode,PatientReceiveID,PatientCode,DepartmentCode,EmployeeCode,DiagnosisCode,DescriptionNode,PostingDate,AppointmentDate,ReferenceCode,Symptoms,Status,ObjectCode,Advices,DiagnosisEnclosed,TackleCode,RowIDMedicalPattern,ContentMedicalPattern,EmployeeCodeDoctor,ReceiptID,DiagnosisCustom,TypeMedical,ShiftWork,Treatments,Pregnant,Breastfeeding,Use_Smoking,Use_Alcohol,EmployeeCodeDoing,ICD10_Custom,ICD10Name_Custom) 
		values(@MedicalRecordCode,@PatientReceiveID,@PatientCode,@DepartmentCode,@EmployeeCode,@DiagnosisCode,@DescriptionNode,@PostingDate,@AppointmentDate,@ReferenceCode,@Symptoms,@Status,@ObjectCode,@Advices,@DiagnosisEnclosed,@TackleCode,@RowIDMedicalPattern,@ContentMedicalPattern,@EmployeeCodeDoctor,@ReceiptID,@DiagnosisCustom,@TypeMedical,@ShiftWork,@Treatments,@Pregnant,@Breastfeeding,@Use_Smoking,@Use_Alcohol,@EmployeeCodeDoing,@ICD10_Custom,@ICD10Name_Custom)
		update PatientReceive set status=1 where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID
		update SuggestedServiceReceipt set status=1 where PatientCode=@PatientCode and RefID=@PatientReceiveID and DepartmentCode=@DepartmentCode and Note='TIEPDON' and ServiceCode=@ServiceCode
		set @ResultMedicalCode=@MedicalRecordCode
	end
end
go
if exists(select name from sysobjects where name ='pro_Ins_MedicalRecordForAttachItems')
	drop procedure pro_Ins_MedicalRecordForAttachItems
go
create procedure pro_Ins_MedicalRecordForAttachItems
(
	@MedicalRecordCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(50),
	@DepartmentCode varchar(50),
	@EmployeeCode varchar(50),
	@DiagnosisCode numeric(18,0),
	@DescriptionNode nvarchar(1000),
	@PostingDate datetime,
	@AppointmentDate datetime,
	@ReferenceCode varchar(50),
	@Symptoms nvarchar(250),
	@Status int,
	@ObjectCode int,
	@Advices nvarchar(250),
	@DiagnosisEnclosed numeric(18,0),
	@TackleCode int,
	@ServiceCode varchar(50),
	@RowIDMedicalPattern int =-1,
	@ContentMedicalPattern nvarchar(max),
	@EmployeeCodeDoctor varchar(50),
	@DiagnosisCustom nvarchar(250),
	@TypeMedical int =1,
	@ReceiptID numeric(18,0)=0,
	@ShiftWork char(2),
	@Treatments nvarchar(200)='',
	@Pregnant bit=0,
	@Breastfeeding bit=0,
	@Use_Smoking bit=0,
	@Use_Alcohol bit=0,
	@EmployeeCodeDoing varchar(50)='',
	@ICD10_Custom varchar(20)='',
	@ICD10Name_Custom nvarchar(500)='',
	@ResultMedicalCode varchar(50) output
)
as
begin
	if exists(select MedicalRecordCode from MedicalRecord where ReceiptID=@ReceiptID)
		begin		
			update MedicalRecord set PatientReceiveID=@PatientReceiveID,PatientCode=@PatientCode,DepartmentCode=@DepartmentCode,EmployeeCode=@EmployeeCode,DiagnosisCode=@DiagnosisCode,
			DescriptionNode=@DescriptionNode,PostingDate=@PostingDate,AppointmentDate=@AppointmentDate,ReferenceCode=@ReferenceCode,Symptoms=@Symptoms,ObjectCode=@ObjectCode,
			Advices=@Advices,DiagnosisEnclosed=@DiagnosisEnclosed,TackleCode=@TackleCode,RowIDMedicalPattern=@RowIDMedicalPattern,ContentMedicalPattern=@ContentMedicalPattern,EmployeeCodeDoctor=@EmployeeCodeDoctor,ReceiptID=@ReceiptID,DiagnosisCustom=@DiagnosisCustom,Treatments=@Treatments,
			Pregnant=@Pregnant,Breastfeeding=@Breastfeeding,Use_Smoking=@Use_Smoking,Use_Alcohol=@Use_Alcohol,EmployeeCodeDoing=@EmployeeCodeDoing,ICD10_Custom=@ICD10_Custom,ICD10Name_Custom=@ICD10Name_Custom
			where ReceiptID=@ReceiptID
			set @ResultMedicalCode=@MedicalRecordCode
		end
	else
	begin
		set @MedicalRecordCode =(SELECT 'BA' + CONVERT(char(8),GETDATE(),112) + REPLACE(CONVERT(VARCHAR(15),GETDATE(),114),':','') Code)
		insert into MedicalRecord(MedicalRecordCode,PatientReceiveID,PatientCode,DepartmentCode,EmployeeCode,DiagnosisCode,DescriptionNode,PostingDate,AppointmentDate,ReferenceCode,Symptoms,Status,ObjectCode,Advices,DiagnosisEnclosed,TackleCode,RowIDMedicalPattern,ContentMedicalPattern,EmployeeCodeDoctor,ReceiptID,DiagnosisCustom,TypeMedical,ShiftWork,Treatments,Pregnant,Breastfeeding,Use_Smoking,Use_Alcohol,EmployeeCodeDoing,ICD10_Custom,ICD10Name_Custom) 
		values(@MedicalRecordCode,@PatientReceiveID,@PatientCode,@DepartmentCode,@EmployeeCode,@DiagnosisCode,@DescriptionNode,@PostingDate,@AppointmentDate,@ReferenceCode,@Symptoms,@Status,@ObjectCode,@Advices,@DiagnosisEnclosed,@TackleCode,@RowIDMedicalPattern,@ContentMedicalPattern,@EmployeeCodeDoctor,@ReceiptID,@DiagnosisCustom,@TypeMedical,@ShiftWork,@Treatments,@Pregnant,@Breastfeeding,@Use_Smoking,@Use_Alcohol,@EmployeeCodeDoing,@ICD10_Custom,@ICD10Name_Custom)		
		set @ResultMedicalCode=@MedicalRecordCode
	end
end
go
if exists(select name from sysobjects where name ='pro_Ins_MedicalRecord_Emergency')
	drop procedure pro_Ins_MedicalRecord_Emergency
go
create procedure pro_Ins_MedicalRecord_Emergency
(
	@MedicalRecordCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(50),
	@DepartmentCode varchar(50),
	@EmployeeCode varchar(50),
	@PostingDate datetime,
	@ReferenceCode varchar(50),
	@Status int,
	@ObjectCode int,
	@DiagnosisEnclosed numeric(18,0),
	@AppointmentDate datetime,
	@ShiftWork char(2),
	@Treatments nvarchar(max),
	@DiagnosisCustom nvarchar(200),
	@Advices nvarchar(250),
	@Symptoms nvarchar(250),
	@ReceiptID decimal=0,
	@ResultMedicalCode varchar(50) output
)
as
begin
	declare @DiagnosisCode numeric(18,0)=0
	select @DiagnosisCode=b.RowID from MedicalEmergency a inner join Diagnosis b on a.ICD10=b.DiagnosisCode where a.PatientCode=@PatientCode and a.MedicalEmergencyCode=@ReferenceCode
	if exists(select MedicalRecordCode from MedicalRecord where MedicalRecordCode=@MedicalRecordCode)
		begin		
			update MedicalRecord set DepartmentCode=@DepartmentCode,EmployeeCode=@EmployeeCode,
			PostingDate=@PostingDate,ObjectCode=@ObjectCode,DiagnosisCode=@DiagnosisCode,AppointmentDate=@AppointmentDate,ShiftWork=@ShiftWork,Treatments=@Treatments,DiagnosisCustom=@DiagnosisCustom,Advices=@Advices, Symptoms=@Symptoms,ReceiptID=@ReceiptID
			where MedicalRecordCode=@MedicalRecordCode and ReferenceCode=@ReferenceCode and PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode and Paid=0 and Status=0
			set @ResultMedicalCode=@MedicalRecordCode
		end
	else
	begin
		set @MedicalRecordCode =(SELECT 'BA' + CONVERT(char(8),GETDATE(),112) + REPLACE(CONVERT(VARCHAR(15),GETDATE(),114),':','') Code)
		insert into MedicalRecord(MedicalRecordCode,PatientReceiveID,PatientCode,DepartmentCode,EmployeeCode,PostingDate,ReferenceCode,Status,ObjectCode,DiagnosisEnclosed,DiagnosisCode,AppointmentDate,ShiftWork,Treatments,DiagnosisCustom,Advices,Symptoms,ReceiptID) 
		values(@MedicalRecordCode,@PatientReceiveID,@PatientCode,@DepartmentCode,@EmployeeCode,@PostingDate,@ReferenceCode,@Status,@ObjectCode,@DiagnosisEnclosed,@DiagnosisCode,@AppointmentDate,@ShiftWork,@Treatments,@DiagnosisCustom,@Advices,@Symptoms,@ReceiptID)
		set @ResultMedicalCode=@MedicalRecordCode
	end
end
go
if exists(select name from sysobjects where name ='pro_Ins_MedicalRecord_Surgeries')
	drop procedure pro_Ins_MedicalRecord_Surgeries
go
create procedure pro_Ins_MedicalRecord_Surgeries
(
	@MedicalRecordCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(50),
	@DepartmentCode varchar(50),
	@EmployeeCode varchar(50),
	@PostingDate datetime,
	@ReferenceCode varchar(50),
	@Status int,
	@ObjectCode int,
	@DiagnosisEnclosed numeric(18,0),
	@AppointmentDate datetime,
	@ResultMedicalCode varchar(50) output
)
as
begin
declare @DiagnosisCode numeric(18,0)
	select @DiagnosisCode=b.RowID from Surgeries a inner join Diagnosis b on a.ICD10On=b.DiagnosisCode where a.PatientCode=@PatientCode and a.SurgeriesCode=@ReferenceCode
	if exists(select MedicalRecordCode from MedicalRecord where MedicalRecordCode=@MedicalRecordCode)
		begin		
			update MedicalRecord set DepartmentCode=@DepartmentCode,EmployeeCode=@EmployeeCode,
			PostingDate=@PostingDate,ObjectCode=@ObjectCode,DiagnosisCode=@DiagnosisCode,AppointmentDate=@AppointmentDate
			where MedicalRecordCode=@MedicalRecordCode and ReferenceCode=@ReferenceCode and PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode
			set @ResultMedicalCode=@MedicalRecordCode
		end
	else
	begin
		set @MedicalRecordCode =(SELECT 'BA' + CONVERT(char(8),GETDATE(),112) + REPLACE(CONVERT(VARCHAR(15),GETDATE(),114),':','') Code)
		insert into MedicalRecord(MedicalRecordCode,PatientReceiveID,PatientCode,DepartmentCode,EmployeeCode,PostingDate,ReferenceCode,Status,ObjectCode,DiagnosisEnclosed,DiagnosisCode,AppointmentDate) 
		values(@MedicalRecordCode,@PatientReceiveID,@PatientCode,@DepartmentCode,@EmployeeCode,@PostingDate,@ReferenceCode,@Status,@ObjectCode,@DiagnosisEnclosed,@DiagnosisCode,@AppointmentDate)
		set @ResultMedicalCode=@MedicalRecordCode
	end
end
go
--------------------------------------
if exists(select name from sysobjects where name ='pro_Ins_MedicalPrescriptionDetail')
	drop procedure pro_Ins_MedicalPrescriptionDetail
go
create procedure pro_Ins_MedicalPrescriptionDetail
(
	@MedicalRecordCode varchar(50),
	@EmployeeCode varchar(50),
	@ItemCode varchar(50),
	@DateOfIssues int,
	@Morning varchar(50),
	@Noon varchar(50),
	@Afternoon varchar(50),
	@Evening varchar(50),
	@Quantity numeric(18,2),
	@Instruction nvarchar(max),
	@UnitPrice numeric(18,4),
	@Amount numeric(18,4),
	@PostingDate datetime,
	@Status int,
	@New int,
	@RepositoryCode varchar(50),
	@ObjectCode int =2,
	@DoseOf int,
	@DoseOfPills varchar(50),
	@BHYT int=0,
	@UnitOfMeasureCode_Medi varchar(15),
	@ObjectCode_Patient int
)
as
begin
	--declare @ListBHYT_Temp int =(select ListBHYT from Items where ItemCode=@ItemCode)
	--if( @ListBHYT_Temp=1 and @ObjectCode_Patient=1 and @ObjectCode=1)
	--	set @ObjectCode = @ObjectCode_Patient
	--else
	--	begin
	--		if(@ObjectCode_Patient=1)
	--			set @ObjectCode = 2
	--		else
	--			set @ObjectCode = @ObjectCode_Patient
	--	end
	declare @ItemCode_Temp varchar(50)
	declare @Quantity_Temp numeric(18,2)
	declare @AmountVirtual_Temp numeric(18,2)
	if exists(select ItemCode from MedicalPrescriptionDetail where MedicalRecordCode=@MedicalRecordCode and ItemCode=@ItemCode and Status=0 and RepositoryCode=@RepositoryCode)
		begin		
			select @ItemCode_Temp=ItemCode,@Quantity_Temp=Quantity from MedicalPrescriptionDetail where MedicalRecordCode=@MedicalRecordCode and ItemCode=@ItemCode and Status=0 and RepositoryCode=@RepositoryCode
			select @AmountVirtual_Temp=AmountVirtual from InventoryGeneral where ItemCode=@ItemCode_Temp and RepositoryCode=@RepositoryCode  and Hide = 0
			if @AmountVirtual_Temp>=@Quantity_Temp
			begin
				update InventoryGeneral set AmountVirtual=AmountVirtual-@Quantity_Temp where ItemCode=@ItemCode_Temp and RepositoryCode=@RepositoryCode  and Hide = 0
			end
			update MedicalPrescriptionDetail set EmployeeCode=@EmployeeCode,DateOfIssues=@DateOfIssues,Morning=@Morning,Noon=@Noon,Afternoon=@Afternoon,
			Evening=@Evening,Quantity=@Quantity,Instruction=@Instruction,UnitPrice=@UnitPrice,Amount=@Amount,PostingDate=@PostingDate,New=@New,ObjectCode=@ObjectCode,DoseOf=@DoseOf,DoseOfPills=@DoseOfPills,BHYT=@BHYT,UnitOfMeasureCode_Medi=@UnitOfMeasureCode_Medi
			where MedicalRecordCode=@MedicalRecordCode and ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Status=0
			update InventoryGeneral set AmountVirtual=AmountVirtual+@Quantity where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode  and Hide = 0
		end
	--else if exists(select ItemCode from MedicalPrescriptionDetail where MedicalRecordCode=@MedicalRecordCode and ItemCode=@ItemCode and Status=1)
		--begin
			--set @Status=1
		--end
	else
	begin
		insert into MedicalPrescriptionDetail(MedicalRecordCode,EmployeeCode,ItemCode,DateOfIssues,Morning,Noon,Afternoon,Evening,Quantity,Instruction,UnitPrice,Amount,PostingDate,Status,RepositoryCode,New,ObjectCode,DoseOf,DoseOfPills,BHYT,UnitOfMeasureCode_Medi) 
		values(@MedicalRecordCode,@EmployeeCode,@ItemCode,@DateOfIssues,@Morning,@Noon,@Afternoon,@Evening,@Quantity,@Instruction,@UnitPrice,@Amount,@PostingDate,@Status,@RepositoryCode,@New,@ObjectCode,@DoseOf,@DoseOfPills,@BHYT,@UnitOfMeasureCode_Medi)
		update InventoryGeneral set AmountVirtual=AmountVirtual+@Quantity where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Hide = 0
	end
end
go
if exists(select name from sysobjects where name like'pro_Del_MedicalPrescriptionDetail')
	drop procedure pro_Del_MedicalPrescriptionDetail
go
create procedure pro_Del_MedicalPrescriptionDetail
(
	@MedicalRecordCode varchar(50),
	@RowID numeric(18,0),
	@Result int output,
	@BHYT int=0
)
as
begin
	declare @Count int
	if exists(select RowID from MedicalPrescriptionDetail where RowID=@RowID and Status=0 and BHYT=@BHYT)
		begin		
			delete from MedicalPrescriptionDetail where RowID=@RowID and Status=0
			--select @Count=Count(*) from MedicalPrescriptionDetail where MedicalRecordCode=@MedicalRecordCode
			--if @Count<=0
				--delete from MedicalRecord where MedicalRecordCode=@MedicalRecordCode 
			set @Result =1
		end
	else
	begin
		if @RowID=-1
			begin
				delete from MedicalPrescriptionDetail where MedicalRecordCode=@MedicalRecordCode and Status=0 and BHYT=@BHYT
				--select @Count=Count(*) from MedicalPrescriptionDetail where MedicalRecordCode=@MedicalRecordCode
				--if @Count<=0
					--delete from MedicalRecord where MedicalRecordCode=@MedicalRecordCode 
				--set @Result =1
			end
		else
			set @Result =-1
	end
end
go
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
			delete from HospitalTransfer where PatientReceiveID=@PatientReceiveID
			delete from PatientAppointment where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID
			delete from SurviveSign where RefID=@PatientReceiveID and PatientCode=@PatientCode and ReferenceCode=@MedicalRecordCode
			delete from MedicalPrescriptionDetail where MedicalRecordCode=@MedicalRecordCode
			delete from MedicalRecord_ANC where MedicalRecordCode=@MedicalRecordCode
			delete from MedicalRecord_Childbirth where MedicalRecordCode=@MedicalRecordCode
			delete from MedicalRecord_Abortions where MedicalRecordCode=@MedicalRecordCode
			delete from MedicalRecord where MedicalRecordCode=@MedicalRecordCode and PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode
			update SuggestedServiceReceipt set Status=0 where ReceiptID=@ReceiptID
			delete from SuggestedServiceReceipt where RefID=@PatientReceiveID and PatientCode=@PatientCode and ReferenceCode=@MedicalRecordCode and Status=0 and (BanksAccountCode is null or BanksAccountCode='')
			set @Result =1 --- success
		end
    end
    else
		set @Result =-3 --- Mã hs benh an chua phat sinh
end
go
------------------------------------ Table hen [PatientAppointment]
if exists(select name from sysobjects where name like'%pro_Ins_PatientAppointment%')
	drop procedure pro_Ins_PatientAppointment
go
create procedure pro_Ins_PatientAppointment
(
	@PatientCode varchar(50),
	@ExaminationDate datetime,
	@AppointmentDate datetime,
	@PatientReceiveID numeric(18,0),
	@EmloyeeCode varchar(50),
	@AppointmentNote nvarchar(250),
	@STT int
)
as
begin
	declare @RowID numeric(18,0)
	declare @STTTemp int
	select @RowID=ISNULL(MAX(RowID)+1,1) from PatientAppointment
	select @STTTemp=ISNULL(MAX(STT)+1,1) from PatientAppointment where CONVERT(date,AppointmentDate,103)=CONVERT(date,GETDATE(),103)
	--if exists(select PatientCode from PatientAppointment where PatientCode=@PatientCode and CONVERT(date,AppointmentDate,103)=CONVERT(date,@AppointmentDate,103))
	if exists(select PatientCode from PatientAppointment where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID)
		begin
			if CONVERT(char(10),@AppointmentDate,103)='01/01/1990'
				begin
					delete from PatientAppointment where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID 
				end
			else
				begin
					update PatientAppointment set ExaminationDate=@ExaminationDate,AppointmentDate=@AppointmentDate,AppointmentNote=@AppointmentNote,STT=@STTTemp
					where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID
				end
		end
	else
	begin
		insert into PatientAppointment(RowID,PatientCode,ExaminationDate,AppointmentDate,PatientReceiveID,EmloyeeCode,AppointmentNote,STT)
		values(@RowID,@PatientCode,@ExaminationDate,@AppointmentDate,@PatientReceiveID,@EmloyeeCode,@AppointmentNote,@STTTemp)
	end
end
go
if exists(select name from sysobjects where name like'%pro_Ins_AppointmentRegister%')
	drop procedure pro_Ins_AppointmentRegister
go
create procedure pro_Ins_AppointmentRegister
(
	@PatientCode varchar(50),
	@ExaminationDate datetime,
	@AppointmentDate datetime,
	@PatientReceiveID numeric(18,0),
	@EmloyeeCode varchar(50),
	@AppointmentNote nvarchar(250),
	@STT int,
	@AppointmentHour varchar(10),
	@Done int,
	@StatusID int,
	@LableID int,
	@AppointmentDateOld datetime,
	@AppointmentHourOld varchar(10),
	@iresult int output
)
as
begin
	declare @STTTemp int
	select @STTTemp=ISNULL(MAX(STT)+1,1) from PatientAppointment where CONVERT(date,AppointmentDate,103)=CONVERT(date,GETDATE(),103)
	if exists(select PatientCode from PatientAppointment where PatientCode=@PatientCode and AppointmentDate=@AppointmentDateOld and AppointmentHour=@AppointmentHourOld)
		begin		
			update PatientAppointment set ExaminationDate=@ExaminationDate,AppointmentDate=@AppointmentDate,AppointmentNote=@AppointmentNote,STT=@STTTemp,AppointmentHour=@AppointmentHour,Done=@Done,StatusID=@StatusID,LableID=@LableID
			where PatientCode=@PatientCode and AppointmentDate=@AppointmentDateOld and AppointmentHour=@AppointmentHourOld
			set @iresult=1
		end
	else
	begin
		SET IDENTITY_INSERT PatientAppointment on
		insert into PatientAppointment(PatientCode,ExaminationDate,AppointmentDate,PatientReceiveID,EmloyeeCode,AppointmentNote,STT,AppointmentHour,Done,StatusID,LableID)
		values(@PatientCode,@ExaminationDate,@AppointmentDate,@PatientReceiveID,@EmloyeeCode,@AppointmentNote,@STTTemp,@AppointmentHour,@Done,@StatusID,@LableID)
		SET IDENTITY_INSERT PatientAppointment off
		set @iresult=1
	end
end
go
------------------ Table Phieu nhap kho[Warehousing]
if exists(select name from sysobjects where name ='pro_Ins_Warehousing' and type='P')
	drop procedure pro_Ins_Warehousing
go
create procedure pro_Ins_Warehousing
(
	@WarehousingCode varchar(50),
	@ImportDate date,
	@Seri varchar(50),
	@InvoiceNnumber nvarchar(50),
	@InvoiceDate varchar(50),
	@ReportNumber varchar(50),
	@ReportDate varchar(50),
	@VendorCode varchar(50),
	@Discount int,
	@Shipper nvarchar(250),
	@Supplies int,
	@RepositoryCode varchar(50),
	@Reason int,
	@Note nvarchar(250),
	@EmployeeCode varchar(50),
	@Status int,
	@InventoryStaff nvarchar(150),
	@ShiftWork char(2),
	@FormNo varchar(100),
	@VAT int =0,
	@Depreciated decimal,
	@ResultWarehousingCode varchar(50) output
)
as
begin
	if exists(select WarehousingCode from Warehousing where WarehousingCode=@WarehousingCode)
		begin		
			update Warehousing set ImportDate=@ImportDate,Seri=@Seri,InvoiceNnumber=@InvoiceNnumber,InvoiceDate=@InvoiceDate,ReportNumber=@ReportNumber,ReportDate=@ReportDate,VendorCode=@VendorCode,Discount=@Discount,Shipper=@Shipper,
			Supplies=@Supplies,RepositoryCode=@RepositoryCode,Reason=@Reason,Note=@Note,EmployeeCode=@EmployeeCode,Status=@Status,InventoryStaff=@InventoryStaff,ShiftWork=@ShiftWork,FormNo=@FormNo,VAT=@VAT,Depreciated=@Depreciated
			where WarehousingCode=@WarehousingCode
			set @ResultWarehousingCode=@WarehousingCode
		end
	else
	begin
		declare @_TempCode varchar(50)
		declare @_stt decimal(18,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(WarehousingCode,12)) maxcode from Warehousing order by RowID desc)+1
		if(@_stt<=9)
			begin
				set @_TempCode = 'PN00000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_TempCode = 'PN0000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_TempCode = 'PN000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_TempCode = 'PN00000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999 and @_stt<=99999)
			begin
				set @_TempCode = 'PN0000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999 and @_stt<=999999)
			begin
				set @_TempCode = 'PN000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999999 and @_stt<=9999999)
			begin
				set @_TempCode = 'PN00000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999999 and @_stt<=99999999)
			begin
				set @_TempCode = 'PN0000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999999 and @_stt<=999999999)
			begin
				set @_TempCode = 'PN000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999999999 and @_stt<=9999999999)
			begin
				set @_TempCode = 'PN00'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999999999 and @_stt<=99999999999)
			begin
				set @_TempCode = 'PN0'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999999999 and @_stt<=999999999999)
			begin
				set @_TempCode = 'PN'+convert(varchar(12),@_stt)
			end
		else
			begin
				set @_TempCode = 'PN000000000001'
			end
		insert into Warehousing(WarehousingCode,ImportDate,Seri,InvoiceNnumber,InvoiceDate,ReportNumber,ReportDate,VendorCode,Discount,Shipper,Supplies,RepositoryCode,Reason,Note,EmployeeCode,Status,InventoryStaff,ShiftWork,FormNo,VAT,Depreciated) values(@_TempCode,@ImportDate,@Seri,@InvoiceNnumber,@InvoiceDate,@ReportNumber,@ReportDate,@VendorCode,@Discount,@Shipper,@Supplies,@RepositoryCode,@Reason,@Note,@EmployeeCode,@Status,@InventoryStaff,@ShiftWork,@FormNo,@VAT,@Depreciated)
		set @ResultWarehousingCode=@_TempCode
	end
end
go
if exists(select name from sysobjects where name like'pro_Ins_ExportWarehousing')
	drop procedure pro_Ins_ExportWarehousing
go
create procedure pro_Ins_ExportWarehousing
(
	@ExpWarehousingCode varchar(50),
	@ExportDate date,
	@ExpRepositoryCode varchar(50),
	@ImpRepositoryCode varchar(50),
	@Note nvarchar(250),
	@EmployeeCode varchar(50),
	@Type int,
	@EmployeeNameReceive nvarchar(250)='',
	@ResultCode varchar(50) output
)
as
begin
	if exists(select ExpWarehousingCode from ExportWarehousing where ExpWarehousingCode=@ExpWarehousingCode)
		begin		
			update ExportWarehousing 
			set ExportDate=@ExportDate,ExpRepositoryCode=@ExpRepositoryCode,ImpRepositoryCode=@ImpRepositoryCode,Note=@Note,EmployeeCode=@EmployeeCode,[Type]=@Type,EmployeeNameReceive=@EmployeeNameReceive
			where ExpWarehousingCode=@ExpWarehousingCode
			set @ResultCode=@ExpWarehousingCode
		end
	else
	begin
		declare @_TempCode varchar(50)
		declare @_stt decimal(18,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(ExpWarehousingCode,12)) maxcode from ExportWarehousing order by RowID desc)+1
		if(@_stt<=9)
			begin
				set @_TempCode = 'PX00000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_TempCode = 'PX0000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_TempCode = 'PX000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_TempCode = 'PX00000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999 and @_stt<=99999)
			begin
				set @_TempCode = 'PX0000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999 and @_stt<=999999)
			begin
				set @_TempCode = 'PX000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999999 and @_stt<=9999999)
			begin
				set @_TempCode = 'PX00000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999999 and @_stt<=99999999)
			begin
				set @_TempCode = 'PX0000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999999 and @_stt<=999999999)
			begin
				set @_TempCode = 'PX000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999999999 and @_stt<=9999999999)
			begin
				set @_TempCode = 'PX00'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999999999 and @_stt<=99999999999)
			begin
				set @_TempCode = 'PX0'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999999999 and @_stt<=999999999999)
			begin
				set @_TempCode = 'PX'+convert(varchar(12),@_stt)
			end
		else
			begin
				set @_TempCode = 'PX000000000001'
			end
		insert into ExportWarehousing(ExpWarehousingCode,ExportDate,ExpRepositoryCode,ImpRepositoryCode,Note,EmployeeCode,Type,EmployeeNameReceive) values(@_TempCode,@ExportDate,@ExpRepositoryCode,@ImpRepositoryCode,@Note,@EmployeeCode,@Type,@EmployeeNameReceive)
		set @ResultCode=@_TempCode
	end
end
go
if exists(select name from sysobjects where name like'pro_Ins_ExportWarehousingDetail')
	drop procedure pro_Ins_ExportWarehousingDetail
go
create procedure pro_Ins_ExportWarehousingDetail
(
	@RowIDGumshoe numeric(18,3),
	@RepositoryReceiveCode varchar(50),
	@RepositoryExportCode varchar(50),
	@AmountRealExport numeric(18,3),
	@ExpWarehousingCode varchar(50)
)
as
begin
	declare @ItemCode varchar(50)
	declare @AmountImport numeric(18,3)
	declare @WarehousingCode varchar(50)
	declare @DateEnd date
	declare @SalesPrice numeric(18,3)
	declare @UnitPrice numeric(18,3)
	declare @AmountExport numeric(18,3)
	declare @Shipment nvarchar(50)
	declare @BHYTPrice numeric(18,3)
	declare @DateImport datetime
	declare @IDWarehousingDetail numeric(18,0)
	select @ItemCode=ItemCode,@AmountImport=AmountImport,@WarehousingCode=WarehousingCode,@DateEnd=DateEnd,@SalesPrice=SalesPrice,
	@UnitPrice=UnitPrice,@AmountExport=AmountExport,@Shipment=Shipment,@BHYTPrice=BHYTPrice,@DateImport=DateImport,@IDWarehousingDetail=IDWarehousingDetail
	from InventoryGumshoe where RowID=@RowIDGumshoe
	if exists (select ItemCode from InventoryGumshoe where RowID=@RowIDGumshoe and AmountImport>=(AmountExport+@AmountRealExport))
	begin
		insert into InventoryGumshoe(DateImport,ItemCode,AmountImport,WarehousingCode,DateEnd,SalesPrice,UnitPrice,AmountExport,Shipment,RepositoryCode,BHYTPrice,ExpWarehousingCode,IDWarehousingDetail)
		values(@DateImport,@ItemCode,@AmountRealExport,@WarehousingCode,@DateEnd,@SalesPrice,@UnitPrice,0,@Shipment,@RepositoryReceiveCode,@BHYTPrice,@ExpWarehousingCode,@IDWarehousingDetail)
		insert into ExportWarehousingDetail(DateImport,ItemCode,AmountImport,WarehousingCode,DateEnd,SalesPrice,UnitPrice,AmountExport,Shipment,RepositoryExportCode,IDate,BHYTPrice,ExpWarehousingCode,RepositoryReceiveCode,RowIDGumshoe,AmountRealExport)
		values (@DateImport,@ItemCode,@AmountImport,@WarehousingCode,@DateEnd,@SalesPrice,@UnitPrice,@AmountExport,@Shipment,@RepositoryExportCode,GETDATE(),@BHYTPrice,@ExpWarehousingCode,@RepositoryReceiveCode,@RowIDGumshoe,@AmountRealExport)
		update InventoryGumshoe set AmountExport=AmountExport+@AmountRealExport where RowID=@RowIDGumshoe
	end
end
go
--exec pro_Ins_ExportWarehousingDetail 99,'KHO004','KHO001'
if exists(select name from sysobjects where name like'%pro_Del_ExportWarehousing%')
	drop procedure pro_Del_ExportWarehousing
go
create procedure pro_Del_ExportWarehousing
(
	@ExpWarehousingCode varchar(50),
	@iresult int output
)
as
begin
	declare @ItemCode varchar(50)
	declare @RowIDGumshoe numeric(18,0)
	declare @AmountRealExport numeric(18,3)
	declare @ExpRepositoryCode varchar(50)
	declare @ImpRepositoryCode varchar(50)
	
	select @ExpRepositoryCode=ExpRepositoryCode,@ImpRepositoryCode=ImpRepositoryCode from ExportWarehousing where ExpWarehousingCode=@ExpWarehousingCode
	if exists(select ItemCode from RealMedicinesForPatientsDetail where RowIDInventoryGumshoe in(select RowID from InventoryGumshoe  where ExpWarehousingCode=@ExpWarehousingCode and RepositoryCode=@ImpRepositoryCode))
		set @iresult =-2
	if exists(select ItemCode from MedicinesForPatientsDetail where RowIDInventoryGumshoe in(select RowID from InventoryGumshoe  where ExpWarehousingCode=@ExpWarehousingCode and RepositoryCode=@ImpRepositoryCode))
		set @iresult =-2
	else
	begin
		declare cur cursor read_only fast_forward
		for select ItemCode,RowIDGumshoe,AmountRealExport from ExportWarehousingDetail where ExpWarehousingCode=@ExpWarehousingCode
		open cur
		fetch next from cur into @ItemCode,@RowIDGumshoe,@AmountRealExport
		while @@FETCH_STATUS = 0
		begin
			update InventoryGumshoe set AmountExport=AmountExport -@AmountRealExport where RowID=@RowIDGumshoe
			update InventoryGeneral set AmountExport=AmountExport -@AmountRealExport,AmountEnd=AmountEnd+@AmountRealExport where ItemCode=@ItemCode and RepositoryCode=@ExpRepositoryCode and Hide = 0
			update InventoryGeneral set AmountImport=AmountImport -@AmountRealExport,AmountEnd=AmountEnd-@AmountRealExport where ItemCode=@ItemCode and RepositoryCode=@ImpRepositoryCode and Hide = 0
			FETCH NEXT FROM cur into @ItemCode,@RowIDGumshoe,@AmountRealExport
		end	 
		CLOSE cur
		DEALLOCATE cur
		
		delete from InventoryGumshoe  where ExpWarehousingCode=@ExpWarehousingCode and RepositoryCode=@ImpRepositoryCode
		delete from ExportWarehousingDetail where ExpWarehousingCode=@ExpWarehousingCode
		delete from ExportWarehousing where ExpWarehousingCode=@ExpWarehousingCode
		set @iresult =1
	end
end
go
--------------------- Kiem tra thuoc truoc khi xoa
if exists(select name from sysobjects where name like'%pro_check_ExportWarehousing%')
	drop procedure pro_check_ExportWarehousing
go
create procedure pro_check_ExportWarehousing
(
	@ExpWarehousingCode varchar(50),
	@iresult int output
)
as
begin
	declare @ItemCode varchar(50)
	declare @RowIDGumshoe numeric(18,0)
	declare @AmountRealExport numeric(18,3)
	declare @ExpRepositoryCode varchar(50)
	declare @ImpRepositoryCode varchar(50)
	
	select @ExpRepositoryCode=ExpRepositoryCode,@ImpRepositoryCode=ImpRepositoryCode from ExportWarehousing where ExpWarehousingCode=@ExpWarehousingCode
	if exists(select ItemCode from RealMedicinesForPatientsDetail where RowIDInventoryGumshoe in(select RowID from InventoryGumshoe  where ExpWarehousingCode=@ExpWarehousingCode and RepositoryCode=@ImpRepositoryCode))
		set @iresult =1
	else if exists(select ItemCode from MedicinesForPatientsDetail where RowIDInventoryGumshoe in(select RowID from InventoryGumshoe  where ExpWarehousingCode=@ExpWarehousingCode and RepositoryCode=@ImpRepositoryCode))
		set @iresult =2
	else if exists (select ItemCode from MedicinesRetailDetail where RowIDInventoryGumshoe in(select RowID from InventoryGumshoe  where ExpWarehousingCode=@ExpWarehousingCode and RepositoryCode=@ImpRepositoryCode))
		set @iresult =3
	else
		set @iresult = 0
end
go
------------------ Table phieu nhap kho [WarehousingDetail]
if exists(select name from sysobjects where name ='pro_Ins_WarehousingDetail' and type='P')
	drop procedure pro_Ins_WarehousingDetail
go
create procedure pro_Ins_WarehousingDetail
(
	@RowID numeric(18,0),
	@WarehousingCode varchar(50),
	@ItemCode varchar(50),
	@Active nvarchar(max),
	@UnitOfMeasureCode varchar(50),
	@Quantity numeric(18,3),
	@UnitPrice numeric(18,3),
	@Amount numeric(18,3),
	@Tax int,
	@Scot numeric(18,3),
	@TotalTax numeric(18,3),
	@SalesPrice numeric(18,3),
	@Shipment nvarchar(250),
	@DateEnd Date,
	--@ProducerCode varchar(50),
	--@Country nvarchar(250),
	@BHYTPrice numeric(18,3),
	@UnitPriceNoVAT numeric(18,3),
	@PerSalesPrice int =0,
	@QtyOfMeasure decimal =0,
	@QuantityInput decimal =0,
	@RowIDOut numeric(18,0) output
)
as
begin
	if exists(select WarehousingCode from WarehousingDetail where RowID=@RowID)
		begin		
			update WarehousingDetail set ItemCode=@ItemCode,Active=@Active,UnitOfMeasureCode=@UnitOfMeasureCode,Quantity=@Quantity,UnitPrice=@UnitPrice,Amount=@Amount,
			Tax=@Tax,Scot=@Scot,TotalTax=@TotalTax,SalesPrice=@SalesPrice,Shipment=@Shipment,DateEnd=@DateEnd,BHYTPrice=@BHYTPrice,UnitPriceNoVAT=@UnitPriceNoVAT,PerSalesPrice=@PerSalesPrice,QtyOfMeasure=@QtyOfMeasure,QuantityInput=@QuantityInput
			where RowID=@RowID
			set @RowIDOut=@RowID
		end
	else
	begin
		insert into WarehousingDetail(WarehousingCode,ItemCode,Active,UnitOfMeasureCode,Quantity,UnitPrice,Amount,Tax,Scot,TotalTax,SalesPrice,Shipment,DateEnd,BHYTPrice,UnitPriceNoVAT,PerSalesPrice,QtyOfMeasure,QuantityInput) values(@WarehousingCode,@ItemCode,@Active,@UnitOfMeasureCode,@Quantity,@UnitPrice,@Amount,@Tax,@Scot,@TotalTax,@SalesPrice,@Shipment,@DateEnd,@BHYTPrice,@UnitPriceNoVAT,@PerSalesPrice,@QtyOfMeasure,@QuantityInput)
		select @RowIDOut=isnull(max(Rowid),0) from  WarehousingDetail where WarehousingCode=@WarehousingCode
	end
end
go
------------------ xoa thong tin [WarehousingDetail]
if exists(select name from sysobjects where name ='pro_Del_WarehousingDetail')
	drop procedure pro_Del_WarehousingDetail
go
create procedure pro_Del_WarehousingDetail
(
	@WarehousingCode varchar(50),
	@iresult int output
)
as
begin
	if exists(select WarehousingCode from Warehousing where WarehousingCode=@WarehousingCode and status =0)
	begin
		---delete from InventoryGumshoe where WarehousingCode=@WarehousingCode
		delete from WarehousingDetail where WarehousingCode=@WarehousingCode
		delete from Warehousing where WarehousingCode=@WarehousingCode
		set @iresult =1
	end
end
go
--declare @test numeric(18,0)
--select @test=Rowid from  WarehousingDetail where RowID=4
--print @test
--select * from  WarehousingDetail where RowID= 4
--select MAX(RowID) RowID from  WarehousingDetail
if exists(select name from sysobjects where name like'%pro_Del_WarehousingDetailForItem%')
	drop procedure pro_Del_WarehousingDetailForItem
go
create procedure pro_Del_WarehousingDetailForItem
(
	@WarehousingCode varchar(50),
	@ItemCode varchar(50),
	@iresult int output
)
as
begin
	if exists(select WarehousingCode from Warehousing where WarehousingCode=@WarehousingCode and status =0)
	begin
		delete from InventoryGumshoe where WarehousingCode=@WarehousingCode and ItemCode=@ItemCode
		delete from WarehousingDetail where WarehousingCode=@WarehousingCode and ItemCode=@ItemCode
		set @iresult = 1
	end
	else
		set @iresult = -1
end
go
------------------ Table theoi ton va gia thuoc
if exists(select name from sysobjects where name ='pro_Ins_InventoryGumshoe')
	drop procedure pro_Ins_InventoryGumshoe
go
create procedure pro_Ins_InventoryGumshoe --02/08/2016 
(
	@DateImport datetime,
	@MM numeric(2,0),
	@YYYY numeric(4,0),
	@ItemCode varchar(50),
	@AmountImport numeric(18,4),
	@WarehousingCode varchar(50),
	@DateEnd date,
	@SalesPrice numeric(18,4),
	@UnitPrice numeric(18,4),
	@Shipment nvarchar(250),
	@RepositoryCode varchar(50),
	@BHYTPrice numeric(18,4),
	@IDWarehousingDetail numeric(18,0)
)
as
begin
	insert into InventoryGumshoe(DateImport,MM,YYYY,ItemCode,AmountImport,WarehousingCode,DateEnd,SalesPrice,UnitPrice,Shipment,RepositoryCode,IDate,BHYTPrice,IDWarehousingDetail) values(@DateImport,@MM,@YYYY,@ItemCode,@AmountImport,@WarehousingCode,@DateEnd,@SalesPrice,@UnitPrice,@Shipment,@RepositoryCode,GETDATE(),@BHYTPrice,@IDWarehousingDetail)	
	if exists(select ItemCode from InventoryGeneral where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode)
		begin
			update InventoryGeneral set AmountImport=AmountImport+@AmountImport,AmountEnd=AmountEnd+@AmountImport where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode
		end
	else
	begin
		insert into InventoryGeneral(ItemCode,RepositoryCode,AmountBegin,AmountImport,IDate,AmountEnd) values(@ItemCode,@RepositoryCode,0,@AmountImport,GETDATE(),@AmountImport)
	end
	if((select [Values] from SystemParameter where RowID = 210) = 1)
	begin
		update Items set SalesPrice=@SalesPrice,BHYTPrice=@BHYTPrice,UnitPrice=@UnitPrice where ItemCode=@ItemCode
	end
	/*
	if exists(select ItemCode from InventoryGeneral where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode  and Hide = 0)
		begin
			update InventoryGeneral set AmountImport=AmountImport+@AmountImport,AmountEnd=AmountEnd+@AmountImport where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Hide = 0
		end
	else
	if exists(select ItemCode from InventoryGeneral where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode  and Hide = 1)
		begin
			update InventoryGeneral set Hide = 0 where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Hide = 1
			update InventoryGeneral set AmountImport=AmountImport+@AmountImport,AmountEnd=AmountEnd+@AmountImport where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Hide = 0
		end
	else
	begin
		insert into InventoryGeneral(ItemCode,RepositoryCode,AmountBegin,AmountImport,IDate,AmountEnd) values(@ItemCode,@RepositoryCode,0,@AmountImport,GETDATE(),@AmountImport)
	end
	--update Items set SalesPrice=@SalesPrice,BHYTPrice=@BHYTPrice,UnitPrice=@UnitPrice where ItemCode=@ItemCode
	*/
end
go
------------------ xoa table thuoc theo doi
if exists(select name from sysobjects where name='pro_Del_GumshoeForHousingCode')
	drop procedure pro_Del_GumshoeForHousingCode
go
create procedure pro_Del_GumshoeForHousingCode
(
	@WarehousingCode varchar(50),
	@RepositoryCode varchar(50),
	@iresult int output
)
as
begin

	if exists(select WarehousingCode from Warehousing where WarehousingCode=@WarehousingCode and RepositoryCode=@RepositoryCode and status =0)
	begin
		declare @ItemCode varchar(50)=''
		declare @AmountImport numeric(18,3)
		declare @RowIDInventory numeric(18,3)=0
		declare cur cursor read_only fast_forward
		for select a.RowID,a.ItemCode,a.AmountImport,a.RepositoryCode from InventoryGumshoe a inner join WarehousingDetail b on a.IDWarehousingDetail=b.RowID where b.WarehousingCode=@WarehousingCode and a.RepositoryCode=@RepositoryCode
		open cur
		fetch next from cur into @RowIDInventory,@ItemCode,@AmountImport,@RepositoryCode
		while @@FETCH_STATUS = 0
		begin
			if exists(select a.ItemCode from MedicinesRetailDetail a inner join MedicinesRetail b on a.RetailCode=b.RetailCode where a.RowIDInventoryGumshoe=@RowIDInventory and a.RepositoryCode=@RepositoryCode and b.Paid=1)
				set @iresult=0
			else if exists(select a.ItemCode from MedicinesForPatientsDetail a inner join MedicinesForPatients b on a.RowIDMedicines=b.RowID where a.RowIDInventoryGumshoe=@RowIDInventory and a.RepositoryCode=@RepositoryCode)
				set @iresult=0
			else if exists(select a.ItemCode from ExportWarehousingDetail a inner join ExportWarehousing b on a.ExpWarehousingCode=b.ExpWarehousingCode where a.RowIDGumshoe=@RowIDInventory and a.RepositoryExportCode=@RepositoryCode)
				set @iresult=0
			else
			begin
				delete from InventoryGumshoe where RowID=@RowIDInventory and ItemCode=@ItemCode and RepositoryCode=@RepositoryCode
				update InventoryGeneral set AmountImport=AmountImport -@AmountImport,AmountEnd=AmountEnd-@AmountImport where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Hide = 0
				set @iresult=1
			end
			FETCH NEXT FROM cur into @RowIDInventory,@ItemCode,@AmountImport,@RepositoryCode
		end
		CLOSE cur
		DEALLOCATE cur
	end
	--if exists(select WarehousingCode from Warehousing where WarehousingCode=@WarehousingCode and status =0)
	--begin
	--	if exists(select ItemCode from InventoryGumshoe where WarehousingCode=@WarehousingCode and (ExpWarehousingCode is null or ExpWarehousingCode=''))
	--	begin
	--		delete from InventoryGumshoe where WarehousingCode=@WarehousingCode and (ExpWarehousingCode is null or ExpWarehousingCode='')
	--		set @iresult =1
	--	end
	--	else
	--		set @iresult=-2
	--end
end
go
------------------ Table khai bao ton kho InventoryGeneral
if exists(select name from sysobjects where name ='pro_Ins_InventoryGeneral')
	drop procedure pro_Ins_InventoryGeneral
go
create procedure pro_Ins_InventoryGeneral
(
	@ItemCode varchar(50),
	@RepositoryCodeExport varchar(50),
	@RepositoryCodeReceived varchar(50),
	@WarehousingCode varchar(50),
	@AmountImport numeric(18,3)
)
as
begin
	if exists(select ItemCode from InventoryGeneral where ItemCode=@ItemCode and RepositoryCode=@RepositoryCodeReceived and Hide = 0)
		begin
			update InventoryGeneral set AmountImport=AmountImport+@AmountImport,AmountEnd=AmountEnd+@AmountImport where ItemCode=@ItemCode and RepositoryCode=@RepositoryCodeReceived  and Hide = 0
			update InventoryGeneral set AmountExport=AmountExport+@AmountImport,AmountEnd=AmountEnd-@AmountImport where ItemCode=@ItemCode and RepositoryCode=@RepositoryCodeExport  and Hide = 0
		end
	else
	begin
		insert into InventoryGeneral(ItemCode,RepositoryCode,AmountImport,IDate,AmountEnd,AmountVirtual,AmountBegin) values(@ItemCode,@RepositoryCodeReceived,@AmountImport,GETDATE(),@AmountImport,0,0)
		update InventoryGeneral set AmountExport=AmountExport+@AmountImport,AmountEnd=AmountEnd-@AmountImport where ItemCode=@ItemCode and RepositoryCode=@RepositoryCodeExport  and Hide = 0
	end
end
--select * from ExportWarehousingDetail
---exec pro_Ins_InventoryGeneral 'TH000002','KHO001','KHO004','PN000000000001',200
--select ItemCode from InventoryGeneral where ItemCode='TH000002' and RepositoryCode='KHO004'
go
if exists(select name from sysobjects where name ='pro_Del_InventoryGeneral')
	drop procedure pro_Del_InventoryGeneral
go
create procedure pro_Del_InventoryGeneral
(
	@ItemCode varchar(50),
	--@MM numeric(2,0),
	--@YYYY numeric(4,0),
	@RepositoryCodeExport varchar(50),
	@RepositoryCodeReceived varchar(50),
	@WarehousingCode varchar(50),
	@AmountImport numeric(18,3)
)
as
begin
	if exists(select ItemCode from InventoryGeneral where ItemCode=@ItemCode and RepositoryCode=@RepositoryCodeReceived  and Hide = 0)
		begin
			update InventoryGeneral set AmountImport=AmountImport+@AmountImport,AmountEnd=AmountEnd+@AmountImport where ItemCode=@ItemCode and RepositoryCode=@RepositoryCodeReceived  and Hide = 0
			update InventoryGumshoe set AmountExport=AmountExport+@AmountImport where ItemCode=@ItemCode and RepositoryCode=@RepositoryCodeExport and WarehousingCode=@WarehousingCode
			delete from InventoryGumshoe where ItemCode=@ItemCode and RepositoryCode=@RepositoryCodeReceived and WarehousingCode=@WarehousingCode
		end
	else
	begin
		insert into InventoryGeneral(ItemCode,RepositoryCode,AmountBegin,AmountImport,IDate,AmountEnd) values(@ItemCode,@RepositoryCodeReceived,0,@AmountImport,GETDATE(),@AmountImport) 
		update InventoryGumshoe set AmountExport=AmountExport+@AmountImport where ItemCode=@ItemCode and RepositoryCode=@RepositoryCodeExport and WarehousingCode=@WarehousingCode
		delete from InventoryGumshoe where ItemCode=@ItemCode and RepositoryCode=@RepositoryCodeReceived and WarehousingCode=@WarehousingCode
	end
end
go
if exists(select name from sysobjects where name ='pro_Upd_InventoryWareHousing')
	drop procedure pro_Upd_InventoryWareHousing
go
create procedure pro_Upd_InventoryWareHousing
(
	@ItemCode varchar(50),
	--@MM numeric(2,0),
	--@YYYY numeric(4,0),
	@RepositoryCodeExport varchar(50),
	@RepositoryCodeReceived varchar(50),
	@WarehousingCode varchar(50),
	@AmountImport numeric(18,3)
)
as
begin
	if exists(select ItemCode from InventoryGeneral where ItemCode=@ItemCode and RepositoryCode=@RepositoryCodeReceived  and Hide = 0)
		begin
			update InventoryGeneral set AmountImport=AmountImport+@AmountImport,AmountEnd=AmountEnd+@AmountImport where ItemCode=@ItemCode and RepositoryCode=@RepositoryCodeReceived and Hide = 0
		end
	else
	begin
		insert into InventoryGeneral(ItemCode,RepositoryCode,AmountBegin,AmountImport,IDate,AmountEnd) values(@ItemCode,@RepositoryCodeReceived,0,@AmountImport,GETDATE(),@AmountImport)
	end
end
go
----------------------------------- Thong so he thong
------------------------------------ Table hen [PatientAppointment]
if exists(select name from sysobjects where name ='pro_Ins_SystemParameter')
	drop procedure pro_Ins_SystemParameter
go
create procedure pro_Ins_SystemParameter
(
	@RowID numeric(18,0),
	@Module varchar(50),
	@Name nvarchar(250),
	@Values int,
	@Description varchar(250),
	@EmployeeCode varchar(15),
	@VersionNo varchar(20)
)
as
begin
	if exists(select RowID from SystemParameter where RowID=@RowID)
		begin		
			update SystemParameter set Module=@Module,Name=@Name,[Values]=@Values,[Description]=@Description,UDate=GETDATE(),VersionNo=@VersionNo,EmployeeCode=@EmployeeCode
			where RowID=@RowID
		end
	else
	begin
		insert into SystemParameter(RowID,Module,Name,[Values],[Description],IDate,UDate,VersionNo,EmployeeCode)
		values(@RowID,@Module,@Name,@Values,@Description,GETDATE(),GETDATE(),@VersionNo,@EmployeeCode)
	end
end
go
---------------------------------- Table duyet thuoc
if exists(select name from sysobjects where name like'%pro_Ins_MedicinesForPatients%')
	drop procedure pro_Ins_MedicinesForPatients
go
create procedure pro_Ins_MedicinesForPatients
(
	@MedicalRecordCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(50),
	@EmployeeCode varchar(50),
	@MM numeric(18,0),
	@YYYY numeric(18,0),
	@ObjectCode int,
	@RowID decimal(18,0),
	@ShiftWork char(2),
	@OutRowID decimal(18,0) output
)
as
begin
	if exists(select MedicalRecordCode from MedicinesForPatients where RowID=@RowID)
		begin		
			update MedicinesForPatients set EmployeeCode=@EmployeeCode,MM=@MM,YYYY=@YYYY,DateApproved=getdate(),ShiftWork=@ShiftWork where MedicalRecordCode=@MedicalRecordCode and PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode
			update MedicalRecord set Status=1 where MedicalRecordCode=@MedicalRecordCode
			select @OutRowID=ISNULL(max(rowid),0) from MedicinesForPatients where MedicalRecordCode=@MedicalRecordCode
		end
	else
	begin
		insert into MedicinesForPatients(MedicalRecordCode,PatientReceiveID,PatientCode,MM,YYYY,DateApproved,ObjectCode,EmployeeCode,ShiftWork)
		values(@MedicalRecordCode,@PatientReceiveID,@PatientCode,@MM,@YYYY,getdate(),@ObjectCode,@EmployeeCode,@ShiftWork)
		update MedicalRecord set Status=1 where MedicalRecordCode=@MedicalRecordCode
		select @OutRowID=ISNULL(max(rowid),0) from MedicinesForPatients where MedicalRecordCode=@MedicalRecordCode
	end
end
go
-- exec pro_Ins_MedicinesForPatients 'BA000000000001',63,'BN00000001','NV00001',5,2014,1
if exists(select name from sysobjects where name ='pro_Del_MedicinesForPatients' and type='P')
	drop procedure pro_Del_MedicinesForPatients
go
create procedure pro_Del_MedicinesForPatients
(
	@MedicalRecordCode varchar(50),
	@RowID decimal(18,0),
	@EmployeeCode varchar(50),
	@Result int out
)
as
begin
	declare @ItemCode varchar(50)
	declare @Quantity numeric(18,2)
	declare @MM numeric(18,0)
	declare @YYYY numeric(18,0)
	declare @RowIDGumshoe numeric(18,0)
	declare @RowIDMedicalPrescription numeric(18,0)
	declare @RepositoryCode varchar(50)
	declare @EmployeeGroupID int =(select EmployeeGroupID from Employee where EmployeeCode=@EmployeeCode)
	if exists(select PatientCode from MedicinesForPatients where RowID=@RowID and Done=0)
	begin
		if exists(select PatientCode from MedicinesForPatients where RowID=@RowID and (EmployeeCode=@EmployeeCode or @EmployeeGroupID=-9999))
		begin
			if exists(select MedicalRecordCode from MedicalRecord where MedicalRecordCode=@MedicalRecordCode and Paid=0)
		begin
			select @MM=MM,@YYYY=YYYY from MedicinesForPatients where MedicalRecordCode=@MedicalRecordCode
			declare cur cursor read_only fast_forward
			for select ItemCode,Quantity,RepositoryCode,RowIDInventoryGumshoe,RowIDMedicalPrescription from MedicinesForPatientsDetail where MedicalRecordCode=@MedicalRecordCode and RowIDMedicines=@RowID
			open cur
			fetch next from cur into @ItemCode,@Quantity,@RepositoryCode,@RowIDGumshoe,@RowIDMedicalPrescription
			while @@FETCH_STATUS = 0
			begin
				update InventoryGumshoe set AmountExport=AmountExport-@Quantity where RowID=@RowIDGumshoe
				update InventoryGeneral set AmountExport=AmountExport-@Quantity, AmountVirtual=AmountVirtual+@Quantity,AmountEnd=AmountEnd+@Quantity where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Hide = 0
				update MedicalPrescriptionDetail set Status=0 where RowID=@RowIDMedicalPrescription
				FETCH NEXT FROM cur into @ItemCode,@Quantity,@RepositoryCode,@RowIDGumshoe,@RowIDMedicalPrescription
			end	 
			CLOSE cur
			DEALLOCATE cur
			
			delete from MedicinesForPatientsDetail where MedicalRecordCode=@MedicalRecordCode and RowIDMedicines=@RowID
			delete from MedicinesForPatients where MedicalRecordCode=@MedicalRecordCode and RowID=@RowID
			if not exists (select ItemCode from MedicalPrescriptionDetail where MedicalRecordCode=@MedicalRecordCode and Status=1)
				update MedicalRecord set Status=0 where MedicalRecordCode=@MedicalRecordCode
			set @Result =1 -- xoa thanh cong
		end
	else
	begin
		set @Result = -1 -- da thanh toan
	end
		end
		else
			set @Result =-3
	end
	else
		set @Result =-2
end
go
if exists(select name from sysobjects where name like'%proUpd_MedicinesForPatients%')
	drop procedure proUpd_MedicinesForPatients
go
create procedure proUpd_MedicinesForPatients
(
	@MedicalRecordCode varchar(50),
	@RowID decimal(18,0),
	@EmployeeCodeDone varchar(20),
	@Done int=0,
	@PatientReceiveID numeric(18,0),
	@Result int out
)
as
begin
	--if exists(select PatientReceiveID from PatientReceive where PatientReceiveID=@PatientReceiveID and Status=2)
	--	set @Result =-2
	--else 
	if exists(select MedicalRecordCode from MedicinesForPatients where RowID=@RowID and (EmployeeCodeDone=@EmployeeCodeDone or EmployeeCodeDone is null))
		begin		
			update MedicinesForPatients set Done = @Done where RowID=@RowID
			set @Result =1
		end
	else
		set @Result =-1
end
go
if exists(select name from sysobjects where name like'%pro_Ins_MedicinesForPatientsDetail%')
	drop procedure pro_Ins_MedicinesForPatientsDetail
go
create procedure pro_Ins_MedicinesForPatientsDetail
(
	@MedicalRecordCode varchar(50),
	@ItemCode varchar(50),
	@DateOfIssues int,
	@Quantity numeric(18,2),
	@UnitPrice numeric(18,4),
	@SalesPrice numeric(18,4),
	@BHYTPrice numeric(18,4),
	@Amount numeric(18,4),
	@RowIDInventoryGumshoe numeric(18,0),
	@RateBHYT numeric(18,0),
	@ObjectCode int,
	@RepositoryCode varchar(50),
	@QuantityExport numeric(18,2),
	@RowIDMedicines decimal(18,0),
	@RowIDMedicalPrescription decimal(18,0)
)
as
begin
	insert into MedicinesForPatientsDetail(MedicalRecordCode,ItemCode,DateOfIssues,Quantity,UnitPrice,SalesPrice,BHYTPrice,Amount,IDate,RowIDInventoryGumshoe,RateBHYT,ObjectCode,RepositoryCode,QuantityExport,RowIDMedicines,RowIDMedicalPrescription)
	values(@MedicalRecordCode,@ItemCode,@DateOfIssues,@Quantity,@UnitPrice,@SalesPrice,@BHYTPrice,@Amount,getdate(),@RowIDInventoryGumshoe,@RateBHYT,@ObjectCode,@RepositoryCode,@QuantityExport,@RowIDMedicines,@RowIDMedicalPrescription)
	update MedicalPrescriptionDetail set Status=1 where RowID = @RowIDMedicalPrescription
	update InventoryGumshoe set AmountExport=AmountExport+@QuantityExport where RowID=@RowIDInventoryGumshoe
	update InventoryGeneral set AmountExport=AmountExport+@QuantityExport, AmountVirtual=AmountVirtual-@QuantityExport,AmountEnd=AmountEnd-@QuantityExport where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Hide = 0
end
go
----------------------------------Khai bao tu dien viet tat
if exists(select name from sysobjects where name ='pro_Ins_DiagnosisAbbreviations' and type='P')
	drop procedure pro_Ins_DiagnosisAbbreviations
go
create procedure pro_Ins_DiagnosisAbbreviations
(
	@RowID int,
	@CharacterCode varchar(50),
	@CharacterName nvarchar(max),
	@EmployeeCode varchar(10)
)
as
begin
	if exists(select CharacterCode from DiagnosisAbbreviations where CharacterCode=@CharacterCode and EmployeeCode=@EmployeeCode)
	begin
		update DiagnosisAbbreviations set CharacterName=@CharacterName where CharacterCode=@CharacterCode and EmployeeCode=@EmployeeCode
	end
	else
	begin
		insert into DiagnosisAbbreviations(CharacterCode,CharacterName,EmployeeCode) values(@CharacterCode,@CharacterName,@EmployeeCode)
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_DiagnosisAbbreviations%')
	drop procedure pro_Del_DiagnosisAbbreviations
go
create procedure pro_Del_DiagnosisAbbreviations
(
	@RowID int,
	@iresult int output
)
as
begin
	begin
		delete DiagnosisAbbreviations where RowID=@RowID
		set @iresult =1
	end
end
go
---------------------------------- Khai bao mau mo ta [TemplateDescription]
if exists(select name from sysobjects where name='pro_Ins_TemplateDescription')
	drop procedure pro_Ins_TemplateDescription
go
create procedure pro_Ins_TemplateDescription
(
	@TemplateHeaderCode varchar(50),
	@TemplateHeaderName nvarchar(max),
	@Apply int,
	@Contents nvarchar(max),
	@Conclusion nvarchar(max),
	@Proposal nvarchar(max),
	@EmployeeCode varchar(50),
	@ServiceCode varchar(50),
	@EmployeeDoctorCode varchar(15)='',
	@PrintPaper varchar(10),
	@ServiceMenuID int
	,@ResultCode  varchar(50) output
)
as
begin
	if exists(select TemplateHeaderCode from TemplateDescription where TemplateHeaderCode=@TemplateHeaderCode)
	begin
		update TemplateDescription set TemplateHeaderName=@TemplateHeaderName,[Apply]=@Apply,Contents=@Contents,Conclusion=@Conclusion,Proposal=@Proposal,EmployeeCode=@EmployeeCode,ServiceCode=@ServiceCode,EmployeeDoctorCode=@EmployeeDoctorCode,PrintPaper=@PrintPaper,ServiceMenuID=@ServiceMenuID where TemplateHeaderCode=@TemplateHeaderCode
		set @ResultCode =@TemplateHeaderCode
	end
	else
	begin
		declare @_Code varchar(50)
		declare @_stt decimal(18,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(TemplateHeaderCode,7)) maxcode from TemplateDescription order by RowID desc)+1
		if(@_stt<=9)
			begin
				set @_Code = 'MAU000000'+convert(varchar(50),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_Code = 'MAU00000'+convert(varchar(50),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_Code = 'MAU0000'+convert(varchar(50),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_Code = 'MAU000'+convert(varchar(50),@_stt)
			end
		else if(@_stt>9999 and @_stt<=99999)
			begin
				set @_Code = 'MAU00'+convert(varchar(50),@_stt)
			end
		else if(@_stt>99999 and @_stt<=999999)
			begin
				set @_Code = 'MAU0'+convert(varchar(50),@_stt)
			end
		else if(@_stt>999999 and @_stt<=9999999)
			begin
				set @_Code = 'MAU'+convert(varchar(50),@_stt)
			end
		else
			begin
				set @_Code = 'MAU0000001'
			end
		insert into TemplateDescription(TemplateHeaderCode,TemplateHeaderName,[Apply],Contents,Conclusion,Proposal,EmployeeCode,ServiceCode,EmployeeDoctorCode,PrintPaper,ServiceMenuID) 
		values(@_Code,@TemplateHeaderName,@Apply,@Contents,@Conclusion,@Proposal,@EmployeeCode,@ServiceCode,@EmployeeDoctorCode,@PrintPaper,@ServiceMenuID)
		set @ResultCode =@_Code 
	end
end
go
if exists(select name from sysobjects where name ='pro_Del_TemplateDescription')
	drop procedure pro_Del_TemplateDescription
go
create procedure pro_Del_TemplateDescription
(
	@TemplateHeaderCode varchar(50),
	@iresult int output
)
as
begin
	delete TemplateDescription where TemplateHeaderCode=@TemplateHeaderCode
	set @iresult =1
end
go
--------------------------- Xet Nghiem Don Vi Do
if exists(select name from sysobjects where name like'%pro_Ins_UnitValues%')
	drop procedure pro_Ins_UnitValues
go
create procedure pro_Ins_UnitValues
(
	@RowID int,
	@UnitValuesName nvarchar(250)
)
as
begin
	if exists(select RowID from UnitValues where RowID=@RowID)
	begin
		update UnitValues set UnitValuesName=@UnitValuesName where RowID=@RowID
	end
	else
	begin
		insert into UnitValues(UnitValuesName) values(@UnitValuesName)
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_UnitValues%')
	drop procedure pro_Del_UnitValues
go
create procedure pro_Del_UnitValues
(
	@RowID int,
	@iresult int output
)
as
begin
	delete UnitValues where RowID=@RowID
	set @iresult =1
end
go
if exists(select name from sysobjects where name ='pro_Ins_LaboratoryPackage')
	drop procedure pro_Ins_LaboratoryPackage
go
create procedure pro_Ins_LaboratoryPackage
(
	@LaboratoryPackageCode varchar(50)='',
	@EmployeeCode varchar(50)='',
	@ServiceCode varchar(20)='',
	@LaboratoryPackageName nvarchar(1000)='',
	@TypeResult int,
	@TemplateHeaderCode nvarchar(50)='',
	@resultCode varchar(50) output
)
as
begin tran
	if exists(select LaboratoryPackageCode from LaboratoryPackage where LaboratoryPackageCode=@LaboratoryPackageCode)
	begin
		update LaboratoryPackage set EmployeeCode=@EmployeeCode,IDate=GETDATE(),ServiceCode=@ServiceCode,LaboratoryPackageName=@LaboratoryPackageName,TypeResult=@TypeResult,TemplateHeaderCode=@TemplateHeaderCode where LaboratoryPackageCode=@LaboratoryPackageCode
		set @resultCode=@LaboratoryPackageCode
	end
	else
	begin
		declare @_PackageCodeTemp varchar(20)
		declare @_stt decimal(18,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(LaboratoryPackageCode,6)) maxcode from LaboratoryPackage order by CONVERT(decimal(18,0),RIGHT(LaboratoryPackageCode,6)) desc)+1
		if(@_stt<=9)
			begin
				set @_PackageCodeTemp = 'LP00000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_PackageCodeTemp = 'LP0000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_PackageCodeTemp = 'LP000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_PackageCodeTemp = 'LP00'+convert(varchar(10),@_stt)
			end
		else if(@_stt>9999 and @_stt<=99999)
			begin
				set @_PackageCodeTemp = 'LP0'+convert(varchar(10),@_stt)
			end
		else if(@_stt>99999 and @_stt<=999999)
			begin
				set @_PackageCodeTemp = 'LP'+convert(varchar(10),@_stt)
			end
		else
			begin
				set @_PackageCodeTemp = 'LP000001'
			end
		insert into LaboratoryPackage(LaboratoryPackageCode,EmployeeCode,IDate,ServiceCode,LaboratoryPackageName,TypeResult,TemplateHeaderCode) values(@_PackageCodeTemp,@EmployeeCode,GETDATE(),@ServiceCode,@LaboratoryPackageName,@TypeResult,@TemplateHeaderCode)
		set @resultCode=@_PackageCodeTemp
	end
commit
go
if exists(select name from sysobjects where name ='pro_Del_LaboratoryPackage')
	drop procedure pro_Del_LaboratoryPackage
go
create procedure pro_Del_LaboratoryPackage
(
	@LaboratoryPackageCode varchar(50),
	@iresult int output
)
as
begin
	if exists(select LaboratoryPackageCode from LaboratoryPackage where LaboratoryPackageCode=@LaboratoryPackageCode)
	begin
		delete from LaboratoryPackageDetail where LaboratoryPackageCode=@LaboratoryPackageCode
		delete from LaboratoryPackage where LaboratoryPackageCode=@LaboratoryPackageCode
		set @iresult =1
	end
	else
		set @iresult =0	
end
go
if exists(select name from sysobjects where name ='pro_Ins_LaboratoryPackageDetail')
	drop procedure pro_Ins_LaboratoryPackageDetail
go
create procedure pro_Ins_LaboratoryPackageDetail
(
	@RowID int,
	@LaboratoryPackageCode varchar(50),
	@LaboratoryName nvarchar(max),
	@UnitValues nvarchar(50),
	@ValuedFemale nvarchar(50),
	@ValuedMale nvarchar(50),
	@MinValuedFemale numeric(18,5),
	@MaxValuedFemale numeric(18,5),
	@MinValuedMale numeric(18,5),
	@MaxValuedMale numeric(18,5),
	@STT int,
	@ParameterMachine varchar(50),
	@ValuesEntry nvarchar(50)
)
as
begin
	if(@STT = 0)
		set @STT=(select (ISNULL(MAX(STT),0)+1) STT from LaboratoryPackageDetail where LaboratoryPackageCode=@LaboratoryPackageCode)
	if exists(select RowID from LaboratoryPackageDetail where RowID=@RowID and LaboratoryPackageCode=@LaboratoryPackageCode)
	begin
		update LaboratoryPackageDetail set LaboratoryPackageCode=@LaboratoryPackageCode,LaboratoryName=@LaboratoryName,UnitValues=@UnitValues,ValuedFemale=@ValuedFemale,ValuedMale=@ValuedMale,MinValuedFemale=@MinValuedFemale,MaxValuedFemale=@MaxValuedFemale,MinValuedMale=@MinValuedMale,MaxValuedMale=@MaxValuedMale,STT=@STT,ParameterMachine=@ParameterMachine,ValuesEntry=@ValuesEntry where RowID=@RowID and LaboratoryPackageCode=@LaboratoryPackageCode
	end
	else
	begin
		insert into LaboratoryPackageDetail(LaboratoryPackageCode,LaboratoryName,UnitValues,ValuedFemale,ValuedMale,MinValuedFemale,MaxValuedFemale,MinValuedMale,MaxValuedMale,STT,ParameterMachine,ValuesEntry) values(@LaboratoryPackageCode,@LaboratoryName,@UnitValues,@ValuedFemale,@ValuedMale,@MinValuedFemale,@MaxValuedFemale,@MinValuedMale,@MaxValuedMale,@STT,@ParameterMachine,@ValuesEntry)
	end
end
go
if exists(select name from sysobjects where name ='pro_Del_LaboratoryPackageDetail')
	drop procedure pro_Del_LaboratoryPackageDetail
go
create procedure pro_Del_LaboratoryPackageDetail
(
	@RowID int,
	@LaboratoryPackageCode varchar(50),
	@iresult int output
)
as
begin
	if exists(select RowID from LaboratoryPackageDetail where RowID=@RowID and LaboratoryPackageCode=@LaboratoryPackageCode)
	begin
		delete LaboratoryPackageDetail where RowID=@RowID and LaboratoryPackageCode=@LaboratoryPackageCode
		set @iresult =1
	end
	else
		set @iresult =0
end
go
--------------------------- Xet Nghiem Thong so [Laboratory]
if exists(select name from sysobjects where name ='pro_Ins_Laboratory')
	drop procedure pro_Ins_Laboratory
go
create procedure pro_Ins_Laboratory
(
	@RowID int,
	@LaboratoryName nvarchar(250)
)
as
begin
	if exists(select RowID from Laboratory where RowID=@RowID)
	begin
		update Laboratory set LaboratoryName=@LaboratoryName where RowID=@RowID
	end
	else
	begin
		insert into Laboratory(LaboratoryName) values(@LaboratoryName)
	end
end
go
if exists(select name from sysobjects where name ='pro_Del_Laboratory')
	drop procedure pro_Del_Laboratory
go
create procedure pro_Del_Laboratory
(
	@RowID int,
	@iresult int output
)
as
begin
	delete Laboratory where RowID=@RowID
	set @iresult =1
end
go
------------------ Table CLS [ServiceRadiologyEntry] and [ServiceRadiologyDetailEntry]
if exists(select name from sysobjects where name ='pro_Ins_ServiceRadiologyEntry')
	drop procedure pro_Ins_ServiceRadiologyEntry
go
create procedure pro_Ins_ServiceRadiologyEntry
(
	@ServiceCode varchar(50),
	@PatientCode varchar(50),
	@ReferenceCode varchar(50),
	@AppointmentDate datetime,
	@AppointmentNote nvarchar(max),
	@Contents nvarchar(max),
	@Conclusion nvarchar(max),
	@Proposal nvarchar(max),
	@PostingDate datetime,
	@PatientReceiveID numeric(18,0),
	@Done int,
	@EmployeeCode varchar(50),
	@SuggestedID numeric(18,0),
	@ResultRowID numeric(18,0) output,
	@EmployeeCodeDoctor varchar(50),
	@ServiceGroupCode varchar(50)='CDHA',
	@ShiftWork char(2),
	@Note nvarchar(200)
)
as
begin
	if exists(select RowID from ServiceRadiologyEntry where SuggestedID=@SuggestedID)
		begin		
			update ServiceRadiologyEntry set ServiceCode=@ServiceCode,PatientCode=@PatientCode,ReferenceCode=@ReferenceCode,AppointmentDate=@AppointmentDate,
			AppointmentNote=@AppointmentNote,Contents=@Contents,Conclusion=@Conclusion,Proposal=@Proposal,PostingDate=GETDATE(),PatientReceiveID=@PatientReceiveID,
			Done=@Done,EmployeeCode=@EmployeeCode,SuggestedID=@SuggestedID,EmployeeCodeDoctor=@EmployeeCodeDoctor,Note=@Note where SuggestedID=@SuggestedID and ServiceGroupCode=@ServiceGroupCode
			select top(1) @ResultRowID=RowID from ServiceRadiologyEntry where SuggestedID=@SuggestedID order by RowID desc
		end
	else
	begin
		insert into ServiceRadiologyEntry(ServiceCode,PatientCode,ReferenceCode,AppointmentDate,AppointmentNote,Contents,Conclusion,Proposal,PostingDate,PatientReceiveID,Done,EmployeeCode,SuggestedID,EmployeeCodeDoctor,ServiceGroupCode,ShiftWork,Note) 
		values(@ServiceCode,@PatientCode,@ReferenceCode,@AppointmentDate,@AppointmentNote,@Contents,@Conclusion,@Proposal,@PostingDate,@PatientReceiveID,@Done,@EmployeeCode,@SuggestedID,@EmployeeCodeDoctor,@ServiceGroupCode,@ShiftWork,@Note)
		select top(1) @ResultRowID=RowID from ServiceRadiologyEntry where SuggestedID=@SuggestedID order by RowID desc
	end
	update SuggestedServiceReceipt set Status=1 where ReceiptID=@SuggestedID
end
go
if exists(select name from sysobjects where name ='pro_Ins_ServiceRadiologyDetailEntry')
	drop procedure pro_Ins_ServiceRadiologyDetailEntry
go
create procedure pro_Ins_ServiceRadiologyDetailEntry
(
	@RadiologyRowID numeric(18,0),
	@Image image,
	@PostingDate datetime,
	@Status int,
	@Checked bit
)
as
begin
	--if @Status=1
		--delete from ServiceRadiologyDetailEntry where RadiologyRowID=@RadiologyRowID
	insert into ServiceRadiologyDetailEntry(RadiologyRowID,Image,PostingDate,Checked) values(@RadiologyRowID,@Image,GETDATE(),@Checked)
	
end
go
--------------------------------- Xóa ket qua thuc hien cls
if exists(select name from sysobjects where name ='pro_Del_ServiceRadiologyEntry')
	drop procedure pro_Del_ServiceRadiologyEntry
go
create procedure pro_Del_ServiceRadiologyEntry
(
	@SuggestedID numeric(18,0),
	@Result int output
)
as
begin
	declare @RowID decimal(18,0)
	if exists(select RowID from ServiceRadiologyEntry where SuggestedID=@SuggestedID)
		begin
			select @RowID=RowID from ServiceRadiologyEntry where SuggestedID=@SuggestedID
			delete from ServiceRadiologyDetailEntry where RadiologyRowID=@RowID
			delete from ServiceRadiologyEntry where RowID=@RowID
			update SuggestedServiceReceipt set Status = 0 where ReceiptID=@SuggestedID
			set @Result =1
		end
	else
		begin
			set @Result =-1
		end
end
go
--------------------------------- Thong tin phong kham [ClinicInformation]
if exists(select name from sysobjects where name ='pro_Ins_ClinicInformation')
	drop procedure pro_Ins_ClinicInformation
go
create procedure pro_Ins_ClinicInformation
(
	@ClinicCode int,
	@ClinicName nvarchar(max),
	@ClinicAddress nvarchar(max),
	@Province nvarchar(max),
	@Phone varchar(50),
	@Mobile varchar(50),
	@Doctor nvarchar(250),
	@WorkingDateLine01 nvarchar(max),
	@WorkingDateLine02 nvarchar(max),
	@WorkingDateLine03 nvarchar(max),
	@KCBBDCode varchar(50),
	@WorkingTimeLineFrom01 char(5),
	@WorkingTimeLineTo01 char(5),
	@WorkingTimeLineFrom02 char(5),
	@WorkingTimeLineTo02 char(5),
	@WorkingTimeLineFrom03 char(5),
	@WorkingTimeLineTo03 char(5),
	@PK247Code varchar(50),
	@UserName_BV nvarchar(20)='',
	@PassWord_BV varchar(50)='',
	@UserName_TC nvarchar(20)='',
	@PassWord_TC varchar(50)=''
)
as
begin
	if exists (select ClinicCode from ClinicInformation where ClinicCode=@ClinicCode) 
	begin
		update ClinicInformation set ClinicName=@ClinicName,ClinicAddress=@ClinicAddress,Province=@Province,Phone=@Phone,Mobile=@Mobile,Doctor=@Doctor,WorkingDateLine01=@WorkingDateLine01,WorkingDateLine02=@WorkingDateLine02,WorkingDateLine03=@WorkingDateLine03,KCBBDCode=@KCBBDCode,WorkingTimeLineFrom01=@WorkingTimeLineFrom01,WorkingTimeLineTo01=@WorkingTimeLineTo01,WorkingTimeLineFrom02=@WorkingTimeLineFrom02,WorkingTimeLineTo02=@WorkingTimeLineTo02,WorkingTimeLineFrom03=@WorkingTimeLineFrom03,WorkingTimeLineTo03=@WorkingTimeLineTo03,PK247Code=@PK247Code,UserName_BV=@UserName_BV,PassWord_BV=@PassWord_BV,UserName_TC=@UserName_TC,PassWord_TC=@PassWord_TC
		where ClinicCode=@ClinicCode 
	end
	else
	begin
		insert into ClinicInformation(ClinicCode,ClinicName,ClinicAddress,Province,Phone,Mobile,Doctor,WorkingDateLine01,WorkingDateLine02,WorkingDateLine03,KCBBDCode,WorkingTimeLineFrom01,WorkingTimeLineTo01,WorkingTimeLineFrom02,WorkingTimeLineTo02,WorkingTimeLineFrom03,WorkingTimeLineTo03,PK247Code,UserName_BV,PassWord_BV,UserName_TC,PassWord_TC) 
		values(@ClinicCode,@ClinicName,@ClinicAddress,@Province,@Phone,@Mobile,@Doctor,@WorkingDateLine01,@WorkingDateLine02,@WorkingDateLine03,@KCBBDCode,@WorkingTimeLineFrom01,@WorkingTimeLineTo01,@WorkingTimeLineFrom02,@WorkingTimeLineTo02,@WorkingTimeLineFrom03,@WorkingTimeLineTo03,@PK247Code,@UserName_BV,@PassWord_BV,@UserName_TC,@PassWord_TC)
	end
end
go
------------------ Table CLS [ServiceLaboratoryEntry] and [ServiceLaboratoryDetail]
if exists(select name from sysobjects where name ='pro_Ins_ServiceLaboratoryEntry')
	drop procedure pro_Ins_ServiceLaboratoryEntry
go
create procedure pro_Ins_ServiceLaboratoryEntry
(
	@RowID numeric(18,0),
	@PatientCode varchar(50),
	@ReferenceCode varchar(50),
	@Conclusion nvarchar(max),
	@Proposal nvarchar(max),
	@PostingDate datetime,
	@PatientReceiveID numeric(18,0),
	@ServiceCategoryCode varchar(50),
	@Status int,
	@EmployeeCode varchar(50),
	@ObjectCode int,
	@STT varchar(10),
	@DepartmentCodeOrder varchar(10),
	@LabPathologicalID int,
	@OrderDate varchar(20),
	@EmployeeCodeOrder varchar(20),
	@EmployeeDoctorCodeOrder varchar(20),
	@ShiftWork char(2),
	@IDMachine int,
	@DepartmentCode varchar(10)='',
	@EmployeeCodeDoctor varchar(20),
	@ResultRowID numeric(18,0) output
)
as
begin tran
	if exists(select RowID from ServiceLaboratoryEntry where RowID=@RowID)
		begin
			update ServiceLaboratoryEntry set ReferenceCode=@ReferenceCode,Conclusion=@Conclusion,Proposal=@Proposal,PatientReceiveID=@PatientReceiveID,ServiceCategoryCode=@ServiceCategoryCode,STT=@STT,Status=@Status,EmployeeCode=@EmployeeCode,ObjectCode=@ObjectCode,
			PostingDateResult=(CONVERT(char(10),GETDATE(),103)+' '+ convert(char(8),sysdatetime(),108)),DepartmentCodeOrder=@DepartmentCodeOrder,LabPathologicalID=@LabPathologicalID,OrderDate=@OrderDate,EmployeeCodeOrder=@EmployeeCodeOrder,EmployeeDoctorCodeOrder=@EmployeeDoctorCodeOrder,ShiftWork=@ShiftWork,IDMachine=@IDMachine,DepartmentCode=@DepartmentCode,EmployeeCodeDoctor=@EmployeeCodeDoctor
			where RowID=@RowID
			set @ResultRowID = @RowID
		end
	else
	begin
		insert into ServiceLaboratoryEntry(PatientCode,ReferenceCode,Conclusion,Proposal,PostingDate,PatientReceiveID,ServiceCategoryCode,STT,Status,EmployeeCode,ObjectCode,DepartmentCodeOrder,LabPathologicalID,OrderDate,EmployeeCodeOrder,EmployeeDoctorCodeOrder,ShiftWork,IDMachine,DepartmentCode,EmployeeCodeDoctor) 
		values(@PatientCode,@ReferenceCode,@Conclusion,@Proposal,@PostingDate,@PatientReceiveID,@ServiceCategoryCode,@STT,@Status,@EmployeeCode,@ObjectCode,@DepartmentCodeOrder,@LabPathologicalID,@OrderDate,@EmployeeCodeOrder,@EmployeeDoctorCodeOrder,@ShiftWork,@IDMachine,@DepartmentCode,@EmployeeCodeDoctor)
		select top(1) @ResultRowID=RowID from ServiceLaboratoryEntry where PatientCode=@PatientCode and ReferenceCode=@ReferenceCode and PatientReceiveID=@PatientReceiveID and ServiceCategoryCode=@ServiceCategoryCode and ObjectCode=@ObjectCode order by RowID desc
	end
commit tran
go
if exists(select name from sysobjects where name ='pro_Ins_ServiceLaboratoryDetail')
	drop procedure pro_Ins_ServiceLaboratoryDetail
go
create procedure pro_Ins_ServiceLaboratoryDetail
(
	@RowIDLaboratoryEnTry numeric(18,0),
	@ServiceCode varchar(50),
	@UnitValues nvarchar(50),
	@ValuesEntry nvarchar(50),
	@ValuedFemale nvarchar(50),
	@ValuedMale nvarchar(50),
	@MinValuedFemale decimal(18,4),
	@MaxValuedFemale decimal(18,4),
	@MinValuedMale decimal(18,4),
	@MaxValuedMale decimal(18,4),
	@Normal decimal(18,0),
	@LaboratoryName nvarchar(100),
	@STT int,
	@Status int,
	@ParameterMachine nvarchar(50)
)
as
begin
	declare @SuggestedID numeric(18,0)
	declare @PatientCode varchar(50)
	declare @ReferenceCode varchar(50)
	declare @PatientReceiveID numeric(18,0)
	select @PatientCode=PatientCode,@ReferenceCode=ReferenceCode,@PatientReceiveID=PatientReceiveID from ServiceLaboratoryEntry where RowID=@RowIDLaboratoryEnTry
	select @SuggestedID=ReceiptID from SuggestedServiceReceipt where PatientCode=@PatientCode and ReferenceCode=@ReferenceCode and RefID=@PatientReceiveID and ServiceCode=@ServiceCode and ReceiptID_DisparityPrice=0
	--begin
		insert into ServiceLaboratoryDetail(RowIDLaboratoryEnTry,ServiceCode,UnitValues,ValuesEntry,ValuedFemale,ValuedMale,MinValuedFemale,MaxValuedFemale,MinValuedMale,MaxValuedMale,Normal,SuggestedID,LaboratoryName,STT,ParameterMachine) values(@RowIDLaboratoryEnTry,@ServiceCode,@UnitValues,@ValuesEntry,@ValuedFemale,@ValuedMale,@MinValuedFemale,@MaxValuedFemale,@MinValuedMale,@MaxValuedMale,@Normal,@SuggestedID,@LaboratoryName,@STT,@ParameterMachine)
		--update SuggestedServiceReceipt set Status=@Status where ReceiptID=@SuggestedID
	--end
end
go
if exists(select name from sysobjects where name ='pro_Upd_SuggestedServiceReceipt')
	drop procedure pro_Upd_SuggestedServiceReceipt
go
create procedure pro_Upd_SuggestedServiceReceipt
(
	@RowIDLaboratoryEnTry numeric(18,0),
	@Status int,
	@Result int out
)
as
begin
	declare @SuggestedID numeric(18,0)
	declare cur cursor read_only fast_forward
	for select distinct SuggestedID from ServiceLaboratoryDetail where RowIDLaboratoryEnTry=@RowIDLaboratoryEnTry
	open cur
	fetch next from cur into @SuggestedID
	while @@FETCH_STATUS = 0
	begin
		update SuggestedServiceReceipt set Status=@Status where ReceiptID=@SuggestedID
		FETCH NEXT FROM cur into @SuggestedID
	end	 
	CLOSE cur
	DEALLOCATE cur
	set @Result =1 -- update thanh cong
	
end
go
if exists(select name from sysobjects where name ='pro_Del_LaboratoryGetTemplate')
	drop procedure pro_Del_LaboratoryGetTemplate
go
create procedure pro_Del_LaboratoryGetTemplate
(
	@RowID numeric(18,0),
	@Result int out
)
as
begin
	if exists(select RowID from ServiceLaboratoryEntry where status=2 and RowID=@RowID)
		begin
			update SuggestedServiceReceipt set status=0 where ReceiptID in( select distinct SuggestedID from ServiceLaboratoryDetail where RowIDLaboratoryEnTry=@RowID)
			delete from ServiceLaboratoryDetail where RowIDLaboratoryEnTry=@RowID
			delete from ServiceLaboratoryEntry where RowID=@RowID
			set @Result =1 -- xoa thanh cong
		end
	else
		begin
			set @Result = -1 -- da co ket qua
		end
end
go
--exec pro_Ins_RealMedicinesForPatients 0,'CC000000000100',162,'14000003','NV00001',2,2,1,1,'KP0011','07/10/2014',0
--------------------------------- xu ly xuat thuoc tu truc khoa xet nghiem
if exists(select name from sysobjects where name ='pro_Ins_RealMedicinesForPatients')
	drop procedure pro_Ins_RealMedicinesForPatients
go
create procedure pro_Ins_RealMedicinesForPatients
(
	@RowID numeric(18,0),
	@RefCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(50),
	@EmployeeCode varchar(50),
	@ObjectCode int,
	@PatientType int,
	@VoteRowID int,
	@Status int,
	@DepartmentCode varchar(50),
	@DateApproved datetime,
	@ShiftWork char(2),
	@ResultRowID numeric(18,0) output
)
as
begin
	if exists(select RefCode from RealMedicinesForPatients where RefCode=@RefCode and RowID=@RowID)
		begin		
			update RealMedicinesForPatients set EmployeeCode=@EmployeeCode,ObjectCode=@ObjectCode,PatientType=@PatientType,VoteRowID=@VoteRowID,Status=@Status,DepartmentCode=@DepartmentCode,ShiftWork=@ShiftWork where RefCode=@RefCode and PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode and CONVERT(date,DateApproved,103)=CONVERT(date,@DateApproved,103)
			--select top(1) @ResultRowID=RowID from RealMedicinesForPatients where PatientCode=@PatientCode and RefCode=@RefCode and PatientReceiveID=@PatientReceiveID and CONVERT(date,DateApproved,103)=CONVERT(date,@DateApproved,103) order by RowID desc
			set @ResultRowID=@RowID
		end
	else
	begin
		insert into RealMedicinesForPatients(RefCode,PatientReceiveID,PatientCode,EmployeeCode,DateApproved,ObjectCode,PatientType,VoteRowID,Status,DepartmentCode,ShiftWork)
		values(@RefCode,@PatientReceiveID,@PatientCode,@EmployeeCode,@DateApproved,@ObjectCode,@PatientType,@VoteRowID,@Status,@DepartmentCode,@ShiftWork)
		select top(1) @ResultRowID=RowID from RealMedicinesForPatients where PatientCode=@PatientCode and RefCode=@RefCode and PatientReceiveID=@PatientReceiveID and CONVERT(date,DateApproved,103)=CONVERT(date,@DateApproved,103) order by RowID desc
	end
end
go

--delete from RealMedicinesForPatients where RowID=58
--select * from RealMedicinesForPatients
--select RefCode from RealMedicinesForPatients where RefCode='CC000000000001'
--update RealMedicinesForPatients set EmployeeCode='NV00001',DateApproved=GETDATE(),ObjectCode=2,PatientType=2,VoteRowID=1,Status=1,DepartmentCode='KP0011' where RefCode='CC000000000001' and PatientReceiveID=82 and PatientCode='14000003'
--exec pro_Ins_RealMedicinesForPatients 0,'CC000000000015',162,'14000030','NV00003',3,2,1,1,'KP0008',0
if exists(select name from sysobjects where name like'%pro_Ins_RealMedicinesForPatientsDetail%')
	drop procedure pro_Ins_RealMedicinesForPatientsDetail
go
create procedure pro_Ins_RealMedicinesForPatientsDetail
(
	@RealRowID numeric(18,0),
	@ItemCode varchar(50),
	@Quantity numeric(18,2),
	@UnitPrice numeric(18,4),
	@SalesPrice numeric(18,4),
	@BHYTPrice numeric(18,4),
	@Amount numeric(18,4),
	@RowIDInventoryGumshoe numeric(18,0),
	@RateBHYT numeric(18,0),
	@ObjectCode int,
	@RepositoryCode varchar(50),
	@Instruction nvarchar(500),
	@RowIDold numeric(18,0)
)
as
begin
	declare @RowID numeric(18,0)
	if not exists(select BanksAccountCode from RealMedicinesForPatients where (BanksAccountCode is not null and BanksAccountCode<>'') and RowID=@RealRowID)
		begin
			if exists(select rowid from RealMedicinesForPatientsDetail where RealRowID=@RealRowID and RowID=@RowIDold and ItemCode=@ItemCode)
			begin
				declare @RowIDInventoryGumshoeold numeric(18,0)
				declare @Quantityold numeric(18,2)
				--- cap nhat lai ton kho
				select @RowIDInventoryGumshoeold=RowIDInventoryGumshoe,@Quantityold=Quantity from RealMedicinesForPatientsDetail where RealRowID=@RealRowID and RowID=@RowIDold
				update InventoryGumshoe set AmountExport=AmountExport-@Quantityold where RowID=@RowIDInventoryGumshoe
				update InventoryGeneral set AmountExport=AmountExport-@Quantityold, AmountEnd=AmountEnd+@Quantityold where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Hide = 0
				--- updat lai cai moi
				update RealMedicinesForPatientsDetail set Instruction=@Instruction,Quantity=@Quantity,UnitPrice=@UnitPrice,SalesPrice=@SalesPrice,BHYTPrice=@BHYTPrice,RowIDInventoryGumshoe=@RowIDInventoryGumshoe,RateBHYT=@RateBHYT,ObjectCode=@ObjectCode,RepositoryCode=@RepositoryCode where RealRowID=@RealRowID and RowID=@RowIDold and ItemCode=@ItemCode
				update InventoryGumshoe set AmountExport=AmountExport+@Quantity where RowID=@RowIDInventoryGumshoe
				update InventoryGeneral set AmountExport=AmountExport+@Quantity, AmountEnd=AmountEnd-@Quantity where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Hide = 0
			end
			else
			begin
				set @RowID=1
				select @RowID=(ISNULL(MAX(RowID),0)+1 )from RealMedicinesForPatientsDetail	where RealRowID=@RealRowID
				insert into RealMedicinesForPatientsDetail(RowID,RealRowID,ItemCode,Quantity,UnitPrice,SalesPrice,BHYTPrice,Amount,IDate,RowIDInventoryGumshoe,RateBHYT,ObjectCode,RepositoryCode,Instruction)
				values(@RowID,@RealRowID,@ItemCode,@Quantity,@UnitPrice,@SalesPrice,@BHYTPrice,@Amount,getdate(),@RowIDInventoryGumshoe,@RateBHYT,@ObjectCode,@RepositoryCode,@Instruction)
				update InventoryGumshoe set AmountExport=AmountExport+@Quantity where RowID=@RowIDInventoryGumshoe
				update InventoryGeneral set AmountExport=AmountExport+@Quantity, AmountEnd=AmountEnd-@Quantity where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Hide = 0
			end
		end
end
go
if exists(select name from sysobjects where name like'%pro_Del_RealMedicinesDetail%')
	drop procedure pro_Del_RealMedicinesDetail
go
create procedure pro_Del_RealMedicinesDetail
(
	@RealRowID numeric(18,0),
	@Result int out
)
as
begin
	declare @ItemCode varchar(50)
	declare @Quantity numeric(18,2)
	declare @RowIDGumshoe numeric(18,0)
	declare @RepositoryCode varchar(50)
	if not exists(select BanksAccountCode from RealMedicinesForPatients where (BanksAccountCode is not null and BanksAccountCode<>'') and RowID=@RealRowID)
		begin
			declare cur cursor read_only fast_forward
			for select ItemCode,Quantity,RepositoryCode,RowIDInventoryGumshoe from RealMedicinesForPatientsDetail where RealRowID=@RealRowID
			open cur
			fetch next from cur into @ItemCode,@Quantity,@RepositoryCode,@RowIDGumshoe
			while @@FETCH_STATUS = 0
			begin
				update InventoryGumshoe set AmountExport=AmountExport-@Quantity where RowID=@RowIDGumshoe
				update InventoryGeneral set AmountExport=AmountExport-@Quantity,AmountEnd=AmountEnd+@Quantity where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Hide = 0
				FETCH NEXT FROM cur into @ItemCode,@Quantity,@RepositoryCode,@RowIDGumshoe
			end
			CLOSE cur
			DEALLOCATE cur
			delete from RealMedicinesForPatientsDetail where RealRowID=@RealRowID and Paid=0
			delete from RealMedicinesForPatients where RowID=@RealRowID
			set @Result =1 -- xoa thanh cong
		end
	else
	begin
		set @Result = -1 -- da thanh toan
	end
end
go
-------------------------------------Chi xoa dc 1 table detail
if exists(select name from sysobjects where name like'%pro_Del_RealMedicinesDetailOnlyTable%')
	drop procedure pro_Del_RealMedicinesDetailOnlyTable
go
create procedure pro_Del_RealMedicinesDetailOnlyTable
(
	@RealRowID numeric(18,0),
	@Result int out
)
as
begin
	declare @ItemCode varchar(50)
	declare @Quantity numeric(18,2)
	declare @RowIDGumshoe numeric(18,0)
	declare @RepositoryCode varchar(50)
	if not exists(select BanksAccountCode from RealMedicinesForPatients where (BanksAccountCode is not null and BanksAccountCode<>'') and RowID=@RealRowID)
		begin
			declare cur cursor read_only fast_forward
			for select ItemCode,Quantity,RepositoryCode,RowIDInventoryGumshoe from RealMedicinesForPatientsDetail where RealRowID=@RealRowID
			open cur
			fetch next from cur into @ItemCode,@Quantity,@RepositoryCode,@RowIDGumshoe
			while @@FETCH_STATUS = 0
			begin
				update InventoryGumshoe set AmountExport=AmountExport-@Quantity where RowID=@RowIDGumshoe
				update InventoryGeneral set AmountExport=AmountExport-@Quantity, AmountEnd=AmountEnd+@Quantity where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Hide = 0
				FETCH NEXT FROM cur into @ItemCode,@Quantity,@RepositoryCode,@RowIDGumshoe
			end	 
			CLOSE cur
			DEALLOCATE cur
			delete from RealMedicinesForPatientsDetail where RealRowID=@RealRowID
			set @Result =1 -- xoa thanh cong
		end
	else
	begin
		set @Result = -1 -- da thanh toan
	end
end
go
if exists(select name from sysobjects where name ='pro_Del_RealMedicinesDetailItemCode')
	drop procedure pro_Del_RealMedicinesDetailItemCode
go
create procedure pro_Del_RealMedicinesDetailItemCode
(
	@RealRowID numeric(18,0),
	@ItemCode varchar(50),
	@RowID numeric(18,0),
	@Result int out
)
as
begin tran
	declare @Quantity numeric(18,2)
	declare @RowIDGumshoe numeric(18,0)
	declare @RepositoryCode varchar(50)
	declare @ReCord int
	if not exists(select BanksAccountCode from RealMedicinesForPatients where (BanksAccountCode is not null and BanksAccountCode<>'') and RowID=@RealRowID)
		begin
			declare cur cursor read_only fast_forward
			for select ItemCode,Quantity,RepositoryCode,RowIDInventoryGumshoe from RealMedicinesForPatientsDetail where RealRowID=@RealRowID and ItemCode=@ItemCode and RowID=@RowID
			open cur
			fetch next from cur into @ItemCode,@Quantity,@RepositoryCode,@RowIDGumshoe
			while @@FETCH_STATUS = 0
			begin
				update InventoryGumshoe set AmountExport=AmountExport-@Quantity where RowID=@RowIDGumshoe
				update InventoryGeneral set AmountExport=AmountExport-@Quantity, AmountEnd=AmountEnd+@Quantity where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Hide = 0
				FETCH NEXT FROM cur into @ItemCode,@Quantity,@RepositoryCode,@RowIDGumshoe
			end	 
			CLOSE cur
			DEALLOCATE cur
			delete from RealMedicinesForPatientsDetail where RealRowID=@RealRowID and ItemCode=@ItemCode and RowID=@RowID
			select @ReCord=COUNT(*) from RealMedicinesForPatientsDetail where RealRowID=@RealRowID
			if @ReCord <=0
				delete from RealMedicinesForPatients where RowID=@RealRowID
			set @Result =1 -- xoa thanh cong
		end
	else
	begin
		set @Result = -1 -- da thanh toan
	end
commit tran
go
-----------------------------------------------Thong tin luu benh
if exists(select name from sysobjects where name like'%pro_Ins_MedicalEmergency%')
	drop procedure pro_Ins_MedicalEmergency
go
create procedure pro_Ins_MedicalEmergency
(
	@MedicalEmergencyCode varchar(20),
	@PatientCode varchar(50),
	@DepartmentCode varchar(50),
	@EmployeeCode varchar(50),
	@DateOn date,
	@TimeOn char(5),
	@ReceivePatientFrom nvarchar(100),
	@DiagnosisCode nvarchar(250),
	@ICD10 varchar(10),
	@Family nvarchar(250),
	@FamilyFullname nvarchar(250),
	@FamilyAddress nvarchar(250),
	@FamilyMobile nvarchar(250),
	@PatientReceivingNursing varchar(50),
	@PatientReceiveID numeric(18,0),
	@PatientType int,
	@ObjectCode int,
	@ReceiptID numeric(18,0),
	@Symptoms nvarchar(250),
	@Treatments nvarchar(200)='',
	@vresult varchar(20) output
)
as
begin
	if exists(select MedicalEmergencyCode from MedicalEmergency where MedicalEmergencyCode=@MedicalEmergencyCode)
	begin
		update MedicalEmergency set DepartmentCode=@DepartmentCode,EmployeeCode=@EmployeeCode,DateOn=@DateOn,TimeOn=@TimeOn, 
		ReceivePatientFrom=@ReceivePatientFrom,DiagnosisCode=@DiagnosisCode,ICD10=@ICD10,Family=@Family,FamilyFullname=@FamilyFullname,FamilyAddress=@FamilyAddress,
		FamilyMobile=@FamilyMobile,PatientReceivingNursing=@PatientReceivingNursing,PatientType=@PatientType,ObjectCode=@ObjectCode,IDate=GETDATE(),Symptoms=@Symptoms,Treatments=@Treatments
		where MedicalEmergencyCode=@MedicalEmergencyCode and PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID
		update PatientReceive set status=1 where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID
		update SuggestedServiceReceipt set status=1 where ReceiptID=@ReceiptID
		set @vresult=@MedicalEmergencyCode
	end
	else
	begin
		declare @_Code varchar(20)
		declare @_stt decimal(18,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(MedicalEmergencyCode,12)) maxcode from MedicalEmergency order by CONVERT(decimal(18,0),RIGHT(MedicalEmergencyCode,12)) desc)+1
		if(@_stt<=9)
			begin
				set @_Code = 'CC00000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_Code = 'CC0000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_Code = 'CC000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_Code = 'CC00000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999 and @_stt<=99999)
			begin
				set @_Code = 'CC0000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999 and @_stt<=999999)
			begin
				set @_Code = 'CC000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999999 and @_stt<=9999999)
			begin
				set @_Code = 'CC00000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999999 and @_stt<=99999999)
			begin
				set @_Code = 'CC0000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999999 and @_stt<=999999999)
			begin
				set @_Code = 'CC000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999999999 and @_stt<=9999999999)
			begin
				set @_Code = 'CC00'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999999999 and @_stt<=99999999999)
			begin
				set @_Code = 'CC0'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999999999 and @_stt<=999999999999)
			begin
				set @_Code = 'CC'+convert(varchar(12),@_stt)
			end
		else
			begin
				set @_Code = 'CC000000000001'
			end
		insert into MedicalEmergency(MedicalEmergencyCode,PatientCode,DepartmentCode,EmployeeCode,DateOn,TimeOn,ReceivePatientFrom,DiagnosisCode,ICD10,Family,FamilyFullname,FamilyAddress,FamilyMobile,PatientReceivingNursing,IDate,PatientReceiveID,PatientType,ObjectCode,Symptoms,Treatments)
		values(@_Code,@PatientCode,@DepartmentCode,@EmployeeCode,@DateOn,@TimeOn,@ReceivePatientFrom,@DiagnosisCode,@ICD10,@Family,@FamilyFullname,@FamilyAddress,@FamilyMobile,@PatientReceivingNursing,GETDATE(),@PatientReceiveID,@PatientType,@ObjectCode,@Symptoms,@Treatments)
		update PatientReceive set status=1 where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID
		update SuggestedServiceReceipt set status=1 where ReceiptID=@ReceiptID
		set @vresult =@_Code
	end
end
go
if exists(select name from sysobjects where name like'%pro_Ins_MedicalEmergencyOut%')
	drop procedure pro_Ins_MedicalEmergencyOut
go
create procedure pro_Ins_MedicalEmergencyOut
(
	@MedicalEmergencyOutCode varchar(20),
	@DateOut date,
	@TimeOut char(5),
	@TreatmentTime int,
	@TreatmentResults int,
	@ICD10Out varchar(10),
	@MedicalEmergencyCode varchar(20),
	@TreatingDoctor nvarchar(50),
	@NumberStorage nvarchar(50),
	@EmployeeCode varchar(50),
	@TackleCode int,
	@Advices nvarchar(250),
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(50),
	@Status int=1,
	@vresult varchar(50) output
)
as
begin
	if exists(select MedicalEmergencyCode from MedicalEmergencyOut where MedicalEmergencyCode=@MedicalEmergencyCode)
	begin
		update MedicalEmergencyOut set DateOut=@DateOut,TimeOut=@TimeOut,TreatmentTime=@TreatmentTime,TreatmentResults=@TreatmentResults,
		ICD10Out=@ICD10Out,MedicalEmergencyCode=@MedicalEmergencyCode,TreatingDoctor=@TreatingDoctor,NumberStorage=@NumberStorage,
		EmployeeCode=@EmployeeCode,TackleCode=@TackleCode,Advices=@Advices,IDate=GETDATE()
		where MedicalEmergencyCode=@MedicalEmergencyCode and PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID
		select @vresult=MedicalEmergencyOutCode from MedicalEmergencyOut where MedicalEmergencyCode=@MedicalEmergencyCode and PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID
		update PatientReceive set Status=@Status,OutDate=@DateOut where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID
		--set @vresult=@MedicalEmergencyOutCode
	end
	else
	begin
		declare @_Code varchar(20)
		declare @_stt decimal(18,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(MedicalEmergencyOutCode,12)) maxcode from MedicalEmergencyOut order by CONVERT(decimal(18,0),RIGHT(MedicalEmergencyOutCode,12)) desc)+1
		if(@_stt<=9)
			begin
				set @_Code = 'CCO00000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_Code = 'CCO0000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_Code = 'CCO000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_Code = 'CCO00000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999 and @_stt<=99999)
			begin
				set @_Code = 'CCO0000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999 and @_stt<=999999)
			begin
				set @_Code = 'CCO000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999999 and @_stt<=9999999)
			begin
				set @_Code = 'CCO00000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999999 and @_stt<=99999999)
			begin
				set @_Code = 'CCO0000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999999 and @_stt<=999999999)
			begin
				set @_Code = 'CCO000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999999999 and @_stt<=9999999999)
			begin
				set @_Code = 'CCO00'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999999999 and @_stt<=99999999999)
			begin
				set @_Code = 'CCO0'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999999999 and @_stt<=999999999999)
			begin
				set @_Code = 'CCO'+convert(varchar(12),@_stt)
			end
		else
			begin
				set @_Code = 'CCO000000000001'
			end
		insert into MedicalEmergencyOut(MedicalEmergencyOutCode,DateOut,TimeOut,TreatmentTime,TreatmentResults,ICD10Out,MedicalEmergencyCode,TreatingDoctor,EmployeeCode,TackleCode,Advices,IDate,PatientReceiveID,PatientCode,NumberStorage)
		values(@_Code,@DateOut,@TimeOut,@TreatmentTime,@TreatmentResults,@ICD10Out,@MedicalEmergencyCode,@TreatingDoctor,@EmployeeCode,@TackleCode,@Advices,GETDATE(),@PatientReceiveID,@PatientCode,@NumberStorage)
		set @vresult =@_Code
		update PatientReceive set Status=@Status,OutDate=@DateOut where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID
	end
end
go
------------------------ PatientReceiveCocumentImage
if exists(select name from sysobjects where name ='pro_Ins_PatientReceiveCocumentImage')
	drop procedure pro_Ins_PatientReceiveCocumentImage
go
create procedure pro_Ins_PatientReceiveCocumentImage
(
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(20),
	@STT int,
	@Note nvarchar(250),
	@Image image,
	@Result int output
)
as
begin
	if exists(select PatientCode from PatientReceiveCocumentImage where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode and STT=@STT)
	begin
		update PatientReceiveCocumentImage set Note=@Note,Image=@Image where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode and STT=@STT
		set @Result=2
	end
	else
	begin
		insert into PatientReceiveCocumentImage(PatientReceiveID,PatientCode,STT,Note,Image)
		values(@PatientReceiveID,@PatientCode,@STT,@Note,@Image)
		set @Result = 1
	end
end
go
-- select * from PatientReceiveCocumentImage
------------------ Table Xuat ban thuoc
if exists(select name from sysobjects where name='pro_Ins_MedicinesRetail')
	drop procedure pro_Ins_MedicinesRetail
go
create procedure pro_Ins_MedicinesRetail
(
	@RetailCode varchar(20),
	@FullName nvarchar(500),
	@Birthyear varchar(5),
	@Address nvarchar(500),
	@Diagnosis nvarchar(250),
	@NumberOfDrugCoal varchar(5),
	@SerialNumber varchar(50),
	@InvoiceNumber varchar(50),
	@EmployeeCode varchar(50),
	@ExportDate date,
	@Paid int,
	@TotalAmount decimal(18,4),
	@TotalAmountReal decimal(18,4),
	@RateOther decimal(18,4),
	@RateUSD decimal(18,4),
	@RateSurcharge decimal(18,4),
	@TotalSurcharge decimal(18,4),
	@IntroCode varchar(10),
	@Cash decimal(18,4),
	@ExcessCash decimal(18,4),
	@VoucherCard nvarchar(100),
	@OtherCard nvarchar(100),
	@ExcessCashOther decimal(18,4),
	@MedicalRecordCode varchar(50),
	@PatientCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@ShiftWork char(2),
	@PatientBirthday date,
	@PatientMonth varchar(5),
	@PatientGender int,
	@PatientAge int,
	@EmployeeCodeDoctor varchar(15),
	@EmployeeNameDoctor nvarchar(250),
	@VAT int =0,
	@ResultRetailCode varchar(20) output
)
as
begin
	declare @PatientReceiveClinic varchar(30)
	declare @STT int =0
	set @PatientReceiveClinic = (select PatientReceiveClinic from PatientReceive where PatientReceiveID=@PatientReceiveID)
	set @STT = (select ISNULL(MAX(STT)+1,1) STT from MedicinesRetail where CONVERT(date,ExportDate,103)=CONVERT(date,GETDATE(),103))
	if exists(select RetailCode from MedicinesRetail where RetailCode=@RetailCode)
		begin
			update MedicinesRetail set FullName=@FullName,Birthyear=@Birthyear,Address=@Address,Diagnosis=@Diagnosis,NumberOfDrugCoal=@NumberOfDrugCoal,
			InvoiceNumber=@InvoiceNumber,EmployeeCode=@EmployeeCode,ExportDate=GETDATE(),Paid=@Paid,
			TotalAmount=@TotalAmount,TotalAmountReal=@TotalAmountReal,RateOther=@RateOther,RateUSD=@RateUSD,RateSurcharge=@RateSurcharge,
			TotalSurcharge=@TotalSurcharge,IntroCode=@IntroCode,Cash=@Cash,ExcessCash=@ExcessCash,VoucherCard=@VoucherCard,OtherCard=@OtherCard,ExcessCashOther=@ExcessCashOther,
			MedicalRecordCode=@MedicalRecordCode,PatientCode=@PatientCode,PatientReceiveID=@PatientReceiveID,PatientReceiveClinic=@PatientReceiveClinic,ShiftWork=@ShiftWork,
			PatientBirthday=@PatientBirthday,PatientMonth=@PatientMonth,PatientGender=@PatientGender,PatientAge=@PatientAge,EmployeeCodeDoctor=@EmployeeCodeDoctor,EmployeeNameDoctor=@EmployeeNameDoctor,VAT=@VAT
			where RetailCode=@RetailCode
			set @ResultRetailCode=@RetailCode
		end
	else
	begin
		declare @_MedicalCode varchar(20)
		declare @_stt decimal(18,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(RetailCode,12)) maxcode from MedicinesRetail order by CONVERT(decimal(18,0),RIGHT(RetailCode,12)) desc)+1
		if(@_stt<=9)
			begin
				set @_MedicalCode = 'CH00000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_MedicalCode = 'CH0000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_MedicalCode = 'CH000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_MedicalCode = 'CH00000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999 and @_stt<=99999)
			begin
				set @_MedicalCode = 'CH0000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999 and @_stt<=999999)
			begin
				set @_MedicalCode = 'CH000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999999 and @_stt<=9999999)
			begin
				set @_MedicalCode = 'CH00000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999999 and @_stt<=99999999)
			begin
				set @_MedicalCode = 'CH0000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999999 and @_stt<=999999999)
			begin
				set @_MedicalCode = 'CH000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999999999 and @_stt<=9999999999)
			begin
				set @_MedicalCode = 'CH00'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999999999 and @_stt<=99999999999)
			begin
				set @_MedicalCode = 'CH0'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999999999 and @_stt<=999999999999)
			begin
				set @_MedicalCode = 'CH'+convert(varchar(12),@_stt)
			end
		else
			begin
				set @_MedicalCode = 'CH000000000001'
			end
		insert into MedicinesRetail(RetailCode,FullName,Birthyear,Address,Diagnosis,NumberOfDrugCoal,SerialNumber,InvoiceNumber,EmployeeCode,ExportDate,Paid,TotalAmount,TotalAmountReal,RateOther,RateUSD,RateSurcharge,TotalSurcharge,IntroCode,Cash,ExcessCash,VoucherCard,OtherCard,ExcessCashOther,MedicalRecordCode,PatientCode,PatientReceiveID,PatientReceiveClinic,ShiftWork,PatientBirthday,PatientMonth,PatientGender,PatientAge,EmployeeCodeDoctor,EmployeeNameDoctor,STT,VAT) 
		values(@_MedicalCode,@FullName,@Birthyear,@Address,@Diagnosis,@NumberOfDrugCoal,@SerialNumber,@InvoiceNumber,@EmployeeCode,GETDATE(),@Paid,@TotalAmount,@TotalAmountReal,@RateOther,@RateUSD,@RateSurcharge,@TotalSurcharge,@IntroCode,@Cash,@ExcessCash,@VoucherCard,@OtherCard,@ExcessCashOther,@MedicalRecordCode,@PatientCode,@PatientReceiveID,@PatientReceiveClinic,@ShiftWork,@PatientBirthday,@PatientMonth,@PatientGender,@PatientAge,@EmployeeCodeDoctor,@EmployeeNameDoctor,@STT,@VAT)
		set @ResultRetailCode=@_MedicalCode
	end
end
go
if exists(select name from sysobjects where name like'%pro_ResultMedicinesRetail%')
	drop procedure pro_ResultMedicinesRetail
go
create procedure pro_ResultMedicinesRetail
(
	@Paid int,
	@BanksAccountCode varchar(50),
	@PatientCode varchar(50),
	@PatientReceiveID numeric(18,0)
)
as
begin
	if @Paid=1
		set @Paid=2
	else
		set @Paid=1
	if @BanksAccountCode<>''
	begin
		select c.MedicalRecordCode,a.ItemCode,a.QuantityExport Quantity,a.UnitPrice,a.Amount,b.ItemName,b.SalesPrice,b.BHYTPrice,b.RateBHYT,b1.UnitOfMeasureName
		from MedicinesRetailDetail a inner join Items b on a.ItemCode=b.ItemCode inner join UnitOfMeasure b1 on b.UnitOfMeasureCode=b1.UnitOfMeasureCode
		inner join MedicinesRetail c on a.RetailCode=c.RetailCode inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode
		where c.BanksAccountCode=@BanksAccountCode and c.PatientCode=@PatientCode and c.PatientReceiveID=@PatientReceiveID and c.Paid=@Paid
    end
    else
    begin
		select c.MedicalRecordCode,a.ItemCode,a.QuantityExport Quantity,a.UnitPrice,a.Amount,b.ItemName,b.SalesPrice,b.BHYTPrice,b.RateBHYT,b1.UnitOfMeasureName
		from MedicinesRetailDetail a inner join Items b on a.ItemCode=b.ItemCode inner join UnitOfMeasure b1 on b.UnitOfMeasureCode=b1.UnitOfMeasureCode
		inner join MedicinesRetail c on a.RetailCode=c.RetailCode inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode
		where (c.BanksAccountCode is null or c.BanksAccountCode='') and c.PatientCode=@PatientCode and c.PatientReceiveID=@PatientReceiveID and c.Paid=@Paid
    end
end
go
-- select * from MedicinesRetail
-- exec pro_ResultMedicinesRetail 0,'','14000003',204
if exists(select name from sysobjects where name ='pro_Ins_MedicinesRetailDetailSub')
	drop procedure pro_Ins_MedicinesRetailDetailSub
go
create procedure pro_Ins_MedicinesRetailDetailSub
(
	@RetailCode varchar(20),
	@ItemCode varchar(50),
	@DateOfIssues int,
	@Quantity numeric(18,2),
	@UnitPrice numeric(18,4),
	@Amount numeric(18,4),
	@RowIDInventoryGumshoe numeric(18,0),
	@RateBHYT numeric(18,0),
	@RepositoryCode varchar(50),
	@Instruction nvarchar(500),
	@QuantityExport numeric(18,2),
	@Morning varchar(50),
	@Noon varchar(50),
	@Afternoon varchar(50),
	@Evening varchar(50)
)
as
begin
	insert into MedicinesRetailDetail(RetailCode,ItemCode,DateOfIssues,Quantity,UnitPrice,Amount,IDate,RowIDInventoryGumshoe,RateBHYT,RepositoryCode,Instruction,QuantityExport,Morning,Noon,Afternoon,Evening)
	values(@RetailCode,@ItemCode,@DateOfIssues,@Quantity,@UnitPrice,@Amount,GETDATE(),@RowIDInventoryGumshoe,@RateBHYT,@RepositoryCode,@Instruction,@QuantityExport,@Morning,@Noon,@Afternoon,@Evening)
	update InventoryGumshoe set AmountExport=AmountExport+@QuantityExport where RowID=@RowIDInventoryGumshoe
	update InventoryGeneral set AmountExport=AmountExport+@QuantityExport,AmountEnd=AmountEnd-@QuantityExport where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Hide = 0
end
go
if exists(select name from sysobjects where name ='pro_Ins_MedicinesRetailDetail')
	drop procedure pro_Ins_MedicinesRetailDetail
go
create procedure pro_Ins_MedicinesRetailDetail
(
	@RetailCode varchar(20),
	@ItemCode varchar(50),
	@DateOfIssues int,
	@Quantity numeric(18,2),
	@UnitPrice numeric(18,4),
	@Amount numeric(18,4),
	@RowIDInventoryGumshoe numeric(18,0),
	@RateBHYT numeric(18,0),
	@RepositoryCode varchar(50),
	@Instruction nvarchar(500),
	@QuantityExport numeric(18,2),
	@Morning varchar(50),
	@Noon varchar(50),
	@Afternoon varchar(50),
	@Evening varchar(50)
)
as
begin
	insert into MedicinesRetailDetail(RetailCode,ItemCode,DateOfIssues,Quantity,UnitPrice,Amount,IDate,RowIDInventoryGumshoe,RateBHYT,RepositoryCode,Instruction,QuantityExport,Morning,Noon,Afternoon,Evening)
	values(@RetailCode,@ItemCode,@DateOfIssues,@Quantity,@UnitPrice,@Amount,GETDATE(),@RowIDInventoryGumshoe,@RateBHYT,@RepositoryCode,@Instruction,@QuantityExport,@Morning,@Noon,@Afternoon,@Evening)
end
go
if exists(select name from sysobjects where name like'%pro_DelAll_MedicinesRetail%')
	drop procedure pro_DelAll_MedicinesRetail
go
create procedure pro_DelAll_MedicinesRetail
(
	@RetailCode varchar(20),
	@iresult int output
)
as
begin
	if exists(select RetailCode from MedicinesRetail where RetailCode=@RetailCode and Paid=0)
		begin
			delete from MedicinesRetail where RetailCode=@RetailCode
			delete from MedicinesRetailDetail where RetailCode=@RetailCode
			set @iresult =1
		end
	else
	begin		
		set @iresult = -1
	end
end
go
------------------- Xoa thuoc xuat ban le sau khi co hoa don
if exists(select name from sysobjects where name like'%pro_Del_Retail_SubRep%')
	drop procedure pro_Del_Retail_SubRep
go
create procedure pro_Del_Retail_SubRep
(
	@RetailCode varchar(20),
	@EmployeeCode varchar(50),
	@ReasonCancel nvarchar(500),
	@Result int out
)
as
begin
	declare @ItemCode varchar(50)
	declare @Quantity numeric(18,3)
	declare @RowIDGumshoe numeric(18,0)
	declare @RepositoryCode varchar(50)
	--declare @AmountEnd numeric(18,3)
	--declare @AmountExport numeric(18,3)
	--declare @AmountImport numeric(18,3)
	if exists(select RetailCode from MedicinesRetail where RetailCode=@RetailCode and Paid=1)
		begin
			declare cur cursor read_only fast_forward
			for select ItemCode,QuantityExport,RepositoryCode,RowIDInventoryGumshoe from MedicinesRetailDetail where RetailCode=@RetailCode order by ItemCode
			open cur
			fetch next from cur into @ItemCode,@Quantity,@RepositoryCode,@RowIDGumshoe
			while @@FETCH_STATUS = 0
			begin
				update InventoryGumshoe set AmountExport=AmountExport-@Quantity where RowID=@RowIDGumshoe
				update InventoryGeneral set AmountExport=AmountExport-@Quantity,AmountEnd=AmountEnd+@Quantity where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Hide = 0
				FETCH NEXT FROM cur into @ItemCode,@Quantity,@RepositoryCode,@RowIDGumshoe
			end
			CLOSE cur
			DEALLOCATE cur
			update MedicinesRetail set paid=-1,EmployeeCode=@EmployeeCode,IDate=GETDATE(),ReasonCancel=@ReasonCancel where RetailCode=@RetailCode
			set @Result =1 -- xoa thanh cong
		end
	else
	begin
		set @Result = -1 -- xoa khong thanh cong
	end
end
go
--------------------------------- table BracketPrice
if exists(select name from sysobjects where name like'%pro_Ins_BracketPrice%')
	drop procedure pro_Ins_BracketPrice
go
--------------------------------- table Catalog_ExchangeRate
if exists(select name from sysobjects where name like'%pro_Ins_Catalog_ExchangeRate%')
	drop procedure pro_Ins_Catalog_ExchangeRate
go
--------------------------------- table Catalog_SurgicalCrew
if exists(select name from sysobjects where name like'%pro_Ins_Catalog_SurgicalCrew%')
	drop procedure pro_Ins_Catalog_SurgicalCrew
go
create procedure pro_Ins_Catalog_SurgicalCrew
(
	@RowID int,
	@EmployeeName nvarchar(250),
	@Role nvarchar(50),
	@STT int,
	@EmployeeCode varchar(50),
	@PositionCode int
)
as
begin
	declare @Temp numeric(18,0)
	select @Temp=ISNULL(MAX(RowID)+1,1) from Catalog_SurgicalCrew
	if exists(select RowID from Catalog_SurgicalCrew where RowID=@RowID)
	begin
		update Catalog_SurgicalCrew set EmployeeName=@EmployeeName,[Role]=@Role,STT=@STT,EMPLOYEECODE=@EMPLOYEECODE,PositionCode=@PositionCode where RowID=@RowID
	end
	else
	begin
		insert into Catalog_SurgicalCrew(RowID,EmployeeName,Role,STT,EmployeeCode,PositionCode) values(@Temp,@EmployeeName,@Role,@STT,@EmployeeCode,@PositionCode)
	end
end
go
----------------------------------------------- Thong tin phau thu thuat
--exec pro_Ins_Surgeries '','14000006','KP0013','NV00001','27/06/2014','10:20','27/06/2014','20:30','I01.0','I01.0',5,1,3,'con tent','Note',2,131,1,'NV00001',695,''
--select * from Diagnosis
--select * from Catalog_TheSituation
if exists(select name from sysobjects where name like'%pro_Ins_Surgeries%')
	drop procedure pro_Ins_Surgeries
go
create procedure pro_Ins_Surgeries
(
	@SurgeriesCode varchar(15),
	@PatientCode varchar(50),
	@DepartmentCode varchar(50),
	@EmployeeCode varchar(50),
	@DateOn char(10),
	@TimeOn char(5),
	@DateOut char(10),
	@TimeOut char(5),
	@ICD10On varchar(10),
	@ICD10Out varchar(10),
	@IDAnesthesia int,
	@IDComplications int,
	@IDTheSituation int,
	@Content nvarchar(max),
	@Note nvarchar(500),
	@ObjectCode int,
	@PatientReceiveID numeric(18,0),
	@PatientType int,
	@EmployeeCodeUpd varchar(50),
	@IDSuggested numeric(18,0),
	@DiagnosisCustomOn nvarchar(250),
	@DiagnosisCustomOut nvarchar(250),
	@ShiftWork char(2),
	@vresult varchar(15) output
)
as
begin
	if exists(select SurgeriesCode from Surgeries where SurgeriesCode=@SurgeriesCode)
	begin
		update Surgeries set DepartmentCode=@DepartmentCode,EmployeeCodeUpd=@EmployeeCodeUpd,DateOn=@DateOn,TimeOn=@TimeOn,DateOut=@DateOut,TimeOut=@TimeOut,ICD10On=@ICD10On,ICD10Out=@ICD10Out,
		IDAnesthesia=@IDAnesthesia,IDComplications=@IDComplications,IDTheSituation=@IDTheSituation,Content=@Content,Note=@Note,ObjectCode=@ObjectCode,PatientType=@PatientType,IDSuggested=@IDSuggested,
		UDate=GETDATE(),DiagnosisCustomOn=@DiagnosisCustomOn,DiagnosisCustomOut=@DiagnosisCustomOut,ShiftWork=@ShiftWork
		where SurgeriesCode=@SurgeriesCode and PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID
		update SuggestedServiceReceipt set status=1 where ReceiptID=@IDSuggested
		set @vresult=@SurgeriesCode
	end
	else
	begin
		declare @_Code varchar(20)
		declare @_stt decimal(18,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(SurgeriesCode,12)) maxcode from Surgeries order by CONVERT(decimal(18,0),RIGHT(SurgeriesCode,12)) desc)+1
		if(@_stt<=9)
			begin
				set @_Code = 'PT00000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_Code = 'PT0000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_Code = 'PT000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_Code = 'PT00000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999 and @_stt<=99999)
			begin
				set @_Code = 'PT0000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999 and @_stt<=999999)
			begin
				set @_Code = 'PT000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999999 and @_stt<=9999999)
			begin
				set @_Code = 'PT00000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999999 and @_stt<=99999999)
			begin
				set @_Code = 'PT0000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999999 and @_stt<=999999999)
			begin
				set @_Code = 'PT000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999999999 and @_stt<=9999999999)
			begin
				set @_Code = 'PT00'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999999999 and @_stt<=99999999999)
			begin
				set @_Code = 'PT0'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999999999 and @_stt<=999999999999)
			begin
				set @_Code = 'PT'+convert(varchar(12),@_stt)
			end
		else
			begin
				set @_Code = 'PT000000000001'
			end
		insert into Surgeries(SurgeriesCode,DateOn,TimeOn,DateOut,TimeOut,ICD10On,ICD10Out,IDAnesthesia,IDComplications,IDTheSituation,Content,Note,EmployeeCode,ObjectCode,PatientCode,PatientReceiveID,PatientType,EmployeeCodeUpd,IDate,UDate,IDSuggested,DepartmentCode,DiagnosisCustomOn,DiagnosisCustomOut,ShiftWork)
		values(@_Code,@DateOn,@TimeOn,@DateOut,@TimeOut,@ICD10On,@ICD10Out,@IDAnesthesia,@IDComplications,@IDTheSituation,@Content,@Note,@EmployeeCode,@ObjectCode,@PatientCode,@PatientReceiveID,@PatientType,@EmployeeCodeUpd,GETDATE(),GETDATE(),@IDSuggested,@DepartmentCode,@DiagnosisCustomOn,@DiagnosisCustomOut,@ShiftWork)
		update SuggestedServiceReceipt set status=1 where ReceiptID=@IDSuggested
		set @vresult =@_Code
	end
end
go
---------------------------Del
if exists(select name from sysobjects where name like'%pro_Del_Surgeries%')
	drop procedure pro_Del_Surgeries
go
create procedure pro_Del_Surgeries
(
	@SurgeriesCode varchar(15),
	@iresult int output
)
as
begin
	declare @IDSuggested numeric(18,0)
	declare @ItemCode varchar(50)
	declare @Quantity decimal(18,2)
	declare @RepositoryCode varchar(50)
	declare @RowIDInventoryGumshoe decimal(18,0)
	declare @RowIDDetail numeric(18,0)
	if exists(select SurgeriesCode from Surgeries where SurgeriesCode=@SurgeriesCode and Paid=0 and BanksAccountCode is null)
	begin
		select @IDSuggested=IDSuggested from Surgeries where SurgeriesCode=@SurgeriesCode
		declare cur cursor read_only fast_forward
		for select a1.RowID,a1.ItemCode,a1.Quantity,a1.RepositoryCode,a1.RowIDInventoryGumshoe from RealMedicinesForPatients a inner join RealMedicinesForPatientsDetail a1 on a.RowID=a1.RealRowID where a.RefCode=@SurgeriesCode
		open cur
		fetch next from cur into @RowIDDetail,@ItemCode,@Quantity,@RepositoryCode,@RowIDInventoryGumshoe
		while @@FETCH_STATUS = 0
		begin
			update InventoryGumshoe set AmountExport=AmountExport-@Quantity where RowID=@RowIDInventoryGumshoe and ItemCode=@ItemCode
			update InventoryGeneral set AmountExport=AmountExport-@Quantity, AmountEnd=AmountEnd+@Quantity where RepositoryCode=@RepositoryCode and ItemCode=@ItemCode and Hide = 0
			delete from RealMedicinesForPatientsDetail where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and RowIDInventoryGumshoe=@RowIDInventoryGumshoe and RowID=@RowIDDetail
			FETCH NEXT FROM cur into @RowIDDetail,@ItemCode,@Quantity,@RepositoryCode,@RowIDInventoryGumshoe
		end	 
		CLOSE cur
		DEALLOCATE cur
		delete from RealMedicinesForPatients where RefCode=@SurgeriesCode
		delete from SurgicalCrew where SurgeriesCode=@SurgeriesCode
		delete from Surgeries where SurgeriesCode=@SurgeriesCode
		update SuggestedServiceReceipt set status=0 where ReceiptID=@IDSuggested
		set @iresult =1
	end
	else
	begin
		set @iresult =-1
	end
end
go
if exists(select name from sysobjects where name like'%DucTinDel_Surgeries%')
	drop procedure DucTinDel_Surgeries
go
create procedure DucTinDel_Surgeries
(
	@SurgeriesCode varchar(15),
	@iresult int output
)
as
begin
	if exists(select SurgeriesCode from Surgeries where SurgeriesCode=@SurgeriesCode and Paid=0 and BanksAccountCode is null)
	begin
		if exists(select m.MedicalRecordCode from MedicalRecord M inner join MedicalPrescriptionDetail M1 on M.MedicalRecordCode=M1.MedicalRecordCode where M.ReferenceCode=@SurgeriesCode and M1.Status=1)
			set @iresult =-2
		else
			begin
				delete from MedicalPrescriptionDetail where MedicalRecordCode in(select MedicalRecordCode from MedicalRecord where ReferenceCode=@SurgeriesCode)
				delete from MedicalRecord where ReferenceCode=@SurgeriesCode
				delete from SurgicalCrew where SurgeriesCode=@SurgeriesCode
				delete from Surgeries where SurgeriesCode=@SurgeriesCode
				update SuggestedServiceReceipt set status=0 where ReceiptID in(select IDSuggested from Surgeries where SurgeriesCode=@SurgeriesCode)
				set @iresult =1
			end
	end
	else
	begin
		set @iresult =-1
	end
end
go
if exists(select name from sysobjects where name like'%pro_Ins_SurgicalCrew%')
	drop procedure pro_Ins_SurgicalCrew
go
create procedure pro_Ins_SurgicalCrew
(
	@SurgeriesCode varchar(15),
	@EmployeeCode varchar(50),
	@PositionCode int
)
as
begin
	declare @STT numeric(18,0)
	set @STT = (select max(RowID) from SurgicalCrew)+1
	if @STT>0
	begin
		insert into SurgicalCrew(RowID,SurgeriesCode,IDate,EmployeeCode,PositionCode)values(@STT,@SurgeriesCode,GETDATE(),@EmployeeCode,@PositionCode)
	end
	else
		insert into SurgicalCrew(RowID,SurgeriesCode,IDate,EmployeeCode,PositionCode)values(1,@SurgeriesCode,GETDATE(),@EmployeeCode,@PositionCode)
end
go
---------------------------------- Exec Nghe Nghiep
if exists(select name from sysobjects where name like'%pro_Ins_Career%')
	drop procedure pro_Ins_Career
go
create procedure pro_Ins_Career
(
	@CareerCode varchar(10),
	@CareerName nvarchar(250)
)
as
begin
	if exists(select CareerCode from Career where CareerCode=@CareerCode)
	begin
		update Career set CareerName=@CareerName where CareerCode=@CareerCode
	end
	else
	begin
		declare @_TempCode varchar(10)
		declare @_stt decimal(18,0)
		set @_stt = (select top(1) CONVERT(decimal(8,0),right (CareerCode,8)) maxcode from Career order by CONVERT(decimal(8,0),RIGHT(CareerCode,8)) desc)+1
		print @_stt
		if(@_stt<=9)
			begin
				set @_TempCode = 'NN0000000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_TempCode = 'NN000000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_TempCode = 'NN00000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_TempCode = 'NN0000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>9999 and @_stt<=99999)
			begin
				set @_TempCode = 'NN000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>99999 and @_stt<=999999)
			begin
				set @_TempCode = 'NN00'+convert(varchar(10),@_stt)
			end
		else if(@_stt>999999 and @_stt<=9999999)
			begin
				set @_TempCode = 'NN0'+convert(varchar(10),@_stt)
			end
		else if(@_stt>9999999 and @_stt<=99999999)
			begin
				set @_TempCode = 'NN'+convert(varchar(10),@_stt)
			end
		else
			begin
				set @_TempCode = 'NN00000001'
			end
		insert into Career(CareerCode,CareerName) values(@_TempCode,@CareerName)
	end
end
go
---exec pro_Ins_Career '','kkkkkk'
if exists(select name from sysobjects where name like'%pro_Del_Career%')
	drop procedure pro_Del_Career
go
create procedure pro_Del_Career
(
	@CareerCode varchar(10),
	@iresult int output
)
as
begin
	if exists(select CareerCode from Introducer where CareerCode=@CareerCode)
		set @iresult =-1
	else
	begin
		delete Career where CareerCode=@CareerCode
		set @iresult =1
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_ServiceCategory%')
	drop procedure pro_Del_ServiceCategory
go
create procedure pro_Del_ServiceCategory
(
	@ServiceCategoryCode varchar(50),
	@iresult int output
)
as
begin
	if exists(select ServiceCategoryCode from [Service] where ServiceCategoryCode=@ServiceCategoryCode)
		set @iresult =-1
	else
	begin
		delete ServiceCategory where ServiceCategoryCode=@ServiceCategoryCode
		set @iresult =1
	end
end
go
go
---------------------------------- Exec Nghe Nghiep
if exists(select name from sysobjects where name like'%pro_Ins_Career%')
	drop procedure pro_Ins_Career
go
create procedure pro_Ins_Career
(
	@CareerCode varchar(10),
	@CareerName nvarchar(250)
)
as
begin
	if exists(select CareerCode from Career where CareerCode=@CareerCode)
	begin
		update Career set CareerName=@CareerName where CareerCode=@CareerCode
	end
	else
	begin
		declare @_TempCode varchar(10)
		declare @_stt decimal(18,0)
		set @_stt = (select top(1) CONVERT(decimal(8,0),right (CareerCode,8)) maxcode from Career order by CONVERT(decimal(8,0),RIGHT(CareerCode,8)) desc)+1
		print @_stt
		if(@_stt<=9)
			begin
				set @_TempCode = 'NN0000000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_TempCode = 'NN000000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_TempCode = 'NN00000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_TempCode = 'NN0000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>9999 and @_stt<=99999)
			begin
				set @_TempCode = 'NN000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>99999 and @_stt<=999999)
			begin
				set @_TempCode = 'NN00'+convert(varchar(10),@_stt)
			end
		else if(@_stt>999999 and @_stt<=9999999)
			begin
				set @_TempCode = 'NN0'+convert(varchar(10),@_stt)
			end
		else if(@_stt>9999999 and @_stt<=99999999)
			begin
				set @_TempCode = 'NN'+convert(varchar(10),@_stt)
			end
		else
			begin
				set @_TempCode = 'NN00000001'
			end
		insert into Career(CareerCode,CareerName) values(@_TempCode,@CareerName)
	end
end
go
---exec pro_Ins_Career '','kkkkkk'
if exists(select name from sysobjects where name like'%pro_Del_Career%')
	drop procedure pro_Del_Career
go
create procedure pro_Del_Career
(
	@CareerCode varchar(10),
	@iresult int output
)
as
begin
	if exists(select CareerCode from Introducer where CareerCode=@CareerCode)
		set @iresult =-1
	else
	begin
		delete Career where CareerCode=@CareerCode
		set @iresult =1
	end
end
go
-------------------------------------Exec table Nguoi Gioi Thieu
if exists(select name from sysobjects where name like'%pro_Ins_Introducer%')
	drop procedure pro_Ins_Introducer
go
create procedure pro_Ins_Introducer
(
	@IntroCode varchar(10),
	@IntroName nvarchar(max),
	@Sex int,
	@Mobile nvarchar(50),
	@IDCard nvarchar(100),
	@Address nvarchar(250),
	@Birthday datetime,
	@CareerCode varchar(10),
	@EmployeeCode varchar(50),
	@Note nvarchar(250),
	@iresult int output
)
as
begin
	if exists(select IntroCode from Introducer where IntroCode=@IntroCode)
	begin
		update Introducer set IntroName=@IntroName,Sex=@Sex,Mobile=@Mobile,IDCard=@IDCard,[Address]=@Address,Birthday=@Birthday,CareerCode=@CareerCode,EmployeeCode=@EmployeeCode,Note=@Note where IntroCode=@IntroCode
		set @iresult = 1
	end
	else
	begin
		declare @_TempCode varchar(10)
		declare @_stt decimal(8,0)
		declare @RowID decimal(18,0)
		set @RowID = (select (ISNULL(MAX(Rowid),0) +1) STT from Introducer)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(IntroCode,8)) maxcode from Introducer order by RowID desc)+1
		if(@_stt<=9)
			begin
				set @_TempCode = 'GT0000000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_TempCode = 'GT000000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_TempCode = 'GT00000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_TempCode = 'GT0000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>9999 and @_stt<=99999)
			begin
				set @_TempCode = 'GT000'+convert(varchar(10),@_stt)
			end
		else if(@_stt>99999 and @_stt<=999999)
			begin
				set @_TempCode = 'GT00'+convert(varchar(10),@_stt)
			end
		else if(@_stt>999999 and @_stt<=9999999)
			begin
				set @_TempCode = 'GT0'+convert(varchar(10),@_stt)
			end
		else if(@_stt>9999999 and @_stt<=99999999)
			begin
				set @_TempCode = 'GT'+convert(varchar(10),@_stt)
			end
		else
			begin
				set @_TempCode = 'GT00000001'
			end
		insert into Introducer(IntroCode,IntroName,Sex,Mobile,IDCard,[Address],Birthday,CareerCode,EmployeeCode,Note,RowID) values(@_TempCode,@IntroName,@Sex,@Mobile,@IDCard,@Address,@Birthday,@CareerCode,@EmployeeCode,@Note,@RowID)
		set @iresult = 1
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_Introducer%')
	drop procedure pro_Del_Introducer
go
create procedure pro_Del_Introducer
(
	@IntroCode varchar(10),
	@iresult int output
)
as
begin
	if exists(select IntroCode from BanksAccount where IntroCode=@IntroCode)
		set @iresult =-1
	else
	begin
		delete Introducer where IntroCode=@IntroCode
		set @iresult =1
	end
end
go
------------------------------ Quan ly dinh duong
if exists(select name from sysobjects where name like'%pro_Del_FoodCategory%')
	drop procedure pro_Del_FoodCategory
go
create procedure pro_Del_FoodCategory
(
	@FoodCategoryID int,
	@iresult int output
)
as
begin
	if exists(select FoodCategoryID from Catalog_Food where FoodCategoryID=@FoodCategoryID)
		set @iresult =-1
	else
	begin
		delete FoodCategory where FoodCategoryID=@FoodCategoryID
		set @iresult =1
	end
end
go
------------------------------------- Khai bao nguyen lieu dinh duong
if exists(select name from sysobjects where name like'%pro_Ins_Catalog_Food%')
	drop procedure pro_Ins_Catalog_Food
go
create procedure pro_Ins_Catalog_Food
(
	@Catalog_FoodCode varchar(6),
	@FoodCategoryID int,
	@Catalog_FoodName nvarchar(500),
	@EmployeeCode varchar(50),
	@UnitOfRawID int,
	@iresult int output
)
as
begin
	if exists(select Catalog_FoodCode from Catalog_Food where Catalog_FoodCode=@Catalog_FoodCode)
	begin
		update Catalog_Food set FoodCategoryID=@FoodCategoryID,Catalog_FoodName=@Catalog_FoodName,EmployeeCode=@EmployeeCode,IDate=GETDATE(),UnitOfRawID=@UnitOfRawID where Catalog_FoodCode=@Catalog_FoodCode
		set @iresult = 1
	end
	else
	begin
		declare @_TempCode varchar(10)
		declare @_stt decimal(4,0)
		set @_stt = (select(isnull(MAX(CONVERT(int,SUBSTRING(Catalog_FoodCode,3,4))),0) +1) maxcode from Catalog_Food)
		set @_TempCode = 'GV'+convert(varchar(4),@_stt)
		insert into Catalog_Food(Catalog_FoodCode,FoodCategoryID,Catalog_FoodName,EmployeeCode,IDate,UnitOfRawID) values(@_TempCode,@FoodCategoryID,@Catalog_FoodName,@EmployeeCode,GETDATE(),@UnitOfRawID)
		set @iresult = 1
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_Catalog_Food%')
	drop procedure pro_Del_Catalog_Food
go
create procedure pro_Del_Catalog_Food
(
	@Catalog_FoodCode varchar(6),
	@iresult int output
)
as
begin
	if exists(select Catalog_FoodCode from FoodDetail where Catalog_FoodCode=@Catalog_FoodCode)
		set @iresult =-1
	else
	begin
		delete Catalog_Food where Catalog_FoodCode=@Catalog_FoodCode
		set @iresult =1
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_Catalog_Food%')
	drop procedure pro_Del_Catalog_Food
go
create procedure pro_Del_Catalog_Food
(
	@Catalog_FoodCode varchar(6),
	@iresult int output
)
as
begin
	if exists(select Catalog_FoodCode from FoodDetail where Catalog_FoodCode=@Catalog_FoodCode)
		set @iresult =-1
	else
	begin
		delete Catalog_Food where Catalog_FoodCode=@Catalog_FoodCode
		set @iresult =1
	end
end
go
------------------------------------- Cong khai tai chinh dinh duong
if exists(select name from sysobjects where name like'%pro_Ins_FoodEntry%')
	drop procedure pro_Ins_FoodEntry
go
create procedure pro_Ins_FoodEntry
(
	@FoodEntryID decimal(18,0),
	@Content nvarchar(500),
	@EmployeeCode varchar(50),
	@Amount decimal(18,4),
	@Quantity decimal(18,4),
	@Price decimal(18,4),
	@WorkDate datetime,
	@iresult decimal(18,0) output
)
as
begin
	if exists(select FoodEntryID from FoodEntry where FoodEntryID=@FoodEntryID)
	begin
		update FoodEntry set Content=@Content,EmployeeCode=@EmployeeCode,Amount=@Amount,WorkDate=@WorkDate,Quantity=@Quantity,Price=@Price where FoodEntryID=@FoodEntryID
		set @iresult = @FoodEntryID
	end
	else
	begin
		declare @_TempID decimal(18,0)
		set @_TempID = (select(isnull(MAX(FoodEntryID),0) +1) maxcode from FoodEntry)
		insert into FoodEntry(FoodEntryID,Content,EmployeeCode,Amount,WorkDate,IDate,Quantity,Price) values(@_TempID,@Content,@EmployeeCode,@Amount,@WorkDate,GETDATE(),@Quantity,@Price)
		set @iresult = @_TempID
	end
end
go
if exists(select name from sysobjects where name like'%pro_Ins_FoodDetail%')
	drop procedure pro_Ins_FoodDetail
go
create procedure pro_Ins_FoodDetail
(
	@FoodDetailID decimal(18,0),
	@FoodEntryID decimal(18,0),
	@Catalog_FoodCode varchar(6),
	@Price decimal(18,4),
	@Quantity decimal(18,0),
	@Amount decimal(18,4),
	@EmployeeCode varchar(50),
	@Note nvarchar(250),
	@iresult int output
)
as
begin
	if exists(select FoodDetailID from FoodDetail where FoodDetailID=@FoodDetailID)
	begin
		update FoodDetail set FoodEntryID=@FoodEntryID,Catalog_FoodCode=@Catalog_FoodCode,Price=@Price,Quantity=@Quantity,Amount=@Amount,EmployeeCode=@EmployeeCode,Note=@Note where FoodDetailID=@FoodDetailID
		set @iresult = 1
	end
	else
	begin
		declare @_TempID decimal(18,0)
		set @_TempID = (select(isnull(MAX(FoodDetailID),0) +1) maxcode from FoodDetail)
		insert into FoodDetail(FoodDetailID,FoodEntryID,Catalog_FoodCode,Price,Quantity,Amount,EmployeeCode,Note,IDate) values(@_TempID,@FoodEntryID,@Catalog_FoodCode,@Price,@Quantity,@Amount,@EmployeeCode,@Note,GETDATE())
		set @iresult = 1
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_FoodDetail%')
	drop procedure pro_Del_FoodDetail
go
create procedure pro_Del_FoodDetail
(
	@FoodDetailID decimal(18,0),
	@FoodEntryID decimal(18,0),
	@iresult int output
)
as
begin
	declare @Count int
	if exists(select FoodDetailID from FoodDetail where FoodDetailID=@FoodDetailID )
	begin
		delete from FoodDetail where FoodDetailID=@FoodDetailID
		set @Count =(select COUNT(*) sl from FoodDetail where FoodEntryID=@FoodEntryID)
		if @Count<=0
			delete from FoodEntry where FoodEntryID=@FoodEntryID
		set @iresult =1
	end
	else
		set @iresult =-1
end
go
----------------------------- Don vi tinh nguyen lieu dinh duong
if exists(select name from sysobjects where name like'%pro_Ins_UnitOfRaw%')
	drop procedure pro_Ins_UnitOfRaw
go
create procedure pro_Ins_UnitOfRaw
(
	@UnitOfRawID int,
	@UnitOfRawName nvarchar(250),
	@iresult int output
)
as
begin
	if exists(select UnitOfRawID from UnitOfRaw where UnitOfRawID=@UnitOfRawID)
	begin
		update UnitOfRaw set UnitOfRawName=@UnitOfRawName where UnitOfRawID=@UnitOfRawID
		set @iresult = 1
	end
	else
	begin
		declare @_TempID int
		set @_TempID = (select(isnull(MAX(UnitOfRawID),0) +1) maxcode from UnitOfRaw)
		insert into UnitOfRaw(UnitOfRawID,UnitOfRawName,IDate) values(@_TempID,@UnitOfRawName,GETDATE())
		set @iresult = 1
	end
end
go
if exists(select name from sysobjects where name like'%pro_Del_UnitOfRaw%')
	drop procedure pro_Del_UnitOfRaw
go
create procedure pro_Del_UnitOfRaw
(
	@UnitOfRawID int,
	@iresult int output
)
as
begin
	if exists(select UnitOfRawID from Catalog_Food where UnitOfRawID=@UnitOfRawID)
		set @iresult =-1
	else
	begin
		delete from UnitOfRaw where UnitOfRawID=@UnitOfRawID
		set @iresult =1
	end
end
go
--------------------------------- Print Report
/*
if exists(select name from sysobjects where name like'%pro_PrintChiDinh%')
	drop procedure pro_PrintChiDinh
go
create procedure pro_PrintChiDinh
(
	@RefID numeric(18,0),
	@PatientCode varchar(50),
	@ReceiptID varchar(250)
)
as
begin
	select a.ReceiptID,a.DepartmentCode,a.ServiceCode,a.ServicePrice,a.DisparityPrice,a.Status,a.Paid,a.PatientCode,
	a.ObjectCode,a.WorkDate,b.PatientName,b.PatientAddress,b.PatientAge,c.ObjectName,
	d.DepartmentName,e.TraiTuyen,e.StartDate,e.EndDate,e.Serial,e.KCBBDCode,f.KCBBDName,(case when PatientGender=0 then N'Nữ' else N'Nam' end) PatientGenderName,b.PatientBirthyear,
	g.ServiceName
	from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode inner join [Object] c on a.ObjectCode=c.ObjectCode
	inner join Department d on a.DepartmentCode=d.DepartmentCode left join BHYT e on a.PatientCode=e.PatientCode and a.RefID=e.PatientReceiveID
	left join KCBBD f on e.KCBBDCode=f.KCBBDCode and e.Hide=0 inner join Service g on a.ServiceCode = g.ServiceCode
	where a.RefID=@RefID and a.PatientCode=@PatientCode and a.ReceiptID in(@ReceiptID)
end
go*/
--------------------------------- get Waiting
-- exec pro_PatientWaiting '04/27/2014',0,1,'KP0002',0,'05/02/2014'
if exists(select name from sysobjects where name ='pro_PatientWaiting' and type='P')
	drop procedure pro_PatientWaiting
go
create procedure pro_PatientWaiting
(
	@FromDate char(10),
	@Status int,
	@PatientType int,
	@DepartmentCode varchar(50),
	@Paid int,
	@ToDate char(10),
	@EmployeeCodeDoctor varchar(50)
)
as
	if @Status=0
	begin
		if @Paid=0
		begin
			select a.PatientReceiveID,a.PatientCode,a.CreateDate,b.PatientName,a.Status Statusrv,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
			(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,d.ObjectCard,e.STT,a.PatientType,e.ReceiptID,'' as MedicalRecordCode,e.ServiceCode,e.Status,e1.ServiceName,e.Paid,e.ReferenceCode
			from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode 
			inner join [Object] d on a.ObjectCode=d.ObjectCode inner join SuggestedServiceReceipt e on a.PatientReceiveID=e.RefID
			inner join Department c on e.DepartmentCode=c.DepartmentCode inner join [Service] e1 on e.ServiceCode=e1.ServiceCode
			where e.[Status]=@Status 
			and convert(date,a.CreateDate,103) >= convert(date,@FromDate,103) and convert(date,a.CreateDate,103) <= convert(date,@ToDate,103)
			and a.PatientType=@PatientType and e.DepartmentCode=@DepartmentCode and e.Note='TIEPDON'
			and e.ReceiptID_DisparityPrice=0
			order by e.STT asc
		end
		else
		begin
			select a.PatientReceiveID,a.PatientCode,a.CreateDate,b.PatientName,a.Status Statusrv,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
			(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,d.ObjectCard,e.STT,a.PatientType,e.ReceiptID,'' as MedicalRecordCode,e.ServiceCode,e.Status,e1.ServiceName,e.Paid,e.ReferenceCode
			from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode 
			inner join Object d on a.ObjectCode=d.ObjectCode inner join SuggestedServiceReceipt e on a.PatientReceiveID=e.RefID and e.Note='TIEPDON' and e.DepartmentCode=@DepartmentCode
			inner join Department c on e.DepartmentCode=c.DepartmentCode inner join Service e1 on e.ServiceCode=e1.ServiceCode
			where e.[Status]=@Status 
			--and convert(date,e.CreateDate,103) between @FromDate and @ToDate
			and convert(date,e.CreateDate,103) >= convert(date,@FromDate,103) and convert(date,e.CreateDate,103) <= convert(date,@ToDate,103)
			and a.PatientType=@PatientType and e.DepartmentCode=@DepartmentCode and (a.ObjectCode=1 or e.Paid=1 or e.ServicePrice=0)
			and e.ReceiptID_DisparityPrice=0
			order by e.STT asc
		end
	end
	else if @Status=1
	begin
		select distinct a.PatientReceiveID,a.PatientCode,c.PostingDate CreateDate,b.PatientName,a.Status Statusrv,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
		(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,d.ObjectCard,e.STT,a.PatientType,c.MedicalRecordCode,e.ServiceCode,c.Status,e1.ServiceName,e.Paid,e.ReferenceCode,e.ReceiptID
		from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode inner join MedicalRecord c on a.PatientReceiveID=c.PatientReceiveID 
		inner join [Object] d on a.ObjectCode=d.ObjectCode inner join SuggestedServiceReceipt e on a.PatientReceiveID=e.RefID and e.DepartmentCode=@DepartmentCode inner join Service e1 on e.ServiceCode=e1.ServiceCode
		where e.Status=1
		and convert(date,c.PostingDate,103) >= convert(date,@FromDate,103) and convert(date,c.PostingDate,103) <= convert(date,@ToDate,103)
		and a.PatientType=@PatientType and c.DepartmentCode=@DepartmentCode 
		and c.TackleCode=1
		and e.ReceiptID_DisparityPrice=0
		order by e.STT asc
	end
	else
	begin
		select distinct a.PatientReceiveID,a.PatientCode,c.PostingDate CreateDate,b.PatientName,a.Status Statusrv,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
		(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,d.ObjectCard,e.STT,a.PatientType,c.MedicalRecordCode,e.ServiceCode,c.Status,e1.ServiceName,e.Paid,e.ReferenceCode,e.ReceiptID
		from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode inner join MedicalRecord c on a.PatientReceiveID=c.PatientReceiveID 
		inner join [Object] d on a.ObjectCode=d.ObjectCode inner join SuggestedServiceReceipt e on a.PatientReceiveID=e.RefID and e.DepartmentCode=@DepartmentCode inner join Service e1 on e.ServiceCode=e1.ServiceCode
		where e.Status=1
		and convert(date,c.PostingDate,103) >= convert(date,@FromDate,103) and convert(date,c.PostingDate,103) <= convert(date,@ToDate,103)
		and a.PatientType=@PatientType and c.DepartmentCode=@DepartmentCode
		and c.TackleCode<>1
		and e.ReceiptID_DisparityPrice=0
		order by e.STT asc
	end
go
if exists(select name from sysobjects where name ='pro_GetServicePatient')
	drop procedure pro_GetServicePatient
go
create procedure pro_GetServicePatient
(

	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(50)
)
as
	select a.ReceiptID,a.ServiceCode,b.ServiceName,b2.ServiceGroupName,a.CreateDate WorkDate,(case a.Status when 0 then '' when 1 then N'Đã thực hiện' else N'Đang lấy mẫu' end) StatusName,a.Status,a.Paid, 0 as [Check],a.EmployeeCodeDoctor,b2.ServiceModuleCode
	from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b1.ServiceGroupCode=b2.ServiceGroupCode
	where a.RefID=@PatientReceiveID and a.PatientCode=@PatientCode and a.ServiceCode not in('DV000000') and a.ReceiptID_DisparityPrice=0
	order by b2.STT
go
---exec pro_WaitingForEmergency '06/01/2014',1,2,'KP0011',0,'06/11/2014'
if exists(select name from sysobjects where name ='pro_WaitingForEmergency')
	drop procedure pro_WaitingForEmergency
go
create procedure pro_WaitingForEmergency
(
	@Status int,
	@PatientType int,
	@DepartmentCode varchar(50),
	@FromDate date,
	@Todate date
)
as
	--declare @iDate int
	--declare @iValues int
	--select @iDate=CONVERT(int,Description),@iValues=[Values] from SystemParameter where RowID=4
	if @Status=0
	begin
		select a.PatientReceiveID,a.PatientCode,a.CreateDate,b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
		(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,d.ObjectCard,e.STT,a.PatientType,e.ReceiptID,'' MedicalEmergencyCode
		from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode 
		inner join Object d on a.ObjectCode=d.ObjectCode inner join SuggestedServiceReceipt e on a.PatientReceiveID=e.RefID and e.Note='TIEPDON'
		inner join Department c on e.DepartmentCode=c.DepartmentCode
		where a.Status=@Status and a.PatientType=@PatientType and e.DepartmentCode=@DepartmentCode and convert(date,a.CreateDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103)
		order by a.CreateDate desc
	end
	else if @Status=1
	begin
		select a.PatientReceiveID,a.PatientCode,a.CreateDate,b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
		(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,d.ObjectCard,e.STT,a.PatientType,e.ReceiptID,c.MedicalEmergencyCode
		from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode inner join MedicalEmergency c on a.PatientReceiveID=c.PatientReceiveID 
		inner join [Object] d on a.ObjectCode=d.ObjectCode inner join SuggestedServiceReceipt e on a.PatientReceiveID=e.RefID and e.Note='TIEPDON'
		where a.Status=@Status and a.PatientType=@PatientType and c.DepartmentCode=@DepartmentCode and c.DepartmentCode=e.DepartmentCode and convert(date,a.CreateDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103)
		order by a.CreateDate desc
	end
	else
	begin
		select a.PatientReceiveID,a.PatientCode,a.CreateDate,b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
		(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,d.ObjectCard,e.STT,a.PatientType,e.ReceiptID,c.MedicalEmergencyCode
		from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode inner join MedicalEmergency c on a.PatientReceiveID=c.PatientReceiveID 
		inner join [Object] d on a.ObjectCode=d.ObjectCode inner join SuggestedServiceReceipt e on a.PatientReceiveID=e.RefID and e.Note='TIEPDON'
		left join MedicalEmergencyOut f on f.MedicalEmergencyCode=c.MedicalEmergencyCode
		where a.Status=@Status and a.PatientType=@PatientType and c.DepartmentCode=@DepartmentCode and c.DepartmentCode=e.DepartmentCode
		and convert(date,f.DateOut,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103)
		order by f.DateOut desc
	end
go
if exists(select name from sysobjects where name like'%pro_PatientWaitingDetail%')
	drop procedure pro_PatientWaitingDetail
go
create procedure pro_PatientWaitingDetail
(
	@PatientReceiveID numeric(18,0),
	@DepartmentCode varchar(50),
	@ServiceCode varchar(50)
)
as
	begin
		select a.Reason,a.ObjectCode,a.ReferenceCode,b.MedicalHistory,b.Allergy,e.ServiceName,f.Pulse,f.Temperature,
		f.BloodPressure,f.Weight,a.DepartmentCode,f.Hight,f.BloodPressure1
		from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode 
		inner join SuggestedServiceReceipt c on a.PatientReceiveID=c.RefID and c.Note='TIEPDON'
		inner join [Service] e on c.ServiceCode=e.ServiceCode
		inner join Object d on a.ObjectCode=d.ObjectCode left join SurviveSign f on a.PatientReceiveID=f.RefID and a.ReferenceCode=f.ReferenceCode
		where a.PatientReceiveID=@PatientReceiveID and c.DepartmentCode=@DepartmentCode and c.ServiceCode=@ServiceCode
	end
go
--select * from SurviveSign
if exists(select name from sysobjects where name like'%pro_PatientWaitingEmergency%')
	drop procedure pro_PatientWaitingEmergency
go
create procedure pro_PatientWaitingEmergency
(
	@PatientReceiveID numeric(18,0),
	@ReceiptID numeric(18,0)
)
as
	if @ReceiptID=0
	begin
		select a.Reason,a.ObjectCode,a.ReferenceCode,b.MedicalHistory,b.Allergy,e.ServiceName,f.Pulse,f.Temperature,
		f.BloodPressure,f.Weight,a.DepartmentCode,f.Hight,f.BloodPressure1
		from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode 
		inner join SuggestedServiceReceipt c on a.PatientReceiveID=c.RefID and c.Note='TIEPDON'
		inner join [Service] e on c.ServiceCode=e.ServiceCode
		inner join Object d on a.ObjectCode=d.ObjectCode left join SurviveSign f on a.PatientReceiveID=f.RefID and a.ReferenceCode=f.ReferenceCode
		where a.PatientReceiveID=@PatientReceiveID
	end
	else
	begin
		select a.Reason,a.ObjectCode,a.ReferenceCode,b.MedicalHistory,b.Allergy,e.ServiceName,f.Pulse,f.Temperature,
		f.BloodPressure,f.Weight,a.DepartmentCode,f.Hight,f.BloodPressure1
		from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode 
		inner join SuggestedServiceReceipt c on a.PatientReceiveID=c.RefID and c.Note='TIEPDON'
		inner join [Service] e on c.ServiceCode=e.ServiceCode
		inner join Object d on a.ObjectCode=d.ObjectCode left join SurviveSign f on a.PatientReceiveID=f.RefID and a.ReferenceCode=f.ReferenceCode
		where a.PatientReceiveID=@PatientReceiveID and c.ReceiptID=@ReceiptID
	end
go
------------------------------------- Cho thuc hien Thu thuat
-- exec pro_WaitingService '06/10/2014',0,1,'KP0004',1,5
if exists(select name from sysobjects where name like'%pro_WaitingService%')
	drop procedure pro_WaitingService
go
create procedure pro_WaitingService
(
	@Date datetime,
	@Status int,
	--@PatientType int,
	@DepartmentCode varchar(50),
	@Paid int,
	@MenuID int
)
as
	declare @QuanlityDate nvarchar(250)
	declare @EndDate datetime
	select @QuanlityDate=[Description] from SystemParameter where RowID=300
	set @EndDate = @Date - CONVERT(int,@QuanlityDate) 
	--convert(char(10),@CreateDate,103)
	if @Status=0
	begin
		if @Paid=0
		begin
			select a.ReceiptID,a.RefID,a.PatientCode,a.CreateDate,b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
			(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,e.ServiceName,a.ServiceCode,a.ReferenceCode,c.DepartmentName
			from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode left join Department c on a.DepartmentCodeOrder=c.DepartmentCode
			inner join Object d on a.ObjectCode=d.ObjectCode inner join [Service] e on a.ServiceCode=e.ServiceCode
			where a.Status=@Status and convert(date,a.CreateDate,103) between convert(date,@EndDate,103) and convert(date,@Date,103)
			and a.DepartmentCode=@DepartmentCode and a.Note<>'TIEPDON' and a.ServiceCode in(select ServiceCode from ServiceMenuForService where ServiceMenuid=@MenuID)
			order by a.CreateDate desc
		end
		else
		begin
			select a.ReceiptID,a.RefID,a.PatientCode,a.CreateDate,b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
			(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,e.ServiceName,a.ServiceCode,a.ReferenceCode,c.DepartmentName
			from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode left join Department c on a.DepartmentCodeOrder=c.DepartmentCode
			inner join Object d on a.ObjectCode=d.ObjectCode inner join [Service] e on a.ServiceCode=e.ServiceCode
			where a.Status=@Status and convert(date,a.CreateDate,103) between convert(date,@EndDate,103) and convert(date,@Date,103)
			and a.DepartmentCode=@DepartmentCode and a.Note<>'TIEPDON' and (a.ObjectCode=1 or a.Paid=1) and a.ServiceCode in(select ServiceCode from ServiceMenuForService where ServiceMenuid=@MenuID)
			order by a.CreateDate desc
		end
	end
	else
	begin
		select a.ReceiptID,a.RefID,a.PatientCode,a.CreateDate,b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
		(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,e.ServiceName,a.ServiceCode,a.ReferenceCode,c.DepartmentName
		from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode left join Department c on a.DepartmentCodeOrder=c.DepartmentCode
		inner join Object d on a.ObjectCode=d.ObjectCode inner join [Service] e on a.ServiceCode=e.ServiceCode
		inner join ServiceRadiologyEntry f on a.ReceiptID =f.SuggestedID
		where a.Status=@Status and convert(date,a.CreateDate,103) between convert(date,@EndDate,103) and convert(date,@Date,103)
		and a.DepartmentCode=@DepartmentCode and f.done=1 and a.ServiceCode in(select ServiceCode from ServiceMenuForService where ServiceMenuid=@MenuID)
		order by a.CreateDate desc
	end
go
if exists(select name from sysobjects where name ='pro_WaitingServiceForDate')
	drop procedure pro_WaitingServiceForDate
go
create procedure pro_WaitingServiceForDate
(
	@DateFrom datetime,
	@DateTo datetime,
	@Status int,
	@DepartmentCode varchar(50),
	@Paid int,
	@MenuID int,
	@EmployeeCodeDoctor varchar(50)
)
as
	if @Status=0
	begin
		if @Paid=0
		begin
			select a.ReceiptID,a.RefID,a.PatientCode,a.CreateDate,b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
			(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,e.ServiceName,a.ServiceCode,a.ReferenceCode,c.DepartmentName,a.PatientType,a.Paid, '' as EmployeeNameDoctor,a.STT
			from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode left join Department c on a.DepartmentCodeOrder=c.DepartmentCode
			inner join Object d on a.ObjectCode=d.ObjectCode inner join [Service] e on a.ServiceCode=e.ServiceCode
			where a.Status=@Status and convert(date,a.CreateDate,103) between convert(date,@DateFrom,103) and convert(date,@DateTo,103)
			and a.DepartmentCode=@DepartmentCode and a.Note<>'TIEPDON' and a.ServiceCode in(select ServiceCode from ServiceMenuForService where ServiceMenuid=@MenuID)
			and a.ReceiptID_DisparityPrice=0
			order by convert(date,a.CreateDate,103), a.STT asc
		end
		else
		begin
			select a.ReceiptID,a.RefID,a.PatientCode,a.CreateDate,b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
			(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,e.ServiceName,a.ServiceCode,a.ReferenceCode,c.DepartmentName,a.PatientType,a.Paid, '' as EmployeeNameDoctor,a.STT
			from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode left join Department c on a.DepartmentCodeOrder=c.DepartmentCode
			inner join Object d on a.ObjectCode=d.ObjectCode inner join [Service] e on a.ServiceCode=e.ServiceCode
			where a.Status=@Status and convert(date,a.CreateDate,103) between convert(date,@DateFrom,103) and convert(date,@DateTo,103)
			and a.DepartmentCode=@DepartmentCode and a.Note<>'TIEPDON' and (a.ObjectCode=1 or a.Paid=1) and a.ServiceCode in(select ServiceCode from ServiceMenuForService where ServiceMenuid=@MenuID)
			and a.ReceiptID_DisparityPrice=0
			order by convert(date,a.CreateDate,103), a.STT asc
		end
	end
	else
	begin
		select a.ReceiptID,a.RefID,a.PatientCode,a.CreateDate,b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
		(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,e.ServiceName,a.ServiceCode,a.ReferenceCode,c.DepartmentName,a.PatientType,a.Paid,f1.EmployeeName EmployeeNameDoctor,a.STT
		from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode left join Department c on a.DepartmentCodeOrder=c.DepartmentCode
		inner join Object d on a.ObjectCode=d.ObjectCode inner join [Service] e on a.ServiceCode=e.ServiceCode
		inner join ServiceRadiologyEntry f on a.ReceiptID =f.SuggestedID inner join Employee f1 on f.EmployeeCodeDoctor=f1.EmployeeCode
		where a.Status=@Status and convert(date,f.PostingDate,103) between convert(date,@DateFrom,103) and convert(date,@DateTo,103)
		and a.DepartmentCode=@DepartmentCode and f.done=1 and a.ServiceCode in(select ServiceCode from ServiceMenuForService where ServiceMenuid=@MenuID) and f.EmployeeCodeDoctor=@EmployeeCodeDoctor
		and a.ReceiptID_DisparityPrice=0
		order by convert(date,a.CreateDate,103), a.STT asc
	end
go
if exists(select name from sysobjects where name ='pro_WaitingServicePTT')
	drop procedure pro_WaitingServicePTT
go
create procedure pro_WaitingServicePTT
(
	@DateFrom datetime,
	@DateTo datetime,
	@Status int,
	--@PatientType int,
	@DepartmentCode varchar(50),
	@Paid int,
	@MenuID int
)
as
	--declare @QuanlityDate nvarchar(250)
	--declare @EndDate datetime
	--select @QuanlityDate=[Description] from SystemParameter where RowID=300
	--set @EndDate = @Date - CONVERT(int,@QuanlityDate) 
	--convert(char(10),@CreateDate,103)
	if @Status=0
	begin
		if @Paid=0
		begin
			select a.ReceiptID,a.RefID,a.PatientCode,a.CreateDate,b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
			(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,e.ServiceName,a.ServiceCode,a.ReferenceCode,c.DepartmentName,a.Paid,a.STT
			from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode left join Department c on a.DepartmentCodeOrder=c.DepartmentCode
			inner join Object d on a.ObjectCode=d.ObjectCode inner join [Service] e on a.ServiceCode=e.ServiceCode
			where a.Status=@Status and convert(date,a.CreateDate,103) between convert(date,@DateFrom,103) and convert(date,@DateTo,103)
			and a.DepartmentCode=@DepartmentCode and a.Note<>'TIEPDON' and a.ServiceCode in(select ServiceCode from ServiceMenuForService where ServiceMenuid=@MenuID)
			order by a.WorkDate desc
		end
		else
		begin
			select a.ReceiptID,a.RefID,a.PatientCode,a.CreateDate,b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
			(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,e.ServiceName,a.ServiceCode,a.ReferenceCode,c.DepartmentName,a.Paid,a.STT
			from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode left join Department c on a.DepartmentCodeOrder=c.DepartmentCode
			inner join Object d on a.ObjectCode=d.ObjectCode inner join [Service] e on a.ServiceCode=e.ServiceCode
			where a.Status=@Status and convert(date,a.CreateDate,103) between convert(date,@DateFrom,103) and convert(date,@DateTo,103)
			and a.DepartmentCode=@DepartmentCode and a.Note<>'TIEPDON' and (a.ObjectCode=1 or a.Paid=1) and a.ServiceCode in(select ServiceCode from ServiceMenuForService where ServiceMenuid=@MenuID)
			order by a.WorkDate desc
		end
	end
	else
	begin
		select a.ReceiptID,a.RefID,a.PatientCode,a.CreateDate,b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
		(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,e.ServiceName,a.ServiceCode,a.ReferenceCode,c.DepartmentName,a.Paid,a.STT
		from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode left join Department c on a.DepartmentCodeOrder=c.DepartmentCode
		inner join Object d on a.ObjectCode=d.ObjectCode inner join [Service] e on a.ServiceCode=e.ServiceCode
		inner join Surgeries f on a.ReceiptID =f.IDSuggested
		where a.Status=@Status and convert(date,a.CreateDate,103) between convert(date,@DateFrom,103) and convert(date,@DateTo,103)
		and a.DepartmentCode=@DepartmentCode and a.ServiceCode in(select ServiceCode from ServiceMenuForService where ServiceMenuid=@MenuID)
		order by a.WorkDate desc
	end
go
if exists(select name from sysobjects where name ='pro_RptViewSurgeries')
	drop procedure pro_RptViewSurgeries
go
create procedure pro_RptViewSurgeries
(
	@SurgeriesCode varchar(15),
	@PatientReceiveID numeric(18,0)
)
as
	begin
		select a.SurgeriesCode,a.PatientCode,a.DateOn,a.TimeOn,a.DateOut,a.TimeOut,a.ICD10On,a.ICD10Out,b.DiagnosisName DiagnosisNameOn,
		b1.DiagnosisName DiagnosisNameOut,c.Names PhuongPhap, c1.Names TinhHinh, c2.Names TaiBien,a.Content,a.Note,d.ObjectName,e1.ServiceName,
		f.PatientName,(case when f.PatientGender=0 then N'Nữ' when f.PatientGender=1 then N'Nam' else N'Khác' end)PatientGenderName,
		f.PatientBirthyear,f.PatientAge,[dbo].func_PatientOfAddress(@PatientReceiveID) PatientAddress,f.MedicalHistory,f.Allergy,e2.DepartmentName,a1.DepartmentName,a2.EmployeeName EmployeeNameUpd,
		(select [dbo].func_ListSurgicalCrew (@SurgeriesCode))ListEmployeeSurgical,a.DiagnosisCustomOn,a.DiagnosisCustomOut
		from Surgeries a left join Diagnosis b on a.ICD10On=b.DiagnosisCode left join Diagnosis b1 on b1.DiagnosisCode=a.ICD10Out
		inner join Catalog_Anesthesia c on a.IDAnesthesia=c.RowID inner join Catalog_TheSituation c1 on a.IDTheSituation=c1.RowID
		inner join Catalog_Complications c2 on a.IDComplications=c2.RowID inner join Object d on a.ObjectCode=d.ObjectCode
		inner join SuggestedServiceReceipt e on a.IDSuggested=e.ReceiptID inner join Service e1 on e.ServiceCode=e1.ServiceCode
		left join Department e2 on e.DepartmentCodeOrder=e2.DepartmentCode 
		inner join Patients f on a.PatientCode=f.PatientCode
		left join Department a1 on a.DepartmentCode=a1.DepartmentCode left join Employee a2 on a.EmployeeCodeUpd=a2.EmployeeCode
		where a.SurgeriesCode=@SurgeriesCode
	end
go
------------------------------------- Cho thuc hien CLS for XetNghiem
if exists(select name from sysobjects where name ='pro_WaitingForLaboratory')
	drop procedure pro_WaitingForLaboratory
go
create procedure pro_WaitingForLaboratory
(
	@Date datetime,
	@Status int,
	--@PatientType int,
	@DepartmentCode varchar(50),
	@Paid int,
	@Menu int
	--@ServiceCategoryCode varchar(50)
)
as
	declare @QuanlityDate nvarchar(250)
	declare @EndDate datetime
	select @QuanlityDate=[Description] from SystemParameter where RowID=300
	set @EndDate = @Date - CONVERT(int,@QuanlityDate)
	declare @ServiceCategoryCode varchar(50)
	set @ServiceCategoryCode = (select top(1)b.ServiceCategoryCode
	 from ServiceMenuForService a inner join Service b on a.ServiceCode=b.ServiceCode where ServiceMenuid=@Menu
	 group by b.ServiceCategoryCode)
	if @Status=0
	begin
		if @Paid=0
		begin
			select 0 as RowIDLaboratory,a.RefID,a.PatientCode,convert(date,a.CreateDate,103) CreateDate,b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
			(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,a.ReferenceCode,e.ServiceCategoryCode,0 as STT,c.DepartmentName,e1.ServiceCategoryName
			from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode left join Department c on a.DepartmentCodeOrder=c.DepartmentCode
			inner join Object d on a.ObjectCode=d.ObjectCode inner join [Service] e on a.ServiceCode=e.ServiceCode inner join ServiceCategory e1 on e.ServiceCategoryCode=e1.ServiceCategoryCode
			where a.Status=@Status and convert(date,a.CreateDate,103) between convert(date,@EndDate,103) and convert(date,@Date,103)
			and a.DepartmentCode=@DepartmentCode and a.Note<>'TIEPDON' and a.ServiceCode in(select ServiceCode from ServiceMenuForService where ServiceMenuid=@Menu)
			group by a.RefID,a.PatientCode,convert(date,a.CreateDate,103),b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,b.PatientGender,a.ObjectCode,a.ReferenceCode,e.ServiceCategoryCode,c.DepartmentName,e1.ServiceCategoryName
			order by a.PatientCode,convert(date,a.CreateDate,103) asc
		end
		else
		begin
			select 0 as RowIDLaboratory, a.RefID,a.PatientCode,convert(date,a.CreateDate,103) CreateDate,b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
			(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,a.ReferenceCode,e.ServiceCategoryCode,0 as STT,c.DepartmentName,e1.ServiceCategoryName
			from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode left join Department c on a.DepartmentCodeOrder=c.DepartmentCode
			inner join Object d on a.ObjectCode=d.ObjectCode inner join [Service] e on a.ServiceCode=e.ServiceCode inner join ServiceCategory e1 on e.ServiceCategoryCode=e1.ServiceCategoryCode
			where a.Status=@Status and convert(date,a.CreateDate,103) between convert(date,@EndDate,103) and convert(date,@Date,103)
			and a.DepartmentCode=@DepartmentCode and a.Note<>'TIEPDON' and (a.ObjectCode=1 or a.Paid=1) and a.ServiceCode in(select ServiceCode from ServiceMenuForService where ServiceMenuid=@Menu)
			group by a.RefID,a.PatientCode,convert(date,a.CreateDate,103),b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,b.PatientGender,a.ObjectCode,a.ReferenceCode,e.ServiceCategoryCode,c.DepartmentName,e1.ServiceCategoryName
			order by a.PatientCode,convert(date,a.CreateDate,103) asc
		end
	end
	else
	begin
		select f.RowID RowIDLaboratory,a.RefID,a.PatientCode,convert(date,a.CreateDate,103) CreateDate,b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
		(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,a.ReferenceCode,e.ServiceCategoryCode,f.STT,c.DepartmentName,e1.ServiceCategoryName
		from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode left join Department c on a.DepartmentCodeOrder=c.DepartmentCode
		inner join Object d on a.ObjectCode=d.ObjectCode inner join [Service] e on a.ServiceCode=e.ServiceCode inner join ServiceCategory e1 on e.ServiceCategoryCode=e1.ServiceCategoryCode
		inner join ServiceLaboratoryEntry f on a.RefID =f.PatientReceiveID and a.PatientCode=f.PatientCode and a.ReferenceCode=f.ReferenceCode and f.ServiceCategoryCode=@ServiceCategoryCode
		where a.Status=@Status and convert(date,a.CreateDate,103) between convert(date,@EndDate,103) and convert(date,@Date,103)
		and a.DepartmentCode=@DepartmentCode and a.ServiceCode in(select ServiceCode from ServiceMenuForService where ServiceMenuid=@Menu)
		group by f.RowID,a.RefID,a.PatientCode,convert(date,a.CreateDate,103),b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,b.PatientGender,a.ObjectCode,a.ReferenceCode,e.ServiceCategoryCode,f.STT,c.DepartmentName,e1.ServiceCategoryName
		order by a.PatientCode,convert(date,a.CreateDate,103) asc
	end
go
--- exec pro_ForLaboratoryGetTemplate '06/10/2014',0,1,'KP0003',0,'LO0016'
if exists(select name from sysobjects where name ='pro_ForLaboratoryGetTemplate')
	drop procedure pro_ForLaboratoryGetTemplate
go
create procedure pro_ForLaboratoryGetTemplate
(
	@Date datetime,
	@Status int,
	--@PatientType int,
	@DepartmentCode varchar(50),
	@Paid int,
	@ServiceCategoryCode varchar(50)
)
as
	declare @QuanlityDate nvarchar(250)
	declare @BeginDate datetime
	select @QuanlityDate=[Description] from SystemParameter where RowID=300
	set @BeginDate = @Date - CONVERT(int,@QuanlityDate) 
	--convert(char(10),@CreateDate,103)
	if @Status=0
	begin
		if @Paid=0
		begin
			select distinct 0 as RowIDLaboratory,a.RefID,a.PatientCode,convert(date,a.CreateDate,103) CreateDate,b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
			(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,a.ReferenceCode,e.ServiceCategoryCode,0 as STT,c.DepartmentName
			from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode left join Department c on a.DepartmentCodeOrder=c.DepartmentCode
			inner join Object d on a.ObjectCode=d.ObjectCode inner join [Service] e on a.ServiceCode=e.ServiceCode
			where a.Status=@Status and convert(date,a.CreateDate,103) between convert(date,@BeginDate,103) and convert(date,@Date,103)
			and a.DepartmentCode=@DepartmentCode and a.Note<>'TIEPDON' and e.ServiceCategoryCode=@ServiceCategoryCode
			group by a.RefID,a.PatientCode,convert(date,a.CreateDate,103),b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,b.PatientGender,a.ObjectCode,a.ReferenceCode,e.ServiceCategoryCode,c.DepartmentName
			order by a.PatientCode,convert(date,a.CreateDate,103) asc
		end
		else
		begin
			select distinct 0 as RowIDLaboratory, a.RefID,a.PatientCode,convert(date,a.CreateDate,103) CreateDate,b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
			(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,a.ReferenceCode,e.ServiceCategoryCode,0 as STT,c.DepartmentName
			from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode inner join Department c on a.DepartmentCodeOrder=c.DepartmentCode
			inner join Object d on a.ObjectCode=d.ObjectCode inner join [Service] e on a.ServiceCode=e.ServiceCode
			where a.Status=@Status and convert(date,a.CreateDate,103) between convert(date,@BeginDate,103) and convert(date,@Date,103)
			and a.DepartmentCode=@DepartmentCode and a.Note<>'TIEPDON' and (a.ObjectCode=1 or a.Paid=1) and e.ServiceCategoryCode=@ServiceCategoryCode
			group by a.RefID,a.PatientCode,convert(date,a.CreateDate,103),b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,b.PatientGender,a.ObjectCode,a.ReferenceCode,e.ServiceCategoryCode,c.DepartmentName
			order by a.PatientCode,convert(date,a.CreateDate,103) asc
		end
	end
	else
	begin
		select distinct f.RowID RowIDLaboratory,a.RefID,a.PatientCode,convert(date,a.CreateDate,103) CreateDate,b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,
		(case when b.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,a.ReferenceCode,e.ServiceCategoryCode,f.STT,c.DepartmentName
		from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode left join Department c on a.DepartmentCodeOrder=c.DepartmentCode
		inner join Object d on a.ObjectCode=d.ObjectCode inner join [Service] e on a.ServiceCode=e.ServiceCode
		inner join ServiceLaboratoryEntry f on a.RefID =f.PatientReceiveID and a.PatientCode=f.PatientCode and a.ReferenceCode=f.ReferenceCode and f.ServiceCategoryCode=@ServiceCategoryCode
		where a.Status=@Status and convert(date,a.CreateDate,103) between convert(date,@BeginDate,103) and convert(date,@Date,103)
		and a.DepartmentCode=@DepartmentCode and e.ServiceCategoryCode=@ServiceCategoryCode
		group by f.RowID,a.RefID,a.PatientCode,convert(date,a.CreateDate,103),b.PatientName,a.Status,b.PatientBirthyear,b.PatientAge,b.PatientAddress,d.ObjectName,b.PatientGender,a.ObjectCode,a.ReferenceCode,e.ServiceCategoryCode,f.STT,c.DepartmentName
		order by a.PatientCode,convert(date,a.CreateDate,103) asc
	end
go
------------------------ Get chi tiet xet nghiem
if exists(select name from sysobjects where name ='Get_LaboratoryPackageDetail')
	drop procedure Get_LaboratoryPackageDetail
go
create procedure Get_LaboratoryPackageDetail
(
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(50),
	@ReferenceCode varchar(50),
	@Status int,
	@ServiceCategoryCode varchar(50),
	@RowIDLaboratoryEnTry numeric(18,0),
	@DepartmentCodeOrder varchar(10),
	@TypeResult int =1
)
as
	if @Status=0
	begin
		select a1.ReceiptID as SuggestedID,a1.ServiceCode,b.ServiceName,a.LaboratoryName,0 as RowIDLaboratoryEnTry,a.ValuesEntry,a.UnitValues,a.ValuedFemale,a.ValuedMale,a.MinValuedFemale,a.MaxValuedFemale,a.MinValuedMale,a.MaxValuedMale,0 Normal,a1.STT,convert(date,GETDATE(),103) PostingDate,a.ParameterMachine as ParameterMachine
		from SuggestedServiceReceipt a1 inner join LaboratoryPackage a2 on a1.ServiceCode=a2.ServiceCode inner join LaboratoryPackageDetail a on a2.LaboratoryPackageCode=a.LaboratoryPackageCode inner join Service b on a1.ServiceCode=b.ServiceCode 
		inner join LaboratoryTypeResult c on a2.ServiceCode=c.ServiceCode and c.TypeResult=1
		where a1.PatientCode=@PatientCode and a1.ReferenceCode=@ReferenceCode and a1.RefID=@PatientReceiveID and b.ServiceCategoryCode=@ServiceCategoryCode 
		and a1.Status=@Status and a1.DepartmentCodeOrder=@DepartmentCodeOrder 
		and a1.ReceiptID_DisparityPrice=0
		group by a1.ReceiptID,a1.ServiceCode,b.ServiceName,a.LaboratoryName,a.ValuesEntry,a.UnitValues,a.ValuedFemale,a.ValuedMale,a.MinValuedFemale,a.MaxValuedFemale,a.MinValuedMale,a.MaxValuedMale,a.STT,a.ParameterMachine,a1.DepartmentCodeOrder,a1.STT
		order by a1.STT,a.STT asc
	end
	else if @Status=1
	begin
		select a.SuggestedID,a.ServiceCode,b.ServiceName,a.LaboratoryName,a.RowIDLaboratoryEnTry,a.ValuesEntry,a.UnitValues,a.ValuedFemale,a.ValuedMale,a.MinValuedFemale,a.MaxValuedFemale,a.MinValuedMale,a.MaxValuedMale,a.Normal,a.STT,convert(date,a1.PostingDate,103) PostingDate,a.ParameterMachine
		from ServiceLaboratoryDetail a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceLaboratoryEntry a1 on a.RowIDLaboratoryEnTry=a1.RowID inner join LaboratoryTypeResult c on a.ServiceCode=c.ServiceCode and c.TypeResult=@TypeResult
		where a.ServiceCode in(
		select a.ServiceCode from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode
		where a.PatientCode=@PatientCode and a.Status=1 and a.ReferenceCode=@ReferenceCode and a.RefID=@PatientReceiveID and b.ServiceCategoryCode=@ServiceCategoryCode and a.DepartmentCodeOrder=@DepartmentCodeOrder and a.ReceiptID_DisparityPrice=0)
		and a.RowIDLaboratoryEnTry=@RowIDLaboratoryEnTry
		order by a.STT asc
	end
	else if @Status=2
	begin
		select a.SuggestedID,a.ServiceCode,b.ServiceName,a.LaboratoryName,a.RowIDLaboratoryEnTry,a.ValuesEntry,a.UnitValues,a.ValuedFemale,a.ValuedMale,a.MinValuedFemale,a.MaxValuedFemale,a.MinValuedMale,a.MaxValuedMale,a.Normal,a.STT,convert(date,a1.PostingDate,103) PostingDate,a.ParameterMachine
		from ServiceLaboratoryDetail a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceLaboratoryEntry a1 on a.RowIDLaboratoryEnTry=a1.RowID inner join LaboratoryTypeResult c on a.ServiceCode=c.ServiceCode and c.TypeResult=@TypeResult
		where a.ServiceCode in(
		select a.ServiceCode from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode
		where a.PatientCode=@PatientCode and a.Status=2 and a.ReferenceCode=@ReferenceCode and a.RefID=@PatientReceiveID and b.ServiceCategoryCode=@ServiceCategoryCode and a.DepartmentCodeOrder=@DepartmentCodeOrder and a.ReceiptID_DisparityPrice=0)
		and a.RowIDLaboratoryEnTry=@RowIDLaboratoryEnTry
		order by a.STT asc
	end
go
--- exec Get_LabServiceTemplate 5129,'15000007','DKKB000000005114','XN','LO0042',2,0
if exists(select name from sysobjects where name ='Get_LabServiceTemplate')
	drop procedure Get_LabServiceTemplate
go
create procedure Get_LabServiceTemplate
(
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(50),
	@ReferenceCode varchar(50),
	@ServiceGroupCode varchar(50),
	@ServiceCategoryCode varchar(50),
	@TypeResult int =2,
	@Status int =0
)
as
	select ISNULL(a1.RowID,0) RowIDRadiologyEntry, a.ServiceCode,b.ServiceName,a.Status,(case a.Status when 0 then N'Chưa thực hiện' when 1 then N'Đã thực hiện' else '' end) StatusName,a.ReceiptID,a.ReferenceCode,b.ServiceCategoryCode
	from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode 
	left join ServiceRadiologyEntry a1 on a.ServiceCode=a1.ServiceCode and a1.ServiceGroupCode=@ServiceGroupCode and a.ReceiptID=a1.SuggestedID and a1.PatientCode=@PatientCode and a1.PatientReceiveID=@PatientReceiveID
	inner join LaboratoryTypeResult a2 on a.ServiceCode=a2.ServiceCode
	where a.PatientCode=@PatientCode and a.ReferenceCode=@ReferenceCode and a.RefID=@PatientReceiveID and  b.ServiceGroupCode=@ServiceGroupCode and b.ServiceCategoryCode=@ServiceCategoryCode and a2.TypeResult=@TypeResult and a.Status=@Status
	order by a.STT
go
--select * from ServiceLaboratoryDetail
--select * from LaboratoryPackageDetail
--exec Get_LaboratoryPackageDetail 68,'BN00000001','DKKB000000000001',1
if exists(select name from sysobjects where name ='Get_LaboratoryDetailForSTTDATE')
	drop procedure Get_LaboratoryDetailForSTTDATE
go
create procedure Get_LaboratoryDetailForSTTDATE
(
	@STT varchar(10),
	@PostingDate datetime
)
as
	select a.SuggestedID,a.ServiceCode,b.ServiceName,a.LaboratoryName,a.RowIDLaboratoryEnTry,a.ValuesEntry,a.UnitValues,a.ValuedFemale,a.ValuedMale,a.MinValuedFemale,a.MaxValuedFemale,a.MinValuedMale,a.MaxValuedMale,a.Normal,a.STT,convert(date,a1.PostingDate,103) PostingDate,a.ParameterMachine
	from ServiceLaboratoryDetail a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceLaboratoryEntry a1 on a.RowIDLaboratoryEnTry=a1.RowID
	where a1.STT=@STT and CONVERT(date,a1.PostingDate,103)=CONVERT(date,@PostingDate,103)
	order by a.ServiceCode,a.STT asc
go
------------------------------------------------ Lấy thông tin bệnh nhân thực hiện CLS
if exists(select name from sysobjects where name ='pro_ResultRadiology')
	drop procedure pro_ResultRadiology
go
create procedure pro_ResultRadiology
(
	@SuggestedID numeric(18,0),
	@PatientReceiveID numeric(18,0)
)
as
	begin
		select a.ReceiptID,a.DepartmentCode,a.ServiceCode,a.ServicePrice,a.DisparityPrice,a.Status,a.Paid,a.PatientCode,a.ObjectCode,a.WorkDate WorkDateReceive,b.PatientName,[dbo].func_PatientOfAddress(@PatientReceiveID) PatientAddress,b.PatientAge,c.ObjectName,
		d.DepartmentName,e.TraiTuyen,e.StartDate,e.EndDate,e.Serial,e.KCBBDCode,f.KCBBDName,(case when PatientGender=0 then N'Nữ' else N'Nam' end) PatientGenderName,b.PatientBirthyear,g.ServiceName,h.Contents,h.Conclusion,h.Proposal,i.Symptoms,i.DiagnosisCode,
		u.EmployeeName EmployeeNameHand,h1.EmployeeName EmployeeNameDoctor,i.DiagnosisCustom,h.Note,h.PostingDate,g2.LabPathologicalName,CONVERT(date,a.WorkDate,103) WorkDateHand
		from PatientReceive a1 inner join SuggestedServiceReceipt a on a1.PatientReceiveID=a.RefID inner join Patients b on a.PatientCode=b.PatientCode inner join [Object] c on a1.ObjectCode=c.ObjectCode
		inner join Department d on a.DepartmentCode=d.DepartmentCode left join BHYT e on a.PatientCode=e.PatientCode and a.RefID=e.PatientReceiveID
		left join KCBBD f on e.KCBBDCode=f.KCBBDCode and e.Hide=0 inner join Service g on a.ServiceCode = g.ServiceCode LEFT join LabPatternAttach g1 on g.ServiceCategoryCode=g1.ServiceCategoryCode LEFT join LabPathological g2 on g1.LabPathologicalID=g2.LabPathologicalID
		inner join ServiceRadiologyEntry h on a.ReceiptID = h.SuggestedID left join MedicalRecord i on h.ReferenceCode=i.MedicalRecordCode and h.PatientReceiveID=i.PatientReceiveID
		left join Employee u on a.EmployeeCodeDoctor=u.EmployeeCode left join Employee h1 on h.EmployeeCodeDoctor=h1.EmployeeCode
		left join Catalog_Ward b1 on a1.WardCode=b1.WardCode left join Catalog_District b2 on a1.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on a1.ProvincialCode=b3.ProvincialCode
		where a.ReceiptID=@SuggestedID
	end
go
-- exec pro_ResultRadiology 
------------------------------------- Thong tin in don thuoc BHYT va Mua Ngoai
if exists(select name from sysobjects where name ='pro_ResultMedicalRecord')
	drop procedure pro_ResultMedicalRecord
go
create procedure pro_ResultMedicalRecord
(
	@MedicalRecordCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@Blank int=0
)
as
	if(@Blank=1)
	begin
		select a.MedicalEmergencyCode MedicalRecordCode,a.PatientReceiveID,a2.DepartmentName,a.PatientCode,0 as Status,b.PatientName,b.PatientAge,b.PatientBirthyear,(case  when b.PatientGender=1 then N'Nam' else N'Nữ' end) PatientGenderName,[dbo].func_PatientOfAddress(@PatientReceiveID) PatientAddress,a.ObjectCode,
		('('+ d.DiagnosisCode+')'+d.DiagnosisName) DiagnosisName,a.Symptoms as SymptomsName,f.ObjectName,a1.Advices as AdvicesName,h.TackleName,i.EmployeeName,'' as AppointmentDate,'' as AppointmentNote,d.DiagnosisCode,'' as DescriptionNode,'' as ContentMedicalPattern,i.EmployeeName EmployeeNameDoctor,
		a.DiagnosisCode DiagnosisCustom,a.Treatments
		 from MedicalEmergency a left join MedicalEmergencyOut a1 on a.MedicalEmergencyCode=a1.MedicalEmergencyCode inner join Department a2 on a.DepartmentCode=a2.DepartmentCode
		inner join Patients b on a.PatientCode=b.PatientCode left join Diagnosis d on a.ICD10=d.DiagnosisCode inner join Object f on a.ObjectCode = f.ObjectCode 
		left join Tackle h on a1.TackleCode = h.TackleCode inner join Employee i on a.EmployeeCode = i.EmployeeCode
		where a.MedicalEmergencyCode=@MedicalRecordCode and a.PatientReceiveID=@PatientReceiveID
	end
	else
	begin
		select a.MedicalRecordCode,a.PatientReceiveID,c.DepartmentName,a.PatientCode,a.Status,b.PatientName,b.PatientAge,b.PatientBirthyear,(case  when b.PatientGender=1 then N'Nam' else N'Nữ' end) PatientGenderName,[dbo].func_PatientOfAddress(@PatientReceiveID) PatientAddress,a.ObjectCode
		--,('('+ d.DiagnosisCode+')'+d.DiagnosisName) DiagnosisName
		,('('+ a.ICD10_Custom+')'+a.ICD10Name_Custom) DiagnosisName
		,a.Symptoms as SymptomsName,f.ObjectName,a.Advices as AdvicesName,h.TackleName,i.EmployeeName,(case when CONVERT(char(10),o.AppointmentDate,103)='01/01/1990' then '' else CONVERT(char(10),o.AppointmentDate,103) end)AppointmentDate,o.AppointmentNote
		,a.ICD10_Custom,a.DescriptionNode,a.ContentMedicalPattern,
		a1.EmployeeName EmployeeNameDoctor,a.DiagnosisCustom,a.Treatments
		from MedicalRecord a inner join Patients b on a.PatientCode=b.PatientCode inner join Department c on a.DepartmentCode=c.DepartmentCode
		--left join Diagnosis d on a.DiagnosisCode=d.RowID 
		inner join Object f on a.ObjectCode = f.ObjectCode 
		left join Tackle h on a.TackleCode = h.TackleCode inner join Employee i on a.EmployeeCode = i.EmployeeCode
		left join Employee a1 on a.EmployeeCodeDoctor=a1.EmployeeCode
		left join (select top(1) PatientCode,PatientReceiveID,AppointmentDate,AppointmentNote from PatientAppointment where PatientReceiveID=@PatientReceiveID order by AppointmentDate desc )o on a.PatientCode=o.PatientCode and a.PatientReceiveID=o.PatientReceiveID
		inner join PatientReceive a2 on a.PatientReceiveID=a2.PatientReceiveID left join Catalog_Ward b1 on a2.WardCode=b1.WardCode left join Catalog_District b2 on a2.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on a2.ProvincialCode=b3.ProvincialCode
		where a.MedicalRecordCode=@MedicalRecordCode
	end
go
if exists(select name from sysobjects where name ='pro_MedicalPrescriptionForImmuni')
	drop procedure pro_MedicalPrescriptionForImmuni
go
create procedure pro_MedicalPrescriptionForImmuni
(
	@MedicalRecordCode varchar(50),
	@PatientCode varchar(50),
	@PatientReceiveID numeric(18,0)
)
as
	if not exists(select PatientCode from MedicinesForPatients where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID and MedicalRecordCode=@MedicalRecordCode)
	begin
		select a.RowID,a.ItemCode,b.ItemName,a.Quantity,a.UnitPrice,b.SalesPrice,b.RateBHYT,a.Amount,c.UnitOfMeasureName,b.BHYTPrice,a.Instruction,d.PostingDate,e.ObjectName,'' as Shipment
		from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode 
		inner join UnitOfMeasure c on b.UnitOfMeasureCode=c.UnitOfMeasureCode 
		inner join MedicalRecord d on a.MedicalRecordCode=d.MedicalRecordCode inner join Object e on a.ObjectCode=e.ObjectCode
		where d.MedicalRecordCode=@MedicalRecordCode and d.PatientReceiveID=@PatientReceiveID and d.PatientCode=@PatientCode
		order by a.ItemCode
	end
	else
	begin
		select a.RowID,a.ItemCode,b.ItemName,a.Quantity,a.UnitPrice,b.SalesPrice,b.RateBHYT,a.Amount,c.UnitOfMeasureName,b.BHYTPrice,a.Instruction,d.PostingDate,e.ObjectName,a2.Shipment
		from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode inner join UnitOfMeasure c on b.UnitOfMeasureCode=c.UnitOfMeasureCode 
		inner join MedicalRecord d on a.MedicalRecordCode=d.MedicalRecordCode inner join Object e on a.ObjectCode=e.ObjectCode inner join MedicinesForPatientsDetail a1 on a.RowID=a1.RowIDMedicalPrescription inner join InventoryGumshoe a2 on a1.RowIDInventoryGumshoe=a2.RowID
		where d.MedicalRecordCode=@MedicalRecordCode and d.PatientReceiveID=@PatientReceiveID and d.PatientCode=@PatientCode
		order by a.ItemCode
	end
go
--select * from MedicalRecord
--select * from Diagnosis
--select * from Symptoms
--select * from Advices
if exists(select name from sysobjects where name ='pro_ResultMedicalRecord_Emergency')
	drop procedure pro_ResultMedicalRecord_Emergency
go
create procedure pro_ResultMedicalRecord_Emergency
(
	@MedicalRecordCode varchar(50),
	@MedicalEmergencyCode varchar(50)
)
as
	begin
		declare @MedicalEmergencyOutCode varchar(50)
		select @MedicalEmergencyOutCode=MedicalEmergencyOutCode from MedicalEmergencyOut where MedicalEmergencyCode=@MedicalEmergencyCode
		select c.MedicalRecordCode,b.ICD10Out DiagnosisCode,d.DiagnosisName,e.PatientName,e.PatientAge,e.PatientBirthyear,(case  when e.PatientGender=1 then N'Nam' else N'Nữ' end) PatientGenderName,e.PatientAddress,
		a.ObjectCode,f.ObjectName,b.Advices as AdvicesName,g.EmployeeName,h.TackleName,i.DepartmentName,([dbo].func_DiagnosisEnclosed (@MedicalEmergencyOutCode)) as ICD10KT,(case when (CONVERT(varchar(10),c.AppointmentDate,103)) ='01/01/1900' then '' else CONVERT(varchar(10),c.AppointmentDate,103) end)AppointmentDate,a.PatientCode
		from MedicalEmergency a left join MedicalEmergencyOut b on a.MedicalEmergencyCode=b.MedicalEmergencyCode
		left join MedicalRecord c on a.MedicalEmergencyCode=c.ReferenceCode left join Diagnosis d on b.ICD10Out=d.DiagnosisCode
		left join Patients e on a.PatientCode=e.PatientCode left join Object f on a.ObjectCode = f.ObjectCode
		left join Employee g on b.TreatingDoctor = g.EmployeeCode left join Tackle h on b.TackleCode = h.TackleCode
		left join Department i on a.DepartmentCode=i.DepartmentCode 
		where c.MedicalRecordCode=@MedicalRecordCode
	end
go
--select [dbo].func_DiagnosisEnclosed ('CCO000000000005')
--exec pro_ResultMedicalRecord_Emergency 'BA000000000003'
--select * from MedicalEmergency
--select * from MedicalEmergencyOut
--select * from Diagnosis
--select * from MedicalRecord
--select * from MedicalPrescriptionDetail
--select * from MedicalRecordDiagnosisEnclosed
------------------------------------- Lay thong tin chi tiet don thuoc bhyt
if exists(select name from sysobjects where name='pro_ResultMedicalDetail')
	drop procedure pro_ResultMedicalDetail
go
create procedure pro_ResultMedicalDetail
(
	@MedicalRecordCode varchar(50),
	@RepositoryGroupCode varchar(10),
	@ObjectCode int,
	@Active int =0,
	@Status int=0
)
as
	Declare @TableGroup table (RepositoryGroupCode int)
	insert into @TableGroup(RepositoryGroupCode)(select RepositoryGroupCode from RepositoryGroup where RepositoryGroupCode in(select * from dbo.fnSplitNumber(@RepositoryGroupCode,',')))
	if(@Active=0)
	begin
		select a.MedicalRecordCode,a.ItemCode,[dbo].[func_GetActive](b.Active,'+',b.ItemName,b.ItemContent) ItemName,a.DateOfIssues,(case when a.Morning <>'' then a.Morning+' '+uom_medi.UnitOfMeasureName else '' end) Morning,(case when a.Noon <>'' then a.Noon+' '+uom_medi.UnitOfMeasureName else '' end) Noon,(case when a.Afternoon <>'' then a.Afternoon+' '+uom_medi.UnitOfMeasureName else '' end) Afternoon,(case when a.Evening <>'' then a.Evening +' '+uom_medi.UnitOfMeasureName else '' end) Evening,
		a.Quantity,a.Instruction,a.UnitPrice,b.SalesPrice,b.RateBHYT,a.Amount,c.UnitOfMeasureName,b.BHYTPrice,a.Status,a.RepositoryCode,e.RepositoryName,b1.UsageName,uom_medi.UnitOfMeasureName as UnitOfMeasureName_Medi
		from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode inner join Usage b1 on b.UsageCode=b1.UsageCode
		inner join UnitOfMeasure c on b.UnitOfMeasureCode=c.UnitOfMeasureCode inner join MedicalRecord d on a.MedicalRecordCode=d.MedicalRecordCode
		inner join RepositoryCatalog e on a.RepositoryCode=e.RepositoryCode left join UnitOfMeasure uom_medi on a.UnitOfMeasureCode_Medi=uom_medi.UnitOfMeasureCode
		where a.MedicalRecordCode=@MedicalRecordCode and a.ObjectCode=( case when @ObjectCode=-1 then a.ObjectCode else @ObjectCode end) and e.RepositoryGroupCode in(select RepositoryGroupCode from @TableGroup)
		and a.Status =( case when @Status=-1 then a.Status else @Status end)
		order by a.RowID
	end
	else
	begin
		select a.MedicalRecordCode,a.ItemCode,(b.ItemName+' ' +b.ItemContent) ItemName,a.DateOfIssues,(case when a.Morning <>'' then a.Morning+' '+uom_medi.UnitOfMeasureName else '' end) Morning,(case when a.Noon <>'' then a.Noon+' '+uom_medi.UnitOfMeasureName else '' end) Noon,(case when a.Afternoon <>'' then a.Afternoon+' '+uom_medi.UnitOfMeasureName else '' end) Afternoon,(case when a.Evening <>'' then a.Evening +' '+uom_medi.UnitOfMeasureName else '' end) Evening,
		a.Quantity,a.Instruction,a.UnitPrice,b.SalesPrice,b.RateBHYT,a.Amount,c.UnitOfMeasureName,b.BHYTPrice,a.Status,a.RepositoryCode,e.RepositoryName,b1.UsageName
		from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode inner join Usage b1 on b.UsageCode=b1.UsageCode
		inner join UnitOfMeasure c on b.UnitOfMeasureCode=c.UnitOfMeasureCode inner join MedicalRecord d on a.MedicalRecordCode=d.MedicalRecordCode
		inner join RepositoryCatalog e on a.RepositoryCode=e.RepositoryCode left join UnitOfMeasure uom_medi on a.UnitOfMeasureCode_Medi=uom_medi.UnitOfMeasureCode
		where a.MedicalRecordCode=@MedicalRecordCode and a.ObjectCode=( case when @ObjectCode=-1 then a.ObjectCode else @ObjectCode end) and e.RepositoryGroupCode in(select RepositoryGroupCode from @TableGroup)
		and a.Status =( case when @Status=-1 then a.Status else @Status end)
		order by a.RowID
	end
go
if exists(select name from sysobjects where name ='pro_ResultMedicalDetailForSurgeries')
	drop procedure pro_ResultMedicalDetailForSurgeries
go
create procedure pro_ResultMedicalDetailForSurgeries
(
	@SurgeriesCode varchar(15)
)
as
	begin
		select a.MedicalRecordCode,a.ItemCode,b.ItemName,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening,
		a.Quantity,a.Instruction,a.UnitPrice,b.SalesPrice,b.RateBHYT,a.Amount,c.UnitOfMeasureName,b.BHYTPrice,a.RepositoryCode,
		e.RepositoryName,O.ObjectName,(case a.Status when 0 then N'Chưa duyệt' else N'Đã Duyệt' end) Status
		from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode 
		inner join UnitOfMeasure c on b.UnitOfMeasureCode=c.UnitOfMeasureCode inner join MedicalRecord d on a.MedicalRecordCode=d.MedicalRecordCode
		inner join RepositoryCatalog e on a.RepositoryCode=e.RepositoryCode inner join Object O on a.ObjectCode=O.ObjectCode
		where d.ReferenceCode=@SurgeriesCode
		order by a.ItemCode
	end
go
--exec pro_PatientWaitingDetail 22
------------------------------------- Thong tin in don thuoc BHYT va Mua Ngoai
if exists(select name from sysobjects where name ='pro_RealMedicinesEmergency')
	drop procedure pro_RealMedicinesEmergency
go
create procedure pro_RealMedicinesEmergency
(
	@MedicalEmergencyCode varchar(50),
	@PatientCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@PatientType int=2
)
as
	if(@PatientType=2)
		begin
			select a.MedicalEmergencyCode,a.PatientReceiveID,c.DepartmentName,a.PatientCode,b.PatientName,b.PatientAge,b.PatientBirthyear,(case  when b.PatientGender=1 then N'Nam' else N'Nữ' end) PatientGenderName,
			[dbo].func_PatientOfAddress(@PatientReceiveID) PatientAddress,a.ObjectCode,('('+a.ICD10+')'+d.DiagnosisName) as ICD10Name,(a.ICD10) as ICD10,(a.DiagnosisCode) as SymptomsName,f.ObjectName,e.EmployeeName,'' as Symptoms,'' as DiagnosisCustom
			from MedicalEmergency a inner join Patients b on a.PatientCode=b.PatientCode inner join Department c on a.DepartmentCode=c.DepartmentCode
			left join Diagnosis d on a.ICD10=d.DiagnosisCode inner join Object f on a.ObjectCode = f.ObjectCode inner join Employee e on a.EmployeeCode = e.EmployeeCode
			where a.MedicalEmergencyCode=@MedicalEmergencyCode and a.PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID
		end
	else if(@PatientType=1)
		begin
			select a.MedicalRecordCode MedicalEmergencyCode,a.PatientReceiveID,c.DepartmentName,a.PatientCode,b.PatientName,b.PatientAge,b.PatientBirthyear,(case  when b.PatientGender=1 then N'Nam' else N'Nữ' end) PatientGenderName,
			[dbo].func_PatientOfAddress(@PatientReceiveID) PatientAddress,a.ObjectCode,('('+d.DiagnosisCode+')'+d.DiagnosisName) ICD10Name,d.DiagnosisCode ICD10,(a.Symptoms) as SymptomsName,f.ObjectName,e.EmployeeName,a.Symptoms,a.DiagnosisCustom
			from MedicalRecord a inner join Patients b on a.PatientCode=b.PatientCode inner join Department c on a.DepartmentCode=c.DepartmentCode
			left join Diagnosis d on a.DiagnosisCode=d.RowID inner join Object f on a.ObjectCode = f.ObjectCode inner join Employee e on a.EmployeeCode = e.EmployeeCode
			where a.MedicalRecordCode=@MedicalEmergencyCode and a.PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID
		end
go
--select * from MedicalEmergency
--select * from Diagnosis
--select * from Symptoms
--select * from Advices
------------------------------------- Lay thong tin chi tiet don thuoc bhyt
if exists(select name from sysobjects where name ='pro_RealMedicinesEmergencyDetail')
	drop procedure pro_RealMedicinesEmergencyDetail
go
create procedure pro_RealMedicinesEmergencyDetail
(
	@MedicalEmergencyCode varchar(50),
	@PatientCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@refDate date
)
as
	begin
		select a.RealRowID,a.ItemCode,b.ItemName,a.Quantity,a.UnitPrice,b.SalesPrice,b.RateBHYT,a.Amount,c.UnitOfMeasureName,b.BHYTPrice,a.Instruction,d.DateApproved,e.ObjectName
		from RealMedicinesForPatientsDetail a inner join Items b on a.ItemCode=b.ItemCode 
		inner join UnitOfMeasure c on b.UnitOfMeasureCode=c.UnitOfMeasureCode inner join RealMedicinesForPatients d on a.RealRowID=d.RowID inner join Object e on a.ObjectCode=e.ObjectCode
		where d.RefCode=@MedicalEmergencyCode and d.PatientReceiveID=@PatientReceiveID and d.PatientCode=@PatientCode and CONVERT(date,d.DateApproved,103)=CONVERT(date,@refDate,103)
		order by a.ItemCode
	end
go
if exists(select name from sysobjects where name ='pro_RealMedicinesEmergencyDetail_ForRealID')
	drop procedure pro_RealMedicinesEmergencyDetail_ForRealID
go
create procedure pro_RealMedicinesEmergencyDetail_ForRealID
(
	@RealRowID numeric(18,0),
	@ObjectCode int,
	@GroupBy int =0
)
as
begin tran
	if @GroupBy=0
	begin
		select a.RealRowID,a.ItemCode,(b.ItemName+' ('+b.Active+')') ItemName,a.Quantity,a.UnitPrice,b.SalesPrice,b.RateBHYT,a.Amount,c.UnitOfMeasureName,b.BHYTPrice,a.Instruction,b1.UsageName
		from RealMedicinesForPatientsDetail a inner join Items b on a.ItemCode=b.ItemCode inner join Usage b1 on b.UsageCode=b1.UsageCode
		inner join UnitOfMeasure c on b.UnitOfMeasureCode=c.UnitOfMeasureCode inner join RealMedicinesForPatients d on a.RealRowID=d.RowID
		where a.RealRowID=@RealRowID and a.ObjectCode= (case when @ObjectCode=-1 then a.ObjectCode else @ObjectCode end)
		order by a.RowID
	end
	else
	begin
		select a.ItemCode,(b.ItemName+' ('+b.Active+')') ItemName,sum(a.Quantity) Quantity,a.UnitPrice,b.SalesPrice,b.RateBHYT,sum(a.Amount) Amount,c.UnitOfMeasureName,b.BHYTPrice,a.Instruction,b1.UsageName
		from RealMedicinesForPatientsDetail a inner join Items b on a.ItemCode=b.ItemCode inner join Usage b1 on b.UsageCode=b1.UsageCode
		inner join UnitOfMeasure c on b.UnitOfMeasureCode=c.UnitOfMeasureCode inner join RealMedicinesForPatients d on a.RealRowID=d.RowID
		where a.RealRowID=@RealRowID and a.ObjectCode= (case when @ObjectCode=-1 then a.ObjectCode else @ObjectCode end)
		group by a.ItemCode,b.ItemName,b.Active,a.UnitPrice,b.SalesPrice,b.RateBHYT,c.UnitOfMeasureName,b.BHYTPrice,a.Instruction,b1.UsageName
	end
commit tran
go
----------------------------------------------Lay bao cao thuoc - VTYT
if exists(select name from sysobjects where name ='pro_StatisticMedicinesForPatients')
	drop procedure pro_StatisticMedicinesForPatients
go
create procedure pro_StatisticMedicinesForPatients
(
	@FromDate date,
	@ToDate Date
)
as
begin
	select CONVERT(date,a.DateApproved,103)DateApproved,SUM(b.Quantity) TotalQuantity,b.UnitPrice,c.ItemCode,c.ItemName,d.ItemCategoryName,e.UnitOfMeasureName
	from MedicinesForPatients a inner join MedicinesForPatientsDetail b on a.MedicalRecordCode=b.MedicalRecordCode
	inner join Items c on b.ItemCode=c.ItemCode inner join ItemCategory d on c.ItemCategoryCode=d.ItemCategoryCode
	inner join UnitOfMeasure e on c.UnitOfMeasureCode=e.UnitOfMeasureCode
	where convert(date,a.DateApproved,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103)
	group by CONVERT(date,a.DateApproved,103),b.UnitPrice,c.ItemCode,c.ItemName,d.ItemCategoryName,e.UnitOfMeasureName
end
go
--- exec pro_StatisticBankDetail '2015-01-01','2015-01-31'
if exists(select name from sysobjects where name like'%pro_StatisticBankTotal%')
	drop procedure pro_StatisticBankTotal
go
if exists(select name from sysobjects where name like'%pro_StatisticBankDetail%')
	drop procedure pro_StatisticBankDetail
go
create procedure pro_StatisticBankDetail
(
	@FromDate date,
	@ToDate Date
)
as
begin
	select a.PatientCode,CONVERT(date,a.PostingDate,103) PostingDate,b.PatientName,b.PatientBirthyear, (case when b.PatientGender=0 then N'Nữ' else 'Nam' end ) PatientGenderName,
	d.ServiceName,e.ServiceCategoryName,f.ServiceGroupName,SUM(c.ServicePrice) Amount
	from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode inner join BanksAccountDetail c on a.BanksAccountCode=c.BanksAccountCode
	inner join Service d on c.ServiceCode=d.ServiceCode inner join ServiceCategory e on d.ServiceCategoryCode=e.ServiceCategoryCode
	inner join ServiceGroup f on e.ServiceGroupCode=f.ServiceGroupCode
	where a.Cancel=0 and convert(date,a.PostingDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103) and a.Report in(1)
	group by a.PatientCode,a.PostingDate,b.PatientName,b.PatientBirthyear,b.PatientGender,
	d.ServiceName,e.ServiceCategoryName,f.ServiceGroupName
	union
	select a.PatientCode,CONVERT(date,a.PostingDate,103) PostingDate,b.PatientName,b.PatientBirthyear, (case when b.PatientGender=0 then N'Nữ' else 'Nam' end ) PatientGenderName,
	d.ItemName ServiceName,e.ItemCategoryName ServiceCategoryName,f.GroupName ServiceGroupName,SUM(c.ServicePrice) Amount
	from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode inner join BanksAccountDetail c on a.BanksAccountCode=c.BanksAccountCode
	inner join Items d on c.ServiceCode=d.ItemCode inner join ItemCategory e on d.ItemCategoryCode=e.ItemCategoryCode
	inner join ItemGroup f on e.GroupCode=f.GroupCode
	where a.Cancel=0 and convert(date,a.PostingDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103) and a.Report in(1)
	group by a.PatientCode,a.PostingDate,b.PatientName,b.PatientBirthyear,b.PatientGender,
	d.ItemName,e.ItemCategoryName,f.GroupName
	order by a.PatientCode
end
go
--- exec proTool_StatisticBankGeneral '2015-01-01','2015-01-31',1
if exists(select name from sysobjects where name like'%proTool_StatisticBankGeneral%')
	drop procedure proTool_StatisticBankGeneral
go
create procedure proTool_StatisticBankGeneral
(
	@FromDate date,
	@ToDate Date,
	@Report int=1
)
as
begin
	declare @Checked int =0
	select @Checked as Checked, a.PatientCode,CONVERT(date,a.PostingDate,103) PostingDateBank,b.PatientName,b.PatientBirthyear,(case when b.PatientGender=0 then N'Nữ' else 'Nam' end ) PatientGenderName,CONVERT(char(10),a1.CreateDate,103) DateInto,
	a.PatientPay,a.TotalAmount,a.TotalReal,a.TotalSurcharge,a1.PatientReceiveID,a.BanksAccountCode
	from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode inner join PatientReceive a1 on a.ReferenceCode=a1.PatientReceiveID
	where a.Cancel=0 and convert(date,a.PostingDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103) and a.Report in(@Report)
	order by CONVERT(date,a.PostingDate,103),PatientCode desc
end
go
--- exec proTool_StatisticBankDetail '2015-01-01','2015-01-31',1
if exists(select name from sysobjects where name like'%proTool_StatisticBankDetail%')
	drop procedure proTool_StatisticBankDetail
go
create procedure proTool_StatisticBankDetail
(
	@FromDate date,
	@ToDate Date,
	@Report int=1
)
as
begin
	declare @Checked int =0
	select @Checked as Checked, a.PatientCode,CONVERT(date,a.PostingDate,103) PostingDateBank,(N'Mã BN: '+a.PatientCode+N'_Họ & tên: '+b.PatientName +N'_Năm sinh: '+convert(varchar(5),b.PatientBirthyear) +N'_Giới tính: ' +(case when b.PatientGender=0 then N'Nữ' else 'Nam' end )+N'_Ngày khám: '+CONVERT(char(10),a1.CreateDate,103)) PatientInfo,
	d.ServiceName,e.ServiceCategoryName,f.ServiceGroupName,c.ServicePrice Amount,c.Quantity,a1.PatientReceiveID,a.BanksAccountCode,c.RowID, N'Lần' as UnitOfMeasureName
	from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode inner join BanksAccountDetail c on a.BanksAccountCode=c.BanksAccountCode
	inner join Service d on c.ServiceCode=d.ServiceCode inner join ServiceCategory e on d.ServiceCategoryCode=e.ServiceCategoryCode
	inner join ServiceGroup f on e.ServiceGroupCode=f.ServiceGroupCode inner join PatientReceive a1 on a.ReferenceCode=a1.PatientReceiveID
	where a.Cancel=0 and convert(date,a.PostingDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103) and a.Report in(@Report)
	union
	select @Checked as Checked,a.PatientCode,CONVERT(date,a.PostingDate,103) PostingDateBank,(N'Mã BN: '+a.PatientCode+N'_Họ & tên: '+b.PatientName +N'_Năm sinh: '+convert(varchar(5),b.PatientBirthyear) +N'_Giới tính: ' +(case when b.PatientGender=0 then N'Nữ' else 'Nam' end )+N'_Ngày khám: '+CONVERT(char(10),a1.CreateDate,103)) PatientInfo,
	d.ItemName ServiceName,e.ItemCategoryName ServiceCategoryName,f.GroupName ServiceGroupName,c.ServicePrice Amount,c.Quantity,a1.PatientReceiveID,a.BanksAccountCode,c.RowID,d1.UnitOfMeasureName
	from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode inner join BanksAccountDetail c on a.BanksAccountCode=c.BanksAccountCode
	inner join Items d on c.ServiceCode=d.ItemCode inner join ItemCategory e on d.ItemCategoryCode=e.ItemCategoryCode
	inner join ItemGroup f on e.GroupCode=f.GroupCode inner join PatientReceive a1 on a.ReferenceCode=a1.PatientReceiveID inner join UnitOfMeasure d1 on d.UnitOfMeasureCode=d1.UnitOfMeasureCode
	where a.Cancel=0 and convert(date,a.PostingDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103) and a.Report in(@Report)
	order by CONVERT(date,a.PostingDate,103),PatientCode desc
end
go
if exists(select name from sysobjects where name ='pro_ViewInventory')
	drop procedure pro_ViewInventory
go
create procedure pro_ViewInventory
(
	@RepositoryCode varchar(50)
)
as
begin
	select b.ItemCode,b.ItemName,a.AmountEnd,b.SafelyQuantity,(a.AmountEnd-b.SafelyQuantity) AmountDisparity,
	c.UsageName,d.UnitOfMeasureName,e.RepositoryName,f.ItemCategoryName,g.GroupName,a.RepositoryCode
	from InventoryGeneral a inner join Items b on a.ItemCode=b.ItemCode inner join Usage c on b.UsageCode=c.UsageCode
	inner join UnitOfMeasure d on b.UnitOfMeasureCode=d.UnitOfMeasureCode inner join RepositoryCatalog e on a.RepositoryCode=e.RepositoryCode
	inner join ItemCategory f on b.ItemCategoryCode=f.ItemCategoryCode inner join ItemGroup g on f.GroupCode=g.GroupCode
	where a.RepositoryCode=@RepositoryCode and b.Status=0
	order by a.RepositoryCode
end
go
if exists(select name from sysobjects where name ='pro_ViewInventoryLimited')
	drop procedure pro_ViewInventoryLimited
go
create procedure pro_ViewInventoryLimited
(
	@RepositoryCode varchar(50)
)
as
begin
	select b.ItemCode,a.AmountEnd,d.UnitOfMeasureCode,b.UsageCode,ISNULL(a1.Quantity,0) Quantity
	from InventoryGeneral a inner join Items b on a.ItemCode=b.ItemCode inner join Usage c on b.UsageCode=c.UsageCode
	inner join UnitOfMeasure d on b.UnitOfMeasureCode=d.UnitOfMeasureCode inner join RepositoryCatalog e on a.RepositoryCode=e.RepositoryCode
	inner join ItemCategory f on b.ItemCategoryCode=f.ItemCategoryCode inner join ItemGroup g on f.GroupCode=g.GroupCode left join InventoryLimited a1 on a.RepositoryCode=a1.RepositoryCode and a1.ItemCode=a.ItemCode
	where a.RepositoryCode=@RepositoryCode and a.Hide = 0
	order by a.RepositoryCode
end
go
if exists(select name from sysobjects where name ='pro_ViewTagWarehousing')
	drop procedure pro_ViewTagWarehousing
go
create procedure pro_ViewTagWarehousing
(
	@RepositoryCode varchar(50)
)
as
begin
	select 0 as CheckAll,a.ItemCode,b.ItemName,c.UnitOfMeasureName,b1.ItemCategoryName,b2.GroupName
	from InventoryGeneral a inner join Items b on a.ItemCode=b.ItemCode 
	inner join UnitOfMeasure c on b.UnitOfMeasureCode=c.UnitOfMeasureCode inner join ItemCategory b1 on b.ItemCategoryCode=b1.ItemCategoryCode inner join ItemGroup b2 on b1.GroupCode=b2.GroupCode
	where a.RepositoryCode=@RepositoryCode and  a.Hide = 0
	order by b.ItemName
end
go
----------------------------------Kiem tra benh nhan hien dien trong khoa phong
if exists(select name from sysobjects where name ='pro_PresentPatient')
	drop procedure pro_PresentPatient
go
create procedure pro_PresentPatient
(
	@PatientCode varchar(50),
	@Check int,
	@PatientReceiveID numeric(18,0)=-1,
	@Result int out
)
as
begin
	if @Check=1 -- khi tiep nhan moi kiem tra ket thuc dieu tri hay chua
	begin
		if exists(select @PatientCode from PatientReceive a  where a.PatientCode=@PatientCode and a.Status in(0))
		begin
			select @PatientReceiveID=PatientReceiveID from PatientReceive a  where a.PatientCode=@PatientCode and a.Status in(0)
			if not exists(select a.ServiceCode from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode where a.PatientCode=@PatientCode and b.ServiceGroupCode='KCB' and a.RefID=@PatientReceiveID and Status<>0)
				set @Result = 1
			else
				set @Result = -3
		end
		else
			set @Result = 1
	end
	else
	begin
		--if exists(select a.PatientCode from PatientReceive a  where a.PatientCode=@PatientCode and Status=2)
		--	set @Result = -1
		--else 
		if exists(select a.PatientCode from PatientReceive a inner join MedicalEmergency b on a.PatientReceiveID=b.PatientReceiveID where a.PatientCode=@PatientCode and a.Status in(0,1))
			begin
				if not exists(select a.PatientCode from MedicalEmergency a inner join MedicalEmergencyOut b on a.MedicalEmergencyCode=b.MedicalEmergencyCode where a.PatientCode=@PatientCode)
					set @Result =-2
				else
					set @Result =1
			end
		else if exists(select PatientCode from PatientReceive where Status=0 and PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID)
			set @Result =1
		else if exists(select PatientCode from PatientReceive where Status=2 and PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID)
			set @Result =-1
		else if exists(select PatientCode from PatientReceive where Status=0 and PatientCode=@PatientCode)
			set @Result =-3
		else
			set @Result =1
	end
end
go
--declare @Result int
--exec pro_PresentPatient '14000003',1,@Result out
--print @Result
----------------------------------Kiem tra xoa benh nhan cap cuu
if exists(select name from sysobjects where name ='pro_CheckMedicalEmergency')
	drop procedure pro_CheckMedicalEmergency
go
create procedure pro_CheckMedicalEmergency
(
	@PatientCode varchar(50),
	@PatientReceiveID int,
	@Result int out
)
as
begin
	if exists(select a.PatientCode from MedicalEmergency a inner join MedicalEmergencyOut b on a.MedicalEmergencyCode=b.MedicalEmergencyCode where a.PatientReceiveID=@PatientReceiveID and a.PatientCode=@PatientCode and b.Paid=1 and (b.BanksAccountCode is not null or b.BanksAccountCode<>''))
		set @Result = -1
	else
	begin
		update PatientReceive set Status=1,OutDate=null where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode
		delete from MedicalRecordDiagnosisEnclosed where MedicalRecordCode in(select MedicalEmergencyOutCode from MedicalEmergencyOut where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode)
		delete from MedicalEmergencyOut where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode
		update PatientReceive set Status=1,OutDate=null where PatientReceiveID=@PatientReceiveID
		set @Result =1
	end
end
go
------------------------------------------- In mau BV01 va xem chi phi kham chua benh
if exists(select name from sysobjects where name ='pro_BanksTotalBV01')
	drop procedure pro_BanksTotalBV01
go
create procedure pro_BanksTotalBV01
(
	@PatientCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@Cancel int
)
as
begin
	declare @MedicalRecordCode varchar(50)
	declare @ICD10KT nvarchar(1000)
	set @ICD10KT=''
	declare cur cursor read_only fast_forward
	for select MedicalRecordCode from MedicalRecord where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode
	open cur
	fetch next from cur into @MedicalRecordCode
	while @@FETCH_STATUS = 0
	begin
		set @ICD10KT=@ICD10KT+(select ([dbo].func_DiagnosisEnclosed (@MedicalRecordCode)))
		FETCH NEXT FROM cur into @MedicalRecordCode
	end	 
	CLOSE cur
	DEALLOCATE cur
    select distinct a.ReferenceCode,a.PatientCode,b.PatientName,(case when b.PatientGender=1 then 1 else 0 end) PatientGenderMale,(case when b.PatientGender=0 then 1 else 0 end) PatientGenderFeMale,b.PatientBirthday,b.PatientBirthyear,b.PatientAge,
    b.PatientMobile,b.PatientEmail,b.CodeArise,b.MedicalHistory,b.Allergy,c.Serial,c.Serial01,c.Serial02,c.Serial03,c.Serial04,c.Serial05,c.Serial06,d.KCBBDName,c.StartDate,c.EndDate,(case when c.TraiTuyen = 1 then 1 else 0 end) TraiTuyen,(case when c.TraiTuyen=0 then 1 else 0 end) DungTuyen,e.RateFalse,e.RateTrue,[dbo].func_PatientOfAddress(@PatientReceiveID) PatientAddress
	,b.PatientGender,a.ObjectCode,(d.ProvincialIDBHYT+'-'+c.KCBBDCode) KCBBDCode,DATEPART(HOUR, f.CreateDate)HHvv,DATEPART(MINUTE, f.CreateDate)MIvv,f.CreateDate Datevv,DATEPART(HOUR, f.OutDate)HHrv,DATEPART(MINUTE, f.OutDate)MIrv,f.OutDate Daterv,[dbo].func_Department (@PatientCode,@PatientReceiveID) as DepartmentName
	--,[dbo].func_MedicalDiagnosis (@PatientReceiveID,@PatientCode) as ICD10Name,h.DiagnosisCode
	,g.ICD10Name_Custom as ICD10Name,g.ICD10_Custom as DiagnosisCode
	,@ICD10KT as ICD10KT, (datediff(DD,f.CreateDate,GETDATE())+1) NgayDieuTri, (case when a.ObjectCode=1 then 1 else 0 end) BHYT,(case when a.ObjectCode<>1 then 1 else 0 end) NoneBHYT,c.ReferralPaper
    from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode	
    left join BHYT c on a.ReferenceCode=c.PatientReceiveID 
    left join KCBBD d on c.KCBBDCodeFull=(d.ProvincialIDBHYT+'-'+d.KCBBDCode) left join RateBHYT e on SUBSTRING(c.Serial,0,3)=e.RateCard
    inner join PatientReceive f on a.PatientCode=f.PatientCode and a.ReferenceCode=f.PatientReceiveID
    left join MedicalRecord g on a.ReferenceCode=g.PatientReceiveID and a.PatientCode=g.PatientCode 
    --left join Diagnosis h on g.DiagnosisCode=h.RowID
    where a.ReferenceCode=@PatientReceiveID and a.PatientCode=@PatientCode and Cancel=@Cancel
end
go
-- exec pro_BanksTotalBV01 '17000028',212934,0
if exists(select name from sysobjects where name ='pro_GetBV01')
	drop procedure pro_GetBV01
go
create procedure pro_GetBV01
(
	@PatientCode varchar(50),
	@PatientRecive numeric(18,0),
	@Cancel int
)
as
begin
	select a.ReferenceCode,a.PatientCode,a.BHYTPay BHYTPayTotal,a.PatientPay PatientPayTotal,a.Exemptions,a.TotalAmount,
	c.ObjectName,b.ServicePrice,b.DisparityPrice,b.Quantity,b.ObjectCode,b.ServiceCode,d.ServiceName,e.ServiceCategoryName,
	f.ServiceModuleCode, 100 as RateBHYT,g.UnitOfMeasureName as DVT,(b.Quantity*b.ServicePrice) Amount, 0 as BHYTPay,0 as PatientPay,f1.ServiceModuleName GroupName,f1.STT,a.TotalReal, 0 as ListBHYT
	from BanksAccount a inner join BanksAccountDetail b on a.BanksAccountCode=b.BanksAccountCode inner join Object c on b.ObjectCode=c.ObjectCode inner join Service d on b.ServiceCode=d.ServiceCode inner join UnitOfMeasure g on d.UnitOfMeasureCode=g.UnitOfMeasureCode
	inner join ServiceCategory e on d.ServiceCategoryCode=e.ServiceCategoryCode inner join ServiceGroup f on e.ServiceGroupCode=f.ServiceGroupCode inner join ServiceModule f1 on f.ServiceModuleCode=f1.ServiceModuleCode
	where a.Cancel=@Cancel and a.PatientCode=@PatientCode and a.ReferenceCode=@PatientRecive and b.ObjectCode not in(5)
	union all
	select a.ReferenceCode,a.PatientCode,a.BHYTPay BHYTPayTotal,a.PatientPay PatientPayTotal,a.Exemptions,a.TotalAmount,
	c.ObjectName,b.ServicePrice,b.DisparityPrice,b.Quantity,b.ObjectCode,b.ServiceCode,d.ItemName,e.ItemCategoryName,f.ServiceModuleCode,d.RateBHYT,
	g.UnitOfMeasureName as DVT,(b.Quantity*b.ServicePrice) Amount,0 as BHYTPay, 0 as PatientPay,f1.ServiceModuleName GroupName,f1.STT,a.TotalReal,d.ListBHYT
	from BanksAccount a inner join BanksAccountDetail b on a.BanksAccountCode=b.BanksAccountCode 
	inner join Object c on a.ObjectCode=c.ObjectCode inner join Items d on b.ServiceCode=d.ItemCode
	inner join ItemCategory e on d.ItemCategoryCode=e.ItemCategoryCode inner join ItemGroup f on e.GroupCode=f.GroupCode
	inner join UnitOfMeasure g on d.UnitOfMeasureCode=g.UnitOfMeasureCode inner join ServiceModule f1 on f.ServiceModuleCode=f1.ServiceModuleCode
	where a.Cancel=@Cancel and a.PatientCode=@PatientCode and a.ReferenceCode=@PatientRecive and b.ObjectCode not in(5)
	order by STT
end
go
if exists(select name from sysobjects where name ='pro_View_Treatment_Costs')
	drop procedure pro_View_Treatment_Costs
go
create procedure pro_View_Treatment_Costs
(
	@PatientCode varchar(50),
	@PatientReceiveID numeric(18,0)
)
as
begin
	select a.RefID ReferenceCode,a.PatientCode,0 as BHYTPayTotal, 0 as PatientPayTotal, 0 as Exemptions, 0 as TotalAmount,
	c.ObjectName,a.ServicePrice,a.DisparityPrice, a.Quantity as Quantity,a.ObjectCode,a.ServiceCode,b.ServiceName,d.ServiceCategoryName,
	e.ServiceModuleCode,100 as RateBHYT,b1.UnitOfMeasureName as DVT,(a.ServicePrice) Amount, 0 as BHYTPay,0 as PatientPay,e.ServiceGroupName GroupName,e1.ServiceModuleName ModuleName,CONVERT(date,a.WorkDate,103) WorkDate, 0 as ListBHYT
    from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode inner join UnitOfMeasure b1 on b.UnitOfMeasureCode=b1.UnitOfMeasureCode inner join Object c on a.ObjectCode=c.ObjectCode 
    inner join ServiceCategory d on b.ServiceCategoryCode=d.ServiceCategoryCode inner join ServiceGroup e on d.ServiceGroupCode=e.ServiceGroupCode inner join serviceModule e1 on e.ServiceModuleCode=e1.ServiceModuleCode
    where a.PatientCode=@PatientCode and a.RefID=@PatientReceiveID
	union all
	select c.PatientReceiveID ReferenceCode,c.PatientCode,0 as BHYTPayTotal, 0 as PatientPayTotal, 0 as Exemptions, 0 as TotalAmount,
	d.ObjectName,a.UnitPrice,0 as DisparityPrice,a.Quantity,c.ObjectCode,b.ItemCode,b.ItemName,f.ItemCategoryName,g.ServiceModuleCode,
	b.RateBHYT,e.UnitOfMeasureName,a.Amount,0 as BHYTPay,0 as PatientPay,g.GroupName,g1.ServiceModuleName ModuleName,CONVERT(date,c.PostingDate,103) WorkDate,a.BHYT ListBHYT
    from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode 
    inner join MedicalRecord c on a.MedicalRecordCode=c.MedicalRecordCode inner join Object d on c.ObjectCode=d.ObjectCode
    inner join UnitOfMeasure e on b.UnitOfMeasureCode=e.UnitOfMeasureCode
    inner join ItemCategory f on b.ItemCategoryCode=f.ItemCategoryCode inner join ItemGroup g on f.GroupCode=g.GroupCode inner join serviceModule g1 on g.ServiceModuleCode=g1.ServiceModuleCode
    where c.PatientCode=@PatientCode and c.PatientReceiveID=@PatientReceiveID
    union all
    select c.PatientReceiveID ReferenceCode,c.PatientCode,0 as BHYTPayTotal, 0 as PatientPayTotal, 0 as Exemptions, 0 as TotalAmount,
	d.ObjectName,a.UnitPrice,0 as DisparityPrice,a.Quantity,a.ObjectCode,b.ItemCode,b.ItemName,f.ItemCategoryName,g.ServiceModuleCode,
	b.RateBHYT,e.UnitOfMeasureName,a.Amount,0 as BHYTPay,0 as PatientPay,g.GroupName,g1.ServiceModuleName ModuleName,CONVERT(date,c.DateApproved,103) WorkDate,b.ListBHYT
    from RealMedicinesForPatientsDetail a inner join Items b on a.ItemCode=b.ItemCode 
    inner join RealMedicinesForPatients c on a.RealRowID=c.RowID inner join Object d on c.ObjectCode=d.ObjectCode
    inner join UnitOfMeasure e on b.UnitOfMeasureCode=e.UnitOfMeasureCode
    inner join ItemCategory f on b.ItemCategoryCode=f.ItemCategoryCode inner join ItemGroup g on f.GroupCode=g.GroupCode inner join serviceModule g1 on g.ServiceModuleCode=g1.ServiceModuleCode
    where c.PatientCode=@PatientCode and a.ObjectCode not in(5) and c.PatientReceiveID=@PatientReceiveID
end
go
if exists(select name from sysobjects where name ='pro_View_Treatment_Info')
	drop procedure pro_View_Treatment_Info
go
create procedure pro_View_Treatment_Info
(
	@PatientCode varchar(50),
	@PatientReceiveID numeric(18,0)
)
as
begin
	declare @OutDate char(10)
	declare @HHrv char(5)
	if((select OutDate from PatientReceive where PatientReceiveID=@PatientReceiveID) is null)
	begin
		set @OutDate = (select CONVERT(char(10),GETDATE(),103) from PatientReceive where PatientReceiveID=@PatientReceiveID)
		set @HHrv = (select CONVERT(char(5),GETDATE(),108) from PatientReceive where PatientReceiveID=@PatientReceiveID)
	end
	else
	begin
		set @OutDate = (select CONVERT(char(10),OutDate,103) from PatientReceive where PatientReceiveID=@PatientReceiveID)
		set @HHrv = (select CONVERT(char(5),OutDate,108) from PatientReceive where PatientReceiveID=@PatientReceiveID)
	end
	select a.PatientReceiveID,a.PatientCode,b.PatientName,(case when b.PatientGender=1 then N'Nam' else N'Nữ' end) PatientGendername,
     convert(char(10),b.PatientBirthday,103) PatientBirthday,b.PatientBirthyear,b.PatientAge,b.PatientMobile,b.PatientEmail,b.CodeArise,b.MedicalHistory,b.Allergy,c.Serial,
     d.KCBBDName,c.StartDate,c.EndDate,(case when c.TraiTuyen = 1 then 1 else 0 end) TraiTuyen,(case when c.TraiTuyen=0 then 1 else 0 end) DungTuyen,e.RateFalse,e.RateTrue,[dbo].func_PatientOfAddressFull(b.PatientAddress,wa.WardName,dis.DistrictName,pro.ProvincialName) PatientAddress,b.PatientGender,a.ObjectCode,a1.ObjectName,(d.ProvincialIDBHYT+'-'+c.KCBBDCode) KCBBDCode, convert(char(5),a.CreateDate,108) HHvv,
    CONVERT(date,a.CreateDate,103) Datevv,[dbo].func_Department (@PatientCode,@PatientReceiveID) as DepartmentName,f.Symptoms,(g.DiagnosisCode + ':' +g.DiagnosisName) DiagnosisCode,
    @OutDate OutDate,@HHrv HHrv,(ISNULL( DATEDIFF(day, CreateDate, OutDate),0)+1) DateTotal,f.DescriptionNode,f.Advices,f.DiagnosisCustom,(case when c.Capcuu=1 then 1 else 0 end) capcuu,(case when c.ReferralPaper=1 then 1 else 0 end) chuyenvien
    from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode left join BHYT c on a.PatientReceiveID=c.PatientReceiveID 
    left join KCBBD d on c.KCBBDCode=d.KCBBDCode and left(c.KCBBDCodeFull,2) = d.ProvincialIDBHYT
	left join RateBHYT e on SUBSTRING(c.Serial,0,3)=e.RateCard inner join [Object] a1 on a.ObjectCode=a1.ObjectCode
    left join MedicalRecord f on a.PatientReceiveID=f.PatientReceiveID and a.PatientCode=f.PatientCode left join Diagnosis g on f.DiagnosisCode=g.RowID
	left join Catalog_District dis on a.DistrictCode=dis.DistrictCode left join Catalog_Provincial pro on a.ProvincialCode=pro.ProvincialCode left join Catalog_Ward wa on a.WardCode=wa.WardCode

    where a.PatientReceiveID=@PatientReceiveID and a.PatientCode=@PatientCode
end
go
--exec pro_View_Treatment_Info '15000002',839
--select * from MedicalRecord
--select * from Diagnosis
--select * from SuggestedServiceReceipt where PatientCode in('14000002')
--select * from PatientReceive where PatientCode in('14000002')
if exists(select name from sysobjects where name = 'pro_View_Treatment_Emergency')
	drop procedure pro_View_Treatment_Emergency
go
create procedure pro_View_Treatment_Emergency
(
	@PatientCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@MedicalEmergencyCode varchar(20)
)
as
begin
	Declare @MedicalEmergencyOutCode varchar(20)
	select @MedicalEmergencyOutCode=MedicalEmergencyOutCode from MedicalEmergencyOut where MedicalEmergencyCode=@MedicalEmergencyCode
	select a.PatientReceiveID,a.PatientCode,b.PatientName,(case when b.PatientGender=1 then N'Nam' else N'Nữ' end) PatientGendername,
     b.PatientBirthday,b.PatientBirthyear,b.PatientAge,b.PatientMobile,b.PatientEmail,b.CodeArise,b.MedicalHistory,b.Allergy,c.Serial,
     d.KCBBDName,c.StartDate,c.EndDate,c.TraiTuyen,e.RateFalse,e.RateTrue,[dbo].func_PatientOfAddressFull(b.PatientAddress,wa.WardName,dis.DistrictName,pro.ProvincialName) PatientAddress,
    b.PatientGender,a.ObjectCode,c.KCBBDCode,[dbo].func_Department (@PatientCode,@PatientReceiveID) as DepartmentName,f.DateOn,f.TimeOn,f1.DateOut,f1.DateOut,
    g.DiagnosisName ICD10Namevv,f.DiagnosisCode ICD10vv,([dbo].func_DiagnosisEnclosed (@MedicalEmergencyCode)) ICD10KTvv,g1.DiagnosisName ICD10Namerv,f1.ICD10Out ICD10rv,([dbo].func_DiagnosisEnclosed (@MedicalEmergencyOutCode)) ICD10KTrv,(case when c.Capcuu=1 then 1 else 0 end) capcuu,(case when c.ReferralPaper=1 then 1 else 0 end) chuyenvien
    from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode
    left join BHYT c on a.ReferenceCode=c.PatientReceiveID 
    left join KCBBD d on c.KCBBDCode=d.KCBBDCode left join RateBHYT e on SUBSTRING(c.Serial,0,3)=e.RateCard
    inner join MedicalEmergency f on a.PatientCode=f.PatientCode and a.PatientReceiveID=f.PatientReceiveID
    left join MedicalEmergencyOut f1 on f.MedicalEmergencyCode=f1.MedicalEmergencyCode
    left join Diagnosis g on f.ICD10=g.DiagnosisCode left join Diagnosis g1 on f1.ICD10Out=g1.DiagnosisCode
	left join Catalog_District dis on a.DistrictCode=dis.DistrictCode left join Catalog_Provincial pro on a.ProvincialCode=pro.ProvincialCode left join Catalog_Ward wa on a.WardCode=wa.WardCode

    where a.PatientReceiveID=@PatientReceiveID and a.PatientCode=@PatientCode and f.MedicalEmergencyCode=@MedicalEmergencyCode
end
go
------------------------------------ Function
if exists(select name from sysobjects where name ='func_Department')
	drop function func_Department
go
CREATE FUNCTION func_Department(@PatientCode VarChar(50), @PatientReceiveID numeric(18,0))
RETURNS NVARCHAR(1000)
AS
BEGIN
	Declare @strDepartment nvarchar(1000)
	set @strDepartment=''
	Declare @Tempt nvarchar(1000)
	Declare @DepartmentCode varchar(50)
	Declare @DepartmentName nvarchar(250)
	declare cur1 cursor read_only fast_forward
	for select a.DepartmentCode,b.DepartmentName from SuggestedServiceReceipt a inner join Department b on a.DepartmentCode=b.DepartmentCode where a.PatientCode=@PatientCode and a.RefID=@PatientReceiveID and a.Note='TIEPDON'
	open cur1
	fetch next from cur1 into @DepartmentCode,@DepartmentName
	while @@FETCH_STATUS = 0
	begin
		--set @Tempt = @DepartmentName+' ( '+@DepartmentCode+' );'
		set @Tempt = @DepartmentName+';'
		set @strDepartment=@strDepartment + @Tempt
		FETCH NEXT FROM cur1 into @DepartmentCode,@DepartmentName
	end
	CLOSE cur1
	DEALLOCATE cur1
	RETURN @strDepartment
end
go
------------------------------------------- Lay chuoi ICD10 kem theo
if exists(select name from sysobjects where name = 'func_DiagnosisEnclosed')
	drop function func_DiagnosisEnclosed
go
CREATE FUNCTION func_DiagnosisEnclosed(@MedicalRecordCode VarChar(50))
RETURNS NVARCHAR(1000)
AS
BEGIN
	Declare @strResult nvarchar(2000)
	set @strResult=''
	Declare @Tempt nvarchar(1000)
	Declare @DiagnosisCode varchar(50)
	Declare @DiagnosisName nvarchar(500)
	declare cur1 cursor read_only fast_forward
	for select b.DiagnosisCode,b.DiagnosisName from MedicalRecordDiagnosisEnclosed a inner join Diagnosis b on a.RowIDDiagnosis=b.RowID where a.MedicalRecordCode=@MedicalRecordCode
	open cur1
	fetch next from cur1 into @DiagnosisCode,@DiagnosisName
	while @@FETCH_STATUS = 0
	begin
		set @Tempt = LTRIM(RTRIM(@DiagnosisName))+ '('+ LTRIM(RTRIM(@DiagnosisCode)) +');'
		set @strResult=@strResult + @Tempt
		FETCH NEXT FROM cur1 into @DiagnosisCode,@DiagnosisName
	end
	CLOSE cur1
	DEALLOCATE cur1
	RETURN @strResult
end
go
-- select [dbo].func_DiagnosisEnclosed 'BA000000000011'
if exists(select name from sysobjects where name like'%func_MedicalDiagnosis%')
	drop function func_MedicalDiagnosis
go
CREATE FUNCTION func_MedicalDiagnosis(@PatientReceiveID numeric(18,0),@PatientCode varchar(50))
RETURNS NVARCHAR(1000)
AS
BEGIN
	Declare @strResult nvarchar(1000)=''
	Declare @Tempt nvarchar(500)
	Declare @RowID numeric(18,0)
	Declare @DiagnosisCode varchar(50)
	Declare @DiagnosisName nvarchar(500)
	Declare @DiagnosisCustom nvarchar(250)
	Declare @DiagnosisCustomName nvarchar(500)=''
	Declare @DiagnosisNameResult nvarchar(1000)=''
	declare cur1 cursor read_only fast_forward
	for select DiagnosisCode, DiagnosisCustom from MedicalRecord  where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode
	open cur1
	fetch next from cur1 into @RowID,@DiagnosisCustom
	while @@FETCH_STATUS = 0
	begin
		select @DiagnosisCode=DiagnosisCode,@DiagnosisName=DiagnosisName from Diagnosis where RowID=@RowID
		if(@DiagnosisCode<>'' and @DiagnosisName<>'')
		begin
			---set @Tempt = LTRIM(RTRIM(@DiagnosisName))+ '('+ LTRIM(RTRIM(@DiagnosisCode)) +');'
			set @Tempt = LTRIM(RTRIM(@DiagnosisName))+ ';'
			set @strResult=@strResult + @Tempt
		end
		set @DiagnosisCustomName=@DiagnosisCustomName ---+ LTRIM(RTRIM(@DiagnosisCustom)) + ';'
		FETCH NEXT FROM cur1 into @RowID,@DiagnosisCustom
	end
	CLOSE cur1
	DEALLOCATE cur1
	set @DiagnosisNameResult = @strResult + @DiagnosisCustomName
	RETURN @DiagnosisNameResult
end
go
--select [dbo].func_MedicalDiagnosis (102,'14000017')
if exists(select name from sysobjects where name ='func_ListSurgicalCrew')
	drop function func_ListSurgicalCrew
go
CREATE FUNCTION func_ListSurgicalCrew(@SurgeriesCode VarChar(15))
RETURNS NVARCHAR(1000)
AS
BEGIN
	Declare @strResult nvarchar(1000)
	declare @Tempt nvarchar(1000)
	Declare @EmployeeCode varchar(50)
	Declare @EmployeeName nvarchar(250)
	Declare @PositionName nvarchar(250)
	set @strResult=''
	declare cur1 cursor read_only fast_forward
	for select a.EmployeeCode,b.EmployeeName,c.PositionName from SurgicalCrew a inner join Employee b on a.EmployeeCode=b.EmployeeCode left join EmployeePosition c on a.PositionCode=c.PositionCode where a.SurgeriesCode=@SurgeriesCode
	open cur1
	fetch next from cur1 into @EmployeeCode,@EmployeeName,@PositionName
	while @@FETCH_STATUS = 0
	begin
		set @Tempt = @PositionName+': '+@EmployeeName+'          - '
		set @strResult=@strResult + @Tempt
		FETCH NEXT FROM cur1 into @EmployeeCode,@EmployeeName,@PositionName
	end
	CLOSE cur1
	DEALLOCATE cur1
	RETURN @strResult
end
go
-- select [dbo].func_ListSurgicalCrew ('PT000000000003')
if exists(select name from sysobjects where name ='func_GetActive')
	drop FUNCTION [dbo].[func_GetActive]
go
CREATE FUNCTION [dbo].[func_GetActive]
( 
    @string NVARCHAR(MAX), 
    @delimiter CHAR(1) ,
    @itemName nvarchar(max),
	@ItemContent nvarchar(200)=''
) 
RETURNS NVARCHAR(1000) 
BEGIN 
	declare @output table(Active nvarchar(500))
	declare @Actice nvarchar(500)
	declare @Count int
	set @Count=0
    DECLARE @start INT, @end INT 
    SELECT @start = 1, @end = CHARINDEX(@delimiter, @string) 
    WHILE @start < LEN(@string) + 1 BEGIN 
        IF @end = 0  
            SET @end = LEN(@string) + 1
        INSERT INTO @output (Active) VALUES(SUBSTRING(@string, @start, @end - @start)) 
        SET @start = @end + 1 
        SET @end = CHARINDEX(@delimiter, @string, @start)
    END 
    set @Count = (select COUNT(*) sl from @output)	
    if @Count>0
		set @Actice=@itemName +' (' +@string +')'+' ' + @ItemContent
	else
		set @Actice=@itemName+' ' + @ItemContent
    RETURN @Actice
END
go
-------------------------------------- alter table edit column
--------- Ngay 22/06/2014 ------------------ alter table Add column 
-- ALTER TABLE Service ADD PatientType VARCHAR(20) default null
-- ALTER TABLE SurviveSign ADD Breath VARCHAR(50) default ''
-- ALTER TABLE MedicinesRetail ADD Paid int default 0
----------------------------------------- Bao cao Xuat Nhap Ton Kho Thuoc
if exists(select name from sysobjects where name ='pro_Report_XNT_TH' and type='P')
	drop procedure pro_Report_XNT_TH
go
if exists(select name from sysobjects where name ='pro_Report_XNT_XB' and type='P')
	drop procedure pro_Report_XNT_XB
go
if exists(select name from sysobjects where name ='pro_Report_XNT_TuTruc'and type='P')
	drop procedure pro_Report_XNT_TuTruc
go
--------------------------- Bao cao NXT kho thuoc nhom xuat ban nha thuoc (Ban le) (Nhom Nha Ban Le)
if exists(select name from sysobjects where name ='pro_Report_XNT_NT' and type='P')
	drop procedure pro_Report_XNT_NT
go
---select * from report_NXT_TH where ItemCode='TH000073'
--------------------------- Bao cao NXT xem han dung cua thuoc
if exists(select name from sysobjects where name like'%pro_Report_View_DateEnd%')
	drop procedure pro_Report_View_DateEnd
go
create procedure pro_Report_View_DateEnd
(
	@RepositoryCode varchar(50)
)
as
begin
	if @RepositoryCode ='0'
	begin
		select a.ItemCode,b.ItemName,b1.UnitOfMeasureName,b2.UsageName,b3.ItemCategoryName,a.DateEnd,a.Shipment,c.RepositoryName,b4.GroupName
		from InventoryGumshoe a inner join Items b on a.ItemCode=b.ItemCode inner join UnitOfMeasure b1 on b.UnitOfMeasureCode=b1.UnitOfMeasureCode
		inner join Usage b2 on b.UsageCode=b2.UsageCode inner join ItemCategory b3 on b.ItemCategoryCode=b3.ItemCategoryCode  inner join ItemGroup b4 on b3.GroupCode=b4.GroupCode
		inner join RepositoryCatalog c on a.RepositoryCode=c.RepositoryCode
		where a.AmountImport>0
		group by a.ItemCode,b.ItemName,b1.UnitOfMeasureName,b2.UsageName,b3.ItemCategoryName,a.DateEnd,a.Shipment,c.RepositoryName,b4.GroupName
		order by c.RepositoryName,a.ItemCode
	end
	else
	begin
		select a.ItemCode,b.ItemName,b1.UnitOfMeasureName,b2.UsageName,b3.ItemCategoryName,a.DateEnd,a.Shipment,c.RepositoryName,b4.GroupName
		from InventoryGumshoe a inner join Items b on a.ItemCode=b.ItemCode inner join UnitOfMeasure b1 on b.UnitOfMeasureCode=b1.UnitOfMeasureCode
		inner join Usage b2 on b.UsageCode=b2.UsageCode inner join ItemCategory b3 on b.ItemCategoryCode=b3.ItemCategoryCode inner join ItemGroup b4 on b3.GroupCode=b4.GroupCode
		inner join RepositoryCatalog c on a.RepositoryCode=c.RepositoryCode
		where a.RepositoryCode=@RepositoryCode and a.AmountImport>0
		group by a.ItemCode,b.ItemName,b1.UnitOfMeasureName,b2.UsageName,b3.ItemCategoryName,a.DateEnd,a.Shipment,c.RepositoryName,b4.GroupName
		order by c.RepositoryName,a.ItemCode
	end
end
go
--------------------------- Lay danh sach benh nhan vao vien theo ngay
if exists(select name from sysobjects where name ='pro_Report_View_PatientReceive')
	drop procedure pro_Report_View_PatientReceive
go
create procedure pro_Report_View_PatientReceive
(
	@frDate date,
	@toDate date,
	@PatientType int,
	@SMS char='F'
)
as
begin
	if @SMS='F'
	begin
		select a.PatientCode,b.PatientName,a.PatientReceiveID,a.CreateDate,b.PatientBirthday,(year(getdate())-b.PatientBirthyear) PatientAge, (case b.PatientGender when 0 then N'Nữ' else 'Nam' end) PatientGenderName,a.Address,a3.WardName,a2.DistrictName,a1.ProvincialName,b.PatientMobile,c.ObjectName
		from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode left join Catalog_Provincial a1 on a.ProvincialCode=a1.ProvincialCode left join Catalog_District a2 on a.DistrictCode=a2.DistrictCode left join Catalog_Ward a3 on a.WardCode=a3.WardCode inner join Object c on a.ObjectCode=c.ObjectCode
		where CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103) and a.PatientType=(case @PatientType when -1 then a.PatientType else @PatientType end)
		group by a.PatientCode,b.PatientName,a.PatientReceiveID,a.CreateDate,b.PatientBirthday,b.PatientBirthyear,b.PatientGender,a.Address,a3.WardName,a2.DistrictName,a1.ProvincialName,b.PatientMobile,c.ObjectName
	end
	else
	begin
		select a.PatientCode,b.PatientName,a.PatientReceiveID,a.CreateDate,b.PatientBirthday,(year(getdate())-b.PatientBirthyear) PatientAge, (case b.PatientGender when 0 then N'Nữ' else 'Nam' end) PatientGenderName,a.Address,a3.WardName,a2.DistrictName,a1.ProvincialName,b.PatientMobile,c.ObjectName
		from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode left join Catalog_Provincial a1 on a.ProvincialCode=a1.ProvincialCode left join Catalog_District a2 on a.DistrictCode=a2.DistrictCode left join Catalog_Ward a3 on a.WardCode=a3.WardCode inner join Object c on a.ObjectCode=c.ObjectCode
		where CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103) and a.PatientType=(case @PatientType when -1 then a.PatientType else @PatientType end) and a.PatientReceiveID not in(select PatientReceiveID from PatientsSendSMS)
		group by a.PatientCode,b.PatientName,a.PatientReceiveID,a.CreateDate,b.PatientBirthday,b.PatientBirthyear,b.PatientGender,a.Address,a3.WardName,a2.DistrictName,a1.ProvincialName,b.PatientMobile,c.ObjectName
	end
end
go
--------------------------- Bao cao Xuat thuoc tong hop theo tung benh nhan trong tu truc
if exists(select name from sysobjects where name ='pro_Report_View_RealMedicinesTH')
	drop procedure pro_Report_View_RealMedicinesTH
go
create procedure pro_Report_View_RealMedicinesTH
(
	@RepositoryCode varchar(50),
	@frDate date,
	@toDate date
)
as
begin
	/*
	IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='report_RealMedicines') 
	begin
		drop table report_RealMedicines
	end
	CREATE TABLE report_RealMedicines
	(
		ItemCode varchar(50) not null,
		RepositoryCode varchar(50) not null,
		TotalQuantity decimal(18,4) default 0,
		CONSTRAINT report_RealMedicines_pk PRIMARY KEY (ItemCode)
	)*/
	Declare @TableTemp table(ItemCode varchar(50),RepositoryCode varchar(50),TotalQuantity decimal(18,4) default 0)
	insert @TableTemp(ItemCode,RepositoryCode,TotalQuantity)( select b.ItemCode,b.RepositoryCode,SUM(b.Quantity) TotalQuantity from RealMedicinesForPatients a inner join RealMedicinesForPatientsDetail b on a.RowID=b.RealRowID where a.PatientReceiveID in(select PatientReceiveID from PatientReceive where CONVERT(date,CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103))group by b.ItemCode,b.RepositoryCode)
	if @RepositoryCode <>''
		begin
			select a.ItemCode,a.RepositoryCode,a.TotalQuantity,b.ItemName from @TableTemp a inner join Items b on a.ItemCode=b.ItemCode and a.RepositoryCode=@RepositoryCode
		end
	else
		begin
			select a.ItemCode,a.RepositoryCode,a.TotalQuantity,b.ItemName from @TableTemp a inner join Items b on a.ItemCode=b.ItemCode
		end
end
go
--------------------------- Bao cao Xuat thuoc chi tiet theo tung benh nhan trong tu truc
if exists(select name from sysobjects where name ='pro_Report_View_RealMedicinesDetail')
	drop procedure pro_Report_View_RealMedicinesDetail
go
create procedure pro_Report_View_RealMedicinesDetail
(
	@RepositoryCode varchar(50),
	@frDate date,
	@toDate date
)
as
begin
	if @RepositoryCode <>''
		begin
			select (N'Ngày Vào: ' + convert(char(10),a.CreateDate,103) +N' Mã BN: ' + a.PatientCode + N' - Họ tên: ' + a1.PatientName + N' - Năm Sinh: '+convert(nvarchar(10),a1.PatientBirthyear) +N' - Tuổi: ' +convert(varchar(10),a1.PatientAge) + N' - Giới Tính: '+(case when a1.PatientGender=0 then N'Nữ' else 'Nam' end) +N' - Ghi Chú: '+a.Reason)Info,b3.DepartmentName 'Khoa Phòng',b.DateApproved 'Ngày Cấp', b1.ItemCode 'Mã Thuốc',b2.ItemName 'Tên Thuốc',b1.Quantity 'SL',b1.UnitPrice 'Đơn Giá',b1.Amount 'Thành Tiền',b4.RepositoryName 'Kho'
			from PatientReceive a inner join Patients a1 on a.PatientCode=a1.PatientCode inner join RealMedicinesForPatients b on a.PatientReceiveID=b.PatientReceiveID
			inner join RealMedicinesForPatientsDetail b1 on b.RowID=b1.RealRowID inner join Items b2 on b1.ItemCode=b2.ItemCode
			inner join Department b3 on b.DepartmentCode=b3.DepartmentCode inner join RepositoryCatalog b4 on b1.RepositoryCode=b4.RepositoryCode
			where CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103) and b1.RepositoryCode=@RepositoryCode
			order by a.PatientCode,b.DateApproved,b2.ItemName
		end
	else
		begin
			select (N'Ngày Vào: ' + convert(char(10),a.CreateDate,103) +N' Mã BN: ' + a.PatientCode + N' - Họ tên: ' + a1.PatientName + N' - Năm Sinh: '+convert(nvarchar(10),a1.PatientBirthyear) +N' - Tuổi: ' +convert(varchar(10),a1.PatientAge) + N' - Giới Tính: '+(case when a1.PatientGender=0 then N'Nữ' else 'Nam' end) +N' - Ghi Chú: '+a.Reason)Info,b3.DepartmentName 'Khoa Phòng',b.DateApproved 'Ngày Cấp', b1.ItemCode 'Mã Thuốc',b2.ItemName 'Tên Thuốc',b1.Quantity 'SL',b1.UnitPrice 'Đơn Giá',b1.Amount 'Thành Tiền',b4.RepositoryName 'Kho'
			from PatientReceive a inner join Patients a1 on a.PatientCode=a1.PatientCode inner join RealMedicinesForPatients b on a.PatientReceiveID=b.PatientReceiveID
			inner join RealMedicinesForPatientsDetail b1 on b.RowID=b1.RealRowID inner join Items b2 on b1.ItemCode=b2.ItemCode
			inner join Department b3 on b.DepartmentCode=b3.DepartmentCode inner join RepositoryCatalog b4 on b1.RepositoryCode=b4.RepositoryCode
			where CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103)
			order by a.PatientCode,b.DateApproved,b2.ItemName
		end
end
go
-- exec pro_Report_View_RealMedicinesTH '','2014-07-01','2014-07-01'
-- exec pro_Report_View_MedicinesForPatients 'KHO004','01/04/2015','17/04/2015',''
--------------------------- Bao cao Xuat thuoc theo tung benh nhan trong cap toa thuoc
if exists(select name from sysobjects where name ='pro_Report_View_MedicinesForPatients')
	drop procedure pro_Report_View_MedicinesForPatients
go
create procedure pro_Report_View_MedicinesForPatients
(
	@RepositoryCode varchar(50),
	@Datefrom varchar(10),
	@Dateto varchar(10),
	@ItemCode varchar(50)
)
as
begin
	select a.PatientCode,b.PatientName,(case when b.PatientGender=0 then N'Nữ'else N'Nam' end)PatientGenderName,b.PatientBirthyear,a.MedicalRecordCode,a.PostingDate,a3.ItemName,a2.Quantity,a2.QuantityExport,a2.UnitPrice,a2.SalesPrice,a4.ItemCategoryName,a5.GroupName,a6.RepositoryName,d.DateEnd,d.Shipment,a7.UnitOfMeasureName,c.DepartmentName
	from MedicalRecord a inner join MedicinesForPatients a1 on a.MedicalRecordCode=a1.MedicalRecordCode
	inner join Patients b on a.PatientCode=b.PatientCode left join Department c on a.DepartmentCode=c.DepartmentCode
	inner join MedicinesForPatientsDetail a2 on a1.MedicalRecordCode=a2.MedicalRecordCode
	inner join Items a3 on a2.ItemCode=a3.ItemCode inner join ItemCategory a4 on a3.ItemCategoryCode=a4.ItemCategoryCode
	inner join ItemGroup a5 on a4.GroupCode=a5.GroupCode inner join RepositoryCatalog a6 on a2.RepositoryCode=a6.RepositoryCode
	inner join InventoryGumshoe d on a2.RowIDInventoryGumshoe=d.RowID inner join UnitOfMeasure a7 on a3.UnitOfMeasureCode=a7.UnitOfMeasureCode
	where a2.RepositoryCode=@RepositoryCode 
	and a2.ItemCode = case @ItemCode when '' then a2.ItemCode else @ItemCode end
	and CONVERT(date,a.PostingDate,103) between CONVERT(date,@Datefrom,103) and CONVERT(date,@Dateto,103)
	order by a.MedicalRecordCode
end
go
--------------------------- Thống kê số ca bs chi dinh
if exists(select name from sysobjects where name ='pro_Report_BSChiDinh')
	drop procedure pro_Report_BSChiDinh
go
--------------------------- Thống kê số ca bs thuc hien
if exists(select name from sysobjects where name ='pro_Report_BSThucHien')
	drop procedure pro_Report_BSThucHien
go
--------------------------- Bieu do bao cao doanh thu theo ngay
if exists(select name from sysobjects where name ='pro_ChartVP_DoanhThuNgay')
	drop procedure pro_ChartVP_DoanhThuNgay
go
create procedure pro_ChartVP_DoanhThuNgay
(
	@frDate varchar(10),
	@toDate varchar(10)
)
as
begin
	declare @TableResult table(PostingDate date,Tong decimal(18,0))
	declare @CreateDate date
	declare @KCB decimal(18,0)=0
	declare @TH decimal(18,0)=0
	declare @Tongdv decimal(18,0)=0
	declare @Tongth decimal(18,0)=0
	declare @Tongdt decimal(18,0)=0
	declare @Tongtt decimal(18,0)=0
	declare @Tong decimal(18,0)=0

	declare cur1 cursor read_only fast_forward
	for select distinct CONVERT(date,a.PostingDate,103) PostingDate from BanksAccount a where CONVERT(date,a.PostingDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103)
	open cur1
	fetch next from cur1 into @CreateDate
	while @@FETCH_STATUS = 0
	begin
			set @Tongdv=(select ISNULL(SUM(b.Quantity*b.ServicePrice),0) TotalReal from BanksAccount a inner join BanksAccountDetail b on a.BanksAccountCode=b.BanksAccountCode
			where a.Cancel =0 and a.Report in(1) and CONVERT(date,a.PostingDate,103)=CONVERT(date,@CreateDate,103))
			set @Tongth=(select ISNULL(SUM(b.Quantity*b.UnitPrice),0) from MedicinesRetail a inner join MedicinesRetailDetail b on a.RetailCode=b.RetailCode
			where a.Paid =1 and CONVERT(date,a.ExportDate,103)=CONVERT(date,@CreateDate,103))
			set @Tongdt=(select ISNULL(SUM(b.Quantity*b.UnitPrice),0) from MedicinesForPatients a inner join MedicinesForPatientsDetail b on a.MedicalRecordCode=b.MedicalRecordCode
			where CONVERT(date,a.DateApproved,103)=CONVERT(date,@CreateDate,103))
			set @Tongtt=(select ISNULL(SUM(b.Quantity*b.UnitPrice),0) from RealMedicinesForPatients a inner join RealMedicinesForPatientsDetail b on a.RowID=b.RealRowID
			where CONVERT(date,a.DateApproved,103)=CONVERT(date,@CreateDate,103))
			set @Tong=@Tongdv+@Tongth+@Tongth+@Tongtt
			insert into @TableResult(PostingDate,Tong) values(@CreateDate,@Tong)
		FETCH NEXT FROM cur1 into @CreateDate
	end
	CLOSE cur1
	DEALLOCATE cur1
	select CONVERT(char(10),PostingDate,104) PostingDate,Tong as TotalReal from @TableResult
end
go
--------------------------- Bieu do bao cao doanh thu theo thang
if exists(select name from sysobjects where name = 'pro_ChartVP_DoanhThuThang')
	drop procedure pro_ChartVP_DoanhThuThang
go
create procedure pro_ChartVP_DoanhThuThang
as
begin
	declare @TableResult table(PostingDate date,Tong decimal(18,0))
	declare @CreateDate date
	declare @KCB decimal(18,0)=0
	declare @TH decimal(18,0)=0
	declare @Tongdv decimal(18,0)=0
	declare @Tongth decimal(18,0)=0
	declare @Tongdt decimal(18,0)=0
	declare @Tongtt decimal(18,0)=0
	declare @Tong decimal(18,0)=0

	declare cur1 cursor read_only fast_forward
	for select distinct (CONVERT(date,a.PostingDate,103)) PostingDate from BanksAccount a 
	open cur1
	fetch next from cur1 into @CreateDate
	while @@FETCH_STATUS = 0
	begin
			set @Tongdv=(select ISNULL(SUM(a.TotalReal),0) from BanksAccount a
			where a.Cancel =0 and a.Report in(1) and month(CONVERT(date,a.PostingDate,103))=month(CONVERT(date,@CreateDate,103)))
			set @Tongth=(select ISNULL(SUM(a.TotalAmountReal),0) from MedicinesRetail a
			where a.Paid =1 and month(CONVERT(date,a.ExportDate,103))=month(CONVERT(date,@CreateDate,103)))
			set @Tongdt=(select ISNULL(SUM(b.Amount),0) from MedicinesForPatients a inner join MedicinesForPatientsDetail b 
			on a.MedicalRecordCode=b.MedicalRecordCode
			where month(CONVERT(date,a.DateApproved,103))=month(CONVERT(date,@CreateDate,103)))
			set @Tongtt=(select ISNULL(SUM(b.Amount),0) from RealMedicinesForPatients a inner join RealMedicinesForPatientsDetail b 
			on a.RowID=b.RealRowID
			where month(CONVERT(date,a.DateApproved,103))=month(CONVERT(date,@CreateDate,103)))
			set @Tong=@Tongdv+@Tongth+@Tongdt+@Tongtt
			insert into @TableResult(PostingDate,Tong) values(@CreateDate,@Tong)
		FETCH NEXT FROM cur1 into @CreateDate
	end
	CLOSE cur1
	DEALLOCATE cur1
	select distinct month(PostingDate) as MM,Tong as TotalReal from @TableResult
end
go
--------------------------- Bao cao Xuat thuoc theo tung benh nhan trong xuat ban thuoc
if exists(select name from sysobjects where name like'%pro_Report_View_RetailForPatients%')
	drop procedure pro_Report_View_RetailForPatients
go
create procedure pro_Report_View_RetailForPatients
(
	@RepositoryCode varchar(50),
	@IDatefrom varchar(10),
	@IDateto varchar(10),
	@ItemCode varchar(50),
	@Paid int
)
as
begin
	if(@Paid=-1)
	begin
	if (@ItemCode <>'' and @IDatefrom <>'' and @IDateto <>'')
		begin
			select a.RetailCode,a.FullName,a.Birthyear,a4.ItemCategoryName,a5.GroupName,a6.RepositoryName,d.DateEnd,d.Shipment,a3.ItemName,
			a7.UnitOfMeasureName,a1.QuantityExport,a1.UnitPrice,a1.Instruction,a1.DateOfIssues,a.ExportDate,a1.Amount,a8.EmployeeName,(case a.Paid when 1 then N'Đã Thu' when -1 then N'Hủy' else N'Chờ Thu' end) Paid,a.IDate
			from MedicinesRetail a inner join MedicinesRetailDetail a1 on a.RetailCode=a1.RetailCode
			inner join Items a3 on a1.ItemCode=a3.ItemCode inner join ItemCategory a4 on a3.ItemCategoryCode=a4.ItemCategoryCode
			inner join ItemGroup a5 on a4.GroupCode=a5.GroupCode inner join RepositoryCatalog a6 on a1.RepositoryCode=a6.RepositoryCode
			inner join InventoryGumshoe d on a1.RowIDInventoryGumshoe=d.RowID inner join UnitOfMeasure a7 on a3.UnitOfMeasureCode=a7.UnitOfMeasureCode
			inner join Employee a8 on a.EmployeeCode=a8.EmployeeCode
			where a1.RepositoryCode=@RepositoryCode and a.Paid in(-1) and a1.ItemCode=@ItemCode and CONVERT(date,a.ExportDate,103) between CONVERT(date,@IDatefrom,103) and CONVERT(date,@IDateto,103)
			order by a.RetailCode
		end
	else if (@ItemCode <>'' and @IDatefrom='' and @IDateto='')
		begin
			select a.RetailCode,a.FullName,a.Birthyear,a4.ItemCategoryName,a5.GroupName,a6.RepositoryName,d.DateEnd,d.Shipment,a3.ItemName,
			a7.UnitOfMeasureName,a1.QuantityExport,a1.UnitPrice,a1.Instruction,a1.DateOfIssues,a.ExportDate,a1.Amount,a8.EmployeeName,(case a.Paid when 1 then N'Đã Thu' when -1 then N'Hủy' else N'Chờ Thu' end) Paid,a.IDate
			from MedicinesRetail a inner join MedicinesRetailDetail a1 on a.RetailCode=a1.RetailCode
			inner join Items a3 on a1.ItemCode=a3.ItemCode inner join ItemCategory a4 on a3.ItemCategoryCode=a4.ItemCategoryCode
			inner join ItemGroup a5 on a4.GroupCode=a5.GroupCode inner join RepositoryCatalog a6 on a1.RepositoryCode=a6.RepositoryCode
			inner join InventoryGumshoe d on a1.RowIDInventoryGumshoe=d.RowID inner join UnitOfMeasure a7 on a3.UnitOfMeasureCode=a7.UnitOfMeasureCode
			inner join Employee a8 on a.EmployeeCode=a8.EmployeeCode
			where a1.RepositoryCode=@RepositoryCode and a.Paid in(-1) and a1.ItemCode=@ItemCode
			order by a.RetailCode
		end
	else if (@ItemCode ='' and @IDatefrom <>'' and @IDateto<>'')
		begin
			select a.RetailCode,a.FullName,a.Birthyear,a4.ItemCategoryName,a5.GroupName,a6.RepositoryName,d.DateEnd,d.Shipment,a3.ItemName,
			a7.UnitOfMeasureName,a1.QuantityExport,a1.UnitPrice,a1.Instruction,a1.DateOfIssues,a.ExportDate,a1.Amount,a8.EmployeeName,(case a.Paid when 1 then N'Đã Thu' when -1 then N'Hủy' else N'Chờ Thu' end) Paid,a.IDate
			from MedicinesRetail a inner join MedicinesRetailDetail a1 on a.RetailCode=a1.RetailCode
			inner join Items a3 on a1.ItemCode=a3.ItemCode inner join ItemCategory a4 on a3.ItemCategoryCode=a4.ItemCategoryCode
			inner join ItemGroup a5 on a4.GroupCode=a5.GroupCode inner join RepositoryCatalog a6 on a1.RepositoryCode=a6.RepositoryCode
			inner join InventoryGumshoe d on a1.RowIDInventoryGumshoe=d.RowID inner join UnitOfMeasure a7 on a3.UnitOfMeasureCode=a7.UnitOfMeasureCode
			inner join Employee a8 on a.EmployeeCode=a8.EmployeeCode
			where a1.RepositoryCode=@RepositoryCode and a.Paid in(-1) and CONVERT(date,a.ExportDate,103) between CONVERT(date,@IDatefrom,103) and CONVERT(date,@IDateto,103)
			order by a.RetailCode
		end
	else
		begin
			select a.RetailCode,a.FullName,a.Birthyear,a4.ItemCategoryName,a5.GroupName,a6.RepositoryName,d.DateEnd,d.Shipment,a3.ItemName,
			a7.UnitOfMeasureName,a1.QuantityExport,a1.UnitPrice,a1.Instruction,a1.DateOfIssues,a.ExportDate,a1.Amount,a8.EmployeeName,(case a.Paid when 1 then N'Đã Thu' when -1 then N'Hủy' else N'Chờ Thu' end) Paid,a.IDate
			from MedicinesRetail a inner join MedicinesRetailDetail a1 on a.RetailCode=a1.RetailCode
			inner join Items a3 on a1.ItemCode=a3.ItemCode inner join ItemCategory a4 on a3.ItemCategoryCode=a4.ItemCategoryCode
			inner join ItemGroup a5 on a4.GroupCode=a5.GroupCode inner join RepositoryCatalog a6 on a1.RepositoryCode=a6.RepositoryCode
			inner join InventoryGumshoe d on a1.RowIDInventoryGumshoe=d.RowID inner join UnitOfMeasure a7 on a3.UnitOfMeasureCode=a7.UnitOfMeasureCode
			inner join Employee a8 on a.EmployeeCode=a8.EmployeeCode
			where a1.RepositoryCode=@RepositoryCode and a.Paid in(-1)
			order by a.RetailCode
		end
	end
	else
	begin
		if (@ItemCode <>'' and @IDatefrom <>'' and @IDateto <>'')
		begin
			select a.RetailCode,a.FullName,a.Birthyear,a4.ItemCategoryName,a5.GroupName,a6.RepositoryName,d.DateEnd,d.Shipment,a3.ItemName,
			a7.UnitOfMeasureName,a1.QuantityExport,a1.UnitPrice,a1.Instruction,a1.DateOfIssues,a.ExportDate,a1.Amount,a8.EmployeeName,(case a.Paid when 1 then N'Đã Thu' when -1 then N'Hủy' else N'Chờ Thu' end) Paid,a.IDate
			from MedicinesRetail a inner join MedicinesRetailDetail a1 on a.RetailCode=a1.RetailCode
			inner join Items a3 on a1.ItemCode=a3.ItemCode inner join ItemCategory a4 on a3.ItemCategoryCode=a4.ItemCategoryCode
			inner join ItemGroup a5 on a4.GroupCode=a5.GroupCode inner join RepositoryCatalog a6 on a1.RepositoryCode=a6.RepositoryCode
			inner join InventoryGumshoe d on a1.RowIDInventoryGumshoe=d.RowID inner join UnitOfMeasure a7 on a3.UnitOfMeasureCode=a7.UnitOfMeasureCode
			inner join Employee a8 on a.EmployeeCode=a8.EmployeeCode
			where a.Paid in(0,1) and a1.RepositoryCode=@RepositoryCode and a1.ItemCode=@ItemCode and CONVERT(date,a.ExportDate,103) between CONVERT(date,@IDatefrom,103) and CONVERT(date,@IDateto,103)
			order by a.RetailCode
		end
	else if (@ItemCode <>'' and @IDatefrom='' and @IDateto='')
		begin
			select a.RetailCode,a.FullName,a.Birthyear,a4.ItemCategoryName,a5.GroupName,a6.RepositoryName,d.DateEnd,d.Shipment,a3.ItemName,
			a7.UnitOfMeasureName,a1.QuantityExport,a1.UnitPrice,a1.Instruction,a1.DateOfIssues,a.ExportDate,a1.Amount,a8.EmployeeName,(case a.Paid when 1 then N'Đã Thu' when -1 then N'Hủy' else N'Chờ Thu' end) Paid,a.IDate
			from MedicinesRetail a inner join MedicinesRetailDetail a1 on a.RetailCode=a1.RetailCode
			inner join Items a3 on a1.ItemCode=a3.ItemCode inner join ItemCategory a4 on a3.ItemCategoryCode=a4.ItemCategoryCode
			inner join ItemGroup a5 on a4.GroupCode=a5.GroupCode inner join RepositoryCatalog a6 on a1.RepositoryCode=a6.RepositoryCode
			inner join InventoryGumshoe d on a1.RowIDInventoryGumshoe=d.RowID inner join UnitOfMeasure a7 on a3.UnitOfMeasureCode=a7.UnitOfMeasureCode
			inner join Employee a8 on a.EmployeeCode=a8.EmployeeCode
			where a.Paid in(0,1) and a1.RepositoryCode=@RepositoryCode and a1.ItemCode=@ItemCode
			order by a.RetailCode
		end
	else if (@ItemCode ='' and @IDatefrom <>'' and @IDateto<>'')
		begin
			select a.RetailCode,a.FullName,a.Birthyear,a4.ItemCategoryName,a5.GroupName,a6.RepositoryName,d.DateEnd,d.Shipment,a3.ItemName,
			a7.UnitOfMeasureName,a1.QuantityExport,a1.UnitPrice,a1.Instruction,a1.DateOfIssues,a.ExportDate,a1.Amount,a8.EmployeeName,(case a.Paid when 1 then N'Đã Thu' when -1 then N'Hủy' else N'Chờ Thu' end) Paid,a.IDate
			from MedicinesRetail a inner join MedicinesRetailDetail a1 on a.RetailCode=a1.RetailCode
			inner join Items a3 on a1.ItemCode=a3.ItemCode inner join ItemCategory a4 on a3.ItemCategoryCode=a4.ItemCategoryCode
			inner join ItemGroup a5 on a4.GroupCode=a5.GroupCode inner join RepositoryCatalog a6 on a1.RepositoryCode=a6.RepositoryCode
			inner join InventoryGumshoe d on a1.RowIDInventoryGumshoe=d.RowID inner join UnitOfMeasure a7 on a3.UnitOfMeasureCode=a7.UnitOfMeasureCode
			inner join Employee a8 on a.EmployeeCode=a8.EmployeeCode
			where a.Paid in(0,1) and a1.RepositoryCode=@RepositoryCode and CONVERT(date,a.ExportDate,103) between CONVERT(date,@IDatefrom,103) and CONVERT(date,@IDateto,103)
			order by a.RetailCode
		end
	else
		begin
			select a.RetailCode,a.FullName,a.Birthyear,a4.ItemCategoryName,a5.GroupName,a6.RepositoryName,d.DateEnd,d.Shipment,a3.ItemName,
			a7.UnitOfMeasureName,a1.QuantityExport,a1.UnitPrice,a1.Instruction,a1.DateOfIssues,a.ExportDate,a1.Amount,a8.EmployeeName,(case a.Paid when 1 then N'Đã Thu' when -1 then N'Hủy' else N'Chờ Thu' end) Paid,a.IDate
			from MedicinesRetail a inner join MedicinesRetailDetail a1 on a.RetailCode=a1.RetailCode
			inner join Items a3 on a1.ItemCode=a3.ItemCode inner join ItemCategory a4 on a3.ItemCategoryCode=a4.ItemCategoryCode
			inner join ItemGroup a5 on a4.GroupCode=a5.GroupCode inner join RepositoryCatalog a6 on a1.RepositoryCode=a6.RepositoryCode
			inner join InventoryGumshoe d on a1.RowIDInventoryGumshoe=d.RowID inner join UnitOfMeasure a7 on a3.UnitOfMeasureCode=a7.UnitOfMeasureCode
			inner join Employee a8 on a.EmployeeCode=a8.EmployeeCode
			where a.Paid in(0,1) and a1.RepositoryCode=@RepositoryCode
			order by a.RetailCode
		end
	end
end
go
--------------------------- Bao cao ket qua dieu tri
if exists(select name from sysobjects where name ='pro_Rpt_KetQuaDieuTri')
	drop procedure pro_Rpt_KetQuaDieuTri
go
create procedure pro_Rpt_KetQuaDieuTri
(
	@PatientType int,
	@frDate char(10),
	@toDate char(10),
	@DepartmentCode varchar(50)
)
as
begin
	if @PatientType<>-1
		begin
			if @DepartmentCode<>''
			begin
				select a.PatientCode,a.CreateDate,a1.PatientName,a1.PatientBirthyear,a1.PatientAge,(case when a1.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,
				b.Symptoms DiagnosisCode,(b.ICD10_Custom + ' - ' + b.ICD10Name_Custom) DiagnosisNameIn,b2.ObjectName,(RTRIM(c.DiagnosisCode) + ' - ' + RTRIM(c.DiagnosisName)) DiagnosisNameOut,
				d.TackleName ResultsName,[dbo].func_PatientOfAddressFull(a.Address,wa.WardName,dis.DistrictName,pro.ProvincialName) PatientAddress,b.Advices AdvicesOut, 0 as Chon,a.PatientReceiveID
				 from PatientReceive a inner join Patients a1 on a.PatientCode=a1.PatientCode inner join MedicalRecord b on a.PatientReceiveID=b.PatientReceiveID
				 --left join Diagnosis b1 on b.DiagnosisCode=b1.RowID 
				 inner join Object b2 on b.ObjectCode=b2.ObjectCode
				 left join Diagnosis c on b.DiagnosisCode=c.RowID
				 left join Tackle d on b.TackleCode=d.TackleCode
				 left join Catalog_District dis on a.DistrictCode=dis.DistrictCode left join Catalog_Provincial pro on
				 a.ProvincialCode=pro.ProvincialCode left join Catalog_Ward wa on a.WardCode=wa.WardCode
				 where a.PatientType=@PatientType and CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103) and b.DepartmentCode=@DepartmentCode
				 union all
				 select a.PatientCode,a.CreateDate,a1.PatientName,a1.PatientBirthyear,a1.PatientAge,(case when a1.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,
				b.DiagnosisCode,(RTRIM(b1.DiagnosisCode) + ' - ' + RTRIM(b1.DiagnosisName)) DiagnosisNameIn,b2.ObjectName,(RTRIM(c.DiagnosisCode) + ' - ' + RTRIM(c.DiagnosisName)) DiagnosisNameOut,
				d.ResultsName,[dbo].func_PatientOfAddressFull(a.Address,wa.WardName,dis.DistrictName,pro.ProvincialName) PatientAddress,b3.Advices AdvicesOut, 0 as Chon,a.PatientReceiveID
				 from PatientReceive a inner join Patients a1 on a.PatientCode=a1.PatientCode inner join MedicalEmergency b on a.PatientReceiveID=b.PatientReceiveID
				 left join Diagnosis b1 on b.ICD10=b1.DiagnosisCode inner join Object b2 on b.ObjectCode=b2.ObjectCode
				 left join MedicalEmergencyOut b3 on b.MedicalEmergencyCode=b3.MedicalEmergencyCode left join Diagnosis c on b3.ICD10Out=c.DiagnosisCode
				 left join TreatmentResults d on b3.TreatmentResults=d.RowID
				 left join Catalog_District dis on a.DistrictCode=dis.DistrictCode left join Catalog_Provincial pro on
				 a.ProvincialCode=pro.ProvincialCode left join Catalog_Ward wa on a.WardCode=wa.WardCode
				 where a.PatientType=@PatientType and CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103) and b.DepartmentCode=@DepartmentCode
			 end
			 else
			 begin
				select a.PatientCode,a.CreateDate,a1.PatientName,a1.PatientBirthyear,a1.PatientAge,(case when a1.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,
				b.Symptoms DiagnosisCode,(b.ICD10_Custom + ' - ' + b.ICD10Name_Custom) DiagnosisNameIn,b2.ObjectName,(RTRIM(c.DiagnosisCode) + ' - ' + RTRIM(c.DiagnosisName)) DiagnosisNameOut,
				d.TackleName ResultsName,[dbo].func_PatientOfAddressFull(a.Address,wa.WardName,dis.DistrictName,pro.ProvincialName) PatientAddress,b.Advices AdvicesOut, 0 as Chon,a.PatientReceiveID
				 from PatientReceive a inner join Patients a1 on a.PatientCode=a1.PatientCode inner join MedicalRecord b on a.PatientReceiveID=b.PatientReceiveID
				 --left join Diagnosis b1 on b.DiagnosisCode=b1.RowID 
				 inner join Object b2 on b.ObjectCode=b2.ObjectCode
				 left join Diagnosis c on b.DiagnosisCode=c.RowID
				 left join Tackle d on b.TackleCode=d.TackleCode
				  left join Catalog_District dis on a.DistrictCode=dis.DistrictCode left join Catalog_Provincial pro on
				 a.ProvincialCode=pro.ProvincialCode left join Catalog_Ward wa on a.WardCode=wa.WardCode
				 where a.PatientType=@PatientType and CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103)
				 union all
				 select a.PatientCode,a.CreateDate,a1.PatientName,a1.PatientBirthyear,a1.PatientAge,(case when a1.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,
				b.DiagnosisCode,(RTRIM(b1.DiagnosisCode) + ' - ' + RTRIM(b1.DiagnosisName)) DiagnosisNameIn,b2.ObjectName,(RTRIM(c.DiagnosisCode) + ' - ' + RTRIM(c.DiagnosisName)) DiagnosisNameOut,
				d.ResultsName,[dbo].func_PatientOfAddressFull(a.Address,wa.WardName,dis.DistrictName,pro.ProvincialName) PatientAddress,b3.Advices AdvicesOut, 0 as Chon,a.PatientReceiveID
				 from PatientReceive a inner join Patients a1 on a.PatientCode=a1.PatientCode inner join MedicalEmergency b on a.PatientReceiveID=b.PatientReceiveID
				 left join Diagnosis b1 on b.ICD10=b1.DiagnosisCode inner join Object b2 on b.ObjectCode=b2.ObjectCode
				 left join MedicalEmergencyOut b3 on b.MedicalEmergencyCode=b3.MedicalEmergencyCode left join Diagnosis c on b3.ICD10Out=c.DiagnosisCode
				 left join TreatmentResults d on b3.TreatmentResults=d.RowID
				  left join Catalog_District dis on a.DistrictCode=dis.DistrictCode left join Catalog_Provincial pro on
				 a.ProvincialCode=pro.ProvincialCode left join Catalog_Ward wa on a.WardCode=wa.WardCode
				 where a.PatientType=@PatientType and CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103)
			 end
		end
	else
		begin
			if @DepartmentCode<>''
				begin
					select a.PatientCode,a.CreateDate,a1.PatientName,a1.PatientBirthyear,a1.PatientAge,(case when a1.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,
				b.Symptoms DiagnosisCode,(b.ICD10_Custom + ' - ' + b.ICD10Name_Custom) DiagnosisNameIn,b2.ObjectName,(RTRIM(c.DiagnosisCode) + ' - ' + RTRIM(c.DiagnosisName)) DiagnosisNameOut,
				d.TackleName ResultsName,[dbo].func_PatientOfAddressFull(a.Address,wa.WardName,dis.DistrictName,pro.ProvincialName) PatientAddress,b.Advices AdvicesOut, 0 as Chon,a.PatientReceiveID
				 from PatientReceive a inner join Patients a1 on a.PatientCode=a1.PatientCode inner join MedicalRecord b on a.PatientReceiveID=b.PatientReceiveID
				 --left join Diagnosis b1 on b.DiagnosisCode=b1.RowID 
				 inner join Object b2 on b.ObjectCode=b2.ObjectCode
				 left join Diagnosis c on b.DiagnosisCode=c.RowID
				 left join Tackle d on b.TackleCode=d.TackleCode
				 left join Catalog_District dis on a.DistrictCode=dis.DistrictCode left join Catalog_Provincial pro on
				 a.ProvincialCode=pro.ProvincialCode left join Catalog_Ward wa on a.WardCode=wa.WardCode
				 where CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103) and b.DepartmentCode=@DepartmentCode
				 union all
				 select a.PatientCode,a.CreateDate,a1.PatientName,a1.PatientBirthyear,a1.PatientAge,(case when a1.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,
				b.DiagnosisCode,(RTRIM(b1.DiagnosisCode) + ' - ' + RTRIM(b1.DiagnosisName)) DiagnosisNameIn,b2.ObjectName,(RTRIM(c.DiagnosisCode) + ' - ' + RTRIM(c.DiagnosisName)) DiagnosisNameOut,
				d.ResultsName,[dbo].func_PatientOfAddressFull(a.Address,wa.WardName,dis.DistrictName,pro.ProvincialName) PatientAddress,b3.Advices AdvicesOut, 0 as Chon,a.PatientReceiveID
				 from PatientReceive a inner join Patients a1 on a.PatientCode=a1.PatientCode inner join MedicalEmergency b on a.PatientReceiveID=b.PatientReceiveID
				 left join Diagnosis b1 on b.ICD10=b1.DiagnosisCode inner join Object b2 on b.ObjectCode=b2.ObjectCode
				 left join MedicalEmergencyOut b3 on b.MedicalEmergencyCode=b3.MedicalEmergencyCode left join Diagnosis c on b3.ICD10Out=c.DiagnosisCode
				 left join TreatmentResults d on b3.TreatmentResults=d.RowID
				 left join Catalog_District dis on a.DistrictCode=dis.DistrictCode left join Catalog_Provincial pro on
				 a.ProvincialCode=pro.ProvincialCode left join Catalog_Ward wa on a.WardCode=wa.WardCode
				 where CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103) and b.DepartmentCode=@DepartmentCode
				 end
			 else
				 begin
					select a.PatientCode,a.CreateDate,a1.PatientName,a1.PatientBirthyear,a1.PatientAge,(case when a1.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,
					b.Symptoms DiagnosisCode,(b.ICD10_Custom + ' - ' + b.ICD10Name_Custom) DiagnosisNameIn,b2.ObjectName,(RTRIM(c.DiagnosisCode) + ' - ' + RTRIM(c.DiagnosisName)) DiagnosisNameOut,
					d.TackleName ResultsName,[dbo].func_PatientOfAddressFull(a.Address,wa.WardName,dis.DistrictName,pro.ProvincialName) PatientAddress,b.Advices AdvicesOut, 0 as Chon,a.PatientReceiveID
					 from PatientReceive a inner join Patients a1 on a.PatientCode=a1.PatientCode inner join MedicalRecord b on a.PatientReceiveID=b.PatientReceiveID
					 --left join Diagnosis b1 on b.DiagnosisCode=b1.RowID 
					 inner join Object b2 on b.ObjectCode=b2.ObjectCode
					 left join Diagnosis c on b.DiagnosisCode=c.RowID
					 left join Tackle d on b.TackleCode=d.TackleCode
					  left join Catalog_District dis on a.DistrictCode=dis.DistrictCode left join Catalog_Provincial pro on
				 a.ProvincialCode=pro.ProvincialCode left join Catalog_Ward wa on a.WardCode=wa.WardCode
					 where CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103)
					 union all
					 select a.PatientCode,a.CreateDate,a1.PatientName,a1.PatientBirthyear,a1.PatientAge,(case when a1.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,
					b.DiagnosisCode,(RTRIM(b1.DiagnosisCode) + ' - ' + RTRIM(b1.DiagnosisName)) DiagnosisNameIn,b2.ObjectName,(RTRIM(c.DiagnosisCode) + ' - ' + RTRIM(c.DiagnosisName)) DiagnosisNameOut,
					d.ResultsName,[dbo].func_PatientOfAddressFull(a.Address,wa.WardName,dis.DistrictName,pro.ProvincialName) PatientAddress,b3.Advices AdvicesOut, 0 as Chon,a.PatientReceiveID
					 from PatientReceive a inner join Patients a1 on a.PatientCode=a1.PatientCode inner join MedicalEmergency b on a.PatientReceiveID=b.PatientReceiveID
					 left join Diagnosis b1 on b.ICD10=b1.DiagnosisCode inner join Object b2 on b.ObjectCode=b2.ObjectCode
					 left join MedicalEmergencyOut b3 on b.MedicalEmergencyCode=b3.MedicalEmergencyCode left join Diagnosis c on b3.ICD10Out=c.DiagnosisCode
					 left join TreatmentResults d on b3.TreatmentResults=d.RowID
					 left join Catalog_District dis on a.DistrictCode=dis.DistrictCode left join Catalog_Provincial pro on
					a.ProvincialCode=pro.ProvincialCode left join Catalog_Ward wa on a.WardCode=wa.WardCode
					 where CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103)
				 end
		end
end
go
--------------------------- Theo doi dau hieu sinh ton
if exists(select name from sysobjects where name like'%pro_View_DauHieuSinhTon%')
	drop procedure pro_View_DauHieuSinhTon
go
create procedure pro_View_DauHieuSinhTon
(
	@frDate date,
	@toDate date,
	@DepartmentCode varchar(50)
)
as
begin
	if @DepartmentCode<>''
		begin
			select a.PatientCode,b2.PatientName,b2.PatientAddress,b2.PatientAge,b2.PatientBirthyear,(case when b2.PatientGender =0 then N'Nữ' else 'Nam' end) PatientGendername,CONVERT(date,a.CreateDate,103) CreateDate
			from SurviveSign a inner join MedicalEmergency b on a.ReferenceCode=b.MedicalEmergencyCode inner join PatientReceive b1 on b.PatientReceiveID=b1.PatientReceiveID
			 inner join Patients b2 on b1.PatientCode=b2.PatientCode
			 where CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103) and b.DepartmentCode=@DepartmentCode
			 group by a.PatientCode,b2.PatientName,b2.PatientAddress,b2.PatientAge,b2.PatientBirthyear,b2.PatientGender,CONVERT(date,a.CreateDate,103)
			 union all
			 select a.PatientCode,b2.PatientName,b2.PatientAddress,b2.PatientAge,b2.PatientBirthyear,(case when b2.PatientGender =0 then N'Nữ' else 'Nam' end) PatientGendername,CONVERT(date,a.CreateDate,103) CreateDate
			 from SurviveSign a inner join MedicalRecord b on a.ReferenceCode=b.MedicalRecordCode inner join PatientReceive b1 on b.PatientReceiveID=b1.PatientReceiveID
			 inner join Patients b2 on b1.PatientCode=b2.PatientCode
			 where CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103) and b.DepartmentCode=@DepartmentCode
			 group by a.PatientCode,b2.PatientName,b2.PatientAddress,b2.PatientAge,b2.PatientBirthyear,b2.PatientGender,CONVERT(date,a.CreateDate,103)
			 order by a.PatientCode,CONVERT(date,a.CreateDate,103)
		end
	else
		begin
			select a.PatientCode,b2.PatientName,b2.PatientAddress,b2.PatientAge,b2.PatientBirthyear,(case when b2.PatientGender =0 then N'Nữ' else 'Nam' end) PatientGendername,CONVERT(date,a.CreateDate,103) CreateDate
			from SurviveSign a inner join MedicalEmergency b on a.ReferenceCode=b.MedicalEmergencyCode inner join PatientReceive b1 on b.PatientReceiveID=b1.PatientReceiveID
			 inner join Patients b2 on b1.PatientCode=b2.PatientCode
			 group by a.PatientCode,b2.PatientName,b2.PatientAddress,b2.PatientAge,b2.PatientBirthyear,b2.PatientGender,CONVERT(date,a.CreateDate,103)
			 union all
			 select a.PatientCode,b2.PatientName,b2.PatientAddress,b2.PatientAge,b2.PatientBirthyear,(case when b2.PatientGender =0 then N'Nữ' else 'Nam' end) PatientGendername,CONVERT(date,a.CreateDate,103) CreateDate
			 from SurviveSign a inner join MedicalRecord b on a.ReferenceCode=b.MedicalRecordCode inner join PatientReceive b1 on b.PatientReceiveID=b1.PatientReceiveID
			 inner join Patients b2 on b1.PatientCode=b2.PatientCode
			 group by a.PatientCode,b2.PatientName,b2.PatientAddress,b2.PatientAge,b2.PatientBirthyear,b2.PatientGender,CONVERT(date,a.CreateDate,103)
			 order by a.PatientCode,CONVERT(date,a.CreateDate,103)
		end
end
go
--------------------------- Theo doi dau hieu sinh ton theo benh nhan
if exists(select name from sysobjects where name like'%pro_View_DauHieuSinhTonForPatient%')
	drop procedure pro_View_DauHieuSinhTonForPatient
go
create procedure pro_View_DauHieuSinhTonForPatient
(
	@date date,
	@PatientCode varchar(50)
)
as
begin
	select a.PatientCode,ISNULL(a.Pulse,0) Pulse,ISNULL(a.Temperature,0)Temperature,ISNULL(a.BloodPressure,0)BloodPressure,ISNULL(a.Weight,0)Weight,isnull(a.BloodPressure1,0)BloodPressure1,ISNULL(a.Hight,0)Hight,ISNULL(a.Breath,0) Breath,
	DATEPART(HOUR,a.CreateDate) HH,DATEPART(MINUTE,a.CreateDate) MI,(case when (DATEPART(HOUR,a.CreateDate)<=12) then 'S' else 'C' end) Time
	from SurviveSign a inner join MedicalEmergency b on a.ReferenceCode=b.MedicalEmergencyCode inner join PatientReceive b1 on b.PatientReceiveID=b1.PatientReceiveID
	where a.PatientCode=@PatientCode and CONVERT(date,a.CreateDate,103)=convert(date,@date,103)
	 order by a.CreateDate
end
go
------------------------- Lay dot dieu tri thu tien
-- exec proPatientReceiveForPayment '15002797'
if exists(select name from sysobjects where name ='proPatientReceiveForPayment' and type='P')
	drop procedure proPatientReceiveForPayment
go
create procedure proPatientReceiveForPayment
(
	@PatientCode varchar(50)
)
as
begin
	declare @TableReceive table(PatientReceiveId numeric(18,0))
	declare @TableResult table(PatientReceiveId numeric(18,0),PatientCode varchar(50),DateIn datetime,DateOut datetime,Status int, StatusName nvarchar(50),ObjectCode int, ObjectName nvarchar(50), PatientType int, DepartmentName nvarchar(100))
	declare @DateIn datetime
	declare @DateOut datetime
	declare @Status int
	declare @StatusName nvarchar(50)
	declare @ObjectCode int
	declare @ObjectName nvarchar(50)
	declare @PatientType int
	declare @DepartmentName nvarchar(100)
	declare @PatientReceiveId numeric(18,0)=0
	declare @Count int =0
	declare @TotalAmount numeric(18,0)=0
	insert @TableReceive(PatientReceiveId)(select PatientReceiveID from PatientReceive where PatientCode=@PatientCode)
	set @Count = (select COUNT(*) sl from @TableReceive)
	WHILE(@Count) > 0 
    BEGIN
        SET @PatientReceiveId=(SELECT TOP 1 PatientReceiveId FROM @TableReceive)
		set @TotalAmount=(select ISNULL(SUM(ServicePrice),0) TotalService from SuggestedServiceReceipt where RefID=@PatientReceiveId and PatientCode=@PatientCode and Paid=0 and (BanksAccountCode is null or BanksAccountCode='') and ObjectCode <>5) 
						+ (select ISNULL(SUM(M.QuantityExport*M.SalesPrice),0) TotalMedicines from MedicinesForPatientsDetail M inner join MedicinesForPatients M1 on M.RowIDMedicines=M1.RowID where M1.PatientReceiveID=@PatientReceiveId and M1.PatientCode=@PatientCode and M.ObjectCode <>5 and M.Paid=0) 
						+ (select ISNULL(SUM(R.Quantity*R.SalesPrice),0) TotalRealMedicine from RealMedicinesForPatientsDetail R inner join RealMedicinesForPatients R1 on R.RealRowID=R1.RowID where R1.PatientReceiveID=@PatientReceiveId and R1.PatientCode=@PatientCode and R.ObjectCode <>5 and R.Paid=0) 
						--+ (select ISNULL(SUM(Rd.QuantityExport*UnitPrice),0) Total from MedicinesRetail R inner join MedicinesRetailDetail Rd on R.RetailCode=Rd.RetailCode where R.Paid=1 and R.PatientReceiveID=@PatientReceiveId and R.PatientCode=@PatientCode and (R.BanksAccountCode='' or R.BanksAccountCode is null))
		if @TotalAmount>0
		begin
			insert into @TableResult(PatientReceiveId,PatientCode,DateIn,DateOut,Status,StatusName,ObjectCode,ObjectName,PatientType,DepartmentName)
			(
			select distinct a.PatientReceiveID,a.PatientCode,a.CreateDate DateIn,(case when (a.OutDate is null) or (a.OutDate ='') then GETDATE() else a.OutDate end) DateOut,
			a.Status,(case when a.Status=2 then N'Kết thúc điều trị' else N'Đang điều trị' end) StatusName,a.ObjectCode,c.ObjectName,a.PatientType,de.DepartmentName
			from PatientReceive a inner join Object c on a.ObjectCode=c.ObjectCode
			inner join SuggestedServiceReceipt S on a.PatientReceiveID=S.RefID and a.PatientCode=S.PatientCode
			inner join Department de on s.DepartmentCode=de.DepartmentCode
			where a.PatientCode=@PatientCode and a.PatientReceiveID=@PatientReceiveId and S.Note='TIEPDON'
			)
		end
        DELETE FROM @TableReceive where PatientReceiveId=@PatientReceiveId
        set @Count=@Count-1
    END
    select * from @TableResult order by DateIn desc
end
go
------------------------- Cho thuc hien xet nghiem
--exec proPatientReceiveForPayment'14000140'
if exists(select name from sysobjects where name ='proWaitingLaboratory' and type='P')
	drop procedure proWaitingLaboratory
go
create procedure proWaitingLaboratory
(
	@DateStart char(10),
	@DateEnd char(10),
	@Status int=0,
	@STT varchar(10),
	@Paid int=0
)
as
set nocount on
begin
	declare @LaboratoryPackageTemp table(ServiceCode varchar(50))
	insert into @LaboratoryPackageTemp(ServiceCode) 
	(
		select a.ServiceCode ServiceCode from LaboratoryPackage a inner join Service b on a.ServiceCode=b.ServiceCode
		union
		select a.ServiceCode from TemplateDescription a inner join Service a1 on a.ServiceCode=a1.ServiceCode inner join ServiceCategory a2 on a1.ServiceCategoryCode=a2.ServiceCategoryCode where a2.ServiceGroupCode='XN'
	)
	if @STT<>'' and @Status>0
	begin
		select a.PatientReceiveID PatientReceiveId,a.PatientCode,a1.PatientName,a1.PatientBirthyear,(case when a1.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,c1.DepartmentName,c.DepartmentName DepartmentNameOrder,a2.DepartmentCodeOrder,a2.OrderDate,a1.PatientAge,o.ObjectName,a.ObjectCode,Convert(date,a2.PostingDate,103) ResultDate
		--,isnull(a2.EmployeeCodeOrder,'') EmployeeCodeOrder,isnull(a2.EmployeeDoctorCodeOrder,'') EmployeeDoctorCodeOrder
			from PatientReceive a inner join Patients a1 on a.PatientCode=a1.PatientCode 
			inner join ServiceLaboratoryEntry a2 on a.PatientReceiveID=a2.PatientReceiveID 
			inner join ServiceCategory b2 on a2.ServiceCategoryCode=b2.ServiceCategoryCode
			left join Department c on a2.DepartmentCodeOrder=c.DepartmentCode inner join Department c1 on a2.DepartmentCode=c1.DepartmentCode inner join [Object] o on a.ObjectCode=o.ObjectCode
			where a2.STT=@STT and CONVERT(date,a2.PostingDate,103) >= CONVERT(date,@DateStart,103) and CONVERT(date,a2.PostingDate,103)<= CONVERT(date,@DateEnd,103)
			group by a.PatientReceiveID,a.PatientCode,a1.PatientName,a1.PatientBirthyear,a1.PatientGender,c.DepartmentName,a2.DepartmentCodeOrder,Convert(date,a2.PostingDate,103),a1.PatientAge,o.ObjectName,a.ObjectCode,a2.OrderDate,Convert(date,a2.PostingDate,103),c1.DepartmentName
			--,a2.EmployeeCodeOrder,a2.EmployeeDoctorCodeOrder
			union
			select a.PatientReceiveID PatientReceiveId,a.PatientCode,a1.PatientName,a1.PatientBirthyear,(case when a1.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,c1.DepartmentName,c.DepartmentName DepartmentNameOrder,b2.DepartmentCodeOrder,convert(char(10),b2.WorkDate,103) as OrderDate,
			a1.PatientAge,o.ObjectName,a.ObjectCode,Convert(date,a2.PostingDate,103) ResultDate
			--,ISNULL(b2.EmployeeCode,'') as EmployeeCodeOrder,isnull(b2.EmployeeCodeDoctor,'') as EmployeeDoctorCodeOrder
			from PatientReceive a inner join Patients a1 on a.PatientCode=a1.PatientCode 
			inner join ServiceRadiologyEntry a2 on a.PatientReceiveID=a2.PatientReceiveID 
			inner join SuggestedServiceReceipt b2 on a2.SuggestedID=b2.ReceiptID inner join [service] b3 on b2.ServiceCode=b3.ServiceCode inner join ServiceCategory b4 on b3.ServiceCategoryCode=b4.ServiceCategoryCode
			left join Department c on b2.DepartmentCodeOrder=c.DepartmentCode inner join Department c1 on b2.DepartmentCode=c1.DepartmentCode
			inner join [Object] o on a.ObjectCode=o.ObjectCode 
			where b4.ServiceGroupCode='XN' and CONVERT(date,a2.PostingDate,103) >= CONVERT(date,@DateStart,103) and CONVERT(date,a2.PostingDate,103) <= CONVERT(date,@DateEnd,103)
			and b2.ReceiptID_DisparityPrice=0
			group by a.PatientReceiveID,a.PatientCode,a1.PatientName,a1.PatientBirthyear,a1.PatientGender,c.DepartmentName,b2.DepartmentCodeOrder,Convert(date,a2.PostingDate,103),a1.PatientAge,o.ObjectName,a.ObjectCode,b2.WorkDate,
			Convert(date,a2.PostingDate,103),c1.DepartmentName
			--,b2.EmployeeCode,b2.EmployeeCodeDoctor
			order by PatientCode
	end
	else if @Status>0
		begin
			select a.PatientReceiveID PatientReceiveId,a.PatientCode,a1.PatientName,a1.PatientBirthyear,(case when a1.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,c1.DepartmentName,c.DepartmentName DepartmentNameOrder,a2.DepartmentCodeOrder,a2.OrderDate,a1.PatientAge,o.ObjectName,a.ObjectCode,Convert(date,a2.PostingDate,103) ResultDate
			--,isnull(a2.EmployeeCodeOrder,'') EmployeeCodeOrder,isnull(a2.EmployeeDoctorCodeOrder,'') EmployeeDoctorCodeOrder
			from PatientReceive a inner join Patients a1 on a.PatientCode=a1.PatientCode 
			inner join ServiceLaboratoryEntry a2 on a.PatientReceiveID=a2.PatientReceiveID 
			inner join ServiceCategory b2 on a2.ServiceCategoryCode=b2.ServiceCategoryCode
			left join Department c on a2.DepartmentCodeOrder=c.DepartmentCode inner join Department c1 on a2.DepartmentCode=c1.DepartmentCode inner join [Object] o on a.ObjectCode=o.ObjectCode
			where b2.ServiceGroupCode='XN' and CONVERT(date,a2.PostingDate,103) >= CONVERT(date,@DateStart,103) and CONVERT(date,a2.PostingDate,103)<= CONVERT(date,@DateEnd,103)
			group by a.PatientReceiveID,a.PatientCode,a1.PatientName,a1.PatientBirthyear,a1.PatientGender,c.DepartmentName,a2.DepartmentCodeOrder,Convert(date,a2.PostingDate,103),a1.PatientAge,o.ObjectName,a.ObjectCode,a2.OrderDate,Convert(date,a2.PostingDate,103),c1.DepartmentName
			--,a2.EmployeeCodeOrder,a2.EmployeeDoctorCodeOrder
			union
			select a.PatientReceiveID PatientReceiveId,a.PatientCode,a1.PatientName,a1.PatientBirthyear,(case when a1.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,c1.DepartmentName,c.DepartmentName DepartmentNameOrder,b2.DepartmentCodeOrder,convert(char(10),b2.WorkDate,103) as OrderDate,a1.PatientAge,o.ObjectName,a.ObjectCode,Convert(date,a2.PostingDate,103) ResultDate
			--,ISNULL(b2.EmployeeCode,'') as EmployeeCodeOrder,isnull(b2.EmployeeCodeDoctor,'') as EmployeeDoctorCodeOrder
			from PatientReceive a inner join Patients a1 on a.PatientCode=a1.PatientCode 
			inner join ServiceRadiologyEntry a2 on a.PatientReceiveID=a2.PatientReceiveID 
			inner join SuggestedServiceReceipt b2 on a2.SuggestedID=b2.ReceiptID inner join [service] b3 on b2.ServiceCode=b3.ServiceCode inner join ServiceCategory b4 on b3.ServiceCategoryCode=b4.ServiceCategoryCode
			left join Department c on b2.DepartmentCodeOrder=c.DepartmentCode inner join Department c1 on b2.DepartmentCode=c1.DepartmentCode
			inner join [Object] o on a.ObjectCode=o.ObjectCode 
			where b4.ServiceGroupCode='XN' and CONVERT(date,a2.PostingDate,103) >= CONVERT(date,@DateStart,103) and CONVERT(date,a2.PostingDate,103) <= CONVERT(date,@DateEnd,103)
			and b2.ReceiptID_DisparityPrice=0
			group by a.PatientReceiveID,a.PatientCode,a1.PatientName,a1.PatientBirthyear,a1.PatientGender,c.DepartmentName,b2.DepartmentCodeOrder,Convert(date,a2.PostingDate,103),a1.PatientAge,o.ObjectName,a.ObjectCode,b2.WorkDate,Convert(date,a2.PostingDate,103),c1.DepartmentName
			--,b2.EmployeeCode,b2.EmployeeCodeDoctor
			order by PatientCode
		end
	else
		if @Paid=0
        begin
			select a.PatientReceiveID PatientReceiveId,a.PatientCode,a1.PatientName,a1.PatientBirthyear,(case when a1.PatientGender=0 then N'Nữ' else N'Nam' end) GenderName,c1.DepartmentName,c.DepartmentName DepartmentNameOrder,b.DepartmentCodeOrder,CONVERT(char(10),b.WorkDate,103) OrderDate,a1.PatientAge
			,o.ObjectName,a.ObjectCode,CONVERT(date,GETDATE(),103) as ResultDate
			--,b4.EmployeeCode as EmployeeCodeOrder,b5.EmployeeCode as EmployeeDoctorCodeOrder
			from PatientReceive a inner join Patients a1 on a.PatientCode=a1.PatientCode inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service b1 on b.ServiceCode=b1.ServiceCode inner join ServiceCategory b2 on b1.ServiceCategoryCode=b2.ServiceCategoryCode 
			inner join @LaboratoryPackageTemp b3 on b.ServiceCode=b3.ServiceCode left join Department c on b.DepartmentCodeOrder=c.DepartmentCode left join Department c1 on b.DepartmentCode=c1.DepartmentCode
			inner join Object o on a.ObjectCode=o.ObjectCode left join Employee b4 on b.EmployeeCode=b4.EmployeeCode left join Employee b5 on b.EmployeeCodeDoctor=b5.EmployeeCode
			where b2.ServiceGroupCode='XN' and b.Status=@Status 
			and CONVERT(date,b.WorkDate,103) >= CONVERT(date,@DateStart,103) and CONVERT(date,b.WorkDate,103) <= CONVERT(date,@DateEnd,103)
			and b.ReceiptID_DisparityPrice=0
			group by a.PatientReceiveID,a.PatientCode,a1.PatientName,a1.PatientBirthyear,a1.PatientGender,c1.DepartmentName,c.DepartmentName,b.DepartmentCodeOrder,CONVERT(char(10),b.WorkDate,103),a1.PatientAge,o.ObjectName,a.ObjectCode
			--,b4.EmployeeCode,b5.EmployeeCode
			order by a.PatientCode
		end
		else
		begin
			select a.PatientReceiveID PatientReceiveId,a.PatientCode,a1.PatientName,a1.PatientBirthyear,(case when a1.PatientGender=0 then N'Nữ' else N'Nam' end) GenderName,c1.DepartmentName,c.DepartmentName DepartmentNameOrder,b.DepartmentCodeOrder,CONVERT(char(10),b.WorkDate,103) OrderDate,a1.PatientAge
			,o.ObjectName,a.ObjectCode,CONVERT(date,GETDATE(),103) as ResultDate
			--,b4.EmployeeCode as EmployeeCodeOrder,b5.EmployeeCode as EmployeeDoctorCodeOrder
			from PatientReceive a inner join Patients a1 on a.PatientCode=a1.PatientCode inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join Service b1 on b.ServiceCode=b1.ServiceCode inner join ServiceCategory b2 on b1.ServiceCategoryCode=b2.ServiceCategoryCode 
			inner join @LaboratoryPackageTemp b3 on b.ServiceCode=b3.ServiceCode left join Department c on b.DepartmentCodeOrder=c.DepartmentCode left join Department c1 on b.DepartmentCode=c1.DepartmentCode
			inner join Object o on a.ObjectCode=o.ObjectCode left join Employee b4 on b.EmployeeCode=b4.EmployeeCode left join Employee b5 on b.EmployeeCodeDoctor=b5.EmployeeCode
			where b2.ServiceGroupCode='XN' and b.Status=@Status 
			and ((b.Paid = case when b.ObjectCode=1 then 0 else @Paid end) or (b.Paid = case when b.ObjectCode=1 then 1 else @Paid end))
			and CONVERT(date,b.WorkDate,103) >= CONVERT(date,@DateStart,103) and CONVERT(date,b.WorkDate,103) <= CONVERT(date,@DateEnd,103)
			and b.ReceiptID_DisparityPrice=0
			group by a.PatientReceiveID,a.PatientCode,a1.PatientName,a1.PatientBirthyear,a1.PatientGender,c1.DepartmentName,c.DepartmentName,b.DepartmentCodeOrder,CONVERT(char(10),b.WorkDate,103),a1.PatientAge,o.ObjectName,a.ObjectCode
			--,b4.EmployeeCode,b5.EmployeeCode
			order by a.PatientCode
		end
end
go
-- exec proWaitingLaboratory '2015-07-15','2015-07-15',1,0
---------------------- Thong tin chi dinh xet nghiem cho benh nhan
if exists(select name from sysobjects where name ='proLaboratoryForPatient')
	drop procedure proLaboratoryForPatient
go
create procedure proLaboratoryForPatient
(
	@PatientReceiveId numeric(18,0),
	@PatientCode varchar(50),
	@Status int,
	@STT varchar(10)='0',
	--@PostingDate char(10)=''
	@StartDate char(10),
	@ToDate char(10),
	@DepartmentCodeOrder varchar(15)
)
as
begin
  if @Status=0
	  begin
		select s.PatientReceiveID,s.PatientCode,s.ServiceCategoryCode,s.ServiceCategoryName,s.ReferenceCode,s.DepartmentCodeOrder,s.DepartmentNameOrder,ISNULL(l.Status,0) Status,ISNULL(l.RowID,0) RowIDLaboratory,l.EmployeeCode, (case when ISNULL(l.Status,0)=0 then N'' when ISNULL(l.Status,0)=2 then N'Đã lấy mẫu' else N'Có kết quả' end) StatusName, l.STT, ISNULL(CONVERT(date,l.PostingDate,103),CONVERT(date,GETDATE(),103)) PostingDate,CONVERT(date,l.PostingDateResult,103) PostingDateResult,ISNULL(s1.LabPathologicalID,1) LabPathologicalID, 0 as Printer,l.EmployeeCodeDoctor,s.EmployeeDoctorCodeOrder
		from
		(
			select a.RefID PatientReceiveID,a.PatientCode,b1.ServiceCategoryCode,b1.ServiceCategoryName,a.ReferenceCode,a.DepartmentCodeOrder,a1.DepartmentName DepartmentNameOrder,a.EmployeeCodeDoctor as EmployeeDoctorCodeOrder
			from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join Department a1 on a.DepartmentCodeOrder=a1.DepartmentCode inner join LaboratoryTypeResult a3 on a.ServiceCode=a3.ServiceCode
			where a.PatientCode=@PatientCode and a.RefID=@PatientReceiveId and b1.ServiceGroupCode='XN' and a.Status=0 and a.DepartmentCodeOrder=@DepartmentCodeOrder
			group by a.RefID,a.PatientCode,b1.ServiceCategoryCode,b1.ServiceCategoryName,a.ReferenceCode,a.DepartmentCodeOrder,a1.DepartmentName,a.EmployeeCodeDoctor
		) s left join ServiceLaboratoryEntry l on s.PatientReceiveID=l.PatientReceiveID and s.ReferenceCode=l.ReferenceCode and s.PatientCode=l.PatientCode and s.ServiceCategoryCode=l.ServiceCategoryCode and l.PatientCode=@PatientCode and l.PatientReceiveID=@PatientReceiveId
		and l.STT=(case when @STT<>'0' then @STT else l.STT end) and l.Status=@Status
		and CONVERT(date,l.PostingDate,103) >= CONVERT(date,@StartDate,103) and CONVERT(date,l.PostingDate,103) <= CONVERT(date,@ToDate,103)
		left join LabPatternAttach s1 on s.ServiceCategoryCode=s1.ServiceCategoryCode
	end
  else
	  begin
		select s.PatientReceiveID,s.PatientCode,s.ServiceCategoryCode,s.ServiceCategoryName,s.ReferenceCode,s.DepartmentCodeOrder,s.DepartmentNameOrder,ISNULL(l.Status,0) Status,ISNULL(l.RowID,0) RowIDLaboratory,l.EmployeeCode, (case when ISNULL(l.Status,0)=0 then '' when ISNULL(l.Status,0)=2 then N'Đã lấy mẫu' else N'Có kết quả' end) StatusName ,l.STT,CONVERT(date,l.PostingDate,103) PostingDate,CONVERT(date,l.PostingDateResult,103) PostingDateResult,ISNULL(s1.LabPathologicalID,1) LabPathologicalID, 0 as Printer,l.EmployeeCodeDoctor,s.EmployeeDoctorCodeOrder
		from
		(
			select a.RefID PatientReceiveID,a.PatientCode,b1.ServiceCategoryCode,b1.ServiceCategoryName,a.ReferenceCode,a.DepartmentCodeOrder,a1.DepartmentName DepartmentNameOrder,a.EmployeeCodeDoctor as EmployeeDoctorCodeOrder
			from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join Department a1 on a.DepartmentCodeOrder=a1.DepartmentCode inner join LaboratoryTypeResult a3 on a.ServiceCode=a3.ServiceCode
			where a.PatientCode=@PatientCode and a.RefID=@PatientReceiveId and b1.ServiceGroupCode='XN' and a.Status in(1,2) and a.DepartmentCodeOrder=@DepartmentCodeOrder
			group by a.RefID,a.PatientCode,b1.ServiceCategoryCode,b1.ServiceCategoryName,a.ReferenceCode,a.DepartmentCodeOrder,a.DepartmentCodeOrder,a1.DepartmentName,a.EmployeeCodeDoctor
		) s inner join ServiceLaboratoryEntry l on s.PatientReceiveID=l.PatientReceiveID and s.ReferenceCode=l.ReferenceCode and s.PatientCode=l.PatientCode and s.ServiceCategoryCode=l.ServiceCategoryCode and l.PatientCode=@PatientCode and l.PatientReceiveID=@PatientReceiveId
		and l.STT=(case when @STT>0 then @STT else l.STT end) and l.Status in(1,2)
		and CONVERT(date,l.PostingDate,103) >= CONVERT(date,@StartDate,103) and CONVERT(date,l.PostingDate,103) <= CONVERT(date,@ToDate,103)
		left join LabPatternAttach s1 on s.ServiceCategoryCode=s1.ServiceCategoryCode
		union
		select s.PatientReceiveID,s.PatientCode,s.ServiceCategoryCode,s.ServiceCategoryName,s.ReferenceCode,s.DepartmentCodeOrder,s.DepartmentNameOrder,1 as Status,0 RowIDLaboratory,l.EmployeeCode,N'Có kết quả' StatusName ,'1' as STT,s.WorkDate as PostingDate,CONVERT(date,l.PostingDate,103) as PostingDateResult,s.LabPathologicalID, 0 as Printer,l.EmployeeCodeDoctor,s.EmployeeDoctorCodeOrder
		from
		(
			select a.ReceiptID,a.RefID PatientReceiveID,a.PatientCode,b1.ServiceCategoryCode,b1.ServiceCategoryName,a.ReferenceCode,a.DepartmentCodeOrder,a1.DepartmentName DepartmentNameOrder,ISNULL(b2.LabPathologicalID,1) LabPathologicalID,CONVERT(date,a.WorkDate,103) WorkDate,a.EmployeeCodeDoctor as EmployeeDoctorCodeOrder
			from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join Department a1 on a.DepartmentCodeOrder=a1.DepartmentCode inner join LaboratoryTypeResult a3 on a.ServiceCode=a3.ServiceCode
			left join LabPatternAttach b2 on b1.ServiceCategoryCode=b2.ServiceCategoryCode
			where a.PatientCode=@PatientCode and a.RefID=@PatientReceiveId and b1.ServiceGroupCode='XN' and a.Status in(1,2) and a.DepartmentCodeOrder=@DepartmentCodeOrder
		) s inner join ServiceRadiologyEntry l on s.PatientReceiveID=l.PatientReceiveID and s.PatientCode=l.PatientCode and l.PatientCode=@PatientCode and l.PatientReceiveID=@PatientReceiveId and l.ServiceGroupCode='XN' 
		and CONVERT(date,l.PostingDate,103) >= CONVERT(date,@StartDate,103) and CONVERT(date,l.PostingDate,103)<=CONVERT(date,@ToDate,103) and s.ReceiptID=l.SuggestedID
		group by s.PatientReceiveID,s.PatientCode,s.ServiceCategoryCode,s.ServiceCategoryName,s.ReferenceCode,s.DepartmentCodeOrder,s.DepartmentNameOrder,l.EmployeeCode,s.WorkDate,CONVERT(date,l.PostingDate,103),s.LabPathologicalID,l.EmployeeCodeDoctor,s.EmployeeDoctorCodeOrder
	  end
end
go
-- exec proLaboratoryForPatient 10267,'16000303',1,0,'15/06/2016','15/06/2016'
--------------------------- Thong ke benh nhan kham benh
if exists(select name from sysobjects where name ='pro_View_ListReportReceive' and type='P')
	drop procedure pro_View_ListReportReceive
go
create procedure pro_View_ListReportReceive
(
	@StartDate char(10),
	@EndDate char(10)
)
as
begin
	select a.PatientReceiveID,a.PatientCode,a2.PatientName,a2.PatientBirthyear,(case when a2.PatientGender =0 then N'Nữ' else N'Nam' end) PatientGender,b.DepartmentName,a1.ReceiptID,(case when a1.Status=1 then N'Đã Khám' else N'Chưa khám' end) StatusName,a1.Status, (case when a1.Paid=1 then N'Đã thu tiền' else N'Chưa thu tiền' end) PaidName,
	 a1.Paid,CONVERT(date,a1.CreateDate,103) WorkDate,c.DepartmentName DepartmentNameOrder,a3.EmployeeName,a4.ObjectName,a5.ServiceName
	 from PatientReceive a inner join SuggestedServiceReceipt a1 on a.PatientReceiveID=a1.RefID inner join Patients a2 on a.PatientCode=a2.PatientCode inner join Department b on a1.DepartmentCode=b.DepartmentCode left join Department c on a1.DepartmentCodeOrder=c.DepartmentCode 
	 inner join Employee a3 on a1.EmployeeCode=a3.EmployeeCode inner join [Object] a4 on a1.ObjectCode=a4.ObjectCode left join [Service] a5 on a1.ServiceCode=a5.ServiceCode
	 where CONVERT(date,a.CreateDate,103) >= CONVERT(date,@StartDate,103) and CONVERT(date,a.CreateDate,103)<=CONVERT(date,@EndDate,103)
	 and a1.ReceiptID_DisparityPrice=0
	 order by a.CreateDate desc
end
go
--------------------------- Danh sach cho thu tien vien phi
if exists(select name from sysobjects where name like'%pro_ListWaitingBank%')
	drop procedure pro_ListWaitingBank
go
create procedure pro_ListWaitingBank
(
	@StartDate datetime,
	@EndDate datetime
)
as
begin
	select 0 as PatientReceiveID,a.PatientCode,b.PatientName,(case when b.PatientGender=0 then N'Nữ' else N'Nam' end) GenderName,
	b.PatientBirthyear,c.ObjectName,convert(date,a.CreateDate,103) CreateDate
	from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode
	inner join Object c on a.ObjectCode=c.ObjectCode inner join (select RefID from SuggestedServiceReceipt where Paid =0 and (BanksAccountCode is null or BanksAccountCode='') and ServicePrice>0 group by RefID) d on a.PatientReceiveID=d.RefID
	where a.Status in(0,1) and CONVERT(date,a.CreateDate,103) between CONVERT(date,@StartDate,103) and  CONVERT(date,@EndDate,103)
	group by a.PatientCode,b.PatientName,b.PatientBirthyear,c.ObjectName,convert(date,a.CreateDate,103),b.PatientGender
	union
	select 0 as PatientReceiveID,a.PatientCode ,d.PatientName,(case when d.PatientGender=0 then N'Nữ' else N'Nam' end) GenderName,d.PatientBirthyear,e.ObjectName,convert(date,a.CreateDate,103) CreateDate
	from PatientReceive a inner join MedicalRecord b on a.PatientCode=b.PatientCode and a.PatientReceiveID=b.PatientReceiveID
	inner join MedicinesForPatients c on b.MedicalRecordCode=c.MedicalRecordCode and b.PatientReceiveID=c.PatientReceiveID and b.PatientCode=c.PatientCode
	inner join Patients d  on a.PatientCode=d.PatientCode inner join Object e on a.ObjectCode=e.ObjectCode
	where CONVERT(date,a.CreateDate,103) between CONVERT(date,@StartDate,103) and  CONVERT(date,@EndDate,103) and b.Paid =0 and (b.BanksAccountCode is null or b.BanksAccountCode='')
	order by CONVERT(date,a.CreateDate,103) desc
end
go
--------------------------- Thong ke benh nhan kham benh
if exists(select name from sysobjects where name ='pro_ReportDailyRevenue')
	drop procedure pro_ReportDailyRevenue
go
create procedure pro_ReportDailyRevenue
(
	@StartDate datetime,
	@EndDate datetime
)
as
begin
	declare @TableResult table(PostingDate date,KCB int, CDHA int, XN int, AmountKCB decimal(18,0), AmountCDHA decimal(18,0), AmountXN decimal(18,0), AmountThuoc decimal(18,0),PTTT int, AmountPTTT decimal(18,0),NHA int, AmountNha decimal(18,0), TC int, AmountTC decimal(18,0),VC int, AmountVC decimal(18,0),GIUONG int, AmountGIUONG decimal(18,0), KHAC int, AmountKHAC decimal(18,0), AmountDisparity decimal(18,0), AmountSalesOff decimal(18,2))
	declare @CreateDate date
	declare @KCB int=0
	declare @CDHA int=0
	declare @XN int=0
	declare @PTTT int=0
	declare @NHA int=0
	declare @TC int=0
	declare @VC int=0
	declare @GIUONG int=0
	declare @KHAC int=0

	declare @AmountKCB decimal(18,0)=0
	declare @AmountCDHA decimal(18,0)=0
	declare @AmountXN decimal(18,0)=0
	declare @AmountPTTT decimal(18,0)=0
	declare @AmountNha decimal(18,0)=0
	declare @AmountForPatients decimal(18,0)=0
	declare @AmountRetail decimal(18,0)=0
	declare @AmountThuoc decimal(18,0)=0
	declare @AmountTC decimal(18,0)=0
	declare @AmountVC decimal(18,0)=0
	declare @AmountGIUONG decimal(18,0)=0
	declare @AmountKHAC decimal(18,2)=0
	declare @AmountDisparity decimal(18,2)=0
	declare @AmountSalesOff decimal(18,2)=0
	declare cur1 cursor read_only fast_forward
	for select distinct convert(date,CreateDate,103) CreateDate from PatientReceive where convert(date,CreateDate,103) between convert(date,@StartDate,103) and convert(date,@EndDate,103) order by convert(date,CreateDate,103) asc
	open cur1
	fetch next from cur1 into @CreateDate
	while @@FETCH_STATUS = 0
	begin
			select @KCB=isnull(COUNT(a.ServiceCode),0),@AmountKCB=isnull(SUM(a.Quantity * a.ServicePrice),0)
			from BanksAccountDetail a inner join BanksAccount a1 on a.BanksAccountCode=a1.BanksAccountCode inner join Service b on a .ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode
			inner join ServiceGroup b2 on b2.ServiceGroupCode=b1.ServiceGroupCode inner join ServiceModule b3 on b3.ServiceModuleCode=b2.ServiceModuleCode
			where b3.ServiceModuleCode ='KCB' and CONVERT(date,a1.PostingDate,103)=CONVERT(date,@CreateDate,103) and a1.Cancel=0 and a1.Report=1

			select @CDHA=isnull(COUNT(a.ServiceCode),0),@AmountCDHA=isnull(SUM(a.Quantity * a.ServicePrice),0)
			from BanksAccountDetail a inner join BanksAccount a1 on a.BanksAccountCode=a1.BanksAccountCode inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode
			inner join ServiceGroup b2 on b2.ServiceGroupCode=b1.ServiceGroupCode inner join ServiceModule b3 on b3.ServiceModuleCode=b2.ServiceModuleCode
			where b3.ServiceModuleCode ='CDHA' and CONVERT(date,a1.PostingDate,103)=CONVERT(date,@CreateDate,103) and a1.Cancel=0 and a1.Report=1
			
			select @XN=isnull(COUNT(a.ServiceCode),0),@AmountXN=isnull(SUM(a.Quantity * a.ServicePrice),0)
			from BanksAccountDetail a inner join BanksAccount a1 on a.BanksAccountCode=a1.BanksAccountCode inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode
			inner join ServiceGroup b2 on b2.ServiceGroupCode=b1.ServiceGroupCode inner join ServiceModule b3 on b3.ServiceModuleCode=b2.ServiceModuleCode
			where b3.ServiceModuleCode ='XN' and CONVERT(date,a1.PostingDate,103)=CONVERT(date,@CreateDate,103) and a1.Cancel=0 and a1.Report=1
			
			select @PTTT=isnull(COUNT(a.ServiceCode),0),@AmountPTTT=isnull(SUM(a.Quantity * a.ServicePrice),0)
			from BanksAccountDetail a inner join BanksAccount a1 on a.BanksAccountCode=a1.BanksAccountCode inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode
			inner join ServiceGroup b2 on b2.ServiceGroupCode=b1.ServiceGroupCode inner join ServiceModule b3 on b3.ServiceModuleCode=b2.ServiceModuleCode
			where b3.ServiceModuleCode ='PTTT' and CONVERT(date,a1.PostingDate,103)=CONVERT(date,@CreateDate,103) and a1.Cancel=0 and a1.Report=1
			
			select @NHA=isnull(COUNT(a.ServiceCode),0),@AmountNha=isnull(SUM(a.Quantity * a.ServicePrice),0)
			from BanksAccountDetail a inner join BanksAccount a1 on a.BanksAccountCode=a1.BanksAccountCode inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode
			inner join ServiceGroup b2 on b2.ServiceGroupCode=b1.ServiceGroupCode inner join ServiceModule b3 on b3.ServiceModuleCode=b2.ServiceModuleCode
			where b3.ServiceModuleCode ='NHAKHOA' and CONVERT(date,a1.PostingDate,103)=CONVERT(date,@CreateDate,103) and a1.Cancel=0 and a1.Report=1
			set @AmountForPatients=(select isnull(SUM(a.Quantity*a.ServicePrice),0) from BanksAccountDetail a inner join BanksAccount a1 on a.BanksAccountCode=a1.BanksAccountCode inner join Items b on a.ServiceCode=b.ItemCode where a1.Cancel=0 and CONVERT(date,a1.PostingDate,103)=CONVERT(date,@CreateDate,103))
			
			select @TC=isnull(COUNT(a.ServiceCode),0),@AmountTC=isnull(SUM(a.Quantity * a.ServicePrice),0)
			from BanksAccountDetail a inner join BanksAccount a1 on a.BanksAccountCode=a1.BanksAccountCode inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode
			inner join ServiceGroup b2 on b2.ServiceGroupCode=b1.ServiceGroupCode inner join ServiceModule b3 on b3.ServiceModuleCode=b2.ServiceModuleCode
			where b3.ServiceModuleCode ='TC' and CONVERT(date,a1.PostingDate,103)=CONVERT(date,@CreateDate,103) and a1.Cancel=0 and a1.Report=1
			
			select @VC=isnull(COUNT(a.ServiceCode),0),@AmountVC=isnull(SUM(a.Quantity * a.ServicePrice),0)
			from BanksAccountDetail a inner join BanksAccount a1 on a.BanksAccountCode=a1.BanksAccountCode inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode
			inner join ServiceGroup b2 on b2.ServiceGroupCode=b1.ServiceGroupCode inner join ServiceModule b3 on b3.ServiceModuleCode=b2.ServiceModuleCode
			where b3.ServiceModuleCode ='VC' and CONVERT(date,a1.PostingDate,103)=CONVERT(date,@CreateDate,103) and a1.Cancel=0 and a1.Report=1
			
			select @GIUONG=isnull(COUNT(a.ServiceCode),0),@AmountGIUONG=isnull(SUM(a.Quantity * a.ServicePrice),0)
			from BanksAccountDetail a inner join BanksAccount a1 on a.BanksAccountCode=a1.BanksAccountCode inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode
			inner join ServiceGroup b2 on b2.ServiceGroupCode=b1.ServiceGroupCode inner join ServiceModule b3 on b3.ServiceModuleCode=b2.ServiceModuleCode
			where b3.ServiceModuleCode ='GIUONG' and CONVERT(date,a1.PostingDate,103)=CONVERT(date,@CreateDate,103) and a1.Cancel=0 and a1.Report=1
			
			select @KHAC=isnull(COUNT(a.ServiceCode),0),@AmountKHAC=isnull(SUM(a.Quantity * a.ServicePrice),0)
			from BanksAccountDetail a inner join BanksAccount a1 on a.BanksAccountCode=a1.BanksAccountCode inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b1.ServiceGroupCode=b2.ServiceGroupCode
			where b2.ServiceModuleCode='KHAC' and CONVERT(date,a1.PostingDate,103)=CONVERT(date,@CreateDate,103) and a1.Cancel=0 and a1.Report=1

			set @AmountDisparity = (select isnull(sum(a.TotalSurcharge),0) AmountDisparity from BanksAccount a where CONVERT(date,a.PostingDate,103)=CONVERT(date,@CreateDate,103) and a.Cancel=0 and a.Report=1)
			set @AmountSalesOff = (select isnull(sum(a.Exemptions),0) AmountSalesOff from BanksAccount a where CONVERT(date,a.PostingDate,103)=CONVERT(date,@CreateDate,103) and a.Cancel=0 and a.Report=1)

			set @AmountForPatients=(select isnull(SUM(a.Quantity*a.ServicePrice),0) from BanksAccountDetail a inner join BanksAccount a1 on a.BanksAccountCode=a1.BanksAccountCode inner join Items b on a.ServiceCode=b.ItemCode where a1.Cancel=0 and CONVERT(date,a1.PostingDate,103)=CONVERT(date,@CreateDate,103))
			select @AmountRetail=ISNULL(SUM(a.TotalAmountReal),0)
			from MedicinesRetail a 
			where a.Paid in(1,2) and a.BanksAccountCode is not null and CONVERT(date,a.ExportDate,103)=CONVERT(date,@CreateDate,103)
			
			set @AmountThuoc=@AmountForPatients+@AmountRetail
			
			insert into @TableResult(PostingDate,KCB,CDHA,XN,AmountKCB,AmountCDHA,AmountXN,AmountThuoc,PTTT,NHA,AmountPTTT,AmountNha,TC,AmountTC,VC,AmountVC,GIUONG,AmountGIUONG,KHAC,AmountKHAC,AmountDisparity,AmountSalesOff) values(@CreateDate,@KCB,@CDHA,@XN,@AmountKCB,@AmountCDHA,@AmountXN,@AmountThuoc,@PTTT,@NHA,@AmountPTTT,@AmountNha,@TC,@AmountTC,@VC,@AmountVC,@GIUONG,@AmountGIUONG,@KHAC,@AmountKHAC,@AmountDisparity,@AmountSalesOff)
		FETCH NEXT FROM cur1 into @CreateDate
	end
	CLOSE cur1
	DEALLOCATE cur1
	select PostingDate,KCB,CDHA,XN,PTTT,NHA,TC,GIUONG,VC,AmountKCB,AmountCDHA,AmountXN,AmountThuoc,AmountPTTT,AmountNha,AmountTC,(AmountKCB+AmountCDHA+AmountXN+AmountThuoc+AmountPTTT+AmountNha+AmountTC+AmountGIUONG+AmountVC+AmountKHAC) AmountTotal,AmountVC,AmountGIUONG,KHAC,AmountKHAC,AmountDisparity,AmountSalesOff from @TableResult
end
go
if exists(select name from sysobjects where name ='pro_ReportDailyRevenueDetail')
	drop procedure pro_ReportDailyRevenueDetail
go
create procedure pro_ReportDailyRevenueDetail
(
	@StartDate datetime,
	@EndDate datetime
)
as
begin
	select a.ServiceCode,a1.ServiceName,a.ServicePrice,ISNULL(COUNT(a.ServiceCode),0) Quantity, ISNULL(sum(a.Quantity * a.ServicePrice),0) AmountTotal, c.ServiceGroupName, a2.ServiceCategoryName,ISNULL(sum(a.DisparityPrice),0) AmountDisparity,ISNULL(sum(a.ServicePriceSalesOff),0) AmountSalesOff
	from BanksAccountDetail a inner join BanksAccount b on a.BanksAccountCode=b.BanksAccountCode inner join Service a1 on a.ServiceCode=a1.ServiceCode inner join ServiceCategory a2 on a1.ServiceCategoryCode=a2.ServiceCategoryCode
	inner join ServiceGroup c on c.ServiceGroupCode=a2.ServiceGroupCode
	where b.Cancel=0 and b.Report=1 and convert(date,b.PostingDate,103) between convert(date,@StartDate,103) and convert(date,@EndDate,103)
	group by a.ServiceCode,a1.ServiceName,a1.ServiceCategoryCode,a2.ServiceCategoryName,a.ServicePrice, c.ServiceGroupName,a2.ServiceCategoryName
	union all
	select c.ItemCode ServiceCode,c.ItemName ServiceName,a.UnitPrice ServicePrice,ISNULL(COUNT(a.ItemCode),0) Quantity, ISNULL(sum(a.Amount),0) AmountTotal, e.GroupName ServiceGroupName, d.ItemCategoryName ServiceCategoryName,0 as AmountDisparity, 0 as AmountSalesOff
	from MedicinesRetailDetail a inner join MedicinesRetail b on a.RetailCode =b.RetailCode inner join Items c on c.ItemCode=a.ItemCode
	inner join ItemCategory d on d.ItemCategoryCode=c.ItemCategoryCode inner join ItemGroup e on e.GroupCode=d.GroupCode
	where b.Paid=1
	and convert(date,b.ExportDate,103) between convert(date,@StartDate,103) and convert(date,@EndDate,103)
	group by c.ItemCode,c.ItemName,a.ItemCode,a.UnitPrice,e.GroupName,d.ItemCategoryName
end
go
if exists(select name from sysobjects where name ='pro_ViewMedicinesPatientEmergency')
	drop procedure pro_ViewMedicinesPatientEmergency
go
create procedure pro_ViewMedicinesPatientEmergency
(
	@StartDate varchar(10)='01/01/1900',
	@EndDate varchar(10)='31/12/2100',
	@PatientCode varchar(50)='',
	@ItemCode varchar(50)=''
)
as
begin
	select a.DateOn,a.TimeOn,a.PatientCode,a1.PatientName,a1.PatientBirthyear,a1.PatientAddress,(case when a1.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,b1.ItemCode,b2.ItemName,isnull(sum(b1.Quantity),0)Quantity,b1.BHYTPrice,b1.SalesPrice,b1.UnitPrice,b3.UnitOfMeasureName,
	a3.DateOut,a3.TimeOut,a.DiagnosisCode,a2.Reason,a1.MedicalHistory
	 from MedicalEmergency a left join RealMedicinesForPatients b on a.MedicalEmergencyCode=b.RefCode
	 left join RealMedicinesForPatientsDetail b1 on b.RowID=b1.RealRowID left join Items b2 on b1.ItemCode=b2.ItemCode
	left join UnitOfMeasure b3 on b2.UnitOfMeasureCode=b3.UnitOfMeasureCode
	inner join Patients a1 on a.PatientCode=a1.PatientCode inner join PatientReceive a2 on a.PatientReceiveID=a2.PatientReceiveID
	left join MedicalEmergencyOut a3 on a.MedicalEmergencyCode=a3.MedicalEmergencyCode
	where convert(date,a.DateOn,103) between convert(date,@StartDate,103) and convert(date,@EndDate,103)
	and a.PatientCode=case @PatientCode when '' then a.PatientCode else @PatientCode end
	and b2.ItemCode=case @ItemCode when '' then b2.ItemCode else @ItemCode end
	group by a.DateOn,a.TimeOn,a.PatientCode,a1.PatientName,a1.PatientBirthyear,a1.PatientAddress,a1.PatientGender,b1.ItemCode,b2.ItemName,b1.BHYTPrice,b1.SalesPrice,b1.UnitPrice,b3.UnitOfMeasureName,
	a3.DateOut,a3.TimeOut,a.DiagnosisCode,a2.Reason,a1.MedicalHistory
	order by a.DateOn asc,a.PatientCode
end
go
--exec pro_ViewMedicinesPatientEmergency '01/07/2014','16/12/2014','',''
------------------Update ngay 27/07/2014
--- kiem tra va add column
--alter table PatientReceive add OutDate datetime NULL
--alter table MedicinesForPatients add RowID decimal(18, 0) IDENTITY(1,1) NOT NULL
--Update lai Khoa chinh cua table MedicinesForPatients la RowID

--alter table MedicinesForPatientsDetail add RowIDMedicines decimal(18, 0) default 0 NOT NULL
--alter table MedicinesForPatientsDetail add RowIDMedicalPrescription numeric(18, 0) default 0 NOT NULL

--alter table PatientAppointment add STT int default 1 not null
-- tat chuc nang tu tang RowID in table PatientAppointment

-- Check lai table MenuList xem RowID co tu tang k, neu co thi bo
--Ngay 30/07/2014
--Add them column New: cho biet duoc nhưng thuoc moi nhap vao
--alter table MedicalPrescriptionDetail add New int default 0 not null

--------------- Update Ngay 08/08/2014
if not exists(select * from sys.columns where Name = N'TotalAmount' and Object_ID = Object_ID(N'MedicinesRetail'))
	alter table MedicinesRetail add TotalAmount decimal(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'TotalAmountReal' and Object_ID = Object_ID(N'MedicinesRetail'))
	alter table MedicinesRetail add TotalAmountReal decimal(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'RateOther' and Object_ID = Object_ID(N'MedicinesRetail'))
	alter table MedicinesRetail add RateOther decimal(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'RateUSD' and Object_ID = Object_ID(N'MedicinesRetail'))
	alter table MedicinesRetail add RateUSD decimal(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'RateSurcharge' and Object_ID = Object_ID(N'MedicinesRetail'))
	alter table MedicinesRetail add RateSurcharge decimal(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'TotalSurcharge' and Object_ID = Object_ID(N'MedicinesRetail'))
	alter table MedicinesRetail add TotalSurcharge decimal(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'IntroCode' and Object_ID = Object_ID(N'MedicinesRetail'))
	alter table MedicinesRetail add IntroCode varchar(10) null
go
if not exists(select * from sys.columns where Name = N'Cash' and Object_ID = Object_ID(N'MedicinesRetail'))
	alter table MedicinesRetail add Cash decimal(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'ExcessCash' and Object_ID = Object_ID(N'MedicinesRetail'))
	alter table MedicinesRetail add ExcessCash decimal(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'VoucherCard' and Object_ID = Object_ID(N'MedicinesRetail'))
	alter table MedicinesRetail add VoucherCard nvarchar(100) default null
go
if not exists(select * from sys.columns where Name = N'OtherCard' and Object_ID = Object_ID(N'MedicinesRetail'))
	alter table MedicinesRetail add OtherCard nvarchar(100) default null
go
if not exists(select * from sys.columns where Name = N'ExcessCashOther' and Object_ID = Object_ID(N'MedicinesRetail'))
	alter table MedicinesRetail add ExcessCashOther decimal(18,4) default 0 not null
go
if not exists(select * from sys.columns where Name = N'STT' and Object_ID = Object_ID(N'MedicinesRetail'))
	alter table MedicinesRetail add STT int default 1 not null
go
if not exists(select * from sys.columns where Name = N'IntroCode' and Object_ID = Object_ID(N'BanksAccount'))
	alter table BanksAccount add IntroCode varchar(10) default null
go
-----------Update ngay 11/08/2014
if not exists(select * from sys.columns where Name = N'EmployeeCode' and Object_ID = Object_ID(N'SurgicalCrew'))
	alter table SurgicalCrew add EmployeeCode varchar(50)
go
if not exists(select * from sys.columns where Name = N'PositionCode' and Object_ID = Object_ID(N'SurgicalCrew'))
	alter table SurgicalCrew add PositionCode int default 0 not null
go
if not exists(select * from sys.columns where Name = N'EmployeeCode' and Object_ID = Object_ID(N'Catalog_SurgicalCrew'))
	alter table Catalog_SurgicalCrew add EmployeeCode varchar(50)
go
if not exists(select * from sys.columns where Name = N'PositionCode' and Object_ID = Object_ID(N'Catalog_SurgicalCrew'))
	alter table Catalog_SurgicalCrew add PositionCode int default 0 not null
go
--insert into ServiceMenu(ServiceMenuID,ServiceMenuName) values(13,N'Nước Tiểu')
--go
--insert into ServiceMenu(ServiceMenuID,ServiceMenuName) values(14,N'Miễn Dịch')
--go
---------- Update ngay 11/09/2014
if not exists(select * from sys.columns where Name = N'AppointmentHour' and Object_ID = Object_ID(N'PatientAppointment'))
	alter table PatientAppointment add AppointmentHour varchar(10)
go
if not exists(select * from sys.columns where Name = N'Done' and Object_ID = Object_ID(N'PatientAppointment'))
	alter table PatientAppointment add [Done] int default 0
go
if not exists(select * from sys.columns where Name = N'StatusID' and Object_ID = Object_ID(N'PatientAppointment'))
	alter table PatientAppointment add [StatusID] int default 0
go
if not exists(select * from sys.columns where Name = N'LableID' and Object_ID = Object_ID(N'PatientAppointment'))
	alter table PatientAppointment add [LableID] int default 0
--------------------------
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Career')
begin
CREATE TABLE Career
(
	CareerCode varchar(10) not null,
	CareerName nvarchar(250)not null,
	CONSTRAINT Career_pk PRIMARY KEY (CareerCode)
)
end
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Introducer')
begin
CREATE TABLE Introducer
(
	RowID decimal(18,0) not null,
	IntroCode varchar(10)not null,
	IntroName nvarchar(250)not null,
	Sex int not null,
	Mobile varchar(50) default null,
	IDCard varchar(100) default null,
	Address nvarchar(250) default null,
	Birthday datetime,
	CareerCode varchar(10) not null,
	EmployeeCode varchar(50) not null,
	Note nvarchar(250) default null,
	CONSTRAINT Introducer_pk PRIMARY KEY (IntroCode),
	CONSTRAINT fk_Introducer_Career FOREIGN KEY (CareerCode)REFERENCES Career(CareerCode),
	CONSTRAINT fk_Introducer_Employee FOREIGN KEY (EmployeeCode)REFERENCES Employee(EmployeeCode)
)
end
go
--insert into Career(CareerCode,CareerName) values('NN00000001',N'Công nhân')
--insert into Career(CareerCode,CareerName) values('NN00000002',N'Kỹ sư')
--insert into Career(CareerCode,CareerName) values('NN00000003',N'Công nhân viên')
--insert into Career(CareerCode,CareerName) values('NN00000004',N'Hành chánh')
--insert into Career(CareerCode,CareerName) values('NN00000005',N'Công an')
--insert into Career(CareerCode,CareerName) values('NN00000006',N'Thợ xây dựng')
--insert into Career(CareerCode,CareerName) values('NN00000007',N'Doanh nhân')
--insert into Career(CareerCode,CareerName) values('NN00000008',N'Nha sĩ')
--insert into Career(CareerCode,CareerName) values('NN00000009',N'Quản gia')
--insert into Career(CareerCode,CareerName) values('NN00000010',N'Bác sĩ')

---------------------------------Update ngay 15/08/2014
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'FoodCategory')
begin
CREATE TABLE FoodCategory
(
	FoodCategoryID int,
	FoodCategoryName nvarchar(250) not null,
	IDate datetime,
	STT int default 1
	CONSTRAINT FoodCategory_pk PRIMARY KEY (FoodCategoryID)
)
end
go
--insert into FoodCategory(FoodCategoryID,FoodCategoryName,IDate,STT) values(1,N'Thức Ăn',GETDATE(),1)
--insert into FoodCategory(FoodCategoryID,FoodCategoryName,IDate,STT) values(2,N'Gia Vị',GETDATE(),2)
--insert into FoodCategory(FoodCategoryID,FoodCategoryName,IDate,STT) values(3,N'Chất Đốt',GETDATE(),3)
-- select * from FoodCategory
-- delete from FoodCategory where FoodCategoryID=4
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'UnitOfRaw')
begin
CREATE TABLE UnitOfRaw
(
	UnitOfRawID int,
	UnitOfRawName nvarchar(250) not null,
	IDate datetime
	CONSTRAINT UnitOfFuel_pk PRIMARY KEY (UnitOfRawID)
)
end
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Catalog_Food')
begin
CREATE TABLE Catalog_Food
(
	Catalog_FoodCode varchar(6),
	FoodCategoryID int,
	Catalog_FoodName nvarchar(500) not null,
	EmployeeCode nvarchar(250) not null,
	UnitOfRawID int,
	IDate datetime
	CONSTRAINT Catalog_Food_pk PRIMARY KEY (Catalog_FoodCode),
	CONSTRAINT fk_Catalog_Food_FoodCategory FOREIGN KEY (FoodCategoryID)REFERENCES FoodCategory(FoodCategoryID),
	CONSTRAINT fk_Catalog_Food_UnitOfFuel FOREIGN KEY (UnitOfRawID)REFERENCES UnitOfRaw(UnitOfRawID)
)
end
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'FoodEntry')
begin
CREATE TABLE FoodEntry
(
	FoodEntryID decimal(18,0),
	Content nvarchar(500) not null,
	EmployeeCode nvarchar(50) not null,
	Amount decimal(18,4) default 0 not null,
	Quantity int default 0,
	Price decimal(18,4) default 0 not null,
	WorkDate datetime,
	IDate datetime
	CONSTRAINT FoodEntry_pk PRIMARY KEY (FoodEntryID)
)
end
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'FoodDetail')
begin
CREATE TABLE FoodDetail
(
	FoodDetailID decimal(18,0),
	FoodEntryID decimal(18,0),
	Catalog_FoodCode varchar(6) not null,
	Price decimal(18,4) default 0,
	Quantity decimal(18,2) default 0,
	Amount decimal(18,4) default 0,
	EmployeeCode varchar(50) not null,
	Note nvarchar(250),
	IDate datetime
	CONSTRAINT FoodDetail_pk PRIMARY KEY (FoodDetailID),
	CONSTRAINT fk_FoodDetail_FoodEntry FOREIGN KEY (FoodEntryID)REFERENCES FoodEntry(FoodEntryID),
	CONSTRAINT fk_FoodDetail_Catalog_Food FOREIGN KEY (Catalog_FoodCode)REFERENCES Catalog_Food(Catalog_FoodCode),
	CONSTRAINT fk_FoodDetail_Employee FOREIGN KEY (EmployeeCode)REFERENCES Employee(EmployeeCode)
)
end
go
-------------------------------------------- update ngay 27/06/2014
if exists(select name from sysobjects where name ='func_PatientOfAddress')
	drop function func_PatientOfAddress
go
CREATE FUNCTION func_PatientOfAddress(@PatientReceiveID numeric(18,0))
RETURNS NVARCHAR(800)
AS
BEGIN
	Declare @Result nvarchar(800)=''
	declare @Address nvarchar(200)=''
	declare @WardName nvarchar(200)=''
	declare @DistrictName nvarchar(200)=''
	declare @ProvincialName nvarchar(200)=''
	select @Address=a.Address,@WardName=b1.WardName,@DistrictName=b2.DistrictName,@ProvincialName=b3.ProvincialName  from PatientReceive a left join Catalog_Ward b1 on a.WardCode=b1.WardCode left join Catalog_District b2 on a.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on a.ProvincialCode=b3.ProvincialCode where a.PatientReceiveID=@PatientReceiveID
	if(@Address<>'')
		set @Result=@Address +', '
	if(@WardName<>'' and @WardName<>lower(N'không xác định'))
		set @Result = @Result + @WardName
	if(@DistrictName<>'' and @DistrictName<>lower(N'không xác định'))
		set @Result = @Result +', ' + @DistrictName
	if(@ProvincialName<>'' and @ProvincialName<>lower(N'không xác định'))
		set @Result = @Result +', ' + @ProvincialName
	RETURN @Result
end
go
if exists(select name from sysobjects where name ='func_PatientOfAddressFull')
	drop function func_PatientOfAddressFull
go
CREATE FUNCTION func_PatientOfAddressFull(@Address nvarchar(200),@WardName nvarchar(200),@DistrictName nvarchar(200),@ProvincialName nvarchar(200))
RETURNS NVARCHAR(800)
AS
BEGIN
	Declare @Result nvarchar(800)=''
	if(@Address<>'')
		set @Result=@Address 
	if(@WardName<>'' and @WardName<>lower(N'không xác định'))
		if(len(@Result)>0)
			set @Result = @Result +', '+ @WardName
		else
			set @Result = @Result + @WardName
	if(@DistrictName<>'' and @DistrictName<>lower(N'không xác định'))
		if(len(@Result)>0)
			set @Result = @Result +', '+ @DistrictName
		else
			set @Result = @Result + @DistrictName
	if(@ProvincialName<>'' and @ProvincialName<>lower(N'không xác định'))
		if(len(@Result)>0)
			set @Result = @Result +', '+ @ProvincialName
		else
			set @Result = @Result + @ProvincialName
	RETURN @Result
end
go
-- Update 09/07/2015
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'LabPatternAttach')
begin
CREATE TABLE LabPatternAttach
(
	LabPatternID int identity(1,1),
	LabPatternTitle nvarchar(250),
	LabPatternContent nvarchar(max) not null,
	EmployeeCode varchar(50) not null,
	ServiceCategoryCode varchar(50),
	WorkDate datetime,
	IDate datetime default getdate() not null
	CONSTRAINT LabPatternAttach_pk PRIMARY KEY (LabPatternID),
	CONSTRAINT fk_LabPattern_Employee FOREIGN KEY (EmployeeCode)REFERENCES Employee(EmployeeCode),
	CONSTRAINT fk_LabPattern_ServiceCategory FOREIGN KEY (ServiceCategoryCode)REFERENCES ServiceCategory(ServiceCategoryCode)
)
end
go
if exists(select name from sysobjects where name like'%proIU_LabPatternAttach%')
	drop procedure proIU_LabPatternAttach
go
create procedure proIU_LabPatternAttach
(
	@LabPatternID int,
	@LabPatternTitle nvarchar(250),
	@LabPatternContent nvarchar(max),
	@EmployeeCode varchar(50),
	@ServiceCategoryCode varchar(50),
	@WorkDate datetime,
	@LabPathologicalID int
)
as
begin
	if exists(select LabPatternID from LabPatternAttach where ServiceCategoryCode=@ServiceCategoryCode)
	begin
		update LabPatternAttach set LabPatternTitle=@LabPatternTitle,LabPatternContent=@LabPatternContent,EmployeeCode=@EmployeeCode,WorkDate=GETDATE(),LabPathologicalID=@LabPathologicalID where LabPatternID=@LabPatternID
	end
	else
	begin
		insert into LabPatternAttach(LabPatternTitle,LabPatternContent,EmployeeCode,ServiceCategoryCode,WorkDate,LabPathologicalID) 
		values(@LabPatternTitle,@LabPatternContent,@EmployeeCode,@ServiceCategoryCode,@WorkDate,@LabPathologicalID)
	end
end
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'LabPathological')
begin
CREATE TABLE LabPathological
(
	LabPathologicalID int,
	LabPathologicalName nvarchar(250),
	IDate datetime default getdate() not null
	CONSTRAINT pk_LabPathological PRIMARY KEY (LabPathologicalID)
)
end
go
IF NOT EXISTS (SELECT LabPathologicalID FROM LabPathological WHERE LabPathologicalID = 1)
	insert into LabPathological(LabPathologicalID,LabPathologicalName) values(1,'')
go
IF NOT EXISTS (SELECT LabPathologicalID FROM LabPathological WHERE LabPathologicalID = 2)
	insert into LabPathological(LabPathologicalID,LabPathologicalName) values(2,N'MÁU')
go
IF NOT EXISTS (SELECT LabPathologicalID FROM LabPathological WHERE LabPathologicalID = 3)
	insert into LabPathological(LabPathologicalID,LabPathologicalName) values(3,N'NƯỚC TIỂU')
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='LabPatternAttach' and b.name like'%LabPathologicalID%')
	alter table LabPatternAttach add LabPathologicalID int default 1 not null
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ImmunizationTimesDetail')
begin
CREATE TABLE ImmunizationTimesDetail
(
	TimesDetailID int identity(1,1),
	ServiceCode varchar(50),
	EmployeeCode varchar(50),
	DayTimes int default 0,
	DoseNoID int,
	IDate datetime default getdate() not null
	CONSTRAINT pk_ImmunizationTimesDetail PRIMARY KEY (TimesDetailID)
)
end
go
if exists(select name from sysobjects where name ='proIU_ImmunizationTimes')
	drop procedure proIU_ImmunizationTimes
go
create procedure proIU_ImmunizationTimes
(
	@TimesDetailID int,
	@ServiceCode varchar(50),
	@EmployeeCode varchar(50),
	@DayTimes int,
	@DoseNoID int,
	@DayTimesCome int,
	@Warning bit,
	@Note nvarchar(500),
	@TimesEntryID int,
	@Status int output
)
as
begin
	if exists(select TimesDetailID from ImmunizationTimesDetail where TimesDetailID=@TimesDetailID)
	begin
		update ImmunizationTimesDetail set ServiceCode=@ServiceCode,EmployeeCode=@EmployeeCode,DayTimes=@DayTimes,IDate=GETDATE(),DoseNoID=@DoseNoID,DayTimesCome=@DayTimesCome,Warning=@Warning,Note=@Note,TimesEntryID=@TimesEntryID where TimesDetailID=@TimesDetailID
		set @Status =1
	end
	else
	begin
		if not exists(select TimesDetailID from ImmunizationTimesDetail where ServiceCode=@ServiceCode and DoseNoID=@DoseNoID)
		begin
			insert into ImmunizationTimesDetail(ServiceCode,EmployeeCode,DayTimes,DoseNoID,DayTimesCome,Warning,Note,TimesEntryID) values(@ServiceCode,@EmployeeCode,@DayTimes,@DoseNoID,@DayTimesCome,@Warning,@Note,@TimesEntryID)
			set @Status = 1
		end
		else
			set @Status =-2
	end
end
go
if exists(select name from sysobjects where name ='proDel_ImmunizationTimes')
	drop procedure proDel_ImmunizationTimes
go
create procedure proDel_ImmunizationTimes
(
	@ServiceCode varchar(50),
	@EmployeeCode varchar(50),
	@DoseNoID int,
	@Status int output
)
as
begin
	if exists(select a.ServiceCode from ImmunizationRecord a inner join ImmunizationRecordDetail b on a.ImmunizationRecordCode=b.ImmunizationRecordCode where a.ServiceCode=@ServiceCode and b.RowIDDoseNo=@DoseNoID)
		set @Status =-2
	else
	begin
		delete from ImmunizationTimesDetail where ServiceCode=@ServiceCode and DoseNoID=@DoseNoID
		if not exists(select ServiceCode from ImmunizationTimesDetail where ServiceCode=@ServiceCode)
			delete from ImmunizationTimesEntry where ServiceCode=@ServiceCode
		set @Status =1
	end
end
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ImmunizationTimesEntry')
begin
CREATE TABLE ImmunizationTimesEntry
(
	TimesEntryID int identity(1,1),
	ServiceCode varchar(50),
	EmployeeCode varchar(50),
	Note nvarchar(max),
	Title nvarchar(250),
	IDate datetime default getdate() not null
	CONSTRAINT pk_ImmunizationTimesEntry PRIMARY KEY (ServiceCode)
)
end
go
if exists(select name from sysobjects where name ='proIU_ImmunizationTimesEntry')
	drop procedure proIU_ImmunizationTimesEntry
go
create procedure proIU_ImmunizationTimesEntry
(
	@ServiceCode varchar(50),
	@EmployeeCode varchar(50),
	@Note nvarchar(500),
	@Title nvarchar(250),
	@TimesEntryID int,
	@TimesEntryIDTemp int output
)
as
begin
	if exists(select ServiceCode from ImmunizationTimesEntry where TimesEntryID=@TimesEntryID)
	begin
		update ImmunizationTimesEntry set EmployeeCode=@EmployeeCode,Note=@Note,Title=@Title,ServiceCode=@ServiceCode where TimesEntryID=@TimesEntryID
		set @TimesEntryIDTemp =@TimesEntryID
	end
	else
	begin
		insert into ImmunizationTimesEntry(ServiceCode,EmployeeCode,Note,Title) values(@ServiceCode,@EmployeeCode,@Note,@Title)
		set @TimesEntryIDTemp =(select TimesEntryID from ImmunizationTimesEntry where ServiceCode=@ServiceCode)
	end
end
go
if exists(select name from sysobjects where name ='proDel_ImmunizationEntry')
	drop procedure proDel_ImmunizationEntry
go
create procedure proDel_ImmunizationEntry
(
	@ServiceCode varchar(50),
	@EmployeeCode varchar(50),
	@Status int output
)
as
begin
	if exists(select a.ServiceCode from ImmunizationRecord a inner join ImmunizationRecordDetail b on a.ImmunizationRecordCode=b.ImmunizationRecordCode where a.ServiceCode=@ServiceCode)
		set @Status =-2
	else
	begin
		delete from ImmunizationTimesEntry where ServiceCode=@ServiceCode
		delete from ImmunizationTimesDetail where ServiceCode=@ServiceCode
		set @Status =1
	end
end
go
if exists(select name from sysobjects where name='proView_ListMedical' and type='P')
	drop procedure proView_ListMedical
go
create procedure proView_ListMedical -- 04/08/2016
(
	@FromDate char(10),
	@ToDate char(10),
	@Type int
)
as
begin
	if(@Type=2)
	begin
		select b.PatientName,(case when b.PatientGender=0 then (case when b.PatientAge = 0 then CONVERT(char(3),b.PatientMonth)+'Th' else CONVERT(char(3),b.PatientAge)+'T' end) else '' end) GenderFeMale,(case when b.PatientGender=1 then (case when b.PatientAge = 0 then CONVERT(char(3),b.PatientMonth)+'Th' else CONVERT(char(3),b.PatientAge)+'T' end) else '' end) GenderMale,a2.CareerName,a3.EThnicName,a.Symptoms,a.DiagnosisCustom,[dbo].func_MedicalPrescriptionDetailForItems(a.MedicalRecordCode) as Treatments,a.DescriptionNode,a4.EmployeeName EmployeeNameDoctor,
		[dbo].func_PatientOfAddressFull(a1.Address,c.WardName,d.DistrictName,e.ProvincialName) PatientAddress, CONVERT(date,a.postingDate,103) PostingDate, dp.DepartmentName,a5.ObjectName
		from MedicalRecord a inner join Patients b on a.PatientCode=b.PatientCode
		inner join PatientReceive a1 on a.PatientReceiveID=a1.PatientReceiveID left join Career a2 on a1.CareerCode=a2.CareerCode left join Catalog_EThnic a3 on a1.EThnicID=a3.EThnicID
		left join Employee a4 on a.EmployeeCodeDoctor=a4.EmployeeCode left join Catalog_Ward c on a1.WardCode=c.WardCode left join Catalog_District d on a1.DistrictCode=d.DistrictCode left join Catalog_Provincial e on a1.ProvincialCode=e.ProvincialCode
		inner join Department dp on a.DepartmentCode=dp.DepartmentCode inner join Object a5 on a1.ObjectCode =a5.ObjectCode
		where CONVERT(date,a.PostingDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
		order by CONVERT(date,a.PostingDate,103)
	end
	else
	begin
		select COUNT(*) Total, CONVERT(date,a1.CreateDate,103) WorkDate,a2.ObjectName,a3.EmployeeName
		from Patients a inner join PatientReceive a1 on a.PatientCode=a1.PatientCode inner join Object a2 on a1.ObjectCode=a2.ObjectCode inner join Employee a3 on a1.EmployeeCode=a3.EmployeeCode
		where CONVERT(date,a1.CreateDate,103) >= CONVERT(date,@FromDate,103) and CONVERT(date,a1.CreateDate,103)<=CONVERT(date,@ToDate,103)
		group by CONVERT(date,a1.CreateDate,103),a2.ObjectName,a3.EmployeeName
		order by CONVERT(date,a1.CreateDate,103)
	end
end
go
if exists(select name from sysobjects where name ='proView_TotalSuggested')
	drop procedure proView_TotalSuggested
go
create procedure proView_TotalSuggested
(
	@FromDate char(10) ,
	@ToDate char(10),
	@ServiceGroupCode varchar(15),
	@Receive int=0
)
as
begin tran
	declare @TableResult table(ServiceCode varchar(50),ServiceName nvarchar(300),Serial int default 0 not null,Workdate date, Paid int, ShiftWork char(2), ServiceGroupCode varchar(50))
	declare @QuantityAM int =0
	declare @QuantityPM int =0
	declare @QuantityEV int=0
	declare @Workdate date
	declare @Count int =0
	declare @ServiceCode varchar(50)
	declare @ServiceName nvarchar(300)
	declare @TableTemp table(ServiceName nvarchar(300), QuantityAM int default 0 not null,QuantityPM int default 0 not null,QuantityEV int default 0 not null,Workdate date)
	begin
	if @Receive=0
		begin
			insert into @TableResult(ServiceCode,ServiceName,Serial,Workdate,Paid,ShiftWork,ServiceGroupCode)(select a.ServiceCode,a.ServiceName,a.Serial,CONVERT(date,b.WorkDate,103) WorkDate,b.Paid,b.ShiftWork,a.ServiceGroupCode from [Service] a inner join SuggestedServiceReceipt b on a.ServiceCode=b.ServiceCode and CONVERT(date,b.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) where a.ServiceGroupCode=@ServiceGroupCode and a.ServiceCode not in('DV000000') and CONVERT(date,b.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103))
			set @Count = (select COUNT(*) sl from @TableResult)
			WHILE(@Count) > 0
				BEGIN
					select top(1) @ServiceCode=ServiceCode,@ServiceName=ServiceName,@Workdate=Workdate from @TableResult order by Serial
					set @QuantityAM = (
					select COUNT(a.ServiceCode) Quantity
					from @TableResult a 
					where a.ServiceGroupCode=@ServiceGroupCode and a.ServiceCode in(@ServiceCode)  and CONVERT(date,a.WorkDate,103) = CONVERT(date,@Workdate,103)
					and a.Paid = 1  and a.ShiftWork='AM')
					set @QuantityPM = (
					select COUNT(a.ServiceCode) Quantity
					from @TableResult a 
					where a.ServiceGroupCode=@ServiceGroupCode and a.ServiceCode in(@ServiceCode)  and CONVERT(date,a.WorkDate,103) = CONVERT(date,@Workdate,103)
					and a.Paid = 1  and a.ShiftWork='PM')
					set @QuantityEV=(
					select COUNT(a.ServiceCode) Quantity
					from @TableResult a 
					where a.ServiceGroupCode=@ServiceGroupCode and a.ServiceCode in(@ServiceCode)  and CONVERT(date,a.WorkDate,103) = CONVERT(date,@Workdate,103)
					and a.Paid = 1  and a.ShiftWork='EV')

					insert into @TableTemp(ServiceName,QuantityAM,QuantityPM,QuantityEV,Workdate) values(@ServiceName,@QuantityAM,@QuantityPM,@QuantityEV,CONVERT(date,@Workdate,103))
					
					DELETE FROM @TableResult where ServiceCode=@ServiceCode and Workdate=@Workdate
					set @Count=@Count-1
				 end
		end
	 else
		 begin
			insert into @TableResult(ServiceCode,ServiceName,Serial,Workdate,Paid,ShiftWork,ServiceGroupCode)(select a.ServiceCode,a.ServiceName,a.Serial,CONVERT(date,b.WorkDate,103) WorkDate,b.Paid,b.ShiftWork,a.ServiceGroupCode from [Service] a inner join SuggestedServiceReceipt b on a.ServiceCode=b.ServiceCode and CONVERT(date,b.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) where a.ServiceGroupCode=@ServiceGroupCode and a.ServiceCode not in('DV000000') and CONVERT(date,b.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103))
			set @Count = (select COUNT(*) sl from @TableResult)
			WHILE(@Count) > 0
				BEGIN
					select top(1) @ServiceCode=ServiceCode,@ServiceName=ServiceName,@Workdate=Workdate from @TableResult order by Serial
					set @QuantityAM = (
					select COUNT(a.ServiceCode) Quantity
					from @TableResult a 
					where a.ServiceGroupCode=@ServiceGroupCode and a.ServiceCode in(@ServiceCode)  and CONVERT(date,a.WorkDate,103) = CONVERT(date,@Workdate,103)
					and a.ShiftWork='AM')
					set @QuantityPM = (
					select COUNT(a.ServiceCode) Quantity
					from @TableResult a 
					where a.ServiceGroupCode=@ServiceGroupCode and a.ServiceCode in(@ServiceCode)  and CONVERT(date,a.WorkDate,103) = CONVERT(date,@Workdate,103)
					and a.ShiftWork='PM')
					set @QuantityEV=(
					select COUNT(a.ServiceCode) Quantity
					from @TableResult a 
					where a.ServiceGroupCode=@ServiceGroupCode and a.ServiceCode in(@ServiceCode)  and CONVERT(date,a.WorkDate,103) = CONVERT(date,@Workdate,103)
					and a.ShiftWork='EV')

					insert into @TableTemp(ServiceName,QuantityAM,QuantityPM,QuantityEV,Workdate) values(@ServiceName,@QuantityAM,@QuantityPM,@QuantityEV,CONVERT(date,@Workdate,103))
					
					DELETE FROM @TableResult where ServiceCode=@ServiceCode and Workdate=@Workdate
					set @Count=@Count-1
				 end
		 end
		select DISTINCT ServiceName,QuantityAM,QuantityPM,QuantityEV,CONVERT(char(10),Workdate,103) Workdate from @TableTemp where QuantityAM > 0 or QuantityEV > 0 or QuantityPM > 0
		order by Workdate
	end
commit tran
go
if exists(select name from sysobjects where name ='proView_TotalSuggestedForDoctor')
	drop procedure proView_TotalSuggestedForDoctor
go
create procedure proView_TotalSuggestedForDoctor
(
	@FromDate date,
	@ToDate date,
	@ServiceCategoryCode varchar(300),
	@EmployeeCodeDoctor varchar(300),
	@ServiceGroupCode varchar(15),
	@Paid int,
	@Done int
)
as
begin
	
	declare @TableGroup table(ServiceGroupCode varchar(15))
	declare @TableCategory table(ServiceCategoryCode varchar(15))
	declare @TableDoctor table(EmployeeCode varchar(15))
	if LEN(@ServiceGroupCode)>0
		insert into @TableGroup(ServiceGroupCode)(select ServiceGroupCode from ServiceGroup where ServiceGroupCode in(select * from dbo.fnSplitString(@ServiceGroupCode,',')))
	else
		insert into @TableGroup(ServiceGroupCode)(select ServiceGroupCode from ServiceGroup)
	if LEN(@ServiceCategoryCode)>0
		insert into @TableCategory(ServiceCategoryCode)(select ServiceCategoryCode from ServiceCategory where ServiceCategoryCode in(select * from dbo.fnSplitString(@ServiceCategoryCode,',')))
	else
		insert into @TableCategory(ServiceCategoryCode)(select ServiceCategoryCode from ServiceCategory where ServiceGroupCode in(select ServiceGroupCode from @TableGroup))
	if LEN(@EmployeeCodeDoctor)>0
		insert into @TableDoctor(EmployeeCode)(select EmployeeCode from Employee where EmployeeCode in(select * from dbo.fnSplitString(@EmployeeCodeDoctor,',')))
	else
		insert into @TableDoctor(EmployeeCode)(select EmployeeCode from Employee)
	if @Done=0
	begin
		select b.ServiceName,b1.ServiceCategoryName,(case a.ShiftWork when 'AM' then N'Ca1' when 'PM' then N'Ca2' else'' end) ShiftWork,a.ServicePrice,a.DisparityPrice,CONVERT(date,a.WorkDate,103) WorkDate,datepart(DW ,a.WorkDate) DW,COUNT(a.ServiceCode) Quantity,(COUNT(a.ServiceCode)*a.ServicePrice) Amount,a1.EmployeeName EmployeeNameDoctor
		from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join Employee a1 on a.EmployeeCodeDoctor=a1.EmployeeCode
		where a.Paid=(case @Paid when 1 then @Paid else a.Paid end) 
		and a.EmployeeCodeDoctor in(select EmployeeCode from @TableDoctor) 
		and b.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory)
		and b.ServiceGroupCode in(select ServiceGroupCode from @TableGroup)
		and CONVERT(date,a.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) 
		group by b.ServiceName,b1.ServiceCategoryName,a.ShiftWork,a.ServicePrice,a.DisparityPrice,CONVERT(date,a.WorkDate,103),datepart(DW ,a.WorkDate),a1.EmployeeName
	end
	else
	begin
		select e.PatientName,(case when e.PatientGender=0 then N'Nữ' else N'Nam' end) PatientGenderName,e.PatientBirthyear,b.ServiceName,b1.ServiceCategoryName,a.ServicePrice,a.DisparityPrice,CONVERT(date,a.WorkDate,103) WorkDate,a2.EmployeeName EmployeeNameDoctor,
		[dbo].func_PatientOfAddressFull(d.Address,d1.WardName,d2.DistrictName,d3.ProvincialName) PatientAddress,f.NoInvoice
		from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode 
		inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b.ServiceGroupCode=b2.ServiceGroupCode
		inner join MedicalRecord a1 on a.ReceiptID=a1.ReceiptID and a1.TypeMedical=0 and a1.EmployeeCodeDoctor in(select EmployeeCode from @TableDoctor) inner join Employee a2 on a1.EmployeeCodeDoctor=a2.EmployeeCode
		inner join PatientReceive d on a.RefID=d.PatientReceiveID left join Catalog_Ward d1 on d.WardCode=d1.WardCode left join Catalog_District d2 on d.DistrictCode=d2.DistrictCode left join Catalog_Provincial d3 on d.ProvincialCode=d3.ProvincialCode
		inner join Patients e on d.PatientCode=e.PatientCode left join BanksAccount f on a.BanksAccountCode=f.BanksAccountCode
		where  a.Paid=(case @Paid when 1 then @Paid else a.Paid end)  and b.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory)
		and CONVERT(date,a.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) 
		union all
		select e.PatientName,(case when e.PatientGender=0 then N'Nữ' else N'Nam' end) PatientGenderName,e.PatientBirthyear,b.ServiceName,b1.ServiceCategoryName,a.ServicePrice,a.DisparityPrice,CONVERT(date,a.WorkDate,103) WorkDate,c1.EmployeeName EmployeeNameDoctor,
		[dbo].func_PatientOfAddressFull(d.Address,d1.WardName,d2.DistrictName,d3.ProvincialName) PatientAddress,f.NoInvoice
		from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode 
		inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b.ServiceGroupCode=b2.ServiceGroupCode
		inner join ServiceRadiologyEntry c on a.ReceiptID=c.SuggestedID and c.EmployeeCodeDoctor in(select EmployeeCode from @TableDoctor) inner join Employee c1 on c.EmployeeCodeDoctor=c1.EmployeeCode
		inner join PatientReceive d on a.RefID=d.PatientReceiveID left join Catalog_Ward d1 on d.WardCode=d1.WardCode left join Catalog_District d2 on d.DistrictCode=d2.DistrictCode left join Catalog_Provincial d3 on d.ProvincialCode=d3.ProvincialCode
		inner join Patients e on d.PatientCode=e.PatientCode left join BanksAccount f on a.BanksAccountCode=f.BanksAccountCode
		where  a.Paid=(case @Paid when 1 then @Paid else a.Paid end)  and b.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory)
		and CONVERT(date,a.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
		union all
		select e.PatientName,(case when e.PatientGender=0 then N'Nữ' else N'Nam' end) PatientGenderName,e.PatientBirthyear,b.ServiceName,b1.ServiceCategoryName,a.ServicePrice,a.DisparityPrice,CONVERT(date,a.WorkDate,103) WorkDate,c2.EmployeeName EmployeeNameDoctor,
		[dbo].func_PatientOfAddressFull(d.Address,d1.WardName,d2.DistrictName,d3.ProvincialName) PatientAddress,f.NoInvoice
		from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode 
		inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b.ServiceGroupCode=b2.ServiceGroupCode
		inner join ServiceLaboratoryEntry c inner join ServiceLaboratoryDetail c1 on c.RowID=c1.RowIDLaboratoryEnTry on a.ReceiptID=c1.SuggestedID and c.EmployeeCode in(select EmployeeCode from @TableDoctor) inner join Employee c2 on c.EmployeeCode=c2.EmployeeCode
		inner join PatientReceive d on a.RefID=d.PatientReceiveID left join Catalog_Ward d1 on d.WardCode=d1.WardCode left join Catalog_District d2 on d.DistrictCode=d2.DistrictCode left join Catalog_Provincial d3 on d.ProvincialCode=d3.ProvincialCode
		inner join Patients e on d.PatientCode=e.PatientCode left join BanksAccount f on a.BanksAccountCode=f.BanksAccountCode
		where  a.Paid=(case @Paid when 1 then @Paid else a.Paid end)  and b.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory)
		and CONVERT(date,a.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
		union all
		select e.PatientName,(case when e.PatientGender=0 then N'Nữ' else N'Nam' end) PatientGenderName,e.PatientBirthyear,b.ServiceName,b1.ServiceCategoryName,a.ServicePrice,a.DisparityPrice,CONVERT(date,a.WorkDate,103) WorkDate,c1.EmployeeName EmployeeNameDoctor,
		[dbo].func_PatientOfAddressFull(d.Address,d1.WardName,d2.DistrictName,d3.ProvincialName) PatientAddress,f.NoInvoice
		from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode 
		inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b.ServiceGroupCode=b2.ServiceGroupCode
		inner join Surgeries c on a.ReceiptID=c.IDSuggested and c.EmployeeCode in(select EmployeeCode from @TableDoctor) inner join Employee c1 on c.EmployeeCode=c1.EmployeeCode
		inner join PatientReceive d on a.RefID=d.PatientReceiveID left join Catalog_Ward d1 on d.WardCode=d1.WardCode left join Catalog_District d2 on d.DistrictCode=d2.DistrictCode left join Catalog_Provincial d3 on d.ProvincialCode=d3.ProvincialCode
		inner join Patients e on d.PatientCode=e.PatientCode left join BanksAccount f on a.BanksAccountCode=f.BanksAccountCode
		where  a.Paid=(case @Paid when 1 then @Paid else a.Paid end)  and b.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory)
		and CONVERT(date,a.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
		order by CONVERT(date,WorkDate,103)
	end
end
--- proView_TotalSuggestedForDoctor '2015-08-01','2015-08-01','','','KCB',0,0
go
if exists(select name from sysobjects where name='fnSplitString')
	drop function fnSplitString
go
CREATE FUNCTION [dbo].[fnSplitString] 
( 
    @StringInput NVARCHAR(MAX), 
    @Delimiter CHAR(1) 
) 
RETURNS @output TABLE(splitdata NVARCHAR(MAX) 
) 
BEGIN 
	DECLARE @start INT, @end INT 
	SELECT @start = 1, @end = CHARINDEX(@delimiter, @StringInput) 
	WHILE @start < LEN(@StringInput) + 1 BEGIN 
		IF @end = 0  
			SET @end = LEN(@StringInput) + 1
		INSERT INTO @output (splitdata)  VALUES(SUBSTRING(@StringInput, @start, @end - @start)) 
		SET @start = @end + 1 
		SET @end = CHARINDEX(@Delimiter, @StringInput, @start)
	END 
    RETURN 
END
go
if exists(select name from sysobjects where name ='fnSplitNumber')
	drop function fnSplitNumber
go
CREATE FUNCTION [dbo].[fnSplitNumber] 
( 
    @StringInput NVARCHAR(MAX), 
    @Delimiter CHAR(1) 
) 
RETURNS @output TABLE(splitdata int) 
BEGIN 
	DECLARE @start INT, @end INT 
	SELECT @start = 1, @end = CHARINDEX(@delimiter, @StringInput) 
	WHILE @start < LEN(@StringInput) + 1 BEGIN 
		IF @end = 0  
			SET @end = LEN(@StringInput) + 1
		INSERT INTO @output (splitdata)  VALUES(CONVERT(int,SUBSTRING(@StringInput, @start, @end - @start)))
		SET @start = @end + 1 
		SET @end = CHARINDEX(@Delimiter, @StringInput, @start)
	END 
    RETURN 
END
go
--- select * from dbo.fnSplitString('134,345',',')
if exists(select name from sysobjects where name like'%func_DiagnosisEnclosedMore%')
	drop function func_DiagnosisEnclosedMore
go
CREATE FUNCTION func_DiagnosisEnclosedMore(@icd10 nVarChar(500))
RETURNS NVARCHAR(2000)
AS
BEGIN
	Declare @strResult nvarchar(2000)
	set @strResult=''
	Declare @Tempt nvarchar(1000)
	Declare @DiagnosisCode varchar(50)
	Declare @DiagnosisName nvarchar(500)
	declare cur1 cursor read_only fast_forward
	for select DiagnosisCode,DiagnosisName from Diagnosis where RowID in(select * from [dbo].fnSplitNumber(@icd10,','))
	open cur1
	fetch next from cur1 into @DiagnosisCode,@DiagnosisName
	while @@FETCH_STATUS = 0
	begin
		--set @Tempt = LTRIM(RTRIM(@DiagnosisName))+ '('+ LTRIM(RTRIM(@DiagnosisCode)) +');'
		--set @strResult=@strResult + @Tempt
		set @Tempt = LTRIM(RTRIM(@DiagnosisCode)) +';'
		set @strResult=@strResult + @Tempt
		FETCH NEXT FROM cur1 into @DiagnosisCode,@DiagnosisName
	end
	CLOSE cur1
	DEALLOCATE cur1
	RETURN @strResult
end
go
if exists(select name from sysobjects where name ='pro_ReportDailyInvoice')
	drop procedure pro_ReportDailyInvoice
go
create procedure pro_ReportDailyInvoice
(
	@StartDate datetime,
	@EndDate datetime,
	@Cancel int=0
)
as
begin
	select ROW_NUMBER() OVER(ORDER BY a.BanksAccountCode DESC) AS RowNumber, b.PatientCode,b.PatientName,(case when b.PatientGender=1 then N'Nam' else N'Nữ' end)PatientGenderName,b.PatientBirthyear,a3.ObjectName,CONVERT(date,a.PostingDate,103) PostingDate,a.NoInvoice,(case when a.ShiftWork='AM' then N'Ca 1' when a.ShiftWork='PM' then N'Ca 2' when a.ShiftWork='EV' then N'Ca 3' else '' end) ShiftWork,a1.EmployeeName,a2.EmployeeName CashierName,a.TotalReal,[dbo].func_PatientOfAddressFull(c.Address,c1.WardName,c2.DistrictName,c3.ProvincialName) PatientAddress,a4.EmployeeName EmployeeNameCancel,a.CancelDate,a.BanksAccountCode,a.ReferenceCode
	,a.ObjectCode,a.ReasonCancel, a.TotalAmount, a.Exemptions,a.TotalBHYTPay,a.BHYTPay,a.TotalSurcharge,a.PatientPay,convert(char(5),a.PostingDate,108) PostingTime
	from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode left join Employee a1 on a.EmployeeCode=a1.EmployeeCode left join Employee a2 on a.CashierCode=a2.EmployeeCode
	inner join Object a3 on a.ObjectCode=a3.ObjectCode inner join PatientReceive c on a.ReferenceCode=c.PatientReceiveID left join Employee a4 on a.EmployeeCodeCancel=a4.EmployeeCode
	left join Catalog_Ward c1 on c.WardCode=c1.WardCode left join Catalog_District c2 on c.DistrictCode=c2.DistrictCode left join Catalog_Provincial c3 on c.ProvincialCode=c3.ProvincialCode
	where convert(date,a.PostingDate,103) between convert(date,@StartDate,103) and convert(date,@EndDate,103) and a.Cancel=@Cancel
	order by a.PostingDate,a.NoInvoice
end
go
if exists(select name from sysobjects where name ='proView_InputWarehousing')
	drop procedure proView_InputWarehousing
go
create procedure proView_InputWarehousing
(
	@FromDate datetime,
	@ToDate datetime,
	@RepositoryCode varchar(50),
	@Export int=0
)
as
begin
	declare @TableRepository table (RepositoryCode varchar(10))
	if LEN(@RepositoryCode)>0
		insert into @TableRepository(RepositoryCode)(select RepositoryCode from RepositoryCatalog where RepositoryCode in(select * from dbo.fnSplitString(@RepositoryCode,',')))
	else
		insert into @TableRepository(RepositoryCode)(select RepositoryCode from RepositoryCatalog)
	if @Export=0
	begin
		select a.InvoiceNnumber,a.InvoiceDate,a.ImportDate,b.ItemCode,b1.ItemName,b2.ItemCategoryName,b3.GroupName,b4.UnitOfMeasureName,b.Quantity,b.UnitPrice,b.Amount,b.Shipment,b.DateEnd,c.VendorName,d.RepositoryName,N'Nhập kho' Note
		from Warehousing a inner join WarehousingDetail b on a.WarehousingCode=b.WarehousingCode inner join Items b1 on b.ItemCode=b1.ItemCode
		inner join ItemCategory b2 on b1.ItemCategoryCode=b2.ItemCategoryCode inner join ItemGroup b3 on b2.GroupCode=b3.GroupCode
		inner join UnitOfMeasure b4 on b1.UnitOfMeasureCode=b4.UnitOfMeasureCode inner join Vendor c on a.VendorCode=c.VendorCode
		inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode
		where convert(date,a.ImportDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103) and a.RepositoryCode in(select RepositoryCode from @TableRepository)
		union all
		select b.InvoiceNnumber,b.InvoiceDate,convert(date,a.ExportDate,103) ImportDate,a1.ItemCode,a2.ItemName,a3.ItemCategoryName,a4.GroupName,
		c.UnitOfMeasureName,a1.AmountRealExport Quantity,a1.UnitPrice,(a1.AmountRealExport*a1.UnitPrice) Amount,a1.Shipment,a1.DateEnd,d.VendorName,f.RepositoryName,(case when a.Type=1 then N'Chuyển kho' when a.Type=2 then N'Hoàn trả kho' else '' end) Note
		 from ExportWarehousing a inner join ExportWarehousingDetail a1 on a.ExpWarehousingCode=a1.ExpWarehousingCode
		inner join Warehousing b on a1.WarehousingCode=b.WarehousingCode inner join Items a2 on a1.ItemCode=a2.ItemCode inner join ItemCategory a3 on a2.ItemCategoryCode=a3.ItemCategoryCode inner join ItemGroup a4 on a3.GroupCode=a4.GroupCode
		inner join UnitOfMeasure c on a2.UnitOfMeasureCode=c.UnitOfMeasureCode inner join Vendor d on b.VendorCode=d.VendorCode
		inner join RepositoryCatalog f on a.ImpRepositoryCode=f.RepositoryCode
		where convert(date,a.ExportDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103) and a.ImpRepositoryCode in(select RepositoryCode from @TableRepository)
		order by ImportDate
	end
	else
	begin
		select b.InvoiceNnumber,b.InvoiceDate,convert(date,a.ExportDate,103) ImportDate,a1.ItemCode,a2.ItemName,a3.ItemCategoryName,a4.GroupName,
		c.UnitOfMeasureName,a1.AmountRealExport Quantity,a1.UnitPrice,(a1.AmountRealExport*a1.UnitPrice) Amount,a1.Shipment,a1.DateEnd,d.VendorName,f.RepositoryName,(case when a.Type=1 then N'Chuyển kho' when a.Type=2 then N'Hoàn trả kho' else '' end) Note
		 from ExportWarehousing a inner join ExportWarehousingDetail a1 on a.ExpWarehousingCode=a1.ExpWarehousingCode
		inner join Warehousing b on a1.WarehousingCode=b.WarehousingCode inner join Items a2 on a1.ItemCode=a2.ItemCode inner join ItemCategory a3 on a2.ItemCategoryCode=a3.ItemCategoryCode inner join ItemGroup a4 on a3.GroupCode=a4.GroupCode
		inner join UnitOfMeasure c on a2.UnitOfMeasureCode=c.UnitOfMeasureCode inner join Vendor d on b.VendorCode=d.VendorCode
		inner join RepositoryCatalog f on a.ImpRepositoryCode=f.RepositoryCode
		where convert(date,a.ExportDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103) and a.ExpRepositoryCode in(select RepositoryCode from @TableRepository)
		union all
		select b1.InvoiceNnumber,b1.InvoiceDate,convert(date,a.ExportDate,103) ImportDate,a1.ItemCode,a2.ItemName,a3.ItemCategoryName,a4.GroupName,
		c.UnitOfMeasureName,a1.AmountRealExport Quantity,a1.UnitPrice,(a1.AmountRealExport*a1.UnitPrice) Amount,a1.Shipment,a1.DateEnd,d.VendorName,f.RepositoryName,N'Hoàn trả NCC' Note
		 from ExportVendor a inner join ExportVendorDetail a1 on a.ExportVendorCode=a1.ExportVendorCode
		inner join InventoryGumshoe b on a1.RowIDGumshoe=b.RowID inner join Items a2 on a1.ItemCode=a2.ItemCode inner join ItemCategory a3 on a2.ItemCategoryCode=a3.ItemCategoryCode inner join ItemGroup a4 on a3.GroupCode=a4.GroupCode
		inner join Warehousing b1 on b.WarehousingCode=b1.WarehousingCode
		inner join UnitOfMeasure c on a2.UnitOfMeasureCode=c.UnitOfMeasureCode inner join Vendor d on b1.VendorCode=d.VendorCode
		inner join RepositoryCatalog f on a.ExpRepositoryCode=f.RepositoryCode
		where convert(date,a.ExportDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103) and a.ExpRepositoryCode in(select RepositoryCode from @TableRepository)
		order by ImportDate
	end
end
go
--- exec proView_StatisticBankTotal '2015-08-01','2015-08-10','','NV00006','',''
if exists(select name from sysobjects where name ='proView_StatisticBankTotal')
	drop procedure proView_StatisticBankTotal
go
create procedure proView_StatisticBankTotal
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

	 select a.PatientCode,a.ReferenceCode,CONVERT(date,a.PostingDate,103) PostingDate,SUM(a1.Quantity * a1.ServicePrice) Amount,b.PatientName,
		b.PatientBirthyear,b.PatientBirthday,b.PatientAddress, (case when b.PatientGender=0 then N'Nữ' else 'Nam' end ) PatientGenderName,a5.ServiceModuleName GroupName,a5.ServiceModuleCode
		from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode inner join BanksAccountDetail a1 on a.BanksAccountCode=a1.BanksAccountCode
		inner join Service a2 on a1.ServiceCode=a2.ServiceCode inner join ServiceCategory a3 on a2.ServiceCategoryCode=a3.ServiceCategoryCode
		inner join ServiceGroup a4 on a3.ServiceGroupCode=a4.ServiceGroupCode inner join ServiceModule a5 on a4.ServiceModuleCode=a5.ServiceModuleCode inner join PatientReceive a6 on a.ReferenceCode=a6.PatientReceiveID
		where a.Cancel=0 and convert(date,a.PostingDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103)  
		and a2.ServiceCode in (select ServiceCode from @TableLimitServices)
		and a2.ServiceCategoryCode in(select * from @TableCategory) and a3.ServiceGroupCode in(select * from @TableGroup)
		group by a.PatientCode,a.ReferenceCode,a.PostingDate,b.PatientName,b.PatientBirthyear,b.PatientBirthday,b.PatientAddress,b.PatientGender,a5.ServiceModuleName,a5.ServiceModuleCode
	union all
	select a.PatientCode,a.ReferenceCode,CONVERT(date,a.PostingDate,103) PostingDate,SUM(a1.Quantity * a1.ServicePrice) Amount,b.PatientName,
		b.PatientBirthyear,b.PatientBirthday,b.PatientAddress, (case when b.PatientGender=0 then N'Nữ' else 'Nam' end ) PatientGenderName,a5.ServiceModuleName GroupName,a5.ServiceModuleCode
		from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode inner join BanksAccountDetail a1 on a.BanksAccountCode=a1.BanksAccountCode
		inner join Items a2 on a1.ServiceCode=a2.ItemCode inner join ItemCategory a3 on a2.ItemCategoryCode=a3.ItemCategoryCode
		inner join ItemGroup a4 on a3.GroupCode=a4.GroupCode inner join ServiceModule a5 on a4.ServiceModuleCode=a5.ServiceModuleCode inner join PatientReceive a6 on a.ReferenceCode=a6.PatientReceiveID
		where a.Cancel=0 and convert(date,a.PostingDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103)  
		--and a2.ServiceCode in (select ServiceCode from @TableLimitServices)
		--and a2.ServiceCategoryCode in(select * from @TableCategory) and a3.ServiceGroupCode in(select * from @TableGroup)
		group by a.PatientCode,a.ReferenceCode,a.PostingDate,b.PatientName,b.PatientBirthyear,b.PatientBirthday,b.PatientAddress,b.PatientGender,a5.ServiceModuleName,a5.ServiceModuleCode
	union all
	select a.RetailCode, a.PatientReceiveID ReferenceCode,CONVERT(date,a.ExportDate,103) PostingDate,SUM(a1.Quantity * a1.UnitPrice) Amount,a.FullName,
		a.Birthyear,a.PatientBirthday,a.Address, (case when a.PatientGender=0 then N'Nữ' else 'Nam' end ) PatientGenderName,a5.ServiceModuleName GroupName,a5.ServiceModuleCode
		from MedicinesRetail a  inner join MedicinesRetailDetail a1 on a.RetailCode=a1.RetailCode
		inner join Items a2 on a1.ItemCode=a2.ItemCode inner join ItemCategory a3 on a2.ItemCategoryCode=a3.ItemCategoryCode
		inner join ItemGroup a4 on a3.GroupCode=a4.GroupCode inner join ServiceModule a5 on a4.ServiceModuleCode=a5.ServiceModuleCode 
		where a.Paid=1 and convert(date,a.ExportDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103)
		group by a.PatientCode,a.RetailCode,a.ExportDate,a.FullName,a.Birthyear,a.PatientBirthday,a.PatientGender,a5.ServiceModuleName,a5.ServiceModuleCode,a.PatientReceiveID,a.Address 
end
go
if exists(select name from sysobjects where name ='proView_StatisticBankDetail')
	drop procedure proView_StatisticBankDetail
go
create procedure proView_StatisticBankDetail
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
		
	select a.BanksAccountCode,CONVERT(date,a.PostingDate,103) PostingDate,SUM(a1.Quantity * a1.ServicePrice) Amount,upper(b.PatientName) PatientName,
		b.PatientBirthyear,CONVERT(date,b.PatientBirthday,103) PatientBirthday,b.PatientAddress, (case when b.PatientGender=0 then N'Nữ' else 'Nam' end ) PatientGenderName,a5.ServiceModuleName GroupName,a3.ServiceCategoryName CategoryName,
		a2.ServiceName,a6.UnitOfMeasureName,isnull(SUM(a1.Quantity),0) Quantity,a1.ServicePrice UnitPrice,a.PatientCode
		from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode inner join BanksAccountDetail a1 on a.BanksAccountCode=a1.BanksAccountCode
		inner join Service a2 on a1.ServiceCode=a2.ServiceCode inner join ServiceCategory a3 on a2.ServiceCategoryCode=a3.ServiceCategoryCode
		inner join ServiceGroup a4 on a3.ServiceGroupCode=a4.ServiceGroupCode inner join ServiceModule a5 on a4.ServiceModuleCode=a5.ServiceModuleCode inner join UnitOfMeasure a6 on a2.UnitOfMeasureCode=a6.UnitOfMeasureCode
		inner join PatientReceive a7 on a.ReferenceCode=a7.PatientReceiveID
		where a.Cancel=0 and a.Report in(1)  
		and a2.ServiceCategoryCode in(select * from @TableCategory) and a3.ServiceGroupCode in(select * from @TableGroup) and
		convert(date,a.PostingDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103) and a2.ServiceCode in (select ServiceCode from @TableLimitServices)
		group by a.PatientCode,a.BanksAccountCode,a.PostingDate,b.PatientName,b.PatientBirthyear,b.PatientBirthday,b.PatientAddress,b.PatientGender,a5.ServiceModuleName,a3.ServiceCategoryName,a2.ServiceName,a6.UnitOfMeasureName,a1.ServicePrice
	union all
	select a.BanksAccountCode,CONVERT(date,a.PostingDate,103) PostingDate,SUM(a1.Quantity * a1.ServicePrice) Amount,upper(b.PatientName) PatientName,
		b.PatientBirthyear,CONVERT(date,b.PatientBirthday,103) PatientBirthday,b.PatientAddress, (case when b.PatientGender=0 then N'Nữ' else 'Nam' end ) PatientGenderName,a5.ServiceModuleName GroupName,a3.ItemCategoryName CategoryName,
		a2.ItemName ServiceName,a6.UnitOfMeasureName,isnull(SUM(a1.Quantity),0) Quantity,a1.ServicePrice UnitPrice,a.PatientCode
		from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode inner join BanksAccountDetail a1 on a.BanksAccountCode=a1.BanksAccountCode
		inner join Items a2 on a1.ServiceCode=a2.ItemCode inner join ItemCategory a3 on a2.ItemCategoryCode=a3.ItemCategoryCode
		inner join ItemGroup a4 on a3.GroupCode=a4.GroupCode inner join ServiceModule a5 on a4.ServiceModuleCode=a5.ServiceModuleCode inner join UnitOfMeasure a6 on a2.UnitOfMeasureCode=a6.UnitOfMeasureCode
		inner join PatientReceive a7 on a.ReferenceCode=a7.PatientReceiveID
		where a.Cancel=0 
		--and a2.ServiceCategoryCode in(select * from @TableCategory) and a3.ServiceGroupCode in(select * from @TableGroup) and
		 and convert(date,a.PostingDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103)
		and a4.ServiceModuleCode in(select  ServiceGroupCode from @TableGroup)
		group by a.PatientCode,a.BanksAccountCode,a.PostingDate,b.PatientName,b.PatientBirthyear,b.PatientBirthday,b.PatientAddress,b.PatientGender,a5.ServiceModuleName,a3.ItemCategoryName,a2.ItemName,a6.UnitOfMeasureName,a1.ServicePrice
	union all
	select a.MedicalRecordCode BanksAccountCode,CONVERT(date,a.ExportDate,103) PostingDate,SUM(a1.Quantity * a1.UnitPrice) Amount,upper(a.FullName) PatientName,
		a.Birthyear PatientBirthyear,CONVERT(date,a.PatientBirthday,103) PatientBirthday,a.Address PatientAddress, (case when a.PatientGender=0 then N'Nữ' else 'Nam' end ) PatientGenderName,a5.ServiceModuleName GroupName,a4.GroupName CategoryName,a2.ItemName ServiceName,a6.UnitOfMeasureName,isnull(SUM(a1.Quantity),0) Quantity,a1.UnitPrice,(case when len(a.PatientCode) <= 0 then a.RetailCode else a.PatientCode end ) PatientCode
		from MedicinesRetail a inner join MedicinesRetailDetail a1 on a.RetailCode=a1.RetailCode
		inner join Items a2 on a1.ItemCode=a2.ItemCode inner join ItemCategory a3 on a2.ItemCategoryCode=a3.ItemCategoryCode 
		inner join ItemGroup a4 on a3.GroupCode=a4.GroupCode inner join ServiceModule a5 on a4.ServiceModuleCode=a5.ServiceModuleCode inner join UnitOfMeasure a6 on a2.UnitOfMeasureCode=a6.UnitOfMeasureCode
		where a.Paid=1 and convert(date,a.ExportDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103) 
		and a4.ServiceModuleCode in(select  ServiceGroupCode from @TableGroup)
		group by a.BanksAccountCode,a.ExportDate,a.FullName,a.Birthyear,a.PatientBirthday,a.Address,a.PatientGender,a5.ServiceModuleName,a4.GroupName,a2.ItemName,a6.UnitOfMeasureName,a.RetailCode,a.MedicalRecordCode,a.PatientCode ,a1.UnitPrice
		order by CONVERT(date,a.PostingDate,103),PatientName,GroupName
end
go
if exists(select name from sysobjects where name ='prIns_Catalog_Provincial')
	drop procedure prIns_Catalog_Provincial
go
create procedure prIns_Catalog_Provincial
(
	@ProvincialCode varchar(3),
	@STT int,
	@ProvincialName nvarchar(500),
	@EmployeeCode nvarchar(50),
	@RegionID int,
	@ProvincialIDBHYT varchar(3),
	@iresult int output
)
as
begin
	if not exists(select ProvincialCode from Catalog_Provincial where ProvincialCode=@ProvincialCode)
		begin
			declare @_Code varchar(3)
			declare @_stt int
			set @_stt = (select ISNULL( MAX( CONVERT(int,ProvincialCode)),0) maxcode from Catalog_Provincial)+1
			if(@_stt<=9)
				begin
					set @_Code = '00'+convert(varchar(3),@_stt)
				end
			else if(@_stt>9 and @_stt<=99)
				begin
					set @_Code = '0'+convert(varchar(3),@_stt)
				end
			else if(@_stt>99 and @_stt<=999)
				begin
					set @_Code = convert(varchar(3),@_stt)
				end
			else
				begin
					set @_Code = '001'
				end
			insert into Catalog_Provincial(ProvincialCode,STT,ProvincialName,EmployeeCode,IDate,RegionID,ProvincialIDBHYT) 
			values(@_Code,@STT,@ProvincialName,@EmployeeCode,getdate(),@RegionID,@ProvincialIDBHYT) 
			set @iresult =1
		end
	else
		begin
			update Catalog_Provincial set STT=@STT,ProvincialName=@ProvincialName,EmployeeCode=@EmployeeCode,IDate=GETDATE(),RegionID=@RegionID,ProvincialIDBHYT=@ProvincialIDBHYT where ProvincialCode=@ProvincialCode
			set @iresult =2
		end
end
go
if exists(select name from sysobjects where name ='proView_HandPoint' and type='P')
	drop procedure proView_HandPoint
go
create procedure proView_HandPoint
(
	@PatientReceiveID decimal,
	@PatientCode varchar(50),
	@ReferenceCode varchar(50)='',
	@ReceiptID varchar(250),
	@ServiceGroupCode varchar(50)='',
	@WorkDate date,
	@PatientType int
)
as
begin
	declare @TableReceiptID table(ReceiptID decimal)
	declare @TableServiceGroup table(ServiceGroupCode varchar(50))
	if LEN(@ReceiptID)>0
		insert into @TableReceiptID(ReceiptID)(select ReceiptID from SuggestedServiceReceipt where ReceiptID in(select * from dbo.fnSplitNumber(@ReceiptID,',')))
	else
		insert into @TableReceiptID(ReceiptID)(select ReceiptID from SuggestedServiceReceipt where PatientCode=@PatientCode and RefID=@PatientReceiveID)
	if LEN(@ServiceGroupCode)>0
		insert into @TableServiceGroup(ServiceGroupCode)(select ServiceGroupCode from ServiceGroup where ServiceModuleCode in(select * from dbo.fnSplitString(@ServiceGroupCode,',')))
	else
		insert into @TableServiceGroup(ServiceGroupCode)(select ServiceGroupCode from ServiceGroup)
	if(@PatientType=1)
	begin
		select a.ReceiptID,a.DepartmentCode,a.ServiceCode,a.ServicePrice,a.DisparityPrice,a.Status,a.Paid,a.PatientCode,a.ObjectCode,a.WorkDate,b.PatientName,[dbo].func_PatientOfAddress(@PatientReceiveID) PatientAddress,b.PatientAge,c.ObjectName,g.ServiceName,
		e.TraiTuyen,CONVERT(char(10),e.StartDate,103) StartDate,CONVERT(char(10),e.EndDate,103) EndDate,e.Serial,(f.ProvincialIDBHYT+'-'+e.KCBBDCode) KCBBDCode,f.KCBBDName,(case when PatientGender=0 then N'Nữ' else N'Nam' end) PatientGenderName,b.PatientBirthyear,j.Symptoms,i.EmployeeName,j1.DepartmentName,a1.Reason,j2.DepartmentName DepartmentNameOrder,a1.IntroName,a2.UnitOfMeasureName,a.Quantity,a3.EmployeeName EmployeeNameDoctor,j.DiagnosisCustom,UPPER(g1.ServiceCategoryName) ServiceCategoryName
		--,('('+j3.DiagnosisCode+')'+j3.DiagnosisName) DiagnosisName
		,('('+j.ICD10_Custom+')'+j.ICD10Name_Custom) DiagnosisName
		,(case when a.ObjectCode=1 then ( case when e.TraiTuyen=1 and e.ReferralPaper=0 then c.ObjectName+' '+CONVERT(char(3),e1.RateFalse)+'%' when e.TraiTuyen=1 and e.ReferralPaper=1 then c.ObjectName+' '+CONVERT(char(3),e1.RateTrue)+'%' else c.ObjectName+' '+CONVERT(char(3),e1.RateTrue)+'%' end) else c.ObjectName end) ObjectNameBHYT,e.ReferralPaper,a.Content,a.STT,a1.OrderNumberYYYY,sp.GroupName as GroupPrint
		from PatientReceive a1 inner join SuggestedServiceReceipt a on a1.PatientReceiveID=a.RefID inner join Patients b on a.PatientCode=b.PatientCode inner join [Object] c on a.ObjectCode=c.ObjectCode
		left join BHYT e on a.PatientCode=e.PatientCode and a.RefID=e.PatientReceiveID LEFT join RateBHYT e1 on (e.Serial01+e.Serial02)=e1.RateCard
		left join KCBBD f on REPLACE(e.KCBBDCodeFull,' ','')=(f.ProvincialIDBHYT+'-'+f.KCBBDCode) and e.Hide=0 inner join Service g on a.ServiceCode = g.ServiceCode inner join Employee i on a.EmployeeCode=i.EmployeeCode
		left join MedicalRecord j on a.ReferenceCode=j.MedicalRecordCode  left join Department j1 on j.DepartmentCode =j1.DepartmentCode 
		--left join Diagnosis j3 on j.DiagnosisCode=j3.RowID
		left join Department j2 on a.DepartmentCodeOrder =j2.DepartmentCode left join UnitOfMeasure a2 on g.UnitOfMeasureCode=a2.UnitOfMeasureCode
		left join Employee a3 on a.EmployeeCodeDoctor=a3.EmployeeCode inner join ServiceCategory g1 on g.ServiceCategoryCode=g1.ServiceCategoryCode
		left join Catalog_Ward b1 on a1.WardCode=b1.WardCode left join Catalog_District b2 on a1.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on a1.ProvincialCode=b3.ProvincialCode
		left join ServiceGroupPrint sp on g.IDGroupPrint=sp.ID
		where a.Note not in('TIEPDON') and a.RefID=@PatientReceiveID and a.PatientCode=@PatientCode 
		and a.ReferenceCode = (case @ReferenceCode when '' then a.ReferenceCode else @ReferenceCode end)  and convert(date,a.WorkDate,103)=convert(date,@WorkDate,103) and a.ReceiptID in(select ReceiptID from @TableReceiptID) and g.ServiceGroupCode in(select ServiceGroupCode from @TableServiceGroup)
		and a.ReceiptID_DisparityPrice=0
	end
	else
	begin
		select a.ReceiptID,a.DepartmentCode,a.ServiceCode,a.ServicePrice,a.DisparityPrice,a.Status,a.Paid,a.PatientCode,a.ObjectCode,a.WorkDate,b.PatientName,[dbo].func_PatientOfAddress(@PatientReceiveID) PatientAddress,b.PatientAge,c.ObjectName,g.ServiceName,
		e.TraiTuyen,CONVERT(char(10),e.StartDate,103) StartDate,CONVERT(char(10),e.EndDate,103) EndDate,e.Serial,(f.ProvincialIDBHYT+'-'+e.KCBBDCode) KCBBDCode,f.KCBBDName,(case when PatientGender=0 then N'Nữ' else N'Nam' end) PatientGenderName,b.PatientBirthyear,j.Symptoms,i.EmployeeName,j1.DepartmentName,a1.Reason,j2.DepartmentName DepartmentNameOrder,a1.IntroName,a2.UnitOfMeasureName,a.Quantity,a3.EmployeeName EmployeeNameDoctor,j.DiagnosisCode DiagnosisCustom,UPPER(g1.ServiceCategoryName) ServiceCategoryName,('('+j3.DiagnosisCode+')'+j3.DiagnosisName) DiagnosisName,
		(case when a.ObjectCode=1 then ( case when e.TraiTuyen=1 and e.ReferralPaper=0 then c.ObjectName+' '+CONVERT(char(3),e1.RateFalse)+'%' when e.TraiTuyen=1 and e.ReferralPaper=1 then c.ObjectName+' '+CONVERT(char(3),e1.RateTrue)+'%' else c.ObjectName+' '+CONVERT(char(3),e1.RateTrue)+'%' end) else c.ObjectName end) ObjectNameBHYT,e.ReferralPaper,a.Content,a.STT,a1.OrderNumberYYYY,sp.GroupName as GroupPrint
		from PatientReceive a1 inner join SuggestedServiceReceipt a on a1.PatientReceiveID=a.RefID inner join Patients b on a.PatientCode=b.PatientCode inner join [Object] c on a.ObjectCode=c.ObjectCode
		left join BHYT e on a.PatientCode=e.PatientCode and a.RefID=e.PatientReceiveID LEFT join RateBHYT e1 on (e.Serial01+e.Serial02)=e1.RateCard
		left join KCBBD f on REPLACE(e.KCBBDCodeFull,' ','')=(f.ProvincialIDBHYT+'-'+f.KCBBDCode) and e.Hide=0 inner join Service g on a.ServiceCode = g.ServiceCode 
		inner join Employee i on a.EmployeeCode=i.EmployeeCode left join MedicalEmergency j on a.ReferenceCode=j.MedicalEmergencyCode left join Department j1 on j.DepartmentCode =j1.DepartmentCode left join Diagnosis j3 on j.ICD10=j3.DiagnosisCode
		left join Department j2 on a.DepartmentCodeOrder =j2.DepartmentCode left join UnitOfMeasure a2 on g.UnitOfMeasureCode=a2.UnitOfMeasureCode
		left join Employee a3 on a.EmployeeCodeDoctor=a3.EmployeeCode inner join ServiceCategory g1 on g.ServiceCategoryCode=g1.ServiceCategoryCode
		left join Catalog_Ward b1 on a1.WardCode=b1.WardCode left join Catalog_District b2 on a1.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on a1.ProvincialCode=b3.ProvincialCode
		left join ServiceGroupPrint sp on g.IDGroupPrint=sp.ID
		where a.Note not in('TIEPDON') and a.RefID=@PatientReceiveID and a.PatientCode=@PatientCode and convert(date,a.WorkDate,103)=convert(date,@WorkDate,103) 
		and a.ReceiptID in(select ReceiptID from @TableReceiptID) 
		and g.ServiceGroupCode in(select ServiceGroupCode from @TableServiceGroup)
		and a.ReferenceCode = case @ReferenceCode when '' then a.ReferenceCode else @ReferenceCode end
		and a.ReceiptID_DisparityPrice=0
	end
end
go
--IF NOT EXISTS (SELECT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CatalogComputer')
--begin
--CREATE TABLE CatalogComputer
--(
--	ComputerName nvarchar(200),
--	VersionNo varchar(20),
--	MacAddress varchar(20),
--	HDDSerialNo varchar(20),
--	IDate datetime default getdate() not null
--	CONSTRAINT CatalogComputer_pk PRIMARY KEY (HDDSerialNo)
--)
--end
--go
if exists(select name from sysobjects where name ='proInsCatalogComputer')
	drop procedure proInsCatalogComputer
go
create procedure proInsCatalogComputer
(
	@ComputerName nvarchar(200),
	@VersionNo varchar(20),
	@MacAddress varchar(20),
	@HDDSerialNo varchar(20)
)
as
begin
	if exists(select ComputerName from CatalogComputer where HDDSerialNo=@HDDSerialNo)
		update CatalogComputer set ComputerName=@ComputerName,VersionNo=@VersionNo,MacAddress=@MacAddress,IDate=GETDATE() where HDDSerialNo=@HDDSerialNo
	else
		insert into CatalogComputer(ComputerName,VersionNo,MacAddress,HDDSerialNo) values(@ComputerName,@VersionNo,@MacAddress,@HDDSerialNo)
end
go
----------- Update 10/06/2016
if exists(select name from sysobjects where name like'proPrintBanksInvoice')
	drop procedure proPrintBanksInvoice
go
create procedure proPrintBanksInvoice
(
	@PatientReceiveID numeric(18,0),
	@ObjectCode int
)
as
begin
	if(@ObjectCode=1)
	begin
		select N'Thu V.Phí Khám Chữa Bệnh Ngoại Trú BHYT' as NameService,ISNULL(sum(a.PatientPay),0) PatientPay,c.PatientName,[dbo].func_PatientOfAddress(@PatientReceiveID) PatientAddress
		,(select top 1 PostingDate from BanksAccount where ReferenceCode=@PatientReceiveID ) PostingDate
		from BanksAccountDetail a inner join BanksAccount b on a.BanksAccountCode=b.BanksAccountCode inner join Patients c on b.PatientCode=c.PatientCode
		 where b.ReferenceCode=@PatientReceiveID and a.ObjectCode in(@ObjectCode) and b.Cancel=0
		 group by c.PatientName,c.PatientAddress
		union all
		select N'Thu V.Phí Khám Chữa Bệnh Ngoại Trú Dịch Vụ' as NameService,sum(a.PatientPay) PatientPay,c.PatientName,[dbo].func_PatientOfAddress(@PatientReceiveID) PatientAddres
		,(select top 1 PostingDate from BanksAccount where ReferenceCode=@PatientReceiveID ) PostingDate
		from BanksAccountDetail a inner join BanksAccount b on a.BanksAccountCode=b.BanksAccountCode inner join Patients c on b.PatientCode=c.PatientCode
		 where b.ReferenceCode=@PatientReceiveID and a.ObjectCode not in(@ObjectCode) and b.Cancel=0
		 group by c.PatientName,c.PatientAddress
	 end
	 else
	 begin
		select N'Thu V.Phí Khám Chữa Bệnh Ngoại Trú Dịch Vụ' as NameService, SUM(a.PatientPay) PatientPay,c.PatientName,[dbo].func_PatientOfAddress(@PatientReceiveID) PatientAddress
		,(select top 1 PostingDate from BanksAccount where ReferenceCode=@PatientReceiveID ) PostingDate
		from BanksAccountDetail a inner join BanksAccount b on a.BanksAccountCode=b.BanksAccountCode inner join Patients c on b.PatientCode=c.PatientCode
		 where b.ReferenceCode=@PatientReceiveID and a.ObjectCode not in(1) and b.Cancel=0
		 group by c.PatientName,c.PatientAddress
	 end
end
go
----------------------- update 11/06/2016
if exists(select name from sysobjects where name ='proRepositoryForUser' and type='P')
	drop procedure proRepositoryForUser
go
create procedure proRepositoryForUser
(
	@Hide int,
	@RepositoryGroupCode varchar(50),
	@EmployeeCode varchar(10)
)
as
begin
	declare @TableRepository table(RepositoryCode varchar(10))
	declare @TableGroup table(RepositoryGroupCode int)
	declare @RepositoryCode varchar(100) = (select PermissionRepository from Employee where EmployeeCode=@EmployeeCode)
	if LEN(@RepositoryCode)>0
		insert into @TableRepository(RepositoryCode)(select * from dbo.fnSplitString(@RepositoryCode,','))
	else
		insert into @TableRepository(RepositoryCode)(select RepositoryCode from RepositoryCatalog)
	if LEN(@RepositoryGroupCode)>0
		insert into @TableGroup(RepositoryGroupCode)(select * from dbo.fnSplitNumber(@RepositoryGroupCode,','))
	else
		insert into @TableGroup(RepositoryGroupCode)(select RepositoryGroupCode from RepositoryGroup)
	select RowID,RepositoryCode,RepositoryName,Hide,RepositoryGroupCode 
	from RepositoryCatalog 
	where Hide=@Hide and RepositoryGroupCode in(select RepositoryGroupCode from @TableGroup) and RepositoryCode in(select RepositoryCode from @TableRepository) order by RowID asc
end
go
if exists(select name from sysobjects where name ='proMedicinesRetailDetail' and type='P')
	drop procedure proMedicinesRetailDetail
go
create procedure proMedicinesRetailDetail
(
	@RetailCode varchar(15)
)
as
begin
	declare @TableResult table(STT numeric(18,4), ItemCode varchar(50),ItemName nvarchar(250),DateOfIssues numeric(18,4),Quantity numeric(18,4),QuantityExport numeric(18,4), UnitPrice numeric(18,4), Amount numeric(18,4),Instruction nvarchar(250),UnitOfMeasureName nvarchar(50))
	declare @Count int = 0
	declare @stt int = 1
	declare @Quantitytemp int = 0
	declare @RowID varchar(10)
	declare @ItemCode varchar(50)
	declare @ItemName nvarchar(250)
	declare @DateOfIssues numeric(18,4)
	declare @Quantity numeric(18,4)
	declare @QuantityExport numeric(18,4)
	declare @UnitPrice numeric(18,4)
	declare @Amount numeric(18,4)
	declare @Instruction nvarchar(250)
	declare @UnitOfMeasureName nvarchar(50)
	Declare @TableTemp table(RowID varchar(50),ItemCode varchar(50),ItemName nvarchar(250),DateOfIssues numeric(18,4),Quantity numeric(18,4),QuantityExport numeric(18,4), UnitPrice numeric(18,4), Amount numeric(18,4),Instruction nvarchar(250),UnitOfMeasureName nvarchar(50))
	insert @TableTemp(RowID,ItemCode,ItemName,DateOfIssues,Quantity,QuantityExport,UnitPrice,Amount,Instruction,UnitOfMeasureName)
	(
		select a.RowID, a.ItemCode,b.ItemName,a.DateOfIssues,isnull(sum(a.Quantity),0) Quantity,isnull(sum(a.QuantityExport),0) QuantityExport,
		a.UnitPrice,isnull(sum(a.Amount),0) Amount,a.Instruction,d.UnitOfMeasureName
		from MedicinesRetailDetail a inner join Items b on a.ItemCode=b.ItemCode 
		inner join InventoryGumshoe c on a.RowIDInventoryGumshoe=c.RowID 
		left join UnitOfMeasure d on b.UnitOfMeasureCode=d.UnitOfMeasureCode 
		where a.RetailCode in(@RetailCode)
		group by a.RowID, a.ItemCode,b.ItemName,a.DateOfIssues,a.UnitPrice,a.Instruction,d.UnitOfMeasureName
	)
	set @Count = (select COUNT(*) sl from @TableTemp)
	WHILE(@Count) > 0
	begin
		select top (1) @ItemCode = ItemCode from @TableTemp
		insert @TableResult (stt,ItemCode,ItemName,DateOfIssues,Quantity,QuantityExport,UnitPrice,Amount,Instruction,UnitOfMeasureName)
		(select @stt, ItemCode,ItemName,DateOfIssues,isnull(sum(Quantity),0) Quantity,isnull(sum(QuantityExport),0) QuantityExport,UnitPrice,isnull(sum(Amount),0) Amount,Instruction,UnitOfMeasureName from  @TableTemp
		where  ItemCode = @ItemCode  
		group by ItemCode,ItemName,DateOfIssues,UnitPrice,Instruction,UnitOfMeasureName )
		DELETE FROM @TableTemp where ItemCode = @ItemCode 
		set @Count=@Count-1
		set @stt = @stt+1
	end
	select stt,ItemCode,ItemName,DateOfIssues,isnull(sum(Quantity),0) Quantity,isnull(sum(QuantityExport),0) QuantityExport,UnitPrice,isnull(sum(Amount),0) Amount,Instruction,UnitOfMeasureName from @TableResult 
	group by stt,ItemCode,ItemName,DateOfIssues,Quantity,QuantityExport,UnitPrice,Amount,Instruction,UnitOfMeasureName
end
go
if exists(select name from sysobjects where name ='proView_TotalSuggestedForDoctorDoing')
	drop procedure proView_TotalSuggestedForDoctorDoing
go
create procedure proView_TotalSuggestedForDoctorDoing
(
	@FromDate varchar(15),
	@ToDate varchar(15),
	@ServiceCategoryCode varchar(300),
	@EmployeeCodeDoctor varchar(300),
	@ServiceGroupCode varchar(15),
	@Paid int,
	@Done int,
	@ServiceCode varchar(300)
)
as
begin
	declare @TableGroup table(ServiceGroupCode varchar(15))
	declare @TableCategory table(ServiceCategoryCode varchar(15))
	declare @TableDoctor table(EmployeeCode varchar(15))
	declare @TableService table(ServiceCode varchar(15))
	if LEN(@ServiceGroupCode)>0
		insert into @TableGroup(ServiceGroupCode)(select ServiceGroupCode from ServiceGroup where ServiceGroupCode in(select * from dbo.fnSplitString(@ServiceGroupCode,',')))
	else
		insert into @TableGroup(ServiceGroupCode)(select ServiceGroupCode from ServiceGroup)
	if LEN(@ServiceCategoryCode)>0
		insert into @TableCategory(ServiceCategoryCode)(select ServiceCategoryCode from ServiceCategory where ServiceCategoryCode in(select * from dbo.fnSplitString(@ServiceCategoryCode,',')))
	else
		insert into @TableCategory(ServiceCategoryCode)(select ServiceCategoryCode from ServiceCategory where ServiceGroupCode in(select ServiceGroupCode from @TableGroup))
	if LEN(@ServiceCode)>0
		insert into @TableService(ServiceCode)(select ServiceCode from Service where ServiceCode in(select * from dbo.fnSplitString(@ServiceCode,',')))
	else
		insert into @TableService(ServiceCode)(select ServiceCode from Service where ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory))
	if LEN(@EmployeeCodeDoctor)>0
		insert into @TableDoctor(EmployeeCode)(select EmployeeCode from Employee where EmployeeCode in(select * from dbo.fnSplitString(@EmployeeCodeDoctor,',')))
	else
		insert into @TableDoctor(EmployeeCode)(select EmployeeCode from Employee)
	begin
	--Cong kham
		select e.PatientCode, e.PatientName,(case when e.PatientGender=0 then N'Nữ' else N'Nam' end) PatientGenderName,e.PatientBirthyear,b.ServiceName,b1.ServiceCategoryName,a.ServicePrice,a.DisparityPrice,CONVERT(date,a.WorkDate,103) WorkDate,a2.EmployeeName EmployeeNameDoctor,
		[dbo].func_PatientOfAddressFull(d.Address,d1.WardName,d2.DistrictName,d3.ProvincialName) PatientAddress,f.NoInvoice,b2.ServiceGroupName,dc.DepartmentName,dc1.DepartmentName as DepartmentNameOrder
		, oj.ObjectName,f.BanksAccountCode,e.PatientAge,convert(char(10),d.CreateDate,103) DateIn
		from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode 
		inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b.ServiceGroupCode=b2.ServiceGroupCode
		inner join MedicalRecord a1 on a.ReceiptID=a1.ReceiptID and a1.TypeMedical=0 and a1.EmployeeCodeDoctor in(select EmployeeCode from @TableDoctor) 
		inner join Employee a2 on a1.EmployeeCodeDoctor=a2.EmployeeCode
		inner join PatientReceive d on a.RefID=d.PatientReceiveID left join Catalog_Ward d1 on d.WardCode=d1.WardCode left join Catalog_District d2 on d.DistrictCode=d2.DistrictCode left join Catalog_Provincial d3 on d.ProvincialCode=d3.ProvincialCode
		inner join Patients e on d.PatientCode=e.PatientCode left join BanksAccount f on a.BanksAccountCode=f.BanksAccountCode 
		inner join Department dc on	dc.DepartmentCode=a1.DepartmentCode left join Department dc1 on a.DepartmentCodeOrder = dc1.DepartmentCode inner join Object oj on a.ObjectCode=oj.ObjectCode
		where  a.Paid=(case @Paid when 1 then @Paid else a.Paid end)  and b.ServiceCategoryCode in (select ServiceCategoryCode from @TableCategory)
		and CONVERT(date,a.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) 
		and a.ServiceCode in (select ServiceCode from @TableService)
		union 
		-- sieu am
		select e.PatientCode, e.PatientName,(case when e.PatientGender=0 then N'Nữ' else N'Nam' end) PatientGenderName,e.PatientBirthyear,b.ServiceName,b1.ServiceCategoryName,a.ServicePrice,a.DisparityPrice,CONVERT(date,a.WorkDate,103) WorkDate,c1.EmployeeName EmployeeNameDoctor,
		[dbo].func_PatientOfAddressFull(d.Address,d1.WardName,d2.DistrictName,d3.ProvincialName) PatientAddress,f.NoInvoice,b2.ServiceGroupName,dc.DepartmentName,dc1.DepartmentName as DepartmentNameOrder
		, oj.ObjectName,f.BanksAccountCode,e.PatientAge,convert(char(10),d.CreateDate,103) DateIn
		from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode 
		inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b.ServiceGroupCode=b2.ServiceGroupCode
		inner join ServiceRadiologyEntry c on a.ReceiptID=c.SuggestedID and c.EmployeeCodeDoctor in(select EmployeeCode from @TableDoctor) 
		inner join Employee c1 on c.EmployeeCodeDoctor=c1.EmployeeCode
		inner join PatientReceive d on a.RefID=d.PatientReceiveID left join Catalog_Ward d1 on d.WardCode=d1.WardCode left join Catalog_District d2 on d.DistrictCode=d2.DistrictCode left join Catalog_Provincial d3 on d.ProvincialCode=d3.ProvincialCode
		inner join Patients e on d.PatientCode=e.PatientCode left join BanksAccount f on a.BanksAccountCode=f.BanksAccountCode
		inner join Department dc on	dc.DepartmentCode=a.DepartmentCode left join Department dc1 on a.DepartmentCodeOrder = dc1.DepartmentCode inner join Object oj on a.ObjectCode=oj.ObjectCode
		where  a.Paid=(case @Paid when 1 then @Paid else a.Paid end)  and b.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory)
		and CONVERT(date,a.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) 
		and a.ServiceCode in (select ServiceCode from @TableService)
		union 
		--xet nghiem
		select distinct e.PatientCode, e.PatientName,(case when e.PatientGender=0 then N'Nữ' else N'Nam' end) PatientGenderName,e.PatientBirthyear,b.ServiceName,b1.ServiceCategoryName,a.ServicePrice,a.DisparityPrice,CONVERT(date,a.WorkDate,103) WorkDate,c2.EmployeeName EmployeeNameDoctor,
		[dbo].func_PatientOfAddressFull(d.Address,d1.WardName,d2.DistrictName,d3.ProvincialName) PatientAddress,f.NoInvoice,b2.ServiceGroupName,dc.DepartmentName,dc1.DepartmentName as DepartmentNameOrder
		, oj.ObjectName,f.BanksAccountCode,e.PatientAge,convert(char(10),d.CreateDate,103) DateIn
		from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode 
		inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b.ServiceGroupCode=b2.ServiceGroupCode
		inner join ServiceLaboratoryEntry c inner join ServiceLaboratoryDetail c1 on c.RowID = c1.RowIDLaboratoryEnTry on a.ReceiptID=c1.SuggestedID 
		--and c.EmployeeCode in(select EmployeeCode from @TableDoctor) 
		inner join Employee c2 on c.EmployeeCode=c2.EmployeeCode
		inner join PatientReceive d on a.RefID=d.PatientReceiveID left join Catalog_Ward d1 on d.WardCode=d1.WardCode left join Catalog_District d2 on d.DistrictCode=d2.DistrictCode left join Catalog_Provincial d3 on d.ProvincialCode=d3.ProvincialCode
		inner join Patients e on d.PatientCode=e.PatientCode left join BanksAccount f on a.BanksAccountCode=f.BanksAccountCode
		inner join Department dc on	dc.DepartmentCode=a.DepartmentCode left join Department dc1 on a.DepartmentCodeOrder = dc1.DepartmentCode inner join Object oj on a.ObjectCode=oj.ObjectCode
		where  a.Paid=(case @Paid when 1 then @Paid else a.Paid end)  and b.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory)
		and CONVERT(date,a.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) 
		and a.ServiceCode in(select ServiceCode from @TableService)
		union 
		--
		select e.PatientCode, e.PatientName,(case when e.PatientGender=0 then N'Nữ' else N'Nam' end) PatientGenderName,e.PatientBirthyear,b.ServiceName,b1.ServiceCategoryName,a.ServicePrice,a.DisparityPrice,CONVERT(date,a.WorkDate,103) WorkDate,c1.EmployeeName EmployeeNameDoctor,
		[dbo].func_PatientOfAddressFull(d.Address,d1.WardName,d2.DistrictName,d3.ProvincialName) PatientAddress,f.NoInvoice,b2.ServiceGroupName,dc.DepartmentName,dc1.DepartmentName as DepartmentNameOrder
		, oj.ObjectName,f.BanksAccountCode,e.PatientAge,convert(char(10),d.CreateDate,103) DateIn
		from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode 
		inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b.ServiceGroupCode=b2.ServiceGroupCode
		inner join Surgeries c on a.ReceiptID=c.IDSuggested and c.EmployeeCode in(select EmployeeCode from @TableDoctor) 
		inner join Employee c1 on c.EmployeeCode=c1.EmployeeCode
		inner join PatientReceive d on a.RefID=d.PatientReceiveID left join Catalog_Ward d1 on d.WardCode=d1.WardCode left join Catalog_District d2 on d.DistrictCode=d2.DistrictCode left join Catalog_Provincial d3 on d.ProvincialCode=d3.ProvincialCode
		inner join Patients e on d.PatientCode=e.PatientCode left join BanksAccount f on a.BanksAccountCode=f.BanksAccountCode
		inner join Department dc on	dc.DepartmentCode=a.DepartmentCode left join Department dc1 on a.DepartmentCodeOrder = dc1.DepartmentCode inner join Object oj on a.ObjectCode=oj.ObjectCode
		where  a.Paid=(case @Paid when 1 then @Paid else a.Paid end)  and b.ServiceCategoryCode in(select ServiceCategoryCode from @TableCategory)
		and CONVERT(date,a.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) 
		and a.ServiceCode in(select ServiceCode from @TableService)
		order by CONVERT(date,WorkDate,103)
	end
end
go
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[HospitalTransfer]') AND type in (N'U'))
begin
CREATE TABLE HospitalTransfer
(
	RowID decimal(18,0),
	HospitalTransfer nvarchar(300),
	PatientReceiveID decimal(18,0),
	ObjectCode int,
	DepartmentCode varchar(15),
	DateIn varchar(15),
	HourIn varchar(5),
	DateMedical varchar(15),
	HourMedical varchar(5),
	Symptoms nvarchar(200),
	LabResult nvarchar(1000),
	RadResult nvarchar(1000),
	DiagnosisCustom nvarchar(200),
	DrugUsed nvarchar(1000),
	ReferenceCode varchar(50),
	Result nvarchar(500),
	Reason nvarchar(500),
	IDate datetime default getdate(),
	DateTransfer char(10),
	HourTransfer char(5),
	NumberSave varchar(10),
	NumberTransfer varchar(10),
	TransferExpediency nvarchar(200),
	TransferFullName nvarchar(200),
	EmployeeCode varchar(15),
	DirectorApproval bit,
	PatientApproval bit,
	EmployeeCodeDoctor varchar(15),
	WorkDate datetime default getdate(),
	PatientAddress nvarchar(1000),
	Serial01 varchar(5),Serial02 varchar(5),Serial03 varchar(5),Serial04 varchar(5),Serial05 varchar(5),Serial06 varchar(5),
	FromDate varchar(10),
	ToDate varchar(10)
	CONSTRAINT pk_HospitalTransfer PRIMARY KEY(PatientReceiveID)
)
end
go
if exists(select name from sysobjects where name ='proIns_HospitalTransfer')
	drop procedure proIns_HospitalTransfer
go
create procedure proIns_HospitalTransfer --  02/08/2016
(
	@HospitalTransfer nvarchar(300),
	@PatientReceiveID decimal(18,0),
	@ObjectCode int,
	@DepartmentCode varchar(15),
	@DateIn varchar(15),
	@HourIn varchar(5),
	@DateMedical varchar(15),
	@HourMedical varchar(5),
	@Symptoms nvarchar(200),
	@LabResult nvarchar(1000),
	@DiagnosisCustom nvarchar(200),
	@DrugUsed nvarchar(1000),
	@ReferenceCode varchar(50),
	@Result nvarchar(500),
	@Reason nvarchar(500),
	@DateTransfer char(10),
	@HourTransfer char(5),
	@NumberSave varchar(10),
	@NumberTransfer varchar(10),
	@TransferExpediency nvarchar(200),
	@TransferFullName nvarchar(200),
	@EmployeeCode varchar(15),
	@DirectorApproval bit,
	@PatientApproval bit,
	@EmployeeCodeDoctor varchar(15),
	@WorkDate datetime,
	@PatientAddress nvarchar(1000),
	@Serial01 varchar(5),@Serial02 varchar(5),@Serial03 varchar(5),@Serial04 varchar(5),@Serial05 varchar(5),@Serial06 varchar(5),
	@FromDate varchar(10),
	@ToDate varchar(10)
)
as
begin
	if exists(select PatientReceiveID from HospitalTransfer where PatientReceiveID=@PatientReceiveID)
	begin
		update HospitalTransfer set ObjectCode=@ObjectCode,DepartmentCode=@DepartmentCode,DateIn=@DateIn,HourIn=@HourIn,DateMedical=@DateMedical,HourMedical=@HourMedical,Symptoms=@Symptoms,LabResult=@LabResult,DiagnosisCustom=@DiagnosisCustom,DrugUsed=@DrugUsed,ReferenceCode=@ReferenceCode,Result=@Result,Reason=@Reason,DateTransfer=@DateTransfer,HourTransfer=@HourTransfer,NumberSave=@NumberSave,NumberTransfer=@NumberTransfer,TransferExpediency=@TransferExpediency,TransferFullName=@TransferFullName,EmployeeCode=@EmployeeCode,DirectorApproval=@DirectorApproval,PatientApproval=@PatientApproval,EmployeeCodeDoctor=@EmployeeCodeDoctor,WorkDate=getdate(),PatientAddress=@PatientAddress,Serial01=@Serial01,Serial02=@Serial02,Serial03=@Serial03,Serial04=@Serial04,Serial05=@Serial05,Serial06=@Serial06, FromDate=@FromDate,ToDate=@ToDate where PatientReceiveID=@PatientReceiveID
	end
	else
	begin
		declare @RowID decimal(18,0)
		declare @OrderNumber int = 0
		set @RowID = (select (ISNULL(max(RowID),0)+1) RowID from HospitalTransfer)
		set @OrderNumber = ((select count(*) SL from HospitalTransfer where year(WorkDate)=year(getdate()))+1)
		if(LEN(@OrderNumber)=1)
			set @NumberTransfer = (select convert(char(5),DATEPART(yyyy,GETDATE())) WorkingDate)+'0000'+convert(varchar(5),@OrderNumber)
		else if(LEN(@OrderNumber)=2)
			set @NumberTransfer = (select convert(char(5),DATEPART(yyyy,GETDATE())) WorkingDate)+'000'+convert(varchar(5),@OrderNumber)
		else if(LEN(@OrderNumber)=3)
			set @NumberTransfer = (select convert(char(5),DATEPART(yyyy,GETDATE())) WorkingDate)+'00'+convert(varchar(5),@OrderNumber)
		else if(LEN(@OrderNumber)=4)
			set @NumberTransfer = (select convert(char(5),DATEPART(yyyy,GETDATE())) WorkingDate)+'0'+convert(varchar(5),@OrderNumber)
		else
			set @NumberTransfer = (select convert(char(5),DATEPART(yyyy,GETDATE())) WorkingDate)+convert(varchar(5),@OrderNumber)
		insert into HospitalTransfer(RowID,HospitalTransfer,PatientReceiveID,ObjectCode,DepartmentCode,DateIn,HourIn,DateMedical,HourMedical,Symptoms,LabResult,DiagnosisCustom,DrugUsed,ReferenceCode,Result,Reason,DateTransfer,HourTransfer,NumberSave,NumberTransfer,TransferExpediency,TransferFullName,EmployeeCode,DirectorApproval,PatientApproval,EmployeeCodeDoctor,WorkDate,PatientAddress,Serial01,Serial02,Serial03,Serial04,Serial05,Serial06,FromDate,ToDate) values(@RowID,@HospitalTransfer,@PatientReceiveID,@ObjectCode,@DepartmentCode,@DateIn,@HourIn,@DateMedical,@HourMedical,@Symptoms,@LabResult,@DiagnosisCustom,@DrugUsed,@ReferenceCode,@Result,@Reason,@DateTransfer,@HourTransfer,@NumberSave,@NumberTransfer,@TransferExpediency,@TransferFullName,@EmployeeCode,@DirectorApproval,@PatientApproval,@EmployeeCodeDoctor,@WorkDate,@PatientAddress,@Serial01,@Serial02,@Serial03,@Serial04,@Serial05,@Serial06,@FromDate,@ToDate)
	end
end
go
if exists(select name from sysobjects where name ='proDel_HospitalTransfer')
	drop procedure proDel_HospitalTransfer
go
create procedure proDel_HospitalTransfer
(
	@PatientReceiveID decimal
)
as
begin
	delete from HospitalTransfer where PatientReceiveID=@PatientReceiveID
end
go
if exists(select name from sysobjects where name ='pro_DSTransfer')
	drop procedure pro_DSTransfer
go
create procedure pro_DSTransfer
(
	@datefr varchar(15),
	@dateto varchar(15)
)
as
begin
	select a.HospitalTransfer,a.PatientReceiveID,o.ObjectName,a.DateIn+' '+a.HourIn DateIn,a.DateMedical+' '+a.HourMedical DateMedical,a.Symptoms,a.LabResult,a.DiagnosisCustom,a.DrugUsed,a.ReferenceCode,a.Result,a.Reason,a.DateTransfer+' '+a.HourTransfer DateTransfer,a.NumberSave,a.NumberTransfer,a.TransferExpediency,a.TransferFullName,e1.EmployeeName,a.DirectorApproval,a.PatientApproval,a.WorkDate,a.PatientAddress,
	a.Serial01+a.Serial02+a.Serial03+a.Serial04+a.Serial05+a.Serial06 MaTheBH,a.FromDate,a.ToDate,b1.PatientName,CONVERT(date,b1.PatientBirthday,103) PatientBirthday,b2.EThnicName,b3.CareerName,
	e.EmployeeName EmployeeNameDoctor, (case when b1.PatientGender = 0 then N'Nữ' else 'Nam' end) PatientGender,d.DepartmentName,b.PatientCode
	from HospitalTransfer a inner join PatientReceive b on a.PatientReceiveID=b.PatientReceiveID inner join Patients b1 on b.PatientCode=b1.PatientCode inner join Catalog_EThnic b2 on b.EThnicID=b2.EThnicID inner join Career b3 on b.CareerCode=b3.CareerCode inner join Employee e on a.EmployeeCodeDoctor=e.EmployeeCode 
	inner join Department d on d.DepartmentCode=a.DepartmentCode inner join Object o on o.ObjectCode=a.ObjectCode inner join Employee e1 on a.EmployeeCode=e1.EmployeeCode
	where CONVERT(date,a.DateTransfer,103) between CONVERT(date,@datefr,103) and CONVERT(date,@dateto,103)
	end
go
if exists(select name from sysobjects where name ='pro_DTListResultLabSend')
	drop procedure pro_DTListResultLabSend
go
create procedure pro_DTListResultLabSend
(
	@datefr varchar(15),
	@dateto varchar(15)
)
as
	begin
		select a.WorkDate, b.RowID as PatientReceiveID, b.PatientCode, b.PatientName, b.PatientMobile, b.PatientBirthday, [dbo].func_PatientOfAddressFull(  b.PatientAddress,d1.WardName,d2.DistrictName,d3.ProvincialName) PatientAddress, (case when b.PatientGender = 0 then N'Nữ' else N'Nam' end) GenderName,
		e.ServiceName, f.UnitPrice, f.SampleTransferPrice
		from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode	left join Catalog_Ward d1 on d1.WardCode=b.WardCode left join Catalog_District d2 on d2.DistrictCode=b.DistrictCode left join 
		Catalog_Provincial d3 on d3.ProvincialCode=b.ProvincialCode
		inner join Service e on a.ServiceCode=e.ServiceCode inner join ServicePrice f on f.ServiceCode=e.ServiceCode
		where a.SampleTransfer = 1 and a.Paid =1 
		and CONVERT(date,a.WorkDate,103) between CONVERT(date,@datefr,103) and CONVERT(date,@dateto,103) 
		order by a.WorkDate
	end
go
if exists(select name from sysobjects where name='proView_ListServiceLaboratory')
	drop procedure proView_ListServiceLaboratory
go
create procedure proView_ListServiceLaboratory--04/08/2016
(
	@FromDate char(10),
	@ToDate char(10)
)
as
	begin
		select  ROW_NUMBER() OVER(ORDER BY CONVERT(date,a.PostingDate,103) DESC) as STT, CONVERT(date,a.PostingDate,103) PostingDate, b.PatientCode,b.PatientName,(case when b.PatientGender=0 then (case when b.PatientAge = 0 then CONVERT(char(3),b.PatientMonth)+'Th' else CONVERT(char(3),b.PatientAge)+'T' end) else '' end) GenderFeMale,(case when b.PatientGender=1 then (case when b.PatientAge = 0 then CONVERT(char(3),b.PatientMonth)+'Th' else CONVERT(char(3),b.PatientAge)+'T' end) else '' end)  GenderMale,
		[dbo].func_PatientOfAddressFull(b.PatientAddress,b1.WardName,c1.DistrictName,d1.ProvincialName) PatientAddress, a2.CareerName , a3.EThnicName,
		d.DiagnosisCustom, a1.ServiceName, [dbo].func_Lap(f.ReceiptID,f.ServiceCode) as kq, e.EmployeeName
		from ServiceLaboratoryEntry a inner join Patients b on a.PatientCode=b.PatientCode inner join PatientReceive c on a.PatientReceiveID=c.PatientReceiveID
		left join MedicalRecord d on c.PatientReceiveID=d.PatientReceiveID inner join Employee e on e.EmployeeCode = a.EmployeeCode
		inner join SuggestedServiceReceipt f on a.PatientReceiveID=f.RefID and CONVERT(date,f.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
		inner join Service a1 on f.ServiceCode=a1.ServiceCode 
		left join Catalog_Ward b1 on b.WardCode=b1.WardCode left join Catalog_District c1 on b.DistrictCode=c1.DistrictCode left join Catalog_Provincial d1 on b.ProvincialCode=d1.ProvincialCode 
		left join Career a2 on c.CareerCode=a2.CareerCode left join Catalog_EThnic a3 on c.EThnicID=a3.EThnicID
		where f.Paid in (1,2) and a1.ServiceCode in (select ServiceCode from ServiceLaboratoryDetail de where a.RowID=de.RowIDLaboratoryEnTry)
		and CONVERT(date,a.PostingDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
	end
go
if exists(select name from sysobjects where name ='func_Lap')
	drop function func_Lap
go
create function [dbo].[func_Lap](@SuggestedID VarChar(50),@ServiceCode VarChar(50))
RETURNS NVARCHAR(1000)
AS
BEGIN
	Declare @strKQ nvarchar(1000)
	set @strKQ=''
	Declare @Tempt nvarchar(1000)
	Declare @kq nvarchar(250)
	declare cur1 cursor read_only fast_forward
	for select f.LaboratoryName+' '+ f.ValuesEntry+' '+f.UnitValues from ServiceLaboratoryDetail f where f.SuggestedID = @SuggestedID and f.ServiceCode=@ServiceCode
	open cur1
	fetch next from cur1 into @kq
	while @@FETCH_STATUS = 0
	begin
		set @Tempt = @kq
		if ( len(@strKQ) > 0)
		begin
			set @strKQ=@strKQ + '; ' + @Tempt
		end
		else
		begin
			set @strKQ=@strKQ + @Tempt
		end
		
		FETCH NEXT FROM cur1 into @kq
	end
	CLOSE cur1
	DEALLOCATE cur1
	RETURN @strKQ
end
go
---
if exists(select name from sysobjects where name ='pro_ReportDailyInvoice_xempk')
	drop procedure pro_ReportDailyInvoice_xempk
go
create procedure pro_ReportDailyInvoice_xempk -- 020716
(
	@StartDate datetime,
	@EndDate datetime,
	@Cancel int,
	@Loai int
)
as
begin
if ( @Loai = 0)
	begin
		select ROW_NUMBER() OVER(ORDER BY a.BanksAccountCode DESC) AS RowNumber, b.PatientCode,b.PatientName,
		(case when b.PatientGender=1 then N'Nam' else N'Nữ' end)PatientGenderName,b.PatientBirthyear,a3.ObjectName,CONVERT(date,a.PostingDate,103) PostingDate,
		a2.EmployeeName CashierName,a.TotalReal,[dbo].func_PatientOfAddressFull(c.Address,c1.WardName,c2.DistrictName,c3.ProvincialName) PatientAddress,a.BanksAccountCode,a.ReferenceCode,a.ObjectCode
		, a.Exemptions, a.TotalSurcharge, a.TotalAmount, c.PatientReceiveClinic
		from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode left join Employee a1 on a.EmployeeCode=a1.EmployeeCode left join Employee a2 on a.CashierCode=a2.EmployeeCode
		inner join Object a3 on a.ObjectCode=a3.ObjectCode inner join PatientReceive c on a.ReferenceCode=c.PatientReceiveID left join Employee a4 on a.EmployeeCodeCancel=a4.EmployeeCode
		left join Catalog_Ward c1 on c.WardCode=c1.WardCode left join Catalog_District c2 on c.DistrictCode=c2.DistrictCode left join Catalog_Provincial c3 on c.ProvincialCode=c3.ProvincialCode
		where convert(date,a.PostingDate,103) between convert(date,@StartDate,103) and convert(date,@EndDate,103) 
		and a.Cancel=(case @Cancel when 1 then @Cancel else 0 end)
		union all
		select ROW_NUMBER() OVER(ORDER BY a.BanksAccountCode DESC) AS RowNumber, 
		b.PatientCode,b.PatientName,(case when b.PatientGender=1 then N'Nam' else N'Nữ' end) as PatientGenderName,b.PatientBirthyear,a3.ObjectName,CONVERT(date,a.WorkDate,103) PostingDate,
		a1.EmployeeName CashierName, sum(a.ServicePrice*a.Quantity) as TotalReal,[dbo].func_PatientOfAddressFull(b.PatientAddress,c1.WardName,c2.DistrictName,c3.ProvincialName) PatientAddress,a.BanksAccountCode,a.RefID ReferenceCode,a.ObjectCode,
		0 as Exemptions, 0 as TotalSurcharge, sum(a.ServicePrice*a.Quantity) as TotalAmount,pa.PatientReceiveClinic
		from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode left join Employee a1 on a.EmployeeCode=a1.EmployeeCode 
		inner join Object a3 on a.ObjectCode=a3.ObjectCode  left join Employee a4 on a.EmployeeCode=a4.EmployeeCode
		left join Catalog_Ward c1 on b.WardCode=c1.WardCode left join Catalog_District c2 on b.DistrictCode=c2.DistrictCode left join Catalog_Provincial c3 on b.ProvincialCode=c3.ProvincialCode
		inner join PatientReceive pa on pa.PatientReceiveID=a.RefID
		where convert(date,a.WorkDate,103) between convert(date,@StartDate,103) and convert(date,@EndDate,103) and a.Paid=0
		and (a.BanksAccountCode is null or a.BanksAccountCode='')
		group by b.PatientCode,b.PatientName,b.PatientGender,b.PatientBirthyear,a3.ObjectName,CONVERT(date,a.WorkDate,103),a1.EmployeeName,
		a.BanksAccountCode,a.RefID,a.ObjectCode,b.PatientAddress,c1.WardName,c2.DistrictName,c3.ProvincialName,pa.PatientReceiveClinic
		having sum(a.ServicePrice*a.Quantity)>0 
		union all
		select ROW_NUMBER() OVER(ORDER BY a.BanksAccountCode DESC) AS RowNumber, 
		b.PatientCode,b.PatientName,(case when b.PatientGender=1 then N'Nam' else N'Nữ' end) as PatientGenderName,b.PatientBirthyear,a3.ObjectName,CONVERT(date,a.WorkDate,103) PostingDate,
		a1.EmployeeName CashierName,sum(md.Quantity*md.UnitPrice) as TotalReal,[dbo].func_PatientOfAddressFull(b.PatientAddress,c1.WardName,c2.DistrictName,c3.ProvincialName) PatientAddress,a.BanksAccountCode,a.RefID ReferenceCode,a.ObjectCode,
		0 as Exemptions, 0 as TotalSurcharge, sum(md.Quantity*md.UnitPrice) as TotalAmount, pa.PatientReceiveClinic
		from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode left join Employee a1 on a.EmployeeCode=a1.EmployeeCode 
		inner join Object a3 on a.ObjectCode=a3.ObjectCode  left join Employee a4 on a.EmployeeCode=a4.EmployeeCode
		left join Catalog_Ward c1 on b.WardCode=c1.WardCode left join Catalog_District c2 on b.DistrictCode=c2.DistrictCode left join Catalog_Provincial c3 on b.ProvincialCode=c3.ProvincialCode
		inner join MedicalRecord m on m.ReceiptID=a.ReceiptID inner join MedicalPrescriptionDetail md on md.MedicalRecordCode = m.MedicalRecordCode
		inner join PatientReceive pa on pa.PatientReceiveID=a.RefID
		where convert(date,a.WorkDate,103) between convert(date,@StartDate,103) and convert(date,@EndDate,103) and m.Paid=0
		and (a.BanksAccountCode is null or a.BanksAccountCode='') and (a.ServicePrice*a.Quantity) >0
		group by b.PatientCode,b.PatientName,b.PatientGender,b.PatientBirthyear,a3.ObjectName,CONVERT(date,a.WorkDate,103),a1.EmployeeName,
		a.BanksAccountCode,a.RefID,a.ObjectCode,b.PatientAddress,c1.WardName,c2.DistrictName,c3.ProvincialName,pa.PatientReceiveClinic
		having sum(a.ServicePrice*a.Quantity)>0 
	end
	else
	begin
		select ROW_NUMBER() OVER(ORDER BY a.BanksAccountCode DESC) AS RowNumber, 
		b.PatientCode,b.PatientName,(case when b.PatientGender=1 then N'Nam' else N'Nữ' end) as PatientGenderName,b.PatientBirthyear,a3.ObjectName,CONVERT(date,a.WorkDate,103) PostingDate,
		a1.EmployeeName CashierName, sum(a.ServicePrice*a.Quantity) as TotalReal,[dbo].func_PatientOfAddressFull(b.PatientAddress,c1.WardName,c2.DistrictName,c3.ProvincialName) PatientAddress,a.BanksAccountCode,a.RefID ReferenceCode,a.ObjectCode,
		0 as Exemptions, 0 as TotalSurcharge, sum(a.ServicePrice*a.Quantity) as TotalAmount,pa.PatientReceiveClinic
		from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode left join Employee a1 on a.EmployeeCode=a1.EmployeeCode 
		inner join Object a3 on a.ObjectCode=a3.ObjectCode  left join Employee a4 on a.EmployeeCode=a4.EmployeeCode
		left join Catalog_Ward c1 on b.WardCode=c1.WardCode left join Catalog_District c2 on b.DistrictCode=c2.DistrictCode left join Catalog_Provincial c3 on b.ProvincialCode=c3.ProvincialCode
		inner join PatientReceive pa on pa.PatientReceiveID=a.RefID
		where convert(date,a.WorkDate,103) between convert(date,@StartDate,103) and convert(date,@EndDate,103) and a.Paid=0
		and (a.BanksAccountCode is null or a.BanksAccountCode='')
		group by b.PatientCode,b.PatientName,b.PatientGender,b.PatientBirthyear,a3.ObjectName,CONVERT(date,a.WorkDate,103),a1.EmployeeName,
		a.BanksAccountCode,a.RefID,a.ObjectCode,b.PatientAddress,c1.WardName,c2.DistrictName,c3.ProvincialName,pa.PatientReceiveClinic
		having sum(a.ServicePrice*a.Quantity)>0 
		union all
		select ROW_NUMBER() OVER(ORDER BY a.BanksAccountCode DESC) AS RowNumber, 
		b.PatientCode,b.PatientName,(case when b.PatientGender=1 then N'Nam' else N'Nữ' end) as PatientGenderName,b.PatientBirthyear,a3.ObjectName,CONVERT(date,a.WorkDate,103) PostingDate,
		a1.EmployeeName CashierName,sum(md.Quantity*md.UnitPrice) as TotalReal,[dbo].func_PatientOfAddressFull(b.PatientAddress,c1.WardName,c2.DistrictName,c3.ProvincialName) PatientAddress,a.BanksAccountCode,a.RefID ReferenceCode,a.ObjectCode,
		0 as Exemptions, 0 as TotalSurcharge, sum(md.Quantity*md.UnitPrice) as TotalAmount, pa.PatientReceiveClinic
		from SuggestedServiceReceipt a inner join Patients b on a.PatientCode=b.PatientCode left join Employee a1 on a.EmployeeCode=a1.EmployeeCode 
		inner join Object a3 on a.ObjectCode=a3.ObjectCode  left join Employee a4 on a.EmployeeCode=a4.EmployeeCode
		left join Catalog_Ward c1 on b.WardCode=c1.WardCode left join Catalog_District c2 on b.DistrictCode=c2.DistrictCode left join Catalog_Provincial c3 on b.ProvincialCode=c3.ProvincialCode
		inner join MedicalRecord m on m.ReceiptID=a.ReceiptID inner join MedicalPrescriptionDetail md on md.MedicalRecordCode = m.MedicalRecordCode
		inner join PatientReceive pa on pa.PatientReceiveID=a.RefID
		where convert(date,a.WorkDate,103) between convert(date,@StartDate,103) and convert(date,@EndDate,103) and m.Paid=0
		and (a.BanksAccountCode is null or a.BanksAccountCode='') and (a.ServicePrice*a.Quantity) >0
		group by b.PatientCode,b.PatientName,b.PatientGender,b.PatientBirthyear,a3.ObjectName,CONVERT(date,a.WorkDate,103),a1.EmployeeName,
		a.BanksAccountCode,a.RefID,a.ObjectCode,b.PatientAddress,c1.WardName,c2.DistrictName,c3.ProvincialName,pa.PatientReceiveClinic
		having sum(a.ServicePrice*a.Quantity)>0 
	end
end
go

if exists(select name from sysobjects where name ='proGetBanksAccountDetailHis')
	drop procedure proGetBanksAccountDetailHis
go
CREATE procedure proGetBanksAccountDetailHis --020716
(
	@BanksAccountCode varchar(50),
	@loai int
)
as
begin
	if( @loai = 1)
		begin
			select b.ServiceName,a2.ObjectName,a1.Quantity,a1.ServicePrice,a1.DisparityPrice,(a1.Quantity*a1.ServicePrice) Amount,b2.UnitOfMeasureName,b3.ServiceGroupName,a1.ObjectCode
			from BanksAccount a inner join BanksAccountDetail a1 on a.BanksAccountCode=a1.BanksAccountCode inner join [Service] b on a1.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join [Object] a2 on a1.ObjectCode=a2.ObjectCode inner join UnitOfMeasure b2 on b.UnitOfMeasureCode=b2.UnitOfMeasureCode inner join ServiceGroup b3 on b3.ServiceGroupCode = b1.ServiceGroupCode
			where a1.BanksAccountCode=@BanksAccountCode
			--union
			--select b.ItemName ServiceName,a2.ObjectName,a1.Quantity,a1.ServicePrice,a1.DisparityPrice,(a1.Quantity*a1.ServicePrice) Amount,b2.UnitOfMeasureName,b3.GroupName ServiceGroupName,a1.ObjectCode
			--from BanksAccount a inner join BanksAccountDetail a1 on a.BanksAccountCode=a1.BanksAccountCode inner join Items b on a1.ServiceCode=b.ItemCode inner join ItemCategory b1 on b.ItemCategoryCode=b1.ItemCategoryCode inner join [Object] a2 on a1.ObjectCode=a2.ObjectCode inner join UnitOfMeasure b2 on b.UnitOfMeasureCode=b2.UnitOfMeasureCode inner join ItemGroup b3 on b3.GroupCode = b1.GroupCode
			--where a1.BanksAccountCode=@BanksAccountCode
		end
	else 
		begin
			select s.ServiceName,a3.ObjectName,a.Quantity,a.ServicePrice,a.DisparityPrice,(a.Quantity*a.ServicePrice) Amount,un.UnitOfMeasureName,sg.ServiceGroupName,a3.ObjectCode
			from SuggestedServiceReceipt a   
			inner join Object a3 on a.ObjectCode=a3.ObjectCode inner join Service s on a.ServiceCode=s.ServiceCode inner join UnitOfMeasure un on s.UnitOfMeasureCode=un.UnitOfMeasureCode
			inner join ServiceGroup sg on sg.ServiceGroupCode=s.ServiceGroupCode
			where a.Paid=0 and (a.Quantity*a.ServicePrice) >0 and a.RefID = @BanksAccountCode
			--union
			--select i.ItemName ServiceName,o.ObjectName,md.Quantity,md.UnitPrice,0 DisparityPrice,(md.Quantity*md.UnitPrice) Amount,un.UnitOfMeasureName,ig.GroupName ServiceGroupName,o.ObjectCode
			--from MedicalRecord m inner join  MedicalPrescriptionDetail md on m.MedicalRecordCode=md.MedicalRecordCode
			--inner join Items i on md.ItemCode=i.ItemCode inner join Object o on o.ObjectCode=m.ObjectCode inner join UnitOfMeasure un on un.UnitOfMeasureCode=i.UnitOfMeasureCode
			--inner join ItemCategory ic on i.ItemCategoryCode=ic.ItemCategoryCode inner join ItemGroup ig on ig.GroupCode=ic.GroupCode
			--where  m.Paid = 0 and (md.Quantity*md.UnitPrice) >0 and m.PatientReceiveID = @BanksAccountCode
		end
end
GO
if exists(select name from sysobjects where name ='proView_ChiTietBenhNhanDV')
	drop procedure proView_ChiTietBenhNhanDV
go
create procedure proView_ChiTietBenhNhanDV
(
	@FromDate varchar(15),
	@ToDate varchar(15),
	@PatientCode varchar(15),
	@PatientReceiveID int
)
as
begin
	--Cong kham
		select b2.ServiceGroupName,b1.ServiceCategoryName,b.ServiceName,un.UnitOfMeasureName,a.Quantity,a.ServicePrice,a.DisparityPrice,
		(case a.Paid when 0 then N'Chưa thu' else N'Đã thu' end) paid,
		em.EmployeeName EmployeeNameCD,em1.EmployeeName EmployeeNameDoctorCD ,convert(char(16),a.CreateDate,120)  CreateDateCD, a.ShiftWork ShiftWorkCD, em2.EmployeeName EmployeeNameTH,a2.EmployeeName EmployeeNameDoctorTH 
		, convert(char(16),a1.PostingDate,120) PostingDateTH,a1.ShiftWork ShiftWorkTH
		,dc.DepartmentName,dc1.DepartmentName as DepartmentNameOrder
		, oj.ObjectName,f.BanksAccountCode,convert(char(16),d.CreateDate,120) DateIn
		from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode 
		inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b.ServiceGroupCode=b2.ServiceGroupCode
		inner join MedicalRecord a1 on a.ReceiptID=a1.ReceiptID
		left join Employee a2 on a1.EmployeeCodeDoctor=a2.EmployeeCode
		inner join PatientReceive d on a.RefID=d.PatientReceiveID left join Catalog_Ward d1 on d.WardCode=d1.WardCode left join Catalog_District d2 on d.DistrictCode=d2.DistrictCode left join Catalog_Provincial d3 on d.ProvincialCode=d3.ProvincialCode
		inner join Patients e on d.PatientCode=e.PatientCode left join BanksAccount f on a.BanksAccountCode=f.BanksAccountCode 
		inner join Department dc on	dc.DepartmentCode=a1.DepartmentCode left join Department dc1 on a.DepartmentCodeOrder = dc1.DepartmentCode inner join Object oj on a.ObjectCode=oj.ObjectCode
		inner join UnitOfMeasure un on un.UnitOfMeasureCode=b.UnitOfMeasureCode 
		inner join Employee em on em.EmployeeCode=a.EmployeeCode
		left join Employee em1 on em1.EmployeeCode=a.EmployeeCodeDoctor
		inner join Employee em2 on em2.EmployeeCode=a1.EmployeeCode
		where e.PatientCode = @PatientCode and d.PatientReceiveID = @PatientReceiveID 
		and CONVERT(date,a.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) 
		union 
		-- CDHA
		select b2.ServiceGroupName,b1.ServiceCategoryName,b.ServiceName,un.UnitOfMeasureName,a.Quantity,a.ServicePrice,a.DisparityPrice,
		(case a.Paid when 0 then N'Chưa thu' else N'Đã thu' end) paid,
		em.EmployeeName EmployeeNameCD,em1.EmployeeName EmployeeNameDoctorCD ,convert(char(16),a.CreateDate,120) CreateDateCD, a.ShiftWork ShiftWorkCD, em2.EmployeeName EmployeeNameTH, c1.EmployeeName EmployeeNameDoctorTH,
		convert(char(16),c.PostingDate,120) PostingDateTH,c.ShiftWork ShiftWorkTH,
		dc.DepartmentName,dc1.DepartmentName as DepartmentNameOrder
		, oj.ObjectName,f.BanksAccountCode,convert(char(16),d.CreateDate,120) DateIn
		from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode 
		inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b.ServiceGroupCode=b2.ServiceGroupCode
		inner join ServiceRadiologyEntry c on a.ReceiptID=c.SuggestedID
		inner join Employee c1 on c.EmployeeCodeDoctor=c1.EmployeeCode
		inner join PatientReceive d on a.RefID=d.PatientReceiveID left join Catalog_Ward d1 on d.WardCode=d1.WardCode left join Catalog_District d2 on d.DistrictCode=d2.DistrictCode left join Catalog_Provincial d3 on d.ProvincialCode=d3.ProvincialCode
		inner join Patients e on d.PatientCode=e.PatientCode left join BanksAccount f on a.BanksAccountCode=f.BanksAccountCode
		inner join Department dc on	dc.DepartmentCode=a.DepartmentCode left join Department dc1 on a.DepartmentCodeOrder = dc1.DepartmentCode inner join Object oj on a.ObjectCode=oj.ObjectCode
		inner join UnitOfMeasure un on un.UnitOfMeasureCode=b.UnitOfMeasureCode 
		inner join Employee em on em.EmployeeCode=a.EmployeeCode
		left join Employee em1 on em1.EmployeeCode=a.EmployeeCodeDoctor
		inner join Employee em2 on em2.EmployeeCode=c.EmployeeCode
		where e.PatientCode = @PatientCode and d.PatientReceiveID = @PatientReceiveID 
		and CONVERT(date,a.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) 
		union 
		--XN
		select distinct b2.ServiceGroupName,b1.ServiceCategoryName, b.ServiceName,un.UnitOfMeasureName,a.Quantity,a.ServicePrice,a.DisparityPrice,
		(case a.Paid when 0 then N'Chưa thu' else N'Đã thu' end) paid,
		em.EmployeeName EmployeeNameCD,em1.EmployeeName EmployeeNameDoctorCD ,convert(char(16),a.CreateDate,120) CreateDateCD, a.ShiftWork ShiftWorkCD, em2.EmployeeName EmployeeNameTH, c2.EmployeeName EmployeeNameDoctorTH,
		convert(char(16),c.PostingDate,120) PostingDateTH,c.ShiftWork ShiftWorkTH,
		dc.DepartmentName,dc1.DepartmentName as DepartmentNameOrder,
		oj.ObjectName,f.BanksAccountCode,convert(char(16),d.CreateDate,120) DateIn
		from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode 
		inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b.ServiceGroupCode=b2.ServiceGroupCode
		inner join ServiceLaboratoryEntry c inner join ServiceLaboratoryDetail c1 on c.RowID = c1.RowIDLaboratoryEnTry on a.ReceiptID=c1.SuggestedID 
		inner join Employee c2 on c.EmployeeCode=c2.EmployeeCode
		inner join PatientReceive d on a.RefID=d.PatientReceiveID left join Catalog_Ward d1 on d.WardCode=d1.WardCode left join Catalog_District d2 on d.DistrictCode=d2.DistrictCode left join Catalog_Provincial d3 on d.ProvincialCode=d3.ProvincialCode
		inner join Patients e on d.PatientCode=e.PatientCode left join BanksAccount f on a.BanksAccountCode=f.BanksAccountCode
		inner join Department dc on	dc.DepartmentCode=a.DepartmentCode left join Department dc1 on a.DepartmentCodeOrder = dc1.DepartmentCode inner join Object oj on a.ObjectCode=oj.ObjectCode
		inner join UnitOfMeasure un on un.UnitOfMeasureCode=b.UnitOfMeasureCode 
		inner join Employee em on em.EmployeeCode=a.EmployeeCode
		left join Employee em1 on em1.EmployeeCode=a.EmployeeCodeDoctor
		inner join Employee em2 on em2.EmployeeCode=c.EmployeeCode
		where e.PatientCode = @PatientCode and d.PatientReceiveID = @PatientReceiveID 
		and CONVERT(date,a.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) 
		union 
		--PTTT
		select b2.ServiceGroupName,b1.ServiceCategoryName,b.ServiceName,un.UnitOfMeasureName,a.Quantity,a.ServicePrice,a.DisparityPrice,
		(case a.Paid when 0 then N'Chưa thu' else N'Đã thu' end) paid,
		em.EmployeeName EmployeeNameCD,em1.EmployeeName EmployeeNameDoctorCD ,convert(char(16),a.CreateDate,120) CreateDateCD, a.ShiftWork ShiftWorkCD, em2.EmployeeName EmployeeNameTH, c1.EmployeeName EmployeeNameDoctorTH,
		convert(char(16),c.DateOut,120) PostingDateTH,c.ShiftWork ShiftWorkTH,
		dc.DepartmentName,dc1.DepartmentName as DepartmentNameOrder
		, oj.ObjectName,f.BanksAccountCode,convert(char(16),d.CreateDate,120) DateIn
		from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode 
		inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b.ServiceGroupCode=b2.ServiceGroupCode
		inner join Surgeries c on a.ReceiptID=c.IDSuggested
		inner join Employee c1 on c.EmployeeCode=c1.EmployeeCode
		inner join PatientReceive d on a.RefID=d.PatientReceiveID left join Catalog_Ward d1 on d.WardCode=d1.WardCode left join Catalog_District d2 on d.DistrictCode=d2.DistrictCode left join Catalog_Provincial d3 on d.ProvincialCode=d3.ProvincialCode
		inner join Patients e on d.PatientCode=e.PatientCode left join BanksAccount f on a.BanksAccountCode=f.BanksAccountCode
		inner join Department dc on	dc.DepartmentCode=a.DepartmentCode left join Department dc1 on a.DepartmentCodeOrder = dc1.DepartmentCode inner join Object oj on a.ObjectCode=oj.ObjectCode
		inner join UnitOfMeasure un on un.UnitOfMeasureCode=b.UnitOfMeasureCode 
		inner join Employee em on em.EmployeeCode=a.EmployeeCode
		left join Employee em1 on em1.EmployeeCode=a.EmployeeCodeDoctor
		inner join Employee em2 on em2.EmployeeCode=c.EmployeeCode
		where e.PatientCode = @PatientCode and d.PatientReceiveID = @PatientReceiveID 
		and CONVERT(date,a.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) 
		union 
		--TC
		select b2.ServiceGroupName,b1.ServiceCategoryName,b.ServiceName,un.UnitOfMeasureName,a.Quantity,a.ServicePrice,a.DisparityPrice,
		(case a.Paid when 0 then N'Chưa thu' else N'Đã thu' end) paid,
		em.EmployeeName EmployeeNameCD,em1.EmployeeName EmployeeNameDoctorCD ,convert(char(16),a.CreateDate,120) CreateDateCD, a.ShiftWork ShiftWorkCD, em2.EmployeeName EmployeeNameTH, c1.EmployeeName EmployeeNameDoctorTH,
		convert(char(16),c.WorkDate,120) PostingDateTH,c.ShiftWork ShiftWorkTH,
		dc.DepartmentName,dc1.DepartmentName as DepartmentNameOrder
		, oj.ObjectName,f.BanksAccountCode,convert(char(16),d.CreateDate,120) DateIn
		from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode 
		inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b.ServiceGroupCode=b2.ServiceGroupCode
		inner join ImmunizationRecord c on a.ReceiptID=c.ReceiptID
		inner join Employee c1 on c.EmployeeCode=c1.EmployeeCode
		inner join PatientReceive d on a.RefID=d.PatientReceiveID left join Catalog_Ward d1 on d.WardCode=d1.WardCode left join Catalog_District d2 on d.DistrictCode=d2.DistrictCode left join Catalog_Provincial d3 on d.ProvincialCode=d3.ProvincialCode
		inner join Patients e on d.PatientCode=e.PatientCode left join BanksAccount f on a.BanksAccountCode=f.BanksAccountCode
		inner join Department dc on	dc.DepartmentCode=a.DepartmentCode left join Department dc1 on a.DepartmentCodeOrder = dc1.DepartmentCode inner join Object oj on a.ObjectCode=oj.ObjectCode
		inner join UnitOfMeasure un on un.UnitOfMeasureCode=b.UnitOfMeasureCode 
		inner join Employee em on em.EmployeeCode=a.EmployeeCode
		left join Employee em1 on em1.EmployeeCode=a.EmployeeCodeDoctor
		inner join Employee em2 on em2.EmployeeCode=c.EmployeeCode
		where e.PatientCode = @PatientCode and d.PatientReceiveID = @PatientReceiveID 
		and CONVERT(date,a.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) 
end
go
if exists(select name from sysobjects where name ='proView_ChiTietBenhNhanTH')
	drop procedure proView_ChiTietBenhNhanTH
go
create procedure proView_ChiTietBenhNhanTH
(
	@FromDate varchar(15),
	@ToDate varchar(15),
	@PatientCode varchar(15),
	@PatientReceiveID int
)
as
begin
	select c.ItemName, f.UnitOfMeasureName, b.Quantity, b.UnitPrice, b.Amount, g.RepositoryName, a1.EmployeeName EmployeeNameDuyet, convert(char(16),a.DateApproved,120) DateApproved, a2.EmployeeName EmployeeCodeDoctor,
	convert(char(16),d.PostingDate,120) PostingDate, a3.EmployeeName EmployeeNameNhap
	from MedicinesForPatients a inner join MedicinesForPatientsDetail b on a.MedicalRecordCode=b.MedicalRecordCode
	left join MedicalRecord d on d.MedicalRecordCode=a.MedicalRecordCode
	inner join MedicalPrescriptionDetail e on e.MedicalRecordCode=d.MedicalRecordCode
	inner join Items c on c.ItemCode=e.ItemCode inner join UnitOfMeasure f on c.UnitOfMeasureCode=f.UnitOfMeasureCode
	inner join RepositoryCatalog g on g.RepositoryCode=b.RepositoryCode inner join Employee a1 on a.EmployeeCode = a1.EmployeeCode
	inner join Employee a2 on a2.EmployeeCode=d.EmployeeCodeDoctor inner join Employee a3 on a3.EmployeeCode=d.EmployeeCode
	where a.PatientCode = @PatientCode and a.PatientReceiveID=@PatientReceiveID and d.Status = 1
	union all
	select  c.ItemName, f.UnitOfMeasureName, e.Quantity, e.UnitPrice, e.Amount, g.RepositoryName, '' EmployeeNameDuyet, '' DateApproved, a2.EmployeeName EmployeeCodeDoctor,
	convert(char(16),d.PostingDate,120) PostingDate, a3.EmployeeName EmployeeNameNhap
	from MedicalRecord d 
	inner join MedicalPrescriptionDetail e on e.MedicalRecordCode=d.MedicalRecordCode
	inner join Items c on c.ItemCode=e.ItemCode inner join UnitOfMeasure f on c.UnitOfMeasureCode=f.UnitOfMeasureCode
	inner join RepositoryCatalog g on g.RepositoryCode=e.RepositoryCode inner join Employee a1 on d.EmployeeCode = a1.EmployeeCode
	inner join Employee a2 on a2.EmployeeCode=d.EmployeeCodeDoctor inner join Employee a3 on a3.EmployeeCode=d.EmployeeCode
	where d.PatientCode = @PatientCode and d.PatientReceiveID=@PatientReceiveID and d.Status = 0
end
go
if exists(select name from sysobjects where name='proView_ListServiceLabAppointment')
	drop procedure proView_ListServiceLabAppointment
go
create procedure proView_ListServiceLabAppointment
(
	@PatientReceiveID decimal(18,0),
	@Status int,
	@SampleTransfer int,
	@ServiceCategoryCode varchar(15)
)
as
	select b.ServiceName,a.ServiceCode,a.SampleTransfer,a.ReceiptID,(case a.Status when 0 then N'Chưa Thực Hiện' when 1 then N'Thực Hiện' when 2 then N'Lấy Mẫu' else '' end) Status,a.StatusAppointment as Chon
	from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b1.ServiceGroupCode=b2.ServiceGroupCode
	where b1.ServiceCategoryCode=@ServiceCategoryCode and RefID=@PatientReceiveID 
	and a.Status =(case @Status when -1 then a.Status else @Status end) 
	and a.SampleTransfer =(case @SampleTransfer when -1 then a.SampleTransfer else @SampleTransfer end)
go
if exists(select name from sysobjects where name ='proLabForPatientAppointment')
	drop procedure proLabForPatientAppointment
go
create procedure proLabForPatientAppointment
(
	@PatientReceiveId numeric(18,0),
	@PatientCode varchar(50),
	@ServiceModuleCode varchar(15)
)
as
begin
	select b1.ServiceCategoryCode,b1.ServiceCategoryName
	from SuggestedServiceReceipt a inner join [Service] b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode inner join ServiceGroup b2 on b1.ServiceGroupCode=b2.ServiceGroupCode
	where a.PatientCode=@PatientCode and a.RefID=@PatientReceiveId and b2.ServiceModuleCode=@ServiceModuleCode
	group by b1.ServiceCategoryCode,b1.ServiceCategoryName
end
go
if exists(select name from sysobjects where name='proReport_ListServiceLabAppointment')
	drop procedure proReport_ListServiceLabAppointment
go
create procedure proReport_ListServiceLabAppointment
(
	@PatientReceiveID decimal(18,0),
	@ServiceCategoryCode varchar(15)
)
as
	select c.PatientCode,UPPER(c.PatientName) PatientName,c.PatientBirthyear,a.SampleDate,a.AppointmentDate,a.AppointmentContent,a.AppointmentCode 
	from LabAppointmentForResults a inner join PatientReceive b on a.PatientReceiveID=b.PatientReceiveID inner join Patients c on b.PatientCode=c.PatientCode
	where a.PatientReceiveID=@PatientReceiveID and a.ServiceCategoryCode=@ServiceCategoryCode
go
if exists(select name from sysobjects where name ='proWaitingForPayMent')
	drop procedure proWaitingForPayMent
go
create procedure proWaitingForPayMent
(
	@DateFrom char(10),
	@DateTo char(10)
)
as
begin
	select b.PatientReceiveID,b.PatientCode,a.PatientName,(case when a.PatientGender=0 then N'Nữ' else 'Nam' end) GenderName,a.PatientBirthyear,c.ObjectName,b.CreateDate
	from Patients a inner join (
	select a.PatientReceiveID,a.PatientCode,a.ObjectCode,convert(Date,a.CreateDate,103) CreateDate
	from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID 
	where b.Paid=0 and (b.BanksAccountCode is null or b.BanksAccountCode='') and b.ServicePrice>0 and b.ObjectCode <>5 and CONVERT(date,a.CreateDate,103) between CONVERT(date,@DateFrom,103) and  CONVERT(date,@DateTo,103)
	group by a.PatientReceiveID,a.PatientCode,a.ObjectCode,convert(Date,a.CreateDate,103)) b on a.PatientCode=b.PatientCode inner join Object c on b.ObjectCode=c.ObjectCode
	
	union
	select b.PatientReceiveID,b.PatientCode,a.PatientName,(case when a.PatientGender=0 then N'Nữ' else 'Nam' end) GenderName,a.PatientBirthyear,c.ObjectName,b.CreateDate
	from Patients a inner join (
	select a.PatientReceiveID,a.PatientCode,a.ObjectCode,convert(Date,a.CreateDate,103) CreateDate
	from PatientReceive a inner join RealMedicinesForPatients b on a.PatientReceiveID=b.PatientReceiveID inner join RealMedicinesForPatientsDetail b1 on b.RowID=b1.RealRowID
	where b1.Paid=0 and (b1.BanksAccountCode is null or b1.BanksAccountCode='' ) and b1.ObjectCode <>5 and CONVERT(date,a.CreateDate,103) between CONVERT(date,@DateFrom,103) and  CONVERT(date,@DateTo,103)
	group by a.PatientReceiveID,a.PatientCode,a.ObjectCode,convert(Date,a.CreateDate,103)) b on a.PatientCode=b.PatientCode inner join Object c on b.ObjectCode=c.ObjectCode
	
	union
	select b.PatientReceiveID,b.PatientCode,a.PatientName,(case when a.PatientGender=0 then N'Nữ' else 'Nam' end) GenderName,a.PatientBirthyear,c.ObjectName,b.CreateDate
	from Patients a inner join (
	select a.PatientReceiveID,a.PatientCode,a.ObjectCode,convert(Date,a.CreateDate,103) CreateDate
	from PatientReceive a inner join MedicinesForPatients b on a.PatientReceiveID=b.PatientReceiveID inner join MedicinesForPatientsDetail b1 on b.RowID=b1.RowIDMedicines
	where b1.Paid=0 and (b1.BanksAccountCode is null or b1.BanksAccountCode='') and b1.ObjectCode <>5 and CONVERT(date,a.CreateDate,103) between CONVERT(date,@DateFrom,103) and  CONVERT(date,@DateTo,103)
	group by a.PatientReceiveID,a.PatientCode,a.ObjectCode,convert(Date,a.CreateDate,103)) b on a.PatientCode=b.PatientCode inner join Object c on b.ObjectCode=c.ObjectCode
	
end
go

/*
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Report_ImpExp]') AND type in (N'U'))
CREATE TABLE Report_ImpExp
(
	ItemCode varchar(10) NOT NULL,
	RepositoryCode varchar(10) NOT NULL,
	AmountBegin numeric(18, 3) NOT NULL DEFAULT ((0)),
	AmountImport numeric(18, 3) NOT NULL DEFAULT ((0)),
	AmountExport numeric(18, 3) NOT NULL DEFAULT ((0)),
	AmountRepaid numeric(18, 3) NOT NULL DEFAULT ((0)),
	AmountRepaidVen numeric(18, 3) NOT NULL DEFAULT ((0)),
	AmountEnd numeric(18, 3) NOT NULL DEFAULT ((0)),
	SalesPrice numeric(18, 3) NOT NULL DEFAULT ((0)),
	UnitPrice numeric(18, 3) NOT NULL DEFAULT ((0)),
	BHYTPrice numeric(18, 3) NOT NULL DEFAULT ((0)),
	RowNumber int NOT NULL DEFAULT ((1)),
	DateEnd date,
)
go
*/

if exists(select name from sysobjects where name='proView_ListMedicalRecord_ANC')
	drop procedure proView_ListMedicalRecord_ANC
go
create procedure proView_ListMedicalRecord_ANC
(
	@FromDate char(10),
	@ToDate char(10)
)
as
	begin
	select ROW_NUMBER() OVER(ORDER BY CONVERT(date,a.iDate,103) DESC) as STT, d.PatientName,CONVERT(date,a.iDate,103)iDate,d.PatientAge, '' BHYT, 
	[dbo].func_PatientOfAddressFull(d.PatientAddress,b1.WardName,c1.DistrictName,d1.ProvincialName) PatientAddress, f.CareerName ,e.EThnicName,
	a.TienSuSinhDe,a.NgayKinhCuoiCung,a.TuanThai,a.NgaySinhDuKien,a.LanCoThai,a.TrongLuongMe,a.ChieuCaoMe,a.HuyetAp+'/'+ a.HuyetAp1 as HuyetAp,
	a.ChieuCaoTC,a.VongBung,a.KhungChau,a.ThieuMau,a.Protein,a.XNHIV,a.XNKhac,a.TienLuongDe,a.SoMuiTiem,(case when a.UongVien = 1 then N'Có' else N'Không'end) UongVien,a.TimThai,a.NgoiThai ,a1.EmployeeName,a.GhiChu
	from MedicalRecord_ANC a inner join MedicalRecord b on a.MedicalRecordCode=b.MedicalRecordCode inner join PatientReceive c on b.PatientReceiveID=c.PatientReceiveID
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
	inner join Catalog_EThnic e on e.EThnicID=c.EThnicID inner join Career f on d.CareerCode=f.CareerCode inner join Employee a1 on a1.EmployeeCode=a.EmployeeCode
	where CONVERT(date,a.WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103)
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
------02/08/2016, Update bao cao nxt
if not exists(select name from sys.columns where Name = N'AmountKhaiTonPre' and Object_ID = Object_ID(N'report_NXT_TH'))
	alter table report_NXT_TH add AmountKhaiTonPre numeric(18,3) default 0 not null
go
if not exists(select name from sys.columns where Name = N'AmountKhaiTon' and Object_ID = Object_ID(N'report_NXT_TH'))
	alter table report_NXT_TH add AmountKhaiTon numeric(18,3) default 0 not null
go
if not exists(select name from sys.columns where Name = N'AmountImportRepaidPre' and Object_ID = Object_ID(N'report_NXT_TH'))
	alter table report_NXT_TH add AmountImportRepaidPre numeric(18,3) default 0 not null
go
if not exists(select name from sys.columns where Name = N'AmountImportRepaid' and Object_ID = Object_ID(N'report_NXT_TH'))
	alter table report_NXT_TH add AmountImportRepaid numeric(18,3) default 0 not null
go
if not exists(select name from sys.columns where Name = N'AmountImportTransferPre' and Object_ID = Object_ID(N'report_NXT_TH'))
	alter table report_NXT_TH add AmountImportTransferPre numeric(18,3) default 0 not null
go
if not exists(select name from sys.columns where Name = N'AmountImportTransfer' and Object_ID = Object_ID(N'report_NXT_TH'))
	alter table report_NXT_TH add AmountImportTransfer numeric(18,3) default 0 not null
go
------- add feild nxt detail
if not exists(select name from sys.columns where Name = N'AmountKhaiTonPre' and Object_ID = Object_ID(N'report_NXT_CT'))
	alter table report_NXT_CT add AmountKhaiTonPre numeric(18,3) default 0 not null
go
if not exists(select name from sys.columns where Name = N'AmountKhaiTon' and Object_ID = Object_ID(N'report_NXT_CT'))
	alter table report_NXT_CT add AmountKhaiTon numeric(18,3) default 0 not null
go
if not exists(select name from sys.columns where Name = N'AmountImportRepaidPre' and Object_ID = Object_ID(N'report_NXT_CT'))
	alter table report_NXT_CT add AmountImportRepaidPre numeric(18,3) default 0 not null
go
if not exists(select name from sys.columns where Name = N'AmountImportRepaid' and Object_ID = Object_ID(N'report_NXT_CT'))
	alter table report_NXT_CT add AmountImportRepaid numeric(18,3) default 0 not null
go
if not exists(select name from sys.columns where Name = N'AmountImportTransferPre' and Object_ID = Object_ID(N'report_NXT_CT'))
	alter table report_NXT_CT add AmountImportTransferPre numeric(18,3) default 0 not null
go
if not exists(select name from sys.columns where Name = N'AmountImportTransfer' and Object_ID = Object_ID(N'report_NXT_CT'))
	alter table report_NXT_CT add AmountImportTransfer numeric(18,3) default 0 not null
go
if exists(select name from sysobjects where name ='proReport_ImpExp_General')
	drop procedure proReport_ImpExp_General
go
create procedure proReport_ImpExp_General
(
	@RepositoryCode varchar(15)='',
	@FromDate char(10),
	@ToDate char(10),
	@ItemCode varchar(15)=''
)
as
begin
	delete from report_NXT_TH
	declare @DateBegin datetime =getdate()
	if exists(select RowID from SystemParameter where RowID=208 and [Values]=1)
		set @DateBegin =(select convert(date,DateReport,103) DateForm from RepositoryCatalog where RepositoryCode=@RepositoryCode)
	else
		set @DateBegin = @FromDate
	insert into report_NXT_TH(ItemCode,RepositoryCode,AmountKhaiTonPre,AmountImportPre,AmountImportRepaidPre,AmountExportPre,AmountRepaidPre,AmountRepaidVenPre,AmountTransferPre,AmountImportTransferPre,AmountKhaiTon,AmountImport,AmountImportRepaid,AmountExport,AmountRepaid,AmountRepaidVen,AmountTransfer,AmountImportTransfer,UnitPrice,SalesPrice)
	select a.ItemCode,a.RepositoryCode,SUM(a.Amount_KhaiTonDau) AmountKhaiTonPre, SUM(a.Amount_NhapMoi) AmountImportPre, SUM(a.Amount_NhanHoanTraKho) AmountImportRepaidPre,(SUM(a.Amount_XuatBan) +SUM(a.Amount_XuatBN)) AmountExportPre,SUM(a.Amount_HTKho) AmountRepaidPre,SUM(a.Amount_HTNCC) AmountRepaidVenPre,SUM(a.Amount_XuatCK) AmountTransferPre,SUM(a.Amount_NhanCK) AmountImportTransferPre,
	SUM(a.Amount_KhaiTonDauTime) AmountKhaiTon, SUM(a.Amount_NhapMoiTime) AmountImport, SUM(a.Amount_NhanHoanTraKhoTime) AmountImportRepaid,(SUM(a.Amount_XuatBanTime) +SUM(a.Amount_XuatBNTime)) AmountExport,SUM(a.Amount_HTKhoTime) AmountRepaid,SUM(a.Amount_HTNCCTime) AmountRepaidVen,SUM(a.Amount_XuatCKTime) AmountTransfer,SUM(a.Amount_NhanCKTime) AmountImportTransfer,UnitPrice,SalesPrice
	from (
	--Lay du lieu truoc thoi gian lay bao cao
	-------- 1 Nhap moi kho, cac he thong kho khong phai kho chan
	select b.ItemCode,a.RepositoryCode, ISNULL(sum(b.Quantity),0) as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice
	 from Warehousing a inner join WarehousingDetail b on a.WarehousingCode=b.WarehousingCode 
	where a.RepositoryCode=@RepositoryCode and a.Status=1 and a.Reason<>4 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ImportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ImportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.RepositoryCode,b.UnitPrice,b.SalesPrice
	-------- 2 Khai Ton
	union all
	select b.ItemCode,a.RepositoryCode, 0 as Amount_NhapMoi, ISNULL(sum(b.Quantity),0) as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice
	from Warehousing a inner join WarehousingDetail b on a.WarehousingCode=b.WarehousingCode 
	where a.RepositoryCode=@RepositoryCode and a.Status=1 and a.Reason=4 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ImportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ImportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.RepositoryCode,b.UnitPrice,b.SalesPrice
	-------- 3 Nhan hoan tra kho
	union all
	select b.ItemCode,a.ImpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, ISNULL(sum(b.AmountRealExport),0) as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice
	from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
	where a.ImpRepositoryCode=@RepositoryCode and a.Type=2 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ExportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.ImpRepositoryCode,b.UnitPrice,b.SalesPrice
	-------- 4 Xuat ban le 
	union all
	select b.ItemCode,b.RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, ISNULL(sum(b.QuantityExport),0) as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,c.UnitPrice,c.SalesPrice
	from MedicinesRetail a inner join MedicinesRetailDetail b on a.RetailCode=b.RetailCode inner join InventoryGumshoe c on b.RowIDInventoryGumshoe=c.RowID 
	where b.RepositoryCode=@RepositoryCode and a.Paid=1 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ExportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,b.RepositoryCode,c.UnitPrice,c.SalesPrice
	-------- 5 Xuat cho benh nhan kham benh (Duyet toa BHYT)
	union all
	select b.ItemCode,b.RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, ISNULL(sum(b.QuantityExport),0) as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,c.UnitPrice,c.SalesPrice
	from MedicinesForPatients a inner join MedicinesForPatientsDetail b on a.RowID=b.RowIDMedicines inner join InventoryGumshoe c on b.RowIDInventoryGumshoe=c.RowID 
	where b.RepositoryCode=@RepositoryCode and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.DateApproved,103) >= convert(date,@DateBegin,103) and convert(date,a.DateApproved,103)<convert(date,@FromDate,103)
	group by b.ItemCode,b.RepositoryCode,c.UnitPrice,c.SalesPrice
	-------- 6 Xuat chuyen kho
	union all
	select b.ItemCode,a.ExpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, ISNULL(sum(b.AmountRealExport),0) as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice
	from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
	where a.ExpRepositoryCode=@RepositoryCode and a.Type=1 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ExportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.ExpRepositoryCode,b.UnitPrice,b.SalesPrice
	-------- 7 Hoan tra kho
	union all
	select b.ItemCode,a.ExpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,ISNULL(sum(b.AmountRealExport),0) as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice
	from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
	where a.ExpRepositoryCode=@RepositoryCode and a.Type=2 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ExportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.ExpRepositoryCode,b.UnitPrice,b.SalesPrice
	-------- 8 Nhan chuyen kho, nhan hoan tra kho
	union all
	select b.ItemCode,a.ImpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,ISNULL(sum(b.AmountRealExport),0) as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice
	from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
	where a.ImpRepositoryCode=@RepositoryCode and a.Type=1 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ExportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.ImpRepositoryCode,b.UnitPrice,b.SalesPrice
	-------- 9 Hoan tra nha cung cap
	union all
	select b.ItemCode,a.ExpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,ISNULL(sum(b.AmountRealExport),0) as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,c.UnitPrice,c.SalesPrice
	from ExportVendor a inner join ExportVendorDetail b on a.ExportVendorCode=b.ExportVendorCode inner join InventoryGumshoe c on b.RowIDGumshoe=c.RowID
	where Cancel=0 and a.ExpRepositoryCode=@RepositoryCode and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ExportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.ExpRepositoryCode,c.UnitPrice,c.SalesPrice
	-------- 10 Xuat thuoc tu truc cho benh nhan
	union all
	select b.ItemCode,b.RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, ISNULL(sum(b.Quantity),0) as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,c.UnitPrice,c.SalesPrice
	from RealMedicinesForPatients a inner join RealMedicinesForPatientsDetail b on a.RowID=b.RealRowID inner join InventoryGumshoe c on b.RowIDInventoryGumshoe=c.RowID 
	where b.RepositoryCode=@RepositoryCode and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.DateApproved,103) >= convert(date,@DateBegin,103) and convert(date,a.DateApproved,103)<convert(date,@FromDate,103)
	group by b.ItemCode,b.RepositoryCode,c.UnitPrice,c.SalesPrice
	--Lay du lieu trong thoi gian bao cao
	-------- 1 Nhap moi kho, cac he thong kho khong phai kho chan
	union all
	select b.ItemCode,a.RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	ISNULL(sum(b.Quantity),0) Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice
	 from Warehousing a inner join WarehousingDetail b on a.WarehousingCode=b.WarehousingCode 
	where a.RepositoryCode=@RepositoryCode and a.Status=1 and a.Reason<>4 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ImportDate,103) >= convert(date,@FromDate,103) and convert(date,a.ImportDate,103)<=convert(date,@ToDate,103)
	group by b.ItemCode,a.RepositoryCode,b.UnitPrice,b.SalesPrice
	-------- 2 Khai Ton
	union all
	select b.ItemCode,a.RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,ISNULL(sum(b.Quantity),0) as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice
	from Warehousing a inner join WarehousingDetail b on a.WarehousingCode=b.WarehousingCode 
	where a.RepositoryCode=@RepositoryCode and a.Status=1 and a.Reason=4 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ImportDate,103) >= convert(date,@FromDate,103) and convert(date,a.ImportDate,103)<=convert(date,@ToDate,103)
	group by b.ItemCode,a.RepositoryCode,b.UnitPrice,b.SalesPrice
	-------- 3 Nhan hoan tra kho
	union all
	select b.ItemCode,a.ImpRepositoryCode ImpRepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, ISNULL(sum(b.AmountRealExport),0) as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice
	from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
	where a.ImpRepositoryCode=@RepositoryCode and a.Type=2 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@FromDate,103) and convert(date,a.ExportDate,103)<=convert(date,@ToDate,103)
	group by b.ItemCode,a.ImpRepositoryCode,b.UnitPrice,b.SalesPrice
	-------- 4 Xuat ban le 
	union all
	select b.ItemCode,b.RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, ISNULL(sum(b.QuantityExport),0) as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,c.UnitPrice,c.SalesPrice
	from MedicinesRetail a inner join MedicinesRetailDetail b on a.RetailCode=b.RetailCode inner join InventoryGumshoe c on b.RowIDInventoryGumshoe=c.RowID 
	where b.RepositoryCode=@RepositoryCode and a.Paid=1 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@FromDate,103) and convert(date,a.ExportDate,103)<=convert(date,@ToDate,103)
	group by b.ItemCode,b.RepositoryCode,c.UnitPrice,c.SalesPrice
	-------- 5 Xuat cho benh nhan kham benh (Duyet toa BHYT) va xuat tu truc thuoc BN
	union all
	select b.ItemCode,b.RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, ISNULL(sum(b.QuantityExport),0) as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,c.UnitPrice,c.SalesPrice
	from MedicinesForPatients a inner join MedicinesForPatientsDetail b on a.RowID=b.RowIDMedicines inner join InventoryGumshoe c on b.RowIDInventoryGumshoe=c.RowID 
	where b.RepositoryCode=@RepositoryCode and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.DateApproved,103) >= convert(date,@FromDate,103) and convert(date,a.DateApproved,103)<=convert(date,@ToDate,103)
	group by b.ItemCode,b.RepositoryCode,c.UnitPrice,c.SalesPrice
	-------- 6 Xuat chuyen kho
	union all
	select b.ItemCode,a.ExpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, ISNULL(sum(b.AmountRealExport),0) as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice
	from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
	where a.ExpRepositoryCode=@RepositoryCode and a.Type=1 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@FromDate,103) and convert(date,a.ExportDate,103)<=convert(date,@ToDate,103)
	group by b.ItemCode,a.ExpRepositoryCode,b.UnitPrice,b.SalesPrice
	-------- 7 Hoan tra kho
	union all
	select b.ItemCode,a.ExpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,ISNULL(sum(b.AmountRealExport),0) as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice
	from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
	where a.ExpRepositoryCode=@RepositoryCode and a.Type=2 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@FromDate,103) and convert(date,a.ExportDate,103)<=convert(date,@ToDate,103)
	group by b.ItemCode,a.ExpRepositoryCode,b.UnitPrice,b.SalesPrice
	-------- 8 Nhan chuyen kho
	union all
	select b.ItemCode,a.ImpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,ISNULL(sum(b.AmountRealExport),0) as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice
	from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
	where a.ImpRepositoryCode=@RepositoryCode and a.Type=1 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@FromDate,103) and convert(date,a.ExportDate,103)<=convert(date,@ToDate,103)
	group by b.ItemCode,a.ImpRepositoryCode,b.UnitPrice,b.SalesPrice
	-------- 9 Hoan tra nha cung cap
	union all
	select b.ItemCode,a.ExpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,ISNULL(sum(b.AmountRealExport),0) as Amount_HTNCCTime,c.UnitPrice,c.SalesPrice
	from ExportVendor a inner join ExportVendorDetail b on a.ExportVendorCode=b.ExportVendorCode inner join InventoryGumshoe c on b.RowIDGumshoe=c.RowID
	where Cancel=0 and a.ExpRepositoryCode=@RepositoryCode and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@FromDate,103) and convert(date,a.ExportDate,103)<=convert(date,@ToDate,103)
	group by b.ItemCode,a.ExpRepositoryCode,c.UnitPrice,c.SalesPrice
	-------- 10 Xuat thuoc tu truc cho benh nhan
	union all
	select b.ItemCode,b.RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, ISNULL(sum(b.Quantity),0) as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,c.UnitPrice,c.SalesPrice
	from RealMedicinesForPatients a inner join RealMedicinesForPatientsDetail b on a.RowID=b.RealRowID inner join InventoryGumshoe c on b.RowIDInventoryGumshoe=c.RowID 
	where b.RepositoryCode=@RepositoryCode and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.DateApproved,103) >= convert(date,@FromDate,103) and convert(date,a.DateApproved,103)<=convert(date,@ToDate,103)
	group by b.ItemCode,b.RepositoryCode,c.UnitPrice,c.SalesPrice
	) a
	group by a.ItemCode,a.RepositoryCode,a.UnitPrice,a.SalesPrice
	update report_NXT_TH set AmountBegin=(AmountKhaiTonPre+AmountBeginPre+AmountImportPre+AmountImportRepaidPre+AmountImportTransferPre)-(AmountExportPre+AmountRepaidPre+AmountRepaidVenPre+AmountTransferPre)
	
	/* --Lay chi tiet nhap xuat ton, chuyen kho
    select a.ItemCode,a.ItemName,a1.UnitOfMeasureName,a2.ItemCategoryName,(b.AmountBegin+b.AmountKhaiTon)AmountBegin,b.AmountImport,(b.AmountImportRepaid+b.AmountImportTransfer)AmountImportTransfer,b.AmountExport,b.AmountRepaid,b.AmountRepaidVen,b.AmountTransfer,(b.AmountBegin+b.AmountKhaiTon+b.AmountImport+b.AmountImportRepaid+b.AmountImportTransfer) TotalQuantity,((b.AmountBegin+b.AmountKhaiTon+b.AmountImport+b.AmountImportRepaid+b.AmountImportTransfer)-(b.AmountExport+b.AmountRepaid+b.AmountRepaidVen+b.AmountTransfer)) AmountEnd,a3.GroupName,a.SafelyQuantity,a.QtyOfMeasure,a.Packed,'' as Note
	from Items a
	inner join report_NXT_TH b on a.ItemCode=b.ItemCode
	inner join UnitOfMeasure a1 on a.UnitOfMeasureCode=a1.UnitOfMeasureCode inner join ItemCategory a2 on a.ItemCategoryCode=a2.ItemCategoryCode
	inner join ItemGroup a3 on a2.GroupCode=a3.GroupCode
	order by a.ItemCode
	*/
	
	select a.ItemCode,a.ItemName,a1.UnitOfMeasureName,a2.ItemCategoryName,sum(b.AmountBegin+b.AmountKhaiTon) as ToalQtyBegin,
	sum((b.AmountBegin+b.AmountKhaiTon)*b.UnitPrice) as TotalAmountBegin
	,sum(b.AmountImport) as QtyImport,sum(b.AmountImport *b.UnitPrice) as AmountImport
	,sum(b.AmountImportRepaid+b.AmountImportTransfer) as QtyImpTransfer,sum((b.AmountImportRepaid+b.AmountImportTransfer) * b.UnitPrice) as AmountImportTransfer
	,sum(b.AmountExport) as QtyExport, sum(b.AmountExport*b.UnitPrice) AmountExport,sum(b.AmountRepaid) as QtyRepaid,sum(b.AmountRepaid*b.UnitPrice) as AmountRepaid
	,sum(b.AmountRepaidVen) as QtyRepaidVen,sum(b.AmountRepaidVen*b.UnitPrice) as AmountRepaidVen,sum(b.AmountTransfer) as QtyTransfer,sum(b.AmountTransfer*b.UnitPrice) as AmountTransfer
	,sum(b.AmountBegin+b.AmountKhaiTon+b.AmountImport+b.AmountImportRepaid+b.AmountImportTransfer) as TotalQuantity,sum((b.AmountBegin+b.AmountKhaiTon+b.AmountImport+b.AmountImportRepaid+b.AmountImportTransfer) * b.UnitPrice) as TotalAmount
	,sum((b.AmountBegin+b.AmountKhaiTon+b.AmountImport+b.AmountImportRepaid+b.AmountImportTransfer)-(b.AmountExport+b.AmountRepaid+b.AmountRepaidVen+b.AmountTransfer)) as TotalQuantityEnd,sum(((b.AmountBegin+b.AmountKhaiTon+b.AmountImport+b.AmountImportRepaid+b.AmountImportTransfer)-(b.AmountExport+b.AmountRepaid+b.AmountRepaidVen+b.AmountTransfer))*b.UnitPrice) as TotalAmountEnd
	,sum(b.AmountImport+b.AmountImportRepaid+b.AmountImportTransfer) as TotalQuantityImport,sum((b.AmountImport+b.AmountImportRepaid+b.AmountImportTransfer) * b.UnitPrice) as TotalAmountImport
	,sum(b.AmountExport+b.AmountRepaid+b.AmountRepaidVen+b.AmountTransfer) as TotalQuantityExport,sum((b.AmountExport+b.AmountRepaid+b.AmountRepaidVen+b.AmountTransfer) * b.UnitPrice) as TotalAmountExport
	,a3.GroupName,a.SafelyQuantity,a.QtyOfMeasure,a.Packed,'' as Note,a.Generic_BD,a.VendorCode,a.ATCCode,a.SalesPrice,a4.CountryName,a.VENCode,a.Active
	from Items a
	inner join report_NXT_TH b on a.ItemCode=b.ItemCode
	inner join UnitOfMeasure a1 on a.UnitOfMeasureCode=a1.UnitOfMeasureCode inner join ItemCategory a2 on a.ItemCategoryCode=a2.ItemCategoryCode
	inner join ItemGroup a3 on a2.GroupCode=a3.GroupCode inner join Country a4 on a.CountryCode=a4.CountryCode
	group by a.ItemCode,a.ItemName,a1.UnitOfMeasureName,a2.ItemCategoryName,a3.GroupName,a.SafelyQuantity,a.QtyOfMeasure,a.Packed,a.Generic_BD,a.VendorCode,a.ATCCode,a.SalesPrice,a4.CountryName,a.VENCode,a.Active
	order by a.ItemCode
end
go
if exists(select name from sysobjects where name ='proReport_ImpExp_GeneralDetail')
	drop procedure proReport_ImpExp_GeneralDetail
go
create procedure proReport_ImpExp_GeneralDetail
(
	@RepositoryCode varchar(15)='',
	@FromDate char(10),
	@ToDate char(10),
	@ItemCode varchar(15)=''
)
as
begin
	delete from report_NXT_CT
	declare @DateBegin datetime =getdate()
	if exists(select RowID from SystemParameter where RowID=208 and [Values]=1)
		set @DateBegin =(select convert(date,DateReport,103) DateForm from RepositoryCatalog where RepositoryCode=@RepositoryCode)
	else
		set @DateBegin = @FromDate
	insert into report_NXT_CT(ItemCode,RepositoryCode,AmountKhaiTonPre,AmountImportPre,AmountImportRepaidPre,AmountExportPre,AmountRepaidPre,AmountRepaidVenPre,AmountTransferPre,AmountImportTransferPre,AmountKhaiTon,AmountImport,AmountImportRepaid,AmountExport,AmountRepaid,AmountRepaidVen,AmountTransfer,AmountImportTransfer,UnitPrice,SalesPrice,DateEnd,Shipment,RowIDGumshoe)
	select a.ItemCode,a.RepositoryCode,SUM(a.Amount_KhaiTonDau) AmountKhaiTonPre, SUM(a.Amount_NhapMoi) AmountImportPre, SUM(a.Amount_NhanHoanTraKho) AmountImportRepaidPre,(SUM(a.Amount_XuatBan) +SUM(a.Amount_XuatBN)) AmountExportPre,SUM(a.Amount_HTKho) AmountRepaidPre,SUM(a.Amount_HTNCC) AmountRepaidVenPre,SUM(a.Amount_XuatCK) AmountTransferPre,SUM(a.Amount_NhanCK) AmountImportTransferPre,
	SUM(a.Amount_KhaiTonDauTime) AmountKhaiTon, SUM(a.Amount_NhapMoiTime) AmountImport, SUM(a.Amount_NhanHoanTraKhoTime) AmountImportRepaid,(SUM(a.Amount_XuatBanTime) +SUM(a.Amount_XuatBNTime)) AmountExport,SUM(a.Amount_HTKhoTime) AmountRepaid,SUM(a.Amount_HTNCCTime) AmountRepaidVen,SUM(a.Amount_XuatCKTime) AmountTransfer,SUM(a.Amount_NhanCKTime) AmountImportTransfer,a.UnitPrice,a.SalesPrice,a.DateEnd,a.Shipment,-1
	from (
	--Lay du lieu truoc thoi gian lay bao cao
	-------- 1 Nhap moi kho, cac he thong kho khong phai kho chan
	select b.ItemCode,a.RepositoryCode, ISNULL(sum(b.Quantity),0) as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	 from Warehousing a inner join WarehousingDetail b on a.WarehousingCode=b.WarehousingCode 
	where a.RepositoryCode=@RepositoryCode and a.Status=1 and a.Reason<>4 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ImportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ImportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.RepositoryCode,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	-------- 2 Khai Ton
	union all
	select b.ItemCode,a.RepositoryCode, 0 as Amount_NhapMoi, ISNULL(sum(b.Quantity),0) as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	from Warehousing a inner join WarehousingDetail b on a.WarehousingCode=b.WarehousingCode 
	where a.RepositoryCode=@RepositoryCode and a.Status=1 and a.Reason=4 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ImportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ImportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.RepositoryCode,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	-------- 3 Nhan hoan tra kho
	union all
	select b.ItemCode,a.ImpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, ISNULL(sum(b.AmountRealExport),0) as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
	where a.ImpRepositoryCode=@RepositoryCode and a.Type=2 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ExportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.ImpRepositoryCode,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	-------- 4 Xuat ban le 
	union all
	select b.ItemCode,b.RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, ISNULL(sum(b.QuantityExport),0) as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,c.UnitPrice,c.SalesPrice,c.DateEnd,c.Shipment
	from MedicinesRetail a inner join MedicinesRetailDetail b on a.RetailCode=b.RetailCode inner join InventoryGumshoe c on b.RowIDInventoryGumshoe=c.RowID 
	where b.RepositoryCode=@RepositoryCode and a.Paid=1 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ExportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,b.RepositoryCode,c.UnitPrice,c.SalesPrice,c.DateEnd,c.Shipment
	-------- 5 Xuat cho benh nhan kham benh (Duyet toa BHYT)
	union all
	select b.ItemCode,b.RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, ISNULL(sum(b.QuantityExport),0) as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,c.UnitPrice,c.SalesPrice,c.DateEnd,c.Shipment
	from MedicinesForPatients a inner join MedicinesForPatientsDetail b on a.RowID=b.RowIDMedicines inner join InventoryGumshoe c on b.RowIDInventoryGumshoe=c.RowID 
	where b.RepositoryCode=@RepositoryCode and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.DateApproved,103) >= convert(date,@DateBegin,103) and convert(date,a.DateApproved,103)<convert(date,@FromDate,103)
	group by b.ItemCode,b.RepositoryCode,c.UnitPrice,c.SalesPrice,c.DateEnd,c.Shipment
	-------- 6 Xuat chuyen kho
	union all
	select b.ItemCode,a.ExpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, ISNULL(sum(b.AmountRealExport),0) as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
	where a.ExpRepositoryCode=@RepositoryCode and a.Type=1 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ExportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.ExpRepositoryCode,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	-------- 7 Hoan tra kho
	union all
	select b.ItemCode,a.ExpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,ISNULL(sum(b.AmountRealExport),0) as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
	where a.ExpRepositoryCode=@RepositoryCode and a.Type=2 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ExportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.ExpRepositoryCode,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	-------- 8 Nhan chuyen kho, nhan hoan tra kho
	union all
	select b.ItemCode,a.ImpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,ISNULL(sum(b.AmountRealExport),0) as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
	where a.ImpRepositoryCode=@RepositoryCode and a.Type=1 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ExportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.ImpRepositoryCode,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	-------- 9 Hoan tra nha cung cap
	union all
	select b.ItemCode,a.ExpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,ISNULL(sum(b.AmountRealExport),0) as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,c.UnitPrice,c.SalesPrice,c.DateEnd,c.Shipment
	from ExportVendor a inner join ExportVendorDetail b on a.ExportVendorCode=b.ExportVendorCode inner join InventoryGumshoe c on b.RowIDGumshoe=c.RowID
	where Cancel=0 and a.ExpRepositoryCode=@RepositoryCode and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@DateBegin,103) and convert(date,a.ExportDate,103)<convert(date,@FromDate,103)
	group by b.ItemCode,a.ExpRepositoryCode,c.UnitPrice,c.SalesPrice,c.DateEnd,c.Shipment
	-------- 10 Xuat thuoc tu truc cho benh nhan
	union all
	select b.ItemCode,b.RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, ISNULL(sum(b.Quantity),0) as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,c.UnitPrice,c.SalesPrice,c.DateEnd,c.Shipment
	from RealMedicinesForPatients a inner join RealMedicinesForPatientsDetail b on a.RowID=b.RealRowID inner join InventoryGumshoe c on b.RowIDInventoryGumshoe=c.RowID 
	where b.RepositoryCode=@RepositoryCode and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.DateApproved,103) >= convert(date,@DateBegin,103) and convert(date,a.DateApproved,103)<convert(date,@FromDate,103)
	group by b.ItemCode,b.RepositoryCode,c.UnitPrice,c.SalesPrice,c.DateEnd,c.Shipment
	--Lay du lieu trong thoi gian bao cao
	-------- 1 Nhap moi kho, cac he thong kho khong phai kho chan
	union all
	select b.ItemCode,a.RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	ISNULL(sum(b.Quantity),0) Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	 from Warehousing a inner join WarehousingDetail b on a.WarehousingCode=b.WarehousingCode 
	where a.RepositoryCode=@RepositoryCode and a.Status=1 and a.Reason<>4 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ImportDate,103) >= convert(date,@FromDate,103) and convert(date,a.ImportDate,103)<=convert(date,@ToDate,103)
	group by b.ItemCode,a.RepositoryCode,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	-------- 2 Khai Ton
	union all
	select b.ItemCode,a.RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,ISNULL(sum(b.Quantity),0) as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	from Warehousing a inner join WarehousingDetail b on a.WarehousingCode=b.WarehousingCode 
	where a.RepositoryCode=@RepositoryCode and a.Status=1 and a.Reason=4 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ImportDate,103) >= convert(date,@FromDate,103) and convert(date,a.ImportDate,103)<=convert(date,@ToDate,103)
	group by b.ItemCode,a.RepositoryCode,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	-------- 3 Nhan hoan tra kho
	union all
	select b.ItemCode,a.ImpRepositoryCode ImpRepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, ISNULL(sum(b.AmountRealExport),0) as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
	where a.ImpRepositoryCode=@RepositoryCode and a.Type=2 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@FromDate,103) and convert(date,a.ExportDate,103)<=convert(date,@ToDate,103)
	group by b.ItemCode,a.ImpRepositoryCode,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	-------- 4 Xuat ban le 
	union all
	select b.ItemCode,b.RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, ISNULL(sum(b.QuantityExport),0) as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,c.UnitPrice,c.SalesPrice,c.DateEnd,c.Shipment
	from MedicinesRetail a inner join MedicinesRetailDetail b on a.RetailCode=b.RetailCode inner join InventoryGumshoe c on b.RowIDInventoryGumshoe=c.RowID 
	where b.RepositoryCode=@RepositoryCode and a.Paid=1 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@FromDate,103) and convert(date,a.ExportDate,103)<=convert(date,@ToDate,103)
	group by b.ItemCode,b.RepositoryCode,c.UnitPrice,c.SalesPrice,c.DateEnd,c.Shipment
	-------- 5 Xuat cho benh nhan kham benh (Duyet toa BHYT) va xuat tu truc thuoc BN
	union all
	select b.ItemCode,b.RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, ISNULL(sum(b.QuantityExport),0) as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,c.UnitPrice,c.SalesPrice,c.DateEnd,c.Shipment
	from MedicinesForPatients a inner join MedicinesForPatientsDetail b on a.RowID=b.RowIDMedicines inner join InventoryGumshoe c on b.RowIDInventoryGumshoe=c.RowID 
	where b.RepositoryCode=@RepositoryCode and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.DateApproved,103) >= convert(date,@FromDate,103) and convert(date,a.DateApproved,103)<=convert(date,@ToDate,103)
	group by b.ItemCode,b.RepositoryCode,c.UnitPrice,c.SalesPrice,c.DateEnd,c.Shipment
	-------- 6 Xuat chuyen kho
	union all
	select b.ItemCode,a.ExpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, ISNULL(sum(b.AmountRealExport),0) as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
	where a.ExpRepositoryCode=@RepositoryCode and a.Type=1 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@FromDate,103) and convert(date,a.ExportDate,103)<=convert(date,@ToDate,103)
	group by b.ItemCode,a.ExpRepositoryCode,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	-------- 7 Hoan tra kho
	union all
	select b.ItemCode,a.ExpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,ISNULL(sum(b.AmountRealExport),0) as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
	where a.ExpRepositoryCode=@RepositoryCode and a.Type=2 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@FromDate,103) and convert(date,a.ExportDate,103)<=convert(date,@ToDate,103)
	group by b.ItemCode,a.ExpRepositoryCode,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	-------- 8 Nhan chuyen kho
	union all
	select b.ItemCode,a.ImpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,ISNULL(sum(b.AmountRealExport),0) as Amount_NhanCKTime,0 as Amount_HTNCCTime,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	from ExportWarehousing a inner join ExportWarehousingDetail b on a.ExpWarehousingCode=b.ExpWarehousingCode 
	where a.ImpRepositoryCode=@RepositoryCode and a.Type=1 and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@FromDate,103) and convert(date,a.ExportDate,103)<=convert(date,@ToDate,103)
	group by b.ItemCode,a.ImpRepositoryCode,b.UnitPrice,b.SalesPrice,b.DateEnd,b.Shipment
	-------- 9 Hoan tra nha cung cap
	union all
	select b.ItemCode,a.ExpRepositoryCode RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, 0 as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,ISNULL(sum(b.AmountRealExport),0) as Amount_HTNCCTime,c.UnitPrice,c.SalesPrice,c.DateEnd,c.Shipment
	from ExportVendor a inner join ExportVendorDetail b on a.ExportVendorCode=b.ExportVendorCode inner join InventoryGumshoe c on b.RowIDGumshoe=c.RowID
	where Cancel=0 and a.ExpRepositoryCode=@RepositoryCode and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.ExportDate,103) >= convert(date,@FromDate,103) and convert(date,a.ExportDate,103)<=convert(date,@ToDate,103)
	group by b.ItemCode,a.ExpRepositoryCode,c.UnitPrice,c.SalesPrice,c.DateEnd,c.Shipment
	-------- 10 Xuat thuoc tu truc cho benh nhan
	union all
	select b.ItemCode,b.RepositoryCode, 0 as Amount_NhapMoi, 0 as Amount_KhaiTonDau, 0 as Amount_NhanHoanTraKho, 0 as Amount_XuatBan, 0 as Amount_XuatBN, 0 as Amount_XuatCK,0 as Amount_HTKho,0 as Amount_NhanCK,0 as Amount_HTNCC,
	0 as Amount_NhapMoiTime,0 as Amount_KhaiTonDauTime, 0 as Amount_NhanHoanTraKhoTime, 0 as Amount_XuatBanTime, ISNULL(sum(b.Quantity),0) as Amount_XuatBNTime, 0 as Amount_XuatCKTime,0 as Amount_HTKhoTime,0 as Amount_NhanCKTime,0 as Amount_HTNCCTime,c.UnitPrice,c.SalesPrice,c.DateEnd,c.Shipment
	from RealMedicinesForPatients a inner join RealMedicinesForPatientsDetail b on a.RowID=b.RealRowID inner join InventoryGumshoe c on b.RowIDInventoryGumshoe=c.RowID 
	where b.RepositoryCode=@RepositoryCode and b.ItemCode=(case when @ItemCode<>'' then @ItemCode else b.ItemCode end) and convert(date,a.DateApproved,103) >= convert(date,@FromDate,103) and convert(date,a.DateApproved,103)<=convert(date,@ToDate,103)
	group by b.ItemCode,b.RepositoryCode,c.UnitPrice,c.SalesPrice,c.DateEnd,c.Shipment
	) a
	group by a.ItemCode,a.RepositoryCode,a.UnitPrice,a.SalesPrice,a.DateEnd,a.Shipment
	update report_NXT_CT set AmountBegin=(AmountKhaiTonPre+AmountBeginPre+AmountImportPre+AmountImportRepaidPre+AmountImportTransferPre)-(AmountExportPre+AmountRepaidPre+AmountRepaidVenPre+AmountTransferPre)
	--
	select a.ItemCode,a.ItemName,a1.UnitOfMeasureName,a2.ItemCategoryName,
	sum(b.AmountBegin+b.AmountKhaiTon) as TotalQtyBegin,sum((b.AmountBegin+b.AmountKhaiTon)*b.UnitPrice) as TotalAmountBegin
	,sum(b.AmountImport) as QtyImport,sum(b.AmountImport *b.UnitPrice) as AmountImport
	,sum(b.AmountImportRepaid+b.AmountImportTransfer) as QtyImpTransfer,sum((b.AmountImportRepaid+b.AmountImportTransfer) * b.UnitPrice) as AmountImportTransfer
	,sum(b.AmountExport) as QtyExport, sum(b.AmountExport*b.UnitPrice) AmountExport
	,sum(b.AmountRepaid) as QtyRepaid,sum(b.AmountRepaid*b.UnitPrice) as AmountRepaid
	,sum(b.AmountRepaidVen) as QtyRepaidVen,sum(b.AmountRepaidVen*b.UnitPrice) as AmountRepaidVen
	,sum(b.AmountTransfer) as QtyTransfer,sum(b.AmountTransfer*b.UnitPrice) as AmountTransfer
	,sum(b.AmountBegin+b.AmountKhaiTon+b.AmountImport+b.AmountImportRepaid+b.AmountImportTransfer) as TotalQuantity
	,sum((b.AmountBegin+b.AmountKhaiTon+b.AmountImport+b.AmountImportRepaid+b.AmountImportTransfer)* b.UnitPrice) as TotalAmount
	,sum((b.AmountBegin+b.AmountKhaiTon+b.AmountImport+b.AmountImportRepaid+b.AmountImportTransfer)-(b.AmountExport+b.AmountRepaid+b.AmountRepaidVen+b.AmountTransfer)) as TotalQuantityEnd
	,sum(((b.AmountBegin+b.AmountKhaiTon+b.AmountImport+b.AmountImportRepaid+b.AmountImportTransfer)-(b.AmountExport+b.AmountRepaid+b.AmountRepaidVen+b.AmountTransfer))*b.UnitPrice) as TotalAmountEnd
	,sum(b.AmountImport)+sum(b.AmountImportRepaid+b.AmountImportTransfer) as TotalQuantityImport
	,sum((b.AmountImport+b.AmountImportRepaid+b.AmountImportTransfer)*b.UnitPrice) as TotalAmountImport
	,sum(b.AmountExport+b.AmountRepaid+b.AmountRepaidVen+b.AmountTransfer) as TotalQuantityExport
	,sum((b.AmountExport+b.AmountRepaid+b.AmountRepaidVen+b.AmountTransfer) * b.UnitPrice) as TotalAmountExport
	,a3.GroupName,a.SafelyQuantity,b.DateEnd,b.UnitPrice,b.Shipment,''QtyOfMeasure,''Packed,'' as Note
	from Items a
	inner join report_NXT_CT b on a.ItemCode=b.ItemCode
	inner join UnitOfMeasure a1 on a.UnitOfMeasureCode=a1.UnitOfMeasureCode inner join ItemCategory a2 on a.ItemCategoryCode=a2.ItemCategoryCode
	inner join ItemGroup a3 on a2.GroupCode=a3.GroupCode
	group by a.ItemCode,a.ItemName,a1.UnitOfMeasureName,a2.ItemCategoryName,a3.GroupName,a.SafelyQuantity,b.DateEnd,b.Shipment,b.UnitPrice
	order by a.ItemCode
end
go
------------ tiem chung
if exists(select name from sysobjects where name ='proPrint_MedicinesForPatients')
	drop procedure proPrint_MedicinesForPatients
go
create procedure proPrint_MedicinesForPatients
(
	@RowID varchar(100)
)
as
begin
	declare @TableRowID table(RowID numeric(18,0))
	if LEN(@RowID)>0
		insert into @TableRowID(RowID)(select CONVERT(numeric(18,0),splitdata) RowID from dbo.fnSplitString(@RowID,','))
	else
		insert into @TableRowID(RowID)values(0)
	select a.PatientCode,a.PatientReceiveID,upper(a1.PatientName) PatientName,a1.PatientBirthyear,a1.PatientAge,upper([dbo].func_PatientOfAddressFull(c.Address,c1.WardName,c2.DistrictName,c3.ProvincialName)) PatientAddress,
	CONVERT(date,a.DateApproved,103) DateApproved,b1.ItemName,b2.UnitOfMeasureName, b.SalesPrice, SUM(b.QuantityExport) QuantityExport, SUM(b.QuantityExport*b.SalesPrice) Amount,b.RepositoryCode,c.PatientReceiveClinic,b3.Shipment,d2.DoseNoName,CONVERT(char(10),b3.DateEnd,103) DateEnd
	from MedicinesForPatients a inner join MedicinesForPatientsDetail b on a.RowID=b.RowIDMedicines
	inner join Items b1 on b.ItemCode=b1.ItemCode inner join UnitOfMeasure b2 on b1.UnitOfMeasureCode=b2.UnitOfMeasureCode inner join InventoryGumshoe b3 on b.RowIDInventoryGumshoe=b3.RowID
	inner join Patients a1 on a.PatientCode=a1.PatientCode inner join PatientReceive c on a.PatientReceiveID=c.PatientReceiveID
	left join Catalog_Ward c1 on c.WardCode=c1.WardCode left join Catalog_District c2 on c.DistrictCode=c2.DistrictCode left join Catalog_Provincial c3 on c.ProvincialCode=c3.ProvincialCode
	inner join MedicalRecord d on a.MedicalRecordCode=d.MedicalRecordCode inner join ImmunizationRecordDetail d1 on d.ReferenceCode=d1.ImmunizationRecordDetailCode inner join CatalogDoseNo d2 on d1.RowIDDoseNo=d2.RowID
	where a.RowID in(select RowID from @TableRowID)
	group by a.PatientCode,a.PatientReceiveID,a1.PatientName,a1.PatientBirthyear,a1.PatientAge,c.Address,c1.WardName,c2.DistrictName,c3.ProvincialName,
	CONVERT(date,a.DateApproved,103),b1.ItemName,b2.UnitOfMeasureName,b.SalesPrice,b.RepositoryCode,c.PatientReceiveClinic,b3.Shipment,d2.DoseNoName,CONVERT(char(10),b3.DateEnd,103)
end
go
----------Trong add for hosongoaitru
if exists(select name from sysobjects where name ='func_ResultLap')
	drop function func_ResultLap
go
create function [dbo].[func_ResultLap](@SuggestedID VarChar(50),@ServiceCode VarChar(50))
RETURNS NVARCHAR(1000)
AS
BEGIN
	Declare @strKQ nvarchar(1000)
	set @strKQ=''
	Declare @Tempt nvarchar(1000)
	Declare @kq nvarchar(250)
	declare cur1 cursor read_only fast_forward
	for select f.LaboratoryName+' '+ f.ValuesEntry+' '+f.UnitValues from ServiceLaboratoryDetail f where f.SuggestedID = @SuggestedID and f.ServiceCode=@ServiceCode
	open cur1
	fetch next from cur1 into @kq
	while @@FETCH_STATUS = 0
	begin
		set @Tempt = @kq
		if ( len(@strKQ) > 0)
		begin
			set @strKQ=@strKQ + '; ' + @Tempt
		end
		else
		begin
			set @strKQ=@strKQ + @Tempt
		end
		
		FETCH NEXT FROM cur1 into @kq
	end
	CLOSE cur1
	DEALLOCATE cur1
	RETURN @strKQ
end
go
if exists(select name from sysobjects where name ='pro_View_Treatment_Info')
	drop procedure pro_View_Treatment_Info
go
create procedure pro_View_Treatment_Info
(
	@PatientCode varchar(50),
	@PatientReceiveID numeric(18,0)
)
as
begin
	declare @OutDate char(10)
	declare @HHrv char(5)
	if((select OutDate from PatientReceive where PatientReceiveID=@PatientReceiveID) is null)
	begin
		set @OutDate = (select CONVERT(char(10),GETDATE(),103) from PatientReceive where PatientReceiveID=@PatientReceiveID)
		set @HHrv = (select CONVERT(char(5),GETDATE(),108) from PatientReceive where PatientReceiveID=@PatientReceiveID)
	end
	else
	begin
		set @OutDate = (select CONVERT(char(10),OutDate,103) from PatientReceive where PatientReceiveID=@PatientReceiveID)
		set @HHrv = (select CONVERT(char(5),OutDate,108) from PatientReceive where PatientReceiveID=@PatientReceiveID)
	end
	select a.PatientReceiveID,a.PatientCode,b.PatientName,(case when b.PatientGender=1 then N'Nam' else N'Nữ' end) PatientGendername,
     convert(char(10),b.PatientBirthday,103) PatientBirthday,b.PatientBirthyear,b.PatientAge,b.PatientMobile,b.PatientEmail,b.CodeArise,b.MedicalHistory,b.Allergy,c.Serial,
     d.KCBBDName,c.StartDate,c.EndDate,(case when c.TraiTuyen = 1 then 1 else 0 end) TraiTuyen,(case when c.TraiTuyen=0 then 1 else 0 end) DungTuyen,e.RateFalse,e.RateTrue,b.PatientAddress,b.PatientGender,a.ObjectCode,a1.ObjectName,c.KCBBDCode, convert(char(5),a.CreateDate,108) HHvv,
    CONVERT(date,a.CreateDate,103) Datevv,[dbo].func_Department (@PatientCode,@PatientReceiveID) as DepartmentName,f.Symptoms
	--,(g.DiagnosisCode + ':' +g.DiagnosisName) DiagnosisCode
	,(f.ICD10_Custom + ':' +f.ICD10Name_Custom) DiagnosisCode
	,@OutDate OutDate,@HHrv HHrv,(ISNULL( DATEDIFF(day, CreateDate, OutDate),0)+1) DateTotal,f.DescriptionNode,f.Advices,f.DiagnosisCustom
    from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode left join BHYT c on a.PatientReceiveID=c.PatientReceiveID 
    left join KCBBD d on c.KCBBDCode=d.KCBBDCode left join RateBHYT e on SUBSTRING(c.Serial,0,3)=e.RateCard inner join [Object] a1 on a.ObjectCode=a1.ObjectCode
    left join MedicalRecord f on a.PatientReceiveID=f.PatientReceiveID and a.PatientCode=f.PatientCode 
	--left join Diagnosis g on f.DiagnosisCode=g.RowID
    where a.PatientReceiveID=@PatientReceiveID and a.PatientCode=@PatientCode
end
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BHYT' and b.name ='Serial01')
	alter table BHYT add Serial01 varchar(5)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BHYT' and b.name ='Serial02')
	alter table BHYT add Serial02 varchar(5)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BHYT' and b.name ='Serial03')
	alter table BHYT add Serial03 varchar(5)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BHYT' and b.name ='Serial04')
	alter table BHYT add Serial04 varchar(5)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BHYT' and b.name ='Serial05')
	alter table BHYT add Serial05 varchar(5)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BHYT' and b.name ='Serial06')
	alter table BHYT add Serial06 varchar(5)
go
if exists(select name from sysobjects where name like'proUpd_PatientInfomation')
	drop procedure proUpd_PatientInfomation
go
create procedure proUpd_PatientInfomation
(
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(50),
	@EThnicID int=-1,
	@CareerCode varchar(10),
	@NationalityID int=-1,
	@ProvincialCode varchar(3),
	@DistrictCode varchar(5),
	@WardCode varchar(8),
	@CompanyInfo nvarchar(200),
	@Address nvarchar(max),
	@PatientBirthday date,
	@PatientAge int,
	@PatientBirthyear int,
	@iresult int output
)
as
begin
	if exists(select PatientCode from PatientReceive where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode)
	begin
		update PatientReceive set CompanyInfo=@CompanyInfo,CareerCode=@CareerCode,EThnicID=@EThnicID,NationalityID=@NationalityID,ProvincialCode=@ProvincialCode,DistrictCode=@DistrictCode,WardCode=@WardCode,[Address]=@Address where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode
		update Patients set CareerCode=@CareerCode,EThnicID=@EThnicID,NationalityID=@NationalityID,ProvincialCode=@ProvincialCode,DistrictCode=@DistrictCode,WardCode=@WardCode,PatientAddress=@Address, PatientBirthday=@PatientBirthday, PatientBirthyear=@PatientBirthyear,PatientAge=@PatientAge where PatientCode=@PatientCode
		set @iresult = 1
	end
	else
	begin
		set @iresult = -1
	end
end
go
if not exists(select name from sys.columns where Name = N'PatientMonth' and Object_ID = Object_ID(N'Patients'))
	alter table Patients add PatientMonth nvarchar(10) not null default ''
go
if exists(select name from sysobjects where name='proView_ResultLaboratoryForReceiveID')
	drop procedure proView_ResultLaboratoryForReceiveID
go
create procedure proView_ResultLaboratoryForReceiveID
(
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(15)
)
as
	begin
		select  ROW_NUMBER() OVER(ORDER BY CONVERT(date,a.PostingDate,103) DESC) as STT, a1.ServiceName, [dbo].func_ResultLap(f.ReceiptID,f.ServiceCode) as Result, e.EmployeeName
		from ServiceLaboratoryEntry a inner join Patients b on a.PatientCode=b.PatientCode inner join PatientReceive c on a.PatientReceiveID=c.PatientReceiveID
		left join MedicalRecord d on c.PatientReceiveID=d.PatientReceiveID inner join Employee e on e.EmployeeCode = a.EmployeeCode
		inner join SuggestedServiceReceipt f on a.PatientReceiveID=f.RefID inner join Service a1 on f.ServiceCode=a1.ServiceCode 
		left join Catalog_Ward b1 on b.WardCode=b1.WardCode left join Catalog_District c1 on b.DistrictCode=c1.DistrictCode left join Catalog_Provincial d1 on b.ProvincialCode=d1.ProvincialCode 
		left join Career a2 on c.CareerCode=a2.CareerCode left join Catalog_EThnic a3 on c.EThnicID=a3.EThnicID
		where f.Paid in (1,2) and a1.ServiceCode in (select ServiceCode from ServiceLaboratoryDetail de where a.RowID=de.RowIDLaboratoryEnTry)
		and a.PatientReceiveID=@PatientReceiveID and a.PatientCode=@PatientCode 
	end
go
if exists(select name from sysobjects where name='func_MedicalRecordForItems')
	drop function func_MedicalRecordForItems
go
create function [dbo].[func_MedicalRecordForItems](@PatientReceiveID numeric(18,0),@PatientCode varchar(50))
RETURNS NVARCHAR(1000)
AS
BEGIN
	Declare @strKQ nvarchar(max)
	set @strKQ=''
	Declare @Tempt nvarchar(max)
	Declare @kq nvarchar(max)
	declare cur1 cursor read_only fast_forward
	for select (c.ItemName +' : ' + CONVERT(varchar(10),b.Quantity) +' ('+d.UnitOfMeasureName+') '+(case when b.Morning<>'' then N' Sáng '+b.Morning else '' end)+(case when b.Noon<>'' then N' Trưa '+b.Noon else '' end)+(case when b.Afternoon<>'' then N' Chiều '+b.Afternoon else '' end)+(case when b.Evening<>'' then N' Tối '+b.Evening else '' end) + ' '+ b.Instruction) ItemName from MedicalRecord a inner join MedicalPrescriptionDetail b on a.MedicalRecordCode=b.MedicalRecordCode inner join Items c on b.ItemCode=c.ItemCode inner join UnitOfMeasure d on c.UnitOfMeasureCode=d.UnitOfMeasureCode where a.PatientCode=@PatientCode and a.PatientReceiveID=@PatientReceiveID-- and a.Paid = 1
	open cur1
	fetch next from cur1 into @kq
	while @@FETCH_STATUS = 0
	begin
		set @Tempt = @kq
		if ( len(@strKQ) > 0)
		begin
			set @strKQ=@strKQ + '; ' + @Tempt
		end
		else
		begin
			set @strKQ=@strKQ + @Tempt
		end
		FETCH NEXT FROM cur1 into @kq
	end
	CLOSE cur1
	DEALLOCATE cur1
	RETURN @strKQ
end
go

IF NOT EXISTS (SELECT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MedicalRecordOutput')
begin
CREATE TABLE MedicalRecordOutput
(
	RowID numeric(25,0),
	PatientReceiveID numeric(18,0) not null default 0,	
	PatientCode varchar(15) not null,
	DepartmentCode varchar(50),
	ShiftWork char(2),
	EmployeeCode varchar(15),
	MedicalRecordCode nvarchar(100),
	ObjectCode int,
	FullNameFamily nvarchar(200),
	MobileFamily nvarchar(100),
	HourIn varchar(7),
	DateIn varchar(10),
	DiagnosisIntroduce nvarchar(250),
	isYTe bit not null default 0,
	isTuDen bit not null default 0,
	ReasonIn nvarchar(250),
	Pathological_Process nvarchar(1000),
	Anamnesis_Personal nvarchar(1000),
	Anamnesis_Family nvarchar(1000),
	KB_Totality nvarchar(1000),
	KB_Parts nvarchar(1000),
	Pulse varchar(10),
	Temperature varchar(10),
	BloodPressure varchar(10),
	BloodPressure1 varchar(10),
	Weight_ varchar(10),
	Hight varchar(10),
	Breath varchar(10),
	CLS_Brief nvarchar(max),
	Initial_Diagnosis int,
	Initial_DiagnosisName nvarchar(500),
	Drug_Brief nvarchar(max),
	ICD10_Out int,
	ICD10_OutName nvarchar(500),
	Treatment_DateFrom varchar(10),
	Treatment_DateTo varchar(10),
	BenhAn_DienBienLamSang nvarchar(max),
	BenhAn_TomTatXetNghiem nvarchar(max),
	BenhAn_BenhChinh int,
	BenhAn_BenhChinhTen nvarchar(500),
	BenhAn_BenhKemTheo varchar(100),
	BenhAn_BenhKemTheoTen nvarchar(500),
	BenhAn_PPDieuTri nvarchar(max),
	BenhAn_TTRaVien nvarchar(250),
	BenhAn_HuongDieuTri nvarchar(max),
	BenhAn_HSXQuang varchar(5),
	BenhAn_HSCTScanner varchar(5),
	BenhAn_HSSieuAm varchar(5),
	BenhAn_HSXetNghiem varchar(5),
	BenhAn_HSKhac varchar(5),
	BenhAn_NguoiGiaoHS nvarchar(15),
	BenhAn_NguoiNhanHS nvarchar(15),
	EmployeeDoctorCode varchar(15),
	DateWorking date,
	SoLuuTru int,
	Cancel bit default 0 not null,
	Workplace nvarchar(200)
	CONSTRAINT pk_MedicalRecordOutput PRIMARY KEY (RowID)
)
end
go
if exists(select name from sysobjects where name ='proIU_MedicalRecordOutput' and type='P')
	drop procedure proIU_MedicalRecordOutput
go
create procedure proIU_MedicalRecordOutput
(
	@RowID numeric(25,0),
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(15),
	@DepartmentCode varchar(50),
	@ShiftWork char(2),
	@EmployeeCode varchar(15),
	@MedicalRecordCode varchar(100),
	@ObjectCode int,
	@FullNameFamily nvarchar(200),
	@MobileFamily nvarchar(100),
	@HourIn varchar(7),
	@DateIn varchar(10),
	@DiagnosisIntroduce nvarchar(250),
	@isYTe bit,
	@isTuDen bit,
	@ReasonIn nvarchar(250),
	@Pathological_Process nvarchar(1000),
	@Anamnesis_Personal nvarchar(1000),
	@Anamnesis_Family nvarchar(1000),
	@KB_Totality nvarchar(1000),
	@KB_Parts nvarchar(1000),
	@Pulse varchar(10),
	@Temperature varchar(10),
	@BloodPressure varchar(10),
	@BloodPressure1 varchar(10),
	@Weight_ varchar(10),
	@Hight varchar(10),
	@Breath varchar(10),
	@CLS_Brief nvarchar(max),
	@Initial_DiagnosisName nvarchar(500),
	@Drug_Brief nvarchar(max),
	@ICD10_Out int,
	@ICD10_OutName nvarchar(500),
	@Treatment_DateFrom varchar(10),
	@Treatment_DateTo varchar(10),
	@BenhAn_DienBienLamSang nvarchar(max),
	@BenhAn_TomTatXetNghiem nvarchar(max),
	@BenhAn_BenhChinh int,
	@BenhAn_BenhChinhTen nvarchar(500),
	@BenhAn_BenhKemTheo varchar(100),
	@BenhAn_BenhKemTheoTen nvarchar(1000),
	@BenhAn_PPDieuTri nvarchar(max),
	@BenhAn_TTRaVien nvarchar(250),
	@BenhAn_HuongDieuTri nvarchar(max),
	@BenhAn_HSXQuang varchar(5),
	@BenhAn_HSCTScanner varchar(5),
	@BenhAn_HSSieuAm varchar(5),
	@BenhAn_HSXetNghiem varchar(5),
	@BenhAn_HSKhac varchar(5),
	@BenhAn_NguoiGiaoHS varchar(15),
	@BenhAn_NguoiNhanHS nvarchar(15),
	@EmployeeDoctorCode varchar(15),
	@DateWorking date,
	@SoLuuTru int,
	@Cancel bit =0,
	@Workplace nvarchar(200),
	@Result int output
)
as
begin
	if exists(select RowID from MedicalRecordOutput where PatientReceiveID=@PatientReceiveID and cancel=0)
		begin
			update MedicalRecordOutput set PatientReceiveID=@PatientReceiveID,PatientCode=@PatientCode,DepartmentCode=@DepartmentCode,ShiftWork=@ShiftWork,EmployeeCode=@EmployeeCode,MedicalRecordCode=@MedicalRecordCode,ObjectCode=@ObjectCode,
			FullNameFamily=@FullNameFamily,MobileFamily=@MobileFamily,HourIn=@HourIn,DateIn=@DateIn,DiagnosisIntroduce=@DiagnosisIntroduce,ReasonIn=@ReasonIn,Pathological_Process=@Pathological_Process,Anamnesis_Personal=@Anamnesis_Personal,
			Anamnesis_Family=@Anamnesis_Family,KB_Totality=@KB_Totality,KB_Parts=@KB_Parts,Pulse=@Pulse,Temperature=@Temperature,BloodPressure=@BloodPressure,BloodPressure1=@BloodPressure1,Weight_=@Weight_,Hight=@Hight,Breath=@Breath,
			CLS_Brief=@CLS_Brief,Drug_Brief=@Drug_Brief,ICD10_Out=@ICD10_Out,Treatment_DateFrom=@Treatment_DateFrom,Treatment_DateTo=@Treatment_DateTo,BenhAn_DienBienLamSang=@BenhAn_DienBienLamSang,BenhAn_TomTatXetNghiem=@BenhAn_TomTatXetNghiem,
			BenhAn_BenhChinh=@BenhAn_BenhChinh,BenhAn_BenhKemTheo=@BenhAn_BenhKemTheo,BenhAn_BenhKemTheoTen=@BenhAn_BenhKemTheoTen,BenhAn_PPDieuTri=@BenhAn_PPDieuTri,BenhAn_TTRaVien=@BenhAn_TTRaVien,BenhAn_HuongDieuTri=@BenhAn_HuongDieuTri,BenhAn_HSXQuang=@BenhAn_HSXQuang,BenhAn_HSCTScanner=@BenhAn_HSCTScanner,BenhAn_HSSieuAm=@BenhAn_HSSieuAm,
			BenhAn_HSXetNghiem=@BenhAn_HSXetNghiem,BenhAn_HSKhac=@BenhAn_HSKhac,BenhAn_NguoiGiaoHS=@BenhAn_NguoiGiaoHS,BenhAn_NguoiNhanHS=@BenhAn_NguoiNhanHS,EmployeeDoctorCode=@EmployeeDoctorCode,DateWorking=@DateWorking,SoLuuTru=@SoLuuTru,isYTe=@isYTe,isTuDen=@isTuDen,Initial_DiagnosisName=@Initial_DiagnosisName,ICD10_OutName=@ICD10_OutName,Workplace=@Workplace,BenhAn_BenhChinhTen=@BenhAn_BenhChinhTen where PatientReceiveID=@PatientReceiveID
			set @Result=@SoLuuTru
		end
	else
	begin
		declare @RowIDTemp numeric(25,0) = (select ISNULL(max(RowID),0) +1 from MedicalRecordOutput)
		set @SoLuuTru = (select ISNULL(max(SoLuuTru),0) +1 from MedicalRecordOutput where YEAR(DateWorking)=YEAR(GETDATE()))
		set @Result = @SoLuuTru
		insert into MedicalRecordOutput(RowID,PatientReceiveID,PatientCode,DepartmentCode,ShiftWork,EmployeeCode,MedicalRecordCode,ObjectCode,FullNameFamily,MobileFamily,HourIn,DateIn,DiagnosisIntroduce,ReasonIn,Pathological_Process,Anamnesis_Personal,Anamnesis_Family,KB_Totality,KB_Parts,Pulse,Temperature,BloodPressure,BloodPressure1,Weight_,Hight,Breath,CLS_Brief,Drug_Brief,ICD10_Out,Treatment_DateFrom,Treatment_DateTo,BenhAn_DienBienLamSang,BenhAn_TomTatXetNghiem,BenhAn_BenhChinh,BenhAn_BenhKemTheo,BenhAn_BenhKemTheoTen,BenhAn_PPDieuTri,BenhAn_TTRaVien,BenhAn_HuongDieuTri,BenhAn_HSXQuang,BenhAn_HSCTScanner,BenhAn_HSSieuAm,BenhAn_HSXetNghiem,BenhAn_HSKhac,BenhAn_NguoiGiaoHS,BenhAn_NguoiNhanHS,EmployeeDoctorCode,DateWorking,SoLuuTru,isYTe,isTuDen,Initial_DiagnosisName,ICD10_OutName,Workplace,BenhAn_BenhChinhTen) 
		values(@RowIDTemp,@PatientReceiveID,@PatientCode,@DepartmentCode,@ShiftWork,@EmployeeCode,@MedicalRecordCode,@ObjectCode,@FullNameFamily,@MobileFamily,@HourIn,@DateIn,@DiagnosisIntroduce,@ReasonIn,@Pathological_Process,@Anamnesis_Personal,@Anamnesis_Family,@KB_Totality,@KB_Parts,@Pulse,@Temperature,@BloodPressure,@BloodPressure1,@Weight_,@Hight,@Breath,@CLS_Brief,@Drug_Brief,@ICD10_Out,@Treatment_DateFrom,@Treatment_DateTo,@BenhAn_DienBienLamSang,@BenhAn_TomTatXetNghiem,@BenhAn_BenhChinh,@BenhAn_BenhKemTheo,@BenhAn_BenhKemTheoTen,@BenhAn_PPDieuTri,@BenhAn_TTRaVien,@BenhAn_HuongDieuTri,@BenhAn_HSXQuang,@BenhAn_HSCTScanner,@BenhAn_HSSieuAm,@BenhAn_HSXetNghiem,@BenhAn_HSKhac,@BenhAn_NguoiGiaoHS,@BenhAn_NguoiNhanHS,@EmployeeDoctorCode,@DateWorking,@SoLuuTru,@isYTe,@isTuDen,@Initial_DiagnosisName,@ICD10_OutName,@Workplace,@BenhAn_BenhChinhTen)
	end
end
go
if exists(select name from sysobjects where name='pro_View_Treatment_OutPatient')
	drop procedure pro_View_Treatment_OutPatient
go
create procedure pro_View_Treatment_OutPatient
(
	@PatientCode varchar(50),
	@PatientReceiveID numeric(18,0)
)
as
begin
	select a.RowID,a.PatientReceiveID,a.PatientCode,a.DepartmentCode,a.ShiftWork,a.EmployeeCode,a.MedicalRecordCode,a.ObjectCode,a.FullNameFamily,a.MobileFamily,CONVERT(char(10),a.DateIn,103) DateIn,a.DiagnosisIntroduce,a.ReasonIn,a.Pathological_Process,a.Anamnesis_Personal,a.Anamnesis_Family,a.KB_Totality,a.KB_Parts,a.Pulse,a.Temperature,a.BloodPressure,a.BloodPressure1,a.Weight_,Hight,a.Breath,a.CLS_Brief,a.Drug_Brief,a1.DiagnosisCode ICD10_Out,a.Treatment_DateFrom,a.Treatment_DateTo,a.BenhAn_DienBienLamSang,a.BenhAn_TomTatXetNghiem,a2.DiagnosisCode BenhAn_BenhChinh,a.BenhAn_BenhKemTheo,a.BenhAn_BenhKemTheoTen,a.BenhAn_PPDieuTri,a.BenhAn_TTRaVien,a.BenhAn_HuongDieuTri,a.BenhAn_HSXQuang,a.BenhAn_HSCTScanner,a.BenhAn_HSSieuAm,a.BenhAn_HSXetNghiem,a.BenhAn_HSKhac,a.BenhAn_NguoiGiaoHS,a.BenhAn_NguoiNhanHS,a.EmployeeDoctorCode,a.DateWorking,a.SoLuuTru,a.Cancel,a.isYTe,a.isTuDen,a.Initial_DiagnosisName,a.ICD10_OutName,a.BenhAn_BenhChinhTen
	,a.Workplace,left(a.HourIn,2) HourIn,right(a.HourIn,2) MinuteIn,upper(b.PatientName) PatientName,b.PatientAddress,b.PatientBirthday,b.PatientAge,b.PatientGender,b1.CareerName,b2.WardName,b3.DistrictCode,b3.DistrictName,b4.ProvincialCode,b4.ProvincialName,c.DepartmentName,d.EmployeeName,e.EmployeeName EmployeeDoctorName,f.EmployeeName NguoiGiaoHS,g.EmployeeName NguoiNhanHS,b5.EThnicName,b5.EThnicID,h.EndDate BHYT_EndDate,h.Serial01,h.Serial02,h.Serial03,h.Serial04,h.Serial05,h.Serial06
	from MedicalRecordOutput a inner join Patients b on a.PatientCode=b.PatientCode left join Career b1 on b.CareerCode=b1.CareerCode left join Catalog_Ward b2 on b.WardCode=b2.WardCode left join Catalog_District b3 on b.DistrictCode=b3.DistrictCode left join Catalog_Provincial b4 on b.ProvincialCode=b4.ProvincialCode left join Catalog_EThnic b5 on b.EThnicID=b5.EThnicID
	left join Department c on a.DepartmentCode=c.DepartmentCode left join Employee d on a.EmployeeCode=d.EmployeeCode left join Employee e on a.EmployeeDoctorCode=e.EmployeeCode left join Employee f on a.BenhAn_NguoiGiaoHS =f.EmployeeCode left join Employee g on a.BenhAn_NguoiNhanHS=g.EmployeeCode 
	left join BHYT h on a.PatientReceiveID=h.PatientReceiveID and a.PatientCode=h.PatientCode left join Diagnosis a1 on a.ICD10_Out=a1.RowID left join Diagnosis a2 on a.BenhAn_BenhChinh=a2.RowID
	where a.PatientReceiveID=@PatientReceiveID and a.PatientCode=@PatientCode and a.cancel=0 
end
go
----------End add for hosongoaitru
/*
insert into tackle(TackleCode,TackleName) values(6,N'Đỡ, Khỏi, Giảm')
insert into tackle(TackleCode,TackleName) values(7,N'Tử vong')
*/
if not exists(select * from sys.columns where Name = N'TNTTID' and Object_ID = Object_ID(N'PatientReceive'))
	alter table PatientReceive add TNTTID int default 0 not null
go
if exists(select name from sysobjects where name ='pro_BCTHTC')
	drop procedure pro_BCTHTC
go
create procedure pro_BCTHTC
(
	@frDate date,
	@toDate date
)
as
begin
	select a.PatientCode , d.PatientName, (case when d.PatientGender = 1 then 'Nam' else N'Nữ' end) as PatientGender,(case when d.PatientGender = 1 then 'Nam' else '' end) as PatientGenderNam,(case when d.PatientGender = 0 then  N'Nữ' else'' end) as PatientGenderNu , convert(char(10),d.PatientBirthday,103) PatientBirthday,  
	(case when d3.ProvincialName <> N'Không Xác Định' then d3.ProvincialName else '' end) ProvincialName,(case when d1.WardName <> N'Không Xác Định' then d1.WardName else '' end) WardName, (case when d2.DistrictName <> N'Không Xác Định' then d2.DistrictName else '' end) DistrictName,d.PatientAddress, convert(char(10),a.WorkDate,103) WorkDate, g.ServiceName, f.DoseNoName, e.Note
	from  ImmunizationRecord a inner join SuggestedServiceReceipt b on a.ReceiptID= b.ReceiptID inner join
	 PatientReceive c on c.PatientReceiveID = a.PatientReceiveID inner join Patients d on a.PatientCode=d.PatientCode
	 inner join ImmunizationRecordDetail e on e.ImmunizationRecordCode=a.ImmunizationRecordCode inner join CatalogDoseNo f
	 on f.RowID=e.RowIDDoseNo inner join Service g on g.ServiceCode=a.ServiceCode
	 left join Catalog_Ward d1 on c.WardCode=d1.WardCode left join Catalog_District d2 on c.DistrictCode=d2.DistrictCode left join 
	 Catalog_Provincial d3 on c.ProvincialCode=d3.ProvincialCode
	 where CONVERT(date,a.WorkDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103) 
	 order by CONVERT(date,a.WorkDate,103)
end
go
if exists(select name from sysobjects where name = 'proView_TiemVaccin')
	drop procedure proView_TiemVaccin
go
create procedure proView_TiemVaccin
(
	@frDate date,
	@Todate date
)
as
begin
	declare @MuiTiem int=0
	declare @TreDuoi1t int=0
	declare @TreDuoi1Den5t int=0
	declare @TreDuoi1tVaNL int=0
	declare @ServiceCode nvarchar(50)
	declare @ServiceName nvarchar(300)
	declare @PhanUng nvarchar(300)
	declare @GhiChu nvarchar(300)
	declare @Count int=0
	declare @TableResult table(ServiceCode nvarchar(50),ServiceName nvarchar(300),PhanUng nvarchar(300), GhiChu nvarchar(300))
	declare @TableTemp table(ServiceName nvarchar(300), MuiTiem int, TreDuoi1t int, TreDuoi1Den5t int, TreDuoi1tVaNL int, PhanUng nvarchar(300), GhiChu nvarchar(300))
	begin
		insert into @TableResult (ServiceCode,ServiceName,PhanUng,GhiChu)(select a.ServiceCode,b.ServiceName,c.LotNo,c.Note from ImmunizationRecord a inner join Service b on a.ServiceCode=b.ServiceCode inner join ImmunizationRecordDetail c on a.ImmunizationRecordCode=c.ImmunizationRecordCode )
		set @Count = (select COUNT(*) sl from @TableResult)
		WHILE(@Count) > 0
		begin
			select top(1) @ServiceCode=ServiceCode,@ServiceName=ServiceName,@PhanUng=PhanUng,@GhiChu=GhiChu from @TableResult
			set @TreDuoi1t = (
				select COUNT(a.ServiceCode) ServiceCode
				from ImmunizationRecord a inner join Patients b on a.PatientCode=b.PatientCode inner join SuggestedServiceReceipt c on a.ReceiptID=c.ReceiptID
				where b.PatientAge <= 1 and a.ServiceCode in (@ServiceCode) and CONVERT(date,a.WorkDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@Todate,103) and c.Status in (1,2)
				group by a.ServiceCode
			)
			set @TreDuoi1Den5t = (
				select COUNT(a.ServiceCode) ServiceCode
				from ImmunizationRecord a inner join Patients b on a.PatientCode=b.PatientCode inner join SuggestedServiceReceipt c on a.ReceiptID=c.ReceiptID
				where b.PatientAge > 1 and b.PatientAge <=5 and a.ServiceCode in (@ServiceCode) and CONVERT(date,a.WorkDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@Todate,103) and c.Status in (1,2)
				group by a.ServiceCode
			)
			set @TreDuoi1tVaNL = (
				select COUNT(a.ServiceCode) ServiceCode
				from ImmunizationRecord a inner join Patients b on a.PatientCode=b.PatientCode inner join SuggestedServiceReceipt c on a.ReceiptID=c.ReceiptID
				where b.PatientAge > 5 and a.ServiceCode in (@ServiceCode) and CONVERT(date,a.WorkDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@Todate,103) and c.Status in (1,2)
				group by a.ServiceCode
			)
			if(@TreDuoi1t is null)
				set @TreDuoi1t=0
			if(@TreDuoi1Den5t is null)
				set @TreDuoi1Den5t=0
			if(@TreDuoi1tVaNL is null)
				set @TreDuoi1tVaNL=0
			set @MuiTiem=@TreDuoi1t+@TreDuoi1Den5t+@TreDuoi1tVaNL
			if(@MuiTiem = 0)
			begin
			set @MuiTiem =''
			set @TreDuoi1t = ''
			set @TreDuoi1Den5t = ''
			set @TreDuoi1tVaNL = ''
			end
			insert into @TableTemp(ServiceName,MuiTiem,TreDuoi1t,TreDuoi1Den5t,TreDuoi1tVaNL,PhanUng,GhiChu) values(@ServiceName,@MuiTiem,@TreDuoi1t,@TreDuoi1Den5t,@TreDuoi1tVaNL,@PhanUng,@GhiChu)
			DELETE FROM @TableResult where ServiceCode=@ServiceCode
			set @Count=@Count-1
		end
	end
	select distinct ServiceName,MuiTiem,TreDuoi1t,TreDuoi1Den5t,TreDuoi1tVaNL,PhanUng,GhiChu from @TableTemp
	where MuiTiem > 0
end
go

if exists(select name from sysobjects where name ='proView_HDKCB') 
	drop procedure proView_HDKCB
go
create procedure proView_HDKCB
(
	@frDate date,
	@Todate date
)
as
begin
declare @TableResult table(MaKP varchar(10), TenKP nvarchar(200))
	declare @TenKhoaPhong nvarchar(200)
	declare @MaKhoaPhong varchar(10)
	declare @GiuongLuu int
	declare @TongSo int
	declare @Nu int
	declare @BHYT int
	declare @YHCT int
	declare @TreEm int
	declare @SoLanXN int
	declare @SoLanXQ int
	declare @SoLanSA int
	declare @SoLanCT int
	declare @Count int =0
	declare @TableTemp table(KhoaPhong nvarchar(200),GiuongLuu int,TongSo int, Nu int,BHYT int,YHCT int, TreEm int, SoLanXN int, SoLanXQ int, SoLanSA int, SoLanCT int)
	begin
	insert into @TableResult(MaKP,TenKP)(select DepartmentCode,DepartmentName from Department)
	set @Count = (select COUNT(*) sl from @TableResult)
	WHILE(@Count) > 0
	begin
	select top(1) @MaKhoaPhong = MaKP, @TenKhoaPhong = TenKP from @TableResult
	------------
		set @SoLanXN=(
			select Count(a.ServiceCode)
			from SuggestedServiceReceipt a inner join Service b1 on a.ServiceCode=b1.ServiceCode
				 inner join ServiceCategory b2 on b1.ServiceCategoryCode=b2.ServiceCategoryCode
				 inner join ServiceGroup b3 on b2.ServiceGroupCode=b3.ServiceGroupCode
			where CONVERT(date,a.WorkDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@Todate,103) and b2.ServiceGroupCode='XN' and a.Paid=1 and a.BanksAccountCode<>'' and a.DepartmentCode=@MaKhoaPhong
			group by b2.ServiceGroupCode)
		set @SoLanSA=(
			select Count(a.ServiceCode)
			from SuggestedServiceReceipt a inner join Service b1 on a.ServiceCode=b1.ServiceCode
				 inner join ServiceCategory b2 on b1.ServiceCategoryCode=b2.ServiceCategoryCode
				 inner join ServiceGroup b3 on b2.ServiceGroupCode=b3.ServiceGroupCode
			where CONVERT(date,a.WorkDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@Todate,103) and b2.ServiceGroupCode='CDHA' and a.Paid=1 and a.BanksAccountCode<>'' and a.DepartmentCode=@MaKhoaPhong
			group by b2.ServiceGroupCode)
		set @TreEm=(
			select Count(a.ServiceCode)
			from SuggestedServiceReceipt a inner join Service b1 on a.ServiceCode=b1.ServiceCode
				 inner join ServiceCategory b2 on b1.ServiceCategoryCode=b2.ServiceCategoryCode
				 inner join ServiceGroup b3 on b2.ServiceGroupCode=b3.ServiceGroupCode
				 inner join Patients c on a.PatientCode=c.PatientCode
			where CONVERT(date,a.WorkDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@Todate,103) and c.PatientAge < 15 and b2.ServiceGroupCode='KCB' and a.Paid=1 and a.BanksAccountCode<>'' and a.DepartmentCode=@MaKhoaPhong
			group by b2.ServiceGroupCode)
		set @Nu=(
			select Count(a.ServiceCode)
			from SuggestedServiceReceipt a inner join Service b1 on a.ServiceCode=b1.ServiceCode
				 inner join ServiceCategory b2 on b1.ServiceCategoryCode=b2.ServiceCategoryCode
				 inner join ServiceGroup b3 on b2.ServiceGroupCode=b3.ServiceGroupCode
				 inner join Patients c on a.PatientCode=c.PatientCode
			where CONVERT(date,a.WorkDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@Todate,103) and c.PatientGender=0 and b2.ServiceGroupCode='KCB' and a.Paid=1 and a.BanksAccountCode<>'' and a.DepartmentCode=@MaKhoaPhong
			group by b2.ServiceGroupCode)
		if(@Nu is null) set @Nu=0
		if(@TreEm is null) set @TreEm=0
		set @TongSo=@Nu+@TreEm
		if (@TongSo = 0)
		begin
		set @TongSo=''
		set @Nu = ''
		set @TreEm = ''
		end
		insert into @TableTemp(KhoaPhong,GiuongLuu,TongSo, Nu,BHYT,YHCT, TreEm, SoLanXN, SoLanXQ, SoLanSA, SoLanCT) values(@TenKhoaPhong,@GiuongLuu,@TongSo,@Nu,@BHYT,@YHCT,@TreEm,@SoLanXN,@SoLanXQ,@SoLanSA,@SoLanCT)
		---------------------
	DELETE FROM @TableResult where MaKP=@MaKhoaPhong
	set @Count=@Count-1
	end
	end
	select KhoaPhong,GiuongLuu,TongSo, Nu,BHYT,YHCT, TreEm, SoLanXN, SoLanXQ, SoLanSA, SoLanCT from @TableTemp 
	where TongSo > 0 or Nu > 0 or TreEm > 0 or SoLanXN > 0 or SoLanXQ > 0 or SoLanSA > 0 or SoLanCT > 0
	end
go

if exists(select name from sysobjects where name ='proView_TNTT') 
	drop procedure proView_TNTT
go
create procedure proView_TNTT
(
	@frDate date,
	@Todate date
)
as
begin
declare @TableResult table(TNTTID int, TNTTName nvarchar(200))
	declare @SLMac int
	declare @SLChet int
	declare @Count int
	declare @TNTTID int
	declare @TNTTName nvarchar(200)
	declare @TableTemp table(TNTTID int,TNTTName nvarchar(200),SLMac int,SLChet int)
	begin
	insert into @TableResult(TNTTID,TNTTName)(select Ma,Ten from DMTaiNanTT where Ma <> 1)
	set @Count = (select COUNT(*) sl from @TableResult)
	WHILE(@Count) > 0
		begin
			select top(1) @TNTTID = TNTTID, @TNTTName = TNTTName from @TableResult
			------------
			set @SLMac=(
					select Count(a.PatientCode)
					from PatientReceive a inner join DMTaiNanTT b on a.TNTTID=b.Ma
					where CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@Todate,103) and a.TNTTID=@TNTTID and a.Status in (1,2)
					group by b.Ma)
			set @SLChet = (
					select Count(a.PatientCode)
					from PatientReceive a inner join DMTaiNanTT b on a.TNTTID=b.Ma inner join MedicalRecord c on a.PatientReceiveID=c.PatientReceiveID
					where  a.Status in (1,2) and c.TackleCode = 7 and CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@Todate,103) and a.TNTTID=@TNTTID 
					group by b.Ma)
			if(@SLMac = '')
			begin
				set @SLMac = 0
			end
			if(@SLChet = '')
			begin
				set @SLMac = 0
			end
			insert into @TableTemp(TNTTID,TNTTName,SLMac,SLChet) values(@TNTTID,@TNTTName,@SLMac,@SLChet)
				---------------------
			DELETE FROM @TableResult where TNTTID=@TNTTID
			set @Count=@Count-1
		end
	end
		select TNTTID,TNTTName,SLMac,SLChet from @TableTemp 
		--where SLMac > 0 or SLChet> 0
	end
go
if exists(select name from sysobjects where name ='proView_BM_6_YTTN') 
	drop procedure proView_BM_6_YTTN
go
create procedure proView_BM_6_YTTN
(
	@frDate date,
	@Todate date
)
as
begin
declare @TableResult table(Stt int, MaBenh varchar(10), TenBenh nvarchar(200))
	declare @Count int = 0
	declare @stt int 
	declare @MaBenh varchar(10)
	declare @TenBenh nvarchar(200)

	declare @SLmac int 
	declare @SLchet int 
	

	declare @TableTemp table(Stt int,MaBenh varchar(10), TenBEnh nvarchar(200),SLMac int, SLTuVong int)
	begin
	insert into @TableResult(Stt,MaBenh,TenBenh)values(1,'A00',N'Tả')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(2,'A01',N'Thương hàn')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(3,'A03',N'Lỵ trực trùng')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(4,'A06',N'Lỵ amíp')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(5,'A09',N'Tiêu chảy')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(6,'A83',N'Viêm não vi rút')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(7,'A90',N'Sốt xuất huyết')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(7,'A91',N'Sốt xuất huyết')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(8,'B50',N'Sốt rét')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(9,'B15',N'Viêm gan vi rút')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(10,'A82',N'Bệnh Dại')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(11,'A39',N'Viêm màng não do não mô cầu')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(12,'B01',N'Thuỷ đậu')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(13,'A36',N'Bạch hầu')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(14,'A37',N'Ho gà')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(15,'A33',N'Uốn ván sơ sinh ')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(16,'A35',N'Uốn ván (không phải uốn ván sơ sinh)')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(17,'A80',N'Liệt mềm cấp nghi bại liệt')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(18,'B05',N'Sởi')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(19,'B26',N'Quai bị')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(20,'B06',N'Rubella (Rubeon)')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(21,'J10',N'Cúm')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(21,'J11',N'Cúm')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(22,'J09',N'Cúm A(H5N1)')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(23,'B30',N'Bệnh do vi rút Adeno')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(24,'A20',N'Dịch hạch')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(25,'A22',N'Than')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(26,'A27',N'Xoắn khuẩn vàng da (Leptospira)')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(27,'B08.4',N'Tay - chân - miệng')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(28,'B95',N'Bệnh do liên cầu lợn ở người')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(29,'00000',N'Viêm phổi')
	insert into @TableResult(Stt,MaBenh,TenBenh)values(30,'00001',N'NK đường hô hấp trên')
	set @Count = (select COUNT(*) sl from @TableResult)
	WHILE(@Count) > 0
	begin
	select top(1) @stt = Stt, @MaBenh = MaBenh, @TenBenh = TenBenh from @TableResult
	---------------------
		set @SLmac = (select count(*) from  MedicalRecord a inner join Diagnosis b on a.DiagnosisCode=b.RowID inner join @TableResult c on
		c.MaBenh=b.DiagnosisCode  inner join PatientReceive a1 on a1.PatientReceiveID=a.PatientReceiveID where a1.[Status] in (1,2) and CONVERT(date,a.PostingDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@Todate,103)
		and c.MaBenh = @MaBenh)
		
		set @SLchet =  (select count(*) from MedicalRecord a inner join Diagnosis b on a.DiagnosisCode=b.RowID inner join @TableResult c on
		c.MaBenh=b.DiagnosisCode  inner join PatientReceive a1 on a1.PatientReceiveID=a.PatientReceiveID where a1.[Status] in (1,2) and a.TackleCode = 7 and CONVERT(date,a.PostingDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@Todate,103)
		and c.MaBenh = @MaBenh)
		insert into @TableTemp(Stt,MaBenh,TenBEnh,SLMac,SLTuVong ) values(@stt,@MaBenh,@TenBenh,@SLmac,@SLchet)
	---------------------
	DELETE FROM @TableResult where MaBenh=@MaBenh
	set @Count=@Count-1
	end
	end
	select Stt,TenBEnh,SLMac,SLTuVong from @TableTemp group by Stt,TenBEnh,SLMac,SLTuVong
	end
go
if exists(select name from sysobjects where name = 'pro_Ins_PatientReceive')
 drop procedure pro_Ins_PatientReceive
go
create procedure pro_Ins_PatientReceive
(
 
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(50),
	@Reason nvarchar(max),
	@EmployeeCode varchar(50),
	@Status int,
	@DepartmentCode varchar(50),
	@ObjectCode int,
	@PatientType int,
	@ReferenceCode varchar(50),
	@EThnicID int=-1,
	@CareerCode varchar(10),
	@NationalityID int=-1,
	@ProvincialCode varchar(3),
	@DistrictCode varchar(5),
	@WardCode varchar(8),
	@CompanyInfo nvarchar(200),
	@Address nvarchar(max),
	@IntroName nvarchar(250),
	@IDTypeReceive int,
	@PatientReceiveClinic varchar(30),
	@ShiftWork char(2),
	@TNTTID int,
	@vresult varchar(50) output,
	@IDAppointment247 nvarchar(50),
	@CreateDate datetime
)
as
begin
	set @IntroName =upper(@IntroName)
	if exists(select PatientReceiveID from PatientReceive where PatientReceiveID=@PatientReceiveID)
	begin
		update PatientReceive set Reason=@Reason,EmployeeCode=@EmployeeCode,[Status]=@Status,DepartmentCode=@DepartmentCode,ObjectCode=@ObjectCode,ReferenceCode=@ReferenceCode,PatientType=@PatientType,CompanyInfo=@CompanyInfo,CareerCode=@CareerCode,EThnicID=@EThnicID,NationalityID=@NationalityID,ProvincialCode=@ProvincialCode,DistrictCode=@DistrictCode,WardCode=@WardCode,[Address]=@Address,IntroName=@IntroName,IDTypeReceive=@IDTypeReceive,TNTTID=@TNTTID,IDAppointment247 =@IDAppointment247,CreateDate=@CreateDate,IDate=getdate() where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode
		set @vresult=@ReferenceCode
	end
	else
	begin
		declare @_Code varchar(50)
		declare @_stt decimal(12,0)
		declare @OrderNumber int = 0
		declare @OrderNumberYYYY int = 0
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(ReferenceCode,12)) maxcode from PatientReceive order by PatientReceiveID desc)+1
		if(@_stt<=9)
			begin
				set @_Code = 'DKKB00000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_Code = 'DKKB0000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_Code = 'DKKB000000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_Code = 'DKKB00000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999 and @_stt<=99999)
			begin
				set @_Code = 'DKKB0000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999 and @_stt<=999999)
			begin
				set @_Code = 'DKKB000000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999999 and @_stt<=9999999)
			begin
				set @_Code = 'DKKB00000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999999 and @_stt<=99999999)
			begin
				set @_Code = 'DKKB0000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999999 and @_stt<=999999999)
			begin
				set @_Code = 'DKKB000'+convert(varchar(12),@_stt)
			end
		else if(@_stt>999999999 and @_stt<=9999999999)
			begin
				set @_Code = 'DKKB00'+convert(varchar(12),@_stt)
			end
		else if(@_stt>9999999999 and @_stt<=99999999999)
			begin
				set @_Code = 'DKKB0'+convert(varchar(12),@_stt)
			end
		else if(@_stt>99999999999 and @_stt<=999999999999)
			begin
				set @_Code = 'DKKB'+convert(varchar(12),@_stt)
			end
		else
			begin
				set @_Code = 'DKKB000000000001'
			end
		set @OrderNumber = (select ISNULL(max(OrderNumber),0)+1 STT from PatientReceive where CONVERT(date,CreateDate,103)=CONVERT(date,GETDATE(),103))
		if(LEN(@OrderNumber)=1)
			set @PatientReceiveClinic = (select convert(char(4),DATEPART(yyyy,GETDATE())) WorkingDate)+'000'+convert(varchar(8),@OrderNumber)+'-'+@PatientCode
		else if(LEN(@OrderNumber)=2)
			set @PatientReceiveClinic = (select convert(char(4),DATEPART(yyyy,GETDATE())) WorkingDate)+'00'+convert(varchar(8),@OrderNumber)+'-'+@PatientCode
		else if(LEN(@OrderNumber)=3)
			set @PatientReceiveClinic = (select convert(char(4),DATEPART(yyyy,GETDATE())) WorkingDate)+'0'+convert(varchar(8),@OrderNumber)+'-'+@PatientCode
		else
			set @PatientReceiveClinic = (select convert(char(4),DATEPART(yyyy,GETDATE())) WorkingDate)+convert(varchar(8),@OrderNumber)+'-'+@PatientCode
		set @OrderNumberYYYY = (select ISNULL(max(OrderNumberYYYY),0)+1 STT from PatientReceive where year(CreateDate)=year(GETDATE()))
		insert into PatientReceive(PatientCode,Reason,EmployeeCode,[Status],DepartmentCode,ObjectCode,PatientType,ReferenceCode,EThnicID,CareerCode,NationalityID,ProvincialCode,DistrictCode,WardCode,CompanyInfo,Address,IntroName,IDTypeReceive,PatientReceiveClinic,OrderNumber,ShiftWork,TNTTID,IDAppointment247,CreateDate,OrderNumberYYYY) values(@PatientCode,@Reason,@EmployeeCode,@Status,@DepartmentCode,@ObjectCode,@PatientType,@_Code,@EThnicID,@CareerCode,@NationalityID,@ProvincialCode,@DistrictCode,@WardCode,@CompanyInfo,@Address,@IntroName,@IDTypeReceive,@PatientReceiveClinic,@OrderNumber,@ShiftWork,@TNTTID,@IDAppointment247,@CreateDate,@OrderNumberYYYY)
		set @vresult =@_Code
	end
end
go
if exists(select name from sysobjects where name ='pro_Ins_PatientReceiveUpdate')
	drop procedure pro_Ins_PatientReceiveUpdate
go
create procedure pro_Ins_PatientReceiveUpdate
(
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(50),
	@EmployeeCode varchar(50),
	@ObjectCode int,
	@PatientType int,
	@CreateDate datetime,
	@EThnicID int=-1,
	@CareerCode varchar(10),
	@NationalityID int=-1,
	@ProvincialCode varchar(3),
	@DistrictCode varchar(5),
	@WardCode varchar(8),
	@CompanyInfo nvarchar(200),
	@IntroName nvarchar(250),
	@Address nvarchar(max),
	@iresult int output
)
as
begin
	set @IntroName =upper(@IntroName)
	if exists(select PatientCode from PatientReceive where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode)
	begin
		update PatientReceive set EmployeeCode=@EmployeeCode,ObjectCode=@ObjectCode,PatientType=@PatientType,CompanyInfo=@CompanyInfo,CareerCode=@CareerCode,EThnicID=@EThnicID,NationalityID=@NationalityID,ProvincialCode=@ProvincialCode,DistrictCode=@DistrictCode,WardCode=@WardCode,IntroName=@IntroName,[Address]=@Address where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode
		set @iresult = 1
	end
	else
	begin
		set @iresult = -1
	end
end
go
---------- end add bao cao so
---------------------------- Hen Kham Benh 247
if exists(select name from sysobjects where name ='pro_ViewListIDAppointment247')
	drop procedure pro_ViewListIDAppointment247
go
create procedure pro_ViewListIDAppointment247
as
begin
	select a.IDAppointment247
	from PatientReceive a 
	where IDAppointment247 is not null 
end
go
if exists(select name from sysobjects where name = 'pro_ViewThongkeAppointment247')
 drop procedure pro_ViewThongkeAppointment247
go
create procedure pro_ViewThongkeAppointment247
(
	@FromDate date,
	@ToDate date
	
)
as
begin
select lst1.Datecreate, x.PatientCode,x.PatientName, lst1.IDDoctorAppointment247,lst1.NameDoctorAppointment247,lst1.DepartmentCode,lst2.DepartmentName,lst1.Status
from Patients x 
inner join (
select  convert(date,a.CreateDate,103) as Datecreate,a.IDDoctorAppointment247,a.NameDoctorAppointment247 ,a.PatientCode,a.DepartmentCode ,
	(case 
	when a.Status =0 then N'Chưa khám'
	else N'Đã khám'
	end) Status,
	a.ReceiptID from SuggestedServiceReceipt a inner join Patients b on a.PatientCode = b.PatientCode
where (a.IDAppointment247 is not null and a.IDDoctorAppointment247 is not null) And (convert(date,a.CreateDate,103) between convert(date,@FromDate,103) and convert(date,@ToDate,103) )
group by  convert(date,a.CreateDate,103) ,a.IDDoctorAppointment247, a.NameDoctorAppointment247, a.PatientCode,a.DepartmentCode,a.Status,a.ReceiptID ) lst1 on lst1.PatientCode=x.PatientCode
inner join (
select c.DepartmentCode,c.DepartmentName
from Department c where c.Hide = 0
) lst2 on lst1.DepartmentCode = lst2.DepartmentCode
end
go
----------- Upd ngay 19/01/2017
if exists(select name from sysobjects where name = 'pro_ViewSuggestedForDate')
 drop procedure pro_ViewSuggestedForDate
go
create procedure pro_ViewSuggestedForDate
(
	@FromDate date,
	@ToDate date,
	@Status int=0
)
as
begin
	if @Status=0
	begin
		select a.PatientCode,b.PatientName,a.PatientReceiveID,a.CreateDate,b.PatientBirthYear,(year(getdate())-b.PatientBirthyear) PatientAge, (case b.PatientGender when 0 then N'Nữ' else 'Nam' end) PatientGenderName,a.Address,a3.WardName,a2.DistrictName,a1.ProvincialName,b.PatientMobile,c.ObjectName,d.EmployeeName,a.ObjectCode,a.ReferenceCode,a.PatientType,a.OrderNumber
		from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode left join Catalog_Provincial a1 on a.ProvincialCode=a1.ProvincialCode left join Catalog_District a2 on a.DistrictCode=a2.DistrictCode left join Catalog_Ward a3 on a.WardCode=a3.WardCode inner join Object c on a.ObjectCode=c.ObjectCode inner join Employee d on a.EmployeeCode=d.EmployeeCode
		where CONVERT(date,a.CreateDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) and a.PatientReceiveID not in( select RefID from SuggestedServiceReceipt where CONVERT(date,WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) and ServiceCode<>'DV000000')
	end
	else
	begin
		select a.PatientCode,b.PatientName,a.PatientReceiveID,a.CreateDate,b.PatientBirthYear,(year(getdate())-b.PatientBirthyear) PatientAge, (case b.PatientGender when 0 then N'Nữ' else 'Nam' end) PatientGenderName,a.Address,a3.WardName,a2.DistrictName,a1.ProvincialName,b.PatientMobile,c.ObjectName,d.EmployeeName,a.ObjectCode,a.ReferenceCode,a.PatientType,a.OrderNumber
		from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode left join Catalog_Provincial a1 on a.ProvincialCode=a1.ProvincialCode left join Catalog_District a2 on a.DistrictCode=a2.DistrictCode left join Catalog_Ward a3 on a.WardCode=a3.WardCode inner join Object c on a.ObjectCode=c.ObjectCode inner join Employee d on a.EmployeeCode=d.EmployeeCode
		where CONVERT(date,a.CreateDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) and a.PatientReceiveID in( select RefID from SuggestedServiceReceipt where CONVERT(date,WorkDate,103) between CONVERT(date,@FromDate,103) and CONVERT(date,@ToDate,103) and ServiceCode<>'DV000000')
	end
end
go
if exists(select name from sysobjects where name = 'pro_ViewCountPatientReceive')
 drop procedure pro_ViewCountPatientReceive
go
create procedure pro_ViewCountPatientReceive
as
begin
	select a.PatientCode,c.PatientName,c.PatientBirthyear,c.PatientAddress,c.PatientMobile,COUNT(b.ServiceCode) Quantity,(case when c.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGender
	from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID inner join [Service] b1 on b.ServiceCode=b1.ServiceCode
	inner join ServiceCategory b2 on b1.ServiceCategoryCode=b2.ServiceCategoryCode inner join Patients c on a.PatientCode=c.PatientCode
	where b2.ServiceGroupCode='KCB'
	group by a.PatientCode,c.PatientName,c.PatientBirthyear,c.PatientAddress,c.PatientMobile,c.PatientGender
	order by PatientCode
end
go
IF NOT EXISTS (SELECT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ServiceGroupPrint')
begin
CREATE TABLE ServiceGroupPrint
(
	ID int IDENTITY(1,1) NOT NULL primary key,
	GroupName nvarchar(300) NULL
)
end
go
if exists(select name from sysobjects where name = 'proIU_ServiceGroupPrint')
 drop procedure proIU_ServiceGroupPrint
go
create proc proIU_ServiceGroupPrint
(
	@ID int,
	@GroupName nvarchar(300)
)
as
begin tran
	if @ID = 0
		INSERT INTO ServiceGroupPrint(GroupName) VALUES(@GroupName)
	else
		update ServiceGroupPrint set GroupName =@GroupName	where ID = @ID
commit tran
go
if exists(select name from sysobjects where name = 'proDel_ServiceGroupPrint')
 drop procedure proDel_ServiceGroupPrint
go
create procedure proDel_ServiceGroupPrint
(
	@ID int,
	@iresult int output
)
as
begin
	if exists(select IDGroupPrint from [Service] where IDGroupPrint =@ID)
		set @iresult =-1
	else
	begin
		delete ServiceGroupPrint where ID = @ID
		set @iresult =1
	end
end
go
------------------ Create table Check chi phi BHYT
--IF NOT EXISTS (SELECT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'BanksAccount_BV01')
--begin
--CREATE TABLE BanksAccount_BV01
--(
--	RowID decimal(20,0) identity(1,1),
--	PatientReceiveID numeric(18,0) not null default 0,
--	PatientCode varchar(15) not null,
--	TotalAmount_BHYT decimal(18,3),
--	TotalAmount_BHYT_Pay decimal(18,3),
--	TotalAmount_Patient_Pay decimal(18,3),
--	EmployeeCode varchar(15),
--	WorkDate datetime default getdate(),
--	CONSTRAINT pk_BanksAccount_BV01 PRIMARY KEY (RowID)
--)
--end
--go
--if exists(select name from sysobjects where name ='proIUReportDiscount')
--	drop procedure proIUReportDiscount
--go
--create procedure proIUReportDiscount
--(
--	@ReceiptID numeric(18,0),
--	@PatientReceiveID numeric(18,0),
--	@PatientCode varchar(15),
--	@ServiceCode varchar(15),
--	@ServicePrice numeric(18,2),
--	@ServicePriceOverTime numeric(18,2),
--	@DiscountAmount numeric(18,2),
--	@DiscountPer int,
--	@ReceiveDate datetime,
--	@IntroName nvarchar(200),
--	@ShiftWork char(2),
--	@Status int,
--	@EmployeeCode varchar(15),
--	@Result smallint output
--)
--as
--begin
--	set @IntroName=upper(@IntroName)
--	if( exists(select PatientCode from ReportDiscount where ReceiptID=@ReceiptID) and @Status=0)
--		begin
--			delete from ReportDiscount where ReceiptID=@ReceiptID
--			update SuggestedServiceReceipt set ConfirmDiscountIntro=0 where ReceiptID=@ReceiptID
--			set @Result =1
--		end
--	else if(exists(select PatientCode from ReportDiscount where ReceiptID=@ReceiptID) and @Status=1)
--		begin
--			update ReportDiscount set PatientReceiveID=@PatientReceiveID,PatientCode=@PatientCode,ServiceCode=@ServiceCode,ServicePrice=@ServicePrice,ServicePriceOverTime=@ServicePriceOverTime,
--			DiscountAmount=@DiscountAmount,DiscountPer=@DiscountPer,ReceiveDate=@ReceiveDate,IntroName=@IntroName,WorkDate=GETDATE(),ShiftWork=@ShiftWork,EmployeeCode=@EmployeeCode where ReceiptID=@ReceiptID 
--			update SuggestedServiceReceipt set ConfirmDiscountIntro=@Status,DiscountIntro=@DiscountAmount,IntroName=@IntroName where ReceiptID=@ReceiptID
--			set @Result =1
--		end
--	else if(@Status=1)
--		begin
--			insert into ReportDiscount(ReceiptID,PatientReceiveID,PatientCode,ServiceCode,ServicePrice,ServicePriceOverTime,DiscountAmount,DiscountPer,ReceiveDate,IntroName,WorkDate,ShiftWork,EmployeeCode) 
--			values(@ReceiptID,@PatientReceiveID,@PatientCode,@ServiceCode,@ServicePrice,@ServicePriceOverTime,@DiscountAmount,@DiscountPer,@ReceiveDate,@IntroName,GETDATE(),@ShiftWork,@EmployeeCode)
--			update SuggestedServiceReceipt set ConfirmDiscountIntro=@Status,DiscountIntro=@DiscountAmount,IntroName=@IntroName where ReceiptID=@ReceiptID
--			set @Result =1
--		end
--	else
--		set @Result =1
--end
--go
