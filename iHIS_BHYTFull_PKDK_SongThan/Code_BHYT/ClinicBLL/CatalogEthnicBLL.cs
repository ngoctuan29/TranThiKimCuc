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
    public class CatalogEthnicBLL
    {
        public DataTable DTListEthnic(int ethnicID)
        {
            CatalogEthnicDAL ethnic = new CatalogEthnicDAL();
            return ethnic.DTListEthnic(ethnicID);
        }
    }
}
