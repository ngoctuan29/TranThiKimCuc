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
using System.Reflection;

namespace Ps.Clinic.Entry
{
    public partial class frmPhieuThuTien : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private decimal dPatientReceiveID = 0;
        private string bankEntryCode = string.Empty;
        private string userid = string.Empty, sTheBHYT = string.Empty;
        private int iTraituyen = 0, iCapcuu = 0, iChuyenvien = 0;
        private Int32 iObjectCode = 0, iTile = 0, iPatientType = 0, iPaid = 0, iCancel = 0;
        private string sObjectName = string.Empty;
        private List<SuggestedViewInf> lstViewDV = new List<SuggestedViewInf>();
        private List<SuggestedViewMedicinesInf> lstViewThuoc = new List<SuggestedViewMedicinesInf>();
        private string shiftWork = string.Empty;
        private string sReceiptID = string.Empty;
        private bool bAdmin = false;
        private List<Model_BanksAccountFinish> lstBanksAccountFinish = new List<Model_BanksAccountFinish>();
        Excel.Application oxl;
        Excel._Workbook owb;
        Excel._Worksheet osheet;
        private DateTime dtimePostingDate = new DateTime();
        private string employeeCodeOld = string.Empty;
        private DateTime dtimeServer = new DateTime();
        private decimal amountBHYTtemp = 0;
        private DataTable dtotalBHYT = new DataTable();
        private DataTable tableDetailPayment = new DataTable();
        public frmPhieuThuTien(string _userid, string _shiftWork)
        {
            InitializeComponent();
            this.userid = _userid;
            this.shiftWork = _shiftWork;
            ref_ObjectCode.DataSource = ObjectBLL.DTObjectList(0);
            ref_ObjectCode.ValueMember = "ObjectCode";
            ref_ObjectCode.DisplayMember = "ObjectName";
        }

        private void frmPhieuThuTien_Load(object sender, EventArgs e)
        {
            //this.sLookUpNguoiGT.Properties.DataSource = IntroducerBLL.DTIntroducer("");
            //this.sLookUpNguoiGT.Properties.DisplayMember = "IntroName";
            //this.sLookUpNguoiGT.Properties.ValueMember = "IntroCode";

            this.lkupEmployee.Properties.DataSource = EmployeeBLL.ListEmployeeForPosition("4");
            this.lkupEmployee.Properties.DisplayMember = "EmployeeName";
            this.lkupEmployee.Properties.ValueMember = "EmployeeCode";

            this.repLKupPayment_Employee.DataSource = EmployeeBLL.ListEmployee(string.Empty);
            this.repLKupPayment_Employee.DisplayMember = "EmployeeName";
            this.repLKupPayment_Employee.ValueMember = "EmployeeCode";

            this.lkupEmployee.EditValue = this.userid;
            this.butInputHD.Enabled = false;
            this.bAdmin = EmployeeBLL.CheckUserAdmin(this.userid);
            if (this.bAdmin)
                this.tabPageThongKe.PageVisible = true;
            else this.tabPageThongKe.PageVisible = false;
            SystemParameterInf objSys = SystemParameterBLL.ObjParameter(503);
            if (objSys != null && objSys.RowID > 0)
            {
                if (objSys.Values == 1)
                    this.tstripOptions_CbxPrinter.SelectedIndex = Convert.ToInt32(objSys.Description);
                else
                    this.tstripOptions_CbxPrinter.SelectedIndex = 0;
            }
            this.EnableButton(true);
            this.ClearData();
            this.dtfrom.EditValue = dtTo.EditValue = this.dtSearchFrom.EditValue = this.dtSearchTo.EditValue = this.dtimePostingDate = this.dtimeServer = Utils.DateServer();
            this.butReload_Click(sender, e);
        }
        
