using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class ADR_PhieuBaoCaoInf
    {
        public int Id { get; set; }
        public string NoiBaoCao { get; set; }
        public string MasoBaoCao { get; set; }
        public DateTime NgayBaoCao { get; set; }
        public string NguoiBaoCao { get; set; }
        public string NgheNghiep { get; set; }
        public string SoDienThoai { get; set; }
        public string DangBaoCao { get; set; }
    }
    public class ADR_BenhNhanInf
    {
        public int Id { get; set; }
        public int IdPhieuBaoCao { get; set; }
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string CanNang { get; set; }
        public string NgayXuatHienPhanUng { get; set; }
        public string PhanUngXuatHienSau { get; set; }
        public string MoTaBieuHien { get; set; }
        public string CacXetNghiemLienQuan { get; set; }
        public string TienSu { get; set; }
        public string CachXuTri { get; set; }
        public bool MucDo_TuVong { get; set; }
        public bool MucDo_DeDoaTinhMang { get; set; }
        public bool MucDo_NhapVien { get; set; }
        public bool MucDo_TanTat { get; set; }
        public bool MucDo_DiTat { get; set; }
        public bool MucDo_KhongNghiemTrong { get; set; }
        public bool KetQua_TuVongDoADR { get; set; }
        public bool KetQua_TuVongKoLienQuan { get; set; }
        public bool KetQua_ChuaPhucHoi { get; set; }
        public bool KetQua_DangHoiPhuc { get; set; }
        public bool KetQua_HoiPhucCoDiChung { get; set; }
        public bool KetQua_HoiPhucKoDiChung { get; set; }
        public bool KetQua_KoRo { get; set; }
        public string DanhGia_ChacChan { get; set; }
        public string DanhGia_CoKhaNang { get; set; }
        public string DanhGia_CoThe { get; set; }
        public string DanhGia_KoChacChan { get; set; }
        public string DanhGia_ChuaPhanLoai { get; set; }
        public string DanhGia_KoThePhanLoai { get; set; }
        public string DanhGia_Khac { get; set; }
        public string DanhGia_Khac_DienGiai { get; set; }
        public string ThangThamDinh_WHO { get; set; }
        public string ThangThamDinh_Naranjo { get; set; }
        public string ThangThamDinh_Khac { get; set; }
        public string ThangThamDinh_Khac_DienGiai { get; set; }
        public string BinhLuan { get; set; }

        //load Don Vi Bao Cao
        public string TenDonVi { get; set; }
        public string MaSoBaoCaoCuaDonVi { get; set; }
        public string MaSoBaoCao { get; set; }

        //load Phieu Bao Cao
        public string SoDienThoai { get; set; }
        public bool DangBaoCaoLD { get; set; }
        public string NguoiBaoCao { get; set; }
        public string NgayBaoCao { get; set; }
        public string NgheNghiep { get; set; }
    }
    public class ADR_ThongTinThuoc
    {
        public int Id { get; set; }
        public bool ThuocNghiADR { get; set; }
        public string TenThuoc { get; set; }
        public string DangBaoChe { get; set; }
        public string NhaSanXuat { get; set; }
        public string SoLo { get; set; }
        public string LieuDung1Lan { get; set; }
        public string SoLanDung1Ngay { get; set; }
        public string DuongDung { get; set; }
        public string NgayDT_BatDau { get; set; }
        public string NgayDT_KetThuc { get; set; }
        public string LyDoDungThuoc { get; set; }
        public int IdBenhNhan { get; set; }
        public bool CaiThienKhiNgung_Co { get; set; }
        public bool CaiThienKhiNgung_Khong { get; set; }
        public bool CaiThienKhiNgung_KoNgung { get; set; }
        public bool CaiThienKhiNgung_KoCoThongTin { get; set; }
        public bool XuatHienPhanUngLai_Co { get; set; }
        public bool XuatHienPhanUngLai_Khong { get; set; }
        public bool XuatHienPhanUngLai_KoTaiSuDung { get; set; }
        public bool XuatHienPhanUngLai_KoCoThongTin { get; set; }
        public int MaPhanLoaiATC { get; set; }
    }
}
