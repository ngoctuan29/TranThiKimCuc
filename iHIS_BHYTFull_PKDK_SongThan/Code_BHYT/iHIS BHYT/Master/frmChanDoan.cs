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
    public partial class frmChanDoan : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmChanDoan()
        {
            InitializeComponent();
        }

        private void frmChanDoan_Load(object sender, EventArgs e)
        {
            gridControl_ICD.DataSource = DiagnosisBLL.DTDiagnosis(0);
        }

        private void gridView_ICD_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView_ICD.RowCount > 0)
            {
                if (gridView_ICD.GetFocusedRow() != null)
                {
                    if (e.KeyValue == 46)
                    {
                        if (XtraMessageBox.Show("Bạn có muốn xóa chẩn đoán đang chọn hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                        {
                            try
                            {
                                GridView view = sender as GridView;
                                string icdName = view.GetFocusedRowCellValue(col_ICDName).ToString();
                                decimal dRowid = decimal.Parse(view.GetFocusedRowCellValue(col_RowID).ToString());
                                if (DiagnosisBLL.DelDiagnosis(dRowid) == 1)
                                {
                                    gridView_ICD.DeleteSelectedRows();
                                    XtraMessageBox.Show("Đã xóa chẩn đoán : " + icdName.ToUpper(), "Bệnh viện điện tử .NET");
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

        private void gridView_ICD_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_ICDName)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_ICDName, "Nhập tên - nội dung chẩn đoán !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_DiagnosisCode)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_ICDName, "Nhập mã ICD-10 chẩn đoán !");
                }
                if (e.Valid)
                {
                    DiagnosisInf inf = new DiagnosisInf();
                    if (!string.IsNullOrEmpty(gridView_ICD.GetRowCellValue(e.RowHandle, "RowID").ToString()))
                        inf.RowID = Int32.Parse(gridView_ICD.GetRowCellValue(e.RowHandle, "RowID").ToString());
                    else
                        inf.RowID = 0;
                    inf.DiagnosisName = gridView_ICD.GetRowCellValue(e.RowHandle, "DiagnosisName").ToString();
                    inf.DiagnosisCode = gridView_ICD.GetRowCellValue(e.RowHandle, "DiagnosisCode").ToString();
                    if (e.RowHandle < 0)
                    {
                        if (DiagnosisBLL.InsDiagnosis(inf) == 1)
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
                        if (DiagnosisBLL.InsDiagnosis(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật thành công!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật không thành công!", "Bệnh viện điện tử .NET");
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void gridView_ICD_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo chẩn đoán bệnh !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridControl_ICD_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gridView_ICD.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa chẩn đoán bệnh này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                    {
                        try
                        {
                            if (DiagnosisBLL.DelDiagnosis(decimal.Parse(gridView_ICD.GetRowCellValue(gridView_ICD.FocusedRowHandle, "RowID").ToString())) == 1)
                                gridView_ICD.DeleteSelectedRows();
                            //dt.Rows.RemoveAt(gridView_ServiceGroup.FocusedRowHandle);
                        }
                        catch { return; }
                    }
                }
            }
            catch { }
        }
    }
}