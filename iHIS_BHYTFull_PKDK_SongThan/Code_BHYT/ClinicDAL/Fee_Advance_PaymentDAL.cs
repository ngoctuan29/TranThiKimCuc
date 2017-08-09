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
    public class Fee_Advance_PaymentDAL
    {
        public static List<Fee_Advance_PaymentInf> ListAdvance_PaymentForRowID(decimal patientReceiveID, string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<Fee_Advance_PaymentInf> list = new List<Fee_Advance_PaymentInf>();
            try
            {
                string sql = "select RowID,PatientReceiveID,PatientCode,WorkingDateOrder,AmountOrder,EmployeeCodeOrder,DepartmentCodeOrder,ObjectCode,Done,Paid,EmployeeCode,AmountReal,WorkingDate,RowIDNoteBook,EmployeeCodeRePaid,WorkingDateRePaid,ReceiptNumber,NoteRePaid,BanksAccountCode from Fee_Advance_Payment where PatientReceiveID={0} and PatientCode='{1}' ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, patientReceiveID, patientCode), null);
                while (ireader.Read())
                {
                    Fee_Advance_PaymentInf inf = new Fee_Advance_PaymentInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.PatientReceiveID = Convert.ToDecimal(ireader.GetValue(1));
                    inf.PatientCode = ireader.GetValue(2).ToString();
                    inf.WorkingDateOrder = ireader.GetValue(3).ToString();
                    inf.AmountOrder = Convert.ToDecimal(ireader.GetValue(4));
                    inf.EmployeeCodeOrder = ireader.GetValue(5).ToString();
                    inf.DepartmentCodeOrder = ireader.GetValue(6).ToString();
                    inf.ObjectCode = ireader.GetInt32(7);
                    inf.Done = Convert.ToInt32(ireader.GetValue(8));
                    inf.Paid = Convert.ToInt32(ireader.GetValue(9));
                    inf.EmployeeCode = ireader.GetValue(10).ToString();
                    inf.AmountReal = ireader.GetDecimal(11);
                    inf.WorkingDate = ireader.GetValue(12).ToString();
                    inf.RowIDNoteBook = ireader.GetInt32(13);
                    inf.EmployeeCodeRePaid = ireader.GetValue(14).ToString();
                    inf.WorkingDateRePaid = ireader.GetValue(15).ToString();
                    inf.ReceiptNumber = ireader.GetInt32(16);
                    inf.NoteRePaid = ireader.GetValue(17).ToString();
                    inf.BanksAccountCode = ireader.GetValue(18).ToString();
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
        public static List<Fee_Advance_PaymentViewInf> ListAdvance_PaymentWaiting(string fromdate, string todate)
        {
            ConnectDB cn = new ConnectDB();
            List<Fee_Advance_PaymentViewInf> list = new List<Fee_Advance_PaymentViewInf>();
            try
            {
                string query = @"  select a.PatientReceiveID,a.PatientCode,convert(date,a.CreateDate,103) WorkingDateOrder,a.ObjectCode,c.ObjectName,b.PatientName,b.PatientBirthyear,b.PatientGender,count(*) Quantity
                from PatientReceive a inner
                join Patients b on a.PatientCode = b.PatientCode inner
                join Object c on a.ObjectCode = c.ObjectCode
                left join (select distinct PatientReceiveID,ReceiptNumber from Fee_Advance_Payment where convert(date, WorkingDateOrder, 103) between convert(date,'{0}', 103) and convert(date,'{1}', 103) group by PatientReceiveID,ReceiptNumber) d on a.PatientReceiveID = d.PatientReceiveID
                where a.Status <> 2 and convert(date, a.CreateDate,103) between convert(date,'{0}', 103) and convert(date,'{1}', 103) group by a.PatientReceiveID,a.PatientCode,convert(date,a.CreateDate,103),a.ObjectCode,c.ObjectName,b.PatientName,b.PatientBirthyear,b.PatientGender order by a.PatientCode";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(query, fromdate, todate), null);
                while (ireader.Read())
                {
                    Fee_Advance_PaymentViewInf inf = new Fee_Advance_PaymentViewInf();
                    inf.PatientReceiveID = Convert.ToDecimal(ireader.GetValue(0));
                    inf.PatientCode = ireader.GetValue(1).ToString();
                    inf.WorkingDateOrder = ireader.GetValue(2).ToString();
                    inf.ObjectCode = ireader.GetInt32(3);
                    inf.ObjectName = ireader.GetValue(4).ToString();
                    inf.PatientName = ireader.GetValue(5).ToString();
                    inf.PatientBirthyear = ireader.GetInt32(6);
                    inf.GenderName = ireader.GetInt32(7) == 0 ? "Nữ" : "Nam";
                    inf.Quantity = Convert.ToInt32(ireader.GetValue(8));
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
        public static List<Fee_Advance_PaymentViewDetailInf> ListAdvance_PaymentDetail(decimal patientReceiveID, string patientCode)
        {
            ConnectDB cn = new ConnectDB();
            List<Fee_Advance_PaymentViewDetailInf> list = new List<Fee_Advance_PaymentViewDetailInf>();
            try
            {
                string sql = "select RowID,PatientReceiveID,PatientCode,WorkingDateOrder,AmountOrder,EmployeeCodeOrder,DepartmentCodeOrder,ObjectCode,Done,Paid,EmployeeCode,AmountReal,WorkingDate,RowIDNoteBook,EmployeeCodeRePaid,WorkingDateRePaid,ReceiptNumber,NoteRePaid,BanksAccountCode,0 as [Check] from Fee_Advance_Payment where PatientReceiveID={0} and PatientCode='{1}' ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, patientReceiveID, patientCode), null);
                while (ireader.Read())
                {
                    Fee_Advance_PaymentViewDetailInf inf = new Fee_Advance_PaymentViewDetailInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.PatientReceiveID = Convert.ToDecimal(ireader.GetValue(1));
                    inf.PatientCode = ireader.GetValue(2).ToString();
                    inf.WorkingDateOrder = ireader.GetValue(3).ToString();
                    inf.AmountOrder = Convert.ToDecimal(ireader.GetValue(4));
                    inf.EmployeeCodeOrder = ireader.GetValue(5).ToString();
                    inf.DepartmentCodeOrder = ireader.GetValue(6).ToString();
                    inf.ObjectCode = ireader.GetInt32(7);
                    inf.Done = Convert.ToInt32(ireader.GetValue(8));
                    inf.Paid = Convert.ToInt32(ireader.GetValue(9));
                    inf.EmployeeCode = ireader.GetValue(10).ToString();
                    inf.AmountReal = ireader.GetDecimal(11);
                    inf.WorkingDate = ireader.GetValue(12).ToString();
                    inf.RowIDNoteBook = ireader.GetInt32(13);
                    inf.EmployeeCodeRePaid = ireader.GetValue(14).ToString();
                    inf.WorkingDateRePaid = ireader.GetValue(15).ToString();
                    inf.ReceiptNumber = ireader.GetInt32(16);
                    inf.NoteRePaid = ireader.GetValue(17).ToString();
                    inf.BanksAccountCode = ireader.GetValue(18).ToString();
                    inf.Check = ireader.GetInt32(19);
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
        public static DataTable TableAdvance_PaymentDetail(decimal patientReceiveID, string patientCode, int receiptNumber, string postingDate)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string sql = "select 1 as [Check], RowID,PatientReceiveID,PatientCode,WorkingDateOrder,AmountOrder,EmployeeCodeOrder,DepartmentCodeOrder,ObjectCode,Done,Paid,EmployeeCode,AmountReal,WorkingDate,RowIDNoteBook,EmployeeCodeRePaid,WorkingDateRePaid,ReceiptNumber,NoteRePaid,BanksAccountCode from Fee_Advance_Payment where PatientReceiveID={0} and PatientCode='{1}' and ReceiptNumber={2} and Convert(date,WorkingDate,103)=Convert(date,'{3}',103) ";
                tableResult = cn.ExecuteQuery(string.Format(sql, patientReceiveID, patientCode, receiptNumber, postingDate));
            }
            catch { tableResult = null; }
            return tableResult;
        }
        public static DataTable TableAdvance_PaymentDetail(decimal patientReceiveID, string patientCode, int paid, int done)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string sql = "select 1 as [Check], RowID,PatientReceiveID,PatientCode,WorkingDateOrder,AmountOrder,EmployeeCodeOrder,DepartmentCodeOrder,ObjectCode,Done,Paid,EmployeeCode,AmountReal,WorkingDate,RowIDNoteBook,EmployeeCodeRePaid,WorkingDateRePaid,ReceiptNumber,NoteRePaid,BanksAccountCode from Fee_Advance_Payment where PatientReceiveID={0} and PatientCode='{1}' and Paid={2} and Done={3} ";
                tableResult = cn.ExecuteQuery(string.Format(sql, patientReceiveID, patientCode, paid, done));
            }
            catch { tableResult = null; }
            return tableResult;
        }
        public static DataTable TableAdvance_PaymentPrint(decimal patientReceiveID, string patientCode, int receiptNumber, string postingDate, int rowIDNoteBook)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string sql = "proPrintFee_AdvancePayment";
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar);
                param[0].Value = patientCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = patientReceiveID;
                param[2] = new SqlParameter("@WorkingDate", SqlDbType.Char);
                param[2].Value = postingDate;
                param[3] = new SqlParameter("@RowIDNoteBook", SqlDbType.Int);
                param[3].Value = rowIDNoteBook;
                param[4] = new SqlParameter("@ReceiptNumber", SqlDbType.Int);
                param[4].Value = receiptNumber;
                tableResult = cn.CallProcedureTable(CommandType.StoredProcedure, sql, param);
            }
            catch { tableResult = null; }
            return tableResult;
        }
        public static DataTable TableAdvance_PaymentForSearchFinish(string frmDate, string toDate, string paid)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string sql = @" select a.PatientReceiveID,a.PatientCode,a2.PatientName,a2.PatientBirthyear,CONVERT(char(10),a.WorkingDate,103) WorkingDate,SUM(a.AmountReal) AmountReal,a1.EmployeeName,a.ReceiptNumber,b.EmployeeName EmployeeNameRepaid,CONVERT(char(10),a.WorkingDateRePaid,103) WorkingDateRePaid,a.NoteRePaid,a3.NoteBookName,a.EmployeeCode,a.Paid
                 from Fee_Advance_Payment a inner join Employee a1 on a.EmployeeCode=a1.EmployeeCode
                 left join Employee b on a.EmployeeCodeRePaid=b.EmployeeCode inner join Patients a2 on a.PatientCode=a2.PatientCode inner join Fee_NoteBook a3 on a.RowIDNoteBook=a3.RowID
                where convert(date, a.WorkingDate,103) between convert(date,'{0}', 103) and convert(date,'{1}', 103) and a.Paid in({2})
                 group by a.PatientReceiveID,a.PatientCode,a2.PatientName,a2.PatientBirthyear,CONVERT(char(10),a.WorkingDate,103),a1.EmployeeName,a.ReceiptNumber,b.EmployeeName,CONVERT(char(10),a.WorkingDateRePaid,103),a.NoteRePaid,a3.NoteBookName,a.EmployeeCode,a.Paid ";
                tableResult = cn.ExecuteQuery(string.Format(sql, frmDate, toDate, paid));
            }
            catch { tableResult = null; }
            return tableResult;
        }
        public static bool InsFee_AdvancePayment(Fee_Advance_PaymentViewDetailInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[19];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = info.PatientReceiveID;
                param[2] = new SqlParameter("@PatientCode", SqlDbType.VarChar);
                param[2].Value = info.PatientCode;
                param[3] = new SqlParameter("@WorkingDateOrder", SqlDbType.VarChar);
                param[3].Value = info.WorkingDateOrder;
                param[4] = new SqlParameter("@AmountOrder", SqlDbType.Decimal);
                param[4].Value = info.AmountOrder;
                param[5] = new SqlParameter("@EmployeeCodeOrder", SqlDbType.VarChar);
                param[5].Value = info.EmployeeCodeOrder;
                param[6] = new SqlParameter("@DepartmentCodeOrder", SqlDbType.VarChar);
                param[6].Value = info.DepartmentCodeOrder;
                param[7] = new SqlParameter("@ObjectCode", SqlDbType.Int);
                param[7].Value = info.ObjectCode;
                param[8] = new SqlParameter("@Done", SqlDbType.SmallInt);
                param[8].Value = info.Done;
                param[9] = new SqlParameter("@Paid", SqlDbType.SmallInt);
                param[9].Value = info.Paid;
                param[10] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar);
                param[10].Value = info.EmployeeCode;
                param[11] = new SqlParameter("@AmountReal", SqlDbType.Decimal);
                param[11].Value = info.AmountReal;
                param[12] = new SqlParameter("@WorkingDate", SqlDbType.VarChar);
                param[12].Value = info.WorkingDate;
                param[13] = new SqlParameter("@RowIDNoteBook", SqlDbType.Int);
                param[13].Value = info.RowIDNoteBook;
                param[14] = new SqlParameter("@EmployeeCodeRePaid", SqlDbType.VarChar);
                param[14].Value = info.EmployeeCodeRePaid;
                param[15] = new SqlParameter("@WorkingDateRePaid", SqlDbType.VarChar);
                param[15].Value = info.WorkingDateRePaid;
                param[16] = new SqlParameter("@ReceiptNumber", SqlDbType.Int);
                param[16].Value = info.ReceiptNumber;
                param[17] = new SqlParameter("@NoteRePaid", SqlDbType.NVarChar);
                param[17].Value = info.NoteRePaid;
                param[18] = new SqlParameter("@BanksAccountCode", SqlDbType.VarChar);
                param[18].Value = info.BanksAccountCode;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "proIUFee_Advance_Payment", param) > 0 ? true : false;
            }
            catch { return false; }
        }
        public static Int32 UpdCancelFee_AdvancePayment(decimal rowID, decimal patientReceiveID, int done, int paid, string employeeCodeRePaid, string workingDateRePaid, string noteRePaid)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = rowID;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = patientReceiveID;
                param[2] = new SqlParameter("@Done", SqlDbType.SmallInt);
                param[2].Value = done;
                param[3] = new SqlParameter("@Paid", SqlDbType.SmallInt);
                param[3].Value = paid;
                param[4] = new SqlParameter("@EmployeeCodeRePaid", SqlDbType.VarChar);
                param[4].Value = employeeCodeRePaid;
                param[5] = new SqlParameter("@WorkingDateRePaid", SqlDbType.VarChar);
                param[5].Value = workingDateRePaid;
                param[6] = new SqlParameter("@NoteRePaid", SqlDbType.NVarChar);
                param[6].Value = noteRePaid;
                param[7] = new SqlParameter("@IsResult", SqlDbType.SmallInt);
                param[7].Direction = ParameterDirection.Output;
                int result = Convert.ToInt32(cn.ExecuteReaderProcedure(CommandType.StoredProcedure, "proUpdCancel_AdvancePayment", param));
                return result;
            }
            catch { return -2; }
        }
        public static Int32 UpdPaidFee_AdvancePayment(decimal rowID, decimal patientReceiveID, string bankAccountCode, int paid, bool isCancel, string employeeCodeRePaid, string workingDateRePaid)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = " update Fee_Advance_Payment set BanksAccountCode=@BanksAccountCode,Paid=@Paid,EmployeeCodeRePaid=@EmployeeCodeRePaid,WorkingDateRePaid=@WorkingDateRePaid where PatientReceiveID=@PatientReceiveID and RowID=@RowID and Paid=0";
                if (isCancel)
                    query = "  update Fee_Advance_Payment set BanksAccountCode=@BanksAccountCode,Paid=@Paid where PatientReceiveID=@PatientReceiveID,EmployeeCodeRePaid=@EmployeeCodeRePaid,WorkingDateRePaid=@WorkingDateRePaid and RowID=@RowID and Paid=1 ";
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@BanksAccountCode", SqlDbType.VarChar);
                param[0].Value = bankAccountCode;
                param[1] = new SqlParameter("@Paid", SqlDbType.SmallInt);
                param[1].Value = paid;
                param[2] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[2].Value = patientReceiveID;
                param[3] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[3].Value = rowID;
                param[4] = new SqlParameter("@EmployeeCodeRePaid", SqlDbType.VarChar);
                param[4].Value = employeeCodeRePaid;
                param[5] = new SqlParameter("@WorkingDateRePaid", SqlDbType.VarChar);
                param[5].Value = workingDateRePaid;
                int result = cn.ExecuteNonQuery(CommandType.Text, query, param);
                return result;
            }
            catch { return -2; }
        }
        public static Int32 UpdCountsFee_AdvancePayment(decimal patientReceiveID, string patientCode, int receiptNumber)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string query = "proUpdCountsFee_AdvancePayment";
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@PatientCode", SqlDbType.VarChar);
                param[0].Value = patientCode;
                param[1] = new SqlParameter("@PatientReceiveID", SqlDbType.Decimal);
                param[1].Value = patientReceiveID;
                param[2] = new SqlParameter("@ReceiptNumber", SqlDbType.Int);
                param[2].Value = receiptNumber;
                int result = cn.ExecuteNonQuery(CommandType.StoredProcedure, query, param);
                return result;
            }
            catch { return -2; }
        }
        public static DataTable TableAdvance_PaymentViewReport(string dtimeFrom, string dtimeTo, int paid)
        {
            ConnectDB cn = new ConnectDB();
            DataTable tableResult = new DataTable();
            try
            {
                string sql = @" select a.PatientCode,a1.PatientName,(case a1.PatientGender when 0 then N'Nữ' else 'Nam' end) PatientGenderName,a1.PatientBirthyear,a.ReceiptNumber,a2.NoteBookName,a3.EmployeeName,sum(a.AmountReal) AmountReal
                    from Fee_Advance_Payment a inner join Patients a1 on a.PatientCode=a1.PatientCode inner join Fee_NoteBook a2 on a.RowIDNoteBook=a2.RowID inner join Employee a3 on a.EmployeeCode=a3.EmployeeCode
                    where CONVERT(date,a.WorkingDate,103) between CONVERT(date,'{0}',103) and CONVERT(date,'{1}',103)";
                if (paid.Equals(-1))
                    sql += " and a.Paid =-1 ";
                else
                    sql += " and a.Paid in(0,1) ";
                sql += " group by a.PatientCode,a1.PatientName,a1.PatientGender,a1.PatientBirthyear,a.ReceiptNumber,a2.NoteBookName,a3.EmployeeName ";
                tableResult = cn.CallProcedureTable(CommandType.Text, string.Format(sql, dtimeFrom, dtimeTo, paid), null);
            }
            catch { tableResult = null; }
            return tableResult;
        }
        public static List<Fee_Advance_PaymentView> Report_Fee_Advance_Payment(string datefrom, string dateto,string ListEmployeeOrder,string listObject)
        {
            ConnectDB cn = new ConnectDB();
            List<Fee_Advance_PaymentView> lst = new List<Fee_Advance_PaymentView>();
            try
            {

                string sql = @"select p.PatientCode,p.PatientName,ob.ObjectName,a.AmountReal,a.[Counts],(case a.Paid when 1 then N'Đã hoàn trả' else N'Chưa hoàn trả' end) status,a.WorkingDateOrder,a.EmployeeCodeOrder,a.WorkingDateRePaid,a.EmployeeCodeRePaid
                from Fee_Advance_Payment a 
                inner join Patients  p on a.PatientCode =p.PatientCode
                inner join [Object] ob on a.ObjectCode =ob.ObjectCode
                where  1 = 1";
                if (!string.IsNullOrWhiteSpace(ListEmployeeOrder))
                    sql += " and a.EmployeeCodeOrder in(" + ListEmployeeOrder + ")";
                if (datefrom != string.Empty && dateto != string.Empty)
                    sql += " and CONVERT(date,a.WorkingDateOrder,103) between CONVERT(date,'" + datefrom + "',103) and CONVERT(date,'" + dateto + "',103) ";
                if (!string.IsNullOrWhiteSpace(listObject))
                    sql += " and a.ObjectCode in(" + listObject + ")";
                
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                while (ireader.Read())
                {
                    Fee_Advance_PaymentView inf = new Fee_Advance_PaymentView();
                    inf.PatientCode = ireader.GetValue(0).ToString();
                    inf.PatientName = ireader.GetValue(1).ToString();
                    inf.ObjectName = ireader.GetValue(2).ToString();
                    inf.AmountReal = ireader.GetDecimal(3);
                    inf.Counts = ireader.GetInt32(4);
                    inf.Status = ireader.GetValue(5).ToString();
                    inf.WorkingDateOrder = ireader.GetValue(6).ToString();
                    inf.EmployeeCodeOrder = ireader.GetValue(7).ToString();
                    inf.WorkingDateRePaid = ireader.GetValue(8).ToString();
                    inf.EmployeeCodeRePaid = ireader.GetValue(9).ToString();

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
        public static DataSet DatasetRpt_FeePayment(string dtimeFrom, string dtimeTo, int paid, string employeeCode, string objectCode, string type)
        {
            ConnectDB cn = new ConnectDB();
            DataSet dsResult = new DataSet();
            try
            {
                string query = "proRpt_AdvancePayment";
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@FromDate", SqlDbType.Char);
                param[0].Value = dtimeFrom;
                param[1] = new SqlParameter("@ToDate", SqlDbType.Char);
                param[1].Value = dtimeTo;
                param[2] = new SqlParameter("@Paid", SqlDbType.Int);
                param[2].Value = paid;
                param[3] = new SqlParameter("@EmployeeCode", SqlDbType.VarChar);
                param[3].Value = employeeCode;
                param[4] = new SqlParameter("@ObjectCode", SqlDbType.VarChar);
                param[4].Value = objectCode;
                param[5] = new SqlParameter("@Type", SqlDbType.VarChar);
                param[5].Value = type;
                dsResult = cn.CallProcedure(CommandType.StoredProcedure, query, param);
            }
            catch(Exception ex) { dsResult = null; }
            return dsResult;
        }
    }
}
