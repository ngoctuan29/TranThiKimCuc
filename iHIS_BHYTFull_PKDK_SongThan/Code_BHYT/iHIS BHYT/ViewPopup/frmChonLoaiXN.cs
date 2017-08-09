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
    public partial class frmChonLoaiXN : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string s_module = string.Empty;
        public string s_mapk = "";//, s_LoaiXN = "";
        private string s_Usercode = "";
        private string[] ArrPart;
        //private List<ServiceCategoryInf> lstLoaiXN = new List<ServiceCategoryInf>();
        public frmChonLoaiXN(string _userlogin, string module)
        {
            InitializeComponent();
            s_Usercode = _userlogin;
            s_module = module;
        }
        private void FloadPhongkham()
        {
            try
            {
                string sCode="";
                var vEmployee = EmployeeBLL.ListEmployee(s_Usercode);
                foreach (var v in vEmployee)
                {
                    ArrPart = v.PermissionDepart.Split(',');
                }
                for(int i=0;i<ArrPart.Length;i++)
                {
                    sCode += "'" + ArrPart[i].ToString() + "',";
                }
                List<DepartmentInf> lsttemp = new List<DepartmentInf>();
                lsttemp = DepartmentBLL.ListDepartment(s_module, sCode.TrimEnd(','));

                Lkupkhoaphong.Properties.DataSource = lsttemp;
                Lkupkhoaphong.Properties.DisplayMember = "DepartmentName";
                Lkupkhoaphong.Properties.ValueMember = "DepartmentCode";

                //lkXetNghiem.Properties.DataSource = ServiceCategoryBLL.ListServiceCategory(s_module, "");
                //lkXetNghiem.Properties.DisplayMember = "ServiceCategoryName";
                //lkXetNghiem.Properties.ValueMember = "ServiceCategoryCode";
            }
            catch { }
        }

        private void btChonkham_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!string.IsNullOrEmpty(Convert.ToString(Lkupkhoaphong.EditValue)) && !string.IsNullOrEmpty(Convert.ToString(lkXetNghiem.EditValue)))
                //{
                if (!string.IsNullOrEmpty(Convert.ToString(Lkupkhoaphong.EditValue)))
                {
                    s_mapk = Lkupkhoaphong.EditValue.ToString();
                    //s_LoaiXN = lkXetNghiem.EditValue.ToString();
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Chọn phòng xét nghiệm để lấy mẫu!","Bệnh viện điện tử .NET");
                    return;
                }
            }
            catch 
            {
                return;
            }
        }

        private void frmChonLoaiXN_Load(object sender, EventArgs e)
        {
            FloadPhongkham();
        }

        private void butiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}