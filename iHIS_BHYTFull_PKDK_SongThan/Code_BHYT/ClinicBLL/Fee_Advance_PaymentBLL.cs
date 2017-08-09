using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using ClinicModel;
using ClinicLibrary;
using ClinicDAL;

namespace ClinicBLL
{
    public class Fee_Advance_PaymentBLL
    {
        public static List<Fee_Advance_PaymentView> Report_Fee_Advance_Payment(string datefrom, string dateto, string ListEmployeeOrder, string listObject)
        {
            return Fee_Advance_PaymentDAL.Report_Fee_Advance_Payment(datefrom, dateto, ListEmployeeOrder, listObject);
        }
        public static List<Fee_Advance_PaymentInf> ListAdvance_PaymentForRowID(decimal patientReceiveID, string patientCode)
        {
            return Fee_Advance_PaymentDAL.ListAdvance_PaymentForRowID(patientReceiveID, patientCode);
        }
        public static List<Fee_Advance_PaymentViewInf> ListAdvance_PaymentWaiting(string fromdate, string todate)
        {
            return Fee_Advance_PaymentDAL.ListAdvance_PaymentWaiting(fromdate, todate);
        }
        public static List<Fee_Advance_PaymentViewDetailInf> ListAdvance_PaymentDetail(decimal patientReceiveID, string patientCode)
        {
            return Fee_Advance_PaymentDAL.ListAdvance_PaymentDetail(patientReceiveID, patientCode);
        }
        public static DataTable TableAdvance_PaymentForSearchFinish(string frmDate, string toDate, string paid)
        {
            return Fee_Advance_PaymentDAL.TableAdvance_PaymentForSearchFinish(frmDate, toDate, paid);
        }
        public static DataTable TableAdvance_PaymentDetail(decimal patientReceiveID, string patientCode, int receiptNumber, string postingDate)
        {
            return Fee_Advance_PaymentDAL.TableAdvance_PaymentDetail(patientReceiveID, patientCode, receiptNumber, postingDate);
        }
        public static DataTable TableAdvance_PaymentDetail(decimal patientReceiveID, string patientCode, int paid, int done)
        {
            return Fee_Advance_PaymentDAL.TableAdvance_PaymentDetail(patientReceiveID, patientCode, paid, done);
        }
        public static DataTable TableAdvance_PaymentPrint(decimal patientReceiveID, string patientCode, int receiptNumber, string postingDate, int rowIDNoteBook)
        {
            return Fee_Advance_PaymentDAL.TableAdvance_PaymentPrint(patientReceiveID, patientCode, receiptNumber, postingDate, rowIDNoteBook);
        }
        public static bool InsFee_AdvancePayment(Fee_Advance_PaymentViewDetailInf info)
        {
            return Fee_Advance_PaymentDAL.InsFee_AdvancePayment(info);
        }
        public static Int32 UpdCancelFee_AdvancePayment(decimal rowID, decimal patientReceiveID, int done, int paid, string employeeCodeRePaid, string workingDateRePaid, string noteRePaid)
        {
            return Fee_Advance_PaymentDAL.UpdCancelFee_AdvancePayment(rowID, patientReceiveID, done, paid, employeeCodeRePaid, workingDateRePaid, noteRePaid);
        }
        public static Int32 UpdPaidFee_AdvancePayment(decimal rowID, decimal patientReceiveID, string banksAccountCode, int paid, bool isCancel, string employeeCodeRePaid, string workingDateRePaid)
        {
            return Fee_Advance_PaymentDAL.UpdPaidFee_AdvancePayment(rowID, patientReceiveID, banksAccountCode, paid, isCancel, employeeCodeRePaid, workingDateRePaid);
        }
        public static Int32 UpdCountsFee_AdvancePayment(decimal patientReceiveID, string patientCode, int receiptNumber)
        {
            return Fee_Advance_PaymentDAL.UpdCountsFee_AdvancePayment(patientReceiveID, patientCode, receiptNumber);
        }
        public static DataTable TableAdvance_PaymentViewReport(string dtimeFrom, string dtimeTo, int paid)
        {
            return Fee_Advance_PaymentDAL.TableAdvance_PaymentViewReport(dtimeFrom, dtimeTo, paid);
        }

        public static DataSet DatasetRpt_FeePayment(string dtimeFrom, string dtimeTo, int paid, string employeeCode, string objectCode, string type)
        {
            return Fee_Advance_PaymentDAL.DatasetRpt_FeePayment(dtimeFrom, dtimeTo, paid, employeeCode, objectCode, type);
        }
    }
}
