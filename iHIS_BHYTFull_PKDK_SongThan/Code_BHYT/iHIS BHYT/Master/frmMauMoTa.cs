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
    public partial class frmMauMoTa : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string employeeCode = string.Empty;
        private string refTemplateCode = string.Empty;
        public frmMauMoTa(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }

        private void frmMauMoTa_Load(object sender, EventArgs e)
        {
            try
            {
                this.searchlkService.Properties.DataSource = ServiceBLL.ListServiceReal("CDHA", string.Empty);
                this.searchlkService.Properties.DisplayMember = "ServiceName";
                this.searchlkService.Properties.ValueMember = "ServiceCode";

                this.searchlkDoctor.Properties.DataSource = EmployeeBLL.DTEmployee(string.Empty, false);
                this.searchlkDoctor.Properties.DisplayMember = "EmployeeName";
                this.searchlkDoctor.Properties.ValueMember = "EmployeeCode";

                this.lkupServiceMenu.Properties.DataSource = ServiceMenuBLL.ListServiceMenu().Where(mn => mn.ServiceMenuID == 3 || mn.ServiceMenuID == 4 || mn.ServiceMenuID == 5 || mn.ServiceMenuID == 6 || mn.ServiceMenuID == 10 || mn.ServiceMenuID == 11).ToList();
                this.lkupServiceMenu.Properties.DisplayMember = "ServiceMenuName";
                this.lkupServiceMenu.Properties.ValueMember = "ServiceMenuID";

                this.cbxPrinter.DataSource = this.ListPrintPaper();
                this.cbxPrinter.DisplayMember = "PrintCode";
                this.cbxPrinter.ValueMember = "PrintName";
                this.LoadDataTemplate();

                this.ClearText();
                this.EnableButton(false);
                
                this.txtContent.Appearance.Text.Options.UseFont = false;
            }
            catch { return; }
        }

        private void LoadDataTemplate()
        {
            this.gridControl_List.DataSource = TemplateDescriptionBLL.DT_ListTemplate(string.Empty);
            this.gridView_List.Columns["ServiceMenuName"].Group();
            this.gridView_List.ExpandAllGroups();
        }

        private void ClearText()
        {
            this.txtTemplate_Name.Text = string.Empty;
            this.txtContent.Text = string.Empty;
            this.txtConclusion.Text = string.Empty;
            this.txtProposal.Text = string.Empty;
            this.searchlkService.EditValue = string.Empty;
            this.searchlkService.Text = string.Empty;
            this.searchlkDoctor.EditValue = string.Empty;
            this.lkupServiceMenu.EditValue = 0;
            this.cbxPrinter.SelectedIndex = 0;
        }

        private void EnableButton(bool b)
        {
            this.txtTemplate_Name.Enabled = b;
            this.txtContent.Enabled = b;
            this.txtConclusion.Enabled = b;
            this.txtProposal.Enabled = b;
            this.searchlkService.Enabled = b;
            this.searchlkDoctor.Enabled = b;
            this.cbMen.Enabled = b;
            this.cbWoman.Enabled = b;
            this.cbAll.Enabled = b;
            this.cbxPrinter.Enabled = b;
            this.lkupServiceMenu.Properties.ReadOnly = !b;

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
                if (this.gridView_List.RowCount > 0)
                {
                    if (this.gridView_List.GetFocusedRow() != null)
                    {
                        this.refTemplateCode = this.gridView_List.GetRowCellValue(this.gridView_List.FocusedRowHandle, col_TemplateHeaderCode).ToString();
                        if (string.IsNullOrEmpty(refTemplateCode))
                        {
                            XtraMessageBox.Show("Mẫu không tồn tại.!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            string apply = this.gridView_List.GetRowCellValue(this.gridView_List.FocusedRowHandle, col_Apply).ToString();
                            if (apply == "1")
                                this.cbMen.Checked = true;
                            else if (apply == "0")
                                this.cbWoman.Checked = true;
                            else
                            {
                                this.cbAll.Checked = true;
                            }
                            //this.txtTemplate_Name.Text = this.gridView_List.GetRowCellValue(this.gridView_List.FocusedRowHandle, this.col_TemplateHeaderName).ToString();
                            //this.txtContent.RtfText = gridView_List.GetRowCellValue(gridView_List.FocusedRowHandle, col_Contents).ToString();
                            //this.txtConclusion.RtfText = gridView_List.GetRowCellValue(gridView_List.FocusedRowHandle, col_Conclusion).ToString();
                            //this.txtProposal.Text = gridView_List.GetRowCellValue(gridView_List.FocusedRowHandle, col_Proposal).ToString();
                            //this.searchlkService.EditValue = this.gridView_List.GetRowCellValue(this.gridView_List.FocusedRowHandle, this.col_ServiceCode).ToString();
                            this.LoadObjTemplate();
                            this.butDelete.Enabled = true;
                            this.butEdit.Enabled = true;
                            this.butSave.Enabled = false;
                            this.butEdit.Focus();
                        }
                    }
                    else
                        return;
                }
                else
                    return;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            this.gridControl_List.Visible = true;
            this.cbAll.Checked = true;
            this.EnableButton(true);
            this.ClearText();
            this.refTemplateCode = string.Empty;       
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (this.txtTemplate_Name.Text == string.Empty)
            {
                XtraMessageBox.Show(" Nhập tên mẫu mô tả !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.txtContent.Text == string.Empty)
            {
                XtraMessageBox.Show(" Nhập nội dung mẫu mô tả !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.lkupServiceMenu.EditValue.ToString() == string.Empty)
            {
                XtraMessageBox.Show(" Chọn loại mẫu mô tả!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.lkupServiceMenu.Focus();
                return;
            }
            else
            {
                string gender = string.Empty;
                if (cbMen.Checked == true)
                {
                    gender = "1";
                }
                else if (cbWoman.Checked == true)
                {
                    gender = "0";
                }
                else
                {
                    gender = "2";
                }
                try
                {
                    TemplateDescriptionInf model = new TemplateDescriptionInf();
                    model.TemplateHeaderCode = this.refTemplateCode;
                    model.TemplateHeaderName = this.txtTemplate_Name.Text;
                    model.Apply = Convert.ToInt32(gender);
                    model.Contents = this.txtContent.RtfText;
                    model.Conclusion = this.txtConclusion.RtfText;
                    model.Proposal = this.txtProposal.Text.TrimEnd();
                    model.EmployeeCode = this.employeeCode;
                    model.ServiceCode = this.searchlkService.EditValue.ToString();
                    model.EmployeeDoctorCode = this.searchlkDoctor.EditValue.ToString();
                    if (this.cbxPrinter.SelectedValue == null)
                        model.PrintPaper = "A4";
                    else
                        model.PrintPaper = this.cbxPrinter.SelectedValue.ToString();
                    model.ServiceMenuID = Convert.ToInt32(this.lkupServiceMenu.EditValue);
                    string resultCode = string.Empty;
                    if (TemplateDescriptionBLL.Ins(model, ref resultCode) >= 1)
                    {
                        XtraMessageBox.Show(" Cập nhật mẫu mô tả thành công.\t\n" + txtTemplate_Name.Text.ToUpper(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LoadDataTemplate();
                        int rowHandle = this.gridView_List.LocateByValue("TemplateHeaderCode", this.refTemplateCode);
                        this.gridView_List.FocusedRowHandle = rowHandle;
                        this.LoadObjTemplate();
                    }
                    else
                    {
                        XtraMessageBox.Show(" Cập nhật mẫu mô tả thất bại.\t\n" + txtTemplate_Name.Text.ToUpper(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    this.EnableButton(false);
                    ///DataTable dtTemp = new DataTable();
                    ///dtTemp = TemplateDescriptionBLL.DT_ListTemplate("").Select("ServiceGroupCode='CDHA' or ServiceGroupCode='PTTT'").CopyToDataTable();
                    ///this.gridControl_List.DataSource = dtTemp;
                    ///this.gridView_List.Columns["ServiceCategoryName"].Group();
                    ///this.gridView_List.ExpandAllGroups();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            this.gridControl_List.Visible = true;
            this.refTemplateCode = gridView_List.GetRowCellValue(gridView_List.FocusedRowHandle, col_TemplateHeaderCode).ToString();
            string gender = string.Empty;
            try
            {
                this.EnableButton(true);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Lỗi xảy ra khi thêm mới !\t\nHãy thử lại sau.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butUndo_Click(object sender, EventArgs e)
        {
            this.ClearText();
            this.EnableButton(false);
            this.refTemplateCode = string.Empty;
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (this.gridView_List.RowCount > 0)
            {
                if (this.gridView_List.GetFocusedRow() != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa mẫu mô tả này không ?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        string refTemplateCode = this.gridView_List.GetRowCellValue(this.gridView_List.FocusedRowHandle, col_TemplateHeaderCode).ToString();
                        if (refTemplateCode == "" || refTemplateCode == null)
                        {
                            XtraMessageBox.Show(" Mẫu mô tả không tồn tại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            if (TemplateDescriptionBLL.Del(refTemplateCode) >= 1)
                            {
                                XtraMessageBox.Show(" Đã xóa xong mẫu mô tả đang chọn!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.EnableButton(false);
                                this.gridControl_List.DataSource = TemplateDescriptionBLL.DT_ListTemplate(string.Empty);
                            }
                        }
                    }
                }
            }
        }

        protected void LoadObjTemplate()
        {
            TemplateDescriptionInf model = TemplateDescriptionBLL.ObjTemplate(this.refTemplateCode);
            if (model != null && !string.IsNullOrEmpty(model.TemplateHeaderCode))
            {
                this.searchlkDoctor.EditValue = model.EmployeeDoctorCode;
                this.txtTemplate_Name.Text = model.TemplateHeaderName;
                if (model.Apply == 1)
                    this.cbMen.Checked = true;
                else if (model.Apply == 0)
                    this.cbWoman.Checked = true;
                else
                    this.cbAll.Checked = true;
                this.txtContent.RtfText = model.Contents;
                this.txtConclusion.RtfText = model.Conclusion;
                this.txtProposal.Text = model.Proposal;
                this.cbxPrinter.SelectedValue = model.PrintPaper;
                this.lkupServiceMenu.EditValue = model.ServiceMenuID;
                this.searchlkService.EditValue = model.ServiceCode;
            }
            else
            {
                this.ClearText();
            }
        }

        private void searchlkService_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.txtTemplate_Name.Focus();
        }

        private void txtTemplate_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.searchlkDoctor.Focus();
        }

        private void searchlkDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                this.txtContent.Focus();
        }

        private void txtContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                this.txtConclusion.Focus();
        }

        private void txtProposal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                this.butSave.Focus();
        }
        public class PrintPaperInf
        {
            public string PrintCode { get; set; }
            public string PrintName { get; set; }
        }
        public List<PrintPaperInf> ListPrintPaper()
        {
            List<PrintPaperInf> lstPrint = new List<PrintPaperInf>();
            PrintPaperInf print = new PrintPaperInf { PrintCode = "A5", PrintName = "A5" };
            lstPrint.Add(print);
            print = new PrintPaperInf { PrintCode = "A4", PrintName = "A4" };
            lstPrint.Add(print);
            print = new PrintPaperInf { PrintCode = "A4Rotate", PrintName = "A4Rotate" };
            lstPrint.Add(print);
            return lstPrint;
        }
    }
}