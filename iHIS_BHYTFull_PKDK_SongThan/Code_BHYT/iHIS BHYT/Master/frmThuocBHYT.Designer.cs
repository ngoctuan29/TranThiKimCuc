namespace Ps.Clinic.Master
{
    partial class frmThuocBHYT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThuocBHYT));
            this.gridControl_Data = new DevExpress.XtraGrid.GridControl();
            this.gridView_Data = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colView_STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colView_SO_DANG_KY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colView_TEN_THUOC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colView_MA_HOAT_CHAT_TT40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colView_HOAT_CHAT_TT40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colView_HOAT_CHAT_SODK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colView_MA_DUONG_DUNG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colView_DUONG_DUNG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colView_HAM_LUONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colView_DONG_GOI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colView_HANG_SX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colView_NUOC_SX = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Data
            // 
            this.gridControl_Data.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Data.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Data.MainView = this.gridView_Data;
            this.gridControl_Data.Name = "gridControl_Data";
            this.gridControl_Data.Size = new System.Drawing.Size(1024, 600);
            this.gridControl_Data.TabIndex = 1;
            this.gridControl_Data.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Data});
            // 
            // gridView_Data
            // 
            this.gridView_Data.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Data.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Data.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Data.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_Data.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Data.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Data.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colView_STT,
            this.colView_SO_DANG_KY,
            this.colView_TEN_THUOC,
            this.colView_MA_HOAT_CHAT_TT40,
            this.colView_HOAT_CHAT_TT40,
            this.colView_HOAT_CHAT_SODK,
            this.colView_MA_DUONG_DUNG,
            this.colView_DUONG_DUNG,
            this.colView_HAM_LUONG,
            this.colView_DONG_GOI,
            this.colView_HANG_SX,
            this.colView_NUOC_SX});
            this.gridView_Data.GridControl = this.gridControl_Data;
            this.gridView_Data.Name = "gridView_Data";
            this.gridView_Data.NewItemRowText = "...";
            this.gridView_Data.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Data.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Data.OptionsView.ColumnAutoWidth = false;
            this.gridView_Data.OptionsView.ShowFooter = true;
            this.gridView_Data.OptionsView.ShowGroupPanel = false;
            this.gridView_Data.OptionsView.ShowIndicator = false;
            // 
            // colView_STT
            // 
            this.colView_STT.AppearanceCell.Options.UseTextOptions = true;
            this.colView_STT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colView_STT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colView_STT.AppearanceHeader.Options.UseFont = true;
            this.colView_STT.AppearanceHeader.Options.UseTextOptions = true;
            this.colView_STT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colView_STT.Caption = "STT";
            this.colView_STT.FieldName = "STT";
            this.colView_STT.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colView_STT.Name = "colView_STT";
            this.colView_STT.OptionsColumn.ReadOnly = true;
            this.colView_STT.Visible = true;
            this.colView_STT.VisibleIndex = 0;
            this.colView_STT.Width = 57;
            // 
            // colView_SO_DANG_KY
            // 
            this.colView_SO_DANG_KY.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colView_SO_DANG_KY.AppearanceHeader.Options.UseFont = true;
            this.colView_SO_DANG_KY.AppearanceHeader.Options.UseTextOptions = true;
            this.colView_SO_DANG_KY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colView_SO_DANG_KY.Caption = "Số ĐK";
            this.colView_SO_DANG_KY.FieldName = "SO_DANG_KY";
            this.colView_SO_DANG_KY.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colView_SO_DANG_KY.Name = "colView_SO_DANG_KY";
            this.colView_SO_DANG_KY.OptionsColumn.ReadOnly = true;
            this.colView_SO_DANG_KY.Visible = true;
            this.colView_SO_DANG_KY.VisibleIndex = 1;
            this.colView_SO_DANG_KY.Width = 117;
            // 
            // colView_TEN_THUOC
            // 
            this.colView_TEN_THUOC.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colView_TEN_THUOC.AppearanceHeader.Options.UseFont = true;
            this.colView_TEN_THUOC.AppearanceHeader.Options.UseTextOptions = true;
            this.colView_TEN_THUOC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colView_TEN_THUOC.Caption = "Tên thuốc";
            this.colView_TEN_THUOC.FieldName = "TEN_THUOC";
            this.colView_TEN_THUOC.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colView_TEN_THUOC.Name = "colView_TEN_THUOC";
            this.colView_TEN_THUOC.OptionsColumn.ReadOnly = true;
            this.colView_TEN_THUOC.Visible = true;
            this.colView_TEN_THUOC.VisibleIndex = 2;
            this.colView_TEN_THUOC.Width = 237;
            // 
            // colView_MA_HOAT_CHAT_TT40
            // 
            this.colView_MA_HOAT_CHAT_TT40.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colView_MA_HOAT_CHAT_TT40.AppearanceHeader.Options.UseFont = true;
            this.colView_MA_HOAT_CHAT_TT40.AppearanceHeader.Options.UseTextOptions = true;
            this.colView_MA_HOAT_CHAT_TT40.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colView_MA_HOAT_CHAT_TT40.Caption = "Mã HC TT40";
            this.colView_MA_HOAT_CHAT_TT40.FieldName = "MA_HOAT_CHAT_TT40";
            this.colView_MA_HOAT_CHAT_TT40.Name = "colView_MA_HOAT_CHAT_TT40";
            this.colView_MA_HOAT_CHAT_TT40.OptionsColumn.ReadOnly = true;
            this.colView_MA_HOAT_CHAT_TT40.Visible = true;
            this.colView_MA_HOAT_CHAT_TT40.VisibleIndex = 3;
            this.colView_MA_HOAT_CHAT_TT40.Width = 100;
            // 
            // colView_HOAT_CHAT_TT40
            // 
            this.colView_HOAT_CHAT_TT40.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colView_HOAT_CHAT_TT40.AppearanceHeader.Options.UseFont = true;
            this.colView_HOAT_CHAT_TT40.Caption = "Tên HC TT40";
            this.colView_HOAT_CHAT_TT40.FieldName = "HOAT_CHAT_TT40";
            this.colView_HOAT_CHAT_TT40.Name = "colView_HOAT_CHAT_TT40";
            this.colView_HOAT_CHAT_TT40.OptionsColumn.ReadOnly = true;
            this.colView_HOAT_CHAT_TT40.Visible = true;
            this.colView_HOAT_CHAT_TT40.VisibleIndex = 4;
            this.colView_HOAT_CHAT_TT40.Width = 115;
            // 
            // colView_HOAT_CHAT_SODK
            // 
            this.colView_HOAT_CHAT_SODK.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colView_HOAT_CHAT_SODK.AppearanceHeader.Options.UseFont = true;
            this.colView_HOAT_CHAT_SODK.Caption = "HC Số ĐK";
            this.colView_HOAT_CHAT_SODK.FieldName = "HOAT_CHAT_SODK";
            this.colView_HOAT_CHAT_SODK.Name = "colView_HOAT_CHAT_SODK";
            this.colView_HOAT_CHAT_SODK.OptionsColumn.ReadOnly = true;
            this.colView_HOAT_CHAT_SODK.Visible = true;
            this.colView_HOAT_CHAT_SODK.VisibleIndex = 5;
            this.colView_HOAT_CHAT_SODK.Width = 80;
            // 
            // colView_MA_DUONG_DUNG
            // 
            this.colView_MA_DUONG_DUNG.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colView_MA_DUONG_DUNG.AppearanceHeader.Options.UseFont = true;
            this.colView_MA_DUONG_DUNG.Caption = "Mã đường dùng";
            this.colView_MA_DUONG_DUNG.FieldName = "MA_DUONG_DUNG";
            this.colView_MA_DUONG_DUNG.Name = "colView_MA_DUONG_DUNG";
            this.colView_MA_DUONG_DUNG.OptionsColumn.ReadOnly = true;
            this.colView_MA_DUONG_DUNG.Visible = true;
            this.colView_MA_DUONG_DUNG.VisibleIndex = 6;
            this.colView_MA_DUONG_DUNG.Width = 97;
            // 
            // colView_DUONG_DUNG
            // 
            this.colView_DUONG_DUNG.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colView_DUONG_DUNG.AppearanceHeader.Options.UseFont = true;
            this.colView_DUONG_DUNG.Caption = "Tên đường dùng";
            this.colView_DUONG_DUNG.FieldName = "DUONG_DUNG";
            this.colView_DUONG_DUNG.Name = "colView_DUONG_DUNG";
            this.colView_DUONG_DUNG.OptionsColumn.ReadOnly = true;
            this.colView_DUONG_DUNG.Visible = true;
            this.colView_DUONG_DUNG.VisibleIndex = 7;
            this.colView_DUONG_DUNG.Width = 172;
            // 
            // colView_HAM_LUONG
            // 
            this.colView_HAM_LUONG.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colView_HAM_LUONG.AppearanceHeader.Options.UseFont = true;
            this.colView_HAM_LUONG.Caption = "Hàm lượng";
            this.colView_HAM_LUONG.FieldName = "HAM_LUONG";
            this.colView_HAM_LUONG.Name = "colView_HAM_LUONG";
            this.colView_HAM_LUONG.OptionsColumn.ReadOnly = true;
            this.colView_HAM_LUONG.Visible = true;
            this.colView_HAM_LUONG.VisibleIndex = 8;
            // 
            // colView_DONG_GOI
            // 
            this.colView_DONG_GOI.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colView_DONG_GOI.AppearanceHeader.Options.UseFont = true;
            this.colView_DONG_GOI.Caption = "Đóng gói";
            this.colView_DONG_GOI.FieldName = "DONG_GOI";
            this.colView_DONG_GOI.Name = "colView_DONG_GOI";
            this.colView_DONG_GOI.OptionsColumn.ReadOnly = true;
            this.colView_DONG_GOI.Visible = true;
            this.colView_DONG_GOI.VisibleIndex = 9;
            this.colView_DONG_GOI.Width = 111;
            // 
            // colView_HANG_SX
            // 
            this.colView_HANG_SX.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colView_HANG_SX.AppearanceHeader.Options.UseFont = true;
            this.colView_HANG_SX.Caption = "Hãng SX";
            this.colView_HANG_SX.FieldName = "HANG_SX";
            this.colView_HANG_SX.Name = "colView_HANG_SX";
            this.colView_HANG_SX.OptionsColumn.ReadOnly = true;
            this.colView_HANG_SX.Visible = true;
            this.colView_HANG_SX.VisibleIndex = 10;
            this.colView_HANG_SX.Width = 145;
            // 
            // colView_NUOC_SX
            // 
            this.colView_NUOC_SX.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colView_NUOC_SX.AppearanceHeader.Options.UseFont = true;
            this.colView_NUOC_SX.Caption = "Nước SX";
            this.colView_NUOC_SX.FieldName = "NUOC_SX";
            this.colView_NUOC_SX.Name = "colView_NUOC_SX";
            this.colView_NUOC_SX.OptionsColumn.ReadOnly = true;
            this.colView_NUOC_SX.Visible = true;
            this.colView_NUOC_SX.VisibleIndex = 11;
            this.colView_NUOC_SX.Width = 105;
            // 
            // frmThuocBHYT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.gridControl_Data);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThuocBHYT";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh mục nhóm viện phí";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThuocBHYT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Data;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Data;
        private DevExpress.XtraGrid.Columns.GridColumn colView_STT;
        private DevExpress.XtraGrid.Columns.GridColumn colView_SO_DANG_KY;
        private DevExpress.XtraGrid.Columns.GridColumn colView_TEN_THUOC;
        private DevExpress.XtraGrid.Columns.GridColumn colView_MA_HOAT_CHAT_TT40;
        private DevExpress.XtraGrid.Columns.GridColumn colView_HOAT_CHAT_TT40;
        private DevExpress.XtraGrid.Columns.GridColumn colView_HOAT_CHAT_SODK;
        private DevExpress.XtraGrid.Columns.GridColumn colView_MA_DUONG_DUNG;
        private DevExpress.XtraGrid.Columns.GridColumn colView_DUONG_DUNG;
        private DevExpress.XtraGrid.Columns.GridColumn colView_HAM_LUONG;
        private DevExpress.XtraGrid.Columns.GridColumn colView_DONG_GOI;
        private DevExpress.XtraGrid.Columns.GridColumn colView_HANG_SX;
        private DevExpress.XtraGrid.Columns.GridColumn colView_NUOC_SX;
    }
}