using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Security
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public string _EmployeeCode = string.Empty;
        public string _fullname = string.Empty;
        public string _username = string.Empty;
        public bool cancel = false;
        public string shiftCode = string.Empty;
        public DateTime dtimeWorked = new DateTime();
        public frmLogin()
        {
            InitializeComponent();
            this.txtUsername.Focus();
            //this.txtUsername.Text = "Bệnh viện điện tử .NET@)!%";
            //this.txtPassword.Text = "power20150609";
        }

        private void butCANCEL_Click(object sender, EventArgs e)
        {
            this.cancel = true;
            Application.Exit();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                string sCode = string.Empty, sFullName = string.Empty;
                string passwordTemp = string.Empty;
                if (this.txtUsername.Text == string.Empty)
                {
                    XtraMessageBox.Show("Tên đăng nhập không được để trống!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtUsername.Focus();
                    return;
                }
                if (this.txtPassword.Text == string.Empty)
                {
                    XtraMessageBox.Show("Mật khẩu không được để trống!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtPassword.Focus();
                    return;
                }
                if (this.cboxWorkShift.SelectedValue == null || string.IsNullOrEmpty(this.cboxWorkShift.SelectedValue.ToString()))
                {
                    XtraMessageBox.Show("Vui lòng chọn ca làm việc!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cboxWorkShift.Focus();
                    return;
                }
                if (this.txtUsername.Text != string.Empty && this.txtPassword.Text != string.Empty)
                {
                    bool bCheckLogin = EmployeeBLL.CheckLogin(this.txtUsername.Text.Trim(), this.txtPassword.Text.Trim(), ref sCode, ref sFullName);
                    if (bCheckLogin)
                    {
                        this._username = this.txtUsername.Text.Trim();
                        this._fullname = sFullName;
                        this._EmployeeCode = sCode;
                        this.shiftCode = this.cboxWorkShift.SelectedValue.ToString();
                        this.dtimeWorked = Convert.ToDateTime(this.dtimeWorking.Text.ToString());
                        string hddSerial = Utils.GetHDDSerialNo();
                        CatalogComputerBLL.UpdDateWorking(this.dtimeWorked, hddSerial);
                        this.Close();
                    }
                    else
                    {
                        if (!EmployeeBLL.CheckUser(this.txtUsername.Text.Trim(), ref passwordTemp))
                        {
                            XtraMessageBox.Show("Tên đăng nhập không tồn tại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.txtUsername.Focus();
                        }
                        else
                        {
                            if (passwordTemp != this.txtPassword.Text.Trim())
                            {
                                XtraMessageBox.Show("Mật khẩu đăng nhập chưa đúng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.txtPassword.Focus();
                            }
                            else
                            {
                                XtraMessageBox.Show("Sai thông tin đăng nhập!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.txtUsername.Focus();
                            }
                        }
                        this._username = string.Empty;
                        this._fullname = string.Empty;
                        this._EmployeeCode = string.Empty;
                        this.shiftCode = this.cboxWorkShift.SelectedValue.ToString();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Chưa kết nối với dữ liệu!\t\n-Liên hệ quản trị để kiểm tra chi tiết:\t\n" + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                this.dtimeWorking.EditValue = this.dtimeWorked = Utils.DateTimeServer();
                this.cboxWorkShift.DataSource = Utils.TableWorkShift();
                this.cboxWorkShift.DisplayMember = "ShiftName";
                this.cboxWorkShift.ValueMember = "ShiftCode";

                #region Code kiểm tra ca mới ( Tuấn viết) fixed 13/05/2017 10:27 AM
                this.KiemTraCa();
                #endregion
                #region Code kiểm tra ca cũ
                //var firstInfo = ClinicInformationBLL.ObjInformation(1);
                //string timeRuntime = Utils.TimeServer();
                //    if (Convert.ToDateTime(timeRuntime) >= Convert.ToDateTime(firstInfo.WorkingTimeLineFrom01) && Convert.ToDateTime(timeRuntime) <= Convert.ToDateTime(firstInfo.WorkingTimeLineTo01))
                //    this.cboxWorkShift.SelectedValue = "AM";
                //else if (Convert.ToDateTime(timeRuntime) >= Convert.ToDateTime(firstInfo.WorkingTimeLineFrom02) && Convert.ToDateTime(timeRuntime) <= Convert.ToDateTime(firstInfo.WorkingTimeLineTo02))
                //    this.cboxWorkShift.SelectedValue = "PM";
                //else if (Convert.ToDateTime(timeRuntime) >= Convert.ToDateTime(firstInfo.WorkingTimeLineFrom03) && Convert.ToDateTime(timeRuntime) <= Convert.ToDateTime(firstInfo.WorkingTimeLineTo03))
                //    this.cboxWorkShift.SelectedValue = "EV";
                //else
                //    this.cboxWorkShift.SelectedValue = this.dtimeWorked.ToString("tt");
                #endregion

            }
            catch { this.cboxWorkShift.SelectedValue = this.dtimeWorked.ToString("tt"); }
        }

        private void KiemTraCa()
        {
            var firstInfo = ClinicInformationBLL.ObjInformation(1);
            string timeRuntime = Utils.TimeServer();
            DateTime ca1from = Convert.ToDateTime(firstInfo.WorkingTimeLineFrom01);
            DateTime ca1to = Convert.ToDateTime(firstInfo.WorkingTimeLineTo01);
            DateTime ca2from = Convert.ToDateTime(firstInfo.WorkingTimeLineFrom02);
            DateTime ca2to = Convert.ToDateTime(firstInfo.WorkingTimeLineTo02);
            DateTime ca3from = Convert.ToDateTime(firstInfo.WorkingTimeLineFrom03);
            DateTime ca3to = Convert.ToDateTime(firstInfo.WorkingTimeLineTo03);
            DateTime timeht = Convert.ToDateTime(timeRuntime);

            if (ca3to < ca3from)
             if (timeht > ca3from) ca3to = ca3to.AddDays(1);
              else  ca3from = Convert.ToDateTime("00:00");
            if (ca2to < ca2from)
            if (timeht > ca2from) ca2to = ca2to.AddDays(1);
                else ca2from = Convert.ToDateTime("00:00");
            if (ca1to < ca1from)
            if (timeht > ca1from) ca1to = ca1to.AddDays(1);
                else ca1from = Convert.ToDateTime("00:00");


            if (timeht >= ca1from && timeht <= ca1to)
                this.cboxWorkShift.SelectedValue = "AM";
            else if (timeht >= ca2from && timeht <= ca2to)
                this.cboxWorkShift.SelectedValue = "PM";
            else if (timeht >= ca3from && timeht <= ca3to)
                this.cboxWorkShift.SelectedValue = "EV";
            else
                this.cboxWorkShift.SelectedValue = this.dtimeWorked.ToString("tt");
            
          

        }
    }
}