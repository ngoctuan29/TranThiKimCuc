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
    public partial class frmChonKho : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string s_module = string.Empty;
        public string s_RepositoryCode = string.Empty;
        private string s_Usercode = string.Empty;
        private string[] ArrtempRep;
        private Int32 groupCode = 0;

        public frmChonKho(string _userlogin, Int32 _groupCode)
        {
            InitializeComponent();
            this.s_Usercode = _userlogin;
            this.groupCode = _groupCode;
        }

        private void FloadData()
        {
            try
            {
                this.SelectRepository(s_Usercode);
                string sTempRep = string.Empty;
                if (ArrtempRep.Length > 0)
                {
                    for (int i = 0; i < ArrtempRep.Length; i++)
                        sTempRep += "'" + ArrtempRep[i].ToString() + "',";
                }
                List<RepositoryCatalog_Inf> lstRepository = RepositoryCatalog_BLL.ListRepositoryForBHYT(0, this.groupCode, sTempRep.TrimEnd(','));
                this.lkupKho.Properties.DataSource = lstRepository;
                this.lkupKho.Properties.DisplayMember = "RepositoryName";
                this.lkupKho.Properties.ValueMember = "RepositoryCode";
                if (lstRepository.Count == 1)
                {
                    this.lkupKho.ItemIndex = 0;
                    this.s_RepositoryCode = lkupKho.EditValue.ToString();
                    this.Close();
                }
                else
                    this.lkupKho.ItemIndex = 0;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
                
        private void SelectRepository(string employeeCode)
        {
            try
            {
                List<EmployeeInf> lstRep = new List<EmployeeInf>();
                lstRep = EmployeeBLL.ListEmployee(employeeCode);
                foreach (var dr in lstRep)
                {
                    this.ArrtempRep = dr.PermissionRepository.Split(',');
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Convert.ToString(lkupKho.EditValue)))
                {
                    this.s_RepositoryCode = lkupKho.EditValue.ToString();
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Chọn kho xuất bán hoặc duyệt đơn thuốc khoa phòng!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void frmChonKhoXuatBan_Load(object sender, EventArgs e)
        {
            this.FloadData();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}