using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using ClinicDAL;

namespace ClinicBLL
{
    public class Catalog_BHYTBLL
    {
        public static DataTable TableServiceGroup_BHYT()
        {
            return Catalog_BHYTDAL.TableServiceGroup_BHYT();
        }
        public static DataTable TableDMLoaiPT_TT()
        {
            return Catalog_BHYTDAL.TableDMLoaiPT_TT();
        }
        public static DataTable TableService_BHYT()
        {
            return Catalog_BHYTDAL.TableService_BHYT();
        }
        public static DataTable TableDMChuyenKhoa_BHYT()
        {
            return Catalog_BHYTDAL.TableDMChuyenKhoa_BHYT();
        }
        public static DataTable TableDMThuoc_BHYT()
        {
            return Catalog_BHYTDAL.TableDMThuoc_BHYT();
        }
        
        public static string TableCkTheoTD(string matd)
        {
            string sCode = string.Empty;
            try
            {
                var vlist = Catalog_BHYTDAL.TableCkTheoTD(matd);
                if (vlist.Count > 0)
                    sCode = vlist[0].MaCK;
            }
            catch { }
            return sCode;
        }
    }
}
