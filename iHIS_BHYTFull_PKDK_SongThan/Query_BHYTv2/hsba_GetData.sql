if not exists(SELECT COLUMN_NAME FROM   INFORMATION_SCHEMA.COLUMNS WHERE  TABLE_NAME ='PatientReceive' AND COLUMN_NAME = 'ConfirmHSBA')
	alter table PatientReceive add ConfirmHSBA int default 0 not null
go
if not exists(SELECT COLUMN_NAME FROM   INFORMATION_SCHEMA.COLUMNS WHERE  TABLE_NAME ='ServicePrice' AND COLUMN_NAME = 'UnitPriceRoot')
	alter table ServicePrice add UnitPriceRoot numeric(18,2) default 0 not null
go
if not exists(select name from sys.columns where Name = N'DenominationID' and Object_ID = Object_ID(N'PatientReceive'))
	alter table PatientReceive add DenominationID int default 0 not null
go
if not exists(select name from sys.columns where Name = N'UnitPriceRoot' and Object_ID = Object_ID(N'SuggestedServiceReceipt'))
	alter table SuggestedServiceReceipt add UnitPriceRoot numeric(18,2) default 0 not null
go
if not exists(select name from sys.columns where Name = N'Content' and Object_ID = Object_ID(N'SuggestedServiceReceipt'))
	alter table SuggestedServiceReceipt add Content nvarchar(200)
go
if not exists(SELECT COLUMN_NAME FROM   INFORMATION_SCHEMA.COLUMNS WHERE  TABLE_NAME ='ServiceRadiologyEntry' AND COLUMN_NAME = 'Diagnosis')
	alter table ServiceRadiologyEntry add Diagnosis nvarchar(250) 
go
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CatalogDenomination]') AND type in (N'U'))
begin
CREATE TABLE CatalogDenomination
(
	DenominationID int,
	DenominationName nvarchar(250)
	CONSTRAINT pk_Denomination PRIMARY KEY(DenominationID)
)
end
go
/*
insert into CatalogDenomination(DenominationID,DenominationName) values(0,N'Không')
insert into CatalogDenomination(DenominationID,DenominationName) values(1,N'Thiên Chúa')
*/
--go
------------------------- Dong Add HSBA
if exists(select name from sysobjects where name ='prohsba_GetPatients')
	drop procedure prohsba_GetPatients
go
create procedure prohsba_GetPatients
(
	@PatientCode varchar(15)
)
as
begin
	select a.PatientCode,a1.EThnicName,a2.CareerName,a3.NationalityName,a4.ProvincialName,a5.DistrictName,a6.WardName,a.PatientAddress,a.PatientName,a.PatientGender,a.PatientBirthDay,a.PatientAge,a.PatientMobile,a.PatientEmail,a.MedicalHistory,a.Allergy,a.PatientImage,a.PatientMonth
	from Patients a left join Catalog_EThnic a1 on a.EThnicID=a1.EThnicID left join Career a2 on a.CareerCode=a2.CareerCode inner join Catalog_Nationality a3 on a.NationalityID=a3.NationalityID
	left join Catalog_Provincial a4 on a.ProvincialCode=a4.ProvincialCode left join Catalog_District a5 on a.DistrictCode=a5.DistrictCode left join Catalog_Ward a6 on a.WardCode=a6.WardCode
	where a.PatientCode=@PatientCode
end
go
if exists(select name from sysobjects where name ='prohsba_GetPatientReceive')
	drop procedure prohsba_GetPatientReceive
