using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraEditors.Popup;

namespace Ps.Clinic.Master
{
    public partial class frmToaMau : DevExpress.XtraEditors.XtraForm
    {
        private string No = string.Empty;
        string DocumentNo = string.Empty;

        string strUsed, firstRowUsageGuide = string.Empty;
        string firstRowUOM = string.Empty;
        string bs, s, btr, tr, bc, c, bt, t = string.Empty;

        private string sUserlogin = string.Empty;
        private DataTable tblSampleDetail = new DataTable();
        public frmToaMau(string _Userlogin)
        {
            InitializeComponent();
            sUserlogin = _Userlogin;
        }

        private void frmToaMau_Load(object sender, EventArgs e)
        {
            DataTable tableUnitOfMeasure = UnitOfMeasureBLL.DTUnit(string.Empty, "I");
            this.rep_UoM.DataSource = tableUnitOfMeasure;
            this.rep_UoM.DisplayMember = "UnitOfMeasureName";
            this.rep_UoM.ValueMember = "UnitOfMeasureCode";

            this.repslkup_UnitOfMedi.DataSource = tableUnitOfMeasure;
            this.repslkup_UnitOfMedi.DisplayMember = "UnitOfMeasureName";
            this.repslkup_UnitOfMedi.ValueMember = "UnitOfMeasureCode";

            this.repslkup_Items.DataSource = ItemsBLL.ListItems(0);
            this.repslkup_Items.DisplayMember = "ItemName";
            this.repslkup_Items.ValueMember = "ItemCode";
            this.LoadDataSampleHeader();
        }
        private void LoadDataSampleHeader()
        {
            this.gridControl_List.DataSource = SamplePrescriptionHeader_BLL.DT_SampleHeader();
        }
        public void LoadDataDetail()
        {
            this.tblSampleDetail = SamplePrescriptionLine_BLL.DT_SampleLine(this.DocumentNo);
            this.gridControl_Detail.DataSource = this.tblSampleDetail;
        }

