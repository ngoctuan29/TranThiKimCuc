using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicLibrary;
using ClinicModel;
using System.Data;
using ClinicDAL;
namespace ClinicBLL
{
    public class DepartmentBLL
    {
        public static DataTable DTDepartment(string sSvGroup)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RowID", typeof(int)));
                dt.Columns.Add(new DataColumn("DepartmentCode", typeof(string)));
                dt.Columns.Add(new DataColumn("DepartmentName", typeof(string)));
                dt.Columns.Add(new DataColumn("ServiceGroupCode", typeof(string)));
                dt.Columns.Add(new DataColumn("Hide", typeof(Int32)));
                dt.Columns.Add(new DataColumn("IdBv", typeof(Int32)));
                dt.Columns.Add(new DataColumn("KBHYT", typeof(string)));
                var vlist = DepartmentDal.ListDepartment(sSvGroup);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.RowID;
                    dr[1] = lt1.DepartmentCode;
                    dr[2] = lt1.DepartmentName;
                    dr[3] = lt1.ServiceGroupCode;
                    dr[4] = lt1.Hide;
                    dr[5] = lt1.IdBv;
                    dr[6] = lt1.KBHYT;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static List<DepartmentInf> ListDepartment(string sgroup)
        {
            return DepartmentDal.ListDepartment(sgroup);
        }

        public static List<DepartmentInf> ListDepartmentForCode(string sCode)
        {
            return DepartmentDal.ListDepartmentForCode(sCode);
        }

        public static List<DepartmentInf> ListDepartment(string sgroup, string sDepartCode)
        {
            return DepartmentDal.ListDepartment(sgroup, sDepartCode);
        }

        public static int InsDepartment(DepartmentInf info)
        {
            return DepartmentDal.InsDepartment(info);
        }

        public static int DelDepartment(string sDepartCode)
        {
            return DepartmentDal.DelDepartment(sDepartCode);
        }

        public static Int32 InsDepartmentForRepository(string sDepartmentCode, string sRepositoryCode, string sEmployeeCode)
        {
            return DepartmentDal.InsDepartmentForRepository(sDepartmentCode, sRepositoryCode, sEmployeeCode);
        }

        public static Int32 DelDepartmentForRepository(string sDepartmentCode)
        {
            return DepartmentDal.DelDepartmentForRepository(sDepartmentCode);
        }

        public static DataTable DT_DepartmentForRepository(string sDepartmentCode)
        {
            return DepartmentDal.DT_DepartmentForRepository(sDepartmentCode);
        }

        public static string sRepositoryCodeForGroup(string sDepartmentCode, Int32 iGroup)
        {
            return DepartmentDal.sRepositoryCodeForGroup(sDepartmentCode, iGroup);
        }
        public static List<DepartmentInf> ListDepartmentFull()
        {
            return DepartmentDal.ListDepartmentFull() ;
        }
        public static DataTable DTDepartmentBHYT()
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("STT", typeof(int)));
                dt.Columns.Add(new DataColumn("TenKhoa", typeof(string)));
                dt.Columns.Add(new DataColumn("MaKhoa", typeof(string)));
                var vlist = DepartmentDal.ListDepartmentBHYT();
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.STT;
                    dr[1] = lt1.TenKhoa;
                    dr[2] = lt1.MaKhoa;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }
        public static DataTable DTLoaiKhoa()
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("Id", typeof(int)));
                dt.Columns.Add(new DataColumn("TenLoai", typeof(string)));
                var vlist = DepartmentDal.ListLoaiKhoa();
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.Id;
                    dr[1] = lt1.TenLoai;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }
    }
}
