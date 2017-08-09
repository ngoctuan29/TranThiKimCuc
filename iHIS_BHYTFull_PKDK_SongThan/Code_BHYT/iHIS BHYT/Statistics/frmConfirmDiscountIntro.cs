using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.Linq;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraCharts;
using System.Reflection;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing.Imaging;

namespace Ps.Clinic.Statistics
{
    public partial class frmConfirmDiscountIntro : DevExpress.XtraEditors.XtraForm
    {
        private string userID = string.Empty, shiftWork = string.Empty;
        private string groupCode = string.Empty;
        private DataTable tableServices = new DataTable();
        private DateTime dtimePosting;
        private string introNameSelect = string.Empty;
        private DataTable tableResult = new DataTable();
        private DataTable tableDicount = new DataTable();
        Excel.Application oxl;
        Excel._Workbook owb;
        Excel._Worksheet osheet;
        private DevExpress.Utils.WaitDialogForm Starting = null;

        public frmConfirmDiscountIntro(string _userID, string _shiftWork)
        {
            InitializeComponent();
            this.userID = _userID;
            this.shiftWork = _shiftWork;
        }

        private void frmConfirmDiscount_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadData();
                this.LoadDataForIntro();
            }
            catch { }
        }

        private void LoadData()
        {
            this.dtimePosting = Utils.DateServer();
            this.dtSearchForm.EditValue = this.dtSearchTo.EditValue = this.dateReportForm.EditValue = this.dateReportTo.EditValue = this.dtimePosting;
            List<ServiceGroupInf> listGroup = ServiceGroupBLL.ListServiceGroup(string.Empty).FindAll(x => x.ServiceModuleCode != "THUOC");
            this.lkupServiceGroup.Properties.DataSource = listGroup;
            this.lkupServiceGroup.Properties.ValueMember = "ServiceGroupCode";
            this.lkupServiceGroup.Properties.DisplayMember = "ServiceGroupName";
            this.chcbServiceGroupReport.Properties.DataSource = listGroup;
            this.chcbServiceGroupReport.Properties.ValueMember = "ServiceGroupCode";
            this.chcbServiceGroupReport.Properties.DisplayMember = "ServiceGroupName";
            DataTable tableIntro = IntroducerBLL.DTIntroducer(string.Empty);
            foreach (DataRow row in tableIntro.Rows)
            {
                this.cbIntroducer.Properties.Items.Add(row["IntroName"].ToString());
                this.cbIntroducerReport.Properties.Items.Add(row["IntroName"].ToString());
                this.repcbxEdit_IntroName.Items.Add(row["IntroName"].ToString());
            }
        }

        private void LoadDataForIntro()
        {
            DataTable dt = new DataTable();
            DataTable dtCareer = new DataTable();
            dt.Columns.Add(new DataColumn("StatusCode", typeof(Int32)));
            dt.Columns.Add(new DataColumn("StatusName", typeof(string)));
            dt.Rows.Add(new object[] { "0", "Nữ" });
            dt.Rows.Add(new object[] { "1", "Nam" });
            ref_status_sex.DataSource = dt;
            ref_status_sex.DisplayMember = "StatusName";
            ref_status_sex.ValueMember = "StatusCode";

            dtCareer = CareerBLL.DTCareer(string.Empty);
            ref_Career.DataSource = dtCareer;
            ref_Career.DisplayMember = "CareerName";
            ref_Career.ValueMember = "CareerCode";
            this.gridControl_NguoiGT.DataSource = IntroducerBLL.DTIntroducer(string.Empty);
        }

        private void butSearchIntro_Click(object sender, EventArgs e)
        {
            try
            {
                Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET.");
                this.GetServiceGroup();
                this.GetDateWaitingIntroName();
                this.tableServices = null;
                this.gridControl_ListPatients.DataSource = this.tableServices;
                Starting.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void GetServiceGroup()
        {
            try
            {
                this.groupCode = string.Empty;
                string tempGroup = this.lkupServiceGroup.EditValue.ToString();
                string[] arrGroup;
                if (tempGroup.Trim() != string.Empty)
                {
                    arrGroup = tempGroup.Split(',');
                    for (Int32 i = 0; i < arrGroup.Length; i++)
                    {
                        this.groupCode += "'" + arrGroup.GetValue(i).ToString().Trim(' ') + "',";
                    }
                }
                this.groupCode = this.groupCode.TrimEnd(',');
            }
            catch
            {
                this.groupCode = string.Empty;
            }
        }
        private void gridView_ListIntro_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET.");
                this.GetServiceGroup();
                this.introNameSelect = this.gridView_ListIntro.GetRowCellValue(this.gridView_ListIntro.FocusedRowHandle, col_List_IntroName).ToString();
                this.GetDataIntroNameDetail();
                Starting.Close();
            }
            catch (Exception ex){
                XtraMessageBox.Show("Error : " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void GetDateWaitingIntroName()
        {
            this.gridControl_ListIntro.DataSource = ReportDiscountBLL.GetPatientReceiveForIntroName(this.dtSearchForm.Text, this.dtSearchTo.Text, this.cbIntroducer.Text, this.groupCode, this.chkDone.Checked);
        }
        private void GetDataIntroNameDetail()
        {
            this.tableServices = ReportDiscountBLL.GetSuggestedServiceForIntroNameDetail(this.dtSearchForm.Text, this.dtSearchTo.Text, this.introNameSelect, this.groupCode, this.chkDone.Checked ? 1 : 0);
            this.gridControl_ListPatients.DataSource = this.tableServices;
        }

        private void butClearSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.lkupServiceGroup.EditValue = null;
                this.cbIntroducer.Text = this.introNameSelect = string.Empty;
                this.gridControl_ListIntro.DataSource = null;
                this.gridControl_ListPatients.DataSource = null;
                this.LoadData();
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error : " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_ListPatients_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                decimal servicePrice = Convert.ToDecimal(view.GetFocusedRowCellValue(this.col_ListDetail_ServicePrice));
                if (view.FocusedColumn.FieldName == "DiscountPer")
                {
                    if (e.Value != null)
                    {
                        Int32 discountPer = Convert.ToInt32(e.Value);
                        decimal discountAmount = (discountPer * servicePrice) / 100;
                        view.SetFocusedRowCellValue(this.col_ListDetail_DiscountAmount, discountAmount);
                    }
                }
            }
            catch { }
        }

        private void butSaveIntro_Click(object sender, EventArgs e)
        {
            try
            {
                bool bResult = true;
                DataTable tableTemp = new DataTable();
                if (!this.chkDone.Checked)
                {
                    if (this.tableServices.Select("Check=1").Length > 0)
                        tableTemp = this.tableServices.Select("Check=1").CopyToDataTable();
                }
                else
                {
                    if (this.tableServices.Select("Check=0").Length > 0)
                        tableTemp = this.tableServices.Select("Check=0").CopyToDataTable();
                    else
                        tableTemp = this.tableServices.Copy();
                }
                if (tableTemp != null && tableTemp.Rows.Count > 0)
                {
                    foreach (DataRow row in tableTemp.Rows)
                    {
                        ReportDiscountInf discount = new ReportDiscountInf
                        {
                            ReceiptID = Convert.ToDecimal(row["ReceiptID"]),
                            PatientReceiveID = Convert.ToDecimal(row["PatientReceiveID"]),
                            PatientCode = row["PatientCode"].ToString(),
                            ServiceCode = row["ServiceCode"].ToString(),
                            ServicePrice = Convert.ToDecimal(row["ServicePrice"]),
                            ServicePriceOverTime = 0,
                            DiscountAmount = Convert.ToDecimal(row["DiscountAmount"]),
                            DiscountPer = Convert.ToInt32(row["DiscountPer"]),
                            ReceiveDate = Convert.ToDateTime(row["PostingDate"]),
                            IntroName = row["IntroName"].ToString().Trim(),
                            ShiftWork = this.shiftWork,
                            EmployeeCode = this.userID
                        };
                        int status = Convert.ToInt32(row["Check"]);
                        //Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET.");
                        if (ReportDiscountBLL.IUReportDiscount(discount, status) < 1)
                        {
                            bResult = false;
                            //Starting.Close();
                            break;
                        }
                        //Starting.Close();
                    }
                    if (bResult)
                    {
                        XtraMessageBox.Show("Cập nhật thành công.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.GetDataIntroNameDetail();
                        this.GetDateWaitingIntroName();
                        this.chkAll.Checked = false;
                    }
                    else
                    {
                        XtraMessageBox.Show(" Cập nhật không thành công! Vui lòng xem lại thông tin trước khi cập nhật.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butSearchReport_Click(object sender, EventArgs e)
        {
            try
            {
                this.pivotGridResult.DataSource = null;
                this.pivotGridResult.Fields.Clear();
                this.pivotGridGeneral.DataSource = null;
                this.pivotGridGeneral.Fields.Clear();
                if (this.cbDetail.Checked == true)
                {
                    this.tableResult = rpt_General_BLL.TableDiscountForIntroName(Convert.ToDateTime(this.dateReportForm.EditValue), Convert.ToDateTime(this.dateReportTo.EditValue), string.Empty, this.userID, this.chcbServiceGroupReport.EditValue.ToString().Replace(" ", ""), this.cbIntroducerReport.Text, "DE");
                    this.gridControl_List.DataSource = this.tableResult;
                    this.gridView_List.Columns["IntroName"].Group();
                    this.gridView_List.ExpandAllGroups();
                }
                else if (this.cbDiscount.Checked == true)
                {
                    Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET.");
                    this.tableDicount = rpt_General_BLL.TableDiscountForIntroName(Convert.ToDateTime(this.dateReportForm.EditValue), Convert.ToDateTime(this.dateReportTo.EditValue), string.Empty, this.userID, this.chcbServiceGroupReport.EditValue.ToString().Replace(" ", ""), this.cbIntroducerReport.Text, "IN");
                    Starting.Close();
                    if (this.tableDicount != null && this.tableDicount.Rows.Count > 0)
                    {
                        this.pivotGridResult.DataSource = this.tableDicount;
                        PivotGridField fieldWorkDate = new PivotGridField("WorkDate", PivotArea.FilterArea);
                        fieldWorkDate.Caption = "Ngày";
                        ///fieldWorkDate.Appearance.Value.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                        PivotGridField fieldIntroName = new PivotGridField("IntroName", PivotArea.RowArea);
                        fieldIntroName.Caption = "NGƯỜI GIỚI THIỆU";
                        ///fieldIntroName.Width = 200;
                        PivotGridField fieldEmployeeNameDoctor = new PivotGridField("EmployeeNameDoctor", PivotArea.RowArea);
                        fieldEmployeeNameDoctor.Caption = "Bác sỹ";

                        PivotGridField fieldCategoryName = new PivotGridField("ServiceCategoryName", PivotArea.FilterArea); ///ColumnArea
                        fieldCategoryName.Caption = "Loại dịch vụ";

                        PivotGridField fieldServiceName = new PivotGridField("ServiceName", PivotArea.ColumnArea); ///ColumnArea
                        fieldServiceName.Caption = "Tên dịch vụ";

                        PivotGridField fieldQuantity = new PivotGridField("Quantity", PivotArea.DataArea);
                        fieldQuantity.Caption = "Tổng";
                        fieldQuantity.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        fieldQuantity.CellFormat.FormatString = "#,#";

                        PivotGridField fieldAmount = new PivotGridField("TotalAmount", PivotArea.DataArea);
                        fieldAmount.Caption = "Tổng tiền";
                        fieldAmount.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        fieldAmount.CellFormat.FormatString = "#,#";

                        PivotGridField fieldPatientName = new PivotGridField("PatientName", PivotArea.FilterArea);
                        fieldPatientName.Caption = "Họ và tên";
                        fieldPatientName.Width = 150;
                        PivotGridField fieldPatientBirthyear = new PivotGridField("PatientBirthyear", PivotArea.FilterArea);
                        fieldPatientBirthyear.Caption = "Năm sinh";
                        PivotGridField fieldPatientGender = new PivotGridField("PatientGenderName", PivotArea.FilterArea);
                        fieldPatientGender.Caption = "Giới tính";
                        PivotGridField fieldPatientAddress = new PivotGridField("PatientAddress", PivotArea.FilterArea);
                        fieldPatientAddress.Caption = "Địa chỉ";
                        fieldPatientAddress.Width = 200;
                        PivotGridField fieldPatientMobile = new PivotGridField("PatientMobile", PivotArea.FilterArea);
                        fieldPatientMobile.Caption = "Số ĐT";
                        this.pivotGridResult.Fields.AddRange(new PivotGridField[] { fieldWorkDate, fieldIntroName, fieldCategoryName, fieldServiceName, fieldQuantity, fieldAmount, fieldPatientName, fieldPatientBirthyear, fieldPatientGender, fieldPatientAddress, fieldPatientMobile });
                        this.pivotGridResult.BestFit();
                    }
                }
                else if (this.cbGeneral.Checked == true)
                {
                    Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET.");
                    this.tableDicount = rpt_General_BLL.TableDiscountForIntroName(Convert.ToDateTime(this.dateReportForm.EditValue), Convert.ToDateTime(this.dateReportTo.EditValue), string.Empty, this.userID, this.chcbServiceGroupReport.EditValue.ToString().Replace(" ", ""), this.cbIntroducerReport.Text, "GE");
                    Starting.Close();
                    if (this.tableDicount != null && this.tableDicount.Rows.Count > 0)
                    {
                        this.pivotGridGeneral.DataSource = this.tableDicount;
                        PivotGridField fieldIntroName = new PivotGridField("IntroName", PivotArea.RowArea);
                        fieldIntroName.Caption = "NGƯỜI GIỚI THIỆU";
                        //fieldIntroName.Width = 200;

                        PivotGridField fieldCategoryName = new PivotGridField("ServiceGroupName", PivotArea.ColumnArea);
                        fieldCategoryName.Caption = "Dịch vụ";

                        PivotGridField fieldAmount = new PivotGridField("TotalAmount", PivotArea.DataArea);
                        fieldAmount.Caption = "Tổng tiền";
                        fieldAmount.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        fieldAmount.CellFormat.FormatString = "#,#";
                        this.pivotGridGeneral.Fields.AddRange(new PivotGridField[] { fieldIntroName, fieldCategoryName, fieldAmount });
                        this.pivotGridGeneral.BestFit();
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void tabMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (this.tabMain.SelectedTabPageIndex == 1)
            {
                this.dateReportForm.EditValue = this.dtSearchForm.EditValue;
                this.dateReportTo.EditValue = this.dtSearchTo.EditValue;
            }
        }

        private void tab_Click(object sender, EventArgs e)
        {
            if (this.tab.SelectedTabPageIndex == 0)
            {
                this.cbDetail.Checked = true;
                this.butSearchReport_Click(sender, e);
            }
            else if (this.tab.SelectedTabPageIndex == 1)
            {
                this.cbDiscount.Checked = true;
                this.butSearchReport_Click(sender, e);
            }
            else if (this.tab.SelectedTabPageIndex == 2)
            {
                this.cbGeneral.Checked = true;
                this.butSearchReport_Click(sender, e);
            }
        }

        private void cbDetail_CheckedChanged(object sender, EventArgs e)
        {
            this.tab.SelectedTabPageIndex = 0;
            //this.butSearchReport_Click(sender, e);
        }

        private void cbDiscount_CheckedChanged(object sender, EventArgs e)
        {
            this.tab.SelectedTabPageIndex = 1;
            //this.butSearchReport_Click(sender, e);
        }

        private void cbGeneral_CheckedChanged(object sender, EventArgs e)
        {
            this.tab.SelectedTabPageIndex = 2;
            //this.butSearchReport_Click(sender, e);
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cbDetail.Checked)
                {
                    if (this.tableResult != null && this.tableResult.Rows.Count > 0)
                    {
                        ViewPopup.frmExcelPathName frmPath = new ViewPopup.frmExcelPathName();
                        frmPath.ShowDialog();
                        if (frmPath.reloaded)
                        {
                            Utils.Check_Process_Excel();
                            DataSet dsTemp = new DataSet("table");
                            dsTemp.Merge(this.tableResult);
                            dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\xmlVP_DiscountForIntro.xml");
                            Reports.rpt_VP_DiscountForIntro rpt = new Reports.rpt_VP_DiscountForIntro();
                            rpt.DataSource = dsTemp;
                            rpt.Parameters["fromdate"].Value = this.dateReportForm.Text;
                            rpt.Parameters["todate"].Value = this.dateReportTo.Text;
                            rpt.Parameters["paraTitle"].Value = this.mnoTitle.Text;
                            rpt.ExportOptions.Xlsx.ShowGridLines = true;
                            rpt.ExportOptions.Xls.SheetName = "ChietKhauTongHop";
                            rpt.ExportToXls(frmPath.pathName);
                            oxl = new Excel.Application();
                            owb = (Excel._Workbook)(oxl.Workbooks.Open(frmPath.pathName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                            osheet = (Excel._Worksheet)owb.ActiveSheet;
                            oxl.ActiveWindow.DisplayGridlines = false;
                            oxl.ActiveWindow.DisplayZeros = false;
                            oxl.Visible = true;
                        }
                    }
                }
                else if (this.cbDiscount.Checked)
                {
                    ViewPopup.frmExcelPathName frm = new ViewPopup.frmExcelPathName();
                    frm.ShowInTaskbar = false;
                    frm.ShowDialog();
                    if (frm.reloaded)
                    {
                        this.pivotGridResult.ExportToXls(frm.pathName);
                        oxl = new Excel.Application();
                        owb = (Excel._Workbook)(oxl.Workbooks.Open(frm.pathName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                        osheet = (Excel._Worksheet)owb.ActiveSheet;
                        oxl.ActiveWindow.DisplayGridlines = false;
                        oxl.ActiveWindow.DisplayZeros = false;
                        oxl.Visible = true;
                    }
                }
                else if (this.cbGeneral.Checked)
                {
                    ViewPopup.frmExcelPathName frm = new ViewPopup.frmExcelPathName();
                    frm.ShowInTaskbar = false;
                    frm.ShowDialog();
                    if (frm.reloaded)
                    {
                        this.pivotGridGeneral.ExportToXls(frm.pathName);
                        oxl = new Excel.Application();
                        owb = (Excel._Workbook)(oxl.Workbooks.Open(frm.pathName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                        osheet = (Excel._Worksheet)owb.ActiveSheet;
                        oxl.ActiveWindow.DisplayGridlines = false;
                        oxl.ActiveWindow.DisplayZeros = false;
                        oxl.Visible = true;
                    }
                }
            }
            catch { }
        }

        private void gridView_NguoiGT_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "iHIS Bệnh Viện Điện Tử";
            e.ErrorText = " Xem lại thông tin khai báo người giới thiệu !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_NguoiGT_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_IntroName))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_IntroName, "Họ tên người giới thiệu không được để trống!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Sex))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_Sex, "Chưa chọn giới tính!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Career))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_Career, "Chưa chọn nghề nghiệp!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Birthday))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_Birthday, "Vui lòng chọn ngày sinh!");
                }
                if (e.Valid)
                {
                    IntroducerInf inf = new IntroducerInf();
                    inf.IntroCode = gridView_NguoiGT.GetRowCellValue(e.RowHandle, "IntroCode").ToString();
                    inf.IntroName = gridView_NguoiGT.GetRowCellValue(e.RowHandle, "IntroName").ToString();
                    if (gridView_NguoiGT.GetRowCellValue(e.RowHandle, "Sex").ToString() != "")
                        inf.Sex = int.Parse(gridView_NguoiGT.GetRowCellValue(e.RowHandle, "Sex").ToString());
                    inf.Mobile = gridView_NguoiGT.GetRowCellValue(e.RowHandle, "Mobile").ToString();
                    inf.IDCard = gridView_NguoiGT.GetRowCellValue(e.RowHandle, "IDCard").ToString();
                    inf.Address = gridView_NguoiGT.GetRowCellValue(e.RowHandle, "Address").ToString();
                    inf.Birthday = DateTime.Parse(gridView_NguoiGT.GetRowCellValue(e.RowHandle, "Birthday").ToString());
                    inf.CareerCode = gridView_NguoiGT.GetRowCellValue(e.RowHandle, "CareerCode").ToString();
                    inf.EmployeeCode = this.userID;
                    inf.Note = gridView_NguoiGT.GetRowCellValue(e.RowHandle, "Note").ToString();
                    if (e.RowHandle < 0)
                    {
                        if (IntroducerBLL.Ins(inf) == 1)
                        {
                            XtraMessageBox.Show("Thêm mới thành công!", "iHIS Bệnh Viện Điện Tử");
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm thất bại!", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (IntroducerBLL.Ins(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật thành công!", "iHIS Bệnh Viện Điện Tử");
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật thất bại!", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    this.cbIntroducer.Properties.Items.Clear();
                    this.cbIntroducerReport.Properties.Items.Clear();
                    this.repcbxEdit_IntroName.Properties.Items.Clear();
                    DataTable tableIntro = IntroducerBLL.DTIntroducer(string.Empty);
                    this.gridControl_NguoiGT.DataSource = tableIntro;
                    foreach (DataRow row in tableIntro.Rows)
                    {
                        this.cbIntroducer.Properties.Items.Add(row["IntroName"].ToString());
                        this.cbIntroducerReport.Properties.Items.Add(row["IntroName"].ToString());
                        this.repcbxEdit_IntroName.Properties.Items.Add(row["IntroName"].ToString());
                    }
                }
            }
            catch (Exception) { }
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            this.dateReportForm.EditValue = this.dateReportTo.EditValue = this.dtimePosting;
            this.chcbServiceGroupReport.EditValue = null;
            this.cbIntroducerReport.Text = string.Empty;
            this.mnoTitle.Text = string.Empty;
            this.pivotGridResult.DataSource = null;
            this.pivotGridResult.Fields.Clear();
            this.pivotGridGeneral.DataSource = null;
            this.pivotGridGeneral.Fields.Clear();
        }

        private void chkDone_CheckedChanged(object sender, EventArgs e)
        {
            try
            {                
                this.GetDataIntroNameDetail();
                this.GetDateWaitingIntroName();
            }
            catch { return; }
        }
        
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            this.chkAll.Text = chkAll.Checked ? "UnCheck" : "Check All";
            if (this.chkAll.Checked)
            {
                foreach (DataRow dr in this.tableServices.Rows)
                {
                    dr["Check"] = 1;
                }
            }
            else
            {
                foreach (DataRow dr in this.tableServices.Rows)
                {
                    dr["Check"] = 0;
                }
            }
        }
        
    }
}