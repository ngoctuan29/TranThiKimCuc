using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
//using MedicineABC.DataAccess;
using DevExpress.XtraCharts;
using System.Data.Linq;

namespace Ps.Clinic.VenABC.PhanTichABCTheoThuocNoiNgoai
{
    public partial class frmPhanTichATC : DevExpress.XtraEditors.XtraForm
    {
        DateTime TuNgay; DateTime DenNgay; string Phieu;
        public frmPhanTichATC(DateTime _TuNgay,DateTime _DenNgay,string _Phieu)
        {
            this.TuNgay = _TuNgay;
            this.DenNgay = _DenNgay;
            this.Phieu = _Phieu;
            InitializeComponent();
        }

        private void frmPhanTichATC_Load(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = "(" + this.TuNgay.ToShortDateString() + " - " + this.DenNgay.ToShortDateString() + ")";

                //load grid
                DataTable tbATC = new DataTable();
                tbATC = ClinicBLL.Ven_AnalistBLL.GetThongKeABCTheoATC_TyLe(this.Phieu);
                grdATC.DataSource = tbATC;

                //load chart
                chrATC.DataSource = tbATC;
                Series series1 = new Series("% Giá trị", ViewType.Bar);
                chrATC.Series.Add(series1);
                series1.ArgumentDataMember = "MaATC";
                series1.ValueDataMembers.AddRange(new string[] { "Tile" });

                lblNhomMax.Text = tbATC.Select("[Tile] = MAX(Tile)")[0]["MaATC"].ToString();
                lblTenMax.Text = tbATC.Select("[Tile] = MAX(Tile)")[0]["TenATC"].ToString();
                lblTyleMax.Text = tbATC.Select("[Tile] = MAX(Tile)")[0]["Tile"].ToString() + " %";

                lblNhomMin.Text = tbATC.Select("[Tile] = MIN(Tile)")[0]["MaATC"].ToString();
                lblTenMin.Text = tbATC.Select("[Tile] = MIN(Tile)")[0]["TenATC"].ToString();
                lblTyleMin.Text = tbATC.Select("[Tile] = MIN(Tile)")[0]["Tile"].ToString() + " %";


                //DataTable tbDanhSach = new DataTable();
                //tbDanhSach = ConnectDB.CallProcedureThongKeABCTheoATC(ft);
                //int sl1 = tbDanhSach.Rows.Count;
                //DataView view = new DataView(tbDanhSach);
                //int khangsinh1 = tbDanhSach.Select("[MaATC] = 'A'").Count();
                //int khangsinh2 = tbDanhSach.Select("[MaATC] = 'C'").Count();
                //int khangsinh3 = tbDanhSach.Select("[MaATC] = 'J'").Count();
                //int khangsinh4 = tbDanhSach.Select("[MaATC] = 'N'").Count();
                //int khangsinh5 = tbDanhSach.Select("[MaATC] = 'R'").Count();
                //int khangsinh6 = tbDanhSach.Select("[MaATC] = 'M'").Count();
                //int khangsinh7 = tbDanhSach.Select("[MaATC] = 'G'").Count();
                //int khangsinh8 = tbDanhSach.Select("[MaATC] = 'B'").Count();
                //int khangsinh9 = tbDanhSach.Select("[MaATC] = 'S'").Count();
                //int khangsinh10 = tbDanhSach.Select("[MaATC] = 'H'").Count();
                //int khangsinh11 = tbDanhSach.Select("[MaATC] = 'D'").Count();
                //int khangsinh12 = tbDanhSach.Select("[MaATC] = 'V'").Count();
                //int khangsinh13 = tbDanhSach.Select("[MaATC] = 'P'").Count();
            }
            catch { }
        }
    }
}