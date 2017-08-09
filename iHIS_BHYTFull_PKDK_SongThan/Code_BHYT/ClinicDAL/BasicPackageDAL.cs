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
    public class BasicPackageDAL
    {
        public static DataTable TableItemsRef()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ItemCode", typeof(string)));
            dt.Columns.Add(new DataColumn("ItemName", typeof(string)));
            dt.Columns.Add(new DataColumn("UnitOfMeasureName", typeof(string)));
            dt.Columns.Add(new DataColumn("UnitOfMeasureCode", typeof(string)));
            dt.Columns.Add(new DataColumn("ItemCategoryName", typeof(string)));
            dt.Columns.Add(new DataColumn("UsageCode", typeof(string)));
            dt.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
            dt.Columns.Add(new DataColumn("SalesPrice", typeof(decimal)));
            dt.Columns.Add(new DataColumn("SafelyQuantity", typeof(Int32)));
            dt.Columns.Add(new DataColumn("BHYTPrice", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Active", typeof(string)));
            dt.Columns.Add(new DataColumn("AmountVirtual", typeof(decimal)));
            dt.Columns.Add(new DataColumn("RepositoryCode", typeof(string)));
            dt.Columns.Add(new DataColumn("RepositoryName", typeof(string)));
            dt.Columns.Add(new DataColumn("AmountEnd", typeof(decimal)));
            dt.Columns.Add(new DataColumn("RateBHYT", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Note", typeof(string)));
            dt.Columns.Add(new DataColumn("ListBHYT", typeof(Int32)));
            dt.Columns.Add(new DataColumn("RepositoryGroupCode", typeof(Int32)));
            dt.Columns.Add(new DataColumn("SODKGP", typeof(string)));
            try
            {
                string sql = string.Empty;
                sql = @"  Select a.ItemCode,a.ItemName,c.UnitOfMeasureName,a.UnitPrice,b.ItemCategoryName, a.SafelyQuantity,a.BHYTPrice,a.UnitOfMeasureCode,a.Active,a.UsageCode, a.SalesPrice,
                        0 as AmountVirtual,'' as RepositoryCode,'' as RepositoryName,0 as AmountEnd,a.RateBHYT,a.Note,a.ListBHYT,'' as RepositoryGroupCode,a.SODKGP
                        from Items a inner join ItemCategory b on a.ItemCategoryCode=b.ItemCategoryCode 
                        inner join UnitOfMeasure c on a.UnitOfMeasureCode = c.UnitOfMeasureCode order by a.ItemCode asc 
                        ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql), null);
                while (ireader.Read())
                {
                    Items_Ref inf = new Items_Ref();
                    inf.ItemCode = ireader.GetString(0);
                    inf.ItemName = ireader.GetValue(1).ToString();
                    inf.UnitOfMeasureName = ireader.GetValue(2).ToString();
                    inf.UnitPrice = Convert.ToDecimal(ireader.GetValue(3).ToString());
                    inf.ItemCategoryName = ireader.GetString(4);
                    inf.SafelyQuantity = ireader.GetInt32(5);
                    inf.BHYTPrice = Convert.ToDecimal(ireader.GetValue(6).ToString());
                    inf.UnitOfMeasureCode = ireader.GetValue(7).ToString();
                    inf.Active = ireader.GetValue(8).ToString();
                    inf.UsageCode = ireader.GetValue(9).ToString();
                    inf.SalesPrice = Convert.ToDecimal(ireader.GetValue(10).ToString());
                    inf.AmountVirtual = ireader.GetDecimal(11);
                    inf.RepositoryCode = ireader.GetValue(12).ToString();
                    inf.RepositoryName = ireader.GetValue(13).ToString();
                    inf.AmountEnd = ireader.GetDecimal(14);
                    inf.RateBHYT = ireader.GetDecimal(15);
                    inf.Note = ireader.GetValue(16).ToString();
                    inf.ListBHYT = ireader.GetInt32(17);
                    inf.SODKGP = ireader.GetValue(19).ToString();
                    if ((Convert.ToInt32(ireader.GetValue(18).ToString()) == 2 || Convert.ToInt32(ireader.GetValue(18).ToString()) == 3) && ireader.GetInt32(17) == 1)
                        inf.ListBHYT = 1;
                    else
                        inf.ListBHYT = 0;
                    inf.RepositoryGroupCode = Convert.ToInt32(ireader.GetValue(18).ToString());
                    dt.Rows.Add(inf.ItemCode, inf.ItemName, inf.UnitOfMeasureName, inf.UnitOfMeasureCode, inf.ItemCategoryName, inf.UsageCode, inf.UnitPrice, inf.SalesPrice, inf.SafelyQuantity, inf.BHYTPrice, inf.Active, inf.AmountVirtual, inf.RepositoryCode, inf.RepositoryName, inf.AmountEnd, inf.RateBHYT, inf.Note, inf.ListBHYT, inf.RepositoryGroupCode, inf.SODKGP);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch (Exception) { }
            return dt;
        }

        public static DataTable TableMedicalRecord(string medicalCode)
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
                string sql = string.Empty;
                sql = @" select a.MedicalRecordCode,a.ItemCode,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening,
                        a.Quantity,a.Instruction,a.UnitPrice,a.Amount,a.Status,b.UnitOfMeasureCode,a.RepositoryCode,d.RepositoryName,b.ItemName,a.RowID,a.DoseOf,a.DoseOfPills,a.ObjectCode,b.RateBHYT,d.RepositoryGroupCode,b.UsageCode,b.SODKGP
                        from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode inner join MedicalRecord c on a.MedicalRecordCode=c.MedicalRecordCode inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode
                        where a.MedicalRecordCode in('{0}') ";
                tableResult = cn.ExecuteQuery(string.Format(sql, medicalCode));
            }
            catch { }
            return tableResult;
        }

        public static DataTable TableGetResultMedicalDetail(string medicalCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = medicalCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proBasic_ResultMedicalDetail", param);
            }
            catch { return null; }
        }

    }
}
