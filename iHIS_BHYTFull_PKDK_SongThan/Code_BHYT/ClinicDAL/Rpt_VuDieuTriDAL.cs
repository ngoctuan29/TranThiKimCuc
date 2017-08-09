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
    public class Rpt_VuDieuTriDAL
    {
        #region Bieu Mau05
        public static DataTable TableBM05Template()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            string query = " select RowIDTemplate,OrderNumber,LaMa,LaMa_Detail,TargetName,Result,ServiceCode from BM05_YTTN_Template order by LaMa,OrderNumber ";
            try
            {
                dtResult = cn.CallProcedureTable(CommandType.Text, query, null);
                return dtResult;
            }
            catch { return null; }
        }
        public static DataTable TableBM05Default()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            string query = " select 0 as RowID_BM05, RowIDTemplate,LaMa,LaMa_Detail,TargetName,Result,ServiceCode, 0 as Check_ from BM05_YTTN_Template order by LaMa,OrderNumber ";
            try
            {
                dtResult = cn.CallProcedureTable(CommandType.Text, query, null);
                return dtResult;
            }
            catch { return null; }
        }
        public static DataTable TableBM05Default(decimal rowID_BM05)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            string query = " select b.RowID_BM05, b.RowIDTemplate,c.LaMa,c.LaMa_Detail,b.TargetName,b.Result,c.ServiceCode, 0 as Check_ from BM05_YTTN a inner join BM05_YTTN_Detail b on a.RowID = b.RowID_BM05 inner join BM05_YTTN_Template c on b.RowIDTemplate=c.RowIDTemplate where b.RowID_BM05=@RowID_BM05 order by c.LaMa,c.OrderNumber ";
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RowID_BM05", SqlDbType.Decimal);
                param[0].Value = rowID_BM05;
                dtResult = cn.CallProcedureTable(CommandType.Text, query, param);
                return dtResult;
            }
            catch { return null; }
        }
        public static DataTable TableBM05()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            string query = " select RowID, FromDate, ToDate, (N'Bao Cao: ' + convert(char(10),FromDate,103) +' - ' + convert(char(10),ToDate,103)) BM05Name from BM05_YTTN order by RowID desc ";
            try
            {
                dtResult = cn.CallProcedureTable(CommandType.Text, query, null);
                return dtResult;
            }
            catch { return null; }
        }
        public static DataTable TableViewBM05(decimal rowID_BM05)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                string query = "proView_MBM05_SKSS";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RowID_BM05", SqlDbType.Decimal);
                param[0].Value = rowID_BM05;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, query, param);
                return dtResult;
            }
            catch { return null; }
        }
        public static DataTable TableViewTotalSuggested(DateTime dtfrom, DateTime dtto, string serviceCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            try
            {
                string query = "proView_TotalSuggested";
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@FromDate", SqlDbType.Date);
                param[0].Value = dtfrom;
                param[1] = new SqlParameter("@ToDate", SqlDbType.Date);
                param[1].Value = dtto;
                param[2] = new SqlParameter("@ServiceCode", SqlDbType.VarChar);
                param[2].Value = serviceCode;
                dtResult = cn.CallProcedureTable(CommandType.StoredProcedure, query, param);
                return dtResult;
            }
            catch { return null; }
        }
        public static Int32 InsBM05(BM05_YTTN_TemplateInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@RowIDTemplate", SqlDbType.Int);
                param[0].Value = info.RowIDTemplate;
                param[1] = new SqlParameter("@OrderNumber", SqlDbType.Int);
                param[1].Value = info.OrderNumber;
                param[2] = new SqlParameter("@LaMa", SqlDbType.VarChar);
                param[2].Value = info.LaMa;
                param[3] = new SqlParameter("@LaMa_Detail", SqlDbType.VarChar);
                param[3].Value = info.LaMa_Detail;
                param[4] = new SqlParameter("@TargetName", SqlDbType.NVarChar);
                param[4].Value = info.TargetName;
                param[5] = new SqlParameter("@Result", SqlDbType.NVarChar);
                param[5].Value = info.Result;
                param[6] = new SqlParameter("@ServiceCode", SqlDbType.VarChar);
                param[6].Value = info.ServiceCode;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "proIns_BM05_YTTN_Template", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }
        public static Int32 InsBC_BM05(BM05_YTTNInf info, ref decimal result)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@Result", SqlDbType.Decimal);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[1].Value = info.RowID;
                param[2] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar);
                param[2].Value = info.EmployeeCode;
                param[3] = new SqlParameter("@WorkDate", SqlDbType.DateTime);
                param[3].Value = info.WorkDate;
                param[4] = new SqlParameter("@FromDate", SqlDbType.Date);
                param[4].Value = info.FromDate;
                param[5] = new SqlParameter("@ToDate", SqlDbType.Date);
                param[5].Value = info.ToDate;
                result = Convert.ToDecimal(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proIns_BM05_YTTN", param));
                if (result >= 1)
                    return 1;
                else
                    return -1;
            }
            catch { return -2; }
        }
        public static Int32 InsBC_BM05Detail(BM05_YTTNDetailInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RowID_BM05", SqlDbType.Decimal);
                param[0].Value = info.RowID_BM05;
                param[1] = new SqlParameter("@RowIDTemplate", SqlDbType.Int);
                param[1].Value = info.RowIDTemplate;
                param[2] = new SqlParameter("@TargetName", SqlDbType.NVarChar);
                param[2].Value = info.TargetName;
                param[3] = new SqlParameter("@Result", SqlDbType.NVarChar);
                param[3].Value = info.Result;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "proIns_BM05_YTTNDetail", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }
        public static Int32 DelBM05(int rowIDTemplate)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RowIDTemplate", SqlDbType.Int);
                param[1].Value = rowIDTemplate;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "proDel_BM05YTTN_Template", param);
            }
            catch { return -1; }
        }
        #endregion

        public static DataTable TableBM_6_YTTN(DateTime tungay, DateTime denngay)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@frDate", SqlDbType.DateTime);
                param[0].Value = tungay;
                param[1] = new SqlParameter("@Todate", SqlDbType.DateTime);
                param[1].Value = denngay;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proView_BM_6_YTTN", param);
            }
            catch (Exception)
            { return null; }
        }
        public static DataTable SoKhamThai(string dateFrom, string dateTo)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FromDate", SqlDbType.Char, 10);
                param[0].Value = dateFrom;
                param[1] = new SqlParameter("@ToDate", SqlDbType.Char, 10);
                param[1].Value = dateTo;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, "proView_ListMedicalRecord_ANC", param);
                return tableResult;
            }
            catch { return null; }
        }
        public static DataTable SoDe(string dateFrom, string dateTo)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FromDate", SqlDbType.Char, 10);
                param[0].Value = dateFrom;
                param[1] = new SqlParameter("@ToDate", SqlDbType.Char, 10);
                param[1].Value = dateTo;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, "proView_ListMedicalRecord_Childbirth", param);
                return tableResult;
            }
            catch { return null; }
        }
        public static DataTable SoPhaThai(string dateFrom, string dateTo)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FromDate", SqlDbType.Char, 10);
                param[0].Value = dateFrom;
                param[1] = new SqlParameter("@ToDate", SqlDbType.Char, 10);
                param[1].Value = dateTo;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, "proView_ListMedicalRecord_Abortions", param);
                return tableResult;
            }
            catch { return null; }
        }
    }
}
