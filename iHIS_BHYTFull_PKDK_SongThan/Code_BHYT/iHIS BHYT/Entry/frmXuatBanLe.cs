using System;
using System.IO;
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
using Ps.Clinic.ViewPopup;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using System.Globalization;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;

namespace Ps.Clinic.Entry
{
    public partial class frmXuatBanLe : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string firstRowUOM = string.Empty;
        private string bs, s, btr, tr, bc, c, bt, t = string.Empty;
        private string exportCode = string.Empty, patientCode = string.Empty, strUsed = string.Empty, medicalRecordCode = string.Empty;
        private DataTable lstItem_Out = new DataTable();
        private string repositoryCode = string.Empty, sUserid = string.Empty;
        private DateTime dtimeWorkingDate = new DateTime();
        private DataTable dtMedicalRecord_Out = new DataTable();
        private Int32 iPaid = 0;
        private bool isImportDate = false;
        private bool isShipment = false;
        private bool isDateEnd = false;
        private DataView cloneout = null;
        private decimal dUSD = 0, dReceiveID = 0;
        private decimal dOther = 0;
        private bool bCheckActice = true;
        private string shiftWork = string.Empty;
        private bool isMedical_Old = false;
        private string[] arrVAT = new string[] { "0", "5", "10", "15" };
        private bool isSalesPrice_Retail = false;
        public frmXuatBanLe(string _User, string _RepositoryCode, string _shiftWork)
        {
            InitializeComponent();
            this.sUserid = _User;
            this.repositoryCode = _RepositoryCode;
            this.shiftWork = _shiftWork;
            this.butToaThuoc.Focus();
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void frmXuatBanLe_Load(object sender, EventArgs e)
        {
            try
            {
                this.rep_Out_UnitOf.DataSource = UnitOfMeasureBLL.ListUnit(string.Empty, "I");
                this.rep_Out_UnitOf.DisplayMember = "UnitOfMeasureName";
                this.rep_Out_UnitOf.ValueMember = "UnitOfMeasureCode";

                List<InstructionInf> lstInstruc = InstructionBLL.ListInstruction(0);
                foreach (var v in lstInstruc)
                {
                    rep_Out_Instruction.Items.Add(v.InstructionName);
                }
                //this.sLookUpNguoiGT.Properties.DataSource = IntroducerBLL.DTIntroducer(string.Empty);
                //this.sLookUpNguoiGT.Properties.DisplayMember = "IntroName";
                //this.sLookUpNguoiGT.Properties.ValueMember = "IntroCode";
                this.txtSoPhieu.Properties.ReadOnly = true;
                this.EnableButton(true);
                this.EnableText(true);
                this.gridView_Out.OptionsBehavior.ReadOnly = true;
                this.gridView_Out.OptionsBehavior.Editable = false;
                this.gridView_Out.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                
                string sDateServer = Utils.DateServer().ToString("dd/MM/yyyy");
                this.gridControl_Search.DataSource = MedicinesRetailBLL.DT_ListRetail(sDateServer, sDateServer, this.chkCancel.Checked ? true : false, this.chkDone.Checked ? true : false);
                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(207);
                if (objSys != null && objSys.RowID > 0)
                {
                    if (objSys.Values == 1)
                        this.bCheckActice = true;
                    else
                        this.bCheckActice = false;
                }
                SystemParameterInf objSys_213 = SystemParameterBLL.ObjParameter(213);
                if (objSys_213 != null && objSys_213.RowID > 0)
                {
                    if (objSys_213.Values == 1)
                        this.isSalesPrice_Retail = true;
                    else
                        this.isSalesPrice_Retail = false;
                }
                
                this.searchLkupDoctor.Properties.DataSource = EmployeeBLL.TableEmployeeForPosition("3", string.Empty);
                this.searchLkupDoctor.Properties.DisplayMember = "EmployeeName";
                this.searchLkupDoctor.Properties.ValueMember = "EmployeeCode";
                DataTable tableDiagnosis = DiagnosisCustomBLL.TableDiagnosisCustom(0);
                foreach (DataRow row in tableDiagnosis.Rows)
                    this.txtChandoan.Properties.Items.Add(row["DiagnosisName"].ToString());
                this.dtimeWorkingDate = Utils.DateTimeServer();
                this.dtfrom.EditValue = this.dtto.EditValue = this.dtimeWorkingDate;
                this.InitField();
                this.lkupVAT.Properties.DataSource = this.arrVAT;
                this.txtHoten.Focus();
                this.LoadDataItems();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void LoadDataItems()
        {
            this.lstItem_Out = ItemsBLL.DT_ListItemsRefForRepCode(0, this.repositoryCode);
            this.repSearch_Out_ItemCode.DataSource = this.lstItem_Out;
            this.repSearch_Out_ItemCode.DisplayMember = "ItemName";
            this.repSearch_Out_ItemCode.ValueMember = "ItemCode";
        }
        private decimal ISDBNULL2DECIMAL(object a, object b)
        {
            if (a == DBNull.Value)
                return Convert.ToDecimal(b);
            else
                return Convert.ToDecimal(a);
        }

        public void EnableText(bool b)
        {
            this.txtHoten.Properties.ReadOnly = this.txtNamsinh.Properties.ReadOnly = b;
            this.txtDiachi.Properties.ReadOnly = this.txtChandoan.Properties.ReadOnly = this.txtSothang.Properties.ReadOnly = this.txtSohieu.ReadOnly = this.txtSobienlai.ReadOnly = this.txtMaBN.ReadOnly = b;
            this.sLookUpNguoiGT.Properties.ReadOnly = this.txtVoucher.Properties.ReadOnly = this.txtTheKM.Properties.ReadOnly = b;
            this.searchLkupDoctor.Properties.ReadOnly = this.txtNgaySinh.Properties.ReadOnly = b;
            this.txtTylePhuthu.Properties.ReadOnly = this.txtAmountPhuthu.Properties.ReadOnly = b;
            this.txtTienmat.Properties.ReadOnly = this.cbGioiTinh.Properties.ReadOnly = b;
        }

        public void EnableButton(bool b)
        {
            this.butNew.Enabled = b;
            this.butEdit.Enabled = this.butSave.Enabled = this.butCancel.Enabled = this.butInhoadon.Enabled = !b;
        }

        public void ClearText()
        {
            try
            {
                iPaid = 0; dReceiveID = 0;
                this.patientCode = this.exportCode = this.txtSoPhieu.Text = this.medicalRecordCode = string.Empty;
                this.txtHoten.Text = string.Empty;
                this.txtNamsinh.Text = string.Empty;
                this.txtDiachi.Text = string.Empty;
                this.txtChandoan.Text = string.Empty;
                this.txtSothang.Text = string.Empty;
                this.txtSohieu.Text = string.Empty;
                this.txtSobienlai.Text = string.Empty;
                this.txtThang.Text = this.txtNgaySinh.Text = this.txtTuoi.Text = this.lbNamSinh.Text = string.Empty;
                this.cbGioiTinh.SelectedIndex = -1;
                this.searchLkupDoctor.EditValue = null;
                txtAmountUSD.EditValue = 0;
                txtAmountRealUSD.EditValue = 0;
                txtTylePhuthu.EditValue = 0;
                txtAmountPhuthu.EditValue = 0;
                txtTienmat.EditValue = txtThuathieu.EditValue = txtThuathieuOrther.EditValue = 0;
                sLookUpNguoiGT.EditValue = -1;
                txtVoucher.Text = txtTheKM.Text = string.Empty;
                this.txtMaBN.Text = string.Empty;
                this.gridControl_Out.DataSource = null;
                this.gridView_Out.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                this.EnableButton(false);
                this.EnableText(false);
                this.ClearText();
                this.dtMedicalRecord_Out = MedicinesRetailBLL.DT_MedicinesRetailDetail(this.txtSoPhieu.Text.Trim());
                this.gridControl_Out.DataSource = this.dtMedicalRecord_Out;
                this.gridView_Out.OptionsBehavior.ReadOnly = false;
                this.gridView_Out.OptionsBehavior.Editable = true;
                this.gridView_Out.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                this.butUndo.Enabled = true;
                this.butEdit.Enabled = this.butInhoadon.Enabled = this.butCancel.Enabled = this.butPrintHD.Enabled = false;
                this.LoadDataItems();
                this.isMedical_Old = false;
                this.txtNgaySinh.Text = this.dtimeWorkingDate.ToString("dd/MM/yyyy");
                ///this.butReload_Click(sender, e);
                this.txtHoten.Focus();
                this.GetDataRetail();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView_Out_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                if (gridView_Out.GetFocusedRow() != null)
                {
                    //gridView_Out.SetRowCellValue(e.RowHandle, col_Out_DateOfIssues, 1);
                    gridView_Out.SetRowCellValue(e.RowHandle, col_Out_Quantity, 0);
                    gridView_Out.SetRowCellValue(e.RowHandle, col_Out_UnitPrice, 0);
                    gridView_Out.SetRowCellValue(e.RowHandle, col_Out_Amount, 0);
                    gridView_Out.SetRowCellValue(e.RowHandle, col_Out_Status, 0);
                    gridView_Out.SetRowCellValue(e.RowHandle, col_Out_RetailCode, this.exportCode);
                }
                else
                {
                    return;
                }
            }
            catch
            {
                XtraMessageBox.Show("Lỗi phát sinh khi khởi tạo toa thuốc!\t\n- Liên hệ quản trị để được kiểm tra lại.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_Out_KeyPress(object sender, KeyPressEventArgs e)
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

        private void gridView_Out_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (iPaid == 0 || iPaid == -1)
                {
                    if (e.KeyCode == Keys.Delete && gridView_Out.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                    {
                        if (!this.isMedical_Old)
                        {
                            if (XtraMessageBox.Show("Bạn có muốn xóa thuốc này ra khỏi toa thuốc?", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                            {
                                string retailCodeTemp = this.gridView_Out.GetRowCellValue(gridView_Out.FocusedRowHandle, "RetailCode").ToString();
                                if (!string.IsNullOrEmpty(retailCodeTemp))
                                {
                                    if (MedicinesRetailBLL.DelDetail(retailCodeTemp, gridView_Out.GetRowCellValue(gridView_Out.FocusedRowHandle, "ItemCode").ToString()) == 1)
                                    {
                                        //XtraMessageBox.Show(" Xóa thành công!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.dtMedicalRecord_Out = MedicinesRetailBLL.DT_MedicinesRetailDetail(retailCodeTemp);
                                        this.gridControl_Out.DataSource = this.dtMedicalRecord_Out;
                                        this.ProcessTotalPay();
                                    }
                                }
                                else
                                {
                                    this.gridView_Out.DeleteSelectedRows();
                                    this.ProcessTotalPay();
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show(" Vui lòng Click sửa trước khi nhấn xóa!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            this.dtMedicalRecord_Out.Rows.RemoveAt(this.gridView_Out.FocusedRowHandle);
                            this.ProcessTotalPay();
                        }
                    }
                } 
                else
                {
                    XtraMessageBox.Show(" Phiếu xuất đã thanh toán không được phép sửa, xóa, hủy!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                XtraMessageBox.Show("Lỗi phát sinh khi xóa thuốc", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_Out_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh Viện Điện Tử .Net";
            e.ErrorText = "Toa thuốc kê bị thiếu thông tin!.\t\n - YES: Bổ sung thêm\t\n - NO: Xóa nhập lại\t\n";
        }

        private void gridView_Out_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                decimal unitprice = Convert.ToDecimal(view.GetFocusedRowCellValue(col_Out_UnitPrice));
                decimal amount = Convert.ToDecimal(view.GetFocusedRowCellValue(col_Out_Amount));

                s = Convert.ToString(view.GetFocusedRowCellValue("Morning"));
                tr = Convert.ToString(view.GetFocusedRowCellValue("Noon"));
                c = Convert.ToString(view.GetFocusedRowCellValue("Afternoon"));
                t = Convert.ToString(view.GetFocusedRowCellValue("Evening"));
                if (view.FocusedColumn.FieldName == "Morning")
                {
                    if (view.GetFocusedRowCellValue(col_Out_ItemCode) != null)
                    {
                        if (e.Value != null)
                        {
                            decimal issue = Convert.ToDecimal(view.GetFocusedRowCellValue("DateOfIssues"));
                            decimal morning = ParseQuantity(e.Value.ToString());
                            decimal noon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Noon")));
                            decimal afternoon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Afternoon")));
                            decimal evening = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Evening")));

                            view.SetFocusedRowCellValue(col_Out_Quantity, Math.Round((morning + noon + afternoon + evening) * issue, MidpointRounding.AwayFromZero));
                            decimal s1 = Convert.ToDecimal(view.GetFocusedRowCellValue("Quantity")) * unitprice;
                            view.SetFocusedRowCellValue(col_Out_Amount, s1);
                            s = e.Value.ToString();
                        }
                    }
                }
                if (view.FocusedColumn.FieldName == "Noon")
                {
                    if (view.GetFocusedRowCellValue(col_Out_ItemCode) != null)
                    {
                        if (e.Value != null)
                        {
                            decimal issue = Convert.ToDecimal(view.GetFocusedRowCellValue("DateOfIssues"));
                            decimal morning = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Morning")));
                            decimal noon = ParseQuantity(e.Value.ToString());
                            decimal afternoon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Afternoon")));
                            decimal evening = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Evening")));

                            view.SetFocusedRowCellValue(col_Out_Quantity, Math.Round((morning + noon + afternoon + evening) * issue, MidpointRounding.AwayFromZero));
                            decimal s2 = Convert.ToDecimal(view.GetFocusedRowCellValue("Quantity")) * unitprice;
                            view.SetFocusedRowCellValue(col_Out_Amount, s2);
                            tr = e.Value.ToString();
                        }
                    }
                }
                if (view.FocusedColumn.FieldName == "Afternoon")
                {
                    if (view.GetFocusedRowCellValue(col_Out_ItemCode) != null)
                    {
                        if (e.Value != null)
                        {
                            decimal issue = Convert.ToDecimal(view.GetFocusedRowCellValue("DateOfIssues"));
                            decimal morning = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Morning")));
                            decimal noon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Noon")));
                            decimal afternoon = ParseQuantity(e.Value.ToString());
                            decimal evening = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Evening")));

                            view.SetFocusedRowCellValue(col_Out_Quantity, Math.Round((morning + noon + afternoon + evening) * issue, MidpointRounding.AwayFromZero));
                            decimal s3 = Convert.ToDecimal(view.GetFocusedRowCellValue("Quantity")) * unitprice;
                            view.SetFocusedRowCellValue(col_Out_Amount, s3);
                            c = e.Value.ToString();
                        }
                    }
                }
                if (view.FocusedColumn.FieldName == "Evening")
                {
                    if (view.GetFocusedRowCellValue(col_Out_ItemCode) != null)
                    {
                        if (e.Value != null)
                        {
                            decimal issue = Convert.ToDecimal(view.GetFocusedRowCellValue("DateOfIssues"));
                            decimal morning = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Morning")));
                            decimal noon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Noon")));
                            decimal afternoon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Afternoon")));
                            decimal evening = ParseQuantity(e.Value.ToString());

                            view.SetFocusedRowCellValue(col_Out_Quantity, Math.Round((morning + noon + afternoon + evening) * issue, MidpointRounding.AwayFromZero));
                            decimal s4 = Convert.ToDecimal(view.GetFocusedRowCellValue("Quantity")) * unitprice;
                            view.SetFocusedRowCellValue(col_Out_Amount, s4);
                            t = e.Value.ToString();
                        }
                    }
                }
                strUsed = string.Empty;
                //strUsed = "Sáng " + s.ToString() + ", Trưa " + tr.ToString() + ", Chiều " + c.ToString() + ", Tối " + t.ToString();
                if (s.ToString() != string.Empty && s.ToString() != "0")
                    strUsed = "Sáng " + s.ToString();
                if (tr.ToString() != string.Empty && tr.ToString() != "0")
                    strUsed += ",Trưa " + tr.ToString();
                if (c.ToString() != string.Empty && c.ToString() != "0")
                    strUsed += ",Chiều " + c.ToString();
                if (t.ToString() != string.Empty && t.ToString() != "0")
                    strUsed += ",Tối " + t.ToString();
                view.SetFocusedRowCellValue(col_Out_Instruction, strUsed);
                if (view.FocusedColumn.FieldName == "Quantity")
                {
                    if (view.GetFocusedRowCellValue(col_Out_ItemCode) != null)
                    {
                        if (e.Value != null)
                        {
                            decimal totalQuantity = ParseQuantity(e.Value.ToString());
                            decimal s5 = Convert.ToDecimal(totalQuantity * unitprice);
                            view.SetFocusedRowCellValue(col_Out_Amount, s5);
                        }
                    }
                }
                if (view.FocusedColumn.FieldName == "DateOfIssues")
                {
                    if (view.GetFocusedRowCellValue(col_Out_ItemCode) != null)
                    {
                        if (e.Value != null)
                        {
                            decimal issue = Convert.ToDecimal(e.Value);
                            decimal morning = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Morning")));
                            decimal noon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Noon")));
                            decimal afternoon = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Afternoon")));
                            decimal evening = ParseQuantity(Convert.ToString(view.GetFocusedRowCellValue("Evening")));

                            view.SetFocusedRowCellValue(col_Out_Quantity, Math.Round((morning + noon + afternoon + evening) * issue, MidpointRounding.AwayFromZero));
                            decimal s0 = Convert.ToDecimal(view.GetFocusedRowCellValue("Quantity")) * unitprice;
                            view.SetFocusedRowCellValue(col_Out_Amount, s0);
                        }
                    }
                }
                
            }
            catch { }
        }

        private decimal ParseQuantity(string qty)
        {
            decimal sl1 = 0;
            try
            {
                string[] arr;
                if (!string.IsNullOrEmpty(qty.Trim()))
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
            }
            catch { }
            return sl1;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtHoten.Text.Trim().ToString()))
                {
                    XtraMessageBox.Show(" Xin vui lòng nhập họ tên bệnh nhân! ", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtHoten.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.txtNamsinh.Text.Trim()))
                {
                    //XtraMessageBox.Show(" Xin vui lòng nhập năm sinh bệnh nhân! ", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //this.txtNamsinh.Focus();
                    //return;
                    this.txtNgaySinh.Text = this.dtimeWorkingDate.ToString("dd/MM/yyyy");
                    this.txtNamsinh.Text = this.dtimeWorkingDate.ToString("yyyy");
                }
                if (this.txtNgaySinh.Text.Length < 10)
                {
                    this.txtNgaySinh.Text = this.dtimeWorkingDate.ToString("dd/MM/yyyy");
                }
                //if (txtDiachi.Text.Trim().ToString() == "")
                //{
                //    XtraMessageBox.Show(" Xin vui lòng nhập địa chỉ bệnh nhân! ", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    this.txtDiachi.Focus();
                //    return;
                //}
                if (this.cbGioiTinh.SelectedIndex == -1)
                {
                    XtraMessageBox.Show("Chọn giới tính!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbGioiTinh.Focus();
                    return;
                }
                if (dtMedicalRecord_Out.Rows.Count <= 0)
                {
                    XtraMessageBox.Show(" Chi tiết xuất bán chưa có, vui lòng kiểm tra lại! ", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.gridControl_Out.Focus();
                    return;
                }
                if (Convert.ToDecimal(txtTienmat.EditValue) < Convert.ToDecimal(txtAmountRealUSD.EditValue))
                {
                    XtraMessageBox.Show(" Sô tiền khách đưa phải lớn hơn hoặc bằng tiền thực thu!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    string sItemCode = string.Empty;
                    string sError = string.Empty;
                    decimal dQuantityReal = 0, dQuantityEnd = 0, dQuantityVirtual = 0, dQuantityRequest = 0;
                    bool bCheckInventory = true;
                    decimal dTotalAmount = 0;
                    foreach (DataRow r in dtMedicalRecord_Out.Rows)
                    {
                        dQuantityRequest = Convert.ToDecimal(r["Quantity"].ToString());
                        sItemCode = r["ItemCode"].ToString();
                        dQuantityReal = InventoryBLL.QuantityInvent(sItemCode, ref dQuantityVirtual, this.repositoryCode, ref dQuantityEnd);
                        if (dQuantityEnd < dQuantityRequest)
                        {
                            sError += r["ItemName"].ToString() + "(" + dQuantityEnd + ");";
                            bCheckInventory = false;
                        }
                        dTotalAmount += Convert.ToDecimal(r["Amount"].ToString());
                        if (!bCheckInventory)
                        {
                            XtraMessageBox.Show(" Những thuốc sau không đủ tồn! \n" + sError, "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    foreach (DataRow r in dtMedicalRecord_Out.Rows)
                    {
                        dQuantityRequest = Convert.ToDecimal(r["Quantity"].ToString());
                        sItemCode = r["ItemCode"].ToString();
                        if (dQuantityRequest <=0)
                        {
                            sError += r["ItemName"].ToString() + "(" + dQuantityRequest + ");";
                            bCheckInventory = false;
                        }
                        if (!bCheckInventory)
                        {
                            XtraMessageBox.Show(" Những thuốc sau không có số lượng! \n" + sError, "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    if (bCheckInventory)
                    {
                        SystemParameterInf para = new SystemParameterInf();
                        para = SystemParameterBLL.ObjParameter(200);
                        string sSort = string.Empty;
                        if (para != null && para.Values == 1)
                        {
                            this.isImportDate = true;
                            sSort += "DateImport,";
                        }
                        para = SystemParameterBLL.ObjParameter(201);
                        if (para != null && para.Values == 1)
                        {
                            this.isShipment = true;
                            sSort += "Shipment,";
                        }
                        para = SystemParameterBLL.ObjParameter(202);
                        if (para != null && para.Values == 1)
                        {
                            this.isDateEnd = true;
                            sSort += "DateEnd,";
                        }
                        MedicinesRetailInf inf = new MedicinesRetailInf();
                        inf.RetailCode = this.txtSoPhieu.Text.Trim();
                        inf.FullName = this.txtHoten.Text.Trim();
                        inf.Birthyear = this.txtNamsinh.Text.Trim();
                        inf.Address = this.txtDiachi.Text.Trim();
                        inf.Diagnosis = this.txtChandoan.Text.Trim();
                        inf.NumberOfDrugCoal = this.txtSothang.Text.Trim();
                        inf.SerialNumber = this.txtSohieu.Text.Trim();
                        inf.InvoiceNumber = this.txtSobienlai.Text.Trim();
                        inf.EmployeeCode = sUserid;
                        inf.ExportDate = Utils.DateServer();
                        inf.Paid = 0;
                        inf.TotalAmount = Convert.ToDecimal(this.txtAmountUSD.EditValue);
                        inf.TotalAmountReal = Convert.ToDecimal(this.txtAmountRealUSD.EditValue);
                        inf.RateOther = dOther;
                        inf.RateUSD = dUSD;
                        inf.RateSurcharge = Convert.ToDecimal(this.txtTylePhuthu.EditValue);
                        inf.TotalSurcharge = Convert.ToDecimal(this.txtAmountPhuthu.EditValue);
                        inf.IntroCode = sLookUpNguoiGT.EditValue.ToString();
                        inf.Cash = Convert.ToDecimal(txtTienmat.EditValue);
                        inf.ExcessCash = Convert.ToDecimal(this.txtThuathieu.EditValue);
                        inf.VoucherCard = Convert.ToString(this.txtVoucher.EditValue);
                        inf.OtherCard = Convert.ToString(this.txtTheKM.EditValue);
                        inf.ExcessCashOther = Convert.ToDecimal(this.txtThuathieuOrther.EditValue);
                        inf.MedicalRecordCode = this.medicalRecordCode;
                        inf.PatientReceiveID = dReceiveID;
                        inf.PatientCode = this.patientCode;
                        inf.ShiftWork = this.shiftWork;
                        inf.PatientBirthday = Convert.ToDateTime(this.txtNgaySinh.Text);
                        inf.PatientMonth = this.txtThang.Text.Trim();
                        inf.PatientGender = this.cbGioiTinh.SelectedIndex;
                        if (!string.IsNullOrEmpty(this.txtTuoi.Text))
                            inf.PatientAge = Convert.ToInt32(this.txtTuoi.Text);
                        if (this.searchLkupDoctor.EditValue != null)
                            inf.EmployeeCodeDoctor = this.searchLkupDoctor.EditValue.ToString();
                        inf.EmployeeNameDoctor = this.searchLkupDoctor.Text;
                        inf.VAT = Convert.ToInt32(this.lkupVAT.Text);
                        if (MedicinesRetailBLL.Ins(inf, ref this.exportCode) >= 1)
                        {
                            bool isUnitPrice_Menu = false;
                            SystemParameterInf objSys = SystemParameterBLL.ObjParameter(211);
                            if (objSys != null && objSys.RowID > 0)
                                isUnitPrice_Menu = objSys.Values.Equals(1) ? true : false;
                            
                            MedicinesRetailBLL.DelDetail(this.exportCode);
                            this.txtSoPhieu.Text = this.exportCode;
                            bool b = true;
                            foreach (DataRow dr in dtMedicalRecord_Out.Rows)
                            {
                                dQuantityRequest = Convert.ToDecimal(dr["Quantity"].ToString());
                                decimal dQuanReal = 0;
                                sItemCode = dr["ItemCode"].ToString();
                                
                                List<InventoryGumshoeInf> lst = InventoryBLL.ListInventoryGumshoe(sItemCode, this.repositoryCode, sSort.TrimEnd(','), isUnitPrice_Menu);
                                foreach (var v in lst)
                                {
                                    decimal unitpriceTemp = 0;
                                    if (isUnitPrice_Menu)
                                        unitpriceTemp = decimal.Parse(dr["UnitPrice"].ToString());
                                    else
                                        unitpriceTemp = v.SalesPrice;
                                    dQuanReal = v.AmountImport - v.AmountExport;
                                    if (dQuanReal >= dQuantityRequest && dQuanReal > 0)
                                    {
                                        MedicinesRetailDetailInf infDetail = new MedicinesRetailDetailInf();
                                        infDetail.RetailCode = this.exportCode;
                                        infDetail.ItemCode = dr["ItemCode"].ToString();
                                        infDetail.DateOfIssues = Convert.ToInt32(dr["DateOfIssues"].ToString());
                                        infDetail.Quantity = dQuantityRequest;
                                        infDetail.QuantityExport = dQuantityRequest;
                                        infDetail.UnitPrice = unitpriceTemp;// v.SalesPrice;
                                        infDetail.Amount = dQuantityRequest * unitpriceTemp;
                                        infDetail.RowIDInventoryGumshoe = 0;
                                        infDetail.RateBHYT = decimal.Parse(dr["RateBHYT"].ToString());
                                        infDetail.RepositoryCode = this.repositoryCode;
                                        infDetail.Instruction = dr["Instruction"].ToString();
                                        infDetail.Morning = dr["Morning"].ToString();
                                        infDetail.Noon = dr["Noon"].ToString();
                                        infDetail.Afternoon = dr["Afternoon"].ToString();
                                        infDetail.Evening = dr["Evening"].ToString();
                                        if (MedicinesRetailBLL.InsDetail(infDetail) <= 0)
                                            b = false;
                                        //dQuanReal = dQuanReal - dQuantityRequest;
                                        break;
                                    }
                                    else if (dQuanReal > 0)
                                    {
                                        MedicinesRetailDetailInf infDetail = new MedicinesRetailDetailInf();
                                        infDetail.RetailCode = this.exportCode;
                                        infDetail.ItemCode = dr["ItemCode"].ToString();
                                        infDetail.DateOfIssues = Convert.ToInt32(dr["DateOfIssues"].ToString());
                                        infDetail.Quantity = dQuanReal;
                                        infDetail.QuantityExport = dQuanReal;
                                        infDetail.UnitPrice = unitpriceTemp;// v.SalesPrice;
                                        infDetail.Amount = dQuanReal * unitpriceTemp;
                                        infDetail.RowIDInventoryGumshoe = 0;
                                        infDetail.RateBHYT = decimal.Parse(dr["RateBHYT"].ToString());
                                        infDetail.RepositoryCode = this.repositoryCode;
                                        infDetail.Instruction = dr["Instruction"].ToString();
                                        infDetail.Morning = dr["Morning"].ToString();
                                        infDetail.Noon = dr["Noon"].ToString();
                                        infDetail.Afternoon = dr["Afternoon"].ToString();
                                        infDetail.Evening = dr["Evening"].ToString();
                                        if (MedicinesRetailBLL.InsDetail(infDetail) <= 0)
                                        {
                                            b = false;
                                            break;
                                        }
                                        dQuantityRequest = dQuantityRequest - dQuanReal;
                                    }
                                }
                            }
                            if (b)
                            {
                                ///XtraMessageBox.Show(" Đã tạo phiếu xuất bán! XUẤT KHO để in hóa đơn bán hàng. ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dtMedicalRecord_Out = MedicinesRetailBLL.DT_MedicinesRetailDetail(this.exportCode);
                                gridControl_Out.DataSource = dtMedicalRecord_Out;
                                MedicinesRetailInf ObjRetail = MedicinesRetailBLL.ObjRetail(this.exportCode);

                                this.txtAmountUSD.Text = ObjRetail.TotalAmount.ToString("#,#.00#");
                                this.txtTylePhuthu.Text = ObjRetail.RateSurcharge.ToString("N0");
                                this.txtAmountPhuthu.Text = ObjRetail.TotalSurcharge.ToString("#,#.00#");
                                this.txtAmountRealUSD.Text = ObjRetail.TotalAmountReal.ToString("#,#.00#");
                                this.txtTienmat.EditValue = ObjRetail.Cash.ToString("#,#.00#");
                                this.txtThuathieu.EditValue = ObjRetail.ExcessCash.ToString("#,#.00#");
                                this.txtThuathieuOrther.EditValue = ObjRetail.ExcessCashOther.ToString("#,#.00#");

                                this.EnableButton(true);
                                this.EnableText(true);
                                this.butNew.Enabled = this.butInhoadon.Enabled = this.butEdit.Enabled = this.butPrintHD.Enabled = true;
                                this.gridView_Out.OptionsBehavior.ReadOnly = true;
                                this.gridView_Out.OptionsBehavior.Editable = false;
                                this.gridView_Out.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                                this.butInhoadon.Focus();
                                return;
                            }
                            else
                            {
                                MedicinesRetailBLL.DelAll(this.exportCode);
                                XtraMessageBox.Show(" Lỗi cập nhật đơn thuốc! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            MedicinesRetailBLL.DelAll(this.exportCode);
                            XtraMessageBox.Show(" Lỗi cập nhật đơn thuốc! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(" Lỗi khi cập nhật: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
        }
                
        private void gridView_Search_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView_Search.GetFocusedRow() != null)
                {
                    this.exportCode = gridView_Search.GetRowCellValue(gridView_Search.FocusedRowHandle, col_search_RetailCode).ToString();
                    this.txtSoPhieu.Text = this.exportCode;
                    MedicinesRetailInf inf = MedicinesRetailBLL.ObjRetail(this.exportCode);
                    if (inf != null && inf.RetailCode != string.Empty)
                    {
                        this.txtMaBN.Text = inf.PatientCode;
                        this.txtSoPhieu.Text = inf.RetailCode;
                        this.txtHoten.Text = inf.FullName;
                        this.txtNamsinh.Text = inf.Birthyear;
                        this.txtDiachi.Text = inf.Address;
                        this.txtChandoan.Text = inf.Diagnosis;
                        this.txtSothang.Text = inf.NumberOfDrugCoal;
                        this.txtSohieu.Text = inf.SerialNumber;
                        this.lkupVAT.EditValue = inf.VAT.ToString();
                        this.txtSobienlai.Text = inf.InvoiceNumber;
                        this.txtNgaySinh.Text = inf.PatientBirthday.ToString("dd/MM/yyyy");
                        this.cbGioiTinh.SelectedIndex = inf.PatientGender;
                        this.searchLkupDoctor.EditValue = inf.EmployeeCodeDoctor;
                        this.txtThang.Text = inf.PatientMonth;
                        this.txtTuoi.Text = inf.PatientAge.ToString();
                        this.iPaid = inf.Paid;
                        this.sLookUpNguoiGT.EditValue = inf.IntroCode;
                        this.txtVoucher.Text = inf.VoucherCard;
                        this.txtTheKM.Text = inf.OtherCard;
                        this.txtAmountUSD.EditValue = inf.TotalAmount.ToString("#,#.00#");
                        this.txtTylePhuthu.EditValue = inf.RateSurcharge.ToString("N0");
                        this.txtAmountPhuthu.EditValue = inf.TotalSurcharge.ToString("#,#.00#");
                        this.txtAmountRealUSD.EditValue = inf.TotalAmountReal.ToString("#,#.00#");
                        this.txtTienmat.EditValue = inf.Cash.ToString("#,#.00#");
                        this.txtThuathieu.EditValue = inf.ExcessCash.ToString("#,#.00#");
                        this.txtThuathieuOrther.EditValue = inf.ExcessCashOther.ToString("#,#.00#");
                        this.dtMedicalRecord_Out = MedicinesRetailBLL.DT_MedicinesRetailDetail(this.exportCode);
                        this.gridControl_Out.DataSource = this.dtMedicalRecord_Out;
                        this.medicalRecordCode = inf.MedicalRecordCode;
                        this.dReceiveID = inf.PatientReceiveID;
                        this.TuoiBenhNhan(string.Empty, this.txtNgaySinh.Text);
                    }
                    this.gridView_Out.OptionsBehavior.ReadOnly = true;
                    this.gridView_Out.OptionsBehavior.Editable = false;
                    this.gridView_Out.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    this.EnableText(true);
                    if (inf != null && inf.Paid != -1)
                        this.butEdit.Enabled = butNew.Enabled = butInhoadon.Enabled = butCancel.Enabled = this.butPrintHD.Enabled = true;
                    else
                    {
                        this.butEdit.Enabled = butInhoadon.Enabled = butCancel.Enabled = false;
                        this.butNew.Enabled = true;
                    }
                    this.txtSobienlai.ReadOnly = false;
                    this.butSave.Enabled = false;
                }
            }
            catch { }
        }

        private void Print_Medicines()
        {
            try
            {
                double dblTotalRealTemp = 0;
                DataTable dtClinic = new DataTable("ClinicInfo");
                dtClinic = ClinicInformationBLL.DT_Information(1);
                DataTable dtResult = new DataTable("ResultMedicinesRetail");
                dtResult = MedicinesRetailBLL.rpt_MedicinesRetail(this.exportCode, 1);
                if (dtResult.Rows.Count > 0)
                {
                    DataSet dsTemp = new DataSet("Result");
                    DataTable dtResultDetail = new DataTable("Detail");
                    dtResultDetail = MedicinesRetailBLL.rpt_MedicinesRetailDetail(this.exportCode);
                    dsTemp.Tables.Add(dtResult);
                    if (dtResultDetail != null && dtResultDetail.Rows.Count > 0)
                    {
                        dsTemp.Tables.Add(dtResultDetail);
                    }
                    dblTotalRealTemp = Convert.ToDouble(dtResult.Rows[0]["TotalAmountReal"].ToString());
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptToaThuocBanLe.xml");
                    //Reports.rptToaThuocBanLeA5 rpt = new Reports.rptToaThuocBanLeA5();
                    //rpt.DataSource = dsTemp;
                    //rpt.Parameters["prTotalReal"].Value = dblTotalRealTemp;
                    //rpt.CreateDocument();
                    //if(this.chkPrinted.Checked)
                    //   rpt.Print();
                    //else
                    //    rpt.ShowRibbonPreviewDialog();
                    Reports.rptToaThuocBanLeA5 rptShow = new Reports.rptToaThuocBanLeA5();
                    rptShow.Parameters["prTotalReal"].Value = dblTotalRealTemp;
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "ToaThuocMuaNgoai","Toa thuốc mua ngoài");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Toa thuốc không tồn tại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                string retailCodeTemp = this.txtSoPhieu.Text.Trim();
                if (iPaid == 0)
                {
                    if (XtraMessageBox.Show("Bạn muốn hủy toa thuốc này hay không?", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        if (MedicinesRetailBLL.DelAll(retailCodeTemp) >= 1)
                        {
                            ///XtraMessageBox.Show(" Hủy toa thuốc thành công!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.butNew_Click(sender, e);
                            this.EnableButton(true);
                            this.EnableText(true);
                            DataTable dtResult = MedicinesRetailBLL.DT_ListRetail(DateTime.Now.Date.ToString("dd/MM/yyyy"), DateTime.Now.Date.ToString("dd/MM/yyyy"), this.chkCancel.Checked ? true : false, this.chkDone.Checked ? true : false);
                            this.gridControl_Search.DataSource = dtResult;
                            return;
                        }
                        else
                        {
                            XtraMessageBox.Show(" Hủy toa thuốc không thành công!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                else if (iPaid == 1)
                {
                    if (EmployeeBLL.CheckUserAdmin(this.sUserid))
                    {
                        ViewPopup.frmLyDoHuyPhieuThu frmCancel = new ViewPopup.frmLyDoHuyPhieuThu();
                        frmCancel.ShowDialog();
                        if (string.IsNullOrEmpty(frmCancel.reason))
                            return;
                        if (XtraMessageBox.Show(" Thuốc đã xuất bạn thật sự muốn hủy hóa đơn này hay không?", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                        {
                            if (MedicinesRetailBLL.Del_AfterInvoiceNumber(this.txtSoPhieu.Text.Trim(), sUserid, frmCancel.reason) >= 1)
                            {
                                ///XtraMessageBox.Show(" Hủy hóa đơn thành công!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                this.butNew_Click(sender, e);
                                this.EnableButton(true);
                                this.EnableText(true);
                                DataTable dtResult = MedicinesRetailBLL.DT_ListRetail(DateTime.Now.Date.ToString("dd/MM/yyyy"), DateTime.Now.Date.ToString("dd/MM/yyyy"), this.chkCancel.Checked ? true : false, this.chkDone.Checked ? true : false);
                                this.gridControl_Search.DataSource = dtResult;
                                if (XtraMessageBox.Show("Bạn có muốn lấy lại thông tin toa thuốc đã hủy?", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    this.GetDataRetailCancel(retailCodeTemp);
                                }
                                else
                                    return;
                            }
                            else
                            {
                                XtraMessageBox.Show(" Hủy hóa đơn không thành công!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("User không có quyền hủy phiếu thu này! Vui lòng liên hệ quản trị hệ thống.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Đơn thuốc này đã thu tiền! Không cho phép hủy đơn thuốc. Vui lòng hủy hóa đơn trước.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch { }
        }

        private void GetDataRetailCancel(string retailCode)
        {
            MedicinesRetailInf inf = MedicinesRetailBLL.ObjRetail(retailCode);
            if (inf != null && inf.RetailCode != string.Empty)
            {
                this.txtSoPhieu.Text = string.Empty;
                this.txtHoten.Text = inf.FullName;
                this.txtNamsinh.Text = inf.Birthyear;
                this.txtDiachi.Text = inf.Address;
                this.txtChandoan.Text = inf.Diagnosis;
                this.txtSothang.Text = inf.NumberOfDrugCoal;
                this.txtSohieu.Text = inf.SerialNumber;
                this.txtSobienlai.Text = inf.InvoiceNumber;
                this.txtNgaySinh.Text = inf.PatientBirthday.ToString("dd/MM/yyyy");
                this.cbGioiTinh.SelectedIndex = inf.PatientGender;
                this.searchLkupDoctor.EditValue = inf.EmployeeCodeDoctor;
                this.txtThang.Text = inf.PatientMonth;
                this.txtTuoi.Text = inf.PatientAge.ToString();
                this.iPaid = inf.Paid;
                this.sLookUpNguoiGT.EditValue = inf.IntroCode;
                this.txtVoucher.Text = inf.VoucherCard;
                this.txtTheKM.Text = inf.OtherCard;
                this.txtAmountUSD.EditValue = inf.TotalAmount.ToString("#,#.00#");
                this.txtTylePhuthu.EditValue = inf.RateSurcharge.ToString("N0");
                this.txtAmountPhuthu.EditValue = inf.TotalSurcharge.ToString("#,#.00#");
                this.txtAmountRealUSD.EditValue = inf.TotalAmountReal.ToString("#,#.00#");
                this.txtTienmat.EditValue = inf.Cash.ToString("#,#.00#");
                this.txtThuathieu.EditValue = inf.ExcessCash.ToString("#,#.00#");
                this.txtThuathieuOrther.EditValue = inf.ExcessCashOther.ToString("#,#.00#");
                this.dtMedicalRecord_Out = MedicinesRetailBLL.DT_MedicinesRetailDetail(retailCode);
                this.gridControl_Out.DataSource = dtMedicalRecord_Out;
                this.TuoiBenhNhan(string.Empty, this.txtNgaySinh.Text);
                this.isMedical_Old = true;
            }
            this.EnableButton(false);
            this.EnableText(false);
            this.gridView_Out.OptionsBehavior.ReadOnly = false;
            this.gridView_Out.OptionsBehavior.Editable = true;
            this.gridView_Out.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            this.butUndo.Enabled = true;
            this.butEdit.Enabled = this.butInhoadon.Enabled = this.butCancel.Enabled = false;
        }

        private void butInhoadon_Click(object sender, EventArgs e)
        {
            try
            {
                if (iPaid == 1)
                {
                    this.Print_Medicines();
                    this.butToaThuoc.Focus();
                }
                else
                {
                    string sItemCode = string.Empty;
                    string sError = string.Empty;
                    decimal dQuantityReal = 0, dQuantityEnd = 0, dQuantityVirtual = 0, dQuantityRequest = 0;
                    bool bCheckInventory = true;
                    foreach (DataRow r in dtMedicalRecord_Out.Rows)
                    {
                        dQuantityRequest = Convert.ToDecimal(r["Quantity"].ToString());
                        sItemCode = r["ItemCode"].ToString();
                        dQuantityReal = InventoryBLL.QuantityInvent(sItemCode, ref dQuantityVirtual, this.repositoryCode, ref dQuantityEnd);
                        if (dQuantityEnd < dQuantityRequest)
                        {
                            sError += r["ItemName"].ToString() + "(" + dQuantityEnd + ");";
                            bCheckInventory = false;
                        }
                        if (!bCheckInventory)
                        {
                            XtraMessageBox.Show(" Những thuốc sau không đủ tồn! \n" + sError, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    if (bCheckInventory)
                    {
                        //MedicinesRetailInf inf = new MedicinesRetailInf();
                        //inf.RetailCode = txtMabn.Text.Trim();
                        //inf.FullName = txtHoten.Text.Trim();
                        //inf.Birthyear = txtNamsinh.Text.Trim();
                        //inf.Address = txtDiachi.Text.Trim();
                        //inf.Diagnosis = txtChandoan.Text.Trim();
                        //inf.NumberOfDrugCoal = txtSothang.Text.Trim();
                        //inf.SerialNumber = txtSohieu.Text.Trim();
                        //inf.InvoiceNumber = txtSobienlai.Text.Trim();
                        //inf.EmployeeCode = sUserid;
                        //inf.ExportDate = Utils.DateServer();
                        //inf.Paid = 1;
                        this.exportCode = this.txtSoPhieu.Text.Trim();
                        if (MedicinesRetailBLL.UpdStatus(1, this.exportCode) >= 1)
                        {
                            bool isUnitPrice_Menu = false;
                            SystemParameterInf objSys = SystemParameterBLL.ObjParameter(211);
                            if (objSys != null && objSys.RowID > 0)
                            {
                                isUnitPrice_Menu = objSys.Values.Equals(1) ? true : false;
                            }

                            MedicinesRetailBLL.DelDetail(this.exportCode);
                            this.txtSoPhieu.Text = this.exportCode;
                            SystemParameterInf para = new SystemParameterInf();
                            para = SystemParameterBLL.ObjParameter(200);
                            string sSort = string.Empty;
                            if (para != null && para.Values == 1)
                            {
                                sSort += "DateImport,";
                            }
                            para = SystemParameterBLL.ObjParameter(201);
                            if (para != null && para.Values == 1)
                            {
                                sSort += "Shipment,";
                            }
                            para = SystemParameterBLL.ObjParameter(202);
                            if (para != null && para.Values == 1)
                            {
                                sSort += "DateEnd,";
                            }
                            bool b = false;

                            foreach (DataRow dr in dtMedicalRecord_Out.Rows)
                            {
                                MedicinesRetailDetailInf infDetail = new MedicinesRetailDetailInf();
                                infDetail.RetailCode = this.exportCode;
                                sItemCode = dr["ItemCode"].ToString();
                                infDetail.ItemCode = sItemCode;
                                infDetail.DateOfIssues = Convert.ToInt32(dr["DateOfIssues"].ToString());
                                dQuantityRequest = Convert.ToDecimal(dr["Quantity"].ToString());
                                infDetail.Quantity = dQuantityRequest;
                                List<InventoryGumshoeInf> lst = InventoryBLL.ListInventoryGumshoe(sItemCode, this.repositoryCode, sSort.TrimEnd(','), isUnitPrice_Menu);
                                if (lst != null && lst.Count > 0)
                                {
                                    dQuantityRequest = infDetail.Quantity;
                                    foreach (var v in lst)
                                    {
                                        decimal unitpriceTemp = 0;
                                        if (isUnitPrice_Menu)
                                            unitpriceTemp = decimal.Parse(dr["UnitPrice"].ToString());
                                        else
                                            unitpriceTemp = v.SalesPrice;
                                        if (dQuantityRequest <= (v.AmountImport - v.AmountExport))
                                        {
                                            infDetail.QuantityExport = dQuantityRequest;
                                            infDetail.UnitPrice = unitpriceTemp;// v.SalesPrice;
                                            infDetail.Amount = dQuantityRequest * unitpriceTemp;
                                            infDetail.RowIDInventoryGumshoe = v.RowID;
                                            infDetail.RateBHYT = decimal.Parse(dr["RateBHYT"].ToString());
                                            infDetail.RepositoryCode = this.repositoryCode;
                                            infDetail.Instruction = dr["Instruction"].ToString();
                                            infDetail.Morning = dr["Morning"].ToString();
                                            infDetail.Noon = dr["Noon"].ToString();
                                            infDetail.Afternoon = dr["Afternoon"].ToString();
                                            infDetail.Evening = dr["Evening"].ToString();
                                            if (MedicinesRetailBLL.InsDetailSub(infDetail) > 0)
                                                b = true;
                                            else
                                                b = false;
                                            break;
                                        }
                                        else
                                        {
                                            dQuantityReal = (v.AmountImport - v.AmountExport);
                                            dQuantityRequest = dQuantityRequest - dQuantityReal;
                                            infDetail.QuantityExport = dQuantityReal;
                                            infDetail.UnitPrice = unitpriceTemp;// v.SalesPrice;
                                            infDetail.Amount = dQuantityReal * unitpriceTemp;
                                            infDetail.RowIDInventoryGumshoe = v.RowID;
                                            infDetail.RateBHYT = decimal.Parse(dr["RateBHYT"].ToString());
                                            infDetail.RepositoryCode = this.repositoryCode;
                                            infDetail.Instruction = dr["Instruction"].ToString();
                                            infDetail.Morning = dr["Morning"].ToString();
                                            infDetail.Noon = dr["Noon"].ToString();
                                            infDetail.Afternoon = dr["Afternoon"].ToString();
                                            infDetail.Evening = dr["Evening"].ToString();
                                            if (MedicinesRetailBLL.InsDetailSub(infDetail) > 0)
                                                b = true;
                                            else
                                                b = false;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (b)
                            {
                                MedicinesRetailBLL.UpdAmountRealRetail(this.exportCode);
                                ///XtraMessageBox.Show(" Đã XUẤT KHO và In hóa đơn bán hàng! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.EnableButton(true);
                                this.EnableText(true);
                                this.Print_Medicines();
                                string sDate = Utils.DateServer().ToString("dd/MM/yyyy");
                                this.gridControl_Search.DataSource = MedicinesRetailBLL.DT_ListRetail(sDate, sDate, this.chkCancel.Checked ? true : false, this.chkDone.Checked ? true : false);
                                this.butToaThuoc.Focus();
                            }
                            else
                            {
                                XtraMessageBox.Show(" Lỗi xuất bán thuốc thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show(" Lỗi xuất bán thuốc thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butReload_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.dtfrom.Text.Trim()) || string.IsNullOrEmpty(this.dtto.Text.Trim()))
                {
                    XtraMessageBox.Show(" Chọn ngày để xem ? ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);                       
                    return;
                }
                else
                {
                    if (this.tabSearchMain.SelectedTabPageIndex == 0)
                        this.GetDataRetail();
                    else if (this.tabSearchMain.SelectedTabPageIndex == 1)
                        this.gridControl_Patient_List.DataSource = PatientReceiveBLL.DTListPatientsSearch(string.Empty, string.Empty, string.Empty, string.Empty, this.dtfrom.Text.Trim(), this.dtto.Text.Trim());
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void GetDataRetail()
        {
            this.gridControl_Search.DataSource = MedicinesRetailBLL.DT_ListRetail(this.dtfrom.Text.Trim(), this.dtto.Text.Trim(), this.chkCancel.Checked ? true : false, this.chkDone.Checked ? true : false);
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            if (iPaid == 0)
            {
                gridView_Out.OptionsBehavior.ReadOnly = false;
                gridView_Out.OptionsBehavior.Editable = true;
                gridView_Out.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                butEdit.Enabled = butInhoadon.Enabled = false;
                butNew.Enabled = butSave.Enabled = butCancel.Enabled = true;
                EnableText(false);
            }
            else
            {
                EnableButton(true);
                EnableText(true);
                XtraMessageBox.Show(" Đơn thuốc đã thanh toán không được phép sửa!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butUndo_Click(object sender, EventArgs e)
        {
            EnableButton(true);
            butUndo.Enabled = false;
            EnableText(true);
        }

        private void txtHoten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}"); 
        }

        private void txtNamsinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}"); 
        }

        private void txtDiachi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}"); 
        }

        private void txtChandoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}"); 
        }

        private void txtSothang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}"); 
        }

        private void txtSohieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}"); 
        }

        private void txtSobienlai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}"); 
        }

        private void frmXuatBanLe_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: this.butNew_Click(sender, e); break;                   //F1 - Mới
                case Keys.F3: this.butSave_Click(sender, e); break;                  //F3 - Lưu
                case Keys.F7: this.butInhoadon_Click(sender, e); break;              //F7 - In
            }
        }

        private void txtTylePhuthu_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal dRealTemp = Convert.ToDecimal(txtAmountUSD.EditValue);
                if (dRealTemp > 0)
                {
                    decimal dPhuthu_temp = (Convert.ToDecimal(txtTylePhuthu.EditValue) * dRealTemp) / 100;
                    decimal dTong_Temp = dRealTemp + dPhuthu_temp;
                    txtAmountPhuthu.Text = dPhuthu_temp.ToString("#,#.00#");
                    txtAmountRealUSD.Text = dTong_Temp.ToString("#,#.00#");
                }
                else
                {
                    //XtraMessageBox.Show("Không phát sinh hóa đơn chờ điều chỉnh thu!", "Bệnh Viện Điện Tử .Net");
                    return;
                }
            }
            catch { }
        }

        private void txtAmountPhuthu_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!Utils.IsNumber(txtTienmat.Text.Trim()))
                {
                    XtraMessageBox.Show("Tiền bệnh nhân đưa phải nhập số!", "Bệnh Viện Điện Tử .Net");
                    txtTienmat.Focus();
                    return;
                }
                else
                {
                    decimal dAmountTemp = Convert.ToDecimal(txtAmountUSD.EditValue);
                    if (dAmountTemp > 0)
                    {
                        decimal dPhuthu_temp = Convert.ToDecimal(txtAmountPhuthu.EditValue);
                        decimal dTong_Temp = dAmountTemp + dPhuthu_temp;
                        txtAmountRealUSD.Text = dTong_Temp.ToString("#,#.00#");
                    }
                    else
                    {
                        //XtraMessageBox.Show("Không phát sinh hóa đơn chờ điều chỉnh thu!", "Bệnh Viện Điện Tử .Net");
                        return;
                    }
                }
            }
            catch { }
        }

        private void txtTienmat_Validated(object sender, EventArgs e)
        {
            decimal dTienmat = 0, dTotalReal = 0, dTienConlai = 0, dTienConlaiRial = 0;
            try
            {
                dTienmat = Convert.ToDecimal(txtTienmat.EditValue);
                dTotalReal = Convert.ToDecimal(txtAmountRealUSD.EditValue);
                dTienConlai = (Convert.ToDecimal(txtTienmat.EditValue) - Convert.ToDecimal(txtAmountRealUSD.EditValue));
                dTienConlaiRial = dTienConlai - Math.Truncate(dTienConlai);
                if (dTotalReal > dTienmat)
                {
                    txtThuathieu.EditValue = 0;
                    txtThuathieuOrther.EditValue = (((dTienConlai - dTienConlaiRial) * dOther) + (dTienConlaiRial * dOther)).ToString("#,#.00#");
                }
                else
                {
                    dTienmat = Convert.ToDecimal(txtTienmat.EditValue);
                    dTienConlaiRial = dTienConlai - Math.Truncate(dTienConlai);
                    txtThuathieu.EditValue = (dTienConlai - dTienConlaiRial).ToString("#,#.00#");
                    txtThuathieuOrther.EditValue = (dTienConlaiRial * dOther).ToString("#,#.00#");
                }
            }
            catch { }
        }

        private void sLookUpNguoiGT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}"); 
        }

        private void txtVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}"); 
        }

        private void txtTheKM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}"); 
        }

        private void txtNgaySinh_Validated(object sender, EventArgs e)
        {
            if (this.txtNgaySinh.Text == "" || this.txtNgaySinh.Text == "__/__/____") return;
            this.txtNgaySinh.Text = this.txtNgaySinh.Text.Trim();
            if (!Utils.isDate(this.txtNgaySinh.Text))
            {
                XtraMessageBox.Show("Ngày sinh không hợp lệ !", "Bệnh Viện Điện Tử .Net");
                txtNgaySinh.Focus();
                return;
            }
            this.txtNgaySinh.Text = Utils.KiemTrangaygio(this.txtNgaySinh.Text, 10);
            if (!Utils.isDate(string.Empty, this.txtNgaySinh.Text))
            {
                XtraMessageBox.Show("Ngày sinh không hợp lệ !", "Bệnh Viện Điện Tử .Net");
                this.txtNgaySinh.Focus();
                return;
            }
            try
            {
                this.TuoiBenhNhan(string.Empty, this.txtNgaySinh.Text);
                if (int.Parse(this.txtTuoi.Text) > 130)
                {
                    XtraMessageBox.Show("Ngày sinh không hợp lệ !", "Bệnh Viện Điện Tử .Net");
                    this.txtNgaySinh.Focus();
                    return;
                }
                if ((string.IsNullOrEmpty(this.txtTuoi.Text) && string.IsNullOrEmpty(this.txtThang.Text)) || (this.txtTuoi.Text.Equals(0) && this.txtThang.Text.Equals(0)))
                {
                    XtraMessageBox.Show("Vui lòng nhập năm sinh của bệnh nhân!", "Bệnh Viện Điện Tử .Net");
                    this.txtNamsinh.Focus();
                    return;
                }
            }
            catch { }
        }

        private void gridView_Patient_List_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.butNew_Click(sender, e);
                if (this.gridView_Patient_List.GetFocusedRow() != null)
                {
                    if (this.gridView_Patient_List.RowCount > 0)
                    {
                        this.patientCode = this.gridView_Patient_List.GetRowCellValue(this.gridView_Patient_List.FocusedRowHandle, this.col_PatientCode).ToString();
                        this.dReceiveID = Convert.ToDecimal(this.gridView_Patient_List.GetRowCellValue(this.gridView_Patient_List.FocusedRowHandle, this.col_PatientReceiveID).ToString());
                        this.txtSoPhieu.Text = string.Empty;
                        if (string.IsNullOrEmpty(this.patientCode))
                        {
                            XtraMessageBox.Show(" Thông tin bệnh nhân không tồn tại trong hệ thống!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            this.GetInfoPatient();
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            catch { return; }
        }

        private void gridView_Out_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                string itemCode = view.GetRowCellValue(rowfocus, col_Out_ItemCode).ToString();
                if (itemCode == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Out_ItemCode, "Nhập tên thuốc! ");
                }
                if (ISDBNULL2DECIMAL(Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_Out_Quantity)), 1) <= 0)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Out_Quantity, "Số lượng yêu cầu lớn hơn 0 !");
                }
                if (ISDBNULL2DECIMAL(Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_Out_UnitPrice)), 1) < 0)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Out_UnitPrice, "Chưa khai đơn giá cho thuốc!");
                }
            }
            catch { }
        }
                
        private void txtTienmat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                butSave.Focus();
        }

        private void gridView_Out_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                //if (view.FocusedColumn.FieldName == "ItemCode" && view.ActiveEditor is LookUpEdit)
                //{
                //    Text = view.ActiveEditor.Parent.Name;
                //    DevExpress.XtraEditors.LookUpEdit edit;
                //    edit = (LookUpEdit)view.ActiveEditor;
                //    DataTable table = edit.Properties.LookUpData.DataSource as DataTable;
                //    cloneout = new DataView(table);
                //    DataRow row = view.GetDataRow(view.FocusedRowHandle);
                //    //clone.RowFilter = "AmountEnd >0 " + row["AmountEnd"].ToString();
                //    cloneout.RowFilter = "AmountEnd >0 ";
                //    edit.Properties.LookUpData.DataSource = cloneout;
                //}
                if (view.FocusedColumn.FieldName == "ItemCode" && view.ActiveEditor is SearchLookUpEdit)
                {
                    Text = view.ActiveEditor.Parent.Name;
                    DevExpress.XtraEditors.SearchLookUpEdit searchEdit;
                    searchEdit = (SearchLookUpEdit)view.ActiveEditor;
                    DataTable table = this.repSearch_Out_ItemCode.DataSource as DataTable;
                    cloneout = new DataView(table);
                    DataRow row = view.GetDataRow(view.FocusedRowHandle);
                    cloneout.RowFilter = "AmountEnd >0 ";
                    searchEdit.Properties.DataSource = cloneout;
                }
            }
            catch { }
        }

        private void txtNgaySinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void searchLkupDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void cbGioiTinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void tabSearchMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (this.tabSearchMain.SelectedTabPageIndex == 0)
            {
                DataTable dtResult = MedicinesRetailBLL.DT_ListRetail(this.dtfrom.Text.Trim(), this.dtto.Text.Trim(), this.chkCancel.Checked ? true : false, this.chkDone.Checked ? true : false);
                this.gridControl_Search.DataSource = dtResult;
            }
            else if (this.tabSearchMain.SelectedTabPageIndex == 1)
            {
                this.gridControl_Patient_List.DataSource = PatientReceiveBLL.DTListPatientsSearch(string.Empty, string.Empty, string.Empty, string.Empty, this.dtfrom.Text.Trim(), this.dtto.Text.Trim());
            }
        }

        private void chkCancel_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkCancel.Checked)
            {
                this.chkDone.Checked = false;
                if (this.tabSearchMain.SelectedTabPageIndex == 0)
                {
                    DataTable dtResult = MedicinesRetailBLL.DT_ListRetail(this.dtfrom.Text.Trim(), this.dtto.Text.Trim(), this.chkCancel.Checked ? true : false, this.chkDone.Checked ? true : false);
                    this.gridControl_Search.DataSource = dtResult;
                }
                else if (this.tabSearchMain.SelectedTabPageIndex == 1)
                {
                    this.gridControl_Patient_List.DataSource = PatientReceiveBLL.DTListPatientsSearch(string.Empty, string.Empty, string.Empty, string.Empty, this.dtfrom.Text.Trim(), this.dtto.Text.Trim());
                }
            }
        }

        private void txtHoten_Validated(object sender, EventArgs e)
        {
            this.txtHoten.Text = this.txtHoten.Text.Trim().Trim('-').Trim('+');
            this.txtHoten.Text = Utils.ToUpperCharacterFisrt(this.txtHoten.Text);
        }

        private void txtMaBN_Validated(object sender, EventArgs e)
        {
            try
            {
                List<MedicalRecord_INF> lstMedical = MedicalRecord_BLL.ListMedicalRecordForPatientCode(this.txtMaBN.Text.Trim(), this.dtimeWorkingDate);
                if (lstMedical.Count > 0 && lstMedical != null)
                {
                    this.patientCode = lstMedical[0].PatientCode;
                    this.dReceiveID = lstMedical[0].PatientReceiveID;
                    this.searchLkupDoctor.EditValue = lstMedical[0].EmployeeCodeDoctor;
                    this.txtChandoan.Text = lstMedical[0].DiagnosisCustom;
                    this.medicalRecordCode = lstMedical[0].MedicalRecordCode;
                    this.GetInfoPatient();
                }
                else
                {
                    this.patientCode = this.txtMaBN.Text.Trim();
                    this.dReceiveID = 0;
                    this.GetInfoPatient();
                }
            }
            catch {
                this.txtHoten.Focus();
                return; }
        }

        private void txtMaBN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void butPrintHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtSobienlai.Text.Trim().ToString() == string.Empty)
                {
                    XtraMessageBox.Show(" Vui lòng nhập số hóa đơn trước khi in.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtSobienlai.Focus();
                    return;
                }
                MedicinesRetailBLL.UpdVAT_InvoiceNumber(this.exportCode, this.txtSobienlai.Text.Trim(), Convert.ToInt32(this.lkupVAT.Text));
                this.PrintVAT();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_Out_HiddenEditor(object sender, EventArgs e)
        {
            if (this.cloneout != null)
            {
                this.cloneout.Dispose();
                this.cloneout = null;
            }
        }

        private void chkDone_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDone.Checked)
            {
                this.chkCancel.Checked = false;
                if (this.tabSearchMain.SelectedTabPageIndex == 0)
                {
                    DataTable dtResult = MedicinesRetailBLL.DT_ListRetail(this.dtfrom.Text.Trim(), this.dtto.Text.Trim(), this.chkCancel.Checked ? true : false, this.chkDone.Checked ? true : false);
                    this.gridControl_Search.DataSource = dtResult;
                }
                else if (this.tabSearchMain.SelectedTabPageIndex == 1)
                {
                    this.gridControl_Patient_List.DataSource = PatientReceiveBLL.DTListPatientsSearch(string.Empty, string.Empty, string.Empty, string.Empty, this.dtfrom.Text.Trim(), this.dtto.Text.Trim());
                }
            }
        }

        private void repSearch_Out_ItemCode_Popup(object sender, EventArgs e)
        {
            PopupSearchLookUpEditForm f = (sender as DevExpress.Utils.Win.IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            SearchEditLookUpPopup popup = f.ActiveControl as SearchEditLookUpPopup;
            popup.FindTextBox.Text = "\"\"";
            popup.FindTextBox.SelectionStart = 1;
        }

        private void gridView_Out_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            ProcessTotalPay();
        }

        private void ProcessTotalPay()
        {
            try
            {
                decimal dTotalAmountTemp = 0, dTilePhuThuTemp = 0, dTotalPhuThuTemp = 0, dTienmat = 0, dTotalReal = 0, dTienConlai = 0, dTienConlaiRial = 0;
                foreach (DataRow dr in dtMedicalRecord_Out.Rows)
                {
                    dTotalAmountTemp += Convert.ToDecimal(dr["Quantity"].ToString()) * Convert.ToDecimal(dr["UnitPrice"].ToString());
                }
                txtAmountUSD.Text = (dTotalAmountTemp).ToString("#,#.00#");
                txtTienmat.Text = (dTotalAmountTemp).ToString("#,#.00#");
                txtTylePhuthu.Text = dTilePhuThuTemp.ToString("#,#.00#");
                txtAmountPhuthu.Text = dTotalPhuThuTemp.ToString("#,#.00#");
                dTotalReal = (dTotalAmountTemp - dTotalPhuThuTemp);
                txtAmountRealUSD.Text = dTotalReal.ToString("#,#.00#");
                dTienmat = Convert.ToDecimal(txtTienmat.EditValue);
                if (dTienmat > 0)
                {
                    dTotalReal = Convert.ToDecimal(txtAmountRealUSD.EditValue);
                    dTienConlai = (dTienmat - dTotalReal);
                    dTienConlaiRial = dTienConlai - Math.Truncate(dTienConlai);
                    if (dTotalReal > dTienmat)
                    {
                        txtThuathieu.EditValue = 0;
                        txtThuathieuOrther.EditValue = (((dTienConlai - dTienConlaiRial) * dOther) + (dTienConlaiRial * dOther)).ToString("#,#.00#");
                    }
                    else
                    {
                        dTienmat = Convert.ToDecimal(txtTienmat.EditValue);
                        dTienConlaiRial = dTienConlai - Math.Truncate(dTienConlai);
                        txtThuathieu.EditValue = (dTienConlai - dTienConlaiRial).ToString("#,#.00#");
                        txtThuathieuOrther.EditValue = (dTienConlaiRial * dOther).ToString("#,#.00#");
                    }
                }
            }
            catch { }
        }

        private void butToaThuoc_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtTemp = new DataTable();
                decimal receiveID = -1;
                string sPatientName = string.Empty, sAddRess = string.Empty, sBirthyear = string.Empty, employeeCodeDoctor = string.Empty, diagnosisName = string.Empty, diagnosisCustom = string.Empty, medicalCode = string.Empty, patientCode = string.Empty;
                frmToaBacSiPK frm = new frmToaBacSiPK();
                frm.ShowDialog();
                dtTemp = frm.dtMedicalDetail.Copy();
                sPatientName = frm.sPatientName;
                sAddRess = frm.sAddRess;
                sBirthyear = frm.sBirthyear;
                employeeCodeDoctor = frm.employeeCodeDoctor;
                diagnosisName = frm.diagnosisName;
                diagnosisCustom = frm.diagnosisCustom;
                medicalCode = frm.sMedicalCode;
                patientCode = frm.sPatientCode;
                receiveID = frm.dReceiveID;
                frm.Dispose();
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    this.butNew_Click(sender, e);
                    this.txtHoten.Text = sPatientName;
                    this.txtNamsinh.Text = sBirthyear;
                    this.txtDiachi.Text = sAddRess;
                    this.medicalRecordCode = medicalCode;
                    this.patientCode = this.txtMaBN.Text = patientCode;
                    this.dReceiveID = receiveID;
                    this.txtChandoan.Text = diagnosisCustom;
                    this.txtNgaySinh.Text = frm.ngaysinh;
                    this.cbGioiTinh.SelectedIndex = frm.patientGenderCode;
                    this.searchLkupDoctor.EditValue = employeeCodeDoctor;
                    foreach (DataRow r in dtTemp.Rows)
                    {
                        this.dtMedicalRecord_Out.Rows.Add(this.exportCode, r["ItemCode"].ToString(), r["DateOfIssues"].ToString(), r["Morning"].ToString(), r["Noon"].ToString(), r["Afternoon"].ToString(), r["Evening"].ToString(), r["Quantity"].ToString(), r["Instruction"].ToString(), r["UnitPrice"].ToString(), r["Amount"].ToString(), r["UnitOfMeasureCode"].ToString(), this.repositoryCode, r["RepositoryName"].ToString(), r["RateBHYT"].ToString(), r["ItemName"].ToString());
                    }
                    this.ProcessTotalPay();
                    this.TuoiBenhNhan(this.dtimeWorkingDate.ToString("dd/MM/yyyy"), frm.ngaysinh);
                }
                this.butSave.Focus();
            }
            catch { }
        }

        private void gridView_Search_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                Int32 paid = 0;
                if (e.RowHandle >= 0)
                {
                    paid = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, "Paid").ToString());
                    if (paid == 0 || paid == 2)
                    {
                        e.Appearance.ForeColor = Color.DarkOrange;
                    }
                    else if(paid == -1)
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                }
            }
            catch { }
        }

        private void repSearch_Out_ItemCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
                string itemCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ItemCode").ToString();
                string activeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("Active").ToString();
                decimal amountEndTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("AmountEnd").ToString());
                decimal safelyQuantityTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("SafelyQuantity").ToString());
                string unitOfMeasureCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("UnitOfMeasureCode").ToString();
                string repositoryNameTemp = searchEdit.Properties.View.GetFocusedRowCellValue("RepositoryName").ToString();
                string repositoryCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("RepositoryCode").ToString();
                decimal salesPriceTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("SalesPrice").ToString());
                decimal salesPrice_RetailTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("SalesPrice_Retail").ToString());
                Int32 rateBHYTTemp = Convert.ToInt32(searchEdit.Properties.View.GetFocusedRowCellValue("RateBHYT").ToString());
                string itemNameTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ItemName").ToString();
                if (this.isSalesPrice_Retail)
                    salesPriceTemp = salesPrice_RetailTemp;
                DataRow r = Utils.GetPriceRowbyCode(dtMedicalRecord_Out, "ItemCode='" + itemCodeTemp + "'");
                if (bCheckActice)
                {
                    string sErrorActive = string.Empty;
                    List<Items_View> lstActive = new List<Items_View>();
                    if (activeTemp != string.Empty)
                    {
                        lstActive = ItemsBLL.ListItemsForActive(activeTemp, itemCodeTemp, dtMedicalRecord_Out);
                        foreach (var v in lstActive)
                        {
                            sErrorActive += v.ItemName + ":" + v.Active + "\n";
                        }
                        if (sErrorActive != string.Empty)
                        {
                            XtraMessageBox.Show(" Thuốc có hoạt chất trùng với thuốc : \n" + sErrorActive, "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                if (r != null)
                {
                    XtraMessageBox.Show(" Thuốc đã được kê trong toa thuốc!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    gridView_Out.SetFocusedRowCellValue(col_Out_ItemCode, null);
                    gridView_Out.SetFocusedRowCellValue(col_Out_Quantity, 0);
                }
                else
                {
                    if (amountEndTemp <= safelyQuantityTemp)
                    {
                        if (XtraMessageBox.Show(" Số lượng thuốc trong kho sắp hết!\t\n Bạn có muốn tiếp tục cho thuốc ? ", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                        {
                            gridView_Out.SetFocusedRowCellValue(col_Out_UnitOfMeasureCode, unitOfMeasureCodeTemp);
                            gridView_Out.SetFocusedRowCellValue(col_Out_DateOfIssues, 1);
                            gridView_Out.SetFocusedRowCellValue(col_Out_UnitPrice, salesPriceTemp);
                            gridView_Out.SetFocusedRowCellValue(col_Out_RepositoryCode, repositoryCodeTemp);
                            gridView_Out.SetFocusedRowCellValue(col_Out_RepositoryName, repositoryNameTemp);
                            gridView_Out.SetFocusedRowCellValue(col_Out_RateBHYT, rateBHYTTemp);
                            gridView_Out.SetFocusedRowCellValue(col_Out_ItemName, itemNameTemp);
                            gridView_Out.SetFocusedRowCellValue(col_Out_Active, activeTemp);
                        }
                    }
                    else if (amountEndTemp <= 0)
                    {
                        XtraMessageBox.Show(" Thuốc trong kho đã hết!\t\n Xin vui lòng kê thuôc khác ? ", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        gridView_Out.SetFocusedRowCellValue(col_Out_UnitOfMeasureCode, unitOfMeasureCodeTemp);
                        gridView_Out.SetFocusedRowCellValue(col_Out_DateOfIssues, 1);
                        gridView_Out.SetFocusedRowCellValue(col_Out_UnitPrice, salesPriceTemp);
                        gridView_Out.SetFocusedRowCellValue(col_Out_RepositoryCode, repositoryCodeTemp);
                        gridView_Out.SetFocusedRowCellValue(col_Out_RepositoryName, repositoryNameTemp);
                        gridView_Out.SetFocusedRowCellValue(col_Out_RateBHYT, rateBHYTTemp);
                        gridView_Out.SetFocusedRowCellValue(col_Out_ItemName, itemNameTemp);
                        gridView_Out.SetFocusedRowCellValue(col_Out_Active, activeTemp);
                    }
                }
                this.gridControl_Out.DataSource = this.dtMedicalRecord_Out;
            }
            catch (Exception ex){
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void repButHSBA_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.gridView_Search.GetFocusedRowCellValue(this.col_search_PatientCode).ToString()))
            {
                frmKB_HSBA frm = new frmKB_HSBA(this.gridView_Search.GetFocusedRowCellValue(this.col_search_PatientCode).ToString());
                frm.Show();
            }
            else
            {
                XtraMessageBox.Show("Hồ sơ chỉ xem được bệnh nhân đã đến khám và cấp toa.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void repButEditRetail_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.gridView_Search.GetFocusedRowCellValue(this.col_search_RetailCode).ToString()))
            {
                frmCapNhatToaThuocBanLe frm = new frmCapNhatToaThuocBanLe(this.gridView_Search.GetFocusedRowCellValue(this.col_search_RetailCode).ToString(), this.sUserid);
                frm.ShowDialog();
                if (frm.isResult)
                {
                    this.txtHoten.Text = frm.fullname;
                    this.txtNamsinh.Text = frm.birthyear;
                    this.txtDiachi.Text = frm.address;
                    this.txtChandoan.Text = frm.diagnosis;
                    this.txtSothang.Text = frm.numberOfDrugCoal;
                    this.txtSohieu.Text = frm.serialNumber;
                    this.txtSobienlai.Text = frm.invoiceNumber;
                }

            }
        }

        public void InitField()
        {
            this.cbGioiTinh.Properties.Items.AddRange(new string[] { "Nữ", "Nam" });
        }

        private void GetInfoPatient()
        {
            try
            {
                PatientsInf objPatient = PatientsBLL.ObjPatients(this.patientCode, this.dReceiveID);
                if (objPatient != null && objPatient.PatientCode != null)
                {
                    this.txtHoten.Text = objPatient.PatientName;
                    this.txtTuoi.Text = objPatient.PatientAge.ToString();
                    this.txtDiachi.Text = objPatient.PatientAddress + ", " + objPatient.WardName + ", " + objPatient.DistrictName + ", " + objPatient.ProvincialName;
                    this.cbGioiTinh.SelectedIndex = objPatient.PatientGender;
                    this.txtNgaySinh.Text = objPatient.PatientBirthday.ToString("dd/MM/yyyy");
                    this.txtNamsinh.Text = objPatient.PatientBirthyear.ToString();
                    this.txtThang.Text = objPatient.PatientMonth;
                    this.TuoiBenhNhan(string.Empty, this.txtNgaySinh.Text);
                }
                else
                {
                    this.txtHoten.Text = string.Empty;
                    this.txtTuoi.Text = string.Empty;
                    this.txtDiachi.Text = string.Empty;
                    this.cbGioiTinh.SelectedIndex = -1;
                    this.txtNgaySinh.Text = string.Empty;
                    this.txtNamsinh.Text = string.Empty;
                    this.txtThang.Text = string.Empty;
                }
                
            }
            catch { }
        }

        private void TuoiBenhNhan(string ngayvao, string ngaysinh)
        {
            int namht = this.dtimeWorkingDate.Year;
            int thanght = this.dtimeWorkingDate.Month;
            int ngayht = this.dtimeWorkingDate.Day;
            //int gioht = DateTime.Now.Hour;

            int nam = int.Parse(ngaysinh.Substring(6, 4));
            int thang = int.Parse(ngaysinh.Substring(3, 2));
            int ngay = int.Parse(ngaysinh.Substring(0, 2));
            int gio = (ngaysinh.Length > 10) ? int.Parse(ngaysinh.Substring(11, 2)) : 0;
            if (!string.IsNullOrEmpty(ngayvao))
            {
                namht = int.Parse(ngayvao.Substring(6, 4));
                thanght = int.Parse(ngayvao.Substring(3, 2));
                ngayht = int.Parse(ngayvao.Substring(0, 2));
                //gioht = int.Parse(ngayvao.Substring(11, 2));
            }
            int yyyy = namht - nam;
            if (yyyy <= 5)
            {
                DateTime dtNgaySinh = Convert.ToDateTime(this.txtNgaySinh.Text.Trim());
                var sothang = this.dtimeWorkingDate.Month - dtNgaySinh.Month + 12 * (this.dtimeWorkingDate.Year - dtNgaySinh.Year);
                int yy = sothang / 12;
                int mm = sothang % 12;
                this.lbNamSinh.Text = yy + " tuổi " + mm + " tháng.";
                this.txtThang.Text = mm.ToString().PadLeft(2, '0');
                this.txtTuoi.Text = yy.ToString().PadLeft(2, '0');
            }
            else
            {
                this.lbNamSinh.Text = yyyy + " tuổi ";
                this.txtTuoi.Text = yyyy.ToString().PadLeft(2, '0');
                this.txtThang.Text = "00";
            }
            this.txtNamsinh.Text = this.Namsinh(this.txtNgaySinh.Text).ToString();
        }
        public int Namsinh(string ngaysinh)
        {
            return int.Parse(ngaysinh.Substring(6, 4));
        }
        private void PrintVAT()
        {
            try
            {
                double dblTotalRealTemp = 0;
                DataTable dtResult = new DataTable("ResultMedicinesRetail");
                dtResult = MedicinesRetailBLL.rpt_MedicinesRetail(this.exportCode, 1);
                if (dtResult.Rows.Count > 0)
                {
                    DataSet dsTemp = new DataSet("Result");
                    DataTable dtResultDetail = new DataTable("Detail");
                    dtResultDetail = MedicinesRetailBLL.rpt_MedicinesRetailDetail(this.exportCode);
                    dsTemp.Tables.Add(dtResult);
                    if (dtResultDetail != null && dtResultDetail.Rows.Count > 0)
                    {
                        dsTemp.Tables.Add(dtResultDetail);
                    }
                    dblTotalRealTemp = Convert.ToDouble(dtResult.Rows[0]["TotalAmountRealVAT"].ToString());
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptToaThuocBanLeVAT.xml");
                    string prNgayIn = string.Empty, prThangIn = string.Empty, prNamIn = string.Empty;
                    prNgayIn = dtResult.Rows[0]["ExportDate"].ToString().Substring(0, 2);
                    prThangIn = dtResult.Rows[0]["ExportDate"].ToString().Substring(3, 2);
                    prNamIn = dtResult.Rows[0]["ExportDate"].ToString().Substring(6, 4);

                    Reports.rptTH_InvoiceA5 rptShow = new Reports.rptTH_InvoiceA5();
                    rptShow.Parameters["prNgayIn"].Value = dtResult.Rows[0]["ExportDate"].ToString().Substring(0, 2);
                    rptShow.Parameters["prThangIn"].Value = dtResult.Rows[0]["ExportDate"].ToString().Substring(3, 2);
                    rptShow.Parameters["prNamIn"].Value = dtResult.Rows[0]["ExportDate"].ToString().Substring(6, 4);
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "ToaThuoc","Toa thuốc");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Toa thuốc không tồn tại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
        }
    }
}