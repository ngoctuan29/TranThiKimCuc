---------- upd 16/02/2017
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='VENABC') 
	drop table VENABC
go
if exists(select name from sysobjects where name ='proVen_ViewInventory')
	drop procedure proVen_ViewInventory
go
CREATE proc proVen_ViewInventory
	@VENABC_Code varchar(15)
as
begin tran
	select ItemName,Active,BietDuoc,Generic,VENCode,CountryName,ATCCode,UnitOfMeasureName,Quantity,UnitPriceVAT from VENABC_AnalistDetail where VENABC_Code=@VENABC_Code
commit tran
GO
if exists(select name from sysobjects where name ='proIU_VENABC_Analist')
	drop procedure proIU_VENABC_Analist
go
CREATE proc proIU_VENABC_Analist
	@VENABC_Code varchar(15),
	@FromDate date,
	@ToDate date,
	@EmployeeCode varchar(15),
	@ResultVENABC_Code varchar(15) output
as
begin tran
	if exists (select VENABC_Code from VENABC_Analist where VENABC_Code=@VENABC_Code)
		set @ResultVENABC_Code ='exist'
	else
		begin
			insert into VENABC_Analist(VENABC_Code,FromDate,ToDate,EmployeeCode) values(@VENABC_Code,@FromDate,@ToDate,@EmployeeCode)
			set @ResultVENABC_Code ='success'
		end
commit tran
GO
if exists(select name from sysobjects where name ='proIU_VENABC_AnalistDetail')
	drop procedure proIU_VENABC_AnalistDetail
go
CREATE proc proIU_VENABC_AnalistDetail
	@VENABC_Code varchar(15),
	@ItemName nvarchar(500),
	@UnitOfMeasureName nvarchar(100),
	@Active nvarchar(250),
	@BietDuoc char(1),
	@Generic char(1),
	@VENCode nvarchar(100),
	@CountryName nvarchar(250),
	@ATCCode nvarchar(250),
	@Quantity numeric(18,2),
	@UnitPriceVAT numeric(18,2)
as
begin tran
	if exists (select VENABC_Code from VENABC_Analist where VENABC_Code=@VENABC_Code)
		begin
			insert into VENABC_AnalistDetail(VENABC_Code,ItemName,UnitOfMeasureName,Active,BietDuoc,Generic,VENCode,CountryName,ATCCode,Quantity,UnitPriceVAT) values (@VENABC_Code,@ItemName,@UnitOfMeasureName,@Active,@BietDuoc,@Generic,@VENCode,@CountryName,@ATCCode,@Quantity,@UnitPriceVAT)
		end
commit tran
GO
------------------------- Phan Tich VENABC
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Items' and b.name='ATCCode')
	alter table Items add ATCCode nvarchar(10)
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='VENABC') 
begin
CREATE TABLE VENABC
(
	FromDate date not null,
	ToDate date not null,
	ItemCode varchar(15),
	AmountBegin numeric(18,2),
	AmountBeginPre numeric(18,2),
	AmountEnd numeric(18,2),
	AmountEndPre numeric(18,2),
	AmountExport numeric(18,2),
	AmountExportPre numeric(18,2),
	AmountImport numeric(18,2),
	AmountImportPre numeric(18,2),
	AmountImportRepaid numeric(18,2),
	AmountImportRepaidPre numeric(18,2),
	AmountImportTransfer numeric(18,2),
	AmountImportTransferPre numeric(18,2),
	AmountKhaiTon numeric(18,2),
	AmountKhaiTonPre numeric(18,2),
	AmountRepaid numeric(18,2),
	AmountRepaidPre numeric(18,2),
	AmountRepaidVen numeric(18,2),
	AmountRepaidVenPre numeric(18,2),
	AmountTransfer numeric(18,2),
	AmountTransferPre numeric(18,2),
	Quantity numeric(18,2),
	UnitPriceVAT numeric(18,2),
)
end
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='VENABC_Analist') 
begin
CREATE TABLE VENABC_Analist
(
	VENABC_Code varchar(15),
	FromDate date not null,
	ToDate date not null,
	EmployeeCode varchar(15),
	CONSTRAINT VENABC_Analist_pk PRIMARY KEY (VENABC_Code)
)
end
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='VENABC_AnalistDetail') 
begin
CREATE TABLE VENABC_AnalistDetail
(
	VENABC_Code varchar(15),
	ItemName nvarchar(500),
	UnitOfMeasureName nvarchar(100),
	Active nvarchar(250),
	BietDuoc char(1),
	Generic char(1),
	VENCode nvarchar(100),
	CountryName nvarchar(250),
	ATCCode nvarchar(250),
	Quantity numeric(18,2),
	UnitPriceVAT numeric(18,2),
	CONSTRAINT VENABC_AnalistDetail_fk foreign key(VENABC_Code) references VENABC_Analist(VENABC_Code)
)
end
go
if exists(select name from sysobjects where name ='sp_ThongKeABCTheoATC_NotABC')
	drop procedure sp_ThongKeABCTheoATC_NotABC
