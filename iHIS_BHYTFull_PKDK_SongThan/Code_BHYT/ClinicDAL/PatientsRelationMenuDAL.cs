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
    public class PatientsRelationMenuDAL
    {
        public DataTable TableRelationMenu()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtbResult = new DataTable();
            try
            {
                dtbResult.Columns.Add("RowID", typeof(int));
                dtbResult.Columns.Add("RelationTitle", typeof(string));
                dtbResult.Columns.Add("EmployeeCode", typeof(string));
                string query = " select RowID,RelationTitle,EmployeeCode from PatientsRelationMenu order by RowID ";
                dtbResult = cn.ExecuteQuery(query);
            }
            catch { dtbResult = null; }
            return dtbResult;
        }

        public bool DelPatientsRelationMenu(int rowid)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = rowid;
                param[1] = new SqlParameter("@Result", SqlDbType.Int);
                param[1].Direction = ParameterDirection.Output;
                int result = cn.ExecuteNonQuery(CommandType.StoredProcedure, "proDelPatientsRelationMenu", param);
                if (result >= 1)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        public int InsPatientsRelationMenu(PatientsRelationMenuInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@RelationTitle", SqlDbType.NVarChar, 250);
                param[1].Value = info.RelationTitle;
                param[2] = new SqlParameter("@EmployeeCode", SqlDbType.NVarChar, 50);
                param[2].Value = info.EmployeeCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "proInsPatientsRelationMenu", param);
            }
            catch { return -1; }
        }
    }
}
