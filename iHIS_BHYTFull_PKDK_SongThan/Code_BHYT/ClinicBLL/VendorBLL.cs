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
    public class VendorBLL
    {
        public static DataTable DTVendorList(string sVenCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("VendorCode", typeof(string)));
                dt.Columns.Add(new DataColumn("VendorName", typeof(string)));
                dt.Columns.Add(new DataColumn("Salesman", typeof(string)));
                dt.Columns.Add(new DataColumn("Address", typeof(string)));
                dt.Columns.Add(new DataColumn("Phone", typeof(string)));
                dt.Columns.Add(new DataColumn("Email", typeof(string)));
                dt.Columns.Add(new DataColumn("Status", typeof(Int32)));
                dt.Columns.Add(new DataColumn("VendorTaxNo", typeof(string)));
                dt.Columns.Add(new DataColumn("VendorFax", typeof(string)));
                dt.Columns.Add(new DataColumn("VendorBankName", typeof(string)));
                var vlist = VendorDal.ListVendor(sVenCode);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.VendorCode;
                    dr[1] = lt1.VendorName;
                    dr[2] = lt1.Salesman;
                    dr[3] = lt1.Address;
                    dr[4] = lt1.Phone;
                    dr[5] = lt1.Email;
                    dr[6] = lt1.Status;
                    dr[7] = lt1.VendorTaxNo;
                    dr[8] = lt1.VendorFax;
                    dr[9] = lt1.VendorBankName;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch  { dt = null; }
            return dt;
        }

        public static List<VendorInf> ListVendor(string sVenCode)
        {
            return VendorDal.ListVendor(sVenCode);
        }

        public static int InsVendor(VendorInf info)
        {
            try
            {
                return VendorDal.InsVendor(info);
            }
            catch { return -2; }
        }

        public static int DelVendor(string sVenCode)
        {
            try
            {
                return VendorDal.DelVendor(sVenCode);
            }
            catch { return -2; }
        }

    }
}
