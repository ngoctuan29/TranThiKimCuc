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
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using Ps.Clinic.ViewPopup;
using Ps.Clinic.Master;
using Ps.Clinic.Entry;
using DevExpress.XtraGrid.Views.Grid;
using System.Net;
using DevExpress.XtraTab;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
namespace Ps.Clinic.ViewPopup
{
    public partial class frmDepartmentOther : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string usercode = string.Empty;
        private string departmentCode = string.Empty;
        private string patientCode = string.Empty;
        private decimal patientReceiveID = 0, receiptID = 0;
        private string serviceCode = string.Empty, referenceCode = string.Empty, employeeCodeDoctor = string.Empty, shiftWork = string.Empty;
        public bool reload = false;
        private Int32 objectCode = 0, patientType = 0, paid = 0;
        private string serviceGroupCode = string.Empty, serviceCategoryCode = string.Empty;
        public Int32 status = 0;
        public frmDepartmentOther(string _userlogin, string _departmentCode, string _patientCode, decimal _patientReceiveID, string _serviceCode, Int32 _objectCode, Int32 _patientType, string _referenceCode, Int32 _paid, decimal _receiptID, string _serviceGroupCode, string _serviceCategoryCode, string _employeeCodeDoctor, int _status,string _shiftWork)
        {
            InitializeComponent();
            this.usercode = _userlogin;
            this.departmentCode = _departmentCode;
            this.patientCode = _patientCode;
            this.patientReceiveID = _patientReceiveID;
            this.serviceCode = _serviceCode;
            this.objectCode = _objectCode;
            this.patientType = _patientType;
            this.referenceCode = _referenceCode;
            this.paid = _paid;
            this.receiptID = _receiptID;
            this.serviceGroupCode = _serviceGroupCode;
            this.serviceCategoryCode = _serviceCategoryCode;
            this.employeeCodeDoctor = _employeeCodeDoctor;
            this.status = _status;
            this.shiftWork = _shiftWork;
        }
        
        private void FloadPhongkham()
        {
            try
            {
                List<DepartmentInf> lsttemp = new List<DepartmentInf>();
                lsttemp = DepartmentBLL.ListDepartment(this.serviceGroupCode.Replace("'",""));
                this.Lkupkhoaphong.Properties.DataSource = lsttemp;
                this.Lkupkhoaphong.Properties.DisplayMember = "DepartmentName";
                this.Lkupkhoaphong.Properties.ValueMember = "DepartmentCode";
                this.Lkupkhoaphong.EditValue = this.departmentCode;
            }
            catch { }
        }

        private void btChonkham_Click(object sender, EventArgs e)
        {
            try
            {
                string note = string.Empty;
                if (this.serviceGroupCode == "KCB")
                {
                    note = "TIEPDON";
                    if (this.Lkupkhoaphong.EditValue.ToString() == this.departmentCode)
                    {
                        XtraMessageBox.Show("Phòng khám này đang chọn, vui lòng chọn phòng khác!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Lkupkhoaphong.Focus();
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(Convert.ToString(Lkupkhoaphong.EditValue)))
                {
                    //int result = SuggestedServiceReceiptBLL.UpdChangeDepartment(this.Lkupkhoaphong.EditValue.ToString(), this.patientCode, this.patientReceiveID, this.serviceCode, this.lkupCongKham.EditValue.ToString());
                    SuggestedServiceReceiptInf infSugges = new SuggestedServiceReceiptInf();
                    if (this.chkCongKham.Checked)
                        infSugges.ReceiptID = -1;
                    else
                        infSugges.ReceiptID = this.receiptID;
                    infSugges.DepartmentCode = this.Lkupkhoaphong.EditValue.ToString();
                    infSugges.ServiceCode = this.lkupCongKham.EditValue.ToString();
                    infSugges.ServicePrice = 0;
                    infSugges.DisparityPrice = 0;
                    infSugges.PatientCode = this.patientCode;
                    infSugges.Status = 0;
                    infSugges.Paid = this.paid;
                    infSugges.ServicePackageCode = string.Empty;
                    infSugges.EmployeeCode = this.usercode;
                    infSugges.Note = note;
                    infSugges.RefID = this.patientReceiveID;
                    infSugges.ObjectCode = this.objectCode;
                    infSugges.PatientType = this.patientType;
                    infSugges.WorkDate = Utils.DateTimeServer();
                    infSugges.ReferenceCode = this.referenceCode;
                    infSugges.DepartmentCodeOder = this.departmentCode;
                    infSugges.EmployeeCodeDoctor = this.employeeCodeDoctor;
                    infSugges.ShiftWork = this.shiftWork;
                    int result = SuggestedServiceReceiptBLL.Ins(infSugges, this.status);
                    if (result > 0)
                    {
                        this.reload = true;
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Chỉ được cho phép chuyển khi bệnh nhân chưa khám bệnh! \n\t Vui lòng xem lại.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng chọn phòng khám?", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Lkupkhoaphong.Focus();
                    return;
                }
                
            }
            catch 
            {
                return;
            }
        }

        private void frmDepartmentOther_Load(object sender, EventArgs e)
        {
            this.FloadPhongkham();
            DataTable tableService = ServicePriceBLL.DTListPrice_MapService(0, objectCode, patientType, this.serviceGroupCode, this.serviceCategoryCode);
            //this.lkupCongKham.Properties.DataSource = tableService.Select("ServiceCode <>'" + serviceCode + "'").CopyToDataTable();
            this.lkupCongKham.Properties.DataSource = tableService;
            this.lkupCongKham.Properties.ValueMember = "ServiceCode";
            this.lkupCongKham.Properties.DisplayMember = "ServiceName";
            this.lkupCongKham.EditValue = this.serviceCode;
            if (this.status == 0)
            {
                this.chkCongKham.Properties.ReadOnly = true;
                this.lkupCongKham.Properties.ReadOnly = true;
            }
        }

        private void butiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}