using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Globalization;
using ClinicBLL;

namespace Ps.Clinic.Reports.ADR
{
    public partial class rptTongKetSST : DevExpress.XtraReports.UI.XtraReport
    {
        private DateTime from, to;
        private DataTable dtHinhThuc, dtPhanLoai, dtKhoaPhong;

        public rptTongKetSST(DateTime _from, DateTime _to, DataTable _dtHinhThuc, DataTable _dtPhanLoai, DataTable _dtKhoaPhong)
        {
            this.from = _from;
            this.to = _to;
            this.dtHinhThuc = _dtHinhThuc;
            this.dtPhanLoai = _dtPhanLoai;
            this.dtKhoaPhong = _dtKhoaPhong;
            InitializeComponent();
        }

        private void rptTongKetSST_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblFrom.Text = this.from.ToString("dd/MM/yyyy");
            lblTo.Text = this.to.ToString("dd/MM/yyyy");
            try
            {
                int tong = SSTBLL.GetTongLuotKham(this.from, this.to);
                lblCount.Text = String.Format(CultureInfo.InvariantCulture, "{0:#,#}", Convert.ToDouble(dtKhoaPhong.Compute("Sum(SoLuong)", "").ToString()));

                double tyle = Convert.ToDouble(dtKhoaPhong.Compute("Sum(SoLuong)", "").ToString()) * 100 / tong;
                lbltongluot.Text = tong.ToString("N0");
                lbltyle.Text = String.Format("{0:0.00}", tyle) + "%";
                if (this.dtHinhThuc.Rows.Count > 0)
                {
                    DataRow[] drMaxHinhThuc = dtHinhThuc.Select("[SoLuong] = MAX([SoLuong])");
                    txtNhanXetHinhThuc.Text = "Nhận thấy, " + drMaxHinhThuc[0][1].ToString() + " chiếm tỷ lệ cao nhất "
                        + String.Format(CultureInfo.InvariantCulture, "{0:n2}", Convert.ToDouble(drMaxHinhThuc[0][3].ToString()))  + 
                        "% (" + String.Format(CultureInfo.InvariantCulture, "{0:#,#}", Convert.ToDouble(drMaxHinhThuc[0][2].ToString())) + " trường hợp).";
                }

                if (this.dtPhanLoai.Rows.Count > 0)
                {
                    DataRow[] drMaxPhanLoai = dtPhanLoai.Select("[SoLuong] = MAX([SoLuong])");
                    txtNhanXetPhanLoai.Text = "Nhận thấy, Nhóm " + drMaxPhanLoai[0][2].ToString() + " chiếm tỷ lệ cao nhất "
                        + String.Format(CultureInfo.InvariantCulture, "{0:n2}", Convert.ToDouble(drMaxPhanLoai[0][4].ToString()))  + 
                        "% (" + Convert.ToDouble(drMaxPhanLoai[0][3].ToString()) + " trường hợp).";
                }
               
                if(this.dtKhoaPhong.Rows.Count > 0)
                {
                    DataRow[] drMaxKhoaPhong = dtKhoaPhong.Select("[SoLuong] = MAX([SoLuong])");
                    txtNhanXetKhoaPhong.Text = "Nhận thấy, " + drMaxKhoaPhong[0][1].ToString() + " có sai sót liên quan đến thuốc nhiều nhất chiếm tỷ lệ "
                        + String.Format(CultureInfo.InvariantCulture, "{0:n2}", Convert.ToDouble(drMaxKhoaPhong[0][3].ToString()))  +
                        " % (" + Convert.ToDouble(drMaxKhoaPhong[0][2].ToString()) + " trường hợp). Tuy nhiên, các sai sót trên đã được bộ phận giám định đơn thuốc phát hiện kịp thời và liên hệ bác sĩ để chỉnh sửa nhằm phòng tránh các sai sót liên quan đến thuốc, đây là đặc điểm quan trọng nhất và vì vậy việc ngăn chặn và giảm thiểu sai sót liên quan đến thuốc trở thành một mục tiêu quan trọng trong chính sách an toàn thuốc của mỗi Quốc gia cũng như của các cơ sở y tế.";
                }
            }
            catch { txtNhanXetHinhThuc.Text = txtNhanXetPhanLoai.Text = txtNhanXetKhoaPhong.Text = string.Empty; }
           
        }

    }
}
