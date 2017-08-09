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
    public partial class frmVP_BangKeHDChiTiet : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable dtbResult = new DataTable();
        private string employeeCode = string.Empty;
        private DataTable tableReport = new DataTable();
        
        public frmVP_BangKeHDChiTiet(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }
                
        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                //var firstInfo = ClinicInformationBLL.ObjInformation(1);
                //DateTime ca1from = Convert.ToDateTime(firstInfo.WorkingTimeLineFrom01);
                //DateTime ca3to = Convert.ToDateTime(firstInfo.WorkingTimeLineTo03);
                //DateTime startdate = this.controlDatetime.tungay.Value.Date + ca1from.TimeOfDay;
                //DateTime enddate = this.controlDatetime.denngay.Value.Date.AddDays(1) + ca3to.TimeOfDay;
                DateTime startdate = DateTime.Now;
                DateTime enddate = DateTime.Now;
                if (chk_TimeofDate.Checked == true)
                {
                    var firstInfo = ClinicInformationBLL.ObjInformation(1);
                    DateTime ca1from = Convert.ToDateTime(firstInfo.WorkingTimeLineFrom01).AddSeconds(00);
                    DateTime ca3to = Convert.ToDateTime(firstInfo.WorkingTimeLineTo03).AddSeconds(59);
                    startdate = this.controlDatetime.tungay.Value.Date + ca1from.TimeOfDay;
                    enddate = this.controlDatetime.denngay.Value.Date.AddDays(1) + ca3to.TimeOfDay;
                }
                else
                {
                    DateTime time1 = this.timeStart.Time;
                    DateTime time2 = this.timeFrom.Time;
                    startdate = this.controlDatetime.tungay.Value.Date + time1.TimeOfDay;
                    enddate = this.controlDatetime.denngay.Value.Date + time2.TimeOfDay;
                }
                this.dtbResult = rpt_Banking_BLL.DataViewDailyInvoiceDetail(startdate,enddate , this.chkCancel.Checked ? 1 : 0);
                this.gridControl_Result.DataSource = this.dtbResult;
                //this.gridView_Result.Columns["DepartmentNameOrder"].Group();
                //this.gridView_Result.Columns["ServiceGroupName"].Group();
                //this.gridView_Result.Columns["ServiceCategoryName"].Group();
             
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
                rptShow.Parameters["title"].Value = this.cbxReport.Text.ToUpper();
                rptShow.DataSource = dsTemp;
                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "HoaDon","Hoá đơn");
                rpt.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("Không có dữ liệu phát sinh !", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void frmVP_BangKeHDNgay_Load(object sender, EventArgs e)
        {
            this.tableReport.Columns.Add("ReportCode", typeof(string));
            this.tableReport.Columns.Add("ReportName", typeof(string));
            this.tableReport.Rows.Add("BC01", " Bảng Kê Hóa Đơn");
            this.tableReport.Rows.Add("BC02", " Danh Sách Khách Hàng Thu Tiền");
            this.cbxReport.DataSource = this.tableReport;
            this.cbxReport.DisplayMember = "ReportName";
            this.cbxReport.ValueMember = "ReportName";
            this.chk_TimeofDate.Checked = true;
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
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnPrintGrid_Click(object sender, EventArgs e)
        {
            this.gridControl_Result.ShowPrintPreview();
        }

        private void chk_TimeofDate_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_TimeofDate.CheckState ==CheckState.Checked)
            {
                this.timeStart.Enabled = false;
                this.timeFrom.Enabled = false;
            }
            else
            {
                this.timeStart.Enabled = true;
                this.timeFrom.Enabled = true;
            }
        }
    }
}