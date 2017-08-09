namespace Ps.Clinic.Master
{
    partial class frmLoiDan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoiDan));
            this.gridControl_Advice = new DevExpress.XtraGrid.GridControl();
            this.gridView_Advice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Advice_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Advice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Advice)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Advice
            // 
            this.gridControl_Advice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Advice.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Advice.MainView = this.gridView_Advice;
            this.gridControl_Advice.Name = "gridControl_Advice";
            this.gridControl_Advice.Size = new System.Drawing.Size(612, 289);
            this.gridControl_Advice.TabIndex = 2;
            this.gridControl_Advice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Advice});
            this.gridControl_Advice.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_Advice_ProcessGridKey);
            // 
            // gridView_Advice
            // 
            this.gridView_Advice.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_Advice.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Blue;
            this.gridView_Advice.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Advice.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView_Advice.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_Advice.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView_Advice.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView_Advice.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_Advice.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Advice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_RowID,
            this.col_Advice_Name});
            this.gridView_Advice.GridControl = this.gridControl_Advice;
            this.gridView_Advice.Name = "gridView_Advice";
            this.gridView_Advice.NewItemRowText = "Nhập thêm mới mã, tên diễn giải cho danh mục (Lời dặn).";
            this.gridView_Advice.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Advice.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Advice.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gridView_Advice.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Advice.OptionsView.ShowFooter = true;
            this.gridView_Advice.OptionsView.ShowGroupPanel = false;
            this.gridView_Advice.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_Advice_InvalidRowException);
            this.gridView_Advice.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_Advice_ValidateRow);
            this.gridView_Advice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_Advice_KeyDown);
            // 
            // col_RowID
            // 
            this.col_RowID.Caption = "STT";
            this.col_RowID.FieldName = "RowID";
            this.col_RowID.Name = "col_RowID";
            // 
            // col_Advice_Name
            // 
            this.col_Advice_Name.Caption = "Tên diễn giải lời dặn";
            this.col_Advice_Name.FieldName = "AdvicesName";
            this.col_Advice_Name.Name = "col_Advice_Name";
            this.col_Advice_Name.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "RowID", "Count: {0:#,#}")});
            this.col_Advice_Name.Visible = true;
            this.col_Advice_Name.VisibleIndex = 0;
            // 
            // frmLoiDan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 289);
            this.Controls.Add(this.gridControl_Advice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLoiDan";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Khai báo danh mục lời dặn bệnh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLoiDan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Advice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Advice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Advice;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Advice;
        private DevExpress.XtraGrid.Columns.GridColumn col_Advice_Name;
        private DevExpress.XtraGrid.Columns.GridColumn col_RowID;
    }
}