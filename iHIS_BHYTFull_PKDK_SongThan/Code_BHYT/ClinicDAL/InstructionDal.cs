using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using ClinicModel;

namespace ClinicDAL
{
    public class InstructionDal
    {
        public static List<InstructionInf> ListInstruction(decimal dId)
        {
            ConnectDB cn = new ConnectDB();
            List<InstructionInf> list = new List<InstructionInf>();
            try
            {
                string sql = "";
                if (dId != 0)
                {
                    sql = "select Rowid,InstructionName from Instruction where Rowid in({0}) order by Rowid asc";
                }
                else
                {
                    sql = "select Rowid,InstructionName from Instruction order by Rowid asc";
                }
                IDataReader ireader = cn.ExecuteReader(CommandType.Text, string.Format(sql, dId), null);
                while (ireader.Read())
                {
                    InstructionInf inf = new InstructionInf();
                    inf.RowID = ireader.GetDecimal(0);
                    inf.InstructionName = ireader.GetString(1);
                    list.Add(inf);
                }
                if (!ireader.IsClosed)
                {
                    ireader.Close();
                    ireader.Dispose();
                }
            }
            catch { list = null; }
            return list;
        }

        public static DataTable DataTableInstruction(decimal dId)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                string sql = "";
                if (dId != 0)
                {
                    sql = "select Rowid,InstructionName from Instruction where Rowid in({0}) order by Rowid asc";
                }
                else
                {
                    sql = "select Rowid,InstructionName from Instruction order by Rowid asc";
                }
                return cn.ExecuteQuery(string.Format(sql, dId));
            }
            catch { return null; }
        }

        public static Int32 InsInstruction(InstructionInf info)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[0].Value = info.RowID;
                param[1] = new SqlParameter("@InstructionName", SqlDbType.NVarChar, 250);
                param[1].Value = info.InstructionName;
                if (cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Ins_Instruction", param) >= 1)
                {
                    return 1;
                }
                else
                    return -1;
            }
            catch  { return -2; }
        }

        public static Int32 DelInstruction(decimal dId)
        {
            ConnectDB cn = new ConnectDB();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@iresult", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@RowID", SqlDbType.Decimal);
                param[1].Value = dId;
                return cn.ExecuteNonQuery(CommandType.StoredProcedure, "pro_Del_Instruction", param);
            }
            catch { return -1; }
        }

    }
}
