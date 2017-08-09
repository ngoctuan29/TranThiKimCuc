using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using ClinicModel;

namespace ClinicDAL
{
    public class Catalog_BHYTDAL
    {
        public static DataTable TableServiceGroup_BHYT()
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "select GroupID, STT, GroupName, Hide, Abbreviations,IDate from ServiceGroup_BHYT";
                return cn.ExecuteQuery(sql);
            }
            catch { return null; }
        }
        public static DataTable TableDMLoaiPT_TT()
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "select MaPT_TT, Ten, IDate, Hide from DMLoaiPT_TT";
                return cn.ExecuteQuery(sql);
            }
            catch { return null; }
        }
        public static DataTable TableService_BHYT()
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "select MaTuongDuong,Ma_TT50,Ten_TT50,PhanTuyen,MaPT_TT,Hide,Ma_TT37,Ten_TT37,SoQD,NgayKy,MaCKTT50,MaTT03_04,MaQD5084,STT,GhiChu,DonGia_010316,DonGia_010716 from Service_BHYT";
                return cn.ExecuteQuery(sql);
            }
            catch { return null; }
        }
        public static DataTable TableDMChuyenKhoa_BHYT()
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "select MaCK, STT, Ten, IDate, Hide from DMChuyenKhoa_BHYT";
                return cn.ExecuteQuery(sql);
            }
            catch { return null; }
        }
        public static List<Service_BHYTINF> TableCkTheoTD(string matd)
        {
            ConnectDB cn = new ConnectDB();
            List<Service_BHYTINF> list = new List<Service_BHYTINF>();
            try
            {
                string sql = string.Empty;
                sql = "select MaTuongDuong,Ma_TT50,Ten_TT50,PhanTuyen,MaPT_TT,Hide,Ma_TT37,Ten_TT37,SoQD,NgayKy,MaCKTT50,MaTT03_04,MaQD5084,STT,GhiChu from Service_BHYT where 1=1 ";
                if (matd != "")
                    sql += " and MaTuongDuong = '{0}'";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, matd), null);
                while (ireader.Read())
                {
                    Service_BHYTINF inf = new Service_BHYTINF();
                    inf.MaTuongDuong = ireader.GetValue(0).ToString();
                    inf.Ma_TT50 = ireader.GetValue(1).ToString();
                    inf.Ten_TT50 = ireader.GetValue(2).ToString();
                    inf.PhanTuyen = ireader.GetValue(3).ToString();
                    inf.MaPT_TT = ireader.GetValue(4).ToString();
                    inf.Hide = ireader.GetInt32(5);
                    inf.Ma_TT37 = ireader.GetValue(6).ToString();
                    inf.Ten_TT37 = ireader.GetValue(7).ToString();
                    inf.SoQD = ireader.GetValue(8).ToString();
                    inf.NgayKy = ireader.GetValue(9).ToString();
                    inf.MaCKTT50 = ireader.GetValue(10).ToString();
                    inf.MaTT03_04 = ireader.GetValue(11).ToString();
                    inf.MaQD5084 = ireader.GetValue(12).ToString();
                    inf.STT = ireader.GetInt32(13);
                    inf.Note = ireader.GetValue(14).ToString();
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { list = null; }
            return list;
        }
        public static DataTable TableDMThuoc_BHYT()
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "select STT,SO_DANG_KY,TEN_THUOC,MA_HOAT_CHAT_TT40,HOAT_CHAT_TT40,HOAT_CHAT_SODK,MA_DUONG_DUNG,DUONG_DUNG,HAM_LUONG,DONG_GOI,HANG_SX,NUOC_SX from Items_BHYT ORDER BY STT ";
                return cn.ExecuteQuery(sql);
            }
            catch { return null; }
        }
    }
}