go
CREATE proc sp_ThongKeABCTheoATC_NotABC
@VENABC_Code as varchar(15)
as
begin tran
declare @T as table
(	Id int identity(1,1),
	ItemName nvarchar(150),
	Active nvarchar(500),
	ATCCode nvarchar(200),
	UnitOfMeasureName nvarchar(50),
	Quantity int,
	UnitPriceVAT money,
	Amount money,
	Total money
)
insert into @T(ItemName,Active,ATCCode,UnitOfMeasureName,Quantity,UnitPriceVAT,Amount)
select a.ItemName,a.Active,left(a.ATCCode,1)as ATCCode,a.UnitOfMeasureName,sum(a.Quantity)as Quantity,a.UnitPriceVAT,sum(a.Quantity*a.UnitPriceVAT)as Amount
from VENABC_AnalistDetail a
where a.VENABC_Code = @VENABC_Code
group by a.ItemName,a.Active,left(a.ATCCode,1),a.UnitOfMeasureName,a.UnitPriceVAT
order by Amount desc

update @T set Total=(select sum(Amount) from @T)
select ItemName,Active,ATCCode,UnitOfMeasureName,Quantity,UnitPriceVAT,Amount, Total from @T 
commit tran
GO
----
if exists(select name from sysobjects where name ='sp_ThongKeABCTheoATC_TyLe')
	drop procedure sp_ThongKeABCTheoATC_TyLe
go
CREATE proc sp_ThongKeABCTheoATC_TyLe
@IdPhieu as varchar(15)
as
begin tran
declare @T as table
(	Id int identity(1,1),
	MaATC char(10),
	ThanhTien decimal(18,4),
	Tong decimal(18,4),
	TiLe decimal(18,4)
)

insert into @T(MaATC,ThanhTien)
select left(a.ATCCode,1)as MaATC,sum(a.Quantity*a.UnitPriceVAT)as ThanhTien
from VENABC_AnalistDetail a 
where a.VENABC_Code=@IdPhieu
group by left(a.ATCCode,1)

update @T set Tong=(select sum(ThanhTien) from @T)
update @T set TiLe=ThanhTien/Tong *100

select t.MaATC,isnull(ma.ATCName,'')as TenATC,ThanhTien,TiLe 
from @T t
left join Catalog_ATC ma on t.MaATC=ma.ATCCode 
order by TiLe desc
commit tran
GO
---
if exists(select name from sysobjects where name ='sp_ThongKeABCVEN')
	drop procedure sp_ThongKeABCVEN
go
CREATE proc sp_ThongKeABCVEN
@VEN as char(5),
@VENCode as varchar(15)
as
begin tran
declare @T as table
(	Id int identity(1,1),
	ItemName nvarchar(150),
	Active nvarchar(500),
	BietDuoc1 nvarchar(150),
	Generic nvarchar(150),
	VEN nvarchar(100),
	UnitOfMeasureName nvarchar(50),
	Quantity int,
	UnitPriceVAT money,
	Amount money,
	Total money,
	TiLe float,
	TiLeTL float,
	ABC nvarchar(5)
)

