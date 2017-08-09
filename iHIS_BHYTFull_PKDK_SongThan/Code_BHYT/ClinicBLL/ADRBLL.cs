using ClinicDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicModel;

namespace ClinicBLL
{
    public class ADRBLL
    {
        public static DataTable GetListDonVi(int id)
        {
            return ADRDAL.GetListDonVi(id);
        }
        public static ADR_PhieuBaoCaoInf GetChiTietPhieu(int id)
        {
            try
            {
                DataTable tb = ADRDAL.GetDanhSachPhieu(id);
                ADR_PhieuBaoCaoInf model = new ADR_PhieuBaoCaoInf();
                model.Id = Convert.ToInt32(tb.Rows[0]["Id"]);
                model.NoiBaoCao = tb.Rows[0]["NoiBaoCao"].ToString();
                model.MasoBaoCao = tb.Rows[0]["MaSoBaoCao"].ToString();
                model.NgayBaoCao = Convert.ToDateTime(tb.Rows[0]["NgayBaoCao"].ToString());
                model.NguoiBaoCao = tb.Rows[0]["NguoiBaoCao"].ToString();
                model.NgheNghiep = tb.Rows[0]["NgheNghiep"].ToString();
                model.SoDienThoai = tb.Rows[0]["SoDienThoai"].ToString();
                model.DangBaoCao = tb.Rows[0]["DangBaoCao"].ToString();
                return model;
            }
            catch { return null; }
        }
        public static Int16 CheckExistId(string id)
        {
            return ADRDAL.CheckExistId(id);
        }

        public static DataTable GetDanhSachPhieu(int idMaBaoCao)
        {
            return ADRDAL.GetDanhSachPhieu(idMaBaoCao);
        }
        public static Int16 InsUpd_ADR(ADR_PhieuBaoCaoInf info)
        {
            return ADRDAL.InsUpd_ADR(info);
        }

        public static Int16 Del_ADR(int id)
        {
            return ADRDAL.Del_ADR(id);
        }
        public static DataTable GetListBenhNhan(int idPhieu)
        {
            return ADRDAL.GetListBenhNhan(idPhieu);
        }
        public static Int16 InsUpd_BenhNhan(ADR_BenhNhanInf info)
        {
            return ADRDAL.InsUpd_BenhNhan(info);
        }
        public static void InsMulti_BenhNhan(List<ADR_BenhNhanInf> lstModel)
        {
            ADRDAL.InsMulti_BenhNhan(lstModel);
        }
        public static DataTable GetListThuoc(int idBN)
        {
            return ADRDAL.GetListThuoc(idBN);
        }
        public static Int16 Del_DanhSachBenhNhan(int id)
        {
            return ADRDAL.Del_DanhSachBenhNhan(id);
        }
        public static DataTable Report_PhanLoaiSST(DateTime from, DateTime to)
        {
            return ADRDAL.Report_PhanLoaiSST(from, to);
        }
        public static DataTable Report_Tuoi(DateTime from, DateTime to)
        {
            return ADRDAL.Report_Tuoi(from, to);
        }
        public static DataTable Report_GioiTInh(DateTime from, DateTime to)
        {
            return ADRDAL.Report_GioiTInh(from, to);
        }
        public static DataTable Report_DuongDung(DateTime from, DateTime to)
        {
            return ADRDAL.Report_DuongDung(from, to);
        }
        public static DataTable Report_ATC(DateTime from, DateTime to)
        {
            return ADRDAL.Report_ATC(from, to);
        }
        public static DataTable Report_ThuocNghiNgo(DateTime from, DateTime to)
        {
            return ADRDAL.Report_ThuocNghiNgo(from, to);
        }

        public static DataTable Get_Catalog_ATC()
        {
            return ADRDAL.Get_Catalog_ATC();
        }

        public static Int16 InsThuoc(ADR_ThongTinThuoc thuoc)
        {
            return ADRDAL.InsThuoc(thuoc);
        }
        public static Int16 UpdThuoc(ADR_ThongTinThuoc thuoc)
        {
            return ADRDAL.UpdThuoc(thuoc);
        }
        public static Int16 UpdThuoc_Ngung(ADR_ThongTinThuoc thuoc)
        {
            return ADRDAL.UpdThuoc_Ngung(thuoc);
        }
        public static Int16 UpdThuoc_XuatHien(ADR_ThongTinThuoc thuoc)
        {
            return ADRDAL.UpdThuoc_XuatHien(thuoc);
        }

        public static Int16 DelThuoc(int id)
        {
            return ADRDAL.DelThuoc(id);
        }

        public static DataTable getBenhNhan(int idBn)
        {
            return ADRDAL.getBenhNhan(idBn);
        }

        public static int Update_BenhNhan(ADR_BenhNhanInf info)
        {
            return ADRDAL.Update_BenhNhan(info);
        } 
    }
}
