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
    public partial class frmVP_DMNhom : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataTable dt = new DataTable();
        public frmVP_DMNhom()
        {
            InitializeComponent();
        }

        private void frmNhomVienPhi_Load(object sender, EventArgs e)
        {
            try
            {
                this.rep_ServiceModule.DataSource = ServiceModuleBLL.DTListServiceModule(string.Empty);
                this.rep_ServiceModule.ValueMember = "ServiceModuleCode";
                this.rep_ServiceModule.DisplayMember = "ServiceModuleName";

                this.repsearch_GroupBHYT.DataSource = Catalog_BHYTBLL.TableServiceGroup_BHYT();
                this.repsearch_GroupBHYT.ValueMember = "GroupID";
                this.repsearch_GroupBHYT.DisplayMember = "GroupName";

                this.gridControl_ServiceGroup.DataSource = ServiceGroupBLL.DTServiceGroup(string.Empty);
            }
            catch (Exception ex){
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView_ServiceGroup_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                string sErr = "";
                bool bVali = true;
                if (gridView_ServiceGroup.GetRowCellValue(e.RowHandle, "ServiceGroupCode").ToString() == "")
                {
                    bVali = false;
                    sErr = sErr + "Vui lòng nhập mã nhóm!";
                }
                if (gridView_ServiceGroup.GetRowCellValue(e.RowHandle, "ServiceGroupName").ToString() == "")
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
                    ServiceGroupInf inf = new ServiceGroupInf();
                    inf.ServiceGroupCode = gridView_ServiceGroup.GetRowCellValue(e.RowHandle, "ServiceGroupCode").ToString();
                    inf.ServiceGroupName = gridView_ServiceGroup.GetRowCellValue(e.RowHandle, "ServiceGroupName").ToString();
                    inf.ServiceModuleCode = gridView_ServiceGroup.GetRowCellValue(e.RowHandle, "ServiceModuleCode").ToString();
                    if (gridView_ServiceGroup.GetRowCellValue(e.RowHandle, "STT").ToString() == string.Empty)
                        inf.STT = 0;
                    else
                        inf.STT = Convert.ToInt32(gridView_ServiceGroup.GetRowCellValue(e.RowHandle, "STT").ToString());
                    if (string.IsNullOrEmpty(this.gridView_ServiceGroup.GetRowCellValue(e.RowHandle, "GroupID_BHYT").ToString()))
                        inf.GroupID_BHYT = -1;
                    else
                        inf.GroupID_BHYT = Convert.ToInt32(this.gridView_ServiceGroup.GetRowCellValue(e.RowHandle, "GroupID_BHYT").ToString());
                    if (e.RowHandle < 0)
                    {
                        if (ServiceGroupBLL.InsServiceGroup(inf, true) == 1)
                        {
                            XtraMessageBox.Show("Thêm thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm không thành công nhóm viện phí!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (ServiceGroupBLL.InsServiceGroup(inf, false) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    e.Valid = false;
                    XtraMessageBox.Show(sErr, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { }
        }

        private void gridControl_ServiceGroup_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_ServiceGroup.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa nhóm dịch vụ này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    try
                    {
                        ServiceGroupBLL.DelServiceGroup(gridView_ServiceGroup.GetRowCellValue(gridView_ServiceGroup.FocusedRowHandle, "ServiceGroupCode").ToString());
                        gridControl_ServiceGroup.DataSource = ServiceGroupBLL.DTServiceGroup("");
                    }
                    catch { return; }
                }
            }
        }
    }
}