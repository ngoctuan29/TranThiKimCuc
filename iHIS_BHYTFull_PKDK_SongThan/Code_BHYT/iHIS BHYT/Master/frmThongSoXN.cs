using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
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

namespace Ps.Clinic.Master
{
    public partial class frmThongSoXN : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Int32 iRowID = 0;
        public frmThongSoXN()
        {
            InitializeComponent();
        }

        private void frmThongSoXN_Load(object sender, EventArgs e)
        {
            gridControl_Laboratory.DataSource = LaboratoryBLL.DT_Laboratory(0);
        }

        private void gridView_Laboratory_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView_Laboratory.RowCount > 0)
            {
                if (gridView_Laboratory.GetFocusedRow() != null)
                {
                    if (e.KeyValue == 46)
                    {
                        if (XtraMessageBox.Show("Bạn có muốn xóa thông số xét nghiệm đang chọn hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                        {
                            try
                            {
                                if (LaboratoryBLL.Del(Convert.ToInt32(gridView_Laboratory.GetRowCellValue(gridView_Laboratory.FocusedRowHandle, "RowID").ToString())) >= 1)
                                    gridControl_Laboratory.DataSource = LaboratoryBLL.DT_Laboratory(0);
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

        private void gridView_Laboratory_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_LaboratoryName)).ToString() == string.Empty)
                {
                    XtraMessageBox.Show(" Chưa nhập đơn vị đo xét nghiệm, vtye ! \t\nHãy thử lại.", "Bệnh viện điện tử .NET");
                    return;
                }
                else
                {
                    if ((view.GetRowCellValue(rowfocus, col_RowID)).ToString() != string.Empty)
                        iRowID = Convert.ToInt32((view.GetRowCellValue(rowfocus, col_RowID)).ToString());
                    var unit = new LaboratoryInf
                    {
                        RowID = iRowID,
                        LaboratoryName = view.GetRowCellValue(rowfocus, col_LaboratoryName).ToString(),
                    };
                    if (LaboratoryBLL.Ins(unit) >= 1)
                    {
                        gridControl_Laboratory.DataSource = LaboratoryBLL.DT_Laboratory(0);
                    }
                    else
                    {
                        XtraMessageBox.Show(" Cập nhật đơn vị đo xét nghiệm thất bại ! \t\nHãy thử lại.", "Bệnh viện điện tử .NET");
                        return;
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show(" Lỗi cập nhật danh mục thông số xét nghiệm, vtye ! \t\nHãy thử lại.", "Bệnh viện điện tử .NET");
                this.Close();
            }
        }
    }
}