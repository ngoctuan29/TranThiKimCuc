namespace Ps.Clinic.Statistics
{
    partial class frm_TiemVaccin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_TiemVaccin));
            this.gridVIew_Result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl_Result = new DevExpress.XtraGrid.GridControl();
            this.butRefesh = new DevExpress.XtraEditors.SimpleButton();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.controlDatetime = new UserControlDateTimes.UserControlDateTimes();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridVIew_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridVIew_Result
            // 
            this.gridVIew_Result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.gridVIew_Result.GridControl = this.gridControl_Result;
            this.gridVIew_Result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridVIew_Result.Name = "gridVIew_Result";
            this.gridVIew_Result.OptionsFind.FindFilterColumns = "ItemName";
            this.gridVIew_Result.OptionsView.ColumnAutoWidth = false;
            this.gridVIew_Result.OptionsView.ShowFooter = true;
            this.gridVIew_Result.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên Vaccin";
            this.gridColumn2.FieldName = "ServiceName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 201;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Mũi tiêm";
            this.gridColumn3.DisplayFormat.FormatString = "{0:#,#}";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "MuiTiem";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MuiTiem", "{0:#,#}")});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 63;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Trẻ <1 tuổi";
            this.gridColumn4.DisplayFormat.FormatString = "{0:#,#}";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "TreDuoi1t";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TreDuoi1t", "{0:#,#}")});
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 67;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Trẻ <1-5 tuổi";
            this.gridColumn5.DisplayFormat.FormatString = "{0:#,#}";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "TreDuoi1Den5t";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TreDuoi1Den5t", "{0:#,#}")});
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Trẻ <1 tuổi & người lớn";
            this.gridColumn6.DisplayFormat.FormatString = "{0:#,#}";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "TreDuoi1tVaNL";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TreDuoi1tVaNL", "{0:#,#}")});
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 122;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Phản ứng sau tiêm";
            this.gridColumn7.FieldName = "PhanUng";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 218;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Ghi chú";
            this.gridColumn8.FieldName = "GhiChu";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 281;
            // 
            // gridControl_Result
            // 
            this.gridControl_Result.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Result.Location = new System.Drawing.Point(0, 40);
            this.gridControl_Result.MainView = this.gridVIew_Result;
            this.gridControl_Result.Name = "gridControl_Result";
            this.gridControl_Result.Size = new System.Drawing.Size(843, 316);
            this.gridControl_Result.TabIndex = 5;
            this.gridControl_Result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridVIew_Result});
            // 
            // butRefesh
            // 
            this.butRefesh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butRefesh.Image = ((System.Drawing.Image)(resources.GetObject("butRefesh.Image")));
            this.butRefesh.Location = new System.Drawing.Point(649, 6);
            this.butRefesh.Name = "butRefesh";
            this.butRefesh.Size = new System.Drawing.Size(102, 26);
            this.butRefesh.TabIndex = 4;
            this.butRefesh.Text = "Lấy dữ liệu";
            this.butRefesh.Click += new System.EventHandler(this.butRefesh_Click);
            // 
            // butPrint
            // 
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(752, 6);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(81, 26);
            this.butPrint.TabIndex = 5;
            this.butPrint.Text = "File Excel";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // controlDatetime
            // 
            this.controlDatetime.Location = new System.Drawing.Point(3, 6);
            this.controlDatetime.Name = "controlDatetime";
            this.controlDatetime.Size = new System.Drawing.Size(640, 25);
            this.controlDatetime.TabIndex = 6;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.controlDatetime);
            this.panelControl3.Controls.Add(this.butPrint);
            this.panelControl3.Controls.Add(this.butRefesh);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(843, 40);
            this.panelControl3.TabIndex = 4;
            // 
            // frm_TiemVaccin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 356);
            this.Controls.Add(this.gridControl_Result);
            this.Controls.Add(this.panelControl3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_TiemVaccin";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tiêm vaccin dịch vụ ngoài CT.TCMR quốc gia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridVIew_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridVIew_Result;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.GridControl gridControl_Result;
        private DevExpress.XtraEditors.SimpleButton butRefesh;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private UserControlDateTimes.UserControlDateTimes controlDatetime;
        private DevExpress.XtraEditors.PanelControl panelControl3;
    }
}