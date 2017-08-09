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
using DevExpress.XtraGrid.Views.Grid;
using ClinicLibrary;
using ClinicBLL;
using ClinicModel;
namespace Ps.Clinic.Master
{
    public partial class frmMapMachine : DevExpress.XtraEditors.XtraForm
    {
        private DataTable tableCategory = new DataTable();
        private string userID = string.Empty;
        public frmMapMachine(string _userID)
        {
            InitializeComponent();
            this.userID = _userID;
        }

        private void frmMapMachine_Load(object sender, EventArgs e)
        {
            try
            {
                this.repItem_CategoryCode.DataSource = ServiceCategoryBLL.DTServiceCategory("XN", "");
                this.repItem_CategoryCode.DisplayMember = "ServiceCategoryName";
                this.repItem_CategoryCode.ValueMember = "ServiceCategoryCode";
                this.LoadData();
            }
            catch { return; }
        }

        private void LoadData()
        {
            this.tableCategory = LaboratoryResultDescriptionBLL.TableCategoryForMachine(string.Empty);
            this.gridControl_Machine.DataSource = this.tableCategory;
        }

        

    }
}