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
    public class TemplateDescriptionDal
    {
        public static TemplateDescriptionInf ObjTemplate(string code)
        {
            ConnectDB cn = new ConnectDB();
            TemplateDescriptionInf template = new TemplateDescriptionInf();
            try
            {
                string query = "select TemplateHeaderCode,TemplateHeaderName,Apply,Contents,Conclusion,Proposal,EmployeeCode,ServiceCode,EmployeeDoctorCode,ServiceMenuID,PrintPaper from TemplateDescription where TemplateHeaderCode ='{0}' ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(query, code), null);
                if (ireader.Read())
                {
                    template.TemplateHeaderCode = ireader.GetString(0);
                    template.TemplateHeaderName = ireader.GetString(1);
                    template.Apply = ireader.GetInt32(2);
                    template.Contents = ireader.GetValue(3).ToString();
                    template.Conclusion = ireader.GetValue(4).ToString();
                    template.Proposal = ireader.GetValue(5).ToString();
                    template.EmployeeCode = ireader.GetValue(6).ToString();
                    template.ServiceCode = ireader.GetValue(7).ToString();
                    template.EmployeeDoctorCode = ireader.GetValue(8).ToString();
                    template.ServiceMenuID = ireader.GetInt32(9);
                    template.PrintPaper = ireader.GetValue(10).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { template = null; }
            return template;
        }

        public static DataTable DT_ListTemplate(string headerCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Empty;
                if (!string.IsNullOrEmpty(headerCode))
                {
                    sql = @" select a.TemplateHeaderCode,a.TemplateHeaderName,a.Apply,a.Contents,a.Conclusion,a.Proposal,a.EmployeeCode,(case when a.apply='0' then N'Nữ' when a.apply='1' then N'Nam' else N'Chung' end) ApplyName,a.ServiceCode,a.EmployeeDoctorCode,b.ServiceMenuName,a.PrintPaper
                    from TemplateDescription a left join ServiceMenu b on a.ServiceMenuID=b.ServiceMenuID where a.TemplateHeaderCode ='{0}' order by a.TemplateHeaderName asc ";
                }
                else
                {
                    sql = @" select a.TemplateHeaderCode,a.TemplateHeaderName,a.Apply,a.Contents,a.Conclusion,a.Proposal,a.EmployeeCode,(case when a.apply='0' then N'Nữ' when a.apply='1' then N'Nam' else N'Chung' end) ApplyName,a.ServiceCode,a.EmployeeDoctorCode,b.ServiceMenuName,a.PrintPaper
                    from TemplateDescription a left join ServiceMenu b on a.ServiceMenuID=b.ServiceMenuID  order by a.TemplateHeaderName asc ";
                }
                dt = cn.ExecuteQuery(string.Format(sql, headerCode));
            }
            catch { }
            return dt;
        }
        public static DataTable DT_ListTemplateForMenuID(int serviceMenuID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = @" select a.TemplateHeaderCode,a.TemplateHeaderName,a.Apply,a.Contents,a.Conclusion,a.Proposal,a.EmployeeCode,(case when a.apply='0' then N'Nữ' when a.apply='1' then N'Nam' else N'Chung' end) ApplyName,a.ServiceCode,a.EmployeeDoctorCode,b.ServiceMenuName,a.PrintPaper
                    from TemplateDescription a inner join ServiceMenu b on a.ServiceMenuID=b.ServiceMenuID where a.ServiceMenuID={0} order by a.TemplateHeaderName asc ";
                dt = cn.ExecuteQuery(string.Format(sql, serviceMenuID));
            }
            catch { }
            return dt;
        }
        public static DataTable TableListTemplateForService(string serviceCode, string employeeDoctorCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = "select TemplateHeaderCode,TemplateHeaderName,(case when apply='0' then N'Nữ' when apply='1' then N'Nam' else N'Chung' end) ApplyName,Contents,Conclusion,Proposal,EmployeeDoctorCode from TemplateDescription where ServiceCode ='{0}' ";
                if (!string.IsNullOrEmpty(employeeDoctorCode))
                    sql += " and EmployeeDoctorCode ='{1}' ";
                dt = cn.ExecuteQuery(string.Format(sql, serviceCode, employeeDoctorCode));
            }
            catch { dt = null; }
            return dt;
        }

        public static Int32 Ins(TemplateDescriptionInf info, ref string resultCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[12];
                param[0] = new SqlParameter("@TemplateHeaderCode", SqlDbType.VarChar, 50);
                param[0].Value = info.TemplateHeaderCode;
                param[1] = new SqlParameter("@TemplateHeaderName", SqlDbType.NVarChar);
                param[1].Value = info.TemplateHeaderName;
                param[2] = new SqlParameter("@Apply", SqlDbType.NVarChar);
                param[2].Value = info.Apply;
                param[3] = new SqlParameter("@Contents", SqlDbType.NVarChar);
                param[3].Value = info.Contents;
                param[4] = new SqlParameter("@Conclusion", SqlDbType.NVarChar);
                param[4].Value = info.Conclusion;
                param[5] = new SqlParameter("@Proposal", SqlDbType.NVarChar);
                param[5].Value = info.Proposal;
                param[6] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar);
                param[6].Value = info.EmployeeCode;
                param[7] = new SqlParameter("@ServiceCode", SqlDbType.VarChar);
                param[7].Value = info.ServiceCode;
                param[8] = new SqlParameter("@EmployeeDoctorCode", SqlDbType.VarChar);
                param[8].Value = info.EmployeeDoctorCode;
                param[9] = new SqlParameter("@PrintPaper", SqlDbType.VarChar);
                param[9].Value = info.PrintPaper;
                param[10] = new SqlParameter("@ServiceMenuID", SqlDbType.Int);
                param[10].Value = info.ServiceMenuID;
                param[11] = new SqlParameter("@ResultCode", SqlDbType.VarChar, 50);
                param[11].Direction = ParameterDirection.Output;
                //int result = cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_TemplateDescription", param);
                resultCode = cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_TemplateDescription", param);
                if (!string.IsNullOrEmpty(resultCode))
                    return 1;
                else
                    return -1;
            }
            catch (Exception){ return -2; }
        }

        public static Int32 Del(string sCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@TemplateHeaderCode", SqlDbType.VarChar,50);
                param[1].Value = sCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_TemplateDescription", param);
            }
            catch { return -1; }
        }
    }
}
