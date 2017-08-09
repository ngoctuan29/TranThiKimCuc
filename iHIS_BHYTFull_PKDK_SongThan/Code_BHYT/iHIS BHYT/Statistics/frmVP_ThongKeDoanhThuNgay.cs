using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.Linq;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Statistics
{
    public partial class frmVP_ThongKeDoanhThuNgay : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable dtbResult = new DataTable();
        private string employeeCode = string.Empty;
        public frmVP_ThongKeDoanhThuNgay(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }

        private void frmVP_ThongKeDoanhThuNgay_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch { }
        }
        
        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tabResult.SelectedTabPageIndex == 0)
                {
                    this.dtbResult = rpt_Banking_BLL.DataReportDailyRevenue(this.dllNgay.tungay.Value, this.dllNgay.denngay.Value);
                    this.gridControl_Result.DataSource = dtbResult;
                }
                else
                {
                    this.dtbResult = rpt_Banking_BLL.DataViewDailyRevenueDetail(this.dllNgay.tungay.Value, this.dllNgay.denngay.Value);
                    this.gridControl_ResultDetail.DataSource = this.dtbResult;
                    this.gridView_ResultDetail.Columns["ServiceGroupName"].Group();//260616
                    this.gridView_ResultDetail.Columns["ServiceCategoryName"].Group();
                    this.gridView_ResultDetail.ExpandAllGroups();
                }
            }
            catch
            {
                return;
            }
        }

        private void btnPrintGrid_Click(object sender, EventArgs e)
        {
            if (tabResult.SelectedTabPageIndex == 0)
                gridControl_Result.ShowRibbonPrintPreview();
            else
                gridControl_ResultDetail.ShowRibbonPrintPreview();
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    if (tabResult.SelectedTabPageIndex == 0)
                    {
                        DataSet dsXml = new DataSet();
                        dsXml.Merge(dtbResult);
                        dsXml.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rpt_VP_ThongKeDoanhThuNgay.xml");
                        Reports.rpt_VP_ThongKeDoanhThuNgay rptShow = new Reports.rpt_VP_ThongKeDoanhThuNgay();
                        rptShow.Parameters["fromdate"].Value = dllNgay.tungay.Text;
                        rptShow.Parameters["todate"].Value = dllNgay.denngay.Text;
                        rptShow.DataSource = dsXml;
                        Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "TKeDoanhThuNgay", "Thống kê doanh thu ngày");
                        rpt.ShowDialog();
                    }
                    else
                    {
                        DataSet dsXml = new DataSet();
                        dsXml.Merge(this.dtbResult);
                        dsXml.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rpt_VP_ThongKeDoanhThuNgayDetail.xml");
                        Reports.rpt_VP_ThongKeDoanhThuNgayDetail rptShow = new Reports.rpt_VP_ThongKeDoanhThuNgayDetail();
                        rptShow.Parameters["fromdate"].Value = dllNgay.tungay.Text;
                        rptShow.Parameters["todate"].Value = dllNgay.denngay.Text;
                        rptShow.DataSource = dsXml;
                        Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "TKeDoanhThuNgay", "Thống kê doanh thu ngày");
                        rpt.ShowDialog();
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Số liệu báo cáo chưa phát sinh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void tabResult_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                butOK_Click(sender, e);
            }
            catch { return; }
        }
        
    }
}