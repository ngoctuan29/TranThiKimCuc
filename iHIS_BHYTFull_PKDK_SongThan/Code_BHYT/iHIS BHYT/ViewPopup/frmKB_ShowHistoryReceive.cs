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
    public partial class frmKB_ShowHistoryReceive : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public decimal patientReceiveID = 0;
        private string patientCode = string.Empty;
        private DateTime dtimeServer = new DateTime();
        private List<PatientViewInf> lstpatient = new List<PatientViewInf>();
        public frmKB_ShowHistoryReceive(List<PatientViewInf>  _lstpatient)
        {
            InitializeComponent();
            this.lstpatient = _lstpatient;
        }
        
        private void butClosed_Click(object sender, EventArgs e)
        {
            this.Close();            
        }
        
        private void frmKB_ShowHistoryReceive_Load(object sender, EventArgs e)
        {
            try
            {
                this.dtimeServer = Utils.DateServer();
                this.groupInfo.Text = "Bệnh nhân tiếp nhận nhiều lần trong ngày: " + this.dtimeServer.ToString("dd/MM/yyyy") + " - chưa kết thúc hồ sơ khám bệnh.";
                this.gridControl_History.DataSource = this.lstpatient;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView_History_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                Int32 statusTemp = 0;
                if (e.RowHandle >= 0)
                {
                    statusTemp = Convert.ToInt32(view.GetRowCellDisplayText(e.RowHandle, view.Columns["Status"]));
                    if (statusTemp == 1)
                        e.Appearance.ForeColor = Color.Salmon;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void gridView_History_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int status = Convert.ToInt32(gridView_History.GetRowCellValue(this.gridView_History.FocusedRowHandle, this.colHistory_Status));
                if (status == 0)
                    this.patientReceiveID = Convert.ToDecimal(this.gridView_History.GetRowCellValue(this.gridView_History.FocusedRowHandle, this.colHistory_RefID));
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message, "iHIS Bệnh Viện Điện Tử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}