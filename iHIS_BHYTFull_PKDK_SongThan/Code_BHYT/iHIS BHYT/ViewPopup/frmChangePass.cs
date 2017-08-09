using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using Ps.Clinic.ViewPopup;
using Ps.Clinic.Master;
using Ps.Clinic.Entry;
using DevExpress.XtraGrid.Views.Grid;
using System.Net;
using DevExpress.XtraTab;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
namespace Ps.Clinic.ViewPopup
{
    public partial class frmChangePass : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string sEmployeeCode = "";
        public frmChangePass(string _sEmployeeCode)
        {
            InitializeComponent();
            sEmployeeCode = _sEmployeeCode;
        }
                
        private void btAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPasswordOld.Text == string.Empty)
                {
                    XtraMessageBox.Show(" Chưa nhập mật khẩu cũ.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPasswordOld.Focus();
                    return;
                }
                if (txtPasswordNew.Text == string.Empty)
                {
                    XtraMessageBox.Show(" Nhập mật khẩu cần thay đổi.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPasswordNew.Focus();
                    return;
                }
                if (txtPasswordNew01.Text == string.Empty)
                {
                    XtraMessageBox.Show(" Xác nhận lại mật khẩu đã thay đổi.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPasswordNew01.Focus();
                    return;
                }
                if (txtPasswordNew01.Text != txtPasswordNew.Text)
                {
                    XtraMessageBox.Show(" Xác nhận lại mật khẩu không đúng.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPasswordNew01.Focus();
                    return;
                }
                if (txtPasswordNew.Text != string.Empty && txtPasswordNew01.Text != string.Empty)
                {
                    List<EmployeeInf> lst = new List<EmployeeInf>();
                    lst = EmployeeBLL.ListEmployee(sEmployeeCode);
                    if (lst.Count > 0)
                    {
                        if (txtPasswordOld.Text != lst[0].Password)
                        {
                            XtraMessageBox.Show(" Mật khẩu cũ chưa đúng.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPasswordOld.Focus();
                            return;
                        }
                        else
                        {
                            if (EmployeeBLL.UpdPass(sEmployeeCode, txtPasswordNew.Text) == 1)
                            {
                                XtraMessageBox.Show(" Thay đổi mật khẩu thành công! \n Chương trình sẽ Restart lại.", "Bệnh viện điện tử .NET");
                                Application.Restart();
                            }
                            else
                            {
                                XtraMessageBox.Show(" Thay đổi thất bại, vui lòng xem lại thông tin!", "Bệnh viện điện tử .NET");
                                txtPasswordNew.Focus();
                                return;
                            }
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(" Tài khoản không hợp lệ!", "Bệnh viện điện tử .NET");
                        return;
                    }  
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Lỗi kết nối máy chủ!\t\n-Liên hệ quản trị để kiểm tra chi tiết:\t\n" + ex.Message);
                return;
            }
        }
        
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPasswordOld_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtPasswordNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtPasswordNew01_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

    }
}