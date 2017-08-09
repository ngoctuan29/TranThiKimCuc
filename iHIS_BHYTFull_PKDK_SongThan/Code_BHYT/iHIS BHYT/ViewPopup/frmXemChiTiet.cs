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

namespace Ps.Clinic.ViewPopup
{
    public partial class frmXemChiTiet : DevExpress.XtraEditors.XtraForm
    {
        PictureBox _pic;
        public frmXemChiTiet(PictureBox pic)
        {
            InitializeComponent();
            _pic = pic;
        }

        private void frmPatientDetails_Load(object sender, EventArgs e)
        {
            picPopup.Image = _pic.Image;
        }

        private void grDetails_Paint(object sender, PaintEventArgs e)
        {
        }

        private void grDetails_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void zoomTrackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}