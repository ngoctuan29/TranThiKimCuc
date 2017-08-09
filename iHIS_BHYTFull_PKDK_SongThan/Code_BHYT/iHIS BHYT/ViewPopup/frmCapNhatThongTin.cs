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
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using System.Web.Script.Serialization;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmCapNhatThongTin : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private SmtpClient client;
        private string userID = string.Empty;
        public frmCapNhatThongTin(string _userID)
        {
            InitializeComponent();
            this.userID = _userID;
        }

        public void initMaster()
        {
            //lkKCB.Properties.DataSource = KCBBDBLL.DTKCBBD_List(0);
            //lkKCB.Properties.DisplayMember = "KCBBDName";
            //lkKCB.Properties.ValueMember = "KCBBDCodeFull";
            this.lkTP.Properties.DataSource = KCBBDBLL.TinhKCBBD_List();
            this.lkTP.Properties.DisplayMember = "ProvincialName";
            this.lkTP.Properties.ValueMember = "ProvincialIDBHYT";
        }

        private void frmCapNhatThongTin_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadDataInfo();
            }
            catch (Exception ex){
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void LoadDataInfo()
        {
            this.initMaster();
            var firstInfo = ClinicInformationBLL.ObjInformation(1);
            if (firstInfo != null)
            {
                this.txtClinicName.Text = firstInfo.ClinicName.ToUpper();
                this.txtClinicAddress.Text = firstInfo.ClinicAddress;
                this.lkTP.EditValue = firstInfo.Province;
                this.txtClinicPhone.Text = firstInfo.Phone;
                this.txtClinicMobile.Text = firstInfo.Mobile;
                this.txtClinicDoctor.Text = firstInfo.Doctor;
                this.lkKCB.EditValue = firstInfo.KCBBDCode;
                this.txtTimeFrom01.Text = firstInfo.WorkingTimeLineFrom01;
                this.txtTimeTo01.Text = firstInfo.WorkingTimeLineTo01;
                this.txtTimeFrom02.Text = firstInfo.WorkingTimeLineFrom02;
                this.txtTimeTo02.Text = firstInfo.WorkingTimeLineTo02;
                this.txtTimeFrom03.Text = firstInfo.WorkingTimeLineFrom03;
                this.txtTimeTo03.Text = firstInfo.WorkingTimeLineTo03;
                this.txtUsername_TC.Text = firstInfo.UserName_TC;
                this.txtPassword_TC.Text = firstInfo.PassWord_TC;
                this.txtUsername_BV.Text = firstInfo.UserName_BV;
                this.txtPassword_BV.Text = firstInfo.PassWord_BV;
            }
            else
            {
                XtraMessageBox.Show(" Thông tin chi tiết chưa bổ sung !\t\nYêu cầu nhập vào. ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        

        private void butUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtClinicName.Text == string.Empty)
                {
                    XtraMessageBox.Show("Tên phòng khám không được để trống !\t\nYêu cầu nhập.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtClinicName.Focus();
                    return;
                }
                if (this.txtClinicAddress.Text == string.Empty)
                {
                    XtraMessageBox.Show("Địa chỉ của phòng khám không được để trống !\t\nYêu cầu nhập.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtClinicAddress.Focus();
                    return;
                }
                if (this.lkTP.Text == string.Empty)
                {
                    XtraMessageBox.Show("Tỉnh & Thành phố không được để trống !\t\nYêu cầu nhập.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkTP.Focus();
                    return;
                }
                if (this.txtClinicDoctor.Text == string.Empty)
                {
                    XtraMessageBox.Show("Bác sĩ không được để trống !\t\nYêu cầu nhập.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtClinicDoctor.Focus();
                    return;
                }
                if (!Utils.isHour(this.txtTimeFrom01.Text))
                {
                    XtraMessageBox.Show("Giờ bắt đầu Ca 1 không hợp lệ!\t\nYêu cầu nhập lại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtTimeFrom01.Focus();
                    return;
                }
                if (!Utils.isHour(this.txtTimeTo01.Text))
                {
                    XtraMessageBox.Show("Giờ kết thúc Ca 1 không hợp lệ!\t\nYêu cầu nhập lại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtTimeTo01.Focus();
                    return;
                }
                if (!Utils.isHour(this.txtTimeFrom02.Text))
                {
                    XtraMessageBox.Show("Giờ bắt đầu Ca 2 không hợp lệ!\t\nYêu cầu nhập lại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtTimeFrom02.Focus();
                    return;
                }
                if (!Utils.isHour(this.txtTimeTo02.Text))
                {
                    XtraMessageBox.Show("Giờ kết thúc Ca 2 không hợp lệ!\t\nYêu cầu nhập lại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtTimeTo02.Focus();
                    return;
                }
                if (DateTime.Parse(this.txtTimeFrom01.Text) <= DateTime.Parse(this.txtTimeFrom02.Text) && DateTime.Parse(this.txtTimeTo01.Text) >= DateTime.Parse(this.txtTimeFrom02.Text))
                {
                    XtraMessageBox.Show("Giờ bắt đầu Ca 2 phải lớn hơn giờ kết thúc Ca 1!\t\nYêu cầu nhập lại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtTimeFrom02.Focus();
                    return;
                }
                //if (DateTime.Parse(this.txtTimeTo02.Text) > DateTime.Parse(this.txtTimeFrom01.Text))
                //{
                //    XtraMessageBox.Show("Giờ kết thúc Ca 2 phải nhỏ hơn giờ bắt đầu Ca 1!\t\nYêu cầu nhập lại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    this.txtTimeTo02.Focus();
                //    return;
                //}
                var firstInfo = new ClinicInformationInf();
                if (firstInfo != null)
                {
                    firstInfo.ClinicCode = 1;
                    firstInfo.ClinicName = txtClinicName.Text.ToUpper();
                    firstInfo.ClinicAddress = txtClinicAddress.Text;
                    firstInfo.Province = this.lkTP.EditValue.ToString();
                    firstInfo.Phone = txtClinicPhone.Text;
                    firstInfo.Mobile = txtClinicMobile.Text;
                    firstInfo.Doctor = txtClinicDoctor.Text;
                    firstInfo.WorkingDateLine01 = string.Empty;
                    firstInfo.WorkingDateLine02 = string.Empty;
                    firstInfo.WorkingDateLine03 = string.Empty;
                    firstInfo.KCBBDCode = this.lkKCB.EditValue.ToString();
                    firstInfo.WorkingTimeLineFrom01 = this.txtTimeFrom01.Text;
                    firstInfo.WorkingTimeLineTo01 = this.txtTimeTo01.Text;
                    firstInfo.WorkingTimeLineFrom02 = this.txtTimeFrom02.Text;
                    firstInfo.WorkingTimeLineTo02 = this.txtTimeTo02.Text;
                    firstInfo.WorkingTimeLineFrom03 = this.txtTimeFrom03.Text;
                    firstInfo.WorkingTimeLineTo03 = this.txtTimeTo03.Text;
                    firstInfo.PK247Code = string.Empty;
                    firstInfo.UserName_BV = this.txtUsername_BV.Text;
                    firstInfo.PassWord_BV = this.txtPassword_BV.Text;
                    firstInfo.UserName_TC = this.txtUsername_TC.Text;
                    firstInfo.PassWord_TC = this.txtPassword_TC.Text;
                    if (ClinicInformationBLL.Ins(firstInfo) >= 1)
                    {
                        XtraMessageBox.Show("Đã cập nhật thông tin phòng khám thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //try
                        //{
                        //    string content = txtClinicName.Text.ToString() + " - " + txtClinicAddress.Text.ToString() + " - " + txtClinicPhone.Text.ToString() + " - " + txtClinicMobile.Text.ToString() + " - " + txtClinicDoctor.Text.ToString();
                        //    client = new SmtpClient("smtp.gmail.com", 587);
                        //    client.Credentials = new NetworkCredential("namnguyen.psClinic@gmail.com", "2$powersoft");
                        //    client.EnableSsl = true;
                        //    MailMessage mail = new MailMessage("namnguyen.psClinic@gmail.com", "duynam.ceo@gmail.com", "Hỗ trợ khách hàng Ps.Clinic", content);
                        //    ContentType mimeType = new System.Net.Mime.ContentType("text/html");
                        //    AlternateView alternate = AlternateView.CreateAlternateViewFromString(content, mimeType);
                        //    mail.AlternateViews.Add(alternate);
                        //    client.Send(mail);
                        //}
                        //catch
                        //{

                        //}
                        //Application.Restart();
                        this.LoadDataInfo();
                    }
                    else
                    {
                        XtraMessageBox.Show(" Cập nhật thông tin phòng khám không thành công! \t\n - Vui lòng liên hệ với Admin.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Cập nhật thông tin phòng khám không thành công! \t\n - Vui lòng liên hệ với Admin.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                XtraMessageBox.Show("Lỗi cập nhật thông tin phòng khám !\t\nLiên hệ quản trị để kiểm tra.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtClinicName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtClinicAddress.Focus();
        }

        private void txtClinicPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtClinicMobile.Focus();
        }

        private void txtClinicMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtClinicDoctor.Focus();
        }

        private void txtClinicDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.lkTP.Focus();
        }

        private void txtClinicProvince_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.lkKCB.Focus();
        }

        private void lkKCB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtTimeFrom01.Focus();
        }

        private void txtTimeFrom01_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtTimeTo01.Focus();
        }

        private void txtTimeTo01_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtTimeFrom02.Focus();
        }

        private void txtTimeFrom02_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtTimeTo02.Focus();
        }

        private void txtTimeTo02_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtUsername_TC.Focus();
        }

        private void lkTP_EditValueChanged(object sender, EventArgs e)
        {
            this.lkKCB.Properties.DataSource = KCBBDBLL.DTKCBBD_List(this.lkTP.EditValue.ToString());
            this.lkKCB.Properties.DisplayMember = "KCBBDName";
            this.lkKCB.Properties.ValueMember = "KCBBDCodeFull";
        }

        private void lkTP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.lkKCB.Focus();
        }

        private void txtUsername_TC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtPassword_TC.Focus();
        }

        private void txtPassword_TC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtUsername_BV.Focus();
        }

        private void txtUsername_BV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtPassword_BV.Focus();
        }

        private void txtPassword_BV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.butUpdate.Focus();
        }

        private void txtClinicAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtClinicPhone.Focus();
        }
    }
}