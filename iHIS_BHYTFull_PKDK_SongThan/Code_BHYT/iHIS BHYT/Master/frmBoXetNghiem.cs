using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;

namespace Ps.Clinic.Master
{
    public partial class frmBoXetNghiem : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string userid = string.Empty;
        private int serviceMenuID = 16;
        private string serviceGroupCode = "XN";
        private DataTable tableLabPackage = new DataTable();
        private DataTable tablePackageDetail = new DataTable();
        
        public frmBoXetNghiem(string _Userid)
        {
            InitializeComponent();
            userid = _Userid;
        }

        private void frmBoXetNghiem_Load(object sender, EventArgs e)
        {
            try
            {
                this.rep_LaboratoryName.DataSource = LaboratoryBLL.ListLaboratory(0);
                this.rep_LaboratoryName.DisplayMember = "LaboratoryName";
                this.rep_LaboratoryName.ValueMember = "LaboratoryName";

                this.rep_UnitValuesName.DataSource = UnitValuesBLL.ListUnitValues(0);
                this.rep_UnitValuesName.DisplayMember = "UnitValuesName";
                this.rep_UnitValuesName.ValueMember = "UnitValuesName";

                DataSet dsTypeMenu = new DataSet();
                dsTypeMenu.ReadXml(Utils.CurrentPathApplication() + "\\xml\\LabTypeResult.xml");
                this.lkupTypeResult.Properties.DataSource = dsTypeMenu.Tables[0];
                this.lkupTypeResult.Properties.DisplayMember = "Title";
                this.lkupTypeResult.Properties.ValueMember = "Value";
                this.lkupTypeResult.EditValue = "1";

                this.repTypeResult.DataSource = dsTypeMenu.Tables[0].Select("Value>0").CopyToDataTable();
                this.repTypeResult.DisplayMember = "Title";
                this.repTypeResult.ValueMember = "Value";

                this.gridView_Laboratory.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                this.gridView_Laboratory.OptionsBehavior.ReadOnly = true;
                this.gridView_Laboratory.OptionsBehavior.Editable = false;
                this.LoadDataService();
                this.LoadData();
                this.EnableText(true);
                this.EnableButton(false);
            }
            catch (Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadDataService()
        {
            this.searchlkService.Properties.DataSource = this.repLaboratory_Service.DataSource = LaboratoryResultDescriptionBLL.TableLabTypeResultTemplate(this.serviceGroupCode, Convert.ToInt32(this.lkupTypeResult.EditValue));
            this.repLaboratory_Service.DisplayMember = "ServiceName";
            this.repLaboratory_Service.ValueMember = "ServiceCode";

            this.searchlkService.Properties.DisplayMember = "ServiceName";
            this.searchlkService.Properties.ValueMember = "ServiceCode";
        }

        private void LoadData()
        {
            this.tableLabPackage = LaboratoryPackageBLL.TableLabPackageForModule(this.serviceGroupCode, Convert.ToInt32(this.lkupTypeResult.EditValue));
            this.gridControl_Laboratory_Package.DataSource = this.tableLabPackage;
            //this.gridView_Laboratory_Package.Columns["ServiceCategoryName"].Group();
        }

        private void gridView_Laboratory_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (this.gridView_Laboratory.GetFocusedRow() != null)
            {
                try
                {
                    string refLaboratoryPackageCode = this.gridView_Laboratory_Package.GetRowCellValue(this.gridView_Laboratory_Package.FocusedRowHandle, this.colLab_LaboratoryPackageCode).ToString();
                    this.gridView_Laboratory.SetRowCellValue(e.RowHandle, this.col_Details_LaboratoryPackageCode, refLaboratoryPackageCode);
                    this.gridView_Laboratory.SetRowCellValue(e.RowHandle, this.col_Details_ValuedMale, string.Empty);
                    this.gridView_Laboratory.SetRowCellValue(e.RowHandle, this.col_Details_ValuedFemale, string.Empty);
                    this.gridView_Laboratory.SetRowCellValue(e.RowHandle, this.col_Details_MinValuedFemale, 0);
                    this.gridView_Laboratory.SetRowCellValue(e.RowHandle, this.col_Details_MaxValuedFemale, 0);
                    this.gridView_Laboratory.SetRowCellValue(e.RowHandle, this.col_Details_MinValuedMale, 0);
                    this.gridView_Laboratory.SetRowCellValue(e.RowHandle, this.col_Details_MaxValuedMale, 0);
                    this.gridView_Laboratory.SetRowCellValue(e.RowHandle, this.col_Details_STT, 0);
                }
                catch
                {
                    XtraMessageBox.Show("Lỗi xảy ra khi khai báo bộ xét nghiệm ! \t\n Hãy thử lại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }
        
        private void gridView_Laboratory_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Details_LaboratoryName)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Details_LaboratoryName, " Nhập tên - nội dung thông số xét nghiệm !");
                }
                else if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Details_UnitValues)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Details_UnitValues, " Nhập đơn vị đo !");
                }
                else if(!Utils.CheckNumber(view.GetRowCellValue(rowfocus, col_Details_STT).ToString()))
                {
                    e.Valid = false;
                    view.SetColumnError(col_Details_STT, " Số thứ tự phải là số!");
                }
                else
                {
                    LaboratoryPackageDetailInf inf = new LaboratoryPackageDetailInf();
                    inf.LaboratoryPackageCode = this.txtLaboratoryPackageCode.Text;
                    inf.LaboratoryName = view.GetRowCellValue(rowfocus, col_Details_LaboratoryName).ToString();
                    inf.UnitValues = view.GetRowCellValue(rowfocus, col_Details_UnitValues).ToString();
                    inf.ValuedFemale = view.GetRowCellValue(rowfocus, col_Details_ValuedFemale).ToString();
                    inf.ValuedMale = view.GetRowCellValue(rowfocus, col_Details_ValuedMale).ToString();
                    if (view.GetRowCellValue(rowfocus, col_Details_MinValuedFemale).ToString() != string.Empty)
                        inf.MinValuedFemale = Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_Details_MinValuedFemale).ToString());
                    if (view.GetRowCellValue(rowfocus, col_Details_MaxValuedFemale).ToString() != string.Empty)
                        inf.MaxValuedFemale = Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_Details_MaxValuedFemale).ToString());
                    if (view.GetRowCellValue(rowfocus, col_Details_MinValuedMale).ToString() != string.Empty)
                        inf.MinValuedMale = Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_Details_MinValuedMale).ToString());
                    if (view.GetRowCellValue(rowfocus, col_Details_MaxValuedMale).ToString() != string.Empty)
                        inf.MaxValuedMale = Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_Details_MaxValuedMale).ToString());
                    if (view.GetRowCellValue(rowfocus, col_Details_STT).ToString() != string.Empty)
                        inf.STT = Convert.ToInt32(view.GetRowCellValue(rowfocus, col_Details_STT).ToString());
                    inf.ParameterMachine = view.GetRowCellValue(rowfocus, col_Details_ParameterMachine).ToString();
                    inf.ValuesEntry = view.GetRowCellValue(rowfocus, col_Details_ValuesEntry).ToString();
                    if (!string.IsNullOrEmpty(inf.LaboratoryPackageCode))
                    {
                        if (e.RowHandle < 0)
                        {
                            inf.RowID = 0;
                            if (LaboratoryPackageBLL.InsPackageDetail(inf) < 1)
                            {
                                XtraMessageBox.Show(" Khai báo nội dung thông số xét nghiệm không thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.gridView_Laboratory.DeleteRow(e.RowHandle);
                                return;
                            }
                            else
                                this.gridControl_Laboratory.DataSource = LaboratoryPackageBLL.TableLabPackageDetail(this.txtLaboratoryPackageCode.Text);
                        }
                        else
                        {
                            inf.RowID = Convert.ToInt32(view.GetRowCellValue(rowfocus, col_Details_RowID).ToString());
                            if (LaboratoryPackageBLL.InsPackageDetail(inf) == 1)
                            {
                                XtraMessageBox.Show(" Cập nhật thông số xét nghiệm thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.gridControl_Laboratory.DataSource = LaboratoryPackageBLL.TableLabPackageDetail(this.txtLaboratoryPackageCode.Text);
                            }
                            else
                            {
                                XtraMessageBox.Show(" Cập nhật thông số xét nghiệm thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridControl_Laboratory_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && this.gridView_Laboratory.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show(" Bạn có muốn xóa thông số xét nghiệm đang chọn hay không? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    if (LaboratoryPackageBLL.DelDetail(Int32.Parse(this.gridView_Laboratory.GetRowCellValue(this.gridView_Laboratory.FocusedRowHandle, "RowID").ToString()), this.txtLaboratoryPackageCode.Text) == 1)
                        this.LoadPackageDetail();
                }
            }
        }

        private void gridView_Laboratory_Package_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                if (this.gridView_Laboratory_Package.RowCount > 0)
                {
                    if (this.gridView_Laboratory_Package.GetFocusedRow() != null)
                    {
                        this.txtLaboratoryPackageCode.Text = this.gridView_Laboratory_Package.GetRowCellValue(this.gridView_Laboratory_Package.FocusedRowHandle, this.colLab_LaboratoryPackageCode).ToString();
                        this.txtHeaderCode.Text = this.gridView_Laboratory_Package.GetRowCellValue(this.gridView_Laboratory_Package.FocusedRowHandle, this.colLab_TemplateHeaderCode).ToString();
                        string serviceCodeTemp = this.gridView_Laboratory_Package.GetRowCellValue(this.gridView_Laboratory_Package.FocusedRowHandle, this.colLab_ServiceCode).ToString();
                        string laboratoryPackageName = this.gridView_Laboratory_Package.GetRowCellValue(this.gridView_Laboratory_Package.FocusedRowHandle, this.colLab_LaboratoryPackageName).ToString();
                        int typeResultTemp = Convert.ToInt32(this.gridView_Laboratory_Package.GetRowCellValue(this.gridView_Laboratory_Package.FocusedRowHandle, this.colLab_TypeResult).ToString());
                        if (typeResultTemp.Equals(1))
                        {
                            this.tabPage01.PageEnabled = true;
                            this.tabPage02.PageEnabled = false;
                            this.LoadPackageDetail();
                        }
                        else if (typeResultTemp.Equals(2))
                        {
                            this.tabPage01.PageEnabled = false;
                            this.tabPage02.PageEnabled = true;
                            this.LoadPatternDetail(this.txtHeaderCode.Text);
                        }
                        this.searchlkService.EditValue = serviceCodeTemp;
                        this.txtLabName.Text = laboratoryPackageName;
                        this.btnEdit.Enabled = this.btnDelete.Enabled = true;
                        this.btnSave.Enabled = false;
                        this.EnableText(true);
                        this.gridView_Laboratory.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    }
                    else
                        this.gridControl_Laboratory.DataSource = null;
                }
                else
                    this.gridControl_Laboratory.DataSource = null;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void butRefesh_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadData();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void lkupTypeResult_EditValueChanged(object sender, EventArgs e)
        {
            this.butRefesh_Click(sender, e);
            if (Convert.ToInt32(this.lkupTypeResult.EditValue) == 1)
                this.VisibleTab(true);
            else if (Convert.ToInt32(this.lkupTypeResult.EditValue) == 2)
                this.VisibleTab(false);
            else
            {
                this.tabPage01.PageEnabled = true;
                this.tabPage02.PageEnabled = false;
            }
            this.ClearText();
            this.LoadDataService();
            this.btnEdit.Enabled = this.btnSave.Enabled = this.btnDelete.Enabled = false;
        }

        private void VisibleTab(bool b)
        {
            this.tabPage01.PageEnabled = b;
            this.tabPage02.PageEnabled = !b;
        }
        
        private void LoadPatternDetail(string templateHeaderCode)
        {
            var listTemplate = TemplateDescriptionBLL.ObjTemplate(templateHeaderCode);
            if (listTemplate != null && !string.IsNullOrEmpty(listTemplate.TemplateHeaderCode))
            {
                if (string.IsNullOrEmpty(listTemplate.TemplateHeaderName))
                    this.txtLabName.Text = this.gridView_Laboratory_Package.GetRowCellValue(this.gridView_Laboratory_Package.FocusedRowHandle, this.colLab_LaboratoryPackageName).ToString();
                else
                    this.txtLabName.Text = listTemplate.TemplateHeaderName;
                this.txtContent.RtfText = listTemplate.Contents;
                //this.txtConclusion.RtfText = listTemplate[0].Conclusion;
                //this.txtProposal.Text = listTemplate[0].Proposal;
            }
            else
            {
                this.txtLabName.Text = this.gridView_Laboratory_Package.GetRowCellValue(this.gridView_Laboratory_Package.FocusedRowHandle, this.colLab_LaboratoryPackageName).ToString();
                this.txtContent.RtfText = string.Empty;
                //this.txtConclusion.RtfText = this.txtProposal.Text = string.Empty;
            }
        }
        
        
        private void LoadPackageDetail()
        {
            this.tablePackageDetail = LaboratoryPackageBLL.TableLabPackageDetail(this.txtLaboratoryPackageCode.Text);
            this.gridControl_Laboratory.DataSource = this.tablePackageDetail;
        }
        
        private void repLaboratory_Service_Popup(object sender, EventArgs e)
        {
            PopupSearchLookUpEditForm f = (sender as DevExpress.Utils.Win.IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            SearchEditLookUpPopup popup = f.ActiveControl as SearchEditLookUpPopup;
            popup.FindTextBox.Text = "\"\"";
            popup.FindTextBox.SelectionStart = 1;
        }

        private void rep_LaboratoryName_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
            string LaboratoryNameTemp = searchEdit.Properties.View.GetFocusedRowCellValue("LaboratoryName").ToString();
            DataRow row = Utils.GetPriceRowbyCode(this.tablePackageDetail, "LaboratoryName='" + LaboratoryNameTemp + "'");
            if (row != null)
            {
                this.gridView_Laboratory.SetFocusedRowCellValue(this.col_Details_LaboratoryName, string.Empty);
                XtraMessageBox.Show("Đơn vị đã tồn tại!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void ClearText()
        {
            this.searchlkService.EditValue = string.Empty;
            this.txtLabName.Text = string.Empty;
            this.txtLaboratoryPackageCode.Text = string.Empty;
            this.txtHeaderCode.Text = string.Empty;
            this.txtContent.RtfText = string.Empty;
            this.gridControl_Laboratory.DataSource = this.tablePackageDetail;
        }
        private void EnableText(bool b)
        {
            this.searchlkService.ReadOnly = b;
            this.txtLabName.ReadOnly = b;
            this.txtContent.ReadOnly = b;
            this.gridView_Laboratory.OptionsBehavior.ReadOnly = b;
            this.gridView_Laboratory.OptionsBehavior.Editable = !b;
        }
        private void EnableButton(bool b)
        {
            this.btnSave.Enabled = b;
            this.btnEdit.Enabled = b;
            this.btnDelete.Enabled = b;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.ClearText();
            this.EnableText(false);
            this.LoadDataService();
            this.searchlkService.Focus();
            this.btnEdit.Enabled = this.btnDelete.Enabled = false;
            this.btnSave.Enabled = true;
            this.LoadPackageDetail();
            this.gridView_Laboratory.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.btnEdit.Enabled = this.btnDelete.Enabled = false;
            this.btnSave.Enabled = true;
            this.EnableText(false);
            this.gridView_Laboratory.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtLabName.Text))
                {
                    XtraMessageBox.Show(" Vui lòng nhập tên bộ xét nghiệm trả kết quả!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtLabName.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(this.txtLaboratoryPackageCode.Text) && LaboratoryPackageBLL.TableLabPackageForServiceCode(this.searchlkService.EditValue.ToString()).Rows.Count > 0)
                {
                    XtraMessageBox.Show("Dịch vụ đã được khai báo!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.searchlkService.Focus();
                    return;
                }
                else
                {
                    LaboratoryPackageInf objPack = new LaboratoryPackageInf { LaboratoryPackageCode = this.txtLaboratoryPackageCode.Text, EmployeeCode = this.userid, ServiceCode = this.searchlkService.EditValue.ToString(), LaboratoryPackageName = this.txtLabName.Text.Trim(), TypeResult = Convert.ToInt32(this.lkupTypeResult.EditValue), TemplateHeaderCode = this.txtHeaderCode.Text };
                    string resultCode = string.Empty;
                    if (LaboratoryPackageBLL.InsPackage(objPack, ref resultCode) == 1)
                    {
                        if (this.tablePackageDetail != null && this.tablePackageDetail.Rows.Count > 0)
                        {
                            foreach (DataRow row in this.tablePackageDetail.Rows)
                            {
                                LaboratoryPackageDetailInf inf = new LaboratoryPackageDetailInf();
                                inf.LaboratoryPackageCode = resultCode;
                                inf.LaboratoryName = row["LaboratoryName"].ToString();
                                inf.UnitValues = row["UnitValues"].ToString();
                                inf.ValuedFemale = row["ValuedFemale"].ToString();
                                inf.ValuedMale = row["ValuedMale"].ToString();
                                inf.MinValuedFemale = Convert.ToDecimal(row["MinValuedFemale"].ToString());
                                inf.MaxValuedFemale = Convert.ToDecimal(row["MaxValuedFemale"].ToString());
                                inf.MinValuedMale = Convert.ToDecimal(row["MinValuedMale"].ToString());
                                inf.MaxValuedMale = Convert.ToDecimal(row["MaxValuedMale"].ToString());
                                inf.STT = Convert.ToInt32(row["STT"].ToString());
                                inf.ParameterMachine = row["ParameterMachine"].ToString();
                                inf.ValuesEntry = row["ValuesEntry"].ToString();
                                LaboratoryPackageBLL.InsPackageDetail(inf);
                            }
                        }
                        this.LoadDataService();
                        this.txtLaboratoryPackageCode.Text = resultCode;
                        this.LoadPackageDetail();
                    }
                    else
                    {
                        XtraMessageBox.Show(" Khai báo thông số xét nghiệm không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.gridView_Laboratory_Package.SetFocusedRowCellValue(this.colLab_ServiceCode, string.Empty);
                        return;
                    }
                    if (Convert.ToInt32(this.lkupTypeResult.EditValue) == 2)
                        this.SaveTemplateDescription();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtLaboratoryPackageCode.Text.Trim()))
            {
                if (XtraMessageBox.Show(" Bạn có muốn hủy bộ thông số xét nghiệm đang chọn hay không? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        if (Convert.ToInt32(this.lkupTypeResult.EditValue) == 2)
                            TemplateDescriptionBLL.Del(this.txtHeaderCode.Text.Trim());
                        if (LaboratoryPackageBLL.Del(this.txtLaboratoryPackageCode.Text.Trim()) >= 1)
                        {
                            this.txtLabName.Text = string.Empty;
                            this.txtLaboratoryPackageCode.Text = string.Empty;
                            this.searchlkService.EditValue = string.Empty;
                            this.LoadData();
                            this.LoadPackageDetail();
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Chọn bộ xét nghiệm cần xóa!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void searchlkService_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtLabName.Text))
                this.txtLabName.Text = this.searchlkService.Text;
            this.txtLabName.Focus();
        }
        private void SaveTemplateDescription()
        {
            try
            {
                if (this.txtContent.Text == string.Empty)
                {
                    XtraMessageBox.Show(" Nhập nội dung mẫu mô tả !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    TemplateDescriptionInf model = new TemplateDescriptionInf();
                    model.TemplateHeaderCode = this.txtHeaderCode.Text;
                    model.TemplateHeaderName = this.txtLabName.Text;
                    model.Apply = 2;
                    model.Contents = this.txtContent.RtfText;
                    //model.Conclusion = txtConclusion.RtfText;
                    //model.Proposal = txtProposal.Text.TrimEnd();
                    model.EmployeeCode = this.userid;
                    model.ServiceCode = this.searchlkService.EditValue.ToString();
                    model.EmployeeDoctorCode = string.Empty;
                    model.PrintPaper = "A4";
                    model.ServiceMenuID = this.serviceMenuID;
                    string resultCode = string.Empty;
                    if (TemplateDescriptionBLL.Ins(model, ref resultCode) >= 1)
                    {
                        this.txtHeaderCode.Text = resultCode;
                        XtraMessageBox.Show(" Cập nhật mẫu mô tả thành công.\t\n" + this.txtLabName.Text.ToUpper(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LaboratoryPackageBLL.UpdPackageTemplateHeader(this.searchlkService.EditValue.ToString(), resultCode);
                        this.EnableText(true);
                        this.btnSave.Enabled = this.btnEdit.Enabled = this.btnDelete.Enabled = false;
                    }
                    else
                    {
                        XtraMessageBox.Show(" Cập nhật mẫu mô tả thất bại.\t\n" + this.txtLabName.Text.ToUpper(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    this.LoadData();
                }
            }
            catch
            {
                XtraMessageBox.Show("Lỗi khai báo mẫu kết quả xét nghiệm ! \t\n Hãy xem lại thông tin trước khi lưu.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
    }
}