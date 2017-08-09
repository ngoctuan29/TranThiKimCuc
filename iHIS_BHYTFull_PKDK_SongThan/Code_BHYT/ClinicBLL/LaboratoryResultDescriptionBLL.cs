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
    public class LaboratoryResultDescriptionBLL
    {
        public static DataTable DT_LabResultDescription()
        {
            return LaboratoryResultDescriptionDAL.DT_LabResultDescription();
        }
        public static Int32 InsResultDescription(LaboratoryResultDescriptionInf info)
        {
            return LaboratoryResultDescriptionDAL.InsResultDescription(info);
        }
        public static Int32 UpdResultDescription(LaboratoryResultDescriptionInf info)
        {
            return LaboratoryResultDescriptionDAL.UpdResultDescription(info);
        }
        public static Int32 DelResultDescription(Int32 iRowID)
        {
            return LaboratoryResultDescriptionDAL.DelResultDescription(iRowID);
        }
        public static DataTable TableCategoryForMachine(string serviceCategoryCode)
        {
            return LaboratoryResultDescriptionDAL.TableCategoryForMachine(serviceCategoryCode);
        }
        public static DataTable TableLabTypeResult(string serviceGroupCode)
        {
            return LaboratoryResultDescriptionDAL.TableLabTypeResult(serviceGroupCode);
        }

        public static DataTable TableLabTypeResultTemplate(string serviceGroupCode, Int32 type)
        {
            return LaboratoryResultDescriptionDAL.TableLabTypeResultTemplate(serviceGroupCode, type);
        }

        public static Int32 IULabTypeResult(string serviceCode, int typeResult, string employeeCode)
        {
            return LaboratoryResultDescriptionDAL.IULabTypeResult(serviceCode, typeResult, employeeCode);
        }

        public static Int32 DelLabTypeResult(string serviceCode)
        {
            return LaboratoryResultDescriptionDAL.DelLabTypeResult(serviceCode);
        }
    }

    public class LabPatternAttachBLL
    {
        public static Int32 InsLabPattern(LabPatternAttachInf info)
        {
            return LabPatternAttachDAL.InsLabPattern(info);
        }

        public static Int32 DelLabPattern(Int32 labPatternID)
        {
            return LabPatternAttachDAL.DelLabPattern(labPatternID);
        }

        public static LabPatternAttachInf ObjLabPattern(string serviceCategoryCode)
        {
            return LabPatternAttachDAL.ObjLabPattern(serviceCategoryCode);
        }
    }

    public class LabPathologicalBLL
    {
        public static DataTable TableLabPathological()
        {
            return LabPathologicalDAL.TableLabPathological();
        }
    }

}
