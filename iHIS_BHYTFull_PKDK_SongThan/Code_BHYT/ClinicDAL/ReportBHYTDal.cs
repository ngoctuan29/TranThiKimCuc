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
    public class ReportBHYTDal
    {
        public static Int32 InsReportBHYT(ReportBHYTInf info, ref string reportID, DateTime dateIntoEdit)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[55];
                param[0] = new SqlParameter("@ReportID", SqlDbType.VarChar, 20);
                param[0].Value = info.ReportID;
                param[1] = new SqlParameter("@BHYTPay", SqlDbType.Decimal);
                param[1].Value = info.BHYTPay;
                param[2] = new SqlParameter("@PatientPay", SqlDbType.Decimal);
                param[2].Value = info.PatientPay;
                param[3] = new SqlParameter("@Exemptions", SqlDbType.Decimal);
                param[3].Value = info.Exemptions;
                param[4] = new SqlParameter("@TotalAmount", SqlDbType.Decimal);
                param[4].Value = info.TotalAmount;
                param[5] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[5].Value = info.EmployeeCode;
                param[6] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[6].Value = info.PatientCode;
                param[7] = new SqlParameter("@TotalReal", SqlDbType.Decimal);
                param[7].Value = info.TotalReal;
                param[8] = new SqlParameter("@RateExemptions", SqlDbType.Decimal);
                param[8].Value = info.RateExemptions;
                param[9] = new SqlParameter("@RateSurcharge", SqlDbType.Decimal);
                param[9].Value = info.RateSurcharge;
                param[10] = new SqlParameter("@TotalSurcharge", SqlDbType.Decimal);
                param[10].Value = info.TotalSurcharge;
                param[11] = new SqlParameter("@ShiftWork", SqlDbType.Char, 2);
                param[11].Value = info.ShiftWork;
                param[12] = new SqlParameter("@DateInto", SqlDbType.DateTime);
                param[12].Value = info.DateInto;
                param[13] = new SqlParameter("@DateOut", SqlDbType.DateTime);
                param[13].Value = info.DateOut;
                param[14] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[14].Value = info.DepartmentCode;
                param[15] = new SqlParameter("@Symptoms", SqlDbType.NVarChar);
                param[15].Value = info.Symptoms;
                param[16] = new SqlParameter("@Advices", SqlDbType.NVarChar);
                param[16].Value = info.Advices;
                param[17] = new SqlParameter("@Treatments", SqlDbType.NVarChar);
                param[17].Value = info.Treatments;
                param[18] = new SqlParameter("@TackleCode", SqlDbType.Int);
                param[18].Value = info.TackleCode;
                param[19] = new SqlParameter("@ICD10", SqlDbType.VarChar);
                param[19].Value = info.ICD10;
                param[20] = new SqlParameter("@ICD10More", SqlDbType.VarChar);
                param[20].Value = info.ICD10More;
                param[21] = new SqlParameter("@DiagnosisCustom", SqlDbType.NVarChar);
                param[21].Value = info.DiagnosisCustom;
                param[22] = new SqlParameter("@AppointmentDate", SqlDbType.VarChar);
                param[22].Value = info.AppointmentDate;
                param[23] = new SqlParameter("@AppointmentContent", SqlDbType.NVarChar);
                param[23].Value = info.AppointmentContent;
                param[24] = new SqlParameter("@Pulse", SqlDbType.VarChar);
                param[24].Value = info.Pulse;
                param[25] = new SqlParameter("@Temperature", SqlDbType.VarChar);
                param[25].Value = info.Temperature;
                param[26] = new SqlParameter("@BloodPressure", SqlDbType.VarChar);
                param[26].Value = info.BloodPressure;
                param[27] = new SqlParameter("@BloodPressure1", SqlDbType.VarChar);
                param[27].Value = info.BloodPressure1;
                param[28] = new SqlParameter("@Weight", SqlDbType.VarChar);
                param[28].Value = info.Weight;
                param[29] = new SqlParameter("@Hight", SqlDbType.VarChar);
                param[29].Value = info.Hight;
                param[30] = new SqlParameter("@Breath", SqlDbType.VarChar);
                param[30].Value = info.Breath;
                param[31] = new SqlParameter("@Serial", SqlDbType.VarChar);
                param[31].Value = info.Serial;
                param[32] = new SqlParameter("@StartDate", SqlDbType.Date);
                param[32].Value = info.StartDate;
                param[33] = new SqlParameter("@EndDate", SqlDbType.Date);
                param[33].Value = info.EndDate;
                param[34] = new SqlParameter("@KCBBDCode", SqlDbType.VarChar, 10);
                param[34].Value = info.KCBBDCode;
                param[35] = new SqlParameter("@TraiTuyen", SqlDbType.Int);
                param[35].Value = info.TraiTuyen;
                param[36] = new SqlParameter("@Serial01", SqlDbType.VarChar, 5);
                param[36].Value = info.Serial01;
                param[37] = new SqlParameter("@Serial02", SqlDbType.VarChar, 5);
                param[37].Value = info.Serial02;
                param[38] = new SqlParameter("@Serial03", SqlDbType.VarChar, 5);
                param[38].Value = info.Serial03;
                param[39] = new SqlParameter("@Serial04", SqlDbType.VarChar, 5);
                param[39].Value = info.Serial04;
                param[40] = new SqlParameter("@Serial05", SqlDbType.VarChar, 5);
                param[40].Value = info.Serial05;
                param[41] = new SqlParameter("@Serial06", SqlDbType.VarChar, 5);
                param[41].Value = info.Serial06;
                param[42] = new SqlParameter("@ReferralPaper", SqlDbType.Int);
                param[42].Value = info.ReferralPaper;
                param[43] = new SqlParameter("@RateBHYT", SqlDbType.Int);
                param[43].Value = info.RateBHYT;
                param[44] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[44].Value = info.ObjectCode;
                param[45] = new SqlParameter("@DateIntoEdit", SqlDbType.DateTime);
                param[45].Value = dateIntoEdit;
                param[46] = new SqlParameter("@MATNTT", SqlDbType.Int);
                param[46].Value = info.MATNTT;
                param[47] = new SqlParameter("@MATTRV", SqlDbType.Int);
                param[47].Value = info.MATTRV;
                param[48] = new SqlParameter("@IDTreatmentResults", SqlDbType.Int);
                param[48].Value = info.IDTreatmentResults;
                param[49] = new SqlParameter("@Capcuu", SqlDbType.Int);
                param[49].Value = info.Capcuu;
                param[50] = new SqlParameter("@TongBH", SqlDbType.Decimal);
                param[50].Value = info.AmountBHYT;
                param[51] = new SqlParameter("@BNTraBH", SqlDbType.Decimal);
                param[51].Value = info.AmountBNTraBHYT;
                param[52] = new SqlParameter("@ICD10_Custom", SqlDbType.VarChar);
                param[52].Value = info.ICD10_Custom;
                param[53] = new SqlParameter("@ICD10Name_Custom", SqlDbType.NVarChar);
                param[53].Value = info.ICD10Name_Custom;
                param[54] = new SqlParameter("@RowIDResult", SqlDbType.VarChar, 20);
                param[54].Direction = ParameterDirection.Output;
                reportID = cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proIUReportBHYT", param);
                if (!string.IsNullOrEmpty(reportID))
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch (Exception) { return -2; }
        }


        public static Int32 InsReportBHYTDetail(ReportBHYTDetailInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[26];
                param[0] = new SqlParameter("@ReportID", SqlDbType.VarChar, 20);
                param[0].Value = info.ReportID;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = info.PatientReceiveID;
                param[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[2].Value = info.PatientCode;
                param[3] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[3].Value = info.ServiceCode;
                param[4] = new SqlParameter("@ServicePrice", SqlDbType.Decimal);
                param[4].Value = info.ServicePrice;
                param[5] = new SqlParameter("@DisparityPrice", SqlDbType.Decimal);
                param[5].Value = info.DisparityPrice;
                param[6] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[6].Value = info.ObjectCode;
                param[7] = new SqlParameter("@Quantity", SqlDbType.Int);
                param[7].Value = info.Quantity;
                param[8] = new SqlParameter("@Amount", SqlDbType.Decimal);
                param[8].Value = info.Amount;
                param[9] = new SqlParameter("@BHYTPay", SqlDbType.Decimal);
                param[9].Value = info.BHYTPay;
                param[10] = new SqlParameter("@PatientPay", SqlDbType.Decimal);
                param[10].Value = info.PatientPay;
                param[11] = new SqlParameter("@Ordinal", SqlDbType.Int);
                param[11].Value = info.Ordinal;
                param[12] = new SqlParameter("@SalesPrice", SqlDbType.Decimal);
                param[12].Value = info.SalesPrice;
                param[13] = new SqlParameter("@BHYTPrice", SqlDbType.Decimal);
                param[13].Value = info.BHYTPrice;
                param[14] = new SqlParameter("@RateBHYT", SqlDbType.Int);
                param[14].Value = info.RateBHYT;
                param[15] = new SqlParameter("@DateOfIssues", SqlDbType.VarChar, 5);
                param[15].Value = info.DateOfIssues;
                param[16] = new SqlParameter("@Morning", SqlDbType.VarChar, 5);
                param[16].Value = info.Morning;
                param[17] = new SqlParameter("@Noon", SqlDbType.VarChar, 5);
                param[17].Value = info.Noon;
                param[18] = new SqlParameter("@Afternoon", SqlDbType.VarChar, 5);
                param[18].Value = info.Afternoon;
                param[19] = new SqlParameter("@Evening", SqlDbType.VarChar, 5);
                param[19].Value = info.Evening;
                param[20] = new SqlParameter("@Instruction", SqlDbType.NVarChar, 200);
                param[20].Value = info.Instruction;
                param[21] = new SqlParameter("@DoseOf", SqlDbType.VarChar, 5);
                param[21].Value = info.DoseOf;
                param[22] = new SqlParameter("@DoseOfPills", SqlDbType.NVarChar, 5);
                param[22].Value = info.DoseOfPills;
                param[23] = new SqlParameter("@RowIDPrice", SqlDbType.Decimal);
                param[23].Value = info.RowIDPrice;
                param[24] = new SqlParameter("@ServiceCode_PK", SqlDbType.VarChar);
                param[24].Value = info.ServiceCode_PK;
                param[25] = new SqlParameter("@SODKGP", SqlDbType.VarChar);
                param[25].Value = info.SODKGP;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "proIUReportBHYTDetail", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 DelReportBHYTDetail(string reportID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@ReportID", SqlDbType.VarChar, 20);
                param[1].Value = reportID;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "proDel_ReportBHYTDetail", param);
            }
            catch { return -1; }
        }

        public static Int32 DelReportBHYT(string reportID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@ReportID", SqlDbType.VarChar, 20);
                param[1].Value = reportID;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "proDel_ReportBHYT", param);
            }
            catch { return -1; }
        }

        public static Int32 UpdCancelReportBHYT(string reportID, string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@ReportID", SqlDbType.VarChar, 20);
                param[1].Value = reportID;
                param[2] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[2].Value = employeeCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "proUpd_ReportBHYT", param);
            }
            catch { return -1; }
        }

        public static DataTable TableListReportBHYTFinish(string dateFrom, string dateTo, Int32 cancel)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = @"Select a.PatientCode,a.ReportID,a.PostingDate,c.PatientName,(case c.PatientGender when 0 then N'Nữ' else N'Nam' end) PatientGenderName,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.RateExemptions,a.RateSurcharge,a.TotalSurcharge,d.ObjectName,a1.EmployeeName,a.Cancel,a.Exemptions,a.Serial,a.DateOut,a.DateInto
                        from ReportBHYT a inner join Patients c on a.PatientCode=c.PatientCode inner join [Object] d on a.ObjectCode=d.ObjectCode inner join Employee a1 on a.EmployeeCode=a1.EmployeeCode
                        where CONVERT(date,a.PostingDate,103) between CONVERT(date,'{0}',103) and CONVERT(date,'{1}',103) and a.Cancel={2}";
                tableResult = cn.ExecuteQuery(string.Format(query, dateFrom, dateTo, cancel));
            }
            catch { tableResult = null; }
            return tableResult;
        }

        public static DataTable TableReportBHYTFinish(string reportID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "proGet_ReportBHYT";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ReportID", SqlDbType.VarChar, 20);
                param[0].Value = reportID;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, query, param);
            }
            catch { tableResult = null; }
            return tableResult;
        }

        public static DataTable TableReportBHYTFinishDetail(string reportID, int type)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "proGet_ReportBHYTDetail";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ReportID", SqlDbType.VarChar, 20);
                param[0].Value = reportID;
                param[1] = new SqlParameter("@Type", SqlDbType.Int);
                param[1].Value = type;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, query, param);
            }
            catch { tableResult = null; }
            return tableResult;
        }

        public static ReportBHYTInf ObjReportBHYTFinish(string reportID)
        {
            ConnectDB cn = new ConnectDB();
            ReportBHYTInf bhyt = new ReportBHYTInf();
            try
            {
                string query = @"select ReportID,BHYTPay,PatientPay,Exemptions,TotalAmount,PostingDate,EmployeeCode,PatientCode,Cancel,TotalReal,RateExemptions,RateSurcharge,TotalSurcharge,DateInto,DateOut,DepartmentCode,ObjectCode,Symptoms,Advices,Treatments,TackleCode,
                    ICD10,ICD10More,DiagnosisCustom,AppointmentDate,AppointmentContent,Pulse,Temperature,BloodPressure,BloodPressure1,Weight,Hight,Breath,Serial,StartDate,EndDate,KCBBDCode,TraiTuyen,Serial,Serial01,Serial02,Serial03,Serial04,Serial05,Serial06,ReferralPaper,
                    MATNTT,MATTRV,IDTreatmentResults,Capcuu,TongBH,BNTraBH,ICD10_Custom,ICD10Name_Custom
                     from ReportBHYT where ReportID ='{0}'";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(query, reportID), null);
                if (ireader.Read())
                {
                    bhyt.ReportID = ireader.GetValue(0).ToString(); bhyt.BHYTPay = ireader.GetDecimal(1); bhyt.PatientPay = ireader.GetDecimal(2); bhyt.Exemptions = ireader.GetDecimal(3); bhyt.TotalAmount = ireader.GetDecimal(4); bhyt.PostingDate = ireader.GetDateTime(5);
                    bhyt.EmployeeCode = ireader.GetValue(6).ToString(); bhyt.PatientCode = ireader.GetValue(7).ToString(); bhyt.Cancel = ireader.GetInt32(8); bhyt.TotalReal = ireader.GetDecimal(9); bhyt.RateExemptions = ireader.GetDecimal(10);
                    bhyt.RateSurcharge = ireader.GetDecimal(11); bhyt.TotalSurcharge = ireader.GetDecimal(12); bhyt.DateInto = ireader.GetDateTime(13); bhyt.DateOut = ireader.GetDateTime(14); bhyt.DepartmentCode = ireader.GetValue(15).ToString();
                    bhyt.ObjectCode = ireader.GetInt32(16); bhyt.Symptoms = ireader.GetValue(17).ToString(); bhyt.Advices = ireader.GetValue(18).ToString(); bhyt.Treatments = ireader.GetValue(19).ToString(); bhyt.TackleCode = ireader.GetInt32(20);
                    bhyt.ICD10 = ireader.GetValue(21).ToString();
                    bhyt.ICD10More = ireader.GetValue(22).ToString();
                    bhyt.DiagnosisCustom = ireader.GetValue(23).ToString();
                    bhyt.AppointmentDate = ireader.GetValue(24).ToString();
                    bhyt.AppointmentContent = ireader.GetValue(25).ToString();
                    bhyt.Pulse = ireader.GetValue(26).ToString();
                    bhyt.Temperature = ireader.GetValue(27).ToString();
                    bhyt.BloodPressure = ireader.GetValue(28).ToString();
                    bhyt.BloodPressure1 = ireader.GetValue(29).ToString();
                    bhyt.Weight = ireader.GetValue(30).ToString();
                    bhyt.Hight = ireader.GetValue(31).ToString();
                    bhyt.Breath = ireader.GetValue(32).ToString();
                    bhyt.Serial = ireader.GetValue(33).ToString();
                    bhyt.StartDate = ireader.GetDateTime(34);
                    bhyt.EndDate = ireader.GetDateTime(35);
                    bhyt.KCBBDCode = ireader.GetValue(36).ToString();
                    bhyt.TraiTuyen = ireader.GetInt32(37);
                    bhyt.Serial = ireader.GetValue(38).ToString();
                    bhyt.Serial01 = ireader.GetValue(39).ToString();
                    bhyt.Serial02 = ireader.GetValue(40).ToString();
                    bhyt.Serial03 = ireader.GetValue(41).ToString();
                    bhyt.Serial04 = ireader.GetValue(42).ToString();
                    bhyt.Serial05 = ireader.GetValue(43).ToString();
                    bhyt.Serial06 = ireader.GetValue(44).ToString();
                    bhyt.ReferralPaper = Convert.ToInt32(ireader.GetValue(45).ToString());
                    bhyt.MATNTT = Convert.ToInt32(ireader.GetValue(46).ToString());
                    bhyt.MATTRV = Convert.ToInt32(ireader.GetValue(47).ToString());
                    bhyt.IDTreatmentResults = Convert.ToInt32(ireader.GetValue(48).ToString());
                    bhyt.Capcuu = ireader.GetInt32(49);
                    bhyt.AmountBHYT = Convert.ToDecimal(ireader.GetValue(50).ToString());
                    bhyt.AmountBNTraBHYT = Convert.ToDecimal(ireader.GetValue(51).ToString());
                    bhyt.ICD10_Custom = ireader.GetValue(52).ToString();
                    bhyt.ICD10Name_Custom = ireader.GetValue(53).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { }
            return bhyt;
        }
        public static DataTable TableListReportBHYTFinish(string dateFrom, string dateTo, Int32 cancel, string patientcode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = @"Select a.PatientCode,a.ReportID,a.PostingDate,c.PatientName,(case c.PatientGender when 0 then N'Nữ' else N'Nam' end) PatientGenderName,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.RateExemptions,a.RateSurcharge,a.TotalSurcharge,d.ObjectName,a1.EmployeeName,a.Cancel,a.Exemptions,a.Serial,a.DateOut,a.DateInto,a.SendFile
                        from ReportBHYT a inner join Patients c on a.PatientCode=c.PatientCode inner join [Object] d on a.ObjectCode=d.ObjectCode inner join Employee a1 on a.EmployeeCode=a1.EmployeeCode
                        where CONVERT(date,a.PostingDate,103) between CONVERT(date,'{0}',103) and CONVERT(date,'{1}',103) and a.Cancel={2} and a.PatientCode='{3}'";
                tableResult = cn.ExecuteQuery(string.Format(query, dateFrom, dateTo, cancel, patientcode));
            }
            catch { tableResult = null; }
            return tableResult;
        }
        public static DataTable TableDMTTRV()
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "select Ma,Ten from DMTTRV order by ma ";
                tableResult = cn.CallProcedureTable(CommandType.Text, query, null);
            }
            catch { tableResult = null; }
            return tableResult;
        }
        public static Int32 UpdSendFileReportBHYT(string reportID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = " update ReportBHYT set SendFile=@SendFile where ReportID=@ReportID";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ReportID", SqlDbType.VarChar, 20);
                param[0].Value = reportID;
                param[1] = new SqlParameter("@SendFile", SqlDbType.Bit);
                param[1].Value = 1;
                return cn.ExecuteNonQuery(CommandType.Text, query, param);
            }
            catch { return -1; }
        }
        public static DataTable TableKQDT()
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "select RowID,ResultsName from TreatmentResults order by RowID ";
                tableResult = cn.CallProcedureTable(CommandType.Text, query, null);
            }
            catch { tableResult = null; }
            return tableResult;
        }
        public static DataTable TableReportBHYTFinishThuPhi(string reportID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "proGet_ReportBHYTThuPhi";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ReportID", SqlDbType.VarChar, 20);
                param[0].Value = reportID;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, query, param);
            }
            catch { tableResult = null; }
            return tableResult;
        }
    }
}
