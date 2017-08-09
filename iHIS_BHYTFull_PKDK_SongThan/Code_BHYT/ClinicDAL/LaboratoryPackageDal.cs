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
    public class LaboratoryPackageDal
    {
        public static DataTable TableLabPackage(string packageCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = "select a.LaboratoryPackageCode,a.LaboratoryPackageName,a.EmployeeCode,a.ServiceCode,svc.ServiceCategoryName,a.TypeResult,a.TemplateHeaderCode from LaboratoryPackage a left join service sv  on a.ServiceCode=sv.ServiceCode left join ServiceCategory svc on sv.ServiceCategoryCode=svc.ServiceCategoryCode left join ServiceGroup svg on svc.ServiceGroupCode=svg.ServiceGroupCode where a.LaboratoryPackageCode ='{0}' ";
                dt = cn.ExecuteQuery(string.Format(sql, packageCode));
            }
            catch { dt = null; }
            return dt;
        }
        public static DataTable TableLabPackageForServiceCode(string serviceCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = "select a.LaboratoryPackageCode,a.LaboratoryPackageName,a.EmployeeCode,a.ServiceCode,svc.ServiceCategoryName,a.TypeResult,a.TemplateHeaderCode from LaboratoryPackage a inner join service sv  on a.ServiceCode=sv.ServiceCode inner join ServiceCategory svc on sv.ServiceCategoryCode=svc.ServiceCategoryCode inner join ServiceGroup svg on svc.ServiceGroupCode=svg.ServiceGroupCode where a.ServiceCode ='{0}' ";
                dt = cn.ExecuteQuery(string.Format(sql, serviceCode));
            }
            catch { dt = null; }
            return dt;
        }
        public static DataTable TableLabPackageForModule( string serviceModuleCode, int typeresult)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = "select a.LaboratoryPackageCode,a.LaboratoryPackageName,a.EmployeeCode,a.ServiceCode,svc.ServiceCategoryName,a.TypeResult,a.TemplateHeaderCode from LaboratoryPackage a left join service sv  on a.ServiceCode=sv.ServiceCode left join ServiceCategory svc on sv.ServiceCategoryCode=svc.ServiceCategoryCode left join ServiceGroup svg on svc.ServiceGroupCode=svg.ServiceGroupCode where svg.ServiceModuleCode ='{0}' ";
                if (typeresult > 0)
                    sql += "  and a.TypeResult={1} ";
                dt = cn.ExecuteQuery(string.Format(sql, serviceModuleCode, typeresult));
            }
            catch { dt = null; }
            return dt;
        }
        public static DataTable TableLabPackageDetail(String sCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(Int32)));
                dt.Columns.Add(new DataColumn("LaboratoryPackageCode", typeof(string)));
                dt.Columns.Add(new DataColumn("LaboratoryName", typeof(string)));
                dt.Columns.Add(new DataColumn("UnitValues", typeof(string)));
                dt.Columns.Add(new DataColumn("ValuedFemale", typeof(string)));
                dt.Columns.Add(new DataColumn("ValuedMale", typeof(string)));
                dt.Columns.Add(new DataColumn("MinValuedFemale", typeof(string)));
                dt.Columns.Add(new DataColumn("MaxValuedFemale", typeof(string)));
                dt.Columns.Add(new DataColumn("MinValuedMale", typeof(string)));
                dt.Columns.Add(new DataColumn("MaxValuedMale", typeof(string)));
                dt.Columns.Add(new DataColumn("STT", typeof(Int32)));
                dt.Columns.Add(new DataColumn("ParameterMachine", typeof(string)));
                dt.Columns.Add(new DataColumn("ValuesEntry", typeof(string)));
                string sql = "select RowID,LaboratoryPackageCode,LaboratoryName,UnitValues,ValuedFemale,ValuedMale,MinValuedFemale,MaxValuedFemale,MinValuedMale,MaxValuedMale,STT,ParameterMachine,ValuesEntry from LaboratoryPackageDetail where LaboratoryPackageCode ='{0}'  order by STT";
                dt = cn.ExecuteQuery(string.Format(sql, sCode));
            }
            catch { dt = null; }
            return dt;
        }
        public static List<LaboratoryPackageDetailInf> List_LabPackageDetail(String sCode)
        {
            ConnectDB cn = new ConnectDB();
            List<LaboratoryPackageDetailInf> lst = new List<LaboratoryPackageDetailInf>();
            try
            {
                string sql = string.Empty;
                sql = "select RowID,LaboratoryPackageCode,LaboratoryName,UnitValues,ValuedFemale,ValuedMale,MinValuedFemale,MaxValuedFemale,MinValuedMale,MaxValuedMale,STT,ParameterMachine,ValuesEntry from LaboratoryPackageDetail where LaboratoryPackageCode in('{0}') order by STT ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sCode), null);
                while (ireader.Read())
                {
                    LaboratoryPackageDetailInf inf = new LaboratoryPackageDetailInf();
                    inf.RowID = ireader.GetInt32(0);
                    inf.LaboratoryPackageCode = ireader.GetValue(1).ToString();
                    inf.LaboratoryName = ireader.GetValue(2).ToString();
                    inf.UnitValues = ireader.GetValue(3).ToString();
                    inf.ValuedFemale = ireader.GetValue(4).ToString();
                    inf.ValuedMale = ireader.GetValue(5).ToString();
                    inf.MinValuedFemale = ireader.GetDecimal(6);
                    inf.MaxValuedFemale = ireader.GetDecimal(7);
                    inf.MinValuedMale = ireader.GetDecimal(8);
                    inf.MaxValuedMale = ireader.GetDecimal(9);
                    inf.STT = ireader.GetInt32(10);
                    inf.ParameterMachine = ireader.GetValue(11).ToString();
                    inf.ValuesEntry = ireader.GetValue(12).ToString();
                    lst.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return lst;
            }
            catch {return null; }
        }
        public static Int32 InsPackage(LaboratoryPackageInf info, ref string resultCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@LaboratoryPackageCode", SqlDbType.VarChar, 50);
                param[0].Value = info.LaboratoryPackageCode;
                param[1] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[1].Value = info.EmployeeCode;
                param[2] = new SqlParameter("@ServiceCode", SqlDbType.VarChar);
                param[2].Value = info.ServiceCode;
                param[3] = new SqlParameter("@LaboratoryPackageName", SqlDbType.NVarChar);
                param[3].Value = info.LaboratoryPackageName;
                param[4] = new SqlParameter("@TypeResult", SqlDbType.Int);
                param[4].Value = info.TypeResult;
                param[5] = new SqlParameter("@TemplateHeaderCode", SqlDbType.NVarChar);
                param[5].Value = info.TemplateHeaderCode;
                param[6] = new SqlParameter("@resultCode", SqlDbType.VarChar, 50);
                param[6].Direction = ParameterDirection.Output;
                resultCode = cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_LaboratoryPackage", param);
                if (!string.IsNullOrEmpty(resultCode))
                    return 1;
                else
                    return -1;
            }
            catch(Exception) { return -2; }
        }
        public static Int32 InsPackageDetail(LaboratoryPackageDetailInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[13];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@LaboratoryPackageCode", SqlDbType.VarChar, 50);
                param[1].Value = info.LaboratoryPackageCode;
                param[2] = new SqlParameter("@LaboratoryName", SqlDbType.NVarChar);
                param[2].Value = info.LaboratoryName;
                param[3] = new SqlParameter("@UnitValues", SqlDbType.NVarChar);
                param[3].Value = info.UnitValues;
                param[4] = new SqlParameter("@ValuedFemale", SqlDbType.NVarChar);
                param[4].Value = info.ValuedFemale;
                param[5] = new SqlParameter("@ValuedMale", SqlDbType.NVarChar);
                param[5].Value = info.ValuedMale;
                param[6] = new SqlParameter("@MinValuedFemale", SqlDbType.Decimal);
                param[6].Value = info.MinValuedFemale;
                param[7] = new SqlParameter("@MaxValuedFemale", SqlDbType.Decimal);
                param[7].Value = info.MaxValuedFemale;
                param[8] = new SqlParameter("@MinValuedMale", SqlDbType.Decimal);
                param[8].Value = info.MinValuedMale;
                param[9] = new SqlParameter("@MaxValuedMale", SqlDbType.Decimal);
                param[9].Value = info.MaxValuedMale;
                param[10] = new SqlParameter("@STT", SqlDbType.Int);
                param[10].Value = info.STT;
                param[11] = new SqlParameter("@ParameterMachine", SqlDbType.NVarChar);
                param[11].Value = info.ParameterMachine;
                param[12] = new SqlParameter("@ValuesEntry", SqlDbType.NVarChar, 50);
                param[12].Value = info.ValuesEntry;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_LaboratoryPackageDetail", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }
        public static Int32 Del(string packageCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@LaboratoryPackageCode", SqlDbType.VarChar, 50);
                param[1].Value = packageCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_LaboratoryPackage", param);
            }
            catch (Exception){ return -1; }
        }
        public static Int32 DelDetail(int iRowID, string packageCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RowID", SqlDbType.Int);
                param[1].Value = iRowID;
                param[2] = new SqlParameter("@LaboratoryPackageCode", SqlDbType.VarChar);
                param[2].Value = packageCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_LaboratoryPackageDetail", param);
            }
            catch { return -1; }
        }
        public static Int32 UpdPackageTemplateHeader(string serviceCode, string templateHeaderCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "update LaboratoryPackage set TemplateHeaderCode=@TemplateHeaderCode where ServiceCode=@ServiceCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ServiceCode", SqlDbType.VarChar);
                param[0].Value = serviceCode;
                param[1] = new SqlParameter("@TemplateHeaderCode", SqlDbType.NVarChar);
                param[1].Value = templateHeaderCode;
                return cn.ExecuteNonQuery(CommandType.Text, query, param);
            }
            catch { return -1; }
        }
    }
}
