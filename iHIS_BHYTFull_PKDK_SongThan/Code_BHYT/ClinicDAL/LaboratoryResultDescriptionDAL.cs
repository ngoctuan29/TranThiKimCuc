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
    public class LaboratoryResultDescriptionDAL
    {
        public static DataTable DT_LabResultDescription()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(Int32)));
                dt.Columns.Add(new DataColumn("DescriptionResult", typeof(string)));
                string sql = "select RowID,DescriptionResult from LaboratoryResultDescription order by RowID ";
                dt = cn.ExecuteQuery(sql);
            }
            catch { dt = null; }
            return dt;
        }

        public static Int32 InsResultDescription(LaboratoryResultDescriptionInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " insert into LaboratoryResultDescription(DescriptionResult) values(@DescriptionResult) ";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@DescriptionResult", SqlDbType.NVarChar, 50);
                param[0].Value = info.DescriptionResult;
                if (cn.ExecuteNonQuery(CommandType.Text, sql, param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 UpdResultDescription(LaboratoryResultDescriptionInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " update LaboratoryResultDescription set DescriptionResult=@DescriptionResult where RowID=@RowID ";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@DescriptionResult", SqlDbType.NVarChar, 50);
                param[0].Value = info.DescriptionResult;
                param[1] = new SqlParameter("@RowID", SqlDbType.Int);
                param[1].Value = info.DescriptionResult;
                if (cn.ExecuteNonQuery(CommandType.Text, sql, param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 DelResultDescription(Int32 iRowID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " Delete from LaboratoryResultDescription where RowID=@RowID ";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = iRowID;
                if (cn.ExecuteNonQuery(CommandType.Text, sql, param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static DataTable TableCategoryForMachine(string serviceCategoryCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string sql = "select ServiceCategoryCode,MachineCode,TypeResult,Contents,Conclusion,Proposal from LaboratoryCategoryForMachine ";
                if (!string.IsNullOrEmpty(serviceCategoryCode))
                    sql += " where ServiceCategoryCode='{0}'";
                sql += " order by ServiceCategoryCode";
                tableResult = cn.ExecuteQuery(string.Format(sql, serviceCategoryCode));
            }
            catch {  }
            return tableResult;
        }

        public static DataTable TableLabTypeResult(string serviceGroupCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = @" select a.ServiceCategoryCode,b.ServiceCategoryName,a.ServiceCode,a.ServiceName 
                    from [Service] a inner join ServiceCategory b on a.ServiceCategoryCode=b.ServiceCategoryCode 
                    where  ServiceCode not in('DV000000') and a.Hide=0 and a.ServiceCode not in(select ServiceCode from LaboratoryTypeResult) and a.ServiceGroupCode='{0}'";
                sql += "  order by a.ServiceCategoryCode ";
                tableResult = cn.ExecuteQuery(string.Format(sql, serviceGroupCode));
            }
            catch { }
            return tableResult;
        }

        public static DataTable TableLabTypeResultTemplate(string serviceGroupCode, int type)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = @" select a.ServiceCode,b.ServiceName,a.TypeResult,b1.ServiceCategoryName,b.ServiceCategoryCode,a1.TemplateHeaderCode
                        from LaboratoryTypeResult a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceCategory b1 on b.ServiceCategoryCode=b1.ServiceCategoryCode left join TemplateDescription a1 on a.ServiceCode=a1.ServiceCode
                    where b.Hide =0 and  b.ServiceGroupCode='{0}'";
                if (type >= 0)
                    sql += " and a.TypeResult in({1})";
                sql += " order by b.ServiceCategoryCode ";
                tableResult = cn.ExecuteQuery(string.Format(sql, serviceGroupCode, type));
            }
            catch { }
            return tableResult;
        }

        public static Int32 IULabTypeResult(string serviceCode, int typeResult, string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[0].Value = serviceCode;
                param[1] = new SqlParameter("@TypeResult", SqlDbType.Int);
                param[1].Value = typeResult;
                param[2] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[2].Value = employeeCode;
                param[3] = new SqlParameter("@Result", SqlDbType.Int);
                param[3].Direction = ParameterDirection.Output;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "proInsUpd_LabTypeResult", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 DelLabTypeResult(string serviceCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " delete from LaboratoryTypeResult where ServiceCode=@ServiceCode ";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[0].Value = serviceCode;
                if (cn.ExecuteNonQuery(CommandType.Text, sql, param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

    }

    public class LabPatternAttachDAL
    {
        public static Int32 DelLabPattern(Int32 labPatternID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " delete from LabPatternAttach where LabPatternID=@LabPatternID ";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@LabPatternID", SqlDbType.Int);
                param[0].Value = labPatternID;
                if (cn.ExecuteNonQuery(CommandType.Text, sql, param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 InsLabPattern(LabPatternAttachInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "proIU_LabPatternAttach";
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@LabPatternID", SqlDbType.Int);
                param[0].Value = info.LabPatternID;
                param[1] = new SqlParameter("@LabPatternTitle", SqlDbType.NVarChar, 250);
                param[1].Value = info.LabPatternTitle;
                param[2] = new SqlParameter("@LabPatternContent", SqlDbType.NVarChar);
                param[2].Value = info.LabPatternContent;
                param[3] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[3].Value = info.EmployeeCode;
                param[4] = new SqlParameter("@ServiceCategoryCode", SqlDbType.VarChar, 50);
                param[4].Value = info.ServiceCategoryCode;
                param[5] = new SqlParameter("@WorkDate", SqlDbType.DateTime);
                param[5].Value = info.WorkDate;
                param[6] = new SqlParameter("@LabPathologicalID", SqlDbType.Int);
                param[6].Value = info.LabPathologicalID;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, query, param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static LabPatternAttachInf ObjLabPattern(string serviceCategoryCode)
        {
            ConnectDB cn = new ConnectDB();
            LabPatternAttachInf obj = new LabPatternAttachInf();
            try
            {
                string query = "select LabPatternID,LabPatternTitle,LabPatternContent,EmployeeCode,ServiceCategoryCode,WorkDate,LabPathologicalID from LabPatternAttach where ServiceCategoryCode='{0}'";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(query, serviceCategoryCode), null);
                if (ireader.Read())
                {
                    obj.LabPatternID = ireader.GetInt32(0);
                    obj.LabPatternTitle = ireader.GetValue(1).ToString();
                    obj.LabPatternContent = ireader.GetValue(2).ToString();
                    obj.EmployeeCode = ireader.GetString(3);
                    obj.ServiceCategoryCode = ireader.GetValue(4).ToString();
                    obj.WorkDate = ireader.GetDateTime(5);
                    obj.LabPathologicalID = ireader.GetInt32(6);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { obj = null; }
            return obj;
        }
    }

    public class LabPathologicalDAL
    {
        public static DataTable TableLabPathological()
        {
            try
            {
                ConnectDB cn = new ConnectDB();
                DataTable tableResult = new DataTable();
                string query = " select LabPathologicalID,LabPathologicalName from LabPathological ";
                tableResult = cn.ExecuteQuery(query);
                return tableResult;
            }
            catch { return null; }
        }
    }

}
