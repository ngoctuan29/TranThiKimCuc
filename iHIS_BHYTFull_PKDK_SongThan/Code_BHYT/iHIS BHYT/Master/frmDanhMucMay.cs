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
    public partial class frmDanhMucMay : DevExpress.XtraEditors.XtraForm
    {
        private string userID = string.Empty;
        public frmDanhMucMay(string _userID)
        {
            this.userID = _userID;
            InitializeComponent();
        }

        private void frmDanhMucMay_Load(object sender, EventArgs e)
        {
            try
            {
                this.rep_ServiceCategory.DataSource = ServiceCategoryBLL.ListServiceCategory("", "").Where(c => c.ServiceGroupCode == "XN" || c.ServiceGroupCode == "CDHA");
                this.rep_ServiceCategory.DisplayMember = "ServiceCategoryName";
                this.rep_ServiceCategory.ValueMember = "ServiceCategoryCode";
                this.Getdata();
            }
            catch(Exception ex)  {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void Getdata()
        {
            this.gridControl_Data.DataSource = MachineListsBLL.TableMachineLists();
        }

        private void gridView_Object_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo danh mục máy xét nghiệm hoặc chuẩn đoán hình ảnh!.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Data_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (Convert.ToString(view.GetRowCellValue(rowfocus, colMachine_Name)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(colMachine_Name, " Tên máy khai báo không được để trống !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, colMachine_Code)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(colMachine_Name, " Tên viết tắt chưa được khai báo !");
                }
                if (Convert.ToString(view.GetRowCellValue(rowfocus, colMachine_ServiceCategoryCode)).ToString() == string.Empty)
                {
                    e.Valid = false;
                    view.SetColumnError(colMachine_ServiceCategoryCode, " Chọn loại dịch vụ có máy xét nghiệm, CĐHA,.. !");
                }
                if (e.Valid == true)
                {
                    MachineLists inf = new MachineLists();
                    inf.MechineCode = gridView_Data.GetRowCellValue(e.RowHandle, "MechineCode").ToString();
                    inf.MechineName = gridView_Data.GetRowCellValue(e.RowHandle, "MechineName").ToString();
                    if (gridView_Data.GetRowCellValue(e.RowHandle, "Hide").ToString() != "")
                        inf.Hide = Int32.Parse(gridView_Data.GetRowCellValue(e.RowHandle, "Hide").ToString());
                    else
                        inf.Hide = 0;
                    if (gridView_Data.GetRowCellValue(e.RowHandle, "ServiceCategoryCode").ToString() != "")
                        inf.ServiceCategoryCode = gridView_Data.GetRowCellValue(e.RowHandle, "ServiceCategoryCode").ToString();
                    if (gridView_Data.GetRowCellValue(e.RowHandle, "RowID").ToString() != string.Empty)
                        inf.RowID = Convert.ToInt32(gridView_Data.GetRowCellValue(e.RowHandle, "RowID").ToString());
                    else
                        inf.RowID = 0;
                    if (e.RowHandle < 0)
                    {
                        if (MachineListsBLL.InsMachineLists(inf) == 1)
                        {
                            XtraMessageBox.Show(" Khai báo máy mới thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show(" Khai báo máy mới thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (MachineListsBLL.InsMachineLists(inf) == 2)
                        {
                            XtraMessageBox.Show(" Cập nhật lại danh mục máy thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show(" Cập nhật máy thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                this.Getdata();
            }
            catch  { }
        }

        private void gridControl_Data_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gridView_Data.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa máy XN, XĐHA này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                    {
                        try
                        {
                            if (MachineListsBLL.IsDeleteMachineLists(Convert.ToInt32(gridView_Data.GetRowCellValue(gridView_Data.FocusedRowHandle, "RowID").ToString())))
                                this.Getdata();
                            else
                            {
                                XtraMessageBox.Show(" Xóa không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        catch { return; }
                    }
                }
            }
            catch { }
        }
    }
}