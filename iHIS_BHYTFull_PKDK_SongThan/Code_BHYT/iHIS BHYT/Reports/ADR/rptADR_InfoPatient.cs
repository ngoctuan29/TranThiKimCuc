using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Ps.Clinic.Reports
{
    public partial class rptADR_InfoPatient : DevExpress.XtraReports.UI.XtraReport
    {
        private DateTime from, to;
        private DataTable dtOld, dtSex;

        private void rptADR_InfoPatients_Tuoi_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblDate.Text = "Từ ngày " + this.from.ToString("dd/MM/yyyy") + " đến ngày " + this.to.ToString("dd/MM/yyyy");
            //ket luan
            DataRow[] drMaxOld = dtOld.Select("[SoLuong] = MAX([SoLuong])");
            txtNhanXetTuoi.Text = "Nhận thấy, ADR thường được ghi nhận nhiều nhất ở nhóm đối tượng " + drMaxOld[0][1].ToString() + " chiếm " + drMaxOld[0][3].ToString() + "%";

            DataRow[] drMaxSex = dtSex.Select("[SoLuong] = MAX([SoLuong])");
            txtNhanXetGioiTinh.Text = "Nhận thấy, ADR thường được ghi nhận nhiều nhất ở giới " + drMaxSex[0][1].ToString() + " chiếm " + drMaxSex[0][3].ToString() + "%";
        }

        public rptADR_InfoPatient(DateTime _from, DateTime _to, DataTable _dtOld, DataTable _dtSex)
        {
            this.from = _from;
            this.to = _to;
            this.dtOld = _dtOld;
            this.dtSex = _dtSex;
            InitializeComponent();
        }

        private TopMarginBand topMarginBand1;

        //private void InitializeComponent()
        //{
        //    this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
        //    this.detailBand1 = new DevExpress.XtraReports.UI.DetailBand();
        //    this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
        //    ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        //    // 
        //    // topMarginBand1
        //    // 
        //    this.topMarginBand1.HeightF = 100F;
        //    this.topMarginBand1.Name = "topMarginBand1";
        //    // 
        //    // detailBand1
        //    // 
        //    this.detailBand1.HeightF = 100F;
        //    this.detailBand1.Name = "detailBand1";
        //    // 
        //    // bottomMarginBand1
        //    // 
        //    this.bottomMarginBand1.HeightF = 100F;
        //    this.bottomMarginBand1.Name = "bottomMarginBand1";
        //    // 
        //    // rptADR_InfoPatients
        //    // 
        //    this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
        //    this.topMarginBand1,
        //    this.detailBand1,
        //    this.bottomMarginBand1});
        //    this.Version = "15.2";
        //    ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        //}

        private DetailBand detailBand1;
        private BottomMarginBand bottomMarginBand1;
    }
}
