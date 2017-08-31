using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClinicBLL;
using DevExpress.XtraGrid.Views.Grid;
using ClinicModel;
using ClinicLibrary;

namespace Ps.Clinic.ViewPopup
{
    public partial class frm_Attach_Service : DevExpress.XtraEditors.XtraForm
    {
        private string attachServiceCodeOld = string.Empty;
        private DataView dataviewCategory = null;
        private DataTable dtAttach_Service = new DataTable();
        private string attachServiceCode = string.Empty;
        private string itemCode = string.Empty;
        public frm_Attach_Service(string itemcode)
        {
            InitializeComponent();

            this.itemCode = itemcode;
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Attach_Service_Load(object sender, EventArgs e)
        {
            try
            {
                this.ref_Service_CategoryCode.DataSource = ServiceCategoryBLL.DTServiceCategory(string.Empty, string.Empty);
                this.ref_Service_CategoryCode.DisplayMember = "ServiceCategoryName";
                this.ref_Service_CategoryCode.ValueMember = "ServiceCategoryCode";

                this.ItemGridLookUpEdit_Service_Group.DataSource = ServiceGroupBLL.DTServiceGroup(string.Empty);
                this.ItemGridLookUpEdit_Service_Group.DisplayMember = "ServiceGroupName";
                this.ItemGridLookUpEdit_Service_Group.ValueMember = "ServiceGroupCode";

                this.rep_ObjectCode.DataSource = ObjectBLL.DTObjectList(0);
                this.rep_ObjectCode.DisplayMember = "ObjectName";
                this.rep_ObjectCode.ValueMember = "ObjectCode";

                this.rep_EmployeeCode.DataSource = EmployeeBLL.DTEmployeeList(0);
                this.rep_EmployeeCode.DisplayMember = "EmployeeName";
                this.rep_EmployeeCode.ValueMember = "EmployeeCode";








                this.repSLookUp_DV.DataSource = ServiceBLL.DTServiceList(0);
                this.repSLookUp_DV.DisplayMember = "ServiceName";
                this.repSLookUp_DV.ValueMember = "ServiceCode";

                //this.rep_Service.DataSource = ServiceBLL.DTServiceList(0);
                //this.rep_Service.DisplayMember = "ServiceName";
                //this.rep_Service.ValueMember = "ServiceCode";


                //this.repSearch_Item.DataSource = ItemsBLL.ListItemsRef(0, this.. == null ? string.Empty : this.lkupKho.EditValue.ToString());
                //this.repSearch_Item.DisplayMember = "ItemName";
                //this.repSearch_Item.ValueMember = "ItemCode";


                //this.butSave.Enabled = true;
                this.GetDataServiceItems();
                if (this.dtAttach_Service.Rows.Count > 0 && this.dtAttach_Service != null)
                {

                }
                    //this.butNew.Enabled = this.butSave.Enabled = false;

                else
                    this.EnableButton(true);
            }
            catch (Exception ex) { }

        }

        private void gridView_Attach_Service_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view.FocusedColumn.FieldName == "ServiceCategoryCode" && view.ActiveEditor is GridLookUpEdit)
                {
                    DevExpress.XtraEditors.GridLookUpEdit gridLKupEdit;
                    string groupCode = this.gridView_Attach_Service.GetRowCellValue(this.gridView_Attach_Service.FocusedRowHandle, "ServiceGroupCode").ToString();
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

        //private void butNew_Click(object sender, EventArgs e)
        //{
        //    this.gridView_Attach_Service.OptionsBehavior.ReadOnly = false;
        //    this.gridView_Attach_Service.OptionsBehavior.Editable = true;
        //    this.gridView_Attach_Service.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;

        //}


        private void GetDataServiceItems()
        {
            this.dtAttach_Service = Utils.ListToDataTable(ServiceBLL.ListViewAttach_Service(this.itemCode));
            this.gridControl_Attach_Service.DataSource = this.dtAttach_Service;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtAttach_Service.Rows.Count > 0)
                {
                    int stt = 1;
                    bool isSuccess = true;
                    foreach (DataRow row in this.dtAttach_Service.Rows)
                    {
                        if (row["AttachServiceCode"].ToString()==null || row["AttachServiceCode"].ToString()=="")
                        {
                            XtraMessageBox.Show("Bạn chưa chọn tên dịch vụ!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        
                        else if (row["ObjectCode"].ToString() == null || row["ObjectCode"].ToString() == "")
                        {
                            XtraMessageBox.Show("Bạn chưa chọn đối tượng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //else if (row["EmployeeCode"].ToString() == null || row["EmployeeCode"].ToString() == "")
                        //{
                        //    XtraMessageBox.Show("Bạn chưa chọn người thực hiện!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    return;
                        //}
                        else
                        {
                            int quantity = 1;

                            if(row["Quantity"].ToString() != null&& row["Quantity"].ToString() != "")
                            {
                                quantity = Convert.ToInt32(row["Quantity"].ToString());
                            }
                            String idate = DateTime.Now.ToString();
                            
                            int rowid = -1;
                            if (row["RowID"].ToString() != null && row["RowID"].ToString() != "")
                            {
                                rowid = Convert.ToInt32((row["RowID"]));
                            }
                            int auto = 0;
                            if (row["Is_Service_Auto"].ToString() != null && row["Is_Service_Auto"].ToString() != "")
                            {
                                auto = Convert.ToInt32((row["Is_Service_Auto"]));
                            }
                            Attach_ServiceINF inf = new Attach_ServiceINF { RowID = rowid, AttachServiceCode = row["AttachServiceCode"].ToString(), ItemCode = this.itemCode, ObjectCode = Convert.ToInt32(row["ObjectCode"].ToString()), IDate = Convert.ToDateTime(idate), Quantity = quantity, EmployeeCode = "null", STT = stt, Note = row["Note"].ToString(), Is_Service_Auto = auto };
                            if (ServiceBLL.InsAttach_Service(inf) <= 0)
                            {
                                isSuccess = false;
                                XtraMessageBox.Show("Lưu không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //ServiceBLL.DelServiceItemAttachAll(this.attachServiceCode);
                                break;
                            }
                            stt++;
                        }
                        
                    }
                    if (isSuccess)
                    {
                        //this.gridView_Attach_Service.OptionsBehavior.ReadOnly = true;
                        //this.gridView_Attach_Service.OptionsBehavior.Editable = false;
                        //this.gridView_Attach_Service.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                        //this.butCancel.Enabled = this.butEdit.Enabled = true;
                        //this.butSave.Enabled = this.butNew.Enabled = false;
                        //ServiceBLL.UpdServiceItemAttach(true, this.attachServiceCode);
                        XtraMessageBox.Show("Lưu thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.GetDataServiceItems();
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Không có dịch vụ phát sinh! Hãy nhập dịch vụ trước khi lưu.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }


        public void EnableButton(bool b)
        {
            //this.butNew.Enabled = b;
            //this.butSave.Enabled = !b;
            //his.butCancel.Enabled = false;
            //this.butEdit.Enabled = false;
        }

        private void gridView_Attach_Service_KeyPress(object sender, KeyPressEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "Quantity")
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '/')
                {
                    e.Handled = true;
                }
            }
        }

        private void gridControl_Attach_Service_Validated(object sender, EventArgs e)
        {

        }

        //private void butEdit_Click(object sender, EventArgs e)
        //{
        //    this.butSave.Enabled = true;
        //    //this.butNew.Enabled = this.butEdit.Enabled = false;
        //    this.gridView_Attach_Service.OptionsBehavior.ReadOnly = false;
        //    this.gridView_Attach_Service.OptionsBehavior.Editable = true;
        //    this.gridView_Attach_Service.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
        //}

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Bạn có muốn hủy tất cả dịch vụ?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    bool isScuccess = true;
                    string itemcodeTemp = string.Empty;
                    foreach (DataRow row in dtAttach_Service.Rows)
                    {
                        if (ServiceBLL.DelAttach_ServiceAll(this.attachServiceCode, row["ItemCode"].ToString()) < 0)
                        {
                            isScuccess = false;
                            itemcodeTemp = row["ItemCode"].ToString();
                            break;
                        }
                    }
                    if (isScuccess)
                    {
                        this.gridView_Attach_Service.OptionsBehavior.ReadOnly = true;
                        this.gridView_Attach_Service.OptionsBehavior.Editable = false;
                        this.gridView_Attach_Service.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                        ServiceBLL.UpdServiceItemAttach(false, this.attachServiceCode);
                        XtraMessageBox.Show(" Dịch vụ theo tên thuốc thành công !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.EnableButton(true);
                        this.GetDataServiceItems();
                    }
                    else
                        XtraMessageBox.Show(" Dịch vụ theo tên thuốc không thành công !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_Attach_Service_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa dịch vụ này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        string tempItemCode = this.gridView_Attach_Service.GetRowCellValue(this.gridView_Attach_Service.FocusedRowHandle, this.col_ItemCode).ToString();
                        string acttachCode = this.gridView_Attach_Service.GetRowCellValue(this.gridView_Attach_Service.FocusedRowHandle, this.col_AttachServiceCode).ToString();
                        if (!string.IsNullOrEmpty(tempItemCode))
                        {
                            if (ServiceBLL.DelAttach_ServiceAll(acttachCode, tempItemCode) > 0)
                            {
                                this.GetDataServiceItems();
                                XtraMessageBox.Show("Xoá dịch vụ thành công.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Vui lòng chọn dịch vụ để xoá.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.ToString(), "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_Attach_Service_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //try
            //{
            //    GridView view = sender as GridView;
            //    int rowfocus = e.RowHandle;

            //    string a = this.attachServiceCodeOld;

            //    if (e.Valid == true)
            //    {
            //        Attach_ServiceINF inf = new Attach_ServiceINF();
            //        if (this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "AttachServiceCode").ToString() == null || this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "AttachServiceCode").ToString() == "")
            //        {
            //            XtraMessageBox.Show("Bạn chưa chọn tên dịch vụ!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }

            //        else if (this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "ObjectCode").ToString() == null || this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "ObjectCode").ToString() == "")
            //        {
            //            XtraMessageBox.Show("Bạn chưa chọn đối tượng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }
            //        else if (this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "EmployeeCode").ToString() == null || this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "EmployeeCode").ToString() == "")
            //        {
            //            XtraMessageBox.Show("Bạn chưa chọn người thực hiện!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }
            //        else
            //        {
            //            int quantity = 1;

            //            if (this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "Quantity").ToString() != null && this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "Quantity").ToString() != "")
            //            {
            //                quantity = Convert.ToInt32(this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "Quantity").ToString());
            //            }
            //            String idate = DateTime.Now.ToString();
            //            if (this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "IDate").ToString() != null && this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "IDate").ToString() != "")
            //            {
            //                idate = Convert.ToString(this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "IDate").ToString());
            //            }
            //            int Stt = 0;
            //            if (this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "STT").ToString() != null && this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "STT").ToString() != "")
            //            {
            //                Stt = Convert.ToInt32(this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "STT").ToString());
            //            }
            //            int rowid = -1;
            //            if (this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "RowID").ToString() != null && this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "RowID").ToString() != "")
            //            {
            //                inf.RowID = Convert.ToInt32(this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "RowID").ToString());
            //            }
            //            inf.AttachServiceCodeOld = null;
            //            if (this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "AttachServiceCodeOld").ToString() != null && this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "AttachServiceCodeOld").ToString() != "")
            //            {
            //                inf.AttachServiceCodeOld = this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "AttachServiceCodeOld").ToString();
            //            }

            //            inf.RowID = rowid;
            //            inf.AttachServiceCode = this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "AttachServiceCode").ToString();
            //            inf.ItemCode = this.itemCode;
            //            inf.ObjectCode = Convert.ToInt32(this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "ObjectCode").ToString());
            //            inf.IDate = Convert.ToDateTime(idate);
            //            inf.Quantity = quantity;
            //            inf.EmployeeCode = this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "EmployeeCode").ToString();
            //            inf.STT = Stt;
            //            inf.Note = this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "Note").ToString();
            //            //inf.AttachServiceCodeOld= this.gridView_Attach_Service.GetRowCellValue(e.RowHandle, "AttachServiceCodeOld").ToString();

            //            if (e.RowHandle < 0)
            //            {
            //                if (ServiceBLL.InsAttach_Service(inf) == 1)
            //                {
            //                    XtraMessageBox.Show("Thêm thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                }
            //                else
            //                {
            //                    XtraMessageBox.Show("Thêm chưa được loại viện phí!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                }
            //            }
            //            else
            //            {
            //                if (ServiceBLL.InsAttach_Service(inf) == 1)
            //                {
            //                    XtraMessageBox.Show("Cập nhật thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                }
            //                else
            //                {
            //                    XtraMessageBox.Show("Cập nhật không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                }
            //            }


            //        }

            //    }
            //}
            //catch (Exception) { }
        }

        private void rep_Service_Click(object sender, EventArgs e)
        {
            try
            {
                SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
                this.attachServiceCodeOld = searchEdit.Properties.View.GetFocusedRowCellValue("ServiceCode").ToString();
            }
            catch
            {

            }
        }
    }
}