insert into @T(ItemName,Active,BietDuoc1,Generic,VEN,UnitOfMeasureName,Quantity,UnitPriceVAT,Amount)
select a.ItemName,a.Active,a.BietDuoc,a.Generic,a.VENCode,a.UnitOfMeasureName,sum(a.Quantity)as Quantity,a.UnitPriceVAT,sum(a.Quantity*a.UnitPriceVAT)as Amount
from VENABC_AnalistDetail a 
where a.VENABC_Code = @VENCode
group by a.ItemName,a.Active,BietDuoc,Generic,VENCode,a.UnitOfMeasureName,a.UnitPriceVAT
order by Amount desc

update @T set Total=(select sum(Amount) from @T)

update @T set TiLe=Amount/Total *100

declare @r as int,@i as int
set @r=(select count(Id) from @T)
set @i=1
while (@i<=@r)
	begin
		if @i-1=0
			update @T set TiLeTL=TiLe where id=@i
		else		
			update @T set TiLeTL=TiLe+(select TiLeTL from @T where id=@i-1) where id=@i

		set @i=@i+1
	end
update @T set ABC='A' where TiLeTL>=0 and TiLeTL<=75
update @T set ABC='B' where TiLeTL>75 and TiLeTL<=90
update @T set ABC='C' where TiLeTL>90 and TiLeTL<=100

if @VEN<>'VEN'
	select ItemName,Active,BietDuoc1,Generic,VEN,UnitOfMeasureName,Quantity,UnitPriceVAT,Amount,Total,TiLe,TiLeTL,ABC from @T where VEN=@VEN
else 
	select ItemName,Active,BietDuoc1,Generic,VEN,UnitOfMeasureName,Quantity,UnitPriceVAT,Amount,Total,TiLe,TiLeTL,ABC from @T
commit tran
GO
----
if exists(select name from sysobjects where name ='sp_ThongKeABCVEN_2Time')
	drop procedure sp_ThongKeABCVEN_2Time
go
CREATE proc sp_ThongKeABCVEN_2Time
@VEN as char(5),
@VENCode1 as varchar(15),
@VENCode2 as varchar(15)
as
begin tran
declare @T1 as table
(	Id int identity(1,1),
	iTime int default ((1)),
	IdNhom int,
	TenSP nvarchar(150),
	TenHC nvarchar(500),
	BietDuoc1 nvarchar(150),
	Generic nvarchar(150),
	VEN nvarchar(100),
	DVT nvarchar(50),
	SoLuong int,
	DonGiaVAT money,
	ThanhTien money,
	Tong money,
	TiLe float,
	TiLeTL float,
	ABC nvarchar(5)

)
declare @T2 as table
(	Id int identity(1,1),
	iTime int default ((2)),
	IdNhom int,
	TenSP nvarchar(150),
	TenHC nvarchar(500),
	BietDuoc1 nvarchar(150),
	Generic nvarchar(150),
	VEN nvarchar(100),
	DVT nvarchar(50),
	SoLuong int,
	DonGiaVAT money,
	ThanhTien money,
	Tong money,
	TiLe float,
	TiLeTL float,
	ABC nvarchar(5)

)

insert into @T1(TenSP,TenHC,BietDuoc1,Generic,VEN,DVT,SoLuong,DonGiaVAT,ThanhTien,Tong,TiLe,TiLeTL,ABC)
exec sp_ThongKeABCVEN @VEN,@VENCode1

insert into @T2(TenSP,TenHC,BietDuoc1,Generic,VEN,DVT,SoLuong,DonGiaVAT,ThanhTien,Tong,TiLe,TiLeTL,ABC)
exec sp_ThongKeABCVEN @VEN,@VENCode2

select iTime,TenSP,TenHC,VEN,DVT,SoLuong,DonGiaVAT,ThanhTien,Tong,TiLe,TiLeTL,ABC
from @T1
union all
select iTime,TenSP,TenHC,VEN,DVT,SoLuong,DonGiaVAT,ThanhTien,Tong,TiLe,TiLeTL,ABC
from @T2
commit tran
GO
---
if exists(select name from sysobjects where name ='sp_ThongKeABCVEN_2Time_ThayDoiBac')
	drop procedure sp_ThongKeABCVEN_2Time_ThayDoiBac
