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
using System.IO;
using ClinicModel;

namespace ClinicDAL
{
    public class ConnectDB
    {

        public string connectionstring = @"Data Source=DONGDEV-PC;Initial Catalog=iHISAppv2;User Id=powersoft;Password=ps2016;";
        public SqlConnection sqlConnection;
        private SqlDataAdapter sqlDataAdapter;
        private ServerInfo serverInfo = new ServerInfo();
        public ConnectDB()
        {
            this.sqlConnection = new SqlConnection();
            this.GetConfigObject();
        }

        public void GetConfigObject()
        {
            try
            {
                string pathFileName = (Application.StartupPath) + "\\xml\\configiHIS.xml";
                ServerInfo server = this.LoadFileXml(pathFileName);
                if (server != null && server.Encrypt == "true")
                {
                    this.serverInfo.Encrypt = server.Encrypt;
                    this.serverInfo.ServerName = this.DecryptString(server.ServerName, true);
                    this.serverInfo.Database = this.DecryptString(server.Database, true);
                    this.serverInfo.UserName = this.DecryptString(server.UserName, true);
                    this.serverInfo.Password = this.DecryptString(server.Password, true);
                }
                else
                {
                    this.serverInfo.Encrypt = "false";
                    this.serverInfo.ServerName = "powersoft.vn";
                    this.serverInfo.Database = "iHIS";
                    this.serverInfo.UserName = "ps";
                    this.serverInfo.Password = "****";
                }
                this.connectionstring = "Data Source=" + this.serverInfo.ServerName + ";Initial Catalog=" + this.serverInfo.Database + ";User Id=" + this.serverInfo.UserName + ";Password=" + this.serverInfo.Password + ";";
                this.sqlConnection.ConnectionString = this.connectionstring;
            }
            catch (Exception ex)
            {
                this.connectionstring = string.Empty;
                throw new Exception(ex.Message);
            }
        }
        public ServerInfo LoadFileXml(string FileName)
        {
            using (var stream = System.IO.File.OpenRead(FileName))
            {
                var serializer = new XmlSerializer(typeof(ServerInfo));
                return serializer.Deserialize(stream) as ServerInfo;
            }
        }

        public bool CheckConnection(string servername, string username, string password, string database)
        {
            try
            {
                this.serverInfo.ServerName = servername;
                this.serverInfo.UserName = username;
                this.serverInfo.Password = password;
                this.serverInfo.Database = database;
                this.connectionstring = "Data Source=" + this.serverInfo.ServerName + ";Initial Catalog=" + this.serverInfo.Database + ";User Id=" + this.serverInfo.UserName + ";Password=" + this.serverInfo.Password + ";";
                this.sqlConnection = new SqlConnection(this.connectionstring);
                this.sqlConnection.Open();
                this.WritefileXmlObject();
                return true;
            }
            catch { return false; }
            finally
            {
                if (this.sqlConnection.State != ConnectionState.Closed)
                    this.sqlConnection.Close();
            }
        }



        public XmlDocument ReadXml(String fileName)
        {
            XmlDocument XmlDocument = new XmlDocument();
            try
            {
                XmlDocument.Load(fileName);
            }
            catch
            {
                MessageBox.Show("Không đọc được hoặc không tồn tại tập tin cấu hình " + fileName, "Ps Clinic", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return XmlDocument;
        }
        public string GetTokenClasHealthcareAppointment()
        {
            XmlDocument XmlDOcument = ReadXml((Application.StartupPath) + "\\xml\\configAppointmentClas.xml");
            XmlElement XmlElement = XmlDOcument.DocumentElement;
            try
            {
                return XmlElement.SelectSingleNode("token").InnerText;
            }
            catch
            {
                return string.Empty;
            }
        }
        public bool CheckConnection()
        {
            try
            {
                this.GetConfigObject();
                this.connectionstring = "Data Source=" + this.serverInfo.ServerName + ";Initial Catalog=" + this.serverInfo.Database + ";User Id=" + this.serverInfo.UserName + ";Password=" + this.serverInfo.Password + ";";
                this.sqlConnection = new SqlConnection(this.connectionstring);
                this.sqlConnection.Open();
                this.WritefileXmlObject();
                return true;
            }
            catch { return false; }
            finally
            {
                if (this.sqlConnection.State != ConnectionState.Closed)
                    this.sqlConnection.Close();
            }
        }

        public string GETMD5(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        private void WritefileXmlObject()
        {
            string fileName = (Application.StartupPath) + "\\xml\\configiHIS.xml";
            var serializer = new XmlSerializer(typeof(ServerInfo));
            ServerInfo server = new ServerInfo { Encrypt = "true", ServerName = this.EncryptString(this.serverInfo.ServerName, true), UserName = this.EncryptString(this.serverInfo.UserName, true), Password = this.EncryptString(this.serverInfo.Password, true), Database = this.EncryptString(this.serverInfo.Database, true) };
            using (StreamWriter myWriter = new StreamWriter(fileName, false))
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(ServerInfo));
                mySerializer.Serialize(myWriter, server);
            }
        }

        public string schemas { get { return "ihis"; } }

        public DataTable TableServerName()
        {
            try
            {
                string myServer = Environment.MachineName;
                DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
                return servers;
            }
            catch { return null; }
        }

        public string EncryptString(string toEncrypt, bool useHashing)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
                if (useHashing)
                {
                    var hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes("2$Powersoft.vn"));
                }
                else keyArray = Encoding.UTF8.GetBytes("2$Powersoft.vn");
                var tdes = new TripleDESCryptoServiceProvider
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch { return toEncrypt; }
        }

