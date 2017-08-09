namespace Ps.Clinic.Master
{
    partial class frmDDLoaiNguyenLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDDLoaiNguyenLieu));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_FoodCategory = new DevExpress.XtraGrid.GridControl();
            this.gridView_FoodCategory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_FoodCategoryID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_FoodCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_FoodCategorySTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.butPrint = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_FoodCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_FoodCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grMain.CaptionImage")));
            this.grMain.Controls.Add(this.panelControl2);
            this.grMain.Controls.Add(this.panelControl1);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(666, 358);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Kê khai nhiên liệu ( thức ăn, gia vị, khí đốt, ... )";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.gridControl_FoodCategory);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(2, 60);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(662, 296);
            this.panelControl2.TabIndex = 6;
            // 
            // gridControl_FoodCategory
            // 
            this.gridControl_FoodCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_FoodCategory.Location = new System.Drawing.Point(0, 0);
            this.gridControl_FoodCategory.MainView = this.gridView_FoodCategory;
            this.gridControl_FoodCategory.Name = "gridControl_FoodCategory";
            this.gridControl_FoodCategory.Size = new System.Drawing.Size(662, 296);
            this.gridControl_FoodCategory.TabIndex = 0;
            this.gridControl_FoodCategory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_FoodCategory});
            this.gridControl_FoodCategory.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_FoodCategory_ProcessGridKey);
            // 
            // gridView_FoodCategory
            // 
            this.gridView_FoodCategory.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_FoodCategory.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_FoodCategory.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_FoodCategory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_FoodCategoryID,
            this.col_FoodCategoryName,
            this.col_FoodCategorySTT});
            this.gridView_FoodCategory.GridControl = this.gridControl_FoodCategory;
            this.gridView_FoodCategory.GroupPanelText = "Nhóm loại viện phí theo nhóm!";
            this.gridView_FoodCategory.Name = "gridView_FoodCategory";
            this.gridView_FoodCategory.NewItemRowText = "Nhập thêm mới mã, tên diễn giải nhiên liệu";
            this.gridView_FoodCategory.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_FoodCategory.OptionsView.ShowFooter = true;
            this.gridView_FoodCategory.OptionsView.ShowGroupPanel = false;
            this.gridView_FoodCategory.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_FoodCategory_InvalidRowException);
            this.gridView_FoodCategory.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_FoodCategory_ValidateRow);
            // 
            // col_FoodCategoryID
            // 
            this.col_FoodCategoryID.AppearanceCell.Options.UseTextOptions = true;
            this.col_FoodCategoryID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_FoodCategoryID.AppearanceHeader.Options.UseTextOptions = true;
            this.col_FoodCategoryID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_FoodCategoryID.Caption = "ID";
            this.col_FoodCategoryID.FieldName = "FoodCategoryID";
            this.col_FoodCategoryID.Name = "col_FoodCategoryID";
            this.col_FoodCategoryID.OptionsColumn.AllowEdit = false;
            this.col_FoodCategoryID.OptionsColumn.AllowSize = false;
            this.col_FoodCategoryID.OptionsColumn.ReadOnly = true;
            this.col_FoodCategoryID.Width = 110;
            // 
            // col_FoodCategoryName
            // 
            this.col_FoodCategoryName.Caption = "Loại nhiên liệu";
            this.col_FoodCategoryName.FieldName = "FoodCategoryName";
            this.col_FoodCategoryName.Name = "col_FoodCategoryName";
            this.col_FoodCategoryName.Visible = true;
            this.col_FoodCategoryName.VisibleIndex = 0;
            this.col_FoodCategoryName.Width = 498;
            // 
            // col_FoodCategorySTT
            // 
            this.col_FoodCategorySTT.AppearanceCell.Options.UseTextOptions = true;
            this.col_FoodCategorySTT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_FoodCategorySTT.AppearanceHeader.Options.UseTextOptions = true;
            this.col_FoodCategorySTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_FoodCategorySTT.Caption = "STT";
            this.col_FoodCategorySTT.DisplayFormat.FormatString = "#,###";
            this.col_FoodCategorySTT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_FoodCategorySTT.FieldName = "STT";
            this.col_FoodCategorySTT.Name = "col_FoodCategorySTT";
            this.col_FoodCategorySTT.Visible = true;
            this.col_FoodCategorySTT.VisibleIndex = 1;
            this.col_FoodCategorySTT.Width = 53;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.butPrint);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 23);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(662, 37);
            this.panelControl1.TabIndex = 5;
            // 
            // butPrint
            // 
            this.butPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPrint.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butPrint.Appearance.Options.UseForeColor = true;
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.Location = new System.Drawing.Point(562, 5);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(97, 28);
            this.butPrint.TabIndex = 9;
            this.butPrint.Text = "In danh mục";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // frmDDLoaiNguyenLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 358);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDDLoaiNguyenLieu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo loại viện phí";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDDLoaiNguyenLieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_FoodCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_FoodCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_FoodCategory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_FoodCategory;
        private DevExpress.XtraGrid.Columns.GridColumn col_FoodCategoryID;
        private DevExpress.XtraGrid.Columns.GridColumn col_FoodCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn col_FoodCategorySTT;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton butPrint;
    }
}