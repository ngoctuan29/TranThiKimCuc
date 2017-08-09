using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using Ps.Clinic.ViewPopup;
using Ps.Clinic.Master;
using Ps.Clinic.Entry;
using DevExpress.XtraGrid.Views.Grid;
using System.Net;
using DevExpress.XtraTab;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
namespace Ps.Clinic.ViewPopup
{
    public partial class frmVP_ChonQuyenSo : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Int32 rowid = -1;
        private string employeeCode = string.Empty;
        private Int32 notetype = 0;
        public string symbol = string.Empty;
        public frmVP_ChonQuyenSo(string _employeeCode, Int32 _notetype)
        {
            InitializeComponent();
            this.employeeCode = _employeeCode;
            this.notetype = _notetype;
        }
        private void LoadNoteBook()
        {
            this.LkupNoteBook.Properties.DataSource = Fee_NoteBookBLL.ListNoteBook(rowid).Where(s => s.Hide == 0 & s.NoteType == this.notetype);
            this.LkupNoteBook.Properties.DisplayMember = "NoteBookName";
            this.LkupNoteBook.Properties.ValueMember = "RowID";
        }

        private void btnAgree_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(this.LkupNoteBook.EditValue)))
                {
                    XtraMessageBox.Show("Chọn quyển sổ để thu tiền.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.LkupNoteBook.Focus();
                    return;
                }
                else
                {
                    this.rowid = Convert.ToInt32(this.LkupNoteBook.EditValue.ToString());
                    this.Close();
                }
            }
            catch 
            {
                return;
            }
        }

        private void frmVP_ChonQuyenSo_Load(object sender, EventArgs e)
        {
            this.LoadNoteBook();
            this.LkupNoteBook.Focus();
        }

        private void LkupNoteBook_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lkupEdit = sender as LookUpEdit;
            this.symbol = lkupEdit.GetColumnValue("Symbol").ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();            
        }
        
    }
}