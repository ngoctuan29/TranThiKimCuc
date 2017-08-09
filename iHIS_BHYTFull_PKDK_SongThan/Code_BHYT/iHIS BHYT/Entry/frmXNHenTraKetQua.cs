using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using System.Globalization;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using System.Collections;

namespace Ps.Clinic.Entry
{
    public partial class frmXNHenTraKetQua : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string serviceModuleCode = "XN";
        private string patientCode = string.Empty;
        private decimal patientReceiveID = -1;
        private string patientInfo = string.Empty;
        private List<StatusInf> listStatus = new List<StatusInf>();
        private List<StatusInf> listTransfer = new List<StatusInf>();
        private string fromDate = string.Empty, toDate = string.Empty, serviceCategoryCode = string.Empty, employeeCode = string.Empty;
        private DataTable tableDetail = new DataTable();
        public frmXNHenTraKetQua(string _patientCode, decimal _patientReceiveID, string _patientInfo, string _serviceCategoryCode, string _employeeCode)
        {
            InitializeComponent();
            this.patientCode = _patientCode;
            this.patientReceiveID = _patientReceiveID;
            this.patientInfo = _patientInfo;
            this.serviceCategoryCode = _serviceCategoryCode;
            this.employeeCode = _employeeCode;
        }

        private void frmXNHenTraKetQua_Load(object sender, EventArgs e)
        {
            try
            {
                this.lbPatientInfo.Text = this.patientInfo;
                StatusInf status = new StatusInf { ID = -1 , Name = "Tất Cả" };
                this.listStatus.Add(status);
                status = new StatusInf { ID = 0, Name = "Chưa Thực Hiện" };
                this.listStatus.Add(status);
                status = new StatusInf { ID = 1, Name = "Thực Hiện" };
                this.listStatus.Add(status);
                status = new StatusInf { ID = 2, Name = "Lấy Mẫu" };
                this.listStatus.Add(status);
                status = new StatusInf { ID = -1, Name = "Tất Cả" };
                this.listTransfer.Add(status);
                status = new StatusInf { ID = 0, Name = "Mẫu Thực Hiện PK" };
                this.listTransfer.Add(status);
                status = new StatusInf { ID = 1, Name = "Mẫu Gửi Đi" };
                this.listTransfer.Add(status);
                this.lkupStatus.Properties.DataSource = this.listStatus;
                this.lkupStatus.Properties.ValueMember = "ID";
                this.lkupStatus.Properties.DisplayMember = "Name";

                this.lkupTransfer.Properties.DataSource = this.listTransfer;
                this.lkupTransfer.Properties.ValueMember = "ID";
                this.lkupTransfer.Properties.DisplayMember = "Name";
                this.lkupStatus.EditValue = -1;
                this.lkupTransfer.EditValue = -1;
                this.lkupXetNghiem.Properties.DataSource = LaboratoryBLL.DataLaboratoryForPatientAppointment(this.patientReceiveID, this.patientCode, Convert.ToInt32(this.lkupStatus.EditValue), Convert.ToInt32(this.lkupTransfer.EditValue), this.serviceModuleCode);
                this.lkupXetNghiem.Properties.ValueMember = "ServiceCategoryCode";
                this.lkupXetNghiem.Properties.DisplayMember = "ServiceCategoryName";
                this.lkupXetNghiem.EditValue = this.serviceCategoryCode;
                this.LoadDataDetail();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void LoadDataDetail()
        {
            LabAppointmentForResultsInf inf = ServiceLaboratoryEntryBLL.ObjLabAppointmentForResults(this.patientReceiveID, this.lkupXetNghiem.EditValue.ToString());
            if (inf != null && inf.PatientReceiveID > 0)
            {
                this.lkupXetNghiem.EditValue = inf.ServiceCategoryCode;
                this.dtimeFrom.Value = inf.SampleDate;
                this.dtimeTo.Value = inf.AppointmentDate;
                this.txtIDMau.Text = inf.AppointmentCode;
                this.txtContent.Text = inf.AppointmentContent;
            }
            else
            {
                this.dtimeFrom.Value = this.dtimeTo.Value = Utils.DateServer();
                this.txtContent.Text = this.txtIDMau.Text = string.Empty;
            }
            this.tableDetail = ServiceLaboratoryEntryBLL.TableListServiceLaboratoryAppointment(this.patientReceiveID, Convert.ToInt32(this.lkupStatus.EditValue), Convert.ToInt32(this.lkupTransfer.EditValue), this.lkupXetNghiem.EditValue.ToString());
            this.gridControl_Result.DataSource = this.tableDetail;
        }
        public class StatusInf
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

        private void butPrintPrescription_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tbResult = ServiceLaboratoryEntryBLL.TableReport_ServiceLabAppointment(this.patientReceiveID, this.lkupXetNghiem.EditValue.ToString());
                DataSet dsResult = new DataSet();
                if (tbResult != null && tbResult.Rows.Count > 0)
                {
                    string resultXN = string.Empty;
                    DataTable tbTemp = new DataTable();
                    if (this.tableDetail.Rows.Count > 0 && this.tableDetail.Select("Chon=True").Length > 0)
                        tbTemp = this.tableDetail.Select("Chon=True").CopyToDataTable();
                    if (tbTemp.Rows.Count > 0 && tbTemp != null)
                    {
                        foreach (DataRow row in tbTemp.Rows)
                        {
                            resultXN += row["ServiceName"] + ", ";
                        }
                    }
                    dsResult.Tables.Add(tbResult);
                    dsResult.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptXNHenTraKQ.xml");
                    Reports.rptXN_HenTraKQA5 rptShow = new Reports.rptXN_HenTraKQA5();
                    rptShow.Parameters["prResultXN"].Value = resultXN;
                    rptShow.DataSource = dsResult;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "XNHentraketqua","Hẹn trả kết quả");
                    rpt.ShowDialog();
                }
                else
                    XtraMessageBox.Show("Nội dung hẹn chưa có!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int iresult = ServiceLaboratoryEntryBLL.DelLabAppointment(this.patientReceiveID, this.lkupXetNghiem.EditValue.ToString());
                if (iresult > 0)
                {
                    DataTable tbTemp = new DataTable();
                    if (this.tableDetail.Rows.Count > 0 && this.tableDetail.Select("Chon=True").Length > 0)
                        tbTemp = this.tableDetail.Select("Chon=True").CopyToDataTable();
                    if (tbTemp.Rows.Count > 0 && tbTemp != null)
                    {
                        foreach (DataRow row in tbTemp.Rows)
                        {
                            SuggestedServiceReceiptBLL.UpdStatusAppointment(Convert.ToDecimal(row["ReceiptID"]), 0);
                        }
                    }
                    XtraMessageBox.Show("Hủy hẹn kết quả xét nghiệm thành công.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadDataDetail();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butRefesh_Click(object sender, EventArgs e)
        {
            this.LoadDataDetail();
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            GC.Collect();
            this.Close();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tbTemp = new DataTable();
                if (this.tableDetail.Rows.Count > 0 && this.tableDetail.Select("Chon=True").Length > 0)
                    tbTemp = this.tableDetail.Select("Chon=True").CopyToDataTable();
                if (tbTemp.Rows.Count > 0 && tbTemp != null)
                {
                    LabAppointmentForResultsInf inf = new LabAppointmentForResultsInf();
                    inf.PatientReceiveID = this.patientReceiveID;
                    inf.EmployeeCode = this.employeeCode;
                    inf.SampleDate = Convert.ToDateTime(this.dtimeFrom.Value);
                    inf.AppointmentDate = Convert.ToDateTime(this.dtimeTo.Value);
                    inf.AppointmentContent = this.txtContent.Text;
                    inf.ServiceCategoryCode = this.lkupXetNghiem.EditValue.ToString();
                    inf.AppointmentCode = this.txtIDMau.Text.Trim();
                    int result = ServiceLaboratoryEntryBLL.InsLabAppointment(inf);
                    bool bresult = true;
                    if (result >= 1)
                    {
                        foreach(DataRow row in tbTemp.Rows)
                        {
                            if (SuggestedServiceReceiptBLL.UpdStatusAppointment(Convert.ToDecimal(row["ReceiptID"].ToString()), 1) < 1)
                                bresult = false;
                        }
                        if (!bresult)
                            XtraMessageBox.Show("Ghi nhận lịch hẹn không thành công! \r\n Vui lòng xem lại xét nghiệm hẹn.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            XtraMessageBox.Show("Ghi hẹn trả kết quả xét nghiệm thành công.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadDataDetail();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Ghi nhận lịch hẹn không thành công! \r\n Vui lòng xem lại thông tin hẹn.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Chọn xét nghiệm cần hẹn!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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