go
create procedure prohsba_GetPatientReceive
(
	@PatientReceiveID decimal(25,0)
)
as
begin
	select a.PatientReceiveID,a.PatientCode,a.Reason,a.CreateDate InDate, c.EmployeeName, a.ObjectCode,a.OutDate,a1.EThnicName,a2.CareerName,a3.NationalityName,a4.ProvincialName,
	a5.DistrictName,a6.WardName,a.CompanyInfo,a.Address as PatientAddress,a.IntroName,a.IDTypeReceive TypeReceiveID,a.OrderNumber,a7.DenominationName,'' ObjectExemptedName,a.ContentMedicalPattern
	,a8.Pulse,a8.Temperature,a8.BloodPressure,a8.BloodPressure1,a8.Weight as Weight_,a8.Hight,a8.Breath,a9.Serial,a9.KCBBDCodeFull KCBBDCode,a10.KCBBDName,CONVERT(char(10),a9.StartDate,103) StartDate,CONVERT(char(10),a9.EndDate,103) EndDate,a9.TraiTuyen
	from PatientReceive a inner join Employee c on a.EmployeeCode=c.EmployeeCode
	left join Catalog_EThnic a1 on a.EThnicID=a1.EThnicID left join Career a2 on a.CareerCode=a2.CareerCode inner join Catalog_Nationality a3 on a.NationalityID=a3.NationalityID
	left join Catalog_Provincial a4 on a.ProvincialCode=a4.ProvincialCode left join Catalog_District a5 on a.DistrictCode=a5.DistrictCode left join Catalog_Ward a6 on a.WardCode=a6.WardCode
	left join CatalogDenomination a7 on a.DenominationID=a7.DenominationID left join SurviveSign a8 on a.PatientReceiveID=a8.RefID and a.ReferenceCode=a8.ReferenceCode left join BHYT a9 on a.PatientReceiveID=a9.PatientReceiveID and a.PatientCode=a9.PatientCode and hide=0 left join KCBBD a10 on a9.KCBBDCodeFull=a10.ProvincialIDBHYT+'-'+a10.KCBBDCode
	where a.PatientReceiveID=@PatientReceiveID
end
go
if exists(select name from sysobjects where name ='prohsba_GetSuggestedServiceReceipt')
	drop procedure prohsba_GetSuggestedServiceReceipt
go
create procedure prohsba_GetSuggestedServiceReceipt
(
	@PatientReceiveID decimal(25,0),
	@PatientCode varchar(15)
)
as
begin
	select a.ReceiptID SuggestedReceiptID,RefID PatientReceiveID, b.ServiceName,a.ServicePrice,a.DisparityPrice,a.UnitPriceRoot,a.PatientCode,
	a.Status Status_,a.Paid,c.EmployeeName,a.Note,a.ObjectCode,a.PatientType,a.WorkDate,a.STT as OrderNumber,d.EmployeeName EmployeeNameDoctor,
	e.DepartmentName,f.DepartmentName DepartmentNameOrder,a.AmountExemption,a.Quantity,a.Content,b1.UnitOfMeasureName,b2.ServiceCategoryName,b3.ServiceGroupName,b3.ServiceModuleCode
	from SuggestedServiceReceipt a inner join Service b on a.ServiceCode=b.ServiceCode 
	left join Employee c on a.EmployeeCode=c.EmployeeCode left join Employee d on a.EmployeeCodeDoctor=d.EmployeeCode
	inner join Department e on a.DepartmentCode = e.DepartmentCode inner join Department f on a.DepartmentCodeOrder = f.DepartmentCode
	inner join UnitOfMeasure b1 on b.UnitOfMeasureCode=b1.UnitOfMeasureCode inner join ServiceCategory b2 on b.ServiceCategoryCode=b2.ServiceCategoryCode inner join ServiceGroup b3 on b2.ServiceGroupCode=b3.ServiceGroupCode
	where a.RefID=@PatientReceiveID and PatientCode=@PatientCode
end
go
if exists(select name from sysobjects where name ='prohsba_GetReceiveCocumentImage')
	drop procedure prohsba_GetReceiveCocumentImage
go
create procedure prohsba_GetReceiveCocumentImage
(
	@PatientReceiveID decimal(25,0)
)
as
begin
	 select PatientReceiveID,Note,Image,STT from PatientReceiveCocumentImage where PatientReceiveID=@PatientReceiveID
end
go
if exists(select name from sysobjects where name ='prohsba_GetMedicalRecord')
	drop procedure prohsba_GetMedicalRecord
