using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.OleDb;
using System.Diagnostics;
using System.Data;

namespace ClinicDAL
{
    public class ConnectDataExcel
    {
        private const string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private const string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";

        public static DataTable ReadExcel(string filePath)
        {
            DataTable tableResult = new DataTable();
            try
            {
                string extension = Path.GetExtension(filePath);
                string conStr = string.Empty, sheetName = string.Empty;
                conStr = string.Empty;
                switch (extension)
                {
                    case ".xls": //Excel 97-03
                        conStr = string.Format(Excel03ConString, filePath, "YES");
                        break;
                    case ".xlsx": //Excel 07
                        conStr = string.Format(Excel07ConString, filePath, "YES");
                        break;
                }

                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.Connection = con;
                        con.Open();
                        DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                        cmd.Dispose();
                    }
                    con.Close();
                    con.Dispose();
                }

                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    con.Open();
                    OleDbDataAdapter sheetAdapter = new OleDbDataAdapter("select * from [" + sheetName + "]", con);
                    sheetAdapter.Fill(tableResult);
                }
            }
            catch { tableResult = null; }
            return tableResult;
        }
        public static DataTable ReadExcel(string _filePath, int rowTableName)
        {
            DataTable dt = new DataTable();
            try
            {
                string filePath = _filePath;
                string extension = Path.GetExtension(filePath);
                string conStr, sheetName;
                conStr = string.Empty;
                switch (extension)
                {

                    case ".xls": //Excel 97-03
                        conStr = string.Format(Excel03ConString, filePath, "YES");
                        break;

                    case ".xlsx": //Excel 07
                        conStr = string.Format(Excel07ConString, filePath, "YES");
                        break;
                }

                //Get the name of the First Sheet.
                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.Connection = con;
                        con.Open();
                        DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                        cmd.Dispose();
                        con.Close();
                        con.Dispose();
                    }
                }

                //Read Data from the First Sheet.
                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        using (OleDbDataAdapter oda = new OleDbDataAdapter())
                        {
                            cmd.CommandText = "SELECT * From [" + sheetName + "]";
                            cmd.Connection = con;
                            con.Open();
                            oda.SelectCommand = cmd;
                            oda.Fill(dt);
                            cmd.Dispose();
                            con.Close();
                            con.Dispose();
                        }
                    }
                }
            }
            catch { }
            return dt;
        }
    }
}
