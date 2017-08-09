using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports;
using ClinicModel;
using ClinicBLL;
using ClinicLibrary;
using DevExpress.XtraGrid.Views.Grid;

namespace Ps.Clinic.Statistics
{
    public partial class frmTKeBanThuoc : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtbResult = new DataTable();
        public frmTKeBanThuoc()
        {
            InitializeComponent();
        }
        
        private void butCount_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkCancel.Checked)
                    gridControl_Result.DataSource = rpt_Medicines_BLL.DT_View_TKeBanThuoc(dtNgay.TN, dtNgay.DN, -1);
                else
                    gridControl_Result.DataSource = rpt_Medicines_BLL.DT_View_TKeBanThuoc(dtNgay.TN, dtNgay.DN, 1);
            }
            catch { }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            gridControl_Result.ShowRibbonPrintPreview();
        }

        private void frmTKeBanThuoc_Load(object sender, EventArgs e)
        {
            try
            {

                
            }
            catch { }
        }

        private void butCountTH_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkCancelTH.Checked)
                    gridControl_ResultTH.DataSource = rpt_Medicines_BLL.DT_View_TKeBanThuocTH(dtNgayTH.TN, dtNgayTH.DN, -1);
                else
                    gridControl_ResultTH.DataSource = rpt_Medicines_BLL.DT_View_TKeBanThuocTH(dtNgayTH.TN, dtNgayTH.DN, 1);
            }
            catch { }
        }

        private void butPrintTH_Click(object sender, EventArgs e)
        {
            gridControl_ResultTH.ShowRibbonPrintPreview();
        }

        private void butCountTHMonth_Click(object sender, EventArgs e)
        {
            try
            {
                dtbResult = rpt_Medicines_BLL.DT_View_TKeBanThuocTHMonth(dtNgayMonth.TN, dtNgayMonth.DN, 1);
                gridControl_ResultTHMonth.DataSource = dtbResult;
            }
            catch { }
        }

        private void butPrintTHMonth_Click(object sender, EventArgs e)
        {
            if (dtbResult != null && dtbResult.Rows.Count > 0)
            {
                DataSet dsTemp = new DataSet();
                dsTemp.Merge(dtbResult);
                dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rpt_Thuoc_BCLaiSuat.xml");
                Reports.rpt_Thuoc_BCLaiSuat rptShow = new Reports.rpt_Thuoc_BCLaiSuat();
                rptShow.Parameters["title"].Value = "BÁO CÁO DANH THU LÃI BÁN THUỐC";
                rptShow.Parameters["fromdate"].Value = this.dtNgayMonth.TN;
                rptShow.Parameters["todate"].Value = this.dtNgayMonth.DN;
                rptShow.DataSource = dsTemp;
                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "BÁO CÁO DANH THU LÃI BÁN THUỐC", "BÁO CÁO DANH THU LÃI BÁN THUỐC");
                rpt.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show(" Số liệu báo cáo chưa phát sinh! Vui lòng xem lại thông tin.", "Bệnh viện điện tử .NET");
                dtNgayMonth.Focus();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControl_ResultTHMonth.ShowRibbonPrintPreview();
        }
    }
}