        private void butReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                ///this.GetTotalServiceMedical();
                List<SuggestedViewInf> lstViewReal = this.lstViewDV.Where(p => p.Check == 1).ToList();
                List<SuggestedViewMedicinesInf> lstViewMedicinesReal = this.lstViewThuoc.Where(p => p.Check == 1).ToList();
                if ((lstViewReal.Count > 0 || lstViewMedicinesReal.Count > 0) && Convert.ToDecimal(this.txtAmount.EditValue) > 0)
                {
                    this.gridView_BankList.OptionsBehavior.ReadOnly = false;
                    this.gridView_BankList.OptionsBehavior.Editable = true;
                    BanksAccountInf modelAcc = new BanksAccountInf();
                    modelAcc.BanksAccountCode = Utils.DateTimeServer().ToString("yyyyMMddHHmmssfff");
                    modelAcc.ReferenceCode = this.dPatientReceiveID;
                    modelAcc.BHYTPay = Convert.ToDecimal(this.txtAmountBHYT_BHYTPay.EditValue);
                    modelAcc.PatientPay = Convert.ToDecimal(this.txtAmountThuphi.EditValue);
                    modelAcc.Exemptions = Convert.ToDecimal(this.txtAmountDiscount.EditValue);
                    modelAcc.RateExemptions = Convert.ToDecimal(this.txtDiscount.EditValue);
                    modelAcc.RateSurcharge = 0;
                    modelAcc.TotalSurcharge = Convert.ToDecimal(this.txtAmountPhuthu.EditValue);
                    modelAcc.TotalAmount = Convert.ToDecimal(this.txtAmount.EditValue);
                    modelAcc.TotalReal = Convert.ToDecimal(this.txtAmountReal.EditValue);
                    modelAcc.Description = string.Empty;
                    modelAcc.PatientCode = this.txtMabn.Text.Trim().ToUpper();
                    modelAcc.Cancel = 0;
                    modelAcc.PatientType = this.iPatientType;
                    modelAcc.EmployeeCode = this.userid;
                    modelAcc.ObjectCode = this.iObjectCode;
                    modelAcc.IntroCode = this.sLookUpNguoiGT.EditValue.ToString();
                    modelAcc.Serial = Convert.ToInt32(this.txtSerial.EditValue);
                    modelAcc.CashierCode = this.userid;//this.lkupEmployee.EditValue.ToString();
                    modelAcc.ShiftWork = this.shiftWork;
                    modelAcc.TotalBHYTPay = Convert.ToDecimal(this.txtAmountBHYT.EditValue);
                    modelAcc.TotalPatientPay = Convert.ToDecimal(this.txtTotalPayment.EditValue);//BN dong tam ung
                    string msgError = string.Empty;
                    bool isSuccess = BanksAccountBLL.InsBanksAccount(modelAcc,ref msgError);
                    if (isSuccess)
                    {
                        if (this.chkBV01.Checked)
                            PatientReceiveBLL.UpdPatientForStatus(this.dPatientReceiveID, this.txtMabn.Text.Trim(), 2);
                        int istt = 1;
                        foreach (var v in lstViewReal)
                        {
                            if (v.Check == 1)
                            {
                                BanksAccountDetailInf modelAccdetail = new BanksAccountDetailInf();
                                modelAccdetail.BanksAccountCode = modelAcc.BanksAccountCode;
                                modelAccdetail.EmployeeCode = this.userid;
                                modelAccdetail.ReceiptID = v.RowID;
                                modelAccdetail.STT = istt;
                                modelAccdetail.Type = this.iPatientType;
                                modelAccdetail.BHYTPay = v.BHYTPay;
                                modelAccdetail.PatientPay = v.PatientPay;
                                modelAccdetail.ServicePriceSalesOff = v.ServicePriceSalesOff;
                                modelAccdetail.Quantity = v.Quantity;
                                BanksAccountDetailBLL.Ins(modelAccdetail);
                                istt++;
                            }
                        }
                        istt = 1;
                        string sMedicalCode = string.Empty;
                        if (!this.chkService.Checked)
                        {
                            foreach (var items in lstViewMedicinesReal)
                            {
                                BanksAccountDetailInf modelMedical = new BanksAccountDetailInf();
                                modelMedical.BanksAccountCode = modelAcc.BanksAccountCode;
                                modelMedical.ServiceCode = items.ItemCode;
                                modelMedical.ServicePrice = items.UnitPrice;
                                modelMedical.DisparityPrice = items.DisparityPrice;
                                modelMedical.STT = istt;
                                modelMedical.ObjectCode = iObjectCode;
                                modelMedical.EmployeeCode = this.userid;
                                modelMedical.RowIDPrice = items.RowIDPrice;
                                modelMedical.ReceiptID = items.PatientReceiveID;
                                modelMedical.Type = this.iPatientType;
                                modelMedical.Quantity = items.Quantity;
                                sMedicalCode = items.MedicalRecordCode;
                                modelMedical.MedicalRecordCode = items.MedicalRecordCode;
                                modelMedical.RowIDMedicines = items.RowID;
                                modelMedical.RowIDDetail = items.RowIDDetail;
                                modelMedical.MedicinesType = items.MedicinesType;
                                modelMedical.BHYTPay = items.BHYTPay;
                                modelMedical.PatientPay = items.PatientPay;
                                modelMedical.ServicePriceSalesOff = items.ServicePriceSalesOff;
                                BanksAccountDetailBLL.InsForMedical(modelMedical);
                                istt++;
                            }
                        }
                        this.bankEntryCode = modelAcc.BanksAccountCode;
                        BanksAccountDetailBLL.Upd_Paid_MedicalRecord(sMedicalCode, 1, this.bankEntryCode);
                        if (this.tableDetailPayment != null && this.tableDetailPayment.Rows.Count > 0)
                        {
                            DateTime dtserverTemp = Utils.DateTimeServer();
                            foreach (DataRow row in this.tableDetailPayment.Rows)
                            {
                                Fee_Advance_PaymentBLL.UpdPaidFee_AdvancePayment(Convert.ToDecimal(row["RowID"]), this.dPatientReceiveID, this.bankEntryCode, 1, false, this.userid, dtserverTemp.ToString("dd/MM/yyyy HH:mm:ss"));
                            }
                        }
                        //RealMedicinesForPatientsBLL.UpdReal_Bank(bankEntryCode, sMedicalCode, dPatientReceiveID, txtMabn.Text.Trim().ToUpper());
                        //MedicinesRetailBLL.UpdPaidMedicines(1, txtMabn.Text.Trim().ToUpper(), dPatientReceiveID, bankEntryCode);

                        this.EnableButton(true);
                        this.gridView_BankList.OptionsBehavior.ReadOnly = true;
                        this.gridView_BankList.OptionsBehavior.Editable = false;
                        ///XtraMessageBox.Show("Đã ghi sổ thành công. \r\n", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.PrintBank();
                        if (!this.chkBV01.Checked)
                        {
                            this.butReload_Click(sender, e);
                            this.butNew_Click(sender, e);
                        }
                        else
                            this.butInBV01.Enabled = true;

                    }
                    else
                    {
                        XtraMessageBox.Show(" Ghi sổ không thành công \r\n" + msgError, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Không có khoản thu cần thu tiền! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void PrintBank()
        {
            try
            {
                DataTable dtClinic = ClinicInformationBLL.DT_Information(1);
                Double dTotalRealTemp = 0;
                DataTable dtBanksInfo = BanksAccountDetailBLL.TableBanksTotal("'" + bankEntryCode + "'", 0, this.dPatientReceiveID);
                DataTable dtBanksService = BanksAccountDetailBLL.DT_GetBank_Service_Done(this.dPatientReceiveID, this.txtMabn.Text.Trim().ToUpper(), this.bankEntryCode);
                if (dtBanksService.Rows.Count > 0)
                {
                    DataSet dsTemp = new DataSet("Result");
                    dsTemp.Tables.Add(dtClinic);
                    if (dtBanksInfo.Rows.Count > 0)
                    {
                        dsTemp.Tables.Add(dtBanksInfo);
                        dTotalRealTemp = Convert.ToDouble(dtBanksInfo.Rows[0]["TotalReal"].ToString());
                    }
                    dsTemp.Tables.Add(dtBanksService);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptVienPhi_ThuTien.xml");
                    if (dsTemp.Tables[0].Rows.Count > 0)
                    {
                        if (this.tstripOptions_CbxPrinter.SelectedIndex == 0)
                        {
                            if (this.tstripOptions_MenuInPhuThu.Checked)
                            {
                                Reports.rptVP_PhieuThuGiayNhiet_PThu rptShow = new Reports.rptVP_PhieuThuGiayNhiet_PThu();
                                rptShow.DataSource = dsTemp;
                                rptShow.Parameters["prTotalReal"].Value = dTotalRealTemp;
                                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "Phieuthu", "Phiếu thu");
                                rpt.ShowDialog();
                            }
                            else if (this.tstripOptions_MenuInChiTiet.Checked)
                            {
                                Reports.rptVP_PhieuThuGiayNhiet rptShow = new Reports.rptVP_PhieuThuGiayNhiet();
                                rptShow.DataSource = dsTemp;
                                rptShow.Parameters["prTotalReal"].Value = dTotalRealTemp;
                                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "Phieuthu", "Phiếu thu");
                                rpt.ShowDialog();
                            }
                            else if(this.tstripOptions_MenuInTH.Checked)
                            {
                                Reports.rptVP_PhieuThuGiayNhietGroup rptShow = new Reports.rptVP_PhieuThuGiayNhietGroup();
                                rptShow.DataSource = dsTemp;
                                rptShow.Parameters["prTotalReal"].Value = dTotalRealTemp;
                                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "Phieuthu", "Phiếu thu");
                                rpt.ShowDialog();
                            }
                        }
                        else if (this.tstripOptions_CbxPrinter.SelectedIndex == 1)
                        {
                            if (this.tstripOptions_MenuInChiTiet.Checked)
                            {
                                Reports.rptPhieuThuGiayA5 rptShow = new Reports.rptPhieuThuGiayA5();
                                rptShow.DataSource = dsTemp;
                                rptShow.Parameters["prTotalReal"].Value = dTotalRealTemp;
                                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "Phieuthu", "Phiếu thu");
                                rpt.ShowDialog();
                            }
                            else if (this.tstripOptions_MenuInTH.Checked)
                            {
                                Reports.rptVP_PhieuThuGiayA5Group rptShow = new Reports.rptVP_PhieuThuGiayA5Group();
                                rptShow.DataSource = dsTemp;
                                rptShow.Parameters["prTotalReal"].Value = dTotalRealTemp;
                                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "Phieuthu", "Phiếu thu");
                                rpt.ShowDialog();
                            }
                        }
                        else
                        {
                            if (this.tstripOptions_MenuInChiTiet.Checked)
                            {
                                Reports.rptPhieuThuGiayA4 rptShow = new Reports.rptPhieuThuGiayA4();
                                rptShow.Parameters["prTotalReal"].Value = dTotalRealTemp;
                                rptShow.DataSource = dsTemp;
                                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "PhieuThu", "Phiếu thu");
                                rpt.ShowDialog();
                            }
                            else if (this.tstripOptions_MenuInTH.Checked)
                            {
                                Reports.rptVP_PhieuThuGiayA4Group rptShow = new Reports.rptVP_PhieuThuGiayA4Group();
                                rptShow.Parameters["prTotalReal"].Value = dTotalRealTemp;
                                rptShow.DataSource = dsTemp;
                                Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "PhieuThu", "Phiếu thu");
                                rpt.ShowDialog();
                            }
                        }
                        BanksAccountBLL.UpdBanksAccountPrinter(bankEntryCode);
                    }
                    else
                    {
                        XtraMessageBox.Show(" Chi tiết hóa đơn chưa phát sinh! Chọn lại bệnh nhân và xem đợt điều trị.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Chi tiết hóa đơn chưa phát sinh! Chọn lại bệnh nhân và xem đợt điều trị.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                XtraMessageBox.Show(" Chi tiết hóa đơn chưa phát sinh! Chọn lại bệnh nhân và xem đợt điều trị.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void PrintBankTotalTreatment()
        {
            try
            {
                DataTable dtClinic = ClinicInformationBLL.DT_Information(1);
                Double dTotalRealTemp = 0, dExemptions = 0, dTotalAmount = 0, dPatientPay = 0, dTotalSurcharge = 0;
                DataTable dtBanksInfo = BanksAccountDetailBLL.TableBanksTotal_TotalGroupDate(0, this.txtMabn.Text, this.dtimePostingDate);
                DataTable dtBanksService = BanksAccountDetailBLL.Table_GetBankServiceDoneForInvoice(this.dPatientReceiveID, this.txtMabn.Text.Trim().ToUpper());
                if (dtBanksService.Rows.Count > 0)
                {
                    DataSet dsTemp = new DataSet("Result");
                    dsTemp.Tables.Add(dtClinic);
                    dsTemp.Tables.Add(dtBanksInfo);
                    dsTemp.Tables.Add(dtBanksService);
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptVienPhi_ThuTien.xml");
                    if (dsTemp.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow r in dtBanksInfo.Rows)
                        {
                            dTotalRealTemp += Convert.ToDouble(r["TotalReal"].ToString());
                            dExemptions += Convert.ToDouble(r["Exemptions"].ToString());
                            dTotalAmount += Convert.ToDouble(r["TotalAmount"].ToString());
                            dPatientPay += Convert.ToDouble(r["PatientPay"].ToString());
                            dTotalSurcharge += Convert.ToDouble(r["TotalSurcharge"].ToString());
                        }
                        if (this.tstripOptions_CbxPrinter.SelectedIndex == 1)
                        {
                            Reports.rptVP_PhieuThuGiayA5Total rptShow = new Reports.rptVP_PhieuThuGiayA5Total();
                            rptShow.DataSource = dsTemp;
                            rptShow.Parameters["prTotalReal"].Value = dTotalRealTemp;
                            rptShow.Parameters["prExemptions"].Value = dExemptions;
                            rptShow.Parameters["prTotalAmount"].Value = dTotalAmount;
                            rptShow.Parameters["prPatientPay"].Value = dPatientPay;
                            rptShow.Parameters["prTotalSurcharge"].Value = dTotalSurcharge;
                            Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "Phieuthu", "Phiếu thu tiền tổng hợp");
                            rpt.ShowDialog();

                        }
                        if (this.tstripOptions_CbxPrinter.SelectedIndex == 2)
                        {
                            Reports.rptVP_PhieuThuGiayA4Total rptShow = new Reports.rptVP_PhieuThuGiayA4Total();
                            rptShow.Parameters["prTotalReal"].Value = dTotalRealTemp;
                            rptShow.Parameters["prExemptions"].Value = dExemptions;
                            rptShow.Parameters["prTotalAmount"].Value = dTotalAmount;
                            rptShow.Parameters["prPatientPay"].Value = dPatientPay;
                            rptShow.Parameters["prTotalSurcharge"].Value = dTotalSurcharge;
                            rptShow.DataSource = dsTemp;
                            Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "PhieuThu", "Phiếu thu tiền tổng hợp");
                            rpt.ShowDialog();
                        }
                        else
                        {
                            Reports.rptVP_PhieuThuGiayA4Total rptShow = new Reports.rptVP_PhieuThuGiayA4Total();
                            rptShow.Parameters["prTotalReal"].Value = dTotalRealTemp;
                            rptShow.Parameters["prExemptions"].Value = dExemptions;
                            rptShow.Parameters["prTotalAmount"].Value = dTotalAmount;
                            rptShow.Parameters["prPatientPay"].Value = dPatientPay;
                            rptShow.Parameters["prTotalSurcharge"].Value = dTotalSurcharge;
                            rptShow.DataSource = dsTemp;
                            Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "PhieuThu", "Phiếu thu tiền tổng hợp");
                            rpt.ShowDialog();
                        }                   
                    }
                    else
                    {
                        XtraMessageBox.Show(" Chi tiết hóa đơn chưa phát sinh! Chọn lại bệnh nhân và xem đợt điều trị.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Chi tiết hóa đơn chưa phát sinh! Chọn lại bệnh nhân và xem đợt điều trị.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                XtraMessageBox.Show(" Chi tiết hóa đơn chưa phát sinh! Chọn lại bệnh nhân và xem đợt điều trị.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void EnableButton(bool b)
        {
            this.butNew.Enabled = b;
            this.butReceipt.Enabled = !b;
            this.butIgnore.Enabled = !b;
            this.butCancel.Enabled = false;
            this.butInBV01.Enabled = false;
            this.butInPT.Enabled = this.butPrintHD.Enabled = !b;
            this.txtMabn.Properties.ReadOnly = b;
            this.lkNgayVaoVien.Properties.ReadOnly = false;
            ////txtTylePhuthu.Properties.ReadOnly = b;
            this.sLookUpNguoiGT.Properties.ReadOnly = b;
            this.chkBV01.Properties.ReadOnly = false;
            this.txtAmount.Properties.ReadOnly = true;
            this.gridView_ListBanksAccount.OptionsBehavior.Editable = !b;
        }

        private void txtDiscount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (iPaid == 0)
                {
                    //decimal dRealTemp = Convert.ToDecimal(this.txtAmount.EditValue);// +Convert.ToDecimal(txtAmountPhuthu.EditValue);
                    decimal dRealTemp = Convert.ToDecimal(this.txtAmountBHYT_PatientPay.EditValue.ToString()) + Convert.ToDecimal(this.txtAmountThuphi.EditValue.ToString()) + Convert.ToDecimal(this.txtAmountPhuthu.EditValue.ToString()) - Convert.ToDecimal(this.txtTotalPayment.EditValue);
                    if (dRealTemp > 0)
                    {
                        decimal dMien_temp = (Convert.ToDecimal(this.txtDiscount.EditValue) * dRealTemp) / 100;
                        decimal dTong_Temp = dRealTemp - dMien_temp;
                        this.txtAmountDiscount.Text = dMien_temp.ToString("N0");
                        this.txtAmountReal.Text = dTong_Temp.ToString("N0");
                    }
                    else
                    {
                        XtraMessageBox.Show("Không phát sinh chi phí thu để miễn giảm!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch { }
        }

        private void txtAmountDiscount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (iPaid == 0)
                {
                    ///decimal amountRealTemp = Convert.ToDecimal(this.txtAmountReal.EditValue);
                    decimal amountRealTemp = Convert.ToDecimal(this.txtAmountBHYT_PatientPay.EditValue.ToString()) + Convert.ToDecimal(this.txtAmountThuphi.EditValue.ToString()) + Convert.ToDecimal(this.txtAmountPhuthu.EditValue.ToString()) - Convert.ToDecimal(this.txtTotalPayment.EditValue);
                    if (amountRealTemp > 0)
                    {
                        decimal dPhuthu_temp = 0;///Convert.ToDecimal(txtAmountPhuthu.EditValue);
                        decimal dMien_temp = Convert.ToDecimal(this.txtAmountDiscount.EditValue);
                        if (dMien_temp > amountRealTemp)
                        {
                            dMien_temp = amountRealTemp;
                            this.txtAmountDiscount.EditValue = dMien_temp;
                        }
                        decimal dTong_Temp = amountRealTemp + dPhuthu_temp - dMien_temp;
                        this.txtAmountReal.EditValue = dTong_Temp.ToString("N0");
                    }
                }
            }
            catch { }
        }

        private void txtMabn_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtMabn.Text.Trim()))
                this.GetNumberReceive(this.txtMabn.Text.Trim(), false);
        }

        public void ListService(ref decimal amountTotalService, bool isReset)
        {
            try
            {
                BHYTParametersInf bhytpara = BHYTParametersBLL.ObjParameters(1);
                if (this.lstViewDV.Count <= 0)
                    this.lstViewDV = SuggestedServiceReceiptBLL.ListView(this.txtMabn.Text.Trim().ToUpper(), this.dPatientReceiveID, this.iPaid, this.bankEntryCode,this.amountBHYTtemp, bhytpara.BHYTUnderPrice);
                decimal dBHYT = 0;
                foreach (var v in this.lstViewDV)
                {
                    if (v.Check.Equals(1))
                    {
                        if (this.iObjectCode == 1)
                        {
                            if (v.ObjectCode == 1)
                            {
                                if (isReset)
                                {
                                    dBHYT = (((v.Quantity * v.ServicePrice) * iTile) / 100);
                                    v.BHYTPay = dBHYT;
                                    v.PatientPay = (v.Quantity * v.ServicePrice) - dBHYT - v.ServicePriceSalesOff;
                                    v.Amount = (v.Quantity * v.ServicePrice);
                                    v.PatientPayReal = v.PatientPay + (v.DisparityPrice * v.Quantity);
                                    amountTotalService += (v.Quantity * v.ServicePrice);
                                }
                                else
                                {
                                    amountTotalService += (v.Quantity * v.ServicePrice);
                                }
                            }
                            else
                            {
                                v.PatientPay = (v.Quantity * v.ServicePrice) - v.ServicePriceSalesOff;
                                v.BHYTPay = 0;
                                v.PatientPayReal = v.PatientPay + (v.DisparityPrice * v.Quantity);
                                v.Amount = (v.Quantity * v.ServicePrice);
                            }
                        }
                        else
                        {
                            v.PatientPay = (v.Quantity * v.ServicePrice) - v.ServicePriceSalesOff;
                            v.BHYTPay = 0;
                            v.PatientPayReal = v.PatientPay + (v.DisparityPrice * v.Quantity);
                            v.Amount = (v.Quantity * v.ServicePrice);
                        }
                    }
                }
            }
            catch { }
        }

        private void ListMedical(ref decimal amountTotalMedical, bool isReset)
        {
            try
            {
                BHYTParametersInf bhytpara = BHYTParametersBLL.ObjParameters(1);
                if (this.lstViewThuoc.Count <= 0)
                    this.lstViewThuoc = SuggestedServiceReceiptBLL.ListMedicalView(this.txtMabn.Text.Trim().ToUpper(), this.dPatientReceiveID, this.iPaid, this.bankEntryCode, this.amountBHYTtemp, bhytpara.BHYTUnderPrice);
                List<SuggestedViewMedicinesInf> lstViewThuocReal = this.lstViewThuoc.Where(p => p.Check == 1).ToList();
                decimal dBHYTReal = 0, dPatientReal = 0;
                foreach (var v in lstViewThuocReal)
                {
                    if (iObjectCode == 1)
                    {
                        if (v.ObjectCode == 1)
                        {
                            if (isReset)
                            {
                                dBHYTReal = ((v.BHYTPay * iTile) / 100);
                                dPatientReal = (v.PatientPay + v.BHYTPay - dBHYTReal);
                                v.PatientPay = dPatientReal - v.ServicePriceSalesOff;
                                v.BHYTPay = dBHYTReal;
                                v.PatientPayReal = v.PatientPay + (v.DisparityPrice * v.Quantity);
                                amountTotalMedical += v.Quantity * v.UnitPrice;
                            }
                            else
                                amountTotalMedical += v.Quantity * v.UnitPrice;
                        }
                        else
                        {
                            dBHYTReal = v.Amount;
                            dPatientReal = v.Amount - v.ServicePriceSalesOff;
                            v.PatientPay = dPatientReal;
                            v.BHYTPay = 0;
                            v.PatientPayReal = dPatientReal + (v.DisparityPrice * v.Quantity);
                        }
                    }
                    else
                    {
                        dBHYTReal = v.Amount;
                        dPatientReal = v.Amount - v.ServicePriceSalesOff;
                        v.PatientPay = dPatientReal;
                        v.BHYTPay = 0;
                        v.PatientPayReal = dPatientReal + (v.DisparityPrice * v.Quantity);
                    }
                }
            }
            catch { }
        }
        
        public void SumAmountTotal(string rowIDSuggested)
        {
            decimal dCDHA = 0, dKCB = 0, dPTTT = 0, dXN = 0, dKhac = 0,dMau = 0, dVC = 0, dGiuong = 0;
            decimal dDVDisparity = 0, dDVTotal = 0, dDVBHYTToal = 0;
            decimal dThuocBHYTChiTra = 0, dThuocThuPhi = 0, dThuocBHYTTotal = 0, dThuocBHYT_BNChiTra = 0;
            decimal totalPayBHYT = 0, totalDVThuPhi = 0, totalDiscount = 0, totalBHYT_PatientPay = 0;
            try
            {
                // lay theo check tren grid
                ////txtDiscount.Value = txtAmountDiscount.Value = 0;
                //DataTable dtAmountService = new DataTable();
                //dtAmountService = BanksAccountBLL.TableSumAmountServiceDetail(this.dPatientReceiveID, this.txtMabn.Text.Trim().ToUpper(), rowIDSuggested, this.iPaid, this.bankEntryCode);
                List<SuggestedViewInf> lstViewReal = this.lstViewDV.Where(p => p.Check.Equals(1)).ToList();
                List<SuggestedViewMedicinesInf> lstMedicinesReal = this.lstViewThuoc.Where(p => p.Check.Equals(1)).ToList();
                //foreach (DataRow dr in dtAmountService.Rows)
                //{
                foreach (var v in lstViewReal)
                {
                    dDVDisparity += v.DisparityPrice * v.Quantity;
                    if (v.ServiceModuleCode == "CDHA")
                        dCDHA += v.ServicePrice * v.Quantity;
                    else if (v.ServiceModuleCode == "KCB")
                        dKCB += v.ServicePrice * v.Quantity;
                    else if (v.ServiceModuleCode == "PTTT")
                        dPTTT += v.ServicePrice * v.Quantity;
                    else if (v.ServiceModuleCode == "XN")
                        dXN += v.ServicePrice * v.Quantity;
                    else if (v.ServiceModuleCode == "VC")
                        dVC += v.ServicePrice * v.Quantity;
                    else if (v.ServiceModuleCode == "GIUONG")
                        dGiuong += v.ServicePrice * v.Quantity;
                    else if (v.ServiceModuleCode == "MAU")
                        dMau += v.ServicePrice * v.Quantity;
                    else
                        dKhac += v.ServicePrice * v.Quantity;
                }
                //}
                this.lbCDHA_TDCN.Text = dCDHA.ToString("N0");
                this.lbKCB.Text = dKCB.ToString("N0");
                this.lbPT_TT.Text = dPTTT.ToString("N0");
                this.lbXN.Text = dXN.ToString("N0");
                this.lbKhac.Text = dKhac.ToString("N0");
                this.lbVC.Text = dVC.ToString("N0");
                this.lbGiuong.Text = dGiuong.ToString("N0");
                this.lbMau.Text = dMau.ToString("N0");
                this.lbTHUOC_VTYT.Text = "0";
                foreach (var vservice in lstViewReal)
                {
                    if (vservice.ObjectCode == 1)
                    {
                        dDVBHYTToal += (vservice.Quantity * vservice.ServicePrice);
                        totalBHYT_PatientPay += vservice.Amount - vservice.BHYTPay;
                    }
                    else
                        totalDVThuPhi += (vservice.Quantity * vservice.ServicePrice);
                    totalPayBHYT += vservice.BHYTPay;
                    totalDiscount += vservice.ServicePriceSalesOff;
                }
                if (!this.chkService.Checked)
                {
                    if (lstMedicinesReal.Count > 0)
                    {
                        foreach (var items in lstMedicinesReal)
                        {
                            if (items.ObjectCode != 5 && items.ObjectCode.Equals(1))
                            {
                                dThuocBHYTChiTra += items.BHYTPay;
                                dThuocBHYT_BNChiTra += items.PatientPay;
                                dThuocBHYTTotal += items.BHYTPay + items.PatientPay;
                            }
                            else if (items.ObjectCode != 5 && !items.ObjectCode.Equals(1))
                                dThuocThuPhi += items.PatientPay;
                           // totalPayBHYT += items.BHYTPay;
                            dDVDisparity += items.DisparityPrice* items.Quantity;
                        }
                        this.lbTHUOC_VTYT.Text = (dThuocBHYTChiTra + dThuocThuPhi + dThuocBHYT_BNChiTra).ToString("N0");
                    }
                }
                dDVTotal = (dCDHA + dKCB + dPTTT + dXN + dKhac + dMau + dVC + dGiuong);
                this.txtAmount.Text = (dDVTotal + dThuocBHYTChiTra + dThuocThuPhi + dThuocBHYT_BNChiTra + dDVDisparity).ToString("N0");
                this.txtAmountBHYT.EditValue = dDVBHYTToal + dThuocBHYTTotal;
                this.txtAmountThuphi.Text = (totalDVThuPhi + dThuocThuPhi).ToString("N0");
                this.txtAmountBHYT_BHYTPay.EditValue = (totalPayBHYT + dThuocBHYTChiTra).ToString("N0");
                this.txtAmountBHYT_PatientPay.EditValue = totalBHYT_PatientPay + dThuocBHYT_BNChiTra;
                this.txtAmountReal.Text = (totalDVThuPhi + dThuocThuPhi + dDVDisparity).ToString("N0");
                this.txtAmountDiscount.Value = totalDiscount;
                this.txtAmountPhuthu.Text = dDVDisparity.ToString("N0");
                if (this.iObjectCode.Equals(1))
                {
                    BHYTParametersInf bhytpara = BHYTParametersBLL.ObjParameters(1);
                    if ((dDVBHYTToal + dThuocBHYTTotal) <= bhytpara.BHYTUnderPrice && iTraituyen == 0)
                    {
                        this.txtAmountReal.Text = dDVDisparity.ToString("N0");
                        this.txtAmountBHYT_PatientPay.Text = "0";
                    }
                    else if ((dDVBHYTToal + dThuocBHYTTotal) > bhytpara.BHYTUnderPrice && (dDVBHYTToal + dThuocBHYTTotal) <= bhytpara.BHYTOnPrice)
                        this.txtAmountReal.Text = (totalDVThuPhi + dThuocThuPhi + dDVDisparity).ToString("N0");
                    else if ((dDVBHYTToal + dThuocBHYTTotal) >= bhytpara.BHYTOnPrice)
                        this.txtAmountReal.Text = ((totalDVThuPhi + dThuocThuPhi + dDVDisparity) - bhytpara.BHYTOnPrice).ToString("N0");
                }
                this.txtAmountReal.EditValue = Convert.ToDecimal(this.txtAmountBHYT_PatientPay.EditValue.ToString()) + Convert.ToDecimal(this.txtAmountThuphi.EditValue.ToString())+ Convert.ToDecimal(this.txtAmountPhuthu.EditValue.ToString()) - Convert.ToDecimal(this.txtAmountDiscount.EditValue.ToString()) - Convert.ToDecimal(this.txtTotalPayment.EditValue);
                if (Convert.ToDecimal(this.txtAmountReal.EditValue) < 0)
                    this.lbAmountReal.Text = "Hoàn trả :";
                else
                    this.lbAmountReal.Text = "Thực thu :";
            }
            catch { }
        }
        private void GetNumberReceive(string patientCode, bool theEnd)
        {
            try
            {
                if (theEnd)
                {
                    this.lkNgayVaoVien.Properties.DataSource = PatientReceiveBLL.ListPatientView(patientCode, this.dPatientReceiveID);
                    this.lkNgayVaoVien.Properties.DisplayMember = "DateIn";
                    this.lkNgayVaoVien.Properties.ValueMember = "PatientReceiveID";
                    this.lkNgayVaoVien.EditValue = this.dPatientReceiveID;
                    this.lkNgayVaoVien.Focus();
                }
                else
                {
                    this.lkNgayVaoVien.Properties.DataSource = PatientReceiveBLL.ListPatientView(patientCode);
                    this.lkNgayVaoVien.Properties.DisplayMember = "DateIn";
                    this.lkNgayVaoVien.Properties.ValueMember = "PatientReceiveID";
                    this.lkNgayVaoVien.EditValue = this.dPatientReceiveID;
                    this.lkNgayVaoVien.Focus();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Erorr: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void lkNgayVaoVien_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.lstViewDV.Clear();
                this.lstViewThuoc.Clear();
                LookUpEdit LEdit = sender as LookUpEdit;
                this.dPatientReceiveID = Convert.ToDecimal(LEdit.EditValue.ToString());
                this.iObjectCode = Convert.ToInt32(LEdit.GetColumnValue("ObjectCode"));
                this.iPatientType = Convert.ToInt32(LEdit.GetColumnValue("PatientType"));
                this.sObjectName = LEdit.GetColumnValue("ObjectName").ToString();
                this.lbNgayvao.Text = LEdit.GetColumnValue("DateIn").ToString();
                if (LEdit.GetColumnValue("DateOut").ToString() != "01/01/0001 12:00:00 AM")
                    this.lbNgayra.Text = LEdit.GetColumnValue("DateOut").ToString();
                else
                    this.lbNgayra.Text = string.Empty;
                this.GetInfoPatient(Convert.ToDecimal(this.lkNgayVaoVien.EditValue));
                this.GetTotalServiceMedical();
                if (Convert.ToDecimal(this.txtAmountReal.EditValue.ToString()) > 0)
                    this.txtDiscount.Properties.ReadOnly = this.txtAmountDiscount.Properties.ReadOnly = false;
                else
                    this.txtDiscount.Properties.ReadOnly = this.txtAmountDiscount.Properties.ReadOnly = true;
                this.gridView_BankList.OptionsBehavior.ReadOnly = false;
                this.gridView_BankList.OptionsBehavior.Editable = true;
                this.gridView_List.OptionsBehavior.ReadOnly = false;
                this.gridView_List.OptionsBehavior.Editable = true;
            }
            catch { }
        }

        private void GetTotalServiceMedical()
        {
            decimal amountBHYTTotal = 0;
            decimal amountBHYTTotalObject = 0;
            
            this.dtotalBHYT = SuggestedServiceReceiptBLL.CheckTotalBHYT(dPatientReceiveID);
            foreach (DataRow dr in dtotalBHYT.Rows)
            {
                amountBHYTTotalObject += Convert.ToDecimal(dr["TotalBHYT"].ToString());
            }
            this.amountBHYTtemp = amountBHYTTotalObject;
            // lay lai tong tien amountBHYTTotal
            this.ListService(ref amountBHYTTotal, true);
            this.ListMedical(ref amountBHYTTotal, true);
            #region tinh lai BHYT cho dich vu va thuoc
            if (this.iObjectCode.Equals(1))
            {
                BHYTParametersInf bhytpara = BHYTParametersBLL.ObjParameters(1);
                if (amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iTraituyen == 0 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iCapcuu == 1 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iChuyenvien == 1)
                {
                    foreach (var v in this.lstViewDV)
                    {
                        if (v.ObjectCode == 1)
                        {
                            v.BHYTPay = v.Quantity * v.ServicePrice;
                            v.PatientPay = 0;
                            v.PatientPayReal = v.Quantity * v.DisparityPrice;
                        }
                    }
                }
            }
            this.gridControl_ListBanksAccount.DataSource = this.lstViewDV;
            this.gridView_ListBanksAccount.Columns["ServiceGroupName"].Group();
            this.gridView_ListBanksAccount.ExpandAllGroups();
            if (this.iObjectCode.Equals(1))
            {
                BHYTParametersInf bhytpara = BHYTParametersBLL.ObjParameters(1);
                if (amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iTraituyen == 0 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iCapcuu == 1 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iChuyenvien == 1)
                {
                    foreach (var items in this.lstViewThuoc)
                    {
                        if (items.ObjectCode == 1)
                        {
                            items.BHYTPay = items.Quantity * items.UnitPrice;
                            items.PatientPay = 0;
                        }
                    }
                }
            }
            this.gridControl_List.DataSource = this.lstViewThuoc;
            #endregion

            // Lấy toa bán lẻ vào thu viện phí.
            //this.ListMedicinesRetail();

            //Load bien lai tam ung cua bn
            this.LoadDataFeePaymentDetail();
            this.SumAmountTotal(string.Empty);
            //this.txtAmountBHYT_BHYTPay.Text = amountBHYTTotal.ToString("N0");
        }

        private void GetInfoPatient(decimal dReceive)
        {
            try
            {
                PatientsInf objPatient = PatientsBLL.ObjPatients(this.txtMabn.Text.Trim().ToUpper(), dReceive);
                if (objPatient != null && !string.IsNullOrEmpty(objPatient.PatientCode))
                {
                    this.lbHoten01.Text = objPatient.PatientName;
                    this.lbTuoi01.Text = objPatient.PatientAge.ToString();
                    if (objPatient.PatientGender == 0)
                        lbGioitinh01.Text = "Nữ";
                    else
                        lbGioitinh01.Text = "Nam";
                    this.lbNamsinh01.Text = objPatient.PatientBirthday.ToString("dd/MM/yyyy");
                    this.lbDiachi01.Text = objPatient.PatientAddress.TrimEnd(',');
                    if (!string.IsNullOrEmpty(objPatient.WardName))
                        this.lbDiachi01.Text += ", " + objPatient.WardName;
                    if (!string.IsNullOrEmpty(objPatient.DistrictName))
                        this.lbDiachi01.Text += ", " + objPatient.DistrictName;
                    if (!string.IsNullOrEmpty(objPatient.ProvincialName))
                        this.lbDiachi01.Text += ", " + objPatient.ProvincialName;
                    if (objPatient != null && objPatient.PatientCode != string.Empty && objPatient.PatientImage != null)
                    {
                        Byte[] imageadata = new Byte[0];
                        imageadata = (Byte[])(objPatient.PatientImage.ToArray());
                        MemoryStream memo = new MemoryStream(imageadata);
                        Bitmap b = new Bitmap(Image.FromStream(memo));
                        picPatient.Image = (Bitmap)b;
                    }
                    else
                    {
                        Bitmap b1 = new Bitmap("NoImgPatient.jpeg");
                        this.picPatient.Image = (Bitmap)b1;
                    }
                }
                if (iObjectCode == 1)
                {
                    List<BHYTInf> lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(dPatientReceiveID);
                    if (lstBHYT != null && lstBHYT.Count > 0)
                    {
                        sTheBHYT = lstBHYT[0].Serial;
                        this.lbSothe.Text = lstBHYT[0].Serial;
                        this.lbTungay.Text = lstBHYT[0].StartDate.ToString("dd/MM/yyyy");
                        this.iTraituyen = lstBHYT[0].TraiTuyen;
                        this.iCapcuu = lstBHYT[0].Capcuu;
                        this.iChuyenvien = lstBHYT[0].ReferralPaper;
                        this.chkTraiTuyen.Checked = lstBHYT[0].TraiTuyen == 1 ? true : false;
                        this.chkGiayChuyenVien.Checked = lstBHYT[0].ReferralPaper == 1 ? true : false;
                        this.chkCapCuu.Checked = lstBHYT[0].Capcuu == 1 ? true : false;
                        this.lbNoiDKKCB.Text = lstBHYT[0].KCBBDCodeFull.ToString();
                        this.lbDenngay.Text = lstBHYT[0].EndDate.ToString("dd/MM/yyyy");
                        int rateBHYT = 0;
                        this.GetCardInfo(lstBHYT[0].Serial, ref rateBHYT);
                    }
                }
                else
                {
                    iTraituyen = 0;
                    iCapcuu = 0;
                    iChuyenvien = 0;
                    lbSothe.Text = string.Empty;
                    lbTungay.Text = string.Empty;
                    lbNoiDKKCB.Text = string.Empty;
                    lbDenngay.Text = string.Empty;
                    lbTileBHYT.Text = sObjectName;
                }
            }
            catch { }
        }

        private void GetInfoOutHospital(string sPatientcode)
        {
            try
            {
                List<PatientReceive_ViewInf> lst = PatientReceiveBLL.ListPatientView(sPatientcode, dPatientReceiveID);
                dPatientReceiveID = lst[0].PatientReceiveID;
                iObjectCode = lst[0].ObjectCode;
                iPatientType = lst[0].PatientType;
                sObjectName = lst[0].ObjectName;

                lbNgayvao.Text = lst[0].DateIn.ToString("dd/MM/yyyy HH:mm:ss");
                if (lst[0].DateOut.ToString() != "01/01/0001 12:00:00 AM")
                    lbNgayra.Text = lst[0].DateOut.ToString("dd/MM/yyyy HH:mm:ss");
                else
                    lbNgayra.Text = "";
            }
            catch { }
        }

        private void GetCardInfo(string cardBHYT, ref int rateBHYT)
        {
            try
            {
                string sMaBHYT = cardBHYT.Substring(0, 3);
                RateBHYTInf model = RateBHYTBLL.objectRateBHYT(sMaBHYT);
                if (model != null || model.RateCard != string.Empty)
                {
                    if (this.chkTraiTuyen.Checked)
                    {
                        if (this.chkGiayChuyenVien.Checked || this.chkCapCuu.Checked)
                        {
                            this.iTile = model.RateTrue;
                            this.lbTileBHYT.Text = "BHYT " + model.RateTrue + "% ";
                        }
                        else
                        {
                            this.iTile = model.RateFalse;
                            this.lbTileBHYT.Text = "BHYT " + model.RateFalse + "% ";
                        }
                    }
                    else
                    {
                        this.iTile = model.RateTrue;
                        this.lbTileBHYT.Text = "BHYT " + model.RateTrue + "% ";
                    }
                }
            }
            catch { }
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearData();
                this.EnableButton(false);
                this.gridView_BankList.OptionsBehavior.ReadOnly = false;
                this.gridView_BankList.OptionsBehavior.Editable = true;
                this.chkBV01.Checked = false;
                this.txtMabn.Focus();
                this.tstripOptions_MenuInChiTiet.Checked = true;
                this.tstripOptions_MenuInPhuThu.Checked = false;
            }
            catch (Exception ex){
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void ClearData()
        {
            dPatientReceiveID = 0;
            iTraituyen = iObjectCode = iTile = iPatientType = iPaid = iCancel = iChuyenvien = iCapcuu = 0;
            bankEntryCode = string.Empty;
            sObjectName = string.Empty;
            sTheBHYT = string.Empty;
            txtMabn.Text = lbHoten01.Text = lbNgayvao.Text = lbNgayra.Text = lbNamsinh01.Text = lbTuoi01.Text = lbGioitinh01.Text = lbDiachi01.Text = lbSothe.Text = string.Empty;
            this.lbTungay.Text = this.lbDenngay.Text = this.lbNoiDKKCB.Text = string.Empty;
            this.chkTraiTuyen.Checked = this.chkGiayChuyenVien.Checked = this.chkCapCuu.Checked = false;
            this.lbTileBHYT.Text = string.Empty;
            this.lbKCB.Text = this.lbCDHA_TDCN.Text = this.lbXN.Text = this.lbPT_TT.Text = this.lbTHUOC_VTYT.Text = this.lbKhac.Text = this.lbGiuong.Text = this.lbMau.Text = this.lbVC.Text = "0";
            this.txtDiscount.Value = 0;
            this.txtAmountDiscount.Value = 0;
            ////this.this.txtTylePhuthu.Value = 0;
            ///dTilePhuThu = dTotalPhuThu = dTileGiam = dTotalGiam = 0;
            this.txtSerial.EditValue = this.txtAmount.Text = this.txtAmountThuphi.Text = this.txtAmountBHYT_PatientPay.Text = this.txtAmountReal.Text = this.txtAmountPhuthu.Text = this.txtTotalPayment.Text = this.txtAmountBHYT_BHYTPay.Text = "0";
            this.lstViewDV.Clear();
            this.lstViewThuoc.Clear();
            this.lkNgayVaoVien.Properties.DataSource = null;
            this.gridControl_BankList.DataSource = null;
            this.gridControl_ListBanksAccount.DataSource = null;
            this.gridControl_List.DataSource = null;
            this.gridControl_FeePayment.DataSource = null;
            this.sLookUpNguoiGT.EditValue = -1;
            this.lkNgayVaoVien.EditValue = -1;
            Bitmap b = new Bitmap("NoImgPatient.jpeg");
            this.picPatient.Image = (Bitmap)b;
            this.chkService.Checked = false;
            this.chkUnCheck.Checked = false;
            this.sReceiptID = string.Empty;
            this.chkDisparityPrice.Checked = false;
        }

        private void butIgnore_Click(object sender, EventArgs e)
        {
            this.EnableButton(true);
            this.gridView_BankList.OptionsBehavior.ReadOnly = true;
            this.gridView_BankList.OptionsBehavior.Editable = false;
            this.butNew.Focus();
        }

        private void butInBV01_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtMabn.Text.Trim().ToLower() != string.Empty)
                {
                    if (this.chkBV01.Checked)
                        PatientReceiveBLL.UpdPatientForStatus(this.dPatientReceiveID, this.txtMabn.Text.Trim().ToUpper(), 2);

                    #region print report from data
                    if (!this.iObjectCode.Equals(1))
                    {
                        DataTable dtClinic = ClinicInformationBLL.DT_Information(1);
                        DataTable dtBanksInfo = BanksAccountDetailBLL.DT_BanksTotalBV01(this.txtMabn.Text.Trim().ToUpper(), this.dPatientReceiveID, 0);
                        DataTable dtBV01 = BanksAccountDetailBLL.DT_GetBank_Service_BV01(dPatientReceiveID, txtMabn.Text.Trim().ToUpper(), 0);
                        decimal bhytPayTotal = 0, patientReal = 0;
                        decimal patientPayTotal = 0, disparityPrice = 0;
                        foreach (DataRow dr in dtBV01.Rows)
                        {
                            bhytPayTotal = Convert.ToDecimal(dr["BHYTPayTotal"].ToString());
                            patientPayTotal = Convert.ToDecimal(dr["TotalAmount"].ToString());
                            patientReal = Convert.ToDecimal(dr["PatientPayTotal"].ToString());
                            decimal bhytPay = 0, servicePrice = 0, patientPay = 0, quantity = 0;
                            Int32 rate = 0;
                            if (Convert.ToInt32(dr["ObjectCode"].ToString()) == 1)
                            {
                                if (dr["ServiceModuleCode"].Equals("THUOC"))
                                {
                                    if (Convert.ToInt32(dr["ListBHYT"].ToString()) == 1)
                                    {
                                        rate = Convert.ToInt32(dr["RateBHYT"].ToString());
                                        servicePrice = Convert.ToDecimal(dr["ServicePrice"].ToString());
                                        quantity = Convert.ToDecimal(dr["Quantity"].ToString());
                                        bhytPay = ((((servicePrice * quantity) * rate) / 100) * iTile / 100);
                                        patientPay = (servicePrice * quantity) - bhytPay;
                                        dr["PatientPay"] = patientPay;
                                        dr["BHYTPay"] = bhytPay;
                                    }
                                    else
                                    {
                                        rate = Convert.ToInt32(dr["RateBHYT"].ToString());
                                        servicePrice = Convert.ToDecimal(dr["ServicePrice"].ToString());
                                        quantity = Convert.ToDecimal(dr["Quantity"].ToString());
                                        bhytPay = 0;
                                        patientPay = (servicePrice * quantity) - bhytPay;
                                        dr["PatientPay"] = patientPay;
                                        dr["BHYTPay"] = bhytPay;
                                    }
                                }
                                else
                                {
                                    rate = Convert.ToInt32(dr["RateBHYT"].ToString());
                                    servicePrice = Convert.ToDecimal(dr["ServicePrice"].ToString());
                                    quantity = Convert.ToDecimal(dr["Quantity"].ToString());
                                    bhytPay = ((servicePrice * quantity) * iTile / 100);
                                    patientPay = servicePrice - bhytPay;
                                    dr["PatientPay"] = patientPay;
                                    dr["BHYTPay"] = bhytPay;
                                }
                                disparityPrice += Convert.ToDecimal(dr["DisparityPrice"].ToString());
                            }
                            else
                            {
                                rate = Convert.ToInt32(dr["RateBHYT"].ToString());
                                servicePrice = Convert.ToDecimal(dr["ServicePrice"].ToString());
                                bhytPay = 0;
                                patientPay = servicePrice - bhytPay;
                                dr["PatientPay"] = patientPay;
                                dr["BHYTPay"] = bhytPay;
                            }
                        }
                        DataSet dsTemp = new DataSet("Result");
                        dsTemp.Tables.Add(dtClinic);
                        dsTemp.Tables.Add(dtBanksInfo);
                        dsTemp.Tables.Add(dtBV01);
                        dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptMauBV01.xml");
                        Reports.rptMauBV01 rptShow = new Reports.rptMauBV01();
                        rptShow.DataSource = dsTemp;
                        rptShow.Parameters["prBHYTPayTotal"].Value = bhytPayTotal;
                        rptShow.Parameters["prPatientPayTotal"].Value = patientPayTotal;
                        rptShow.Parameters["prPatientReal"].Value = patientReal;
                        rptShow.Parameters["prDisparityPrice"].Value = disparityPrice;
                        Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "BV01", "Mẫu BV01");
                        rpt.ShowDialog();
                    }
                    #endregion

                    #region print form BHYT confirm
                    else
                    {
                        DateTime dateInto = this.dtimePostingDate;
                        List<PatientReceiveInf> listReceive = PatientReceiveBLL.ListPatientReceive(this.dPatientReceiveID);
                        if (listReceive.Count > 0 && listReceive[0].PatientReceiveID > 0)
                            dateInto = listReceive[0].CreateDate;
                        frmInforPatientReportBV01 frm = new frmInforPatientReportBV01(this.userid, this.shiftWork, this.txtMabn.Text.Trim(), this.dPatientReceiveID, dateInto);
                        frm.ShowDialog();
                    }
                    #endregion
                }
                else
                {
                    XtraMessageBox.Show(" Vui lòng nhập mã bệnh nhân cần in BV01.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void butSearch_Click(object sender, EventArgs e)
        {
            this.lstBanksAccountFinish = BanksAccountBLL.ListWaitingFinsh(this.txtSearchCode.Text.TrimEnd(), txtSearchName.Text.TrimEnd(), txtSearchAge.Text.TrimEnd(), dtSearchFrom.Text, dtSearchTo.Text);
            this.gridControl_BankList.DataSource = this.lstBanksAccountFinish;
        }

        private void gridView_BankList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_BankList.RowCount > 0)
                {
                    this.lstViewDV.Clear();
                    this.lstViewThuoc.Clear();
                    this.gridControl_ListBanksAccount.DataSource = null;
                    this.gridControl_List.DataSource = null;
                    this.gridControl_FeePayment.DataSource = null;

                    this.xtraTabControl1.SelectedTabPageIndex = 0;
                    this.iPaid = 1;
                    this.txtMabn.Text = this.gridView_BankList.GetRowCellValue(this.gridView_BankList.FocusedRowHandle, "PatientCode").ToString();
                    this.bankEntryCode = this.gridView_BankList.GetRowCellValue(this.gridView_BankList.FocusedRowHandle, "BanksAccountCode").ToString();
                    this.dPatientReceiveID = Convert.ToDecimal(this.gridView_BankList.GetRowCellValue(gridView_BankList.FocusedRowHandle, "ReferenceCode").ToString());
                    this.iCancel = Convert.ToInt32(this.gridView_BankList.GetRowCellValue(this.gridView_BankList.FocusedRowHandle, "Cancel").ToString());
                    //this.dTilePhuThu = Convert.ToDecimal(gridView_BankList.GetRowCellValue(gridView_BankList.FocusedRowHandle, "RateSurcharge").ToString());
                    //this.dTotalPhuThu = Convert.ToDecimal(gridView_BankList.GetRowCellValue(gridView_BankList.FocusedRowHandle, "TotalSurcharge").ToString());

                    //this.dTileGiam = Convert.ToDecimal(gridView_BankList.GetRowCellValue(gridView_BankList.FocusedRowHandle, "RateExemptions").ToString());
                    decimal amountExemptionsDone = Convert.ToDecimal(this.gridView_BankList.GetRowCellValue(this.gridView_BankList.FocusedRowHandle, "Exemptions").ToString());
                    //sLookUpNguoiGT.EditValue = gridView_BankList.GetRowCellValue(gridView_BankList.FocusedRowHandle, "IntroCode").ToString();
                    this.lkupEmployee.EditValue = gridView_BankList.GetRowCellValue(gridView_BankList.FocusedRowHandle, col_CashierCode).ToString();
                    this.txtSerial.EditValue = gridView_BankList.GetRowCellValue(gridView_BankList.FocusedRowHandle, "Serial").ToString();
                    Int32 statusReceive = Convert.ToInt32(this.gridView_BankList.GetRowCellValue(this.gridView_BankList.FocusedRowHandle, "StatusReceive"));
                    this.dtimePostingDate = Convert.ToDateTime(this.gridView_BankList.GetRowCellValue(this.gridView_BankList.FocusedRowHandle, "PostingDate"));
                    this.employeeCodeOld = this.gridView_BankList.GetRowCellValue(this.gridView_BankList.FocusedRowHandle, "EmployeeCode").ToString();
                    this.txtAmountDiscount.EditValue = amountExemptionsDone.ToString("N0");
                    this.GetNumberReceive(this.txtMabn.Text.Trim(), true);
                    this.GetInfoPatient(dPatientReceiveID);
                    this.GetInfoOutHospital(this.txtMabn.Text.Trim());
                    // BHYT
                    decimal amountTotalBHYT = 0;
                    this.ListService(ref amountTotalBHYT, true);
                    this.ListMedical(ref amountTotalBHYT,true);
                    this.GetTotalServiceMedical();
                    //this.ListMedicinesRetail(); /// Lay toa thuoc ban le
                    this.SumAmountTotal("0");

                    this.EnableButton(true);
                    this.butCancel.Enabled = this.butInPT.Enabled = this.butPrintHD.Enabled = this.butInBV01.Enabled = true;
                    this.gridView_BankList.OptionsBehavior.ReadOnly = true;
                    this.gridView_BankList.OptionsBehavior.Editable = false;
                    this.gridView_List.OptionsBehavior.ReadOnly = true;
                    this.gridView_List.OptionsBehavior.Editable = false;
                    if (statusReceive == 2)
                        this.chkBV01.Checked = true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                this.butSearch_Click(sender, e);
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(bankEntryCode))
            {
                if (this.iCancel == 0)
                {
                    //if (XtraMessageBox.Show(" Bạn thật sự muốn hoàn trả phiếu thu này?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    //{
                        
                    //}
                    try
                    {
                        if (this.dtimePostingDate.Date != this.dtimeServer.Date && !this.bAdmin)
                        {
                            XtraMessageBox.Show("Khác ngày việc không được phép xóa! Chỉ quản trị hệ thông mới được phép xóa.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (this.bAdmin || this.userid == this.employeeCodeOld)
                        {
                            ViewPopup.frmLyDoHuyPhieuThu frmCancel = new ViewPopup.frmLyDoHuyPhieuThu();
                            frmCancel.ShowDialog();
                            if (string.IsNullOrEmpty(frmCancel.reason))
                                return;
                            else
                            {
                                if (BanksAccountBLL.DelBanksAccount(this.bankEntryCode, this.txtMabn.Text.TrimEnd(), this.dPatientReceiveID, this.shiftWork, this.userid, frmCancel.reason) >= 1)
                                {
                                    if (this.tableDetailPayment != null && this.tableDetailPayment.Rows.Count > 0)
                                    {
                                        DateTime dtserverTemp = Utils.DateTimeServer();
                                        foreach (DataRow row in this.tableDetailPayment.Rows)
                                        {
                                            Fee_Advance_PaymentBLL.UpdPaidFee_AdvancePayment(Convert.ToDecimal(row["RowID"]), this.dPatientReceiveID, bankEntryCode, 0, true, this.userid, dtserverTemp.ToString("dd/MM/yyyy HH:mm:ss"));
                                        }
                                    }
                                    XtraMessageBox.Show(" Hoàn trả phiếu thu thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.iCancel = 0;
                                    this.EnableButton(true);
                                    this.ClearData();
                                }
                                else
                                {
                                    XtraMessageBox.Show(" Việc hoàn trả thất bại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("User không có quyền hủy phiếu thu này! Vui lòng liên hệ quản trị hệ thống.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    catch { return; }
                }
                else
                {
                    XtraMessageBox.Show(" Phiếu đã được hủy!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                XtraMessageBox.Show(" Chưa phát sinh phiếu thu!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtMabn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
                SendKeys.Send("{Tab}{F4}");	
        }

        private void lkNgayVaoVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.butReceipt.Focus();
        }

        private void butInPT_Click(object sender, EventArgs e)
        {
            if (this.tstripOptions_MenuInTongDotDieuTri.Checked)
                this.PrintBankTotalTreatment();
            else
                this.PrintBank();
        }
        
        private void butReload_Click(object sender, EventArgs e)
        {
            DateTime from =Convert.ToDateTime(this.dtfrom.EditValue);
            from = from.Date.AddHours(00).AddMinutes(00).AddSeconds(00).AddMilliseconds(0);
            DateTime to = Convert.ToDateTime(this.dtTo.EditValue);
            to = to.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999);

            this.gridControl_WaitingList.DataSource = BanksAccountBLL.TableWaitingForDate(this.dtfrom.Text.Trim(), this.dtTo.Text.Trim());
        }

        private void gridView_WaitingList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.butNew_Click(sender, e);
                string patientCodeTemp = gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, "PatientCode").ToString();
                this.dPatientReceiveID = Convert.ToDecimal(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, "PatientReceiveID").ToString());
                this.txtMabn.Text = patientCodeTemp;
                if (!string.IsNullOrEmpty(patientCodeTemp))
                    this.txtMabn_Validated(sender, e);
            }
            catch { }
        }

        private void gridView_ListBanksAccount_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view.FocusedColumn.FieldName == "Check")
                {
                    this.sReceiptID = string.Empty;
                    if (this.gridView_ListBanksAccount.GetRowCellValue(e.RowHandle, "Check").ToString() == "1")
                    {
                        this.gridView_ListBanksAccount.SetRowCellValue(e.RowHandle, "Check", 0);
                    }
                    else
                    {
                        this.gridView_ListBanksAccount.SetRowCellValue(e.RowHandle, "Check", 1);
                    }
                    foreach (var v in this.lstViewDV)
                    {
                        if (v.Check == 1)
                            this.sReceiptID += v.RowID + ",";
                    }
                    if (!string.IsNullOrEmpty(this.sReceiptID))
                    {
                        decimal amountBHYTTotal = 0;
                        decimal amountBHYTTotalObject = 0;
                        this.dtotalBHYT = SuggestedServiceReceiptBLL.CheckTotalBHYT(dPatientReceiveID);
                        foreach (DataRow dr in dtotalBHYT.Rows)
                        {
                            amountBHYTTotalObject += Convert.ToDecimal(dr["TotalBHYT"].ToString());
                        }
                        this.amountBHYTtemp = amountBHYTTotalObject;
                        // lay lai tong tien amountBHYTTota
                        this.ListService(ref amountBHYTTotal, false);
                        this.ListMedical(ref amountBHYTTotal, false);
                        #region tinh lai BHYT cho dich vu va thuoc
                        if (this.iObjectCode.Equals(1))
                        {
                            BHYTParametersInf bhytpara = BHYTParametersBLL.ObjParameters(1);
                            if (amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iTraituyen == 0 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iCapcuu == 1 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iChuyenvien == 1)
                            {
                                foreach (var v in this.lstViewDV)
                                {
                                    if (v.ObjectCode == 1)
                                    {
                                        v.BHYTPay = v.Quantity * v.ServicePrice;
                                        v.PatientPay = 0;
                                    }
                                }
                            }
                        }
                        this.gridControl_ListBanksAccount.DataSource = this.lstViewDV;
                        this.gridView_ListBanksAccount.Columns["ServiceGroupName"].Group();
                        this.gridView_ListBanksAccount.ExpandAllGroups();
                        if (this.iObjectCode.Equals(1))
                        {
                            BHYTParametersInf bhytpara = BHYTParametersBLL.ObjParameters(1);
                            if (amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iTraituyen == 0 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iCapcuu == 1 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iChuyenvien == 1)
                            {
                                foreach (var items in this.lstViewThuoc)
                                {
                                    if (items.ObjectCode == 1)
                                    {
                                        items.BHYTPay = items.Quantity * items.UnitPrice;
                                        items.PatientPay = 0;
                                    }
                                }
                            }
                        }
                        this.gridControl_List.DataSource = this.lstViewThuoc;
                        #endregion
                        this.SumAmountTotal(this.sReceiptID.TrimEnd(','));
                    }
                    else
                        this.SumAmountTotal("-1");
                }
            }
            catch { }
        }

        private void butInputHD_Click(object sender, EventArgs e)
        {
            try
            {
                #region Invoice printer old
                //DataTable dtClinic = new DataTable("ClinicInfo");
                //dtClinic = ClinicInformationBLL.DT_Information(1);
                //Double dTotalRealTemp = 0;
                //DataTable dtBanksInfo = new DataTable("BanksInfo");
                //dtBanksInfo = BanksAccountDetailBLL.DT_BanksTotal(this.bankEntryCode, 0, this.dPatientReceiveID);
                //DataTable dtBanksService = new DataTable();
                //dtBanksService = BanksAccountDetailBLL.DT_GetBank_Service_Done(this.dPatientReceiveID, this.txtMabn.Text.Trim().ToUpper(), this.bankEntryCode);
                //if (dtBanksService.Rows.Count > 0 && dtBanksService.Rows.Count <= 10)
                //{
                //    DataSet dsTemp = new DataSet("Result");
                //    dsTemp.Tables.Add(dtClinic);
                //    if (dtBanksInfo.Rows.Count > 0)
                //    {
                //        dsTemp.Tables.Add(dtBanksInfo);
                //        dTotalRealTemp = Convert.ToDouble(dtBanksInfo.Rows[0]["TotalReal"].ToString());
                //    }
                //    if (dtBanksService.Rows.Count > 0)
                //        dsTemp.Tables.Add(dtBanksService);
                //    dsTemp.WriteXml(@"..\..\xml\rptVP_Invoice.xml");
                //    if (dsTemp.Tables[0].Rows.Count > 0)
                //    {
                //        Reports.rpt_VP_Invoice rpt = new Reports.rpt_VP_Invoice();
                //        rpt.DataSource = dsTemp;
                //        rpt.Parameters["prTotalReal"].Value = dTotalRealTemp;
                //        rpt.CreateDocument();
                //        rpt.ShowRibbonPreviewDialog();
                //    }
                //    else
                //    {
                //        XtraMessageBox.Show(" Chi tiết hóa đơn chưa phát sinh! Chọn lại bệnh nhân và xem đợt điều trị.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //}
                //else if (dtBanksService.Rows.Count <= 0)
                //{
                //    XtraMessageBox.Show(" Chi tiết hóa đơn chưa phát sinh! Chọn lại bệnh nhân và xem đợt điều trị.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //else
                //{
                //    this.PrintInvoiceGeneral();
                //}
                #endregion

                ///int countTemp = this.lstBanksAccountFinish.Where(p => p.Printer == 1).Count();
                bool checkExist = false;
                decimal patientReceiveIDTemp = 0;
                string noInvoiceTemp = string.Empty;
                string banksAccountCodeTemp = string.Empty, patientCodeTemp = string.Empty;
                List<Model_BanksAccountFinish> lstTemp = this.lstBanksAccountFinish.Where(p => p.Printer == 1).ToList();
                if (lstTemp.Count > 0)
                {
                    foreach (var v in lstTemp)
                    {
                        if (patientReceiveIDTemp == 0)
                        {
                            patientReceiveIDTemp = v.ReferenceCode;
                            noInvoiceTemp = v.NoInvoice;
                            patientCodeTemp = v.PatientCode;
                        }
                        if (patientReceiveIDTemp != v.ReferenceCode)
                        {
                            checkExist = true;
                            break;
                        }
                        banksAccountCodeTemp += "'" + v.BanksAccountCode + "',";
                    }
                    if (checkExist)
                    {
                        XtraMessageBox.Show(" Số hóa đơn chỉ xuất cho duy nhất một bệnh nhân \n\t Và trong một đợt điều trị!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        ViewPopup.frmNoInvoice frmInvoice = new ViewPopup.frmNoInvoice(this.userid, patientReceiveIDTemp, noInvoiceTemp, banksAccountCodeTemp, patientCodeTemp, this.dtimePostingDate);
                        frmInvoice.ShowDialog();
                        if (frmInvoice.reloaded)
                            this.butSearch_Click(sender, e);
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Chọn bệnh nhân cần in hóa đơn!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
                dtBanksInfo = BanksAccountDetailBLL.TableBanksTotalForInvoice("'" + this.bankEntryCode + "'", 0, this.dPatientReceiveID);
                DataTable dtBanksService = new DataTable();
                dtBanksService = BanksAccountDetailBLL.Table_GetBank_Service_DoneGeneral(this.dPatientReceiveID, this.txtMabn.Text.Trim(), "'" + this.bankEntryCode + "'");
                DataSet dsTemp = new DataSet("Result");
                ////dsTemp.Tables.Add(dtClinic);
                if (dtBanksInfo.Rows.Count > 0)
                {
                    dsTemp.Tables.Add(dtBanksInfo);
                    dTotalRealTemp = Convert.ToDouble(dtBanksInfo.Rows[0]["TotalReal"].ToString());
                }
                if (dtBanksService.Rows.Count > 0)
                    dsTemp.Tables.Add(dtBanksService);
                dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptVP_InvoiceGeneral.xml");
                if (dsTemp.Tables[0].Rows.Count > 0)
                {
                    Reports.rpt_VP_InvoiceGeneral rptShow = new Reports.rpt_VP_InvoiceGeneral();
                    rptShow.Parameters["prTotalReal"].Value = dTotalRealTemp;
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "HoaDon","VP-Hoá đơn");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Chi tiết hóa đơn chưa phát sinh! Chọn lại bệnh nhân và xem đợt điều trị.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                XtraMessageBox.Show(" Chi tiết hóa đơn chưa phát sinh! Chọn lại bệnh nhân và xem đợt điều trị.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_BankList_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.butInputHD.Enabled = true;
        }

        private void butPrintHD_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsResult = new DataSet("Result");
                decimal totalRealTemp = 0;
                string prNgayIn = string.Empty, prThangIn = string.Empty, prNamIn = string.Empty;
                DataTable dtBanksInfo = new DataTable("BanksInfo");
                dtBanksInfo = BanksAccountDetailBLL.TableBanksTotalForInvoice(this.dPatientReceiveID, this.iObjectCode);
                dsResult.Tables.Add(dtBanksInfo);
                if (dtBanksInfo != null && dtBanksInfo.Rows.Count > 0)
                {
                    for (int index = 0; index < dtBanksInfo.Rows.Count; index++)
                    {
                        totalRealTemp += Convert.ToDecimal(dtBanksInfo.Rows[index][1].ToString());
                    }
                    dsResult.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptVP_InvoiceA5.xml");
                    prNgayIn = dtBanksInfo.Rows[0]["PostingDate"].ToString().Substring(0, 2);
                    prThangIn = dtBanksInfo.Rows[0]["PostingDate"].ToString().Substring(3, 2);
                    prNamIn = dtBanksInfo.Rows[0]["PostingDate"].ToString().Substring(6, 4);

                    Reports.rptVP_InvoiceA5 rptShow = new Reports.rptVP_InvoiceA5();
                    rptShow.Parameters["prTotalReal"].Value = totalRealTemp;
                    rptShow.Parameters["prNgayIn"].Value = prNgayIn;
                    rptShow.Parameters["prThangIn"].Value = prThangIn;
                    rptShow.Parameters["prNamIn"].Value = prNamIn;
                    rptShow.DataSource = dsResult;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "BKHoaDon", "VP-Bảng kê hoá đơn");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Chi tiết hóa đơn chưa phát sinh! Vui lòng xem lại thông tin đợt điều trị của bệnh nhân.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void chkService_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.sReceiptID))
            {
                this.SumAmountTotal(this.sReceiptID.TrimEnd(','));
            }
            else
                this.SumAmountTotal(string.Empty);
        }

        private void chkUnCheck_CheckedChanged(object sender, EventArgs e)
        {
            this.gridControl_ListBanksAccount.DataSource = null;
            this.gridControl_List.DataSource = null;
            this.sReceiptID = string.Empty;
            this.chkDisparityPrice.Checked = false;
            if (this.chkUnCheck.Checked)
            {
                this.chkUnCheck.Text = "Chọn tất cả";
                foreach (var v in this.lstViewDV)
                {
                    v.Check = 0;
                    ///this.sReceiptID += v.RowID + ",";
                }
                foreach (var v in this.lstViewThuoc)
                {
                    v.Check = 0;
                    //this.sReceiptID += v.RowID + ",";
                }
                this.sReceiptID = "-1000";
                this.chkUnCheck.Checked = true;
            }
            else
            {
                this.chkUnCheck.Text = "Bỏ chọn";
                foreach (var v in this.lstViewDV)
                {
                    v.Check = 1;
                    this.sReceiptID += v.RowID + ",";
                }
                foreach (var v in this.lstViewThuoc)
                {
                    v.Check = 1;
                    this.sReceiptID += v.RowID + ",";
                }
                this.chkUnCheck.Checked = false;
            }
            this.gridControl_ListBanksAccount.DataSource = this.lstViewDV;
            this.gridView_ListBanksAccount.Columns["ServiceGroupName"].Group();
            this.gridView_ListBanksAccount.ExpandAllGroups();

            this.gridControl_List.DataSource = this.lstViewThuoc;

            decimal amountBHYTTotal = 0;
            decimal amountBHYTTotalObject = 0;

            this.dtotalBHYT = SuggestedServiceReceiptBLL.CheckTotalBHYT(dPatientReceiveID);
            foreach (DataRow dr in dtotalBHYT.Rows)
            {
                amountBHYTTotalObject += Convert.ToDecimal(dr["TotalBHYT"].ToString());
            }
            this.amountBHYTtemp = amountBHYTTotalObject;
            this.ListService(ref amountBHYTTotal, false);
            this.ListMedical(ref amountBHYTTotal, false);
            #region tinh lai BHYT cho dich vu va thuoc
            if (this.iObjectCode.Equals(1))
            {
                BHYTParametersInf bhytpara = BHYTParametersBLL.ObjParameters(1);
                if (amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iTraituyen == 0 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iCapcuu == 1 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iChuyenvien == 1)
                {
                    foreach (var v in this.lstViewDV)
                    {
                        if (v.ObjectCode == 1)
                        {
                            v.BHYTPay = v.Quantity * v.ServicePrice;
                            v.PatientPay = 0;
                        }
                    }
                }
            }
            if (this.iObjectCode.Equals(1))
            {
                BHYTParametersInf bhytpara = BHYTParametersBLL.ObjParameters(1);
                if (amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iTraituyen == 0 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iCapcuu == 1 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iChuyenvien == 1)
                {
                    foreach (var items in this.lstViewThuoc)
                    {
                        if (items.ObjectCode == 1)
                        {
                            items.BHYTPay = items.Quantity * items.UnitPrice;
                            items.PatientPay = 0;
                        }
                    }
                }
            }
            #endregion
            this.SumAmountTotal(this.sReceiptID.TrimEnd(','));
        }

        private void repServicePriceSalesOff_ValueChanged(object sender, EventArgs e)
        {
            SpinEdit spin = sender as SpinEdit;
            if (spin.EditValue == null)
            {
                spin.EditValue = 0;
            }
            decimal amountTemp = Convert.ToDecimal(this.gridView_ListBanksAccount.GetRowCellValue(this.gridView_ListBanksAccount.FocusedRowHandle, "Amount").ToString());
            decimal rowidTemp = Convert.ToDecimal(this.gridView_ListBanksAccount.GetRowCellValue(this.gridView_ListBanksAccount.FocusedRowHandle, "RowID").ToString());
            decimal changeValued = Convert.ToDecimal(spin.EditValue);
            decimal discountMedical = this.GetAmountDiscountMedical();
            if (changeValued > amountTemp)
            {
                this.gridView_ListBanksAccount.SetFocusedRowCellValue(this.col_PatientPayReal, 0);
                spin.EditValue = changeValued = amountTemp;
            }
            else
            {
                this.gridView_ListBanksAccount.SetFocusedRowCellValue(this.col_PatientPayReal, amountTemp - changeValued);
            }
            List<SuggestedViewInf> lstViewReal = this.lstViewDV.Where(p => p.Check.Equals(1)).ToList();
            decimal totalDiscount = 0;
            foreach (var sugg in lstViewReal)
            {
                if (sugg.RowID != rowidTemp)
                {
                    totalDiscount += sugg.ServicePriceSalesOff;
                }
            }
            totalDiscount += changeValued;
            this.txtAmountDiscount.EditValue = totalDiscount + discountMedical;
            this.txtAmountReal.EditValue = Convert.ToDecimal(this.txtAmountBHYT_PatientPay.EditValue.ToString()) + Convert.ToDecimal(this.txtAmountThuphi.EditValue.ToString()) + Convert.ToDecimal(this.txtAmountPhuthu.EditValue.ToString()) - Convert.ToDecimal(this.txtAmountDiscount.EditValue.ToString()) - Convert.ToDecimal(this.txtTotalPayment.EditValue);
        }

        private void tstripOptions_MenuInChiTiet_Click(object sender, EventArgs e)
        {
            if (this.tstripOptions_MenuInChiTiet.Checked)
            {
                this.tstripOptions_MenuInTH.Checked = false;
                this.tstripOptions_MenuInTongDotDieuTri.Checked = false;
            }
        }

        private void tstripOptions_MenuInTH_Click(object sender, EventArgs e)
        {
            if (this.tstripOptions_MenuInTH.Checked)
            {
                this.tstripOptions_MenuInChiTiet.Checked = false;
                this.tstripOptions_MenuInTongDotDieuTri.Checked = false;
            }
        }

        private void tstripOptions_MenuInTongDotDieuTri_Click(object sender, EventArgs e)
        {
            if (this.tstripOptions_MenuInTongDotDieuTri.Checked)
            {
                this.tstripOptions_MenuInChiTiet.Checked = false;
                this.tstripOptions_MenuInTH.Checked = false;
            }
        }

        private void chkDisparityPrice_CheckedChanged(object sender, EventArgs e)
        {
            this.gridControl_ListBanksAccount.DataSource = null;
            this.gridControl_List.DataSource = null;
            this.sReceiptID = string.Empty;
            this.chkUnCheck.Checked = false;
            if (this.chkDisparityPrice.Checked)
            {
                foreach (var v in this.lstViewDV)
                {
                    if (v.ReceiptID_DisparityPrice > 0)
                    {
                        v.Check = 1;
                        this.sReceiptID += v.RowID + ",";
                    }
                    else
                        v.Check = 0;
                }
                this.tstripOptions_MenuInPhuThu.Checked = true;
            }
            else
                this.tstripOptions_MenuInPhuThu.Checked = false;
            this.gridControl_ListBanksAccount.DataSource = this.lstViewDV;
            this.gridView_ListBanksAccount.Columns["ServiceGroupName"].Group();
            this.gridView_ListBanksAccount.ExpandAllGroups();

            this.gridControl_List.DataSource = this.lstViewThuoc;

            decimal amountBHYTTotal = 0;
            decimal amountBHYTTotalObject = 0;
            this.dtotalBHYT = SuggestedServiceReceiptBLL.CheckTotalBHYT(dPatientReceiveID);
            foreach (DataRow dr in dtotalBHYT.Rows)
            {
                amountBHYTTotalObject += Convert.ToDecimal(dr["TotalBHYT"].ToString());
            }
            this.amountBHYTtemp = amountBHYTTotalObject;
            this.ListService(ref amountBHYTTotal, false);
            this.ListMedical(ref amountBHYTTotal, false);
            #region tinh lai BHYT cho dich vu va thuoc
            if (this.iObjectCode.Equals(1))
            {
                BHYTParametersInf bhytpara = BHYTParametersBLL.ObjParameters(1);
                if (amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iTraituyen == 0 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iCapcuu == 1 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iChuyenvien == 1)
                {
                    foreach (var v in this.lstViewDV)
                    {
                        if (v.ObjectCode == 1)
                        {
                            v.BHYTPay = v.Quantity * v.ServicePrice;
                            v.PatientPay = 0;
                        }
                    }
                }
            }
            if (this.iObjectCode.Equals(1))
            {
                BHYTParametersInf bhytpara = BHYTParametersBLL.ObjParameters(1);
                if (amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iTraituyen == 0 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iCapcuu == 1 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iChuyenvien == 1)
                {
                    foreach (var items in this.lstViewThuoc)
                    {
                        if (items.ObjectCode == 1)
                        {
                            items.BHYTPay = items.Quantity * items.UnitPrice;
                            items.PatientPay = 0;
                        }
                    }
                }
            }
            #endregion
            this.SumAmountTotal(this.sReceiptID.TrimEnd(','));
        }

        private void tstripOptions_MenuInPhuThu_Click(object sender, EventArgs e)
        {
            if (this.tstripOptions_MenuInPhuThu.Checked)
            {
                this.tstripOptions_MenuInTH.Checked = this.tstripOptions_MenuInChiTiet.Checked = this.tstripOptions_MenuInTongDotDieuTri.Checked = false;

            }
        }

        private decimal GetAmountDiscountMedical()
        {
            List<SuggestedViewMedicinesInf> lstMedicalReal = this.lstViewThuoc.Where(p => p.Check.Equals(1)).ToList();
            decimal totalDiscount = 0;
            foreach (var sugg in lstMedicalReal)
            {
                totalDiscount += sugg.ServicePriceSalesOff;
            }
            return totalDiscount;
        }

        private void gridView_List_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
            try
            {
                GridView view = sender as GridView;
                if (view.FocusedColumn.FieldName == "Check")
                {
                    this.sReceiptID = string.Empty;
                    if (this.gridView_List.GetRowCellValue(e.RowHandle, "Check").ToString() == "1")
                    {
                        this.gridView_List.SetRowCellValue(e.RowHandle, "Check", 0);
                    }
                    else
                    {
                        this.gridView_List.SetRowCellValue(e.RowHandle, "Check", 1);
                    }
                    foreach (var v in this.lstViewThuoc)
                    {
                        if (v.Check == 1)
                            this.sReceiptID += v.RowID + ",";
                    }
                    if (!string.IsNullOrEmpty(this.sReceiptID))
                    {
                        decimal amountBHYTTotal = 0;
                        decimal amountBHYTTotalObject = 0;
                        this.dtotalBHYT = SuggestedServiceReceiptBLL.CheckTotalBHYT(dPatientReceiveID);
                        foreach (DataRow dr in dtotalBHYT.Rows)
                        {
                            amountBHYTTotalObject += Convert.ToDecimal(dr["TotalBHYT"].ToString());
                        }
                        this.amountBHYTtemp = amountBHYTTotalObject;
                        // lay lai tong tien amountBHYTTota
                        this.ListService(ref amountBHYTTotal, false);
                        this.ListMedical(ref amountBHYTTotal, false);
                        #region tinh lai BHYT cho dich vu va thuoc
                        if (this.iObjectCode.Equals(1))
                        {
                            BHYTParametersInf bhytpara = BHYTParametersBLL.ObjParameters(1);
                            if (amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iTraituyen == 0 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iCapcuu == 1 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iChuyenvien == 1)
                            {
                                foreach (var v in this.lstViewDV)
                                {
                                    if (v.ObjectCode == 1)
                                    {
                                        v.BHYTPay = v.Quantity * v.ServicePrice;
                                        v.PatientPay = 0;
                                    }
                                }
                            }
                        }
                        this.gridControl_ListBanksAccount.DataSource = this.lstViewDV;
                        this.gridView_ListBanksAccount.Columns["ServiceGroupName"].Group();
                        this.gridView_ListBanksAccount.ExpandAllGroups();
                        if (this.iObjectCode.Equals(1))
                        {
                            BHYTParametersInf bhytpara = BHYTParametersBLL.ObjParameters(1);
                            if (amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iTraituyen == 0 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iCapcuu == 1 || amountBHYTTotalObject <= bhytpara.BHYTUnderPrice && this.iChuyenvien == 1)
                            {
                                foreach (var items in this.lstViewThuoc)
                                {
                                    if (items.ObjectCode == 1)
                                    {
                                        items.BHYTPay = items.Quantity * items.UnitPrice;
                                        items.PatientPay = 0;
                                    }
                                }
                            }
                        }
                        this.gridControl_List.DataSource = this.lstViewThuoc;
                        #endregion
                        this.SumAmountTotal(this.sReceiptID.TrimEnd(','));
                    }
                    else
                        this.SumAmountTotal("-1");
                }
            }
            catch { }
        }

        private void butInBangKeHD_Click(object sender, EventArgs e)
        {
            ViewPopup.frmExcelPathName frmPath = new ViewPopup.frmExcelPathName();
            frmPath.ShowInTaskbar = false;
            frmPath.ShowDialog();
            if (frmPath.reloaded)
            {
                this.gridControl_BankList.ExportToXls(frmPath.pathName);
                oxl = new Excel.Application();
                owb = (Excel._Workbook)(oxl.Workbooks.Open(frmPath.pathName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                osheet = (Excel._Worksheet)owb.ActiveSheet;
                oxl.ActiveWindow.DisplayGridlines = false;
                oxl.ActiveWindow.DisplayZeros = false;
                oxl.Visible = true;
            }
        }

        private void txtSearchCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.butSearch_Click(sender, e);
            else if (e.KeyCode == Keys.Tab)
                this.txtSearchName.Focus();
        }

        private void txtSearchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.butSearch_Click(sender, e);
            else if (e.KeyCode == Keys.Tab)
                this.txtSearchAge.Focus();
        }

        private void txtSearchAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.butSearch_Click(sender, e);
        }

        private void LoadDataFeePaymentDetail()
        {
            this.tableDetailPayment = Fee_Advance_PaymentBLL.TableAdvance_PaymentDetail(this.dPatientReceiveID, this.txtMabn.Text, this.iPaid, 1);
            this.gridControl_FeePayment.DataSource = this.tableDetailPayment;
            decimal totalAmountReal = 0;
            foreach (DataRow row in this.tableDetailPayment.Rows)
            {
                totalAmountReal += Convert.ToDecimal(row["AmountReal"]);
            }
            this.txtTotalPayment.EditValue = totalAmountReal.ToString("N0");
        }
        
    }
}