go
create procedure prohsba_GetMedicalRecord
(
	@PatientReceiveID decimal(25,0),
	@PatientCode varchar(15)
)
as
begin
	select a.MedicalRecordCode,a.PatientReceiveID,a.PatientCode,b.DepartmentName,c.EmployeeName,(d.DiagnosisName+' ('+d.DiagnosisCode+')') DiagnosisName, a.DescriptionNode, a.PostingDate,a.AppointmentDate,a.Symptoms,a.ObjectCode,
	a.Advices,[dbo].func_DiagnosisEnclosed(a.MedicalRecordCode) IDC10KT,e.TackleName,f.EmployeeName EmployeeNameDoctor,a.DiagnosisCustom,a.Treatments,a1.Pulse,a1.Temperature,a1.BloodPressure,a1.BloodPressure1,a1.Weight Weight_,a1.Hight,a1.Breath,a.ReceiptID as SuggestedReceiptID
	from MedicalRecord a inner join Department b on a.DepartmentCode=b.DepartmentCode inner join Employee c on a.EmployeeCode=c.EmployeeCode
	left join Diagnosis d on a.DiagnosisCode = d.RowID left join Tackle e on a.TackleCode=e.TackleCode left join Employee f on a.EmployeeCodeDoctor=f.EmployeeCode
	left join SurviveSign a1 on a.PatientReceiveID = a1.RefID and a.MedicalRecordCode=a1.ReferenceCode
	where a.PatientReceiveID=@PatientReceiveID and a.PatientCode=@PatientCode
end
go
if exists(select name from sysobjects where name ='prohsba_GetMedicalRecordDetail')
	drop procedure prohsba_GetMedicalRecordDetail
go
create procedure prohsba_GetMedicalRecordDetail
(
	@PatientReceiveID decimal(25,0),
	@PatientCode varchar(15)
)
as
begin
	 select a.MedicalRecordCode,b1.ItemName,b.DateOfIssues,b.Morning,b.Noon,b.Afternoon,b.Evening,b.Quantity,b.Instruction,b.UnitPrice,b.Amount,b.ObjectCode,b.DoseOf,b.DoseOfPills,b2.ItemCategoryName,b3.GroupName,b4.UnitOfMeasureName,b1.Active,b1.ItemContent,a.PatientReceiveID
	 from MedicalRecord a inner join MedicalPrescriptionDetail b on a.MedicalRecordCode=b.MedicalRecordCode inner join Items b1 on b.ItemCode=b1.ItemCode inner join ItemCategory b2 on b1.ItemCategoryCode=b2.ItemCategoryCode
	 inner join ItemGroup b3 on b2.GroupCode=b3.GroupCode inner join UnitOfMeasure b4 on b1.UnitOfMeasureCode=b4.UnitOfMeasureCode
	 where a.PatientReceiveID=@PatientReceiveID and a.PatientCode=@PatientCode
end
go
if exists(select name from sysobjects where name ='prohsba_GetServiceRadiologyEntry')
	drop procedure prohsba_GetServiceRadiologyEntry
go
create procedure prohsba_GetServiceRadiologyEntry
(
	@PatientReceiveID decimal(25,0),
	@PatientCode varchar(15)
)
as
begin
	select a.RowID,a.PatientReceiveID,a.Contents,a.Conclusion,a.Proposal,a.PostingDate,b.EmployeeName,c.EmployeeName EmployeeNameDoctor,a.ServiceGroupCode,a.Note,a.Diagnosis,d.ServiceName,a.SuggestedID SuggestedReceiptID
	from ServiceRadiologyEntry a inner join Employee b on a.EmployeeCode=b.EmployeeCode inner join Employee c on a.EmployeeCodeDoctor=c.EmployeeCode inner join Service d on a.ServiceCode=d.ServiceCode
	where a.PatientReceiveID=@PatientReceiveID and a.PatientCode=@PatientCode
end
go
if exists(select name from sysobjects where name ='prohsba_GetServiceRadiologyDetail')
	drop procedure prohsba_GetServiceRadiologyDetail
go
create procedure prohsba_GetServiceRadiologyDetail
(
	@PatientReceiveID decimal(25,0),
	@PatientCode varchar(15)
)
as
begin
	select a.PatientReceiveID,b.RadiologyRowID,b.Image
	from ServiceRadiologyEntry a inner join ServiceRadiologyDetailEntry b on a.RowID=b.RadiologyRowID
	where a.PatientReceiveID=@PatientReceiveID and a.PatientCode=@PatientCode
