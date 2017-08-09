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
    public class SamplePrescriptionHeader_DAL
    {
        public static List<SamplePrescriptionHeader_INF> ListAll()
        {
            ConnectDB cn = new ConnectDB();
            List<SamplePrescriptionHeader_INF> list = new List<SamplePrescriptionHeader_INF>();
            try
            {
                string sql = "";
                sql = " select SamplePrescriptionCode,SamplePrescriptionName,SamplePrescriptionDescription,EmployeeCode from SamplePrescriptionHeader order by RowID desc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    SamplePrescriptionHeader_INF inf = new SamplePrescriptionHeader_INF();
                    inf.SamplePrescriptionCode = ireader.GetValue(0).ToString();
                    inf.SamplePrescriptionName = ireader.GetValue(1).ToString();
                    inf.SamplePrescriptionDescription = ireader.GetValue(2).ToString();
                    inf.EmployeeCode = ireader.GetString(3);
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch  { list = null; }
            return list;
        }

        public static Int32 Ins(SamplePrescriptionHeader_INF info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@SamplePrescriptionCode", SqlDbType.VarChar, 50);
                param[0].Value = info.SamplePrescriptionCode;
                param[1] = new SqlParameter("@SamplePrescriptionName", SqlDbType.NVarChar, 1000);
                param[1].Value = info.SamplePrescriptionName;
                param[2] = new SqlParameter("@SamplePrescriptionDescription", SqlDbType.NVarChar, 1000);
                param[2].Value = info.SamplePrescriptionDescription;
                param[3] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[3].Value = info.EmployeeCode;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_SampleHeader", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Del(string sSampleCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@SamplePrescriptionCode", SqlDbType.VarChar, 50);
                param[1].Value = sSampleCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_SampleHeader", param);
                //int iResult = cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_SampleHeader", param);
                //return iResult;
            }
            catch { return -1; }
        }

    }
}
