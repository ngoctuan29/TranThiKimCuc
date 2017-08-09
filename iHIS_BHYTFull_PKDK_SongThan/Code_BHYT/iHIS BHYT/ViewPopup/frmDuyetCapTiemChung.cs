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
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using System.Globalization;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmDuyetCapTiemChung : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string patientCode = string.Empty;
        private string exportCode = string.Empty;
        private string MedicalCode = string.Empty;
        private decimal dReceiveID = 0;
        private string sUserid = string.Empty, sTheBHYT = string.Empty;

        private bool bImportDate = false;
        private bool bShipment = false;
        private bool bDateEnd = false;
        private DataTable tableMedicalDetail = new DataTable();
        private bool bcheckInventory = true; // Kiem tra ton kho
        private decimal dVirtual = 0;
        private decimal dRowIDMedicines = 0;

        private int iObjectCode = 0, iTraituyen = 0, typeMedical = 3;
        private string sRepositoryCode = string.Empty;
        private string shiftWork = string.Empty;
        private DateTime dtWorking;
        private List<MedicalRecord_WaitingBrowseModel> lstMedicalRecordRestul = new List<MedicalRecord_WaitingBrowseModel>();
        public frmDuyetCapTiemChung(string _User, string _RepositoryCode, string _shiftWork)
        {
            InitializeComponent();
            this.sUserid = _User;
            this.sRepositoryCode = _RepositoryCode;
            this.shiftWork = _shiftWork;
            this.dtWorking = Utils.DateServer();
        }

        private void ClearInfo()
        {
            try
            {
                this.patientCode = this.exportCode = this.MedicalCode = this.sTheBHYT = string.Empty;
                this.iObjectCode = this.iTraituyen = 0;
            }
            catch { }
        }
        
        public void LoadListDrugOfPatient()
        {
            try
            {
                this.tableMedicalDetail = MedicalRecord_BLL.DTMedicalRecordApprove(MedicalCode, iObjectCode, sRepositoryCode, this.rdNo.Checked ? 0 : 1, dRowIDMedicines);
                this.gridControl_List.DataSource = this.tableMedicalDetail;
            }
            catch { }
        }

        public void LoadWaitingList()
        {
            try
            {
                if (this.rdYes.Checked)
                {                    
                    this.butCancel.Enabled = true;
                    this.lstMedicalRecordRestul = MedicalRecord_BLL.ListPatient_WaitingBrowse(1, this.sRepositoryCode, this.typeMedical,0,Convert.ToDateTime(this.dtimeFrom.EditValue), Convert.ToDateTime(this.dtimeTo.EditValue));
                    this.gridControl_WaitingList.DataSource = this.lstMedicalRecordRestul;
                }
                else
                {
                    this.butCancel.Enabled = false;
                    this.lstMedicalRecordRestul = MedicalRecord_BLL.ListPatient_WaitingBrowse(0, this.sRepositoryCode, this.typeMedical,1, Convert.ToDateTime(this.dtimeFrom.EditValue), Convert.ToDateTime(this.dtimeTo.EditValue));
                    this.gridControl_WaitingList.DataSource = this.lstMedicalRecordRestul;
                }
                this.butOK.Enabled = false;
            }
            catch { }
        }

        private void frmDuyetCapTiemChung_Load(object sender, EventArgs e)
        {
            this.LoadWaitingList();
            this.repLkup_Shipment.DataSource = InventoryBLL.TableShipmentForItem(string.Empty, this.sRepositoryCode);
            this.repLkup_Shipment.DisplayMember = "Shipment";
            this.repLkup_Shipment.ValueMember = "Shipment";
            this.butPrint.Enabled = false;
            this.dtimeFrom.EditValue = this.dtimeTo.EditValue = this.dtWorking;
        }

        private string ISDBNULL2STRING(object a, object b)
        {
            if (a == DBNull.Value)
            {
                return string.Empty;
            }
            else
                return Convert.ToString(a);
        }
        
        private void GetCardInfo(string sCard)
        {
            //try
            //{
            //    string sMaBHYT = sCard.Substring(0, 2);
            //    RateBHYTInf model = RateBHYTBLL.objectRateBHYT(sMaBHYT);
            //    if (model != null || model.RateCard != string.Empty)
            //    {
            //        if (chkTraiTuyen.Checked == true)
            //            lbTileBHYT.Text = "BHYT " + model.RateFalse + "% ";
            //        else
            //            lbTileBHYT.Text = "BHYT " + model.RateTrue + "% ";
            //    }
            //}
            //catch { }
        }

        private void GetInfoPatient()
        {
            try
            {
                PatientsInf objPatient = PatientsBLL.ObjPatients(this.patientCode, this.dReceiveID);
                if (objPatient != null && objPatient.PatientCode != null)
                {
                    lbMabn01.Text = objPatient.PatientCode;
                    lbHoten01.Text = objPatient.PatientName;
                    lbNamsinh01.Text = objPatient.PatientBirthday.ToString().Substring(0, 10); //objPatient.PatientBirthyear.ToString();
                    lbTuoi01.Text = objPatient.PatientAge.ToString();
                    if (objPatient.PatientGender == 0)
                        lbGioitinh01.Text = "Nữ";
                    else
                        lbGioitinh01.Text = "Nam";
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
                else
                    return;
            }
            catch { }
        }

        private void VisableBHYT(bool b)
        {
            //lbSothe.Visible = b;
            //lbTungay.Visible = b;
            //chkTraiTuyen.Visible = b;
            //lbNoiDKKCB.Visible = b;
            //lbDenngay.Visible = b;
            //lbTongchiphi01.Visible = true;
            //lbBHYTTra01.Visible = true;
            //lbBenhNhantra01.Visible = true;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView_List.RowCount > 0)
                {
                    string sMsgError = string.Empty;
                    decimal dAmountEnd = 0, dQuantity = 0, dAmountExp = 0;
                    foreach (DataRow r in this.tableMedicalDetail.Rows)
                    {
                        dQuantity = Convert.ToDecimal(r["Quantity"].ToString());
                        dAmountExp = InventoryBLL.QuantityInvent(r["ItemCode"].ToString(), ref dVirtual, sRepositoryCode, ref dAmountEnd);
                        if (dQuantity > dAmountEnd)
                        {
                            sMsgError += r["ItemName"].ToString() + " tồn: " + dAmountExp.ToString("N0");
                            bcheckInventory = false;
                        }
                    }
                    if (bcheckInventory)
                    {
                        SystemParameterInf para = new SystemParameterInf();
                        para = SystemParameterBLL.ObjParameter(200);
                        string sSort = string.Empty;
                        if (para != null && para.Values == 1)
                        {
                            bImportDate = true;
                            sSort += "DateImport,";
                        }
                        para = SystemParameterBLL.ObjParameter(201);
                        if (para != null && para.Values == 1)
                        {
                            bShipment = true;
                            sSort += "Shipment,";
                        }
                        para = SystemParameterBLL.ObjParameter(202);
                        if (para != null && para.Values == 1)
                        {
                            bDateEnd = true;
                            sSort += "DateEnd,";
                        }
                        string sItemCode = string.Empty;
                        MedicinesForPatients Medi = new MedicinesForPatients();
                        Medi.MedicalRecordCode = MedicalCode;
                        Medi.PatientReceiveID = dReceiveID;
                        Medi.PatientCode = patientCode;
                        Medi.EmployeeCode = sUserid;
                        Medi.MM = this.dtWorking.Month;
                        Medi.YYYY = this.dtWorking.Year;
                        Medi.EmployeeCode = sUserid;
                        Medi.ObjectCode = iObjectCode;
                        Medi.RowID = 0;
                        Medi.shiftWork = this.shiftWork;
                        Medi.DateApproved = Convert.ToDateTime(this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
                        if (MedicinesForPatientsBLL.Ins(Medi, ref dRowIDMedicines) >= 1)
                        {
                            foreach (DataRow r in this.tableMedicalDetail.Rows)
                            {
                                decimal dQuanRequest = Convert.ToDecimal(r["Quantity"].ToString());
                                decimal dQuanReal = 0;
                                sItemCode = r["ItemCode"].ToString();
                                List<InventoryGumshoeInf> lst = new List<InventoryGumshoeInf>();
                                lst = InventoryBLL.ListInventoryGumshoe(sItemCode, sRepositoryCode, sSort.TrimEnd(','), r["Shipment"].ToString());
                                if (lst != null && lst.Count > 0)
                                {
                                    MedicinesForPatientsDetail MediDetail = new MedicinesForPatientsDetail();
                                    MediDetail.MedicalRecordCode = MedicalCode;
                                    foreach (var v in lst)
                                    {
                                        dQuanReal = v.AmountImport - v.AmountExport;
                                        if (dQuanReal >= dQuanRequest && dQuanReal > 0)
                                        {
                                            MediDetail.ItemCode = v.ItemCode;
                                            MediDetail.DateOfIssues = Convert.ToInt32(r["DateOfIssues"].ToString());
                                            MediDetail.Quantity = dQuanRequest;
                                            MediDetail.UnitPrice = Convert.ToDecimal(r["UnitPrice"].ToString());
                                            MediDetail.SalesPrice = Convert.ToDecimal(r["SalesPrice"].ToString());
                                            MediDetail.BHYTPrice = Convert.ToDecimal(r["BHYTPrice"].ToString());
                                            MediDetail.Amount = Convert.ToDecimal(r["Amount"].ToString());
                                            MediDetail.RowIDInventoryGumshoe = v.RowID;
                                            MediDetail.RateBHYT = Convert.ToDecimal(r["RateBHYT"].ToString());
                                            MediDetail.ObjectCode = iObjectCode;
                                            MediDetail.RepositoryCode = r["RepositoryCode"].ToString();
                                            MediDetail.QuantityExport = dQuanRequest;
                                            MediDetail.RowIDMedicines = dRowIDMedicines;
                                            MediDetail.RowIDMedicalPrescription = Convert.ToDecimal(r["RowID"].ToString());
                                            MedicinesForPatientsBLL.InsDetail(MediDetail);
                                            break;
                                        }
                                        else if(dQuanReal > 0)
                                        {
                                            MediDetail.ItemCode = v.ItemCode;
                                            MediDetail.DateOfIssues = Convert.ToInt32(r["DateOfIssues"].ToString());
                                            MediDetail.Quantity = dQuanReal;
                                            MediDetail.UnitPrice = Convert.ToDecimal(r["UnitPrice"].ToString());
                                            MediDetail.SalesPrice = Convert.ToDecimal(r["SalesPrice"].ToString());
                                            MediDetail.BHYTPrice = Convert.ToDecimal(r["BHYTPrice"].ToString());
                                            MediDetail.Amount = Convert.ToDecimal(r["Amount"].ToString());
                                            MediDetail.RowIDInventoryGumshoe = v.RowID;
                                            MediDetail.RateBHYT = Convert.ToDecimal(r["RateBHYT"].ToString());
                                            MediDetail.ObjectCode = iObjectCode;
                                            MediDetail.RepositoryCode = r["RepositoryCode"].ToString();
                                            MediDetail.QuantityExport = dQuanReal;
                                            MediDetail.RowIDMedicines = dRowIDMedicines;
                                            MediDetail.RowIDMedicalPrescription = Convert.ToDecimal(r["RowID"].ToString());
                                            MedicinesForPatientsBLL.InsDetail(MediDetail);
                                            dQuanRequest = dQuanRequest - dQuanReal;
                                        }
                                    }
                                }
                                else
                                {
                                    MedicinesForPatientsBLL.Del(MedicalCode, dRowIDMedicines,this.sUserid);
                                    XtraMessageBox.Show(" Lỗi khi trừ tồn kho, liên hệ quản trị ! \n\t", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            XtraMessageBox.Show(" Duyệt thuốc thành công!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInfo();
                            this.tableMedicalDetail.Clear();
                            LoadWaitingList();
                        }
                        else
                        {
                            MedicinesForPatientsBLL.Del(MedicalCode, dRowIDMedicines,this.sUserid);
                            XtraMessageBox.Show(" Phát sinh lỗi, vui lòng xem lại \n\t", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Những thuốc sau không đủ tồn: \n\t" + sMsgError, "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Không có thuốc để xuất! \n\t Xem lại thông tin chi tiết thuốc trước khi xuất kho.", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch { }
        }

        private void butReload_Click(object sender, EventArgs e)
        {
            this.LoadWaitingList();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MedicalCode != "")
                {
                    if (XtraMessageBox.Show("Bạn có muốn hủy phiếu duyệt kho này hay không?", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.YesNo) != DialogResult.No)
                    {
                        try
                        {
                            if (MedicinesForPatientsBLL.Del(MedicalCode, dRowIDMedicines,this.sUserid) == 1)
                            {
                                XtraMessageBox.Show(" Hủy phiếu thành công!", "Bệnh Viện Điện Tử .Net");
                                this.tableMedicalDetail.Clear();
                                ClearInfo();
                                LoadWaitingList();
                                return;
                            }
                            else
                            {
                                XtraMessageBox.Show(" Bệnh nhân đã thanh toán không cho phép hủy.", "Bệnh Viện Điện Tử .Net");
                                return;
                            }
                        }
                        catch { return; }
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Chọn bệnh nhân để hủy phiếu.", "Bệnh Viện Điện Tử .Net");
                    return;
                }
            }
            catch { }
        }

        private void rdNo_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadWaitingList();
            this.gridView_List.Columns["Shipment"].OptionsColumn.ReadOnly = false;
            this.gridView_List.Columns["Shipment"].OptionsColumn.AllowFocus = true;
            this.gridView_List.Columns["Shipment"].OptionsColumn.AllowEdit = true;
            this.butPrint.Enabled = false;
        }

        private void rdYes_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadWaitingList();
            this.gridControl_List.DataSource = null;
            this.gridView_List.Columns["Shipment"].OptionsColumn.ReadOnly = true;
            this.gridView_List.Columns["Shipment"].OptionsColumn.AllowFocus = false;
            this.gridView_List.Columns["Shipment"].OptionsColumn.AllowEdit = false;
        }

        private void gridView_WaitingList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_WaitingList.RowCount > 0)
                {
                    if (this.gridView_WaitingList.GetFocusedRow() != null)
                    {
                        this.patientCode = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientCode).ToString(), string.Empty);
                        this.MedicalCode = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_MedicalRecordCode).ToString(), string.Empty);
                        this.dReceiveID = Convert.ToDecimal(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientReceiveID).ToString());
                        this.iObjectCode = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectCode).ToString());
                        this.dRowIDMedicines = Convert.ToDecimal(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_RowIDMedicinesFor).ToString());
                        if (this.patientCode != string.Empty && this.dReceiveID != 0 && this.MedicalCode != string.Empty && this.iObjectCode != 0)
                        {
                            this.LoadListDrugOfPatient();
                            if (this.iObjectCode == 1)
                            {
                                //List<BHYTInf> lstBHYT = new List<BHYTInf>();
                                //lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(dReceiveID);
                                //if (lstBHYT.Count > 0)
                                //{
                                //    sTheBHYT = lstBHYT[0].Serial;
                                //    lbSothe.Text = lstBHYT[0].Serial;
                                //    lbTungay.Text = lstBHYT[0].StartDate.ToString("dd/MM/yyyy");
                                //    iTraituyen = lstBHYT[0].TraiTuyen;
                                //    if (iTraituyen == 1)
                                //        chkTraiTuyen.Checked = true;
                                //    else
                                //        chkTraiTuyen.Checked = false;
                                //    this.lbNoiDKKCB.Text = lstBHYT[0].KCBBDCode.ToString();
                                //    this.lbDenngay.Text = lstBHYT[0].EndDate.ToString("dd/MM/yyyy");
                                //    this.GetCardInfo(lstBHYT[0].Serial);
                                //    this.VisableBHYT(true);
                                //}
                        }
                            else
                            {
                                this.lbTileBHYT.Text = this.gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectName).ToString();
                                this.VisableBHYT(false);
                            }
                            this.GetInfoPatient();
                            if (this.rdNo.Checked)
                                this.butOK.Enabled = true;
                            else
                                this.butOK.Enabled = false;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi xảy ra khi chọn bệnh nhân duyệt đơn thuốc: \t\n" + ex.Message, "Bệnh Viện Điện Tử .Net");
                return;
            }
        }

        private void gridView_List_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
                string itemCodeTemp = view.GetFocusedRowCellValue(this.col_ItemCode).ToString();
                if (view.FocusedColumn.FieldName == "Shipment" && view.ActiveEditor is LookUpEdit)
                {
                    LookUpEdit edit = (LookUpEdit)view.ActiveEditor;
                    edit.Properties.DataSource = InventoryBLL.TableShipmentForItem(itemCodeTemp, this.sRepositoryCode);
                }
            }
            catch { return; }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string rowIDMedicinesForTemp = string.Empty;
                List<MedicalRecord_WaitingBrowseModel> lstTemp = this.lstMedicalRecordRestul.Where(p => p.Printer == 1).ToList();
                if (lstTemp.Count > 0)
                {
                    foreach (var v in lstTemp)
                    {
                        rowIDMedicinesForTemp += v.RowIDMedicinesFor.ToString() + ',';
                    }
                    DataTable tableResult = MedicinesForPatientsBLL.TablePrintMedicinesForPatients(rowIDMedicinesForTemp.TrimEnd(','));
                    DataSet dsResult = new DataSet();
                    dsResult.Tables.Add(tableResult);
                    dsResult.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\xmlTiemChungDuyetCap.xml");
                    Reports.rptTiemChungDuyetCap rptShow = new Reports.rptTiemChungDuyetCap();
                    rptShow.DataSource = dsResult;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "DuyetCapTiemChung","Duyệt cấp tiêm chủng");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Chọn bệnh nhân cần in toa thuốc!", "Bệnh Viện Điện Tử .Net", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_WaitingList_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.butPrint.Enabled = true;
        }
        
    }
}