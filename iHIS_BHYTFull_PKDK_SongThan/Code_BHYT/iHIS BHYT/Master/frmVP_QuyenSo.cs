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
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Master
{
    public partial class frmVP_QuyenSo : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string employeeCode = string.Empty, shiftWork = string.Empty;
        
        public frmVP_QuyenSo(string _employeeCode, string _shiftWork)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
            this.shiftWork = _shiftWork;
        }

        private void frmVP_QuyenSo_Load(object sender, EventArgs e)
        {
            this.LoadData();
            List<NoteType> lstType = new List<NoteType>();
            NoteType obj1 = new NoteType { ID = 0, Name = "Tạm Ứng" };
            NoteType obj2 = new NoteType { ID = 1, Name = "Viện Phí" };
            lstType.Add(obj1);
            lstType.Add(obj2);
            this.repLKup_NoteType.DataSource = lstType;
            this.repLKup_NoteType.DisplayMember = "Name";
            this.repLKup_NoteType.ValueMember = "ID";
        }
        
        private void LoadData()
        {
            this.gridControl.DataSource = Fee_NoteBookBLL.TableListNoteBookALL();
        }

        private void gridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(view.GetRowCellValue(rowfocus, this.col_Symbol).ToString()))
                {
                    e.Valid = false;
                    view.SetColumnError(this.col_Symbol, "Nhập ký hiệu quyển sổ! ");
                }
                if (string.IsNullOrEmpty(view.GetRowCellValue(rowfocus, this.col_NoteBookName).ToString()))
                {
                    e.Valid = false;
                    view.SetColumnError(this.col_NoteBookName, "Nhập tên quyển sổ! ");
                }
                if (Convert.ToInt32(view.GetRowCellValue(rowfocus, this.col_ToNumber).ToString()) < Convert.ToInt32(view.GetRowCellValue(rowfocus, this.col_FromNumber).ToString()))
                {
                    e.Valid = false;
                    view.SetColumnError(this.col_ToNumber, "Số hoá đơn không hợp lệ! ");
                }
                if (Convert.ToInt32(view.GetRowCellValue(rowfocus, this.col_WriteNumber).ToString()) > Convert.ToInt32(view.GetRowCellValue(rowfocus, this.col_ToNumber).ToString()))
                {
                    e.Valid = false;
                    view.SetColumnError(this.col_WriteNumber, "Số hoá đơn không hợp lệ! ");
                }
                if (e.Valid)
                {
                    Fee_NoteBookInf inf = new Fee_NoteBookInf();
                    if (!string.IsNullOrEmpty(this.gridView.GetRowCellValue(e.RowHandle, "RowID").ToString()))
                        inf.RowID = Int32.Parse(this.gridView.GetRowCellValue(e.RowHandle, "RowID").ToString());
                    else
                        inf.RowID = 0;
                    inf.Symbol = this.gridView.GetRowCellValue(e.RowHandle, "Symbol").ToString();
                    inf.NoteBookName = this.gridView.GetRowCellValue(e.RowHandle, "NoteBookName").ToString();
                    inf.FromNumber = Convert.ToInt32(this.gridView.GetRowCellValue(e.RowHandle, "FromNumber").ToString());
                    inf.ToNumber = Convert.ToInt32(this.gridView.GetRowCellValue(e.RowHandle, "ToNumber").ToString());
                    inf.WriteNumber = Convert.ToInt32(this.gridView.GetRowCellValue(e.RowHandle, "WriteNumber").ToString());
                    inf.NoteType = Convert.ToInt32(this.gridView.GetRowCellValue(e.RowHandle, "NoteType").ToString());
                    inf.Hide = string.IsNullOrEmpty(this.gridView.GetRowCellValue(e.RowHandle, "Hide").ToString()) ? 0 : Convert.ToInt32(this.gridView.GetRowCellValue(e.RowHandle, "Hide").ToString());
                    inf.ShiftWork = this.shiftWork;
                    inf.EmployeeCode = this.employeeCode;
                    inf.EmployeeCodeUpd = inf.RowID > 0 ? this.employeeCode : string.Empty;
                    inf.UDate = inf.RowID > 0 ? Utils.DateTimeServer().ToString("dd/MM/yyyy HH:mm") : string.Empty;
                    if (e.RowHandle < 0)
                    {
                        if (Fee_NoteBookBLL.InsFee_NoteBook(inf))
                        {
                            XtraMessageBox.Show("Thêm thành công quyển sổ!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadData();
                        }
                        else
                            XtraMessageBox.Show("Thêm quyển sổ không thành công! Vui lòng kiểm tra lại thông tin quyển sổ.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (Fee_NoteBookBLL.InsFee_NoteBook(inf))
                        {
                            XtraMessageBox.Show("Cập nhật thành công quyển sổ!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadData();
                        }
                        else
                            XtraMessageBox.Show("Cập nhật quyển sổ không thành công! Vui lòng kiểm tra lại thông tin quyển sổ.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khai báo quyển sổ !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridControl_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gridView.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa quyển sổ đang chọn?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        if (Fee_NoteBookBLL.DelFee_NoteBook(Convert.ToInt32(this.gridView.GetRowCellValue(gridView.FocusedRowHandle, "RowID").ToString())))
                            this.LoadData();
                        else
                            XtraMessageBox.Show("Quyển sổ đang được sử dụng! Không được phép xoá.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private class NoteType
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

    }
}