        private void gridView_List_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (this.gridView_List.RowCount > 0)
            {
                if (this.gridView_List.GetFocusedRow() != null)
                {
                    this.DocumentNo = gridView_List.GetRowCellValue(this.gridView_List.FocusedRowHandle, this.col_SamplePrescriptionCode).ToString();
                    this.LoadDataDetail();
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn toa mẫu cần xem chi tiết toa.", "Bệnh Viện Điện Tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView_Detail_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (this.gridView_Detail.GetFocusedRow() != null)
            {
                string Document_No = Convert.ToString(this.gridView_List.GetRowCellValue(this.gridView_List.FocusedRowHandle, col_SamplePrescriptionCode));
                {
                    this.gridView_Detail.SetRowCellValue(e.RowHandle, col_Detail_Sample_Prescription_Code, Document_No);
                }
            }
            else
            {
                this.gridControl_Detail.DataSource = null;
            }
        }

        private void gridView_List_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (gridView_List.GetFocusedRow() != null)
            {
                try
                {
                    GridView view = sender as GridView;
                    int rowfocus = e.RowHandle;
                    if (Convert.ToString(view.GetRowCellValue(rowfocus, col_SamplePrescriptionName)).ToString() == string.Empty)
                    {
                        e.Valid = false;
                        view.SetColumnError(col_SamplePrescriptionName, "Tên toa mẫu không được để trống!");
                    }
                    if (e.Valid)
                    {
                        SamplePrescriptionHeader_INF mHead = new SamplePrescriptionHeader_INF();
                        if (Convert.ToString(view.GetRowCellValue(rowfocus, col_SamplePrescriptionCode)).ToString() != string.Empty)
                            mHead.SamplePrescriptionCode = view.GetRowCellValue(rowfocus, col_SamplePrescriptionCode).ToString();
                        else
                            mHead.SamplePrescriptionCode = "";
                        mHead.SamplePrescriptionName = view.GetRowCellValue(rowfocus, col_SamplePrescriptionName).ToString();
                        mHead.SamplePrescriptionDescription = view.GetRowCellValue(rowfocus, col_SamplePrescriptionDescription).ToString();
                        mHead.EmployeeCode = sUserlogin;
                        if (e.RowHandle < 0)
                        {
                            SamplePrescriptionHeader_BLL.Ins(mHead);
                        }
                        else
                        {
                            SamplePrescriptionHeader_BLL.Ins(mHead);
                        }
                    }
                    this.LoadDataSampleHeader();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Error: " + ex.ToString(), "Bệnh Viện Điện Tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void gridView_List_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "iHIS - Bệnh Viện Điện Tử";
            e.ErrorText = "Bạn nhập thiếu thông tin tổng hợp cho toa mẫu!.\t\n - YES: Bổ sung thêm\t\n - NO: Xóa nhập lại\t\n";
        }

        private void gridView_Detail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "iHIS - Bệnh Viện Điện Tử";
            e.ErrorText = "Bạn nhập thiếu thông tin chi tiết cho toa mẫu!.\t\n - YES: Bổ sung thêm\t\n - NO: Xóa nhập lại\t\n";
        }
        
        private void gridView_Detail_KeyPress(object sender, KeyPressEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "DateOfIssues")
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            if (view.FocusedColumn.FieldName == "Morning")
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '/' && !Char.IsControl(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            if (view.FocusedColumn.FieldName == "Noon")
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '/' && !Char.IsControl(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            if (view.FocusedColumn.FieldName == "Afternoon")
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '/' && !Char.IsControl(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            if (view.FocusedColumn.FieldName == "Evening")
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '/' && !Char.IsControl(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
        }

        private void repslkup_Items_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
                string itemCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ItemCode").ToString();
                string activeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("Active").ToString();
                string unitOfMeasureCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("UnitOfMeasureCode").ToString();
                string unitOfMeasureCode_MediTemp = searchEdit.Properties.View.GetFocusedRowCellValue("UnitOfMeasureCode_Medi").ToString();
                DataRow r = Utils.GetPriceRowbyCode(this.tblSampleDetail, "ItemCode='" + itemCodeTemp + "'");
                if (r != null)
                {
                    XtraMessageBox.Show(" Thuốc đã được kê trong toa thuốc!", "Bệnh Viện Điện Tử. NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.gridView_Detail.SetFocusedRowCellValue(this.col_Detail_Item_Code, null);
                    this.gridView_Detail.SetFocusedRowCellValue(this.col_Detail_Quantity, 0);
                }
                else
                {
                    this.gridView_Detail.SetFocusedRowCellValue(this.col_Detail_UnitOfMeasure, unitOfMeasureCodeTemp);
                    this.gridView_Detail.SetFocusedRowCellValue(this.col_Detail_UnitOfMeasureCode_Medi, unitOfMeasureCode_MediTemp);
                    this.gridView_Detail.SetFocusedRowCellValue(this.col_Detail_DateOfIssues, 1);
                }
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.ToString(), "Bệnh Viện Điện Tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void repslkup_Items_Popup(object sender, EventArgs e)
        {
            PopupSearchLookUpEditForm f = (sender as DevExpress.Utils.Win.IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            SearchEditLookUpPopup popup = f.ActiveControl as SearchEditLookUpPopup;
            popup.FindTextBox.Text = "\"\"";
            popup.FindTextBox.SelectionStart = 1;
        }

        private string ISDBNULL2STRING(object a, object b)
        {
            if (a == DBNull.Value)
            {
                return string.Empty;
            }
            else
                return Convert.ToString(a);
        }

        private decimal ISDBNULL2DECIMAL(object a, object b)
        {
            if (a == DBNull.Value)
            {
                return Convert.ToDecimal(b);
            }
            else
                return Convert.ToDecimal(a);
        }

        private void gridView_Detail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (ISDBNULL2STRING(Convert.ToString(view.GetRowCellValue(rowfocus, this.col_Detail_Item_Code)).ToString(), string.Empty) == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(this.col_Detail_Item_Code, "Nhập tên thuốc!");
                }
                //string value = ISDBNULL2STRING(Convert.ToString(view.GetRowCellValue(rowfocus, col_Detail_Item_Code)).ToString(), string.Empty);
                //if (value != string.Empty)
                //{
                //    for (int i = 0; i < gridView_Detail.DataRowCount; i++)
                //    {
                //        object ItemCode = gridView_Detail.GetRowCellValue(i, col_Detail_Item_Code);

                //        if (ItemCode != null && Convert.ToString(ItemCode) == value.ToString())
                //        {
                //            e.Valid = false;
                //            view.SetColumnError(col_Detail_Item_Code, "Đã tồn tại thuốc trong toa!");
                //            break;
                //        }
                //    }
                //}
                if (ISDBNULL2DECIMAL(Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_Detail_Quantity)), 1) <= 0)
                {
                    e.Valid = false;
                    view.SetColumnError(this.col_Detail_Quantity, "Số lượng phải > 0 !");
                }
                if (e.Valid)
                {
                    SamplePrescriptionLine_INF model = new SamplePrescriptionLine_INF();
                    if (Convert.ToString(view.GetRowCellValue(rowfocus, this.col_Detal_RowID)).ToString() != string.Empty)
                        model.RowID = Convert.ToDecimal(view.GetRowCellValue(rowfocus, this.col_Detal_RowID).ToString());
                    else
                        model.RowID = 0;
                    model.SamplePrescriptionCode = DocumentNo;
                    model.ItemCode = view.GetRowCellValue(rowfocus, this.col_Detail_Item_Code).ToString();
                    model.UnitOfMeasure = view.GetRowCellValue(rowfocus, this.col_Detail_UnitOfMeasure).ToString();
                    if (!string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, this.col_Detail_DateOfIssues))))
                    {
                        model.DateOfIssues = Convert.ToInt32(view.GetRowCellValue(rowfocus, this.col_Detail_DateOfIssues));
                    }
                    else
                    {
                        model.DateOfIssues = 1;
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, this.col_Detail_Morning))))
                    {
                        model.Morning = float.Parse(view.GetRowCellValue(rowfocus, this.col_Detail_Morning).ToString());
                    }
                    else
                    {
                        model.Morning = 0;
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, this.col_Detail_Noon))))
                    {
                        model.Noon = float.Parse(view.GetRowCellValue(rowfocus, this.col_Detail_Noon).ToString());
                    }
                    else
                    {
                        model.Noon = 0;
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, this.col_Detail_Afternoon))))
                    {
                        model.Afternoon = float.Parse(view.GetRowCellValue(rowfocus, this.col_Detail_Afternoon).ToString());
                    }
                    else
                    {
                        model.Afternoon = 0;
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, this.col_Detail_Evening))))
                    {

                        model.Evening = float.Parse(view.GetRowCellValue(rowfocus, this.col_Detail_Evening).ToString());
                    }
                    else
                    {
                        model.Evening = 0;
                    }
                    model.Quantity = Convert.ToInt32(view.GetRowCellValue(rowfocus, this.col_Detail_Quantity).ToString());
                    model.Instruction = view.GetRowCellValue(rowfocus, this.col_Detail_Instruction).ToString();
                    model.UnitOfMeasureCode_Medi = view.GetRowCellValue(rowfocus, this.col_Detail_UnitOfMeasureCode_Medi).ToString();
                    if (e.RowHandle < 0)
                    {
                        SamplePrescriptionLine_BLL.Ins(model);
                    }
                    else
                    {
                        SamplePrescriptionLine_BLL.Ins(model);
                    }
                    this.LoadDataDetail();
                }
            }
            catch
            {
                XtraMessageBox.Show("Kiểm tra liều dùng và số lượng thuốc trước khi lưu.", "Bệnh Viện Điện Tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private decimal ParseQuantity(string qty)
        {
            decimal sl1 = 0;
            string[] arr;
            if (qty.Trim() != "")
            {
                arr = qty.Trim().Split('/');
                if (arr.Length == 2)
                {
                    try
                    {
                        int tu = int.Parse(arr[0].Trim() == "" ? "0" : arr[0].Trim());
                        int mau = int.Parse(arr[1].Trim() == "" ? "1" : arr[1].Trim());
                        sl1 = (decimal)(tu * (1M) / mau);
                    }
                    catch { }
                }
                else
                    if (arr.Length > 0)
                    {
                        try
                        {
                            sl1 = decimal.Parse(arr[0].Trim() == "" ? "0" : arr[0].Trim());
                        }
                        catch { }
                    }
            }
            return sl1;
        }

        private void gridView_Detail_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                bool converted_Medi = Convert.ToBoolean(view.GetFocusedRowCellValue(this.col_Detail_Converted_Medi));
                s = Convert.ToString(view.GetFocusedRowCellValue("Morning"));
                tr = Convert.ToString(view.GetFocusedRowCellValue("Noon"));
                c = Convert.ToString(view.GetFocusedRowCellValue("Afternoon"));
                t = Convert.ToString(view.GetFocusedRowCellValue("Evening"));

                if (view.FocusedColumn.FieldName == "Morning")
                {
                    if (view.GetFocusedRowCellValue(this.col_Detail_Item_Code) != null)
                    {
                        if (e.Value != null)
                        {
                            decimal issue = Convert.ToDecimal(view.GetFocusedRowCellValue("DateOfIssues"));
                            decimal morning = ParseQuantity(e.Value.ToString());
                            decimal noon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Noon")));
                            decimal afternoon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Afternoon")));
                            decimal evening = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Evening")));
                            if (converted_Medi)
                                view.SetFocusedRowCellValue(this.col_Detail_Quantity, Math.Round((morning + noon + afternoon + evening) * issue, MidpointRounding.AwayFromZero));
                            else
                                view.SetFocusedRowCellValue(this.col_Detail_Quantity, 1);
                            //decimal s1 = Convert.ToDecimal(view.GetFocusedRowCellValue("Quantity")) * unitprice;
                            //view.SetFocusedRowCellValue(col_Amount, s1);
                            s = e.Value.ToString();
                        }
                    }
                }
                if (view.FocusedColumn.FieldName == "Noon")
                {
                    if (view.GetFocusedRowCellValue(this.col_Detail_Item_Code) != null)
                    {
                        if (e.Value != null)
                        {
                            decimal issue = Convert.ToDecimal(view.GetFocusedRowCellValue("DateOfIssues"));
                            decimal morning = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Morning")));
                            decimal noon = ParseQuantity(e.Value.ToString());
                            decimal afternoon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Afternoon")));
                            decimal evening = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Evening")));
                            if (converted_Medi)
                                view.SetFocusedRowCellValue(this.col_Detail_Quantity, Math.Round((morning + noon + afternoon + evening) * issue, MidpointRounding.AwayFromZero));
                            else
                                view.SetFocusedRowCellValue(this.col_Detail_Quantity, 1);
                            //decimal s2 = Convert.ToDecimal(view.GetFocusedRowCellValue("Quantity")) * unitprice;
                            //view.SetFocusedRowCellValue(col_Amount, s2);
                            tr = e.Value.ToString();
                        }
                    }
                }
                if (view.FocusedColumn.FieldName == "Afternoon")
                {
                    if (view.GetFocusedRowCellValue(this.col_Detail_Item_Code) != null)
                    {
                        if (e.Value != null)
                        {
                            decimal issue = Convert.ToDecimal(view.GetFocusedRowCellValue("DateOfIssues"));
                            decimal morning = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Morning")));
                            decimal noon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Noon")));
                            decimal afternoon = ParseQuantity(e.Value.ToString());
                            decimal evening = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Evening")));
                            if (converted_Medi)
                                view.SetFocusedRowCellValue(this.col_Detail_Quantity, Math.Round((morning + noon + afternoon + evening) * issue, MidpointRounding.AwayFromZero));
                            else
                                view.SetFocusedRowCellValue(this.col_Detail_Quantity, 1);
                            //decimal s3 = Convert.ToDecimal(view.GetFocusedRowCellValue("Quantity")) * unitprice;
                            //view.SetFocusedRowCellValue(col_Amount, s3);
                            c = e.Value.ToString();
                        }
                    }
                }
                if (view.FocusedColumn.FieldName == "Evening")
                {
                    if (view.GetFocusedRowCellValue(this.col_Detail_Item_Code) != null)
                    {
                        if (e.Value != null)
                        {
                            decimal issue = Convert.ToDecimal(view.GetFocusedRowCellValue("DateOfIssues"));
                            decimal morning = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Morning")));
                            decimal noon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Noon")));
                            decimal afternoon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Afternoon")));
                            decimal evening = ParseQuantity(e.Value.ToString());
                            if (converted_Medi)
                                view.SetFocusedRowCellValue(this.col_Detail_Quantity, Math.Round((morning + noon + afternoon + evening) * issue, MidpointRounding.AwayFromZero));
                            else
                                view.SetFocusedRowCellValue(this.col_Detail_Quantity, 1);
                            //decimal s4 = Convert.ToDecimal(view.GetFocusedRowCellValue("Quantity")) * unitprice;
                            //view.SetFocusedRowCellValue(col_Amount, s4);
                            t = e.Value.ToString();
                        }
                    }
                }

                if (s.ToString() != string.Empty && s.ToString() != "0")
                    strUsed = "Sáng " + s.ToString();
                if (tr.ToString() != string.Empty && tr.ToString() != "0")
                    strUsed += ",Trưa " + tr.ToString();
                if (c.ToString() != string.Empty && c.ToString() != "0")
                    strUsed += ",Chiều " + c.ToString();
                if (t.ToString() != string.Empty && t.ToString() != "0")
                    strUsed += ",Tối " + t.ToString();
                ///strUsed = "Sáng " + s.ToString() + ", Trưa " + tr.ToString() + ", Chiều " + c.ToString() + ", Tối " + t.ToString();
                ///view.SetFocusedRowCellValue(col_Instruction, strUsed);
                if (view.FocusedColumn.FieldName == "Quantity")
                {
                    if (view.GetFocusedRowCellValue(this.col_Detail_Item_Code) != null)
                    {
                        if (e.Value != null)
                        {
                            decimal totalQuantity = ParseQuantity(e.Value.ToString());
                            //decimal s5 = Convert.ToDecimal(totalQuantity * unitprice);
                            //view.SetFocusedRowCellValue(col_Amount, s5);
                        }
                    }
                }
                if (view.FocusedColumn.FieldName == "DateOfIssues")
                {
                    if (view.GetFocusedRowCellValue(this.col_Detail_Item_Code) != null)
                    {
                        if (e.Value != null)
                        {
                            decimal issue = Convert.ToDecimal(e.Value);
                            decimal morning = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Morning")));
                            decimal noon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Noon")));
                            decimal afternoon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Afternoon")));
                            decimal evening = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Evening")));

                            if (converted_Medi)
                                view.SetFocusedRowCellValue(this.col_Detail_Quantity, Math.Round((morning + noon + afternoon + evening) * issue, MidpointRounding.AwayFromZero));
                            else
                                view.SetFocusedRowCellValue(this.col_Detail_Quantity, 1);
                            //decimal s0 = Convert.ToDecimal(view.GetFocusedRowCellValue("Quantity")) * unitprice;
                            //view.SetFocusedRowCellValue(col_Amount, s0);
                        }
                    }
                }
            }
            catch { }
        }

        private void gridControl_Detail_EditorKeyPress(object sender, KeyPressEventArgs e)
        {
            GridControl grid = sender as GridControl;
            gridView_Detail_KeyPress(grid.FocusedView, e);
        }

        private void gridControl_List_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_List.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa toa thuốc mẫu đã khai báo này?", "iHIS - Bệnh Viện Điện Tử.", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    try
                    {
                        if (SamplePrescriptionHeader_BLL.Del(gridView_List.GetRowCellValue(gridView_List.FocusedRowHandle, "SamplePrescriptionCode").ToString()) >= 1)
                            this.gridView_List.DeleteSelectedRows();
                    }
                    catch { return; }
                }
            }
        }

        private void gridControl_Detail_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_Detail.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                try
                {
                    string samplePrescriptionCode = this.gridView_Detail.GetRowCellValue(this.gridView_Detail.FocusedRowHandle, this.col_Detail_Sample_Prescription_Code).ToString();
                    string itemcode = this.gridView_Detail.GetRowCellValue(this.gridView_Detail.FocusedRowHandle, this.col_Detail_Item_Code).ToString();
                    if (SamplePrescriptionLine_BLL.Del(samplePrescriptionCode, itemcode) >= 1)
                        this.LoadDataDetail();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Error: " + ex.ToString(), "Bệnh Viện Điện Tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}