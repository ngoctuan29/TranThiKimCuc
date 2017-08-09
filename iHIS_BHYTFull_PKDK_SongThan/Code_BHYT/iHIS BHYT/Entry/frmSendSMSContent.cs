using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using Ps.Clinic.ViewPopup;
using DevExpress.XtraTab;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Entry
{
    public partial class frmSendSMSContent : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string patientCode = string.Empty, patientName = string.Empty, ngayhen = string.Empty, dienThoaiDatHen = string.Empty, namKB = string.Empty, employeeCode = string.Empty;
        private string contentSMS = "Thong bao den Quy khach:{0} lich tai kham ngay {1} LH dat hen: {2} hoac - TB lich kham dinh ky nam {3} cua Quy khach: {4} LH dat hen: {5}";
        private decimal patientReceiveID = -1;
        private DateTime dtWorking = new DateTime();
        public bool reload = false;
        public frmSendSMSContent(Decimal _patientReceiveID, string _patientCode, string _patientName, string _patientGenderName, string _patientBirthday, string _patientMobile, string _patientAge, string _address, string _wardName, string _districtName, string _provincialName, string _ngayhen, string _dienThoaiDatHen, string _namKB, string _employeeCode, string _contentSMS)
        {
            InitializeComponent();
            this.patientReceiveID = _patientReceiveID;
            this.patientCode = _patientCode;
            this.lbHoTen.Text = this.patientName = _patientName;
            this.lbGioiTinh.Text = _patientGenderName;
            this.lbNgaySinh.Text = _patientBirthday;
            this.txtDienThoai.Text = _patientMobile;
            this.lbTuoi.Text = _patientAge;
            this.ngayhen = _ngayhen;
            this.dienThoaiDatHen = _dienThoaiDatHen;
            this.namKB = _namKB;
            this.employeeCode = _employeeCode;
            this.contentSMS = _contentSMS;            
            if (!string.IsNullOrEmpty(_address))
                this.lbDiaChi.Text = _address + " - ";
            if (!string.IsNullOrEmpty(_wardName))
                this.lbDiaChi.Text += _wardName + " - ";
            if (!string.IsNullOrEmpty(_districtName))
                this.lbDiaChi.Text += _districtName + " - ";
            if (!string.IsNullOrEmpty(_provincialName))
                this.lbDiaChi.Text += _provincialName;
        }

        private void frmSendSMS_Load(object sender, EventArgs e)
        {
            try
            {
                string patientNameNosign = Utils.convertToUnSign3(this.patientName).ToUpper();
                this.txtNoiDung.Text = string.Format(this.contentSMS, patientNameNosign);

                List<PatientsInf> listPatient = PatientsBLL.ListPatients(this.patientCode);
                if (listPatient != null && listPatient.Count > 0 && listPatient[0].PatientImage != null)
                {
                    Byte[] imageadata = new Byte[0];
                    imageadata = (Byte[])(listPatient[0].PatientImage.ToArray());
                    MemoryStream memo = new MemoryStream(imageadata);
                    Bitmap b = new Bitmap(Image.FromStream(memo));
                    picPatient.Image = (Bitmap)b;
                }
                else
                {
                    Bitmap b1 = new Bitmap("NoImgPatient.jpeg");
                    this.picPatient.Image = (Bitmap)b1;
                }
                this.dtWorking = Utils.DateServer();
                this.txtDienThoai.Focus();
            }
            catch { throw new Exception(); }
        }

        private void butSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Utils.isMobile(this.txtDienThoai.Text) && (Utils.ReplaceMobile(this.txtDienThoai.Text).Length < 10 || Utils.ReplaceMobile(this.txtDienThoai.Text).Length > 11))
                {
                    XtraMessageBox.Show(" Số điện thoại liên hệ hẹn khám không hợp lệ!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (this.txtNoiDung.Text.Trim().Length <= 0)
                {
                    XtraMessageBox.Show(" Nội dung tin nhắn không được để trống!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    iHISSendSMS.iHISSendSMSPolycare c = new iHISSendSMS.iHISSendSMSPolycare();
                    iHISSendSMS.iHISSendSMSPolycare.ResultData data = c.SendSMS(this.txtNoiDung.Text, this.txtDienThoai.Text);
                    if (data.Result)
                    {
                        this.reload = true;
                        XtraMessageBox.Show(" Gửi SMS hẹn khám đến số điện thoại: " + this.txtDienThoai.Text + " thành công.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show(data.StringResult, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    PatientsSendSMSInf objsms = new PatientsSendSMSInf { IDTarget = data.IDTarget, PatientReceiveID= this.patientReceiveID, PatientCode = this.patientCode, AppointmentDate = this.ngayhen, Mobile = this.txtDienThoai.Text.Trim(), Result = data.StringResult, Content = this.txtNoiDung.Text, EmployeeCode = this.employeeCode, WorkDate = this.dtWorking };
                    PatientsSendSMSBLL.InsSendSMS(objsms);
                }
            }
            catch { throw new Exception(); }
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtNoiDung.Focus();
        }

        private void txtNoiDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.butSend.Focus();
        }
        
    }
}