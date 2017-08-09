using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.Linq;
using System.Linq;
using ClinicBLL;
using ClinicLibrary;
using ClinicModel;
using DevExpress.XtraEditors.Controls;

namespace Ps.Clinic.Master
{
    public partial class frmShipmentDateEnd : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string userid = string.Empty;
        private DataTable dtItems = new DataTable();
        public frmShipmentDateEnd(string _userid)
        {
            InitializeComponent();
            userid = _userid;
        }

        private void frmShipmentDateEnd_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
            this.dtItems = InventoryBLL.TableViewShipmentDateEnd();
            this.gridControl_Item.DataSource = this.dtItems;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadData();
            }
            catch { return; }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                int count = this.dtItems.Select("Delete=1").CopyToDataTable().Rows.Count;
                if (count > 0)
                {
                    bool result = false;
                    int countRow = 0;
                    foreach (DataRow row in this.dtItems.Select("Delete=1").CopyToDataTable().Rows)
                    {
                        countRow = InventoryBLL.Upd_InventoryShipmentDateEnd(row["ItemCode"].ToString(), row["Shipment"].ToString(), Convert.ToDateTime(row["DateEnd"].ToString()), row["ShipmentNew"].ToString(), Convert.ToDateTime(row["DateEndNew"].ToString()));
                        if (countRow > 0)
                            result = true;
                        if (!result)
                        {
                            XtraMessageBox.Show(" Cập nhật không thành công lô, hạn dùng của thuốc " + row["ItemName"].ToString() + " vui lòng xem lại!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.LoadData();
                            break;
                        }
                    }
                    if (result)
                    {
                        XtraMessageBox.Show(" Cập nhật thành công.", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LoadData();
                    }
                }
                else
                {
                    XtraMessageBox.Show(" Vui lòng chọn thuốc sửa lô, hạn dùng,...trước khi cập nhật!", "Bệnh viện điện tử .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch { return; }
        }
    }
}