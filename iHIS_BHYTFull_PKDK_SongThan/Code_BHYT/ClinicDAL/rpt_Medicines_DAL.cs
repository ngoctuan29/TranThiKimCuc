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
    public class rpt_Medicines_DAL
    {
        public static DataTable DT_View_XNT_General(string refRepositoryCode, string dtFrom, string dtTo, string itemCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 15);
                param[0].Value = refRepositoryCode;
                param[1] = new SqlParameter("@FromDate", SqlDbType.Char, 10);
                param[1].Value = dtFrom;
                param[2] = new SqlParameter("@ToDate", SqlDbType.Char, 10);
                param[2].Value = dtTo;
                param[3] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 15);
                param[3].Value = itemCode;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "proReport_ImpExp_General", param);
                return dtResult;
            }
            catch (Exception) { return null; }
        }

        public static DataTable DT_View_XNT_GeneralDetail(string refRepositoryCode, string dtFrom, string dtTo, string itemCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 15);
                param[0].Value = refRepositoryCode;
                param[1] = new SqlParameter("@FromDate", SqlDbType.Char, 10);
                param[1].Value = dtFrom;
                param[2] = new SqlParameter("@ToDate", SqlDbType.Char, 10);
                param[2].Value = dtTo;
                param[3] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 15);
                param[3].Value = itemCode;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "proReport_ImpExp_GeneralDetail", param);
                return dtResult;
            }
            catch { return null; }
        }
        public static DataTable DT_View_DateEnd(string refRepositoryCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[0].Value = refRepositoryCode;
                //param[1] = new SqlParameter("@FromDate", SqlDbType.Date);
                //param[1].Value = dtFrom;
                //param[2] = new SqlParameter("@ToDate", SqlDbType.Date);
                //param[2].Value = dtTo;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_Report_View_DateEnd", param);
                return dtResult;
            }
            catch { return null; }
        }
                
        public static DataTable DT_View_TKeBanThuoc(string sFrom, string sTo, Int32 iPaid)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                //string sql = @" 
                //            select a.RetailCode,a.IDate,a.FullName,a.Birthyear,a.Address,a.Diagnosis,a.NumberOfDrugCoal,a.SerialNumber,a.InvoiceNumber,a.ExportDate,
                //            a.TotalAmount,a.TotalAmountReal,a.RateOther,a.RateUSD,a.RateSurcharge,a.TotalSurcharge,a.Cash,a.ExcessCash,a.VoucherCard,a.OtherCard,a.ExcessCashOther,a1.IntroName
                //            from MedicinesRetail a left join Introducer a1 on a.IntroCode=a1.IntroCode
                //            where convert(date,a.ExportDate,103) between convert(date,'{0}',103) and convert(date,'{1}',103) and a.Paid in({2})
                //        ";

                string sql = @"	  select a.RetailCode ,a.IDate,a.FullName,a.Address,a.Birthyear,
                                 a.TotalAmount,a.TotalAmountReal, '0.00' as TotalSurcharge, N'Xuất bán lẻ' as RepositoryName
                                    from MedicinesRetail a left join Introducer a1 on a.IntroCode=a1.IntroCode
                                    where convert(date,a.ExportDate,103) between convert(date,'{0}',103) and convert(date,'{1}',103) and a.Paid in({2})
							   union all
							    select distinct b.MedicalRecordCode as RetailCode ,convert(date,d.PostingDate,103), c.PatientName, c.PatientAddress, Convert(varchar, c.PatientBirthyear),
							    sum(lst1.Quantity*lst1.ServicePrice+lst1.Quantity*lst1.DisparityPrice ) as TotalAmount, sum(lst1.PatientPay +lst1.Quantity*lst1.DisparityPrice) as TotalAmountReal ,sum(lst1.Quantity*lst1.DisparityPrice) as TotalSurcharge,f.RepositoryName
							    from MedicinesForPatients a inner join MedicinesForPatientsDetail b on a.MedicalRecordCode = b.MedicalRecordCode
                                inner join RepositoryCatalog f on f.RepositoryCode = b.RepositoryCode 
							    inner join Patients c on a.PatientCode = c.PatientCode
							    inner join MedicalRecord d on d.PatientReceiveID = a.PatientReceiveID 
							    inner join 
								    (	select b.* from BanksAccount a inner join BanksAccountDetail b on a.BanksAccountCode = b.BanksAccountCode 
							     where a.BanksAccountCode in
											( select distinct b.BanksAccountCode 
											 from MedicinesForPatients a inner join  MedicinesForPatientsDetail b on a.MedicalRecordCode = b.MedicalRecordCode
												where convert(date,a.DateApproved,103) between convert(date,'{0}',103) and convert(date,'{1}',103) and b.Paid in({2}))
								) lst1 on lst1.BanksAccountCode =b.BanksAccountCode and b.ItemCode = lst1.ServiceCode
							group by b.MedicalRecordCode,d.PostingDate, c.PatientName,c.PatientBirthyear, c.PatientAddress, f.RepositoryName
                          
