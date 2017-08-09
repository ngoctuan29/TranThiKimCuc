using System;
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
using DevExpress.XtraTab;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
namespace Ps.Clinic.ViewPopup
{
    public partial class frmBaoCao_TKeLuotKhamBenh : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmBaoCao_TKeLuotKhamBenh()
        {
            InitializeComponent();
        }

        private void frmBaoCao_TKeLuotKhamBenh_Load(object sender, EventArgs e)
        {
            try
            {
                this.GetData();
            }
            catch (Exception ex){
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .Net,", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void GetData()
        {
            this.gridControl_result.DataSource = rpt_General_BLL.TableCountReceive();
        }
        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.GetData();
            }
            catch
            {
                return;
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            this.gridControl_result.ShowRibbonPrintPreview();
        }
    }
}