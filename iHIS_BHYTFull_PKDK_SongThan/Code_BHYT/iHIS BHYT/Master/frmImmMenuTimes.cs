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
    public partial class frmImmMenuTimes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Int32 timesEntryID = -1;
        private string userid = string.Empty;
        private string serviceGroupCode = "TC";
        private DataTable tableTimesDetail = new DataTable();
        
        private List<ImmunizationTimesEntryInf> listTimesEntry = new List<ImmunizationTimesEntryInf>();

        public frmImmMenuTimes(string _employeeCode)
        {
            InitializeComponent();
            this.userid = _employeeCode;
        }

        private void frmImmMenuTimes_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadData();
                this.repLkup_DoseNo.DataSource = ImmunizationRecordBll.TableDoseNo();
                this.repLkup_DoseNo.DisplayMember = "DoseNoName";
                this.repLkup_DoseNo.ValueMember = "RowID";
                this.ClearText();
                this.EnableText(false);
                this.gridView_Detail.OptionsBehavior.ReadOnly = true;
                this.gridView_Detail.OptionsBehavior.Editable = false;
                this.gridView_Detail.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                this.butSave.Enabled = this.butEdit.Enabled = this.butDelete.Enabled = false;
            }
            catch (Exception ex) {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void LoadData()
        {
            List<ServiceInf> lstService = ServiceBLL.ListServiceReal(this.serviceGroupCode, string.Empty);
            this.searchlkup_Service.Properties.DataSource = lstService;
            this.searchlkup_Service.Properties.DisplayMember = "ServiceName";
            this.searchlkup_Service.Properties.ValueMember = "ServiceCode";

            this.repsearchLkup_Service.DataSource = lstService;
            this.repsearchLkup_Service.DisplayMember = "ServiceName";
            this.repsearchLkup_Service.ValueMember = "ServiceCode";

            this.listTimesEntry = ImmunizationTimesEntryBLL.ListTimesEntryAll();
            this.gridControl_Data.DataSource = Utils.ListToDataTable(this.listTimesEntry);
        }

        private void LoadDataTimes()
        {
            this.tableTimesDetail = ImmunizationTimesDetailBLL.TableTimesDetail(this.timesEntryID);
            this.gridControl_Detail.DataSource = this.tableTimesDetail;
        }

        private void gridView_Detail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(view.GetRowCellValue(rowfocus, this.col_Details_DoseNoID).ToString()))
                {
                    e.Valid = false;
                    view.SetColumnError(this.col_Details_DoseNoID, " Chọn mũi tiêm!");
                }
                //else if (string.IsNullOrEmpty(view.GetRowCellValue(rowfocus, this.col_Details_DayTimes).ToString()))
                //{
                //    e.Valid = false;
                //    view.SetColumnError(this.col_Details_DayTimes, " Số ngày tiêm!");
                //}
                //else if (string.IsNullOrEmpty( view.GetRowCellValue(rowfocus, this.col_Details_DayTimesCome).ToString()))
                //{
                //    e.Valid = false;
                //    view.SetColumnError(this.col_Details_DayTimes, " Số ngày tiêm lần tiếp theo!");
                //}
                if (e.Valid)
                {
                    ImmunizationTimesDetailInf inf = new ImmunizationTimesDetailInf();
                    if (!string.IsNullOrEmpty(view.GetRowCellValue(rowfocus, col_Details_TimesDetailID).ToString()))
                        inf.TimesDetailID = Convert.ToInt32(view.GetRowCellValue(rowfocus, col_Details_TimesDetailID).ToString());
                    else
                        inf.TimesDetailID = 0;
                    inf.ServiceCode = this.searchlkup_Service.EditValue.ToString();
                    inf.EmployeeCode = this.userid;
                    inf.DayTimes = view.GetRowCellValue(rowfocus, col_Details_DayTimes).ToString() == string.Empty ? -1 : Convert.ToInt32(view.GetRowCellValue(rowfocus, col_Details_DayTimes).ToString());
                    inf.DayTimesCome = view.GetRowCellValue(rowfocus, col_Details_DayTimesCome).ToString() == string.Empty ? -1 : Convert.ToInt32(view.GetRowCellValue(rowfocus, col_Details_DayTimesCome).ToString());
                    inf.DoseNoID = view.GetRowCellValue(rowfocus, col_Details_DoseNoID).ToString() == string.Empty ? -1 : Convert.ToInt32(view.GetRowCellValue(rowfocus, col_Details_DoseNoID).ToString());
                    inf.TimesEntryID = this.timesEntryID;
                    inf.Note = view.GetRowCellValue(rowfocus, this.col_Details_Note).ToString();
                    inf.Warning = view.GetRowCellValue(rowfocus, this.col_Details_Warning).ToString() == "True" ? true : false;
                    Int32 result = ImmunizationTimesDetailBLL.IUTimesDetail(inf);
                    if (result > 0)
                    {
                        this.LoadDataTimes();
                    }
                    else if (result == -2)
                    {
                        XtraMessageBox.Show(" Lần tiêm chủng này đã được khai báo!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.gridView_Detail.DeleteSelectedRows();
                    }
                    else
                    {
                        XtraMessageBox.Show(" Cập nhật lịch tiêm chủng không thành công! Vui lòng kiểm tra lại.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.LoadDataTimes();
                    }
                }
            }
            catch { this.gridView_Detail.DeleteSelectedRows(); }
        }
        
        private void gridControl_Laboratory_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_Detail.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show(" Bạn có muốn xóa lần tiêm chủng đang chọn hay không? ", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        Int32 doseNoID = Convert.ToInt32(this.gridView_Detail.GetRowCellValue(this.gridView_Detail.FocusedRowHandle, col_Details_DoseNoID).ToString());
                        Int32 result = ImmunizationTimesDetailBLL.DelTimesDetail(this.searchlkup_Service.EditValue.ToString(), doseNoID, this.userid);
                        if (result == -2)
                            XtraMessageBox.Show(" Lần tiêm chủng này đã được dùng trong đợt tiêm chủng! Không được phép xóa.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else if (result == 1)
                            this.LoadDataTimes();
                        else
                            return;
                    }
                    catch { return; }
                }
            }
        }

        private void gridView_Data_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                if (this.gridView_Data.RowCount > 0)
                {
                    if (this.gridView_Data.GetFocusedRow() != null)
                    {
                        this.timesEntryID = Convert.ToInt32(this.gridView_Data.GetRowCellValue(this.gridView_Data.FocusedRowHandle, this.col_TimesEntryID).ToString());
                        ImmunizationTimesEntryInf objEntry = ImmunizationTimesEntryBLL.ObjTimesEntryID(this.timesEntryID);
                        if (objEntry != null && !string.IsNullOrEmpty(objEntry.ServiceCode))
                        {
                            this.txtTitle.Text = objEntry.Title;
                            this.txtNote.Text = objEntry.Note;
                            this.searchlkup_Service.EditValue = objEntry.ServiceCode;
                            this.EnableText(false);
                            this.butEdit.Enabled = true;
                            this.butSave.Enabled = false;
                            this.butDelete.Enabled = true;
                            this.LoadDataTimes();
                        }
                        else
                        {
                            this.txtTitle.Text = "Tiêm chủng " + this.gridView_Data.GetRowCellValue(this.gridView_Data.FocusedRowHandle, col_Title).ToString();
                            this.txtNote.Text = string.Empty;
                            this.searchlkup_Service.EditValue = -1;
                            this.EnableText(true);
                            this.butEdit.Enabled = false;
                            this.butSave.Enabled = true;
                            this.butDelete.Enabled = false;
                            this.LoadDataTimes();
                        }
                        this.gridView_Detail.OptionsBehavior.ReadOnly = true;
                        this.gridView_Detail.OptionsBehavior.Editable = false;
                        this.gridView_Detail.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    }
                    else
                    {
                        this.gridControl_Detail.DataSource = null;
                    }
                }
                else
                {
                    this.gridControl_Detail.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void ClearText()
        {
            this.txtTitle.Text = this.txtNote.Text = string.Empty;
            this.searchlkup_Service.EditValue = string.Empty;
        }

        private void EnableText(bool b)
        {
            this.txtTitle.Properties.ReadOnly = !b;
            this.txtNote.Properties.ReadOnly = !b;
            this.searchlkup_Service.Properties.ReadOnly = true;
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                this.EnableText(true);
                this.butDelete.Enabled = this.butEdit.Enabled = false;
                this.butSave.Enabled = true;
                this.gridView_Detail.OptionsBehavior.ReadOnly = false;
                this.gridView_Detail.OptionsBehavior.Editable = true;
                this.gridView_Detail.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                this.searchlkup_Service.Focus();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Lỗi xảy khi edit !\t\nHãy thử lại sau.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.timesEntryID <= 0)
                {
                    XtraMessageBox.Show(" Chọn vắc xin để khai báo lịch tiêm ngừa!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.gridView_Data.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.txtTitle.Text.Trim()))
                {
                    XtraMessageBox.Show(" Nhập thông tin tiêm chủng!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtTitle.Focus();
                    return;
                }
                else
                {
                    ImmunizationTimesEntryInf objTemp = new ImmunizationTimesEntryInf();
                    objTemp.ServiceCode = this.searchlkup_Service.EditValue.ToString();
                    objTemp.EmployeeCode = this.userid;
                    objTemp.Note = this.txtNote.Text;
                    objTemp.Title = this.txtTitle.Text;
                    objTemp.TimesEntryID = this.timesEntryID;
                    if (!ImmunizationTimesEntryBLL.IUTimesEntry(objTemp, ref this.timesEntryID))
                    {
                        XtraMessageBox.Show(" Cập nhật thông tin khai báo lịch tiêm chủng " + this.txtTitle.Text.ToUpper() + " không thành công! \n\t Vui lòng xem lại thông tin.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show(" Cập nhật lịch tiêm vắc xin: " + this.txtTitle.Text.ToUpper() + " thành công!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LoadData();
                        this.LoadDataTimes();
                        this.EnableText(false);
                        this.butSave.Enabled = false;
                        this.butEdit.Enabled = this.butDelete.Enabled = true;
                        this.gridView_Detail.OptionsBehavior.ReadOnly = true;
                        this.gridView_Detail.OptionsBehavior.Editable = false;
                        this.gridView_Detail.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                        int rowHandle = this.gridView_Data.LocateByValue("TimesEntryID", this.timesEntryID);
                        this.gridView_Data.FocusedRowHandle = rowHandle;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error:" + ex.Message + "! \t\nHãy thử lại sau.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn hủy khai báo lịch tiêm chủng này không ?", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
            {
                int result = ImmunizationTimesEntryBLL.DelTimesEntry(this.searchlkup_Service.EditValue.ToString(), this.userid);
                if (result >= 1)
                {
                    this.ClearText();
                    this.butEdit.Enabled = this.butDelete.Enabled = this.butSave.Enabled = false;
                    this.EnableText(false);
                    this.gridControl_Detail.DataSource = null;
                    this.LoadData();
                }
                else if (result == -2)
                {
                    XtraMessageBox.Show(" Lần tiêm chủng này đã được dùng trong đợt tiêm chủng! Không được phép xóa.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void searchlkup_Service_Popup(object sender, EventArgs e)
        {
            PopupSearchLookUpEditForm f = (sender as DevExpress.Utils.Win.IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            SearchEditLookUpPopup popup = f.ActiveControl as SearchEditLookUpPopup;
            popup.FindTextBox.Text = "\"\"";
            popup.FindTextBox.SelectionStart = 1;
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearText();
                this.EnableText(true);
                this.timesEntryID = 0;
                this.butEdit.Enabled = this.butDelete.Enabled = false;
                this.butSave.Enabled = true;
                this.gridView_Detail.OptionsBehavior.ReadOnly = false;
                this.gridView_Detail.OptionsBehavior.Editable = true;
                this.gridView_Detail.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                this.LoadData();
                this.LoadDataTimes();
                this.searchlkup_Service.Focus();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void searchlkup_Service_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.txtTitle.Focus();
            }
        }

        private void txtTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.txtNote.Focus();
            }
        }

        private void searchlkup_Service_EditValueChanged(object sender, EventArgs e)
        {
            if (this.timesEntryID <= 0)
                this.txtTitle.Text = this.searchlkup_Service.Text;
        }

        private void gridView_Data_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(view.GetRowCellValue(rowfocus, this.col_Title).ToString()))
                {
                    e.Valid = false;
                    view.SetColumnError(this.col_Title, " Nhập nội dung tiêm vắc xin!");
                }
                if (e.Valid)
                {
                    ImmunizationTimesEntryInf objTemp = new ImmunizationTimesEntryInf();
                    objTemp.ServiceCode = view.GetRowCellValue(rowfocus, this.col_ServiceCode).ToString();
                    objTemp.EmployeeCode = this.userid;
                    objTemp.Note = view.GetRowCellValue(rowfocus, this.col_Note).ToString();
                    objTemp.Title = view.GetRowCellValue(rowfocus, this.col_Title).ToString();
                    objTemp.TimesEntryID = this.timesEntryID;
                    if (string.IsNullOrEmpty(view.GetRowCellValue(rowfocus, this.col_TimesEntryID).ToString()))
                        objTemp.TimesEntryID = 0;
                    else
                        objTemp.TimesEntryID = Convert.ToInt32(view.GetRowCellValue(rowfocus, this.col_TimesEntryID).ToString());
                    if (!ImmunizationTimesEntryBLL.IUTimesEntry(objTemp, ref this.timesEntryID))
                    {
                        XtraMessageBox.Show(" Cập nhật thông tin khai báo lịch tiêm chủng " + this.txtTitle.Text.ToUpper() + " không thành công! \n\t Vui lòng xem lại thông tin.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        this.LoadData();
                        int rowHandle = this.gridView_Data.LocateByValue("TimesEntryID", this.timesEntryID);
                        this.gridView_Data.FocusedRowHandle = rowHandle;
                        this.txtTitle.Text = objTemp.Title;
                        this.txtNote.Text = objTemp.Note;
                        this.searchlkup_Service.EditValue = objTemp.ServiceCode;
                        this.LoadDataTimes();
                        this.butEdit.Enabled = true;
                        this.butSave.Enabled = this.butDelete.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void repsearchLkup_Service_Popup(object sender, EventArgs e)
        {
            PopupSearchLookUpEditForm f = (sender as DevExpress.Utils.Win.IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            SearchEditLookUpPopup popup = f.ActiveControl as SearchEditLookUpPopup;
            popup.FindTextBox.Text = "\"\"";
            popup.FindTextBox.SelectionStart = 1;
        }

        private void repsearchLkup_Service_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
            string serviceCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ServiceCode").ToString();
            string serviceNameTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ServiceName").ToString();
            if (this.listTimesEntry.Where(s => s.ServiceCode == serviceCodeTemp).ToList().Count > 0 && !string.IsNullOrEmpty(serviceCodeTemp))
            {
                this.gridView_Data.SetFocusedRowCellValue(this.col_ServiceCode, string.Empty);
                XtraMessageBox.Show("Dịch vụ đã được khai báo lịch tiêm chủng!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
                this.gridView_Data.SetFocusedRowCellValue(this.col_Title, serviceNameTemp);
        }
    }
}