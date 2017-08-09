using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.Linq;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using COMExcel = Microsoft.Office.Interop.Excel;
using System.Globalization;
using DevExpress.XtraTab;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;
using DevExpress.XtraSplashScreen;

namespace Ps.Clinic.Statistics
{
    public partial class frmRpt_KetXuatDuLieu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable dtResult;
        private DateTime dtServer = new DateTime();
        private string userID = string.Empty;

        public frmRpt_KetXuatDuLieu(string _userID)
        {
            InitializeComponent();
            this.userID = _userID;
        }
        
        private void btnBMTE_Click(object sender, EventArgs e)
        {
            this.dtResult = new DataTable();
            this.dtResult = rpt_General_BLL.XuatBCTE(this.dllNgay.tungay.Text, this.dllNgay.denngay.Text);
            this.butExport.Enabled = this.butExtoxml.Enabled = false;
            try
            {
                DataSet dsTemp = new DataSet("table");
                dsTemp.Tables.Add(dtResult);
                dsTemp.Merge(dtResult);
                dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptBMTE.xml");
                Reports.rpt_BMTE rptShow = new Reports.rpt_BMTE(this.dtServer);
                rptShow.Parameters["fromdate"].Value = this.dllNgay.tungay.Text;
                rptShow.Parameters["todate"].Value = this.dllNgay.denngay.Text;
                rptShow.DataSource = dsTemp;
                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "BMTE","Biểu mẫu BCTE");
                rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnIn21_Click(object sender, EventArgs e)
        {
            dtResult = new DataTable();
            dtResult = rpt_General_BLL.Xuat21(this.dllNgay.tungay.Text, this.dllNgay.denngay.Text);
            this.butExport.Enabled = this.butExtoxml.Enabled = false;
            try
            {
                DataSet dsTemp = new DataSet("table");
                dsTemp.Tables.Add(dtResult);
                dsTemp.Merge(dtResult);
                dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptBM21.xml");
                Reports.rpt_BM21 rptShow = new Reports.rpt_BM21();
                rptShow.Parameters["fromdate"].Value = this.dllNgay.tungay.Text;
                rptShow.Parameters["todate"].Value = this.dllNgay.denngay.Text;
                rptShow.DataSource = dsTemp;
                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "BM 21", "BM 21");
                rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBM20_Click(object sender, EventArgs e)
        {
            dtResult = new DataTable();
            dtResult = rpt_General_BLL.Xuat20(dllNgay.tungay.Text, dllNgay.denngay.Text);
            this.butExport.Enabled = this.butExtoxml.Enabled = false;
            try
            {
                DataSet dsTemp = new DataSet("table");
                dsTemp.Tables.Add(dtResult);
                dsTemp.Merge(dtResult);
                dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptBM20.xml");
                Reports.rpt_BM20 rptShow = new Reports.rpt_BM20(this.dtServer);
                rptShow.Parameters["fromdate"].Value = this.dllNgay.tungay.Text;
                rptShow.Parameters["todate"].Value = this.dllNgay.denngay.Text;
                rptShow.DataSource = dsTemp;
                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "BM 20", "Biểu mẫu 20");
                rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void butReviewer_1_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadWaiting();
                this.gridControl_XML1.Visible = true;
                this.gridControl_XML2.Visible = gridControl_XML3.Visible = false;
                this.gridControl_XML1.DataSource = null;
                this.gridControl_XML2.DataSource = null;
                this.gridControl_XML3.DataSource = null;
                this.butExport.Enabled = this.butExtoxml.Enabled = true;

                this.dtResult = new DataTable("Bang1");
                this.dtResult = rpt_General_BLL.WriteXML1_9324(this.dllNgay.tungay.Text, this.dllNgay.denngay.Text, this.txtMaLK.Text);
                this.gridControl_XML1.DataSource = this.dtResult;
            }
            catch
            {
                this.gridControl_XML1.DataSource = null;
            }
            this.CloseWaiting();
        }

        private void butExport_Click(object sender, EventArgs e)
        {
            ViewPopup.frmExcelPathName frmPath = new ViewPopup.frmExcelPathName();
            frmPath.ShowInTaskbar = false;
            frmPath.ShowDialog();
            if (frmPath.reloaded)
            {
                try
                {

                    if (this.gridControl_XML1.Visible == true)
                    {
                        this.gridControl_XML1.ExportToXls(frmPath.pathName);
                    }
                    if (this.gridControl_XML2.Visible == true)
                    {
                        this.gridControl_XML2.ExportToXls(frmPath.pathName);
                    }
                    if (this.gridControl_XML3.Visible == true)
                    {
                        this.gridControl_XML3.ExportToXls(frmPath.pathName);
                    }
                    XtraMessageBox.Show("Lưu thành công tại " + frmPath.pathName, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void butReviewer_2_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadWaiting();
                this.gridControl_XML2.Visible = true;
                this.gridControl_XML1.Visible = gridControl_XML3.Visible = false;
                this.gridControl_XML1.DataSource = null;
                this.gridControl_XML2.DataSource = null;
                this.gridControl_XML3.DataSource = null;
                this.butExport.Enabled = this.butExtoxml.Enabled = true;
                this.dtResult = new DataTable();
                this.dtResult = rpt_General_BLL.WriteXML2_9324(this.dllNgay.tungay.Text, this.dllNgay.denngay.Text, this.txtMaLK.Text);
                this.gridControl_XML2.DataSource = this.dtResult;
            }
            catch
            {
                this.gridControl_XML2.DataSource = null;
            }
            this.CloseWaiting();
        }

        private void butReviewer_3_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadWaiting();
                this.gridControl_XML3.Visible = true;
                this.gridControl_XML1.Visible = gridControl_XML2.Visible = false;
                this.gridControl_XML1.DataSource = null;
                this.gridControl_XML2.DataSource = null;
                this.gridControl_XML3.DataSource = null;
                this.butExport.Enabled = this.butExtoxml.Enabled = true;
                this.dtResult = new DataTable();
                this.dtResult = rpt_General_BLL.WriteXML3_9324(this.dllNgay.tungay.Text, this.dllNgay.denngay.Text, this.txtMaLK.Text);
                this.gridControl_XML3.DataSource = this.dtResult;
            }
            catch
            {
                this.gridControl_XML3.DataSource = null;
            }
            this.CloseWaiting();
        }

        private void btnInBM79a_Click(object sender, EventArgs e)
        {
            this.dtResult = new DataTable();
            this.dtResult = rpt_General_BLL.XuatBM79a(this.dllNgay.tungay.Text, this.dllNgay.denngay.Text);
            this.butExport.Enabled = this.butExtoxml.Enabled = false;
            try
            {
                DataSet dsTemp = new DataSet("table");
                dsTemp.Tables.Add(dtResult);
                dsTemp.Merge(dtResult);
                dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptBM79a.xml");
                Reports.rpt_BM79a rptShow = new Reports.rpt_BM79a(this.dtServer);
                rptShow.Parameters["fromdate"].Value = this.dllNgay.tungay.Text;
                rptShow.Parameters["todate"].Value = this.dllNgay.denngay.Text;
                rptShow.DataSource = dsTemp;
                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "BM 79a","Biểu mẫu 79a");
                rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtPathSave.Text))
                {
                    string pathSaveXML = string.Empty;
                    if (this.gridControl_XML1.Visible == true)
                    {
                        DataSet dsTemp = new DataSet("CHITIEUTONGHOPKCBBHYT");
                        dtResult.TableName = "TONG_HOP";
                        //dsTemp.Tables.Add(dtResult);
                        dsTemp.Merge(dtResult);
                        pathSaveXML = this.txtPathSave.Text + "\\XML1.xml";
                        dsTemp.WriteXml(pathSaveXML);
                    }
                    if (this.gridControl_XML2.Visible == true)
                    {
                        DataSet dsTemp = new DataSet("DSACH_CHI_TIET_THUOC");
                        dtResult.TableName = "CHI_TIET_THUOC";
                        //dsTemp.Tables.Add(dtResult);
                        dsTemp.Merge(dtResult);
                        pathSaveXML = this.txtPathSave.Text + "\\XML2.xml";
                        dsTemp.WriteXml(pathSaveXML);
                    }
                    if (this.gridControl_XML3.Visible == true)
                    {
                        DataSet dsTemp = new DataSet("DSACH_CHI_TIET_DVKT");
                        dtResult.TableName = "CHI_TIET_DVKT";
                        //dsTemp.Tables.Add(dtResult);
                        dsTemp.Merge(dtResult);
                        pathSaveXML = this.txtPathSave.Text + "\\XML3.xml";
                        dsTemp.WriteXml(pathSaveXML);
                    }
                    XtraMessageBox.Show("Lưu thành công tại " + pathSaveXML, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Chọn đường dẫn lưu file gửi giám định!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBM19_Click(object sender, EventArgs e)
        {
            dtResult = new DataTable();
            dtResult = rpt_General_BLL.Xuat19(this.dllNgay.tungay.Text, this.dllNgay.denngay.Text);
            this.butExport.Enabled = this.butExtoxml.Enabled = false;
            try
            {
                DataSet dsTemp = new DataSet("table");
                dsTemp.Tables.Add(this.dtResult);
                dsTemp.Merge(dtResult);
                dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptBM19.xml");
                Reports.rpt_BM19 rptShow = new Reports.rpt_BM19(this.dtServer);
                rptShow.Parameters["fromdate"].Value = this.dllNgay.tungay.Text;
                rptShow.Parameters["todate"].Value = this.dllNgay.denngay.Text;
                rptShow.DataSource = dsTemp;
                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "BM 19","Biểu mẫu 19");
                rpt.ShowDialog();
            }
            catch (Exception ex) { 
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnInBM80a_Click(object sender, EventArgs e)
        {
            this.dtResult = new DataTable();
            this.dtResult = rpt_General_BLL.XuatBM80a(dllNgay.tungay.Text, dllNgay.denngay.Text);
            this.butExport.Enabled = this.butExtoxml.Enabled = false;
            try
            {
                DataSet dsTemp = new DataSet("table");
                dsTemp.Tables.Add(this.dtResult);
                dsTemp.Merge(dtResult);
                dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptBM80a.xml");
                Reports.rpt_BM80a rptShow = new Reports.rpt_BM80a(this.dtServer);
                rptShow.Parameters["fromdate"].Value = this.dllNgay.tungay.Text;
                rptShow.Parameters["todate"].Value = this.dllNgay.denngay.Text;
                rptShow.DataSource = dsTemp;
                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "BM 80a","KB-Mẫu 80a");
                rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void picClear_Click(object sender, EventArgs e)
        {
            this.txtMaLK.Text = string.Empty;
        }
        
        private void LoadWaiting()
        {
            SplashScreenManager.ShowForm(this, typeof(Entry.frmWaiting), true, true, false);
        }

        private void CloseWaiting()
        {
            SplashScreenManager.CloseForm(false);
        }

        private void frmRpt_KetXuatDuLieu_Load(object sender, EventArgs e)
        {
            try
            {
                this.dtServer = Utils.DateTimeServer();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void btnSendGD_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtResult != null && this.dtResult.Rows.Count > 0)
                {
                    Entry.frmUploadHSGDBHYT frmUpload = new Entry.frmUploadHSGDBHYT(this.userID, this.txtPathSave.Text);
                    frmUpload.ShowInTaskbar = false;
                    frmUpload.ShowDialog();
                }
                else
                    XtraMessageBox.Show("Dữ liệu chưa phát sinh! Vui lòng xem lại thông tin kết xuất file báo cáo.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butPathSave_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    this.txtPathSave.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnClearPath_Click(object sender, EventArgs e)
        {
            this.txtPathSave.Text = string.Empty;
        }
        
    }
}