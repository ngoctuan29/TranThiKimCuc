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
    public class CountryBLL
    {
        public static DataTable DTCountry(string sCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("CountryCode", typeof(string)));
                dt.Columns.Add(new DataColumn("CountryName", typeof(string)));
                var vlist = CountryDAL.ListCountry(sCode);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.CountryCode;
                    dr[1] = lt1.CountryName;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch { dt = null; }
            return dt;
        }

        public static List<CountryInf> List(string sCode)
        {
            return CountryDAL.ListCountry(sCode);
        }

        public static int Ins(CountryInf info)
        {
            try
            {
                return CountryDAL.Ins(info);
            }
            catch { return -2; }
        }

        public static int Del(string sCode)
        {
            try
            {
                return CountryDAL.Del(sCode);
            }
            catch { return -2; }
        }

    }
}
