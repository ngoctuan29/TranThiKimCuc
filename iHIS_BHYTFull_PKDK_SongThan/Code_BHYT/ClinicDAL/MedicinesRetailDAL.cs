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
    public class MedicinesRetailDAL
    {
        public static DataTable DT_MedicinesRetailDetail(string sRetailCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RetailCode", typeof(string)));
                dt.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                dt.Columns.Add(new DataColumn("DateOfIssues", typeof(int)));
                dt.Columns.Add(new DataColumn("Morning", typeof(string)));
                dt.Columns.Add(new DataColumn("Noon", typeof(string)));
                dt.Columns.Add(new DataColumn("Afternoon", typeof(string)));
                dt.Columns.Add(new DataColumn("Evening", typeof(string)));
                dt.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
                dt.Columns.Add(new DataColumn("Instruction", typeof(string)));
                dt.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                dt.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                dt.Columns.Add(new DataColumn("RateBHYT", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ItemName", typeof(string)));
                dt.Columns.Add(new DataColumn("Active", typeof(string)));
                string sql = @" select a.RetailCode,a.ItemCode,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening,
                        a.Quantity,a.Instruction,a.UnitPrice,a.Amount,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.RateBHYT,b.ItemName,b.Active
                        from MedicinesRetailDetail a inner join Items b on a.ItemCode=b.ItemCode 
                        inner join MedicinesRetail c on a.RetailCode=c.RetailCode inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode
                        where a.RetailCode in('{0}') 
                        ";
                dt = cn.ExecuteQuery(string.Format(sql, sRetailCode));
            }
            catch { }
            return dt;
        }

        public static DataTable DT_MedicinesRetail(string sPatientCode, decimal dPatientReceiveID, Int32 iPaid, string sBanksAccountCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("MedicalRecordCode", typeof(string)));
                dt.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                dt.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
                dt.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ItemName", typeof(string)));
                dt.Columns.Add(new DataColumn("SalesPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("BHYTPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("RateBHYT", typeof(decimal)));
                dt.Columns.Add(new DataColumn("BHYTPay", typeof(decimal)));
                dt.Columns.Add(new DataColumn("PatientPay", typeof(decimal)));
                dt.Columns.Add(new DataColumn("UnitOfMeasureName", typeof(string)));
                dt.Columns.Add(new DataColumn("ReceiptID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("RowIDPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                SqlParameter[] sqlParameter = new SqlParameter[4];
                sqlParameter[0] = new SqlParameter("@Paid", SqlDbType.Int);
                sqlParameter[0].Value = iPaid;
                sqlParameter[1] = new SqlParameter("@BanksAccountCode", SqlDbType.VarChar, 50);
                sqlParameter[1].Value = sBanksAccountCode;
                sqlParameter[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                sqlParameter[2].Value = sPatientCode;
                sqlParameter[3] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                sqlParameter[3].Value = dPatientReceiveID;
                IDataReader ireader = cn.ExecuteReader(CommandType.StoredProcedure, "pro_ResultMedicinesRetail", sqlParameter);
                while (ireader.Read())
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = ireader.GetValue(0).ToString();
                    dr[1] = ireader.GetString(1);
                    dr[2] = ireader.GetDecimal(2);
                    dr[3] = ireader.GetDecimal(3);
                    dr[4] = ireader.GetDecimal(4);
                    dr[5] = ireader.GetValue(5).ToString();
                    dr[6] = ireader.GetDecimal(6);
                    dr[7] = ireader.GetDecimal(7);
                    dr[8] = 0;
                    dr[9] = 0;
                    dr[10] = ireader.GetDecimal(4);
                    dr[11] = ireader.GetValue(9).ToString();
                    dr[12] = 0;
                    dr[13] = 0;
                    dr[14] = 2;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { }
            return dt;
        }

        public static Int32 Ins(MedicinesRetailInf info, ref string refRetailCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[35];
                param[0] = new SqlParameter("@RetailCode", SqlDbType.VarChar, 20);
                param[0].Value = info.RetailCode;
                param[1] = new SqlParameter("@FullName", SqlDbType.NVarChar, 500);
                param[1].Value = info.FullName;
                param[2] = new SqlParameter("@Birthyear", SqlDbType.VarChar, 5);
                param[2].Value = info.Birthyear;
                param[3] = new SqlParameter("@Address", SqlDbType.NVarChar, 500);
                param[3].Value = info.Address;
                param[4] = new SqlParameter("@Diagnosis", SqlDbType.NVarChar, 250);
                param[4].Value = info.Diagnosis;
                param[5] = new SqlParameter("@NumberOfDrugCoal", SqlDbType.VarChar, 5);
                param[5].Value = info.NumberOfDrugCoal;
                param[6] = new SqlParameter("@SerialNumber", SqlDbType.VarChar, 50);
                param[6].Value = info.SerialNumber;
                param[7] = new SqlParameter("@InvoiceNumber", SqlDbType.VarChar, 50);
                param[7].Value = info.InvoiceNumber;
                param[8] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[8].Value = info.EmployeeCode;
                param[9] = new SqlParameter("@ExportDate", SqlDbType.Date);
                param[9].Value = info.ExportDate;
                param[10] = new SqlParameter("@Paid", SqlDbType.Int);
                param[10].Value = info.Paid;
                param[11] = new SqlParameter("@TotalAmount", SqlDbType.Decimal);
                param[11].Value = info.TotalAmount;
                param[12] = new SqlParameter("@TotalAmountReal", SqlDbType.Decimal);
                param[12].Value = info.TotalAmountReal;
                param[13] = new SqlParameter("@RateOther", SqlDbType.Decimal);
                param[13].Value = info.RateOther;
                param[14] = new SqlParameter("@RateUSD", SqlDbType.Decimal);
                param[14].Value = info.RateUSD;
                param[15] = new SqlParameter("@RateSurcharge", SqlDbType.Decimal);
                param[15].Value = info.RateSurcharge;
                param[16] = new SqlParameter("@TotalSurcharge", SqlDbType.Decimal);
                param[16].Value = info.TotalSurcharge;
                param[17] = new SqlParameter("@IntroCode", SqlDbType.VarChar);
                param[17].Value = info.IntroCode;
                param[18] = new SqlParameter("@Cash", SqlDbType.Decimal);
                param[18].Value = info.Cash;
                param[19] = new SqlParameter("@ExcessCash", SqlDbType.Decimal);
                param[19].Value = info.ExcessCash;
                param[20] = new SqlParameter("@VoucherCard", SqlDbType.VarChar);
                param[20].Value = info.VoucherCard;
                param[21] = new SqlParameter("@OtherCard", SqlDbType.VarChar);
                param[21].Value = info.OtherCard;
                param[22] = new SqlParameter("@ExcessCashOther", SqlDbType.Decimal);
                param[22].Value = info.ExcessCashOther;
                param[23] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[23].Value = info.MedicalRecordCode;
                param[24] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[24].Value = info.PatientCode;
                param[25] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[25].Value = info.PatientReceiveID;
                param[26] = new SqlParameter("@ShiftWork", SqlDbType.Char, 2);
                param[26].Value = info.ShiftWork;
                param[27] = new SqlParameter("@PatientBirthday", SqlDbType.Date);
                param[27].Value = info.PatientBirthday;
                param[28] = new SqlParameter("@PatientMonth", SqlDbType.VarChar, 5);
                param[28].Value = info.PatientMonth;
                param[29] = new SqlParameter("@PatientGender", SqlDbType.Int);
                param[29].Value = info.PatientGender;
                param[30] = new SqlParameter("@PatientAge", SqlDbType.Int);
                param[30].Value = info.PatientAge;
                param[31] = new SqlParameter("@EmployeeCodeDoctor", SqlDbType.VarChar, 15);
                param[31].Value = info.EmployeeCodeDoctor;
                param[32] = new SqlParameter("@EmployeeNameDoctor", SqlDbType.NVarChar, 250);
                param[32].Value = info.EmployeeNameDoctor;
                param[33] = new SqlParameter("@VAT", SqlDbType.Int);
                param[33].Value = info.VAT;
                param[34] = new SqlParameter("@ResultRetailCode", SqlDbType.VarChar, 20);
                param[34].Direction = ParameterDirection.Output;
                refRetailCode = cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_MedicinesRetail", param);
                if (refRetailCode != string.Empty)
                    return 1;
                else
                    return 0;
            }
            catch (Exception) { return -2; }
        }

        public static Int32 UpdMedicinesRetailInfo(MedicinesRetailInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "update MedicinesRetail set FullName=@FullName,Birthyear=@Birthyear,Address=@Address,Diagnosis=@Diagnosis,NumberOfDrugCoal=@NumberOfDrugCoal,SerialNumber=@SerialNumber,InvoiceNumber=@InvoiceNumber where RetailCode=@RetailCode";
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@RetailCode", SqlDbType.VarChar, 20);
                param[0].Value = info.RetailCode;
                param[1] = new SqlParameter("@FullName", SqlDbType.NVarChar, 500);
                param[1].Value = info.FullName;
                param[2] = new SqlParameter("@Birthyear", SqlDbType.VarChar, 5);
                param[2].Value = info.Birthyear;
                param[3] = new SqlParameter("@Address", SqlDbType.NVarChar, 500);
                param[3].Value = info.Address;
                param[4] = new SqlParameter("@Diagnosis", SqlDbType.NVarChar, 250);
                param[4].Value = info.Diagnosis;
                param[5] = new SqlParameter("@NumberOfDrugCoal", SqlDbType.VarChar, 5);
                param[5].Value = info.NumberOfDrugCoal;
                param[6] = new SqlParameter("@SerialNumber", SqlDbType.VarChar, 50);
                param[6].Value = info.SerialNumber;
                param[7] = new SqlParameter("@InvoiceNumber", SqlDbType.VarChar, 50);
                param[7].Value = info.InvoiceNumber;
                return cn.ExecuteNonQuery(CommandType.Text, query, param);
            }
            catch { return -2; }
        }

        public static Int32 UpdStatus(Int32 iPaid, string sRetailCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " update MedicinesRetail set Paid=@Paid where RetailCode=@RetailCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@RetailCode", SqlDbType.VarChar, 20);
                param[0].Value = sRetailCode;
                param[1] = new SqlParameter("@Paid", SqlDbType.Int);
                param[1].Value = iPaid;
                return cn.ExecuteNonQuery(CommandType.Text, sql, param);
            }
            catch { return -2; }
        }

        public static Int32 UpdPaidMedicines(Int32 iPaid, string sPatientCode, decimal dPatientReceiveID, string sBanksAccountCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " update MedicinesRetail set Paid=@Paid,BanksAccountCode=@BanksAccountCode where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID and Paid not in(-1)";
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@BanksAccountCode", SqlDbType.VarChar, 50);
                param[0].Value = sBanksAccountCode;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = sPatientCode;
                param[2] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[2].Value = dPatientReceiveID;
                param[3] = new SqlParameter("@Paid", SqlDbType.Int);
                param[3].Value = iPaid;
                return cn.ExecuteNonQuery(CommandType.Text, sql, param);
            }
            catch { return -2; }
        }

        public static Int32 InsDetailSub(MedicinesRetailDetailInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[15];
                param[0] = new SqlParameter("@RetailCode", SqlDbType.VarChar, 20);
                param[0].Value = info.RetailCode;
                param[1] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[1].Value = info.ItemCode;
                param[2] = new SqlParameter("@DateOfIssues", SqlDbType.Int);
                param[2].Value = info.DateOfIssues;
                param[3] = new SqlParameter("@Quantity", SqlDbType.Decimal);
                param[3].Value = info.Quantity;
                param[4] = new SqlParameter("@UnitPrice", SqlDbType.Decimal);
                param[4].Value = info.UnitPrice;
                param[5] = new SqlParameter("@Amount", SqlDbType.Decimal);
                param[5].Value = info.Amount;
                param[6] = new SqlParameter("@RowIDInventoryGumshoe", SqlDbType.Decimal);
                param[6].Value = info.RowIDInventoryGumshoe;
                param[7] = new SqlParameter("@RateBHYT", SqlDbType.Decimal);
                param[7].Value = info.RateBHYT;
                param[8] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[8].Value = info.RepositoryCode;
                param[9] = new SqlParameter("@Instruction", SqlDbType.NVarChar, 1000);
                param[9].Value = info.Instruction;
                param[10] = new SqlParameter("@QuantityExport", SqlDbType.Decimal);
                param[10].Value = info.QuantityExport;
                param[11] = new SqlParameter("@Morning", SqlDbType.VarChar, 50);
                param[11].Value = info.Morning;
                param[12] = new SqlParameter("@Noon", SqlDbType.VarChar, 50);
                param[12].Value = info.Noon;
                param[13] = new SqlParameter("@Afternoon", SqlDbType.VarChar, 50);
                param[13].Value = info.Afternoon;
                param[14] = new SqlParameter("@Evening", SqlDbType.VarChar, 50);
                param[14].Value = info.Evening;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_MedicinesRetailDetailSub", param);
            }
            catch { return -2; }
        }

        public static Int32 InsDetail(MedicinesRetailDetailInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[15];
                param[0] = new SqlParameter("@RetailCode", SqlDbType.VarChar, 20);
                param[0].Value = info.RetailCode;
                param[1] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[1].Value = info.ItemCode;
                param[2] = new SqlParameter("@DateOfIssues", SqlDbType.Int);
                param[2].Value = info.DateOfIssues;
                param[3] = new SqlParameter("@Quantity", SqlDbType.Decimal);
                param[3].Value = info.Quantity;
                param[4] = new SqlParameter("@UnitPrice", SqlDbType.Decimal);
                param[4].Value = info.UnitPrice;
                param[5] = new SqlParameter("@Amount", SqlDbType.Decimal);
                param[5].Value = info.Amount;
                param[6] = new SqlParameter("@RowIDInventoryGumshoe", SqlDbType.Decimal);
                param[6].Value = info.RowIDInventoryGumshoe;
                param[7] = new SqlParameter("@RateBHYT", SqlDbType.Decimal);
                param[7].Value = info.RateBHYT;
                param[8] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[8].Value = info.RepositoryCode;
                param[9] = new SqlParameter("@Instruction", SqlDbType.NVarChar, 1000);
                param[9].Value = info.Instruction;
                param[10] = new SqlParameter("@QuantityExport", SqlDbType.Decimal);
                param[10].Value = info.QuantityExport;
                param[11] = new SqlParameter("@Morning", SqlDbType.VarChar, 50);
                param[11].Value = info.Morning;
                param[12] = new SqlParameter("@Noon", SqlDbType.VarChar, 50);
                param[12].Value = info.Noon;
                param[13] = new SqlParameter("@Afternoon", SqlDbType.VarChar, 50);
                param[13].Value = info.Afternoon;
                param[14] = new SqlParameter("@Evening", SqlDbType.VarChar, 50);
                param[14].Value = info.Evening;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_MedicinesRetailDetail", param);
            }
            catch { return -2; }
        }

        public static Int32 DelDetail(string sRetailCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = @" delete from MedicinesRetailDetail where RetailCode=@RetailCode";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RetailCode", SqlDbType.VarChar, 20);
                param[0].Value = sRetailCode;
                return cn.ExecuteNonQuery(CommandType.Text, sql, param);
            }
            catch { return -2; }
        }

        public static Int32 DelDetail(string sRetailCode, string sItemCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = @" delete from MedicinesRetailDetail where RetailCode=@RetailCode and ItemCode=@ItemCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@RetailCode", SqlDbType.VarChar, 20);
                param[0].Value = sRetailCode;
                param[1] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[1].Value = sItemCode;
                return cn.ExecuteNonQuery(CommandType.Text, sql, param);
            }
            catch { return -2; }
        }

        public static Int32 DelAll(string sRetailCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@RetailCode", SqlDbType.VarChar, 20);
                param[0].Value = sRetailCode;
                param[1] = new SqlParameter("@iresult", SqlDbType.Int);
                param[1].Direction = ParameterDirection.Output;
                Int32 iResult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_DelAll_MedicinesRetail", param));
                return iResult;
            }
            catch { return -2; }
        }

        public static DataTable DT_ListRetail(string sfr, string sto, bool isCancel, bool isDone)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = @" select RetailCode,FullName,Birthyear,Address,Diagnosis,NumberOfDrugCoal,SerialNumber,InvoiceNumber,ExportDate,Paid,PatientCode,(case when PatientGender=1 then 'Nam' else N'Nữ'end) PatientGender,PatientAge,PatientMonth,TotalAmountReal from MedicinesRetail where CONVERT(date,ExportDate,103) >= CONVERT(date,'{0}',103) and CONVERT(date,ExportDate,103) <= CONVERT(date,'{1}',103) ";
                if (!isCancel)
                    sql += " and paid not in(-1) ";
                else
                    sql += " and paid in(-1) ";
                if (isDone)
                    sql += " and paid=(1)";
                return cn.ExecuteQuery(string.Format(sql, sfr, sto));
            }
            catch { }
            return null;
        }

        public static Int32 UpdAmountRealRetail(string retailCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = @" update MedicinesRetail set TotalAmount=(select sum(Amount) from MedicinesRetailDetail where RetailCode=@RetailCode),TotalAmountReal=(select sum(Amount) from MedicinesRetailDetail where RetailCode=@RetailCode) where RetailCode=@RetailCode";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RetailCode", SqlDbType.VarChar, 20);
                param[0].Value = retailCode;
                return cn.ExecuteNonQuery(CommandType.Text, sql, param);
            }
            catch { return -2; }
        }

        public static MedicinesRetailInf ObjRetail(string sRetailCode)
        {
            ConnectDB cn = new ConnectDB();
            MedicinesRetailInf inf = new MedicinesRetailInf();
            try
            {
                string sql = @" select RetailCode,FullName,Birthyear,Address,Diagnosis,NumberOfDrugCoal,SerialNumber,InvoiceNumber,ExportDate,EmployeeCode,Paid,STT,TotalAmount,TotalAmountReal,RateOther,RateUSD,RateSurcharge,TotalSurcharge,IntroCode,Cash,ExcessCash,VoucherCard,OtherCard,ExcessCashOther,EmployeeCodeDoctor,PatientGender,PatientAge,PatientMonth,PatientBirthday,MedicalRecordCode,PatientCode,PatientReceiveID,VAT from MedicinesRetail where RetailCode='{0}' ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sRetailCode), null);
                if (ireader.Read())
                {
                    inf.RetailCode = ireader.GetString(0);
                    inf.FullName = ireader.GetValue(1).ToString();
                    inf.Birthyear = ireader.GetValue(2).ToString();
                    inf.Address = ireader.GetValue(3).ToString();
                    inf.Diagnosis = ireader.GetValue(4).ToString();
                    inf.NumberOfDrugCoal = ireader.GetValue(5).ToString();
                    inf.SerialNumber = ireader.GetValue(6).ToString();
                    inf.InvoiceNumber = ireader.GetValue(7).ToString();
                    inf.ExportDate = ireader.GetDateTime(8);
                    inf.EmployeeCode = ireader.GetValue(9).ToString();
                    inf.Paid = ireader.GetInt32(10);
                    inf.STT = ireader.GetInt32(11);
                    inf.TotalAmount = ireader.GetDecimal(12);
                    inf.TotalAmountReal = ireader.GetDecimal(13);
                    inf.RateOther = ireader.GetDecimal(14);
                    inf.RateUSD = ireader.GetDecimal(15);
                    inf.RateSurcharge = ireader.GetDecimal(16);
                    inf.TotalSurcharge = ireader.GetDecimal(17);
                    inf.IntroCode = ireader.GetValue(18).ToString();
                    inf.Cash = ireader.GetDecimal(19);
                    inf.ExcessCash = ireader.GetDecimal(20);
                    inf.VoucherCard = ireader.GetValue(21).ToString();
                    inf.OtherCard = ireader.GetValue(22).ToString();
                    inf.ExcessCashOther = ireader.GetDecimal(23);
                    inf.EmployeeCodeDoctor = ireader.GetValue(24).ToString();
                    inf.PatientGender = ireader.GetInt32(25);
                    inf.PatientAge = ireader.GetInt32(26);
                    inf.PatientMonth = ireader.GetValue(27).ToString();
                    inf.PatientBirthday = ireader.GetDateTime(28);
                    inf.MedicalRecordCode = ireader.GetValue(29).ToString();
                    inf.PatientCode = ireader.GetValue(30).ToString();
                    inf.PatientReceiveID = Convert.ToDecimal(ireader.GetValue(31).ToString());
                    inf.VAT = ireader.GetInt32(32);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { }
            return inf;
        }

        public static List<MedicinesRetailDetailInf> ListRetailDetail(string sRetailCode)
        {
            ConnectDB cn = new ConnectDB();
            List<MedicinesRetailDetailInf> list = new List<MedicinesRetailDetailInf>();
            try
            {
                //select RetailCode,ItemCode,DateOfIssues,Quantity ,UnitPrice,Amount,RowIDInventoryGumshoe,RateBHYT,RepositoryCode,
                //Instruction,QuantityExport,Morning,Noon,Afternoon,Evening
                string sql = @" select RetailCode,ItemCode,DateOfIssues,Quantity,UnitPrice,Amount,RowIDInventoryGumshoe,RateBHYT,RepositoryCode,Instruction,QuantityExport,Morning,Noon,Afternoon,Evening from MedicinesRetail where RetailCode='{0}' ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sRetailCode), null);
                while (ireader.Read())
                {
                    MedicinesRetailDetailInf inf = new MedicinesRetailDetailInf();
                    inf.RetailCode = ireader.GetString(0);
                    inf.ItemCode = ireader.GetString(1);
                    if (ireader.GetString(2).ToString() != string.Empty)
                        inf.DateOfIssues = Convert.ToInt32(ireader.GetString(2).ToString());
                    else
                        inf.DateOfIssues = 0;
                    inf.Quantity = Convert.ToDecimal(ireader.GetString(3));
                    inf.UnitPrice = Convert.ToDecimal(ireader.GetString(4));
                    inf.Amount = Convert.ToDecimal(ireader.GetString(5));
                    inf.RowIDInventoryGumshoe = ireader.GetDecimal(6);
                    inf.RateBHYT = ireader.GetInt32(7);
                    inf.RepositoryCode = ireader.GetString(8);
                    inf.Instruction = ireader.GetString(9);
                    inf.QuantityExport = ireader.GetDecimal(10);
                    inf.Morning = ireader.GetString(11);
                    inf.Noon = ireader.GetString(12);
                    inf.Afternoon = ireader.GetString(13);
                    inf.Evening = ireader.GetString(14);
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }

            }
            catch { }
            return list;
        }

        public static DataTable rpt_MedicinesRetail(string retailCode, int paid)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = @" select a.RetailCode, FullName,a.IDate,a.Birthyear,a.Address,a.Diagnosis,a.NumberOfDrugCoal,a.SerialNumber,a.InvoiceNumber,b.EmployeeName,a.ExportDate,a.TotalAmount,a.TotalAmountReal,a.RateOther,a.RateUSD,a.RateSurcharge,a.TotalSurcharge,a.Cash,a.ExcessCash,a.ExcessCashOther,a.VoucherCard,a.OtherCard,c.IntroName,a.PatientReceiveClinic,convert(varchar(10),d.PatientBirthday,103) PatientBirthday,d.PatientMobile,a.VAT,((a.VAT*a.TotalAmountReal)/100) AmountVAT,(a.TotalAmountReal + ((a.VAT*a.TotalAmountReal)/100)) TotalAmountRealVAT, a.ExportDate
                                from MedicinesRetail a inner join Employee b on a.EmployeeCode=b.EmployeeCode left join Introducer c on a.IntroCode=c.IntroCode left join Patients d on a.PatientCode=d.PatientCode
                                where a.RetailCode in('{0}') and a.Paid={1}";
                dt = cn.ExecuteQuery(string.Format(sql, retailCode, paid));
            }//21/07/2016
            catch { }
            return dt;
        }

        public static DataTable rpt_MedicinesRetailDetail(string retailCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                //string sql = @" select a.ItemCode,b.ItemName,a.DateOfIssues,isnull(sum(a.Quantity),0) Quantity,isnull(sum(a.QuantityExport),0) QuantityExport,a.UnitPrice,isnull(sum(a.Amount),0) Amount,a.Instruction,d.UnitOfMeasureName
                //    from MedicinesRetailDetail a inner join Items b on a.ItemCode=b.ItemCode 
                //    inner join InventoryGumshoe c on a.RowIDInventoryGumshoe=c.RowID 
                //    inner join UnitOfMeasure d on b.UnitOfMeasureCode=d.UnitOfMeasureCode 
                //    where a.RetailCode in('{0}')
                //    group by a.ItemCode,b.ItemName,a.DateOfIssues,a.UnitPrice,a.Instruction,d.UnitOfMeasureName";
                //dt = cn.ExecuteQuery(string.Format(sql, sRetailCode));
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RetailCode", SqlDbType.VarChar, 15);
                param[0].Value = retailCode;
                dt = cn.CallProcedureTable(CommandType.StoredProcedure, "proMedicinesRetailDetail", param);
            }
            catch { }
            return dt;
        }

        public static Int32 Del_AfterInvoiceNumber(string sRetailCode, string sEmployee, string reason)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RetailCode", SqlDbType.VarChar, 20);
                param[0].Value = sRetailCode;
                param[1] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[1].Value = sEmployee;
                param[2] = new SqlParameter("@ReasonCancel", SqlDbType.NVarChar, 500);
                param[2].Value = reason;
                param[3] = new SqlParameter("@Result", SqlDbType.Int);
                param[3].Direction = ParameterDirection.Output;
                Int32 iResult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Del_Retail_SubRep", param));
                return iResult;
            }
            catch { return -2; }
        }

        public static DataTable DT_Exp_RetailForPatients(string sRepositoryCode, string sfrom, string sto, string sItemCode, int cancel)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[0].Value = sRepositoryCode;
                param[1] = new SqlParameter("@IDatefrom", SqlDbType.VarChar, 10);
                param[1].Value = sfrom;
                param[2] = new SqlParameter("@IDateto", SqlDbType.VarChar, 10);
                param[2].Value = sto;
                param[3] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[3].Value = sItemCode;
                param[4] = new SqlParameter("@Paid", SqlDbType.Int);
                param[4].Value = cancel;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_Report_View_RetailForPatients", param);
            }
            catch { return null; }
        }

        public static DataTable TableReportListRetail(string dateForm, string dateTo)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = @" select SUM(b.QuantityExport*b.UnitPrice) Amount,a.RetailCode,a.Paid,a.PatientReceiveID,a.FullName,a.Birthyear,a.Address,a.Diagnosis,CONVERT(date,a.ExportDate,103) ExportDate
                from MedicinesRetail a inner join MedicinesRetailDetail b on a.RetailCode=b.RetailCode
                where CONVERT(date,a.ExportDate,103) between CONVERT(date,'{0}',103) and CONVERT(date,'{1}',103) and a.Paid in(1,2) 
                and PatientReceiveID=0 and (MedicalRecordCode='' or MedicalRecordCode is null) and (PatientCode='' or PatientCode is null)
                group by a.RetailCode,a.RetailCode,a.Paid,a.PatientReceiveID,a.FullName,a.Birthyear,a.Address,a.Diagnosis,CONVERT(date,a.ExportDate,103) ";
                return cn.ExecuteQuery(string.Format(sql, dateForm, dateTo));
            }
            catch { }
            return null;
        }
        public static DataTable TableResultMedicinesRetailGroupForDoctor(string sPatientCode, string sFromdate, string sTodate, string sItemCode, string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                string sql = "";
                sql = @"select a.MedicalRecordCode,b.PatientCode,b.PatientName,[dbo].func_PatientOfAddressFull(b.PatientAddress,w.WardName,di.DistrictName,ca.ProvincialName) PatientAddress,b.PatientBirthyear,(case when b.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,sum(a1.Amount) Amount,CONVERT(date,a.IDate,103) PostingDate,CONVERT(date,d.CreateDate,103) InDate,a2.EmployeeName
                    from MedicinesRetail a inner join MedicinesRetailDetail a1 on a.RetailCode=a1.RetailCode inner join Patients b on a.PatientCode=b.PatientCode
                    inner join Items c on a1.ItemCode=c.ItemCode inner join UnitOfMeasure c1 on c.UnitOfMeasureCode=c1.UnitOfMeasureCode inner join PatientReceive d on a.PatientReceiveID=d.PatientReceiveID
                    left join Employee a2 on a.EmployeeCodeDoctor=a2.EmployeeCode left join Catalog_Ward w on b.WardCode=w.WardCode left join Catalog_District di on b.DistrictCode=di.DistrictCode left join Catalog_Provincial ca on b.ProvincialCode=ca.ProvincialCode
                    where 1=1 and a.Paid = 1 ";
                if (sPatientCode != string.Empty)
                    sql += " and a.PatientCode='" + sPatientCode + "'";
                if (sFromdate != string.Empty && sTodate != string.Empty)
                    sql += " and CONVERT(date,a.IDate,103) between CONVERT(date,'" + sFromdate + "',103) and CONVERT(date,'" + sTodate + "',103)";
                if (sItemCode != string.Empty)
                    sql += " and a1.ItemCode='" + sItemCode + "'";
                if (employeeCode != string.Empty)
                    sql += " and a.EmployeeCodeDoctor in(" + employeeCode + ")";
                sql += " group by a.MedicalRecordCode,b.PatientCode,b.PatientName,b.PatientAddress,b.PatientBirthyear,b.PatientGender,a.IDate,d.CreateDate,a2.EmployeeName,w.WardName,di.DistrictName,ca.ProvincialName,a.Paid ";
                dtResult = cn.ExecuteQuery(sql);
            }
            catch { }
            return dtResult;
        }
        public static DataTable TableResultMedicinesRetail(string sPatientCode, string sFromdate, string sTodate, string sItemCode, string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                string sql = "";
                sql = @" select a.MedicalRecordCode,b.PatientCode,b.PatientName,[dbo].func_PatientOfAddressFull(b.PatientAddress,b1.WardName,b2.DistrictName,b3.ProvincialName) PatientAddress,b.PatientBirthyear,(case when b.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,a1.ItemCode,c.ItemName,c1.UnitOfMeasureName,
                a1.Morning,a1.Noon,a1.Afternoon,a1.Evening,a1.Quantity,a1.Instruction,a1.UnitPrice,a1.Amount,CONVERT(date,a.IDate,103) PostingDate,a.Diagnosis as Symptoms,CONVERT(date,d.CreateDate,103) InDate
                from MedicinesRetail a inner join MedicinesRetailDetail a1 on a.RetailCode=a1.RetailCode inner join Patients b on a.PatientCode=b.PatientCode
                inner join Items c on a1.ItemCode=c.ItemCode inner join UnitOfMeasure c1 on c.UnitOfMeasureCode=c1.UnitOfMeasureCode inner join PatientReceive d on a.PatientReceiveID=d.PatientReceiveID
                left join Catalog_Ward b1 on b.WardCode=b1.WardCode left join Catalog_District b2 on b.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on b.ProvincialCode=b3.ProvincialCode
                where 1=1 and a.Paid = 1 ";
                if (sPatientCode != string.Empty)
                    sql += " and a.PatientCode='" + sPatientCode + "'";
                if (sFromdate != string.Empty && sTodate != string.Empty)
                    sql += " and CONVERT(date,a.IDate,103) between CONVERT(date,'" + sFromdate + "',103) and CONVERT(date,'" + sTodate + "',103)";
                if (sItemCode != string.Empty)
                    sql += " and a1.ItemCode='" + sItemCode + "'";
                if (employeeCode != string.Empty)
                    sql += " and a.EmployeeCodeDoctor in(" + employeeCode + ")";
                dtResult = cn.ExecuteQuery(sql);
            }
            catch { }
            return dtResult;
        }
        public static Int32 UpdVAT_InvoiceNumber(string retailCode, string invoiceNumber, int vat)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " update MedicinesRetail set InvoiceNumber=@InvoiceNumber,VAT=@VAT where RetailCode=@RetailCode";
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@InvoiceNumber", SqlDbType.VarChar, 50);
                param[0].Value = invoiceNumber;
                param[1] = new SqlParameter("@VAT", SqlDbType.Int);
                param[1].Value = vat;
                param[2] = new SqlParameter("@RetailCode", SqlDbType.VarChar, 20);
                param[2].Value = retailCode;
                return cn.ExecuteNonQuery(CommandType.Text, sql, param);
            }
            catch { return -2; }
        }
    }
}
