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
    public class InventoryDal
    {
        public static Int32 Ins_InventoryGeneral(InventoryGeneralInf info, string sRepositoryCodeExport, string sWarehousingCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[0].Value = info.ItemCode;
                //param[1] = new SqlParameter("@MM", SqlDbType.Int);
                //param[1].Value = info.MM;
                //param[2] = new SqlParameter("@YYYY", SqlDbType.Int);
                //param[2].Value = info.YYYY;
                param[1] = new SqlParameter("@RepositoryCodeExport", SqlDbType.VarChar, 50);
                param[1].Value = sRepositoryCodeExport;
                param[2] = new SqlParameter("@RepositoryCodeReceived", SqlDbType.VarChar, 50);
                param[2].Value = info.RepositoryCode;
                param[3] = new SqlParameter("@WarehousingCode", SqlDbType.VarChar, 50);
                param[3].Value = sWarehousingCode;
                param[4] = new SqlParameter("@AmountImport", SqlDbType.Decimal);
                param[4].Value = info.AmountImpot;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_InventoryGeneral", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Del_InventoryGeneral(InventoryGeneralInf info, string sRepositoryCodeExport, string sWarehousingCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[0].Value = info.ItemCode;
                //param[1] = new SqlParameter("@MM", SqlDbType.Int);
                //param[1].Value = info.MM;
                //param[2] = new SqlParameter("@YYYY", SqlDbType.Int);
                //param[2].Value = info.YYYY;
                param[1] = new SqlParameter("@RepositoryCodeExport", SqlDbType.VarChar, 50);
                param[1].Value = sRepositoryCodeExport;
                param[2] = new SqlParameter("@RepositoryCodeReceived", SqlDbType.VarChar, 50);
                param[2].Value = info.RepositoryCode;
                param[3] = new SqlParameter("@WarehousingCode", SqlDbType.VarChar, 50);
                param[3].Value = sWarehousingCode;
                param[4] = new SqlParameter("@AmountImport", SqlDbType.Decimal);
                param[4].Value = info.AmountImpot;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_InventoryGeneral", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Upd_InventoryWareHousing(InventoryGeneralInf info, string sRepositoryCodeExport, string sWarehousingCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[0].Value = info.ItemCode;
                //param[1] = new SqlParameter("@MM", SqlDbType.Int);
                //param[1].Value = info.MM;
                //param[2] = new SqlParameter("@YYYY", SqlDbType.Int);
                //param[2].Value = info.YYYY;
                param[1] = new SqlParameter("@RepositoryCodeExport", SqlDbType.VarChar, 50);
                param[1].Value = sRepositoryCodeExport;
                param[2] = new SqlParameter("@RepositoryCodeReceived", SqlDbType.VarChar, 50);
                param[2].Value = info.RepositoryCode;
                param[3] = new SqlParameter("@WarehousingCode", SqlDbType.VarChar, 50);
                param[3].Value = sWarehousingCode;
                param[4] = new SqlParameter("@AmountImport", SqlDbType.Decimal);
                param[4].Value = info.AmountImpot;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Upd_InventoryWareHousing", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Ins_InventoryGumshoe(InventoryGumshoeInf infInven)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param1 = new SqlParameter[13];
                //param1[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                //param1[0].Value = infInven.RowID;
                param1[0] = new SqlParameter("@DateImport", SqlDbType.DateTime);
                param1[0].Value = infInven.DateImport;
                param1[1] = new SqlParameter("@MM", SqlDbType.Int);
                param1[1].Value = infInven.MM;
                param1[2] = new SqlParameter("@YYYY", SqlDbType.Int);
                param1[2].Value = infInven.YYYY;
                param1[3] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param1[3].Value = infInven.ItemCode;
                param1[4] = new SqlParameter("@AmountImport", SqlDbType.Decimal);
                param1[4].Value = infInven.AmountImport;
                param1[5] = new SqlParameter("@WarehousingCode", SqlDbType.VarChar, 50);
                param1[5].Value = infInven.WarehousingCode;
                param1[6] = new SqlParameter("@DateEnd", SqlDbType.Date);
                param1[6].Value = infInven.DateEnd;
                param1[7] = new SqlParameter("@SalesPrice", SqlDbType.Decimal);
                param1[7].Value = infInven.SalesPrice;
                param1[8] = new SqlParameter("@UnitPrice", SqlDbType.Decimal);
                param1[8].Value = infInven.UnitPrice;
                param1[9] = new SqlParameter("@Shipment", SqlDbType.NVarChar, 250);
                param1[9].Value = infInven.Shipment;
                param1[10] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar);
                param1[10].Value = infInven.RepositoryCode;
                param1[11] = new SqlParameter("@BHYTPrice", SqlDbType.Decimal);
                param1[11].Value = infInven.BHYTPrice;
                param1[12] = new SqlParameter("@IDWarehousingDetail", SqlDbType.Decimal);
                param1[12].Value = infInven.IDWarehousingDetail;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_InventoryGumshoe", param1) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch  { return -2; }
        }

        public static decimal QuantityInvent(string itemCode, ref decimal amountVirtual, string repositoryCode, ref decimal amountEnd)
        {
            ConnectDB cn = new ConnectDB();
            decimal dQuantity = 0;
            //InventoryGeneralInf inf = new InventoryGeneralInf();
            try
            {
                string sql = @" select a.ItemCode,a.RepositoryCode,a.AmountVirtual,a.AmountBegin,
                                a.AmountImport,a.AmountExport,a.AmountEnd from InventoryGeneral a where a.ItemCode='{0}' and a.RepositoryCode='{1}'";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, itemCode, repositoryCode), null);
                if (ireader.Read())
                {
                    //inf.ItemCode = ireader.GetString(0);
                    //inf.MM = ireader.GetDecimal(1);
                    //inf.YYYY = ireader.GetDecimal(2);
                    //inf.RepositoryCode = ireader.GetValue(3).ToString();
                    //inf.AmountVirtual = ireader.GetDecimal(4);
                    //inf.AmountBegin = ireader.GetDecimal(5);
                    //inf.AmountImpot = ireader.GetDecimal(6);
                    //inf.AmountExpot = ireader.GetDecimal(7);
                    //inf.AmountEnd = ireader.GetDecimal(8);
                    amountVirtual = ireader.GetDecimal(2);
                    dQuantity = (ireader.GetDecimal(3) + ireader.GetDecimal(4) - ireader.GetDecimal(5));
                    amountEnd = ireader.GetDecimal(6);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return dQuantity;
            }
            catch { return 0; }
        }

        public static List<InventoryGumshoeInf> ListInventoryGumshoe(string itemCode, string repositoryCode, string sort, bool isGiaThuocDanhMuc)
        {
            ConnectDB cn = new ConnectDB();
            List<InventoryGumshoeInf> lst = new List<InventoryGumshoeInf>();
            try
            {
                string query = string.Empty;
                if (!isGiaThuocDanhMuc)
                {
                    query = @" select RowID,DateImport,MM,YYYY,ItemCode,AmountImport,WarehousingCode,DateEnd,SalesPrice,UnitPrice,AmountExport, Shipment,RepositoryCode,BHYTPrice
                                from InventoryGumshoe where ItemCode='{0}' and RepositoryCode='{1}' and AmountImport > AmountExport";
                    if (!string.IsNullOrEmpty(sort))
                        query += " order by " + sort;
                    else
                        query += " order by DateImport asc";
                }
                else
                {
                    query = @" select a.RowID,a.DateImport,a.MM,a.YYYY,a.ItemCode,a.AmountImport,a.WarehousingCode,a.DateEnd,b.SalesPrice,b.UnitPrice,a.AmountExport,a.Shipment,a.RepositoryCode,b.BHYTPrice
                                from InventoryGumshoe a inner join items b on a.ItemCode=b.ItemCode where a.ItemCode='{0}' and a.RepositoryCode='{1}' and a.AmountImport > a.AmountExport";
                    if (!string.IsNullOrEmpty(sort))
                        query += " order by " + sort;
                    else
                        query += " order by a.DateImport asc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(query, itemCode, repositoryCode), null);
                while (ireader.Read())
                {
                    InventoryGumshoeInf inf = new InventoryGumshoeInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.DateImport = ireader.GetDateTime(1);
                    inf.MM = ireader.GetDecimal(2);
                    inf.YYYY = ireader.GetDecimal(3);
                    inf.ItemCode = ireader.GetString(4);
                    inf.AmountImport = ireader.GetDecimal(5);
                    inf.WarehousingCode = ireader.GetString(6);
                    inf.DateEnd = ireader.GetDateTime(7);
                    inf.SalesPrice = ireader.GetDecimal(8);
                    inf.UnitPrice = ireader.GetDecimal(9);
                    inf.AmountExport = ireader.GetDecimal(10);
                    inf.Shipment = ireader.GetValue(11).ToString();
                    inf.RepositoryCode = ireader.GetString(12);
                    inf.BHYTPrice = ireader.GetDecimal(13);
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

        public static List<InventoryGumshoeInf> ListInventoryGumshoe(string itemCode, string repositoryCode, string sort, string shipment)
        {
            ConnectDB cn = new ConnectDB();
            List<InventoryGumshoeInf> lst = new List<InventoryGumshoeInf>();
            try
            {
                string sql = @" select RowID,DateImport,MM,YYYY,ItemCode,AmountImport,WarehousingCode,DateEnd,SalesPrice,UnitPrice,AmountExport, Shipment,RepositoryCode,BHYTPrice
                                from InventoryGumshoe where ItemCode='{0}' and RepositoryCode='{1}' and AmountImport > AmountExport";
                if (!string.IsNullOrEmpty(shipment))
                    sql += " and Shipment='{2}'";
                if (!string.IsNullOrEmpty(sort))
                    sql += " order by " + sort;
                else
                    sql += " order by DateImport asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, itemCode, repositoryCode, shipment), null);
                while (ireader.Read())
                {
                    InventoryGumshoeInf inf = new InventoryGumshoeInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.DateImport = ireader.GetDateTime(1);
                    inf.MM = ireader.GetDecimal(2);
                    inf.YYYY = ireader.GetDecimal(3);
                    inf.ItemCode = ireader.GetString(4);
                    inf.AmountImport = ireader.GetDecimal(5);
                    inf.WarehousingCode = ireader.GetString(6);
                    inf.DateEnd = ireader.GetDateTime(7);
                    inf.SalesPrice = ireader.GetDecimal(8);
                    inf.UnitPrice = ireader.GetDecimal(9);
                    inf.AmountExport = ireader.GetDecimal(10);
                    inf.Shipment = ireader.GetValue(11).ToString();
                    inf.RepositoryCode = ireader.GetString(12);
                    inf.BHYTPrice = ireader.GetDecimal(13);
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

        public static DataTable TableTagWarehousing(string repositoryCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[0].Value = repositoryCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_ViewTagWarehousing", param);
            }
            catch { return null; }
        }

        public static DataTable TableTagRepositoryGeneral(string repositoryCode, DateTime dateForm, DateTime dateTo, string itemCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[0].Value = repositoryCode;
                param[1] = new SqlParameter("@FromDate", SqlDbType.Date);
                param[1].Value = dateForm;
                param[2] = new SqlParameter("@ToDate", SqlDbType.Date);
                param[2].Value = dateTo;
                param[3] = new SqlParameter("@ItemCode", SqlDbType.VarChar);
                param[3].Value = itemCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_Report_TagGeneral", param);
            }
            catch { return null; }
        }

        public static Int32 Del_GumshoeForHousingCode(string repositoryCode, string warehousingCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@WarehousingCode", SqlDbType.VarChar, 50);
                param[1].Value = warehousingCode;
                param[2] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[2].Value = repositoryCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_GumshoeForHousingCode", param);
            }
            catch { return -1; }
        }

        public static DataTable TableViewShipmentDateEnd()
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_ViewShipmentDateEnd", null);
            }
            catch { return null; }
        }

        public static Int32 Upd_InventoryShipmentDateEnd(string itemCode, string shipment, DateTime dtimeEnd, string shipmentNew, DateTime dtimeEndNew )
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[0].Value = itemCode;
                param[1] = new SqlParameter("@Shipment", SqlDbType.NVarChar, 250);
                param[1].Value = shipment;
                param[2] = new SqlParameter("@DateEnd", SqlDbType.Date);
                param[2].Value = dtimeEnd;
                param[3] = new SqlParameter("@ShipmentNew", SqlDbType.NVarChar, 250);
                param[3].Value = shipmentNew;
                param[4] = new SqlParameter("@DateEndNew", SqlDbType.Date);
                param[4].Value = dtimeEndNew;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "proUpd_InventoryShipmentDateEnd", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Upd_WarehousingInven(string warehousingCode, decimal rowID, string repositoryCode, string itemCode, string unitOfMeasureCode, decimal quantity, decimal unitPrice, decimal bhytPrice, decimal amount, int tax, decimal scot, decimal totalTax, decimal salesPrice, string shipment, DateTime dtimeEnd)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[16];
                param[0] = new SqlParameter("@WarehousingCode", SqlDbType.VarChar, 50);
                param[0].Value = warehousingCode;
                param[1] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[1].Value = rowID;
                param[2] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[2].Value = repositoryCode;
                param[3] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[3].Value = itemCode;
                param[4] = new SqlParameter("@UnitOfMeasureCode", SqlDbType.VarChar, 50);
                param[4].Value = unitOfMeasureCode;
                param[5] = new SqlParameter("@Quantity", SqlDbType.Decimal);
                param[5].Value = quantity;
                param[6] = new SqlParameter("@UnitPrice", SqlDbType.Decimal);
                param[6].Value = unitPrice;
                param[7] = new SqlParameter("@BHYTPrice", SqlDbType.Decimal);
                param[7].Value = bhytPrice;
                param[8] = new SqlParameter("@Amount", SqlDbType.Decimal);
                param[8].Value = amount;
                param[9] = new SqlParameter("@Tax", SqlDbType.Int);
                param[9].Value = tax;
                param[10] = new SqlParameter("@Scot", SqlDbType.Decimal);
                param[10].Value = scot;
                param[11] = new SqlParameter("@TotalTax", SqlDbType.Decimal);
                param[11].Value = totalTax;
                param[12] = new SqlParameter("@SalesPrice", SqlDbType.Decimal);
                param[12].Value = salesPrice;
                param[13] = new SqlParameter("@Shipment", SqlDbType.NVarChar, 250);
                param[13].Value = shipment;
                param[14] = new SqlParameter("@DateEnd", SqlDbType.Date);
                param[14].Value = dtimeEnd;
                param[15] = new SqlParameter("@Result", SqlDbType.NVarChar, 200);
                param[15].Direction = ParameterDirection.Output;
                return Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proUpd_WarehousingInven", param));
            }
            catch { return -10; }
        }

        public static DataTable TableShipmentForItem(string itemCode, string repositoryCode)
        {
            ConnectDB connect = new ConnectDB();
            try
            {
                string query = "select RTRIM(LTRIM(Shipment)) as Shipment,ItemCode from InventoryGumshoe where AmountExport<=AmountImport and AmountExport>=0 and (Shipment is not null and Shipment<>'') and ItemCode=(case @ItemCode when '' then ItemCode else @ItemCode end) and RepositoryCode=@RepositoryCode group by RTRIM(LTRIM(Shipment)),ItemCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[0].Value = repositoryCode;
                param[1] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[1].Value = itemCode;
                return connect.CallProcedureTable(CommandType.Text, query, param);
            }
            catch { return null; }
        }

        public static Int32 InsInventoryLimited(InventoryLimitedInf inven)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "pro_InsInventoryLimited";
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[0].Value = inven.ItemCode;
                param[1] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[1].Value = inven.RepositoryCode;
                param[2] = new SqlParameter("@Quantity", SqlDbType.Int);
                param[2].Value = inven.Quantity;
                param[3] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[3].Value = inven.EmployeeCode;
                param[4] = new SqlParameter("@IEmployeeCode", SqlDbType.VarChar, 50);
                param[4].Value = inven.IEmployeeCode;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, query, param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

    }
}
