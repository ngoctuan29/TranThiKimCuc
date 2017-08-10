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
    public class MedicalRecord_DAL
    {

        public static DataTable DTMedicalRecord(string sMedicalCode, Int32 iObjectCode, string sDepartCode, string repositoryGroup, DateTime dtNow)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("MedicalRecordCode", typeof(string)));
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
                dt.Columns.Add(new DataColumn("Status", typeof(int)));
                dt.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                dt.Columns.Add(new DataColumn("ItemName", typeof(string)));
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("DoseOf", typeof(Int32)));
                dt.Columns.Add(new DataColumn("DoseOfPills", typeof(string)));
                dt.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                dt.Columns.Add(new DataColumn("RateBHYT", typeof(Int32)));
                string sql = string.Empty;
                sql = @" select a.MedicalRecordCode,a.ItemCode,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening,
                        a.Quantity,a.Instruction,a.UnitPrice,a.Amount,a.Status,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.ItemName,a.RowID,a.DoseOf,a.DoseOfPills,a.ObjectCode,b.RateBHYT
                        from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode 
                        inner join MedicalRecord c on a.MedicalRecordCode=c.MedicalRecordCode inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode
                        where a.MedicalRecordCode in('{0}') and c.ObjectCode in({1}) 
                        and a.RepositoryCode in(
	                        select d1.RepositoryCode 
	                        from DepartmentForRepository d1 inner join RepositoryCatalog d2 on d1.RepositoryCode=d2.RepositoryCode
	                        where d1.DepartmentCode='{2}' and d2.RepositoryGroupCode in({3})
                        ) and CONVERT(date,a.PostingDate,103)=CONVERT(date,'{4}',103)
                        ";
                dt = cn.ExecuteQuery(string.Format(sql, sMedicalCode, iObjectCode, sDepartCode, repositoryGroup, dtNow.ToString("dd/MM/yyyy")));
            }
            catch { }
            return dt;
        }

        public static DataTable DTMedicalRecord(string sMedicalCode, Int32 iObjectCode, string sDepartCode, string repositoryGroup, int status)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                tableResult.Columns.Add(new DataColumn("MedicalRecordCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("DateOfIssues", typeof(int)));
                tableResult.Columns.Add(new DataColumn("Morning", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Noon", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Afternoon", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Evening", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("Instruction", typeof(string)));
                tableResult.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("Status", typeof(int)));
                tableResult.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                tableResult.Columns.Add(new DataColumn("ItemName", typeof(string)));
                tableResult.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("DoseOf", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("DoseOfPills", typeof(string)));
                tableResult.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("RateBHYT", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("RepositoryGroupCode", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("UsageCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("SODKGP", typeof(string)));
                tableResult.Columns.Add(new DataColumn("UnitOfMeasureCode_Medi", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Converted_Medi", typeof(Boolean)));
                string sql = string.Empty;
                sql = @" select a.MedicalRecordCode,a.ItemCode,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening,
                        a.Quantity,a.Instruction,a.UnitPrice,a.Amount,a.Status,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.ItemName,a.RowID,a.DoseOf,a.DoseOfPills,a.ObjectCode,b.RateBHYT,d.RepositoryGroupCode,b.UsageCode,b.SODKGP,a.UnitOfMeasureCode_Medi,b.Converted_Medi
                        from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode inner join MedicalRecord c on a.MedicalRecordCode=c.MedicalRecordCode inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode
                        where a.MedicalRecordCode in('{0}') and c.ObjectCode in({1}) 
                        and a.RepositoryCode in(
	                        select d1.RepositoryCode 
	                        from DepartmentForRepository d1 inner join RepositoryCatalog d2 on d1.RepositoryCode=d2.RepositoryCode
	                        where d1.DepartmentCode='{2}' and d2.RepositoryGroupCode in({3})
                        ) and a.Status={4}";
                tableResult = cn.ExecuteQuery(string.Format(sql, sMedicalCode, iObjectCode, sDepartCode, repositoryGroup, status));
            }
            catch { }
            return tableResult;
        }

        public static DataTable DTMedicalRecord(string sMedicalCode, Int32 iObjectCode, string sDepartCode, string repositoryGroup)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                tableResult.Columns.Add(new DataColumn("MedicalRecordCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("DateOfIssues", typeof(int)));
                tableResult.Columns.Add(new DataColumn("Morning", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Noon", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Afternoon", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Evening", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("Instruction", typeof(string)));
                tableResult.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("Status", typeof(int)));
                tableResult.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                tableResult.Columns.Add(new DataColumn("ItemName", typeof(string)));
                tableResult.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("DoseOf", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("DoseOfPills", typeof(string)));
                tableResult.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("RateBHYT", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("RepositoryGroupCode", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("UsageCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("SODKGP", typeof(string)));
                tableResult.Columns.Add(new DataColumn("UnitOfMeasureCode_Medi", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Converted_Medi", typeof(Boolean)));
                string sql = string.Empty;
                sql = @" select a.MedicalRecordCode,a.ItemCode,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening,
                        a.Quantity,a.Instruction,a.UnitPrice,a.Amount,a.Status,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.ItemName,a.RowID,a.DoseOf,a.DoseOfPills,a.ObjectCode,b.RateBHYT,d.RepositoryGroupCode,b.UsageCode,b.SODKGP,a.UnitOfMeasureCode_Medi,b.Converted_Medi
                        from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode inner join MedicalRecord c on a.MedicalRecordCode=c.MedicalRecordCode inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode
                        where a.MedicalRecordCode in('{0}') and c.ObjectCode in({1}) 
                        and a.RepositoryCode in(
	                        select d1.RepositoryCode 
	                        from DepartmentForRepository d1 inner join RepositoryCatalog d2 on d1.RepositoryCode=d2.RepositoryCode
	                        where d1.DepartmentCode='{2}' and d2.RepositoryGroupCode in({3})
                        ) ";
                tableResult = cn.ExecuteQuery(string.Format(sql, sMedicalCode, iObjectCode, sDepartCode, repositoryGroup));
            }
            catch { }
            return tableResult;
        }
        public static DataTable DTMedicalRecordForSuggestedID(decimal receiptID, string repositoryGroup)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                tableResult.Columns.Add(new DataColumn("MedicalRecordCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("DateOfIssues", typeof(int)));
                tableResult.Columns.Add(new DataColumn("Morning", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Noon", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Afternoon", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Evening", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("Instruction", typeof(string)));
                tableResult.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("Status", typeof(int)));
                tableResult.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                tableResult.Columns.Add(new DataColumn("ItemName", typeof(string)));
                tableResult.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("DoseOf", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("DoseOfPills", typeof(string)));
                tableResult.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("RateBHYT", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("RepositoryGroupCode", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("UsageCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("SODKGP", typeof(string)));
                tableResult.Columns.Add(new DataColumn("UnitOfMeasureCode_Medi", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Converted_Medi", typeof(Boolean)));
                tableResult.Columns.Add(new DataColumn("isChecked", typeof(Boolean)));
                string sql = string.Empty;
                sql = @" select a.MedicalRecordCode,a.ItemCode,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening,
                        a.Quantity,a.Instruction,a.UnitPrice,a.Amount,a.Status,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.ItemName,a.RowID,a.DoseOf,a.DoseOfPills,a.ObjectCode,b.RateBHYT,d.RepositoryGroupCode,b.UsageCode,b.SODKGP,a.UnitOfMeasureCode_Medi,b.Converted_Medi
                        from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode inner join MedicalRecord c on a.MedicalRecordCode=c.MedicalRecordCode inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode
                        where c.ReceiptID ={0} 
                        and a.RepositoryCode in(
	                        select d1.RepositoryCode 
	                        from DepartmentForRepository d1 inner join RepositoryCatalog d2 on d1.RepositoryCode=d2.RepositoryCode
	                        where d2.RepositoryGroupCode in({1})
                        ) ";
                tableResult = cn.ExecuteQuery(string.Format(sql, receiptID, repositoryGroup));
            }
            catch { }
            return tableResult;
        }
        public static DataTable DTMedicalAttachItem(string serviceCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                tableResult.Columns.Add(new DataColumn("MedicalRecordCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("DateOfIssues", typeof(int)));
                tableResult.Columns.Add(new DataColumn("Morning", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Noon", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Afternoon", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Evening", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("Instruction", typeof(string)));
                tableResult.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("Status", typeof(int)));
                tableResult.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                tableResult.Columns.Add(new DataColumn("ItemName", typeof(string)));
                tableResult.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("DoseOf", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("DoseOfPills", typeof(string)));
                tableResult.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("RateBHYT", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("RepositoryGroupCode", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("UsageCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("SODKGP", typeof(string)));
                tableResult.Columns.Add(new DataColumn("UnitOfMeasureCode_Medi", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Converted_Medi", typeof(Boolean)));
                tableResult.Columns.Add(new DataColumn("isChecked", typeof(Boolean)));
                string sql = string.Empty;
                sql = @" select '' as MedicalRecordCode,a.ItemCode,1 as DateOfIssues,'' as Morning,'' as Noon,'' as Afternoon,'' as Evening,
                        a.Quantity,a.Note as Instruction,b.SalesPrice as UnitPrice,(a.Quantity * b.SalesPrice) Amount,0 as Status,b.UnitOfMeasureCode,'' as RepositoryCode,'' as RepositoryName,b.ItemName,0 as RowID,0 as DoseOf,'' DoseOfPills,a.ObjectCode,b.RateBHYT,'' as RepositoryGroupCode,b.UsageCode,b.SODKGP,b.UnitOfMeasureCode_Medi,b.Converted_Medi,0 as isChecked
                        from Service_Item_Attach a inner join Items b on a.ItemCode=b.ItemCode 
                        where a.ServiceCode ='{0}'
                        ";
                tableResult = cn.ExecuteQuery(string.Format(sql, serviceCode));
            }
            catch { }
            return tableResult;
        }

        public static DataTable DTMedicalRecord(string sMedicalCode, Int32 iObjectCode, string sDepartCode, Int32 iGroup, bool bCheck, Int32 typeMedical)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("MedicalRecordCode", typeof(string)));
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
                dt.Columns.Add(new DataColumn("Status", typeof(int)));
                dt.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                dt.Columns.Add(new DataColumn("ItemName", typeof(string)));
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("PostingDate", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("Chon", typeof(Int32)));
                dt.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                dt.Columns.Add(new DataColumn("RateBHYT", typeof(Int32)));

                string sql = string.Empty;
                sql = @" select a.MedicalRecordCode,a.ItemCode,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening,
                        a.Quantity,a.Instruction,a.UnitPrice,a.Amount,a.Status,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.ItemName,a.RowID,a.PostingDate,a.New,a.ObjectCode,b.RateBHYT
                        from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode 
                        inner join MedicalRecord c on a.MedicalRecordCode=c.MedicalRecordCode inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode
                        where a.MedicalRecordCode in('{0}') and c.ObjectCode in({1}) 
                        and a.RepositoryCode in(
	                        select d1.RepositoryCode 
	                        from DepartmentForRepository d1 inner join RepositoryCatalog d2 on d1.RepositoryCode=d2.RepositoryCode
	                        where d1.DepartmentCode='{2}' and d2.RepositoryGroupCode in({3})
                        ) and c.TypeMedical in({4})
                        ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sMedicalCode, iObjectCode, sDepartCode, iGroup, typeMedical), null);
                while (ireader.Read())
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = ireader.GetString(0);
                    dr[1] = ireader.GetString(1);
                    dr[2] = ireader.GetInt32(2);
                    dr[3] = ireader.GetValue(3).ToString();
                    dr[4] = ireader.GetValue(4).ToString();
                    dr[5] = ireader.GetValue(5).ToString();
                    dr[6] = ireader.GetValue(6).ToString();
                    dr[7] = ireader.GetDecimal(7);
                    dr[8] = ireader.GetValue(8).ToString();
                    dr[9] = ireader.GetDecimal(9);
                    dr[10] = ireader.GetDecimal(10);
                    dr[11] = ireader.GetInt32(11);
                    dr[12] = ireader.GetValue(12).ToString();
                    dr[13] = ireader.GetValue(13).ToString();
                    dr[14] = ireader.GetValue(14).ToString();
                    dr[15] = ireader.GetValue(15).ToString();
                    dr[16] = ireader.GetDecimal(16);
                    dr[17] = ireader.GetDateTime(17);
                    if (bCheck)
                        dr[18] = Convert.ToInt32(ireader.GetValue(18));
                    else
                        dr[18] = 0;
                    dr[19] = ireader.GetInt32(19);
                    dr[20] = Convert.ToInt32(ireader.GetValue(20));
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

        public static DataTable DTMedicalRecord(string sMedicalCode, Int32 iObjectCode, string sDepartCode, Int32 iGroup, bool bCheck, string sDate)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("MedicalRecordCode", typeof(string)));
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
                dt.Columns.Add(new DataColumn("Status", typeof(int)));
                dt.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                dt.Columns.Add(new DataColumn("ItemName", typeof(string)));
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("PostingDate", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("Chon", typeof(Int32)));
                dt.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                string sql = string.Empty;
                sql = @" select a.MedicalRecordCode,a.ItemCode,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening,
                        a.Quantity,a.Instruction,a.UnitPrice,a.Amount,a.Status,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.ItemName,a.RowID,a.PostingDate,a.New,a.ObjectCode
                        from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode 
                        inner join MedicalRecord c on a.MedicalRecordCode=c.MedicalRecordCode inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode
                        where a.MedicalRecordCode in('{0}') and c.ObjectCode in({1}) 
                        and a.RepositoryCode in(
	                        select d1.RepositoryCode 
	                        from DepartmentForRepository d1 inner join RepositoryCatalog d2 on d1.RepositoryCode=d2.RepositoryCode
	                        where d1.DepartmentCode='{2}' and d2.RepositoryGroupCode in({3})
                        )  and CONVERT(date,a.PostingDate,103)=CONVERT(date,'{4}',103)
                        ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sMedicalCode, iObjectCode, sDepartCode, iGroup, sDate), null);
                while (ireader.Read())
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = ireader.GetString(0);
                    dr[1] = ireader.GetString(1);
                    dr[2] = ireader.GetInt32(2);
                    dr[3] = ireader.GetValue(3).ToString();
                    dr[4] = ireader.GetValue(4).ToString();
                    dr[5] = ireader.GetValue(5).ToString();
                    dr[6] = ireader.GetValue(6).ToString();
                    dr[7] = ireader.GetDecimal(7);
                    dr[8] = ireader.GetValue(8).ToString();
                    dr[9] = ireader.GetDecimal(9);
                    dr[10] = ireader.GetDecimal(10);
                    dr[11] = ireader.GetInt32(11);
                    dr[12] = ireader.GetValue(12).ToString();
                    dr[13] = ireader.GetValue(13).ToString();
                    dr[14] = ireader.GetValue(14).ToString();
                    dr[15] = ireader.GetValue(15).ToString();
                    dr[16] = ireader.GetDecimal(16);
                    dr[17] = ireader.GetDateTime(17);
                    if (bCheck)
                        dr[18] = Convert.ToInt32(ireader.GetValue(18));
                    else
                        dr[18] = 0;
                    dr[19] = ireader.GetInt32(19);
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

        public static DataTable DTMedicalRecordSurgeries(string sSurgeriesCode, Int32 iObjectCode, string sDepartCode, Int32 iGroup, bool bCheck, string sDate)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("MedicalRecordCode", typeof(string)));
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
                dt.Columns.Add(new DataColumn("Status", typeof(int)));
                dt.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                dt.Columns.Add(new DataColumn("ItemName", typeof(string)));
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("PostingDate", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("Chon", typeof(Int32)));
                dt.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                string sql = string.Empty;
                sql = @" select a.MedicalRecordCode,a.ItemCode,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening,
                        a.Quantity,a.Instruction,a.UnitPrice,a.Amount,a.Status,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.ItemName,a.RowID,a.PostingDate,a.New,a.ObjectCode
                        from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode 
                        inner join MedicalRecord c on a.MedicalRecordCode=c.MedicalRecordCode inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode
                        where c.ReferenceCode in('{0}') and c.ObjectCode in({1}) 
                        and a.RepositoryCode in(
	                        select d1.RepositoryCode 
	                        from DepartmentForRepository d1 inner join RepositoryCatalog d2 on d1.RepositoryCode=d2.RepositoryCode
	                        where d1.DepartmentCode='{2}' and d2.RepositoryGroupCode in({3})
                        )  and CONVERT(date,c.PostingDate,103)=CONVERT(date,'{4}',103)
                        ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sSurgeriesCode, iObjectCode, sDepartCode, iGroup, sDate), null);
                while (ireader.Read())
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = ireader.GetString(0);
                    dr[1] = ireader.GetString(1);
                    dr[2] = ireader.GetInt32(2);
                    dr[3] = ireader.GetValue(3).ToString();
                    dr[4] = ireader.GetValue(4).ToString();
                    dr[5] = ireader.GetValue(5).ToString();
                    dr[6] = ireader.GetValue(6).ToString();
                    dr[7] = ireader.GetDecimal(7);
                    dr[8] = ireader.GetValue(8).ToString();
                    dr[9] = ireader.GetDecimal(9);
                    dr[10] = ireader.GetDecimal(10);
                    dr[11] = ireader.GetInt32(11);
                    dr[12] = ireader.GetValue(12).ToString();
                    dr[13] = ireader.GetValue(13).ToString();
                    dr[14] = ireader.GetValue(14).ToString();
                    dr[15] = ireader.GetValue(15).ToString();
                    dr[16] = ireader.GetDecimal(16);
                    dr[17] = ireader.GetDateTime(17);
                    if (bCheck)
                        dr[18] = Convert.ToInt32(ireader.GetValue(18));
                    else
                        dr[18] = 0;
                    dr[19] = ireader.GetInt32(19);
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

        public static DataTable DTMedicalRecordOld(string sMedicalCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                tableResult.Columns.Add(new DataColumn("MedicalRecordCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("DateOfIssues", typeof(int)));
                tableResult.Columns.Add(new DataColumn("Morning", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Noon", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Afternoon", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Evening", typeof(string)));
                tableResult.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("Instruction", typeof(string)));
                tableResult.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("Status", typeof(int)));
                tableResult.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                tableResult.Columns.Add(new DataColumn("ItemName", typeof(string)));
                tableResult.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("DoseOf", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("DoseOfPills", typeof(string)));
                tableResult.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("RateBHYT", typeof(Int32)));
                tableResult.Columns.Add(new DataColumn("UsageCode", typeof(string)));
                tableResult.Columns.Add(new DataColumn("SalesPrice", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("BHYTPrice", typeof(decimal)));
                tableResult.Columns.Add(new DataColumn("UnitOfMeasureName", typeof(string)));
                string sql = string.Empty;
                sql = @" select a.MedicalRecordCode,a.ItemCode,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening,a.Quantity,a.Instruction,a.UnitPrice,a.Amount,a.Status,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.ItemName,a.RowID,a.DoseOf,a.DoseOfPills,a.ObjectCode,b.RateBHYT,b.UsageCode,b.SalesPrice,b.BHYTPrice,b1.UnitOfMeasureName
                        from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode inner join MedicalRecord c on a.MedicalRecordCode=c.MedicalRecordCode inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode inner join UnitOfMeasure b1 on b.UnitOfMeasureCode=b1.UnitOfMeasureCode
                        where a.MedicalRecordCode in('{0}')";
                tableResult = cn.ExecuteQuery(string.Format(sql, sMedicalCode));
            }
            catch { }
            return tableResult;
        }

        public static DataTable DTMedicalRecordApprove(string sMedicalCode, Int32 iObjectCode, string sRepCode, Int32 iStatus, decimal dRowIDMedicines)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("MedicalRecordCode", typeof(string)));
                dt.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                dt.Columns.Add(new DataColumn("DateOfIssues", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Morning", typeof(string)));
                dt.Columns.Add(new DataColumn("Noon", typeof(string)));
                dt.Columns.Add(new DataColumn("Afternoon", typeof(string)));
                dt.Columns.Add(new DataColumn("Evening", typeof(string)));
                dt.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
                dt.Columns.Add(new DataColumn("Instruction", typeof(string)));
                dt.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                dt.Columns.Add(new DataColumn("Status", typeof(Int32)));
                dt.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                dt.Columns.Add(new DataColumn("ItemName", typeof(string)));
                dt.Columns.Add(new DataColumn("SalesPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("BHYTPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("RateBHYT", typeof(decimal)));
                dt.Columns.Add(new DataColumn("UnitOfMeasureName", typeof(string)));
                dt.Columns.Add(new DataColumn("PostingDate", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("RowID", typeof(Decimal)));
                dt.Columns.Add(new DataColumn("ObjectCode", typeof(int)));
                dt.Columns.Add(new DataColumn("Shipment", typeof(string)));
                dt.Columns.Add(new DataColumn("Paid", typeof(int)));
                dt.Columns.Add(new DataColumn("BanksAccountCode", typeof(string)));
                string sql = string.Empty;
                if (iStatus == 0)
                {
                    sql = @" select a.MedicalRecordCode,a.ItemCode,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening,a.Quantity,a.Instruction,a.UnitPrice,a.Amount,a.Status,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.ItemName,
                        b.SalesPrice,b.BHYTPrice,b.RateBHYT,e.UnitOfMeasureName,a.PostingDate,a.RowID,a.ObjectCode,'' as Shipment,c.Paid,c.BanksAccountCode,c.Paid,c.BanksAccountCode
                        from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode 
                        inner join MedicalRecord c on a.MedicalRecordCode=c.MedicalRecordCode inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode inner join UnitOfMeasure e on b.UnitOfMeasureCode=e.UnitOfMeasureCode
                        where a.MedicalRecordCode in('{0}') and c.ObjectCode in({1}) 
                        and a.RepositoryCode in('{2}') and a.Status in({3})
                        ";
                    dt = cn.ExecuteQuery(string.Format(sql, sMedicalCode, iObjectCode, sRepCode, iStatus));
                    ///ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sMedicalCode, iObjectCode, sRepCode, iStatus), null);
                }
                else
                {
                    sql = @" select a.MedicalRecordCode,a.ItemCode,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening,a1.QuantityExport Quantity,a.Instruction,a1.UnitPrice,a1.Amount,a.Status,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.ItemName,
                        b.SalesPrice,b.BHYTPrice,b.RateBHYT,e.UnitOfMeasureName,a.PostingDate,a.RowID,a.ObjectCode,a2.Shipment,c.Paid,c.BanksAccountCode
                        from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode inner join MedicalRecord c on a.MedicalRecordCode=c.MedicalRecordCode inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode 
                        inner join UnitOfMeasure e on b.UnitOfMeasureCode=e.UnitOfMeasureCode inner join MedicinesForPatientsDetail a1 on a.RowID=a1.RowIDMedicalPrescription inner join InventoryGumshoe a2 on a1.RowIDInventoryGumshoe=a2.RowID
                        where a.MedicalRecordCode in('{0}') and c.ObjectCode in({1}) and a.RepositoryCode in('{2}') and a.Status in({3}) and a1.RowIDMedicines={4}
                        ";
                    dt = cn.ExecuteQuery(string.Format(sql, sMedicalCode, iObjectCode, sRepCode, iStatus, dRowIDMedicines));
                    ///ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sMedicalCode, iObjectCode, sRepCode, iStatus, dRowIDMedicines), null);
                }

            }
            catch { }
            return dt;
        }
        public static DataTable DTMedicalRecordApprove(string medicalCode, Int32 objectCode, string repCode, Int32 status, decimal rowIDMedicines, int objectCode_Medical)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("MedicalRecordCode", typeof(string)));
                dt.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                dt.Columns.Add(new DataColumn("DateOfIssues", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Morning", typeof(string)));
                dt.Columns.Add(new DataColumn("Noon", typeof(string)));
                dt.Columns.Add(new DataColumn("Afternoon", typeof(string)));
                dt.Columns.Add(new DataColumn("Evening", typeof(string)));
                dt.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
                dt.Columns.Add(new DataColumn("Instruction", typeof(string)));
                dt.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                dt.Columns.Add(new DataColumn("Status", typeof(Int32)));
                dt.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                dt.Columns.Add(new DataColumn("ItemName", typeof(string)));
                dt.Columns.Add(new DataColumn("SalesPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("BHYTPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("RateBHYT", typeof(decimal)));
                dt.Columns.Add(new DataColumn("UnitOfMeasureName", typeof(string)));
                dt.Columns.Add(new DataColumn("PostingDate", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("RowID", typeof(Decimal)));
                dt.Columns.Add(new DataColumn("ObjectCode", typeof(int)));
                dt.Columns.Add(new DataColumn("Shipment", typeof(string)));
                dt.Columns.Add(new DataColumn("Paid", typeof(int)));
                dt.Columns.Add(new DataColumn("BanksAccountCode", typeof(string)));
                string sql = string.Empty;
                if (status == 0)
                {
                    sql = @" select a.MedicalRecordCode,a.ItemCode,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening,a.Quantity,a.Instruction,a.UnitPrice,a.Amount,a.Status,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.ItemName,
                        b.SalesPrice,b.BHYTPrice,b.RateBHYT,e.UnitOfMeasureName,a.PostingDate,a.RowID,a.ObjectCode,'' as Shipment,c.Paid,c.BanksAccountCode,c.Paid,c.BanksAccountCode, obj.ObjectName
                        from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode 
                        inner join MedicalRecord c on a.MedicalRecordCode=c.MedicalRecordCode inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode inner join UnitOfMeasure e on b.UnitOfMeasureCode=e.UnitOfMeasureCode
                        inner join Object obj on obj.ObjectCode = a.ObjectCode
                        where a.MedicalRecordCode in('{0}') and c.ObjectCode in({1}) 
                        and a.RepositoryCode in('{2}') and a.Status in({3})
                        ";
                    if (!objectCode_Medical.Equals(-1))
                        sql += " and a.ObjectCode =" + objectCode_Medical;
                    dt = cn.ExecuteQuery(string.Format(sql, medicalCode, objectCode, repCode, status));
                }
                else
                {
                    sql = @" select a.MedicalRecordCode,a.ItemCode,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening,a1.QuantityExport Quantity,a.Instruction,a1.UnitPrice,a1.Amount,a.Status,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.ItemName,
                        b.SalesPrice,b.BHYTPrice,b.RateBHYT,e.UnitOfMeasureName,a.PostingDate,a.RowID,a.ObjectCode,a2.Shipment,a1.Paid,c.BanksAccountCode, obj.ObjectName
                        from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode inner join MedicalRecord c on a.MedicalRecordCode=c.MedicalRecordCode inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode 
                        inner join UnitOfMeasure e on b.UnitOfMeasureCode=e.UnitOfMeasureCode inner join MedicinesForPatientsDetail a1 on a.RowID=a1.RowIDMedicalPrescription inner join InventoryGumshoe a2 on a1.RowIDInventoryGumshoe=a2.RowID
                        inner join Object obj on obj.ObjectCode = a.ObjectCode
                        where a.MedicalRecordCode in('{0}') and c.ObjectCode in({1}) and a.RepositoryCode in('{2}') and a.Status in({3}) and a1.RowIDMedicines={4}
                        ";
                    if (!objectCode_Medical.Equals(-1))
                        sql += " and a.ObjectCode =" + objectCode_Medical;
                    dt = cn.ExecuteQuery(string.Format(sql, medicalCode, objectCode, repCode, status, rowIDMedicines));
                }

            }
            catch { }
            return dt;
        }
        public static List<MedicalRecordHistoryModel> ListHistoryMedical(string sPatientCode, Int32 iPatientType)
        {
            ConnectDB cn = new ConnectDB();
            List<MedicalRecordHistoryModel> list = new List<MedicalRecordHistoryModel>();
            try
            {
                string sql = string.Empty;
                sql = @" select a.PatientReceiveID,a.PatientCode,a.PostingDate,e.PatientName,b.Status Statusrv,e.PatientBirthyear,e.PatientAge,e.PatientAddress,f.ObjectName,
                    (case when e.PatientGender=0 then N'Nữ' else N'Nam' end)GenderName,a.ObjectCode,f.ObjectCard,b.PatientType,a.MedicalRecordCode,g.ServiceCode,a.Status,d.DepartmentName,a.ICD10_Custom as DiagnosisCode,a.ICD10Name_Custom as DiagnosisName,a.Symptoms,a.DiagnosisCustom,a1.EmployeeName EmployeeNameDoctor,g.STT
                     from MedicalRecord a inner join PatientReceive b on a.PatientReceiveID=b.PatientReceiveID
                     --left join Diagnosis c on a.DiagnosisCode=c.RowID 
                    inner join Department d on a.DepartmentCode=d.DepartmentCode 
                    inner join Patients e on a.PatientCode=e.PatientCode inner join [Object] f on a.ObjectCode=f.ObjectCode
                    inner join SuggestedServiceReceipt g on a.ReceiptID=g.ReceiptID and a.DepartmentCode=g.DepartmentCode LEFT join Employee a1 on a.EmployeeCodeDoctor=a1.EmployeeCode
                    where a.PatientCode='{0}' and b.PatientType={1} and a.TypeMedical in(0)
                    group by a.PatientReceiveID,a.PatientCode,a.PostingDate,e.PatientName,b.Status,e.PatientBirthyear,e.PatientAge,e.PatientAddress,f.ObjectName,
                    e.PatientGender,a.ObjectCode,f.ObjectCard,b.PatientType,a.MedicalRecordCode,g.ServiceCode,a.Status,d.DepartmentName,a.ICD10_Custom,a.ICD10Name_Custom,a.Symptoms,a.DiagnosisCustom,a1.EmployeeName,g.STT
                    order by a.PostingDate desc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sPatientCode, iPatientType), null);
                while (ireader.Read())
                {
                    MedicalRecordHistoryModel inf = new MedicalRecordHistoryModel();
                    inf.PatientReceiveID = ireader.GetDecimal(0);
                    inf.PatientCode = ireader.GetString(1);
                    inf.PostingDate = ireader.GetDateTime(2);
                    inf.PatientName = ireader.GetValue(3).ToString();
                    inf.Statusrv = ireader.GetInt32(4);
                    inf.PatientBirthyear = ireader.GetInt32(5);
                    inf.PatientAge = Convert.ToInt32(ireader.GetValue(6).ToString());
                    inf.PatientAddress = ireader.GetValue(7).ToString();
                    inf.ObjectName = ireader.GetValue(8).ToString();
                    inf.GenderName = ireader.GetValue(9).ToString();
                    inf.ObjectCode = Convert.ToInt32(ireader.GetValue(10).ToString());
                    inf.ObjectCard = Convert.ToInt32(ireader.GetValue(11).ToString());
                    inf.PatientType = Convert.ToInt32(ireader.GetValue(12).ToString());
                    inf.MedicalRecordCode = ireader.GetString(13);
                    inf.ServiceCode = ireader.GetValue(14).ToString();
                    inf.Status = Convert.ToInt32(ireader.GetValue(15).ToString());
                    inf.DepartmentName = ireader.GetValue(16).ToString();
                    inf.DiagnosisCode = ireader.GetValue(17).ToString();
                    inf.DiagnosisName = ireader.GetValue(18).ToString();
                    inf.Symptoms = ireader.GetValue(19).ToString();
                    inf.DiagnosisCustom = ireader.GetValue(20).ToString();
                    inf.EmployeeNameDoctor = ireader.GetValue(21).ToString();
                    inf.STT = Convert.ToInt32(ireader.GetValue(22).ToString());
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

        public static List<MedicalEmergencyHistoryModel> ListHistoryMedicalEmergency(string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<MedicalEmergencyHistoryModel> list = new List<MedicalEmergencyHistoryModel>();
            try
            {
                string sql = "";
                sql += @"
                    select a.PatientReceiveID,a.PatientCode, CONVERT(date,a.DateOn,103) PostingDate,a1.PatientName,a1.PatientAge,a2.ObjectName,a. DiagnosisCode Symptoms,a.ICD10,a3.DepartmentName
                    from MedicalEmergency a inner join Patients a1 on a.PatientCode=a1.PatientCode inner join Object a2 on a.ObjectCode=a2.ObjectCode 
                    inner join Department a3 on a.DepartmentCode=a3.DepartmentCode
                    where a.PatientCode='{0}'
                    union all
                    select a.PatientReceiveID,a.PatientCode,CONVERT(date,a.PostingDate,103) PostingDate,a1.PatientName,a1.PatientAge,a2.ObjectName,a.Symptoms,a3.DiagnosisCode ICD10,a4.DepartmentName
                    from MedicalRecord a inner join Patients a1 on a.PatientCode=a1.PatientCode inner join Object a2 on a.ObjectCode=a2.ObjectCode
                    inner join Diagnosis a3 on a.DiagnosisCode=a3.RowID inner join Department a4 on a.DepartmentCode=a4.DepartmentCode
                    where a.PatientCode='{0}' and (SUBSTRING(a.ReferenceCode,1,2)!='CC' and SUBSTRING(a.ReferenceCode,1,2)!='PT')
                    order by PostingDate desc
                ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sPatientCode), null);
                while (ireader.Read())
                {
                    MedicalEmergencyHistoryModel inf = new MedicalEmergencyHistoryModel();
                    inf.PatientReceiveID = ireader.GetDecimal(0);
                    inf.PatientCode = ireader.GetString(1);
                    inf.PostingDate = ireader.GetDateTime(2);
                    inf.PatientName = ireader.GetValue(3).ToString();
                    inf.PatientAge = Convert.ToInt32(ireader.GetValue(4).ToString());
                    inf.ObjectName = ireader.GetValue(5).ToString();
                    inf.Symptoms = ireader.GetValue(6).ToString();
                    inf.ICD10 = ireader.GetValue(7).ToString();
                    inf.DepartmentName = ireader.GetValue(8).ToString();
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

        public static MedicalRecord_INF ObjMedicalRecordForReceiveID(decimal dReceiveID, string sDepartmentCode)
        {
            ConnectDB cn = new ConnectDB();
            MedicalRecord_INF inf = new MedicalRecord_INF();
            try
            {
                string sql = string.Empty;
                sql = @"select RowID,MedicalRecordCode,PatientReceiveID,PatientCode, DepartmentCode,EmployeeCode,DiagnosisCode,DescriptionNode,PostingDate, AppointmentDate, ReferenceCode,
                        Symptoms,Status,ObjectCode, Advices, DiagnosisEnclosed, TackleCode,RowIDMedicalPattern,ContentMedicalPattern,DiagnosisCustom,Treatments,EmployeeCodeDoctor,ICD10_Custom,ICD10Name_Custom
                        from MedicalRecord where PatientReceiveID={0} and DepartmentCode in('{1}')";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dReceiveID, sDepartmentCode), null);
                if (ireader.Read())
                {
                    inf.RowID = ireader.GetDecimal(0);
                    inf.MedicalRecordCode = ireader.GetString(1);
                    inf.PatientReceiveID = ireader.GetDecimal(2);
                    inf.PatientCode = ireader.GetString(3);
                    inf.DepartmentCode = ireader.GetString(4);
                    inf.EmployeeCode = ireader.GetString(5);
                    inf.DiagnosisCode = ireader.GetDecimal(6);
                    inf.DescriptionNode = ireader.GetValue(7).ToString();
                    inf.PostingDate = ireader.GetDateTime(8);
                    if (ireader.GetValue(9).ToString() != string.Empty)
                        inf.AppointmentDate = ireader.GetDateTime(9);
                    inf.ReferenceCode = ireader.GetString(10);
                    inf.Symptoms = ireader.GetValue(11).ToString();
                    inf.Status = ireader.GetInt32(12);
                    inf.ObjectCode = ireader.GetInt32(13);
                    inf.Advices = ireader.GetValue(14).ToString();
                    if (ireader.GetValue(15).ToString() != string.Empty)
                        inf.DiagnosisEnclosed = ireader.GetDecimal(15);
                    if (ireader.GetValue(16).ToString() != string.Empty)
                        inf.TackleCode = ireader.GetInt32(16);
                    inf.RowIDMedicalPattern = ireader.GetInt32(17);
                    inf.ContentMedicalPattern = ireader.GetValue(18).ToString();
                    inf.DiagnosisCustom = ireader.GetValue(19).ToString();
                    inf.Treatments = ireader.GetValue(20).ToString();
                    inf.EmployeeCodeDoctor = ireader.GetValue(21).ToString();
                    inf.ICD10_Custom = ireader.GetValue(22).ToString();
                    inf.ICD10Name_Custom = ireader.GetValue(23).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return inf;
            }
            catch { return null; }
        }
        public static MedicalRecord_INF ObjMedicalRecordForSuggestedID(decimal suggestedID, decimal receiveID)
        {
            ConnectDB cn = new ConnectDB();
            MedicalRecord_INF inf = new MedicalRecord_INF();
            try
            {
                string sql = string.Empty;
                sql = @"select RowID,MedicalRecordCode,PatientReceiveID,PatientCode, DepartmentCode,EmployeeCode,DiagnosisCode,DescriptionNode,PostingDate, AppointmentDate, ReferenceCode,
                        Symptoms,Status,ObjectCode, Advices, DiagnosisEnclosed, TackleCode,RowIDMedicalPattern,ContentMedicalPattern,DiagnosisCustom,Treatments,EmployeeCodeDoctor,ICD10_Custom,ICD10Name_Custom
                        from MedicalRecord where PatientReceiveID={0} and ReceiptID ={1}";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, receiveID, suggestedID), null);
                if (ireader.Read())
                {
                    inf.RowID = ireader.GetDecimal(0);
                    inf.MedicalRecordCode = ireader.GetString(1);
                    inf.PatientReceiveID = ireader.GetDecimal(2);
                    inf.PatientCode = ireader.GetString(3);
                    inf.DepartmentCode = ireader.GetString(4);
                    inf.EmployeeCode = ireader.GetString(5);
                    inf.DiagnosisCode = ireader.GetDecimal(6);
                    inf.DescriptionNode = ireader.GetValue(7).ToString();
                    inf.PostingDate = ireader.GetDateTime(8);
                    if (ireader.GetValue(9).ToString() != string.Empty)
                        inf.AppointmentDate = ireader.GetDateTime(9);
                    inf.ReferenceCode = ireader.GetString(10);
                    inf.Symptoms = ireader.GetValue(11).ToString();
                    inf.Status = ireader.GetInt32(12);
                    inf.ObjectCode = ireader.GetInt32(13);
                    inf.Advices = ireader.GetValue(14).ToString();
                    if (ireader.GetValue(15).ToString() != string.Empty)
                        inf.DiagnosisEnclosed = ireader.GetDecimal(15);
                    if (ireader.GetValue(16).ToString() != string.Empty)
                        inf.TackleCode = ireader.GetInt32(16);
                    inf.RowIDMedicalPattern = ireader.GetInt32(17);
                    inf.ContentMedicalPattern = ireader.GetValue(18).ToString();
                    inf.DiagnosisCustom = ireader.GetValue(19).ToString();
                    inf.Treatments = ireader.GetValue(20).ToString();
                    inf.EmployeeCodeDoctor = ireader.GetValue(21).ToString();
                    inf.ICD10_Custom = ireader.GetValue(22).ToString();
                    inf.ICD10Name_Custom = ireader.GetValue(23).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return inf;
            }
            catch { return null; }
        }
        public static List<MedicalRecord_INF> ListMedicalRecordForReceiveID(string receiveID)
        {
            ConnectDB cn = new ConnectDB();
            List<MedicalRecord_INF> lstMedical = new List<MedicalRecord_INF>();
            try
            {
                string sql = string.Empty;
                sql = @"select RowID,MedicalRecordCode,PatientReceiveID,PatientCode, DepartmentCode,EmployeeCode,DiagnosisCode,DescriptionNode,PostingDate,Symptoms,ObjectCode, Advices, TackleCode,ContentMedicalPattern,DiagnosisCustom,Treatments,EmployeeCodeDoctor,ICD10_Custom,ICD10Name_Custom
                        from MedicalRecord where PatientReceiveID in({0})
                        union all
                        select 0 as RowID,a.MedicalEmergencyCode,a.PatientReceiveID, a.PatientCode,a.DepartmentCode,a.EmployeeCode,b.RowID DiagnosisCode, '' as DescriptionNode, IDate PostingDate,Symptoms,a.ObjectCode,'' Advices,-1 as TackleCode,'' as ContentMedicalPattern,'' as DiagnosisCustom,'' as Treatments, EmployeeCode EmployeeCodeDoctor,'' as ICD10_Custom,'' as ICD10Name_Custom
                        from MedicalEmergency a inner join Diagnosis b on a.ICD10=b.DiagnosisCode
                        where a.PatientReceiveID in({0}) ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, receiveID), null);
                while (ireader.Read())
                {
                    MedicalRecord_INF inf = new MedicalRecord_INF();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.MedicalRecordCode = ireader.GetString(1);
                    inf.PatientReceiveID = ireader.GetDecimal(2);
                    inf.PatientCode = ireader.GetString(3);
                    inf.DepartmentCode = ireader.GetString(4);
                    inf.EmployeeCode = ireader.GetString(5);
                    inf.DiagnosisCode = ireader.GetDecimal(6);
                    inf.DescriptionNode = ireader.GetValue(7).ToString();
                    inf.PostingDate = ireader.GetDateTime(8);
                    inf.Symptoms = ireader.GetValue(9).ToString();
                    inf.ObjectCode = ireader.GetInt32(10);
                    inf.Advices = ireader.GetValue(11).ToString();
                    if (ireader.GetValue(12).ToString() != string.Empty)
                        inf.TackleCode = ireader.GetInt32(12);
                    inf.ContentMedicalPattern = ireader.GetValue(13).ToString();
                    inf.DiagnosisCustom = ireader.GetValue(14).ToString();
                    inf.Treatments = ireader.GetValue(15).ToString();
                    inf.EmployeeCodeDoctor = ireader.GetValue(16).ToString();
                    inf.ICD10_Custom = ireader.GetValue(17).ToString();
                    inf.ICD10Name_Custom = ireader.GetValue(18).ToString();
                    lstMedical.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return lstMedical;
            }
            catch { return null; }
        }

        public static MedicalRecord_INF ObjMedicalRecordForRecordCode(string medicalRecordCode)
        {
            ConnectDB cn = new ConnectDB();
            MedicalRecord_INF inf = new MedicalRecord_INF();
            try
            {
                string sql = string.Empty;
                sql = @"select RowID,MedicalRecordCode,PatientReceiveID,PatientCode, DepartmentCode,EmployeeCode,DiagnosisCode,DescriptionNode,PostingDate, AppointmentDate, ReferenceCode,
                        Symptoms,Status,ObjectCode, Advices, DiagnosisEnclosed, TackleCode,RowIDMedicalPattern,ContentMedicalPattern,EmployeeCodeDoctor,DiagnosisCustom,Treatments,Pregnant,Breastfeeding,Use_Smoking,Use_Alcohol
                        from MedicalRecord where MedicalRecordCode in('{0}')";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, medicalRecordCode), null);
                if (ireader.Read())
                {
                    inf.RowID = ireader.GetDecimal(0);
                    inf.MedicalRecordCode = ireader.GetString(1);
                    inf.PatientReceiveID = ireader.GetDecimal(2);
                    inf.PatientCode = ireader.GetString(3);
                    inf.DepartmentCode = ireader.GetString(4);
                    inf.EmployeeCode = ireader.GetString(5);
                    inf.DiagnosisCode = ireader.GetDecimal(6);
                    inf.DescriptionNode = ireader.GetValue(7).ToString();
                    inf.PostingDate = ireader.GetDateTime(8);
                    if (ireader.GetValue(9).ToString() != string.Empty)
                        inf.AppointmentDate = ireader.GetDateTime(9);
                    inf.ReferenceCode = ireader.GetString(10);
                    inf.Symptoms = ireader.GetValue(11).ToString();
                    inf.Status = ireader.GetInt32(12);
                    inf.ObjectCode = ireader.GetInt32(13);
                    inf.Advices = ireader.GetValue(14).ToString();
                    if (ireader.GetValue(15).ToString() != string.Empty)
                        inf.DiagnosisEnclosed = ireader.GetDecimal(15);
                    if (ireader.GetValue(16).ToString() != string.Empty)
                        inf.TackleCode = ireader.GetInt32(16);
                    inf.RowIDMedicalPattern = ireader.GetInt32(17);
                    inf.ContentMedicalPattern = ireader.GetValue(18).ToString();
                    inf.EmployeeCodeDoctor = ireader.GetValue(19).ToString();
                    inf.DiagnosisCustom = ireader.GetValue(20).ToString();
                    inf.Treatments = ireader.GetValue(21).ToString();
                    inf.Pregnant = ireader.GetValue(22).ToString().Equals("True") ? 1 : 0;
                    inf.Breastfeeding = ireader.GetValue(23).ToString().Equals("True") ? 1 : 0;
                    inf.Use_Smoking = ireader.GetValue(24).ToString().Equals("True") ? 1 : 0;
                    inf.Use_Alcohol = ireader.GetValue(25).ToString().Equals("True") ? 1 : 0;
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return inf;
            }
            catch { return null; }
        }

        public static Int32 InsMedicalRecord(MedicalRecord_INF info, ref string sMedicalCode, ref string sServiceCode, ref string msg)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[33];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = info.MedicalRecordCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = info.PatientReceiveID;
                param[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[2].Value = info.PatientCode;
                param[3] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[3].Value = info.DepartmentCode;
                param[4] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[4].Value = info.EmployeeCode;
                param[5] = new SqlParameter("@DiagnosisCode", SqlDbType.Decimal);
                param[5].Value = info.DiagnosisCode;
                param[6] = new SqlParameter("@DescriptionNode", SqlDbType.NVarChar, 1000);
                param[6].Value = info.DescriptionNode;
                param[7] = new SqlParameter("@PostingDate", SqlDbType.DateTime);
                param[7].Value = info.PostingDate;
                param[8] = new SqlParameter("@AppointmentDate", SqlDbType.DateTime);
                param[8].Value = info.AppointmentDate;
                param[9] = new SqlParameter("@ReferenceCode", SqlDbType.VarChar, 50);
                param[9].Value = info.ReferenceCode;
                param[10] = new SqlParameter("@Symptoms", SqlDbType.NVarChar, 250);
                param[10].Value = info.Symptoms;
                param[11] = new SqlParameter("@Status", SqlDbType.Int);
                param[11].Value = info.Status;
                param[12] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[12].Value = info.ObjectCode;
                param[13] = new SqlParameter("@Advices", SqlDbType.NVarChar, 250);
                param[13].Value = info.Advices;
                param[14] = new SqlParameter("@DiagnosisEnclosed", SqlDbType.Decimal);
                param[14].Value = info.DiagnosisEnclosed;
                param[15] = new SqlParameter("@TackleCode", SqlDbType.Int);
                param[15].Value = info.TackleCode;
                param[16] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[16].Value = sServiceCode;
                param[17] = new SqlParameter("@RowIDMedicalPattern", SqlDbType.Int);
                param[17].Value = info.RowIDMedicalPattern;
                param[18] = new SqlParameter("@ContentMedicalPattern", SqlDbType.NVarChar);
                param[18].Value = info.ContentMedicalPattern;
                param[19] = new SqlParameter("@EmployeeCodeDoctor", SqlDbType.VarChar, 50);
                param[19].Value = info.EmployeeCodeDoctor;
                param[20] = new SqlParameter("@DiagnosisCustom", SqlDbType.NVarChar, 250);
                param[20].Value = info.DiagnosisCustom;
                param[21] = new SqlParameter("@TypeMedical", SqlDbType.Int);
                param[21].Value = info.TypeMedical;
                param[22] = new SqlParameter("@ReceiptID", SqlDbType.Decimal);
                param[22].Value = info.ReceiptID;
                param[23] = new SqlParameter("@ShiftWork", SqlDbType.Char);
                param[23].Value = info.ShiftWork;
                param[24] = new SqlParameter("@Treatments", SqlDbType.NVarChar, 200);
                param[24].Value = info.Treatments;
                param[25] = new SqlParameter("@Pregnant", SqlDbType.Bit);
                param[25].Value = info.Pregnant;
                param[26] = new SqlParameter("@Breastfeeding", SqlDbType.Bit);
                param[26].Value = info.Breastfeeding;
                param[27] = new SqlParameter("@Use_Smoking", SqlDbType.Bit);
                param[27].Value = info.Use_Smoking;
                param[28] = new SqlParameter("@Use_Alcohol", SqlDbType.Bit);
                param[28].Value = info.Use_Alcohol;
                param[29] = new SqlParameter("@EmployeeCodeDoing", SqlDbType.VarChar);
                param[29].Value = info.EmployeeCodeDoing;
                param[30] = new SqlParameter("@ICD10_Custom", SqlDbType.VarChar);
                param[30].Value = info.ICD10_Custom;
                param[31] = new SqlParameter("@ICD10Name_Custom", SqlDbType.NVarChar);
                param[31].Value = info.ICD10Name_Custom;
                param[32] = new SqlParameter("@ResultMedicalCode", SqlDbType.VarChar, 50);
                param[32].Direction = ParameterDirection.Output;
                sMedicalCode = cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_MedicalRecord", param);
                return 1;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return -2;
            }
        }
        public static Int32 InsMedicalRecordForAttach_Items(MedicalRecord_INF info, ref string sMedicalCode, decimal receiptID, string serviceCode, ref string msg)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[33];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = info.MedicalRecordCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = info.PatientReceiveID;
                param[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[2].Value = info.PatientCode;
                param[3] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[3].Value = info.DepartmentCode;
                param[4] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[4].Value = info.EmployeeCode;
                param[5] = new SqlParameter("@DiagnosisCode", SqlDbType.Decimal);
                param[5].Value = info.DiagnosisCode;
                param[6] = new SqlParameter("@DescriptionNode", SqlDbType.NVarChar, 1000);
                param[6].Value = info.DescriptionNode;
                param[7] = new SqlParameter("@PostingDate", SqlDbType.DateTime);
                param[7].Value = info.PostingDate;
                param[8] = new SqlParameter("@AppointmentDate", SqlDbType.DateTime);
                param[8].Value = info.AppointmentDate;
                param[9] = new SqlParameter("@ReferenceCode", SqlDbType.VarChar, 50);
                param[9].Value = info.ReferenceCode;
                param[10] = new SqlParameter("@Symptoms", SqlDbType.NVarChar, 250);
                param[10].Value = info.Symptoms;
                param[11] = new SqlParameter("@Status", SqlDbType.Int);
                param[11].Value = info.Status;
                param[12] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[12].Value = info.ObjectCode;
                param[13] = new SqlParameter("@Advices", SqlDbType.NVarChar, 250);
                param[13].Value = info.Advices;
                param[14] = new SqlParameter("@DiagnosisEnclosed", SqlDbType.Decimal);
                param[14].Value = info.DiagnosisEnclosed;
                param[15] = new SqlParameter("@TackleCode", SqlDbType.Int);
                param[15].Value = info.TackleCode;
                param[16] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[16].Value = serviceCode;
                param[17] = new SqlParameter("@RowIDMedicalPattern", SqlDbType.Int);
                param[17].Value = info.RowIDMedicalPattern;
                param[18] = new SqlParameter("@ContentMedicalPattern", SqlDbType.NVarChar);
                param[18].Value = info.ContentMedicalPattern;
                param[19] = new SqlParameter("@EmployeeCodeDoctor", SqlDbType.VarChar, 50);
                param[19].Value = info.EmployeeCodeDoctor;
                param[20] = new SqlParameter("@DiagnosisCustom", SqlDbType.NVarChar, 250);
                param[20].Value = info.DiagnosisCustom;
                param[21] = new SqlParameter("@TypeMedical", SqlDbType.Int);
                param[21].Value = info.TypeMedical;
                param[22] = new SqlParameter("@ReceiptID", SqlDbType.Decimal);
                param[22].Value = info.ReceiptID;
                param[23] = new SqlParameter("@ShiftWork", SqlDbType.Char);
                param[23].Value = info.ShiftWork;
                param[24] = new SqlParameter("@Treatments", SqlDbType.NVarChar, 200);
                param[24].Value = info.Treatments;
                param[25] = new SqlParameter("@Pregnant", SqlDbType.Bit);
                param[25].Value = info.Pregnant;
                param[26] = new SqlParameter("@Breastfeeding", SqlDbType.Bit);
                param[26].Value = info.Breastfeeding;
                param[27] = new SqlParameter("@Use_Smoking", SqlDbType.Bit);
                param[27].Value = info.Use_Smoking;
                param[28] = new SqlParameter("@Use_Alcohol", SqlDbType.Bit);
                param[28].Value = info.Use_Alcohol;
                param[29] = new SqlParameter("@EmployeeCodeDoing", SqlDbType.VarChar);
                param[29].Value = info.EmployeeCodeDoing;
                param[30] = new SqlParameter("@ICD10_Custom", SqlDbType.VarChar);
                param[30].Value = info.ICD10_Custom;
                param[31] = new SqlParameter("@ICD10Name_Custom", SqlDbType.NVarChar);
                param[31].Value = info.ICD10Name_Custom;
                param[32] = new SqlParameter("@ResultMedicalCode", SqlDbType.VarChar, 50);
                param[32].Direction = ParameterDirection.Output;
                sMedicalCode = cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_MedicalRecord", param);
                return 1;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return -2;
            }
        }
        public static bool InsMedicalRecord_ANC(MedicalRecord_ANCINF info, ref string msgError)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[25];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = info.MedicalRecordCode;
                param[1] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 15);
                param[1].Value = info.EmployeeCode;
                param[2] = new SqlParameter("@TienSuSinhDe", SqlDbType.NVarChar, 100);
                param[2].Value = info.TienSuSinhDe;
                param[3] = new SqlParameter("@NgayKinhCuoiCung", SqlDbType.Char, 10);
                param[3].Value = info.NgayKinhCuoiCung;
                param[4] = new SqlParameter("@TuanThai", SqlDbType.VarChar, 20);
                param[4].Value = info.TuanThai;
                param[5] = new SqlParameter("@NgaySinhDuKien", SqlDbType.Char, 10);
                param[5].Value = info.NgaySinhDuKien;
                param[6] = new SqlParameter("@LanCoThai", SqlDbType.Int);
                param[6].Value = info.LanCoThai;
                param[7] = new SqlParameter("@TrongLuongMe", SqlDbType.VarChar, 20);
                param[7].Value = info.TrongLuongMe;
                param[8] = new SqlParameter("@ChieuCaoMe", SqlDbType.VarChar, 20);
                param[8].Value = info.ChieuCaoMe;
                param[9] = new SqlParameter("@HuyetAp", SqlDbType.VarChar, 10);
                param[9].Value = info.HuyetAp;
                param[10] = new SqlParameter("@HuyetAp1", SqlDbType.VarChar, 10);
                param[10].Value = info.HuyetAp1;
                param[11] = new SqlParameter("@ChieuCaoTC", SqlDbType.VarChar, 10);
                param[11].Value = info.ChieuCaoTC;
                param[12] = new SqlParameter("@VongBung", SqlDbType.VarChar, 10);
                param[12].Value = info.VongBung;
                param[13] = new SqlParameter("@KhungChau", SqlDbType.VarChar, 10);
                param[13].Value = info.KhungChau;
                param[14] = new SqlParameter("@ThieuMau", SqlDbType.NVarChar, 50);
                param[14].Value = info.ThieuMau;
                param[15] = new SqlParameter("@Protein", SqlDbType.NVarChar, 50);
                param[15].Value = info.Protein;
                param[16] = new SqlParameter("@XNHIV", SqlDbType.NVarChar, 200);
                param[16].Value = info.XNHIV;
                param[17] = new SqlParameter("@XNKhac", SqlDbType.NVarChar, 200);
                param[17].Value = info.XNKhac;
                param[18] = new SqlParameter("@TienLuongDe", SqlDbType.NVarChar, 200);
                param[18].Value = info.TienLuongDe;
                param[19] = new SqlParameter("@SoMuiTiem", SqlDbType.Int);
                param[19].Value = info.SoMuiTiem;
                param[20] = new SqlParameter("@UongVien", SqlDbType.Bit);
                param[20].Value = info.UongVien;
                param[21] = new SqlParameter("@WorkDate", SqlDbType.DateTime);
                param[21].Value = info.WorkDate;
                param[22] = new SqlParameter("@TimThai", SqlDbType.NVarChar, 200);
                param[22].Value = info.TimThai;
                param[23] = new SqlParameter("@NgoiThai", SqlDbType.NVarChar, 200);
                param[23].Value = info.NgoiThai;
                param[24] = new SqlParameter("@GhiChu", SqlDbType.NVarChar, 200);
                param[24].Value = info.GhiChu;
                int result = cn.ExecuteNonQuery(CommandType.StoredProcedure, "proIns_MedicalRecord_ANC", param);
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
                return false;
            }
        }
        public static MedicalRecord_ANCINF ObjMedicalRecord_ANC(string medicalRecordCode)
        {
            ConnectDB cn = new ConnectDB();
            MedicalRecord_ANCINF inf = new MedicalRecord_ANCINF();
            try
            {
                string sql = string.Empty;
                sql = @"select MedicalRecordCode,EmployeeCode,TienSuSinhDe,NgayKinhCuoiCung,TuanThai,NgaySinhDuKien,LanCoThai,TrongLuongMe,ChieuCaoMe,HuyetAp,HuyetAp1,ChieuCaoTC,VongBung,KhungChau,ThieuMau,Protein,XNHIV,XNKhac,TienLuongDe,SoMuiTiem,UongVien,WorkDate,TimThai,NgoiThai,GhiChu
                        from MedicalRecord_ANC where MedicalRecordCode in('{0}')";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, medicalRecordCode), null);
                if (ireader.Read())
                {
                    inf.MedicalRecordCode = ireader.GetValue(0).ToString();
                    inf.EmployeeCode = ireader.GetValue(1).ToString();
                    inf.TienSuSinhDe = ireader.GetValue(2).ToString();
                    inf.NgayKinhCuoiCung = ireader.GetValue(3).ToString();
                    inf.TuanThai = ireader.GetValue(4).ToString();
                    inf.NgaySinhDuKien = ireader.GetValue(5).ToString();
                    inf.LanCoThai = ireader.GetInt32(6);
                    inf.TrongLuongMe = ireader.GetValue(7).ToString();
                    inf.ChieuCaoMe = ireader.GetValue(8).ToString();
                    inf.HuyetAp = ireader.GetValue(9).ToString();
                    inf.HuyetAp1 = ireader.GetValue(10).ToString();
                    inf.ChieuCaoTC = ireader.GetValue(11).ToString();
                    inf.VongBung = ireader.GetValue(12).ToString();
                    inf.KhungChau = ireader.GetValue(13).ToString();
                    inf.ThieuMau = ireader.GetValue(14).ToString();
                    inf.Protein = ireader.GetValue(15).ToString();
                    inf.XNHIV = ireader.GetValue(16).ToString();
                    inf.XNKhac = ireader.GetValue(17).ToString();
                    inf.TienLuongDe = ireader.GetValue(18).ToString();
                    inf.SoMuiTiem = ireader.GetInt32(19);
                    inf.UongVien = ireader.GetValue(20).ToString() == "1" ? true : false;
                    inf.WorkDate = ireader.GetDateTime(21);
                    inf.TimThai = ireader.GetValue(22).ToString();
                    inf.NgoiThai = ireader.GetValue(23).ToString();
                    inf.GhiChu = ireader.GetValue(24).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return inf;
            }
            catch { return null; }
        }

        public static bool InsMedicalRecord_Abortions(MedicalRecord_AbortionsINF info, ref string msgError)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[13];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = info.MedicalRecordCode;
                param[1] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 15);
                param[1].Value = info.EmployeeCode;
                param[2] = new SqlParameter("@TTHonNhan", SqlDbType.Bit);
                param[2].Value = info.TTHonNhan;
                param[3] = new SqlParameter("@SoConHienCo", SqlDbType.Int);
                param[3].Value = info.SoConHienCo;
                param[4] = new SqlParameter("@NgayKinhCuoiCung", SqlDbType.Char, 10);
                param[4].Value = info.NgayKinhCuoiCung;
                param[5] = new SqlParameter("@ChuanDoanThai", SqlDbType.NVarChar, 200);
                param[5].Value = info.ChuanDoanThai;
                param[6] = new SqlParameter("@PPPhaThai", SqlDbType.NVarChar, 200);
                param[6].Value = info.PPPhaThai;
                param[7] = new SqlParameter("@KetQuaSoiMo", SqlDbType.NVarChar, 200);
                param[7].Value = info.KetQuaSoiMo;
                param[8] = new SqlParameter("@TaiBienMac", SqlDbType.Bit);
                param[8].Value = info.TaiBienMac;
                param[9] = new SqlParameter("@TaiBienChet", SqlDbType.Bit);
                param[9].Value = info.TaiBienChet;
                param[10] = new SqlParameter("@KhamLai", SqlDbType.NVarChar, 100);
                param[10].Value = info.KhamLai;
                param[11] = new SqlParameter("@GhiChu", SqlDbType.NVarChar, 200);
                param[11].Value = info.GhiChu;
                param[12] = new SqlParameter("@WorkDate", SqlDbType.DateTime);
                param[12].Value = info.WorkDate;
                int result = cn.ExecuteNonQuery(CommandType.StoredProcedure, "proIns_MedicalRecord_Abortions", param);
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
                return false;
            }
        }

        public static MedicalRecord_AbortionsINF ObjMedicalRecord_Abortions(string medicalRecordCode)
        {
            ConnectDB cn = new ConnectDB();
            MedicalRecord_AbortionsINF inf = new MedicalRecord_AbortionsINF();
            try
            {
                string sql = string.Empty;
                sql = @"select MedicalRecordCode,EmployeeCode,TTHonNhan,SoConHienCo,NgayKinhCuoiCung,ChuanDoanThai,PPPhaThai,KetQuaSoiMo,TaiBienMac,TaiBienChet,KhamLai,GhiChu,WorkDate
                        from MedicalRecord_Abortions where MedicalRecordCode in('{0}')";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, medicalRecordCode), null);
                if (ireader.Read())
                {
                    inf.MedicalRecordCode = ireader.GetValue(0).ToString();
                    inf.EmployeeCode = ireader.GetValue(1).ToString();
                    inf.TTHonNhan = ireader.GetValue(2).ToString() == "True" ? 1 : 0;
                    inf.SoConHienCo = Convert.ToInt32(ireader.GetValue(3).ToString());
                    inf.NgayKinhCuoiCung = ireader.GetValue(4).ToString();
                    inf.ChuanDoanThai = ireader.GetValue(5).ToString();
                    inf.PPPhaThai = ireader.GetValue(6).ToString();
                    inf.KetQuaSoiMo = ireader.GetValue(7).ToString();
                    inf.TaiBienMac = ireader.GetValue(8).ToString() == "True" ? 1 : 0;
                    inf.TaiBienChet = ireader.GetValue(9).ToString() == "True" ? 1 : 0;
                    inf.KhamLai = ireader.GetValue(10).ToString();
                    inf.GhiChu = ireader.GetValue(11).ToString();
                    inf.WorkDate = ireader.GetDateTime(12);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return inf;
            }
            catch { return null; }
        }

        public static List<MedicalRecord_INF> ListMedicalRecordForPatientCode(string patientCode, DateTime postingDate)
        {
            ConnectDB cn = new ConnectDB();
            List<MedicalRecord_INF> lstMedical = new List<MedicalRecord_INF>();
            try
            {
                string query = string.Empty;
                query = @"select RowID,MedicalRecordCode,PatientReceiveID,PatientCode, DepartmentCode,EmployeeCode,DiagnosisCode,DescriptionNode,PostingDate,Symptoms,ObjectCode, Advices, TackleCode,ContentMedicalPattern,DiagnosisCustom,Treatments,EmployeeCodeDoctor
                        from MedicalRecord where PatientCode=@PatientCode and convert(date,PostingDate,103)=convert(date,@PostingDate,103) order by PostingDate desc ";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 15);
                param[0].Value = patientCode;
                param[1] = new SqlParameter("@PostingDate", SqlDbType.Char, 10);
                param[1].Value = postingDate.ToString("dd/MM/yyyy");
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, query, param);
                while (ireader.Read())
                {
                    MedicalRecord_INF inf = new MedicalRecord_INF();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.MedicalRecordCode = ireader.GetString(1);
                    inf.PatientReceiveID = ireader.GetDecimal(2);
                    inf.PatientCode = ireader.GetString(3);
                    inf.DepartmentCode = ireader.GetString(4);
                    inf.EmployeeCode = ireader.GetString(5);
                    inf.DiagnosisCode = ireader.GetDecimal(6);
                    inf.DescriptionNode = ireader.GetValue(7).ToString();
                    inf.PostingDate = ireader.GetDateTime(8);
                    inf.Symptoms = ireader.GetValue(9).ToString();
                    inf.ObjectCode = ireader.GetInt32(10);
                    inf.Advices = ireader.GetValue(11).ToString();
                    if (ireader.GetValue(12).ToString() != string.Empty)
                        inf.TackleCode = ireader.GetInt32(12);
                    inf.ContentMedicalPattern = ireader.GetValue(13).ToString();
                    inf.DiagnosisCustom = ireader.GetValue(14).ToString();
                    inf.Treatments = ireader.GetValue(15).ToString();
                    inf.EmployeeCodeDoctor = ireader.GetValue(16).ToString();
                    lstMedical.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return lstMedical;
            }
            catch { return null; }
        }

        public static Int32 InsMedicalRecord_Emergency(MedicalRecord_INF info, ref string sMedicalCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[18];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = info.MedicalRecordCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = info.PatientReceiveID;
                param[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[2].Value = info.PatientCode;
                param[3] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[3].Value = info.DepartmentCode;
                param[4] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[4].Value = info.EmployeeCode;
                param[5] = new SqlParameter("@PostingDate", SqlDbType.DateTime);
                param[5].Value = info.PostingDate;
                param[6] = new SqlParameter("@ReferenceCode", SqlDbType.VarChar, 50);
                param[6].Value = info.ReferenceCode;
                param[7] = new SqlParameter("@Status", SqlDbType.Int);
                param[7].Value = info.Status;
                param[8] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[8].Value = info.ObjectCode;
                param[9] = new SqlParameter("@DiagnosisEnclosed", SqlDbType.Decimal);
                param[9].Value = info.DiagnosisEnclosed;
                param[10] = new SqlParameter("@AppointmentDate", SqlDbType.DateTime);
                param[10].Value = info.AppointmentDate;
                param[11] = new SqlParameter("@ShiftWork", SqlDbType.Char, 2);
                param[11].Value = info.ShiftWork;
                param[12] = new SqlParameter("@Treatments", SqlDbType.NVarChar);
                param[12].Value = info.Treatments;
                param[13] = new SqlParameter("@DiagnosisCustom", SqlDbType.NVarChar, 200);
                param[13].Value = info.DiagnosisCustom;
                param[14] = new SqlParameter("@Advices", SqlDbType.NVarChar, 250);
                param[14].Value = info.Advices;
                param[15] = new SqlParameter("@Symptoms", SqlDbType.NVarChar, 250);
                param[15].Value = info.Symptoms;
                param[16] = new SqlParameter("@ReceiptID", SqlDbType.Decimal);
                param[16].Value = info.ReceiptID;
                param[17] = new SqlParameter("@ResultMedicalCode", SqlDbType.VarChar, 50);
                param[17].Direction = ParameterDirection.Output;
                sMedicalCode = cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_MedicalRecord_Emergency", param);
                return 1;
            }
            catch { return -2; }
        }

        public static Int32 InsMedicalRecord_Surgeries(MedicalRecord_INF info, ref string sMedicalCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[12];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = info.MedicalRecordCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = info.PatientReceiveID;
                param[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[2].Value = info.PatientCode;
                param[3] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[3].Value = info.DepartmentCode;
                param[4] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[4].Value = info.EmployeeCode;
                param[5] = new SqlParameter("@PostingDate", SqlDbType.DateTime);
                param[5].Value = info.PostingDate;
                param[6] = new SqlParameter("@ReferenceCode", SqlDbType.VarChar, 50);
                param[6].Value = info.ReferenceCode;
                param[7] = new SqlParameter("@Status", SqlDbType.Int);
                param[7].Value = info.Status;
                param[8] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[8].Value = info.ObjectCode;
                param[9] = new SqlParameter("@DiagnosisEnclosed", SqlDbType.Decimal);
                param[9].Value = info.DiagnosisEnclosed;
                param[10] = new SqlParameter("@AppointmentDate", SqlDbType.DateTime);
                param[10].Value = info.AppointmentDate;
                param[11] = new SqlParameter("@ResultMedicalCode", SqlDbType.VarChar, 50);
                param[11].Direction = ParameterDirection.Output;
                sMedicalCode = cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_MedicalRecord_Surgeries", param);
                return 1;
            }
            catch { return -2; }
        }

        public static Int32 InsDiagnosisEnclosed(decimal dRowIDDiagnosis, string sMedicalRecordCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " insert into MedicalRecordDiagnosisEnclosed(RowIDDiagnosis,MedicalRecordCode) values(@RowIDDiagnosis,@MedicalRecordCode)";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@RowIDDiagnosis", SqlDbType.Decimal);
                param[0].Value = dRowIDDiagnosis;
                param[1] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[1].Value = sMedicalRecordCode;
                return cn.ExecuteNonQuery(CommandType.Text, sql, param);
            }
            catch { return -2; }
        }

        public static Int32 DelDiagnosisEnclosed(string sMedicalRecordCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " delete from MedicalRecordDiagnosisEnclosed where MedicalRecordCode=@MedicalRecordCode";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = sMedicalRecordCode;
                return cn.ExecuteNonQuery(CommandType.Text, sql, param);
            }
            catch { return -2; }
        }

        public static Int32 InsMedicalRecordDetail(MedicalPrescriptionDetail_INF info, Int32 objectCode_Patient)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[22];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = info.MedicalRecordCode;
                param[1] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[1].Value = info.EmployeeCode;
                param[2] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[2].Value = info.ItemCode;
                param[3] = new SqlParameter("@DateOfIssues", SqlDbType.Int);
                param[3].Value = info.DateOfIssues;
                param[4] = new SqlParameter("@Morning", SqlDbType.VarChar, 50);
                param[4].Value = info.Morning;
                param[5] = new SqlParameter("@Noon", SqlDbType.VarChar, 50);
                param[5].Value = info.Noon;
                param[6] = new SqlParameter("@Afternoon", SqlDbType.VarChar, 50);
                param[6].Value = info.Afternoon;
                param[7] = new SqlParameter("@Evening", SqlDbType.VarChar, 50);
                param[7].Value = info.Evening;
                param[8] = new SqlParameter("@Quantity", SqlDbType.Decimal);
                param[8].Value = info.Quantity;
                param[9] = new SqlParameter("@Instruction", SqlDbType.NVarChar, 1000);
                param[9].Value = info.Instruction;
                param[10] = new SqlParameter("@UnitPrice", SqlDbType.Decimal);
                param[10].Value = info.UnitPrice;
                param[11] = new SqlParameter("@Amount", SqlDbType.Decimal);
                param[11].Value = info.Amount;
                param[12] = new SqlParameter("@PostingDate", SqlDbType.DateTime);
                param[12].Value = info.PostingDate;
                param[13] = new SqlParameter("@Status", SqlDbType.Int);
                param[13].Value = info.Status;
                param[14] = new SqlParameter("@New", SqlDbType.Int);
                param[14].Value = info.New;
                param[15] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[15].Value = info.RepositoryCode;
                param[16] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[16].Value = info.ObjectCode;
                param[17] = new SqlParameter("@DoseOf", SqlDbType.Int);
                param[17].Value = info.DoseOf;
                param[18] = new SqlParameter("@DoseOfPills", SqlDbType.VarChar, 50);
                param[18].Value = info.DoseOfPills;
                param[19] = new SqlParameter("@BHYT", SqlDbType.Int);
                param[19].Value = info.BHYT;
                param[20] = new SqlParameter("@UnitOfMeasureCode_Medi", SqlDbType.VarChar, 15);
                param[20].Value = info.UnitOfMeasureCode_Medi;
                param[21] = new SqlParameter("@ObjectCode_Patient", SqlDbType.Int);
                param[21].Value = objectCode_Patient;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_MedicalPrescriptionDetail", param);
            }
            catch
            {
                return -2;
            }
        }

        public static Int32 UpdMedicalRecordDetailForNew(string sMedicalRecordCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " update MedicalPrescriptionDetail set new=0 where MedicalRecordCode='{0}'";
                return cn.ExecuteNonQuery(CommandType.Text, string.Format(sql, sMedicalRecordCode), null);
            }
            catch { return -2; }
        }

        public static Int32 UpdMedicalRecordForHide(string medicalRecordCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " update MedicalRecord set Hide=1 where MedicalRecordCode='{0}'";
                return cn.ExecuteNonQuery(CommandType.Text, string.Format(sql, medicalRecordCode), null);
            }
            catch { return -2; }
        }

        public static Int32 DelMedicalRecordDetail(string sMedicalRecordCode, decimal dRowID, int bhyt)
        {
            Int32 iResult = 0;
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = sMedicalRecordCode;
                param[1] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[1].Value = dRowID;
                param[2] = new SqlParameter("@Result", SqlDbType.Int);
                param[2].Direction = ParameterDirection.Output;
                param[3] = new SqlParameter("@BHYT", SqlDbType.Int);
                param[3].Value = bhyt;
                iResult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Del_MedicalPrescriptionDetail", param));
            }
            catch { iResult = -2; }
            return iResult;
        }

        public static Int32 DelMedicalRecord(string medicalRecordCode, decimal patientReceiveID, string patientCode)
        {
            Int32 iResult = 0;
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = medicalRecordCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = patientReceiveID;
                param[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[2].Value = patientCode;
                param[3] = new SqlParameter("@Result", SqlDbType.Int);
                param[3].Direction = ParameterDirection.Output;
                iResult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proDel_MedicalRecord", param));
            }
            catch { iResult = -2; }
            return iResult;
        }

        public static Int32 DelMedicalRecordDetailForItemCode(string sMedicalRecordCode, string sItemCode)
        {
            Int32 iResult = 0;
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "delete from MedicalPrescriptionDetail where MedicalRecordCode=@MedicalRecordCode and ItemCode=@ItemCode ";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = sMedicalRecordCode;
                param[1] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[1].Value = sItemCode;
                iResult = cn.ExecuteNonQuery(CommandType.Text, sql, param);
            }
            catch { iResult = -2; }
            return iResult;
        }
        public static Int32 DelMedicalRecordDetailForRowID(string sMedicalRecordCode, int sItemCode)
        {
            Int32 iResult = 0;
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "delete from MedicalPrescriptionDetail where MedicalRecordCode=@MedicalRecordCode and RowID=@RowID ";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = sMedicalRecordCode;
                param[1] = new SqlParameter("@RowID", SqlDbType.Int, 50);
                param[1].Value = sItemCode;
                iResult = cn.ExecuteNonQuery(CommandType.Text, sql, param);
            }
            catch { iResult = -2; }
            return iResult;
        }

        public static DataTable DT_GetResultMedical(string sMedicalRecordCode, decimal dPatientReceiveID, int blank)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = sMedicalRecordCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = dPatientReceiveID;
                param[2] = new SqlParameter("@Blank", SqlDbType.Int);
                param[2].Value = blank;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_ResultMedicalRecord", param);
            }
            catch { return null; }
        }

        public static DataTable TableMedicalPrescriptionForImmuni(string medicalRecordCode, string patientCode, decimal patientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = medicalRecordCode;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = patientCode;
                param[2] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[2].Value = patientReceiveID;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_MedicalPrescriptionForImmuni", param);
            }
            catch { return null; }
        }

        public static DataTable DT_GetResultMedical_Emergency(string sMedicalRecordCode, string sMedicalEmergencyCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = sMedicalRecordCode;
                param[1] = new SqlParameter("@MedicalEmergencyCode", SqlDbType.VarChar, 50);
                param[1].Value = sMedicalEmergencyCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_ResultMedicalRecord_Emergency", param);
            }
            catch { return null; }
        }

        public static DataTable DT_GetResultMedicalDetail(string sMedicalCode, string group, Int32 iObject, Int32 active, int status)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = sMedicalCode;
                param[1] = new SqlParameter("@RepositoryGroupCode", SqlDbType.VarChar, 10);
                param[1].Value = group;
                param[2] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[2].Value = iObject;
                param[3] = new SqlParameter("@Active", SqlDbType.Int);
                param[3].Value = active;
                param[4] = new SqlParameter("@Status", SqlDbType.Int);
                param[4].Value = status;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_ResultMedicalDetail", param);
            }
            catch { return null; }
        }

        public static DataTable DT_GetResultMedicalDetailForSurgeries(string surgeriesCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@SurgeriesCode", SqlDbType.VarChar, 15);
                param[0].Value = surgeriesCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_ResultMedicalDetailForSurgeries", param);
            }
            catch { return null; }
        }

        public static DataTable DT_GetResultMedicalDetailForRowId(string sMedicalCode, Int32 iGroup, Int32 iObject, string sRowID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = @" select a.MedicalRecordCode,a.ItemCode,b.ItemName,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening,
		            a.Quantity,a.Instruction,a.UnitPrice,b.SalesPrice,b.RateBHYT,a.Amount,c.UnitOfMeasureName,b.BHYTPrice,a.Status,a.RepositoryCode,
		            e.RepositoryName
		            from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode 
		            inner join UnitOfMeasure c on b.UnitOfMeasureCode=c.UnitOfMeasureCode inner join MedicalRecord d on a.MedicalRecordCode=d.MedicalRecordCode
		            inner join RepositoryCatalog e on a.RepositoryCode=e.RepositoryCode
		            where a.MedicalRecordCode='{0}' and d.ObjectCode={1} and e.RepositoryGroupCode={2} and a.RowID in({3})
		            order by a.ItemCode ";
                return cn.ExecuteQuery(string.Format(sql, sMedicalCode, iObject, iGroup, sRowID));
            }
            catch { return null; }
        }

        public static DataTable TableMedicalRecordDiagnosisEnclosed(string medicalCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = @" select a.RowID,(a.DiagnosisCode +' - ' +a.DiagnosisName)DiagnosisName
                        from Diagnosis a inner join MedicalRecordDiagnosisEnclosed b on a.RowID=b.RowIDDiagnosis where b.MedicalRecordCode='{0}' ";
                return cn.ExecuteQuery(string.Format(sql, medicalCode));
            }
            catch { return null; }
        }

        public static DataTable TableMedicalRecordDiagnosisEnclosed(string medicalCode, decimal patientReceiveID, int patientType)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = string.Empty;
                if (patientType.Equals(1))
                {
                    query = @" select a.RowID,(a.DiagnosisCode +' - ' +a.DiagnosisName)DiagnosisName
                        from Diagnosis a inner join MedicalRecordDiagnosisEnclosed b on a.RowID=b.RowIDDiagnosis inner join MedicalRecord c on b.MedicalRecordCode=c.MedicalRecordCode where c.PatientReceiveID={0} ";
                    if (!string.IsNullOrEmpty(medicalCode))
                        query += " and b.MedicalRecordCode='{1}'";
                    return cn.ExecuteQuery(string.Format(query, medicalCode));
                }
                else
                {
                    query = @" select a.RowID,(a.DiagnosisCode +' - ' +a.DiagnosisName)DiagnosisName
                        from Diagnosis a inner join MedicalRecordDiagnosisEnclosed b on a.RowID=b.RowIDDiagnosis inner join MedicalEmergency b.MedicalRecordCode=c.MedicalEmergencyCode where c.PatientReceiveID={0} ";
                    if (!string.IsNullOrEmpty(medicalCode))
                        query += " and b.MedicalRecordCode='{1}'";
                    return cn.ExecuteQuery(string.Format(query, medicalCode));
                }
            }
            catch { return null; }
        }

        public static DataTable DT_MedicalRecordDiagnosis(string sMedicalCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = @" select a.RowID,(a.DiagnosisCode +' - ' +a.DiagnosisName)DiagnosisName,a.DiagnosisName_EN
                from Diagnosis a inner join MedicalRecord b on a.RowID=b.DiagnosisCode where b.MedicalRecordCode='{0}' ";
                return cn.ExecuteQuery(string.Format(sql, sMedicalCode));
            }
            catch { return null; }
        }

        public static DataTable DT_TotalMedicalRecord(decimal dRefID, string sPatientCode, string sMedicalCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = @" select b.ItemCode,b.Quantity,b.UnitPrice,c.ListBHYT,c.RateBHYT
                                from MedicalRecord a inner join MedicalPrescriptionDetail b on a.MedicalRecordCode = b.MedicalRecordCode
                                inner join Items c on b.ItemCode = c.ItemCode
                                where b.MedicalRecordCode='{0}' and a.PatientCode='{1}' and a.PatientReceiveID={2} and a.Paid =0
                                union all
                                select b.ItemCode,b.Quantity,b.UnitPrice,c.ListBHYT,b.RateBHYT from RealMedicinesForPatients a inner join RealMedicinesForPatientsDetail b on a.RowID=b.RealRowID
                                inner join Items c on b.ItemCode = c.ItemCode
                                where a.RefCode='{0}' and a.PatientCode='{1}' and a.PatientReceiveID={2}
                                order by b.ItemCode ";
                dt = cn.ExecuteQuery(string.Format(sql, sMedicalCode, sPatientCode, dRefID));
            }
            catch { }
            return dt;
        }

        public static DataTable DT_MedicalDetailRecordOut(string sMedicalCode, string sDate)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = @" select b.ItemCode,b.Quantity,b.UnitPrice,c.ListBHYT,c.RateBHYT,c.ItemName
                                from MedicalRecord a inner join MedicalPrescriptionDetail b on a.MedicalRecordCode = b.MedicalRecordCode
                                inner join Items c on b.ItemCode = c.ItemCode
                                where b.MedicalRecordCode='{0}' and CONVERT(date,b.PostingDate,103)=CONVERT(date,'{1}',103)
                                 ";
                dt = cn.ExecuteQuery(string.Format(sql, sMedicalCode, sDate));
            }
            catch { }
            return dt;
        }

        public static DataTable DT_TotalMedicalRecord(decimal dRefID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = @" select b.ItemCode,b.Quantity,b.UnitPrice,c.ListBHYT,c.RateBHYT
                                from MedicalRecord a inner join MedicalPrescriptionDetail b on a.MedicalRecordCode = b.MedicalRecordCode
                                inner join Items c on b.ItemCode = c.ItemCode
                                where  a.PatientCode='{0}' and a.PatientReceiveID={1} and a.Paid =0
                                order by b.ItemCode ";
                dt = cn.ExecuteQuery(string.Format(sql, sPatientCode, dRefID));
            }
            catch { }
            return dt;
        }

        public static DataTable DT_Get_PrescriptionsOld(string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp.Columns.Add(new DataColumn("MedicalRecordCode", typeof(string)));
                dtTemp.Columns.Add(new DataColumn("PatientReceiveID", typeof(decimal)));
                dtTemp.Columns.Add(new DataColumn("PostingDate", typeof(DateTime)));
                dtTemp.Columns.Add(new DataColumn("PostingDateName", typeof(string)));
                dtTemp.Columns.Add(new DataColumn("DiagnosisCustom", typeof(string)));
                string sql = @"select distinct a.MedicalRecordCode,a.PatientReceiveID,a.PostingDate,(N'Toa ngày: '+CONVERT(char(10),a.PostingDate,103)) PostingDateName,a.DiagnosisCustom
                    from MedicalRecord a inner join MedicalPrescriptionDetail b on a.MedicalRecordCode=b.MedicalRecordCode 
                    where a.PatientCode ='{0}'";
                dtTemp = cn.ExecuteQuery(string.Format(sql, sPatientCode));
            }
            catch { }
            return dtTemp;
        }

        public static DataTable DT_Get_PrescriptionsOld(string sPatientCode, decimal dReceiveID, string sMedicalCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp.Columns.Add(new DataColumn("MedicalRecordCode", typeof(string)));
                dtTemp.Columns.Add(new DataColumn("PatientReceiveID", typeof(decimal)));
                dtTemp.Columns.Add(new DataColumn("PostingDate", typeof(DateTime)));
                dtTemp.Columns.Add(new DataColumn("PostingDateName", typeof(string)));
                dtTemp.Columns.Add(new DataColumn("Symptoms", typeof(string)));
                string sql = @"select distinct a.MedicalRecordCode,a.PatientReceiveID,a.PostingDate,(N'Toa ngày: '+CONVERT(char(10),a.PostingDate,103)) PostingDateName,a.Symptoms
                    from MedicalRecord a inner join MedicalPrescriptionDetail b on a.MedicalRecordCode=b.MedicalRecordCode 
                    where a.PatientCode ='{0}' and a.PatientReceiveID in({1}) and a.MedicalRecordCode='{2}'";
                dtTemp = cn.ExecuteQuery(string.Format(sql, sPatientCode, dReceiveID, sMedicalCode));
            }
            catch { }
            return dtTemp;
        }

        public static DataTable DT_Get_PrescriptionsOldFor(string sPatientCode, decimal dReceiveID, string sReferenceCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtTemp = new DataTable();
            try
            {
                dtTemp.Columns.Add(new DataColumn("MedicalRecordCode", typeof(string)));
                dtTemp.Columns.Add(new DataColumn("PatientReceiveID", typeof(decimal)));
                dtTemp.Columns.Add(new DataColumn("PostingDate", typeof(DateTime)));
                dtTemp.Columns.Add(new DataColumn("PostingDateName", typeof(string)));
                dtTemp.Columns.Add(new DataColumn("Symptoms", typeof(string)));
                string sql = @"select distinct a.MedicalRecordCode,a.PatientReceiveID,CONVERT(date,b.PostingDate,103) PostingDate,a.Symptoms
                    from MedicalRecord a inner join MedicalPrescriptionDetail b on a.MedicalRecordCode=b.MedicalRecordCode 
                    where a.PatientCode ='{0}' and a.PatientReceiveID in({1}) and a.ReferenceCode='{2}'
                    group by a.MedicalRecordCode,a.PatientReceiveID,CONVERT(date,b.PostingDate,103),a.Symptoms ";
                dtTemp = cn.ExecuteQuery(string.Format(sql, sPatientCode, dReceiveID, sReferenceCode));
            }
            catch { }
            return dtTemp;
        }

        public static List<MedicalRecord_WaitingBrowseModel> ListPatient_WaitingBrowse(Int32 iStatus, string sRepCode, Int32 typeMedical, Int32 done, DateTime dateFrom, DateTime dateTo)
        {
            ConnectDB cn = new ConnectDB();
            List<MedicalRecord_WaitingBrowseModel> list = new List<MedicalRecord_WaitingBrowseModel>();
            try
            {
                string sql = string.Empty;
                if (iStatus == 0)
                {
                    sql = @"  select a.MedicalRecordCode,a.PatientReceiveID,c.DepartmentName,a.PatientCode,d.PatientName,d.PatientAge,d.PatientBirthyear,(case when d.PatientGender=0 then N'Nữ' else N'Nam' end)PatientGenderName,
                        a.ObjectCode,e.ObjectName,0 RowIDMedicinesFor, '' as DateApproved,convert(date,a.PostingDate,103) PostingDate,[dbo].func_PatientOfAddressFull(a1.Address,b1.WardName,b2.DistrictName,b3.ProvincialName) PatientAddress, 0 as Printer
                        from MedicalRecord a inner join MedicalPrescriptionDetail b on a.MedicalRecordCode=b.MedicalRecordCode
                        inner join Department c on a.DepartmentCode=c.DepartmentCode inner join Patients d on a.PatientCode=d.PatientCode inner join Object e on a.ObjectCode=e.ObjectCode 
                        inner join PatientReceive a1 on a.PatientReceiveID=a1.PatientReceiveID left join Catalog_Ward b1 on a1.WardCode=b1.WardCode left join Catalog_District b2 on a1.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on a1.ProvincialCode=b3.ProvincialCode
                        where b.status in({0}) and CONVERT(date,a.PostingDate,103) between CONVERT(date,'{1}',103) and CONVERT(date,'{4}',103) and b.RepositoryCode in('{2}') and a.typeMedical in({3})
                        group by a.MedicalRecordCode,a.PatientReceiveID,c.DepartmentName,a.PatientCode,d.PatientName,d.PatientAge,d.PatientBirthyear,d.PatientGender, a.ObjectCode,e.ObjectName,convert(date,a.PostingDate,103),a1.Address,b1.WardName,b2.DistrictName,b3.ProvincialName
                        order by convert(date,a.PostingDate,103) desc ";
                }
                else
                {
                    sql = @"  select a.MedicalRecordCode,a.PatientReceiveID,c.DepartmentName,a.PatientCode,d.PatientName,d.PatientAge,d.PatientBirthyear,(case when d.PatientGender=0 then N'Nữ' else N'Nam' end)PatientGenderName,
                        a.ObjectCode,e.ObjectName,f.RowID RowIDMedicinesFor,f.DateApproved,convert(date,a.PostingDate,103) PostingDate,[dbo].func_PatientOfAddressFull(a1.Address,b1.WardName,b2.DistrictName,b3.ProvincialName) PatientAddress,0 as Printer
                        from MedicalRecord a inner join MedicalPrescriptionDetail b on a.MedicalRecordCode=b.MedicalRecordCode
                        inner join Department c on a.DepartmentCode=c.DepartmentCode inner join Patients d on a.PatientCode=d.PatientCode
                        inner join Object e on a.ObjectCode=e.ObjectCode inner join MedicinesForPatients f on a.MedicalRecordCode=f.MedicalRecordCode and a.PatientReceiveID=f.PatientReceiveID
                        inner join PatientReceive a1 on a.PatientReceiveID=a1.PatientReceiveID left join Catalog_Ward b1 on a1.WardCode=b1.WardCode left join Catalog_District b2 on a1.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on a1.ProvincialCode=b3.ProvincialCode
                        where b.status in({0}) and CONVERT(date,a.PostingDate,103) between CONVERT(date,'{1}',103) and CONVERT(date,'{4}',103) and b.RepositoryCode in('{2}') and a.typeMedical in({3}) and f.Done in(" + done + ")";
                    sql += "group by a.MedicalRecordCode,a.PatientReceiveID,c.DepartmentName,a.PatientCode,d.PatientName,d.PatientAge,d.PatientBirthyear,d.PatientGender,a.ObjectCode,e.ObjectName,f.RowID,f.DateApproved,convert(date,a.PostingDate,103),a1.Address,b1.WardName,b2.DistrictName,b3.ProvincialName order by convert(date,a.PostingDate,103) desc ";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iStatus, dateFrom.Date.ToString("dd/MM/yyyy"), sRepCode, typeMedical, dateTo.Date.ToString("dd/MM/yyyy")), null);
                while (ireader.Read())
                {
                    MedicalRecord_WaitingBrowseModel inf = new MedicalRecord_WaitingBrowseModel();
                    inf.MedicalRecordCode = ireader.GetString(0);
                    inf.PatientReceiveID = ireader.GetDecimal(1);
                    inf.DepartmentName = ireader.GetValue(2).ToString();
                    inf.PatientCode = ireader.GetValue(3).ToString();
                    inf.PatientName = ireader.GetValue(4).ToString();
                    inf.PatientAge = ireader.GetInt32(5);
                    inf.PatientBirthyear = ireader.GetInt32(6);
                    inf.PatientGenderName = ireader.GetValue(7).ToString();
                    inf.ObjectCode = ireader.GetInt32(8);
                    inf.ObjectName = ireader.GetValue(9).ToString();
                    inf.RowIDMedicinesFor = Convert.ToDecimal(ireader.GetValue(10));
                    inf.DateApproved = ireader.GetValue(11).ToString();
                    inf.PostingDate = ireader.GetValue(12).ToString();
                    inf.PatientAddress = ireader.GetValue(13).ToString();
                    inf.Printer = ireader.GetInt32(14);
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
        public static Int32 Done(Decimal MedicalRecordCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql1 = string.Empty;
                sql1 = @"select distinct MedicalRecordCode from MedicinesForPatients m inner join BanksAccount p on m.PatientReceiveID=p.ReferenceCode where p.ReferenceCode in ('{0}')";
                IDataReader ireader1 = cn.ExecuteReader(CommandType.Text, string.Format(sql1, MedicalRecordCode));
                if (ireader1.Read())
                {
                    string s = ireader1.GetValue(0).ToString();
                    string sql = string.Empty;
                    sql = @"select Done from MedicinesForPatients where MedicalRecordCode = '" + s + "'";
                    IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, MedicalRecordCode));
                    if (ireader.Read() == true)
                    {
                        if (ireader.GetInt32(0) == 1)
                            return 1;
                        else
                            return 0;
                    }
                    else
                        return 0;
                }
                else
                {
                    return 0;
                }
            }
            catch { }
            return 0;
        }
        public static List<MedicalRecord_WaitingBrowseModel> ListPatient_WaitingBrowseForBHYT(Int32 istatus, string sRepCode, Int32 typeMedical, Int32 done, DateTime dateFrom, DateTime dateTo, string objectCode)
        {
            ConnectDB cn = new ConnectDB();
            List<MedicalRecord_WaitingBrowseModel> list = new List<MedicalRecord_WaitingBrowseModel>();
            try
            {
                string sql = string.Empty;
                if (istatus == 0)
                {
                    sql = @" select a.MedicalRecordCode,a.PatientReceiveID,c.DepartmentName,a.PatientCode,d.PatientName,
                        d.PatientAge,d.PatientBirthyear,(case when d.PatientGender=0 then N'Nữ' else N'Nam' end)PatientGenderName,
                        a.ObjectCode,e.ObjectName,0 RowIDMedicinesFor, '' as DateApproved,convert(date,a.PostingDate,103) PostingDate,[dbo].func_PatientOfAddressFull(a1.Address,b1.WardName,b2.DistrictName,b3.ProvincialName) PatientAddress, 0 as Printer,'' EmployeeName
                        from MedicalRecord a inner join MedicalPrescriptionDetail b on a.MedicalRecordCode=b.MedicalRecordCode
                        inner join Department c on a.DepartmentCode=c.DepartmentCode inner join Patients d on a.PatientCode=d.PatientCode inner join Object e on a.ObjectCode=e.ObjectCode 
                        inner join PatientReceive a1 on a.PatientReceiveID=a1.PatientReceiveID left join Catalog_Ward b1 on a1.WardCode=b1.WardCode left join Catalog_District b2 on a1.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on a1.ProvincialCode=b3.ProvincialCode
                        where b.status in({0}) and CONVERT(date,a.PostingDate,103) between CONVERT(date,'{1}',103) and CONVERT(date,'{5}',103) and b.RepositoryCode in('{2}')  and a.typeMedical in({3}) and b.ObjectCode in({6})
                        group by a.MedicalRecordCode,a.PatientReceiveID,c.DepartmentName,a.PatientCode,d.PatientName,d.PatientAge,d.PatientBirthyear,d.PatientGender,
                        a.ObjectCode,e.ObjectName,convert(date,a.PostingDate,103),a1.Address,b1.WardName,b2.DistrictName,b3.ProvincialName
                        order by a.MedicalRecordCode asc ";
                }
                else
                {
                    sql = @"  select a.MedicalRecordCode,a.PatientReceiveID,c.DepartmentName,a.PatientCode,d.PatientName,
                        d.PatientAge,d.PatientBirthyear,(case when d.PatientGender=0 then N'Nữ' else N'Nam' end)PatientGenderName,
                        a.ObjectCode,e.ObjectName,f.RowID RowIDMedicinesFor,f.DateApproved,convert(date,a.PostingDate,103) PostingDate,[dbo].func_PatientOfAddressFull(a1.Address,b1.WardName,b2.DistrictName,b3.ProvincialName) PatientAddress,0 as Printer,a3.EmployeeName
                        from MedicalRecord a inner join MedicalPrescriptionDetail b on a.MedicalRecordCode=b.MedicalRecordCode
                        inner join Department c on a.DepartmentCode=c.DepartmentCode inner join Patients d on a.PatientCode=d.PatientCode
                        inner join Object e on a.ObjectCode=e.ObjectCode inner join MedicinesForPatients f on a.MedicalRecordCode=f.MedicalRecordCode and a.PatientReceiveID=f.PatientReceiveID
                        inner join PatientReceive a1 on a.PatientReceiveID=a1.PatientReceiveID left join Catalog_Ward b1 on a1.WardCode=b1.WardCode left join Catalog_District b2 on a1.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on a1.ProvincialCode=b3.ProvincialCode
                        left join MedicinesForPatients a2 on a.MedicalRecordCode=a2.MedicalRecordCode and a2.PatientReceiveID=a1.PatientReceiveID left join Employee a3 on a2.EmployeeCode=a3.EmployeeCode
                        where b.status in({0}) and CONVERT(date,a.PostingDate,103) between CONVERT(date,'{1}',103) and CONVERT(date,'{5}',103) and b.RepositoryCode in('{2}') and a.typeMedical in({3}) and f.Done in({4}) and b.ObjectCode in({6})
                        group by a.MedicalRecordCode,a.PatientReceiveID,c.DepartmentName,a.PatientCode,d.PatientName,d.PatientAge,d.PatientBirthyear,d.PatientGender,
                        a.ObjectCode,e.ObjectName,f.RowID,f.DateApproved,convert(date,a.PostingDate,103),a1.Address,b1.WardName,b2.DistrictName,b3.ProvincialName,a3.EmployeeName
                        order by f.RowID desc ";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, istatus, dateFrom.ToShortDateString(), sRepCode, typeMedical, done, dateTo.ToShortDateString(), objectCode), null);
                while (ireader.Read())
                {
                    MedicalRecord_WaitingBrowseModel inf = new MedicalRecord_WaitingBrowseModel();
                    inf.MedicalRecordCode = ireader.GetString(0);
                    inf.PatientReceiveID = ireader.GetDecimal(1);
                    inf.DepartmentName = ireader.GetValue(2).ToString();
                    inf.PatientCode = ireader.GetValue(3).ToString();
                    inf.PatientName = ireader.GetValue(4).ToString();
                    inf.PatientAge = ireader.GetInt32(5);
                    inf.PatientBirthyear = ireader.GetInt32(6);
                    inf.PatientGenderName = ireader.GetValue(7).ToString();
                    inf.ObjectCode = ireader.GetInt32(8);
                    inf.ObjectName = ireader.GetValue(9).ToString();
                    inf.RowIDMedicinesFor = Convert.ToDecimal(ireader.GetValue(10));
                    inf.DateApproved = ireader.GetValue(11).ToString();
                    inf.PostingDate = ireader.GetValue(12).ToString();
                    inf.PatientAddress = ireader.GetValue(13).ToString();
                    inf.Printer = ireader.GetInt32(14);
                    inf.EmployeeName = ireader.GetValue(15).ToString();
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
        public static List<MedicalRecord_WaitingBrowseModel> ListPatient_WaitingBrowseForBHYTCAPPHAT(Int32 istatus, string sRepCode, Int32 typeMedical, Int32 done, DateTime dateFrom, DateTime dateTo, string objectCode)
        {
            ConnectDB cn = new ConnectDB();
            List<MedicalRecord_WaitingBrowseModel> list = new List<MedicalRecord_WaitingBrowseModel>();
            try
            {
                string sql = string.Empty;
                if (istatus == 0)
                {
                    sql = @" select a.MedicalRecordCode,a.PatientReceiveID,c.DepartmentName,a.PatientCode,d.PatientName,
                        d.PatientAge,d.PatientBirthyear,(case when d.PatientGender=0 then N'Nữ' else N'Nam' end)PatientGenderName,
                        a.ObjectCode,e.ObjectName,0 RowIDMedicinesFor, '' as DateApproved,convert(date,a.PostingDate,103) PostingDate,[dbo].func_PatientOfAddressFull(a1.Address,b1.WardName,b2.DistrictName,b3.ProvincialName) PatientAddress, 0 as Printer,'' EmployeeName
                        from MedicalRecord a inner join MedicalPrescriptionDetail b on a.MedicalRecordCode=b.MedicalRecordCode
                        inner join Department c on a.DepartmentCode=c.DepartmentCode inner join Patients d on a.PatientCode=d.PatientCode inner join Object e on a.ObjectCode=e.ObjectCode 
                        inner join PatientReceive a1 on a.PatientReceiveID=a1.PatientReceiveID left join Catalog_Ward b1 on a1.WardCode=b1.WardCode left join Catalog_District b2 on a1.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on a1.ProvincialCode=b3.ProvincialCode
                        where b.status in({0}) and CONVERT(date,a.PostingDate,103) between CONVERT(date,'{1}',103) and CONVERT(date,'{5}',103) and b.RepositoryCode in('{2}')  and a.typeMedical in({3}) and b.ObjectCode in({6})
                        group by a.MedicalRecordCode,a.PatientReceiveID,c.DepartmentName,a.PatientCode,d.PatientName,d.PatientAge,d.PatientBirthyear,d.PatientGender,
                        a.ObjectCode,e.ObjectName,convert(date,a.PostingDate,103),a1.Address,b1.WardName,b2.DistrictName,b3.ProvincialName
                        order by a.MedicalRecordCode asc ";
                }
                else
                {
                    sql = @"select a.MedicalRecordCode,a.PatientReceiveID,c.DepartmentName,a.PatientCode,d.PatientName,
                        d.PatientAge,d.PatientBirthyear,(case when d.PatientGender=0 then N'Nữ' else N'Nam' end)PatientGenderName,
                        a.ObjectCode,e.ObjectName,f.RowID RowIDMedicinesFor,f.DateApproved,convert(date,a.PostingDate,103) PostingDate,[dbo].func_PatientOfAddressFull(a1.Address,b1.WardName,b2.DistrictName,b3.ProvincialName) PatientAddress,0 as Printer,a3.EmployeeName
                        from MedicalRecord a inner join MedicalPrescriptionDetail b on a.MedicalRecordCode=b.MedicalRecordCode
                        inner join Department c on a.DepartmentCode=c.DepartmentCode 
						inner join Patients d on a.PatientCode=d.PatientCode
                        inner join [Object] e on a.ObjectCode=e.ObjectCode 
						inner join MedicinesForPatients f on a.MedicalRecordCode=f.MedicalRecordCode and a.PatientReceiveID=f.PatientReceiveID
                        inner join PatientReceive a1 on a.PatientReceiveID=a1.PatientReceiveID 
						left join Catalog_Ward b1 on a1.WardCode=b1.WardCode 
						left join Catalog_District b2 on a1.DistrictCode=b2.DistrictCode 
						left join Catalog_Provincial b3 on a1.ProvincialCode=b3.ProvincialCode
                        and a.MedicalRecordCode=f.MedicalRecordCode and f.PatientReceiveID=a1.PatientReceiveID 
						left join Employee a3 on f.EmployeeCode=a3.EmployeeCode
                        left join MedicinesForPatientsDetail m on m.MedicalRecordCode = a.MedicalRecordCode    
                        where b.status in({0}) and CONVERT(date,a.PostingDate,103) between CONVERT(date,'{1}',103) and CONVERT(date,'{5}',103) and b.RepositoryCode in('{2}') and a.typeMedical in({3}) and f.Done in({4}) and b.ObjectCode in({6}) and m.Paid='1'
                        group by a.MedicalRecordCode,a.PatientReceiveID,c.DepartmentName,a.PatientCode,d.PatientName,d.PatientAge,d.PatientBirthyear,d.PatientGender,
                        a.ObjectCode,e.ObjectName,f.RowID,f.DateApproved,convert(date,a.PostingDate,103),a1.Address,b1.WardName,b2.DistrictName,b3.ProvincialName,a3.EmployeeName
                        order by f.RowID desc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, istatus, dateFrom.ToShortDateString(), sRepCode, typeMedical, done, dateTo.ToShortDateString(), objectCode), null);
                while (ireader.Read())
                {
                    MedicalRecord_WaitingBrowseModel inf = new MedicalRecord_WaitingBrowseModel();
                    inf.MedicalRecordCode = ireader.GetString(0);
                    inf.PatientReceiveID = ireader.GetDecimal(1);
                    inf.DepartmentName = ireader.GetValue(2).ToString();
                    inf.PatientCode = ireader.GetValue(3).ToString();
                    inf.PatientName = ireader.GetValue(4).ToString();
                    inf.PatientAge = ireader.GetInt32(5);
                    inf.PatientBirthyear = ireader.GetInt32(6);
                    inf.PatientGenderName = ireader.GetValue(7).ToString();
                    inf.ObjectCode = ireader.GetInt32(8);
                    inf.ObjectName = ireader.GetValue(9).ToString();
                    inf.RowIDMedicinesFor = Convert.ToDecimal(ireader.GetValue(10));
                    inf.DateApproved = ireader.GetValue(11).ToString();
                    inf.PostingDate = ireader.GetValue(12).ToString();
                    inf.PatientAddress = ireader.GetValue(13).ToString();
                    inf.Printer = ireader.GetInt32(14);
                    inf.EmployeeName = ireader.GetValue(15).ToString();
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

        public static List<MedicalRecordHistoryModel> ListHistoryMedicalReceive(string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<MedicalRecordHistoryModel> list = new List<MedicalRecordHistoryModel>();
            try
            {
                string sql = "";
                sql = @"  select b.PatientReceiveID,b.MedicalRecordCode,a.CreateDate,d.DepartmentName,c.DiagnosisCode,b.Symptoms
                            from PatientReceive a left join MedicalRecord b on a.PatientReceiveID=b.PatientReceiveID
                            inner join Diagnosis c on b.DiagnosisCode=c.RowID 
                            inner join Department d on b.DepartmentCode=d.DepartmentCode  
                         where a.PatientCode='{0}'
                         order by a.CreateDate ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sPatientCode), null);
                while (ireader.Read())
                {
                    MedicalRecordHistoryModel inf = new MedicalRecordHistoryModel();
                    inf.PatientReceiveID = ireader.GetDecimal(0);
                    inf.MedicalRecordCode = ireader.GetString(1);
                    inf.PostingDate = ireader.GetDateTime(2);
                    inf.DepartmentName = ireader.GetValue(3).ToString();
                    inf.DiagnosisCode = ireader.GetValue(4).ToString();
                    inf.Symptoms = ireader.GetValue(5).ToString();
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

        public static string refMedicalCode(decimal dPatientReceiveID, string sPatientCode, string sDepartmentCode, string sReferenceCode, ref Int32 refStatus, ref Int32 refPaid, ref string refBanksAccountCode)
        {
            ConnectDB cn = new ConnectDB();
            List<MedicalRecordHistoryModel> list = new List<MedicalRecordHistoryModel>();
            string sMedical = string.Empty;
            try
            {

                string sql = @"  select MedicalRecordCode,Status,Paid,BanksAccountCode
                        from MedicalRecord where PatientReceiveID={0} and PatientCode='{1}' and DepartmentCode in('{2}') and ReferenceCode='{3}'";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dPatientReceiveID, sPatientCode, sDepartmentCode, sReferenceCode), null);
                if (ireader.Read())
                {
                    sMedical = ireader.GetString(0);
                    refStatus = ireader.GetInt32(1);
                    refPaid = ireader.GetInt32(2);
                    refBanksAccountCode = ireader.GetValue(3).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { }
            return sMedical;
        }

        public static List<MedicalRecord_WaitingBrowseModel> ListPatient_WaitingBrowseForDate(Int32 iStatus, string dtFrom, string dtTo, bool done)
        {
            ConnectDB cn = new ConnectDB();
            List<MedicalRecord_WaitingBrowseModel> list = new List<MedicalRecord_WaitingBrowseModel>();
            try
            {
                string sql = string.Empty;
                sql = @"  select a.MedicalRecordCode,a.PatientReceiveID,c.DepartmentName,a.PatientCode,d.PatientName,d.PatientAge,d.PatientBirthyear,(case when d.PatientGender=0 then N'Nữ' else N'Nam' end) PatientGenderName,
                        a.ObjectCode,e.ObjectName,0 RowIDMedicinesFor, '' as DateApproved,(a2.Address+', '+b1.WardName+', '+b2.DistrictName+', '+b3.ProvincialName) PatientAddress,a1.DiagnosisName,a.DiagnosisCustom,d.PatientBirthday,d.PatientGender,a.EmployeeCodeDoctor
                        from MedicalRecord a inner join MedicalPrescriptionDetail b on a.MedicalRecordCode=b.MedicalRecordCode
                        inner join Department c on a.DepartmentCode=c.DepartmentCode inner join Patients d on a.PatientCode=d.PatientCode
                        inner join Object e on a.ObjectCode=e.ObjectCode left join Diagnosis a1 on a.DiagnosisCode=a1.RowID
                        inner join PatientReceive a2 on a.PatientReceiveID=a2.PatientReceiveID left join Catalog_Ward b1 on a2.WardCode=b1.WardCode left join Catalog_District b2 on a2.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on a2.ProvincialCode=b3.ProvincialCode
                        where b.status in({0}) and a.Hide=0 and b.BHYT in(0) and CONVERT(date,a.PostingDate,103) between CONVERT(date,'{1}',103) and CONVERT(date,'{2}',103)
                          ";
                if (!done)
                    sql += "and a.MedicalRecordCode not in(select a.MedicalRecordCode from MedicinesRetail a inner join MedicalRecord b on a.MedicalRecordCode=b.MedicalRecordCode where a.Paid in(1,2))";
                sql += " group by a.MedicalRecordCode,a.PatientReceiveID,c.DepartmentName,a.PatientCode,d.PatientName,d.PatientAge,d.PatientBirthyear,d.PatientGender,a.ObjectCode,e.ObjectName,d.PatientAddress,a1.DiagnosisName,a.DiagnosisCustom,a2.Address,b1.WardName,b2.DistrictName,b3.ProvincialName,d.PatientBirthday,d.PatientGender,a.EmployeeCodeDoctor";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iStatus, dtFrom, dtTo), null);
                while (ireader.Read())
                {
                    MedicalRecord_WaitingBrowseModel inf = new MedicalRecord_WaitingBrowseModel();
                    inf.MedicalRecordCode = ireader.GetString(0);
                    inf.PatientReceiveID = ireader.GetDecimal(1);
                    inf.DepartmentName = ireader.GetValue(2).ToString();
                    inf.PatientCode = ireader.GetValue(3).ToString();
                    inf.PatientName = ireader.GetValue(4).ToString();
                    inf.PatientAge = ireader.GetInt32(5);
                    inf.PatientBirthyear = ireader.GetInt32(6);
                    inf.PatientGenderName = ireader.GetValue(7).ToString();
                    inf.ObjectCode = ireader.GetInt32(8);
                    inf.ObjectName = ireader.GetValue(9).ToString();
                    inf.RowIDMedicinesFor = Convert.ToDecimal(ireader.GetValue(10));
                    inf.DateApproved = ireader.GetValue(11).ToString();
                    inf.PatientAddress = ireader.GetValue(12).ToString();
                    inf.DiagnosisName = ireader.GetValue(13).ToString();
                    inf.DiagnosisCustom = ireader.GetValue(14).ToString();
                    inf.PatientBirthday = Convert.ToDateTime(ireader.GetValue(15).ToString());
                    inf.PatientGender = ireader.GetInt32(16);
                    inf.EmployeeCodeDoctor = ireader.GetValue(17).ToString();
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

        public static DataTable DTMedicalRecordApprove(string sMedicalCode, Int32 iObjectCode, Int32 iStatus, decimal dRowIDMedicines)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("MedicalRecordCode", typeof(string)));
                dt.Columns.Add(new DataColumn("ItemCode", typeof(string)));
                dt.Columns.Add(new DataColumn("DateOfIssues", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Morning", typeof(string)));
                dt.Columns.Add(new DataColumn("Noon", typeof(string)));
                dt.Columns.Add(new DataColumn("Afternoon", typeof(string)));
                dt.Columns.Add(new DataColumn("Evening", typeof(string)));
                dt.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
                dt.Columns.Add(new DataColumn("Instruction", typeof(string)));
                dt.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                dt.Columns.Add(new DataColumn("Status", typeof(Int32)));
                dt.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
                dt.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
                dt.Columns.Add(new DataColumn("ItemName", typeof(string)));
                dt.Columns.Add(new DataColumn("SalesPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("BHYTPrice", typeof(decimal)));
                dt.Columns.Add(new DataColumn("RateBHYT", typeof(decimal)));
                dt.Columns.Add(new DataColumn("UnitOfMeasureName", typeof(string)));
                dt.Columns.Add(new DataColumn("PostingDate", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("RowID", typeof(Decimal)));
                string sql = string.Empty;
                sql = @" select a.MedicalRecordCode,a.ItemCode,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening,
                        a.Quantity,a.Instruction,b.SalesPrice UnitPrice,(a.Quantity*b.SalesPrice) Amount,a.Status,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.ItemName,
                        b.SalesPrice,b.BHYTPrice,b.RateBHYT,e.UnitOfMeasureName,a.PostingDate,a.RowID
                        from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode 
                        inner join MedicalRecord c on a.MedicalRecordCode=c.MedicalRecordCode inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode inner join UnitOfMeasure e on b.UnitOfMeasureCode=e.UnitOfMeasureCode
                        where a.MedicalRecordCode in('{0}') and c.ObjectCode in({1}) 
                        and a.Status in({2}) and a.BHYT in(0)
                        ";
                dt = cn.ExecuteQuery(string.Format(sql, sMedicalCode, iObjectCode, iStatus));
            }
            catch { }
            return dt;
        }

        public static DataTable hsba_MedicalRecord(decimal dPatientReceiveID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("MedicalRecordCode", typeof(string)));
                dt.Columns.Add(new DataColumn("PatientReceiveID", typeof(decimal)));
                dt.Columns.Add(new DataColumn("PatientCode", typeof(string)));
                dt.Columns.Add(new DataColumn("DepartmentCode", typeof(string)));
                dt.Columns.Add(new DataColumn("EmployeeCode", typeof(string)));
                dt.Columns.Add(new DataColumn("DiagnosisCode", typeof(decimal)));
                dt.Columns.Add(new DataColumn("DescriptionNode", typeof(string)));
                dt.Columns.Add(new DataColumn("PostingDate", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("AppointmentDate", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("ReferenceCode", typeof(string)));
                dt.Columns.Add(new DataColumn("Symptoms", typeof(string)));
                dt.Columns.Add(new DataColumn("Status", typeof(Int32)));
                dt.Columns.Add(new DataColumn("ObjectCode", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Advices", typeof(string)));
                dt.Columns.Add(new DataColumn("DiagnosisEnclosed", typeof(decimal)));
                dt.Columns.Add(new DataColumn("TackleCode", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Paid", typeof(Int32)));
                dt.Columns.Add(new DataColumn("BanksAccountCode", typeof(string)));
                string sql = string.Empty;
                sql = @" select RowID,MedicalRecordCode,PatientReceiveID,PatientCode,DepartmentCode,EmployeeCode,DiagnosisCode,DescriptionNode,PostingDate,AppointmentDate,ReferenceCode,Symptoms,Status,
                        ObjectCode,Advices,DiagnosisEnclosed,TackleCode,Paid,BanksAccountCode
                        from MedicalRecord
                        where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode
                        ";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = dPatientReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = sPatientCode;
                dt = cn.CallProcedureTable(CommandType.StoredProcedure, sql, param);
                //IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, param);
                //while (ireader.Read())
                //{
                //    DataRow dr = dt.NewRow();
                //    dr[0] = Convert.ToDecimal(ireader.GetValue(0).ToString());
                //    dr[1] = ireader.GetValue(1).ToString();
                //    dr[2] = Convert.ToDecimal(ireader.GetValue(2).ToString());
                //    dr[3] = ireader.GetValue(3).ToString();
                //    dr[4] = ireader.GetValue(4).ToString();
                //    dr[5] = ireader.GetValue(5).ToString();
                //    dr[6] = Convert.ToDecimal(ireader.GetValue(6).ToString());
                //    dr[7] = ireader.GetValue(7).ToString();
                //    dr[8] = Convert.ToDateTime(ireader.GetValue(8).ToString());
                //    dr[9] = Convert.ToDateTime(ireader.GetValue(9).ToString());
                //    dr[10] = ireader.GetValue(10).ToString();
                //    dr[11] = ireader.GetValue(11).ToString();
                //    dr[12] = Convert.ToInt32(ireader.GetValue(12).ToString());
                //    dr[13] = Convert.ToInt32(ireader.GetValue(13).ToString());
                //    dr[14] = ireader.GetValue(14).ToString();
                //    dr[15] = Convert.ToDecimal(ireader.GetValue(15).ToString());
                //    dr[16] = Convert.ToInt32(ireader.GetValue(16).ToString());
                //    dr[17] = Convert.ToInt32(ireader.GetValue(17).ToString());
                //    dr[18] = ireader.GetValue(18).ToString();
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

        public static DataTable hsba_MedicalDetail(string sMedicalCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = @" select RowID,MedicalRecordCode,EmployeeCode,ItemCode,DateOfIssues,Morning,Noon,Afternoon,Evening,Quantity,Instruction,UnitPrice,
                        Amount,PostingDate,Status,RepositoryCode,New
                        from MedicalPrescriptionDetail where MedicalRecordCode=@MedicalRecordCode
                        ";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = sMedicalCode;
                return cn.CallProcedureTable(CommandType.Text, sql, param);
            }
            catch { return null; }
        }

        public static DataTable hsba_DiagnosisEnclosed(decimal dReceiveID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = @" select a.RowIDDiagnosis,a.MedicalRecordCode from MedicalRecordDiagnosisEnclosed a inner join MedicalRecord b on a.MedicalRecordCode=b.MedicalRecordCode where b.PatientReceiveID=@PatientReceiveID and b.PatientCode=@PatientCode
                                union all
                                select a.RowIDDiagnosis,a.MedicalRecordCode from MedicalRecordDiagnosisEnclosed a inner join MedicalEmergency b on a.MedicalRecordCode=b.MedicalEmergencyCode where b.PatientReceiveID=@PatientReceiveID and b.PatientCode=@PatientCode
                                union all
                                select a.RowIDDiagnosis,a.MedicalRecordCode from MedicalRecordDiagnosisEnclosed a inner join MedicalEmergencyOut b on a.MedicalRecordCode=b.MedicalEmergencyOutCode where b.PatientReceiveID=@PatientReceiveID and b.PatientCode=@PatientCode
                                ";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = dReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = sPatientCode;
                return cn.CallProcedureTable(CommandType.Text, sql, param);
            }
            catch { return null; }
        }

        public static DataTable TableResultPrescription(string sPatientCode, string sFromdate, string sTodate, string sItemCode, string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                string sql = "";
                sql = @" select a.MedicalRecordCode,b.PatientCode,b.PatientName,[dbo].func_PatientOfAddressFull(b.PatientAddress,b1.WardName,b2.DistrictName,b3.ProvincialName) PatientAddress,b.PatientBirthyear,(case when b.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,a1.ItemCode,c.ItemName,c1.UnitOfMeasureName,
                        a1.Morning,a1.Noon,a1.Afternoon,a1.Evening,a1.Quantity,a1.Instruction,a1.UnitPrice,a1.Amount,CONVERT(date,a.PostingDate,103) PostingDate,a.Symptoms,CONVERT(date,d.CreateDate,103) InDate
                        from MedicalRecord a inner join MedicalPrescriptionDetail a1 on a.MedicalRecordCode=a1.MedicalRecordCode inner join Patients b on a.PatientCode=b.PatientCode
                        inner join Items c on a1.ItemCode=c.ItemCode inner join UnitOfMeasure c1 on c.UnitOfMeasureCode=c1.UnitOfMeasureCode inner join PatientReceive d on a.PatientReceiveID=d.PatientReceiveID
						left join Catalog_Ward b1 on b.WardCode=b1.WardCode left join Catalog_District b2 on b.DistrictCode=b2.DistrictCode left join Catalog_Provincial b3 on b.ProvincialCode=b3.ProvincialCode
                        where 1=1";
                if (sPatientCode != string.Empty)
                    sql += " and a.PatientCode='" + sPatientCode + "'";
                if (sFromdate != string.Empty && sTodate != string.Empty)
                    sql += " and CONVERT(date,a.PostingDate,103) between CONVERT(date,'" + sFromdate + "',103) and CONVERT(date,'" + sTodate + "',103)";
                if (sItemCode != string.Empty)
                    sql += " and a1.ItemCode='" + sItemCode + "'";
                if (employeeCode != string.Empty)
                    sql += " and a.EmployeeCode in(" + employeeCode + ")";
                dtResult = cn.ExecuteQuery(sql);
            }
            catch { }
            return dtResult;
        }

        public static DataTable TableResultPrescriptionGroupForDoctor(string sPatientCode, string sFromdate, string sTodate, string sItemCode, string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                string sql = "";
                sql = @" select a.MedicalRecordCode,b.PatientCode,b.PatientName,[dbo].func_PatientOfAddressFull(b.PatientAddress,w.WardName,di.DistrictName,ca.ProvincialName) PatientAddress,b.PatientBirthyear,(case when b.PatientGender=0 then N'Nữ' else 'Nam' end) PatientGenderName,sum(a1.Amount) Amount,CONVERT(date,a.PostingDate,103) PostingDate,CONVERT(date,d.CreateDate,103) InDate,a2.EmployeeName
                from MedicalRecord a inner join MedicalPrescriptionDetail a1 on a.MedicalRecordCode=a1.MedicalRecordCode inner join Patients b on a.PatientCode=b.PatientCode
                inner join Items c on a1.ItemCode=c.ItemCode inner join UnitOfMeasure c1 on c.UnitOfMeasureCode=c1.UnitOfMeasureCode inner join PatientReceive d on a.PatientReceiveID=d.PatientReceiveID
                left join Employee a2 on a.EmployeeCode=a2.EmployeeCode left join Catalog_Ward w on b.WardCode=w.WardCode left join Catalog_District di on b.DistrictCode=di.DistrictCode left join Catalog_Provincial ca on b.ProvincialCode=ca.ProvincialCode
                where 1=1";
                if (sPatientCode != string.Empty)
                    sql += " and a.PatientCode='" + sPatientCode + "'";
                if (sFromdate != string.Empty && sTodate != string.Empty)
                    sql += " and CONVERT(date,a.PostingDate,103) between CONVERT(date,'" + sFromdate + "',103) and CONVERT(date,'" + sTodate + "',103)";
                if (sItemCode != string.Empty)
                    sql += " and a1.ItemCode='" + sItemCode + "'";
                if (employeeCode != string.Empty)
                    sql += " and a.EmployeeCode in(" + employeeCode + ")";
                sql += " group by a.MedicalRecordCode,b.PatientCode,b.PatientName,b.PatientAddress,b.PatientBirthyear,b.PatientGender,a.PostingDate,d.CreateDate,a2.EmployeeName,w.WardName,di.DistrictName,ca.ProvincialName ";
                dtResult = cn.ExecuteQuery(sql);
            }
            catch { }
            return dtResult;
        }

        public static bool InsMedicalRecord_Childbirth(MedicalRecord_ChildbirthINF info, ref string msgError)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[27];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = info.MedicalRecordCode;
                param[1] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 15);
                param[1].Value = info.EmployeeCode;
                param[2] = new SqlParameter("@QLThai", SqlDbType.NVarChar, 150);
                param[2].Value = info.QLThai;
                param[3] = new SqlParameter("@TiemUV", SqlDbType.NVarChar, 150);
                param[3].Value = info.TiemUV;
                param[4] = new SqlParameter("@KT3Lan", SqlDbType.Bit);
                param[4].Value = info.KT3Lan;
                param[5] = new SqlParameter("@KT4Lan", SqlDbType.Bit);
                param[5].Value = info.KT4Lan;
                param[6] = new SqlParameter("@XNHIVMangThai", SqlDbType.NVarChar, 200);
                param[6].Value = info.XNHIVMangThai;
                param[7] = new SqlParameter("@XNHIVChuyenDa", SqlDbType.NVarChar, 200);
                param[7].Value = info.XNHIVChuyenDa;
                param[8] = new SqlParameter("@SLDeDuThang", SqlDbType.Int);
                param[8].Value = info.SLDeDuThang;
                param[9] = new SqlParameter("@SLDeNon", SqlDbType.Int);
                param[9].Value = info.SLDeNon;
                param[10] = new SqlParameter("@SLPhaThai", SqlDbType.Int);
                param[10].Value = info.SLPhaThai;
                param[11] = new SqlParameter("@SLConHienTai", SqlDbType.Int);
                param[11].Value = info.SLConHienTai;
                param[12] = new SqlParameter("@CachThucDe", SqlDbType.NVarChar, 200);
                param[12].Value = info.CachThucDe;
                param[13] = new SqlParameter("@TaiBienMac", SqlDbType.Int);
                param[13].Value = info.TaiBienMac;
                param[14] = new SqlParameter("@TaiBienTV", SqlDbType.Int);
                param[14].Value = info.TaiBienTV;
                param[15] = new SqlParameter("@CanNang", SqlDbType.NVarChar, 15);
                param[15].Value = info.CanNang;
                param[16] = new SqlParameter("@GioiTinh", SqlDbType.Int);
                param[16].Value = info.GioiTinh;
                param[17] = new SqlParameter("@TinhTrangCon", SqlDbType.NVarChar, 200);
                param[17].Value = info.TinhTrangCon;
                param[18] = new SqlParameter("@TVThaiNhi", SqlDbType.NVarChar, 200);
                param[18].Value = info.TVThaiNhi;
                param[19] = new SqlParameter("@NguoiDoDe", SqlDbType.NVarChar, 200);
                param[19].Value = info.NguoiDoDe;
                param[20] = new SqlParameter("@BuGioDau", SqlDbType.VarChar, 10);
                param[20].Value = info.BuGioDau;
                param[21] = new SqlParameter("@TiemViataminK1", SqlDbType.Bit);
                param[21].Value = info.TiemViataminK1;
                param[22] = new SqlParameter("@TiemVXViemGanB", SqlDbType.Bit);
                param[22].Value = info.TiemVXViemGanB;
                param[23] = new SqlParameter("@KhamTuanDau", SqlDbType.NVarChar, 200);
                param[23].Value = info.KhamTuanDau;
                param[24] = new SqlParameter("@KhamSauDe", SqlDbType.NVarChar, 200);
                param[24].Value = info.KhamSauDe;
                param[25] = new SqlParameter("@GhiChu", SqlDbType.NVarChar, 200);
                param[25].Value = info.GhiChu;
                param[26] = new SqlParameter("@WorkDate", SqlDbType.DateTime);
                param[26].Value = info.WorkDate;
                int result = cn.ExecuteNonQuery(CommandType.StoredProcedure, "proIns_MedicalRecord_Childbirth", param);
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
                return false;
            }
        }

        public static MedicalRecord_ChildbirthINF ObjMedicalRecord_Childbirth(string medicalRecordCode)
        {
            ConnectDB cn = new ConnectDB();
            MedicalRecord_ChildbirthINF inf = new MedicalRecord_ChildbirthINF();
            try
            {
                string sql = string.Empty;
                sql = @"select MedicalRecordCode,EmployeeCode,QLThai,TiemUV,KT3Lan,KT4Lan,XNHIVMangThai,XNHIVChuyenDa,SLDeDuThang,SLDeNon,SLPhaThai,SLConHienTai,CachThucDe,TaiBienMac,TaiBienTV,CanNang,GioiTinh,TinhTrangCon,TVThaiNhi,NguoiDoDe,BuGioDau,TiemViataminK1,TiemVXViemGanB,KhamTuanDau,KhamSauDe,GhiChu,WorkDate
                        from MedicalRecord_Childbirth where MedicalRecordCode in('{0}')";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, medicalRecordCode), null);
                if (ireader.Read())
                {
                    inf.MedicalRecordCode = ireader.GetValue(0).ToString();
                    inf.EmployeeCode = ireader.GetValue(1).ToString();
                    inf.QLThai = ireader.GetValue(2).ToString();
                    inf.TiemUV = ireader.GetValue(3).ToString();
                    inf.KT3Lan = ireader.GetValue(4).ToString() == "True" ? true : false;
                    inf.KT4Lan = ireader.GetValue(5).ToString() == "True" ? true : false;
                    inf.XNHIVMangThai = ireader.GetValue(6).ToString();
                    inf.XNHIVChuyenDa = ireader.GetValue(7).ToString();
                    inf.SLDeDuThang = Convert.ToInt32(ireader.GetValue(8).ToString());
                    inf.SLDeNon = Convert.ToInt32(ireader.GetValue(9).ToString());
                    inf.SLPhaThai = Convert.ToInt32(ireader.GetValue(10).ToString());
                    inf.SLConHienTai = Convert.ToInt32(ireader.GetValue(11).ToString());
                    inf.CachThucDe = ireader.GetValue(12).ToString();
                    inf.TaiBienMac = Convert.ToInt32(ireader.GetValue(13).ToString());
                    inf.TaiBienTV = Convert.ToInt32(ireader.GetValue(14).ToString());
                    inf.CanNang = ireader.GetValue(15).ToString();
                    inf.GioiTinh = Convert.ToInt32(ireader.GetValue(16).ToString());
                    inf.TinhTrangCon = ireader.GetValue(17).ToString();
                    inf.TVThaiNhi = ireader.GetValue(18).ToString();
                    inf.NguoiDoDe = ireader.GetValue(19).ToString();
                    inf.BuGioDau = ireader.GetValue(20).ToString();
                    inf.TiemViataminK1 = ireader.GetValue(21).ToString() == "True" ? true : false;
                    inf.TiemVXViemGanB = ireader.GetValue(22).ToString() == "True" ? true : false;
                    inf.KhamTuanDau = ireader.GetValue(23).ToString();
                    inf.KhamSauDe = ireader.GetValue(24).ToString();
                    inf.GhiChu = ireader.GetValue(25).ToString();
                    inf.WorkDate = ireader.GetDateTime(26);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return inf;
            }
            catch { return null; }
        }

        public static Int32 DelMedicalRecord_Childbirth(string medicalRecordCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " delete from MedicalRecord_Childbirth where MedicalRecordCode=@MedicalRecordCode";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = medicalRecordCode;
                return cn.ExecuteNonQuery(CommandType.Text, sql, param);
            }
            catch { return -2; }
        }
        public static Int32 DelMedicalRecord_Abortions(string medicalRecordCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " delete from MedicalRecord_Abortions where MedicalRecordCode=@MedicalRecordCode";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = medicalRecordCode;
                return cn.ExecuteNonQuery(CommandType.Text, sql, param);
            }
            catch { return -2; }
        }
        public static Int32 DelMedicalRecord_ANC(string medicalRecordCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " delete from MedicalRecord_ANC where MedicalRecordCode=@MedicalRecordCode";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = medicalRecordCode;
                return cn.ExecuteNonQuery(CommandType.Text, sql, param);
            }
            catch { return -2; }
        }
        public static string GetDrugMedicalrecord(decimal patientReceiveID, string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "select [dbo].func_MedicalRecordForItems(@PatientReceiveID ,@PatientCode) Drug";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = patientReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = patientCode;
                tableResult = cn.CallProcedureTable(CommandType.Text, query, param);
                if (tableResult != null && tableResult.Rows.Count > 0)
                    return tableResult.Rows[0][0].ToString();
                else
                    return string.Empty;
            }
            catch { return string.Empty; }
        }
        public static Int32 UpdMedicalRecordForDone(decimal receiptID, decimal discountAmount, string employeeCodeDoctor, int per, int status)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query01 = " update MedicalRecord set EmployeeCodeDoctor='{0}' where ReceiptID={1};";
                string query02 = " update Surgeries set EmployeeCode='{0}' where IDSuggested={1};";
                string query03 = " update ServiceRadiologyEntry set EmployeeCodeDoctor='{0}' where SuggestedID={1};";
                string query04 = " update SuggestedServiceReceipt set DiscountDoctorDone={0}, PerDiscountDoctorDone={1},ConfirmDiscountDone={2} where ReceiptID={3}";
                return cn.ExecuteNonQuery(CommandType.Text, string.Format(query01, employeeCodeDoctor, receiptID) + string.Format(query02, employeeCodeDoctor, receiptID) + string.Format(query03, employeeCodeDoctor, receiptID) + string.Format(query04, discountAmount, per, status, receiptID), null);
            }
            catch { return -2; }
        }
        public static Int32 UpdMedicalRecordForDoctorPointed(decimal receiptID, decimal discountAmount, string employeeCodeDoing, int per, int status)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = " update SuggestedServiceReceipt set PerDiscountDoctor={0}, DiscountDoctor={1},EmployeeCodeDoctor='{2}',ConfirmDiscountPointed={3} where ReceiptID={4}";
                return cn.ExecuteNonQuery(CommandType.Text, string.Format(query, per, discountAmount, employeeCodeDoing, status, receiptID));
            }
            catch { return -2; }
        }
    }
}
