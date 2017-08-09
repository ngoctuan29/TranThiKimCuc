using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClinicLibrary;

namespace Ps.Clinic.Reports
{
    public partial class rptHoSoKhamBenhNgoaiTru : DevExpress.XtraReports.UI.XtraReport
    {

        public rptHoSoKhamBenhNgoaiTru()
        {
            InitializeComponent();
        }

        private void rptHoSoKhamBenh_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.txtDateprint.Text = " Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
            string ssoyte = string.Empty, simage = string.Empty, names = string.Empty, saddress = string.Empty, sphone = string.Empty, semail = string.Empty, sckhoa = string.Empty, sothers = string.Empty, simgcopyright = string.Empty;
            Utils.GetClinicInfo(ref ssoyte, ref simage, ref names, ref saddress, ref sphone, ref semail, ref sckhoa, ref sothers, ref simgcopyright);
            this.lbNames.Text = names;
        }

        private void lbNgaySinh_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.lbNgaySinh.Text = this.lbNgaySinh.Text.ToString().Length >= 10 ? this.lbNgaySinh.Text.Substring(0, 1) : string.Empty;
        }

        private void lbNgaySinh01_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.lbNgaySinh01.Text = this.lbNgaySinh01.Text.ToString().Length >= 10 ? this.lbNgaySinh01.Text.Substring(1, 1) : string.Empty;
        }

        private void lbThangSinh_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.lbThangSinh.Text = this.lbThangSinh.Text.ToString().Length >= 10 ? this.lbThangSinh.Text.Substring(3, 1) : string.Empty;
        }

        private void lbThangSinh01_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.lbThangSinh01.Text = this.lbThangSinh01.Text.ToString().Length >= 10 ? this.lbThangSinh01.Text.Substring(4, 1) : string.Empty;
        }

        private void lbNamSinh_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.lbNamSinh.Text = this.lbNamSinh.Text.ToString().Length >= 10 ? this.lbNamSinh.Text.Substring(6, 1) : string.Empty;
        }

        private void lbNamSinh01_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.lbNamSinh01.Text = this.lbNamSinh01.Text.ToString().Length >= 10 ? this.lbNamSinh01.Text.Substring(7, 1) : string.Empty;
        }

        private void lbNamSinh02_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.lbNamSinh02.Text = this.lbNamSinh02.Text.ToString().Length >= 10 ? this.lbNamSinh02.Text.Substring(8, 1) : string.Empty;
        }

        private void lbNamSinh03_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.lbNamSinh03.Text = this.lbNamSinh03.Text.ToString().Length >= 10 ? this.lbNamSinh03.Text.Substring(9, 1) : string.Empty;
        }

        private void lbTuoi01_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.lbTuoi01.Text = this.lbTuoi01.Text.ToString().Length >= 2 ? this.lbTuoi01.Text.Substring(0, 1) : string.Empty;
        }

        private void lbTuoi02_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.lbTuoi02.Text = (this.lbTuoi02.Text.Length >= 2 && this.lbTuoi02.Text != string.Empty) ? this.lbTuoi02.Text.Substring(1, 1) : string.Empty;
        }

        private void chkYTe_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.chkYTe.Text = this.chkYTe.Text.Equals("True") ? "x" : string.Empty;
        }

        private void chkTuDen_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.chkTuDen.Text = this.chkTuDen.Text.Equals("True") ? "x" : string.Empty;
        }

        private void chkNam_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.chkNam.Text = this.chkNam.Text.Equals("1") ? "x" : string.Empty;
        }

        private void chkNu_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.chkNu.Text = this.chkNu.Text.Equals("0") ? "x" : string.Empty;
        }

        private void chkBHYT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.chkBHYT.Text = this.chkBHYT.Text.Equals("1") ? "x" : string.Empty;
        }

        private void chkThuPhi_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.chkThuPhi.Text = (this.chkThuPhi.Text.Equals("2") || this.chkThuPhi.Text.Equals("6")) ? "x" : string.Empty;
        }

        private void chkMien_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.chkMien.Text = this.chkMien.Text.Equals("5") ? "x" : string.Empty;
        }

        private void chkKhac_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.chkKhac.Text = this.chkKhac.Text.Equals("7") ? "x" : string.Empty;
        }

        private void lbNgayVao_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.lbNgayVao.Text = this.lbNgayVao.Text.Length >= 10 ? this.lbNgayVao.Text.Substring(0, 2) : string.Empty;
        }

        private void lbThangVao_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.lbThangVao.Text = this.lbThangVao.Text.Length >= 10 ? this.lbThangVao.Text.Substring(3, 2) : string.Empty;
        }

        private void lbNamVao_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.lbNamVao.Text = this.lbNamVao.Text.Length >= 10 ? this.lbNamVao.Text.Substring(6, 4) : string.Empty;
        }
    }
}
