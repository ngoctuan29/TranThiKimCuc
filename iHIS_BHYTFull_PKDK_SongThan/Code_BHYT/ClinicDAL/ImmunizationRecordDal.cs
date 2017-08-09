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
    public class ImmunizationRecordDal
    {
        public static List<ImmunizationRecordInf> ListImmunizationAll()
        {
            ConnectDB cn = new ConnectDB();
            List<ImmunizationRecordInf> list = new List<ImmunizationRecordInf>();
            try
            {
                string sql = " select ImmunizationRecordCode,ObjectCode,PatientType,ServiceCode,PatientReceiveID,PatientCode,ReceiptID,DepartmentCode,WorkDate,EmployeeCode,Status from ImmunizationRecord order by ImmunizationRecordCode ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    ImmunizationRecordInf inf = new ImmunizationRecordInf();
                    inf.ImmunizationRecordCode = ireader.GetString(0);
                    inf.ObjectCode = ireader.GetInt32(1);
                    inf.PatientType = ireader.GetInt32(2);
                    inf.ServiceCode = ireader.GetString(3);
                    inf.PatientReceiveID = ireader.GetDecimal(4);
                    inf.PatientCode = ireader.GetString(5);
                    inf.ReceiptID = ireader.GetDecimal(6);
                    inf.DepartmentCode = ireader.GetString(7);
                    inf.WorkDate = ireader.GetDateTime(8);
                    inf.EmployeeCode = ireader.GetString(9);
                    inf.Status = ireader.GetInt32(10);
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch {  }
            return list;
        }

        public static ImmunizationRecordInf ObjImmunization(string recordCode)
        {
            ConnectDB cn = new ConnectDB();
            ImmunizationRecordInf inf = new ImmunizationRecordInf();
            try
            {
                string sql = " select ImmunizationRecordCode,ObjectCode,PatientType,ServiceCode,PatientReceiveID,PatientCode,ReceiptID,DepartmentCode,WorkDate,EmployeeCode,Status from ImmunizationRecord where ImmunizationRecordCode='{0}' order by ImmunizationRecordCode ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, recordCode), null);
                if (ireader.Read())
                {
                    
                    inf.ImmunizationRecordCode = ireader.GetString(0);
                    inf.ObjectCode = ireader.GetInt32(1);
                    inf.PatientType = ireader.GetInt32(2);
                    inf.ServiceCode = ireader.GetString(3);
                    inf.PatientReceiveID = ireader.GetDecimal(4);
                    inf.PatientCode = ireader.GetString(5);
                    inf.ReceiptID = ireader.GetDecimal(6);
                    inf.DepartmentCode = ireader.GetString(7);
                    inf.WorkDate = ireader.GetDateTime(8);
                    inf.EmployeeCode = ireader.GetString(9);
                    inf.Status = ireader.GetInt32(10);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { }
            return inf;
        }

        public static bool InsImmunization(ImmunizationRecordInf info, ref string recordCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[12];
                param[0] = new SqlParameter("@ImmunizationRecordCode", SqlDbType.VarChar, 15);
                param[0].Value = info.ImmunizationRecordCode;
                param[1] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[1].Value = info.ObjectCode;
                param[2] = new SqlParameter("@PatientType", SqlDbType.Int);
                param[2].Value = info.PatientType;
                param[3] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[3].Value = info.ServiceCode;
                param[4] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[4].Value = info.PatientReceiveID;
                param[5] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[5].Value = info.PatientCode;
                param[6] = new SqlParameter("@ReceiptID", SqlDbType.Decimal);
                param[6].Value = info.ReceiptID;
                param[7] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[7].Value = info.DepartmentCode;
                param[8] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[8].Value = info.EmployeeCode;
                param[9] = new SqlParameter("@Status", SqlDbType.Int);
                param[9].Value = info.Status;
                param[10] = new SqlParameter("@ShiftWork", SqlDbType.Char, 2);
                param[10].Value = info.ShiftWork;
                param[11] = new SqlParameter("@ReturnCode", SqlDbType.VarChar, 15);
                param[11].Direction = ParameterDirection.Output;
                string result = cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proInsImmunizationRecord", param);
                if (result != string.Empty)
                {
                    recordCode = result;
                    return true;
                }
                else
                {
                    recordCode = string.Empty;
                    return false;
                }
            }
            catch { return false; }
        }

        public static bool InsImmunizationDetail(ImmunizationRecordDetailInf info, ref string recordCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[13];
                param[0] = new SqlParameter("@ImmunizationRecordDetailCode", SqlDbType.VarChar, 15);
                param[0].Value = info.ImmunizationRecordDetailCode;
                param[1] = new SqlParameter("@ImmunizationRecordCode", SqlDbType.VarChar, 15);
                param[1].Value = info.ImmunizationRecordCode;
                param[2] = new SqlParameter("@RowIDDoseNo", SqlDbType.Int);
                param[2].Value = info.RowIDDoseNo;
                param[3] = new SqlParameter("@LotNo", SqlDbType.VarChar, 50);
                param[3].Value = info.LotNo;
                param[4] = new SqlParameter("@Note", SqlDbType.NVarChar, 200);
                param[4].Value = info.Note;
                param[5] = new SqlParameter("@Content", SqlDbType.NVarChar);
                param[5].Value = info.Content;
                param[6] = new SqlParameter("@DateGiven", SqlDbType.DateTime);
                param[6].Value = info.DateGiven;
                param[7] = new SqlParameter("@AppointmentDate", SqlDbType.VarChar,20);
                param[7].Value = info.AppointmentDate;
                param[8] = new SqlParameter("@AppointmentContent", SqlDbType.NVarChar, 200);
                param[8].Value = info.AppointmentContent;
                param[9] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[9].Value = info.EmployeeCode;
                param[10] = new SqlParameter("@ShiftWork", SqlDbType.Char, 2);
                param[10].Value = info.ShiftWork;
                param[11] = new SqlParameter("@EmployeeCodeDoctor", SqlDbType.VarChar, 50);
                param[11].Value = info.EmployeeCodeDoctor;
                param[12] = new SqlParameter("@ReturnCode", SqlDbType.VarChar, 15);
                param[12].Direction = ParameterDirection.Output;
                string result = cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proInsImmunizationRecordDetail", param);
                if (result != string.Empty)
                {
                    recordCode = result;
                    return true;
                }
                else
                {
                    recordCode = string.Empty;
                    return false;
                }
            }
            catch { return false; }
        }

        public static Int32 DelImmunization(string recordCode, string employeeCode, string recordDetailCode, decimal patientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@Result", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@ImmunizationRecordCode", SqlDbType.VarChar, 15);
                param[1].Value = recordCode;
                param[2] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[2].Value = employeeCode;
                param[3] = new SqlParameter("@ImmunizationRecordDetailCode", SqlDbType.VarChar, 15);
                param[3].Value = recordDetailCode;
                param[4] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[4].Value = patientReceiveID;
                return Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proDelImmunizationRecord", param));
            }
            catch { return -1; }
        }

        public static Int32 DelImmunizationForMedical(string recordCode, string employeeCode, string recordDetailCode, decimal patientReceiveID, string medicalRecordCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@Result", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@ImmunizationRecordCode", SqlDbType.VarChar, 15);
                param[1].Value = recordCode;
                param[2] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[2].Value = employeeCode;
                param[3] = new SqlParameter("@ImmunizationRecordDetailCode", SqlDbType.VarChar, 15);
                param[3].Value = recordDetailCode;
                param[4] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[4].Value = patientReceiveID;
                param[5] = new SqlParameter("@MedicalRecordCode", SqlDbType.VarChar, 50);
                param[5].Value = medicalRecordCode;
                return Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proDelImmunizationRecordWithMedical", param));
            }
            catch { return -1; }
        }

        public static Int32 UpdStatusImmunizationRecord(string employeeCode, decimal patientReceiveID, string immunizationCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@Result", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@ImmunizationRecordCode", SqlDbType.VarChar, 15);
                param[1].Value = immunizationCode;
                param[2] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[2].Value = employeeCode;
                param[3] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[3].Value = patientReceiveID;
                return Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proUpdImmunizationRecord", param));
            }
            catch { return -1; }
        }

        public static DataTable TableDoseNo()
        {
            DataTable dtbResult = new DataTable();
            dtbResult.Columns.Add("RowID", typeof(int));
            dtbResult.Columns.Add("DoseNoName", typeof(string));
            try
            {
                ConnectDB cn = new ConnectDB();
                string query = "select RowID,DoseNoName from CatalogDoseNo order by RowID ";
                dtbResult = cn.ExecuteQuery(query);
            }
            catch { }
            return dtbResult;
        }

        public static List<ImmunizationRecordDetailInf> ListImmunizationDetail(string recordCode)
        {
            ConnectDB cn = new ConnectDB();
            List<ImmunizationRecordDetailInf> lstResult = new List<ImmunizationRecordDetailInf>();
            try
            {
                string sql = " select a.RowID,a.ImmunizationRecordCode,a.ImmunizationRecordDetailCode,a.RowIDDoseNo,a.LotNo,a.Note,a.Content,a.DateGiven,a.AppointmentDate,a.AppointmentContent,b.DoseNoName,a.EmployeeCode,c.MedicalRecordCode from ImmunizationRecordDetail a inner join CatalogDoseNo b on a.RowIDDoseNo=b.RowID left join MedicalRecord c on a.ImmunizationRecordDetailCode=c.ReferenceCode and c.TypeMedical=3 where a.ImmunizationRecordCode='{0}' order by a.DateGiven desc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, recordCode), null);
                while (ireader.Read())
                {
                    ImmunizationRecordDetailInf inf = new ImmunizationRecordDetailInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.ImmunizationRecordCode = ireader.GetString(1);
                    inf.ImmunizationRecordDetailCode = ireader.GetValue(2).ToString();
                    inf.RowIDDoseNo = ireader.GetInt32(3);
                    inf.LotNo = ireader.GetValue(4).ToString();
                    inf.Note = ireader.GetValue(5).ToString();
                    inf.Content = ireader.GetValue(6).ToString();
                    inf.DateGiven = ireader.GetDateTime(7);
                    inf.AppointmentDate = ireader.GetValue(8).ToString();
                    inf.AppointmentContent = ireader.GetValue(9).ToString();
                    inf.DoseNoName = ireader.GetValue(10).ToString();
                    inf.EmployeeCode = ireader.GetValue(11).ToString();
                    inf.MedicalRecordCode = ireader.GetValue(12).ToString();
                    lstResult.Add(inf);
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

        public static DataTable TableImmunizationHistoryTimes(string serviceCode, string immunizationRecordCode, decimal patientReceiveID, string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = @"proGetImmunizationHistoryTimes";
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@ImmunizationRecordCode", SqlDbType.VarChar, 15);
                param[0].Value = immunizationRecordCode;
                param[1] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[1].Value = serviceCode;
                param[2] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[2].Value = patientReceiveID;
                param[3] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[3].Value = patientCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, query, param);
            }
            catch { return null; }
        }

        public static ImmunizationRecordDetailInf ObjImmunizationDetail(string recordDetailCode)
        {
            ConnectDB cn = new ConnectDB();
            ImmunizationRecordDetailInf inf = new ImmunizationRecordDetailInf();
            try
            {
                string sql = " select a.RowID,a.ImmunizationRecordCode,a.ImmunizationRecordDetailCode,a.RowIDDoseNo,a.LotNo,a.Note,a.Content,a.DateGiven,a.AppointmentDate,a.AppointmentContent,b.DoseNoName from ImmunizationRecordDetail a inner join CatalogDoseNo b on a.RowIDDoseNo=b.RowID where a.ImmunizationRecordDetailCode='{0}' ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, recordDetailCode), null);
                if (ireader.Read())
                {
                    inf.RowID = ireader.GetDecimal(0);
                    inf.ImmunizationRecordCode = ireader.GetString(1);
                    inf.ImmunizationRecordDetailCode = ireader.GetValue(2).ToString();
                    inf.RowIDDoseNo = ireader.GetInt32(3);
                    inf.LotNo = ireader.GetValue(4).ToString();
                    inf.Note = ireader.GetValue(5).ToString();
                    inf.Content = ireader.GetValue(6).ToString();
                    inf.DateGiven = ireader.GetDateTime(7);
                    inf.AppointmentDate = ireader.GetValue(8).ToString();
                    inf.AppointmentContent = ireader.GetValue(9).ToString();
                    inf.DoseNoName = ireader.GetValue(10).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { }
            return inf;
        }

        public static DataTable TableRptViewImmunization(string recordCode, decimal patientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ImmunizationRecordCode", SqlDbType.VarChar, 15);
                param[0].Value = recordCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = patientReceiveID;
                dt = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_RptViewImmunization", param);
            }
            catch { }
            return dt;
        }

        public static DataTable TableRptViewImmunizationDetail(string recordCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ImmunizationRecordCode", SqlDbType.VarChar, 15);
                param[0].Value = recordCode;
                dt = cn.CallProcedureTable(CommandType.StoredProcedure, "pro_RptViewImmunizationDetail", param);
            }
            catch { }
            return dt;
        }

    }

    public class ImmunizationTimesDetailDAL
    {
        public static Int32 IUTimesDetail(ImmunizationTimesDetailInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("@TimesDetailID", SqlDbType.Int);
                param[0].Value = info.TimesDetailID;
                param[1] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[1].Value = info.ServiceCode;
                param[2] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[2].Value = info.EmployeeCode;
                param[3] = new SqlParameter("@DayTimes", SqlDbType.Int);
                param[3].Value = info.DayTimes;
                param[4] = new SqlParameter("@DoseNoID", SqlDbType.Int);
                param[4].Value = info.DoseNoID;
                param[5] = new SqlParameter("@DayTimesCome", SqlDbType.Int);
                param[5].Value = info.DayTimesCome;
                param[6] = new SqlParameter("@Warning", SqlDbType.Bit);
                param[6].Value = info.Warning ? 1 : 0;
                param[7] = new SqlParameter("@Note", SqlDbType.NVarChar);
                param[7].Value = info.Note;
                param[8] = new SqlParameter("@TimesEntryID", SqlDbType.Int);
                param[8].Value = info.TimesEntryID;
                param[9] = new SqlParameter("@Status", SqlDbType.Int);
                param[9].Direction = ParameterDirection.Output;
                Int32 result = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proIU_ImmunizationTimes", param));
                return result;
            }
            catch { return -404; }
        }

        public static DataTable TableTimesDetail(int timesEntryID)
        {
            string query = " select TimesDetailID,ServiceCode,EmployeeCode,DayTimes,DoseNoID,DayTimesCome,Note,Warning from ImmunizationTimesDetail where TimesEntryID={0} ";
            try
            {
                ConnectDB cn = new ConnectDB();
                return cn.ExecuteQuery(string.Format(query, timesEntryID));
            }
            catch { return null; }
        }

        public static Int32 DelTimesDetail(string serviceCode, int doseNoID, string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[0].Value = serviceCode;
                param[1] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[1].Value = employeeCode;
                param[2] = new SqlParameter("@DoseNoID", SqlDbType.Int);
                param[2].Value = doseNoID;
                param[3] = new SqlParameter("@Status", SqlDbType.Int);
                param[3].Direction = ParameterDirection.Output;
                Int32 result = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proDel_ImmunizationTimes", param));
                return result;
            }
            catch { return -404; }
        }

    }

    public class ImmunizationTimesEntryDAL
    {
        public static ImmunizationTimesEntryInf ObjTimesEntry(string serviceCode)
        {
            ConnectDB connect = new ConnectDB();
            ImmunizationTimesEntryInf inf = new ImmunizationTimesEntryInf();
            try
            {
                string sql = " select TimesEntryID,ServiceCode,EmployeeCode,Note,Title from ImmunizationTimesEntry where ServiceCode='{0}'";
                IDataReader ireader = connect.ExecuteReader(CommandType.Text, string.Format(sql, serviceCode), null);
                if (ireader.Read())
                {

                    inf.TimesEntryID = ireader.GetInt32(0);
                    inf.ServiceCode = ireader.GetString(1);
                    inf.EmployeeCode = ireader.GetString(2);
                    inf.Note = ireader.GetValue(3).ToString();
                    inf.Title = ireader.GetValue(4).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return inf;
            }
            catch { return null; }
            
        }
        public static ImmunizationTimesEntryInf ObjTimesEntryID(int timesEntryID)
        {
            ConnectDB connect = new ConnectDB();
            ImmunizationTimesEntryInf inf = new ImmunizationTimesEntryInf();
            try
            {
                string sql = " select TimesEntryID,ServiceCode,EmployeeCode,Note,Title from ImmunizationTimesEntry where TimesEntryID={0}";
                IDataReader ireader = connect.ExecuteReader(CommandType.Text, string.Format(sql, timesEntryID), null);
                if (ireader.Read())
                {

                    inf.TimesEntryID = ireader.GetInt32(0);
                    inf.ServiceCode = ireader.GetString(1);
                    inf.EmployeeCode = ireader.GetString(2);
                    inf.Note = ireader.GetValue(3).ToString();
                    inf.Title = ireader.GetValue(4).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return inf;
            }
            catch { return null; }

        }
        public static List<ImmunizationTimesEntryInf> ListTimesEntryAll()
        {
            ConnectDB connect = new ConnectDB();
            List<ImmunizationTimesEntryInf> lst = new List<ImmunizationTimesEntryInf>();
            try
            {
                string sql = " select TimesEntryID,ServiceCode,EmployeeCode,Note,Title from ImmunizationTimesEntry order by Title ";
                IDataReader ireader = connect.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    ImmunizationTimesEntryInf inf = new ImmunizationTimesEntryInf();
                    inf.TimesEntryID = ireader.GetInt32(0);
                    inf.ServiceCode = ireader.GetString(1);
                    inf.EmployeeCode = ireader.GetString(2);
                    inf.Note = ireader.GetValue(3).ToString();
                    inf.Title = ireader.GetValue(4).ToString();
                    lst.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return lst;
            }
            catch { return null; }

        }

        public static bool IUTimesEntry(ImmunizationTimesEntryInf info, ref int timesEntryIDTemp)
        {
            ConnectDB connect = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[0].Value = info.ServiceCode;
                param[1] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[1].Value = info.EmployeeCode;
                param[2] = new SqlParameter("@Note", SqlDbType.NVarChar);
                param[2].Value = info.Note;
                param[3] = new SqlParameter("@Title", SqlDbType.NVarChar);
                param[3].Value = info.Title;
                param[4] = new SqlParameter("@TimesEntryID", SqlDbType.Int);
                param[4].Value = info.TimesEntryID;
                param[5] = new SqlParameter("@TimesEntryIDTemp", SqlDbType.Int);
                param[5].Direction = ParameterDirection.Output;
                timesEntryIDTemp = Convert.ToInt32(connect.ExecuteReaderProcedure(CommandType.StoredProcedure, "proIU_ImmunizationTimesEntry", param));
                if (timesEntryIDTemp > 0)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        public static Int32 DelTimesEntry(string serviceCode, string employeeCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[0].Value = serviceCode;
                param[1] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[1].Value = employeeCode;
                param[2] = new SqlParameter("@Status", SqlDbType.Int);
                param[2].Direction = ParameterDirection.Output;
                Int32 result = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proDel_ImmunizationEntry", param));
                return result;
            }
            catch { return -404; }
        }

    }

}
