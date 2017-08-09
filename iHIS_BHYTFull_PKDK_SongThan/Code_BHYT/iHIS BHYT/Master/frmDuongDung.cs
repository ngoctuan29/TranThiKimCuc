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
    public partial class frmDuongDung : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmDuongDung()
        {
            InitializeComponent();
        }

        private void frmDuongDung_Load(object sender, EventArgs e)
        {
            this.GetData();
            this.repSchLKup_UsageBHYT.DataSource = UsageBLL.DataUsageBHYT();
            this.repSchLKup_UsageBHYT.ValueMember = "UsageCode";
            this.repSchLKup_UsageBHYT.DisplayMember = "UsageName";
        }

        private void gridView_Usage_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo đường dùng của thuốc, vtyt !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Usage_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(view.GetRowCellValue(rowfocus, this.col_UsageName).ToString()))
                {
                    e.Valid = false;
                    view.SetColumnError(this.col_UsageName, "Tên đường dùng của thuốc, vtyt không được để trống!");
                }
                if (string.IsNullOrEmpty(view.GetRowCellValue(rowfocus, this.col_BHYT_MaDuongDung).ToString()))
                {
                    e.Valid = false;
                    view.SetColumnError(this.col_BHYT_MaDuongDung, "Nhập mã đường dùng theo danh mục bộ y tế!");
                }
                if (e.Valid)
                {
                    UsageInf inf = new UsageInf();
                    inf.UsageCode = gridView_Usage.GetRowCellValue(e.RowHandle, "UsageCode").ToString();
                    inf.UsageName = gridView_Usage.GetRowCellValue(e.RowHandle, "UsageName").ToString();
                    inf.STT = gridView_Usage.GetRowCellValue(e.RowHandle, "STT") == null ? 1 : Convert.ToInt32(gridView_Usage.GetRowCellValue(e.RowHandle, "STT").ToString());
                    inf.BHYT_MaDuongDung = gridView_Usage.GetRowCellValue(e.RowHandle, "BHYT_MaDuongDung") == null ? string.Empty : gridView_Usage.GetRowCellValue(e.RowHandle, "BHYT_MaDuongDung").ToString();
                    if (e.RowHandle < 0)
                    {
                        if (UsageBLL.InsUsage(inf) == 1)
                        {
                            XtraMessageBox.Show("Thêm thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.GetData();
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.gridView_Usage.DeleteRow(rowfocus);
                        }
                    }
                    else
                    {
                        if (UsageBLL.InsUsage(inf) == 1)
                            XtraMessageBox.Show("Cập nhật thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            XtraMessageBox.Show("Cập nhật thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.GetData();
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: "+ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void GetData()
        {
            this.gridControl_Usage.DataSource = UsageBLL.DTUsageList(string.Empty);
        }
        private void gridControl_Usage_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && this.gridView_Usage.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa đường dùng này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        if (UsageBLL.DelUsage(this.gridView_Usage.GetRowCellValue(this.gridView_Usage.FocusedRowHandle, "UsageCode").ToString()) == 1)
                            this.GetData();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}