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
    public class BanksAccountDal
    {
        public static List<Model_BanksAccountFinish> ListWaitingFinsh(string patientCode, string fullName, string age, string fromDate, string toDate)
        {
            ConnectDB cn = new ConnectDB();
            List<Model_BanksAccountFinish> list = new List<Model_BanksAccountFinish>();
            try
            {
                string sql = string.Empty;
                sql = @" select a.ReferenceCode,a.BanksAccountCode,a.BHYTPay,a.PatientPay,a.Exemptions,a.TotalReal,a.Description,a.PostingDate,a.PatientCode,b.PatientName,a.Cancel,a.ObjectCode,c.ObjectName,d.EmployeeName,a.RateExemptions,a.RateSurcharge,a.TotalSurcharge,a.IntroCode,a.Serial,a.TotalAmount,a.CashierCode,a1.Status, 0 as Printer,a.NoInvoice,a.EmployeeCode,replicate('0', 5 - len(a.Serial)) + cast (a.Serial as varchar) as SerialNumber,a.TotalBHYTPay,a.TotalPatientPay
                        from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode inner join Object c on a.ObjectCode=c.ObjectCode inner join Employee d on a.EmployeeCode=d.EmployeeCode inner join PatientReceive a1 on a.ReferenceCode=a1.PatientReceiveID
                        where a.Cancel=0 ";
                if (!string.IsNullOrEmpty(patientCode))
                    sql += " and a.PatientCode like'%" + patientCode + "%'";
                if (!string.IsNullOrEmpty(fullName))
                    sql += " and b.PatientName like N'%" + fullName + "%'";
                if (!string.IsNullOrEmpty(age))
                    sql += " and (b.PatientAge in(" + age + ") or b.PatientBirthyear in(" + age + "))";
                if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
                    sql += " and convert(date,a.PostingDate,103) between CONVERT(date,'" + fromDate + "',103) and CONVERT(date,'" + toDate + "',103) ";
                sql += " and a.Report in(1)";
                sql += " order by a.Serial desc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    Model_BanksAccountFinish inf = new Model_BanksAccountFinish();
                    inf.ReferenceCode = ireader.GetDecimal(0);
                    inf.BanksAccountCode = ireader.GetValue(1).ToString();
                    inf.BHYTPay = ireader.GetDecimal(2);
                    inf.PatientPay = ireader.GetDecimal(3);
                    inf.Exemptions = ireader.GetDecimal(4);
                    inf.TotalReal = ireader.GetDecimal(5);
                    inf.Description = ireader.GetValue(6).ToString();
                    inf.PostingDate = ireader.GetDateTime(7);
                    inf.PatientCode = ireader.GetString(8);
                    inf.PatientName = ireader.GetValue(9).ToString();
                    inf.Cancel = ireader.GetInt32(10);
                    inf.ObjectCode = ireader.GetInt32(11);
                    inf.ObjectName = ireader.GetValue(12).ToString();
                    inf.EmployeeName = ireader.GetValue(13).ToString();
                    inf.RateExemptions = ireader.GetDecimal(14);
                    inf.RateSurcharge = ireader.GetDecimal(15);
                    inf.TotalSurcharge = ireader.GetDecimal(16);
                    inf.IntroCode = ireader.GetValue(17).ToString();
                    inf.Serial = ireader.GetInt32(18);
                    inf.TotalAmount = ireader.GetDecimal(19);
                    inf.CashierCode = ireader.GetValue(20).ToString();
                    inf.StatusReceive = ireader.GetInt32(21);
                    inf.Printer = ireader.GetInt32(22);
                    inf.NoInvoice = ireader.GetValue(23).ToString();
                    inf.EmployeeCode = ireader.GetValue(24).ToString();
                    inf.SerialNumber = ireader.GetValue(25).ToString();
                    inf.TotalBHYTPay = ireader.GetDecimal(26);
                    inf.TotalPatientPay = ireader.GetDecimal(27);
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
        
        public static bool InsBanksAccount(BanksAccountInf info,ref string refMsgError)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[22];
                param[0] = new SqlParameter("@BanksAccountCode", SqlDbType.VarChar, 50);
                param[0].Value = info.BanksAccountCode;
                param[1] = new SqlParameter("@ReferenceCode", SqlDbType.Decimal);
                param[1].Value = info.ReferenceCode;
                param[2] = new SqlParameter("@BHYTPay", SqlDbType.Decimal);
                param[2].Value = info.BHYTPay;
                param[3] = new SqlParameter("@PatientPay", SqlDbType.Decimal);
                param[3].Value = info.PatientPay;
                param[4] = new SqlParameter("@Exemptions", SqlDbType.Decimal);
                param[4].Value = info.Exemptions;
                param[5] = new SqlParameter("@TotalAmount", SqlDbType.Decimal);
                param[5].Value = info.TotalAmount;
                param[6] = new SqlParameter("@Description", SqlDbType.NVarChar, 500);
                param[6].Value = info.Description;
                param[7] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[7].Value = info.EmployeeCode;
                param[8] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[8].Value = info.PatientCode;
                param[9] = new SqlParameter("@Cancel", SqlDbType.Int);
                param[9].Value = info.Cancel;
                param[10] = new SqlParameter("@PatientType", SqlDbType.Int);
                param[10].Value = info.PatientType;
                param[11] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[11].Value = info.ObjectCode;
                param[12] = new SqlParameter("@TotalReal", SqlDbType.Decimal);
                param[12].Value = info.TotalReal;
                param[13] = new SqlParameter("@RateExemptions", SqlDbType.Decimal);
                param[13].Value = info.RateExemptions;
                param[14] = new SqlParameter("@RateSurcharge", SqlDbType.Decimal);
                param[14].Value = info.RateSurcharge;
                param[15] = new SqlParameter("@TotalSurcharge", SqlDbType.Decimal);
                param[15].Value = info.TotalSurcharge;
                param[16] = new SqlParameter("@IntroCode", SqlDbType.VarChar, 10);
                param[16].Value = info.IntroCode;
                param[17] = new SqlParameter("@Serial", SqlDbType.Int);
                param[17].Value = info.Serial;
                param[18] = new SqlParameter("@CashierCode", SqlDbType.VarChar, 50);
                param[18].Value = info.CashierCode;
                param[19] = new SqlParameter("@ShiftWork", SqlDbType.Char, 2);
                param[19].Value = info.ShiftWork;
                param[20] = new SqlParameter("@TotalBHYTPay", SqlDbType.Decimal);
                param[20].Value = info.TotalBHYTPay;
                param[21] = new SqlParameter("@TotalPatientPay", SqlDbType.Decimal);
                param[21].Value = info.TotalPatientPay;
                //param[22] = new SqlParameter("@ResultBanksCode", SqlDbType.VarChar, 50);
                //param[22].Direction = ParameterDirection.Output;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_BanksAccount", param) > 0 ? true : false;
            }
            catch(Exception ex)  {
                refMsgError = ex.Message;
                return false;
            }
        }

        public static Int32 DelBanksAccount(string sBanksCode, string sPatientCode, decimal dReceiveID, string shiftWork, string employeeCode, string reason)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@BanksAccountCode", SqlDbType.VarChar, 50);
                param[0].Value = sBanksCode;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = sPatientCode;
                param[2] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[2].Value = dReceiveID;
                param[3] = new SqlParameter("@ShiftWork", SqlDbType.Char, 2);
                param[3].Value = shiftWork;
                param[4] = new SqlParameter("@EmployeeCodeCancel", SqlDbType.VarChar, 20);
                param[4].Value = employeeCode;
                param[5] = new SqlParameter("@ReasonCancel", SqlDbType.NVarChar, 250);
                param[5].Value = reason;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_BanksAccount", param);
            }
            catch { return -1; }
        }

        public static Int32 UpdBanksAccountInvoice(BanksAccountInvoiceInf inf)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "update BanksAccount set NoInvoice=@NoInvoice,Invoice_MauSo=@Invoice_MauSo,Invoice_KyHieu=@Invoice_KyHieu,Invoice_HoTenKH=@Invoice_HoTenKH,Invoice_DiaChi=@Invoice_DiaChi,Invoice_MaSoThue=@Invoice_MaSoThue,Invoice_DienThoai=@Invoice_DienThoai,Invoice_HTThanhToan=@Invoice_HTThanhToan,Invoice_VAT=@Invoice_VAT,Invoice_EmployeeCode=@Invoice_EmployeeCode,Invoice_DonVi=@Invoice_DonVi where PatientCode =@PatientCode and ReferenceCode=@ReferenceCode";
                SqlParameter[] param = new SqlParameter[13];
                param[0] = new SqlParameter("@NoInvoice", SqlDbType.VarChar);
                param[0].Value = inf.NoInvoice;
                param[1] = new SqlParameter("@Invoice_MauSo", SqlDbType.VarChar);
                param[1].Value = inf.Invoice_MauSo;
                param[2] = new SqlParameter("@Invoice_KyHieu", SqlDbType.VarChar);
                param[2].Value = inf.Invoice_KyHieu;
                param[3] = new SqlParameter("@Invoice_HoTenKH", SqlDbType.NVarChar);
                param[3].Value = inf.Invoice_HoTenKH;
                param[4] = new SqlParameter("@Invoice_DiaChi", SqlDbType.NVarChar);
                param[4].Value = inf.Invoice_DiaChi;
                param[5] = new SqlParameter("@Invoice_MaSoThue", SqlDbType.VarChar);
                param[5].Value = inf.Invoice_MaSoThue;
                param[6] = new SqlParameter("@Invoice_DienThoai", SqlDbType.NVarChar);
                param[6].Value = inf.Invoice_DienThoai;
                param[7] = new SqlParameter("@Invoice_HTThanhToan", SqlDbType.NVarChar);
                param[7].Value = inf.Invoice_HTThanhToan;
                param[8] = new SqlParameter("@Invoice_VAT", SqlDbType.Int);
                param[8].Value = inf.Invoice_VAT;
                param[9] = new SqlParameter("@Invoice_EmployeeCode", SqlDbType.VarChar);
                param[9].Value = inf.Invoice_EmployeeCode;
                param[10] = new SqlParameter("@Invoice_DonVi", SqlDbType.NVarChar);
                param[10].Value = inf.Invoice_DonVi;
                param[11] = new SqlParameter("@PatientCode", SqlDbType.VarChar);
                param[11].Value = inf.PatientCode;
                param[12] = new SqlParameter("@ReferenceCode", SqlDbType.Decimal);
                param[12].Value = inf.PatientReceiveID;
                return cn.ExecuteNonQuery(CommandType.Text, query, param);
            }
            catch { return -1; }
        }
        
        public static BanksAccountInf ListBankAccountForCode(string banksAccountCode)
        {
            ConnectDB cn = new ConnectDB();
            BanksAccountInf inf = new BanksAccountInf();
            try
            {
                string sql = " select BanksAccountCode,ReferenceCode,BHYTPay,PatientPay,Exemptions,TotalAmount,Description,PostingDate,PatientCode,Cancel,ObjectCode,TotalReal,RateExemptions,RateSurcharge,TotalSurcharge from BanksAccount where BanksAccountCode='{0}' ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, banksAccountCode), null);
                if (ireader.Read())
                {
                    inf.BanksAccountCode = ireader.GetString(0);
                    inf.ReferenceCode = ireader.GetDecimal(1);
                    inf.BHYTPay = ireader.GetDecimal(2);
                    inf.PatientPay = ireader.GetDecimal(3);
                    inf.Exemptions = ireader.GetDecimal(4);
                    inf.TotalAmount = ireader.GetDecimal(5);
                    inf.Description = ireader.GetString(6);
                    inf.PostingDate = ireader.GetDateTime(7);
                    inf.PatientCode = ireader.GetString(8);
                    inf.Cancel = ireader.GetInt32(9);
                    inf.ObjectCode = ireader.GetInt32(10);
                    inf.TotalReal = ireader.GetDecimal(11);
                    inf.RateExemptions = ireader.GetDecimal(12);
                    inf.RateSurcharge = ireader.GetDecimal(13);
                    inf.TotalSurcharge = ireader.GetDecimal(14);
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
        
        public static DataTable TableStatisticBankTotal(string fromDate, string toDate, string serviceGroupCode, string serviceCategoryCode, string serviceCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                /// Lay thuoc ban le vao bao cao
//                sql += @" union all select a.PatientCode,a.PatientReceiveID ReferenceCode,CONVERT(date,a.ExportDate,103) PostingDate,ISNULL(SUM(a1.Amount),0) Amount,b.PatientName,
//    b.PatientBirthyear,b.PatientBirthday,b.PatientAddress, (case when b.PatientGender=0 then N'Nữ' else 'Nam' end ) PatientGenderName,a5.ServiceModuleName GroupName,a5.ServiceModuleCode
//    from MedicinesRetail a inner join Patients b on a.PatientCode=b.PatientCode inner join MedicinesRetailDetail a1 on a.RetailCode=a1.RetailCode
//    inner join Items a2 on a1.ItemCode=a2.ItemCode inner join ItemCategory a3 on a2.ItemCategoryCode=a3.ItemCategoryCode
//    inner join ItemGroup a4 on a3.GroupCode=a4.GroupCode inner join ServiceModule a5 on a4.ServiceModuleCode=a5.ServiceModuleCode
//    where a.Paid in(1,2)  and convert(date,a.ExportDate,103) between convert(date,'{0}',103) and convert(date,'{1}',103) ";
//                if (!string.IsNullOrEmpty(serviceGroupCode))
//                    sql += " and a4.ServiceModuleCode in({2}) ";
//                if (!string.IsNullOrEmpty(serviceCategoryCode))
//                    sql += " and a2.ItemCategoryCode in({3}) ";
//                if (!string.IsNullOrEmpty(introCode))
//                    sql += " and a1.IntroCode in('{4}')";
//                sql += "group by a.PatientCode,a.PatientReceiveID,a.ExportDate,b.PatientName,b.PatientBirthyear,b.PatientBirthday,b.PatientAddress,b.PatientGender,a5.ServiceModuleName,a5.ServiceModuleCode order by PatientCode ";
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@FromDate", SqlDbType.Date);
                param[0].Value = fromDate;
                param[1] = new SqlParameter("@ToDate", SqlDbType.Date);
                param[1].Value = toDate;
                param[2] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 300);
                param[2].Value = serviceCategoryCode;
                param[3] = new SqlParameter("@ServiceGroupCode", SqlDbType.VarChar, 15);
                param[3].Value = serviceGroupCode;
                param[4] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 1000);
                param[4].Value = serviceCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proView_StatisticBankTotal", param);
            }
            catch { return null; }
        }
        
        public static DataTable TableStatisticBankDetail(string fromDate, string toDate, string serviceGroupCode, string serviceCategoryCode, string employeeCode, string serviceCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@FromDate", SqlDbType.Date);
                param[0].Value = fromDate;
                param[1] = new SqlParameter("@ToDate", SqlDbType.Date);
                param[1].Value = toDate;
                param[2] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 300);
                param[2].Value = serviceCategoryCode;
                param[3] = new SqlParameter("@ServiceGroupCode", SqlDbType.VarChar, 15);
                param[3].Value = serviceGroupCode;
                param[4] = new SqlParameter("@ServiceCode", SqlDbType.VarChar);
                param[4].Value = serviceCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proView_StatisticBankDetail", param);
            }
            catch { return null; }
        }

        public static DataTable TableWaitingForDate(string fromDate, string toDate)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable("Waiting");
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@DateFrom", SqlDbType.Char);
                param[0].Value = fromDate;//"2017-04-21 00:00:00.000";// 
                param[1] = new SqlParameter("@DateTo", SqlDbType.Char);
                param[1].Value = toDate;// "2017-04-21 23:59:59.999"; //
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "proWaitingForPayMent", param);
                dtResult.Columns.Add(new DataColumn("PatientReceiveID", typeof(decimal)));
                dtResult.Columns.Add(new DataColumn("PatientCode", typeof(string)));
                dtResult.Columns.Add(new DataColumn("PatientName", typeof(string)));
                dtResult.Columns.Add(new DataColumn("GenderName", typeof(string)));
                dtResult.Columns.Add(new DataColumn("PatientBirthyear", typeof(Int32)));
                dtResult.Columns.Add(new DataColumn("ObjectName", typeof(string)));
                dtResult.Columns.Add(new DataColumn("CreateDate", typeof(DateTime)));
                #region Lấy theo kiểu Datetime
                //string fromdate = "'" + fromDate.ToString("yyyy-MM-dd") + " 00:00:00.000'";
                //string todate = "'" + toDate.ToString("yyyy-MM-dd") + " 23:59:59.000'";
                //string sql = @"select b.PatientReceiveID,b.PatientCode,a.PatientName,(case when a.PatientGender=0 then N'Nữ' else 'Nam' end) GenderName,a.PatientBirthyear,c.ObjectName,b.CreateDate
                //from  Patients a  inner join  
                //		(select a.PatientReceiveID,a.PatientCode,a.ObjectCode,a.CreateDate
                //		from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID 
                //		where b.Paid=0 and (b.BanksAccountCode is null or b.BanksAccountCode='') and b.ServicePrice>0 and b.ObjectCode <>5 
                //					--group by a.PatientReceiveID,a.PatientCode,a.ObjectCode,convert(Date,a.CreateDate,103)
                //	union
                //		select a.PatientReceiveID,a.PatientCode,a.ObjectCode,a.CreateDate
                //		from PatientReceive a inner join RealMedicinesForPatients b on a.PatientReceiveID=b.PatientReceiveID inner join RealMedicinesForPatientsDetail b1 on b.RowID=b1.RealRowID
                //		where b1.Paid=0 and (b1.BanksAccountCode is null or b1.BanksAccountCode='' ) and b1.ObjectCode <>5 
                //	union
                //		select a.PatientReceiveID,a.PatientCode,a.ObjectCode,a.CreateDate 
                //		from PatientReceive a inner join MedicinesForPatients b on a.PatientReceiveID=b.PatientReceiveID inner join MedicinesForPatientsDetail b1 on b.RowID=b1.RowIDMedicines
                //		where b1.Paid=0 and (b1.BanksAccountCode is null or b1.BanksAccountCode='') and b1.ObjectCode <>5 
                //	) b 
                //	on a.PatientCode = b.PatientCode inner join  Object c on b.ObjectCode=c.ObjectCode
                //	where  b.CreateDate between {0} and {1} --'2017-04-21 00:00:00.000' and '2017-04-21 23:59:59.000'";

                ////string sql = @"select b.PatientReceiveID,b.PatientCode,a.PatientName,(case when a.PatientGender=0 then N'Nữ' else 'Nam' end) GenderName,a.PatientBirthyear,c.ObjectName,b.CreateDate
                ////from Patients a inner join (
                ////			select a.PatientReceiveID,a.PatientCode,a.ObjectCode,a.CreateDate
                ////				from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID 
                ////				where  a.CreateDate between {0} and {1} and b.Paid=0 and (b.BanksAccountCode is null or b.BanksAccountCode='') and b.ServicePrice>0 and b.ObjectCode <>5 
                ////				group by a.PatientReceiveID,a.PatientCode,a.ObjectCode,a.CreateDate
                ////				)
                //// b on a.PatientCode=b.PatientCode inner join Object c on b.ObjectCode=c.ObjectCode

                ////union
                ////select b.PatientReceiveID,b.PatientCode,a.PatientName,(case when a.PatientGender=0 then N'Nữ' else 'Nam' end) GenderName,a.PatientBirthyear,c.ObjectName,b.CreateDate
                ////from Patients a inner join (
                ////select a.PatientReceiveID,a.PatientCode,a.ObjectCode,a.CreateDate
                ////from PatientReceive a inner join RealMedicinesForPatients b on a.PatientReceiveID=b.PatientReceiveID inner join RealMedicinesForPatientsDetail b1 on b.RowID=b1.RealRowID
                ////where  a.CreateDate between {0} and {1} and b1.Paid=0 and (b1.BanksAccountCode is null or b1.BanksAccountCode='' ) and b1.ObjectCode <>5 
                ////group by a.PatientReceiveID,a.PatientCode,a.ObjectCode,a.CreateDate) b on a.PatientCode=b.PatientCode inner join Object c on b.ObjectCode=c.ObjectCode

                ////union
                ////select b.PatientReceiveID,b.PatientCode,a.PatientName,(case when a.PatientGender=0 then N'Nữ' else 'Nam' end) GenderName,a.PatientBirthyear,c.ObjectName,b.CreateDate
                ////from Patients a inner join (
                ////select a.PatientReceiveID,a.PatientCode,a.ObjectCode,a.CreateDate
                ////from PatientReceive a inner join MedicinesForPatients b on a.PatientReceiveID=b.PatientReceiveID inner join MedicinesForPatientsDetail b1 on b.RowID=b1.RowIDMedicines
                ////where b1.Paid=0 and (b1.BanksAccountCode is null or b1.BanksAccountCode='') and b1.ObjectCode <>5 and  a.CreateDate between {0} and {1}
                ////group by a.PatientReceiveID,a.PatientCode,a.ObjectCode,a.CreateDate
                ////) b on a.PatientCode=b.PatientCode inner join Object c on b.ObjectCode=c.ObjectCode";
                //dtResult = cn.ExecuteQuery(string.Format(sql, fromdate, todate));
                #endregion lấy dữ liệu theo Datetime
                //while (fromDate>toDate)
                //{

                //}
                //string sql = @"select b.PatientReceiveID,b.PatientCode,a.PatientName,(case when a.PatientGender=0 then N'Nữ' else 'Nam' end) GenderName,a.PatientBirthyear,c.ObjectName,b.CreateDate
                //from  Patients a  inner join  
                //		(select a.PatientReceiveID,a.PatientCode,a.ObjectCode,convert(char,a.CreateDate,103) as  CreateDate
                //		from PatientReceive a inner join SuggestedServiceReceipt b on a.PatientReceiveID=b.RefID 
                //		where b.Paid=0 and (b.BanksAccountCode is null or b.BanksAccountCode='') and b.ServicePrice>0 and b.ObjectCode <>5 
                //					--group by a.PatientReceiveID,a.PatientCode,a.ObjectCode,convert(Date,a.CreateDate,103)
                //	union
                //		select a.PatientReceiveID,a.PatientCode,a.ObjectCode,convert(char,a.CreateDate,103) as  CreateDate
                //		from PatientReceive a inner join RealMedicinesForPatients b on a.PatientReceiveID=b.PatientReceiveID inner join RealMedicinesForPatientsDetail b1 on b.RowID=b1.RealRowID
                //		where b1.Paid=0 and (b1.BanksAccountCode is null or b1.BanksAccountCode='' ) and b1.ObjectCode <>5 
                //	union
                //		select a.PatientReceiveID,a.PatientCode,a.ObjectCode, convert(char,a.CreateDate,103) as  CreateDate
                //		from PatientReceive a inner join MedicinesForPatients b on a.PatientReceiveID=b.PatientReceiveID inner join MedicinesForPatientsDetail b1 on b.RowID=b1.RowIDMedicines
                //		where b1.Paid=0 and (b1.BanksAccountCode is null or b1.BanksAccountCode='') and b1.ObjectCode <>5 
                //	) b 
                //	on a.PatientCode = b.PatientCode inner join  Object c on b.ObjectCode=c.ObjectCode
                //	where b.CreateDate in ({0})";
                //dtResult = cn.ExecuteQuery(string.Format(sql, fromdate
                #region Lấy dữ liệu theo kiểu char where in


                #endregion

            }
            catch (Exception ex) { }
            return dtResult;
        }

        public static DataTable TableWaitingForDateBN(string sfrom, string sto)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable("Waiting");
            try
            {
                dt.Columns.Add(new DataColumn("PatientReceiveID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("PatientCode", typeof(string)));
                dt.Columns.Add(new DataColumn("PatientName", typeof(string)));
                dt.Columns.Add(new DataColumn("GenderName", typeof(string)));
                dt.Columns.Add(new DataColumn("PatientBirthyear", typeof(Int32)));
                dt.Columns.Add(new DataColumn("ObjectName", typeof(string)));
                dt.Columns.Add(new DataColumn("CreateDate", typeof(DateTime)));
                string sql = @" select  a.PatientReceiveID,a.PatientCode,b.PatientName,(case when b.PatientGender=0 then N'Nữ' else N'Nam' end) GenderName,
                b.PatientBirthyear,c.ObjectName,convert(date,a.CreateDate,103) CreateDate
                from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode
                inner join Object c on a.ObjectCode=c.ObjectCode inner join SuggestedServiceReceipt d on a.PatientReceiveID=d.RefID
                where CONVERT(date,a.CreateDate,103) between CONVERT(date,'{0}',103) and  CONVERT(date,'{1}',103)
                group by a.PatientCode,b.PatientName,b.PatientBirthyear,c.ObjectName,convert(date,a.CreateDate,103),b.PatientGender,a.PatientReceiveID
                order by CONVERT(date,a.CreateDate,103) desc ";
                dt = cn.ExecuteQuery(string.Format(sql, sfrom, sto));
            }
            catch { }
            return dt;
        }
        
        public static DataTable GetDataBanksAccountDetailHis(string banksAccountCode, int loai)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtbResult = new DataTable("Waiting");
            try
            {
                SqlParameter[] sqlParameter = new SqlParameter[2];
                sqlParameter[0] = new SqlParameter("@BanksAccountCode", SqlDbType.VarChar, 50);
                sqlParameter[0].Value = banksAccountCode;
                sqlParameter[1] = new SqlParameter("@loai", SqlDbType.Int);
                sqlParameter[1].Value = loai;
                dtbResult = cn.CallProcedureTable(CommandType.StoredProcedure, "proGetBanksAccountDetailHis", sqlParameter);
            }
            catch { }
            return dtbResult;
        }
        public static bool IsUpdateBanksAccountHideReport(string banksAccountCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "update BanksAccount set Report=-1 where BanksAccountCode in({0})";
                int result = Convert.ToInt32(cn.ExecuteNonQuery(CommandType.Text, string.Format(query, banksAccountCode), null));
                return result >= 1 ? true : false;
            }
            catch { return false; }
        }
        
        public static bool IsUpdateBanksAccountUnhideReport(string banksAccountCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "update BanksAccount set Report=1 where BanksAccountCode in({0})";
                int result = Convert.ToInt32(cn.ExecuteNonQuery(CommandType.Text, string.Format(query, banksAccountCode), null));
                return result >= 1 ? true : false;
            }
            catch { return false; }
        }
        
        public static DataTable TableWaitingForDateBV01(string sfrom, string sto, int confirmBV01, int objectCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tbResult = new DataTable("Waiting");
            try
            {
                tbResult.Columns.Add(new DataColumn("PatientCode", typeof(string)));
                tbResult.Columns.Add(new DataColumn("PatientName", typeof(string)));
                tbResult.Columns.Add(new DataColumn("GenderName", typeof(string)));
                tbResult.Columns.Add(new DataColumn("PatientBirthyear", typeof(Int32)));
                tbResult.Columns.Add(new DataColumn("ObjectName", typeof(string)));
                tbResult.Columns.Add(new DataColumn("CreateDate", typeof(DateTime)));
                string sql = @" select a.PatientCode,b.PatientName,(case when b.PatientGender=0 then N'Nữ' else N'Nam' end) GenderName,
                        b.PatientBirthyear,c.ObjectName,convert(date,a.CreateDate,103) CreateDate
                        from PatientReceive a inner join Patients b on a.PatientCode=b.PatientCode inner join Object c on a.ObjectCode=c.ObjectCode 
                        where CONVERT(date,a.CreateDate,103) between CONVERT(date,'{0}',103) and  CONVERT(date,'{1}',103)  and a.ConfirmBV01 in({2}) and a.ObjectCode in({3})
                        group by a.PatientCode,b.PatientName,b.PatientBirthyear,c.ObjectName,convert(date,a.CreateDate,103),b.PatientGender
                        order by CONVERT(date,a.CreateDate,103) desc ";
                tbResult = cn.ExecuteQuery(string.Format(sql, sfrom, sto, confirmBV01, objectCode));
            }
            catch { }
            return tbResult;
        }

        public static Int32 UpdBanksAccountPrinter(string banksAccountCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "update BanksAccount set Printer=Printer+1 where BanksAccountCode='{0}'";
                return cn.ExecuteNonQuery(CommandType.Text, string.Format(query, banksAccountCode), null);
            }
            catch { return -1; }
        }
        public static BanksAccountInvoiceInf ObjBanksAccountInvoice(decimal patientReceiveID, string patientCode, string noinvoice)
        {
            ConnectDB cn = new ConnectDB();
            BanksAccountInvoiceInf inf = new BanksAccountInvoiceInf();
            try
            {
                string sql = "select Invoice_MauSo,Invoice_KyHieu,Invoice_HoTenKH,Invoice_DiaChi,Invoice_MaSoThue,Invoice_DienThoai,Invoice_HTThanhToan,Invoice_VAT,Invoice_EmployeeCode,ReferenceCode,PatientCode,NoInvoice,Invoice_DonVi from BanksAccount where ReferenceCode={0} and PatientCode='{1}' ";
                if (!string.IsNullOrEmpty(noinvoice))
                    sql += " and NoInvoice='{2}'";
                sql += " group by Invoice_MauSo,Invoice_KyHieu,Invoice_HoTenKH,Invoice_DiaChi,Invoice_MaSoThue,Invoice_DienThoai,Invoice_HTThanhToan,Invoice_VAT,Invoice_EmployeeCode,ReferenceCode,PatientCode,NoInvoice,Invoice_DonVi ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, patientReceiveID, patientCode, noinvoice), null);
                if (ireader.Read())
                {
                    inf.Invoice_MauSo = ireader.GetValue(0).ToString();
                    inf.Invoice_KyHieu = ireader.GetValue(1).ToString();
                    inf.Invoice_HoTenKH = ireader.GetValue(2).ToString();
                    inf.Invoice_DiaChi = ireader.GetValue(3).ToString();
                    inf.Invoice_MaSoThue = ireader.GetValue(4).ToString();
                    inf.Invoice_DienThoai = ireader.GetValue(5).ToString();
                    inf.Invoice_HTThanhToan = ireader.GetValue(6).ToString();
                    inf.Invoice_VAT = Convert.ToInt32(ireader.GetValue(7).ToString());
                    inf.Invoice_EmployeeCode = ireader.GetValue(8).ToString();
                    inf.PatientReceiveID = ireader.GetDecimal(9);
                    inf.PatientCode = ireader.GetValue(10).ToString();
                    inf.NoInvoice = ireader.GetValue(11).ToString();
                    inf.Invoice_DonVi = ireader.GetValue(12).ToString();
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
    }
}
