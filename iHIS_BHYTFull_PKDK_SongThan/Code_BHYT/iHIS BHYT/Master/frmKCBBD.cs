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
    public partial class frmKCBBD : DevExpress.XtraEditors.XtraForm
    {
        private string employeeCode = string.Empty;
        public frmKCBBD(string _employeeCode)
        {
            this.employeeCode = _employeeCode;
            InitializeComponent();
        }

        private void frmKCBBD_Load(object sender, EventArgs e)
        {
            try
            {
                this.gridControl_Main.DataSource = KCBBDBLL.DTKCBBD_List(string.Empty);
                this.repSearchProvincialIDBHYT.DataSource = CatalogProvincialBLL.DTListProvincialForBHYT(string.Empty);
                this.repSearchProvincialIDBHYT.DisplayMember = "ProvincialName";
                this.repSearchProvincialIDBHYT.ValueMember = "ProvincialIDBHYT";
            }
            catch {  }
        }

        private void gridView_Main_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh Viện Điện Tử .Net";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo nơi đăng ký KCB BĐ!.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Main_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_KCBBDName)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_KCBBDCode, "Mã ĐK KCB BĐ chưa nhập.");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_KCBBDCode)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_KCBBDCode, "Tên ĐK KCB BĐ chưa nhập.");
                }
                if (string.IsNullOrEmpty(view.GetRowCellValue(rowfocus, col_ProvincialIDBHYT).ToString()))
                {
                    e.Valid = false;
                    view.SetColumnError(col_ProvincialIDBHYT, "Chọn tỉnh tham gia BHYT.");
                }
                if (e.Valid == true)
                {
                    KCBBDInf inf = new KCBBDInf();
                    if (this.gridView_Main.GetRowCellValue(e.RowHandle, "RowID").ToString() != "")
                        inf.RowID = decimal.Parse(this.gridView_Main.GetRowCellValue(e.RowHandle, "RowID").ToString());
                    else
                        inf.RowID = 0;
                    inf.KCBBDCode = this.gridView_Main.GetRowCellValue(e.RowHandle, "KCBBDCode").ToString();
                    inf.KCBBDName = this.gridView_Main.GetRowCellValue(e.RowHandle, "KCBBDName").ToString();
                    inf.ProvincialIDBHYT = this.gridView_Main.GetRowCellValue(e.RowHandle, "ProvincialIDBHYT").ToString();
                    inf.TT = Convert.ToInt32(this.gridView_Main.GetRowCellValue(e.RowHandle, "TT").ToString());
                    if (e.RowHandle < 0)
                    {
                        if (KCBBDBLL.InsKCBBD(inf) == 1)
                        {
                            XtraMessageBox.Show("Thêm thành công!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm thất bại!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (KCBBDBLL.InsKCBBD(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật thành công!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật không thành công!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    this.gridControl_Main.DataSource = KCBBDBLL.DTKCBBD_List(string.Empty);
                }
            }
            catch (Exception) { }
        }

        private void gridControl_Main_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_Main.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa nơi ĐK KCB BĐ này hay không?", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        if (KCBBDBLL.DelKCBBD(decimal.Parse(gridView_Main.GetRowCellValue(gridView_Main.FocusedRowHandle, "RowID").ToString())) == 1)
                            this.gridControl_Main.DataSource = KCBBDBLL.DTKCBBD_List(string.Empty);
                    }
                    catch { return; }
                }
            }
        }
    }
}