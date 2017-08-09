using System;
using System.IO;
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
using DevExpress.XtraRichEdit;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Statistics
{
    public partial class frmHSBA_SendEmail : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable dtResult;
        private string employeeCode = string.Empty;
        private DateTime dtWorking;
        
        public frmHSBA_SendEmail(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }

        private void frmHSBA_SendEmail_Load(object sender, EventArgs e)
        {
            try
            {
                this.slkupPatientType.Properties.DataSource = PatientTypeBLL.ListPatientType();
                this.slkupPatientType.Properties.DisplayMember = "TypeName";
                this.slkupPatientType.Properties.ValueMember = "RowID";
                this.dtWorking = Utils.DateTimeServer();
                List<EmailType> lstEmail = new List<EmailType>();
                EmailType obj = new EmailType { Email = "GMail", SMTP = "smtp.gmail.com" };
                lstEmail.Add(obj);
                this.lkupEmailType.Properties.DataSource = lstEmail;
                this.lkupEmailType.Properties.DisplayMember = "Email";
                this.lkupEmailType.Properties.ValueMember = "SMTP";
            }
            catch { }
        }
                
        private void butReload_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
            try
            {
                this.dtResult = HSBA_SynchronizeBLL.TableGet_KetQuaDieuTri(this.dllNgay.tungay.Text, this.dllNgay.denngay.Text, string.Empty, Convert.ToInt32(this.slkupPatientType.EditValue), this.chkConfirm.Checked ? 1 : 0);
                if (this.dtResult != null && this.dtResult.Rows.Count > 0)
                {
                    this.gridControl_result.DataSource = dtResult;
                }
                else
                {
                    XtraMessageBox.Show("Không có số liệu thống kê!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.gridControl_result.DataSource = null;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void butUpload_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!Utils.CheckEmail(this.txtEmailFrom.Text.Trim()))
                //{
                //    XtraMessageBox.Show("Địa chỉ email không hợp lệ!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //if(string.IsNullOrEmpty(this.txtSMTP.Text))
                //{
                //    XtraMessageBox.Show("SMTP không được để trống!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //XtraMessageBox.Show("Vui lòng cung cấp Email và SMTP cần của Email cần gửi!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return;
                string sendto = "vandongitc2009@gmail.com";
                string sendfrom = "vandongitc2010@gmail.com";
                string subject = "Hồ Sơ Khám Chữa Bệnh";
                string body = "Chi phí điều trị KCB";
                string attachmentPath = "D:\\Projects\\CTyPowerSoft\\iHIS_BHYTFull_PKDK\\CodeSVN\\iHIS BHYT\\SendEmail\\rptChiphidieutri.pdf";
                //string result = this.SendEmail_With_Attachment(sendto, sendfrom, subject, body, attachmentPath);
                XtraMessageBox.Show("Vui lòng liên hệ với công ty config email cho quý khách.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex){
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public class EmailType
        {
            public string Email { get; set; }
            public string SMTP { get; set; }
        }

        public string SendEmail_With_Attachment(string sendTo, string sendFrom, string subject, string body, string attachmentPath)
        {
            try
            {
                bool result = Utils.CheckEmail(sendTo);
                if (!Utils.CheckEmail(sendTo))
                {
                    return "Địa chỉ email nhận không hợp lệ.";
                }
                else if(!Utils.CheckEmail(sendFrom))
                {
                    return "Địa chỉ email gửi không hợp lệ.";
                }
                else
                {
                    try
                    {
                        System.Net.Mail.MailMessage em = new System.Net.Mail.MailMessage(sendFrom, sendTo, subject, body);
                        System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(attachmentPath);
                        em.Attachments.Add(attach);
                        em.Bcc.Add(sendFrom);
                        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Send(em);
                        return "Gửi hồ sơ thành công.";
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private void lkupEmailType_EditValueChanged(object sender, EventArgs e)
        {
            this.txtSMTP.Text = this.lkupEmailType.EditValue.ToString();
        }
    }
}