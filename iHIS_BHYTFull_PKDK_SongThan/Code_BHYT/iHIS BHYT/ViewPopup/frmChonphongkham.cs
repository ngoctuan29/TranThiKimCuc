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
    public partial class frmChonphongkham : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Int32 imodule = 0;
        public string s_mapk = string.Empty, s_namepk = string.Empty, s_Usercode = string.Empty, employeeCodeDoctor = string.Empty, employeeNameDoctor = string.Empty, employeeCodeDoing = string.Empty, employeeCodeDoingName = string.Empty;
        private string[] ArrPart;
        public frmChonphongkham(string _userlogin, Int32 _module)
        {
            InitializeComponent();
            this.s_Usercode = _userlogin;
            this.imodule = _module;
        }
        private void FloadPhongkham()
        {
            try
            {
                string sCode = string.Empty;
                var vEmployee = EmployeeBLL.ListEmployee(s_Usercode);
                List<ServiceMenuForDepartmentINF> lstMenuPart = ServiceMenuBLL.ListServiceMenuForDepartmentINF(imodule);
                foreach (var v in vEmployee)
                {
                    ArrPart = v.PermissionDepart.Split(',');
                }
                for (int i = 0; i < ArrPart.Length; i++)
                {
                    sCode += "'" + ArrPart[i].ToString() + "',";
                }
                
                this.Lkupkhoaphong.Properties.DataSource = ServiceMenuBLL.DT_MenuDeparForEmployee(imodule, sCode.TrimEnd(','));
                this.Lkupkhoaphong.Properties.DisplayMember = "DepartmentName";
                this.Lkupkhoaphong.Properties.ValueMember = "DepartmentCode";

            }
            catch { }
        }

        private void btChonkham_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(Lkupkhoaphong.EditValue)))
                {
                    XtraMessageBox.Show("Chọn phòng khám/phòng thực hiện.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Lkupkhoaphong.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(Convert.ToString(this.lkupEmployee.EditValue)))
                {
                    XtraMessageBox.Show("Chọn bác sĩ khám bệnh.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lkupEmployee.Focus();
                    return;
                }
                else
                {
                    this.s_mapk = Lkupkhoaphong.EditValue.ToString();
                    this.s_namepk = Lkupkhoaphong.Text;
                    this.employeeCodeDoctor = this.lkupEmployee.EditValue.ToString();
                    this.employeeNameDoctor = this.lkupEmployee.Text.ToString();
                    this.employeeCodeDoing = this.employeeCodeDoctor = this.lkupEmployee.EditValue.ToString();
                    this.Close();
                }
            }
            catch 
            {
                return;
            }
        }

        private void frmChonphongkham_Load(object sender, EventArgs e)
        {
            this.FloadPhongkham();
            this.Lkupkhoaphong.Focus();
        }

        private void butiClose_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void Lkupkhoaphong_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.lkupEmployee.Properties.DataSource = EmployeeBLL.TableEmployeeForPosition("3", this.Lkupkhoaphong.EditValue.ToString());
                this.lkupEmployee.Properties.DisplayMember = "EmployeeName";
                this.lkupEmployee.Properties.ValueMember = "EmployeeCode";
            }
            catch { }
        }
    }
}