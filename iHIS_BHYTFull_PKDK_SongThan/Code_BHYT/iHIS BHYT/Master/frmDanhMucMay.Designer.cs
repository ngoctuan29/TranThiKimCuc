namespace Ps.Clinic.Master
{
    partial class frmDanhMucMay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucMay));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Data = new DevExpress.XtraGrid.GridControl();
            this.gridView_Data = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMachine_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachine_ServiceCategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_ServiceCategory = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMachine_Hide = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_Hide = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colMachine_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachine_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_ServiceCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_Hide)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.Appearance.ForeColor = System.Drawing.Color.White;
            this.grMain.Appearance.Options.UseForeColor = true;
            this.grMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grMain.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.grMain.AppearanceCaption.Options.UseFont = true;
            this.grMain.AppearanceCaption.Options.UseForeColor = true;
            this.grMain.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grMain.CaptionImage")));
            this.grMain.Controls.Add(this.gridControl_Data);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(674, 362);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Danh mục máy XN + CĐHA";
            // 
            // gridControl_Data
            // 
            this.gridControl_Data.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Data.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Data.MainView = this.gridView_Data;
            this.gridControl_Data.Name = "gridControl_Data";
            this.gridControl_Data.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rep_Hide,
            this.rep_ServiceCategory});
            this.gridControl_Data.Size = new System.Drawing.Size(670, 337);
            this.gridControl_Data.TabIndex = 0;
            this.gridControl_Data.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Data});
            this.gridControl_Data.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Data_ProcessGridKey);
            // 
            // gridView_Data
            // 
            this.gridView_Data.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Data.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMachine_Name,
            this.colMachine_ServiceCategoryCode,
            this.colMachine_Hide,
            this.colMachine_RowID,
            this.colMachine_Code});
            this.gridView_Data.GridControl = this.gridControl_Data;
            this.gridView_Data.Name = "gridView_Data";
            this.gridView_Data.NewItemRowText = "Khai báo máy xét nghiệm + chẩn đoán hình ảnh";
            this.gridView_Data.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Data.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Data.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Data.OptionsView.ShowFooter = true;
            this.gridView_Data.OptionsView.ShowGroupPanel = false;
            this.gridView_Data.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Object_InvalidRowException);
            this.gridView_Data.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Data_ValidateRow);
            // 
            // colMachine_Name
            // 
            this.colMachine_Name.Caption = "Tên máy";
            this.colMachine_Name.FieldName = "MechineName";
            this.colMachine_Name.Name = "colMachine_Name";
            this.colMachine_Name.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "RowID", "Count: {0:#,#}")});
            this.colMachine_Name.Visible = true;
            this.colMachine_Name.VisibleIndex = 0;
            this.colMachine_Name.Width = 378;
            // 
            // colMachine_ServiceCategoryCode
            // 
            this.colMachine_ServiceCategoryCode.Caption = "Dịch vụ (XN + CĐHA)";
            this.colMachine_ServiceCategoryCode.ColumnEdit = this.rep_ServiceCategory;
            this.colMachine_ServiceCategoryCode.FieldName = "ServiceCategoryCode";
            this.colMachine_ServiceCategoryCode.Name = "colMachine_ServiceCategoryCode";
            this.colMachine_ServiceCategoryCode.OptionsColumn.AllowSize = false;
            this.colMachine_ServiceCategoryCode.Visible = true;
            this.colMachine_ServiceCategoryCode.VisibleIndex = 2;
            this.colMachine_ServiceCategoryCode.Width = 187;
            // 
            // rep_ServiceCategory
            // 
            this.rep_ServiceCategory.AutoHeight = false;
            this.rep_ServiceCategory.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_ServiceCategory.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceCategoryName", "Loại dịch vụ"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServiceCategoryCode", "Mã", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center)});
            this.rep_ServiceCategory.Name = "rep_ServiceCategory";
            this.rep_ServiceCategory.NullText = "..";
            this.rep_ServiceCategory.ShowFooter = false;
            this.rep_ServiceCategory.ShowHeader = false;
            // 
            // colMachine_Hide
            // 
            this.colMachine_Hide.AppearanceCell.Options.UseTextOptions = true;
            this.colMachine_Hide.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMachine_Hide.AppearanceHeader.Options.UseTextOptions = true;
            this.colMachine_Hide.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMachine_Hide.Caption = "Khóa";
            this.colMachine_Hide.ColumnEdit = this.rep_Hide;
            this.colMachine_Hide.FieldName = "Hide";
            this.colMachine_Hide.Name = "colMachine_Hide";
            this.colMachine_Hide.OptionsColumn.AllowSize = false;
            this.colMachine_Hide.Visible = true;
            this.colMachine_Hide.VisibleIndex = 3;
            this.colMachine_Hide.Width = 56;
            // 
            // rep_Hide
            // 
            this.rep_Hide.AutoHeight = false;
            this.rep_Hide.DisplayValueChecked = "1";
            this.rep_Hide.DisplayValueGrayed = "0";
            this.rep_Hide.DisplayValueUnchecked = "0";
            this.rep_Hide.Name = "rep_Hide";
            this.rep_Hide.ValueChecked = 1;
            this.rep_Hide.ValueGrayed = 0;
            this.rep_Hide.ValueUnchecked = 0;
            // 
            // colMachine_RowID
            // 
            this.colMachine_RowID.Caption = "RowID";
            this.colMachine_RowID.FieldName = "RowID";
            this.colMachine_RowID.Name = "colMachine_RowID";
            // 
            // colMachine_Code
            // 
            this.colMachine_Code.Caption = "Viết tắt";
            this.colMachine_Code.FieldName = "MechineCode";
            this.colMachine_Code.Name = "colMachine_Code";
            this.colMachine_Code.Visible = true;
            this.colMachine_Code.VisibleIndex = 1;
            // 
            // frmDanhMucMay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 362);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDanhMucMay";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh sách phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDanhMucMay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_ServiceCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_Hide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_Data;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Data;
        private DevExpress.XtraGrid.Columns.GridColumn colMachine_Hide;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rep_Hide;
        private DevExpress.XtraGrid.Columns.GridColumn colMachine_Name;
        private DevExpress.XtraGrid.Columns.GridColumn colMachine_ServiceCategoryCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rep_ServiceCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colMachine_RowID;
        private DevExpress.XtraGrid.Columns.GridColumn colMachine_Code;
    }
}