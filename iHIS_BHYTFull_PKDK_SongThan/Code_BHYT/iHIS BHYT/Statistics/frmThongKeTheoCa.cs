using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;

namespace Ps.Clinic.Statistics
{
    public partial class frmThongKeTheoCa : DevExpress.XtraEditors.XtraForm
    {
        private string userID = string.Empty;
        private DataTable tableResult = new DataTable();
        private DevExpress.Utils.WaitDialogForm Starting = null;
        public frmThongKeTheoCa(string _userID)
        {
            InitializeComponent();
            this.userID = _userID;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.lkupNhomDV.EditValue.ToString()))
                {
                    XtraMessageBox.Show(" Chọn nhóm dịch vụ thống kê báo cáo!", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkupNhomDV.Focus();
                    return;
                }
                this.pivotResult.DataSource = null;
                this.pivotResult.Fields.Clear();

                Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "iHIS - Bệnh Viện Điện Tử.");
                this.tableResult = rpt_General_BLL.TableTotalSuggested(this.lkupNhomDV.EditValue.ToString(), this.controlDate.tungay.Text, this.controlDate.denngay.Text, this.chkGetReceive.Checked ? 1 : 0);
                Starting.Close();
                if (this.tableResult != null && this.tableResult.Rows.Count > 0)
                {
                    this.pivotResult.DataSource = this.tableResult;
                    PivotGridField fieldServiceName = new PivotGridField("ServiceName", PivotArea.RowArea);
                    fieldServiceName.Caption = "Tên dịch vụ";
                    PivotGridField fieldAM = new PivotGridField("QuantityAM", PivotArea.DataArea);
                    fieldAM.Caption = "Ca 1";
                    fieldAM.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    fieldAM.CellFormat.FormatString = "{0:#,#}";
                    PivotGridField fieldPM = new PivotGridField("QuantityPM", PivotArea.DataArea);
                    fieldPM.Caption = "Ca 2";
                    fieldPM.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    fieldPM.CellFormat.FormatString = "{0:#,#}";
                    PivotGridField fieldEV = new PivotGridField("QuantityEV", PivotArea.DataArea);
                    fieldEV.Caption = "Ca 3";
                    fieldEV.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    fieldEV.CellFormat.FormatString = "{0:#,#}";
                    PivotGridField fieldDate = new PivotGridField("Workdate", PivotArea.ColumnArea);
                    fieldDate.Caption = "Ngày";
                    this.pivotResult.Fields.AddRange(new PivotGridField[] { fieldServiceName, fieldAM, fieldPM, fieldEV, fieldDate });
                    this.pivotResult.BestFit();

                }
                else
                {
                    XtraMessageBox.Show(" Số liệu báo cáo chưa phát sinh!\n\t Xem lại thông tin lấy báo cáo thống kê.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void frmThongKeTheoCa_Load(object sender, EventArgs e)
        {
            List<ServiceGroupInf> lstGroup = ServiceGroupBLL.ListServiceGroup(string.Empty).FindAll(x => x.ServiceModuleCode != "THUOC");
            this.lkupNhomDV.Properties.DataSource = lstGroup;
            this.lkupNhomDV.Properties.ValueMember = "ServiceGroupCode";
            this.lkupNhomDV.Properties.DisplayMember = "ServiceGroupName";
            this.tableResult.Columns.Add("ServiceName", typeof(string));
            this.tableResult.Columns.Add("Quantity", typeof(Int32));
        }
        
        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tableResult != null && this.tableResult.Rows.Count > 0)
                {
                    ViewPopup.frmExcelPathName frm = new ViewPopup.frmExcelPathName();
                    frm.ShowInTaskbar = false;
                    frm.ShowDialog();
                    if (frm.reloaded)
                    {
                        this.pivotResult.ExportToXlsx(frm.pathName);
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Số liệu báo cáo chưa phát sinh!\n\t Xem lại thông tin lấy báo cáo thống kê.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
