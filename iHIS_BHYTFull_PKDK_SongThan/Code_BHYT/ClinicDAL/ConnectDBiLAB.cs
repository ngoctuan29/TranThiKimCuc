using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Xml;
using System.Windows.Forms;

namespace ClinicDAL
{
    public class ConnectDBiLAB
    {
        public string sconnection = string.Empty;
        public SqlConnection sqlConnection;
        private SqlDataAdapter sqlDataAdapter;

        public ConnectDBiLAB()
        {
            this.sqlConnection = new SqlConnection();
            this.GetConfig();
        }

        public void GetConfig()
        {
            XmlDocument XmlDOcument = ReadXml((Application.StartupPath) + "\\xml\\configiLAB.xml");
            XmlElement XmlElement = XmlDOcument.DocumentElement;
            try
            {
                if (XmlElement.SelectSingleNode("costatus").InnerText == "true")
                {
                    sconnection = @"Data Source=" + XmlElement.SelectSingleNode("servername").InnerText + ";Initial Catalog=" + XmlElement.SelectSingleNode(";Integrated Security=True;");
                }
                else
                {
                    sconnection = "Data Source=" + XmlElement.SelectSingleNode("servername").InnerText + ";Initial Catalog=" + XmlElement.SelectSingleNode("database").InnerText + ";User Id=" + XmlElement.SelectSingleNode("username").InnerText + ";Password=" + XmlElement.SelectSingleNode("password").InnerText + "; Integrated Security=False;";
                }
                sqlConnection.ConnectionString = sconnection;
            }
            catch
            {
                MessageBox.Show("Không thể kết nối được cơ sở dữ liệu! \n Lỗi: kết nối", "Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public XmlDocument ReadXml(String fileName)
        {
            XmlDocument XmlDocument = new XmlDocument();
            try
            {
                XmlDocument.Load(fileName);
            }
            catch
            {
                MessageBox.Show("Không đọc được hoặc không tồn tại tập tin cấu hình " + fileName, "Bệnh viện điện tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return XmlDocument;
        }
                
        public DataTable ExecuteQuery(string query)
        {
            DataTable table = new DataTable();
            this.sqlConnection = new SqlConnection(this.sconnection);
            try
            {
                this.sqlConnection.Open();
                this.sqlDataAdapter = new SqlDataAdapter(query, this.sqlConnection);
                this.sqlDataAdapter.Fill(table);
            }
            catch (Exception)
            {
                table = null;
            }
            finally
            {
                this.sqlConnection.Close();
                this.sqlConnection.Dispose();
            }
            return table;
        }

        public DataSet ExecuteQuery_ds(string s_sql)
        {
            DataSet dataset = new DataSet();
            try
            {
                this.sqlDataAdapter = new SqlDataAdapter(s_sql, this.sqlConnection);
                this.sqlDataAdapter.Fill(dataset);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.sqlConnection.Dispose();
                this.sqlConnection.Close();
            }
            return dataset;
        }
        
        #region Insert data

        public int ExecuteNonQuery(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            int retval = 0;
            if (this.sqlConnection == null)
                throw new ArgumentNullException("connection");
            SqlCommand cmd = new SqlCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, this.sqlConnection, null, commandType, commandText, commandParameters, out mustCloseConnection);
            retval = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            if (mustCloseConnection)
            {
                this.sqlConnection.Close();
                this.sqlConnection.Dispose();
            }
            return retval;
        }

        public DataSet CallProcedure(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            DataSet dsResult = new DataSet();
            if (this.sqlConnection == null)
                throw new ArgumentNullException("connection");
            SqlCommand cmd = new SqlCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, this.sqlConnection, null, commandType, commandText, commandParameters, out mustCloseConnection);
            sqlDataAdapter = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            sqlDataAdapter.Fill(dsResult);
            cmd.Parameters.Clear();
            if (mustCloseConnection)
            {
                this.sqlConnection.Close();
                this.sqlConnection.Dispose();
            }
            return dsResult;
        }
        public DataTable CallProcedureTable(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            DataTable dtResult = new DataTable();
            if (sqlConnection == null)
                throw new ArgumentNullException("connection");
            SqlCommand cmd = new SqlCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, sqlConnection, null, commandType, commandText, commandParameters, out mustCloseConnection);
            sqlDataAdapter = new SqlDataAdapter(cmd);
            cmd.CommandTimeout = 600;
            cmd.ExecuteNonQuery();
            sqlDataAdapter.Fill(dtResult);
            cmd.Parameters.Clear();
            if (mustCloseConnection)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return dtResult;
        }
        private void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, out bool mustCloseConnection)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");
            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }
            command.Connection = connection;
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
                AttachParameters(command, commandParameters);
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
            if (sconnection == null || sconnection.Length == 0) throw new ArgumentNullException("connectionString");
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(sconnection);
                connection.Open();
                return ExecuteReader(connection, null, commandType, commandText, commandParameters, SqlConnectionOwnership.Internal);
            }
            catch
            {
                if (connection != null) connection.Close();
                throw;
            }
        }

        private SqlDataReader ExecuteReader(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, SqlConnectionOwnership connectionOwnership)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            bool mustCloseConnection = false;
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
                SqlDataReader dataReader;
                if (connectionOwnership == SqlConnectionOwnership.External)
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

                return dataReader;
            }
            catch
            {
                if (mustCloseConnection)
                    connection.Close();
                throw;
            }
        }

        public string ExecuteReaderProcedure(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (sconnection == null || sconnection.Length == 0) throw new ArgumentNullException("connectionString");
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(sconnection);
                connection.Open();
                return ExecuteReaderProcedure(connection, null, commandType, commandText, commandParameters, SqlConnectionOwnership.External);
            }
            catch
            {
                if (connection != null) connection.Close();
                throw;
            }

        }

        private string ExecuteReaderProcedure(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, SqlConnectionOwnership connectionOwnership)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            bool mustCloseConnection = false;
            string sResult = "";
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
                SqlDataReader dataReader;
                if (connectionOwnership == SqlConnectionOwnership.External)
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
                        sResult = commandParameter.Value.ToString();
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
                return sResult;
            }
            catch
            {
                if (mustCloseConnection)
                    connection.Close();
                throw;
            }
        }

        private enum SqlConnectionOwnership
        {
            Internal,
            External
        }
        #endregion
    }
}
