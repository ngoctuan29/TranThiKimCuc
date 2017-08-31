using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ps.Clinic.ViewPopup
{
    public partial class ChoseService : DevExpress.XtraEditors.XtraForm
    {
        public DataTable dt = new DataTable();
        public ChoseService()
        {
            InitializeComponent();
        }

        private void ChoseService_Load(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = dt;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            this.dt = (DataTable)gridControl1.DataSource;
            this.Close();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}