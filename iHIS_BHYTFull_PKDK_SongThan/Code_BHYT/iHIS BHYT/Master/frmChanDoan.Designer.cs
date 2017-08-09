namespace Ps.Clinic.Master
{
    partial class frmChanDoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChanDoan));
            this.gridView_ICD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DiagnosisCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ICDName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl_ICD = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ICD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ICD)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView_ICD
            // 
            this.gridView_ICD.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_ICD.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_ICD.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_ICD.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_ICD.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_RowID,
            this.gridColumn1,
            this.gridColumn2,
            this.col_DiagnosisCode,
            this.col_ICDName});
            this.gridView_ICD.GridControl = this.gridControl_ICD;
            this.gridView_ICD.GroupPanelText = "Nhóm dữ liệu!";
            this.gridView_ICD.Name = "gridView_ICD";
            this.gridView_ICD.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục chẩn đoán bệnh (ICD-10).";
            this.gridView_ICD.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_ICD.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_ICD.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gridView_ICD.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_ICD.OptionsView.ShowFooter = true;
            this.gridView_ICD.OptionsView.ShowGroupPanel = false;
            this.gridView_ICD.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_ICD_InvalidRowException);
            this.gridView_ICD.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_ICD_ValidateRow);
            this.gridView_ICD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_ICD_KeyDown);
            // 
            // col_RowID
            // 
            this.col_RowID.AppearanceCell.Options.UseTextOptions = true;
            this.col_RowID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_RowID.AppearanceHeader.Options.UseTextOptions = true;
            this.col_RowID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_RowID.Caption = "STT";
            this.col_RowID.FieldName = "RowID";
            this.col_RowID.Name = "col_RowID";
            this.col_RowID.OptionsColumn.AllowEdit = false;
            this.col_RowID.OptionsColumn.AllowFocus = false;
            this.col_RowID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.col_RowID.OptionsColumn.AllowSize = false;
            this.col_RowID.OptionsColumn.ReadOnly = true;
            this.col_RowID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.col_RowID.Width = 63;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Chương";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowSize = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 150;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Phân loại bệnh";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowSize = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 268;
            // 
            // col_DiagnosisCode
            // 
            this.col_DiagnosisCode.Caption = "Mã ICD-10";
            this.col_DiagnosisCode.FieldName = "DiagnosisCode";
            this.col_DiagnosisCode.Name = "col_DiagnosisCode";
            this.col_DiagnosisCode.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.col_DiagnosisCode.OptionsColumn.AllowSize = false;
            this.col_DiagnosisCode.Visible = true;
            this.col_DiagnosisCode.VisibleIndex = 2;
            this.col_DiagnosisCode.Width = 89;
            // 
            // col_ICDName
            // 
            this.col_ICDName.Caption = "Tên - nội dung chẩn đoán bệnh";
            this.col_ICDName.FieldName = "DiagnosisName";
            this.col_ICDName.Name = "col_ICDName";
            this.col_ICDName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.col_ICDName.Visible = true;
            this.col_ICDName.VisibleIndex = 3;
            this.col_ICDName.Width = 436;
            // 
            // gridControl_ICD
            // 
            this.gridControl_ICD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_ICD.Location = new System.Drawing.Point(0, 0);
            this.gridControl_ICD.MainView = this.gridView_ICD;
            this.gridControl_ICD.Name = "gridControl_ICD";
            this.gridControl_ICD.Size = new System.Drawing.Size(769, 366);
            this.gridControl_ICD.TabIndex = 3;
            this.gridControl_ICD.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_ICD});
            this.gridControl_ICD.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_ICD_ProcessGridKey);
            // 
            // frmChanDoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 366);
            this.ControlBox = false;
            this.Controls.Add(this.gridControl_ICD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChanDoan";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh mục chẩn đoán bệnh - ICD 10";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChanDoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ICD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ICD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView_ICD;
        private DevExpress.XtraGrid.Columns.GridColumn col_ICDName;
        private DevExpress.XtraGrid.GridControl gridControl_ICD;
        private DevExpress.XtraGrid.Columns.GridColumn col_RowID;
        private DevExpress.XtraGrid.Columns.GridColumn col_DiagnosisCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;

    }
}