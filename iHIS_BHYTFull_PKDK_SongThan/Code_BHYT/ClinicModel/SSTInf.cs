using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicModel
{
    public class SaiSot_PhieuBaoCaoInf
    {
        public int Id { get; set; }

        public int IdNoiBaoCao { get; set; }

        public string NoiBaoCao { get; set; }

        public string MaSoBaoCao { get; set; }

        public DateTime NgayNhapPhieu { get; set; }

        public string Ghichu { get; set; }

        public string TongLuotKham { get; set; }

    }
    public class SaiSot_DanhSach
    {
        public int Id { get; set; }
        public int IdPhieuBaoCao { get; set; }
        public DateTime NgayBaoCao { get; set; }
        public string NguoiBaoCao { get; set; }
        public string ThoiGianXayRaSuCo { get; set; }
        public string KhoaPhong_DiaDiemXayRa { get; set; }
        public string MoTaSuCo { get; set; }
        public string HauQuaXayRa { get; set; }
        public string CachXuTriTucThoi { get; set; }
        public string CapBaoCao { get; set; }
        public string GiaiPhapKhacPhuc { get; set; }
        public string TrachNhiem { get; set; }
        public string DanhGiaLai { get; set; }
        public string Ghichu { get; set; }
        public string HinhThucSaiSot { get; set; }
        public string PhanLoai { get; set; }
    }
}
