namespace Ps.Clinic.Statistics
{
    partial class frm_BM04_YTTN_TNTT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BM04_YTTN_TNTT));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Result = new DevExpress.XtraGrid.GridControl();
            this.gridVIew_Result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_TNTTID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TNTTName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SLMac = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SLChet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.controlDatetime = new UserControlDateTimes.UserControlDateTimes();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            this.butRefesh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVIew_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.Controls.Add(this.gridControl_Result);
            this.grMain.Controls.Add(this.panelControl3);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(843, 356);
            this.grMain.TabIndex = 6;
            this.grMain.Text = "Hoạt động khám chữa bệnh và cận lâm sàn";
            // 
            // gridControl_Result
            // 
            this.gridControl_Result.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Result.Location = new System.Drawing.Point(2, 60);
            this.gridControl_Result.MainView = this.gridVIew_Result;
            this.gridControl_Result.Name = "gridControl_Result";
            this.gridControl_Result.Size = new System.Drawing.Size(839, 294);
            this.gridControl_Result.TabIndex = 6;
            this.gridControl_Result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridVIew_Result});
            // 
            // gridVIew_Result
            // 
            this.gridVIew_Result.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_TNTTID,
            this.col_TNTTName,
            this.col_SLMac,
            this.col_SLChet});
            this.gridVIew_Result.GridControl = this.gridControl_Result;
            this.gridVIew_Result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridVIew_Result.Name = "gridVIew_Result";
            this.gridVIew_Result.OptionsFind.FindFilterColumns = "ItemName";
            this.gridVIew_Result.OptionsView.ColumnAutoWidth = false;
            this.gridVIew_Result.OptionsView.ShowFooter = true;
            this.gridVIew_Result.OptionsView.ShowGroupPanel = false;
            // 
            // col_TNTTID
            // 
            this.col_TNTTID.Caption = "TNTTID";
            this.col_TNTTID.FieldName = "TNTTID";
            this.col_TNTTID.Name = "col_TNTTID";
            this.col_TNTTID.OptionsColumn.AllowEdit = false;
            this.col_TNTTID.OptionsColumn.AllowFocus = false;
            this.col_TNTTID.OptionsColumn.ReadOnly = true;
            // 
            // col_TNTTName
            // 
            this.col_TNTTName.AppearanceCell.Options.UseTextOptions = true;
            this.col_TNTTName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.col_TNTTName.AppearanceHeader.Options.UseTextOptions = true;
            this.col_TNTTName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.col_TNTTName.Caption = "Tên tai nạn thương tích";
            this.col_TNTTName.FieldName = "TNTTName";
            this.col_TNTTName.Name = "col_TNTTName";
            this.col_TNTTName.OptionsColumn.AllowEdit = false;
            this.col_TNTTName.OptionsColumn.AllowFocus = false;
            this.col_TNTTName.OptionsColumn.ReadOnly = true;
            this.col_TNTTName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "TNTTName", "{0:#,#}")});
            this.col_TNTTName.Visible = true;
            this.col_TNTTName.VisibleIndex = 0;
            this.col_TNTTName.Width = 296;
            // 
            // col_SLMac
            // 
            this.col_SLMac.AppearanceCell.Options.UseTextOptions = true;
            this.col_SLMac.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_SLMac.AppearanceHeader.Options.UseTextOptions = true;
            this.col_SLMac.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_SLMac.Caption = "Số lượng mắc";
            this.col_SLMac.DisplayFormat.FormatString = "{0:#,#}";
            this.col_SLMac.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_SLMac.FieldName = "SLMac";
            this.col_SLMac.Name = "col_SLMac";
            this.col_SLMac.OptionsColumn.AllowEdit = false;
            this.col_SLMac.OptionsColumn.AllowFocus = false;
            this.col_SLMac.OptionsColumn.ReadOnly = true;
            this.col_SLMac.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SLMac", "{0:#,#}")});
            this.col_SLMac.Visible = true;
            this.col_SLMac.VisibleIndex = 1;
            this.col_SLMac.Width = 86;
            // 
            // col_SLChet
            // 
            this.col_SLChet.AppearanceCell.Options.UseTextOptions = true;
            this.col_SLChet.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_SLChet.AppearanceHeader.Options.UseTextOptions = true;
            this.col_SLChet.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_SLChet.Caption = "Số lượng tử vong";
            this.col_SLChet.DisplayFormat.FormatString = "{0:#,#}";
            this.col_SLChet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_SLChet.FieldName = "SLChet";
            this.col_SLChet.Name = "col_SLChet";
            this.col_SLChet.OptionsColumn.AllowEdit = false;
            this.col_SLChet.OptionsColumn.AllowFocus = false;
            this.col_SLChet.OptionsColumn.ReadOnly = true;
            this.col_SLChet.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SLChet", "{0:#,#}")});
            this.col_SLChet.Visible = true;
            this.col_SLChet.VisibleIndex = 2;
            this.col_SLChet.Width = 93;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.controlDatetime);
            this.panelControl3.Controls.Add(this.butPrint);
            this.panelControl3.Controls.Add(this.butRefesh);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 20);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(839, 40);
            this.panelControl3.TabIndex = 5;
            this.panelControl3.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl3_Paint);
            // 
            // controlDatetime
            // 
            this.controlDatetime.Location = new System.Drawing.Point(3, 6);
            this.controlDatetime.Name = "controlDatetime";
            this.controlDatetime.Size = new System.Drawing.Size(640, 25);
            this.controlDatetime.TabIndex = 6;
            // 
            // butPrint
            // 
            this.butPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(752, 6);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(81, 26);
            this.butPrint.TabIndex = 5;
            this.butPrint.Text = "In báo cáo";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click_1);
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
            this.butRefesh.Click += new System.EventHandler(this.butRefesh_Click_1);
            // 
            // frm_BM04_YTTN_TNTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 356);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_BM04_YTTN_TNTT";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tiêm vaccin dịch vụ ngoài CT.TCMR quốc gia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVIew_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_Result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridVIew_Result;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private UserControlDateTimes.UserControlDateTimes controlDatetime;
        private DevExpress.XtraEditors.SimpleButton butPrint;
        private DevExpress.XtraEditors.SimpleButton butRefesh;
        private DevExpress.XtraGrid.Columns.GridColumn col_TNTTID;
        private DevExpress.XtraGrid.Columns.GridColumn col_TNTTName;
        private DevExpress.XtraGrid.Columns.GridColumn col_SLMac;
        private DevExpress.XtraGrid.Columns.GridColumn col_SLChet;
    }
}