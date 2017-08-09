using ClinicModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDAL
{
    public class SSTDAL
    {
        public static DataTable GetListSaiSotThuoc(int id)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = string.Empty;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id", SqlDbType.Int);
                param[0].Value = id;
                if (id == 0)
                {
                    query = @" select a.Id, a.MaSoBaoCao, a.NoiBaoCao, a.NgayNhapPhieu, a.Ghichu, a.TongLuotKham
                               from SaiSot_PhieuBaoCao a ";
                    param = null;
                }
                else
                {
                    query = @" select a.Id, a.MaSoBaoCao, a.NoiBaoCao, a.NgayNhapPhieu, a.Ghichu, a.TongLuotKham
                               from SaiSot_PhieuBaoCao a 
                               where a.Id = @Id";
                }
                tableResult = cn.CallProcedureTable(CommandType.Text, query, param);
            }
            catch (Exception ex) { ex.ToString(); tableResult = null; }
            return tableResult;
        }

        public static Int16 CheckExistId(string id)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = @"select Id from SaiSot_PhieuBaoCao where MaSoBaoCao = @MaSoBaoCao";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@MaSoBaoCao", SqlDbType.NVarChar);
                param[0].Value = id;
                DataTable result = cn.CallProcedureTable(CommandType.Text, query, param);
                if (result.Rows.Count > 0)
                    return 1;
                else
                    return 0;
            }
            catch { return -1; }
        }

        public static Int16 InsUpd_SaiSotThuoc(SaiSot_PhieuBaoCaoInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@Id", SqlDbType.Int);
                param[0].Value = info.Id;
                param[1] = new SqlParameter("@NoiBaoCao", SqlDbType.NVarChar);
                param[1].Value = info.NoiBaoCao;
                param[2] = new SqlParameter("@MaSoBaoCao", SqlDbType.NVarChar);
                param[2].Value = info.MaSoBaoCao;
                param[3] = new SqlParameter("@NgayNhapPhieu", SqlDbType.DateTime);
                param[3].Value = info.NgayNhapPhieu;
                param[4] = new SqlParameter("@Ghichu", SqlDbType.NVarChar);
                param[4].Value = info.Ghichu;
                param[5] = new SqlParameter("@TongLuotKham", SqlDbType.NVarChar);
                param[5].Value = info.TongLuotKham;
                cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proIU_PhieuSaiSot", param);
                return 1;
            }
            catch (Exception ex) { return -1; throw new Exception(ex.Message); }
        }

        public static Int16 Del_SaiSotThuoc(int id)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = @"delete SaiSot_PhieuBaoCao where Id = @Id";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id", SqlDbType.Int);
                param[0].Value = id;
                cn.CallProcedureTable(CommandType.Text, query, param);
                return 1;
            }
            catch
            {
                return -1;
            }
        }

        public static DataTable Report_SSTKhoaPhong(DateTime from, DateTime to)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@TuNgay", SqlDbType.Date);
                param[0].Value = from;
                param[1] = new SqlParameter("@DenNgay", SqlDbType.Date);
                param[1].Value = to;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, "proSaiSot_ThongTinBN_KhoaPhong", param);
                return tableResult;
            }
            catch { return null; }
        }

        public static DataTable Report_HinhThucSST(DateTime from, DateTime to)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@TuNgay", SqlDbType.Date);
                param[0].Value = from;
                param[1] = new SqlParameter("@DenNgay", SqlDbType.Date);
                param[1].Value = to;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, "proSaiSot_HinhThucSaiSot", param);
                return tableResult;
            }
            catch { return null; }
        }

        public static DataTable Report_PhanLoaiSST(DateTime from, DateTime to)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@TuNgay", SqlDbType.Date);
                param[0].Value = from;
                param[1] = new SqlParameter("@DenNgay", SqlDbType.Date);
                param[1].Value = to;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, "proSaiSot_PhanLoaiSaiSot", param);
                return tableResult;
            }
            catch { return null; }
        }

        public static DataTable GetListDetailSaiSotThuoc(int idPhieu)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = @" select a.Id, a.NgayBaoCao, a.NguoiBaoCao, a.ThoiGianXayRaSuCo, a.KhoaPhong_DiaDiemXayRa, a.MoTaSuCo, a.HauQuaXayRa, a.CachXuTriTucThoi, a.CapBaoCao, a.GiaiPhapKhacPhuc, a.TrachNhiem, a.DanhGiaLai, a.Ghichu, a.HinhThucSaiSot, a.PhanLoai
                               from SaiSot_DanhSach a
                               where a.IdPhieuBaoCao = @Id";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id", SqlDbType.Int);
                param[0].Value = idPhieu;
                tableResult = cn.CallProcedureTable(CommandType.Text, query, param);
            }
            catch (Exception ex) { ex.ToString(); tableResult = null; }
            return tableResult;
        }
        public static void InsMulti_DetailSaiSotThuoc(List<SaiSot_DanhSach> lstModel)
        {
            ConnectDB cn = new ConnectDB();
            string insertQuery = @"exec proIU_DanhSachPhieuSaiSot @Id, @IdPhieuBaoCao,@NgayBaoCao,@NguoiBaoCao,@ThoiGianXayRaSuCo,@KhoaPhong_DiaDiemXayRa,@MoTaSuCo,@HauQuaXayRa,@CachXuTriTucThoi
                                   ,@CapBaoCao,@GiaiPhapKhacPhuc,@TrachNhiem,@DanhGiaLai,@Ghichu,@HinhThucSaiSot,@PhanLoai";

            using (SqlCommand command = new SqlCommand(insertQuery, cn.sqlConnection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int);
                command.Parameters.Add("@IdPhieuBaoCao", SqlDbType.Int);
                command.Parameters.Add("@NgayBaoCao", SqlDbType.DateTime);
                command.Parameters.Add("@NguoiBaoCao", SqlDbType.NVarChar);
                command.Parameters.Add("@ThoiGianXayRaSuCo", SqlDbType.NVarChar);
                command.Parameters.Add("@KhoaPhong_DiaDiemXayRa", SqlDbType.NVarChar);
                command.Parameters.Add("@MoTaSuCo", SqlDbType.NVarChar);
                command.Parameters.Add("@HauQuaXayRa", SqlDbType.NVarChar);
                command.Parameters.Add("@CachXuTriTucThoi", SqlDbType.NVarChar);
                command.Parameters.Add("@CapBaoCao", SqlDbType.NVarChar);
                command.Parameters.Add("@GiaiPhapKhacPhuc", SqlDbType.NVarChar);
                command.Parameters.Add("@TrachNhiem", SqlDbType.NVarChar);
                command.Parameters.Add("@DanhGiaLai", SqlDbType.NVarChar);
                command.Parameters.Add("@Ghichu", SqlDbType.NVarChar);
                command.Parameters.Add("@HinhThucSaiSot", SqlDbType.NVarChar);
                command.Parameters.Add("@PhanLoai", SqlDbType.NVarChar);
                cn.sqlConnection.Open();

                foreach (var item in lstModel)
                {
                    command.Parameters["@Id"].Value = item.Id;
                    command.Parameters["@IdPhieuBaoCao"].Value = item.IdPhieuBaoCao;
                    command.Parameters["@NgayBaoCao"].Value = item.NgayBaoCao;
                    command.Parameters["@NguoiBaoCao"].Value = item.NguoiBaoCao;
                    command.Parameters["@ThoiGianXayRaSuCo"].Value = item.ThoiGianXayRaSuCo;
                    command.Parameters["@KhoaPhong_DiaDiemXayRa"].Value = item.KhoaPhong_DiaDiemXayRa;
                    command.Parameters["@MoTaSuCo"].Value = item.MoTaSuCo;
                    command.Parameters["@HauQuaXayRa"].Value = item.HauQuaXayRa;
                    command.Parameters["@CachXuTriTucThoi"].Value = item.CachXuTriTucThoi;
                    command.Parameters["@CapBaoCao"].Value = item.CapBaoCao;
                    command.Parameters["@GiaiPhapKhacPhuc"].Value = item.GiaiPhapKhacPhuc;
                    command.Parameters["@TrachNhiem"].Value = item.TrachNhiem;
                    command.Parameters["@DanhGiaLai"].Value = item.DanhGiaLai;
                    command.Parameters["@Ghichu"].Value = item.Ghichu;
                    command.Parameters["@HinhThucSaiSot"].Value = item.HinhThucSaiSot;
                    command.Parameters["@PhanLoai"].Value = item.PhanLoai;
                    command.ExecuteNonQuery();
                }

                cn.sqlConnection.Close();
            }
        }

        public static Int16 Del_AllDanhSachSaiSotThuoc(int id)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = @"delete SaiSot_DanhSach where IdPhieuBaoCao = @IdPhieuBaoCao";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@IdPhieuBaoCao", SqlDbType.Int);
                param[0].Value = id;
                cn.CallProcedureTable(CommandType.Text, query, param);
                return 1;
            }
            catch
            {
                return -1;
            }
        }

        public static Int32 GetTongLuotKham(DateTime from, DateTime to)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = @"select sum(CONVERT(int,SaiSot_PhieuBaoCao.TongLuotKham)) as TongLK  from SaiSot_PhieuBaoCao   
	                        where SaiSot_PhieuBaoCao.id in (
							select IdPhieuBaoCao from SaiSot_DanhSach SS 
							where convert(date,SS.NgayBaoCao,103)>=convert(date,@TuNgay, 103) and convert(date,SS.NgayBaoCao,103)<= convert(date,@DenNgay, 103)  and SaiSot_PhieuBaoCao.id=SS.IdPhieuBaoCao )";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@TuNgay", SqlDbType.DateTime);
                param[0].Value = from;
                param[1] = new SqlParameter("@DenNgay", SqlDbType.DateTime);
                param[1].Value = to;
                DataTable tbresult = cn.CallProcedureTable(CommandType.Text, query, param);
                
                return Convert.ToInt32(tbresult.Compute("Sum(TongLK)", "").ToString());
            }
            catch(Exception)
            {
                return -1;
            }
        }

    }
}
