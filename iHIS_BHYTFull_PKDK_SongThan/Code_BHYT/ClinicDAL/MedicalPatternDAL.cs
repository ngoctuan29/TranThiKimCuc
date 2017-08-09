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
    public class MedicalPatternDAL
    {
        public DataTable TablePattern(int rowid)
        {
            DataTable dtbResult = new DataTable();
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = string.Empty;
                dtbResult.Columns.Add(new DataColumn("RowID", typeof(int)));
                dtbResult.Columns.Add(new DataColumn("Title", typeof(string)));
                dtbResult.Columns.Add(new DataColumn("Content", typeof(string)));
                dtbResult.Columns.Add(new DataColumn("ServiceCode", typeof(string)));
                dtbResult.Columns.Add(new DataColumn("EmployeeCode", typeof(string)));
                dtbResult.Columns.Add(new DataColumn("ServiceName", typeof(string)));
                if (rowid != 0)
                {
                    sql = "select a.RowID,a.Title,a.Content,a.ServiceCode,a.EmployeeCode,b.ServiceName from MedicalPattern a inner join [Service] b on a.ServiceCode=b.ServiceCode where a.RowID in({0})";
                }
                else
                {
                    sql = "select a.RowID,a.Title,a.Content,a.ServiceCode,a.EmployeeCode,b.ServiceName from MedicalPattern a inner join [Service] b on a.ServiceCode=b.ServiceCode order by a.RowID asc";
                }
                dtbResult = cn.ExecuteQuery(string.Format(sql, rowid));
                
            }
            catch { dtbResult = null; }
            return dtbResult;
        }

        public MedicalPatternInf ObjPattern(int rowid)
        {
            MedicalPatternInf model = new MedicalPatternInf();
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "select RowID,Title,Content,ServiceCode,EmployeeCode from MedicalPattern where RowID in({0})";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, rowid), null);
                if (ireader.Read())
                {
                    model.RowID = ireader.GetInt32(0);
                    model.Title = ireader.GetValue(1).ToString();
                    model.Content = ireader.GetValue(2).ToString();
                    model.ServiceCode = ireader.GetValue(3).ToString();
                    model.EmployeeCode = ireader.GetValue(4).ToString();
                }
            }
            catch {  }
            return model;
        }

        public List<MedicalPatternInf> ListPattern(string serviceCode)
        {
            List<MedicalPatternInf> lstResult = new List<MedicalPatternInf>();
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "select RowID,Title,Content,ServiceCode,EmployeeCode from MedicalPattern where ServiceCode in('{0}') order by RowID asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, serviceCode), null);
                while (ireader.Read())
                {
                    MedicalPatternInf model = new MedicalPatternInf();
                    model.RowID = ireader.GetInt32(0);
                    model.Title = ireader.GetValue(1).ToString();
                    model.Content = ireader.GetValue(2).ToString();
                    model.ServiceCode = ireader.GetValue(3).ToString();
                    model.EmployeeCode = ireader.GetValue(4).ToString();
                    lstResult.Add(model);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { }
            return lstResult;
        }

        public Int32 InsPattern(MedicalPatternInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@RowID", SqlDbType.VarChar);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@Title", SqlDbType.NVarChar, 200);
                param[1].Value = info.Title;
                param[2] = new SqlParameter("@Content", SqlDbType.NVarChar);
                param[2].Value = info.Content;
                param[3] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[3].Value = info.ServiceCode;
                param[4] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[4].Value = info.EmployeeCode;
                param[5] = new SqlParameter("@Result", SqlDbType.Int);
                param[5].Direction = ParameterDirection.Output;

                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "proInsMedicalPattern", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public Int32 DelPattern(int rowid, string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Result", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[1].Value = employeeCode;
                param[2] = new SqlParameter("@RowID", SqlDbType.Int);
                param[2].Value = rowid;
                return Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proDelMedicalPattern", param));
            }
            catch { return -1; }
        }

    }
}
