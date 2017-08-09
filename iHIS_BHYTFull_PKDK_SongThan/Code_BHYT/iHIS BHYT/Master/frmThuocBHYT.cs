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
    public partial class frmThuocBHYT : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable tableData = new DataTable();
        private string userid = string.Empty;
        public frmThuocBHYT(string _userid)
        {
            InitializeComponent();
            this.userid = _userid;
        }

        private void frmThuocBHYT_Load(object sender, EventArgs e)
        {
            this.gridControl_Data.DataSource = Catalog_BHYTBLL.TableDMThuoc_BHYT();
        }
    }
}