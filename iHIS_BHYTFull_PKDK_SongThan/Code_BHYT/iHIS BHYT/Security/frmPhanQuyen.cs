using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Linq;
using System.Linq;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraGrid.Views.Grid;
namespace Ps.Clinic.Security
{
    public partial class frmPhanQuyen : DevExpress.XtraEditors.XtraForm
    {
        private DevExpress.Utils.WaitDialogForm Starting = null;
        private DataTable tableSetQuyen = new DataTable();
        private DataTable tableCoppy = new DataTable();
        private DataTable tableDepart = new DataTable();
        private Int32 countItemAll = 0;
        public frmPhanQuyen(TreeNode node, Int32 _countItemAll)
        {
            InitializeComponent();
            this.treeAuthor.Nodes.Clear();
            this.treeAuthor.Nodes.Add(node);
            this.countItemAll = _countItemAll;
        }

        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("StatusCode", typeof(Int32)));
                dt.Columns.Add(new DataColumn("StatusName", typeof(string)));
                dt.Rows.Add(new object[] { "0", "Nữ" });
                dt.Rows.Add(new object[] { "1", "Nam" });
                ref_status_sex.DataSource = dt;
                ref_status_sex.DisplayMember = "StatusName";
                ref_status_sex.ValueMember = "StatusCode";

                ref_status_position.DataSource = EmployeePositionBLL.DTEmployeePosition(0);
                ref_status_position.DisplayMember = "PositionName";
                ref_status_position.ValueMember = "PositionCode";
                DataTable tbDepartmentTemp = DepartmentBLL.DTDepartment(string.Empty);
                if (tbDepartmentTemp.Select("Hide=0").Length > 0)
                {
                    this.tableDepart = tbDepartmentTemp.Select("Hide=0").CopyToDataTable();
                    ref_Department.DataSource = this.tableDepart;
                    ref_Department.DisplayMember = "DepartmentName";
                    ref_Department.ValueMember = "DepartmentCode";
                }

                checklistKhoaphong.DataSource = this.tableDepart;
                checklistKhoaphong.ValueMember = "DepartmentCode";
                checklistKhoaphong.DisplayMember = "DepartmentName";

                checklistKho.DataSource = RepositoryCatalog_BLL.ListRepository(0);
                checklistKho.ValueMember = "RepositoryCode";
                checklistKho.DisplayMember = "RepositoryName";

                this.ref_EmployeeGroup.DataSource = EmployeeBLL.TableEmployeeGroup();
                this.ref_EmployeeGroup.DisplayMember = "EmployeeGroupName";
                this.ref_EmployeeGroup.ValueMember = "EmployeeGroupID";

