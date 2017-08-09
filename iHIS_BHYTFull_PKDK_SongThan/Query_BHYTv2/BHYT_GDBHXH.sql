----------- Update Ngay 10/03/2017
IF NOT EXISTS (SELECT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Items_BHYT_Active')
begin
CREATE TABLE Items_BHYT_Active
(
	RowID int,
	Active_Code varchar(15),
	Active_Name nvarchar(max),
	Note nvarchar(max),
	STT int not null default 0,
	CONSTRAINT pk_Items_BHYT_Active PRIMARY KEY (RowID)
)
end
go
IF NOT EXISTS (SELECT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Usage_BHYT')
begin
CREATE TABLE Usage_BHYT(
	UsageCode varchar(10) NOT NULL,
	UsageName nvarchar(max) not NULL,
	STT int NOT NULL DEFAULT (0),
	CONSTRAINT pk_Usage_BHYT PRIMARY KEY (UsageCode)
)
end
GO
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ReportBHYTDetail' and b.name='ServiceCode_PK')
	alter table ReportBHYTDetail add ServiceCode_PK varchar(20) not null default ''
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ReportBHYTDetail' and b.name='SODKGP')
	alter table ReportBHYTDetail add SODKGP varchar(25) not null default ''
go
--- Portal GDBHXH
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ClinicInformation' and b.name='UserName_BV')
	alter table ClinicInformation add UserName_BV nvarchar(20) not null default ''
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ClinicInformation' and b.name='PassWord_BV')
	alter table ClinicInformation add PassWord_BV varchar(50) not null default ''
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ClinicInformation' and b.name='UserName_TC')
	alter table ClinicInformation add UserName_TC nvarchar(20) not null default ''
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ClinicInformation' and b.name='PassWord_TC')
	alter table ClinicInformation add PassWord_TC varchar(50) not null default ''
go
---Update proc: pro_Ins_ClinicInformation
--- End Portal GDBHXH
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ReportBHYT' and b.name='ICD10_Custom')
	alter table ReportBHYT add ICD10_Custom varchar(20) not null default ''
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='ReportBHYT' and b.name='ICD10Name_Custom')
	alter table ReportBHYT add ICD10Name_Custom nvarchar(500) not null default ''
go
if exists(select name from sysobjects where name ='BCTE')
	drop procedure BCTE
go
create procedure BCTE
	@frDate char(10),
	@toDate char(10)
as
begin
select p.patientname,CONVERT(date,(case when p.patientgender=0 then p.PatientBirthday else null end),103) as patientgender1, CONVERT(date,(case when p.patientgender=1 then p.PatientBirthday else null end),103) as patientgender2 , 
CONVERT(date,p.patientbirthday,103) as patientbirthday, [dbo].func_PatientOfAddressFull(p.PatientAddress,w.WardName,d.DistrictName,pr.ProvincialName) as diachi, 
p.TenCha, p.NSCha, p.TenMe, p.NSMe, r.BHYTPay,CONVERT(date, r.dateinto, 103) as dateinto, CONVERT(date,r.dateout,103) as dateout
from Patients p inner join ReportBHYT r on p.Patientcode = r.Patientcode inner join Catalog_Ward w
on p.WardCode = w.WardCode inner join Catalog_District d on p.DistrictCode = d.DistrictCode inner join
Catalog_Provincial pr on p.ProvincialCode = pr.ProvincialCode and DateDiff( year , p.patientbirthday , r.DateOut) <= 6 and (p.TenCha <> '' or p.TenMe <> '')
where CONVERT(date, r.DateOut,103) >= CONVERT(date,@frDate,103) and CONVERT(date,@toDate,103) >= CONVERT(date, r.DateOut,103)
end
GO
if exists(select name from sysobjects where name ='pro_Bang1_9324')
	drop procedure pro_Bang1_9324
go
CREATE procedure pro_Bang1_9324
(
	@frDate char(10),
	@toDate char(10),
	@ReportID varchar(20)=''
)
as
begin
 select  rpbh.ReportID as MA_LK, ROW_NUMBER() OVER(ORDER BY rpbh.ReportID DESC) as STT 
, p.PatientCode as MA_BN, p.PatientName as HO_TEN, REPLACE( CONVERT(varchar, p.PatientBirthday, 102),'.','')   as NGAY_SINH ,(case when p.PatientGender = '1' then '1' else '2' end) GIOI_TINH,
[dbo].func_PatientOfAddressFull(p.PatientAddress,w.WardName,d.DistrictName,pr.ProvincialName)
as DIA_CHI, rpbh.Serial as MA_THE,
REPLACE(REPLACE( rpbh.KCBBDCode,'-' ,''),' ','') as MA_DKBD,REPLACE( CONVERT(varchar, rpbh.StartDate, 102),'.','')   as GT_THE_TU,  REPLACE( CONVERT(varchar, rpbh.EndDate, 102),'.','') as GT_THE_DEN
--,dia.DiagnosisName as TEN_BENH ,dia.DiagnosisCode as MA_BENH
,rpbh.ICD10Name_Custom as TEN_BENH,rpbh.ICD10_Custom as MA_BENH
,[dbo].func_DiagnosisEnclosedMore(rpbh.ICD10More) as MA_BENHKHAC,
(case when rpbh.TraiTuyen = '0' then '1' else '3' end) MA_LYDO_VVIEN,
REPLACE(REPLACE( rpbh.KCBBDCode,'-',''),' ','') as MA_NOI_CHUYEN, rpbh.MATNTT as MA_TAI_NAN, CONVERT(varchar, rpbh.DateInto, 112)+left(REPLACE(CONVERT(varchar, rpbh.DateInto, 108),':',''),4) as NGAY_VAO,
CONVERT(varchar, rpbh.DateOut, 112)+left(REPLACE(CONVERT(varchar, rpbh.DateOut, 108),':',''),4) as NGAY_RA, DATEDIFF (day, rpbh.DateInto, rpbh.DateOut)+1 as SO_NGAY_DTRI,
rpbh.IDTreatmentResults as KET_QUA_DTRI, rpbh.MATTRV as TINH_TRANG_RV, CONVERT(varchar, rpbh.DateOut, 112)+left(REPLACE(CONVERT(varchar, rpbh.DateOut, 108),':',''),4) as NGAY_TTOAN, (case when (rpbh.TongBH)<=181500 then 100 else rpbh.RateBHYT end) as MUC_HUONG, 
  ( case when (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Items sv, ItemCategory itc, ItemGroup itg, ServiceGroup_BHYT srbh where rbh.ReportID = rpbh.ReportID and sv.ItemCode=rbh.ServiceCode and
  sv.ItemCategoryCode = itc.ItemCategoryCode and itc.GroupCode=itg.GroupCode and srbh.GroupID=itg.GroupID_BHYT and  srbh.Abbreviations = 'THUOCBH' and rbh.ObjectCode = 1
 ) is null then 0 else  (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Items sv, ItemCategory itc, ItemGroup itg,ServiceGroup_BHYT srbh where rbh.ReportID = rpbh.ReportID and sv.ItemCode=rbh.ServiceCode and
  sv.ItemCategoryCode = itc.ItemCategoryCode and itc.GroupCode=itg.GroupCode and srbh.GroupID=itg.GroupID_BHYT and  srbh.Abbreviations = 'THUOCBH' and rbh.ObjectCode = 1
 )   end)as T_THUOC,	
  ( case when (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Items sv, ItemCategory itc, ItemGroup itg, ServiceGroup_BHYT srbh where rbh.ReportID = rpbh.ReportID and sv.ItemCode=rbh.ServiceCode and
  sv.ItemCategoryCode = itc.ItemCategoryCode and itc.GroupCode=itg.GroupCode and srbh.GroupID=itg.GroupID_BHYT and  srbh.Abbreviations = 'VTYTBH' and rbh.ObjectCode = 1
 ) is null then 0 else  (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Items sv, ItemCategory itc, ItemGroup itg,ServiceGroup_BHYT srbh where rbh.ReportID = rpbh.ReportID and sv.ItemCode=rbh.ServiceCode and
  sv.ItemCategoryCode = itc.ItemCategoryCode and itc.GroupCode=itg.GroupCode and srbh.GroupID=itg.GroupID_BHYT and  srbh.Abbreviations = 'VTYTBH' and rbh.ObjectCode = 1
 )   end)as T_VTYT, 
  round(rpbh.TongBH,0) as T_TONGCHI, round(rpbh.BNTraBH,0) as T_BNTT , round(rpbh.BHYTPay,0) as T_BHTT,
 0 as T_NGUONKHAC, 0 as T_NGOAIDS, YEAR(CONVERT(date, rpbh.DateOut ,103)) as NAM_QT, month(CONVERT(date, rpbh.DateOut ,103)) as THANG_QT, 1 as MA_LOAI_KCB,
dpm.KBHYT as MA_KHOA, (select REPLACE(REPLACE( KCBBDCode,'-' ,''),' ','')  from ClinicInformation) as MA_CSKCB, '' as MA_KHUVUC, '' as MA_PTTT_QT, '' as CAN_NANG
 from Patients p inner join ReportBHYT rpbh on p.PatientCode=rpbh.PatientCode left join Catalog_Provincial pr on
 p.ProvincialCode=pr.ProvincialCode left join Catalog_Ward w on p.WardCode=w.WardCode left join Catalog_District d on
 p.DistrictCode=d.DistrictCode inner join Department dpm on rpbh.DepartmentCode=dpm.DepartmentCode 
 --inner join Diagnosis dia on rpbh.ICD10=dia.RowID 
where rpbh.ObjectCode=1 and CONVERT(date, rpbh.DateOut ,103) between  CONVERT(date,@frDate,103) and CONVERT(date, @toDate ,103) and rpbh.ReportID=(case when @ReportID='' then rpbh.ReportID else @ReportID end) and rpbh.Cancel = 0
end
GO
--- ok
if exists(select name from sysobjects where name ='pro_Bang2_9324')
	drop procedure pro_Bang2_9324
go
create procedure pro_Bang2_9324
(
	@frDate char(10),
	@toDate char(10),
	@ReportID varchar(20)=''
)
as
begin
select r.ReportID as MA_LK, ROW_NUMBER() OVER(ORDER BY r.ReportID DESC) as STT,i.Active_TT40 as MA_THUOC, sm.STT as MA_NHOM , i.ItemName as TEN_THUOC,un.UnitOfMeasureName as DON_VI_TINH, i.ItemContent as HAM_LUONG,
usbh.UsageName as DUONG_DUNG, '' as LIEU_DUNG, i.SODKGP as SO_DANG_KY, rd.Quantity as SO_LUONG, rd.ServicePrice as DON_GIA, i.RateBHYT as TYLE_TT, round(rd.Amount,0) as THANH_TIEN
,d.KBHYT as MA_KHOA,''as MA_BAC_SI,  [dbo].func_DiagnosisEnclosedMore(r.ICD10)+ [dbo].func_DiagnosisEnclosedMore(r.ICD10More)as MA_BENH,  CONVERT(varchar, r.DateOut, 112)+left(REPLACE(CONVERT(varchar, r.DateOut, 108),':',''),4) as NGAY_YL, '' as MA_PTTT
from Patients p inner join ReportBHYT r on r.PatientCode = p.PatientCode inner join Department d on r.DepartmentCode=d.DepartmentCode
inner join ReportBHYTDetail rd on r.ReportID=rd.ReportID inner join Items i on i.ItemCode = rd.ServiceCode inner join ItemCategory it
on i.ItemCategoryCode=it.ItemCategoryCode inner join ItemGroup ig on it.GroupCode=ig.GroupCode inner join ServiceModule sm on ig.ServiceModuleCode = sm.ServiceModuleCode
inner join UnitOfMeasure un on i.UnitOfMeasureCode=un.UnitOfMeasureCode inner join Usage us on i.UsageCode=us.UsageCode  left join Usage_BHYT usbh on us.BHYT_MaDuongDung=usbh.UsageCode
where r.Cancel = 0 and rd.ObjectCode=1 and CONVERT(date, r.DateOut ,103) between  CONVERT(date,@frDate,103) and CONVERT(date, @toDate ,103) and r.ReportID=(case when @ReportID='' then r.ReportID else @ReportID end)
end
GO
--- ok
if exists(select name from sysobjects where name ='pro_Bang3_9324')
	drop procedure pro_Bang3_9324
go
create procedure pro_Bang3_9324
(
	@frDate char(10),
	@toDate char(10),
	@ReportID varchar(20)=''
)
as
begin
select r.ReportID as MA_LK, ROW_NUMBER() OVER(ORDER BY r.ReportID DESC) as STT, s.MaDK_BHYT as MA_DICH_VU, '' as MA_VAT_TU, sg.STT as MA_NHOM, s.ServiceName as TEN_DICH_VU,
un.UnitOfMeasureName as DON_VI_TINH, rd.Quantity as SO_LUONG,rd.ServicePrice as DON_GIA, 100 as TYLE_TT,round(rd.Amount,0) as THANH_TIEN,
d.KBHYT as MA_KHOA, '' as MA_BAC_SI,  
[dbo].func_DiagnosisEnclosedMore(r.ICD10) + [dbo].func_DiagnosisEnclosedMore(r.ICD10More) as MA_BENH,
CONVERT(varchar, r.DateInto, 112)+left(REPLACE(CONVERT(varchar, r.DateInto, 108),':',''),4) as NGAY_YL, CONVERT(varchar, r.DateOut, 112)+left(REPLACE(CONVERT(varchar, r.DateOut, 108),':',''),4) as NGAY_KQ, '' as MA_PTTT
 from Service s inner join ReportBHYTDetail rd on rd.ServiceCode = s.ServiceCode inner join ReportBHYT r on r.ReportID=rd.ReportID
inner join UnitOfMeasure un on un.UnitOfMeasureCode=s.UnitOfMeasureCode inner join ServiceGroup sg on sg.ServiceGroupCode=s.ServiceGroupCode
inner join Department d on r.DepartmentCode = d.DepartmentCode
left join Service_BHYT srbh on s.MaTuongDuong_BHYT=srbh.MaTuongDuong
where rd.ObjectCode =1 and r.Cancel = 0 and CONVERT(date, r.DateOut ,103) between  CONVERT(date,@frDate,103) and CONVERT(date, @toDate ,103) and r.ReportID=(case when @ReportID='' then r.ReportID else @ReportID end)
end
GO
-- ok
if exists(select name from sysobjects where name ='pro_BM_79a')
	drop procedure pro_BM_79a
go
CREATE procedure pro_BM_79a
(
	@frDate char(10),
	@toDate char(10)
)
as
begin
 select p.PatientName as hoten, (case when p.PatientGender = 1 then p.PatientBirthyear else '' end ) as namsinhnam ,
(case when p.PatientGender = 0 then p.PatientBirthyear else '' end ) as namsinhnu, rpbh.Serial as mathebhyt,
REPLACE(REPLACE( rpbh.KCBBDCode,'-' ,''),' ','') as madkbd, dia.DiagnosisCode as mabenh,
CONVERT(varchar, rpbh.DateInto, 112)+left(REPLACE(CONVERT(varchar, rpbh.DateInto, 108),':',''),4) as ngay_vao,

 round(rpbh.TongBH,0) as tongtien, 
  ( case when (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Service sv, ServiceCategory sc ,ServiceGroup sg, ServiceGroup_BHYT sgbh where rbh.ReportID = rpbh.ReportID and sv.ServiceCode=rbh.ServiceCode and
  sv.ServiceCategoryCode=sc.ServiceCategoryCode and sc.ServiceGroupCode=sg.ServiceGroupCode and sg.GroupID_BHYT=sgbh.GroupID and 
  sgbh.Abbreviations= 'XN' and rbh.ObjectCode = 1
 ) is null then 0 else  (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Service sv, ServiceCategory sc ,ServiceGroup sg, ServiceGroup_BHYT sgbh where rbh.ReportID = rpbh.ReportID and sv.ServiceCode=rbh.ServiceCode and
    sv.ServiceCategoryCode=sc.ServiceCategoryCode and sc.ServiceGroupCode=sg.ServiceGroupCode and sg.GroupID_BHYT=sgbh.GroupID and 
  sgbh.Abbreviations= 'XN' and rbh.ObjectCode = 1)   end)as xn,

 ( case when (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Service sv, ServiceCategory sc ,ServiceGroup sg, ServiceGroup_BHYT sgbh where rbh.ReportID = rpbh.ReportID and sv.ServiceCode=rbh.ServiceCode and
   sv.ServiceCategoryCode=sc.ServiceCategoryCode and sc.ServiceGroupCode=sg.ServiceGroupCode and sg.GroupID_BHYT=sgbh.GroupID and 
  sgbh.Abbreviations= 'CDHA' and rbh.ObjectCode = 1
 ) is null then 0 else  (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Service sv, ServiceCategory sc ,ServiceGroup sg, ServiceGroup_BHYT sgbh where rbh.ReportID = rpbh.ReportID and sv.ServiceCode=rbh.ServiceCode and
  sv.ServiceCategoryCode=sc.ServiceCategoryCode and sc.ServiceGroupCode=sg.ServiceGroupCode and sg.GroupID_BHYT=sgbh.GroupID and 
  sgbh.Abbreviations= 'CDHA' and rbh.ObjectCode = 1)   end)as cdha,

 ( case when (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Items sv, ItemCategory itc, ItemGroup itg, ServiceGroup_BHYT srbh where rbh.ReportID = rpbh.ReportID and sv.ItemCode=rbh.ServiceCode and
  sv.ItemCategoryCode = itc.ItemCategoryCode and itc.GroupCode=itg.GroupCode and srbh.GroupID=itg.GroupID_BHYT and  srbh.Abbreviations = 'THUOCBH' and rbh.ObjectCode = 1
 ) is null then 0 else  (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Items sv, ItemCategory itc, ItemGroup itg,ServiceGroup_BHYT srbh where rbh.ReportID = rpbh.ReportID and sv.ItemCode=rbh.ServiceCode and
  sv.ItemCategoryCode = itc.ItemCategoryCode and itc.GroupCode=itg.GroupCode and srbh.GroupID=itg.GroupID_BHYT and  srbh.Abbreviations = 'THUOCBH' and rbh.ObjectCode = 1
 )   end)as thuocdich,	

   ( case when (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Items sv, ItemCategory itc, ItemGroup itg, ServiceGroup_BHYT srbh where rbh.ReportID = rpbh.ReportID and sv.ItemCode=rbh.ServiceCode and
  sv.ItemCategoryCode = itc.ItemCategoryCode and itc.GroupCode=itg.GroupCode and srbh.GroupID=itg.GroupID_BHYT and  srbh.Abbreviations = 'MAU' and rbh.ObjectCode = 1
 ) is null then 0 else  (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Items sv, ItemCategory itc, ItemGroup itg,ServiceGroup_BHYT srbh where rbh.ReportID = rpbh.ReportID and sv.ItemCode=rbh.ServiceCode and
  sv.ItemCategoryCode = itc.ItemCategoryCode and itc.GroupCode=itg.GroupCode and srbh.GroupID=itg.GroupID_BHYT and  srbh.Abbreviations = 'MAU' and rbh.ObjectCode = 1
 )   end) as mau,

 ( case when (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Service sv, ServiceCategory sc ,ServiceGroup sg, ServiceGroup_BHYT sgbh where rbh.ReportID = rpbh.ReportID and sv.ServiceCode=rbh.ServiceCode and
  sv.ServiceCategoryCode=sc.ServiceCategoryCode and sc.ServiceGroupCode=sg.ServiceGroupCode and sg.GroupID_BHYT=sgbh.GroupID and 
  sgbh.Abbreviations= 'TTPT' and rbh.ObjectCode = 1
 ) is null then 0 else  (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Service sv, ServiceCategory sc ,ServiceGroup sg, ServiceGroup_BHYT sgbh where rbh.ReportID = rpbh.ReportID and sv.ServiceCode=rbh.ServiceCode and
  sv.ServiceCategoryCode=sc.ServiceCategoryCode and sc.ServiceGroupCode=sg.ServiceGroupCode and sg.GroupID_BHYT=sgbh.GroupID and 
  sgbh.Abbreviations= 'TTPT' and rbh.ObjectCode = 1)   end)as pttt,

 ( case when (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Items sv, ItemCategory itc, ItemGroup itg, ServiceGroup_BHYT srbh where rbh.ReportID = rpbh.ReportID and sv.ItemCode=rbh.ServiceCode and
  sv.ItemCategoryCode = itc.ItemCategoryCode and itc.GroupCode=itg.GroupCode and srbh.GroupID=itg.GroupID_BHYT and  srbh.Abbreviations = 'VTYTBH' and rbh.ObjectCode = 1
 ) is null then 0 else  (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Items sv, ItemCategory itc, ItemGroup itg,ServiceGroup_BHYT srbh where rbh.ReportID = rpbh.ReportID and sv.ItemCode=rbh.ServiceCode and
  sv.ItemCategoryCode = itc.ItemCategoryCode and itc.GroupCode=itg.GroupCode and srbh.GroupID=itg.GroupID_BHYT and  srbh.Abbreviations = 'VTYTBH' and rbh.ObjectCode = 1
 )   end)as vtth,

  0 as vttt,  0 as dvktc,  0 as tktg,

 ( case when (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Service sv, ServiceCategory sc ,ServiceGroup sg, ServiceGroup_BHYT sgbh where rbh.ReportID = rpbh.ReportID and sv.ServiceCode=rbh.ServiceCode and
  sv.ServiceCategoryCode=sc.ServiceCategoryCode and sc.ServiceGroupCode=sg.ServiceGroupCode and sg.GroupID_BHYT=sgbh.GroupID and 
  sgbh.Abbreviations= 'KB' and rbh.ObjectCode = 1
 ) is null then 0 else  (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Service sv, ServiceCategory sc ,ServiceGroup sg, ServiceGroup_BHYT sgbh where rbh.ReportID = rpbh.ReportID and sv.ServiceCode=rbh.ServiceCode and
  sv.ServiceCategoryCode=sc.ServiceCategoryCode and sc.ServiceGroupCode=sg.ServiceGroupCode and sg.GroupID_BHYT=sgbh.GroupID and 
  sgbh.Abbreviations= 'KB' and rbh.ObjectCode = 1)   end)as kcb,
  
 ( case when (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Service sv, ServiceCategory sc ,ServiceGroup sg, ServiceGroup_BHYT sgbh where rbh.ReportID = rpbh.ReportID and sv.ServiceCode=rbh.ServiceCode and
  sv.ServiceCategoryCode=sc.ServiceCategoryCode and sc.ServiceGroupCode=sg.ServiceGroupCode and sg.GroupID_BHYT=sgbh.GroupID and 
  sgbh.Abbreviations= 'VC' and rbh.ObjectCode = 1
 ) is null then 0 else  (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Service sv, ServiceCategory sc ,ServiceGroup sg, ServiceGroup_BHYT sgbh where rbh.ReportID = rpbh.ReportID and sv.ServiceCode=rbh.ServiceCode and
  sv.ServiceCategoryCode=sc.ServiceCategoryCode and sc.ServiceGroupCode=sg.ServiceGroupCode and sg.GroupID_BHYT=sgbh.GroupID and 
  sgbh.Abbreviations= 'VC' and rbh.ObjectCode = 1)   end)as vc ,

 round(rpbh.BNTraBH,0) as bncct , round(rpbh.BHYTPay,0) as tcbh, 0 as cpngoai,
 (
 case when (REPLACE(REPLACE( rpbh.KCBBDCode,'-' ,''),' ','')) = (select REPLACE(REPLACE( KCBBDCode,'-' ,''),' ','')  from ClinicInformation) 
 then N'A. BỆNH NHÂN NỘI TỈNH KCB BAN ĐẦU' else 
 case when left(rpbh.KCBBDCode,2) = (select left(KCBBDCode,2) from ClinicInformation) 
 then N'B. BỆNH NHÂN NỘI TỈNH ĐẾN' else N'C. BỆNH NHÂN NGOẠI TỈNH ĐẾN' end end
 ) as nhom,[dbo].func_DiagnosisEnclosedMore(rpbh.ICD10More) as kemtheo, YEAR(CONVERT(date, rpbh.DateOut ,103)) namqt, MONTH(CONVERT(date, rpbh.DateOut ,103)) thangqt,
 dpm.KBHYT as makhoa, 1 as maloaikcb,(select REPLACE(REPLACE( KCBBDCode,'-' ,''),' ','')  from ClinicInformation) as macskcb, '' makv
 from Patients p inner join ReportBHYT rpbh on p.PatientCode=rpbh.PatientCode left join Catalog_Provincial pr on
 p.ProvincialCode=pr.ProvincialCode left join Catalog_Ward w on p.WardCode=w.WardCode left join Catalog_District d on
 p.DistrictCode=d.DistrictCode inner join Department dpm on rpbh.DepartmentCode=dpm.DepartmentCode inner join 
 Diagnosis dia on rpbh.ICD10=dia.RowID and rpbh.Cancel = 0 and dpm.IdBv = 1
where CONVERT(date, rpbh.DateOut ,103) between  CONVERT(date,@frDate,103) and CONVERT(date, @toDate ,103)
end
GO
-- ok
if exists(select name from sysobjects where name ='pro_BM_80a')
	drop procedure pro_BM_80a
go
CREATE procedure pro_BM_80a
(
	@frDate char(10),
	@toDate char(10)
)
as
begin
  select p.PatientName as hoten, (case when p.PatientGender = 1 then p.PatientBirthyear else '' end ) as namsinhnam ,
(case when p.PatientGender = 0 then p.PatientBirthyear else '' end ) as namsinhnu, rpbh.Serial as mathebhyt,
REPLACE(REPLACE( rpbh.KCBBDCode,'-' ,''),' ','') as madkbd, dia.DiagnosisCode as mabenh,
CONVERT(varchar, rpbh.DateInto, 112)+left(REPLACE(CONVERT(varchar, rpbh.DateInto, 108),':',''),4) as ngay_vao,

 round(rpbh.TongBH,0) as tongtien, 
  ( case when (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Service sv, ServiceCategory sc ,ServiceGroup sg, ServiceGroup_BHYT sgbh where rbh.ReportID = rpbh.ReportID and sv.ServiceCode=rbh.ServiceCode and
  sv.ServiceCategoryCode=sc.ServiceCategoryCode and sc.ServiceGroupCode=sg.ServiceGroupCode and sg.GroupID_BHYT=sgbh.GroupID and 
  sgbh.Abbreviations= 'XN' and rbh.ObjectCode = 1
 ) is null then 0 else  (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Service sv, ServiceCategory sc ,ServiceGroup sg, ServiceGroup_BHYT sgbh where rbh.ReportID = rpbh.ReportID and sv.ServiceCode=rbh.ServiceCode and
    sv.ServiceCategoryCode=sc.ServiceCategoryCode and sc.ServiceGroupCode=sg.ServiceGroupCode and sg.GroupID_BHYT=sgbh.GroupID and 
  sgbh.Abbreviations= 'XN' and rbh.ObjectCode = 1)   end)as xn,

 ( case when (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Service sv, ServiceCategory sc ,ServiceGroup sg, ServiceGroup_BHYT sgbh where rbh.ReportID = rpbh.ReportID and sv.ServiceCode=rbh.ServiceCode and
   sv.ServiceCategoryCode=sc.ServiceCategoryCode and sc.ServiceGroupCode=sg.ServiceGroupCode and sg.GroupID_BHYT=sgbh.GroupID and 
  sgbh.Abbreviations= 'CDHA' and rbh.ObjectCode = 1
 ) is null then 0 else  (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Service sv, ServiceCategory sc ,ServiceGroup sg, ServiceGroup_BHYT sgbh where rbh.ReportID = rpbh.ReportID and sv.ServiceCode=rbh.ServiceCode and
  sv.ServiceCategoryCode=sc.ServiceCategoryCode and sc.ServiceGroupCode=sg.ServiceGroupCode and sg.GroupID_BHYT=sgbh.GroupID and 
  sgbh.Abbreviations= 'CDHA' and rbh.ObjectCode = 1)   end)as cdha,

 ( case when (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Items sv, ItemCategory itc, ItemGroup itg, ServiceGroup_BHYT srbh where rbh.ReportID = rpbh.ReportID and sv.ItemCode=rbh.ServiceCode and
  sv.ItemCategoryCode = itc.ItemCategoryCode and itc.GroupCode=itg.GroupCode and srbh.GroupID=itg.GroupID_BHYT and  srbh.Abbreviations = 'THUOCBH' and rbh.ObjectCode = 1
 ) is null then 0 else  (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Items sv, ItemCategory itc, ItemGroup itg,ServiceGroup_BHYT srbh where rbh.ReportID = rpbh.ReportID and sv.ItemCode=rbh.ServiceCode and
  sv.ItemCategoryCode = itc.ItemCategoryCode and itc.GroupCode=itg.GroupCode and srbh.GroupID=itg.GroupID_BHYT and  srbh.Abbreviations = 'THUOCBH' and rbh.ObjectCode = 1
 )   end)as thuocdich,	

   ( case when (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Items sv, ItemCategory itc, ItemGroup itg, ServiceGroup_BHYT srbh where rbh.ReportID = rpbh.ReportID and sv.ItemCode=rbh.ServiceCode and
  sv.ItemCategoryCode = itc.ItemCategoryCode and itc.GroupCode=itg.GroupCode and srbh.GroupID=itg.GroupID_BHYT and  srbh.Abbreviations = 'MAU' and rbh.ObjectCode = 1
 ) is null then 0 else  (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Items sv, ItemCategory itc, ItemGroup itg,ServiceGroup_BHYT srbh where rbh.ReportID = rpbh.ReportID and sv.ItemCode=rbh.ServiceCode and
  sv.ItemCategoryCode = itc.ItemCategoryCode and itc.GroupCode=itg.GroupCode and srbh.GroupID=itg.GroupID_BHYT and  srbh.Abbreviations = 'MAU' and rbh.ObjectCode = 1
 )   end) as mau,

 ( case when (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Service sv, ServiceCategory sc ,ServiceGroup sg, ServiceGroup_BHYT sgbh where rbh.ReportID = rpbh.ReportID and sv.ServiceCode=rbh.ServiceCode and
  sv.ServiceCategoryCode=sc.ServiceCategoryCode and sc.ServiceGroupCode=sg.ServiceGroupCode and sg.GroupID_BHYT=sgbh.GroupID and 
  sgbh.Abbreviations= 'TTPT' and rbh.ObjectCode = 1
 ) is null then 0 else  (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Service sv, ServiceCategory sc ,ServiceGroup sg, ServiceGroup_BHYT sgbh where rbh.ReportID = rpbh.ReportID and sv.ServiceCode=rbh.ServiceCode and
  sv.ServiceCategoryCode=sc.ServiceCategoryCode and sc.ServiceGroupCode=sg.ServiceGroupCode and sg.GroupID_BHYT=sgbh.GroupID and 
  sgbh.Abbreviations= 'TTPT' and rbh.ObjectCode = 1)   end)as pttt,

 ( case when (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Items sv, ItemCategory itc, ItemGroup itg, ServiceGroup_BHYT srbh where rbh.ReportID = rpbh.ReportID and sv.ItemCode=rbh.ServiceCode and
  sv.ItemCategoryCode = itc.ItemCategoryCode and itc.GroupCode=itg.GroupCode and srbh.GroupID=itg.GroupID_BHYT and  srbh.Abbreviations = 'VTYTBH' and rbh.ObjectCode = 1
 ) is null then 0 else  (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Items sv, ItemCategory itc, ItemGroup itg,ServiceGroup_BHYT srbh where rbh.ReportID = rpbh.ReportID and sv.ItemCode=rbh.ServiceCode and
  sv.ItemCategoryCode = itc.ItemCategoryCode and itc.GroupCode=itg.GroupCode and srbh.GroupID=itg.GroupID_BHYT and  srbh.Abbreviations = 'VTYTBH' and rbh.ObjectCode = 1
 )   end)as vtth,

  0 as vttt,  0 as dvktc,  0 as tktg,

 ( case when (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Service sv, ServiceCategory sc ,ServiceGroup sg, ServiceGroup_BHYT sgbh where rbh.ReportID = rpbh.ReportID and sv.ServiceCode=rbh.ServiceCode and
  sv.ServiceCategoryCode=sc.ServiceCategoryCode and sc.ServiceGroupCode=sg.ServiceGroupCode and sg.GroupID_BHYT=sgbh.GroupID and 
  sgbh.Abbreviations= 'KB' and rbh.ObjectCode = 1
 ) is null then 0 else  (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Service sv, ServiceCategory sc ,ServiceGroup sg, ServiceGroup_BHYT sgbh where rbh.ReportID = rpbh.ReportID and sv.ServiceCode=rbh.ServiceCode and
  sv.ServiceCategoryCode=sc.ServiceCategoryCode and sc.ServiceGroupCode=sg.ServiceGroupCode and sg.GroupID_BHYT=sgbh.GroupID and 
  sgbh.Abbreviations= 'KB' and rbh.ObjectCode = 1)   end)as kcb,
  
 ( case when (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Service sv, ServiceCategory sc ,ServiceGroup sg, ServiceGroup_BHYT sgbh where rbh.ReportID = rpbh.ReportID and sv.ServiceCode=rbh.ServiceCode and
  sv.ServiceCategoryCode=sc.ServiceCategoryCode and sc.ServiceGroupCode=sg.ServiceGroupCode and sg.GroupID_BHYT=sgbh.GroupID and 
  sgbh.Abbreviations= 'VC' and rbh.ObjectCode = 1
 ) is null then 0 else  (select  sum(rbh.Amount) from ReportBHYTDetail rbh, Service sv, ServiceCategory sc ,ServiceGroup sg, ServiceGroup_BHYT sgbh where rbh.ReportID = rpbh.ReportID and sv.ServiceCode=rbh.ServiceCode and
  sv.ServiceCategoryCode=sc.ServiceCategoryCode and sc.ServiceGroupCode=sg.ServiceGroupCode and sg.GroupID_BHYT=sgbh.GroupID and 
  sgbh.Abbreviations= 'VC' and rbh.ObjectCode = 1)   end)as vc ,

 round(rpbh.BNTraBH,0) as bncct , round(rpbh.BHYTPay,0) as tcbh, 0 as cpngoai,
 (
 case when (REPLACE(REPLACE( rpbh.KCBBDCode,'-' ,''),' ','')) = (select REPLACE(REPLACE( KCBBDCode,'-' ,''),' ','')  from ClinicInformation) 
 then N'A. BỆNH NHÂN NỘI TỈNH KCB BAN ĐẦU' else 
 case when left(rpbh.KCBBDCode,2) = (select left(KCBBDCode,2) from ClinicInformation) 
 then N'B. BỆNH NHÂN NỘI TỈNH ĐẾN' else N'C. BỆNH NHÂN NGOẠI TỈNH ĐẾN' end end
 ) as nhom,[dbo].func_DiagnosisEnclosedMore(rpbh.ICD10More) as kemtheo, YEAR(CONVERT(date, rpbh.DateOut ,103)) namqt, MONTH(CONVERT(date, rpbh.DateOut ,103)) thangqt,
 dpm.KBHYT as makhoa, 1 as maloaikcb,(select REPLACE(REPLACE( KCBBDCode,'-' ,''),' ','')  from ClinicInformation) as macskcb, '' makv
 from Patients p inner join ReportBHYT rpbh on p.PatientCode=rpbh.PatientCode left join Catalog_Provincial pr on
 p.ProvincialCode=pr.ProvincialCode left join Catalog_Ward w on p.WardCode=w.WardCode left join Catalog_District d on
 p.DistrictCode=d.DistrictCode inner join Department dpm on rpbh.DepartmentCode=dpm.DepartmentCode inner join 
 Diagnosis dia on rpbh.ICD10=dia.RowID and rpbh.Cancel = 0 and dpm.IdBv = 2
where CONVERT(date, rpbh.DateOut ,103) between  CONVERT(date,@frDate,103) and CONVERT(date, @toDate ,103)
end
GO
-- ok

if exists(select name from sysobjects where name ='pro_BM20')
	drop procedure pro_BM20
go
CREATE procedure pro_BM20
(
	@frDate char(20),
	@toDate char(20)
)
as
begin
	declare @TableBM20 table(ItemCode varchar(50), KhoaNgoai int default 0, KhoaNoi int default 0, SalesPrice decimal, TotalAmount decimal)
	declare @Quantity int=0
	declare @TotalAmount decimal =0
	declare @ItemCode varchar(50)
	declare @SalesPrice decimal =0
	declare cur1 cursor read_only fast_forward
	for (select sum(rpd.Quantity) Quantity, sum(rpd.Quantity*rpd.ServicePrice) TotalAmount,rpd.ServiceCode,rpd.ServicePrice from 
		reportBHYT rp inner join ReportBHYTDetail rpd on rp.ReportID=rpd.ReportID inner join Items th on th.ItemCode = rpd.ServiceCode inner join Usage cd on cd.UsageCode = th.UsageCode inner join UnitOfMeasure un
		on un.UnitOfMeasureCode = th.UnitOfMeasureCode inner join Department p on p.DepartmentCode = rp.DepartmentCode inner join ItemCategory ic on ic.ItemCategoryCode =th.ItemCategoryCode
		inner join ItemGroup gr on gr.GroupCode=ic.GroupCode inner join ServiceGroup_BHYT srbh on gr.GroupID_BHYT=srbh.GroupID
		where p.IdBv=1 and rpd.ObjectCode = 1 and rp.Cancel=0 and srbh.Abbreviations = 'THUOCBH' and convert(date,rp.PostingDate,103) between convert(date,@frDate,103) and convert(date,@toDate,103) 
		group by rpd.ServiceCode,rpd.ServicePrice)
	open cur1
	fetch next from cur1 into @Quantity,@TotalAmount,@ItemCode,@SalesPrice
	while @@FETCH_STATUS = 0
	begin
			if not exists (select ItemCode from @TableBM20 where ItemCode=@ItemCode and SalesPrice=@SalesPrice)
				insert into @TableBM20(ItemCode,KhoaNgoai,KhoaNoi,SalesPrice,TotalAmount) values(@ItemCode,@Quantity,0,@SalesPrice,@TotalAmount)
			else
				update @TableBM20 set KhoaNgoai=@Quantity,ItemCode=@ItemCode,TotalAmount=@TotalAmount where ItemCode=@ItemCode and SalesPrice=@SalesPrice
			FETCH NEXT FROM cur1 into @Quantity,@TotalAmount,@ItemCode,@SalesPrice
	end
	CLOSE cur1
	DEALLOCATE cur1
	declare cur2 cursor read_only fast_forward
	for (select sum(rpd.Quantity) Quantity, sum(rpd.Quantity*rpd.ServicePrice) TotalAmount,rpd.ServiceCode,rpd.ServicePrice from 
		reportBHYT rp inner join ReportBHYTDetail rpd on rp.ReportID=rpd.ReportID inner join Items th on th.ItemCode = rpd.ServiceCode inner join Usage cd on cd.UsageCode = th.UsageCode inner join UnitOfMeasure un
		on un.UnitOfMeasureCode = th.UnitOfMeasureCode inner join Department p on p.DepartmentCode = rp.DepartmentCode inner join ItemCategory ic on ic.ItemCategoryCode =th.ItemCategoryCode
		inner join ItemGroup gr on gr.GroupCode=ic.GroupCode inner join ServiceGroup_BHYT srbh on gr.GroupID_BHYT=srbh.GroupID
		where p.IdBv=2 and rpd.ObjectCode = 1 and rp.Cancel=0 and srbh.Abbreviations = 'THUOCBH' and convert(date,rp.PostingDate,103) between convert(date,@frDate,103) and convert(date,@toDate,103)
		group by rpd.ServiceCode,rpd.ServicePrice)
	open cur2
	fetch next from cur2 into @Quantity,@TotalAmount,@ItemCode,@SalesPrice
	while @@FETCH_STATUS = 0
	begin
			if not exists (select ItemCode from @TableBM20 where ItemCode=@ItemCode and SalesPrice=@SalesPrice)
				insert into @TableBM20(ItemCode,KhoaNoi,SalesPrice,TotalAmount) values(@ItemCode,@Quantity,@SalesPrice,@TotalAmount)
			else
				update @TableBM20 set KhoaNoi=@Quantity,ItemCode=@ItemCode,TotalAmount=TotalAmount+@TotalAmount where ItemCode=@ItemCode and SalesPrice=@SalesPrice
			FETCH NEXT FROM cur2 into @Quantity,@TotalAmount,@ItemCode,@SalesPrice
	end
	CLOSE cur2
	DEALLOCATE cur2
	select distinct th.STTBCBHYT , th.ItemName, th.Active, cd.UsageName , th.ItemContent , th.SODKGP , un.UnitOfMeasureName, bm.KhoaNgoai as ngoai, bm.KhoaNoi as noi,
	bm.SalesPrice, bm.TotalAmount as tien, ic.ItemCategoryName
	from @TableBM20 bm inner join Items th on bm.ItemCode = th.ItemCode inner join ReportBHYTDetail rpd  on rpd.ServiceCode=th.ItemCode inner join reportBHYT rp 
	on rp.ReportID=rpd.ReportID inner join Usage cd on th.UsageCode = cd.UsageCode inner join UnitOfMeasure un
	on th.UnitOfMeasureCode=un.UnitOfMeasureCode  inner join Department p on rp.DepartmentCode=p.DepartmentCode inner join ItemCategory ic 
	on ic.ItemCategoryCode =th.ItemCategoryCode
end
GO
if exists(select name from sysobjects where name ='pro_BM21')
	drop procedure pro_BM21
go
create procedure pro_BM21
(
	@frDate char(10),
	@toDate char(10)
)
as
begin
	declare @TableBM21 table(ServiceCode varchar(50), KhoaNgoai int, KhoaNoi int, ServicePrice decimal, TotalAmount decimal)
	declare @Quantity int=0
	declare @TotalAmount decimal =0
	declare @ServiceCode varchar(50)
	declare @ServicePrice decimal =0
	declare cur1 cursor read_only fast_forward
	for (select sum(rpd.Quantity) Quantity, sum(rpd.Quantity*rpd.ServicePrice) TotalAmount,rpd.ServiceCode,rpd.ServicePrice from 
		reportBHYT rp inner join ReportBHYTDetail rpd on rp.ReportID=rpd.ReportID inner join Department p on rp.DepartmentCode = p.DepartmentCode 
		inner join Service s on rpd.ServiceCode=s.ServiceCode inner join ServiceCategory sc on s.ServiceCategoryCode=sc.ServiceCategoryCode inner join ServiceGroup sg on sc.ServiceGroupCode=sg.ServiceGroupCode
		where p.IdBv=1 and rpd.ObjectCode = 1 and rp.Cancel=0 and convert(date,rp.PostingDate,103) between convert(date,@frDate,103) and convert(date,@toDate,103)
		group by rpd.ServiceCode,rpd.ServicePrice)
	open cur1
	fetch next from cur1 into @Quantity,@TotalAmount,@ServiceCode,@ServicePrice
	while @@FETCH_STATUS = 0
	begin
			if not exists (select ServiceCode from @TableBM21 where ServiceCode=@ServiceCode and ServicePrice=@ServicePrice)
				insert into @TableBM21(ServiceCode,KhoaNgoai,KhoaNoi,ServicePrice,TotalAmount) values(@ServiceCode,@Quantity,0,@ServicePrice,@TotalAmount)
			else
				update @TableBM21 set KhoaNgoai=@Quantity,ServicePrice=@ServicePrice,TotalAmount=@TotalAmount where ServiceCode=@ServiceCode and ServicePrice=@ServicePrice
			FETCH NEXT FROM cur1 into @Quantity,@TotalAmount,@ServiceCode,@ServicePrice
	end
	CLOSE cur1
	DEALLOCATE cur1
	declare cur2 cursor read_only fast_forward
	for (select sum(rpd.Quantity) Quantity, sum(rpd.Quantity*rpd.ServicePrice) TotalAmount,rpd.ServiceCode,rpd.ServicePrice from 
		reportBHYT rp inner join ReportBHYTDetail rpd on rp.ReportID=rpd.ReportID inner join Department p on rp.DepartmentCode = p.DepartmentCode 
		inner join Service s on rpd.ServiceCode=s.ServiceCode inner join ServiceCategory sc on s.ServiceCategoryCode=sc.ServiceCategoryCode inner join ServiceGroup sg on sc.ServiceGroupCode=sg.ServiceGroupCode
		where p.IdBv=2 and rpd.ObjectCode = 1 and rp.Cancel = 0 and convert(date,rp.PostingDate,103) between convert(date,@frDate,103) and convert(date,@toDate,103)
		group by rpd.ServiceCode,rpd.ServicePrice)
	open cur2
	fetch next from cur2 into @Quantity,@TotalAmount,@ServiceCode,@ServicePrice
	while @@FETCH_STATUS = 0
	begin
			if not exists (select ServiceCode from @TableBM21 where ServiceCode=@ServiceCode and ServicePrice=@ServicePrice)
				insert into @TableBM21(ServiceCode,KhoaNoi,ServicePrice,TotalAmount) values(@ServiceCode,@Quantity,@ServicePrice,@TotalAmount)
			else
				update @TableBM21 set KhoaNoi=@Quantity,ServicePrice=@ServicePrice,TotalAmount=TotalAmount+@TotalAmount where ServiceCode=@ServiceCode and ServicePrice=@ServicePrice
			FETCH NEXT FROM cur2 into @Quantity,@TotalAmount,@ServiceCode,@ServicePrice
	end
	CLOSE cur2
	DEALLOCATE cur2
	select srbh.Ma_TT37 as DMBHYT, d.ServiceGroupName,b.ServiceName,a.KhoaNgoai,a.KhoaNoi,a.ServicePrice,a.TotalAmount from @TableBM21 a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory c on b.ServiceCategoryCode=c.ServiceCategoryCode inner join ServiceGroup d on c.ServiceGroupCode=d.ServiceGroupCode left join Service_BHYT srbh on b.MaTuongDuong_BHYT=srbh.MaTuongDuong
end
GO
if exists(select name from sysobjects where name ='pro_BM19')
	drop procedure pro_BM19
go
CREATE procedure pro_BM19
(
	@frDate char(10),
	@toDate char(10)
)
as
begin
	declare @TableBM19 table(ItemCode varchar(50), KhoaNgoai int default 0, KhoaNoi int default 0, SalesPrice decimal, TotalAmount decimal)
	declare @Quantity int=0
	declare @TotalAmount decimal =0
	declare @ItemCode varchar(50)
	declare @SalesPrice decimal =0
	declare cur1 cursor read_only fast_forward
	for (select sum(rpd.Quantity) Quantity, sum(rpd.Quantity*rpd.ServicePrice) TotalAmount,rpd.ServiceCode,rpd.ServicePrice from 
		reportBHYT rp inner join ReportBHYTDetail rpd on rp.ReportID=rpd.ReportID inner join Items th on th.ItemCode = rpd.ServiceCode inner join Usage cd on cd.UsageCode = th.UsageCode inner join UnitOfMeasure un
		on un.UnitOfMeasureCode = th.UnitOfMeasureCode inner join Department p on p.DepartmentCode = rp.DepartmentCode inner join ItemCategory ic on ic.ItemCategoryCode =th.ItemCategoryCode
		inner join ItemGroup gr on gr.GroupCode=ic.GroupCode inner join ServiceGroup_BHYT srbh on gr.GroupID_BHYT=srbh.GroupID
		where p.IdBv=1 and rp.Cancel = 0 and srbh.Abbreviations = 'VTYTBH' and rpd.ObjectCode = 1 and convert(date,rp.PostingDate,103) between convert(date,@frDate,103) and convert(date,@toDate,103) 
		group by rpd.ServiceCode,rpd.ServicePrice)
	open cur1
	fetch next from cur1 into @Quantity,@TotalAmount,@ItemCode,@SalesPrice
	while @@FETCH_STATUS = 0
	begin
			if not exists (select ItemCode from @TableBM19 where ItemCode=@ItemCode and SalesPrice=@SalesPrice)
				insert into @TableBM19(ItemCode,KhoaNgoai,KhoaNoi,SalesPrice,TotalAmount) values(@ItemCode,@Quantity,0,@SalesPrice,@TotalAmount)
			else
				update @TableBM19 set KhoaNgoai=@Quantity,ItemCode=@ItemCode,TotalAmount=@TotalAmount where ItemCode=@ItemCode and SalesPrice=@SalesPrice
			FETCH NEXT FROM cur1 into @Quantity,@TotalAmount,@ItemCode,@SalesPrice
	end
	CLOSE cur1
	DEALLOCATE cur1
	declare cur2 cursor read_only fast_forward
	for (select sum(rpd.Quantity) Quantity, sum(rpd.Quantity*rpd.ServicePrice) TotalAmount,rpd.ServiceCode,rpd.ServicePrice from 
		reportBHYT rp inner join ReportBHYTDetail rpd on rp.ReportID=rpd.ReportID inner join Items th on th.ItemCode = rpd.ServiceCode inner join Usage cd on cd.UsageCode = th.UsageCode inner join UnitOfMeasure un
		on un.UnitOfMeasureCode = th.UnitOfMeasureCode inner join Department p on p.DepartmentCode = rp.DepartmentCode inner join ItemCategory ic on ic.ItemCategoryCode =th.ItemCategoryCode
		inner join ItemGroup gr on gr.GroupCode=ic.GroupCode inner join ServiceGroup_BHYT srbh on gr.GroupID_BHYT=srbh.GroupID
		where p.IdBv=2 and rp.Cancel = 0 and srbh.Abbreviations = 'VTYTBH' and rpd.ObjectCode = 1 and convert(date,rp.PostingDate,103) between convert(date,@frDate,103) and convert(date,@toDate,103)
		group by rpd.ServiceCode,rpd.ServicePrice)
	open cur2
	fetch next from cur2 into @Quantity,@TotalAmount,@ItemCode,@SalesPrice
	while @@FETCH_STATUS = 0
	begin
			if not exists (select ItemCode from @TableBM19 where ItemCode=@ItemCode and SalesPrice=@SalesPrice)
				insert into @TableBM19(ItemCode,KhoaNoi,SalesPrice,TotalAmount) values(@ItemCode,@Quantity,@SalesPrice,@TotalAmount)
			else
				update @TableBM19 set KhoaNoi=@Quantity,ItemCode=@ItemCode,TotalAmount=TotalAmount+@TotalAmount where ItemCode=@ItemCode and SalesPrice=@SalesPrice
			FETCH NEXT FROM cur2 into @Quantity,@TotalAmount,@ItemCode,@SalesPrice
	end
	CLOSE cur2
	DEALLOCATE cur2
	select distinct th.STTBCBHYT as dmbhyt, th.ItemName as ItemNameVTYTBH , th.ItemName, th.STTBCBHYT, th.QUYCACH ,un.UnitOfMeasureName, bm.KhoaNgoai as ngoai, bm.KhoaNoi as noi,
	th.UnitPrice ,bm.SalesPrice, bm.TotalAmount as tien
	from @TableBM19 bm inner join Items th on bm.ItemCode = th.ItemCode inner join ReportBHYTDetail rpd  on rpd.ServiceCode=th.ItemCode inner join reportBHYT rp 
	on rp.ReportID=rpd.ReportID inner join Usage cd on th.UsageCode = cd.UsageCode inner join UnitOfMeasure un
	on th.UnitOfMeasureCode=un.UnitOfMeasureCode  inner join Department p on rp.DepartmentCode=p.DepartmentCode inner join ItemCategory ic 
	on ic.ItemCategoryCode =th.ItemCategoryCode 
end
go
if exists(select name from sysobjects where name ='pro_CheckTotalBHYT')
	drop procedure pro_CheckTotalBHYT
go
create procedure pro_CheckTotalBHYT
(
	@dPatientReceiveID decimal
)
as
begin
	declare @DV decimal=0
	declare @TH decimal =0
	declare @TTruc decimal =0
	declare @TableResult table(TotalBHYT decimal(18,0))
	select @DV = ISNULL(sum(ServicePrice * Quantity),0) from SuggestedServiceReceipt where RefID in (@dPatientReceiveID) and ObjectCode in (1)
	select @TH = ISNULL(sum(b.BHYTPrice*b.QuantityExport),0) from MedicinesForPatients a inner join MedicinesForPatientsDetail b on a.MedicalRecordCode=b.MedicalRecordCode where a.PatientReceiveID in (@dPatientReceiveID) and b.ObjectCode in (1)
	select @TTruc = ISNULL(sum(b.BHYTPrice*b.Quantity),0) from RealMedicinesForPatients a inner join RealMedicinesForPatientsDetail b on a.RowID=b.RealRowID where a.PatientReceiveID in (@dPatientReceiveID) and b.ObjectCode in (1)
	insert into @TableResult(TotalBHYT)values(@DV+@TH+@TTruc)
	select TotalBHYT from @TableResult
end
go
