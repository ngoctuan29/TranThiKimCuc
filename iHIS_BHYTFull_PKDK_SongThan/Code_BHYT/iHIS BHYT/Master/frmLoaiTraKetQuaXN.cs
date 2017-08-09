using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;

namespace Ps.Clinic.Master
{
    public partial class frmLoaiTraKetQuaXN : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string codeTemp = string.Empty;
        private string userid = string.Empty;
        private DataTable tableLaboratory = new DataTable();
        private DataTable tableResult = new DataTable();
        private string serviceGroupCode = "XN";
        public frmLoaiTraKetQuaXN(string _userid)
        {
            InitializeComponent();
            this.userid = _userid;
        }

        private void frmLoaiTraKetQuaXN_Load(object sender, EventArgs e)
        {
            try
            {
                this.butRemove.Enabled = false;
                this.butAdd.Enabled = false;
                this.LoadLaboratory();
                this.LoadLabResult();
                DataSet dsTypeMenu = new DataSet();
                dsTypeMenu.ReadXml(Utils.CurrentPathApplication() + "\\xml\\LabTypeResult.xml");
                this.lkupTypeResult.Properties.DataSource = dsTypeMenu.Tables[0];
                this.lkupTypeResult.Properties.DisplayMember = "Title";
                this.lkupTypeResult.Properties.ValueMember = "Value";
                this.lkupTypeResult.EditValue = "1";

                this.repItem_TypeResult.DataSource = dsTypeMenu.Tables[0];
                this.repItem_TypeResult.DisplayMember = "Title";
                this.repItem_TypeResult.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void LoadLaboratory()
        {
            this.tableLaboratory = LaboratoryResultDescriptionBLL.TableLabTypeResult(this.serviceGroupCode);
            this.gridControl_Laboratory.DataSource = tableLaboratory;
            this.gridView_Laboratory.Columns["ServiceCategoryName"].Group();
            this.gridView_Laboratory.ExpandAllGroups();
        }

        private void LoadLabResult()
        {
            this.gridControl_LabResult.DataSource = LaboratoryResultDescriptionBLL.TableLabTypeResultTemplate(this.serviceGroupCode, Convert.ToInt32(this.lkupTypeResult.EditValue));
            this.gridView_LabResult.Columns["ServiceCategoryName"].Group();
            this.gridView_LabResult.ExpandAllGroups();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(this.lkupTypeResult.EditValue) == 0)
                {
                    XtraMessageBox.Show("Chọn hình thức trả kết quả xét nghiệm.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    string serviceCode = this.gridView_Laboratory.GetRowCellValue(this.gridView_Laboratory.FocusedRowHandle, col_ServiceCode).ToString();
                    LaboratoryResultDescriptionBLL.IULabTypeResult(serviceCode, Convert.ToInt32(this.lkupTypeResult.EditValue), this.userid);
                    this.LoadLaboratory();
                    this.LoadLabResult();
                }
            }
            catch { 
                XtraMessageBox.Show("Chọn xét nghiệm cần khai báo trả kết quả.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void butRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string serviceCode = this.gridView_LabResult.GetRowCellValue(this.gridView_LabResult.FocusedRowHandle, colResult_ServiceCode).ToString();
                LaboratoryResultDescriptionBLL.DelLabTypeResult(serviceCode);
                this.LoadLaboratory();
                this.LoadLabResult();
            }
            catch(Exception ex) {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_LabResult_Click(object sender, EventArgs e)
        {
            this.butRemove.Enabled = true;
            this.butAdd.Enabled = false;
        }

        private void gridView_Laboratory_Click(object sender, EventArgs e)
        {
            this.butRemove.Enabled = false;
            this.butAdd.Enabled = true;
        }

        private void lkupTypeResult_EditValueChanged(object sender, EventArgs e)
        {
            this.LoadLabResult();
        }

        private void butRefesh_Click(object sender, EventArgs e)
        {
            this.LoadLaboratory();
        }
    }
}