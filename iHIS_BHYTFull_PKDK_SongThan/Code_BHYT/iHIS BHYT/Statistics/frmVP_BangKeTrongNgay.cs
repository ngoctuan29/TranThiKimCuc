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
using System.Reflection;

namespace Ps.Clinic.Statistics
{
    public partial class frmVP_BangKeTrongNgay : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable dtbResult = new DataTable();
        private string employeeCode = string.Empty;
        private DataTable tableReport = new DataTable();
        
        public frmVP_BangKeTrongNgay(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }
                
        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtbResult = rpt_Banking_BLL.ReportDailyInvoice_xempk(this.controlDatetime.tungay.Value, this.controlDatetime.denngay.Value, 0, this.chkLoai.Checked ? 1 : 0);
                this.gridControl_Result.DataSource = this.dtbResult;
                this.gridView_Result.Columns["PostingDate"].Group();
                this.gridView_Result.Columns["PatientCode"].Group();
                this.gridView_Result.ExpandAllGroups();
            }
            catch
            {
                return;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (this.dtbResult != null && this.dtbResult.Rows.Count > 0)
            {
                DataSet dsTemp = new DataSet();
                dsTemp.Merge(this.dtbResult);
                dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\viewVP_InvoiceForDate.xml");
                Reports.rpt_VP_BangKeHD rptShow = new Reports.rpt_VP_BangKeHD();
                rptShow.Parameters["fromdate"].Value = this.controlDatetime.tungay.Text;
                rptShow.Parameters["todate"].Value = this.controlDatetime.denngay.Text;
                rptShow.DataSource = dsTemp;
                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "BKHoaDonNgay", "Bảng kê hoá đơn ngày");
                rpt.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("Không có dữ liệu phát sinh !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void gridView_Result_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_Result.GetFocusedRow() != null)
                {
                    string banksAccountCodeTemp = this.gridView_Result.GetRowCellValue(this.gridView_Result.FocusedRowHandle, "BanksAccountCode").ToString();
                    string patientCodeTemp = this.gridView_Result.GetRowCellValue(this.gridView_Result.FocusedRowHandle, "PatientCode").ToString();
                    decimal referenceCodeTemp = Convert.ToDecimal(this.gridView_Result.GetRowCellValue(this.gridView_Result.FocusedRowHandle, "ReferenceCode").ToString());
                    int objectCodeTemp = Convert.ToInt32(this.gridView_Result.GetRowCellValue(this.gridView_Result.FocusedRowHandle, "ObjectCode").ToString());
                    string objectNameTemp = this.gridView_Result.GetRowCellValue(this.gridView_Result.FocusedRowHandle, "ObjectName").ToString();
                    frmPopupCancelServiceDetail frm = new frmPopupCancelServiceDetail(banksAccountCodeTemp, patientCodeTemp, referenceCodeTemp, objectCodeTemp, objectNameTemp);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex){
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_Result_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                string bankcode = "";
                if (e.RowHandle >= 0)
                {
                    bankcode = View.GetRowCellValue(e.RowHandle, "BanksAccountCode").ToString();
                    if (bankcode == "" || bankcode == null)
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
            }
            catch { }
        }
    }
}