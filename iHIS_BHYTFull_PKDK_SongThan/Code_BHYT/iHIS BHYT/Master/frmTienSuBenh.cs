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
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ClinicModel;
using ClinicBLL;
using ClinicLibrary;

namespace Ps.Clinic.Master
{
    public partial class frmTienSuBenh : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private decimal rowID = 0;
        private string employeeCode = string.Empty;
        public frmTienSuBenh(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }

        private void frmTienSuBenh_Load(object sender, EventArgs e)
        {
            this.GetData();
            this.ReadOnlyText(true);
            this.ClearText();
            this.butSave.Enabled = false;
            this.butCancel.Enabled = false;
            this.butEdit.Enabled = false;
        }

        private void GetData()
        {
            this.gridControl_Medical_History.DataSource = MedicalHistoryBLL.TableMedicalHistory(0);
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtName.Text.Trim() == string.Empty)
                {
                    XtraMessageBox.Show(" Nhập tên mẫu tiền sử bệnh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtName.Focus();
                    return;
                }
                else if (this.txtContentPattern.Text.Trim() == string.Empty)
                {
                    XtraMessageBox.Show(" Nhập nội dung tiền sử bệnh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtContentPattern.Focus();
                    return;
                }
                else
                {
                    Int32 result = 0;
                    MedicalHistoryInf medical = new MedicalHistoryInf();
                    medical.RowID = this.rowID;
                    medical.MedicalHistoryName = this.txtName.Text.Trim();
                    medical.MedicalHistoryContent = this.txtContentPattern.RtfText.ToString();
                    medical.EmployeeCode = this.employeeCode;
                    result = MedicalHistoryBLL.InsMedicalHistory(medical);
                    if (result > 0)
                    {
                        XtraMessageBox.Show(" Thêm thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.GetData();
                        this.ReadOnlyText(true);
                        this.butSave.Enabled = false;
                        this.butCancel.Enabled = false;
                        this.butEdit.Enabled = false;
                        this.butContinues.Focus();
                    }
                    else
                    {
                        XtraMessageBox.Show(" Thêm thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch { return; }
        }

        private void ReadOnlyText(bool b)
        {
            this.txtName.Properties.ReadOnly = b;
            this.txtContentPattern.ReadOnly = b;
        }

        private void ClearText()
        {
            this.txtName.Text = this.txtContentPattern.Text = string.Empty;
            this.rowID = 0;
        }

        private void butContinues_Click(object sender, EventArgs e)
        {
            try
            {
                this.ReadOnlyText(false);
                this.ClearText();
                this.butSave.Enabled = true;
                this.butCancel.Enabled = false;
                this.butEdit.Enabled = false;
                this.txtName.Focus();
            }
            catch { return; }
        }

        private void gridView_Medical_History_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                this.rowID = Convert.ToDecimal(this.gridView_Medical_History.GetFocusedRowCellValue("RowID").ToString());
                DataTable tableMedical = MedicalHistoryBLL.TableMedicalHistory(this.rowID);
                if (tableMedical.Rows.Count > 0)
                {
                    this.txtName.Text = tableMedical.Rows[0]["MedicalHistoryName"].ToString();
                    this.txtContentPattern.RtfText = tableMedical.Rows[0]["MedicalHistoryContent"].ToString();
                    this.butEdit.Enabled = true;
                    this.butCancel.Enabled = true;
                    this.butSave.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show(" Chi tiết mẫu khai tiền sử bệnh chưa có!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch { }
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            this.butSave.Enabled = true;
            this.butCancel.Enabled = false;
            this.butEdit.Enabled = false;
            this.ReadOnlyText(false);
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.txtContentPattern.Focus();
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(" Bạn có muốn xóa mẫu bệnh án này? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
            {
                try
                {
                    if (MedicalHistoryBLL.DelMedicalHistory(this.rowID)>=0)
                    {
                        this.GetData();
                        this.ReadOnlyText(true);
                        this.ClearText();
                        this.butSave.Enabled = false;
                        this.butCancel.Enabled = false;
                        this.butEdit.Enabled = false;
                    }
                    else
                    {
                        XtraMessageBox.Show(" Xóa không thành công! Vui lòng thực hiện lại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch { return; }
            }
        }

    }
}