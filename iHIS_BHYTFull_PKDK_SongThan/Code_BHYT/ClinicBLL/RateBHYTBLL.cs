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
    public class RateBHYTBLL
    {
        public static List<RateBHYTInf> ListRateBHYT()
        {
            return RateBHYTDal.ListRateBHYT();
        }

        public static RateBHYTInf objectRateBHYT(string sRateCard)
        {
            return RateBHYTDal.objectRateBHYT(sRateCard);
        }

        public static DataTable DT_ListRateBHYT()
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("RateCard", typeof(string)));
                dt.Columns.Add(new DataColumn("RateTrue", typeof(int)));
                dt.Columns.Add(new DataColumn("RateFalse", typeof(int)));
                var vlist = RateBHYTDal.ListRateBHYT();
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.RateCard;
                    dr[1] = lt1.RateTrue;
                    dr[2] = lt1.RateFalse;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch  { dt = null; }
            return dt;
        }

        public static int InsRate(RateBHYTInf info)
        {
            return RateBHYTDal.InsRate(info);
        }

        public static int DelRate(string rateCard)
        {
            return RateBHYTDal.DelRate(rateCard);
        }

    }
}
