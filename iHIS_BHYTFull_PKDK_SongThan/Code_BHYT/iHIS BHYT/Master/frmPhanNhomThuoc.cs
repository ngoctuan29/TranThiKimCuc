using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ClinicBLL;
using ClinicModel;
namespace Ps.Clinic.Master
{
    public partial class frmPhanNhomThuoc : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataTable dt = new DataTable();
        public frmPhanNhomThuoc()
        {
            InitializeComponent();
        }

        private void frmPhanNhomThuoc_Load(object sender, EventArgs e)
        {
            rep_ServiceModule.DataSource = ServiceModuleBLL.DTListServiceModule("");
            rep_ServiceModule.ValueMember = "ServiceModuleCode";
            rep_ServiceModule.DisplayMember = "ServiceModuleName";

            repGroupID_BHYT.DataSource = Catalog_BHYTBLL.TableServiceGroup_BHYT();
            repGroupID_BHYT.ValueMember = "GroupID";
            repGroupID_BHYT.DisplayMember = "GroupName";

            gridControl_ServiceGroup.DataSource = ItemGroupBLL.DTListItemGroup("");
        }

        private void gridView_ServiceGroup_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                string sErr = "";
                bool bVali = true;
                //if (gridView_ServiceGroup.GetRowCellValue(e.RowHandle, "GroupCode").ToString() == "")
                //{
                //    bVali = false;
                //    sErr = sErr + "Vui lòng nhập mã nhóm!";
                //}
                if (gridView_ServiceGroup.GetRowCellValue(e.RowHandle, "GroupName").ToString() == "")
                {
                    bVali = false;
                    sErr = sErr + "Vui lòng nhập tên nhóm!";
                }
                if (gridView_ServiceGroup.GetRowCellValue(e.RowHandle, "ServiceModuleCode").ToString() == "")
                {
                    bVali = false;
                    sErr = sErr + "Vui lòng chọn phân hệ!";
                }
                if (bVali)
                {
                    ItemGroupInf inf = new ItemGroupInf();
                    inf.GroupCode = gridView_ServiceGroup.GetRowCellValue(e.RowHandle, "GroupCode").ToString();
                    inf.GroupName = gridView_ServiceGroup.GetRowCellValue(e.RowHandle, "GroupName").ToString();
                    inf.ServiceModuleCode = gridView_ServiceGroup.GetRowCellValue(e.RowHandle, "ServiceModuleCode").ToString();
                    inf.GroupID_BHYT = Convert.ToInt32(gridView_ServiceGroup.GetRowCellValue(e.RowHandle, "GroupID_BHYT").ToString());
                    if (e.RowHandle < 0)
                    {
                        if (ItemGroupBLL.InsItemGroup(inf) == 1)
                        {
                            XtraMessageBox.Show("Thêm thành công!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm chưa được nhóm viện phí!", "Bệnh viện điện tử .NET");
                        }
                    }
                    else
                    {
                        if (ItemGroupBLL.InsItemGroup(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật thành công!", "Bệnh viện điện tử .NET");
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật không thành công!", "Bệnh viện điện tử .NET");
                        }
                    }
                    gridControl_ServiceGroup.DataSource = ItemGroupBLL.DTListItemGroup("");
                }
                else
                {
                    e.Valid = false;
                    XtraMessageBox.Show(sErr, "Bệnh viện điện tử .NET");
                }
            }
            catch { }
        }

        private void gridControl_ServiceGroup_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_ServiceGroup.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa nhóm nhóm thuốc này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    try
                    {
                        ItemGroupBLL.DelItemGroup(gridView_ServiceGroup.GetRowCellValue(gridView_ServiceGroup.FocusedRowHandle, "GroupCode").ToString());
                        gridControl_ServiceGroup.DataSource = ItemGroupBLL.DTListItemGroup("");
                    }
                    catch { return; }
                }
            }
        }
    }
}