go
CREATE proc sp_ThongKeABCVEN_2Time_ThayDoiBac
@VEN as char(5),
@VENABC_Code1 as varchar(15),
@VENABC_Code2 as varchar(15)
as
begin tran
declare @T1 as table
(	Id int identity(1,1),
	iTime int default ((1)),
	IdNhom int,
	TenSP nvarchar(150),
	TenHC nvarchar(500),
	BietDuoc1 nvarchar(150),
	Generic nvarchar(150),
	VEN nvarchar(100),
	DVT nvarchar(50),
	SoLuong int,
	DonGiaVAT money,
	ThanhTien money,
	Tong money,
	TiLe float,
	TiLeTL float,
	ABC nvarchar(5),
	SoLuotLanhThuoc int default((0))
)

declare @T2 as table
(	Id int identity(1,1),
	iTime int default ((2)),
	IdNhom int,
	TenSP nvarchar(150),
	TenHC nvarchar(500),
	BietDuoc1 nvarchar(150),
	Generic nvarchar(150),
	VEN nvarchar(100),
	DVT nvarchar(50),
	SoLuong int,
	DonGiaVAT money,
	ThanhTien money,
	Tong money,
	TiLe float,
	TiLeTL float,
	ABC nvarchar(5),
	SoLuotLanhThuoc int default((0))

)
insert into @T1(TenSP,TenHC,BietDuoc1,Generic,VEN,DVT,SoLuong,DonGiaVAT,ThanhTien,Tong,TiLe,TiLeTL,ABC)
exec sp_ThongKeABCVEN @VEN, @VENABC_Code1

insert into @T2(TenSP,TenHC,BietDuoc1,Generic,VEN,DVT,SoLuong,DonGiaVAT,ThanhTien,Tong,TiLe,TiLeTL,ABC)
exec sp_ThongKeABCVEN @VEN, @VENABC_Code2

select isnull(t1.TenSP,t2.TenSP)as TenSP,isnull(t1.TenHC,t2.TenHC)as TenHC
,isnull(t1.DVT,t2.DVT)as DVT,isnull(t1.DonGiaVAT,t2.DonGiaVAT)as DonGiaVAT
,isnull(t1.SoLuong,0)as SL1,isnull(t2.SoLuong,0)as SL2
,isnull(t1.ThanhTien,0)as TT1,isnull(t2.ThanhTien,0)as TT2
,(isnull(t2.ThanhTien,0)-isnull(t1.ThanhTien,0))as ChenhLech
,isnull(t1.ABC,'C')as ABC1,isnull(t2.ABC,'C')as ABC2
,(isnull(t1.ABC,'C')+isnull(t2.ABC,'C'))as TangGiamBac
,isnull(t1.VEN,t2.VEN)as VEN
from @T1 t1
full join @T2 t2 on t2.TenSP=t1.TenSP and t2.DonGiaVAT=t1.DonGiaVAT
order by TenSP
commit tran
GO
---
if exists(select name from sysobjects where name ='sp_ThongKeABCVENTheoThoiGian_NotABC')
	drop procedure sp_ThongKeABCVENTheoThoiGian_NotABC
go
CREATE proc sp_ThongKeABCVENTheoThoiGian_NotABC
@VENABC_Code varchar(15)
as
begin tran
declare @T as table
(	Id int identity(1,1),
	TenSP nvarchar(150),
	TenHC nvarchar(500),
	VEN nvarchar(100),
	DVT nvarchar(50),
	SoLuong int,
	DonGiaVAT money,
	ThanhTien money,
	Tong money
)

insert into @T(TenSP,TenHC,VEN,DVT,SoLuong,DonGiaVAT,ThanhTien)
select a.ItemName,a.Active,a.VENCode,a.UnitOfMeasureName,sum(a.Quantity)as SoLuong,a.UnitPriceVAT,sum(a.Quantity*a.UnitPriceVAT)as ThanhTien
from VENABC_AnalistDetail a 
where a.VENABC_Code=@VENABC_Code
group by a.ItemName,a.Active,a.VENCode,a.UnitOfMeasureName,a.UnitPriceVAT
order by ThanhTien desc

