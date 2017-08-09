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
    public class ADRDAL
    {
        public static DataTable GetListDonVi(int id)
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
                    query = @" select Id,TenDonVi,MaSoBaoCaoCuaDonVi from ADR_DonViBaoCao";
                    param = null;
                }
                else
                {
                    query = @" select Id,TenDonVi,MaSoBaoCaoCuaDonVi from ADR_DonViBaoCao where Id = @Id";
                }
                tableResult = cn.CallProcedureTable(CommandType.Text, query, param);
            }
            catch (Exception) {
                tableResult = null; }
            return tableResult;
        }
        
        public static DataTable GetDanhSachPhieu(int idMaBaoCao)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                string query = string.Empty;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id", SqlDbType.Int);
                param[0].Value = idMaBaoCao;
                if (idMaBaoCao <= 0)
                {
                    query = @" Select a.Id, a.MasoBaoCao, a.NgayBaoCao, a.NoiBaoCao, a.NguoiBaoCao, a.NgheNghiep, a.SoDienThoai, a.DangBaoCao 
                             from ADR_PhieuBaoCao a";
                    param = null;
                }
                else
                {
                    query = @" Select a.Id, a.MasoBaoCao, a.NgayBaoCao, a.NoiBaoCao, a.NguoiBaoCao, a.NgheNghiep, a.SoDienThoai, a.DangBaoCao 
                               from ADR_PhieuBaoCao a
                               where a.Id=@Id";
                }
                dtResult = cn.CallProcedureTable(CommandType.Text, query, param);
            }
            catch (Exception ex) { ex.ToString(); dtResult = null; }
            return dtResult;
        }
        public static Int16 CheckExistId(string id)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = @"select Id from ADR_PhieuBaoCao where MaSoBaoCao = @MaSoBaoCao";
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
        public static Int16 InsUpd_ADR(ADR_PhieuBaoCaoInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@Id", SqlDbType.Int);
                param[0].Value = info.Id;
                param[1] = new SqlParameter("@NoiBaoCao", SqlDbType.NVarChar);
                param[1].Value = info.NoiBaoCao;
                param[2] = new SqlParameter("@MaSoBaoCao", SqlDbType.NVarChar);
                param[2].Value = info.MasoBaoCao;
                param[3] = new SqlParameter("@NgayBaoCao", SqlDbType.DateTime);
                param[3].Value = info.NgayBaoCao;
                param[4] = new SqlParameter("@NguoiBaoCao", SqlDbType.NVarChar);
                param[4].Value = info.NguoiBaoCao;
                param[5] = new SqlParameter("@NgheNghiep", SqlDbType.NVarChar);
                param[5].Value = info.NgheNghiep;
                param[6] = new SqlParameter("@SoDienThoai", SqlDbType.NVarChar);
                param[6].Value = info.SoDienThoai;
                param[7] = new SqlParameter("@DangBaoCao", SqlDbType.NVarChar);
                param[7].Value = info.DangBaoCao;
                cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proIU_PhieuADR", param);
                return 1;
            }
            catch (Exception ex) { return -1; throw new Exception(ex.Message); }
        }
        public static Int16 Del_ADR(int id)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = @" delete ADR_PhieuBaoCao where Id = @Id";
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
        public static DataTable GetListBenhNhan(int idPhieu)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = @" select Id, HoTen, NgaySinh, GioiTinh, CanNang, NgayXuatHienPhanUng, MoTaBieuHien from ADR_BenhNhan where IdPhieuBaoCao = @Id";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id", SqlDbType.Int);
                param[0].Value = idPhieu;
                tableResult = cn.CallProcedureTable(CommandType.Text, query, param);
            }
            catch (Exception) {
                tableResult = null; }
            return tableResult;
        }
        public static Int16 InsUpd_BenhNhan(ADR_BenhNhanInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@Id", SqlDbType.Int);
                param[0].Value = info.Id;
                param[1] = new SqlParameter("@IdPhieuBaoCao", SqlDbType.Int);
                param[1].Value = info.IdPhieuBaoCao;
                param[2] = new SqlParameter("@HoTen", SqlDbType.NVarChar);
                param[2].Value = info.HoTen;
                param[3] = new SqlParameter("@NgaySinh", SqlDbType.NChar);
                param[3].Value = info.NgaySinh;
                param[4] = new SqlParameter("@GioiTinh", SqlDbType.NVarChar);
                param[4].Value = info.GioiTinh;
                param[5] = new SqlParameter("@CanNang", SqlDbType.NVarChar);
                param[5].Value = info.CanNang;
                param[6] = new SqlParameter("@NgayXuatHienPhanUng", SqlDbType.NChar);
                param[6].Value = info.NgayXuatHienPhanUng;
                param[7] = new SqlParameter("@MoTaBieuHien", SqlDbType.NVarChar);
                param[7].Value = info.MoTaBieuHien;
                cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proIU_BenhNhanADR", param);
                return 1;
            }
            catch (Exception ex) { return -1; throw new Exception(ex.Message); }
        }
        public static void InsMulti_BenhNhan(List<ADR_BenhNhanInf> lstModel)
        {
            ConnectDB cn = new ConnectDB();
            string insertQuery = @"exec proIU_BenhNhanADR @Id, @IdPhieuBaoCao,@HoTen,@NgaySinh ,@GioiTinh ,@CanNang ,@NgayXuatHienPhanUng, @MoTaBieuHien";

            using (SqlCommand command = new SqlCommand(insertQuery, cn.sqlConnection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int);
                command.Parameters.Add("@IdPhieuBaoCao", SqlDbType.Int);
                command.Parameters.Add("@HoTen", SqlDbType.NVarChar);
                command.Parameters.Add("@NgaySinh", SqlDbType.NChar);
                command.Parameters.Add("@GioiTinh", SqlDbType.NVarChar);
                command.Parameters.Add("@CanNang", SqlDbType.NVarChar);
                command.Parameters.Add("@NgayXuatHienPhanUng", SqlDbType.NChar);
                command.Parameters.Add("@MoTaBieuHien", SqlDbType.NVarChar);
                cn.sqlConnection.Open();

                foreach (var item in lstModel)
                {
                    command.Parameters["@Id"].Value = item.Id;
                    command.Parameters["@IdPhieuBaoCao"].Value = item.IdPhieuBaoCao;
                    command.Parameters["@HoTen"].Value = item.HoTen;
                    command.Parameters["@NgaySinh"].Value = item.NgaySinh;
                    command.Parameters["@GioiTinh"].Value = item.GioiTinh;
                    command.Parameters["@CanNang"].Value = item.CanNang;
                    command.Parameters["@NgayXuatHienPhanUng"].Value = item.NgayXuatHienPhanUng;
                    command.Parameters["@MoTaBieuHien"].Value = item.MoTaBieuHien;
                    command.ExecuteNonQuery();
                }
                cn.sqlConnection.Close();
            }
        }
        public static DataTable GetListThuoc(int idBN)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = @" SELECT a.Id
                                ,ThuocNghiADR,TenThuoc,DangBaoChe,NhaSanXuat,SoLo,LieuDung1Lan,SoLanDung1Ngay
                                ,DuongDung,NgayDT_BatDau,NgayDT_KetThuc,LyDoDungThuoc,IdBenhNhan,CaiThienKhiNgung_Co
                                ,CaiThienKhiNgung_Khong,CaiThienKhiNgung_KoNgung,CaiThienKhiNgung_KoCoThongTin,XuatHienPhanUngLai_Co
                                ,XuatHienPhanUngLai_Khong,XuatHienPhanUngLai_KoTaiSuDung,XuatHienPhanUngLai_KoCoThongTin,b.RowID  
                                FROM ADR_ThongTinThuoc a left join Catalog_ATC b on b.RowID = a.MaPhanLoaiATC 
                                WHERE a.IdBenhNhan = @IdBenhNhan";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@IdBenhNhan", SqlDbType.Int);
                param[0].Value = idBN;
                tableResult = cn.CallProcedureTable(CommandType.Text, query, param);
            }
            catch (Exception ex) { ex.ToString(); tableResult = null; }
            return tableResult;
        }
        public static Int16 Del_DanhSachBenhNhan(int id)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = @"delete ADR_BenhNhan where Id = @Id; delete ADR_ThongTinThuoc where IdBenhNhan = @Id";
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
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, "proADR_SoLuongBaoCaoHangThang", param);
                return tableResult;
            }
            catch { return null; }
        }
        public static DataTable Report_Tuoi(DateTime from, DateTime to)
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
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, "proADR_ThongTinBN_Tuoi_1", param);
                return tableResult;
            }
            catch { return null; }
        }
        public static DataTable Report_GioiTInh(DateTime from, DateTime to)
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
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, "proADR_ThongTinBN_GioiTinh", param);
                return tableResult;
            }
            catch { return null; }
        }
        public static DataTable Report_DuongDung(DateTime from, DateTime to)
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
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, "proADR_ThongTinBN_DuongDung", param);
                return tableResult;
            }
            catch { return null; }
        }

        public static DataTable Report_ATC(DateTime from, DateTime to)
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
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, "proADR_ThongTinBN_NhomATC", param);
                return tableResult;
            }
            catch (Exception){ return null; }
        }

        public static DataTable Report_ThuocNghiNgo(DateTime from, DateTime to)
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
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, "proADR_ThongTinBN_ThuocNghiNgoADRNhieuNhat", param);
                return tableResult;
            }
            catch { return null; }
        }

        public static DataTable Get_Catalog_ATC()
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = @"select RowID, ATCCode, ATCName from Catalog_ATC";
                return tableResult = cn.CallProcedureTable(CommandType.Text, query, null);
            }
            catch { return null; }
        }

        public static Int16 InsThuoc(ADR_ThongTinThuoc thuoc)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = @" INSERT INTO ADR_ThongTinThuoc(ThuocNghiADR,TenThuoc,DangBaoChe,NhaSanXuat,SoLo,LieuDung1Lan,SoLanDung1Ngay,DuongDung,NgayDT_BatDau,NgayDT_KetThuc,LyDoDungThuoc,IdBenhNhan,CaiThienKhiNgung_Co
                                ,CaiThienKhiNgung_Khong,CaiThienKhiNgung_KoNgung,CaiThienKhiNgung_KoCoThongTin,XuatHienPhanUngLai_Co,XuatHienPhanUngLai_Khong,XuatHienPhanUngLai_KoTaiSuDung,XuatHienPhanUngLai_KoCoThongTin,MaPhanLoaiATC)
                                     VALUES(@ThuocNghiADR,@TenThuoc,@DangBaoChe,@NhaSanXuat,@SoLo,@LieuDung1Lan,@SoLanDung1Ngay,@DuongDung,@NgayDT_BatDau,@NgayDT_KetThuc,@LyDoDungThuoc,@IdBenhNhan,@CaiThienKhiNgung_Co
                                ,@CaiThienKhiNgung_Khong,@CaiThienKhiNgung_KoNgung,@CaiThienKhiNgung_KoCoThongTin,@XuatHienPhanUngLai_Co,@XuatHienPhanUngLai_Khong,@XuatHienPhanUngLai_KoTaiSuDung,@XuatHienPhanUngLai_KoCoThongTin,@MaPhanLoaiATC)";
                SqlParameter[] param = new SqlParameter[21];
                param[0] = new SqlParameter("@ThuocNghiADR", SqlDbType.Int);
                param[0].Value = thuoc.ThuocNghiADR;
                param[1] = new SqlParameter("@TenThuoc", SqlDbType.NVarChar);
                param[1].Value = thuoc.TenThuoc;
                param[2] = new SqlParameter("@DangBaoChe", SqlDbType.NVarChar);
                param[2].Value = thuoc.DangBaoChe;
                param[3] = new SqlParameter("@NhaSanXuat", SqlDbType.NVarChar);
                param[3].Value = thuoc.NhaSanXuat;
                param[4] = new SqlParameter("@SoLo", SqlDbType.NVarChar);
                param[4].Value = thuoc.SoLo;
                param[5] = new SqlParameter("@LieuDung1Lan", SqlDbType.NVarChar);
                param[5].Value = thuoc.LieuDung1Lan;
                param[6] = new SqlParameter("@SoLanDung1Ngay", SqlDbType.NVarChar);
                param[6].Value = thuoc.SoLanDung1Ngay;
                param[7] = new SqlParameter("@DuongDung", SqlDbType.NVarChar);
                param[7].Value = thuoc.DuongDung;
                param[8] = new SqlParameter("@NgayDT_BatDau", SqlDbType.NChar);
                param[8].Value = thuoc.NgayDT_BatDau;
                param[9] = new SqlParameter("@NgayDT_KetThuc", SqlDbType.NChar);
                param[9].Value = thuoc.NgayDT_KetThuc;
                param[10] = new SqlParameter("@LyDoDungThuoc", SqlDbType.NVarChar);
                param[10].Value = thuoc.LyDoDungThuoc;
                param[11] = new SqlParameter("@IdBenhNhan", SqlDbType.Int);
                param[11].Value = thuoc.IdBenhNhan;
                param[12] = new SqlParameter("@CaiThienKhiNgung_Co", SqlDbType.Bit);
                param[12].Value = thuoc.CaiThienKhiNgung_Co;
                param[13] = new SqlParameter("@CaiThienKhiNgung_Khong", SqlDbType.Bit);
                param[13].Value = thuoc.CaiThienKhiNgung_Khong;
                param[14] = new SqlParameter("@CaiThienKhiNgung_KoNgung", SqlDbType.Bit);
                param[14].Value = thuoc.CaiThienKhiNgung_KoNgung;
                param[15] = new SqlParameter("@CaiThienKhiNgung_KoCoThongTin", SqlDbType.Bit);
                param[15].Value = thuoc.CaiThienKhiNgung_KoCoThongTin;
                param[16] = new SqlParameter("@XuatHienPhanUngLai_Co", SqlDbType.Bit);
                param[16].Value = thuoc.XuatHienPhanUngLai_Co;
                param[17] = new SqlParameter("@XuatHienPhanUngLai_Khong", SqlDbType.Bit);
                param[17].Value = thuoc.XuatHienPhanUngLai_Khong;
                param[18] = new SqlParameter("@XuatHienPhanUngLai_KoTaiSuDung", SqlDbType.Bit);
                param[18].Value = thuoc.XuatHienPhanUngLai_KoTaiSuDung;
                param[19] = new SqlParameter("@XuatHienPhanUngLai_KoCoThongTin", SqlDbType.Bit);
                param[19].Value = thuoc.XuatHienPhanUngLai_KoCoThongTin;
                param[20] = new SqlParameter("@MaPhanLoaiATC", SqlDbType.Int);
                param[20].Value = thuoc.MaPhanLoaiATC;
                cn.ExecuteNonQuery(CommandType.Text, query, param);
                return 1;
            }
            catch (Exception ex) { ex.ToString(); return -1; }
        }

        public static Int16 UpdThuoc(ADR_ThongTinThuoc thuoc)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = @" UPDATE dbo.ADR_ThongTinThuoc
                                   SET ThuocNghiADR = @ThuocNghiADR
                                      ,TenThuoc = @TenThuoc
                                      ,DangBaoChe = @DangBaoChe
                                      ,NhaSanXuat = @NhaSanXuat
                                      ,SoLo = @SoLo
                                      ,LieuDung1Lan = @LieuDung1Lan
                                      ,SoLanDung1Ngay = @SoLanDung1Ngay
                                      ,DuongDung = @DuongDung
                                      ,NgayDT_BatDau = @NgayDT_BatDau
                                      ,NgayDT_KetThuc = @NgayDT_KetThuc
                                      ,LyDoDungThuoc = @LyDoDungThuoc
                                      ,MaPhanLoaiATC = @MaPhanLoaiATC
                                 WHERE Id = @Id";
                SqlParameter[] param = new SqlParameter[13];
                param[0] = new SqlParameter("@ThuocNghiADR", SqlDbType.Int);
                param[0].Value = thuoc.ThuocNghiADR;
                param[1] = new SqlParameter("@TenThuoc", SqlDbType.NVarChar);
                param[1].Value = thuoc.TenThuoc;
                param[2] = new SqlParameter("@DangBaoChe", SqlDbType.NVarChar);
                param[2].Value = thuoc.DangBaoChe;
                param[3] = new SqlParameter("@NhaSanXuat", SqlDbType.NVarChar);
                param[3].Value = thuoc.NhaSanXuat;
                param[4] = new SqlParameter("@SoLo", SqlDbType.NVarChar);
                param[4].Value = thuoc.SoLo;
                param[5] = new SqlParameter("@LieuDung1Lan", SqlDbType.NVarChar);
                param[5].Value = thuoc.LieuDung1Lan;
                param[6] = new SqlParameter("@SoLanDung1Ngay", SqlDbType.NVarChar);
                param[6].Value = thuoc.SoLanDung1Ngay;
                param[7] = new SqlParameter("@DuongDung", SqlDbType.NVarChar);
                param[7].Value = thuoc.DuongDung;
                param[8] = new SqlParameter("@NgayDT_BatDau", SqlDbType.NChar);
                param[8].Value = thuoc.NgayDT_BatDau;
                param[9] = new SqlParameter("@NgayDT_KetThuc", SqlDbType.NChar);
                param[9].Value = thuoc.NgayDT_KetThuc;
                param[10] = new SqlParameter("@LyDoDungThuoc", SqlDbType.NVarChar);
                param[10].Value = thuoc.LyDoDungThuoc;
                param[11] = new SqlParameter("@Id", SqlDbType.Int);
                param[11].Value = thuoc.Id;
                param[12] = new SqlParameter("@MaPhanLoaiATC", SqlDbType.Int);
                param[12].Value = thuoc.MaPhanLoaiATC;
                cn.ExecuteNonQuery(CommandType.Text, query, param);
                return 1;
            }
            catch (Exception ex) { ex.ToString(); return -1; }
        }

        public static Int16 UpdThuoc_Ngung(ADR_ThongTinThuoc thuoc)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = @" UPDATE dbo.ADR_ThongTinThuoc
                                SET    CaiThienKhiNgung_Co = @CaiThienKhiNgung_Co
                                      ,CaiThienKhiNgung_Khong = @CaiThienKhiNgung_Khong
                                      ,CaiThienKhiNgung_KoNgung = @CaiThienKhiNgung_KoNgung
                                      ,CaiThienKhiNgung_KoCoThongTin = @CaiThienKhiNgung_KoCoThongTin
                                 WHERE  Id = @Id";
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@CaiThienKhiNgung_Co", SqlDbType.Bit);
                param[0].Value = thuoc.CaiThienKhiNgung_Co;
                param[1] = new SqlParameter("@CaiThienKhiNgung_Khong", SqlDbType.Bit);
                param[1].Value = thuoc.CaiThienKhiNgung_Khong;
                param[2] = new SqlParameter("@CaiThienKhiNgung_KoNgung", SqlDbType.Bit);
                param[2].Value = thuoc.CaiThienKhiNgung_KoNgung;
                param[3] = new SqlParameter("@CaiThienKhiNgung_KoCoThongTin", SqlDbType.Bit);
                param[3].Value = thuoc.CaiThienKhiNgung_KoCoThongTin;
                param[4] = new SqlParameter("@Id", SqlDbType.Int);
                param[4].Value = thuoc.Id;
                cn.ExecuteNonQuery(CommandType.Text, query, param);
                return 1;
            }
            catch (Exception ex) { ex.ToString(); return -1; }
        }

        public static Int16 UpdThuoc_XuatHien(ADR_ThongTinThuoc thuoc)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = @" UPDATE dbo.ADR_ThongTinThuoc
                                  SET    XuatHienPhanUngLai_Co = @XuatHienPhanUngLai_Co
                                         ,XuatHienPhanUngLai_Khong = @XuatHienPhanUngLai_Khong
                                        ,XuatHienPhanUngLai_KoTaiSuDung = @XuatHienPhanUngLai_KoTaiSuDung
                                        ,XuatHienPhanUngLai_KoCoThongTin = @XuatHienPhanUngLai_KoCoThongTin
                                 WHERE  Id = @Id";
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@XuatHienPhanUngLai_Co", SqlDbType.Bit);
                param[0].Value = thuoc.XuatHienPhanUngLai_Co;
                param[1] = new SqlParameter("@XuatHienPhanUngLai_Khong", SqlDbType.Bit);
                param[1].Value = thuoc.XuatHienPhanUngLai_Khong;
                param[2] = new SqlParameter("@XuatHienPhanUngLai_KoTaiSuDung", SqlDbType.Bit);
                param[2].Value = thuoc.XuatHienPhanUngLai_KoTaiSuDung;
                param[3] = new SqlParameter("@XuatHienPhanUngLai_KoCoThongTin", SqlDbType.Bit);
                param[3].Value = thuoc.XuatHienPhanUngLai_KoCoThongTin;
                param[4] = new SqlParameter("@Id", SqlDbType.Int);
                param[4].Value = thuoc.Id;
                cn.ExecuteNonQuery(CommandType.Text, query, param);
                return 1;
            }
            catch (Exception ex) { ex.ToString(); return -1; }
        }

        public static Int16 DelThuoc(int id)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = @" DELETE FROM ADR_ThongTinThuoc
                                  WHERE  Id = @Id";
                SqlParameter[] param = new SqlParameter[5];
                param[4] = new SqlParameter("@Id", SqlDbType.Int);
                param[4].Value = id;
                cn.ExecuteNonQuery(CommandType.Text, query, param);
                return 1;
            }
            catch (Exception ex) { ex.ToString(); return -1; }
        }

        public static DataTable getBenhNhan(int idBn)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string query = @" select *
								from ADR_BenhNhan a 
                                inner join ADR_PhieuBaoCao b on a.IdPhieuBaoCao = b.Id
								where a.Id = @idBn";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@idBn", SqlDbType.BigInt);
                param[0].Value = idBn;
                dt = cn.CallProcedureTable(CommandType.Text, query, param);
            }
            catch (Exception ex) { ex.ToString(); dt = null; }
            return dt;
        }

        public static int Update_BenhNhan(ADR_BenhNhanInf info)
        {
            ConnectDB cn = new ConnectDB();
            string query = "";
            int i = -1;
            SqlParameter[] param = new SqlParameter[24];
            try
            {
                query = @" update ADR_BenhNhan
						set HoTen = @HoTen, NgaySinh = @NgaySinh, CanNang = @CanNang, NgayXuatHienPhanUng = @NgayXuatHienPhanUng, PhanUngXuatHienSau = @PhanUngXuatHienSau,
						MoTaBieuHien = @MoTaBieuHien, CachXuTri = @CachXuTri, TienSu = @TienSu, CacXetNghiemLienQuan = @CacXetNghiemLienQuan, GioiTinh = @GioiTinh, MucDo_TuVong = @MucDo_TuVong,
						MucDo_DeDoaTinhMang = @MucDo_DeDoaTinhMang, MucDo_NhapVien = @MucDo_NhapVien, MucDo_TanTat = @MucDo_TanTat, MucDo_DiTat = @MucDo_DiTat, MucDo_KhongNghiemTrong = @MucDo_KhongNghiemTrong,
						KetQua_TuVongDoADR = @KetQua_TuVongDoADR, KetQua_TuVongKoLienQuan = @KetQua_TuVongKoLienQuan, KetQua_ChuaPhucHoi = @KetQua_ChuaPhucHoi, KetQua_DangHoiPhuc = @KetQua_DangHoiPhuc,
						KetQua_HoiPhucCoDiChung = @KetQua_HoiPhucCoDiChung, KetQua_HoiPhucKoDiChung = @KetQua_HoiPhucKoDiChung, KetQua_KoRo = @KetQua_KoRo
						where Id = @Id";
                param[++i] = new SqlParameter("@HoTen", SqlDbType.NVarChar);
                param[i].Value = info.HoTen;
                param[++i] = new SqlParameter("@NgaySinh", SqlDbType.NChar);
                param[i].Value = info.NgaySinh;
                param[++i] = new SqlParameter("@CanNang", SqlDbType.NVarChar);
                param[i].Value = info.CanNang;
                param[++i] = new SqlParameter("@NgayXuatHienPhanUng", SqlDbType.NChar);
                param[i].Value = info.NgayXuatHienPhanUng;
                param[++i] = new SqlParameter("@PhanUngXuatHienSau", SqlDbType.NVarChar);
                param[i].Value = info.PhanUngXuatHienSau;
                param[++i] = new SqlParameter("@MoTaBieuHien", SqlDbType.NVarChar);
                param[i].Value = info.MoTaBieuHien;
                param[++i] = new SqlParameter("@CachXuTri", SqlDbType.NVarChar);
                param[i].Value = info.CachXuTri;
                param[++i] = new SqlParameter("@TienSu", SqlDbType.NVarChar);
                param[i].Value = info.TienSu;
                param[++i] = new SqlParameter("@CacXetNghiemLienQuan", SqlDbType.NVarChar);
                param[i].Value = info.CacXetNghiemLienQuan;
                param[++i] = new SqlParameter("@GioiTinh", SqlDbType.NVarChar);
                param[i].Value = info.GioiTinh;
                param[++i] = new SqlParameter("@MucDo_TuVong", SqlDbType.Bit);
                param[i].Value = info.MucDo_TuVong;
                param[++i] = new SqlParameter("@MucDo_DeDoaTinhMang", SqlDbType.Bit);
                param[i].Value = info.MucDo_DeDoaTinhMang;
                param[++i] = new SqlParameter("@MucDo_NhapVien", SqlDbType.Bit);
                param[i].Value = info.MucDo_NhapVien;
                param[++i] = new SqlParameter("@MucDo_TanTat", SqlDbType.Bit);
                param[i].Value = info.MucDo_TanTat;
                param[++i] = new SqlParameter("@MucDo_DiTat", SqlDbType.Bit);
                param[i].Value = info.MucDo_DiTat;
                param[++i] = new SqlParameter("@MucDo_KhongNghiemTrong", SqlDbType.Bit);
                param[i].Value = info.MucDo_KhongNghiemTrong;
                param[++i] = new SqlParameter("@KetQua_TuVongDoADR", SqlDbType.Bit);
                param[i].Value = info.KetQua_TuVongDoADR;
                param[++i] = new SqlParameter("@KetQua_TuVongKoLienQuan", SqlDbType.Bit);
                param[i].Value = info.KetQua_TuVongKoLienQuan;
                param[++i] = new SqlParameter("@KetQua_ChuaPhucHoi", SqlDbType.Bit);
                param[i].Value = info.KetQua_ChuaPhucHoi;
                param[++i] = new SqlParameter("@KetQua_DangHoiPhuc", SqlDbType.Bit);
                param[i].Value = info.KetQua_DangHoiPhuc;
                param[++i] = new SqlParameter("@KetQua_HoiPhucCoDiChung", SqlDbType.Bit);
                param[i].Value = info.KetQua_HoiPhucCoDiChung;
                param[++i] = new SqlParameter("@KetQua_HoiPhucKoDiChung", SqlDbType.Bit);
                param[i].Value = info.KetQua_HoiPhucKoDiChung;
                param[++i] = new SqlParameter("@KetQua_KoRo", SqlDbType.Bit);
                param[i].Value = info.KetQua_KoRo;
                param[++i] = new SqlParameter("@Id", SqlDbType.BigInt);
                param[i].Value = info.Id;

                cn.ExecuteNonQuery(CommandType.Text, query, param);
            }
            catch (Exception ex) { return -1; throw new Exception(ex.Message); }
            return 1;
        }
    }
}