";
                dtResult = cn.CallProcedureTable(CommandType.Text, string.Format(sql, sFrom, sTo, iPaid), null);
                return dtResult;
            }
            catch { return null; }
        }

        public static DataTable DT_View_TKeBanThuocTH(string sFrom, string sTo, Int32 iPaid)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                //string sql = @" 
                //            select CONVERT(date,a.ExportDate,103) ExportDate,sum(a.TotalAmount) TotalAmount,sum(a.TotalAmountReal) TotalAmountReal,SUM(a.TotalSurcharge) TotalSurcharge,sum(a.Cash)Cash,
                //            sum(a.ExcessCash)ExcessCash,sum(a.ExcessCashOther)ExcessCashOther
                //            from MedicinesRetail a left join Introducer a1 on a.IntroCode=a1.IntroCode
                //            where convert(date,a.ExportDate,103) between convert(date,'{0}',103) and convert(date,'{1}',103) and a.Paid in({2}) group by CONVERT(date,a.ExportDate,103)
                //        ";
                string sql = @" select CONVERT(date, lst2.IDate,103) ExportDate, sum(lst2.TotalAmount) TotalAmount, sum(lst2.TotalAmountReal) TotalAmountReal,sum (lst2.TotalSurcharge) TotalSurcharge from
                            ( select a.IDate,
                            a.TotalAmount,a.TotalAmountReal, '0.00' as TotalSurcharge
                            from MedicinesRetail a left join Introducer a1 on a.IntroCode=a1.IntroCode
                            where convert(date,a.ExportDate,103) between convert(date,'{0}',103) and convert(date,'{1}',103) and a.Paid in({2})
							union all
							select convert(date,d.PostingDate,103), 
							sum(lst1.Quantity*lst1.ServicePrice+lst1.Quantity*lst1.DisparityPrice ) as TotalAmount, sum(lst1.PatientPay +lst1.Quantity*lst1.DisparityPrice) as TotalAmountReal ,sum(lst1.Quantity*lst1.DisparityPrice) as TotalSurcharge
							from MedicinesForPatients a inner join MedicinesForPatientsDetail b on a.MedicalRecordCode = b.MedicalRecordCode
							inner join Patients c on a.PatientCode = c.PatientCode
							inner join MedicalRecord d on d.PatientReceiveID = a.PatientReceiveID 
							inner join 
								(	select b.* from BanksAccount a inner join BanksAccountDetail b on a.BanksAccountCode = b.BanksAccountCode 
							 where a.BanksAccountCode in
											( select distinct b.BanksAccountCode 
											 from MedicinesForPatients a inner join  MedicinesForPatientsDetail b on a.MedicalRecordCode = b.MedicalRecordCode
												where convert(date,a.DateApproved,103) between convert(date,'{0}',103) and convert(date,'{1}',103) and b.Paid in({2}))
								) lst1 on lst1.BanksAccountCode =b.BanksAccountCode and b.ItemCode = lst1.ServiceCode
							group by b.MedicalRecordCode,d.PostingDate, c.PatientName,c.PatientBirthyear, c.PatientAddress
  ) lst2 
							group by lst2.IDate
