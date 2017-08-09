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
    public class SSTBLL
    {
        public static DataTable GetListSaiSotThuoc(int id)
        {
            return SSTDAL.GetListSaiSotThuoc(id);
        }

        public static Int16 CheckExistId(string id)
        {
            return SSTDAL.CheckExistId(id);
        }

        public static SaiSot_PhieuBaoCaoInf GetChiTietPhieu(int id)
        {
            try
            {
                DataTable tb = SSTDAL.GetListSaiSotThuoc(id);
                SaiSot_PhieuBaoCaoInf model = new SaiSot_PhieuBaoCaoInf();
                model.Id = Convert.ToInt32(tb.Rows[0]["Id"]);
                model.NoiBaoCao = tb.Rows[0]["NoiBaoCao"].ToString();
                model.NgayNhapPhieu = Convert.ToDateTime(tb.Rows[0]["NgayNhapPhieu"]);
                model.MaSoBaoCao = tb.Rows[0]["MaSoBaoCao"].ToString();
                model.Ghichu = tb.Rows[0]["Ghichu"].ToString();
                model.TongLuotKham = tb.Rows[0]["TongLuotKham"].ToString();
                return model;
            }
            catch { return null; }
        }

        public static Int16 InsUpd_SaiSotThuoc(SaiSot_PhieuBaoCaoInf info)
        {
            return SSTDAL.InsUpd_SaiSotThuoc(info);
        }

        public static Int16 Del_SaiSotThuoc(int id)
        {
            return SSTDAL.Del_SaiSotThuoc(id);
        }

        public static DataTable Report_SSTKhoaPhong(DateTime from, DateTime to)
        {
            return SSTDAL.Report_SSTKhoaPhong(from, to);
        }

        public static DataTable Report_HinhThucSST(DateTime from, DateTime to)
        {
            return SSTDAL.Report_HinhThucSST(from, to);
        }

        public static DataTable Report_PhanLoaiSST(DateTime from, DateTime to)
        {
            return SSTDAL.Report_PhanLoaiSST(from, to);
        }
        public static DataTable GetListDetailSaiSotThuoc(int idPhieu)
        {
            return SSTDAL.GetListDetailSaiSotThuoc(idPhieu);
        }

        public static void InsMulti_DetailSaiSotThuoc(List<SaiSot_DanhSach> lstModel)
        {
            SSTDAL.InsMulti_DetailSaiSotThuoc(lstModel);
        }

        public static Int16 Del_AllDanhSachSaiSotThuoc(int id)
        {
            return SSTDAL.Del_AllDanhSachSaiSotThuoc(id);
        }

        public static Int32 GetTongLuotKham(DateTime from, DateTime to)
        {
            return SSTDAL.GetTongLuotKham(from, to);
        }
    }
}
