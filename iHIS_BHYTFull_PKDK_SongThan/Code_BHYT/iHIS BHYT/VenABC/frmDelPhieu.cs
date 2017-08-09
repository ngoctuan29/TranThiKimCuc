using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClinicBLL;

namespace Ps.Clinic.VenABC
{
    public partial class frmDelPhieu : DevExpress.XtraEditors.XtraForm
    {
        public frmDelPhieu()
        {
            InitializeComponent();
        }

        private void frmDelPhieu_Load(object sender, EventArgs e)
        {
            DataTable tbAnalist = Ven_AnalistBLL.GetListVENABC_Analist();
            this.lktPhieuABC.Properties.DataSource = tbAnalist;
            this.lktPhieuABC.Properties.DisplayMember = "VENABC_Code";
            this.lktPhieuABC.Properties.ValueMember = "VENABC_Code";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if(lktPhieuABC.EditValue == null)
                {
                    XtraMessageBox.Show("Vui lòng chọn phiếu để xóa!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Ven_AnalistBLL.Delete_VENABC_Analist(lktPhieuABC.EditValue.ToString()) == 1)
                {
                    XtraMessageBox.Show("Xóa dữ liệu thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Xóa dữ liệu thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}