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
    public class Ven_AnalistDAL
    {
        public static DataTable DataVen()
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "select VENCode,VENName from Catalog_VEN ";
                return cn.ExecuteQuery(query);
            }
            catch { return null; }
        }

        #region Tuan code Phan tich ABC
        public static DataTable GetDMPhieu()
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "SP_LayComboDMPhieu";
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, query, null);
            }
            catch { tableResult = null; }
            return tableResult;
        }
        public static DataTable GetThongKeABCVEN2Time(string venCode1, string venCode2)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "sp_ThongKeABCVEN_2Time";
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@VENCode1", SqlDbType.VarChar,  15);
                param[0].Value = venCode1;
                param[1] = new SqlParameter("@VENCode2", SqlDbType.VarChar, 15);
                param[1].Value = venCode2;
                param[2] = new SqlParameter("@VEN", SqlDbType.VarChar);
                param[2].Value = "VEN";
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, query, param);
            }
            catch{ tableResult = null; }
            return tableResult;
        }
        public static DataTable GetThongKeABC(string ven, string venCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "sp_ThongKeABCVEN";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@VEN", SqlDbType.Char, 5);
                param[0].Value = ven;
                param[1] = new SqlParameter("@VENCode", SqlDbType.VarChar, 15);
                param[1].Value = venCode;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, query, param);
            }
            catch { tableResult = null; }
            return tableResult;
        }
        public static DataTable GetThongKeABCTheoATC(string venCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "sp_ThongKeABCTheoATC_NotABC";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@VENABC_Code", SqlDbType.VarChar, 15);
                param[0].Value = venCode;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, query, param);
            }
            catch { tableResult = null; }
            return tableResult;
        }
        public static DataTable GetDMPhieuForID(int IdVEN)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "select ID,VENABC_Code,FromDate,ToDate from VENABC where ID =@ID ";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ID", SqlDbType.Int);
                param[0].Value = IdVEN;
                tableResult = cn.CallProcedureTable(CommandType.Text, query, param);
            }
            catch { tableResult = null; }
            return tableResult;
        }
        public static DataTable GetThongKeABCTheoATC_TyLe(string venCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "sp_ThongKeABCTheoATC_TyLe ";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@IdPhieu", SqlDbType.VarChar, 15);
                param[0].Value = venCode;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, query, param);
            }
            catch { tableResult = null; }
            return tableResult;
        }
        public static DataTable GetThongKeABCVENTheoThuocNoiNgoai(string venCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "sp_ThongKeABCVENTheoThuocNoiNgoai";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@VENABC_Code", SqlDbType.VarChar, 15);
                param[0].Value = venCode;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, query, param);
            }
            catch(Exception) { tableResult = null; }
            return tableResult;
        }
        #endregion

        public static DataTable GetChiSoHieuQua(string venCode1, string venCode2)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "sp_ThongKeABCVEN_2Time_ThayDoiBac";
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@VENABC_Code1", SqlDbType.VarChar, 15);
                param[0].Value = venCode1;
                param[1] = new SqlParameter("@VENABC_Code2", SqlDbType.VarChar, 15);
                param[1].Value = venCode2;
                param[2] = new SqlParameter("@VEN", SqlDbType.VarChar);
                param[2].Value = "VEN";
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, query, param);
            }
            catch { tableResult = null; }
            return tableResult;
        }
        public static DataTable ThongKeABCVENTheoThoiGian(string venCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "sp_ThongKeABCVENTheoThoiGian_NotABC";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@VENABC_Code", SqlDbType.VarChar, 15);
                param[0].Value = venCode;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, query, param);
            }
            catch { tableResult = null; }
            return tableResult;
        }

        public static DataTable GetABCVENTheoThoiGian2Time(string venCode1, string venCode2)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "sp_ThongKeABCVENTheoThoiGian_NotABC_2Time";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@VENABC_Code1", SqlDbType.VarChar, 15);
                param[0].Value = venCode1;
                param[1] = new SqlParameter("@VENABC_Code2", SqlDbType.VarChar, 15);
                param[1].Value = venCode2;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, query, param);
            }
            catch { tableResult = null; }
            return tableResult;
        }

        public static DataTable GetViewInventory(string venCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "proVen_ViewInventory";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@VENABC_Code", SqlDbType.VarChar, 15);
                param[0].Value = venCode;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, query, param);
            }
            catch{ tableResult = null; }
            return tableResult;
        }

        public static String Ins_VENABC_Analist(string venCode, string fromDate, string toDate, string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "proIU_VENABC_Analist";
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@VENABC_Code", SqlDbType.VarChar, 15);
                param[0].Value = venCode;
                param[1] = new SqlParameter("@FromDate", SqlDbType.Date);
                param[1].Value = Convert.ToDateTime(fromDate);
                param[2] = new SqlParameter("@ToDate", SqlDbType.Date);
                param[2].Value = Convert.ToDateTime(toDate);
                param[3] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 15);
                param[3].Value = employeeCode;
                param[4] = new SqlParameter("@ResultVENABC_Code", SqlDbType.VarChar, 15);
                param[4].Direction = ParameterDirection.Output;
                return cn.ExecuteReaderProcedure(CommandType.StoredProcedure, query, param).ToString();
            }
            catch
            { return string.Empty; }
        }

        public static int Ins_VENABC_AnalistDetail(string venABC_Code, string itemName, string unitOfMeasureName,string active, string bietDuoc, string generic, string venCode, string countryName, string atcCode, decimal quantity, decimal unitPriceVAT)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "proIU_VENABC_AnalistDetail";
                SqlParameter[] param = new SqlParameter[11];
                param[0] = new SqlParameter("@VENABC_Code", SqlDbType.VarChar, 15);
                param[0].Value = venABC_Code;
                param[1] = new SqlParameter("@ItemName", SqlDbType.NVarChar, 500);
                param[1].Value = itemName;
                param[2] = new SqlParameter("@UnitOfMeasureName", SqlDbType.NVarChar, 100);
                param[2].Value =unitOfMeasureName;
                param[3] = new SqlParameter("@Active", SqlDbType.NVarChar, 250);
                param[3].Value = active;
                param[4] = new SqlParameter("@BietDuoc", SqlDbType.Char, 1);
                param[4].Value = bietDuoc;
                param[5] = new SqlParameter("@Generic", SqlDbType.Char, 1);
                param[5].Value = generic;
                param[6] = new SqlParameter("@VENCode", SqlDbType.NVarChar, 100);
                param[6].Value = venCode;
                param[7] = new SqlParameter("@CountryName", SqlDbType.NVarChar, 250);
                param[7].Value = countryName;
                param[8] = new SqlParameter("@ATCCode", SqlDbType.NVarChar, 250);
                param[8].Value = atcCode;
                param[9] = new SqlParameter("@Quantity", SqlDbType.Decimal);
                param[9].Value = quantity;
                param[10] = new SqlParameter("@UnitPriceVAT", SqlDbType.Decimal);
                param[10].Value = unitPriceVAT;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, query, param);
            }
            catch
            { return -1; }
        }

        public static int Delete_VENABC_Analist(string venCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = " delete from VENABC_AnalistDetail where VENABC_Code=@VENABC_Code; delete from VENABC_Analist where VENABC_Code=@VENABC_Code";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@VENABC_Code", SqlDbType.VarChar, 15);
                param[0].Value = venCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, query, param);
            }
            catch
            { return -1; }
        }

        public static DataTable GetListVENABC_Analist()
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "select VENABC_Code from VENABC_Analist";
                tableResult = cn.CallProcedureTable(CommandType.Text, query, null);
            }
            catch { tableResult = null; }
            return tableResult;
        }

        public static DataTable GetVENABC_AnalistByVENcode(string venCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "select FromDate, ToDate from VENABC_Analist where VENABC_Code = '" + venCode + "'";
                tableResult = cn.CallProcedureTable(CommandType.Text, query, null);
            }
            catch { tableResult = null; }
            return tableResult;
        }

    }
}
