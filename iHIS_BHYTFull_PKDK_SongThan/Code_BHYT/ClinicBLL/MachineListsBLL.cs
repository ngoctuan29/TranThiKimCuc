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
    public class MachineListsBLL
    {
        public static DataTable TableMachineLists()
        {
            return MachineListsDal.TableMachineLists();
        }
        
        public static DataTable TableMachineListsForGroup(string categoryCode)
        {
            return MachineListsDal.TableMachineListsForGroup(categoryCode);
        }

        public static DataTable TableMachineLists(int hide)
        {
            return MachineListsDal.TableMachineLists(hide);
        }

        public static Int32 InsMachineLists(MachineLists info)
        {
            return MachineListsDal.InsMachineLists(info);
        }
        public static bool IsDeleteMachineLists(int rowID)
        {
            return MachineListsDal.IsDeleteMachineLists(rowID);
        }

    }
}
