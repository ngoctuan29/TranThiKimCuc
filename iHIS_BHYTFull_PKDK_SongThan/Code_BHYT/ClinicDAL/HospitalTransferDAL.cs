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
    public class HospitalTransferDAL
    {
        public static HospitalTransferINF ObjTransfer(decimal patientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            HospitalTransferINF inf = new HospitalTransferINF();
            try
            {
                string query = " select HospitalTransfer,PatientReceiveID,ObjectCode,DepartmentCode,DateIn,HourIn,DateMedical,HourMedical,Symptoms,LabResult,DiagnosisCustom,DrugUsed,ReferenceCode,Result,Reason,DateTransfer,HourTransfer,NumberSave,NumberTransfer,TransferExpediency,TransferFullName,EmployeeCode,DirectorApproval,PatientApproval,EmployeeCodeDoctor,WorkDate,PatientAddress,Serial01,Serial02,Serial03,Serial04,Serial05,Serial06,FromDate,ToDate from HospitalTransfer where PatientReceiveID={0} ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(query, patientReceiveID), null);
                if (ireader.Read())
                {
                    inf.HospitalTransfer = ireader.GetValue(0).ToString();
                    inf.PatientReceiveID = ireader.GetDecimal(1);
                    inf.ObjectCode = ireader.GetInt32(2);
                    inf.DepartmentCode = ireader.GetValue(3).ToString();
                    inf.DateIn = ireader.GetValue(4).ToString();
                    inf.HourIn = ireader.GetValue(5).ToString();
                    inf.DateMedical = ireader.GetValue(6).ToString();
                    inf.HourMedical = ireader.GetValue(7).ToString();
                    inf.Symptoms = ireader.GetValue(8).ToString();
                    inf.LabResult = ireader.GetString(9).ToString();
                    inf.DiagnosisCustom = ireader.GetValue(10).ToString();
                    inf.DrugUsed = ireader.GetValue(11).ToString();
                    inf.ReferenceCode = ireader.GetValue(12).ToString();
                    inf.Result = ireader.GetValue(13).ToString();
                    inf.Reason = ireader.GetValue(14).ToString();
                    inf.DateTransfer = ireader.GetValue(15).ToString();
                    inf.HourTransfer = ireader.GetValue(16).ToString();
                    inf.NumberSave = ireader.GetValue(17).ToString();
                    inf.NumberTransfer = ireader.GetValue(18).ToString();
                    inf.TransferExpediency = ireader.GetValue(19).ToString();
                    inf.TransferFullName = ireader.GetValue(20).ToString();
                    inf.EmployeeCode = ireader.GetValue(21).ToString();
                    string temp = ireader.GetValue(22).ToString();
                    inf.DirectorApproval = ireader.GetValue(22).ToString() == "True" ? 1 : 0;
                    inf.PatientApproval = ireader.GetValue(23).ToString() == "True" ? 1 : 0;
                    inf.EmployeeCodeDoctor = ireader.GetValue(24).ToString();
                    inf.WorkDate = Convert.ToDateTime(ireader.GetValue(25).ToString());
                    inf.PatientAddress = ireader.GetValue(26).ToString();
                    inf.Serial01 = ireader.GetValue(27).ToString();
                    inf.Serial02 = ireader.GetValue(28).ToString();
                    inf.Serial03 = ireader.GetValue(29).ToString();
                    inf.Serial04 = ireader.GetValue(30).ToString();
                    inf.Serial05 = ireader.GetValue(31).ToString();
                    inf.Serial06 = ireader.GetValue(32).ToString();
                    inf.FromDate = ireader.GetValue(33).ToString();
                    inf.ToDate = ireader.GetValue(34).ToString();
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
        
        public static DataTable TableTransfer(string dtimeFrom, string dtimeTo)
        {
            ConnectDB cn = new ConnectDB();
            List<HospitalTransferINF> list = new List<HospitalTransferINF>();
            try
            {
                string query = " select a.HospitalTransfer,a.PatientReceiveID,a.ObjectCode,a.DepartmentCode,a.DateIn,a.HourIn,a.DateMedical,a.HourMedical,a.Symptoms,a.LabResult,a.DiagnosisCustom,a.DrugUsed,a.ReferenceCode,a.Result,a.Reason,a.DateTransfer,a.HourTransfer,a.NumberSave,a.NumberTransfer,a.TransferExpediency,a.TransferFullName,a.EmployeeCode,a.DirectorApproval,a.PatientApproval,a.EmployeeCodeDoctor,a.WorkDate,b1.PatientName,b.PatientCode from HospitalTransfer a inner join PatientReceive b on a.PatientReceiveID=b.PatientReceiveID inner join Patients b1 on b.PatientCode=b1.PatientCode where CONVERT(date,a.WorkDate,103)>=CONVERT(date,'{0}',103) and CONVERT(date,a.WorkDate,103)<=CONVERT(date,'{1}',103) order by a.WorkDate ";
                return cn.ExecuteQuery(string.Format(query, dtimeFrom, dtimeTo));
            }
            catch { return null; }
        }
        public static DataTable DTPrintTrransfer(decimal patientReceiveID)
        {
            try
            {
                ConnectDB cn = new ConnectDB();
                string query = "select a.HospitalTransfer,a.PatientReceiveID,a.ObjectCode,a.DepartmentCode,a.DateIn,a.HourIn,a.DateMedical,a.HourMedical,a.Symptoms,a.LabResult,a.DiagnosisCustom,a.DrugUsed,a.ReferenceCode,a.Result,a.Reason,a.DateTransfer,a.HourTransfer,a.NumberSave,a.NumberTransfer,a.TransferExpediency,a.TransferFullName,a.EmployeeCode,a.DirectorApproval,a.PatientApproval,a.EmployeeCodeDoctor,a.WorkDate,a.PatientAddress,";
                query += "a.Serial01,a.Serial02,a.Serial03,a.Serial04,a.Serial05,a.Serial06,a.FromDate,a.ToDate,b1.PatientName,b1.PatientAge,convert(date,b1.PatientBirthday,103) PatientBirthday,b2.EThnicName,b3.CareerName,";
                query += "e.EmployeeName EmployeeNameDoctor, (case when b1.PatientGender = 0 then N'Nữ' else 'Nam' end) PatientGender ,b1.PatientMonth ";
                query += " from HospitalTransfer a inner join PatientReceive b on a.PatientReceiveID=b.PatientReceiveID inner join Patients b1 on b.PatientCode=b1.PatientCode inner join Catalog_EThnic b2 on b.EThnicID=b2.EThnicID inner join Career b3 on b.CareerCode=b3.CareerCode inner join Employee e on a.EmployeeCodeDoctor=e.EmployeeCode ";
                query += " where a.PatientReceiveID={0}";
                return cn.ExecuteQuery(string.Format(query, patientReceiveID));
            }
            catch
            {
                return null;
            }
        }
        public static bool InsTransfer(HospitalTransferINF info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[35];
                param[0] = new SqlParameter("@HospitalTransfer", SqlDbType.NVarChar, 300);
                param[0].Value = info.HospitalTransfer;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = info.PatientReceiveID;
                param[2] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[2].Value = info.ObjectCode;
                param[3] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 15);
                param[3].Value = info.DepartmentCode;
                param[4] = new SqlParameter("@DateIn", SqlDbType.VarChar, 15);
                param[4].Value = info.DateIn;
                param[5] = new SqlParameter("@HourIn", SqlDbType.VarChar, 5);
                param[5].Value = info.HourIn;
                param[6] = new SqlParameter("@DateMedical", SqlDbType.VarChar, 15);
                param[6].Value = info.DateMedical;
                param[7] = new SqlParameter("@HourMedical", SqlDbType.VarChar, 5);
                param[7].Value = info.HourMedical;
                param[8] = new SqlParameter("@Symptoms", SqlDbType.NVarChar, 200);
                param[8].Value = info.Symptoms;
                param[9] = new SqlParameter("@LabResult", SqlDbType.NVarChar);
                param[9].Value = info.LabResult;
                param[10] = new SqlParameter("@DiagnosisCustom", SqlDbType.NVarChar);
                param[10].Value = info.DiagnosisCustom;
                param[11] = new SqlParameter("@DrugUsed", SqlDbType.NVarChar);
                param[11].Value = info.DrugUsed;
                param[12] = new SqlParameter("@ReferenceCode", SqlDbType.VarChar);
                param[12].Value = info.ReferenceCode;
                param[13] = new SqlParameter("@Result", SqlDbType.NVarChar);
                param[13].Value = info.Result;
                param[14] = new SqlParameter("@Reason", SqlDbType.NVarChar);
                param[14].Value = info.Reason;
                param[15] = new SqlParameter("@DateTransfer", SqlDbType.VarChar);
                param[15].Value = info.DateTransfer;
                param[16] = new SqlParameter("@HourTransfer", SqlDbType.VarChar);
                param[16].Value = info.HourTransfer;
                param[17] = new SqlParameter("@NumberSave", SqlDbType.VarChar, 10);
                param[17].Value = info.NumberSave;
                param[18] = new SqlParameter("@NumberTransfer", SqlDbType.VarChar, 10);
                param[18].Value = info.NumberTransfer;
                param[19] = new SqlParameter("@TransferExpediency", SqlDbType.NVarChar);
                param[19].Value = info.TransferExpediency;
                param[20] = new SqlParameter("@TransferFullName", SqlDbType.NVarChar);
                param[20].Value = info.TransferFullName;
                param[21] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar);
                param[21].Value = info.EmployeeCode;
                param[22] = new SqlParameter("@DirectorApproval", SqlDbType.VarChar);
                param[22].Value = info.DirectorApproval;
                param[23] = new SqlParameter("@PatientApproval", SqlDbType.VarChar);
                param[23].Value = info.PatientApproval;
                param[24] = new SqlParameter("@EmployeeCodeDoctor", SqlDbType.VarChar);
                param[24].Value = info.EmployeeCodeDoctor;
                param[25] = new SqlParameter("@WorkDate", SqlDbType.DateTime);
                param[25].Value = info.WorkDate;
                param[26] = new SqlParameter("@PatientAddress", SqlDbType.NVarChar, 1000);
                param[26].Value = info.PatientAddress;
                param[27] = new SqlParameter("@Serial01", SqlDbType.VarChar, 5);
                param[27].Value = info.Serial01;
                param[28] = new SqlParameter("@Serial02", SqlDbType.VarChar, 5);
                param[28].Value = info.Serial02;
                param[29] = new SqlParameter("@Serial03", SqlDbType.VarChar, 5);
                param[29].Value = info.Serial03;
                param[30] = new SqlParameter("@Serial04", SqlDbType.VarChar, 5);
                param[30].Value = info.Serial04;
                param[31] = new SqlParameter("@Serial05", SqlDbType.VarChar, 5);
                param[31].Value = info.Serial05;
                param[32] = new SqlParameter("@Serial06", SqlDbType.VarChar, 5);
                param[32].Value = info.Serial06;
                param[33] = new SqlParameter("@FromDate", SqlDbType.VarChar, 10);
                param[33].Value = info.FromDate;
                param[34] = new SqlParameter("@ToDate", SqlDbType.VarChar, 10);
                param[34].Value = info.ToDate;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "proIns_HospitalTransfer", param) >= 1)
                    return true;
                return false;
            }
            catch { return false; }
        }
        public static Int32 DelTransfer(decimal patientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = patientReceiveID;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "proDel_HospitalTransfer", param);
            }
            catch { return -1; }
        }
        public static DataTable DSTransfer(string datefr, string dateto)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@datefr", SqlDbType.VarChar);
                param[0].Value = datefr;
                param[1] = new SqlParameter("@dateto", SqlDbType.VarChar);
                param[1].Value = dateto;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_DSTransfer", param);
            }
            catch { return null; }
        }
    }
}
