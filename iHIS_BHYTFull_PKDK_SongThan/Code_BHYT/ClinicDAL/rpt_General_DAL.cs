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
    public class rpt_General_DAL
    {
        public static DataTable DT_Get_KetQuaDieuTri(string dtFrom, string dtTo, string sDepartment, int iType)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@PatientType", SqlDbType.Int);
                param[0].Value = iType;
                param[1] = new SqlParameter("@frDate", SqlDbType.Char);
                param[1].Value = dtFrom;
                param[2] = new SqlParameter("@toDate", SqlDbType.Char);
                param[2].Value = dtTo;
                param[3] = new SqlParameter("@DepartmentCode", SqlDbType.NVarChar);
                param[3].Value = sDepartment;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_Rpt_KetQuaDieuTri", param);
                return dtResult;
            }
            catch { return null; }
        }

        public static DataTable DT_DauHieuSinhTon(DateTime dtFrom, DateTime dtTo, string sDepartment)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@frDate", SqlDbType.Date);
                param[0].Value = dtFrom;
                param[1] = new SqlParameter("@toDate", SqlDbType.Date);
                param[1].Value = dtTo;
                param[2] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar);
                param[2].Value = sDepartment;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_View_DauHieuSinhTon", param);
                return dtResult;
            }
            catch { return null; }
        }

        public static DataTable DT_DauHieuSinhTonForPatient(DateTime dtime, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@date", SqlDbType.Date);
                param[0].Value = dtime;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar);
                param[1].Value = sPatientCode;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_View_DauHieuSinhTonForPatient", param);
                return dtResult;
            }
            catch { return null; }

        }

        public static DataTable TableViewListMedical(string dateFrom, string dateTo, Int32 type)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@FromDate", SqlDbType.Char, 10);
                param[0].Value = dateFrom;
                param[1] = new SqlParameter("@ToDate", SqlDbType.Char, 10);
                param[1].Value = dateTo;
                param[2] = new SqlParameter("@Type", SqlDbType.Int);
                param[2].Value = type;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, "proView_ListMedical", param);
                return tableResult;
            }
            catch { return null; }
        }
        public static DataTable TableCountReceive()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_ViewCountPatientReceive", null);
                return dtResult;
            }
            catch { return null; }
        }
        public static DataTable TableTotalSuggested(string serviceGroupCode, string fromdate, string todate, int receive)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@FromDate", SqlDbType.Char, 10);
                param[0].Value = fromdate;
                param[1] = new SqlParameter("@ToDate", SqlDbType.Char, 10);
                param[1].Value = todate;
                param[2] = new SqlParameter("@ServiceGroupCode", SqlDbType.VarChar, 15);
                param[2].Value = serviceGroupCode;
                param[3] = new SqlParameter("@Receive", SqlDbType.Int);
                param[3].Value = receive;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proView_TotalSuggested", param);
            }
            catch { return null; }
        }
        public static DataTable TableTotalSuggestedForDoctor(DateTime fromDate, DateTime toDate, string serviceCategoryCode, string employeeCodeDoctor, Int32 paid, string serviceGroupCode, Int32 done)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@FromDate", SqlDbType.Date);
                param[0].Value = fromDate;
                param[1] = new SqlParameter("@ToDate", SqlDbType.Date);
                param[1].Value = toDate;
                param[2] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 300);
                param[2].Value = serviceCategoryCode;
                param[3] = new SqlParameter("@EmployeeCodeDoctor", SqlDbType.VarChar, 300);
                param[3].Value = employeeCodeDoctor;
                param[4] = new SqlParameter("@Paid", SqlDbType.Int);
                param[4].Value = paid;
                param[5] = new SqlParameter("@Done", SqlDbType.Int);
                param[5].Value = done;
                param[6] = new SqlParameter("@ServiceGroupCode", SqlDbType.VarChar, 15);
                param[6].Value = serviceGroupCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proView_TotalSuggestedForDoctor", param);
            }
            catch { return null; }
        }
        public static DataTable TableTotalSuggestedForDoctorDoing(string fromDate, string toDate, string serviceCategoryCode, string employeeCodeDoctor, Int32 paid, string serviceGroupCode, Int32 done, string ServiceCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@FromDate", SqlDbType.VarChar, 15);
                param[0].Value = fromDate;
                param[1] = new SqlParameter("@ToDate", SqlDbType.VarChar, 15);
                param[1].Value = toDate;
                param[2] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 300);
                param[2].Value = serviceCategoryCode;
                param[3] = new SqlParameter("@EmployeeCodeDoctor", SqlDbType.VarChar, 300);
                param[3].Value = employeeCodeDoctor;
                param[4] = new SqlParameter("@Paid", SqlDbType.Int);
                param[4].Value = paid;
                param[5] = new SqlParameter("@Done", SqlDbType.Int);
                param[5].Value = done;
                param[6] = new SqlParameter("@ServiceGroupCode", SqlDbType.VarChar, 15);
                param[6].Value = serviceGroupCode;
                param[7] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 15);
                param[7].Value = ServiceCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proView_TotalSuggestedForDoctorDoing", param);
            }
            catch { return null; }
        }

        public static DataTable TableChiTietBenhNhanDV(string fromDate, string toDate, string PatientCode, int PatientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@FromDate", SqlDbType.VarChar, 15);
                param[0].Value = fromDate;
                param[1] = new SqlParameter("@ToDate", SqlDbType.VarChar, 15);
                param[1].Value = toDate;
                param[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 10);
                param[2].Value = PatientCode;
                param[3] = new SqlParameter("@PatientReceiveID", SqlDbType.Int);
                param[3].Value = PatientReceiveID;
               
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proView_ChiTietBenhNhanDV", param);
            }
            catch { return null; }
        }
        public static DataTable TableChiTietBenhNhanTH(string fromDate, string toDate, string PatientCode, int PatientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@FromDate", SqlDbType.VarChar, 15);
                param[0].Value = fromDate;
                param[1] = new SqlParameter("@ToDate", SqlDbType.VarChar, 15);
                param[1].Value = toDate;
                param[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 10);
                param[2].Value = PatientCode;
                param[3] = new SqlParameter("@PatientReceiveID", SqlDbType.Int);
                param[3].Value = PatientReceiveID;

                return cn.CallProcedureTable(CommandType.StoredProcedure, "proView_ChiTietBenhNhanTH", param);
            }
            catch { return null; }
        }
        public static DataTable XuatBM79a(string dtFrom, string dtTo)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@frDate", SqlDbType.VarChar);
                param[0].Value = dtFrom;
                param[1] = new SqlParameter("@toDate", SqlDbType.VarChar);
                param[1].Value = dtTo;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_BM_79a", param);
                return dtResult;
            }
            catch { return null; }
        }
        public static DataTable XuatBM80a(string dtFrom, string dtTo)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@frDate", SqlDbType.VarChar);
                param[0].Value = dtFrom;
                param[1] = new SqlParameter("@toDate", SqlDbType.VarChar);
                param[1].Value = dtTo;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_BM_80a", param);
                return dtResult;
            }
            catch { return null; }
        }
        public static DataTable XuatBCTE(string dtFrom, string dtTo)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@frDate", SqlDbType.VarChar);
                param[0].Value = dtFrom;
                param[1] = new SqlParameter("@toDate", SqlDbType.VarChar);
                param[1].Value = dtTo;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "BCTE", param);
                return dtResult;
            }
            catch { return null; }
        }
        public static DataTable Xuat21(string dtFrom, string dtTo)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@frDate", SqlDbType.VarChar);
                param[0].Value = dtFrom;
                param[1] = new SqlParameter("@toDate", SqlDbType.VarChar);
                param[1].Value = dtTo;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_BM21", param);
                return dtResult;
            }
            catch { return null; }
        }
        public static DataTable Xuat20(string dtFrom, string dtTo)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@frDate", SqlDbType.VarChar);
                param[0].Value = dtFrom;
                param[1] = new SqlParameter("@toDate", SqlDbType.VarChar);
                param[1].Value = dtTo;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_BM20", param);
                return dtResult;
            }
            catch { return null; }
        }
        public static DataTable Xuat19(string dtFrom, string dtTo)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@frDate", SqlDbType.VarChar);
                param[0].Value = dtFrom;
                param[1] = new SqlParameter("@toDate", SqlDbType.VarChar);
                param[1].Value = dtTo;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_BM19", param);
                return dtResult;
            }
            catch { return null; }
        }
        public static DataTable WriteXML1_9324(string dtFrom, string dtTo, string reportID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@frDate", SqlDbType.Char);
                param[0].Value = dtFrom;
                param[1] = new SqlParameter("@toDate", SqlDbType.Char);
                param[1].Value = dtTo;
                param[2] = new SqlParameter("@ReportID", SqlDbType.VarChar);
                param[2].Value = reportID;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_Bang1_9324", param);
                return dtResult;
            }
            catch { return null; }
        }
        public static DataTable WriteXML2_9324(string dtFrom, string dtTo, string reportID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@frDate", SqlDbType.Char);
                param[0].Value = dtFrom;
                param[1] = new SqlParameter("@toDate", SqlDbType.Char);
                param[1].Value = dtTo;
                param[2] = new SqlParameter("@ReportID", SqlDbType.VarChar);
                param[2].Value = reportID;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_Bang2_9324", param);
                return dtResult;
            }
            catch { return null; }
        }
        public static DataTable WriteXML3_9324(string dtFrom, string dtTo, string reportID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@frDate", SqlDbType.Char);
                param[0].Value = dtFrom;
                param[1] = new SqlParameter("@toDate", SqlDbType.Char);
                param[1].Value = dtTo;
                param[2] = new SqlParameter("@ReportID", SqlDbType.VarChar);
                param[2].Value = reportID;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_Bang3_9324", param);
                return dtResult;
            }
            catch { return null; }
        }
        public static DataTable TableTHTC(DateTime tungay, DateTime denngay)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@frDate", SqlDbType.Date);
                param[0].Value = tungay;
                param[1] = new SqlParameter("@toDate", SqlDbType.Date);
                param[1].Value = denngay;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_BCTHTC", param);
            }
            catch { return null; }
        }

        public static DataTable TableTiemVaccin(DateTime tungay, DateTime denngay)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@frDate", SqlDbType.Date);
                param[0].Value = tungay;
                param[1] = new SqlParameter("@toDate", SqlDbType.Date);
                param[1].Value = denngay;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proView_TiemVaccin", param);
            }
            catch { return null; }
        }
        public static DataTable TableHDKCB(DateTime tungay, DateTime denngay)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@frDate", SqlDbType.Date);
                param[0].Value = tungay;
                param[1] = new SqlParameter("@toDate", SqlDbType.Date);
                param[1].Value = denngay;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proView_HDKCB", param);
            }
            catch { return null; }
        }
        public static DataTable TableTNTT(DateTime tungay, DateTime denngay)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@frDate", SqlDbType.Date);
                param[0].Value = tungay;
                param[1] = new SqlParameter("@toDate", SqlDbType.Date);
                param[1].Value = denngay;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proView_TNTT", param);
            }
            catch { return null; }
        }
        public static DataTable TableBM_6_YTTN(DateTime tungay, DateTime denngay)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@frDate", SqlDbType.DateTime);
                param[0].Value = tungay;
                param[1] = new SqlParameter("@Todate", SqlDbType.DateTime);
                param[1].Value = denngay;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proView_BM_6_YTTN", param);
            }
            catch
            { return null; }
        }
        public static DataTable TableDiscountForIntroName(DateTime fromDate, DateTime toDate, string serviceCategoryCode, string employeeCode, string serviceGroupCode, string introName, string typeReport)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@FromDate", SqlDbType.Char, 10);
                param[0].Value = fromDate.ToString("dd/MM/yyyy");
                param[1] = new SqlParameter("@ToDate", SqlDbType.Char, 10);
                param[1].Value = toDate.ToString("dd/MM/yyyy");
                param[2] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 400);
                param[2].Value = serviceCategoryCode;
                param[3] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[3].Value = employeeCode;
                param[4] = new SqlParameter("@IntroName", SqlDbType.NVarChar, 200);
                param[4].Value = introName;
                param[5] = new SqlParameter("@TypeReport", SqlDbType.Char, 2);
                param[5].Value = typeReport;
                param[6] = new SqlParameter("@ServiceGroupCode", SqlDbType.VarChar, 400);
                param[6].Value = serviceGroupCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pReport_DiscountForIntro", param);
            }
            catch { return null; }
        }
        public static DataTable TableDiscountForDoctor(DateTime fromDate, DateTime toDate, string serviceCategoryCode, string employeeCode, string serviceGroupCode, string employeeCodeDoctor, string typeReport)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@FromDate", SqlDbType.Char, 10);
                param[0].Value = fromDate.ToString("dd/MM/yyyy");
                param[1] = new SqlParameter("@ToDate", SqlDbType.Char, 10);
                param[1].Value = toDate.ToString("dd/MM/yyyy");
                param[2] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 400);
                param[2].Value = serviceCategoryCode;
                param[3] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[3].Value = employeeCode;
                param[4] = new SqlParameter("@EmployeeCodeDoctor", SqlDbType.VarChar, 200);
                param[4].Value = employeeCodeDoctor;
                param[5] = new SqlParameter("@TypeReport", SqlDbType.VarChar, 3);
                param[5].Value = typeReport;
                param[6] = new SqlParameter("@ServiceGroupCode", SqlDbType.VarChar, 400);
                param[6].Value = serviceGroupCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pReport_DiscountForDoctor", param);
            }
            catch { return null; }
        }
    }
}