";
                dtResult = cn.CallProcedureTable(CommandType.Text, string.Format(sql, sFrom, sTo, iPaid), null);
                return dtResult;
            }
            catch { return null; }
        }

        public static DataTable DT_View_TKeBanThuocTHMonth(string sFrom, string sTo, Int32 iPaid)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                string sql = @" 
                            select SUM(b.QuantityExport*SalePrice) TotalSale, SUM(b.QuantityExport*BuyPrice) TotalBuy,b.ItemCode,datepart(MONTH,a.ExportDate) MM,c.ItemName,SUM(b.QuantityExport*SalePrice)-SUM(b.QuantityExport*BuyPrice) TotalInterest,Ic.ItemCategoryName,Ig.GroupName,Um.UnitOfMeasureName,SUM(b.QuantityExport) QuantityExport
                            from MedicinesRetail a inner join(
                            select a.QuantityExport,a.UnitPrice SalePrice,a.ItemCode,a1.UnitPrice BuyPrice,a.RetailCode
                            from MedicinesRetailDetail a inner join InventoryGumshoe a1 on a.RowIDInventoryGumshoe=a1.RowID ) b on a.RetailCode=b.RetailCode
                            inner join Items c on b.ItemCode=c.ItemCode inner join ItemCategory Ic on c.ItemCategoryCode=Ic.ItemCategoryCode inner join ItemGroup Ig on Ic.GroupCode=Ig.GroupCode inner join UnitOfMeasure Um on c.UnitOfMeasureCode=Um.UnitOfMeasureCode
                            where convert(date,a.ExportDate,103) 
                            between convert(date,'{0}',103) and convert(date,'{1}',103) and a.Paid in({2})
                            group by b.ItemCode,datepart(MONTH,a.ExportDate),c.ItemName,b.ItemCode,Ic.ItemCategoryName,Ig.GroupName,Um.UnitOfMeasureName
                            order by datepart(MONTH,a.ExportDate)
                        ";
                dtResult = cn.CallProcedureTable(CommandType.Text, string.Format(sql, sFrom, sTo, iPaid), null);
                return dtResult;
            }
            catch { return null; }
        }

        public static DataTable DT_Exp_MedicinesForPatients(string sRepositoryCode, string sfrom, string sto, string sItemCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[0].Value = sRepositoryCode;
                param[1] = new SqlParameter("@Datefrom", SqlDbType.VarChar, 10);
                param[1].Value = sfrom;
                param[2] = new SqlParameter("@Dateto", SqlDbType.VarChar, 10);
                param[2].Value = sto;
                param[3] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[3].Value = sItemCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_Report_View_MedicinesForPatients", param);
            }
            catch { return null; }
        }

        public static DataTable DT_View_RealMedicinesTH(string sRepositoryCode, DateTime dtfrDate, DateTime dttoDate)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[0].Value = sRepositoryCode;
                param[1] = new SqlParameter("@frDate", SqlDbType.Date);
                param[1].Value = dtfrDate;
                param[2] = new SqlParameter("@toDate", SqlDbType.Date);
                param[2].Value = dttoDate;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_Report_View_RealMedicinesTH", param);
            }
            catch { return null; }
        }

        public static decimal View_RealMedicinesDetail(string sPatientCode, decimal dPatientReceiveID, string sItemCode)
        {
            ConnectDB cn = new ConnectDB();
            decimal dQuantity = 0;
            try
            {
                string sql = @" select isnull(sum(b.Quantity),0) Quantity from RealMedicinesForPatients a inner join RealMedicinesForPatientsDetail b on a.RowID=b.RealRowID
                where a.PatientCode=@PatientCode and a.PatientReceiveID=@PatientReceiveID and b.ItemCode=@ItemCode";
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 10);
                param[0].Value = sPatientCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = dPatientReceiveID;
                param[2] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[2].Value = sItemCode;
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, param);
                if (ireader.Read())
                    dQuantity = Convert.ToDecimal(ireader.GetValue(0).ToString());
                else
                    dQuantity = 0;
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch {  }
            return dQuantity;
        }

        public static DataTable DT_View_RealMedicinesDetail(string sRepositoryCode, DateTime dtfrDate, DateTime dttoDate)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[0].Value = sRepositoryCode;
                param[1] = new SqlParameter("@frDate", SqlDbType.Date);
                param[1].Value = dtfrDate;
                param[2] = new SqlParameter("@toDate", SqlDbType.Date);
                param[2].Value = dttoDate;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_Report_View_RealMedicinesDetail", param);
            }
            catch { return null; }
        }
                
        public static List<view_DoctorAppointedInf> View_BSChiDinh(string sEmployeeCode, string sFrom, string sTo, string sDepartmentCode, string sDepartmentCodeOrder, string sServiceCategoryCode, string sServiceGroupCode, Int32 iPatientType, string sServiceCode, int iStatus, Int32 iPaid, string employeeCodeReport)
        {
            ConnectDB cn = new ConnectDB();
            List<view_DoctorAppointedInf> lst = new List<view_DoctorAppointedInf>();
            try
            {
                //string sql = @" select a.PatientCode,CONVERT(date,a.WorkDate,103) WorkDate,a.ServicePrice,a.DisparityPrice,a1.ServiceName,a2.ServiceCategoryName,a3.ServiceGroupName,b.DepartmentName,
                //        b1.DepartmentName DepartmentNameOrder,b3.ObjectName,a.BanksAccountCode,c.PatientName,c.PatientAddress,c.PatientAge,c.PatientBirthyear,(case when c.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,
                //        convert(char(10),c1.CreateDate,103) DateIn,convert(char(10),c1.OutDate,103) DateOut,a4.EmployeeName EmployeeNameOrder,convert(char(5),a.WorkDate,108)  WorkTime
                //         from SuggestedServiceReceipt a inner join Service a1 on a.ServiceCode=a1.ServiceCode inner join ServiceCategory a2 on a1.ServiceCategoryCode=a2.ServiceCategoryCode
                //         inner join ServiceGroup a3 on a2.ServiceGroupCode=a3.ServiceGroupCode inner join Department b on a.DepartmentCode=b.DepartmentCode
                //         left join Department b1 on a.DepartmentCodeOrder = b1.DepartmentCode inner join Object b3 on a.ObjectCode=b3.ObjectCode 
                //         inner join Patients c on a.PatientCode=c.PatientCode inner join PatientReceive c1 on a.RefID=c1.PatientReceiveID 
                //        inner join Employee a4 on a.EmployeeCodeDoctor=a4.EmployeeCode
                //    where 1=1 ";

                //string sql = @" select a.PatientCode,CONVERT(date,a.WorkDate,103) WorkDate,a.ServicePrice,a.DisparityPrice,a1.ServiceName,a2.ServiceCategoryName,a3.ServiceGroupName,b1.DepartmentName,
                //        b1.DepartmentName DepartmentNameOrder,b3.ObjectName,a.BanksAccountCode,c.PatientName,c.PatientAddress,c.PatientAge,c.PatientBirthyear,(case when c.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,
                //        convert(char(10),c1.CreateDate,103) DateIn,convert(char(10),c1.OutDate,103) DateOut,a4.EmployeeName EmployeeNameOrder,convert(char(5),a.WorkDate,108)  WorkTime,a.Quantity,(a.Quantity * a.ServicePrice) as Amount, (a.Quantity* a.DisparityPrice) as AmountDisparity, ((a.Quantity* a.DisparityPrice)+(a.Quantity * a.ServicePrice)) as AmountTotal
                //         from SuggestedServiceReceipt a inner join Service a1 on a.ServiceCode=a1.ServiceCode inner join ServiceCategory a2 on a1.ServiceCategoryCode=a2.ServiceCategoryCode
                //         inner join ServiceGroup a3 on a2.ServiceGroupCode=a3.ServiceGroupCode 
                //         left join Department b1 on a.DepartmentCodeOrder = b1.DepartmentCode inner join Object b3 on a.ObjectCode=b3.ObjectCode 
                //         inner join Patients c on a.PatientCode=c.PatientCode inner join PatientReceive c1 on a.RefID=c1.PatientReceiveID 
                //        inner join Employee a4 on a.EmployeeCodeDoctor=a4.EmployeeCode
                //    where 1=1 ";

                string sql = @" select a.PatientCode,CONVERT(date, a.WorkDate, 103) WorkDate,sum(a.ServicePrice) as ServicePrice,sum(a.DisparityPrice) as DisparityPrice,a1.ServiceName,a2.ServiceCategoryName,a3.ServiceGroupName,b1.DepartmentName,
                        b1.DepartmentName DepartmentNameOrder, b3.ObjectName,a.BanksAccountCode,c.PatientName,c.PatientAddress,c.PatientAge,c.PatientBirthyear,(case when c.PatientGender = 0 then N'Nữ' else 'Nam' end) PatientGenderName,
                        convert(char(10), c1.CreateDate, 103) DateIn,convert(char(10), c1.OutDate, 103) DateOut,a4.EmployeeName EmployeeNameOrder, convert(char(5), a.WorkDate, 108)  WorkTime,a.Quantity,sum((a.Quantity * a.ServicePrice)) as Amount, sum((a.Quantity * a.DisparityPrice)) as AmountDisparity, sum(((a.Quantity * a.DisparityPrice) + (a.Quantity * a.ServicePrice))) as AmountTotal
                         from SuggestedServiceReceipt a inner
                         join Service a1 on a.ServiceCode = a1.ServiceCode inner
                         join ServiceCategory a2 on a1.ServiceCategoryCode = a2.ServiceCategoryCode
                         inner
                         join ServiceGroup a3 on a2.ServiceGroupCode = a3.ServiceGroupCode
                         left
                         join Department b1 on a.DepartmentCodeOrder = b1.DepartmentCode inner
                         join Object b3 on a.ObjectCode = b3.ObjectCode
                         inner
                         join Patients c on a.PatientCode = c.PatientCode inner
                         join PatientReceive c1 on a.RefID = c1.PatientReceiveID
                        inner
                         join Employee a4 on a.EmployeeCodeDoctor = a4.EmployeeCode
                    where 1 = 1";
                if (!string.IsNullOrWhiteSpace(sEmployeeCode))
                    sql += " and a.EmployeeCodeDoctor in(" + sEmployeeCode + ")";
                if (sFrom != string.Empty && sTo != string.Empty)
                    sql += " and CONVERT(date,a.WorkDate,103) between CONVERT(date,'" + sFrom + "',103) and CONVERT(date,'" + sTo + "',103) ";
                if (!string.IsNullOrWhiteSpace(sDepartmentCode))
                    sql += " and a.DepartmentCode in(" + sDepartmentCode + ")";
                if (!string.IsNullOrWhiteSpace(sDepartmentCodeOrder))
                    sql += " and a.DepartmentCodeOrder in(" + sDepartmentCodeOrder + ")";
                if (!string.IsNullOrWhiteSpace(sServiceCategoryCode))
                    sql += " and a1.ServiceCategoryCode in(" + sServiceCategoryCode + ")";
                if (!string.IsNullOrWhiteSpace(sServiceGroupCode))
                    sql += " and a2.ServiceGroupCode in(" + sServiceGroupCode + ")";
                if (iPatientType != -1)
                    sql += " and a.PatientType in(" + iPatientType + ")";
                if (!string.IsNullOrWhiteSpace(sServiceCode))
                    sql += " and a.ServiceCode in(" + sServiceCode + ")";
                if (iStatus != -1)
                    sql += " and a.Status in(1,2)";
                if(iPaid==1)
                    sql += " and a.Paid in(1) and a.BanksAccountCode is not null ";
                //if (!string.IsNullOrWhiteSpace(employeeCodeReport))
                //    sql += " and a1.ServiceCode in( select ServiceCode from ServiceLimitForEmployee where EmployeeCode='" + employeeCodeReport + "')";

                sql += "group by a.PatientCode,a.WorkDate,a1.ServiceName,a2.ServiceCategoryName,a3.ServiceGroupName,b1.DepartmentName,b1.DepartmentName,b3.ObjectName,a.BanksAccountCode,c.PatientName,c.PatientAddress,c.PatientAge,c.PatientBirthyear, c.PatientGender,c1.CreateDate,c1.OutDate,a4.EmployeeName,a.Quantity";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    view_DoctorAppointedInf inf = new view_DoctorAppointedInf();
                    inf.PatientCode = ireader.GetValue(0).ToString();
                    inf.WorkDate = ireader.GetDateTime(1);
                    inf.ServicePrice = ireader.GetDecimal(2);
                    inf.DisparityPrice = ireader.GetDecimal(3);
                    inf.ServiceName = ireader.GetValue(4).ToString();
                    inf.ServiceCategoryName = ireader.GetValue(5).ToString();
                    inf.ServiceGroupName = ireader.GetValue(6).ToString();
                    inf.DepartmentName = ireader.GetValue(7).ToString();
                    inf.DepartmentNameOrder = ireader.GetValue(8).ToString();
                    inf.ObjectName = ireader.GetValue(9).ToString();
                    inf.BanksAccountCode = ireader.GetValue(10).ToString();
                    inf.PatientName = ireader.GetValue(11).ToString();
                    inf.PatientAddress = ireader.GetValue(12).ToString();
                    inf.PatientAge = ireader.GetInt32(13);
                    inf.PatientBirthyear = ireader.GetInt32(14);
                    inf.PatientGenderName = ireader.GetValue(15).ToString();
                    inf.DateIn = ireader.GetValue(16).ToString();
                    inf.DateOut = ireader.GetValue(17).ToString();
                    inf.EmployeeNameOrder = ireader.GetValue(18).ToString();
                    inf.WorkTime = ireader.GetValue(19).ToString();
                    inf.Quantity = ireader.GetInt32(20);
                    inf.Amount = ireader.GetDecimal(21);
                    inf.AmountDisparity = ireader.GetDecimal(22);
                    inf.AmountTotal = ireader.GetDecimal(23);

                    //if(inf.DisparityPrice>0 && inf.ServicePrice==0)
                    //{
                    //    inf.ServicePrice = inf.DisparityPrice;
                    //    inf.ObjectName = "Thu phí";
                    //}
                    lst.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return lst;
            }
            catch { return null; }
        }

        public static DataTable TableViewInputWarehousing(string repositoryCode, DateTime dateFrom, DateTime dateTo, Int32 export)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[0].Value = repositoryCode;
                param[1] = new SqlParameter("@FromDate", SqlDbType.Date);
                param[1].Value = dateFrom;
                param[2] = new SqlParameter("@ToDate", SqlDbType.Date);
                param[2].Value = dateTo;
                param[3] = new SqlParameter("@Export", SqlDbType.Int);
                param[3].Value = export;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proView_InputWarehousing", param);
            }
            catch { return null; }
        }
        public static List<view_DoctorAppointedInf> View_ChiDinhKCB( string sFrom, string sTo, string sServiceGroupCode, Int32 iStatus)
        {
            ConnectDB cn = new ConnectDB();
            List<view_DoctorAppointedInf> lst = new List<view_DoctorAppointedInf>();
            try
            {
                string sql = @" select a.PatientCode,CONVERT(date,a.WorkDate,103) WorkDate,a.ServicePrice,a.DisparityPrice,a1.ServiceName,a2.ServiceCategoryName,a3.ServiceGroupName,b.DepartmentName,
                        b1.DepartmentName DepartmentNameOrder,b3.ObjectName,a.BanksAccountCode,c.PatientName,c.PatientAddress,c.PatientAge,c.PatientBirthyear,(case when c.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,
                        convert(char(10),c1.CreateDate,103) DateIn,convert(char(10),c1.OutDate,103) DateOut,a4.EmployeeName EmployeeNameOrder
                         from SuggestedServiceReceipt a inner join Service a1 on a.ServiceCode=a1.ServiceCode inner join ServiceCategory a2 on a1.ServiceCategoryCode=a2.ServiceCategoryCode
                         inner join ServiceGroup a3 on a2.ServiceGroupCode=a3.ServiceGroupCode inner join Department b on a.DepartmentCode=b.DepartmentCode
                         left join Department b1 on a.DepartmentCodeOrder = b1.DepartmentCode inner join Object b3 on a.ObjectCode=b3.ObjectCode 
                         inner join Patients c on a.PatientCode=c.PatientCode inner join PatientReceive c1 on a.RefID=c1.PatientReceiveID 
                        inner join Employee a4 on a.EmployeeCodeDoctor=a4.EmployeeCode
                    where 1=1 ";
                if (sFrom != string.Empty && sTo != string.Empty)
                    sql += " and CONVERT(date,a.WorkDate,103) between CONVERT(date,'" + sFrom + "',103) and CONVERT(date,'" + sTo + "',103) ";
                if (!string.IsNullOrWhiteSpace(sServiceGroupCode))
                    sql += " and a2.ServiceGroupCode in(" + sServiceGroupCode + ")";
                if (iStatus == 1)
                    sql += " and a.Status in(1,2)";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    view_DoctorAppointedInf inf = new view_DoctorAppointedInf();
                    inf.PatientCode = ireader.GetValue(0).ToString();
                    inf.WorkDate = ireader.GetDateTime(1);
                    inf.ServicePrice = ireader.GetDecimal(2);
                    inf.DisparityPrice = ireader.GetDecimal(3);
                    inf.ServiceName = ireader.GetValue(4).ToString();
                    inf.ServiceCategoryName = ireader.GetValue(5).ToString();
                    inf.ServiceGroupName = ireader.GetValue(6).ToString();
                    inf.DepartmentName = ireader.GetValue(7).ToString();
                    inf.DepartmentNameOrder = ireader.GetValue(8).ToString();
                    inf.ObjectName = ireader.GetValue(9).ToString();
                    inf.BanksAccountCode = ireader.GetValue(10).ToString();
                    inf.PatientName = ireader.GetValue(11).ToString();
                    inf.PatientAddress = ireader.GetValue(12).ToString();
                    inf.PatientAge = ireader.GetInt32(13);
                    inf.PatientBirthyear = ireader.GetInt32(14);
                    inf.PatientGenderName = ireader.GetValue(15).ToString();
                    inf.DateIn = ireader.GetValue(16).ToString();
                    inf.DateOut = ireader.GetValue(17).ToString();
                    inf.EmployeeNameOrder = ireader.GetValue(18).ToString();
                    lst.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return lst;
            }
            catch { return null; }
        }
    }
}
