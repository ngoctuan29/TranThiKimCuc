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
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Master
{
    public partial class frmMedicalPattern : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string userID = "";
        private int rowid = 0;
        public frmMedicalPattern(string _User)
        {
            InitializeComponent();
            userID = _User;
        }

        private void frmMedicalPattern_Load(object sender, EventArgs e)
        {
            try
            {
                this.searchlkService.Properties.DataSource = ServiceBLL.ListServiceReal("KCB", "");
                this.searchlkService.Properties.DisplayMember = "ServiceName";
                this.searchlkService.Properties.ValueMember = "ServiceCode";
                this.ClearText();
                this.EnableButton(false);
                this.LoadPattern(0);
            }
            catch { return; }
        }

        private void LoadPattern(int rowid)
        {
            MedicalPatternBLL pattern = new MedicalPatternBLL();
            DataTable dtTemp = new DataTable();
            dtTemp = pattern.TablePattern(rowid);
            this.gridControl_List.DataSource = dtTemp;
        }

        private void ClearText()
        {
            this.rowid = 0;
            this.txtTemplate_Name.Text = string.Empty;
            this.txtContent.Text = string.Empty;
            this.searchlkService.EditValue = null;
        }

        private void EnableButton(bool b)
        {
            this.txtTemplate_Name.Enabled = b;
            this.txtContent.Enabled = b;
            this.searchlkService.Enabled = b;
            this.butNew.Enabled = !b;
            this.butSave.Enabled = b;
            this.butUndo.Enabled = b;
            this.butEdit.Enabled = false;
            this.butDelete.Enabled = false;
        }

        private void gridView_List_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView_List.RowCount > 0)
                {
                    if (gridView_List.GetFocusedRow() != null)
                    {
                        this.rowid = Convert.ToInt32(gridView_List.GetRowCellValue(gridView_List.FocusedRowHandle, collist_RowID).ToString());
                        this.txtTemplate_Name.Text = gridView_List.GetRowCellValue(gridView_List.FocusedRowHandle, collist_Title).ToString();
                        this.txtContent.RtfText = gridView_List.GetRowCellValue(gridView_List.FocusedRowHandle, collist_Contents).ToString();
                        this.searchlkService.EditValue = gridView_List.GetRowCellValue(gridView_List.FocusedRowHandle, collist_ServiceCode).ToString();
                        this.EnableButton(false);
                        this.butDelete.Enabled = true;
                        this.butEdit.Enabled = true;
                    }
                    else
                    {
                        this.ClearText();
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            this.gridControl_List.Visible = true;
            this.EnableButton(true);
            this.ClearText();         
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (txtTemplate_Name.Text == string.Empty)
            {
                XtraMessageBox.Show(" Nhập tên mẫu hồ sơ khám bệnh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtContent.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show(" Nhập nội dung mẫu hồ sơ khám bệnh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (searchlkService.EditValue == null)
            {
                XtraMessageBox.Show(" Vui lòng chọn công khám khi khai báo mẫu hồ sơ khám bệnh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    MedicalPatternInf model = new MedicalPatternInf();
                    model.RowID = rowid;
                    model.Title = this.txtTemplate_Name.Text;
                    model.Content = this.txtContent.RtfText;
                    model.EmployeeCode = this.userID;
                    model.ServiceCode = this.searchlkService.EditValue.ToString();
                    MedicalPatternBLL pattern = new MedicalPatternBLL();
                    if (pattern.InsPattern(model) >= 1)
                        XtraMessageBox.Show(" Cập nhật mẫu mô tả thành công.\t\n\t" + txtTemplate_Name.Text.ToUpper(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        XtraMessageBox.Show(" Cập nhật mẫu mô tả thất bại.\t\n\t" + txtTemplate_Name.Text.ToUpper(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    this.EnableButton(false);
                    this.LoadPattern(0);
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Lỗi xảy ra khi thêm mới !\t\nHãy thử lại sau.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            this.gridControl_List.Visible = true;
            try
            {
                this.EnableButton(true);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Lỗi xảy ra khi thêm mới !\t\nHãy thử lại sau.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void butUndo_Click(object sender, EventArgs e)
        {
            this.ClearText();
            this.EnableButton(false);
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (gridView_List.RowCount > 0)
            {
                if (gridView_List.GetFocusedRow() != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa mẫu mô tả này không ?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        if (this.rowid == 0)
                        {
                            XtraMessageBox.Show(" Vui lòng chọn mẫu hồ sơ cần xóa!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.gridControl_List.Focus();
                            return;
                        }
                        else
                        {
                            MedicalPatternBLL pattern = new MedicalPatternBLL();
                            if (pattern.DelPattern(this.rowid, this.userID) >= 1)
                            {
                                XtraMessageBox.Show("Xóa thành công mẫu hồ sơ khám bệnh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.EnableButton(false);
                                this.ClearText();
                                this.LoadPattern(0);
                            }
                        }
                    }
                }
            }
        }
    }
}