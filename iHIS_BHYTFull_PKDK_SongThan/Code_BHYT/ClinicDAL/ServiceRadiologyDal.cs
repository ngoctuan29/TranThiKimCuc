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
    public class ServiceRadiologyDal
    {
        public static Int32 InsRadiologyEntry(ServiceRadiologyEntryInf info, ref decimal refID, string serviceGroupCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[18];
                param[0] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[0].Value = info.ServiceCode;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = info.PatientCode;
                param[2] = new SqlParameter("@ReferenceCode", SqlDbType.NVarChar, 50);
                param[2].Value = info.ReferenceCode;
                param[3] = new SqlParameter("@AppointmentDate", SqlDbType.Date);
                param[3].Value = info.AppointmentDate;
                param[4] = new SqlParameter("@AppointmentNote", SqlDbType.NVarChar);
                param[4].Value = info.AppointmentNote;
                param[5] = new SqlParameter("@Contents", SqlDbType.NVarChar);
                param[5].Value = info.Contents;
                param[6] = new SqlParameter("@Conclusion", SqlDbType.NVarChar);
                param[6].Value = info.Conclusion;
                param[7] = new SqlParameter("@Proposal", SqlDbType.NVarChar);
                param[7].Value = info.Proposal;
                param[8] = new SqlParameter("@PostingDate", SqlDbType.DateTime);
                param[8].Value = info.PostingDate;
                param[9] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[9].Value = info.PatientReceiveID;
                param[10] = new SqlParameter("@Done", SqlDbType.Int);
                param[10].Value = info.Done;
                param[11] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[11].Value = info.EmployeeCode;
                param[12] = new SqlParameter("@SuggestedID", SqlDbType.Decimal);
                param[12].Value = info.SuggestedID;
                param[13] = new SqlParameter("@ResultRowID", SqlDbType.Decimal);
                param[13].Direction = ParameterDirection.Output;
                param[14] = new SqlParameter("@EmployeeCodeDoctor", SqlDbType.VarChar, 50);
                param[14].Value = info.EmployeeCodeDoctor;
                param[15] = new SqlParameter("@ServiceGroupCode", SqlDbType.VarChar, 50);
                param[15].Value = serviceGroupCode;
                param[16] = new SqlParameter("@ShiftWork", SqlDbType.Char, 2);
                param[16].Value = info.ShiftWork;
                param[17] = new SqlParameter("@Note", SqlDbType.NVarChar, 200);
                param[17].Value = info.Note;
                refID = Convert.ToDecimal(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Ins_ServiceRadiologyEntry", param));
                if (refID > 0)
                    return 1;
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 DelRadiologyEntry(decimal dSuggestedID, ref Int32 refID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@SuggestedID", SqlDbType.Decimal);
                param[0].Value = dSuggestedID;
                param[1] = new SqlParameter("@Result", SqlDbType.Int);
                param[1].Direction = ParameterDirection.Output;
                refID = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Del_ServiceRadiologyEntry", param));
                if (refID > 0)
                    return 1;
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 InsRadiologyDetailEntry(ServiceRadiologyDetailEntryInf info, Int32 iStatus)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@RadiologyRowID", SqlDbType.Decimal);
                param[0].Value = info.RadiologyRowID;
                param[1] = new SqlParameter("@Image", SqlDbType.Image);
                param[1].Value = info.Image;
                param[2] = new SqlParameter("@PostingDate", SqlDbType.DateTime);
                param[2].Value = info.PostingDate;
                param[3] = new SqlParameter("@Status", SqlDbType.Int);
                param[3].Value = iStatus;
                param[4] = new SqlParameter("@Checked", SqlDbType.Bit);
                param[4].Value = info.Checked;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_ServiceRadiologyDetailEntry", param) > 0)
                    return 1;
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 UpdRadiologyDetailEntry(ServiceRadiologyDetailEntryInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " update ServiceRadiologyDetailEntry set Image=@Image,PostingDate=getdate() where RadiologyRowID=@RadiologyRowID and RowID=@RowID ";
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@Image", SqlDbType.Image);
                param[1].Value = info.Image;
                param[2] = new SqlParameter("@RadiologyRowID", SqlDbType.Decimal);
                param[2].Value = info.RadiologyRowID;
                if (cn.ExecuteNonQuery(CommandType.Text, sql, param) > 0)
                    return 1;
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 DelRadiologyDetailEntry(decimal dRadiologyRowID, decimal dRowID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " delete from ServiceRadiologyDetailEntry where RadiologyRowID=@RadiologyRowID and RowID=@RowID ";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = dRowID;
                param[1] = new SqlParameter("@RadiologyRowID", SqlDbType.Decimal);
                param[1].Value = dRadiologyRowID;
                if (cn.ExecuteNonQuery(CommandType.Text, sql, param) > 0)
                    return 1;
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static Int32 DelRadiologyDetailEntry(decimal dRadiologyRowID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " delete from ServiceRadiologyDetailEntry where RadiologyRowID=@RadiologyRowID ";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RadiologyRowID", SqlDbType.Decimal);
                param[0].Value = dRadiologyRowID;
                if (cn.ExecuteNonQuery(CommandType.Text, sql, param) > 0)
                    return 1;
                else
                    return -1;
            }
            catch { return -2; }
        }

        public static List<ViewPreviousInf> ListPrevious(string sPatientCode, Int32 iMenu)
        {
            ConnectDB cn = new ConnectDB();
            List<ViewPreviousInf> list = new List<ViewPreviousInf>();
            try
            {
                string sql = string.Empty;
                sql = " select a.RowID,a.PatientCode,a.PostingDate,a.ServiceCode,b.ServiceName,a.EmployeeCode,a.EmployeeCodeDoctor,a1.EmployeeName EmployeeNameDoctor,a2.STT,a.SuggestedID from ServiceRadiologyEntry a inner join Service b on a.ServiceCode=b.ServiceCode inner join ServiceMenuForService c on a.ServiceCode=c.ServiceCode left join Employee a1 on a.EmployeeCodeDoctor=a1.EmployeeCode inner join SuggestedServiceReceipt a2 on a.SuggestedID=a2.ReceiptID where a.PatientCode in('{0}') and c.ServiceMenuID={1} order by a.PostingDate desc ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sPatientCode, iMenu), null);
                while (ireader.Read())
                {
                    ViewPreviousInf inf = new ViewPreviousInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.PatientCode = ireader.GetString(1);
                    inf.PostingDate = ireader.GetDateTime(2);
                    inf.ServiceCode = ireader.GetString(3);
                    inf.ServiceName = ireader.GetString(4);
                    inf.EmployeeCode = ireader.GetString(5);
                    inf.EmployeeCodeDoctor = ireader.GetValue(6).ToString();
                    inf.EmployeeNameDoctor = ireader.GetValue(7).ToString();
                    inf.STT = Convert.ToInt32(ireader.GetValue(8));
                    inf.SuggestedID = ireader.GetDecimal(9);
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

        public static List<ViewPreviousInf> ListPreviousPTT(string sPatientCode, Int32 iMenu)
        {
            ConnectDB cn = new ConnectDB();
            List<ViewPreviousInf> list = new List<ViewPreviousInf>();
            try
            {
                string sql = "";
                sql = @" 
                    select a.RowID,a.PatientCode,a.IDate PostingDate,b.ServiceCode,c.ServiceName,a.EmployeeCode,a.UDate
                    from Surgeries a inner join SuggestedServiceReceipt b on a.IDSuggested=b.ReceiptID inner join Service c on b.ServiceCode=c.ServiceCode 
                    inner join ServiceMenuForService d on c.ServiceCode=d.ServiceCode
                    where a.PatientCode in('{0}') and d.ServiceMenuID={1} order by RowID desc";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sPatientCode, iMenu), null);
                while (ireader.Read())
                {
                    ViewPreviousInf inf = new ViewPreviousInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.PatientCode = ireader.GetString(1);
                    inf.PostingDate = ireader.GetDateTime(2);
                    inf.ServiceCode = ireader.GetString(3);
                    inf.ServiceName = ireader.GetString(4);
                    inf.EmployeeCode = ireader.GetString(5);
                    inf.UDate = ireader.GetDateTime(6);
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
        
        public static ServiceRadiologyEntryInf ObjRadiologyEntry(decimal dRowID)
        {
            ConnectDB cn = new ConnectDB();
            ServiceRadiologyEntryInf inf = new ServiceRadiologyEntryInf();
            try
            {
                string sql = "select a.RowID,a.ServiceCode,a.PatientCode,a.ReferenceCode,a.AppointmentDate,a.AppointmentNote,a.Contents,a.Conclusion,a.Proposal,a.PostingDate,a.PatientReceiveID,a.Done,a.EmployeeCode,a.SuggestedID,a.EmployeeCodeDoctor,a.Note from ServiceRadiologyEntry a inner join Service b on a.ServiceCode=b.ServiceCode where a.RowID in({0}) order by RowID ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dRowID), null);
                if (ireader.Read())
                {
                    inf.RowID = ireader.GetDecimal(0);
                    inf.ServiceCode = ireader.GetString(1);
                    inf.PatientCode = ireader.GetString(2);
                    inf.ReferenceCode = ireader.GetString(3);
                    inf.AppointmentDate = ireader.GetDateTime(4);
                    inf.AppointmentNote = ireader.GetValue(5).ToString();
                    inf.Contents = ireader.GetValue(6).ToString();
                    inf.Conclusion = ireader.GetValue(7).ToString();
                    inf.Proposal = ireader.GetValue(8).ToString();
                    inf.PostingDate = ireader.GetDateTime(9);
                    inf.PatientReceiveID = ireader.GetDecimal(10);
                    inf.Done = ireader.GetInt32(11);
                    inf.EmployeeCode = ireader.GetValue(12).ToString();
                    inf.SuggestedID = ireader.GetDecimal(13);
                    inf.EmployeeCodeDoctor = ireader.GetValue(14).ToString();
                    inf.Note = ireader.GetValue(15).ToString();
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

        public static ServiceRadiologyEntryInf ObjRadiologyEntryForSuggestedID(decimal suggestedID)
        {
            ConnectDB cn = new ConnectDB();
            ServiceRadiologyEntryInf inf = new ServiceRadiologyEntryInf();
            try
            {
                string sql = "select a.RowID,a.ServiceCode,a.PatientCode,a.ReferenceCode,a.AppointmentDate,a.AppointmentNote,a.Contents,a.Conclusion,a.Proposal,a.PostingDate,a.PatientReceiveID,a.Done,a.EmployeeCode,a.SuggestedID,a.EmployeeCodeDoctor,a.Note from ServiceRadiologyEntry a inner join Service b on a.ServiceCode=b.ServiceCode where a.SuggestedID ={0} order by RowID ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, suggestedID), null);
                if (ireader.Read())
                {
                    inf.RowID = ireader.GetDecimal(0);
                    inf.ServiceCode = ireader.GetString(1);
                    inf.PatientCode = ireader.GetString(2);
                    inf.ReferenceCode = ireader.GetString(3);
                    inf.AppointmentDate = ireader.GetDateTime(4);
                    inf.AppointmentNote = ireader.GetValue(5).ToString();
                    inf.Contents = ireader.GetValue(6).ToString();
                    inf.Conclusion = ireader.GetValue(7).ToString();
                    inf.Proposal = ireader.GetValue(8).ToString();
                    inf.PostingDate = ireader.GetDateTime(9);
                    inf.PatientReceiveID = ireader.GetDecimal(10);
                    inf.Done = ireader.GetInt32(11);
                    inf.EmployeeCode = ireader.GetValue(12).ToString();
                    inf.SuggestedID = ireader.GetDecimal(13);
                    inf.EmployeeCodeDoctor = ireader.GetValue(14).ToString();
                    inf.Note = ireader.GetValue(15).ToString();
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

        public static List<ServiceRadiologyDetailEntryInf> ListRadiologyDetail(decimal dRadiology)
        {
            ConnectDB cn = new ConnectDB();
            List<ServiceRadiologyDetailEntryInf> list = new List<ServiceRadiologyDetailEntryInf>();
            try
            {
                string sql = "select RowID,RadiologyRowID,[Image],PostingDate,Checked from ServiceRadiologyDetailEntry where RadiologyRowID in({0}) order by RowID ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dRadiology), null);
                while (ireader.Read())
                {
                    ServiceRadiologyDetailEntryInf inf = new ServiceRadiologyDetailEntryInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.RadiologyRowID = ireader.GetDecimal(1);
                    inf.Image =(byte[])ireader.GetValue(2);
                    inf.PostingDate = ireader.GetDateTime(3);
                    inf.Checked = ireader.GetBoolean(4);
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

        public static List<ServiceRadiologyDetailEntryInf> ListRadiologyDetailForReceiptID(decimal dReceipt)
        {
            ConnectDB cn = new ConnectDB();
            List<ServiceRadiologyDetailEntryInf> list = new List<ServiceRadiologyDetailEntryInf>();
            try
            {
                string sql = string.Empty;
                sql = "select a.RowID,a.RadiologyRowID,a.Image,a.PostingDate,a.Checked from ServiceRadiologyDetailEntry a inner join ServiceRadiologyEntry b on a.RadiologyRowID=b.RowID  where b.SuggestedID ={0} and a.Checked=1 order by RowID ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dReceipt), null);
                while (ireader.Read())
                {
                    ServiceRadiologyDetailEntryInf inf = new ServiceRadiologyDetailEntryInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.RadiologyRowID = ireader.GetDecimal(1);
                    inf.Image = (byte[])ireader.GetValue(2);
                    inf.PostingDate = ireader.GetDateTime(3);
                    inf.Checked = ireader.GetBoolean(4);
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

        public static DataTable DT_ResultRadiology(decimal dSuggestedID, decimal patientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@SuggestedID", SqlDbType.Decimal);
                param[0].Value = dSuggestedID;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = patientReceiveID;
                return cn.CallProcedureTable(CommandType.StoredProcedure, "pro_ResultRadiology", param);
            }
            catch { return null; }
        }

        public static DataTable hsba_RadiologyEntry(decimal dReceiveID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = " select RowID,ServiceCode,PatientCode,ReferenceCode,AppointmentDate,AppointmentNote,Contents,Conclusion,Proposal,PostingDate,PatientReceiveID,Done,EmployeeCode,SuggestedID from ServiceRadiologyEntry where PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = dReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = sPatientCode;
                return cn.CallProcedureTable(CommandType.Text, sql, param);
            }
            catch { return null; }
        }

        public static DataTable hsba_RadiologyEntrydetail(decimal dReceiveID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("RowID", typeof(decimal));
            dtResult.Columns.Add("RadiologyRowID", typeof(decimal));
            dtResult.Columns.Add("Image", typeof(string));
            dtResult.Columns.Add("PostingDate", typeof(DateTime));
            try
            {
                string sql = @" select a.RowID,a.RadiologyRowID,a.Image,a.PostingDate 
from ServiceRadiologyDetailEntry a inner join ServiceRadiologyEntry b on a.RadiologyRowID=b.RowID where b.PatientReceiveID=@PatientReceiveID and b.PatientCode=@PatientCode ";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = dReceiveID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = sPatientCode;
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, param);
                while (ireader.Read())
                {
                    DataRow dr = dtResult.NewRow();
                    dr[0] = Convert.ToDecimal(ireader.GetValue(0).ToString());
                    dr[1] = Convert.ToDecimal(ireader.GetValue(1).ToString());
                    if (ireader.GetValue(2).ToString() != "")
                    {
                        byte[] bytestemp = (byte[])ireader.GetValue(2);
                        dr[2] = Convert.ToBase64String(bytestemp);
                    }
                    dr[3] = ireader.GetDateTime(3);
                    dtResult.Rows.Add(dr);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { }
            return dtResult;
        }

    }
}
