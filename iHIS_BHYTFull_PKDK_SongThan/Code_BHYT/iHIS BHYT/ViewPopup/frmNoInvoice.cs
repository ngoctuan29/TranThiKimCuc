using System;
using System.IO;
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
using System.Globalization;
using DevExpress.XtraReports.UI;
using ClinicModel;
using ClinicBLL;
using ClinicLibrary;
using DevExpress.XtraTab;
using DevExpress.XtraGrid.Views.Grid;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmNoInvoice : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string employeeCode = string.Empty, noInvoice = string.Empty, banksAccountCode = string.Empty;
        private decimal patientReceiveID = 0;
        public bool reloaded = false;
        private string patientCode = string.Empty;
        private List<EmployeeInf> list = new List<EmployeeInf>();
        private DateTime dtWorking = new DateTime();
        public frmNoInvoice(string _employeeCode, decimal _patientReceiveID, string _noInvoice, string _banksAccountCode, string _patientCode, DateTime _dtWorking)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
            this.patientReceiveID = _patientReceiveID;
            this.noInvoice = _noInvoice;
            this.banksAccountCode = _banksAccountCode;
            this.patientCode = _patientCode;
            this.dtWorking = _dtWorking;
        }

        private void btAccept_Click(object sender, EventArgs e)
        {
            try
            {
                BanksAccountInvoiceInf obj = new BanksAccountInvoiceInf
                {
                    PatientCode = this.patientCode,
                    PatientReceiveID = this.patientReceiveID,
                    Invoice_MauSo = this.txtMauso.Text,
                    Invoice_KyHieu = this.txtKyhieu.Text,
                    Invoice_HoTenKH = this.txtHoten.Text.ToUpper(),
                    Invoice_DiaChi = this.txtDiachi.Text.ToUpper(),
                    Invoice_MaSoThue = this.txtMasothue.Text,
                    Invoice_DienThoai = this.txtDienthoai.Text,
                    Invoice_HTThanhToan = this.txtHinhthucTT.Text,
                    Invoice_VAT = Convert.ToInt32(this.cbxVAT.Text),
                    Invoice_EmployeeCode = this.employeeCode,
                    NoInvoice = this.txtNo.Text,
                    Invoice_DonVi = this.txtDonvi.Text
                };
                Int32 result = BanksAccountBLL.UpdBanksAccountInvoice(obj);
                if (result > 0)
                {
                    this.reloaded = true;
                    if (this.chkPrint.Checked)
                    {
                        Double dTotalRealTemp = 0;
                        DataTable dtBanksInfo = BanksAccountDetailBLL.TableBanksTotalForInvoice(this.banksAccountCode.TrimEnd(','), 0, this.patientReceiveID);
                        DataTable dtBanksInfoAdd = BanksAccountDetailBLL.TableBanksTotalForInvoiceTop(this.patientCode, 0, this.patientReceiveID);
                        DataTable dtBanksService = BanksAccountDetailBLL.Table_GetBankServiceDoneForInvoice(this.patientReceiveID, this.patientCode);
                        if (dtBanksService.Rows.Count > 0 && dtBanksService.Rows.Count <= 10)
                        {
                            DataSet dsTemp = new DataSet("Result");
                            if (dtBanksInfo.Rows.Count > 0)
                            {
                                dsTemp.Tables.Add(dtBanksInfoAdd);
                                foreach (DataRow r in dtBanksInfo.Rows)
                                {
                                    dTotalRealTemp += Convert.ToDouble(r["TotalReal"].ToString());
                                }
                            }
                            if (dtBanksService.Rows.Count > 0)
                                dsTemp.Tables.Add(dtBanksService);
                            dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptVP_Invoice.xml");
                            if (dsTemp.Tables[0].Rows.Count > 0)
                            {
                                Reports.rpt_VP_Invoice rpt = new Reports.rpt_VP_Invoice();
                                rpt.DataSource = dsTemp;
                                rpt.Parameters["prTotalReal"].Value = dTotalRealTemp;
                                rpt.Parameters["prNgayIn"].Value = this.dtWorking.ToString("dd/MM/yyyy").Substring(0, 2);
                                rpt.Parameters["prThangIn"].Value = this.dtWorking.ToString("dd/MM/yyyy").Substring(3, 2);
                                rpt.Parameters["prNamIn"].Value = this.dtWorking.ToString("dd/MM/yyyy").Substring(6, 4);
                                rpt.CreateDocument();
                                rpt.ShowRibbonPreviewDialog();
                            }
                            else
                            {
                                XtraMessageBox.Show(" Chi tiết hóa đơn chưa phát sinh! Chọn lại bệnh nhân và xem đợt điều trị.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else if (dtBanksService.Rows.Count <= 0)
                        {
                            XtraMessageBox.Show(" Chi tiết hóa đơn chưa phát sinh! Chọn lại bệnh nhân và xem đợt điều trị.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            this.PrintInvoiceGeneral();
                        }
                    }
                    else
                    {
                        this.Close();
                        this.Dispose();
                    }
                }
                else
                {
                    this.reloaded = false;
                    XtraMessageBox.Show(" Cập nhật số hóa đơn cho bệnh nhân không thành công!", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void frmNoInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadInvoiceInfo();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(" Error: " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtKyhieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtHoten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtDonvi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtDiachi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtMasothue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtDienthoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtHinhthucTT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void cbxVAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void LoadInvoiceInfo()
        {
            BanksAccountInvoiceInf obj = BanksAccountBLL.ObjBanksAccountInvoice(this.patientReceiveID, this.patientCode, this.noInvoice);
            if (obj != null && !string.IsNullOrEmpty(obj.PatientCode))
            {
                this.txtMauso.Text = obj.Invoice_MauSo;
                this.txtKyhieu.Text = obj.Invoice_KyHieu;
                this.txtNo.Text = obj.NoInvoice;
                this.txtHoten.Text = obj.Invoice_HoTenKH;
                this.txtDonvi.Text = obj.Invoice_DonVi;
                this.txtDiachi.Text = obj.Invoice_DiaChi;
                this.txtMasothue.Text = obj.Invoice_MaSoThue;
                this.txtDienthoai.Text = obj.Invoice_DienThoai;
                this.txtHinhthucTT.Text = obj.Invoice_HTThanhToan;
                this.cbxVAT.Text = obj.Invoice_VAT.ToString();
            }
            else
            {
                PatientsInf objPatients = PatientsBLL.ObjPatients(this.patientCode, this.patientReceiveID);
                if (objPatients != null && !string.IsNullOrEmpty(objPatients.PatientCode))
                {
                    string address = string.Empty;
                    this.txtHoten.Text = objPatients.PatientName.ToUpper();
                    if (!string.IsNullOrEmpty(objPatients.PatientAddress))
                        address = objPatients.PatientAddress + ",";
                    if (!string.IsNullOrEmpty(objPatients.WardName))
                        address += objPatients.WardName + ",";
                    if (!string.IsNullOrEmpty(objPatients.DistrictName))
                        address += objPatients.DistrictName + ",";
                    if (!string.IsNullOrEmpty(objPatients.ProvincialName))
                        address += objPatients.ProvincialName + ",";
                    this.txtDiachi.Text = address.TrimEnd(',').ToUpper();
                    this.txtDienthoai.Text = objPatients.PatientMobile;
                    this.txtHinhthucTT.Text = "TM";
                    this.cbxVAT.SelectedIndex = 0;
                }
                this.txtMauso.Focus();
                this.txtNo.Text = this.noInvoice;
            }
        }

        private void PrintInvoiceGeneral()
        {
            try
            {
                ////DataTable dtClinic = new DataTable("ClinicInfo");
                ////dtClinic = ClinicInformationBLL.DT_Information(1);
                Double dTotalRealTemp = 0;
                DataTable dtBanksInfo = new DataTable("BanksInfo");
                dtBanksInfo = BanksAccountDetailBLL.TableBanksTotalForInvoice(this.patientCode, 0, this.patientReceiveID);
                DataTable dtBanksInfoAdd = new DataTable("BanksInfo");
                dtBanksInfoAdd = BanksAccountDetailBLL.TableBanksTotalForInvoiceTop(this.patientCode, 0, this.patientReceiveID);
                DataTable dtBanksService = new DataTable();
                dtBanksService = BanksAccountDetailBLL.Table_GetBank_Service_DoneGeneral(this.patientReceiveID, this.patientCode, this.banksAccountCode);
                DataSet dsTemp = new DataSet("Result");
                ////dsTemp.Tables.Add(dtClinic);
                if (dtBanksInfo.Rows.Count > 0)
                {
                    dsTemp.Tables.Add(dtBanksInfoAdd);
                    foreach (DataRow r in dtBanksInfo.Rows)
                    {
                        dTotalRealTemp += Convert.ToDouble(r["TotalReal"].ToString());
                    }
                }
                if (dtBanksService.Rows.Count > 0)
                    dsTemp.Tables.Add(dtBanksService);
                dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptVP_InvoiceGeneral.xml");
                if (dsTemp.Tables[0].Rows.Count > 0)
                {
                    Reports.rpt_VP_InvoiceGeneral rpt = new Reports.rpt_VP_InvoiceGeneral();
                    rpt.DataSource = dsTemp;
                    rpt.Parameters["prTotalReal"].Value = dTotalRealTemp;
                    rpt.Parameters["prNgayIn"].Value = dtBanksInfo.Rows[0]["PostingDate"].ToString().Substring(0, 2);
                    rpt.Parameters["prThangIn"].Value = dtBanksInfo.Rows[0]["PostingDate"].ToString().Substring(3, 2);
                    rpt.Parameters["prNamIn"].Value = dtBanksInfo.Rows[0]["PostingDate"].ToString().Substring(6, 4);
                    rpt.CreateDocument();
                    rpt.ShowRibbonPreviewDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Chi tiết hóa đơn chưa phát sinh! Chọn lại bệnh nhân và xem đợt điều trị.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                XtraMessageBox.Show(" Chi tiết hóa đơn chưa phát sinh! Chọn lại bệnh nhân và xem đợt điều trị.", "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

    }
}