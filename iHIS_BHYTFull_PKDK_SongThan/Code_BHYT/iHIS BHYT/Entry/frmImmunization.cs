using System;
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
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Ps.Clinic.ViewPopup;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraRichEdit.API.Native;

namespace Ps.Clinic.Entry
{
    public partial class frmImmunization : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string patientCode, patientName = string.Empty;
        private string serviceCode = string.Empty;
        private string serviceName = string.Empty;
        private string referenceCode = string.Empty, immunizationRecordCode = string.Empty, immunizationRecordDetailCode = string.Empty, imageCode = string.Empty;
        private decimal patientReceiveID = 0, realMedicinesID = 0, receiptID = 0;
        private Int32 status = 1, iObjectCode = 0, iPatientType = 0, paid = 0, statusMedical = 0;
        private string sTheBHYT = string.Empty;
        private int iTraituyen = 0;
        private string departmentCode = string.Empty, departmentName = string.Empty, employeeCodeDoctor = string.Empty;
        private string s_uSerid = string.Empty, medicalRecordCode = string.Empty;
        private List<Items_Ref> lstItem = new List<Items_Ref>();
        private DataTable dtMedicalRecord_Material = new DataTable();
        private int iMenu = 0, typeMedical = 3;
        private DataView cloneout = null;
        private DateTime dtimeWorking = new DateTime();
        private DateTime dtimeServer = new DateTime();
        private DateTime dtimeGiven;
        private List<DiagnosisAbbreviationsInf> listAbb;
        private string shiftWork = string.Empty;
        public frmImmunization(string _spk, string _uSerid, int _Menu, string _namekp, string _shiftWork, string _employeeCodeDoctor, DateTime _dtWorking)
        {
            InitializeComponent();
            grWaitingList.Visible = true;
            grWaitingList.Dock = DockStyle.Fill;
            grPrevious.Visible = false;
            grPrevious.Dock = DockStyle.None;
            departmentCode = _spk;
            s_uSerid = _uSerid;
            iMenu = _Menu;
            departmentName = _namekp;
            this.shiftWork = _shiftWork;
            this.employeeCodeDoctor = _employeeCodeDoctor;
            this.dtimeWorking = this.dtimeGiven = _dtWorking;
        }

        private void frmImmunization_Load(object sender, EventArgs e)
        {
            try
            {
                this.dtimeServer = Utils.DateServer();
                this.EnableField(true);
                this.ref_ObjectCode.DataSource = ObjectBLL.ListObject(0);
                this.ref_ObjectCode.DisplayMember = "ObjectName";
                this.ref_ObjectCode.ValueMember = "ObjectCode";
                
                this.ref_Material_UoM.DataSource = UnitOfMeasureBLL.ListUnit(string.Empty,"I");
                this.ref_Material_UoM.DisplayMember = "UnitOfMeasureName";
                this.ref_Material_UoM.ValueMember = "UnitOfMeasureCode";
                List<InstructionInf> lstInstruc = InstructionBLL.ListInstruction(0);
                foreach (var v in lstInstruc)
                {
                    rep_Out_Instruction.Items.Add(v.InstructionName);
                }
                this.LoadGeneral();
                this.LoadDataDoseNo();
                this.EnableButton(true);
                this.lbInfo.Text = string.Empty;
                this.listAbb = DiagnosisAbbreviationsBLL.ListAbb(this.s_uSerid);
                //this.GetTableMaterial();
                this.gridView_Material.OptionsBehavior.ReadOnly = true;
                this.gridView_Material.OptionsBehavior.Editable = false;
                this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                this.chkTheEnd.Enabled = false;
                this.LoadListPatientWaitingCompleted(0);
            }
            catch { }
        }

