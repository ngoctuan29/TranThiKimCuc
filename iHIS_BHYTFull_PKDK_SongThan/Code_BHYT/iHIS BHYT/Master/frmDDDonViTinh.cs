using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Data.Linq;
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
    public partial class frmDDDonViTinh : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Int32 iRowID = 0;
        public frmDDDonViTinh()
        {
            InitializeComponent();
        }

        private void frmDDDonViTinh_Load(object sender, EventArgs e)
        {
            gridControl_Unit.DataSource = UnitOfRawBLL.DT_UnitOfRaw(0);
        }

        private void gridView_Unit_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView_Unit.RowCount > 0)
            {
                if (gridView_Unit.GetFocusedRow() != null)
                {
                    if (e.KeyValue == 46)
                    {
                        if (XtraMessageBox.Show(" Bạn có muốn xóa đơn vị tính đang chọn hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                        {
                            try
                            {
                                GridView view = sender as GridView;
                                if (UnitOfRawBLL.Del(Int32.Parse(gridView_Unit.GetRowCellValue(gridView_Unit.FocusedRowHandle, "UnitOfRawID").ToString())) >= 1)
                                    gridView_Unit.DeleteSelectedRows();
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

       
        private void gridView_Unit_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_UnitOfRawName)).ToString() == string.Empty)
                {
                    XtraMessageBox.Show(" Chưa nhập đơn vị tính cần khai báo! \t\nHãy thử lại.", "Bệnh viện điện tử .NET");
                    return;
                }
                else
                {
                    if ((view.GetRowCellValue(rowfocus, col_UnitOfRawID)).ToString() != string.Empty)
                        iRowID = Convert.ToInt32((view.GetRowCellValue(rowfocus, col_UnitOfRawID)).ToString());
                    else
                        iRowID = 0;
                    var unit = new UnitOfRawINF
                    {
                        UnitOfRawID = iRowID,
                        UnitOfRawName = view.GetRowCellValue(rowfocus, col_UnitOfRawName).ToString(),
                    };
                    if (UnitOfRawBLL.Ins(unit) >= 1)
                    {
                        XtraMessageBox.Show(" Cập nhật đơn vị tính thành công ! ", "Bệnh viện điện tử .NET");
                        gridControl_Unit.DataSource = UnitOfRawBLL.DT_UnitOfRaw(0);
                        return;
                        
                    }
                    else
                    {
                        XtraMessageBox.Show(" Thêm đơn vị tính thất bại ! \t\n Hãy thử lại.", "Bệnh viện điện tử .NET");
                        gridView_Unit.DeleteSelectedRows();
                        return;
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show("Lỗi cập nhật danh mục đơn vị tính nguyên liệu! \t\nHãy thử lại.", "Bệnh viện điện tử .NET");
                this.Close();
            }
        }

        private void gridView_Unit_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = " Bạn nhập thiếu thông tin khi khai báo đơn vị tính nguyên liệu!.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n ";
        }
    }
}