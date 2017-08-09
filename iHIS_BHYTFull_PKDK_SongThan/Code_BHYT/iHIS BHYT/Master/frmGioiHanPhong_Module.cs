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
using ClinicModel;
using ClinicLibrary;
namespace Ps.Clinic.Master
{
    public partial class frmGioiHanPhong_Module : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable dtService = new DataTable();
        private DataTable dtDepart = new DataTable();
        private string userID = string.Empty;
        public frmGioiHanPhong_Module(string _userID)
        {
            InitializeComponent();
            this.userID = _userID;
        }

        private void frmGioiHanPhong_Module_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable tableDep = DepartmentBLL.DTDepartment(string.Empty);
                if (tableDep != null && tableDep.Rows.Count > 0 && tableDep.Select("Hide=0").Length > 0)
                    this.dtDepart = tableDep.Select("Hide=0").CopyToDataTable();                
                this.chkDepartment.DataSource = this.dtDepart;
                this.chkDepartment.ValueMember = "DepartmentCode";
                this.chkDepartment.DisplayMember = "DepartmentName";
                this.gridControl_Menu.DataSource = ServiceMenuBLL.ListServiceMenu();
                this.dtService = ServiceBLL.DTServiceReal();
                this.gridControl_Service.DataSource = dtService;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_Menu_Click(object sender, EventArgs e)
        {
            try
            {
                chkDepartment.UnCheckAll();
                if (gridView_Menu.RowCount > 0)
                {
                    Int32 iMenu = Convert.ToInt32(gridView_Menu.GetRowCellValue(gridView_Menu.FocusedRowHandle, col_ServiceMenuID).ToString());
                    if (gridView_Menu.GetFocusedRow() != null)
                    {
                        List<ServiceMenuForDepartmentINF> lstMenuPart = ServiceMenuBLL.ListServiceMenuForDepartmentINF(iMenu);
                        foreach (var v in lstMenuPart)
                        {
                            for (int i = 0; i < chkDepartment.ItemCount; i++)
                            {
                                if (chkDepartment.GetItemValue(i).ToString() == v.DepartmentCode)
                                    chkDepartment.SetItemChecked(i, true);
                            }
                        }
                        dtService = ServiceBLL.DTServiceReal();
                        gridControl_Service.DataSource = dtService;
                        List<ServiceMenuForServiceINF> lstMenuSer = ServiceMenuBLL.ListServiceMenuForService(iMenu);
                        foreach (DataRow dr in dtService.Rows)
                        {
                            foreach (var v in lstMenuSer)
                            {
                                if (dr["ServiceCode"].ToString() == v.ServiceCode)
                                {
                                    dr["Chon"] = 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_Menu.RowCount > 0)
                {
                    Int32 iMenu = Convert.ToInt32(gridView_Menu.GetRowCellValue(gridView_Menu.FocusedRowHandle, col_ServiceMenuID).ToString());
                    ServiceMenuBLL.Del_ServiceMenuForService(iMenu);
                    ServiceMenuBLL.Del_ServiceMenuForDepartment(iMenu);
                    if (this.gridView_Menu.GetFocusedRow() != null)
                    {

                        #region 
                        //int[] lst = this.gridView_Service.GetSelectedRows();
                        //foreach (var index in lst)
                        //{
                        //    if (index >= 0)
                        //    {
                        //        string value = this.gridView_Service.GetRowCellValue(index, this.col_Chon).ToString();
                        //    }
                        //}
                        #endregion

                        DataTable dtTemp = this.dtService.Select("Chon=1", "Chon desc").CopyToDataTable();
                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            if (dr["Chon"].ToString() == "1")
                            {
                                ServiceMenuForServiceINF inf = new ServiceMenuForServiceINF();
                                inf.ServiceCode = dr["ServiceCode"].ToString();
                                inf.ServiceMenuID = iMenu;
                                ServiceMenuBLL.Ins_ServiceMenuForService(inf);
                            }
                        }
                        for (int i = 0; i < dtDepart.Rows.Count; i++)
                        {
                            if (chkDepartment.GetItemChecked(i) == true)
                            {
                                ServiceMenuForDepartmentINF inf = new ServiceMenuForDepartmentINF();
                                inf.ServiceMenuID = iMenu;
                                inf.DepartmentCode = chkDepartment.GetItemValue(i).ToString();
                                ServiceMenuBLL.Ins_ServiceMenuForDepartment(inf);
                            }
                        }
                        XtraMessageBox.Show(" Cập nhật thông tin giới hạn thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Chưa chọn menu giới hạn chỉ định!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}