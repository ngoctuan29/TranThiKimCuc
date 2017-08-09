using System;
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
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraReports.UI;
using System.Diagnostics;
using System.Reflection;
namespace Ps.Clinic.Statistics
{
    public partial class frmTheoDoiDauHieuSinhTon : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private List<view_SurviveSignInf> lst;
        public frmTheoDoiDauHieuSinhTon()
        {
            InitializeComponent();
        }

        private void frmTheoDoiDauHieuSinhTon_Load(object sender, EventArgs e)
        {
            try
            {
                txtFrom.EditValue = txtTo.EditValue = Utils.DateServer();
                slkupDepartment.Properties.DataSource = DepartmentBLL.ListDepartmentFull();
                slkupDepartment.Properties.DisplayMember = "DepartmentName";
                slkupDepartment.Properties.ValueMember = "DepartmentCode";
            }
            catch { }
        }
        
        private void butPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl_result.ShowPrintPreview();
        }

        private void butReturn_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                lst = new List<view_SurviveSignInf>();
                if (slkupDepartment.EditValue.ToString() != "")
                    lst = rpt_General_BLL.List_DauHieuSinhTon(Utils.StringToDate(txtFrom.Text), Utils.StringToDate(txtTo.Text), slkupDepartment.EditValue.ToString());
                else
                    lst = rpt_General_BLL.List_DauHieuSinhTon(Utils.StringToDate(txtFrom.Text), Utils.StringToDate(txtTo.Text), "");
                if (lst != null && lst.Count > 0)
                {
                    gridControl_result.DataSource = lst;
                    gridView_result.Columns["PatientCode"].Group();
                    gridView_result.ExpandAllGroups();
                }
                else
                {
                    XtraMessageBox.Show("Dữ liệu chưa phát sinh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Reports.view_DauSinhTon rpt = new Reports.view_DauSinhTon();
                rpt.DataSource = this.lst;
                rpt.Parameters["title"].Value = this.mnoTitle.Text.Trim();
                rpt.Parameters["fromdate"].Value = this.txtFrom.Text;
                rpt.Parameters["todate"].Value = this.txtTo.Text;
                rpt.CreateDocument();
                rpt.ShowRibbonPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

    }
}