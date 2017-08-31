using ClinicModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ClinicDAL
{
    public class RealMedicinesForPatients_VTTH_AttachDAL
    {
        public static Int32 InsReal(RealMedicinesForPatients_VTTH_AttachInf info, ref decimal refID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[15];
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
                param[7] = new SqlParameter("@Status", SqlDbType.Int);
                param[7].Value = info.Status;
                param[8] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[8].Value = info.DepartmentCode;
                param[9] = new SqlParameter("@DateApproved", SqlDbType.DateTime);
                param[9].Value = info.DateApproved;
                param[10] = new SqlParameter("@ShiftWork", SqlDbType.Char, 2);
                param[10].Value = info.ShiftWork;
                param[11] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 15);
                param[11].Value = info.ServiceCode;
                param[12] = new SqlParameter("@SuggestedID", SqlDbType.Decimal);
                param[12].Value = info.SuggestedID;
                param[13] = new SqlParameter("@BanksAccountCode", SqlDbType.VarChar, 50);
                param[13].Value = info.BanksAccountCode;
                param[14] = new SqlParameter("@ResultRowID", SqlDbType.Decimal);
                param[14].Direction = ParameterDirection.Output;
                refID = Convert.ToDecimal(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_RealMedicinesForPatients_VTTH_Attach", param));
                if (refID > 0)
                    return 1;
                else
                    return 0;
                //return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_RealMedicinesForPatients", param);
            }
            catch (Exception ex) { return -2; }
        }

        public static Int32 InsRealDetail(RealMedicinesForPatients_VTTH_Attach_DetailInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[15];
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
                param[13] = new SqlParameter("@BanksAccountCode", SqlDbType.VarChar, 50);
                param[13].Value = info.BanksAccountCode;
                param[14] = new SqlParameter("@Paid", SqlDbType.Int);
                param[14].Value = info.Paid;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_RealMedicinesForPatients_VTTH_Attach_Detail", param);
            }
            catch { return -2; }
        }

        public static Int32 Del_RealMedicinesForPatients_VTTH_Attach_Detail(decimal dRealID, string sItemCode, decimal dRowID)
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
                return Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Del_RealMedicinesForPatients_VTTH_Attach_Detail", param));
            }
            catch { return -2; }
        }

        public static DataTable DTRealMedicinesForEmergency_VTTH_Attach_Detail(decimal dRealRowID)
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
                        from RealMedicinesForPatients_VTTH_Attach_Detail a inner join Items b on a.ItemCode=b.ItemCode 
                        inner join RealMedicinesForPatients_VTTH_Attach c on a.RealRowID=c.RowID inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode
                        where a.RealRowID in({0})
                        ";
                table = cn.ExecuteQuery(string.Format(sql, dRealRowID));
            }
            catch { }
            return table;
        }

        public static DataTable DTRealMedicinesForPatients_VTTH_Attach_Detail(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("RowID", typeof(decimal));
            dtResult.Columns.Add("RealRowID", typeof(string));
            dtResult.Columns.Add("ItemCode", typeof(string));
            dtResult.Columns.Add("Quantity", typeof(decimal));
            dtResult.Columns.Add("RowIDInventoryGumshoe", typeof(decimal));
            dtResult.Columns.Add("RepositoryCode", typeof(string));
            dtResult.Columns.Add("Checks", typeof(int));
            
            try
            {
                string sql = "";
                sql = " select a.RowID,a.RealRowID,a.ItemCode,a.Quantity,a.RowIDInventoryGumshoe,a.RepositoryCode, 1 as Checks from RealMedicinesForPatients_VTTH_Attach_Detail a inner join RealMedicinesForPatients_VTTH_Attach a1 on a1.RowID=a.RealRowID where a1.ServiceCode=@ServiceCode order by a.ItemCode asc ";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 15);
                param[0].Value = sCode;
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, param);
                while (ireader.Read())
                {
                    DataRow dr = dtResult.NewRow();
                    dr[0] = ireader.GetDecimal(0);
                    dr[1] = ireader.GetValue(1).ToString();
                    dr[2] = ireader.GetValue(2).ToString();
                    dr[3] = ireader.GetDecimal(3);
                    dr[4] = ireader.GetDecimal(4);
                    dr[5] = ireader.GetValue(5).ToString();  
                    dr[6] = ireader.GetInt32(6).ToString();
                    dtResult.Rows.Add(dr);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch (Exception ex) { }
            return dtResult;
        }
    }
}
