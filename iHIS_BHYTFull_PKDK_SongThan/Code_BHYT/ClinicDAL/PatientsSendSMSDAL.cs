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

    public class PatientsSendSMSDAL
    {
        public static Int32 InsSendSMS(PatientsSendSMSInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@IDTarget", SqlDbType.VarChar, 25);
                param[0].Value = info.IDTarget;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 15);
                param[1].Value = info.PatientCode;
                param[2] = new SqlParameter("@AppointmentDate", SqlDbType.Char, 10);
                param[2].Value = info.AppointmentDate;
                param[3] = new SqlParameter("@Mobile", SqlDbType.VarChar, 50);
                param[3].Value = info.Mobile;
                param[4] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
                param[4].Value = info.Result;
                param[5] = new SqlParameter("@Content", SqlDbType.NVarChar);
                param[5].Value = info.Content;
                param[6] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 15);
                param[6].Value = info.EmployeeCode;
                param[7] = new SqlParameter("@WorkDate", SqlDbType.Date);
                param[7].Value = info.WorkDate;
                param[8] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[8].Value = info.PatientReceiveID;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "proIns_PatientsSendSMS", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static DataTable TableGetPatientSendSMS(string fromDate, string toDate)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string query = "proView_PatientsSendSMS";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FrmDate", SqlDbType.Char, 10);
                param[0].Value = fromDate;
                param[1] = new SqlParameter("@ToDate", SqlDbType.Char, 10);
                param[1].Value = toDate;
                dt = cn.CallProcedureTable(CommandType.StoredProcedure, query, param);
            }
            catch { dt = null; }
            return dt;
        }

    }

}
