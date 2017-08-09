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
    public class PatientsRelationDal
    {
        public DataTable TableRelation(string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtbResult = new DataTable();
            try
            {
                dtbResult.Columns.Add("RowID", typeof(decimal));
                dtbResult.Columns.Add("PatientCode", typeof(string));
                dtbResult.Columns.Add("PatientReceiveID", typeof(decimal));
                dtbResult.Columns.Add("RelationContent", typeof(string));
                dtbResult.Columns.Add("RowIDMenu", typeof(int));
                dtbResult.Columns.Add("EmployeeCode", typeof(string));
                dtbResult.Columns.Add("Age", typeof(string));
                dtbResult.Columns.Add("CareerName", typeof(string));
                dtbResult.Columns.Add("MedicalHistory", typeof(string));
                string query = " select RowID,PatientCode,PatientReceiveID,RelationContent,RowIDMenu,EmployeeCode,Age,CareerName,MedicalHistory from PatientsRelation where PatientCode in('{0}') order by RowID ";
                dtbResult = cn.ExecuteQuery(string.Format(query, patientCode));
            }
            catch { dtbResult = null; }
            return dtbResult;
        }

        public bool DelPatientsRelation(decimal rowid)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = rowid;
                int result = cn.ExecuteNonQuery(CommandType.StoredProcedure, "proDelPatientsRelation", param);
                if (result >= 1)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        public int InsPatientsRelation(PatientsRelationInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = info.PatientReceiveID;
                param[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[2].Value = info.PatientCode;
                param[3] = new SqlParameter("@RelationContent", SqlDbType.NVarChar, 500);
                param[3].Value = info.RelationContent;
                param[4] = new SqlParameter("@EmployeeCode", SqlDbType.NVarChar, 50);
                param[4].Value = info.EmployeeCode;
                param[5] = new SqlParameter("@RowIDMenu", SqlDbType.Int);
                param[5].Value = info.RowIDMenu;
                param[6] = new SqlParameter("@Age", SqlDbType.VarChar, 3);
                param[6].Value = info.Age;
                param[7] = new SqlParameter("@CareerName", SqlDbType.NVarChar, 100);
                param[7].Value = info.CareerName;
                param[8] = new SqlParameter("@MedicalHistory", SqlDbType.NVarChar, 250);
                param[8].Value = info.MedicalHistory;
                int result = cn.ExecuteNonQuery(CommandType.StoredProcedure, "proInsPatientsRelation", param);
                return result;
            }
            catch { return -1; }
        }
    }
}
