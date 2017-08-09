using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class Fee_NoteBookInf
    {
        public int RowID { get; set; }
        public string Symbol { get; set; }
        public string NoteBookName { get; set; }
        public int FromNumber { get; set; }
        public int ToNumber { get; set; }
        public int WriteNumber { get; set; }
        public int NoteType { get; set; }
        public int Hide { get; set; }
        public string ShiftWork { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeCodeUpd { get; set; }
        public string UDate { get; set; }
    }
}
