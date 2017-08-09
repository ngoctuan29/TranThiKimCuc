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
    public partial class frmKyHieu : DevExpress.XtraEditors.XtraForm
    {
        //MasterDataContext db = new MasterDataContext();
        public frmKyHieu()
        {
            InitializeComponent();
        }

        private void frmKyHieu_Load(object sender, EventArgs e)
        {
            //gridControl_Symbol.DataSource = db.Symbol_Tooths;
        }

        private void gridView_Symbol_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            try
            {
                //db.SubmitChanges();
            }
            catch
            {
                XtraMessageBox.Show("Lỗi cập nhật danh mục ký hiệu! \t\nHãy thử lại.", "Bệnh viện điện tử .NET");
                this.Close();
            }
        }
    }
}