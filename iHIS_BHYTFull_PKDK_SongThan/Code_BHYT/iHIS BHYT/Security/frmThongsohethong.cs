using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System.Management;
using System.Diagnostics;
using System.Reflection;

namespace Ps.Clinic.Security
{
    public partial class frmThongsohethong : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string sUserID = string.Empty;
        public frmThongsohethong(string _user)
        {
            InitializeComponent();
            this.sUserID = _user;
        }

        private void fLoadParameterKCB()
        {
            List<SystemParameterInf> para = SystemParameterBLL.ListParameter("KCB");
            if (para != null && para.Count > 0)
            {
                foreach (var v in para)
                {
                    switch (v.RowID)
                    {
                        case 1:
                            this.chk1.Checked = v.Values == 1 ? true : false;
                            this.spinQuantity_01.EditValue = v.Description;
                            break;
                        case 2:
                            this.chk2.Checked = v.Values == 1 ? true : false;
                            break;
                        case 3:
                            this.chk3.Checked = v.Values == 1 ? true : false;
                            break;
                        case 4:
                            this.chk4.Checked = v.Values == 1 ? true : false;
                            this.spinQuantity_04.EditValue = v.Description;
                            break;
                        case 5:
                            this.chk5.Checked = v.Values == 1 ? true : false;
                            this.txtPathUpdate.Text = v.Description;
                            break;
                        case 6:
                            this.chk6.Checked = v.Values == 1 ? true : false;
                            break;
                        case 7:
                            this.chk7.Checked = v.Values == 1 ? true : false;
                            break;
                        case 8:
                            this.chk8.Checked = v.Values == 1 ? true : false;
                            break;
                        case 9:
                            this.chk9.Checked = v.Values == 1 ? true : false;
                            break;
                        case 10:
                            this.chk10.Checked = v.Values == 1 ? true : false;
                            break;
                        case 11:
                            this.chk11.Checked = v.Values == 1 ? true : false;
                            break;
                        case 12:
                            this.chk12.Checked = v.Values == 1 ? true : false;
                            break;
                        case 13:
                            this.chk13.Checked = v.Values == 1 ? true : false;
                            break;
                        case 14:
                            this.chk14.Checked = v.Values == 1 ? true : false;
                            break;
                        case 15:
                            this.chk15.Checked = v.Values == 1 ? true : false;
                            break;
                        case 16:
                            this.chk16.Checked = v.Values == 1 ? true : false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private void fLoadParameterTHUOC()
        {
            List<SystemParameterInf> para = SystemParameterBLL.ListParameter("THUOC");
            if (para != null && para.Count > 0)
            {
                foreach (var v in para)
                {
                    switch (v.RowID)
                    {
                        case 200:
                            this.chk200.Checked = v.Values == 1 ? true : false;
                            break;
                        case 201:
                            this.chk201.Checked = v.Values == 1 ? true : false;
                            break;
                        case 202:
                            this.chk202.Checked = v.Values == 1 ? true : false;
                            break;
                        case 203:
                            this.chk203.Checked = v.Values == 1 ? true : false;
                            break;
                        case 204:
                            this.chk204.Checked = v.Values == 1 ? true : false;
                            this.spinQuantity_204.EditValue = v.Description;
                            break;
                        case 205:
                            this.chk205.Checked = v.Values == 1 ? true : false;
                            break;
                        case 206:
                            this.chk206.Checked = v.Values == 1 ? true : false;
                            break;
                        case 207:
                            this.chk207.Checked = v.Values == 1 ? true : false;
                            break;
                        case 208:
                            this.chk208.Checked = v.Values == 1 ? true : false;
                            break;
                        case 209:
                            this.chk209.Checked = v.Values == 1 ? true : false;
                            break;
                        case 210:
                            this.chk210.Checked = v.Values == 1 ? true : false;
                            break;
                        case 211:
                            this.chk211.Checked = v.Values == 1 ? true : false;
                            if (this.chk211.Checked)
                                this.chk213.Enabled = true;
                            else
                                this.chk213.Enabled = false;
                            break;
                        case 212:
                            this.chk212.Checked = v.Values == 1 ? true : false;
                            this.chkListBox_212.SetEditValue(v.Description);
                            break;
                        case 213:
                            this.chk213.Checked = v.Values == 1 ? true : false;
                            break;
                        default: break;
                    }
                }
            }
        }
        private void fLoadParameterCDHA()
        {
            List<SystemParameterInf> para = SystemParameterBLL.ListParameter("CDHA");
            if (para != null && para.Count > 0)
            {
                foreach (var v in para)
                {
                    switch (v.RowID)
                    {
                        case 300:
                            this.chk300.Checked = v.Values == 1 ? true : false;
                            this.spinValues300.EditValue = v.Description;
                            break;
                        case 301:
                            this.chk301.Checked = v.Values == 1 ? true : false;
                            break;
                        case 302:
                            this.chk302.Checked = v.Values == 1 ? true : false;
                            break;
                        default: break;
                    }
                }
            }
        }
        private void fLoadParameterXN()
        {
            string serviceGroup = "XN";
            //this.cb401.Properties.DataSource = ServiceCategoryBLL.ListServiceCategory("XN", string.Empty).Select(c => new { c.ServiceCategoryCode, c.ServiceCategoryName }).ToList();
            this.cb401.Properties.DataSource = ServiceCategoryBLL.DTServiceCategory(serviceGroup, string.Empty);
            this.cb401.Properties.DisplayMember = "ServiceCategoryName";
            this.cb401.Properties.ValueMember = "ServiceCategoryCode";
            List<SystemParameterInf> para = SystemParameterBLL.ListParameter(serviceGroup);
            if (para != null && para.Count > 0)
            {
                foreach (var v in para)
                {
                    switch (v.RowID)
                    {
                        case 400:
                            this.chk400.Checked = v.Values == 1 ? true : false;
                            this.txtPathFolder.Text = v.Description;
                            break;
                        case 401:
                            this.chk401.Checked = v.Values == 1 ? true : false;
                            this.cb401.SetEditValue(v.Description);
                            break;
                        case 402:
                            this.chk402.Checked = v.Values == 1 ? true : false;
                            break;
                        default: break;
                    }
                }
            }
        }
        private void fLoadParameterVP()
        {
            List<SystemParameterInf> para = SystemParameterBLL.ListParameter("VIENPHI");
            if (para != null && para.Count > 0)
            {
                foreach (var v in para)
                {
                    switch (v.RowID)
                    {
                        case 500:
                            this.chk500.Checked = v.Values == 1 ? true : false;
                            break;
                        case 501:
                            this.chk501.Checked = v.Values == 1 ? true : false;
                            break;
                        //case 502:
                        //    this.chk502.Checked = v.Values == 1 ? true : false;
                        //    break;
                        case 503:
                            this.chk503.Checked = this.cbxPrinter503.Enabled = v.Values == 1 ? true : false;
                            this.cbxPrinter503.SelectedIndex = Convert.ToInt32(v.Description);
                            break;
                        case 504:
                            this.chk504.Checked = v.Values == 1 ? true : false;
                            break;
                        case 505:
                            this.chk505.Checked = v.Values == 1 ? true : false;
                            break;
                        case 506:
                            this.chk506.Checked = v.Values == 1 ? true : false;
                            break;
                        case 507:
                            this.chk507.Checked = v.Values == 1 ? true : false;
                            break;
                    }
                }
            }
        }

        private void xtabMain_Click(object sender, EventArgs e)
        {
            if (xtabMain.SelectedTabPageIndex == 0)
            {
                this.fLoadParameterKCB();
            }
            else if (xtabMain.SelectedTabPageIndex == 1)
            {
                this.fLoadParameterTHUOC();
            }
            else if (xtabMain.SelectedTabPageIndex == 2)
            {
                this.fLoadParameterCDHA();
            }
            else if (xtabMain.SelectedTabPageIndex == 3)
            {
                this.fLoadParameterXN();
            }
            else if (xtabMain.SelectedTabPageIndex == 4)
            {
                this.fLoadParameterVP();
            }
        }

        private void butSave01_Click(object sender, EventArgs e)
        {
            try
            {
                SystemParameterBLL.Ins(1, "KCB", this.chk1.Name, this.chk1.Checked ? 1 : 0, this.spinQuantity_01.EditValue.ToString(), this.sUserID, string.Empty);
                SystemParameterBLL.Ins(2, "KCB", this.chk2.Name, this.chk2.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
                SystemParameterBLL.Ins(3, "KCB", this.chk3.Name, this.chk3.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
                SystemParameterBLL.Ins(4, "KCB", this.chk4.Name, this.chk4.Checked ? 1 : 0, this.spinQuantity_04.EditValue.ToString(), this.sUserID, string.Empty);
                if (this.chk5.Checked && string.IsNullOrEmpty(this.txtPathUpdate.Text))
                {
                    XtraMessageBox.Show(" Chưa chọn đường dẫn cập nhật phần mềm!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                    string versionCurrent = fileVersionInfo.ProductVersion;
                    SystemParameterBLL.Ins(5, "KCB", this.chk5.Name, this.chk5.Checked ? 1 : 0, this.txtPathUpdate.Text.Trim(), this.sUserID, versionCurrent);

                }
                SystemParameterBLL.Ins(6, "KCB", this.chk6.Name, this.chk6.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
                SystemParameterBLL.Ins(7, "KCB", this.chk7.Name, this.chk7.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
                SystemParameterBLL.Ins(8, "KCB", this.chk8.Name, this.chk8.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
                SystemParameterBLL.Ins(9, "KCB", this.chk9.Name, this.chk9.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
                SystemParameterBLL.Ins(10, "KCB", this.chk10.Name, this.chk10.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
                SystemParameterBLL.Ins(11, "KCB", this.chk11.Name, this.chk11.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
                SystemParameterBLL.Ins(12, "KCB", this.chk12.Name, this.chk12.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
                SystemParameterBLL.Ins(13, "KCB", this.chk13.Name, this.chk13.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
                SystemParameterBLL.Ins(14, "KCB", this.chk14.Name, this.chk14.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
                SystemParameterBLL.Ins(15, "KCB", this.chk15.Name, this.chk15.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
                SystemParameterBLL.Ins(16, "KCB", this.chk16.Name, this.chk16.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
                XtraMessageBox.Show(" Cập nhật thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.fLoadParameterKCB();
            }
            catch { }
        }

        private void butSave02_Click(object sender, EventArgs e)
        {
            SystemParameterBLL.Ins(200, "THUOC", this.chk200.Name, this.chk200.Checked ? 1 : 0,  string.Empty, this.sUserID, string.Empty);
            SystemParameterBLL.Ins(201, "THUOC", this.chk201.Name, this.chk201.Checked ? 1 : 0,  string.Empty, this.sUserID, string.Empty);
            SystemParameterBLL.Ins(202, "THUOC", this.chk202.Name, this.chk202.Checked ? 1 : 0,  string.Empty, this.sUserID, string.Empty);
            SystemParameterBLL.Ins(203, "THUOC", this.chk203.Name, this.chk203.Checked ? 1 : 0,  string.Empty, this.sUserID, string.Empty);
            SystemParameterBLL.Ins(204, "THUOC", this.chk204.Name, this.chk204.Checked ? 1 : 0, this.spinQuantity_204.EditValue.ToString(), this.sUserID, string.Empty);
            SystemParameterBLL.Ins(205, "THUOC", this.chk205.Name, this.chk205.Checked ? 1 : 0,  string.Empty, this.sUserID, string.Empty);
            SystemParameterBLL.Ins(206, "THUOC", this.chk206.Name, this.chk206.Checked ? 1 : 0,  string.Empty, this.sUserID, string.Empty);
            SystemParameterBLL.Ins(207, "THUOC", this.chk207.Name, this.chk207.Checked ? 1 : 0,  string.Empty, this.sUserID, string.Empty);
            SystemParameterBLL.Ins(208, "THUOC", this.chk208.Name, this.chk208.Checked ? 1 : 0,  string.Empty, this.sUserID, string.Empty);
            SystemParameterBLL.Ins(209, "THUOC", this.chk209.Name, this.chk209.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
            SystemParameterBLL.Ins(210, "THUOC", this.chk210.Name, this.chk210.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
            SystemParameterBLL.Ins(211, "THUOC", this.chk211.Name, this.chk211.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
            SystemParameterBLL.Ins(212, "THUOC", this.chk212.Name, this.chk212.Checked ? 1 : 0, this.chkListBox_212.EditValue.ToString(), this.sUserID, string.Empty);
            SystemParameterBLL.Ins(213, "THUOC", this.chk213.Name, this.chk213.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
            XtraMessageBox.Show(" Cập nhật thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.fLoadParameterTHUOC();
        }

        private void butSave03_Click(object sender, EventArgs e)
        {
            SystemParameterBLL.Ins(300, "CDHA", this.chk300.Name, this.chk300.Checked ? 1 : 0, this.spinValues300.EditValue.ToString(), this.sUserID, string.Empty);
            SystemParameterBLL.Ins(301, "CDHA", this.chk301.Name, this.chk301.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
            SystemParameterBLL.Ins(302, "CDHA", this.chk302.Name, this.chk302.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
            XtraMessageBox.Show(" Cập nhật thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.fLoadParameterCDHA();
        }

        private void butSave04_Click(object sender, EventArgs e)
        {
            try
            {
                SystemParameterBLL.Ins(400, "XN", this.chk400.Name, this.chk400.Checked ? 1 : 0, this.txtPathFolder.Text.Trim(), sUserID, string.Empty);
                if (this.chk401.Checked && string.IsNullOrEmpty(this.cb401.EditValue.ToString()))
                    SystemParameterBLL.Ins(401, "XN", this.chk401.Name, 0, this.cb401.EditValue.ToString(), sUserID, string.Empty);
                else
                    SystemParameterBLL.Ins(401, "XN", this.chk401.Name, this.chk401.Checked ? 1 : 0, this.cb401.EditValue.ToString(), sUserID, string.Empty);
                SystemParameterBLL.Ins(402, "XN", this.chk402.Name, this.chk402.Checked ? 1 : 0, string.Empty, sUserID, string.Empty);
                XtraMessageBox.Show(" Cập nhật thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.fLoadParameterXN();
            }
            catch { return; }
        }

        private void butSave05_Click(object sender, EventArgs e)
        {
            SystemParameterBLL.Ins(500, "VIENPHI", this.chk500.Name, this.chk500.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
            SystemParameterBLL.Ins(501, "VIENPHI", this.chk501.Name, this.chk501.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
            //SystemParameterBLL.Ins(502, "VIENPHI", this.chk502.Name, this.chk502.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
            SystemParameterBLL.Ins(503, "VIENPHI", this.chk503.Name, this.chk503.Checked ? 1 : 0, this.cbxPrinter503.SelectedIndex.ToString(), this.sUserID, string.Empty);
            SystemParameterBLL.Ins(504, "VIENPHI", this.chk504.Name, this.chk504.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
            SystemParameterBLL.Ins(505, "VIENPHI", this.chk505.Name, this.chk505.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
            SystemParameterBLL.Ins(506, "VIENPHI", this.chk506.Name, this.chk506.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
            SystemParameterBLL.Ins(507, "VIENPHI", this.chk507.Name, this.chk507.Checked ? 1 : 0, string.Empty, this.sUserID, string.Empty);
            XtraMessageBox.Show(" Cập nhật thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.fLoadParameterVP();
        }

        private void frmThongsohethong_Load(object sender, EventArgs e)
        {
            this.chkListBox_212.Properties.DataSource = ObjectBLL.DTObjectList(0);
            this.chkListBox_212.Properties.ValueMember = "ObjectCode";
            this.chkListBox_212.Properties.DisplayMember = "ObjectName";
            this.fLoadParameterKCB();

        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                folderDlg.ShowNewFolderButton = true;
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.txtPathFolder.Text = folderDlg.SelectedPath;
                    Environment.SpecialFolder root = folderDlg.RootFolder;
                }
            }
            catch { return; }
        }

        private void chk401_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk401.Checked)
                this.chk400.Checked = false;
        }

        private void chk400_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk400.Checked)
                this.chk401.Checked = false;
        }

        private void chk503_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk503.Checked)
                this.cbxPrinter503.Enabled = true;
            else
                this.cbxPrinter503.Enabled = false;
        }

        private void chk211_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk211.Checked)
                this.chk213.Enabled = true;
            else
                this.chk213.Enabled = false;
        }
        
    }
}