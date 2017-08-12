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
    public class ObjectBLL
    {
        public static DataTable DTObjectList(int iObjCode)
        {
            return ObjectDal.DTObjectList(iObjCode);
        }

        public static DataTable DTObjectListNotIn(int iObjCode)
        {
            return ObjectDal.DTObjectListNotIn(iObjCode);
        }

        public static List<ObjectInf> ListObject(int iObjCode)
        {
            return ObjectDal.ListObject(iObjCode);
        }

        public static int InsObject(ObjectInf info)
        {
            try
            {
                return ObjectDal.InsObject(info);
            }
            catch { return -2; }
        }

        public static int DelObject(int iObjCode)
        {
            try
            {
                return ObjectDal.DelObject(iObjCode);
            }
            catch { return -2; }
        }

        public static Int32 Del(int sRowID, int sReceiveID, string sPatientCode, string sServiceCode)
        {
            return ObjectDal.Del(sRowID, sReceiveID, sPatientCode, sServiceCode);
        }

        public static Int32 DelThuoc(int sRowID2, string sMedicalRecordCode, string sItemCode)
        {
            return ObjectDal.DelThuoc(sRowID2, sMedicalRecordCode, sItemCode);
        }

    }
}
