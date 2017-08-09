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
    public partial class frmKBSoXN : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtbResult = new DataTable();
        private string employeeCode = string.Empty;
        public frmKBSoXN(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }

        private void butRefesh_Click(object sender, EventArgs e)
        {
            try
            {
                dtbResult = new DataTable();
                this.dtbResult = ServiceLaboratoryEntryBLL.TableListServiceLaboratory(this.controlDatetime.TN.ToString(), this.controlDatetime.DN.ToString());
                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    this.gridControl_Result.DataSource = this.dtbResult;
                }
                else
                {
                    XtraMessageBox.Show("Dữ liệu chưa phát sinh !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                DataSet dsTemp = new DataSet();
                dsTemp.Merge(this.dtbResult);
                dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\viewKB_ListServiceLaboratory.xml");
                Reports.rpt_KB_SoXetNghiem rptShow = new Reports.rpt_KB_SoXetNghiem();
                rptShow.Parameters["fromdate"].Value = this.controlDatetime.TN.ToString();
                rptShow.Parameters["todate"].Value = this.controlDatetime.DN.ToString();
                rptShow.DataSource = dsTemp;
                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "SoXetNghiem", "Sổ xét nghiệm");
                rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}