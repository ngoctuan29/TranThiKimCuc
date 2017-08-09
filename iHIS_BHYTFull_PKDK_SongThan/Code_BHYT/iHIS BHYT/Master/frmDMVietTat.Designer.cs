namespace Ps.Clinic.Master
{
    partial class frmDMVietTat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMVietTat));
            this.gridControl_DiagnosisAbbre = new DevExpress.XtraGrid.GridControl();
            this.gridView_DiagnosisAbbre = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_RowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_CharacterCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_CharacterName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DiagnosisAbbre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DiagnosisAbbre)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_DiagnosisAbbre
            // 
            this.gridControl_DiagnosisAbbre.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl_DiagnosisAbbre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_DiagnosisAbbre.Location = new System.Drawing.Point(0, 0);
            this.gridControl_DiagnosisAbbre.MainView = this.gridView_DiagnosisAbbre;
            this.gridControl_DiagnosisAbbre.Name = "gridControl_DiagnosisAbbre";
            this.gridControl_DiagnosisAbbre.Size = new System.Drawing.Size(628, 335);
            this.gridControl_DiagnosisAbbre.TabIndex = 0;
            this.gridControl_DiagnosisAbbre.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_DiagnosisAbbre});
            this.gridControl_DiagnosisAbbre.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl_DiagnosisAbbre_ProcessGridKey);
            // 
            // gridView_DiagnosisAbbre
            // 
            this.gridView_DiagnosisAbbre.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_DiagnosisAbbre.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_RowID,
            this.col_CharacterCode,
            this.col_CharacterName});
            this.gridView_DiagnosisAbbre.GridControl = this.gridControl_DiagnosisAbbre;
            this.gridView_DiagnosisAbbre.Name = "gridView_DiagnosisAbbre";
            this.gridView_DiagnosisAbbre.NewItemRowText = "Khai báo ký tự viết tắt";
            this.gridView_DiagnosisAbbre.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_DiagnosisAbbre.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_DiagnosisAbbre.OptionsFind.FindFilterColumns = "CharacterCode";
            this.gridView_DiagnosisAbbre.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gridView_DiagnosisAbbre.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_DiagnosisAbbre.OptionsView.ShowFooter = true;
            this.gridView_DiagnosisAbbre.OptionsView.ShowGroupPanel = false;
            this.gridView_DiagnosisAbbre.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_DiagnosisAbbre_InvalidRowException);
            this.gridView_DiagnosisAbbre.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_DiagnosisAbbre_ValidateRow);
            // 
            // col_RowID
            // 
            this.col_RowID.Caption = "ID";
            this.col_RowID.FieldName = "RowID";
            this.col_RowID.Name = "col_RowID";
            // 
            // col_CharacterCode
            // 
            this.col_CharacterCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_CharacterCode.AppearanceHeader.Options.UseFont = true;
            this.col_CharacterCode.Caption = "Ký tự viết tắt";
            this.col_CharacterCode.FieldName = "CharacterCode";
            this.col_CharacterCode.Name = "col_CharacterCode";
            this.col_CharacterCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CharacterCode", "Count: {0:#,#}", 0)});
            this.col_CharacterCode.Visible = true;
            this.col_CharacterCode.VisibleIndex = 0;
            this.col_CharacterCode.Width = 101;
            // 
            // col_CharacterName
            // 
            this.col_CharacterName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_CharacterName.AppearanceHeader.Options.UseFont = true;
            this.col_CharacterName.Caption = "Nội dung viết tắt";
            this.col_CharacterName.FieldName = "CharacterName";
            this.col_CharacterName.Name = "col_CharacterName";
            this.col_CharacterName.Visible = true;
            this.col_CharacterName.VisibleIndex = 1;
            this.col_CharacterName.Width = 511;
            // 
            // frmDMVietTat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 335);
            this.Controls.Add(this.gridControl_DiagnosisAbbre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDMVietTat";
            this.Text = "frmDMVietTat";
            this.Load += new System.EventHandler(this.frmDMVietTat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DiagnosisAbbre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DiagnosisAbbre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_DiagnosisAbbre;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_DiagnosisAbbre;
        private DevExpress.XtraGrid.Columns.GridColumn col_RowID;
        private DevExpress.XtraGrid.Columns.GridColumn col_CharacterCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_CharacterName;

    }
}