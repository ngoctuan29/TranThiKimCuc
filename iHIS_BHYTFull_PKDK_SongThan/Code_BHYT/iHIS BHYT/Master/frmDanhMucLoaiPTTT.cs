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
using DevExpress.XtraGrid.Views.Grid;
using ClinicLibrary;
using ClinicBLL;
using ClinicModel;

namespace Ps.Clinic.Master
{
    public partial class frmDanhMucLoaiPTTT : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmDanhMucLoaiPTTT()
        {
            InitializeComponent();
        }

        private void frmDanhMucLoaiPTTT_Load(object sender, EventArgs e)
        {
            this.gridControl_Advice.DataSource = Catalog_BHYTBLL.TableDMLoaiPT_TT();
        }
        
    }
}