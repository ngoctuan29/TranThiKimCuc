using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ps.Clinic.ADR_SST
{
    public partial class frmEntryEmail : DevExpress.XtraEditors.XtraForm
    {
        public string EmailFrom = string.Empty;
        public string stm = string.Empty;
        public string Password = string.Empty;
        public string Emailto = string.Empty;
        public string Title = string.Empty;
        public string FileName = string.Empty;
        public frmEntryEmail(string _FileName)
        {
            this.FileName = _FileName;
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string error = string.Empty;
            if (string.IsNullOrEmpty(txtEmailFrom.Text))
                error += "Nhập email người gửi \n";
            if (string.IsNullOrEmpty(txtPassword.Text))
                error += "Nhập mật khẩu người gửi \n";
            if (string.IsNullOrEmpty(txtMailTo.Text))
                error += "Nhập email người nhận \n";
            if (string.IsNullOrEmpty(txtTitle.Text))
                error += "Nhập tiêu đề \n";
            if(!string.IsNullOrEmpty(error))
            {
                XtraMessageBox.Show(error.TrimEnd('\n'), "iHIS - Bệnh viện điện tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.EmailFrom = txtEmailFrom.Text;
            this.stm = cmb.Text;
            this.Password = txtPassword.Text;
            this.Emailto = txtMailTo.Text;
            this.Title = txtTitle.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEntryEmail_Load(object sender, EventArgs e)
        {
            lblFileName.Text = this.FileName;
        }
    }
}