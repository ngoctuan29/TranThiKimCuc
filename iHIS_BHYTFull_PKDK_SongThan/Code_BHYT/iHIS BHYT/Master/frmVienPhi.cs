using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using DevExpress.XtraEditors.Controls;

namespace Ps.Clinic.Master
{
    public partial class frmVienPhi : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string s_userid = string.Empty;
        private string type = "S";
        private DataView dataviewCategory = null;
        private DateTime dtWorking = new DateTime();
        public frmVienPhi(string _userid, DateTime _dtWorking)
        {
            InitializeComponent();
            this.s_userid = _userid;
            this.dtWorking = _dtWorking;
        }

        private void frmVienPhi_Load(object sender, EventArgs e)
        {
            try {
                this.ItemGridLookUpEdit_Service_Group.DataSource = ServiceGroupBLL.DTServiceGroup(string.Empty);
                this.ItemGridLookUpEdit_Service_Group.DisplayMember = "ServiceGroupName";
                this.ItemGridLookUpEdit_Service_Group.ValueMember = "ServiceGroupCode";

                this.ref_Service_CategoryCode.DataSource = ServiceCategoryBLL.DTServiceCategory(string.Empty, string.Empty);
                this.ref_Service_CategoryCode.DisplayMember = "ServiceCategoryName";
                this.ref_Service_CategoryCode.ValueMember = "ServiceCategoryCode";

                var listDepart = (from p in DepartmentBLL.ListDepartment(string.Empty) where p.Hide == 0 select new { p.DepartmentCode, p.DepartmentName }).ToList();
                this.rep_DepartmentCode.DataSource = listDepart;
                this.rep_DepartmentCode.DisplayMember = "DepartmentName";
                this.rep_DepartmentCode.ValueMember = "DepartmentCode";

                this.rep_PatientType.DataSource = PatientsBLL.DT_PatientTypeMain();
                this.rep_PatientType.DisplayMember = "TypeName";
                this.rep_PatientType.ValueMember = "RowID";

                this.ref_UnitOf.DataSource = UnitOfMeasureBLL.ListUnit(string.Empty, this.type);
                this.ref_UnitOf.DisplayMember = "UnitOfMeasureName";
                this.ref_UnitOf.ValueMember = "UnitOfMeasureCode";

                this.repMaTuongDuong_BHYT.DataSource = Catalog_BHYTBLL.TableService_BHYT();
                this.repMaTuongDuong_BHYT.DisplayMember = "MaTuongDuong";
                this.repMaTuongDuong_BHYT.ValueMember = "MaTuongDuong";

                this.replkup_IDGroupPrint.DataSource = VP_ServiceGroupPrintBLL.GetListNhomIn();
                this.replkup_IDGroupPrint.DisplayMember = "GroupName";
                this.replkup_IDGroupPrint.ValueMember = "ID";

                //this.repMaCK_BHYT.DataSource = Catalog_BHYTBLL.TableDMChuyenKhoa_BHYT();
                //this.ref_UnitOf.DisplayMember = "Ten";
                //this.ref_UnitOf.ValueMember = "MaCK";

                this.fLoaddata();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void fLoaddata()
        {
            this.gridControl_Service.DataSource = Utils.ListToDataTable(ServiceBLL.ListService(string.Empty, string.Empty, this.chkKhoa.Checked ? 1 : 0));
        }

        private void gridView_Service_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi khai báo giá viện phí !.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridView_Service_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, colService_ServiceGroupCode))))
                {
                    e.Valid = false;
                    view.SetColumnError(colService_ServiceGroupCode, "Nhóm viện phí không tồn tại. Yêu cầu qua khai báo!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, colService_ServiceCategoryCode))))
                {
                    e.Valid = false;
                    view.SetColumnError(colService_ServiceGroupCode, "Chọn loại của nhóm viện phí!");
                }
                //if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Service_Code))))
                //{
                //    e.Valid = false;
                //    view.SetColumnError(col_Service_Code, "Mã viện phí không được để trống !");
                //}
                //if (ISDBNULL(Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_Unit_Price)),1 ) < 0)
                //{
                //    e.Valid = false;
                //    view.SetColumnError(col_Unit_Price, "Đơn giá phải lớn hơn không (0) !");
                //}
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, colService_ServiceName))))
                {
                    e.Valid = false;
                    view.SetColumnError(colService_ServiceName, "Tên viện phí không được để trống!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, colService_UnitOf))))
                {
                    e.Valid = false;
                    view.SetColumnError(colService_UnitOf, "Chưa chọn đơn vị tính!");
                }
                if (e.Valid == true)
                {
                    ServiceInf inf = new ServiceInf();
                    inf.ServiceGroupCode = this.gridView_Service.GetRowCellValue(e.RowHandle, "ServiceGroupCode").ToString();
                    inf.ServiceCategoryCode = this.gridView_Service.GetRowCellValue(e.RowHandle, "ServiceCategoryCode").ToString();
                    inf.ServiceCode = this.gridView_Service.GetRowCellValue(e.RowHandle, "ServiceCode").ToString();
                    inf.ServiceName = Utils.ToUpperCharacterFisrt(this.gridView_Service.GetRowCellValue(e.RowHandle, "ServiceName").ToString());
                    inf.DepartmentCode = this.gridView_Service.GetRowCellValue(e.RowHandle, "DepartmentCode").ToString();
                    if (this.gridView_Service.GetRowCellValue(e.RowHandle, "Hide").ToString() != "")
                        inf.Hide = Int32.Parse(this.gridView_Service.GetRowCellValue(e.RowHandle, "Hide").ToString());
                    else
                        inf.Hide = 0;
                    inf.EmployeeCode = s_userid;
                    inf.PatientType = this.gridView_Service.GetRowCellValue(e.RowHandle, "PatientType").ToString();
                    if (this.gridView_Service.GetRowCellValue(e.RowHandle, "Serial").ToString() != "")
                        inf.Serial = Convert.ToInt32(gridView_Service.GetRowCellValue(e.RowHandle, "Serial").ToString());
                    else
                        inf.Serial = 0;
                    inf.UnitOfMeasureCode = this.gridView_Service.GetRowCellValue(e.RowHandle, "UnitOfMeasureCode").ToString();
                    if (this.gridView_Service.GetRowCellValue(e.RowHandle, "SampleTransfer").ToString() != "")
                        inf.SampleTransfer = Int32.Parse(this.gridView_Service.GetRowCellValue(e.RowHandle, "SampleTransfer").ToString());
                    else
                        inf.SampleTransfer = 0;
                    inf.MaTuongDuong_BHYT = this.gridView_Service.GetRowCellValue(e.RowHandle, "MaTuongDuong_BHYT").ToString(); 
                    inf.MaCK_BHYT = this.gridView_Service.GetRowCellValue(e.RowHandle, "MaCK_BHYT").ToString();
                    inf.MaDK_BHYT = this.gridView_Service.GetRowCellValue(e.RowHandle, "MaDK_BHYT").ToString();
                    inf.SOQDPK = this.gridView_Service.GetRowCellValue(e.RowHandle, "SOQDPK").ToString();
                    inf.Note = this.gridView_Service.GetRowCellValue(e.RowHandle, "Note").ToString();
                    inf.Ma_TT37 = this.gridView_Service.GetRowCellValue(e.RowHandle, "Ma_TT37").ToString();
                    inf.Ten_TT37 = this.gridView_Service.GetRowCellValue(e.RowHandle, "Ten_TT37").ToString();
                    inf.IDGroupPrint = string.IsNullOrEmpty(this.gridView_Service.GetRowCellValue(e.RowHandle, "IDGroupPrint").ToString()) ? 0 : Convert.ToInt32(this.gridView_Service.GetRowCellValue(e.RowHandle, "IDGroupPrint").ToString());
                    if (e.RowHandle < 0)
                    {
                        if (ServiceBLL.InsService(inf) != 1)
                            XtraMessageBox.Show("Thêm chưa được danh mục viện phí!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (ServiceBLL.InsService(inf) != 1)
                            XtraMessageBox.Show("Cập nhật không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    this.fLoaddata();
                }
                
            }
            catch (Exception ex) {
                XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_Service_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "ServiceCategoryCode")
            {
                if (e.Value != null)
                {
                    string sGrCode = ServiceCategoryBLL.ServiceGroupCode(string.Empty, e.Value.ToString());
                    view.SetFocusedRowCellValue(colService_ServiceGroupCode, sGrCode);
                }
            }
            if (view.FocusedColumn.FieldName == "MaTuongDuong_BHYT")
            {
                if (e.Value != null)
                {
                    string sCK = Catalog_BHYTBLL.TableCkTheoTD(e.Value.ToString());
                    view.SetFocusedRowCellValue(colService_MaCK_BHYT, sCK);
                }
            }
        }

        private void gridControl_Service_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_Service.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show(" Bạn có muốn xóa dịch vụ đang chọn hay không? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        string sCode = gridView_Service.GetRowCellValue(gridView_Service.FocusedRowHandle, "ServiceCode").ToString();
                        if (ServiceBLL.DelService(sCode) >= 1)
                            this.fLoaddata();
                        else
                        {
                            XtraMessageBox.Show(" Dịch vụ đã sử dụng không cho phép xóa !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(" Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            this.gridView_Service.ShowRibbonPrintPreview();
        }

        private void gridView_Service_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view.FocusedColumn.FieldName == "ServiceCategoryCode" && view.ActiveEditor is GridLookUpEdit)
                {
                    DevExpress.XtraEditors.GridLookUpEdit gridLKupEdit;
                    string groupCode = this.gridView_Service.GetRowCellValue(this.gridView_Service.FocusedRowHandle, "ServiceGroupCode").ToString();
                    gridLKupEdit = (GridLookUpEdit)view.ActiveEditor;
                    DataTable table = this.ref_Service_CategoryCode.DataSource as DataTable;
                    this.dataviewCategory = new DataView(table);
                    DataRow row = view.GetDataRow(view.FocusedRowHandle);
                    this.dataviewCategory.RowFilter = "ServiceGroupCode='" + groupCode + "'";
                    gridLKupEdit.Properties.DataSource = this.dataviewCategory;
                }
            }
            catch { return; }
        }

        private void gridView_Service_HiddenEditor(object sender, EventArgs e)
        {
            if (this.dataviewCategory != null)
            {
                this.dataviewCategory.Dispose();
                this.dataviewCategory = null;
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            this.fLoaddata();
        }

        private void rep_btnRefItemsAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string serviceCodeTemp = this.gridView_Service.GetFocusedRowCellValue("ServiceCode").ToString();
                ViewPopup.frmVP_VTTHKemTheo frm = new ViewPopup.frmVP_VTTHKemTheo(this.s_userid, serviceCodeTemp, this.dtWorking);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.ToString(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_Service_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (!view.GetRowCellDisplayText(e.RowHandle, view.Columns["Attach_Items"]).ToString().Equals("Unchecked"))
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                }
            }
            catch (Exception ex){ }
        }
    }
}