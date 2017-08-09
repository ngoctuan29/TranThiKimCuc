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

namespace Ps.Clinic.Entry
{
    public partial class frmCSKHListSendSMS : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable dtResult;
        private DateTime dtWorking = new DateTime();
        private string employeeCode = string.Empty;
        private bool isSendSMS = false;
        private string contentSMS = string.Empty;
        private int typeSMS = -1;
        private DataTable tableSenSMS = new DataTable();
        public frmCSKHListSendSMS(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }

        private void frmCSKH_SendSMS_Load(object sender, EventArgs e)
        {
            try
            {
                this.slkupPatientType.Properties.DataSource = PatientTypeBLL.ListPatientType();
                this.slkupPatientType.Properties.DisplayMember = "TypeName";
                this.slkupPatientType.Properties.ValueMember = "RowID";
                this.dtWorking = Utils.DateServer();
                this.dtNgayTaiKham.EditValue = this.dtWorking;
                this.txtMonh.Value = this.dtWorking.Month;
                this.txtYear.Value = this.dtWorking.Year;
                
                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(10);
                if (objSys != null && objSys.RowID > 0)
                {
                    if (objSys.Values == 1)
                        this.isSendSMS = true;
                }
                iHISSendSMS.iHISSendSMSPolycare lst = new iHISSendSMS.iHISSendSMSPolycare();
                this.lkupSMSType.Properties.DataSource = lst.ListContentSMS();
                this.lkupSMSType.Properties.ValueMember = "ID";
                this.lkupSMSType.Properties.DisplayMember = "Title";
            }
            catch { throw new Exception(); }
        }
                
        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtResult = PatientReceiveBLL.DT_View_PatientReceive(Convert.ToDateTime(this.dllNgay.tungay.Text), Convert.ToDateTime(this.dllNgay.denngay.Text), Convert.ToInt32(this.slkupPatientType.EditValue), "T");
                this.gridControl_result.DataSource = this.dtResult;
            }
            catch
            {
                throw new Exception();
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsTemp = new DataSet("table");
                dsTemp.Merge(dtResult);
                dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptDanhSachTiepNhan.xml");
                Reports.rptDanhSachTiepNhan rptShow = new Reports.rptDanhSachTiepNhan();
                rptShow.DataSource = dsTemp;
                rptShow.Parameters["fromdate"].Value = this.dllNgay.tungay.Text;
                rptShow.Parameters["todate"].Value = this.dllNgay.denngay.Text;
                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "Danhsachtiepnhan", "Danh sách tiếp nhận");
                rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView_result_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.isSendSMS)
                {
                    if (this.lkupSMSType.EditValue == null)
                    {
                        XtraMessageBox.Show(" Vui lòng chọn hình thức gửi tin nhắn.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.lkupSMSType.Focus();
                        return;
                    }
                    if (Convert.ToDateTime(this.dtNgayTaiKham.EditValue).Date < this.dtWorking.Date)
                    {
                        XtraMessageBox.Show(" Ngày hẹn tái khám không được nhỏ hơn ngày hiện tại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.dtNgayTaiKham.Focus();
                        return;
                    }
                    if (!Utils.isMobile(this.txtDienThoai.Text) && (Utils.ReplaceMobile(this.txtDienThoai.Text).Length < 10 || Utils.ReplaceMobile(this.txtDienThoai.Text).Length > 11))
                    {
                        XtraMessageBox.Show(" Số điện thoại liên hệ hẹn khám không hợp lệ.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.txtDienThoai.Focus();
                        return;
                    }
                    if (Convert.ToInt32(this.txtYear.Value) < this.dtWorking.Year)
                    {
                        XtraMessageBox.Show(" Năm hẹn khám định kỳ không được nhỏ hơn năm hiện tại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.txtYear.Focus();
                        return;
                    }
                    
                    string patientCode = this.gridView_result.GetRowCellValue(this.gridView_result.FocusedRowHandle, this.col_List_PatientCode).ToString();
                    string patientName = this.gridView_result.GetRowCellValue(this.gridView_result.FocusedRowHandle, this.col_List_PatientName).ToString();
                    string patientGenderName = this.gridView_result.GetRowCellValue(this.gridView_result.FocusedRowHandle, this.col_List_PatientGenderName).ToString();
                    string patientBirthday = this.gridView_result.GetRowCellValue(this.gridView_result.FocusedRowHandle, this.col_List_PatientBirthday).ToString();
                    string patientMobile = this.gridView_result.GetRowCellValue(this.gridView_result.FocusedRowHandle, this.col_List_PatientMobile).ToString();
                    string patientAge = this.gridView_result.GetRowCellValue(this.gridView_result.FocusedRowHandle, this.col_List_PatientAge).ToString();
                    string address = this.gridView_result.GetRowCellValue(this.gridView_result.FocusedRowHandle, this.col_List_Address).ToString();
                    string wardName = this.gridView_result.GetRowCellValue(this.gridView_result.FocusedRowHandle, this.col_List_WardName).ToString();
                    string districtName = this.gridView_result.GetRowCellValue(this.gridView_result.FocusedRowHandle, this.col_List_DistrictName).ToString();
                    string provincialName = this.gridView_result.GetRowCellValue(this.gridView_result.FocusedRowHandle, this.col_List_ProvincialName).ToString();
                    decimal patientReceiveID = Convert.ToDecimal(this.gridView_result.GetRowCellValue(this.gridView_result.FocusedRowHandle, this.col_List_PatientReceiveID).ToString());
                    frmSendSMSContent frm = new frmSendSMSContent(patientReceiveID, patientCode, patientName, patientGenderName, patientBirthday.Substring(0, 10), patientMobile, patientAge, address, wardName, districtName, provincialName, this.dtNgayTaiKham.Text, this.txtDienThoai.Text, this.txtYear.Value.ToString(), this.employeeCode, this.contentSMS);
                    frm.ShowDialog();
                    if (frm.reload)
                        this.butOK_Click(sender, e);
                }
                else
                {
                    XtraMessageBox.Show(" Option gửi SMS hẹn khám bệnh chưa được config.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void butSearchSendSMS_Click(object sender, EventArgs e)
        {
            this.tableSenSMS = PatientsSendSMSBLL.TableGetPatientSendSMS(this.dtNgay.TN, this.dtNgay.DN);
            this.gridControl_ListPatientSMS.DataSource = this.tableSenSMS;
        }

        private void tabMain_Click(object sender, EventArgs e)
        {
            if (this.tabMain.SelectedTabPageIndex == 0)
                this.butOK_Click(sender, e);
            else
                this.butSearchSendSMS_Click(sender, e);
        }

        private void lkupSMSType_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lkup = (LookUpEdit)sender;
            this.contentSMS = lkup.GetColumnValue("Content").ToString();
            this.txtDienThoai.Text = lkup.GetColumnValue("Mobile").ToString();
            this.typeSMS = Convert.ToInt32(this.lkupSMSType.EditValue);
            this.GetContentSMS();
        }

        private void GetContentSMS()
        {
            switch (this.typeSMS)
            {
                case 1:
                    this.txtNoiDungSMS.Text = string.Format(this.contentSMS, "{0}", this.dtNgayTaiKham.Text, this.txtDienThoai.Text);
                    this.contentSMS = string.Format(this.contentSMS, "{0}", this.dtNgayTaiKham.Text, this.txtDienThoai.Text);
                    break;
                case 2:
                    this.txtNoiDungSMS.Text = string.Format(this.contentSMS, this.txtYear.Value, "{0}", this.txtDienThoai.Text);
                    this.contentSMS = string.Format(this.contentSMS, this.txtYear.Value, "{0}", this.txtDienThoai.Text);
                    break;
                case 3:
                    this.txtNoiDungSMS.Text = string.Format(this.contentSMS, this.txtMonh.Value, this.txtYear.Value, this.txtDienThoai.Text);
                    this.contentSMS = string.Format(this.contentSMS, this.txtMonh.Value, this.txtYear.Value, this.txtDienThoai.Text);
                    this.txtMonh.ReadOnly = false;
                    break;
                default:
                    this.txtNoiDungSMS.Text = this.contentSMS;
                    break;

            }
        }

        private void dtNgayTaiKham_EditValueChanged(object sender, EventArgs e)
        {
            this.GetContentSMS();
        }

        private void txtMonh_ValueChanged(object sender, EventArgs e)
        {
            int monthTemp = Convert.ToInt32(this.txtMonh.Value);
            if (monthTemp < this.dtWorking.Month && Convert.ToInt32(this.txtYear.Value) <= this.dtWorking.Year)
                this.txtMonh.Value = this.dtWorking.Month;
            this.GetContentSMS();
        }

        private void txtYear_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.txtYear.Value) <= this.dtWorking.Year)
            {
                this.txtMonh.Value = this.dtWorking.Month;
                this.txtYear.Value = this.dtWorking.Year;
            }
            this.GetContentSMS();
        }

        private void btnPrintSMS_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tableSenSMS != null && this.tableSenSMS.Rows.Count > 0)
                {
                    DataSet dsTemp = new DataSet("table");
                    dsTemp.Merge(this.tableSenSMS);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptDanhSachSMS.xml");
                    Reports.rptKB_DanhSachSMS rptShow = new Reports.rptKB_DanhSachSMS();
                    rptShow.DataSource = dsTemp;
                    rptShow.Parameters["fromdate"].Value = this.dllNgay.tungay.Text;
                    rptShow.Parameters["todate"].Value = this.dllNgay.denngay.Text;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "DSKhachHang", "Danh sách KH gửi SMS");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("Chi tiết danh sách gửi SMS không phát sinh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}