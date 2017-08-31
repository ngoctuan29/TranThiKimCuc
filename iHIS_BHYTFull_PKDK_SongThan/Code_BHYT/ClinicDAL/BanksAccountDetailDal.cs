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
    public class BanksAccountDetailDal
    {
        public static Int32 Ins(BanksAccountDetailInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@BanksAccountCode", SqlDbType.VarChar, 50);
                param[0].Value = info.BanksAccountCode;
                param[1] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[1].Value = info.EmployeeCode;
                param[2] = new SqlParameter("@ReceiptID", SqlDbType.Decimal);
                param[2].Value = info.ReceiptID;
                param[3] = new SqlParameter("@STT", SqlDbType.Int);
                param[3].Value = info.STT;
                param[4] = new SqlParameter("@Type", SqlDbType.Int);
                param[4].Value = info.Type;
                param[5] = new SqlParameter("@BHYTPay", SqlDbType.Decimal);
                param[5].Value = info.BHYTPay;
                param[6] = new SqlParameter("@PatientPay", SqlDbType.Decimal);
                param[6].Value = info.PatientPay;
                param[7] = new SqlParameter("@ServicePriceSalesOff", SqlDbType.Decimal);
                param[7].Value = info.ServicePriceSalesOff;
                param[8] = new SqlParameter("@Quantity", SqlDbType.Int);
                param[8].Value = info.Quantity;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_BanksAccountDetail", param) >= 1)
                    return 1;
                else
                    return 0;
            }
            catch { return -2; }
        }

        public static Int32 InsForMedical(BanksAccountDetailInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[18];
                param[0] = new SqlParameter("@BanksAccountCode", SqlDbType.VarChar, 50);
                param[0].Value = info.BanksAccountCode;
                param[1] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[1].Value = info.ServiceCode;
                param[2] = new SqlParameter("@ServicePrice", SqlDbType.Decimal);
                param[2].Value = info.ServicePrice;
                param[3] = new SqlParameter("@DisparityPrice", SqlDbType.Decimal);
                param[3].Value = info.DisparityPrice;
                param[4] = new SqlParameter("@STT", SqlDbType.Int);
                param[4].Value = info.STT;
                param[5] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[5].Value = info.ObjectCode;
                param[6] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[6].Value = info.EmployeeCode;
                param[7] = new SqlParameter("@RowIDPrice", SqlDbType.Decimal);
                param[7].Value = info.RowIDPrice;
                param[8] = new SqlParameter("@ReceiptID", SqlDbType.Decimal);
                param[8].Value = info.ReceiptID;
                param[9] = new SqlParameter("@Type", SqlDbType.Int);
                param[9].Value = info.Type;
                param[10] = new SqlParameter("@Quantity", SqlDbType.Decimal);
                param[10].Value = info.Quantity;
                param[11] = new SqlParameter("@RowIDDetail", SqlDbType.Decimal);
                param[11].Value = info.RowIDDetail;
                param[12] = new SqlParameter("@MedicinesType", SqlDbType.Int);
                param[12].Value = info.MedicinesType;
                param[13] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[13].Value = info.MedicalRecordCode;
                param[14] = new SqlParameter("@RowIDMedicines", SqlDbType.Decimal);
                param[14].Value = info.RowIDMedicines;
                param[15] = new SqlParameter("@BHYTPay", SqlDbType.Decimal);
                param[15].Value = info.BHYTPay;
                param[16] = new SqlParameter("@PatientPay", SqlDbType.Decimal);
                param[16].Value = info.PatientPay;
                param[17] = new SqlParameter("@ServicePriceSalesOff", SqlDbType.Decimal);
                param[17].Value = info.ServicePriceSalesOff;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_BanksAccountDetail_01", param) >= 1)
                    return 1;
                else
                    return 0;
            }
            catch { return -2; }
        }

        public static Int32 Upd_Paid_MedicalRecord(string sMedicalCode, Int32 iPaid, string sBankCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " update MedicalRecord set Paid=@Paid,BanksAccountCode=@BanksAccountCode where MedicalRecordCode=@MedicalRecordCode";
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Paid", SqlDbType.Int);
                param[0].Value = iPaid;
                param[1] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[1].Value = sMedicalCode;
                param[2] = new SqlParameter("@BanksAccountCode", SqlDbType.VarChar, 50);
                param[2].Value = sBankCode;
                if (cn.ExecuteNonQuery(CommandType.Text, sql, param) >= 1)
                    return 1;
                else
                    return 0;
            }
            catch { return -2; }
        }
        public static Int32 Upd_Paid_SuggestedForObjectCode(string patientCode, decimal datientReceiveID, Int32 iPaid, string bankCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " update SuggestedServiceReceipt set Paid=@Paid,BanksAccountCode=@BanksAccountCode where RefID=@RefID and ObjectCode =5 and Paid =0 and PatientCode=@PatientCode";
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@Paid", SqlDbType.Int);
                param[0].Value = iPaid;
                param[1] = new SqlParameter("@BanksAccountCode", SqlDbType.VarChar);
                param[1].Value = bankCode;
                param[2] = new SqlParameter("@RefID", SqlDbType.Decimal);
                param[2].Value = datientReceiveID;
                param[3] = new SqlParameter("@PatientCode", SqlDbType.VarChar);
                param[3].Value = patientCode;
                if (cn.ExecuteNonQuery(CommandType.Text, sql, param) >= 1)
                    return 1;
                else
                    return 0;
            }
            catch { return -2; }
        }
        public static DataTable TableBanksTotal(string banksAccountCode, Int32 cancel, decimal patientReceiveID)
        {
            ConnectDB cn = new ConnectDB();//02/08/2016
            try
            {
                string query = @"select a.BanksAccountCode,a.ReferenceCode,a.PatientCode,a.BHYTPay,a.PatientPay,b.PatientName,(case when b.PatientGender=1 then N'Nam' else N'Nữ' end) PatientGendername,b.PatientBirthday,b.PatientBirthyear,b.PatientAge,b.PatientMobile,b.PatientEmail,b.CodeArise,b.MedicalHistory,b.Allergy,c.Serial,d.KCBBDName,c.StartDate,c.EndDate,c.TraiTuyen,[dbo].func_PatientOfAddress({2}) PatientAddress,a.TotalAmount,a.TotalReal,a.Exemptions,a.TotalSurcharge,REPLACE( CONVERT(varchar, a.PostingDate, 102),'.','')+'-'+replicate('0', 5 - len(a.Serial)) + cast (a.Serial as varchar) as SerialNumber,a1.PatientReceiveClinic,a2.EmployeeName,a3.EmployeeName CashierName,(case when a.ObjectCode=1 then ( case when c.TraiTuyen=1 and c.ReferralPaper=0 then CONVERT(char(3),e.RateFalse)+'%' when c.TraiTuyen=1 and c.ReferralPaper=1 then CONVERT(char(3),e.RateTrue)+'%' else CONVERT(char(3),e.RateTrue)+'%' end) else '' end) RateBHYT,a.Postingdate
                from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode left join BHYT c on a.ReferenceCode=c.PatientReceiveID left join KCBBD d on c.KCBBDCode=d.KCBBDCode left join RateBHYT e on (c.Serial01+c.Serial02)=e.RateCard inner join PatientReceive a1 on a.ReferenceCode=a1.PatientReceiveID inner join Employee a2 on a.EmployeeCode=a2.EmployeeCode left join Employee a3 on a.CashierCode=a3.EmployeeCode left join Catalog_Ward b1 on a1.WardCode=b1.WardCode left join Catalog_District b2 on b.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on b.ProvincialCode=b3.ProvincialCode where a.BanksAccountCode in({0}) and Cancel in({1}) ";
                return cn.ExecuteQuery(string.Format(query, banksAccountCode, cancel, patientReceiveID));
            }
            catch { return null; }
        }

        public static DataTable TableBanksTotalForInvoice(string banksAccountCode, Int32 cancel, decimal patientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = @"select a.ReferenceCode,a.PatientCode,b.PatientName,(case when b.PatientGender=1 then N'Nam' else N'Nữ' end) PatientGendername,b.PatientBirthday,b.PatientBirthyear,b.PatientAge,b.PatientMobile,b.PatientEmail,[dbo].func_PatientOfAddress({2}) PatientAddress,isnull(sum(a.TotalAmount),0) TotalAmount,isnull(sum(a.TotalReal),0) TotalReal,isnull(sum(a.Exemptions),0) Exemptions,isnull(sum(a.TotalSurcharge),0) TotalSurcharge
                from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode left join BHYT c on a.ReferenceCode=c.PatientReceiveID left join KCBBD d on c.KCBBDCode=d.KCBBDCode left join RateBHYT e on SUBSTRING(c.Serial,0,3)=e.RateCard inner join PatientReceive a1 on a.ReferenceCode=a1.PatientReceiveID inner join Employee a2 on a.EmployeeCode=a2.EmployeeCode left join Employee a3 on a.CashierCode=a3.EmployeeCode left join Catalog_Ward b1 on a1.WardCode=b1.WardCode left join Catalog_District b2 on b.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on b.ProvincialCode=b3.ProvincialCode where a.BanksAccountCode in({0}) and Cancel in({1}) 
                group by a.ReferenceCode,a.PatientCode,b.PatientName,b.PatientGender,b.PatientBirthday,b.PatientBirthyear,b.PatientAge,b.PatientMobile,b.PatientEmail ";
                return cn.ExecuteQuery(string.Format(query, banksAccountCode, cancel, patientReceiveID));
            }
            catch { return null; }
        }
        public static DataTable TableBanksTotalForInvoice(decimal patientReceiveID, int objectCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = patientReceiveID;
                param[1] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[1].Value = objectCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proPrintBanksInvoice", param);
            }
            catch { }
            return null;
        }
        public static DataTable DT_BanksTotalBV01(string sPatientCode, decimal dPatientReceive, Int32 iCancel)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[0].Value = sPatientCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = dPatientReceive;
                param[2] = new SqlParameter("@Cancel", SqlDbType.Int);
                param[2].Value = iCancel;
                //param[3] = new SqlParameter("@BanksAccountCode", SqlDbType.VarChar, 50);
                //param[3].Value = banksAccountCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_BanksTotalBV01", param);
            }
            catch { }
            return null;
        }

        public static DataTable DT_View_Treatment_Info(string sPatientCode, decimal dPatientReceive)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[0].Value = sPatientCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = dPatientReceive;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_View_Treatment_Info", param);
            }
            catch { }
            return null;
        }

        public static DataTable DT_View_Treatment_Emergency(string sPatientCode, decimal dPatientReceive, string sMedicalEmergencyCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[0].Value = sPatientCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = dPatientReceive;
                param[2] = new SqlParameter("@MedicalEmergencyCode", SqlDbType.VarChar, 20);
                param[2].Value = sMedicalEmergencyCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_View_Treatment_Emergency", param);
            }
            catch { }
            return null;
        }

        public static DataTable DT_GetBank_Service_Done(decimal dRefID, string sPatientCode, string sBanksCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                //string sql = @" select a.PatientCode,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.PostingDate,c.ServiceName,e.ServiceModuleCode,
                //                (case when b.ServicePrice =0 then b.DisparityPrice else b.ServicePrice end) ServicePrice, b.DisparityPrice,b.Quantity,((case when b.ServicePrice =0 then b.DisparityPrice else b.ServicePrice end)*b.Quantity) Amount,a.Exemptions,a.TotalSurcharge,f.ServiceModuleName,c1.UnitOfMeasureName DVT,f.STT,b1.ObjectName,(case when e.ServiceGroupCode='KCB' then convert(varchar(4), b2.STT) else '' end) STTKham,b.ServicePriceSalesOff,a.TotalBHYTPay,a.TotalPatientPay,e.ServiceGroupName as GroupName
                //                from BanksAccount a inner join BanksAccountDetail b on a.BanksAccountCode=b.BanksAccountCode inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceCategory d on c.ServiceCategoryCode=d.ServiceCategoryCode
                //                inner join ServiceGroup e on d.ServiceGroupCode=e.ServiceGroupCode inner join ServiceModule f on e.ServiceModuleCode=f.ServiceModuleCode inner join UnitOfMeasure c1 on c.UnitOfMeasureCode=c1.UnitOfMeasureCode inner join [Object] b1 on b.ObjectCode=b1.ObjectCode left join SuggestedServiceReceipt b2 on b.ReceiptID=b2.ReceiptID
                //                where a.Cancel=0 and a.ReferenceCode in({0}) and a.PatientCode='{1}' and a.BanksAccountCode='{2}' and b.ServiceCode not in('DV000000')
                //                 union all
                //                select a.PatientCode,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.PostingDate,c.ItemName ServiceName,e.ServiceModuleCode,
                //                b.ServicePrice, b.DisparityPrice,b.Quantity,(b.ServicePrice*b.Quantity) Amount,a.Exemptions,a.TotalSurcharge,f.ServiceModuleName,c1.UnitOfMeasureName DVT,f.STT,b1.ObjectName,'' STTKham,b.ServicePriceSalesOff,a.TotalBHYTPay,a.TotalPatientPay,e.GroupName
                //                from BanksAccount a inner join BanksAccountDetail b on a.BanksAccountCode=b.BanksAccountCode inner join [Object] b1 on b.ObjectCode=b1.ObjectCode
                //                inner join Items c on b.ServiceCode=c.ItemCode inner join ItemCategory d on c.ItemCategoryCode=d.ItemCategoryCode
                //                inner join ItemGroup e on d.GroupCode=e.GroupCode left join ServiceModule f on e.ServiceModuleCode=f.ServiceModuleCode
                //                inner join UnitOfMeasure c1 on c.UnitOfMeasureCode=c1.UnitOfMeasureCode
                //                where a.Cancel=0 and a.ReferenceCode in({0}) and a.PatientCode='{1}' and a.BanksAccountCode='{2}'
                //                order by STT ";
                //string sql = @" 
                //                select a.PatientCode,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.PostingDate,a.ServiceName,a.ServiceModuleCode,
                //            sum(a.ServicePrice) ServicePrice,sum(a.DisparityPrice) DisparityPrice,sum(a.ServicePrice+a.DisparityPrice) as ServicePrice_Disparity,a.Quantity, (sum(a.Quantity*a.ServicePrice) + sum(a.Quantity*a.DisparityPrice)) Amount,a.Exemptions,a.TotalSurcharge,a.ServiceModuleName,a.DVT,a.STT,a.ObjectName,a.STTKham,a.ServicePriceSalesOff,a.TotalBHYTPay,a.TotalPatientPay,a.GroupName
                //             from (
                //                select a.PatientCode,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.PostingDate,c.ServiceName,e.ServiceModuleCode,
                //                b.ServicePrice,b.DisparityPrice,b.Quantity,(b.ServicePrice*b.Quantity) Amount,a.Exemptions,a.TotalSurcharge,f.ServiceModuleName,c1.UnitOfMeasureName DVT,f.STT,b1.ObjectName,(case when e.ServiceGroupCode='KCB' then convert(varchar(4), b2.STT) else '' end) STTKham,b.ServicePriceSalesOff,a.TotalBHYTPay,a.TotalPatientPay,e.ServiceGroupName as GroupName
                //                from BanksAccount a inner join BanksAccountDetail b on a.BanksAccountCode=b.BanksAccountCode inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceCategory d on c.ServiceCategoryCode=d.ServiceCategoryCode
                //                inner join ServiceGroup e on d.ServiceGroupCode=e.ServiceGroupCode inner join ServiceModule f on e.ServiceModuleCode=f.ServiceModuleCode inner join UnitOfMeasure c1 on c.UnitOfMeasureCode=c1.UnitOfMeasureCode inner join [Object] b1 on b.ObjectCode=b1.ObjectCode left join SuggestedServiceReceipt b2 on b.ReceiptID=b2.ReceiptID
                //                where a.Cancel=0 and a.ReferenceCode in({0}) and a.PatientCode='{1}' and a.BanksAccountCode='{2}' and b.ServiceCode not in('DV000000')
                //                 union all
                //                select a.PatientCode,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.PostingDate,c.ItemName ServiceName,e.ServiceModuleCode,
                //                b.ServicePrice,b.DisparityPrice,b.Quantity,(b.ServicePrice*b.Quantity) Amount,a.Exemptions,a.TotalSurcharge,f.ServiceModuleName,c1.UnitOfMeasureName DVT,f.STT,b1.ObjectName,'' STTKham,b.ServicePriceSalesOff,a.TotalBHYTPay,a.TotalPatientPay,e.GroupName
                //                from BanksAccount a inner join BanksAccountDetail b on a.BanksAccountCode=b.BanksAccountCode inner join [Object] b1 on b.ObjectCode=b1.ObjectCode
                //                inner join Items c on b.ServiceCode=c.ItemCode inner join ItemCategory d on c.ItemCategoryCode=d.ItemCategoryCode
                //                inner join ItemGroup e on d.GroupCode=e.GroupCode left join ServiceModule f on e.ServiceModuleCode=f.ServiceModuleCode
                //                inner join UnitOfMeasure c1 on c.UnitOfMeasureCode=c1.UnitOfMeasureCode
                //                where a.Cancel=0 and a.ReferenceCode in({0}) and a.PatientCode='{1}' and a.BanksAccountCode='{2}' ) a
                //                group by 
                //            a.PatientCode,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.PostingDate,a.ServiceName,a.ServiceModuleCode,a.Quantity,a.Exemptions,a.TotalSurcharge,a.ServiceModuleName,a.DVT,a.STT
                //            ,a.ObjectName,a.STTKham,a.ServicePriceSalesOff,a.TotalBHYTPay,a.TotalPatientPay,a.GroupName
                //            order by STT
                //                ";

                string sql = @" 
                                select a.PatientCode,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.PostingDate,a.ServiceName,a.ServiceModuleCode,
                            sum(a.ServicePrice) ServicePrice,sum(a.DisparityPrice) DisparityPrice,sum(a.ServicePrice+a.DisparityPrice) as ServicePrice_Disparity,a.Quantity, (sum(a.Quantity*a.ServicePrice) + sum(a.Quantity*a.DisparityPrice)) Amount,a.Exemptions,a.TotalSurcharge,a.ServiceModuleName,a.DVT,a.STT,a.ObjectName,a.STTKham,a.ServicePriceSalesOff,a.TotalBHYTPay,a.TotalPatientPay,a.GroupName
                             from (
                                select a.PatientCode,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.PostingDate,c.ServiceName,e.ServiceModuleCode,
                                b.ServicePrice,b.DisparityPrice,b.Quantity,(b.ServicePrice*b.Quantity) Amount,a.Exemptions,a.TotalSurcharge,f.ServiceModuleName,c1.UnitOfMeasureName DVT,f.STT,b1.ObjectName,(case when e.ServiceGroupCode='KCB' then convert(varchar(4), b2.STT) else '' end) STTKham,b.ServicePriceSalesOff,a.TotalBHYTPay,a.TotalPatientPay,e.ServiceGroupName as GroupName
                                from BanksAccount a inner join BanksAccountDetail b on a.BanksAccountCode=b.BanksAccountCode inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceCategory d on c.ServiceCategoryCode=d.ServiceCategoryCode
                                inner join ServiceGroup e on d.ServiceGroupCode=e.ServiceGroupCode inner join ServiceModule f on e.ServiceModuleCode=f.ServiceModuleCode inner join UnitOfMeasure c1 on c.UnitOfMeasureCode=c1.UnitOfMeasureCode inner join [Object] b1 on b.ObjectCode=b1.ObjectCode left join SuggestedServiceReceipt b2 on b.ReceiptID=b2.ReceiptID
                                where a.Cancel=0 and a.ReferenceCode in({0}) and a.PatientCode='{1}' and a.BanksAccountCode='{2}' and b.ServiceCode not in('DV000000')
                                 union all
                                select a.PatientCode,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.PostingDate,c.ItemName ServiceName,e.ServiceModuleCode,
                                b.ServicePrice,b.DisparityPrice,sum(b.Quantity) Quantity,sum((b.ServicePrice*b.Quantity))Amount,a.Exemptions,a.TotalSurcharge,f.ServiceModuleName,c1.UnitOfMeasureName DVT,f.STT,b1.ObjectName,'' STTKham,b.ServicePriceSalesOff,a.TotalBHYTPay,a.TotalPatientPay,e.GroupName
                                from BanksAccount a inner join BanksAccountDetail b on a.BanksAccountCode=b.BanksAccountCode inner join [Object] b1 on b.ObjectCode=b1.ObjectCode
                                inner join Items c on b.ServiceCode=c.ItemCode inner join ItemCategory d on c.ItemCategoryCode=d.ItemCategoryCode
                                inner join ItemGroup e on d.GroupCode=e.GroupCode left join ServiceModule f on e.ServiceModuleCode=f.ServiceModuleCode
                                inner join UnitOfMeasure c1 on c.UnitOfMeasureCode=c1.UnitOfMeasureCode
                                where a.Cancel=0 and a.ReferenceCode in({0}) and a.PatientCode='{1}' and a.BanksAccountCode='{2}'
                                group by 
								a.PatientCode,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.PostingDate,c.ItemName,e.ServiceModuleCode,
                                b.ServicePrice,b.DisparityPrice,Quantity ,a.Exemptions,a.TotalSurcharge,f.ServiceModuleName,c1.UnitOfMeasureName,f.STT,b1.ObjectName,b.ServicePriceSalesOff,a.TotalBHYTPay,a.TotalPatientPay,e.GroupName
) a
                                group by 
                            a.PatientCode,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.PostingDate,a.ServiceName,a.ServiceModuleCode,a.Quantity,a.Exemptions,a.TotalSurcharge,a.ServiceModuleName,a.DVT,a.STT
                            ,a.ObjectName,a.STTKham,a.ServicePriceSalesOff,a.TotalBHYTPay,a.TotalPatientPay,a.GroupName
                            order by STT
                                ";
                dt = cn.ExecuteQuery(string.Format(sql, dRefID, sPatientCode, sBanksCode));
            }
            catch { }
            return dt;
        }

        public static DataTable Table_GetBankServiceDoneForInvoice(decimal patientReceiveID, string patientCode)
        {
            ConnectDB connect = new ConnectDB();
            DataTable table = new DataTable();
            try
            {
                string sql = @" select a.PatientCode,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.PostingDate,c.ServiceName,e.ServiceModuleCode,
                                b.ServicePrice,b.DisparityPrice,b.Quantity,(b.ServicePrice*b.Quantity) Amount,a.Exemptions,a.TotalSurcharge,f.ServiceModuleName,c1.UnitOfMeasureName DVT,f.STT,a.NoInvoice
                                from BanksAccount a inner join BanksAccountDetail b on a.BanksAccountCode=b.BanksAccountCode
                                inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceCategory d on c.ServiceCategoryCode=d.ServiceCategoryCode
                                inner join ServiceGroup e on d.ServiceGroupCode=e.ServiceGroupCode inner join ServiceModule f on e.ServiceModuleCode=f.ServiceModuleCode inner join UnitOfMeasure c1 on c.UnitOfMeasureCode=c1.UnitOfMeasureCode
                                where a.Cancel=0 and a.ReferenceCode in({0}) and a.PatientCode in({1}) and b.ServiceCode not in('DV000000')
                                 union all
                                 select a.PatientCode,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.PostingDate,c.ItemName ServiceName,e.ServiceModuleCode,
                                b.ServicePrice,b.DisparityPrice,b.Quantity,(b.ServicePrice*b.Quantity) Amount,a.Exemptions,a.TotalSurcharge,f.ServiceModuleName,c1.UnitOfMeasureName DVT,f.STT,a.NoInvoice
                                from BanksAccount a inner join BanksAccountDetail b on a.BanksAccountCode=b.BanksAccountCode
                                inner join Items c on b.ServiceCode=c.ItemCode inner join ItemCategory d on c.ItemCategoryCode=d.ItemCategoryCode
                                inner join ItemGroup e on d.GroupCode=e.GroupCode left join ServiceModule f on e.ServiceModuleCode=f.ServiceModuleCode
                                inner join UnitOfMeasure c1 on c.UnitOfMeasureCode=c1.UnitOfMeasureCode
                                 where a.Cancel=0 and a.ReferenceCode in({0}) and a.PatientCode in({1})
                                order by STT
                                 ";
                table = connect.ExecuteQuery(string.Format(sql, patientReceiveID, patientCode));
            }
            catch { }
            return table;
        }

        public static DataTable TableBanksTotal_TotalGroupDate(Int32 cancel, string patientCode, DateTime dtPosting)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = @"select a.BanksAccountCode,a.ReferenceCode,a.PatientCode,a.BHYTPay,a.PatientPay,b.PatientName,(case when b.PatientGender=1 then N'Nam' else N'Nữ' end) PatientGendername,b.PatientBirthday,b.PatientBirthyear,b.PatientAge,b.PatientMobile,b.PatientEmail,b.CodeArise,b.MedicalHistory,b.Allergy,c.Serial,d.KCBBDName,c.StartDate,c.EndDate,c.TraiTuyen,[dbo].func_PatientOfAddress({1}) PatientAddress,a.TotalAmount,a.TotalReal,a.Exemptions,a.TotalSurcharge,REPLACE( CONVERT(varchar, a.PostingDate, 102),'.','')+'-'+replicate('0', 5 - len(a.Serial)) + cast (a.Serial as varchar) as SerialNumber,a1.PatientReceiveClinic,a2.EmployeeName,a3.EmployeeName CashierName,(case when a.ObjectCode=1 then ( case when c.TraiTuyen=1 and c.ReferralPaper=0 then CONVERT(char(3),e.RateFalse)+'%' when c.TraiTuyen=1 and c.ReferralPaper=1 then CONVERT(char(3),e.RateTrue)+'%' else CONVERT(char(3),e.RateTrue)+'%' end) else '' end) RateBHYT,a.Postingdate
                from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode left join BHYT c on a.ReferenceCode=c.PatientReceiveID left join KCBBD d on c.KCBBDCode=d.KCBBDCode left join RateBHYT e on (c.Serial01+c.Serial02)=e.RateCard inner join PatientReceive a1 on a.ReferenceCode=a1.PatientReceiveID inner join Employee a2 on a.EmployeeCode=a2.EmployeeCode left join Employee a3 on a.CashierCode=a3.EmployeeCode left join Catalog_Ward b1 on a1.WardCode=b1.WardCode left join Catalog_District b2 on b.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on b.ProvincialCode=b3.ProvincialCode where Cancel ={0} and a.PatientCode ={1} and convert(Date,a.Postingdate,103)=convert(Date,'{2}',103)";
                return cn.ExecuteQuery(string.Format(query, cancel, patientCode, dtPosting.ToString("dd/MM/yyyy")));
            }
            catch { return null; }
        }

        public static DataTable TableBanksTotalForInvoiceTop(string sPatientCode, Int32 cancel, decimal patientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = @"select top 1 a.ReferenceCode,a.PatientCode,b.PatientName,(case when b.PatientGender=1 then N'Nam' else N'Nữ' end) PatientGendername,b.PatientBirthday,b.PatientBirthyear,b.PatientAge,b.PatientMobile,b.PatientEmail,[dbo].func_PatientOfAddress({2}) PatientAddress,isnull(sum(a.TotalAmount),0) TotalAmount,isnull(sum(a.TotalReal),0) TotalReal,isnull(sum(a.Exemptions),0) Exemptions,isnull(sum(a.TotalSurcharge),0) TotalSurcharge,CONVERT(char(10), a.PostingDate,103) PostingDate,a.Invoice_MauSo,a.Invoice_KyHieu,a.Invoice_HoTenKH,a.Invoice_DiaChi,a.Invoice_MaSoThue,a.Invoice_DienThoai,a.Invoice_HTThanhToan,a.Invoice_VAT,a.Invoice_DonVi
                from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode left join BHYT c on a.ReferenceCode=c.PatientReceiveID left join KCBBD d on c.KCBBDCode=d.KCBBDCode left join RateBHYT e on SUBSTRING(c.Serial,0,3)=e.RateCard inner join PatientReceive a1 on a.ReferenceCode=a1.PatientReceiveID inner join Employee a2 on a.EmployeeCode=a2.EmployeeCode left join Employee a3 on a.CashierCode=a3.EmployeeCode left join Catalog_Ward b1 on a1.WardCode=b1.WardCode left join Catalog_District b2 on b.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on b.ProvincialCode=b3.ProvincialCode 
                where a.PatientCode = '{0}' and Cancel in({1}) and a.ReferenceCode in ({2})
                group by a.ReferenceCode,a.PatientCode,b.PatientName,b.PatientGender,b.PatientBirthday,b.PatientBirthyear,b.PatientAge,b.PatientMobile,b.PatientEmail,a.PostingDate,a.Invoice_MauSo,a.Invoice_KyHieu,a.Invoice_HoTenKH,a.Invoice_DiaChi,a.Invoice_MaSoThue,a.Invoice_DienThoai,a.Invoice_HTThanhToan,a.Invoice_VAT,a.Invoice_DonVi ";
                return cn.ExecuteQuery(string.Format(query, sPatientCode, cancel, patientReceiveID));
            }
            catch { return null; }
        }

        public static DataTable Table_GetBank_Service_DoneGeneral(decimal patientReceiveID, string patientCode, string banksAccountCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string sql = @" select a.PatientCode,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.PostingDate,e.ServiceModuleCode,
isnull(sum(b.DisparityPrice),0) DisparityPrice,isnull(sum(b.ServicePrice*b.Quantity),0) Amount,
a.Exemptions,a.TotalSurcharge,f.ServiceModuleName,f.STT,a1.EmployeeName
from BanksAccount a inner join BanksAccountDetail b on a.BanksAccountCode=b.BanksAccountCode
inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceCategory d on c.ServiceCategoryCode=d.ServiceCategoryCode
inner join ServiceGroup e on d.ServiceGroupCode=e.ServiceGroupCode 
inner join ServiceModule f on e.ServiceModuleCode=f.ServiceModuleCode inner join Employee a1 on a.EmployeeCode=a1.EmployeeCode
                                where a.Cancel=0 and a.ReferenceCode in({0}) and a.PatientCode='{1}' and a.BanksAccountCode in({2})
group by a.PatientCode,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.PostingDate,e.ServiceModuleCode,
a.Exemptions,a.TotalSurcharge,f.ServiceModuleName,f.STT,a1.EmployeeName
                                 union all
                                  select a.PatientCode,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.PostingDate,e.ServiceModuleCode,
isnull(sum(b.DisparityPrice),0) DisparityPrice,isnull(sum(b.ServicePrice*b.Quantity),0) Amount,
a.Exemptions,a.TotalSurcharge,f.ServiceModuleName,f.STT,a1.EmployeeName
from BanksAccount a inner join BanksAccountDetail b on a.BanksAccountCode=b.BanksAccountCode
inner join Items c on b.ServiceCode=c.ItemCode inner join ItemCategory d on c.ItemCategoryCode=d.ItemCategoryCode
inner join ItemGroup e on d.GroupCode=e.GroupCode 
left join ServiceModule f on e.ServiceModuleCode=f.ServiceModuleCode
inner join UnitOfMeasure c1 on c.UnitOfMeasureCode=c1.UnitOfMeasureCode inner join Employee a1 on a.EmployeeCode=a1.EmployeeCode
                                 where a.Cancel=0 and a.ReferenceCode in({0}) and a.PatientCode='{1}' and a.BanksAccountCode in({2})
                                group by a.PatientCode,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.PostingDate,e.ServiceModuleCode,
a.Exemptions,a.TotalSurcharge,f.ServiceModuleName,f.STT,a1.EmployeeName
                                order by f.STT
                                 ";
                tableResult = cn.ExecuteQuery(string.Format(sql, patientReceiveID, patientCode, banksAccountCode));
            }
            catch { }
            return tableResult;
        }

        public static DataTable DT_GetBank_Service_Done_NoBankCode(decimal dRefID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = @" select a.PatientCode,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.PostingDate,c.ServiceName,e.ServiceModuleCode,
                                b.ServicePrice,b.DisparityPrice,b.Quantity,(b.ServicePrice*b.Quantity) Amount,a.Exemptions,a.TotalSurcharge,f.ServiceModuleName,c1.UnitOfMeasureName DVT,f.STT,b1.ObjectName,(case when e.ServiceGroupCode='KCB' then convert(varchar(4), b2.STT) else '' end) STTKham,b.ServicePriceSalesOff,b.PatientPay PatientPayDetail
                                from BanksAccount a inner join BanksAccountDetail b on a.BanksAccountCode=b.BanksAccountCode inner join Service c on b.ServiceCode=c.ServiceCode inner join ServiceCategory d on c.ServiceCategoryCode=d.ServiceCategoryCode
                                inner join ServiceGroup e on d.ServiceGroupCode=e.ServiceGroupCode inner join ServiceModule f on e.ServiceModuleCode=f.ServiceModuleCode inner join UnitOfMeasure c1 on c.UnitOfMeasureCode=c1.UnitOfMeasureCode inner join [Object] b1 on b.ObjectCode=b1.ObjectCode left join SuggestedServiceReceipt b2 on b.ReceiptID=b2.ReceiptID
                                where a.Cancel=0 and a.ReferenceCode in({0}) and a.PatientCode='{1}' and b.ServiceCode not in('DV000000') 
                                 union all
                                 select a.PatientCode,a.BHYTPay,a.PatientPay,a.TotalAmount,a.TotalReal,a.PostingDate,c.ItemName ServiceName,e.ServiceModuleCode,
                                b.ServicePrice,b.DisparityPrice,b.Quantity,(b.ServicePrice*b.Quantity) Amount,a.Exemptions,a.TotalSurcharge,f.ServiceModuleName,c1.UnitOfMeasureName DVT,f.STT,b1.ObjectName,'' STTKham,b.ServicePriceSalesOff,b.PatientPay PatientPayDetail
                                from BanksAccount a inner join BanksAccountDetail b on a.BanksAccountCode=b.BanksAccountCode inner join [Object] b1 on b.ObjectCode=b1.ObjectCode
                                inner join Items c on b.ServiceCode=c.ItemCode inner join ItemCategory d on c.ItemCategoryCode=d.ItemCategoryCode
                                inner join ItemGroup e on d.GroupCode=e.GroupCode left join ServiceModule f on e.ServiceModuleCode=f.ServiceModuleCode
                                inner join UnitOfMeasure c1 on c.UnitOfMeasureCode=c1.UnitOfMeasureCode
                                 where a.Cancel=0 and a.ReferenceCode in({0}) and a.PatientCode='{1}'
                                order by STT
                                 ";
                dt = cn.ExecuteQuery(string.Format(sql, dRefID, sPatientCode));
            }
            catch { dt = null; }
            return dt;
        }

        public static DataTable DT_GetBank_Service_BV01(decimal dRefID, string sPatientCode, Int32 iCancel)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[0].Value = sPatientCode;
                param[1] = new SqlParameter("@PatientRecive", SqlDbType.Decimal);
                param[1].Value = dRefID;
                param[2] = new SqlParameter("@Cancel", SqlDbType.Int);
                param[2].Value = iCancel;
                //param[3] = new SqlParameter("@BanksAccountCode", SqlDbType.VarChar, 50);
                //param[3].Value = banksAccountCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_GetBV01", param);
            }
            catch { }
            return null;
        }

        public static DataTable DT_View_Treatment_Costs(decimal refID, string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[0].Value = patientCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = refID;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_View_Treatment_Costs", param);
            }
            catch { }
            return null;
        }
        public static DataTable DT_View_Treatment_OutPatient(string patientCode, decimal patientReceive)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[0].Value = patientCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = patientReceive;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_View_Treatment_OutPatient", param);
            }
            catch { }
            return null;
        }

    }
}