                this.tableCoppy = MenuListBLL.DTMenuListSystem();
                this.fLoadEmployeePosition(string.Empty);
                this.LoadDataEmployee();
            }
            catch { }
        }

        private void fLoadEmployeePosition(string ten)
        {
            try
            {
                TreeNode anode, anode1;
                treeEmployee.Nodes.Clear();
                treeEmployee.ItemHeight = 18;
                DataTable dt = EmployeePositionBLL.DTEmployeePosition(0);
                DataTable dt1 = EmployeeBLL.DTEmployee(string.Empty, this.chkAll.Checked);
                string aft = string.Empty;
                if (ten != "")
                    aft = " and (EmployeeName like '%" + ten + "%' or Username like '%" + ten + "%' or EmployeeCode like'%" + ten + "%')";
                foreach (DataRow r in dt.Select("", ""))
                {
                    anode = new TreeNode(r["PositionName"].ToString());
                    anode.Tag = r["PositionCode"].ToString() + ":?";
                    treeEmployee.Nodes.Add(anode);
                    foreach (DataRow r1 in dt1.Select("PositionCode=" + r["PositionCode"].ToString() + aft + "", "EmployeeName"))
                    {
                        anode1 = new TreeNode(r1["EmployeeName"].ToString() + " (" + r1["EmployeeCode"].ToString() + ")");
                        anode1.Tag = r["PositionCode"].ToString() + ":" + r1["EmployeeCode"].ToString();
                        anode.Nodes.Add(anode1);
                    }
                }
                treeEmployee.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void gridView_Employee_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Bạn nhập thiếu thông tin khi thêm nhân viên!.\t\n- YES: Bổ sung thêm\t\n- NO: Xóa nhập lại\t\n";
        }

        private void gridControl_Employee_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView_Employee.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa nhân viên này hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                {
                    try
                    {
                        if (EmployeeBLL.DelEmployee(gridView_Employee.GetRowCellValue(gridView_Employee.FocusedRowHandle, "EmployeeCode").ToString()) >= 1)
                            this.LoadDataEmployee();
                    }
                    catch { return; }
                }
            }
        }

        private void gridView_Employee_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {

                GridView view = sender as GridView;
                int rowfocus = e.RowHandle;
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_EmployeeName))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_EmployeeName, "Họ tên nhân viên không được để trống!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_EmployeeUsername))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_EmployeeName, "Tên đăng nhập được để trống!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_EmployeePass))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_EmployeeName, "Mật khẩu không được để trống!");
                }
                if (string.IsNullOrEmpty(Convert.ToString(view.GetRowCellValue(rowfocus, col_Employee_Sex))))
                {
                    e.Valid = false;
                    view.SetColumnError(col_EmployeeName, "Chưa chọn giới tính!");
                }
                if (e.Valid)
                {
                    EmployeeInf inf = new EmployeeInf();
                    inf.EmployeeCode = gridView_Employee.GetRowCellValue(e.RowHandle, "EmployeeCode").ToString();
                    inf.EmployeeName = gridView_Employee.GetRowCellValue(e.RowHandle, "EmployeeName").ToString();
                    if (gridView_Employee.GetRowCellValue(e.RowHandle, "Sex").ToString() != "")
                        inf.Sex = int.Parse(gridView_Employee.GetRowCellValue(e.RowHandle, "Sex").ToString());
                    inf.Mobile = gridView_Employee.GetRowCellValue(e.RowHandle, "Mobile").ToString();
                    inf.IDCard = gridView_Employee.GetRowCellValue(e.RowHandle, "IDCard").ToString();
                    inf.Address = gridView_Employee.GetRowCellValue(e.RowHandle, "Address").ToString();
                    inf.Birthday = DateTime.Parse(gridView_Employee.GetRowCellValue(e.RowHandle, "Birthday").ToString());
                    inf.PositionCode = int.Parse(gridView_Employee.GetRowCellValue(e.RowHandle, "PositionCode").ToString());
                    inf.CreateDate = DateTime.Now;
                    inf.Username = gridView_Employee.GetRowCellValue(e.RowHandle, "Username").ToString();
                    inf.Password = gridView_Employee.GetRowCellValue(e.RowHandle, "Password").ToString();
                    inf.DepartmentCode = gridView_Employee.GetRowCellValue(e.RowHandle, "DepartmentCode").ToString();
                    if (gridView_Employee.GetRowCellValue(e.RowHandle, "OffWork").ToString() != "")
                        inf.OffWork = int.Parse(gridView_Employee.GetRowCellValue(e.RowHandle, "OffWork").ToString());
                    else
                        inf.OffWork = 0;
                    inf.EmployeeGroupID = int.Parse(gridView_Employee.GetRowCellValue(e.RowHandle, "EmployeeGroupID").ToString());
                    if (e.RowHandle < 0)
                    {
                        if (EmployeeBLL.InsEmployee(inf) == 1)
                        {
                            XtraMessageBox.Show("Thêm mới nhân viên thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm nhân viên thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (EmployeeBLL.InsEmployee(inf) == 1)
                        {
                            XtraMessageBox.Show("Cập nhật nhân viên thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Cập nhật nhân viên thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    this.LoadDataEmployee();
                }
            }
            catch (Exception) { }
        }

        private void butQuyen_All_Click(object sender, EventArgs e)
        {
            try
            {
                string employeeCode = string.Empty;
                int i = treeEmployee.SelectedNode.Parent == null ? 0 : 1;
                employeeCode = treeEmployee.SelectedNode.Tag.ToString().Split(':')[i];
                if (employeeCode != string.Empty)
                {
                    this.butQuyen_All.Checked = !butQuyen_All.Checked;
                    this.butQuyen_All.ToolTipText = butQuyen_All.Checked ? "Bỏ chọn tất cả" : "Chọn tất cả";
                    this.f_Chon_All();
                }
                else
                {
                    XtraMessageBox.Show(" Chọn user cần phân quyền sử dụng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch { return; }
        }

        private void ttQuyen_Luu_Click(object sender, EventArgs e)
        {
            this.ttQuyen_Luu.Enabled = false;
            this.Cursor = Cursors.AppStarting;
            try
            {
                string susercode = "";
                try
                {
                    int i = treeEmployee.SelectedNode.Parent == null ? 0 : 1;
                    susercode = treeEmployee.SelectedNode.Tag.ToString().Split(':')[i];
                }
                catch
                {
                    susercode = "";
                }
                if (susercode != "" && susercode != "?")
                {
                    MenuSecurityBLL.DelMenuSecurity(susercode);
                    if (this.tableSetQuyen.Select("chon=1").Length > 0)
                    {
                        DataTable dtTemp = this.tableSetQuyen.Select("chon=1").CopyToDataTable();
                        foreach (DataRow r in dtTemp.Rows)
                        {
                            MenuSecurityInf inf = new MenuSecurityInf();
                            inf.MenuCode = r["menucode"].ToString();
                            inf.MenuName = r["menuname"].ToString();
                            inf.EmployeeCode = susercode;
                            MenuSecurityBLL.InsMenuSecurity(inf);
                        }
                        XtraMessageBox.Show(" Cập nhật thành công phân quyền chức năng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show(" User chưa chọn quyền chức năng cho nhân viên !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch
            {
            }
            finally
            {
                this.Cursor = Cursors.Default;
                ttQuyen_Luu.Enabled = true;
            }
        }

        private void butQuyenkp_all_Click(object sender, EventArgs e)
        {
            try
            {
                butQuyenkp_all.Checked = !butQuyenkp_all.Checked;
                butQuyenkp_all.ToolTipText = butQuyenkp_all.Checked ? "Bỏ chọn tất cả" : "Chọn tất cả";
                if (butQuyenkp_all.Checked)
                    checklistKhoaphong.CheckAll();
                else
                    checklistKhoaphong.UnCheckAll();
            }
            catch { }
        }

        private string[] Arrtemp;
        private void SelectDepartment(string employeeCode)
        {
            try
            {
                checklistKhoaphong.UnCheckAll();
                List<EmployeeInf> lstEmploy = new List<EmployeeInf>();
                lstEmploy = EmployeeBLL.ListEmployee(employeeCode);
                foreach (var dr in lstEmploy)
                {
                    Arrtemp = dr.PermissionDepart.Split(',');
                }
                for (int i = 0; i < checklistKhoaphong.ItemCount; i++)
                {
                    for (int j = 0; j < Arrtemp.Length; j++)
                    {
                        if (checklistKhoaphong.GetItemValue(i).ToString() == Arrtemp[j].ToString())
                        {
                            checklistKhoaphong.SetItemChecked(i, true);
                            break;
                        }
                    }
                }
            }
            catch { }
        }

        private string[] ArrtempRep;
        private void SelectRepository(string employeeCode)
        {
            try
            {
                checklistKho.UnCheckAll();
                List<EmployeeInf> lstRep = new List<EmployeeInf>();
                lstRep = EmployeeBLL.ListEmployee(employeeCode);
                foreach (var dr in lstRep)
                {
                    ArrtempRep = dr.PermissionRepository.Split(',');
                }
                for (int i = 0; i < checklistKho.ItemCount; i++)
                {
                    for (int j = 0; j < ArrtempRep.Length; j++)
                    {
                        if (checklistKho.GetItemValue(i).ToString() == ArrtempRep[j].ToString())
                        {
                            checklistKho.SetItemChecked(i, true);
                            break;
                        }
                    }
                }
            }
            catch { }
        }

        private void ttQuyenKP_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                string sUserSelect = treeEmployee.SelectedNode.Tag.ToString().Split(':')[treeEmployee.SelectedNode.Parent == null ? 0 : 1];
                string stemp = "";
                for (int i = 0; i < checklistKhoaphong.ItemCount; i++)
                {
                    if (checklistKhoaphong.GetItemChecked(i))
                        stemp += checklistKhoaphong.GetItemValue(i).ToString() + ",";
                }
                if (EmployeeBLL.UpdPermissionDepart(sUserSelect, stemp.TrimEnd(',')) > 0)
                {
                    XtraMessageBox.Show(" Cập nhật thành công phân quyền khoa phòng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    XtraMessageBox.Show(" Phân quyền cập nhật không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch { }
        }

        private void ttQuyenKP_Kho_Click(object sender, EventArgs e)
        {
            try
            {
                string sUserSelect = treeEmployee.SelectedNode.Tag.ToString().Split(':')[treeEmployee.SelectedNode.Parent == null ? 0 : 1];
                string stemp = "";
                for (int i = 0; i < checklistKho.ItemCount; i++)
                {
                    if (checklistKho.GetItemChecked(i))
                        stemp += checklistKho.GetItemValue(i).ToString() + ",";
                }
                if (EmployeeBLL.UpdPermissionRepository(sUserSelect, stemp.TrimEnd(',')) > 0)
                {
                    XtraMessageBox.Show(" Cập nhật thành công phân quyền kho!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    XtraMessageBox.Show(" Phân quyền cập nhật không thành công!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch { }
        }

        private void butQuyenKho_all_Click(object sender, EventArgs e)
        {
            try
            {
                butQuyenKho_all.Checked = !butQuyenKho_all.Checked;
                butQuyenKho_all.ToolTipText = butQuyenKho_all.Checked ? "Bỏ chọn tất cả" : "Chọn tất cả";
                if (butQuyenKho_all.Checked)
                    checklistKho.CheckAll();
                else
                    checklistKho.UnCheckAll();
            }
            catch { }
        }

        private void treeAuthor_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
                {
                    this.f_Chon_Quyen(e.Node, e.Node.Checked);
                }
                if (this.tableSetQuyen.Select("menucode='" + e.Node.Name.ToString() + "'").Length <= 0)
                {
                    DataRow r = this.tableSetQuyen.NewRow();
                    r[0] = 0;
                    r["menucode"] = e.Node.Name.ToString();
                    r["menuname"] = e.Node.Text.ToString();
                    r["chon"] = e.Node.Checked ? 1 : 0;
                    r["chitiet"] = "000" + r["chon"].ToString() + "00";
                    this.tableSetQuyen.Rows.Add(r);
                }
                else
                {
                    string atmp = "";
                    DataRow r1 = this.tableSetQuyen.Select("menucode='" + e.Node.Name.ToString() + "'")[0];
                    if (e.Node.Nodes.Count > 0)
                    {
                        this.tableSetQuyen.Rows.Remove(r1);
                    }
                    else
                    {
                        atmp = r1["chitiet"].ToString().PadRight(6, '0');
                        r1["chon"] = e.Node.Checked ? 1 : 0;
                        r1["chitiet"] = atmp.Substring(0, 3) + r1["chon"].ToString() + atmp.Substring(4);
                    }
                }
                this.lbQuyen.Text = "Chức năng sử dụng (" + this.tableSetQuyen.Select("chon=1").Length.ToString() + "/" + this.countItemAll.ToString() + ")";
            }
            catch
            {
                return;
            }
        }

        private void treeAuthor_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                this.f_Set_Quyen_Chitiet();
                e.Node.ForeColor = Color.Red;
            }
            catch { return; }
        }

        private void treeAuthor_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                treeAuthor.SelectedNode.ForeColor = Color.Black;
            }
            catch
            {
                return;
            }
        }

        private void treeAuthor_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                this.treeAuthor.SelectedNode.ForeColor = Color.Black;
            }
            catch
            {
                return;
            }
        }

        private void treeEmployee_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                treeEmployee.SelectedNode.ForeColor = Color.Black;
            }
            catch
            {
            }
        }

        private void treeEmployee_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                this.Starting = new DevExpress.Utils.WaitDialogForm("Loading...", "Bệnh viện điện tử .NET");
                if (this.tableSetQuyen != null)
                    this.tableSetQuyen.Clear();
                string userID = treeEmployee.SelectedNode.Tag.ToString().Split(':')[treeEmployee.SelectedNode.Parent == null ? 0 : 1];
                this.SelectDepartment(userID);
                this.SelectRepository(userID);
                this.f_Load_Quyen(false);
                this.butQuyen_All.Checked = false;
                e.Node.ForeColor = Color.Red;
                this.Starting.Close();
            }
            catch
            {
            }
        }

        private void f_Set_Quyen_Chitiet()
        {
            try
            {
                string atmp = "";
                try
                {
                    atmp = this.tableSetQuyen.Select("menucode='" + treeAuthor.SelectedNode.Name.ToString() + "'")[0]["chitiet"].ToString().Trim();
                }
                catch
                {
                }
                atmp = atmp.PadRight(6, '0');
            }
            catch
            {
            }
        }

        private bool f_Chon(string v_menuname)
        {
            bool art = false;
            try
            {
                art = this.tableSetQuyen.Select("menucode='" + v_menuname + "'")[0]["chon"].ToString() == "1";
            }
            catch
            {
                art = false;
            }
            return art;
        }

        private void f_Chon_Quyen(TreeNode v_node, bool v_bool)
        {
            try
            {
                foreach (TreeNode anode in v_node.Nodes)
                {
                    anode.Checked = v_bool;
                    if (anode.Nodes.Count > 0)
                    {
                        f_Chon_Quyen(anode, v_bool);
                    }
                }
            }
            catch
            {
            }
        }

        private void f_Chon_All()
        {
            try
            {
                foreach (TreeNode anode in treeAuthor.Nodes)
                {
                    anode.Checked = butQuyen_All.Checked;
                    if (anode.Nodes.Count > 0)
                    {
                        f_Chon_Quyen(anode, butQuyen_All.Checked);
                    }
                }
            }
            catch
            {
            }
        }

        private void f_Load_Quyen(bool boolDone)
        {
            try
            {
                string aid = "";
                try
                {
                    aid = treeEmployee.SelectedNode.Tag.ToString().Split(':')[treeEmployee.SelectedNode.Parent == null ? 0 : 1];
                }
                catch
                {
                    aid = "";
                }
                if (boolDone)
                    this.tableSetQuyen = this.tableCoppy;
                else 
                    this.tableSetQuyen = MenuSecurityBLL.DTMenuSecurityForUser(aid);
                
                foreach (TreeNode anode in treeAuthor.Nodes)
                {
                    anode.Checked = f_Chon(anode.Name.ToString());
                    try
                    {
                        if (this.tableSetQuyen.Select("menucode='" + anode.Name.ToString() + "'").Length <= 0 && anode.Nodes.Count <= 0)
                        {
                            DataRow r = this.tableSetQuyen.NewRow();
                            r[0] = 0;
                            r["menucode"] = anode.Name.ToString();
                            r["menuname"] = anode.Text.ToString();
                            r["chon"] = 0;
                            r["chitiet"] = "000" + r["chon"].ToString() + "00";
                            this.tableSetQuyen.Rows.Add(r);
                        }
                    }
                    catch
                    {
                    }
                    if (anode.Nodes.Count > 0)
                    {
                        if (this.tableSetQuyen.Select("menucode='" + anode.Tag.ToString() + "'").Length > 0)
                        {
                            DataRow r1 = this.tableSetQuyen.Select("menucode='" + anode.Name.ToString() + "'")[0];
                            this.tableSetQuyen.Rows.Remove(r1);
                        }
                        this.f_Set_Quyen(anode);
                    }
                }
                //this.f_Set_Quyen_Chitiet();
            }
            catch
            {
            }
        }

        private void f_Set_Quyen(TreeNode v_node)
        {
            try
            {
                foreach (TreeNode anode in v_node.Nodes)
                {
                    anode.Checked = f_Chon(anode.Name.ToString());
                    try
                    {
                        if (this.tableSetQuyen.Select("menucode='" + anode.Name.ToString() + "'").Length <= 0 && anode.Nodes.Count <= 0)
                        {
                            DataRow r = this.tableSetQuyen.NewRow();
                            r[0] = 0;
                            r["menucode"] = anode.Name.ToString();
                            r["chon"] = 0;
                            r["chitiet"] = "000" + r["chon"].ToString() + "00";
                            this.tableSetQuyen.Rows.Add(r);
                        }
                    }
                    catch
                    {
                    }
                    if (anode.Nodes.Count > 0)
                    {
                        if (this.tableSetQuyen.Select("menucode='" + anode.Name.ToString() + "'").Length > 0)
                        {
                            DataRow r1 = this.tableSetQuyen.Select("menucode='" + anode.Name.ToString() + "'")[0];
                            this.tableSetQuyen.Rows.Remove(r1);
                        }
                        f_Set_Quyen(anode);
                    }
                }
            }
            catch
            {
            }
        }

        private void butTim_Click(object sender, EventArgs e)
        {
            this.NodeTextSearch();
        }

        private void NodeTextSearch()
        {
            this.ClearColorSelected();
            this.FindByText();
        }
        private void ClearColorSelected()
        {
            TreeNodeCollection nodes = this.treeEmployee.Nodes;
            foreach (TreeNode n in nodes)
            {
                this.ClearRecursive(n);
            }
        }

        private void FindByText()
        {
            TreeNodeCollection nodes = this.treeEmployee.Nodes;
            foreach (TreeNode n in nodes)
            {
                this.FindRecursive(n);
            }
        }

        private void FindRecursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Text.ToLower().IndexOf(this.txtTim.Text.ToLower().Trim()) != -1)
                    tn.BackColor = Color.Yellow;
                FindRecursive(tn);
            }
        }

        private void ClearRecursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                tn.BackColor = Color.White;
                ClearRecursive(tn);
            }
        }

        private void ttUser_Refresh_Click(object sender, EventArgs e)
        {
            this.fLoadEmployeePosition(string.Empty);
        }

        private void txtTim_Enter(object sender, EventArgs e)
        {
            this.txtTim.Text = string.Empty;
        }

        private void LoadDataEmployee()
        {
            this.gridControl_Employee.DataSource = EmployeeBLL.DTEmployee(string.Empty, this.chkAll.Checked);
        }

        private void butReload_Click(object sender, EventArgs e)
        {
            this.LoadDataEmployee();
            this.fLoadEmployeePosition(string.Empty);
        }
        
    }
}