update @T set Tong=(select sum(ThanhTien) from @T)

select TenSP,TenHC,VEN,DVT,SoLuong,DonGiaVAT,ThanhTien,Tong from @T 
commit tran
GO
--
if exists(select name from sysobjects where name ='sp_ThongKeABCVENTheoThoiGian_NotABC_2Time')
	drop procedure sp_ThongKeABCVENTheoThoiGian_NotABC_2Time
go
CREATE proc sp_ThongKeABCVENTheoThoiGian_NotABC_2Time
@VENABC_Code1 as varchar(15),
@VENABC_Code2 as varchar(15)
as
begin tran
declare @T1 as table
(	Id int identity(1,1),
	iTime int default ((1)),
	TenSP nvarchar(150),
	TenHC nvarchar(500),
	VEN nvarchar(100),
	DVT nvarchar(50),
	SoLuong int,
	DonGiaVAT money,
	ThanhTien money,
	Tong money
)
declare @T2 as table
(	Id int identity(1,1),
	iTime int default ((2)),
	TenSP nvarchar(150),
	TenHC nvarchar(500),
	VEN nvarchar(100),
	DVT nvarchar(50),
	SoLuong int,
	DonGiaVAT money,
	ThanhTien money,
	Tong money
)
insert into @T1(TenSP,TenHC,VEN,DVT,SoLuong,DonGiaVAT,ThanhTien,Tong)
exec sp_ThongKeABCVENTheoThoiGian_NotABC @VENABC_Code1

insert into @T2(TenSP,TenHC,VEN,DVT,SoLuong,DonGiaVAT,ThanhTien,Tong)
exec sp_ThongKeABCVENTheoThoiGian_NotABC @VENABC_Code2

select iTime,TenSP,TenHC,VEN,DVT,SoLuong,DonGiaVAT,ThanhTien,Tong from @T1 
union all
select iTime,TenSP,TenHC,VEN,DVT,SoLuong,DonGiaVAT,ThanhTien,Tong from @T2 
commit tran
GO
---
if exists(select name from sysobjects where name ='sp_ThongKeABCVENTheoThuocNoiNgoai')
	drop procedure sp_ThongKeABCVENTheoThuocNoiNgoai
go
CREATE proc sp_ThongKeABCVENTheoThuocNoiNgoai
@VENABC_Code as varchar(15)

as
begin tran
declare @T as table
(	Id int identity(1,1),
	ItemName nvarchar(150),
	Active nvarchar(500),
	UnitOfMeasureName nvarchar(50),
	CountryName nvarchar(250),
	Quantity int,
	UnitPriceVAT money,
	Amount money,
	Total money,
	TiLe float,
	TiLeTL float,
	ABC nvarchar(5)
)

insert into @T(ItemName,Active,UnitOfMeasureName,CountryName,Quantity,UnitPriceVAT,Amount)
select a.ItemName,a.Active,a.UnitOfMeasureName,a.CountryName,sum(a.Quantity)as Quantity,a.UnitPriceVAT,sum(a.Quantity*a.UnitPriceVAT)as Amount
from VENABC_AnalistDetail a 
where a.VENABC_Code=@VENABC_Code
group by a.ItemName,a.Active,a.UnitOfMeasureName,a.CountryName,a.UnitPriceVAT
order by Amount desc

update @T set Total=(select sum(Amount) from @T)

update @T set TiLe=Amount/Total *100

declare @r as int,@i as int
set @r=(select count(Id) from @T)
set @i=1
while (@i<=@r)
	begin
		if @i-1=0
			update @T set TiLeTL=TiLe where id=@i
		else		
			update @T set TiLeTL=TiLe+(select TiLeTL from @T where id=@i-1) where id=@i

		set @i=@i+1
	end
update @T set ABC='A' where TiLeTL>=0 and TiLeTL<=75
update @T set ABC='B' where TiLeTL>75 and TiLeTL<=90
update @T set ABC='C' where TiLeTL>90 and TiLeTL<=100

select ItemName,Active,UnitOfMeasureName,CountryName,Quantity,UnitPriceVAT,Amount,Total,TiLe,TiLeTL,ABC from @T 
commit tran
GO
