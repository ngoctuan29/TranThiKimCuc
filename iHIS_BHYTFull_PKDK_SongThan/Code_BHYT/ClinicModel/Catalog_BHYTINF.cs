using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class Service_BHYTINF
    {
        public string MaTuongDuong { get; set; }
        public string Ma_TT50 { get; set; }
        public string Ten_TT50 { get; set; }
        public string PhanTuyen { get; set; }
        public string SoQD { get; set; }
        public string Ten_TT43_TT50 { get; set; }
        public string MaPT_TT { get; set; }
        public int Hide { get; set; }
        public string Ma_TT37 { get; set; }
        public string Ten_TT37 { get; set; }
        public int STT { get; set; }
        public string MaCK { get; set; }
        public string Note { get; set; }
        public string NgayKy { get; set; }
        public string MaCKTT50 { get; set; }
        public string MaTT03_04 { get; set; }
        public string MaQD5084 { get; set; }
    }
    public class DMLoaiPT_TTINF
    {
        public string MaPT_TT { get; set; }
        public string Ten { get; set; }
        public int Hide { get; set; }
    }
    public class DMChuyenKhoa_BHYTINF
    {
        public string MaCK { get; set; }
        public int STT { get; set; }
        public string Ten { get; set; }
        public int Hide { get; set; }
    }
    public class ServiceGroup_BHYTINF
    {
        public int GroupID { get; set; }
        public int STT { get; set; }
        public string GroupName { get; set; }
        public int Hide { get; set; }
    }
}
