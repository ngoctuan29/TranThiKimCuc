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
    public partial class frmTrieuChung : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmTrieuChung()
        {
            InitializeComponent();
        }

        private void frmTrieuChung_Load(object sender, EventArgs e)
        {
            gridControl_Symptom.DataSource = SymptomsBLL.DTSymptoms(0);
        }

        private void gridView_Symptoms_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo triệu chứng bệnh !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Symptoms_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView_Symptoms.RowCount > 0)
            {
                if (gridView_Symptoms.GetFocusedRow() != null)
                {
                    if (e.KeyValue == 46)
                    {
                        if (XtraMessageBox.Show("Bạn có muốn xóa triệu chứng đang chọn hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                        {
                            try
                            {
                                GridView view = sender as GridView;
                                string sName = view.GetFocusedRowCellValue(col_SymptomsName).ToString();
                                decimal dRowid = decimal.Parse(view.GetFocusedRowCellValue(col_RowID).ToString());
                                if (SymptomsBLL.DelSymptoms(dRowid) == 1)
                                {
                                    gridView_Symptoms.DeleteSelectedRows();
                                    XtraMessageBox.Show("Đã xóa triệu chứng : " + sName.ToUpper(), "Bệnh viện điện tử .NET");
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

        private void gridView_Symptoms_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_SymptomsName)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_SymptomsName, "Nhập tên - nội dung triệu chứng bệnh !");
                }
                if (e.Valid)
                {
                    SymptomsInf inf = new SymptomsInf();
                    if (gridView_Symptoms.GetRowCellValue(e.RowHandle, "RowID").ToString() != "")
                        inf.RowID = Int32.Parse(gridView_Symptoms.GetRowCellValue(e.RowHandle, "RowID").ToString());
                    else
                        inf.RowID = 0;
                    inf.SymptomsName = gridView_Symptoms.GetRowCellValue(e.RowHandle, "SymptomsName").ToString();
                    if (e.RowHandle < 0)
                    {
                        if (SymptomsBLL.InsSymptoms(inf) == 1)
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
                        if (SymptomsBLL.InsSymptoms(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật thành công!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật không thành công!", "Bệnh viện điện tử .NET");
                        }
                    }
                    gridControl_Symptom.DataSource = SymptomsBLL.DTSymptoms(0);
                }
            }
            catch (Exception) { }
        }

        

        private void gridControl_Symptom_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gridView_Symptoms.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa triệu chứng đang chọn hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                    {
                        try
                        {
                            if (SymptomsBLL.DelSymptoms(decimal.Parse(gridView_Symptoms.GetRowCellValue(gridView_Symptoms.FocusedRowHandle, "RowID").ToString())) == 1)
                                gridView_Symptoms.DeleteSelectedRows();
                        }
                        catch { return; }
                    }
                }
            }
            catch { }
        }
    }
}