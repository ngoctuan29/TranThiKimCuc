using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class EmployeeInf
    {
        public int RowID { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public Int32 Sex { get; set; }
        public string Mobile { get; set; }
        public string IDCard { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public Int32 PositionCode { get; set; }
        public DateTime CreateDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DepartmentCode { get; set; }
        public Int32 OffWork { get; set; }
        public string PermissionDepart { get; set; }
        public string PermissionRepository { get; set; }
        public Int32 EmployeeGroupID { get; set; }
    }
    public class EmployeeViewInf
    {
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public Int32 PositionCode { get; set; }
    }

    public class EmployeeGroup
    {
        public int EmployeeGroupID { get; set; }
        public string EmployeeGroupName { get; set; }
    }

}
