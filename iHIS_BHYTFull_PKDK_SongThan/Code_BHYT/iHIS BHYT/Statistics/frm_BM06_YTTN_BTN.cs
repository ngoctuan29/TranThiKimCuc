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
    public partial class frm_BM06_YTTN_BTN : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable dtbResult = new DataTable();
        private DevExpress.Utils.WaitDialogForm Starting = null;

        public frm_BM06_YTTN_BTN()
        {
            InitializeComponent();
        }

        private void frmVP_BangKeHDNgay_Load(object sender, EventArgs e)
        {
            
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "Bệnh viện điện tử .NET.");
                this.dtbResult = rpt_General_BLL.TableBM_6_YTTN(Convert.ToDateTime(this.controlDatetime.tungay.Text), Convert.ToDateTime(this.controlDatetime.denngay.Text));
                Starting.Close();
                this.gridControl_Result.DataSource = this.dtbResult;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet dsXml = new DataSet();
            dsXml.Merge(dtbResult);
            dsXml.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rpt_BM6_YTTN.xml");
            Reports.rpt_BM6_YTTN_DBTN rpt = new Reports.rpt_BM6_YTTN_DBTN();
            rpt.DataSource = dsXml.Tables[0];
            rpt.Parameters["fromdate"].Value = Convert.ToDateTime(this.controlDatetime.tungay.Text);
            rpt.Parameters["todate"].Value = Convert.ToDateTime(this.controlDatetime.denngay.Text);
            rpt.CreateDocument();
            rpt.ShowRibbonPreviewDialog();
        }
    }
}