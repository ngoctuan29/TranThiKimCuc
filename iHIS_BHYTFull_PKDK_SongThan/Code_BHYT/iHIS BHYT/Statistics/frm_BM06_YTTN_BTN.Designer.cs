namespace Ps.Clinic.Statistics
{
    partial class frm_BM06_YTTN_BTN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BM06_YTTN_BTN));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_Result = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView_Result = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.grb_STT = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.col_th_STT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grb_Name = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.col_th_TenBenh = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grb_Total = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grb_Mac = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.col_th_SLMac = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grb_Die = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.col_th_SLTuVong = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridView_Result = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnSearch = new System.Windows.Forms.Panel();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.controlDatetime = new UserControlDate.dllNgay();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).BeginInit();
            this.pnSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.panelControl1);
            this.groupControl2.Controls.Add(this.pnSearch);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1022, 469);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Bảng kê tình hình bệnh truyền nhiễm gây dịch";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.gridControl_Result);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(304, 21);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(716, 446);
            this.panelControl1.TabIndex = 1056;
            // 
            // gridControl_Result
            // 
            this.gridControl_Result.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Result.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Result.MainView = this.bandedGridView_Result;
            this.gridControl_Result.Name = "gridControl_Result";
            this.gridControl_Result.Size = new System.Drawing.Size(716, 446);
            this.gridControl_Result.TabIndex = 1055;
            this.gridControl_Result.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView_Result,
            this.gridView_Result});
            // 
            // bandedGridView_Result
            // 
            this.bandedGridView_Result.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.bandedGridView_Result.Appearance.FooterPanel.Options.UseFont = true;
            this.bandedGridView_Result.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.grb_STT,
            this.grb_Name,
            this.grb_Total});
            this.bandedGridView_Result.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.col_th_STT,
            this.col_th_TenBenh,
            this.col_th_SLMac,
            this.col_th_SLTuVong});
            this.bandedGridView_Result.CustomizationFormBounds = new System.Drawing.Rectangle(1147, 473, 219, 254);
            this.bandedGridView_Result.GridControl = this.gridControl_Result;
            this.bandedGridView_Result.GroupPanelText = "Nhóm dữ liệu!";
            this.bandedGridView_Result.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ServicePrice", null, "{0:#,#}", new decimal(new int[] {
                            0,
                            0,
                            0,
                            0}))});
            this.bandedGridView_Result.Name = "bandedGridView_Result";
            this.bandedGridView_Result.OptionsFind.AllowFindPanel = false;
            this.bandedGridView_Result.OptionsFind.FindFilterColumns = "";
            this.bandedGridView_Result.OptionsView.ColumnAutoWidth = false;
            this.bandedGridView_Result.OptionsView.ShowColumnHeaders = false;
            this.bandedGridView_Result.OptionsView.ShowFooter = true;
            // 
            // grb_STT
            // 
            this.grb_STT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.grb_STT.AppearanceHeader.Options.UseFont = true;
            this.grb_STT.AppearanceHeader.Options.UseTextOptions = true;
            this.grb_STT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grb_STT.Caption = "STT";
            this.grb_STT.Columns.Add(this.col_th_STT);
            this.grb_STT.Name = "grb_STT";
            this.grb_STT.VisibleIndex = 0;
            this.grb_STT.Width = 47;
            // 
            // col_th_STT
            // 
            this.col_th_STT.AppearanceCell.Options.UseTextOptions = true;
            this.col_th_STT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_STT.Caption = "STT";
            this.col_th_STT.FieldName = "Stt";
            this.col_th_STT.Name = "col_th_STT";
            this.col_th_STT.OptionsColumn.AllowEdit = false;
            this.col_th_STT.OptionsColumn.AllowFocus = false;
            this.col_th_STT.OptionsColumn.ReadOnly = true;
            this.col_th_STT.Visible = true;
            this.col_th_STT.Width = 47;
            // 
            // grb_Name
            // 
            this.grb_Name.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.grb_Name.AppearanceHeader.Options.UseFont = true;
            this.grb_Name.AppearanceHeader.Options.UseTextOptions = true;
            this.grb_Name.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grb_Name.Caption = "Tên bệnh";
            this.grb_Name.Columns.Add(this.col_th_TenBenh);
            this.grb_Name.Name = "grb_Name";
            this.grb_Name.VisibleIndex = 1;
            this.grb_Name.Width = 349;
            // 
            // col_th_TenBenh
            // 
            this.col_th_TenBenh.Caption = "Tên bệnh";
            this.col_th_TenBenh.FieldName = "TenBEnh";
            this.col_th_TenBenh.Name = "col_th_TenBenh";
            this.col_th_TenBenh.OptionsColumn.AllowEdit = false;
            this.col_th_TenBenh.OptionsColumn.AllowFocus = false;
            this.col_th_TenBenh.OptionsColumn.ReadOnly = true;
            this.col_th_TenBenh.Visible = true;
            this.col_th_TenBenh.Width = 349;
            // 
            // grb_Total
            // 
            this.grb_Total.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.grb_Total.AppearanceHeader.Options.UseFont = true;
            this.grb_Total.AppearanceHeader.Options.UseTextOptions = true;
            this.grb_Total.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grb_Total.Caption = "Tổng số";
            this.grb_Total.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.grb_Mac,
            this.grb_Die});
            this.grb_Total.Name = "grb_Total";
            this.grb_Total.VisibleIndex = 2;
            this.grb_Total.Width = 426;
            // 
            // grb_Mac
            // 
            this.grb_Mac.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.grb_Mac.AppearanceHeader.Options.UseFont = true;
            this.grb_Mac.AppearanceHeader.Options.UseTextOptions = true;
            this.grb_Mac.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grb_Mac.Caption = "Mắc";
            this.grb_Mac.Columns.Add(this.col_th_SLMac);
            this.grb_Mac.Name = "grb_Mac";
            this.grb_Mac.VisibleIndex = 0;
            this.grb_Mac.Width = 217;
            // 
            // col_th_SLMac
            // 
            this.col_th_SLMac.AppearanceCell.Options.UseTextOptions = true;
            this.col_th_SLMac.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_SLMac.Caption = "Mắc";
            this.col_th_SLMac.DisplayFormat.FormatString = "#,#";
            this.col_th_SLMac.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_th_SLMac.FieldName = "SLMac";
            this.col_th_SLMac.Name = "col_th_SLMac";
            this.col_th_SLMac.OptionsColumn.AllowEdit = false;
            this.col_th_SLMac.OptionsColumn.AllowFocus = false;
            this.col_th_SLMac.OptionsColumn.ReadOnly = true;
            this.col_th_SLMac.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SLMac", "{0:#,#}")});
            this.col_th_SLMac.Visible = true;
            this.col_th_SLMac.Width = 217;
            // 
            // grb_Die
            // 
            this.grb_Die.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.grb_Die.AppearanceHeader.Options.UseFont = true;
            this.grb_Die.AppearanceHeader.Options.UseTextOptions = true;
            this.grb_Die.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grb_Die.Caption = "Tử vong";
            this.grb_Die.Columns.Add(this.col_th_SLTuVong);
            this.grb_Die.Name = "grb_Die";
            this.grb_Die.VisibleIndex = 1;
            this.grb_Die.Width = 209;
            // 
            // col_th_SLTuVong
            // 
            this.col_th_SLTuVong.AppearanceCell.Options.UseTextOptions = true;
            this.col_th_SLTuVong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_th_SLTuVong.Caption = "Tử vong";
            this.col_th_SLTuVong.DisplayFormat.FormatString = "#,#";
            this.col_th_SLTuVong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_th_SLTuVong.FieldName = "SLTuVong";
            this.col_th_SLTuVong.Name = "col_th_SLTuVong";
            this.col_th_SLTuVong.OptionsColumn.AllowEdit = false;
            this.col_th_SLTuVong.OptionsColumn.ReadOnly = true;
            this.col_th_SLTuVong.OptionsColumn.ShowCaption = false;
            this.col_th_SLTuVong.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SLTuVong", "{0:#,#}")});
            this.col_th_SLTuVong.Visible = true;
            this.col_th_SLTuVong.Width = 209;
            // 
            // gridView_Result
            // 
            this.gridView_Result.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_Result.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_Result.GridControl = this.gridControl_Result;
            this.gridView_Result.GroupPanelText = "Nhóm dữ liệu!";
            this.gridView_Result.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ServicePrice", null, "{0:#,#}", new decimal(new int[] {
                            0,
                            0,
                            0,
                            0}))});
            this.gridView_Result.Name = "gridView_Result";
            this.gridView_Result.OptionsFind.AllowFindPanel = false;
            this.gridView_Result.OptionsFind.FindFilterColumns = "";
            this.gridView_Result.OptionsView.ColumnAutoWidth = false;
            this.gridView_Result.OptionsView.ShowFooter = true;
            // 
            // pnSearch
            // 
            this.pnSearch.Controls.Add(this.btnPrint);
            this.pnSearch.Controls.Add(this.controlDatetime);
            this.pnSearch.Controls.Add(this.butOK);
            this.pnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnSearch.Location = new System.Drawing.Point(2, 21);
            this.pnSearch.Name = "pnSearch";
            this.pnSearch.Size = new System.Drawing.Size(302, 446);
            this.pnSearch.TabIndex = 1053;
            // 
            // btnPrint
            // 
            this.btnPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(207, 84);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(89, 26);
            this.btnPrint.TabIndex = 1054;
            this.btnPrint.Text = "In báo cáo";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // controlDatetime
            // 
            this.controlDatetime.BackColor = System.Drawing.Color.Transparent;
            this.controlDatetime.Location = new System.Drawing.Point(3, 3);
            this.controlDatetime.Margin = new System.Windows.Forms.Padding(4);
            this.controlDatetime.Name = "controlDatetime";
            this.controlDatetime.Size = new System.Drawing.Size(293, 73);
            this.controlDatetime.TabIndex = 1052;
            // 
            // butOK
            // 
            this.butOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.Location = new System.Drawing.Point(111, 84);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(94, 26);
            this.butOK.TabIndex = 4;
            this.butOK.Text = "Lấy số liệu";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // frm_BM06_YTTN_BTN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 469);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_BM06_YTTN_BTN";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Báo cáo & Thống kê doanh thu khám chữa bệnh của phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVP_BangKeHDNgay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Result)).EndInit();
            this.pnSearch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton butOK;
        private UserControlDate.dllNgay controlDatetime;
        private System.Windows.Forms.Panel pnSearch;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraGrid.GridControl gridControl_Result;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Result;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView_Result;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn col_th_STT;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn col_th_TenBenh;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn col_th_SLMac;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn col_th_SLTuVong;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand grb_STT;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand grb_Name;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand grb_Total;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand grb_Mac;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand grb_Die;
    }
}