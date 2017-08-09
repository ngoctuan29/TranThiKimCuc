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
    public class Fee_NoteBookBLL
    {
        public static DataTable TableListNoteBookALL()
        {
            return Fee_NoteBookDAL.TableListNoteBookALL();
        }
        public static List<Fee_NoteBookInf> ListNoteBook(int rowid)
        {
            return Fee_NoteBookDAL.ListNoteBook(rowid);
        }
        public static bool InsFee_NoteBook(Fee_NoteBookInf info)
        {
            return Fee_NoteBookDAL.InsFee_NoteBook(info);
        }
        public static bool DelFee_NoteBook(int rowid)
        {
            return Fee_NoteBookDAL.DelFee_NoteBook(rowid);
        }
    } 
}
