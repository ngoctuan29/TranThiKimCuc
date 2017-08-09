using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
namespace Ps.Clinic.ViewPopup
{
    public partial class frm_Baocao_DateEnd : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtRep = new DataTable();
        public frm_Baocao_DateEnd()
        {
            InitializeComponent();
            
            dtRep = RepositoryCatalog_BLL.DTListRepositoryAll(0);
            dtRep.Rows.Add(0, "0", "Tất cả", 0, 0);
            lkupKho.Properties.DataSource = dtRep;
            lkupKho.Properties.DisplayMember = "RepositoryName";
            lkupKho.Properties.ValueMember = "RepositoryCode";
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            gridControl_DateEnd.ShowRibbonPrintPreview();
        }

        private void butCount_Click(object sender, EventArgs e)
        {
            try
            {
                if (lkupKho.EditValue == null || lkupKho.Text.Trim() == "")
                {
                    XtraMessageBox.Show(" Vui lòng chọn kho cần xem báo cáo.", "Bệnh viện điện tử .NET");
                    lkupKho.Focus();
                }
                else
                {
                    gridControl_DateEnd.DataSource = rpt_Medicines_BLL.DT_View_DateEnd(lkupKho.EditValue.ToString());
                }
            }
            catch { }
        }
    }
}