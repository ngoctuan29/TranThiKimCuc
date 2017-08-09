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
    public class CatalogComputerBLL
    {
        public static CatalogComputerInf ObjComputer(string hddSerialNo)
        {
            return CatalogComputerDAL.ObjComputer(hddSerialNo);
        }

        public static Int32 InsComputer(CatalogComputerInf info)
        {
            return CatalogComputerDAL.InsComputer(info);
        }
        public static Int32 UpdDateWorking(DateTime dtimeWorking, string hddserialNo)
        {
            return CatalogComputerDAL.UpdDateWorking(dtimeWorking, hddserialNo);
        }
    }
}
