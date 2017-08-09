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
    public class LaboratoryDAL
    {
        public static List<LaboratoryInf> ListLaboratory(Int32 iRowID)
        {
            ConnectDB cn = new ConnectDB();
            List<LaboratoryInf> list = new List<LaboratoryInf>();
            try
            {
                string sql = string.Empty;
                if (iRowID != 0)
                {
                    sql = "select RowID,LaboratoryName from Laboratory where rowid in({0}) ";
                }
                else
                {
                    sql = "select RowID,LaboratoryName from Laboratory order by rowid asc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iRowID), null);
                while (ireader.Read())
                {
                    LaboratoryInf inf = new LaboratoryInf();
                    inf.RowID = ireader.GetInt32(0);
                    inf.LaboratoryName = ireader.GetValue(1).ToString();
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { list = null; }
            return list;
        }

        public static DataTable DT_Laboratory(int iRowID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(Int32)));
                dt.Columns.Add(new DataColumn("LaboratoryName", typeof(string)));
                string sql = string.Empty;
                if (iRowID != 0)
                {
                    sql = "select RowID,LaboratoryName from Laboratory where rowid in({0}) ";
                }
                else
                {
                    sql = "select RowID,LaboratoryName from Laboratory order by rowid asc";
                }
                dt = cn.ExecuteQuery(string.Format(sql, iRowID));
                //IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, iRowID), null);
                //while (ireader.Read())
                //{
                //    dt.Rows.Add(ireader.GetInt32(0), ireader.GetValue(1).ToString());
                //}
                //if (!ireader.IsClosed)
                //{
                //    ireader.Close();
                //    ireader.Dispose();
                //}
            }
            catch { dt = null; }
            return dt;
        }

        public static Int32 Ins(LaboratoryInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@RowID", SqlDbType.Int);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@LaboratoryName", SqlDbType.NVarChar, 250);
                param[1].Value = info.LaboratoryName;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_Laboratory", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 Del(Int32 iRowid)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RowID", SqlDbType.Int);
                param[1].Value = iRowid;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_Laboratory", param);
            }
            catch { return -1; }
        }

        public static DataTable DataLaboratoryForPatient(decimal patientReceiveId, string patientCode, int status, string stt, string startDate, string toDate, string departmentCodeOrder)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@PatientReceiveId", SqlDbType.Decimal);
                param[0].Value = patientReceiveId;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar);
                param[1].Value = patientCode;
                param[2] = new SqlParameter("@Status", SqlDbType.Int);
                param[2].Value = status;
                param[3] = new SqlParameter("@STT", SqlDbType.VarChar, 10);
                param[3].Value = stt;
                //param[4] = new SqlParameter("@PostingDate", SqlDbType.Char, 10);
                //param[4].Value = postingDate;
                param[4] = new SqlParameter("@StartDate", SqlDbType.Char, 10);
                param[4].Value = startDate;
                param[5] = new SqlParameter("@ToDate", SqlDbType.Char, 10);
                param[5].Value = toDate;
                param[6] = new SqlParameter("@DepartmentCodeOrder", SqlDbType.VarChar, 15);
                param[6].Value = departmentCodeOrder;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proLaboratoryForPatient", param);
            }
            catch { return null; }
        }

        public static DataTable DataLaboratoryForPatientAppointment(decimal patientReceiveId, string patientCode, int status, int transfer, string serviceModuleCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@PatientReceiveId", SqlDbType.Decimal);
                param[0].Value = patientReceiveId;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar);
                param[1].Value = patientCode;
                param[2] = new SqlParameter("@ServiceModuleCode", SqlDbType.VarChar, 15);
                param[2].Value = serviceModuleCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proLabForPatientAppointment", param);
            }
            catch { return null; }
        }
    }
}
