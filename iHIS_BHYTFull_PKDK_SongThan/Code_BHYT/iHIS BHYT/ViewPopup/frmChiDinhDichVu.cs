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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;

namespace Ps.Clinic.ViewPopup
{
    public partial class frmChiDinhDichVu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string patientCode = string.Empty;
        private decimal patientReceiveId = 0;
        private string sUserid = string.Empty;
        private Int32 objectCode = 0, iPatientType = 0;
        private string sMathe = string.Empty;
        private int iTraituyen = 0;
        private string sReferenceCode = string.Empty;
        private DataTable dtDichvu = new DataTable();
        private string s_idGroup = string.Empty, s_idCate = string.Empty;
        private XtraTabPage tab;
        private CheckBox chkbox;
        private ToolTip tooltip;
        public string s_PackageCode = string.Empty;
        private string sMakpOder = string.Empty;
        private DataTable dtPackage = new DataTable();
        private bool bChkNgayCD = true;
        private string type = "S";
        private string shiftWork = string.Empty;
        private string employeeCodeDoctor = string.Empty, serviceCode = string.Empty;
        private DataView cloneObject = null;
        private List<ServiceCategoryInf> lstCategory = new List<ServiceCategoryInf>();
        private List<ServiceGroupInf> lstGroup = new List<ServiceGroupInf>();
        private List<ServiceInf> lstServiceReal = new List<ServiceInf>();
        private DateTime dtWorking = new DateTime();
        public frmChiDinhDichVu(decimal _patientReceiveId, string refPatientCode, string _UserLogin, Int32 _objectCode, string _Mathe, int _TraiTuyen, string _ReferenceCode, int _PatientType, string _sMakpOder, string _employeeCodeDoctor, string _serviceCode, string _shiftWork, DateTime _dtWorking)
        {
            InitializeComponent();
            this.patientCode = refPatientCode;
            this.patientReceiveId = _patientReceiveId;
            this.sUserid = _UserLogin;
            this.objectCode = _objectCode;
            this.sMathe = _Mathe;
            this.iTraituyen = _TraiTuyen;
            this.sReferenceCode = _ReferenceCode;
            this.iPatientType = _PatientType;
            this.sMakpOder = _sMakpOder;
            this.employeeCodeDoctor = _employeeCodeDoctor;
            this.serviceCode = _serviceCode;
            this.shiftWork = _shiftWork;
            this.dtWorking = _dtWorking;
            this.dtNgayCD.EditValue = Convert.ToDateTime(_dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
        }

        public void InitGrid(decimal dReceive)
        {
            this.dtDichvu.Clear();
            DataTable dtServiceTemp = SuggestedServiceReceiptBLL.DTListForPatientReceiveId(dReceive, patientCode, iPatientType, string.Empty, dtNgayCD.Text.ToString(), sReferenceCode);
            Int32 runNumber = this.dtDichvu.Rows.Count + 1;
            if (dtServiceTemp != null && dtServiceTemp.Rows.Count > 0)
            {
                foreach (DataRow dr in dtServiceTemp.Rows)
                {
                    //RowID,DepartmentCode,ServiceCode,ServicePrice,DisparityPrice,PatientCode,Status,Paid,CreateDate,EmployeeCode,Note,RefID,ObjectCode,RowIDPrice,ServicePackageCode,
                    //ServiceName, Del,PatientType,WorkDate,ReferenceCode,Quantity,AmountExemption,UnitOfMeasureCode,Content,Attach_Items
                    dtDichvu.Rows.Add(dr["RowID"].ToString(), dr["ServiceCode"].ToString(), dr["ServiceName"].ToString(), Convert.ToInt32(dr["Quantity"].ToString()), dr["ObjectCode"].ToString(), dr["ServicePrice"].ToString(), dr["DisparityPrice"].ToString(), dr["DepartmentCode"].ToString(), dr["Status"].ToString(), dr["Paid"].ToString(), dr["Del"].ToString(), dr["RowIDPrice"].ToString(), dr["ServicePackageCode"].ToString(), dr["ReferenceCode"].ToString(), dr["EmployeeCode"].ToString(), Convert.ToDecimal(dr["AmountExemption"].ToString()), dr["UnitOfMeasureCode"].ToString(), runNumber, dr["Content"].ToString(), dr["Attach_Items"].ToString());
                    runNumber++;
                }
            }
            this.gridControl_Service.DataSource = dtDichvu;
        }

        private void frmChiDinhDichVu_Load(object sender, EventArgs e)
        {
            try
            {
                this.rep_DepartmentCode.DataSource = DepartmentBLL.DTDepartment(string.Empty);
                this.rep_DepartmentCode.DisplayMember = "DepartmentName";
                this.rep_DepartmentCode.ValueMember = "DepartmentCode";

                this.rep_ObjectCode.DataSource = ObjectBLL.DTObjectListNotIn(5);
                this.rep_ObjectCode.DisplayMember = "ObjectName";
                this.rep_ObjectCode.ValueMember = "ObjectCode";

                this.ref_UnitOf.DataSource = UnitOfMeasureBLL.ListUnit("", this.type);
                this.ref_UnitOf.DisplayMember = "UnitOfMeasureName";
                this.ref_UnitOf.ValueMember = "UnitOfMeasureCode";

                this.lkupEmployee.Properties.DataSource = EmployeeBLL.ListEmployeeForPosition("3");
                this.lkupEmployee.Properties.DisplayMember = "EmployeeName";
                this.lkupEmployee.Properties.ValueMember = "EmployeeCode";
                this.lkupEmployee.EditValue = this.employeeCodeDoctor;

                this.dtDichvu.Columns.Add("RowID", typeof(Decimal));
                this.dtDichvu.Columns.Add("ServiceCode", typeof(string));
                this.dtDichvu.Columns.Add("ServiceName", typeof(string));
                this.dtDichvu.Columns.Add("Quantity", typeof(Int32));
                this.dtDichvu.Columns.Add("ObjectCode", typeof(Int32));
                this.dtDichvu.Columns.Add("Price", typeof(Decimal));
                this.dtDichvu.Columns.Add("DisparityPrice", typeof(Decimal));
                this.dtDichvu.Columns.Add("DepartmentCode", typeof(string));
                this.dtDichvu.Columns.Add("Status", typeof(Int32));
                this.dtDichvu.Columns.Add("Paid", typeof(Int32));
                this.dtDichvu.Columns.Add("Del", typeof(Int32));
                this.dtDichvu.Columns.Add("RowIDPrice", typeof(Decimal));
                this.dtDichvu.Columns.Add("ServicePackageCode", typeof(string));
                this.dtDichvu.Columns.Add("ReferenceCode", typeof(string));
                this.dtDichvu.Columns.Add("EmployeeCode", typeof(string));
                this.dtDichvu.Columns.Add("AmountExemption", typeof(decimal));
                this.dtDichvu.Columns.Add("UnitOfMeasureCode", typeof(string));
                this.dtDichvu.Columns.Add("RunNumber", typeof(Int32));
                this.dtDichvu.Columns.Add("Content", typeof(string));
                this.dtDichvu.Columns.Add("Attach_Items", typeof(string));

                this.InitGrid(this.patientReceiveId);
                SystemParameterInf objSys = SystemParameterBLL.ObjParameter(2);
                if (objSys.Values != 0)
                    bChkNgayCD = false;
                this.lstGroup = ServiceGroupBLL.ListServiceGroup(string.Empty);
                this.lstCategory = ServiceCategoryBLL.ListServiceCategoryRefService(string.Empty, string.Empty);
                this.lstServiceReal = ServiceBLL.ListServiceReal(string.Empty, string.Empty);
                this.fLoad_NhomDichVu();
                this.Load_new(s_idGroup, s_idCate);
                this.Load_TreeView();
                this.TotalService(patientReceiveId);
                this.GetSearchService();
                this.EnableAll(false);
                if (!this.sMakpOder.Equals("KP0000"))
                    this.lkupEmployee.Properties.ReadOnly = true;
                foreach (DataRow rowChk in this.dtDichvu.Rows)
                {
                    rowChk["Del"] = 0;
                }
                objSys = SystemParameterBLL.ObjParameter(16);
                if (objSys.Values != 0 && objSys != null)
                    this.lkupEmployee.Properties.ReadOnly = false;
            }
            catch (Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                int iresult = 0;
                if (dtDichvu != null && dtDichvu.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtDichvu.Rows)
                    {
                        if (dr["ReferenceCode"].ToString() == sReferenceCode)
                        {
                            SuggestedServiceReceiptInf inf = new SuggestedServiceReceiptInf();
                            inf.ReceiptID = decimal.Parse(dr["RowID"].ToString());
                            inf.DepartmentCode = dr["DepartmentCode"].ToString();
                            inf.ServiceCode = dr["ServiceCode"].ToString();
                            inf.ServicePrice = decimal.Parse(dr["Price"].ToString());
                            inf.DisparityPrice = decimal.Parse(dr["DisparityPrice"].ToString());
                            inf.PatientCode = patientCode;
                            inf.Status = int.Parse(dr["Status"].ToString());
                            inf.Paid = int.Parse(dr["Paid"].ToString());
                            inf.ServicePackageCode = dr["ServicePackageCode"].ToString();
                            inf.EmployeeCode = this.sUserid;
                            inf.Note = string.Empty;
                            inf.RefID = patientReceiveId;
                            inf.ObjectCode = Int32.Parse(dr["ObjectCode"].ToString());
                            inf.PatientType = this.iPatientType;
                            inf.RowIDPrice = decimal.Parse(dr["RowIDPrice"].ToString());
                            inf.WorkDate = Convert.ToDateTime(this.dtWorking.ToString("dd/MM/yyyy") + " " + Utils.TimeServer());
                            inf.ReferenceCode = sReferenceCode;
                            inf.DepartmentCodeOder = sMakpOder;
                            inf.ShiftWork = this.shiftWork;
                            inf.Quantity = Convert.ToInt32(dr["Quantity"].ToString());
                            inf.Content = dr["Content"].ToString();
                            inf.Check_ = Convert.ToInt32(dr["Del"]);
                            if (this.lkupEmployee.EditValue != null)
                                inf.EmployeeCodeDoctor = this.lkupEmployee.EditValue.ToString();
                            else
                                inf.EmployeeCodeDoctor = this.sUserid;
                            if (SuggestedServiceReceiptBLL.Ins(inf) >= 1)
                            {
                                iresult += 1;
                            }
                        }
                    }
                    if (iresult >= 1)
                    {
                        XtraMessageBox.Show(" Lưu chỉ định thành công! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.InitGrid(this.patientReceiveId);
                        this.Load_TreeView();
                        this.TotalService(patientReceiveId);
                        this.EnableAll(false);
                        if (dtDichvu.Rows.Count > 0)
                        {
                            this.butSave.Enabled = true;
                            this.butDelete.Enabled = true;
                            this.butPrint.Enabled = true;
                        }
                        //butNew_Click(sender, e);
                        this.butPrint_Click(sender, e);
                    }
                }
                else
                    XtraMessageBox.Show(" Chưa có chỉ dịch vụ được chỉ định.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi lưu chỉ định dịch vụ :" + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        
        private void butDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string sSuccess = string.Empty;
                string sDone = string.Empty;
                string sPaid = string.Empty;
                string sResult = string.Empty;
                string sMsg = string.Empty;
                string attachItem = string.Empty;
                if (dtDichvu != null && dtDichvu.Rows.Count > 0)
                {
                    int iCountDel = dtDichvu.Select("Del=1", " Del asc").Count();
                    if (iCountDel > 0)
                    {
                        if (XtraMessageBox.Show(" Bạn thật sự muốn xóa các chỉ định này? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                        {
                            DataTable dtTemp = dtDichvu.Select("Del=1").CopyToDataTable();
                            
                            foreach (DataRow r in dtTemp.Rows)
                            {
                                //if (r["ReferenceCode"].ToString() == sReferenceCode && r["Del"].ToString() == "1")
                                if (r["Del"].ToString() == "1")
                                {
                                    int iResult = SuggestedServiceReceiptBLL.Del(decimal.Parse(r["RowID"].ToString()), ref sResult);
                                    if (iResult == 0)
                                    {
                                        sSuccess += r["ServiceName"].ToString() + "\n";
                                        this.dtDichvu.Rows.RemoveAt(gridView_Service.FocusedRowHandle);
                                    }
                                    else
                                    {
                                        if (iResult == 1)
                                        {
                                            sSuccess += r["ServiceName"].ToString();
                                            dtDichvu.Rows.RemoveAt(gridView_Service.FocusedRowHandle);
                                        }
                                        else if (iResult == -1)
                                        {
                                            sDone += r["ServiceName"].ToString();
                                        }
                                        else if (iResult == -2)
                                        {
                                            sPaid += r["ServiceName"].ToString();
                                        }
                                        else if (iResult == -3)
                                        {
                                            attachItem += r["ServiceName"].ToString();
                                        }
                                    }
                                }
                            }
                            if (sDone != "")
                                sMsg += " Đã thực hiện:  " + sDone + " không cho phép xóa \r\n";
                            else if (sPaid != "")
                                sMsg += " Thu tiền:  " + sPaid + " không cho phép xóa \r\n";
                            else if (attachItem != "")
                                sMsg += " Thuốc - VTTH kèm theo dịch vụ:  " + attachItem + " đã duyệt không cho phép xóa \r\n Hủy duyệt trước khi xóa.";
                            if(string.IsNullOrEmpty(sMsg))
                            {
                                if (XtraMessageBox.Show(" Xóa thành công!", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                {
                                    this.InitGrid(patientReceiveId);
                                    this.Load_TreeView();
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show(sMsg, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            //if (XtraMessageBox.Show(sMsg + "\r\n Bạn có muốn load lại dữ liệu? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            //{
                            //    this.InitGrid(patientReceiveId);
                            //    this.Load_TreeView();
                            //}
                            if (dtDichvu.Rows.Count <= 0)
                            {
                                this.EnableAll(true);
                            }
                            this.TotalService(patientReceiveId);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(" Chọn dịch vụ cần xóa! ", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Chỉ định chưa có!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch { return; }
        }

        private void Load_TreeView()
        {
            try
            {
                this.treeView1.Nodes.Clear();
                TreeNode node, node1, node2, node3;
                List<PatientReceiveInf> lstPatien = new List<PatientReceiveInf>();
                lstPatien = PatientReceiveBLL.ListForPatient(patientCode);
                DataTable dtPre;
                foreach (var v in lstPatien)
                {
                    node = new TreeNode("Ngày vào viện: " + v.CreateDate.ToString("dd/MM/yyyy"));
                    node.Tag = v.PatientReceiveID + ":?:?";
                    treeView1.Nodes.Add(node);
                    DataTable dtTemp = SuggestedServiceReceiptBLL.DTListReceiveIdGroupDate(v.PatientReceiveID, v.PatientCode, iPatientType);
                    foreach (DataRow r in dtTemp.Rows)
                    {
                        node1 = new TreeNode("Ngày: " + r["CreateDate"].ToString());
                        node1.Tag = v.PatientReceiveID + ":" + r["CreateDate"].ToString() + ":?";
                        node.Nodes.Add(node1);
                        DataTable dtTemp01 = SuggestedServiceReceiptBLL.DTListReceiveIdGroupDepartmentOrder(v.PatientReceiveID, v.PatientCode, iPatientType, r["CreateDate"].ToString());
                        foreach (DataRow r2 in dtTemp01.Rows)
                        {
                            node2 = new TreeNode("Phòng: " + r2["DepartmentName"].ToString());
                            node2.Tag = v.PatientReceiveID + ":" + r["CreateDate"].ToString() + ":" + r2["DepartmentCodeOrder"].ToString();
                            node1.Nodes.Add(node2);

                            dtPre = SuggestedServiceReceiptBLL.DTListServiceGroupDepartmentOrder(v.PatientReceiveID, v.PatientCode, iPatientType, r["CreateDate"].ToString(), r2["DepartmentCodeOrder"].ToString());
                            foreach (DataRow r3 in dtPre.Rows)
                            {
                                node3 = new TreeNode(r3["ServiceName"].ToString());
                                node3.Tag = v.PatientReceiveID + ":?:?";
                                node2.Nodes.Add(node3);
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void TotalService(decimal dReceive)
        {
            try
            {
                decimal dAmount = 0, dThuphiTotal = 0, dTile = 0, dChenhlech = 0;
                decimal dBHYTTotal = 0, dBHYTTra = 0;
                if (dtDichvu.Rows.Count > 0)
                {
                    if (objectCode == 1)
                    {
                        List<BHYTInf> lstBHYT = BHYTBLL.ListBHYTForPatientReceiveId(dReceive);
                        if (lstBHYT !=null && lstBHYT.Count > 0)
                        {
                            sMathe = lstBHYT[0].Serial;
                            if (lstBHYT[0].TraiTuyen.Equals(1) && lstBHYT[0].ReferralPaper.Equals(1))
                                iTraituyen = 0;
                            else if (lstBHYT[0].TraiTuyen.Equals(1) && !lstBHYT[0].ReferralPaper.Equals(1))
                                iTraituyen = 1;
                            else
                                iTraituyen = 0;
                        }
                        BHYTParametersInf Modelpara = BHYTParametersBLL.ObjParameters(1);
                        RateBHYTInf ModelRate = RateBHYTBLL.objectRateBHYT(sMathe.Substring(0, 3));
                        if (iTraituyen == 1)
                        {
                            dTile = ModelRate.RateFalse;
                        }
                        else
                        {
                            dTile = ModelRate.RateTrue;
                        }
                        foreach (DataRow dr in dtDichvu.Rows)
                        {
                            dAmount += Convert.ToDecimal(dr["Price"].ToString());
                            dChenhlech += Convert.ToDecimal(dr["DisparityPrice"].ToString());
                            List<ObjectInf> lstObject = new List<ObjectInf>();
                            lstObject = ObjectBLL.ListObject(int.Parse(dr["ObjectCode"].ToString()));
                            if (lstObject != null && lstObject.Count > 0)
                            {
                                if (Convert.ToInt32(dr["ObjectCode"].ToString()) == lstObject[0].ObjectCode && lstObject[0].ObjectCard == 1)
                                {
                                    dBHYTTotal += Convert.ToDecimal(dr["Price"].ToString());
                                }
                                else
                                    dThuphiTotal += Convert.ToDecimal(dr["Price"].ToString());
                            }
                        }

                        txtAmount.EditValue = dAmount.ToString("N0");

                        if (dBHYTTotal <= Modelpara.BHYTUnderPrice)
                        {
                            txtBhytPay.EditValue = dBHYTTotal.ToString("N0");
                            txtPatientPay.EditValue = (dChenhlech + dThuphiTotal).ToString("N0");
                        }
                        else if (dBHYTTotal > Modelpara.BHYTUnderPrice && dBHYTTotal <= Modelpara.BHYTOnPrice)
                        {
                            dBHYTTra = (dBHYTTotal * dTile / 100);
                            txtBhytPay.EditValue = dBHYTTra.ToString("N0");
                            txtPatientPay.EditValue = (dChenhlech + dThuphiTotal + (dBHYTTotal - dBHYTTra)).ToString("N0");
                        }
                        else if (dBHYTTotal > Modelpara.BHYTOnPrice)
                        {
                            dBHYTTra = Modelpara.BHYTOnPrice;
                            txtBhytPay.EditValue = dBHYTTra.ToString("N0");
                            txtPatientPay.EditValue = (dChenhlech + dThuphiTotal + (dBHYTTotal - dBHYTTra)).ToString("N0");
                        }
                    }
                    else
                    {
                        foreach (DataRow dr in dtDichvu.Rows)
                        {
                            dAmount += Convert.ToDecimal(dr["Price"].ToString());
                        }
                        txtPatientPay.EditValue = txtAmount.EditValue = dAmount.ToString("N0");
                        txtBhytPay.EditValue = 0;
                    }
                }
                
            }
            catch { }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            this.PrintServices();
        }

        private void PrintServices()
        {
            try
            {
                DataTable dtClinic = ClinicInformationBLL.DT_Information(1);
                string sRowID = string.Empty;
                foreach (DataRow dr in dtDichvu.Rows)
                {
                    if (dr["Del"].ToString() == "1")
                        sRowID += dr[0].ToString() + ",";
                }
                DataTable dtICD10kt = new DataTable();
                dtICD10kt.Columns.Add("DiagnosisName", typeof(string));
                string sICD10kt = MedicalRecord_BLL.DiagnosisEnclosed(sReferenceCode);
                if (sICD10kt != string.Empty)
                    dtICD10kt.Rows.Add(sICD10kt);
                DataTable tableHandPoint = new DataTable("SuggestedInfo");
                if (!string.IsNullOrEmpty(sRowID))
                    tableHandPoint = SuggestedServiceReceiptBLL.DT_Danhsachchidinh(this.patientReceiveId, this.patientCode, sRowID.TrimEnd(','), sReferenceCode, this.dtNgayCD.Text, this.iPatientType, string.Empty);//"CDHA,KCB,TC,PTTT,TD,NHAKHOA,VC,GIUONG,XN"
                else
                    tableHandPoint = SuggestedServiceReceiptBLL.DT_Danhsachchidinh(this.patientReceiveId, this.patientCode, sRowID.TrimEnd(','), sReferenceCode, this.dtNgayCD.Text, this.iPatientType, string.Empty);
                if (tableHandPoint != null && tableHandPoint.Rows.Count > 0)
                {
                    DataTable dtBHYT = BHYTBLL.TableBHYTForPatientReceiveId(this.patientReceiveId);
                    DataTable dtSurviveSign = SurviveSignBLL.DT_SurviveSignForRefCode(sReferenceCode, this.patientCode, this.patientReceiveId);
                    DataSet dsTemp = new DataSet("Result");
                    dsTemp.Tables.Add(dtClinic);
                    dsTemp.Tables.Add(tableHandPoint);
                    dsTemp.Tables.Add(dtICD10kt);
                    dsTemp.Tables.Add(dtBHYT);
                    dsTemp.Tables.Add(dtSurviveSign);
                    dsTemp.WriteXmlSchema(Utils.CurrentPathApplication() + "\\xml\\rptChidinh.xml");
                    if (this.objectCode.Equals(1))
                    {
                        //if (this.chkGroup.Checked)
                        //{
                        //    Reports.rptKB_ChidinhGroup rptShow = new Reports.rptKB_ChidinhGroup();
                        //    rptShow.DataSource = dsTemp;
                        //    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "PhieuChiDinh", "Phiếu chỉ định");
                        //    rpt.ShowDialog();
                        //}
                        //else
                        //{
                        //    Reports.rptKB_Chidinh rptShow = new Reports.rptKB_Chidinh();
                        //    rptShow.DataSource = dsTemp;
                        //    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "PhieuChiDinh", "Phiếu chỉ định");
                        //    rpt.ShowDialog();
                        //}
                        Reports.rptKB_ChidinhGroup rptShow = new Reports.rptKB_ChidinhGroup(this.dtWorking);
                        rptShow.DataSource = dsTemp;
                        Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "PhieuChiDinh", "Phiếu chỉ định");
                        rpt.ShowDialog();
                    }
                    else
                    {
                        //if (this.chkGroup.Checked)
                        //{
                        //    Reports.rptKB_ChidinhDichVuGroup rptShow = new Reports.rptKB_ChidinhDichVuGroup();
                        //    rptShow.DataSource = dsTemp;
                        //    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "PhieuChiDinh", "Phiếu chỉ định");
                        //    rpt.ShowDialog();
                        //}
                        //else
                        //{
                        //    Reports.rptKB_ChidinhDichVu rptShow = new Reports.rptKB_ChidinhDichVu();
                        //    rptShow.DataSource = dsTemp;
                        //    Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "PhieuChiDinh", "Phiếu chỉ định");
                        //    rpt.ShowDialog();
                        //}
                        Reports.rptKB_ChidinhDichVuGroup rptShow = new Reports.rptKB_ChidinhDichVuGroup(this.dtWorking);
                        rptShow.DataSource = dsTemp;
                        Reports.frmReportEditGeneral rpt = new Reports.frmReportEditGeneral(rptShow, "PhieuChiDinh", "Phiếu chỉ định");
                        rpt.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void GetSearchService()
        {
            schlk_Service.Properties.DataSource = ServiceBLL.DTServiceRealNotGroup();
            schlk_Service.Properties.DisplayMember = "ServiceName";
            schlk_Service.Properties.ValueMember = "ServiceCode";
        }
                
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.GetHistory();
        }

        private void GetHistory()
        {
            try
            {
                string sReceive = "0";
                string sDate = treeView1.SelectedNode.Tag.ToString().Split(':')[1];
                string sDepartmentCodeOrder = treeView1.SelectedNode.Tag.ToString().Split(':')[2];
                if (treeView1.SelectedNode.Tag.ToString().Split(':')[0] != "?" && sDate != "?" && sDepartmentCodeOrder != "?")
                {
                    sReceive = treeView1.SelectedNode.Tag.ToString().Split(':')[0];
                    //InitGrid(Convert.ToDecimal(sReceive));
                    this.dtDichvu.Clear();
                    DataTable dttemp = SuggestedServiceReceiptBLL.DTGetServiceOld(Convert.ToDecimal(sReceive), patientCode, iPatientType, string.Empty, sDate, sDepartmentCodeOrder);
                    Int32 runNumber = this.dtDichvu.Rows.Count + 1;
                    if (dttemp != null && dttemp.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dttemp.Rows)
                        {
                            this.dtDichvu.Rows.Add(dr["RowID"].ToString(), dr["ServiceCode"].ToString(), dr["ServiceName"].ToString(), 1, dr["ObjectCode"].ToString(), dr["ServicePrice"].ToString(), dr["DisparityPrice"].ToString(), dr["DepartmentCode"].ToString(), dr["Status"].ToString(), dr["Paid"].ToString(), dr["Del"].ToString(), dr["RowIDPrice"].ToString(), dr["ServicePackageCode"].ToString(), dr["ReferenceCode"].ToString(), dr["EmployeeCode"].ToString(), 0, dr["UnitOfMeasureCode"].ToString(), runNumber, dr["Attach_Items"].ToString(), dr["Content"].ToString());
                            runNumber++;
                        }
                    }
                    this.gridControl_Service.DataSource = this.dtDichvu;
                    this.TotalService(Convert.ToDecimal(sReceive));
                    if (Convert.ToDecimal(sReceive) == patientReceiveId)
                    {
                        if (sMakpOder != sDepartmentCodeOrder)
                            this.EnableAll(true);
                        else
                            this.EnableAll(false);
                    }
                    else
                        this.EnableAll(true);
                }
            }
            catch
            {
            }
        }

        #region Thông chi chi định và gói
        private void fLoad_NhomDichVu()
        {
            try
            {
                treeService.Nodes.Clear();
                TreeNode anode, anode1;
                anode = new TreeNode("Tất cả");
                anode.Tag = "?:?";
                treeService.Nodes.Add(anode);
                foreach (var v in this.lstGroup)
                {
                    if (v.ServiceModuleCode != "THUOC")
                    {
                        var lstCateTemp = this.lstCategory.Where(p => p.ServiceGroupCode == v.ServiceGroupCode).Select(p => new { p.ServiceCategoryCode, p.ServiceCategoryName }).ToList();
                        if (lstCateTemp != null && lstCateTemp.Count > 0)
                        {
                            anode = new TreeNode(v.ServiceGroupName);
                            anode.Tag = v.ServiceGroupCode + ":?";
                            treeService.Nodes.Add(anode);
                            foreach (var v1 in lstCateTemp)
                            {
                                anode1 = new TreeNode(v1.ServiceCategoryName);
                                anode1.Tag = v.ServiceGroupCode + ":" + v1.ServiceCategoryCode;
                                anode.Nodes.Add(anode1);
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void f_Filter()
        {
            try
            {
                s_idGroup = ""; s_idCate = "";
                try
                {
                    if (treeService.SelectedNode.Tag.ToString().Split(':')[0] != "?" && treeService.SelectedNode.Tag.ToString().Split(':')[0] != "-1")
                    {
                        s_idGroup = treeService.SelectedNode.Tag.ToString().Split(':')[0];
                    }
                    if (treeService.SelectedNode.Tag.ToString().Split(':')[1] != "?" && treeService.SelectedNode.Tag.ToString().Split(':')[1] != "-1")
                    {
                        s_idCate = treeService.SelectedNode.Tag.ToString().Split(':')[1];
                    }
                }
                catch
                {
                }
                this.Load_new(s_idGroup.Trim(), s_idCate.Trim());
            }
            catch
            {
            }
        }

        private void treeService_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                treeService.SelectedNode.ForeColor = Color.Black;
                if (treeService.SelectedNode.Parent != null)
                {
                    treeService.SelectedNode.Parent.ForeColor = Color.Black;
                }
                if (treeService.SelectedNode.Parent.Parent != null)
                {
                    treeService.SelectedNode.Parent.Parent.ForeColor = Color.Black;
                }
            }
            catch
            {
            }
        }

        private void treeService_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.f_Filter();
            try
            {
                treeService.SelectedNode.ForeColor = Color.Red;
                if (treeService.SelectedNode.Parent != null)
                {
                    treeService.SelectedNode.Parent.ForeColor = Color.Red;
                }
                if (treeService.SelectedNode.Parent.Parent != null)
                {
                    treeService.SelectedNode.Parent.Parent.ForeColor = Color.Red;
                }
            }
            catch
            {
            }
        }

        private void Load_new(string _Group, string _Cate)
        {
            var lstGroupReal = this.lstGroup.Select(g => new { g.ServiceGroupCode, g.ServiceGroupName, g.ServiceModuleCode }).ToList();
            if (!string.IsNullOrEmpty(_Group))
                lstGroupReal = this.lstGroup.Where(g => g.ServiceGroupCode == _Group).Select(g => new { g.ServiceGroupCode, g.ServiceGroupName, g.ServiceModuleCode }).ToList();
            tabControl_Service.TabPages.Clear();
            try
            {
                foreach (var vgroup in lstGroupReal)
                {
                    if (vgroup.ServiceModuleCode != "THUOC")
                    {
                        var lstServiceRealTemp = this.lstServiceReal.Where(p => p.ServiceGroupCode == vgroup.ServiceGroupCode).Select(p => p).ToList();
                        tab = new XtraTabPage();
                        if (_Cate != "")
                        {
                            lstServiceRealTemp = this.lstServiceReal.Where(p => p.ServiceGroupCode == vgroup.ServiceGroupCode && p.ServiceCategoryCode == _Cate).Select(p => p).ToList();
                            var lst = this.lstCategory.Where(c => c.ServiceGroupCode == _Group && c.ServiceCategoryCode == _Cate).Select(c => c).ToList();
                            tab.Text = lst[0].ServiceCategoryName;
                        }
                        else
                            tab.Text = vgroup.ServiceGroupName;
                        if (lstServiceRealTemp != null && lstServiceRealTemp.Count > 0)
                        {
                            tabControl_Service.TabPages.Add(tab);
                            int t = 5, l = 0, j = 0;
                            foreach (var v in lstServiceRealTemp)
                            {
                                if (v.ServiceCode != this.serviceCode)
                                {
                                    if (j % 14 == 0 && j != 0)
                                    {
                                        t = 5;
                                        l += 295;
                                    }
                                    this.Addchkbox(v.ServiceName, v.ServiceCode, t, l, new EventHandler(chkEvent));
                                    t += 23;
                                    j++;
                                }
                            }
                            tab.AutoScroll = true;
                        }
                    }
                }
            }
            catch { }
        }

        public void Addchkbox(string text, string name, int t, int l, EventHandler onClickEvent)
        {
            chk chkClick = new chk(name, onClickEvent);
            chkbox = new CheckBox();
            tooltip = new ToolTip();
            chkbox.Text = text;
            chkbox.Name = name;
            chkbox.Top = t;
            chkbox.Left = l;
            chkbox.Size = new System.Drawing.Size(290, 23);
            chkbox.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chkbox.Click += onClickEvent;
            chkbox.Tag = chkClick;
            DataRow r = Utils.GetPriceRowbyCode(dtDichvu, "ServiceCode='" + name + "'");
            chkbox.Checked = r != null;
            chkbox.ForeColor = (r != null) ? Color.Red : Color.Black;
            tab.Controls.Add(chkbox);
            tooltip.SetToolTip(chkbox, text);
        }

        public void chkEvent(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            chk c = ctrl.Tag as chk;
            List<ServicePriceInf> lstPrice = ServicePriceBLL.ListServicePriceReal(c.index.ToString());
            string attach_Items = "False";
            if (lstPrice.Count > 0)
            {
                if (this.objectCode == 1)
                {
                    List<ServicePriceInf> lstPriceTemp = lstPrice.Where(v => v.ObjectCode == 1).ToList();
                    if (lstPriceTemp != null && lstPriceTemp.Count > 0)
                    {
                        DataRow r = Utils.GetPriceRowbyCode(this.dtDichvu, "ServiceCode='" + lstPriceTemp[0].ServiceCode + "'");
                        Int32 runNumber = this.dtDichvu.Rows.Count + 1;
                        if (r != null)
                        {
                            if (XtraMessageBox.Show(" Dịch vụ đã tồn tại, bạn muốn chỉ định thêm? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                            {
                                this.dtDichvu.Rows.Add(-1, lstPriceTemp[0].ServiceCode, ctrl.Text.ToString(), 1, lstPriceTemp[0].ObjectCode, lstPriceTemp[0].UnitPrice, lstPriceTemp[0].DisparityPrice, lstPriceTemp[0].DepartmentCode, 0, 0, 1, lstPriceTemp[0].Rowid, string.Empty, sReferenceCode, sUserid, 0, lstPriceTemp[0].UnitOfMeasureCode, runNumber, string.Empty, attach_Items);
                            }
                        }
                        else
                        {
                            this.dtDichvu.Rows.Add(-1, lstPriceTemp[0].ServiceCode, ctrl.Text.ToString(), 1, lstPriceTemp[0].ObjectCode, lstPriceTemp[0].UnitPrice, lstPriceTemp[0].DisparityPrice, lstPriceTemp[0].DepartmentCode, 0, 0, 1, lstPriceTemp[0].Rowid, string.Empty, sReferenceCode, sUserid, 0, lstPriceTemp[0].UnitOfMeasureCode, runNumber, string.Empty, attach_Items);
                        }
                        ctrl.ForeColor = (r != null) ? Color.Red : Color.Black;
                    }
                    else
                    {
                        Int32 runNumber = this.dtDichvu.Rows.Count + 1;
                        DataRow r = Utils.GetPriceRowbyCode(this.dtDichvu, "ServiceCode='" + lstPrice[0].ServiceCode + "'");
                        if (r != null)
                        {
                            if (XtraMessageBox.Show(" Dịch vụ đã tồn tại, bạn muốn chỉ định thêm? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                            {
                                this.dtDichvu.Rows.Add(-1, lstPrice[0].ServiceCode, ctrl.Text.ToString(), 1, lstPrice[0].ObjectCode, lstPrice[0].UnitPrice, lstPrice[0].DisparityPrice, lstPrice[0].DepartmentCode, 0, 0, 1, lstPrice[0].Rowid, string.Empty, sReferenceCode, sUserid, 0, lstPrice[0].UnitOfMeasureCode, runNumber, string.Empty, attach_Items);
                            }
                        }
                        else
                        {
                            this.dtDichvu.Rows.Add(-1, lstPrice[0].ServiceCode, ctrl.Text.ToString(), 1, lstPrice[0].ObjectCode, lstPrice[0].UnitPrice, lstPrice[0].DisparityPrice, lstPrice[0].DepartmentCode, 0, 0, 1, lstPrice[0].Rowid, string.Empty, sReferenceCode, sUserid, 0, lstPrice[0].UnitOfMeasureCode, runNumber, string.Empty, attach_Items);
                        }
                        ctrl.ForeColor = (r != null) ? Color.Red : Color.Black;
                    }
                }
                else
                {
                    foreach (var v in lstPrice)
                    {
                        if (this.objectCode == v.ObjectCode)
                        {
                            Int32 runNumber = this.dtDichvu.Rows.Count + 1;
                            DataRow r = Utils.GetPriceRowbyCode(this.dtDichvu, "ServiceCode='" + v.ServiceCode + "'");
                            if (r != null)
                            {
                                if (XtraMessageBox.Show(" Dịch vụ đã tồn tại, bạn muốn chỉ định thêm? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
                                {
                                    this.dtDichvu.Rows.Add(-1, v.ServiceCode, ctrl.Text.ToString(), 1, v.ObjectCode, v.UnitPrice, v.DisparityPrice, v.DepartmentCode, 0, 0, 1, v.Rowid, "", sReferenceCode, sUserid, 0, v.UnitOfMeasureCode, runNumber, string.Empty, attach_Items);
                                }
                            }
                            else
                            {
                                this.dtDichvu.Rows.Add(-1, v.ServiceCode, ctrl.Text.ToString(), 1, v.ObjectCode, v.UnitPrice, v.DisparityPrice, v.DepartmentCode, 0, 0, 1, v.Rowid, "", sReferenceCode, sUserid, 0, v.UnitOfMeasureCode, runNumber, string.Empty, attach_Items);
                            }
                            ctrl.ForeColor = (r != null) ? Color.Red : Color.Black;
                            break;
                        }
                    }
                }
                this.dtDichvu.AcceptChanges();
                this.gridControl_Service.DataSource = this.dtDichvu;
                this.TotalService(this.patientReceiveId);
            }
            else
            {
                XtraMessageBox.Show(" Dịch vụ chưa khai báo giá !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public class chk : CheckBox
        {
            public string index;
            public string Index
            {
                get
                {
                    return index;
                }
            }
            
            public chk(string index, EventHandler onClickEvent)
            {
                this.index = index;
                Click += onClickEvent;
            }
        }

        private void FloadListPackage()
        {
            try
            {
                dtPackage = ServicePackageBLL.DTServicePackage(string.Empty);
                gridControl_Package.DataSource = dtPackage;
            }
            catch { }
        }
        #endregion

        private void btChonGoi_Click(object sender, EventArgs e)
        {
            try
            {
                string sTemp = gridView_Package.GetRowCellValue(gridView_Package.FocusedRowHandle, "ServicePackageCode").ToString();
                var vlist = ServicePackageDetailBLL.ListChidinh(sTemp);
                Int32 runNumber = this.dtDichvu.Rows.Count + 1;
                string attach_Items = "False";
                foreach (var v in vlist)
                {
                    if (this.objectCode.Equals(1))
                    {
                        if (v.ObjectCode == 2)
                        {
                            dtDichvu.Rows.Add(0, v.ServiceCode, v.ServiceName, 1, v.ObjectCode, v.ServicePrice, v.DisparityPrice, v.DepartmentCode, v.Status, v.Paid, v.Del, v.RowIDPrice, v.ServicePackageCode, sReferenceCode, sUserid, 0, v.UnitOfMeasureCode, runNumber, string.Empty, attach_Items);
                            runNumber++;
                        }
                    }
                    else
                    {
                        //if (v.ObjectCode == objectCode)
                        //{
                        //    dtDichvu.Rows.Add(0, v.ServiceCode, v.ServiceName, 1, v.ObjectCode, v.ServicePrice, v.DisparityPrice, v.DepartmentCode, v.Status, v.Paid, v.Del, v.RowIDPrice, v.ServicePackageCode, sReferenceCode, sUserid, 0, v.UnitOfMeasureCode, runNumber, string.Empty, attach_Items);
                        //    runNumber++;
                        //}

                        dtDichvu.Rows.Add(0, v.ServiceCode, v.ServiceName, 1, objectCode, v.ServicePrice, v.DisparityPrice, v.DepartmentCode, v.Status, v.Paid, v.Del, v.RowIDPrice, v.ServicePackageCode, sReferenceCode, sUserid, 0, v.UnitOfMeasureCode, runNumber, string.Empty, attach_Items);
                        runNumber++;
                    }
                }
                this.EnableAll(false);
                this.TotalService(patientReceiveId);
                this.gridControl_Service.DataSource = this.dtDichvu;

            }
            catch { }
        }

        private void gridView_Package_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                string sTemp = view.GetFocusedRowCellValue(col_Service_Package_Code).ToString();
                gridControl_PackageDetail.DataSource = ServicePackageDetailBLL.TablePackageDetail(sTemp);
            }
            catch { }
        }

        private void xtabMain_Click(object sender, EventArgs e)
        {
            if (xtabMain.SelectedTabPageIndex == 1)
                this.FloadListPackage();
        }

        private void schlk_Service_EditValueChanged(object sender, EventArgs e)
        {
            string tempCode = schlk_Service.EditValue.ToString();
            string tempName = schlk_Service.Text.ToString();
            List<ServicePriceInf> lstPrice = ServicePriceBLL.ListServicePriceReal(tempCode);
            if (lstPrice.Count > 0)
            {
                string attach_Items = "False";
                foreach (var v in lstPrice)
                {
                    Int32 runNumber = this.dtDichvu.Rows.Count + 1;
                    if (this.objectCode == 1)
                    {
                        if (this.objectCode == v.ObjectCode)
                        {
                            DataRow r = Utils.GetPriceRowbyCode(this.dtDichvu, "ServiceCode='" + v.ServiceCode + "'");
                            if (r != null)
                            {
                                if (XtraMessageBox.Show(" Dịch vụ đã tồn tại, bạn muốn chỉ định thêm? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                                {
                                    this.dtDichvu.Rows.Add(-1, v.ServiceCode, tempName, 1, v.ObjectCode, v.UnitPrice, v.DisparityPrice, v.DepartmentCode, 0, 0, 1, v.Rowid, string.Empty, sReferenceCode, sUserid, 0, v.UnitOfMeasureCode, runNumber, string.Empty, attach_Items);
                                }
                            }
                            else
                            {
                                this.dtDichvu.Rows.Add(-1, v.ServiceCode, tempName, 1, v.ObjectCode, v.UnitPrice, v.DisparityPrice, v.DepartmentCode, 0, 0, 1, v.Rowid, string.Empty, sReferenceCode, sUserid, 0, v.UnitOfMeasureCode, runNumber, string.Empty, attach_Items);
                            }
                            break;
                        }
                        else
                        {
                            DataRow r = Utils.GetPriceRowbyCode(this.dtDichvu, "ServiceCode='" + v.ServiceCode + "'");
                            if (r != null)
                            {
                                if (XtraMessageBox.Show(" Dịch vụ đã tồn tại, bạn muốn chỉ định thêm? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                                {
                                    this.dtDichvu.Rows.Add(-1, v.ServiceCode, tempName, 1, v.ObjectCode, v.UnitPrice, v.DisparityPrice, v.DepartmentCode, 0, 0, 1, v.Rowid, string.Empty, sReferenceCode, sUserid, 0, v.UnitOfMeasureCode, runNumber, string.Empty, attach_Items);
                                }
                            }
                            else
                            {
                                this.dtDichvu.Rows.Add(-1, v.ServiceCode, tempName, 1, v.ObjectCode, v.UnitPrice, v.DisparityPrice, v.DepartmentCode, 0, 0, 1, v.Rowid, string.Empty, sReferenceCode, sUserid, 0, v.UnitOfMeasureCode, runNumber, string.Empty, attach_Items);
                            }
                            break;
                        }
                    }
                    else
                    {
                        if (this.objectCode == v.ObjectCode)
                        {
                            DataRow r = Utils.GetPriceRowbyCode(this.dtDichvu, "ServiceCode='" + v.ServiceCode + "'");
                            if (r != null)
                            {
                                if (XtraMessageBox.Show(" Dịch vụ đã tồn tại, bạn muốn chỉ định thêm? ", "Bệnh viện điện tử .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
                                {
                                    this.dtDichvu.Rows.Add(-1, v.ServiceCode, tempName, 1, v.ObjectCode, v.UnitPrice, v.DisparityPrice, v.DepartmentCode, 0, 0, 1, v.Rowid, string.Empty, sReferenceCode, sUserid, 0, v.UnitOfMeasureCode, runNumber, string.Empty, attach_Items);
                                }
                            }
                            else
                            {
                                this.dtDichvu.Rows.Add(-1, v.ServiceCode, tempName, 1, v.ObjectCode, v.UnitPrice, v.DisparityPrice, v.DepartmentCode, 0, 0, 1, v.Rowid, string.Empty, sReferenceCode, sUserid, 0, v.UnitOfMeasureCode, runNumber, string.Empty, attach_Items);
                            }
                            break;
                        }
                    }
                }
                this.dtDichvu.AcceptChanges();
                this.gridControl_Service.DataSource = this.dtDichvu;
                this.TotalService(patientReceiveId);
            }
            else
            {
                XtraMessageBox.Show(" Dịch vụ chưa khai báo giá !", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            this.EnableAll(false);
            if (this.bChkNgayCD)
            {
                this.dtNgayCD.Properties.ReadOnly = false;
                this.dtNgayCD.Enabled = false;
            }
            else
            {
                this.dtNgayCD.Properties.ReadOnly = true;
                this.dtNgayCD.Enabled = false;
            }
            this.txtAmount.Text = this.txtBhytPay.Text = this.txtPatientPay.Text = "0";
            this.InitGrid(this.patientReceiveId);
        }

        private void EnableAll(bool b)
        {
            this.butNew.Enabled = b;
            this.butSave.Enabled = !b;
            this.butPrint.Enabled = !b;
            this.butDelete.Enabled = !b;
            this.butUndo.Enabled = !b;
            if (this.bChkNgayCD)
            {
                this.dtNgayCD.Properties.ReadOnly = !b;
                this.dtNgayCD.Enabled = b;
            }
            else
            {
                this.dtNgayCD.Properties.ReadOnly = false;
                this.dtNgayCD.Enabled = !b;
            }
            this.gridView_Service.OptionsBehavior.Editable = !b;
        }

        private void butUndo_Click(object sender, EventArgs e)
        {
            this.EnableAll(true);
        }
        
        private void dtNgayCD_Validated(object sender, EventArgs e)
        {
            InitGrid(patientReceiveId);
        }

        private void gridView_Service_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                string serviceCodeTemp = view.GetFocusedRowCellValue("ServiceCode").ToString();
                if (view.FocusedColumn.FieldName == "ObjectCode" && view.ActiveEditor is GridLookUpEdit)
                {
                    DevExpress.XtraEditors.GridLookUpEdit searchObject;
                    searchObject = (GridLookUpEdit)view.ActiveEditor;
                    ///DataTable table = this.rep_ObjectCode.DataSource as DataTable;
                    DataTable table = ServicePriceBLL.TableObjectForService(serviceCodeTemp);
                    this.cloneObject = new DataView(table);
                    ///DataRow row = view.GetDataRow(view.FocusedRowHandle);
                    ///this.cloneObject.RowFilter = "ObjectCode >0 ";
                    searchObject.Properties.DataSource = this.cloneObject;
                }
            }
            catch { }
        }

        private void frmChiDinhDichVu_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2: this.butNew_Click(sender, e); break;
                case Keys.F3: this.butSave_Click(sender, e); break;
                case Keys.F6: this.butPrint_Click(sender, e); break;
            }
        }

        private void repbtn_ItemsAttach_Click(object sender, EventArgs e)
        {
            try
            {
                decimal suggestedID_ref = Convert.ToDecimal(this.gridView_Service.GetFocusedRowCellValue(this.col_RowID).ToString());
                string serviceCode_ref = this.gridView_Service.GetFocusedRowCellValue(this.col_ServiceCode).ToString();
                frmKB_ThuocVTTHKemTheo frm = new frmKB_ThuocVTTHKemTheo(suggestedID_ref, serviceCode_ref, this.sMakpOder, this.sUserid, this.sReferenceCode, this.patientCode, iPatientType, this.patientReceiveId, this.objectCode, this.shiftWork, this.dtWorking);
                frm.ShowDialog(this);
            }
            catch { return; }
        }

        private void gridView_Service_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.Name == "col_ItemsAttach")
            {
                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                string attach_ItemsTemp = this.gridView_Service.GetRowCellValue(e.RowHandle, "Attach_Items").ToString();
                if (attach_ItemsTemp.Equals("False"))
                {
                    btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                    btn.Buttons[0].Enabled = false;
                    e.RepositoryItem = btn;
                }
            }
        }

    }
}