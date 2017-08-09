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
    public partial class frmTHBangKeNhapXuatThuoc : DevExpress.XtraEditors.XtraForm
    {
        private DataTable tableResult = new DataTable();
        private string repositoryCode = string.Empty;
        private string employeeCode = string.Empty;

        public frmTHBangKeNhapXuatThuoc(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }
   
        private void butCount_Click(object sender, EventArgs e)
        {
            this.repositoryCode = string.Empty;
            string sTemp = this.cbxRepository.EditValue.ToString();
            string[] arrGroup;
            if (sTemp.Trim() != string.Empty)
            {
                arrGroup = sTemp.Split(',');
                for (Int32 i = 0; i < arrGroup.Length; i++)
                {
                    this.repositoryCode += arrGroup.GetValue(i).ToString().Trim(' ') + ",";
                }
            }
            this.tableResult = rpt_Medicines_BLL.TableViewInputWarehousing(this.repositoryCode, Utils.StringToDate(this.controlDate.TN), Utils.StringToDate(this.controlDate.DN), this.chkExport.Checked ? 1 : 0);
            this.gridControl_Result.DataSource = this.tableResult;
        }
                
        private void frmBaoCao_NXT_TH_Load(object sender, EventArgs e)
        {
            try
            {
                this.cbxRepository.Properties.DataSource = RepositoryCatalog_BLL.DTListRepositoryAll(0);
                this.cbxRepository.Properties.DisplayMember = "RepositoryName";
                this.cbxRepository.Properties.ValueMember = "RepositoryCode";
            }
            catch { }
        }
        
        private void butPrintBC_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tableResult != null && this.tableResult.Rows.Count > 0)
                {
                    DataSet dsTemp = new DataSet();
                    dsTemp.Tables.Add(this.tableResult);
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\xmlTH_BangKeNhapThuoc.xml");
                    Reports.rpt_TH_BangKeNhapThuoc rptShow = new Reports.rpt_TH_BangKeNhapThuoc();
                    rptShow.Parameters["fromdate"].Value = this.controlDate.TN;
                    rptShow.Parameters["todate"].Value = this.controlDate.DN;
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "BangKeNhapThuoc","Bảng kê nhập/ xuất thuốc");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Số liệu báo cáo chưa phát sinh! Vui lòng xem lại thông tin.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbxRepository.Focus();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void chkExport_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkExport.Checked)
                this.lbRepository.Text = "Kho nhập :";
            else
                this.lbRepository.Text = "Kho nhận :";
        }


    }
}