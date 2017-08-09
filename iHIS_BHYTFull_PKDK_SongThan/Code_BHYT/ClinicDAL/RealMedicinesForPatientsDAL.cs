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
    public class RealMedicinesForPatientsDAL
    {
        public static List<RealMedicinesForPatientsINF> ListForPatients(string sRefCode, decimal dPatientReceiveID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<RealMedicinesForPatientsINF> list = new List<RealMedicinesForPatientsINF>();
            try
            {
                string sql = "";
                sql = " select RowID,RefCode,PatientReceiveID,PatientCode,EmployeeCode,DateApproved,ObjectCode,PatientType,VoteRowID,Status,BanksAccountCode,DepartmentCode from RealMedicinesForPatients where RefCode='{0}' and PatientReceiveID ={1} and PatientCode='{2}'";
                //sql = " select RefCode,PatientReceiveID,PatientCode,EmployeeCode,DateApproved,ObjectCode,PatientType,VoteRowID,Status,BanksAccountCode,DepartmentCode from RealMedicinesForPatients where RefCode='{0}' and PatientReceiveID ={1} and PatientCode='{2}' order by DateApproved asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sRefCode, dPatientReceiveID, sPatientCode), null);
                while (ireader.Read())
                {
                    RealMedicinesForPatientsINF inf = new RealMedicinesForPatientsINF();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.RefCode = ireader.GetString(1);
                    inf.PatientReceiveID = ireader.GetDecimal(2);
                    inf.PatientCode = ireader.GetString(3);
                    inf.EmployeeCode = ireader.GetString(4);
                    inf.DateApproved = ireader.GetDateTime(5);
                    inf.ObjectCode = ireader.GetInt32(6);
                    inf.PatientType = ireader.GetInt32(7);
                    inf.VoteRowID = ireader.GetInt32(8);
                    inf.Status = ireader.GetInt32(9);
                    inf.BanksAccountCode = ireader.GetValue(10).ToString();
                    inf.DepartmentCode = ireader.GetValue(11).ToString();
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

        public static List<RealMedicinesForPatientsINF> ListForPatientsHistory(string sRefCode, decimal dPatientReceiveID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<RealMedicinesForPatientsINF> list = new List<RealMedicinesForPatientsINF>();
            try
            {
                string sql = "";
                //sql = " select RefCode,PatientReceiveID,PatientCode,DateApproved from RealMedicinesForPatients where RefCode='{0}' and PatientReceiveID ={1} and PatientCode='{2}' group by RefCode,PatientReceiveID,PatientCode,DateApproved order by DateApproved asc";
                sql = " select RefCode,PatientReceiveID,PatientCode,DateApproved,RowID from RealMedicinesForPatients where RefCode='{0}' and PatientReceiveID ={1} and PatientCode='{2}' order by DateApproved desc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sRefCode, dPatientReceiveID, sPatientCode), null);
                while (ireader.Read())
                {
                    RealMedicinesForPatientsINF inf = new RealMedicinesForPatientsINF();
                    inf.RefCode = ireader.GetString(0);
                    inf.PatientReceiveID = ireader.GetDecimal(1);
                    inf.PatientCode = ireader.GetString(2);
                    inf.DateApproved = ireader.GetDateTime(3);
                    inf.RowID = ireader.GetDecimal(4);
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

        public static Int32 InsReal(RealMedicinesForPatientsINF info, ref decimal refID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[13];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@RefCode", SqlDbType.VarChar, 20);
                param[1].Value = info.RefCode;
                param[2] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[2].Value = info.PatientReceiveID;
                param[3] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[3].Value = info.PatientCode;
                param[4] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[4].Value = info.EmployeeCode;
                param[5] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[5].Value = info.ObjectCode;
                param[6] = new SqlParameter("@PatientType", SqlDbType.Int);
                param[6].Value = info.PatientType;
                param[7] = new SqlParameter("@VoteRowID", SqlDbType.Int);
                param[7].Value = info.VoteRowID;
                param[8] = new SqlParameter("@Status", SqlDbType.Int);
                param[8].Value = info.Status;
                param[9] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[9].Value = info.DepartmentCode;
                param[10] = new SqlParameter("@DateApproved", SqlDbType.DateTime);
                param[10].Value = info.DateApproved;
                param[11] = new SqlParameter("@ShiftWork", SqlDbType.Char, 2);
                param[11].Value = info.ShiftWork;
                param[12] = new SqlParameter("@ResultRowID", SqlDbType.Decimal);
                param[12].Direction = ParameterDirection.Output;
                refID = Convert.ToDecimal(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_RealMedicinesForPatients", param));
                if (refID > 0)
                    return 1;
                else
                    return 0;
                //return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_RealMedicinesForPatients", param);
            }
            catch { return -2; }
        }

        public static Int32 InsRealDetail(RealMedicinesForPatientsDetailINF info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[13];
                param[0] = new SqlParameter("@RealRowID", SqlDbType.Decimal);
                param[0].Value = info.RealRowID;
                param[1] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[1].Value = info.ItemCode;
                param[2] = new SqlParameter("@Quantity", SqlDbType.Decimal);
                param[2].Value = info.Quantity;
                param[3] = new SqlParameter("@UnitPrice", SqlDbType.Decimal);
                param[3].Value = info.UnitPrice;
                param[4] = new SqlParameter("@SalesPrice", SqlDbType.Decimal);
                param[4].Value = info.SalesPrice;
                param[5] = new SqlParameter("@BHYTPrice", SqlDbType.Decimal);
                param[5].Value = info.BHYTPrice;
                param[6] = new SqlParameter("@Amount", SqlDbType.Decimal);
                param[6].Value = info.Amount;
                param[7] = new SqlParameter("@RowIDInventoryGumshoe", SqlDbType.Decimal);
                param[7].Value = info.RowIDInventoryGumshoe;
                param[8] = new SqlParameter("@RateBHYT", SqlDbType.Decimal);
                param[8].Value = info.RateBHYT;
                param[9] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[9].Value = info.ObjectCode;
                param[10] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[10].Value = info.RepositoryCode;
                param[11] = new SqlParameter("@RowIDold", SqlDbType.Decimal);
                param[11].Value = info.RowID;
                param[12] = new SqlParameter("@Instruction", SqlDbType.NVarChar, 500);
                param[12].Value = info.Instruction;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_RealMedicinesForPatientsDetail", param);
            }
            catch { return -2; }
        }

        public static Int32 UpdReal_Bank(string sBankCode, string sRefCode, decimal dPatientReceive, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " update RealMedicinesForPatients set BanksAccountCode=@BanksAccountCode where RefCode=@RefCode and PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode and (BanksAccountCode is null or BanksAccountCode='') ";
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@BanksAccountCode", SqlDbType.VarChar, 50);
                param[0].Value = sBankCode;
                param[1] = new SqlParameter("@RefCode", SqlDbType.VarChar, 20);
                param[1].Value = sRefCode;
                param[2] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[2].Value = dPatientReceive;
                param[3] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[3].Value = sPatientCode;
                return cn.ExecuteNonQuery(CommandType.Text, sql, param);
            }
            catch { return -2; }
        }

        public static Int32 DelRealDetailAll(decimal dRealID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Result", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RealRowID", SqlDbType.Decimal);
                param[1].Value = dRealID;
                return Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Del_RealMedicinesDetail", param));
            }
            catch { return -2; }
        }

        public static Int32 DelRealDetailOnly(decimal dRealID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Result", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RealRowID", SqlDbType.Decimal);
                param[1].Value = dRealID;
                return Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Del_RealMedicinesDetailOnlyTable", param));
            }
            catch { return -2; }
        }

        public static Int32 DelRealDetailForItems(decimal dRealID,string sItemCode, decimal dRowID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@Result", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RealRowID", SqlDbType.Decimal);
                param[1].Value = dRealID;
                param[2] = new SqlParameter("@ItemCode", SqlDbType.VarChar);
                param[2].Value = sItemCode;
                param[3] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[3].Value = dRowID;
                return Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Del_RealMedicinesDetailItemCode", param));
            }
            catch { return -2; }
        }

        public static DataTable DTRealMedicines(string sRefCode, Int32 iObjectCode, string sDepartCode, Int32 iGroup, DateTime dtNow)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RealRowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                dt.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
                dt.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                dt.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                dt.Columns.Add(new DataColumn("RateBHYT", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Instruction", typeof(string)));
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ItemName", typeof(string)));
                string sql = "";
                sql = @" select a.RealRowID,a.ItemCode,a.Quantity,a.UnitPrice,a.Amount,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.RateBHYT,a.ObjectCode,a.Instruction,a.RowID,b.ItemName
                        from RealMedicinesForPatientsDetail a inner join Items b on a.ItemCode=b.ItemCode 
                        inner join RealMedicinesForPatients c on a.RealRowID=c.RowID inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode
                        where c.RefCode in('{0}') and c.ObjectCode in({1}) 
                        and a.RepositoryCode in(
	                        select d1.RepositoryCode 
	                        from DepartmentForRepository d1 inner join RepositoryCatalog d2 on d1.RepositoryCode=d2.RepositoryCode
	                        where d1.DepartmentCode='{2}' and d2.RepositoryGroupCode in({3})
                        ) and CONVERT(date,c.DateApproved,103)=CONVERT(date,'{4}',103)
                        ";
                dt = cn.ExecuteQuery(string.Format(sql, sRefCode, iObjectCode, sDepartCode, iGroup, dtNow.ToString("dd/MM/yyyy")));
                //IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sRefCode, iObjectCode, sDepartCode, iGroup, dtNow.ToString("dd/MM/yyyy")), null);
                //while (ireader.Read())
                //{
                //    DataRow dr;
                //    dr = dt.NewRow();
                //    dr.BeginEdit();
                //    dr[0] = ireader.GetDecimal(0);
                //    dr[1] = ireader.GetString(1);
                //    dr[2] = ireader.GetDecimal(2);
                //    dr[3] = ireader.GetDecimal(3);
                //    dr[4] = ireader.GetDecimal(4);
                //    dr[5] = ireader.GetValue(5).ToString();
                //    dr[6] = ireader.GetValue(6).ToString();
                //    dr[7] = ireader.GetValue(7).ToString();
                //    dr[8] = ireader.GetDecimal(8);
                //    dr[9] = ireader.GetInt32(9);
                //    dr[10] = ireader.GetValue(10).ToString();
                //    dr[11] = ireader.GetDecimal(11);
                //    dr[12] = ireader.GetValue(12).ToString();
                //    dr.EndEdit();
                //    dt.Rows.Add(dr);
                //}
                //if (!ireader.IsClosed)
                //{
                //    ireader.Close();
                //    ireader.Dispose();
                //}
            }
            catch { }
            return dt;
        }
                
        public static DataTable DTRealMedicines(string sRefCode, Int32 iObjectCode, string sDepartCode, Int32 iGroup)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RealRowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                dt.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
                dt.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                dt.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                dt.Columns.Add(new DataColumn("RateBHYT", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Instruction", typeof(string)));
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ItemName", typeof(string)));
                string sql = "";
                sql = @" select a.RealRowID,a.ItemCode,a.Quantity,a.UnitPrice,a.Amount,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.RateBHYT,a.ObjectCode,a.Instruction,a.RowID,b.ItemName
                        from RealMedicinesForPatientsDetail a inner join Items b on a.ItemCode=b.ItemCode 
                        inner join RealMedicinesForPatients c on a.RealRowID=c.RowID inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode
                        where c.RefCode in('{0}') and c.ObjectCode in({1}) 
                        and a.RepositoryCode in(
	                        select d1.RepositoryCode 
	                        from DepartmentForRepository d1 inner join RepositoryCatalog d2 on d1.RepositoryCode=d2.RepositoryCode
	                        where d1.DepartmentCode='{2}' and d2.RepositoryGroupCode in({3})
                        ) 
                        ";
                dt = cn.ExecuteQuery(string.Format(sql, sRefCode, iObjectCode, sDepartCode, iGroup));
            }
            catch { }
            return dt;
        }

        public static DataTable DTRealMedicinesForEmergency(string sRefCode, Int32 iObjectCode, string sDepartCode, Int32 iGroup, DateTime dtNow, ref decimal dRealID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                tableResult.Columns.Add(new DataColumn("RealRowID", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                tableResult.Columns.Add(new DataColumn("RateBHYT", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("Instruction", typeof(string)));
                tableResult.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("ItemName", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Chon", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("New", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("SalesPrice", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("BHYTPrice", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("ListBHYT", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("UsageCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Paid", typeof(Int32)));
                string sql = string.Empty;
                sql = @" select a.RealRowID,a.ItemCode,a.Quantity,a.UnitPrice,a.Amount,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.RateBHYT,a.ObjectCode,a.Instruction,a.RowID,b.ItemName, 0 as [Chon], 1 as [New],a.SalesPrice,a.BHYTPrice,b.ListBHYT,b.UsageCode,a.Paid
                        from RealMedicinesForPatientsDetail a inner join Items b on a.ItemCode=b.ItemCode 
                        inner join RealMedicinesForPatients c on a.RealRowID=c.RowID inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode
                        where c.RefCode in('{0}') and c.ObjectCode in({1}) 
                        and a.RepositoryCode in(
	                        select d1.RepositoryCode 
	                        from DepartmentForRepository d1 inner join RepositoryCatalog d2 on d1.RepositoryCode=d2.RepositoryCode
	                        where d1.DepartmentCode='{2}' and d2.RepositoryGroupCode in({3})
                        ) and CONVERT(date,c.DateApproved,103)=CONVERT(date,'{4}',103) and CONVERT(char(5),c.DateApproved,114)='{5}'
                        ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sRefCode, iObjectCode, sDepartCode, iGroup, dtNow.ToString("dd/MM/yyyy"), dtNow.ToString("HH:mm")), null);
                while (ireader.Read())
                {
                    if (dRealID <= 0)
                        dRealID = ireader.GetDecimal(0);
                    DataRow row = tableResult.NewRow();
                    row[0] = ireader.GetDecimal(0);
                    row[1] = ireader.GetValue(1).ToString();
                    row[2] = ireader.GetDecimal(2);
                    row[3] = ireader.GetDecimal(3);
                    row[4] = ireader.GetDecimal(4);
                    row[5] = ireader.GetValue(5).ToString();
                    row[6] = ireader.GetValue(6).ToString();
                    row[7] = ireader.GetValue(7).ToString();
                    row[8] = ireader.GetDecimal(8);
                    row[9] = ireader.GetInt32(9);
                    row[10] = ireader.GetValue(10).ToString();
                    row[11] = ireader.GetDecimal(11);
                    row[12] = ireader.GetValue(12).ToString();
                    row[13] = Convert.ToInt32(ireader.GetValue(13).ToString());
                    row[14] = Convert.ToInt32(ireader.GetValue(14).ToString());
                    row[15] = ireader.GetDecimal(15);
                    row[16] = ireader.GetDecimal(16);
                    row[17] = Convert.ToInt32(ireader.GetValue(17).ToString());
                    row[18] = ireader.GetValue(18).ToString();
                    row[19] = Convert.ToInt32(ireader.GetValue(19).ToString());
                    tableResult.Rows.Add(row);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { }
            return tableResult;
        }

        public static DataTable DTRealMedicinesForEmergency(decimal dRealRowID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable table = new DataTable();
            try
            {
                table.Columns.Add(new DataColumn("RealRowID", typeof(decimal)));
                table.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                table.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
                table.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
                table.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                table.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                table.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                table.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                table.Columns.Add(new DataColumn("RateBHYT", typeof(decimal)));
                table.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                table.Columns.Add(new DataColumn("Instruction", typeof(string)));
                table.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                table.Columns.Add(new DataColumn("ItemName", typeof(string)));
                table.Columns.Add(new DataColumn("Chon", typeof(Int32)));
                table.Columns.Add(new DataColumn("New", typeof(Int32)));
                table.Columns.Add(new DataColumn("SalesPrice", typeof(decimal)));
                table.Columns.Add(new DataColumn("BHYTPrice", typeof(decimal)));
                table.Columns.Add(new DataColumn("ListBHYT", typeof(Int32)));
                table.Columns.Add(new DataColumn("UsageCode", typeof(string)));
                table.Columns.Add(new DataColumn("Paid", typeof(Int32)));
                string sql = string.Empty;
                sql = @" select a.RealRowID,a.ItemCode,a.Quantity,a.UnitPrice,a.Amount,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.RateBHYT,a.ObjectCode,a.Instruction,a.RowID,b.ItemName, 0 as [Chon], 1 as [New],a.SalesPrice,a.BHYTPrice,b.ListBHYT,b.UsageCode,a.Paid
                        from RealMedicinesForPatientsDetail a inner join Items b on a.ItemCode=b.ItemCode 
                        inner join RealMedicinesForPatients c on a.RealRowID=c.RowID inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode
                        where a.RealRowID in({0})
                        ";
                table = cn.ExecuteQuery(string.Format(sql, dRealRowID));
            }
            catch { }
            return table;
        }

        public static DataTable DTRealMedicinesForEmergencyCoppy(decimal dRealRowID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RealRowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                dt.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
                dt.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                dt.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                dt.Columns.Add(new DataColumn("RateBHYT", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Instruction", typeof(string)));
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ItemName", typeof(string)));
                dt.Columns.Add(new DataColumn("Chon", typeof(Int32)));
                dt.Columns.Add(new DataColumn("New", typeof(Int32)));
                dt.Columns.Add(new DataColumn("UsageCode", typeof(string)));
                dt.Columns.Add(new DataColumn("Paid", typeof(Int32)));
                //dt.Columns.Add(new DataColumn("SalesPrice", typeof(decimal)));
                //dt.Columns.Add(new DataColumn("BHYTPrice", typeof(decimal)));
                string sql = string.Empty;
                sql = @" select a.RealRowID,a.ItemCode,a.Quantity,a.UnitPrice,a.Amount,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.RateBHYT,a.ObjectCode,a.Instruction,a.RowID,b.ItemName, 0 as Chon, 0 as [New],b.UsageCode
                        from RealMedicinesForPatientsDetail a inner join Items b on a.ItemCode=b.ItemCode 
                        inner join RealMedicinesForPatients c on a.RealRowID=c.RowID inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode
                        where a.RealRowID in({0})
                        ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dRealRowID), null);
                while (ireader.Read())
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = ireader.GetDecimal(0);
                    dr[1] = ireader.GetString(1);
                    dr[2] = ireader.GetDecimal(2);
                    dr[3] = ireader.GetDecimal(3);
                    dr[4] = ireader.GetDecimal(4);
                    dr[5] = ireader.GetValue(5).ToString();
                    dr[6] = ireader.GetValue(6).ToString();
                    dr[7] = ireader.GetValue(7).ToString();
                    dr[8] = ireader.GetDecimal(8);
                    dr[9] = ireader.GetInt32(9);
                    dr[10] = ireader.GetValue(10).ToString();
                    dr[11] = ireader.GetDecimal(11);
                    dr[12] = ireader.GetValue(12).ToString();
                    dr[13] = 0;
                    dr[14] = 0;
                    dr[15] = ireader.GetValue(15).ToString();
                    dr[16] = 0;
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

        public static DataTable DTRealMedicinesCoppy(string sRefCode, Int32 iObjectCode, string sDepartCode, Int32 iGroup, string dtNow)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RealRowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                dt.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
                dt.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                dt.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                dt.Columns.Add(new DataColumn("RateBHYT", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Instruction", typeof(string)));
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ItemName", typeof(string)));
                dt.Columns.Add(new DataColumn("Chon", typeof(Int32)));
                string sql = "";
                sql = @" select 0 as RealRowID,a.ItemCode,a.Quantity,a.UnitPrice,a.Amount,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.RateBHYT,a.ObjectCode,a.Instruction,a.RowID,b.ItemName,0 as [Chon]
                        from RealMedicinesForPatientsDetail a inner join Items b on a.ItemCode=b.ItemCode 
                        inner join RealMedicinesForPatients c on a.RealRowID=c.RowID inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode
                        where c.RefCode in('{0}') and c.ObjectCode in({1}) 
                        and a.RepositoryCode in(
	                        select d1.RepositoryCode 
	                        from DepartmentForRepository d1 inner join RepositoryCatalog d2 on d1.RepositoryCode=d2.RepositoryCode
	                        where d1.DepartmentCode='{2}' and d2.RepositoryGroupCode in({3})
                        ) and CONVERT(date,c.DateApproved,103)=CONVERT(date,'{4}',103)
                        ";
                dt = cn.ExecuteQuery(string.Format(sql, sRefCode, iObjectCode, sDepartCode, iGroup, dtNow));
                //IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sRefCode, iObjectCode, sDepartCode, iGroup, dtNow), null);
                //while (ireader.Read())
                //{ 
                //    DataRow dr;
                //    dr = dt.NewRow();
                //    dr.BeginEdit();
                //    dr[0] = Convert.ToDecimal(ireader.GetValue(0));
                //    dr[1] = ireader.GetString(1);
                //    dr[2] = ireader.GetDecimal(2);
                //    dr[3] = ireader.GetDecimal(3);
                //    dr[4] = ireader.GetDecimal(4);
                //    dr[5] = ireader.GetValue(5).ToString();
                //    dr[6] = ireader.GetValue(6).ToString();
                //    dr[7] = ireader.GetValue(7).ToString();
                //    dr[8] = ireader.GetDecimal(8);
                //    dr[9] = ireader.GetInt32(9);
                //    dr[10] = ireader.GetValue(10).ToString();
                //    dr[11] = ireader.GetDecimal(11);
                //    dr[12] = ireader.GetValue(12).ToString();
                //    dr[13] = 0;
                //    dr.EndEdit();
                //    dt.Rows.Add(dr);
                //}
                //if (!ireader.IsClosed)
                //{
                //    ireader.Close();
                //    ireader.Dispose();
            }
            catch { dt=null; }
            return dt;
        }

        public static DataTable DT_RealMedicinesEmergency(string sMedicalEmergencyCode, string sPatientCode, decimal dPatientReceiveID, Int32 patientType)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@MedicalEmergencyCode", SqlDbType.VarChar, 50);
                param[0].Value = sMedicalEmergencyCode;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = sPatientCode;
                param[2] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[2].Value = dPatientReceiveID;
                param[3] = new SqlParameter("@PatientType", SqlDbType.Int);
                param[3].Value = patientType;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_RealMedicinesEmergency", param);
            }
            catch { return null; }
        }

        public static DataTable DT_RealMedicinesEmergencyDetail(string sMedicalEmergencyCode, string sPatientCode, decimal dPatientReceiveID, DateTime refDate)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@MedicalEmergencyCode", SqlDbType.VarChar, 50);
                param[0].Value = sMedicalEmergencyCode;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = sPatientCode;
                param[2] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[2].Value = dPatientReceiveID;
                param[3] = new SqlParameter("@refDate", SqlDbType.Date);
                param[3].Value = refDate;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_RealMedicinesEmergencyDetail", param);
            }
            catch { return null; }
        }

        public static DataTable DT_RealMedicinesEmergencyDetail(decimal realRowID, int objectCode, bool groupby)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RealRowID", SqlDbType.Decimal);
                param[0].Value = realRowID;
                param[1] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[1].Value = objectCode;
                param[2] = new SqlParameter("@GroupBy", SqlDbType.Int);
                param[2].Value = groupby ? 1 : 0;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_RealMedicinesEmergencyDetail_ForRealID", param);
            }
            catch { return null; }
        }

        public static DataTable DTTemplateNorms(string sDepartCode, Int32 iGroup,decimal RowIDLab)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RealRowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                dt.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
                dt.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                dt.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                dt.Columns.Add(new DataColumn("RateBHYT", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Instruction", typeof(string)));
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("ItemName", typeof(string)));
                string sql = "";
                sql = @" select a.ItemCode,a.Quantity,a2.UnitPrice,(a.Quantity*a2.UnitPrice) as Amount,a2.UnitOfMeasureCode,b.RepositoryCode,b.RepositoryName,a2.RateBHYT,a.Instruction,a2.ItemName
                        from TemplateItemNormsDetail a inner join TemplateItemNorms a1 on a.NormsCode=a1.NormsCode
                        inner join
                        (select a.ItemCode,a.RepositoryCode,b.RepositoryName from InventoryGeneral a inner join RepositoryCatalog b on a.RepositoryCode=b.RepositoryCode where a.RepositoryCode in(
	                        select d1.RepositoryCode 
                            from DepartmentForRepository d1 inner join RepositoryCatalog d2 on d1.RepositoryCode=d2.RepositoryCode
                            where d1.DepartmentCode=@DepartmentCode and d2.RepositoryGroupCode in(@RepositoryGroupCode)) and AmountEnd>0 ) b on a.ItemCode=b.ItemCode
                         inner join Items a2 on a.ItemCode=a2.ItemCode
                        where a1.ServiceCode in(select distinct ServiceCode from ServiceLaboratoryDetail where RowIDLaboratoryEnTry in(@RowIDLaboratoryEnTry))
                        ";
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[0].Value = sDepartCode;
                param[1] = new SqlParameter("@RepositoryGroupCode", SqlDbType.Int);
                param[1].Value = iGroup;
                param[2] = new SqlParameter("@RowIDLaboratoryEnTry", SqlDbType.Decimal);
                param[2].Value = RowIDLab;
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, param);
                while (ireader.Read())
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = 0;
                    dr[1] = ireader.GetString(0);
                    dr[2] = ireader.GetDecimal(1);
                    dr[3] = ireader.GetDecimal(2);
                    dr[4] = ireader.GetDecimal(3);
                    dr[5] = ireader.GetValue(4).ToString();
                    dr[6] = ireader.GetValue(5).ToString();
                    dr[7] = ireader.GetValue(6).ToString();
                    dr[8] = ireader.GetDecimal(7);
                    dr[9] = 5;
                    dr[10] = ireader.GetValue(8).ToString();
                    dr[11] = 0;
                    dr[12] = ireader.GetValue(9).ToString();
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

        public static DataTable hsba_RealMedicines(decimal dReceiveID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " select RowID,RefCode,PatientReceiveID,PatientCode,EmployeeCode,DateApproved,ObjectCode,PatientType,VoteRowID,Status,BanksAccountCode,DepartmentCode from RealMedicinesForPatients where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = dReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = sPatientCode;
                return cn.CallProcedureTable(CommandType.Text, sql, param);
            }
            catch { return null; }
        }

        public static DataTable hsba_RealMedicinesdetail(decimal dReceiveID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " select a.RowID,a.RealRowID,a.ItemCode,a.Instruction,a.Quantity,a.UnitPrice,a.SalesPrice,a.BHYTPrice,a.Amount,a.IDate,a.RowIDInventoryGumshoe,a.RateBHYT,a.ObjectCode,a.RepositoryCode from RealMedicinesForPatientsDetail a inner join RealMedicinesForPatients b on a.RealRowID=b.RowID where b.PatientReceiveID=@PatientReceiveID and b.PatientCode=@PatientCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = dReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = sPatientCode;
                return cn.CallProcedureTable(CommandType.Text, sql, param);
            }
            catch { return null; }
        }

    }
}
