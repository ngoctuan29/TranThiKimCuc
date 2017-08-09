using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using Ps.Clinic.Models;

namespace Ps.Clinic.Library
{
    public class Utility
    {
        //MasterDataContext db = new MasterDataContext();
        //public string SetupSerialNumber(int _Year, string _Prefix)
        //{
        //    var query = from p in db.Setup_Serial_Numbers where p.Year == _Year && p.Prefix == _Prefix select new { Identity = p.Identity, Prefix = p.Prefix };
        //    if (query.Count() == 0)
        //    {
        //        Setup_Serial_Number doc = new Setup_Serial_Number();
        //        doc.Year = _Year;
        //        doc.Identity = 1;
        //        doc.Prefix = _Prefix;
        //        db.Setup_Serial_Numbers.InsertOnSubmit(doc);
        //        db.SubmitChanges();
        //    }
        //    foreach (var a in query)
        //    {
        //        string documentNo_ = a.Prefix + _Year.ToString() + string.Format("{0:000000}", a.Identity);
        //        Setup_Serial_Number doc = db.Setup_Serial_Numbers.Single(p => p.Year == _Year && p.Prefix == _Prefix);
        //        doc.Identity += 1;
        //        db.SubmitChanges();
        //        return documentNo_;
        //    }
        //    return string.Empty;
        //}
    }
}
