using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Linq;
using System.Linq;

namespace Ps.Clinic.Master
{
    public partial class frmVungRang : DevExpress.XtraEditors.XtraForm
    {
        //MasterDataContext db = new MasterDataContext();
        public frmVungRang()
        {
            InitializeComponent();
        }

        private void frmVungRang_Load(object sender, EventArgs e)
        {
            //gridControl_Area_Tooth.DataSource = db.Area_Tooth_Colors;
        }

        private void gridView_Area_Tooth_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            try
            {
                //db.SubmitChanges();
            }
            catch
            {
                XtraMessageBox.Show("Lỗi cập nhật danh mục mô tả vùng răng! \t\nHãy thử lại.", "Bệnh viện điện tử .NET");
                this.Close();
            }
        }
    }
}