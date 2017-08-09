using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ClinicBLL;
using ClinicModel;
using DevExpress.XtraEditors.Controls;
namespace Ps.Clinic.Master
{
    public partial class frmNhomVienPhiBHYT : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataTable dt = new DataTable();
        public frmNhomVienPhiBHYT()
        {
            InitializeComponent();
        }

        private void frmNhomVienPhiBHYT_Load(object sender, EventArgs e)
        {
            gridControl_ServiceGroup.DataSource = Catalog_BHYTBLL.TableServiceGroup_BHYT();
        }

        private void gridView_ServiceGroup_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

        }

        private void gridControl_ServiceGroup_ProcessGridKey(object sender, KeyEventArgs e)
        {
           
        }
    }
}