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
    public partial class frmLyDoHuyPhieuThu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string reason = string.Empty;
        public frmLyDoHuyPhieuThu()
        {
            InitializeComponent();
            this.txtReason.Focus();
        }

        private void butAgree_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtReason.Text.Trim()))
            {
                XtraMessageBox.Show("Vui lòng nhập lý do hủy phiếu thu.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtReason.Focus();
                return;
            }
            else
                this.reason = this.txtReason.Text.TrimEnd();
            this.Close();
        }

        private void butClosed_Click(object sender, EventArgs e)
        {
            this.reason = string.Empty;
            this.Close();            
        }

        private void txtReason_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.butAgree.Focus();
        }

    }
}