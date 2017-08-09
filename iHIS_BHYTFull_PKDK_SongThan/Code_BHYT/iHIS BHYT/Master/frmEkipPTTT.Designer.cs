namespace Ps.Clinic.Master
{
    partial class frmEkipPTTT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEkipPTTT));
            this.grMain = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_SurgicalCrew = new DevExpress.XtraGrid.GridControl();
            this.gridView_SurgicalCrew = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Sur_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Sur_EmployeeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_EmployeeCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_Sur_PositionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ref_PositionCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_Sur_STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Sur_EmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Sur_Role = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.grMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_SurgicalCrew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_SurgicalCrew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_EmployeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_PositionCode)).BeginInit();
            this.SuspendLayout();
            // 
            // grMain
            // 
            this.grMain.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grMain.CaptionImage")));
            this.grMain.Controls.Add(this.gridControl_SurgicalCrew);
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(666, 358);
            this.grMain.TabIndex = 0;
            this.grMain.Text = "Danh sách Ekip PT - TT";
            // 
            // gridControl_SurgicalCrew
            // 
            this.gridControl_SurgicalCrew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_SurgicalCrew.Location = new System.Drawing.Point(2, 23);
            this.gridControl_SurgicalCrew.MainView = this.gridView_SurgicalCrew;
            this.gridControl_SurgicalCrew.Name = "gridControl_SurgicalCrew";
            this.gridControl_SurgicalCrew.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ref_PositionCode,
            this.ref_EmployeeCode});
            this.gridControl_SurgicalCrew.Size = new System.Drawing.Size(662, 333);
            this.gridControl_SurgicalCrew.TabIndex = 0;
            this.gridControl_SurgicalCrew.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_SurgicalCrew});
            this.gridControl_SurgicalCrew.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Service_Category_ProcessGridKey);
            // 
            // gridView_SurgicalCrew
            // 
            this.gridView_SurgicalCrew.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_SurgicalCrew.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_SurgicalCrew.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_SurgicalCrew.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Sur_RowID,
            this.col_Sur_EmployeeCode,
            this.col_Sur_PositionCode,
            this.col_Sur_STT,
            this.col_Sur_EmployeeName,
            this.col_Sur_Role});
            this.gridView_SurgicalCrew.GridControl = this.gridControl_SurgicalCrew;
            this.gridView_SurgicalCrew.GroupPanelText = "Nhóm loại viện phí theo nhóm!";
            this.gridView_SurgicalCrew.Name = "gridView_SurgicalCrew";
            this.gridView_SurgicalCrew.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục (loại viện phí).";
            this.gridView_SurgicalCrew.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_SurgicalCrew.OptionsView.ShowFooter = true;
            this.gridView_SurgicalCrew.OptionsView.ShowGroupPanel = false;
            this.gridView_SurgicalCrew.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_SurgicalCrew_InvalidRowException);
            this.gridView_SurgicalCrew.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_SurgicalCrew_ValidateRow);
            // 
            // col_Sur_RowID
            // 
            this.col_Sur_RowID.AppearanceCell.Options.UseTextOptions = true;
            this.col_Sur_RowID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Sur_RowID.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Sur_RowID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Sur_RowID.Caption = "RowID";
            this.col_Sur_RowID.FieldName = "RowID";
            this.col_Sur_RowID.Name = "col_Sur_RowID";
            this.col_Sur_RowID.OptionsColumn.AllowEdit = false;
            this.col_Sur_RowID.OptionsColumn.AllowSize = false;
            this.col_Sur_RowID.Width = 110;
            // 
            // col_Sur_EmployeeCode
            // 
            this.col_Sur_EmployeeCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Sur_EmployeeCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Sur_EmployeeCode.Caption = "Bác sĩ, Kỹ Thuật Viên";
            this.col_Sur_EmployeeCode.ColumnEdit = this.ref_EmployeeCode;
            this.col_Sur_EmployeeCode.FieldName = "EmployeeCode";
            this.col_Sur_EmployeeCode.Name = "col_Sur_EmployeeCode";
            this.col_Sur_EmployeeCode.Visible = true;
            this.col_Sur_EmployeeCode.VisibleIndex = 0;
            this.col_Sur_EmployeeCode.Width = 242;
            // 
            // ref_EmployeeCode
            // 
            this.ref_EmployeeCode.AutoHeight = false;
            this.ref_EmployeeCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_EmployeeCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeCode", "Mã NV"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeName", "Họ & Tên")});
            this.ref_EmployeeCode.Name = "ref_EmployeeCode";
            this.ref_EmployeeCode.NullText = "...";
            // 
            // col_Sur_PositionCode
            // 
            this.col_Sur_PositionCode.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Sur_PositionCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Sur_PositionCode.Caption = "Vị trí";
            this.col_Sur_PositionCode.ColumnEdit = this.ref_PositionCode;
            this.col_Sur_PositionCode.FieldName = "PositionCode";
            this.col_Sur_PositionCode.Name = "col_Sur_PositionCode";
            this.col_Sur_PositionCode.Visible = true;
            this.col_Sur_PositionCode.VisibleIndex = 1;
            this.col_Sur_PositionCode.Width = 281;
            // 
            // ref_PositionCode
            // 
            this.ref_PositionCode.AutoHeight = false;
            this.ref_PositionCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ref_PositionCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PositionCode", "ID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PositionName", "Vị trí")});
            this.ref_PositionCode.Name = "ref_PositionCode";
            this.ref_PositionCode.NullText = "...";
            // 
            // col_Sur_STT
            // 
            this.col_Sur_STT.AppearanceCell.Options.UseTextOptions = true;
            this.col_Sur_STT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Sur_STT.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Sur_STT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Sur_STT.Caption = "STT";
            this.col_Sur_STT.DisplayFormat.FormatString = "#,###";
            this.col_Sur_STT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Sur_STT.FieldName = "STT";
            this.col_Sur_STT.Name = "col_Sur_STT";
            this.col_Sur_STT.Visible = true;
            this.col_Sur_STT.VisibleIndex = 2;
            this.col_Sur_STT.Width = 123;
            // 
            // col_Sur_EmployeeName
            // 
            this.col_Sur_EmployeeName.Caption = "EmployeeName";
            this.col_Sur_EmployeeName.Name = "col_Sur_EmployeeName";
            // 
            // col_Sur_Role
            // 
            this.col_Sur_Role.Caption = "Role";
            this.col_Sur_Role.Name = "col_Sur_Role";
            // 
            // frmEkipPTTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 358);
            this.Controls.Add(this.grMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEkipPTTT";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo Ekip PT - TT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEkipPTTT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.grMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_SurgicalCrew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_SurgicalCrew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_EmployeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ref_PositionCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grMain;
        private DevExpress.XtraGrid.GridControl gridControl_SurgicalCrew;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_SurgicalCrew;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sur_PositionCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sur_RowID;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sur_EmployeeCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sur_STT;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ref_PositionCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sur_EmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sur_Role;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ref_EmployeeCode;
    }
}