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
    public class ReportDiscountDal
    {
        public static DataTable GetPatientReceiveForIntroName(string dateFrom, string dateTo, string introName, string serviceGroupCode, bool confirmDiscountIntro)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query =string.Empty;
                if (!string.IsNullOrEmpty(introName))
                    query = @" select distinct ISNULL(b.IntroName,'') IntroName from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID = b.RefID inner join Service b1 on b.ServiceCode=b1.ServiceCode inner join ServiceCategory b2 on b1.ServiceCategoryCode=b2.ServiceCategoryCode inner join ServiceGroup b3 on b2.ServiceGroupCode=b3.ServiceGroupCode  where CONVERT(date,a.createDate,103) >= CONVERT(date,'{0}',103) and CONVERT(date,a.createDate,103)<=CONVERT(date,'{1}',103) and b.IntroName like N'{2}%' and b.ServiceCode not in('DV000000') and b.Paid =1 ";
                else
                    query = @"select distinct ISNULL(b.IntroName,'') IntroName from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID = b.RefID inner join Service b1 on b.ServiceCode=b1.ServiceCode inner join ServiceCategory b2 on b1.ServiceCategoryCode=b2.ServiceCategoryCode inner join ServiceGroup b3 on b2.ServiceGroupCode=b3.ServiceGroupCode where CONVERT(date,a.createDate,103) >= CONVERT(date,'{0}',103) and CONVERT(date,a.createDate,103)<=CONVERT(date,'{1}',103) and b.ServiceCode not in('DV000000')  and b.Paid =1  ";
                if (!string.IsNullOrEmpty(serviceGroupCode))
                    query += @" and b3.ServiceGroupCode in({3})";
                if (confirmDiscountIntro)
                    query += " and b.confirmdiscountIntro=1";
                else
                    query += " and b.confirmdiscountIntro=0";
                return cn.ExecuteQuery(string.Format(query, dateFrom, dateTo, introName, serviceGroupCode));
            }
            catch { return null; }
        }

        public static DataTable GetSuggestedServiceForIntroNameDetail(string dateFrom, string dateTo, string introName, string serviceGroup, int statusConfirm)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = string.Empty;
                query = @" Select a.ReceiptID,b.PatientReceiveID,b.CreateDate PostingDate,e.PatientCode,e.PatientName,(case e.PatientGender when 0 then N'Nữ' else 'Nam' end) PatientGenderName, e.PatientBirthyear,c.ServiceCode,c.ServiceName,(a.Quantity * a.ServicePrice) ServicePrice,(a.Quantity * a.DiscountIntro) DiscountAmount, ISNULL(f.DiscountPer,a1.PerDiscountIntro) DiscountPer, a.ConfirmDiscountIntro as [Check],a.IntroName
                        from SuggestedServiceReceipt a inner join PatientReceive b on a.RefID=b.PatientReceiveID and CONVERT(date,a.WorkDate,103) between CONVERT(date,'{0}',103) and CONVERT(date,'{1}',103) inner join [Service] c on a.ServiceCode=c.ServiceCode inner join ServiceCategory d on c.ServiceCategoryCode=d.ServiceCategoryCode inner join Patients e on b.PatientCode=e.PatientCode left join (select ReceiptID,DiscountPer from ReportDiscount where CONVERT(date,ReceiveDate,103) between CONVERT(date,'{0}',103) and CONVERT(date,'{1}',103)) f on a.ReceiptID=f.ReceiptID inner join ServicePrice a1 on a.RowIDPrice=a1.RowID inner join ServiceGroup d1 on d.ServiceGroupCode=d1.ServiceGroupCode
                        where a.ConfirmDiscountIntro=" + statusConfirm + " and CONVERT(date,b.CreateDate,103) >= CONVERT(date,'{0}',103) and CONVERT(date,b.CreateDate,103) <= CONVERT(date,'{1}',103) and a.ServiceCode not in('DV000000','DV000238') and a.Paid =1 "; //and a.ServicePrice > 0 "; lay tim chung gia bang 0 ngay 17/07/2016
                if (string.IsNullOrEmpty(introName))
                    query += " and (a.IntroName is null or a.IntroName ='')";
                else
                    query += " and Replace (Ltrim(rtrim(a.IntroName)),' ','') like Replace (Ltrim(rtrim( N'%{3}%')),' ','')"; 
                if (!string.IsNullOrEmpty(serviceGroup))
                    query += " and d1.ServiceGroupCode in({2})";
                return cn.ExecuteQuery(string.Format(query, dateFrom, dateTo, serviceGroup, introName));
            }
            catch { return null; }
        }

        public static DataTable GetPatientReceiveForDoctor(string dateFrom, string dateTo, string employeeCode, string serviceGroupCode, string type)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@FromDate", SqlDbType.Date);
                param[0].Value = dateFrom;
                param[1] = new SqlParameter("@ToDate", SqlDbType.Date);
                param[1].Value = dateTo;
                param[2] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[2].Value = employeeCode;
                param[3] = new SqlParameter("@ServiceGroupCode", SqlDbType.VarChar, 250);
                param[3].Value = serviceGroupCode;
                param[4] = new SqlParameter("@Type", SqlDbType.VarChar, 5);
                param[4].Value = type;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proGetPatientReceiveForDoctor", param);
            }
            catch { return null; }
        }

        public static DataTable GetSuggestedServiceForDoctorDetail(string dateFrom, string dateTo, string employeeCode, string serviceGroupCode, string type)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@FromDate", SqlDbType.Char, 10);
                param[0].Value = dateFrom;
                param[1] = new SqlParameter("@ToDate", SqlDbType.Char, 10);
                param[1].Value = dateTo;
                param[2] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[2].Value = employeeCode;
                param[3] = new SqlParameter("@ServiceGroupCode", SqlDbType.VarChar, 50);
                param[3].Value = serviceGroupCode;
                param[4] = new SqlParameter("@Type", SqlDbType.VarChar, 5);
                param[4].Value = type;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proGetPatientReceiveForDoctorDetail", param);
            }
            catch { return null; }
        }

        public static DataTable GetPatientReceiveForDoctorPointed(string dateFrom, string dateTo, string employeeCode, string serviceGroup)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = @"select a.EmployeeCodeDoctor EmployeeCode,b.EmployeeName from SuggestedServiceReceipt a inner join Employee b on a.EmployeeCodeDoctor = b.EmployeeCode inner join [Service] a1 on a.ServiceCode=a1.ServiceCode inner join ServiceCategory a2 on a1.ServiceCategoryCode=a2.ServiceCategoryCode where CONVERT(date,a.WorkDate,103) >= CONVERT(date,'{0}',103) and CONVERT(date,a.WorkDate,103)<=CONVERT(date,'{1}',103) and a.Paid =1 and (a.BanksAccountCode<>'' or a.BanksAccountCode is null) ";
                if (!string.IsNullOrEmpty(employeeCode))
                    query += " and a.EmployeeCodeDoctor in('"+ employeeCode + "')";
                if (!string.IsNullOrEmpty(serviceGroup))
                    query += " and a2.ServiceGroupCode in(" + serviceGroup + ")";
                query += " group by a.EmployeeCodeDoctor,b.EmployeeName";
                return cn.ExecuteQuery(string.Format(query, dateFrom, dateTo));
            }
            catch { return null; }
        }

        public static DataTable GetSuggestedServiceForDoctorPointed(string dateFrom, string dateTo, string employeeCode, string serviceGroup)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = string.Empty;
                query = @" Select a.ReceiptID,b.PatientReceiveID,b.CreateDate PostingDate,e.PatientCode,e.PatientName,(case e.PatientGender when 0 then N'Nữ' else 'Nam' end) PatientGenderName, e.PatientBirthyear,c.ServiceCode,c.ServiceName,(a.Quantity*a.ServicePrice) ServicePrice,(a.Quantity*a.DiscountDoctor) DiscountAmount,(case when a.PerDiscountDoctor=0 then c1.PerDiscountDoctor else a.PerDiscountDoctor end) DiscountPer, ConfirmDiscountPointed as [Check],a.EmployeeCodeDoctor
                        from SuggestedServiceReceipt a inner join PatientReceive b on a.RefID=b.PatientReceiveID inner join [Service] c on a.ServiceCode=c.ServiceCode inner join ServiceCategory d on c.ServiceCategoryCode=d.ServiceCategoryCode inner join Patients e on b.PatientCode=e.PatientCode inner join ServicePrice c1 on a.RowIDPrice=c1.RowID
                        where CONVERT(date,a.WorkDate,103) between CONVERT(date,'{0}',103) and CONVERT(date,'{1}',103) and a.ServiceCode not in('DV000000') and a.Paid =1 ";
                if (!string.IsNullOrEmpty(employeeCode))
                    query += "and a.EmployeeCodeDoctor in('{2}')";
                if (!string.IsNullOrEmpty(serviceGroup))
                    query += " and d.ServiceGroupCode in({3})";
                return cn.ExecuteQuery(string.Format(query, dateFrom, dateTo, employeeCode, serviceGroup));
            }
            catch { return null; }
        }

        public static Int32 IUReportDiscount(ReportDiscountInf info, int status)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[14];
                param[0] = new SqlParameter("@ReceiptID", SqlDbType.Decimal);
                param[0].Value = info.ReceiptID;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = info.PatientReceiveID;
                param[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 15);
                param[2].Value = info.PatientCode;
                param[3] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 15);
                param[3].Value = info.ServiceCode;
                param[4] = new SqlParameter("@ServicePrice", SqlDbType.Decimal);
                param[4].Value = info.ServicePrice;
                param[5] = new SqlParameter("@ServicePriceOverTime", SqlDbType.Decimal);
                param[5].Value = info.ServicePriceOverTime;
                param[6] = new SqlParameter("@DiscountAmount", SqlDbType.Decimal);
                param[6].Value = info.DiscountAmount;
                param[7] = new SqlParameter("@DiscountPer", SqlDbType.Int);
                param[7].Value = info.DiscountPer;
                param[8] = new SqlParameter("@ReceiveDate", SqlDbType.DateTime);
                param[8].Value = info.ReceiveDate;
                param[9] = new SqlParameter("@IntroName", SqlDbType.NVarChar, 200);
                param[9].Value = info.IntroName;
                param[10] = new SqlParameter("@ShiftWork", SqlDbType.Char, 2);
                param[10].Value = info.ShiftWork;
                param[11] = new SqlParameter("@Status", SqlDbType.Int);
                param[11].Value = status;
                param[12] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 15);
                param[12].Value = info.EmployeeCode;
                param[13] = new SqlParameter("@Result", SqlDbType.SmallInt);
                param[13].Direction = ParameterDirection.Output;
                Int16 result = Convert.ToInt16(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proIUReportDiscount", param));
                if (result >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch
            {
                return -2;
            }
        }
    }
}
