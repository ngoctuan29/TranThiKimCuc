using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using Ps.Clinic.ViewPopup;
using Ps.Clinic.Master;
using Ps.Clinic.Entry;
using Ps.Clinic.Statistics;
using DevExpress.XtraGrid.Views.Grid;
using System.Net;
using DevExpress.XtraTab;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using System.Management;
using System.Reflection;
using System.Diagnostics;
using DevExpress.XtraReports.UI;
using System.Threading;

namespace Ps.Clinic.Security
{
    public partial class frmStartupiHIS_BD_SongThan : RibbonForm
    {
        private DevExpress.Utils.WaitDialogForm Starting = null;
        private string ucLogin = string.Empty;
        private string ucFullName = string.Empty;
        private string shiftWork = string.Empty;
        private DataTable tableMenu = new DataTable();
        private DateTime dtWorking = new DateTime();
        private bool timeout = false;
        private int timedur = 0;
        private DateTime datetimelogin;
        private string CaLamViec = "AM";
        private bool QuaCa = false;
        public frmStartupiHIS_BD_SongThan()
        {
            InitializeComponent();
            InitSkinGallery();
            tableMenu.Columns.Add(new DataColumn("MenuCode", typeof(string)));
            tableMenu.Columns.Add(new DataColumn("MenuName", typeof(string)));
        }
        private void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(ribbonGalleryBarItem, true);
        }
        private void Startup_Load(object sender, EventArgs e)
        {
            try
            {

                Utils lib = new Utils();
                if (!lib.CheckConnection())
                {
                    frmConfig frm = new frmConfig();
                    frm.ShowDialog(this);
                    if (frm.isConnected)
                        this.GetLogin();
                }
                else
                {
                    this.GetLogin();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi:" + ex.Message + "!\t\n- Yêu cầu đăng nhập lại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        //private void CheckQuaCaTruc()
        //{
        //    while (!this.QuaCa)
        //    {
        //        Thread.Sleep(10000);
        //    }
        //    XtraMessageBox.Show("Đã qua ca làm việc! Vui lòng đăng nhập lại", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    Application.Restart();
        //}
        private string KiemTraCa()
        {
            var firstInfo = ClinicInformationBLL.ObjInformation(1);
            string timeRuntime = Utils.TimeServer();
            DateTime ca1from = Convert.ToDateTime(firstInfo.WorkingTimeLineFrom01);
            DateTime ca1to = Convert.ToDateTime(firstInfo.WorkingTimeLineTo01);
            DateTime ca2from = Convert.ToDateTime(firstInfo.WorkingTimeLineFrom02);
            DateTime ca2to = Convert.ToDateTime(firstInfo.WorkingTimeLineTo02);
            DateTime ca3from = Convert.ToDateTime(firstInfo.WorkingTimeLineFrom03);
            DateTime ca3to = Convert.ToDateTime(firstInfo.WorkingTimeLineTo03);
            DateTime timeht = Convert.ToDateTime(timeRuntime);

            if (ca3to < ca3from)
                if (timeht > ca3from) ca3to = ca3to.AddDays(1);
                else ca3from = Convert.ToDateTime("00:00");
            if (ca2to < ca2from)
                if (timeht > ca2from) ca2to = ca2to.AddDays(1);
                else ca2from = Convert.ToDateTime("00:00");
            if (ca1to < ca1from)
                if (timeht > ca1from) ca1to = ca1to.AddDays(1);
                else ca1from = Convert.ToDateTime("00:00");


            if (timeht >= ca1from && timeht <= ca1to)
                return "AM";
            else if (timeht >= ca2from && timeht <= ca2to)
                return "PM";
            else if (timeht >= ca3from && timeht <= ca3to)
                return "EV";
            else
                return "AM";
        }
        private void CheckTheNewDay()
        {
            while (!this.timeout)
            {
                Thread.Sleep(30000);
            }
            XtraMessageBox.Show("Thời gian hệ thống thay đổi, vui lòng đăng nhập lại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Application.Restart();
            this.timeout = false;
        }
        private void CheckTheNewCa()
        {
            while (!this.QuaCa)
            {
                Thread.Sleep(30000);
            }
            XtraMessageBox.Show("Tới thời điểm giao ca, vui lòng đăng nhập lại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Application.Restart();
            this.QuaCa = false;
        }
        private void GetLogin()
        {
            string pathName = string.Empty;
            string versionCurrent = string.Empty;
            if (this.CheckAutoUpdate(ref pathName, ref versionCurrent) && !string.IsNullOrEmpty(pathName))
            {
                if (System.IO.File.Exists(pathName + "\\UpdatePowerMed.exe"))
                {
                    System.Diagnostics.Process.Start(pathName + "\\UpdatePowerMed.exe");
                    Application.Exit();
                }
                else
                {
                    XtraMessageBox.Show(" Không tồn tại đường dẫn: " + pathName + "\\UpdatePowerMed.exe", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            this.datetimelogin = DateTime.Now.Date;
            this.CaLamViec = KiemTraCa();
            frmLogin frm = new frmLogin();
            frm.lbVersion.Text = versionCurrent;
            frm.ShowDialog(this);
            if (!frm.cancel)
            {
                this.ucLogin = frm._EmployeeCode;
                this.barUserInfo.Caption = "User: " + frm._fullname;
                this.shiftWork = frm.shiftCode;
                this.dtWorking = frm.dtimeWorked;
                if (!string.IsNullOrEmpty(frm._username) && ucLogin.Equals("powersoft0313529521"))
                {
                    this.GetInfoDefault();
                }
                else
                {
                    if (ucLogin != string.Empty)
                    {
                        bool bCheck = false;
                        DataTable tableMenuEmployee = new DataTable();
                        tableMenuEmployee = MenuSecurityBLL.DTMenuSecurityForUser(ucLogin, ref bCheck);
                        if (tableMenuEmployee.Rows.Count > 0 && bCheck == true)
                        {
                            foreach (DataRow dr in tableMenuEmployee.Rows)
                            {
                                this.SetMenu(dr["MenuCode"].ToString());
                            }
                            if (this.rib_NghiepVu.Visible)
                                this.ribbonMenu.SelectedPage = this.rib_NghiepVu;
                            else if (this.rib_BaoCao.Visible)
                                this.ribbonMenu.SelectedPage = this.rib_BaoCao;
                            else if (this.rib_DanhMuc.Visible)
                                this.ribbonMenu.SelectedPage = this.rib_DanhMuc;
                            else if (this.rib_TienIch.Visible)
                                this.ribbonMenu.SelectedPage = this.rib_TienIch;
                            try
                            {
                                
                                Thread clientprocess = new Thread(this.CheckTheNewDay);
                                
                                clientprocess.IsBackground = true;
                                clientprocess.Start();
                                Thread clientprocessCa = new Thread(this.CheckTheNewCa);
                                clientprocessCa.IsBackground = true;
                                clientprocessCa.Start();
                                this.timer_Working.Start();
                            }
                            catch
                            { }
                        }
                        else
                        {
                            XtraMessageBox.Show(" Chưa được phân quyền !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Lỗi đăng nhập!\t\n- Yêu cầu đăng nhập lại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            else
                Application.Exit();
        }
        private void GetInfoDefault()
        {
            try
            {
                //this.InitSkinGallery();
                this.SetMenuEnable(true);
            }
            catch { }
        }
        public TreeNode GetMenu(ref Int32 countItemAll)
        {
            TreeNode anode;
            anode = new TreeNode("Tất cả");
            anode.Tag = "menuChucnang";
            anode.Name = "menuChucnang";
            anode.Text = "Tất cả";
            Int32 countItem = 0;
            Int32 countPage = 0;
            Int32 countGroup = 0;
            foreach (RibbonPage mi in this.ribbonMenu.Pages)
            {
                RibbonPage ribbon = (RibbonPage)(mi);
                if (this.ribbonMenu.Pages.Count > 0)
                {
                    this.GetPermisonInPage(anode, ribbon, ref countItem, ref countPage, ref countGroup);
                }
            }
            anode.ExpandAll();
            countItemAll = countItem + countPage + countGroup + anode.Nodes.Count;
            return anode;
        }
        public void GetPermisonInPage(TreeNode Node, RibbonPage page, ref Int32 countItem, ref Int32 countPage, ref Int32 countGroup)
        {
            TreeNode subnode = new TreeNode();
            if (page != null)
            {
                subnode = new TreeNode(page.Text);
                subnode.Name = page.Name;
                Node.Nodes.Add(subnode);
                if (page.Groups != null)
                {
                    foreach (RibbonPageGroup pagegroup in page.Groups)
                    {
                        countGroup++;
                        this.GetPermisonInPageGroup(subnode, pagegroup, ref countItem, ref countPage);
                    }
                }
            }
        }
        public void GetPermisonInPageGroup(TreeNode Node, RibbonPageGroup page, ref Int32 countItem, ref Int32 countPage)
        {
            TreeNode anode1 = new TreeNode();
            if (page != null)
            {
                anode1 = new TreeNode(page.Text);
                anode1.Name = page.Name;
                Node.Nodes.Add(anode1);

                if (page.ItemLinks != null)
                {
                    foreach (BarItemLink Item in page.ItemLinks)
                    {
                        countPage++;
                        GetPermisonInBarItemLink(anode1, Item, ref countItem);
                    }
                }
            }
        }
        public void GetPermisonInBarItemLink(TreeNode Node, BarItemLink page, ref Int32 countItem)
        {
            TreeNode anode1 = new TreeNode();
            BarItem barItem = page.Item;
            if (barItem != null)
            {
                anode1 = new TreeNode(barItem.Caption);
                anode1.Name = barItem.Name;
                Node.Nodes.Add(anode1);

                if (barItem.GetType().FullName == "DevExpress.XtraBars.BarSubItem")
                {
                    BarSubItem mBarSubItem = (BarSubItem)barItem;
                    foreach (BarItemLink mSubLink in mBarSubItem.ItemLinks)
                    {
                        countItem ++;
                        GetPermisonInBarItemLink(anode1, mSubLink, ref countItem);
                    }
                }
            }  
        }
        public void SetMenuEnable(bool action)
        {
            foreach (RibbonPage mi in this.ribbonMenu.Pages)
            {
                RibbonPage ribbon = (RibbonPage)(mi);
                if (this.ribbonMenu.Pages.Count > 0)
                {
                    SetPermisonInPageEnable(action, ribbon);
                }
                mi.Visible = action;
            }
        }
        public void SetPermisonInPageEnable(bool action, RibbonPage page)
        {
            if (page.Groups != null)
            {
                foreach (RibbonPageGroup pagegroup in page.Groups)
                {
                    this.SetPermisonInPageGroupEnable(action, pagegroup);
                    pagegroup.Visible = action;
                } 
            }
        }
        public void SetPermisonInPageGroupEnable(bool action, RibbonPageGroup pageGroup)
        {
            if (pageGroup.ItemLinks != null)
            {
                foreach (BarItemLink Item in pageGroup.ItemLinks)
                {
                    this.SetPermisonInBarItemLinkEnable(action, Item);
                    Item.Visible = action;
                }
            }
        }
        public void SetPermisonInBarItemLinkEnable(bool action, BarItemLink page)
        {
            try
            {
                BarItem barItems = page.Item;
                if (barItems != null)
                {
                    barItems.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                if (barItems.GetType().FullName == "DevExpress.XtraBars.BarSubItem")
                {
                    BarSubItem mBarSubItem = (BarSubItem)barItems;
                    foreach (BarItemLink mSubLink in mBarSubItem.ItemLinks)
                    {
                        tableMenu.Rows.Add(mSubLink.Item.Name, mSubLink.Item.Caption);
                        SetPermisonInBarItemLinkEnable(action, mSubLink);
                    }
                }
                else
                {
                    tableMenu.Rows.Add(barItems.Name, barItems.Caption);
                }
            }
            catch { }
        }
        public void SetMenu(string menuName)
        {
            foreach (RibbonPage mi in this.ribbonMenu.Pages)
            {
                bool visibleMenu = false;
                RibbonPage ribbon = (RibbonPage)(mi);
                if (this.ribbonMenu.Pages.Count > 0)
                {
                    this.SetPermisonInPage(menuName, ribbon, ref visibleMenu);
                }
                if (visibleMenu)
                {
                    mi.Visible = true;
                    break;
                }
            }
        }
        public void SetPermisonInPage(string menuname, RibbonPage page, ref bool visibleMenu)
        {
            if (page.Groups != null)
            {
                foreach (RibbonPageGroup pagegroup in page.Groups)
                {
                    this.SetPermisonInPageGroup(menuname, pagegroup, ref visibleMenu);
                    if (visibleMenu)
                    {
                        pagegroup.Visible = true;
                        break;
                    }
                }
                if (visibleMenu)
                    page.Visible = true;
            }
        }
        public void SetPermisonInPageGroup(string menuname, RibbonPageGroup page, ref bool visiblePage)
        {
            if (page != null)
            {
                if (page.Name == menuname)
                {
                    page.Visible = true;
                }
                if (page.ItemLinks != null)
                {
                    foreach (BarItemLink Item in page.ItemLinks)
                    {
                        this.SetPermisonInBarItemLink(menuname, Item, ref visiblePage);
                        if (visiblePage)
                            break;
                    }
                }
            }
        }
        public void SetPermisonInBarItemLink(string menuname, BarItemLink page, ref bool visibleGroup)
        {
            BarItem barItem = page.Item;
            if (barItem != null)
            {
                if (barItem.Name == menuname)
                {
                    barItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    visibleGroup = true;
                }
                if (barItem.GetType().FullName == "DevExpress.XtraBars.BarSubItem")
                {
                    BarSubItem mBarSubItem = (BarSubItem)barItem;
                    foreach (BarItemLink menuSubLink in mBarSubItem.ItemLinks)
                    {
                        SetPermisonInBarItemLink(menuname, menuSubLink, ref visibleGroup);
                        if (visibleGroup)
                        {
                            barItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            break;
                        }
                    }
                }
                
            }
        }

        protected bool CheckUrlStatus(string Website)
        {
            try
            {
                var request = WebRequest.Create(Website) as HttpWebRequest;
                request.Method = "HEAD";
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch
            {
                return false;
            }
        }

        //private void InitSkinGallery()
        //{
        //    SkinHelper.InitSkinGallery(rgbiSkins, true);
        //}

        public void TabCreating(XtraTabControl TabControl, string Text, Form Form)
        {
            int Index = this.CheckExists(TabControl, Text);
            if (Index >= 0)
            {
                TabControl.SelectedTabPage = TabControl.TabPages[Index];
                TabControl.SelectedTabPage.Text = Text;
            }
            else
            {
                XtraTabPage TabPage = new XtraTabPage { Text = Text };
                TabPage.AutoScroll = true;
                TabControl.TabPages.Add(TabPage);
                TabControl.SelectedTabPage = TabPage;
                //TabControl.AppearancePage.HeaderActive.ForeColor = Color.Red;
                TabControl.AppearancePage.HeaderActive.Font = new Font(TabControl.AppearancePage.HeaderActive.Font, FontStyle.Bold);
                Form.TopLevel = false;
                Form.Parent = TabPage;
                Form.Dock = DockStyle.Fill;
                Form.Show();
            }
        }

        private int CheckExists(XtraTabControl TabControlName, string TabName)
        {
            int temp = -1;
            for (int i = 0; i < TabControlName.TabPages.Count; i++)
            {
                if (TabControlName.TabPages[i].Text == TabName)
                {
                    temp = i;
                    break;
                }
            }
            return temp;
        }

        private string ISDBNULL2STRING(object a, object b)
        {
            if (a == DBNull.Value)
            {
                return string.Empty;
            }
            else
                return Convert.ToString(a);
        }

        private decimal ISDBNULL2DECIMAL(object a, object b)
        {
            if (a == DBNull.Value)
            {
                return Convert.ToDecimal(b);
            }
            else
                return Convert.ToDecimal(a);
        }

        private void UpdateMenuControl()
        {
            try
            {
                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(3);
                if (objSys.Values == 1)
                {
                    MenuListBLL.DelAll_MenuList();
                    foreach (DataRow dr in tableMenu.Rows)
                    {
                        MenuListInf infmenu = new MenuListInf();
                        infmenu.MenuCode = dr["menucode"].ToString();
                        infmenu.MenuName = dr["menuname"].ToString();
                        MenuListBLL.InsMenuList(infmenu);
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show("Máy chủ CSDL SQL SERVER chưa khởi động !\t\n-Hãy khởi động lại máy tính và thử lại.\t\n-Hoặc liên hệ admin: NGUYỄN DUY NAM(Email: duynam.ceo@gmail.com - Di động: 090 2726 381)", "Bệnh viện điện tử .NET");
                Application.Exit();
            }
        }
        
        private void barItem_Exit_ItemClick(object sender, ItemClickEventArgs e)
        {
            var iExits = XtraMessageBox.Show("Bạn có muốn thoát chương trình không ?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (iExits == System.Windows.Forms.DialogResult.Yes)
            {
                this.Dispose();
                Application.Exit();
            }
        }
        
        private void xTabMain_CloseButtonClick(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraTab.XtraTabControl xtab = (DevExpress.XtraTab.XtraTabControl)sender;
                if (xtab.TabPages.Count == 1) return;
                int i = xtab.SelectedTabPageIndex;
                xtab.TabPages.RemoveAt(xtab.SelectedTabPageIndex);
                xtab.SelectedTabPageIndex = i - 1;
            }
            catch { }
        }

        public void CloseTab(string text)
        {
            for (int i = 0; i < this.xTabMain.TabPages.Count; i++)
            {
                var tabPage = this.xTabMain.TabPages[i];
                if (tabPage.Text.ToLower() == text.ToLower())
                {
                    var ctrl = tabPage.Controls.Count > 0 ? tabPage.Controls[0] : null;
                    if (ctrl != null)
                    {
                        this.xTabMain.TabPages.Remove(tabPage);
                        this.xTabMain.Dispose();
                    }
                }
            }
            
        }
                
        private void butInfoCompany_ItemClick(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.powersoft.vn");
        }

        public void CloseTabALL()
        {
            for (int i = 0; i < this.xTabMain.TabPages.Count; i++)
            {
                var tabPage = this.xTabMain.TabPages[i];
                if (tabPage.Name != "mainPage")
                {
                    var ctrl = tabPage.Controls.Count > 0 ? tabPage.Controls[0] : null;
                    if (ctrl != null)
                    {
                        this.xTabMain.TabPages.Remove(tabPage);
                    }
                }
            }
        }
               
        private void barItem_NhanBenh_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
                SystemParameterInf sys = SystemParameterBLL.ObjParameter(15);
                if (sys != null && sys.Values == 1)
                {
                    frmTiepDonBHYT frm = new frmTiepDonBHYT(this.ucLogin, this.shiftWork, this.dtWorking);
                    TabCreating(xTabMain, "Tiếp đón", frm);
                }
                else
                {
                    frmTiepDon frm = new frmTiepDon(this.ucLogin, this.shiftWork, this.dtWorking);
                    TabCreating(xTabMain, "Tiếp đón", frm);
                }
                Starting.Close();
            }
            catch { Starting.Close(); }
        }
        
        private void barItem_KhamBenh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            Starting.Close();
            string sMakp = string.Empty;
            string sNamekp = string.Empty;
            int iResult = CheckDepartment(1, ucLogin, ref sMakp, ref sNamekp);
            if (iResult == -2)
            {
                frmChonphongkham frphong = new frmChonphongkham(ucLogin, 1);
                frphong.ShowDialog(this);
                if (!string.IsNullOrEmpty(frphong.s_mapk))
                {
                    frmKhamBenh frm = new frmKhamBenh(frphong.s_mapk, ucLogin, frphong.s_namepk, frphong.employeeCodeDoctor, this.shiftWork, frphong.employeeCodeDoing, this.dtWorking);
                    TabCreating(xTabMain, frphong.s_namepk + " - B.S: " + frphong.employeeNameDoctor, frm);
                }
            }
            else if (iResult == -1)
            {
                XtraMessageBox.Show("Vui lòng xem lại quyền user và giới hạn chỉ định khoa phòng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                frmKhamBenh frm = new frmKhamBenh(sMakp, this.ucLogin, sNamekp, this.ucLogin, this.shiftWork, this.ucLogin, this.dtWorking);
                TabCreating(xTabMain, "Khám bệnh", frm);
            }
            //frmChiDinhTiepNhan frm = new frmChiDinhTiepNhan(this.ucLogin, this.shiftWork, this.dtWorking);
            //TabCreating(xTabMain, "Chỉ Định Khám Bệnh", frm);
        }

        private void barItem_SieuAm_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            
            
            string sMakp = string.Empty;
            string sNamekp = string.Empty;
            int iResult = CheckDepartment(5, ucLogin, ref sMakp, ref sNamekp);
            Starting.Close();
            if (iResult == -2)
            {
                frmChonphongkham frphong = new frmChonphongkham(ucLogin, 5);
                frphong.ShowDialog(this);
                if (!string.IsNullOrEmpty(frphong.s_mapk))
                {
                    try {
                        frmSieuAmGeneral frm = new frmSieuAmGeneral(frphong.s_mapk, ucLogin, 5, frphong.s_namepk, frphong.employeeCodeDoctor, this.shiftWork, this.dtWorking);
                        frm.ShowDialog();
                    }
                    catch(Exception ex) { }
                }
            }
            else if (iResult == -1)
            {
                XtraMessageBox.Show("Vui lòng xem lại quyền user và giới hạn chỉ định khoa phòng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                frmChonphongkham frphong = new frmChonphongkham(ucLogin, 5);
                frphong.ShowDialog(this);
                if (!string.IsNullOrEmpty(frphong.s_mapk))
                {
                    frmSieuAmGeneral frm = new frmSieuAmGeneral(frphong.s_mapk, ucLogin, 5, frphong.s_namepk, frphong.employeeCodeDoctor, this.shiftWork, this.dtWorking);
                    frm.ShowDialog();
                }
            }
        }

        private void barItem_NoiSoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            Starting.Close();
            string sMakp = string.Empty;
            string sNamekp = string.Empty;
            int iResult = CheckDepartment(6, ucLogin, ref sMakp, ref sNamekp);
            if (iResult == -2)
            {
                frmChonphongkham frphong = new frmChonphongkham(ucLogin, 6);
                frphong.ShowDialog(this);
                if (!string.IsNullOrEmpty(frphong.s_mapk))
                {
                    //frmNoiSoi frm = new frmNoiSoi(frphong.s_mapk, ucLogin, 6, frphong.s_namepk, frphong.employeeCodeDoctor, this.shiftWork, this.dtWorking);
                    //TabCreating(xTabMain, "Nội soi", frm);
                    frmNoiSoiGeneral frm = new frmNoiSoiGeneral(frphong.s_mapk, ucLogin, 6, frphong.s_namepk, frphong.employeeCodeDoctor, this.shiftWork, this.dtWorking);
                    frm.ShowDialog();
                }
            }
            else if (iResult == -1)
            {
                XtraMessageBox.Show("Vui lòng xem lại quyền user và giới hạn chỉ định khoa phòng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                frmChonphongkham frphong = new frmChonphongkham(ucLogin, 6);
                frphong.ShowDialog(this);
                if (!string.IsNullOrEmpty(frphong.s_mapk))
                {
                    //frmNoiSoi frm = new frmNoiSoi(frphong.s_mapk, ucLogin, 6, frphong.s_namepk, frphong.employeeCodeDoctor, this.shiftWork,this.dtWorking);
                    //TabCreating(xTabMain, "Nội soi", frm);
                    frmNoiSoiGeneral frm = new frmNoiSoiGeneral(frphong.s_mapk, ucLogin, 6, frphong.s_namepk, frphong.employeeCodeDoctor, this.shiftWork, this.dtWorking);
                    frm.ShowDialog();
                }
            }
        }

        private void barItem_XQuang_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            Starting.Close();

            string sMakp = string.Empty;
            string sNamekp = string.Empty;
            int iResult = CheckDepartment(3, ucLogin, ref sMakp, ref sNamekp);
            if (iResult == -2)
            {
                frmChonphongkham frphong = new frmChonphongkham(ucLogin, 3);
                frphong.ShowDialog(this);
                if (!string.IsNullOrEmpty(frphong.s_mapk))
                {
                    frmXQuang frm = new frmXQuang(frphong.s_mapk, ucLogin, 3, frphong.s_namepk, frphong.employeeCodeDoctor, this.shiftWork, this.dtWorking);
                    TabCreating(xTabMain, "X-Quang", frm);
                }
            }
            else if (iResult == -1)
            {
                XtraMessageBox.Show("Vui lòng xem lại quyền user và giới hạn chỉ định khoa phòng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                frmChonphongkham frphong = new frmChonphongkham(ucLogin, 3);
                frphong.ShowDialog(this);
                if (!string.IsNullOrEmpty(frphong.s_mapk))
                {
                    frmXQuang frm = new frmXQuang(frphong.s_mapk, ucLogin, 3, frphong.s_namepk, frphong.employeeCodeDoctor, this.shiftWork, this.dtWorking);
                    TabCreating(xTabMain, "X-Quang", frm);
                }
            }
        }

        private void barItem_ICD10_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmChanDoan frm = new frmChanDoan();
            TabCreating(xTabMain, "Chẩn đoán ICD-10", frm);
            Starting.Close();
        }

        private void barItem_TrieuChungBenh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmTrieuChung frm = new frmTrieuChung();
            TabCreating(xTabMain, "Triệu chứng bệnh", frm);
            Starting.Close();
        }

        private void barItem_TienSuBenh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmTienSuBenh frm = new frmTienSuBenh(this.ucLogin);
            TabCreating(xTabMain, "Tiền sử bệnh", frm);
            Starting.Close();
        }

        private void barItem_LoiDan_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmLoiDan frm = new frmLoiDan();
            TabCreating(xTabMain, "Lời dặn", frm);
            Starting.Close();
        }

        private void barItem_PhongKham_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmDMKhoaphong frm = new frmDMKhoaphong(this.ucLogin);
            TabCreating(xTabMain, "Danh mục khoa phòng", frm);
            Starting.Close();
        }

        private void barItem_TiLeCoQuanBHYT_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmTiLeBHYT frm = new frmTiLeBHYT(this.ucLogin);
            TabCreating(xTabMain, "Khai báo tỉ lệ thẻ BHYT", frm);
            Starting.Close();
        }

        private void barItem_GioiHanBHYTChiTra_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmChiPhiBHYTTra frm = new frmChiPhiBHYTTra(this.ucLogin);
            TabCreating(xTabMain, "Giới hạn chi phí BHYT trả", frm);
            Starting.Close();
        }

        private void barItem_DKKCB_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmKCBBD frm = new frmKCBBD(this.ucLogin);
            TabCreating(xTabMain, "Đăng ký KCB BĐ", frm);
            Starting.Close();
        }

        private void barItem_ThongTinPK_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmCapNhatThongTin frm = new frmCapNhatThongTin(this.ucLogin);
            TabCreating(xTabMain, "Thông tin phòng khám", frm);
            Starting.Close();
        }

        private void barItem_PhanQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            Int32 countItemAll = 0;
            frmPhanQuyen frm = new frmPhanQuyen(this.GetMenu(ref countItemAll), countItemAll);
            TabCreating(xTabMain, "Quản lý nhân viên", frm);
            Starting.Close();
        }

        private void barItem_ThongSoHeThong_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmThongsohethong frm = new frmThongsohethong(this.ucLogin);
            TabCreating(xTabMain, "Thông số hệ thống", frm);
            Starting.Close();
        }

        private void barItem_DienTim_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
                Starting.Close();
                string sMakp = string.Empty;
                string sNamekp = string.Empty;
                int iResult = CheckDepartment(4, ucLogin, ref sMakp, ref sNamekp);
                if (iResult == -2)
                {
                    frmChonphongkham frphong = new frmChonphongkham(ucLogin, 4);
                    frphong.ShowDialog(this);
                    if (!string.IsNullOrEmpty(frphong.s_mapk))
                    {
                        frmDienTim frm = new frmDienTim(frphong.s_mapk, ucLogin, 4, frphong.s_namepk, frphong.employeeCodeDoctor, this.shiftWork, this.dtWorking);
                        TabCreating(xTabMain, "CĐHA - Thăm dò chức năng", frm);
                    }
                }
                else if (iResult == -1)
                {
                    XtraMessageBox.Show("Vui lòng xem lại quyền user và giới hạn chỉ định khoa phòng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    frmDienTim frm = new frmDienTim(sMakp, ucLogin, 4, sNamekp, this.ucLogin, this.shiftWork, this.dtWorking);
                    TabCreating(xTabMain, "CĐHA - Thăm dò chức năng", frm);
                }
            }
            catch { }
        }

        private void barItem_NhapKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmNhapKho frm = new frmNhapKho(this.ucLogin, this.shiftWork);
            TabCreating(xTabMain, "Nhập Kho", frm);
            Starting.Close();
        }

        private void barItem_DMLoaiVP_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmVienPhi frm = new frmVienPhi(this.ucLogin, this.dtWorking);
            TabCreating(xTabMain, "Khai Báo Dịch Vụ", frm);
            Starting.Close();
        }

        private void barItem_NhomVP_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmVP_DMNhomIn frm = new frmVP_DMNhomIn();
            TabCreating(xTabMain, "Nhóm Dịch Vụ", frm);
            Starting.Close();
        }

