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
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraGrid.Views.Grid;

namespace Ps.Clinic.Master
{
    public partial class frmTiLeBHYT : DevExpress.XtraEditors.XtraForm
    {
        private string employeeCode = string.Empty;
        public frmTiLeBHYT(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }

        private void frmTiLeBHYT_Load(object sender, EventArgs e)
        {
            try
            {
                this.gridControl_Object.DataSource = RateBHYTBLL.DT_ListRateBHYT();
            }
            catch {  }
        }

        private void gridView_Object_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khai báo tỉ lệ hưởng BHYT!.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Object_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_RateCard)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_RateCard, "Mã thẻ không được để trống!");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_RateTrue)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_RateCard, "Tỉ lệ đúng tuyến không được để trống!");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_RateFalse)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_RateCard, "Tỉ lệ trái tuyến không được để trống!");
                }
                if (e.Valid == true)
                {
                    RateBHYTInf inf = new RateBHYTInf();
                    inf.RateCard = gridView_Object.GetRowCellValue(e.RowHandle, "RateCard").ToString();
                    if (gridView_Object.GetRowCellValue(e.RowHandle, "RateTrue").ToString() != "")
                        inf.RateTrue = int.Parse(gridView_Object.GetRowCellValue(e.RowHandle, "RateTrue").ToString());
                    else
                        inf.RateTrue = 0;
                    if (gridView_Object.GetRowCellValue(e.RowHandle, "RateFalse").ToString() != "")
                        inf.RateFalse = int.Parse(gridView_Object.GetRowCellValue(e.RowHandle, "RateFalse").ToString());
                    else
                        inf.RateFalse = 0;
                    if (e.RowHandle < 0)
                    {
                        if (RateBHYTBLL.InsRate(inf) == 1)
                        {
                            XtraMessageBox.Show("Thêm thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadData();
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (RateBHYTBLL.InsRate(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadData();
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void LoadData()
        {
            this.gridControl_Object.DataSource = RateBHYTBLL.DT_ListRateBHYT();
        }

        private void gridControl_Object_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gridView_Object.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa tỉ lệ này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        try
                        {
                            if (RateBHYTBLL.DelRate(this.gridView_Object.GetRowCellValue(this.gridView_Object.FocusedRowHandle, "RateCard").ToString()) == 1)
                                this.LoadData();
                        }
                        catch { return; }
                    }
                }
            }
            catch { }
        }
    }
}