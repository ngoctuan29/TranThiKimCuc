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
    public class ServiceMenuBLL
    {
        public static List<ServiceMenuINF> ListServiceMenu()
        {
            return ServiceMenuDAL.ListServiceMenu();
        }
        public static List<ServiceMenuForDepartmentINF> ListServiceMenuForDepartmentINF(Int32 idMenu)
        {
            return ServiceMenuDAL.ListServiceMenuForDepartmentINF(idMenu);
        }

        public static List<ServiceMenuForServiceINF> ListServiceMenuForService(Int32 idMenu)
        {
            return ServiceMenuDAL.ListServiceMenuForService(idMenu);
        }
        public static Int32 Ins_ServiceMenuForDepartment(ServiceMenuForDepartmentINF info)
        {
            return ServiceMenuDAL.Ins_ServiceMenuForDepartment(info);
        }

        public static Int32 Ins_ServiceMenuForService(ServiceMenuForServiceINF info)
        {
            return ServiceMenuDAL.Ins_ServiceMenuForService(info);
        }
        public static Int32 Del_ServiceMenuForService(Int32 iMenu)
        {
            return ServiceMenuDAL.Del_ServiceMenuForService(iMenu);
        }
        public static Int32 Del_ServiceMenuForDepartment(Int32 iMenu)
        {
            return ServiceMenuDAL.Del_ServiceMenuForDepartment(iMenu);
        }
        public static DataTable DT_MenuDeparForEmployee(Int32 idMenu, string sDepartCode)
        {
            return ServiceMenuDAL.DT_MenuDeparForEmployee(idMenu, sDepartCode);
        }
    }
}
