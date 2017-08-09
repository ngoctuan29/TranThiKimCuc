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
    public class MedicalRecordOutputDAL
    {
        public static MedicalRecordOutputInf ObjRecordOutput(decimal rowid)
        {
            ConnectDB cn = new ConnectDB();
            MedicalRecordOutputInf inf = new MedicalRecordOutputInf();
            try
            {
                string sql = @"select a.RowID,a.PatientReceiveID,a.PatientCode,a.DepartmentCode,a.ShiftWork,a.EmployeeCode,a.MedicalRecordCode,a.ObjectCode,a.FullNameFamily,a.MobileFamily,a.HourIn,a.DateIn,a.DiagnosisIntroduce,a.ReasonIn,a.Pathological_Process,a.Anamnesis_Personal,a.Anamnesis_Family,a.KB_Totality,a.KB_Parts,a.Pulse,a.Temperature,a.BloodPressure,a.BloodPressure1,a.Weight_,a.Hight,a.Breath,a.CLS_Brief,a.Drug_Brief,a.ICD10_Out,a.Treatment_DateFrom,a.Treatment_DateTo,a.BenhAn_DienBienLamSang,a.BenhAn_TomTatXetNghiem,a.BenhAn_BenhChinh,a.BenhAn_BenhKemTheo,a.BenhAn_BenhKemTheoTen,a.BenhAn_PPDieuTri,a.BenhAn_TTRaVien,a.BenhAn_HuongDieuTri,a.BenhAn_HSXQuang,a.BenhAn_HSCTScanner,a.BenhAn_HSSieuAm,a.BenhAn_HSXetNghiem,a.BenhAn_HSKhac,a.BenhAn_NguoiGiaoHS,a.BenhAn_NguoiNhanHS,a.EmployeeDoctorCode,a.DateWorking,a.SoLuuTru,a.Cancel,a.isYTe,a.isTuDen,a.Initial_DiagnosisName,a.ICD10_OutName,a.BenhAn_BenhChinhTen,a.Workplace,b.Serial01,b.Serial02,b.Serial03,b.Serial04,b.Serial05,b.Serial06,convert(char(10),EndDate,103) EndDate_BHYT from MedicalRecordOutput a left join BHYT b on a.PatientReceiveID=b.PatientReceiveID and a.PatientCode=b.PatientCode and b.Hide=0 where a.RowID=@RowID ";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = rowid;
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, param);
                while (ireader.Read())
                {
                    inf.RowID = ireader.GetDecimal(0);
                    inf.PatientReceiveID = ireader.GetDecimal(1);
                    inf.PatientCode = ireader.GetValue(2).ToString();
                    inf.DepartmentCode = ireader.GetValue(3).ToString();
                    inf.ShiftWork = ireader.GetValue(4).ToString();
                    inf.EmployeeCode = ireader.GetValue(5).ToString();
                    inf.MedicalRecordCode = ireader.GetValue(6).ToString();
                    inf.ObjectCode = ireader.GetInt32(7);
                    inf.FullNameFamily = ireader.GetValue(8).ToString();
                    inf.MobileFamily = ireader.GetValue(9).ToString();
                    inf.HourIn = ireader.GetValue(10).ToString();
                    inf.DateIn = ireader.GetValue(11).ToString();
                    inf.DiagnosisIntroduce = ireader.GetValue(12).ToString();
                    inf.ReasonIn = ireader.GetValue(13).ToString();
                    inf.Pathological_Process = ireader.GetValue(14).ToString();
                    inf.Anamnesis_Personal = ireader.GetValue(15).ToString();
                    inf.Anamnesis_Family = ireader.GetValue(16).ToString();
                    inf.KB_Totality = ireader.GetValue(17).ToString();
                    inf.KB_Parts = ireader.GetValue(18).ToString();
                    inf.Pulse = ireader.GetValue(19).ToString();
                    inf.Temperature = ireader.GetValue(20).ToString();
                    inf.BloodPressure = ireader.GetValue(21).ToString();
                    inf.BloodPressure1 = ireader.GetValue(22).ToString();
                    inf.Weight_ = ireader.GetValue(23).ToString();
                    inf.Hight = ireader.GetValue(24).ToString();
                    inf.Breath = ireader.GetValue(25).ToString();
                    inf.CLS_Brief = ireader.GetValue(26).ToString();
                    inf.Drug_Brief = ireader.GetValue(27).ToString();
                    inf.ICD10_Out = Convert.ToInt32(ireader.GetValue(28).ToString());
                    inf.Treatment_DateFrom = ireader.GetValue(29).ToString();
                    inf.Treatment_DateTo = ireader.GetValue(30).ToString();
                    inf.BenhAn_DienBienLamSang = ireader.GetValue(31).ToString();
                    inf.BenhAn_TomTatXetNghiem = ireader.GetValue(32).ToString();
                    inf.BenhAn_BenhChinh = Convert.ToInt32(ireader.GetValue(33).ToString());
                    inf.BenhAn_BenhKemTheo = ireader.GetValue(34).ToString();
                    inf.BenhAn_BenhKemTheoTen = ireader.GetValue(35).ToString();
                    inf.BenhAn_PPDieuTri = ireader.GetValue(36).ToString();
                    inf.BenhAn_TTRaVien = ireader.GetValue(37).ToString();
                    inf.BenhAn_HuongDieuTri = ireader.GetValue(38).ToString();
                    inf.BenhAn_HSXQuang = ireader.GetValue(39).ToString();
                    inf.BenhAn_HSCTScanner = ireader.GetValue(40).ToString();
                    inf.BenhAn_HSSieuAm = ireader.GetValue(41).ToString();
                    inf.BenhAn_HSXetNghiem = ireader.GetValue(42).ToString();
                    inf.BenhAn_HSKhac = ireader.GetValue(43).ToString();
                    inf.BenhAn_NguoiGiaoHS = ireader.GetValue(44).ToString();
                    inf.BenhAn_NguoiNhanHS = ireader.GetValue(45).ToString();
                    inf.EmployeeDoctorCode = ireader.GetValue(46).ToString();
                    inf.DateWorking = ireader.GetDateTime(47);
                    inf.SoLuuTru = ireader.GetInt32(48);
                    inf.Cancel = ireader.GetValue(49).ToString() == "true" ? true : false;
                    inf.isYTe = ireader.GetValue(50).ToString() == "true" ? true : false;
                    inf.isTuDen = ireader.GetValue(51).ToString() == "true" ? true : false;
                    inf.Initial_DiagnosisName = ireader.GetValue(52).ToString();
                    inf.ICD10_OutName = ireader.GetValue(53).ToString();
                    inf.BenhAn_BenhChinhTen = ireader.GetValue(54).ToString();
                    inf.Workplace = ireader.GetValue(55).ToString();
                    inf.Serial01 = ireader.GetValue(56).ToString();
                    inf.Serial02 = ireader.GetValue(57).ToString();
                    inf.Serial03 = ireader.GetValue(58).ToString();
                    inf.Serial04 = ireader.GetValue(59).ToString();
                    inf.Serial05 = ireader.GetValue(60).ToString();
                    inf.Serial06 = ireader.GetValue(61).ToString();
                    inf.EndDate_BHYT = ireader.GetValue(62).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { inf = null; }
            return inf;
        }

        public static MedicalRecordOutputInf ObjRecordOutputForReceiveID(decimal patientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            MedicalRecordOutputInf inf = new MedicalRecordOutputInf();
            try
            {
                string sql = @"select a.RowID,a.PatientReceiveID,a.PatientCode,a.DepartmentCode,a.ShiftWork,a.EmployeeCode,a.MedicalRecordCode,a.ObjectCode,a.FullNameFamily,a.MobileFamily,a.HourIn,a.DateIn,a.DiagnosisIntroduce,a.ReasonIn,a.Pathological_Process,a.Anamnesis_Personal,a.Anamnesis_Family,a.KB_Totality,a.KB_Parts,a.Pulse,a.Temperature,a.BloodPressure,a.BloodPressure1,a.Weight_,a.Hight,a.Breath,a.CLS_Brief,a.Drug_Brief,a.ICD10_Out,a.Treatment_DateFrom,a.Treatment_DateTo,a.BenhAn_DienBienLamSang,a.BenhAn_TomTatXetNghiem,a.BenhAn_BenhChinh,a.BenhAn_BenhKemTheo,a.BenhAn_BenhKemTheoTen,a.BenhAn_PPDieuTri,a.BenhAn_TTRaVien,a.BenhAn_HuongDieuTri,a.BenhAn_HSXQuang,a.BenhAn_HSCTScanner,a.BenhAn_HSSieuAm,a.BenhAn_HSXetNghiem,a.BenhAn_HSKhac,a.BenhAn_NguoiGiaoHS,a.BenhAn_NguoiNhanHS,a.EmployeeDoctorCode,a.DateWorking,a.SoLuuTru,a.Cancel,a.isYTe,a.isTuDen,a.Initial_DiagnosisName,a.ICD10_OutName,a.BenhAn_BenhChinhTen,a.Workplace,b.Serial01,b.Serial02,b.Serial03,b.Serial04,b.Serial05,b.Serial06,convert(char(10),EndDate,103) EndDate_BHYT from MedicalRecordOutput a left join BHYT b on a.PatientReceiveID=b.PatientReceiveID and a.PatientCode=b.PatientCode and b.Hide=0 where a.PatientReceiveID=@PatientReceiveID and a.cancel=0 ";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = patientReceiveID;
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, param);
                while (ireader.Read())
                {
                    inf.RowID = ireader.GetDecimal(0);
                    inf.PatientReceiveID = ireader.GetDecimal(1);
                    inf.PatientCode = ireader.GetValue(2).ToString();
                    inf.DepartmentCode = ireader.GetValue(3).ToString();
                    inf.ShiftWork = ireader.GetValue(4).ToString();
                    inf.EmployeeCode = ireader.GetValue(5).ToString();
                    inf.MedicalRecordCode = ireader.GetValue(6).ToString();
                    inf.ObjectCode = ireader.GetInt32(7);
                    inf.FullNameFamily = ireader.GetValue(8).ToString();
                    inf.MobileFamily = ireader.GetValue(9).ToString();
                    inf.HourIn = ireader.GetValue(10).ToString();
                    inf.DateIn = ireader.GetValue(11).ToString();
                    inf.DiagnosisIntroduce = ireader.GetValue(12).ToString();
                    inf.ReasonIn = ireader.GetValue(13).ToString();
                    inf.Pathological_Process = ireader.GetValue(14).ToString();
                    inf.Anamnesis_Personal = ireader.GetValue(15).ToString();
                    inf.Anamnesis_Family = ireader.GetValue(16).ToString();
                    inf.KB_Totality = ireader.GetValue(17).ToString();
                    inf.KB_Parts = ireader.GetValue(18).ToString();
                    inf.Pulse = ireader.GetValue(19).ToString();
                    inf.Temperature = ireader.GetValue(20).ToString();
                    inf.BloodPressure = ireader.GetValue(21).ToString();
                    inf.BloodPressure1 = ireader.GetValue(22).ToString();
                    inf.Weight_ = ireader.GetValue(23).ToString();
                    inf.Hight = ireader.GetValue(24).ToString();
                    inf.Breath = ireader.GetValue(25).ToString();
                    inf.CLS_Brief = ireader.GetValue(26).ToString();
                    inf.Drug_Brief = ireader.GetValue(27).ToString();
                    inf.ICD10_Out = Convert.ToInt32(ireader.GetValue(28).ToString());
                    inf.Treatment_DateFrom = ireader.GetValue(29).ToString();
                    inf.Treatment_DateTo = ireader.GetValue(30).ToString();
                    inf.BenhAn_DienBienLamSang = ireader.GetValue(31).ToString();
                    inf.BenhAn_TomTatXetNghiem = ireader.GetValue(32).ToString();
                    inf.BenhAn_BenhChinh = Convert.ToInt32(ireader.GetValue(33).ToString());
                    inf.BenhAn_BenhKemTheo = ireader.GetValue(34).ToString();
                    inf.BenhAn_BenhKemTheoTen = ireader.GetValue(35).ToString();
                    inf.BenhAn_PPDieuTri = ireader.GetValue(36).ToString();
                    inf.BenhAn_TTRaVien = ireader.GetValue(37).ToString();
                    inf.BenhAn_HuongDieuTri = ireader.GetValue(38).ToString();
                    inf.BenhAn_HSXQuang = ireader.GetValue(39).ToString();
                    inf.BenhAn_HSCTScanner = ireader.GetValue(40).ToString();
                    inf.BenhAn_HSSieuAm = ireader.GetValue(41).ToString();
                    inf.BenhAn_HSXetNghiem = ireader.GetValue(42).ToString();
                    inf.BenhAn_HSKhac = ireader.GetValue(43).ToString();
                    inf.BenhAn_NguoiGiaoHS = ireader.GetValue(44).ToString();
                    inf.BenhAn_NguoiNhanHS = ireader.GetValue(45).ToString();
                    inf.EmployeeDoctorCode = ireader.GetValue(46).ToString();
                    inf.DateWorking = ireader.GetDateTime(47);
                    inf.SoLuuTru = ireader.GetInt32(48);
                    inf.Cancel = ireader.GetValue(49).ToString() == "True" ? true : false;
                    inf.isYTe = ireader.GetValue(50).ToString() == "True" ? true : false;
                    inf.isTuDen = ireader.GetValue(51).ToString() == "True" ? true : false;
                    inf.Initial_DiagnosisName = ireader.GetValue(52).ToString();
                    inf.ICD10_OutName = ireader.GetValue(53).ToString();
                    inf.BenhAn_BenhChinhTen = ireader.GetValue(54).ToString();
                    inf.Workplace = ireader.GetValue(55).ToString();
                    inf.Serial01 = ireader.GetValue(56).ToString();
                    inf.Serial02 = ireader.GetValue(57).ToString();
                    inf.Serial03 = ireader.GetValue(58).ToString();
                    inf.Serial04 = ireader.GetValue(59).ToString();
                    inf.Serial05 = ireader.GetValue(60).ToString();
                    inf.Serial06 = ireader.GetValue(61).ToString();
                    inf.EndDate_BHYT = ireader.GetValue(62).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { inf = null; }
            return inf;
        }

        public static bool IsUpdCancelRecordOutput(decimal patientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "update MedicalRecordOutput set Cancel=1 where PatientReceiveID={0}";
                return cn.ExecuteNonQuery(CommandType.Text, string.Format(query, patientReceiveID), null) == 1 ? true : false;
            }
            catch { return false; }
        }

        public static bool IURecordOutput(MedicalRecordOutputInf info, ref int soluutru)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[57];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = info.PatientReceiveID;
                param[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar);
                param[2].Value = info.PatientCode;
                param[3] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[3].Value = info.DepartmentCode;
                param[4] = new SqlParameter("@ShiftWork", SqlDbType.Char, 2);
                param[4].Value = info.ShiftWork;
                param[5] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 15);
                param[5].Value = info.EmployeeCode;
                param[6] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 100);
                param[6].Value = info.MedicalRecordCode;
                param[7] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[7].Value = info.ObjectCode;
                param[8] = new SqlParameter("@FullNameFamily", SqlDbType.NVarChar, 200);
                param[8].Value = info.FullNameFamily;
                param[9] = new SqlParameter("@MobileFamily", SqlDbType.NVarChar, 100);
                param[9].Value = info.MobileFamily;
                param[10] = new SqlParameter("@HourIn", SqlDbType.VarChar, 7);
                param[10].Value = info.HourIn;
                param[11] = new SqlParameter("@DateIn", SqlDbType.VarChar, 10);
                param[11].Value = info.DateIn;
                param[12] = new SqlParameter("@DiagnosisIntroduce", SqlDbType.NVarChar, 250);
                param[12].Value = info.DiagnosisIntroduce;
                param[13] = new SqlParameter("@isYTe", SqlDbType.Bit);
                param[13].Value = info.isYTe == true ? 1 : 0;
                param[14] = new SqlParameter("@isTuDen", SqlDbType.Bit);
                param[14].Value = info.isTuDen == true ? 1 : 0;
                param[15] = new SqlParameter("@ReasonIn", SqlDbType.NVarChar, 250);
                param[15].Value = info.ReasonIn;
                param[16] = new SqlParameter("@Pathological_Process", SqlDbType.NVarChar, 1000);
                param[16].Value = info.Pathological_Process;
                param[17] = new SqlParameter("@Anamnesis_Personal", SqlDbType.NVarChar, 1000);
                param[17].Value = info.Anamnesis_Personal;
                param[18] = new SqlParameter("@Anamnesis_Family", SqlDbType.NVarChar, 1000);
                param[18].Value = info.Anamnesis_Family;
                param[19] = new SqlParameter("@KB_Totality", SqlDbType.NVarChar, 1000);
                param[19].Value = info.KB_Totality;
                param[20] = new SqlParameter("@KB_Parts", SqlDbType.NVarChar, 1000);
                param[20].Value = info.KB_Parts;
                param[21] = new SqlParameter("@Pulse", SqlDbType.VarChar, 10);
                param[21].Value = info.Pulse;
                param[22] = new SqlParameter("@Temperature", SqlDbType.VarChar, 10);
                param[22].Value = info.Temperature;
                param[23] = new SqlParameter("@BloodPressure", SqlDbType.VarChar, 10);
                param[23].Value = info.BloodPressure;
                param[24] = new SqlParameter("@BloodPressure1", SqlDbType.VarChar, 10);
                param[24].Value = info.BloodPressure1;
                param[25] = new SqlParameter("@Weight_", SqlDbType.VarChar, 10);
                param[25].Value = info.Weight_;
                param[26] = new SqlParameter("@Hight", SqlDbType.VarChar, 10);
                param[26].Value = info.Hight;
                param[27] = new SqlParameter("@Breath", SqlDbType.VarChar, 10);
                param[27].Value = info.Breath;
                param[28] = new SqlParameter("@CLS_Brief", SqlDbType.NVarChar);
                param[28].Value = info.CLS_Brief;
                param[29] = new SqlParameter("@Initial_DiagnosisName", SqlDbType.NVarChar, 500);
                param[29].Value = info.Initial_DiagnosisName;
                param[30] = new SqlParameter("@Drug_Brief", SqlDbType.NVarChar);
                param[30].Value = info.Drug_Brief;
                param[31] = new SqlParameter("@ICD10_Out", SqlDbType.Int);
                param[31].Value = info.ICD10_Out;
                param[32] = new SqlParameter("@ICD10_OutName", SqlDbType.NVarChar, 500);
                param[32].Value = info.ICD10_OutName;
                param[33] = new SqlParameter("@Treatment_DateFrom", SqlDbType.VarChar, 10);
                param[33].Value = info.Treatment_DateFrom;
                param[34] = new SqlParameter("@Treatment_DateTo", SqlDbType.VarChar, 10);
                param[34].Value = info.Treatment_DateTo;
                param[35] = new SqlParameter("@BenhAn_DienBienLamSang", SqlDbType.NVarChar);
                param[35].Value = info.BenhAn_DienBienLamSang;
                param[36] = new SqlParameter("@BenhAn_TomTatXetNghiem", SqlDbType.NVarChar);
                param[36].Value = info.BenhAn_TomTatXetNghiem;
                param[37] = new SqlParameter("@BenhAn_BenhChinh", SqlDbType.Int);
                param[37].Value = info.BenhAn_BenhChinh;
                param[38] = new SqlParameter("@BenhAn_BenhChinhTen", SqlDbType.NVarChar, 500);
                param[38].Value = info.BenhAn_BenhChinhTen;
                param[39] = new SqlParameter("@BenhAn_BenhKemTheo", SqlDbType.VarChar, 100);
                param[39].Value = info.BenhAn_BenhKemTheo;
                param[40] = new SqlParameter("@BenhAn_BenhKemTheoTen", SqlDbType.NVarChar, 1000);
                param[40].Value = info.BenhAn_BenhKemTheoTen;
                param[41] = new SqlParameter("@BenhAn_PPDieuTri", SqlDbType.NVarChar);
                param[41].Value = info.BenhAn_PPDieuTri;
                param[42] = new SqlParameter("@BenhAn_TTRaVien", SqlDbType.NVarChar, 250);
                param[42].Value = info.BenhAn_TTRaVien;
                param[43] = new SqlParameter("@BenhAn_HuongDieuTri", SqlDbType.NVarChar);
                param[43].Value = info.BenhAn_HuongDieuTri;
                param[44] = new SqlParameter("@BenhAn_HSXQuang", SqlDbType.VarChar, 5);
                param[44].Value = info.BenhAn_HSXQuang;
                param[45] = new SqlParameter("@BenhAn_HSCTScanner", SqlDbType.VarChar, 5);
                param[45].Value = info.BenhAn_HSCTScanner;
                param[46] = new SqlParameter("@BenhAn_HSSieuAm", SqlDbType.VarChar, 5);
                param[46].Value = info.BenhAn_HSSieuAm;
                param[47] = new SqlParameter("@BenhAn_HSXetNghiem", SqlDbType.VarChar, 5);
                param[47].Value = info.BenhAn_HSXetNghiem;
                param[48] = new SqlParameter("@BenhAn_HSKhac", SqlDbType.VarChar, 5);
                param[48].Value = info.BenhAn_HSKhac;
                param[49] = new SqlParameter("@BenhAn_NguoiGiaoHS", SqlDbType.VarChar, 15);
                param[49].Value = info.BenhAn_NguoiGiaoHS;
                param[50] = new SqlParameter("@BenhAn_NguoiNhanHS", SqlDbType.VarChar, 15);
                param[50].Value = info.BenhAn_NguoiNhanHS;
                param[51] = new SqlParameter("@EmployeeDoctorCode", SqlDbType.VarChar, 15);
                param[51].Value = info.EmployeeDoctorCode;
                param[52] = new SqlParameter("@DateWorking", SqlDbType.Date);
                param[52].Value = info.DateWorking;
                param[53] = new SqlParameter("@SoLuuTru", SqlDbType.Int);
                param[53].Value = info.SoLuuTru;
                param[54] = new SqlParameter("@Cancel", SqlDbType.Bit);
                param[54].Value = info.Cancel == true ? 1 : 0;
                param[55] = new SqlParameter("@Workplace", SqlDbType.NVarChar, 200);
                param[55].Value = info.Workplace;
                param[56] = new SqlParameter("@Result", SqlDbType.Int);
                param[56].Direction = ParameterDirection.Output;
                soluutru = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proIU_MedicalRecordOutput", param));
                if (soluutru > 0)
                    return true;
                else
                    return false;
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }

    }
}
