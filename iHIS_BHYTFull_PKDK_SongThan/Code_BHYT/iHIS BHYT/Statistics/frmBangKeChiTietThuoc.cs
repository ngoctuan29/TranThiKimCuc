using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClinicModel;
using ClinicBLL;
using ClinicLibrary;

namespace Ps.Clinic.Statistics
{
    public partial class frmBangKeChiTietThuoc : DevExpress.XtraEditors.XtraForm
    {
        public frmBangKeChiTietThuoc()
        {
            InitializeComponent();
            
        }
        
        private void butCount_Click(object sender, EventArgs e)
        {
            try
            {
                if (lkupKho.EditValue == null || lkupKho.Text.Trim() == "")
                {
                    XtraMessageBox.Show(" Vui lòng chọn kho cần xem thống kê.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lkupKho.Focus();
                }
                else if (this.txtDatefrom.Text.Trim() == string.Empty || this.txtDateto.Text.Trim() == string.Empty)
                {
                    XtraMessageBox.Show("Chọn ngày xem duyệt toa thuốc!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDatefrom.Focus();
                }
                else
                {
                    this.gridControl_Result.DataSource = rpt_Medicines_BLL.DT_Exp_MedicinesForPatients(lkupKho.EditValue.ToString(), txtDatefrom.Text.Trim(), txtDateto.Text.Trim(), sLookupItem.EditValue.ToString());
                }
            }
            catch { }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            gridControl_Result.ShowRibbonPrintPreview();
        }

        private void frmBangKeChiTietThuoc_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtDateto.EditValue = DateTime.Now.Date;
                this.txtDatefrom.EditValue = DateTime.Now.Date;
                lkupKho.Properties.DataSource = RepositoryCatalog_BLL.ListRepositoryForDuyetCap(0);
                lkupKho.Properties.DisplayMember = "RepositoryName";
                lkupKho.Properties.ValueMember = "RepositoryCode";

                sLookupItem.Properties.DataSource = ItemsBLL.ListItemsRef(0);
                sLookupItem.Properties.DisplayMember = "ItemName";
                sLookupItem.Properties.ValueMember = "ItemCode";

                this.rep_LK_ObjectCode.DataSource = ObjectBLL.DTObjectList(0);
                this.rep_LKDocTor.DataSource = EmployeeBLL.ListEmployee(string.Empty);
                this.repLK_Usage.DataSource = UsageBLL.DTUsageList(string.Empty);
                
            }
            catch { }
        }
    }
}