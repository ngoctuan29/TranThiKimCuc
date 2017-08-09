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
using DevExpress.XtraGrid.Views.Grid;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
namespace Ps.Clinic.Master
{
    public partial class frmHangSanXuat : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string sUser = string.Empty;
        public frmHangSanXuat(string _User)
        {
            InitializeComponent();
            this.sUser = _User;
        }

        private void frmHangSanXuat_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            this.gridControl_Producer.DataSource = Producer_BLL.DTProducer(string.Empty);
        }
        private void gridView_Producer_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo hãng sản xuất!.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Producer_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, col_ProducerName)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(col_ProducerName, "Tên hãng sản xuất không được để trống !");
                }
                if (e.Valid)
                {
                    Producer_INF inf = new Producer_INF();
                    inf.ProducerCode = gridView_Producer.GetRowCellValue(e.RowHandle, "ProducerCode").ToString();
                    inf.ProducerName = gridView_Producer.GetRowCellValue(e.RowHandle, "ProducerName").ToString();
                    if (gridView_Producer.GetRowCellValue(e.RowHandle, "Hide").ToString() != "")
                        inf.Hide = int.Parse(gridView_Producer.GetRowCellValue(e.RowHandle, "Hide").ToString());
                    else
                        inf.Hide = 0;
                    if (e.RowHandle < 0)
                    {
                        if (Producer_BLL.Ins(inf) == 1)
                            XtraMessageBox.Show("Thêm thành công hãng sản xuất!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            XtraMessageBox.Show("Thêm hãng sản xuất thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        if (Producer_BLL.Ins(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật hãng sản xuất thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật hãng sản xuất thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    this.LoadData();
                }

            }
            catch (Exception) { }
        }

        private void gridControl_Producer_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gridView_Producer.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa hãng sản xuất này?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        if (Producer_BLL.Del(gridView_Producer.GetRowCellValue(gridView_Producer.FocusedRowHandle, "ProducerCode").ToString()) == 1)
                            this.LoadData();
                    }
                }
            }
            catch { return; }
        }
    }
}