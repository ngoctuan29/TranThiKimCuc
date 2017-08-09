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
using DevExpress.XtraReports.UI;
using ClinicBLL;
using ClinicLibrary;

namespace Ps.Clinic.Statistics
{
    public partial class frmThongKeDuyetToaBS : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtbResult = new DataTable();
        public frmThongKeDuyetToaBS()
        {
            InitializeComponent();
        }
        
        private void butCount_Click(object sender, EventArgs e)
        {
            try
            {
                string itemCode = string.Empty;
                if (sLookupItem.EditValue != null)
                    itemCode = sLookupItem.EditValue.ToString();
                string employeeCode = cbEmployee.EditValue.ToString();
                string[] arrEmployeeCode;
                if (employeeCode.Length > 0)
                    arrEmployeeCode = employeeCode.Split(',');
                else
                    arrEmployeeCode = null;
                if (arrEmployeeCode != null)
                {
                    employeeCode = string.Empty;
                    for (Int32 i = 0; i < arrEmployeeCode.Length; i++)
                    {
                        employeeCode += "'" + arrEmployeeCode[i].ToString().Trim() + "',";
                    }
                }
                if (!this.chkGeneral.Checked)
                {
                    this.dtbResult = MedicinesRetailBLL.TableResultMedicinesRetail(this.txtPatientCode.Text.Trim(), this.dllNgay.tungay.Text, this.dllNgay.denngay.Text, itemCode, employeeCode.TrimEnd(','));
                    this.gridControl_Result.DataSource = dtbResult;
                    this.gridView_Result.Columns["PatientName"].Group();
                    this.pnGeneral.Visible = false;
                    this.pnGeneral.Dock = DockStyle.None;
                    this.pnDetail.Visible = true;
                    this.pnDetail.Dock = DockStyle.Fill;
                    //gridView_Result.ExpandAllGroups();
                }
                else
                {
                    this.dtbResult = MedicinesRetailBLL.TableResultMedicinesRetailGroupForDoctor(this.txtPatientCode.Text.Trim(), this.dllNgay.tungay.Text, this.dllNgay.denngay.Text, itemCode, employeeCode.TrimEnd(','));
                    this.gridControlGeneral.DataSource = dtbResult;
                    this.gridViewGeneral.Columns["EmployeeName"].Group();
                    this.pnGeneral.Visible = true;
                    this.pnGeneral.Dock = DockStyle.Fill;
                    this.pnDetail.Visible = false;
                    this.pnDetail.Dock = DockStyle.None;
                }
            }
            catch { }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            gridControl_Result.ShowRibbonPrintPreview();
        }

        private void frmThongKeToaBS_Load(object sender, EventArgs e)
        {
            try
            {
                this.cbEmployee.Properties.DataSource = EmployeeBLL.ListEmployeeForPosition("3");
                this.cbEmployee.Properties.DisplayMember = "EmployeeName";
                this.cbEmployee.Properties.ValueMember = "EmployeeCode";

                this.sLookupItem.Properties.DataSource = ItemsBLL.ListItemsRef(0);
                this.sLookupItem.Properties.DisplayMember = "ItemName";
                this.sLookupItem.Properties.ValueMember = "ItemCode";

                this.pnGeneral.Visible = false;
                this.pnDetail.Visible = true;
                this.pnDetail.Dock = DockStyle.Fill;
            }
            catch { }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    DataSet dataSetTemp = new DataSet();
                    dataSetTemp.Tables.Add(dtbResult);
                    if (!this.chkGeneral.Checked)
                    {
                        dataSetTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rpt_KB_BangKeToaThuocBacSi.xml");
                        Reports.rpt_KB_BangKeToaThuocBacSiCT rptShow = new Reports.rpt_KB_BangKeToaThuocBacSiCT();
                        rptShow.Parameters["fromdate"].Value = dllNgay.tungay.Text;
                        rptShow.Parameters["todate"].Value = dllNgay.denngay.Text;
                        rptShow.DataSource = dataSetTemp;
                        Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "BKeToaThuocBS", "Thống kê toa bác sỹ");
                        rpt.ShowDialog();
                    }
                    else
                    {
                        dataSetTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rpt_KB_BangKeToaThuocBacSiGroupDoctor.xml");
                        Reports.rpt_KB_BangKeToaThuocBacSi rptShow = new Reports.rpt_KB_BangKeToaThuocBacSi();
                        rptShow.Parameters["fromdate"].Value = dllNgay.tungay.Text;
                        rptShow.Parameters["todate"].Value = dllNgay.denngay.Text;
                        rptShow.DataSource = dataSetTemp;
                        Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "BKeToaThuocBS","Thống kê toa bác sỹ");
                        rpt.ShowDialog();
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Số liệu báo cáo chưa phát sinh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

    }
}