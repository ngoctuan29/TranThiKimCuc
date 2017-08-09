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
    public partial class frmTheEndReceive : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string employeeCode = "";
        public frmTheEndReceive(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }
                
        private void btAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dateFrom.Value > this.dateTo.Value)
                {
                    XtraMessageBox.Show(" Ngày chọn không hợp lệ! Vui lòng chọn lại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.dateFrom.Focus();
                    return;
                }
                else
                {
                    Int32 result = PatientReceiveBLL.UpdPatientForStatus(this.dateFrom.Text, this.dateTo.Text, 2);
                    if (result > 0)
                        XtraMessageBox.Show(" Kết thúc khám bệnh thành công.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        XtraMessageBox.Show(" Kết thúc không thành công.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Lỗi kết nối máy chủ!\t\n-Liên hệ quản trị để kiểm tra chi tiết:\t\n" + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}