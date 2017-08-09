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
using Ps.Clinic.ViewPopup;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using System.Globalization;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraCharts;

namespace Ps.Clinic.Entry
{
    public partial class frmPhongLuu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string s_userCode = string.Empty;
        private string spatientCode = string.Empty;
        private Int32 iStatus = 0, iPaid = 0, iPatientType = 0;
        private string sMedicalEmergency = string.Empty;
        private string bankCode = string.Empty;
        private DateTime dtReceive = new DateTime();
        private decimal dReceiveID = 0, dSuggestedID = 0;
        private string s_makp = string.Empty;
        private int iObjectCode = 0, iCheckCard = 0;
        private Int32 iMenu = 0;
        private string sTheBHYT = string.Empty, shiftWork = string.Empty;
        private int iTraituyen = 0;
        private string refCode = string.Empty;
        private DataTable dtICD10kemtheo = new DataTable("ICD10");
        private DataTable dtICD10rvkemtheo = new DataTable("ICD10rv");
        private DataTable dtSurviveSign = new DataTable();
        private List<SurviveSignInf> lstSign = new List<SurviveSignInf>();
        private DateTime dtWorking = new DateTime();
        public frmPhongLuu(string _makp, string suserCode, Int32 _iMenu, string _shiftWork, DateTime _dtWorking)
        {
            InitializeComponent();
            this.s_userCode = suserCode;
            this.s_makp = _makp;
            this.iMenu = _iMenu;
            this.shiftWork = _shiftWork;
            this.CleanerInfo();
            this.grWaitingList.Visible = true;
            this.grWaitingList.Dock = DockStyle.Fill;
            this.panelControl3.Visible = false;
            this.panelControl3.Dock = DockStyle.None;
            this.dtWorking = _dtWorking;
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
        
        public void LoadListPatientWaitingCompleted(int iStatus)
        {
            this.gridControl_WaitingList.DataSource = PatientReceiveBLL.DT_WaitingEmergency(iStatus, 2, this.s_makp, Convert.ToDateTime(this.dtimeFrom.EditValue.ToString()), Convert.ToDateTime(this.dtimeTo.EditValue.ToString()));
        }

        private void frmPhongLuu_Load(object sender, EventArgs e)
        {
            try
            {
                this.dtimeFrom.EditValue = this.dtimeTo.EditValue = Utils.DateServer();
                this.ref_Department.DataSource = DepartmentBLL.ListDepartment(string.Empty);
                this.ref_Department.ValueMember = "DepartmentCode";
                this.ref_Department.DisplayMember = "DepartmentName";
                List<SymptomsInf> lstSym = new List<SymptomsInf>();
                lstSym = SymptomsBLL.ListSymptoms(0);
                foreach (var v in lstSym)
                {
                    this.cbChandoan.Properties.Items.Add(v.SymptomsName);
                }
                lkXutri.Properties.DataSource = Tackle_BLL.ListTackle();
                lkXutri.Properties.DisplayMember = "TackleName";
                lkXutri.Properties.ValueMember = "TackleCode";
                lkKetquadieutri.Properties.DataSource = MedicalEmergencyBLL.lstResults();
                lkKetquadieutri.Properties.DisplayMember = "ResultsName";
                lkKetquadieutri.Properties.ValueMember = "RowID";
                List<AdvicesInf> lstAdvices = new List<AdvicesInf>();
                lstAdvices = AdvicesBLL.ListAdvices(0);
                foreach (var v in lstAdvices)
                {
                    cbLoidan.Properties.Items.Add(v.AdvicesName);
                }
                this.lkNhanbenh.Properties.DataSource = this.lkBacsi.Properties.DataSource = EmployeeBLL.ListEmployeeForPosition("3,4");
                this.lkBacsi.Properties.DisplayMember = "EmployeeName";
                this.lkBacsi.Properties.ValueMember = "EmployeeCode";
                this.lkNhanbenh.Properties.DisplayMember = "EmployeeName";
                this.lkNhanbenh.Properties.ValueMember = "EmployeeCode";
                dtICD10kemtheo.Columns.Add("RowID", typeof(Int32));
                dtICD10kemtheo.Columns.Add("DiagnosisName", typeof(string));
                dtICD10rvkemtheo.Columns.Add("RowID", typeof(Int32));
                dtICD10rvkemtheo.Columns.Add("DiagnosisName", typeof(string));
                List<DiagnosisInf> lstDia = DiagnosisBLL.ListDiagnosisName();
                lkupICD10.Properties.DataSource = lstDia;
                lkupICD10.Properties.DisplayMember = "DiagnosisName";
                lkupICD10.Properties.ValueMember = "DiagnosisCode";
                lkupICD10ktheo.Properties.DataSource = lstDia;
                lkupICD10ktheo.Properties.DisplayMember = "DiagnosisName";
                lkupICD10ktheo.Properties.ValueMember = "RowID";
                lkupBenhchinh.Properties.DataSource = lstDia;
                lkupBenhchinh.Properties.DisplayMember = "DiagnosisName";
                lkupBenhchinh.Properties.ValueMember = "DiagnosisCode";
                lkupBenhkemtheo.Properties.DataSource = lstDia;
                lkupBenhkemtheo.Properties.DisplayMember = "DiagnosisName";
                lkupBenhkemtheo.Properties.ValueMember = "RowID";
                this.LoadListPatientWaitingCompleted(1);
                this.EnableText(false);
                this.EnableButtonAll(true);
                this.GetStatistic();
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi phát sinh khi khám bệnh\t\n-Liên hệ admin để kiểm tra lỗi: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void EnableText(bool ena)
        {
            try
            {
                this.txtTiensubenh.Properties.ReadOnly = this.txtDiungthuoc.Properties.ReadOnly = this.txtLydokham.Properties.ReadOnly = !ena;
                txtNgayvv.ReadOnly = txtGiovv.ReadOnly = txtNhantu.Properties.ReadOnly = !ena;
                cbChandoan.Properties.ReadOnly = lkupICD10.Properties.ReadOnly = lkupICD10ktheo.Properties.ReadOnly = !ena;
                txtMach.Properties.ReadOnly = txtHuyetap.Properties.ReadOnly = txtHuyetap1.Properties.ReadOnly = txtNhietdo.Properties.ReadOnly = txtNang.Properties.ReadOnly = txtCao.Properties.ReadOnly = !ena;
                gridView_ICD10.OptionsBehavior.ReadOnly = ena;
                gridView_ICD10.OptionsBehavior.Editable = !ena;
                
                this.txtTrieuChung.Properties.ReadOnly = txtNguoithan.Properties.ReadOnly = txtHoten.Properties.ReadOnly = txtdiachi.Properties.ReadOnly = txtDienthoai.Properties.ReadOnly = this.memoTreatments.Properties.ReadOnly = !ena;
                lkNhanbenh.Properties.ReadOnly = !ena;
                txtNgayrv.ReadOnly = txtGiorv.ReadOnly = txtNgaydieutri.Properties.ReadOnly = lkKetquadieutri.Properties.ReadOnly = lkupBenhchinh.Properties.ReadOnly = lkupBenhkemtheo.Properties.ReadOnly = !ena;
                lkBacsi.Properties.ReadOnly = txtSoluutru.Properties.ReadOnly = lkXutri.Properties.ReadOnly = cbLoidan.Properties.ReadOnly = !ena;
                gridView_Benhkemtheo.OptionsBehavior.ReadOnly = ena;
                gridView_Benhkemtheo.OptionsBehavior.Editable = !ena;
            }
            catch { }
        }

        public void EnableButtonAll(bool b)
        {
            try
            {
                butNew.Enabled = b;
                butCancel.Enabled = false;
                butHSBA.Enabled = b;
                butSave.Enabled = butUndo.Enabled = butEdit.Enabled = butChiDinh.Enabled = butNhapSinhHieu.Enabled = butPrint.Enabled = butCapToa.Enabled = butXuatTuTruc.Enabled = !b;
            }
            catch { }
        }

        private decimal ParseQuantity(string qty)
        {
            decimal sl1 = 0;
            try
            {
                string[] arr;
                if (!string.IsNullOrEmpty(qty.Trim()))
                {
                    arr = qty.Trim().Split('/');
                    if (arr.Length == 2)
                    {
                        try
                        {
                            int tu = int.Parse(arr[0].Trim() == string.Empty ? "0" : arr[0].Trim());
                            int mau = int.Parse(arr[1].Trim() == string.Empty ? "1" : arr[1].Trim());
                            sl1 = (decimal)(tu * (1M) / mau);
                        }
                        catch { }
                    }
                    else
                        if (arr.Length > 0)
                        {
                            try
                            {
                                sl1 = decimal.Parse(arr[0].Trim() == string.Empty ? "0" : arr[0].Trim());
                            }
                            catch { }
                        }
                }
            }
            catch { }
            return sl1;
        }
        
        private void frmPhongLuu_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5: butReload_Click(sender, e); break;                //F5 - Refresh
                case Keys.F1: butContinues_Click(sender, e); break;             //F1 - Bệnh nhân tiếp
                case Keys.F2: butNew_Click(sender, e); break;                   //F2 - Khám
                case Keys.F3: butSave_Click(sender, e); break;                  //F3 - Lưu
                case Keys.F7: butHandPoint_Click(sender, e); break;             //F7 - Chỉ định CLS
                
            }
        }

        private void checkWaiting_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                butNew.Enabled = true;
                LoadListPatientWaitingCompleted(0);
            }
            catch
            {
                return;
            }
        }

        private void CheckCompleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                butNew.Enabled = false;
                LoadListPatientWaitingCompleted(1);
            }
            catch
            {
                return;
            }
        }

        private void butHandPoint_Click(object sender, EventArgs e)
        {
            frmChiDinhDichVu form = new frmChiDinhDichVu(dReceiveID, spatientCode, s_userCode, iObjectCode, sTheBHYT, iTraituyen, sMedicalEmergency, iPatientType, s_makp, this.s_userCode, string.Empty, this.shiftWork, this.dtWorking);
            form.ShowDialog();
        }

        private bool SaveMedical()
        {
            try
            {
                MedicalEmergencyINF modelRecord = new MedicalEmergencyINF();
                modelRecord.MedicalEmergencyCode = this.sMedicalEmergency;
                modelRecord.PatientCode = this.spatientCode;
                modelRecord.DepartmentCode = this.s_makp;
                modelRecord.EmployeeCode = this.s_userCode;
                modelRecord.DateOn = Utils.StringToDate(this.txtNgayvv.Text);
                modelRecord.TimeOn = this.txtGiovv.Text;
                modelRecord.ReceivePatientFrom = this.txtNhantu.Text.Trim();
                modelRecord.DiagnosisCode = this.cbChandoan.Text;
                if (this.lkupICD10.EditValue != null)
                    modelRecord.ICD10 = this.lkupICD10.EditValue.ToString();
                else
                    modelRecord.ICD10 = string.Empty;
                modelRecord.Family = this.txtNguoithan.Text.Trim();
                modelRecord.FamilyFullname = this.txtHoten.Text.Trim();
                modelRecord.FamilyAddress = this.txtdiachi.Text.Trim();
                modelRecord.FamilyMobile = this.txtDienthoai.Text.Trim();
                modelRecord.PatientReceivingNursing = this.lkNhanbenh.EditValue.ToString();
                modelRecord.PatientReceiveID = this.dReceiveID;
                modelRecord.PatientType = 2;
                modelRecord.ObjectCode = this.iObjectCode;
                modelRecord.Symptoms = this.txtTrieuChung.Text;
                modelRecord.Treatments = this.memoTreatments.Text;
                int iResult = MedicalEmergencyBLL.InsMedicalEmergency(modelRecord, ref sMedicalEmergency, dSuggestedID);
                if (iResult == 1)
                {
                    PatientsBLL.UpdPatients(this.txtTiensubenh.Text, this.txtTiensubenh.Text, this.spatientCode);
                    PatientReceiveBLL.UpdPatientReceiveForReason(this.dReceiveID, this.spatientCode, this.txtLydokham.Text.Trim());
                    MedicalRecord_BLL.DelDiagnosisEnclosed(sMedicalEmergency);
                    if (this.dtICD10kemtheo.Rows.Count > 0)
                    {
                        foreach (DataRow dr in this.dtICD10kemtheo.Rows)
                        {
                            MedicalRecord_BLL.InsDiagnosisEnclosed(Convert.ToDecimal(dr["RowID"].ToString()), sMedicalEmergency);
                        }
                    }

                    List<SurviveSignInf> lstSur = SurviveSignBLL.ListSurviveSignForRefCode(sMedicalEmergency, dReceiveID, spatientCode);
                    if (lstSur.Count > 0 && lstSur != null)
                    {
                        SurviveSignInf infsur = new SurviveSignInf();
                        infsur.RowID = lstSur[0].RowID;
                        infsur.PatientCode = spatientCode;
                        infsur.Pulse = txtMach.Text.Trim();
                        infsur.Temperature = txtNhietdo.Text.Trim();
                        infsur.BloodPressure = txtHuyetap.Text.Trim();
                        infsur.BloodPressure1 = txtHuyetap1.Text.Trim();
                        infsur.Weight = txtNang.Text.Trim();
                        infsur.Hight = txtCao.Text;
                        infsur.EmployeeCode = s_userCode;
                        infsur.RefID = dReceiveID;
                        infsur.ReferenceCode = sMedicalEmergency;
                        infsur.CreateDate = Utils.DateTimeServer();
                        SurviveSignBLL.InsSurviveSign(infsur);
                    }
                    else
                    {
                        SurviveSignInf infsur = new SurviveSignInf();
                        infsur.RowID = 0;
                        infsur.PatientCode = spatientCode;
                        infsur.Pulse = txtMach.Text.Trim();
                        infsur.Temperature = txtNhietdo.Text.Trim();
                        infsur.BloodPressure = txtHuyetap.Text.Trim();
                        infsur.BloodPressure1 = txtHuyetap1.Text.Trim();
                        infsur.Weight = txtNang.Text.Trim();
                        infsur.Hight = txtCao.Text.Trim();
                        infsur.EmployeeCode = s_userCode;
                        infsur.RefID = dReceiveID;
                        infsur.ReferenceCode = sMedicalEmergency;
                        infsur.CreateDate = Utils.DateTimeServer();
                        SurviveSignBLL.InsSurviveSign(infsur);
                    }
                    return true;
                }
                else
                {
                    XtraMessageBox.Show("Đã có lỗi thông tin lưu trữ \t\n Đề nghị xem lại thông tin khám bệnh.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch
            {
                XtraMessageBox.Show("Đã có lỗi thông tin lưu trữ \t\n Đề nghị xem lại thông tin khám bệnh.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public bool UpdateEmergencyOut()
        {
            try
            {
                if (!Utils.isDate(txtNgayrv.Text))
                {
                    XtraMessageBox.Show(" Ngày vào ra viện không hợp lệ ! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNgayrv.Focus();
                    return false;
                }
                if (!Utils.isHour(txtGiorv.Text))
                {
                    XtraMessageBox.Show(" Giờ ra viện không hợp lệ ! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtGiorv.Focus();
                    return false;
                }

                if (lkKetquadieutri.EditValue == null || lkKetquadieutri.Text.Trim().ToString() == string.Empty)
                {
                    XtraMessageBox.Show(" Chọn kết quả điều trị! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkKetquadieutri.Focus();
                    return false;
                }
                //if (lkupBenhchinh.EditValue == null || lkupBenhchinh.Text.Trim().ToString() == string.Empty)
                //{
                //    XtraMessageBox.Show(" Chẩn đoán ICD10 ra viện! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    this.lkKetquadieutri.Focus();
                //    return false;
                //}
                if (lkBacsi.EditValue == null || lkBacsi.Text.Trim().ToString() == string.Empty && this.CheckCompleted.Checked)
                {
                    XtraMessageBox.Show(" Bác sĩ điều trị! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkKetquadieutri.Focus();
                    return false;
                }
                if (lkXutri.EditValue == null || lkXutri.Text.Trim().ToString() == string.Empty)
                {
                    XtraMessageBox.Show(" Xử trí ra viện!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkKetquadieutri.Focus();
                    return false;
                }
                else
                {
                    string sEmergencyOut = string.Empty;
                    MedicalEmergencyOutINF modelOut = new MedicalEmergencyOutINF();
                    modelOut.MedicalEmergencyOutCode = string.Empty;
                    modelOut.DateOut = Utils.StringToDate(this.txtNgayrv.Text);
                    modelOut.TimeOut = this.txtGiorv.Text;
                    modelOut.TreatmentTime = Convert.ToInt32(this.txtNgaydieutri.Text);
                    modelOut.TreatmentResults = Convert.ToInt32(this.lkKetquadieutri.EditValue.ToString());
                    if (this.lkupBenhchinh.EditValue != null)
                        modelOut.ICD10Out = this.lkupBenhchinh.EditValue.ToString();
                    else
                        modelOut.ICD10Out = string.Empty;
                    modelOut.MedicalEmergencyCode = sMedicalEmergency;
                    modelOut.TreatingDoctor = this.lkBacsi.EditValue.ToString();
                    modelOut.NumberStorage = this.txtSoluutru.Text;
                    modelOut.EmployeeCode = this.s_userCode;
                    modelOut.TackleCode = Convert.ToInt32(this.lkXutri.EditValue.ToString());
                    modelOut.Advices = this.cbLoidan.Text;
                    modelOut.PatientReceiveID = dReceiveID;
                    modelOut.PatientCode = spatientCode;
                    if (this.checkWaiting.Checked)
                        modelOut.Status = 1;
                    else
                        modelOut.Status = 2;
                    if (MedicalEmergencyBLL.InsMedicalEmergencyOut(modelOut, ref sEmergencyOut) >= 1)
                    {
                        MedicalRecord_BLL.DelDiagnosisEnclosed(sEmergencyOut);
                        if (dtICD10rvkemtheo.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtICD10rvkemtheo.Rows)
                            {
                                MedicalRecord_BLL.InsDiagnosisEnclosed(Convert.ToDecimal(dr["RowID"].ToString()), sEmergencyOut);
                            }
                        }
                    }
                }
                return true;
            }
            catch { return false; }
            
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dReceiveID > 0)
                {
                    this.butEdit.Enabled = this.butNew.Enabled = false;
                    this.butSave.Enabled = this.butUndo.Enabled = this.butContinues.Enabled = this.butChiDinh.Enabled = this.butNhapSinhHieu.Enabled = this.butPrint.Enabled = this.butCapToa.Enabled = this.butXuatTuTruc.Enabled = true;
                    this.EnableText(true);
                }
            }
            catch
            {
                XtraMessageBox.Show("Bệnh nhân chưa qua đăng ký khám!\t\nChọn bệnh nhân khác hoặc yêu cầu qua đăng ký.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
        }

        private void butUndo_Click(object sender, EventArgs e)
        {
            try
            {
                this.gridControl_PreviousList.Visible = true;
                this.gridControl_PreviousList.Dock = DockStyle.Fill;
                this.butEdit.Enabled = this.butNew.Enabled = butContinues.Enabled = true;
                this.butSave.Enabled = this.butUndo.Enabled = butChiDinh.Enabled = butNhapSinhHieu.Enabled = butPrint.Enabled = butCapToa.Enabled = butXuatTuTruc.Enabled = false;
                this.EnableText(false);
                this.butNew.Enabled = false;
            }
            catch
            {
                return;
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Utils.isDate(this.txtNgayvv.Text))
                {
                    XtraMessageBox.Show(" Ngày vào viện không hợp lệ ! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNgayvv.Focus();
                    return;
                }
                if (!Utils.isHour(this.txtGiovv.Text))
                {
                    XtraMessageBox.Show(" Giờ vào viện không hợp lệ ! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtGiovv.Focus();
                    return;
                }
                if (this.cbChandoan.EditValue == null || this.cbChandoan.Text.Trim().ToString() == string.Empty)
                {
                    XtraMessageBox.Show(" Chẩn đoán vào viện! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbChandoan.Focus();
                    return;
                }
                //if (lkupICD10.EditValue == null || lkupICD10.Text.Trim().ToString() == string.Empty)
                //{
                //    XtraMessageBox.Show(" Nhập ICD10 khi vào viện! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    this.lkupICD10.Focus();
                //    return;
                //}
                if (this.lkNhanbenh.EditValue == null || this.lkNhanbenh.Text.Trim().ToString() == string.Empty)
                {
                    XtraMessageBox.Show(" Xác nhận người nhận bệnh!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkupICD10.Focus();
                    return;
                }
                if (this.SaveMedical())
                {
                    string stemp = this.txtNgayrv.Text.Trim();
                    if (this.txtNgayrv.Text.Trim() != "/  /" && this.txtGiorv.Text.Trim() != ":")
                    {
                        this.UpdateEmergencyOut();
                    }
                    XtraMessageBox.Show(" Hồ sơ bệnh án cập nhật thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.GetHistoryPatient(this.spatientCode);
                    this.EnableText(false);
                    this.butEdit.Enabled = this.butNew.Enabled = this.butSave.Enabled = this.butUndo.Enabled = false;
                    this.butContinues.Enabled = this.butChiDinh.Enabled = this.butNhapSinhHieu.Enabled = this.butPrint.Enabled = this.butCapToa.Enabled = this.butXuatTuTruc.Enabled = true;
                    if (this.txtNgayrv.Text.Trim() != "/  /" && this.txtGiorv.Text.Trim() != ":")
                    {
                        this.butEdit.Enabled = this.butNew.Enabled = this.butSave.Enabled = this.butChiDinh.Enabled = this.butNhapSinhHieu.Enabled = this.butXuatTuTruc.Enabled = false;
                        this.butUndo.Enabled = this.butContinues.Enabled = this.butPrint.Enabled = this.butCapToa.Enabled = true;
                    }
                    if (this.checkWaiting.Checked)
                    {
                        this.butXuatTuTruc.Enabled = this.butChiDinh.Enabled = true;
                        this.butUndo.Enabled = false;
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Hồ sơ bệnh án cập nhật thất bại! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch { }
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (dReceiveID > 0)
                {
                    if (iStatus == 0)
                    {
                        butSave.Enabled = butUndo.Enabled = true;
                        butNew.Enabled = false;
                        EnableText(true);
                        dtICD10kemtheo.Clear();
                        dtICD10rvkemtheo.Clear();
                        txtNhantu.Focus();
                        this.lkNhanbenh.EditValue = this.s_userCode;
                        this.lkBacsi.EditValue = this.s_userCode;
                        this.txtNgayrv.Text = Utils.DateServer().ToString("dd/MM/yyyy");
                        this.txtGiorv.Text = Utils.TimeServer();
                        this.txtNgaydieutri.Text = ((Utils.StringToDate(this.txtNgayrv.Text) - Utils.StringToDate(this.txtNgayvv.Text)).Days + 1).ToString();
                        this.lkKetquadieutri.EditValue = 2;
                        this.lkXutri.EditValue = 2;
                    }
                    else
                    {
                        XtraMessageBox.Show(" Bệnh nhân đã khám xong!\t\n Đề nghị bệnh nhân khám lại vào đợt sau. ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show("Bệnh nhân chưa qua đăng ký khám!\t\nChọn bệnh nhân khác hoặc yêu cầu qua đăng ký.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void butContinues_Click(object sender, EventArgs e)
        {
            grWaitingList.Visible = true;
            grWaitingList.Dock = DockStyle.Fill;

            panelControl3.Visible = false;
            panelControl3.Dock = DockStyle.None;

            grMain.Text = "Quản lý HSBA - Lưu Bệnh!";
            CleanerInfo();
            EnableButtonAll(true);
            butNew.Enabled = false;
            dtICD10kemtheo.Clear();
            if (checkWaiting.Checked == true)
            {
                LoadListPatientWaitingCompleted(0);
            }
            if (CheckCompleted.Checked == true)
            {
                LoadListPatientWaitingCompleted(1);
            }
            Bitmap b = new Bitmap("NoImgPatient.jpeg");
            picPatient.Image = (Bitmap)b;
        }

        public void CleanerInfo()
        {
            dReceiveID = dSuggestedID = 0;
            sMedicalEmergency = spatientCode = string.Empty;
            iObjectCode = 0; iCheckCard = 0;
            iStatus = iPaid = iPatientType = 0;
            sTheBHYT = string.Empty; iTraituyen = 0; refCode = string.Empty;
            txtNgayrv.Text = txtNgayvv.Text = "__/__/____"; 
            txtGiovv.Text = txtGiorv.Text = "__:__"; 
            txtNhantu.Text = string.Empty;
            cbChandoan.EditValue = lkupICD10.EditValue = lkupICD10ktheo.EditValue = null;
            txtMach.Text = txtHuyetap.Text = txtHuyetap1.Text = txtNhietdo.Text = txtNang.Text = txtCao.Text = string.Empty;
            gridControl_ICD10.DataSource = null;

            this.txtTiensubenh.Text = txtDiungthuoc.Text = this.txtTrieuChung.Text = this.memoTreatments.Text = string.Empty;
            txtNguoithan.Text = txtHoten.Text = txtdiachi.Text = txtDienthoai.Text = string.Empty;
            lkNhanbenh.EditValue = null;
            txtNgaydieutri.Text = "0"; lkKetquadieutri.EditValue = lkupBenhchinh.EditValue = lkupBenhkemtheo.EditValue = lkBacsi.EditValue = null;
            txtSoluutru.Text = string.Empty; lkXutri.EditValue = null; cbLoidan.EditValue = null;
            gridControl_Benhkemtheo.DataSource = null;
            dtICD10kemtheo.Clear();
            dtICD10rvkemtheo.Clear();
        }

        private void butReload_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkWaiting.Checked == true)
                {
                    this.LoadListPatientWaitingCompleted(0);
                }
                else if (CheckCompleted.Checked == true)
                {
                    this.LoadListPatientWaitingCompleted(1);
                }
                else if (CheckDone.Checked == true)
                {
                    this.LoadListPatientWaitingCompleted(2);
                }
            }
            catch
            {
                return;
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
                        this.grWaitingList.Visible = false;
                        this.grWaitingList.Dock = DockStyle.None;
                        this.panelControl3.Visible = true;
                        this.panelControl3.Dock = DockStyle.Fill;
                        this.dReceiveID = Convert.ToDecimal(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ReceiveID).ToString());
                        this.EnableText(false);
                        this.spatientCode = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientCode).ToString(), string.Empty);
                        this.iObjectCode = Int32.Parse(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectCode).ToString());
                        this.iCheckCard = Int32.Parse(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectCard).ToString());
                        this.iStatus = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_Status).ToString());
                        this.iPatientType = Convert.ToInt32(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_PatientType).ToString());
                        this.dSuggestedID = Convert.ToDecimal(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_SuggestedID).ToString());
                        this.sMedicalEmergency = ISDBNULL2STRING(gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_MedicalEmergencyCode).ToString(), string.Empty);
                        this.GetInfoPatient(this.spatientCode);
                        List<PatientReceiveInf> lstReceive = PatientReceiveBLL.ListPatientReceive(dReceiveID);
                        if (lstReceive.Count > 0 && lstReceive != null)
                            this.dtReceive = lstReceive[0].CreateDate;
                        DataTable dt = PatientReceiveBLL.DT_PatientWaitingEmergency(dReceiveID, dSuggestedID);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            refCode = dt.Rows[0]["ReferenceCode"].ToString();
                            txtTiensubenh.Text = dt.Rows[0]["MedicalHistory"].ToString();
                            txtDiungthuoc.Text = dt.Rows[0]["Allergy"].ToString();
                            txtLydokham.Text = dt.Rows[0]["Reason"].ToString();
                            
                            if (iStatus == 0)
                            {
                                txtMach.Text = dt.Rows[0]["Pulse"].ToString();
                                txtNhietdo.Text = dt.Rows[0]["Temperature"].ToString();
                                txtHuyetap.Text = dt.Rows[0]["BloodPressure"].ToString();
                                txtHuyetap1.Text = dt.Rows[0]["BloodPressure1"].ToString();
                                txtNang.Text = dt.Rows[0]["Weight"].ToString();
                                txtCao.Text = dt.Rows[0]["Hight"].ToString();
                            }
                        }
                        if (iObjectCode == 1)
                        {
                            List<BHYTInf> lstBHYT = new List<BHYTInf>();
                            lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(dReceiveID);
                            if (lstBHYT.Count > 0)
                            {
                                sTheBHYT = lstBHYT[0].Serial;
                                lbSothe.Text =lstBHYT[0].Serial;
                                lbTungay.Text =lstBHYT[0].StartDate.ToString("dd/MM/yyyy");
                                iTraituyen = lstBHYT[0].TraiTuyen;
                                this.chkTraiTuyen.Checked = iTraituyen == 1 ? true : false;
                                this.chkCapCuu.Checked = lstBHYT[0].Capcuu == 1 ? true : false;
                                this.chkGiayChuyenVien.Checked = lstBHYT[0].ReferralPaper == 1 ? true : false;
                                this.lbNoiDKKCB.Text = lstBHYT[0].Serial03.ToString() + "-" + lstBHYT[0].KCBBDCode.ToString();//lstBHYT[0].KCBBDCode.ToString();
                                this.lbDenngay.Text = lstBHYT[0].EndDate.ToString("dd/MM/yyyy");
                                this.GetCardInfo(lstBHYT[0].Serial);
                            }
                        }
                        else
                        {
                            this.lbTileBHYT.Text = gridView_WaitingList.GetRowCellValue(gridView_WaitingList.FocusedRowHandle, col_List_ObjectName).ToString();
                        }
                        if (iStatus == 1 || iStatus ==2)
                        {
                            List<SurviveSignInf> lstSur = SurviveSignBLL.ListSurviveSignForRefCode(sMedicalEmergency, dReceiveID, spatientCode);
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
                            MedicalEmergencyINF objEmergency = MedicalEmergencyBLL.ObjEmergency(sMedicalEmergency);
                            if (objEmergency != null && !string.IsNullOrEmpty(objEmergency.MedicalEmergencyCode))
                            {
                                this.txtNgayvv.Text = objEmergency.DateOn.ToString("dd/MM/yyyy");
                                this.txtGiovv.Text = objEmergency.TimeOn;
                                this.txtNhantu.Text = objEmergency.ReceivePatientFrom;
                                this.cbChandoan.Text = objEmergency.DiagnosisCode;
                                this.lkupICD10.EditValue = objEmergency.ICD10;
                                this.lkupBenhchinh.EditValue = objEmergency.ICD10;
                                this.txtNguoithan.Text = objEmergency.Family;
                                this.txtHoten.Text = objEmergency.FamilyFullname;
                                this.txtdiachi.Text = objEmergency.FamilyAddress;
                                this.txtDienthoai.Text = objEmergency.FamilyMobile;
                                this.lkNhanbenh.EditValue = objEmergency.PatientReceivingNursing;
                                this.txtTrieuChung.Text = objEmergency.Symptoms;
                                this.memoTreatments.Text = objEmergency.Treatments;
                                this.lkBacsi.EditValue = this.s_userCode;
                            }
                            dtICD10kemtheo = MedicalRecord_BLL.DT_MedicalRecordDiagnosisEnclosed(sMedicalEmergency);
                            gridControl_ICD10.DataSource = dtICD10kemtheo;
                            this.lkBacsi.EditValue = this.s_userCode;
                            MedicalEmergencyOutINF objEmergencyOut = MedicalEmergencyBLL.ObjEmergencyOut(sMedicalEmergency);
                            if (objEmergencyOut != null && objEmergencyOut.PatientReceiveID > 0)
                            {
                                this.txtNgayrv.Text = objEmergencyOut.DateOut.ToString("dd/MM/yyyy");
                                this.txtGiorv.Text = objEmergencyOut.TimeOut;
                                this.txtNgaydieutri.Text = objEmergencyOut.TreatmentTime.ToString();
                                this.lkKetquadieutri.EditValue = objEmergencyOut.TreatmentResults;
                                this.lkupBenhchinh.EditValue = objEmergencyOut.ICD10Out;
                                this.lkBacsi.EditValue = objEmergencyOut.TreatingDoctor;
                                this.txtSoluutru.Text = objEmergencyOut.NumberStorage.ToString();
                                this.lkXutri.EditValue = objEmergencyOut.TackleCode;
                                this.cbLoidan.Text = objEmergencyOut.Advices;
                            }
                            else
                            {
                                this.lkBacsi.EditValue = this.s_userCode;
                                this.txtNgayrv.Text = Utils.DateServer().ToString("dd/MM/yyyy");
                                this.txtGiorv.Text = Utils.TimeServer();
                                this.txtNgaydieutri.Text = ((Utils.StringToDate(this.txtNgayrv.Text) - Utils.StringToDate(this.txtNgayvv.Text)).Days + 1).ToString();
                                this.lkKetquadieutri.EditValue = 2;
                                this.lkXutri.EditValue = 2;
                            }
                            dtICD10rvkemtheo = MedicalRecord_BLL.DT_MedicalRecordDiagnosisEnclosed(objEmergencyOut.MedicalEmergencyOutCode);
                            gridControl_Benhkemtheo.DataSource = dtICD10rvkemtheo;
                            if (dtICD10rvkemtheo == null || dtICD10rvkemtheo.Rows.Count <= 0)
                                gridControl_Benhkemtheo.DataSource = dtICD10kemtheo;
                            if (iStatus == 1)
                            {
                                butContinues.Enabled = butUndo.Enabled = butEdit.Enabled = true;
                                butNew.Enabled = butChiDinh.Enabled = butNhapSinhHieu.Enabled = butPrint.Enabled = butCapToa.Enabled = butXuatTuTruc.Enabled = butSave.Enabled = butCancel.Enabled = false;
                            }
                            else if (iStatus == 2)
                            {
                                butPrint.Enabled = butContinues.Enabled = butCancel.Enabled = butCapToa.Enabled = true;
                                butNew.Enabled = butChiDinh.Enabled = butNhapSinhHieu.Enabled = butXuatTuTruc.Enabled = butSave.Enabled = butUndo.Enabled = butEdit.Enabled = false;
                            }
                        }
                        else
                        {
                            butContinues.Enabled = butUndo.Enabled = butNew.Enabled = true;
                            butEdit.Enabled = butChiDinh.Enabled = butNhapSinhHieu.Enabled = butPrint.Enabled = butCapToa.Enabled = butXuatTuTruc.Enabled = butSave.Enabled = false;
                            txtNgayvv.Text = Utils.DateServer().ToString("dd/MM/yyyy");
                            txtGiovv.Text = Utils.TimeServer();
                        }
                        this.GetHistoryPatient(spatientCode);
                    }
                    else
                        return;
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi : " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GetCardInfo(string sCard)
        {
            try
            {
                string sMaBHYT = sCard.Substring(0, 3);
                RateBHYTInf model = RateBHYTBLL.objectRateBHYT(sMaBHYT);
                if (model != null || model.RateCard != string.Empty)
                {
                    if (this.chkTraiTuyen.Checked)
                    {
                        if (this.chkGiayChuyenVien.Checked || this.chkCapCuu.Checked)
                            this.lbTileBHYT.Text = "BHYT " + model.RateTrue + "%";
                        else
                            this.lbTileBHYT.Text = "BHYT " + model.RateFalse + "%";
                    }
                    else
                        this.lbTileBHYT.Text = "BHYT " + model.RateTrue + "%";
                }
            }
            catch { }
        }

        private void GetInfoPatient(string sPatient)
        {
            try
            {
                PatientsInf objPatient = PatientsBLL.ObjPatients(sPatient,this.dReceiveID);
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

        private void GetHistoryPatient(string sPatient)
        {
            try
            {
                List<MedicalEmergencyHistoryModel> lstHistory = new List<MedicalEmergencyHistoryModel>();
                lstHistory = MedicalRecord_BLL.ListHistoryMedicalEmergency(sPatient);
                gridControl_PreviousList.DataSource = lstHistory;
            }
            catch { }
        }

        private void txtChandoankemtheo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow r = Utils.GetPriceRowbyCode(dtICD10kemtheo, "DiagnosisCode='" + lkupICD10ktheo.EditValue.ToString() + "'");
                if (r != null)
                {
                    if (XtraMessageBox.Show(" Bệnh kèm theo đã tồn tại! ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    this.dtICD10kemtheo.Rows.Add(lkupICD10ktheo.EditValue.ToString(), lkupICD10ktheo.Text);
                    this.gridControl_ICD10.DataSource = dtICD10kemtheo;
                    this.gridControl_Benhkemtheo.DataSource = dtICD10kemtheo;
                }
            }
            catch { }
        }

        private void gridControl_ICD10_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gridView_ICD10.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show("Bạn có muốn bỏ chẩn đoán bệnh kèm theo này?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        try
                        {
                            dtICD10kemtheo.Rows.RemoveAt(gridView_ICD10.FocusedRowHandle);
                        }
                        catch { return; }
                    }
                }
            }
            catch { }
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

        private void txtHuyetap1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtGiovv_Validated(object sender, EventArgs e)
        {
            try
            {
                string str = (this.txtGiovv.Text.Trim() == string.Empty) ? "00:00" : this.txtGiovv.Text.Trim();
                this.txtGiovv.Text = str.Substring(0, 2).Trim().PadLeft(2, '0') + ":" + str.Substring(3).Trim().PadRight(2, '0');
                if (!Utils.isHour(this.txtGiovv.Text))
                {
                    XtraMessageBox.Show("Giờ vào viện không hợp lệ !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtGiovv.Focus();
                }
                else
                {
                    if (this.dtReceive > Utils.StringToDateTime(txtNgayvv.Text.Trim() + " " + txtGiovv.Text.Trim()))
                    {
                        XtraMessageBox.Show("Ngày, giờ vào viện không được phép nhỏ hơn ngày giờ tiếp nhận bệnh (" + this.dtReceive.ToString("dd/MM/yyyy HH:mm") + ")!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.txtGiovv.Focus();
                    }
                }
            }
            catch { }
        }
        private void txtNgayvv_Validated(object sender, EventArgs e)
        {
            string sDate = txtNgayvv.Text;
            if (sDate == string.Empty || sDate == "  /  /") 
                return;
            this.txtNgayvv.Text = this.txtNgayvv.Text.Trim();
            if (!Utils.isDate(this.txtNgayvv.Text))
            {
                XtraMessageBox.Show("Ngày vào viện không hợp lệ !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtNgayvv.Focus();
                return;
            }
            this.txtNgayvv.Text = Ktngaygio(this.txtNgayvv.Text, 10);
            if (!Utils.isDate(this.txtNgayvv.Text))
            {
                XtraMessageBox.Show("Ngày vào viện không hợp lệ !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgayvv.Focus();
                return;
            }
        }
        public string Ktngaygio(string s, int len)
        {
            try
            {
                string s1 = Utils.Onlyso(s);
                if (len == 10)
                    return s1.Substring(0, 2).Trim().PadLeft(2, '0') + "/" + s1.Substring(2, 2).Trim().PadLeft(2, '0') + "/" + s1.Substring(4).Trim().PadLeft(4, '0');
                else
                    return s1.Substring(0, 2).Trim().PadLeft(2, '0') + "/" + s1.Substring(2, 2).Trim().PadLeft(2, '0') + "/" + s1.Substring(4, 4).Trim().PadLeft(4, '0') + " " + s1.Substring(9, 2).Trim().PadLeft(2, '0') + ":" + s1.Substring(11, 2).Trim().PadLeft(2, '0');
            }
            catch { return s; }
        }

        private void txtNgayrv_Validated(object sender, EventArgs e)
        {
            try
            {
                string sDate = txtNgayrv.Text;
                if (sDate == string.Empty || sDate == "  /  /")
                    return;
                txtNgayrv.Text = txtNgayrv.Text.Trim();
                if (!Utils.isDate(txtNgayrv.Text))
                {
                    XtraMessageBox.Show("Ngày ra viện không hợp lệ !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgayrv.Focus();
                    return;
                }
                txtNgayrv.Text = Ktngaygio(txtNgayrv.Text, 10);
                if (!Utils.isDate(txtNgayrv.Text))
                {
                    XtraMessageBox.Show("Ngày ra viện không hợp lệ !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgayrv.Focus();
                    return;
                }
                this.txtNgaydieutri.Text = ((Utils.StringToDate(this.txtNgayrv.Text) - Utils.StringToDate(this.txtNgayvv.Text)).Days + 1).ToString();
            }
            catch { }
        }

        private void txtGiorv_Validated(object sender, EventArgs e)
        {
            try
            {
                string str = (this.txtGiorv.Text.Trim() == string.Empty) ? "00:00" : this.txtGiovv.Text.Trim();
                this.txtGiorv.Text = str.Substring(0, 2).Trim().PadLeft(2, '0') + ":" + str.Substring(3).Trim().PadRight(2, '0');
                if (!Utils.isHour(this.txtGiorv.Text))
                {
                    XtraMessageBox.Show("Giờ ra viện không hợp lệ !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtGiorv.Focus();
                }
                else
                {
                    if (Utils.StringToDateTime(txtNgayrv.Text.Trim() + " " + txtGiorv.Text.Trim()) < Utils.StringToDateTime(txtNgayvv.Text.Trim() + " " + txtGiovv.Text.Trim()))
                    {
                        XtraMessageBox.Show("Ngày, giờ vào viện không được phép nhỏ hơn ngày giờ vào viện(" + txtNgayrv.Text.Trim() + " " + txtGiorv.Text.Trim() + ")!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.txtGiovv.Focus();
                    }
                    else
                        txtNgaydieutri.Text = ((Utils.StringToDate(txtNgayrv.Text) - Utils.StringToDate(txtNgayvv.Text)).Days + 1).ToString();
                }
            }
            catch { }
        }

        private void lkupBenhkemtheo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow r = Utils.GetPriceRowbyCode(dtICD10rvkemtheo, "DiagnosisCode='" + lkupBenhkemtheo.EditValue.ToString() + "'");
                if (r != null)
                {
                    if (XtraMessageBox.Show(" Bệnh kèm theo đã tồn tại! ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    dtICD10rvkemtheo.Rows.Add(lkupBenhkemtheo.EditValue.ToString(), lkupBenhkemtheo.Text);
                    gridControl_Benhkemtheo.DataSource = dtICD10rvkemtheo;
                }
            }
            catch { }
        }

        private void gridControl_Benhkemtheo_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gridView_Benhkemtheo.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    if (XtraMessageBox.Show("Bạn có muốn bỏ chẩn đoán bệnh kèm theo này?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        try
                        {
                            dtICD10rvkemtheo.Rows.RemoveAt(gridView_Benhkemtheo.FocusedRowHandle);
                        }
                        catch { return; }
                    }
                }
            }
            catch { }
        }

        private void CheckDone_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.butNew.Enabled = false;
                this.LoadListPatientWaitingCompleted(2);
            }
            catch
            {
                return;
            }
        }

        private void txtNgaydieutri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNhietdo_Validated(object sender, EventArgs e)
        {
            if (this.txtNhietdo.Text.Trim() != string.Empty)
            {
                if (!Utils.IsNumber(this.txtNhietdo.Text.Trim()))
                {
                    XtraMessageBox.Show(" Nhiệt độ phải nhập số!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNhietdo.Focus();
                    return;
                }
            }
        }

        private void butXuatTuTruc_Click(object sender, EventArgs e)
        {
            try
            {
                frmXuatTuTruc form = new frmXuatTuTruc(s_makp, s_userCode, dReceiveID, spatientCode, iObjectCode, sMedicalEmergency, iPatientType, sTheBHYT, iTraituyen, this.shiftWork, this.dtWorking);
                form.ShowDialog();
            }
            catch { }
        }

        private void butCapToa_Click(object sender, EventArgs e)
        {
            frmCapToaVe frm = new frmCapToaVe(this.s_makp, this.s_userCode, sMedicalEmergency, spatientCode, iPatientType, iPaid, dReceiveID, iObjectCode, this.shiftWork, this.dtICD10kemtheo, this.cbChandoan.Text, this.txtTrieuChung.Text, this.memoTreatments.Text, this.dtWorking);
            frm.ShowDialog(this);
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            this.Total_Treatment_Costs();
        }

        private void Total_Treatment_Costs()
        {
            try
            {
                Int32 iTile = 0;
                if (this.iObjectCode == 1)
                {
                    BHYTParametersInf Modelpara = BHYTParametersBLL.ObjParameters(1);
                    RateBHYTInf ModelRate = RateBHYTBLL.objectRateBHYT(this.sTheBHYT.Substring(0, 3));
                    if (iTraituyen == 1)
                    {
                        iTile = ModelRate.RateFalse;
                    }
                    else
                    {
                        iTile = ModelRate.RateTrue;
                    }
                }
                DataTable dtClinic = new DataTable("ClinicInfo");
                dtClinic = ClinicInformationBLL.DT_Information(1);
                DataTable dtBanksInfo = new DataTable("BanksInfo");
                dtBanksInfo = BanksAccountDetailBLL.DT_View_Treatment_Emergency(spatientCode, dReceiveID, sMedicalEmergency);
                if (dtBanksInfo.Rows.Count > 0)
                {
                    DataTable dtBV01 = new DataTable("ResultBV01");
                    dtBV01 = BanksAccountDetailBLL.DT_View_Treatment_Costs(dReceiveID, spatientCode);
                    decimal disparityPrice = 0;
                    foreach (DataRow dr in dtBV01.Rows)
                    {
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
                    dsTemp.WriteXml(Utils.CurrentPathApplication() + "\\xml\\rptChiphidieutriCC.xml");
                    Reports.rptChiphidieutriCC rptShow = new Reports.rptChiphidieutriCC();
                    rptShow.DataSource = dsTemp;
                    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "PhieuDieuTri", "P.Lưu-Phiếu điều trị");
                    rpt.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show(" Bệnh nhân chưa có thông tin điều trị tại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtNhantu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) 
                SendKeys.Send("{Tab}{F4}"); 
        }

        private void lkNhanbenh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                cbChandoan.Focus();
        }

        private void lkupICD10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}{F4}");
        }

        private void lkupICD10ktheo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                txtNguoithan.Focus();
        }

        private void txtNguoithan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                txtHoten.Focus();
        }

        private void txtHoten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                txtDienthoai.Focus();
        }

        private void txtdiachi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                cbChandoan.Focus();
        }

        private void txtDienthoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                txtdiachi.Focus();
        }

        private void txtNgayrv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtGiorv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtNgaydieutri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}{F4}");
        }

        private void lkKetquadieutri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}{F4}");
        }

        private void lkupBenhchinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}{F4}");
        }

        private void lkupBenhkemtheo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}{F4}");
        }

        private void lkBacsi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}");
        }

        private void txtSoluutru_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}{F4}");
        }

        private void lkXutri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}{F4}");
        }

        private void cbLoidan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                butSave.Focus();
        }

        private void cbChandoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SendKeys.Send("{Tab}{F4}");
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (iStatus == 2)
                {
                    if (XtraMessageBox.Show(" Bạn thật sự muốn hủy thông tin ra viện của bệnh nhân này?", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                    {
                        if (PatientReceiveBLL.DelEmergencyOut(spatientCode, dReceiveID) == 1)
                        {
                            XtraMessageBox.Show(" Hủy thành công thông tin bệnh nhân ra viện!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MedicalEmergencyOutINF objEmergencyOut = MedicalEmergencyBLL.ObjEmergencyOut(sMedicalEmergency);
                            if (objEmergencyOut != null && objEmergencyOut.PatientReceiveID <= 0)
                            {
                                txtNgayrv.Text = "/__/";
                                txtGiorv.Text = ":";
                                txtNgaydieutri.Text = "0";
                                lkKetquadieutri.EditValue = null;
                                lkupBenhchinh.EditValue = null;

                                lkBacsi.EditValue = null;
                                txtSoluutru.Text = string.Empty;
                                lkXutri.EditValue = null;
                                cbLoidan.Text = string.Empty;
                            }
                            EnableButtonAll(true);
                            butReload_Click(sender, e);
                            gridControl_Benhkemtheo.DataSource = null;
                        }
                        else
                        {
                            XtraMessageBox.Show(" Bệnh nhân đã thanh toán, không được phép hủy thông tin ra viện!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                        return;
                }
            }
            catch { }
        }

        private void butHSBA_Click(object sender, EventArgs e)
        {
            if (spatientCode != string.Empty)
            {
                frmKB_HSBA frm = new frmKB_HSBA(spatientCode);
                frm.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show(" Chưa có thông tin mã bệnh nhân!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void txtMach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtHuyetap.Focus();
            }
        }

        private void txtHuyetap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtHuyetap1.Focus();
            }
        }

        private void txtHuyetap1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtNhietdo.Focus();
            }
        }

        private void txtCao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtNang.Focus();
            }
        }

        private void txtNang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.txtNguoithan.Focus();
            }
        }

        private void txtNhietdo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.txtCao.Focus();
            }
        }

        private void txtNang_Validated(object sender, EventArgs e)
        {
            if (this.txtNang.Text.Trim() != string.Empty)
            {
                if (!Utils.IsNumber(this.txtNang.Text.Trim()))
                {
                    XtraMessageBox.Show(" Cân nặng phải nhập số!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNang.Focus();
                    return;
                }
                else
                    this.ProcessBMI();
            }
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

        private void txtCao_Validated(object sender, EventArgs e)
        {
            if (this.txtCao.Text.Trim() != string.Empty)
            {
                if (!Utils.IsNumber(this.txtCao.Text.Trim()))
                {
                    XtraMessageBox.Show(" Chiều cao phải nhập số!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtCao.Focus();
                    return;
                }
            }
        }

        private void butNhapSinhHieu_Click(object sender, EventArgs e)
        {
            frmTheoDoiSinhTon form = new frmTheoDoiSinhTon(sMedicalEmergency, dReceiveID, spatientCode, s_userCode);
            form.ShowDialog();
            GetStatistic();
        }

        private void GetStatistic()
        {
            try
            {
                lstSign = SurviveSignBLL.ListSurviveSignForRefID(this.dReceiveID);
                chartControl1.Series.Clear();
                Series series1 = new Series("Mạch", ViewType.SwiftPlot);
                Series series2 = new Series("Nhiệt độ", ViewType.SwiftPlot);
                Series series3 = new Series("Huyết áp", ViewType.SwiftPlot);
                Series series4 = new Series("Nặng", ViewType.SwiftPlot);
                Series series5 = new Series("Cao", ViewType.SwiftPlot);
                Series series6 = new Series("Nhịp thở", ViewType.SwiftPlot);
                string sDate = string.Empty;
                foreach (var v in lstSign)
                {
                    sDate = v.CreateDate.ToString("dd/MM HH:mm");
                    if (v.Pulse.Trim() != string.Empty)
                        series1.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(v.Pulse) }));
                    else
                        series1.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(0) }));
                    if (v.Temperature.Trim() != string.Empty)
                        series2.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(v.Temperature) }));
                    else
                        series2.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(0) }));
                    if (v.BloodPressure.Trim() != string.Empty)
                        series3.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(v.BloodPressure) }));
                    else
                        series3.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(0) }));
                    if (v.Weight.Trim() != string.Empty)
                        series4.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(v.Weight) }));
                    else
                        series4.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(0) }));
                    if (v.Hight.Trim() != string.Empty)
                        series5.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(v.Hight) }));
                    else
                        series5.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(0) }));
                    if (v.Breath.Trim() != string.Empty)
                        series6.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(v.Breath) }));
                    else
                        series6.Points.Add(new SeriesPoint(sDate, new double[] { Convert.ToDouble(0) }));
                }
                chartControl1.Series.Add(series1);
                chartControl1.Series.Add(series2);
                chartControl1.Series.Add(series3);
                chartControl1.Series.Add(series4);
                chartControl1.Series.Add(series5);
                chartControl1.Series.Add(series6);
                chartControl1.Legend.Visible = true;
            }
            catch { }
        }

        private void txtTrieuChung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.memoTreatments.Focus();
        }

        private void lkupICD10_EditValueChanged(object sender, EventArgs e)
        {
            this.lkupBenhchinh.EditValue = this.lkupICD10.EditValue;
        }

        private void memoTreatments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.cbChandoan.Focus();
        }
    }
}