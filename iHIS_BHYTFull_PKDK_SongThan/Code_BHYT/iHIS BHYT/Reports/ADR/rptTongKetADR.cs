using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DevExpress.XtraCharts;
using System.Globalization;
using System.Linq;

namespace Ps.Clinic.Reports.ADR
{
    public partial class rptTongKetADR : DevExpress.XtraReports.UI.XtraReport
    {
        private DateTime from, to;
        private DataTable dtTungThang;
        private DataTable dtTuoi;
        private DataTable dtGioiTinh;
        private DataTable dtDuongDung;
        private DataTable dtATC;
        private DataTable NghiNgo;


        public rptTongKetADR(DateTime _from, DateTime _to, DataTable _dtTungThang, DataTable _dtTuoi, DataTable _dtGioiTinh, DataTable _dtDuongDung, DataTable _dtATC, DataTable _NghiNgo)
        {
            this.from = _from;
            this.to = _to;
            this.dtTungThang = _dtTungThang;
            this.dtTuoi = _dtTuoi;
            this.dtGioiTinh = _dtGioiTinh;
            this.dtDuongDung = _dtDuongDung;
            this.dtATC = _dtATC;
            this.NghiNgo = _NghiNgo;
            InitializeComponent();
        }


        private void rptTongKetADR_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                lblFrom.Text = this.from.ToString("dd/MM/yyyy");
                lblTo.Text = this.to.ToString("dd/MM/yyyy");
                lblCount.Text = String.Format(CultureInfo.InvariantCulture, "{0:#,#}", Convert.ToDouble(dtTungThang.Compute("Sum(SoLuong)", "").ToString()));

                if (dtTungThang.Rows.Count > 0)
                {
                    this.chart_Report.DataSource = this.dtTungThang;
                    Series series1 = new Series("Số lượng", ViewType.Line);
                    chart_Report.Series.Add(series1);
                    series1.ArgumentDataMember = "Thang";
                    series1.ValueDataMembers.AddRange(new string[] { "SoLuong" });
                    DataRow[] drMaxTungThang = this.dtTungThang.Select("[SoLuong] = MAX([SoLuong])");
                    DataRow[] drMinTungThang = this.dtTungThang.Select("[SoLuong] = Min([SoLuong])");
                    this.txtNhanXetTungThang.Text = "Số lượng báo cáo ARD ghi nhận ít nhất vào tháng " + drMinTungThang[0][1].ToString() + " (" +
                        String.Format(CultureInfo.InvariantCulture, "{0:#,#}", Convert.ToDouble((drMinTungThang[0][2]).ToString())) +
                    ") Số lượng báo cáo ARD nhiều nhất vào tháng " + drMaxTungThang[0][1].ToString() + " (" +
                    String.Format(CultureInfo.InvariantCulture, "{0:#,#}", Convert.ToDouble((drMaxTungThang[0][2]).ToString())) + ")";
                }
                

                if(this.dtTuoi.Rows.Count > 0)
                {
                    DataRow[] drMaxOld = this.dtTuoi.Select("[SoLuong] = MAX([SoLuong])");
                    this.txtNhanXetTuoi.Text = "Nhận thấy, ADR thường được ghi nhận nhiều nhất ở nhóm đối tượng " + drMaxOld[0][1].ToString() + " chiếm " + String.Format(CultureInfo.InvariantCulture, "{0:n2}", Convert.ToDouble(drMaxOld[0][3].ToString())) + "%";
                }
                

                if(this.dtGioiTinh.Rows.Count > 0)
                {
                    DataRow[] drMaxSex = this.dtGioiTinh.Select("[SoLuong] = MAX([SoLuong])");
                    this.txtNhanXetGioiTinh.Text = "Nhận thấy, ADR thường được ghi nhận nhiều nhất ở giới " + drMaxSex[0][1].ToString() + " chiếm " + String.Format(CultureInfo.InvariantCulture, "{0:n2}", Convert.ToDouble(drMaxSex[0][3].ToString())) + "%";
                }

                if(this.dtDuongDung.Rows.Count > 0)
                {
                    DataRow[] drMaxDuongDung = dtDuongDung.Select("[SoLuong] = MAX([SoLuong])");
                    string klDuongDung = "Nhận thấy, phản ứng có hại xảy ra nhiều nhất khi dùng thuốc ";
                    for (int i = 0; i < drMaxDuongDung.Count(); i++)
                    {
                        klDuongDung += drMaxDuongDung[i][1].ToString() + " ,";
                    }
                    klDuongDung = klDuongDung.TrimEnd(',');
                    klDuongDung += "chiếm " + String.Format(CultureInfo.InvariantCulture, "{0:n2}", Convert.ToDouble(drMaxDuongDung[0][3].ToString())) + "%";
                    txtDuongDung.Text = klDuongDung;
                }
                

                if(this.dtATC.Rows.Count > 0)
                {
                    DataRow[] drMaxATC = dtATC.Select("[SoLuong] = MAX([SoLuong])");
                    string klATC = "Nhận thấy, nhóm ";
                    for (int i = 0; i < drMaxATC.Count(); i++)
                    {
                        klATC += drMaxATC[i][2].ToString() + " ,";
                    }
                    klATC = klATC.TrimEnd(',');
                    klATC += "ghi nhận nhiều nhất, chiếm tỷ lệ " + String.Format(CultureInfo.InvariantCulture, "{0:n2}", Convert.ToDouble(drMaxATC[0][4].ToString())) + "%";
                    txtNhanXetATC.Text = klATC;
                }
                
            }
            catch { txtNhanXetTungThang.Text = txtNhanXetTuoi.Text = txtNhanXetGioiTinh.Text = txtDuongDung.Text = txtNhanXetATC.Text = string.Empty; }
            
        }

    }
}
