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
    public class LaboratoryPackageBLL
    {
        public static DataTable TableLabPackage(string packageCode)
        {
            return LaboratoryPackageDal.TableLabPackage(packageCode);
        }
        public static DataTable TableLabPackageForModule(string serviceModuleCode, int typeResult)
        {
            return LaboratoryPackageDal.TableLabPackageForModule(serviceModuleCode, typeResult);
        }
        public static DataTable TableLabPackageDetail(String sCode)
        {
            return LaboratoryPackageDal.TableLabPackageDetail(sCode);
        }
        public static List<LaboratoryPackageDetailInf> List_LabPackageDetail(String sCode)
        {
            return LaboratoryPackageDal.List_LabPackageDetail(sCode);
        }
        public static Int32 InsPackage(LaboratoryPackageInf info, ref string resultCode)
        {
            return LaboratoryPackageDal.InsPackage(info,ref resultCode);
        }
        public static Int32 InsPackageDetail(LaboratoryPackageDetailInf info)
        {
            return LaboratoryPackageDal.InsPackageDetail(info);
        }
        public static Int32 Del(string packageCode)
        {
            return LaboratoryPackageDal.Del(packageCode);
        }
        public static Int32 DelDetail(int iRowID, string laboratoryPackageCode)
        {
            return LaboratoryPackageDal.DelDetail(iRowID, laboratoryPackageCode);
        }
        public static Int32 UpdPackageTemplateHeader(string serviceCode, string templateHeaderCode)
        {
            return LaboratoryPackageDal.UpdPackageTemplateHeader(serviceCode, templateHeaderCode);
        }
        public static DataTable TableLabPackageForServiceCode(string serviceCode)
        {
            return LaboratoryPackageDal.TableLabPackageForServiceCode(serviceCode);
        }
    }
}
