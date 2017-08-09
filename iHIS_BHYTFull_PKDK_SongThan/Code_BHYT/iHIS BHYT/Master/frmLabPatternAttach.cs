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
    public partial class frmLabPatternAttach : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string employeeCode = string.Empty, categoryCode = string.Empty;
        private Int32 labPatternID = 0;
        public frmLabPatternAttach(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }

        private void frmLabPatternAttach_Load(object sender, EventArgs e)
        {
            try
            {
                this.gridControl_List.DataSource = ServiceCategoryBLL.ListServiceCategory("XN", string.Empty);
                this.lkupLabPatholo.Properties.DataSource = LabPathologicalBLL.TableLabPathological();
                this.lkupLabPatholo.Properties.DisplayMember = "LabPathologicalName";
                this.lkupLabPatholo.Properties.ValueMember = "LabPathologicalID";
                this.ClearText();
                this.EnableText(false);
            }
            catch { return; }
        }

        private void ClearText()
        {
            this.txtTemplate_Name.Text = this.txtContent.Text = string.Empty;
        }

        private void EnableText(bool b)
        {
            this.txtTemplate_Name.Enabled = b;
            this.txtContent.Enabled = b;
            this.lkupLabPatholo.Enabled = b;
        }

        private void gridView_List_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_List.RowCount > 0)
                {
                    if (this.gridView_List.GetFocusedRow() != null)
                    {
                        this.categoryCode = this.gridView_List.GetRowCellValue(this.gridView_List.FocusedRowHandle, col_ServiceCategoryCode).ToString();
                        if (string.IsNullOrEmpty(this.categoryCode))
                        {
                            XtraMessageBox.Show(" Chọn xét nghiệm khai báo mẫu!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            LabPatternAttachInf objLab = LabPatternAttachBLL.ObjLabPattern(this.categoryCode);
                            if (objLab != null && !string.IsNullOrEmpty(objLab.ServiceCategoryCode))
                            {
                                this.labPatternID = objLab.LabPatternID;
                                this.EnableText(false);
                                this.butEdit.Enabled = true;
                                this.butSave.Enabled = false;
                                this.butDelete.Enabled = true;
                                this.txtTemplate_Name.Text = objLab.LabPatternTitle;
                                this.txtContent.RtfText = objLab.LabPatternContent;
                                this.lkupLabPatholo.EditValue = objLab.LabPathologicalID;
                            }
                            else
                            {
                                this.EnableText(true);
                                this.ClearText();
                                this.butEdit.Enabled = false;
                                this.butSave.Enabled = true;
                                this.butDelete.Enabled = false;
                                this.lkupLabPatholo.EditValue = 0;
                                this.txtTemplate_Name.Text = this.gridView_List.GetRowCellValue(this.gridView_List.FocusedRowHandle, this.col_ServiceCategoryName).ToString();
                            }
                        }
                    }
                    else
                    {
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

        private void butSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty( this.txtTemplate_Name.Text.Trim()))
            {
                XtraMessageBox.Show(" Nhập tên mẫu mô tả !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    LabPatternAttachInf model = new LabPatternAttachInf();
                    model.LabPatternID = this.labPatternID;
                    model.LabPatternTitle = this.txtTemplate_Name.Text.Trim();
                    model.LabPatternContent = this.txtContent.RtfText;
                    model.EmployeeCode = this.employeeCode;
                    model.ServiceCategoryCode = this.categoryCode;
                    model.WorkDate = Utils.DateTimeServer();
                    model.LabPathologicalID = Convert.ToInt32(this.lkupLabPatholo.EditValue.ToString());
                    if (LabPatternAttachBLL.InsLabPattern(model) >= 1)
                        XtraMessageBox.Show(" Cập nhật mẫu mô tả thành công.\t\n" + txtTemplate_Name.Text.ToUpper(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        XtraMessageBox.Show(" Cập nhật mẫu mô tả thất bại.\t\n" + txtTemplate_Name.Text.ToUpper(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Lỗi xảy khi lưu mẫu !\t\nHãy thử lại sau.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                this.EnableText(true);
                this.butDelete.Enabled = false;
                this.butSave.Enabled = true;
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Lỗi xảy khi edit !\t\nHãy thử lại sau.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (this.gridView_List.RowCount > 0)
            {
                if (this.gridView_List.GetFocusedRow() != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa mẫu mô tả này không ?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        string refTemplate = this.gridView_List.GetRowCellValue(this.gridView_List.FocusedRowHandle, this.col_ServiceCategoryName).ToString();
                        if (LabPatternAttachBLL.DelLabPattern(this.labPatternID) >= 1)
                        {
                            XtraMessageBox.Show(" Xóa thành công mẫu " + refTemplate + ".", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.ClearText();
                            this.butEdit.Enabled = false;
                            this.butDelete.Enabled = false;
                        }
                    }
                }
            }
        }

    }
}