        private void barItem_LoaiVP_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmLoaiVienPhi frm = new frmLoaiVienPhi(ucLogin);
            TabCreating(xTabMain, "Loại Viện Phí", frm);
            Starting.Close();
        }

        private void barItem_GoiVP_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmDMGoi frm = new frmDMGoi(this.ucLogin);
            TabCreating(xTabMain, "Khai Báo Gói Dịch Vụ", frm);
            Starting.Close();
        }

        private void barItem_MauMoTa_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmMauMoTa frm = new frmMauMoTa(this.ucLogin);
            TabCreating(xTabMain, "Khai Báo Mẫu Mô Tả CĐHA", frm);
            Starting.Close();
        }

        private void barItem_VietTat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmDMVietTat frm = new frmDMVietTat(this.ucLogin);
            TabCreating(xTabMain, "Khai Báo Danh Mục Viết Tắt", frm);
            Starting.Close();
        }

        private void barItem_DonViDo_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmDMDonViDo frm = new frmDMDonViDo();
            TabCreating(xTabMain, "Đơn Vị Đo", frm);
            Starting.Close();
        }

        private void barItem_ThongSoXN_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmThongSoXN frm = new frmThongSoXN();
            TabCreating(xTabMain, "Thông Số Xét Nghiệm", frm);
            Starting.Close();
        }

        private void barItem_BoXN_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmBoXetNghiem frm = new frmBoXetNghiem(this.ucLogin);
            TabCreating(xTabMain, "Bộ Xét Nghiệm", frm);
            Starting.Close();
        }

        private void barItem_NhapKQXN_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmMauKQXN frm = new frmMauKQXN();
            TabCreating(xTabMain, "Mô Tả KQ Xét Nghiệm", frm);
            Starting.Close();
        }

        private void barItem_DMThuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmThuoc frm = new frmThuoc(this.ucLogin);
            TabCreating(xTabMain, "Thuốc - VTYT", frm);
            Starting.Close();
        }

        private void barItem_DMDVT_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmDonViTinh frm = new frmDonViTinh("I");
            TabCreating(xTabMain, "Đơn vị tính", frm);
            Starting.Close();
        }

        private void barItem_DMCachDung_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmCachDung frm = new frmCachDung();
            TabCreating(xTabMain, "Cách dùng thuốc", frm);
            Starting.Close();
        }

        private void barItem_DMPhanLoai_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmPhanLoaiThuoc frm = new frmPhanLoaiThuoc();
            TabCreating(xTabMain, "Phân loại thuốc", frm);
            Starting.Close();
        }

        private void barItem_DMDuongDung_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmDuongDung frm = new frmDuongDung();
            TabCreating(xTabMain, "Đường dùng thuốc", frm);
            Starting.Close();
        }

        private void barItem_NCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmNhaCungCap frm = new frmNhaCungCap();
            TabCreating(xTabMain, "Nhà cung cấp", frm);
            Starting.Close();
        }

        private void barItem_DMToaMau_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmToaMau frm = new frmToaMau(this.ucLogin);
            TabCreating(xTabMain, "Khai báo toa mẫu", frm);
            Starting.Close();
        }

        private void barItem_DMKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmDanhMucKho frm = new frmDanhMucKho(ucLogin);
            TabCreating(xTabMain, "Khai báo danh mục kho", frm);
            Starting.Close();
        }

        private void barItem_HSX_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmHangSanXuat frm = new frmHangSanXuat(ucLogin);
            TabCreating(xTabMain, "Khai báo hãng sản xuất", frm);
            Starting.Close();
        }

        private void barItem_ChuyenKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmXuatChuyenKho frm = new frmXuatChuyenKho(this.ucLogin);
            TabCreating(xTabMain, "Xuất chuyển kho", frm);
            Starting.Close();
        }

        private void barItem_NSX_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmNuocSanXuat frm = new frmNuocSanXuat(ucLogin);
            TabCreating(xTabMain, "Nước sản xuất", frm);
            Starting.Close();
        }

        private void barItem_Logout_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Restart();
        }

        private void barItem_Khaibaogia_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmVienPhiGia frm = new frmVienPhiGia(this.ucLogin);
            TabCreating(xTabMain, " Khai báo giá viện phí", frm);
            Starting.Close();
        }

        private void barItem_DMPhanNhom_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmPhanNhomThuoc frm = new frmPhanNhomThuoc();
            TabCreating(xTabMain, " Khai báo nhóm thuốc", frm);
            Starting.Close();
        }

        private void subItem_XN_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            
            string sMakp = string.Empty;
            string sNamekp = string.Empty;
            int iResult = CheckDepartment(16, ucLogin, ref sMakp, ref sNamekp);
            if (iResult == -2)
            {
                frmChonphongkham frphong = new frmChonphongkham(ucLogin, 16);
                frphong.ShowDialog(this);
                if (!string.IsNullOrEmpty(frphong.s_mapk))
                {
                    //frmXNHuyetHoc frm = new frmXNHuyetHoc(frphong.s_mapk, ucLogin, 7, frphong.s_namepk);
                    //TabCreating(xTabMain, "Xét nghiệm - Huyết Học", frm);
                    frmXNKetQuaNew frm = new frmXNKetQuaNew(frphong.s_mapk, ucLogin, this.shiftWork, this.dtWorking);
                    TabCreating(xTabMain, "Lấy Mẫu - Kết Quả - Xét Nghiệm", frm);
                }
            }
            else if (iResult == -1)
            {
                XtraMessageBox.Show("Vui lòng xem lại quyền user và giới hạn chỉ định khoa phòng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                //frmXNHuyetHoc frm = new frmXNHuyetHoc(sMakp, ucLogin, 7, sNamekp);
                //TabCreating(xTabMain, "Xét nghiệm - Huyết Học", frm);
                frmXNKetQuaNew frm = new frmXNKetQuaNew(sMakp, ucLogin, this.shiftWork, this.dtWorking);
                TabCreating(xTabMain, "Kết Quả - Xét Nghiệm", frm);
            }
            Starting.Close();
        }

        private void barItem_GioihanChidinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmGioiHanPhong_Module frm = new frmGioiHanPhong_Module(this.ucLogin);
            TabCreating(xTabMain, " Giới hạn chỉ định khoa phòng", frm);
            Starting.Close();
        }

        private void barItem_rptThongkeKB_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmBaoCao_ThongKeBenhNhan frm = new frmBaoCao_ThongKeBenhNhan(this.ucLogin);
            TabCreating(xTabMain, " Thống kê khám bệnh", frm);
            Starting.Close();
        }

        private void barItem_TKeDoanhThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmBaoCao_ThongKeDoanhThu frm = new frmBaoCao_ThongKeDoanhThu(this.ucLogin, this.dtWorking);
            TabCreating(xTabMain, " Thống kê doanh thu", frm);
            Starting.Close();
        }

        private void barItem_TheKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmTheKho frm = new frmTheKho();
            TabCreating(xTabMain, " Thẻ kho", frm);
            Starting.Close();
        }

        private void barItem_TonToiThieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmBaoCao_TonToiThieu frm = new frmBaoCao_TonToiThieu();
            TabCreating(xTabMain, " Xem tồn tối thiểu", frm);
            Starting.Close();
        }

        private void barItem_HD_Losx_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frm_Baocao_DateEnd frm = new frm_Baocao_DateEnd();
            TabCreating(xTabMain, " Xem hạn dùng - lô sản xuất", frm);
            Starting.Close();
        }

        private void barItem_MRI_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            Starting.Close();
            
            string sMakp = string.Empty;
            string sNamekp = string.Empty;
            int iResult = CheckDepartment(10, ucLogin, ref sMakp, ref sNamekp);
            if (iResult == -2)
            {
                frmChonphongkham frphong = new frmChonphongkham(ucLogin, 10);
                frphong.ShowDialog(this);
                if (!string.IsNullOrEmpty(frphong.s_mapk))
                {
                    frmMRI frm = new frmMRI(frphong.s_mapk, ucLogin, 10, frphong.s_namepk, frphong.employeeCodeDoctor, this.shiftWork, this.dtWorking);
                    TabCreating(xTabMain, "CĐHA - MRI", frm);
                }
            }
            else if (iResult == -1)
            {
                XtraMessageBox.Show("Vui lòng xem lại quyền user và giới hạn chỉ định khoa phòng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                frmMRI frm = new frmMRI(sMakp, ucLogin, 10, sNamekp, this.ucLogin, this.shiftWork, this.dtWorking);
                TabCreating(xTabMain, "CĐHA - MRI", frm);
            }
        }

        private void barItem_Scanner_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            Starting.Close();

            string sMakp = string.Empty;
            string sNamekp = string.Empty;
            int iResult = CheckDepartment(11, ucLogin, ref sMakp, ref sNamekp);
            if (iResult == -2)
            {
                frmChonphongkham frphong = new frmChonphongkham(ucLogin, 11);
                frphong.ShowDialog(this);
                if (!string.IsNullOrEmpty(frphong.s_mapk))
                {
                    frmCTScanner frm = new frmCTScanner(frphong.s_mapk, ucLogin, 11, frphong.s_namepk, frphong.employeeCodeDoctor, this.shiftWork, this.dtWorking);
                    TabCreating(xTabMain, "CĐHA - CT SCanner", frm);
                }
            }
            else if (iResult == -1)
            {
                XtraMessageBox.Show("Vui lòng xem lại quyền user và giới hạn chỉ định khoa phòng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                frmCTScanner frm = new frmCTScanner(sMakp, ucLogin, 11, string.Empty, this.ucLogin, this.shiftWork, this.dtWorking);
                TabCreating(xTabMain, "CĐHA - CT SCanner", frm);
            }
        }

        private void barItem_LuuBenh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            Starting.Close();
            string sMakp =string.Empty;
            string sNamekp = string.Empty;
            int iResult = CheckDepartment(12, this.ucLogin, ref sMakp, ref sNamekp);
            if (iResult == -2)
            {
                frmChonphongkham frphong = new frmChonphongkham(this.ucLogin, 12);
                frphong.ShowDialog(this);
                if (!string.IsNullOrEmpty(frphong.s_mapk))
                {
                    frmPhongLuu frm = new frmPhongLuu(frphong.s_mapk, this.ucLogin, 12, this.shiftWork, this.dtWorking);
                    TabCreating(xTabMain, "Phòng Cấp Cứu", frm);
                }
            }
            else if (iResult == -1)
            {
                XtraMessageBox.Show("Vui lòng xem lại quyền user và giới hạn chỉ định khoa phòng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                frmPhongLuu frm = new frmPhongLuu(sMakp, this.ucLogin, 12, this.shiftWork, this.dtWorking);
                TabCreating(xTabMain, "Phòng Cấp Cứu", frm);
            }
        }
        private string[] ArrPart;
        private Int32 CheckDepartment(int imodule, string s_Usercode, ref string sMapk, ref string sNamepk)
        {
            try
            {
                DataTable dtTemp = new DataTable();
                var vEmployee = EmployeeBLL.ListEmployee(s_Usercode);
                string sCode = "";
                foreach (var v in vEmployee)
                {
                    ArrPart = v.PermissionDepart.Split(',');
                }
                for (int i = 0; i < ArrPart.Length; i++)
                {
                    sCode += "'" + ArrPart[i].ToString() + "',";
                }
                dtTemp = ServiceMenuBLL.DT_MenuDeparForEmployee(imodule, sCode.TrimEnd(','));
                if (dtTemp.Rows.Count <= 0)
                    return -1;
                else if (dtTemp.Rows.Count == 1)
                {
                    sMapk = dtTemp.Rows[0]["DepartmentCode"].ToString();
                    sNamepk = dtTemp.Rows[0]["DepartmentName"].ToString();
                    return 1;
                }
                else
                    return -2;
                
            }
            catch { return -2; }
        }

        private void barItem_ThuThuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
                Starting.Close();
                string sMakp = string.Empty;
                string sNamekp = string.Empty;
                int iResult = CheckDepartment(2, ucLogin, ref sMakp, ref sNamekp);
                if (iResult == -2 || iResult == 1)
                {
                    frmChonphongkham frphong = new frmChonphongkham(ucLogin, 2);
                    frphong.ShowDialog(this);
                    if (!string.IsNullOrEmpty(frphong.s_mapk))
                    {
                        frmThuThuat frm = new frmThuThuat(frphong.s_mapk, frphong.employeeCodeDoctor, 2, frphong.s_namepk, this.shiftWork, this.dtWorking);
                        TabCreating(xTabMain, "Thủ Thuật", frm);
                    }
                }
                else if (iResult == -1)
                {
                    XtraMessageBox.Show("Vui lòng xem lại quyền user và giới hạn chỉ định khoa phòng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    frmThuThuat frm = new frmThuThuat(sMakp, ucLogin, 2, sNamekp, this.shiftWork, this.dtWorking);
                    TabCreating(xTabMain, "Thủ Thuật", frm);
                }
            }
            catch { }
        }

        private void barItem_Banle_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            Starting.Close();
            frmChonKho frmkho = new frmChonKho(this.ucLogin, 4);
            frmkho.ShowDialog(this);
            if (!string.IsNullOrEmpty(frmkho.s_RepositoryCode))
            {
                frmXuatBanLe frm = new frmXuatBanLe(this.ucLogin, frmkho.s_RepositoryCode, this.shiftWork);
                TabCreating(xTabMain, "Xuất Bán Thuốc", frm);
                //frm.ShowInTaskbar = false;
                //frm.ShowDialog();
            }
        }

        private void barItem_NXTTongHop_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmBaoCao_NXT_TH frm = new frmBaoCao_NXT_TH();
            TabCreating(xTabMain, " Báo cáo nhập xuất tồn tổng hợp", frm);
            Starting.Close();
        }

        private void barItem_NXTChiTiet_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmBaoCao_NXT_CT frm = new frmBaoCao_NXT_CT();
            TabCreating(xTabMain, " Báo cáo nhập xuất tồn chi tiết", frm);
            Starting.Close();
        }

        private void barItem_TKToathuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmBangKeChiTietThuoc frm = new frmBangKeChiTietThuoc();
            TabCreating(xTabMain, " Thống kê chi tiết thuốc", frm);
            Starting.Close();
        }

        private void barItem_TKThuoctutruc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmBangKeThuocTuTruc frm = new frmBangKeThuocTuTruc();
            TabCreating(xTabMain, " Thống kê thuốc xuất tủ trực", frm);
            Starting.Close();
        }

        private void barItem_TKThuocXB_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmBangKeThuocXB frm = new frmBangKeThuocXB();
            TabCreating(xTabMain, " Thống kê thuốc xuất bán", frm);
            Starting.Close();
        }

        private void subItem_TKesocabacsi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmRpt_BacSiChiDinh frm = new frmRpt_BacSiChiDinh(this.ucLogin);
            TabCreating(xTabMain, " Thống kê số ca bác sĩ chỉ định", frm);
            Starting.Close();
        }
        
        private void barSub_NgheNghiep_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmNgheNghiep frm = new frmNgheNghiep();
            TabCreating(xTabMain, " Nghề nghiệp", frm);
            Starting.Close();
        }

        private void barSub_NguoiGioiThieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmNguoiGioiThieu frm = new frmNguoiGioiThieu(ucLogin);
            TabCreating(xTabMain, " Người giới thiệu", frm);
            Starting.Close();
        }

        private void barSub_BCDoanhthuNT_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmTKeBanThuoc frm = new frmTKeBanThuoc();
            TabCreating(xTabMain, " Thống kê doanh thu nhà thuốc", frm);
            Starting.Close();
        }

        private void barSub_EkipPTTT_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmEkipPTTT frm = new frmEkipPTTT();
            TabCreating(xTabMain, " Ekip PT-TT", frm);
            Starting.Close();
        }

        private void sub_BCKetquadieutri_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmRpt_KetQuaDieuTri frm = new frmRpt_KetQuaDieuTri();
            TabCreating(xTabMain, " Kết Quả Điều Trị", frm);
            Starting.Close();
        }

        private void barSub_TheoDoiDHST_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmTheoDoiDauHieuSinhTon frm = new frmTheoDoiDauHieuSinhTon();
            TabCreating(xTabMain, " Dấu Hiệu Sinh Tồn", frm);
            Starting.Close();
        }

        private void barItem_ChangePass_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            Starting.Close();
            frmChangePass frm = new frmChangePass(ucLogin);
            frm.ShowDialog(this);
        }

        private void barSub_BCSoCaCD_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmRpt_BacSiChiDinh frm = new frmRpt_BacSiChiDinh(this.ucLogin);
            TabCreating(xTabMain, " Thống kê số ca bác sĩ chỉ định", frm);
            Starting.Close();
        }

        private void barSub_Backupdata_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            Starting.Close();
            frmBackupDatabase frm = new frmBackupDatabase(ucLogin);
            frm.ShowDialog();
        }

        private void barSub_ChartCDHA_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmChartCDHA frm = new frmChartCDHA();
            TabCreating(xTabMain, " Biểu đồ thống kê", frm);
            Starting.Close();
        }

        private void barSub_BCSoCaTH_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmRpt_BacSiThucHien frm = new frmRpt_BacSiThucHien(this.ucLogin);
            TabCreating(xTabMain, " Thống kê số ca bác sĩ thực hiện", frm);
            Starting.Close();
        }

        private void barSub_DThuTheoBSChidinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmVP_DoanhThuBSChiDinh frm = new frmVP_DoanhThuBSChiDinh(this.ucLogin);
            TabCreating(xTabMain, " Thống kê doanh thu theo bác sĩ", frm);
            Starting.Close();
        }
                
        private void barItem_HoanTraKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmHoanTraKhoChan frm = new frmHoanTraKhoChan(this.ucLogin);
            TabCreating(xTabMain, "Hoàn trả kho", frm);
            Starting.Close();
        }
        
        private void barSub_UpdateBN_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            Starting.Close();
            frmCapNhatThongTinBN frm = new frmCapNhatThongTinBN(this.ucLogin, string.Empty,this.dtWorking);
            frm.Show();
        }

        private void barSub_ListReceive_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmRpt_DSDotDieuTri frm = new frmRpt_DSDotDieuTri();
            TabCreating(xTabMain, " Danh Sách Điều Trị", frm);
            Starting.Close();
        }

        private void barItem_DinhMucVTTH_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmDanhMucVTTH frm = new frmDanhMucVTTH(this.ucLogin);
            TabCreating(xTabMain, "Định mức Thuốc-VTTH", frm);
            Starting.Close();
        }

        private void barItem_HoanTraNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmHoanTraNCC frm = new frmHoanTraNCC(this.ucLogin);
            TabCreating(xTabMain, "Hoàn trả nhà cung cấp", frm);
            Starting.Close();
        }
        
        private void barItem_TKeDaily_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmVP_ThongKeDoanhThuNgay frm = new frmVP_ThongKeDoanhThuNgay(this.ucLogin);
            TabCreating(xTabMain, "Thống kê doanh thu tổng hợp", frm);
            Starting.Close();
        }

        private void barItem_Machine_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmDanhMucMay frm = new frmDanhMucMay(this.ucLogin);
            TabCreating(xTabMain, "Danh sách máy XN, CĐHA,..", frm);
            Starting.Close();
        }

        private void barSubTinhTPho_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmDanhMucTinhThanh frm = new frmDanhMucTinhThanh(ucLogin);
            TabCreating(xTabMain, "Danh mục tỉnh/thành phố", frm);
            Starting.Close();
        }

        private void barSubQuanHuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmDanhMucQuanHuyen frm = new frmDanhMucQuanHuyen(this.ucLogin);
            TabCreating(xTabMain, "Danh mục quận/huyện", frm);
            Starting.Close();
        }

        private void barSubPhuongXa_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmDanhMucPXa frm = new frmDanhMucPXa(this.ucLogin);
            TabCreating(xTabMain, "Danh mục phường/xã", frm);
            Starting.Close();
        }

        private void barListMenuRelation_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmMenuRelationPatient frm = new frmMenuRelationPatient(ucLogin);
            TabCreating(xTabMain, "Thông tin gia đình", frm);
            Starting.Close();
        }

        private void barListMedicalPattern_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmMedicalPattern frm = new frmMedicalPattern(ucLogin);
            TabCreating(xTabMain, "Khai báo hồ sơ khám bệnh", frm);
            Starting.Close();
        }
                
        private void barSub_UpdWarehousing_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmUpdateInventory frm = new frmUpdateInventory(this.ucLogin);
            TabCreating(xTabMain, "Cập nhật phiếu nhập kho", frm);
            Starting.Close();
        }

        private void barSub_UpdDateEnd_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmShipmentDateEnd frm = new frmShipmentDateEnd(this.ucLogin);
            TabCreating(xTabMain, "Lô, hạn dùng", frm);
            Starting.Close();
        }

        private void barItem_MenuUnitOfService_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmDonViTinh frm = new frmDonViTinh("S");
            TabCreating(xTabMain, "Đơn vị tính", frm);
            Starting.Close();
        }

        private void barItem_Diagnosis_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmDiagnosisCustom frm = new frmDiagnosisCustom(this.ucLogin);
            TabCreating(xTabMain, "Chẩn đoán bệnh theo người dùng", frm);
            Starting.Close();
        }

        private void barItem_MapTypeResult_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmLoaiTraKetQuaXN frm = new frmLoaiTraKetQuaXN(this.ucLogin);
            TabCreating(xTabMain, "Khai báo hình thức trả kết quả XN", frm);
            Starting.Close();
        }

        private void barItem_ServiceForEmployee_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmLimitForService frm = new frmLimitForService(this.ucLogin);
            TabCreating(xTabMain, "Giới hạn dịch vụ báo cáo", frm);
            Starting.Close();
        }
        
        private void barItem_CategoryAttach_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmLabPatternAttach frm = new frmLabPatternAttach(this.ucLogin);
            TabCreating(xTabMain, "Mẫu xét nghiệm đính kèm", frm);
            Starting.Close();
        }

        private void barItem_LichTC_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmImmMenuTimes frm = new frmImmMenuTimes(this.ucLogin);
            TabCreating(xTabMain, "Lịch tiêm chủng", frm);
            Starting.Close();
        }

        private void barItem_SoKB_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmKBSoKB frm = new frmKBSoKB(this.ucLogin);
            TabCreating(xTabMain, "Sổ khám bệnh", frm);
            Starting.Close();
        }

        private void barItemKB_TKTheoCa_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThongKeTheoCa frm = new frmThongKeTheoCa(this.ucLogin);
            frm.ShowInTaskbar = true;
            frm.Show();
        }

        private void barItemKB_TKTheoBSY_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmKB_PivotTKeTheoBSY frm = new frmKB_PivotTKeTheoBSY(this.ucLogin);
            TabCreating(xTabMain, " Thống kê theo bác sỹ", frm);
            Starting.Close();
        }

        private void barItem_BangKeHD_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmVP_BangKeHDNgay frm = new frmVP_BangKeHDNgay(this.ucLogin);
            TabCreating(xTabMain, "Bảng kê hóa đơn", frm);
            Starting.Close();
        }

        private void barItem_THThongKeNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmTHBangKeNhapXuatThuoc frm = new frmTHBangKeNhapXuatThuoc(this.ucLogin);
            TabCreating(xTabMain, "Bảng kê nhập thuốc", frm);
            Starting.Close();
        }
        
        private bool CheckAutoUpdate(ref string pathName, ref string versionCurrent)
        {
            try
            {
                bool result = false;
                DataSet dsUpdate = new DataSet("updateModule");
                dsUpdate.Tables.Add(new DataTable("path"));
                dsUpdate.Tables[0].Columns.Add("srcPath", typeof(string));
                dsUpdate.Tables[0].Columns.Add("destPath", typeof(string));
                dsUpdate.Tables[0].Columns.Add("currentPath", typeof(string));
                dsUpdate.Tables[0].Columns.Add("version", typeof(string));
                dsUpdate.Tables[0].Columns.Add("auto", typeof(int));
                dsUpdate.Tables[0].Columns.Add("module", typeof(string));
                string computerName = Utils.GetComputerName();
                string hddSerial = Utils.GetHDDSerialNo();
                string macAddress = Utils.GetMacAddress();
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                versionCurrent = fileVersionInfo.ProductVersion;
                string versionNew = string.Empty;
                CatalogComputerInf computer = new CatalogComputerInf();
                computer = CatalogComputerBLL.ObjComputer(hddSerial);
                if (computer == null || string.IsNullOrEmpty(computer.HDDSerialNo))
                {
                    computer = new CatalogComputerInf { ComputerName = computerName, MacAddress = macAddress, HDDSerialNo = hddSerial, VersionNo = versionCurrent };
                    CatalogComputerBLL.InsComputer(computer);
                }
                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(5);
                versionNew = objSys.VersionNo;
                pathName = Directory.GetCurrentDirectory();
                //string dirname = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                string dirname = Utils.CurrentPathApplication();
                Process p = Process.GetCurrentProcess();
                string moduleName = p.ProcessName;
                if(computer.IDate.Equals(Utils.DateServer()))
                    dsUpdate.Tables[0].Rows.Add(objSys.Description, dirname, pathName, versionNew, 0, moduleName.Replace(".vshost", ""));
                else
                    dsUpdate.Tables[0].Rows.Add(objSys.Description, dirname, pathName, versionNew, 1, moduleName.Replace(".vshost", ""));
                dsUpdate.WriteXml(dirname + "\\xml\\PathUpdateModule.xml");
                if (objSys != null && objSys.RowID > 0 && objSys.Values == 1)
                {
                    if (!objSys.VersionNo.Equals(versionCurrent))
                        result = true;
                    computer.VersionNo = versionNew;
                    CatalogComputerBLL.InsComputer(computer);
                }
                else
                    result = false;
                return result;
            }
            catch { return false; }
        }

        private void barItem_CoSoTuTruc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmCoSoTuTruc frm = new frmCoSoTuTruc(this.ucLogin);
            TabCreating(xTabMain, " Cơ số tủ trực", frm);
            Starting.Close();
        }

        private void barSub_BaoCaoLaiSuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmBaoCaoLaiSuat frm = new frmBaoCaoLaiSuat();
            TabCreating(xTabMain, " Báo cáo lãi suất", frm);
            Starting.Close();
        }
        
        private void barItem_TKToaThuocBS_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmThongKeToaBS frm = new frmThongKeToaBS();
            TabCreating(xTabMain, "Thống kê cấp toa bác sĩ", frm);
            Starting.Close();
        }

        private void barItem_TKDuyetToaThuocBS_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmThongKeDuyetToaBS frm = new frmThongKeDuyetToaBS();
            TabCreating(xTabMain, "Thống kê duyệt toa bác sĩ", frm);
            Starting.Close();
        }

        private void barItemKB_TKChuyenVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmRpt_DSChuyenVien frm = new frmRpt_DSChuyenVien();
            TabCreating(xTabMain, "Thống kê chuyển viện", frm);
            Starting.Close();
        }

        private void barItemKB_TKGuiMauXN_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmRpt_DSGuiMauXN frm = new frmRpt_DSGuiMauXN();
            TabCreating(xTabMain, "Thống kê gửi mẫu xét nghiệm", frm);
            Starting.Close();
        }

        private void barItem_SoXN_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmKBSoXN frm = new frmKBSoXN(this.ucLogin);
            TabCreating(xTabMain, "Sổ xét nghiệm", frm);
            Starting.Close();
        }

        private void barItem_BangKeTrongNgay_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmVP_BangKeTrongNgay frm = new frmVP_BangKeTrongNgay(this.ucLogin);
            TabCreating(xTabMain, "Chi phí phát sinh", frm);
            Starting.Close();
        }
        
        private void barItemVP_KhaiBaoDotKM_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmVPDotKhuyenMai frm = new frmVPDotKhuyenMai(this.ucLogin);
            TabCreating(xTabMain, "Đợt Khuyến Mãi", frm);
            Starting.Close();
        }

        private void barSubBN_ChiTietDieuTri_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmBNLogDieuTri frm = new frmBNLogDieuTri();
            frm.Show();
            //TabCreating(xTabMain, "Lịch Sử Đợt Điều Trị", frm);
            //Starting.Close();
        }

        private void barSubBN_InPhieuPTTT_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.prtCamKetPTTT frm = new Reports.prtCamKetPTTT();
            frm.ShowRibbonPreviewDialog();
        }

        private void barItem_SoDe_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmKBSode frm = new frmKBSode(this.ucLogin);
            TabCreating(xTabMain, "Sổ đẻ", frm);
            Starting.Close();
        }

        private void barItem_SoKT_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmKBSoKT frm = new frmKBSoKT(this.ucLogin);
            TabCreating(xTabMain, "Sổ khám thai", frm);
            Starting.Close();
        }

        private void barItem_SoPT_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmKBSoPT frm = new frmKBSoPT(this.ucLogin);
            TabCreating(xTabMain, "Sổ phá thai", frm);
            Starting.Close();
        }
        private void barSub_Kiemduyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmConfirmReportBV01 frm = new frmConfirmReportBV01(this.ucLogin, this.shiftWork);
            frm.Show();
        }

        private void barSub_Ketxuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmRpt_KetXuatDuLieu frm = new frmRpt_KetXuatDuLieu(this.ucLogin);
            TabCreating(xTabMain, "Kết xuất dữ liệu BHYT", frm);
            Starting.Close();
        }

        private void barItem_TiemChung_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
                Starting.Close();

                string sMakp = string.Empty;
                string sNamekp = string.Empty;
                int iResult = CheckDepartment(15, this.ucLogin, ref sMakp, ref sNamekp);
                if (iResult == -2 || iResult == 1)
                {
                    frmChonphongkham frphong = new frmChonphongkham(this.ucLogin, 15);
                    frphong.ShowDialog(this);
                    if (!string.IsNullOrEmpty(frphong.s_mapk))
                    {
                        frmImmunization frm = new frmImmunization(frphong.s_mapk, this.ucLogin, 15, frphong.s_namepk, this.shiftWork, frphong.employeeCodeDoctor, this.dtWorking);
                        TabCreating(xTabMain, "Tiêm Chủng", frm);
                    }
                }
                else if (iResult == -1)
                {
                    XtraMessageBox.Show("Vui lòng xem lại quyền user và giới hạn chỉ định khoa phòng", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    frmImmunization frm = new frmImmunization(sMakp, this.ucLogin, 15, sNamekp, this.shiftWork, this.ucLogin, this.dtWorking);
                    this.TabCreating(xTabMain, "Tiêm Chủng", frm);
                }
            }
            catch { }
        }

        private void subItem_DuyetTC_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            Starting.Close();
            frmChonKho frmkho = new frmChonKho(this.ucLogin, 2);
            frmkho.ShowDialog(this);
            if (frmkho.s_RepositoryCode != "")
            {
                frmDuyetCapTiemChung frm = new frmDuyetCapTiemChung(this.ucLogin, frmkho.s_RepositoryCode, this.shiftWork);
                TabCreating(xTabMain, " Duyệt cấp tiêm chủng", frm);
            }
        }

        private void barItem_KH_DSDangKyKham_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmCSKH_DSBenhNhanTiepNhan frm = new frmCSKH_DSBenhNhanTiepNhan();
            TabCreating(xTabMain, " CSKH - Danh sách khách hàng đăng ký khám.", frm);
            Starting.Close();
        }

        private void barItem_KH_SendSMS_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmCSKHListSendSMS frm = new frmCSKHListSendSMS(this.ucLogin);
            TabCreating(xTabMain, " CSKH - Gửi tin nhắn hẹn tái khám.", frm);
            Starting.Close();
        }
       
        private void barItemKB_THTC_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET.");
            frm_THTC frm = new frm_THTC();
            TabCreating(xTabMain, "Báo cáo tình hình tiêm chủng!", frm);
            Starting.Close();
        }

        private void barItemKB_TimVaccin_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET.");
            frm_THTC frm = new frm_THTC();
            TabCreating(xTabMain, "Báo cáo tình hình tiêm chủng!", frm);
            Starting.Close();
        }

        private void barItemKB_HDKCB_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET.");
            frm_BM03_YTTN_HDKCB frm = new frm_BM03_YTTN_HDKCB();
            TabCreating(xTabMain, "Hoạt động KCB và CLS!", frm);
            Starting.Close();
        }

        private void barItemKB_TNTT_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET.");
            frm_BM04_YTTN_TNTT frm = new frm_BM04_YTTN_TNTT();
            TabCreating(xTabMain, "Tai nạn thương tích!", frm);
            Starting.Close();
        }

        private void barItemKB_BTNGD_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET.");
            frm_BM06_YTTN_BTN frm = new frm_BM06_YTTN_BTN();
            TabCreating(xTabMain, " Tình hình bệnh truyền nhiễm", frm);
            Starting.Close();
        }

        private void barItemPTVenABC_PTABC_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            VenABC.frmCacPhanTichLienQuanABC frm = new VenABC.frmCacPhanTichLienQuanABC(this.ucLogin);
            TabCreating(xTabMain, " Phân tích ABC", frm);
            Starting.Close();
        }

        private void Item_DMBHYT_ListDV_DMDV_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmVienPhiBHYT frm = new frmVienPhiBHYT(this.ucLogin);
            TabCreating(xTabMain, "Danh Mục Dịch Vụ BHYT", frm);
            Starting.Close();
        }

        private void Item_DMBHYT_ListDV_DMLoaiTTPT_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmDanhMucLoaiPTTT frm = new frmDanhMucLoaiPTTT();
            TabCreating(xTabMain, "Danh Mục Loại PT-TT ", frm);
            Starting.Close();
        }

        private void Item_DMBHYT_ListDV_DMNhom_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmNhomVienPhiBHYT frm = new frmNhomVienPhiBHYT();
            TabCreating(xTabMain, "Nhóm Dịch Vụ BHYT", frm);
            Starting.Close();
        }

        private void butItem_BC_CK_BSGioiThieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmConfirmDiscountIntro frm = new frmConfirmDiscountIntro(this.ucLogin, this.shiftWork);
            frm.Show();
            frm.ShowInTaskbar = true;
        }

        private void barItemVP_PhieuThuTien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmPhieuThuTien frm = new frmPhieuThuTien(this.ucLogin, this.shiftWork);
            TabCreating(xTabMain, "Phiếu Thu Tiền", frm);
            Starting.Close();
        }

        private void barItemVP_PhieuThuTamUng_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmVP_ChonQuyenSo frmQuyenSo = new frmVP_ChonQuyenSo(ucLogin, 0);
            frmQuyenSo.ShowDialog(this);
            if (frmQuyenSo.rowid > 0)
            {
                Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET.");
                frmPhieuThuTienTamUng frm = new frmPhieuThuTienTamUng(this.ucLogin, this.shiftWork, frmQuyenSo.rowid, this.dtWorking, frmQuyenSo.symbol);
                TabCreating(xTabMain, "Thu Tạm Ứng", frm);
                Starting.Close();
            }
        }

        private void barItemKB_SKSS_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frm_BM05_YTTN_SKSS frm = new frm_BM05_YTTN_SKSS(this.dtWorking, this.ucLogin);
            TabCreating(xTabMain, "BS05 - SKSS", frm);
            Starting.Close();
        }

        private void barItemVP_KhaiBaoQSo_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET.");
            frmVP_QuyenSo frm = new frmVP_QuyenSo(this.ucLogin, this.shiftWork);
            TabCreating(xTabMain, "Khai báo quyển sổ", frm);
            Starting.Close();
        }

        private void barItem_KH_SendMail_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET.");
            frmHSBA_SendEmail frm = new frmHSBA_SendEmail(this.ucLogin);
            TabCreating(xTabMain, "Gửi hồ sơ qua Email", frm);
            Starting.Close();
        }

        private void barItem_BHYT_DMDV_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmVienPhiBHYT frm = new frmVienPhiBHYT(this.ucLogin);
            TabCreating(xTabMain, "Danh Mục Dịch Vụ BHYT", frm);
            Starting.Close();
        }

        private void barItem_BHYT_DMPTTT_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmDanhMucLoaiPTTT frm = new frmDanhMucLoaiPTTT();
            TabCreating(xTabMain, "Danh Mục Loại PT-TT ", frm);
            Starting.Close();
        }

        private void barItem_BHYT_DMNhomBHYT_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmNhomVienPhiBHYT frm = new frmNhomVienPhiBHYT();
            TabCreating(xTabMain, "Nhóm Dịch Vụ BHYT", frm);
            Starting.Close();
        }

        private void barItem_BHYT_DMKP_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmDMKhoaphongBHYT frm = new frmDMKhoaphongBHYT(this.ucLogin);
            TabCreating(xTabMain, "DM Khoa Phòng BHYT", frm);
            Starting.Close();
        }

        private void barItem_BHYT_DMThuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmThuocBHYT frm = new frmThuocBHYT(this.ucLogin);
            TabCreating(xTabMain, "Danh mục Thuốc - VTTH", frm);
            Starting.Close();
        }

        private void barItem_TemplateBM05_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmTemplate_MSBieu05 frm = new frmTemplate_MSBieu05(this.ucLogin);
            TabCreating(xTabMain, "Biểu số 05", frm);
            Starting.Close();
        }

        private void butItem_BC_CK_BSCD_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmConfirmDiscountDoctorPointed frm = new frmConfirmDiscountDoctorPointed(this.ucLogin, this.shiftWork);
            frm.Show();
            frm.ShowInTaskbar = true;
        }

        private void barItem_TU_BaoCao_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmVP_BangKeHDTamUng frm = new frmVP_BangKeHDTamUng(this.ucLogin, this.dtWorking);
            TabCreating(xTabMain, "Báo cáo thu tạm ứng", frm);
            Starting.Close();
        }
        
        private void barItem_HSBAOnline_DSBenhNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmHSBA_Synchronize frm = new frmHSBA_Synchronize(this.ucLogin);
            TabCreating(xTabMain, "Upload HSBA Online", frm);
            Starting.Close();
        }

        private void barItemPTVenABC_PTChiSo_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            VenABC.frmPhanTichChiSoGeneral frm = new VenABC.frmPhanTichChiSoGeneral(this.ucLogin);
            TabCreating(xTabMain, " Phân tích chỉ số", frm);
            Starting.Close();
        }

        private void subItem_DuyetCapBHYT_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            Starting.Close();
            frmChonKho frmkho = new frmChonKho(this.ucLogin, 2);
            frmkho.ShowDialog(this);
            if (!string.IsNullOrEmpty(frmkho.s_RepositoryCode))
            {
                frmDuyetToaThuocBHYT frm = new frmDuyetToaThuocBHYT(this.ucLogin, frmkho.s_RepositoryCode, this.shiftWork);
                TabCreating(xTabMain, " Duyệt toa thuốc (Nhóm duyệt cấp)", frm);
            }
        }

        private void subItem_DuyetCapThuPhi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            Starting.Close();
            frmChonKho frmkho = new frmChonKho(this.ucLogin, 4);
            frmkho.ShowDialog(this);
            if (!string.IsNullOrEmpty(frmkho.s_RepositoryCode))
            {
                frmDuyetToaThuocThuPhi frm = new frmDuyetToaThuocThuPhi(this.ucLogin, frmkho.s_RepositoryCode, this.shiftWork);
                TabCreating(xTabMain, " Duyệt toa thuốc (Nhóm xuất bán)", frm);
            }
        }

        private void subItem_CapPhatToaBHYT_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            Starting.Close();
            frmChonKho frmkho = new frmChonKho(this.ucLogin, 4);
            frmkho.ShowDialog(this);
            if (!string.IsNullOrEmpty(frmkho.s_RepositoryCode))
            {
                frmCapPhatToaBHYT frm = new frmCapPhatToaBHYT(this.ucLogin, frmkho.s_RepositoryCode, this.shiftWork);
                TabCreating(xTabMain, " Cấp Phát Thuốc", frm);
            }
        }

        private void barList_ReportReceive_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmBaoCao_TKeLuotKhamBenh frm = new frmBaoCao_TKeLuotKhamBenh();
            TabCreating(xTabMain, " Thống kê lượt khám", frm);
            Starting.Close();
        }

        private void barItemVP_PrintGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmVP_DMNhomIn frm = new frmVP_DMNhomIn();
            TabCreating(xTabMain, " Khai báo nhóm in", frm);
            Starting.Close();
        }

        private void timer_Working_Tick(object sender, EventArgs e)
        {
            this.timedur += 1;
            if (timedur >= 60)//1 minutes kiem tra 1 lan
            {
                //this.timer1.Stop();
                DateTime datetime = ClinicLibrary.Utils.DateTimeServer();
                if (datetime.Day != this.datetimelogin.Day)
                    this.timeout = true;
                else
                    this.timeout = false;
                bool login = false;
                DataTable dt = EmployeeBLL.DTEmployee(this.ucLogin, false);
                for(int i=0; i<dt.Rows.Count; i++)
                {
                    if(dt.Rows[i]["EmployeeCode"].ToString()==this.ucLogin && Convert.ToInt32(dt.Rows[i]["PositionCode"].ToString())==4)
                    {
                        login = true;
                    }
                }
                if (!this.CaLamViec.Equals(this.KiemTraCa())&& login==true)//kiểm tra group user đăng nhập phải nhóm kế toán ko? nếu là nhóm kt thì cho zô ha a uhm. set cứng luôn ha uuhm ok 
                    this.QuaCa = true;
                else
                    this.QuaCa = false;

                this.timedur = 0;
            }
            
                
            
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET");
            frmVP_BangKeHDChiTiet frm = new frmVP_BangKeHDChiTiet(this.ucLogin);
            TabCreating(xTabMain, "Báo cáo doanh thu chi tiết", frm);
            Starting.Close();
        }
    }
}