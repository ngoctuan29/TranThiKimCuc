using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class Fee_Advance_PaymentInf
    {
        public decimal RowID { get; set; }
        public decimal PatientReceiveID { get; set; }
        public string PatientCode { get; set; }
        public string WorkingDateOrder { get; set; }
        public decimal AmountOrder { get; set; }
        public string EmployeeCodeOrder { get; set; }
        public string DepartmentCodeOrder { get; set; }
        public int ObjectCode { get; set; }
        public int Done { get; set; }
        public int Paid { get; set; }
        public string EmployeeCode { get; set; }
        public decimal AmountReal { get; set; }
        public string WorkingDate { get; set; }
        public int RowIDNoteBook { get; set; }
        public string EmployeeCodeRePaid { get; set; }
        public string WorkingDateRePaid { get; set; }
        public int ReceiptNumber { get; set; }
        public string NoteRePaid { get; set; }
        public string BanksAccountCode { get; set; }
    }
    public class Fee_Advance_PaymentView
    {

        public string PatientName { get; set; }
        public string PatientCode { get; set; }
        public string WorkingDateOrder { get; set; }
        public string EmployeeCodeOrder { get; set; }
        public string ObjectName { get; set; }
        public string Status { get; set; }
        public decimal AmountReal { get; set; }
        public string EmployeeCodeRePaid { get; set; }
        public string WorkingDateRePaid { get; set; }
        public int Counts { get; set; }
        
    }
    public class Fee_Advance_PaymentViewInf
    {
        public decimal PatientReceiveID { get; set; }
        public string PatientName { get; set; }
        public string PatientCode { get; set; }
        public string GenderName { get; set; }
        public int PatientBirthyear { get; set; }
        public int ObjectCode { get; set; }
        public string ObjectName { get; set; }
        public string WorkingDateOrder { get; set; }
        public Int32 Quantity { get; set; }
    }

    public class Fee_Advance_PaymentViewDetailInf: Fee_Advance_PaymentInf
    {
        public int Check { get; set; }
        public int Counts { get; set; }
    }
}
