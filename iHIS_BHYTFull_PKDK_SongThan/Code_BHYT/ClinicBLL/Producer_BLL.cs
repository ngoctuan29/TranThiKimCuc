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
    public class Producer_BLL
    {
        public static DataTable DTProducer(string sCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn("ProducerCode", typeof(string)));
                dt.Columns.Add(new DataColumn("ProducerName", typeof(string)));
                dt.Columns.Add(new DataColumn("Hide", typeof(Int32)));
                var vlist = Producer_DAL.ListProducer(sCode);
                foreach (var lt1 in vlist)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.BeginEdit();
                    dr[0] = lt1.ProducerCode;
                    dr[1] = lt1.ProducerName;
                    dr[2] = lt1.Hide;
                    dr.EndEdit();
                    dt.Rows.Add(dr);
                }
            }
            catch  { dt = null; }
            return dt;
        }

        public static List<Producer_INF> List(string sCode)
        {
            return Producer_DAL.ListProducer(sCode);
        }

        public static int Ins(Producer_INF info)
        {
            try
            {
                return Producer_DAL.Ins(info);
            }
            catch { return -2; }
        }

        public static int Del(string sCode)
        {
            try
            {
                return Producer_DAL.Del(sCode);
            }
            catch { return -2; }
        }

    }
}
