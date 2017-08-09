using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class DepartmentInf
    {
        public int RowID { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string ServiceGroupCode { get; set; }
        public Int32 Hide { get; set; }
        public Int32 IdBv { get; set; }
        public string KBHYT { get; set; }
    }
    public class DepartmentBHYTInf
    {
        public int STT { get; set; }
        public string TenKhoa { get; set; }
        public string MaKhoa { get; set; }
       
    }
    public class LoaiKhoaTInf
    {
        public int Id { get; set; }
        public string TenLoai { get; set; }

    }
}