        public string DecryptString(string toDecrypt, bool useHashing)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
                if (useHashing)
                {
                    var hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes("2$Powersoft.vn"));
                }
                else keyArray = Encoding.UTF8.GetBytes("2$Powersoft.vn");
                var tdes = new TripleDESCryptoServiceProvider
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return Encoding.UTF8.GetString(resultArray);
            }
            catch { return toDecrypt; }
        }

        public string MyServerName()
        {
            return Environment.MachineName;
        }

        #region getdata

        public DataTable ExecuteQuery(string query)
        {
            DataTable table = new DataTable();
            try
            {
                if (this.sqlConnection != null)
                {
                    this.sqlConnection.Close();
                    this.sqlConnection.Dispose();
                }
                this.sqlConnection = new SqlConnection(this.connectionstring);
                this.sqlConnection.Open();
                this.sqlDataAdapter = new SqlDataAdapter(query, this.connectionstring);
                this.sqlDataAdapter.Fill(table);
            }
            catch (Exception ex)
            {
                table = null;
                throw new Exception(ex.Message);
            }
            finally
            {
                this.sqlConnection.Close();
                this.sqlConnection.Dispose();
            }
            return table;
        }
        public DataSet ExecuteDatasetQuery(string query)
        {
            DataSet dataset = new DataSet();
            try
            {
                if (this.sqlConnection != null)
                {
                    this.sqlConnection.Close();
                    this.sqlConnection.Dispose();
                }
                this.sqlConnection = new SqlConnection(this.connectionstring);
                this.sqlConnection.Open();
                this.sqlDataAdapter = new SqlDataAdapter(query, this.sqlConnection);
                this.sqlDataAdapter.Fill(dataset);
            }
            catch (Exception ex)
            {
                dataset = null;
                throw new Exception(ex.Message);
            }
            finally
            {
                this.sqlConnection.Dispose();
                this.sqlConnection.Close();
            }
            return dataset;
        }

        #endregion

        #region Insert data

        public int ExecuteNonQuery(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            int retval = 0;
            if (this.sqlConnection != null)
            {
                this.sqlConnection.Close();
                this.sqlConnection.Dispose();
            }
            this.sqlConnection = new SqlConnection(this.connectionstring);
            this.sqlConnection.Open();
            SqlCommand cmd = new SqlCommand();
            bool mustCloseConnection = false;
            this.PrepareCommand(cmd, null, commandType, commandText, commandParameters, out mustCloseConnection);
            retval = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            if (this.sqlConnection != null)
            {
                this.sqlConnection.Close();
                this.sqlConnection.Dispose();
            }
            return retval;
        }
        public DataSet CallProcedure(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            DataSet dsResult = new DataSet();
            if (this.sqlConnection != null)
            {
                this.sqlConnection.Close();
                this.sqlConnection.Dispose();
            }
            SqlCommand cmd = new SqlCommand();
            bool mustCloseConnection = false;
            this.sqlConnection = new SqlConnection(this.connectionstring);
            this.sqlConnection.Open();
            this.PrepareCommand(cmd, null, commandType, commandText, commandParameters, out mustCloseConnection);
            this.sqlDataAdapter = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            this.sqlDataAdapter.Fill(dsResult);
            cmd.Parameters.Clear();
            if (this.sqlConnection != null)
            {
                this.sqlConnection.Close();
                this.sqlConnection.Dispose();
            }
            return dsResult;
        }
        public DataTable CallProcedureTable(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            DataTable dtResult = new DataTable();
            if (this.sqlConnection != null)
            {
                this.sqlConnection.Close();
                this.sqlConnection.Dispose();
            }
            this.sqlConnection = new SqlConnection(this.connectionstring);
            this.sqlConnection.Open();
            SqlCommand cmd = new SqlCommand();
            bool mustCloseConnection = false;
            this.PrepareCommand(cmd, null, commandType, commandText, commandParameters, out mustCloseConnection);
            this.sqlDataAdapter = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            this.sqlDataAdapter.Fill(dtResult);
            cmd.Parameters.Clear();
            if (this.sqlConnection != null)
            {
                this.sqlConnection.Close();
                this.sqlConnection.Dispose();
            }
            return dtResult;
        }
        private void PrepareCommand(SqlCommand command, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, out bool mustCloseConnection)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");
            if (this.sqlConnection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                this.sqlConnection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }
            command.Connection = this.sqlConnection;
            command.CommandText = commandText;
            if (transaction != null)
            {
                if (transaction.Connection == null)
                    throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }
            command.CommandType = commandType;
            if (commandParameters != null)
            {
                this.AttachParameters(command, commandParameters);
            }
            return;
        }
        private void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                foreach (SqlParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        if ((p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Input || p.Direction == ParameterDirection.Output) &&
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }

        #endregion

        #region  Doc Ilist
        public SqlDataReader ExecuteReader(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            try
            {
                if (this.sqlConnection != null)
                {
                    this.sqlConnection.Close();
                    this.sqlConnection.Dispose();
                }
                this.sqlConnection = new SqlConnection(this.connectionstring);
                this.sqlConnection.Open();
                return ExecuteReader(null, commandType, commandText, commandParameters, ConnectionOwnership.Internal);
            }
            catch
            {
                if (this.sqlConnection != null)
                {
                    this.sqlConnection.Close();
                    this.sqlConnection.Dispose();
                }
                throw;
            }
            finally
            {

            }
        }
        private SqlDataReader ExecuteReader(SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, ConnectionOwnership connectionOwnership)
        {
            bool mustCloseConnection = false;
            SqlCommand cmd = new SqlCommand();
            try
            {
                this.PrepareCommand(cmd, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
                SqlDataReader dataReader;
                if (connectionOwnership == ConnectionOwnership.External)
                {
                    dataReader = cmd.ExecuteReader();
                }
                else
                {
                    dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                bool canClear = true;
                foreach (SqlParameter commandParameter in cmd.Parameters)
                {
                    if (commandParameter.Direction != ParameterDirection.Input)
                        canClear = false;
                }
                if (canClear)
                {
                    cmd.Parameters.Clear();
                }
                if (mustCloseConnection)
                {
                    this.sqlConnection.Close();
                    this.sqlConnection.Dispose();
                }
                return dataReader;
            }
            catch
            {
                if (mustCloseConnection)
                {
                    this.sqlConnection.Close();
                    this.sqlConnection.Dispose();
                }
                throw;
            }
        }
        public string ExecuteReaderProcedure(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (this.connectionstring == null || this.connectionstring.Length == 0)
                throw new ArgumentNullException("connectionString");
            try
            {
                if (this.sqlConnection != null)
                {
                    this.sqlConnection.Close();
                    this.sqlConnection.Dispose();
                }
                this.sqlConnection = new SqlConnection(this.connectionstring);
                this.sqlConnection.Open();
                return ExecuteReaderProcedure(null, commandType, commandText, commandParameters, ConnectionOwnership.External);
            }
            catch
            {
                if (this.sqlConnection != null)
                {
                    this.sqlConnection.Close();
                    this.sqlConnection.Dispose();
                }
                throw new Exception();
            }
        }
        private string ExecuteReaderProcedure(SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, ConnectionOwnership connectionOwnership)
        {
            bool mustCloseConnection = false;
            string result = string.Empty;
            SqlCommand cmd = new SqlCommand();
            try
            {
                this.PrepareCommand(cmd, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
                SqlDataReader dataReader;
                if (connectionOwnership == ConnectionOwnership.External)
                {
                    dataReader = cmd.ExecuteReader();
                }
                else
                {
                    dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                bool canClear = true;
                foreach (SqlParameter commandParameter in cmd.Parameters)
                {
                    if (commandParameter.Direction != ParameterDirection.Input)
                    {
                        result = commandParameter.Value.ToString();
                        canClear = false;
                    }
                }
                if (canClear)
                {
                    cmd.Parameters.Clear();
                }
                if (!dataReader.IsClosed)
                {
                    dataReader.Close();
                    dataReader.Dispose();
                }
                if (this.sqlConnection != null)
                {
                    this.sqlConnection.Close();
                    this.sqlConnection.Dispose();
                }
                return result;
            }
            catch
            {
                if (mustCloseConnection)
                {
                    this.sqlConnection.Close();
                    this.sqlConnection.Dispose();
                }
                throw;
            }
        }
        private enum ConnectionOwnership
        {
            /// <summary>Connection is owned and managed by SqlHelper</summary>
            Internal,
            /// <summary>Connection is owned and managed by the caller</summary>
            External
        }
        #endregion

    }
}
