using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Data.Sql;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using System.IO;

namespace ClinicDAL
{
    public class iHISAccessConfigDataDAL
    {
        public static string MyServerName()
        {
            return Environment.MachineName;
        }

        public static DataTable TableServerName()
        {
            try
            {
                string myServer = Environment.MachineName;
                DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
                return servers;
            }
            catch { return null; }
        }

    }
}
