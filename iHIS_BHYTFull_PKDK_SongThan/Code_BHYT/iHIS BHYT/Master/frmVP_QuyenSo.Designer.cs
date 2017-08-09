namespace Ps.Clinic.Master
{
    partial class frmVP_QuyenSo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVP_QuyenSo));
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Symbol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_NoteBookName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_FromNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSpin_FromNumber = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.col_ToNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSpin_ToNumber = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.col_WriteNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSpin_WriteNumber = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.col_NoteType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLKup_NoteType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_Hide = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repChk_Hide = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpin_FromNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpin_ToNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpin_WriteNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLKup_NoteType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChk_Hide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView
            // 
            this.gridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_RowID,
            this.col_Symbol,
            this.col_NoteBookName,
            this.col_FromNumber,
            this.col_ToNumber,
            this.col_WriteNumber,
            this.col_NoteType,
            this.col_Hide});
            this.gridView.GridControl = this.gridControl;
            this.gridView.GroupPanelText = "Nhóm dữ liệu!";
            this.gridView.Name = "gridView";
            this.gridView.NewItemRowText = "Thêm mới quyển số biên lai";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_InvalidRowException);
            this.gridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_ValidateRow);
            // 
            // col_RowID
            // 
            this.col_RowID.AppearanceCell.Options.UseTextOptions = true;
            this.col_RowID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_RowID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_RowID.AppearanceHeader.Options.UseFont = true;
            this.col_RowID.AppearanceHeader.Options.UseTextOptions = true;
            this.col_RowID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_RowID.Caption = "ID";
            this.col_RowID.FieldName = "RowID";
            this.col_RowID.Name = "col_RowID";
            this.col_RowID.OptionsColumn.AllowEdit = false;
            this.col_RowID.OptionsColumn.AllowFocus = false;
            this.col_RowID.OptionsColumn.ReadOnly = true;
            this.col_RowID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_RowID.Visible = true;
            this.col_RowID.VisibleIndex = 0;
            this.col_RowID.Width = 53;
            // 
            // col_Symbol
            // 
            this.col_Symbol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Symbol.AppearanceHeader.Options.UseFont = true;
            this.col_Symbol.Caption = "Ký hiệu";
            this.col_Symbol.FieldName = "Symbol";
            this.col_Symbol.Name = "col_Symbol";
            this.col_Symbol.Visible = true;
            this.col_Symbol.VisibleIndex = 1;
            this.col_Symbol.Width = 76;
            // 
            // col_NoteBookName
            // 
            this.col_NoteBookName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_NoteBookName.AppearanceHeader.Options.UseFont = true;
            this.col_NoteBookName.Caption = "Tên sổ";
            this.col_NoteBookName.FieldName = "NoteBookName";
            this.col_NoteBookName.Name = "col_NoteBookName";
            this.col_NoteBookName.Visible = true;
            this.col_NoteBookName.VisibleIndex = 2;
            this.col_NoteBookName.Width = 231;
            // 
            // col_FromNumber
            // 
            this.col_FromNumber.AppearanceCell.Options.UseTextOptions = true;
            this.col_FromNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_FromNumber.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_FromNumber.AppearanceHeader.Options.UseFont = true;
            this.col_FromNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.col_FromNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_FromNumber.Caption = "Từ số";
            this.col_FromNumber.ColumnEdit = this.repSpin_FromNumber;
            this.col_FromNumber.FieldName = "FromNumber";
            this.col_FromNumber.Name = "col_FromNumber";
            this.col_FromNumber.Visible = true;
            this.col_FromNumber.VisibleIndex = 3;
            this.col_FromNumber.Width = 79;
            // 
            // repSpin_FromNumber
            // 
            this.repSpin_FromNumber.AutoHeight = false;
            this.repSpin_FromNumber.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSpin_FromNumber.DisplayFormat.FormatString = "#,###";
            this.repSpin_FromNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repSpin_FromNumber.Name = "repSpin_FromNumber";
            // 
            // col_ToNumber
            // 
            this.col_ToNumber.AppearanceCell.Options.UseTextOptions = true;
            this.col_ToNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_ToNumber.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_ToNumber.AppearanceHeader.Options.UseFont = true;
            this.col_ToNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ToNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_ToNumber.Caption = "Đến số";
            this.col_ToNumber.ColumnEdit = this.repSpin_ToNumber;
            this.col_ToNumber.FieldName = "ToNumber";
            this.col_ToNumber.Name = "col_ToNumber";
            this.col_ToNumber.Visible = true;
            this.col_ToNumber.VisibleIndex = 4;
            this.col_ToNumber.Width = 74;
            // 
            // repSpin_ToNumber
            // 
            this.repSpin_ToNumber.AutoHeight = false;
            this.repSpin_ToNumber.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSpin_ToNumber.DisplayFormat.FormatString = "#,###";
            this.repSpin_ToNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repSpin_ToNumber.Name = "repSpin_ToNumber";
            // 
            // col_WriteNumber
            // 
            this.col_WriteNumber.AppearanceCell.Options.UseTextOptions = true;
            this.col_WriteNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_WriteNumber.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_WriteNumber.AppearanceHeader.Options.UseFont = true;
            this.col_WriteNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.col_WriteNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_WriteNumber.Caption = "Ghi đến số";
            this.col_WriteNumber.ColumnEdit = this.repSpin_WriteNumber;
            this.col_WriteNumber.FieldName = "WriteNumber";
            this.col_WriteNumber.Name = "col_WriteNumber";
            this.col_WriteNumber.Visible = true;
            this.col_WriteNumber.VisibleIndex = 5;
            this.col_WriteNumber.Width = 74;
            // 
            // repSpin_WriteNumber
            // 
            this.repSpin_WriteNumber.AutoHeight = false;
            this.repSpin_WriteNumber.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSpin_WriteNumber.DisplayFormat.FormatString = "#,###";
            this.repSpin_WriteNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repSpin_WriteNumber.Name = "repSpin_WriteNumber";
            // 
            // col_NoteType
            // 
            this.col_NoteType.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_NoteType.AppearanceHeader.Options.UseFont = true;
            this.col_NoteType.Caption = "Loại sổ";
            this.col_NoteType.ColumnEdit = this.repLKup_NoteType;
            this.col_NoteType.FieldName = "NoteType";
            this.col_NoteType.Name = "col_NoteType";
            this.col_NoteType.Visible = true;
            this.col_NoteType.VisibleIndex = 6;
            this.col_NoteType.Width = 98;
            // 
            // repLKup_NoteType
            // 
            this.repLKup_NoteType.AutoHeight = false;
            this.repLKup_NoteType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLKup_NoteType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Loại sổ")});
            this.repLKup_NoteType.Name = "repLKup_NoteType";
            this.repLKup_NoteType.NullText = "";
            // 
            // col_Hide
            // 
            this.col_Hide.AppearanceCell.Options.UseTextOptions = true;
            this.col_Hide.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Hide.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_Hide.AppearanceHeader.Options.UseFont = true;
            this.col_Hide.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Hide.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_Hide.Caption = "Kh. Dùng";
            this.col_Hide.ColumnEdit = this.repChk_Hide;
            this.col_Hide.FieldName = "Hide";
            this.col_Hide.Name = "col_Hide";
            this.col_Hide.Visible = true;
            this.col_Hide.VisibleIndex = 7;
            this.col_Hide.Width = 66;
            // 
            // repChk_Hide
            // 
            this.repChk_Hide.AutoHeight = false;
            this.repChk_Hide.DisplayValueChecked = "1";
            this.repChk_Hide.DisplayValueGrayed = "0";
            this.repChk_Hide.DisplayValueUnchecked = "0";
            this.repChk_Hide.Name = "repChk_Hide";
            this.repChk_Hide.ValueChecked = 1;
            this.repChk_Hide.ValueGrayed = 0;
            this.repChk_Hide.ValueUnchecked = 0;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repSpin_FromNumber,
            this.repSpin_ToNumber,
            this.repSpin_WriteNumber,
            this.repChk_Hide,
            this.repLKup_NoteType});
            this.gridControl.Size = new System.Drawing.Size(769, 366);
            this.gridControl.TabIndex = 3;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.gridControl.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_ProcessGridKey);
            // 
            // frmVP_QuyenSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 366);
            this.ControlBox = false;
            this.Controls.Add(this.gridControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVP_QuyenSo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh mục chẩn đoán bệnh - ICD 10";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVP_QuyenSo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpin_FromNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpin_ToNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpin_WriteNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLKup_NoteType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChk_Hide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn col_ToNumber;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Columns.GridColumn col_RowID;
        private DevExpress.XtraGrid.Columns.GridColumn col_FromNumber;
        private DevExpress.XtraGrid.Columns.GridColumn col_Symbol;
        private DevExpress.XtraGrid.Columns.GridColumn col_NoteBookName;
        private DevExpress.XtraGrid.Columns.GridColumn col_WriteNumber;
        private DevExpress.XtraGrid.Columns.GridColumn col_NoteType;
        private DevExpress.XtraGrid.Columns.GridColumn col_Hide;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repSpin_FromNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repSpin_ToNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repSpin_WriteNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repChk_Hide;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLKup_NoteType;
    }
}