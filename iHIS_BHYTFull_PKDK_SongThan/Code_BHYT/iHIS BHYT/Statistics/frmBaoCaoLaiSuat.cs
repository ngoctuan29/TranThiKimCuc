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
    public partial class frmBaoCaoLaiSuat : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtbResult = new DataTable();
        public frmBaoCaoLaiSuat()
        {
            InitializeComponent();
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
                XtraMessageBox.Show(" Số liệu báo cáo chưa phát sinh! Vui lòng xem lại thông tin.", "Bệnh viện điện tử .NET",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.dtNgayMonth.Focus();
            }
        }

        private void butPrintGrid_Click(object sender, EventArgs e)
        {
            this.gridControl_ResultTHMonth.ShowRibbonPrintPreview();
        }

    }
}