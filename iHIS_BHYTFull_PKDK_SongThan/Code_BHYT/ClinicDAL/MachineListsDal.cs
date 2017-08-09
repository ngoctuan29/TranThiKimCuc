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
    public class MachineListsDal
    {
        public static DataTable TableMachineLists()
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtbResult = new DataTable();
            try
            {
                dtbResult.Columns.Add(new DataColumn("RowID", typeof(int)));
                dtbResult.Columns.Add(new DataColumn("MechineCode", typeof(string)));
                dtbResult.Columns.Add(new DataColumn("MechineName", typeof(string)));
                dtbResult.Columns.Add(new DataColumn("ServiceCategoryCode", typeof(string)));
                dtbResult.Columns.Add(new DataColumn("Hide", typeof(int)));
                dtbResult = cn.ExecuteQuery("select RowID,MechineCode,MechineName,ServiceCategoryCode,Hide from MachineLists order by RowID ");
            }
            catch { dtbResult = null; }
            return dtbResult;
        }
       
        public static DataTable TableMachineLists(int hide)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt = cn.ExecuteQuery(string.Format("select RowID,MechineCode,MechineName,ServiceCategoryCode from MachineLists where Hide={0} order by RowID ", hide));
            }
            catch { dt = null; }
            return dt;
        }

        public static DataTable TableMachineListsForGroup(string categoryCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt = cn.ExecuteQuery(string.Format("select a.RowID,a.MechineCode,a.MechineName,a.ServiceCategoryCode from MachineLists a inner join ServiceCategory b on a.ServiceCategoryCode=b.ServiceCategoryCode where a.Hide =0 and a.ServiceCategoryCode='{0}' order by a.RowID ", categoryCode));
            }
            catch { dt = null; }
            return dt;
        }

        public static Int32 InsMachineLists(MachineLists info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@MechineCode", SqlDbType.VarChar, 5);
                param[1].Value = info.MechineCode;
                param[2] = new SqlParameter("@MechineName", SqlDbType.NVarChar, 250);
                param[2].Value = info.MechineName;
                param[3] = new SqlParameter("@ServiceCategoryCode", SqlDbType.NVarChar, 50);
                param[3].Value = info.ServiceCategoryCode;
                param[4] = new SqlParameter("@Hide", SqlDbType.Int);
                param[4].Value = info.Hide;
                param[5] = new SqlParameter("@Result", SqlDbType.Int);
                param[5].Direction = ParameterDirection.Output;
                int iresult = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proIU_MachineLists", param));
                return iresult;
            }
            catch { return -2; }
        }

        public static bool IsDeleteMachineLists(int rowID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " delete from MachineLists where RowID=@RowID ";
                SqlParameter[] sqlParameter = new SqlParameter[1];
                sqlParameter[0] = new SqlParameter("@RowID", SqlDbType.Int);
                sqlParameter[0].Value = rowID;
                if (cn.ExecuteNonQuery(CommandType.Text, sql, sqlParameter) >= 1)
                {
                    return true;
                }
                else
                    return false;
            }
            catch { return false; }
        }
    }
}
