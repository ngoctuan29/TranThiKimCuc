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
using DevExpress.XtraGrid.Views.Grid;
using ClinicLibrary;
using ClinicBLL;
using ClinicModel;

namespace Ps.Clinic.Master
{
    public partial class frmLoiDan : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmLoiDan()
        {
            InitializeComponent();
        }

        private void frmLoiDan_Load(object sender, EventArgs e)
        {
            gridControl_Advice.DataSource = AdvicesBLL.DTAdvices(0);
        }

        private void gridView_Advice_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_Advice_Name)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Advice_Name, "Nhập tên - nội dung lời dặn !");
                }
                if (e.Valid)
                {
                    AdvicesInf inf = new AdvicesInf();
                    if (gridView_Advice.GetRowCellValue(e.RowHandle, "RowID").ToString() != "")
                        inf.RowID = Int32.Parse(gridView_Advice.GetRowCellValue(e.RowHandle, "RowID").ToString());
                    else
                        inf.RowID = 0;
                    inf.AdvicesName = gridView_Advice.GetRowCellValue(e.RowHandle, "AdvicesName").ToString();
                    if (e.RowHandle < 0)
                    {
                        if (AdvicesBLL.InsAdvices(inf) == 1)
                        {
                            XtraMessageBox.Show("Thêm thành công!", "Bệnh viện điện tử .NET");

                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm thất bại!", "Bệnh viện điện tử .NET");
                        }
                    }
                    else
                    {
                        if (AdvicesBLL.InsAdvices(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật thành công!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật không thành công!", "Bệnh viện điện tử .NET");
                        }
                    }
                    gridControl_Advice.DataSource = AdvicesBLL.DTAdvices(0);
                }
            }
            catch (Exception) {

            }
        }

        private void gridView_Advice_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo lời dặn !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Advice_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView_Advice.RowCount > 0)
            {
                if (gridView_Advice.GetFocusedRow() != null)
                {
                    if (e.KeyValue == 46)
                    {
                        if (XtraMessageBox.Show("Bạn có muốn xóa lời dặn đang chọn hay không ?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                        {
                            try
                            {
                                GridView view = sender as GridView;
                                decimal dRowid = decimal.Parse(view.GetFocusedRowCellValue(col_RowID).ToString());
                                string adviceName = view.GetFocusedRowCellValue(col_Advice_Name).ToString();
                                gridView_Advice.DeleteSelectedRows();
                                if (AdvicesBLL.DelAdvices(dRowid) == 1)
                                {
                                    gridView_Advice.DeleteSelectedRows();
                                    XtraMessageBox.Show("Đã xóa lời dặn : " + adviceName.ToUpper(), "Bệnh viện điện tử .NET");
                                }
                            }
                            catch { return; }
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

        private void gridControl_Advice_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gridView_Advice.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa lời dặn đang chọn hay không ?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                    {
                        try
                        {
                            if (AdvicesBLL.DelAdvices(decimal.Parse(gridView_Advice.GetRowCellValue(gridView_Advice.FocusedRowHandle, "RowID").ToString())) == 1)
                                gridView_Advice.DeleteSelectedRows();
                        }
                        catch { return; }
                    }
                }
            }
            catch { }
        }
    }
}