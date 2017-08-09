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
    public partial class frmMauKQXN : DevExpress.XtraEditors.XtraForm
    {
        public frmMauKQXN()
        {
            InitializeComponent();
        }

        private void frmMauKQXN_Load(object sender, EventArgs e)
        {
            gridControl_LaboratoryResult.DataSource = LaboratoryResultDescriptionBLL.DT_LabResultDescription();
        }

        
        private void gridView_LaboratoryResult_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_laboratory_DescriptionResult)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_laboratory_DescriptionResult, "Nhập tên - nội dung mô tả kết quả!");
                }
                if (e.Valid)
                {
                    LaboratoryResultDescriptionInf inf = new LaboratoryResultDescriptionInf();
                    if (this.gridView_LaboratoryResult.GetRowCellValue(e.RowHandle, "RowID").ToString() != "")
                        inf.RowID = Int32.Parse(gridView_LaboratoryResult.GetRowCellValue(e.RowHandle, "RowID").ToString());
                    else
                        inf.RowID = 0;
                    inf.DescriptionResult = gridView_LaboratoryResult.GetRowCellValue(e.RowHandle, "DescriptionResult").ToString();
                    if (e.RowHandle < 0)
                    {
                        if (LaboratoryResultDescriptionBLL.InsResultDescription(inf) == 1)
                        {
                            this.gridControl_LaboratoryResult.DataSource = LaboratoryResultDescriptionBLL.DT_LabResultDescription();
                        }
                        else
                        {
                            XtraMessageBox.Show(" Khai báo kết quả thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.gridView_LaboratoryResult.DeleteRow(rowfocus);
                        }
                    }
                    else
                    {
                        if (LaboratoryResultDescriptionBLL.UpdResultDescription(inf) == 1)
                        {
                            this.gridControl_LaboratoryResult.DataSource = LaboratoryResultDescriptionBLL.DT_LabResultDescription();
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật kết quả thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void gridView_LaboratoryResult_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo mô tả kết quả!.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_LaboratoryResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView_LaboratoryResult.RowCount > 0)
            {
                if (gridView_LaboratoryResult.GetFocusedRow() != null)
                {
                    if (e.KeyValue == 46)
                    {
                        if (XtraMessageBox.Show("Bạn có muốn xóa mô tả kết quả đang chọn hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                        {
                            try
                            {
                                GridView view = sender as GridView;
                                Int32 iRowID = Convert.ToInt32(view.GetFocusedRowCellValue(col_laboratory_RowID).ToString());
                                string sName = view.GetFocusedRowCellValue(col_laboratory_DescriptionResult).ToString();
                                if (LaboratoryResultDescriptionBLL.DelResultDescription(iRowID) >= 1)
                                {
                                    this.gridView_LaboratoryResult.DeleteSelectedRows();
                                    //XtraMessageBox.Show("Đã xóa mô tả kết quả: " + sName.ToUpper(), "Bệnh viện điện tử .NET");
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
    }
}