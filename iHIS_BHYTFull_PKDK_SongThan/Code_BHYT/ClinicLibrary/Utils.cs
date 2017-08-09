using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Web.UI;
using System.Web;
using System.Web.Security;
using System.Globalization;
using System.Data;
using ClinicDAL;
using System.Data.OleDb;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Management;
using System.Reflection;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using ClinicModel;
using DevExpress.XtraRichEdit;
using System.ComponentModel;

namespace ClinicLibrary
{
    public class Utils
    {
        private ConnectDB connect = new ConnectDB();
        public Utils()
        {

        }

        public static string Md5Encrypt(string originalText)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(originalText.Trim(), "MD5").ToLower();
        }
        public static string GetClientIP()
        {
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return ip;
        }
        private static Random random = new Random();
        public static int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }
        public static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                builder.Append((char)random.Next(0x41, 0x5A));
            }
            return builder.ToString();
        }
        public static DateTime StringToDate(string s)
        {
            string[] format = { "dd/MM/yyyy" };
            return System.DateTime.ParseExact(s.Substring(0, 10), format[0], System.Globalization.DateTimeFormatInfo.CurrentInfo, System.Globalization.DateTimeStyles.None);
        }
        public static DateTime StringToDateTime(string s)
        {
            string[] format = { "dd/MM/yyyy HH:mm" };
            return System.DateTime.ParseExact(s.Substring(0, 16), format[0], System.Globalization.DateTimeFormatInfo.CurrentInfo, System.Globalization.DateTimeStyles.None);
        }
        public static DateTime DateServer()
        {
            ConnectDB cn = new ConnectDB();
            DateTime dtTemp = new DateTime();
            try
            {
                string sql = " SELECT CONVERT(date, GETDATE(), 103) date ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                if (ireader.Read())
                {
                    dtTemp = ireader.GetDateTime(0);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { }
            return dtTemp;
        }
        public static DateTime DateTimeServer()
        {
            ConnectDB cn = new ConnectDB();
            DateTime dtTemp = new DateTime();
            try
            {
                string sql = " SELECT GETDATE() date ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                if (ireader.Read())
                {
                    dtTemp = ireader.GetDateTime(0);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { }
            return dtTemp;
        }
        public static string DateServerYYYYMMDD()
        {
            ConnectDB cn = new ConnectDB();
            string stime = string.Empty;
            try
            {
                string sql = " SELECT CONVERT(char(8), GETDATE(), 112) dateserver ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                if (ireader.Read())
                {
                    stime = ireader.GetValue(0).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return stime;
            }
            catch { return null; }
        }
        public static string DateServerYYMMDD()
        {
            ConnectDB cn = new ConnectDB();
            string date = string.Empty;
            try
            {
                string sql = " select RIGHT(convert(char(10),GETDATE(),112),8) dateserver ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                if (ireader.Read())
                {
                    date = ireader.GetValue(0).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return date.TrimEnd();
            }
            catch { return null; }
        }
        public static DataRow GetPriceRowbyCode(DataTable tableData, string expression)
        {
            try
            {
                DataRow[] foundRows;
                foundRows = tableData.Select(expression);
                if (foundRows.Length > 0)
                {
                    return foundRows[0];
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
        public static bool isHour(string gio)
        {
            try
            {
                if (gio.IndexOf("::") != -1)
                {
                    return false;
                }
                string s = gio.Substring(0, 2);
                string str2 = gio.Substring(3, 2);
                if (int.Parse(s) > 0x17)
                    return false;
                if (int.Parse(str2) > 0x3b)
                {
                    return false;
                }
                return true;
            }
            catch { return false; }
        }
        public static string ObjectName(int iObjectCode)
        {
            if (iObjectCode == 1)
                return "BHYT";
            else if (iObjectCode == 2)
                return "Thu Phí";
            else if (iObjectCode == 5)
                return "Miễn";
            else if (iObjectCode == 7)
                return "Dịch Vụ";
            else if (iObjectCode == 8)
                return "Víp";
            else if (iObjectCode == 9)
                return "Yêu Cầu";
            else
                return "Khác";
        }
        public static bool isDate(string ngay)
        {
            try
            {
                if (ngay.IndexOf("_") != -1 || (ngay.IndexOf(" ") != -1 && ngay.Trim().Length == 10)) return false;
                int len = ngay.Length;
                if (len == 0) return false;
                string dd = ngay.Substring(0, 2), mm = ngay.Substring(3, 2), yyyy = ngay.Substring(6, 4);
                string s31 = "01+03+05+07+08+10+12+", s30 = "04+06+09+11+", s2829 = (int.Parse(yyyy) % 4 == 0) ? "29" : "28";
                if (int.Parse(yyyy.Substring(0, 1)) < 1) return false;
                if (int.Parse(mm) < 1 || int.Parse(mm) > 12) return false;
                if (s31.IndexOf(mm + "+") > -1)
                {
                    if (int.Parse(dd) < 1 || int.Parse(dd) > 31) return false;
                }
                else if (s30.IndexOf(mm + "+") > -1)
                {
                    if (int.Parse(dd) < 1 || int.Parse(dd) > 30) return false;
                }
                else if (int.Parse(dd) < 1 || int.Parse(dd) > int.Parse(s2829)) return false;
                if (len > 10)
                {
                    string hh = ngay.Substring(11, 2), MM = ngay.Substring(14, 2);
                    if (int.Parse(hh) > 23) return false;
                    if (int.Parse(MM) > 59) return false;
                }
                return true;
            }
            catch { return false; };
        }
        public static bool isDate(string ngayvao, string ngaysinh)
        {
            try
            {
                int d1 = DateTime.Now.Day;
                int m1 = DateTime.Now.Month;
                int y1 = DateTime.Now.Year;
                if (!string.IsNullOrEmpty(ngayvao))
                {
                    y1 = int.Parse(ngayvao.Substring(6, 4));
                    m1 = int.Parse(ngayvao.Substring(3, 2));
                    d1 = int.Parse(ngayvao.Substring(0, 2));
                }
                int d2 = int.Parse(ngaysinh.Substring(0, 2));
                int m2 = int.Parse(ngaysinh.Substring(3, 2));
                int y2 = int.Parse(ngaysinh.Substring(6, 4));
                if (y2 > y1) return false;
                else if (y2 < y1) return true;
                if (m2 > m1) return false;
                else if (m2 < m1) return true;
                if (d2 > d1) return false;
                return true;
            }
            catch { return true; }
        }
        public static string Onlyso(string s)
        {
            string ret = "", s1 = " 0123456789";
            for (int i = 0; i < s.Length; i++)
                if (s1.IndexOf(s.Substring(i, 1)) != -1) ret += s.Substring(i, 1);
            return ret;
        }
        public static string KiemTrangaygio(string s, int len)
        {
            try
            {
                string s1 = Onlyso(s);
                if (len == 10)
                    return s1.Substring(0, 2).Trim().PadLeft(2, '0') + "/" + s1.Substring(2, 2).Trim().PadLeft(2, '0') + "/" + s1.Substring(4).Trim().PadLeft(4, '0');
                else
                    return s1.Substring(0, 2).Trim().PadLeft(2, '0') + "/" + s1.Substring(2, 2).Trim().PadLeft(2, '0') + "/" + s1.Substring(4, 4).Trim().PadLeft(4, '0') + " " + s1.Substring(9, 2).Trim().PadLeft(2, '0') + ":" + s1.Substring(11, 2).Trim().PadLeft(2, '0');
            }
            catch { return s; }
        }
        public static bool IsNumber(string pText)
        {
            try
            {
                decimal dResult = 0;
                if (decimal.TryParse(pText, out dResult))
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }
        public static bool CheckNumber(string sValue)
        {
            try
            {
                decimal dResult;
                bool isNum = Decimal.TryParse(sValue, out dResult);
                if (isNum)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }
        public static void Check_Process_Excel()
        {
            Process[] processes = Process.GetProcesses();

            if (processes.Length > 1)
            {
                int i = 0;
                for (int n = 0; n <= processes.Length - 1; n++)
                {
                    if (((Process)processes[n]).ProcessName == "EXCEL")
                    {
                        i++;
                        ((Process)processes[n]).Kill();
                    }
                }
            }
        }
        public static string Export_Excel(DataTable datatable, string tenfile)
        {
            try
            {

                string dirPath = AppDomain.CurrentDomain.BaseDirectory + "Excel";
                string filePath = dirPath + "//" + tenfile + ".xls";
                if (!System.IO.Directory.Exists(dirPath)) System.IO.Directory.CreateDirectory(dirPath);
                System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.Unicode);
                string astr = string.Empty;
                astr = "<Table>";//"<Table border=1>";
                astr = astr + "<tr>";
                for (int i = 0; i < datatable.Columns.Count; i++)
                {
                    astr = astr + "<th>";
                    astr = astr + datatable.Columns[i].ColumnName;
                    astr = astr + "</th>";
                }
                astr = astr + "</tr>";
                sw.Write(astr);
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    astr = "<tr>";
                    for (int j = 0; j < datatable.Columns.Count; j++)
                    {
                        astr = astr + "<td>";
                        astr = astr + datatable.Rows[i][j].ToString().Trim().Replace("'", " ");
                        astr = astr + "</td>";
                    }
                    astr = astr + "</tr>";
                    sw.Write(astr);
                }
                astr = "</Table>";
                sw.Write(astr);
                sw.Close();
                return filePath;
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string GetIndex(int i)
        {
            string[] map = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
                               "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ",
                               "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ",
                               "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ",
                               "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ",
                               "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ",
                               "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ",
                               "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ",
                               "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ",
                               "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ",
                               "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ",
                               "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ",
                               "LA", "LB", "LC", "LD", "LE", "LF", "LG", "LH", "LI", "LJ", "LK", "LL", "LM", "LN", "LO", "LP", "LQ", "LR", "LS", "LT", "LU", "LV", "LW", "LX", "LY", "LZ",
                               "MA", "MB", "MC", "MD", "ME", "MF", "MG", "MH", "MI", "MJ", "MK", "ML", "MM", "MN", "MO", "MP", "MQ", "MR", "MS", "MT", "MU", "MV", "MW", "MX", "MY", "MZ",
                               "NA", "NB", "NC", "ND", "NE", "NF", "NG", "NH", "NI", "NJ", "NK", "NL", "NM", "NN", "NO", "NP", "NQ", "NR", "NS", "NT", "NU", "NV", "NW", "NX", "NY", "NZ",
                               "OA", "OB", "OC", "OD", "OE", "OF", "OG", "OH", "OI", "OJ", "OK", "OL", "OM", "ON", "OO", "OP", "OQ", "OR", "OS", "OT", "OU", "OV", "OW", "OX", "OY", "OZ",
                               "PA", "PB", "PC", "PD", "PE", "PF", "PG", "PH", "PI", "PJ", "PK", "PL", "PM", "PN", "PO", "PP", "PQ", "PR", "PS", "PT", "PU", "PV", "PW", "PX", "PY", "PZ",
                               "QA", "QB", "QC", "QD", "QE", "QF", "QG", "QH", "QI", "QJ", "QK", "QL", "QM", "QN", "QO", "QP", "QQ", "QR", "QS", "QT", "QU", "QV", "QW", "QX", "QY", "QZ",
                               "RA", "RB", "RC", "RD", "RE", "RF", "RG", "RH", "RI", "RJ", "RK", "RL", "RM", "RN", "RO", "RP", "RQ", "RR", "RS", "RT", "RU", "RV", "RW", "RX", "RY", "RZ",
                               "SA", "SB", "SC", "SD", "SE", "SF", "SG", "SH", "SI", "SJ", "SK", "SL", "SM", "SN", "SO", "SP", "SQ", "SR", "SS", "ST", "SU", "SV", "SW", "SX", "SY", "SZ",
                               "TA", "TB", "TC", "TD", "TE", "TF", "TG", "TH", "TI", "TJ", "TK", "TL", "TM", "TN", "TO", "TP", "TQ", "TR", "TS", "TT", "TU", "TV", "TW", "TX", "TY", "TZ",
                               "UA", "UB", "UC", "UD", "UE", "UF", "UG", "UH", "UI", "UJ", "UK", "UL", "UM", "UN", "UO", "UP", "UQ", "UR", "US", "UT", "UU", "UV", "UW", "UX", "UY", "UZ",
                               "VA", "VB", "VC", "VD", "VE", "VF", "VG", "VH", "VI", "VJ", "VK", "VL", "VM", "VN", "VO", "VP", "VQ", "VR", "VS", "VT", "VU", "VV", "VW", "VX", "VY", "VZ",
                               "WA", "WB", "WC", "WD", "WE", "WF", "WG", "WH", "WI", "WJ", "WK", "WL", "WM", "WN", "WO", "WP", "WQ", "WR", "WS", "WT", "WU", "WV", "WW", "WX", "WY", "WZ",
                               "XA", "XB", "XC", "XD", "XE", "XF", "XG", "XH", "XI", "XJ", "XK", "XL", "XM", "XN", "XO", "XP", "XQ", "XR", "XS", "XT", "XU", "XV", "XW", "XX", "XY", "XZ",
                               "YA", "YB", "YC", "YD", "YE", "YF", "YG", "YH", "YI", "YJ", "YK", "YL", "YM", "YN", "YO", "YP", "YQ", "YR", "YS", "YT", "YU", "YV", "YW", "YX", "YY", "YZ",
                               "ZA", "ZB", "ZC", "ZD", "ZE", "ZF", "ZG", "ZH", "ZI", "ZJ", "ZK", "ZL", "ZM", "ZN", "ZO", "ZP", "ZQ", "ZR", "ZS", "ZT", "ZU", "ZV", "ZW", "ZX", "ZY", "ZZ"};

            return map[i];
        }
        public static void GetClinicInfo(ref string ssoyte, ref string simage, ref string snames, ref string saddress, ref string sphone, ref string semail, ref string sckhoa, ref string sothers, ref string simgcopyright)
        {
            XmlDocument XmlDOcument = ReadXml(Utils.CurrentPathApplication() + "\\xml\\ClinicInfo.xml");
            XmlElement XmlElement = XmlDOcument.DocumentElement;
            try
            {
                ssoyte = XmlElement.SelectSingleNode("soyte").InnerText;
                simage = XmlElement.SelectSingleNode("image").InnerText;
                snames = XmlElement.SelectSingleNode("names").InnerText;
                saddress = XmlElement.SelectSingleNode("address").InnerText;
                sphone = XmlElement.SelectSingleNode("phone").InnerText;
                semail = XmlElement.SelectSingleNode("email").InnerText;
                sckhoa = XmlElement.SelectSingleNode("ckhoa").InnerText;
                sothers = XmlElement.SelectSingleNode("others").InnerText;
                simgcopyright = XmlElement.SelectSingleNode("imgcopyright").InnerText;
            }
            catch
            {
                throw new Exception();
            }
        }
        public static bool BackupDataBase(string sPath)
        {
            ConnectDB cn = new ConnectDB();
            bool bResult = true;
            try
            {
                string sDatabase = string.Empty;
                ServerInfo server = cn.LoadFileXml(Utils.CurrentPathApplication() + "\\xml\\configiHIS.xml");
                if (server.Database == string.Empty)
                    bResult = false;
                else
                {
                    cn.ExecuteNonQuery(CommandType.Text, " backup database " + sDatabase + " to disk = '" + sPath + "'", null);
                    bResult = true;
                }
            }
            catch
            {
                bResult = false;
            }
            return bResult;
        }
        public static DataTable TableWorkShift()
        {
            DataTable tableWork = new DataTable();
            tableWork.Columns.Add("ShiftCode", typeof(string));
            tableWork.Columns.Add("ShiftName", typeof(string));
            tableWork.Rows.Add("AM", "Ca 1");
            tableWork.Rows.Add("PM", "Ca 2");
            tableWork.Rows.Add("EV", "Ca 3");
            return tableWork;
        }
        public static string GetMacAddress()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true");
            IEnumerable<ManagementObject> objects = searcher.Get().Cast<ManagementObject>();
            string mac = (from o in objects orderby o["IPConnectionMetric"] select o["MACAddress"].ToString()).FirstOrDefault();
            return mac;
        }
        public static String GetHDDSerialNo()
        {
            ManagementClass mangnmt = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection mcol = mangnmt.GetInstances();
            string result = "";
            foreach (ManagementObject strt in mcol)
            {
                result += Convert.ToString(strt["VolumeSerialNumber"]);
            }
            return result;
        }
        public static String GetComputerName()
        {
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            String info = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                info = (string)mo["Name"];
            }
            return info;
        }
        public static string ToUpperCharacterFisrt(string s)
        {
            if (s.Length == 0) return null;
            System.Text.StringBuilder sb = new System.Text.StringBuilder(s);//.ToLower());
            sb[0] = Char.ToUpper(sb[0]);
            string ret = null;
            int num = 0; int ispace = 0;
            while (num < sb.Length)
            {
                if (Char.IsWhiteSpace(sb[num])) ispace++;
                if (!Char.IsWhiteSpace(sb[num]))
                {
                    if (ispace > 0 && num > 0)
                    {
                        sb[num] = Char.ToUpper(sb[num]);
                        ispace = 0;
                    }
                }
                num++;
            }
            num = 0;
            ispace = 0;
            while (num < sb.Length)
            {
                if (Char.IsWhiteSpace(sb[num]))
                {
                    if (ispace < 1 && num > 0) ret += sb[num];
                    ispace++;
                }
                else
                {
                    ret += sb[num];
                    ispace = 0;
                }
                num++;
            }
            return ret;
        }
        public static string ToUpperCharacterFisrtString(string s)
        {
            if (s.Length == 0) return null;
            System.Text.StringBuilder sb = new System.Text.StringBuilder(s);
            sb[0] = Char.ToUpper(sb[0]);
            string ret = null;
            int num = 0; int ispace = 0;
            while (num < sb.Length)
            {
                if (Char.IsWhiteSpace(sb[num])) ispace++;
                if (!Char.IsWhiteSpace(sb[num]))
                {
                    if (ispace > 0 && num > 0)
                    {
                        sb[num] = sb[num];
                        ispace = 0;
                    }
                }
                num++;
            }
            num = 0;
            ispace = 0;
            while (num < sb.Length)
            {
                if (Char.IsWhiteSpace(sb[num]))
                {
                    if (ispace < 1 && num > 0) ret += sb[num];
                    ispace++;
                }
                else
                {
                    ret += sb[num];
                    ispace = 0;
                }
                num++;
            }
            return ret;
        }
        public static XmlDocument ReadXml(String fileName)
        {
            XmlDocument XmlDocument = new XmlDocument();
            try
            {
                XmlDocument.Load(fileName);
            }
            catch
            {
                throw new Exception();
            }
            return XmlDocument;
        }
        public bool CheckConnection()
        {
            return this.connect.CheckConnection();
        }
        public bool CheckConnection(string servername, string username, string password, string database)
        {
            return this.connect.CheckConnection(servername, username, password, database);
        }
        public static bool isMobile(string mobile)
        {
            String phoneNumber = @"0\d{9,10}";
            if (!Regex.IsMatch(mobile, phoneNumber))
                return false;
            else
                return true;
        }
        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        public static string ReplaceMobile(string mobile)
        {
            return mobile.Trim().Replace(" ", "").Replace(".", "").Replace("-", "");
        }
        public static bool CheckEmail(string email)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            bool result = regex.IsMatch(email);
            return result;
        }
        public static string GetTokenClasHealthcareAppointment()
        {
            ConnectDB cn = new ConnectDB();
            return cn.GetTokenClasHealthcareAppointment();
        }
        public static string CheckFirtCharForDoc(string s)
        {
            if (s.Length == 0) return null;
            System.Text.StringBuilder sb = new System.Text.StringBuilder(s);//.ToLower());
            sb[0] = Char.ToUpper(sb[0]);
            string ret = null;
            int num = 0; int idau = 0;
            while (num < sb.Length)
            {
                if (sb[num].ToString() == ".") idau++;
                if (!(sb[num].ToString() == "."))
                {
                    if (idau > 0 && num > 0)
                    {
                        sb[num] = Char.ToUpper(sb[num]);
                        idau = 0;
                    }
                }
                num++;
            }
            num = 0;
            idau = 0;
            while (num < sb.Length)
            {
                if (sb[num].ToString() == ".")
                {
                    if (idau < 1 && num > 0) ret += sb[num];
                    idau++;
                }
                else
                {
                    ret += sb[num];
                    idau = 0;
                }
                num++;
            }
            return ret;
        }
        public static bool CheckConnectInternet()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "g3g4.vn";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success) return true;
                else return false;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public static DataTable ReadFileExcel(string pathName)
        {
            return ConnectDataExcel.ReadExcel(pathName);
        }
        public static DataTable ReadFileExcel(string pathName, int rowTableName)
        {
            return ConnectDataExcel.ReadExcel(pathName, rowTableName);
        }
        public static String CurrentPathApplication()
        {
            return Application.StartupPath;
        }
        public static string TimeServer()
        {
            ConnectDB cn = new ConnectDB();
            string stime = string.Empty;
            try
            {
                string sql = " SELECT CONVERT(char(5), SYSDATETIME(), 24) time ";
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, sql, null);
                if (ireader.Read())
                {
                    stime = ireader.GetValue(0).ToString();
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
                return stime;
            }
            catch { return null; }
        }
        public static DataTable ListToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            Type Propiedad = null;
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                Propiedad = prop.PropertyType;
                if (Propiedad.IsGenericType && Propiedad.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    Propiedad = Nullable.GetUnderlyingType(Propiedad);
                }
                table.Columns.Add(prop.Name, Propiedad);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
        
    }
}