using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports;
using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using DevExpress.XtraGrid.Views.Grid;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using System.Windows.Forms;
using System.Reflection;

namespace Ps.Clinic.Statistics
{
    public partial class frm_BM05_YTTN_SKSS : Form
    {

        private DataTable dtbResult = new DataTable();
        private DevExpress.Utils.WaitDialogForm Starting = null;
        private DateTime dtWorking = new DateTime();
        private string employeeCode = string.Empty;
        private decimal rowID_BM05 = 0;
        private Excel.Application oxl;
        private Excel._Workbook owb;
        private Excel._Worksheet osheet;

        public frm_BM05_YTTN_SKSS(DateTime _dtWorking, string _employeeCode)
        {
            InitializeComponent();
            this.dtWorking = _dtWorking;
            this.employeeCode = _employeeCode;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDateTime(this.controlDatetime.TN) > Convert.ToDateTime(this.controlDatetime.DN))
                {
                    XtraMessageBox.Show("Ngày chọn không hợp lệ. Vui lòng xem lại!", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.controlDatetime.Focus();
                    return;
                }
                if (this.dtbResult != null && this.dtbResult.Rows.Count > 0)
                {
                    this.rowID_BM05 = -1;
                    if (this.lkupBM05.EditValue == null)
                        this.rowID_BM05 = -1;
                    else
                        this.rowID_BM05 = Convert.ToDecimal(this.lkupBM05.EditValue);
                    BM05_YTTNInf inf = new BM05_YTTNInf { RowID = 0, EmployeeCode = this.employeeCode, FromDate = Convert.ToDateTime(this.controlDatetime.TN), ToDate = Convert.ToDateTime(this.controlDatetime.DN), WorkDate = Convert.ToDateTime(this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer()) };
                    int result = Rpt_VuDieuTriBLL.InsBC_BM05(inf, ref this.rowID_BM05);
                    if (result > 0)
                    {
                        bool isResult = true;
                        foreach (DataRow row in this.dtbResult.Rows)
                        {
                            BM05_YTTNDetailInf detail = new BM05_YTTNDetailInf();
                            detail.RowID_BM05 = this.rowID_BM05;
                            detail.RowIDTemplate = Convert.ToInt32(row["RowIDTemplate"]);
                            detail.TargetName = row["TargetName"].ToString();
                            detail.Result = row["Result"].ToString();
                            if (Rpt_VuDieuTriBLL.InsBC_BM05Detail(detail) <= 0)
                            {
                                isResult = false;
                                break;
                            }
                        }
                        if (!isResult)
                        {
                            XtraMessageBox.Show("Dữ liệu báo cáo lưu trữ không thành công! \n\r Xem lại thông tin nhập báo cáo.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            XtraMessageBox.Show("Lưu báo cáo thành công.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (result == -1)
                    {
                        XtraMessageBox.Show("Ngày tháng báo cáo không hợp lệ, đã trùng với dữ liệu báo cáo trước đó.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                        XtraMessageBox.Show("Dữ liệu nhập chưa được lưu! Vui lòng xem lại thông tin trên báo cáo.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.btnCancel.Enabled = this.butPrint.Enabled = true;
                }
                else
                {
                    XtraMessageBox.Show("Nhập dữ liệu báo cáo trước khi lưu.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                XtraMessageBox.Show("Không có dữ liệu phát sinh !", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tableResult = Rpt_VuDieuTriBLL.TableViewBM05(this.rowID_BM05);
                DataTable tableTemp = new DataTable();
                if (tableResult != null && tableResult.Rows.Count > 0)
                {
                    DataRow rowadd = tableTemp.NewRow();
                    foreach (DataRow row in tableResult.Rows)
                    {
                        tableTemp.Columns.Add("C_" + row["LaMa"].ToString() + "_" + row["OrderNumber"].ToString(), typeof(string));
                    }
                    tableTemp.Rows.Add(rowadd);
                    foreach (DataRow row in tableResult.Rows)
                    {
                        tableTemp.Rows[0]["C_" + row["LaMa"].ToString() + "_" + row["OrderNumber"].ToString()] = row["Result"].ToString();
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Số liệu báo cáo chưa phát sinh.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                ViewPopup.frmExcelPathName frmPath = new ViewPopup.frmExcelPathName();
                frmPath.ShowDialog();
                if (frmPath.reloaded)
                {
                    Starting = new DevExpress.Utils.WaitDialogForm("Đang xử lý ...", "Bệnh viện điện tử .NET");
                    Utils.Check_Process_Excel();
                    DataSet dsTemp = new DataSet();
                    dsTemp.Merge(tableTemp);
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\View_BM05_YTTN_SKSS.xml");
                    Reports.rpt_BM05_YTTN_SKSS rpt = new Reports.rpt_BM05_YTTN_SKSS();
                    rpt.DataSource = dsTemp;
                    rpt.Parameters["prReportDate"].Value = "( Báo cáo: từ ngày  " + this.controlDatetime.TN.ToString() + " đến ngày " + this.controlDatetime.DN.ToString();
                    rpt.ExportOptions.Xls.ShowGridLines = true;
                    rpt.ExportOptions.Xls.SheetName = "SKSS";
                    rpt.ExportToXls(frmPath.pathName);
                    oxl = new Excel.Application();
                    owb = (Excel._Workbook)(oxl.Workbooks.Open(frmPath.pathName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                    osheet = (Excel._Worksheet)owb.ActiveSheet;
                    oxl.ActiveWindow.DisplayGridlines = false;
                    oxl.ActiveWindow.DisplayZeros = false;
                    oxl.Visible = true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Starting.Close();
        }

        private void frm_BM05_YTTN_SKSS_Load(object sender, EventArgs e)
        {
            try
            {
                this.gridControl_Result.DataSource = null;
                this.lkupBM05.Properties.DataSource = Rpt_VuDieuTriBLL.TableBM05();
                this.lkupBM05.Properties.DisplayMember = "BM05Name";
                this.lkupBM05.Properties.ValueMember = "RowID";
                this.butContinues.Enabled = true;
                this.butSave.Enabled = this.btnCancel.Enabled = this.butPrint.Enabled = this.btnGetData.Enabled = false;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butContinues_Click(object sender, EventArgs e)
        {
            this.dtbResult = Rpt_VuDieuTriBLL.TableBM05Default();
            if (this.dtbResult != null && this.dtbResult.Rows.Count > 0)
            {
                foreach (DataRow row in this.dtbResult.Rows)
                {
                    if (!string.IsNullOrEmpty(row["LaMa"].ToString()) && !string.IsNullOrEmpty(row["LaMa_Detail"].ToString()))
                        row["LaMa"] = string.Empty;
                }
            }
            this.gridControl_Result.DataSource = this.dtbResult;
            this.lkupBM05.Properties.DataSource = Rpt_VuDieuTriBLL.TableBM05();
            this.lkupBM05.Properties.DisplayMember = "BM05Name";
            this.lkupBM05.Properties.ValueMember = "RowID";
            this.lkupBM05.EditValue = null;
            this.btnGetData.Enabled = true;
            this.butPrint.Enabled = this.butSave.Enabled = this.btnCancel.Enabled = false;
        }

        private void lkupBM05_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkupBM05.EditValue != null)
            {
                this.rowID_BM05 = Convert.ToDecimal(this.lkupBM05.EditValue.ToString());
                this.dtbResult = Rpt_VuDieuTriBLL.TableBM05Default(this.rowID_BM05);
                if (this.dtbResult != null && this.dtbResult.Rows.Count > 0)
                {
                    foreach (DataRow row in this.dtbResult.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["LaMa"].ToString()) && !string.IsNullOrEmpty(row["LaMa_Detail"].ToString()))
                            row["LaMa"] = string.Empty;
                        if (Utils.CheckNumber(row["Result"].ToString()))
                            row["Check_"] = 1;
                    }
                }
                this.gridControl_Result.DataSource = this.dtbResult;
                this.btnGetData.Enabled = false;
                this.butPrint.Enabled = this.btnCancel.Enabled = this.butSave.Enabled = true;
            }
        }

        private void gridVIew_Result_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                string lama = string.Empty;
                int check_ = 0;
                if (e.RowHandle >= 0)
                {
                    lama = View.GetRowCellDisplayText(e.RowHandle, View.Columns["LaMa"]);
                    if (!string.IsNullOrEmpty(lama))
                    {
                        e.Appearance.ForeColor = Color.Black;
                        e.Appearance.Font = new Font(this.Font, FontStyle.Bold);
                    }
                    check_ = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["Check_"]));
                    if (check_ == 1)
                    {
                        e.Appearance.ForeColor = Color.Red;
                        e.Appearance.Font = new Font(this.Font, FontStyle.Bold);
                    }
                }
            }
            catch { throw new Exception(); }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                Starting = new DevExpress.Utils.WaitDialogForm("Đang xử lý ... vui lòng chờ.", "Bệnh viện điện tử .NET");
                if (Convert.ToDateTime(this.controlDatetime.TN) > Convert.ToDateTime(this.controlDatetime.DN))
                {
                    XtraMessageBox.Show("Ngày chọn không hợp lệ. Vui lòng xem lại!", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.controlDatetime.Focus();
                    return;
                }
                DataTable tableSoKhamThai = Rpt_VuDieuTriBLL.SoKhamThai(this.controlDatetime.TN.ToString(), this.controlDatetime.DN.ToString());
                DataTable tableSoDe = Rpt_VuDieuTriBLL.SoDe(this.controlDatetime.TN.ToString(), this.controlDatetime.DN.ToString());
                string lama = string.Empty;
                foreach (DataRow row in this.dtbResult.Rows)
                {
                    string servicecode = row["ServiceCode"].ToString();
                    if (!string.IsNullOrEmpty(row["LaMa"].ToString()))
                        lama = row["LaMa"].ToString();
                    string rowID = lama + "_" + row["LaMa_Detail"].ToString();
                    DataTable tableTemp = new DataTable();
                    switch (rowID)
                    {
                        case "I_1":
                            row["Result"] = tableSoKhamThai.Rows.Count.ToString();
                            row["Check_"] = 1;
                            break;
                        case "I_1.1":
                            row["Result"] = tableSoKhamThai.Select("PatientAge<15").Length.ToString();
                            row["Check_"] = 1;
                            break;
                        case "I_2":
                            row["Result"] = tableSoKhamThai.Select("XNHIV<>''").Length.ToString();
                            row["Check_"] = 1;
                            break;
                        case "I_3":
                            //tableTemp = Rpt_VuDieuTriBLL.TableViewTotalSuggested(Convert.ToDateTime(this.controlDatetime.TN), Convert.ToDateTime(this.controlDatetime.DN), servicecode.Replace(" ", ""));
                            //if (tableTemp != null && tableTemp.Rows.Count > 0)
                            //    row["Result"] = tableTemp.Rows[0][0].ToString();
                            row["Result"] = tableSoKhamThai.Rows.Count.ToString();
                            row["Check_"] = 1;
                            break;
                        case "I_3.1":
                            tableTemp = Rpt_VuDieuTriBLL.TableViewTotalSuggested(Convert.ToDateTime(this.controlDatetime.TN), Convert.ToDateTime(this.controlDatetime.DN), servicecode.Replace(" ", ""));
                            if (tableTemp != null && tableTemp.Rows.Count > 0)
                                row["Result"] = tableTemp.Rows[0][0].ToString();
                            row["Check_"] = 1;
                            break;
                        case "I_4.1":
                            row["Result"] = tableSoDe.Select("PatientAge<15").Length.ToString();
                            row["Check_"] = 1;
                            break;
                        case "I_4.2":
                            row["Result"] = tableSoDe.Rows.Count.ToString();
                            row["Check_"] = 1;
                            break;
                        case "I_4.3":
                            row["Result"] = tableSoDe.Select("TiemUV<>''").Length.ToString();
                            row["Check_"] = 1;
                            break;
                        case "I_4.4":
                            row["Result"] = tableSoDe.Select("KT3Lan='Có'").Length.ToString();
                            row["Check_"] = 1;
                            break;
                        case "I_4.5":
                            row["Result"] = tableSoDe.Select("KT4Lan='Có'").Length.ToString();
                            row["Check_"] = 1;
                            break;
                        case "I_4.6":
                            row["Result"] = tableSoDe.Select("XNHIVMangThai<>''").Length.ToString();
                            row["Check_"] = 1;
                            break;
                        case "I_4.7":
                            row["Result"] = tableSoDe.Select("XNHIVChuyenDa<>''").Length.ToString();
                            row["Check_"] = 1;
                            break;
                        case "I_7":
                            tableTemp = Rpt_VuDieuTriBLL.TableViewTotalSuggested(Convert.ToDateTime(this.controlDatetime.TN), Convert.ToDateTime(this.controlDatetime.DN), servicecode.Replace(" ", ""));
                            if (tableTemp != null && tableTemp.Rows.Count > 0)
                                row["Result"] = tableTemp.Rows[0][0].ToString();
                            row["Check_"] = 1;
                            break;
                        case "I_8":
                            tableTemp = Rpt_VuDieuTriBLL.TableViewTotalSuggested(Convert.ToDateTime(this.controlDatetime.TN), Convert.ToDateTime(this.controlDatetime.DN), servicecode.Replace(" ", ""));
                            if (tableTemp != null && tableTemp.Rows.Count > 0)
                                row["Result"] = tableTemp.Rows[0][0].ToString();
                            row["Check_"] = 1;
                            break;
                        case "I_10":
                            DataTable tablePhaThai = Rpt_VuDieuTriBLL.SoPhaThai(this.controlDatetime.TN.ToString(), this.controlDatetime.DN.ToString());
                            row["Result"] = tablePhaThai.Rows.Count.ToString();
                            row["Check_"] = 1;
                            break;
                        default:
                            break;
                    }
                }
                this.butSave.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Starting.Close();
        }
    }
}
