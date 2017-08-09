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
    public partial class frmDonViTinh : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string type = string.Empty;
        public frmDonViTinh(string _type)
        {
            InitializeComponent();
            this.type = _type;
        }

        private void frmDonViTinh_Load(object sender, EventArgs e)
        {
            this.gridControl_Price.DataSource = UnitOfMeasureBLL.DTUnit(string.Empty, type);
        }
        
        private void gridView_Unit_Of_Measure_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo ĐVT thuốc, vtyt !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Unit_Of_Measure_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_UnitOfMeasureName)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_UnitOfMeasureName, " Tên ĐVT thuốc, vtyt không được để trống ! ");
                }
                if (e.Valid)
                {
                    UnitOfMeasureInf inf = new UnitOfMeasureInf();
                    inf.UnitOfMeasureCode = gridView_Unit_Of_Measure.GetRowCellValue(e.RowHandle, "UnitOfMeasureCode").ToString();
                    inf.UnitOfMeasureName = gridView_Unit_Of_Measure.GetRowCellValue(e.RowHandle, "UnitOfMeasureName").ToString();
                    inf.Type = this.type;
                    if (e.RowHandle < 0)
                    {
                        if (UnitOfMeasureBLL.InsUnit(inf) == 1)
                        {
                            XtraMessageBox.Show(" Khai báo đơn vị tính thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show(" Khai báo thất bại! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            gridView_Unit_Of_Measure.DeleteRow(rowfocus);
                        }
                    }
                    else
                    {
                        if (UnitOfMeasureBLL.InsUnit(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật đơn vị tính thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                this.gridControl_Price.DataSource = UnitOfMeasureBLL.DTUnit(string.Empty, this.type);
            }
            catch (Exception) { }
        }

        private void gridControl_Unit_Of_Measure_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_Unit_Of_Measure.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa đơn vị tính này?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        if (UnitOfMeasureBLL.DelUnit(gridView_Unit_Of_Measure.GetRowCellValue(gridView_Unit_Of_Measure.FocusedRowHandle, "UnitOfMeasureCode").ToString()) == 1)
                            this.gridView_Unit_Of_Measure.DeleteSelectedRows();
                        else
                        {
                            XtraMessageBox.Show(" Đơn vị tính đã được sử dụng! Không được xóa.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    catch { return; }
                }
            }
        }

    }
}