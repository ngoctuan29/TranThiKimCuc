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
    public partial class frmKBSoKB : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtbResult = new DataTable();
        private string employeeCode = string.Empty;
        public frmKBSoKB(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }

        private void butRefesh_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tabMain.SelectedTabPageIndex == 1)
                {
                    this.dtbResult = rpt_General_BLL.TableViewListMedical(this.controlDatetime.TN.ToString(), this.controlDatetime.DN.ToString(), 2);
                    this.gridControl_Result.DataSource = this.dtbResult;
                    this.gridVIew_Result.Columns["ObjectName"].Group();
                    this.gridVIew_Result.ExpandAllGroups();
                }
                else if (this.tabMain.SelectedTabPageIndex == 0)
                {
                    this.dtbResult = rpt_General_BLL.TableViewListMedical(this.controlDatetime.TN.ToString(), this.controlDatetime.DN.ToString(), 1);
                    this.gridControl_ListPatient.DataSource = this.dtbResult;
                    this.gridView_ListPatient.Columns["WorkDate"].Group();
                    this.gridView_ListPatient.ExpandAllGroups();
                }
                else if (this.tabMain.SelectedTabPageIndex == 2)
                {
                    this.dtbResult = PatientReceiveBLL.DT_View_ListReportReceive(this.controlDatetime.TN.ToString(), this.controlDatetime.DN.ToString());
                    this.gridControl_Receive.DataSource = this.dtbResult;
                    this.gridView_Receive.Columns["DepartmentName"].Group();
                    ///this.gridView_Receive.ExpandAllGroups();
                }
            }
            catch {
                XtraMessageBox.Show("Dữ liệu chưa phát sinh !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            if (this.dtbResult != null && this.dtbResult.Rows.Count > 0)
            {
                if (this.tabMain.SelectedTabPageIndex == 1)
                {
                    DataSet dsTemp = new DataSet();
                    dsTemp.Merge(this.dtbResult);
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\viewKB_ListMedical.xml");
                    Reports.rpt_KB_SoKhamBenh rptShow = new Reports.rpt_KB_SoKhamBenh();
                    rptShow.Parameters["fromdate"].Value = this.controlDatetime.TN.ToString();
                    rptShow.Parameters["todate"].Value = this.controlDatetime.DN.ToString();
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "SoKhamBenh","Sổ khám bệnh");
                    rpt.ShowDialog();
                }
                else if (this.tabMain.SelectedTabPageIndex == 2)
                {
                    this.gridControl_Receive.ShowRibbonPrintPreview();
                }
            }
            else
            {
                XtraMessageBox.Show("Không có dữ liệu phát sinh !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void tabMain_TabIndexChanged(object sender, EventArgs e)
        {
            this.butRefesh_Click(sender, e);
        }

        private void tabMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            this.butRefesh_Click(sender, e);
        }
    }
}