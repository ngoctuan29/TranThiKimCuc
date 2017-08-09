using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports;
using ClinicModel;
using ClinicBLL;
using ClinicLibrary;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;

namespace Ps.Clinic.Statistics
{
    public partial class frmTemplate_MSBieu05 : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtbResult = new DataTable();
        private string employeeCode = string.Empty;
        public frmTemplate_MSBieu05(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }
        
        private void LoadDataBS05()
        {
            this.dtbResult = Rpt_VuDieuTriBLL.TableBM05Template();
            this.gridControl_Result.DataSource = this.dtbResult;
        }
        
        private void frmTemplate_MSBieu05_Load(object sender, EventArgs e)
        {
            this.repChkCB_Service.DataSource = ServiceBLL.DTServiceFull();
            this.repChkCB_Service.DisplayMember = "ServiceName";
            this.repChkCB_Service.ValueMember = "ServiceCode";
            this.LoadDataBS05();
        }

        private void gridVIew_Result_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(view.GetRowCellValue(rowfocus, this.gridCol_LaMa).ToString()))
                {
                    e.Valid = false;
                    view.SetColumnError(this.gridCol_LaMa, "Nhập mục báo cáo biểu mẫu.");
                }
                if (string.IsNullOrEmpty(view.GetRowCellValue(rowfocus, this.gridCol_TargetName).ToString()))
                {
                    e.Valid = false;
                    view.SetColumnError(this.gridCol_TargetName, "Nhập tên chỉ tiêu.");
                }
                
                if (e.Valid == true)
                {
                    BM05_YTTN_TemplateInf inf = new BM05_YTTN_TemplateInf();
                    if (string.IsNullOrEmpty(this.gridVIew_Result.GetRowCellValue(e.RowHandle, "RowIDTemplate").ToString()))
                        inf.RowIDTemplate = -1;
                    else
                        inf.RowIDTemplate = Convert.ToInt32(this.gridVIew_Result.GetRowCellValue(e.RowHandle, "RowIDTemplate").ToString());
                    inf.OrderNumber = Convert.ToInt32(this.gridVIew_Result.GetRowCellValue(e.RowHandle, "OrderNumber").ToString());
                    inf.LaMa = this.gridVIew_Result.GetRowCellValue(e.RowHandle, "LaMa").ToString();
                    inf.LaMa_Detail = this.gridVIew_Result.GetRowCellValue(e.RowHandle, "LaMa_Detail").ToString();
                    inf.TargetName = this.gridVIew_Result.GetRowCellValue(e.RowHandle, "TargetName").ToString();
                    inf.Result = this.gridVIew_Result.GetRowCellValue(e.RowHandle, "Result").ToString();
                    inf.ServiceCode = this.gridVIew_Result.GetRowCellValue(e.RowHandle, "ServiceCode").ToString();
                    if (e.RowHandle < 0)
                    {
                        if (Rpt_VuDieuTriBLL.InsBM05(inf) == 1)
                            XtraMessageBox.Show("Thêm chỉ tiêu thành công!", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            XtraMessageBox.Show("Thêm không thành công chỉ tiêu!", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (Rpt_VuDieuTriBLL.InsBM05(inf) == 1)
                            XtraMessageBox.Show("Cập nhật thành công!", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            XtraMessageBox.Show("Cập nhật không thành công chỉ tiêu!", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    this.LoadDataBS05();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridControl_Result_ProcessGridKey(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete && this.gridVIew_Result.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            //{
            //    if (XtraMessageBox.Show(" Bạn có muốn xóa chỉ tiêu đang chọn hay không? ", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
            //    {
            //        try
            //        {
            //            int rowIDTemplate = Convert.ToInt32(this.gridVIew_Result.GetRowCellValue(this.gridVIew_Result.FocusedRowHandle, "RowIDTemplate").ToString());
            //            if (rpt_VuDieuTriBLL.DelBM05(rowIDTemplate) >= 1)
            //                this.LoadDataBS05();
            //            else
            //            {
            //                XtraMessageBox.Show(" Chỉ tiêu áp dụng báo cáo không được phép xóa !", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return;
            //            }
            //        }
            //        catch (Exception ex){
            //            XtraMessageBox.Show(" Error: " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return; }
            //    }
            //}
        }
    }
}