end
go
if exists(select name from sysobjects where name ='prohsba_GetSurgeries')
	drop procedure prohsba_GetSurgeries
go
create procedure prohsba_GetSurgeries
(
	@PatientReceiveID decimal(25,0),
	@PatientCode varchar(15)
)
as
begin
	select a.PatientReceiveID,a.SurgeriesCode,a.DateOn,a.TimeOn,a.DateOut,a.TimeOut,('('+a1.DiagnosisCode+')'+a1.DiagnosisName) ICD10On,('('+a2.DiagnosisCode+')'+a2.DiagnosisName) ICD10Out,a3.Names AnesthesiaName,
	a4.Names ComplicationsName,a5.Names SituationName,a.Content,a.Note,a6.EmployeeName,a.ObjectCode,a.PatientType,a7.DepartmentName,a.DiagnosisCustomOn,a.DiagnosisCustomOut,b1.ServiceName,a.IDSuggested SuggestedReceiptID
	 from Surgeries a left join Diagnosis a1 on a.ICD10On=a1.RowID left join Diagnosis a2 on a.ICD10Out=a2.RowID
	 left join Catalog_Anesthesia a3 on a.IDAnesthesia=a3.RowID left join Catalog_Complications a4 on a.IDComplications=a4.RowID
	 left join Catalog_TheSituation a5 on a.IDTheSituation = a5.RowID inner join Employee a6 on a.EmployeeCode=a6.EmployeeCode 
	 inner join SuggestedServiceReceipt b on a.IDSuggested=b.ReceiptID inner join Service b1 on b.ServiceCode=b1.ServiceCode
	 inner join Department a7 on a.DepartmentCode=a7.DepartmentCode
	 where a.PatientReceiveID=@PatientReceiveID and a.PatientCode=@PatientCode
end
go
if exists(select name from sysobjects where name ='prohsba_GetSurgicalCrew')
	drop procedure prohsba_GetSurgicalCrew
go
create procedure prohsba_GetSurgicalCrew
(
	@PatientReceiveID decimal(25,0),
	@PatientCode varchar(15)
)
as
begin
	select a.PatientReceiveID,a.SurgeriesCode,b1.EmployeeName,b2.PositionName
	 from Surgeries a inner join SurgicalCrew b on a.SurgeriesCode=b.SurgeriesCode left join Employee b1 on b.EmployeeCode=b1.EmployeeCode left join EmployeePosition b2 on b.PositionCode=b2.PositionCode
	 where a.PatientReceiveID=@PatientReceiveID and a.PatientCode=@PatientCode
end
go
if exists(select name from sysobjects where name ='prohsba_GetLaboratoryEntry')
	drop procedure prohsba_GetLaboratoryEntry
go
create procedure prohsba_GetLaboratoryEntry
(
	@PatientReceiveID decimal(25,0),
	@PatientCode varchar(15)
)
as
begin
	select a.RowID IDLaboratoryEntry,a.PatientReceiveID,a.AppointmentDate,a.AppointmentNote,a.Conclusion,a.Proposal,a.PostingDate,a1.ServiceCategoryName,a.STT IDTemplate,a.ObjectCode,a2.EmployeeName,a.PostingDateResult,a3.DepartmentName DepartmentNameOrder,a.OrderDate
	,a4.EmployeeName EmployeeDoctorNameOrder, (case when a.Status=1 then N'Lấy Mẫu' when a.Status=2 then N'Có Kết Quả' else '' end) Status_
	from ServiceLaboratoryEntry a inner join ServiceCategory a1 on a.ServiceCategoryCode=a1.ServiceCategoryCode inner join Employee a2 on a.EmployeeCode=a2.EmployeeCode inner join Department a3 on a.DepartmentCodeOrder=a3.DepartmentCode
	inner join Employee a4 on a.EmployeeDoctorCodeOrder=a4.EmployeeCode
	 where a.PatientReceiveID=@PatientReceiveID and a.PatientCode=@PatientCode
end
go
if exists(select name from sysobjects where name ='prohsba_GetLaboratoryDetail')
	drop procedure prohsba_GetLaboratoryDetail
