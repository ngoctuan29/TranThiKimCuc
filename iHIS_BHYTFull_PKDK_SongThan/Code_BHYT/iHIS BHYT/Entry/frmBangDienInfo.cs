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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors;
using ClinicModel;
using ClinicBLL;
using ClinicLibrary;
using DevExpress.XtraTab;
using System.Text.RegularExpressions;
using System.IO;

namespace Ps.Clinic.Entry
{
    public partial class frmBangDienInfo : DevExpress.XtraEditors.XtraForm
    {
        public DataTable tableDepartment = new DataTable();
        private string groupCode = "KCB";
        public frmBangDienInfo()
        {
            InitializeComponent();
        }

        private void frmBangDienInfo_Load(object sender, EventArgs e)
        {
            this.tableDepartment.Columns.Add(new DataColumn("DepartmentCode", typeof(string)));
            this.tableDepartment.Columns.Add(new DataColumn("DepartmentName", typeof(string)));
            this.tableDepartment.Columns.Add(new DataColumn("Chon", typeof(int)));
            this.LoadTableDepartment();
        }
        
        private void LoadTableDepartment()
        {
            DataTable tableTemp = DepartmentBLL.DTDepartment(this.groupCode);
            if (tableTemp != null && tableTemp.Rows.Count > 0)
            {
                foreach(DataRow row in tableTemp.Rows)
                {
                    DataRow dr = this.tableDepartment.NewRow();
                    dr["DepartmentCode"] = row["DepartmentCode"];
                    dr["DepartmentName"] = row["DepartmentName"];
                    dr["Chon"] = 0;
                    this.tableDepartment.Rows.Add(dr);
                }
            }
            this.gridControl_Data.DataSource = this.tableDepartment;
        }
        
        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tableDepartment.Select("Chon=1").Length > 0)
                {
                    iHISLCD.frmBangDien frm = new iHISLCD.frmBangDien(this.tableDepartment.Select("Chon=1").CopyToDataTable());
                    this.Close();
                    frm.Show();
                }
                else
                    XtraMessageBox.Show("Chọn phòng khám hiển thị màn hình CLD!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex){
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}