
EXEC sp_rename 'ADR_PhieuBaoCao.IdNoiBaoCao', 'NoiBaoCao', 'COLUMN'
go
EXEC sp_rename 'SaiSot_PhieuBaoCao.IdNoiBaoCao', 'NoiBaoCao', 'COLUMN'
go
ALTER TABLE ADR_PhieuBaoCao ALTER COLUMN NoiBaoCao nvarchar(500);
ALTER TABLE SaiSot_PhieuBaoCao ALTER COLUMN NoiBaoCao nvarchar(500);
go
IF  NOT EXISTS (SELECT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ADR_DonViBaoCao')
	CREATE TABLE ADR_DonViBaoCao(
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[TenDonVi] [nvarchar](100) NULL,
		[MaSoBaoCaoCuaDonVi] [nvarchar](50) NULL,
	 CONSTRAINT [PK_ADR_DonViBaoCao] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
GO
/*
SET IDENTITY_INSERT ADR_DonViBaoCao ON
INSERT ADR_DonViBaoCao ([Id], [TenDonVi], [MaSoBaoCaoCuaDonVi]) VALUES (1, N'Bênh viên Quận 11', N'01')
*/
SET IDENTITY_INSERT ADR_DonViBaoCao OFF
go
IF  NOT EXISTS (SELECT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ADR_PhieuBaoCao')
	CREATE TABLE ADR_PhieuBaoCao(
		[Id] [bigint] IDENTITY(1,1) NOT NULL,
		[IdNoiBaoCao] [int] NULL,
		[MaSoBaoCao] [nvarchar](50) NULL,
		[NgayBaoCao] [datetime] NULL,
		[NguoiBaoCao] [nvarchar](100) NULL,
		[NgheNghiep] [nvarchar](100) NULL,
		[SoDienThoai] [nvarchar](50) NULL,
		[DangBaoCao] [nvarchar](50) NULL,
	 CONSTRAINT [PK_ADR_PhieuBaoCao] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
GO
IF  NOT EXISTS (SELECT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ADR_BenhNhan')
CREATE TABLE ADR_BenhNhan(
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPhieuBaoCao] [bigint] NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [nchar](20) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[CanNang] [nvarchar](50) NULL,
	[NgayXuatHienPhanUng] [nchar](20) NULL,
	[PhanUngXuatHienSau] [nvarchar](200) NULL,
	[MoTaBieuHien] [nvarchar](max) NULL,
	[CacXetNghiemLienQuan] [nvarchar](max) NULL,
	[TienSu] [nvarchar](max) NULL,
	[CachXuTri] [nvarchar](max) NULL,
	[MucDo_TuVong] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_MucDo_TuVong]  DEFAULT ((0)),
	[MucDo_DeDoaTinhMang] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_MucDo_DeDoaTinhMang]  DEFAULT ((0)),
	[MucDo_NhapVien] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_MucDo_NhapVien]  DEFAULT ((0)),
	[MucDo_TanTat] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_MucDo_TanTat]  DEFAULT ((0)),
	[MucDo_DiTat] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_MucDo_DiTat]  DEFAULT ((0)),
	[MucDo_KhongNghiemTrong] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_MucDo_KhongNghiemTrong]  DEFAULT ((0)),
	[KetQua_TuVongDoADR] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_KetQua_TuVongDoADR]  DEFAULT ((0)),
	[KetQua_TuVongKoLienQuan] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_KetQua_TuVongKoLienQuan]  DEFAULT ((0)),
	[KetQua_ChuaPhucHoi] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_KetQua_ChuaPhucHoi]  DEFAULT ((0)),
	[KetQua_DangHoiPhuc] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_KetQua_DangHoiPhuc]  DEFAULT ((0)),
	[KetQua_HoiPhucCoDiChung] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_KetQua_HoiPhucCoDiChung]  DEFAULT ((0)),
	[KetQua_HoiPhucKoDiChung] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_KetQua_HoiPhucKoDiChung]  DEFAULT ((0)),
	[KetQua_KoRo] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_KetQua_KoRo]  DEFAULT ((0)),
	[DanhGia_ChacChan] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DanhGia_ChacChan]  DEFAULT ((0)),
	[DanhGia_CoKhaNang] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DanhGia_CoKhaNang]  DEFAULT ((0)),
	[DanhGia_CoThe] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DanhGia_CoThe]  DEFAULT ((0)),
	[DanhGia_KoChacChan] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DanhGia_KoChacChan]  DEFAULT ((0)),
	[DanhGia_ChuaPhanLoai] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DanhGia_ChuaPhanLoai]  DEFAULT ((0)),
	[DanhGia_KoThePhanLoai] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DanhGia_KoThePhanLoai]  DEFAULT ((0)),
	[DanhGia_Khac] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DanhGia_Khac]  DEFAULT ((0)),
	[DanhGia_Khac_DienGiai] [nvarchar](max) NULL,
	[ThangThamDinh_WHO] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_ThangThamDinh_WHO]  DEFAULT ((0)),
	[ThangThamDinh_Naranjo] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_ThangThamDinh_Naranjo]  DEFAULT ((0)),
	[ThangThamDinh_Khac] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_ThangThamDinh_Khac]  DEFAULT ((0)),
	[ThangThamDinh_Khac_DienGiai] [nvarchar](max) NULL,
	[BinhLuan] [nvarchar](max) NULL,
	[NguoiBC_HoTen] [nvarchar](200) NULL,
	[NguoiBC_NgheNghiep] [nvarchar](200) NULL,
	[NguoiBC_DienThoai] [nvarchar](200) NULL,
	[NguoiBC_Email] [nvarchar](200) NULL,
	[NguoiBC_LanDau] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_NguoiBC_LanDau]  DEFAULT ((0)),
	[NguoiBC_BoSung] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_NguoiBC_BoSung]  DEFAULT ((0)),
	[NguoiBC_NgayBC] [nchar](20) NULL,
	[DI_GuiXacNhan] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_GuiXacNhan]  DEFAULT ((0)),
	[DI_PhanLoai_ThuocMoi] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_PhanLoai_ThuocMoi]  DEFAULT ((0)),
	[DI_PhanLoai_NghiemTrong] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_PhanLoai_NghiemTrong]  DEFAULT ((0)),
	[DI_PhanLoai_ThuocCu] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_PhanLoai_ThuocCu]  DEFAULT ((0)),
	[DI_PhanLoai_KoNghiemTrong] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_PhanLoai_KoNghiemTrong]  DEFAULT ((0)),
	[DI_PhanUngDaCoCSDL] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_PhanUngDaCoCSDL]  DEFAULT ((0)),
	[DI_NhapDuLieuVaoHeCSDL] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_NhapDuLieuVaoHeCSDL]  DEFAULT ((0)),
	[DI_NhapDuLieuPMVigiflow] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_NhapDuLieuPMVigiflow]  DEFAULT ((0)),
	[DI_MucDo_DeDoa] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_MucDo_DeDoa]  DEFAULT ((0)),
	[DI_MucDo_NhapVien] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_MucDo_NhapVien]  DEFAULT ((0)),
	[DI_MucDo_GayDiTat] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_MucDo_GayDiTat]  DEFAULT ((0)),
	[DI_MucDo_LienQuanLamDung] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_MucDo_LienQuanLamDung]  DEFAULT ((0)),
	[DI_GuiBCHoiDong] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_GuiBCHoiDong]  DEFAULT ((0)),
	[DI_GuiBCHoiDong_NgayGui] [nchar](20) NULL,
	[DI_GuiBCUMC] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_GuiBCUMC]  DEFAULT ((0)),
	[DI_GuiBCUMC_NgayGui] [nchar](20) NULL,
	[DI_KQTD_ChacChan] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_KQTD_ChacChan]  DEFAULT ((0)),
	[DI_KQTD_CoKhaNang] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_KQTD_CoKhaNang]  DEFAULT ((0)),
	[DI_KQTD_CoThe] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_KQTD_CoThe]  DEFAULT ((0)),
	[DI_KQTD_KoChacChan] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_KQTD_KoChacChan]  DEFAULT ((0)),
	[DI_KQTD_ChuaPhanLoai] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_KQTD_ChuaPhanLoai]  DEFAULT ((0)),
	[DI_KQTD_KoThePhanLoai] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_KQTD_KoThePhanLoai]  DEFAULT ((0)),
	[DI_KQTD_Khac] [bit] NULL CONSTRAINT [DF_ADR_BenhNhan_DI_KQTD_Khac]  DEFAULT ((0)),
	[DI_KQTD_Khac_DienGiai] [nvarchar](max) NULL,
	[DI_NguoiQuanLyBC] [nvarchar](50) NULL,
	[DI_NgayBC] [nchar](20) NULL,
 CONSTRAINT [PK_ADR_BenhNhan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
IF  NOT EXISTS (SELECT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ADR_ThongTinThuoc')
CREATE TABLE [ADR_ThongTinThuoc](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ThuocNghiADR] [bit] NULL,
	[TenThuoc] [nvarchar](max) NULL,
	[DangBaoChe] [nvarchar](max) NULL,
	[NhaSanXuat] [nvarchar](max) NULL,
	[SoLo] [nvarchar](50) NULL,
	[LieuDung1Lan] [nvarchar](50) NULL,
	[SoLanDung1Ngay] [nvarchar](50) NULL,
	[DuongDung] [nvarchar](50) NULL,
	[NgayDT_BatDau] [nchar](20) NULL,
	[NgayDT_KetThuc] [nchar](20) NULL,
	[LyDoDungThuoc] [nvarchar](max) NULL,
	[IdBenhNhan] [bigint] NULL,
	[CaiThienKhiNgung_Co] [bit] NULL CONSTRAINT [DF_ADR_ThongTinThuoc_CaiThienKhiNgung_Co]  DEFAULT ((0)),
	[CaiThienKhiNgung_Khong] [bit] NULL CONSTRAINT [DF_ADR_ThongTinThuoc_CaiThienKhiNgung_Khong]  DEFAULT ((0)),
	[CaiThienKhiNgung_KoNgung] [bit] NULL CONSTRAINT [DF_ADR_ThongTinThuoc_CaiThienKhiNgung_KoNgung]  DEFAULT ((0)),
	[CaiThienKhiNgung_KoCoThongTin] [bit] NULL CONSTRAINT [DF_ADR_ThongTinThuoc_CaiThienKhiNgung_KoCoThongTin]  DEFAULT ((0)),
	[XuatHienPhanUngLai_Co] [bit] NULL CONSTRAINT [DF_ADR_ThongTinThuoc_XuatHienPhanUngLai_Co]  DEFAULT ((0)),
	[XuatHienPhanUngLai_Khong] [bit] NULL CONSTRAINT [DF_ADR_ThongTinThuoc_XuatHienPhanUngLai_Khong]  DEFAULT ((0)),
	[XuatHienPhanUngLai_KoTaiSuDung] [bit] NULL CONSTRAINT [DF_ADR_ThongTinThuoc_XuatHienPhanUngLai_KoTaiSuDung]  DEFAULT ((0)),
	[XuatHienPhanUngLai_KoCoThongTin] [bit] NULL CONSTRAINT [DF_ADR_ThongTinThuoc_[XuatHienPhanUngLai_KoCoThongTin]  DEFAULT ((0)),
	[MaPhanLoaiATC] [nvarchar](50) NULL,
 CONSTRAINT [PK_ADR_ThongTinThuoc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
----------------- Proc ADR
if exists(select name from sysobjects where name ='proIU_PhieuADR')
	drop procedure proIU_PhieuADR
go
create proc proIU_PhieuADR
	@Id int,
	@NoiBaoCao nvarchar(500) ,
	@MaSoBaoCao nvarchar(50) ,
	@NgayBaoCao datetime ,
	@NguoiBaoCao nvarchar(100) ,
	@NgheNghiep nvarchar(100) ,
	@SoDienThoai nvarchar(50) ,
	@DangBaoCao nvarchar(50) 
as
	declare @result int
	begin tran
		begin try
			if (@Id =0)
			begin
			INSERT INTO [ADR_PhieuBaoCao](NoiBaoCao ,MaSoBaoCao,NgayBaoCao,NguoiBaoCao ,NgheNghiep ,SoDienThoai ,DangBaoCao )
			VALUES (@NoiBaoCao ,@MaSoBaoCao,@NgayBaoCao,@NguoiBaoCao ,@NgheNghiep ,@SoDienThoai ,@DangBaoCao )
			set @result=(select @@identity)
			end
			else
			begin
			update [ADR_PhieuBaoCao] set NoiBaoCao=@NoiBaoCao ,MaSoBaoCao=@MaSoBaoCao,NgayBaoCao=@NgayBaoCao,NguoiBaoCao=@NguoiBaoCao ,NgheNghiep=@NgheNghiep ,SoDienThoai=@SoDienThoai ,DangBaoCao=@DangBaoCao
			where id=@Id 
			set @result=@Id 
			end
			--
		end try	
		begin catch
			set @result =-1--(SELECT ERROR_NUMBER() AS ErrorNumber)
			ROLLBACK TRAN
		end catch
		IF @@TRANCOUNT >0					
			commit tran
GO
if exists(select name from sysobjects where name ='proIU_BenhNhanADR')
	drop procedure proIU_BenhNhanADR
go
create proc proIU_BenhNhanADR
	@Id int,
	@IdPhieuBaoCao int ,
	@HoTen nvarchar(50) ,
	@NgaySinh nchar(20) ,
	@GioiTinh nvarchar(50) ,
	@CanNang nvarchar(50) ,
	@NgayXuatHienPhanUng nchar(20) ,
	@MoTaBieuHien nvarchar(MAX)
as
	declare @result int
	begin tran
		begin try
			if (@Id =0)
				begin
				INSERT INTO ADR_BenhNhan(IdPhieuBaoCao,HoTen,NgaySinh ,GioiTinh ,CanNang ,NgayXuatHienPhanUng, MoTaBieuHien)
				VALUES (@IdPhieuBaoCao,@HoTen,@NgaySinh ,@GioiTinh ,@CanNang ,@NgayXuatHienPhanUng, @MoTaBieuHien)
				set @result=(select @@identity)
				end
			else
				begin
				update ADR_BenhNhan set HoTen=@HoTen ,NgaySinh=@NgaySinh,GioiTinh=@GioiTinh,CanNang=@CanNang ,NgayXuatHienPhanUng=@NgayXuatHienPhanUng ,MoTaBieuHien=@MoTaBieuHien
				where id=@Id 
				set @result=@Id 
			end
			--
		end try	
		begin catch
			set @result =-1--(SELECT ERROR_NUMBER() AS ErrorNumber)
			ROLLBACK TRAN
		end catch
		IF @@TRANCOUNT >0					
			commit tran
	return @result
GO
if exists(select name from sysobjects where name ='proADR_SoLuongBaoCaoHangThang')
	drop procedure proADR_SoLuongBaoCaoHangThang
go
CREATE proc proADR_SoLuongBaoCaoHangThang
	@TuNgay date,
	@DenNgay date
as
begin tran
	declare @total as decimal(18,4)
	declare @A table  
	(
	Thang int,
	Nam int,
	SoLuong decimal(18,4),
	 TyLe decimal(18,4)
	)
	insert into @A 
		select  CONVERT(int, MONTH(P.NgayBaoCao)) as Thang, CONVERT(int, Year(P.NgayBaoCao)) as Nam, COUNT(BN.HoTen)as SoLuong,0 as TyLe  from ADR_PhieuBaoCao  P
			inner join ADR_BenhNhan BN on P.Id =BN.IdPhieuBaoCao 
			where CONVERT(date,P.NgayBaoCao,103) between CONVERT(date,@TuNgay,103) and CONVERT(date,@DenNgay,103)
			group by CONVERT(int, MONTH(P.NgayBaoCao)), CONVERT(int, Year(P.NgayBaoCao))--CONVERT(varchar, MONTH(P.NgayBaoCao))+ '/'+ CONVERT(varchar, Year(P.NgayBaoCao))
			order by  CONVERT(int, Year(P.NgayBaoCao)),CONVERT(int, MONTH(P.NgayBaoCao))
	set @total = (select sum(SoLuong)  from @A)
	update @A set TyLe = SoLuong*100/@total
	select ROW_NUMBER()  OVER (ORDER BY A.Thang) AS STT,	CONVERT(nvarchar , A.Thang) +'/' +  CONVERT(nvarchar, A.Nam ) as Thang, A.SoLuong ,A.TyLe  from @A as A
commit tran
GO
if exists(select name from sysobjects where name ='proADR_ThongTinBN_Tuoi_1')
	drop procedure proADR_ThongTinBN_Tuoi_1
go
CREATE proc proADR_ThongTinBN_Tuoi_1
@TuNgay as date,
@DenNgay as date
as
begin tran
	declare @tuoi table
    (
	   tuoi int
    );
	Insert into @tuoi(Tuoi) 
	(
		select 
		(case when BN.NgaySinh != '' 
			Then (YEAR(GETDATE()) - CONVERT(INT, BN.NgaySinh)) 
			else '-1'
		end) as Tuoi 
		from ADR_PhieuBaoCao  P
			inner join ADR_BenhNhan BN on P.Id =BN.IdPhieuBaoCao 
			where convert(date,P.NgayBaoCao,103)>=convert(date,@TuNgay,103) and convert(date,P.NgayBaoCao,103)<=convert(date,@DenNgay,103)
	)
	declare @table as table
    (
	   STT int,
	   Tuoi nvarchar(max) NULL,
	   SoLuong decimal(18,4),
	   TyLe decimal(18,4)
    );
	insert into @table(STT,Tuoi,SoLuong,TyLe) values(1, N'<= 01 tuổi', CONVERT(int,(select count(tuoi) from @tuoi where tuoi <= 1 and tuoi > 0)), 0)
	insert into @table(STT,Tuoi,SoLuong,TyLe) values(2, N'>01-12 tuổi',  CONVERT(int,(select count(tuoi) from @tuoi where tuoi > 1 and tuoi <= 12)), 0)
	insert into @table(STT,Tuoi,SoLuong,TyLe) values(3, N'>12-18 tuổi',  CONVERT(int,(select count(tuoi) from @tuoi where tuoi > 12 and tuoi <= 18)), 0)
	insert into @table(STT,Tuoi,SoLuong,TyLe) values(4, N'>18-60 tuổi',CONVERT(int,(select count(tuoi) from @tuoi where tuoi > 18 and tuoi <= 60)), 0)
	insert into @table(STT,Tuoi,SoLuong,TyLe) values(5, N'>60 tuổi', CONVERT(int,(select count(tuoi) from @tuoi where tuoi > 60)), 0)
	insert into @table(STT,Tuoi,SoLuong,TyLe) values(6, N'Không có thông tin	', CONVERT(int,(select count(tuoi) from @tuoi where tuoi = -1)), 0)

	declare @total as decimal(18,4)
	set @total = (select sum(SoLuong) from @table)
	if @total >0
		update @table set TyLe = (SoLuong*100)/@total
	else
		update @table set TyLe = (SoLuong*100)
	select STT, Tuoi, SoLuong, TyLe from @table

commit tran
GO
if exists(select name from sysobjects where name ='f_GioiTinh')
	drop function f_GioiTinh
go
CREATE FUNCTION f_GioiTinh
(
	@data nvarchar(50)
)
RETURNS nvarchar(100)
AS 
BEGIN
	declare  @r as nvarchar(100)
	if (@data <> N'Nam' and @data<>N'Nữ')
	set @r=N'Không có thông tin'
	else 
	set @r=@data
	return @r
END
go
if exists(select name from sysobjects where name ='proADR_ThongTinBN_GioiTinh')
	drop procedure proADR_ThongTinBN_GioiTinh
go
CREATE proc proADR_ThongTinBN_GioiTinh
	@TuNgay as date,
	@DenNgay as date
as
begin tran
declare @table as table
    (
	   STT int,
	   GioiTinh nvarchar(max) NULL,
	   SoLuong decimal(18,4),
	   TyLe decimal(18,4)
    );
Insert into @table(STT, GioiTinh, SoLuong, TyLe) 
	(
		select ROW_NUMBER()  OVER (ORDER BY GioiTinh) AS STT,GioiTinh,count(HoTen) as SoLuong,0 as TyLe from 
		(
			select dbo.f_GioiTinh(BN.GioiTinh) as GioiTinh,BN.HoTen  from ADR_PhieuBaoCao  P
				inner join ADR_BenhNhan BN on P.Id =BN.IdPhieuBaoCao 
				where convert(date,P.NgayBaoCao,103) between convert(date,@TuNgay,103) and CONVERT(date,@DenNgay,103)
		)As BN_Tuoi
				group by GioiTinh
	)
	declare @total as decimal(18,4)
	set @total = (select sum(SoLuong) from @table)
	update @table set TyLe = SoLuong*100/@total
	select STT, GioiTinh, SoLuong, TyLe from @table
commit tran
GO
if exists(select name from sysobjects where name ='proADR_ThongTinBN_DuongDung')
	drop procedure proADR_ThongTinBN_DuongDung
go
CREATE proc proADR_ThongTinBN_DuongDung
@TuNgay as date,
@DenNgay as date
as
begin tran
 declare @table as table
    (
	   STT int,
	   DuongDung nvarchar(max) NULL,
	   SoLuong decimal(18,4),
	   TyLe decimal(18,4)
    );

Insert into @table(STT, DuongDung, SoLuong, TyLe) 
(
	select ROW_NUMBER()  OVER (ORDER BY TT.DuongDung) AS STT, TT.DuongDung  as DuongDung,count(TT.TenThuoc) as SoLuong,0 as TyLe  from ADR_PhieuBaoCao  P
		inner join ADR_BenhNhan BN on P.Id =BN.IdPhieuBaoCao 
		inner join ADR_ThongTinThuoc TT on TT.IdBenhNhan =BN.Id 
		where convert(date,P.NgayBaoCao,103)>=convert(date,@TuNgay,103) and convert(date,P.NgayBaoCao,103)<=convert(date,@DenNgay,103) and TT.ThuocNghiADR =1
		group by TT.DuongDung
)
	declare @total as decimal(18,4)

	set @total = (select sum(SoLuong) from @table)

	update @table set TyLe = SoLuong*100/@total

	select STT, DuongDung, SoLuong, TyLe from @table
		
commit tran
GO
if exists(select name from sysobjects where name ='proADR_ThongTinBN_NhomATC')
	drop procedure proADR_ThongTinBN_NhomATC
go
CREATE proc proADR_ThongTinBN_NhomATC
@TuNgay as date,
@DenNgay as date
as
begin tran
	 declare @table as table
    (
	   STT int,
	   PhanLoai nvarchar(max) NULL,
	   NhomThuoc nvarchar(max) NULL,
	   SoLuong decimal(18,4),
	   TyLe decimal(18,4)
    );

	Insert into @table(STT, PhanLoai, NhomThuoc, SoLuong, TyLe) 
	
		select ROW_NUMBER()  OVER (ORDER BY ATC.ATCCode) AS STT,
		isnull(ATC.ATCCode,'') as MaATC,isnull(ATC.ATCName,'') as TenATC,count(TT.TenThuoc) as SoLuong,0 as TyLe  from ADR_PhieuBaoCao  P
		inner join ADR_BenhNhan BN on P.Id =BN.IdPhieuBaoCao 
		inner join ADR_ThongTinThuoc TT on TT.IdBenhNhan = BN.Id 
		left join Catalog_ATC ATC on ATC.RowID=TT.MaPhanLoaiATC
		where convert(date,P.NgayBaoCao,103)>=convert(date,@TuNgay,103) and convert(date,P.NgayBaoCao,103)<=convert(date,@DenNgay,103) and TT.ThuocNghiADR =1
		group by TT.MaPhanLoaiATC,ATC.ATCName, ATC.ATCCode
		order by ATC.ATCCode
	declare @total as decimal(18,4)

	set @total = (select sum(SoLuong) from @table)

	update @table set TyLe = SoLuong*100/@total

	select STT, PhanLoai, NhomThuoc, SoLuong, TyLe from @table
commit tran
GO
if exists(select name from sysobjects where name ='proADR_ThongTinBN_ThuocNghiNgoADRNhieuNhat')
	drop procedure proADR_ThongTinBN_ThuocNghiNgoADRNhieuNhat
go
CREATE proc proADR_ThongTinBN_ThuocNghiNgoADRNhieuNhat
@TuNgay as date,
@DenNgay as date
as
begin tran

	 declare @table as table
    (
	   STT int,
	   TenThuoc nvarchar(max) NULL,
	   SoLuong decimal(18,4),
	   TyLe decimal(18,4)
    );

	Insert into @table(STT, TenThuoc, SoLuong, TyLe) 
 select ROW_NUMBER()  OVER (ORDER BY TenThuoc) AS STT, TenThuoc,SoLuong,Tyle from 
	(select TT.TenThuoc,count(TT.TenThuoc) as SoLuong,0 as TyLe  from ADR_PhieuBaoCao  P
		inner join ADR_BenhNhan BN on P.Id =BN.IdPhieuBaoCao 
		inner join ADR_ThongTinThuoc TT on TT.IdBenhNhan =BN.Id 
		where convert(date,P.NgayBaoCao,103)>=convert(date,@TuNgay,103) and convert(date,P.NgayBaoCao,103)<=convert(date,@DenNgay,103) and TT.ThuocNghiADR =1
		group by TT.TenThuoc
	) as AAA
	order by SoLuong desc
	declare @total as decimal(18,4)
	set @total = (select sum(SoLuong) from @table)
	update @table set TyLe = SoLuong*100/@total
	select STT, TenThuoc, SoLuong, TyLe from @table
commit tran
GO
---------------------------------- Table sai sot thuoc
IF  NOT EXISTS (SELECT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SaiSot_PhieuBaoCao')
CREATE TABLE [SaiSot_PhieuBaoCao](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdNoiBaoCao] [int] NULL,
	[MaSoBaoCao] [nvarchar](50) NULL,
	[NgayNhapPhieu] [datetime] NULL,
	[Ghichu] [nvarchar](max) NULL,
	[TongLuotKham] [nvarchar](50) NULL,
 CONSTRAINT [PK_SaiSot_PhieuBaoCao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
IF  NOT EXISTS (SELECT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SaiSot_DanhSach')
CREATE TABLE [SaiSot_DanhSach](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPhieuBaoCao] [bigint] NULL,
	[NgayBaoCao] [datetime] NULL,
	[NguoiBaoCao] [nvarchar](200) NULL,
	[ThoiGianXayRaSuCo] [nvarchar](200) NULL,
	[KhoaPhong_DiaDiemXayRa] [nvarchar](300) NULL,
	[MoTaSuCo] [nvarchar](max) NULL,
	[HauQuaXayRa] [nvarchar](max) NULL,
	[CachXuTriTucThoi] [nvarchar](max) NULL,
	[CapBaoCao] [nvarchar](300) NULL,
	[GiaiPhapKhacPhuc] [nvarchar](max) NULL,
	[TrachNhiem] [nvarchar](max) NULL,
	[DanhGiaLai] [nvarchar](max) NULL,
	[Ghichu] [nvarchar](max) NULL,
	[HinhThucSaiSot] [nvarchar](200) NULL,
	[PhanLoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_SaiSot_DanhSach] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
IF  NOT EXISTS (SELECT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SaiSot_Nhom')
CREATE TABLE [SaiSot_Nhom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ma] [nvarchar](10) NULL,
	[Ten] [nvarchar](max) NULL,
	[IdPhanLoai] [int] NULL,
 CONSTRAINT [PK_SaiSot_Nhom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/*
SET IDENTITY_INSERT [SaiSot_Nhom] ON 
INSERT [SaiSot_Nhom] ([Id], [Ma], [Ten], [IdPhanLoai]) VALUES (1, N'A', N'Tình huống hoặc biến cố có khả năng gây ra sai sót', 1)
INSERT [SaiSot_Nhom] ([Id], [Ma], [Ten], [IdPhanLoai]) VALUES (2, N'B', N'Có sai sót nhưng thuốc chưa tiếp cận đến người bệnh ', 2)
INSERT [SaiSot_Nhom] ([Id], [Ma], [Ten], [IdPhanLoai]) VALUES (3, N'C', N'Có sai sót và đã tiếp cận đến người bệnh nhưng không gây tác hại', 2)
INSERT [SaiSot_Nhom] ([Id], [Ma], [Ten], [IdPhanLoai]) VALUES (4, N'D', N'Sai sót xảy ra và đã tiếp cận đến người bệnh dẫn đến yêu cầu theo dõi', 2)
INSERT [SaiSot_Nhom] ([Id], [Ma], [Ten], [IdPhanLoai]) VALUES (5, N'E', N'Sai sót xảy ra có thể đã gây tác hại hoặc góp phần gây tác hại tạm thời cho người bệnh và cần các biện pháp can thiệp ', 3)
INSERT [SaiSot_Nhom] ([Id], [Ma], [Ten], [IdPhanLoai]) VALUES (6, N'F', N'Sai sót xảy ra có thể đã gây tác hại hoặc góp phần gây tác hại tạm thời cho người bệnh và cần nhập viện hoặc kéo dài thời gian nằm viện ', 3)
INSERT [SaiSot_Nhom] ([Id], [Ma], [Ten], [IdPhanLoai]) VALUES (7, N'G', N'Sai sót xảy ra có thể đac gay tác hại hoặc góp phần gây tác hại không phục hồi cho người bệnh', 3)
INSERT [SaiSot_Nhom] ([Id], [Ma], [Ten], [IdPhanLoai]) VALUES (8, N'H', N'Sai sót xảy ra yêu cầu các can thiệp cần thiết để duy trì sự sống ', 3)
INSERT [SaiSot_Nhom] ([Id], [Ma], [Ten], [IdPhanLoai]) VALUES (9, N'I', N'Sai sót xảy ra góp phần hoặc gây ra tử vong cho người bệnh ', 4)
SET IDENTITY_INSERT [SaiSot_Nhom] OFF
go
*/
IF  NOT EXISTS (SELECT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SoiSot_PhanLoai')
CREATE TABLE [SoiSot_PhanLoai](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](max) NULL,
 CONSTRAINT [PK_SoiSot_PhanLoai] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/*
SET IDENTITY_INSERT [SoiSot_PhanLoai] ON 
INSERT [SoiSot_PhanLoai] ([Id], [Ten]) VALUES (1, N'Không có sai sót')
INSERT [SoiSot_PhanLoai] ([Id], [Ten]) VALUES (2, N'Sai sót không gây tổn hại')
INSERT [SoiSot_PhanLoai] ([Id], [Ten]) VALUES (3, N'Sai sót gây tổn hại')
INSERT [SoiSot_PhanLoai] ([Id], [Ten]) VALUES (4, N'Sai sót gây tử vong')
SET IDENTITY_INSERT [dbo].[SoiSot_PhanLoai] OFF
go
*/
----- Proc sai sot thuoc
if exists(select name from sysobjects where name ='proIU_PhieuSaiSot')
	drop procedure proIU_PhieuSaiSot
go
CREATE proc proIU_PhieuSaiSot
	@Id int,
	@NoiBaoCao nvarchar(500) ,
	@MaSoBaoCao nvarchar(50) ,
	@NgayNhapPhieu datetime ,
	@Ghichu nvarchar(max) ,
	@TongLuotKham nvarchar(50)

as
	declare @result int
	begin tran
		begin try
			if (@Id =0)
			begin
			INSERT INTO [SaiSot_PhieuBaoCao](NoiBaoCao ,MaSoBaoCao,NgayNhapPhieu ,Ghichu,TongLuotKham )
			VALUES (@NoiBaoCao ,@MaSoBaoCao,@NgayNhapPhieu,@Ghichu ,@TongLuotKham )
			set @result=(select @@identity)
			end
			else
			begin
			update [SaiSot_PhieuBaoCao] set NoiBaoCao=@NoiBaoCao ,MaSoBaoCao=@MaSoBaoCao,NgayNhapPhieu =@NgayNhapPhieu, TongLuotKham=@TongLuotKham
			where id=@Id 
			set @result=@Id 
			end
			--
		end try	
		begin catch
			set @result =-1--(SELECT ERROR_NUMBER() AS ErrorNumber)
			ROLLBACK TRAN
		end catch
		IF @@TRANCOUNT >0					
			commit tran
	return @result
GO
if exists(select name from sysobjects where name ='proSaiSot_ThongTinBN_KhoaPhong')
	drop procedure proSaiSot_ThongTinBN_KhoaPhong
go
CREATE proc [proSaiSot_ThongTinBN_KhoaPhong]
@TuNgay as date,
@DenNgay as date
as
begin tran
	declare @total as decimal(18,4)
	declare @tableTotal as table
    (
	   SoLuong int NULL
    );

	declare @table as table
    (
	   STT int,
	   KhoaPhong nvarchar(max) NULL,
	   SoLuong decimal(18,4),
	   TyLe decimal(18,4)
    );

	Insert into @table(STT, KhoaPhong, SoLuong, TyLe) 
	(select ROW_NUMBER()  OVER (ORDER BY SS.KhoaPhong_DiaDiemXayRa) AS STT,   SS.KhoaPhong_DiaDiemXayRa as KhoaPhong, count(SS.Id)  as SoLuong,0 as TyLe from SaiSot_PhieuBaoCao  P
		inner join  SaiSot_DanhSach SS on P.Id =SS.IdPhieuBaoCao 
		where convert(date,SS.NgayBaoCao,103)>=convert(date,@TuNgay,103) and convert(date,SS.NgayBaoCao,103)<=convert(date,@DenNgay,103) 
		group by KhoaPhong_DiaDiemXayRa)
	set @total = (select sum(SoLuong) from @table)
	update @table
	set TyLe = SoLuong*100/@total
	select * from @table
commit tran
GO
if exists(select name from sysobjects where name ='proSaiSot_HinhThucSaiSot')
	drop procedure proSaiSot_HinhThucSaiSot
go
CREATE proc [proSaiSot_HinhThucSaiSot]
@TuNgay as date,
@DenNgay as date
as
begin tran
	declare @total as decimal(18,4)=0
	declare @tableTotal as table
    (
	   SoLuong int NULL
    );
	declare @table as table
    (
	   STT int,
	   HinhThuc nvarchar(max) NULL,
	   SoLuong decimal(18,4),
	   TyLe decimal(18,4)
    );
	Insert into @table(STT, HinhThuc, SoLuong, TyLe) 
	(
	select ROW_NUMBER()  OVER (ORDER BY SS.HinhThucSaiSot) AS STT, SS.HinhThucSaiSot as HinhThuc,count(SS.Id)  as SoLuong,0 as TyLe from SaiSot_PhieuBaoCao  P
		inner join  SaiSot_DanhSach SS on P.Id =SS.IdPhieuBaoCao 
		where convert(date,SS.NgayBaoCao,103)>=convert(date,@TuNgay,103) and convert(date,SS.NgayBaoCao,103)<=convert(date,@DenNgay,103)
		group by HinhThucSaiSot
		)
	set @total = (select sum(SoLuong) from @table)
	if @total>0
		update @table set TyLe = SoLuong*100/@total
	else
		update @table set TyLe = SoLuong*100
	select * from @table
commit tran
GO
if exists(select name from sysobjects where name ='proSaiSot_PhanLoaiSaiSot')
	drop procedure proSaiSot_PhanLoaiSaiSot
go
CREATE proc [proSaiSot_PhanLoaiSaiSot]
@TuNgay as date,
@DenNgay as date
as
begin tran
	declare @total as decimal(18,4)
	declare @tableTotal as table
    (
	   SoLuong int NULL
    );
	declare @table as table
    (
	   STT int,
	   PhanLoai nvarchar(max) NULL,
	   Nhom nvarchar(max) NULL,
	   SoLuong decimal(18,4),
	   TyLe decimal(18,4)
    );

	Insert into @table(STT, PhanLoai, Nhom, SoLuong, TyLe) 
select PL.Id as STT,PL.ten as TenPhanLoai,nhom.Ten as TenNhom,TH.SoLuong,TH.TyLe  from 

(	select SS.PhanLoai   as MaNhom,count(SS.Id)  as SoLuong,0 as TyLe from SaiSot_PhieuBaoCao  P
		inner join  SaiSot_DanhSach SS on P.Id =SS.IdPhieuBaoCao 
		where convert(date,SS.NgayBaoCao,103) between convert(date,@TuNgay,103) and convert(date,@DenNgay,103)
		group by PhanLoai
) as TH inner join [SaiSot_Nhom] nhom on nhom.Ma=TH.Manhom
		inner join [SoiSot_PhanLoai] PL on Pl.Id =nhom.IdPhanLoai 
		order by PL.id ,TH.MaNhom 
		set @total = (select sum(SoLuong) from @table)
		update @table
		set TyLe = SoLuong*100/@total
		select * from @table
commit tran
GO
if exists(select name from sysobjects where name ='proIU_DanhSachPhieuSaiSot')
	drop procedure proIU_DanhSachPhieuSaiSot
go
CREATE proc [proIU_DanhSachPhieuSaiSot]
	@Id int,
	@IdPhieuBaoCao bigint NULL,
	@NgayBaoCao datetime NULL,
	@NguoiBaoCao nvarchar(200) NULL,
	@ThoiGianXayRaSuCo nvarchar(200) NULL,
	@KhoaPhong_DiaDiemXayRa nvarchar(300) NULL,
	@MoTaSuCo nvarchar(max) NULL,
	@HauQuaXayRa nvarchar(max) NULL,
	@CachXuTriTucThoi nvarchar(max) NULL,
	@CapBaoCao nvarchar(300) NULL,
	@GiaiPhapKhacPhuc nvarchar(max) NULL,
	@TrachNhiem nvarchar(max) NULL,
	@DanhGiaLai nvarchar(max) NULL,
	@Ghichu nvarchar(max) NULL,
	@HinhThucSaiSot nvarchar(200) NULL,
	@PhanLoai nvarchar(50) NULL
as
	declare @result int
	begin tran
		begin try
			if @Id = 0
			begin
				INSERT INTO SaiSot_DanhSach(IdPhieuBaoCao,NgayBaoCao,NguoiBaoCao,ThoiGianXayRaSuCo,KhoaPhong_DiaDiemXayRa,MoTaSuCo
					 ,HauQuaXayRa,CachXuTriTucThoi,CapBaoCao,GiaiPhapKhacPhuc,TrachNhiem,DanhGiaLai,Ghichu,HinhThucSaiSot,PhanLoai)
				VALUES(@IdPhieuBaoCao,@NgayBaoCao,@NguoiBaoCao,@ThoiGianXayRaSuCo,@KhoaPhong_DiaDiemXayRa,@MoTaSuCo,@HauQuaXayRa
			       ,@CachXuTriTucThoi,@CapBaoCao,@GiaiPhapKhacPhuc,@TrachNhiem,@DanhGiaLai,@Ghichu,@HinhThucSaiSot,@PhanLoai)
			end
			else
			begin
				update SaiSot_DanhSach set NgayBaoCao =@NgayBaoCao,NguoiBaoCao = @NguoiBaoCao,ThoiGianXayRaSuCo = @ThoiGianXayRaSuCo,
										  KhoaPhong_DiaDiemXayRa=@KhoaPhong_DiaDiemXayRa,MoTaSuCo=@MoTaSuCo
					 ,HauQuaXayRa=@HauQuaXayRa,CachXuTriTucThoi=@CachXuTriTucThoi,CapBaoCao=@CapBaoCao,GiaiPhapKhacPhuc=@GiaiPhapKhacPhuc,
					 TrachNhiem=@TrachNhiem,DanhGiaLai=@DanhGiaLai,Ghichu=@Ghichu,HinhThucSaiSot=@HinhThucSaiSot,PhanLoai=@PhanLoai
				where id=@Id 
				set @result=@Id 
			end
		end try	

		begin catch
			set @result =-1--(SELECT ERROR_NUMBER() AS ErrorNumber)
			ROLLBACK TRAN
		end catch
		IF @@TRANCOUNT >0					
			commit tran
	return @result
GO
