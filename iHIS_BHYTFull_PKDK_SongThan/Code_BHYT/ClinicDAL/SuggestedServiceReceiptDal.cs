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
    public class SuggestedServiceReceiptDal
    {
        public static List<SuggestedServiceReceiptInf> List(decimal dId)
        {
            ConnectDB cn = new ConnectDB();
            List<SuggestedServiceReceiptInf> list = new List<SuggestedServiceReceiptInf>();
            try
            {
                string sql = string.Empty;
                if (dId != 0)
                {
                    sql = "select ReceiptID,DepartmentCode,ServiceCode,ServicePrice,DisparityPrice,PatientCode,Status,Paid,CreateDate,ServicePackageCode,EmployeeCode,Note,RefID,ObjectCode,PatientType,WorkDate from SuggestedServiceReceipt where ReceiptID={0}";
                }
                else
                {
                    sql = "select ReceiptID,DepartmentCode,ServiceCode,ServicePrice,DisparityPrice,PatientCode,Status,Paid,CreateDate,ServicePackageCode, EmployeeCode,Note,RefID,ObjectCode,PatientType,WorkDate order by ReceiptID desc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dId), null);
                while (ireader.Read())
                {
                    SuggestedServiceReceiptInf inf = new SuggestedServiceReceiptInf();
                    inf.ReceiptID = ireader.GetDecimal(0);
                    inf.DepartmentCode = ireader.GetString(1);
                    inf.ServiceCode = ireader.GetString(2);
                    inf.ServicePrice = ireader.GetDecimal(3);
                    inf.DisparityPrice = ireader.GetDecimal(4);
                    inf.PatientCode = ireader.GetString(5);
                    inf.Status = ireader.GetInt32(6);
                    inf.Paid = ireader.GetInt32(7);
                    inf.CreateDate = ireader.GetDateTime(8);
                    inf.ServicePackageCode = ireader.GetValue(9).ToString();
                    inf.EmployeeCode = ireader.GetValue(10).ToString();
                    inf.Note = ireader.GetValue(11).ToString();
                    inf.RefID = ireader.GetDecimal(12);
                    inf.ObjectCode = ireader.GetInt32(13);
                    inf.PatientType = ireader.GetInt32(14);
                    inf.WorkDate = ireader.GetDateTime(15);
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

        public static List<SuggestedServiceReceiptInf> SuggestedServiceReceipt(string sNote, decimal dRefID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<SuggestedServiceReceiptInf> lst = new List<SuggestedServiceReceiptInf>();
            try
            {
                string sql = string.Empty;
                sql = "select ReceiptID,DepartmentCode,ServiceCode,ServicePrice,DisparityPrice,PatientCode,Status,Paid,CreateDate,ServicePackageCode,EmployeeCode,Note,RefID,ObjectCode,PatientType,WorkDate from SuggestedServiceReceipt where Note='{0}' and RefID in({1}) and PatientCode='{2}'";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sNote, dRefID, sPatientCode), null);
                while (ireader.Read())
                {
                    SuggestedServiceReceiptInf inf = new SuggestedServiceReceiptInf();
                    inf.ReceiptID = ireader.GetDecimal(0);
                    inf.DepartmentCode = ireader.GetString(1);
                    inf.ServiceCode = ireader.GetString(2);
                    inf.ServicePrice = ireader.GetDecimal(3);
                    inf.DisparityPrice = ireader.GetDecimal(4);
                    inf.PatientCode = ireader.GetString(5);
                    inf.Status = ireader.GetInt32(6);
                    inf.Paid = ireader.GetInt32(7);
                    inf.CreateDate = ireader.GetDateTime(8);
                    inf.ServicePackageCode = ireader.GetValue(9).ToString();
                    inf.EmployeeCode = ireader.GetValue(10).ToString();
                    inf.Note = ireader.GetValue(11).ToString();
                    inf.RefID = ireader.GetDecimal(12);
                    inf.ObjectCode = ireader.GetInt32(13);
                    inf.PatientType = ireader.GetInt32(14);
                    inf.WorkDate = ireader.GetDateTime(15);
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

        public static List<SuggestedServiceReceiptInf> ListForPatientCode(string sPatientCode, int iType)
        {
            ConnectDB cn = new ConnectDB();
            List<SuggestedServiceReceiptInf> list = new List<SuggestedServiceReceiptInf>();
            try
            {
                string sql = " Select WorkDate,RefID,PatientCode from SuggestedServiceReceipt where PatientCode='{0}' and PatientType={1} order by CreateDate desc ";

                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sPatientCode, iType), null);
                while (ireader.Read())
                {
                    SuggestedServiceReceiptInf inf = new SuggestedServiceReceiptInf();
                    inf.WorkDate = ireader.GetDateTime(0);
                    inf.RefID = ireader.GetDecimal(1);
                    inf.PatientCode = ireader.GetString(2);
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
        
        public static DataTable DTListForPatientReceiveId(decimal dRefId, string sPatientCode, int iPatientType, string snote, string sDate, string sReferenceCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = @" select a.ReceiptID RowID, a.DepartmentCode,a.ServiceCode,(a.ServicePrice-a.AmountExemption) ServicePrice,a.DisparityPrice,a.PatientCode,a.Status,a.Paid,a.CreateDate,a.EmployeeCode,a.Note,a.RefID,a.ObjectCode,a.RowIDPrice,a.ServicePackageCode,d.ServiceName, Check_ as Del,a.PatientType,a.WorkDate,a.ReferenceCode,a.Quantity,a.AmountExemption,d.UnitOfMeasureCode,a.Content,d.Attach_Items
                        from SuggestedServiceReceipt a inner join PatientReceive b on a.RefID=b.PatientReceiveID inner join ServicePrice c on a.RowIDPrice=c.RowID inner join [Service] d on c.ServiceCode=d.ServiceCode 
                        where a.RefID in ({0}) and a.PatientCode ='{1}' and a.PatientType in({2}) and CONVERT(date,a.WorkDate,103)=CONVERT(date,'{3}',103) ";
                if (sReferenceCode != "")
                    sql += " and a.ReferenceCode='{4}'";
                sql += " and a.ReceiptID_DisparityPrice=0 ";
                sql += " order by a.STT ";
                dt = cn.ExecuteQuery(string.Format(sql, dRefId, sPatientCode, iPatientType, sDate, sReferenceCode));
            }
            catch  { dt = null; }
            return dt;
        }
                
        public static DataTable DTListReceiveIdGroupDate(decimal dRefId, string sPatientCode, int iPatientType)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = @" select PatientCode,RefID PatientReceiveID,convert(char(10),workdate,103) CreateDate
                        from SuggestedServiceReceipt 
                        where RefID in ({0}) and PatientCode ='{1}' and PatientType in({2})
                        group by PatientCode,RefID,convert(char(10),workdate,103) order by convert(char(10),workdate,103) desc
                         ";
                dt = cn.ExecuteQuery(string.Format(sql, dRefId, sPatientCode, iPatientType));
            }
            catch { dt = null; }
            return dt;
        }

        public static DataTable DTListForPatientReceivePre(decimal dRefId, string sPatientCode, int iPatientType, string snote, string sDate)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = @" select a.ReceiptID RowID, a.DepartmentCode,a.ServiceCode,a.ServicePrice,a.DisparityPrice,a.PatientCode,a.Status,a.Paid,a.CreateDate,a.EmployeeCode,a.Note,a.RefID,a.ObjectCode,a.RowIDPrice,a.ServicePackageCode,d.ServiceName, 0 as Del ,a.PatientType,a.WorkDate,c.RowID RowIDPrice,a.ReferenceCode,a.EmployeeCode
                        from SuggestedServiceReceipt a inner join PatientReceive b on a.RefID=b.PatientReceiveID inner join ServicePrice c on a.RowIDPrice=c.RowID inner join [Service] d on c.ServiceCode=d.ServiceCode 
                        where a.RefID in ({0}) and a.PatientCode ='{1}' and a.PatientType in({2}) and a.note ='{3}' and convert(date,a.createDate,103)=convert(date,'{4}',103)";
                dt = cn.ExecuteQuery(string.Format(sql, dRefId, sPatientCode, iPatientType, snote));
            }
            catch { dt = null; }
            return dt;
        }

        public static DataTable DTListForPatientReceiveHSBA(decimal dRefId, string sPatientCode, string snote)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = @" select a.ReceiptID RowID, a.DepartmentCode,a.ServiceCode,a.PatientCode,a.RefID,a.ObjectCode,d.ServiceName,e.MedicalRecordCode,a.PatientType,f.DepartmentName,g.ServiceMenuID
                        from SuggestedServiceReceipt a inner join PatientReceive b on a.RefID=b.PatientReceiveID 
                        left join ServicePrice c on a.RowIDPrice=c.RowID left join [Service] d on c.ServiceCode=d.ServiceCode
                        left join MedicalRecord e on a.RefID=e.PatientReceiveID and a.PatientCode=e.PatientCode and a.DepartmentCode=e.DepartmentCode
                        left join Department f on a.DepartmentCode=f.DepartmentCode left join ServiceMenuForService g on a.ServiceCode=g.ServiceCode
                        where a.RefID in ({0}) and a.PatientCode ='{1}' ";
                if (snote == "TIEPDON")
                    sql += "  and a.note ='{2}' ";
                else
                    sql += "  and a.note not in('TIEPDON') ";
                sql += " order by a.CreateDate asc ";
                dt = cn.ExecuteQuery(string.Format(sql, dRefId, sPatientCode, snote));
            }
            catch { dt = null; }
            return dt;
        }

        public static DataTable DTListForPatientServiceHSBA(decimal refID, string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string query = "proHSBAResultService";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@RefID", SqlDbType.Decimal);
                param[0].Value = refID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = patientCode;
                return cn.CallProcedureTable(CommandType.StoredProcedure, query, param);
            }
            catch { tableResult = null; }
            return tableResult;
        }

        public static DataTable DTListForGroupServiceHSBA(decimal dRefId, string sPatientCode, string sDepartmentCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = @"  select d.ServiceGroupName,d.ServiceGroupCode,d.STT
                        from SuggestedServiceReceipt a inner join PatientReceive b on a.RefID=b.PatientReceiveID 
                        inner join Service c on a.ServiceCode=c.ServiceCode inner join ServiceGroup d on c.ServiceGroupCode=d.ServiceGroupCode
                        where a.RefID in ({0}) and a.PatientCode ='{1}' and a.DepartmentCodeOrder ='{2}' 
                        group by d.ServiceGroupName,d.ServiceGroupCode,d.STT
                        order by d.STT
                        ";
                dt = cn.ExecuteQuery(string.Format(sql, dRefId, sPatientCode, sDepartmentCode));
            }
            catch { dt = null; }
            return dt;
        }

        public static DataTable TableListServiceFor(decimal refId, string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = "pro_GetServicePatient";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = refId;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar);
                param[1].Value = patientCode;
                dt = cn.CallProcedureTable(CommandType.StoredProcedure, sql, param);
            }
            catch { dt = null; }
            return dt;
        }


        public static DataTable Gia(string serviceCode)
        {
            
            ConnectDB cn = new ConnectDB();
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("RowID", typeof(decimal));
                dt.Columns.Add("UnitPrice", typeof(decimal));
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[0].Value = serviceCode;
                var render = cn.ExecuteReader(CommandType.StoredProcedure, "pro_LayGia", param);
                while(render.Read())
                {
                    DataRow r = dt.NewRow();
                    r.BeginEdit();
                    r[0] = render.GetDecimal(0);
                    r[1] = render.GetDecimal(1);
                    r.EndEdit();
                    dt.Rows.Add(r);
                }
                return dt;
                
              }
              catch (Exception ex)
              {
                return null;
              }
           }



        public static Int32 Lanthuchien(string svitemCode, string severcode)
        {

            ConnectDB cn = new ConnectDB();
            int solan = 1;
            try
            {
                //string query = "update SuggestedServiceReceipt set EmployeeCodeDoctor=@EmployeeCodeDoctor where ReceiptID=@ReceiptID";
                
                string query = "select Quantity from Attach_Service where ItemCode=@ItemCode and AttachServiceCode=@Servicode ";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ItemCode", SqlDbType.VarChar,50);
                param[0].Value = svitemCode;
                param[1] = new SqlParameter("@Servicode ", SqlDbType.VarChar, 50);
                param[1].Value = severcode;
                var render = cn.ExecuteReader(CommandType.Text, query, param);
                while(render.Read())
                {
                    solan = render.GetInt32(0);
                }
                if (solan > 1)
                {
                    return solan;
                }
                else
                    return solan = 1;
 
            }
            catch
            {
                return solan;
            }
            //ConnectDB cn = new ConnectDB();
            //try
            //{
            //    DataTable dk = new DataTable();
            //    dk.Columns.Add("Quantity", typeof(int));
            //    SqlParameter[] param = new SqlParameter[2];

            //    param[0] = new SqlParameter("@ItemCode", SqlDbType.VarChar, 50);
            //    param[0].Value = svitemCode;
            //    param[1] = new SqlParameter("@Servicode", SqlDbType.VarChar, 50);
            //    param[1].Value = severcode;
            //    var render = cn.ExecuteReader(CommandType.StoredProcedure, "pro_Lanthuchien", param);
            //    while (render.Read())
            //    {
            //        DataRow r = dk.NewRow();
            //        r.BeginEdit();
            //        r[0] = render.GetInt32(0);
            //        r.EndEdit();
            //        dk.Rows.Add(r);
            //    }
            //    return dk;

            //}
            //catch (Exception ex)
            //{
            //    return null;
            //}


        }


        public static Int32 Ins(SuggestedServiceReceiptInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[25];
                param[0] = new SqlParameter("@ReceiptID", SqlDbType.Decimal);
                param[0].Value = info.ReceiptID;
                param[1] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[1].Value = info.DepartmentCode;
                param[2] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[2].Value = info.ServiceCode;
                param[3] = new SqlParameter("@ServicePrice", SqlDbType.Decimal);
                param[3].Value = info.ServicePrice;
                param[4] = new SqlParameter("@DisparityPrice", SqlDbType.Decimal);
                param[4].Value = info.DisparityPrice;
                param[5] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[5].Value = info.PatientCode;
                param[6] = new SqlParameter("@Status", SqlDbType.Int);
                param[6].Value = info.Status;
                param[7] = new SqlParameter("@Paid", SqlDbType.Int);
                param[7].Value = info.Paid;
                param[8] = new SqlParameter("@ServicePackageCode", SqlDbType.VarChar, 50);
                param[8].Value = info.ServicePackageCode;
                param[9] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar,50);
                param[9].Value = info.EmployeeCode;
                param[10] = new SqlParameter("@Note", SqlDbType.NVarChar,500);
                param[10].Value = info.Note;
                param[11] = new SqlParameter("@RefID", SqlDbType.Decimal);
                param[11].Value = info.RefID;
                param[12] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[12].Value = info.ObjectCode;
                param[13] = new SqlParameter("@PatientType", SqlDbType.Int);
                param[13].Value = info.PatientType;
                param[14] = new SqlParameter("@WorkDate", SqlDbType.DateTime);
                param[14].Value = info.WorkDate;
                param[15] = new SqlParameter("@DepartmentCodeOrder", SqlDbType.VarChar, 50);
                param[15].Value = info.DepartmentCodeOder;
                param[16] = new SqlParameter("@ReferenceCode", SqlDbType.VarChar, 50);
                param[16].Value = info.ReferenceCode;
                param[17] = new SqlParameter("@EmployeeCodeDoctor", SqlDbType.VarChar, 50);
                param[17].Value = info.EmployeeCodeDoctor;
                param[18] = new SqlParameter("@ShiftWork", SqlDbType.Char, 2);
                param[18].Value = info.ShiftWork;
                param[19] = new SqlParameter("@Quantity", SqlDbType.Int);
                param[19].Value = info.Quantity;
                param[20] = new SqlParameter("@IDAppointment247", SqlDbType.NVarChar,50);
                param[20].Value = info.IDAppointment247;
                param[21] = new SqlParameter("@IDDoctorAppointment247", SqlDbType.NVarChar, 50);
                param[21].Value = info.IDDoctorAppointment247;
                param[22] = new SqlParameter("@NameDoctorAppointment247", SqlDbType.NVarChar, 100);
                param[22].Value = info.NameDoctorAppointment247;
                param[23] = new SqlParameter("@Content", SqlDbType.NVarChar);
                param[23].Value = info.Content;
                param[24] = new SqlParameter("@Check_", SqlDbType.Int);
                param[24].Value = info.Check_;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_SuggestedServiceReceipt", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch(Exception ex)
            { 
                return -2; 
            }
        }
        public static Int32 Ins(SuggestedServiceReceiptInf info,int statusDepartment)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[20];
                param[0] = new SqlParameter("@ReceiptID", SqlDbType.Decimal);
                param[0].Value = info.ReceiptID;
                param[1] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[1].Value = info.DepartmentCode;
                param[2] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[2].Value = info.ServiceCode;
                param[3] = new SqlParameter("@ServicePrice", SqlDbType.Decimal);
                param[3].Value = info.ServicePrice;
                param[4] = new SqlParameter("@DisparityPrice", SqlDbType.Decimal);
                param[4].Value = info.DisparityPrice;
                param[5] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[5].Value = info.PatientCode;
                param[6] = new SqlParameter("@Status", SqlDbType.Int);
                param[6].Value = info.Status;
                param[7] = new SqlParameter("@Paid", SqlDbType.Int);
                param[7].Value = info.Paid;
                param[8] = new SqlParameter("@ServicePackageCode", SqlDbType.VarChar, 50);
                param[8].Value = info.ServicePackageCode;
                param[9] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[9].Value = info.EmployeeCode;
                param[10] = new SqlParameter("@Note", SqlDbType.NVarChar, 500);
                param[10].Value = info.Note;
                param[11] = new SqlParameter("@RefID", SqlDbType.Decimal);
                param[11].Value = info.RefID;
                param[12] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[12].Value = info.ObjectCode;
                param[13] = new SqlParameter("@PatientType", SqlDbType.Int);
                param[13].Value = info.PatientType;
                param[14] = new SqlParameter("@WorkDate", SqlDbType.DateTime);
                param[14].Value = info.WorkDate;
                param[15] = new SqlParameter("@DepartmentCodeOrder", SqlDbType.VarChar, 50);
                param[15].Value = info.DepartmentCodeOder;
                param[16] = new SqlParameter("@ReferenceCode", SqlDbType.VarChar, 50);
                param[16].Value = info.ReferenceCode;
                param[17] = new SqlParameter("@EmployeeCodeDoctor", SqlDbType.VarChar, 50);
                param[17].Value = info.EmployeeCodeDoctor;
                param[18] = new SqlParameter("@ShiftWork", SqlDbType.Char, 2);
                param[18].Value = info.ShiftWork;
                param[19] = new SqlParameter("@StatusDepartment", SqlDbType.Int);
                param[19].Value = statusDepartment;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_SuggestedServiceReceipt", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch
            {
                return -2;
            }
        }
        public static Int32 InsReceive(SuggestedServiceReceiptInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[22];
                param[0] = new SqlParameter("@ReceiptID", SqlDbType.Decimal);
                param[0].Value = info.ReceiptID;
                param[1] = new SqlParameter("@DepartmentCode", SqlDbType.VarChar, 50);
                param[1].Value = info.DepartmentCode;
                param[2] = new SqlParameter("@ServiceCode", SqlDbType.VarChar, 50);
                param[2].Value = info.ServiceCode;
                param[3] = new SqlParameter("@ServicePrice", SqlDbType.Decimal);
                param[3].Value = info.ServicePrice;
                param[4] = new SqlParameter("@DisparityPrice", SqlDbType.Decimal);
                param[4].Value = info.DisparityPrice;
                param[5] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[5].Value = info.PatientCode;
                param[6] = new SqlParameter("@Status", SqlDbType.Int);
                param[6].Value = info.Status;
                param[7] = new SqlParameter("@Paid", SqlDbType.Int);
                param[7].Value = info.Paid;
                param[8] = new SqlParameter("@ServicePackageCode", SqlDbType.VarChar, 50);
                param[8].Value = info.ServicePackageCode;
                param[9] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50);
                param[9].Value = info.EmployeeCode;
                param[10] = new SqlParameter("@Note", SqlDbType.NVarChar, 500);
                param[10].Value = info.Note;
                param[11] = new SqlParameter("@RefID", SqlDbType.Decimal);
                param[11].Value = info.RefID;
                param[12] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[12].Value = info.ObjectCode;
                param[13] = new SqlParameter("@PatientType", SqlDbType.Int);
                param[13].Value = info.PatientType;
                param[14] = new SqlParameter("@WorkDate", SqlDbType.DateTime);
                param[14].Value = info.WorkDate;
                param[15] = new SqlParameter("@DepartmentCodeOrder", SqlDbType.VarChar, 50);
                param[15].Value = info.DepartmentCodeOder;
                param[16] = new SqlParameter("@ReferenceCode", SqlDbType.VarChar, 50);
                param[16].Value = info.ReferenceCode;
                param[17] = new SqlParameter("@ShiftWork", SqlDbType.Char, 2);
                param[17].Value = info.ShiftWork;
                param[18] = new SqlParameter("@Quantity", SqlDbType.Int);
                param[18].Value = info.Quantity;
                param[19] = new SqlParameter("@IDAppointment247", SqlDbType.NVarChar,50);
                param[19].Value = info.IDAppointment247;
                param[20] = new SqlParameter("@IDDoctorAppointment247", SqlDbType.NVarChar, 50);
                param[20].Value = info.IDDoctorAppointment247;
                param[21] = new SqlParameter("@NameDoctorAppointment247", SqlDbType.NVarChar, 100);
                param[21].Value = info.NameDoctorAppointment247;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "proIns_SuggestedReceive", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch
            {
                return -2;
            }
        }

        public static Int32 UpdSuggestedForEmployeeDoctor(decimal receiptID, string employeeCodeDoctor)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "update SuggestedServiceReceipt set EmployeeCodeDoctor=@EmployeeCodeDoctor where ReceiptID=@ReceiptID";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ReceiptID", SqlDbType.Decimal);
                param[0].Value = receiptID;
                param[1] = new SqlParameter("@EmployeeCodeDoctor", SqlDbType.VarChar, 50);
                param[1].Value = employeeCodeDoctor;
                if (cn.ExecuteNonQuery(CommandType.Text, query, param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch
            {
                return -2;
            }
        }
        public static Int32 UpdStatusAppointment(decimal receiptID, int status)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "update SuggestedServiceReceipt set StatusAppointment=@StatusAppointment where ReceiptID=@ReceiptID";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ReceiptID", SqlDbType.Decimal);
                param[0].Value = receiptID;
                param[1] = new SqlParameter("@StatusAppointment", SqlDbType.Bit);
                param[1].Value = status;
                if (cn.ExecuteNonQuery(CommandType.Text, query, param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch
            {
                return -2;
            }
        }
        public static Int32 Del(decimal dId)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@ReceiptID", SqlDbType.Decimal);
                param[1].Value = dId;
                return Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "pro_Del_SuggestedServiceReceipt", param));
            }
            catch { return -3; }
        }

        public static DataTable DT_Danhsachchidinh(decimal refID, string patientCode, string receiptID, string referenceCode, string date, Int32 patientType, string serviceGroupCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string sql = "proView_HandPoint";
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[0].Value = refID;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar);
                param[1].Value = patientCode;
                param[2] = new SqlParameter("@ReferenceCode", SqlDbType.VarChar);
                param[2].Value = referenceCode;
                param[3] = new SqlParameter("@ReceiptID", SqlDbType.VarChar);
                param[3].Value = receiptID;
                param[4] = new SqlParameter("@WorkDate", SqlDbType.Date);
                param[4].Value = date;
                param[5] = new SqlParameter("@PatientType", SqlDbType.Int);
                param[5].Value = patientType;
                param[6] = new SqlParameter("@ServiceGroupCode", SqlDbType.VarChar, 250);
                param[6].Value = serviceGroupCode;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, sql, param);
            }
            catch { tableResult = null; }
            return tableResult;
        }

        public static DataTable DT_ChidinhPK(decimal dRefID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = @" Select a.ServiceCode,d.ServiceName,a.DepartmentCode,c.DepartmentName,a.ReceiptID,a.Status,a.Paid
                                 from SuggestedServiceReceipt a inner join PatientReceive b on a.RefID=b.PatientReceiveID 
                                 inner join Department c on a.DepartmentCode=c.DepartmentCode inner join Service d on a.ServiceCode=d.ServiceCode
                                 where a.Note='TIEPDON' and a.RefID={0} and a.PatientCode='{1}' and a.ServiceCode not in('DV000000') and a.ReceiptID_DisparityPrice=0
                                 ";
                return cn.ExecuteQuery(string.Format(sql, dRefID, sPatientCode));
            }
            catch { return null; }
        }

        public static decimal dTotalService(decimal dRefID, string sPatientCode, ref decimal dDisparity)
        {
            ConnectDB cn = new ConnectDB();
            decimal dTotal = 0;
            try
            {
                string sql = @" select ISNULL(SUM(a.ServicePrice),0) Total,ISNULL(SUM(a.DisparityPrice),0) TotalDisparity
                                from SuggestedServiceReceipt a inner join ServicePrice b on a.RowIDPrice=b.RowID
                                where a.Refid in({0}) and a.PatientCode='{1}'";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dRefID, sPatientCode), null);
                if(ireader.Read())
                {
                    dTotal = ireader.GetDecimal(0);
                    dDisparity = ireader.GetDecimal(1);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return dTotal;
            }
            catch { return 0; }
        }

        public static DataTable DT_TotalServiceForGroup(decimal dRefID, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = @" select SUM(a.ServicePrice) Total, SUM(a.DisparityPrice) TotalDisparity,e.ServiceGroupCode,e.ServiceGroupName
                                from SuggestedServiceReceipt a inner join ServicePrice b on a.RowIDPrice=b.RowID 
                                inner join Service c on a.ServiceCode=c.ServiceCode inner join ServiceCategory d on c.ServiceCategoryCode=d.ServiceCategoryCode
                                inner join ServiceGroup e on d.ServiceGroupCode=e.ServiceGroupCode
                                where a.Refid in({0}) and a.PatientCode='{1}' and a.Paid=0
                                group by e.ServiceGroupCode,e.ServiceGroupName ";
                dt = cn.ExecuteQuery(string.Format(sql, dRefID, sPatientCode));
            }
            catch { }
            return dt;
        }

        public static List<SuggestedViewInf> ListView(string sPatientCode, decimal dReceiveID, Int32 iPaid, string sBankCode, decimal amountBHYTtemp, decimal BHYTUnderPrice)
        {
            ConnectDB cn = new ConnectDB();
            List<SuggestedViewInf> list = new List<SuggestedViewInf>();
            try
            {
                string sql = string.Empty;
                if (iPaid == 1)
                {
                    sql = @"select distinct a.ReceiptID RowID,a.RefID ReceiveID,a.PatientCode,a.ServiceCode,b.ServiceName,a.ServicePrice,a.DisparityPrice,a.Status,a.Paid,a.ObjectCode,c.BanksAccountCode,c.Cancel,d.ServiceGroupCode,(convert(varchar(3),d.STT)+'-'+d.ServiceGroupName) ServiceGroupName, d.STT,e.UnitOfMeasureName,d.ServiceModuleCode,c1.ServicePriceSalesOff, a.Quantity,a.ReceiptID_DisparityPrice
                                from SuggestedServiceReceipt a inner join service b on a.ServiceCode=b.ServiceCode inner join BanksAccount c on a.RefID=c.ReferenceCode and a.BanksAccountCode=c.BanksAccountCode inner join ServiceGroup d on b.ServiceGroupCode=d.ServiceGroupCode inner join UnitOfMeasure e on b.UnitOfMeasureCode=e.UnitOfMeasureCode inner join BanksAccountDetail c1 on c.BanksAccountCode=c1.BanksAccountCode and a.ServiceCode=c1.ServiceCode
                                where a.ObjectCode not in(5) and c.Cancel=0 and a.PatientCode in('{0}') and a.RefID in({1}) and a.paid={2} and a.BanksAccountCode in('{3}') order by d.STT
                            ";
                }
                else
                {
                    sql = @" select a.ReceiptID RowID,a.RefID ReceiveID,a.PatientCode,a.ServiceCode,b.ServiceName,a.ServicePrice,a.DisparityPrice,a.Status,a.Paid,a.ObjectCode,'' as BanksAccountCode, 0 as Cancel,c.ServiceGroupCode,(convert(varchar(3),c.STT)+'-'+c.ServiceGroupName) ServiceGroupName,c.STT,d.UnitOfMeasureName,c.ServiceModuleCode,0 as ServicePriceSalesOff, a.Quantity,a.ReceiptID_DisparityPrice
                                from SuggestedServiceReceipt a inner join service b on a.ServiceCode=b.ServiceCode inner join ServiceGroup c on b.ServiceGroupCode=c.ServiceGroupCode inner join UnitOfMeasure d on b.UnitOfMeasureCode=d.UnitOfMeasureCode
                                where a.ObjectCode not in(5) and a.PatientCode in('{0}') and a.RefID in({1}) and a.paid={2} and (a.DisparityPrice>0 or a.ServicePrice>0) ";
                    sql += " order by c.STT";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, sPatientCode, dReceiveID, iPaid, sBankCode), null);
                while (ireader.Read())
                {
                    SuggestedViewInf inf = new SuggestedViewInf();
                    if (amountBHYTtemp <= BHYTUnderPrice)
                    {
                        if (ireader.GetInt32(9) == 1)
                            inf.Check = 0;
                        else
                            inf.Check = 1;
                    }
                    else
                    {
                        inf.Check = 1;
                    }
                    inf.Check = 1;
                    inf.RowID = ireader.GetDecimal(0);
                    inf.ReceiveID = ireader.GetDecimal(1);
                    inf.PatientCode = ireader.GetString(2);
                    inf.ServiceCode = ireader.GetString(3);
                    inf.ServiceName = ireader.GetString(4);
                    inf.Quantity = 1;
                    inf.ServicePrice = ireader.GetDecimal(5);
                    inf.DisparityPrice = ireader.GetDecimal(6);
                    inf.PatientPay = 0;
                    inf.BHYTPay = 0;
                    inf.Amount = 0;
                    inf.Status = ireader.GetInt32(7);
                    inf.Paid = ireader.GetInt32(8);
                    inf.ObjectCode = ireader.GetInt32(9);
                    inf.BanksAccountCode = ireader.GetValue(10).ToString();
                    inf.Cancel = ireader.GetInt32(11);
                    inf.ServiceGroupCode = ireader.GetValue(12).ToString();
                    inf.ServiceGroupName = ireader.GetValue(13).ToString();
                    inf.UnitOfMeasureName = ireader.GetValue(15).ToString();
                    inf.ServiceModuleCode = ireader.GetValue(16).ToString();
                    inf.ServicePriceSalesOff = Convert.ToDecimal(ireader.GetValue(17));
                    inf.Quantity = Convert.ToInt32(ireader.GetValue(18));
                    inf.PatientPayReal = 0;
                    inf.ReceiptID_DisparityPrice = Convert.ToDecimal(ireader.GetValue(19));
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
        
        public static List<SuggestedViewInf> ListViewForBV01(string patientCode, string receiveID, int done, string reportID, int iPaid)
        {
            ConnectDB cn = new ConnectDB();
            List<SuggestedViewInf> list = new List<SuggestedViewInf>();
            try
            {
                string query = string.Empty;
                if (done.Equals(1))
                {
                    query = @"select 0 RowID, a.PatientReceiveID,a.PatientCode,a.ServiceCode,b.ServiceName,a.ServicePrice,a.DisparityPrice,0 as Status,0 as Paid,a.ObjectCode,'' as BanksAccountCode,0 as Cancel,d.ServiceGroupCode,(convert(varchar(3),d.STT)+'-'+d.ServiceGroupName) ServiceGroupName, d.STT,e.UnitOfMeasureName,d.ServiceModuleCode,a.RowIDPrice, a.Quantity,a.ServiceCode_PK,a.SODKGP from ReportBHYTDetail a inner join service b on a.ServiceCode=b.ServiceCode inner join ServiceGroup d on b.ServiceGroupCode=d.ServiceGroupCode inner join UnitOfMeasure e on b.UnitOfMeasureCode=e.UnitOfMeasureCode where a.ReportID='" + reportID + "'  order by Ordinal ";
                }
                else
                {
                    if(iPaid == 1)
                        query = @" select a.ReceiptID as RowID,a.RefID ReceiveID,a.PatientCode,a.ServiceCode,b.ServiceName,a.ServicePrice,a.DisparityPrice,a.Status,a.Paid,a.ObjectCode,'' as BanksAccountCode, 0 as Cancel,c.ServiceGroupCode,(convert(varchar(3),c.STT)+'-'+c.ServiceGroupName) ServiceGroupName,c.STT,d.UnitOfMeasureName,c.ServiceModuleCode,a.RowIDPrice,a.Quantity,a.ServiceCode_PK,b.MaDK_BHYT ServiceCode_PK,'' as SODKGP  from SuggestedServiceReceipt a inner join service b on a.ServiceCode=b.ServiceCode inner join ServiceGroup c on b.ServiceGroupCode=c.ServiceGroupCode inner join UnitOfMeasure d on b.UnitOfMeasureCode=d.UnitOfMeasureCode where a.PaidBV = 0 and a.ObjectCode not in(5) and a.PatientCode in('" + patientCode + "') and a.RefID in(" + receiveID + ") and a.Paid = 1 ";
                    else
                        query = @" select a.ReceiptID as RowID,a.RefID ReceiveID,a.PatientCode,a.ServiceCode,b.ServiceName,a.ServicePrice,a.DisparityPrice,a.Status,a.Paid,a.ObjectCode,'' as BanksAccountCode, 0 as Cancel,c.ServiceGroupCode,(convert(varchar(3),c.STT)+'-'+c.ServiceGroupName) ServiceGroupName,c.STT,d.UnitOfMeasureName,c.ServiceModuleCode,a.RowIDPrice,a.Quantity,b.MaDK_BHYT ServiceCode_PK,'' as SODKGP from SuggestedServiceReceipt a inner join service b on a.ServiceCode=b.ServiceCode inner join ServiceGroup c on b.ServiceGroupCode=c.ServiceGroupCode inner join UnitOfMeasure d on b.UnitOfMeasureCode=d.UnitOfMeasureCode where a.PaidBV = 0 and a.ObjectCode not in(5) and a.PatientCode in('" + patientCode + "') and a.RefID in(" + receiveID + ") ";
                    query += " order by c.STT";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, query, null);
                while (ireader.Read())
                {
                    SuggestedViewInf inf = new SuggestedViewInf();
                    inf.Check = 1;
                    inf.RowID = Convert.ToDecimal(ireader.GetValue(0).ToString());
                    inf.ReceiveID = ireader.GetDecimal(1);
                    inf.PatientCode = ireader.GetString(2);
                    inf.ServiceCode = ireader.GetString(3);
                    inf.ServiceName = ireader.GetString(4);
                    inf.ServicePrice = ireader.GetDecimal(5);
                    inf.DisparityPrice = ireader.GetDecimal(6);
                    inf.PatientPay = 0;
                    inf.BHYTPay = 0;
                    inf.Amount = 0;
                    inf.Status = ireader.GetInt32(7);
                    inf.Paid = ireader.GetInt32(8);
                    inf.ObjectCode = ireader.GetInt32(9);
                    inf.BanksAccountCode = ireader.GetValue(10).ToString();
                    inf.Cancel = ireader.GetInt32(11);
                    inf.ServiceGroupCode = ireader.GetValue(12).ToString();
                    inf.ServiceGroupName = ireader.GetValue(13).ToString();
                    inf.UnitOfMeasureName = ireader.GetValue(15).ToString();
                    inf.ServiceModuleCode = ireader.GetValue(16).ToString();
                    inf.RowIDPrice = ireader.GetDecimal(17);
                    inf.Quantity = Convert.ToDecimal(ireader.GetValue(18).ToString());
                    inf.ServiceCode_PK = ireader.GetValue(19).ToString();
                    inf.SODKGP = ireader.GetValue(20).ToString();
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

        public static List<SuggestedViewMedicinesInf> ListMedicalView(string patientCode, decimal receiveID, Int32 paid, string bankCode,decimal amountBHYTtemp, decimal BHYTUnderPrice)
        {
            ConnectDB cn = new ConnectDB();
            List<SuggestedViewMedicinesInf> listMedical = new List<SuggestedViewMedicinesInf>();
            try
            {
                string sql = string.Empty;
                if (paid == 0)
                {
                    sql = @" select a.MedicalRecordCode,b.ItemCode,a.Quantity,a.UnitPrice,a.Amount,b.ItemName,b.SalesPrice,b.BHYTPrice,b.RateBHYT,e.UnitOfMeasureName,c.PatientReceiveID,b.RowID RowIDPrice,a.ObjectCode,a1.ObjectName,b.DisparityPrice,b.ListBHYT,c.RowID, 1 as MedicinesType,a.RowID RowIDDetail,0 as ServicePriceSalesOff
                        from MedicinesForPatientsDetail a inner join Items b on a.ItemCode=b.ItemCode inner join Object a1 on a.ObjectCode=a1.ObjectCode
                        inner join MedicinesForPatients c on a.RowIDMedicines=c.RowID inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode inner join UnitOfMeasure e on b.UnitOfMeasureCode=e.UnitOfMeasureCode
                        where c.PatientCode='{0}' and c.PatientReceiveID={1} and a.Paid={2} and a.ObjectCode not in(5) and (a.BanksAccountCode is null or a.BanksAccountCode='')";
                    sql += @"
                        union all
                        select a.RefCode MedicalRecordCode,b.ItemCode,b.Quantity,b.UnitPrice,b.Amount,c.ItemName,b.SalesPrice,b.BHYTPrice,b.RateBHYT,d.UnitOfMeasureName,a.PatientReceiveID,c.RowID RowIDPrice,b.ObjectCode,b1.ObjectName,c.DisparityPrice,c.ListBHYT,a.RowID, 2 as MedicinesType,b.RowID RowIDDetail, 0 as ServicePriceSalesOff
                        from RealMedicinesForPatients a inner join RealMedicinesForPatientsDetail b on a.RowID=b.RealRowID inner join Object b1 on b.ObjectCode=b1.ObjectCode
                        inner join Items c on b.ItemCode = c.ItemCode inner join UnitOfMeasure d on c.UnitOfMeasureCode=d.UnitOfMeasureCode
                        where b.ObjectCode not in(5) and a.PatientCode='{0}' and a.PatientReceiveID={1} and b.Paid={2} and (a.BanksAccountCode is null or a.BanksAccountCode='')
                        ";
                    sql += " order by b.ItemCode ";
                }
                else
                {
                    sql = @" select distinct a.MedicalRecordCode,b.ItemCode,a.Quantity,a.UnitPrice,a.Amount,b.ItemName,b.SalesPrice,b.BHYTPrice,b.RateBHYT,e.UnitOfMeasureName,c.PatientReceiveID,b.RowID RowIDPrice,a.ObjectCode,a1.ObjectName,b.DisparityPrice,b.ListBHYT,c.RowID, 1 as MedicinesType,a.RowID RowIDDetail,a2.ServicePriceSalesOff
                        from MedicinesForPatientsDetail a inner join Items b on a.ItemCode=b.ItemCode  inner join Object a1 on a.ObjectCode=a1.ObjectCode inner join BanksAccountDetail a2 on a.BanksAccountCode=a2.BanksAccountCode and a.ItemCode=a2.ServiceCode
                        inner join MedicinesForPatients c on a.RowIDMedicines=c.RowID inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode inner join UnitOfMeasure e on b.UnitOfMeasureCode=e.UnitOfMeasureCode
                        where c.PatientCode='{0}' and c.PatientReceiveID={1} and a.Paid={2} and a.BanksAccountCode='{3}' and a.ObjectCode not in(5) ";
                    sql += @"
                        union all
                        select a.RefCode MedicalRecordCode,b.ItemCode,b.Quantity,b.UnitPrice,b.Amount,c.ItemName,b.SalesPrice,b.BHYTPrice,b.RateBHYT,d.UnitOfMeasureName,a.PatientReceiveID,c.RowID RowIDPrice,b.ObjectCode,b1.ObjectName,c.DisparityPrice,c.ListBHYT,a.RowID, 2 as MedicinesType,b.RowID RowIDDetail,a2.ServicePriceSalesOff
                        from RealMedicinesForPatients a inner join RealMedicinesForPatientsDetail b on a.RowID=b.RealRowID inner join Object b1 on b.ObjectCode=b1.ObjectCode inner join BanksAccountDetail a2 on b.BanksAccountCode=a2.BanksAccountCode and b.ItemCode=a2.ServiceCode
                        inner join Items c on b.ItemCode = c.ItemCode inner join UnitOfMeasure d on c.UnitOfMeasureCode=d.UnitOfMeasureCode
                        where b.ObjectCode not in(5) and a.PatientCode='{0}' and a.PatientReceiveID={1} and b.Paid={2} and b.BanksAccountCode='{3}'";
                    sql += "  order by b.ItemCode";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, patientCode, receiveID, paid, bankCode), null);
                decimal dAmount = 0, dBHYT = 0, dPatient = 0, dRate = 0;
                while (ireader.Read())
                {
                    SuggestedViewMedicinesInf obj = new SuggestedViewMedicinesInf();
                    obj.MedicalRecordCode = ireader.GetString(0);
                    obj.ItemCode = ireader.GetString(1);
                    obj.Quantity = ireader.GetDecimal(2);
                    obj.UnitPrice = ireader.GetDecimal(3);
                    dAmount = ireader.GetDecimal(4);
                    if (ireader.GetInt32(12).Equals(1))
                        obj.Amount = dAmount + +ireader.GetDecimal(14);
                    obj.Amount = dAmount;
                    obj.ItemName = ireader.GetValue(5).ToString();
                    obj.SalesPrice = ireader.GetDecimal(6);
                    obj.BHYTPrice = ireader.GetDecimal(7);
                    dRate = ireader.GetDecimal(8);
                    obj.RateBHYT = dRate;
                    if (ireader.GetInt32(15).Equals(1) && ireader.GetInt32(12).Equals(1))
                        dBHYT = (dAmount * dRate) / 100;
                    else
                        dBHYT = 0;
                    dPatient = dAmount - dBHYT;
                    obj.BHYTPay = dBHYT;
                    obj.PatientPay = dPatient;
                    obj.UnitOfMeasureName = ireader.GetValue(9).ToString();
                    obj.PatientReceiveID = ireader.GetDecimal(10);
                    obj.RowIDPrice = ireader.GetDecimal(11);
                    obj.ObjectCode = ireader.GetInt32(12);
                    obj.ObjectName = ireader.GetString(13);
                    if (ireader.GetInt32(12).Equals(1))
                        obj.DisparityPrice = ireader.GetDecimal(14);
                    else
                        obj.DisparityPrice = 0;
                    obj.RowID = ireader.GetDecimal(16);
                    if (amountBHYTtemp <= BHYTUnderPrice)
                    {
                        if (ireader.GetInt32(12) == 1)
                            obj.Check = 0;
                        else
                            obj.Check = 1;
                    }
                    else
                    {
                        obj.Check = 1;
                    }
                    obj.Check = 1;
                    obj.MedicinesType = Convert.ToInt32(ireader.GetValue(17));
                    obj.RowIDDetail = ireader.GetDecimal(18);
                    obj.ServicePriceSalesOff = Convert.ToDecimal(ireader.GetValue(19).ToString());
                    listMedical.Add(obj);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { }
            return listMedical;
        }
        
        public static List<SuggestedViewMedicinesBV01Inf> ListMedicalViewForBV01(string patientCode, string receiveID, Int32 done, string reportID)
        {
            ConnectDB cn = new ConnectDB();
            List<SuggestedViewMedicinesBV01Inf> listMedical = new List<SuggestedViewMedicinesBV01Inf>();
            try
            {
                string sql = string.Empty;
                if (done.Equals(0))
                {
                    sql = @" select a.MedicalRecordCode,b.ItemCode,a.Quantity,a.UnitPrice,a.Amount,b.ItemName,b.SalesPrice,b.BHYTPrice,b.RateBHYT,e.UnitOfMeasureName,c.PatientReceiveID,b.RowID RowIDPrice,a.ObjectCode,a1.ObjectName,b.DisparityPrice,b.ListBHYT,c.RowID, 1 as MedicinesType,a.RowID RowIDDetail,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening,a.Instruction,b.Active_TT40 as ItemCode_PK,b.SODKGP
                        from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode inner join Object a1 on a.ObjectCode=a1.ObjectCode
                        inner join MedicalRecord c on a.MedicalRecordCode=c.MedicalRecordCode inner join RepositoryCatalog d on a.RepositoryCode=d.RepositoryCode inner join UnitOfMeasure e on b.UnitOfMeasureCode=e.UnitOfMeasureCode
                        where c.PatientCode='" + patientCode + "' and c.PatientReceiveID in(" + receiveID + ") and a.ObjectCode in(1) and a.BHYT = 1 and a.Status in (1,2) ";
                    sql += @"
                        union all
                        select a.RefCode MedicalRecordCode,b.ItemCode,b.Quantity,b.UnitPrice,b.Amount,c.ItemName,b.SalesPrice,b.BHYTPrice,b.RateBHYT,d.UnitOfMeasureName,a.PatientReceiveID,c.RowID RowIDPrice,b.ObjectCode,b1.ObjectName,c.DisparityPrice,c.ListBHYT,a.RowID, 2 as MedicinesType,b.RowID RowIDDetail,'' DateOfIssues,'' Morning,'' Noon,'' Afternoon,'' Evening,b.Instruction,c.Active_TT40 as ItemCode_PK,c.SODKGP
                        from RealMedicinesForPatients a inner join RealMedicinesForPatientsDetail b on a.RowID=b.RealRowID inner join Object b1 on b.ObjectCode=b1.ObjectCode
                        inner join Items c on b.ItemCode = c.ItemCode inner join UnitOfMeasure d on c.UnitOfMeasureCode=d.UnitOfMeasureCode
                        where b.ObjectCode in(1) and a.PatientCode='" + patientCode + "' and a.PatientReceiveID in(" + receiveID + ") and a.Status in (1,2)";
                    sql += " order by b.ItemCode ";
                }
                else
                {
                    sql = @" select '' as MedicalRecordCode,b.ItemCode,a.Quantity,a.ServicePrice,a.Amount,b.ItemName,b.SalesPrice,b.BHYTPrice,b.RateBHYT,e.UnitOfMeasureName,a.PatientReceiveID,
                            b.RowID RowIDPrice,a.ObjectCode,a1.ObjectName,b.DisparityPrice,b.ListBHYT,a.ReportID, 1 as MedicinesType,0 RowIDDetail,a.DateOfIssues,a.Morning,a.Noon,a.Afternoon,a.Evening,a.Instruction,a.ServiceCode_PK as ItemCode_PK,a.SODKGP
                            from ReportBHYTDetail a inner join Items b on a.ServiceCode=b.ItemCode  inner join Object a1 on a.ObjectCode=a1.ObjectCode
                             inner join UnitOfMeasure e on b.UnitOfMeasureCode=e.UnitOfMeasureCode
                            where a.PatientCode='" + patientCode + "' and a.ReportID='" + reportID + "'";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                decimal dAmount = 0, dBHYT = 0, dPatient = 0, dRate = 0;
                while (ireader.Read())
                {
                    SuggestedViewMedicinesBV01Inf obj = new SuggestedViewMedicinesBV01Inf();
                    obj.MedicalRecordCode = ireader.GetString(0);
                    obj.ItemCode = ireader.GetString(1);
                    obj.Quantity = Convert.ToDecimal(ireader.GetValue(2).ToString());
                    obj.UnitPrice = ireader.GetDecimal(3);
                    dAmount = ireader.GetDecimal(4);
                    if (ireader.GetInt32(12).Equals(1))
                        obj.Amount = dAmount + +ireader.GetDecimal(14);
                    obj.Amount = dAmount;
                    obj.ItemName = ireader.GetValue(5).ToString();
                    obj.SalesPrice = ireader.GetDecimal(6);
                    obj.BHYTPrice = ireader.GetDecimal(7);
                    dRate = ireader.GetDecimal(8);
                    obj.RateBHYT = dRate;
                    if (ireader.GetInt32(15).Equals(1) && ireader.GetInt32(12).Equals(1))
                        dBHYT = (dAmount * dRate) / 100;
                    else
                        dBHYT = 0;
                    dPatient = dAmount - dBHYT;
                    obj.BHYTPay = dBHYT;
                    obj.PatientPay = dPatient;
                    obj.UnitOfMeasureName = ireader.GetValue(9).ToString();
                    obj.PatientReceiveID = ireader.GetDecimal(10);
                    obj.RowIDPrice = ireader.GetDecimal(11);
                    obj.ObjectCode = ireader.GetInt32(12);
                    obj.ObjectName = ireader.GetString(13);
                    //if (ireader.GetInt32(12).Equals(1))
                    //    obj.DisparityPrice = ireader.GetDecimal(14); //// khong lay phu thu len trong kiem duyet bv01
                    //else
                        obj.DisparityPrice = 0;
                    obj.RowID = 0;// ireader.GetDecimal(16);
                    obj.Check = 1;
                    obj.MedicinesType = Convert.ToInt32(ireader.GetValue(17));
                    obj.RowIDDetail = 0;// ireader.GetDecimal(18);
                    obj.DateOfIssues = ireader.GetValue(19).ToString();
                    obj.Morning = ireader.GetValue(20).ToString();
                    obj.Noon = ireader.GetValue(21).ToString();
                    obj.Afternoon = ireader.GetValue(22).ToString();
                    obj.Evening = ireader.GetValue(23).ToString();
                    obj.Instruction = ireader.GetValue(24).ToString();
                    obj.ItemCode_PK = ireader.GetValue(25).ToString();
                    obj.SODKGP = ireader.GetValue(26).ToString();
                    listMedical.Add(obj);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { }
            return listMedical;
        }
        
        public static DataTable DTListServiceGroupDepartmentOrder(decimal dRefId, string sPatientCode, int iPatientType, string sDate, string sDepartmenrCodeOrder)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = @" select a.ReceiptID RowID, a.DepartmentCode,a.ServiceCode,a.ServicePrice,a.DisparityPrice,a.PatientCode,a.Status,a.Paid,a.CreateDate,a.EmployeeCode,a.Note,a.RefID,a.ObjectCode,a.RowIDPrice,a.ServicePackageCode,d.ServiceName, 0 as Del ,a.PatientType,a.WorkDate,c.RowID RowIDPrice,a.ReferenceCode,a.EmployeeCode
                        from SuggestedServiceReceipt a inner join PatientReceive b on a.RefID=b.PatientReceiveID inner join ServicePrice c on a.RowIDPrice=c.RowID inner join [Service] d on c.ServiceCode=d.ServiceCode
                        where a.RefID in ({0}) and a.PatientCode ='{1}' and a.PatientType in({2}) and convert(date,a.WorkDate,103)=convert(date,'{3}',103) and a.DepartmentCodeOrder='{4}'
                        order by a.WorkDate
                         ";
                dt = cn.ExecuteQuery(string.Format(sql, dRefId, sPatientCode, iPatientType, sDate, sDepartmenrCodeOrder));
            }
            catch { dt = null; }
            return dt;
        }

        public static DataTable DTGetServiceOld(decimal dRefId, string sPatientCode, int iPatientType, string snote, string sDate, string sDepartMentCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = @" select a.ReceiptID RowID, a.DepartmentCode,a.ServiceCode,a.ServicePrice,a.DisparityPrice,a.PatientCode,a.Status,a.Paid,a.CreateDate,a.EmployeeCode,a.Note,a.RefID,a.ObjectCode,a.RowIDPrice,a.ServicePackageCode,d.ServiceName, 0 as Del ,a.PatientType,a.WorkDate,c.RowID RowIDPrice,a.ReferenceCode,a.EmployeeCode,d.UnitOfMeasureCode,a.Content,d.Attach_Items
                        from SuggestedServiceReceipt a inner join PatientReceive b on a.RefID=b.PatientReceiveID inner join ServicePrice c on a.RowIDPrice=c.RowID inner join [Service] d on c.ServiceCode=d.ServiceCode 
                        where a.RefID in ({0}) and a.PatientCode ='{1}' and a.PatientType in({2}) and CONVERT(date,a.CreateDate,103)=CONVERT(date,'{3}',103)  and a.DepartmentCodeOrder='{4}'";
                dt = cn.ExecuteQuery(string.Format(sql, dRefId, sPatientCode, iPatientType, sDate, sDepartMentCode));
            }
            catch { dt = null; }
            return dt;
        }

        public static DataTable DTListReceiveIdGroupDepartmentOrder(decimal dRefId, string sPatientCode, int iPatientType, string sDate)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Empty;
                sql = @" select a.DepartmentCodeOrder,b.DepartmentName from SuggestedServiceReceipt a inner join Department b on a.DepartmentCodeOrder=b.DepartmentCode
                        where RefID in ({0}) and PatientCode ='{1}' and PatientType in({2}) and convert(date,WorkDate,103)=convert(date,'{3}',103)
                        group by a.DepartmentCodeOrder,b.DepartmentName
                         ";
                dt = cn.ExecuteQuery(string.Format(sql, dRefId, sPatientCode, iPatientType, sDate));
            }
            catch { dt = null; }
            return dt;
        }

        public static Int32 UpdChangeDepartment(string departmentCode, string patientCode, decimal patientReceiveID, string serviceCode, string serviceCodeNew)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = " update SuggestedServiceReceipt set DepartmentCode='{0}', serviceCode='{4}' where PatientCode='{1}' and RefID={2} and ServiceCode='{3}' and Note='TIEPDON' and Status=0 ";
                if (cn.ExecuteNonQuery(CommandType.Text, string.Format(query, departmentCode, patientCode, patientReceiveID, serviceCode, serviceCodeNew)) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch
            {
                return -2;
            }
        }

        public static DataTable hsba_Suggested(decimal dRefId, string sPatientCode)
        {
            ConnectDB cn = new ConnectDB();
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("ReceiptID", typeof(decimal));
            dtResult.Columns.Add("DepartmentCode", typeof(string));
            dtResult.Columns.Add("ServiceCode", typeof(string));
            dtResult.Columns.Add("ServicePrice", typeof(decimal));
            dtResult.Columns.Add("DisparityPrice", typeof(decimal));
            dtResult.Columns.Add("PatientCode", typeof(string));
            dtResult.Columns.Add("Status", typeof(Int32));
            dtResult.Columns.Add("Paid", typeof(Int32));
            dtResult.Columns.Add("CreateDate", typeof(DateTime));
            dtResult.Columns.Add("ServicePackageCode", typeof(string));
            dtResult.Columns.Add("EmployeeCode", typeof(string));
            dtResult.Columns.Add("Note", typeof(string));
            dtResult.Columns.Add("RefID", typeof(decimal));
            dtResult.Columns.Add("ObjectCode", typeof(Int32));
            dtResult.Columns.Add("RowIDPrice", typeof(decimal));
            dtResult.Columns.Add("PatientType", typeof(Int32));
            dtResult.Columns.Add("WorkDate", typeof(DateTime));
            dtResult.Columns.Add("ReferenceCode", typeof(string));
            dtResult.Columns.Add("BanksAccountCode", typeof(string));
            dtResult.Columns.Add("STT", typeof(Int32));
            dtResult.Columns.Add("DepartmentCodeOrder", typeof(string));
            try
            {
                string sql = string.Empty;
                sql = @" select a.ReceiptID,a.DepartmentCode,a.ServiceCode,a.ServicePrice,a.DisparityPrice,a.PatientCode,a.Status,a.Paid,a.CreateDate,a.ServicePackageCode,a.EmployeeCode,
                        a.Note,a.RefID,a.ObjectCode,a.RowIDPrice,a.PatientType,a.WorkDate,a.ReferenceCode,a.BanksAccountCode,a.STT,a.DepartmentCodeOrder
                        from SuggestedServiceReceipt a where a.RefID=@RefID and a.PatientCode =@PatientCode";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@RefID", SqlDbType.Decimal);
                param[0].Value = dRefId;
                param[1] = new SqlParameter("@PatientCode", SqlDbType.VarChar, 50);
                param[1].Value = sPatientCode;
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, param);
                while (ireader.Read())
                {
                    DataRow dr = dtResult.NewRow();
                    dr[0] = Convert.ToDecimal(ireader[0].ToString());
                    dr[1] = ireader[1].ToString();
                    dr[2] = ireader[2].ToString();
                    dr[3] = Convert.ToDecimal(ireader[3].ToString());
                    dr[4] = Convert.ToDecimal(ireader[4].ToString());
                    dr[5] = ireader[5].ToString();
                    dr[6] = Convert.ToInt32(ireader[6].ToString());
                    dr[7] = Convert.ToInt32(ireader[7].ToString());
                    dr[8] = Convert.ToDateTime(ireader[8].ToString());
                    dr[9] = ireader[9].ToString();
                    dr[10] = ireader[10].ToString();
                    dr[11] = ireader[11].ToString();
                    dr[12] = Convert.ToDecimal(ireader[12].ToString());
                    dr[13] = Convert.ToInt32(ireader[13].ToString());
                    dr[14] = Convert.ToDecimal(ireader[14].ToString());
                    dr[15] = Convert.ToInt32(ireader[15].ToString());
                    dr[16] = Convert.ToDateTime(ireader[16].ToString());
                    dr[17] = ireader[17].ToString();
                    dr[18] = ireader[18].ToString();
                    dr[19] = Convert.ToInt32(ireader[19].ToString());
                    dr[20] = ireader[20].ToString();
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
        public static DataTable CheckTotalBHYT(decimal dPatientReceiveID)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string sql = "pro_CheckTotalBHYT";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@dPatientReceiveID", SqlDbType.Decimal);
                param[0].Value = dPatientReceiveID;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, sql, param);
            }
            catch { tableResult = null; }
            return tableResult;
              
        }
        public static DataTable GetThongKeKhamBenhTheoAppointment247(DateTime fromdate, DateTime todate)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string sql = "pro_ViewThongkeAppointment247";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                param[0].Value = fromdate;
                param[1] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                param[1].Value = todate;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, sql, param);
            }
            catch(Exception)
            {
                tableResult = null;
            }
            return tableResult;
        }
    }

}