go
create procedure prohsba_GetLaboratoryDetail
(
	@PatientReceiveID decimal(25,0),
	@PatientCode varchar(15)
)
as
begin
	select a.PatientReceiveID,b.RowIDLaboratoryEnTry IDLaboratoryEntry,b1.ServiceName,b.UnitValues,b.ValuesEntry,b.ValuedFemale,b.ValuedMale,b.Normal,b.LaboratoryName,b.STT,b.SuggestedID SuggestedReceiptID
	from ServiceLaboratoryEntry a inner join ServiceLaboratoryDetail b on a.RowID=b.RowIDLaboratoryEnTry inner join Service b1 on b.ServiceCode=b1.ServiceCode
	 where a.PatientReceiveID=@PatientReceiveID and a.PatientCode=@PatientCode
end
go
if exists(select name from sysobjects where name ='prohsba_ViewKetQuaDieuTri')
	drop procedure prohsba_ViewKetQuaDieuTri
go
create procedure prohsba_ViewKetQuaDieuTri
(
	@PatientType int,
	@frDate char(10),
	@toDate char(10),
	@DepartmentCode varchar(50),
	@ConfirmHSBA int=0
)
as
begin
	if @PatientType<>-1
		begin
			if @DepartmentCode<>''
			begin
				select a.PatientCode,a.CreateDate,a1.PatientName,a1.PatientBirthyear,a1.PatientAge,(case when a1.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,
				b.Symptoms DiagnosisCode,(RTRIM(b1.DiagnosisCode) + ' - ' + RTRIM(b1.DiagnosisName)) DiagnosisNameIn,b2.ObjectName,(RTRIM(c.DiagnosisCode) + ' - ' + RTRIM(c.DiagnosisName)) DiagnosisNameOut,
				d.TackleName ResultsName,[dbo].func_PatientOfAddressFull(a.Address,wa.WardName,dis.DistrictName,pro.ProvincialName) PatientAddress,b.Advices AdvicesOut, 0 as Chon,a.PatientReceiveID
				 from PatientReceive a inner join Patients a1 on a.PatientCode=a1.PatientCode inner join MedicalRecord b on a.PatientReceiveID=b.PatientReceiveID
				 left join Diagnosis b1 on b.DiagnosisCode=b1.RowID inner join Object b2 on b.ObjectCode=b2.ObjectCode
				 left join Diagnosis c on b.DiagnosisCode=c.RowID
				 left join Tackle d on b.TackleCode=d.TackleCode
				 left join Catalog_District dis on a.DistrictCode=dis.DistrictCode left join Catalog_Provincial pro on
				 a.ProvincialCode=pro.ProvincialCode left join Catalog_Ward wa on a.WardCode=wa.WardCode
				 where a.PatientType=@PatientType and CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103) and b.DepartmentCode=@DepartmentCode and a.ConfirmHSBA=@ConfirmHSBA
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
				 where a.PatientType=@PatientType and CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103) and b.DepartmentCode=@DepartmentCode and a.ConfirmHSBA=@ConfirmHSBA
			 end
			 else
			 begin
				select a.PatientCode,a.CreateDate,a1.PatientName,a1.PatientBirthyear,a1.PatientAge,(case when a1.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,
				b.Symptoms DiagnosisCode,(RTRIM(b1.DiagnosisCode) + ' - ' + RTRIM(b1.DiagnosisName)) DiagnosisNameIn,b2.ObjectName,(RTRIM(c.DiagnosisCode) + ' - ' + RTRIM(c.DiagnosisName)) DiagnosisNameOut,
				d.TackleName ResultsName,[dbo].func_PatientOfAddressFull(a.Address,wa.WardName,dis.DistrictName,pro.ProvincialName) PatientAddress,b.Advices AdvicesOut, 0 as Chon,a.PatientReceiveID
				 from PatientReceive a inner join Patients a1 on a.PatientCode=a1.PatientCode inner join MedicalRecord b on a.PatientReceiveID=b.PatientReceiveID
				 left join Diagnosis b1 on b.DiagnosisCode=b1.RowID inner join Object b2 on b.ObjectCode=b2.ObjectCode
				 left join Diagnosis c on b.DiagnosisCode=c.RowID
				 left join Tackle d on b.TackleCode=d.TackleCode
				  left join Catalog_District dis on a.DistrictCode=dis.DistrictCode left join Catalog_Provincial pro on
				 a.ProvincialCode=pro.ProvincialCode left join Catalog_Ward wa on a.WardCode=wa.WardCode
				 where a.PatientType=@PatientType and CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103) and a.ConfirmHSBA=@ConfirmHSBA
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
				 where a.PatientType=@PatientType and CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103) and a.ConfirmHSBA=@ConfirmHSBA
			 end
		end
	else
		begin
			if @DepartmentCode<>''
				begin
					select a.PatientCode,a.CreateDate,a1.PatientName,a1.PatientBirthyear,a1.PatientAge,(case when a1.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,
				b.Symptoms DiagnosisCode,(RTRIM(b1.DiagnosisCode) + ' - ' + RTRIM(b1.DiagnosisName)) DiagnosisNameIn,b2.ObjectName,(RTRIM(c.DiagnosisCode) + ' - ' + RTRIM(c.DiagnosisName)) DiagnosisNameOut,
				d.TackleName ResultsName,[dbo].func_PatientOfAddressFull(a.Address,wa.WardName,dis.DistrictName,pro.ProvincialName) PatientAddress,b.Advices AdvicesOut, 0 as Chon,a.PatientReceiveID
				 from PatientReceive a inner join Patients a1 on a.PatientCode=a1.PatientCode inner join MedicalRecord b on a.PatientReceiveID=b.PatientReceiveID
				 left join Diagnosis b1 on b.DiagnosisCode=b1.RowID inner join Object b2 on b.ObjectCode=b2.ObjectCode
				 left join Diagnosis c on b.DiagnosisCode=c.RowID
				 left join Tackle d on b.TackleCode=d.TackleCode
				 left join Catalog_District dis on a.DistrictCode=dis.DistrictCode left join Catalog_Provincial pro on
				 a.ProvincialCode=pro.ProvincialCode left join Catalog_Ward wa on a.WardCode=wa.WardCode
				 where CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103) and b.DepartmentCode=@DepartmentCode and a.ConfirmHSBA=@ConfirmHSBA
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
				 where CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103) and b.DepartmentCode=@DepartmentCode and a.ConfirmHSBA=@ConfirmHSBA
				 end
			 else
				 begin
					select a.PatientCode,a.CreateDate,a1.PatientName,a1.PatientBirthyear,a1.PatientAge,(case when a1.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,
					b.Symptoms DiagnosisCode,(RTRIM(b1.DiagnosisCode) + ' - ' + RTRIM(b1.DiagnosisName)) DiagnosisNameIn,b2.ObjectName,(RTRIM(c.DiagnosisCode) + ' - ' + RTRIM(c.DiagnosisName)) DiagnosisNameOut,
					d.TackleName ResultsName,[dbo].func_PatientOfAddressFull(a.Address,wa.WardName,dis.DistrictName,pro.ProvincialName) PatientAddress,b.Advices AdvicesOut, 0 as Chon,a.PatientReceiveID
					 from PatientReceive a inner join Patients a1 on a.PatientCode=a1.PatientCode inner join MedicalRecord b on a.PatientReceiveID=b.PatientReceiveID
					 left join Diagnosis b1 on b.DiagnosisCode=b1.RowID inner join Object b2 on b.ObjectCode=b2.ObjectCode
					 left join Diagnosis c on b.DiagnosisCode=c.RowID
					 left join Tackle d on b.TackleCode=d.TackleCode
					  left join Catalog_District dis on a.DistrictCode=dis.DistrictCode left join Catalog_Provincial pro on
				 a.ProvincialCode=pro.ProvincialCode left join Catalog_Ward wa on a.WardCode=wa.WardCode
					 where CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103) and a.ConfirmHSBA=@ConfirmHSBA
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
					 where CONVERT(date,a.CreateDate,103) between CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103) and a.ConfirmHSBA=@ConfirmHSBA
				 end
		end
end
go