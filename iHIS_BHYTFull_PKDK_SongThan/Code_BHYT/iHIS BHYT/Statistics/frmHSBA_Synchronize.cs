using System;
using System.IO;
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
using DevExpress.XtraRichEdit;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Statistics
{
    public partial class frmHSBA_Synchronize : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable dtResult;
        private string employeeCode = string.Empty;
        private DateTime dtWorking;
        
        public frmHSBA_Synchronize(string _employeeCode)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
        }

        private void frmHSBA_Synchronize_Load(object sender, EventArgs e)
        {
            try
            {
                this.slkupPatientType.Properties.DataSource = PatientTypeBLL.ListPatientType();
                this.slkupPatientType.Properties.DisplayMember = "TypeName";
                this.slkupPatientType.Properties.ValueMember = "RowID";
                this.dtWorking = Utils.DateTimeServer();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                
        private void butReload_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
            try
            {
                this.dtResult = HSBA_SynchronizeBLL.TableGet_KetQuaDieuTri(this.dllNgay.tungay.Text, this.dllNgay.denngay.Text, string.Empty, Convert.ToInt32(this.slkupPatientType.EditValue), this.chkConfirm.Checked ? 1 : 0);
                if (this.dtResult != null && this.dtResult.Rows.Count > 0)
                {
                    this.gridControl_result.DataSource = dtResult;
                }
                else
                {
                    XtraMessageBox.Show("Không có số liệu thống kê!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.gridControl_result.DataSource = null;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private const string keysUser = "powersoft";
        private const string keysCode = "hsba@vn";
        private const string hospitalCode = "ihistmh";
        
        private string SignMD5
        {
            get {
                return Utils.Md5Encrypt(keysUser + keysCode);
            }
        }
        private void butUpload_Click(object sender, EventArgs e)
        {
            try
            {                
                //XtraMessageBox.Show("Vui lòng cung cấp hosting và Domain cần upload HSBA online!", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return;
                string result = string.Empty;
                string signMD5 = Utils.Md5Encrypt(keysUser + keysCode);
                int error = 0;
                string patientCode = string.Empty;
                decimal patientReceiveID = -1;
                foreach (DataRow row in this.dtResult.Select("Chon=1", "Chon Desc"))
                {
                    patientReceiveID = Convert.ToDecimal(row["PatientReceiveID"].ToString());
                    patientCode = row["patientCode"].ToString();
                    HSBA_ObjMedicalrecordsInf objMedical = HSBA_SynchronizeBLL.ObjMedicalrecords(patientReceiveID, patientCode);
                    if (objMedical != null && !string.IsNullOrEmpty(objMedical.ObjPatientReceive.PatientReceiveID))
                    {
                        this.ClearData(patientReceiveID.ToString(), patientCode);
                        if ( this.SynchronizePatients(objMedical.ObjPatient, ref result) && this.SynchronizePatientReceive(objMedical.ObjPatientReceive, ref result))
                        {
                            if (!this.SynchronizeSuggested(objMedical.ListSuggested, ref result))
                            {
                                error = -1;
                                break;
                            }
                            if (objMedical.ListReceiveDocumentImage != null && objMedical.ListReceiveDocumentImage.Count > 0)
                            {
                                if (!this.SynchronizeReceiveDocumentImage(objMedical.ListReceiveDocumentImage, ref result))
                                {
                                    error = -2;
                                    break;
                                }
                            }
                            if (objMedical.ListMedicalRecord != null && objMedical.ListMedicalRecord.Count > 0)
                            {
                                if (!this.SynchronizeMedicalRecord(objMedical.ListMedicalRecord, ref result))
                                {
                                    error = -3;
                                    break;
                                }
                            }
                            if (objMedical.ListMedicalRecordDetail != null && objMedical.ListMedicalRecordDetail.Count > 0)
                            {
                                if (!this.SynchronizeMedicalRecordDetail(objMedical.ListMedicalRecordDetail, ref result))
                                {
                                    error = -4;
                                    break;
                                }
                            }
                            if (objMedical.ListServiceRadiologyEntry != null && objMedical.ListServiceRadiologyEntry.Count > 0)
                            {
                                if (!this.SynchronizeServiceRadiologyEntry(objMedical.ListServiceRadiologyEntry, ref result))
                                {
                                    error = -5;
                                    break;
                                }
                            }
                            if (objMedical.ListServiceRadiologyDetail != null && objMedical.ListServiceRadiologyDetail.Count > 0)
                            {
                                if (!this.SynchronizeServiceRadiologyDetail(objMedical.ListServiceRadiologyDetail, ref result))
                                {
                                    error = -6;
                                    break;
                                }
                            }
                            if (objMedical.ListSurgeries != null && objMedical.ListSurgeries.Count > 0)
                            {
                                if (!this.SynchronizeSurgeries(objMedical.ListSurgeries, ref result))
                                {
                                    error = -7;
                                    break;
                                }
                            }
                            if (objMedical.ListSurgicalCrew != null && objMedical.ListSurgicalCrew.Count > 0)
                            {
                                if (!this.SynchronizeSurgicalCrew(objMedical.ListSurgicalCrew, ref result))
                                {
                                    error = -8;
                                    break;
                                }
                            }
                            if (objMedical.ListLaboratoryEntry != null && objMedical.ListLaboratoryEntry.Count > 0)
                            {
                                if (!this.SynchronizeLaboratoryEntry(objMedical.ListLaboratoryEntry, ref result))
                                {
                                    error = -9;
                                    break;
                                }
                            }
                            if (objMedical.ListLaboratoryDetail != null && objMedical.ListLaboratoryDetail.Count > 0)
                            {
                                if (!this.SynchronizeLaboratoryDetail(objMedical.ListLaboratoryDetail, ref result))
                                {
                                    error = -10;
                                    break;
                                }
                            }
                            this.SynchronizeCreateUser(objMedical.ObjPatient, ref result);
                        }
                        HSBA_SynchronizeBLL.isUpdComfirmHSBA(patientReceiveID, patientCode);
                    }
                    else
                    {
                        error = -99;
                        result = "Hồ sơ điều trị chưa tồn tại.";
                        break;
                    }
                }
                if (error.Equals(-1) || error.Equals(-2) || error.Equals(-3) || error.Equals(-4) || error.Equals(-5) || error.Equals(-6) || error.Equals(-7) || error.Equals(-8) || error.Equals(-9) || error.Equals(-10))
                {
                    this.ClearData(patientReceiveID.ToString(), patientCode);
                    XtraMessageBox.Show(result + " MaBN:" + patientCode, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (error.Equals(-99))
                {
                    XtraMessageBox.Show(result + " MaBN:" + patientCode, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    XtraMessageBox.Show("Upload thông tin điều trị bệnh nhân lên hsba thành công.", "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadData();
                }
            }
            catch (Exception ex){
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearData(string patientReceiveID, string patientCode)
        {
            string result = string.Empty;
            //if (!string.IsNullOrEmpty(patientReceiveID) && !string.IsNullOrEmpty(patientCode))
            //{
            //    string temp = this.SignMD5;
            //    using (var sv = new WebServiceHSBA.WSHSBASoapClient())
            //    {
            //        result = sv.IClearData(this.SignMD5, patientReceiveID, patientCode, hospitalCode);
            //    }
            //    result = result + " - ClearData.";
            //}
        }

        private bool SynchronizePatients(hsba_PatientsInf obj, ref string refResult)
        {
            string result = string.Empty;
            if (obj != null && !string.IsNullOrEmpty(obj.PatientCode))
            {
                string temp = this.SignMD5;
                using (var sv = new WebServiceHSBA.WSHSBASoapClient())
                {
                    result = sv.IPatients(this.SignMD5, obj.PatientCode, obj.EThnicName, obj.CareerName, obj.NationalityName, obj.ProvincialName, obj.DistrictName, obj.WardName, obj.PatientAddress, obj.PatientName, obj.PatientGender, obj.PatientBirthDay, obj.PatientAge, obj.PatientMobile, obj.PatientEmail, obj.MedicalHistory, obj.Allergy, obj.PatientImage, obj.PatientMonth, hospitalCode);
                }
                refResult = result + " - SynchronizePatientReceive.";
                if (result.Substring(0, 1) == "0")
                    return true;
                else
                    return false;
            }
            return false;
        }

        private bool SynchronizePatientReceive(hsba_PatientReceiveInf obj, ref string refResult)
        {
            string result = string.Empty;
            if (obj != null && !string.IsNullOrEmpty(obj.PatientReceiveID))
            {
                string temp = this.SignMD5;
                using (var sv = new WebServiceHSBA.WSHSBASoapClient())
                {
                    result = sv.IPatientReceive(this.SignMD5, obj.PatientReceiveID, obj.PatientCode, obj.Reason, obj.InDate, obj.EmployeeName, obj.ObjectCode, obj.TypeReceiveID, obj.OutDate, obj.EThnicName, obj.CareerName, obj.NationalityName, obj.ProvincialName, obj.DistrictName, obj.WardName, obj.CompanyInfo, obj.PatientAddress, obj.IntroName, obj.OrderNumber, obj.DenominationName, obj.ObjectExemptedName, obj.ContentMedicalPattern, obj.Pulse, obj.Temperature, obj.BloodPressure, obj.BloodPressure1, obj.Weight_, obj.Hight, obj.Breath, obj.Serial, obj.KCBBDCode, obj.KCBBDName, obj.StartDate, obj.EndDate, obj.TraiTuyen, hospitalCode);
                }
                refResult = result + " - SynchronizePatientReceive.";
                if (result.Substring(0, 1) == "0")
                    return true;
                else
                    return false;
            }
            return false;
        }

        private bool SynchronizeSuggested(IList<hsba_SuggestedServiceReceiptInf> list, ref string refResult)
        {
            string result = string.Empty;
            if (list != null && list.Count > 0)
            {
                using (var sv = new WebServiceHSBA.WSHSBASoapClient())
                {
                    foreach (var v in list)
                    {
                        result = sv.ISuggestedReceipt(this.SignMD5, v.SuggestedReceiptID, v.PatientReceiveID, v.ServiceName, v.ServicePrice, v.DisparityPrice, v.UnitPriceRoot, v.PatientCode, v.Status_, v.Paid, v.EmployeeName, v.Note, v.ObjectCode, v.PatientType, v.WorkDate, v.OrderNumber, v.DepartmentNameOrder, v.DepartmentName, v.AmountExemption, v.Quantity, v.EmployeeNameDoctor, v.Content, v.UnitOfMeasureName, v.ServiceCategoryName, v.ServiceGroupName, v.ServiceModuleCode, hospitalCode);
                    }
                }
                refResult = result + " - SynchronizeSuggested.";
                if (result.Substring(0, 1) == "0")
                    return true;
                else
                    return false;
            }
            return false;
        }

        private bool SynchronizeReceiveDocumentImage(IList<hsba_ReceiveDocumentImageInf> list, ref string refResult)
        {
            string result = string.Empty;
            if (list != null && list.Count > 0)
            {
                using (var sv = new WebServiceHSBA.WSHSBASoapClient())
                {
                    foreach (var v in list)
                    {
                        result = sv.IReceiveDocumentImage(this.SignMD5, v.PatientReceiveID, v.Note, v.Image_, v.STT, hospitalCode);
                    }
                }
                refResult = result + " - SynchronizeReceiveDocumentImage.";
                if (result.Substring(0, 1) == "0")
                    return true;
                else
                    return false;
            }
            return false;
        }
        
        private bool SynchronizeMedicalRecord(IList<hsba_MedicalRecordInf> list, ref string refResult)
        {
            string result = string.Empty;
            if (list != null && list.Count > 0)
            {
                using (var sv = new WebServiceHSBA.WSHSBASoapClient())
                {
                    foreach (var v in list)
                    {
                        result = sv.IMedicalRecord(this.SignMD5, v.PatientReceiveID, v.MedicalRecordCode, v.DepartmentName, v.EmployeeName, v.DiagnosisName, v.DescriptionNode, v.PostingDate, v.AppointmentDate, v.Symptoms, v.ObjectCode, v.Advices, v.IDC10KT, v.TackleName, v.EmployeeNameDoctor, v.DiagnosisCustom, v.Treatments, v.Pulse, v.Temperature, v.BloodPressure, v.BloodPressure1, v.Weight_, v.Hight, v.Breath, v.AppointmentNote, v.SuggestedReceiptID, hospitalCode);
                    }
                }
                refResult = result + " - SynchronizeMedicalRecord.";
                if (result.Substring(0, 1) == "0")
                    return true;
                else
                    return false;
            }
            return false;
        }

        private bool SynchronizeMedicalRecordDetail(IList<hsba_MedicalRecordDetailInf> list, ref string refResult)
        {
            string result = string.Empty;
            if (list != null && list.Count > 0)
            {
                using (var sv = new WebServiceHSBA.WSHSBASoapClient())
                {
                    foreach (var v in list)
                    {
                        result = sv.IMedicalRecordDetail(this.SignMD5, v.PatientReceiveID, v.MedicalRecordCode, v.ItemName, v.DateOfIssues, v.Morning, v.Noon, v.Afternoon, v.Evening, v.Quantity, v.Instruction, v.UnitPrice, v.Amount, v.ObjectCode, v.DoseOf, v.DoseOfPills, v.ItemCategoryName, v.GroupName, v.UnitOfMeasureName, v.Active, v.ItemContent, hospitalCode);
                    }
                }
                refResult = result + " - SynchronizeMedicalRecordDetail.";
                if (result.Substring(0, 1) == "0")
                    return true;
                else
                    return false;
            }
            return false;
        }

        private bool SynchronizeServiceRadiologyEntry(IList<hsba_ServiceRadiologyEntryInf> list, ref string refResult)
        {
            string result = string.Empty;
            if (list != null && list.Count > 0)
            {
                using (var sv = new WebServiceHSBA.WSHSBASoapClient())
                {
                    foreach (var v in list)
                    {
                        string contentsHTML = string.Empty, conclusionHTML = string.Empty;
                        RichEditControl rtfContent = new RichEditControl();
                        RichEditControl rtfConclusion = new RichEditControl();
                        rtfContent.RtfText = v.Contents;
                        rtfConclusion.RtfText = v.Conclusion;
                        contentsHTML = rtfContent.HtmlText;
                        conclusionHTML = rtfConclusion.HtmlText;
                        result = sv.IServiceRadiologyEntry(this.SignMD5, v.RowID, v.PatientReceiveID, contentsHTML, conclusionHTML, v.Proposal, v.PostingDate, v.EmployeeName, v.EmployeeNameDoctor, v.ServiceGroupCode, v.Note, v.Diagnosis, v.ServiceName, v.SuggestedReceiptID, hospitalCode);
                    }
                }
                refResult = result + " - SynchronizeServiceRadiologyEntry.";
                if (result.Substring(0, 1) == "0")
                    return true;
                else
                    return false;
            }
            return false;
        }

        private bool SynchronizeServiceRadiologyDetail(IList<hsba_ServiceRadiologyDetailInf> list, ref string refResult)
        {
            string result = string.Empty;
            if (list != null && list.Count > 0)
            {
                using (var sv = new WebServiceHSBA.WSHSBASoapClient())
                {
                    foreach (var v in list)
                    {
                        result = sv.IServiceRadiologyDetail(this.SignMD5, v.RadiologyRowID, v.PatientReceiveID, v.Image_, hospitalCode);
                    }
                }
                refResult = result + " - SynchronizeServiceRadiologyDetail.";
                if (result.Substring(0, 1) == "0")
                    return true;
                else
                    return false;
            }
            return false;
        }

        private bool SynchronizeSurgeries(IList<hsba_SurgeriesInf> list, ref string refResult)
        {
            string result = string.Empty;
            if (list != null && list.Count > 0)
            {
                using (var sv = new WebServiceHSBA.WSHSBASoapClient())
                {
                    foreach (var v in list)
                    {
                        string contentsHTML = string.Empty;
                        RichEditControl rtfContent = new RichEditControl();
                        rtfContent.RtfText = v.Content;
                        contentsHTML = rtfContent.HtmlText;
                        result = sv.ISurgeries(this.SignMD5, v.PatientReceiveID, v.SurgeriesCode, v.DateOn, v.TimeOn, v.DateOut, v.TimeOut, v.ICD10On, v.ICD10Out, v.AnesthesiaName, v.ComplicationsName, v.SituationName, contentsHTML, v.Note, v.EmployeeName, v.ObjectCode, v.PatientType, v.DepartmentName, v.DiagnosisCustomOn, v.DiagnosisCustomOut, v.SuggestedReceiptID, hospitalCode);
                    }
                }
                refResult = result + " - SynchronizeSurgeries.";
                if (result.Substring(0, 1) == "0")
                    return true;
                else
                    return false;
            }
            return false;
        }

        private bool SynchronizeSurgicalCrew(IList<hsba_SurgicalCrewInf> list, ref string refResult)
        {
            string result = string.Empty;
            if (list != null && list.Count > 0)
            {
                using (var sv = new WebServiceHSBA.WSHSBASoapClient())
                {
                    foreach (var v in list)
                    {
                        result = sv.ISurgicalCrew(this.SignMD5, v.SurgeriesCode, v.PatientReceiveID, v.EmployeeName, v.PositionName, hospitalCode);
                    }
                }
                refResult = result + " - SynchronizeSurgicalCrew.";
                if (result.Substring(0, 1) == "0")
                    return true;
                else
                    return false;
            }
            return false;
        }

        private bool SynchronizeLaboratoryEntry(IList<hsba_LaboratoryEntryInf> list, ref string refResult)
        {
            string result = string.Empty;
            if (list != null && list.Count > 0)
            {
                using (var sv = new WebServiceHSBA.WSHSBASoapClient())
                {
                    foreach (var v in list)
                    {
                        result = sv.ILaboratoryEntry(this.SignMD5, v.PatientReceiveID, v.IDLaboratoryEntry, v.AppointmentDate, v.AppointmentNote, v.Conclusion, v.Proposal, v.PostingDate, v.ServiceCategoryName, v.IDTemplate, v.ObjectCode, v.EmployeeName, v.PostingDateResult, v.DepartmentNameOrder, v.OrderDate, v.EmployeeDoctorNameOrder, v.Status_, hospitalCode);
                    }
                }
                refResult = result + " - SynchronizeLaboratoryEntry.";
                if (result.Substring(0, 1) == "0")
                    return true;
                else
                    return false;
            }
            return false;
        }

        private bool SynchronizeLaboratoryDetail(IList<hsba_LaboratoryDetailInf> list, ref string refResult)
        {
            string result = string.Empty;
            if (list != null && list.Count > 0)
            {
                using (var sv = new WebServiceHSBA.WSHSBASoapClient())
                {
                    foreach (var v in list)
                    {
                        result = sv.ILaboratoryDetail(this.SignMD5, v.PatientReceiveID, v.IDLaboratoryEntry, v.ServiceName, v.UnitValues, v.ValuesEntry, v.ValuedFemale, v.ValuedMale, v.Normal, v.LaboratoryName, v.Serial, v.SuggestedReceiptID, hospitalCode);
                    }
                }
                refResult = result + " - SynchronizeLaboratoryDetail.";
                if (result.Substring(0, 1) == "0")
                    return true;
                else
                    return false;
            }
            return false;
        }
        private bool SynchronizeCreateUser(hsba_PatientsInf obj, ref string refResult)
        {
            string result = string.Empty;
            if (obj != null && !string.IsNullOrEmpty(obj.PatientCode))
            {
                string userID = hospitalCode + "_" + obj.PatientCode;
                using (var sv = new WebServiceHSBA.WSHSBASoapClient())
                {
                    result = sv.IsCreateUserLogin(this.SignMD5, userID, hospitalCode, obj.PatientGender, obj.PatientMobile, obj.PatientAddress, obj.ProvincialName, obj.DistrictName, obj.WardName, obj.PatientName);
                }
                refResult = result + " - SynchronizeCreateUser.";
                if (result.Substring(0, 1) == "0")
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}