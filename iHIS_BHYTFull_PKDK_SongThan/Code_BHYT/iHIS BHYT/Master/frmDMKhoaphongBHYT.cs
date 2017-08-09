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
    public partial class frmDMKhoaphongBHYT : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string userid = string.Empty;
        public frmDMKhoaphongBHYT(string _userid)
        {
            InitializeComponent();
            this.userid = _userid;
        }

        private void frmDMKhoaphongBHYT_Load(object sender, EventArgs e)
        {
            this.gridControl.DataSource = DepartmentBLL.DTDepartmentBHYT();
        }
    }
}