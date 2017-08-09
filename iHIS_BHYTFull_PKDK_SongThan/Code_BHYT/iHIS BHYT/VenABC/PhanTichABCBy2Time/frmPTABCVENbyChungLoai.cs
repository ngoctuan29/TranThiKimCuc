﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;

namespace Ps.Clinic.VenABC.PhanTichABCBy2Time
{
    public partial class frmPTABCVENbyChungLoai : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbDanhSach = new DataTable();
        DateTime TuNgay1;
        DateTime DenNgay1;
        DateTime TuNgay2;
        DateTime DenNgay2;
        public frmPTABCVENbyChungLoai(DataTable _tbDanhSach, DateTime _TuNgay1, DateTime _DenNgay1, DateTime _TuNgay2, DateTime _DenNgay2)
        {
            this.tbDanhSach = _tbDanhSach;
            this.TuNgay1 = _TuNgay1;
            this.DenNgay1 = _DenNgay1;
            this.TuNgay2 = _TuNgay2;
            this.DenNgay2 = _DenNgay2;
            InitializeComponent();
        }

        private void frmPTABCVENbyChungLoai_Load(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = "(so sánh T1:(" + this.TuNgay1.ToShortDateString() + " - " + this.DenNgay1.ToShortDateString() + ") và T2:(" + this.TuNgay2.ToShortDateString() + " - " + this.DenNgay2.ToShortDateString() + "))";

                string selectNhom1T1 = "([ABC] = 'A' and [iTime] = 1 and [VEN] = 'V') or ([ABC] = 'A' and [iTime] = 1 and [VEN] = 'E') or ([ABC] = 'A' and [iTime] = 1 and [VEN] = 'N') or ([ABC] = 'B' and [iTime] = 1 and [VEN] = 'V') or ([ABC] = 'C' and [iTime] = 1 and [VEN] = 'V')";
                double SlNhom1T1 = this.tbDanhSach.Select(selectNhom1T1).Count();

                string selectNhom2T1 = "([ABC] = 'B' and [iTime] = 1 and [VEN] = 'E') or ([ABC] = 'B' and [iTime] = 1 and [VEN] = 'N') or ([ABC] = 'C' and [iTime] = 1 and [VEN] = 'E')";
                double SlNhom2T1 = this.tbDanhSach.Select(selectNhom2T1).Count();

                string selectNhom3T1 = "[ABC] = 'C' and [iTime] = 1 and [VEN] = 'N' ";
                double SlNhom3T1 = this.tbDanhSach.Select(selectNhom3T1).Count();

                double TongNhomT1 = SlNhom1T1 + SlNhom2T1 + SlNhom3T1;
                double phantramNhom1T1 = (SlNhom1T1 * 100) / TongNhomT1;
                phantramNhom1T1 = Math.Round(phantramNhom1T1, 2);
                double phantramNhom2T1 = (SlNhom2T1 * 100) / TongNhomT1;
                phantramNhom2T1 = Math.Round(phantramNhom2T1, 2);
                double phantramNhom3T1 = (SlNhom3T1 * 100) / TongNhomT1;
                phantramNhom3T1 = Math.Round(phantramNhom3T1, 2);

                string selectNhom1T2 = "([ABC] = 'A' and [iTime] = 2 and [VEN] = 'V') or ([ABC] = 'A' and [iTime] = 2 and [VEN] = 'E') or ([ABC] = 'A' and [iTime] = 2 and [VEN] = 'N') or ([ABC] = 'B' and [iTime] = 2 and [VEN] = 'V') or ([ABC] = 'C' and [iTime] = 2 and [VEN] = 'V')";
                double SlNhom1T2 = this.tbDanhSach.Select(selectNhom1T2).Count();

                string selectNhom2T2 = "([ABC] = 'B' and [iTime] = 2 and [VEN] = 'E') or ([ABC] = 'B' and [iTime] = 2 and [VEN] = 'N') or ([ABC] = 'C' and [iTime] = 2 and [VEN] = 'E')";
                double SlNhom2T2 = this.tbDanhSach.Select(selectNhom2T2).Count();

                string selectNhom3T2 = "[ABC] = 'C' and [iTime] = 2 and [VEN] = 'N' ";
                double SlNhom3T2 = this.tbDanhSach.Select(selectNhom3T2).Count();

                double TongNhomT2 = SlNhom1T2 + SlNhom2T2 + SlNhom3T2;
                double phantramNhom1T2 = (SlNhom1T2 * 100) / TongNhomT2;
                phantramNhom1T2 = Math.Round(phantramNhom1T2, 2);
                double phantramNhom2T2 = (SlNhom2T2 * 100) / TongNhomT2;
                phantramNhom2T2 = Math.Round(phantramNhom2T2, 2);
                double phantramNhom3T2 = (SlNhom3T2 * 100) / TongNhomT2;
                phantramNhom3T2 = Math.Round(phantramNhom3T2, 2);

                //pass data into gridNhom
                DataTable tbNhom = new DataTable();
                tbNhom.Columns.Add("nhom", typeof(string));
                tbNhom.Columns.Add("chungloai1", typeof(double));
                tbNhom.Columns.Add("tylecl1", typeof(double));
                tbNhom.Columns.Add("chungloai2", typeof(double));
                tbNhom.Columns.Add("tylecl2", typeof(double));
                tbNhom.Rows.Add("I", SlNhom1T1, phantramNhom1T1, SlNhom1T2, phantramNhom1T2);
                tbNhom.Rows.Add("II", SlNhom2T1, phantramNhom2T1, SlNhom2T2, phantramNhom2T2);
                tbNhom.Rows.Add("III", SlNhom3T1, phantramNhom3T1, SlNhom3T2, phantramNhom3T2);
                tbNhom.Rows.Add("Tổng", TongNhomT1, 100, TongNhomT2, 100);
                this.grdNhom.DataSource = tbNhom;

                //Load chart
                chrNhom.DataSource = tbNhom.Select("[nhom] <> 'Tổng'").CopyToDataTable();
                Series series1 = new Series("% Chủng loại T1", ViewType.Bar);
                Series series2 = new Series("% Chủng loại T2", ViewType.Bar);
                chrNhom.Series.Add(series1);
                chrNhom.Series.Add(series2);
                series1.ArgumentDataMember = "nhom";
                series1.ValueDataMembers.AddRange(new string[] { "tylecl1" });
                series2.ArgumentDataMember = "nhom";
                series2.ValueDataMembers.AddRange(new string[] { "tylecl2" });

                //Phân tích
                if (phantramNhom1T2 >= phantramNhom1T1)
                {
                    lblNhomI.Text = "tăng " + Math.Round((phantramNhom1T2 - phantramNhom1T1), 2) + "%";
                }
                else
                {
                    lblNhomI.Text = "giảm " + Math.Round((phantramNhom1T1 - phantramNhom1T2), 2) + "%";
                }

                if (phantramNhom2T2 >= phantramNhom2T1)
                {
                    lblNhomII.Text = "tăng " + Math.Round((phantramNhom2T2 - phantramNhom2T1), 2) + "%";
                }
                else
                {
                    lblNhomII.Text = "giảm " + Math.Round((phantramNhom2T1 - phantramNhom2T2), 2) + "%";
                }

                if (phantramNhom3T2 >= phantramNhom3T1)
                {
                    lblNhomIII.Text = "tăng " + Math.Round((phantramNhom3T2 - phantramNhom3T1), 2) + "%";
                }
                else
                {
                    lblNhomIII.Text = "giảm " + Math.Round((phantramNhom3T1 - phantramNhom3T2), 2) + "%";
                }
                double TongNhom1va2T1 = phantramNhom1T1 + phantramNhom2T1;
                double TongNhom1va2T2 = phantramNhom1T2 + phantramNhom2T2;
                lbl1and2.Text = TongNhom1va2T2 + "%";
                if (TongNhom1va2T2 >= TongNhom1va2T1)
                {
                    lblSoSanh.Text = "tăng";
                    lblTru.Text = Math.Round((TongNhom1va2T2 - TongNhom1va2T1), 2) + "%";
                }
                else
                {
                    lblSoSanh.Text = "giảm";
                    lblTru.Text = Math.Round((TongNhom1va2T1 - TongNhom1va2T2), 2) + "%";
                }
            }
            catch { }
        }
    }
}