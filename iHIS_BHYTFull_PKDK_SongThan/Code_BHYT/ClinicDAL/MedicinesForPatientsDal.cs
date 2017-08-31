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
    public class MedicinesForPatientsDal
    {
        public static List<MedicinesForPatients> MedicinesForPatients(string sMedicinesCode)
        {
            ConnectDB cn = new ConnectDB();
            List<MedicinesForPatients> list = new List<MedicinesForPatients>();
            try
            {
                string sql = "";
                sql = "select MedicalRecordCode,PatientReceiveID,PatientCode,EmployeeCode,MM,YYYY,DateApproved,ObjectCode from MedicinesForPatients where MedicalRecordCode in('{0}') order by MedicalRecordCode asc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sMedicinesCode), null);
                while (ireader.Read())
                {
                    MedicinesForPatients inf = new MedicinesForPatients();
                    inf.MedicalRecordCode = ireader.GetString(0);
                    inf.PatientReceiveID = ireader.GetDecimal(1);
                    inf.PatientCode = ireader.GetString(2);
                    inf.EmployeeCode = ireader.GetString(3);
                    inf.MM = ireader.GetDecimal(4);
                    inf.YYYY = ireader.GetDecimal(5);
                    inf.DateApproved = ireader.GetDateTime(6);
                    inf.ObjectCode = ireader.GetInt32(7);
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


        public static Int32 MedicinesForPatients_ReceiveIns(MedicinesForPatients_ReceiveINF info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[12];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar);
                param[0].Value = info.PatientCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = info.PatientReceiveID;
                param[2] = new SqlParameter("@ReferenceCode", SqlDbType.VarChar);
                param[2].Value = info.ReferenceCode;
                param[3] = new SqlParameter("@IDate", SqlDbType.DateTime);
                param[3].Value = info.IDate;
                param[4] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar);
                param[4].Value = info.EmployeeCode;
                param[5] = new SqlParameter("@ItemCode", SqlDbType.VarChar);
                param[5].Value = info.ItemCode;
                param[6] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar);
                param[6].Value = info.RepositoryCode;
                param[7] = new SqlParameter("@Quantity", SqlDbType.Decimal);
                param[7].Value = info.Quantity;
                param[8] = new SqlParameter("@Quantity_Receive", SqlDbType.Decimal);
                param[8].Value = info.Quantity_Receive;
                param[9] = new SqlParameter("@WorkDate_Receive", SqlDbType.DateTime);
                param[9].Value = info.WorkDate_Receive;
                param[10] = new SqlParameter("@Note", SqlDbType.NVarChar,250);
                param[10].Value = info.Note;
                param[11] = new SqlParameter("@RowIDMedicine", SqlDbType.Decimal);
                param[11].Value = info.RowIDMedicine;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_MedicinesForPatients_Receive", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch(Exception ex)
            { return -2; }
        }


        public static Int32 Ins(MedicinesForPatients info, ref decimal dRowIDMedicines)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = info.MedicalRecordCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = info.PatientReceiveID;
                param[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[2].Value = info.PatientCode;
                param[3] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[3].Value = info.EmployeeCode;
                param[4] = new SqlParameter("@MM", SqlDbType.Decimal);
                param[4].Value = info.MM;
                param[5] = new SqlParameter("@YYYY", SqlDbType.Decimal);
                param[5].Value = info.YYYY;
                param[6] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[6].Value = info.ObjectCode;
                param[7] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[7].Value = info.RowID;
                param[8] = new SqlParameter("@ShiftWork", SqlDbType.Char, 2);
                param[8].Value = info.shiftWork;
                param[9] = new SqlParameter("@OutRowID", SqlDbType.Decimal);
                param[9].Direction = ParameterDirection.Output;
                dRowIDMedicines = Convert.ToDecimal(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_MedicinesForPatients", param));
                if (dRowIDMedicines > 0)
                    return 1;
                else
                    return 0;
            }
            catch  { return -2; }
        }

        public static Int32 Del(string medicalCode, decimal rowIDMedicines, string emplyeeCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@Result", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar);
                param[1].Value = medicalCode;
                param[2] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[2].Value = rowIDMedicines;
                param[3] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[3].Value = emplyeeCode;
                return Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Del_MedicinesForPatients", param));
            }
            catch { return -2; }
        }

        public static Int32 UpdForDone(string medicalCode, decimal rowIDMedicines, string employeeCodeDone, Int32 done, decimal patientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@Result", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar);
                param[1].Value = medicalCode;
                param[2] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[2].Value = rowIDMedicines;
                param[3] = new SqlParameter("@EmployeeCodeDone", SqlDbType.VarChar, 20);
                param[3].Value = employeeCodeDone;
                param[4] = new SqlParameter("@Done", SqlDbType.Int);
                param[4].Value = done;
                param[5] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[5].Value = patientReceiveID;
                return Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proUpd_MedicinesForPatients", param));
            }
            catch { return 404; }
        }

        public static Int32 InsDetail(MedicinesForPatientsDetail info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[15];
                param[0] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[0].Value = info.MedicalRecordCode;
                param[1] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
                param[1].Value = info.ItemCode;
                param[2] = new SqlParameter("@DateOfIssues", SqlDbType.Int);
                param[2].Value = info.DateOfIssues;
                param[3] = new SqlParameter("@Quantity", SqlDbType.Decimal);
                param[3].Value = info.Quantity;
                param[4] = new SqlParameter("@UnitPrice", SqlDbType.Decimal);
                param[4].Value = info.UnitPrice;
                param[5] = new SqlParameter("@SalesPrice", SqlDbType.Decimal);
                param[5].Value = info.SalesPrice;
                param[6] = new SqlParameter("@BHYTPrice", SqlDbType.Decimal);
                param[6].Value = info.BHYTPrice;
                param[7] = new SqlParameter("@Amount", SqlDbType.Decimal);
                param[7].Value = info.Amount;
                param[8] = new SqlParameter("@RowIDInventoryGumshoe", SqlDbType.Decimal);
                param[8].Value = info.RowIDInventoryGumshoe;
                param[9] = new SqlParameter("@RateBHYT", SqlDbType.Decimal);
                param[9].Value = info.RateBHYT;
                param[10] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[10].Value = info.ObjectCode;
                param[11] = new SqlParameter("@RepositoryCode", SqlDbType.VarChar, 50);
                param[11].Value = info.RepositoryCode;
                param[12] = new SqlParameter("@QuantityExport", SqlDbType.Decimal);
                param[12].Value = info.QuantityExport;
                param[13] = new SqlParameter("@RowIDMedicines", SqlDbType.Decimal);
                param[13].Value = info.RowIDMedicines;
                param[14] = new SqlParameter("@RowIDMedicalPrescription", SqlDbType.Decimal);
                param[14].Value = info.RowIDMedicalPrescription;
                //RowIDMedicalPrescription
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_MedicinesForPatientsDetail", param);
            }
            catch { return -2; }
        }

        public static DataTable DT_StatisticMedicinesForPatients(DateTime dtfrom, DateTime dtto)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FromDate", SqlDbType.Date);
                param[0].Value = dtfrom;
                param[1] = new SqlParameter("@ToDate", SqlDbType.Date);
                param[1].Value = dtto;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_StatisticMedicinesForPatients", param);
            }
            catch { return null; }
        }

        public static DataTable hsba_MedicinesForPatients(decimal dReceiveID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "select MedicalRecordCode,PatientReceiveID,PatientCode,EmployeeCode,MM,YYYY,ObjectCode,RowID,DateApproved from MedicinesForPatients where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = dReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = sPatientCode;
                return cn.CallProcedureTable(CommandType.Text, sql, param);
            }
            catch { return null; }
        }

        public static DataTable hsba_MedicinesForPatientsdetail(decimal dReceiveID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "select a.RowID,a.MedicalRecordCode,a.ItemCode,a.DateOfIssues,a.Quantity,a.UnitPrice,a.SalesPrice,a.BHYTPrice,a.Amount,a.IDate,a.RowIDInventoryGumshoe,a.RateBHYT,a.ObjectCode,a.RepositoryCode,a.QuantityExport,a.RowIDMedicines,a.RowIDMedicalPrescription from MedicinesForPatientsDetail a inner join MedicinesForPatients b on a.RowIDMedicines=b.RowID where b.PatientReceiveID=@PatientReceiveID and b.PatientCode=@PatientCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = dReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = sPatientCode;
                return cn.CallProcedureTable(CommandType.Text, sql, param);
            }
            catch { return null; }
        }
        public static DataTable TablePrintMedicinesForPatients(string rowid)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RowID", SqlDbType.VarChar, 100);
                param[0].Value = rowid;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "proPrint_MedicinesForPatients", param);
            }
            catch { return null; }
        }

        public static bool UpdateDone(decimal patientRe, int done)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " update MedicinesForPatients set Done = {1}  where PatientReceiveID = {0}";
                cn.ExecuteQuery(string.Format(sql, patientRe, done));
                return true;
            }
            catch (Exception ex){ return false; }
        }

    }
}
