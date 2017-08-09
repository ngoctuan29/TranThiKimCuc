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
    public partial class frmRang : DevExpress.XtraEditors.XtraForm
    {
        //MasterDataContext db = new MasterDataContext();
        public frmRang()
        {
            InitializeComponent();
        }

        private void frmRang_Load(object sender, EventArgs e)
        {
            //gridControl_tooth.DataSource = db.Tooth_Categories;
        }

        private void gridView_tooth_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            try
            {
                //db.SubmitChanges();
            }
            catch
            {
                XtraMessageBox.Show("Lỗi cập nhật danh mục mô tả răng! \t\nHãy thử lại.", "Bệnh viện điện tử .NET");
                this.Close();
            }
        }
    }
}