        private void LoadDataDoseNo()
        {
            DataTable tableImmunization = new DataTable();
            tableImmunization = ImmunizationRecordBll.TableDoseNo();
            this.lkupLanTiem.Properties.DataSource = tableImmunization;
            this.lkupLanTiem.Properties.DisplayMember = "DoseNoName";
            this.lkupLanTiem.Properties.ValueMember = "RowID";
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
        
        private decimal ISDBNULL2DECIMAL(object a, object b)
        {
            if (a == DBNull.Value)
            {
                return Convert.ToDecimal(b);
            }
            else
                return Convert.ToDecimal(a);
        }
        
        private Int32 ISDBNULL2INT32(object a, object b)
        {
            if (a == DBNull.Value)
            {
                return Convert.ToInt32(b);
            }
            else
                return Convert.ToInt32(a);
        }
        
        public void EnableField(bool ena)
        {
            this.txtGhichu.Properties.ReadOnly = ena;
            this.txtMach.Properties.ReadOnly = this.txtNhietdo.Properties.ReadOnly = this.txtHuyetap.Properties.ReadOnly = this.txtHuyetap1.Properties.ReadOnly = this.txtCao.Properties.ReadOnly = this.txtNang.Properties.ReadOnly = ena;
            this.txtContent.ReadOnly = ena;
            this.txtTiensubenh.Properties.ReadOnly = this.txtDiung.Properties.ReadOnly = this.txtGhichu.Properties.ReadOnly = this.dtNgayHen.Properties.ReadOnly = this.memoNoidunghen.Properties.ReadOnly = ena;
            //this.gridView_Material.OptionsBehavior.ReadOnly = !ena;
            //this.gridView_Material.OptionsBehavior.Editable = ena;
            this.lkupLanTiem.Properties.ReadOnly = true;
        }

        public void EnableButton(bool b)
        {
            butUndo.Enabled = !b;
            butEdit.Enabled = false;
            butPrint.Enabled = false;
            butPrintVTTH.Enabled = false;
            butCancel.Enabled = false;
            butSave.Enabled = false;
            this.butToaNhaThuoc.Enabled = false;
        }

        public void CleanerFieldALL()
        {
            this.txtTiensubenh.Text = this.txtGhichu.Text = this.txtMach.Text = this.txtHuyetap.Text = this.txtHuyetap1.Text = this.txtNhietdo.Text = this.txtCao.Text = this.txtNang.Text = this.lbBMI.Text = string.Empty;
            this.lkupLanTiem.EditValue = null;
            ////this.txtSolo.EditValue = this.txtGhichu.EditValue = this.memoNoidunghen.EditValue = string.Empty;
            this.dtNgayHen.Text = string.Empty;
            this.txtContent.RtfText = string.Empty;
            this.lbInfo.Text = string.Empty;
            Bitmap b = new Bitmap("NoImgPatient.jpeg");
            this.picPatient.Image = (Bitmap)b;

            this.patientCode = this.patientName = string.Empty;
            this.serviceCode = string.Empty;
            this.serviceName = string.Empty;
            this.referenceCode = string.Empty;
            this.patientReceiveID = this.receiptID = this.realMedicinesID = 0;
            this.iObjectCode = this.iPatientType = 0;
            this.status = 1;
            this.imageCode = this.immunizationRecordCode = this.immunizationRecordDetailCode = this.medicalRecordCode = string.Empty;
            this.sTheBHYT = string.Empty;
            this.iTraituyen = 0;
            this.chkTheEnd.Checked = false;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lkupLanTiem.EditValue == null || this.lkupLanTiem.Text.Trim() == string.Empty)
                {
                    XtraMessageBox.Show(" Chọn lần tiêm chủng, để thực hiện!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkupLanTiem.Focus();
                    return;
                }
                //else if (this.txtSolo.Text.Trim() == string.Empty)
                //{
                //    XtraMessageBox.Show(" Nhập số lô cho đợt tiêm chủng! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    this.txtSolo.Focus();
                //    return;
                //}
                else
                {
                    var infImmun = new ImmunizationRecordInf();
                    {
                        infImmun.ImmunizationRecordCode = this.immunizationRecordCode;
                        infImmun.ObjectCode = this.iObjectCode;
                        infImmun.PatientType = this.iPatientType;
                        infImmun.ServiceCode = this.serviceCode;
                        infImmun.PatientReceiveID = this.patientReceiveID;
                        infImmun.PatientCode = this.patientCode;
                        infImmun.ReceiptID = this.receiptID;
                        infImmun.DepartmentCode = this.departmentCode;
                        infImmun.WorkDate = Convert.ToDateTime(this.dtimeWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
                        infImmun.EmployeeCode = this.s_uSerid;
                        if (this.status == 0)
                            infImmun.Status = 1;
                        else
                            infImmun.Status = this.status;
                        if (chkTheEnd.Checked)
                            infImmun.Status = 2;
                        infImmun.ShiftWork = this.shiftWork;
                    };
                    if (ImmunizationRecordBll.InsImmunization(infImmun, ref this.immunizationRecordCode) && this.immunizationRecordCode != string.Empty)
                    {
                        PatientsBLL.UpdPatients(txtTiensubenh.Text, txtDiung.Text, this.patientCode);
                        var infImmundetail = new ImmunizationRecordDetailInf();
                        {
                            infImmundetail.ImmunizationRecordCode = this.immunizationRecordCode;
                            infImmundetail.ImmunizationRecordDetailCode = this.immunizationRecordDetailCode;
                            infImmundetail.RowIDDoseNo = Convert.ToInt32(this.lkupLanTiem.EditValue);
                            infImmundetail.LotNo = string.Empty;
                            infImmundetail.Note = this.txtGhichu.Text;
                            infImmundetail.Content = this.txtContent.RtfText;
                            infImmundetail.DateGiven = this.dtimeGiven;
                            if (this.dtNgayHen.EditValue != null && this.dtNgayHen.Text != string.Empty)
                                infImmundetail.AppointmentDate = this.dtNgayHen.Text;
                            else
                                infImmundetail.AppointmentDate = string.Empty;
                            infImmundetail.AppointmentContent = this.memoNoidunghen.Text;
                            infImmundetail.EmployeeCode = this.s_uSerid;
                            infImmundetail.ShiftWork = this.shiftWork;
                            infImmundetail.EmployeeCodeDoctor = this.employeeCodeDoctor;
                        };
                        if (ImmunizationRecordBll.InsImmunizationDetail(infImmundetail, ref this.immunizationRecordDetailCode))
                        {
                            string sMsgError = string.Empty, sMsgErrorQuantity = string.Empty;
                            this.InsSurviveSign();

                            #region Xuat thuoc tu truc
                            //if (gridView_Material.RowCount != 0 && paid == 0)
                            //{
                            //    decimal dQuantity = 0, dAmountEnd = 0, dQuantityReq = 0;
                            //    bool bcheckInventory = true, bImportDate = false, bShipment = false, bDateEnd = false, bCheckQuantity = true;
                            //    string sMsgError = string.Empty, sError = string.Empty;
                            //    foreach (DataRow r in dtMedicalRecord_Material.Rows)
                            //    {
                            //        dQuantityReq = Convert.ToDecimal(r["Quantity"].ToString());
                            //        dQuantity = InventoryBLL.QuantityInvent(r["ItemCode"].ToString(), ref dAmountEnd, r["RepositoryCode"].ToString(), ref dAmountEnd);
                            //        if (dAmountEnd < dQuantityReq)
                            //        {
                            //            sMsgError += r["ItemName"].ToString() + " tồn: " + dAmountEnd.ToString("N0");
                            //            bcheckInventory = false;
                            //        }
                            //        if (dQuantityReq <= 0)
                            //        {
                            //            sError += r["ItemName"].ToString() + "(" + dQuantityReq + ");";
                            //            bCheckQuantity = false;
                            //        }
                            //    }
                            //    if (!bCheckQuantity)
                            //    {
                            //        XtraMessageBox.Show(" Những thuốc sau không có số lượng! \n" + sError, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //        return;
                            //    }
                            //    if (bcheckInventory)
                            //    {
                            //        SystemParameterInf para = new SystemParameterInf();
                            //        para = SystemParameterBLL.ObjParameter(200);
                            //        string sSort = string.Empty;
                            //        if (para != null && para.Values == 1)
                            //        {
                            //            bImportDate = true;
                            //            sSort += "DateImport,";
                            //        }
                            //        para = SystemParameterBLL.ObjParameter(201);
                            //        if (para != null && para.Values == 1)
                            //        {
                            //            bShipment = true;
                            //            sSort += "Shipment,";
                            //        }
                            //        para = SystemParameterBLL.ObjParameter(202);
                            //        if (para != null && para.Values == 1)
                            //        {
                            //            bDateEnd = true;
                            //            sSort += "DateEnd,";
                            //        }
                            //        string sItemCode = string.Empty;
                            //        RealMedicinesForPatientsINF infReal = new RealMedicinesForPatientsINF();
                            //        {
                            //            infReal.RowID = this.realMedicinesID;
                            //            infReal.RefCode = this.immunizationRecordDetailCode;
                            //            infReal.PatientReceiveID = this.patientReceiveID;
                            //            infReal.PatientCode = this.patientCode;
                            //            infReal.EmployeeCode = this.s_uSerid;
                            //            infReal.ObjectCode = this.iObjectCode;
                            //            infReal.PatientType = this.iPatientType;
                            //            infReal.VoteRowID = 1;
                            //            infReal.Status = 1;
                            //            infReal.DepartmentCode = this.departmentCode;
                            //            infReal.DateApproved = this.dtimeGiven;
                            //        };
                            //        if (RealMedicinesForPatientsBLL.InsReal(infReal, ref realMedicinesID) > 0)
                            //        {
                            //            bool bResult = true;
                            //            RealMedicinesForPatientsBLL.DelRealDetailOnly(realMedicinesID);
                            //            if (dtMedicalRecord_Material != null && dtMedicalRecord_Material.Rows.Count > 0)
                            //            {
                            //                foreach (DataRow r in dtMedicalRecord_Material.Rows)
                            //                {
                            //                    decimal dQuanRequest = Convert.ToDecimal(r["Quantity"].ToString());
                            //                    decimal dQuanReal = 0;
                            //                    sItemCode = r["ItemCode"].ToString();
                            //                    List<InventoryGumshoeInf> lst = new List<InventoryGumshoeInf>();
                            //                    lst = InventoryBLL.ListInventoryGumshoe(sItemCode, r["RepositoryCode"].ToString(), sSort.TrimEnd(','));
                            //                    if (lst != null && lst.Count > 0)
                            //                    {
                            //                        RealMedicinesForPatientsDetailINF mDetail = new RealMedicinesForPatientsDetailINF();
                            //                        foreach (var v in lst)
                            //                        {
                            //                            dQuanReal = v.AmountImport - v.AmountExport;
                            //                            if (dQuanReal >= dQuanRequest && dQuanReal > 0)
                            //                            {
                            //                                mDetail.RealRowID = realMedicinesID;
                            //                                mDetail.ItemCode = r["ItemCode"].ToString();
                            //                                mDetail.Quantity = dQuanRequest;
                            //                                mDetail.UnitPrice = Convert.ToDecimal(r["UnitPrice"].ToString());
                            //                                mDetail.SalesPrice = Convert.ToDecimal(r["UnitPrice"].ToString());
                            //                                mDetail.BHYTPrice = Convert.ToDecimal(r["UnitPrice"].ToString());
                            //                                mDetail.Amount = Convert.ToDecimal(r["Amount"].ToString());
                            //                                mDetail.RowIDInventoryGumshoe = v.RowID;
                            //                                mDetail.RateBHYT = Convert.ToDecimal(r["RateBHYT"].ToString());
                            //                                mDetail.ObjectCode = Convert.ToInt32(r["ObjectCode"].ToString());
                            //                                mDetail.RepositoryCode = r["RepositoryCode"].ToString();
                            //                                mDetail.Instruction = r["Instruction"].ToString();
                            //                                RealMedicinesForPatientsBLL.InsRealDetail(mDetail);
                            //                                break;
                            //                            }
                            //                            else if (dQuanReal > 0)
                            //                            {
                            //                                mDetail.RealRowID = realMedicinesID;
                            //                                mDetail.ItemCode = v.ItemCode;
                            //                                mDetail.Quantity = dQuanReal;
                            //                                mDetail.UnitPrice = Convert.ToDecimal(r["UnitPrice"].ToString());
                            //                                mDetail.SalesPrice = Convert.ToDecimal(r["UnitPrice"].ToString());
                            //                                mDetail.BHYTPrice = Convert.ToDecimal(r["UnitPrice"].ToString());
                            //                                mDetail.Amount = Convert.ToDecimal(r["Amount"].ToString());
                            //                                mDetail.RowIDInventoryGumshoe = v.RowID;
                            //                                mDetail.RateBHYT = Convert.ToDecimal(r["RateBHYT"].ToString());
                            //                                mDetail.ObjectCode = Convert.ToInt32(r["ObjectCode"].ToString());
                            //                                mDetail.RepositoryCode = r["RepositoryCode"].ToString();
                            //                                mDetail.Instruction = r["Instruction"].ToString();
                            //                                RealMedicinesForPatientsBLL.InsRealDetail(mDetail);
                            //                                dQuanRequest = dQuanRequest - dQuanReal;
                            //                            }
                            //                        }
                            //                    }
                            //                    else
                            //                    {
                            //                        bResult = false;
                            //                        RealMedicinesForPatientsBLL.DelRealDetailAll(realMedicinesID);
                            //                        XtraMessageBox.Show(" Lỗi khi trừ tồn kho, liên hệ quản trị ! \n\t", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //                        return;
                            //                    }
                            //                }
                            //            }

                            //        }
                            //        else
                            //        {
                            //            XtraMessageBox.Show(" Lỗi khi trừ tồn kho, liên hệ quản trị ! \n\t", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //            return;
                            //        }
                            //    }
                            //    else
                            //    {
                            //        XtraMessageBox.Show(" Thuốc không đủ tồn : \n\t" + sMsgError, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //        return;
                            //    }
                            //}
                            #endregion

                            #region ke toa thuoc, duyet kho
                            MedicalRecord_INF modelRecord = new MedicalRecord_INF();
                            modelRecord.MedicalRecordCode = this.medicalRecordCode;
                            modelRecord.PatientReceiveID = this.patientReceiveID;
                            modelRecord.PatientCode = patientCode;
                            modelRecord.DepartmentCode = this.departmentCode;
                            modelRecord.EmployeeCode = this.s_uSerid;
                            modelRecord.DiagnosisCode = 0;
                            modelRecord.DescriptionNode = txtGhichu.Text;
                            modelRecord.PostingDate = Convert.ToDateTime(this.dtimeWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
                            modelRecord.AppointmentDate = Convert.ToDateTime("01/01/1900");
                            modelRecord.ReferenceCode = this.immunizationRecordDetailCode;
                            modelRecord.Symptoms = string.Empty;
                            modelRecord.Status = 0;
                            modelRecord.ObjectCode = this.iObjectCode;
                            modelRecord.Advices = string.Empty;
                            modelRecord.DiagnosisEnclosed = -1;
                            modelRecord.EmployeeCodeDoctor = this.s_uSerid;
                            modelRecord.TackleCode = -1;
                            modelRecord.RowIDMedicalPattern = -1;
                            modelRecord.ContentMedicalPattern = string.Empty;
                            modelRecord.DiagnosisCustom = string.Empty;
                            modelRecord.TypeMedical = 3;
                            modelRecord.ReceiptID = this.receiptID;
                            modelRecord.ShiftWork = this.shiftWork;
                            modelRecord.Treatments = string.Empty;
                            modelRecord.EmployeeCodeDoing = this.s_uSerid;
                            modelRecord.ICD10_Custom = string.Empty;
                            modelRecord.ICD10Name_Custom = string.Empty;
                            int resultMedical = MedicalRecord_BLL.InsMedicalRecord(modelRecord, ref this.medicalRecordCode, ref this.serviceCode, ref sMsgError);
                            if(resultMedical>0)
                            {
                                if (this.dtMedicalRecord_Material != null && this.dtMedicalRecord_Material.Rows.Count > 0 && this.statusMedical == 0)
                                {
                                    decimal dQuantity = 0, dAmountEnd = 0, dQuantityReq = 0;
                                    bool bcheckInventory = true;
                                    bool bcheckQuantity = true;
                                  
                                    foreach (DataRow r in dtMedicalRecord_Material.Rows)
                                    {
                                        dQuantityReq = Convert.ToDecimal(r["Quantity"].ToString());
                                        dQuantity = InventoryBLL.QuantityInvent(r["ItemCode"].ToString(), ref dAmountEnd, r["RepositoryCode"].ToString(), ref dAmountEnd);
                                        if (dQuantityReq <= 0)
                                        {
                                            sMsgErrorQuantity += r["ItemName"].ToString() + " số lượng: " + dQuantityReq.ToString("N0") + "\n\t";
                                            bcheckQuantity = false;
                                        }
                                        if (dAmountEnd < dQuantityReq)
                                        {
                                            sMsgError += r["ItemName"].ToString() + " tồn hiện tại: " + dAmountEnd.ToString("N0") + "\n\t";
                                            bcheckInventory = false;
                                        }
                                    }
                                    if (!bcheckQuantity)
                                    {
                                        XtraMessageBox.Show(" Những thuốc sau chưa nhập số lượng \n\t" + sMsgErrorQuantity, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (bcheckInventory)
                                    {
                                        bool resultDetail = true;
                                        //MedicalRecord_BLL.DelMedicalRecordDetail(this.medicalRecordCode, -1);
                                        foreach (DataRow r in this.dtMedicalRecord_Material.Rows)
                                        {
                                            if (r["Status"].ToString() == "0")
                                            {
                                                MedicalPrescriptionDetail_INF mDetail = new MedicalPrescriptionDetail_INF();
                                                mDetail.MedicalRecordCode = this.medicalRecordCode;
                                                mDetail.EmployeeCode = this.s_uSerid;
                                                mDetail.ItemCode = r["ItemCode"].ToString();
                                                mDetail.DateOfIssues = 1;
                                                mDetail.Morning = string.Empty;
                                                mDetail.Noon = string.Empty;
                                                mDetail.Afternoon = string.Empty;
                                                mDetail.Evening = string.Empty;
                                                mDetail.Quantity = Convert.ToDecimal(r["Quantity"].ToString());
                                                mDetail.Instruction = r["Instruction"].ToString();
                                                mDetail.UnitPrice = Convert.ToDecimal(r["UnitPrice"].ToString());
                                                mDetail.Amount = Convert.ToDecimal(r["Amount"].ToString());
                                                mDetail.PostingDate = Utils.DateTimeServer();
                                                mDetail.Status = 0;
                                                mDetail.New = 1;
                                                mDetail.RepositoryCode = r["RepositoryCode"].ToString();
                                                mDetail.ObjectCode = Convert.ToInt32(r["ObjectCode"].ToString());
                                                mDetail.DoseOf = 1;
                                                mDetail.DoseOfPills = string.Empty;
                                                mDetail.BHYT = 0;
                                                mDetail.PostingDate = Convert.ToDateTime(this.dtimeWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
                                                mDetail.UnitOfMeasureCode_Medi = string.Empty;
                                                if (MedicalRecord_BLL.InsMedicalRecordDetail(mDetail, this.iObjectCode) <= 0)
                                                {
                                                    resultDetail = false;
                                                    sMsgError += r["ItemName"].ToString() + ";";
                                                }
                                            }
                                        }
                                        if (!resultDetail)
                                        {
                                            this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                                            this.gridView_Material.OptionsBehavior.ReadOnly = true;
                                            this.gridView_Material.OptionsBehavior.Editable = false;
                                            XtraMessageBox.Show(" Lưu không thành công thuốc - vtth : \n" + sMsgError + "\n Hãy kiểm tra lại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show(" Thuốc không đủ tồn : \n\t" + sMsgError, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                            }
                            #endregion

                            XtraMessageBox.Show(" Lưu kết quả tiêm chủng thành công !\t\nOK", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.gridControl_PreviousList.Visible = true;
                            this.EnableField(false);
                            this.EnableButton(true);
                            this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                            this.gridView_Material.OptionsBehavior.ReadOnly = true;
                            this.gridView_Material.OptionsBehavior.Editable = false;
                            this.butSave.Enabled = this.butUndo.Enabled = false;
                            this.butEdit.Enabled = true;
                            this.butPrint.Enabled = true;
                            this.butPrintVTTH.Enabled = this.butToaNhaThuoc.Enabled = true;
                            this.GetHistoryPatient();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(" Lưu kết quả tiêm chủng không thành công !\t\nOK", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show(" Lưu kết quả tiêm chủng không thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //finally {
            //    XtraMessageBox.Show(" Lưu kết quả tiêm chủng thành công !\t\nOK", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.gridControl_PreviousList.Visible = true;
            //    this.EnableField(false);
            //    this.EnableButton(true);

            //    this.butSave.Enabled = this.butNew.Enabled = this.butUndo.Enabled = false;
            //    this.butEdit.Enabled = true;
            //    this.butPrint.Enabled = true;
            //    this.butPrintVTTH.Enabled = true;
            //    this.GetHistoryPatient();
            //}
        }

        private void GetSurviveSign()
        {
            try
            {
                List<SurviveSignInf> lstSur = new List<SurviveSignInf>();
                lstSur = SurviveSignBLL.ListSurviveSignForRefCode(this.immunizationRecordDetailCode, this.patientReceiveID, this.patientCode);
                if (lstSur.Count > 0)
                {
                    this.txtMach.Text = lstSur[0].Pulse;
                    this.txtNhietdo.Text = lstSur[0].Temperature;
                    this.txtHuyetap.Text = lstSur[0].BloodPressure;
                    this.txtHuyetap1.Text = lstSur[0].BloodPressure1;
                    this.txtNang.Text = lstSur[0].Weight;
                    this.txtCao.Text = lstSur[0].Hight;
                }
                else
                {
                    this.txtMach.Text = string.Empty;
                    this.txtNhietdo.Text = string.Empty;
                    this.txtHuyetap.Text = string.Empty;
                    this.txtHuyetap1.Text = string.Empty;
                    this.txtNang.Text = string.Empty;
                    this.txtCao.Text = string.Empty;
                }
            }
            catch { return; }
        }

        private void InsSurviveSign()
        {
            try
            {
                List<SurviveSignInf> lstSur = new List<SurviveSignInf>();
                if (this.txtMach.Text.Trim() != string.Empty || this.txtNhietdo.Text.Trim() != string.Empty || this.txtHuyetap.Text.Trim() != string.Empty || this.txtHuyetap1.Text.Trim() != string.Empty || this.txtCao.Text.Trim() != string.Empty || this.txtNang.Text.Trim() != string.Empty)
                {
                    lstSur = SurviveSignBLL.ListSurviveSignForRefCode(this.immunizationRecordDetailCode, this.patientReceiveID, this.patientCode);
                    if (lstSur.Count > 0)
                    {
                        SurviveSignInf infsur = new SurviveSignInf();
                        infsur.RowID = lstSur[0].RowID;
                        infsur.PatientCode = this.patientCode;
                        infsur.Pulse = this.txtMach.Text.Trim();
                        infsur.Temperature = this.txtNhietdo.Text.Trim();
                        infsur.BloodPressure = this.txtHuyetap.Text.Trim();
                        infsur.BloodPressure1 = this.txtHuyetap1.Text.Trim();
                        infsur.Weight = this.txtNang.Text.Trim();
                        infsur.Hight = this.txtCao.Text;
                        infsur.EmployeeCode = this.s_uSerid;
                        infsur.RefID = this.patientReceiveID;
                        infsur.ReferenceCode = this.immunizationRecordDetailCode;
                        infsur.CreateDate = Utils.DateTimeServer();
                        SurviveSignBLL.InsSurviveSign(infsur);
                    }
                    else
                    {
                        SurviveSignInf infsur = new SurviveSignInf();
                        infsur.RowID = 0;
                        infsur.PatientCode = patientCode;
                        infsur.Pulse = txtMach.Text.Trim();
                        infsur.Temperature = txtNhietdo.Text.Trim();
                        infsur.BloodPressure = txtHuyetap.Text.Trim();
                        infsur.BloodPressure1 = txtHuyetap1.Text.Trim();
                        infsur.Weight = txtNang.Text.Trim();
                        infsur.Hight = txtCao.Text.Trim();
                        infsur.EmployeeCode = this.s_uSerid;
                        infsur.RefID = this.patientReceiveID;
                        infsur.ReferenceCode = this.immunizationRecordDetailCode;
                        infsur.CreateDate = Utils.DateTimeServer();
                        SurviveSignBLL.InsSurviveSign(infsur);
                    }
                }
            }
            catch { return; }
        }

        private void butUndo_Click(object sender, EventArgs e)
        {
            try
            {
                this.grWaitingList.Visible = true;
                this.grPrevious.Visible = false;
                this.EnableField(true);
                this.CleanerFieldALL();
                this.EnableButton(true);
                this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }
            catch
            {
                return;
            }
        }

        public void LoadListPatientWaitingCompleted(int iStatus)
        {
            SystemParameterInf objSys = SystemParameterBLL.ObjParameter(506);
            if (objSys != null && objSys.RowID > 0)
            {
                this.gridControl_WaitingList.DataSource = PatientReceiveBLL.TableWaitingServiceImmunization(dtfrom.Value, dtto.Value, iStatus, departmentCode, objSys.Values, iMenu);
                if (iStatus == 0)
                    this.col_List_ImmunizationDate.Visible = false;
                else
                    this.col_List_ImmunizationDate.Visible = true;
            }
        }

        private void butContinues_Click(object sender, EventArgs e)
        {
            try
            {
                this.grWaitingList.Visible = true;
                this.grWaitingList.Dock = DockStyle.Fill;
                this.grPrevious.Visible = false;
                this.grPrevious.Dock = DockStyle.None;
                this.EnableField(true);
                this.CleanerFieldALL();
                this.LoadGeneral();
                this.dtMedicalRecord_Material.Clear();
                this.gridControl_Material.DataSource = this.dtMedicalRecord_Material;
                this.butReload_Click(sender, e);
            }
            catch { }
        }

        private void LoadGeneral()
        {
            ///Theo nguyen tac tu truc
            //this.repSearch_Out_ItemCode.DataSource = ItemsBLL.ListItemsRef(0, departmentCode, 3);
            //this.repSearch_Out_ItemCode.DisplayMember = "ItemName";
            //this.repSearch_Out_ItemCode.ValueMember = "ItemCode";
            ///Theo nguyen tac duyet toa
            this.repSearch_Out_ItemCode.DataSource = Utils.ListToDataTable(ItemsBLL.ListItemsRef(0, departmentCode, 2));
            this.repSearch_Out_ItemCode.DisplayMember = "ItemName";
            this.repSearch_Out_ItemCode.ValueMember = "ItemCode";
        }

        private void checkWaiting_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkWaiting.Checked)
            {
                this.LoadListPatientWaitingCompleted(0);
                this.chkTheEnd.Enabled = false;
            }
        }

        private void CheckDoing_CheckedChanged(object sender, EventArgs e)
        {
            if(this.CheckDoing.Checked)
            {
                this.LoadListPatientWaitingCompleted(1);
                this.chkTheEnd.Enabled = true;
            }
        }    
        
        private void gridView_WaitingList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_WaitingList.RowCount > 0)
                {
                    if (this.gridView_WaitingList.GetFocusedRow() != null)
                    {
                        this.gridControl_PreviousList.Visible = true;
                        this.CleanerFieldALL();

                        this.grWaitingList.Visible = false;
                        this.grWaitingList.Dock = DockStyle.None;
                        this.grPrevious.Visible = true;
                        this.grPrevious.Dock = DockStyle.Fill;

                        this.patientReceiveID = Convert.ToDecimal(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_RefID).ToString());
                        this.receiptID = Convert.ToDecimal(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_ReceiptID).ToString());
                        this.referenceCode = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_ReferenceCode).ToString();
                        this.immunizationRecordCode = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_ImmunizationRecordCode).ToString();
                        this.patientCode = ISDBNULL2STRING(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_PatientCode).ToString(), string.Empty);
                        this.serviceCode = ISDBNULL2STRING(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_ServiceCode).ToString(), string.Empty);
                        this.serviceName = ISDBNULL2STRING(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_ServiceName).ToString(), string.Empty);
                        this.status = ISDBNULL2INT32(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_Status), 0);
                        this.iObjectCode = Convert.ToInt32(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_ObjectCode));
                        
                        string name = ISDBNULL2STRING(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_PatientName).ToString(), string.Empty);
                        string gender = ISDBNULL2STRING(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_GenderName).ToString(), string.Empty);
                        string year = ISDBNULL2STRING(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_PatientBirthyear).ToString(), string.Empty);
                        DateTime dtimeTemp = Convert.ToDateTime(this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, col_List_ImmunizationDate).ToString());
                        this.lbInfo.Text = "Tiêm chủng Vaccines: " + serviceName + " - Phòng: " + departmentName;

                        List<PatientReceiveInf> lstReceive = PatientReceiveBLL.ListPatientReceive(patientReceiveID);
                        iPatientType = lstReceive[0].PatientType;
                        this.txtTiensubenh.Text = lstReceive[0].MedicalHistory;
                        this.txtDiung.Text = lstReceive[0].Allergy;
                        this.memoLydokham.Text = lstReceive[0].Reason;
                        if (this.status == 1 || this.status == 2)
                            this.dtimeWorking = dtimeTemp;
                        else
                            this.dtimeWorking = Utils.DateTimeServer();
                        if (this.status == 1)
                        {
                            this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                            this.butEdit.Enabled = this.butUndo.Enabled = true;
                        }
                        else if (this.status == 0)
                        {
                            List<SurviveSignInf> lstSign = SurviveSignBLL.ListSurviveSignForRefCode(referenceCode, patientReceiveID, patientCode);
                            if (lstSign != null && lstSign.Count > 0)
                            {
                                this.txtMach.Text = lstSign[0].Pulse;
                                this.txtNhietdo.Text = lstSign[0].Temperature;
                                this.txtHuyetap.Text = lstSign[0].BloodPressure;
                                this.txtHuyetap1.Text = lstSign[0].BloodPressure1;
                                this.txtNang.Text = lstSign[0].Weight;
                                this.txtCao.Text = lstSign[0].Hight;
                            }
                        }
                        if (this.iObjectCode == 1)
                        {
                            List<BHYTInf> lstBHYT = new List<BHYTInf>();
                            lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(this.patientReceiveID);
                            if (lstBHYT.Count > 0)
                            {
                                sTheBHYT = lstBHYT[0].Serial;
                                lbSothe.Text = lstBHYT[0].Serial;
                                lbTungay.Text = lstBHYT[0].StartDate.ToString("dd/MM/yyyy");
                                iTraituyen = lstBHYT[0].TraiTuyen;
                                if (iTraituyen == 1)
                                    chkTraiTuyen.Checked = true;
                                else
                                    chkTraiTuyen.Checked = false;
                                this.lbNoiDKKCB.Text = lstBHYT[0].KCBBDCode.ToString();
                                this.lbDenngay.Text = lstBHYT[0].EndDate.ToString("dd/MM/yyyy");
                                this.GetCardInfo(lstBHYT[0].Serial);
                                this.VisableBHYT(true);
                            }
                        }
                        else
                        {
                            lbTileBHYT.Text = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_ObjectName).ToString();
                            this.VisableBHYT(false);
                        }
                        this.GetTableMaterial();
                        if (this.dtMedicalRecord_Material.Rows.Count > 0)
                        {
                            realMedicinesID = Convert.ToDecimal(this.dtMedicalRecord_Material.Rows[0][0].ToString());
                        }
                        
                        this.GetInfoPatient();
                        this.GetHistoryPatient();
                        this.ProcessBMI();
                        ///this.TotalMoney();
                        if (this.status == 2)
                            this.chkTheEnd.Checked = true;
                        else
                            this.chkTheEnd.Checked = false;
                        this.gridView_PreviousList_Click(sender, e);
                    }
                    else
                        return;
                }
                else
                    return;
            }
            catch
            {
                return;
            }
        }

        private void GetTableMaterial()
        {
            try
            {
                //// Lay thuoc tu truc
                //this.dtMedicalRecord_Material = RealMedicinesForPatientsBLL.DTRealMedicines(this.immunizationRecordCode, this.iObjectCode, this.departmentCode, 3, this.dtimeWorking);
                //this.gridControl_Material.DataSource = this.dtMedicalRecord_Material;

                ////Lay don thuoc tu ke toa thuoc
                this.dtMedicalRecord_Material = MedicalRecord_BLL.DTMedicalRecord(this.medicalRecordCode, this.iObjectCode, this.departmentCode, 2, true, this.typeMedical);
                this.gridControl_Material.DataSource = dtMedicalRecord_Material;
            }
            catch { return; }
        }

        private void gridView_PreviousList_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView_PreviousList.RowCount > 0)
                {
                    if (this.gridView_PreviousList.GetFocusedRow() != null)
                    {
                        this.immunizationRecordDetailCode = this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.colHis_ImmunizationRecordDetailCode).ToString();
                        this.medicalRecordCode = this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.colHis_MedicalRecordCode).ToString();
                        ////this.txtSolo.Text = this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.colHis_LotNo).ToString();
                        int dayTimesCome = Convert.ToInt32(this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.colHis_DayTimesCome).ToString());
                        int dayTimes = Convert.ToInt32(this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.colHis_DayTimes).ToString());
                        string chkWarning = this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.colHis_Warning).ToString();
                        if (!this.CheckCompleted.Checked)
                        {
                            if (this.dtimeWorking.AddDays(dayTimes) > this.dtimeWorking && chkWarning.Equals("True"))
                            {
                                if (XtraMessageBox.Show(" Bệnh nhân đến tiêm mũi tiếp theo sớm hơn theo lịch!\n\t Có muốn tiếp tục tiêm? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                    return;
                            }
                        }
                        this.lkupLanTiem.EditValue = Convert.ToInt32(this.gridView_PreviousList.GetRowCellValue(this.gridView_PreviousList.FocusedRowHandle, this.colHis_RowIDDoseNo).ToString());
                        ImmunizationTimesEntryInf objEntry = ImmunizationTimesEntryBLL.ObjTimesEntry(this.serviceCode);
                        this.editExplain.Text = objEntry.Note;
                        ImmunizationRecordDetailInf objDetail = new ImmunizationRecordDetailInf();
                        objDetail = ImmunizationRecordBll.ObjImmunizationDetail(this.immunizationRecordDetailCode);
                        if (objDetail != null && !string.IsNullOrEmpty(objDetail.ImmunizationRecordDetailCode))
                        {
                            this.lkupLanTiem.EditValue = objDetail.RowIDDoseNo;
                            this.dtNgayHen.Text = objDetail.AppointmentDate;
                            this.memoNoidunghen.Text = objDetail.AppointmentContent;
                            this.txtGhichu.Text = objDetail.Note;
                            this.txtContent.RtfText = objDetail.Content;
                            this.immunizationRecordDetailCode = objDetail.ImmunizationRecordDetailCode;
                            this.GetSurviveSign();
                            this.dtimeGiven = objDetail.DateGiven;
                            ///this.chkComplete.Enabled = true;
                        }
                        else
                        {
                            this.dtNgayHen.EditValue = this.dtimeWorking.AddDays(dayTimesCome);
                            this.memoNoidunghen.Text = string.Empty;
                            this.txtGhichu.Text = string.Empty;
                            this.txtContent.RtfText = string.Empty;
                            this.immunizationRecordDetailCode = string.Empty;
                            this.GetSurviveSign();
                            this.dtimeGiven = Utils.DateTimeServer();
                        }
                        this.lbInfo.Text = "Tiêm chủng Vaccines: " + serviceName + " - Phòng: " + departmentName;
                        if (iObjectCode == 1)
                        {
                            List<BHYTInf> lstBHYT = new List<BHYTInf>();
                            lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(patientReceiveID);
                            if (lstBHYT.Count > 0)
                            {
                                sTheBHYT = lstBHYT[0].Serial;
                                lbSothe.Text = lstBHYT[0].Serial;
                                lbTungay.Text = lstBHYT[0].StartDate.ToString("dd/MM/yyyy");
                                iTraituyen = lstBHYT[0].TraiTuyen;
                                if (iTraituyen == 1)
                                    chkTraiTuyen.Checked = true;
                                else
                                    chkTraiTuyen.Checked = false;
                                lbNoiDKKCB.Text = lstBHYT[0].KCBBDCode.ToString();
                                lbDenngay.Text = lstBHYT[0].EndDate.ToString("dd/MM/yyyy");
                                this.GetCardInfo(lstBHYT[0].Serial);
                                this.VisableBHYT(true);
                            }
                            this.lbTileBHYT.Text = this.gridView_WaitingList.GetRowCellValue(this.gridView_WaitingList.FocusedRowHandle, this.col_List_ObjectName).ToString();
                        }
                        else
                        {
                            this.VisableBHYT(false);
                        }
                        if (string.IsNullOrEmpty(this.immunizationRecordDetailCode))
                        {
                            this.butSave.Enabled = this.butUndo.Enabled = this.butCancel.Enabled = true;
                            this.butCancel.Enabled = this.butUndo.Enabled = this.butPrint.Enabled = this.butPrintVTTH.Enabled = this.butToaNhaThuoc.Enabled = this.butEdit.Enabled = false;
                            this.EnableField(false);
                            this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                            this.gridView_Material.OptionsBehavior.ReadOnly = false;
                            this.gridView_Material.OptionsBehavior.Editable = true;
                        }
                        else
                        {
                            this.butEdit.Enabled = this.butUndo.Enabled = this.butPrint.Enabled = this.butPrintVTTH.Enabled = this.butToaNhaThuoc.Enabled = this.butCancel.Enabled = true;
                            if (this.CheckCompleted.Checked)
                            {
                                this.butEdit.Enabled = false;
                                this.chkTheEnd.Enabled = false;
                            }
                            else
                                this.butEdit.Enabled = true;
                            this.butSave.Enabled = false;
                            this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                            this.gridView_Material.OptionsBehavior.ReadOnly = true;
                            this.gridView_Material.OptionsBehavior.Editable = false;
                        }
                        /// Dung cho tu truc
                        //this.dtMedicalRecord_Material = RealMedicinesForPatientsBLL.DTRealMedicines(this.immunizationRecordDetailCode, this.iObjectCode, this.departmentCode, 3, this.dtimeGiven);
                        //this.gridControl_Material.DataSource = dtMedicalRecord_Material;
                        /// Dung cho cap va duyet toa
                        this.GetTableMaterial();
                        this.ProcessBMI();
                        List<RealMedicinesForPatientsINF> lstMmedicines = new List<RealMedicinesForPatientsINF>();
                        lstMmedicines = RealMedicinesForPatientsBLL.ListForPatients(this.immunizationRecordDetailCode, this.patientReceiveID, this.patientCode);
                        if (lstMmedicines.Count > 0 && lstMmedicines[0].BanksAccountCode != string.Empty)
                            this.paid = 1;
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
            catch { return; }
        }

        private void GetCardInfo(string sCard)
        {
            try
            {
                string sMaBHYT = sCard.Substring(0, 2);
                RateBHYTInf model = RateBHYTBLL.objectRateBHYT(sMaBHYT);
                if (model != null || model.RateCard != string.Empty)
                {
                    if (chkTraiTuyen.Checked == true)
                        lbTileBHYT.Text = "BHYT " + model.RateFalse + "% ";
                    else
                        lbTileBHYT.Text = "BHYT " + model.RateTrue + "% ";
                }
            }
            catch { }
        }

        private void VisableBHYT(bool b)
        {
            lbSothe.Visible = b;
            lbTungay.Visible = b;
            chkTraiTuyen.Visible = b;
            lbNoiDKKCB.Visible = b;
            lbDenngay.Visible = b;
        }

        private void GetHistoryPatient()
        {
            try
            {
                ////this.gridControl_PreviousList.DataSource = ImmunizationRecordBll.ListImmunizationDetail(this.immunizationRecordCode);
                DataTable tableHistory = ImmunizationRecordBll.TableImmunizationHistoryTimes(this.serviceCode, this.immunizationRecordCode, this.patientReceiveID, this.patientCode);
                this.gridControl_PreviousList.DataSource = tableHistory;
                if (tableHistory != null && tableHistory.Rows.Count > 0)
                {
                    this.gridControl_PreviousList.DataSource = tableHistory;
                    if (!string.IsNullOrEmpty(this.immunizationRecordCode))
                    {
                        Int32 rowFocus = ImmunizationRecordBll.ListImmunizationDetail(this.immunizationRecordCode).Count;
                        this.gridView_PreviousList.FocusedRowHandle = rowFocus - 1;
                    }
                    else
                        this.gridView_PreviousList.FocusedRowHandle = 0;
                }
            }
            catch { }
        }

        private void GetInfoPatient()
        {
            try
            {
                PatientsInf objPatient = PatientsBLL.ObjPatients(this.patientCode, this.patientReceiveID);
                if (objPatient != null && objPatient.PatientCode != null)
                {
                    lbMabn01.Text = objPatient.PatientCode;
                    lbHoten01.Text = objPatient.PatientName;
                    lbNamsinh01.Text = objPatient.PatientBirthday.ToString().Substring(0, 10); //objPatient.PatientBirthyear.ToString();
                    lbTuoi01.Text = objPatient.PatientAge.ToString();
                    if (objPatient.PatientAge <= 3)
                        lbThang01.Text = objPatient.PatientMonth;
                    else
                    {
                        lbThang.Visible = false;
                        lbThang01.Visible = false;
                    }
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
        
        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView_PreviousList.RowCount > 0)
                {
                    if (gridView_PreviousList.GetFocusedRow() != null)
                    {
                        String _employeeCode = ISDBNULL2STRING(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, colHis_EmployeeCode).ToString(), string.Empty);
                        if (this.status == 2)
                        {
                            XtraMessageBox.Show(" Đợt tiêm chủng đã kết thúc! Không được phép xóa hoặc sửa.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else ///if (!string.IsNullOrEmpty(_employeeCode) && _employeeCode == this.s_uSerid)
                        {
                            //if (this.paid == 1)
                            //{
                            //    this.gridControl_PreviousList.Visible = true;
                            //    this.EnableField(false);
                            //    this.butSave.Enabled = this.butUndo.Enabled = this.butCancel.Enabled = true;
                            //    this.butPrint.Enabled = this.butPrintVTTH.Enabled = this.butEdit.Enabled = false;
                            //    this.gridView_Material.OptionsBehavior.ReadOnly = true;
                            //    this.gridView_Material.OptionsBehavior.Editable = false;
                            //    this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                            //    this.gridView_Material.OptionsBehavior.ReadOnly = true;
                            //    this.gridView_Material.OptionsBehavior.Editable = false;
                            //}
                            this.gridControl_PreviousList.Visible = true;
                            this.EnableField(false);
                            this.butSave.Enabled = this.butUndo.Enabled = true;
                            this.butPrint.Enabled = this.butPrintVTTH.Enabled = this.butEdit.Enabled = this.butToaNhaThuoc.Enabled = false;
                            this.gridView_Material.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                            this.gridView_Material.OptionsBehavior.ReadOnly = false;
                            this.gridView_Material.OptionsBehavior.Editable = true;
                            if (this.immunizationRecordDetailCode == string.Empty)
                                this.butPrint.Enabled = this.butPrintVTTH.Enabled = this.butEdit.Enabled = this.butCancel.Enabled = this.butToaNhaThuoc.Enabled = false;
                        }
                        //else
                        //{
                        //    XtraMessageBox.Show(" Khác bác sĩ tiêm chủng không cho phép sửa, xóa! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    return;
                        //}
                    }
                    else
                    {
                        XtraMessageBox.Show(" Chọn đợt tiêm chủng cần sửa lại thông tin! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Bệnh nhân chưa có thực hiện đợt tiêm chủng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private void butReload_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.checkWaiting.Checked == true)
                {
                    this.LoadListPatientWaitingCompleted(0);
                }
                else if (this.CheckDoing.Checked == true)
                {
                    this.LoadListPatientWaitingCompleted(1);
                }
                else if (this.CheckCompleted.Checked == true)
                {
                    this.LoadListPatientWaitingCompleted(2);
                }
                this.EnableButton(true);
            }
            catch
            {
                return;
            }
        }

        private void frmImmunization_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F5: butReload_Click(sender, e); break;                    //F5 - Refresh
                    case Keys.F1: butContinues_Click(sender, e); break;                 //F1 - Bệnh nhân tiếp
                    case Keys.F3: butSave_Click(sender, e); break;                    //F3 - Lưu
                    case Keys.F6: butPrint_Click(sender, e); break;                   //F6 - In toa
                }
            }
            catch
            {
                return;
            }
        }

        private void ref_Material_ItemCode_EditValueChanged(object sender, EventArgs e)
        {
        //    try
        //    {
        //        LookUpEdit LEdit = sender as LookUpEdit;
        //        decimal dUnitPrice = 0;
        //        if (iObjectCode == 1)
        //            dUnitPrice = Convert.ToDecimal(LEdit.GetColumnValue("BHYTPrice"));
        //        else
        //            dUnitPrice = Convert.ToDecimal(LEdit.GetColumnValue("SalesPrice"));
        //        DataRow r = Utils.GetPriceRowbyCode(dtMedicalRecord_Material, "ItemCode='" + LEdit.GetColumnValue("ItemCode").ToString() + "'");
        //        if (r != null)
        //        {
        //            XtraMessageBox.Show(" Thuốc đã được kê trong trong phiếu!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            this.gridView_Material.SetFocusedRowCellValue(col_Material_ItemCode, null);
        //            this.gridView_Material.SetFocusedRowCellValue(col_Material_Quantity, 0);
        //        }
        //        else
        //        {
        //            if (Convert.ToDecimal(LEdit.GetColumnValue("AmountEnd").ToString()) <= Convert.ToDecimal(LEdit.GetColumnValue("SafelyQuantity").ToString()))
        //            {
        //                if (XtraMessageBox.Show(" Số lượng thuốc trong kho sắp hết!\t\n Bạn có muốn tiếp tục kê thuốc không? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
        //                {
        //                    gridView_Material.SetFocusedRowCellValue(col_Material_UnitOfMeasureCode, LEdit.GetColumnValue("UnitOfMeasureCode"));
        //                    gridView_Material.SetFocusedRowCellValue(col_Material_UnitPrice, dUnitPrice);
        //                    gridView_Material.SetFocusedRowCellValue(col_Material_Quantity, 1);
        //                    gridView_Material.SetFocusedRowCellValue(col_Material_Amount, dUnitPrice);
        //                    gridView_Material.SetFocusedRowCellValue(col_Material_RateBHYT, LEdit.GetColumnValue("RateBHYT"));
        //                    gridView_Material.SetFocusedRowCellValue(col_Material_RepositoryCode, LEdit.GetColumnValue("RepositoryCode"));
        //                    gridView_Material.SetFocusedRowCellValue(col_Material_RepositoryName, LEdit.GetColumnValue("RepositoryName"));
        //                    gridView_Material.SetFocusedRowCellValue(col_Material_ObjectCode, iObjectCode);
        //                    gridView_Material.SetFocusedRowCellValue(col_Material_ItemName, LEdit.GetColumnValue("ItemName"));
        //                }
        //                return;
        //            }
        //            else if (Convert.ToDecimal(LEdit.GetColumnValue("AmountEnd").ToString()) == 0)
        //            {
        //                XtraMessageBox.Show(" Thuốc trong kho đã hết!\t\n Xin vui lòng kê thuốc khác ? ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                return;
        //            }
        //            else
        //            {
        //                gridView_Material.SetFocusedRowCellValue(col_Material_UnitOfMeasureCode, LEdit.GetColumnValue("UnitOfMeasureCode"));
        //                gridView_Material.SetFocusedRowCellValue(col_Material_UnitPrice, dUnitPrice);
        //                gridView_Material.SetFocusedRowCellValue(col_Material_Quantity, 1);
        //                gridView_Material.SetFocusedRowCellValue(col_Material_Amount, dUnitPrice);
        //                gridView_Material.SetFocusedRowCellValue(col_Material_RateBHYT, LEdit.GetColumnValue("RateBHYT"));
        //                gridView_Material.SetFocusedRowCellValue(col_Material_RepositoryCode, LEdit.GetColumnValue("RepositoryCode"));
        //                gridView_Material.SetFocusedRowCellValue(col_Material_RepositoryName, LEdit.GetColumnValue("RepositoryName"));
        //                gridView_Material.SetFocusedRowCellValue(col_Material_ObjectCode, iObjectCode);
        //                gridView_Material.SetFocusedRowCellValue(col_Material_ItemName, LEdit.GetColumnValue("ItemName"));
        //            }
        //        }
        //        gridControl_Material.DataSource = dtMedicalRecord_Material;
        //    }
        //    catch { }
        }

        private void ProcessBMI()
        {
            try
            {
                double do_BMI = 0;
                double do_W = 0;
                double do_H = 0;
                string strThumuc = Directory.GetCurrentDirectory();
                if (!string.IsNullOrEmpty(txtNang.Text.Trim()) && !string.IsNullOrEmpty(txtCao.Text.Trim()))
                {
                    do_W = Convert.ToDouble(txtNang.Text.Trim());
                    do_H = Convert.ToDouble(txtCao.Text.Trim()) / 100;
                    do_BMI = do_W / (do_H * do_H);
                    if (do_BMI < 18)
                    {
                        //lbBMI.Text = Math.Round(do_BMI, 1).ToString() + "\n : Người gầy.";
                        lbBMI.Text = "( " + Math.Round(do_BMI, 1).ToString() + " )";
                        string path_image = strThumuc + "\\BMI\\H1.jpg";
                        pictureBMI.Image = Image.FromFile(path_image);
                    }
                    else if (do_BMI >= 18 && do_BMI <= 24.9)
                    {
                        //lbBMI.Text = Math.Round(do_BMI, 1).ToString() + " : Người bình thường.";
                        lbBMI.Text = "( " + Math.Round(do_BMI, 1).ToString() + " )";
                        string path_image = strThumuc + "\\BMI\\H2.jpg";
                        pictureBMI.Image = Image.FromFile(path_image);
                    }
                    else if (do_BMI >= 25 && do_BMI <= 29.9)
                    {
                        //lbBMI.Text = Math.Round(do_BMI, 1).ToString() + " : Người béo phì độ I.";
                        lbBMI.Text = "( " + Math.Round(do_BMI, 1).ToString() + " )";
                        string path_image = strThumuc + "\\BMI\\H3.jpg";
                        pictureBMI.Image = Image.FromFile(path_image);
                    }
                    else if (do_BMI >= 30 && do_BMI <= 34.9)
                    {
                        //lbBMI.Text = Math.Round(do_BMI, 1).ToString() + " : Người béo phì độ II.";
                        lbBMI.Text = "( " + Math.Round(do_BMI, 1).ToString() + " )";
                        string path_image = strThumuc + "\\BMI\\H4.jpg";
                        pictureBMI.Image = Image.FromFile(path_image);
                    }
                    else if (do_BMI > 35 && do_BMI <= 39.9)
                    {
                        //lbBMI.Text = Math.Round(do_BMI, 1).ToString() + "\n : Người béo phì độ III.";
                        lbBMI.Text = "( " + Math.Round(do_BMI, 1).ToString() + " )";
                        string path_image = strThumuc + "\\BMI\\H5.jpg";
                        pictureBMI.Image = Image.FromFile(path_image);
                    }
                    else if (do_BMI >= 40)
                    {
                        //lbBMI.Text = Math.Round(do_BMI, 1).ToString() + "\n : Người béo phì độ III.";
                        lbBMI.Text = "( " + Math.Round(do_BMI, 1).ToString() + " )";
                        string path_image = strThumuc + "\\BMI\\H6.jpg";
                        pictureBMI.Image = Image.FromFile(path_image);
                    }
                }
            }
            catch { }
        }

        private void txtNang_Validated(object sender, EventArgs e)
        {
            if (!Utils.IsNumber(txtNang.Text.Trim()))
            {
                XtraMessageBox.Show(" Cân nặng phải nhập số!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtNang.Focus();
                return;
            }
            else
            {
                this.ProcessBMI();
            }
        }

        private void txtMach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtHuyetap.Focus();
                //SendKeys.Send("{Tab}{F4}");
            }
        }

        private void txtNhietdo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //SendKeys.Send("{Tab}{F4}");
                txtCao.Focus();
            }
        }

        private void txtHuyetap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtHuyetap1.Focus();
                //SendKeys.Send("{Tab}{F4}");
            }
        }

        private void txtMach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHuyetap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHuyetap1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                txtNhietdo.Focus();
        }

        private void txtHuyetap1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNhietdo_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //SendKeys.Send("{Tab}{F4}");
                txtCao.Focus();
            }
        }

        private void txtNhietdo_Validated(object sender, EventArgs e)
        {
            if (!Utils.IsNumber(txtNhietdo.Text.Trim()))
            {
                XtraMessageBox.Show(" Nhiệt độ phải nhập số!", "Bệnh viện điện tử .NET");
                txtNhietdo.Focus();
                return;
            }
        }

        private void txtCao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtNang.Focus();
            }
        }

        private void txtCao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.txtContent.Focus();
                this.tabMain.SelectedTabPageIndex = 0;
            }
        }
        
        private void txtGhichu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.txtContent.Focus();
                this.tabMain.SelectedTabPageIndex = 0;
            }
        }
        
        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                String _employeeCode = ISDBNULL2STRING(gridView_PreviousList.GetRowCellValue(gridView_PreviousList.FocusedRowHandle, colHis_EmployeeCode).ToString(), string.Empty);
                if (this.immunizationRecordDetailCode != string.Empty && this.paid == 1)
                {
                    XtraMessageBox.Show(" Bệnh nhân thanh toán Thuốc - VTTH không cho phép xóa hoặc sửa! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (_employeeCode != this.s_uSerid)
                {
                    XtraMessageBox.Show(" Khác bác sĩ tiêm chủng, không cho phép xóa hoặc sửa! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (this.dtMedicalRecord_Material.Select("Status=1").Length > 0)
                {
                    XtraMessageBox.Show(" Có thuốc đã duyệt cho bệnh nhân. \n Hãy hủy duyệt toa thuốc trước khi hủy phiếu tiêm chủng.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (XtraMessageBox.Show("Bạn thật sự muốn hủy kết quả tiêm chủng này không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        if (this.status == 1)
                        {
                            if (ImmunizationRecordBll.DelImmunizationForMedical(this.immunizationRecordCode, this.s_uSerid, this.immunizationRecordDetailCode, this.patientReceiveID, this.medicalRecordCode) == 1)
                            {
                                XtraMessageBox.Show(" Hủy kết quả tiêm chủng thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.gridControl_PreviousList.Visible = true;
                                this.EnableField(true);
                                this.EnableButton(true);
                                this.GetHistoryPatient();
                            }
                            else
                            {
                                XtraMessageBox.Show(" Hủy kết quả tiêm chủng không thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.EnableField(true);
                                this.GetHistoryPatient();
                                return;
                            }
                        }
                        else
                        {
                            if (ImmunizationRecordBll.UpdStatusImmunizationRecord(this.s_uSerid, this.patientReceiveID, this.immunizationRecordCode) == 1)
                            {
                                XtraMessageBox.Show(" Hủy kết thúc điều trị tiêm chủng thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.butReload_Click(sender, e);
                            }
                            else
                            {
                                XtraMessageBox.Show(" Hủy kết thúc điều trị không thành công \n Kiểm tra lại thông tin đợt điều trị.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch { }
        }

        private void gridView_Material_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            int rowfocus = e.RowHandle;
            try
            {
                if (ISDBNULL2DECIMAL(Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_Material_Quantity)), 1) <= 0)
                {
                    e.Valid = false;
                    view.SetColumnError(col_Material_Quantity, "Số lượng yêu cầu lớn hơn 0 !");
                }
                //if (ISDBNULL2DECIMAL(Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_Material_UnitPrice)), 1) <= 0)
                //{
                //    e.Valid = false;
                //    view.SetColumnError(col_Material_UnitPrice, "Chưa khai đơn giá cho vật tư tiêu hao!");
                //}
                if (e.Valid)
                {
                    decimal dUnitPrice = Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_Material_UnitPrice));
                    decimal dQuantity = Convert.ToDecimal(view.GetRowCellValue(rowfocus, col_Material_Quantity));
                    gridView_Material.SetFocusedRowCellValue(col_Material_Amount, dQuantity * dUnitPrice);
                }
            }
            catch { }
        }

        private void gridView_Material_KeyPress(object sender, KeyPressEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "Quantity")
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '/')
                {
                    e.Handled = true;
                }
            }
        }

        private void gridView_Material_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa thuốc - VTTH đang chọn hay không?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        #region Tu Truc
                        //decimal tempRealID = Convert.ToDecimal(gridView_Material.GetRowCellValue(gridView_Material.FocusedRowHandle, col_Material_MedicalRecordCode).ToString());
                        //string tempItemCode = gridView_Material.GetRowCellValue(gridView_Material.FocusedRowHandle, col_Material_ItemCode).ToString();
                        //decimal tempRowID = Convert.ToDecimal(gridView_Material.GetRowCellValue(gridView_Material.FocusedRowHandle, col_Material_RowID).ToString());
                        //Int32 iResult = RealMedicinesForPatientsBLL.DelRealDetailForItems(tempRealID, tempItemCode, tempRowID);
                        //if (iResult >= 1)
                        //{
                        //    gridView_Material.DeleteSelectedRows();
                        //}
                        //else
                        //{
                        //    XtraMessageBox.Show("Thuốc đang chọn đã thanh toán, hoặc đã được duyệt! Không cho phép xóa!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    return;
                        //}
                        #endregion
                        
                        #region cap toa
                        Int32 statusTemp = Convert.ToInt32(this.gridView_Material.GetRowCellValue(this.gridView_Material.FocusedRowHandle, col_Material_Status).ToString());
                        decimal rowidDetail =0;
                        if (!string.IsNullOrEmpty(this.gridView_Material.GetRowCellValue(this.gridView_Material.FocusedRowHandle, col_Material_RowID).ToString()))
                            rowidDetail = Convert.ToDecimal(this.gridView_Material.GetRowCellValue(this.gridView_Material.FocusedRowHandle, col_Material_RowID).ToString());
                        if (rowidDetail != 0)
                        {
                            if (statusTemp == 0 && rowidDetail != 0)
                            {
                                if (MedicalRecord_BLL.DelMedicalRecordDetail(this.medicalRecordCode, rowidDetail,0) == 1)
                                {
                                    this.GetTableMaterial();
                                    return;
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show(" Thuốc đã được duyệt, không được xóa! Liên hệ kho dược hủy duyệt trước khi xóa.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                            this.gridView_Material.DeleteSelectedRows();
                        #endregion
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show("Lỗi phát sinh khi xóa thuốc", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void gridView_Material_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.WindowCaption = "Bệnh viện điện tử .NET";
            e.ErrorText = "Phiếu xuất thuốc thiếu thông tin!.\t\n - YES: Bổ sung thêm\t\n - NO: Xóa nhập lại\t\n";
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.immunizationRecordCode != string.Empty && this.immunizationRecordDetailCode != string.Empty)
                {
                    DataTable dtResult = new DataTable("Result");
                    dtResult = ImmunizationRecordBll.TableRptViewImmunization(this.immunizationRecordCode, this.patientReceiveID);

                    DataTable dtDetail = new DataTable("ResultDetail");
                    dtDetail = ImmunizationRecordBll.TableRptViewImmunizationDetail(this.immunizationRecordCode);

                    DataTable dtEmergencyDetail = new DataTable("ResultEmergencyDetail");
                    dtEmergencyDetail = RealMedicinesForPatientsBLL.DT_RealMedicinesEmergencyDetail(this.immunizationRecordDetailCode, this.patientCode, this.patientReceiveID, this.dtimeGiven);

                    DataSet dsTemp = new DataSet();
                    dsTemp.Tables.Add(dtResult);
                    dsTemp.Tables.Add(dtDetail);
                    dsTemp.Tables.Add(dtEmergencyDetail);
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptTiemChung.xml");
                    //Reports.rptTiemChung rpt = new Reports.rptTiemChung();
                    //rpt.DataSource = dsTemp;
                    //rpt.CreateDocument();
                    //rpt.ShowRibbonPreviewDialog();
                    Reports.rptTiemChung rptShow = new Reports.rptTiemChung();
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "TiemChung", "Tiêm chủng");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("Chọn đợt tiêm chủng từ danh sách để in phiếu Tiêm Chủng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butPrintVTTH_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.immunizationRecordCode != string.Empty && this.immunizationRecordDetailCode != string.Empty)
                {
                    DataTable dtResult = new DataTable("Result");
                    dtResult = ImmunizationRecordBll.TableRptViewImmunization(this.immunizationRecordCode, this.patientReceiveID);

                    DataTable dtDetail = new DataTable("ResultDetail");
                    dtDetail = ImmunizationRecordBll.TableRptViewImmunizationDetail(this.immunizationRecordCode);

                    DataTable dtEmergencyDetail = new DataTable("ResultEmergencyDetail");
                    //dtEmergencyDetail = RealMedicinesForPatientsBLL.DT_RealMedicinesEmergencyDetail(this.immunizationRecordDetailCode, this.patientCode, this.patientReceiveID, this.dtimeGiven);
                    dtEmergencyDetail = MedicalRecord_BLL.TableMedicalPrescriptionForImmuni(this.medicalRecordCode, this.patientCode, this.patientReceiveID);

                    DataSet dsTemp = new DataSet();
                    dsTemp.Tables.Add(dtResult);
                    dsTemp.Tables.Add(dtDetail);
                    dsTemp.Tables.Add(dtEmergencyDetail);
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptTiemChung.xml");
                    Reports.rptTiemChungVTTH rptShow = new Reports.rptTiemChungVTTH();
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "TiemChung_VTTH","Tiêm chủng - VTTH");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("Chọn đợt tiêm chủng từ danh sách để in phiếu Thuốc - VTTH!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_Material_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view.FocusedColumn.FieldName == "ItemCode" && view.ActiveEditor is SearchLookUpEdit)
                {
                    Text = view.ActiveEditor.Parent.Name;
                    DevExpress.XtraEditors.SearchLookUpEdit edit;
                    edit = (SearchLookUpEdit)view.ActiveEditor;
                    DataTable table = this.repSearch_Out_ItemCode.DataSource as DataTable;
                    cloneout = new DataView(table);
                    DataRow row = view.GetDataRow(view.FocusedRowHandle);
                    cloneout.RowFilter = "AmountEnd >0 ";
                    edit.Properties.DataSource = cloneout;
                }
            }
            catch { }
        }

        private void gridView_Material_HiddenEditor(object sender, EventArgs e)
        {
            if (cloneout != null)
            {
                cloneout.Dispose();
                cloneout = null;
            }
        }

        private void txtTiensubenh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void butToaNhaThuoc_Click(object sender, EventArgs e)
        {
            frmCapToaVe frm = new frmCapToaVe(this.departmentCode, this.s_uSerid, this.immunizationRecordDetailCode, this.patientCode, this.iPatientType, this.paid, this.patientReceiveID, iObjectCode, this.shiftWork, null, string.Empty, string.Empty, this.txtGhichu.Text.Trim(), this.dtimeWorking);
            frm.ShowDialog(this);
        }

        private void txtDiung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void memoLydokham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void lkupLanTiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtSolo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void dtNgayHen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void memoNoidunghen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                ///SendKeys.Send("{Tab}");
                this.txtGhichu.Focus();
            }
        }

        private void CheckCompleted_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CheckCompleted.Checked)
            {
                this.LoadListPatientWaitingCompleted(2);
                this.chkTheEnd.Enabled = true;
            }
        }

        private void btnCaptureDocument_Click(object sender, EventArgs e)
        {
            if (this.patientReceiveID == 0 || this.patientCode == string.Empty)
            {
                XtraMessageBox.Show("Chọn bệnh nhân để đính kèm văn bản, hình ảnh.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                ViewPopup.frmCaptureDocument frm = new frmCaptureDocument(this.patientReceiveID, this.patientCode);
                frm.ShowDialog();
            }
        }

        private void repSearch_Out_ItemCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
                string itemCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ItemCode").ToString();
                string activeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("Active").ToString();
                decimal amountEndTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("AmountEnd").ToString());
                decimal safelyQuantityTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("SafelyQuantity").ToString());
                string unitOfMeasureCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("UnitOfMeasureCode").ToString();
                string repositoryNameTemp = searchEdit.Properties.View.GetFocusedRowCellValue("RepositoryName").ToString();
                string repositoryCodeTemp = searchEdit.Properties.View.GetFocusedRowCellValue("RepositoryCode").ToString();
                decimal salesPriceTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("SalesPrice").ToString());
                decimal bhytPriceTemp = Convert.ToDecimal(searchEdit.Properties.View.GetFocusedRowCellValue("BHYTPrice").ToString());
                Int32 rateBHYTTemp = Convert.ToInt32(searchEdit.Properties.View.GetFocusedRowCellValue("RateBHYT").ToString());
                string itemNameTemp = searchEdit.Properties.View.GetFocusedRowCellValue("ItemName").ToString();
                decimal dUnitPrice = 0;
                if (iObjectCode == 1)
                    dUnitPrice = bhytPriceTemp;
                else
                    dUnitPrice = salesPriceTemp;
                Int32 statusTemp = 0;
                string itemCodeOld = this.gridView_Material.GetFocusedRowCellValue(this.col_Material_ItemCode).ToString();
                if (!string.IsNullOrEmpty(this.gridView_Material.GetFocusedRowCellValue(this.col_Material_Status).ToString()))
                    statusTemp = Convert.ToInt32(this.gridView_Material.GetFocusedRowCellValue(col_Material_Status));
                if (statusTemp > 0)
                {
                    this.gridView_Material.SetFocusedRowCellValue(col_Material_ItemCode, itemCodeOld);
                    XtraMessageBox.Show(" Thuốc đã duyệt không cho phép sửa hoặc xóa.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataRow r = Utils.GetPriceRowbyCode(dtMedicalRecord_Material, "ItemCode='" + itemCodeTemp + "'");
                if (r != null)
                {
                    XtraMessageBox.Show(" Thuốc đã được kê trong trong phiếu!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.gridView_Material.SetFocusedRowCellValue(col_Material_ItemCode, null);
                    this.gridView_Material.SetFocusedRowCellValue(col_Material_Quantity, 0);
                }
                else
                {
                    if (amountEndTemp <= safelyQuantityTemp)
                    {
                        if (XtraMessageBox.Show(" Số lượng thuốc trong kho sắp hết!\t\n Bạn có muốn tiếp tục kê thuốc không? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                        {
                            this.gridView_Material.SetFocusedRowCellValue(this.col_Material_UnitOfMeasureCode, unitOfMeasureCodeTemp);
                            this.gridView_Material.SetFocusedRowCellValue(this.col_Material_UnitPrice, dUnitPrice);
                            this.gridView_Material.SetFocusedRowCellValue(this.col_Material_Quantity, 1);
                            this.gridView_Material.SetFocusedRowCellValue(this.col_Material_Amount, dUnitPrice);
                            this.gridView_Material.SetFocusedRowCellValue(this.col_Material_RateBHYT, rateBHYTTemp);
                            this.gridView_Material.SetFocusedRowCellValue(this.col_Material_RepositoryCode, repositoryCodeTemp);
                            this.gridView_Material.SetFocusedRowCellValue(this.col_Material_RepositoryName, repositoryNameTemp);
                            this.gridView_Material.SetFocusedRowCellValue(this.col_Material_ObjectCode, this.iObjectCode);
                            this.gridView_Material.SetFocusedRowCellValue(this.col_Material_ItemName, itemNameTemp);
                            this.gridView_Material.SetFocusedRowCellValue(this.col_Material_Chon, 0);
                            this.gridView_Material.SetFocusedRowCellValue(this.col_Material_Status, 0);
                        }
                        return;
                    }
                    else if (amountEndTemp == 0)
                    {
                        XtraMessageBox.Show(" Thuốc trong kho đã hết!\t\n Xin vui lòng kê thuôc khác ? ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        this.gridView_Material.SetFocusedRowCellValue(this.col_Material_UnitOfMeasureCode, unitOfMeasureCodeTemp);
                        this.gridView_Material.SetFocusedRowCellValue(this.col_Material_UnitPrice, dUnitPrice);
                        this.gridView_Material.SetFocusedRowCellValue(this.col_Material_Quantity, 1);
                        this.gridView_Material.SetFocusedRowCellValue(this.col_Material_Amount, dUnitPrice);
                        this.gridView_Material.SetFocusedRowCellValue(this.col_Material_RateBHYT, rateBHYTTemp);
                        this.gridView_Material.SetFocusedRowCellValue(this.col_Material_RepositoryCode, repositoryCodeTemp);
                        this.gridView_Material.SetFocusedRowCellValue(this.col_Material_RepositoryName, repositoryNameTemp);
                        this.gridView_Material.SetFocusedRowCellValue(this.col_Material_ObjectCode, this.iObjectCode);
                        this.gridView_Material.SetFocusedRowCellValue(this.col_Material_ItemName, itemNameTemp);
                        this.gridView_Material.SetFocusedRowCellValue(this.col_Material_Chon, 0);
                        this.gridView_Material.SetFocusedRowCellValue(this.col_Material_Status, 0);
                    }
                }
                this.gridControl_Material.DataSource = dtMedicalRecord_Material;
            }
            catch { }
        }

        private void butHSBA_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.patientCode))
            {
                frmKB_HSBA frm = new frmKB_HSBA(this.patientCode);
                frm.Show();
            }
            else
            {
                XtraMessageBox.Show(" Chưa có thông tin mã bệnh nhân!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtContent_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DevExpress.XtraRichEdit.RichEditControl txt = (DevExpress.XtraRichEdit.RichEditControl)(sender);
                string auto = "", s1 = "", s2 = "", strSource = "";
                if (e.KeyChar == ' ')
                {
                    strSource = this.f_Get_AutoRichText(txt);
                    auto = this.SearchCharecter(strSource);
                    if (!string.IsNullOrEmpty(auto))
                    {
                        s1 = auto.Split('©')[0];
                        s2 = auto.Split('©')[1];
                        int start = txt.Document.CaretPosition.ToInt();
                        Document document = txt.Document;
                        document.BeginUpdate();
                        try
                        {
                            DocumentRange range = txt.Document.CreateRange(start - s2.Length, s2.Length);
                            string text = txt.Document.GetText(range);
                            document.Delete(range);
                            document.Replace(range, s1);
                            document.Selection = range;
                        }
                        catch
                        {
                        }
                        finally
                        {
                            document.EndUpdate();
                        }
                    }
                }
            }
            catch { }
        }

        private string f_Get_AutoRichText(DevExpress.XtraRichEdit.RichEditControl txt)
        {
            int iSelect = 0;
            int iStart = 0;
            int chieudai = 0;
            string str = "", strFind = "", strSource = "";
            strSource = txt.Text;
            strSource = strSource.Replace("\n", " ");
            strSource = strSource.Replace("\r", " ");
            strSource = strSource.Replace("\t", " ");
            iSelect = txt.Document.Selection.Start.ToInt();

            for (int i = iSelect - 1; i > 0; i--)
            {
                iStart = i;
                str = strSource.Substring(iStart, 1);
                if (str == " ")
                {
                    chieudai = iSelect - 1 - i;
                    strFind = txt.Text.Substring(iSelect - chieudai, chieudai);
                    break;
                }
            }
            try
            {
                if (strFind == "" && strFind.Length < 10) strFind = txt.Text;
            }
            catch
            {
                strFind = string.Empty;
            }
            return strFind;
        }

        private string SearchCharecter(string strsource)
        {
            string stemp = "";
            try
            {
                var v_Viettat = from p in this.listAbb where p.CharacterCode == strsource select new { p.CharacterName };
                stemp = v_Viettat.FirstOrDefault().CharacterName;
                strsource = strsource.ToLower().Trim();
                try
                {
                    stemp += "©" + strsource;
                }
                catch
                {
                    stemp = string.Empty;
                }
            }
            catch { }
            return stemp;
        }

        private void editExplain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.memoNoidunghen.Focus();
            }
        }

    }
}